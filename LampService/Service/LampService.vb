Imports System.ServiceModel.Configuration
Imports System.Threading.Tasks
Imports LampCommon
Imports LampService

''' <summary>
''' The receiver class has all privildegeds to the database 
''' runs on the server side
''' </summary>
Public Class LampService
    Implements ILampService


    Public Property Database As TemplateDatabase

#Region "Constructors"
    Sub New()
        Database = New TemplateDatabase(Configuration.ConfigurationManager.AppSettings("databasePath"))
    End Sub

    Sub New(databasePath As String)
        Database = New TemplateDatabase(databasePath)
    End Sub

#End Region


#Region "ImplementILampService"
    Public Function GetTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper Implements ILampService.GetTemplate
        Dim response As New LampTemplateWrapper

        Try
            If guid Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If


            Dim user = auth.user
            Dim template = Database.SelectTemplate(guid)
            If Not HasGetTemplatePerms(user, template) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If


            If template Is Nothing Then
                response.Status = LampStatus.DoesNotExist
                Return response
            End If


            response.Status = LampStatus.OK
            response.Template = template
                Return response




        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try


    End Function

    Public Function AddTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.AddTemplate
        Dim response As LampStatus

        Try
            If template Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user
            If user Is Nothing Then
                response = auth.Status
                Return response
            End If
            If Not HasAddTemplatePerms(user, template) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If Database.SelectTemplateData(template.GUID) IsNot Nothing Then
                response = LampStatus.GuidConflict
                Return response
            End If

            Database.SetTemplate(template, user.UserId, user.UserId)
            response = LampStatus.OK
            Return response
        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try

    End Function


    Public Function EditTemplate(credentials As LampCredentials, newTemplate As LampTemplate) As LampStatus Implements ILampService.EditTemplate
        Dim response As LampStatus

        Try
            If newTemplate Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim oldTemplate = Database.SelectTemplate(newTemplate.GUID)

            If Not HasEditTemplatePerms(user, oldTemplate, newTemplate) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If oldTemplate Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If


            Database.SetTemplate(newTemplate, user.UserId)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Function RemoveTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveTemplate
        Dim response As LampStatus
        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user
            Dim template = Database.SelectTemplate(guid)
            If Not HasRemoveTemplatePerms(user, template) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If template Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If

            Database.RemoveTemplate(template.GUID)
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
        End Try
        Return response
    End Function

    Public Function GetUser(credentials As LampCredentials, guid As String) As LampUserWrapper Implements ILampService.GetUser
        Dim response As New LampUserWrapper()

        Try
            If guid Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Authenticate(credentials)
            If auth.user IsNot Nothing Then

                Dim thisUser = auth.user

                Dim gottenUser = Database.SelectUser(guid)

                If HasGetUserPerms(thisUser, gottenUser) Then
                    response.user = gottenUser
                    response.Status = LampStatus.OK
                Else
                    response.Status = LampStatus.NoAccess

                End If
            Else
                response.Status = auth.Status
            End If

        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
        End Try

        Return response
    End Function

    Public Function AddUser(credentials As LampCredentials, toAddUser As LampUser) As LampStatus Implements ILampService.AddUser
        Dim response As LampStatus

        Try
            If toAddUser Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim thisUser As LampUser
            If credentials IsNot Nothing Then
                Dim auth = Authenticate(credentials)
                If auth.user Is Nothing Then
                    response = auth.Status
                    Return response
                End If
                thisUser = auth.user
            Else
                thisUser = LampUser.Guest
            End If




            If Not HasAddUserPerms(thisUser, toAddUser) Then
                response = LampStatus.NoAccess
                Return response
            End If

            Dim exists = Database.UserExists(toAddUser)
            If exists <> LampStatus.OK Then
                response = exists
                Return response
            End If


            Database.SetUser(toAddUser)
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Function DebugAddUser(user As LampUser) As LampStatus
        Dim response As LampStatus
        Dim exists = Database.UserExists(user)
        If exists <> LampStatus.OK Then
            response = exists
            Return response
        End If

        Database.SetUser(user)
        response = LampStatus.OK

        Return response
    End Function

    Public Function EditUser(credentials As LampCredentials, newUser As LampUser) As LampStatus Implements ILampService.EditUser
        Dim response As LampStatus

        Try
            If newUser Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim thisUser = auth.user

            Dim oldUser = Database.SelectUser(newUser.UserId)

            If Not HasEditUserPerms(thisUser, oldUser, newUser) Then
                response = LampStatus.NoAccess
                Return response
            End If

            Dim exists = Database.UserExists(newUser)
            If exists <> LampStatus.OK Then
                response = exists
                Return response
            End If

            If oldUser Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If


            Database.SetUser(newUser)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try

    End Function

    ''' <summary>
    ''' only admins
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="newUser"></param>
    ''' <returns></returns>
    Public Function RemoveUser(credentials As LampCredentials, newUser As LampUser) As LampStatus Implements ILampService.RemoveUser
        Dim response As LampStatus

        Try
            If newUser Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If


            Dim thisUser = auth.user
            Dim oldUser = Database.SelectUser(newUser.UserId)

            If oldUser Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If

            If Not HasEditUserPerms(thisUser, oldUser, newUser) Then
                response = LampStatus.NoAccess
                Return response
            End If

            ' passed all checks
            Database.SetUser(newUser)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try

    End Function

    ''' <summary>
    ''' returns the user corresponding w/ credentials
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    Public Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampService.Authenticate
        Dim response As New LampUserWrapper()

        Try
            If credentials Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            If credentials.Username Is Nothing Or credentials.Password Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            Dim user = Database.SelectUser(credentials.Username, credentials.Password)
            If user Is Nothing Then
                response.Status = LampStatus.InvalidUsernameOrPassword
                Return response
            End If

            response.user = user
            response.Status = LampStatus.OK
            Return response

        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    ''' <summary>
    ''' only elevated / submitter can view their own template by default
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function GetUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper Implements ILampService.GetUnapprovedTemplate
        Dim response As New LampTemplateWrapper()

        Try
            If guid Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If

            Dim user = auth.user
            Dim template = Database.SelectTemplate(guid)
            If Not HasGetUnapprovedTemplatePerms(user, template) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If


            If template Is Nothing Then
                response.Status = LampStatus.DoesNotExist
                Return response
            End If

            response.Template = template
            response.Status = LampStatus.OK
            Return response

        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    ''' <summary>
    ''' all standard + can submit an unapproved template
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="template"></param>
    ''' <returns></returns>
    Public Function AddUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.AddUnapprovedTemplate
        Dim response As LampStatus

        Try
            If template Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            If Database.SelectTemplateData(template.GUID) IsNot Nothing Then
                response = LampStatus.GuidConflict
                Return response
            End If

            If Not HasAddUnapprovedTemplatePerms(user, template) Then
                response = LampStatus.NoAccess
                Return response
            End If

            ' passed all tests
            Database.SetTemplate(template, user.UserId) ' no approver
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try

    End Function

    ''' <summary>
    ''' only submitter / elevated + can edit
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="newTemplate"></param>
    ''' <returns></returns>
    Public Function EditUnapprovedTemplate(credentials As LampCredentials, newTemplate As LampTemplate) As LampStatus Implements ILampService.EditUnapprovedTemplate
        Dim response As LampStatus

        Try
            If newTemplate Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim oldTemplate = Database.SelectTemplate(newTemplate.GUID)

            If oldTemplate Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If

            If Not HasEditUnapprovedTemplatePerms(user, oldTemplate) Then
                response = LampStatus.NoAccess
                Return response
            End If

            ' passed all tests
            Database.SetTemplate(newTemplate, user.UserId) ' no approver
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    ''' <summary>
    ''' only submitter and elevated + can remove
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function RemoveUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveUnapprovedTemplate
        Dim response As LampStatus

        Try
            Dim auth = Authenticate(credentials)
            If auth.user IsNot Nothing Then

                Dim user = auth.user

                Dim oldTemplate = Database.SelectTemplate(guid)

                If oldTemplate IsNot Nothing Then
                    If HasRemoveUnapprovedTemplatePerms(user, oldTemplate) Then
                        Database.RemoveTemplate(guid)
                        response = LampStatus.OK

                    Else
                        response = LampStatus.NoAccess
                    End If
                Else
                    response = LampStatus.DoesNotExist
                End If
            Else
                response = auth.Status

            End If


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
        End Try

        Return response
    End Function

    Public Function ApproveTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.ApproveTemplate
        Dim response As LampStatus

        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim template = Database.SelectTemplate(guid)

            If template Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If

            If template.Approved = True Then
                response = LampStatus.InvalidOperation
                Return response
            End If

            If Not HasApproveTemplatePerms(user, template) Then
                response = LampStatus.NoAccess
                Return response
            End If


            ' passed all tests
            Database.SetTemplate(template, template.CreatorId, user.UserId) ' new approver
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Function RevokeTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RevokeTemplate
        Dim response As LampStatus

        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim template = Database.SelectTemplate(guid)

            If template Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If

            If template.Approved = False Then
                response = LampStatus.InvalidOperation
                Return response
            End If

            If Not HasRevokeTemplatePerms(user, template) Then
                response = LampStatus.NoAccess
                Return response
            End If


            ' passed all tests
            Database.SetTemplate(template, template.CreatorId, Nothing) ' remove the approver
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function


    Public Function SelectDxf(credentials As LampCredentials, guid As String) As LampDxfDocumentWrapper Implements ILampService.SelectDxf
        Dim response As New LampDxfDocumentWrapper

        Try
            If guid Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If


            Dim user = auth.user
            If user Is Nothing Then
                response.Status = LampStatus.InvalidUsernameOrPassword
                Return response
            End If

            Dim template = Database.SelectTemplate(guid)
            If template Is Nothing Then
                response.Status = LampStatus.DoesNotExist
                Return response
            End If

            If Not HasGetTemplatePerms(user, template) Then
                response.Status = LampStatus.NoAccess
                Return response
            Else
                response.Status = LampStatus.OK
                response.Drawing = template.BaseDrawing
                Return response
            End If




        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function


    ''' <summary>
    ''' only admins and the creator of the job can view their own job
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function GetJob(credentials As LampCredentials, guid As String) As LampJobWrapper Implements ILampService.GetJob
        ' check if user got permissions
        Dim response As New LampJobWrapper


        Try
            If guid Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If

            Dim user = auth.user
            Dim job = Database.SelectJob(guid)
            If job Is Nothing Then
                ' no job found
                response.Status = LampStatus.DoesNotExist
                Return response
            End If

            If Not HasGetJobPerms(user, job) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If


            response.Job = job
            response.Status = LampStatus.OK
            Return response

        Catch ex As Exception
            Log(ex)
            response.Status = LampStatus.InternalServerError
            Return response
        End Try
    End Function

    Public Function AddJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampService.AddJob
        Dim response As LampStatus

        Try
            If job Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            If Not HasAddJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If Database.SelectJob(job.JobId) IsNot Nothing Then
                ' already exists a job, 
                response = LampStatus.GuidConflict
                Return response
            End If

            If Database.SelectTemplateData(job.Template.GUID) Is Nothing Then ' check if exists
                response = LampStatus.NoTemplateFound
                Return response
            End If




            Database.SetJob(job)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            Log(ex)
            response = LampStatus.InternalServerError
            Return response
        End Try
    End Function


    Public Function EditJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampService.EditJob
        Dim response As LampStatus

        Try
            If job Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            If Not HasEditJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If Not Database.SelectJob(job.JobId) IsNot Nothing Then
                ' already exists a job, 
                response = LampStatus.GuidConflict
                Return response
            End If

            If Database.SelectTemplateData(job.Template.GUID) Is Nothing Then ' check if exists
                response = LampStatus.NoTemplateFound
                Return response
            End If


            Database.SetJob(job)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            Log(ex)
            response = LampStatus.InternalServerError
            Return response
        End Try
    End Function

    Public Function RemoveJob(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveJob
        Dim response As LampStatus

        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim job = Database.SelectJob(guid)

            If Not HasRemoveJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If
            If Not job Is Nothing Then
                ' no job exists
                response = LampStatus.DoesNotExist
                Return response
            End If



            Database.RemoveJob(guid)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            Log(ex)
            response = LampStatus.InternalServerError
            Return response
        End Try
    End Function


    Public Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate) Implements ILampService.GetAllTemplate
        ' TODO add hasview template
        Return Database.GetAllTemplate()
    End Function

    Public Const MAX_TEMPLATES_PER_REQUEST = 50

    Public Function GetTemplateList(credentials As LampCredentials, tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampSort) As LampTemplateListWrapper Implements ILampService.GetTemplateList
        Dim response As New LampTemplateListWrapper
        Try
            If limit <= 0 Or offset < 0 Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            If limit > MAX_TEMPLATES_PER_REQUEST Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            Select Case approveStatus
                Case LampApprove.All, LampApprove.Approved, LampApprove.Unapproved
                    ' allow
                Case Else
                    response.Status = LampStatus.InvalidParameters
                    Return response
            End Select

            If tags Is Nothing Then
                tags = New List(Of String)
            End If
            If byUser Is Nothing Then
                byUser = New List(Of String)
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If
            Dim user = auth.user

            If Not HasGetTemplateListPerms(user, approveStatus, byUser) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If

            response.Templates = Database.GetMultipleTemplate(tags, byUser, limit, offset, approveStatus, orderBy)
            response.Status = LampStatus.OK
            Return response

        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Const MAX_JOBS_PER_REQUEST = 50

    Public Function GetJobList(credentials As LampCredentials, byUser As IEnumerable(Of String), limit As Integer, offset As Integer, orderBy As LampSort) As LampJobListWrapper Implements ILampService.GetJobList
        Dim response As New LampJobListWrapper
        'todo

        Try

            If limit <= 0 Or offset < 0 Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            If limit > MAX_JOBS_PER_REQUEST Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            ' blacklist template name sort on jobs
            Select Case orderBy
                Case LampSort.TemplateNameAsc, LampSort.TemplateNameDesc
                    response.Status = LampStatus.InvalidParameters
                    Return response

            End Select

            If byUser Is Nothing Then
                byUser = New List(Of String)
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If
            Dim user = auth.user

            If Not HasGetJobListPerms(user, byUser) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If

            response.Templates = Database.GetMultipleJob(byUser, limit, offset, orderBy)
            response.Status = LampStatus.OK
            Return response

        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function


#End Region


#Region "HasPermissions"

    Public Function HasGetUserTemplateList(user As LampUser) As Boolean
        Return user.PermissionLevel >= UserPermission.Standard
    End Function

    Public Function HasGetTemplateListPerms(user As LampUser, approveStatus As LampApprove, byUser As IEnumerable(Of String)) As Boolean
        ' allow anyone to access approved
        If approveStatus = LampApprove.Approved And user.PermissionLevel >= UserPermission.Standard Then
            Return True
        End If

        '  deny if standard user tries to get unapproved templates from other users
        If user.PermissionLevel < UserPermission.Elevated Then
            If byUser.Count() = 0 Then
                Return false 
            End If
            Dim notUser As Boolean = False
            For Each item In byUser
                If item <> user.UserId Then
                    notUser = True
                    Exit For
                End If
            Next
            If notUser Then
                Return False
            End If
        End If
        Return user.PermissionLevel >= UserPermission.Standard
    End Function

    Public Function HasGetTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        If template.Approved = True Then
            ' anyone can access approved templates
            Return True
        End If

        If user.UserId = template.CreatorId Then
            Return True
            ' same user can access template
        End If

        If user.PermissionLevel >= UserPermission.Elevated Then
            ' greater than normal can access all templates
            Return True
        End If

        Return False
    End Function


    Public Function HasAddTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        Return user.PermissionLevel >= UserPermission.Elevated
    End Function

    Public Function HasEditTemplatePerms(user As LampUser, original As LampTemplate, altered As LampTemplate) As Boolean
        If original IsNot Nothing AndAlso user.UserId = original.CreatorId Then
            Return True
        End If
        If user.PermissionLevel >= UserPermission.Elevated Then
            Return True
        End If
        Return False
    End Function

    Public Function HasRemoveTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        If user.PermissionLevel >= UserPermission.Elevated Then
            Return True
        End If
        If template IsNot Nothing AndAlso template.CreatorId = user.UserId Then
            Return True
        End If
        Return False
    End Function




    Public Function HasGetUnapprovedTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        Return user.PermissionLevel >= UserPermission.Elevated Or user.UserId = template.CreatorId
    End Function

    Public Function HasAddUnapprovedTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        If user.PermissionLevel >= UserPermission.Standard Then
            Return True
        End If
        Return False
    End Function

    Public Function HasEditUnapprovedTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        If user.PermissionLevel >= UserPermission.Elevated OrElse user.UserId = template.CreatorId Then
            Return True
        End If
        Return False
    End Function

    Public Function HasRemoveUnapprovedTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        Return user.UserId = template.CreatorId Or user.PermissionLevel >= UserPermission.Elevated
    End Function





    Public Function HasGetUserPerms(thisUser As LampUser, otherUser As LampUser)
        Return thisUser.PermissionLevel >= UserPermission.Admin
    End Function

    Public Function HasAddUserPerms(thisUser As LampUser, otherUser As LampUser)
        ' allow standard users to be signed up
        If otherUser.PermissionLevel = UserPermission.Standard Then
            Return True
        End If
        Return thisUser.PermissionLevel >= UserPermission.Admin
    End Function

    Public Function HasEditUserPerms(user As LampUser, oldUser As LampUser, newUser As LampUser) As Boolean
        Return oldUser.UserId = user.UserId OrElse user.PermissionLevel >= UserPermission.Admin
    End Function

    Public Function HasRemoveUserPerms(user As LampUser, otherUser As LampUser)
        Return user.PermissionLevel >= UserPermission.Admin
    End Function





    Public Function HasGetJobPerms(user As LampUser, job As LampJob)
        Return user.PermissionLevel >= UserPermission.Admin OrElse job.SubmitId = user.UserId
    End Function

    Public Function HasAddJobPerms(user As LampUser, job As LampJob) As Boolean
        Return user.PermissionLevel >= UserPermission.Elevated
    End Function

    Public Function HasEditJobPerms(thisUser As LampUser, job As LampJob)
        Return thisUser.PermissionLevel >= UserPermission.Admin OrElse thisUser.UserId = job.SubmitId
    End Function

    Public Function HasRemoveJobPerms(user As LampUser, job As LampJob)
        Return user.PermissionLevel >= UserPermission.Admin OrElse job.SubmitId = user.UserId
    End Function





    Public Function HasApproveTemplatePerms(user As LampUser, template As LampTemplate)
        Return user.PermissionLevel >= UserPermission.Elevated
    End Function


    Public Function HasRevokeTemplatePerms(user As LampUser, template As LampTemplate)
        Return user.PermissionLevel >= UserPermission.Elevated
    End Function



    Public Function HasGetJobListPerms(user As LampUser, byUser As IEnumerable(Of String))
        If user.PermissionLevel >= UserPermission.Admin Then
            Return True
        End If
        ' only allow elevated to view own jobs
        If user.PermissionLevel >= UserPermission.Elevated Then
            For Each item In byUser
                If item <> user.UserId Then
                    Return False
                End If
            Next
            Return True
        End If
        Return False

    End Function
















#End Region

    Public Sub ResetDebug()
        Database.ResetDebug()
    End Sub

    Public Sub DeleteDebug()
        Database.DeleteDebug()
    End Sub


End Class





Public Module loggger
    Public Sub Log(x As Object)
        Console.WriteLine(x.ToString)
#If DEBUG Then
        If x.GetType.IsSubclassOf(GetType(Exception)) Or x.GetType() = GetType(Exception) Then
            Dim ex = DirectCast(x, Exception)
            Console.Write(ex.InnerException)
            Throw ex
        End If
#End If
    End Sub
End Module


Public Class LampTemplateListWrapper
    Public Status As LampStatus
    Public Templates As New List(Of LampTemplate)
End Class
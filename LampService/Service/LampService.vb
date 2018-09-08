Imports System.ServiceModel.Configuration
Imports System.Threading.Tasks
Imports LampCommon
Imports LampService.ValidateHelper
Imports LampService.PermsHelper

''' <summary>
''' The receiver class has all privildegeds to the database 
''' runs on the server side
''' </summary>
Public Class LampService
    Implements ILampService


    Public Property Database As TemplateDatabase

    Public Const MAX_TEMPLATES_PER_REQUEST = 50

    Public Const MAX_JOBS_PER_REQUEST = 50

    Public Const MAX_USERS_PER_REQUEST = 50

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

            Dim thisUser As LampUser = Nothing
            If credentials IsNot Nothing Then
                Dim auth = Authenticate(credentials)
                If auth.user Is Nothing Then
                    response = auth.Status
                    Return response
                End If
                thisUser = auth.user
            End If


            If Not HasAddUserPerms(thisUser, toAddUser) Then
                response = LampStatus.NoAccess
                Return response
            End If

            Dim exists = Database.UniqueUser(toAddUser)
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
        Dim exists = Database.UniqueUser(user)
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
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function RemoveUser(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveUser
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


            Dim thisUser = auth.user
            Dim oldUser = Database.SelectUser(guid)

            If Not HasRemoveUserPerms(thisUser, oldUser) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If oldUser Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If

            ' passed all checks
            Database.RemoveUser(oldUser.UserId)
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

            If Not HasApproveTemplatePerms(user, template) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If template Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If

            If template.Approved = True Then
                response = LampStatus.InvalidOperation
                Return response
            End If

            ' passed all tests
            Database.SetTemplateApprover(guid, user.UserId) ' new approver
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
            Database.SetTemplateApprover(guid, Nothing) ' remove the approver
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

            If Not ValidJob(job) Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim submitter = Database.SelectUser(job.SubmitId)
            If submitter.PermissionLevel < UserPermission.Elevated Then
                response = LampStatus.InvalidSubmitter
                Return response
            End If
            If job.ApproverId IsNot Nothing Then
                Dim approver = Database.SelectUser(job.ApproverId)
                If approver Is Nothing OrElse approver.PermissionLevel <= UserPermission.Elevated Then
                    response = LampStatus.InvalidApprover
                    Return response
                End If
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

            If job Is Nothing Then
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

    Public Function ApproveJob(credentials As LampCredentials, jobId As String) As LampStatus Implements ILampService.ApproveJob
        Dim response As LampStatus

        Try
            If jobId Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim job = Database.SelectJob(jobId)

            If Not HasApproveJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If job Is Nothing Then
                ' no job exists
                response = LampStatus.DoesNotExist
                Return response
            End If

            Database.SetJobApprover(jobId, user.UserId)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            Log(ex)
            response = LampStatus.InternalServerError
            Return response
        End Try
    End Function

    Public Function RevokeJob(credentials As LampCredentials, jobId As String) As LampStatus Implements ILampService.RevokeJob
        Dim response As LampStatus

        Try
            If jobId Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim job = Database.SelectJob(jobId)

            If Not HasRevokeJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If job Is Nothing Then
                ' no job exists
                response = LampStatus.DoesNotExist
                Return response
            End If

            Database.SetJobApprover(jobId, Nothing)
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



    Public Function GetTemplateList(credentials As LampCredentials, tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampTemplateSort) As LampTemplateListWrapper Implements ILampService.GetTemplateList
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


    Public Function GetJobList(credentials As LampCredentials, byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampJobSort) As LampJobListWrapper Implements ILampService.GetJobList
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

            response.Templates = Database.GetMultipleJob(byUser, limit, offset, approveStatus, orderBy)
            response.Status = LampStatus.OK
            Return response

        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function



    Public Function GetUserList(credentials As LampCredentials, limit As Integer, offset As Integer, orderBy As LampUserSort) As LampUserListWrapper Implements ILampService.GetUserList
        Dim response As New LampUserListWrapper

        Try
            If limit <= 0 Or offset < 0 Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            If limit > MAX_USERS_PER_REQUEST Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If
            Dim user = auth.user

            If Not HasGetUserList(user) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If

            response.Users = Database.GetMultipleUser(limit, offset, orderBy)
            response.Status = LampStatus.OK

            Return response

        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Return response
        End Try
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
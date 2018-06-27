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

#Region "crap"
    Public Property Database As TemplateDatabase

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
                response.Template = template
                Return response
            End If




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
            If auth.user IsNot Nothing Then
                Dim user = auth.user

                If user IsNot Nothing Then
                    If Database.SelectTemplateMetadata(template.GUID) Is Nothing Then
                        If HasAddTemplatePerms(user, template) Then
                            Database.SetTemplate(template, user.UserId, user.UserId)

                            response = LampStatus.OK
                        Else
                            response = LampStatus.NoAccess
                        End If
                    Else
                        response = LampStatus.GuidConflict
                    End If
                Else

                    response = LampStatus.InvalidUsernameOrPassword
                End If

            Else
                ' no user selected, either no user/password or internal server error
                response = auth.Status

            End If
        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)

        End Try

        Return response
    End Function

    Public Function EditTemplate(credentials As LampCredentials, newTemplate As LampTemplate) As LampStatus Implements ILampService.EditTemplate
        Dim response As LampStatus
        If newTemplate Is Nothing Then
            response = LampStatus.InvalidParameters
            Return response
        End If
        Try
            Dim auth = Authenticate(credentials)
            If auth.user IsNot Nothing Then
                Dim user = auth.user

                If user IsNot Nothing Then
                    Dim oldTemplate = Database.SelectTemplate(newTemplate.GUID)
                    If oldTemplate IsNot Nothing Then
                        If HasEditTemplatePerms(user, oldTemplate, newTemplate) Then
                            Database.SetTemplate(newTemplate, user.UserId, user.UserId)

                            response = LampStatus.OK
                        Else
                            response = LampStatus.NoAccess
                        End If
                    Else
                        response = LampStatus.DoesNotExist
                    End If
                Else

                    response = LampStatus.InvalidUsernameOrPassword
                End If

            Else
                response = auth.Status
            End If

        Catch ex As Exception
            response = LampStatus.InvalidUsernameOrPassword
            Log(ex)
        End Try
        Return response
    End Function

    Public Function RemoveTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveTemplate
        Dim response As LampStatus
        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Authenticate(credentials)
            If auth.user IsNot Nothing Then

                Dim user = auth.user
                Dim template = Database.SelectTemplate(guid)

                If template IsNot Nothing Then

                    If HasRemoveTemplatePerms(user, template) Then
                        Database.RemoveTemplate(template.GUID)
                        response = LampStatus.OK
                    Else
                        response = LampStatus.NoAccess
                    End If
                Else
                    ' template doesnt exist
                    response = LampStatus.DoesNotExist
                End If
            Else
                response = auth.Status
            End If


        Catch ex As Exception
            response = LampStatus.InvalidUsernameOrPassword
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
            Dim auth = Authenticate(credentials)
            If auth.user IsNot Nothing Then

                Dim thisUser = auth.user


                If HasAddUserPerms(thisUser, toAddUser) Then
                    If Database.SelectUser(toAddUser.UserId) IsNot Nothing Then
                        Database.SetUser(toAddUser)
                        response = LampStatus.OK
                    Else
                        response = LampStatus.GuidConflict
                    End If

                Else
                    response = LampStatus.NoAccess

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

    Public Function EditUser(credentials As LampCredentials, newUser As LampUser) As LampStatus Implements ILampService.EditUser
        Dim response As LampStatus

        Try
            If newUser Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Authenticate(credentials)
            If auth.user IsNot Nothing Then

                Dim thisUser = auth.user

                Dim oldUser = Database.SelectUser(newUser.UserId)

                If HasEditUserPerms(thisUser, oldUser, newUser) Then
                    If oldUser IsNot Nothing Then
                        Database.SetUser(newUser)
                        response = LampStatus.OK
                    Else
                        response = LampStatus.DoesNotExist
                    End If

                Else
                    response = LampStatus.NoAccess

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
            If credentials.Username IsNot Nothing And credentials.Password IsNot Nothing Then
                Dim user = Database.SelectUser(credentials.Username, credentials.Password)
                If user Is Nothing Then
                    response.Status = LampStatus.InvalidUsernameOrPassword
                Else
                    response.user = user
                    response.Status = LampStatus.OK
                End If
            Else
                response.Status = LampStatus.InvalidParameters
            End If

        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
        End Try

        Return response
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
            If auth.user IsNot Nothing Then

                Dim user = auth.user

                Dim template = Database.SelectTemplate(guid)
                If template IsNot Nothing Then

                    If HasGetUnapprovedTemplatePerms(user, template) Then
                        response.Template = template
                        response.Status = LampStatus.OK
                    Else
                        response.Status = LampStatus.NoAccess
                    End If

                Else
                    response.Status = LampStatus.DoesNotExist

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

            If Database.SelectTemplateMetadata(template.GUID) IsNot Nothing Then
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
            If Database.SelectJob(job.JobId) IsNot Nothing Then
                ' already exists a job, 
                response = LampStatus.GuidConflict
                Return response
            End If
            If Not HasAddJobPerms(user, job) Then
                response = LampStatus.NoAccess
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
            If Not Database.SelectJob(job.JobId) IsNot Nothing Then
                ' already exists a job, 
                response = LampStatus.GuidConflict
                Return response
            End If

            If Not HasEditJobPerms(user, job) Then
                response = LampStatus.NoAccess
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
            If Not job Is Nothing Then
                ' no job exists
                response = LampStatus.DoesNotExist
                Return response
            End If

            If Not HasRemoveJobPerms(user, job) Then
                response = LampStatus.NoAccess
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















#End Region

#Region "HasPermissions"
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
        If user.UserId = original.CreatorId Then
            Return True
        End If
        If user.PermissionLevel >= UserPermission.Elevated Then
            Return True
        End If
        Return False
    End Function

    Public Function HasRemoveTemplatePerms(user As LampUser, template As LampTemplate)
        If user.UserId >= UserPermission.Admin Then
            Return True
        End If
        Return False
    End Function




    Public Function HasGetUnapprovedTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        Return user.PermissionLevel >= UserPermission.Elevated Or user.UserId = template.CreatorId
    End Function

    Public Function HasAddUnapprovedTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        If user.UserId >= UserPermission.Standard Then
            Return True
        End If
        Return False
    End Function

    Public Function HasEditUnapprovedTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        If user.UserId >= UserPermission.Elevated OrElse user.UserId = template.CreatorId Then
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




















#End Region

    Public Sub ResetDatabase()
        Database.ResetDebug()
    End Sub
End Class





Public Module loggger
    Public Sub Log(x As Object)
        Console.WriteLine(x.ToString)
    End Sub
End Module
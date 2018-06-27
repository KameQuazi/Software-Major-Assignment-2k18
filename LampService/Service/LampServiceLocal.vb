Imports System.Threading.Tasks
Imports LampCommon

Public Class LampServiceLocal
    Inherits LampService
    Implements ILampServiceBoth

    Public Async Function GetTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampServiceAsync.GetTemplateAsync
        Dim response As New LampTemplateWrapper

        Try
            If guid Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If


            Dim user = auth.user

            Dim template = Await Database.SelectTemplateAsync(guid)
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

    Public Async Function AddTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceAsync.AddTemplateAsync
        Dim response As LampStatus
        If template Is Nothing Then
            response = LampStatus.InvalidParameters
            Return response
        End If

        Try
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user IsNot Nothing Then
                Dim user = auth.user

                If user IsNot Nothing Then
                    If Await Database.SelectTemplateMetadataAsync(template.GUID) Is Nothing Then
                        If HasAddTemplatePerms(user, template) Then
                            Await Database.SetTemplateAsync(template, user.UserId, user.UserId)

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
        Catch
            response = LampStatus.InternalServerError
        End Try
        Return response
    End Function

    Public Async Function EditTemplateAsync(credentials As LampCredentials, newTemplate As LampTemplate) As Task(Of LampStatus) Implements ILampServiceAsync.EditTemplateAsync
        Dim response As LampStatus
        If newTemplate Is Nothing Then
            response = LampStatus.InvalidParameters
            Return response
        End If

        Try
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user IsNot Nothing Then
                Dim user = auth.user

                If user IsNot Nothing Then
                    Dim oldTemplate = Await Database.SelectTemplateAsync(newTemplate.GUID)
                    If oldTemplate IsNot Nothing Then
                        If HasEditTemplatePerms(user, oldTemplate, newTemplate) Then
                            Await Database.SetTemplateAsync(newTemplate, user.UserId, user.UserId)

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

    Public Async Function RemoveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceAsync.RemoveTemplateAsync
        Dim response As LampStatus
        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user IsNot Nothing Then

                Dim user = auth.user
                Dim template = Await Database.SelectTemplateAsync(guid)

                If template IsNot Nothing Then

                    If HasRemoveTemplatePerms(user, template) Then
                        Await Database.RemoveTemplateAsync(template.GUID)
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

    Public Async Function GetUserAsync(credentials As LampCredentials, guid As String) As Task(Of LampUserWrapper) Implements ILampServiceAsync.GetUserAsync
        Dim response As New LampUserWrapper()

        Try
            If guid Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user IsNot Nothing Then

                Dim thisUser = auth.user

                Dim gottenUser = Await Database.SelectUserAsync(guid)

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

    Public Async Function AddUserAsync(credentials As LampCredentials, toAddUser As LampUser) As Task(Of LampStatus) Implements ILampServiceAsync.AddUserAsync
        Dim response = LampStatus.OK

        Try
            If toAddUser Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user IsNot Nothing Then

                Dim thisUser = auth.user


                If HasAddUserPerms(thisUser, toAddUser) Then
                    If Await Database.SelectUserAsync(toAddUser.UserId) IsNot Nothing Then
                        Await Database.SetUserAsync(toAddUser)
                        response = LampStatus.OK
                    Else
                        response = LampStatus.GuidConflict
                    End If

                Else
                    response = LampStatus.InvalidUsernameOrPassword

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

    Public Async Function EditUserAsync(credentials As LampCredentials, newUser As LampUser) As Task(Of LampStatus) Implements ILampServiceAsync.EditUserAsync
        Dim response As LampStatus

        Try
            If newUser Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user IsNot Nothing Then

                Dim thisUser = auth.user

                Dim oldUser = Await Database.SelectUserAsync(newUser.UserId)

                If HasEditUserPerms(thisUser, oldUser, newUser) Then
                    If oldUser IsNot Nothing Then
                        Await Database.SetUserAsync(newUser)
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

    Public Async Function RemoveUserAsync(credentials As LampCredentials, newUser As LampUser) As Task(Of LampStatus) Implements ILampServiceAsync.RemoveUserAsync
        Dim response As LampStatus

        Try
            If newUser Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If


            Dim thisUser = auth.user
            Dim oldUser = Await Database.SelectUserAsync(newUser.UserId)

            If oldUser Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If

            If Not HasEditUserPerms(thisUser, oldUser, newUser) Then
                response = LampStatus.NoAccess
                Return response
            End If

            ' passed all checks
            Await Database.SetUserAsync(newUser)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Async Function AuthenticateAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampServiceAsync.AuthenticateAsync
        Dim user As LampUser = Nothing
        Dim response As New LampUserWrapper()

        Try
            If credentials.Username IsNot Nothing And credentials.Password IsNot Nothing Then
                user = Await Database.SelectUserAsync(credentials.Username, credentials.Password)
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

    Public Function GetAllTemplateAsync(credentials As LampCredentials) As Task(Of List(Of LampTemplate)) Implements ILampServiceAsync.GetAllTemplateAsync
        'to do
        Return Database.GetAllTemplateAsync()
    End Function

    Public Async Function GetUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampServiceAsync.GetUnapprovedTemplateAsync
        Dim response As New LampTemplateWrapper()

        Try
            If guid Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user IsNot Nothing Then

                Dim user = auth.user

                Dim template = Await Database.SelectTemplateAsync(guid)
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

    Public Async Function AddUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceAsync.AddUnapprovedTemplateAsync
        Dim response As LampStatus

        Try
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user IsNot Nothing Then

                Dim user = auth.user


                If HasAddUnapprovedTemplatePerms(user, template) Then
                    If Await Database.SelectTemplateMetadataAsync(template.GUID) Is Nothing Then
                        Database.SetTemplate(template, user.UserId) ' no approver
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

    Public Async Function EditUnapprovedTemplateAsync(credentials As LampCredentials, newTemplate As LampTemplate) As Task(Of LampStatus) Implements ILampServiceAsync.EditUnapprovedTemplateAsync
        Dim response As LampStatus

        Try
            If newTemplate Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim oldTemplate = Await Database.SelectTemplateAsync(newTemplate.GUID)

            If oldTemplate Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If

            If Not HasEditUnapprovedTemplatePerms(user, oldTemplate) Then
                response = LampStatus.NoAccess
                Return response
            End If

            ' passed all tests
            Await Database.SetTemplateAsync(newTemplate, user.UserId) ' no approver
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Async Function RemoveUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceAsync.RemoveUnapprovedTemplateAsync
        Dim response As LampStatus

        Try
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user IsNot Nothing Then

                Dim user = auth.user

                Dim oldTemplate = Await Database.SelectTemplateAsync(guid)

                If oldTemplate IsNot Nothing Then
                    If HasRemoveUnapprovedTemplatePerms(user, oldTemplate) Then
                        Await Database.RemoveTemplateAsync(guid)
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

    Public Async Function ApproveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceAsync.ApproveTemplateAsync
        Dim response As LampStatus

        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim template = Await Database.SelectTemplateAsync(guid)

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
            Await Database.SetTemplateAsync(template, template.CreatorId, user.UserId) ' new approver
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Async Function RevokeTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceAsync.RevokeTemplateAsync
        Dim response As LampStatus

        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim template = Await Database.SelectTemplateAsync(guid)

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
            Await Database.SetTemplateAsync(template, template.CreatorId, Nothing) ' remove the approver
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    ''' <summary>
    ''' only admins or users who also submitted
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Async Function GetJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampJobWrapper) Implements ILampServiceAsync.GetJobAsync
        Dim response As New LampJobWrapper

        Try
            If guid Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If

            Dim user = auth.user
            Dim job = Await Database.SelectJobAsync(guid)
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

    Public Async Function AddJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampServiceAsync.AddJobAsync
        Dim response As LampStatus

        Try
            If job Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user
            If Await Database.SelectJobAsync(job.JobId) IsNot Nothing Then
                ' already exists a job, 
                response = LampStatus.GuidConflict
                Return response
            End If
            If Not HasAddJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If


            Await Database.SetJobAsync(job)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            Log(ex)
            response = LampStatus.InternalServerError
            Return response
        End Try
    End Function

    Public Async Function EditJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampServiceAsync.EditJobAsync
        Dim response As LampStatus

        Try
            If job Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user
            If Not Await Database.SelectJobAsync(job.JobId) IsNot Nothing Then
                ' already exists a job, 
                response = LampStatus.GuidConflict
                Return response
            End If

            If Not HasEditJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If


            Await Database.SetJobAsync(job)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            Log(ex)
            response = LampStatus.InternalServerError
            Return response
        End Try
    End Function

    Public Async Function RemoveJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceAsync.RemoveJobAsync
        Dim response As LampStatus

        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user
            Dim job = Await Database.SelectJobAsync(guid)
            If Not job Is Nothing Then
                ' no job exists
                response = LampStatus.DoesNotExist
                Return response
            End If

            If Not HasRemoveJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If


            Await Database.RemoveJobAsync(guid)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            Log(ex)
            response = LampStatus.InternalServerError
            Return response
        End Try
    End Function

    Public Async Function SelectDxfAsync(credentials As LampCredentials, guid As String) As Task(Of LampDxfDocumentWrapper) Implements ILampServiceAsync.SelectDxfAsync
        Dim response As New LampDxfDocumentWrapper

        Try
            If guid Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If


            Dim user = auth.user
            If user Is Nothing Then
                response.Status = LampStatus.InvalidUsernameOrPassword
                Return response
            End If

            Dim template = Await Database.SelectTemplateAsync(guid)
            If template Is Nothing Then
                response.Status = LampStatus.DoesNotExist
                Return response
            End If

            If Not HasGetTemplatePerms(user, template) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If

            ' passed all tests
            response.Status = LampStatus.OK
                response.Drawing = template.BaseDrawing
                Return response




        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function




End Class
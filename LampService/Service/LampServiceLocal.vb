Imports System.Threading.Tasks
Imports LampCommon
Imports LampService.PermsHelper
Imports LampService.ValidateHelper

Public Class LampServiceLocal
    Inherits LampService
    Implements ILampServiceClient

    Public Sub New(databasePath As String)
        MyBase.New(databasePath)
    End Sub

    Public Async Function GetTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampServiceClient.GetTemplateAsync
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

    Public Async Function AddTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceClient.AddTemplateAsync
        Dim response As LampStatus

        Try
            If template Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
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

            If Await Database.SelectTemplateDataAsync(template.GUID).ConfigureAwait(False) IsNot Nothing Then
                response = LampStatus.GuidConflict
                Return response
            End If

            Await Database.SetTemplateAsync(template, user.UserId, user.UserId).ConfigureAwait(False)
            response = LampStatus.OK
            Return response
        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Async Function EditTemplateAsync(credentials As LampCredentials, newTemplate As LampTemplate) As Task(Of LampStatus) Implements ILampServiceClient.EditTemplateAsync
        Dim response As LampStatus

        Try
            If newTemplate Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim oldTemplate = Await Database.SelectTemplateAsync(newTemplate.GUID).ConfigureAwait(False)


            If Not HasEditTemplatePerms(user, oldTemplate, newTemplate) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If oldTemplate Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If


            Await Database.SetTemplateAsync(newTemplate, user.UserId).ConfigureAwait(False)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Async Function RemoveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceClient.RemoveTemplateAsync
        Dim response As LampStatus
        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user
            Dim template = Await Database.SelectTemplateAsync(guid).ConfigureAwait(False)
            If Not HasRemoveTemplatePerms(user, template) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If template Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If

            Await Database.RemoveTemplateAsync(template.GUID).ConfigureAwait(False)
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Async Function GetUserAsync(credentials As LampCredentials, guid As String) As Task(Of LampUserWrapper) Implements ILampServiceClient.GetUserAsync
        Dim response As New LampUserWrapper()

        Try
            If guid Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If
            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
            If auth.user IsNot Nothing Then

                Dim thisUser = auth.user

                Dim gottenUser = Await Database.SelectUserAsync(guid).ConfigureAwait(False)

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

    Public Async Function AddUserAsync(credentials As LampCredentials, toAddUser As LampUser) As Task(Of LampStatus) Implements ILampServiceClient.AddUserAsync
        Dim response As LampStatus

        Try
            If toAddUser Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If


            Dim thisUser As LampUser
            If credentials IsNot Nothing Then
                Dim auth = Await AuthenticateAsync(credentials)
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

            Dim exists = Await Database.UserExistsAsync(toAddUser)
            If exists <> LampStatus.OK Then
                response = exists
                Return response
            End If


            Await Database.SetUserAsync(toAddUser)
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Async Function EditUserAsync(credentials As LampCredentials, newUser As LampUser) As Task(Of LampStatus) Implements ILampServiceClient.EditUserAsync
        Dim response As LampStatus

        Try
            If newUser Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim thisUser = auth.user

            Dim oldUser = Await Database.SelectUserAsync(newUser.UserId).ConfigureAwait(False)

            If Not HasEditUserPerms(thisUser, oldUser, newUser) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If oldUser Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If



            Await Database.SetUserAsync(newUser).ConfigureAwait(False)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try

    End Function

    Public Async Function RemoveUserAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceClient.RemoveUserAsync
        Dim response As LampStatus

        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If


            Dim thisUser = auth.user
            Dim oldUser = Await Database.SelectUserAsync(guid).ConfigureAwait(False)

            If Not HasRemoveUserPerms(thisUser, oldUser) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If oldUser Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If



            ' passed all checks
            Await Database.RemoveUserAsync(guid).ConfigureAwait(False)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Async Function AuthenticateAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampServiceClient.AuthenticateAsync
        Dim user As LampUser = Nothing
        Dim response As New LampUserWrapper()

        Try
            If credentials Is Nothing Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            If credentials.Username Is Nothing OrElse credentials.Password Is Nothing OrElse credentials.Username = "" OrElse credentials.Password = "" Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            user = Await Database.SelectUserAsync(credentials.Username.ToLower(), credentials.Password)
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

    Public Function GetAllTemplateAsync(credentials As LampCredentials) As Task(Of List(Of LampTemplate)) Implements ILampServiceClient.GetAllTemplateAsync
        'to do
        Return Database.GetAllTemplateAsync()
    End Function

    Public Async Function GetUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampServiceClient.GetUnapprovedTemplateAsync
        Dim response As New LampTemplateWrapper()

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

            If Not HasGetUnapprovedTemplatePerms(user, template) Then
                response.Status = LampStatus.NoAccess
            End If

            If template Is Nothing Then
                response.Status = LampStatus.DoesNotExist
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

    Public Async Function AddUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceClient.AddUnapprovedTemplateAsync
        Dim response As LampStatus

        Try
            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user IsNot Nothing Then

                Dim user = auth.user


                If HasAddUnapprovedTemplatePerms(user, template) Then
                    If Await Database.SelectTemplateDataAsync(template.GUID) Is Nothing Then
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

    Public Async Function EditUnapprovedTemplateAsync(credentials As LampCredentials, newTemplate As LampTemplate) As Task(Of LampStatus) Implements ILampServiceClient.EditUnapprovedTemplateAsync
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
    Public Async Function RemoveUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceClient.RemoveUnapprovedTemplateAsync
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

    Public Async Function ApproveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceClient.ApproveTemplateAsync
        Dim response As LampStatus

        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim template = Await Database.SelectTemplateAsync(guid).ConfigureAwait(False)

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
            Await Database.SetTemplateApproverAsync(guid, user.UserId).ConfigureAwait(False) ' new approver
            response = LampStatus.OK
            Return response


        Catch ex As Exception
            response = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Async Function RevokeTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceClient.RevokeTemplateAsync
        Dim response As LampStatus

        Try
            If guid Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim template = Await Database.SelectTemplateAsync(guid).ConfigureAwait(False)

            If Not HasRevokeTemplatePerms(user, template) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If template Is Nothing Then
                response = LampStatus.DoesNotExist
                Return response
            End If

            If template.Approved = False Then
                response = LampStatus.InvalidOperation
                Return response
            End If




            ' passed all tests
            Await Database.SetTemplateApproverAsync(guid, Nothing).ConfigureAwait(False) ' remove the approver
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
    Public Async Function GetJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampJobWrapper) Implements ILampServiceClient.GetJobAsync
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

            If Not HasGetJobPerms(user, job) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If

            If job Is Nothing Then
                ' no job found
                response.Status = LampStatus.DoesNotExist
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

    ''' <summary>
    ''' invalid operation = no template in db
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="job"></param>
    ''' <returns></returns>
    Public Async Function AddJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampServiceClient.AddJobAsync
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
            If Not HasAddJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If Not ValidJob(job) Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim submitter = Await Database.SelectUserAsync(job.SubmitId).ConfigureAwait(False)
            If submitter.PermissionLevel < UserPermission.Elevated Then
                response = LampStatus.InvalidSubmitter
                Return response
            End If
            If job.ApproverId IsNot Nothing Then
                Dim approver = Await Database.SelectUserAsync(job.ApproverId)
                If approver Is Nothing OrElse approver.PermissionLevel <= UserPermission.Elevated Then
                    response = LampStatus.InvalidApprover
                    Return response
                End If
            End If

            If Await Database.SelectJobAsync(job.JobId) IsNot Nothing Then
                ' already exists a job, 
                response = LampStatus.GuidConflict
                Return response
            End If

            If Await Database.SelectTemplateDataAsync(job.Template.GUID).ConfigureAwait(False) Is Nothing Then ' check if exists
                response = LampStatus.NoTemplateFound
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

    Public Async Function EditJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampServiceClient.EditJobAsync
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
            If Not HasEditJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If Not Await Database.SelectJobAsync(job.JobId) IsNot Nothing Then
                ' already exists a job, 
                response = LampStatus.GuidConflict
                Return response
            End If

            If Await Database.SelectTemplateDataAsync(job.Template.GUID).ConfigureAwait(False) Is Nothing Then
                ' no template found
                response = LampStatus.NoTemplateFound
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

    Public Async Function RemoveJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceClient.RemoveJobAsync
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

            If Not HasRemoveJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response

            End If

            If Not job Is Nothing Then
                ' no job exists
                response = LampStatus.DoesNotExist
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

    Public Async Function SelectDxfAsync(credentials As LampCredentials, guid As String) As Task(Of LampDxfDocumentWrapper) Implements ILampServiceClient.SelectDxfAsync
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
            If Not HasGetTemplatePerms(user, template) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If

            If template Is Nothing Then
                response.Status = LampStatus.DoesNotExist
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


    Public Async Function GetTemplateListAsync(credentials As LampCredentials, tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampTemplateSort) As Task(Of LampTemplateListWrapper) Implements ILampServiceClient.GetTemplateListAsync
        Dim response As New LampTemplateListWrapper
        Try
            If limit <= 0 Or offset < 0 Then
                response.Status = LampStatus.InvalidParameters
                Return response
            End If

            If limit > MAX_TEMPLATES_PER_REQUEST Then
                response.Status = LampStatus.InvalidOperation
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

            Dim auth = Await AuthenticateAsync(credentials)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If
            Dim user = auth.user

            If Not HasGetTemplateListPerms(user, approveStatus, byUser) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If

            response.Templates = Await Database.GetMultipleTemplateAsync(tags, byUser, limit, offset, approveStatus, orderBy).ConfigureAwait(False)
            response.Status = LampStatus.OK
            Return response

        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function


    Public Async Function GetJobListAsync(credentials As LampCredentials, byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampJobSort) As Task(Of LampJobListWrapper) Implements ILampServiceClient.GetJobListAsync
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

            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If
            Dim user = auth.user

            If Not HasGetJobListPerms(user, byUser) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If

            response.Templates = Await Database.GetMultipleJobAsync(byUser, limit, offset, approveStatus, orderBy).ConfigureAwait(False)
            response.Status = LampStatus.OK
            Return response

        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Log(ex)
            Return response
        End Try
    End Function

    Public Async Function GetUserListAsync(credentials As LampCredentials, limit As Integer, offset As Integer, orderBy As LampUserSort) As Task(Of LampUserListWrapper) Implements ILampServiceClient.GetUserListAsync
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

            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
            If auth.user Is Nothing Then
                response.Status = auth.Status
                Return response
            End If
            Dim user = auth.user

            If Not HasGetUserList(user) Then
                response.Status = LampStatus.NoAccess
                Return response
            End If

            response.Users = Await Database.GetMultipleUserAsync(limit, offset, orderBy).ConfigureAwait(False)
            response.Status = LampStatus.OK

            Return response

        Catch ex As Exception
            response.Status = LampStatus.InternalServerError
            Return response
        End Try
    End Function

    Public Async Function ApproveJobAsync(credentials As LampCredentials, jobId As String) As Task(Of LampStatus) Implements ILampServiceClient.ApproveJobAsync
        Dim response As LampStatus

        Try
            If jobId Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim job = Await Database.SelectJobAsync(jobId).ConfigureAwait(False)

            If Not HasApproveJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If job Is Nothing Then
                ' no job exists
                response = LampStatus.DoesNotExist
                Return response
            End If

            Await Database.SetJobApproverAsync(jobId, user.UserId).ConfigureAwait(False)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            Log(ex)
            response = LampStatus.InternalServerError
            Return response
        End Try
    End Function

    Public Async Function RevokeJobAsync(credentials As LampCredentials, jobId As String) As Task(Of LampStatus) Implements ILampServiceClient.RevokeJobAsync
        Dim response As LampStatus

        Try
            If jobId Is Nothing Then
                response = LampStatus.InvalidParameters
                Return response
            End If

            Dim auth = Await AuthenticateAsync(credentials).ConfigureAwait(False)
            If auth.user Is Nothing Then
                response = auth.Status
                Return response
            End If

            Dim user = auth.user

            Dim job = Await Database.SelectJobAsync(jobId).ConfigureAwait(False)

            If Not HasRevokeJobPerms(user, job) Then
                response = LampStatus.NoAccess
                Return response
            End If

            If job Is Nothing Then
                ' no job exists
                response = LampStatus.DoesNotExist
                Return response
            End If

            Await Database.SetJobApproverAsync(jobId, Nothing).ConfigureAwait(False)
            response = LampStatus.OK
            Return response

        Catch ex As Exception
            Log(ex)
            response = LampStatus.InternalServerError
            Return response
        End Try
    End Function
End Class
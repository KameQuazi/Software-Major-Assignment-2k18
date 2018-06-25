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
    Public Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampService.Authenticate
        Dim user As LampUser = Nothing
        Dim response As New LampUserWrapper()
        response.status = LampStatus.OK

        Try
            user = Database.SelectUser(credentials.Username, credentials.Password)
            If user Is Nothing Then
                response.status = LampStatus.InvalidUsernameOrPassword
            Else
                response.user = user
            End If

        Catch ex As Exception
            response.status = LampStatus.InternalServerError
            Console.WriteLine(ex)
        End Try

        Return response
    End Function



    Public Function GetTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper Implements ILampService.GetTemplate
        Dim user = Authenticate(credentials).user
        Dim response As New LampTemplateWrapper
        response.Status = LampStatus.OK

        If user IsNot Nothing Then
            Dim template = Database.SelectTemplate(guid)

            If template IsNot Nothing Then

                If HasGetTemplatePerms(user, template) Then
                    response.Template = template
                Else
                    response.Status = LampStatus.NoAccess
                End If
            Else
                ' template doesnt exist
                response.Status = LampStatus.DoesNotExist
            End If

        Else
            response.Status = LampStatus.InvalidUsernameOrPassword
        End If

        Return response
    End Function


    Public Function AddTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.AddTemplate
        Dim user = Authenticate(credentials).user
        Dim response As LampStatus = LampStatus.OK

        If user IsNot Nothing Then
            If Database.SelectTemplateMetadata(template.GUID) Is Nothing Then
                If HasAddTemplatePerms(user, template) Then
                    Database.SetTemplate(template, user.UserId, user.UserId)
                Else
                    response = LampStatus.NoAccess
                End If
            Else
                response = LampStatus.GuidConflict
            End If
        Else

            response = LampStatus.InvalidUsernameOrPassword
        End If

        Return response
    End Function

    Public Function EditTemplate(credentials As LampCredentials, newTemplate As LampTemplate) As LampStatus Implements ILampService.EditTemplate
        Dim user = Authenticate(credentials).user
        Dim response As LampStatus = LampStatus.OK

        If user IsNot Nothing Then
            Dim oldTemplate = Database.SelectTemplate(newTemplate.GUID)
            If oldTemplate IsNot Nothing Then
                If HasEditTemplatePerms(user, oldTemplate, newTemplate) Then

                    Database.SetTemplate(newTemplate, user.UserId, user.UserId)
                Else
                    response = LampStatus.NoAccess
                End If
            Else
                response = LampStatus.DoesNotExist
            End If
        Else

            response = LampStatus.InvalidUsernameOrPassword
        End If

        Return response
    End Function



    Public Function RemoveTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveTemplate
        Dim user = Authenticate(credentials).user
        Dim response As LampStatus = LampStatus.OK

        If user IsNot Nothing Then
            Dim template = Database.SelectTemplate(guid)

            If template IsNot Nothing Then

                If HasRemoveTemplatePerms(user, template) Then
                    Database.RemoveTemplate(template.GUID)
                Else
                    response = LampStatus.NoAccess
                End If
            Else
                ' template doesnt exist
                response = LampStatus.DoesNotExist
            End If

        Else
            response = LampStatus.InvalidUsernameOrPassword
        End If


        Return response
    End Function



    Public Function AddUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.AddUnapprovedTemplate
        Throw New NotImplementedException()
    End Function

    Public Function EditUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.EditUnapprovedTemplate
        Throw New NotImplementedException()
    End Function

    Public Function RemoveUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveUnapprovedTemplate
        Throw New NotImplementedException()
    End Function

    Public Function GetUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper Implements ILampService.GetUnapprovedTemplate
        Throw New NotImplementedException()
    End Function

    Public Function RevokeTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RevokeTemplate
        Throw New NotImplementedException()
    End Function


    Public Function SelectDxf(credentials As LampCredentials, guid As String) As LampDxfDocumentWrapper Implements ILampService.SelectDxf
        Throw New NotImplementedException()
    End Function








    Public Function AddJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampService.AddJob
        ' check if user got permissions
        Dim user = Authenticate(credentials).user
        Dim response As LampStatus = LampStatus.OK

        If user IsNot Nothing Then
            If Database.SelectJob(job.JobId) IsNot Nothing Then
                If HasAddJobPerms(user, job) Then
                    Database.SetJob(job)

                End If
            Else
                response = LampStatus.GuidConflict
            End If

        Else
            response = LampStatus.InvalidUsernameOrPassword
        End If

        Return response
    End Function


    Public Function EditJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampService.EditJob
        Throw New NotImplementedException()
    End Function

    Public Function RemoveJob(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveJob
        Throw New NotImplementedException()
    End Function


    Public Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate) Implements ILampService.GetAllTemplate
        ' TODO add hasview template
        Return Database.GetAllTemplate()
    End Function








    Public Function ApproveTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.ApproveTemplate
        Throw New NotImplementedException()
    End Function




    Public Function GetUser(credentials As LampCredentials) As LampUserWrapper Implements ILampService.GetUser
        Throw New NotImplementedException()
    End Function

    Public Function AddUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampService.AddUser
        Throw New NotImplementedException()
    End Function

    Public Function EditUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampService.EditUser
        Throw New NotImplementedException()
    End Function

#End Region

#Region "HasPermissions"
    Public Function HasGetTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        Return user.PermissionLevel >= UserPermission.Guest
    End Function

    Public Function HasAddTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        Return user.PermissionLevel >= UserPermission.Admin
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

    Public Function HasAddUnapprovedTemplatePerms(user As LampUser, template As LampTemplate)
        If user.UserId >= UserPermission.Standard Then
            Return True
        End If
        Return False
    End Function





    Public Function HasAddJobPerms(user As LampUser, job As LampJob) As Boolean
        Return user.PermissionLevel >= UserPermission.Elevated
    End Function






    Public Function RemoveUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampService.RemoveUser
        Throw New NotImplementedException()
    End Function


    Public Function GetJob(credentials As LampCredentials, guid As String) As LampJobWrapper Implements ILampService.GetJob
        Throw New NotImplementedException()
    End Function









#End Region


End Class

Public Class LampServiceLocal
    Inherits LampService
    Implements ILampServiceBoth

    Public Async Function GetTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampServiceAsync.GetTemplateAsync
        Dim user = (Await AuthenticateAsync(credentials)).user
        Dim response As New LampTemplateWrapper
        response.Status = LampStatus.OK

        If user IsNot Nothing Then
            Dim template = Await Database.SelectTemplateAsync(guid)

            If template IsNot Nothing Then

                If HasGetTemplatePerms(user, template) Then
                    response.Template = template
                Else
                    response.Status = LampStatus.NoAccess
                End If
            Else
                ' template doesnt exist
                response.Status = LampStatus.DoesNotExist
            End If

        Else
            response.Status = LampStatus.InvalidUsernameOrPassword
        End If

        Return response
    End Function

    Public Async Function AddTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceAsync.AddTemplateAsync
        Dim user = (Await AuthenticateAsync(credentials)).user
        Dim response As LampStatus = LampStatus.OK

        If user IsNot Nothing Then
            If Database.SelectTemplateMetadata(template.GUID) Is Nothing Then
                If HasAddTemplatePerms(user, template) Then
                    Database.SetTemplate(template, user.UserId, user.UserId)
                Else
                    response = LampStatus.NoAccess
                End If
            Else
                response = LampStatus.GuidConflict
            End If
        Else

            response = LampStatus.InvalidUsernameOrPassword
        End If

        Return response
    End Function

    Public Async Function EditTemplateAsync(credentials As LampCredentials, newTemplate As LampTemplate) As Task(Of LampStatus) Implements ILampServiceAsync.EditTemplateAsync
        Dim user = (Await AuthenticateAsync(credentials)).user
        Dim response As LampStatus = LampStatus.OK

        If user IsNot Nothing Then
            Dim oldTemplate = Await Database.SelectTemplateAsync(newTemplate.GUID)
            If oldTemplate IsNot Nothing Then
                If HasEditTemplatePerms(user, oldTemplate, newTemplate) Then

                    Await Database.SetTemplateAsync(newTemplate, user.UserId, user.UserId)
                Else
                    response = LampStatus.NoAccess
                End If
            Else
                response = LampStatus.DoesNotExist
            End If
        Else

            response = LampStatus.InvalidUsernameOrPassword
        End If

        Return response
    End Function

    Public Async Function RemoveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceAsync.RemoveTemplateAsync
        Dim user = (Await AuthenticateAsync(credentials)).user
        Dim response As LampStatus = LampStatus.OK

        If user IsNot Nothing Then
            Dim template = Await Database.SelectTemplateAsync(guid)

            If template IsNot Nothing Then

                If HasRemoveTemplatePerms(user, template) Then
                    Await Database.RemoveTemplateAsync(template.GUID)
                Else
                    response = LampStatus.NoAccess
                End If
            Else
                ' template doesnt exist
                response = LampStatus.DoesNotExist
            End If

        Else
            response = LampStatus.InvalidUsernameOrPassword
        End If


        Return response
    End Function

    Public Function GetUserAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampServiceAsync.GetUserAsync
        Throw New NotImplementedException()
    End Function

    Public Function AddUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampServiceAsync.AddUserAsync
        Throw New NotImplementedException()
    End Function

    Public Function EditUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampServiceAsync.EditUserAsync
        Throw New NotImplementedException()
    End Function

    Public Function RemoveUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampServiceAsync.RemoveUserAsync
        Throw New NotImplementedException()
    End Function

    Public Async Function AuthenticateAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampServiceAsync.AuthenticateAsync
        Dim user As LampUser = Nothing
        Dim reason As LampStatus = LampStatus.OK

        Try
            user = Await Database.SelectUserAsync(credentials.Username, credentials.Password)

        Catch ex As Exception
            reason = LampStatus.InternalServerError
            Console.WriteLine(ex)
        End Try
        Return New LampUserWrapper(user, reason)
    End Function

    Public Function GetAllTemplateAsync(credentials As LampCredentials) As Task(Of List(Of LampTemplate)) Implements ILampServiceAsync.GetAllTemplateAsync
        'to do
        Return Database.GetAllTemplateAsync()
    End Function

    Public Function GetUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampServiceAsync.GetUnapprovedTemplateAsync
        Throw New NotImplementedException()
    End Function

    Public Function SelectDxfAsync(credentials As LampCredentials, guid As String) As Task(Of LampDxfDocumentWrapper) Implements ILampServiceAsync.SelectDxfAsync
        Throw New NotImplementedException()
    End Function

    Public Function AddUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceAsync.AddUnapprovedTemplateAsync
        Throw New NotImplementedException()
    End Function

    Public Function EditUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceAsync.EditUnapprovedTemplateAsync
        Throw New NotImplementedException()
    End Function

    Public Function RemoveUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceAsync.RemoveUnapprovedTemplateAsync
        Throw New NotImplementedException()
    End Function

    Public Function ApproveTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceAsync.ApproveTemplateAsync
        Throw New NotImplementedException()
    End Function

    Public Function RevokeTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceAsync.RevokeTemplateAsync
        Throw New NotImplementedException()
    End Function

    Public Function GetJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampJobWrapper) Implements ILampServiceAsync.GetJobAsync
        Throw New NotImplementedException()
    End Function

    Public Function AddJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampServiceAsync.AddJobAsync
        Throw New NotImplementedException()
    End Function

    Public Function EditJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampServiceAsync.EditJobAsync
        Throw New NotImplementedException()
    End Function

    Public Function RemoveJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceAsync.RemoveJobAsync
        Throw New NotImplementedException()
    End Function
End Class
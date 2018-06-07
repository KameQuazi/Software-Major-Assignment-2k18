Imports System.ServiceModel.Configuration
Imports System.Threading.Tasks
Imports LampCommon
Imports LampService

''' <summary>
''' The receiver class has all privildegeds to the database 
''' runs on the server side
''' </summary>
Public Class LampService
    Implements ILampServerService

    Public Property Database As TemplateDatabase

    Sub New()
        Database = New TemplateDatabase(Configuration.ConfigurationManager.AppSettings("databasePath"))
    End Sub

    Sub New(databasePath As String)
        Database = New TemplateDatabase(databasePath)
    End Sub




#Region "ImplementILampService"
    Public Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampServerService.Authenticate
        Dim user As LampUser = Nothing
        Dim reason As LampStatus = LampStatus.OK

        Try
            user = Database.SelectUser(credentials.Username, credentials.Password)

        Catch ex As Exception
            reason = LampStatus.InternalServerError
            Console.WriteLine(ex)
        End Try
        Return New LampUserWrapper(user, reason)
    End Function


    Public Function AddTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampServerService.AddTemplate
        Dim user = Authenticate(credentials).user
        Dim response As LampStatus = LampStatus.OK

        If user IsNot Nothing Then
            If HasAddTemplatePerms(user) Then
                Database.AddTemplate(template)
            Else
                response = response And LampStatus.NoAccess
            End If
        Else
            response = response And LampStatus.InvalidUsernameOrPassword
        End If
        Return response
    End Function



    Public Function QueueJob(job As LampJob, credentials As LampCredentials) As LampStatus
        ' check if user got permissions

        ' TODO Also extract stuff
        Database.AddJob(job)
        Return 0
    End Function






    Public Function GetTemplate(credentials As LampCredentials) As LampTemplateWrapper Implements ILampServerService.GetTemplate
        Return New LampTemplateWrapper() With {.Template = New LampTemplate(), .Status = LampStatus.OK}
    End Function

    Private Function ILampService_QueueJob(job As LampJob, credentials As LampCredentials) As LampStatus Implements ILampServerService.QueueJob
        Database.AddJob(job)
        Throw New NotImplementedException()
    End Function

    Public Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate) Implements ILampServerService.GetAllTemplate
        ' TODO add hasview template
        Return Database.GetAllTemplate()
    End Function

    Public Function GetAllTemplateAsync(credentials As LampCredentials) As Task(Of List(Of LampTemplate))
        Return Database.GetAllTemplateAsync()
    End Function

    Public Function DeleteTemplate(credentials As LampCredentials) As LampStatus Implements ILampService.DeleteTemplate
        Throw New NotImplementedException()
    End Function

    Public Function SelectDxf(credentials As LampCredentials) As LampDxfDocumentWrapper Implements ILampService.SelectDxf
        Throw New NotImplementedException()
    End Function

    Public Function AddUnapprovedTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampService.AddUnapprovedTemplate
        Throw New NotImplementedException()
    End Function

    Public Function DeleteUnapprovedTemplate(guid As String, credentials As LampCredentials) As LampStatus Implements ILampService.DeleteUnapprovedTemplate
        Throw New NotImplementedException()
    End Function

    Public Function AuthenticateAsync(credentials As LampCredentials) As Task(Of LampUserWrapper)
        Throw New NotImplementedException()
    End Function

    Public Function AddTemplateAsync(template As LampTemplate, credentials As LampCredentials) As Task(Of LampStatus)
        Throw New NotImplementedException()
    End Function

    Public Function QueueJobAsync(job As LampJob, credentials As LampCredentials) As Task(Of LampStatus)
        Throw New NotImplementedException()
    End Function

    Public Function ApproveTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampService.ApproveTemplate
        Throw New NotImplementedException()
    End Function

    Public Function GetTemplateAsync(credentials As LampCredentials) As Task(Of LampTemplateWrapper)
        Throw New NotImplementedException()
    End Function

    Public Function RevokeTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampService.RevokeTemplate
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
    Public Function HasQueueJobPerms(user As LampUser)
        Return user.PermissionLevel >= UserPermission.Standard
    End Function

    Public Function HasAddTemplatePerms(user As LampUser)
        Return user.PermissionLevel >= UserPermission.Elevated
    End Function

    Public Function HasViewTemplatePerms(user As LampUser)
        Return user.PermissionLevel >= UserPermission.Guest
    End Function


#End Region


End Class


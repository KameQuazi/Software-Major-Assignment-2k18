Imports System.ServiceModel.Description
Imports LampCommon
Imports LampService
''' <summary>
''' The receiver class has all privildegeds to the database 
''' runs on the server side
''' </summary>
Public Class LampService
    Implements ILampService

    Public Property Database As TemplateDatabase

    Sub New()
        Database = New TemplateDatabase(Configuration.ConfigurationManager.AppSettings("databasePath"))
    End Sub


    ''' <summary>
    ''' Starts the ip listener
    ''' </summary>
    Public Sub StartListener(address As String)

        Dim uri = New Uri(address)

        Dim serviceHost = New ServiceHost(GetType(LampService))

        serviceHost.AddServiceEndpoint(GetType(ILampService), New WSHttpBinding(), "LampService")

        Dim smb = New ServiceMetadataBehavior()
        smb.HttpGetEnabled = True
        serviceHost.Description.Behaviors.Add(smb)

        serviceHost.Open()

        Console.WriteLine(String.Format("The service is ready at {0}", address))
        Console.WriteLine("Press <ENTER> to terminate service.")
        Console.WriteLine()
        serviceHost.Close()


    End Sub

#Region "ImplementILampService"
    Public Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampService.Authenticate
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


    Public Function AddTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampService.AddTemplate
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



    Public Function QueueJob(template As LampTemplate, User As LampUser) As LampStatus
        ' check if user got permissions

        ' TODO Also extract stuff
        Dim job As New LampJob(template, User)
        Database.AddJob(job)
        Return 0
    End Function


    Public Sub AddTemplate(template As LampTemplate, user As LampUser)
        Throw New NotImplementedException()
    End Sub
#End Region



    Public Function GetTemplate(credentials As LampCredentials) As LampTemplateWrapper Implements ILampService.GetTemplate
        Return New LampTemplateWrapper() With {.Template = New LampTemplate(), .Status = LampStatus.OK}
    End Function

    Private Function ILampService_QueueJob(job As LampJob, credentials As LampCredentials) As LampStatus Implements ILampService.QueueJob
        Database.AddJob(job)
        Throw New NotImplementedException()
    End Function

#Region "HasPermissions"
    Public Function HasQueueJobPerms(user As LampUser)
        Return user.PermissionLevel >= UserPermission.Standard
    End Function

    Public Function HasAddTemplatePerms(user As LampUser)
        Return user.PermissionLevel >= UserPermission.Elevated
    End Function
#End Region


End Class




Module OwO
    Sub Main()
        Dim x As New LampService
        x.StartListener("http://localhost:8000/WCF/")
    End Sub
End Module
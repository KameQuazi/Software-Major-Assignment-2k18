Imports System.ServiceModel.Description
Imports LampCommon
Imports LampService
''' <summary>
''' The receiver class has all privildegeds to the database 
''' </summary>
Public Class LampService
    Implements ILampService
    Public Property Protocol As LampCommunication

    Public Property Database As TemplateDatabase

    Public Sub New(protocol As LampCommunication)
        Me.Protocol = protocol
        Me.Database = New TemplateDatabase()
    End Sub

#Region "ImplementILampService"
    Public Function QueueJob(template As LampTemplate, User As LampUser) As LampStatus
        ' check if user got permissions

        ' TODO Also extract stuff
        Dim job As New LampJob(template, User)
        Database.AddJob(job)
        Return 0
    End Function

    Public Function Authenticate(username As String, password As String) As LampUserWrapper Implements ILampService.Authenticate
        Dim user As LampUser = Nothing
        Dim reason As LampStatus = LampStatus.OK

        Try
            user = Database.SelectUser(username, password)

        Catch ex As Exception
            reason = LampStatus.InternalServerError
            Console.WriteLine(ex)
        End Try
        Return New LampUserWrapper(user, reason)
    End Function


    Public Sub AddTemplate(template As LampTemplate, user As LampUser)
        Throw New NotImplementedException()
    End Sub
#End Region

    Sub New()
        Database = New TemplateDatabase(Configuration.ConfigurationManager.AppSettings("databasePath"))
    End Sub


    ''' <summary>
    ''' Starts the ip listener
    ''' </summary>
    Public Sub StartListener()
        If Protocol.Type <> SubmitType.Server Then
            Throw New Exception("must be in server mode to start listener")
        End If
        Dim uri = New Uri(Protocol.Address)

        Dim serviceHost = New ServiceHost(GetType(LampService))

        serviceHost.AddServiceEndpoint(GetType(ILampService), New WSHttpBinding(), "LampService")

        Dim smb = New ServiceMetadataBehavior()
        smb.HttpGetEnabled = True
        serviceHost.Description.Behaviors.Add(smb)

        serviceHost.Open()

        System.Threading.Thread.Sleep(-1)
        serviceHost.Close()


    End Sub

    Private Sub ILampService_AddTemplate(template As LampTemplate, user As LampUser)
        Throw New NotImplementedException()
    End Sub

    Public Function GetTemplate() As LampTemplateWrapper Implements ILampService.GetTemplate
        Return New LampTemplateWrapper() With {.Template = New LampTemplate(), .Status = LampStatus.OK}
    End Function

    Private Shared ReadOnly Local As New LampService(New LampCommunication(SubmitType.Local))

End Class


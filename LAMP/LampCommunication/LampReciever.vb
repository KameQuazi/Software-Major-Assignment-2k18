Imports System.ServiceModel
Imports System.ServiceModel.Description
''' <summary>
''' The receiver class has all privildegeds to the database 
''' </summary>
Public Class LampReciever
    Implements ILampReciever
    Public Property Protocol As LampCommunication

    Public Property Database As TemplateDatabase

    Public Sub New(protocol As LampCommunication)
        Me.Protocol = protocol
        Me.Database = New TemplateDatabase()
    End Sub

    Public Function QueueJob(template As LampTemplate, User As LampUser) As LampStatus Implements ILampReciever.QueueJob
        ' check if user got permissions

        ' 
        Dim job As New LampJob(template, User)
        Database.AddJob(job)
        Return 0
    End Function

    ''' <summary>
    ''' Starts the ip listener
    ''' </summary>
    Public Sub StartListener()
        If Protocol.Type <> SubmitType.Server Then
            Throw New Exception("must be in server mode to start listener")
        End If
        Dim uri = New Uri(Protocol.Address)

        Dim serviceHost = New ServiceHost(GetType(LampReciever))

        serviceHost.AddServiceEndpoint(GetType(ILampReciever), New WSHttpBinding(), "LampService")

        Dim smb = New ServiceMetadataBehavior()
        smb.HttpGetEnabled = True
        serviceHost.Description.Behaviors.Add(smb)

        serviceHost.Open()

        System.Threading.Thread.Sleep(-1)
        serviceHost.Close()


    End Sub

    Public Function Authenticate(username As String, password As String) As LampUser
        Return Database.SelectUser(username, password)
    End Function

    Private Shared ReadOnly Local As New LampReciever(New LampCommunication(SubmitType.Local))

End Class

<Flags>
Public Enum LampStatus
    NoAccess
    DoesNotExist

End Enum
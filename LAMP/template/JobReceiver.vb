
Public Class LampReciever
    Public Property Protocol As LampCommunication

    Public Property Database As TemplateDatabase

    Public Sub New(protocol As LampCommunication)
        If protocol.Type <> SubmitType.Local Then
            Throw New NotImplementedException()
        End If

        Me.Protocol = protocol
        Me.Database = New TemplateDatabase()
    End Sub

    Public Sub ReceiveTemplate(template As LampTemplate, User As LampUser)
        Dim job As New LampJob(template, User)
        Database.AddJob(job)
    End Sub

    ''' <summary>
    ''' Starts the ip listener
    ''' </summary>
    Public Sub StartListener()
        If Protocol.Type <> SubmitType.Server Then
            Throw New Exception("must be in different mode")
        End If
        Throw New NotImplementedException()
    End Sub

    Public Function Authenticate(username As String, password As String) As LampUser
        Return Database.SelectUser(username, password)
    End Function

    Private Shared ReadOnly Local As New LampReciever(New LampCommunication(SubmitType.Local))

End Class


Public Class LampCommunication
    Public Type As SubmitType
    Public Address As String

    Sub New(type As SubmitType, Optional address As String = Nothing)
        If type = SubmitType.Server And address Is Nothing Then
            Throw New ArgumentNullException(NameOf(address))
        End If
        Me.Type = type
        Me.Address = address
    End Sub
End Class
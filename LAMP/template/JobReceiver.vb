Public Class JobReceiver
    Public Type As SubmitType

    Public Sub New(type As SubmitType)
        Me.Type = type
    End Sub

    Public Sub Receive(template As LampTemplate, User As LampUser)
        Dim db As New TemplateDatabase()
        Dim job As New LampJob(template, User)
        db.AddJob(job)
    End Sub

    ''' <summary>
    ''' Starts the ip listener
    ''' </summary>
    Public Sub StartListener()
        If Me.Type <> SubmitType.Server Then
            Throw New Exception("must be in different mode")
        End If
        Throw New NotImplementedException()
    End Sub
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
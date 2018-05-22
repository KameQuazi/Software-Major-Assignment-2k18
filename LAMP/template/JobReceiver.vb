Public Class JobReceiver
    Public Type As SubmitType

    Public Sub New(type As SubmitType)
        Me.Type = type
    End Sub

    Public Sub Receive(template As LampTemplate, User As LampUser)
        Dim db As New TemplateDatabase()
        db.AddJob(template)
    End Sub

    Public Sub StartListener()
        If Me.Type <> SubmitType.Server Then
            Throw New Exception("must be in different mode")
        End If
        Throw New NotImplementedException()
    End Sub
End Class

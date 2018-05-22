Public Class JobSubmitter
    Public Property Type As SubmitType
    Public Property Address As String


    Sub New(type As SubmitType, Optional address As String = "")
        If type = SubmitType.Local Then
            Me.Type = type
            Me.Address = address
        Else
            Throw New NotImplementedException("server not implemented")
        End If
    End Sub

    ''' <summary>
    ''' Send template to a web or ip address, or to internal db.
    ''' </summary>
    Public Sub Submit(template As LampTemplate, user As LampUser)
        If Type = SubmitType.Local Then
            Dim receiver As New JobReceiver(SubmitType.Local)
            receiver.Receive(template, user)
        End If
    End Sub
End Class

Public Enum SubmitType
    Local
    Server
End Enum


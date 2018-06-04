Public Class LampCommunication
    Public Type As SubmitType
    Public Address As String
    Public Shared ReadOnly Local As New LampCommunication(SubmitType.Local)

    Sub New(type As SubmitType, Optional address As String = Nothing)
        If type = SubmitType.Server And address Is Nothing Then
            Throw New ArgumentNullException(NameOf(address))
        End If
        Me.Type = type
        Me.Address = address
    End Sub
End Class


Public Enum SubmitType
    Local
    Server
End Enum
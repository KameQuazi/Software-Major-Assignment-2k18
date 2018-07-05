Imports System.Runtime.Serialization

<DataContract>
Public Class LampCredentials
    <DataMember>
    Public Property Username As String

    <DataMember>
    Public Property Password As String

    Sub New(user As String, pass As String)
        Me.Username = user
        Me.Password = pass
    End Sub
End Class

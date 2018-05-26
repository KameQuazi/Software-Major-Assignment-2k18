Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptIn)>
Public Class LampProfile
    <JsonProperty("username")>
    Public Property Username As String

    <JsonProperty("name")>
    Public Property Name As String

    Public Sub New(username As String)
        Me.Username = username
    End Sub
End Class

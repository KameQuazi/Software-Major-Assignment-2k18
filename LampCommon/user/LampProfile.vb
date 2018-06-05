Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptIn)>
Public Class LampProfile
    <JsonProperty("username")>
    Public Property Username As String

    <JsonProperty("name")>
    Public Property Name As String

    <JsonProperty("userId")>
    Public Property UserId As String

    Public Sub New(username As String, name As String, userid As String)
        Me.Username = username
        Me.Name = name
        Me.UserId = userid

    End Sub
End Class

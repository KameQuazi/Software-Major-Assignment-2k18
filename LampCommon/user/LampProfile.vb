Imports System.Runtime.Serialization
Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptIn)>
<DataContract>
Public Class LampProfile
    <JsonProperty("username")>
    <DataMember>
    Public Property Username As String

    <JsonProperty("name")>
    <DataMember>
    Public Property Name As String

    <JsonProperty("userId")>
    <DataMember>
    Public Property UserId As String

    Public Sub New(username As String, name As String, userid As String)
        Me.Username = username
        Me.Name = name
        Me.UserId = userid

    End Sub
End Class

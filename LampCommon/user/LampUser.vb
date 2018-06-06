Imports System.Runtime.Serialization


''' <summary>
''' A user. contains username / password, so be careful when passing it around
''' </summary>
<DataContract>
Public Class LampUser
    <DataMember>
    Public Property Email As String

    <DataMember>
    Public Property Password As String

    <DataMember>
    Public Property Username As String

    <DataMember>
    Public Property Name As String

    <DataMember>
    Public Property UserId As String

    <DataMember>
    Public Property PermissionLevel As UserPermission

    Sub New(userid As String, permissionLevel As UserPermission, email As String, username As String, password As String, name As String)
        Me.Email = email
        Me.Password = password
        Me.UserId = userid
        Me.PermissionLevel = permissionLevel
        Me.Username = username
        Me.Name = name
    End Sub


    Public Function ToProfile() As LampProfile
        Return New LampProfile(Username, Name, UserId)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("LampUser username={0}, userId={1}", Username, UserId)
    End Function


End Class

Public Enum UserPermission
    Guest
    Standard
    Admin

End Enum

''' <summary>
''' A wrapper around a user object to also allow an status message
''' password is also deleted to not leak anything 
''' </summary>
<DataContract>
Public Class LampUserWrapper
    <DataMember>
    Public Property user As LampUser

    <DataMember>
    Public Property status As LampStatus

    Sub New(user As LampUser, status As LampStatus)
        Me.user = user
        Me.status = status
        Me.user.Password = Nothing
    End Sub
End Class



''' <summary>
''' status codes returned by the API
''' </summary>
<Flags>
Public Enum LampStatus
    OK = 0
    NoAccess = 1
    DoesNotExist = 2
    InvalidUsernameOrPassword = 4
    InternalServerError = 8
    GuidConflict = 16

End Enum
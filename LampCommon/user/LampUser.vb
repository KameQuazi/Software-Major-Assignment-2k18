Imports System.Runtime.Serialization
Imports LampCommon

''' <summary>
''' A user. contains username / password, so be careful when passing it around
''' </summary>
<DataContract>
Public Class LampUser
    Implements ICloneable
    ''' <summary>
    ''' a anonymous user
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property Guest As LampUser = New LampUser("", UserPermission.Guest, "", "", "", "")

    <DataMember>
    Public Property Email As String

    <DataMember>
    <ComponentModel.Browsable(False)>
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
        Return New LampProfile(Username, Name, UserId, PermissionLevel)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("LampUser username={0}, userId={1}", Username, UserId)
    End Function

    Public Function ToCredentials() As LampCredentials
        Return New LampCredentials(Me.Username, Me.Password)
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim user = New LampUser(Me.UserId.Clone(),
                                Me.PermissionLevel,
                                Me.Email.Clone(),
                                Me.Username.Clone(),
                                Me.Password.Clone(),
                                Me.Name.Clone())
        Return user
    End Function
End Class

Public Enum UserPermission
    Guest = 0 ' for not logged in
    Standard = 1 ' for students
    Elevated = 2 ' for teachers
    Admin = 3 ' for us + ia staff 
    Super = 4

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
    Public Property Status As LampStatus

    Sub New(user As LampUser, status As LampStatus)
        Me.user = user
        Me.Status = status
        If user IsNot Nothing Then
            Me.user.Password = Nothing
        End If
    End Sub

    Public Sub New()
    End Sub


End Class



''' <summary>
''' status codes returned by the API
''' </summary>
<Flags>
Public Enum LampStatus
    Invalid = 0
    OK = 1
    NoAccess = 2
    DoesNotExist = 4
    InvalidUsernameOrPassword = 8
    InternalServerError = 16
    GuidConflict = 32
    InvalidParameters = 64
    InvalidOperation = 128
    UsernameConflict = 256
    EmailConflict = 512
    NoTemplateFound = 1024
End Enum

<DataContract>
Public Class LampUserListWrapper
    <DataMember>
    Public Property Users As New List(Of LampUser)

    <DataMember>
    Public Property Status As LampStatus
End Class
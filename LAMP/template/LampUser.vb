''' <summary>
''' user. Dangerous to pass around, use properly!
''' </summary>
Public Class LampUser
    Public Property Email As String

    Public Property Password As String

    Public Property Username As String

    Public Property Name As String

    Public Property UserId As String

    Public Property PermissionLevel As UserPermission

    Sub New(userid As String, permissionLevel As UserPermission, email As String, username As String, password As String, name As String)
        Me.Email = email
        Me.Password = password
        Me.UserId = userid
        Me.PermissionLevel = permissionLevel
        Me.Username = username
        Me.Name = name
    End Sub

    ''' <summary>
    ''' Takes a username + password 
    ''' </summary>
    ''' <param name="username"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    Public Shared Function LoginUser(username As String, password As String, Optional loginLocation As LampCommunication = Nothing) As LampUser
        If loginLocation Is Nothing Then
            loginLocation = OwO.DefaultCommunication
        End If

        Dim sender As New LampSender(loginLocation)
        Return sender.Authenticate(username, password)
    End Function

    Public Function ToProfile() As LampProfile
        Return New LampProfile(Username)
    End Function

End Class

Public Enum UserPermission
    Guest
    Standard
    Admin

End Enum

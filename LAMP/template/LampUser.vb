Public Class LampUser
    Public Property Email As String
    Public Property Password As String
    Public Property Username As String

    Public Property UserId As String

    Public Property PermissionLevel As UserPermission

    Sub New(email As String, username As String, password As String, userid As String, permissionLevel As UserPermission)
        Me.Email = email
        Me.Password = password
        Me.UserId = userid
        Me.PermissionLevel = permissionLevel
        Me.Username = username
    End Sub

    ''' <summary>
    ''' Takes a username + password 
    ''' </summary>
    ''' <param name="username"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    Public Shared Function LoginUser(username As String, password As String, Optional loginLocation As LampCommunication = Nothing) As LampUser
        If loginLocation Is Nothing Then
            loginLocation = New LampCommunication(SubmitType.Local)
        End If

        Dim sender As New LampSender(loginLocation)
        Return sender.Authenticate(username, password)
    End Function


End Class

Public Enum UserPermission
    Guest
    Standard
    Admin

End Enum

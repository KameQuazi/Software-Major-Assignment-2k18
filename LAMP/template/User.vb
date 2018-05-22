Public Class LampUser
    Public Property Email As String
    Public Property Password As String
    Public Property UserId As String
    Public Property PermissionLevel As UserPermission

    Sub New(email As String, password As String, userid As String, permissionLevel As UserPermission)
        Me.Email = email
        Me.Password = password
        Me.UserId = userid
        Me.PermissionLevel = permissionLevel

    End Sub

End Class

Public Enum UserPermission
    Guest
    Standard
    Admin

End Enum

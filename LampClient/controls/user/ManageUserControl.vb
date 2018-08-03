Imports System.ComponentModel
Imports LampCommon

Public Class ManageUserControl
    Public Property UsernameReadonly As Boolean
        Get
            Return TboxUsername.ReadOnly
        End Get
        Set(value As Boolean)
            TboxUsername.ReadOnly = value
        End Set
    End Property

    Private _user As New LampUser("", UserPermission.Guest, "", "", "", "")
    <DesignerSerializationVisibilityAttribute(False)>
    Public Property User As LampUser
        Get
            Return _user
        End Get
        Set(value As LampUser)
            _user = value
            UpdateContents()
        End Set
    End Property

    Private _readonly As Boolean
    Public Property [Readonly] As Boolean
        Get
            Return _readonly
        End Get
        Set(value As Boolean)
            _readonly = value
            If _readonly Then
                DisableEdit()
            Else
                EnableEdit()
            End If
        End Set
    End Property


    Private Sub EnableEdit()
        TboxEmail.ReadOnly = False
        TboxName.ReadOnly = False
        DropDownPermission.Enabled = True
        btnResetPassword.Enabled = True
    End Sub

    Friend Sub ValidateAll()
        ValidateEmail()
        ValidateUsername()
        ValidateName()
        ValidatePassword()
    End Sub

    Private Sub DisableEdit()
        TboxEmail.ReadOnly = True
        TboxName.ReadOnly = True
        DropDownPermission.Enabled = False
        btnResetPassword.Enabled = False
    End Sub



    Private Sub UpdateContents()
        TboxUsername.Text = User.Username
        TboxName.Text = User.Name
        Select Case User.PermissionLevel
            Case UserPermission.Standard
                DropDownPermission.SelectedItem = "Standard"
            Case UserPermission.Elevated
                DropDownPermission.SelectedItem = "Elevated"
            Case UserPermission.Admin
                DropDownPermission.SelectedItem = "Admin"
            Case Else
                DropDownPermission.Items.Add("Unknown")
                DropDownPermission.SelectedIndex = "Unknown"

        End Select
        TboxEmail.Text = User.Email
        TboxPassword.Text = User.Password

    End Sub

    Private allowEdit As Boolean = False

    Private Sub btnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
        Using input As New LampPasswordBox()
            If input.ShowDialog(Me) = DialogResult.OK Then
                TboxPassword.Text = input.InputText
            End If
        End Using
    End Sub




    Private Const UnknownText = "Unknown"
    Private Sub DropDownPermission_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownPermission.SelectedIndexChanged
        Dim selected As String = DropDownPermission.SelectedItem
        If Not selected = UnknownText Then
            If DropDownPermission.Items.Contains(UnknownText) Then
                DropDownPermission.Items.Remove(UnknownText)
            End If
            Select Case selected
                Case "Standard"
                    User.PermissionLevel = UserPermission.Standard
                Case "Elevated"
                    User.PermissionLevel = UserPermission.Elevated
                Case "Admin"
                    User.PermissionLevel = UserPermission.Admin
                Case Else
#If DEBUG Then
                    Throw New ArgumentOutOfRangeException(NameOf(DropDownPermission.SelectedIndex))
#End If
            End Select
        End If
    End Sub


    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TboxEmail.TextChanged
        ' tOdo email validation
        User.Email = TboxEmail.Text
        ValidateEmail()
    End Sub




    Private Sub TboxName_TextChanged(sender As Object, e As EventArgs) Handles TboxName.TextChanged
        User.Name = TboxName.Text
        ValidateName()
    End Sub



    Public Function ValidateEmail() As Boolean
        If TboxEmail.Text = "" Then
            ErrorProvider1.SetError(TboxEmail, "Email is empty")
            Return False
        ElseIf Not OwO.ValidateEmail(TboxEmail.Text) Then
            ErrorProvider1.SetError(TboxEmail, "Email in invalid format")
            Return False
        Else
            ErrorProvider1.SetError(TboxEmail, "")
        End If
        Return True
    End Function

    Public Function ValidateUsername() As Boolean
        If TboxUsername.Text = "" Then
            ErrorProvider1.SetError(TboxUsername, "Username is empty")
            Return False
        Else
            ErrorProvider1.SetError(TboxUsername, "")
        End If
        Return True
    End Function

    Public Function ValidateName() As Boolean
        If TboxName.Text = "" Then
            ErrorProvider1.SetError(TboxName, "Name is empty")
            Return False
        Else
            ErrorProvider1.SetError(TboxName, "")
        End If
        Return True
    End Function

    Private Sub TboxUsername_TextChanged(sender As Object, e As EventArgs) Handles TboxUsername.TextChanged
        User.Username = TboxUsername.Text
        ValidateUsername()
    End Sub

    Public Function ValidatePassword() As Boolean
        If TboxPassword.Text = "" Then
            ErrorProvider1.SetError(TboxPassword, "Password is empty")
            Return False
        ElseIf TboxPassword.Text.Length < MIN_PASSWORD_LENGTH Then
            ErrorProvider1.SetError(TboxPassword, String.Format("Password must be longer than {0} characters long", MIN_PASSWORD_LENGTH))
            Return False
        Else
            ErrorProvider1.SetError(TboxPassword, "")
        End If

        Return True
    End Function

    Private Sub TboxPassword_TextChanged(sender As Object, e As EventArgs) Handles TboxPassword.TextChanged
        User.Password = TboxPassword.Text
        ValidatePassword()
    End Sub
End Class


Public Class UserDeletedEventArgs
    Inherits EventArgs
    Public Property User As LampUser
    Sub New(user As LampUser)
        MyBase.New
        Me.User = user
    End Sub
End Class

Public Class UserEditedEventArgs
    Inherits EventArgs
    Public Property User As LampUser
    Sub New(user As LampUser)
        MyBase.New()
        Me.User = user

    End Sub
End Class
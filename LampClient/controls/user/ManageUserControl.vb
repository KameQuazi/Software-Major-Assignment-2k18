Imports System.ComponentModel
Imports LampCommon

Public Class ManageUserControl
    Public Event UserDeleted(sender As Object, args As UserDeletedEventArgs)
    Public Event UserEdited(sender As Object, args As UserEditedEventArgs)
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

    End Sub

    Private allowEdit As Boolean = False

    Private Sub btnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
        Using input As New LampPasswordBox()
            If input.ShowDialog(Me) = DialogResult.OK Then
                User.Password = input.InputText
            End If
        End Using
    End Sub

    Private Sub EnableEdit()
        TboxEmail.ReadOnly = False
        TboxName.ReadOnly = False
        DropDownPermission.Enabled = True
        btnResetPassword.Enabled = True
    End Sub

    Private Sub DisableEdit()
        TboxEmail.ReadOnly = True
        TboxName.ReadOnly = True
        DropDownPermission.Enabled = False
        btnResetPassword.Enabled = False
    End Sub

    Private previousUser As LampUser
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        allowEdit = Not allowEdit


        If allowEdit Then
            btnEdit.Text = "Confirm Edit"
            EnableEdit()
            btnRevert.Enabled = True
            previousUser = User.Clone()

        Else
            ' actually submit it
            Dim response = CurrentSender.EditUser(CurrentUser.ToCredentials, User)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Successfully edited user!")
                    RaiseEvent UserEdited(Me, New UserEditedEventArgs(User))
                    btnEdit.Text = "Edit User"
                    btnRevert.Enabled = False
                    allowEdit = False
                    DisableEdit()
                Case Else
                    ShowError(response)
            End Select


        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("This will permanently remove this user", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) Then
            Dim response = CurrentSender.RemoveUser(CurrentUser.ToCredentials, User.UserId)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Sucessfully deleted user!")
                    RaiseEvent UserDeleted(Me, New UserDeletedEventArgs(User))
                Case Else
                    ShowError(response)
            End Select
        End If
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
    End Sub

    Private Sub btnRevert_Click(sender As Object, e As EventArgs) Handles btnRevert.Click
        btnRevert.Enabled = False
        User = previousUser
        previousUser = Nothing
        btnEdit.Enabled = True
        btnEdit.Text = "Edit User"
        DisableEdit()
        allowEdit = False
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
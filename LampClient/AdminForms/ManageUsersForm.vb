Public Class ManageUsersForm
    Private Sub ServiceMultiUserViewer1_UserClick(sender As Object, e As UserClickEventArgs) Handles ServiceMultiUserViewer1.UserClick
        Using dialog As New EditUserForm
            dialog.User = e.User
            dialog.ShowDialog(Me)
            ServiceMultiUserViewer1.UpdateContents()
        End Using
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Using dialog As New AddNewUserDialog
            If dialog.ShowDialog(Me) = DialogResult.OK Then

            End If
            ServiceMultiUserViewer1.UpdateContents()
        End Using
    End Sub

    Private Sub load() Handles MyBase.Load
        AdminToolbar1.btnHome.Enabled = True
        AdminToolbar1.btnApproveTemplates.Enabled = True
        AdminToolbar1.btnApproveJob.Enabled = True
        AdminToolbar1.btnManageUsers.Enabled = False
    End Sub
End Class
Public Class ManageUsersForm
    Private Sub ServiceMultiUserViewer1_UserClick(sender As Object, e As UserClickEventArgs) Handles ServiceMultiUserViewer1.UserClick
        Using dialog As New EditUserForm
            dialog.User = e.User
            dialog.ShowDialog(Me)
            ServiceMultiUserViewer1.UpdateContents()
        End Using
    End Sub
End Class
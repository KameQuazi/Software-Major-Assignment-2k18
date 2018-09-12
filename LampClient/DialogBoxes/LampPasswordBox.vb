Public Class LampPasswordBox
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If tboxPassword.Text <> tboxConfirm.Text Then
            lblNoUser.Visible = True
            Label3.Visible = True
            Return
        Else
            lblNoUser.Visible = False
            Label3.Visible = False
        End If
        If tboxPassword.Text.Count < 4 Then
            MessageBox.Show("Password is too short, must be > 3 characters")
            Return
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Public Property InputText As String
        Get
            Return tboxPassword.Text
        End Get
        Set(value As String)
            tboxPassword.Text = value
        End Set
    End Property

    Private Sub tboxPassword_TextChanged(sender As Object, e As EventArgs) Handles tboxPassword.TextChanged

    End Sub
End Class
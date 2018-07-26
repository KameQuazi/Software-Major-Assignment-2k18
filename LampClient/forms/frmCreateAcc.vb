Public Class frmCreateAcc
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        If txtPass.Text <> txtPass2.Text Then
            lblNoMatch.Show()
        Else
            lblNoMatch.Hide()
        End If
        If txtName.Text = "" Then
            lblFillRequired.Show()
            required2.Show()
        End If
        If txtName2.Text = "" Then
            lblFillRequired.Show()
            required3.Show()
        End If
        If txtUser.Text = "" Then
            lblFillRequired.Show()
            required1.Show()
        End If
        If txtPass.Text = "" Then
            lblFillRequired.Show()
            required4.Show()
        End If
        If txtPass2.Text = "" Then
            lblFillRequired.Show()
            required5.Show()
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Private Sub frmCreateAcc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtPass.Text = txtPass2.Text Then
            lblNoMatch.Hide()
        End If
        lblNoEmail.Hide()
        lblNoUser.Hide()
    End Sub
End Class
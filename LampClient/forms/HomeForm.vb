Public Class HomeForm
    Private Sub btnNewOrder_Click(sender As Object, e As EventArgs) Handles btnNewOrder.Click
        TemplateSelectForm.Show()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        AboutBox.Show()
    End Sub

    Private Sub HomeForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Username.Text = String.Format("Hello" + vbCrLf + "{0}!" + vbCrLf + "Welcome to LAMP", CurrentUser.Name)
    End Sub

    Private Sub Username_Click(sender As Object, e As EventArgs) Handles Username.Click

    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click

    End Sub
End Class
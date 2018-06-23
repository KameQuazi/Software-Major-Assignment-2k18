Public Class frmStart
    Private Sub btnQuit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        login.Show()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs)
        AboutBox1.Show()
    End Sub
    Private Sub frmStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolBar1.lblCurScr.Text = "Welcome To LAMP!"
        ToolBar1.btnLogOut.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login.Hide()
    End Sub

    Private Sub frmStart_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    End Sub

    Private Sub WelcomePanel_Paint(sender As Object, e As PaintEventArgs) Handles WelcomePanel.Paint

    End Sub

    Private Async Sub btnlogon_Click(sender As Object, e As EventArgs) Handles btnlogon.Click
        ' TODO: add empty check, max password attempts etc
        Dim user = Await CurrentSender.AuthenticateAsync(txtUser.Text, txtPass.Text)

    End Sub
End Class

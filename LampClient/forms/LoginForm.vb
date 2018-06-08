Public Class frmStart
    Public lastform As String = "main"
    Public curForm As String = "main"
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
        curForm = "main"
    End Sub

    Private Sub WelcomePanel_Paint(sender As Object, e As PaintEventArgs) Handles WelcomePanel.Paint

    End Sub
End Class

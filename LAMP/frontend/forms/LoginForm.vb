Public Class frmStart
    Public lastform As String = "main"
    Public curForm As String = "main"
    Private Sub btnQuit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs)
        AboutBox1.Show()
    End Sub

    Private Sub frmStart_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        curForm = "main"
    End Sub

    Private Sub WelcomePanel_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUser.Text = "Waxy" Then
            If txtPass.Text = "memes" Then
                Me.Hide()
                Main.Show()
            End If
        End If
    End Sub
End Class

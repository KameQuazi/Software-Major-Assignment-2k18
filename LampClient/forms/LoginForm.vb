Imports LampCommon

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

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username = txtUser.Text
        Dim pass = txtPass.Text

        Dim login = CurrentSender.Authenticate(New LampCredentials(username, pass))
        If login.Status = LampStatus.OK Then
            CurrentUser = login.user
            ' TODO login/give message to user
            MessageBox.Show(String.Format("loggin succ: {0}", CurrentUser))
        Else
            ' TODO tell user that they're bad
            ' 
            MessageBox.Show(String.Format("login unsucc: {0})", login.Status))
        End If
    End Sub


End Class

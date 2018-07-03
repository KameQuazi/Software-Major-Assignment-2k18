Imports LampCommon

Public Class LoginForm
    Public lastform As String = "main"
    Public curForm As String = "main"
    Private Sub btnQuit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs)
        AboutBox.Show()
    End Sub

    Private Sub frmStart_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        curForm = "main"
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username = txtUser.Text
        Dim pass = txtPass.Text
        Login(username, pass)

    End Sub

    Private Sub LoginForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, txtPass.KeyDown, txtUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim username = txtUser.Text
            Dim pass = txtPass.Text
            Login(username, pass)
        End If
    End Sub


    Private Sub Login(username As String, password As String)
        Dim login = CurrentSender.Authenticate(New LampCredentials(username, password))
        If login.Status = LampStatus.OK Then
            CurrentUser = login.user
            ' TODO login/give message to user
            MessageBox.Show(String.Format("loggin succ: {0}", CurrentUser))

            HomeForm.Show()
            Me.Close()
        Else
            ' TODO tell user that they're bad
            ' 
            MessageBox.Show(String.Format("login unsucc: {0})", login.Status))
            txtUser.Focus()
        End If
    End Sub

    Private Sub pbLogo_Click(sender As Object, e As EventArgs) Handles pbLogo.Click
        Login("moji", "snack time")
    End Sub
End Class

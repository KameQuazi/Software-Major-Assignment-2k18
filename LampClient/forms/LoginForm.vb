Imports LampCommon

Public Class LoginForm
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


    Private Function Login(username As String, password As String) As Boolean
        Dim loginResponse = CurrentSender.Authenticate(New LampCredentials(username, password))
        If loginResponse.Status = LampStatus.OK Then
            CurrentUser = loginResponse.user

            HomeForm.Show()
            Me.Close()
            Return True
        Else
            txtUser.Focus()
            Return False
        End If
    End Function

    Private Async Sub pbLogo_Click(sender As Object, e As EventArgs) Handles pbLogo.Click
#If DEBUG Then
        If Not Login("moji", "snack time") Then
            Await TemplateDatabase.FillDebugDatabaseAsync
            Login("moji", "snack time")

        End If

#End If
    End Sub
End Class

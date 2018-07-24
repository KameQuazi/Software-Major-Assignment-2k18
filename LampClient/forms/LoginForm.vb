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

    Private Sub SaveLogin(username As String, password As String, doSave As Boolean)
        If doSave = True Then
            My.Settings.LoginUsername = username
            My.Settings.LoginPassword = password
            My.Settings.PasswordSaved = True

        Else
            My.Settings.LoginUsername = ""
            My.Settings.LoginPassword = ""
            My.Settings.PasswordSaved = False
        End If
        My.Settings.Save()
    End Sub


    Private Function Login(username As String, password As String) As Boolean
        Dim loginResponse = CurrentSender.Authenticate(New LampCredentials(username, password))
        If loginResponse.Status = LampStatus.OK Then
            CurrentUser = loginResponse.user

            HomeForm.Show()
            Me.Close()
            SaveLogin(username, password, PasswordCheckbox.Checked)
            Return True
        Else
            ' TODO tell user that they're bad
            ' 
            MessageBox.Show(String.Format("login unsucc: {0})", loginResponse.Status))
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

    Private Sub PasswordCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles PasswordCheckbox.CheckedChanged
        If Not PasswordCheckbox.Checked Then
            My.Settings.LoginPassword = ""
            My.Settings.LoginUsername = ""
            My.Settings.PasswordSaved = False
        End If
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtUser.Text = My.Settings.LoginUsername
        txtPass.Text = My.Settings.LoginPassword
        PasswordCheckbox.Checked = My.Settings.PasswordSaved
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        frmCreateAcc.Show()
    End Sub
End Class

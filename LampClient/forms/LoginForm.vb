Imports LampCommon

Public Class LoginForm
    Private Loaded As Boolean = False

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Not ValidateConnection() Then
            MessageBox.Show("Error when trying to connect to server: please check the connection address is correct", "Error connecting to remote server", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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
            Settings.LoginUsername = username
            Settings.LoginPassword = password
            Settings.PasswordSaved = True
        Else
            Settings.LoginUsername = ""
            Settings.LoginPassword = ""
            Settings.PasswordSaved = False
        End If
    End Sub

    Private Sub SaveEndpoint(address As String, internal As Boolean)
        If internal Then
            Settings.ClientEndpoint = New LampWcfClientSettings(True, "")
        Else
            Settings.ClientEndpoint = New LampWcfClientSettings(False, address)
        End If
        My.Settings.Save()
    End Sub


    Private Function Login(username As String, password As String) As Boolean
        Dim loginResponse = CurrentSender.Authenticate(username, password)
        If loginResponse.Status = LampStatus.OK Then
            CurrentUser = loginResponse.user

            HomeForm.Show()
            Me.Close()
            SaveLogin(username, password, PasswordCheckbox.Checked)
            Return True
        Else
            ' TODO tell user that they're bad
#If DEBUG Then
            MessageBox.Show("Login unsucc: " + loginResponse.Status.ToString())
            txtUser.Focus()
            Return False
#Else
            Select Case loginResponse.Status
                Case LampStatus.InvalidUsernameOrPassword
                    MessageBox.Show(String.Format("An invalid username or password supplied. Please try again"))
                Case Else
                    MessageBox.Show("An unspecified error occured: " + loginResponse.Status.ToString)
            End Select

            txtUser.Focus()
            Return False
#End If

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
            SaveLogin("", "", False)
        End If
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtUser.Text = Settings.LoginUsername
        txtPass.Text = Settings.LoginPassword
        PasswordCheckbox.Checked = Settings.PasswordSaved
        cboxInternal.Checked = Settings.ClientEndpoint.UseLocal
        tboxServerUrl.Text = Settings.ClientEndpoint.ServerAddress
        Loaded = True
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        frmCreateAcc.Show()
    End Sub

    Private Property UseInternal As Boolean
        Get
            Return cboxInternal.Checked
        End Get
        Set(value As Boolean)
            cboxInternal.Checked = value
        End Set
    End Property

    Private Sub cboxInternal_CheckedChanged(sender As Object, e As EventArgs) Handles cboxInternal.CheckedChanged
        If Not Loaded Then
            Return
        End If

        If cboxInternal.Checked Then
            tboxServerUrl.Enabled = False
            btnTryConnection.Enabled = False
            ' save it
            SaveEndpoint("", True)
            ErrorProvider1.SetError(tboxServerUrl, "")
        Else
            tboxServerUrl.Enabled = True
            btnTryConnection.Enabled = True
            If ValidateConnection() Then
                ' save it
                SaveEndpoint(tboxServerUrl.Text, False)
            Else

            End If
        End If
    End Sub

    Private Function CanConnect(str As String) As Boolean
        Try
            SetServiceEndpoint(str)
            CurrentSender.Authenticate(Nothing)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function ValidateConnection() As Boolean
        If UseInternal Then
            Return True
        Else
            Dim result = CanConnect(tboxServerUrl.Text)
            If result Then
                ErrorProvider1.SetError(tboxServerUrl, "")
            Else
                ErrorProvider1.SetError(tboxServerUrl, "Cannot connect to this server")
            End If
            Return result
        End If
    End Function

    Private Sub tboxServerUrl_TextChanged(sender As Object, e As EventArgs) Handles tboxServerUrl.TextChanged
        If Not Loaded Then
            Return
        End If

        If Not UseInternal Then
            ' try to check if it is legit
            If ValidateConnection() Then
                ' help
                SaveEndpoint(tboxServerUrl.Text, False)

            End If

        Else

        End If
    End Sub


End Class

Imports LampCommon

Public Class LoginForm

    Private Async Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username = txtUser.Text
        Dim pass = txtPass.Text
        Await Login(username, pass)
    End Sub



    Private Async Sub LoginForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, txtPass.KeyDown, txtUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim username = txtUser.Text
            Dim pass = txtPass.Text
            Await Login(username, pass)
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


    Private Async Function Login(username As String, password As String) As Task(Of Boolean)
        ' help me please
        Dim past = Me.Enabled
        Me.Enabled = False

        Try
            ShowWaitForm()

            Dim response = Await CurrentSender.AuthenticateAsync(username, password)

            If response.Status = LampStatus.OK Then
                CurrentUser = response.user

                HomeForm.Show()
                Me.Close()
                SaveLogin(username, password, PasswordCheckbox.Checked)
                Return True
            Else
                Select Case response.Status
                    Case LampStatus.InvalidUsernameOrPassword
                        MessageBox.Show(String.Format("An invalid username or password supplied. Please try again"))
                    Case Else
                        MessageBox.Show("An unspecified error occured: " + response.Status.ToString)
                End Select

                txtUser.Focus()
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("An error occured while connecting to server")
#If DEBUG Then
            Throw ex
#End If
        Finally
            Me.Enabled = past
            HideWaitForm()

        End Try





    End Function

    Private Async Sub pbLogo_Click(sender As Object, e As EventArgs) Handles pbLogo.Click
#If DEBUG Then
        If Not Await Login("moji", "snack time") Then
            Await TemplateDatabase.FillDebugDatabaseAsync
            Await Login("moji", "snack time")

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
        rtboxServerUrl.Text = Settings.ClientEndpoint.ServerAddress
        cboxInternal.Checked = Settings.ClientEndpoint.UseLocal
        CheckUserConnections()
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

    Private canLogin As Boolean = False
    Private Sub IndicatorEnabled()
        pBoxConnectionIndicator.Image = My.Resources.green_dot
        canLogin = True
        OnEnabledChanged(Nothing)
    End Sub

    Private Sub IndicatorDisabled()
        pBoxConnectionIndicator.Image = My.Resources.red_dot
        canLogin = False
        OnEnabledChanged(Nothing)

    End Sub

    Private Async Sub CheckUserConnections()
        IndicatorDisabled()

        ' do logic based off the checkbox state
        If cboxInternal.Checked Then
            rtboxServerUrl.Enabled = False
            btnTryConnection.Enabled = False
            ' save it
            SaveEndpoint("", True)
            IndicatorEnabled()
        Else
            rtboxServerUrl.Enabled = True
            btnTryConnection.Enabled = True
            Await AttemptRemoteConnection()
        End If
    End Sub

    Private Sub cboxInternal_CheckedChanged(sender As Object, e As EventArgs) Handles cboxInternal.CheckedChanged
        CheckUserConnections()
    End Sub

    Private Sub btnTryConnection_Click(sender As Object, e As EventArgs) Handles btnTryConnection.Click
        CheckUserConnections()
    End Sub


    Private Async Function AttemptRemoteConnection() As Task
        ' help me please
        Dim past = Me.Enabled
        Me.Enabled = False

        Try
            ShowWaitForm()
            Dim result = Await CanConnect(rtboxServerUrl.Text)
            If result Then
                IndicatorEnabled()
                SaveEndpoint(rtboxServerUrl.Text, False)
            Else
                ErrorProvider1.SetError(rtboxServerUrl, "Cannot connect to server")
            End If

        Catch ex As Exception
            MessageBox.Show("An error occured while connecting to server")
#If DEBUG Then
            Throw ex
#End If
        Finally
            Me.Enabled = past
            HideWaitForm()

        End Try
    End Function

    Private Async Function CanConnect(str As String) As Task(Of Boolean)
        Try
            Dim uriResult As Uri = Nothing
            If Not (Uri.TryCreate(str, UriKind.Absolute, uriResult)) Then
                Return False
            End If

            SetServiceEndpoint(str)
            Await CurrentSender.AuthenticateAsync(Nothing)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)
        For Each control As Control In Me.Controls
            control.Enabled = Me.Enabled
        Next
        If Not canLogin Then
            btnLogin.Enabled = False
            btnCreate.Enabled = False
        End If
    End Sub



    Private Sub tboxServerUrl_TextChanged(sender As Object, e As EventArgs) Handles rtboxServerUrl.TextChanged
        ErrorProvider1.SetError(rtboxServerUrl, "")
    End Sub


End Class

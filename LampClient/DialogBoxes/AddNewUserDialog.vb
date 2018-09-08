Imports LampCommon

Public Class AddNewUserDialog

    Public Property User As LampUser
        Get
            Return ManageUserControl1.User
        End Get
        Set(value As LampUser)
            ManageUserControl1.User = value
        End Set
    End Property
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If Not validateUser Then
            return
        End If
        Dim response = CurrentSender.AddUser(CurrentUser.ToCredentials, ManageUserControl1.User)
        Select Case response
            Case LampStatus.OK
                MessageBox.Show("Sucessfully added user")
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Case LampStatus.UsernameConflict
                MessageBox.Show("Username already taken, please choose a different user")
            Case Else
                ShowError(response)
        End Select

    End Sub

    Private Function validateUser() As Boolean
        Dim warnings As Boolean = False
        Dim warningTEext As String = "Warnings detected: \n"
        ManageUserControl1.ValidateAll
        If User.Username = String.Empty Then
            MessageBox.Show("Username must be specified")
            Return False
        End If
        If User.Email = String.Empty Then
            MessageBox.Show("Email must be specified")
            Return False
        End If

        If Not ValidateEmail(User.Email) Then
            MessageBox.Show("Email is invalid")
            Return False
        End If

        If User.Password = String.Empty Then
            MessageBox.Show("Password is empty")
            Return False
        End If

        If User.Password.Length < MIN_PASSWORD_LENGTH Then
            MessageBox.Show(String.Format("Password must be {0} or more characters long", MIN_PASSWORD_LENGTH))
            Return False
        End If
        Return True

    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        'Me.Close()
    End Sub
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ManageUserControl1.User = New LampUser
    End Sub

    Private Sub AddNewUserDialog_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOk.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            btnCancel.PerformClick()
        End If
    End Sub
End Class
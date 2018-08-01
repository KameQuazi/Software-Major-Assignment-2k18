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
        Me.DialogResult = DialogResult.OK
        If Not validateUser Then
            return
        End If
        Dim response = CurrentSender.AddUser(CurrentUser.ToCredentials, ManageUserControl1.User)
        Select Case response
            Case LampStatus.OK
                MessageBox.Show("Sucessfully added user")
                Me.Close()
            Case LampStatus.UsernameConflict
                MessageBox.Show("Username already taken, please choose a different user")
            Case Else
                ShowError(response)
        End Select
        Me.Close()

    End Sub

    Private Function validateUser() As Boolean
        Dim warnings As Boolean = False
        Dim warningTEext As String = "Warnings detected: \n"
        If User.Username = String.Empty Then
            MessageBox.Show("Username must be specified")
            ' TODO ad a errorprovider
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
        Return True

    End Function
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ManageUserControl1.User = New LampUser
    End Sub
End Class
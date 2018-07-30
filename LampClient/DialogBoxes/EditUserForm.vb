Imports LampCommon

Public Class EditUserForm
    Public Property User As LampUser
        Get
            Return ManageUserControl1.User
        End Get
        Set(value As LampUser)
            ManageUserControl1.User = value
        End Set
    End Property

    Private Sub ManageUserControl1_UserDeleted(sender As Object, args As EventArgs) Handles ManageUserControl1.UserDeleted, ManageUserControl1.UserEdited
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class
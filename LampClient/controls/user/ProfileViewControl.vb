Imports LampCommon

Public Class ProfileViewControl
    Private _profile As LampProfile
    Public Property Profile As LampProfile
        Get
            Return _profile
        End Get
        Set(value As LampProfile)
            _profile = value
            UpdateProfile()
        End Set
    End Property

    Private Sub UpdateProfile()
        If Profile IsNot Nothing Then
            txtBoxName.Text = Profile.Name
            txtBoxUsername.Text = Profile.Username
        Else
            txtBoxName.Text = ""
            txtBoxUsername.Text = ""
        End If
    End Sub

    Private Sub ProfileViewControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

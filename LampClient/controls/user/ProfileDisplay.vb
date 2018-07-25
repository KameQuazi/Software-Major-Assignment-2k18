Imports LampCommon

Public Class ProfileDisplay
    Private _profile As LampProfile

    Public Property Profile As LampProfile
        Get
            Return _profile
        End Get
        Set(value As LampProfile)
            _profile = value
            RefreshProfile()
        End Set
    End Property

    Public Sub RefreshProfile()
        If _profile IsNot Nothing Then
            tboxPermissionlevel.Text = _profile.PermissionLevel.ToString
            tboxUserId.Text = _profile.UserId
            tboxUsername.Text = _profile.Username
            tboxName.Text = _profile.Name
        End If
    End Sub
End Class

Imports LampCommon

Public Class SimpleProfileDisplay
    Public Event DetailedClicked(sender As Object, args As ProfileEventArgs)

    Private _profile As LampProfile
    Public Property Profile As LampProfile
        Get
            Return _profile
        End Get
        Set(value As LampProfile)
            _profile = value
            UpdateContents
        End Set
    End Property

    Public ReadOnly Property Title As Label
        Get
            Return lblTitle
        End Get
    End Property

    Public Property TitleText As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
        End Set
    End Property

    Private _readOnly As Boolean
    Public Property [Readonly] As Boolean
        Get
            Return _readOnly
        End Get
        Set(value As Boolean)
            _readOnly = value
            If value Then
                tboxUsername.ReadOnly = True
            Else
                tboxUsername.ReadOnly = False
            End If
        End Set
    End Property


    Public Property DetailedEnabled As Boolean
        Get
            Return btnDetailed.Enabled
        End Get
        Set(value As Boolean)
            btnDetailed.Enabled = value
        End Set
    End Property
    Private Sub btnDetailed_Click(sender As Object, e As EventArgs) Handles btnDetailed.Click
        RaiseEvent DetailedClicked(Me, New ProfileEventArgs(Profile))
    End Sub

    Public Sub UpdateContents()
        If Profile IsNot Nothing Then
            tboxUsername.Text = Profile.Username
        Else
            tboxUsername.Text = ""
        End If
    End Sub

    Sub New()


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        [Readonly] = True
    End Sub
End Class


Public Class ProfileEventArgs
    Inherits EventArgs
    Public Property Profile As LampProfile
    Sub New(profile As LampProfile)
        MyBase.New()
        Me.Profile = profile
    End Sub

End Class
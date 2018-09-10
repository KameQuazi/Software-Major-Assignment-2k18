Imports System.ComponentModel
Imports LampClient

Public Class AdminToolbar
    Implements IToolbar

#Region "DesignerProperties"
    <Category("DisableButtons")>
    Public Property HomeEnabled As Boolean
        Get
            Return btnHome.Enabled
        End Get
        Set(value As Boolean)
            btnHome.Enabled = value
        End Set
    End Property

    <Category("DisableButtons")>
    Public Property ApproveTemplateEnabled As Boolean
        Get
            Return btnApproveTemplates.Enabled
        End Get
        Set(value As Boolean)
            btnApproveTemplates.Enabled = value
        End Set
    End Property

    <Category("DisableButtons")>
    Public Property ApproveJobEnabled As Boolean
        Get
            Return btnApproveJob.Enabled
        End Get
        Set(value As Boolean)
            btnApproveJob.Enabled = value
        End Set
    End Property

    <Category("DisableButtons")>
    Public Property ManageUsersEnabled As Boolean
        Get
            Return btnManageUsers.Enabled
        End Get
        Set(value As Boolean)
            btnManageUsers.Enabled = value
        End Set
    End Property
#End Region


    Public Sub SetUsername(username As String) Implements IToolbar.SetUsername
        Me.Username.Text = String.Format("Welcome {0}", username)
    End Sub

    Private _confirmationRequired As ConfirmationInformation
    Public Property ConfirmationRequired As ConfirmationInformation Implements IToolbar.ConfirmationRequired
        Get
            Return _confirmationRequired
        End Get
        Set(value As ConfirmationInformation)
            _confirmationRequired = value
        End Set
    End Property


    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        ShowNewForm(ParentForm, AdminForm)
    End Sub

    Private Sub AdminToolbar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreviousForms.Count() = 0 Then
            btnBack.Enabled = False
        Else
            btnBack.Enabled = True
        End If
        SetUsername(CurrentUser.Username)
    End Sub

    Private Sub btnManageUsers_Click(sender As Object, e As EventArgs) Handles btnManageUsers.Click
        ShowNewForm(ParentForm, ManageUsersForm)
    End Sub

    Private Sub btnViewEditJobs_Click(sender As Object, e As EventArgs) Handles btnApproveJob.Click
        ShowNewForm(ParentForm, ApproveJobForm)
    End Sub

    Private Sub btnApproveTemplates_Click(sender As Object, e As EventArgs) Handles btnApproveTemplates.Click
        ShowNewForm(ParentForm, ApproveTemplateForm)
    End Sub



    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Logout(ParentForm)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If PreviousForms.Count = 0 Then
            btnBack.Enabled = False
            MessageBox.Show("ProgramException: PreviousForm not found")
            ' note: this shouldnt be possilbe unless you twiddle w/ the values of PreviousForm urself
            Return
        End If

        ShowPreviousForm(ParentForm)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        AdminHelp.ShowDialog()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        AboutBox.ShowDialog()
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        QuitProgram()
    End Sub
End Class

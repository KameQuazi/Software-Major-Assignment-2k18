Imports LampClient

Public Class AdminToolbar
    Implements IToolbar

    Public Sub SetUsername(username As String) Implements IToolbar.SetUsername
        Me.Username.Text = String.Format("Welcome {0}", username)
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        ShowNewForm(ParentForm, HomeForm)
    End Sub

    Private Sub AdminToolbar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreviousForms.Count() = 0 Then
            btnBack.Enabled = False
        Else
            btnBack.Enabled = True
        End If
        SetUsername(CurrentUser.Username)
    End Sub

    Private Sub btnViewEditTemplate_Click(sender As Object, e As EventArgs) Handles btnViewEditTemplate.Click
        ShowNewForm(ParentForm, ViewEditTemplateForm)
    End Sub

    Private Sub btnViewEditJobs_Click(sender As Object, e As EventArgs) Handles btnViewEditJobs.Click
        ShowNewForm(ParentForm, ViewEditJobsForm)
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
End Class

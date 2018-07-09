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

    End Sub

    Private Sub btnViewEditJobs_Click(sender As Object, e As EventArgs) Handles btnViewEditJobs.Click

    End Sub

    Private Sub btnApproveTemplates_Click(sender As Object, e As EventArgs) Handles btnApproveTemplates.Click

    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click

    End Sub
End Class

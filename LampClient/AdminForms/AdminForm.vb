Public Class AdminForm


    Private Sub btnStandard_Click(sender As Object, e As EventArgs) Handles btnStandard.Click
        AdminToolbar1.ShowNewForm(Me, HomeForm)
    End Sub

    Private Sub zoad() Handles MyBase.Load
        AdminToolbar1.btnHome.Enabled = False
        AdminToolbar1.btnApproveTemplates.Enabled = True
        AdminToolbar1.btnApproveJob.Enabled = True
        AdminToolbar1.btnManageUsers.Enabled = True

    End Sub




End Class
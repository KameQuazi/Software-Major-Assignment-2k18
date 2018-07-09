Imports LampCommon

Public Class HomeForm
    Private Sub btnNewOrder_Click(sender As Object, e As EventArgs)
        TemplateSelectForm.Show()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs)
        AboutBox.Show()
    End Sub

    Private Sub pbLogo_Click(sender As Object, e As EventArgs) Handles pbLogo.Click
        DebugForm.Show()
    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        ToolBar1.ShowNewForm(Me, AdminForm)
    End Sub

    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CurrentUser.PermissionLevel >= UserPermission.Admin Then
            btnAdmin.Enabled = True
        Else
            btnAdmin.Enabled = False
        End If
    End Sub

End Class
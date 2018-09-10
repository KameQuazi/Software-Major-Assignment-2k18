Imports LampCommon

Public Class HomeForm
    Private Sub btnNewOrder_Click(sender As Object, e As EventArgs)
        TemplateSelectBox.Show()
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

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ToolBar1_Load(sender As Object, e As EventArgs) Handles ToolBar1.Load

    End Sub
End Class
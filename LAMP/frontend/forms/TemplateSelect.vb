Public Class TemplateSelect
    Private Sub pbLogo_Click(sender As Object, e As EventArgs)
        frmStart.Show()
        Me.Hide()
        frmStart.lastform = frmStart.curForm
        frmStart.curForm = "view"
    End Sub

    Private Sub fileViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolBar1.lblCurScr.Text = "File Viewer"
        MultiTemplateViewer1.ColumnCount = 2
    End Sub



End Class
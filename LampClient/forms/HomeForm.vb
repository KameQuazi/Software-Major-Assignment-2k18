Public Class HomeForm
    Private Sub btnNewOrder_Click(sender As Object, e As EventArgs)
        TemplateSelectForm.Show()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs)
        AboutBox.Show()
    End Sub

    Private Sub HomeForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    End Sub

    Private Sub Username_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolBar1_Load(sender As Object, e As EventArgs) 

    End Sub

    Private Sub pbLogo_Click(sender As Object, e As EventArgs) Handles pbLogo.Click
        DebugForm.Show()
    End Sub

    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub pnlStart_Paint(sender As Object, e As PaintEventArgs) Handles pnlStart.Paint

    End Sub

    Private Sub ToolBar1_Load_1(sender As Object, e As EventArgs) Handles ToolBar1.Load
        ToolBar1.HomeEnabled = False
    End Sub
End Class
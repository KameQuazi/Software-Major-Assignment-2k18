Public Class Options
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TemplateViewer.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DesignerForm.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim w As New TemplateDatabase()
        Dim y As New LampTemplate
        w.AddTemplate(y)
    End Sub
End Class
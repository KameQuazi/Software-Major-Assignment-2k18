Public Class DebugForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As New TemplateDatabase()
        db.FillDebugDatabase()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim screen As New Form()
        ' TODO replace with shourovs form
        screen.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim screen As New DesignerForm()
        ' TODO replace with shourovs form
        screen.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim screen As New frmStart()
        ' TODO replace with shourovs form
        screen.ShowDialog()
    End Sub
End Class
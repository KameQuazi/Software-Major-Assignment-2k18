Public Class DebugForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As New TemplateDatabase()
        TemplateDatabase.FillDebugDatabase()
        db.GetAllTemplate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim screen As New Form()
        screen.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim screen As New DesignerForm()
        screen.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim screen As New frmStart()
        screen.ShowDialog()
    End Sub

    Private Sub DebugForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim x = New TemplateDatabase()
        x.DeleteTables()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim x = New TemplateSelect()
        x.ShowDialog()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Test()
    End Sub

    Private Sub Test()

        MultiTemplateViewer.LoadExample()
        Dim db As New TemplateDatabase

        Dim lamp As New LampTemplate

        lamp.Tags.Add("wood")
        lamp.Tags.Add("test")

        MultiTemplateViewer.SetTemplateToPosition(0, 0, lamp)

        db.AddTemplate(lamp)

        Dim out = db.SelectTemplate(lamp.GUID)

        MultiTemplateViewer.SetTemplateToPosition(1, 0, out)

        Dim testTags As New List(Of String)
        testTags.Add("wood")
        Dim withTags = db.SelectTemplateWithTags(testTags)

        MultiTemplateViewer.SetTemplateToPosition(2, 0, withTags(0))
    End Sub

    Private Sub Test2()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim x As New TemplateEditor
        x.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Test2()
    End Sub

    Private Sub MultiTemplateViewer_Load(sender As Object, e As EventArgs) Handles MultiTemplateViewer.Load

    End Sub
End Class
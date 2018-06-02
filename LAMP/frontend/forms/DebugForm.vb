Imports netDxf

Public Class DebugForm
    Dim db As New TemplateDatabase()
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Await Task.Run(AddressOf TemplateDatabase.FillDebugDatabase)
        db.GetAllTemplate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim screen As New DBViewer(db)
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
        MultiTemplateViewer1.SetTemplateToPosition(5, 0, New LampTemplate())
    End Sub

    Private Sub Test2()

        Dim x As New Bitmap(500, 500)
        Using g = Graphics.FromImage(x)
            g.DrawArc(New Pen(Color.AliceBlue), New RectangleF(0, 0, 500, 500), 45, 120)
        End Using
        x.Save("out.png")

        Dim y As New DxfDocument
        Dim txt = New Entities.Text("hello", New Vector3(0, 0, 0), 10, Tables.TextStyle.Default)
        txt.ObliqueAngle = 10
        Dim t2 = New Entities.MText("hello", New Vector2(0, 0), 10, 10, Tables.TextStyle.Default)
        t2.Rotation = 10
        y.AddEntity(t2)
        y.AddEntity(txt)
        y.Save("helow.dxf")

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim x As New TemplateEditor
        x.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Test2()
    End Sub

    Private Sub MultiTemplateViewer_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim frm As New DynamicTextCreationForm

        frm.ShowDialog()
    End Sub

    Private Sub DynamicFormCreation1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub MultiTemplateViewer1_Load(sender As Object, e As EventArgs) Handles MultiTemplateViewer1.Load

    End Sub
End Class
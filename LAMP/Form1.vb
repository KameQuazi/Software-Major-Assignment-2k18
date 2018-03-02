Imports System.Drawing.Imaging
Imports Newtonsoft.Json
Imports Point = netDxf.Vector3
Imports LAMP.LampMath



Public Class Form1
    Private dxf As LampDxfDocument
    Private template As LampTemplate


    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OpenFileBtn.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            dxf = LampDxfDocument.LoadFromFile(OpenFileDialog1.FileName)
            SaveFileBtn.Enabled = True

            Me.Invalidate()
            FilenameTbox.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles SaveFileBtn.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            dxf.Save(SaveFileDialog1.FileName)
        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dxf = New LampDxfDocument()
        dxf.AddLine(0, 0, -100, -100)

        template = New LampTemplate(dxf)
        DesignerScreen1.Source = dxf

        jsonOutput.Text = template.Serialize(Formatting.Indented)
        template.Save("out.spf", Formatting.Indented)
        dxf.Save("out.dxf")
        LampTemplate.Load("out.spf")
        ' dxf = template.
        Dim database As New TemplateDB("templatedb.sqlite")
        database.addEntry(template)

    End Sub


    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim z = TextBox1.Text.Split(" ")
        Dim y = TextBox2.Text.Split(" ")
        dxf.AddLine(Double.Parse(z(0)), Double.Parse(z(1)), Double.Parse(y(0)), Double.Parse(y(1)))
        DesignerScreen1.Refresh()
    End Sub



    Private Sub rightButton_Click(sender As Object, e As EventArgs) Handles rightButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, 10, 0)
    End Sub

    Private Sub downButton_Click(sender As Object, e As EventArgs) Handles downButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, 0, -10)
    End Sub

    Private Sub leftButton_Click(sender As Object, e As EventArgs) Handles leftButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, -10, 0)
    End Sub

    Private Sub upButton_Click(sender As Object, e As EventArgs) Handles upButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, 0, 10)
    End Sub

    Private Sub DesignerScreen1_Load(sender As Object, e As EventArgs) Handles DesignerScreen1.Load

    End Sub
End Class


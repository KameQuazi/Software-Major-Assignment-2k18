Imports System.Drawing.Imaging
Imports Newtonsoft.Json
Imports Point = netDxf.Vector3



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

    Dim currentCenter As New PointF(0, 0)

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

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim z = TextBox1.Text.Split(" ")
        Dim y = TextBox2.Text.Split(" ")
        dxf.AddLine(Double.Parse(z(0)), Double.Parse(z(1)), Double.Parse(y(0)), Double.Parse(y(1)))
        Me.Invalidate()
    End Sub

    Private Sub jsonOutput_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub rightButton_Click(sender As Object, e As EventArgs) Handles rightButton.Click
        DesignerScreen1.Center = DesignerScreen1.Center
        Me.Invalidate()
    End Sub

    Private Sub downButton_Click(sender As Object, e As EventArgs) Handles downButton.Click
        currentCenter.Y += 10
        Me.Invalidate()
    End Sub

    Private Sub leftButton_Click(sender As Object, e As EventArgs) Handles leftButton.Click
        currentCenter.X += 10
        Me.Invalidate()
    End Sub

    Private Sub upButton_Click(sender As Object, e As EventArgs) Handles upButton.Click
        currentCenter.Y -= 10
        Me.Invalidate()
    End Sub

    Private Sub DesignerScreen1_Load(sender As Object, e As EventArgs) Handles DesignerScreen1.Load

    End Sub
End Class


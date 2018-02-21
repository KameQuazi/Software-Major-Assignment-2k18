Imports System.Drawing.Imaging
Imports Point = netDxf.Vector3



Public Class Form1
    Private dxf As LampDxfDocument
    Private template As LampTemplate


    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            dxf = New LampDxfDocument(OpenFileDialog1.FileName)
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            dxf.Save(SaveFileDialog1.FileName)
        End If
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dxf = New LampDxfDocument()
        dxf.AddLine(0, 0, 100, 50)
        dxf.AddArc(0, 0, 5, 0, 90)
        dxf.AddMultiText(0, 0, "hewwo!", 12, 100)
        dxf.Save("out.dxf")
        Dim bmp As New Bitmap(200, 200)

        Using g = Graphics.FromImage(bmp)
            g.FillRectangle(New SolidBrush(Color.LightSlateGray), 0, 0, Width, Height)

            dxf.WriteToGraphics(g, New PointF(0, 0), 200, 200)
        End Using
        bmp.Save("out.png", ImageFormat.Png)
        template = New LampTemplate(dxf)

        jsonOutput.Text = template.Serialize()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.TranslateTransform(200, 0)
        g.FillRectangle(New SolidBrush(Color.LightSlateGray), 0, 0, 200, 200)
        dxf.WriteToGraphics(g, New PointF(0, 0), 200, 200)
        g.ResetTransform()

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim z = TextBox1.Text.Split(" ")
        Dim y = TextBox2.Text.Split(" ")
        dxf.AddLine(Double.Parse(z(0)), Double.Parse(z(1)), Double.Parse(y(0)), Double.Parse(y(1)))
        Me.Invalidate()
    End Sub

    Private Sub jsonOutput_Click(sender As Object, e As EventArgs) Handles jsonOutput.Click

    End Sub
End Class


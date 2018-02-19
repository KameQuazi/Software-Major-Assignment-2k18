Imports System.Drawing.Imaging
Imports Point = netDxf.Vector3



Public Class Form1
    Private dxf As LampDxfDocument


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
        dxf.AddLine(0, 0, 100, 100)
        dxf.AddArc(0, 0, 5, 0, 90)
        dxf.AddMultiText(0, 0, "hewwo!", 12, 100)
        dxf.Save("out.dxf")
        Dim bmp As New Bitmap(200, 200)

        Using g = Graphics.FromImage(bmp)
            ' g.FillRectangle()
            dxf.WriteToGraphics(g, New PointF(0, 0), 200, 200)
        End Using
        bmp.Save("out.png", ImageFormat.Png)
    End Sub


End Class


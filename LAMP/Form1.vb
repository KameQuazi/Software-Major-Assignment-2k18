Imports Point = netDxf.Vector3



Public Class Form1
    Private dxf As LampDxfDocument


    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            dxf = New LampDxfDocument(OpenFileDialog1.FileName)
            Button2.Enabled = true
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.Ok
            dxf.Save(SaveFileDialog1.FileName)
        End If
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dxf = New LampDxfDocument()
        dxf.AddLine(0,0,100,100)
        dxf.AddArc(0, 0, 5, 0, 90)
        dxf.AddMultiText(0, 0, "hewwo!", 12, 100)
        dxf.Save("out.dxf")
    End Sub

    
End Class


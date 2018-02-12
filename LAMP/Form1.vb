Imports IxMilia.Dxf.Entities

Public Class Form1
    Private dxf as DxfDrawing


    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.Ok
            dxf = New DxfDrawing(OpenFileDialog1.FileName)
            Button2.Enabled = true
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
       For Each item in dxf.GetAll()
            Select item.EntityType
                
                Case DxfEntityType.Line
                    dim line = CType(item, DxfLine)
                    MessageBox.Show(line.P1.ToString() + ":" + line.P2.ToString())
                Case Else
                    MessageBox.Show([Enum].GetName(GetType(DxfEntityType), item.EntityType))

            End Select
       Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class


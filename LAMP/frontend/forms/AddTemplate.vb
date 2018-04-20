Public Class AddTemplate
    Private dxf As LampDxfDocument
    Private image1 As Image
    Private image2 As Image
    Private image3 As Image

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DxfFileDialog.ShowDialog = DialogResult.OK Then
            Try
                dxf = LampDxfDocument.FromFile(DxfFileDialog.FileName)
                DxfIndicator.Text = DxfFileDialog.FileName
            Catch ex As FormatException
                MessageBox.Show(ex.Message)
            End Try




        Else
            dxf = Nothing
            DxfIndicator.Text = "*None*"
        End If
    End Sub

    Private Sub AddTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Preview1_Click(sender As Object, e As EventArgs) Handles Preview1.Click
        If ImageFileDialog.ShowDialog = DialogResult.OK Then
            image1 = Image.FromFile(ImageFileDialog.FileName)
            Preview1.Image = image1

        End If
    End Sub

    Private Sub Preview2_Click(sender As Object, e As EventArgs) Handles Preview2.Click
        If ImageFileDialog.ShowDialog = DialogResult.OK Then
            image2 = Image.FromFile(ImageFileDialog.FileName)
            Preview2.Image = image2
        End If
    End Sub

    Private Sub Preview3_Click(sender As Object, e As EventArgs) Handles Preview3.Click
        If ImageFileDialog.ShowDialog = DialogResult.OK Then
            image3 = Image.FromFile(ImageFileDialog.FileName)
            Preview3.Image = image3
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim temp As New LampTemplate()
        temp.Template = dxf
        Dim images As New List(Of Image)

        If image1 IsNot Nothing Then
            images.Add(image1)
        End If
        If image2 IsNot Nothing Then
            images.Add(image2)
        End If
        If image3 IsNot Nothing Then
            images.Add(image3)
        End If

        If images.Count > 0 Then
            temp.PreviewImages = images
        End If

        Dim db As New TemplateDatabase()
        db.AddTemplate(temp)
    End Sub
End Class
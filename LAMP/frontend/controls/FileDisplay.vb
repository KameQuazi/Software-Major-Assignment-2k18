Public Class fileDisplay
    Private Sub DisplayBox_Click(sender As Object, e As EventArgs) Handles DisplayBox.Click

    End Sub

    Public Sub DisplayTemplate(template As LampTemplate)
        Dim dxf = template.Template
        lblName.Text = "Name: test trophy"
        lblCreator.Text = "Creator: Waxy by steve"
        If template.PreviewImages.Count > 0 Then
            DisplayBox.Image = template.PreviewImages(0)
        End If

        lblWidth.Text = "Width: " & dxf.Width
        lblMaterial.Text = "Material: " & template.Material & " thiccness: " & template.MaterialThickness
        lblCutTime.Text = "Time to Cut: ?? Min"
    End Sub
End Class

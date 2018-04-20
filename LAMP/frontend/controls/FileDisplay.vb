Public Class FileDisplay

    Private _template As LampTemplate

    ''' <summary>
    ''' Change template to change the text on the display
    ''' </summary>
    ''' <returns></returns>
    Public Property Template As LampTemplate
        Get
            Return _template
        End Get
        Set(value As LampTemplate)
            _template = value
            DisplayTemplate(value)
        End Set
    End Property

    Private Sub DisplayTemplate(template As LampTemplate)
        If template IsNot Nothing Then
            Dim dxf = template.Template
            lblName.Text = "Name: " & template.Name
            lblCreator.Text = "Creator: Waxy by steve"
            If template.PreviewImages.Count > 0 Then
                DisplayBox.Image = template.PreviewImages(0)
            End If

            lblWidth.Text = "Width: " & dxf.Width
            lblMaterial.Text = "Material: " & template.Material & " thiccness: " & template.MaterialThickness
            lblCutTime.Text = "Time to Cut: ?? Min"
        Else
            lblName.Text = "Name: *None*"
            lblCreator.Text = "Creator: *None*"
            lblWidth.Text = "Width: *None*"
            lblMaterial.Text = "Material: *None*"
            lblCutTime.Text = "Time to Cut: *None*"
        End If
    End Sub

    Private Sub FileDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class

Public Class FileDisplay

    Private _template As LampTemplate = LampTemplate.Empty

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

    ''' <summary>
    ''' Puts all the details from a template into the control
    ''' </summary>
    ''' <param name="template"></param>
    Private Sub DisplayTemplate(template As LampTemplate)
        If template IsNot Nothing And template IsNot LampTemplate.Empty Then
            Dim dxf = template.BaseDrawing
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

    Private Sub DisplayBox_Click(sender As Object, e As EventArgs) Handles DisplayBox.Click
        If Me.Enabled Then
            ' Oepn up the single template Viewer
            Dim singleViewer As New TemplateEditor()
            singleViewer.Template = Me.Template
            singleViewer.ShowDialog()
            Me.Template = singleViewer.Template
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Visible = False
    End Sub
End Class

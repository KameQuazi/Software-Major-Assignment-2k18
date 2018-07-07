Imports LampCommon

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

    Private Const NoneText = "*none*"

    ''' <summary>
    ''' Puts all the details from a template into the control
    ''' </summary>
    ''' <param name="template"></param>
    Private Sub DisplayTemplate(template As LampTemplate)
        Dim dxf = template.BaseDrawing

        editname.Text = template.Name

        If template.CreatorProfile IsNot Nothing Then
            editcreator.Text = template.CreatorProfile.Username
        Else
            editcreator.Text = NoneText
        End If

        If template.ApproverProfile IsNot Nothing Then
            editapprover.Text = template.CreatorProfile.Username
        Else
            editapprover.Text = NoneText
        End If

        If template.PreviewImages(0) IsNot Nothing Then
            DisplayBox.Image = template.PreviewImages(0)
        Else
            DisplayBox.Image = My.Resources.no_preview_image
        End If

        editwidth.Text = dxf.Width
        editheight.Text = dxf.Height
        editmaterial.Text = template.Material

        '" thiccness: " & template.MaterialThickness

    End Sub



    Private Sub FileDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub DisplayBox_Click(sender As Object, e As EventArgs) Handles DisplayBox.Click
        If Me.Enabled And Template IsNot Nothing Then
            ' Oepn up the single template Viewer
            Dim singleViewer As New TemplateEditorForm()
            singleViewer.Template = Me.Template
            singleViewer.ShowDialog()
            Me.Template = singleViewer.Template
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Visible = False
    End Sub

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Template = LampTemplate.Empty
    End Sub
End Class

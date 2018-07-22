Imports LampCommon

Public Class TemplateDisplay

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
            editapprover.Text = template.ApproverProfile.Username
        Else
            editapprover.Text = NoneText
        End If

        If template.PreviewImages(0) IsNot Nothing Then
            DisplayBox.Image = template.PreviewImages(0)
        Else
            DisplayBox.Image = My.Resources.no_preview_image
        End If

        ' TO decimal places
        editwidth.Text = dxf.Width.ToString("0.00")
        editheight.Text = dxf.Height.ToString("0.00")
        editmaterial.Text = template.Material

        '" thiccness: " & template.MaterialThickness

    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Visible = False
    End Sub



    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Template = LampTemplate.Empty
        AddBubblingEvent(Me.Controls)
    End Sub

    Private Sub RaiseClickEvent(sender As Object, e As EventArgs)
        Me.OnClick(e)
    End Sub

    ''' <summary>
    ''' Recusively add click handler -> 
    ''' </summary>
    ''' <param name="controls"></param>
    Private Sub AddBubblingEvent(controls As ICollection)

        For Each control As Control In controls
            AddHandler control.Click, AddressOf RaiseClickEvent
            AddBubblingEvent(control.Controls)
        Next
    End Sub


    Public Property MouseOverHighlight As Boolean = False

    Public Property HighLightColor As Color = Color.AliceBlue

    Private _mouseEntered As Boolean = False

    Private Sub FileDisplay_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        _mouseEntered = True
        If MouseOverHighlight Then
            Me.BackColor = HighLightColor
        End If
    End Sub

    Private Sub FileDisplay_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        _mouseEntered = False
        If MouseOverHighlight Then
            Me.BackColor = Color.White
        End If
    End Sub

    Private Sub editapprover_Click(sender As Object, e As EventArgs) Handles editapprover.Click

    End Sub
End Class

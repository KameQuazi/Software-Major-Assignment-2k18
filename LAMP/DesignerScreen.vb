Imports System.ComponentModel

Public Class DesignerScreen
    Private Sub DesignerScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private _center As New PointF
    <Description("Where the center of the view is"), Category("Data")>
    Public Property Center As PointF
        Get
            Return _center
        End Get
        Set(value As PointF)
            _center = value
            UpdateView()
        End Set
    End Property

    Private _source As LampDxfDocument
    <Description("The dxf document that is rendered onto this control"), Category("Data")>
    Public Property Source As LampDxfDocument
        Get
            Return _source
        End Get
        Set(value As LampDxfDocument)
            _source = value
            UpdateView()
        End Set
    End Property

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UpdateView()
    End Sub

    Public Sub UpdateView()
        Me.Invalidate()
    End Sub


    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If Source IsNot Nothing Then
            Dim g = e.Graphics
            g.FillRectangle(New SolidBrush(Color.LightSlateGray), 0, 0, Width, Height)
            ' Source.ToImage(Center, Width, Height).Save("out.png")
            Source.WriteToGraphics(g, Center, Width, Height)

        End If
    End Sub

    Private Sub DesignerScreen_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        UpdateView()
    End Sub
End Class

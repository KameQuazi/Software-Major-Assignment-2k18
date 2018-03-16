Imports System.ComponentModel

Public Class DesignerScreen
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

    Private Sub SourceChanged(sender As Object, e As PropertyChangedEventArgs)
        If sender IsNot Nothing Then
            UpdateView()
        End If
    End Sub

    Private _source As LampDxfDocument
    <Description("The dxf document that is rendered onto this control"), Category("Data")>
    Public Property Source As LampDxfDocument
        Get
            Return _source
        End Get
        Set(value As LampDxfDocument)
            If value <> _source Then
                _source = value
                If _source IsNot Nothing Then
                    AddHandler value.PropertyChanged, AddressOf SourceChanged
                    UpdateView()
                End If
            End If
        End Set
    End Property

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        If Me.DesignMode Then
            Me.Source = New LampDxfDocument()
        End If

        ' Add any initialization after the InitializeComponent() call.
        UpdateView()
    End Sub

    Public Sub UpdateView()
        Me.Invalidate()
    End Sub

    Public BackgroundColorBrush As Brush = New SolidBrush(Color.LimeGreen)

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If Source IsNot Nothing Then
            Dim g = e.Graphics
            g.FillRectangle(BackgroundColorBrush, 0, 0, Width, Height)
            ' Source.ToImage(Center, Width, Height).Save("out.png")
            Source.WriteToGraphics(g, Center, Width, Height)

        End If
    End Sub

    Private Sub DesignerScreen_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        UpdateView()
    End Sub

    Private Sub DesignerScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
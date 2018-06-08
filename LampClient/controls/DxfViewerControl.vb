Imports System.ComponentModel
Imports LampCommon

Public Class DxfViewerControl
    Implements INotifyPropertyChanged

    Public Property BackgroundColorBrush As Brush = New SolidBrush(Color.LimeGreen)
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

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

    Private _drawing As LampDxfDocument

    <Description("The dxf document that is rendered onto this control"), Category("Data")>
    Public Property Drawing As LampDxfDocument
        Get
            Return _drawing
        End Get
        Set(value As LampDxfDocument)
            If value <> _drawing Then
                If _drawing IsNot Nothing Then
                    RemoveHandler _drawing.PropertyChanged, AddressOf SourceChanged
                    AddHandler value.PropertyChanged, AddressOf SourceChanged
                End If
                _drawing = value
            End If
            UpdateView()
        End Set
    End Property

    Private _zoomX As Double = 1
    ''' <summary>
    ''' The zoom level. 2x zoomx = 2x zoom in the x direction and so on
    ''' </summary>
    ''' <returns></returns>
    <Description("X zoom factor"), Category("Data")>
    Public Property ZoomX As Double
        Get
            Return _zoomX
        End Get
        Set(value As Double)
            _zoomX = value
            UpdateView()
        End Set
    End Property

    Private _zoomY As Double = 1
    <Description("Y zoom factor"), Category("Data")>
    Public Property ZoomY As Double
        Get
            Return _zoomY
        End Get
        Set(value As Double)
            _zoomY = value
            UpdateView()
        End Set
    End Property

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        If Me.DesignMode Then
            Me.Drawing = New LampDxfDocument()
        End If

        ' Add any initialization after the InitializeComponent() call.
        UpdateView()
    End Sub

    Public Sub UpdateView()
        Me.Invalidate()
    End Sub


    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If Drawing IsNot Nothing Then
            Dim g = e.Graphics
            g.FillRectangle(BackgroundColorBrush, 0, 0, Width, Height)
            ' Source.ToImage(Center, Width, Height).Save("out.png")
            Drawing.WriteToGraphics(g, Center, Width, Height, 1 / ZoomX, 1 / ZoomY)

        End If
    End Sub

    Private Sub DesignerScreen_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        UpdateView()
    End Sub

    Private Sub DesignerScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
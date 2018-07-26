Imports System.ComponentModel
Imports LampCommon
Imports netDxf



<DefaultEvent("MouseClickAbsolute")>
Public Class DxfViewerControl
    Implements INotifyPropertyChanged
    Public Event MouseClickAbsolute(sender As Object, args As MouseClickAbsoluteEventArgs)
    Public Event MouseMoveAbsolute(sender As Object, args As MouseMoveAbsoluteEventArgs)

    Private Sub Handle_Click(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'Console.WriteLine("x: " + e.X.ToString + "y: " + e.Y.ToString)
        RaiseEvent MouseClickAbsolute(Me, New MouseClickAbsoluteEventArgs(LampDxfHelper.GdiToCartesian(Center, Width, Height, e.Location, 1 / ZoomX, 1 / ZoomY)))
    End Sub

    Private Sub Handle_Move(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        RaiseEvent MouseMoveAbsolute(Me, New MouseMoveAbsoluteEventArgs(LampDxfHelper.GdiToCartesian(Center, Width, Height, e.Location, 1 / ZoomX, 1 / ZoomY)))
    End Sub


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
            If _drawing IsNot Nothing Then
                RemoveHandler _drawing.PropertyChanged, AddressOf SourceChanged
            End If

            If value IsNot Nothing Then
                AddHandler value.PropertyChanged, AddressOf SourceChanged
            End If
            _drawing = value
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
        Me.DoubleBuffered = True

        ' Add any initialization after the InitializeComponent() call.
        UpdateView()
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get

            Dim handleParam = MyBase.CreateParams
            handleParam.ExStyle = handleParam.ExStyle Or &H2000000 '  // WS_EX_COMPOSITED       
            Return handleParam
        End Get
    End Property


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




End Class

Public Class MouseClickAbsoluteEventArgs
    Inherits EventArgs
    Public Property Location As Vector3
    Public Sub New(location As Vector3)
        MyBase.New()
        Me.Location = location
    End Sub
End Class

Public Class MouseMoveAbsoluteEventArgs
    Inherits EventArgs
    Public Property Location As Vector3
    Public Sub New(location As Vector3)
        MyBase.New()
        Me.Location = location
    End Sub
End Class
Imports System.IO
Imports netDxf
Imports netDxf.Entities
Imports netDxf.Units


' WARNING! Aliasing Point3 to vector2
Imports Point3 = netDxf.Vector3


Public Class LampDxfDocument
    Private _dxfFile As DxfDocument

    ''' <summary>
    ''' Creates a new DxfDrawing, reading from a file given in filePath
    ''' </summary>
    ''' <param name="filePath">Filepath of file to read</param>
    Sub New(filePath As String)
        _dxfFile = DxfDocument.Load(filePath)
    End Sub

    ''' <summary>
    ''' Creates a new, empty DxfDrawing
    ''' </summary>
    Sub New()
        _dxfFile = New DxfDocument()

    End Sub

    ''' <summary>
    ''' Saves the file
    ''' </summary>
    ''' <param name="filepath"></param>
    Public Sub Save(filepath As String)
        Using fs = New FileStream(filepath, FileMode.Create)
            _dxfFile.Save(fs)
        End Using
    End Sub

    ''' <summary>
    ''' Adds a line between two coordinates. Shorthand for AddLine(New line(...))
    ''' </summary>
    ''' <param name="x1">x value of first</param>
    ''' <param name="y1">y value of first</param>
    ''' <param name="x2">x value of second</param>
    ''' <param name="y2">y value of second</param>
    Public Sub AddLine(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        AddLine(New Line(ConvertPoint3(x1, y1), ConvertPoint3(x2, y2)))
    End Sub

    ''' <summary>
    ''' Adds a line between two coordinates. Shorthand for AddLine(New line(...))
    ''' </summary>
    ''' <param name="start">startpoint </param>
    ''' <param name="end">endpoint </param>
    Public Sub AddLine(start As Point3, [end] As Point3)
        AddLine(New Line(start, [end]))
    End Sub

    ''' <summary>
    ''' Adds a line to the dxfDrawing
    ''' </summary>
    ''' <param name="line">Line object to add</param>
    Public Sub AddLine(line As Line)
        _dxfFile.AddEntity(line)
    End Sub

    ''' <summary>
    ''' Adds an already created circle into the dxf document
    ''' </summary>
   	''' <param name="circle">Circle object to add</param>
    Public Sub AddCircle(circle As Circle)
        _dxfFile.AddEntity(circle)
    End Sub

    ''' <summary>
    ''' Adds a circle to the drawing. Shorthand for AddCircle(New Circle(...))
    ''' </summary>
    ''' <param name="centerX">Point3 1</param>
    ''' <param name="centerY">Point3 2</param>
    ''' <param name="radius">radius of circle</param>
    Public Sub AddCircle(centerX As Integer, centerY As Integer, radius As Double)
        _dxfFile.AddEntity(New Circle(ConvertPoint3(centerX, centerY), radius))
    End Sub

    Public Sub AddCircle(centre As Point3, radius As Double)
        _dxfFile.AddEntity(New Circle(ConvertPoint3(centre.X, centre.Y), radius))
    End Sub


    Public Sub AddPolyline(ParamArray Point3s() As Point3)
        AddPolyline(Point3s)
    End Sub

    Public Sub AddPolyline(Point3s As IEnumerable(Of Point3))

        _dxfFile.AddEntity(New Polyline(Point3s))
    End Sub

    Public Sub AddArc(centerX As Integer, centerY As Integer, radius As Double, startAngle As Double, endAngle As Double)
        _dxfFile.AddEntity(New Arc(ConvertPoint3(centerX, centerY), radius, startAngle, endAngle))
    End Sub

    ''' <summary>
    ''' Adds a multi line text to the drawing
    ''' TextHeight is the height PER LINE of text
    ''' width is the max width of the text object
    ''' </summary>
    ''' <param name="x">x value of bottom left</param>
    ''' <param name="y">y value of bottom left</param>
    ''' <param name="text"></param>
    ''' <param name="textHeight"></param>
    ''' <param name="width"></param>
    Public Sub AddMultiText(x As Integer, y As Integer, text As String, textHeight As Double, width As Double)
        _dxfFile.AddEntity(New MText(text, ConvertPoint3(x, y), textHeight, width))
    End Sub




    Public Shared Function ConvertPoint3(x As Integer, y As Integer) As Point3
        Return New Point3(x, y, 0)
    End Function

    Public Shared Function ConvertToPointF(point As Point3) As Drawing.PointF
        Return New PointF(point.X, point.Y)
    End Function


    Public Overrides Function ToString() As String
        Return String.Format("CustomDxfDrawing: {0}", _dxfFile)
    End Function



    Public Function GetRawDxf() As DxfDocument
        Return _dxfFile
    End Function



    Public Sub WriteToGraphics(g As Graphics, middle As PointF, width As Integer, height As Integer)
        ' the bounds where entities are rendered
        Dim bounds As New RectangleF(middle.X - width / 2, middle.Y + height / 2, width, height)

        For Each line As Line In _dxfFile.Lines
            If IntersectsWith(bounds, line) Then
                Dim start As PointF = ConvertToPointF(line.StartPoint)
                start.X -= middle.X
                start.Y -= middle.Y

                Dim [end] As PointF = ConvertToPointF(line.EndPoint)
                [end].X -= middle.X
                [end].Y -= middle.Y

                g.DrawLine(New Pen(line.Color.ToColor()), start, [end])
            End If
        Next
    End Sub


    Private Function IntersectsWith(rect As RectangleF, line As Line) As Boolean
        Return True
    End Function
End Class


Imports System.IO
Imports netDxf
Imports netDxf.Entities


' WARNING! Aliasing point to vector2
Imports Point = netDxf.Vector3


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
        AddLine(New Line(ConvertPoint(x1, y1), ConvertPoint(x2, y2)))
    End Sub

    ''' <summary>
    ''' Adds a line between two coordinates. Shorthand for AddLine(New line(...))
    ''' </summary>
    ''' <param name="point1">point 1</param>
    ''' <param name="point2">point 2</param>
    Public Sub AddLine(point1 As Point, point2 As Point)
        AddLine(New Line(point1, point2))
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
    ''' <param name="centerX">point 1</param>
    ''' <param name="centerY">point 2</param>
    ''' <param name="radius">radius of circle</param>
    Public Sub AddCircle(centerX As Integer, centerY As Integer, radius As Double)
        _dxfFile.AddEntity(New Circle(ConvertPoint(centerX, centerY), radius))
    End Sub

    Public Sub AddCircle(centre As Point, radius As Double)
        _dxfFile.AddEntity(New Circle(ConvertPoint(centre.X, centre.Y), radius))
    End Sub


    Public Sub AddPolyline(ParamArray points() As Point)
        AddPolyline(points)
    End Sub

    Public Sub AddPolyline(points As IEnumerable(Of Point))

        _dxfFile.AddEntity(New Polyline(points))
    End Sub

    Public Sub AddArc(centerX As Integer, centerY As Integer, radius As Double, startAngle As Double, endAngle As Double)
        _dxfFile.AddEntity(New Arc(ConvertPoint(centerX, centerY), radius, startAngle, endAngle))
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
        _dxfFile.AddEntity(New MText(text, ConvertPoint(x, y), textHeight, width))
    End Sub




    Private Function ConvertPoint(x As Integer, y As Integer) As Point
        Return New Point(x, y, 0)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("CustomDxfDrawing: {0}", _dxfFile)
    End Function



    Public Function GetRawDxf() As DxfDocument
        Return _dxfFile
    End Function
End Class



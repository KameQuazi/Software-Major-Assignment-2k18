Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text
Imports LAMP
Imports netDxf
Imports netDxf.Entities
Imports netDxf.Tables
Imports netDxf.Units
Imports Newtonsoft.Json
Imports LAMP.LampMath

' WARNING! Aliasing Point3 to vector3
Imports Point3 = netDxf.Vector3



<JsonConverter(GetType(DxfJsonConverter))>
Public Class LampDxfDocument
    ''' <summary>
    ''' DxfDocument from .netdxf library
    ''' </summary>
    Private _dxfFile As DxfDocument

    Public Property BottomLeft As New Point3
    Public Property TopRight As New Point3



    ''' <summary>
    ''' Creates a new LampDxfDocument from a dxf string
    ''' </summary>
    ''' <param name="dxf"></param>
    Public Shared Function LoadFromString(dxf As String) As LampDxfDocument
        Dim out As LampDxfDocument
        Using stream As New MemoryStream(Encoding.UTF8.GetBytes(dxf))
            out = New LampDxfDocument(DxfDocument.Load(stream))
            Return out
        End Using
    End Function

    Public Function ToDxfString() As String
        Dim out As String
        Using stream As New MemoryStream()
            GetRawDxf().Save(stream, isBinary:=False)
            Using reader As New StreamReader(stream)
                out = reader.ReadToEnd()
            End Using
        End Using
        Return out
    End Function

    ''' <summary>
    ''' Creates a new, empty LampDxfDrawing
    ''' </summary>
    Sub New()
        _dxfFile = New DxfDocument()
        RecalculateBounds()
    End Sub

    ''' <summary>
    ''' Creates a new LampDxfDrawing from an existing one
    ''' </summary>
    ''' <param name="dxfFile"></param>
    Sub New(dxfFile As DxfDocument)
        _dxfFile = dxfFile
        RecalculateBounds()
    End Sub


    ''' <summary>
    ''' Creates a new DxfDrawing, reading from a file given in filePath
    ''' </summary>
    ''' <param name="filePath">Filepath of file to read</param>
    Public Shared Function LoadFromFile(filePath As String) As LampDxfDocument
        Dim dxf = DxfDocument.Load(filePath)
        If dxf Is Nothing Then
            Throw New InvalidTimeZoneException("dxf cannot be loaded from string")
        End If
        Return New LampDxfDocument(dxf)
    End Function


    ''' <summary>
    ''' Rasterises the contents of the dxfFile into an Image
    ''' </summary>
    ''' <param name="center"></param>
    ''' <param name="width"></param>
    ''' <param name="height"></param>
    ''' <returns></returns>
    Public Function ToImage(center As PointF, width As Integer, height As Integer) As System.Drawing.Image
        Dim bmp As New Bitmap(width, height)

        Using g = Graphics.FromImage(bmp)
            g.FillRectangle(BackgroundBrush, 0, 0, width, height)
            WriteToGraphics(g, center, width, height)
        End Using
        Return bmp
    End Function

    Public Function ToImage() As System.Drawing.Image
        Return ToImage(New PointF((BottomLeft.X + TopRight.X) / 2, (BottomLeft.Y + TopRight.Y) / 2),
                       Math.Abs(BottomLeft.X - TopRight.X),
                       Math.Abs(BottomLeft.Y - TopRight.Y))
    End Function

    Public Property BackgroundBrush As New SolidBrush(Color.LightSlateGray)

    Public Sub InsertInto(otherDrawing As LampDxfDocument, point As LampDxfInsertLocation)
        Dim offset = point.InsertPoint
        For Each line As Line In _dxfFile.Lines
            Dim start = line.StartPoint

        Next
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
    Public Sub AddLine(x1 As Double, y1 As Double, x2 As Double, y2 As Double)
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

    Private Sub RecalculateBounds()
        For Each line As Line In _dxfFile.Lines
            If IsBottomOrLeft(line.StartPoint) Then
                BottomLeft = line.StartPoint
            End If
            If IsBottomOrLeft(line.EndPoint) Then
                BottomLeft = line.EndPoint
            End If
            If IsTopOrRight(line.StartPoint) Then
                TopRight = line.StartPoint
            End If
            If IsTopOrRight(line.EndPoint) Then
                TopRight = line.EndPoint
            End If
        Next
        ' TODO others
    End Sub

    Private Function IsBottomOrLeft(point As Point3) As Boolean
        If point.X < Me.BottomLeft.X Then
            Return True
        End If
        If point.Y < Me.BottomLeft.Y Then
            Return True
        End If
        Return False
    End Function

    Private Function IsTopOrRight(point As Point3) As Boolean
        If point.X > Me.TopRight.X Then
            Return True
        End If
        If point.Y > Me.TopRight.Y Then
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Adds a circle to the drawing. Shorthand for AddCircle(New Circle(...))
    ''' </summary>
    ''' <param name="centerX">Point3 1</param>
    ''' <param name="centerY">Point3 2</param>
    ''' <param name="radius">radius of circle</param>
    Public Sub AddCircle(centerX As Double, centerY As Double, radius As Double)
        _dxfFile.AddEntity(New Circle(ConvertPoint3(centerX, centerY), radius))
    End Sub

    Public Sub AddCircle(centre As Point3, radius As Double)
        _dxfFile.AddEntity(New Circle(ConvertPoint3(centre.X, centre.Y), radius))
    End Sub


    Public Sub AddPolyline(ParamArray Points() As Point3)
        AddPolyline(Points)
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
    Public Sub AddMultiText(x As Integer, y As Integer, text As String, textHeight As Double, width As Double, Optional tstyle As TextStyle = Nothing)
        _dxfFile.AddEntity(New MText(text, ConvertPoint3(x, y), textHeight, width))
    End Sub

    Public Sub AddText(x As Integer, y As Integer, text As String, height As Integer)
        _dxfFile.AddEntity(New Text(text, New Point3(x, y, 0), height))
    End Sub

    Public Sub AddEntity(ent As EntityObject, Optional recalculate As Boolean = True)
        _dxfFile.AddEntity(ent)
        If recalculate = True Then
            RecalculateBounds()
        End If
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


    ''' <summary>
    ''' Draws the contents onto a graphics object
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="middle"></param>
    ''' <param name="width"></param>
    ''' <param name="height"></param>
    Public Sub WriteToGraphics(g As Graphics, middle As PointF, width As Integer, height As Integer)
        ' the bounds where entities are rendered
        Dim bounds As New RectangleF(middle.X - width / 2, middle.Y + height / 2, width, height)

        For Each line As Line In _dxfFile.Lines
            If IntersectsWith(bounds, line) Then
                Dim start = LampMath.CartesianToGdi(middle, width, height, line.StartPoint.X, line.StartPoint.Y)

                Dim [end] = LampMath.CartesianToGdi(middle, width, height, line.EndPoint.X, line.EndPoint.Y)

                g.DrawLine(New Pen(line.Color.ToColor()), start, [end])
            End If
        Next
    End Sub
End Class

Public Class DxfJsonConverter
    Inherits JsonConverter

    Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
        Dim document As LampDxfDocument = value
        Dim dxfString As String = document.ToDxfString()
        writer.WriteValue(dxfString)
    End Sub

    Public Overrides Function CanConvert(objectType As Type) As Boolean
        Return objectType = GetType(DxfDocument)
    End Function

    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
        Dim out As LampDxfDocument
        If reader.TokenType <> JsonToken.String Then
            Throw New JsonSerializationException()
        Else
            Dim value As String = reader.Value
            out = LampDxfDocument.LoadFromString(value)
        End If

        Return out
    End Function

End Class

Public Class LampMath
    Public Shared Function CartesianToGdi(center As PointF, width As Integer, height As Integer, cartesianX As Double, cartesianY As Double) As PointF
        Dim ret As New PointF(-center.X + width / 2, center.Y + height / 2)
        ret.X += cartesianX
        ret.Y -= cartesianY
        Return ret
    End Function

    Public Shared Function GdiToCartesian(center As PointF, width As Integer, height As Integer, location As PointF) As PointF
        Throw New Exception("TODO")
    End Function

    Public Shared Function Transform(point As PointF, x As Double, y As Double) As PointF
        point.X += x
        point.Y += y
        Return point
    End Function

    Public Shared Function IntersectsWith(rect As RectangleF, line As Line) As Boolean

        Return True
    End Function

End Class
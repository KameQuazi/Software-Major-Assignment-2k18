Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text
Imports netDxf
Imports netDxf.Entities
Imports netDxf.Tables
Imports netDxf.Units
Imports Newtonsoft.Json

' WARNING! Aliasing Point3 to vector3
Imports Point3 = netDxf.Vector3

Public Class DxfJsonConverter
    Inherits JsonConverter

    Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
        Dim document As DxfDocument = value
        ' save it to a stream, then convert the stream -> a string and return the string
        Dim dxfString As String = ""
        Using stream As New MemoryStream()
            document.Save(stream, isBinary:=False)
            Using reader As New StreamReader(stream)
                dxfString = reader.ReadToEnd()
            End Using
        End Using
        writer.WriteValue(dxfString)
    End Sub

    Public Overrides Function CanConvert(objectType As Type) As Boolean
        Return objectType = GetType(DxfDocument)
    End Function

    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
        Dim out As DxfDocument
        If reader.TokenType <> JsonToken.String Then
            Throw New JsonSerializationException()
        Else
            Dim value As String = reader.Value
            Using stream As New MemoryStream(Encoding.UTF8.GetBytes(value))
                out = DxfDocument.Load(stream)
            End Using
        End If

        Return out
    End Function

End Class

Public Class LampDxfDocument
    ''' <summary>
    ''' DxfDocument from .netdxf library
    ''' </summary>
    <JsonProperty("dxfFile")>
    <JsonConverter(GetType(DxfJsonConverter))>
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

    Public Function ToImage(center As PointF, width As Integer, height As Integer) As System.Drawing.Image
        Dim bmp As New Bitmap(width, height)

        Using g = Graphics.FromImage(bmp)
            g.FillRectangle(New SolidBrush(Color.LightSlateGray), 0, 0, width, height)

            WriteToGraphics(g, center, width, 200)
        End Using
        Return bmp
    End Function



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
    Public Sub AddMultiText(x As Integer, y As Integer, text As String, textHeight As Double, width As Double, Optional tstyle As TextStyle = Nothing)
        _dxfFile.AddEntity(New MText(text, ConvertPoint3(x, y), textHeight, width))
    End Sub

    Public Sub AddText(x As Integer, y As Integer, text As String, height As Integer)
        _dxfFile.AddEntity(New Text(text, New Point3(x, y, 0), height))
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
                Dim start = LampMath.CartesianToGdi(middle, width, height, line.StartPoint.X, line.StartPoint.Y)

                Dim [end] = LampMath.CartesianToGdi(middle, width, height, line.EndPoint.X, line.EndPoint.Y)

                g.DrawLine(New Pen(line.Color.ToColor()), start, [end])
            End If
        Next
    End Sub




    Private Function IntersectsWith(rect As RectangleF, line As Line) As Boolean

        Return True
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
End Class
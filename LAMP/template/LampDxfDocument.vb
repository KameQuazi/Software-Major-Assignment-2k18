Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text
Imports LAMP
Imports netDxf
Imports netDxf.Entities
Imports netDxf.Tables
Imports netDxf.Units
Imports Newtonsoft.Json
Imports LAMP.LampDxfHelper
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

<JsonConverter(GetType(DxfJsonConverter))>
Public Class LampDxfDocument
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ''' <summary>
    ''' DxfDocument from .netdxf library
    ''' </summary>
    Public ReadOnly Property DxfFile As DxfDocument

    ''' <summary>
    ''' The width of all parts of dxfDocument
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Width As Double
        Get
            Return TopRight.X - BottomLeft.X
        End Get
    End Property

    ''' <summary>
    ''' The height of all parts of dxfDocument
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Height As Double
        Get
            Return TopRight.Y - BottomLeft.Y
        End Get
    End Property

    ''' <summary>
    ''' Bottom Left point 
    ''' </summary>
    ''' <returns></returns>
    Public Property BottomLeft As New Vector3

    ''' <summary>
    ''' Top right point
    ''' </summary>
    ''' <returns></returns>
    Public Property TopRight As New Vector3

    ''' <summary>
    ''' Brush used to draw the background
    ''' </summary>
    ''' <returns></returns>
    Public Property BackgroundBrush As New SolidBrush(Color.LightSlateGray)

    ''' <summary>
    ''' Constructor for LampDxfDocument
    ''' </summary>
    Sub New()
        _dxfFile = New DxfDocument()
        RecalculateBounds()
    End Sub

    ''' <summary>
    ''' Creates a new LampDxfDrawing from an existing DxfDrawing (From netDxf),
    ''' NOT a LampDxfDocument
    ''' </summary>
    ''' <param name="dxfFile"></param>
    Sub New(dxfFile As DxfDocument)
        Me.DxfFile = dxfFile
        RecalculateBounds()
    End Sub

    ''' <summary>
    ''' Creates a new LampDxfDocument from a dxf string
    ''' </summary>
    ''' <param name="dxf"></param>
    Public Shared Function FromString(dxf As String) As LampDxfDocument
        Dim out As LampDxfDocument
        Using stream As New MemoryStream(Encoding.UTF8.GetBytes(dxf))
            out = New LampDxfDocument(DxfDocument.Load(stream))
            Return out
        End Using
    End Function

    ''' <summary>
    ''' Converts to Dxf String
    ''' </summary>
    ''' <returns></returns>
    Public Function ToDxfString() As String
        Dim out As String
        Using stream As New MemoryStream()
            DxfFile.Save(stream, isBinary:=False)
            Using reader As New StreamReader(stream)
                out = reader.ReadToEnd()
            End Using
        End Using
        Return out
    End Function

    ''' <summary>
    ''' Creates a new DxfDrawing, reading from a file given in filePath
    ''' </summary>
    ''' <param name="filePath">Filepath of file to read</param>
    Public Shared Function FromFile(filePath As String) As LampDxfDocument
        Dim version = DxfDocument.CheckDxfFileVersion(filePath, New Boolean())
        If version < Header.DxfVersion.AutoCad2000 Then
            Throw New FormatException(String.Format("DXF version = {0} < AutoCad 2000, cannot be read", version))
        End If

        Dim dxf = DxfDocument.Load(filePath)

        If dxf Is Nothing Then
            Throw New FormatException("DXF invalid")
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
    Public Function RasterizeImage(center As PointF, width As Integer, height As Integer) As System.Drawing.Image
        Dim bmp As New Bitmap(width, height)

        Using g = Graphics.FromImage(bmp)
            g.FillRectangle(BackgroundBrush, 0, 0, width, height)
            WriteToGraphics(g, center, width, height)
        End Using
        Return bmp
    End Function

    ''' <summary>
    ''' Converts this to an image
    ''' </summary>
    ''' <returns></returns>
    Public Function ToImage() As System.Drawing.Image
#Disable Warning BC42016 ' Implicit conversion
        Return RasterizeImage(New PointF((BottomLeft.X + TopRight.X) / 2, (BottomLeft.Y + TopRight.Y) / 2),
                       Width, Height)
#Enable Warning BC42016 ' Implicit conversion
    End Function

    ''' <summary>
    ''' Inserts a lampdocument into this document at the insertionpoint given
    ''' TODO!
    ''' </summary>
    ''' <param name="otherDrawing"></param>
    ''' <param name="point"></param>
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
    Public Sub AddLine(start As Vector3, [end] As Vector3)
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
    Public Sub AddCircle(centerX As Double, centerY As Double, radius As Double)
        _dxfFile.AddEntity(New Circle(ConvertPoint3(centerX, centerY), radius))
    End Sub

    ''' <summary>
    ''' Adds a circle to drawing. Shorthand for AddCircle(New Circle(...))
    ''' </summary>
    ''' <param name="centre"></param>
    ''' <param name="radius"></param>
    Public Sub AddCircle(centre As Vector3, radius As Double)
        _dxfFile.AddEntity(New Circle(ConvertPoint3(centre.X, centre.Y), radius))
    End Sub

    ''' <summary>
    ''' Adds a polyline to drawing. Shorthand for AddPolyLine(points)
    ''' </summary>
    ''' <param name="Points"></param>
    Public Sub AddPolyline(ParamArray Points() As Vector3)
        AddPolyline(Points)
    End Sub

    ''' <summary>
    ''' Adds a polyline to drawing. Shorthand for AddPolyLine(points)
    ''' </summary>
    ''' <param name="Point3s"></param>
    Public Sub AddPolyline(Point3s As IEnumerable(Of Vector3))
        _dxfFile.AddEntity(New Polyline(Point3s))
    End Sub

    ''' <summary>
    ''' Adds an arc to the drawing. Shorthand for AddArc(...)
    ''' </summary>
    ''' <param name="centerX"></param>
    ''' <param name="centerY"></param>
    ''' <param name="radius"></param>
    ''' <param name="startAngle"></param>
    ''' <param name="endAngle"></param>
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

    ''' <summary>
    ''' Adds single line text to drawing
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="text"></param>
    ''' <param name="height"></param>
    Public Sub AddText(x As Integer, y As Integer, text As String, height As Integer)
        _dxfFile.AddEntity(New Text(text, New Vector3(x, y, 0), height))
    End Sub

    ''' <summary>
    ''' adds any entity to the drawing. 
    ''' </summary>
    ''' <param name="ent"></param>
    ''' <param name="recalculate"></param>
    Public Sub AddEntity(ent As EntityObject, Optional recalculate As Boolean = True)
        _dxfFile.AddEntity(ent)
        If recalculate = True Then
            RecalculateBounds()
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("CustomDxfDrawing: {0}", _dxfFile)
    End Function

    ''' <summary>
    ''' Draws the contents onto a graphics object
    ''' Only draws lines right now
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="middle"></param>
    ''' <param name="width"></param>
    ''' <param name="height"></param>
    Public Sub WriteToGraphics(g As Graphics, middle As PointF, width As Integer, height As Integer)
        ' the bounds where entities are rendered
#Disable Warning BC42016 ' Implicit conversion
        Dim bounds As New RectangleF(middle.X - width / 2, middle.Y + height / 2, width, height)
#Enable Warning BC42016 ' Implicit conversion

        For Each line As Line In _dxfFile.Lines
            If IntersectsWith(bounds, line) Then
                Dim start = CartesianToGdi(middle, width, height, line.StartPoint.X, line.StartPoint.Y)

                Dim [end] = CartesianToGdi(middle, width, height, line.EndPoint.X, line.EndPoint.Y)

                g.DrawLine(New Pen(line.Color.ToColor()), start, [end])
            End If
        Next
    End Sub

    ''' <summary>
    ''' Todo implement equality lampdxf
    ''' </summary>
    ''' <param name="first"></param>
    ''' <param name="second"></param>
    ''' <returns></returns>
    Public Shared Operator =(ByVal first As LampDxfDocument, ByVal second As LampDxfDocument) As Boolean
        Return False
    End Operator

    ''' <summary>
    ''' Todo implement equality lampdxf
    ''' </summary>
    ''' <param name="first"></param>
    ''' <param name="second"></param>
    ''' <returns></returns>
    Public Shared Operator <>(ByVal first As LampDxfDocument, ByVal second As LampDxfDocument) As Boolean
        Return True
    End Operator

    ''' <summary>
    ''' Calculates the width, height bottomleft and right of the document
    ''' </summary>
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

    ''' <summary>
    ''' Checks if point is more bottom or more left of the drawing
    ''' </summary>
    ''' <param name="point"></param>
    ''' <returns></returns>
    Private Function IsBottomOrLeft(point As Vector3) As Boolean
        If point.X < Me.BottomLeft.X Then
            Return True
        End If
        If point.Y < Me.BottomLeft.Y Then
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Checks if point is more top or right of the drawing
    ''' </summary>
    Private Function IsTopOrRight(point As Vector3) As Boolean
        If point.X > Me.TopRight.X Then
            Return True
        End If
        If point.Y > Me.TopRight.Y Then
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Used to notify if a property changes
    ''' </summary>
    ''' <param name="propertyName"></param>
    Private Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class

Public Class DxfJsonConverter
    Inherits JsonConverter

    Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
        Dim document As LampDxfDocument = DirectCast(value, LampDxfDocument)
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
            Dim value As String = DirectCast(reader.Value, String)
            out = LampDxfDocument.FromString(value)
        End If

        Return out
    End Function

End Class

Public Class InvalidJsonDxfExceptions
    Inherits JsonSerializationException

End Class


Public Class LampDxfHelper
    Public Shared Function ConvertPoint3(x As Double, y As Double) As Vector3
        Return New Vector3(x, y, 0)
    End Function

    Public Shared Function ConvertToPointF(point As Vector3) As Drawing.PointF
#Disable Warning BC42016 ' Implicit conversion
        Return New PointF(point.X, point.Y)
#Enable Warning BC42016 ' Implicit conversion
    End Function

    Public Shared Function IntersectsWith(rect As RectangleF, line As Line) As Boolean
        Return True
    End Function
    Public Shared Function CartesianToGdi(center As PointF, width As Integer, height As Integer, cartesianX As Double, cartesianY As Double) As PointF
#Disable Warning BC42016 ' Implicit conversion
        Dim ret As New PointF(-center.X + width / 2, center.Y + height / 2)
        ret.X += cartesianX
        ret.Y -= cartesianY
#Enable Warning BC42016 ' Implicit conversion
        Return ret
    End Function

    Public Shared Function GdiToCartesian(center As PointF, width As Integer, height As Integer, location As PointF) As PointF
        Throw New Exception("TODO")
    End Function

    Public Shared Function Transform(point As PointF, x As Double, y As Double) As PointF
#Disable Warning BC42016 ' Implicit conversion  
        point.X += x
        point.Y += y
#Enable Warning BC42016 ' Implicit conversion
        Return point
    End Function
End Class
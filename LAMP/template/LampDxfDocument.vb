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
Imports System.Drawing.Drawing2D

<JsonConverter(GetType(DxfJsonConverter))>
Public Class LampDxfDocument
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public ReadOnly Property DefaultFont As New FontFamily("Arial")

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
        _DxfFile = New DxfDocument()
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
        If width <= 0 Then
            Throw New ArgumentOutOfRangeException(NameOf(width))
        End If
        If height <= 0 Then
            Throw New ArgumentOutOfRangeException(NameOf(height))
        End If
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
    ''' Saves the file
    ''' </summary>
    ''' <param name="filepath"></param>
    Public Sub Save(filepath As String)
        Using fs = New FileStream(filepath, FileMode.Create)
            _DxfFile.Save(fs)
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
        _DxfFile.AddEntity(line)
    End Sub

    ''' <summary>
    ''' Adds an already created circle into the dxf document
    ''' </summary>
   	''' <param name="circle">Circle object to add</param>
    Public Sub AddCircle(circle As Circle)
        _DxfFile.AddEntity(circle)
    End Sub

    ''' <summary>
    ''' Adds a circle to the drawing. Shorthand for AddCircle(New Circle(...))
    ''' </summary>
    ''' <param name="centerX">Point3 1</param>
    ''' <param name="centerY">Point3 2</param>
    ''' <param name="radius">radius of circle</param>
    Public Sub AddCircle(centerX As Double, centerY As Double, radius As Double)
        _DxfFile.AddEntity(New Circle(ConvertPoint3(centerX, centerY), radius))
    End Sub

    ''' <summary>
    ''' Adds a circle to drawing. Shorthand for AddCircle(New Circle(...))
    ''' </summary>
    ''' <param name="centre"></param>
    ''' <param name="radius"></param>
    Public Sub AddCircle(centre As Vector3, radius As Double)
        _DxfFile.AddEntity(New Circle(ConvertPoint3(centre.X, centre.Y), radius))
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
        _DxfFile.AddEntity(New Polyline(Point3s))
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
        _DxfFile.AddEntity(New Arc(ConvertPoint3(centerX, centerY), radius, startAngle, endAngle))
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
        _DxfFile.AddEntity(New MText(text, ConvertPoint3(x, y), textHeight, width))
    End Sub

    ''' <summary>
    ''' Adds single line text to drawing
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="text"></param>
    ''' <param name="height"></param>
    Public Sub AddText(x As Integer, y As Integer, text As String, height As Integer)
        _DxfFile.AddEntity(New Text(text, New Vector3(x, y, 0), height))
    End Sub

    Public Function AddText(text As Text) As Text
        DxfFile.AddEntity(text)
        Return text
    End Function

    Public Function AddMText(mtext As MText) As MText
        DxfFile.AddEntity(mtext)
        Return mtext
    End Function

    Public Function AddImage(image As Image) As Image
        DxfFile.AddEntity(image)
        Return image
    End Function

    Public Function AddMLine(mline As MLine) As MLine
        DxfFile.AddEntity(mline)
        Return mline
    End Function

    Public Function AddRay(ray As Ray) As Ray
        DxfFile.AddEntity(ray)
        Return ray
    End Function



    Public Function AddArc(arc As Arc) As Arc
        _DxfFile.AddEntity(arc)
        Return arc
    End Function

    Public Function AddEllipse(ellipse As Ellipse) As Ellipse
        _DxfFile.AddEntity(ellipse)
        Return ellipse
    End Function

    Public Function AddPoint(point As Point) As Point
        _DxfFile.AddEntity(point)
        Return point
    End Function

    ''' <summary>
    ''' adds any entity to the drawing. 
    ''' </summary>
    ''' <param name="ent"></param>
    ''' <param name="recalculate"></param>
    Public Sub AddEntity(ent As EntityObject, Optional recalculate As Boolean = True)
        _DxfFile.AddEntity(ent)
        If recalculate = True Then
            RecalculateBounds()
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("CustomDxfDrawing: {0}", _DxfFile)
    End Function

    ''' <summary>
    ''' Inserts a lampdocument into this document at the insertionpoint given
    ''' TODO!
    ''' </summary>
    ''' <param name="otherDrawing"></param>
    ''' <param name="insertLocation"></param>
    Public Sub InsertInto(otherDrawing As LampDxfDocument, insertLocation As LampDxfInsertLocation)
        Dim offset = insertLocation.InsertPoint

        For Each arc As Arc In DxfFile.Arcs
            Dim newArc As Arc = arc.Clone()
            newArc.Center = Transform(newArc.Center, offset)
            otherDrawing.AddArc(newArc)
        Next

        For Each circle As Circle In DxfFile.Circles
            Dim newCircle As Circle = circle.Clone()
            newCircle.Center = Transform(newCircle.Center, offset)
            otherDrawing.AddCircle(newCircle)
        Next

        For Each ellipse As Ellipse In DxfFile.Ellipses
            Dim newEllipse As Ellipse = ellipse.Clone()
            newEllipse.Center = Transform(newEllipse.Center, offset)
            otherDrawing.AddEllipse(newEllipse)
        Next

        For Each line As Line In DxfFile.Lines
            Dim newLine As Line = line.Clone()
            newLine.StartPoint = Transform(newLine.StartPoint, offset)
            newLine.EndPoint = Transform(newLine.EndPoint, offset)
            otherDrawing.AddLine(newLine)
        Next

        For Each line As Line In DxfFile.Lines
            Dim newLine As Line = line.Clone()
            newLine.StartPoint = Transform(newLine.StartPoint, offset)
            newLine.EndPoint = Transform(newLine.EndPoint, offset)
        Next

        For Each point As Point In DxfFile.Points
            Dim newPoint As Point = point.Clone()
            newPoint.Position = Transform(newPoint.Position, offset)
            otherDrawing.AddPoint(newPoint)
        Next

        For Each polyLine As Polyline In DxfFile.Polylines
            Dim newPolyLine As Polyline = polyLine.Clone()
            For Each point In newPolyLine.Vertexes
                point.Position = Transform(point.Position, offset)
            Next
            otherDrawing.AddPolyline(newPolyLine)
        Next

        For Each text As Text In DxfFile.Texts
            Dim newText As Text = text.Clone()
            newText.Position = Transform(newText.Position, offset)
            otherDrawing.AddText(newText)
        Next

        For Each mtext As MText In DxfFile.MTexts
            Dim newmtext As Text = mtext.Clone()
            newmtext.Position = Transform(newmtext.Position, offset)
            otherDrawing.AddText(newmtext)
        Next

        For Each image As Image In DxfFile.Images
            Dim newimage As Text = image.Clone()
            newimage.Position = Transform(newimage.Position, offset)
            otherDrawing.AddText(newimage)
        Next

        For Each mLine As MLine In DxfFile.MLines
            Dim newmLine As Text = mLine.Clone()
            newmLine.Position = Transform(newmLine.Position, offset)
            otherDrawing.AddText(newmLine)
        Next

        For Each ray As Ray In DxfFile.Rays
            Dim newRay As Ray = ray.Clone()
            newRay.Origin = Transform(newRay.Origin, offset)
            otherDrawing.AddRay(newRay)
        Next
    End Sub

    ''' <summary>
    ''' Draws the contents onto a graphics object
    ''' Only draws lines right now
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="focalPoint">where the center of the view is</param>
    ''' <param name="renderWidth">number of pixels to render</param>
    ''' <param name="renderHeight">number of pixels to render</param>
    ''' <param name="pixelsPerUnitX">number of cartesian units per pixel</param>
    ''' <param name="pixelsPerUnitY">Number of cartesian units in dxf per pixel y. recommended to be equal to pixelsPerX</param>
    Public Sub WriteToGraphics(g As Graphics, focalPoint As PointF, renderWidth As Double, renderHeight As Double, Optional pixelsPerUnitX As Double = 1, Optional pixelsPerUnitY As Double = 1)
        ' the bounds where entities are rendered
        ' draw x at 0, 0
        If pixelsPerUnitY <= 0 Then
            Throw New ArgumentOutOfRangeException(NameOf(pixelsPerUnitY))
        End If
        If pixelsPerUnitX <= 0 Then
            Throw New ArgumentOutOfRangeException(NameOf(pixelsPerUnitX))
        End If

        Dim cartesianZero As PointF = CartesianToGdi(focalPoint, renderWidth, renderHeight, New Vector3(0, 0, 0), 1, 1)
        g.DrawLine(New Pen(Color.Purple), cartesianZero.X - 50, cartesianZero.Y, cartesianZero.X + 50, cartesianZero.Y)
        g.DrawLine(New Pen(Color.Purple), cartesianZero.X, cartesianZero.Y - 50, cartesianZero.X, cartesianZero.Y + 50)


        Dim bounds As New RectangleF(focalPoint.X - renderWidth.ToSingle * pixelsPerUnitX.ToSingle / 2,
                                     focalPoint.Y + renderHeight.ToSingle * pixelsPerUnitY.ToSingle / 2,
                                     renderWidth.ToSingle,
                                     renderHeight.ToSingle)

        For Each arc As Arc In DxfFile.Arcs
            If InsideBounds(bounds, arc) Then
                ' draw arc takes in the upper left corner, width/height of the ellipse (equal=radius since it is always circular)
                ' start angle and total angle subtended

                ' However, we need the top left corner, from center
                Dim upperLeft = arc.Center
                upperLeft.X -= arc.Radius
                upperLeft.Y += arc.Radius

                Dim GdiUpperleft = CartesianToGdi(focalPoint, renderWidth, renderHeight, upperLeft, pixelsPerUnitX, pixelsPerUnitY)
                ' arc startangle is anti-clockwise from the positive x axis, then further anticlockwise till endangle
                ' however, gdi draws clockwise from positive x axis, then clockwise theta degrees sweepangle
                ' therefore, the arc's endpoint is actually the arc originates

                Dim gdiStartAngle = 360 - arc.EndAngle

                ' if startAngle > endangle, 
                Dim angleRotated = (arc.EndAngle - arc.StartAngle + 360) Mod 360


                ' Width, height = 2x radius
                Dim arcBound As New RectangleF(GdiUpperleft, New SizeF(Convert.ToSingle(arc.Radius * 2 / pixelsPerUnitX), Convert.ToSingle(arc.Radius * 2 / pixelsPerUnitY)))

                g.DrawArc(New Pen(arc.Color.ToColor()), arcBound, Convert.ToSingle(gdiStartAngle), Convert.ToSingle(angleRotated))

            End If
        Next

        For Each circle As Circle In DxfFile.Circles
            If InsideBounds(bounds, circle) Then
                ' get upper left point (in cartesian point)
                Dim upperleft = circle.Center
                upperleft.Y += circle.Radius
                upperleft.X -= circle.Radius

                Dim gdiCenter = CartesianToGdi(focalPoint, renderWidth, renderHeight, upperleft, pixelsPerUnitX, pixelsPerUnitY)
                Dim circleBound As New RectangleF(gdiCenter, New SizeF(Convert.ToSingle(circle.Radius * 2 / pixelsPerUnitX), Convert.ToSingle(circle.Radius * 2 / pixelsPerUnitY)))

                g.DrawEllipse(New Pen(circle.Color.ToColor()), circleBound)
            End If
        Next

        For Each ellipse As Ellipse In DxfFile.Ellipses

        Next

        For Each line As Line In DxfFile.Lines
            If InsideBounds(bounds, line) Then
                Dim start = CartesianToGdi(focalPoint, renderWidth, renderHeight, line.StartPoint.X, line.StartPoint.Y, pixelsPerUnitX, pixelsPerUnitY)

                Dim [end] = CartesianToGdi(focalPoint, renderWidth, renderHeight, line.EndPoint.X, line.EndPoint.Y, pixelsPerUnitX, pixelsPerUnitY)

                g.DrawLine(New Pen(line.Color.ToColor()), start, [end])
            End If
        Next

        For Each point As Point In DxfFile.Points

        Next

        For Each polyline As Polyline In DxfFile.Polylines
            If InsideBounds(bounds, polyline) Then
                Dim previousPoint As PolylineVertex = Nothing
                For Each vertex In polyline.Vertexes
                    If previousPoint IsNot Nothing Then
                        Dim start = CartesianToGdi(focalPoint, renderWidth, renderHeight, previousPoint.Position.X, previousPoint.Position.Y, pixelsPerUnitX, pixelsPerUnitY)

                        Dim [end] = CartesianToGdi(focalPoint, renderWidth, renderHeight, vertex.Position.X, vertex.Position.Y, pixelsPerUnitX, pixelsPerUnitY)

                        g.DrawLine(New Pen(polyline.Color.ToColor()), start, [end])
                    End If

                    previousPoint = vertex
                Next
            End If
        Next

        For Each text As Text In DxfFile.Texts
            If InsideBounds(bounds, text) Then
                Dim upperleft = text.Position
                ' text.Position is from bottom left of the text
                upperleft.Y += text.Height

                Dim gdiUpperleft = CartesianToGdi(focalPoint, renderWidth, renderHeight, upperleft, pixelsPerUnitX, pixelsPerUnitY)

                g.DrawString(text.Value, New Font(New FontFamily(text.Style.FontFamilyName), (text.Height / pixelsPerUnitY).ToSingle), New SolidBrush(text.Color.ToColor()), gdiUpperleft)

            End If
        Next

        For Each mtext As MText In DxfFile.MTexts

        Next

        For Each image As Image In DxfFile.Images

        Next

        For Each mLine As MLine In DxfFile.MLines

        Next

        For Each ray As Ray In DxfFile.Rays

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
        For Each line As Line In _DxfFile.Lines
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

    Public Shared Function ImageToBase64(image As System.Drawing.Image) As String
        If image Is Nothing Then
            Return Nothing
        End If
        Using ms = New MemoryStream()
            image.Save(ms, Imaging.ImageFormat.Png)
            Return System.Convert.ToBase64String(ms.ToArray)
        End Using
    End Function

    Public Shared Function Base64ToImage(base64 As String) As Drawing.Image
        If base64 Is Nothing Then
            Return Nothing
        End If
        Dim bytes = Convert.FromBase64String(base64)
        Using ms = New MemoryStream(bytes)
            Return Drawing.Image.FromStream(ms)
        End Using
    End Function
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
        Return New PointF(point.X.ToSingle, point.Y.ToSingle)
    End Function

    Public Shared Function InsideBounds(rect As RectangleF, text As Text) As Boolean
        Return True
    End Function

    Public Shared Function InsideBounds(rect As RectangleF, MText As MText) As Boolean
        Return True
    End Function

    Public Shared Function InsideBounds(rect As RectangleF, line As Line) As Boolean
        Return True
    End Function

    Public Shared Function InsideBounds(rect As RectangleF, arc As Arc) As Boolean
        Return True
    End Function


    Public Shared Function InsideBounds(rect As RectangleF, circle As Circle) As Boolean
        Return True
    End Function

    Public Shared Function InsideBounds(rect As RectangleF, polyLine As Polyline) As Boolean
        Return True
    End Function

    Public Shared Function CartesianToGdi(center As PointF, width As Double, height As Double, cartesianPoint As Vector3, Optional pixelsPerX As Double = 1, Optional pixelsPerY As Double = 1) As PointF
        Return CartesianToGdi(center, width, height, cartesianPoint.X, cartesianPoint.Y, pixelsPerX, pixelsPerY)
    End Function

    Public Shared Function CartesianToGdi(center As PointF, width As Double, height As Double, cartesianX As Double, cartesianY As Double, Optional pixelsPerX As Double = 1, Optional pixelsPerY As Double = 1) As PointF
        Dim ret As New PointF((-center.X + width.ToSingle / 2) * pixelsPerX.ToSingle,
                              (center.Y + height.ToSingle / 2) * pixelsPerY.ToSingle)
        ' transformation to apply to cartesian equation to convert to gdi
        ' if an item is left of the center point in the cartesian diagram,
        ' it needs to be left of the center point in the screen
        ' ret stores the x,y transformation that needs to be applied to the point for it to be relative to the top left point of the bounds given
        ' centered around (center), with width and height

        ' however, we also need to take into account the pixelsPerX factor. this effectively changes the width/height of the bounds given
        ' but the point is still in 

        ' basically, we get the distance from top left to the point on cartesian (incl. pixel adjustment), then clamp the values to the renderWidth

        ret.X += cartesianX.ToSingle
        ret.X /= pixelsPerX.ToSingle
        ret.Y -= cartesianY.ToSingle
        ret.Y /= pixelsPerY.ToSingle
        Return ret
    End Function



    Public Shared Function GdiToCartesian(center As PointF, width As Double, height As Double, location As PointF) As PointF
        Throw New Exception("TODO")
    End Function

    Public Shared Function Transform(point As PointF, x As Single, y As Single) As PointF
#Disable Warning BC42016 ' Implicit conversion  
        point.X += x
        point.Y += y
#Enable Warning BC42016 ' Implicit conversion
        Return point
    End Function

    ''' <summary>
    ''' Transforms a point by x and y amount
    ''' </summary>
    ''' <param name="point"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <returns></returns>
    Public Shared Function Transform(point As Vector3, x As Double, y As Double) As Vector3
        point.X += x
        point.Y += y
        Return point
    End Function

    ''' <summary>
    ''' Transforms a vector by offset amount
    ''' </summary>
    ''' <param name="point"></param>
    ''' <param name="offset"></param>
    ''' <returns></returns>
    Public Shared Function Transform(point As Vector3, offset As Vector3) As Vector3
        Return Transform(point, offset.X, offset.Y)
    End Function
End Class
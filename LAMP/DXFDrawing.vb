Imports System.IO
Imports IxMilia.Dxf
Imports IxMilia.Dxf.Entities


Public Class DxfDrawing
    Private _dxfFile As DxfFile

    ''' <summary>
    ''' Creates a new DxfDrawing, reading from a file given in filePath
    ''' </summary>
    ''' <param name="filePath">Filepath of file to read</param>
    Sub New(filePath As String)
        Using fs = New FileStream(filePath, FileMode.Open)
            _dxfFile = DxfFile.Load(fs)
        End Using
    End Sub

    ''' <summary>
    ''' Creates a new, empty DxfDrawing
    ''' </summary>
    Sub New()
        _dxfFile = New DxfFile()
        
    End Sub

   ''' <summary>
   ''' Saves the file
   ''' </summary>
   ''' <param name="filepath"></param>
    Public Sub Save(filepath As String)
       Using fs=New FileStream(filepath, FileMode.Create)
           _dxfFile.Save(fs)
       End Using
    End Sub


    Public Sub AddLine(x1 as Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        _dxfFile.Entities.Add(New DxfLine(ConvertPoint(x1, y1), ConvertPoint(x2, y2)))
    End Sub

    Public Sub AddLine(point1 As Point, point2 As Point)
        AddLine(point1.X, point1.Y, point2.x, point2.y)
    End Sub

    Public Sub AddCircle(centerX As integer, centerY as integer, radius As Double)
        _dxfFile.Entities.Add(New DxfCircle(ConvertPoint(centerX, centerY), radius))
    End Sub

    Public Sub AddCircle(centre As Point, radius As Double)
        AddCircle(centre.X, centre.Y, radius)
    End Sub

    Public Sub AddPolyline(ParamArray points() As Point)
        AddPolyline(points)
    End Sub

    Public Sub AddPolyline(points As IEnumerable(Of Point))
        dim list as New List(Of DxfPoint)
        For each item in points
            list.Add(ConvertPoint(item))
        Next
        _dxfFile.Entities.Add(New DxfPolyLine(list))
    End Sub

    Public Sub AddArc(centerX As integer, centerY as integer, radius as Double, startAngle as double, endAngle As double)
        _dxfFile.Entities.Add(New DxfArc(ConvertPoint(centerX, centerY), radius, startAngle, endAngle))
    End Sub

    

    




    Private Function ConvertPoint(point As Point) As DxfPoint
        Return New DxfPoint(point.X, point.Y, 0)
    End Function

    Private Function ConvertPoint(x As Integer, y as integer) As DxfPoint
        Return New DxfPoint(x, y, 0)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("DxfDrawing: {0}", _dxfFile)
    End Function

    Public Iterator Function GetAll () As IEnumerable(Of DxfEntity)
        For each entity As DxfEntity In _dxfFile.Entities
            Yield entity
        Next
    End Function

   

    Public Function GetRawDxf() As DxfFile
        Return _dxfFile
    End Function 
End Class



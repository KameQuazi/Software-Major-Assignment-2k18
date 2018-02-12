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
   ''' Saves the file. If the filepath is specified when the DxfDrawing is created
   ''' saves it automatically at that location
   ''' </summary>
   ''' <param name="filepath"></param>
    Public Sub Save(filepath As String)
       Using fs=New FileStream(filepath, FileMode.Create)
           _dxfFile.Save(fs)
       End Using
    End Sub


    Public Sub AddLine(point1 As Point, point2 As Point)
        _dxfFile.Entities.Add(New DxfLine(ConvertPoint(point1), ConvertPoint(Point2)))       
    End Sub

    Public Sub AddCircle(centre As Point, radius As Double)
        _dxfFile.Entities.Add(New DxfCircle(ConvertPoint(centre), radius))
    End Sub



    Private Function ConvertPoint(point As Point) As DxfPoint
        Return New DxfPoint(point.X, point.Y, 0)
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



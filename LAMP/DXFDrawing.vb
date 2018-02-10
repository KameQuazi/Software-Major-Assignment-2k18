Imports System.IO
Imports IxMilia.Dxf
Imports IxMilia.Dxf.Entities


Public Class DxfDrawing
    Private _dxfFile As DxfFile
    Private _filePathLocation as String

    ''' <summary>
    ''' Creates a new DxfDrawing, reading from a file given in filePath
    ''' </summary>
    ''' <param name="filePath">Filepath of file to read</param>
    Sub New(filePath As String)
        Using fs = New FileStream(filePath, FileMode.Open)
            _dxfFile = DxfFile.Load(fs)
        End Using
        _filePathLocation= filePath
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
   ''' <param name="location"></param>
    Public Sub Save(Optional location As String = Nothing)
        If location Is Nothing
            if _filePathLocation Is Nothing
                Throw New FileNotFoundException("Must specify location paramter")
            Else
                _save(_filePathLocation)
            End If
        Else 
            ' save in location
            _save(location)
        End If
    End Sub
    
    ''' <summary>
    ''' Helper function to check for errors before saving.
    ''' Dont use from outside this file, use <see cref="Save"></see> instead
    ''' </summary>
    ''' <param name="filepath"></param>
    Private Sub _save(filepath As string)
        Using fs=New FileStream(FilePath, FileMode.Create)
            _dxfFile.Save(fs)
        End Using
    End Sub

    Public Sub AddLine(point1 As Point, point2 As Point)
        _dxfFile.Entities.Add(New DxfLine(ConvertPoint(point1), ConvertPoint(Point2)))       
    End Sub

    Private Function ConvertPoint(point As Point) As DxfPoint
        Return New DxfPoint(point.X, point.Y, 0)
    End Function
End Class



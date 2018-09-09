Imports System.Runtime.InteropServices
Imports AutoCAD

Public Class AcadWrapper
    Public Shared ExternalEditorPath = "S:\Programs\Autodesk\AutoCAD 2017\acad.exe"
    Public Shared Function OpenFile(fileFp As String)
        Dim newAcad As New Process()
        newAcad.StartInfo.Arguments = fileFp
        newAcad.StartInfo.FileName = ExternalEditorPath
        newAcad.Start()


        Return Nothing
    End Function
End Class

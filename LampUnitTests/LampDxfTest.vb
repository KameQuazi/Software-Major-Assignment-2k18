Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Drawing
Imports System.IO
Imports LampCommon.LampDxfHelper
Imports netDxf.Entities
Imports netDxf
Imports LampCommon


<TestClass()>
Public Class LampDxfTest
    <TestMethod()>
    Public Sub CartesianToGdiTest()
        Dim zero = New PointF(0, 0)
        ' test P(0, 0) with zero center
        AreEqual(CartesianToGdi(zero, 200, 200, 0, 0), New PointF(100, 100))
        ' test P(0, 0) with (100, 100) as center
        AreEqual(CartesianToGdi(New PointF(100, 100), 200, 200, 0, 0), New PointF(0, 200))
        ' test P(100, 100) with (100, 100)
        AreEqual(CartesianToGdi(New PointF(100, 100), 200, 200, 100, 100), New PointF(100, 100))
        ' test P(100, 100) with (0, 0)
        AreEqual(CartesianToGdi(zero, 200, 200, 100, 100), New PointF(200, 0))
        ' test P(0, 0) with (0, 0), but a much bigger screen (1000, 1000)
        AreEqual(CartesianToGdi(zero, 1000, 1000, 0, 0), New PointF(500, 500))
        ' test P(100, 100) with center (0, 0), but with a bigger screen (1000, 1000)
        AreEqual(CartesianToGdi(zero, 1000, 1000, 100, 100), New PointF(600, 400))

    End Sub



    <TestMethod()>
    Public Sub CompletedDrawingTest()
        Dim dxf As New LampDxfDocument
        dxf.AddLine(10, 10, 20, 0)
        dxf.AddLine(20, 10, 10, 10)
        dxf.Save("unshifted.dxf")
        dxf = dxf.ShiftToZero()
        dxf.Save("shifted.dxf")

        ' template.AddInsertionPoint(New LampDxfInsertLocation(New Vector3(0, 0, 0)))
        ' template.AddInsertionPoint(New LampDxfInsertLocation(New Vector3(30, 0, 0)))
        ' template.AddInsertionPoint(New LampDxfInsertLocation(New Vector3(60, 0, 0)))

        ' template.CompletedDrawing.Save("finished drawing.dxf")
        dxf = New LampDxfDocument
        dxf.AddLine(0, 0, 0, 10)
        AreEqual(0.0, dxf.Width)
        AreEqual(10.0, dxf.Height)
        dxf.AddLine(0, 0, 0, -10)
        AreEqual(0.0, dxf.Width)
        AreEqual(20.0, dxf.Height)
        dxf.AddLine(10, 0, -10, 0)
        AreEqual(20.0, dxf.Width)
        AreEqual(20.0, dxf.Height)
        dxf.AddLine(5, 5, -5, -5)
        AreEqual(20.0, dxf.Width)
        AreEqual(20.0, dxf.Height)
        dxf.AddLine(100, 100, 0, 0)
        AreEqual(110.0, dxf.Width)
        AreEqual(110.0, dxf.Height)
        dxf = New LampDxfDocument
        Dim l = New Line(New Vector3(0, 0, 0), New Vector3(1, 1, 0))
        l.Color = New AciColor(Color.Red)

        dxf.AddLine(l)

        dxf.ToImage().Save("test.png")

        Dim template As New LampTemplate(dxf)
        template.Save("template.spf")

    End Sub

    <TestMethod>
    Public Sub DrawLines()
        Dim dxf As New LampDxfDocument
        dxf.AddLine(0, 0, 10, 10)

    End Sub

End Class

Public Module DxfExtensions
    <System.Runtime.CompilerServices.Extension()>
    Public Function EntityEquals(line1 As Line, line2 As Line) As Boolean
        If line1.StartPoint = line2.StartPoint And line1.EndPoint = line2.EndPoint Then
            Return True
        End If
        Return False

    End Function
End Module

Imports System.Text
Imports LAMP
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports LAMP.LampMath
Imports System.Drawing
Imports System.IO
Imports netDxf

<TestClass()> Public Class LampDxfTest

    <TestMethod()> Public Sub CartesianToGdiTest()
        Dim zero = New PointF(0, 0)
        ' test P(0, 0) with zero center
        Assert.AreEqual(LampMath.CartesianToGdi(zero, 200, 200, 0, 0), New PointF(100, 100))
        ' test P(0, 0) with (100, 100) as center
        Assert.AreEqual(CartesianToGdi(New PointF(100, 100), 200, 200, 0, 0), New PointF(0, 200))
        ' test P(100, 100) with (100, 100)
        Assert.AreEqual(CartesianToGdi(New PointF(100, 100), 200, 200, 100, 100), New PointF(100, 100))
        ' test P(100, 100) with (0, 0)
        Assert.AreEqual(CartesianToGdi(zero, 200, 200, 100, 100), New PointF(200, 0))
        ' test P(0, 0) with (0, 0), but a much bigger screen (1000, 1000)
        Assert.AreEqual(CartesianToGdi(zero, 1000, 1000, 0, 0), New PointF(500, 500))
        ' test P(100, 100) with center (0, 0), but with a bigger screen (1000, 1000)
        Assert.AreEqual(CartesianToGdi(zero, 1000, 1000, 100, 100), New PointF(600, 400))

    End Sub



    <TestMethod()>
    Public Sub CompletedDrawingTest()
        Dim dxf As New LampDxfDocument
        dxf.AddLine(0, 0, 10, 10)
        dxf.AddLine(10, 10, 20, 0)
        dxf.AddLine(20, 0, 0, 0)
        Dim template As New LampTemplate(dxf, New List(Of LampDxfInsertLocation))
        template.AddInsertionPoint(New LampDxfInsertLocation(New Vector3(0, 0, 0)))
        template.AddInsertionPoint(New LampDxfInsertLocation(New Vector3(30, 0, 0)))
        template.AddInsertionPoint(New LampDxfInsertLocation(New Vector3(60, 0, 0)))
        template.Save("template.spf")
        template.CompletedDrawing.Save("finished drawing.dxf")
    End Sub

End Class
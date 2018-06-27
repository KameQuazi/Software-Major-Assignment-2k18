Public Class refpointTest
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim test As New LampDxfDocument

        Dim randItem As New LampTemplate
        randItem.BaseDrawing = LampDxfDocument.FromFile("..\..\..\templates\ten.dxf")

        Dim point As New LampDxfInsertLocation(New netDxf.Vector3(0, 0, 0))
        randItem.Height = 193
        randItem.Length = 73

        Dim listPoint As New List(Of LampDxfInsertLocation)

        listPoint = test.GenRefPoint(randItem, 600, 400)
        For Each item In listPoint
            test.InsertInto(randItem.BaseDrawing, item)
        Next

        test.Save("reftest.dxf")
    End Sub
End Class
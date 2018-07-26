Imports System.Drawing.Imaging
Imports LampCommon.LampDxfHelper
Imports LampCommon
Imports netDxf
Imports netDxf.Entities

Public Class DesignerForm
    Private _drawing As LampDxfDocument

    Public Property Drawing As LampDxfDocument
        Get
            Return DesignerScreen1.Drawing
        End Get
        Set(value As LampDxfDocument)
            DesignerScreen1.Drawing = value
        End Set
    End Property

    Public Property [Readonly] As Boolean



    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OpenFileBtn.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Drawing = LampDxfDocument.FromFile(OpenFileDialog1.FileName)
            SaveFileBtn.Enabled = True

            FilenameTbox.Text = OpenFileDialog1.FileName
            DesignerScreen1.Drawing = Drawing
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles SaveFileBtn.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Drawing.Save(SaveFileDialog1.FileName)
        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' NOTE!!
        ' Exceptions in event handlers (form.load) suppress exceptions implicitly
        ' That means if any function raises an exception (e.g. inserting a duplicate item,
        ' since the GUID is a unique constraint, it will simply exit the function
        ' as if a return was placed there
        ' I've moved the stuff to the sub new underneath
        If Drawing IsNot Nothing Then
            jsonOutput.Text = Drawing.ToDxfString
        End If

    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True
    End Sub

    Sub New(Optional dxf As LampDxfDocument = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DesignerScreen1.Drawing = dxf


    End Sub


    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim z = TextBox1.Text.Split(" "c)
            Dim y = TextBox2.Text.Split(" "c)
            Drawing.AddLine(Double.Parse(z(0)), Double.Parse(z(1)), Double.Parse(y(0)), Double.Parse(y(1)))
            DesignerScreen1.Refresh()
        Catch ex As FormatException
            MessageBox.Show("The format is incorrect!")
        End Try
    End Sub



    ''' <summary>
    ''' super override the keydown
    ''' </summary>
    ''' <param name="message"></param>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    Protected Overrides Function ProcessCmdKey(ByRef message As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Down
                DesignerScreen1.Center = Transform(DesignerScreen1.Center, 0, -10)
                Return True
            Case Keys.Up
                DesignerScreen1.Center = Transform(DesignerScreen1.Center, 0, 10)
                Return True
            Case Keys.Left
                DesignerScreen1.Center = Transform(DesignerScreen1.Center, -10, 0)
                Return True
            Case Keys.Right
                DesignerScreen1.Center = Transform(DesignerScreen1.Center, 10, 0)
                Return True
        End Select
        Return MyBase.ProcessCmdKey(message, keyData)
    End Function

    Private Sub rightButton_Click(sender As Object, e As EventArgs) Handles rightButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, 10, 0)
    End Sub

    Private Sub downButton_Click(sender As Object, e As EventArgs) Handles downButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, 0, -10)
    End Sub

    Private Sub leftButton_Click(sender As Object, e As EventArgs) Handles leftButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, -10, 0)
    End Sub

    Private Sub upButton_Click(sender As Object, e As EventArgs) Handles upButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, 0, 10)
    End Sub

    Private Sub DesignerScreen1_Load(sender As Object, e As EventArgs) Handles DesignerScreen1.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If SaveFileDialog2.ShowDialog = DialogResult.OK Then
            Dim x As New LampTemplate(Drawing)
            x.Save(SaveFileDialog2.FileName)
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Dim zoom = TrackBar1.Value / 10
        ZoomLevelBox.Text = zoom.ToString
        DesignerScreen1.ZoomX = zoom
        DesignerScreen1.ZoomY = zoom
    End Sub

    Private Sub DesignerScreen1_MouseWheel(sender As Object, e As MouseEventArgs) Handles MyBase.MouseWheel
        Dim zoomDiff = e.Delta / 120 / 4
        If zoomDiff > 0 Then
            Dim newZoom = Math.Min(DesignerScreen1.ZoomX + zoomDiff, 3)
            TrackBar1.Value = Convert.ToInt32(newZoom * 10)
            ZoomLevelBox.Text = newZoom.ToString
            DesignerScreen1.ZoomX = newZoom
            DesignerScreen1.ZoomY = newZoom
        ElseIf zoomDiff < 0 Then
            Dim newZoom = Math.Max(DesignerScreen1.ZoomX + zoomDiff, 0.1)
            TrackBar1.Value = Convert.ToInt32(newZoom * 10)
            ZoomLevelBox.Text = newZoom.ToString
            DesignerScreen1.ZoomX = newZoom
            DesignerScreen1.ZoomY = newZoom
        End If
    End Sub

    Private Sub DuplicateButton_Click(sender As Object, e As EventArgs) Handles DuplicateButton.Click
        Dim input As New LampInputBox("enter location (x y) to insert", "enter a point [x y] without brackets")
        If input.ShowDialog = DialogResult.OK Then
            Try
                Dim output = input.InputText.Split(" "c)
                Dim x = Double.Parse(output(0))
                Dim y = Double.Parse(output(1))
                Drawing.InsertInto(Drawing, New LampDxfInsertLocation(New netDxf.Vector3(x, y, 0)))
            Catch ex As Exception
                MessageBox.Show("invalid input: reason {" + ex.ToString + "}")
            End Try
        End If
    End Sub

    Private Sub DesignerForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            ' revert the item being drawing right now

        End If

    End Sub

    Private Sub DesignerForm_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Console.WriteLine("hewww-wo?")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Dim firstPoint As Vector3

    Dim previousEntity As EntityObject
    Public Property CurrentTool As LampTool = LampTool.Circle

    Private currentState As DrawingState = DrawingState.None



    Private Sub DesignerScreen1_LocationMoved(sender As Object, e As MouseMoveAbsoluteEventArgs) Handles DesignerScreen1.MouseMoveAbsolute

        Select Case CurrentTool
            Case LampTool.Nothing
                If currentState = DrawingState.Start Then

                    If previousEntity IsNot Nothing Then
                        ' delete the previous line and add new line
                        Drawing.RemoveEntity(previousEntity)
                        previousEntity = Drawing.AddLine(firstPoint, e.Location)
                    Else
                        previousEntity = Drawing.AddLine(firstPoint, e.Location)
                    End If
                End If

            Case LampTool.Circle
                If currentState = DrawingState.Start Then
                    If previousEntity IsNot Nothing Then
                        Drawing.RemoveEntity(previousEntity)
                        previousEntity = Drawing.AddCircle(firstPoint, DistanceTwoPoints(firstPoint, e.Location))
                    Else
                        previousEntity = Drawing.AddCircle(firstPoint, DistanceTwoPoints(firstPoint, e.Location))
                    End If
                End If

        End Select

    End Sub

    Private Sub DesignerScreen1_LocationClicked(sender As Object, e As MouseClickAbsoluteEventArgs) Handles DesignerScreen1.MouseClickAbsolute
        If currentState = DrawingState.None Then
            firstPoint = e.Location
            currentState = DrawingState.Start
        ElseIf currentState = DrawingState.Start Then
            ' commit the line and firstpoint
            firstPoint = Nothing
            previousEntity = Nothing
            currentState = DrawingState.None
        End If
    End Sub
End Class


Public Enum LampTool
    [Nothing]
    Line
    Circle
    Arc

End Enum



Public Module owo1
    Public Function DistanceTwoPoints(first As Vector3, second As Vector3)
        Return Math.Sqrt((first.X - second.X) ^ 2 + (first.Y - second.Y) ^ 2)
    End Function
End Module

Public Enum DrawingState
    None = 0
    Start = 1

End Enum
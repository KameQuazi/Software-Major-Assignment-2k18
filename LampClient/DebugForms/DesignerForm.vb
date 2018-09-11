Imports System.Drawing.Imaging
Imports LampCommon.LampDxfHelper
Imports LampCommon
Imports netDxf
Imports netDxf.Entities
Imports System.Runtime.CompilerServices
Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class DesignerForm
    Private _drawing As LampDxfDocument

    <[ReadOnly](True), Browsable(False),
        EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Template As LampTemplate
        Get
            Return DesignerScreen1.Template
        End Get
        Set(value As LampTemplate)
            If value Is Nothing Then
                Throw New ArgumentNullException(NameOf(Template))
            End If
            DesignerScreen1.Template = value
        End Set
    End Property

    <[ReadOnly](True), Browsable(False),
        EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Drawing As LampDxfDocument
        Get
            Return DesignerScreen1.Drawing
        End Get
        Set(value As LampDxfDocument)
            DesignerScreen1.Drawing = value

        End Set
    End Property


    Public ReadOnly Property DynamicTextKeys As ObservableCollection(Of DynamicTextKey)
        Get
            Return Template?.DynamicTextList
        End Get
    End Property

    Public Property [Readonly] As Boolean

    Private _undoEntities As New Stack(Of EntityObject)
    Private ReadOnly Property UndoEntities As Stack(Of EntityObject)
        Get
            Return _undoEntities
        End Get

    End Property

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OpenFileBtn.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Drawing = LampDxfDocument.FromFile(OpenFileDialog1.FileName)
            Drawing = Drawing.ShiftToZero()
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
        If dxf IsNot Nothing Then
            DesignerScreen1.Drawing = dxf
        End If


    End Sub

    Private _myColor As Color
    Public Property MyColor As Color
        Get
            Return _myColor
        End Get
        Set(value As Color)
            _myColor = value

        End Set
    End Property

    Public Sub EnableOnlyDynamicText()
        Me.CurrentTool = LampTool.DynamicMText
        Me.currentState = DrawingState.None
        OpenFileBtn.Enabled = False
        SaveFileBtn.Enabled = False
        btnUndo.Enabled = False
        SaveFileBtn.Enabled = False
        cboxLine.Enabled = False
        cboxCircle.Enabled = False
        cboxMeasure.Enabled = False
        cboxStaticText.Enabled = False
        cboxDynamicText.Enabled = True
        cboxDynamicText.Checked = True
    End Sub


    Sub New(Optional template As LampTemplate = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If template IsNot Nothing Then
            Me.Template = template
        End If
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



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If SaveFileDialog2.ShowDialog = DialogResult.OK Then
            Dim x As New LampTemplate(Drawing)
            x.DynamicTextList.AddRange(DynamicTextKeys)
            x.Save(SaveFileDialog2.FileName)
        End If
    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        Dim zoom = TrackBar1.Value
        ' this is zoom percentage

        ZoomLevelBox.Text = zoom.ToString + "%"
        DesignerScreen1.ZoomX = zoom / 100
        DesignerScreen1.ZoomY = zoom / 100
    End Sub

    Private Sub DesignerScreen1_MouseWheel(sender As Object, e As MouseEventArgs) Handles MyBase.MouseWheel
        Dim zoomDiff = e.Delta / 120

        If zoomDiff > 0 Then
            Dim zoomPercent = Math.Min((DesignerScreen1.ZoomX + zoomDiff) * 100, 1000)
            TrackBar1.Value = Convert.ToInt32(zoomPercent)

        ElseIf zoomDiff < 0 Then
            Dim zoomPercent = Math.Max((DesignerScreen1.ZoomX + zoomDiff) * 100, 10)
            TrackBar1.Value = Convert.ToInt32(zoomPercent)
        End If
    End Sub

    Private Sub DuplicateButton_Click(sender As Object, e As EventArgs)
        Dim input As New LampInputBox("enter location (x y) to insert", "enter a point [x y] without brackets")
        If input.ShowDialog = DialogResult.OK Then
            Try
                Dim output = input.InputText.Split(" "c)
                Dim x = Double.Parse(output(0))
                Dim y = Double.Parse(output(1))
                Drawing.InsertInto(Drawing, New LampSingleDxfInsertLocation(New netDxf.Vector3(x, y, 0)))
            Catch ex As Exception
                MessageBox.Show("invalid input: reason {" + ex.ToString + "}")
            End Try
        End If
    End Sub


    Private Sub DesignerForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                ' revert the item being drawing right now
                If currentState <> DrawingState.None Then
                    RevertDraw()
                End If
            Case Keys.Enter
                If currentState <> DrawingState.None Then
                    EnterPressed()
                End If



        End Select

        If currentState = DrawingState.InTextMode Or currentState = DrawingState.AskingTextHeight Then
            Dim character = "" + ChrW(e.KeyValue)

            If My.Computer.Keyboard.ShiftKeyDown Then
                character = character.ToUpper()
            Else
                character = character.ToLower()
            End If

            If Char.IsLetterOrDigit(character) Or Char.IsSymbol(character) Then
                textbuff += character
            ElseIf e.KeyCode = Keys.Back Then
                textbuff = textbuff.TrimFinalCharacter()
            ElseIf e.KeyCode = Keys.OemPeriod Then
                textbuff += "."
            End If

            SetCommand(String.Format(currentCmdText, textbuff))


        End If
        e.Handled = True

    End Sub



    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Dim firstPoint As Vector3

    Dim firstPreviousEntity As EntityObject
    Private textbuff As String = ""
    Dim parameterName As String = ""
    Public Property CurrentTool As LampTool = LampTool.Nothing

    Private textWidth As Double = 0
    Private textHeight As Double = 0

    Private currentState As DrawingState = DrawingState.None
    Private currentCmdText As String = ""

    Private Sub RevertDraw()
        Select Case CurrentTool
            Case LampTool.Measure, LampTool.Arc, LampTool.Circle, LampTool.Line
                If currentState = DrawingState.Uncommitted Then
                    Drawing.RemoveEntity(firstPreviousEntity)
                End If
            Case LampTool.DynamicMText
                Drawing.RemoveEntity(firstPreviousEntity)
                textWidth = 0
                textbuff = ""
                parameterName = ""

            Case Else
                MessageBox.Show("No cancel routine found for " + CurrentTool.ToString)


        End Select
        ResetVariables()
    End Sub

    Private Sub ResetVariables()
        firstPoint = Nothing
        firstPreviousEntity = Nothing
        currentState = DrawingState.None
        parameterName = ""
        textbuff = ""
        textWidth = 0
        textHeight = 0
        currentCmdText = ""
    End Sub

    Private Sub EnterPressed()
        Select Case CurrentTool
            Case LampTool.DynamicMText
                Select Case currentState
                    Case DrawingState.InTextMode
                        ' just entered in name
                        If textbuff.Count = 0 Then
                            SetError("name length cannot be zero")
                        ElseIf DynamicTextKeys.ContainsString(textbuff) Then
                            SetError("parameter name already exists in drawing")
                        Else
                            currentState = DrawingState.AskingTextHeight
                            currentCmdText = "Enter text Height: {0}"
                            parameterName = textbuff
                            SetCommand(String.Format(currentCmdText, ""))
                            textbuff = ""

                        End If

                    Case DrawingState.AskingTextHeight
                        If textbuff.Count = 0 Then
                            SetError("Height cannot be empty")
                        ElseIf Not Double.TryParse(textbuff, textHeight) Then
                            SetError("Text entered is not a decimal number")


                        Else
                            currentState = DrawingState.None


                            DynamicTextKeys.Add(New DynamicTextKey(parameterName, "", firstPoint, textHeight, textWidth))
                            Drawing.RemoveEntity(firstPreviousEntity)
                            Dim mtext = Drawing.AddMText(firstPoint, parameterName, textHeight, textWidth)

                            UndoEntities.Push(mtext)
                            ShownDynamicText.Add(mtext)
                            ResetVariables()

                        End If
                End Select
        End Select
    End Sub


    Private Sub DesignerScreen1_LocationClicked(sender As Object, e As MouseClickAbsoluteEventArgs) Handles DesignerScreen1.MouseClickAbsolute
        Select Case CurrentTool
            Case LampTool.Measure
                If currentState = DrawingState.Uncommitted Then
                    ' tell the user the distance
                    MessageBox.Show("Distance is " + DistanceTwoPoints(firstPoint, e.Location).ToString)
                    currentState = DrawingState.None
                    firstPoint = Nothing
                    Drawing.RemoveEntity(firstPreviousEntity)
                Else
                    ' startpoint
                    firstPoint = e.Location
                    firstPreviousEntity = Nothing
                    currentState = DrawingState.Uncommitted
                End If

            Case LampTool.DynamicMText
                Select Case currentState
                    Case DrawingState.None
                        ' specify top left 
                        firstPoint = e.Location
                        firstPreviousEntity = Nothing
                        currentState = DrawingState.Uncommitted
                    Case DrawingState.Uncommitted
                        ' specify width
                        If firstPoint.X > e.Location.X Then
                            SetError("Textwidth has to be > 0 ")
                        Else
                            textWidth = e.Location.X - firstPoint.X
                            currentState = DrawingState.InTextMode
                            currentCmdText = EnterText
                            SetCommand(String.Format(EnterText, ""))
                        End If



                End Select


            Case LampTool.Arc, LampTool.Circle, LampTool.Line
                If currentState = DrawingState.None Then
                    firstPoint = e.Location
                    currentState = DrawingState.Uncommitted

                Else
                    UndoEntities.Push(firstPreviousEntity)
                    firstPoint = Nothing
                    firstPreviousEntity = Nothing
                    currentState = DrawingState.None


                End If

        End Select

        TextBox1.Text = Drawing.Width
        TextBox2.Text = Drawing.Height

    End Sub


    Private Sub DesignerScreen1_LocationMoved(sender As Object, e As MouseMoveAbsoluteEventArgs) Handles DesignerScreen1.MouseMoveAbsolute

        Select Case CurrentTool
            Case LampTool.Nothing
                ' do nothing

            Case LampTool.Line
                If currentState = DrawingState.Uncommitted Then

                    If firstPreviousEntity IsNot Nothing Then
                        ' delete the previous line and add new line
                        Drawing.RemoveEntity(firstPreviousEntity)
                        firstPreviousEntity = Drawing.AddLine(firstPoint, e.Location)
                    Else
                        firstPreviousEntity = Drawing.AddLine(firstPoint, e.Location)
                    End If
                End If

            Case LampTool.Circle
                If currentState = DrawingState.Uncommitted Then
                    If firstPreviousEntity IsNot Nothing Then
                        Drawing.RemoveEntity(firstPreviousEntity)
                        firstPreviousEntity = Drawing.AddCircle(firstPoint, DistanceTwoPoints(firstPoint, e.Location))
                    Else
                        firstPreviousEntity = Drawing.AddCircle(firstPoint, DistanceTwoPoints(firstPoint, e.Location))
                    End If
                End If

            Case LampTool.Measure
                If currentState = DrawingState.Uncommitted Then
                    If firstPreviousEntity IsNot Nothing Then
                        Drawing.RemoveEntity(firstPreviousEntity)
                        firstPreviousEntity = Drawing.AddLine(firstPoint, e.Location)
                    Else
                        firstPreviousEntity = Drawing.AddLine(firstPoint, e.Location)
                    End If
                End If

            Case LampTool.DynamicMText
                Select Case currentState
                    Case DrawingState.None
                        SetCommand(String.Format(FirstCorner, e.Location.X, e.Location.Y))
                    Case DrawingState.Uncommitted
                        If firstPreviousEntity IsNot Nothing Then
                            Drawing.RemoveEntity(firstPreviousEntity)
                            firstPreviousEntity = Drawing.AddRectangle(firstPoint, e.Location)
                        Else
                            firstPreviousEntity = Drawing.AddRectangle(firstPoint, e.Location)
                        End If
                        SetCommand(String.Format(SecondCorner, e.Location.X, e.Location.Y))

                End Select





        End Select

    End Sub

    Private DynamicTextPrefix = "DyamicText"
    Private FirstCorner = "Specify First Corner: {0},{1} or tab for manual entry"
    Private SecondCorner = "Specify Second Corner: {0},{1} or tab for manual entry"
    Private EnterText = "Enter name: {0}"
    Private StartPoint As Vector3
    ' need to set doUpdate to prevent calls from overwriting each otehr
    Private doUpdate As Boolean = True



    Public Sub ResetDrawingState(Optional keep As CheckBox = Nothing)
        If currentState <> DrawingState.None Then
            RevertDraw()
        End If

        firstPoint = Nothing
        currentState = DrawingState.None
        CurrentTool = LampTool.Nothing

        Dim cboxes As New List(Of CheckBox) From {cboxCircle, cboxLine, cboxDynamicText, cboxStaticText, cboxMeasure}
        For Each box In cboxes
            If Not box.Equals(keep) Then
                box.Checked = False
            End If
        Next
    End Sub

    Private ShownDynamicText As New List(Of MText)

    Private Sub cboxDynamicText_CheckedChanged(sender As Object, e As EventArgs) Handles cboxDynamicText.CheckedChanged
        If doUpdate Then
            doUpdate = False
            ResetDrawingState(cboxDynamicText)
            If cboxDynamicText.Checked Then
                CurrentTool = LampTool.DynamicMText
            Else
                CurrentTool = LampTool.Nothing
            End If
        End If
        doUpdate = True
    End Sub

    Private Sub cboxStaticText_CheckedChanged(sender As Object, e As EventArgs) Handles cboxStaticText.CheckedChanged

        If doUpdate Then
            doUpdate = False
            ResetDrawingState(cboxStaticText)
            If cboxStaticText.Checked Then
                CurrentTool = LampTool.MText
            Else
                CurrentTool = LampTool.Nothing
            End If
        End If
        doUpdate = True
    End Sub

    Private Sub cboxLine_CheckedChanged(sender As Object, e As EventArgs) Handles cboxLine.CheckedChanged

        If doUpdate Then
            doUpdate = False
            ResetDrawingState(cboxLine)
            If cboxLine.Checked Then
                CurrentTool = LampTool.Line
            Else
                CurrentTool = LampTool.Nothing
            End If
        End If
        doUpdate = True
    End Sub

    Private Sub cboxMeasure_CheckedChanged(sender As Object, e As EventArgs) Handles cboxMeasure.CheckedChanged
        If doUpdate Then
            doUpdate = False
            ResetDrawingState(cboxMeasure)
            If cboxMeasure.Checked Then
                CurrentTool = LampTool.Measure
            Else
                CurrentTool = LampTool.Nothing
            End If
            doUpdate = True
        End If

    End Sub

    Private Sub cboxCircle_CheckedChanged(sender As Object, e As EventArgs) Handles cboxCircle.CheckedChanged
        If doUpdate Then
            doUpdate = False
            ResetDrawingState(cboxCircle)
            If cboxCircle.Checked Then
                CurrentTool = LampTool.Circle
            Else
                CurrentTool = LampTool.Nothing
            End If
            doUpdate = True
        End If

    End Sub



    Private Sub rtboxCurrent_TextChanged(sender As Object, e As EventArgs) Handles rtboxCurrent.TextChanged

    End Sub

    Private Sub rtboxPrevious_TextChanged(sender As Object, e As EventArgs) Handles rtboxPrevious.TextChanged
        rtboxPrevious.ScrollToCaret()
    End Sub

    Private Sub AddCommand(command As String)
        If rtboxCurrent.Text <> String.Empty Then
            AddMessage(rtboxCurrent.Text)
            rtboxCurrent.Text = ""
        End If

        rtboxCurrent.Text = command
    End Sub

    Private Sub AddMessage(message As String)
        rtboxPrevious.AppendText(message)
    End Sub

    Private Sub SetCommand(command As String)
        rtboxCurrent.Text = command
    End Sub


    Private Sub SetError([error] As String)
        AddMessage([error] + Environment.NewLine)
    End Sub




    Private Sub rtboxCurrent_KeyDown(sender As Object, e As KeyEventArgs) Handles rtboxCurrent.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            AddMessage(rtboxCurrent.Text + Environment.NewLine)
            rtboxCurrent.Text = ""
        End If
    End Sub


    Private Sub DesignerScreen1_KeyDown(sender As Object, e As KeyEventArgs) Handles DesignerScreen1.KeyDown
        ' bubble the event
        OnKeyDown(e)
    End Sub

    Private Sub DesignerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If currentState <> DrawingState.None Then
            RevertDraw()
        End If
        For Each item In ShownDynamicText
            Drawing.RemoveEntity(item)
        Next

    End Sub

    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        Drawing.RemoveEntity(UndoEntities.Pop)
    End Sub

    Private Sub CutSelectorControl1_Load(sender As Object, e As EventArgs) Handles CutSelectorControl1.Load

    End Sub

    Private Sub CutSelectorControl1_Changed(sender As Object, e As Color) Handles CutSelectorControl1.Changed
        MyColor = e
    End Sub
End Class


Public Enum LampTool
    [Nothing]
    Line
    Circle
    Arc
    Measure
    MText
    DynamicMText
End Enum


Public Enum DrawingState
    None = 0
    Uncommitted = 1
    InTextMode = 2
    AskingTextHeight = 3
End Enum


Imports System.ComponentModel
Imports LampCommon

Public Class TemplateCreatorControl
    Public Shared ReadOnly Property DefaultMaterials As New List(Of String)

#Region "Properties"

    Private _optionsControl As Control
    Public Property OptionsControl As Control
        Get
            Return _optionsControl
        End Get
        Set(value As Control)
            If _optionsControl IsNot Nothing Then
                gboxOptions.Controls.Remove(_optionsControl)
            End If

            If value IsNot Nothing Then
                If value.GetType().GetProperty("ReadOnly") IsNot Nothing Then
                    DirectCast(value, Object).Readonly = Me.ReadOnly
                End If
            End If

            _optionsControl = value

            gboxOptions.Controls.Add(_optionsControl)
        End Set
    End Property


    Private _readonly As Boolean
    Public Property [ReadOnly] As Boolean
        Get
            Return _readonly
        End Get

        Set(value As Boolean)
            _readonly = value
            UpdateReadonlyElements()
        End Set
    End Property

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)

        UpdateEnabledElements()
    End Sub

    Private _template As LampTemplate = New LampTemplate

    ''' <summary>
    ''' Determines the template 
    ''' </summary>
    ''' <returns></returns>
    <[ReadOnly](True), Browsable(False),
        EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Template As LampTemplate
        Get
            Return _template
        End Get
        Set(value As LampTemplate)
            _template = value
            AddHandler _template.PropertyChanged, AddressOf Template_PropertyChanged
            UpdateAllFromTempate()

        End Set
    End Property




#End Region

    ''' <summary>
    ''' sets the enabled properties for any parts that need to be updated
    ''' 
    ''' </summary>
    Private Sub UpdateEnabledElements()
        gboxPrimary.Enabled = Me.Enabled
        gboxSecondary.Enabled = Me.Enabled
        gboxTags.Enabled = Me.Enabled
        gboxOptions.Enabled = Me.Enabled

        UpdateReadonlyElements()
    End Sub

    Private Sub UpdateReadonlyElements()
        NameBox.ReadOnly = Me.ReadOnly
        ComboBoxMaterial.Enabled = Not Me.ReadOnly
        ShortDescription.ReadOnly = Me.ReadOnly
        LongDescription.ReadOnly = Me.ReadOnly
        TboxThickness.ReadOnly = Me.ReadOnly
        DxfViewerControl1.Readonly = Me.ReadOnly
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' attach handler
        AddBubblingEvent(Me.Controls)

        ' add default
        DefaultMaterials.ForEach(Sub(item As String) ComboBoxMaterial.Items.Add(item))
        If ComboBoxMaterial.Items.Count > 0 Then
            ComboBoxMaterial.SelectedIndex = 0
        End If
        TboxApprove.Enabled = False
        gboxOptions.Controls.Clear()
    End Sub

    ''' <summary>
    ''' Recusively add click handler -> 
    ''' </summary>
    ''' <param name="controls"></param>
    Private Sub AddBubblingEvent(controls As ICollection)

        For Each control As Control In controls
            AddHandler control.KeyDown, AddressOf RaiseKeyDownEvent
            AddBubblingEvent(control.Controls)
        Next
    End Sub

    Private Sub RaiseKeyDownEvent(sender As Object, e As KeyEventArgs)
        OnKeyDown(e)
    End Sub


    Private Sub UpdateAllFromTempate()
        UpdateTextFromTemplate()
        UpdateViewerImages()
        UpdateTagsFromTemplate()
        UpdateDxfFromTemplate()
        UpdateDynFromTemplate()
        UpdateApproval()
    End Sub

    Private Sub UpdateApproval()
        If Template.Approved Then
            TboxApprove.Text = String.Format("Yes, Approver: {0}", Template.ApproverProfile.Username)
        Else
            TboxApprove.Text = "No"
        End If

    End Sub



    Private Sub Template_PropertyChanged(sender As Object, args As PropertyChangedEventArgs)

        Dim template As LampTemplate = DirectCast(sender, LampTemplate)
        Select Case args.PropertyName
            Case NameOf(LampTemplate.Tags)
                UpdateTagsFromTemplate()
            Case NameOf(LampTemplate.PreviewImages)
                UpdateViewerImages()
            Case NameOf(LampTemplate.BaseDrawing)
                UpdateDxfFromTemplate()
            Case NameOf(LampTemplate.DynamicTextList)
                UpdateDynFromTemplate()
            Case NameOf(LampTemplate.Name)
                NameBox.Text = template.Name
            Case NameOf(LampTemplate.ShortDescription)
                Dim i = ShortDescription.SelectionStart
                ShortDescription.Text = template.ShortDescription
                ShortDescription.SelectionStart = i
            Case NameOf(LampTemplate.LongDescription)
                Dim i = LongDescription.SelectionStart
                LongDescription.Text = template.LongDescription
                LongDescription.SelectionStart = i

            Case NameOf(LampTemplate.GUID)
                ' Do nothing
            Case NameOf(LampTemplate.MaterialThickness)
                If ValidateThickness() Then
                    ' check if the thickness has actually changed
                    If Double.Parse(TboxThickness.Text) <> template.MaterialThickness Then
                        TboxThickness.Text = template.MaterialThickness
                    Else
                        ' do nothing
                    End If
                Else
                    TboxThickness.Text = template.MaterialThickness
                End If

            Case NameOf(LampTemplate.Material)
                ComboBoxMaterial.Text = template.Material
            Case NameOf(LampTemplate.Approved)
                UpdateApproval()
            Case NameOf(LampTemplate.Width)
            Case NameOf(LampTemplate.Height)

#If DEBUG Then
            Case Else
                Throw New ArgumentOutOfRangeException(args.PropertyName)
#End If
        End Select

    End Sub

    Private updatingFromTemplate = False
    ''' <summary>
    ''' Updates tag from the template
    ''' </summary>
    Private Sub UpdateTagsFromTemplate()
        If updatingFromControl Then
            Return
        End If

        updatingFromTemplate = True
        TagEditorControl1.Tags.Clear()
        TagEditorControl1.Tags.AddRange(Me.Template.Tags)
        updatingFromTemplate = False
    End Sub

    Private Sub UpdateDynFromTemplate()
        DynamicFormCreation1.Source.Clear()
        DynamicFormCreation1.Source.AddRange(Template.DynamicTextList)
    End Sub

    Private Sub UpdateTextFromTemplate()
        NameBox.Text = Template.Name
        ShortDescription.Text = Template.ShortDescription
        LongDescription.Text = Template.LongDescription
        ComboBoxMaterial.Text = Template.Material
        TboxThickness.Text = Template.MaterialThickness
        UpdateApproval()
    End Sub


    Private Sub UpdateDxfFromTemplate()
        DxfViewerControl1.Template = Template
    End Sub

    Private Sub UpdateTemplateFromDxf()
        Template = DxfViewerControl1.Template
    End Sub

    ''' <summary>
    ''' Updates the PictureBoxes in the form with the internal image array
    ''' </summary>
    Private Sub UpdateViewerImages()
        Preview1.Image = Template.PreviewImages(0)
        Preview2.Image = Template.PreviewImages(1)
        Preview3.Image = Template.PreviewImages(2)
    End Sub





    Private Sub DxfViewerControl1_Click(sender As Object, e As EventArgs) Handles DxfViewerControl1.Click

        Using viewer As New DesignerForm(DxfViewerControl1.Drawing) With {.Readonly = Me.ReadOnly}
            If viewer.ShowDialog() = DialogResult.OK Then
                Me.Template = viewer.Template
                Me.Template.BaseDrawing = Me.Template.BaseDrawing.ShiftToZero
            End If
        End Using
    End Sub


    Private Sub Preview1_Click(sender As Object, e As EventArgs) Handles Preview1.Click
        If Not [ReadOnly] Then
            Try
                If ImageFileDialog.ShowDialog = DialogResult.OK Then
                    Template.PreviewImages(0) = Image.FromFile(ImageFileDialog.FileName)
                End If
            Catch ex As Exception
                If MessageBox.Show("Image is invalid. Show detailed error message?", "File Invalid", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    MessageBox.Show(ex.ToString)
                End If
            End Try
        End If
    End Sub

    Private Sub Preview2_Click(sender As Object, e As EventArgs) Handles Preview2.Click
        If Not [ReadOnly] Then
            Try
                If ImageFileDialog.ShowDialog = DialogResult.OK Then
                    Template.PreviewImages(1) = Image.FromFile(ImageFileDialog.FileName)
                End If
            Catch ex As Exception
                If MessageBox.Show("Image is invalid. Show detailed error message?", "File Invalid", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    MessageBox.Show(ex.ToString)
                End If
            End Try
        End If
    End Sub

    Private Sub Preview3_Click(sender As Object, e As EventArgs) Handles Preview3.Click
        If Not [ReadOnly] Then
            Try
                If ImageFileDialog.ShowDialog = DialogResult.OK Then

                    Template.PreviewImages(2) = Image.FromFile(ImageFileDialog.FileName)

                End If
            Catch ex As Exception
                If MessageBox.Show("Image is invalid. Show detailed error message?", "File Invalid", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    MessageBox.Show(ex.ToString)
                End If
            End Try
        End If
    End Sub



    Private Sub AddTemplate_Load(sender As Object, e As EventArgs)
        SyncLock DefaultMaterials
            For Each item In DefaultMaterials
                ComboBoxMaterial.Items.Add(item)
            Next
        End SyncLock

    End Sub















    Private Sub TemplateEditorForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            MessageBox.Show("Hewwo")
        End If
    End Sub


    Public Event SubmitSuccessful(sender As Object, e As SubmitEventArgs)

    Public Event EditSuccessful(sender As Object, e As SubmitEventArgs)

    Public Event DeleteSuccesful(sender As Object, e As SubmitEventArgs)

    Friend Sub RaiseSubmitSuccessful(sender As Object, e As SubmitEventArgs)
        RaiseEvent SubmitSuccessful(Me, e)
    End Sub

    Friend Sub RaiseEditSuccessful(sender As Object, e As SubmitEventArgs)
        RaiseEvent EditSuccessful(Me, e)
    End Sub

    Friend Sub RaiseDeleteSuccessful(sender As Object, e As SubmitEventArgs)
        RaiseEvent DeleteSuccesful(Me, e)
    End Sub



    Private Async Sub btnSubmitTemplate_Click(sender As Object, e As EventArgs)
        If Not CheckPossibleErrors() Then
            Return
        End If

        'TODO FIX wasd
        'If SubmitType = SendType.Add Then
        '    Dim response = Await CurrentSender.AddUnapprovedTemplateAsync(CurrentUser.ToCredentials, Template)
        '    Select Case response
        '        Case LampStatus.OK
        '            MessageBox.Show("Submitted Successfully")

        '            RaiseEvent SubmitSuccessful(Me, New SubmitEventArgs(Template))


        '        Case LampStatus.InvalidUsernameOrPassword
        '            ShowLoginError(Me.ParentForm)
        '        Case Else
        '            ShowError(response)

        '    End Select


        'ElseIf SubmitType = SendType.Edit Then
        '    Dim response = CurrentSender.EditTemplate(CurrentUser.ToCredentials, Template)
        '    Select Case response
        '        Case LampStatus.OK
        '            MessageBox.Show("Editted Successfully")

        '            RaiseEvent SubmitSuccessful(Me, New SubmitEventArgs(Template))


        '        Case LampStatus.InvalidUsernameOrPassword
        '            ShowLoginError(Me.ParentForm)

        '        Case Else
        '            ShowError(response)

        '    End Select



        'Else
        '    Throw New InvalidOperationException(NameOf(SubmitType))

        'End If


    End Sub

    Private Function CheckPossibleErrors() As Boolean
        If Not ValidateThickness() Then
            MessageBox.Show("Error: Thickness is in incorrect format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If Not ValidateName() Then
            MessageBox.Show("Error: Name is in incorrect format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If


        Dim showWarning As Boolean = False

        Dim warningText = "Possible Problems: "
        If Template.LongDescription.Length = 0 OrElse Template.ShortDescription.Length = 0 Then
            showWarning = True
            warningText += "\n- Description Empty"
        End If

        If showWarning Then
            warningText += "\nDo you want to continue?"
            warningText = warningText.Replace("\n", Environment.NewLine)
            Dim result = MessageBox.Show(warningText, "Warning", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Return False
            End If
        End If

        Return True
    End Function


    Private Sub TboxThickness_TextChanged(sender As Object, e As EventArgs) Handles TboxThickness.TextChanged
        If ValidateThickness() Then
            Template.MaterialThickness = Double.Parse(TboxThickness.Text)
        End If
    End Sub

    Private Function ValidateThickness() As Boolean
        Dim value As Double = -1
        Dim parsible = Double.TryParse(TboxThickness.Text, value)
        If Not parsible Then
            ErrorProviderThickness.SetError(TboxThickness, "Please enter an number")
            Return False
        ElseIf value <= 0 Then
            ErrorProviderThickness.SetError(TboxThickness, "Number must be greater than 0")
            Return False
        Else
            ErrorProviderThickness.SetError(TboxThickness, "")
            Return True
        End If

    End Function

    Private Function ValidateName() As Boolean
        Dim correct = NameBox.Text.Length > 0
        If correct Then
            ErrorProviderThickness.SetError(NameBox, "")
        Else
            ErrorProviderThickness.SetError(NameBox, "Name cannot be empty")
        End If
        Return correct
    End Function

    Private Sub NameBox_TextChanged(sender As Object, e As EventArgs) Handles NameBox.TextChanged
        Template.Name = NameBox.Text
        ValidateName()
    End Sub


    Private Sub ShortDescription_TextChanged(sender As Object, e As EventArgs) Handles ShortDescription.TextChanged
        Template.ShortDescription = ShortDescription.Text
    End Sub

    Private Sub LongDescription_TextChanged(sender As Object, e As EventArgs) Handles LongDescription.TextChanged
        Template.LongDescription = LongDescription.Text
    End Sub

    Private Sub ComboBoxMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxMaterial.SelectedIndexChanged, ComboBoxMaterial.TextChanged
        Template.Material = ComboBoxMaterial.Text
    End Sub




    Private Sub btnNewJob_Click(sender As Object, e As EventArgs)

        ' create a new job
        ' we need to push the current form (before this is opened as a dialog) => the toolbar previousform stack
        If Me.ParentForm.Owner IsNot Nothing Then
            ShowNewForm(Nothing, Me.ParentForm.Owner, New NewOrderFormChooseParameter() With {.SelectedTemplate = Me.Template})
        Else
            Dim x As New NewOrderFormChooseParameter() With {.SelectedTemplate = Me.Template}
            x.Show()
            Me.ParentForm.Close()
            MessageBox.Show("Warning: Cannot update history")
        End If

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        Using x As New DynamicTextCreationForm(Template)
            x.ShowDialog()
        End Using
    End Sub


    Public Property DrawingOpenProgram As OpenType
        Get
            Return My.Settings.DesignerProgram
        End Get
        Set(value As OpenType)
            My.Settings.DesignerProgram = value
            My.Settings.Save()
        End Set
    End Property

    Private Sub btnSetDrawing_Click(sender As Object, e As EventArgs) Handles btnSetDrawing.Click
        If DxfOpenDialog.ShowDialog = DialogResult.OK Then

            Me.CurrentFilename = DxfOpenDialog.FileName
            Dim loaded = LampDxfDocument.FromFile(CurrentFilename).ShiftToZero

            Template.DynamicTextList.Clear()
            If loaded.HasMText Then
                If MessageBox.Show("Found text in template file. Do you want to convert these one or more of these text to dynamic text?", "Found dynamic text", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                                   MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    Dim allText = New List(Of netDxf.Entities.MText)
                    For Each text As netDxf.Entities.MText In loaded.Drawing.MTexts

                        If MessageBox.Show(String.Format("Found text={0} at location=({1},{2})", text.PlainText, text.Position.X,
                                                         text.Position.Y), "Found text", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                            Dim dyn = New DynamicTextKey(text.PlainText, "", text.Position, text.Height, text.RectangleWidth, font:=text.Style.FontFamilyName)
                            Template.DynamicTextList.Add(dyn)
                            allText.Add(text)
                        End If


                    Next
                    For Each item In allText
                        Template.BaseDrawing.RemoveEntity(item)
                    Next
                End If

            End If
            Template.BaseDrawing = loaded
            ' also convert all text

        End If


    End Sub


    Private CurrentFilename As String = Nothing

    Private Sub AskForDrawingProgram()
        DrawingOpenProgram = New OpenType(False, "S:\Programs\Autodesk\AutoCAD 2017\acad.exe")
        ''  TODO
    End Sub

    Private Sub EditDrawingButton_Click(sender As Object, e As EventArgs)
        ' open with internal viewer
        If DrawingOpenProgram Is Nothing Then
            ' prompt user for 
            AskForDrawingProgram()
        End If
        If DrawingOpenProgram.Internal Then
            Using viewer As New DesignerForm(Me.Template) With {.Readonly = Me.ReadOnly}
                If viewer.ShowDialog() = DialogResult.OK Then
                    Me.Template = viewer.Template
                End If
            End Using
        Else
            Dim process As New Process
            process.StartInfo.FileName = DrawingOpenProgram.ProgramPath
            ' prompt use for file name and create empty dxf file
            If CurrentFilename Is Nothing Then
                If DxfSaveDialog.ShowDialog = DialogResult.OK Then
                    CurrentFilename = DxfSaveDialog.FileName
                    Me.Template.BaseDrawing.Save(CurrentFilename)
                End If

            End If

            process.StartInfo.Arguments = CurrentFilename
            Try
                process.Start()
            Catch ex As Exception
                MessageBox.Show("Cannot open program: " + ex.ToString)
            End Try
        End If
        ' else open with saved opentype
    End Sub

    Private updatingFromControl As Boolean = False
    Private Sub TagEditorControl1_TagContentsChanged(sender As Object, e As TagContentsChangedEvent) Handles TagEditorControl1.TagContentsChanged
        If updatingFromTemplate Then
            Return ' dont do anything if it is actually from updating . template
        End If
        updatingFromControl = True

        Me.Template.Tags.Clear()
        Me.Template.Tags.AddRange(TagEditorControl1.Tags)
        updatingFromControl = False
    End Sub

    Private Sub TagEditorControl1_Load(sender As Object, e As EventArgs)

    End Sub


    Private Sub TagsBox_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RemoveTag_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnGeneratePreview_Click(sender As Object, e As EventArgs) Handles btnGeneratePreview.Click
        If Not Me.Template.GeneratePreviewImages() Then
            MessageBox.Show("Could not generate preview image. Please ensure there is at least 1 entity in the drawing", "Preview Generation Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class

Public Class SubmitEventArgs
    Inherits EventArgs
    Public Property Template As LampTemplate
    Sub New(template As LampTemplate)
        MyBase.New()
        Me.Template = template
    End Sub

End Class
Imports System.ComponentModel
Imports LampCommon

Public Class TemplateCreatorControl
    Public Shared ReadOnly Property DefaultMaterials As New List(Of String)

#Region "Properties"


    Private _readonly As Boolean
    Public Property [ReadOnly] As Boolean
        Get
            Return _readonly
        End Get

        Set(value As Boolean)
            _readonly = value
            NameBox.ReadOnly = value
            ShortDescription.ReadOnly = value
            LongDescription.ReadOnly = value
            ComboBoxMaterial.Enabled = Not value

            TboxThickness.ReadOnly = value


            AddTag.Enabled = Not value
            ImportSpf.Enabled = Not value
            RemoveTag.Enabled = Not value



        End Set
    End Property

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)

        ImportSpf.Enabled = Me.Enabled
        ExportDxf.Enabled = Me.Enabled
        ExportSpf.Enabled = Me.Enabled
        btnViewDrawing.Enabled = Me.Enabled

        UpdateEnabledElements()
        If Not Me.Enabled Then
            Me.ReadOnly = True
            btnSubmitTemplate.Enabled = False
            btnNewJob.Enabled = False
        End If
    End Sub

    Private _template As LampTemplate

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

    Private _jobEnabled As Boolean = False
    Public Property JobEnabled As Boolean
        Get
            Return _jobEnabled
        End Get
        Set(value As Boolean)
            _jobEnabled = value
            btnNewJob.Enabled = value
        End Set
    End Property


    Public Sub SetSubmitType(opt As SendType)
        SubmitType = opt
        If opt <> SendType.None Then
            btnSubmitTemplate.Enabled = True
        Else
            btnSubmitTemplate.Enabled = False
        End If
    End Sub

    Public Property SubmitType As SendType



    Public Enum SendType
        None
        Add
        Edit
    End Enum


#End Region

    ''' <summary>
    ''' sets the enabled properties for any parts that need to be updated
    ''' 
    ''' </summary>
    Private Sub UpdateEnabledElements()
        SetSubmitType(SubmitType)
        TboxApprove.ReadOnly = True
        btnNewJob.Enabled = JobEnabled
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Template = New LampTemplate
        ' attach handler
        AddBubblingEvent(Me.Controls)

        ' add default
        DefaultMaterials.ForEach(Sub(item As String) ComboBoxMaterial.Items.Add(item))
        If ComboBoxMaterial.Items.Count > 0 Then
            ComboBoxMaterial.SelectedIndex = 0
        End If

        UpdateEnabledElements()
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
        UpdateApproval()
        DynamicFormCreation1.Template = Template
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

    ''' <summary>
    ''' Updates tag from the template
    ''' </summary>
    Private Sub UpdateTagsFromTemplate()
        TagsBox.Items.Clear()
        For Each item In Template.Tags
            TagsBox.Items.Add(NormalizeTags(item))
        Next
    End Sub

    Private Sub UpdateDynFromTemplate()
        ' TODO
        'Dynbox.Items.Clear()
        'For Each item In Template.DynamicTextList
        '    Dynbox.Items.Add(item.ParameterName)
        'Next
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



    Private Sub ExportDxf_Click(sender As Object, e As EventArgs) Handles ExportDxf.Click
        If DxfSaveDialog.ShowDialog = DialogResult.OK Then
            Template.BaseDrawing.Save(DxfSaveDialog.FileName)
        End If
    End Sub

    Private Sub ExportSpf_Click(sender As Object, e As EventArgs) Handles ExportSpf.Click
        If SpfSaveDialog.ShowDialog = DialogResult.OK Then
            Template.Save(SpfSaveDialog.FileName)
        End If
    End Sub

    Private Sub ImportSpf_Click(sender As Object, e As EventArgs) Handles ImportSpf.Click
        If SpfOpenDialog.ShowDialog() = DialogResult.OK Then
            Try
                Me.Template = LampTemplate.FromFile(SpfOpenDialog.FileName)
            Catch ex As Exception
                If MessageBox.Show("File is invalid. Show detailed error message?", "File Invalid", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    MessageBox.Show(ex.ToString)
                End If
            End Try

        End If
    End Sub



    Private Sub AddTag_Click(sender As Object, e As EventArgs) Handles AddTag.Click
        Dim dialog As New LampInputBox("New tag", "Enter new tag")
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim newTag = NormalizeTags(dialog.InputText)

            If Me.Template.Tags.Contains(newTag) Then
                ' dont allow duplicates
                MessageBox.Show("tags must be unique ")
            ElseIf newTag.Length > 16 Then
                MessageBox.Show("tag must be shorter or equal to 16 characters")
            ElseIf newTag.Length = 0 Then
                MessageBox.Show("tag not be empty")
            Else
                ' add them to the tags in the template
                Me.Template.Tags.Add(newTag)
                Me.Template.SortTags()
            End If
        End If
    End Sub


    Private Function NormalizeTags(text As String) As String
        Return New String(text.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray()).ToLower
    End Function

    Private Sub RemoveTagTags_Click(sender As Object, e As EventArgs) Handles RemoveTag.Click
        Dim selectedPosition = TagsBox.SelectedIndex
        If selectedPosition <> -1 Then
            ' an item is selected
            Dim selectedTag = NormalizeTags(TagsBox.SelectedItem.ToString)
            Me.Template.Tags.Remove(selectedTag)

        End If
    End Sub






    Private Sub TemplateEditorForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            MessageBox.Show("Hewwo")
        End If
    End Sub


    Public Event SubmitSuccessful(sender As Object, e As SubmitEventArgs)


    Private Async Sub btnSubmitTemplate_Click(sender As Object, e As EventArgs) Handles btnSubmitTemplate.Click
        If Not CheckPossibleErrors() Then
            Return
        End If

        If SubmitType = SendType.Add Then
            Dim response = Await CurrentSender.AddUnapprovedTemplateAsync(CurrentUser.ToCredentials, Template)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Submitted Successfully")

                    RaiseEvent SubmitSuccessful(Me, New SubmitEventArgs(Template))


                Case LampStatus.InvalidUsernameOrPassword
                    ShowLoginError(Me.ParentForm)
                Case Else
                    ShowError(response)

            End Select


        ElseIf SubmitType = SendType.Edit Then
            Dim response = CurrentSender.EditTemplate(CurrentUser.ToCredentials, Template)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Editted Successfully")

                    RaiseEvent SubmitSuccessful(Me, New SubmitEventArgs(Template))


                Case LampStatus.InvalidUsernameOrPassword
                    ShowLoginError(Me.ParentForm)

                Case Else
                    ShowError(response)

            End Select



        Else
            Throw New InvalidOperationException(NameOf(SubmitType))

        End If


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
            ErrorProviderThickness.SetError(TboxThickness, "Please Enter an number")
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




    Private Sub btnNewJob_Click(sender As Object, e As EventArgs) Handles btnNewJob.Click

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

    Private Sub DxfViewerControl1_MouseClickAbsolute(sender As Object, args As MouseClickAbsoluteEventArgs) Handles DxfViewerControl1.MouseClickAbsolute

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
        If DxfFileDialog.ShowDialog = DialogResult.OK Then
            Me.CurrentFilename = DxfFileDialog.FileName
            Dim loaded = LampDxfDocument.FromFile(CurrentFilename)
            Console.WriteLine(loaded.AllEntities)
            Template.BaseDrawing = loaded.ShiftToZero
        End If


    End Sub


    Private CurrentFilename As String = Nothing

    Private Sub AskForDrawingProgram()
        DrawingOpenProgram = New OpenType(False, "S:\Programs\Autodesk\AutoCAD 2017\acad.exe")
    End Sub

    Private Sub EditDrawingButton_Click(sender As Object, e As EventArgs) Handles btnViewDrawing.Click
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

End Class

Public Class SubmitEventArgs
    Inherits EventArgs
    Public Property Template As LampTemplate
    Sub New(template As LampTemplate)
        MyBase.New()
        Me.Template = template
    End Sub

End Class
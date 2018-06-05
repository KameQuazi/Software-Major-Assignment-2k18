Imports System.ComponentModel
Imports LampCommon

Public Class TemplateEditor
    ''' <summary>
    ''' Array of 3 images
    ''' </summary>
    Private ViewerImages(LampTemplate.MaxImages - 1) As Image

#Region "Properties"
    Private _template As LampTemplate

    ''' <summary>
    ''' Determines the template 
    ''' </summary>
    ''' <returns></returns>
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

    Private Sub UpdateAllFromTempate()
        UpdateTextFromTemplate()
        UpdateImagesFromTemplate()
        UpdateTagsFromTemplate()
        UpdateDxfFromTemplate()
    End Sub

    Private Sub UpdateTemplateFromAll()
        UpdateTemplateFromText()
        UpdateTemplateFromImages()
        UpdateTemplateFromImages()
        UpdateTemplateFromDxf()
    End Sub

    Private Sub Template_PropertyChanged(sender As Object, args As PropertyChangedEventArgs)

        If shouldUpdateViewer Then
            Dim template As LampTemplate = DirectCast(sender, LampTemplate)
            Select Case args.PropertyName
                Case NameOf(LampTemplate.Tags)
                    UpdateTagsFromTemplate()
                Case NameOf(LampTemplate.PreviewImages)
                    UpdateTemplateFromImages()
                Case NameOf(LampTemplate.BaseDrawing)
                    UpdateDxfFromTemplate()

                ' text
                Case NameOf(LampTemplate.Name)
                    NameBox.Text = template.Name
                Case NameOf(LampTemplate.ShortDescription)
                    ShortDescription.Text = template.ShortDescription
                Case NameOf(LampTemplate.LongDescription)
                    LongDescription.Text = template.LongDescription
                Case NameOf(LampTemplate.GUID)
                    GuidBox.Text = template.GUID


                Case Else
                    Throw New Exception()
            End Select
        End If

    End Sub
#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Template = LampTemplate.Empty
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

    ''' <summary>
    ''' updates template from tag
    ''' </summary>
    Private Sub UpdateTemplateFromTags()
        Template.Tags.Clear()
        For Each item In TagsBox.Items
            Template.Tags.Add(NormalizeTags(item.ToString))
        Next
    End Sub

    Private Sub UpdateTextFromTemplate()
        NameBox.Text = Template.Name
        ShortDescription.Text = Template.ShortDescription
        LongDescription.Text = Template.LongDescription
        GuidBox.Text = Template.GUID
    End Sub

    Private Sub UpdateTemplateFromText()
        SuspendViewerUpdate()
        Template.Name = NameBox.Text
        Template.ShortDescription = ShortDescription.Text
        Template.LongDescription = LongDescription.Text
        Template.GUID = GuidBox.Text
        ResumeViewerUpdate()
    End Sub


    ''' <summary>
    ''' Updates the images in the Template from the images
    ''' in the internal image array
    ''' </summary>
    Private Sub UpdateImagesFromTemplate()
        Array.Clear(ViewerImages, 0, ViewerImages.Count)

        For i = 0 To Template.PreviewImages.Count() - 1
            Dim image = Template.PreviewImages(i)
            ViewerImages(i) = image
        Next
        UpdateViewerImages()
    End Sub

    ''' <summary>
    ''' Updates the images in the Template from the images
    ''' in the internal image array
    ''' </summary>
    Private Sub UpdateTemplateFromImages()
        Me.SuspendViewerUpdate()
        Template.PreviewImages.ClearAsArray()

        For i = 0 To ViewerImages.Count() - 1
            Dim image = ViewerImages(i)
            Template.PreviewImages(i) = image
        Next


        ResumeViewerUpdate()
    End Sub

    Private shouldUpdateViewer As Boolean = True

    Public Sub SuspendViewerUpdate()
        shouldUpdateViewer = False
    End Sub

    Public Sub ResumeViewerUpdate(Optional doUpdate As Boolean = False)
        shouldUpdateViewer = True
        If doUpdate Then
            UpdateAllFromTempate()
        End If
    End Sub






    Private Sub UpdateDxfFromTemplate()
        DxfViewerControl1.Drawing = Template.BaseDrawing
    End Sub

    Private Sub UpdateTemplateFromDxf()
        Template.BaseDrawing = DxfViewerControl1.Drawing
    End Sub

    ''' <summary>
    ''' Updates the PictureBoxes in the form with the internal image array
    ''' </summary>
    Private Sub UpdateViewerImages()
        Preview1.Image = ViewerImages(0)
        Preview2.Image = ViewerImages(1)
        Preview3.Image = ViewerImages(2)
    End Sub


    Private Sub SelectDxf_Click(sender As Object, e As EventArgs) Handles SelectDxf.Click
        If DxfFileDialog.ShowDialog = DialogResult.OK Then
            Try
                Template.BaseDrawing = LampDxfDocument.FromFile(DxfFileDialog.FileName)
                DxfIndicator.Text = DxfFileDialog.FileName
            Catch ex As FormatException
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Preview1_Click(sender As Object, e As EventArgs) Handles Preview1.Click
        If ImageFileDialog.ShowDialog = DialogResult.OK Then
            ViewerImages(0) = Image.FromFile(ImageFileDialog.FileName)
            Preview1.Image = ViewerImages(0)
            UpdateTemplateFromImages()
        End If
    End Sub

    Private Sub Preview2_Click(sender As Object, e As EventArgs) Handles Preview2.Click
        If ImageFileDialog.ShowDialog = DialogResult.OK Then
            ViewerImages(1) = Image.FromFile(ImageFileDialog.FileName)
            Preview2.Image = ViewerImages(1)
            UpdateTemplateFromImages()
        End If
    End Sub

    Private Sub Preview3_Click(sender As Object, e As EventArgs) Handles Preview3.Click
        If ImageFileDialog.ShowDialog = DialogResult.OK Then
            ViewerImages(2) = Image.FromFile(ImageFileDialog.FileName)
            Preview3.Image = ViewerImages(2)
            UpdateTemplateFromImages()
        End If
    End Sub



    Private Sub AddTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AddToDb_Click(sender As Object, e As EventArgs) Handles AddToDb.Click
        CurrentSender.AddTemplate(Template, CurrentUser)
    End Sub

    Private Sub ExportDxf_Click(sender As Object, e As EventArgs) Handles ExportDxf.Click
        If DxfSaveDialog.ShowDialog = DialogResult.OK Then
            UpdateDxfFromTemplate()
            Template.BaseDrawing.Save(DxfSaveDialog.FileName)
        End If
    End Sub

    Private Sub ExportSpf_Click(sender As Object, e As EventArgs) Handles ExportSpf.Click
        If SpfSaveDialog.ShowDialog = DialogResult.OK Then
            UpdateTemplateFromText()
            Template.Save(SpfSaveDialog.FileName)
        End If
    End Sub

    Private Sub ImportSpf_Click(sender As Object, e As EventArgs) Handles ImportSpf.Click
        If SpfOpenDialog.ShowDialog() = DialogResult.OK Then
            Me.Template = LampTemplate.FromFile(SpfOpenDialog.FileName)
        End If
    End Sub

    Private Sub AddTag_Click(sender As Object, e As EventArgs) Handles AddTag.Click
        Dim dialog As New LampInputBox("New tag", "Enter new tag")
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim newTag = NormalizeTags(dialog.Value)

            If Me.Template.Tags.Contains(newTag) Then
                ' dont allow duplicates
                MessageBox.Show("tags must be unique ")
            Else
                ' add them to the tags in the template
                Me.Template.Tags.Add(newTag)
            End If
        End If
    End Sub

    Private Function NormalizeTags(text As String) As String
        Return New String(text.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray()).ToLower
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles RemoveTag.Click
        Dim selectedPosition = TagsBox.SelectedIndex
        If selectedPosition <> -1 Then
            ' an item is selected
            Dim selectedTag = NormalizeTags(TagsBox.SelectedItem.ToString)
            Me.Template.Tags.Remove(selectedTag)

        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles ShortDescription.TextChanged

    End Sub

    Private Sub LongDescription_TextChanged(sender As Object, e As EventArgs) Handles LongDescription.TextChanged

    End Sub

    Private Sub DxfViewerControl1_Load(sender As Object, e As EventArgs) Handles DxfViewerControl1.Load

    End Sub

    Private Sub DxfViewerControl1_Click(sender As Object, e As EventArgs) Handles DxfViewerControl1.Click
        Dim viewer As New DesignerForm(DxfViewerControl1.Drawing)
        viewer.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UpdateTemplateFromAll()
        MessageBox.Show("Saved to memory (to multitemplateviewer) ")
    End Sub

    Private Sub NewGuidButton_Click(sender As Object, e As EventArgs) Handles NewGuidButton.Click
        Template.GUID = GetNewGuid()
    End Sub
End Class
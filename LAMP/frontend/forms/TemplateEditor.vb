
Imports System.ComponentModel

Public Class TemplateEditor
    ''' <summary>
    ''' Array of 3 images
    ''' </summary>
    Private images(3) As Image

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
            UpdateViewer()
        End Set
    End Property

    Private Sub Template_PropertyChanged(sender As Object, args As PropertyChangedEventArgs)
        UpdateViewer()
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Template = LampTemplate.Empty
    End Sub

    ''' <summary>
    ''' Updates the viewer using the template in 
    ''' .Template
    ''' </summary>
    Private Sub UpdateViewer()
        UpdateInternalImages()

        UpdateText()

        UpdateTags()

        UpdateViewerImages()
    End Sub

    Private Sub UpdateTags()
        TagsBox.Items.Clear()
        For Each item In Template.Tags
            TagsBox.Items.Add(item)
        Next
    End Sub

    Private Sub UpdateText()
        If Template IsNot Nothing Then
            NameBox.Text = Template.Name
            DxfViewerControl1.Source = Template.BaseDrawing
        End If
    End Sub

    ''' <summary>
    ''' Updates the PictureBoxes in the form with the internal image array
    ''' </summary>
    Private Sub UpdateViewerImages()
        If Template IsNot Nothing Then
            Preview1.Image = images(0)
            Preview2.Image = images(1)
            Preview3.Image = images(2)
        End If
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
        UpdateViewer()
    End Sub

    Private Sub Preview1_Click(sender As Object, e As EventArgs) Handles Preview1.Click
        If ImageFileDialog.ShowDialog = DialogResult.OK Then
            images(0) = Image.FromFile(ImageFileDialog.FileName)
            Preview1.Image = images(0)
            UpdateTemplateImages()
        End If
    End Sub

    Private Sub Preview2_Click(sender As Object, e As EventArgs) Handles Preview2.Click
        If ImageFileDialog.ShowDialog = DialogResult.OK Then
            images(1) = Image.FromFile(ImageFileDialog.FileName)
            Preview2.Image = images(1)
            UpdateTemplateImages()
        End If
    End Sub

    Private Sub Preview3_Click(sender As Object, e As EventArgs) Handles Preview3.Click
        If ImageFileDialog.ShowDialog = DialogResult.OK Then
            images(2) = Image.FromFile(ImageFileDialog.FileName)
            Preview3.Image = images(2)
            UpdateTemplateImages()
        End If
    End Sub

    ''' <summary>
    ''' Updates the images in the Template from the images
    ''' in the internal image array
    ''' </summary>
    Private Sub UpdateTemplateImages()
        Template.PreviewImages.Clear()
        For Each image As Image In images
            If image IsNot Nothing Then
                Template.PreviewImages.Add(image)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Updates the array of images
    ''' from the Template
    ''' </summary>
    Private Sub UpdateInternalImages()
        If _template Is Nothing Then
            Return
        End If

        For i As Integer = 0 To 3
            images(i) = Nothing
            If _template.PreviewImages.Count > i Then
                images(i) = _template.PreviewImages(i)
            End If
        Next
    End Sub

    Private Sub AddTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AddToDb_Click(sender As Object, e As EventArgs) Handles AddToDb.Click
        Dim db As New TemplateDatabase()
        db.AddTemplate(Template)
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
            Me.Template = LampTemplate.FromFile(SpfOpenDialog.FileName)
        End If
    End Sub

    Private Sub AddTag_Click(sender As Object, e As EventArgs) Handles AddTag.Click
        Dim dialog As New LampInputBox("New tag", "Enter new tag")
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim newTag = dialog.InputText.ToLower()
            If Me.Template.Tags.Contains(newTag) Then
                ' dont allow duplicates
                MessageBox.Show("tags must be unique ")
            Else
                ' add them to the tags in the template
                Me.Template.Tags.Add(dialog.InputText)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles RemoveTag.Click
        Dim selectedPosition = TagsBox.SelectedIndex
        If selectedPosition <> -1 Then
            ' an item is selected
            Dim selectedTag = TagsBox.SelectedItem.ToString().ToLower()
            Me.Template.Tags.Remove(selectedTag)

        End If
    End Sub
End Class
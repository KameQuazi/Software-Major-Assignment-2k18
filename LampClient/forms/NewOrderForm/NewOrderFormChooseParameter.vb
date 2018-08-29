Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports LampCommon

Public Class NewOrderFormChooseParameter

    Private _selectedTemplate As LampTemplate
    Public Property SelectedTemplate As LampTemplate
        Get
            Return _selectedTemplate
        End Get
        Set(value As LampTemplate)
            _selectedTemplate = value
            UpdateContents()
        End Set
    End Property

    Public Property Items As New ObservableCollection(Of DynamicTextValueRow)


    Public ReadOnly Property Parameters As ObservableCollection(Of DynamicTextKey)
        Get
            Return SelectedTemplate?.DynamicTextList
        End Get
    End Property

    Private Sub UpdateContents()
        TemplateDisplay1.Template = SelectedTemplate
        UpdateColumnHeaders()
        UpdateRows()
    End Sub

    Private Sub UpdateRows()
        For Each row In Items
            DataGridView1.Rows.Add(row)
        Next
    End Sub

    Private Sub UpdateColumnHeaders()
        DataGridView1.Columns.Clear()


        If Parameters IsNot Nothing Then
            For Each item In Parameters
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = item.ParameterName})
            Next
        End If

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode

        End Select
    End Sub


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        UpdateContents()

    End Sub



    Private Sub DxfViewerControl1_Click(sender As Object, e As EventArgs)
        Using dialog As New TemplateSelectBox ' 
            If dialog.ShowDialog() = DialogResult.OK Then
                SelectedTemplate = dialog.SelectedTemplate
            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim job = New LampJob(Me.SelectedTemplate, CurrentUser.ToProfile, "hello summary")
        job.Pages = 3

        For i = 0 To 2
            job.AddInsertionPoint(New LampSingleDxfInsertLocation(New netDxf.Vector3(0, 0, 0)), i, True)

        Next


        Dim response = CurrentSender.AddJob(CurrentUser.ToCredentials, job)
        Select Case response
            Case LampStatus.OK
                MessageBox.Show("Successfully added job")
                ShowNewForm(Nothing, Me, HomeForm)
            Case Else
                ShowError(response)
        End Select
    End Sub

    Private Sub ServiceSortableTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TemplateDisplay1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Using dialog As New DynamicTextCreationForm(SelectedTemplate)
            dialog.ShowDialog()

        End Using
    End Sub

    Private _numberOfTemplates As Integer
    Private Property NumberOfTemplates As Integer
        Get
            Return _numberOfTemplates
        End Get
        Set(value As Integer)
            If value > _numberOfTemplates Then
                ' gotta add some empty templates
                For i = 1 To value - _numberOfTemplates
                    Items.Add(New DynamicTextValueRow())
                Next

            ElseIf value < _numberOfTemplates Then
                For i = _numberOfTemplates - 1 To value
                    Items.RemoveAt(i)
                Next
            End If
            _numberOfTemplates = value
            UpdateContents()
        End Set
    End Property


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        NumberOfTemplates += 1
    End Sub

    Private Sub btnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click
        NumberOfTemplates -= 1
    End Sub
End Class



Public Class DynamicTextValueRow
    Inherits ObservableCollection(Of DynamicTextValue)
End Class
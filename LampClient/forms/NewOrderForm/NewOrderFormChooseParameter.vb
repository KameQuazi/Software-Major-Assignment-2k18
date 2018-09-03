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
            UpdateFromItems()
        End Set
    End Property

    Public WithEvents Items As New ObservableCollection(Of DynamicTextValueRow)

    Private Sub HandleItemChanged(sender As Object, e As EventArgs) Handles Items.CollectionChanged
        If Items.Count = 0 Then
            btnNext.Enabled = False
        Else
            btnNext.Enabled = True
        End If
    End Sub



    Public ReadOnly Property Parameters As ObservableCollection(Of DynamicTextKey)
        Get
            Return SelectedTemplate?.DynamicTextList
        End Get
    End Property

    Private Sub UpdateFromItems()
        TemplateDisplay1.Template = SelectedTemplate
        tboxNumTemplates.Text = NumberOfTemplates.ToString
        UpdateColumnHeaders()
        UpdateRows()
    End Sub

    Dim doUpdateFromGrid As Boolean = True

    Private Sub UpdateRows()
        doUpdateFromGrid = False
        If DataGridView1.ColumnCount >= 1 Then

            For Each row In Items

                Dim rowIndex = DataGridView1.Rows.Add()

                ' row to insert
                For index = 0 To Parameters.Count - 1
                    Dim para = Parameters(index)
                    DataGridView1.Rows(rowIndex).Cells(para.ParameterName).Value = row(index).Value
                Next

            Next
        End If
        doUpdateFromGrid = True
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
        UpdateFromItems()

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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub TemplateDisplay1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        AddCopy()
    End Sub

    Private Sub AddCopy()
        If SelectedTemplate.DynamicTextList.Count > 0 Then

            Using dialog As New DynamicTextCreationForm(SelectedTemplate)
                If dialog.ShowDialog() = DialogResult.OK Then
                    Items.Add(dialog.DynamicTextValues)

                End If

            End Using
            UpdateFromItems()
        Else
            NumberOfTemplates += 1
        End If
    End Sub

    Private Property NumberOfTemplates As Integer
        Get
            Return Items.Count()
        End Get
        Set(value As Integer)
            Dim _numberOfTemplates = NumberOfTemplates
            If value > _numberOfTemplates Then
                ' gotta add some empty templates
                If Parameters.Count > 0 Then
                    Throw New Exception("Cannot add numbertemplates, add Items instead for templates with parameters")
                End If
                For i = 1 To value - _numberOfTemplates

                    Items.Add(New DynamicTextValueRow())
                Next

            ElseIf value < _numberOfTemplates Then
                For i = _numberOfTemplates - 1 To value
                    Items.RemoveAt(i)
                Next
            End If
            UpdateFromItems()
        End Set
    End Property


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddCopy()
    End Sub

    Private Sub btnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click
        If NumberOfTemplates >= 1 Then
            NumberOfTemplates -= 1
        End If

    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        SetItemFromDataGridView()
    End Sub

    Private Sub SetItemFromDataGridView()
        If doUpdateFromGrid Then
            Items.Clear()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim dRow As New DynamicTextValueRow
                    For Each p In Parameters
                        Dim parameterName = p.ParameterName
                        dRow.Add(New DynamicTextValue(row.Cells(p.ParameterName).Value))
                    Next
                    Items.Add(dRow)
                End If
            Next
            tboxNumTemplates.Text = NumberOfTemplates.ToString
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnDeletedSelected.Click
        Dim rows = DataGridView1.SelectedRows
        For Each owos As DataGridViewRow In rows
            If Not owos.IsNewRow Then
                DataGridView1.Rows.Remove(owos)
            End If
        Next
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            btnDeletedSelected.PerformClick()
        End If
    End Sub

    Private Sub btNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim newJob As New LampJob(SelectedTemplate)

        Dim x As New NewOrderFormExport(newJob)
        x.Show()
        Me.Close()

    End Sub

    Private Sub NewOrderFormChooseParameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class




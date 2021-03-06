﻿Imports System.Collections.ObjectModel
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

    Public WithEvents Items As New ObservableCollection(Of List(Of DynamicTextValue))

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
        If ValidateNumTemplates(New Integer) Then
            tboxNumTemplates.Text = NumberOfTemplates.ToString
        End If

        UpdateColumnHeaders()
        UpdateRows()
        If SelectedTemplate IsNot Nothing AndAlso SelectedTemplate.DynamicTextList.Count = 0 Then
            tboxNumTemplates.Enabled = True
        End If
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

                    Items.Add(New List(Of DynamicTextValue))
                Next

            ElseIf value < _numberOfTemplates Then
                For i = _numberOfTemplates - 1 To value Step -1
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
                    Dim dRow As New List(Of DynamicTextValue)
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
        newJob.SetCopies(Items.ToList())
        Dim x As New NewOrderFormExport(newJob)
        x.Show()
        Me.Close()

    End Sub

    Private Sub NewOrderFormChooseParameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub tboxNumTemplates_TextChanged(sender As Object, e As EventArgs) Handles tboxNumTemplates.TextChanged

        If SelectedTemplate Is Nothing Then
            ' do nothing
        ElseIf SelectedTemplate.DynamicTextList.Count = 0 Then
            Dim result As Integer = -1
            If ValidateNumTemplates(result) Then
                NumberOfTemplates = result
                ErrorProvider1.SetError(tboxNumTemplates, "")
            Else
                ErrorProvider1.SetError(tboxNumTemplates, "Please enter a valid integer")
                NumberOfTemplates = 0
            End If
        Else
            ' do nothing
        End If
    End Sub

    Private Function ValidateNumTemplates(ByRef result As Integer) As Boolean
        Return Integer.TryParse(tboxNumTemplates.Text, result)
    End Function
End Class




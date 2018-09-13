Imports System.ComponentModel
Imports LampCommon

Public Class DynamicTextCreationForm

    Private _source As LampTemplate
    Private newJob As LampJob


    Public Property Source As LampTemplate
        Get
            Return _source
        End Get
        Set(value As LampTemplate)
            _source = value
            If _source IsNot Nothing Then
                AddHandler _source.PropertyChanged, Sub(sender As Object, e As PropertyChangedEventArgs) UpdateDynamicText()
            End If
            UpdateDynamicText()
        End Set
    End Property

    Private Sub UpdateDynamicText()
        DynamicFormCreation1.Source.Clear()
        For Each item In Source.DynamicTextList
            DynamicFormCreation1.Source.Add(item)

        Next

        If DynamicFormCreation1.Source.Count() = 0 Then
            DynamicFormCreation1.Source.Add(New DynamicTextKey("No dynamic text in this template", "", Nothing, 0, 0))
            btnSubmit.Enabled = False
        Else
            btnSubmit.Enabled = True
        End If
    End Sub

    Sub New(Optional item As LampTemplate = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If item Is Nothing Then
            Source = LampTemplate.Empty
        Else
            Source = item
        End If

    End Sub

    Private Sub DynamicTextCreationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' newJob = New LampJob(Source, New LampProfile("", "", "", New UserPermission()))
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim singleDT As LampClient.SingleDynamicText


        For index As Integer = 0 To DynamicFormCreation1.FlowLayoutPanel1.Controls.Count - 1

            singleDT = DynamicFormCreation1.FlowLayoutPanel1.Controls.Item(index)
            For value As Integer = 0 To singleDT.GetValue.ToString.Split(",").Count
                ' ??
                'If newJob.DynamicTextDictionaries.Count < value + 1 Then
                '    newJob.DynamicTextDictionaries.Add(New DynamicTextDictionary)
                'End If
                'newJob.DynamicTextDictionaries(value).Add(Source.DynamicTextList.Item(value), New DynamicTextValue(singleDT.GetValue.ToString.Split(",").GetValue(value)))
            Next
        Next
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub DynamicFormCreation1_Load(sender As Object, e As EventArgs) Handles DynamicFormCreation1.Load

    End Sub

    Public ReadOnly Property DynamicTextValues As List(Of DynamicTextValue)
        Get
            Dim out As New List(Of DynamicTextValue)
            For Each item In DynamicFormCreation1.FlowLayoutPanel1.Controls
                Dim x As SingleDynamicText = item
                out.Add(New DynamicTextValue(x.GetValue().tolower()))
            Next
            Return out
        End Get

    End Property

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
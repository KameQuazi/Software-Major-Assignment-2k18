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
            DynamicFormCreation1.Source.Add(New DynamicTextKey("No parameters found", "No parameters are in this template", Nothing, InputType.None))
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
        newJob = New LampJob(Source, New LampProfile("", "", "", New UserPermission()))
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim singleDT As LampClient.SingleDynamicText


        For index As Integer = 0 To DynamicFormCreation1.FlowLayoutPanel1.Controls.Count

            singleDT = DynamicFormCreation1.FlowLayoutPanel1.Controls.Item(index)
            For value As Integer = 0 To singleDT.GetValue.ToString.Split(",").Count
                If newJob.DynamicTextDictionary.Count < value + 1 Then
                    newJob.DynamicTextDictionary.Add(New DynamicTextDictionary)
                End If
                newJob.DynamicTextDictionary(value).Add(Source.DynamicTextList.Item(value), New DynamicTextValue(singleDT.GetValue.ToString.Split(",").GetValue(value)))
            Next
        Next
    End Sub
End Class
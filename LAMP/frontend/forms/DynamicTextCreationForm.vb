Imports System.ComponentModel

Public Class DynamicTextCreationForm

    Private _source As LampTemplate
    Public Property Source As LampTemplate
        Get
            Return _source
        End Get
        Set(value As LampTemplate)
            _source = value
            AddHandler _source.PropertyChanged, Sub(sender As Object, e As PropertyChangedEventArgs) UpdateDynamicText()
            UpdateDynamicText()
        End Set
    End Property

    Private Sub UpdateDynamicText()
        DynamicFormCreation1.Source.Clear()
        For Each item In Source.DynamicTextList
            DynamicFormCreation1.Source.Add(item)
        Next
        If DynamicFormCreation1.Source.Count() = 0 Then
            DynamicFormCreation1.Source.Add(New DynamicTemplateInput("No parameters found", "No parameters are in this template", Nothing, InputType.None))
        End If
    End Sub


    Private Sub DynamicFormCreation1_Load(sender As Object, e As EventArgs) Handles DynamicFormCreation1.Load

    End Sub

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Source = LampTemplate.Empty
    End Sub


End Class
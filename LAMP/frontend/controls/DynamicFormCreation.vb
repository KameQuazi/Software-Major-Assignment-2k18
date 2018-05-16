Imports System.Collections.ObjectModel

Public Class DynamicFormCreation
    Private AllPanels As New List(Of Panel)

    Public Property Source As New ObservableCollection(Of DynamicText)

    Private Function MakePanel() As Panel
        Dim newPanel As New Panel
        Return newPanel
    End Function


    Protected Overrides Sub OnPaddingChanged(e As EventArgs)
        MyBase.OnPaddingChanged(e)

        UpdatePanels()
    End Sub

    Public Sub UpdatePanels()
        For Each panel In AllPanels
            Me.Controls.Remove(panel)
        Next
        Dim i = 0
        For Each dynText In Source
            Dim x As New Button()
            Me.Controls.Add(x)
            x.Height = i * 100
            i += 1
        Next
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim x As New Button()
        Me.Controls.Add(x)
        Source.Add(New DynamicText("1", Nothing))
        Source.Add(New DynamicText("2", Nothing))
        Source.Add(New DynamicText("3", Nothing))
        Source.Add(New DynamicText("4", Nothing))
        UpdatePanels()
    End Sub

    Private Sub DynamicFormCreation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

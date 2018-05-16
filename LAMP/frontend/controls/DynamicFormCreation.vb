Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Public Class DynamicFormCreation
    Private AllControls As New ObservableCollection(Of SingleDynamicText)

    Public ReadOnly Property Source As New ObservableCollection(Of DynamicText)


    Protected Overrides Sub OnPaddingChanged(e As EventArgs)
        MyBase.OnPaddingChanged(e)

        UpdatePanels()
    End Sub

    Public Sub UpdatePanels()
        For Each panel In AllControls
            Me.FlowLayoutPanel1.Controls.Remove(panel)
        Next
        AllControls.Clear()

        Dim i = 0
        For Each dynText In Source
            Dim newControl As New SingleDynamicText
            AllControls.Add(newControl)
            newControl.Width = Me.Width

            Me.FlowLayoutPanel1.Controls.Add(newControl)
            ' use SetChildIndex to set control's index if needed mayyybe
        Next
    End Sub

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler Source.CollectionChanged, Sub(sender As Object, args As NotifyCollectionChangedEventArgs) UpdatePanels()

    End Sub

    Private Sub DynamicFormCreation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class

Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports LampCommon

Public Class NewOrderFormExport
    Public Property Job As LampJob

    Public Sub New(Optional newJob As LampJob = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Job = newJob
        newJob.RefreshCompleteDrawing()
        UpdateContents()
    End Sub

    Private Sub UpdateContents()
        MultiDrawingViewerControl1.Drawings = Job.CompleteDrawings
        Job.RefreshCompleteDrawing()
    End Sub
End Class


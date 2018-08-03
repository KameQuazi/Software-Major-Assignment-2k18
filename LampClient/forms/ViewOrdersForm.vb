Imports LampCommon

Public Class ViewOrdersForm
    Private Sub ServiceSortableJobViewer1_AdvancedClick(sender As Object, e As LampJobEventArgs) Handles ServiceSortableJobViewer1.AdvancedClick
        Using viewer As New AdvancedJobForm With {.Job = e.Job}
            viewer.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ServiceSortableJobViewer1_ViewDrawingClick(sender As Object, e As LampJobEventArgs) Handles ServiceSortableJobViewer1.ViewDrawingClick
        Using viewer As New MultiDrawingViewer With {.Drawings = e.Job.CompleteDrawings}
            viewer.ShowDialog(Me)
        End Using
    End Sub
End Class
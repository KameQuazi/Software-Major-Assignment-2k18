Imports LampCommon

Public Class AdvancedJobViewer
    Private _job As LampJob
    Public Property Job As LampJob
        Get
            Return _job
        End Get
        Set(value As LampJob)
            _job = value
            UpdateContents()
        End Set
    End Property

    Private Sub UpdateContents()
        If Job IsNot Nothing Then
            tboxSubmitter.Text = Job.Submitter?.Username
            tboxApprover.Text = Job.Approver?.Username
            tboxSummary.Text = Job.Summary
            tboxPages.Text = Job.Pages
            dtPicker.Value = Job.SubmitDate
        End If
    End Sub

    Private Sub btnViewDrawing_Click(sender As Object, e As EventArgs) Handles btnViewDrawing.Click
        Using viewer As New MultiDrawingViewer With {.Drawings = Job.CompleteDrawings}
            viewer.ShowDialog(Me)
        End Using
    End Sub
End Class

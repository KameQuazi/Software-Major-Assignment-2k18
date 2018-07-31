Public Class ApproveJobForm
    Private Sub ServiceSortableJobViewer1_JobClick(sender As Object, e As JobClickedEventArgs) Handles ServiceSortableJobViewer1.JobClick
        If MessageBox.Show("Do you wish to approve this job?", "Approve", MessageBoxButtons.YesNo) Then

        End If
    End Sub
End Class
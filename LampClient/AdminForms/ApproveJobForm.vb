Imports LampCommon

Public Class ApproveJobForm


    Private Sub ApproveJob(job As LampJob)
        If MessageBox.Show("Do you wish to approve this job?", "Approve", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim response = CurrentSender.ApproveJob(CurrentUser.ToCredentials, job.JobId)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Approve Successful")
                    ServiceSortableJobViewer1.UpdateContents()
                Case Else
                    ShowError(response)
            End Select
        End If
    End Sub



    Private Sub ApproveJobForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AdminToolbar1.btnHome.Enabled = True
        AdminToolbar1.btnApproveTemplates.Enabled = True
        AdminToolbar1.btnApproveJob.Enabled = False
        AdminToolbar1.btnManageUsers.Enabled = True
    End Sub
End Class
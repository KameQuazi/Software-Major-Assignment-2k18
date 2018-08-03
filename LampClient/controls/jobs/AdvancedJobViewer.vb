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
            If Job.Approved Then
                btnApprove.Text = "Revoke"
            Else
                btnApprove.Text = "Approve"
            End If
        End If
    End Sub

    Private Sub btnViewDrawing_Click(sender As Object, e As EventArgs) Handles btnViewDrawing.Click
        Using viewer As New MultiDrawingViewer With {.Drawings = Job.CompleteDrawings}
            viewer.ShowDialog(Me)
        End Using
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If CurrentUser.PermissionLevel < UserPermission.Admin Then
            btnApprove.Enabled = False
        End If
    End Sub

    'approved if true, else revoke
    Public Event JobStatusChange(sender As Object, approved As Boolean)

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If Job.Approved Then
            Dim response = CurrentSender.RevokeJob(CurrentUser.ToCredentials, Job.JobId)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Revoke successful")
                    Job.Approver = Nothing
                    UpdateContents()
                    RaiseEvent JobStatusChange(Me, True)

                Case Else
                    ShowError(response)
            End Select
        Else
            Dim response = CurrentSender.ApproveJob(CurrentUser.ToCredentials, Job.JobId)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Approve successful")
                    Job.Approver = CurrentUser.ToProfile
                    UpdateContents()
                    RaiseEvent JobStatusChange(Me, False)
                Case Else
                    ShowError(response)
            End Select
        End If
    End Sub
End Class

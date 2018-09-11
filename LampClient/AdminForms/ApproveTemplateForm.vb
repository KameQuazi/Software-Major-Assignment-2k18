Imports LampCommon

Public Class ApproveTemplateForm
    Private Sub ServiceSortableTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs) Handles ServiceSortableTemplateViewer1.TemplateClick
        Using approve As New TemplateApproveBox() With {.Template = e.Template}
            If approve.ShowDialog() = DialogResult.OK Then
                ServiceSortableTemplateViewer1.UpdateContents()
            End If
        End Using
    End Sub

    Private Sub ApproveTemplateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServiceSortableTemplateViewer1.ApprovedType = LampApprove.Unapproved
        AdminToolbar1.btnHome.Enabled = True
        AdminToolbar1.btnApproveTemplates.Enabled = False
        AdminToolbar1.btnApproveJob.Enabled = True
        AdminToolbar1.btnManageUsers.Enabled = True
    End Sub
End Class
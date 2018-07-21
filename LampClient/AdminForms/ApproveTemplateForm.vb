Public Class ApproveTemplateForm
    Private Sub ServiceSortableTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs) Handles ServiceSortableTemplateViewer1.TemplateClick
        Using approve As New TemplateApproveBox() With {.Template = e.Template}
            If approve.ShowDialog() = DialogResult.OK Then

            End If
        End Using
    End Sub
End Class
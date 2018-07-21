Imports LampCommon

Public Class ViewEditTemplateForm


    Private Sub ServiceSortableTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs) Handles ServiceSortableTemplateViewer1.TemplateClick
        Using dialog As New EditTemplateDialog() With {.Template = e.Template}
            dialog.ShowDialog(Me)
            ServiceSortableTemplateViewer1.UpdateContents()
        End Using
    End Sub
End Class
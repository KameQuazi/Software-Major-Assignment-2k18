Imports LampCommon

Public Class ViewTemplatesForm
    Private Sub TableLayoutPanel1_MouseEnter(sender As Object, e As EventArgs) Handles TableLayoutPanel1.MouseEnter

    End Sub

    Private Sub TableLayoutPanel1_MouseLeave(sender As Object, e As EventArgs) Handles TableLayoutPanel1.MouseLeave

    End Sub

    Private Sub TableLayoutPanel1_MouseHover(sender As Object, e As EventArgs) Handles TableLayoutPanel1.MouseHover

    End Sub

    Private Sub ServiceSortableTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs) Handles ServiceSortableTemplateViewer1.TemplateClick
        ' Oepn up the single template Viewer
        Using singleViewer As New UseTemplateBox() With {.Template = e.Template, .Readonly = True}
            singleViewer.ShowDialog(Me)
        End Using
    End Sub
End Class


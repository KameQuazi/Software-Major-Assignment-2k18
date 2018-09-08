Imports LampCommon

Public Class ViewTemplatesForm


    Private Sub ServiceSortableTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs) Handles ServiceSortableTemplateViewer1.TemplateClick
        ' Oepn up the single template Viewer
        Using singleViewer As New EditTemplateDialog() With {.Template = e.Template, .JobEnabled = True}
            ' allow editing if same creator OR permission >= Elevated
            If e.Template.CreatorId = CurrentUser.UserId OrElse CurrentUser.PermissionLevel >= UserPermission.Elevated Then
                singleViewer.Readonly = False
                singleViewer.Text = "Editing Template - LAMP"
            Else
                singleViewer.Readonly = True
                singleViewer.Text = "Viewing Template - LAMP"
            End If

            singleViewer.ShowDialog(Me)
            ServiceSortableTemplateViewer1.UpdateContents()
        End Using
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class


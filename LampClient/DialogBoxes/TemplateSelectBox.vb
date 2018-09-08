Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports LampCommon

Public Class TemplateSelectBox
    Public Property SelectedTemplate As LampTemplate

    Private Sub ServiceSortableTemplateViewer1_Load(sender As Object, e As EventArgs) Handles ServiceSortableTemplateViewer1.Load

    End Sub


    Private Sub ServiceSortableTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs) Handles ServiceSortableTemplateViewer1.TemplateClick
        DialogResult = DialogResult.OK
        SelectedTemplate = e.Template
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        SelectedTemplate = Nothing
        Me.Close()
    End Sub



End Class
Imports LampCommon

Public Class MyTemplatesForm
    Private Sub MyTemplatesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim request = CurrentSender.GetTemplateList(CurrentUser.ToCredentials, Nothing, 10, 0, False)
        If request.Status <> LampStatus.OK Then
            Return
        End If

        For Each item In request.Templates
            MultiTemplateViewer1.Templates.Add(item)
        Next
    End Sub
End Class
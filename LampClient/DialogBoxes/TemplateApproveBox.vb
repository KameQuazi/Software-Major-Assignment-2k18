Imports LampCommon

Public Class TemplateApproveBox
    Public Property Template As LampTemplate
        Get
            Return TemplateCreatorControl1.Template
        End Get
        Set(value As LampTemplate)
            TemplateCreatorControl1.Template = value
        End Set
    End Property

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub



    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim response = CurrentSender.ApproveTemplate(CurrentUser.ToCredentials, Template.GUID)
        Select Case response
            Case LampStatus.OK
                MessageBox.Show("Approve Successful")
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Case Else
                ShowError(response)
                Me.DialogResult = DialogResult.Abort
        End Select
    End Sub

    Private Sub btnRevoke_Click(sender As Object, e As EventArgs) Handles btnRevoke.Click

    End Sub
End Class
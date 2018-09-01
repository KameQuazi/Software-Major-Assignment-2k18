Public Class NewTemplateForm
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TemplateCreatorControl1.SetSubmitType(TemplateCreatorControl.SendType.Add)
    End Sub

    Private Sub TemplateCreatorControl1_SubmitSuccessful(sender As Object, e As SubmitEventArgs) Handles TemplateCreatorControl1.SubmitSuccessful
        ' actually submitted an item
        ' go back a form
        ToolBar1.ShowPreviousForm(Me)
    End Sub


End Class
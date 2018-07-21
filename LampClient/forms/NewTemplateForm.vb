Public Class NewTemplateForm
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TemplateCreatorControl1.SetSubmitType(TemplateCreatorControl.SendType.Add)
    End Sub
End Class
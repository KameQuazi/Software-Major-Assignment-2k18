Public Class NewTemplateForm
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim buttons = New CreateNewTemplateButtons(TemplateCreatorControl1) With {.Dock = DockStyle.Fill}
        TemplateCreatorControl1.OptionsControl = buttons
        AddHandler buttons.LoadingStart, AddressOf LoadingStart
        AddHandler buttons.LoadingEnd, AddressOf LoadingEnd

    End Sub

    Private Sub TemplateCreatorControl1_SubmitSuccessful(sender As Object, e As SubmitEventArgs) Handles TemplateCreatorControl1.SubmitSuccessful
        ' actually submitted an item
        ' go back to home
        ToolBar1.ShowPreviousForm(Me)
    End Sub

    Private Sub LoadingStart(sender As Object, e As EventArgs)
        Me.ToolBar1.Enabled = False

    End Sub

    Private Sub LoadingEnd(sender As Object, e As EventArgs)
        Me.ToolBar1.Enabled = True
    End Sub


End Class
Imports LampCommon

Public Class EditTemplateDialog
    Public Property Template As LampTemplate
        Get
            Return TemplateCreatorControl1.Template
        End Get
        Set(value As LampTemplate)
            TemplateCreatorControl1.Template = value
        End Set
    End Property

    Public Property [Readonly] As Boolean
        Get
            Return TemplateCreatorControl1.ReadOnly
        End Get
        Set(value As Boolean)
            TemplateCreatorControl1.ReadOnly = value
        End Set
    End Property


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim buttons = New EditTemplateDialogButtons(TemplateCreatorControl1)
        buttons.Dock = DockStyle.Fill

    End Sub

    Private Sub TemplateCreatorControl1_SubmitSuccessful(sender As Object, e As SubmitEventArgs) Handles TemplateCreatorControl1.SubmitSuccessful
        Me.Close()
    End Sub



End Class
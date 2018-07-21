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
End Class
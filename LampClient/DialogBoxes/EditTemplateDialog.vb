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

    Public Property JobEnabled As Boolean
        Get
            Return TemplateCreatorControl1.JobEnabled
        End Get
        Set(value As Boolean)
            TemplateCreatorControl1.JobEnabled = value
        End Set
    End Property

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' TemplateCreatorControl1.SetSubmitType(TemplateCreatorControl.SendType.Edit)

    End Sub

    Private Sub TemplateCreatorControl1_SubmitSuccessful(sender As Object, e As SubmitEventArgs) Handles TemplateCreatorControl1.SubmitSuccessful
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Are you sure you want to PERMANTLY delete this template?", "Warning - Deleting file", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim response = CurrentSender.RemoveTemplate(CurrentUser.ToCredentials, Template.GUID)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Removed successfully")
                    Me.Close()
                Case Else
                    ShowError(response)

            End Select
        End If

    End Sub

    Private Sub btnSubmitEdit_Click(sender As Object, e As EventArgs) Handles btnSubmitEdit.Click
        If MessageBox.Show("Are you sure you edit this template? Previous data may be lost", "Warning - Editing file", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim response = CurrentSender.EditTemplate(CurrentUser.ToCredentials, Template)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Editted successfully")
                    Me.Close()
                Case Else
                    ShowError(response)

            End Select
        End If
    End Sub

    Private Sub EditTemplateDialog_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Delete Then
            btnDelete.PerformClick()
        End If
    End Sub

    Private Sub TemplateCreatorControl1_Load(sender As Object, e As EventArgs) Handles TemplateCreatorControl1.Load

    End Sub
End Class
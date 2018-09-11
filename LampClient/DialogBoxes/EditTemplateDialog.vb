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


    Private WithEvents buttons As New EditTemplateDialogButtons() With {.Dock = DockStyle.Fill}
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TemplateCreatorControl1.OptionsControl = buttons
    End Sub



    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)
        For Each control As Control In Me.Controls
            control.Enabled = Me.Enabled
        Next
    End Sub


    Private Sub ExportDxfClickedHandler(sender As Object, e As EventArgs) Handles buttons.ExportDxfClicked
        If TemplateCreatorControl1.DxfSaveDialog.ShowDialog = DialogResult.OK Then
            Template.BaseDrawing.Save(TemplateCreatorControl1.DxfSaveDialog.FileName)
        End If
    End Sub

    Private Sub ExportSpfClickedHandler(sender As Object, e As EventArgs) Handles buttons.ExportSpfClicked
        If TemplateCreatorControl1.SpfSaveDialog.ShowDialog = DialogResult.OK Then
            Template.Save(TemplateCreatorControl1.SpfSaveDialog.FileName)
        End If
    End Sub

    Private Sub ImportSpfClickedHandler(sender As Object, e As EventArgs) Handles buttons.ImportSpfClicked
        If TemplateCreatorControl1.SpfOpenDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim temp = LampTemplate.FromFile(TemplateCreatorControl1.SpfOpenDialog.FileName)
                If temp Is Nothing Then
                    Throw New Exception("Spf File cannot be nothing")
                End If
                Me.Template = temp

            Catch ex As Exception
                If MessageBox.Show("File is invalid. Show detailed error message?", "File Invalid", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    MessageBox.Show(ex.ToString)
                End If
            End Try

        End If
    End Sub

    Private Sub ImportDxfClickedHandler(sender As Object, e As EventArgs) Handles buttons.ImportDxfClicked
        If TemplateCreatorControl1.DxfOpenDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim dxf = LampDxfDocument.FromFile(TemplateCreatorControl1.DxfOpenDialog.FileName)
                If dxf Is Nothing Then
                    Throw New Exception("Dxf File cannot be nothing")
                End If
                Me.Template.BaseDrawing = dxf

            Catch ex As Exception
                If MessageBox.Show("File is invalid. Show detailed error message?", "File Invalid", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    MessageBox.Show(ex.ToString)
                End If
            End Try

        End If
    End Sub

    Private Async Sub SubmitEditClickedHandler(sender As Object, e As EventArgs) Handles buttons.SubmitEditClicked
        If Not TemplateCreatorControl1.CheckPossibleErrors Then
            Return
        End If

        ShowWaitForm()
        Dim pastEnabled = Me.Enabled
        Me.Enabled = False
        Try

            If MessageBox.Show("Are you sure you edit this template? Previous data may be lost", "Warning - Editing file",
                               MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim response = Await CurrentSender.EditTemplateAsync(CurrentUser.ToCredentials, Template)
                Select Case response
                    Case LampStatus.OK
                        MessageBox.Show("Edited successfully")
                        Me.Close()
                    Case LampStatus.InvalidUsernameOrPassword
                        ShowLoginError(Me.ParentForm)
                    Case Else
                        ShowError(response)
                End Select
            End If

        Catch ex As Exception
            MessageBox.Show("An unknown error occured when communicating with server")
#If DEBUG Then
            Throw ex
#End If
        Finally
            HideWaitForm()
            Me.Enabled = pastEnabled
        End Try

    End Sub

    Private Async Sub DeleteClickedHandler(sender As Object, e As EventArgs) Handles buttons.DeleteClicked
        ShowWaitForm()
        Dim pastEnabled = Me.Enabled
        Me.Enabled = False
        Try
            If MessageBox.Show("Are you sure you want to PERMANTLY delete this template?", "Warning - Deleting file",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim response = Await CurrentSender.RemoveTemplateAsync(CurrentUser.ToCredentials,
                                                                  Template.GUID)
                Select Case response
                    Case LampStatus.OK
                        MessageBox.Show("Deleted successfully")
                        Me.Close()
                    Case LampStatus.InvalidUsernameOrPassword
                        ShowLoginError(Me.ParentForm)
                    Case Else
                        ShowError(response)
                End Select
            End If

        Catch ex As Exception
            MessageBox.Show("An unknown error occured when communicating with server")
#If DEBUG Then
            Throw ex
#End If
        Finally
            HideWaitForm()
            Me.Enabled = pastEnabled
        End Try


    End Sub


End Class
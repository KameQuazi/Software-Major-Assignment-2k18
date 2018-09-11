Imports LampCommon

Public Class NewTemplateForm

    Private WithEvents buttons As New CreateNewTemplateButtons() With {.Dock = DockStyle.Fill}

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
        TemplateCreatorControl1.OptionsControl = buttons

    End Sub

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)
        For Each item As Control In Me.Controls
            item.Enabled = Me.Enabled
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

    Private Async Sub ValidateAndSubmitTemplate(sender As Object, e As EventArgs) Handles buttons.SubmitToDatabaseClicked
        If Not TemplateCreatorControl1.CheckPossibleErrors Then
            Return
        End If

        ' actually submit the template
        Dim pastEnabled = Me.Enabled

        ShowWaitForm()
        Me.Enabled = False
        Try
            Dim response = Await CurrentSender.AddUnapprovedTemplateAsync(CurrentUser.ToCredentials, Template)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Submitted Successfully")

                Case LampStatus.InvalidUsernameOrPassword
                    ShowLoginError(Me.ParentForm)
                Case Else
                    ShowError(response)
            End Select



        Catch ex As Exception
#If DEBUG Then
            Throw ex
#End If
            ' todo spff it up
            MessageBox.Show("A error occured when connecting to server. Please try again")

        Finally
            HideWaitForm()
            Me.Enabled = pastEnabled
        End Try
    End Sub





End Class
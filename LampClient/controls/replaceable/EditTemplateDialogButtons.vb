Imports LampClient
Imports LampCommon

Public Class EditTemplateDialogButtons

    Public Event LoadingStart(sender As Object, e As EventArgs)

    Public Event LoadingEnd(sender As Object, e As EventArgs)

    Private _readonly As Boolean = False
    Public Property [Readonly] As Boolean
        Get
            Return _readonly
        End Get
        Set(value As Boolean)
            _readonly = value

        End Set
    End Property

    Private Sub UpdateReadonlyElements()
        ImportSpf.Enabled = Not [Readonly]
    End Sub

    Private Sub UpdateEnabledElements()
        RootTableLayoutPanel.Enabled = Me.Enabled
    End Sub

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)

        UpdateEnabledElements()
    End Sub

    Private _enabled As Boolean = False
    Public Property TemplateParent As TemplateCreatorControl

    Public Property Template As LampTemplate
        Get
            Return TemplateParent.Template
        End Get
        Set(value As LampTemplate)
            TemplateParent.Template = value
        End Set
    End Property

    Private Sub ImportSpf_Click(sender As Object, e As EventArgs) Handles ImportSpf.Click
        If SpfOpenDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim temp = LampTemplate.FromFile(SpfOpenDialog.FileName)
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

    Private Sub ExportDxf_Click(sender As Object, e As EventArgs) Handles ExportDxf.Click
        If DxfSaveDialog.ShowDialog = DialogResult.OK Then
            Template.BaseDrawing.Save(DxfSaveDialog.FileName)
        End If
    End Sub

    Private Sub ExportSpf_Click(sender As Object, e As EventArgs) Handles ExportSpf.Click
        If SpfSaveDialog.ShowDialog = DialogResult.OK Then
            Template.Save(SpfSaveDialog.FileName)
        End If
    End Sub


    Sub New(parent As TemplateCreatorControl)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.TemplateParent = parent
    End Sub

    Private Sub StartLoading()
        RaiseEvent LoadingStart(Me, New EventArgs)
        TemplateParent.Enabled = False
        ShowWaitForm()
    End Sub

    Private Sub StopLoading()
        RaiseEvent LoadingEnd(Me, New EventArgs)
        HideWaitForm()
    End Sub



    Private Async Sub btnSubmitEdit_Click(sender As Object, e As EventArgs) Handles btnSubmitEdit.Click
        StartLoading()
        Dim pastEnabled = TemplateParent.Enabled

        Try
            If MessageBox.Show("Are you sure you edit this template? Previous data may be lost", "Warning - Editing file",
                               MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim response = Await CurrentSender.EditTemplateAsync(CurrentUser.ToCredentials, Template)
                Select Case response
                    Case LampStatus.OK
                        MessageBox.Show("Edited successfully")
                        TemplateParent.RaiseEditSuccessful(Me, New SubmitEventArgs(Template))
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
            StopLoading()
            TemplateParent.Enabled = pastEnabled
        End Try

    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        StartLoading()
        Dim pastEnabled = TemplateParent.Enabled

        Try
            If MessageBox.Show("Are you sure you want to PERMANTLY delete this template?", "Warning - Deleting file",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim response = Await CurrentSender.RemoveTemplateAsync(CurrentUser.ToCredentials,
                                                                  Template.GUID)
                Select Case response
                    Case LampStatus.OK
                        MessageBox.Show("Edited successfully")
                        TemplateParent.RaiseEditSuccessful(Me, New SubmitEventArgs(Template))
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
            StopLoading()
            TemplateParent.Enabled = pastEnabled
        End Try


    End Sub
End Class


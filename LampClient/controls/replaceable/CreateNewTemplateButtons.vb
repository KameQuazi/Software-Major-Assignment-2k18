Imports LampClient
Imports LampCommon

Public Class CreateNewTemplateButtons

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

    Private Async Sub btnSubmitTemplate_Click(sender As Object, e As EventArgs) Handles btnSubmitTemplate.Click
        Dim pastEnabled = TemplateParent.Enabled

        StartLoading()

        Try
            Dim response = Await CurrentSender.AddUnapprovedTemplateAsync(CurrentUser.ToCredentials, Template)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Submitted Successfully")
                    TemplateParent.RaiseSubmitSuccessful(Me, New SubmitEventArgs(Template))
                Case LampStatus.InvalidUsernameOrPassword
                    ShowLoginError(Me.ParentForm)
                Case Else
                    ShowError(response)
            End Select

        Catch ex As Exception

#If DEBUG Then
            Throw ex
#End If

        Finally
            StopLoading()
            TemplateParent.Enabled = pastEnabled

        End Try
    End Sub
End Class


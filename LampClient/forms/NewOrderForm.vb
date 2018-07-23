Imports LampCommon

Public Class NewOrderForm

    Private _currentTemplate As LampTemplate
    Public Property CurrentTemplate As LampTemplate
        Get
            Return _currentTemplate
        End Get
        Set(value As LampTemplate)
            _currentTemplate = value
            DxfViewerControl1.Drawing = value.BaseDrawing
        End Set
    End Property

    Private Sub txtRecipient_Enter(sender As Object, e As EventArgs) Handles txtRecipient.Enter
        If txtRecipient.Text = "Insert Name Here" Then
            txtRecipient.Text = ""
        End If
    End Sub

    Private Sub txtRecipient_Leave(sender As Object, e As EventArgs) Handles txtRecipient.Leave
        If txtRecipient.Text = "" Then
            txtRecipient.Text = "Insert Name Here"
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Select Case e.KeyCode

        End Select
    End Sub

    Private Sub ToolBar1_Load(sender As Object, e As EventArgs)

    End Sub


    Private Sub DxfViewerControl1_Click(sender As Object, e As EventArgs) Handles DxfViewerControl1.Click
        Using dialog As New TemplateSelectBox ' 
            If dialog.ShowDialog() = DialogResult.OK Then
                CurrentTemplate = dialog.SelectedTemplate
            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim response = CurrentSender.AddJob(CurrentUser.ToCredentials, New LampJob(Me.CurrentTemplate, CurrentUser.ToProfile, "hello summary"))
        Select Case response
            Case LampStatus.OK
                MessageBox.Show("Successfully added job")
            Case Else
                ShowError(response)
        End Select
    End Sub
End Class
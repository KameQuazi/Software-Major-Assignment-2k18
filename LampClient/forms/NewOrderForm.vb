Public Class NewOrderForm


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
        TemplateSelectForm.ShowDialog()

    End Sub
End Class
Imports LampCommon

Public Class NewOrderForm
    Dim numJobs As Integer = 0
    Dim dynamicTextDict As New List(Of String)
    Dim valid As Boolean = False
    Dim summary As String = ""

    Private _currentTemplate As LampTemplate = New LampTemplate()
    Public Property CurrentTemplate As LampTemplate
        Get
            Return _currentTemplate
        End Get
        Set(value As LampTemplate)
            _currentTemplate = value

        End Set
    End Property

    Private Sub txtRecipient_Enter(sender As Object, e As EventArgs) Handles txtRecipient.Enter
        If txtRecipient.Text = "Insert csv Here" Then
            txtRecipient.Text = ""
        End If
        txtRecipient.Text = dynamicTextDict(txtPrefix.SelectedIndex())
    End Sub

    Private Sub txtRecipient_Leave(sender As Object, e As EventArgs) Handles txtRecipient.Leave
        dynamicTextDict(txtPrefix.SelectedIndex()) = txtRecipient.Text
        If txtRecipient.Text = "" Then
            txtRecipient.Text = "Insert csv Here"
        End If

    End Sub


    Private Sub checkValid()
        valid = True
        If numJobs > 0 Then


            If Not CurrentTemplate.HasDynamicText Then
                txtPrefix.Show()
                For i = 0 To dynamicTextDict.Count - 1
                    If dynamicTextDict(i).Split(",").Count <> numJobs Then
                        valid = False
                    End If
                Next
            Else
                valid = True
            End If

        Else
            valid = False
        End If

    End Sub

    Private Sub DxfViewerControl1_Click(sender As Object, e As EventArgs) Handles DxfViewerControl1.Click
        Using dialog As New TemplateSelectBox ' 
            If dialog.ShowDialog() = DialogResult.OK Then
                CurrentTemplate = dialog.SelectedTemplate
            End If
        End Using
    End Sub



    Private Sub txtCaseID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNum.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub txtNumb_Enter(sender As Object, e As EventArgs) Handles txtNum.Enter
        If txtNum.Text = "Number Of Jobs" Then
            txtNum.Text = ""
        End If
    End Sub

    Private Sub txtnumb_Leave(sender As Object, e As EventArgs) Handles txtNum.Leave
        If txtNum.Text = "" Then
            txtNum.Text = "Number Of Jobs"
            numJobs = 0
        Else
            numJobs = Int(txtNum.Text)
        End If

    End Sub

    Private Sub txtsuum_Enter(sender As Object, e As EventArgs) Handles txtSum.Enter
        If txtSum.Text = "Summary" Then
            txtSum.Text = ""
        End If
    End Sub

    Private Sub txtsum_Leave(sender As Object, e As EventArgs) Handles txtSum.Leave
        If txtSum.Text = "" Then
            txtSum.Text = "Summary"
            summary = ""
        Else
            summary = txtSum.Text
        End If

    End Sub

    Private Sub txtPrefix_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtPrefix.SelectedIndexChanged
        txtRecipient.Text = dynamicTextDict(txtPrefix.SelectedIndex())
    End Sub
    
     Private Sub ServiceSortableTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs) Handles ServiceSortableTemplateViewer1.TemplateClick
        Dim x = NewOrderFormChooseParameter
        x.SelectedTemplate = e.Template
        x.Show()
        Me.Close()
    End Sub
End Class
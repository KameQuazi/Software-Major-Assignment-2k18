Imports LampCommon

Public Class NewOrderForm

    Private _currentTemplate As LampTemplate
    Public Property CurrentTemplate As LampTemplate
        Get
            Return _currentTemplate
        End Get
        Set(value As LampTemplate)
            _currentTemplate = value
        End Set
    End Property



    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode

        End Select
    End Sub

    Private Sub ToolBar1_Load(sender As Object, e As EventArgs)

    End Sub


    Private Sub DxfViewerControl1_Click(sender As Object, e As EventArgs)
        Using dialog As New TemplateSelectBox ' 
            If dialog.ShowDialog() = DialogResult.OK Then
                CurrentTemplate = dialog.SelectedTemplate
            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim job = New LampJob(Me.CurrentTemplate, CurrentUser.ToProfile, "hello summary")
        job.Pages = 3

        For i = 0 To 2
            job.AddInsertionPoint(New LampSingleDxfInsertLocation(New netDxf.Vector3(0, 0, 0)), i, True)

        Next


        Dim response = CurrentSender.AddJob(CurrentUser.ToCredentials, job)
        Select Case response
            Case LampStatus.OK
                MessageBox.Show("Successfully added job")
                ShowNewForm(Nothing, Me, HomeForm)
            Case Else
                ShowError(response)
        End Select
    End Sub

    Private Sub ServiceSortableTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs) Handles ServiceSortableTemplateViewer1.TemplateClick
        Console.WriteLine("owo")
    End Sub
End Class
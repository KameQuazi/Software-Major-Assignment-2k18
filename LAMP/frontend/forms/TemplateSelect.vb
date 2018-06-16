Imports LAMP
Public Class TemplateSelect
    Dim listTemplate As New List(Of LampTemplate)
    Dim sortTemplate As New List(Of LampTemplate)
    Dim db As New TemplateDatabase()
    Private Sub pbLogo_Click(sender As Object, e As EventArgs)
        frmStart.Show()
        Me.Hide()
        frmStart.lastform = frmStart.curForm
        frmStart.curForm = "view"
    End Sub

    Private Sub fileViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.CharacterCasing = CharacterCasing.Lower
        ToolBar2.lblCurScr.Text = "File Viewer"
        listTemplate = db.GetAllTemplate(0, 3, "Name")

    End Sub

    ''' <summary>
    ''' Load Files into the viewing screen
    ''' </summary>

    Private Sub cmbSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSort.SelectedIndexChanged
        For i = 0 To listTemplate.Count - 1

            MultiTemplateViewer1.SetTemplateToPosition(i, 0, listTemplate(i))
            Debug.Write(listTemplate(i).Name)

        Next
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        sortTemplate.Clear()
        For Each template As LampTemplate In listTemplate
            For Each tag As String In template.Tags
                If tag.Contains(TextBox1.Text) And TextBox1.Text IsNot "" Then
                    sortTemplate.Add(template)
                    Exit For
                End If
            Next
        Next


        If sortTemplate.HasNotNothing Then
            For i = 0 To sortTemplate.Count - 1
                MultiTemplateViewer1.SetTemplateToPosition(i, 0, sortTemplate(i))
            Next
        End If
    End Sub



End Class
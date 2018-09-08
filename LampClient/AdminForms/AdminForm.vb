Public Class AdminForm
    Private Sub AdminToolbar1_Load(sender As Object, e As EventArgs) 

    End Sub

    Private Sub btnStandard_Click(sender As Object, e As EventArgs) Handles btnStandard.Click
        AdminToolbar1.ShowNewForm(Me, HomeForm)
    End Sub
End Class
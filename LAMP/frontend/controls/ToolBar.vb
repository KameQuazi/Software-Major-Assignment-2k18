Public Class ToolBar
    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        frmStart.Show()
        Options.Close()
        Logout.Close()
        TemplateSelect.Close()
        AboutBox1.Close()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        AboutBox1.Show()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Select Case frmStart.lastform
            Case = "main"
                frmStart.Show()
                TemplateSelect.Hide()
                AboutBox1.Hide()
                Options.Hide()
            Case = "view"
                TemplateSelect.Show()
                frmStart.Hide()
                AboutBox1.Hide()
                Options.Hide()
        End Select
        frmStart.lastform = frmStart.curForm
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        btnQY.Show()
        btnQN.Show()
        btnQuit.Hide()
    End Sub

    Private Sub btnQN_Click(sender As Object, e As EventArgs) Handles btnQN.Click
        btnQY.Hide()
        btnQN.Hide()
        btnQuit.Show()
    End Sub

    Private Sub btnQY_Click(sender As Object, e As EventArgs) Handles btnQY.Click
        If Me.Parent.GetType().IsSubclassOf(GetType(Form)) Then
            Dim parent As Form = DirectCast(Me.Parent, Form)
            parent.Close()
        Else
            Throw New Exception("Control must be on top level (must not be in a panel etc)")
        End If

    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Logout.Show()
    End Sub
End Class

Public Class HelpBox

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click
        IO.File.WriteAllBytes("Help.docx", My.Resources.LAMP_User_Help)
        Dim psi As New ProcessStartInfo()
        With psi
            .FileName = "Help.docx"
            .UseShellExecute = True
        End With
        Process.Start(psi)
    End Sub
End Class
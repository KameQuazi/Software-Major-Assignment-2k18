Public Class CutSelectorControl
    Public Event Changed(sender As Object, e As Color)

    Private Sub radioRed_CheckedChanged(sender As Object, e As EventArgs) Handles radioRed.CheckedChanged, radioRed.CheckedChanged, radioBlack.CheckedChanged
        If radioRed.Checked Then
            RaiseEvent Changed(Me, Color.Red)
        ElseIf radioBlack.CanFocus Then
            RaiseEvent Changed(Me, Color.Black)
        Else
            RaiseEvent Changed(Me, Color.Blue)
        End If
    End Sub
End Class

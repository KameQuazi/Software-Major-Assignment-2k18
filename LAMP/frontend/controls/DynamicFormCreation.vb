Public Class DynamicFormCreation
    Private Function MakePanel() As Panel
        Dim newPanel As New Panel
        Return newPanel
    End Function


    Protected Overrides Sub OnPaddingChanged(e As EventArgs)
        MyBase.OnPaddingChanged(e)

        UpdatePanels()
    End Sub

    Public Sub UpdatePanels()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class

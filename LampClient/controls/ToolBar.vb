Public Class ToolBar
    Public Property ScreenName As String
        Get
            Return lblCurScr.Text
        End Get
        Set(value As String)
            lblCurScr.Text = value
        End Set
    End Property

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        frmStart.Show()
        DebugOptions.Close()
        LogoutBox.Close()
        TemplateSelectForm.Close()
        AboutBox.Close()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        AboutBox.Show()
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

    ''' <summary>
    ''' Closes the first form that is a parent of control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnQY_Click(sender As Object, e As EventArgs) Handles btnQY.Click
        Dim currentParent As Control = Me.Parent
        Dim closed As Boolean = False

        While currentParent IsNot Nothing
            If currentParent.GetType().IsSubclassOf(GetType(Form)) Then
                Dim parent As Form = DirectCast(currentParent, Form)
                parent.Close()
                closed = True
                Exit While
            End If

            currentParent = currentParent.Parent
        End While

#If DEBUG Then
        If Not closed Then
            Throw New Exception("Control must be on top level (must not be in a panel etc)")
        End If
#End If

    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        LogoutBox.Show()
    End Sub
End Class

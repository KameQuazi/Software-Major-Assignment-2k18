Public Class ToolBar
    Public Property HomeEnabled As Boolean
        Get
            Return btnHome.Enabled
        End Get
        Set(value As Boolean)
            btnHome.Enabled = value
        End Set
    End Property

    Public Sub SetUsername(username As String)

    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs)
        LoginForm.Show()
        DebugOptions.Close()
        LogoutBox.Close()
        TemplateSelectForm.Close()
        AboutBox.Close()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs)
        AboutBox.Show()
    End Sub


    Private Sub btnQuit_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnQN_Click(sender As Object, e As EventArgs)

    End Sub

    ''' <summary>
    ''' Closes the first form that is a parent of control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnQY_Click(sender As Object, e As EventArgs)
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

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs)
        LogoutBox.Show()
    End Sub
End Class

Imports LampCommon

Public Class MyTemplatesForm
    Private offset = 0
    Private Const TEMPLATES_PER_PAGE = 8

    Private Sub ShowError(status As LampStatus)
        MessageBox.Show("Could not update: " + status.ToString)
    End Sub

    Public Property SortOrder As LampSort

    Private Async Function UpdateInterface() As Task
        Try
            ' check if the next page exists (offset - tempaltes-per-page)
            MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) MultiTemplateViewer1.Templates.Clear())

            If offset - TEMPLATES_PER_PAGE >= 0 Then
                Dim previousPage = Await CurrentSender.GetTemplateListAsync(CurrentUser.ToCredentials,
                                                        Nothing, New List(Of String) From {CurrentUser.UserId},
                                                        TEMPLATES_PER_PAGE, offset - TEMPLATES_PER_PAGE, False, SortOrder)
                If previousPage.Status = LampStatus.OK Then
                    If previousPage.Templates.Count() > 0 Then
                        MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) btnPreviousPage.Enabled = True)
                    Else
                        MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) btnPreviousPage.Enabled = False)
                    End If
                Else
                    ShowError(previousPage.Status)
                    Return
                End If
            End If


            Dim request = Await CurrentSender.GetTemplateListAsync(CurrentUser.ToCredentials,
                                                               Nothing, New List(Of String) From {CurrentUser.UserId},
                                                               TEMPLATES_PER_PAGE, offset, False, SortOrder)

            If request.Status <> LampStatus.OK Then
                ShowError(request.Status)
                Return
            End If

            MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) control.Suspend())
            For Each item In request.Templates
                MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) control.Templates.Add(item))
            Next
            MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) control.EndSuspend())

            ' check if the next page exists
            If offset + TEMPLATES_PER_PAGE >= 0 Then
                Dim previousPage = Await CurrentSender.GetTemplateListAsync(CurrentUser.ToCredentials,
                                                            Nothing, New List(Of String) From {CurrentUser.UserId},
                                                            TEMPLATES_PER_PAGE, offset + TEMPLATES_PER_PAGE, False, SortOrder)
                If previousPage.Status = LampStatus.OK Then
                    If previousPage.Templates.Count() > 0 Then
                        MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) btnNextPage.Enabled = True)
                    Else
                        MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) btnNextPage.Enabled = False)
                    End If
                Else
                    ShowError(previousPage.Status)
                    Return
                End If
            End If
        Catch e As ObjectDisposedException
            ' if the form gets closed b4 request is finish, it will crash
            ' we just want to catch it
#If DEBUG Then
            MessageBox.Show(e.ToString)

#End If
        End Try
    End Function

    Private Sub MyTemplatesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadComplete()

    End Sub

    Private Sub LoadComplete()
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        MultiTemplateViewer1.ShowLoading()

        Try
            Dim newTask = New Task(Async Sub()
                                       Await UpdateInterface()
                                   End Sub)

            newTask.ContinueWith(Sub(x)
                                     MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) MultiTemplateViewer1.StopLoading())
                                 End Sub)
            newTask.Start()

        Catch e As ObjectDisposedException
            ' if the form gets closed b4 request is finish, it will crash
            ' we just want to catch it
#If DEBUG Then
            MessageBox.Show(e.ToString)

#End If
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        offset += TEMPLATES_PER_PAGE
        LoadComplete()
    End Sub

    Private Sub btnPreviousPage_Click(sender As Object, e As EventArgs) Handles btnPreviousPage.Click
        offset -= TEMPLATES_PER_PAGE
        LoadComplete()
    End Sub

    Private Sub MultiTemplateViewer1_Load(sender As Object, e As EventArgs) Handles MultiTemplateViewer1.Load

    End Sub
End Class
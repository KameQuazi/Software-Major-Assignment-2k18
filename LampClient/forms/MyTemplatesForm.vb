Imports LampCommon

Public Class MyTemplatesForm
    Private offset = 0
    Private Const TEMPLATES_PER_PAGE = 8

    Private Sub ShowError(status As LampStatus)
        MessageBox.Show("Could not update: " + status.ToString)
    End Sub

    Private Async Function UpdateInterface() As Task
        ' check if the next page exists (offset - tempaltes-per-page)
        MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) MultiTemplateViewer1.Templates.Clear())

        If offset - TEMPLATES_PER_PAGE >= 0 Then
            Dim previousPage = Await CurrentSender.GetTemplateListAsync(CurrentUser.ToCredentials,
                                                        Nothing, New List(Of String) From {CurrentUser.UserId},
                                                        TEMPLATES_PER_PAGE, offset - TEMPLATES_PER_PAGE, False)
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
                                                               TEMPLATES_PER_PAGE, offset, False)

        If request.Status <> LampStatus.OK Then
            ShowError(request.Status)
            Return
        End If
        For Each item In request.Templates
            MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) control.Templates.Add(item))
        Next

        ' check if the next page exists
        If offset + TEMPLATES_PER_PAGE >= 0 Then
            Dim previousPage = Await CurrentSender.GetTemplateListAsync(CurrentUser.ToCredentials,
                                                        Nothing, New List(Of String) From {CurrentUser.UserId},
                                                        TEMPLATES_PER_PAGE, offset + TEMPLATES_PER_PAGE, False)
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

    End Function

    Private Sub MyTemplatesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComplete

    End Sub

    Private Sub LoadComplete()
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        MultiTemplateViewer1.ShowLoading()
        Dim newTask = New Task(Async Sub()
                                   Await UpdateInterface()
                               End Sub)
        newTask.ContinueWith(Sub() MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) MultiTemplateViewer1.StopLoading()))
        newTask.Start()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        offset += TEMPLATES_PER_PAGE
        LoadComplete()
    End Sub

    Private Sub btnPreviousPage_Click(sender As Object, e As EventArgs) Handles btnPreviousPage.Click
        offset -= TEMPLATES_PER_PAGE
        LoadComplete()
    End Sub


End Class
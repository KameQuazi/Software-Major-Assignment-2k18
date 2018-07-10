Imports LampCommon

Public Class ServiceTemplateViewer
    Private _sortOrder As LampSort = LampSort.SubmitDateAsc
    Public Property SortOrder As LampSort
        Get
            Return _sortOrder
        End Get
        Set(value As LampSort)
            _sortOrder = value
            If IsHandleCreated Then
                NewThreadUpdateInterface()
            End If
        End Set
    End Property

    Private Const TEMPLATES_PER_PAGE = 8

    Public Property Offset = 0


    Private Sub UpdateInterfaceLocking()
        Try
            SyncLock CurrentSender
                ' check if the next page exists (offset - tempaltes-per-page)
                Console.WriteLine(MultiTemplateViewer1.IsHandleCreated)
                MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) control.Templates.Clear())

                If Offset - TEMPLATES_PER_PAGE >= 0 Then
                    Dim previousPage = CurrentSender.GetTemplateList(CurrentUser.ToCredentials,
                                                        Nothing, New List(Of String) From {CurrentUser.UserId},
                                                        TEMPLATES_PER_PAGE, Offset - TEMPLATES_PER_PAGE, False, SortOrder)
                    If previousPage.Status = LampStatus.OK Then
                        If previousPage.Templates.Count() > 0 Then
                            Me.InvokeEx(Sub(control As ServiceTemplateViewer) control.btnPreviousPage.Enabled = True)
                        Else
                            Me.InvokeEx(Sub(control As ServiceTemplateViewer) control.btnPreviousPage.Enabled = False)
                        End If
                    Else
                        ShowError(previousPage.Status)
                        Return
                    End If
                Else
                    Me.InvokeEx(Sub(control As ServiceTemplateViewer) control.btnPreviousPage.Enabled = False)
                End If


                Dim request = CurrentSender.GetTemplateList(CurrentUser.ToCredentials,
                                                               Nothing, New List(Of String) From {CurrentUser.UserId},
                                                               TEMPLATES_PER_PAGE, Offset, False, SortOrder)

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
                If Offset + TEMPLATES_PER_PAGE >= 0 Then
                    Dim previousPage = CurrentSender.GetTemplateList(CurrentUser.ToCredentials,
                                                            Nothing, New List(Of String) From {CurrentUser.UserId},
                                                            TEMPLATES_PER_PAGE, Offset + TEMPLATES_PER_PAGE, False, SortOrder)
                    If previousPage.Status = LampStatus.OK Then
                        If previousPage.Templates.Count() > 0 Then
                            Me.InvokeEx(Sub(control As ServiceTemplateViewer) control.btnNextPage.Enabled = True)
                        Else
                            Me.InvokeEx(Sub(control As ServiceTemplateViewer) control.btnNextPage.Enabled = False)
                        End If
                    Else
                        ShowError(previousPage.Status)
                        Return
                    End If
                End If
            End SyncLock
        Catch e As ObjectDisposedException
            ' if the form gets closed b4 request is finish, it will crash
            ' we just want to catch it
#If DEBUG Then
            Console.WriteLine(e.ToString)

#End If

        End Try
    End Sub

    Private Sub NewThreadUpdateInterface()
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        MultiTemplateViewer1.ShowLoading()

        Try
            Dim newTask = New Task(AddressOf UpdateInterfaceLocking)

            newTask.ContinueWith(Sub(x)
                                     MultiTemplateViewer1.InvokeEx(Sub(control As MultiTemplateViewer) control.StopLoading())
                                 End Sub, TaskContinuationOptions.NotOnFaulted)
            newTask.Start()

        Catch e As ObjectDisposedException
            ' if the form gets closed b4 request is finish, it will crash
            ' we just want to catch it
#If DEBUG Then
            MessageBox.Show(e.ToString)

#End If
        End Try
    End Sub
    Private Sub ShowError(status As LampStatus)
        MessageBox.Show("Could not update: " + status.ToString)
    End Sub

    Private Sub btnPreviousPage_Click(sender As Object, e As EventArgs) Handles btnPreviousPage.Click
        Offset -= TEMPLATES_PER_PAGE
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        NewThreadUpdateInterface()
    End Sub

    Private Sub btnNextPage_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        Offset += TEMPLATES_PER_PAGE
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        NewThreadUpdateInterface()
    End Sub

    Private Sub ServiceTemplateViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewThreadUpdateInterface()
    End Sub
End Class

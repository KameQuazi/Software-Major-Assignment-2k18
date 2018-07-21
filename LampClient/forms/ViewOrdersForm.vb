Imports LampCommon

Public Class ViewOrdersForm
    Private offset = 0
    Private Const JOBS_PER_PAGE = 3

    Private Sub ShowError(status As LampStatus)
        MessageBox.Show("Could not update: " + status.ToString)
    End Sub

    Private _sortOrder As LampSort = LampSort.SubmitDateAsc
    Public Property SortOrder As LampSort
        Get
            Return _sortOrder
        End Get
        Set(value As LampSort)
            _sortOrder = value
            NewThreadUpdateInterface()
        End Set
    End Property

    Private Async Function UpdateInterface() As Task
        Try
            ' check if the next page exists (offset - tempaltes-per-page)
            MultiJobViewer1.SafeInvokeEx(Sub(control As MultiJobViewer) control.Jobs.Clear())

            If offset - JOBS_PER_PAGE >= 0 Then
                Dim previousPage = Await CurrentSender.GetJobListAsync(CurrentUser.ToCredentials,
                                                         New List(Of String) From {CurrentUser.UserId},
                                                        JOBS_PER_PAGE, offset - JOBS_PER_PAGE, SortOrder)
                If previousPage.Status = LampStatus.OK Then
                    If previousPage.Templates.Count() > 0 Then
                        Me.SafeInvokeEx(Sub(form As ViewOrdersForm) form.btnPreviousPage.Enabled = True)
                    Else
                        Me.SafeInvokeEx(Sub(form As ViewOrdersForm) form.btnPreviousPage.Enabled = False)
                    End If
                Else
                    ShowError(previousPage.Status)
                    Return
                End If
            End If


            Dim request = Await CurrentSender.GetJobListAsync(CurrentUser.ToCredentials,
                                                         New List(Of String) From {CurrentUser.UserId},
                                                        JOBS_PER_PAGE, offset, SortOrder)

            If request.Status <> LampStatus.OK Then
                ShowError(request.Status)
                Return
            End If

            MultiJobViewer1.SafeInvokeEx(Sub(control As MultiJobViewer) control.Suspend())
            For Each item In request.Templates
                MultiJobViewer1.SafeInvokeEx(Sub(control As MultiJobViewer) control.Jobs.Add(item))
            Next
            MultiJobViewer1.SafeInvokeEx(Sub(control As MultiJobViewer) control.EndSuspend())

            ' check if the next page exists
            If offset + JOBS_PER_PAGE >= 0 Then
                Dim previousPage = Await CurrentSender.GetJobListAsync(CurrentUser.ToCredentials,
                                                         New List(Of String) From {CurrentUser.UserId},
                                                        JOBS_PER_PAGE, offset + JOBS_PER_PAGE, SortOrder)
                If previousPage.Status = LampStatus.OK Then
                    If previousPage.Templates.Count() > 0 Then
                        Me.SafeInvokeEx(Sub(form As ViewOrdersForm) form.btnNextPage.Enabled = True)
                    Else
                        Me.SafeInvokeEx(Sub(form As ViewOrdersForm) form.btnNextPage.Enabled = False)
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

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MultiJobViewer1.Rows = JOBS_PER_PAGE
    End Sub

    Private Sub MyTemplatesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        NewThreadUpdateInterface()

    End Sub

    ''' <summary>
    ''' Creates a thread to update the buttons so it doesnt get locked
    ''' </summary>
    Private Sub NewThreadUpdateInterface()
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        MultiJobViewer1.ShowLoading()

        Try
            Dim newTask = New Task(Async Sub()
                                       Await UpdateInterface()
                                   End Sub)

            newTask.ContinueWith(Sub(x)
                                     MultiJobViewer1.SafeInvokeEx(Sub(control As MultiJobViewer) control.StopLoading())
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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        offset += JOBS_PER_PAGE
        NewThreadUpdateInterface()
    End Sub

    Private Sub btnPreviousPage_Click(sender As Object, e As EventArgs) Handles btnPreviousPage.Click
        offset -= JOBS_PER_PAGE
        NewThreadUpdateInterface()
    End Sub

End Class
Imports System.ComponentModel
Imports LampCommon

<DefaultEvent("JobClick")>
Public Class ServiceJobViewer
    Public Event JobClick(sender As Object, e As JobClickedEventArgs)

    Private Sub MultiJobViewer1_JobClick(sender As Object, e As JobClickedEventArgs) Handles MultiJobViewer1.JobClick
        RaiseEvent JobClick(Me, e)
    End Sub


    Private _sortOrder As LampSort = LampSort.NoSort
    Public Property SortOrder As LampSort
        Get
            Return _sortOrder
        End Get
        Set(value As LampSort)
            _sortOrder = value
            If IsHandleCreated Then
                UpdateContents()
            End If
        End Set
    End Property

    Private Const JOBS_PER_PAGE = 3

    Public Property Offset = 0

    Public Sub UpdateContents()
        NewThreadUpdateInterface()
    End Sub

    Private _justMyJobs As Boolean = True
    Public Property JustMyJobs As Boolean
        Get
            Return _justMyJobs
        End Get
        Set(value As Boolean)
            _justMyJobs = value
            If IsHandleCreated Then
                UpdateContents()
            End If
        End Set
    End Property

    Private Function GetFilteredUserList() As List(Of String)
        If JustMyJobs Then
            Return New List(Of String) From {CurrentUser.UserId}
        Else
            Return New List(Of String)
        End If
    End Function


    Private Sub UpdateInterfaceLocking()
        Try
            SyncLock CurrentSender
                ' check if the next page exists (offset - tempaltes-per-page)
                If Offset - JOBS_PER_PAGE >= 0 Then
                    Dim previousPage = CurrentSender.GetJobList(CurrentUser.ToCredentials,
                                                        GetFilteredUserList,
                                                        JOBS_PER_PAGE, Offset - JOBS_PER_PAGE, SortOrder)
                    If previousPage.Status = LampStatus.OK Then
                        If previousPage.Templates.Count() > 0 Then
                            Me.SafeInvokeEx(Sub(control As ServiceJobViewer) control.btnPreviousPage.Enabled = True)
                        Else
                            Me.SafeInvokeEx(Sub(control As ServiceJobViewer) control.btnPreviousPage.Enabled = False)
                        End If
                    Else
                        ShowError(previousPage.Status)
                        Return
                    End If
                Else
                    Me.SafeInvokeEx(Sub(control As ServiceJobViewer) control.btnPreviousPage.Enabled = False)
                End If


                Dim request = CurrentSender.GetJobList(CurrentUser.ToCredentials,
                                                               GetFilteredUserList,
                                                               JOBS_PER_PAGE, Offset, SortOrder)

                If request.Status <> LampStatus.OK Then
                    ShowError(request.Status)
                    Return
                End If

                ' actually aadd the templates
                MultiJobViewer1.SafeInvokeEx(Sub(control As MultiJobViewer) control.Suspend())
                MultiJobViewer1.SafeInvokeEx(Sub(control As MultiJobViewer) control.Jobs.Clear())

                For Each item In request.Templates
                    MultiJobViewer1.SafeInvokeEx(Sub(control As MultiJobViewer) control.Jobs.Add(item))
                Next
                MultiJobViewer1.SafeInvokeEx(Sub(control As MultiJobViewer) control.EndSuspend())

                ' check if the next page exists
                If Offset + JOBS_PER_PAGE >= 0 Then
                    Dim previousPage = CurrentSender.GetJobList(CurrentUser.ToCredentials,
                                                            GetFilteredUserList,
                                                            JOBS_PER_PAGE, Offset + JOBS_PER_PAGE, SortOrder)
                    If previousPage.Status = LampStatus.OK Then
                        If previousPage.Templates.Count() > 0 Then
                            Me.SafeInvokeEx(Sub(control As ServiceJobViewer) control.btnNextPage.Enabled = True)
                        Else
                            Me.SafeInvokeEx(Sub(control As ServiceJobViewer) control.btnNextPage.Enabled = False)
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
        MultiJobViewer1.ShowLoading()

        Try
            Dim newTask = New Task(AddressOf UpdateInterfaceLocking)

            newTask.ContinueWith(Sub(x)
                                     MultiJobViewer1.SafeInvokeEx(Sub(control As MultiJobViewer) control.StopLoading())
                                 End Sub, TaskContinuationOptions.NotOnFaulted)
            newTask.Start()

        Catch e As Exception ' an aggregate exception will be thrown instead of ObjectDisposedException
            ' if the form gets closed b4 request is finish, it will crash
            ' we just want to catch it
#If DEBUG Then
            MessageBox.Show(e.ToString)

#End If
        End Try
    End Sub

    Private Sub btnPreviousPage_Click(sender As Object, e As EventArgs) Handles btnPreviousPage.Click
        Offset -= JOBS_PER_PAGE
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        UpdateContents()
    End Sub

    Private Sub btnNextPage_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        Offset += JOBS_PER_PAGE
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        UpdateContents()
    End Sub

    Private Sub ServiceTemplateViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateContents()
    End Sub
End Class

Imports System.ComponentModel
Imports LampCommon

<DefaultEvent("JobClick")>
Public Class ServiceJobViewer
    Public Event JobClick(sender As Object, e As JobClickedEventArgs)
    Public Event ApproveClick(sender As Object, job As LampJobEventArgs)
    Public Event ViewDrawingClick(sender As Object, job As LampJobEventArgs)
    Public Event AdvancedClick(sender As Object, job As LampJobEventArgs)

    Private Sub HandleApproveClick(sender As Object, job As LampJobEventArgs) Handles MultiJobViewer1.ApproveClick
        RaiseEvent ApproveClick(Me, job)
    End Sub
    Private Sub HandleViewDrawingClick(sender As Object, job As LampJobEventArgs) Handles MultiJobViewer1.ViewDrawingClick
        RaiseEvent ViewDrawingClick(Me, job)
    End Sub
    Private Sub HandleAdvancedClick(sender As Object, job As LampJobEventArgs) Handles MultiJobViewer1.AdvancedClick
        RaiseEvent AdvancedClick(Me, job)
    End Sub

    Private Sub MultiJobViewer1_JobClick(sender As Object, e As JobClickedEventArgs) Handles MultiJobViewer1.JobClick
        RaiseEvent JobClick(Me, e)
    End Sub


    Private _sortOrder As LampJobSort = LampJobSort.NoSort
    Public Property SortOrder As LampJobSort
        Get
            Return _sortOrder
        End Get
        Set(value As LampJobSort)
            _sortOrder = value

            If IsHandleCreated Then
                UpdateContents()
            End If
        End Set
    End Property

    Private Const JOBS_PER_PAGE = 2

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

    Private _approvedType As LampApprove = LampApprove.Approved
    Public Property ApprovedType As LampApprove
        Get
            Return _ApprovedType
        End Get
        Set(value As LampApprove)
            _ApprovedType = value
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
                                                        JOBS_PER_PAGE, Offset - JOBS_PER_PAGE, ApprovedType, SortOrder)
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
                                                               JOBS_PER_PAGE, Offset, ApprovedType, SortOrder)

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
                                                            JOBS_PER_PAGE, Offset + JOBS_PER_PAGE, ApprovedType, SortOrder)
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

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MultiJobViewer1.Rows = JOBS_PER_PAGE
        If Me.DesignMode Then
            Me.StopLoading()
        End If
    End Sub

    Public Sub StopLoading()
        MultiJobViewer1.StopLoading()
    End Sub

    Public Sub StartLoading()
        MultiJobViewer1.ShowLoading()
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

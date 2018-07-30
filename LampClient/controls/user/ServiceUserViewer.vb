Imports LampCommon

Public Class ServiceUserViewer
    Public Event UserClick(sender As Object, e As UserClickEventArgs)

    Private Sub MultiTemplateViewer1_TemplateClick(sender As Object, e As UserClickEventArgs) Handles MultiUserControl1.UserClick
        RaiseEvent UserClick(Me, e)
        ' just bubble the event
    End Sub

    Private _sortOrder As LampUserSort = LampUserSort.NameAsc
    Public Property SortOrder As LampUserSort
        Get
            Return _sortOrder
        End Get
        Set(value As LampUserSort)
            _sortOrder = value
            If IsHandleCreated Then
                UpdateContents()
            End If
        End Set
    End Property



    Public Property Offset As Integer = 0

    Private Const USERS_PER_PAGE = 50

    Private Sub UpdateInterfaceLocking()
        Try
            SyncLock CurrentSender
                ' check if the next page exists (offset - tempaltes-per-page)
                If Offset - USERS_PER_PAGE >= 0 Then
                    Dim previousPage = CurrentSender.GetUserList(CurrentUser.ToCredentials, USERS_PER_PAGE, Offset - USERS_PER_PAGE, SortOrder)
                    If previousPage.Status = LampStatus.OK Then
                        If previousPage.Users.Count() > 0 Then
                            Me.SafeInvokeEx(Sub(control As ServiceUserViewer) control.btnPreviousPage.Enabled = True)
                        Else
                            Me.SafeInvokeEx(Sub(control As ServiceUserViewer) control.btnPreviousPage.Enabled = False)
                        End If
                    Else
                        ShowError(previousPage.Status)
                        Return
                    End If
                Else
                    Me.SafeInvokeEx(Sub(control As ServiceUserViewer) control.btnPreviousPage.Enabled = False)
                End If


                Dim request = CurrentSender.GetUserList(CurrentUser.ToCredentials,
                                                               USERS_PER_PAGE, Offset, SortOrder)

                If request.Status <> LampStatus.OK Then
                    ShowError(request.Status)
                    Return
                End If

                ' actually aadd the templates
                MultiUserControl1.SafeInvokeEx(Sub(control As MultiUserViewer) control.Users.Clear())

                For Each item In request.Users
                    MultiUserControl1.SafeInvokeEx(Sub(control As MultiUserViewer) control.Users.Add(item))
                Next

                ' check if the next page exists
                If Offset + USERS_PER_PAGE >= 0 Then
                    Dim nextPage = CurrentSender.GetUserList(CurrentUser.ToCredentials,
                                                            USERS_PER_PAGE, Offset + USERS_PER_PAGE, SortOrder)
                    If nextPage.Status = LampStatus.OK Then
                        If nextPage.Users.Count() > 0 Then
                            Me.SafeInvokeEx(Sub(control As ServiceUserViewer) control.btnNextPage.Enabled = True)
                        Else
                            Me.SafeInvokeEx(Sub(control As ServiceUserViewer) control.btnNextPage.Enabled = False)
                        End If
                    Else
                        ShowError(nextPage.Status)
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

    Public Sub StopLoading()
        Me.MultiUserControl1.StopLoading()
    End Sub

    Public Sub StartLoading()
        Me.MultiUserControl1.ShowLoading()
    End Sub


    Public Sub UpdateContents()
        NewThreadUpdateInterface()
    End Sub

    Private Sub NewThreadUpdateInterface()
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        MultiUserControl1.ShowLoading()

        Try
            Dim newTask = New Task(AddressOf UpdateInterfaceLocking)

            newTask.ContinueWith(Sub(x)
                                     MultiUserControl1.SafeInvokeEx(Sub(control As MultiUserViewer) control.StopLoading())
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
        Offset -= USERS_PER_PAGE
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        UpdateContents()
    End Sub

    Private Sub btnNextPage_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        Offset += USERS_PER_PAGE
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        UpdateContents()
    End Sub

    Private Sub ServiceUserViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateContents()
    End Sub
End Class


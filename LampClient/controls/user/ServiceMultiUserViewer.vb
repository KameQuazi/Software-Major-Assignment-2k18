Imports LampCommon

Public Class ServiceMultiUserViewer
    Public Event UserClick(sender As Object, e As UserClickEventArgs)

    Private Sub MultiTemplateViewer1_TemplateClick(sender As Object, e As UserClickEventArgs) Handles MultiUserControl1.UserClick
        RaiseEvent UserClick(Me, e)
        ' just bubble the event
    End Sub

    Private _sortOrder As LampSort = LampSort.SubmitDateAsc
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

    Private _justMyTemplates As Boolean
    Public Property JustMyTemplates As Boolean
        Get
            Return _justMyTemplates
        End Get
        Set(value As Boolean)
            _justMyTemplates = value
            If IsHandleCreated Then
                UpdateContents()
            End If
        End Set
    End Property

    Private Function GetFilteredUserList() As List(Of String)
        If JustMyTemplates Then
            Return New List(Of String) From {CurrentUser.UserId}
        Else
            Return New List(Of String)
        End If
    End Function

    Private Const TEMPLATES_PER_PAGE = 8

    Public Property Offset = 0

    Private Sub UpdateInterfaceLocking()
        Try
            SyncLock CurrentSender
                ' check if the next page exists (offset - tempaltes-per-page)
                If Offset - TEMPLATES_PER_PAGE >= 0 Then
                    Dim previousPage = CurrentSender.GetTemplateList(CurrentUser.ToCredentials,
                                                        Nothing, GetFilteredUserList,
                                                        TEMPLATES_PER_PAGE, Offset - TEMPLATES_PER_PAGE, ApprovedType, SortOrder)
                    If previousPage.Status = LampStatus.OK Then
                        If previousPage.Templates.Count() > 0 Then
                            Me.SafeInvokeEx(Sub(control As ServiceTemplateViewer) control.btnPreviousPage.Enabled = True)
                        Else
                            Me.SafeInvokeEx(Sub(control As ServiceTemplateViewer) control.btnPreviousPage.Enabled = False)
                        End If
                    Else
                        ShowError(previousPage.Status)
                        Return
                    End If
                Else
                    Me.SafeInvokeEx(Sub(control As ServiceTemplateViewer) control.btnPreviousPage.Enabled = False)
                End If


                Dim request = CurrentSender.GetTemplateList(CurrentUser.ToCredentials,
                                                               Nothing, GetFilteredUserList,
                                                               TEMPLATES_PER_PAGE, Offset, ApprovedType, SortOrder)

                If request.Status <> LampStatus.OK Then
                    ShowError(request.Status)
                    Return
                End If

                ' actually aadd the templates
                MultiUserControl1.SafeInvokeEx(Sub(control As MultiTemplateViewer) control.Suspend())
                MultiUserControl1.SafeInvokeEx(Sub(control As MultiTemplateViewer) control.Templates.Clear())

                For Each item In request.Templates
                    MultiUserControl1.SafeInvokeEx(Sub(control As MultiTemplateViewer) control.Templates.Add(item))
                Next
                MultiUserControl1.SafeInvokeEx(Sub(control As MultiTemplateViewer) control.EndSuspend())

                ' check if the next page exists
                If Offset + TEMPLATES_PER_PAGE >= 0 Then
                    Dim previousPage = CurrentSender.GetTemplateList(CurrentUser.ToCredentials,
                                                            Nothing, GetFilteredUserList,
                                                            TEMPLATES_PER_PAGE, Offset + TEMPLATES_PER_PAGE, ApprovedType, SortOrder)
                    If previousPage.Status = LampStatus.OK Then
                        If previousPage.Templates.Count() > 0 Then
                            Me.SafeInvokeEx(Sub(control As ServiceTemplateViewer) control.btnNextPage.Enabled = True)
                        Else
                            Me.SafeInvokeEx(Sub(control As ServiceTemplateViewer) control.btnNextPage.Enabled = False)
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
        MultiTemplateViewer1.ShowLoading()

        Try
            Dim newTask = New Task(AddressOf UpdateInterfaceLocking)

            newTask.ContinueWith(Sub(x)
                                     MultiTemplateViewer1.SafeInvokeEx(Sub(control As MultiTemplateViewer) control.StopLoading())
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
        Offset -= TEMPLATES_PER_PAGE
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        UpdateContents()
    End Sub

    Private Sub btnNextPage_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        Offset += TEMPLATES_PER_PAGE
        btnNextPage.Enabled = False
        btnPreviousPage.Enabled = False
        UpdateContents()
    End Sub
End Class

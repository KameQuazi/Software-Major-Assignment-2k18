Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports LampCommon

<DefaultEvent("JobClick")>
Public Class MultiJobViewer
    Public Event JobClick(sender As Object, e As JobClickedEventArgs)

    Public Event ApproveClick(sender As Object, job As LampJobEventArgs)
    Public Event ViewDrawingClick(sender As Object, job As LampJobEventArgs)
    Public Event AdvancedClick(sender As Object, job As LampJobEventArgs)

    Private Sub ApproveClickHandler(sender As Object, job As LampJobEventArgs)
        RaiseEvent ApproveClick(Me, job)
    End Sub

    Private Sub ViewDrawingClickHandler(sender As Object, job As LampJobEventArgs)
        RaiseEvent ViewDrawingClick(Me, job)
    End Sub

    Private Sub AdvancedHandler(sender As Object, job As LampJobEventArgs)
        RaiseEvent AdvancedClick(Me, job)
    End Sub




    Public ReadOnly Property Jobs As ObservableCollection(Of LampJob)

    Private _columns As Integer = 1
    Public Property Columns As Integer
        Get
            Return _columns
        End Get
        Set(value As Integer)
            _columns = value
            UpdateViewers(Nothing, Nothing)
        End Set
    End Property

    Private _rows As Integer = 3
    Public Property Rows As Integer
        Get
            Return _rows
        End Get
        Set(value As Integer)
            _rows = value
            UpdateViewers(Nothing, Nothing)
        End Set
    End Property


    Private _jobCursor As Cursor = Windows.Forms.Cursors.Hand
    Public Property JobCursor As Cursor
        Get
            Return _jobCursor
        End Get
        Set(value As Cursor)
            _jobCursor = value
            For Each item As TemplateDisplay In TableLayoutPanel1.Controls
                item.Cursor = value
            Next
        End Set
    End Property


    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Jobs = New ObservableCollection(Of LampJob)
        AddHandler Jobs.CollectionChanged, AddressOf UpdateViewers

    End Sub

    Private Sub UpdateViewers(sender As Object, e As NotifyCollectionChangedEventArgs)
        If _suspend Then
            Return
        End If
        SuspendLayout()
        TableLayoutPanel1.Controls.Clear()

        TableLayoutPanel1.RowCount = 0
        TableLayoutPanel1.RowStyles.Clear()
        For i = 1 To Rows
            TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 1 / Rows))
        Next
        TableLayoutPanel1.RowCount = Rows

        TableLayoutPanel1.ColumnCount = Columns
        TableLayoutPanel1.ColumnStyles.Clear()
        For i = 1 To Columns
            TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 1 / Columns))
        Next

        If Jobs.Count > 0 Then


            For Each job In Jobs
                Dim newViewer As New JobDisplay() With {
                    .Job = job,
                    .Dock = DockStyle.Fill
                }
                AddHandler newViewer.Click, AddressOf HandleJobClicked
                AddHandler newViewer.AdvancedClick, AddressOf AdvancedHandler
                AddHandler newViewer.ViewDrawingClicks, AddressOf ViewDrawingClickHandler

                TableLayoutPanel1.Controls.Add(newViewer)

            Next
            lblNoTemplates.Visible = False
        Else
            lblNoTemplates.Visible = True
        End If
        ResumeLayout()
    End Sub

    Private Sub HandleJobClicked(sender As Object, e As EventArgs)
        Dim item As JobDisplay = sender
        HandleJobClicked(New JobClickedEventArgs(item.Job))
    End Sub

    Public Sub HandleJobClicked(args As JobClickedEventArgs)
        RaiseEvent JobClick(Me, args)
    End Sub

    Public Sub StopLoading()
        TableLayoutPanel2.Visible = False
    End Sub


    Public Sub ShowLoading()
        TableLayoutPanel2.Visible = True
        LoadingPictureBox.Visible = True
    End Sub

    Private _suspend As Boolean = False
    Public Sub Suspend()
        _suspend = True
    End Sub

    Public Sub EndSuspend(Optional doUpdate As Boolean = True)
        _suspend = False
        If doUpdate Then
            UpdateViewers(Nothing, Nothing)
        End If
    End Sub


    ' enable double buffering
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get

            Dim baseParams = MyBase.CreateParams
            baseParams.ExStyle = baseParams.ExStyle Or &H2000000 ' magic number that enables double buffering
            Return baseParams
        End Get
    End Property

End Class

Public Class JobClickedEventArgs
    Inherits EventArgs
    Public Property Job As LampJob

    Public Sub New(job As LampJob)
        Me.Job = job
    End Sub
End Class

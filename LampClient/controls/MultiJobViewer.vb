Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports LampCommon

Public Class MultiJobViewer
    Public ReadOnly Property Jobs As ObservableCollection(Of LampJob)

    Private ReadOnly Property NewColumnStyle As ColumnStyle
        Get
            Return New ColumnStyle(SizeType.AutoSize)
        End Get
    End Property

    Private ReadOnly Property NewRowStyle As RowStyle
        Get
            Return New RowStyle(SizeType.AutoSize)
        End Get
    End Property

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

    Private _rows As Integer = 5
    Public Property Rows As Integer
        Get
            Return _rows
        End Get
        Set(value As Integer)
            _rows = value
            UpdateViewers(Nothing, Nothing)
        End Set
    End Property


    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Jobs = New ObservableCollection(Of LampJob)
        AddHandler Jobs.CollectionChanged, AddressOf UpdateViewers
        Me.TableLayoutPanel1.Padding = New Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0)
        Me.TableLayoutPanel1.ColumnCount = Columns

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



        For Each job In Jobs

            TableLayoutPanel1.Controls.Add(New JobDisplay() With {.Job = job, .Dock = DockStyle.Fill})

        Next

        ResumeLayout()
    End Sub

    Friend Sub StopLoading()
        LoadingPictureBox.Visible = False
    End Sub

    Friend Sub ShowLoading()
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

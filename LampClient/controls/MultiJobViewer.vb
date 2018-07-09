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

    Public Const Columns = 1


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

        Dim count = 0
        For Each job In Jobs
            If count Mod Columns = 0 Then
                TableLayoutPanel1.RowCount += 1
                TableLayoutPanel1.RowStyles.Add(NewRowStyle)
            End If

            TableLayoutPanel1.Controls.Add(New JobDisplay() With {.Job = job, .Dock = DockStyle.Fill})

            count += 1
        Next

        ResumeLayout()
    End Sub

    Friend Sub StopLoading()
        'LoadingPictureBox.Visible = False
    End Sub

    Friend Sub ShowLoading()
        'LoadingPictureBox.Visible = True
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

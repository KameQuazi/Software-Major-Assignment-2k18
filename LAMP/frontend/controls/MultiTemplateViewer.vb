Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Public Class MultiTemplateViewer
    Public ReadOnly Property Templates As ObservableCollection(Of LampTemplate)

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

    Public Const Columns = 4


    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Templates = New ObservableCollection(Of LampTemplate)
        AddHandler Templates.CollectionChanged, AddressOf UpdateViewers
        Me.GridPanel.Padding = New Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0)
    End Sub

    Private Sub UpdateViewers(sender As Object, e As NotifyCollectionChangedEventArgs)
        If _suspend Then
            Return
        End If
        SuspendLayout()
        GridPanel.Controls.Clear()

        GridPanel.RowCount = 0
        GridPanel.RowStyles.Clear()

        Dim count = 0
        For Each template In Templates
            If count Mod Columns = 0 Then
                GridPanel.RowCount += 1
                GridPanel.RowStyles.Add(NewRowStyle)
            End If

            GridPanel.Controls.Add(New FileDisplay() With {.Template = template})

            count += 1
        Next

        ResumeLayout()
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

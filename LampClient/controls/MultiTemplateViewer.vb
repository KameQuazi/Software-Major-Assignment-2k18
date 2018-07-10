Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports LampCommon

Public Class MultiTemplateViewer
    Public ReadOnly Property Templates As ObservableCollection(Of LampTemplate)

    Public Overrides Property AutoScroll As Boolean
        Get
            Return GridPanel.AutoScroll
        End Get
        Set(value As Boolean)
            GridPanel.AutoScroll = value
        End Set
    End Property


    Private _columns As Integer = 4
    Public Property Columns As Integer
        Get
            Return _columns
        End Get
        Set(value As Integer)
            _columns = value
            UpdateViewers(Nothing, Nothing)
        End Set
    End Property

    Private _rows As Integer = 2
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
        For i = 1 To Rows
            GridPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 1 / Rows))
        Next
        GridPanel.RowCount = Rows

        GridPanel.ColumnCount = Columns
        GridPanel.ColumnStyles.Clear()
        For i = 1 To Columns
            GridPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 1 / Columns))
        Next

        If Templates.Count > 0 Then

            For Each template In Templates
                GridPanel.Controls.Add(New FileDisplay() With {.Template = template, .Dock = DockStyle.Fill})
            Next
            lblNoTemplates.Visible = False
        Else
            lblNoTemplates.Visible = True
        End If



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

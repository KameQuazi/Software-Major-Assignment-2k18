Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports LampClient
Imports LampCommon



Public Class MultiTemplateViewer
    Public Event TemplateClick(sender As Object, e As TemplateClickedEventArgs)

    Public ReadOnly DefaultTemplateMargin As New Padding(12, 12, 12, 12)

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

    Public Property MouseOverHighlight As Boolean = False

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Templates = New ObservableCollection(Of LampTemplate)
        AddHandler Templates.CollectionChanged, AddressOf UpdateViewers
        Me.GridPanel.Padding = New Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0)
    End Sub


    Private Sub HandleTemplateClicked(sender As Object, e As EventArgs)
        Dim item As FileDisplay = sender
        HandleTemplateClicked(New TemplateClickedEventArgs() With {
                              .Index = GridPanel.Controls.IndexOf(item),
                              .Template = item.Template})
    End Sub

    Public Sub HandleTemplateClicked(args As TemplateClickedEventArgs)
        RaiseEvent TemplateClick(Me, args)
    End Sub


    Private Sub UpdateViewers(sender As Object, e As NotifyCollectionChangedEventArgs)
        If _suspend Then
            Return
        End If

        SuspendLayout()
        For Each item As FileDisplay In GridPanel.Controls
            RemoveHandler item.Click, AddressOf HandleTemplateClicked
        Next

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
                Dim newViewer As New FileDisplay() With {
                                       .Template = template,
                                       .Dock = DockStyle.Fill,
                                       .MouseOverHighlight = Me.MouseOverHighlight,
                                       .Margin = DefaultTemplateMargin
                                       }
                AddHandler newViewer.Click, AddressOf HandleTemplateClicked


                GridPanel.Controls.Add(newViewer)
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

Public Class TemplateClickedEventArgs
    Inherits EventArgs
    Public Property Index As Integer = -1
    Public Property Template As LampTemplate

End Class
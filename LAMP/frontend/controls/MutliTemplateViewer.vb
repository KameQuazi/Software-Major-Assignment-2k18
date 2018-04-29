Public Class MutliTemplateViewer
    Private Property TemplateViewers As New List(Of FileDisplay)


    Private NewColumnStyle As Func(Of ColumnStyle) = Function() New ColumnStyle(SizeType.AutoSize)

    Private NewRowStyle As Func(Of RowStyle) = Function() New RowStyle(SizeType.AutoSize)

    Private _columnCount As Integer = 2

    Public Property ColumnCount As Integer
        Get
            Return _columnCount
        End Get
        Set(value As Integer)
            _columnCount = value
            UpdateGridColumns()
            AddViewersIfNeeded()
        End Set
    End Property

    Private _rowCount As Integer = 2

    Public Property RowCount As Integer
        Get
            Return _rowCount
        End Get
        Set(value As Integer)
            _rowCount = value
            UpdateGridRows()
            AddViewersIfNeeded()
        End Set
    End Property

    Private Sub UpdateGridColumns()
        GridPanel.ColumnCount = ColumnCount
        GridPanel.ColumnStyles.Clear()

        For i = 0 To ColumnCount - 1
            GridPanel.ColumnStyles.Add(NewColumnStyle())
        Next
    End Sub

    Private Sub UpdateGridRows()
        GridPanel.RowCount = RowCount
        GridPanel.RowStyles.Clear()

        For i = 0 To RowCount - 1
            GridPanel.RowStyles.Add(NewRowStyle())
        Next
    End Sub

    Private Sub AddViewersIfNeeded()
        Dim viewersRequired As Integer = RowCount * ColumnCount
        Dim totalViewers As Integer = TemplateViewers.Count
        If viewersRequired > TemplateViewers.Count Then
            For i = 0 To (viewersRequired - TemplateViewers.Count - 1)
                Dim viewer As New FileDisplay()
                TemplateViewers.Add(viewer)
                GridPanel.Controls.Add(viewer)
            Next
        ElseIf viewersRequired < TemplateViewers.Count Then
            ' check if there are too many
            GridPanel.Controls.Clear()
            ' Index ViewersRequired = index N, or the N+1 th element
            ' However, removeRange is inclusive first element,
            ' meaning that it ill remove the N+1th -> end element
            ' COunt = total - (N+1) + 1, to remove total-N elements, leaving it with N elements
            TemplateViewers.RemoveRange(viewersRequired, TemplateViewers.Count - )

        End If
    End Sub



    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UpdateViewers()
    End Sub

    Private Sub UpdateViewers()
        TemplateViewers.Clear()

        GridPanel.SuspendLayout()

        ' clear out the viewers in the panels
        GridPanel.Controls.Clear()
        AddViewersIfNeeded()

        GridPanel.ResumeLayout()
    End Sub
End Class

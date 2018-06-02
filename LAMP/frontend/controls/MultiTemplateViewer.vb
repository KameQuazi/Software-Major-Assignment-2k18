Public Class MultiTemplateViewer
    Private Property TemplateViewers As New Dictionary(Of Point, FileDisplay)


    Private ReadOnly Property NewColumnStyle As ColumnStyle
        Get
            Return New ColumnStyle(SizeType.Percent, (1 / ColumnCount).ToSingle)
        End Get
    End Property

    Private ReadOnly Property NewRowStyle As RowStyle
        Get
            Return New RowStyle(SizeType.Percent, (1 / RowCount).ToSingle)
        End Get
    End Property

    Private _columnCount As Integer = 4

    Public Property ColumnCount As Integer
        Get
            Return _columnCount
        End Get
        Set(value As Integer)
            _columnCount = value
            UpdateGridColumns()
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





    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


    End Sub


    Private Sub ForceUpdateViewer()

        GridPanel.SuspendLayout()

        ' clear out the viewers in the panels
        GridPanel.Controls.Clear()
        For Each item As KeyValuePair(Of Point, FileDisplay) In TemplateViewers
            Dim location As Point = item.Key
            Dim viewer As FileDisplay = item.Value
            ' Add(Control, column, row)
            GridPanel.Controls.Add(viewer, location.X, location.Y)
        Next

        GridPanel.ResumeLayout(False)

    End Sub

    Public Function GetControlFromPosition(column As Integer, row As Integer) As FileDisplay
        Return DirectCast(GridPanel.GetControlFromPosition(column, row), FileDisplay)
    End Function

    Public Function GetTemplateFromPosition(column As Integer, row As Integer) As LampTemplate
        Dim filedisplay = DirectCast(GridPanel.GetControlFromPosition(column, row), FileDisplay)
        Return filedisplay.Template
    End Function

    Public Function RemoveViewerAsFD(column As Integer, row As Integer) As FileDisplay
        Dim pos = New Point(column, row)
        If Not TemplateViewers.ContainsKey(pos) Then
            Throw New ArgumentOutOfRangeException(String.Format("Position specified has no element"))
        End If
        Dim fileDisplay = GetControlFromPosition(column, row)
        TemplateViewers.Remove(pos)
        GridPanel.Controls.Remove(fileDisplay)
        Return fileDisplay
    End Function

    Public Function RemoveTemplate(column As Integer, row As Integer) As LampTemplate
        Return RemoveViewerAsFD(column, row).Template
    End Function


    Public Sub SetViewerToPosition(column As Integer, row As Integer, display As FileDisplay)
        ' >= used as columncount is 1 index, column is 0 indexed
        While column > GridPanel.ColumnStyles.Count
            GridPanel.ColumnStyles.Add(NewColumnStyle)
        End While

        While row > GridPanel.RowStyles.Count
            GridPanel.RowStyles.Add(NewRowStyle)
        End While
        Dim location = New Point(column, row)
        TemplateViewers(location) = display


        ' remove filedisplay if necessary
        Dim originalControl = GridPanel.GetControlFromPosition(column, row)
        If originalControl IsNot Nothing Then
            GridPanel.Controls.Remove(originalControl)
        End If

        ' add new filedisplay
        GridPanel.Controls.Add(display, column, row)
    End Sub

    Public Sub SetTemplateToPosition(column As Integer, row As Integer, template As LampTemplate)
        SetViewerToPosition(column, row, New FileDisplay() With {.Template = template})
    End Sub



End Class

Public Class MultiTemplateViewer
    Private Property TemplateViewers As New Dictionary(Of Point, FileDisplay)

    Private NewColumnStyle As Func(Of ColumnStyle) = Function() New ColumnStyle(SizeType.AutoSize)

    Private NewRowStyle As Func(Of RowStyle) = Function() New RowStyle(SizeType.AutoSize)

    Private _columnCount As Integer = 4

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

        ' set flag to update the grid if necessary
        Dim mustUpdateGrid As Boolean = False

        ' trim the columns
        For Each key As Point In TemplateViewers.Keys
            ' greater or equal here, as column is 1 indexed, while X is 0 indexed
            If key.X >= ColumnCount OrElse key.Y >= RowCount Then
                TemplateViewers.Remove(key)
            End If
        Next

        ' check if there are any gaps in the Grid
        For row = 0 To RowCount - 1
            For col = 0 To ColumnCount - 1
                Dim pos As New Point(col, row)
                If Not TemplateViewers.ContainsKey(pos) Then
                    mustUpdateGrid = True
                    ' add a new viewer into that spot
                    Dim viewer As New FileDisplay

                    TemplateViewers(pos) = viewer
                End If
            Next
        Next


        If mustUpdateGrid Then
            ForceUpdateViewer()
        End If
    End Sub



    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddViewersIfNeeded()
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

    Public Sub SetViewerToPosition(column As Integer, row As Integer, display As FileDisplay)
        ' >= used as columncount is 1 index, column is 0 indexed
        If column >= ColumnCount Then
            Throw New ArgumentOutOfRangeException(NameOf(column))
        End If
        If row >= RowCount Then
            Throw New ArgumentOutOfRangeException(NameOf(row))
        End If
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

    Public Sub LoadExample()
        SetTemplateToPosition(0, 0, TemplateDatabase.GetExampleTemplate("one"))
        SetTemplateToPosition(1, 0, TemplateDatabase.GetExampleTemplate("two"))
        SetTemplateToPosition(2, 0, TemplateDatabase.GetExampleTemplate("three"))
        SetTemplateToPosition(3, 0, TemplateDatabase.GetExampleTemplate("four"))


        SetTemplateToPosition(0, 1, TemplateDatabase.GetExampleTemplate("five"))
        SetTemplateToPosition(1, 1, TemplateDatabase.GetExampleTemplate("six"))
        SetTemplateToPosition(2, 1, TemplateDatabase.GetExampleTemplate("seven"))
        SetTemplateToPosition(3, 1, TemplateDatabase.GetExampleTemplate("eight"))
    End Sub

    Private Sub GridPanel_Paint(sender As Object, e As PaintEventArgs) Handles GridPanel.Paint

    End Sub
End Class

Public Class MultipleTemplateViewer
    Private _rowCount As Integer = 2
    Private _columnCount As Integer = 4

    Private _startIndex As Integer = 0

    Public Property Items As TemplateItemCollection

    Public Property RowCount As Integer
        Get
            Return _rowCount
        End Get
        Set(value As Integer)
            _rowCount = value
            ResetLayout()
        End Set
    End Property

    Public Property ColumnCount As Integer
        Get
            Return _columnCount
        End Get
        Set(value As Integer)
            _columnCount = value
            ResetLayout()
        End Set
    End Property

    Private Sub MultipleTemplateViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Items = New TemplateItemCollection(Me)
    End Sub

    Private Sub ResetLayout()
        TableLayoutPanel1.RowCount = Me.RowCount
        TableLayoutPanel1.ColumnCount = Me.ColumnCount
    End Sub

    Private Function TotalItemsShown() As Integer
        Return _rowCount * _columnCount
    End Function

    Private Sub UpdateItems()
        For pos As Integer = 0 To TotalItemsShown()
            Dim index = pos + _startIndex
            If Items.Count > index Then
                Dim singleTemplate As New FileDisplay
                Me.Controls.Add(singleTemplate)

                singleTemplate.Template = DirectCast(Items(index), LampTemplate)
                TableLayoutPanel1.SetRow(singleTemplate, GetRow(pos))
                TableLayoutPanel1.SetColumn(singleTemplate, GetCol(pos))
            End If
        Next
    End Sub


    Private Function GetRow(index As Integer) As Integer
        Return Convert.ToInt32(index / ColumnCount)
    End Function

    Private Function GetCol(index As Integer) As Integer
        Return index Mod ColumnCount
    End Function

    Public Class TemplateItemCollection
        Implements IList, ICollection, IEnumerable

        Private _templates As New List(Of LampTemplate)

        Private owner As MultipleTemplateViewer

        Sub New(owner As MultipleTemplateViewer)
            Me.owner = owner
        End Sub

#Region "IList Normal"

        Public ReadOnly Property Count As Integer Implements ICollection.Count
            Get
                Return DirectCast(_templates, IList).Count
            End Get
        End Property

        Public ReadOnly Property IsFixedSize As Boolean Implements IList.IsFixedSize
            Get
                Return DirectCast(_templates, IList).IsFixedSize
            End Get
        End Property

        Public ReadOnly Property IsReadOnly As Boolean Implements IList.IsReadOnly
            Get
                Return DirectCast(_templates, IList).IsReadOnly
            End Get
        End Property

        Public ReadOnly Property IsSynchronized As Boolean Implements ICollection.IsSynchronized
            Get
                Return DirectCast(_templates, IList).IsSynchronized
            End Get
        End Property

        Default Public Property Item(index As Integer) As Object Implements IList.Item
            Get
                Return DirectCast(_templates, IList)(index)
            End Get
            Set(value As Object)
                DirectCast(_templates, IList)(index) = value
            End Set
        End Property

        Public ReadOnly Property SyncRoot As Object Implements ICollection.SyncRoot
            Get
                Return DirectCast(_templates, IList).SyncRoot
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return DirectCast(_templates, IList).GetEnumerator()
        End Function

        Public Function IndexOf(value As Object) As Integer Implements IList.IndexOf
            Return DirectCast(_templates, IList).IndexOf(value)
        End Function
#End Region

#Region "IList updateowner"
        Public Sub Clear() Implements IList.Clear
            DirectCast(_templates, IList).Clear()
            owner.UpdateItems()
        End Sub

        Public Sub CopyTo(array As Array, index As Integer) Implements ICollection.CopyTo
            DirectCast(_templates, IList).CopyTo(array, index)
            owner.UpdateItems()
        End Sub

        Public Sub Insert(index As Integer, value As Object) Implements IList.Insert
            DirectCast(_templates, IList).Insert(index, value)
            owner.UpdateItems()
        End Sub

        Public Sub Remove(value As Object) Implements IList.Remove
            DirectCast(_templates, IList).Remove(value)
            owner.UpdateItems()
        End Sub

        Public Sub RemoveAt(index As Integer) Implements IList.RemoveAt
            DirectCast(_templates, IList).RemoveAt(index)
            owner.UpdateItems()
        End Sub

        Public Function Add(value As Object) As Integer Implements IList.Add
            Dim val = DirectCast(_templates, IList).Add(value)
            owner.UpdateItems()
            Return val
        End Function

        Public Function Contains(value As Object) As Boolean Implements IList.Contains
            Dim val = DirectCast(_templates, IList).Contains(value)
            owner.UpdateItems()
            Return val
        End Function

#End Region

    End Class
End Class


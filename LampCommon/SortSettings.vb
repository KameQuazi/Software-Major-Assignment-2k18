<Serializable>
Public Class SortSettings
    Public Property SortHidden As Boolean
    Public Property SortType As LampSort
    Public Property ByMe As Boolean

    Public Sub New(sortHidden As Boolean, sortType As LampSort, byMe As Boolean)
        Me.SortHidden = sortHidden
        Me.SortType = sortType
        Me.ByMe = byMe
    End Sub

    Public Sub New()

    End Sub
End Class
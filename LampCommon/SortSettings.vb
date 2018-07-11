<Serializable>
Public Class SortSettings
    Public Property SortHidden As Boolean
    Public Property SortType As LampSort

    Public Sub New(sortHidden As Boolean, sortType As LampSort)
        Me.SortHidden = sortHidden
        Me.SortType = sortType
    End Sub

    Public Sub New()

    End Sub
End Class
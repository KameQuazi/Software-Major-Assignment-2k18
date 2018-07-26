<Serializable>
Public Class SortSettings
    Public Property SortHidden As Boolean
    Public Property SortType As LampSort
    Public Property ByMe As Boolean
    Public Property ApproveStatus As LampApprove

    Public Sub New(sortHidden As Boolean, sortType As LampSort, byMe As Boolean, approveStatus As LampApprove)
        Me.SortHidden = sortHidden
        Me.SortType = sortType
        Me.ByMe = byMe
        Me.ApproveStatus = approveStatus
    End Sub

    Public Sub New()

    End Sub
End Class
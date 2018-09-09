<Serializable>
Public Class LampWcfClientSettings
    Public Property UseLocal As Boolean
    Public Property ServerAddress As String

    Sub New(useLocal As Boolean, serverAddress As String)
        Me.UseLocal = useLocal
        Me.ServerAddress = serverAddress
    End Sub

    Public Sub New()

    End Sub
End Class

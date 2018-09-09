Imports System.Runtime.Serialization

<Serializable>
Public Class OpenType
    Public Property Internal As Boolean
    Public Property ProgramPath As String

    Sub New(internal As Boolean, programPath As String)
        Me.Internal = internal
        Me.ProgramPath = programPath
    End Sub

    Public Sub New()

    End Sub
End Class
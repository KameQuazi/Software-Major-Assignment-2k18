Imports System.Runtime.Serialization

<DataContract>
Public Class LampVersion
    Public Property ProgramName As String = "LAMP"
    Public Property Version As String = "0.0.0"

    Public Shared ReadOnly GetVersion As LampVersion = New LampVersion()
End Class

Public Class LampJob
    Public Property GUID As String
    Public Property Template As LampTemplate
    Public Property SubmitId As String
    Public Property ApproverId As String
    Public Property Approved As Boolean


    Sub New(template As LampTemplate, SubmitID As String)

        If template Is Nothing Then
            Throw New ArgumentNullException(NameOf(template))
        End If
        Me.GUID = System.Guid.NewGuid().ToString()
        Me.Template = template
        Me.SubmitId = SubmitID
        Me.ApproverId = System.Guid.Empty.ToString()

    End Sub

End Class

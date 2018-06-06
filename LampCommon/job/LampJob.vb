Imports System.Runtime.Serialization

<DataContract>
Public Class LampJob
    Public Property JobId As String

    Public Property Template As LampTemplate

    Public Property Submitter As LampUser

    Public Property Approver As LampUser

    Public Property Approved As Boolean

    Public Property SubmitId As String
        Get
            Return Submitter.UserId
        End Get
        Set(value As String)
            Submitter.UserId = value
        End Set
    End Property

    Public Property ApproverId As String
        Get
            If Approver Is Nothing Then
                Return Nothing
            End If
            Return Approver.UserId
        End Get
        Set(value As String)
            If Approver Is Nothing Then
                Throw New ArgumentNullException(NameOf(Approver) + " cannot be nothing")
            End If
            Approver.UserId = value
        End Set
    End Property


    Sub New(template As LampTemplate, submitter As LampUser, Optional approver As LampUser = Nothing, Optional approved As Boolean = False)

        If template Is Nothing Then
            Throw New ArgumentNullException(NameOf(template))
        End If
        Me.JobId = System.Guid.NewGuid().ToString()
        Me.Template = template
        Me.Submitter = submitter
        Me.Approver = approver
        Me.Approved = approved

    End Sub

End Class

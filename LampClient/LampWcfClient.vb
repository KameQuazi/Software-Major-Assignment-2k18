Imports LampCommon

''' <summary>
''' Run on the vclient machine
''' does not have full access to the db, only through a LampReciever
''' </summary>
Public Class LampWcfClient
    Public Property Protocol As LampCommunication
    Public Property Address As String

    ''' <summary>
    ''' Only used if the protocol is Local. Internal receiver 
    ''' </summary>
    ''' <returns></returns>
    Private Property Reciever As LampService


    Sub New(protocol As LampCommunication)
        If protocol.Type = SubmitType.Local Then
            Reciever = New LampService(New LampCommunication(SubmitType.Local))
        Else
            Throw New NotImplementedException("server not implemented")
        End If

        Me.Protocol = protocol

    End Sub

    ''' <summary>
    ''' Send template to a web or ip address, or to internal db.
    ''' </summary>
    Public Sub SubmitTemplate(template As LampTemplate, user As LampUser)
        If Protocol.Type = SubmitType.Local Then
            Reciever.QueueJob(template, user)
        End If
    End Sub

    ''' <summary>
    ''' Sends a job
    ''' </summary>
    ''' <param name="job"></param>
    ''' <param name="user"></param>
    Public Sub SubmitJob(job As LampJob, user As LampJob)
        Throw New NotImplementedException()
        ' TODO
    End Sub

    Public Function Authenticate(username As String, password As String) As LampUser
        If Protocol.Type = SubmitType.Local Then
            Dim wrapper = Reciever.Authenticate(username, password)
            Return wrapper.user
        End If

        Throw New NotImplementedException()
    End Function

    Public Function RequestTemplates(currentUser As LampUser, tags As IEnumerable(Of String)) As List(Of LampTemplate)
        Throw New NotImplementedException()
    End Function



    Public Shared Local As New LampWcfClient(LampCommunication.Local)

    ''' <summary>
    ''' Takes a username + password 
    ''' </summary>
    ''' <param name="username"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    Public Shared Function LoginUser(username As String, password As String, sender As LampWcfClient) As LampUser

        Return sender.Authenticate(username, password)
    End Function

    Public Sub AddUnapprovedTemplate()
        Throw New NotImplementedException()
    End Sub

    Public Sub AddTemplate(template As LampTemplate, user As LampUser)
        ' TODO check if user has permissions
        Reciever.AddTemplate(template, user)

    End Sub
End Class




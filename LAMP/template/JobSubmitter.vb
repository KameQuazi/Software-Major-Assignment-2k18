﻿Public Class LampSender
    Public Property Protocol As LampCommunication
    Public Property Address As String

    ''' <summary>
    ''' Only used if the protocol is Local. Internal receiver 
    ''' </summary>
    ''' <returns></returns>
    Private Property LocalReceiver As LampReciever

    Sub New(protocol As LampCommunication)
        If protocol.Type = SubmitType.Local Then
            LocalReceiver = New LampReciever(New LampCommunication(SubmitType.Local))
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
            LocalReceiver.ReceiveTemplate(template, user)
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
            Return LocalReceiver.Authenticate(username, password)
        End If

        Throw New NotImplementedException()
    End Function
End Class

Public Enum SubmitType
    Local
    Server
End Enum

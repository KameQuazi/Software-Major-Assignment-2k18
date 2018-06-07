﻿Imports System.ServiceModel
Imports LampCommon
Imports LampService

<ServiceContract(ConfigurationName:="ILampService")>
Public Interface ILampClientService
    Inherits ILampService

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ILampService/Authenticate", ReplyAction:="http://tempuri.org/ILampService/AuthenticateResponse")>
    Function AuthenticateAsync(ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampUserWrapper)

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ILampService/AddTemplate", ReplyAction:="http://tempuri.org/ILampService/AddTemplateResponse")>
    Function AddTemplateAsync(ByVal template As LampCommon.LampTemplate, ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampStatus)

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ILampService/QueueJob", ReplyAction:="http://tempuri.org/ILampService/QueueJobResponse")>
    Function QueueJobAsync(ByVal job As LampCommon.LampJob, ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampStatus)

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ILampService/GetTemplate", ReplyAction:="http://tempuri.org/ILampService/GetTemplateResponse")>
    Function GetTemplateAsync(ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampTemplateWrapper)

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ILampService/GetAllTemplate", ReplyAction:="http://tempuri.org/ILampService/GetAllTemplateResponse")>
    Function GetAllTemplateAsync(ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of List(Of LampCommon.LampTemplate))
End Interface

''' <summary>
''' Run on the client machine, has an internal receiver
''' </summary>
Public Class LampLocalWcfClient
    Implements ILampClientService

    Private Property Service As ILampClientService

    Public Shared ReadOnly Local As New LampLocalWcfClient(New LampService.LampService)

    Public Function Authenticate(username As String, password As String) As LampUserWrapper
        Return Authenticate(New LampCredentials(username, password))
    End Function

    Sub New(service As ILampClientService)
        Me.Service = service
    End Sub


#Region "ILampService"
    Public Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampClientService.Authenticate
        Return Service.Authenticate(credentials)
    End Function

    Public Function AddTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampClientService.AddTemplate
        Return Service.AddTemplate(template, credentials)
    End Function

    Public Function QueueJob(job As LampJob, credentials As LampCredentials) As LampStatus Implements ILampClientService.QueueJob
        Return Service.QueueJob(job, credentials)
    End Function

    Public Function GetTemplate(credentials As LampCredentials) As LampTemplateWrapper Implements ILampClientService.GetTemplate
        Return Service.GetTemplate(credentials)
    End Function

    Public Function AuthenticateAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampClientService.AuthenticateAsync
        Return Service.AuthenticateAsync(credentials)
    End Function

    Public Function AddTemplateAsync(template As LampTemplate, credentials As LampCredentials) As Task(Of LampStatus) Implements ILampClientService.AddTemplateAsync
        Return Service.AddTemplateAsync(template, credentials)
    End Function

    Public Function QueueJobAsync(job As LampJob, credentials As LampCredentials) As Task(Of LampStatus) Implements ILampClientService.QueueJobAsync
        Return Service.QueueJobAsync(job, credentials)
    End Function

    Public Function GetTemplateAsync(credentials As LampCredentials) As Task(Of LampTemplateWrapper) Implements ILampClientService.GetTemplateAsync
        Return Service.GetTemplateAsync(credentials)
    End Function

    Public Function GetAllTemplateAsync(credentials As LampCredentials) As Task(Of List(Of LampTemplate)) Implements ILampClientService.GetAllTemplateAsync
        Return Service.GetAllTemplateAsync(credentials)
    End Function


    Private Function ILampService_GetAllTemplate1(credentials As LampCredentials) As List(Of LampTemplate) Implements ILampService.GetAllTemplate
        Throw New NotImplementedException()
    End Function
#End Region
End Class

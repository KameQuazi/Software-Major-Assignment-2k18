Imports System.ServiceModel
Imports LampClient
Imports LampCommon
Imports LampService

''' <summary>
''' Client side service contract for lampservice
''' offers 
''' </summary>
<ServiceContract(ConfigurationName:="ILampService")>
Public Interface ILampClientService
    Inherits LampService.ILampService

    <System.ServiceModel.OperationContractAttribute>
    Function AuthenticateAsync(ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampUserWrapper)

    <System.ServiceModel.OperationContractAttribute>
    Function QueueJobAsync(ByVal template As LampCommon.LampTemplate, ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampStatus)

    <System.ServiceModel.OperationContractAttribute>
    Function GetTemplateAsync(ByVal template As LampCommon.LampTemplate, ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampStatus)

    <System.ServiceModel.OperationContractAttribute>
    Function AddTemplateAsync(ByVal template As LampCommon.LampTemplate, ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampStatus)

    <OperationContract>
    Function DeleteTemplateAsync(credentials As LampCredentials) As Task(Of LampStatus)

    <System.ServiceModel.OperationContractAttribute>
    Function GetAllTemplateAsync(ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of List(Of LampCommon.LampTemplate))

    <OperationContract>
    Function SelectDxfAsync(credentials As LampCredentials) As LampDxfDocumentWrapper

    <OperationContract()>
    Function AddUnapprovedTemplateAsync(template As LampTemplate, credentials As LampCredentials) As LampStatus

    <OperationContract()>
    Function DeleteUnapprovedTemplateAsync(guid As String, credentials As LampCredentials) As LampStatus

    <OperationContract()>
    Function ApproveTemplateAsync(template As LampTemplate, credentials As LampCredentials) As LampStatus

    <OperationContract()>
    Function RevokeTemplateAsync(template As LampTemplate, credentials As LampCredentials) As LampStatus

    <OperationContract>
    Function GetUserAsync(credentials As LampCredentials) As LampUserWrapper

    <OperationContract>
    Function AddUserAsync(credentials As LampCredentials, user As LampUser) As LampStatus

    <System.ServiceModel.OperationContractAttribute>
    Function QueueJobAsync(ByVal job As LampCommon.LampJob, ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampStatus)

    <System.ServiceModel.OperationContractAttribute>
    Function GetTemplateAsync(ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampTemplateWrapper)



End Interface

Public MustInherit Class LampWcfClient
    Implements ILampClientService

    Public MustOverride Function AddTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampService.AddTemplate

    Public MustOverride Function AddTemplateAsync(template As LampTemplate, credentials As LampCredentials) As Task(Of LampStatus) Implements ILampClientService.AddTemplateAsync

    Public MustOverride Function AddUnapprovedTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampService.AddUnapprovedTemplate

    Public MustOverride Function AddUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampService.AddUser

    Public MustOverride Function ApproveTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampService.ApproveTemplate

    Public MustOverride Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampService.Authenticate

    Public MustOverride Function AuthenticateAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampClientService.AuthenticateAsync

    Public MustOverride Function DeleteTemplate(credentials As LampCredentials) As LampStatus Implements ILampService.DeleteTemplate

    Public MustOverride Function DeleteUnapprovedTemplate(guid As String, credentials As LampCredentials) As LampStatus Implements ILampService.DeleteUnapprovedTemplate

    Public MustOverride Function EditUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampService.EditUser

    Public MustOverride Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate) Implements ILampService.GetAllTemplate

    Public MustOverride Function GetAllTemplateAsync(credentials As LampCredentials) As Task(Of List(Of LampTemplate)) Implements ILampClientService.GetAllTemplateAsync

    Public MustOverride Function GetTemplate(credentials As LampCredentials) As LampTemplateWrapper Implements ILampService.GetTemplate

    Public MustOverride Function GetTemplateAsync(credentials As LampCredentials) As Task(Of LampTemplateWrapper) Implements ILampClientService.GetTemplateAsync

    Public MustOverride Function GetUser(credentials As LampCredentials) As LampUserWrapper Implements ILampService.GetUser

    Public MustOverride Function QueueJob(job As LampJob, credentials As LampCredentials) As LampStatus Implements ILampService.QueueJob

    Public MustOverride Function QueueJobAsync(job As LampJob, credentials As LampCredentials) As Task(Of LampStatus) Implements ILampClientService.QueueJobAsync

    Public MustOverride Function RevokeTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampService.RevokeTemplate

    Public MustOverride Function SelectDxf(credentials As LampCredentials) As LampDxfDocumentWrapper Implements ILampService.SelectDxf
End Class

''' <summary>
''' Run on the client machine, has an internal receiver
''' </summary>
Public Class LampLocalWcfClient
    Implements ILampClientService

    Private Property Service As LampService.LampService

    Public Shared Local As LampLocalWcfClient

    Public Function Authenticate(username As String, password As String) As LampUserWrapper
        Return Authenticate(New LampCredentials(username, password))
    End Function

    Sub New(service As LampService.LampService)
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


    Private Function ILampService_GetAllTemplate1(credentials As LampCredentials) As List(Of LampTemplate) Implements LampService.ILampService.GetAllTemplate
        Throw New NotImplementedException()
    End Function

    Public Function DeleteTemplate(credentials As LampCredentials) As LampStatus Implements LampService.ILampService.DeleteTemplate
        Throw New NotImplementedException()
    End Function

    Public Function SelectDxf(credentials As LampCredentials) As LampDxfDocumentWrapper Implements LampService.ILampService.SelectDxf
        Throw New NotImplementedException()
    End Function

    Public Function AddUnapprovedTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements LampService.ILampService.AddUnapprovedTemplate
        Throw New NotImplementedException()
    End Function

    Public Function DeleteUnapprovedTemplate(guid As String, credentials As LampCredentials) As LampStatus Implements LampService.ILampService.DeleteUnapprovedTemplate
        Throw New NotImplementedException()
    End Function

    Public Function ApproveTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements LampService.ILampService.ApproveTemplate
        Throw New NotImplementedException()
    End Function

    Public Function RevokeTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements LampService.ILampService.RevokeTemplate
        Throw New NotImplementedException()
    End Function

    Public Function GetUser(credentials As LampCredentials) As LampUserWrapper Implements LampService.ILampService.GetUser
        Throw New NotImplementedException()
    End Function

    Public Function AddUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements LampService.ILampService.AddUser
        Throw New NotImplementedException()
    End Function

    Public Function EditUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements LampService.ILampService.EditUser
        Throw New NotImplementedException()
    End Function
#End Region
End Class


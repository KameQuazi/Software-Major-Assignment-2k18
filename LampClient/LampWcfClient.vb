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
    <OperationContract>
    Function GetTemplateAsync(ByVal credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper)

    <OperationContract>
    Function AddTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus)

    <OperationContract>
    Function EditTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus)

    <OperationContract>
    Function RemoveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus)

    <OperationContract>
    Function GetUserAsync(credentials As LampCredentials) As Task(Of LampUserWrapper)

    <OperationContract>
    Function AddUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus)

    <OperationContract>
    Function EditUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus)

    <OperationContract>
    Function RemoveUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus)

    <OperationContract>
    Function AuthenticateAsync(ByVal credentials As LampCredentials) As Task(Of LampUserWrapper)

    <OperationContract>
    Function GetAllTemplateAsync(credentials As LampCredentials) As Task(Of List(Of LampTemplate))

    <OperationContract()>
    Function GetUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper)

    <OperationContract>
    Function SelectDxfAsync(credentials As LampCredentials, guid As String) As Task(Of LampDxfDocumentWrapper)

    <OperationContract()>
    Function AddUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus)

    <OperationContract()>
    Function EditUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus)

    <OperationContract()>
    Function RemoveUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus)

    <OperationContract()>
    Function ApproveTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus)

    <OperationContract()>
    Function RevokeTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus)

    <OperationContract>
    Function GetJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampJobWrapper)

    <OperationContract>
    Function AddJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus)

    <OperationContract>
    Function EditJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus)

    <OperationContract>
    Function RemoveJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus)
End Interface

Public MustInherit Class LampWcfClient
    Implements ILampClientService

    Public MustOverride Function AddJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampService.AddJob
    Public MustOverride Function AddJobAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.AddJobAsync
    Public MustOverride Function AddTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.AddTemplate
    Public MustOverride Function AddTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.AddTemplateAsync
    Public MustOverride Function AddUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.AddUnapprovedTemplate
    Public MustOverride Function AddUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.AddUnapprovedTemplateAsync
    Public MustOverride Function AddUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampService.AddUser
    Public MustOverride Function AddUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampClientService.AddUserAsync
    Public MustOverride Function ApproveTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.ApproveTemplate
    Public MustOverride Function ApproveTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.ApproveTemplateAsync
    Public MustOverride Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampService.Authenticate
    Public MustOverride Function AuthenticateAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampClientService.AuthenticateAsync
    Public MustOverride Function DeleteTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.DeleteTemplate
    Public MustOverride Function DeleteTemplateAsync(credentials As LampCredentials) As Task(Of LampStatus) Implements ILampClientService.DeleteTemplateAsync
    Public MustOverride Function RemoveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.RemoveTemplateAsync
    Public MustOverride Function DeleteTemplateAsync(guid As String, credentials As LampCredentials) As Task(Of LampStatus) Implements ILampClientService.DeleteTemplateAsync
    Public MustOverride Function RemoveUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveUnapprovedTemplate
    Public MustOverride Function RemoveUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.RemoveUnapprovedTemplateAsync
    Public MustOverride Function RemoveUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampService.RemoveUser
    Public MustOverride Function RemoveUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampClientService.RemoveUserAsync
    Public MustOverride Function EditJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampService.EditJob
    Public MustOverride Function EditJobAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.EditJobAsync
    Public MustOverride Function EditTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.EditTemplate
    Public MustOverride Function EditTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.EditTemplateAsync
    Public MustOverride Function EditUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.EditUnapprovedTemplate
    Public MustOverride Function EditUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.EditUnapprovedTemplateAsync
    Public MustOverride Function EditUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampService.EditUser
    Public MustOverride Function EditUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampClientService.EditUserAsync
    Public MustOverride Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate) Implements ILampService.GetAllTemplate
    Public MustOverride Function GetAllTemplateAsync(credentials As LampCredentials) As Task(Of List(Of LampTemplate)) Implements ILampClientService.GetAllTemplateAsync
    Public MustOverride Function GetJob(credentials As LampCredentials, guid As String) As LampJobWrapper Implements ILampService.GetJob
    Public MustOverride Function GetJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampJobWrapper) Implements ILampClientService.GetJobAsync
    Public MustOverride Function GetTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper Implements ILampService.GetTemplate
    Public MustOverride Function GetTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampClientService.GetTemplateAsync
    Public MustOverride Function GetUser(credentials As LampCredentials) As LampUserWrapper Implements ILampService.GetUser
    Public MustOverride Function GetUserAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampClientService.GetUserAsync
    Public MustOverride Function RemoveJob(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveJob
    Public MustOverride Function RemoveJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.RemoveJobAsync
    Public MustOverride Function RevokeTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.RevokeTemplate
    Public MustOverride Function RevokeTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.RevokeTemplateAsync
    Public MustOverride Function SelectDxf(credentials As LampCredentials) As LampDxfDocumentWrapper Implements ILampService.SelectDxf
    Public MustOverride Function SelectDxfAsync(credentials As LampCredentials) As Task(Of LampDxfDocumentWrapper) Implements ILampClientService.SelectDxfAsync
End Class


Imports System.ServiceModel
Imports LampCommon

' NOTE: You can use the "Rename" command on the context menu to change the interface name "ILampService" in both code and config file together.
<ServiceContract>
Public Interface ILampService
    ''' <summary>
    ''' returns a user / reason
    ''' </summary>
    ''' <returns></returns>
    <OperationContract()>
    Function Authenticate(credentials As LampCredentials) As LampUserWrapper

    ''' <summary>
    ''' Queues a job using the given template.
    ''' </summary>
    ''' <param name="job"></param>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function QueueJob(credentials As LampCredentials, job As LampJob) As LampStatus

    ''' <summary>
    ''' Gets a template
    ''' </summary>
    ''' <returns></returns>
    <OperationContract>
    Function GetTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper

    ''' <summary>
    ''' Adds a template to db
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function AddTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus

    ''' <summary>
    ''' deletes a template from the db
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract>
    Function DeleteTemplate(credentials As LampCredentials) As LampStatus

    <OperationContract>
    Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate)

    <OperationContract>
    Function SelectDxf(credentials As LampCredentials) As LampDxfDocumentWrapper

    <OperationContract()>
    Function AddUnapprovedTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus

    <OperationContract()>
    Function DeleteUnapprovedTemplate(guid As String, credentials As LampCredentials) As LampStatus

    <OperationContract()>
    Function ApproveTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus

    <OperationContract()>
    Function RevokeTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus

    <OperationContract>
    Function GetUser(credentials As LampCredentials) As LampUserWrapper

    <OperationContract>
    Function AddUser(credentials As LampCredentials, user As LampUser) As LampStatus

    <OperationContract>
    Function EditUser(credentials As LampCredentials, user As LampUser) As LampStatus

    <OperationBehavior>
    Function DeleteUser(credentials As LampCredentials, user As LampUser) As LampStatus

    <OperationBehavior>
    Function GetJob(credentials As LampCredentials, guid As String) As LampJobWrapper

    <OperationBehavior>
    Function RemoveJob(credentials As LampCredentials, guid As String) As LampStatus

    <OperationBehavior>
    Function EditJob(credentials As LampCredentials, job As LampJob) As LampStatus

    <OperationBehavior>
    Function AddJob(credentials As LampCredentials, job As LampJob) As LampStatus
End Interface

Public Interface ILampServerService
    Inherits ILampService

End Interface

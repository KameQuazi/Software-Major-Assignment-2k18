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

    <OperationContract()>
    Function AddTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus

    ''' <summary>
    ''' Queues a job using the given template.
    ''' the 
    ''' </summary>
    ''' <param name="job"></param>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function QueueJob(job As LampJob, credentials As LampCredentials) As LampStatus

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <OperationContract>
    Function GetTemplate(credentials As LampCredentials) As LampTemplateWrapper

    <OperationContract>
    Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate)


End Interface


Public Interface ILampServerService
    Inherits ILampService

End Interface

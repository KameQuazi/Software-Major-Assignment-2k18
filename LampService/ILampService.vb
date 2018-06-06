Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "ILampService" in both code and config file together.
<ServiceContract>
Public Interface ILampService

    ''' <summary>
    ''' Queues a job using the given template.
    ''' the 
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="user"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function QueueJob(template As LampTemplate, user As LampUser) As LampStatus

    <OperationContract>
    Function GetTemplate() As LampTemplateWrapper

    ''' <summary>
    ''' returns a user / reason
    ''' </summary>
    ''' <param name="username"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function Authenticate(username As String, password As String) As LampUserWrapper
    'Sub AddTemplate(template As LampTemplate, user As LampUser)

End Interface


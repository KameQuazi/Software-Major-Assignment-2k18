Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "ILampService" in both code and config file together.
<ServiceContract([Namespace]:="LampEndpoint")>
Public Interface ILampReciever

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="user"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function QueueJob(template As LampTemplate, user As LampUser) As LampStatus

End Interface

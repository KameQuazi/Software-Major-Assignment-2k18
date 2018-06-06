Imports LampCommon
Imports LampService

''' <summary>
''' Run on the vclient machine
''' does not have full access to the db, only through a LampReciever
''' </summary>
Public Class LampWcfClient
    Implements ILampService
    ''' <summary>
    ''' Only used if the protocol is Local. Internal receiver 
    ''' </summary>
    ''' <returns></returns>
    Private Property Service As ILampService


    Sub New(service As ILampService)
        Me.Service = service
    End Sub

    ''' <summary>
    ''' Send template to a web or ip address, or to internal db.
    ''' </summary>
    Public Sub SubmitTemplate(template As LampTemplate, user As LampUser)
        'Service.SubmitTempalte(template, user)
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

    Public Function Authenticate(username As String, password As String) As LampUserWrapper
        Return Authenticate(New LampCredentials(username, password))
    End Function

    Public Function RequestTemplates(currentUser As LampUser, tags As IEnumerable(Of String)) As List(Of LampTemplate)
        Throw New NotImplementedException()
    End Function


#Region "ILampService"
    Public Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampService.Authenticate
        Return Service.Authenticate(credentials)
    End Function

    Public Function AddTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampService.AddTemplate
        Return Service.AddTemplate(template, credentials)
    End Function

    Public Function QueueJob(job As LampJob, credentials As LampCredentials) As LampStatus Implements ILampService.QueueJob
        Return Service.QueueJob(job, credentials)
    End Function

    Public Function GetTemplate(credentials As LampCredentials) As LampTemplateWrapper Implements ILampService.GetTemplate
        Return Service.GetTemplate(credentials)
    End Function
#End Region

    Public Shared Local As New LampWcfClient(New LampService.LampService)


End Class

Partial Public Class LampServiceClient
    Inherits ServiceModel.ClientBase(Of ILampService)
    Implements ILampService

    Public Sub New()
        MyBase.New
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String)
        MyBase.New(endpointConfigurationName)
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
        MyBase.New(endpointConfigurationName, remoteAddress)
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(endpointConfigurationName, remoteAddress)
    End Sub

    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(binding, remoteAddress)
    End Sub

    Public Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampService.Authenticate
        Return MyBase.Channel.Authenticate(credentials)
    End Function

    Public Function AddTemplate(template As LampTemplate, credentials As LampCredentials) As LampStatus Implements ILampService.AddTemplate
        Return MyBase.Channel.AddTemplate(template, credentials)
    End Function

    Public Function QueueJob(job As LampJob, credentials As LampCredentials) As LampStatus Implements ILampService.QueueJob
        Return MyBase.Channel.QueueJob(job, credentials)
    End Function

    Public Function GetTemplate(credentials As LampCredentials) As LampTemplateWrapper Implements ILampService.GetTemplate
        Return MyBase.Channel.GetTemplate(credentials)
    End Function
End Class



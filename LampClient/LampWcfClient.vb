Imports LampCommon
Imports LampService

''' <summary>
''' Run on the client machine
''' does not have full access to the db, only through a LampReciever
''' Bascially, an ILampService with a few helper functions
''' </summary>
Public Class LampWcfClient
    Implements ILampService

    Private Property Service As ILampService

    Public Shared ReadOnly Local As New LampWcfClient(New LampService.LampService)

    Public Function Authenticate(username As String, password As String) As LampUserWrapper
        Return Authenticate(New LampCredentials(username, password))
    End Function

    Sub New(service As ILampService)
        Me.Service = service
    End Sub


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
End Class

''' <summary>
''' A remote WCF fetcher
''' will fetch data from the endpoint given
''' </summary>
Public Class LampRemoteWcfClient
    Inherits ServiceModel.ClientBase(Of ILampService)
    Implements ILampService



#Region "ClientBase"
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
#End Region

#Region "ILampService"
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
#End Region
End Class



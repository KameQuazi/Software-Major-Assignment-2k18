Imports LampCommon
Imports LampService

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

    Public Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate) Implements ILampService.GetAllTemplate
        ' TODO add hasview template
        Return MyBase.Channel.GetAllTemplate(credentials)
    End Function
#End Region
End Class



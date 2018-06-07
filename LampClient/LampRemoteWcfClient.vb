Imports LampCommon
Imports LampService

''' <summary>
''' A remote WCF fetcher
''' will fetch data from the endpoint given
''' </summary>
Public Class LampRemoteWcfClient
    Inherits ServiceModel.ClientBase(Of ILampClientService)
    Implements ILampClientService



#Region "ClientBase"

    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(binding, remoteAddress)
    End Sub
#End Region

#Region "ILampService"
    Public Function Authenticate(ByVal credentials As LampCommon.LampCredentials) As LampCommon.LampUserWrapper Implements ILampClientService.Authenticate
        Return MyBase.Channel.Authenticate(credentials)
    End Function

    Public Function AuthenticateAsync(ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampUserWrapper) Implements ILampClientService.AuthenticateAsync
        Return MyBase.Channel.AuthenticateAsync(credentials)
    End Function

    Public Function AddTemplate(ByVal template As LampCommon.LampTemplate, ByVal credentials As LampCommon.LampCredentials) As LampCommon.LampStatus Implements ILampClientService.AddTemplate
        Return MyBase.Channel.AddTemplate(template, credentials)
    End Function

    Public Function AddTemplateAsync(ByVal template As LampCommon.LampTemplate, ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampStatus) Implements ILampClientService.AddTemplateAsync
        Return MyBase.Channel.AddTemplateAsync(template, credentials)
    End Function

    Public Function QueueJob(ByVal job As LampCommon.LampJob, ByVal credentials As LampCommon.LampCredentials) As LampCommon.LampStatus Implements ILampClientService.QueueJob
        Return MyBase.Channel.QueueJob(job, credentials)
    End Function

    Public Function QueueJobAsync(ByVal job As LampCommon.LampJob, ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampStatus) Implements ILampClientService.QueueJobAsync
        Return MyBase.Channel.QueueJobAsync(job, credentials)
    End Function

    Public Function GetTemplate(ByVal credentials As LampCommon.LampCredentials) As LampCommon.LampTemplateWrapper Implements ILampClientService.GetTemplate
        Return MyBase.Channel.GetTemplate(credentials)
    End Function

    Public Function GetTemplateAsync(ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of LampCommon.LampTemplateWrapper) Implements ILampClientService.GetTemplateAsync
        Return MyBase.Channel.GetTemplateAsync(credentials)
    End Function

    Public Function GetAllTemplateAsync(ByVal credentials As LampCommon.LampCredentials) As System.Threading.Tasks.Task(Of List(Of LampCommon.LampTemplate)) Implements ILampClientService.GetAllTemplateAsync
        Return MyBase.Channel.GetAllTemplateAsync(credentials)
    End Function

    Public Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate) Implements LampService.ILampService.GetAllTemplate
        Return MyBase.Channel.GetAllTemplate(credentials)
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



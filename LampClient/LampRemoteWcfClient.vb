﻿Imports LampClient
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

    Public Function GetTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper Implements ILampService.GetTemplate
        Return MyBase.Channel.GetTemplate(credentials, guid)
    End Function

    Public Function GetTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampClientService.GetTemplateAsync
        Return MyBase.Channel.GetTemplateAsync(credentials, guid)
    End Function

    Public Function AddTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampClientService.AddTemplate
        Return MyBase.Channel.AddTemplate(credentials, template)
    End Function

    Public Function AddTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.AddTemplateAsync
        Return MyBase.Channel.AddTemplateAsync(credentials, template)
    End Function

    Public Function EditTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.EditTemplate
        Return MyBase.Channel.EditTemplate(credentials, template)
    End Function

    Public Function EditTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.EditTemplateAsync
        Return MyBase.Channel.EditTemplateAsync(credentials, template)
    End Function

    Public Function DeleteTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.DeleteTemplate
        Return MyBase.Channel.DeleteTemplate(credentials, guid)
    End Function

    Public Function RemoveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.RemoveTemplateAsync
        Return MyBase.Channel.RemoveTemplateAsync(credentials, guid)
    End Function

    Public Function GetUser(credentials As LampCredentials) As LampUserWrapper Implements LampService.ILampService.GetUser
        Return MyBase.Channel.GetUser(credentials)
    End Function

    Public Function GetUserAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampClientService.GetUserAsync
        Return MyBase.Channel.GetUserAsync(credentials)
    End Function

    Public Function AddUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements LampService.ILampService.AddUser
        Return MyBase.Channel.AddUser(credentials, user)
    End Function

    Public Function AddUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampClientService.AddUserAsync
        Return MyBase.Channel.AddUserAsync(credentials, user)
    End Function

    Public Function EditUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements LampService.ILampService.EditUser
        Return MyBase.Channel.EditUser(credentials, user)
    End Function

    Public Function EditUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampClientService.EditUserAsync
        Return MyBase.Channel.EditUserAsync(credentials, user)
    End Function

    Public Function RemoveUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampService.RemoveUser
        Return MyBase.Channel.RemoveUser(credentials, user)
    End Function

    Public Function RemoveUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampClientService.RemoveUserAsync
        Return MyBase.Channel.RemoveUserAsync(credentials, user)
    End Function

    Public Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampClientService.Authenticate
        Return MyBase.Channel.Authenticate(credentials)
    End Function

    Public Function AuthenticateAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampClientService.AuthenticateAsync
        Return MyBase.Channel.AuthenticateAsync(credentials)
    End Function

    Public Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate) Implements ILampService.GetAllTemplate
        Return MyBase.Channel.GetAllTemplate(credentials)
    End Function

    Public Function GetAllTemplateAsync(ByVal credentials As LampCredentials) As Task(Of List(Of LampTemplate)) Implements ILampClientService.GetAllTemplateAsync
        Return MyBase.Channel.GetAllTemplateAsync(credentials)
    End Function

    Public Function SelectDxf(credentials As LampCredentials, guid As String) As LampDxfDocumentWrapper Implements LampService.ILampService.SelectDxf
        Return MyBase.Channel.SelectDxf(credentials, guid)
    End Function

    Public Function SelectDxfAsync(credentials As LampCredentials, guid As String) As Task(Of LampDxfDocumentWrapper) Implements ILampClientService.SelectDxfAsync
        Return MyBase.Channel.SelectDxfAsync(credentials, guid)
    End Function

    Public Function GetUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper Implements ILampService.GetUnapprovedTemplate
        Return MyBase.Channel.GetUnapprovedTemplate(credentials, guid)
    End Function

    Public Function GetUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampClientService.GetUnapprovedTemplateAsync
        Return MyBase.Channel.GetUnapprovedTemplateAsync(credentials, guid)
    End Function

    Public Function AddUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.AddUnapprovedTemplate
        Return MyBase.Channel.AddUnapprovedTemplate(credentials, template)
    End Function
    Public Function AddUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.AddUnapprovedTemplateAsync
        Return MyBase.Channel.AddUnapprovedTemplateAsync(credentials, template)
    End Function

    Public Function EditUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.EditUnapprovedTemplate
        Return MyBase.Channel.EditUnapprovedTemplate(credentials, template)
    End Function

    Public Function EditUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.EditUnapprovedTemplateAsync
        Return MyBase.Channel.EditUnapprovedTemplateAsync(credentials, template)
    End Function

    Public Function RemoveUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveUnapprovedTemplate
        Throw New NotImplementedException()
    End Function

    Public Function RemoveUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.RemoveUnapprovedTemplateAsync
        Return MyBase.Channel.EditUnapprovedTemplateAsync(credentials, template)
    End Function

    Public Function ApproveTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements LampService.ILampService.ApproveTemplate
        Return MyBase.Channel.EditUnapprovedTemplate(credentials, template)
    End Function

    Public Function ApproveTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.ApproveTemplateAsync
        Return MyBase.Channel.EditUnapprovedTemplateAsync(credentials, template)
    End Function

    Public Function RevokeTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RevokeTemplate
        Return MyBase.Channel.RevokeTemplate(credentials, guid)
    End Function

    Public Function RevokeTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.RevokeTemplateAsync
        Return MyBase.Channel.RevokeTemplateAsync(credentials, guid)
    End Function

    Public Function GetJob(credentials As LampCredentials, guid As String) As LampJobWrapper Implements ILampService.GetJob
        Return MyBase.Channel.GetJob(credentials, guid)
    End Function

    Public Function GetJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampJobWrapper) Implements ILampClientService.GetJobAsync
        Return MyBase.Channel.GetJobAsync(credentials, guid)
    End Function

    Public Function AddJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampService.AddJob
        Return MyBase.Channel.AddJob(credentials, job)
    End Function

    Public Function AddJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampClientService.AddJobAsync
        Return MyBase.Channel.AddJobAsync(credentials, job)
    End Function

    Public Function EditJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampService.EditJob
        Return MyBase.Channel.EditJob(credentials, job)
    End Function

    Public Function EditJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampClientService.EditJobAsync
        Return MyBase.Channel.AddJobAsync(credentials, job)
    End Function

    Public Function RemoveJob(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveJob
        Return MyBase.Channel.RemoveJob(credentials, guid)
    End Function

    Public Function RemoveJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.RemoveJobAsync
        Return MyBase.Channel.RemoveJobAsync(credentials, guid)
    End Function

    Public Function RemoveUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.RemoveUnapprovedTemplateAsync
        Throw New NotImplementedException()
    End Function








#End Region
End Class



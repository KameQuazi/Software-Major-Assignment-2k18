Imports LampClient
Imports LampCommon
Imports LampService

''' <summary>
''' A remote WCF fetcher
''' will fetch data from the endpoint given
''' </summary>
Public Class LampRemoteWcfClient
    Inherits ServiceModel.ClientBase(Of ILampServiceBoth)
    Implements ILampServiceBoth



#Region "ClientBase"

    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(binding, remoteAddress)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "ILampService"

    Public Function GetTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper Implements ILampServiceBoth.GetTemplate
        Return Channel.GetTemplate(credentials, guid)
    End Function

    Public Function GetTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampServiceBoth.GetTemplateAsync
        Return Channel.GetTemplateAsync(credentials, guid)
    End Function

    Public Function AddTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampServiceBoth.AddTemplate
        Return Channel.AddTemplate(credentials, template)
    End Function

    Public Function AddTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceBoth.AddTemplateAsync
        Return Channel.AddTemplateAsync(credentials, template)
    End Function

    Public Function EditTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampServiceBoth.EditTemplate
        Return Channel.EditTemplate(credentials, template)
    End Function

    Public Function EditTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceBoth.EditTemplateAsync
        Return Channel.EditTemplateAsync(credentials, template)
    End Function

    Public Function RemoveTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampServiceBoth.RemoveTemplate
        Return Channel.RemoveTemplate(credentials, guid)
    End Function

    Public Function RemoveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceBoth.RemoveTemplateAsync
        Return Channel.RemoveTemplateAsync(credentials, guid)
    End Function

    Public Function GetUser(credentials As LampCredentials, guid As String) As LampUserWrapper Implements ILampServiceBoth.GetUser
        Return Channel.GetUser(credentials, guid)
    End Function

    Public Function GetUserAsync(credentials As LampCredentials, guid As String) As Task(Of LampUserWrapper) Implements ILampServiceBoth.GetUserAsync
        Return Channel.GetUserAsync(credentials, guid)
    End Function

    Public Function AddUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampServiceBoth.AddUser
        Return Channel.AddUser(credentials, user)
    End Function

    Public Function AddUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampServiceBoth.AddUserAsync
        Return Channel.AddUserAsync(credentials, user)
    End Function

    Public Function EditUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampServiceBoth.EditUser
        Return Channel.EditUser(credentials, user)
    End Function

    Public Function EditUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampServiceBoth.EditUserAsync
        Return Channel.EditUserAsync(credentials, user)
    End Function

    Public Function RemoveUser(credentials As LampCredentials, guid As String) As LampStatus Implements ILampServiceBoth.RemoveUser
        Return Channel.RemoveUser(credentials, guid)
    End Function

    Public Function RemoveUserAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceBoth.RemoveUserAsync
        Return Channel.RemoveUserAsync(credentials, guid)
    End Function

    Public Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampServiceBoth.Authenticate
        Return Channel.Authenticate(credentials)
    End Function

    Public Function AuthenticateAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampServiceBoth.AuthenticateAsync
        Return Channel.AuthenticateAsync(credentials)
    End Function

    Public Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate) Implements ILampServiceBoth.GetAllTemplate
        Return Channel.GetAllTemplate(credentials)
    End Function

    Public Function GetAllTemplateAsync(ByVal credentials As LampCredentials) As Task(Of List(Of LampTemplate)) Implements ILampServiceBoth.GetAllTemplateAsync
        Return Channel.GetAllTemplateAsync(credentials)
    End Function

    Public Function SelectDxf(credentials As LampCredentials, guid As String) As LampDxfDocumentWrapper Implements ILampServiceBoth.SelectDxf
        Return Channel.SelectDxf(credentials, guid)
    End Function

    Public Function SelectDxfAsync(credentials As LampCredentials, guid As String) As Task(Of LampDxfDocumentWrapper) Implements ILampServiceBoth.SelectDxfAsync
        Return Channel.SelectDxfAsync(credentials, guid)
    End Function

    Public Function GetUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper Implements ILampServiceBoth.GetUnapprovedTemplate
        Return Channel.GetUnapprovedTemplate(credentials, guid)
    End Function

    Public Function GetUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampServiceBoth.GetUnapprovedTemplateAsync
        Return Channel.GetUnapprovedTemplateAsync(credentials, guid)
    End Function

    Public Function AddUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampServiceBoth.AddUnapprovedTemplate
        Return Channel.AddUnapprovedTemplate(credentials, template)
    End Function
    Public Function AddUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceBoth.AddUnapprovedTemplateAsync
        Return Channel.AddUnapprovedTemplateAsync(credentials, template)
    End Function

    Public Function EditUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampServiceBoth.EditUnapprovedTemplate
        Return Channel.EditUnapprovedTemplate(credentials, template)
    End Function

    Public Function EditUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampServiceBoth.EditUnapprovedTemplateAsync
        Return Channel.EditUnapprovedTemplateAsync(credentials, template)
    End Function

    Public Function RemoveUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampServiceBoth.RemoveUnapprovedTemplate
        Return Channel.RemoveUnapprovedTemplate(credentials, guid)
    End Function

    Public Function RemoveUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceBoth.RemoveUnapprovedTemplateAsync
        Return Channel.RemoveUnapprovedTemplateAsync(credentials, guid)
    End Function

    Public Function ApproveTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampServiceBoth.ApproveTemplate
        Return Channel.ApproveTemplate(credentials, guid)
    End Function

    Public Function ApproveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceBoth.ApproveTemplateAsync
        Return Channel.ApproveTemplateAsync(credentials, guid)
    End Function

    Public Function RevokeTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampServiceBoth.RevokeTemplate
        Return Channel.RevokeTemplate(credentials, guid)
    End Function

    Public Function RevokeTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceBoth.RevokeTemplateAsync
        Return Channel.RevokeTemplateAsync(credentials, guid)
    End Function

    Public Function GetJob(credentials As LampCredentials, guid As String) As LampJobWrapper Implements ILampServiceBoth.GetJob
        Return Channel.GetJob(credentials, guid)
    End Function

    Public Function GetJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampJobWrapper) Implements ILampServiceBoth.GetJobAsync
        Return Channel.GetJobAsync(credentials, guid)
    End Function

    Public Function AddJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampServiceBoth.AddJob
        Return Channel.AddJob(credentials, job)
    End Function

    Public Function AddJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampServiceBoth.AddJobAsync
        Return Channel.AddJobAsync(credentials, job)
    End Function

    Public Function EditJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampServiceBoth.EditJob
        Return Channel.EditJob(credentials, job)
    End Function

    Public Function EditJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampServiceBoth.EditJobAsync
        Return Channel.AddJobAsync(credentials, job)
    End Function

    Public Function RemoveJob(credentials As LampCredentials, guid As String) As LampStatus Implements ILampServiceBoth.RemoveJob
        Return Channel.RemoveJob(credentials, guid)
    End Function

    Public Function RemoveJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampServiceBoth.RemoveJobAsync
        Return Channel.RemoveJobAsync(credentials, guid)
    End Function

    Public Function GetTemplateList(credentials As LampCredentials, tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampSort) As LampTemplateListWrapper Implements ILampService.GetTemplateList
        Return Channel.GetTemplateList(credentials, tags, byUser, limit, offset, approveStatus, orderBy)
    End Function

    Public Function GetTemplateListAsync(credentials As LampCredentials, tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampSort) As Task(Of LampTemplateListWrapper) Implements ILampServiceAsync.GetTemplateListAsync
        Return Channel.GetTemplateListAsync(credentials, tags, byUser, limit, offset, approveStatus, orderBy)
    End Function

    Public Function GetJobList(credentials As LampCredentials, byUsers As IEnumerable(Of String), limit As Integer, offset As Integer, orderBy As LampSort) As LampJobListWrapper Implements ILampService.GetJobList
        Return Channel.GetJobList(credentials, byUsers, limit, offset, orderBy)
    End Function

    Public Function GetJobListAsync(credentials As LampCredentials, byUsers As IEnumerable(Of String), limit As Integer, offset As Integer, orderBy As LampSort) As Task(Of LampJobListWrapper) Implements ILampServiceAsync.GetJobListAsync
        Return Channel.GetJobListAsync(credentials, byUsers, limit, offset, orderBy)
    End Function


#End Region
End Class



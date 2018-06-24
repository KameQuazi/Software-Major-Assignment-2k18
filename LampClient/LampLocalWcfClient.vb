Imports LampCommon
Imports LampService

''' <summary>
''' Run on the client machine, has an internal receiver
''' </summary>
Public Class LampLocalWcfClient
    Implements ILampClientService

    ''' <summary>
    ''' global local wcf client
    ''' </summary>
    Public Shared Local As ILampService

    Private Property Channel As ILampServerService



    Sub New(service As ILampServerService)
        Me.Channel = service
    End Sub

    Public Function GetTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper Implements ILampService.GetTemplate
        Return Channel.GetTemplate(credentials, guid)
    End Function

    Public Function GetTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampClientService.GetTemplateAsync
        Return Channel.GetTemplateAsync(credentials, guid)
    End Function

    Public Function AddTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampClientService.AddTemplate
        Return Channel.AddTemplate(credentials, template)
    End Function

    Public Function AddTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.AddTemplateAsync
        Return Channel.AddTemplateAsync(credentials, template)
    End Function

    Public Function EditTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.EditTemplate
        Return Channel.EditTemplate(credentials, template)
    End Function

    Public Function EditTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.EditTemplateAsync
        Return Channel.EditTemplateAsync(credentials, template)
    End Function

    Public Function DeleteTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.DeleteTemplate
        Return Channel.DeleteTemplate(credentials, guid)
    End Function

    Public Function RemoveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.RemoveTemplateAsync
        Return Channel.RemoveTemplateAsync(credentials, guid)
    End Function

    Public Function GetUser(credentials As LampCredentials) As LampUserWrapper Implements LampService.ILampService.GetUser
        Return Channel.GetUser(credentials)
    End Function

    Public Function GetUserAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampClientService.GetUserAsync
        Return Channel.GetUserAsync(credentials)
    End Function

    Public Function AddUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements LampService.ILampService.AddUser
        Return Channel.AddUser(credentials, user)
    End Function

    Public Function AddUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampClientService.AddUserAsync
        Return Channel.AddUserAsync(credentials, user)
    End Function

    Public Function EditUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements LampService.ILampService.EditUser
        Return Channel.EditUser(credentials, user)
    End Function

    Public Function EditUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampClientService.EditUserAsync
        Return Channel.EditUserAsync(credentials, user)
    End Function

    Public Function RemoveUser(credentials As LampCredentials, user As LampUser) As LampStatus Implements ILampService.RemoveUser
        Return Channel.RemoveUser(credentials, user)
    End Function

    Public Function RemoveUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus) Implements ILampClientService.RemoveUserAsync
        Return Channel.RemoveUserAsync(credentials, user)
    End Function

    Public Function Authenticate(credentials As LampCredentials) As LampUserWrapper Implements ILampClientService.Authenticate
        Return Channel.Authenticate(credentials)
    End Function

    Public Function AuthenticateAsync(credentials As LampCredentials) As Task(Of LampUserWrapper) Implements ILampClientService.AuthenticateAsync
        Return Channel.AuthenticateAsync(credentials)
    End Function

    Public Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate) Implements ILampService.GetAllTemplate
        Return Channel.GetAllTemplate(credentials)
    End Function

    Public Function GetAllTemplateAsync(ByVal credentials As LampCredentials) As Task(Of List(Of LampTemplate)) Implements ILampClientService.GetAllTemplateAsync
        Return Channel.GetAllTemplateAsync(credentials)
    End Function

    Public Function SelectDxf(credentials As LampCredentials, guid As String) As LampDxfDocumentWrapper Implements LampService.ILampService.SelectDxf
        Return Channel.SelectDxf(credentials, guid)
    End Function

    Public Function SelectDxfAsync(credentials As LampCredentials, guid As String) As Task(Of LampDxfDocumentWrapper) Implements ILampClientService.SelectDxfAsync
        Return Channel.SelectDxfAsync(credentials, guid)
    End Function

    Public Function GetUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper Implements ILampService.GetUnapprovedTemplate
        Return Channel.GetUnapprovedTemplate(credentials, guid)
    End Function

    Public Function GetUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper) Implements ILampClientService.GetUnapprovedTemplateAsync
        Return Channel.GetUnapprovedTemplateAsync(credentials, guid)
    End Function

    Public Function AddUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.AddUnapprovedTemplate
        Return Channel.AddUnapprovedTemplate(credentials, template)
    End Function
    Public Function AddUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.AddUnapprovedTemplateAsync
        Return Channel.AddUnapprovedTemplateAsync(credentials, template)
    End Function

    Public Function EditUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements ILampService.EditUnapprovedTemplate
        Return Channel.EditUnapprovedTemplate(credentials, template)
    End Function

    Public Function EditUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.EditUnapprovedTemplateAsync
        Return Channel.EditUnapprovedTemplateAsync(credentials, template)
    End Function

    Public Function RemoveUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveUnapprovedTemplate
        Return Channel.RemoveUnapprovedTemplate(credentials, guid)
    End Function

    Public Function RemoveUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.RemoveUnapprovedTemplateAsync
        Return Channel.RemoveUnapprovedTemplateAsync(credentials, guid)
    End Function

    Public Function ApproveTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus Implements LampService.ILampService.ApproveTemplate
        Return Channel.EditUnapprovedTemplate(credentials, template)
    End Function

    Public Function ApproveTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus) Implements ILampClientService.ApproveTemplateAsync
        Return Channel.EditUnapprovedTemplateAsync(credentials, template)
    End Function

    Public Function RevokeTemplate(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RevokeTemplate
        Return Channel.RevokeTemplate(credentials, guid)
    End Function

    Public Function RevokeTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.RevokeTemplateAsync
        Return Channel.RevokeTemplateAsync(credentials, guid)
    End Function

    Public Function GetJob(credentials As LampCredentials, guid As String) As LampJobWrapper Implements ILampService.GetJob
        Return Channel.GetJob(credentials, guid)
    End Function

    Public Function GetJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampJobWrapper) Implements ILampClientService.GetJobAsync
        Return Channel.GetJobAsync(credentials, guid)
    End Function

    Public Function AddJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampService.AddJob
        Return Channel.AddJob(credentials, job)
    End Function

    Public Function AddJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampClientService.AddJobAsync
        Return Channel.AddJobAsync(credentials, job)
    End Function

    Public Function EditJob(credentials As LampCredentials, job As LampJob) As LampStatus Implements ILampService.EditJob
        Return Channel.EditJob(credentials, job)
    End Function

    Public Function EditJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus) Implements ILampClientService.EditJobAsync
        Return Channel.AddJobAsync(credentials, job)
    End Function

    Public Function RemoveJob(credentials As LampCredentials, guid As String) As LampStatus Implements ILampService.RemoveJob
        Return Channel.RemoveJob(credentials, guid)
    End Function

    Public Function RemoveJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus) Implements ILampClientService.RemoveJobAsync
        Return Channel.RemoveJobAsync(credentials, guid)
    End Function

End Class


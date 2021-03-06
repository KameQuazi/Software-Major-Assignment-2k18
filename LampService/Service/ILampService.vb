﻿Imports System.Threading.Tasks
Imports LampCommon

<ServiceContract(Name:=NameOf(ILampService))>
Public Interface ILampService

    ''' <summary>
    ''' Gets a template
    ''' </summary>
    ''' <returns></returns>
    <OperationContract>
    Function GetTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper

    ''' <summary>
    ''' Adds a template to db
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function AddTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus

    ''' <summary>
    ''' Adds a template to db
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function EditTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus

    ''' <summary>
    ''' deletes a template from the db
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract>
    Function RemoveTemplate(credentials As LampCredentials, guid As String) As LampStatus

    ''' <summary>
    ''' Gets a user from the server
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract>
    Function GetUser(credentials As LampCredentials, guid As String) As LampUserWrapper

    ''' <summary>
    ''' adds a user to the server
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="user"></param>
    ''' <returns></returns>
    <OperationContract>
    Function AddUser(credentials As LampCredentials, user As LampUser) As LampStatus

    ''' <summary>
    ''' edits a user from the server
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="user"></param>
    ''' <returns></returns>
    <OperationContract>
    Function EditUser(credentials As LampCredentials, user As LampUser) As LampStatus

    ''' <summary>
    ''' delets a user from the server
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    <OperationContract>
    Function RemoveUser(credentials As LampCredentials, guid As String) As LampStatus

    ''' <summary>
    ''' tries to login, and returns a user / reason wrapper
    ''' </summary>
    ''' <returns></returns>
    <OperationContract()>
    Function Authenticate(credentials As LampCredentials) As LampUserWrapper

    ''' <summary>
    ''' Gets all the templates in db. should be for debug only
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract>
    Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate)

    ''' <summary>
    ''' gets a dxf. moar efficent then getting a whole template if only the template is required
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract>
    Function SelectDxf(credentials As LampCredentials, guid As String) As LampDxfDocumentWrapper

    ''' <summary>
    ''' Adds an unapproved template
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function GetUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampTemplateWrapper

    ''' <summary>
    ''' Adds an unapproved template
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function AddUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus

    ''' <summary>
    ''' Adds an unapproved template
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function EditUnapprovedTemplate(credentials As LampCredentials, template As LampTemplate) As LampStatus

    ''' <summary>
    ''' Deletes an unapproved Template
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function RemoveUnapprovedTemplate(credentials As LampCredentials, guid As String) As LampStatus

    ''' <summary>
    ''' set template to approved to -> into public folder
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function ApproveTemplate(credentials As LampCredentials, guid As String) As LampStatus

    ''' <summary>
    ''' unapproves template so it cannot be seen by normal users
    ''' </summary>
    ''' <param name="credentials"></param>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function RevokeTemplate(credentials As LampCredentials, guid As String) As LampStatus

    <OperationContract>
    Function GetJob(credentials As LampCredentials, guid As String) As LampJobWrapper

    ''' <summary>
    ''' adds a job using the given template.
    ''' </summary>
    ''' <param name="job"></param>
    ''' <param name="credentials"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function AddJob(credentials As LampCredentials, job As LampJob) As LampStatus

    <OperationContract>
    Function EditJob(credentials As LampCredentials, job As LampJob) As LampStatus

    <OperationContract>
    Function RemoveJob(credentials As LampCredentials, guid As String) As LampStatus

    <OperationContract>
    Function GetJobList(credentials As LampCredentials, byUsers As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampJobSort) As LampJobListWrapper

    <OperationContract>
    Function GetTemplateList(credentials As LampCredentials, tags As IEnumerable(Of String), byUsers As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampTemplateSort) As LampTemplateListWrapper

    <OperationContract>
    Function GetUserList(credentials As LampCredentials, limit As Integer, offset As Integer, orderBy As LampUserSort) As LampUserListWrapper

    <OperationContract>
    Function ApproveJob(credentials As LampCredentials, jobId As String) As LampStatus

    <OperationContract>
    Function RevokeJob(credentials As LampCredentials, jobId As String) As LampStatus

End Interface

<ServiceContract(Name:=NameOf(ILampService))>
Public Interface ILampServiceClient
    Inherits ILampService
    <OperationContract>
    Function GetTemplateAsync(ByVal credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper)

    <OperationContract>
    Function AddTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus)

    <OperationContract>
    Function EditTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus)

    <OperationContract>
    Function RemoveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus)

    <OperationContract>
    Function GetUserAsync(credentials As LampCredentials, guid As String) As Task(Of LampUserWrapper)

    <OperationContract>
    Function AddUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus)

    <OperationContract>
    Function EditUserAsync(credentials As LampCredentials, user As LampUser) As Task(Of LampStatus)

    <OperationContract>
    Function RemoveUserAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus)

    <OperationContract>
    Function AuthenticateAsync(credentials As LampCredentials) As Task(Of LampUserWrapper)

    <OperationContract>
    Function GetAllTemplateAsync(credentials As LampCredentials) As Task(Of List(Of LampTemplate))

    <OperationContract()>
    Function GetUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampTemplateWrapper)

    <OperationContract>
    Function SelectDxfAsync(credentials As LampCredentials, guid As String) As Task(Of LampDxfDocumentWrapper)

    <OperationContract()>
    Function AddUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus)

    <OperationContract()>
    Function EditUnapprovedTemplateAsync(credentials As LampCredentials, template As LampTemplate) As Task(Of LampStatus)

    <OperationContract()>
    Function RemoveUnapprovedTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus)

    <OperationContract()>
    Function ApproveTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus)

    <OperationContract()>
    Function RevokeTemplateAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus)

    <OperationContract>
    Function GetJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampJobWrapper)

    <OperationContract>
    Function AddJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus)

    <OperationContract>
    Function EditJobAsync(credentials As LampCredentials, job As LampJob) As Task(Of LampStatus)

    <OperationContract>
    Function RemoveJobAsync(credentials As LampCredentials, guid As String) As Task(Of LampStatus)

    <OperationContract>
    Function GetTemplateListAsync(credentials As LampCredentials, tags As IEnumerable(Of String), byUsers As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampTemplateSort) As Task(Of LampTemplateListWrapper)

    <OperationContract>
    Function GetJobListAsync(credentials As LampCredentials, byUsers As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampJobSort) As Task(Of LampJobListWrapper)

    <OperationContract>
    Function GetUserListAsync(credentials As LampCredentials, limit As Integer, offset As Integer, orderBy As LampUserSort) As Task(Of LampUserListWrapper)


    <OperationContract>
    Function ApproveJobAsync(credentials As LampCredentials, jobId As String) As Task(Of LampStatus)

    <OperationContract>
    Function RevokeJobAsync(credentials As LampCredentials, jobId As String) As Task(Of LampStatus)
End Interface


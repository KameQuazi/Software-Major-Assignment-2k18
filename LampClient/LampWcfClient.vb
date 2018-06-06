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

    Public Function GetAllTemplate(credentials As LampCredentials) As List(Of LampTemplate) Implements ILampService.GetAllTemplate
        ' TODO add hasview template
        Return Service.GetAllTemplate(credentials)
    End Function
#End Region
End Class


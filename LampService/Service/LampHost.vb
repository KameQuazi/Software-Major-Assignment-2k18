Imports System.Configuration
Imports System.ServiceModel.Configuration
Imports System.ServiceModel.Description

Public Class LampHost
    Public Property OpenedHosts As New List(Of ServiceHost)

    ''' <summary>
    ''' Starts the ip listener
    ''' dont forget to close it !
    ''' </summary>
    Public Sub StartListenerFromConfig()
        Dim config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim serviceModelList = config.SectionGroups.OfType(Of ServiceModelSectionGroup).ToList()
        If serviceModelList Is Nothing Then
            Throw New ArgumentOutOfRangeException("Configuration section 'system.serviceModel' is missing.")
        End If
        If serviceModelList.Count > 1 Then
            Throw New ArgumentOutOfRangeException("multiple sections 'system.serviceModel' exist, only 1 allowed")
        End If
        Dim serviceModel = serviceModelList(0)
        If serviceModel.Name <> "LampService.LampService" Then
            Throw New ArgumentOutOfRangeException("name must be LampService.LampService")
        End If
        ' code sourced here https://stackoverflow.com/questions/24649979/programatically-getting-the-value-of-baseaddresses-from-seperate-services-in-wcf

        Dim services = serviceModel.Services.Services
        If services.Count() = 0 Then
            Throw New ArgumentOutOfRangeException("number of services cannot be 0")
        End If



        ' add services
        For Each service As ServiceElement In services
            Dim endpoints = service.Endpoints
            StartHost(service.Host.BaseAddresses, endpoints)

            For Each item As ServiceMetadataBehavior In serviceModel.Behaviors.ServiceBehaviors
                For Each meta In item.OfType(Of ServiceMetadataEndpointElement)
                    meta.
            Next
            Next
        Next




    End Sub

    Public Function StartHost(baseAddresses As BaseAddressElementCollection, endpoints As ServiceEndpointElementCollection) As ServiceHost
        Dim addresses As New List(Of Uri)
        For Each address As BaseAddressElement In baseAddresses
            addresses.Add(New Uri(address.BaseAddress))
        Next

        Dim listEndpoint As New List(Of ServiceEndpoint)
        For Each endp As ServiceEndpointElement In endpoints
            Dim serviceEnd As New ServiceEndpoint(New ContractDescription("ILampService"), New WSHttpBinding(endp.BindingConfiguration), New EndpointAddress(endp.Address))
            listEndpoint.Add(serviceEnd)
        Next

        Return StartHost(addresses, listEndpoint)
    End Function

    Public Function StartHost(baseAddresses As List(Of Uri), endpoints As List(Of ServiceEndpoint)) As ServiceHost
        ' supports only 1 baseAddress right now
        Dim newHost As New ServiceHost(GetType(ILampService), baseAddresses(0))

        For Each endpoint In endpoints

            newHost.AddServiceEndpoint(endpoint)

        Next

        Return newHost
    End Function


End Class

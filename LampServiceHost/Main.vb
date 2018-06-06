Imports System.Collections.Specialized
Imports System.Configuration
Imports System.ServiceModel.Configuration
Imports LampService

Module OwOHost

    Sub Main()
        Dim service As New LampService.LampService
        Dim config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim serviceModel = config.SectionGroups.OfType(Of ServiceModelSectionGroup)().SingleOrDefault()
        If serviceModel Is Nothing Then
            Throw New ArgumentNullException("Configuration section 'system.serviceModel' is missing.")
        End If
        ' code sourced here https://stackoverflow.com/questions/24649979/programatically-getting-the-value-of-baseaddresses-from-seperate-services-in-wcf
        Dim services = serviceModel.Services.Services
        If services.Count() = 0 Then
            Throw New ArgumentOutOfRangeException("number of services cannot be 0")
        End If




        Dim host As New LampHost
        Dim endpoints = host.StartListenerFromConfig()
        Console.PrintLine(String.Format("Service started on endpoints {0})", endpoints)
        Console.ReadLine()
    End Sub

End Module

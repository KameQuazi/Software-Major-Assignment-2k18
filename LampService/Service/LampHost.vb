Imports System.Configuration
Imports System.ServiceModel.Configuration
Imports System.ServiceModel.Description

Public Class LampHost
    Inherits LampService

    Public Property Host As ServiceHost

    Public Property BaseAddress As String



    Public Shared Sub Configure(config As ServiceConfiguration)
        config.LoadFromConfiguration(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None))
    End Sub

    Public Sub Close()
        Host.Close()
    End Sub

    Public Property OpenedHosts As New List(Of ServiceHost)

    ''' <summary>
    ''' Starts the ip listener
    ''' dont forget to close it !
    ''' </summary>
    Public Sub StartListenerFromConfig()




        ' add services 
        Host = New ServiceHost(GetType(LampService))
        Host.Open()
        BaseAddress = Host.BaseAddresses(0).ToString

    End Sub




End Class

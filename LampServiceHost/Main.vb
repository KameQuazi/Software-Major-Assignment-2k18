Imports System.Collections.Specialized
Imports System.Configuration
Imports System.ServiceModel.Configuration
Imports LampService

Module OwOHost

    Sub Main()
        Dim hoster As New LampHost()
        hoster.StartListenerFromConfig()
        Console.WriteLine(String.Format("Service started on {0}", hoster.baseAddress))
        Console.ReadLine()
        hoster.Close()
    End Sub

End Module

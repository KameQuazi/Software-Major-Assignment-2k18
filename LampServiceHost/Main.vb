Imports LampService

Module OwOHost

    Sub Main()
        Dim service As New LampService.LampService
        service.StartListener(Configuration.ConfigurationManager.Appsettings("hostUrl"))
    End Sub

End Module

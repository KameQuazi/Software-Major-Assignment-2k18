Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub Handle() Handles MyBase.Startup
            Console.WriteLine("Start")
            InitalizeLibraries()
            LampLocalWcfClient.Local = New LampLocalWcfClient(New LampService.LampServiceLocal("templateDB.sqlite"))
            SetServiceEndpoint(LampLocalWcfClient.Local)
            CurrentUser = Nothing
            Console.WriteLine("hewwo?")
        End Sub
    End Class


End Namespace

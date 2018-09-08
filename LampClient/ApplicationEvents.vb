

Imports System.IO
Imports Newtonsoft.Json

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
            SetServiceEndpoint(ClientEndpoint)
            ' SetServiceEndpoint(LampLocalWcfClient.Local)

            CurrentUser = Nothing
            Console.WriteLine("hewwo?")

            LoadDefaultMaterials()
        End Sub

        Private Property DefualtMaterialFilename = "DefaultMaterials.json"

        Private Sub LoadDefaultMaterials()

            Try
                Dim fileText As String = Nothing

                Dim local = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefualtMaterialFilename)
                Dim userData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DefualtMaterialFilename)
                If File.Exists(local) Then
                    fileText = File.ReadAllText(local)
                ElseIf File.Exists(userData) Then
                    fileText = File.ReadAllText(userData)
                Else
                    MessageBox.Show("Unable to find configuration file")
                    Return
                End If

                Dim mats = JsonConvert.DeserializeObject(Of String())(fileText)

                SyncLock TemplateCreatorControl.DefaultMaterials
                    For Each item In mats
                        TemplateCreatorControl.DefaultMaterials.Add(item)
                    Next
                End SyncLock

            Catch e As Exception
                MessageBox.Show("Error occured during reading config files: " + e.ToString)
            End Try

        End Sub
    End Class


End Namespace

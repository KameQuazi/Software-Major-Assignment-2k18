Imports LampCommon
Imports LampService

Public Module OwO
    Public Property CurrentUser As LampUser = New LampUser(GetNewGuid, UserPermission.Admin, "none@gmail.comg", "hewwwo", "password", "debugger")

    Public Property CurrentSender As ServiceReference1.ILampService  'LampWcfClient.Local

    Public Sub Main()
        InitalizeLibraries()
        CurrentSender = New LampClient.ServiceReference1.LampServiceClient()

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New DebugForm())

    End Sub

    Sub InitalizeLibraries()
        ' extract necessary dll files
        ' put folder in DLL path
    End Sub





End Module

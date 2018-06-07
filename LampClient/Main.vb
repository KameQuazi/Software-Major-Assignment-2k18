Imports System.ServiceModel
Imports LampCommon
Imports LampService

Public Module OwO
    Public Property CurrentUser As LampUser = New LampUser(GetNewGuid, UserPermission.Admin, "none@gmail.comg", "hewwwo", "password", "debugger")

    Public Property CurrentSender As ILampService  'LampWcfClient.Local

    Public Property ClientEndpoint As String = "http://localhost:8733/Design_Time_Addresses/LampService.svcsdf"

    Public Sub Main()
        InitalizeLibraries()
        ' CurrentSender = New LampClient.ServiceReference1.LampServiceClient()

        Dim endpoint As New EndpointAddress(ClientEndpoint)
        Dim binding = New BasicHttpBinding()
        CurrentSender = New LampRemoteWcfClient(binding, endpoint)


        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New DebugForm())

    End Sub

    Sub InitalizeLibraries()
        ' extract necessary dll files
        ' put folder in DLL path
    End Sub





End Module

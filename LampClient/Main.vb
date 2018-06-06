Imports LampCommon
Imports LampClient.LampServiceReference

Public Module OwO
    Public Property CurrentUser As LampUser

    Public Property CurrentSender As ILampService = New LampServiceClient

    Public Sub Main()
        InitalizeLibraries()


        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New DesignerForm())

    End Sub

    Sub InitalizeLibraries()
        ' extract necessary dll files
        ' put folder in DLL path
    End Sub





End Module

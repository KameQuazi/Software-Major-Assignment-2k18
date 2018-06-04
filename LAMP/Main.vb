Public Module OwO

    Public Property CurrentUser As LampUser

    Public Property CurrentSender As LampSender = LampSender.Local

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

    Public Function GetNewGuid() As String
        Return Guid.NewGuid().ToString()
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function ToSingle(this As Double) As Single
        Return Convert.ToSingle(this)
    End Function


End Module

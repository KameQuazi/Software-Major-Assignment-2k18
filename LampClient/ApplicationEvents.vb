Imports System.IO
Imports Newtonsoft.Json
Imports System.ComponentModel.DataAnnotations
Imports System.ServiceModel
Imports System.Text.RegularExpressions
Imports LampCommon
Imports LampService
Imports netDxf


Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub Handle() Handles MyBase.Startup
            InitalizeLibraries()
            LoadEndpointFromSettings()

            CurrentUser = Nothing
            LampJob.ValidateDist = True
            Console.WriteLine("hewwo? im starting plz")

            LoadDefaultMaterials()

        End Sub

        Private Sub LoadEndpointFromSettings()
            ' SetServiceEndpoint(ClientEndpoint)
            SetServiceEndpoint(LampLocalWcfClient.Local)
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


Public Module OwO
    Public Property CurrentUser As LampUser = New LampUser(GetNewGuid, UserPermission.Admin, "none@gmail.comg", "debugUser", "password", "debugger")

    Public Property CurrentSender As ILampWcfClient

    Public Property ClientEndpoint As String
        Get
            Return "http://localhost:8733/Design_Time_Addresses/LampService.svc"
        End Get
        Set(value As String)

        End Set
    End Property

    Public Sub SetServiceEndpoint(url As String)
        Dim endpoint As New EndpointAddress(ClientEndpoint)
        Dim binding = New BasicHttpBinding()
        binding.MaxReceivedMessageSize = 2147483647 ' 100 mb max
        binding.MaxBufferSize = 2147483647
        SetServiceEndpoint(New LampRemoteWcfClient(binding, New EndpointAddress(url)))
    End Sub

    Public Sub SetServiceEndpoint(sender As ILampWcfClient)
        CurrentSender = sender
    End Sub





    Sub InitalizeLibraries()
        ' extract necessary dll files
        ' put folder in DLL path
    End Sub

    Public Sub ShowLoginError(parentForm As Form)
        MessageBox.Show("Login Expired: please login again")
        Logout(Nothing, parentForm)
    End Sub

    Public Sub ShowError([error] As LampStatus)
        MessageBox.Show("An error occurred: " + [error].ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Function ValidateEmail(email As String) As Boolean
        Return New EmailAddressAttribute().IsValid(email)
    End Function

    Public Const MIN_PASSWORD_LENGTH = 6

    Public Function DistanceTwoPoints(first As Vector3, second As Vector3)
        Return Math.Sqrt((first.X - second.X) ^ 2 + (first.Y - second.Y) ^ 2)
    End Function

End Module

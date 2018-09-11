Imports System.IO
Imports Newtonsoft.Json
Imports System.ComponentModel.DataAnnotations
Imports System.ServiceModel
Imports System.Text.RegularExpressions
Imports LampCommon
Imports LampService
Imports netDxf
Imports System.Runtime.CompilerServices

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

Public Module Settings
    Public Property ClientEndpoint As LampWcfClientSettings
        Get
            If My.Settings.ClientEndpoint Is Nothing Then
                ' set it to default (local)
                Settings.ClientEndpoint = New LampWcfClientSettings(True, "")
            End If

            Return My.Settings.ClientEndpoint
        End Get
        Set(value As LampWcfClientSettings)
            My.Settings.ClientEndpoint = value
            My.Settings.Save()
        End Set
    End Property

    Public Property LoginPassword As String
        Get
            If My.Settings.LoginPassword Is Nothing Then
                ' set it to default (local)
                Settings.LoginPassword = ""
            End If

            Return My.Settings.LoginPassword
        End Get
        Set(value As String)
            My.Settings.LoginPassword = value
            My.Settings.Save()
        End Set
    End Property

    Public Property LoginUsername As String
        Get
            If My.Settings.LoginUsername Is Nothing Then
                ' set it to default (local)
                Settings.LoginUsername = ""
            End If

            Return My.Settings.LoginUsername
        End Get
        Set(value As String)
            My.Settings.LoginUsername = value
            My.Settings.Save()
        End Set
    End Property

    Public Property PasswordSaved As Boolean
        Get
            Return My.Settings.PasswordSaved
        End Get
        Set(value As Boolean)
            If Not value Then
                Settings.LoginPassword = ""
            End If
            My.Settings.PasswordSaved = value
            My.Settings.Save()
        End Set
    End Property

    Public Property DesignerProgram As OpenType
        Get
            If My.Settings.DesignerProgram Is Nothing Then
                Settings.DesignerProgram = New OpenType(False, "C:\Program Files\Autodesk\AutoCAD 2018\acad.exe")
            End If
            Return My.Settings.DesignerProgram
        End Get
        Set(value As OpenType)
            My.Settings.DesignerProgram = value
            My.Settings.Save()
        End Set
    End Property


End Module



Public Module OwO
    Public Property CurrentUser As LampUser = New LampUser(GetNewGuid, UserPermission.Admin, "none@gmail.comg", "debugUser", "password", "debugger")


    Public Property CurrentSender As ILampWcfClient

    Public Sub SetServiceEndPoint(settings As LampWcfClientSettings)
        If settings Is Nothing Then
            Throw New ArgumentNullException(NameOf(settings))
        End If
        If settings.UseLocal Then
            SetServiceEndpoint(LampLocalWcfClient.Local)
        Else
            SetServiceEndpoint(settings.ServerAddress)
        End If
    End Sub

    Public Sub SetServiceEndpoint(url As String)
        Dim endpoint As New EndpointAddress(url)
        Dim binding = New BasicHttpBinding()
        binding.MaxReceivedMessageSize = 2147483647 ' as big as possible
        binding.MaxBufferSize = 2147483647
        SetServiceEndpoint(New LampRemoteWcfClient(binding, endpoint))
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

    <Extension>
    Public Function IsItemSelected(this As ListBox) As Boolean
        Return this.SelectedIndex <> -1
    End Function


    <Extension>
    Public Function ItemSelected(this As ListBox) As String
        If Not this.IsItemSelected Then
            Throw New InvalidOperationException("No item selected")
        End If
        Return this.Items(this.SelectedIndex).ToString
    End Function
End Module

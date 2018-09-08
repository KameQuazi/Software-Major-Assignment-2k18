Imports System.ComponentModel.DataAnnotations
Imports System.ServiceModel
Imports System.Text.RegularExpressions
Imports LampCommon
Imports LampService






Public Module OwO
    Public Property CurrentUser As LampUser = New LampUser(GetNewGuid, UserPermission.Admin, "none@gmail.comg", "debugUser", "password", "debugger")

    Public Property CurrentSender As ILampServiceBoth

    Public Property ClientEndpoint As String = "http://localhost:8733/Design_Time_Addresses/LampService.svc"

    Public Sub SetServiceEndpoint(url As String)
        Dim endpoint As New EndpointAddress(ClientEndpoint)
        Dim binding = New BasicHttpBinding()
        binding.MaxReceivedMessageSize = 100000000 ' 100 mb max
        ' CurrentSender = New LampRemoteWcfClient(binding, New EndpointAddress(url))
        SetServiceEndpoint(New LampRemoteWcfClient(binding, New EndpointAddress(url)))
    End Sub

    Public Sub SetServiceEndpoint(sender As ILampServiceBoth)
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

End Module

Imports System.Runtime.CompilerServices
Imports LampCommon
Imports LampService

''' <summary>
''' includes some convience functions ...
''' </summary>
Public Interface ILampWcfClient
    Inherits ILampServiceClient

End Interface

Public Module WcfClientExtension
    <Extension>
    Public Function Authenticate(self As ILampWcfClient, username As String, password As String) As LampUserWrapper
        Return self.Authenticate(New LampCredentials(username, password))
    End Function
End Module
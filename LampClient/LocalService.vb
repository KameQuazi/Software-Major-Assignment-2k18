Imports LampClient.LampServiceReference
Imports LampCommon

Public Class LocalService
    Implements ILampService

    Public Function Add(n1 As Double, n2 As Double) As Double Implements ILampService.Add
        Throw New NotImplementedException()
    End Function

    Public Function AddAsync(n1 As Double, n2 As Double) As Task(Of Double) Implements ILampService.AddAsync
        Throw New NotImplementedException()
    End Function

    Public Function Authenticate(username As String, password As String) As LampUserWrapper Implements ILampService.Authenticate
        Throw New NotImplementedException()
    End Function

    Public Function AuthenticateAsync(username As String, password As String) As Task(Of LampUserWrapper) Implements ILampService.AuthenticateAsync
        Throw New NotImplementedException()
    End Function

    Public Function Return1() As Integer Implements ILampService.Return1
        Throw New NotImplementedException()
    End Function

    Public Function Return1Async() As Task(Of Integer) Implements ILampService.Return1Async
        Throw New NotImplementedException()
    End Function
End Class

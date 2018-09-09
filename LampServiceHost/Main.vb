Imports System.Collections.Specialized
Imports System.Configuration
Imports System.ServiceModel.Configuration
Imports LampService
Imports LampCommon

Public Module OwOHost
    Public hoster As New LampHost()

    Sub Main()

        hoster.StartListenerFromConfig()
        Try
            Console.WriteLine(String.Format("Service started on {0}", hoster.BaseAddress))
            StartConsoleLoop

        Catch
        End Try

        hoster.Close()
    End Sub

    Sub StartConsoleLoop()
        Nodes.StartNode.SetNew()
        While True
            HandledLine(Console.ReadLine())
        End While
    End Sub
    Public Delegate Sub TextEntryHandler(text As String)

    Public HandledLine As TextEntryHandler
    Public HandledError As TextEntryHandler
    Public HandledStart As TextEntryHandler


End Module

Public Module Nodes
    Public StartNode As New StartNode()
    Public HelpNode As New HelpNode()
    Public AddUserNode As New AddUserNode
End Module

Public MustInherit Class ConsoleNode

    Public MustOverride Sub HandleLine(text As String)

    Public MustOverride Sub HandleError(text As String)

    Public MustOverride Sub HandleStart(text As String)

    Public Sub SetNew()
        HandledLine = AddressOf HandleLine
        HandledError = AddressOf HandleError
        HandledStart = AddressOf HandleStart
        HandledStart(Nothing)
    End Sub


End Class

Public Class StartNode
    Inherits ConsoleNode


    Sub New()
        MyBase.New()
    End Sub


    Public Overrides Sub HandleLine(text As String)
        text = text.ToLower()
        Select Case text
            Case "help"
                Nodes.HelpNode.SetNew()
            Case "adduser"
                Nodes.AddUserNode.SetNew()

            Case Else
                HandleError(Nothing)

        End Select
    End Sub

    Public Overrides Sub HandleError(text As String)
        Nodes.HelpNode.SetNew()
    End Sub

    Public Overrides Sub HandleStart(text As String)
        Console.WriteLine("Enter command:")
    End Sub


End Class

Public Class HelpNode
    Inherits ConsoleNode

    Public Overrides Sub HandleLine(text As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub HandleError(text As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub HandleStart(text As String)
        Console.WriteLine("LampHost command line\n Commands available:\n help\n adduser\n".Replace("\n", vbCrLf))
    End Sub
End Class

Public Class AddUserNode
    Inherits ConsoleNode

    Public Overrides Sub HandleError(text As String)
        Console.WriteLine("Invalid options suppled, please try again")
    End Sub

    Public Overrides Sub HandleLine(text As String)
        Dim items = text.Split(",")

        If items.Count = 4 AndAlso Integer.TryParse(items(1), New Integer) AndAlso Integer.Parse(items(1)) <= 3 AndAlso Integer.Parse(items(1)) >= 0 Then
            hoster.Database.SetUser(New LampUser(GetNewGuid, Integer.Parse(items(1)), "", items(2), items(3), items(0)))
            Nodes.StartNode.SetNew()
        Else
            HandleError(Nothing)
        End If
    End Sub

    Public Overrides Sub HandleStart(text As String)
        Console.WriteLine("Enter the following 4 fields, seperated by commas: \n name, permissionlevel(0=guest,1=standard,2=elevated,3=admin), username, password".Replace("\n", vbCrLf))
    End Sub
End Class
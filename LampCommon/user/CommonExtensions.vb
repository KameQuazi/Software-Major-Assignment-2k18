Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel

Public Module CommonExtensions
    <System.Runtime.CompilerServices.Extension()>
    Public Function ToSingle(this As Double) As Single
        Return Convert.ToSingle(this)
    End Function



    <System.Runtime.CompilerServices.Extension>
    Public Function ToObservableList(Of T)(this As List(Of T)) As ObservableCollection(Of T)
        Return New ObservableCollection(Of T)(this)
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function ToList(Of T)(this As ObservableCollection(Of T)) As List(Of T)
        Return New List(Of T)(this)
    End Function

    ''' <summary>
    ''' Clears a list so that it has that many elements left
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    <System.Runtime.CompilerServices.Extension>
    Public Sub ClearAsArray(Of T)(this As IList(Of T), Optional size As Integer = LampTemplate.MaxImages)
        this.Clear()
        For i = 0 To size - 1
            this.Add(Nothing)
        Next
    End Sub

    <System.Runtime.CompilerServices.Extension>
    Public Function HasNotNothing(Of T)(this As IList(Of T)) As Boolean
        For Each item In this
            If item IsNot Nothing Then
                Return True
            End If
        Next
        Return False
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Sub InvokeEx(this As ISynchronizeInvoke, action As Action(Of ISynchronizeInvoke))
        If this.InvokeRequired Then
            this.Invoke(action, New Object() {this})
        Else

            action(this)
        End If
    End Sub

    Public Function GetNewGuid() As String
        Return Guid.NewGuid().ToString()
    End Function
End Module

Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports netDxf

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
    Public Sub SafeInvokeEx(this As ISynchronizeInvoke, action As Action(Of ISynchronizeInvoke), Optional Handler As Action(Of Exception) = Nothing)
        Try
            If this.InvokeRequired Then
                this.Invoke(action, New Object() {this})
            Else

                action(this)
            End If
        Catch e As Exception
            If Handler IsNot Nothing Then
                Handler(e)
            End If
        End Try
    End Sub

    Public Function GetNewGuid() As String
        Return Guid.NewGuid().ToString()
    End Function
    <Extension>
    Public Function ContainsString(self As IEnumerable(Of DynamicTextKey), textbuff As String) As Boolean
        For Each key In self
            If key.ParameterName.ToLower = textbuff.ToLower() Then
                Return True
            End If
        Next
        Return False
    End Function

    <Extension>
    Public Sub AddRange(Of T)(self As ObservableCollection(Of T), range As IEnumerable(Of T))
        If range Is Nothing Then
            Return
        End If
        For Each item In range
            self.Add(item)
        Next
    End Sub


    <Extension>
    Public Function TrimFinalCharacter(self As String)
        If String.IsNullOrEmpty(self) Then
            Return self
        Else
            Return self.Remove(self.Length - 1)
        End If
    End Function

    <Extension>
    Public Sub Log(array As String(), message As String)
#If DEBUG Then
        Console.WriteLine(message)
#End If
        Dim x As List(Of String) = array.ToList()
        x.Sort()
        x.CopyTo(array)

    End Sub

    <Extension>
    Public Function ToAci(this As Color) As AciColor
        Return New AciColor(this)
    End Function



End Module

Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization
Imports netDxf
Imports Newtonsoft.Json

''' <summary>
''' The location where a template should be inserted into the board
''' </summary>
<JsonObject(MemberSerialization.OptIn)>
<DataContract>
Public Class LampDxfInsertLocation
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private _insertionPoint As Vector3
    ''' <summary>
    ''' Where the text should be inserted
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("insertPoint")>
    <DataMember>
    Public Property InsertPoint As Vector3
        Get
            Return _insertionPoint
        End Get
        Set(value As Vector3)
            _insertionPoint = value
            NotifyPropertyChanged()
        End Set
    End Property

    ''' <summary>
    ''' Rotation in degrees of the item inserted
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("rotation")>
    <DataMember>
    Public Property Rotation As Double

    ''' <summary>
    ''' The what texts to insert
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("dynamicTextData")>
    <DataMember>
    Public Property DynamicTextData As New DynamicTextDataStore

    Sub New(point As Vector3)
        Me.InsertPoint = point
    End Sub
End Class

Public Class DynamicTextDataStore
    Inherits Dictionary(Of DynamicTextKey, DynamicTextValue)

End Class

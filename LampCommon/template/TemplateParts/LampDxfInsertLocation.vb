Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization
Imports netDxf
Imports Newtonsoft.Json



''' <summary>
''' The location where a template should be inserted into the board
''' this encompasses 1 single object to insert
''' </summary>
<JsonObject(MemberSerialization.OptIn)>
<DataContract>
Public Class LampSingleDxfInsertLocation
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private _insertionPoint As Vector3
    ''' <summary>
    ''' Where the item
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
    <Browsable(False)>
    Public Property DynamicTextData As New DynamicTextDictionary

    Sub New(point As Vector3)
        Me.InsertPoint = point
    End Sub
End Class

''' <summary>
''' More than 1 single object (1 board)
''' this represents 1 sheet of dxf objects to put into the laser cutter
''' </summary>
<DataContract>
Public Class LampMultipleInsertLocation
    Inherits ObservableCollection(Of LampSingleDxfInsertLocation)
End Class
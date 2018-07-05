Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization
Imports Newtonsoft.Json

''' <summary>
''' The value for a <see cref="DynamicTextKey"></see>
''' </summary>
<JsonObject(MemberSerialization.OptIn)>
<DataContract>
Public Class DynamicTextValue
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private _value As Object
    ''' <summary>
    ''' The text to insert into the finished Template
    ''' Value will be:
    ''' String, for richtextbox
    ''' boolean, for checkbox
    ''' Nothing, for nothing
    ''' Image, for PictureBox
    ''' IList(Of text), for ListView
    ''' String, for combobox
    ''' NOTE - not all are actually implemented ;-;
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("value")>
    <DataMember>
    Public Property Value As Object
        Get
            Return _value
        End Get
        Set(input As Object)
            NotifyPropertyChanged()
            _value = input
        End Set
    End Property

End Class

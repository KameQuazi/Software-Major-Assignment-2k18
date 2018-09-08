Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization
Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptIn)>
<DataContract>
Public Class LampProfile
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private _username As String
    ''' <summary>
    ''' The username of the person, used to login
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("username")>
    <DataMember>
    Public Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _name As String
    ''' <summary>
    ''' The full name of the person
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("name")>
    <DataMember>
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _userid As String
    ''' <summary>
    ''' user guid 
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("userId")>
    <DataMember>
    Public Property UserId As String
        Get
            Return _userid
        End Get
        Set(value As String)
            _userid = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _permissionLevel As UserPermission
    <JsonProperty("permissionLevel")>
    <DataMember>
    Public Property PermissionLevel As UserPermission
        Get
            Return _permissionLevel
        End Get
        Set(value As UserPermission)
            _permissionLevel = value
            NotifyPropertyChanged()
        End Set
    End Property


    ''' <summary>
    ''' constructor for <see cref="LampProfile"></see>
    ''' </summary>
    ''' <param name="username"></param>
    ''' <param name="name"></param>
    ''' <param name="userid"></param>
    Sub New(username As String, name As String, userid As String, permissionLevel As UserPermission)
        Me.Username = username
        Me.Name = name
        Me.UserId = userid
        Me.PermissionLevel = permissionLevel
    End Sub
End Class

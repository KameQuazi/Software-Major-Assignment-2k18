Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization
Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptIn)>
<DataContract>
Public Class LampJob
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private _jobId As String
    ''' <summary>
    ''' The job id of this job
    ''' </summary>
    ''' <returns></returns>
    ''' 
    <JsonProperty("job_id")>
    Public Property JobId As String
        Get
            Return _jobId
        End Get
        Set(value As String)
            _jobId = value
            NotifyPropertyChanged()
        End Set
    End Property


    Private _dynamicTextDict As ObservableCollection(Of DynamicTextDictionary)
    ''' <summary>
    ''' Where the dynamic stuff
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("dynamic_text_dictionary")>
    <DataMember>
    Public Property DynamicTextDictionaries As ObservableCollection(Of DynamicTextDictionary)
        Get
            Return _dynamicTextDict
        End Get
        Private Set(value As ObservableCollection(Of DynamicTextDictionary))
            If _dynamicTextDict IsNot Nothing Then
                RemoveHandler _dynamicTextDict.CollectionChanged, AddressOf DynamicTextDictionary_PropertyChanged
            End If
            _dynamicTextDict = value

            If _dynamicTextDict IsNot Nothing Then
                AddHandler _dynamicTextDict.CollectionChanged, AddressOf DynamicTextDictionary_PropertyChanged
            End If
        End Set
    End Property
    ''' <summary>
    ''' Handler for dynamic text changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DynamicTextDictionary_PropertyChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        NotifyPropertyChanged("DynamicTextDictionary")
    End Sub

    Private _template As LampTemplate
    ''' <summary>
    ''' the base template that the job is based off of
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("template")>
    Public Property Template As LampTemplate
        Get
            Return _template
        End Get
        Set(value As LampTemplate)
            If _template IsNot Nothing Then
                RemoveHandler _template.PropertyChanged, AddressOf Template_PropertyChanged
            End If
            _template = value
            If _template IsNot Nothing Then
                AddHandler _template.PropertyChanged, AddressOf Template_PropertyChanged
            End If

            NotifyPropertyChanged()
        End Set
    End Property

    ''' <summary>
    ''' handler for template changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Template_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
        NotifyPropertyChanged(NameOf(Template))
    End Sub

    Private _submitter As LampProfile
    ''' <summary>
    ''' The submitter of 
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("submitter_profile")>
    Public Property Submitter As LampProfile
        Get
            Return _submitter
        End Get
        Set(value As LampProfile)
            If _submitter IsNot Nothing Then
                RemoveHandler _submitter.PropertyChanged, AddressOf Submitter_PropertyChanged
            End If
            _submitter = value
            If _submitter IsNot Nothing Then
                AddHandler _submitter.PropertyChanged, AddressOf Submitter_PropertyChanged
            End If
            NotifyPropertyChanged()
        End Set
    End Property

    Private Sub Submitter_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
        NotifyPropertyChanged(NameOf(Submitter))
    End Sub

    Private _approver As LampProfile
    <JsonProperty("approver_profile")>
    Public Property Approver As LampProfile
        Get
            Return _approver
        End Get
        Set(value As LampProfile)
            If _approver IsNot Nothing Then
                RemoveHandler _approver.PropertyChanged, AddressOf Approver_PropertyChanged
            End If
            _approver = value
            If _approver IsNot Nothing Then
                AddHandler _approver.PropertyChanged, AddressOf Approver_PropertyChanged
            End If
            NotifyPropertyChanged()
        End Set
    End Property

    Private Sub Approver_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
        NotifyPropertyChanged(NameOf(Approver))
    End Sub

    Public Property Approved As Boolean

    Public Property SubmitDate As Date?

    ''' <summary>
    ''' The completed drawing, w/ all the templates laid out appropriately
    ''' Not serialized, as it can be generated using _template when deserialized
    ''' </summary>
    Public Property CompletedDrawing As LampDxfDocument

    Private _insertionLocations As New ObservableCollection(Of LampDxfInsertLocation)
    ''' <summary>
    ''' Where each individual trophy will be inserted (in cartesian form) on the competedDrawing
    ''' Contains rotation data, dynamic text data, everything required to rebuild the
    ''' completeddrawing
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("insertion_locations")>
    <DataMember>
    Public Property InsertionLocations As ObservableCollection(Of LampDxfInsertLocation)
        Get
            Return _insertionLocations
        End Get
        Set(value As ObservableCollection(Of LampDxfInsertLocation))
            If _insertionLocations IsNot Nothing Then
                RemoveHandler _insertionLocations.CollectionChanged, AddressOf InsertionLocations_CollectionChanged
            End If
            _insertionLocations = value
            If _insertionLocations IsNot Nothing Then
                AddHandler _insertionLocations.CollectionChanged, AddressOf InsertionLocations_CollectionChanged
            End If
            NotifyPropertyChanged()
        End Set
    End Property

    ''' <summary>
    ''' event handler for insertion location changing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub InsertionLocations_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        NotifyPropertyChanged(NameOf(InsertionLocations))
    End Sub

    Public ReadOnly Property SubmitId As String
        Get
            If Submitter Is Nothing Then
                Return Nothing
            End If
            Return Submitter.UserId
        End Get
    End Property

    Public ReadOnly Property ApproverId As String
        Get
            If Approver Is Nothing Then
                Return Nothing
            End If
            Return Approver.UserId
        End Get
    End Property


    Sub New(template As LampTemplate, submitter As LampProfile, Optional approver As LampProfile = Nothing, Optional approved As Boolean = False, Optional submitDate As Date? = Nothing)

        If template Is Nothing Then
            Throw New ArgumentNullException(NameOf(template))
        End If
        Me.JobId = System.Guid.NewGuid().ToString()
        Me.Template = template
        Me.Submitter = submitter
        Me.Approver = approver
        Me.Approved = approved
        Me.SubmitDate = submitDate


        Me.DynamicTextDictionaries = New ObservableCollection(Of DynamicTextDictionary)
    End Sub

    ''' <summary>
    ''' Refreshes the _completeDrawing based on the InsertionLocations
    ''' Expensive, dont call too many times
    ''' </summary>
    Public Sub RefreshCompleteDrawing()
        ' TODO!
        CompletedDrawing = New LampDxfDocument()

        For Each point As LampDxfInsertLocation In InsertionLocations
            CompletedDrawing.InsertInto(Template.BaseDrawing, point)
        Next
    End Sub


    Public Sub AddInsertionPoint(point As LampDxfInsertLocation, Optional refresh As Boolean = True)
        InsertionLocations.Add(point)

        If refresh Then
            RefreshCompleteDrawing()
        End If
    End Sub

    Private Sub EnsureCompleteIsUpdated(sender As Object, e As PropertyChangedEventArgs)
        Select Case e.PropertyName
            Case NameOf(Template)
                RefreshCompleteDrawing()
        End Select
    End Sub

#If DEBUG Then
    Public Sub Save(path As String, Optional compress As Boolean = False)
#Else
    Public Sub Save(path As String, Optional compress as boolean = True)
#End If
        Dim formatting As Newtonsoft.Json.Formatting
        If compress Then
            formatting = Formatting.None
        Else
            formatting = Formatting.Indented
        End If

        Using fileStream As New StreamWriter(path)
            fileStream.Write(ToJson(formatting))
        End Using
    End Sub

    ''' <summary>
    ''' Converts -> json format to be saved as a .spf
    ''' </summary>
    ''' <param name="formatting"></param>
    ''' <returns></returns>
    Public Function ToJson(Optional formatting As Formatting = Formatting.None) As String
        Return JsonConvert.SerializeObject(Me, formatting)
    End Function
End Class



Public Class LampJobWrapper
    Public Job As LampJob
    Public Status As LampStatus
End Class

Public Class LampJobListWrapper
    Public Status As LampStatus
    Public Templates As New List(Of LampJob)
End Class
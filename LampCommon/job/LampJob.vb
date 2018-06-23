Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
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
    Public Property JobId As String
        Get
            Return _jobId
        End Get
        Set(value As String)
            _jobId = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _template As LampTemplate
    ''' <summary>
    ''' the base template that the job is based off of
    ''' </summary>
    ''' <returns></returns>
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
    Public Property Submitter As LampProfile
        Get
            Return _submitter
        End Get
        Set(value As LampProfile)
            If _submitter IsNot Nothing Then
                RemoveHandler _submitter.PropertyChanged, AddressOf Submitter_PropertyChanged
            End If
            _submitter = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private Sub Submitter_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
        NotifyPropertyChanged(NameOf(Submitter))
    End Sub

    Public Property Approver As LampProfile

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

    Public Property SubmitId As String
        Get
            Return Submitter.UserId
        End Get
        Set(value As String)
            Submitter.UserId = value
        End Set
    End Property

    Public Property ApproverId As String
        Get
            If Approver Is Nothing Then
                Return Nothing
            End If
            Return Approver.UserId
        End Get
        Set(value As String)
            If Approver Is Nothing Then
                Throw New ArgumentNullException(NameOf(Approver) + " cannot be nothing")
            End If
            Approver.UserId = value
        End Set
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
End Class



Public Class LampJobWrapper
    Public Job As LampJob
    Public Status As LampStatus
End Class
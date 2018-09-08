Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing
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

    Public BoardSize As New SizeF(610, 305)
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

    Public ReadOnly Property Approved As Boolean
        Get
            Return Approver IsNot Nothing
        End Get
    End Property

    Public Property SubmitDate As Date?

    Private _completedDrawings As New List(Of LampDxfDocument)
    ''' <summary>
    ''' The completed drawing, w/ all the templates laid out appropriately
    ''' Not serialized, as it can be generated using _template when deserialized
    ''' </summary>
    <JsonProperty("completed_drawing", Order:=1000)>
    <DataMember>
    Public Property CompleteDrawings As List(Of LampDxfDocument)
        Get
            If needsRegenerate Then
                RefreshCompleteDrawing()
            End If
            Return _completedDrawings

        End Get
        Private Set(value As List(Of LampDxfDocument))
            _completedDrawings = value
        End Set
    End Property


    Private _insertionLocations As New ObservableCollection(Of LampMultipleInsertLocation)
    ''' <summary>
    ''' Each InsertionPages is list of LampMultipleInsertLocation. each multiple insert location locations to 
    ''' 1 dxf document / 1 board of the laser cutter
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("insertion_locations")>
    <DataMember>
    Public Property InsertionPages As ObservableCollection(Of LampMultipleInsertLocation)
        Get
            Return _insertionLocations
        End Get
        Set(value As ObservableCollection(Of LampMultipleInsertLocation))
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
        NotifyPropertyChanged(NameOf(InsertionPages))
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

    Private _summary As String
    ''' <summary>
    ''' a brief summary of job
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("summary")>
    <DataMember>
    Public Property Summary As String
        Get
            Return _summary
        End Get
        Set(value As String)
            _summary = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Pages As Integer
        Get
            Return InsertionPages.Count()
        End Get
        Set(value As Integer)
            If value > InsertionPages.Count Then
                ' add a few new pages
                For i = 1 To value - InsertionPages.Count
                    InsertionPages.Add(New LampMultipleInsertLocation)
                Next
            ElseIf value < InsertionPages.Count Then
                ' remove some pages
                For i = InsertionPages.Count - 1 To value Step -1
                    InsertionPages.RemoveAt(i)
                Next
            End If
        End Set
    End Property

    ''' <summary>
    ''' default constructor for when job needs to be sent to db from client
    ''' will auto-generate the drawing
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="submitter"></param>
    Sub New(template As LampTemplate, submitter As LampProfile, summary As String)
        Me.New(GetNewGuid, template, submitter, Nothing, summary, DateTime.Now)
        RefreshCompleteDrawing()
    End Sub

    ''' <summary>
    ''' constructor for when job needs to be sent to db from client
    ''' will auto-generate the drawing
    ''' </summary>
    ''' <param name="template"></param>
    Sub New(template As LampTemplate)
        Me.New(GetNewGuid, template, Nothing, Nothing, Nothing, DateTime.Now)
        RefreshCompleteDrawing()
    End Sub

    ''' <summary>
    ''' constructor for a complete lampJob
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="submitter"></param>
    ''' <param name="approver"></param>
    ''' <param name="submitDate"></param>
    ''' <param name="CompleteDrawings"></param>
    Sub New(jobId As String, template As LampTemplate, submitter As LampProfile, approver As LampProfile, summary As String, submitDate As Date?, Optional CompleteDrawings As List(Of LampDxfDocument) = Nothing)

        If template Is Nothing Then
            Throw New ArgumentNullException(NameOf(template))
        End If
        Me.JobId = jobId
        Me.Template = template
        Me.Submitter = submitter
        Me.Approver = approver
        Me.SubmitDate = submitDate
        If CompleteDrawings IsNot Nothing Then
            Me.CompleteDrawings = CompleteDrawings
        End If
        Me.Summary = summary

    End Sub

    Public ReadOnly Property Parameters As ObservableCollection(Of DynamicTextKey)
        Get
            Return Me.Template?.DynamicTextList
        End Get
    End Property

    Private needsRegenerate As Boolean = False

    ''' <summary>
    ''' adds a new template to 
    ''' </summary>
    ''' <param name="values"></param>
    Public Sub AddCopy(values As IEnumerable(Of DynamicTextKey), Optional regenerate As Boolean = True)
        If values.Count <> Parameters.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(values) + "should be same length as parameters")

        End If

        ' do some magic here
        ' take into account the board size
    End Sub



    ''' <summary>
    ''' Refreshes the _completeDrawing based on the InsertionLocations
    ''' Expensive, dont call too many times
    ''' </summary>
    Public Sub RefreshCompleteDrawing()
        ' TODO!
        CompleteDrawings.Clear()


        For Each singleBoardInsert In InsertionPages
            ' each drawing
            Dim newDrawing As New LampDxfDocument

            For Each invidualTemplate In singleBoardInsert
                ' todo insert dyanmic text
                Template.BaseDrawing.InsertInto(newDrawing, invidualTemplate)

            Next

            CompleteDrawings.Add(newDrawing)
        Next
    End Sub




    Private Sub AddNewPage()
        InsertionPages.Add(New LampMultipleInsertLocation)
    End Sub

    Private Sub AddInsertionPoint(point As LampSingleDxfInsertLocation, page As Integer, Optional refresh As Boolean = False)
        If page >= InsertionPages.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(page))
        End If

        InsertionPages(page).Add(point)

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
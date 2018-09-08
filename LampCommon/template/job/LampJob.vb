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

    Private _boardSize As New SizeF(610, 305)
    <JsonProperty("board_size")>
    <DataMember>
    Public Property BoardSize As SizeF
        Get
            Return _boardSize
        End Get
        Private Set(value As SizeF)
            _boardSize = value
        End Set
    End Property

    Private _jobId As String
    ''' <summary>
    ''' The job id of this job
    ''' </summary>
    ''' <returns></returns>
    ''' 
    <JsonProperty("job_id")>
    <DataMember>
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

    Public Shared ValidateDist As Boolean = False

    Private _template As LampTemplate
    ''' <summary>
    ''' the base template that the job is based off of
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("template")>
    <DataMember>
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

            If ValidateDist Then

                If TemplateWidth + 2 * SeperationDist > BoardWidth Then
                    ' cannot even fit one, just exit
                    Throw New ArgumentOutOfRangeException(String.Format("Template is too high for laser cutter bed [widthWithpadding={0}, boardWidth={1}]", TemplateWidth + 2 * SeperationDist, BoardWidth))
                End If

                If TemplateHeight + 2 * SeperationDist > BoardHeight Then
                    ' cannot even fit one, just exit
                    Throw New ArgumentOutOfRangeException(String.Format("Template is too high for laser cutter bed [heightWithPadding={0}, boardHeight={1}]", TemplateHeight + 2 * SeperationDist, BoardHeight))
                End If
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
    <DataMember>
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
    <DataMember>
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
                needsRegenerate = False
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

    Public Property SubmitId As String
        Get
            Return Submitter?.UserId
        End Get
        Set(value As String)
            Submitter = New LampProfile(Nothing, Nothing, value, UserPermission.Invalid)
        End Set
    End Property

    Public Property ApproverId As String
        Get
            Return Approver?.UserId
        End Get
        Set(value As String)
            Approver = New LampProfile(Nothing, Nothing, value, UserPermission.Invalid)
        End Set
    End Property

    Private _summary As String = ""
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
        Me.New(GetNewGuid, template, submitter, Nothing, summary, Nothing)
    End Sub

    ''' <summary>
    ''' constructor for when job needs to be sent to db from client
    ''' will auto-generate the drawing
    ''' </summary>
    ''' <param name="template"></param>
    Sub New(template As LampTemplate)
        Me.New(GetNewGuid, template, Nothing, Nothing, "", Nothing)
    End Sub

    ''' <summary>
    ''' constructor for a complete lampJob
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="submitter"></param>
    ''' <param name="approver"></param>
    ''' <param name="submitDate"></param>
    ''' <param name="CompleteDrawings"></param>
    Sub New(jobId As String, template As LampTemplate, submitter As LampProfile, approver As LampProfile, summary As String, submitDate As Date?, Optional boardSize As SizeF? = Nothing, Optional CompleteDrawings As List(Of LampDxfDocument) = Nothing)

        If template Is Nothing Then
            Throw New ArgumentNullException(NameOf(template))
        End If
        If boardSize IsNot Nothing Then
            Me.BoardSize = boardSize
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

    Public Property TemplateHeight As Double
        Get
            Return Template?.Height
        End Get
        Set(value As Double)
            Template.Height = value
        End Set
    End Property

    Public Property TemplateWidth As Double
        Get
            Return Template?.Width
        End Get
        Set(value As Double)
            Template.Width = value
        End Set
    End Property


    Public Property BoardHeight As Double
        Get
            Return BoardSize.Height
        End Get
        Set(value As Double)
            BoardSize = New SizeF(BoardSize.Width, value)
        End Set
    End Property

    Public Property BoardWidth As Double
        Get
            Return BoardSize.Width
        End Get
        Set(value As Double)
            BoardSize = New SizeF(value, BoardSize.Height)
        End Set
    End Property



    Private Function CanFitWidth(currentX As Double) As Boolean
        Return currentX + TemplateWidth + SeperationDist <= BoardWidth
    End Function

    Private Function CanFitHeight(currentY As Double) As Boolean
        Return currentY + TemplateHeight + SeperationDist <= BoardHeight
    End Function

    Private Const SeperationDist As Integer = 5

    Public Sub SetCopies(values As IList(Of List(Of DynamicTextValue)), Optional regenerate As Boolean = True)
        Dim currentX As Double = SeperationDist
        Dim currentY As Double = SeperationDist ' assume that it can fit a height, (since templateheight is validated at initial)
        Dim currentPage As Integer = 0

        InsertionPages.Clear()

        AddNewPage()
        For Each row In values
            If row.Count <> Parameters.Count Then
                Throw New ArgumentOutOfRangeException(NameOf(values))
            End If

            ' we will tile from top left to bottom right
            ' we assume all boxes are same height
            ' when it reaches the end, it will drop down
            ' get the last element's 

            ' check if the template will fit
            ' check if there is enoguh width 
            If CanFitWidth(currentX) Then
                ' add a template here

            Else
                ' move back to left
                currentX = SeperationDist
                ' try to go up 
                If CanFitHeight(SeperationDist + TemplateHeight) Then
                    currentY += SeperationDist + TemplateHeight

                Else
                    ' new page
                    currentPage += 1
                    AddNewPage()
                    currentY = SeperationDist
                End If
            End If
            Dim sng As New LampSingleDxfInsertLocation(New netDxf.Vector3(currentX, currentY, 0))

            For i = 0 To Parameters.Count - 1
                sng.DynamicTextData.Add(Parameters(i), row(i))
            Next
            AddInsertionPoint(sng, currentPage)
            currentX += SeperationDist + TemplateWidth
        Next
    End Sub



    ''' <summary>
    ''' Refreshes the _completeDrawing based on the InsertionLocations
    ''' Expensive, dont call too many times
    ''' </summary>
    Public Sub RefreshCompleteDrawing()
        ' TODO!
        _completedDrawings.Clear()


        For Each singleBoardInsert In InsertionPages
            ' each drawing
            Dim newDrawing As New LampDxfDocument

            For Each invidualTemplate In singleBoardInsert
                ' todo insert dyanmic text
                Template.BaseDrawing.InsertInto(newDrawing, invidualTemplate)

            Next

            _completedDrawings.Add(newDrawing)
        Next
    End Sub




    Private Sub AddNewPage()
        InsertionPages.Add(New LampMultipleInsertLocation)
    End Sub

    Private Sub AddInsertionPoint(point As LampSingleDxfInsertLocation, page As Integer)
        If page >= InsertionPages.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(page))
        End If

        InsertionPages(page).Add(point)

        needsRegenerate = True
    End Sub

    Private Sub AddInsertionPoint(x As Double, y As Double, page As Integer)
        Dim insertPoint As New LampSingleDxfInsertLocation(New netDxf.Vector3(x, y, 0))
        AddInsertionPoint(insertPoint, page)
    End Sub

    Private Sub EnsureCompleteIsUpdated(sender As Object, e As PropertyChangedEventArgs)
        Select Case e.PropertyName
            Case NameOf(Template)
                needsRegenerate = True
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
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.CompilerServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Drawing
Imports System.Runtime.Serialization
Imports LampCommon

<DataContract>
<JsonObject(MemberSerialization.OptIn)>
<KnownType(GetType(LampTemplate))>
<KnownType(GetType(LampProfile))>
Public Class LampTemplateMetadata
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Function ToLampTemplate() As LampTemplate
        Dim ret As New LampTemplate()
        ret.GUID = GUID
        ret.Name = Name
        ret.ShortDescription = ShortDescription
        ret.LongDescription = LongDescription
        ret.Material = Material
        ret.Width = Width
        ret.Height = Height
        ret.MaterialThickness = MaterialThickness
        ret.IsComplete = IsComplete
        ret.ApproverProfile = ApproverProfile
        ret.CreatorProfile = CreatorProfile
        ret.SubmitDate = SubmitDate
        ret.IsComplete = IsComplete
        ret.BoundsLock = BoundsLock
        Return ret
    End Function


    Private _guid As String
    ''' <summary>
    ''' a unique identifer for each different template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("guid")>
    <DataMember()>
    Public Property GUID As String
        Get
            Return _guid
        End Get
        Set(value As String)
            _guid = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _name As String = ""
    ''' <summary>
    ''' a unique identifer for each different template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("Name")>
    <DataMember()>
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _shortDescription As String = ""
    ''' <summary>
    ''' a unique identifer for each different template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("ShortDescription")>
    <DataMember()>
    Public Property ShortDescription As String
        Get
            Return _shortDescription
        End Get
        Set(value As String)
            _shortDescription = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _longDescription As String = ""

    ''' <summary>
    ''' a unique identifer for each different template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("LongDescription")>
    <DataMember()>
    Public Property LongDescription As String
        Get
            Return _longDescription
        End Get
        Set(value As String)
            _longDescription = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _material As String = "Unspecified"
    ''' <summary>
    ''' material the trophy is made out of
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("material")>
    <DataMember()>
    Public Property Material As String
        Get
            Return _material
        End Get
        Set(value As String)
            _material = value
            NotifyPropertyChanged()
        End Set
    End Property




    Private _width As Double
    ''' <summary>
    ''' The length of all of the template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("width")>
    <DataMember()>
    Public Property Width As Double
        Get
            Return _width
        End Get
        Set(value As Double)
            _width = value
            NotifyPropertyChanged()
        End Set
    End Property


    Private _height As Double
    ''' <summary>
    ''' The  height of all the template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("height")>
    <DataMember()>
    Public Property Height As Double
        Get
            Return _height
        End Get
        Set(value As Double)
            _height = value
            NotifyPropertyChanged()
        End Set
    End Property

    <JsonProperty("bound_lock")>
    <DataMember>
    Private _boundsLock As Boolean = False
    Public Property BoundsLock As Boolean
        Get
            Return _boundsLock
        End Get
        Set(value As Boolean)
            _boundsLock = value
            NotifyPropertyChanged()
        End Set
    End Property


    Private _materialThickness As Double
    ''' <summary>
    ''' The thickness of the material used
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("material_thickness")>
    <DataMember()>
    Public Property MaterialThickness As Double
        Get
            Return _materialThickness
        End Get
        Set(value As Double)
            _materialThickness = value
            NotifyPropertyChanged()
        End Set
    End Property


    ''' <summary>
    ''' Name, email of creator if exists
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("creator_profile")>
    <DataMember>
    Public Property CreatorProfile As LampProfile = Nothing

    <IgnoreDataMember>
    Public ReadOnly Property CreatorId As String
        Get
            Return CreatorProfile?.UserId
        End Get
    End Property

    ''' <summary>
    ''' name, email of approver if exists
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("approver_profile")>
    <DataMember>
    Public Property ApproverProfile As LampProfile = Nothing

    <IgnoreDataMember>
    Public ReadOnly Property Approved As Boolean
        Get
            Return ApproverProfile IsNot Nothing
        End Get
    End Property

    Private _submitDate As Date?
    ''' <summary>
    ''' The date item was submitted
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("submit_date")>
    <DataMember()>
    Public Property SubmitDate As Date?
        Get
            Return _submitDate
        End Get
        Set(value As Date?)
            _submitDate = value
            NotifyPropertyChanged()
        End Set
    End Property


    Private _complete As Boolean
    ''' <summary>
    ''' The date item was submitted
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("is_complete")>
    <DataMember()>
    Public Property IsComplete As Boolean
        Get
            Return _complete
        End Get
        Set(value As Boolean)
            _complete = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Sub New()
        Me.New(GetNewGuid())
    End Sub

    Public Sub New(guid As String)
        Me.GUID = guid
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        Dim data = TryCast(obj, LampTemplateMetadata)
        If data Is Nothing Then
            Return False
        End If

        If data.GUID IsNot Nothing Then
            If Not data.GUID.Equals(GUID) Then
                Return False
            End If
        Else ' is nothing
            If GUID IsNot Nothing Then
                Return False
            End If
        End If

        If data.ShortDescription IsNot Nothing Then
            If Not data.ShortDescription.Equals(ShortDescription) Then
                Return False
            End If
        Else ' is nothing
            If ShortDescription IsNot Nothing Then
                Return False
            End If
        End If


        If Not data.LongDescription.Equals(LongDescription) Then
            Return False
        End If

        If Not data.Material.Equals(Material) Then
            Return False
        End If

        If Not data.Width.Equals(Width) Then
            Return False
        End If

        If Not data.Height.Equals(Height) Then
            Return False
        End If

        If Not data.MaterialThickness.Equals(MaterialThickness) Then
            Return False
        End If

        If data.CreatorProfile IsNot Nothing Then
            If Not data.CreatorProfile.Equals(CreatorProfile) Then
                Return False
            End If
        Else ' is nothing
            If CreatorProfile IsNot Nothing Then
                Return False
            End If
        End If


        If data.ApproverProfile IsNot Nothing Then
            If Not data.CreatorProfile.Equals(CreatorProfile) Then
                Return False
            End If
        Else ' is nothing
            If ApproverProfile IsNot Nothing Then
                Return False
            End If
        End If

        If Not data.SubmitDate.Equals(SubmitDate) Then
            Return False
        End If

        If Not data.IsComplete.Equals(IsComplete) Then
            Return False
        End If

        If Not data.BoundsLock.Equals(BoundsLock) Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Me.GUID.GetHashCode()
    End Function
End Class


<JsonObject(MemberSerialization.OptIn)>
<DataContract()>
<KnownType(GetType(LampTemplateMetadata))>
<KnownType(GetType(LampProfile))>
<KnownType(GetType(LampDxfDocument))>
Public NotInheritable Class LampTemplate
    Inherits LampTemplateMetadata
    Public Const MaxImages As Integer = 3


#Region "Instance Variables"
    Private _baseDrawing As LampDxfDocument = New LampDxfDocument
    ''' <summary>
    ''' The actual template : contains just 1 of drawing
    ''' Is serialized last in the file 
    ''' </summary>
    <JsonProperty("template", Order:=1000, Required:=Required.Always)>
    <DataMember>
    Public Property BaseDrawing As LampDxfDocument
        Get
            Return _baseDrawing
        End Get
        Set(value As LampDxfDocument)
            If value Is Nothing Then
                Throw New ArgumentNullException(NameOf(value))
            End If
            If _baseDrawing IsNot Nothing Then
                RemoveHandler _baseDrawing.PropertyChanged, AddressOf BaseDrawing_PropertyChanged
            End If
            _baseDrawing = value
            If _baseDrawing IsNot Nothing Then
                AddHandler _baseDrawing.PropertyChanged, AddressOf BaseDrawing_PropertyChanged
            End If

            If Not BoundsLock Then
                UpdateBoundsFromDrawing()
            End If
            NotifyPropertyChanged()
        End Set
    End Property


    Private Sub UpdateBoundsFromDrawing()
        If BaseDrawing IsNot Nothing Then
            Me.Width = BaseDrawing.Width
            Me.Height = BaseDrawing.Height
        End If
    End Sub
    ''' <summary>
    ''' handler for base drawing mutating
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BaseDrawing_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
        If Not BoundsLock Then
            UpdateBoundsFromDrawing()
        End If

        NotifyPropertyChanged(NameOf(BaseDrawing))
    End Sub

    Private _tags As ObservableCollection(Of String)
    ''' <summary>
    ''' A list of tags. 
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("tags")>
    <DataMember>
    Public Property Tags As ObservableCollection(Of String)
        Get
            Return _tags
        End Get
        Private Set(value As ObservableCollection(Of String))
            If _tags IsNot Nothing Then
                RemoveHandler _tags.CollectionChanged, AddressOf Tags_CollectionChanged
            End If
            _tags = value
            If _tags IsNot Nothing Then
                AddHandler _tags.CollectionChanged, AddressOf Tags_CollectionChanged
            End If
            NotifyPropertyChanged()
        End Set
    End Property

    ''' <summary>
    ''' Handler for tags changing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    Private Sub Tags_CollectionChanged(sender As Object, args As NotifyCollectionChangedEventArgs)
        NotifyPropertyChanged(NameOf(Tags))
    End Sub

    Private _dynamicTextList As ObservableCollection(Of DynamicTextKey)
    ''' <summary>
    ''' Where the dynamic text will be stored:
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("dynamic_text_list")>
    <DataMember>
    Public Property DynamicTextList As ObservableCollection(Of DynamicTextKey)
        Get
            Return _dynamicTextList
        End Get
        Private Set(value As ObservableCollection(Of DynamicTextKey))
            If _dynamicTextList IsNot Nothing Then
                RemoveHandler _dynamicTextList.CollectionChanged, AddressOf DynamicTextList_PropertyChanged
            End If
            _dynamicTextList = value

            If _dynamicTextList IsNot Nothing Then
                AddHandler _dynamicTextList.CollectionChanged, AddressOf DynamicTextList_PropertyChanged
            End If
        End Set
    End Property

    ''' <summary>
    '''  see algorithm for in depth explaination
    ''' </summary>
    Public Sub SortTags()
        Dim copy As New List(Of String)
        copy.AddRange(Tags)
        copy.Sort()

        Tags.Clear()
        Tags.AddRange(copy)

    End Sub

    ''' <summary>
    ''' Handler for dynamic text changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DynamicTextList_PropertyChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        NotifyPropertyChanged(NameOf(DynamicTextList))
    End Sub

    ''' <summary>
    ''' Dummy member for WCF to serialize images
    ''' DONT USE
    ''' </summary>
    ''' <returns></returns>
    <DataMember>
    <JsonIgnore>
    Private Property _serializePreviewImages As IEnumerable(Of String)
        Get
            Return LampDxfDocument.ImageListToBase64(PreviewImages)
        End Get
        Set(value As IEnumerable(Of String))
            PreviewImages = LampDxfDocument.Base64ListToImage(value).ToObservableList
        End Set
    End Property

    Private _previewImage As ObservableCollection(Of Image)
    ''' <summary>
    ''' List of 3 images
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("preview_images")>
    <JsonConverter(GetType(ImageListJsonConverter))>
    Public Property PreviewImages As ObservableCollection(Of Image)
        Get
            Return _previewImage
        End Get
        Private Set(value As ObservableCollection(Of Image))
            If _previewImage IsNot Nothing Then
                RemoveHandler PreviewImages.CollectionChanged, AddressOf PreviewImages_CollectionChanged
            End If
            _previewImage = value
            If _previewImage IsNot Nothing Then
                AddHandler PreviewImages.CollectionChanged, AddressOf PreviewImages_CollectionChanged
            End If
            NotifyPropertyChanged()
        End Set
    End Property


    ''' <summary>
    ''' Handler for previewImages change
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    Private Sub PreviewImages_CollectionChanged(sender As Object, args As NotifyCollectionChangedEventArgs)
        NotifyPropertyChanged(NameOf(PreviewImages))
    End Sub
#End Region

    ''' <summary>
    ''' Load from a file on disk
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    Public Shared Function FromFile(fileName As String) As LampTemplate
        Using file As New StreamReader(fileName)
            Return Deserialize(file.ReadToEnd())
        End Using
    End Function

    Public Shared Async Function FromFileAsync(fileName As String) As Task(Of LampTemplate)
        Using file As New StreamReader(fileName)
            Return Deserialize(Await file.ReadToEndAsync())
        End Using
    End Function

    ''' <summary>
    ''' Loads from a json string
    ''' </summary>
    ''' <param name="json"></param>
    ''' <returns></returns>
    Private Shared Function Deserialize(json As String) As LampTemplate
        Return JsonConvert.DeserializeObject(Of LampTemplate)(json)
    End Function

    ''' <summary>
    ''' Gets whether or not it has text that is filled in by the user
    ''' during creation
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property HasDynamicText As Boolean
        Get
            Return DynamicTextList.Count() = 0
        End Get
    End Property

    ''' <summary>
    ''' Gets an empty lamptemplte
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property Empty As LampTemplate
        Get
            Return New LampTemplate(GetNewGuid()) 'Gets a New Default guid (0000-0000-0000...)
        End Get
    End Property



    ''' <summary>
    ''' Converts -> json format to be saved as a .spf
    ''' </summary>
    ''' <returns></returns>
    Public Function ToJson(Optional formatting As Formatting = Formatting.None) As String
        Return JsonConvert.SerializeObject(Me, formatting)
    End Function

    ''' <summary>
    ''' Saves to file on disk
    ''' </summary>
    ''' <param name="path"></param>
    ''' <param name="compress"></param>
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

        If Not BoundsLock Then
            UpdateBoundsFromDrawing()
        End If

        Using fileStream As New StreamWriter(path)
            fileStream.Write(ToJson(formatting))
        End Using
    End Sub

    ''' <summary>
    ''' Create a new LampTemplate with default Everything
    ''' </summary>
    Sub New()
        Me.New(New LampDxfDocument(), System.Guid.NewGuid.ToString)
    End Sub

    ''' <summary>
    ''' Creates a new <see cref="LampTemplate"></see> with default LampDxfDocument
    ''' </summary>
    ''' <param name="guid"></param>
    <JsonConstructor>
    Sub New(guid As String)
        Me.New(New LampDxfDocument, guid)
    End Sub

    ''' <summary>
    '''  Creates a new <see cref="LampTemplate"></see> with default guid
    '''  also sets the bounds
    ''' </summary>
    ''' <param name="dxf"></param>
    Sub New(dxf As LampDxfDocument)
        Me.New(dxf, System.Guid.NewGuid.ToString)

    End Sub

    ''' <summary>
    '''  Creates a new <see cref="LampTemplate"></see> 
    ''' </summary>
    ''' <param name="dxf"></param>
    ''' <param name="guid"></param>
    Sub New(dxf As LampDxfDocument, guid As String)
        Me.GUID = guid
        Me.BaseDrawing = dxf
        Me.Tags = New ObservableCollection(Of String)
        Me.DynamicTextList = New ObservableCollection(Of DynamicTextKey)

        PreviewImages = New ObservableCollection(Of Image)
        PreviewImages.ClearAsArray()

        If Not BoundsLock Then
            UpdateBoundsFromDrawing()
        End If

    End Sub


    Public Shared Sub SortByMaterial(listOfTemplate As List(Of LampTemplate))
        listOfTemplate.Sort(AddressOf CompareMaterial)
    End Sub

    Private Shared Function CompareMaterial(x As LampTemplate, y As LampTemplate) As Integer
        Return x.Material.CompareTo(y.Material)
    End Function

    Private Shared Function CompareDate(x As LampTemplate, y As LampTemplate) As Integer
        Return x.Material.CompareTo(y.Material)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("LampTemplate Guid:{0}", Me.GUID)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function

    Public Function GeneratePreviewImages() As Boolean
        If Me.Width <= 0 OrElse Me.Height <= 0 Then
            Return False
        End If

        Me.PreviewImages(0) = Me.BaseDrawing.ToImage()
        Return True
    End Function
End Class


<DataContract>
<KnownType(GetType(LampTemplate))>
<KnownType(GetType(LampStatus))>
Public Class LampTemplateWrapper
    <DataMember>
    Public Property Template As LampTemplate

    <DataMember>
    Public Property Status As LampStatus
End Class

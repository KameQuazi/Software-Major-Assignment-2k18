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
Public Class LampTemplateMetadata
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Friend Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Function ToLampTemplate() As LampTemplate
        Dim ret As New LampTemplate()
        ret.GUID = GUID
        ret.Name = Name
        ret.ShortDescription = ShortDescription
        ret.LongDescription = LongDescription
        ret.Material = Material
        ret.Length = Length
        ret.Height = Height
        ret.MaterialThickness = MaterialThickness
        ret.IsComplete = IsComplete
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


    Private _length As Double
    ''' <summary>
    ''' The length of all of the template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("length")>
    <DataMember()>
    Public Property Length As Double
        Get
            Return _length
        End Get
        Set(value As Double)
            _length = value
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


    ''' <summary>
    ''' name, email of approver if exists
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("approver_profile")>
    <DataMember>
    Public Property ApproverProfile As LampProfile = Nothing


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

        If Not data.GUID.Equals(GUID) Then
            Return False
        End If

        If Not data.ShortDescription.Equals(ShortDescription) Then
            Return False
        End If

        If Not data.LongDescription.Equals(LongDescription) Then
            Return False
        End If

        If Not data.Material.Equals(Material) Then
            Return False
        End If

        If Not data.Length.Equals(Length) Then
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

        Return True
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Me.GUID.GetHashCode()
    End Function
End Class


<JsonObject(MemberSerialization.OptIn)>
<DataContract()>
Public NotInheritable Class LampTemplate
    Inherits LampTemplateMetadata
    Public Const MaxImages As Integer = 3



#Region "Instance Variables"
    ''' <summary>
    ''' The completed drawing, w/ all the templates laid out appropriately
    ''' Not serialized, as it can be generated using _template when deserialized
    ''' </summary>
    Public Property CompletedDrawing As LampDxfDocument

    Private _baseDrawing As LampDxfDocument
    ''' <summary>
    ''' The actual template : contains just 1 of drawing
    ''' Is serialized last in the file 
    ''' </summary>
    <JsonProperty("template", Order:=1000)>
    <DataMember>
    Public Property BaseDrawing As LampDxfDocument
        Get
            Return _baseDrawing
        End Get
        Set(value As LampDxfDocument)
            _baseDrawing = value
            If _baseDrawing IsNot Nothing Then
                AddHandler _baseDrawing.PropertyChanged, (Sub(sender As Object, e As PropertyChangedEventArgs) NotifyPropertyChanged(NameOf(BaseDrawing)))
            End If
            NotifyPropertyChanged()
        End Set
    End Property

    ''' <summary>
    ''' A list of tags. 
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("tags")>
    <DataMember>
    Public Property Tags As ObservableCollection(Of String)


    Private Sub HandleTag_CollectionChanged(sender As Object, args As NotifyCollectionChangedEventArgs)
        NotifyPropertyChanged(NameOf(Tags))
    End Sub



    Private _dynamicTextList As New ObservableCollection(Of DynamicTemplateInput)
    ''' <summary>
    ''' Where the dynamic text will be stored:
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("dynamic_text_list")>
    <DataMember>
    Public Property DynamicTextList As ObservableCollection(Of DynamicTemplateInput)
        Get
            Return _dynamicTextList
        End Get
        Set(value As ObservableCollection(Of DynamicTemplateInput))
            _dynamicTextList = value
            If _dynamicTextList IsNot Nothing Then
                AddHandler _dynamicTextList.CollectionChanged, (Sub(sender As Object, e As NotifyCollectionChangedEventArgs) NotifyPropertyChanged("DynamicTextList"))
            End If
        End Set
    End Property


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
            _insertionLocations = value
            If _insertionLocations IsNot Nothing Then
                AddHandler _insertionLocations.CollectionChanged, (Sub(sender As Object, e As NotifyCollectionChangedEventArgs) NotifyPropertyChanged("InsertionLocations"))
            End If

            NotifyPropertyChanged()
        End Set
    End Property


    Private Sub PreviewImages_CollectionChanged(sender As Object, args As NotifyCollectionChangedEventArgs)
        NotifyPropertyChanged(NameOf(PreviewImages))
    End Sub

    <DataMember>
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
            _previewImage = value
            AddHandler PreviewImages.CollectionChanged, AddressOf PreviewImages_CollectionChanged
        End Set
    End Property




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
    Public Function Serialize(Optional formatting As Formatting = Formatting.None) As String
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

        Using fileStream As New StreamWriter(path)
            fileStream.Write(Serialize(formatting))
        End Using
    End Sub

    ''' <summary>
    ''' Helper constructor for LampTemplates
    ''' </summary>
    ''' <param name="dxf"></param>
    ''' <param name="guid"></param>
    Private Sub _new(dxf As LampDxfDocument, guid As String)



    End Sub
    ''' <summary>
    ''' Create a new LampTemplate with default Everything
    ''' </summary>
    Public Sub New()
        Me.New(New LampDxfDocument(), System.Guid.NewGuid.ToString)
    End Sub

    Public Sub New(guid As String)
        Me.New(New LampDxfDocument, guid)
    End Sub

    Public Sub New(dxf As LampDxfDocument)
        Me.New(dxf, System.Guid.NewGuid.ToString)
    End Sub

    Sub New(dxf As LampDxfDocument, guid As String)
        Me.GUID = guid
        Me.BaseDrawing = dxf
        Me.Tags = New ObservableCollection(Of String)

        Dim collection = New ObservableCollection(Of Image)
        collection.ClearAsArray()

        PreviewImages = collection


        Tags = New ObservableCollection(Of String)
        AddHandler Tags.CollectionChanged, AddressOf HandleTag_CollectionChanged
    End Sub





    ''' <summary>
    ''' Refreshes the _completeDrawing based on the InsertionLocations
    ''' Expensive, dont call too many times
    ''' </summary>
    Public Sub RefreshCompleteDrawing()
        ' TODO!
        CompletedDrawing = New LampDxfDocument()
        For Each point As LampDxfInsertLocation In InsertionLocations
            BaseDrawing.InsertInto(CompletedDrawing, point)
        Next
    End Sub

    Public Sub AddInsertionPoint(point As LampDxfInsertLocation, Optional refresh As Boolean = True)
        InsertionLocations.Add(point)

        If refresh Then
            RefreshCompleteDrawing()
        End If
    End Sub

    Public Sub SortByMaterial(listOfTemplate As List(Of LampTemplate))
        listOfTemplate.Sort(AddressOf CompareMaterial)
    End Sub

    Private Function CompareMaterial(x As LampTemplate, y As LampTemplate) As Integer
        Return x.Material.CompareTo(y.Material)
    End Function

    Private Function CompareDate(x As LampTemplate, y As LampTemplate) As Integer
        Return x.Material.CompareTo(y.Material)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("LampTemplate Guid:{0}", Me.GUID)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function
End Class


Public Class ImageListJsonConverter
    Inherits JsonConverter

    Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
        Dim ImageList = DirectCast(value, IList(Of Image))
        Dim encodedImages As New List(Of String)

        For Each image In ImageList
            encodedImages.Add(LampDxfDocument.ImageToBase64(image))
        Next
        writer.WriteStartArray()
        For Each item In encodedImages
            writer.WriteValue(item)
        Next
        writer.WriteEndArray()
    End Sub

    Public Overrides Function CanConvert(objectType As Type) As Boolean
        Return objectType = GetType(List(Of Image))
    End Function

    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
        Dim out As New ObservableCollection(Of Image)

        Dim token = JToken.Load(reader)
        If token.Type = JTokenType.Array Then
            For Each base64Image In token.ToArray()
                If base64Image.Type = JTokenType.String Then
                    out.Add(LampDxfDocument.Base64ToImage(base64Image.ToString))
                ElseIf base64Image.Type = JTokenType.Null Then
                    out.Add(Nothing)
                Else
                    Throw New JsonSerializationException()
                End If
            Next

        Else
            Throw New JsonSerializationException()
        End If
#If DEBUG Then
        If out.Count > LampTemplate.MaxImages Then
            Throw New JsonSerializationException("too many images!")
        End If
#Else
        While out.Count > LampTemplate.MaxImages
            out.RemoveAt(out.Count - 1)
        End While
#End If
        Return out
    End Function

End Class

<DataContract>
Public Class LampTemplateWrapper
    <DataMember>
    Public Property Template As LampTemplate

    <DataMember>
    Public Property Status As LampStatus
End Class
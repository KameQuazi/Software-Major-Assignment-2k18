Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports LAMP
Imports netDxf
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

<Serializable>
<JsonObject(MemberSerialization.OptIn)>
Public NotInheritable Class LampTemplate
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Const MaxImages As Integer = 3

#Region "Instance Variables"
    Private _guid As String
    ''' <summary>
    ''' a unique identifer for each different template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("guid")>
    Public Property GUID As String
        Get
            Return _guid
        End Get
        Set(value As String)
            _guid = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _name As String
    ''' <summary>
    ''' a unique identifer for each different template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("Name")>
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _shortDescription As String
    ''' <summary>
    ''' a unique identifer for each different template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("ShortDescription")>
    Public Property ShortDescription As String
        Get
            Return _shortDescription
        End Get
        Set(value As String)
            _shortDescription = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _longDescription As String
    ''' <summary>
    ''' a unique identifer for each different template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("LongDescription")>
    Public Property LongDescription As String
        Get
            Return _longDescription
        End Get
        Set(value As String)
            _longDescription = value
            NotifyPropertyChanged()
        End Set
    End Property

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

    Private _tags As ObservableCollection(Of String)
    ''' <summary>
    ''' A list of tags. 
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("tags")>
    Public Property Tags As ObservableCollection(Of String)
        Get
            Return _tags
        End Get
        Private Set(value As ObservableCollection(Of String))
            _tags = value
            AddHandler _tags.CollectionChanged, AddressOf HandleTag_CollectionChanged

            NotifyPropertyChanged()
        End Set
    End Property

    Private Sub HandleTag_CollectionChanged(sender As Object, args As NotifyCollectionChangedEventArgs)
        NotifyPropertyChanged(NameOf(Tags))
    End Sub

    Private _material As String = "Unspecified"
    ''' <summary>
    ''' material the trophy is made out of
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("material")>
    Public Property Material As String
        Get
            Return _material
        End Get
        Set(value As String)
            _material = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _height As Double
    ''' <summary>
    ''' The  height of all the template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("height")>
    Public Property Height As Double
        Get
            Return _height
        End Get
        Set(value As Double)
            _height = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _length As Double
    ''' <summary>
    ''' The length of all of the template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("length")>
    Public Property Length As Double
        Get
            Return _length
        End Get
        Set(value As Double)
            _length = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _materialThickness As Double
    ''' <summary>
    ''' The thickness of the material used
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("material_thickness")>
    Public Property MaterialThickness As Double
        Get
            Return _materialThickness
        End Get
        Set(value As Double)
            _materialThickness = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _submitDate As Date?
    ''' <summary>
    ''' The date item was submitted
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("submit_date")>
    Public Property SubmitDate As Date?
        Get
            Return _submitDate
        End Get
        Set(value As Date?)
            _submitDate = value
            NotifyPropertyChanged()
        End Set
    End Property

    Private _dynamicTextList As New ObservableCollection(Of DynamicTemplateInput)
    ''' <summary>
    ''' Where the dynamic text will be stored:
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("dynamic_text_list")>
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

    ''' <summary>
    ''' where or not the file is in a complete state - if complete, should disable editing
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("is_complete")>
    Public Property IsComplete As Boolean

    ''' <summary>
    ''' full name of creator
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("creator_name")>
    Public Property CreatorName As String = ""

    ''' <summary>
    ''' guid of creator
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("creator_id")>
    Public Property CreatorId As String = System.Guid.Empty.ToString

    ''' <summary>
    ''' full name of approver
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("approver_name")>
    Public Property ApproverName As String = ""

    ''' <summary>
    ''' guid of approver
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("approver_id")>
    Public Property ApproverId As String = Nothing

    Private Sub PreviewImages_CollectionChanged(sender As Object, args As NotifyCollectionChangedEventArgs)
        NotifyPropertyChanged(NameOf(PreviewImages))
    End Sub

    Private _previewImages As ObservableCollection(Of Image)

    ''' <summary>
    ''' List of 3 images
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("preview_images")>
    <JsonConverter(GetType(ImageListJsonConverter))>
    Public Property PreviewImages As ObservableCollection(Of Image)
        Get
            Return _previewImages
        End Get
        Private Set(value As ObservableCollection(Of Image))
            If value.Count < LampTemplate.MaxImages Then
                Throw New ArgumentOutOfRangeException(NameOf(value), value, String.Format("Collection must have at least {0} elements", MaxImages))
            End If

            _previewImages = value
            AddHandler _previewImages.CollectionChanged, AddressOf PreviewImages_CollectionChanged
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
            Return New LampTemplate With {.GUID = New Guid().ToString()} 'Gets a New Default guid (0000-0000-0000...)
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
    ''' <param name="formatting"></param>
#If DEBUG Then
    Public Sub Save(path As String, Optional formatting As Formatting = Formatting.Indented)
#Else
    Public Sub Save(path As String, Optional formatting As Formatting = Formatting.None)
#End If
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
        Me.GUID = guid
        Me.BaseDrawing = dxf
        Me.Tags = New ObservableCollection(Of String)

        Dim collection = New ObservableCollection(Of Image)
        collection.ClearAsArray()
        Me.PreviewImages = collection

    End Sub
    ''' <summary>
    ''' Create a new LampTemplate with default Everything
    ''' </summary>
    Public Sub New()
        _new(New LampDxfDocument(), System.Guid.NewGuid.ToString)

    End Sub

    Public Sub New(dxf As LampDxfDocument)
        _new(dxf, System.Guid.NewGuid.ToString)
    End Sub

    Public Sub New(dxf As LampDxfDocument, guid As String)
        _new(dxf, guid)
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

    ' TODO - ACtually compare all the elements of the template
    Public Shared Operator =(ByVal first As LampTemplate, ByVal second As LampTemplate) As Boolean
        Return first.GUID = second.GUID
    End Operator

    Public Shared Operator <>(ByVal first As LampTemplate, ByVal second As LampTemplate) As Boolean
        Return first.GUID <> second.GUID
    End Operator

    Public Overrides Function ToString() As String
        Return String.Format("LampTemplate Guid:{0}", Me.GUID.ToString())
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










Public Module OwO

    Public Sub Main()
        InitalizeLibraries()


        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New DesignerForm())
    End Sub

    Sub InitalizeLibraries()
        ' extract necessary dll files
        ' put folder in DLL path
    End Sub

    Public Function GetNewGuid() As String
        Return Guid.NewGuid().ToString()
    End Function


End Module

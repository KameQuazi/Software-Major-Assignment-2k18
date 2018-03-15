Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports LAMP
Imports netDxf
Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptIn)>
Public NotInheritable Class LampTemplate
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private Sub LampDxfChanged(sender As Object, e As PropertyChangedEventArgs)
        NotifyPropertyChanged("Template")
    End Sub

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

    Private _template As LampDxfDocument
    ''' <summary>
    ''' The actual template : contains just 1 of drawing
    ''' Is serialized last in the file 
    ''' </summary>
    <JsonProperty("template", Order:=1000)>
    Public Property Template As LampDxfDocument
        Get
            Return _template
        End Get
        Set(value As LampDxfDocument)
            _template = value
            AddHandler value.PropertyChanged, AddressOf LampDxfChanged
            NotifyPropertyChanged()
        End Set
    End Property

    Private _tags As New List(Of String)
    ''' <summary>
    ''' A list of tags. 
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("tags")>
    Public Property Tags As List(Of String)
        Get
            Return _tags
        End Get
        Set(value As List(Of String))
            _tags = value

            NotifyPropertyChanged()
        End Set
    End Property

    ''' <summary>
    ''' material the trophy is made out of
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("material")>
    Public Property Material As String = "Unspecified"

    ''' <summary>
    ''' The  height of all the template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("height")>
    Public Property Height As Double

    ''' <summary>
    ''' The length of all of the template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("length")>
    Public Property Length As Double

    ''' <summary>
    ''' The thickness of the material used
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("thickness")>
    Public Property MaterialThickness As Integer

    ''' <summary>
    ''' The date item was submitted
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("submitDate")>
    Public Property SubmitDate As Date = Nothing

    ''' <summary>
    ''' Where the dynamic text will be stored:
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("dynamicTextList")>
    Public Property DynamicTextList As New List(Of DynamicText)


    ''' <summary>
    ''' The completed drawing, w/ all the templates laid out appropriately
    ''' Not serialized, as it can be generated using _template when deserialized
    ''' </summary>
    Public Property CompletedDrawing As LampDxfDocument

    ''' <summary>
    ''' Where each individual trophy will be inserted (in cartesian form) on the competedDrawing
    ''' Contains rotation data, dynamic text data, everything required to rebuild the
    ''' completeddrawing
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("insertionLocations")>
    Public Property InsertionLocations As New List(Of LampDxfInsertLocation)

    ''' <summary>
    ''' where or not the file is in a complete state - if complete, should disable editing
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("isComplete")>
    Public Property IsComplete As Boolean

    ''' <summary>
    ''' full name of creator
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("creatorName")>
    Public Property CreatorName As String = ""

    ''' <summary>
    ''' guid of creator
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("creatorId")>
    Public Property CreatorId As String = System.Guid.Empty.ToString

    ''' <summary>
    ''' full name of approver
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("approverName")>
    Public Property ApproverName As String = ""

    ''' <summary>
    ''' guid of approver
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("approverId")>
    Public Property ApproverId As String = System.Guid.Empty.ToString

    ''' <summary>
    ''' Load from a file on disk
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    Friend Shared Function LoadFromFile(fileName As String) As LampTemplate
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
    Public Sub Save(path As String, Optional formatting As Formatting = Formatting.None)
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
        Me.template = dxf

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
            template.InsertInto(CompletedDrawing, point)
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














Public Class OwO
    Sub Main()
        InitalizeLibraries()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form5())
    End Sub

    Sub InitalizeLibraries()
        ' extract necessary dll files
        ' put folder in DLL path
    End Sub




End Class


Public Class LampDxfInsertLocation
    <JsonProperty("insertPoint")>
    Public Property InsertPoint As New Vector3
    <JsonProperty("rotation")>
    Public Property Rotation As Double
    <JsonProperty("dynamicTextData")>
    Public Property DynamicTextData As New Dictionary(Of DynamicText, String)
    Sub New(point As Vector3)
        Me.InsertPoint = point
    End Sub
End Class

Imports System.IO
Imports System.Reflection
Imports LAMP
Imports netDxf
Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptIn)>
Public NotInheritable Class LampTemplate
    ''' <summary>
    ''' a unique identifer 
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("guid")>
    Public Property GUID As String

    ''' <summary>
    ''' The actual template : contains just 1 of drawing
    ''' </summary>
    <JsonProperty("template", Order:=1000)>
    Public template As LampDxfDocument

    ''' <summary>
    ''' A list of tags
    ''' </summary>
    ''' <returns></returns>
    Public Property Tags As New List(Of String)

    ''' <summary>
    ''' material the trophy is made out of
    ''' </summary>
    ''' <returns></returns>
    Public Property Material As String = "Unspecified"

    Public Property Height As Integer
    Public Property Length As Integer
    Public Property MaterialThickness As Integer

    Public Property SubmitDate As Date = Nothing



    ''' <summary>
    ''' Where the dynamic text will be stored:
    '''
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

    <JsonProperty("creatorName")>
    Public Property CreatorName As String = ""

    <JsonProperty("creatorId")>
    Public Property CreatorId As Integer = -1


    <JsonProperty("approverName")>
    Public Property ApproverName As String = ""

    Friend Shared Function Load(fileName As String) As LampTemplate
        Using file As New StreamReader(fileName)
            Return Deserialize(file.ReadToEnd())
        End Using
    End Function

    Private Shared Function Deserialize(json As String) As LampTemplate
        Return JsonConvert.DeserializeObject(Of LampTemplate)(json)
    End Function

    <JsonProperty("approverId")>
    Public Property ApproverId As Integer = -1

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

    Public Sub Save(path As String, Optional formatting As Formatting = Formatting.None)
        Using fileStream As New StreamWriter(path)
            fileStream.Write(Serialize(formatting))
        End Using
    End Sub



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
        Application.Run(New Form1())
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

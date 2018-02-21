Imports System.Reflection
Imports Newtonsoft.Json

Public Class LampTemplate
    ''' <summary>
    ''' The completed drawing, w/ all the templates laid out appropriately
    ''' </summary>
    Private _completedDrawing As LampDxfDocument
    Public Property IsComplete As Boolean
    Public Property TemplateInsertLocations As New List(Of DxfLocations)


    ''' <summary>
    ''' The actual template : contains just 1 of drawing
    ''' </summary>
    Private _template As LampDxfDocument

    <JsonProperty("dynamicTextList")>
    Public Property DynamicTextList As New List(Of DynamicText)

    Public ReadOnly Property HasDynamicText As Boolean
        Get
            Return DynamicTextList.Count() = 0
        End Get
    End Property

    <JsonProperty("creatorName")>
    Public Property CreatorName As String

    <JsonProperty("creatorId")>
    Public Property CreatorId As Integer

    <JsonProperty("approverName")>
    Public Property ApproverName As String

    <JsonProperty("approverId")>
    Public Property ApproverId As Integer

    ''' <summary>
    ''' Converts -> json format to be saved as a .spiff
    ''' </summary>
    ''' <returns></returns>
    Public Function Serialize() As String
        Return JsonConvert.SerializeObject(Me)
    End Function

    Public Shared Function Serialize(item As LampTemplate) As String
        Return JsonConvert.SerializeObject(item)
    End Function

    Public Sub New(start As LampDxfDocument)
        Me._template = start
        RefreshCompleteDrawing()
    End Sub

    Public Sub RefreshCompleteDrawing()
        ' TODO!

    End Sub
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


Public Class DxfLocations

End Class
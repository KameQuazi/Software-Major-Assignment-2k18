Imports System.Runtime.Serialization
Imports Newtonsoft.Json



Public Class DynamicText
    <JsonProperty("text")>
    Public Property Text As String

    <JsonProperty("location")>
    Public Property Location As Point

    <JsonProperty("font")>
    Public Property Font As Font

    Public Sub New(text As String, location As Point)
        Me.Text = text
        Me.Location = location
    End Sub

    ''' <summary>
    ''' Converts from json to list(of DynamicText)
    ''' </summary>
    ''' <param name="json"></param>
    ''' <returns></returns>
    Public Shared Function Deserialise(json As String) As IList(Of DynamicText)
        Dim dynList As IList(Of DynamicText)


        dynList = JsonConvert.DeserializeObject(Of IEnumerable(Of DynamicText))(json).ToList()


        Return dynList
    End Function

    ''' <summary>
    ''' Converts from 
    ''' </summary>
    ''' <param name="textList"></param>
    ''' <returns></returns>
    Public Shared Function Serialise(textList As IList(Of DynamicText)) As String
        Dim ret As String
        ret = JsonConvert.SerializeObject(textList, Formatting.Indented)
        Return ret
    End Function


End Class


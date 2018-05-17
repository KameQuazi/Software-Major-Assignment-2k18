Imports System.Runtime.Serialization
Imports Newtonsoft.Json


''' <summary>
''' Stores where and how text that changes between each form <see cref="DynamicTemplateInput"/>
''' </summary>
Public Class DynamicTemplateInput
    ''' <summary>
    ''' name of the dynamic input: e.g. year, name, date etc
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("paramterName")>
    Public ReadOnly Property ParameterName As String

    ''' <summary>
    ''' The description of the dynamic input: e.g. 'year this student blah blah blah'
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("description")>
    Public ReadOnly Property Description As String

    ''' <summary>
    ''' The text to insert into the finished Template
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("text")>
    Public Property Text As String = ""

    <JsonProperty("location")>
    Public Property Location As Point

    <JsonProperty("font")>
    Public Property Font As Font

    <JsonProperty("inputType")>
    Public Property InputType As InputType = InputType.RichTextBox

    Private defaultFont As Font = SystemFonts.DefaultFont

    Public Sub New(parameterName As String, description As String, location As Point, Optional font As Font = Nothing)
        Me.ParameterName = parameterName
        Me.Description = description
        Me.Location = location
        If font IsNot Nothing Then
            Me.Font = defaultFont
        Else
            Me.Font = font
        End If
    End Sub

    ''' <summary>
    ''' Converts from json to <see cref="DynamicTemplateInput"/>
    ''' </summary>
    ''' <param name="json"></param>
    ''' <returns></returns>
    Public Shared Function Deserialise(json As String) As IList(Of DynamicTemplateInput)
        Dim dynList As IList(Of DynamicTemplateInput)

        dynList = JsonConvert.DeserializeObject(Of IEnumerable(Of DynamicTemplateInput))(json).ToList()
        Return dynList
    End Function

    ''' <summary>
    ''' Converts from 
    ''' </summary>
    ''' <param name="textList"></param>
    ''' <returns></returns>
    Public Shared Function Serialise(textList As IList(Of DynamicTemplateInput)) As String
        Dim ret As String
        ret = JsonConvert.SerializeObject(textList, Formatting.Indented)
        Return ret
    End Function


End Class


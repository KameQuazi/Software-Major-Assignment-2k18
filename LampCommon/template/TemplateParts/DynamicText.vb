Imports System.Drawing
Imports System.Runtime.Serialization
Imports Newtonsoft.Json


''' <summary>
''' Stores where and how text that changes between each form <see cref="DynamicTemplateInput"/>
''' </summary>
<DataContract>
Public Class DynamicTemplateInput
    ''' <summary>
    ''' name of the dynamic input: e.g. year, name, date etc
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("paramterName")>
    <DataMember>
    Public ReadOnly Property ParameterName As String

    ''' <summary>
    ''' The description of the dynamic input: e.g. 'year this student blah blah blah'
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("description")>
    <DataMember>
    Public ReadOnly Property Description As String

    ''' <summary>
    ''' The text to insert into the finished Template
    ''' Value will be:
    ''' String, for richtextbox
    ''' boolean, for checkbox
    ''' Nothing, for nothing
    ''' Image, for PictureBox
    ''' IList(Of text), for ListView
    ''' String, for combobox
    ''' NOTE - not all are actually implemented ;-;
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("value")>
    <DataMember>
    Public Property Value As Object

    <JsonProperty("location")>
    <DataMember>
    Public Property Location As Point

    <JsonProperty("font")>
    <DataMember>
    Public Property Font As Font

    ''' <summary>
    ''' The type of input. <see cref="Value"/> to see what data type each one will return
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("inputType")>
    <DataMember>
    Public Property InputType As InputType

    Private Shared defaultFont As Font = SystemFonts.DefaultFont

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="parameterName">Name of parameter</param>
    ''' <param name="description">description of parameter</param>
    ''' <param name="location">where it should be inserted, rel bottom left of the template</param>
    ''' <param name="font">font to use (for text)</param>
    Public Sub New(parameterName As String, description As String, location As Point, Optional inputType As InputType = InputType.RichTextBox, Optional font As Font = Nothing)
        Me.ParameterName = parameterName
        Me.Description = description
        Me.Location = location
        Me.InputType = inputType
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

<DataContract>
Public Enum InputType
    RichTextBox
    CheckBox
    ' PictureBox
    ' Combobox
    ' ListView
    None
End Enum
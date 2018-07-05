Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization
Imports Newtonsoft.Json


''' <summary>
''' Stores where and how text that changes between each form <see cref="DynamicTextKey"/>
''' </summary>
<JsonObject(MemberSerialization.OptIn)>
<DataContract>
Public Structure DynamicTextKey

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
    ''' Where to insert the item
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("location")>
    <DataMember>
    Public ReadOnly Property Location As Point

    ''' <summary>
    ''' The normal font to use
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("font")>
    <DataMember>
    Public ReadOnly Property Font As Font

    ''' <summary>
    ''' if the user can override font
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("can_override_font")>
    <DataMember>
    Public ReadOnly Property CanOverrideFont As Boolean

    ''' <summary>
    ''' The type of input. 
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
    ''' Converts from json to <see cref="DynamicTextKey"/>
    ''' </summary>
    ''' <param name="json"></param>
    ''' <returns></returns>
    Public Shared Function Deserialise(json As String) As IList(Of DynamicTextKey)
        Dim dynList As IList(Of DynamicTextKey)

        dynList = JsonConvert.DeserializeObject(Of IEnumerable(Of DynamicTextKey))(json).ToList()
        Return dynList
    End Function

    ''' <summary>
    ''' Converts from 
    ''' </summary>
    ''' <param name="textList"></param>
    ''' <returns></returns>
    Public Shared Function Serialise(textList As IList(Of DynamicTextKey)) As String
        Dim ret As String
        ret = JsonConvert.SerializeObject(textList, Formatting.Indented)
        Return ret
    End Function
End Structure

<DataContract>
Public Enum InputType
    RichTextBox
    CheckBox
    ' PictureBox
    ' Combobox
    ' ListView
    None
End Enum


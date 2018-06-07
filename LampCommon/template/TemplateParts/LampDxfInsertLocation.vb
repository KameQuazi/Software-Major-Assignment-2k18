Imports System.Runtime.Serialization
Imports netDxf
Imports Newtonsoft.Json

<DataContract>
Public Class LampDxfInsertLocation
    ''' <summary>
    ''' Where the text should be inserted
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("insertPoint")>
    <DataMember>
    Public Property InsertPoint As New Vector3


    <JsonProperty("rotation")>
    <DataMember>
    Public Property Rotation As Double

    <JsonProperty("dynamicTextData")>
    <DataMember>
    Public Property DynamicTextData As New Dictionary(Of DynamicTemplateInput, String)

    Sub New(point As Vector3)
        Me.InsertPoint = point
    End Sub
End Class

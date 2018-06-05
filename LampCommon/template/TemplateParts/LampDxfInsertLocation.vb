Imports netDxf
Imports Newtonsoft.Json

Public Class LampDxfInsertLocation
    ''' <summary>
    ''' Where the text should be inserted
    ''' </summary>
    ''' <returns></returns>
    <JsonProperty("insertPoint")>
    Public Property InsertPoint As New Vector3


    <JsonProperty("rotation")>
    Public Property Rotation As Double
    <JsonProperty("dynamicTextData")>
    Public Property DynamicTextData As New Dictionary(Of DynamicTemplateInput, String)
    Sub New(point As Vector3)
        Me.InsertPoint = point
    End Sub
End Class

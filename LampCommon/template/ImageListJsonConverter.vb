Imports System.Collections.ObjectModel
Imports System.Drawing
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

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
Imports System.ComponentModel
Imports LampCommon

Public Class MultiDrawingViewer
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Drawings As List(Of LampDxfDocument)
        Get

        End Get
        Set(value As List(Of LampDxfDocument))

        End Set
    End Property
End Class
Imports System.ComponentModel
Imports LampCommon

Public Class MultiDrawingViewer
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Drawings As List(Of LampDxfDocument)
        Get
            Return MultiDrawingViewerControl1.Drawings
        End Get
        Set(value As List(Of LampDxfDocument))
            MultiDrawingViewerControl1.Drawings = value
        End Set
    End Property
End Class
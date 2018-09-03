Imports System.ComponentModel
Imports LampCommon

Public Class MultiDrawingViewerControl

    Private _drawings As New List(Of LampDxfDocument)
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Drawings As IList(Of LampDxfDocument)
        Get
            Return _drawings
        End Get
        Set(value As IList(Of LampDxfDocument))
            _drawings = value
            UpdateContents()
        End Set
    End Property

    Private index As Integer = 0

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UpdateButtons()
    End Sub

    Private Sub UpdateButtons()
        If index + 1 > Drawings.Count - 1 Then
            ' cannot go right anymore
            btnNext.Enabled = False
        Else
            btnNext.Enabled = True
        End If
        If index - 1 < 0 Then
            btnPrevious.Enabled = False
        Else
            btnPrevious.Enabled = True
        End If
    End Sub

    Private Sub UpdateContents()
        If Drawings.Count = 0 Then
            lblPage.Text = "No pages loaded"
        Else
            lblPage.Text = String.Format("Page: {0}/{1}", index + 1, Drawings.Count)
            DxfViewerControl1.Drawing = Drawings(index)

        End If

        UpdateButtons()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        index += 1
        UpdateContents()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        index -= 1
        UpdateContents()
    End Sub
End Class

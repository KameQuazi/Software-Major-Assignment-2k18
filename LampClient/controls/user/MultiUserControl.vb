Imports System.ComponentModel
Imports LampCommon

Public Class MultiUserControl
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Users As New List(Of LampUser)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub UpdateContents()

    End Sub

    Private Sub HandleButtonClicked(sender As Object, args As EventArgs)
        Dim button As Button = sender
        Dim user As LampUser = button.Tag

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class

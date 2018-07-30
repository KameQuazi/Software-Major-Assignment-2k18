Imports System.ComponentModel
Imports LampCommon

Public Class MultiUserViewer
    '<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    ' Public Property Users As New List(Of LampUser)
    Public Event UserClick(sender As Object, args As UserClickEventArgs)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'DataGridView1.ColumnCount = 3
        'DataGridView1.Columns(0).Name = "Product ID"
        'DataGridView1.Columns(1).Name = "Product Name"
        'DataGridView1.Columns(2).Name = "Product Price"
        'Dim row As String() = New String() {"1", "Product 1", "1000"}
        'DataGridView1.Rows.Add(row)
        'row = New String() {"2", "Product 2", "2000"}
        'DataGridView1.Rows.Add(row)
        'row = New String() {"3", "Product 3", "3000"}
        'DataGridView1.Rows.Add(row)
        'row = New String() {"4", "Product 4", "4000"}
        'DataGridView1.Rows.Add(row)
        LampUserBindingSource.Add(New LampUser("", UserPermission.Admin, "asdf", "asdasdf", "asdf", "asdasdas"))
    End Sub

    Public Sub UpdateContents()

    End Sub

    Private Sub HandleButtonClicked(sender As Object, args As EventArgs)
        Dim button As Button = sender
        Dim user As LampUser = button.Tag

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim senderGrid As DataGridView = sender
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            Dim selectedUser As LampUser = LampUserBindingSource(e.RowIndex)
            Using dialog As New EditUserForm
                dialog.User = selectedUser
                dialog.ShowDialog(Me)
            End Using
        End If
    End Sub
End Class

Public Class UserClickEventArgs
    Inherits EventArgs
    Public Property User As LampUser
    Sub New(user As LampUser)
        MyBase.New()
        Me.User = user
    End Sub
End Class
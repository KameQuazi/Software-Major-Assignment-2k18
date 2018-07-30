Imports System.ComponentModel
Imports LampCommon

Public Class MultiUserViewer
    '<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    ' Public Property Users As New List(Of LampUser)
    Public Event UserClick(sender As Object, args As UserClickEventArgs)

    Public ReadOnly Property Users As IList
        Get
            Return LampUserBindingSource
        End Get
    End Property


    ' enable double buffering
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get

            Dim baseParams = MyBase.CreateParams
            baseParams.ExStyle = baseParams.ExStyle Or &H2000000 ' magic number that enables double buffering
            Return baseParams
        End Get
    End Property



    Private _suspend As Boolean = False

    Public Sub Suspend()
        _suspend = True
    End Sub

    Public Sub EndSuspend(Optional doUpdate As Boolean = True)
        _suspend = False
        If doUpdate Then
            UpdateContents()
        End If
    End Sub


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
        ' LampUserBindingSource.Add(New LampUser("", UserPermission.Admin, "asdf", "asdasdf", "asdf", "asdasdas"))
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
            RaiseEvent UserClick(Me, New UserClickEventArgs(selectedUser))
        End If
    End Sub

    Public Sub ShowLoading()
        TableLayoutPanel2.Visible = True
        LoadingPictureBox.Visible = True
    End Sub

    Public Sub StopLoading()
        TableLayoutPanel2.Visible = False
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
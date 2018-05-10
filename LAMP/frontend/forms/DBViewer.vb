Imports System.Data.SQLite
Imports LAMP
Public Class DBViewer
    Dim DB As New TemplateDatabase
    Sub New(database As TemplateDatabase)

        ' This call is required by the designer.
        InitializeComponent()
        DB = database
        DBGrid.Refresh()
        Dim ds As New DataTable()
        Dim sqlite_conn = DB.GetConnection
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_conn.Open()
        sqlite_cmd.CommandText = "Select * FROM template"
        Dim adapter = New SQLiteDataAdapter("Select * FROM template", sqlite_conn)
        adapter.Fill(ds)
        DBGrid.DataSource = ds
        sqlite_conn.Close()
        DBGrid.Refresh()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DBViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
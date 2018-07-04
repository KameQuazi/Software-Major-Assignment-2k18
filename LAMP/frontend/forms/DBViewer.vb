Imports System.Data.SQLite
Imports LAMP
Public Class DBViewer
    Dim DB As New TemplateDatabase
    Dim ds As New DataSet()
    Dim sqlite_conn As New SQLiteConnection
    Dim sqlite_cmd As New SQLiteCommand
    Dim cmdbl As SQLiteCommandBuilder
    Dim adapter As New SQLiteDataAdapter

    Sub New(database As TemplateDatabase)


        ' This call is required by the designer.
        InitializeComponent()

        ' TODO - Use db.OpenDatabase() and db.CloseDatabase(), since closing/opening a db twice causes it to crash
        ' 
        ' Using sqlite_cmd = db.GetCommand() '[ which basically does sqlite_conn.CreateCommand() ]' 
        ' End Using
        DBGrid.Refresh()
        DB = database
        sqlite_conn = database.Connection
        sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_conn.Open()
        sqlite_cmd.CommandText = "Select * FROM template"
        adapter = New SQLiteDataAdapter("Select * FROM template", sqlite_conn)
        adapter.Fill(ds, "template")
        DBGrid.DataSource = ds.Tables(0)
        sqlite_conn.Close()
        DBGrid.Refresh()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DBViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles DBGrid.UserDeletingRow        For Each item As DataGridViewRow In DBGrid.SelectedRows
            Try
                DB.removeEntry(item.Cells("GUID").Value.ToString)
            Catch

            End Try


        Next
        sqlite_conn.Open()
        sqlite_conn.Close()
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click

    End Sub
End Class
Imports System.Data.SQLite
Imports LAMP
Public Class TemplateDB
    Public Property Name As String
    Private _connectionString As String

    Public Sub CreateTable()
        Me.Name = Name
        Dim sqlite_conn = New SQLiteConnection(_connectionString)
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_cmd.CommandText = "CREATE TABLE if not exists test (
                                  Auto_ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                                  DXF Text Not NULL DEFAULT '',
                                  Tag Text DEFAULT '',
                                  material Text Not NULL,
                                  length Int Not NULL,
                                  Height Int Not NULL,
                                  thickness Int Not NULL,
                                  creatorName Text Not NULL DEFAULT '',
                                  creator_ID Int Not NULL DEFAULT -1,
                                  approverName Text DEFAULT '',
                                  approver_ID Int Default -1,
                                  complete Int DEFAULT FALSE);"
        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub

    Public Sub New(Optional name As String = "templateDB.sqlite")
        Me.Name = name
        Me._connectionString = String.Format("Data Source={0};Version=3;", name)
        ' recreate the database if not found
        If Not IO.File.Exists(name) Then
            CreateTable()
        End If
    End Sub

    ''' <summary>
    ''' Removes from database based on ID
    ''' </summary>
    ''' <param name="id"></param>
    Sub removeEntry(id As Integer)
        Dim sqlite_conn = New SQLiteConnection(_connectionString)
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_cmd.CommandText = "DELETE from test WHERE AUTO_ID = ?"
        sqlite_cmd.Parameters.Add(id)
        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub

    ''' <summary>
    ''' DXF, Tag, Material, Length, Height, Thickness, Creator Name, Creator ID
    ''' </summary>
    ''' <param name="DXF"></param>
    ''' <param name="tag"></param>
    ''' <param name="material"></param>
    ''' <param name="length"></param>
    ''' <param name="height"></param>
    ''' <param name="thickness"></param>
    ''' <param name="creatorName"></param>
    ''' <param name="creator_ID"></param>
    Sub addDebugEntry(DXF As String, tag As String, material As String, length As Integer, height As Integer, thickness As Integer, creatorName As String, creator_ID As Integer)
        Dim sqlite_conn = New SQLiteConnection(String.Format("Data Source={0};Version=3;", Me.Name))
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()

        sqlite_cmd.CommandText = "INSERT INTO test(DXF,Tag,material,length,Height,thickness,creatorName,creator_ID) VALUES (?,?,?,?,?,?,?,?);"

        sqlite_cmd.Parameters.Add(DXF)
        sqlite_cmd.Parameters.Add(tag)
        sqlite_cmd.Parameters.Add(material)
        sqlite_cmd.Parameters.Add(length)
        sqlite_cmd.Parameters.Add(height)
        sqlite_cmd.Parameters.Add(thickness)
        sqlite_cmd.Parameters.Add(creatorName)
        sqlite_cmd.Parameters.Add(creator_ID)

        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub

    Sub addEntry(lamp As LampTemplate)
        Dim sqlite_conn = New SQLiteConnection(String.Format("Data Source={0};Version=3;", Me.Name))
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_cmd.CommandText = "INSERT INTO test(DXF,Tag,material,length,Height,thickness,creatorName,creator_ID) VALUES (?, ?, ?, ?, ?, ?, ?, ?);"
        sqlite_cmd.Parameters.Add(lamp.template.ToDxfString)
        sqlite_cmd.Parameters.Add(lamp.Tags)
        sqlite_cmd.Parameters.Add(lamp.Material)
        sqlite_cmd.Parameters.Add(lamp.Length)
        sqlite_cmd.Parameters.Add(lamp.Height)
        sqlite_cmd.Parameters.Add(lamp.MaterialThickness)
        sqlite_cmd.Parameters.Add(lamp.CreatorName)
        sqlite_cmd.Parameters.Add(lamp.CreatorId)

        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub

    Function selectEntry(id As Integer) As LampTemplate
        Dim sqlite_conn = New SQLiteConnection(String.Format("Data Source={0};Version=3;", Me.Name))
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        Dim sqlite_reader As SQLiteDataReader

        sqlite_cmd.CommandText = String.Format("Select * FROM test WHERE Auto_ID = {0}", id)
        sqlite_reader = sqlite_cmd.ExecuteReader()
        While sqlite_reader.Read()
            'Debug.Write(sqlite_reader.GetInt32(0) & " " & sqlite_reader.GetString(1) & " " & sqlite_reader.GetString(2) & " " & sqlite_reader.GetString(3)& " " & sqlite_reader.GetInt32(4)& " " & sqlite_reader.GetInt32(5) & " "& sqlite_reader.GetInt32(6)& " " & sqlite_reader.GetString(7) & " "& sqlite_reader.GetInt32(8) & " "& sqlite_reader.GetString(9) & " "& sqlite_reader.GetInt32(10))
            Dim LampDXF = LampDxfDocument.LoadFromString(sqlite_reader.GetString(DatabaseColumn.Dxf))
            Dim LampTemp = New LampTemplate(LampDXF)
            LampTemp.ApproverId = sqlite_reader.GetInt32(DatabaseColumn.ApproverId)
            LampTemp.ApproverName = sqlite_reader.GetString(DatabaseColumn.ApproverName)
            LampTemp.CreatorId = sqlite_reader.GetInt32(DatabaseColumn.CreatorId)
            LampTemp.CreatorName = sqlite_reader.GetString(DatabaseColumn.CreatorName)
            LampTemp.IsComplete = sqlite_reader.GetInt32(DatabaseColumn.IsComplete)
            Return LampTemp

        End While
        Return Nothing
    End Function


    Public Enum DatabaseColumn
        Dxf = 1

        CreatorName = 7
        CreatorId = 8
        ApproverName = 9
        ApproverId = 10
        IsComplete = 11
    End Enum
End Class

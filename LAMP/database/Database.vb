Imports System.Data.SQLite
Imports LAMP

Public Class TemplateDatabase
    Public Property Name As String
    Private _connection As SQLiteConnection

    ''' <summary>
    ''' Makes a connection for use by other code
    ''' </summary>
    ''' <returns></returns>
    Public Function GetConnection() As SQLiteConnection
        Return _connection
    End Function

    ''' <summary>
    ''' Creates all the tables required, if tables not exist
    ''' </summary>
    Public Sub CreateTable()
        Me.Name = Name
        Dim sqlite_conn = _connection
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_cmd.CommandText = "CREATE TABLE if not exists template (
                                  GUID Text PRIMARY KEY Not NULL, 
                                  DXF Text Not NULL,
                                  Tag Text Not NULL,
                                  material Text Not NULL,
                                  length Int Not NULL,
                                  Height Int Not NULL,
                                  thickness Int Not NULL,
                                  creatorName Text Not NULL DEFAULT '',
                                  creator_ID Int Not NULL DEFAULT -1,
                                  approverName Text DEFAULT '',
                                  approver_ID Int Default -1,
                                  submit_date STRING,
                                  complete Int DEFAULT FALSE);"
        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub

    Public Sub New(Optional name As String = "templateDB.sqlite")
        Me.Name = name
        _connection = New SQLiteConnection(String.Format("Data Source={0};Version=3;", name))
        ' create tables 
        CreateTable()
    End Sub

    ''' <summary>
    ''' Removes from database based on ID
    ''' </summary>
    ''' <param name="guid"></param>
    Sub removeEntry(guid As String)
        Dim sqlite_conn = _connection
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_cmd.CommandText = "DELETE from template WHERE GUID = ?"
        sqlite_cmd.Parameters.Add(guid)
        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()

    End Sub

    ''' <summary>
    ''' DXF, Tag, Material, Length, Height, Thickness, Creator Name, Creator ID
    ''' </summary>
    ''' <param name="GUID"></param>
    ''' <param name="DXF"></param>
    ''' <param name="tag"></param>
    ''' <param name="material"></param>
    ''' <param name="length"></param>
    ''' <param name="height"></param>
    ''' <param name="materialthickness"></param>
    ''' <param name="creatorName"></param>
    ''' <param name="creator_ID"></param>
    Sub addDebugEntry(GUID As String, DXF As String, tag As String, material As String, length As Integer, height As Integer, materialthickness As Integer, creatorName As String, creator_ID As Integer)
        Dim sqlite_conn = _connection
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()

        sqlite_cmd.CommandText = "INSERT INTO template(Guid,DXF,Tag,material,length,Height,thickness,creatorName,creator_ID,submit_date) VALUES (?,?,?,?,?,?,?,?,?,DATETIME('now'));"

        sqlite_cmd.Parameters.Add(sqlParam(DbType.String, GUID))
        sqlite_cmd.Parameters.Add(sqlParam(DbType.String, DXF))
        sqlite_cmd.Parameters.Add(sqlParam(DbType.String, tag))
        sqlite_cmd.Parameters.Add(sqlParam(DbType.String, material))
        sqlite_cmd.Parameters.Add(sqlParam(DbType.Int32, length))
        sqlite_cmd.Parameters.Add(sqlParam(DbType.Int32, height))
        sqlite_cmd.Parameters.Add(sqlParam(DbType.Int32, materialthickness))
        sqlite_cmd.Parameters.Add(sqlParam(DbType.String, creatorName))
        sqlite_cmd.Parameters.Add(sqlParam(DbType.String, creator_ID))

        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub

    Function sqlParam(type As DbType, data As Object) As SQLiteParameter
        Dim foo As New SQLiteParameter(type)
        foo.Value = data
        Return foo
    End Function

    Private Function SerializeTags(template As LampTemplate) As String
        Return String.Join(",", template.Tags)
    End Function

    Private Function DeserializeTags(tags As String) As List(Of String)
        Return tags.Split(","c).ToList()
    End Function

    Sub addEntry(lamp As LampTemplate)
        Dim sqlite_conn = _connection
        sqlite_conn.Open()

        Dim sqlite_cmd = sqlite_conn.CreateCommand()

        sqlite_cmd.CommandText = "INSERT INTO template
                (Guid, DXF, Tag, material, length, Height, thickness, creatorName, creator_ID, submit_date) 
                VALUES 
                (@guid, @dxf, @tags, @material, @length, @height, @thickness, @creatorName, @creatorId, DATETIME('now'));"

        sqlite_cmd.Parameters.AddWithValue("@guid", lamp.GUID)
        sqlite_cmd.Parameters.AddWithValue("@dxf", lamp.Template.ToDxfString)
        sqlite_cmd.Parameters.AddWithValue("@tags", SerializeTags(lamp))
        sqlite_cmd.Parameters.AddWithValue("@material", lamp.Material)
        sqlite_cmd.Parameters.AddWithValue("@length", lamp.Length)
        sqlite_cmd.Parameters.AddWithValue("@height", lamp.Height)
        sqlite_cmd.Parameters.AddWithValue("@thickness", lamp.MaterialThickness)
        sqlite_cmd.Parameters.AddWithValue("@creatorName", lamp.CreatorName)
        sqlite_cmd.Parameters.AddWithValue("@creatorId", lamp.CreatorId)
        ' Ensure creatorId and and approverId are strings!
        ' also add approverid/approvername to the db


        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub

    Function selectEntry(guid As String) As LampTemplate
        Dim sqlite_conn = _connection
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        Dim sqlite_reader As SQLiteDataReader

        sqlite_cmd.CommandText = "Select * FROM template WHERE guid = ?"
        sqlite_cmd.Parameters.Add(sqlParam(DbType.String, guid))

        sqlite_reader = sqlite_cmd.ExecuteReader()
        While sqlite_reader.Read()
            'Debug.Write(sqlite_reader.GetInt32(0) & " " & sqlite_reader.GetString(1) & " " & sqlite_reader.GetString(2) & " " & sqlite_reader.GetString(3)& " " & sqlite_reader.GetInt32(4)& " " & sqlite_reader.GetInt32(5) & " "& sqlite_reader.GetInt32(6)& " " & sqlite_reader.GetString(7) & " "& sqlite_reader.GetInt32(8) & " "& sqlite_reader.GetString(9) & " "& sqlite_reader.GetInt32(10))
            Dim LampDXF = LampDxfDocument.LoadFromString(sqlite_reader.GetString(DatabaseColumn.Dxf))
            Dim LampTemp = New LampTemplate(LampDXF)

            LampTemp.GUID = sqlite_reader.GetString(DatabaseColumn.Guid)
            LampTemp.Tags = DeserializeTags(sqlite_reader.GetString(DatabaseColumn.Tags))

            LampTemp.Material = sqlite_reader.GetString(DatabaseColumn.Material)
            LampTemp.Length = sqlite_reader.GetDouble(DatabaseColumn.Length)
            LampTemp.Height = sqlite_reader.GetDouble(DatabaseColumn.Height)

            LampTemp.ApproverId = sqlite_reader.GetInt32(DatabaseColumn.ApproverId)
            LampTemp.ApproverName = sqlite_reader.GetString(DatabaseColumn.ApproverName)
            LampTemp.CreatorId = sqlite_reader.GetInt32(DatabaseColumn.CreatorId)
            LampTemp.CreatorName = sqlite_reader.GetString(DatabaseColumn.CreatorName)
            LampTemp.IsComplete = sqlite_reader.GetBoolean(DatabaseColumn.IsComplete)
            sqlite_conn.Close()
            Return LampTemp

        End While
        sqlite_conn.Close()
        Return Nothing
    End Function


    Public Enum DatabaseColumn
        Guid = 0
        Dxf = 1
        Tags = 2
        Material = 3
        Length = 4
        Height = 5
        Thickness = 6
        CreatorName = 7
        CreatorId = 8
        ApproverName = 9
        ApproverId = 10
        IsComplete = 11
    End Enum
End Class

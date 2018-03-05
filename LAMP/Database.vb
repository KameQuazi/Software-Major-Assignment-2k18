Imports System.Data.SQLite
Imports LAMP
Public Class TemplateDB
    Public name As String
    Public Sub createTable()
        Me.name = name
        Dim sqlite_conn = New SQLiteConnection(String.Format("Data Source={0};Version=3;", Me.name))
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_cmd.CommandText = "CREATE TABLE if not exists test (
                                  Auto_ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                                  DXF Text Not NULL,
                                  Tag Text DEFAULT 'None',
                                  material Text Not NULL,
                                  length Int Not NULL,
                                  Height Int Not NULL,
                                  thickness Int Not NULL,
                                  creatorName Text Not NULL,
                                  creator_ID Int Not NULL,
                                  approverName Text DEFAULT 'NONE',
                                  approver_ID Int Default 0,
                                  complete Int DEFAULT 0);"
        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub


    Public Sub New(Optional start As String = "templateDB.sqlite")
        Me.name = start
        createTable()
    End Sub

    ''' <summary>
    ''' Removes from database based on ID
    ''' </summary>
    ''' <param name="id"></param>
    Sub removeEntry(id As Integer)
        Dim sqlite_conn = New SQLiteConnection(String.Format("Data Source={0};Version=3;", Me.name))
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_cmd.CommandText = String.Format("DELETE from test WHERE AUTO_ID = {0}", id)
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

        Dim sqlite_conn = New SQLiteConnection(String.Format("Data Source={0};Version=3;", Me.name))
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_cmd.CommandText = String.Format("INSERT INTO test(DXF,Tag,material,length,Height,thickness,creatorName,creator_ID) VALUES ('{0}','{1}','{2}',{3},{4},{5},'{6}',{7});", DXF, tag, material, length, height, thickness, creatorName, creator_ID)

        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub
    Sub addEntry(lamp As LampTemplate)
        Dim sqlite_conn = New SQLiteConnection(String.Format("Data Source={0};Version=3;", Me.name))
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_cmd.CommandText = String.Format("INSERT INTO test(DXF,Tag,material,length,Height,thickness,creatorName,creator_ID) VALUES ('{0}','{1}','{2}',{3},{4},{5},'{6}',{7});", lamp.template.ToDxfString, lamp.tags, lamp._material, lamp._length, lamp._height, lamp._thickness, lamp.CreatorName, lamp.CreatorId)

        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub
    Function selectEntry(id As Integer) As LampTemplate
        Dim sqlite_conn = New SQLiteConnection(String.Format("Data Source={0};Version=3;", Me.name))
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
            LampTemp.ApproverName = sqlite_reader.GetString(9)
            LampTemp.CreatorId = sqlite_reader.GetInt32(8)
            LampTemp.CreatorName = sqlite_reader.GetString(7)
            LampTemp.IsComplete = sqlite_reader.GetInt32(11)
            Return LampTemp

        End While
        Return Nothing
    End Function


    Public Enum DatabaseColumn
        Dxf = 1
        ApproverId = 10
    End Enum
End Class

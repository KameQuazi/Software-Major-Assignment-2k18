Imports System.Data.SQLite
Imports System.IO
Imports LAMP.DatabaseHelper
Imports LAMP

Public Class TemplateDatabase
    Public Property Path As String
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
    Public Sub CreateTables()
        _connection.Open()
        Dim sqlite_cmd = _connection.CreateCommand()
        sqlite_cmd.CommandText = "CREATE TABLE if not exists template (
                                  GUID Text PRIMARY KEY Not NULL, 
                                  DXF Text Not NULL,
                                  Tag Text DEFAULT '',
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

        sqlite_cmd.CommandText = "CREATE TABLE if not exists images (
                                  GUID Text PRIMARY KEY Not NULL, 
                                  image1 blob Not NULL,
                                  image2 blob,
                                  image3 blob
                                  );"
        sqlite_cmd.ExecuteNonQuery()

        _connection.Close()
    End Sub

    Friend Sub DeleteTables()
        _connection.Open()
        Dim sqlite_cmd = _connection.CreateCommand()
        sqlite_cmd.CommandText = "DROP TABLE If exists template"
        sqlite_cmd.ExecuteNonQuery()
        sqlite_cmd.CommandText = "DROP TABLE If exists images"
        sqlite_cmd.ExecuteNonQuery()
        _connection.Close()
    End Sub



    Public Sub New(Optional name As String = "templateDB.sqlite")
        Me.Path = name
        _connection = New SQLiteConnection(String.Format("Data Source={0};Version=3;", name))
        ' recreate the database if not found
        CreateTables()
    End Sub

    ''' <summary>
    ''' Removes from database based on ID
    ''' </summary>
    ''' <param name="guid"></param>
    Sub RemoveTemplate(guid As String)
        Dim sqlite_conn = _connection
        sqlite_conn.Open()
        Try
            Dim sqlite_cmd = sqlite_conn.CreateCommand()
            sqlite_cmd.CommandText = "DELETE from template WHERE GUID = ?"
            sqlite_cmd.Parameters.Add(guid)
            sqlite_cmd.ExecuteNonQuery()

            RemoveImage(guid)
        Finally
            ' ensure connection is closed
            sqlite_conn.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Adds a template to the database
    ''' will error if the guid is already in the database
    ''' </summary>
    ''' <param name="lamp"></param>
    Public Sub AddTemplate(lamp As LampTemplate)
        Dim sqlite_conn = _connection

        sqlite_conn.Open()
        Try
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

            ' if there are preview images, store it in the database
            If lamp.PreviewImages.Count > 0 Then
                AddImages(lamp.GUID, lamp.PreviewImages)
            End If

        Finally
            ' ensure connection is always closed
            sqlite_conn.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Function SelectTemplate(guid As String) As LampTemplate
        Dim sqlite_conn = _connection
        sqlite_conn.Open()

        Try
            Dim sqlite_cmd = sqlite_conn.CreateCommand()
            Dim sqlite_reader As SQLiteDataReader

            sqlite_cmd.CommandText = "Select * FROM template WHERE guid = @guid"
            sqlite_cmd.Parameters.AddWithValue("@guid", guid)

            sqlite_reader = sqlite_cmd.ExecuteReader()

            If sqlite_reader.Read() Then
                Dim LampDXF = LampDxfDocument.FromString(sqlite_reader.GetString(sqlite_reader.GetOrdinal("dxf")))

                Dim LampTemp = New LampTemplate(LampDXF)
                LampTemp.GUID = sqlite_reader.GetString(sqlite_reader.GetOrdinal("guid"))
                LampTemp.ApproverId = sqlite_reader.GetString(sqlite_reader.GetOrdinal("ApproverId"))
                LampTemp.ApproverName = sqlite_reader.GetString(sqlite_reader.GetOrdinal("ApproverName"))
                LampTemp.CreatorId = sqlite_reader.GetString(sqlite_reader.GetOrdinal("CreatorId"))
                LampTemp.CreatorName = sqlite_reader.GetString(sqlite_reader.GetOrdinal("CreatorName"))
                LampTemp.IsComplete = sqlite_reader.GetBoolean(sqlite_reader.GetOrdinal("IsComplete"))

                ' check if there are any preview images
                Dim images As List(Of Image) = SelectImages(guid)
                LampTemp.PreviewImages = images

                Return LampTemp
            Else
                Return Nothing
            End If

        Finally
            ' ensure connection is always closed
            sqlite_conn.Close()
        End Try
    End Function

    ''' <summary>
    ''' Stores up to 3 preview images in the database
    ''' images are stored as binary blobs (byte arrays or byte() in vb.net)
    ''' this function takes a list(of Image), converts them into binary and chucks them in the database
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="images"></param>
    Public Sub AddImages(guid As String, images As List(Of Image))
        Dim sqlite_conn = _connection
        sqlite_conn.Open()
        Try
            Dim sqlite_cmd = sqlite_conn.CreateCommand()

            sqlite_cmd.CommandText = "INSERT INTO images 
                    (Guid, image1, image2, image3)  
                    VALUES  
                    (@guid, @image1, @image2, @image3);"


            sqlite_cmd.Parameters.AddWithValue("@guid", guid)
            If images.Count = 0 Then
                Throw New Exception("Must supply at least 1 image")
            ElseIf images.Count = 1 Then
                sqlite_cmd.Parameters.AddWithValue("@image1", ImageToBinary(images(0)))
                sqlite_cmd.Parameters.AddWithValue("@image2", Nothing)
                sqlite_cmd.Parameters.AddWithValue("@image3", Nothing)
            ElseIf images.Count = 2 Then
                sqlite_cmd.Parameters.AddWithValue("@image1", ImageToBinary(images(0)))
                sqlite_cmd.Parameters.AddWithValue("@image2", ImageToBinary(images(1)))
                sqlite_cmd.Parameters.AddWithValue("@image3", Nothing)
            ElseIf images.Count = 3 Then
                sqlite_cmd.Parameters.AddWithValue("@image1", ImageToBinary(images(0)))
                sqlite_cmd.Parameters.AddWithValue("@image2", ImageToBinary(images(1)))
                sqlite_cmd.Parameters.AddWithValue("@image3", ImageToBinary(images(2)))
            Else
                Throw New Exception(String.Format("Must supply list of length max 3, {0} elements supplied", images.Count))
            End If

            sqlite_cmd.ExecuteNonQuery()

        Finally
            ' ensure connection is always closed
            sqlite_conn.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Retrieves the images from the database
    ''' given guid of the template, returns the images associated with it, or nothing if none was found
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectImages(guid As String) As List(Of Image)
        Dim sqlite_conn = _connection
        sqlite_conn.Open()
        Try
            Dim sqlite_cmd = sqlite_conn.CreateCommand()
            Dim sqlite_reader As SQLiteDataReader
            sqlite_cmd.CommandText = "Select * FROM images WHERE guid = @guid"
            sqlite_cmd.Parameters.AddWithValue("@guid", guid)

            sqlite_reader = sqlite_cmd.ExecuteReader()

            If sqlite_reader.Read() Then
                Dim list As New List(Of Image)

                ' should be guaranteed success since image1 is NotNull
                Dim image1 As Image = BinaryToImage(DirectCast(sqlite_reader.GetValue(sqlite_reader.GetOrdinal("image1")), Byte()))
                list.Add(image1)

                If Not sqlite_reader.IsDBNull(sqlite_reader.GetOrdinal("image2")) Then
                    Dim image2 As Image = BinaryToImage(DirectCast(sqlite_reader.GetValue(sqlite_reader.GetOrdinal("image2")), Byte()))
                    list.Add(image2)
                End If

                If Not sqlite_reader.IsDBNull(sqlite_reader.GetOrdinal("image3")) Then
                    Dim image3 As Image = BinaryToImage(DirectCast(sqlite_reader.GetValue(sqlite_reader.GetOrdinal("image3")), Byte()))
                    list.Add(image3)
                End If

                Return list
            Else
                Return New List(Of Image)

            End If

        Finally
            ' ensure connection is always closed
            sqlite_conn.Close()
        End Try
    End Function




    Private Shared ExampleDxfFiles() As String = {"one.dxf", "two.dxf", "three.dxf", "four.dxf", "five.dxf", "six.dxf", "seven.dxf", "eight.dxf", "nine.dxf"}
    ''' <summary>
    ''' Fills database with dxf files located in project root/templates
    ''' The default files are stored in ExampleDxfFiles
    ''' </summary>
    Public Shared Sub FillDebugDatabase()
        Dim db As New TemplateDatabase()
        For Each filename As String In ExampleDxfFiles
            Dim fp = IO.Path.GetFullPath(IO.Path.Combine("../", "../", "../", "templates", filename))
            db.AddTemplate(New LampTemplate(LampDxfDocument.FromFile(fp)))
        Next
    End Sub

    Public Shared Function GetExampleTemplate(name As String) As LampTemplate
        Dim fp = IO.Path.GetFullPath(IO.Path.Combine("../", "../", "../", "templates", name))
        Return New LampTemplate(LampDxfDocument.FromFile(fp))
    End Function


    ''' <summary>
    ''' DXF, Tag, Material, Length, Height, Thickness, Creator Name, Creator ID
    ''' For debugging, dunno if it works now
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
    Private Sub addDebugEntry(GUID As String, DXF As String, tag As String, material As String, length As Integer, height As Integer, materialthickness As Integer, creatorName As String, creator_ID As Integer)
        Dim sqlite_conn = _connection
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()

        sqlite_cmd.CommandText = "INSERT INTO template(Guid,DXF,Tag,material,length,Height,thickness,creatorName,creator_ID,submit_date) VALUES (?,?,?,?,?,?,?,?,?,DATETIME('now'));"

        sqlite_cmd.Parameters.Add(CreateSqlParameter(DbType.String, GUID))
        sqlite_cmd.Parameters.Add(CreateSqlParameter(DbType.String, DXF))
        sqlite_cmd.Parameters.Add(CreateSqlParameter(DbType.String, tag))
        sqlite_cmd.Parameters.Add(CreateSqlParameter(DbType.String, material))
        sqlite_cmd.Parameters.Add(CreateSqlParameter(DbType.Int32, length))
        sqlite_cmd.Parameters.Add(CreateSqlParameter(DbType.Int32, height))
        sqlite_cmd.Parameters.Add(CreateSqlParameter(DbType.Int32, materialthickness))
        sqlite_cmd.Parameters.Add(CreateSqlParameter(DbType.String, creatorName))
        sqlite_cmd.Parameters.Add(CreateSqlParameter(DbType.Int32, creator_ID))

        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub

    ''' <summary>
    ''' Fills database with 50 empty templates
    ''' </summary>
    Public Sub FillDebug()
        Dim iter As Integer
        iter = 1
        Do Until iter = 50
            iter += 1
            Dim dxf As New LampDxfDocument()
            Dim dummy As New LampTemplate(dxf)
            AddTemplate(dummy)
        Loop
    End Sub
End Class

''' <summary>
''' Functions in here are imported into the file
''' and can be used in the TemplateDatabase class
''' since they are public, this makes them easier to debug
''' but dont show up when you do TemplateDatabase.Blah
''' </summary>
Public Class DatabaseHelper
    Public Shared Function SerializeTags(template As LampTemplate) As String
        Return String.Join(",", template.Tags)
    End Function

    Public Shared Function DeserializeTags(tags As String) As List(Of String)
        Return tags.Split(","c).ToList()
    End Function

    Public Shared Function ImageToBinary(image As Image) As Byte()
        If image Is Nothing Then
            Return Nothing
        End If
        Dim stream As New MemoryStream
        image.Save(stream, Imaging.ImageFormat.Png)
        Return stream.ToArray
    End Function

    Public Shared Function BinaryToImage(binary As Byte()) As Image
        If binary Is Nothing Then
            Return Nothing
        End If
        Dim stream As New MemoryStream(binary)
        Return Image.FromStream(stream)
    End Function

    Public Shared Function CreateSqlParameter(type As DbType, data As Object) As SQLiteParameter
        Dim foo As New SQLiteParameter(type)
        foo.Value = data
        Return foo
    End Function

End Class
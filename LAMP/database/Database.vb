Imports System.Data.SQLite
Imports System.IO
Imports LAMP.DatabaseHelper
Imports LAMP

Public Class TemplateDatabase
    ''' <summary>
    ''' Path to database file
    ''' </summary>
    ''' <returns></returns>
    Public Property Path As String

    ''' <summary>
    ''' sqlite connection. Needs to be closed and opened 
    ''' whenever used
    ''' </summary>
    Public Property Connection As SQLiteConnection

    ''' <summary>
    ''' file names of example dxf files in /templates/{name}
    ''' </summary>
    Private Shared ExampleDxfFiles() As String = {"one.dxf", "two.dxf", "three.dxf", "four.dxf", "five.dxf", "six.dxf", "seven.dxf", "eight.dxf", "nine.dxf"}

    ''' <summary>
    ''' Constructor for Database
    ''' By default, the file it will read/write is templateDB.sqlite
    ''' </summary>
    ''' <param name="filePath">the filepath that the databse is located at</param>
    Public Sub New(Optional filePath As String = "templateDB.sqlite")
        Me.Path = filePath
        Connection = New SQLiteConnection(String.Format("Data Source={0};Version=3;", filePath))
        ' recreate the database if not found
        CreateTables()
    End Sub

    ''' <summary> 
    ''' Creates all the tables required, if tables not exist 
    ''' Does not delete any data
    ''' </summary> 
    Public Sub CreateTables()
        Connection.Open()
        Dim sqlite_cmd = Connection.CreateCommand()
        sqlite_cmd.CommandText = "CREATE TABLE if not exists template (
                                  GUID Text PRIMARY KEY Not NULL, 
                                  DXF Text Not NULL,
                                  Name Text DEFAULT '' Not NULL,
                                  ShortDescription Text DEFAULT '' Not NULL,
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
                                  image3 blob,

                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  );"
        sqlite_cmd.ExecuteNonQuery()

        Connection.Close()
    End Sub

    ''' <summary>
    ''' Destroys all tables
    ''' </summary>
    Public Sub DeleteTables()
        Connection.Open()
        Dim sqlite_cmd = Connection.CreateCommand()
        sqlite_cmd.CommandText = "DROP TABLE If exists template"
        sqlite_cmd.ExecuteNonQuery()
        sqlite_cmd.CommandText = "DROP TABLE If exists images"
        sqlite_cmd.ExecuteNonQuery()
        Connection.Close()
    End Sub

    ''' <summary>
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Function SelectTemplate(guid As String) As LampTemplate
        Dim sqlite_conn = Connection
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
    ''' Gets all templates in the database
    ''' </summary>
    ''' <returns></returns>
    Public Function GetAllTemplate() As List(Of LampTemplate)
        Dim sqlite_conn = _Connection
        sqlite_conn.Open()

        Try
            Dim sqlite_cmd = sqlite_conn.CreateCommand()
            Dim sqlite_reader As SQLiteDataReader

            sqlite_cmd.CommandText = "Select * FROM template"

            sqlite_reader = sqlite_cmd.ExecuteReader()
            Dim LampTempList As New List(Of LampTemplate)
            Dim LampDxf As New LampDxfDocument
            Dim LampTemp As New LampTemplate
            Do While sqlite_reader.Read()
                Debug.Write(sqlite_reader.GetString(0))
                LampDxf = LampDxfDocument.FromString(sqlite_reader.GetString(sqlite_reader.GetOrdinal("dxf")))
                LampTemp = New LampTemplate(LampDxf)
                LampTemp.GUID = sqlite_reader.GetString(sqlite_reader.GetOrdinal("guid"))
                'LampTemp.ApproverId = sqlite_reader.GetString(DatabaseColumn.ApproverId)
                LampTemp.ApproverName = sqlite_reader.GetString(sqlite_reader.GetOrdinal("approverName"))
                LampTemp.CreatorId = sqlite_reader.GetString(sqlite_reader.GetOrdinal("creatorId"))
                LampTemp.CreatorName = sqlite_reader.GetString(sqlite_reader.GetOrdinal("creatorName"))
                'LampTemp.IsComplete = sqlite_reader.GetBoolean(DatabaseColumn.IsComplete)
                'still debugging these 2 ;-;
                LampTempList.Add(LampTemp)
            Loop
            sqlite_conn.Close()
            Return LampTempList

        Finally
            sqlite_conn.Close()
        End Try

    End Function

    ''' <summary>
    ''' Adds a template to the database
    ''' will error if the guid is already in the database
    ''' </summary>
    ''' <param name="template"></param>
    Public Sub AddTemplate(template As LampTemplate)
        Dim sqlite_conn = Connection

        sqlite_conn.Open()
        Try
            Dim sqlite_cmd = sqlite_conn.CreateCommand()

            ' Insert if GUID doesnt exist, else replace
            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO template 
                    (Guid, DXF, Tag, material, length, Height, thickness, creatorName, creator_ID, submit_date)  
                    VALUES  
                    (@guid, @dxf, @tags, @material, @length, @height, @thickness, @creatorName, @creatorId, DATETIME('now'));"

            sqlite_cmd.Parameters.AddWithValue("@guid", template.GUID)
            sqlite_cmd.Parameters.AddWithValue("@dxf", template.BaseDrawing.ToDxfString)
            sqlite_cmd.Parameters.AddWithValue("@tags", SerializeTags(template))
            sqlite_cmd.Parameters.AddWithValue("@material", template.Material)
            sqlite_cmd.Parameters.AddWithValue("@length", template.Length)
            sqlite_cmd.Parameters.AddWithValue("@height", template.Height)
            sqlite_cmd.Parameters.AddWithValue("@thickness", template.MaterialThickness)
            sqlite_cmd.Parameters.AddWithValue("@creatorName", template.CreatorName)
            sqlite_cmd.Parameters.AddWithValue("@creatorId", template.CreatorId)
            ' Ensure creatorId and and approverId are strings! 
            ' also add approverid/approvername to the db 

            sqlite_cmd.ExecuteNonQuery()

            ' if there are preview images, store it in the database
            If template.PreviewImages.Count > 0 Then
                AddImages(template.GUID, template.PreviewImages, False)
            End If

        Finally
            ' ensure connection is always closed
            sqlite_conn.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Removes from database based on guid
    ''' Also removes images by default, rmImages can be set to false to not
    ''' </summary>
    ''' <param name="guid">string guid</param>
    ''' <param name="rmImage">whether or not to also delete images</param>
    ''' <returns>True=Removed, False=None found</returns>
    Public Function RemoveTemplate(guid As String, Optional rmImage As Boolean = True) As Boolean
        Dim sqlite_conn = Connection
        sqlite_conn.Open()
        Try
            Dim sqlite_cmd = sqlite_conn.CreateCommand()
            sqlite_cmd.CommandText = "DELETE from template WHERE GUID = ?"
            sqlite_cmd.Parameters.Add(guid)
            Dim rowsRemoved = sqlite_cmd.ExecuteNonQuery()
            If rmImage Then
                RemoveImages(guid, False)
            End If

            If rowsRemoved > 0 Then
                Return True
            Else
                Return False
            End If
        Finally
            ' ensure connection is closed
            sqlite_conn.Close()
        End Try
    End Function

    ''' <summary>
    ''' Retrieves the images from the database
    ''' given guid of the template, returns the images associated with it, or nothing if none was found
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectImages(guid As String) As List(Of Image)
        Dim sqlite_conn = Connection
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



    ''' <summary>
    ''' Stores up to 3 preview images in the database
    ''' images are stored as binary blobs (byte arrays or byte() in vb.net)
    ''' this function takes a list(of Image), converts them into binary and chucks them in the database
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="images"></param>
    Public Sub AddImages(guid As String, images As List(Of Image), Optional openDb As Boolean = True)
        Dim sqlite_conn = Connection

        If openDb Then
            sqlite_conn.Open()
        End If

        Try
            Dim sqlite_cmd = sqlite_conn.CreateCommand()

            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO images 
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
            If openDb Then
                sqlite_conn.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Removes images associated with the guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns>True=Removed image, False=None removed</returns>
    Public Function RemoveImages(guid As String, Optional openDb As Boolean = True) As Boolean
        Dim sqlite_conn = Connection
        If openDb Then
            sqlite_conn.Open()
        End If

        Try
            Dim sqlite_cmd = sqlite_conn.CreateCommand()
            sqlite_cmd.CommandText = "DELETE from images WHERE GUID = ?"
            sqlite_cmd.Parameters.Add(guid)
            Dim rowsRemoved = sqlite_cmd.ExecuteNonQuery()

            If rowsRemoved > 0 Then
                Return True
            Else
                Return False
            End If
        Finally
            ' ensure connection is closed
            If openDb Then
                sqlite_conn.Close()
            End If
        End Try
    End Function

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

    ''' <summary>
    ''' Gets an example template from /templates/{name}
    ''' Name is without the .dxf extension
    ''' preview Image must be .png
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Public Shared Function GetExampleTemplate(name As String) As LampTemplate
        Dim fp = IO.Path.GetFullPath(IO.Path.Combine("../", "../", "../", "templates", name + ".dxf"))
        Dim previewFp = IO.Path.GetFullPath(IO.Path.Combine("../", "../", "../", "templates", name + ".png"))
        Dim template = New LampTemplate(LampDxfDocument.FromFile(fp))
        If File.Exists(previewFp) Then
            Using stream = File.OpenRead(previewFp)
                template.PreviewImages.Add(Image.FromStream(stream))
            End Using
        End If
        Return template
    End Function


    ''' <summary>
    ''' DXF, Tag, Material, Length, Height, Thickness, Creator Name, Creator ID
    ''' For debugging, dunno if it works now since database has changed
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
        Dim sqlite_conn = Connection
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()

        sqlite_cmd.CommandText = "INSERT INTO template(Guid, DXF, Tag, material, length, Height, thickness, creatorName, creator_ID, submit_date) VALUES (?,?,?,?,?,?,?,?,?, DateTime('now'));"

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
    ''' <summary>
    ''' Converts list of tags into string (for database)
    ''' </summary>
    ''' <param name="template"></param>
    ''' <returns></returns>
    Public Shared Function SerializeTags(template As LampTemplate) As String
        Return String.Join(",", template.Tags)
    End Function

    ''' <summary>
    ''' Converts string into list of tags (for database)
    ''' </summary>
    ''' <param name="tags"></param>
    ''' <returns></returns>
    Public Shared Function DeserializeTags(tags As String) As List(Of String)
        Return tags.Split(","c).ToList()
    End Function

    ''' <summary>
    ''' Converts an image to its binary representation
    ''' </summary>
    ''' <param name="image"></param>
    ''' <returns></returns>
    Public Shared Function ImageToBinary(image As Image) As Byte()
        If image Is Nothing Then
            Return Nothing
        End If
        Dim stream As New MemoryStream
        image.Save(stream, Imaging.ImageFormat.Png)
        Return stream.ToArray
    End Function

    ''' <summary>
    ''' Converts binary into image representation
    ''' </summary>
    ''' <param name="binary"></param>
    ''' <returns></returns>
    Public Shared Function BinaryToImage(binary As Byte()) As Image
        If binary Is Nothing Then
            Return Nothing
        End If
        Dim stream As New MemoryStream(binary)
        Return Image.FromStream(stream)
    End Function

    ''' <summary>
    ''' Creates an sqlite paramater
    ''' </summary>
    ''' <param name="type"></param>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Public Shared Function CreateSqlParameter(type As DbType, data As Object) As SQLiteParameter
        Dim foo As New SQLiteParameter(type)
        foo.Value = data
        Return foo
    End Function
End Class
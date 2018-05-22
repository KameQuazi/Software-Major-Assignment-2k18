Imports System.Data.SQLite
Imports System.IO
Imports LAMP.DatabaseHelper
Imports LAMP
Imports System.Text
Imports System.Collections.ObjectModel

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

    Private Opened As Boolean = False

    ''' <summary>
    ''' Opens the database if required. Returns true if database was opened,
    ''' False if it was already open
    ''' </summary>
    Public Function OpenDatabase() As Boolean
        If Me.Opened = False Then
            Me.Connection.Open()
            Me.Opened = True
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Closes the database if necessary. Returns true if database was closed,
    ''' false if database was never opened
    ''' </summary>
    ''' <returns></returns>
    Public Function CloseDatabase() As Boolean
        If Me.Opened = True Then
            Me.Connection.Close()
            Me.Opened = False
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetCommand() As SQLiteCommand
        If Opened = False Then
            Throw New Exception("Database connection Not open! Use OpenDatabase()")
        End If
        Return _Connection.CreateCommand
    End Function

    ''' <summary>
    ''' Creates all the tables required, if tables not exist
    ''' Does not delete any data
    ''' </summary>
    Public Sub CreateTables()
        ' If the databse is open already, dont close it

        Dim closeDatabaseAfter = OpenDatabase()
        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "CREATE TABLE if not exists template (
                                  GUID Text PRIMARY KEY Not NULL,
                                  DXF Text Not NULL,
                                  Name Text DEFAULT '' Not NULL,
                                  ShortDescription Text DEFAULT '' NOT NULL,
                                  LongDescription Text DEFAULT '' NOT NULL,
                                  material Text Not NULL DEFAULT 'none',
                                  length real Not NULL DEFAULT -1,
                                  Height real Not NULL DEFAULT -1,
                                  materialThickness real Not NULL DEFAULT -1,
                                  creatorName Text Not NULL DEFAULT '',
                                  creatorID Text Not NULL DEFAULT '0000-0000-0000-0000',
                                  approverName Text DEFAULT '',
                                  approverID Text Default '0000-0000-0000-0000',
                                  submitDate Text,
                                  complete Int DEFAULT FALSE);"
                sqlite_cmd.ExecuteNonQuery()

                sqlite_cmd.CommandText = "CREATE TABLE if not exists images (
                                  GUID Text PRIMARY KEY Not NULL, 
                                  image1 blob,
                                  image2 blob,
                                  image3 blob,

                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  );"
                sqlite_cmd.ExecuteNonQuery()

                sqlite_cmd.CommandText = "CREATE TABLE if not exists tags (
                                  GUID Text Not Null,
                                  TagName Text Not Null,
                        
                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  );
                        "
                sqlite_cmd.ExecuteNonQuery()

                sqlite_cmd.CommandText = "CREATE TABLE if not exists user (
                                  UserId Text Not Null,
                                  email Text Not Null,
                                  Password Text Null,
                                  PermissionLevel Integer Not Null
                                  );
                        "
                sqlite_cmd.ExecuteNonQuery()


                sqlite_cmd.CommandText = "CREATE TABLE if not exists jobs (
                                  GUID Text Not Null,
                                  templateId Text Not NULL,
                                  submitterId Text Not NULL,
                                  approverId Text,
                                  approved integer Not Null default 0,
                                  submitDate Text Not null,

                                  FOREIGN KEY(submitterId) REFERENCES user(UserId),
                                  FOREIGN KEY(approverId) REFERENCES user(UserId)
                                  );"
                sqlite_cmd.ExecuteNonQuery()
            End Using

        Finally

            If closeDatabaseAfter Then
                CloseDatabase()

            End If
        End Try
    End Sub


    ''' <summary>
    ''' Destroys all tables
    ''' </summary>
    Public Sub DeleteTables()
        ' If the databse is open already, dont close it
        Dim closeDatabaseAfter = OpenDatabase()
        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "DROP TABLE If exists template"
                sqlite_cmd.ExecuteNonQuery()
                sqlite_cmd.CommandText = "DROP TABLE If exists images"
                sqlite_cmd.ExecuteNonQuery()
                sqlite_cmd.CommandText = "DROP TABLE If exists tags"
                sqlite_cmd.ExecuteNonQuery()
            End Using
        Finally
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Reads 1 row off the sqliteReader, returning a lampTemplate with its variables set
    ''' This is so you dont have to duplicate code over SelectTemplate, SelectAllTemplate etc
    ''' Does not call reader.Read(), the reader must have data in it
    ''' </summary>
    Private Function ReadTemplateTable(reader As SQLiteDataReader, Optional start As LampTemplate = Nothing) As LampTemplate
        If reader.HasRows <> True Then
            Throw New DataException(NameOf(reader))
        End If

        If start Is Nothing Then
            start = New LampTemplate
        End If

        Dim LampDXF = LampDxfDocument.FromString(reader.GetString(reader.GetOrdinal("dxf")))

        Dim LampTemp = New LampTemplate(LampDXF)
        LampTemp.GUID = reader.GetString(reader.GetOrdinal("guid"))
        LampTemp.Name = reader.GetString(reader.GetOrdinal("name"))
        LampTemp.ShortDescription = reader.GetString(reader.GetOrdinal("ShortDescription"))
        LampTemp.LongDescription = reader.GetString(reader.GetOrdinal("LongDescription"))
        LampTemp.Material = reader.GetString(reader.GetOrdinal("material"))
        LampTemp.Height = reader.GetDouble(reader.GetOrdinal("height"))
        LampTemp.Length = reader.GetDouble(reader.GetOrdinal("length"))
        LampTemp.MaterialThickness = reader.GetDouble(reader.GetOrdinal("MaterialThickness"))
        LampTemp.SubmitDate = reader.GetDateTime(reader.GetOrdinal("submitDate"))


        LampTemp.ApproverId = reader.GetString(reader.GetOrdinal("ApproverId"))
        LampTemp.ApproverName = reader.GetString(reader.GetOrdinal("ApproverName"))
        LampTemp.CreatorId = reader.GetString(reader.GetOrdinal("CreatorId"))
        LampTemp.CreatorName = reader.GetString(reader.GetOrdinal("CreatorName"))
        LampTemp.IsComplete = reader.GetBoolean(reader.GetOrdinal("complete"))

        Return start
    End Function

    Private Function ReadImageTable(reader As SQLiteDataReader, Optional start As LampTemplate = Nothing) As LampTemplate
        If start Is Nothing Then
            start = New LampTemplate()
        End If
        Throw New NotImplementedException()
    End Function

    Private Function ReadTagTable(reader As SQLiteDataReader, Optional start As LampTemplate = Nothing) As LampTemplate
        If start Is Nothing Then
            start = New LampTemplate()
        End If

        Throw New NotImplementedException()
    End Function

    Sub removeEntry(guid As String)
        Dim sqlite_conn = _Connection
        sqlite_conn.Open()
        Dim sqlite_cmd = sqlite_conn.CreateCommand()
        sqlite_cmd.CommandText = "DELETE from template WHERE GUID = ?"
        sqlite_cmd.Parameters.Add(guid, DbType.String)
        sqlite_cmd.ExecuteNonQuery()
        sqlite_conn.Close()
    End Sub

    ''' <summary>
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Function SelectTemplate(guid As String) As LampTemplate
        ' If the databse is open already, dont close it
        Dim closeDatabaseAfter = OpenDatabase()


        Try
            Using sqlite_cmd = GetCommand()

                sqlite_cmd.CommandText = "Select * FROM template WHERE guid = @guid"
                sqlite_cmd.Parameters.AddWithValue("@guid", guid)

                Using sqlite_reader = sqlite_cmd.ExecuteReader()
                    ' read only 1 row off the database
                    If sqlite_reader.Read() Then
                        Dim LampTemp = ReadTemplateTable(sqlite_reader)

                        ' get all the preview images

                        For Each image In SelectImages(guid)
                            LampTemp.PreviewImages.Add(image)
                        Next

                        ' get all the tags from the db as well
                        LampTemp.Tags = SelectTags(guid).ToObservableList

                        Return LampTemp
                    Else
                        Return Nothing
                    End If
                End Using
            End Using


        Finally
            ' ensure connection is always closed
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Function


    ''' <summary>
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <returns></returns>
    Function SelectTemplateWithTags(tags As List(Of String), Optional limit As Integer = 10, Optional offset As Integer = 0) As List(Of LampTemplate)
        ' If the databse is open already, dont close it
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                Dim matchingTemplates As New List(Of LampTemplate)

                Dim tagParameters As New StringBuilder()
                For i = 0 To tags.Count - 1
                    tagParameters.Insert(i, "@tag" + i.ToString())
                Next
                ' find all templates w/
                sqlite_cmd.CommandText = String.Format("Select guid from tags
                                      WHERE tagName IN ({0})
                                      LIMIT @limit
                                      OFFSET @offset
                                     ", tagParameters.ToString())
                For i = 0 To tags.Count - 1
                    sqlite_cmd.Parameters.AddWithValue("@tag" + i.ToString(), tags(i).ToLower())
                Next
                sqlite_cmd.Parameters.AddWithValue("@limit", limit)
                sqlite_cmd.Parameters.AddWithValue("@offset", offset)


                Using sqlite_reader = sqlite_cmd.ExecuteReader()
                    While sqlite_reader.Read()
                        Dim guid = sqlite_reader.GetString(sqlite_reader.GetOrdinal("guid"))
                        matchingTemplates.Add(SelectTemplate(guid))
                    End While

                End Using

                Return matchingTemplates
            End Using
        Finally
            ' ensure connection is always closed
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Function



    ''' <summary>
    ''' Gets all templates in the database
    ''' </summary>
    ''' <returns></returns>
    Public Function GetAllTemplate() As List(Of LampTemplate)
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()

                sqlite_cmd.CommandText = "Select * FROM template"

                Using sqlite_reader = sqlite_cmd.ExecuteReader()
                    Dim LampTempList As New List(Of LampTemplate)
                    Dim LampTemp As LampTemplate

                    While sqlite_reader.Read()
                        ' read the data off this sqlite_reader
                        LampTemp = ReadTemplateTable(sqlite_reader)


                        ' Set images
                        LampTemp.PreviewImages.Clear()
                        For Each image In SelectImages(LampTemp.GUID)
                            LampTemp.PreviewImages.Add(image)
                        Next

                        ' set tags
                        LampTemp.Tags.Clear()
                        For Each tag In SelectTags(LampTemp.GUID)
                            LampTemp.Tags.Add(tag)
                        Next

                        LampTempList.Add(LampTemp)
                    End While

                    Return LampTempList
                End Using

            End Using
        Finally
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try

    End Function

    ''' <summary>
    ''' Adds a template to the database
    ''' will error if the guid is already in the database
    ''' </summary>
    ''' <param name="template"></param>
    Public Sub AddTemplate(template As LampTemplate)
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()

                ' Insert if GUID doesnt exist, else replace
                sqlite_cmd.CommandText = "INSERT OR REPLACE INTO template
                    (Guid, DXF, material, length, Height, materialthickness, creatorName, creatorID, complete, submitdate)
                    VALUES
                    (@guid, @dxf, @material, @length, @height, @materialthickness, @creatorName, @creatorId, @complete, DATETIME('now'));"

                sqlite_cmd.Parameters.AddWithValue("@guid", template.GUID)
                sqlite_cmd.Parameters.AddWithValue("@dxf", template.BaseDrawing.ToDxfString)
                ' todo use tags table instead of as string
                sqlite_cmd.Parameters.AddWithValue("@material", template.Material)
                sqlite_cmd.Parameters.AddWithValue("@length", template.Length)
                sqlite_cmd.Parameters.AddWithValue("@height", template.Height)
                sqlite_cmd.Parameters.AddWithValue("@materialthickness", template.MaterialThickness)
                sqlite_cmd.Parameters.AddWithValue("@creatorName", template.CreatorName)
                sqlite_cmd.Parameters.AddWithValue("@creatorId", template.CreatorId)
                sqlite_cmd.Parameters.AddWithValue("@complete", template.IsComplete)

                ' Ensure creatorId and and approverId are strings!
                ' also add approverid/approvername to the db

                sqlite_cmd.ExecuteNonQuery()

                ' check that there is at least 1 image
                If template.PreviewImages.HasNotNothing() Then
                    AddImages(template.GUID, template.PreviewImages)
                End If


                If template.Tags.Count > 0 Then
                    AddTags(template.GUID, template.Tags)
                End If

            End Using
        Finally
            ' ensure connection is always closed
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
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
        Dim closeDatabaseAfter = OpenDatabase()

        Try

            Using sqlite_cmd = GetCommand()
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
            End Using
        Finally
            ' ensure connection is closed
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Function

    ''' <summary>
    ''' Retrieves the images from the database
    ''' given guid of the template, returns the images associated with it, or nothing if none was found
    ''' returns a list of <see cref="LampTemplate.MaxImages"/> size.
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectImages(guid As String) As List(Of Image)
        Dim shouldCloseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "Select image1, image2, image3 FROM images WHERE guid = @guid"
                sqlite_cmd.Parameters.AddWithValue("@guid", guid)

                Using sqlite_reader = sqlite_cmd.ExecuteReader()
                    Dim images As New List(Of Image)

                    If sqlite_reader.Read() Then

                        For i = 1 To LampTemplate.MaxImages

                            Dim columnNumber = sqlite_reader.GetOrdinal(String.Format("image{0}", i))

                            If Not sqlite_reader.IsDBNull(columnNumber) Then
                                Dim readImage As Image = BinaryToImage(DirectCast(sqlite_reader.GetValue(columnNumber), Byte()))
                                images.Add(readImage)
                            Else

                                images.Add(Nothing)
                            End If
                        Next
                    End If

                    Return images
                End Using
            End Using

        Finally
            If shouldCloseAfter Then
                CloseDatabase()
            End If
        End Try
    End Function



    ''' <summary>
    ''' Stores up to 3 preview images in the database
    ''' images are stored as binary blobs (byte arrays or byte() in vb.net)
    ''' this function takes a list(of Image), converts them into binary and chucks them in the database
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="images"></param>
    Public Sub AddImages(guid As String, images As IList(Of Image))
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "INSERT OR REPLACE INTO images
                    (Guid, image1, image2, image3)
                    VALUES
                    (@guid, @image1, @image2, @image3);"

                sqlite_cmd.Parameters.AddWithValue("@guid", guid)

                If images.Count > LampTemplate.MaxImages Then
                    Throw New ArgumentOutOfRangeException(NameOf(images), images, String.Format("images array must have {0} or less elements", LampTemplate.MaxImages))
                End If

                Dim insertedAtLeastOne As Boolean = False

                For i = 0 To images.Count - 1
                    Dim columnName = String.Format("images{0}", i + 1)
                    sqlite_cmd.Parameters.AddWithValue("@image1", ImageToBinary(images(0)))
                Next

                If insertedAtLeastOne = False Then
                    Throw New ArgumentOutOfRangeException(NameOf(images), images, "Images must have at least 1 not-null element")
                End If

                sqlite_cmd.ExecuteNonQuery()
            End Using


        Finally
            ' ensure connection is always closed
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Sub

    Public Function SelectTags(guid As String) As List(Of String)
        Dim closeDatabaseAfter = OpenDatabase()
        Try
            Using sqlite_cmd = GetCommand()

                sqlite_cmd.CommandText = "SELECT tagName FROM tags
                                      WHERE guid=@guid;"


                sqlite_cmd.Parameters.AddWithValue("@guid", guid)
                Dim tags As New List(Of String)
                Dim reader = sqlite_cmd.ExecuteReader()

                While reader.Read()
                    tags.Add(reader.GetString(reader.GetOrdinal("tagName")))
                End While

                Return tags
            End Using

        Finally
            If closeDatabaseAfter Then
                CloseDatabase()
            End If

        End Try
    End Function

    ''' <summary>
    ''' TODO !
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="tags"></param>
    Public Sub AddTags(guid As String, tags As IList(Of String))
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "INSERT OR REPLACE INTO tags
                    (Guid, tagName)
                    VALUES
                    (@guid, @tagName);"


                sqlite_cmd.Parameters.AddWithValue("@guid", guid)
                For Each tag In tags
                    sqlite_cmd.Parameters.AddWithValue("@tagName", tag)
                    sqlite_cmd.ExecuteNonQuery()
                Next

            End Using


        Finally
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Removes images associated with the guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns>True=Removed image, False=None removed</returns>
    Public Function RemoveImages(guid As String, Optional openDb As Boolean = True) As Boolean
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "DELETE from images WHERE GUID = ?"
                sqlite_cmd.Parameters.Add(guid)
                Dim rowsRemoved = sqlite_cmd.ExecuteNonQuery()

                If rowsRemoved > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Finally
            ' ensure connection is closed
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Function

    ''' <summary>
    ''' Adds a user to the database
    ''' </summary>
    ''' <param name="user"></param>
    Public Sub AddUser(user As LampUser)
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "INSERT OR REPLACE INTO user
                    (UserId, email, password, permissionLevel)
                    VALUES
                    (@UserId, @email, @password, @permissionLevel);"


                sqlite_cmd.Parameters.AddWithValue("@UserId", user.UserId)
                sqlite_cmd.Parameters.AddWithValue("@email", user.Email)
                sqlite_cmd.Parameters.AddWithValue("@password", user.Password)
                sqlite_cmd.Parameters.AddWithValue("@permissionLevel", user.PermissionLevel)

                sqlite_cmd.ExecuteNonQuery()

            End Using


        Finally
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Adds a job to the database
    ''' </summary>
    Public Sub AddJob(job As LampJob)
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                ' check if the template is already in the database
                If SelectTemplate(job.Template.GUID) IsNot Nothing Then
                    AddTemplate(job.Template)
                End If

                sqlite_cmd.CommandText = "INSERT OR REPLACE INTO tags
                    (GUID, templateId, submitterId, approverId, approved)
                    VALUES
                    (@guid, @templateId, @submitterId, @approverId, @approved);"


                sqlite_cmd.Parameters.AddWithValue("@guid", job.GUID)
                sqlite_cmd.Parameters.AddWithValue("@templateId", job.Template.GUID)
                sqlite_cmd.Parameters.AddWithValue("@submitterId", job.SubmitId)
                sqlite_cmd.Parameters.AddWithValue("@approverId", job.ApproverId)
                sqlite_cmd.Parameters.AddWithValue("@approved", job.Approved)

                sqlite_cmd.ExecuteNonQuery()

            End Using


        Finally
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Sub


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
                template.PreviewImages(0) = (Image.FromStream(stream))
            End Using
        End If
        template.Name = name
        Return template
    End Function

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
        Using ms = New MemoryStream
            image.Save(ms, Imaging.ImageFormat.Png)
            Return ms.ToArray
        End Using
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

Public Module Extensions
    <System.Runtime.CompilerServices.Extension>
    Public Function ToObservableList(Of T)(this As List(Of T)) As ObservableCollection(Of T)
        Return New ObservableCollection(Of T)(this)
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function ToList(Of T)(this As ObservableCollection(Of T)) As List(Of T)
        Return New List(Of T)(this)
    End Function

    ''' <summary>
    ''' Clears a list so that it has that many elements left
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    <System.Runtime.CompilerServices.Extension>
    Public Sub ClearAsArray(Of T)(this As IList(Of T), Optional size As Integer = LampTemplate.MaxImages)
        this.Clear()
        For i = 0 To size - 1
            this.Add(Nothing)
        Next
    End Sub

    <System.Runtime.CompilerServices.Extension>
    Public Function HasNotNothing(Of T)(this As IList(Of T)) As Boolean
        For Each item In this
            If item IsNot Nothing Then
                Return True
            End If
        Next
        Return False
    End Function

End Module

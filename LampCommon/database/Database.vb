Imports System.IO
Imports System.Text
Imports System.Collections.ObjectModel
Imports System.Data.SQLite
Imports System.Drawing
Imports LampCommon.DatabaseHelper
Imports LampCommon
Imports System.Threading

Public Class TemplateDatabase
    ''' <summary>
    ''' Path to database file
    ''' </summary>
    ''' <returns></returns>
    Public Property Path As String

    ''' <summary>
    ''' sqlite connection. Needs to be closed and opened
    ''' </summary>
    Public Property Connection As SqliteConnectionWrapper


    ''' <summary>
    ''' Constructor for Database
    ''' By default, the file it will read/write is templateDB.sqlite
    ''' </summary>
    ''' <param name="filePath">the filepath that the databse is located at</param>
    Public Sub New(Optional filePath As String = "templateDB.sqlite")
        If filePath Is Nothing Then
            filePath = "templateDB.sqlite"
        End If
        Me.Path = filePath
        Connection = New SqliteConnectionWrapper(String.Format("Data Source={0};Version=3;", filePath))
        ' recreate the database if not found
        CreateTables()
    End Sub





    ''' <summary>
    ''' Creates all the tables required, if tables not exist
    ''' Does not delete any data
    ''' </summary>
    Public Sub CreateTables()
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            command.CommandText = "CREATE TABLE if not exists users (
                                  UserId Text PRIMARY KEY Not Null,
                                  PermissionLevel Integer Not Null,
                                  email Text Not Null UNIQUE,
                                  Username text Not NULL UNIQUE,
                                  Password Text Not Null,
                                  Name Text Not Null
                                  );
                        "
            command.ExecuteNonQuery()

            command.CommandText = "CREATE TABLE if not exists template (
                                  GUID Text PRIMARY KEY Not NULL,
                                  Name Text DEFAULT '' Not NULL,
                                  ShortDescription Text DEFAULT '' NOT NULL,
                                  LongDescription Text DEFAULT '' NOT NULL,
                                  material Text Not NULL DEFAULT 'none',
                                  length real Not NULL DEFAULT -1,
                                  Height real Not NULL DEFAULT -1,
                                  materialThickness real Not NULL DEFAULT -1,
                                  creatorID Text,
                                  approverID Text,
                                  submitDate Text,
                                  complete Int DEFAULT FALSE,
                                    
                                  FOREIGN KEY(creatorID) REFERENCES users(UserId),
                                  FOREIGN KEY(approverID) REFERENCES users(UserId)
                                  );"

            command.ExecuteNonQuery()



            command.CommandText = "CREATE TABLE if not exists dxf (
                                  GUID Text PRIMARY KEY not null,
                                  DXF Text Not NULL,
                                  
                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  );"
            command.ExecuteNonQuery()

            command.CommandText = "CREATE TABLE if not exists images (
                                  GUID Text PRIMARY KEY Not NULL, 
                                  image1 blob,
                                  image2 blob,
                                  image3 blob,

                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  );"
            command.ExecuteNonQuery()

            command.CommandText = "CREATE TABLE if not exists tags (
                                  GUID Text Not Null,
                                  TagName Text Not Null,
                        
                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  );
                        "
            command.ExecuteNonQuery()




            command.CommandText = "CREATE TABLE if not exists jobs (
                                  jobId Text Not Null,
                                  templateId Text Not NULL,
                                  submitterId Text Not NULL,
                                  approverId Text,
                                  approved integer Not Null default 0,
                                  submitDate Text Not null,

                                  FOREIGN KEY(submitterId) REFERENCES users(UserId),
                                  FOREIGN KEY(approverId) REFERENCES users(UserId)
                                  );"
            command.ExecuteNonQuery()
        End Using

    End Sub


    ''' <summary>
    ''' Destroys all tables
    ''' </summary>
    Public Sub DeleteTables()
        ' If the databse is open already, dont close it
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            command.CommandText = "DROP TABLE If exists users"
            command.ExecuteNonQuery()
            command.CommandText = "DROP TABLE If exists dxf"
            command.ExecuteNonQuery()
            command.CommandText = "DROP TABLE If exists images"
            command.ExecuteNonQuery()
            command.CommandText = "DROP TABLE If exists tags"
            command.ExecuteNonQuery()
            command.CommandText = "DROP TABLE If exists jobs"
            command.ExecuteNonQuery()
            command.CommandText = "DROP TABLE If exists template"
            command.ExecuteNonQuery()
        End Using
    End Sub


    ''' <summary>
    ''' Gets a dxf. Returns nothing if not found
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectDxf(guid As String) As LampDxfDocument
        Dim dxf As LampDxfDocument = Nothing
        Using conn = Connection.OpenConnection, command = Connection.GetCommand
            command.CommandText = "Select DXF from dxf WHERE guid=@guid"
            command.Parameters.AddWithValue("@guid", guid)
            Dim dxfString = DirectCast(command.ExecuteScalar(), String)
            If dxfString IsNot Nothing Then
                dxf = LampDxfDocument.FromString(dxfString)
            End If
        End Using
        Return dxf
    End Function


    ''' <summary>
    ''' Gets a dxf
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Async Function SelectDxfAsync(guid As String) As Task(Of LampDxfDocument)
        ' If the databse is open already, dont close it
        Using conn = Connection.OpenConnection, command = Connection.GetCommand
            command.CommandText = "Select DXF from dxf WHERE guid=@guid"
            command.Parameters.AddWithValue("@guid", guid)
            Dim dxfString = DirectCast(Await command.ExecuteScalarAsync(), String)
            If dxfString IsNot Nothing Then
                Return LampDxfDocument.FromString(dxfString)
            Else
                Return Nothing
            End If
        End Using
    End Function


    ''' <summary>
    ''' Adds a dxf to the db. Uses the guid in a template
    ''' </summary>
    ''' <param name="template"></param>
    ''' <returns></returns>
    Public Function AddDxf(template As LampTemplate)
        Return AddDxf(template.GUID, template.BaseDrawing)
    End Function


    ''' <summary>
    ''' Adds dxf to the db
    ''' </summary>
    Public Function AddDxf(guid As String, dxf As LampDxfDocument) As Boolean
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand()
            ' Add in templateData
            sqlite_cmd.CommandText = "INSERT OR REPLACE into DXF
                    (guid, DXF)
                    VALUES
                    (@guid, @DXF)"

            sqlite_cmd.Parameters.AddWithValue("@guid", guid)
            sqlite_cmd.Parameters.AddWithValue("@DXF", dxf.ToDxfString())


            Return Convert.ToBoolean(sqlite_cmd.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' adds a dxf async
    ''' </summary>
    ''' <param name="template"></param>
    ''' <returns></returns>
    Public Async Function AddDxfAsync(template As LampTemplate) As Task(Of Boolean)
        Return Await AddDxfAsyc(template.GUID, template.BaseDrawing)
    End Function


    ''' <summary>
    ''' adds a dxf async
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="dxf"></param>
    ''' <returns></returns>
    Public Async Function AddDxfAsyc(guid As String, dxf As LampDxfDocument) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            ' Add in templateData
            command.CommandText = "INSERT OR REPLACE into DXF
                    (guid, DXF)
                    VALUES
                    (@guid, @DXF)"

            command.Parameters.AddWithValue("@guid", guid)
            command.Parameters.AddWithValue("@DXF", dxf.ToDxfString())

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync())
        End Using
    End Function


    ''' <summary>
    ''' Removes from database based on guid
    ''' Also removes images by default, rmImages can be set to false to not
    ''' </summary>
    ''' <param name="guid">string guid</param>
    ''' <returns>True=Removed, False=None found</returns>
    Public Function RemoveDxf(guid As String) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "DELETE from dxf WHERE GUID = @guid"
            command.Parameters.AddWithValue("@guid", guid)

            Return Convert.ToBoolean(command.ExecuteNonQuery())
        End Using
    End Function


    ''' <summary>
    ''' Removes from database based on guid
    ''' Also removes images by default, rmImages can be set to false to not
    ''' </summary>
    ''' <param name="guid">string guid</param>
    ''' <returns>True=Removed, False=None found</returns>
    Public Async Function RemoveDxfAsync(guid As String) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "DELETE from dxf WHERE GUID = @guid"
            command.Parameters.AddWithValue("@guid", guid)

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync())
        End Using
    End Function


    ''' <summary>
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Function SelectTemplate(guid As String) As LampTemplate
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim dxf As LampDxfDocument = SelectDxf(guid)

            If dxf IsNot Nothing Then

                command.CommandText = "Select 
                                    name, shortDescription, longDescription, material, 
                                    length, height, materialthickness, 
                                    creatorId, approverId, submitDate, complete 

                                    FROM template WHERE guid = @guid"
                command.Parameters.AddWithValue("@guid", guid)
                Using reader = command.ExecuteReader()
                    ' read only 1 row off the database
                    If reader.Read() Then
                        Dim LampTemp = New LampTemplate(dxf)
                        LampTemp.GUID = guid

                        LampTemp.Name = reader.GetString(reader.GetOrdinal("name"))
                        LampTemp.ShortDescription = reader.GetString(reader.GetOrdinal("ShortDescription"))
                        LampTemp.LongDescription = reader.GetString(reader.GetOrdinal("LongDescription"))
                        LampTemp.Material = reader.GetString(reader.GetOrdinal("material"))
                        LampTemp.Height = reader.GetDouble(reader.GetOrdinal("height"))
                        LampTemp.Length = reader.GetDouble(reader.GetOrdinal("length"))
                        LampTemp.MaterialThickness = reader.GetDouble(reader.GetOrdinal("MaterialThickness"))

                        If reader.IsDBNull(reader.GetOrdinal("CreatorId")) Then
                            LampTemp.CreatorProfile = Nothing
                        Else
                            LampTemp.CreatorProfile = SelectUser(reader.GetString(reader.GetOrdinal("CreatorId"))).ToProfile
                        End If

                        If reader.IsDBNull(reader.GetOrdinal("ApproverId")) Then
                            LampTemp.ApproverProfile = Nothing
                        Else
                            LampTemp.CreatorProfile = SelectUser(reader.GetString(reader.GetOrdinal("ApproverId"))).ToProfile
                        End If

                        LampTemp.SubmitDate = reader.GetDateTime(reader.GetOrdinal("submitDate"))
                        LampTemp.IsComplete = reader.GetBoolean(reader.GetOrdinal("complete"))

                        ' get all the preview 
                        Dim images = SelectImages(guid)
                        If images IsNot Nothing Then

                            For i = 0 To LampTemplate.MaxImages - 1
                                LampTemp.PreviewImages(i) = images(i)
                            Next
                        End If

                        ' get all the tags from the db as well
                        For Each tag In SelectTags(guid)
                            LampTemp.Tags.Add(tag)
                        Next

                        Return LampTemp
                    End If
                End Using
            End If
        End Using
    End Function




    ''' <summary>
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <returns></returns>
    Public Function SelectTemplateWithTags(tags As List(Of String), Optional limit As Integer = 10, Optional offset As Integer = 0) As List(Of LampTemplate)
        ' If the databse is open already, dont close it

        Using conn = Connection.OpenDatabase(), command = Connection.GetCommand()
            Dim matchingTemplates As New List(Of LampTemplate)

            Dim tagParameters As New StringBuilder()
            For i = 0 To tags.Count - 1
                tagParameters.Insert(i, "@tag" + i.ToString())
            Next
            ' find all templates w/
            command.CommandText = String.Format("Select guid from tags
                                      WHERE tagName IN ({0})
                                      LIMIT @limit
                                      OFFSET @offset
                                     ", tagParameters.ToString())
            For i = 0 To tags.Count - 1
                command.Parameters.AddWithValue("@tag" + i.ToString(), tags(i).ToLower())
            Next
            command.Parameters.AddWithValue("@limit", limit)
            command.Parameters.AddWithValue("@offset", offset)


            Using sqlite_reader = command.ExecuteReader()
                While sqlite_reader.Read()
                    Dim guid = sqlite_reader.GetString(sqlite_reader.GetOrdinal("guid"))
                    matchingTemplates.Add(SelectTemplate(guid))
                End While

            End Using

            Return matchingTemplates
        End Using

    End Function

    ''' <summary>
    ''' Gets all templates in the database
    ''' </summary>
    ''' <returns></returns>
    Public Function GetAllTemplate() As List(Of LampTemplate)
        Dim LampTempList As New List(Of LampTemplate)
        Using Connection.OpenConnection()
            Using sqlite_cmd = Connection.GetCommand()
                sqlite_cmd.CommandText = "Select guid FROM template"

                Using sqlite_reader = sqlite_cmd.ExecuteReader()
                    While sqlite_reader.Read()
                        ' read the data off this sqlite_reader
                        Dim LampTemp = SelectTemplate(sqlite_reader.GetString(sqlite_reader.GetOrdinal("guid")))

                        LampTempList.Add(LampTemp)
                    End While
                End Using
            End Using
        End Using
        Return LampTempList
    End Function

    Public Async Function GetAllTemplateAsync() As Task(Of List(Of LampTemplate))
        Dim LampTempList As New List(Of LampTemplate)
        Using Connection.OpenConnection()
            Using sqlite_cmd = Connection.GetCommand()
                sqlite_cmd.CommandText = "Select guid FROM template"

                Using sqlite_reader = Await sqlite_cmd.ExecuteReaderAsync()
                    While sqlite_reader.Read()
                        ' read the data off this sqlite_reader
                        Dim LampTemp = Await SelectTemplateAsync(sqlite_reader.GetString(sqlite_reader.GetOrdinal("guid")))

                        LampTempList.Add(LampTemp)
                    End While
                End Using
            End Using
        End Using
        Return LampTempList
    End Function


    ''' <summary>
    ''' Sets or unsets the approver of a template
    ''' if a template has an approver of nothing, it is counted as not approved
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="approver"></param>
    ''' <returns>True if found, false if not updated (no template)</returns>
    Public Function SetApprover(guid As String, approver As String) As Boolean
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            ' a transaction makes sure all the inserts are successful 
            ' we dont want a template with name etc, but no dxf 
            Using sqlite_cmd = Connection.CreateCommand()
                sqlite_cmd.CommandText = "UPDATE template SET approverId = @approverId"
                sqlite_cmd.Parameters.AddWithValue("@approverId", approver)

                Return Convert.ToBoolean(sqlite_cmd.ExecuteNonQuery())
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
    Public Sub AddTemplate(template As LampTemplate, Optional creatorId As String = Nothing, Optional approverId As String = Nothing)
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            ' a transaction makes sure all the inserts are successful 
            ' we dont want a template with name etc, but no dxf 
            Using sqlite_cmd = GetCommand()

                ' Add in templateData
                sqlite_cmd.CommandText = "INSERT OR REPLACE INTO template
                    (guid, name, shortDescription, longDescription, material,
                    length, Height, materialthickness, 
                    creatorID, approverId, submitdate, complete)
                    VALUES
                    (@guid, @name, @shortDescription, @longDescription, @material, 
                    @length, @height, @materialthickness, 
                    @creatorId, @approverId, DATETIME('now'), @complete);"

                sqlite_cmd.Parameters.AddWithValue("@guid", template.GUID)

                sqlite_cmd.Parameters.AddWithValue("@name", template.Name)
                sqlite_cmd.Parameters.AddWithValue("@shortDescription", template.ShortDescription)
                sqlite_cmd.Parameters.AddWithValue("@longDescription", template.LongDescription)
                sqlite_cmd.Parameters.AddWithValue("@material", template.Material)

                sqlite_cmd.Parameters.AddWithValue("@length", template.Length)
                sqlite_cmd.Parameters.AddWithValue("@height", template.Height)
                sqlite_cmd.Parameters.AddWithValue("@materialthickness", template.MaterialThickness)

                sqlite_cmd.Parameters.AddWithValue("@creatorId", creatorId)
                sqlite_cmd.Parameters.AddWithValue("@approverId", approverId)
                sqlite_cmd.Parameters.AddWithValue("@complete", template.IsComplete)

                sqlite_cmd.ExecuteNonQuery()


                AddDxf(template.GUID, template.BaseDrawing)

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
    ''' <returns>True=Removed, False=None found</returns>
    Public Function RemoveTemplate(guid As String) As Boolean
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                ' gotta remove these first before the guid in the templates table is gone
                RemoveDxf(guid)
                RemoveImages(guid)
                RemoveTags(guid)

                sqlite_cmd.CommandText = "DELETE from template WHERE GUID = @guid"
                sqlite_cmd.Parameters.AddWithValue("@guid", guid)
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
                        Return images
                    Else
                        Return Nothing
                    End If


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
                    Dim columnName = String.Format("@image{0}", i + 1)
                    sqlite_cmd.Parameters.AddWithValue(columnName, ImageToBinary(images(i)))

                    If images(i) IsNot Nothing Then
                        insertedAtLeastOne = True
                    End If
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

    ''' <summary>
    ''' Removes images associated with the guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns>True=Removed image, False=None removed</returns>
    Public Function RemoveImages(guid As String) As Boolean
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
    ''' Gets all tags that belong to a template's guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
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
    ''' Removes all tags associated with the guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function RemoveTags(guid As String) As Integer
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "DELETE from tags WHERE guid = @guid"
                sqlite_cmd.Parameters.AddWithValue("@guid", guid)
                Dim rowsRemoved = sqlite_cmd.ExecuteNonQuery()


                Return rowsRemoved
            End Using
        Finally
            ' ensure connection is closed
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Function

    ''' <summary>
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function SelectUser(userId As String) As LampUser
        Dim shouldCloseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "Select email, username, password, permissionLevel, name from Users 
                                          WHERE userId = @guid"
                sqlite_cmd.Parameters.AddWithValue("@guid", userId)

                Using sqlite_reader = sqlite_cmd.ExecuteReader()
                    Dim user As LampUser
                    If sqlite_reader.Read() Then
                        Dim email = sqlite_reader.GetString(sqlite_reader.GetOrdinal("email"))
                        Dim username = sqlite_reader.GetString(sqlite_reader.GetOrdinal("username"))
                        Dim password = sqlite_reader.GetString(sqlite_reader.GetOrdinal("password"))
                        Dim permissionLevel = sqlite_reader.GetInt32(sqlite_reader.GetOrdinal("permissionLevel"))
                        Dim name = sqlite_reader.GetString(sqlite_reader.GetOrdinal("name"))

                        user = New LampUser(userId, DirectCast(permissionLevel, UserPermission), email, password, username, name)

                    Else
                        user = Nothing
                    End If

                    Return user
                End Using
            End Using

        Finally
            If shouldCloseAfter Then
                CloseDatabase()
            End If
        End Try
    End Function

    Public Function SelectUser(username As String, password As String) As LampUser
        Dim shouldCloseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "Select userId from Users 
                                          WHERE username=@username AND password=@password"
                sqlite_cmd.Parameters.AddWithValue("@username", username)
                sqlite_cmd.Parameters.AddWithValue("@password", password)

                Dim userId = sqlite_cmd.ExecuteScalar()
                If userId IsNot Nothing Then
                    Return SelectUser(DirectCast(userId, String))
                Else
                    Return Nothing
                End If
            End Using

        Finally
            If shouldCloseAfter Then
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
                sqlite_cmd.CommandText = "INSERT OR REPLACE INTO users
                    (UserId,permissionLevel, email, username, password, name)
                    VALUES
                    (@UserId, @permissionLevel, @email, @username, @password, @name);"


                sqlite_cmd.Parameters.AddWithValue("@UserId", user.UserId)
                sqlite_cmd.Parameters.AddWithValue("@permissionLevel", user.PermissionLevel)
                sqlite_cmd.Parameters.AddWithValue("@email", user.Email)
                sqlite_cmd.Parameters.AddWithValue("@username", user.Username)
                sqlite_cmd.Parameters.AddWithValue("@password", user.Password)
                sqlite_cmd.Parameters.AddWithValue("@name", user.Name)


                sqlite_cmd.ExecuteNonQuery()

            End Using


        Finally
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' removes a user from db
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function RemoveUser(userId As String) As Integer
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "DELETE from users WHERE userId = @userid"
                sqlite_cmd.Parameters.AddWithValue("@userid", userId)
                Dim rowsRemoved = sqlite_cmd.ExecuteNonQuery()

                Return rowsRemoved
            End Using
        Finally
            ' ensure connection is closed
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Function

    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    Public Function SelectJob(jobId As String) As LampJob
        Dim shouldCloseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "Select templateId, submitterId, approverId, approved, submitDate from Users 
                                          WHERE jobId = @jobId"
                sqlite_cmd.Parameters.AddWithValue("@jobId", jobId)

                Using sqlite_reader = sqlite_cmd.ExecuteReader()
                    Dim job As LampJob

                    If sqlite_reader.Read() Then
                        Dim templateId = sqlite_reader.GetString(sqlite_reader.GetOrdinal("templateId"))
                        Dim template = SelectTemplate(templateId)

                        Dim submitterId = sqlite_reader.GetString(sqlite_reader.GetOrdinal("submitterId"))
                        Dim submitter As LampUser = SelectUser(submitterId)


                        Dim approverId = sqlite_reader.GetString(sqlite_reader.GetOrdinal("approverId"))
                        Dim approved = sqlite_reader.GetString(sqlite_reader.GetOrdinal("approved"))
                        Dim submitDate = sqlite_reader.GetDateTime(sqlite_reader.GetOrdinal("submitDate"))

                        job = New LampJob(template, submitter)

                    Else
                        job = Nothing
                    End If

                    Return job
                End Using
            End Using

        Finally
            If shouldCloseAfter Then
                CloseDatabase()
            End If
        End Try
    End Function


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

                sqlite_cmd.CommandText = "INSERT OR REPLACE INTO jobs
                    (jobId, templateId, submitterId, approverId, approved, submitDate)
                    VALUES
                    (@jobId, @templateId, @submitterId, @approverId, @approved, DATETIME('now'));"


                sqlite_cmd.Parameters.AddWithValue("@jobId", job.JobId)
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


    Public Function RemoveJob(jobId As String) As Integer
        Dim closeDatabaseAfter = OpenDatabase()

        Try
            Using sqlite_cmd = GetCommand()
                sqlite_cmd.CommandText = "DELETE from jobs WHERE jobId = @jobId"
                sqlite_cmd.Parameters.AddWithValue("@jobId", jobId)
                Dim rowsRemoved = sqlite_cmd.ExecuteNonQuery()

                Return rowsRemoved
            End Using
        Finally
            ' ensure connection is closed
            If closeDatabaseAfter Then
                CloseDatabase()
            End If
        End Try
    End Function


    ''' <summary>
    ''' Fills database with dxf files located in project root/templates
    ''' The default files are stored in ExampleDxfFiles
    ''' </summary>
    Public Shared Sub FillDebugDatabase(Optional fileName As String = "templateDB.sqlite")
#If Not DEBUG Then
        Throw New Exception("do not use debug db in Release Mode")
#End If

        Dim db As New TemplateDatabase(fileName)

        Dim ExampleSpfFiles() As String = {"1.spf", "2.spf", "3.spf", "4.spf", "5.spf", "6.spf", "7.spf", "8.spf", "9.spf"}

        ' add new templates 
        For Each spfName As String In ExampleSpfFiles
            Dim fp = IO.Path.GetFullPath(IO.Path.Combine("../", "../", "../", "templates", "spf", spfName))
            Dim template = LampTemplate.FromFile(fp)
            db.AddTemplate(template)
        Next

        ' add useres
        Dim max As New LampUser(GetNewGuid(), UserPermission.Admin, "maxywartonyjonesy@gmail.com", "waxy", "memes", "steve by birth!")
        db.AddUser(max)

        Dim shovel = New LampUser(GetNewGuid(), UserPermission.Admin, "qshoveyl@gmail.com", "shourov", "shovel101", "Knot Jack")
        db.AddUser(shovel)

        Dim jack = New LampUser(GetNewGuid(), UserPermission.Admin, "jackywathyy123@gmail.com", "moji", "snack time", "shovel tool")
        db.AddUser(jack)


        Dim templates = db.GetAllTemplate

        ' add jobs
        Dim job As New LampJob(templates(0), max)
        db.AddJob(job)

        job = New LampJob(templates(1), shovel)
        db.AddJob(job)
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


''' <summary>
''' Ensures the the db is open when needed
''' and closed when all are used
''' </summary>
Public Class SqliteConnectionWrapper
    Implements IDisposable

    ''' <summary>
    ''' how many items are using the db right now
    ''' dont tocuh without first locking connection
    ''' </summary>
    ''' <returns></returns>
    Private Property RefCount As Integer = 0

    Public ReadOnly Property Transaction As SQLiteTransaction

    Public ReadOnly Property Opened As Boolean
        Get
            SyncLock Connection
                Return RefCount > 0
            End SyncLock
        End Get
    End Property

    Public Sub DecrementRef()
        SyncLock Connection

            RefCount -= 1
#If DEBUG Then
            If RefCount < 0 Then
                Throw New Exception("refcount < 0?")
            End If
#End If
            If RefCount = 0 Then
                Connection.Close()
            End If

        End SyncLock
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        DecrementRef()
    End Sub



    ''' <summary>
    ''' Connection to the database
    '''
    ''' </summary>
    ''' <returns></returns>
    Public Property Connection As SQLiteConnection



    Public Function OpenConnection() As SqliteConnectionWrapper
        SyncLock Connection
            If RefCount = 0 Then
                Connection.Open()
            End If
            RefCount += 1
        End SyncLock
        Return Me
    End Function



    Sub New(connection As SQLiteConnection)
        Me.Connection = connection
    End Sub

    Sub New(connectionString As String)
        Me.Connection = New SQLiteConnection(connectionString)
    End Sub

    Public Function GetCommand() As SQLiteCommand
        If Opened = False Then
            Throw New Exception("Connection Not opened, run openConnection()")
        End If
        Return Connection.CreateCommand
    End Function
End Class
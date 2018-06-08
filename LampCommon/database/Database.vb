﻿Imports System.IO
Imports System.Text
Imports System.Collections.ObjectModel
Imports System.Data.SQLite
Imports System.Drawing
Imports LampCommon.DatabaseHelper
Imports LampCommon
Imports System.Threading

''' <summary>
''' Template database
''' Split into multiple parts
''' </summary>
Partial Public Class TemplateDatabase
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
    ''' Transaction object. Since only  1 transaction per connection, it must be locked with
    ''' Using trans = Transaction.LockTransaction() 
    '''     ...
    ''' End Using
    ''' </summary>
    ''' <returns></returns>
    Public Property Transaction As SqliteTransactionWrapper

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
    Public Sub RemoveTables()
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
End Class


' Manipulate templates in the db
Partial Public Class TemplateDatabase
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
        Dim dxf As LampDxfDocument = Nothing
        Using conn = Connection.OpenConnection, command = Connection.GetCommand
            command.CommandText = "Select DXF from dxf WHERE guid=@guid"
            command.Parameters.AddWithValue("@guid", guid)
            Dim dxfString = DirectCast(Await command.ExecuteScalarAsync(), String)
            If dxfString IsNot Nothing Then
                dxf = LampDxfDocument.FromString(dxfString)
            End If
        End Using
        Return dxf
    End Function

    ''' <summary>
    ''' Adds a dxf to the db. Uses the guid in a template
    ''' internal use only
    ''' </summary>
    ''' <param name="template"></param>
    ''' <returns></returns>
    Private Function SetDxf(template As LampTemplate) As Boolean
        Return SetDxf(template.GUID, template.BaseDrawing)
    End Function

    ''' <summary>
    ''' Adds dxf to the db - internal
    ''' </summary>
    Private Function SetDxf(guid As String, dxf As LampDxfDocument) As Boolean
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
    ''' adds a dxf async - internal
    ''' </summary>
    ''' <param name="template"></param>
    ''' <returns></returns>
    Private Async Function SetDxfAsync(template As LampTemplate) As Task(Of Boolean)
        Return Await SetDxfAsync(template.GUID, template.BaseDrawing)
    End Function

    ''' <summary>
    ''' adds a dxf async - internal
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="dxf"></param>
    ''' <returns></returns>
    Private Async Function SetDxfAsync(guid As String, dxf As LampDxfDocument) As Task(Of Boolean)
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
    Private Function RemoveDxf(guid As String) As Boolean
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
    Private Async Function RemoveDxfAsync(guid As String) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "DELETE from dxf WHERE GUID = @guid"
            command.Parameters.AddWithValue("@guid", guid)

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync())
        End Using
    End Function

    ''' <summary>
    ''' gets a template's metadata
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectTemplateMetadata(guid As String) As LampTemplateMetadata
        Dim metadata As LampTemplateMetadata = Nothing
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "Select 
                                    name, shortDescription, longDescription, material, 
                                    length, height, materialthickness, 
                                    creatorId, approverId, submitDate, complete 

                                    FROM template WHERE guid = @guid"
            command.Parameters.AddWithValue("@guid", guid)
            Using reader = command.ExecuteReader()
                ' read only 1 row off the database
                If reader.Read() Then
                    metadata = New LampTemplateMetadata()
                    metadata.GUID = guid

                    metadata.Name = reader.GetString(reader.GetOrdinal("name"))
                    metadata.ShortDescription = reader.GetString(reader.GetOrdinal("ShortDescription"))
                    metadata.LongDescription = reader.GetString(reader.GetOrdinal("LongDescription"))
                    metadata.Material = reader.GetString(reader.GetOrdinal("material"))
                    metadata.Length = reader.GetDouble(reader.GetOrdinal("length"))
                    metadata.Height = reader.GetDouble(reader.GetOrdinal("height"))
                    metadata.MaterialThickness = reader.GetDouble(reader.GetOrdinal("MaterialThickness"))

                    If Not reader.IsDBNull(reader.GetOrdinal("CreatorId")) Then
                        metadata.CreatorProfile = SelectUser(reader.GetString(reader.GetOrdinal("CreatorId"))).ToProfile
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("ApproverId")) Then
                        metadata.CreatorProfile = SelectUser(reader.GetString(reader.GetOrdinal("ApproverId"))).ToProfile
                    End If

                    metadata.SubmitDate = reader.GetDateTime(reader.GetOrdinal("submitDate"))
                    metadata.IsComplete = reader.GetBoolean(reader.GetOrdinal("complete"))

                End If
            End Using
        End Using
        Return metadata
    End Function

    ''' <summary>
    ''' gets a template's metadata
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Async Function SelectTemplateMetadataAsync(guid As String) As Task(Of LampTemplateMetadata)
        Dim metadata As LampTemplateMetadata = Nothing
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "Select 
                                    name, shortDescription, longDescription, material, 
                                    length, height, materialthickness, 
                                    creatorId, approverId, submitDate, complete 

                                    FROM template WHERE guid = @guid"
            command.Parameters.AddWithValue("@guid", guid)
            Using reader = Await command.ExecuteReaderAsync()
                ' read only 1 row off the database
                If Await reader.ReadAsync() Then
                    metadata = New LampTemplateMetadata()
                    metadata.GUID = guid

                    metadata.Name = reader.GetString(reader.GetOrdinal("name"))
                    metadata.ShortDescription = reader.GetString(reader.GetOrdinal("ShortDescription"))
                    metadata.LongDescription = reader.GetString(reader.GetOrdinal("LongDescription"))
                    metadata.Material = reader.GetString(reader.GetOrdinal("material"))
                    metadata.Length = reader.GetDouble(reader.GetOrdinal("length"))
                    metadata.Height = reader.GetDouble(reader.GetOrdinal("height"))
                    metadata.MaterialThickness = reader.GetDouble(reader.GetOrdinal("MaterialThickness"))

                    If Not reader.IsDBNull(reader.GetOrdinal("CreatorId")) Then
                        metadata.CreatorProfile = (Await SelectUserAsync(reader.GetString(reader.GetOrdinal("CreatorId")))).ToProfile
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("ApproverId")) Then
                        metadata.CreatorProfile = (Await SelectUserAsync(reader.GetString(reader.GetOrdinal("ApproverId")))).ToProfile
                    End If

                    metadata.SubmitDate = reader.GetDateTime(reader.GetOrdinal("submitDate"))
                    metadata.IsComplete = reader.GetBoolean(reader.GetOrdinal("complete"))

                End If
            End Using
        End Using
        Return metadata
    End Function

    ''' <summary>
    ''' Adds template data
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="creatorId"></param>
    ''' <param name="approverId"></param>
    ''' <returns></returns>
    Private Function SetTemplateData(template As LampTemplateMetadata, creatorId As String, approverId As String) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "INSERT OR REPLACE INTO template
                    (guid, name, shortDescription, longDescription, material,
                    length, Height, materialthickness, 
                    creatorID, approverId, submitdate, complete)
                    VALUES
                    (@guid, @name, @shortDescription, @longDescription, @material, 
                    @length, @height, @materialthickness, 
                    @creatorId, @approverId, DATETIME('now'), @complete);"

            command.Parameters.AddWithValue("@guid", template.GUID)

            command.Parameters.AddWithValue("@name", template.Name)
            command.Parameters.AddWithValue("@shortDescription", template.ShortDescription)
            command.Parameters.AddWithValue("@longDescription", template.LongDescription)
            command.Parameters.AddWithValue("@material", template.Material)

            command.Parameters.AddWithValue("@length", template.Length)
            command.Parameters.AddWithValue("@height", template.Height)
            command.Parameters.AddWithValue("@materialthickness", template.MaterialThickness)

            command.Parameters.AddWithValue("@creatorId", creatorId)
            command.Parameters.AddWithValue("@approverId", approverId)
            command.Parameters.AddWithValue("@complete", template.IsComplete)

            Return Convert.ToBoolean(command.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' adds template data
    ''' </summary>
    ''' <param name="template"></param>
    ''' <param name="creatorId"></param>
    ''' <param name="approverId"></param>
    ''' <returns></returns>
    Private Async Function SetTemplateDataAsync(template As LampTemplateMetadata, creatorId As String, approverId As String) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "INSERT OR REPLACE INTO template
                    (guid, name, shortDescription, longDescription, material,
                    length, Height, materialthickness, 
                    creatorID, approverId, submitdate, complete)
                    VALUES
                    (@guid, @name, @shortDescription, @longDescription, @material, 
                    @length, @height, @materialthickness, 
                    @creatorId, @approverId, DATETIME('now'), @complete);"

            command.Parameters.AddWithValue("@guid", template.GUID)

            command.Parameters.AddWithValue("@name", template.Name)
            command.Parameters.AddWithValue("@shortDescription", template.ShortDescription)
            command.Parameters.AddWithValue("@longDescription", template.LongDescription)
            command.Parameters.AddWithValue("@material", template.Material)

            command.Parameters.AddWithValue("@length", template.Length)
            command.Parameters.AddWithValue("@height", template.Height)
            command.Parameters.AddWithValue("@materialthickness", template.MaterialThickness)

            command.Parameters.AddWithValue("@creatorId", creatorId)
            command.Parameters.AddWithValue("@approverId", approverId)
            command.Parameters.AddWithValue("@complete", template.IsComplete)

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync())
        End Using
    End Function

    ''' <summary>
    ''' Retrieves the images from the database
    ''' given guid of the template, returns the images associated with it, or nothing if none was found
    ''' returns a list of <see cref="LampTemplate.MaxImages"/> size.
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectImages(guid As String) As List(Of Image)
        Dim images As New List(Of Image)

        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "Select image1, image2, image3 FROM images WHERE guid = @guid"
            command.Parameters.AddWithValue("@guid", guid)

            Using sqlite_reader = command.ExecuteReader()
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
                Else
                    For i = 1 To LampTemplate.MaxImages
                        images.Add(Nothing)
                    Next
                End If
            End Using
        End Using
        Return images
    End Function

    ''' <summary>
    ''' Retrieves the images from the database
    ''' given guid of the template, returns the images associated with it, or nothing if none was found
    ''' returns a list of <see cref="LampTemplate.MaxImages"/> size.
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Async Function SelectImagesAsync(guid As String) As Task(Of List(Of Image))
        Dim images As New List(Of Image)

        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "Select image1, image2, image3 FROM images WHERE guid = @guid"
            command.Parameters.AddWithValue("@guid", guid)

            Using reader = Await command.ExecuteReaderAsync()
                If Await reader.ReadAsync() Then
                    For i = 1 To LampTemplate.MaxImages
                        Dim columnNumber = reader.GetOrdinal(String.Format("image{0}", i))

                        If Not reader.IsDBNull(columnNumber) Then
                            Dim readImage As Image = BinaryToImage(DirectCast(reader.GetValue(columnNumber), Byte()))
                            images.Add(readImage)
                        Else
                            images.Add(Nothing)
                        End If
                    Next
                Else
                    For i = 1 To LampTemplate.MaxImages
                        images.Add(Nothing)
                    Next
                End If
            End Using
        End Using
        Return images
    End Function

    ''' <summary>
    ''' Stores up to 3 preview images in the database
    ''' images are stored as binary blobs (byte arrays or byte() in vb.net)
    ''' this function takes a list(of Image), converts them into binary and chucks them in the database
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="images"></param>
    Private Function SetImages(Guid As String, images As IEnumerable(Of Image)) As Boolean
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand()
            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO images
                    (Guid, image1, image2, image3)
                    VALUES
                    (@guid, @image1, @image2, @image3);"

            sqlite_cmd.Parameters.AddWithValue("@guid", Guid)

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

            Return Convert.ToBoolean(sqlite_cmd.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' Stores up to 3 preview images in the database
    ''' images are stored as binary blobs (byte arrays or byte() in vb.net)
    ''' this function takes a list(of Image), converts them into binary and chucks them in the database
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="images"></param>
    Private Async Function SetImagesAsync(guid As String, images As IEnumerable(Of Image)) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand()
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

            Return Convert.ToBoolean(Await sqlite_cmd.ExecuteNonQueryAsync())
        End Using
    End Function

    ''' <summary>
    ''' Removes images associated with the guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns>True=Removed image, False=None removed</returns>
    Private Function RemoveImages(guid As String) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "DELETE from images WHERE GUID = @guid"
            command.Parameters.AddWithValue("@guid", guid)
            Return command.ExecuteNonQuery()
        End Using
    End Function

    ''' <summary>
    ''' Removes images associated with the guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns>True=Removed image, False=None removed</returns>
    Private Async Function RemoveImagesAsync(guid As String) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "DELETE from images WHERE GUID = @guid"
            command.Parameters.AddWithValue("@guid", guid)
            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync())
        End Using
    End Function

    ''' <summary>
    ''' Gets all tags that belong to a template's guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectTags(guid As String) As List(Of String)
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand()
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
    End Function

    ''' <summary>
    ''' Gets all tags that belong to a template's guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Async Function SelectTagsAsync(guid As String) As Task(Of List(Of String))
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "SELECT tagName FROM tags
                                      WHERE guid=@guid;"

            command.Parameters.AddWithValue("@guid", guid)

            Dim tags As New List(Of String)
            Dim reader = Await command.ExecuteReaderAsync()

            While Await reader.ReadAsync()
                tags.Add(reader.GetString(reader.GetOrdinal("tagName")))
            End While

            Return tags
        End Using
    End Function

    ''' <summary>
    ''' adds tags
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="tags"></param>
    Private Function SetTags(guid As String, tags As IEnumerable(Of String)) As Integer
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "INSERT OR REPLACE INTO tags
                    (Guid, tagName)
                    VALUES
                    (@guid, @tagName);"

            Dim insertedRows = 0
            command.Parameters.AddWithValue("@guid", guid)
            For Each tag In tags
                command.Parameters.AddWithValue("@tagName", tag)

                insertedRows += command.ExecuteNonQuery()
            Next
            Return insertedRows
        End Using
    End Function

    ''' <summary>
    ''' adds tags
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="tags"></param>
    Private Async Function SetTagsAsync(guid As String, tags As IEnumerable(Of String)) As Task(Of Integer)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "INSERT OR REPLACE INTO tags
                    (Guid, tagName)
                    VALUES
                    (@guid, @tagName);"

            Dim insertedRows As Integer = 0
            command.Parameters.AddWithValue("@guid", guid)
            For Each tag In tags
                command.Parameters.AddWithValue("@tagName", tag)

                insertedRows += Await command.ExecuteNonQueryAsync()
            Next
            Return insertedRows
        End Using
    End Function

    ''' <summary>
    ''' Removes all tags associated with the guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Private Function RemoveTags(guid As String) As Integer
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand()
            sqlite_cmd.CommandText = "DELETE from tags WHERE guid = @guid"
            sqlite_cmd.Parameters.AddWithValue("@guid", guid)
            Return sqlite_cmd.ExecuteNonQuery()
        End Using
    End Function

    ''' <summary>
    ''' Removes all tags associated with the guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Private Async Function RemoveTagsAsync(guid As String) As Task(Of Integer)
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand()
            sqlite_cmd.CommandText = "DELETE from tags WHERE guid = @guid"
            sqlite_cmd.Parameters.AddWithValue("@guid", guid)
            Return Await sqlite_cmd.ExecuteNonQueryAsync()
        End Using
    End Function

    ''' <summary>
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectTemplate(guid As String) As LampTemplate
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim template As LampTemplate = SelectTemplateMetadata(guid).ToLampTemplate

            If template IsNot Nothing Then
                ' dxf
                Dim dxf As LampDxfDocument = SelectDxf(guid)
                If dxf IsNot Nothing Then
                    template.BaseDrawing = dxf
                End If

                ' images
                Dim images = SelectImages(guid)
                If images IsNot Nothing Then
                    For i = 0 To LampTemplate.MaxImages - 1
                        template.PreviewImages(i) = images(i)
                    Next
                End If

                ' get all the tags from the db as well
                For Each tag In SelectTags(guid)
                    template.Tags.Add(tag)
                Next
            End If
            Return template
        End Using
    End Function

    ''' <summary>
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Async Function SelectTemplateAsync(guid As String) As Task(Of LampTemplate)
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim template = (Await SelectTemplateMetadataAsync(guid)).ToLampTemplate

            If template IsNot Nothing Then
                Dim dxfTask = SelectDxfAsync(guid)
                Dim imageTask = SelectImagesAsync(guid)
                Dim tagTask = SelectTagsAsync(guid)

                Await Task.WhenAll(dxfTask, imageTask, tagTask)

                If dxfTask.Result IsNot Nothing Then
                    template.BaseDrawing = dxfTask.Result
                End If

                If imageTask.Result IsNot Nothing Then
                    For i = 0 To LampTemplate.MaxImages - 1
                        template.PreviewImages(i) = imageTask.Result(i)
                    Next
                End If

                For Each tag In tagTask.Result
                    template.Tags.Add(tag)
                Next
            End If
            Return template
        End Using

    End Function

    ''' <summary>
    ''' Adds a template to the database
    ''' </summary>
    ''' <param name="template"></param>
    Public Function SetTemplate(template As LampTemplate, Optional creatorId As String = Nothing, Optional approverId As String = Nothing) As Boolean
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand()
            ' todo use transaction to make sure it updates everything

            If SetTemplateData(template, creatorId, approverId) Then
                If SetDxf(template.GUID, template.BaseDrawing) Then

                    ' check that there is at least 1 image
                    If template.PreviewImages.HasNotNothing() Then
                        SetImages(template.GUID, template.PreviewImages)
                    End If

                    If template.Tags.Count > 0 Then
                        SetTags(template.GUID, template.Tags)
                    End If

                    Return True
                End If

                Throw New Exception("warning - database inconsisint as template data was inserted, but not dxf data.")
            End If

            ' failed to insert main data, probably
            Return False
        End Using
    End Function

    ''' <summary>
    ''' Adds a template to the database
    ''' </summary>
    ''' <param name="template"></param>
    Public Async Function SetTemplateAsync(template As LampTemplate, Optional creatorId As String = Nothing, Optional approverId As String = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand()
            ' todo use transaction to make sure it updates everything

            If Await SetTemplateDataAsync(template, creatorId, approverId) Then
                If Await SetDxfAsync(template.GUID, template.BaseDrawing) Then

                    ' check that there is at least 1 image
                    If template.PreviewImages.HasNotNothing() Then
                        Await SetImagesAsync(template.GUID, template.PreviewImages)
                    End If

                    If template.Tags.Count > 0 Then
                        Await SetTagsAsync(template.GUID, template.Tags)
                    End If

                    Return True
                End If

                Throw New Exception("warning - database inconsisint as template data was inserted, but not dxf data.")
            End If

            ' failed to insert main data, probably
            Return False
        End Using
    End Function

    ''' <summary>
    ''' Removes from database based on guid
    ''' Also removes images by default, rmImages can be set to false to not
    ''' </summary>
    ''' <param name="guid">string guid</param>
    ''' <returns>True=Removed, False=None found</returns>
    Public Function RemoveTemplate(guid As String) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            ' gotta remove these first before the guid in the templates table is gone
            RemoveDxf(guid)
            RemoveImages(guid)
            RemoveTags(guid)

            command.CommandText = "DELETE from template WHERE GUID = @guid"
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
    Public Async Function RemoveTemplateAsync(guid As String) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            ' gotta remove these first before the guid in the templates table is gone
            RemoveDxf(guid)
            RemoveImages(guid)
            RemoveTags(guid)

            command.CommandText = "DELETE from template WHERE GUID = @guid"
            command.Parameters.AddWithValue("@guid", guid)

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync())
        End Using
    End Function
End Class


' implementation of users
Partial Public Class TemplateDatabase
    ''' <summary>
    ''' gets a user, which has all the info on users
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function SelectUser(userId As String) As LampUser
        Dim user As LampUser = Nothing

        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "Select email, username, password, permissionLevel, name from Users 
                                          WHERE userId = @guid"
            command.Parameters.AddWithValue("@guid", userId)

            Using reader = command.ExecuteReader()
                If reader.Read() Then
                    Dim email = reader.GetString(reader.GetOrdinal("email"))
                    Dim username = reader.GetString(reader.GetOrdinal("username"))
                    Dim password = reader.GetString(reader.GetOrdinal("password"))
                    Dim permissionLevel = reader.GetInt32(reader.GetOrdinal("permissionLevel"))
                    Dim name = reader.GetString(reader.GetOrdinal("name"))

                    user = New LampUser(userId, permissionLevel, email, password, username, name)
                End If
            End Using
        End Using
        Return user
    End Function

    ''' <summary>
    ''' gets a user, which has all the info on users
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Async Function SelectUserAsync(userId As String) As Task(Of LampUser)
        Dim user As LampUser = Nothing

        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "Select email, username, password, permissionLevel, name from Users 
                                          WHERE userId = @guid"
            command.Parameters.AddWithValue("@guid", userId)

            Using reader = Await command.ExecuteReaderAsync()
                If Await reader.ReadAsync() Then
                    Dim email = reader.GetString(reader.GetOrdinal("email"))
                    Dim username = reader.GetString(reader.GetOrdinal("username"))
                    Dim password = reader.GetString(reader.GetOrdinal("password"))
                    Dim permissionLevel = reader.GetInt32(reader.GetOrdinal("permissionLevel"))
                    Dim name = reader.GetString(reader.GetOrdinal("name"))

                    user = New LampUser(userId, permissionLevel, email, password, username, name)
                End If
            End Using
        End Using
        Return user
    End Function

    ''' <summary>
    ''' Gets the user object from a username/password pair
    ''' </summary>
    ''' <param name="username"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    Public Function SelectUser(username As String, password As String) As LampUser
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "Select userId from Users 
                                          WHERE username=@username AND password=@password"
            command.Parameters.AddWithValue("@username", username)
            command.Parameters.AddWithValue("@password", password)

            Dim userId = command.ExecuteScalar()
            If userId IsNot Nothing Then
                Return SelectUser(DirectCast(userId, String))
            Else
                Return Nothing
            End If
        End Using
    End Function

    ''' <summary>
    ''' Gets the user object from a username/password pair
    ''' </summary>
    ''' <param name="username"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    Public Async Function SelectUserAsync(username As String, password As String) As Task(Of LampUser)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "Select userId from Users 
                                          WHERE username=@username AND password=@password"
            command.Parameters.AddWithValue("@username", username)
            command.Parameters.AddWithValue("@password", password)

            Dim userId = Await command.ExecuteScalarAsync()
            If userId IsNot Nothing Then
                Return SelectUser(DirectCast(userId, String))
            Else
                Return Nothing
            End If
        End Using
    End Function

    ''' <summary>
    ''' Adds a user to the database
    ''' </summary>
    ''' <param name="user"></param>
    Public Function SetUser(user As LampUser) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "INSERT OR REPLACE INTO users
                    (UserId,permissionLevel, email, username, password, name)
                    VALUES
                    (@UserId, @permissionLevel, @email, @username, @password, @name);"

            command.Parameters.AddWithValue("@UserId", user.UserId)
            command.Parameters.AddWithValue("@permissionLevel", user.PermissionLevel)
            command.Parameters.AddWithValue("@email", user.Email)
            command.Parameters.AddWithValue("@username", user.Username)
            command.Parameters.AddWithValue("@password", user.Password)
            command.Parameters.AddWithValue("@name", user.Name)


            Return Convert.ToBoolean(command.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' Adds a user to the database
    ''' </summary>
    ''' <param name="user"></param>
    Public Async Function SetUserAsync(user As LampUser) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "INSERT OR REPLACE INTO users
                    (UserId,permissionLevel, email, username, password, name)
                    VALUES
                    (@UserId, @permissionLevel, @email, @username, @password, @name);"

            command.Parameters.AddWithValue("@UserId", user.UserId)
            command.Parameters.AddWithValue("@permissionLevel", user.PermissionLevel)
            command.Parameters.AddWithValue("@email", user.Email)
            command.Parameters.AddWithValue("@username", user.Username)
            command.Parameters.AddWithValue("@password", user.Password)
            command.Parameters.AddWithValue("@name", user.Name)


            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync())
        End Using
    End Function

    ''' <summary>
    ''' removes a user from db
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function RemoveUser(userId As String) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "DELETE from users WHERE userId = @userid"
            command.Parameters.AddWithValue("@userid", userId)
            Return Convert.ToBoolean(command.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' removes a user from db
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Async Function RemoveUserAsync(userId As String) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "DELETE from users WHERE userId = @userid"
            command.Parameters.AddWithValue("@userid", userId)
            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync())
        End Using
    End Function

    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    Public Function SelectJob(jobId As String) As LampJob
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "Select templateId, submitterId, approverId, approved, submitDate from Users 
                                          WHERE jobId = @jobId"
            command.Parameters.AddWithValue("@jobId", jobId)

            Using reader = command.ExecuteReader()
                Dim job As LampJob = Nothing
                If reader.Read() Then
                    Dim templateId = reader.GetString(reader.GetOrdinal("templateId"))
                    Dim template = SelectTemplate(templateId)

                    Dim submitterId = reader.GetString(reader.GetOrdinal("submitterId"))
                    Dim approverId = reader.GetString(reader.GetOrdinal("approverId"))

                    Dim submitter As LampUser = Nothing
                    If submitterId IsNot Nothing Then
                        submitter = SelectUser(submitterId)
                    End If

                    Dim approver As LampUser = Nothing
                    If approverId IsNot Nothing Then
                        approver = SelectUser(approverId)
                    End If


                    Dim approved = reader.GetString(reader.GetOrdinal("approved"))
                    Dim submitDate = reader.GetDateTime(reader.GetOrdinal("submitDate"))

                    job = New LampJob(template, submitter, approver, approved, submitDate)
                End If

                Return job
            End Using
        End Using
    End Function

    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    Public Async Function SelectJobAsync(jobId As String) As Task(Of LampJob)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "Select templateId, submitterId, approverId, approved, submitDate from Users 
                                          WHERE jobId = @jobId"
            command.Parameters.AddWithValue("@jobId", jobId)

            Using reader = Await command.ExecuteReaderAsync()
                Dim job As LampJob = Nothing
                If Await reader.ReadAsync() Then
                    Dim templateId = reader.GetString(reader.GetOrdinal("templateId"))
                    Dim template = SelectTemplate(templateId)

                    Dim submitterId = reader.GetString(reader.GetOrdinal("submitterId"))
                    Dim approverId = reader.GetString(reader.GetOrdinal("approverId"))

                    Dim submitter As LampUser = Nothing
                    If submitterId IsNot Nothing Then
                        submitter = Await SelectUserAsync(submitterId)
                    End If

                    Dim approver As LampUser = Nothing
                    If approverId IsNot Nothing Then
                        approver = Await SelectUserAsync(approverId)
                    End If


                    Dim approved = reader.GetString(reader.GetOrdinal("approved"))
                    Dim submitDate = reader.GetDateTime(reader.GetOrdinal("submitDate"))

                    job = New LampJob(template, submitter, approver, approved, submitDate)
                End If

                Return job
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Adds a job to the database
    ''' </summary>
    Public Function SetJob(job As LampJob) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            ' check if the template is already in the database
            ' todo use equality to check if the two templates are equal
            If SelectTemplate(job.Template.GUID) IsNot Nothing Then
                SetTemplate(job.Template)
            End If

            command.CommandText = "INSERT OR REPLACE INTO jobs
                    (jobId, templateId, submitterId, approverId, approved, submitDate)
                    VALUES
                    (@jobId, @templateId, @submitterId, @approverId, @approved, DATETIME('now'));"


            command.Parameters.AddWithValue("@jobId", job.JobId)
            command.Parameters.AddWithValue("@templateId", job.Template.GUID)
            command.Parameters.AddWithValue("@submitterId", job.SubmitId)
            command.Parameters.AddWithValue("@approverId", job.ApproverId)
            command.Parameters.AddWithValue("@approved", job.Approved)

            Return Convert.ToBoolean(command.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' Adds a job to the database
    ''' </summary>
    Public Async Function SetJobAsync(job As LampJob) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            ' check if the template is already in the database
            ' todo use equality to check if the two templates are equal
            If SelectTemplate(job.Template.GUID) IsNot Nothing Then
                Await SetTemplateAsync(job.Template)
            End If

            command.CommandText = "INSERT OR REPLACE INTO jobs
                    (jobId, templateId, submitterId, approverId, approved, submitDate)
                    VALUES
                    (@jobId, @templateId, @submitterId, @approverId, @approved, DATETIME('now'));"


            command.Parameters.AddWithValue("@jobId", job.JobId)
            command.Parameters.AddWithValue("@templateId", job.Template.GUID)
            command.Parameters.AddWithValue("@submitterId", job.SubmitId)
            command.Parameters.AddWithValue("@approverId", job.ApproverId)
            command.Parameters.AddWithValue("@approved", job.Approved)

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync())
        End Using
    End Function

    ''' <summary>
    ''' Removes a job from the db
    ''' </summary>
    ''' <param name="jobId"></param>
    ''' <returns></returns>
    Public Function RemoveJob(jobId As String) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "DELETE from jobs WHERE jobId = @jobId"
            command.Parameters.AddWithValue("@jobId", jobId)
            Return command.ExecuteNonQuery()
        End Using
    End Function

    ''' <summary>
    ''' Removes a job from the db
    ''' </summary>
    ''' <param name="jobId"></param>
    ''' <returns></returns>
    Public Async Function RemoveJobAsync(jobId As String) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "DELETE from jobs WHERE jobId = @jobId"
            command.Parameters.AddWithValue("@jobId", jobId)
            Return Await command.ExecuteNonQueryAsync()
        End Using
    End Function
End Class

Public Class TemplateDatabase
    ''' <summary>
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <returns></returns>
    Public Function SelectTemplateWithTags(tags As List(Of String), Optional limit As Integer = 10, Optional offset As Integer = 0) As List(Of LampTemplate)
        ' If the databse is open already, dont close it

        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
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
            db.SetTemplate(template)
        Next

        ' add useres
        Dim max As New LampUser(GetNewGuid(), UserPermission.Admin, "maxywartonyjonesy@gmail.com", "waxy", "memes", "steve by birth!")
        db.SetUser(max)

        Dim shovel = New LampUser(GetNewGuid(), UserPermission.Admin, "qshoveyl@gmail.com", "shourov", "shovel101", "Knot Jack")
        db.SetUser(shovel)

        Dim jack = New LampUser(GetNewGuid(), UserPermission.Admin, "jackywathyy123@gmail.com", "moji", "snack time", "shovel tool")
        db.SetUser(jack)


        Dim templates = db.GetAllTemplate

        ' add jobs
        Dim job As New LampJob(templates(0), max)
        db.SetJob(job)

        job = New LampJob(templates(1), shovel)
        db.SetJob(job)
    End Sub


    ''' <summary>
    ''' Gets all templates in the database
    ''' </summary>
    ''' <returns></returns>
    Public Function GetAllTemplate() As List(Of LampTemplate)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            Dim templateList As New List(Of LampTemplate)
            command.CommandText = "Select guid FROM template"

            Using reader = command.ExecuteReader()
                While reader.Read()
                    ' read the data off this sqlite_reader
                    Dim template = SelectTemplate(reader.GetString(reader.GetOrdinal("guid")))

                    templateList.Add(template)
                End While
            End Using

            Return templateList
        End Using

    End Function

    ''' <summary>
    ''' Gets all templates asyncrohonously
    ''' </summary>
    ''' <returns></returns>
    Public Async Function GetAllTemplateAsync() As Task(Of List(Of LampTemplate))
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            Dim templateList As New List(Of LampTemplate)
            command.CommandText = "Select guid FROM template"

            Using reader = Await command.ExecuteReaderAsync()
                While Await reader.ReadAsync()
                    ' read the data off this sqlite_reader
                    Dim template = SelectTemplate(reader.GetString(reader.GetOrdinal("guid")))

                    templateList.Add(template)
                End While
            End Using

            Return templateList
        End Using
    End Function

    ''' <summary>
    ''' Sets or unsets the approver of a template
    ''' if a template has an approver of nothing, it is counted as not approved
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="approver"></param>
    ''' <returns>True if found, false if not updated (no template)</returns>
    Public Function SetApprover(guid As String, approver As String) As Boolean
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand()
            sqlite_cmd.CommandText = "UPDATE template SET approverId = @approverId"
            sqlite_cmd.Parameters.AddWithValue("@approverId", approver)

            Return Convert.ToBoolean(sqlite_cmd.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' Sets or unsets the approver of a template
    ''' if a template has an approver of nothing, it is counted as not approved
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="approver"></param>
    ''' <returns>True if found, false if not updated (no template)</returns>
    Public Async Function SetApproverAsync(guid As String, approver As String) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand()
            sqlite_cmd.CommandText = "UPDATE template SET approverId = @approverId"
            sqlite_cmd.Parameters.AddWithValue("@approverId", approver)

            Return Convert.ToBoolean(Await sqlite_cmd.ExecuteNonQueryAsync())
        End Using
    End Function



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
    ''' raw Connection to the database
    ''' </summary>
    ''' <returns></returns>
    Public Property Connection As SQLiteConnection

    ''' <summary>
    ''' how many items are using the db right now
    ''' dont tocuh without first locking connection
    ''' </summary>
    Private RefCount As Integer = 0

    ''' <summary>
    ''' Single transaction that connection has
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Transaction As SQLiteTransaction

    ''' <summary>
    ''' whether or not the db is opened / closed
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Opened As Boolean
        Get
            SyncLock Connection
                Return RefCount > 0
            End SyncLock
        End Get
    End Property

    ''' <summary>
    ''' decreases ref count / closes connection if needed
    ''' Do NOT call without at least 1 reference
    ''' </summary>
    Private Sub DecrementRef()
        SyncLock Connection
            If RefCount <= 0 Then
                Throw New Exception("refcount < 0?")
            End If

            RefCount -= 1
            If RefCount = 0 Then
                Connection.Close()
            End If

        End SyncLock
    End Sub

    ''' <summary>
    ''' Disposes.
    ''' If refcount reaches 0, it will close the db
    ''' </summary>
    Public Sub Dispose() Implements IDisposable.Dispose
        DecrementRef()
    End Sub

    ''' <summary>
    ''' Gets a reference to the sqliteconnection
    ''' </summary>
    ''' <returns></returns>
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

    Public Function GetCommand(Optional transaction As SqliteTransactionWrapper = Nothing) As SQLiteCommand
        If Opened = False Then
            Throw New Exception("Connection Not opened, run openConnection()")
        End If
        Return Connection.CreateCommand
    End Function
End Class

Public Class SqliteTransactionWrapper
    Implements IDisposable


    ''' <summary>
    ''' parent connection
    ''' </summary>
    ''' <returns></returns>
    Public Property Connection As SqliteConnectionWrapper

    ''' <summary>
    ''' how many items using this transaction
    ''' when reaches zero, it should clear
    ''' If recount = 0, it means transaction not being used by any objects
    ''' when the lock is acquired, the transaction is being used by refCount number of commands 
    ''' </summary>
    Private RefCount As Integer = 0

    ''' <summary>
    ''' ensures the transaction is only used in 1 by 1 transaction at a time
    ''' when the lock is acquired, the transaction is being used by refCount number of commands
    ''' </summary>
    Private lock As New SemaphoreSlim(1, 1)

    ''' <summary>
    ''' whether or not transaction was commited
    ''' if wrapper is completely disposed w/out being commited, will automatically rollback
    ''' MUST lock before changing
    ''' </summary>
    Private committed As Boolean = False

    Public Property Transaction As SQLiteTransaction

    Public Sub Dispose() Implements IDisposable.Dispose
        DecrementRef()
    End Sub

    Private Sub DecrementRef()
        SyncLock lock
            If RefCount <= 0 Then
                Throw New Exception("refcount <= 0?")
            End If

            RefCount -= 1
            If RefCount = 0 Then
                If Not committed Then
                    Transaction.Rollback()
                End If
                Transaction.Dispose() ' dispose the object
                Transaction = Nothing
            End If
        End SyncLock
    End Sub

    Public Function LockTransaction() As SqliteTransactionWrapper
        lock.Wait()
        IncrementRef()
        Return Me
    End Function

    Public Async Function LockTransactionAsync() As Task(Of SqliteTransactionWrapper)
        Await lock.WaitAsync()
        IncrementRef()
        Return Me
    End Function

    Public Sub IncrementRef()
        SyncLock lock
            If RefCount = 0 Then
                ' make a new transaction
                Transaction = Connection.Connection.BeginTransaction()
            End If
            RefCount += 1
        End SyncLock
    End Sub

    Public Sub Commit()
        SyncLock lock
            Transaction.Commit()
            committed = True
        End SyncLock
    End Sub

    Sub New(connect As SqliteConnectionWrapper)
        Me.Connection = connect
    End Sub
End Class


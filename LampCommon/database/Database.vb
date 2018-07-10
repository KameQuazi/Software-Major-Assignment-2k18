Imports System.Data.SQLite
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports LampCommon
Imports LampCommon.DatabaseHelper

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
        Transaction = New SqliteTransactionWrapper(Connection)
        ' recreate the database if not found
        CreateTables()
    End Sub

    ''' <summary>
    ''' Creates all the tables required, if tables not exist
    ''' Does not delete any data
    ''' </summary>
    Public Function CreateTables(Optional optTrans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection(), trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Transaction.LockTransaction), command = Connection.GetCommand(trans)
            Dim results As New List(Of Boolean)
            command.CommandText = "CREATE TABLE if not exists users (
                                  UserId Text Not Null,
                                  email Text Not Null,
                                  Username text Not NULL,

                                  PermissionLevel Integer Not Null,
                                  Password Text Not Null,
                                  Name Text Not Null,

                                  PRIMARY KEY (UserId, email, Username)
                                  ) WITHOUT rowId;
                                  CREATE INDEX if not exists user_username ON users(username);
                                  CREATE INDEX if not exists user_email ON users(email);
                                  
                        "
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

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
                                  ) WITHOUT rowId;"

            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))



            command.CommandText = "CREATE TABLE if not exists dxf (
                                  GUID Text PRIMARY KEY not null,
                                  DXF Text Not NULL,
                                  
                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  ) WITHOUT rowId;"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

            command.CommandText = "CREATE TABLE if not exists images (
                                  GUID Text PRIMARY KEY Not NULL, 
                                  image1 blob,
                                  image2 blob,
                                  image3 blob,

                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  );"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

            command.CommandText = "CREATE TABLE if not exists tags (
                                  GUID Text Not Null,
                                  TagName Text Not Null,
                        
                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  );
                                  CREATE INDEX if not exists tags_guid_tagname ON tags (guid, tagname);
                                  CREATE INDEX if not exists tags_tagname_guid ON tags (TagName, GUID);"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))




            command.CommandText = "CREATE TABLE if not exists jobs (
                                  jobId Text PRIMARY KEY Not Null,
                                  templateId Text Not NULL,
                                  submitterId Text Not NULL,
                                  approverId Text,
                                  approved integer Not Null default 0,
                                  submitDate Text Not null,

                                  FOREIGN KEY(submitterId) REFERENCES users(UserId),
                                  FOREIGN KEY(approverId) REFERENCES users(UserId)
                                  ) WITHOUT rowId;"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

            Dim allSuccess = results.All(Function(x) x = True)

            If optTrans Is Nothing Then
                ' no transaction given in arguments, commit now
                ' also, creating a table doesnt count as inserting a line, so just skip it for nawww
                trans.Commit()
            End If
            Return allSuccess
        End Using

    End Function

    ''' <summary>
    ''' Creates all the tables required, if tables not exist
    ''' Does not delete any data
    ''' </summary>
    Public Async Function CreateTablesAsync(Optional optTrans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection(), trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Await Transaction.LockTransactionAsync.ConfigureAwait(False)), command = Connection.GetCommand(trans)
            Dim tasks As New List(Of Task(Of Integer))
            command.CommandText = "CREATE TABLE if not exists users (
                                  UserId Text Not Null,
                                  email Text Not Null,
                                  Username text Not NULL,

                                  PermissionLevel Integer Not Null,
                                  Password Text Not Null,
                                  Name Text Not Null,

                                  PRIMARY KEY (UserId, email, Username)
                                  ) WITHOUT rowId;
                                  CREATE INDEX if not exists user_username ON users(username);
                                  CREATE INDEX if not exists user_email ON users(email);


                        "
            tasks.Add(command.ExecuteNonQueryAsync())

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
                                  ) WITHOUT rowId;"

            tasks.Add(command.ExecuteNonQueryAsync())



            command.CommandText = "CREATE TABLE if not exists dxf (
                                  GUID Text PRIMARY KEY not null,
                                  DXF Text Not NULL,
                                  
                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  ) WITHOUT rowId;"
            tasks.Add(command.ExecuteNonQueryAsync())

            command.CommandText = "CREATE TABLE if not exists images (
                                  GUID Text PRIMARY KEY Not NULL, 
                                  image1 blob,
                                  image2 blob,
                                  image3 blob,

                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  );"
            tasks.Add(command.ExecuteNonQueryAsync())

            command.CommandText = "CREATE TABLE if not exists tags (
                                  GUID Text Not Null,
                                  TagName Text Not Null,
                        
                                  FOREIGN KEY(GUID) REFERENCES template(GUID)
                                  );
                                  CREATE INDEX if not exists tags_guid_tagname ON tags (guid, tagname);
                                  CREATE INDEX if not exists tags_tagname_guid ON tags (TagName, GUID);"
            tasks.Add(command.ExecuteNonQueryAsync())




            command.CommandText = "CREATE TABLE if not exists jobs (
                                  jobId Text PRMARY KEY Not Null,
                                  templateId Text Not NULL,
                                  submitterId Text Not NULL,
                                  approverId Text,
                                  approved integer Not Null default 0,
                                  submitDate Text Not null,

                                  FOREIGN KEY(submitterId) REFERENCES users(UserId),
                                  FOREIGN KEY(approverId) REFERENCES users(UserId)
                                  ) WITHOUT rowId;"
            tasks.Add(command.ExecuteNonQueryAsync())

            Dim results = Await Task.WhenAll(tasks).ConfigureAwait(False)
            Dim allSuccess = results.All(Function(x) x > 0)
            ' check that each insertion inserted at least 1 line (1 table)

            If optTrans Is Nothing Then
                ' no transaction given in arguments, commit now
                trans.Commit()
            End If
            Return allSuccess
        End Using

    End Function

    ''' <summary>
    ''' Destroys all tables
    ''' </summary>
    Public Function RemoveTables(Optional optTrans As SqliteTransactionWrapper = Nothing) As Boolean
        ' If the databse is open already, dont close it
        Using conn = Connection.OpenConnection(), trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Transaction.LockTransaction), command = Connection.GetCommand(trans)
            Dim results As New List(Of Boolean)
            command.CommandText = "DROP TABLE If exists users;
                                   DROP INDEX if exists user_username;
                                   DROP INDEX if exists user_email;"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

            command.CommandText = "DROP TABLE If exists dxf"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

            command.CommandText = "DROP TABLE If exists images"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

            command.CommandText = "DROP TABLE If exists tags;
                                   DROP INDEX if exists tags_guid_tagname;
                                   DROP INDEX if exists tags_tagname_guid;"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

            command.CommandText = "DROP TABLE If exists jobs"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

            command.CommandText = "DROP TABLE If exists template"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

            Dim allSuccess = results.All(Function(x) x = True)
            ' check that all elements are = true

            If optTrans Is Nothing Then
                ' droping table doesnt count as a line in executeNonQuery
                trans.Commit()
            End If
            Return allSuccess
        End Using
    End Function

    Public Async Function RemoveTablesAsync(Optional optTrans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        ' If the databse is open already, dont close it
        Using conn = Connection.OpenConnection(), trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Await Transaction.LockTransactionAsync.ConfigureAwait(False)), command = Connection.GetCommand(trans)
            Dim tasks As New List(Of Task(Of Integer))

            command.CommandText = "DROP TABLE If exists users;
                                   DROP INDEX if exists user_username;
                                   DROP INDEX if exists user_email;"

            tasks.Add(command.ExecuteNonQueryAsync())

            command.CommandText = "DROP TABLE If exists dxf"
            tasks.Add(command.ExecuteNonQueryAsync())

            command.CommandText = "DROP TABLE If exists images"
            tasks.Add(command.ExecuteNonQueryAsync())

            command.CommandText = "DROP TABLE If exists tags;
                                   DROP INDEX if exists tags_guid_tagname;
                                   DROP INDEX if exists tags_tagname_guid;"

            tasks.Add(command.ExecuteNonQueryAsync())

            command.CommandText = "DROP TABLE If exists jobs"
            tasks.Add(command.ExecuteNonQueryAsync())

            command.CommandText = "DROP TABLE If exists template"
            tasks.Add(command.ExecuteNonQueryAsync())

            Dim results = Await Task.WhenAll(tasks).ConfigureAwait(False)
            Dim allSuccess = results.All(Function(x) x > 0)
            ' check that each insertion inserted at least 1 line (1 table)

            If optTrans Is Nothing Then
                ' no transaction given in arguments, commit now
                trans.Commit()
            End If
            Return allSuccess
        End Using
    End Function

    ''' <summary>
    ''' Resets the database, should ONLY be used for debug
    ''' </summary>
    Public Function ResetDebug() As Boolean
        Me.RemoveTables()
        Me.CreateTables()
        Me.FillDebugDatabase()
        Return True
    End Function

    Public Function DeleteDebug() As Boolean
        Me.RemoveTables()
        Me.CreateTables()
        Return True
    End Function

    ''' <summary>
    ''' Resets the database, should ONLY be used for debug
    ''' </summary>
    Public Async Function ResetDebugAsync() As Task(Of Boolean)
        Await RemoveTablesAsync().ConfigureAwait(False)
        Await CreateTablesAsync().ConfigureAwait(False)
        FillDebugDatabase()
        Return True
    End Function


End Class


' Manipulate templates in the db
Partial Public Class TemplateDatabase
    ''' <summary>
    ''' Gets a dxf. Returns nothing if not found
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectDxf(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As LampDxfDocument
        Dim dxf As LampDxfDocument = Nothing
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
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
    Public Async Function SelectDxfAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of LampDxfDocument)
        Dim dxf As LampDxfDocument = Nothing
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select DXF from dxf WHERE guid=@guid"
            command.Parameters.AddWithValue("@guid", guid)
            Dim dxfString = DirectCast(Await command.ExecuteScalarAsync().ConfigureAwait(False), String)
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
    Private Function SetDxf(template As LampTemplate, Optional trans As SqliteTransactionWrapper = Nothing) As Boolean
        Return SetDxf(template.GUID, template.BaseDrawing, trans)
    End Function

    ''' <summary>
    ''' Adds dxf to the db - internal
    ''' </summary>
    Private Function SetDxf(guid As String, dxf As LampDxfDocument, Optional trans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            ' Add in templateData
            command.CommandText = "INSERT OR REPLACE into DXF
                    (guid, DXF)
                    VALUES
                    (@guid, @DXF)"

            command.Parameters.AddWithValue("@guid", guid)
            command.Parameters.AddWithValue("@DXF", dxf.ToDxfString())


            Return Convert.ToBoolean(command.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' adds a dxf async - internal
    ''' </summary>
    ''' <param name="template"></param>
    ''' <returns></returns>
    Private Async Function SetDxfAsync(template As LampTemplate, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Return Await SetDxfAsync(template.GUID, template.BaseDrawing, trans).ConfigureAwait(False)
    End Function

    ''' <summary>
    ''' adds a dxf async - internal
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="dxf"></param>
    ''' <returns></returns>
    Private Async Function SetDxfAsync(guid As String, dxf As LampDxfDocument, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            ' Add in templateData
            command.CommandText = "INSERT OR REPLACE into DXF
                    (guid, DXF)
                    VALUES
                    (@guid, @DXF)"

            command.Parameters.AddWithValue("@guid", guid)
            command.Parameters.AddWithValue("@DXF", dxf.ToDxfString())

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync().ConfigureAwait(False))
        End Using
    End Function

    ''' <summary>
    ''' Removes from database based on guid
    ''' Also removes images by default, rmImages can be set to false to not
    ''' </summary>
    ''' <param name="guid">string guid</param>
    ''' <returns>True=Removed, False=None found</returns>
    Private Function RemoveDxf(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
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
    Private Async Function RemoveDxfAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "DELETE from dxf WHERE GUID = @guid"
            command.Parameters.AddWithValue("@guid", guid)

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync().ConfigureAwait(False))
        End Using
    End Function

    ''' <summary>
    ''' gets a template's metadata
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectTemplateMetadata(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As LampTemplateMetadata
        Dim metadata As LampTemplateMetadata = Nothing
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select 
                                    name, shortDescription, longDescription, material, 
                                    length, height, materialthickness, 
                                    creatorId, approverId, submitDate, complete 

                                    FROM template WHERE guid = @guid"
            command.Parameters.AddWithValue("@guid", guid)
            Using reader = command.ExecuteReader()
                ' read only 1 row off the database
                If reader.Read() Then
                    metadata = New LampTemplateMetadata(guid)

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
                        metadata.ApproverProfile = SelectUser(reader.GetString(reader.GetOrdinal("ApproverId"))).ToProfile
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
    Public Async Function SelectTemplateMetadataAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of LampTemplateMetadata)
        Dim metadata As LampTemplateMetadata = Nothing
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select 
                                    name, shortDescription, longDescription, material, 
                                    length, height, materialthickness, 
                                    creatorId, approverId, submitDate, complete 

                                    FROM template WHERE guid = @guid"
            command.Parameters.AddWithValue("@guid", guid)
            Using reader = Await command.ExecuteReaderAsync().ConfigureAwait(False)
                ' read only 1 row off the database
                If Await reader.ReadAsync() Then
                    metadata = New LampTemplateMetadata(guid)

                    metadata.Name = reader.GetString(reader.GetOrdinal("name"))
                    metadata.ShortDescription = reader.GetString(reader.GetOrdinal("ShortDescription"))
                    metadata.LongDescription = reader.GetString(reader.GetOrdinal("LongDescription"))
                    metadata.Material = reader.GetString(reader.GetOrdinal("material"))
                    metadata.Length = reader.GetDouble(reader.GetOrdinal("length"))
                    metadata.Height = reader.GetDouble(reader.GetOrdinal("height"))
                    metadata.MaterialThickness = reader.GetDouble(reader.GetOrdinal("MaterialThickness"))

                    If Not reader.IsDBNull(reader.GetOrdinal("CreatorId")) Then
                        metadata.CreatorProfile = (Await SelectUserAsync(reader.GetString(reader.GetOrdinal("CreatorId"))).ConfigureAwait(False)).ToProfile
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("ApproverId")) Then
                        metadata.ApproverProfile = (Await SelectUserAsync(reader.GetString(reader.GetOrdinal("ApproverId"))).ConfigureAwait(False)).ToProfile
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
    Private Function SetTemplateData(template As LampTemplateMetadata, creatorId As String, approverId As String, Optional trans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
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
    Private Async Function SetTemplateDataAsync(template As LampTemplateMetadata, creatorId As String, approverId As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
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

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync().ConfigureAwait(False))
        End Using
    End Function

    ''' <summary>
    ''' Remove template data
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="trans"></param>
    ''' <returns></returns>
    Private Function RemoveTemplateData(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "DELETE from template WHERE GUID = @guid"
            command.Parameters.AddWithValue("@guid", guid)

            Return Convert.ToBoolean(command.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' Remove template data
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="trans"></param>
    ''' <returns></returns>
    Private Async Function RemoveTemplateDataAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "DELETE from template WHERE GUID = @guid"
            command.Parameters.AddWithValue("@guid", guid)

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync().ConfigureAwait(False))
        End Using
    End Function

    ''' <summary>
    ''' Retrieves the images from the database
    ''' given guid of the template, returns the images associated with it, or nothing if none was found
    ''' returns a list of <see cref="LampTemplate.MaxImages"/> size.
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectImages(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As List(Of Image)
        Dim images As New List(Of Image)

        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
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
    Public Async Function SelectImagesAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of List(Of Image))
        Dim images As New List(Of Image)

        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select image1, image2, image3 FROM images WHERE guid = @guid"
            command.Parameters.AddWithValue("@guid", guid)

            Using reader = Await command.ExecuteReaderAsync().ConfigureAwait(False)
                If Await reader.ReadAsync().ConfigureAwait(False) Then
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
    Private Function SetImages(Guid As String, images As IEnumerable(Of Image), Optional trans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "INSERT OR REPLACE INTO images
                    (Guid, image1, image2, image3)
                    VALUES
                    (@guid, @image1, @image2, @image3);"

            command.Parameters.AddWithValue("@guid", Guid)

            If images.Count > LampTemplate.MaxImages Then
                Throw New ArgumentOutOfRangeException(NameOf(images), images, String.Format("images array must have {0} or less elements", LampTemplate.MaxImages))
            End If

            Dim insertedAtLeastOne As Boolean = False

            For i = 0 To images.Count - 1
                Dim columnName = String.Format("@image{0}", i + 1)
                command.Parameters.AddWithValue(columnName, ImageToBinary(images(i)))

                If images(i) IsNot Nothing Then
                    insertedAtLeastOne = True
                End If
            Next

            If insertedAtLeastOne = False Then
                Throw New ArgumentOutOfRangeException(NameOf(images), images, "Images must have at least 1 not-null element")
            End If

            Return Convert.ToBoolean(command.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' Stores up to 3 preview images in the database
    ''' images are stored as binary blobs (byte arrays or byte() in vb.net)
    ''' this function takes a list(of Image), converts them into binary and chucks them in the database
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="images"></param>
    Private Async Function SetImagesAsync(guid As String, images As IEnumerable(Of Image), Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "INSERT OR REPLACE INTO images
                    (Guid, image1, image2, image3)
                    VALUES
                    (@guid, @image1, @image2, @image3);"

            command.Parameters.AddWithValue("@guid", guid)

            If images.Count > LampTemplate.MaxImages Then
                Throw New ArgumentOutOfRangeException(NameOf(images), images, String.Format("images array must have {0} or less elements", LampTemplate.MaxImages))
            End If

            Dim insertedAtLeastOne As Boolean = False

            For i = 0 To images.Count - 1
                Dim columnName = String.Format("@image{0}", i + 1)
                command.Parameters.AddWithValue(columnName, ImageToBinary(images(i)))

                If images(i) IsNot Nothing Then
                    insertedAtLeastOne = True
                End If
            Next

            If insertedAtLeastOne = False Then
                Throw New ArgumentOutOfRangeException(NameOf(images), images, "Images must have at least 1 not-null element")
            End If

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync().ConfigureAwait(False))
        End Using
    End Function

    ''' <summary>
    ''' Removes images associated with the guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns>True=Removed image, False=None removed</returns>
    Private Function RemoveImages(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
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
    Private Async Function RemoveImagesAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "DELETE from images WHERE GUID = @guid"
            command.Parameters.AddWithValue("@guid", guid)
            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync().ConfigureAwait(False))
        End Using
    End Function

    ''' <summary>
    ''' Gets all tags that belong to a template's guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectTags(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As List(Of String)
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand(trans)
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
    Public Async Function SelectTagsAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of List(Of String))
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "SELECT tagName FROM tags
                                      WHERE guid=@guid;"

            command.Parameters.AddWithValue("@guid", guid)

            Dim tags As New List(Of String)
            Dim reader = Await command.ExecuteReaderAsync().ConfigureAwait(False)

            While Await reader.ReadAsync().ConfigureAwait(False)
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
    Private Function SetTags(guid As String, tags As IEnumerable(Of String), Optional trans As SqliteTransactionWrapper = Nothing) As Integer
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "INSERT OR REPLACE INTO tags
                    (Guid, tagName)
                    VALUES
                    (@guid, @tagName);"

            Dim insertedRows = 0
            command.Parameters.AddWithValue("@guid", guid)
            For Each tag In tags
                command.Parameters.AddWithValue("@tagName", tag.ToLower().Trim())

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
    Private Async Function SetTagsAsync(guid As String, tags As IEnumerable(Of String), Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Integer)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "INSERT OR REPLACE INTO tags
                    (Guid, tagName)
                    VALUES
                    (@guid, @tagName);"

            Dim insertedRows As Integer = 0
            command.Parameters.AddWithValue("@guid", guid)
            For Each tag In tags
                command.Parameters.AddWithValue("@tagName", tag.ToLower().Trim())

                insertedRows += Await command.ExecuteNonQueryAsync().ConfigureAwait(False)
            Next
            Return insertedRows
        End Using
    End Function

    ''' <summary>
    ''' Removes all tags associated with the guid
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Private Function RemoveTags(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Integer
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand(trans)
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
    Private Async Function RemoveTagsAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Integer)
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand(trans)
            sqlite_cmd.CommandText = "DELETE from tags WHERE guid = @guid"
            sqlite_cmd.Parameters.AddWithValue("@guid", guid)
            Return Await sqlite_cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
        End Using
    End Function

    ''' <summary>
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectTemplate(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As LampTemplate
        guid = guid.ToLower()
        Using conn = Connection.OpenConnection()
            Dim data = SelectTemplateMetadata(guid, trans)
            Dim template As LampTemplate = If(data IsNot Nothing, data.ToLampTemplate, Nothing)

            If template IsNot Nothing Then
                ' dxf
                Dim dxf As LampDxfDocument = SelectDxf(guid, trans)
                If dxf IsNot Nothing Then
                    template.BaseDrawing = dxf
                End If

                ' images
                Dim images = SelectImages(guid, trans)
                If images IsNot Nothing Then
                    For i = 0 To LampTemplate.MaxImages - 1
                        template.PreviewImages(i) = images(i)
                    Next
                End If

                ' get all the tags from the db as well
                For Each tag In SelectTags(guid, trans)
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
    Public Async Function SelectTemplateAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of LampTemplate)
        guid = guid.ToLower()
        Using conn = Connection.OpenConnection()
            Dim data = Await SelectTemplateMetadataAsync(guid, trans).ConfigureAwait(False)
            Dim template As LampTemplate = If(data IsNot Nothing, data.ToLampTemplate, Nothing)

            If template IsNot Nothing Then
                Dim dxfTask = SelectDxfAsync(guid, trans)
                Dim imageTask = SelectImagesAsync(guid, trans)
                Dim tagTask = SelectTagsAsync(guid, trans)

                Await Task.WhenAll(dxfTask, imageTask, tagTask).ConfigureAwait(False)

                If dxfTask.Result IsNot Nothing Then
                    template.BaseDrawing = dxfTask.Result
                Else
                    Return Nothing ' dxf cannot be nothing
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
    Public Function SetTemplate(template As LampTemplate, Optional creatorId As String = Nothing, Optional approverId As String = Nothing, Optional optTrans As SqliteTransactionWrapper = Nothing) As Boolean
        template.GUID = template.GUID.ToLower
        Using conn = Connection.OpenConnection, trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Transaction.LockTransaction) ' create auto transaction if needed

            If SetTemplateData(template, creatorId, approverId, trans) Then
                If SetDxf(template.GUID, template.BaseDrawing, trans) Then

                    ' check that there is at least 1 image
                    If template.PreviewImages.HasNotNothing() Then
                        SetImages(template.GUID, template.PreviewImages, trans)
                    End If

                    If template.Tags.Count > 0 Then
                        SetTags(template.GUID, template.Tags, trans)
                    End If

                    ' actually write it to the database if using the auto transaction, otherwise leave it to the caller
                    If optTrans Is Nothing Then
                        trans.Commit()
                    End If

                    Return True
                End If
            End If

            ' failed to insert data, probably
            Return False
        End Using
    End Function

    ''' <summary>
    ''' Adds a template to the database
    ''' </summary>
    ''' <param name="template"></param>
    Public Async Function SetTemplateAsync(template As LampTemplate, Optional creatorId As String = Nothing, Optional approverId As String = Nothing, Optional optTrans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        template.GUID = template.GUID.ToLower
        Using conn = Connection.OpenConnection, trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Await Transaction.LockTransactionAsync.ConfigureAwait(False))
            If Await SetTemplateDataAsync(template, creatorId, approverId, trans).ConfigureAwait(False) Then
                If Await SetDxfAsync(template.GUID, template.BaseDrawing, trans).ConfigureAwait(False) Then

                    ' check that there is at least 1 image
                    If template.PreviewImages.HasNotNothing() Then
                        Await SetImagesAsync(template.GUID, template.PreviewImages, trans).ConfigureAwait(False)
                    End If

                    If template.Tags.Count > 0 Then
                        Await SetTagsAsync(template.GUID, template.Tags, trans).ConfigureAwait(False)
                    End If

                    ' actually write it to the database if using the auto transaction, otherwise leave it to the caller
                    If optTrans Is Nothing Then
                        trans.Commit()
                    End If

                    Return True
                End If
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
    Public Function RemoveTemplate(guid As String, Optional optTrans As SqliteTransactionWrapper = Nothing) As Boolean
        guid = guid.ToLower()
        Using conn = Connection.OpenConnection, trans = If(optTrans, Transaction.LockTransaction)
            ' gotta remove these first before the guid in the templates table is gone
            If RemoveTemplateData(guid, trans) Then
                If RemoveDxf(guid, trans) Then
                    ' might not have images/tags, just remove them (itll throw exception if it fails hopefully)
                    RemoveImages(guid, trans)
                    RemoveTags(guid, trans)

                    ' actually write it to the database if using the auto transaction, otherwise leave it to the caller
                    If optTrans Is Nothing Then
                        trans.Commit()
                    End If

                    Return True

                End If
            End If
        End Using
        Return False
    End Function

    ''' <summary>
    ''' Removes from database based on guid
    ''' Also removes images by default, rmImages can be set to false to not
    ''' </summary>
    ''' <param name="guid">string guid</param>
    ''' <returns>True=Removed, False=None found</returns>
    Public Async Function RemoveTemplateAsync(guid As String, Optional optTrans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        guid = guid.ToLower()
        Using conn = Connection.OpenConnection, trans = If(optTrans, Await Transaction.LockTransactionAsync.ConfigureAwait(False))
            ' gotta remove these first before the guid in the templates table is gone
            If Await RemoveTemplateDataAsync(guid, trans).ConfigureAwait(False) Then
                If Await RemoveDxfAsync(guid, trans).ConfigureAwait(False) Then

                    ' wait for remove images/tags to finish
                    Await Task.WhenAll(RemoveImagesAsync(guid, trans), RemoveTagsAsync(guid, trans)).ConfigureAwait(False)


                    ' actually write it to the database if using the auto transaction, otherwise leave it to the caller
                    If optTrans Is Nothing Then
                        trans.Commit()
                    End If

                    Return True
                End If
            End If

        End Using
        Return False
    End Function

End Class


' implementation of users
Partial Public Class TemplateDatabase
    ''' <summary>
    ''' gets a user, which has all the info on users
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function SelectUser(userId As String, Optional trans As SqliteTransactionWrapper = Nothing) As LampUser
        Dim user As LampUser = Nothing

        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
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

                    user = New LampUser(userId, permissionLevel, email, username, password, name)
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
    Public Async Function SelectUserAsync(userId As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of LampUser)
        Dim user As LampUser = Nothing

        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select email, username, password, permissionLevel, name from Users 
                                          WHERE userId = @guid"
            command.Parameters.AddWithValue("@guid", userId)

            Using reader = Await command.ExecuteReaderAsync().ConfigureAwait(False)
                If Await reader.ReadAsync().ConfigureAwait(False) Then
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
    ''' Check if any part of the user exists in the db, since username, email and guid are unique
    ''' </summary>
    ''' <param name="user"></param>
    ''' <param name="trans"></param>
    ''' <returns></returns>
    Public Function UserExists(user As LampUser, Optional trans As SqliteTransactionWrapper = Nothing) As LampStatus
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select EXISTS(SELECT 1 from Users WHERE userid=@userid)"
            command.Parameters.AddWithValue("@userid", user.UserId)
            If command.ExecuteScalar() Then
                ' 1 or more userid's exist
                Return LampStatus.GuidConflict
            End If

            command.CommandText = "Select EXISTS(SELECT 1 from Users WHERE username=@username)"
            command.Parameters.AddWithValue("@username", user.Username)
            If command.ExecuteScalar() Then
                ' 1 or more usernames's exist
                Return LampStatus.UsernameConflict
            End If

            command.CommandText = "Select EXISTS(SELECT 1 from Users WHERE email=@email)"
            command.Parameters.AddWithValue("@email", user.Email)
            If command.ExecuteScalar() Then
                ' 1 or more emails's exist
                Return LampStatus.EmailConflict
            End If

            Return LampStatus.OK
        End Using

    End Function


    Public Async Function UserExistsAsync(user As LampUser, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of LampStatus)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select EXISTS(SELECT 1 from Users WHERE userid=@userid)"
            command.Parameters.AddWithValue("@userid", user.UserId)
            If Await command.ExecuteScalarAsync().ConfigureAwait(False) Then
                ' 1 or more userid's exist
                Return LampStatus.GuidConflict
            End If

            command.CommandText = "Select EXISTS(SELECT 1 from Users WHERE username=@username)"
            command.Parameters.AddWithValue("@username", user.Username)
            If Await command.ExecuteScalarAsync().ConfigureAwait(False) Then
                ' 1 or more usernames's exist
                Return LampStatus.UsernameConflict
            End If

            command.CommandText = "Select EXISTS(SELECT 1 from Users WHERE email=@email)"
            command.Parameters.AddWithValue("@email", user.Email)
            If Await command.ExecuteScalarAsync().ConfigureAwait(False) Then
                ' 1 or more emails's exist
                Return LampStatus.EmailConflict
            End If

            Return LampStatus.OK
        End Using
    End Function

    ''' <summary>
    ''' Gets the user object from a username/password pair
    ''' </summary>
    ''' <param name="username"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    Public Function SelectUser(username As String, password As String, Optional trans As SqliteTransactionWrapper = Nothing) As LampUser
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select userId from Users 
                                          WHERE username=@username AND password=@password"
            command.Parameters.AddWithValue("@username", username)
            command.Parameters.AddWithValue("@password", password)

            Dim userId = command.ExecuteScalar()
            If userId IsNot Nothing Then
                Return SelectUser(DirectCast(userId, String), trans)
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
    Public Async Function SelectUserAsync(username As String, password As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of LampUser)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select userId from Users 
                                          WHERE username=@username AND password=@password"
            command.Parameters.AddWithValue("@username", username)
            command.Parameters.AddWithValue("@password", password)

            Dim userId = Await command.ExecuteScalarAsync().ConfigureAwait(False)
            If userId IsNot Nothing Then
                Return SelectUser(DirectCast(userId, String), trans)
            Else
                Return Nothing
            End If
        End Using
    End Function

    ''' <summary>
    ''' Adds a user to the database
    ''' </summary>
    ''' <param name="user"></param>
    Public Function SetUser(user As LampUser, Optional trans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "INSERT OR REPLACE INTO users
                    (UserId,permissionLevel, email, username, password, name)
                    VALUES
                    (@UserId, @permissionLevel, @email, @username, @password, @name);"

            command.Parameters.AddWithValue("@UserId", user.UserId)
            command.Parameters.AddWithValue("@permissionLevel", user.PermissionLevel)
            command.Parameters.AddWithValue("@email", user.Email.ToLower())
            command.Parameters.AddWithValue("@username", user.Username.ToLower())
            command.Parameters.AddWithValue("@password", user.Password)
            command.Parameters.AddWithValue("@name", user.Name)


            Return Convert.ToBoolean(command.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' Adds a user to the database
    ''' </summary>
    ''' <param name="user"></param>
    Public Async Function SetUserAsync(user As LampUser, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "INSERT OR REPLACE INTO users
                    (UserId,permissionLevel, email, username, password, name)
                    VALUES
                    (@UserId, @permissionLevel, @email, @username, @password, @name);"

            command.Parameters.AddWithValue("@UserId", user.UserId)
            command.Parameters.AddWithValue("@permissionLevel", user.PermissionLevel)
            command.Parameters.AddWithValue("@email", user.Email.ToLower())
            command.Parameters.AddWithValue("@username", user.Username.ToLower())
            command.Parameters.AddWithValue("@password", user.Password)
            command.Parameters.AddWithValue("@name", user.Name)


            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync().ConfigureAwait(False))
        End Using
    End Function

    ''' <summary>
    ''' removes a user from db
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function RemoveUser(userId As String, Optional trans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
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
    Public Async Function RemoveUserAsync(userId As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "DELETE from users WHERE userId = @userid"
            command.Parameters.AddWithValue("@userid", userId)
            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync().ConfigureAwait(False))
        End Using
    End Function

    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    Public Function SelectJob(jobId As String, Optional trans As SqliteTransactionWrapper = Nothing) As LampJob
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select templateId, submitterId, approverId, approved, submitDate from jobs 
                                          WHERE jobId = @jobId"
            command.Parameters.AddWithValue("@jobId", jobId)

            Using reader = command.ExecuteReader()
                Dim job As LampJob = Nothing
                If reader.Read() Then
                    Dim templateId = reader.GetString(reader.GetOrdinal("templateId"))
                    Dim template = SelectTemplate(templateId)

                    Dim submitterId = reader.GetString(reader.GetOrdinal("submitterId"))

                    Dim approverId As String = Nothing
                    If Not reader.IsDBNull(reader.GetOrdinal("approverId")) Then
                        approverId = reader.GetString(reader.GetOrdinal("approverId"))
                    End If

                    Dim submitterP As LampProfile = Nothing
                    If submitterId IsNot Nothing Then
                        submitterP = SelectUser(submitterId, trans).ToProfile
                    End If

                    Dim approverP As LampProfile = Nothing
                    If approverId IsNot Nothing Then
                        approverP = SelectUser(approverId, trans).ToProfile
                    End If


                    Dim approved = reader.GetBoolean(reader.GetOrdinal("approved"))
                    Dim submitDate = reader.GetDateTime(reader.GetOrdinal("submitDate"))

                    job = New LampJob(template, submitterP, approverP, approved, submitDate)
                End If
                Return job
            End Using
        End Using
    End Function

    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    Public Async Function SelectJobAsync(jobId As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of LampJob)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select templateId, submitterId, approverId, approved, submitDate from jobs 
                                          WHERE jobId = @jobId"
            command.Parameters.AddWithValue("@jobId", jobId)

            Using reader = Await command.ExecuteReaderAsync().ConfigureAwait(False)
                Dim job As LampJob = Nothing
                If Await reader.ReadAsync().ConfigureAwait(False) Then

                    Dim templateId = reader.GetString(reader.GetOrdinal("templateId"))
                    Dim template = SelectTemplate(templateId)

                    Dim submitterId = reader.GetString(reader.GetOrdinal("submitterId"))

                    Dim approverId As String = Nothing
                    If Not reader.IsDBNull(reader.GetOrdinal("approverId")) Then
                        approverId = reader.GetString(reader.GetOrdinal("approverId"))
                    End If

                    ' TODO combine in 1 sql statement
                    Dim submitterP As LampProfile = Nothing
                    If submitterId IsNot Nothing Then
                        submitterP = (Await SelectUserAsync(submitterId, trans)).ToProfile
                    End If

                    Dim approverP As LampProfile = Nothing
                    If approverId IsNot Nothing Then
                        approverP = (Await SelectUserAsync(approverId, trans).ConfigureAwait(False)).ToProfile
                    End If


                    Dim approved = reader.GetBoolean(reader.GetOrdinal("approved"))
                    Dim submitDate = reader.GetDateTime(reader.GetOrdinal("submitDate"))

                    job = New LampJob(template, submitterP, approverP, approved, submitDate)
                End If

                Return job
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Adds a job to the database, returns false if not inserted or not template in db
    ''' </summary>
    Public Function SetJob(job As LampJob, Optional trans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            Dim fromDb = SelectTemplateAsync(job.Template.GUID)
            If fromDb Is Nothing Then ' add check for 2 templates equal
                Return False
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
    ''' Adds a job to the database, returns false if not inserted or no template in db
    ''' </summary>
    Public Async Function SetJobAsync(job As LampJob, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            Dim fromDb = Await SelectTemplateMetadataAsync(job.Template.GUID).ConfigureAwait(False)
            If fromDb Is Nothing Then ' add check for 2 template equal TODO
                Return False
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

            Return Convert.ToBoolean(Await command.ExecuteNonQueryAsync().ConfigureAwait(False))
        End Using
    End Function

    ''' <summary>
    ''' Removes a job from the db
    ''' </summary>
    ''' <param name="jobId"></param>
    ''' <returns></returns>
    Public Function RemoveJob(jobId As String, Optional trans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
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
    Public Async Function RemoveJobAsync(jobId As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "DELETE from jobs WHERE jobId = @jobId"
            command.Parameters.AddWithValue("@jobId", jobId)
            Return Await command.ExecuteNonQueryAsync().ConfigureAwait(False)
        End Using
    End Function

End Class

Public Enum LampSort
    NoSort

    SubmitDateAsc
    SubmitDateDesc
    TemplateNameAsc
    TemplateNameDesc
End Enum

Public Class TemplateDatabase
    Public Function GetMultipleTemplate(tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, includeUnapproved As Boolean, orderBy As LampSort) As List(Of LampTemplate)
        If tags Is Nothing OrElse tags.Count() = 0 Then
            Return GetTemplateList(byUser, limit, offset, includeUnapproved, orderBy)
        Else
            Return SelectTemplateWithTags(tags, byUser, limit, offset, includeUnapproved, orderBy)
        End If
    End Function

    Public Async Function GetMultipleTemplateAsync(tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, includeUnapproved As Boolean, orderBy As LampSort) As Task(Of List(Of LampTemplate))
        If tags Is Nothing OrElse tags.Count() = 0 Then
            Return Await GetTemplateListAsync(byUser, limit, offset, includeUnapproved, orderBy).ConfigureAwait(False)
        Else
            Return Await SelectTemplateWithTagsAsync(tags, byUser, limit, offset, includeUnapproved, orderBy).ConfigureAwait(False)
        End If
    End Function

    Public Function GetMultipleJob(byUser As IEnumerable(Of String), limit As Integer, offset As Integer, orderBy As LampSort) As List(Of LampJob)
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingJobs As New List(Of LampJob)

            Dim userParameter = "1"
            If byUser.Count <> 0 Then
                userParameter = "jobs.submitterId in ("
                For i = 0 To byUser.Count() - 1
                    userParameter += ("@user" + i.ToString())
                Next

                userParameter += ")"
            End If

            Dim stringCommand = String.Format("SELECT jobId FROM jobs WHERE {0} 
                                            {1}
                                            LIMIT @limit
                                            OFFSET @offset",
                                            userParameter, GetJobSqlFromSort(orderBy))
            command.CommandText = stringCommand

            command.Parameters.AddWithValue("@limit", limit)
            command.Parameters.AddWithValue("@offset", offset)

            For i = 0 To byUser.Count() - 1
                command.Parameters.AddWithValue("@user" + i.ToString(), byUser(i))
            Next

            Using sqlite_reader = command.ExecuteReader()
                While sqlite_reader.Read()
                    Dim guid = sqlite_reader.GetString(sqlite_reader.GetOrdinal("jobId"))
                    matchingJobs.Add(SelectJob(guid))
                End While

            End Using

            Return matchingJobs
        End Using
    End Function

    Public Async Function GetMultipleJobAsync(byUser As IEnumerable(Of String), limit As Integer, offset As Integer, orderBy As LampSort) As Task(Of List(Of LampJob))
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingJobs As New List(Of LampJob)

            Dim userParameter = "1"
            If byUser.Count <> 0 Then
                userParameter = "jobs.submitterId in ("
                For i = 0 To byUser.Count() - 1
                    userParameter += ("@user" + i.ToString())
                Next

                userParameter += ")"
            End If

            Dim stringCommand = String.Format("SELECT jobId FROM jobs WHERE {0} 
                                            {1}
                                            LIMIT @limit
                                            OFFSET @offset",
                                            userParameter, GetJobSqlFromSort(orderBy))
            command.CommandText = stringCommand

            command.Parameters.AddWithValue("@limit", limit)
            command.Parameters.AddWithValue("@offset", offset)

            For i = 0 To byUser.Count() - 1
                command.Parameters.AddWithValue("@user" + i.ToString(), byUser(i))
            Next

            Using sqlite_reader = Await command.ExecuteReaderAsync().ConfigureAwait(False)
                While Await sqlite_reader.ReadAsync().ConfigureAwait(False)
                    Dim guid = sqlite_reader.GetString(sqlite_reader.GetOrdinal("jobId"))
                    matchingJobs.Add(Await SelectJobAsync(guid).ConfigureAwait(False))
                End While

            End Using

            Return matchingJobs
        End Using
    End Function

    ''' <summary>
    ''' Gets a list of templates without tag filtering
    ''' </summary>
    ''' <param name="limit"></param>
    ''' <param name="offset"></param>
    ''' <param name="includeUnapproved"></param>
    ''' <returns></returns>
    Private Function GetTemplateList(byUser As IEnumerable(Of String), limit As Integer, offset As Integer, includeUnapproved As Boolean, orderBy As LampSort) As List(Of LampTemplate)
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingTemplates As New List(Of LampTemplate)

            Dim approveText = "1"
            If includeUnapproved = False Then
                approveText = "approverId is not null"
            End If

            Dim userParameter = "1"
            If byUser.Count <> 0 Then
                userParameter = "template.creatorId in ("
                For i = 0 To byUser.Count() - 1
                    userParameter += ("@user" + i.ToString())
                Next

                userParameter += ")"
            End If

            Dim stringCommand = String.Format("SELECT guid FROM template WHERE {0} AND {1}
                                            {2}
                                            LIMIT @limit
                                            OFFSET @offset",
                                           approveText, userParameter, GetTemplateSqlFromSort(orderBy))
            command.CommandText = stringCommand
            command.Parameters.AddWithValue("@limit", limit)
            command.Parameters.AddWithValue("@offset", offset)

            For i = 0 To byUser.Count() - 1
                command.Parameters.AddWithValue("@user" + i.ToString(), byUser(i))
            Next

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
    ''' async version of <see cref="GetTemplateList(IEnumerable(Of String),Integer , Integer, Boolean, LampSort)"></see>
    ''' </summary>
    ''' <param name="limit"></param>
    ''' <param name="offset"></param>
    ''' <param name="includeUnapproved"></param>
    ''' <returns></returns>
    Private Async Function GetTemplateListAsync(byUser As IEnumerable(Of String), limit As Integer, offset As Integer, includeUnapproved As Boolean, orderBy As LampSort) As Task(Of List(Of LampTemplate))
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingTemplates As New List(Of LampTemplate)

            Dim approveText = "1"
            If includeUnapproved = False Then
                approveText = "approverId is not null"
            End If

            Dim userParameter = "1"
            If byUser.Count <> 0 Then
                userParameter = "template.creatorId in ("
                For i = 0 To byUser.Count() - 1
                    userParameter += ("@user" + i.ToString())
                Next

                userParameter += ")"
            End If

            Dim stringCommand = String.Format("SELECT guid FROM template WHERE {0} AND {1}
                                            {2}
                                            LIMIT @limit
                                            OFFSET @offset",
                                           approveText, userParameter, GetTemplateSqlFromSort(orderBy))
            command.CommandText = stringCommand
            command.Parameters.AddWithValue("@limit", limit)
            command.Parameters.AddWithValue("@offset", offset)

            For i = 0 To byUser.Count() - 1
                command.Parameters.AddWithValue("@user" + i.ToString(), byUser(i))
            Next

            Using sqlite_reader = Await command.ExecuteReaderAsync().ConfigureAwait(False)
                While Await sqlite_reader.ReadAsync().ConfigureAwait(False)
                    Dim guid = sqlite_reader.GetString(sqlite_reader.GetOrdinal("guid"))
                    matchingTemplates.Add(Await SelectTemplateAsync(guid).ConfigureAwait(False))
                End While

            End Using

            Return matchingTemplates
        End Using
    End Function

    ''' <summary>
    ''' Gets all templates in the database
    ''' Debug only
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
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <returns></returns>
    Private Function SelectTemplateWithTags(tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, includeUnapproved As Boolean, orderBy As LampSort) As List(Of LampTemplate)
        ' If the databse is open already, dont close it

        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingTemplates As New List(Of LampTemplate)

            If tags.Count() = 0 Then
                Throw New Exception("must have at least 1 tag")
            End If

            Dim tagParameters = "tagName IN ("
            For i = 0 To tags.Count - 1
                tagParameters += "@tag" + i.ToString()
            Next
            tagParameters += ")"

            Dim userParameter = "1"
            If byUser.Count <> 0 Then
                userParameter = "template.creatorId in ("
                For i = 0 To byUser.Count() - 1
                    userParameter += ("@user" + i.ToString())
                Next

                userParameter += ")"
            End If


            Dim approveText = "1"
            If includeUnapproved = False Then
                approveText = "(SELECT 1 from template WHERE template.guid = tags.guid and approverId is not null)"
            End If

            Dim stringCommand = String.Format("Select tags.guid from tags
                                      WHERE {0} AND {1} AND {2}
                                      {3}
                                      LIMIT @limit
                                      OFFSET @offset
                                     ", tagParameters, approveText, userParameter, GetTemplateSqlFromSort(orderBy))
            ' find all templates w/
            command.CommandText = stringCommand
            For i = 0 To tags.Count - 1
                command.Parameters.AddWithValue("@tag" + i.ToString(), tags(i).ToLower())
            Next

            For i = 0 To byUser.Count() - 1
                command.Parameters.AddWithValue("@user" + i.ToString(), byUser(i))
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
    ''' Finds a template in the database, given its corresponding guid
    ''' If no template is found, returns nothing
    ''' </summary>
    ''' <returns></returns>
    Private Async Function SelectTemplateWithTagsAsync(tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, includeUnapproved As Boolean, orderBy As LampSort) As Task(Of List(Of LampTemplate))
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingTemplates As New List(Of LampTemplate)

            If tags.Count() = 0 Then
                Throw New Exception("must have at least 1 tag")
            End If

            Dim tagParameters As New StringBuilder()

            For i = 0 To tags.Count - 1
                tagParameters.Insert(i, "@tag" + i.ToString())
            Next
            Dim tagString = "tagName IN (" + tagParameters.ToString() + ")"

            Dim userParameter = "1"
            If byUser.Count <> 0 Then
                userParameter = "template.creatorId in ("
                For i = 0 To byUser.Count() - 1
                    userParameter += ("@user" + i.ToString())
                Next

                userParameter += ")"
            End If



            Dim approveText = "1"
            If includeUnapproved = False Then
                approveText = "(SELECT 1 from template WHERE template.guid = tags.guid and approverId is not null)"
            End If

            Dim stringCommand = String.Format("Select tags.guid from tags
                                      WHERE {0} AND {1} AND {2}
                                      {3}
                                      LIMIT @limit
                                      OFFSET @offset
                                     ", tagString, approveText, userParameter, GetTemplateSqlFromSort(orderBy))
            ' find all templates w/
            command.CommandText = stringCommand
            For i = 0 To tags.Count - 1
                command.Parameters.AddWithValue("@tag" + i.ToString(), tags(i).ToLower())
            Next

            For i = 0 To byUser.Count() - 1
                command.Parameters.AddWithValue("@user" + i.ToString(), byUser(i))
            Next

            command.Parameters.AddWithValue("@limit", limit)
            command.Parameters.AddWithValue("@offset", offset)


            Using sqlite_reader = Await command.ExecuteReaderAsync().ConfigureAwait(False)
                While Await sqlite_reader.ReadAsync().ConfigureAwait(False)
                    Dim guid = sqlite_reader.GetString(sqlite_reader.GetOrdinal("guid"))
                    matchingTemplates.Add(Await SelectTemplateAsync(guid).ConfigureAwait(False))
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
        Dim db As New TemplateDatabase(fileName)
        FillDebugDatabase(db)
    End Sub

    ''' <summary>
    ''' Fills the database with debug data
    ''' </summary>
    ''' <param name="db"></param>
    Public Shared Sub FillDebugDatabase(db As TemplateDatabase)
#If Not DEBUG Then
        Throw New Exception("do not use debug db in Release Mode")
#End If

        ' add useres
        Dim max As New LampUser(GetNewGuid(), UserPermission.Admin, "maxywartonyjonesy@gmail.com", "waxy", "memes", "steve by birth!")
        db.SetUser(max)

        Dim shovel = New LampUser(GetNewGuid(), UserPermission.Admin, "qshoveyl@gmail.com", "shourov", "shovel101", "Knot Jack")
        db.SetUser(shovel)

        Dim jack = New LampUser(GetNewGuid(), UserPermission.Admin, "jackywathyy123@gmail.com", "moji", "snack time", "shovel tool")
        db.SetUser(jack)


        Dim ExampleSpfFiles() As String = {"1.spf", "2.spf", "3.spf", "4.spf", "5.spf", "6.spf", "7.spf", "8.spf", "9.spf"}

        ' add new templates 
        For Each spfName As String In ExampleSpfFiles
            Dim fp = IO.Path.GetFullPath(IO.Path.Combine("../", "../", "../", "templates", "spf", spfName))
            Dim template = LampTemplate.FromFile(fp)
            db.SetTemplate(template, shovel.UserId, shovel.UserId)
        Next




        Dim templates = db.GetAllTemplate

        ' add jobs
        Dim job As New LampJob(templates(0), max.ToProfile)
        db.SetJob(job)

        job = New LampJob(templates(1), shovel.ToProfile)
        db.SetJob(job)
    End Sub

    Public Shared Async Function FillDebugDatabaseAsync(Optional fileName As String = "templateDB.sqlite") As Task
        Dim db As New TemplateDatabase(fileName)
        Await TemplateDatabase.FillDebugDatabaseAsync(db)
    End Function

    Public Shared Async Function FillDebugDatabaseAsync(db As TemplateDatabase) As Task
#If Not DEBUG Then
        Throw New Exception("do not use debug db in Release Mode")
#End If
        Dim ExampleSpfFiles() As String = {"1.spf", "2.spf", "3.spf", "4.spf", "5.spf", "6.spf", "7.spf", "8.spf", "9.spf"}
        ' add useres
        Dim max As New LampUser(GetNewGuid(), UserPermission.Admin, "maxywartonyjonesy@gmail.com", "waxy", "memes", "steve by birth!")
        Await db.SetUserAsync(max).ConfigureAwait(False)

        Dim shovel = New LampUser(GetNewGuid(), UserPermission.Admin, "qshoveyl@gmail.com", "shourov", "shovel101", "Knot Jack")
        Await db.SetUserAsync(shovel).ConfigureAwait(False)

        Dim jack = New LampUser(GetNewGuid(), UserPermission.Admin, "jackywathyy123@gmail.com", "moji", "snack time", "shovel tool")
        Await db.SetUserAsync(jack).ConfigureAwait(False)

        ' add new templates 
        For Each spfName As String In ExampleSpfFiles
            Dim fp = IO.Path.GetFullPath(IO.Path.Combine("../", "../", "../", "templates", "spf", spfName))
            Dim template = Await LampTemplate.FromFileAsync(fp)
            Await db.SetTemplateAsync(template, shovel.UserId, shovel.UserId).ConfigureAwait(False)
        Next




        Dim templates = Await db.GetAllTemplateAsync.ConfigureAwait(False)

        ' add jobs
        Dim job As New LampJob(templates(0), max.ToProfile)
        Await db.SetJobAsync(job).ConfigureAwait(False)

        job = New LampJob(templates(1), shovel.ToProfile)
        Await db.SetJobAsync(job).ConfigureAwait(False)
    End Function

    Public Sub FillDebugDatabase()
        FillDebugDatabase(Me)
    End Sub




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

            Return Convert.ToBoolean(Await sqlite_cmd.ExecuteNonQueryAsync().ConfigureAwait(False))
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
        Using stream As New MemoryStream(binary)
            Return Image.FromStream(stream)
        End Using
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

    Public Shared Function GetTemplateSqlFromSort(sort As LampSort) As String
        Select Case sort
            Case LampSort.SubmitDateAsc
                Return "ORDER BY template.submitDate ASC"
            Case LampSort.SubmitDateDesc
                Return "ORDER BY template.submitDate DESC"

            Case LampSort.TemplateNameAsc
                Return "ORDER BY template.Name ASC"
            Case LampSort.TemplateNameDesc
                Return "ORDER BY template.Name DESC"
            Case LampSort.NoSort
                Return ""

#If DEBUG Then
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(sort))
#Else
            Case Else
                Return ""
#End If


        End Select
    End Function

    Public Shared Function GetJobSqlFromSort(sort As LampSort) As String
        Select Case sort
            Case LampSort.SubmitDateAsc
                Return "ORDER BY jobs.submitDate ASC"
            Case LampSort.SubmitDateDesc
                Return "ORDER BY jobs.submitDate DESC"

            Case LampSort.TemplateNameAsc, LampSort.TemplateNameAsc
                Throw New ArgumentOutOfRangeException(NameOf(sort))

            Case LampSort.NoSort
                Return ""

#If DEBUG Then
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(sort))
#Else
            Case Else
                Return ""
#End If
        End Select
    End Function
End Class

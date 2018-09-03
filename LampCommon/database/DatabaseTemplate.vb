' Manipulate templates and dxf
Imports System.Drawing
Imports LampCommon.DatabaseHelper


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

    Public Function SelectDxf(guids As ICollection(Of String), Optional trans As SqliteTransactionWrapper = Nothing) As List(Of LampDxfDocument)
        Dim out As New List(Of LampDxfDocument)
        For Each guid In guids
            Dim doc = SelectDxf(guid)
            If doc Is Nothing Then
                ' at least 1 is missing, returning nothing!
                Return Nothing
            End If
            out.Add(doc)
        Next
        Return out
    End Function

    Public Async Function SelectDxfAsync(guids As ICollection(Of String), Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of List(Of LampDxfDocument))
        Dim tasks As New List(Of Task(Of LampDxfDocument))
        For Each guid In guids
            tasks.Add(SelectDxfAsync(guid, trans))
        Next
        Dim raw = Await Task.WhenAll(tasks)
        For Each doc In raw
            If doc Is Nothing Then
                Return Nothing
            End If
        Next
        Return raw.ToList
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

    Private Function SetDxf(drawings As List(Of LampDxfDocument), Optional optTrans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Transaction.LockTransaction), command = Connection.GetCommand(trans)

            For Each dwg In drawings
                If Not SetDxf(dwg.GUID, dwg, optTrans) Then
                    ' at least 1 failed
                    ' dont commit
                    Return False
                End If
            Next
            If optTrans Is Nothing Then
                trans.Commit()
            End If
            Return True

        End Using
    End Function

    Private Async Function SetDxfAsync(drawings As List(Of LampDxfDocument), Optional optTrans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Await Transaction.LockTransactionAsync.ConfigureAwait(False)), command = Connection.GetCommand(trans)

            For Each dwg In drawings
                If Not Await SetDxfAsync(dwg.GUID, dwg, optTrans).ConfigureAwait(False) Then
                    ' at least 1 failed
                    ' dont commit
                    Return False
                End If
            Next
            If optTrans Is Nothing Then
                trans.Commit()
            End If
            Return True

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
    ''' Removes from database based on guid
    ''' Also removes images by default, rmImages can be set to false to not
    ''' </summary>
    ''' <param name="guids">string list</param>
    ''' <returns>True=Removed, False=None found</returns>
    Private Function RemoveDxf(guids As ICollection(Of String), Optional optTrans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Transaction.LockTransaction), command = Connection.GetCommand(trans)
            For Each guid In guids
                If Not RemoveDxf(guid) Then
                    Return False
                End If
            Next
            If optTrans Is Nothing Then
                trans.Commit()
            End If
            Return True
        End Using
    End Function

    ''' <summary>
    ''' Removes from database based on guid
    ''' Also removes images by default, rmImages can be set to false to not
    ''' </summary>
    ''' <param name="guids">string list</param>
    ''' <returns>True=Removed, False=None found</returns>
    Private Async Function RemoveDxfAsync(guids As ICollection(Of String), Optional optTrans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Transaction.LockTransaction), command = Connection.GetCommand(trans)
            Dim tasks As New List(Of Task(Of Boolean))
            For Each guid In guids
                tasks.Add(RemoveDxfAsync(guid, trans))
            Next
            Dim results = Await Task.WhenAll(tasks).ConfigureAwait(False)
            For Each item In results
                If Not item Then
                    Return False
                    ' an error occured, dont commit!
                End If
            Next

            If optTrans Is Nothing Then
                trans.Commit()
            End If
            Return True
        End Using
    End Function

    ''' <summary>
    ''' gets a template's metadata
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <returns></returns>
    Public Function SelectTemplateData(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As LampTemplateMetadata
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
                    metadata.Width = reader.GetDouble(reader.GetOrdinal("length"))
                    metadata.Height = reader.GetDouble(reader.GetOrdinal("height"))
                    metadata.MaterialThickness = reader.GetDouble(reader.GetOrdinal("MaterialThickness"))

                    If Not reader.IsDBNull(reader.GetOrdinal("CreatorId")) Then
                        ' user might be deleted
                        metadata.CreatorProfile = SelectUser(reader.GetString(reader.GetOrdinal("CreatorId")))?.ToProfile
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("ApproverId")) Then
                        ' user might be deleted
                        metadata.ApproverProfile = SelectUser(reader.GetString(reader.GetOrdinal("ApproverId")))?.ToProfile
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
    Public Async Function SelectTemplateDataAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of LampTemplateMetadata)
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
                    metadata.Width = reader.GetDouble(reader.GetOrdinal("length"))
                    metadata.Height = reader.GetDouble(reader.GetOrdinal("height"))
                    metadata.MaterialThickness = reader.GetDouble(reader.GetOrdinal("MaterialThickness"))

                    If Not reader.IsDBNull(reader.GetOrdinal("CreatorId")) Then
                        metadata.CreatorProfile = (Await SelectUserAsync(reader.GetString(reader.GetOrdinal("CreatorId"))).ConfigureAwait(False))?.ToProfile
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("ApproverId")) Then
                        metadata.ApproverProfile = (Await SelectUserAsync(reader.GetString(reader.GetOrdinal("ApproverId"))).ConfigureAwait(False))?.ToProfile
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

            command.Parameters.AddWithValue("@length", template.Width)
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

            command.Parameters.AddWithValue("@length", template.Width)
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

    Private Function SelectDynamicText(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As IEnumerable(Of DynamicTextKey)
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand(trans)
            sqlite_cmd.CommandText = "SELECT dText from dynamicText WHERE guid = @guid"
            sqlite_cmd.Parameters.AddWithValue("@guid", guid)
            Dim results As String = sqlite_cmd.ExecuteScalar()

            If results IsNot Nothing Then
                Return DynamicTextKey.Deserialise(results)
            Else
                Return New List(Of DynamicTextKey)
            End If

        End Using
    End Function

    Private Async Function SelectDynamicTextAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of IEnumerable(Of DynamicTextKey))
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand(trans)
            sqlite_cmd.CommandText = "SELECT dText from dynamicText WHERE guid = @guid"
            sqlite_cmd.Parameters.AddWithValue("@guid", guid)
            Dim results As String = Await sqlite_cmd.ExecuteScalarAsync().ConfigureAwait(False)

            If results IsNot Nothing Then
                Return DynamicTextKey.Deserialise(results)
            Else
                Return New List(Of DynamicTextKey)
            End If


        End Using
    End Function

    Private Function SetDynamicText(guid As String, text As IEnumerable(Of DynamicTextKey), Optional trans As SqliteTransactionWrapper = Nothing) As Integer
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "INSERT OR REPLACE INTO dynamicText
                    (Guid, dText)
                    VALUES
                    (@guid, @dynamicKey);"

            Dim insertedRows As Integer = 0
            command.Parameters.AddWithValue("@guid", guid)
            command.Parameters.AddWithValue("@dynamicKey", DynamicTextKey.Serialise(text))

            Return command.ExecuteNonQuery()
        End Using
    End Function


    Private Async Function SetDynamicTextAsync(guid As String, text As IEnumerable(Of DynamicTextKey), Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Integer)
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "INSERT OR REPLACE INTO dynamicText
                    (Guid, dText)
                    VALUES
                    (@guid, @dynamicKey);"

            Dim insertedRows As Integer = 0
            command.Parameters.AddWithValue("@guid", guid)
            command.Parameters.AddWithValue("@dynamicKey", DynamicTextKey.Serialise(text))

            Return Await command.ExecuteNonQueryAsync().ConfigureAwait(False)
        End Using
    End Function

    Private Function RemoveDynamicText(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Integer
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand(trans)
            sqlite_cmd.CommandText = "DELETE from dynamicText WHERE guid = @guid"
            sqlite_cmd.Parameters.AddWithValue("@guid", guid)
            Return sqlite_cmd.ExecuteNonQuery()
        End Using
    End Function

    Private Async Function RemoveDynamicTextAsync(guid As String, Optional trans As SqliteTransactionWrapper = Nothing) As Task(Of Integer)
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand(trans)
            sqlite_cmd.CommandText = "DELETE from dynamicText WHERE guid = @guid"
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
            Dim data = SelectTemplateData(guid, trans)
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

                ' get all dynamicText from db as well
                For Each dyn In SelectDynamicText(guid, trans)
                    template.DynamicTextList.Add(dyn)
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
            Dim data = Await SelectTemplateDataAsync(guid, trans).ConfigureAwait(False)
            Dim template As LampTemplate = If(data IsNot Nothing, data.ToLampTemplate, Nothing)

            If template IsNot Nothing Then
                Dim dxfTask = SelectDxfAsync(guid, trans)
                Dim imageTask = SelectImagesAsync(guid, trans)
                Dim tagTask = SelectTagsAsync(guid, trans)
                Dim dynTask = SelectDynamicTextAsync(guid, trans)

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

                ' get all dynamicText from db as well
                For Each dyn In dynTask.Result
                    template.DynamicTextList.Add(dyn)
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

                    ' clear tags if any exist
                    RemoveTags(template.GUID, trans)
                    If template.Tags.Count > 0 Then
                        SetTags(template.GUID, template.Tags, trans)
                    End If

                    ' write dynamicText
                    RemoveDynamicText(template.GUID, trans)
                    If template.DynamicTextList.Count > 0 Then
                        SetDynamicText(template.GUID, template.DynamicTextList, trans)
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

                    Await RemoveTagsAsync(template.GUID, trans).ConfigureAwait(False)
                    If template.Tags.Count > 0 Then
                        Await SetTagsAsync(template.GUID, template.Tags, trans).ConfigureAwait(False)
                    End If

                    ' write dynamicText
                    Await RemoveDynamicTextAsync(template.GUID, trans).ConfigureAwait(False)
                    If template.DynamicTextList.Count > 0 Then
                        Await SetDynamicTextAsync(template.GUID, template.DynamicTextList, trans).ConfigureAwait(False)
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
                    RemoveDynamicText(guid, trans)

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
                    Await Task.WhenAll(RemoveImagesAsync(guid, trans), RemoveTagsAsync(guid, trans), RemoveDynamicTextAsync(guid, optTrans)).ConfigureAwait(False)


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
    ''' Sets or unsets the approver of a template
    ''' if a template has an approver of nothing, it is counted as not approved
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="approver"></param>
    ''' <returns>True if found, false if not updated (no template)</returns>
    Public Function SetTemplateApprover(guid As String, approver As String) As Boolean
        Using conn = Connection.OpenConnection, command = Connection.GetCommand()
            command.CommandText = "UPDATE template SET approverId = @approverId"
            command.Parameters.AddWithValue("@approverId", approver)

            Return Convert.ToBoolean(command.ExecuteNonQuery())
        End Using
    End Function

    ''' <summary>
    ''' Sets or unsets the approver of a template
    ''' if a template has an approver of nothing, it is counted as not approved
    ''' </summary>
    ''' <param name="guid"></param>
    ''' <param name="approver"></param>
    ''' <returns>True if found, false if not updated (no template)</returns>
    Public Async Function SetTemplateApproverAsync(guid As String, approver As String) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, sqlite_cmd = Connection.GetCommand()
            sqlite_cmd.CommandText = "UPDATE template SET approverId = @approverId"
            sqlite_cmd.Parameters.AddWithValue("@approverId", approver)

            Return Convert.ToBoolean(Await sqlite_cmd.ExecuteNonQueryAsync().ConfigureAwait(False))
        End Using
    End Function

End Class
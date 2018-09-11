Imports System.Data.SQLite
Imports System.Drawing
Imports System.IO
' constructor and instance variables
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
                                  UserId Text Not Null UNIQUE,
                                  email Text Not Null UNIQUE,
                                  Username text Not NULL UNIQUE,

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
                                  boundsLock Int DEFAULT FALSE NOT NULL,
                                    
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
                                  completeDrawingId TEXT not NULL,
                                  submitterId Text Not NULL,
                                  approverId Text,
                                  summary Text Not null,
                                  submitDate Text Not null,

                                  FOREIGN KEY(submitterId) REFERENCES users(UserId),
                                  FOREIGN KEY(approverId) REFERENCES users(UserId),
                                  FOREIGN KEY(templateId) REFERENCES template(guid)
                                  ) WITHOUT rowId;"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

            command.CommandText = "CREATE TABLE if not exists dynamicText (
                                  guid Text PRIMARY KEY Not Null,
                                  dText Text Not NULL,
                                  FOREIGN KEY(guid) REFERENCES template(UserId)
                                 
                                  );"
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
                                  UserId Text Not Null UNIQUE,
                                  email Text Not Null UNIQUE,
                                  Username text Not NULL UNIQUE,

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
                                  boundsLock Int DEFAULT FALSE NOT NULL,

                                    
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
                                  completeDrawingId TEXT not NULL,
                                  submitterId Text Not NULL,
                                  approverId Text,
                                  summary Text Not null,
                                  submitDate Text Not null,

                                  FOREIGN KEY(submitterId) REFERENCES users(UserId),
                                  FOREIGN KEY(approverId) REFERENCES users(UserId),
                                  FOREIGN KEY(templateId) REFERENCES template(guid)
                                  ) WITHOUT rowId;"
            tasks.Add(command.ExecuteNonQueryAsync())

            command.CommandText = "CREATE TABLE if not exists dynamicText (
                                  guid Text PRIMARY KEY Not Null,
                                  dText Text Not NULL,
                                  FOREIGN KEY(guid) REFERENCES template(UserId)
                                 
                                  );"
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

            command.CommandText = "DROP TABLE If exists template;"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))


            command.CommandText = "DROP TABLE If exists jobs;"
            results.Add(Convert.ToBoolean(command.ExecuteNonQuery()))

            command.CommandText = "DROP TABLE If exists users;"
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

            command.CommandText = "DROP TABLE If exists template"
            tasks.Add(command.ExecuteNonQueryAsync())

            command.CommandText = "DROP TABLE If exists jobs"
            tasks.Add(command.ExecuteNonQueryAsync())

            command.CommandText = "DROP TABLE If exists users;"
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
            Dim job As New LampJob(templates(0), max.ToProfile, "job description")
            db.SetJob(job)

            job = New LampJob(templates(1), shovel.ToProfile, "please cut these trophies")
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

            Dim shovel = New LampUser(GetNewGuid(), UserPermission.Admin, "qshoveyl@gmail.com", "shourov", "shovel101", "not jack")
            Await db.SetUserAsync(shovel).ConfigureAwait(False)

            Dim jack = New LampUser(GetNewGuid(), UserPermission.Admin, "jackywathyy123@gmail.com", "moji", "snack time", "shovel tool")
            Await db.SetUserAsync(jack).ConfigureAwait(False)

            Dim standard = New LampUser(GetNewGuid(), UserPermission.Standard, "example@google.com", "standard", "1234", "examply gy")
            Await db.SetUserAsync(standard).ConfigureAwait(False)

            ' add new templates 
            For Each spfName As String In ExampleSpfFiles
                Dim fp = IO.Path.GetFullPath(IO.Path.Combine("../", "../", "../", "templates", "spf", spfName))
                Dim template = Await LampTemplate.FromFileAsync(fp)
                Await db.SetTemplateAsync(template, shovel.UserId, shovel.UserId).ConfigureAwait(False)
            Next




            Dim templates = Await db.GetAllTemplateAsync.ConfigureAwait(False)

            ' add jobs
            Dim job As New LampJob(templates(0), max.ToProfile, "job description")
            Await db.SetJobAsync(job).ConfigureAwait(False)

            job = New LampJob(templates(1), shovel.ToProfile, "please cut these trophies")
            Await db.SetJobAsync(job).ConfigureAwait(False)
        End Function

        Public Sub FillDebugDatabase()
            FillDebugDatabase(Me)
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

    Public Shared Function GetTableName(orderby As LampTemplateSort) As String
        Select Case orderby
            Case LampTemplateSort.SubmitDateAsc, LampTemplateSort.SubmitDateDesc
                Return ", template.submitDate"
            Case LampTemplateSort.TemplateNameAsc, LampTemplateSort.TemplateNameDesc
                Return ", template.name"
            Case LampTemplateSort.NoSort
                Return ""
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(orderby))
        End Select
    End Function

    Public Shared Function GetTemplateSqlFromSort(sort As LampTemplateSort) As String
        Select Case sort
            Case LampTemplateSort.SubmitDateAsc
                Return "ORDER BY template.submitDate ASC"
            Case LampTemplateSort.SubmitDateDesc
                Return "ORDER BY template.submitDate DESC"

            Case LampTemplateSort.TemplateNameAsc
                Return "ORDER BY template.Name COLLATE NOCASE ASC"
            Case LampTemplateSort.TemplateNameDesc
                Return "ORDER BY template.Name COLLATE NOCASE DESC"
            Case LampTemplateSort.NoSort
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

    Public Shared Function GetJobSqlFromSort(sort As LampJobSort) As String
        Select Case sort
            Case LampJobSort.SubmitDateAsc
                Return "ORDER BY jobs.submitDate ASC"
            Case LampJobSort.SubmitDateDesc
                Return "ORDER BY jobs.submitDate DESC"
            Case LampJobSort.JobSummaryAsc
                Return "ORDER BY jobs.summary COLLATE NOCASE ASC"
            Case LampJobSort.JobSummaryDesc
                Return "ORDER BY jobs.summary COLLATE NOCASE DESC"
            Case LampJobSort.NoSort
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

    Public Shared Function GetUserSqlFromSort(sort As LampUserSort) As String
        Select Case sort
            Case LampUserSort.NameAsc
                Return "ORDER BY users.name COLLATE NOCASE ASC"
            Case LampUserSort.NameDesc
                Return "ORDER BY users.name COLLATE NOCASE DESC"
            Case LampUserSort.UserNameAsc
                Return "ORDER BY users.Username COLLATE NOCASE ASC"
            Case LampUserSort.UserNameDesc
                Return "ORDER BY users.Username COLLATE NOCASE DESC"
    ' email support
            Case LampJobSort.NoSort
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

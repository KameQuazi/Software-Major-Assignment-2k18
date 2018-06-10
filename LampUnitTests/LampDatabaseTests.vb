Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert
Imports LampService
Imports LampCommon
Imports System.Data.SQLite

<TestClass()>
Public Class LampDatabaseTests
    Private TemplateTableName As String = "template"
    Private ReadOnly databasePath As String = "testTables.sqlite"

    Private database As New TemplateDatabase(databasePath)

    <TestInitialize>
    Public Sub Initialize()
        ResetDatabase()

    End Sub

    Private Structure ColumnDescriptor
        Public cid As Integer
        Public name As String
        Public notnull As Boolean
        Public [default] As Object
        Public [pk] As Boolean
        Public type As String
        Sub New(cid As Integer, name As String, type As String, notnull As Integer, [default] As String, pk As Integer)
            Me.cid = cid
            Me.name = name
            Me.notnull = notnull
            Me.default = [default]
            Me.pk = pk
            Me.type = type
        End Sub
    End Structure

    Private Function GetTemplateTableMetadata(reader As SQLite.SQLiteDataReader) As ColumnDescriptor
        reader.Read()
        Dim cid = reader.GetInt32(0)
        Dim name = reader.GetString(1)
        Dim type = reader.GetString(2)
        Dim notnull = reader.GetBoolean(3)
        Dim [default] = reader.GetValue(4)
        Select Case [default].GetType()
            Case GetType(System.DBNull)
                [default] = Nothing
        End Select

        Dim pk = reader.GetBoolean(5)
        Return New ColumnDescriptor(cid, name, type, notnull, [default], pk)
    End Function

    <TestMethod()>
    Public Sub ResetDatabase()
        If IO.File.Exists(databasePath) Then
            SQLiteConnection.ClearAllPools()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            IO.File.Delete(databasePath)
        End If

        database.RemoveTables()
        database.CreateTables()
    End Sub



    ' Execute Pragma table_info(template)
    ' to get all the column info 
    <TestMethod()>
    Public Sub TestDatabaseSchema()
        Using conn = database.Connection.OpenConnection(), command = conn.GetCommand
            command.CommandText = "Pragma table_info(template)"
            Using data = command.ExecuteReader()

                Dim guid = GetTemplateTableMetadata(data)
                AreEqual(0, guid.cid)
                AreEqual("guid", guid.name.ToLower())
                AreEqual("text", guid.type.ToLower())
                AreEqual(True, guid.notnull)
                AreEqual(Nothing, guid.default)
                AreEqual(True, guid.pk)

                Dim name = GetTemplateTableMetadata(data)
                AreEqual(1, name.cid)
                AreEqual("name", name.name.ToLower())
                AreEqual("text", name.type.ToLower())
                AreEqual(True, name.notnull)
                AreEqual("''", name.default)
                AreEqual(False, name.pk)

                Dim shortDescription = GetTemplateTableMetadata(data)
                AreEqual(2, shortDescription.cid)
                AreEqual("shortdescription", shortDescription.name.ToLower())
                AreEqual("text", shortDescription.type.ToLower())
                AreEqual(True, shortDescription.notnull)
                AreEqual("''", shortDescription.default)
                AreEqual(False, shortDescription.pk)

                Dim longDescription = GetTemplateTableMetadata(data)
                AreEqual(3, longDescription.cid)
                AreEqual("longdescription", longDescription.name.ToLower())
                AreEqual("text", longDescription.type.ToLower())
                AreEqual(True, longDescription.notnull)
                AreEqual("''", longDescription.default)
                AreEqual(False, longDescription.pk)

                Dim mat = GetTemplateTableMetadata(data)
                AreEqual(4, mat.cid)
                AreEqual("material", mat.name.ToLower())
                AreEqual("text", mat.type.ToLower())
                AreEqual(True, mat.notnull)
                AreEqual("'none'", mat.default)
                AreEqual(False, mat.pk)

                Dim length = GetTemplateTableMetadata(data)
                AreEqual(5, length.cid)
                AreEqual("length", length.name.ToLower())
                AreEqual("real", length.type.ToLower())
                AreEqual(True, length.notnull)
                AreEqual(-1, length.default, 0.01)
                AreEqual(False, length.pk)

                Dim height = GetTemplateTableMetadata(data)
                AreEqual(6, height.cid)
                AreEqual("height", height.name.ToLower())
                AreEqual("real", height.type.ToLower())
                AreEqual(True, height.notnull)
                AreEqual(-1, height.default, 0.01)
                AreEqual(False, height.pk)


                Dim materialThickness = GetTemplateTableMetadata(data)
                AreEqual(7, materialThickness.cid)
                AreEqual("materialthickness", materialThickness.name.ToLower())
                AreEqual("real", materialThickness.type.ToLower())
                AreEqual(True, materialThickness.notnull)
                AreEqual(-1, materialThickness.default, 0.01)
                AreEqual(False, materialThickness.pk)

                Dim creatorId = GetTemplateTableMetadata(data)
                AreEqual(8, creatorId.cid)
                AreEqual("creatorid", creatorId.name.ToLower())
                AreEqual("text", creatorId.type.ToLower())
                AreEqual(False, creatorId.notnull)
                AreEqual(Nothing, creatorId.default)
                AreEqual(False, creatorId.pk)

                Dim approverId = GetTemplateTableMetadata(data)
                AreEqual(9, approverId.cid)
                AreEqual("approverid", approverId.name.ToLower())
                AreEqual("text", approverId.type.ToLower())
                AreEqual(False, approverId.notnull)
                AreEqual(Nothing, approverId.default)
                AreEqual(False, approverId.pk)
            End Using
        End Using

    End Sub



    <TestMethod()>
    Public Sub TestTemplateFileSave()
        Dim temp As New LampTemplate()
        temp.Save("test.spf")
        Dim fromFile = LampTemplate.FromFile("test.spf")
        AreEqual(temp.GUID, fromFile.GUID)
    End Sub


    <TestMethod()>
    Public Async Function TestConnectionClosed() As Task

        For i = 1 To RepeatConnectionTestTimes
            With Nothing ' test database creation / deletion
                Using database.Connection.OpenConnection
                    database.RemoveTables()
                    database.CreateTables()

                End Using
            End With

            With Nothing ' test select and adding template
                Using database.Connection.OpenConnection
                    Dim temp As New LampTemplate
                    database.SetTemplate(temp)
                    AreEqual(temp.GUID, database.SelectTemplate(temp.GUID).GUID)
                    AreEqual(temp.GUID, (Await database.SelectTemplateAsync(temp.GUID)).GUID)
                End Using
            End With


        Next
    End Function


    <TestMethod()>
    Public Async Function TestTemplates() As Task

        Using conn = database.Connection.OpenConnection
            Dim tasks As New List(Of Task(Of Boolean))
            For i = 1 To 10
                tasks.Add(database.SetTemplateAsync(New LampTemplate))
            Next
            Await Task.WhenAll(tasks)

        End Using

        Dim test As New LampTemplate("0123-4567-8901-2345")
        test.Height = 199
        test.Length = 30004.4
        test.Material = "Thicc wood"
        test.MaterialThickness = 800000
        Dim result = Await database.SetTemplateAsync(test)
        AreEqual(True, result)

        Dim template = Await database.SelectTemplateAsync(test.GUID)


        AreEqual(test.GUID, template.GUID)
        AreEqual(test.Height, template.Height)
        AreEqual(test.Length, template.Length)
        AreEqual(test.Material, template.Material)
        AreEqual(test.MaterialThickness, template.MaterialThickness)

    End Function

    <TestMethod()>
    Public Sub TestUsers()
        Dim user As New LampUser(NewGuid, UserPermission.Admin, "email@gmail.com", "jackywathy", "abcd1234", "testuser")
        database.SetUser(user)
        database.SelectUser(user.UserId)
    End Sub

    <TestMethod()>
    Public Async Function TestOrder() As Task

        TestDatabaseSchema()
        Await TestConnectionClosed()
        TestUsers()
        TestUsers()
        TestUsers()
        Await TestTemplates()
    End Function

    Private RepeatConnectionTestTimes As Integer = 5

    Private BenchmarkRepeatTimes As Integer = 100

    <TestMethod>
    Public Sub BenchmarkSyncTemplateInsert()
        For i = 1 To BenchmarkRepeatTimes
            database.SetTemplate(New LampTemplate(NewGuid()))
        Next
    End Sub

    <TestMethod>
    Public Async Function BenchmarkAsyncTemplateInsert() As Task
        Dim tasks As New List(Of Task(Of Boolean))
        For i = 1 To BenchmarkRepeatTimes
            tasks.Add(database.SetTemplateAsync(New LampTemplate(NewGuid())))
        Next
        Await Task.WhenAll(tasks)
    End Function

    <TestMethod>
    Public Sub BenchmarkSyncTemplateInsertTransation()
        Using conn = database.Connection.OpenConnection, trans = database.Transaction.LockTransaction()
            For i = 1 To BenchmarkRepeatTimes
                database.SetTemplate(New LampTemplate(NewGuid()), optTrans:=trans)
            Next
            trans.Commit()
        End Using
    End Sub

    <TestMethod>
    Public Async Function BenchmarkAsyncTemplateInsertTransation() As Task
        Dim tasks As New List(Of Task(Of Boolean))
        Using conn = database.Connection.OpenConnection, trans = database.Transaction.LockTransaction()

            For i = 1 To BenchmarkRepeatTimes
                tasks.Add(database.SetTemplateAsync(New LampTemplate(NewGuid()), optTrans:=trans))
            Next

            Await Task.WhenAll(tasks)
            trans.Commit()
        End Using

    End Function

    <TestMethod>
    Public Sub TestJobs()
        ' TODO jobs
    End Sub
End Class

Public Module owo
    Public Function NewGuid() As String
        Return Guid.NewGuid.ToString()
    End Function
End Module
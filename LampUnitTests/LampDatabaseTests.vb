﻿Imports LAMP
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass()>
Public Class LampDatabaseTests
    Private TemplateTableName As String = "template"
    Private ReadOnly databasePath As String = "testTables.sqlite"

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

    Private Function GetColumnInformation(reader As SQLite.SQLiteDataReader) As ColumnDescriptor
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
            IO.File.Delete(databasePath)
        End If

        Dim database As New TemplateDatabase(databasePath)
        database.DeleteTables()
        database.CreateTables()
    End Sub



    ' Execute Pragma table_info(template)
    ' to get all the column info 
    <TestMethod()>
    Public Sub TestDatabaseCreation()
        Dim database As New TemplateDatabase(databasePath)
        database.OpenDatabase()
        Try
            Using command = database.GetCommand()
                command.CommandText = String.Format("Pragma table_info(template)", TemplateTableName)


                Using data = command.ExecuteReader()

                    Dim guid = GetColumnInformation(data)
                    AreEqual(0, guid.cid)
                    AreEqual("guid", guid.name.ToLower())
                    AreEqual("text", guid.type.ToLower())
                    AreEqual(True, guid.notnull)
                    AreEqual(Nothing, guid.default)
                    AreEqual(True, guid.pk)

                    Dim dxf = GetColumnInformation(data)
                    AreEqual(1, dxf.cid)
                    AreEqual("dxf", dxf.name.ToLower())
                    AreEqual("text", dxf.type.ToLower())
                    AreEqual(True, dxf.notnull)
                    AreEqual(Nothing, dxf.default)
                    AreEqual(False, dxf.pk)

                    Dim name = GetColumnInformation(data)
                    AreEqual(2, name.cid)
                    AreEqual("name", name.name.ToLower())
                    AreEqual("text", name.type.ToLower())
                    AreEqual(True, name.notnull)
                    AreEqual("''", name.default)
                    AreEqual(False, name.pk)

                    Dim shortDescription = GetColumnInformation(data)
                    AreEqual(3, shortDescription.cid)
                    AreEqual("shortdescription", shortDescription.name.ToLower())
                    AreEqual("text", shortDescription.type.ToLower())
                    AreEqual(True, shortDescription.notnull)
                    AreEqual("''", shortDescription.default)
                    AreEqual(False, shortDescription.pk)

                    Dim longDescription = GetColumnInformation(data)
                    AreEqual(4, longDescription.cid)
                    AreEqual("longdescription", longDescription.name.ToLower())
                    AreEqual("text", longDescription.type.ToLower())
                    AreEqual(True, longDescription.notnull)
                    AreEqual("''", longDescription.default)
                    AreEqual(False, longDescription.pk)

                    Dim mat = GetColumnInformation(data)
                    AreEqual(5, mat.cid)
                    AreEqual("material", mat.name.ToLower())
                    AreEqual("text", mat.type.ToLower())
                    AreEqual(True, mat.notnull)
                    AreEqual("'none'", mat.default)
                    AreEqual(False, mat.pk)

                    Dim length = GetColumnInformation(data)
                    AreEqual(6, length.cid)
                    AreEqual("length", length.name.ToLower())
                    AreEqual("real", length.type.ToLower())
                    AreEqual(True, length.notnull)
                    AreEqual(-1, length.default, 0.01)
                    AreEqual(False, length.pk)

                    Dim height = GetColumnInformation(data)
                    AreEqual(7, height.cid)
                    AreEqual("height", height.name.ToLower())
                    AreEqual("real", height.type.ToLower())
                    AreEqual(True, height.notnull)
                    AreEqual(-1, height.default, 0.01)
                    AreEqual(False, height.pk)


                    Dim materialThickness = GetColumnInformation(data)
                    AreEqual(8, materialThickness.cid)
                    AreEqual("materialthickness", materialThickness.name.ToLower())
                    AreEqual("real", materialThickness.type.ToLower())
                    AreEqual(True, materialThickness.notnull)
                    AreEqual(-1, materialThickness.default, 0.01)
                    AreEqual(False, materialThickness.pk)

                    Dim creatorName = GetColumnInformation(data)
                    AreEqual(9, creatorName.cid)
                    AreEqual("creatorname", creatorName.name.ToLower())
                    AreEqual("text", creatorName.type.ToLower())
                    AreEqual(True, creatorName.notnull)
                    AreEqual("''", creatorName.default)
                    AreEqual(False, creatorName.pk)

                    Dim creatorId = GetColumnInformation(data)
                    AreEqual(10, creatorId.cid)
                    AreEqual("creatorid", creatorId.name.ToLower())
                    AreEqual("text", creatorId.type.ToLower())
                    AreEqual(True, creatorId.notnull)
                    AreEqual("'0000-0000-0000-0000'", creatorId.default)
                    AreEqual(False, creatorId.pk)
                End Using
            End Using

        Finally
            database.CloseDatabase()
            TestConnectionClosed()
        End Try
    End Sub

    <TestMethod()>
    Public Sub TestTemplate()
        Dim temp As New LampTemplate()
        temp.Save("test.spf")
        temp = LampTemplate.FromFile("test.spf")

    End Sub

    <TestMethod()>
    Public Sub TestConnectionClosed()

        For i = 0 To RepeatConnectionTestTimes - 1
            With Nothing ' test database creation / deletion
                Dim db As New TemplateDatabase
                db.OpenDatabase()
                db.CreateTables()
                db.DeleteTables()
                db.CloseDatabase()
            End With

            With Nothing ' test select and adding template
                Dim db As New TemplateDatabase
                Dim temp As New LampTemplate
                db.AddTemplate(temp)
                db.SelectTemplate(temp.GUID)
            End With


        Next
    End Sub

    <TestMethod()>
    Public Sub TestUsers()
        Dim db As New TemplateDatabase
        Dim user As New LampUser("email@gmail.com", "jackywathy", "abcd1234", NewGuid, UserPermission.Admin)
        db.AddUser(user)
        db.SelectUser(user.UserId)
    End Sub

    Private RepeatConnectionTestTimes = 3

End Class

Public Module owo
    Public Function NewGuid()
        Return Guid.NewGuid.ToString()
    End Function
End Module
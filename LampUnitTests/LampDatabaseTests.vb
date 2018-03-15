Imports LAMP
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass()>
Public Class LampTemplateText
    Private TemplateTableName As String = "template"


    Private Structure ColumnDescriptor
        Public cid As Integer
        Public name As String
        Public notnull As Integer
        Public [default] As String
        Public [pk] As Integer
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
        Dim notnull = reader.GetInt32(3)
        Dim [default] = reader.GetValue(4).ToString()

        Dim pk = reader.GetInt32(5)
        Return New ColumnDescriptor(cid, name, type, notnull, [default], pk)
    End Function


    ' Execute Pragma table_info(template)
    ' to get all the column info 
    <TestMethod()>
    Public Sub TestDatabaseCreation()
        Dim database As New TemplateDatabase("testTables.sqlite")
        Dim conn = database.GetConnection()
        conn.Open()

        Dim command = conn.CreateCommand
        command.CommandText = String.Format("Pragma table_info(template)", TemplateTableName)


        Dim data = command.ExecuteReader()

        Dim guid = GetColumnInformation(data)
        AreEqual(guid.cid, 0)
        AreEqual(guid.name.ToLower(), "guid")
        AreEqual(guid.type.ToLower(), "text")
        AreEqual(guid.notnull, 1)
        AreEqual(guid.default, "")
        AreEqual(guid.pk, 1)

        Dim dxf = GetColumnInformation(data)
        AreEqual(dxf.cid, 1)
        AreEqual(dxf.name.ToLower(), "dxf")
        AreEqual(dxf.type.ToLower(), "text")
        AreEqual(dxf.notnull, 1)
        AreEqual(dxf.default, "")
        AreEqual(dxf.pk, 0)

        Dim tag = GetColumnInformation(data)
        AreEqual(tag.cid, 2)
        AreEqual(tag.name.ToLower(), "tag")
        AreEqual(tag.type.ToLower(), "text")
        AreEqual(tag.notnull, 1)
        AreEqual(tag.default, "")
        AreEqual(tag.pk, 0)

        Dim mat = GetColumnInformation(data)
        AreEqual(mat.cid, 3)
        AreEqual(mat.name.ToLower(), "material")
        AreEqual(mat.type.ToLower(), "text")
        AreEqual(mat.notnull, 1)
        AreEqual(mat.default, "")
        AreEqual(mat.pk, 0)

        Dim length = GetColumnInformation(data)
        AreEqual(length.cid, 4)
        AreEqual(length.name.ToLower(), "length")
        AreEqual(length.type.ToLower(), "int")
        AreEqual(length.notnull, 1)
        AreEqual(length.default, "")
        AreEqual(length.pk, 0)

        conn.Close()





    End Sub

End Class
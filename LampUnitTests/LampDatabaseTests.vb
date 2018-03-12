Imports LAMP

<TestClass()> Public Class LampTemplateText

    Private TemplateTableName As String = "template"

    <TestMethod()>
    Public Sub TestDatabaseCreation()
        Dim database As New TemplateDatabase(":memory:")
        Dim conn = database.GetConnection()

        Dim command = conn.CreateCommand
        command.CommandText = String.Format("Pragma table_info({0})", TemplateTableName)

        Dim data = command.ExecuteReader()

        While data.Read()
            Dim cid = data.GetInt32(0)
            Dim name = data.GetString(1)
            Dim type = data.GetString(2)
            Dim notnull = data.GetInt32(3)
            Dim [default] = data.GetString(4)
            Dim pk = data.GetInt32(5)



        End While

    End Sub

End Class
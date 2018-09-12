Imports System.Data.Common
Imports System.Data.SQLite
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports LampCommon
Imports LampCommon.DatabaseHelper





Public Class TemplateDatabase
#Region "multiple template"
    Public Function GetMultipleTemplate(tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampTemplateSort) As List(Of LampTemplate)
        If tags Is Nothing OrElse tags.Count() = 0 Then
            Return GetTemplateList(byUser, limit, offset, approveStatus, orderBy)
        Else
            Return SelectTemplateWithTags(tags, byUser, limit, offset, approveStatus, orderBy)
        End If
    End Function

    Public Async Function GetMultipleTemplateAsync(tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampTemplateSort) As Task(Of List(Of LampTemplate))
        If tags Is Nothing OrElse tags.Count() = 0 Then
            Return Await GetTemplateListAsync(byUser, limit, offset, approveStatus, orderBy).ConfigureAwait(False)
        Else
            Return Await SelectTemplateWithTagsAsync(tags, byUser, limit, offset, approveStatus, orderBy).ConfigureAwait(False)
        End If
    End Function

    ''' <summary>
    ''' Gets a list of templates without tag filtering
    ''' </summary>
    ''' <param name="limit"></param>
    ''' <param name="offset"></param>
    ''' <param name="approveStatus"></param>
    ''' <returns></returns>
    Private Function GetTemplateList(byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampTemplateSort) As List(Of LampTemplate)
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingTemplates As New List(Of LampTemplate)

            Dim approveText = "1"
            Select Case approveStatus
                Case LampApprove.Approved
                    approveText = "approverId is not null"
                Case LampApprove.Unapproved
                    approveText = "approverId is null"
                Case LampApprove.All
                Case Else
                    Throw New ArgumentOutOfRangeException(NameOf(approveStatus))
            End Select



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
    ''' async version of <see cref="GetTemplateList(IEnumerable(Of String),Integer , Integer, LampApprove, LampTemplateSort)"></see>
    ''' </summary>
    ''' <param name="limit"></param>
    ''' <param name="offset"></param>
    ''' <param name="approveStatus"></param>
    ''' <returns></returns>
    Private Async Function GetTemplateListAsync(byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampTemplateSort) As Task(Of List(Of LampTemplate))
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingTemplates As New List(Of LampTemplate)

            Dim approveText = "1"
            Select Case approveStatus
                Case LampApprove.Approved
                    approveText = "approverId is not null"
                Case LampApprove.Unapproved
                    approveText = "approverId is null"
                Case LampApprove.All
                Case Else
                    Throw New ArgumentOutOfRangeException(NameOf(approveStatus))
            End Select

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
    Private Function SelectTemplateWithTags(tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampTemplateSort) As List(Of LampTemplate)
        ' If the databse is open already, dont close it

        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingTemplates As New List(Of LampTemplate)

            If tags.Count() = 0 Then
                Throw New Exception("must have at least 1 tag")
            End If

            Dim tagParameters As String = ""

            tagParameters += "@tag0"
            For i = 1 To tags.Count - 1
                tagParameters += ",@tag" + i.ToString()
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
            Select Case approveStatus
                Case LampApprove.Approved
                    approveText = "(SELECT 1 from template WHERE template.guid = tags.guid and approverId is not null)"
                Case LampApprove.Unapproved
                    approveText = "(SELECT 1 from template WHERE template.guid = tags.guid and approverId is null)"
                Case LampApprove.All

                Case Else
                    Throw New ArgumentOutOfRangeException(NameOf(approveStatus))
            End Select

            Dim stringCommand = String.Format("Select tags.guid {4} from tags INNER JOIN template ON template.guid=tags.guid
                                      WHERE {0} AND {1} AND {2}
                                      {3}
                                      LIMIT @limit
                                      OFFSET @offset
                                     ", tagString, approveText, userParameter, GetTemplateSqlFromSort(orderBy), GetTableName(orderBy))
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
    Private Async Function SelectTemplateWithTagsAsync(tags As IEnumerable(Of String), byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampTemplateSort) As Task(Of List(Of LampTemplate))
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingTemplates As New List(Of LampTemplate)

            If tags.Count() = 0 Then
                Throw New Exception("must have at least 1 tag")
            End If

            Dim tagParameters As String = ""

            tagParameters += "@tag0"
            For i = 1 To tags.Count - 1
                tagParameters += ",@tag" + i.ToString()
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
            Select Case approveStatus
                Case LampApprove.Approved
                    approveText = "(SELECT 1 from template WHERE template.guid = tags.guid and approverId is not null)"
                Case LampApprove.Unapproved
                    approveText = "(SELECT 1 from template WHERE template.guid = tags.guid and approverId is null)"
                Case LampApprove.All

                Case Else
                    Throw New ArgumentOutOfRangeException(NameOf(approveStatus))
            End Select

            Dim stringCommand = String.Format("Select tags.guid {4} from tags INNER JOIN template ON template.guid=tags.guid
                                      WHERE {0} AND {1} AND {2}
                                      {3}
                                      LIMIT @limit
                                      OFFSET @offset
                                     ", tagString, approveText, userParameter, GetTemplateSqlFromSort(orderBy), GetTableName(orderBy))
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


#End Region

#Region "Multile Job"
    Public Function GetMultipleJob(byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampJobSort) As List(Of LampJob)
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

            Dim approveParameter = "1"
            Select Case approveStatus
                Case LampApprove.All
                    approveParameter = "1"
                Case LampApprove.Approved
                    approveParameter = "approverId is not null"
                Case LampApprove.Unapproved
                    approveParameter = "approverId is null"
                Case Else
                    Throw New ArgumentOutOfRangeException(NameOf(approveStatus))
            End Select

            Dim stringCommand = String.Format("SELECT jobId FROM jobs WHERE {0} AND {1}
                                            {2}
                                            LIMIT @limit
                                            OFFSET @offset",
                                            userParameter, approveParameter, GetJobSqlFromSort(orderBy))
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

    Public Async Function GetMultipleJobAsync(byUser As IEnumerable(Of String), limit As Integer, offset As Integer, approveStatus As LampApprove, orderBy As LampJobSort) As Task(Of List(Of LampJob))
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
            Dim approveParameter = "1"
            Select Case approveStatus
                Case LampApprove.All
                    approveParameter = "1"
                Case LampApprove.Approved
                    approveParameter = "approverId is not null"
                Case LampApprove.Unapproved
                    approveParameter = "approverId is null"
                Case Else
                    Throw New ArgumentOutOfRangeException(NameOf(approveStatus))
            End Select


            Dim stringCommand = String.Format("SELECT jobId FROM jobs WHERE {0} AND {1}
                                            {2}
                                            LIMIT @limit
                                            OFFSET @offset",
                                            userParameter, approveParameter, GetJobSqlFromSort(orderBy))
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
#End Region

#Region "Multiple User"
    Public Function GetMultipleUser(limit As Integer, offset As Integer, orderBy As LampUserSort) As List(Of LampUser)
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingUsers As New List(Of LampUser)



            Dim stringCommand = String.Format("SELECT userId FROM users 
                                            {0} 
                                            LIMIT @limit
                                            OFFSET @offset",
                                            GetUserSqlFromSort(orderBy))
            command.CommandText = stringCommand

            command.Parameters.AddWithValue("@limit", limit)
            command.Parameters.AddWithValue("@offset", offset)



            Using sqlite_reader = command.ExecuteReader()
                While sqlite_reader.Read()
                    Dim guid = sqlite_reader.GetString(sqlite_reader.GetOrdinal("userId"))
                    matchingUsers.Add(SelectUser(guid))
                End While
            End Using

            Return matchingUsers
        End Using
    End Function

    Public Async Function GetMultipleUserAsync(limit As Integer, offset As Integer, orderBy As LampJobSort) As Task(Of List(Of LampUser))
        Using conn = Connection.OpenConnection(), command = Connection.GetCommand()
            Dim matchingUsers As New List(Of LampUser)



            Dim stringCommand = String.Format("SELECT userId FROM users WHERE
                                            {0}
                                            LIMIT @limit
                                            OFFSET @offset",
                                            GetUserSqlFromSort(orderBy))
            command.CommandText = stringCommand

            command.Parameters.AddWithValue("@limit", limit)
            command.Parameters.AddWithValue("@offset", offset)

            Using sqlite_reader = Await command.ExecuteReaderAsync().ConfigureAwait(False)
                While Await sqlite_reader.ReadAsync().ConfigureAwait(False)
                    Dim guid = sqlite_reader.GetString(sqlite_reader.GetOrdinal("userId"))
                    matchingUsers.Add(Await SelectUserAsync(guid).ConfigureAwait(False))
                End While

            End Using

            Return matchingUsers
        End Using
    End Function
#End Region




End Class



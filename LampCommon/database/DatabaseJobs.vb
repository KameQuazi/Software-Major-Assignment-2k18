Imports System.Data.Common
Imports System.Data.SQLite
Imports System.Drawing

' jobs
Partial Class TemplateDatabase

    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    Public Function SelectJob(jobId As String, Optional trans As SqliteTransactionWrapper = Nothing) As LampJob
        Using conn = Connection.OpenConnection, command = Connection.GetCommand(trans)
            command.CommandText = "Select templateId, submitterId, completeDrawingId, approverId, summary, submitDate from jobs 
                                          WHERE jobId = @jobId"
            command.Parameters.AddWithValue("@jobId", jobId)

            Using reader As SQLiteDataReader = command.ExecuteReader()
                Dim job As LampJob = Nothing
                If reader.Read() Then
                    Dim templateId = reader.GetString(reader.GetOrdinal("templateId"))
                    Dim template = SelectTemplate(templateId)
                    If template Is Nothing Then
                        Return Nothing
                    End If

                    Dim submitterId = reader.GetString(reader.GetOrdinal("submitterId"))

                    Dim approverId As String = Nothing
                    If Not reader.IsDBNull(reader.GetOrdinal("approverId")) Then
                        approverId = reader.GetString(reader.GetOrdinal("approverId"))
                    End If

                    Dim submitterP As LampProfile = Nothing
                    If submitterId IsNot Nothing Then
                        submitterP = SelectUser(submitterId, trans)?.ToProfile
                    End If

                    Dim approverP As LampProfile = Nothing
                    If approverId IsNot Nothing Then
                        approverP = SelectUser(approverId, trans)?.ToProfile
                    End If


                    Dim drawingGuids = DeserializeDrawingGuid(reader.GetString(reader.GetOrdinal("completeDrawingId")))
                    Dim completedDrawings = SelectDxf(drawingGuids)
                    If completedDrawings Is Nothing Then
                        Return Nothing
                    End If

                    Dim submitDate = reader.GetDateTime(reader.GetOrdinal("submitDate"))

                    Dim summary = reader.GetString(reader.GetOrdinal("summary"))

                    job = New LampJob(jobId, template, submitterP, approverP, summary, submitDate, completedDrawings)

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
            command.CommandText = "Select templateId, submitterId, completeDrawingId, approverId, summary, submitDate from jobs 
                                          WHERE jobId = @jobId"
            command.Parameters.AddWithValue("@jobId", jobId)
            ' todo ; put it in paralell!
            Using reader = Await command.ExecuteReaderAsync().ConfigureAwait(False)
                Dim job As LampJob = Nothing
                If Await reader.ReadAsync().ConfigureAwait(False) Then

                    Dim templateId = reader.GetString(reader.GetOrdinal("templateId"))
                    Dim template = Await SelectTemplateAsync(templateId).ConfigureAwait(False)
                    If template Is Nothing Then
                        Return Nothing
                    End If

                    Dim submitterId = reader.GetString(reader.GetOrdinal("submitterId"))

                    Dim approverId As String = Nothing
                    If Not reader.IsDBNull(reader.GetOrdinal("approverId")) Then
                        approverId = reader.GetString(reader.GetOrdinal("approverId"))
                    End If

                    ' TODO combine in 1 sql statement
                    Dim submitterP As LampProfile = Nothing
                    If submitterId IsNot Nothing Then
                        submitterP = (Await SelectUserAsync(submitterId, trans).ConfigureAwait(False))?.ToProfile
                    End If

                    Dim approverP As LampProfile = Nothing
                    If approverId IsNot Nothing Then
                        approverP = (Await SelectUserAsync(approverId, trans).ConfigureAwait(False))?.ToProfile
                    End If


                    Dim drawingGuids = DeserializeDrawingGuid(reader.GetString(reader.GetOrdinal("completeDrawingId")))
                    Dim completedDrawings = Await SelectDxfAsync(drawingGuids).ConfigureAwait(False)
                    If completedDrawings Is Nothing Then
                        Return Nothing
                    End If

                    Dim submitDate = reader.GetDateTime(reader.GetOrdinal("submitDate"))
                    Dim summary = reader.GetString(reader.GetOrdinal("summary"))
                    job = New LampJob(jobId, template, submitterP, approverP, summary, submitDate, completedDrawings)
                End If

                Return job
            End Using
        End Using
    End Function



    ''' <summary>
    ''' joins all the guid's into a commana seperated value
    ''' </summary>
    ''' <param name="list"></param>
    ''' <returns></returns>
    Private Function SerializeDrawingGuid(list As List(Of LampDxfDocument)) As String
        Return String.Join(",", list.Select(Function(x) x.GUID))
    End Function

    Private Function DeserializeDrawingGuid(joined As String) As List(Of String)
        If joined = String.Empty Then
            Return New List(Of String)
        End If
        Return joined.Split(",").ToList
    End Function

    ''' <summary>
    ''' Adds a job to the database, returns false if not inserted or not template in db
    ''' </summary>
    Public Function SetJob(job As LampJob, Optional optTrans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Transaction.LockTransaction), command = Connection.GetCommand(trans)
            Dim fromDb = SelectTemplateAsync(job.Template.GUID, optTrans)
            If fromDb Is Nothing Then ' add check for 2 templates equal
                Return False
            End If

            ' attempt to insert the completed drawing
            ' set the dxf
            If SetDxf(job.CompleteDrawings, trans) Then

                ' now set the job

                command.CommandText = "INSERT OR REPLACE INTO jobs
                    (jobId, templateId, completeDrawingId, submitterId, approverId, summary, submitDate)
                    VALUES
                    (@jobId, @templateId, @completeDrawingId, @submitterId, @approverId, @summary, DATETIME('now'));"


                command.Parameters.AddWithValue("@jobId", job.JobId)
                command.Parameters.AddWithValue("@templateId", job.Template.GUID)
                command.Parameters.AddWithValue("@submitterId", job.SubmitId)
                command.Parameters.AddWithValue("@approverId", job.ApproverId)
                command.Parameters.AddWithValue("@summary", job.Summary)
                command.Parameters.AddWithValue("@completeDrawingId", SerializeDrawingGuid(job.CompleteDrawings))

                If Convert.ToBoolean(command.ExecuteNonQuery()) Then
                    If optTrans Is Nothing Then
                        trans.Commit()
                    End If
                    Return True
                End If
            End If

            Return False

        End Using
    End Function

    ''' <summary>
    ''' Adds a job to the database, returns false if not inserted or no template in db
    ''' </summary>
    Public Async Function SetJobAsync(job As LampJob, Optional optTrans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Await Transaction.LockTransactionAsync), command = Connection.GetCommand(optTrans)
            Dim fromDb = Await SelectTemplateAsync(job.Template.GUID, optTrans).ConfigureAwait(False)
            If fromDb Is Nothing Then ' add check for 2 templates equal
                Return False
            End If

            ' attempt to insert the completed drawing
            ' set the dxf
            If Await SetDxfAsync(job.CompleteDrawings, trans).ConfigureAwait(False) Then

                ' now set the job

                command.CommandText = "INSERT OR REPLACE INTO jobs
                    (jobId, templateId, completeDrawingId, submitterId, approverId, summary, submitDate)
                    VALUES
                    (@jobId, @templateId, @completeDrawingId, @submitterId,  @approverId, @summary, DATETIME('now'));"


                command.Parameters.AddWithValue("@jobId", job.JobId)
                command.Parameters.AddWithValue("@templateId", job.Template.GUID)
                command.Parameters.AddWithValue("@submitterId", job.SubmitId)
                command.Parameters.AddWithValue("@approverId", job.ApproverId)
                command.Parameters.AddWithValue("@summary", job.Summary)
                command.Parameters.AddWithValue("@completeDrawingId", SerializeDrawingGuid(job.CompleteDrawings))

                If Convert.ToBoolean(Await command.ExecuteNonQueryAsync().ConfigureAwait(False)) Then
                    If optTrans Is Nothing Then
                        trans.Commit()
                    End If
                    Return True
                End If
            End If

            Return False

        End Using
    End Function

    ''' <summary>
    ''' Removes a job from the db
    ''' </summary>
    ''' <param name="jobId"></param>
    ''' <returns></returns>
    Public Function RemoveJob(jobId As String, Optional optTrans As SqliteTransactionWrapper = Nothing) As Boolean
        Using conn = Connection.OpenConnection, trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Transaction.LockTransaction), Command = Connection.GetCommand(trans)
            Dim job = SelectJob(jobId, trans)
            If job IsNot Nothing AndAlso RemoveDxf(job.CompleteDrawings.Select(Function(x) x.GUID).ToArray, trans) Then
                Command.CommandText = "DELETE from jobs WHERE jobId = @jobId"
                Command.Parameters.AddWithValue("@jobId", jobId)

                If Command.ExecuteNonQuery() Then
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
    ''' Removes a job from the db
    ''' </summary>
    ''' <param name="jobId"></param>
    ''' <returns></returns>
    Public Async Function RemoveJobAsync(jobId As String, Optional optTrans As SqliteTransactionWrapper = Nothing) As Task(Of Boolean)
        Using conn = Connection.OpenConnection, trans = If(optTrans IsNot Nothing, optTrans.UseTransaction, Await Transaction.LockTransactionAsync), command = Connection.GetCommand(trans)
            Dim job = Await SelectJobAsync(jobId, trans)

            If job IsNot Nothing AndAlso Await RemoveDxfAsync(job.CompleteDrawings.Select(Function(x) x.GUID).ToArray, trans) Then
                command.CommandText = "DELETE from jobs WHERE jobId = @jobId"
                command.Parameters.AddWithValue("@jobId", jobId)
                If Await command.ExecuteNonQueryAsync().ConfigureAwait(False) Then
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
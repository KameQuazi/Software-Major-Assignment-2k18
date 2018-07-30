Imports System.Data.Common
Imports System.Data.SQLite
Imports System.Drawing

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
    Public Function UniqueUser(user As LampUser, Optional trans As SqliteTransactionWrapper = Nothing) As LampStatus
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
End Class

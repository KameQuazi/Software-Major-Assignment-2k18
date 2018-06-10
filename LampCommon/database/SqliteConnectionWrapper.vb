Imports System.Data.SQLite
''' <summary>
''' Ensures the the db is open when needed
''' and closed when all are used
''' </summary>
Public Class SqliteConnectionWrapper
    Implements IDisposable

    ''' <summary>
    ''' raw Connection to the database
    ''' </summary>
    ''' <returns></returns>
    Public Property Connection As SQLiteConnection

    ''' <summary>
    ''' how many items are using the db right now
    ''' dont tocuh without first locking connection
    ''' </summary>
    Private RefCount As Integer = 0

    ''' <summary>
    ''' whether or not the db is opened / closed
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Opened As Boolean
        Get
            SyncLock Connection
                Return RefCount > 0
            End SyncLock
        End Get
    End Property

    ''' <summary>
    ''' decreases ref count / closes connection if needed
    ''' Do NOT call without at least 1 reference
    ''' </summary>
    Private Sub DecrementRef()
        SyncLock Connection
            If RefCount <= 0 Then
                Throw New Exception("refcount < 0?")
            End If

            RefCount -= 1
            If RefCount = 0 Then
                Connection.Close()
            End If

        End SyncLock
    End Sub

    ''' <summary>
    ''' Disposes.
    ''' If refcount reaches 0, it will close the db
    ''' </summary>
    Public Sub Dispose() Implements IDisposable.Dispose
        DecrementRef()
    End Sub

    ''' <summary>
    ''' Gets a reference to the sqliteconnection
    ''' </summary>
    ''' <returns></returns>
    Public Function OpenConnection() As SqliteConnectionWrapper
        SyncLock Connection
            If RefCount = 0 Then
                Connection.Open()
            End If
            RefCount += 1
        End SyncLock
        Return Me
    End Function

    Sub New(connection As SQLiteConnection)
        Me.Connection = connection
    End Sub


    Sub New(connectionString As String)
        Me.Connection = New SQLiteConnection(connectionString)
    End Sub

    Public Function GetCommand(Optional transaction As SqliteTransactionWrapper = Nothing) As SQLiteCommand
        If Opened = False Then
            Throw New Exception("Connection Not opened, run openConnection()")
        End If
        Dim command = Connection.CreateCommand
        If transaction IsNot Nothing Then
            command.Transaction = transaction.Transaction
        End If
        Return command
    End Function
End Class
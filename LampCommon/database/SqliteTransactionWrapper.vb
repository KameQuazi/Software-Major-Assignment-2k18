Imports System.Data.SQLite
Imports System.Threading

Public Class SqliteTransactionWrapper
    Implements IDisposable


    ''' <summary>
    ''' parent connection
    ''' </summary>
    ''' <returns></returns>
    Public Property Connection As SqliteConnectionWrapper

    ''' <summary>
    ''' how many items using this transaction
    ''' when reaches zero, it should clear
    ''' If recount = 0, it means transaction not being used by any objects
    ''' when the lock is acquired, the transaction is being used by refCount number of commands 
    ''' </summary>
    Private RefCount As Integer = 0

    ''' <summary>
    ''' ensures the transaction is only used in 1 by 1 transaction at a time
    ''' when the lock is acquired, the transaction is being used by refCount number of commands
    ''' </summary>
    Private lock As New SemaphoreSlim(1, 1)

    ''' <summary>
    ''' whether or not transaction was commited
    ''' if wrapper is completely disposed w/out being commited, will automatically rollback
    ''' MUST lock before changing
    ''' </summary>
    Private committed As Boolean = False

    Public Property Transaction As SQLiteTransaction

    Public Sub Dispose() Implements IDisposable.Dispose
        DecrementRef()
    End Sub

    Private Sub DecrementRef()
        SyncLock lock
            If RefCount <= 0 Then
                Throw New Exception("refcount {transaction?} <= 0?")
            End If

            RefCount -= 1
            If RefCount = 0 Then
                ' reset the transaction object

                If Not committed Then
                    Transaction.Rollback()
                End If
                Transaction.Dispose() ' dispose the object
                Transaction = Nothing
                committed = False
                lock.Release()
            End If
        End SyncLock
    End Sub

    Public Function LockTransaction() As SqliteTransactionWrapper
        lock.Wait()
        IncrementRef()
        Return Me
    End Function

    Public Async Function LockTransactionAsync() As Task(Of SqliteTransactionWrapper)
        Await lock.WaitAsync()
        IncrementRef()
        Return Me
    End Function

    Public Sub IncrementRef()
        SyncLock lock
            If RefCount = 0 Then
                ' make a new transaction
                Transaction = Connection.Connection.BeginTransaction()
            End If
            RefCount += 1
        End SyncLock
    End Sub

    Public Sub Commit()
        SyncLock lock
            If Not committed Then
                Transaction.Commit()
                committed = True
            Else
                Throw New Exception("multiple commits not supported")
            End If
        End SyncLock
    End Sub



    Sub New(connect As SqliteConnectionWrapper)
        Me.Connection = connect
    End Sub

    ''' <summary>
    ''' Doesn't lock the transcation, just increase the refcount 
    ''' checks if the transaction is already locked
    ''' </summary>
    ''' <returns></returns>
    Public Function UseTransaction() As SqliteTransactionWrapper
        SyncLock lock
            If RefCount = 0 Then
                Throw New Exception("transaction is not locked, therefore cannot be used")
            End If
            RefCount += 1
        End SyncLock
        Return Me
    End Function
End Class


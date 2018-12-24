Imports System.Data.SqlClient
''' <summary>
''' Provides standard provision for run time exception handling
''' </summary>
Public Class BaseExceptionsHandler
    ''' <summary>
    ''' Get/Set if there is a run time exception. Set this property to False before performing any operation that may throw and exception, set this property to True in a Try/Catch when an exception is thrown.
    ''' </summary>
    Protected mHasException As Boolean
    ''' <summary>
    ''' Indicate the last operation thrown an  exception or not. Call this method after an operation has been performed that may throw an exception.
    ''' </summary>
    ''' <returns>True if an exception had been raised, False if no exception has been raised.</returns>
    Public ReadOnly Property HasException() As Boolean
        Get
            Return mHasException
        End Get
    End Property
    ''' <summary>
    ''' Stores a runtime exception which is available throw <seealso cref="LastException"/> after a operation has completed.
    ''' </summary>
    Protected mLastException As Exception
    ''' <summary>
    ''' Provides access to the last exception thrown.
    ''' </summary>
    ''' <returns>Last <seealso cref="Exception"/> thrown</returns>
    ''' <remarks>Use <seealso cref="HasException"/> or <seealso cref="IsSuccessFul"/>  to determine if an exception was thrown first before calling this property </remarks>
    Protected ReadOnly Property LastException() As Exception
        Get
            Return mLastException
        End Get
    End Property
    ''' <summary>
    ''' Indicates if there was a sql related exception.
    ''' </summary>
    ''' <returns>True if the last exception has SqlClient related.</returns>
    Public ReadOnly Property HasSqlException() As Boolean
        Get
            If LastException IsNot Nothing Then
                Return TypeOf LastException Is SqlException
            Else
                Return False
            End If
        End Get
    End Property
    ''' <summary>
    ''' If you don't need the entire exception as in 
    ''' LastException this provides just the text of the exception
    ''' </summary>
    ''' <returns>Last exception message thrown. Use <seealso cref="HasException"/> or <seealso cref="IsSuccessFul"/>  to determine if an exception was thrown first before calling this property</returns>
    Public ReadOnly Property LastExceptionMessage() As String
        Get
            Return LastException.Message
        End Get
    End Property
    ''' <summary>
    ''' Indicate for return of a function if there was an exception thrown or not.
    ''' </summary>
    ''' <returns>True if the operation performed had no errors, False if errors were thrown</returns>
    Public ReadOnly Property IsSuccessFul() As Boolean
        Get
            Return Not HasException
        End Get
    End Property
End Class

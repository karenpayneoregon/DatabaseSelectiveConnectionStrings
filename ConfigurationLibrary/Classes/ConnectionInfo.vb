''' <summary>
''' Container for named database connections.
''' </summary>
Public Class ConnectionInfo
    ''' <summary>
    ''' Name of connection as per app.config
    ''' </summary>
    Public Property Name As String
    ''' <summary>
    ''' Returns the connection name
    ''' </summary>
    ''' <returns>Connection name</returns>
    Public Property ConnectionString As String
    ''' <summary>
    ''' Ordinal index in the collection for ProjectConnections
    ''' and not the ordinal in app.config
    ''' </summary>
    Public Property Index As Integer
    ''' <summary>
    ''' Returns name of connection
    ''' </summary>
    ''' <returns>Name</returns>
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
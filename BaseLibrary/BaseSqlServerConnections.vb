''' <summary>
''' Provides single point of access for a SQL-Server connection string
''' along with standard exception handling though <seealso cref="BaseExceptionsHandler"/>
''' </summary>
Public Class BaseSqlServerConnections
    Inherits BaseExceptionsHandler

    ''' <summary>
    ''' This points to your database server
    ''' </summary>
    Protected DatabaseServer As String = ""
    ''' <summary>
    ''' Name of database containing required tables which is a set/get property.
    ''' </summary>
    Protected DefaultCatalog As String = ""
    ''' <summary>
    ''' A connection string to connect to a SQL-Server instance and database
    ''' </summary>
    Public ConnectionString As String = $"Data Source={DatabaseServer};Initial Catalog={DefaultCatalog};Integrated Security=True"

End Class
''' <summary>
''' Represents a named database connection.
''' </summary>
Public Class ConnectionItem
    ''' <summary>
    ''' Formatted connection name suitable for form controls.
    ''' </summary>
    ''' <returns>Formatted name</returns>
    Property DisplayName As String
    ''' <summary>
    ''' Name of a connection
    ''' </summary>
    ''' <returns>Connection name</returns>
    Property AppConfigName As String
    ''' <summary>
    ''' Default to display for this class.
    ''' </summary>
    ''' <returns>Display name</returns>
    Public Overrides Function ToString() As String
        Return DisplayName
    End Function
End Class

''' <summary>
''' Used to strong type items in GetInformation in ProjectsConnections class
''' </summary>
''' <remarks></remarks>
Public Class ConfigurationItem
    ''' <summary>
    ''' Provides access to named connections
    ''' </summary>
    ''' <returns><seealso cref="Configuration.ConnectionStringSettings"/> </returns>
    Public Property Data As Configuration.ConnectionStringSettings
    ''' <summary>
    ''' Returns Connection index
    ''' </summary>
    ''' <returns>Index of a connection</returns>
    Public Property Index As Integer
End Class

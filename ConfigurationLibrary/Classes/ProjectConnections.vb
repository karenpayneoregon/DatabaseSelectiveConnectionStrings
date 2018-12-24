Imports System.Configuration
''' <summary>
''' Provides deconstruction of database named connections from a configuration file. 
''' </summary>
Public Class ProjectConnections
    ''' <summary>
    ''' Storage for connections
    ''' </summary>
    Public Property Items As New List(Of ConnectionInfo)
    ''' <summary>
    ''' Used to remember the current connection
    ''' </summary>
    Public Property CurrentConnectionIndex As Integer
    Private ReadOnly _removeThis As String = ""
    ''' <summary>
    ''' Initialize named connections into classes.
    ''' </summary>
    Public Sub New()
        ' look at parent assembly as this class is in a class project used by a forms project
        _removeThis = Reflection.Assembly.GetEntryAssembly.GetName.Name & ".My.MySettings."
        ' get connection data into the Items property of this class
        GetInformation()
    End Sub
    ''' <summary>
    ''' Using a valid connection name return the connection string
    ''' </summary>
    ''' <param name="connectionName">Connection string name from app.config</param>
    ''' <returns>Connection name</returns>
    ''' <remarks>Make sure to check for a null value in the event the name is not found</remarks>
    Public Function FindConnection(ByVal connectionName As String) As String

        Dim theConnection = Items _
            .FirstOrDefault(
                Function(item)
                    Return item.Name = connectionName
                End Function).ConnectionString

        Return theConnection

    End Function
    ''' <summary>
    ''' Presents an english name to represent a connection string.
    ''' </summary>
    ''' <remarks>
    ''' Here all connection strings start with database name with ConnectionString added.
    ''' This function returns a list where DisplayName is simply the database name
    ''' and AppConfigName is the actual name in app.config. So you could set a ComboBox
    ''' up with this data for the data source then set DisplayMember to DisplayMember of
    ''' the ComboBox and ValueMember to AppConfigName which allows you to get a connection string
    ''' via SomeComboBox.SelectedValue for the connection string.
    ''' </remarks>
    ''' <returns> <seealso cref="List(Of ConnectionItem)">List(Of ConnectionItem)</seealso> </returns>
    Public Function ConnectionItems() As List(Of ConnectionItem)

        Return Items.Select(Function(item) New ConnectionItem With
            {
                .DisplayName = item.Name.Replace("ConnectionString", ""),
                .AppConfigName = item.Name
            }).ToList

    End Function
    ''' <summary>
    ''' Traverse through connection strings in app.config, exclude local sql-server connection
    ''' </summary>
    ''' <remarks>
    ''' Tested with ms-access, sql-server attached and server based
    ''' </remarks>
    Private Sub GetInformation()
        ConfigurationManager.ConnectionStrings.Cast(Of ConnectionStringSettings)().Select(
            Function(item, index) New ConfigurationItem With {.Data = item, .Index = index}).ToList _
            .ForEach(
                Sub(configurationItem)
                    If configurationItem.Data.Name.Contains(".") Then
                        Items.Add(
                            New ConnectionInfo With
                                {
                                    .Name = configurationItem.Data.Name.Replace(_removeThis, ""),
                                    .ConnectionString = configurationItem.Data.ConnectionString,
                                    .Index = configurationItem.Index
                                })
                    End If
                End Sub)
    End Sub
End Class

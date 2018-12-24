Imports System.ComponentModel
Imports System.Windows.Forms
Imports ConfigurationLibrary


''' <summary>
''' Custom ComboBox designed to work with a specific DataSource of type 
''' <see cref="ConnectionInfo">List(Of ConnectionInfo)</see>. To keep things simple limited  assertion is performed which means use this incorrectly and
''' a run time exception will be thrown.
''' </summary>
Public Class ConnectionComboBox
    Inherits ComboBox
    ''' <summary>
    ''' Setup DropDownStyle and size
    ''' </summary>
    Public Sub New()
        DropDownStyle = ComboBoxStyle.DropDownList
        Size = New Drawing.Size(144, 21)
    End Sub
    ''' <summary>
    ''' Get a connection string by name which must exists and set this item as the selected item, otherwise a runtime exception is thrown.
    ''' </summary>
    ''' <param name="pName">Name of the named connection string</param>
    ''' <returns>Connection string for pName</returns>
    Public Function ConnectionStringByName(pName As String) As String
        Dim itemList = DataSourceConnectionInformation.Select(Function(item, index) New With {.Name = item.Name, .Index = item.Index})

        SelectedIndex = itemList.FirstOrDefault(Function(item) item.Name = pName).Index - 1
        Return DataSourceConnectionInformation.FirstOrDefault(Function(item) item.Name = pName).ConnectionString
    End Function
    ''' <summary>
    ''' Determine if there is a selected item
    ''' </summary>
    ''' <returns>
    ''' True is has a selection, False if no current selection
    ''' </returns>
    <Browsable(False)>
    Public ReadOnly Property HasCurrentSelection() As Boolean
        Get
            Return SelectedIndex > -1
        End Get
    End Property
    ''' <summary>
    ''' Determines if the DataSource is <see cref="ConnectionInfo">List(Of ConnectionInfo)</see>
    ''' </summary>
    ''' <returns>
    ''' True if proper set for <see cref="List(Of ConnectionInfo)">List(Of ConnectionInfo)</see>, False if not
    ''' </returns>
    <Browsable(False)>
    Public ReadOnly Property HasProperDataSource() As Boolean
        Get
            If DataSource IsNot Nothing Then
                Return DataSource Is GetType(List(Of ConnectionInfo))
            Else
                Return False
            End If
        End Get
    End Property
    ''' <summary>
    ''' Get current <see cref="ConnectionInfo">ConnectionInfo</see> or a new ConnectionInfo
    ''' </summary>
    ''' <returns>Current item as <see cref="ConnectionInfo">ConnectionInfo</see></returns>
    <Browsable(False)>
    Public ReadOnly Property SelectedConnectionInfo As ConnectionInfo
        Get
            If HasCurrentSelection Then
                Return CType(SelectedItem, ConnectionInfo)
            Else
                Return New ConnectionInfo()
            End If
        End Get
    End Property
    ''' <summary>
    ''' Current item's ConnectionString
    ''' </summary>
    ''' <returns>ConnectionString</returns>
    ''' <remarks>
    ''' Removes providerName from connection string
    ''' </remarks>
    <Browsable(False)>
    Public ReadOnly Property SelectedConnectionString() As String
        Get
            If HasCurrentSelection Then
                Return CType(SelectedItem, ConnectionInfo).
                    ConnectionString.
                    Replace(""" providerName=""System.Data.SqlClient", "")
            Else
                Return ""
            End If
        End Get
    End Property
    ''' <summary>
    ''' Return current select item connection name
    ''' </summary>
    ''' <returns>Connection name</returns>
    <Browsable(False)>
    Public ReadOnly Property SelectedConnectionName() As String
        Get
            If HasCurrentSelection Then
                Return CType(SelectedItem, ConnectionInfo).Name
            Else
                Return ""
            End If
        End Get
    End Property
    ''' <summary>
    ''' Selected item connection index in app configuration file
    ''' </summary>
    ''' <returns>Current connection index from list</returns>
    <Browsable(False)>
    Public ReadOnly Property SelectedConnectionIndex() As Integer
        Get
            If HasCurrentSelection Then
                Return CType(SelectedItem, ConnectionInfo).Index
            Else
                Return -1
            End If
        End Get
    End Property
    ''' <summary>
    ''' Return underlying DataSource as a list of <see cref="ConnectionInfo">ConnectionInfo</see>
    ''' </summary>
    ''' <returns><see cref="ConnectionInfo">List(Of ConnectionInfo)</see></returns>
    <Browsable(False)>
    Public ReadOnly Property DataSourceConnectionInformation() As List(Of ConnectionInfo)
        Get
            Return CType(DataSource, List(Of ConnectionInfo))
        End Get
    End Property
    ''' <summary>
    ''' Control description
    ''' </summary>
    ''' <returns>About information</returns>
    <Browsable(True), Category("About"),
        DescriptionAttribute("Provides access to ConnectionInfo items")>
    Public ReadOnly Property Details() As String
        Get
            Return "Custom ComboBox for ConnectionInfo class"
        End Get
    End Property
End Class

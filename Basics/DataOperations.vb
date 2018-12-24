Imports System.Data.SqlClient
Imports BaseLibrary
Imports ExtensionsLibrary

Public Class DataOperations
    Inherits BaseSqlServerConnections

    Public Property DatabaseConnectionString() As String
    Public Sub New()
    End Sub
    Public Sub New(pConnectionString As String)
        DatabaseConnectionString = pConnectionString
    End Sub

    Public Function GetCustomersAndContactTypes(Optional pDeveloperMode As Boolean = False) As DataTable
        ConnectionString = DatabaseConnectionString.RemoveProvider

        mHasException = False


        Dim dtCustomers = New DataTable

        Dim selectStatement = "SELECT  C.CustomerIdentifier , C.CompanyName , CT.ContactTitle , C.ContactName , C.[Address] As Street , " &
                              "C.City , C.PostalCode As Postal, C.Country , C.ContactTypeIdentifier , C.ModifiedDate " &
                              "FROM Customers AS C " &
                              "INNER JOIN ContactType AS CT ON C.ContactTypeIdentifier = CT.ContactTypeIdentifier; "
        Try
            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn}
                    cmd.CommandText = selectStatement
                    cn.Open()
                    dtCustomers.Load(cmd.ExecuteReader())
                    If Not pDeveloperMode Then
                        dtCustomers.Columns("CustomerIdentifier").ColumnMapping = MappingType.Hidden
                        dtCustomers.Columns("ContactTypeIdentifier").ColumnMapping = MappingType.Hidden
                        dtCustomers.Columns("ModifiedDate").ColumnMapping = MappingType.Hidden
                    End If
                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try


        Return dtCustomers

    End Function

End Class

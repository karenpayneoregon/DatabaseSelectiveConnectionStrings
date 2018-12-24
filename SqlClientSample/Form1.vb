Imports ConfigurationLibrary
Public Class Form1
    Private connections As ProjectConnections = New ProjectConnections()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dim test = connections.Items
        cboConnections.DataSource = connections.Items
        cboConnections.DisplayMember = "Name"
        cboConnections.SelectedIndex = 1
    End Sub

    Private Sub cmdGetConnection_Click(sender As Object, e As EventArgs) Handles cmdGetConnection.Click

        Console.WriteLine(ctype(cboConnections.SelectedItem,ConnectionInfo).ConnectionString)
        
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim builder as new SqlClient.SqlConnectionStringBuilder
        builder.ConnectionString =ctype(cboConnections.SelectedItem,ConnectionInfo).ConnectionString
        Console.WriteLine()
    End Sub
End Class

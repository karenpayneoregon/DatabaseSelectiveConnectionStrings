Imports ConfigurationLibrary
''' <summary>
''' Note, all three databases here have customers table.
''' </summary>
''' <remarks></remarks>
Public Class Form1
    Private connections As ProjectConnections = New ProjectConnections()
    ''' <summary>
    ''' choose the connection and remember it
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' here I am loading a connection other than the default
        CustomersTableAdapter.Connection.ConnectionString = connections.Items(1).ConnectionString
        ' for keeping track later as in cmdGetConnection.Click
        connections.CurrentConnectionIndex = 1
        ' default method added by the ide data wizard
        Me.CustomersTableAdapter.Fill(Me.Database1DataSet.Customers)

        ' for showing connections - note this and dgvInformation when traversing
        ' will traverse together as they are using the same data source
        cboConnections.DataSource = connections.Items
        cboConnections.DisplayMember = "Name"
        cboConnections.SelectedIndex = 1

        dgvInformation.AutoGenerateColumns = False
        dgvInformation.DataSource = connections.Items
        CustomersDataGridView.ExpandColumns()
        dgvInformation.ExpandColumns()

        ComboBox1.DataSource = connections.ConnectionItems
        ComboBox1.ValueMember = "AppConfigName"
    End Sub
    ''' <summary>
    ''' Change current connection and remember it
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdSetConnection_Click(sender As Object, e As EventArgs) Handles cmdSetConnection.Click
        Dim ordinalIndex As Integer = CType(cboConnections.SelectedItem, ConnectionInfo).Index - 1
        CustomersTableAdapter.Connection.Close()
        CustomersTableAdapter.Connection.ConnectionString = connections.Items(ordinalIndex).ConnectionString
        CustomersTableAdapter.Connection.Open()
        CustomersTableAdapter.Fill(Me.Database1DataSet.Customers)
        cboConnections.SelectedIndex = ordinalIndex
    End Sub
    ''' <summary>
    ''' Show current connection
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdGetConnection_Click(sender As Object, e As EventArgs) Handles cmdGetConnection.Click
        Dim sb As New System.Text.StringBuilder
        sb.AppendLine(cboConnections.Text)
        sb.AppendLine(connections.Items(connections.CurrentConnectionIndex).ConnectionString)

        MessageBox.Show(sb.ToString)
    End Sub
    Private Sub cmdDataReaderSample_Click(sender As Object, e As EventArgs) Handles cmdDataReaderSample.Click
        ' look at app.config for CustomersMainConnectionString, note the difference from the other connection strings
        ' in that I removed the trailing \Bin\Debug. This was done directory in app.config and when viewing my settings
        ' under project properties now the first time a message box indicates it must re-read app.config and my changes
        ' are reflected.
        Dim ordinalIndex As Integer = CType(cboConnections.SelectedItem, ConnectionInfo).Index - 1

        'AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory)

        Using cn As New OleDb.OleDbConnection With {.ConnectionString = connections.Items(ordinalIndex).ConnectionString}
            Using cmd As New OleDb.OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = "SELECT CompanyName FROM Customers WHERE Identifier = @Identifier;"
                }
                cmd.Parameters.AddWithValue("Identifier", 2)
                cn.Open()
                Dim reader As OleDb.OleDbDataReader = cmd.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    MessageBox.Show(reader.GetString(0))
                End If

            End Using

        End Using
    End Sub
    ''' <summary>
    ''' Demo showing nice name, get real name of the connection
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdEnglisNames_Click(sender As Object, e As EventArgs) Handles cmdEnglisNames.Click
        MessageBox.Show(CStr(ComboBox1.SelectedValue))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class


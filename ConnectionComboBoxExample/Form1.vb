Imports ConfigurationLibrary
Imports ExtensionsLibrary
''' <summary>
''' This code sample demonstrates how to have a developer
''' and customer access to data. Dev mode is entered by identifying
''' the current user by current user name, if not a match then
''' customer mode is used.
''' 
''' Dev mode provides a list of servers to select from along with
''' showing primary keys of two tables read via a JOIN.
''' 
''' </summary>
''' <remarks>
''' BindingNavigator action buttons disabled as
''' they play not part in this code sample.
''' </remarks>
Public Class Form1
    ''' <summary>
    ''' Responsible for obtaining connection details
    ''' </summary>
    Private connections As ProjectConnections = New ProjectConnections()
    ''' <summary>
    ''' Responsible for reading data from SQL-Server
    ''' </summary>
    Private dataOperations As New DataOperations

    ''' <summary>
    ''' Logic to determine if in developer mode or customer mode
    ''' by checking the current user name.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConnectionComboBox1.DataSource = connections.Items

        If Environment.UserName = "Karens" Then
            ConnectionComboBox1.Visible = True
            changeConnectionButton.Visible = True
        Else
            dataOperations.DatabaseConnectionString = ConnectionComboBox1.ConnectionStringByName("Home")

            ReadData()
        End If


    End Sub
    ''' <summary>
    ''' While in developer mode this button reads data from the selected
    ''' connection using ReadData procedure.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub changeConnectionButton_Click(sender As Object, e As EventArgs) Handles changeConnectionButton.Click

        dataOperations.DatabaseConnectionString = ConnectionComboBox1.SelectedConnectionString
        ReadData()

    End Sub
    ''' <summary>
    ''' When called the connection string has been set in either
    ''' form load event or changeConnectionButton click event.
    ''' </summary>
    Private Sub ReadData()
        bsCustomers.DataSource = dataOperations.GetCustomersAndContactTypes()

        If dataOperations.IsSuccessFul Then
            DataGridView1.DataSource = bsCustomers

            For Each column As DataGridViewColumn In DataGridView1.Columns
                column.HeaderText = column.HeaderText.SplitCamelCase()
            Next

            DataGridView1.ExpandColumns()

        Else
            MessageBox.Show("Failed to read data" &
                $"{Environment.NewLine}{dataOperations.LastExceptionMessage}")
        End If

    End Sub
    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Close()
    End Sub
End Class

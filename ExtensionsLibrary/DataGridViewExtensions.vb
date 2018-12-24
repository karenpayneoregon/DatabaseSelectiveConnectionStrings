''' <summary>
''' Language extension methods for DataGridView control.
''' </summary>
Public Module DataGridViewExtensions
    ''' <summary>
    ''' Resizes all columns in a <seealso cref="DataGridView">DataGridView</seealso> to show all column data
    ''' </summary>
    ''' <param name="sender"><seealso cref="DataGridView">DataGridView</seealso> to expand columns.</param>
    <DebuggerHidden()>
    <Runtime.CompilerServices.Extension()>
    Public Sub ExpandColumns(sender As DataGridView)
        For Each column As DataGridViewColumn In sender.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
End Module

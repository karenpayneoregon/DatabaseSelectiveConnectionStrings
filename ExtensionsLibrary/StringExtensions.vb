Imports System.Text.RegularExpressions
''' <summary>
''' Language extension methods for type String.
''' </summary>
Public Module StringExtensions
    ''' <summary>
    ''' Given a string with upper and lower cased letters separate them before each upper cased characters
    ''' </summary>
    ''' <param name="sender">String with Camel case to split.</param>
    ''' <returns>String with spaces between upper-case letters</returns>
    <Runtime.CompilerServices.Extension>
    Public Function SplitCamelCase(ByVal sender As String) As String
        Return Regex.Replace(Regex.Replace(sender, "(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), "(\p{Ll})(\P{Ll})", "$1 $2")
    End Function
    ''' <summary>
    ''' Removes providerName from a connection string stored in app.config
    ''' </summary>
    ''' <param name="sender">String to remove provider name from</param>
    ''' <returns>Connection string without provider name</returns>
    <Runtime.CompilerServices.Extension>
    Public Function RemoveProvider(sender As string) As String
        Return sender.Replace(""" providerName=""System.Data.SqlClient", "")
    End Function
End Module

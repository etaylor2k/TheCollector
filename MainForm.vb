Imports MySql.Data.MySqlClient

Public Class MainForm

    ' Custom structure to represent the columns in the table
    Structure identity
        Dim id As Integer
        Dim username As String
        Dim password As String
        Dim level As Integer
        Dim fname As String
        Dim lname As String
        Dim email As String

    End Structure

    Public userIdentity As identity
    Public connection As MySqlConnection

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click

    End Sub
End Class

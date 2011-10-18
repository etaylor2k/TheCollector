Imports MySql.Data.MySqlClient

Public Class UserInfoForm
    ' This class is the UserInfoForm class which is representing the User Information form. With this form the user is able to update the information about their specific account
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

    Public connection As MySqlConnection

    Public uifUsersIdentity As identity ' The identity of the user


    Private Sub cmdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will chagne the users information in the database if there is a change
        ' This subroutine is expecting the 
    End Sub

End Class
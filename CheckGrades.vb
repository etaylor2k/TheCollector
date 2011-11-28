' Check Grades
' This class represents the student being able to check thier test grades
' Endris Taylor for the collective

Imports MySql.Data.MySqlClient ' For MySQL functionalites

Public Class CheckGrades

    ' Class variables
    Public userIdentitiy As Identity
    Public connection As MySqlConnection

    Private Sub CheckGrades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This subroutine will load the test grades for the student.
        ' This subroutine is not expecting or returing anything. 

        ' Declarations
        Dim sqlcommand As New MySqlCommand
        Dim sqlreader As MySqlDataReader
        Dim gradeString As String = ""

        ' Check the connection
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        ' Query to select the students test grades
        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select grades.grade, tests.test_name from grades,tests,users where grades.gtest = tests.idtests and grades.gstudent = users.idusers and users.idusers ='" + Me.userIdentitiy.id.ToString + "'"

        'Error handeling for the query
        Try
            ' Execute the query
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            ' send the exeption to a message box
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            ' If there are results then we need to put them into the listbox
            Do While sqlreader.Read
                gradeString = sqlreader.GetString(0) + " (" + sqlreader.GetString(1) + ")"
                Me.lstTestGrades.Items.Add(gradeString)

                gradeString = ""

            Loop
        Else
            ' If there are not any results
            MsgBox("No Test Grades on File")

            Me.Close()

        End If

        sqlreader.Close() ' Close the data reader

    End Sub
End Class
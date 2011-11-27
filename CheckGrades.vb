Imports MySql.Data.MySqlClient

Public Class CheckGrades
    Public userIdentitiy As Identity
    Public connection As MySqlConnection

    Private Sub CheckGrades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This subroutine will load the test grades for the student.
        ' This subroutine is not expecting or returing anything. 

        Dim sqlcommand As New MySqlCommand
        Dim sqlreader As MySqlDataReader
        Dim gradeString As String = ""

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select grades.grade, tests.test_name from grades,tests,users where grades.gtest = tests.idtests and grades.gstudent = users.idusers and users.idusers ='" + Me.userIdentitiy.id.ToString + "'"

        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            Do While sqlreader.Read
                gradeString = sqlreader.GetString(0) + " (" + sqlreader.GetString(1) + ")"
                Me.lstTestGrades.Items.Add(gradeString)

                gradeString = ""

            Loop
        End If

        sqlreader.Close()

    End Sub
End Class
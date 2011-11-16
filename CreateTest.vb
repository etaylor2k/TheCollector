Imports MySql.Data.MySqlClient

Public Class CreateTest

    Public connection As MySqlConnection
    Public userIdentity As Identity
    Private classes As New Dictionary(Of String, Integer) ' This will represent the dictionary of classes in the combo box

    Private Sub CreateTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This subroutine will populate the classes drop down with the classes the teacher has
        ' This subroutine is not expecting or returning anything

        Dim sqlreader As MySqlDataReader
        Dim sqlcommand As New MySqlCommand
        Dim classesString As String

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select subjects.code, courses.number, courses.title, semesters.name, classes.year, classes.idclasses from classes,courses, subjects, semesters where classes.teacher ='" + Me.userIdentity.id.ToString + "' and courses.subject = subjects.idsubjects and classes.semester = semesters.idsemester"

        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then

            Do While sqlreader.Read
                classesString = sqlreader.GetString(0) + sqlreader.GetString(1) + " " + sqlreader.GetString(2) + "(" + sqlreader.GetString(3) + " " + sqlreader.GetString(4) + ")"
                Me.classes.Add(classesString, sqlreader.GetInt64(5))
                Me.comboClasses.Items.Add(classesString)

            Loop
            Me.comboClasses.SelectedIndex = 0

            sqlreader.Close()

        Else

            sqlreader.Close()
            MsgBox("No Classes on file for this teacher")
            Me.Close()

        End If

    End Sub


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will create the test for the specific class
        ' This suboutine is not expecting or returning anything

        Dim sqlcommand As New MySqlCommand
        Dim sqlreader As MySqlDataReader
        Dim unique As Boolean = False
        Dim created As Boolean = False
        Dim classValue As Integer

        If Trim(txtClassName.Text <> "") Then
            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

            classValue = Me.classes.Item(Me.comboClasses.SelectedItem.ToString)

            sqlcommand.Connection = Me.connection
            sqlcommand.CommandText = "select * from tests where test_class ='" + classValue.ToString + "' and test_name ='" + Me.txtClassName.Text + "'"

            Try
                sqlreader = sqlcommand.ExecuteReader

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            If sqlreader.HasRows = False Then
                unique = True

            End If

            sqlreader.Close()

            If unique = True Then

                If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

                sqlcommand.CommandText = "insert into tests(idtests, test_name, test_class) VALUES(?idtests, ?test_name, ?test_class)"

                sqlcommand.Parameters.AddWithValue("?idtests", DBNull.Value)
                sqlcommand.Parameters.AddWithValue("?test_name", Trim(Me.txtClassName.Text))
                sqlcommand.Parameters.AddWithValue("?test_class", classValue.ToString)

                Try
                    sqlcommand.ExecuteNonQuery()
                    created = True

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try

            End If
        End If

        If created = True Then MsgBox("Test Created") Else MsgBox("Error: Test not created")

        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the form when the cancel button is pressed
        ' This subroutine is not expecting or returning anything

        Me.Close()

    End Sub

End Class
Imports MySql.Data.MySqlClient

Public Class AssignQuestion

    Public userIdentity As Identity
    Public connection As MySqlConnection
    Public questions As New Dictionary(Of String, Integer)
    Public tests As New Dictionary(Of String, Integer)


    Private Sub AssignQuestion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This subroutine will load the tests and available questions 
        ' This subroutine is not expecting or returning anything

        Dim sqlcommand As New MySqlCommand
        Dim sqlreader As MySqlDataReader
        Dim unique As Boolean = False
        Dim classText As String
        Dim subject As Integer

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select subjects.code, courses.number, courses.title, semesters.name, classes.year, tests.idtests, subjects.idsubjects from tests, classes, users, courses, semesters, subjects where tests.test_class = classes.idclasses and classes.teacher = users.idusers and users.idusers ='" + Me.userIdentity.id.ToString + "' and semesters.idsemester = classes.semester and subjects.idsubjects = courses.subject"

        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            ' if there are classes to add this to

            Do While sqlreader.Read
                classText = sqlreader.GetString(0) + sqlreader.GetString(1) + " " + sqlreader.GetString(2) + " (" + sqlreader.GetString(3) + " " + sqlreader.GetString(4) + ")"
                Me.tests.Add(classText, sqlreader.GetInt32(5))
                Me.comboTest.Items.Add(classText)
                subject = sqlreader.GetInt64(6)
                classText = ""

            Loop

            Me.comboTest.SelectedIndex = 0
            sqlreader.Close()

            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()
            sqlcommand.CommandText = "select * from questions where qsubject = '" + subject.ToString + "'"

            Try
                sqlreader = sqlcommand.ExecuteReader

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            If sqlreader.HasRows = True Then
                Do While sqlreader.Read
                    Me.questions.Add(sqlreader.GetString(1), sqlreader.GetInt64(0))
                    Me.lstQuestion.Items.Add(sqlreader.GetString(1))
                Loop

                sqlreader.Close()

            End If
        Else
            'if there are not any classes for this teacher then alert the user

            MsgBox("Error: No Classes created for the teacher")
            sqlreader.Close()
            Me.Close()

        End If

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will clode the form when the user presses the cancel button
        ' This subroutine is not expecting or returning anything

        Me.Close()

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subrotuine will create the question for the test if it does not already exist
        ' This subroutine is not expecting or returning anything

        Dim sqlcommand As New MySqlCommand
        Dim sqlreader As MySqlDataReader
        Dim unique As Boolean = False
        Dim created As Boolean = False
        Dim test As Integer
        Dim question As Integer

        test = Me.tests.Item(Me.comboTest.SelectedItem.ToString)
        question = Me.questions.Item(Me.lstQuestion.SelectedItem.ToString)

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select * from test_questions where tqtest ='" + test.ToString + "' and tqquestion ='" + question.ToString + "'"

        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            sqlreader.Close()
            MsgBox("Error: Question already in test")

        Else
            sqlreader.Close()

            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

            sqlcommand.CommandText = "insert into test_questions(idtest_questions, tqtest, tqquestion) VALUES(?idtest_questions, ?tqtest, ?tqquestion)"

            ' Replace the parameters
            sqlcommand.Parameters.AddWithValue("?idtest_questions", DBNull.Value)
            sqlcommand.Parameters.AddWithValue("?tqtest", test.ToString)
            sqlcommand.Parameters.AddWithValue("?tqquestion", question.ToString)

            Try
                sqlcommand.ExecuteNonQuery()
                created = True

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            If created = True Then
                MsgBox("Question added to test")

            Else
                MsgBox("Error creating test")

            End If
        End If
    End Sub
End Class
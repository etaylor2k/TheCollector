' AssignQuestion
' This class represents the functionality to assign a question to a test
' Endris Taylor for the Collective

Imports MySql.Data.MySqlClient ' For the MySQL functions

Public Class AssignQuestion

    ' Class Variables
    Public userIdentity As Identity
    Public connection As MySqlConnection
    Public questions As New Dictionary(Of String, Integer)
    Public tests As New Dictionary(Of String, Integer)


    Private Sub AssignQuestion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This subroutine will load the tests and available questions 
        ' This subroutine is not expecting or returning anything

        ' Declarations
        Dim sqlcommand As New MySqlCommand
        Dim sqlreader As MySqlDataReader
        Dim unique As Boolean = False
        Dim classText As String
        Dim subject As Integer

        'Checking connection
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        ' Establishing the SQL command
        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select subjects.code, courses.number, courses.title, semesters.name, classes.year, tests.idtests, subjects.idsubjects from tests, classes, users, courses, semesters, subjects where tests.test_class = classes.idclasses and classes.teacher = users.idusers and users.idusers ='" + Me.userIdentity.id.ToString + "' and semesters.idsemester = classes.semester and subjects.idsubjects = courses.subject"

        ' Error handling for the query
        Try
            ' Execute the query
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            ' Put the exception in a message box if applicable
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            ' if there are classes to add this to

            Do While sqlreader.Read
                ' Add the results to the test drop down
                classText = sqlreader.GetString(0) + sqlreader.GetString(1) + " " + sqlreader.GetString(2) + " (" + sqlreader.GetString(3) + " " + sqlreader.GetString(4) + ")"
                Me.tests.Add(classText, sqlreader.GetInt32(5)) ' Add to the dictionary
                Me.comboTest.Items.Add(classText)
                subject = sqlreader.GetInt64(6) ' Assign the subject
                classText = ""

            Loop

            Me.comboTest.SelectedIndex = 0
            sqlreader.Close() ' Close the sql Data reader

            ' Check the connection and then query for the questions of the same subject
            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()
            sqlcommand.CommandText = "select * from questions where qsubject = '" + subject.ToString + "'"

            ' Error handling for the query
            Try
                ' Execute the query
                sqlreader = sqlcommand.ExecuteReader

            Catch ex As Exception
                ' Print the exception to the message box
                MsgBox(ex.Message)

            End Try

            If sqlreader.HasRows = True Then
                ' If there are results
                Do While sqlreader.Read
                    ' Add the questions tothe listbox
                    Me.questions.Add(sqlreader.GetString(1), sqlreader.GetInt64(0))
                    Me.lstQuestion.Items.Add(sqlreader.GetString(1)) ' add questions to the dictionary
                Loop

                sqlreader.Close() ' close the sql data reader, only one per query

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

        ' Get the test and the question that the user selected on the UI
        test = Me.tests.Item(Me.comboTest.SelectedItem.ToString)
        question = Me.questions.Item(Me.lstQuestion.SelectedItem.ToString)

        ' test connection
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        ' get the query to see if it is unique before assigning
        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select * from test_questions where tqtest ='" + test.ToString + "' and tqquestion ='" + question.ToString + "'"

        ' Error handling for the query
        Try
            ' execute the query
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            ' send exception to a messagebox
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            ' If the query returns anything then it is not unique 

            sqlreader.Close() ' Close the sql data reader
            MsgBox("Error: Question already in test")

        Else
            ' If the sql query does not retung anything then we can assign the question
            sqlreader.Close() ' Close data reader

            ' Check connection
            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

            sqlcommand.CommandText = "insert into test_questions(idtest_questions, tqtest, tqquestion) VALUES(?idtest_questions, ?tqtest, ?tqquestion)"

            ' Replace the parameters
            sqlcommand.Parameters.AddWithValue("?idtest_questions", DBNull.Value)
            sqlcommand.Parameters.AddWithValue("?tqtest", test.ToString)
            sqlcommand.Parameters.AddWithValue("?tqquestion", question.ToString)

            ' Error handling for the insert command
            Try
                ' execute the insert command
                sqlcommand.ExecuteNonQuery()
                created = True

            Catch ex As Exception
                ' send exception to the message box
                MsgBox(ex.Message)

            End Try

            If created = True Then
                ' If the command was a success then alert the user
                MsgBox("Question added to test")

            Else
                ' If the command was not a success alert the user
                MsgBox("Error creating test")

            End If
        End If
    End Sub
End Class
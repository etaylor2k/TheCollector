Imports MySql.Data.MySqlClient

Public Class TakeTest
    Public connection As MySqlConnection
    Public userIdentity As Identity
    Public tests As New Dictionary(Of String, Integer)

    Private Sub TakeTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlcommand As New MySqlCommand
        Dim sqlreader As MySqlDataReader
        Dim testString As String

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select tests.test_name, subjects.code, courses.number, semesters.name, classes.year, tests.idtests from tests, classes, class_students, courses, subjects, semesters where tests.test_class = classes.idclasses and class_students.class  =classes.idclasses and class_students.student ='" + Me.userIdentity.id.ToString + "' and classes.course = courses.idcourses and classes.semester = semesters.idsemester and courses.subject = subjects.idsubjects"

        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            Do While sqlreader.Read
                testString = sqlreader.GetString(0) + " (" + sqlreader.GetString(1) + sqlreader.GetString(2) + " " + sqlreader.GetString(3) + " " + sqlreader.GetString(4) + ")"
                Me.tests.Add(testString, sqlreader.GetInt64(5))
                Me.lstTests.Items.Add(testString)

            Loop

            Me.lstTests.SelectedIndex = 0
            sqlreader.Close()
        Else
            sqlreader.Close()
            MsgBox("No Tests to Take")
            Me.Close()

        End If



    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click

        Dim sqlcommand As New MySqlCommand
        Dim sqlreader As MySqlDataReader
        Dim test As Integer
        Dim questions As New ArrayList
        Dim qtype As Integer
        Dim question_text As String
        Dim multipleChoice As New MultipleChoiceForm
        Dim trueOrFalse As New TrueOrFalseForm
        Dim shortAnswer As New ShortAnswerFrom


        test = Me.tests.Item(Me.lstTests.SelectedItem.ToString)

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = " select * from test_questions where tqtest ='" + test.ToString + "'"

        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            Do While sqlreader.Read
                questions.Add(sqlreader.GetInt64(2))

            Loop
        End If

        sqlreader.Close()

        For Each question In questions
            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

            sqlcommand.CommandText = "select * from questions where idquestions ='" + question.ToString + "'"

            Try
                sqlreader = sqlcommand.ExecuteReader

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            If sqlreader.HasRows = True Then
                Do While sqlreader.Read
                    question_text = sqlreader.GetString(1)
                    qtype = sqlreader.GetInt64(2)

                Loop

            End If

            sqlreader.Close()

            Select Case qtype
                Case 1
                    ' True or False question form
                    trueOrFalse.question = question
                    trueOrFalse.connection = Me.connection
                    trueOrFalse.userIdentity = Me.userIdentity
                    trueOrFalse.txtQuestion.Text = question_text
                    trueOrFalse.test = test
                    trueOrFalse.txtQuestion.ReadOnly = True
                    trueOrFalse.ShowDialog() ' this will show the form as a modal

                Case 2
                    ' This will show the short answer form
                    shortAnswer.question = question
                    shortAnswer.connection = Me.connection
                    shortAnswer.userIdentity = Me.userIdentity
                    shortAnswer.txtQuestion.Text = question_text
                    shortAnswer.test = test
                    shortAnswer.txtQuestion.ReadOnly = True
                    shortAnswer.ShowDialog() ' this will show the form as a modal

                Case 3
                    ' This will show the multiple choice question form
                    multipleChoice.question = question
                    multipleChoice.connection = Me.connection
                    multipleChoice.userIdentity = Me.userIdentity
                    multipleChoice.txtQuestion.Text = question_text
                    multipleChoice.test = test
                    multipleChoice.txtQuestion.ReadOnly = True
                    multipleChoice.ShowDialog() ' this will show the form as a modal

            End Select
           
            qtype = 0
            question_text = ""

        Next
        MsgBox("Test Complete")
        Call gradeTest(questions, test)

    End Sub

    Private Sub gradeTest(ByVal questionList As ArrayList, ByVal test As Integer)
        ' This subroutine will grade the test 
        ' This subroutine is expecting the list of questions and the id of the test and is not returning anything

        Dim sqlcommand As New MySqlCommand
        Dim sqlreader As MySqlDataReader
        Dim questionCount As Integer = questionList.Count
        Dim correct As Integer
        Dim score As Decimal


        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select count(*) from answers where correct =1 and atest ='" + test.ToString + "' and astudent ='" + Me.userIdentity.id.ToString + "'"

        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            Do While sqlreader.Read
                correct = sqlreader.GetInt64(0)
            Loop

        End If

        score = (correct / questionCount) * 100

        MsgBox("You had " + correct.ToString + " out of " + questionCount.ToString + "  correct for a score of " + Format(score, "0.00").ToString)

        sqlreader.Close()

    End Sub
End Class
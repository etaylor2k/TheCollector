Imports MySql.Data.MySqlClient

Public Class CreateShortAnswerFrom
    Public userIdentity As Identity
    Public connection As MySqlConnection
    Public subject As Integer
    Public type As Integer = 2

    Private Sub CreateShortAnswerFrom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will save the question in the short answer question in the database
        ' This subroutine is not expecting or returning anything

        Dim sqlreader As MySqlDataReader
        Dim sqlcommand As New MySqlCommand
        Dim questionCreated As Boolean = False
        Dim question As Integer
        Dim shortCreated As Boolean = False

        If Me.connection.State = ConnectionState.Broken Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select * from questions where question_text ='" + Trim(Me.txtQuestion.Text.ToString) + "' and type ='" + Me.type.ToString + "' and qsubject = '" + Me.subject.ToString + "'"

        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            ' This is not a unique question
            MsgBox("Error: Question already exists")
            sqlreader.Close()

        Else
            ' This is a unique question
            sqlreader.Close()

            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()


            sqlcommand.Connection = Me.connection
            sqlcommand.CommandText = "insert into questions(idquestions, question_text, type, qsubject) VALUES(?idquestions, ?question_text, ?type, ?qsubject)"

            sqlcommand.Parameters.AddWithValue("?idquestions", DBNull.Value)
            sqlcommand.Parameters.AddWithValue("?question_text", Trim(Me.txtQuestion.Text.ToString))
            sqlcommand.Parameters.AddWithValue("?type", Me.type.ToString)
            sqlcommand.Parameters.AddWithValue("?qsubject", Me.subject.ToString)

            Try
                sqlcommand.ExecuteNonQuery() ' execute the insert
                questionCreated = True

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            sqlreader.Close()

            If questionCreated = True Then
                ' If the question actually got created then we need to add the rest of the contents to
                If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

                sqlcommand.CommandText = "select idquestions from questions where question_text ='" + Trim(Me.txtQuestion.Text.ToString) + "' and type ='" + Me.type.ToString + "'"

                Try
                    sqlreader = sqlcommand.ExecuteReader

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try

                If sqlreader.HasRows = True Then
                    ' If there is a record, the one that we just added, then get the id so that we can relate the record

                    Do While sqlreader.Read
                        question = sqlreader.GetInt64(0)

                    Loop

                    sqlreader.Close()

                    sqlcommand.Connection = Me.connection
                    sqlcommand.CommandText = "insert into short_answers(idshort_answer, saquestion, sa_answer) VALUES(?idshort_answer, ?saquestion, ?sa_answer)"
                    sqlcommand.Parameters.AddWithValue("?idshort_answer", DBNull.Value)
                    sqlcommand.Parameters.AddWithValue("?saquestion", question.ToString)
                    sqlcommand.Parameters.AddWithValue("?sa_answer", question.ToString)

                    Try
                        sqlcommand.ExecuteNonQuery()
                        shortCreated = True

                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try

                    If shortCreated = True Then
                        MsgBox("Question Created")
                    Else
                        MsgBox("Error creating quesiton")

                    End If

                End If
            Else
                ' If the quesiton was not created
                MsgBox("Error: quesiton not added to the Short Answer table")

            End If
        End If

        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the form
        ' This subroutine is not expecting or returning anything

        Me.Close()

    End Sub
End Class
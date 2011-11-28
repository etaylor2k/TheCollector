' CreateShortAnswerForm
' This class represents the teahcer creating a short answer question
' Endris Taylor for The Collective

Imports MySql.Data.MySqlClient '  For the MySql functionalities

Public Class CreateShortAnswerFrom

    ' Class Variables
    Public userIdentity As Identity
    Public connection As MySqlConnection
    Public subject As Integer
    Public type As Integer = 2

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will save the question in the short answer question in the database
        ' This subroutine is not expecting or returning anything

        ' Declarations
        Dim sqlreader As MySqlDataReader
        Dim sqlcommand As New MySqlCommand
        Dim questionCreated As Boolean = False
        Dim question As Integer
        Dim shortCreated As Boolean = False
        Dim answer As String

        'check the connection
        If Me.connection.State = ConnectionState.Broken Then Me.connection.Open()

        ' select for a unique question
        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select * from questions where question_text ='" + Trim(Me.txtQuestion.Text.ToString) + "' and type ='" + Me.type.ToString + "' and qsubject = '" + Me.subject.ToString + "'"

        ' Error handling for the query
        Try
            ' Execute the query
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            ' send exception to a messagebox
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            ' This is not a unique question
            MsgBox("Error: Question already exists")
            sqlreader.Close()

        Else
            ' This is a unique question
            sqlreader.Close()

            ' check connection
            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

            ' insert command
            sqlcommand.Connection = Me.connection
            sqlcommand.CommandText = "insert into questions(idquestions, question_text, type, qsubject) VALUES(?idquestions, ?question_text, ?type, ?qsubject)"

            ' subsitute the values
            sqlcommand.Parameters.AddWithValue("?idquestions", DBNull.Value)
            sqlcommand.Parameters.AddWithValue("?question_text", Trim(Me.txtQuestion.Text.ToString))
            sqlcommand.Parameters.AddWithValue("?type", Me.type.ToString)
            sqlcommand.Parameters.AddWithValue("?qsubject", Me.subject.ToString)

            ' Error handling for the command
            Try

                sqlcommand.ExecuteNonQuery() ' execute the insert
                questionCreated = True

            Catch ex As Exception
                ' send exception to a messagebox
                MsgBox(ex.Message)

            End Try

            sqlreader.Close() ' close the data reader

            If questionCreated = True Then
                ' If the question actually got created then we need to add the rest of the contents to
                If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

                sqlcommand.CommandText = "select idquestions from questions where question_text ='" + Trim(Me.txtQuestion.Text.ToString) + "' and type ='" + Me.type.ToString + "'"

                ' Error handling for the query
                Try
                    ' Execute the query
                    sqlreader = sqlcommand.ExecuteReader

                Catch ex As Exception
                    ' send the exception to a messagebox
                    MsgBox(ex.Message)

                End Try

                If sqlreader.HasRows = True Then
                    ' If there is a record, the one that we just added, then get the id so that we can relate the record

                    Do While sqlreader.Read
                        question = sqlreader.GetInt64(0)

                    Loop

                    sqlreader.Close() ' close the data reader

                    ' insert command
                    answer = Me.txtAnswer.Text
                    sqlcommand.Connection = Me.connection
                    sqlcommand.CommandText = "insert into short_answers(idshort_answer, saquestion, sa_answer) VALUES(?idshort_answer, ?saquestion, ?sa_answer)"
                    sqlcommand.Parameters.AddWithValue("?idshort_answer", DBNull.Value)
                    sqlcommand.Parameters.AddWithValue("?saquestion", question.ToString)
                    sqlcommand.Parameters.AddWithValue("?sa_answer", Trim(answer))

                    ' Error handling for the insert command
                    Try
                        ' exeute the command
                        sqlcommand.ExecuteNonQuery()
                        shortCreated = True

                    Catch ex As Exception
                        ' send the exception to a messagebox
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

        Me.Close() ' close the connection

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the form
        ' This subroutine is not expecting or returning anything

        Me.Close()

    End Sub
End Class
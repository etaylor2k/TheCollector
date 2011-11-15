Imports MySql.Data.MySqlClient

Public Class CreateTrueOrFalseForm
    Public connection As MySqlConnection
    Public userIdentity As Identity
    Public subject As Integer
    Public type As Integer = 1

    Private Sub checkTorF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkTorF.CheckedChanged
        ' This subroutine will change the answer of the True or False question
        ' This subroutine is not expecting anything and will not return anything

        If Me.checkTorF.Checked = True Then
            ' If the checkbox was checked then change the text to 'True'
            Me.checkTorF.Text = "True"

        Else
            ' If the checkbox was unchecked then change the text to 'False'
            Me.checkTorF.Text = "False"

        End If

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will create the question if it is unique to the subject
        ' This form is not expecting or returning anything

        Dim sqlreader As MySqlDataReader
        Dim sqlcommand As New MySqlCommand
        Dim questionCreated As Boolean = False
        Dim torfCreated As Boolean = False
        Dim question As Integer

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
            ' This is a unique question, create a record in the questons and true_or_false tables

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
                ' If the question actually got created then we need to add the rest of the contents to the true or false table

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
                    sqlcommand.CommandText = "insert into true_or_false(idtrue_or_false, tfquestion, correct_statement) VALUES(?idtrue_or_false, ?tfquestion, ?correct_statement)"
                    sqlcommand.Parameters.AddWithValue("?idtrue_or_false", DBNull.Value)
                    sqlcommand.Parameters.AddWithValue("?tfquestion", question.ToString)

                    If checkTorF.Checked = True Then
                        sqlcommand.Parameters.AddWithValue("?correct_statement", "1")

                    Else
                        sqlcommand.Parameters.AddWithValue("?correct_statement", "0")

                    End If

                    Try
                        sqlcommand.ExecuteNonQuery()
                        torfCreated = True

                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try

                    If torfCreated = True Then
                        MsgBox("Question Created")
                    Else
                        MsgBox("Error creating quesiton")

                    End If
                End If
            Else
                ' If the quesiton was not created
                MsgBox("Error: quesiton not added to the T or F table")

            End If
        End If

        Me.Close() ' Close the form

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the form
        ' This subroutine does not expect or return anything

        Me.Close()

    End Sub
End Class
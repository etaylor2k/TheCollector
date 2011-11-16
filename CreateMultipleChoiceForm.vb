Imports MySql.Data.MySqlClient

Public Class CreateMultipleChoiceForm
    Public userIdentity As Identity
    Public connection As MySqlConnection
    Public subject As Integer
    Public type As Integer = 1

    Private Sub CreateMultipleChoiceForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub checkA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkA.CheckedChanged
        ' This subroutine will control the checkbox for the A answer. If it is checked, it will ensure that there is not another 
        ' checkbox checked
        ' This subroutine is not expecting or returning anything

        If checkA.Checked = True Then
            ' if it is checked, uncheck the other checkbox that could be checked

            If checkB.Checked = True Then checkB.CheckState = CheckState.Unchecked
            If checkC.Checked = True Then checkC.CheckState = CheckState.Unchecked
            If checkD.Checked = True Then checkD.CheckState = CheckState.Unchecked

        End If

    End Sub

    Private Sub checkB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkB.CheckedChanged
        ' This subroutine will control the checkbox for the B answer. If it is checked, it will ensure that there is not another 
        ' checkbox checked
        ' This subroutine is not expecting or returning anything

        If checkB.Checked = True Then
            ' if it is checked, uncheck the other checkbox that could be checked

            If checkA.Checked = True Then checkA.CheckState = CheckState.Unchecked
            If checkC.Checked = True Then checkC.CheckState = CheckState.Unchecked
            If checkD.Checked = True Then checkD.CheckState = CheckState.Unchecked

        End If

    End Sub

    Private Sub checkC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkC.CheckedChanged
        ' This subroutine will control the checkbox for the C answer. If it is checked, it will ensure that there is not another 
        ' checkbox checked
        ' This subroutine is not expecting or returning anything

        If checkC.Checked = True Then
            ' if it is checked, uncheck the other checkbox that could be checked

            If checkA.Checked = True Then checkA.CheckState = CheckState.Unchecked
            If checkB.Checked = True Then checkB.CheckState = CheckState.Unchecked
            If checkD.Checked = True Then checkD.CheckState = CheckState.Unchecked

        End If

    End Sub

    Private Sub checkD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkD.CheckedChanged
        ' This subroutine will control the checkbox for the D answer. If it is checked, it will ensure that there is not another 
        ' checkbox checked
        ' This subroutine is not expecting or returning anything

        If checkD.Checked = True Then
            ' if it is checked, uncheck the other checkbox that could be checked

            If checkA.Checked = True Then checkA.CheckState = CheckState.Unchecked
            If checkB.Checked = True Then checkB.CheckState = CheckState.Unchecked
            If checkC.Checked = True Then checkC.CheckState = CheckState.Unchecked

        End If

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the form
        ' This subroutine is not expecting or returning anything

        Me.Close()

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim sqlreader As MySqlDataReader
        Dim sqlcommand As New MySqlCommand
        Dim questionCreated As Boolean = False
        Dim multipleCreated As Boolean = False
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

                    multipleCreated = addMultipleChoiceAnswer(question, Trim(txtAnswerA.Text), checkA.Checked)

                    If multipleCreated = True Then
                        multipleCreated = addMultipleChoiceAnswer(question, Trim(txtAnswerB.Text), checkB.Checked)

                        If multipleCreated = True Then
                            multipleCreated = addMultipleChoiceAnswer(question, Trim(txtAnswerC.Text), checkC.Checked)

                            If multipleCreated = True Then
                                multipleCreated = addMultipleChoiceAnswer(question, Trim(txtAnswerD.Text), checkD.Checked)

                            End If

                        End If
                    End If

                    If multipleCreated = True Then
                        MsgBox("Question Created")
                    Else
                        MsgBox("Error Creating Question")
                    End If
                End If
            Else
                ' If the quesiton was not created
                MsgBox("Error: quesiton not added to the Multiple Choice table")

            End If
        End If

        Me.Close() ' Close the form

    End Sub

    Public Function addMultipleChoiceAnswer(ByVal question As Integer, ByVal text As String, ByVal correct As Boolean) As Boolean
        ' This function will create a single choice for the multiple choice question

        Dim createdChoice As Boolean = False
        Dim sqlcom As New MySqlCommand

        sqlcom.Connection = Me.connection
        sqlcom.CommandText = "insert into multiple_choices(idmultiple_choices, mcquestion, answer_text, correct_answer) VALUES(?idmultiple_choices, ?mcquestion, ?answer_text, ?correct_answer)"
        sqlcom.Parameters.AddWithValue("?idmultiple_choices", DBNull.Value)
        sqlcom.Parameters.AddWithValue("?mcquestion", question.ToString)
        sqlcom.Parameters.AddWithValue("?answer_text", text)

        If correct = True Then
            sqlcom.Parameters.AddWithValue("?correct_answer", "1")

        Else
            sqlcom.Parameters.AddWithValue("?correct_answer", "0")

        End If

        Try
            sqlcom.ExecuteNonQuery()
            createdChoice = True

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        Return createdChoice

    End Function
End Class
' MultipleChoiceForm
' This class represents the multiple choice question form
' Endris Taylor for The Collective

Imports MySql.Data.MySqlClient ' MySql functionalities

Public Class MultipleChoiceForm

    ' Class variables
    Public connection As MySqlConnection
    Public userIdentity As Identity
    Public test As Integer
    Public question As Integer
    Public answer As Integer

    Private Sub CreateMultipleChoiceForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This subrotuine will load the proper answers, and populate the multiple choice selections
        ' This sunroutine is not expecting or returning anything

        ' declarations
        Dim sqlreader As MySqlDataReader
        Dim sqlcommand As New MySqlCommand
        Dim index As Integer = 0

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        ' gets the answer
        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "Select answer_text, correct_answer from multiple_choices where mcquestion ='" + Me.question.ToString + "'"

        ' Error handling for the query
        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


        If sqlreader.HasRows = True Then
            Do While sqlreader.Read
                ' Populates the multiple choice questions answers
                Select Case index
                    Case 0
                        txtAnswerA.Text = sqlreader.GetString(0)
                        txtAnswerA.ReadOnly = True

                        If sqlreader.GetInt16(1) = 1 Then answer = index

                    Case 1
                        txtAnswerB.Text = sqlreader.GetString(0)
                        txtAnswerB.ReadOnly = True

                        If sqlreader.GetInt16(1) = 1 Then answer = index

                    Case 2
                        txtAnswerC.Text = sqlreader.GetString(0)
                        txtAnswerC.ReadOnly = True

                        If sqlreader.GetInt16(1) = 1 Then answer = index

                    Case 3
                        txtAnswerD.Text = sqlreader.GetString(0)
                        txtAnswerD.ReadOnly = True

                        If sqlreader.GetInt16(1) = 1 Then answer = index

                End Select

                index += 1
            Loop
            sqlreader.Close() ' close the data reader

        Else
            MsgBox("Error Loading Question")
            sqlreader.Close()
            Me.Close()

        End If
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
        ' This subroutine will see if the student entered the correct answer and record the results
        ' This form is not expecting or returning anything

        ' Dim sqlreader As MySqlDataReader
        Dim sqlcommand As New MySqlCommand
        Dim created As Boolean = False

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "insert into answers(idanswers, astudent, atest, aquestion, correct) VALUES(?idanswers, ?astudent, ?atest, ?aquestion, ?correct)"

        ' Replace the parameters
        sqlcommand.Parameters.AddWithValue("?idanswers", DBNull.Value)
        sqlcommand.Parameters.AddWithValue("?astudent", Me.userIdentity.id.ToString)
        sqlcommand.Parameters.AddWithValue("?atest", Me.test.ToString)
        sqlcommand.Parameters.AddWithValue("?aquestion", Me.question.ToString)


        If Me.checkA.Checked = True Then
            If Me.answer = 0 Then
                sqlcommand.Parameters.AddWithValue("?correct", "1")
                MsgBox("Correct")

            Else
                sqlcommand.Parameters.AddWithValue("?correct", "0")
                MsgBox("Incorrect")

            End If
        End If

        If Me.checkB.Checked = True Then
            If Me.answer = 1 Then
                sqlcommand.Parameters.AddWithValue("?correct", "1")
                MsgBox("Correct")

            Else
                sqlcommand.Parameters.AddWithValue("?correct", "0")
                MsgBox("Incorrect")

            End If
        End If

        If Me.checkC.Checked = True Then
            If Me.answer = 2 Then
                sqlcommand.Parameters.AddWithValue("?correct", "1")
                MsgBox("Correct")

            Else
                sqlcommand.Parameters.AddWithValue("?correct", "0")
                MsgBox("Incorrect")

            End If
        End If

        If Me.checkD.Checked = True Then
            If Me.answer = 3 Then
                sqlcommand.Parameters.AddWithValue("?correct", "1")
                MsgBox("Correct")

            Else
                sqlcommand.Parameters.AddWithValue("?correct", "0")
                MsgBox("Incorrect")

            End If
        End If

        Try
            sqlcommand.ExecuteNonQuery()
            created = True

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If created = False Then
            MsgBox("Error recording answer")

        End If

        Me.Close() ' Close the form

    End Sub


End Class
Imports MySql.Data.MySqlClient

Public Class ShortAnswerFrom
    Public connection As MySqlConnection
    Public userIdentity As Identity
    Public test As Integer
    Public question As Integer
    Public answer As String

    Private Sub CreateShortAnswerFrom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This subroutine will get the correct answer from the database from this question
        ' This subroutine is not expecting or returning anything 

        Dim sqlreader As MySqlDataReader
        Dim sqlcommand As New MySqlCommand

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "Select sa_answer from short_answers where saquestion ='" + Me.question.ToString + "'"

        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            Do While sqlreader.Read
                answer = sqlreader.GetString(0)

            Loop
            sqlreader.Close()

        Else
            MsgBox("Error Loading Question")
            sqlreader.Close()
            Me.Close()

        End If

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

        If Trim(Me.answer.ToLower) = (Me.txtAnswer.Text.ToLower) Then
            sqlcommand.Parameters.AddWithValue("?correct", "1")
            MsgBox("Correct")

        Else
            sqlcommand.Parameters.AddWithValue("?correct", "0")
            MsgBox("Incorrect")
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

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the form
        ' This subroutine is not expecting or returning anything

        Me.Close()

    End Sub
End Class
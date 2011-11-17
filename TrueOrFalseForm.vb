Imports MySql.Data.MySqlClient

Public Class TrueOrFalseForm
    Public connection As MySqlConnection
    Public userIdentity As Identity
    Public test As Integer
    Public question As Integer
    Public answer As Boolean = False

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

        If Me.checkTorF.Checked = Me.answer Then
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
        ' This subroutine does not expect or return anything

        Me.Close()

    End Sub

    Private Sub TrueOrFalseForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This subroutine will load the answer for this question
        ' This subroutine 

        Dim sqlreader As MySqlDataReader
        Dim sqlcommand As New MySqlCommand

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select correct_statement from true_or_false where tfquestion ='" + Me.question.ToString + "'"

        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


        If sqlreader.HasRows = True Then
            Do While sqlreader.Read
                If sqlreader.GetInt16(0) = 1 Then Me.answer = True

            Loop
        Else

            MsgBox("Error loading the connection")

            Me.Close()

        End If

        sqlreader.Close()

    End Sub
End Class
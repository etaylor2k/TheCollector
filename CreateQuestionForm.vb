Imports MySql.Data.MySqlClient

Public Class CreateQuestionForm

    Public userIdentity As Identity
    Public connection As MySqlConnection
    Public subject As Integer

    Private Sub CreateQuestionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This subroutine will load the question types to create the question for the users and pass the subject that the teacher teaches to the other quesiton 
        ' forms so that we can store the questions with the proper subject
        ' This subroutine is not expecting anything and will not return anything

        Dim sqlcommand As New MySqlCommand
        Dim sqlreader As MySqlDataReader

        ' Open the connection if it is closed
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select * from question_types"

        ' Execute the SQL query
        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            ' If there are rows 

            Do While sqlreader.Read
                lstQuestionTypes.Items.Add(sqlreader.GetString(1))

            Loop
        End If

        sqlreader.Close() ' close the connection

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select tsubject from teachers where user = '" + Me.userIdentity.id.ToString + "'"

        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            Do While sqlreader.Read
                Me.subject = sqlreader.GetInt64(0)

            Loop
        End If

        sqlreader.Close()


    End Sub

    Private Sub cmdCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
        ' This subroutine will show the form to create the question of the type the user requests
        ' This subroutine is not expecting anything and will not return anything. 

        Dim trueOrFalse As New CreateTrueOrFalseForm
        Dim shortAnswer As New CreateShortAnswerFrom
        Dim multipleChoice As New CreateMultipleChoiceForm

        Select Case Me.lstQuestionTypes.SelectedItem.ToString

            Case "True or False"
                trueOrFalse.MdiParent = Me.MdiParent
                trueOrFalse.connection = Me.connection
                trueOrFalse.userIdentity = Me.userIdentity
                trueOrFalse.subject = Me.subject
                Me.Hide()
                trueOrFalse.Show()

            Case "Short Answer"
                shortAnswer.MdiParent = Me.MdiParent
                shortAnswer.connection = Me.connection
                shortAnswer.userIdentity = Me.userIdentity
                shortAnswer.subject = Me.subject
                Me.Hide()
                shortAnswer.Show()

            Case "Multiple Choice"
                multipleChoice.MdiParent = Me.MdiParent
                multipleChoice.connection = Me.connection
                multipleChoice.userIdentity = Me.userIdentity
                multipleChoice.subject = Me.subject
                Me.Hide()
                multipleChoice.Show()

        End Select


        Me.Close()


    End Sub


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the create questions form
        ' This subroutine is not expecting anything or passing anything back

        Me.Close()

    End Sub

    Private Sub lstQuestionTypes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstQuestionTypes.DoubleClick
        ' This subroutine will show the form to create the question of the type the user requests
        ' This subroutine is not expecting anything and will not return anything. 

        Dim trueOrFalse As New CreateTrueOrFalseForm
        Dim shortAnswer As New CreateShortAnswerFrom
        Dim multipleChoice As New CreateMultipleChoiceForm

        Select Case Me.lstQuestionTypes.SelectedItem.ToString

            Case "True or False"
                trueOrFalse.MdiParent = Me.MdiParent
                trueOrFalse.connection = Me.connection
                trueOrFalse.userIdentity = Me.userIdentity
                trueOrFalse.subject = Me.subject
                Me.Hide()
                trueOrFalse.Show()

            Case "Short Answer"
                shortAnswer.MdiParent = Me.MdiParent
                shortAnswer.connection = Me.connection
                shortAnswer.userIdentity = Me.userIdentity
                shortAnswer.subject = Me.subject
                Me.Hide()
                shortAnswer.Show()

            Case "Multiple Choice"
                multipleChoice.MdiParent = Me.MdiParent
                multipleChoice.connection = Me.connection
                multipleChoice.userIdentity = Me.userIdentity
                multipleChoice.subject = Me.subject
                Me.Hide()
                multipleChoice.Show()

        End Select


        Me.Close()

    End Sub

End Class
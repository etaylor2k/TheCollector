' CreateQuestionForm
' This class represents a teacher creating a questions
' Endris Taylor for the Collective

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

        ' query to select question types
        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select * from question_types"

        ' Execute the SQL query with error handling
        Try
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            ' send exception to a messagebox
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            ' If there are rows 

            Do While sqlreader.Read
                lstQuestionTypes.Items.Add(sqlreader.GetString(1))
                ' add to the list
            Loop
        End If

        sqlreader.Close() ' close the connection

        ' check the connection
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        ' select the subject that the teacher teaches
        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select tsubject from teachers where user = '" + Me.userIdentity.id.ToString + "'"

        ' Error handling for the query
        Try
            ' execute the query
            sqlreader = sqlcommand.ExecuteReader

        Catch ex As Exception
            ' send the exception to a messagebox
            MsgBox(ex.Message)

        End Try

        If sqlreader.HasRows = True Then
            ' if any data is returned
            Do While sqlreader.Read
                ' record the subject
                Me.subject = sqlreader.GetInt64(0)

            Loop
        End If

        sqlreader.Close() ' close the data reader


    End Sub

    Private Sub cmdCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
        ' This subroutine will show the form to create the question of the type the user requests
        ' This subroutine is not expecting anything and will not return anything. 

        ' declarations
        Dim trueOrFalse As New CreateTrueOrFalseForm
        Dim shortAnswer As New CreateShortAnswerFrom
        Dim multipleChoice As New CreateMultipleChoiceForm

        ' select the type of question the user wants to create
        Select Case Me.lstQuestionTypes.SelectedItem.ToString

            Case "True or False"
                ' open a true or false form
                trueOrFalse.MdiParent = Me.MdiParent
                trueOrFalse.connection = Me.connection
                trueOrFalse.userIdentity = Me.userIdentity
                trueOrFalse.subject = Me.subject
                Me.Hide()
                trueOrFalse.Show()

            Case "Short Answer"
                ' open a short answer form
                shortAnswer.MdiParent = Me.MdiParent
                shortAnswer.connection = Me.connection
                shortAnswer.userIdentity = Me.userIdentity
                shortAnswer.subject = Me.subject
                Me.Hide()
                shortAnswer.Show()

            Case "Multiple Choice"
                ' open a multipole choice form
                multipleChoice.MdiParent = Me.MdiParent
                multipleChoice.connection = Me.connection
                multipleChoice.userIdentity = Me.userIdentity
                multipleChoice.subject = Me.subject
                Me.Hide()
                multipleChoice.Show()

        End Select


        Me.Close() ' close the form


    End Sub


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the create questions form
        ' This subroutine is not expecting anything or passing anything back

        Me.Close()

    End Sub

    Private Sub lstQuestionTypes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstQuestionTypes.DoubleClick
        ' This subroutine will show the form to create the question of the type the user requests
        ' This subroutine is not expecting anything and will not return anything. 

        ' declarations
        Dim trueOrFalse As New CreateTrueOrFalseForm
        Dim shortAnswer As New CreateShortAnswerFrom
        Dim multipleChoice As New CreateMultipleChoiceForm

        ' select the type of question the user wants to create
        Select Case Me.lstQuestionTypes.SelectedItem.ToString

            Case "True or False"
                ' show the true or false form
                trueOrFalse.MdiParent = Me.MdiParent
                trueOrFalse.connection = Me.connection
                trueOrFalse.userIdentity = Me.userIdentity
                trueOrFalse.subject = Me.subject
                Me.Hide()
                trueOrFalse.Show()

            Case "Short Answer"
                ' show the short answer form
                shortAnswer.MdiParent = Me.MdiParent
                shortAnswer.connection = Me.connection
                shortAnswer.userIdentity = Me.userIdentity
                shortAnswer.subject = Me.subject
                Me.Hide()
                shortAnswer.Show()

            Case "Multiple Choice"
                ' show the multiple choice form
                multipleChoice.MdiParent = Me.MdiParent
                multipleChoice.connection = Me.connection
                multipleChoice.userIdentity = Me.userIdentity
                multipleChoice.subject = Me.subject
                Me.Hide()
                multipleChoice.Show()

        End Select


        Me.Close() ' close the form

    End Sub

End Class
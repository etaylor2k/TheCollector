Imports MySql.Data.MySqlClient

Public Class CreateShortAnswerFrom
    Public userIdentity As Identity
    Public connection As MySqlConnection
    Public subject As Integer

    Private Sub CreateShortAnswerFrom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This subroutine will load the user preferences
        ' This subroutine is not expecting or returning anything

        Dim sqlcommand As New MySqlCommand
        Dim sqlreader As MySqlDataReader

        ' assign the 
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select * from teachers with "
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will save the question in the database 
        Dim createQuestion As New CreateQuestionForm

        createQuestion.connection = Me.connection
        createQuestion.MdiParent = Me.MdiParent

        Me.Hide()
        createQuestion.Show()
        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the form
        ' This subroutine is not expecting or returning anything

        Dim createQuestion As New CreateQuestionForm

        createQuestion.connection = Me.connection
        createQuestion.MdiParent = Me.MdiParent

        Me.Hide()
        createQuestion.Show()
        Me.Close()
    End Sub
End Class
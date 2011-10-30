Imports MySql.Data.MySqlClient

Public Class CreateClassForm

    Public connection As MySqlConnection

    Public ccfIdentity As Identity


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will attempt to create the classes
        ' This subroutine is not expecting anything and will not return anything

        
    End Sub


    Private Sub CreateClassForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' This subroutine will load the proper values when the form is created/ activated

        Dim sqlCCommand As New MySqlCommand
        Dim sqlCReader As MySqlDataReader
        Dim list_string As String
        'Dim item As 


        If (Me.connection.State = ConnectionState.Closed) Then
            ' if the connection is closed, open it
            Me.connection.Open()

        End If

        sqlCCommand.Connection = Me.connection
        sqlCCommand.CommandText = "select subjects.code,courses.number,courses.title from courses, teachers, subjects where courses.subject = teachers.tsubject and subjects.idsubjects = teachers.tsubject and teachers.user ='" + Me.ccfIdentity.id.ToString + "'"
        
        sqlCReader = sqlCCommand.ExecuteReader

        If sqlCReader.HasRows = True Then
            Do While sqlCReader.Read
                list_string = sqlCReader.GetString(0) + sqlCReader.GetString(1) + " " + sqlCReader.GetString(2)
                Me.comboCourse.Items.Add(list_string)

            Loop
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        Me.Close()

    End Sub
End Class
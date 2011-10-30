Imports MySql.Data.MySqlClient

Public Class CreateClassForm

    Public connection As MySqlConnection

    Public ccfIdentity As Identity


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will attempt to create the classes
        ' This subroutine is not expecting anything and will not return anything

        Dim sqlICommnad As New MySqlCommand

        'If the two required fields are not populated then the user did not want to 
        If ((txtSection.Text = "") And (txtYear.Text = "")) Then

            If () then 
                ]
            End If
        End If

        Me.Close()

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
                ' If there are any results
                list_string = sqlCReader.GetString(0) + sqlCReader.GetString(1) + " " + sqlCReader.GetString(2) ' create the string
                Me.comboCourse.Items.Add(list_string) ' add it the the dropdown box

            Loop
            Me.comboCourse.SelectedIndex = 0 ' This will set the default item as the first item in the list
        End If


        sqlCReader.Close() ' close the reader

        'reopen the connection for the next query - Grade Level
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()
        sqlCCommand.CommandText = "select levelname from grade_levels"

        sqlCReader = sqlCCommand.ExecuteReader

        If sqlCReader.HasRows = True Then
            Do While sqlCReader.Read
                ' if there are any results then add them to the combo box
                list_string = sqlCReader.GetString(0)
                Me.comboGradeLevel.Items.Add(list_string)
            Loop
            Me.comboGradeLevel.SelectedIndex = 0 ' set the default item as the first in the list
        End If

        sqlCReader.Close() ' close the reader

        'reopen the connection for the last query - Semester
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()
        sqlCCommand.CommandText = "select name from semesters"

        sqlCReader = sqlCCommand.ExecuteReader

        If sqlCReader.HasRows = True Then
            Do While sqlCReader.Read
                ' if there are any results then add them to the combo box
                list_string = sqlCReader.GetString(0)
                Me.comboSemester.Items.Add(list_string)
            Loop
            Me.comboSemester.SelectedIndex = 0 ' set the default item as the first in the list
        End If

        sqlCReader.Close() ' close the reader

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the window when the user clicks the cancel button
        ' This subroutine is not expecting or passing any perameters

        Me.Close()

    End Sub
End Class
Imports MySql.Data.MySqlClient

Public Class CreateClassForm

    Public connection As MySqlConnection

    Public ccfIdentity As Identity


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will attempt to create the classes
        ' This subroutine is not expecting anything and will not return anything

        Dim sqlICommnad As New MySqlCommand
        Dim sqlIReader As MySqlDataReader

        'These variables will represent the id's of their respective tables, all which are foreign keys for the classes table
        Dim course As Integer
        Dim gradelevel As Integer
        Dim semester As Integer
        Dim section As Integer
        Dim created As Boolean = False

        ' To see if the connection is closed
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        ' Get the correct values from the combination box
        course = Me.comboCourse.SelectedValue
        gradelevel = Me.comboGradeLevel.SelectedValue
        semester = Me.comboSemester.SelectedValue
        section = Me.comboSection.SelectedValue

        sqlICommnad.Connection = Me.connection
        sqlICommnad.CommandText = "select * from classes where course ='" + course.ToString + "' and grade_level ='" + gradelevel.ToString + "' and " _
                & "semester ='" + semester.ToString + "' and section ='" + section.ToString + "' and year ='" + numYear.Value.ToString + "'"

        sqlIReader = sqlICommnad.ExecuteReader
        If sqlIReader.HasRows = True Then
            MsgBox("Error: Class already Exists")

            sqlIReader.Close()

        Else
            ' If the class does not exist, create it

            sqlIReader.Close()

            sqlICommnad.CommandText = "insert into classes(idclasses, course, grade_level, teacher, section, semester, year)" _
                                 & "VALUES(?idclasses, ?course, ?grade_level, ?teacher, ?section, ?semester, ?year)"

            sqlICommnad.Parameters.AddWithValue("?idclasses", DBNull.Value) ' null for the id since it is auto incriment
            sqlICommnad.Parameters.AddWithValue("?course", course.ToString)
            sqlICommnad.Parameters.AddWithValue("?grade_level", gradelevel.ToString)
            sqlICommnad.Parameters.AddWithValue("?teacher", Me.ccfIdentity.id.ToString)
            sqlICommnad.Parameters.AddWithValue("?section", section.ToString)
            sqlICommnad.Parameters.AddWithValue("?semester", semester.ToString)
            sqlICommnad.Parameters.AddWithValue("?year", numYear.Value.ToString)

            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()
            sqlICommnad.Connection = Me.connection


            Try
                sqlICommnad.ExecuteNonQuery() ' execute the insert
                created = True
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            If created Then MsgBox("Class Created") ' Alert the user that

        End If



        Me.Close()

    End Sub


    Private Sub CreateClassForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' This subroutine will load the proper values when the form is created/ activated

        Dim sqlCCommand As New MySqlCommand
        Dim sqlCReader As MySqlDataReader
        Dim list_string As String
        Dim courses As New Dictionary(Of String, Integer)
        Dim gradelevels As New Dictionary(Of String, Integer)
        Dim semesters As New Dictionary(Of String, Integer)
        Dim sections As New Dictionary(Of String, Integer)

        If (Me.connection.State = ConnectionState.Closed) Then
            ' if the connection is closed, open it
            Me.connection.Open()

        End If

        sqlCCommand.Connection = Me.connection
        sqlCCommand.CommandText = "select subjects.code,courses.number,courses.title, courses.idcourses from courses, teachers, subjects where courses.subject = teachers.tsubject and subjects.idsubjects = teachers.tsubject and teachers.user ='" + Me.ccfIdentity.id.ToString + "'"
        
        sqlCReader = sqlCCommand.ExecuteReader

        If sqlCReader.HasRows = True Then
            Do While sqlCReader.Read
                ' If there are any results
                list_string = sqlCReader.GetString(0) + sqlCReader.GetString(1) + " " + sqlCReader.GetString(2) ' create the string
                'Me.comboCourse.Items.Add(list_string) ' add it the the dropdown box
                courses.Add(list_string, sqlCReader.GetUInt64(3))
                list_string = ""

            Loop
            Me.comboCourse.DataSource = New BindingSource(courses, Nothing)
            Me.comboCourse.DisplayMember = "Key"
            Me.comboCourse.ValueMember = "Value"
            Me.comboCourse.SelectedIndex = 0 ' This will set the default item as the first item in the list
        End If


        sqlCReader.Close() ' close the reader

        'reopen the connection for the next query - Grade Level
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()
        sqlCCommand.CommandText = "select * from grade_levels"

        sqlCReader = sqlCCommand.ExecuteReader

        If sqlCReader.HasRows = True Then
            Do While sqlCReader.Read
                ' if there are any results then add them to the combo box
                gradelevels.Add(sqlCReader.GetString(1), sqlCReader.GetInt64(0))

            Loop

            Me.comboGradeLevel.DataSource = New BindingSource(gradelevels, Nothing)
            Me.comboGradeLevel.DisplayMember = "Key"
            Me.comboGradeLevel.ValueMember = "Value"
            Me.comboGradeLevel.SelectedIndex = 0 ' set the default item as the first in the list
        End If

        sqlCReader.Close() ' close the reader

        'reopen the connection for the query - Semester
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()
        sqlCCommand.CommandText = "select * from semesters"

        sqlCReader = sqlCCommand.ExecuteReader

        If sqlCReader.HasRows = True Then
            Do While sqlCReader.Read
                ' if there are any results then add them to the combo box
                semesters.Add(sqlCReader.GetString(1), sqlCReader.GetInt64(0))

            Loop

            Me.comboSemester.DataSource = New BindingSource(semesters, Nothing)
            Me.comboSemester.DisplayMember = "Key"
            Me.comboSemester.ValueMember = "Value"
            Me.comboSemester.SelectedIndex = 0 ' set the default item as the first in the list
        End If

        sqlCReader.Close() ' close the reader

        'reopen the connection for the last query - Sections
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()
        sqlCCommand.CommandText = "select * from sections"

        sqlCReader = sqlCCommand.ExecuteReader

        If sqlCReader.HasRows = True Then
            Do While sqlCReader.Read
                ' if there are any results then add them to the combo box
                sections.Add(sqlCReader.GetString(1), sqlCReader.GetInt64(0))

            Loop

            Me.comboSection.DataSource = New BindingSource(sections, Nothing)
            Me.comboSection.DisplayMember = "Key"
            Me.comboSection.ValueMember = "Value"
            Me.comboSection.SelectedIndex = 0 ' set the default item as the first in the list
        End If

        sqlCReader.Close() ' close the reader
        'set the year text box to the current year

        numYear.Minimum = Now.Year
        numYear.Maximum = Now.Year + 3
        numYear.Value = Now.Year
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the window when the user clicks the cancel button
        ' This subroutine is not expecting or passing any perameters

        Me.Close()

    End Sub

    Private Sub txtYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class

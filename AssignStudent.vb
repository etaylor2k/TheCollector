Imports MySql.Data.MySqlClient

Public Class AssignStudent

    Public connection As MySqlConnection
    Private students As New Dictionary(Of String, Integer) ' This will represent the dictionary of students in the list box
    Private classes As New Dictionary(Of String, Integer) ' This will represent the dictionary of classes in the combo box

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will cancel all operations for this form
        ' This form is not expecting or returning anything

        Me.Close()

    End Sub

    Private Sub AssignStudent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' This subroutine will load the students and class inforamtion into the list and combo box when the form loads
        ' This subroutine is not expecting or returning anything

        Dim sqlReader As MySqlDataReader
        Dim sqlCommand As New MySqlCommand
        Dim studentString As String = ""
        Dim classesString As String = ""

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlCommand.Connection = Me.connection
        sqlCommand.CommandText = "select * from students, users where student_user = idusers"

        Try
            sqlReader = sqlCommand.ExecuteReader
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlReader.HasRows = True Then
            ' if there are any rows then add then to the list box
            Do While sqlReader.Read
                studentString = sqlReader.GetString(6) + " " + sqlReader.GetString(7)
                Me.students.Add(studentString, sqlReader.GetInt32(2)) ' Create the dictionary to look up later
                Me.lstStudents.Items.Add(sqlReader.GetString(6) + " " + sqlReader.GetString(7)) ' add the values to the list box
                studentString = ""

            Loop

            sqlReader.Close()

        Else
            sqlReader.Close()

            MsgBox("There are not any students on File")
            Me.Close()

        End If

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlCommand.CommandText = "select subjects.code, courses.number, courses.title, semesters.name, classes.year, classes.idclasses from classes,courses, subjects, semesters where classes.teacher =2 and courses.subject = subjects.idsubjects and classes.semester = semesters.idsemester"

        Try
            sqlReader = sqlCommand.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlReader.HasRows = True Then

            Do While sqlReader.Read
                classesString = sqlReader.GetString(0) + sqlReader.GetString(1) + " " + sqlReader.GetString(2) + "(" + sqlReader.GetString(3) + " " + sqlReader.GetString(4) + ")"
                Me.classes.Add(classesString, sqlReader.GetInt64(5))
                Me.comboClasses.Items.Add(classesString)

            Loop
            Me.comboClasses.SelectedIndex = 0

            sqlReader.Close()

        Else

            sqlReader.Close()
            MsgBox("No Classes on file for this teacher")
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will assign a student to a class
        ' This subroutine is expecting a value for the student and class and then will

        Dim sqlreader As MySqlDataReader
        Dim sqlcommand As New MySqlCommand
        Dim classValue As Integer
        Dim studentValue As Integer

        classValue = Me.classes.Item(Me.comboClasses.SelectedItem.ToString)
        studentValue = Me.students.Item(Me.lstStudents.SelectedItem.ToString)

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select * from student_classes where class ='" + classValue + "' and student ='" + studentValue + "'"

        Try
            sqlreader = sqlcommand.ExecuteReader()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        If sqlreader.HasRows = True Then
            ' If there is a class that comes back, the student is already assigned to that class
            sqlreader.Close()

            MsgBox("Student already assigned to class")

        Else
            ' The student is not a part of that class, add them

            sqlreader.Close()

            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

            sqlcommand.CommandText = "insert into student_classes(idclasses, class, student) VALUES(?idclasses, ?course, ?grade_level, ?teacher, ?section, ?semester, ?year)"
        End If

        Me.Close()

    End Sub
End Class
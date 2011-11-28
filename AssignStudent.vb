' AssignStudent
' This class represents the functionality to assign a student to a class
' Endris Taylor for The Collective

Imports MySql.Data.MySqlClient ' For the MySQL functions

Public Class AssignStudent

    ' Class Variables
    Public connection As MySqlConnection
    Private students As New Dictionary(Of String, Integer) ' This will represent the dictionary of students in the list box
    Private classes As New Dictionary(Of String, Integer) ' This will represent the dictionary of classes in the combo box
    Public userIdentity As Identity

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will cancel all operations for this form
        ' This form is not expecting or returning anything

        Me.Close()

    End Sub

    Private Sub AssignStudent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' This subroutine will load the students and class inforamtion into the list and combo box when the form loads
        ' This subroutine is not expecting or returning anything

        ' Declarations
        Dim sqlReader As MySqlDataReader
        Dim sqlCommand As New MySqlCommand
        Dim studentString As String = ""
        Dim classesString As String = ""

        'Checks the status of the connection
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        ' query to select all of the students
        sqlCommand.Connection = Me.connection
        sqlCommand.CommandText = "select * from students, users where student_user = idusers"

        ' Error handling
        Try
            ' Execute the query
            sqlReader = sqlCommand.ExecuteReader

        Catch ex As Exception
            ' send the exception to a message box
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

            sqlReader.Close() ' close the data reader

        Else
            sqlReader.Close() ' close the data reader

            MsgBox("There are not any students on File")
            Me.Close()

        End If

        ' check the connection
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()
        ' query for all of the classes for the teacher/user
        sqlCommand.CommandText = "select subjects.code, courses.number, courses.title, semesters.name, classes.year, classes.idclasses from classes,courses, subjects, semesters where classes.teacher ='" + Me.userIdentity.id.ToString + "' and courses.subject = subjects.idsubjects and classes.semester = semesters.idsemester"

        ' error handling for the query
        Try
            ' execute the query 
            sqlReader = sqlCommand.ExecuteReader

        Catch ex As Exception
            ' send exception to the messagebox
            MsgBox(ex.Message)

        End Try

        If sqlReader.HasRows = True Then
            ' If the query returns something

            Do While sqlReader.Read
                ' Add classes to the combo/ dropdown box and the dictionary
                classesString = sqlReader.GetString(0) + sqlReader.GetString(1) + " " + sqlReader.GetString(2) + "(" + sqlReader.GetString(3) + " " + sqlReader.GetString(4) + ")"
                Me.classes.Add(classesString, sqlReader.GetInt64(5))
                Me.comboClasses.Items.Add(classesString)

            Loop
            Me.comboClasses.SelectedIndex = 0

            sqlReader.Close() ' Close the data reader

        Else
            ' If this are not any classes for the teacher alert them
            sqlReader.Close()
            MsgBox("No Classes on file for this teacher")
            Me.Close()

        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will assign a student to a class
        ' This subroutine is expecting a value for the student and class and then will

        ' Declarations
        Dim sqlreader As MySqlDataReader
        Dim sqlcommand As New MySqlCommand
        Dim classValue As Integer
        Dim studentValue As Integer
        Dim created As Boolean = False

        ' Get the user selected values from the user interface
        classValue = Me.classes.Item(Me.comboClasses.SelectedItem.ToString)
        studentValue = Me.students.Item(Me.lstStudents.SelectedItem.ToString)

        ' Check the connection
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        ' query to see if the student is already in the class
        sqlcommand.Connection = Me.connection
        sqlcommand.CommandText = "select * from class_students where class ='" + classValue.ToString + "' and student ='" + studentValue.ToString + "'"

        ' Error handeling for the query
        Try
            ' Execute the reader
            sqlreader = sqlcommand.ExecuteReader()

        Catch ex As Exception
            ' send the exception to a message box 
            MsgBox(ex.Message)

        End Try


        If sqlreader.HasRows = True Then
            ' If there is a class that comes back, the student is already assigned to that class
            sqlreader.Close()

            MsgBox("Student already assigned to class")

        Else
            ' The student is not a part of that class, add them

            sqlreader.Close()

            ' check connection
            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

            ' insert command
            sqlcommand.CommandText = "insert into class_students(idclass_students, class, student) VALUES(?idclass_students, ?class, ?student)"

            ' Replace the parameters
            sqlcommand.Parameters.AddWithValue("?idclass_students", DBNull.Value)
            sqlcommand.Parameters.AddWithValue("?class", classValue.ToString)
            sqlcommand.Parameters.AddWithValue("?student", studentValue.ToString)


            Try
                sqlcommand.ExecuteNonQuery() ' execute the insert
                created = True

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            If created Then MsgBox("Student Assigned to Class") ' Alert the user that the student was assigned to the class

        End If

        Me.Close()

    End Sub
End Class
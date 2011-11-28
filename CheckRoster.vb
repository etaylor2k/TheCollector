' CheckRoster
' This class represents a teacher being able to check their roster based off of a class
' Endris Taylor for the Collective

Imports MySql.Data.MySqlClient ' MySql functionality

Public Class CheckRoster

    ' Class Variables
    Public connection As MySqlConnection
    Private classes As New Dictionary(Of String, Integer) ' This will represent the dictionary of classes in the combo box
    Public initial As Boolean = True
    Public userIdentity As Identity

    Private Sub CheckStudent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' This subroutine will load the students and class inforamtion into the list and combo box when the form loads
        ' This subroutine is not expecting or returning anything

        ' Delcarations
        Dim sqlReader As MySqlDataReader
        Dim sqlCommand As New MySqlCommand
        Dim classesString As String = ""
        Dim classValue As Integer

        ' check connection
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        ' query for the courses the classes the teacher has
        sqlCommand.Connection = Me.connection
        sqlCommand.CommandText = "select subjects.code, courses.number, courses.title, semesters.name, classes.year, classes.idclasses from classes,courses, subjects, semesters where classes.teacher ='" + Me.userIdentity.id.ToString + "' and courses.subject = subjects.idsubjects and classes.semester = semesters.idsemester"

        ' Error handeling for the query
        Try
            ' execute the query
            sqlReader = sqlCommand.ExecuteReader

        Catch ex As Exception
            ' send exception to a messagebox
            MsgBox(ex.Message)

        End Try

        If sqlReader.HasRows = True Then
            ' If there are are any results

            Do While sqlReader.Read
                ' Add the results to the combobox and the dictionary
                classesString = sqlReader.GetString(0) + sqlReader.GetString(1) + " " + sqlReader.GetString(2) + "(" + sqlReader.GetString(3) + " " + sqlReader.GetString(4) + ")"
                Me.classes.Add(classesString, sqlReader.GetInt64(5))
                Me.comboClasses.Items.Add(classesString)

            Loop

            Me.comboClasses.SelectedIndex = 0

            sqlReader.Close() ' Close the data reader

        Else
            ' If there are not any results
            sqlReader.Close() ' close the data reader
            MsgBox("No Classes on file for this teacher")
        End If

        classValue = Me.classes.Item(Me.comboClasses.SelectedItem.ToString)

        ' check the connection
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        ' selects the students in the class
        sqlCommand.CommandText = "select users.* from users, class_students, classes where users.idusers = class_students.student and class_students.class = classes.idclasses and classes.idclasses ='" + classValue.ToString + "'"

        Try
            sqlReader = sqlCommand.ExecuteReader
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlReader.HasRows = True Then
            ' if there are any rows then add then to the list box
            Do While sqlReader.Read
                ' add students to the list box
                Me.lstStudents.Items.Add(sqlReader.GetString(4) + " " + sqlReader.GetString(5)) ' add the values to the list box

            Loop

            sqlReader.Close() ' close the data reader

        Else
            ' If there are not any records
            sqlReader.Close() ' close the data reader

            MsgBox("There are not any students registered for this class")

        End If

    End Sub

   
    Private Sub comboClasses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboClasses.SelectedIndexChanged
        ' This subroutine will change the class roster list when the dropdown menu chagnes
        ' This subroutine is not expecting or returning anything

        ' Declarations
        Dim sqlReader As MySqlDataReader
        Dim sqlCommand As New MySqlCommand
        Dim classesString As String = ""
        Dim classValue As Integer

        ' test to see if this is the first pass, if it is this is not needed
        If Me.initial = True Then
            Me.initial = False

        Else
            ' If this is not the first pass then we need to update the listbox with the students for the selected class

            ' Get the value from the dictionary and clear the listbox
            classValue = Me.classes.Item(Me.comboClasses.SelectedItem.ToString)
            Me.lstStudents.Items.Clear()

            ' Check the connection
            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

            ' Queery for the users in the class
            sqlCommand.Connection = Me.connection
            sqlCommand.CommandText = "select users.* from users, class_students, classes where users.idusers = class_students.student and class_students.class = classes.idclasses and classes.idclasses ='" + classValue.ToString + "'"

            ' Error handling for the query
            Try
                ' Execute the query
                sqlReader = sqlCommand.ExecuteReader

            Catch ex As Exception
                ' send exception to a message box
                MsgBox(ex.Message)

            End Try

            If sqlReader.HasRows = True Then
                ' if there are any rows then add then to the list box
                Do While sqlReader.Read
                    ' Add the students to the list
                    Me.lstStudents.Items.Add(sqlReader.GetString(4) + " " + sqlReader.GetString(5)) ' add the values to the list box

                Loop

                sqlReader.Close() ' close the data reader

            Else
                ' If there are not any students
                sqlReader.Close() ' close the data reader

                MsgBox("There are not any students registered for this class")

            End If
        End If


    End Sub
End Class
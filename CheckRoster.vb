﻿Imports MySql.Data.MySqlClient

Public Class CheckRoster

    Public connection As MySqlConnection
    Private classes As New Dictionary(Of String, Integer) ' This will represent the dictionary of classes in the combo box
    Public initial As Integer = 1

    Public userIdentity As Identity

    Private Sub CheckStudent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' This subroutine will load the students and class inforamtion into the list and combo box when the form loads
        ' This subroutine is not expecting or returning anything

        Dim sqlReader As MySqlDataReader
        Dim sqlCommand As New MySqlCommand
        Dim classesString As String = ""
        Dim classValue As Integer

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlCommand.Connection = Me.connection
        sqlCommand.CommandText = "select subjects.code, courses.number, courses.title, semesters.name, classes.year, classes.idclasses from classes,courses, subjects, semesters where classes.teacher ='" + Me.userIdentity.id.ToString + "' and courses.subject = subjects.idsubjects and classes.semester = semesters.idsemester"

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

        classValue = Me.classes.Item(Me.comboClasses.SelectedItem.ToString)

        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlCommand.CommandText = "select users.* from users, class_students, classes where users.idusers = class_students.student and class_students.class = classes.idclasses and classes.idclasses ='" + classValue.ToString + "'"

        Try
            sqlReader = sqlCommand.ExecuteReader
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If sqlReader.HasRows = True Then
            ' if there are any rows then add then to the list box
            Do While sqlReader.Read
                Me.lstStudents.Items.Add(sqlReader.GetString(4) + " " + sqlReader.GetString(5)) ' add the values to the list box

            Loop

            sqlReader.Close()

        Else
            sqlReader.Close()

            MsgBox("There are not any students registered for this class")

        End If

    End Sub

   
    Private Sub comboClasses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboClasses.SelectedIndexChanged
        ' This subroutine will change the class roster list when the dropdown menu chagnes
        ' This subroutine is not expecting or returning anything

        Dim sqlReader As MySqlDataReader
        Dim sqlCommand As New MySqlCommand
        Dim classesString As String = ""
        Dim classValue As Integer

        If Me.initial = 1 Then
            Me.initial += 1
        Else


            classValue = Me.classes.Item(Me.comboClasses.SelectedItem.ToString)
            Me.lstStudents.Items.Clear()


            If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

            sqlCommand.Connection = Me.connection
            sqlCommand.CommandText = "select users.* from users, class_students, classes where users.idusers = class_students.student and class_students.class = classes.idclasses and classes.idclasses ='" + classValue.ToString + "'"

            Try
                sqlReader = sqlCommand.ExecuteReader
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            If sqlReader.HasRows = True Then
                ' if there are any rows then add then to the list box
                Do While sqlReader.Read
                    Me.lstStudents.Items.Add(sqlReader.GetString(4) + " " + sqlReader.GetString(5)) ' add the values to the list box

                Loop

                sqlReader.Close()

            Else
                sqlReader.Close()

                MsgBox("There are not any students registered for this class")

            End If
        End If


    End Sub
End Class
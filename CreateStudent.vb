' CreateStudent
' Class for creating a student
' Endris Taylor for The Collective

Imports MySql.Data.MySqlClient ' For MySql functionalities

Public Class CreateStudent

    ' Class Variable
    Public connection As MySqlConnection

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will attempt to create a new student when the user clicks the 'ok' button after they enter the
        '   students information
        ' This subroutine is not expecting anything or returning anything

        ' Declarations
        Dim created As Boolean = False
        Dim uniqueUsername As Boolean = False
        Dim uniqueEmail As Boolean = False
        Dim sqlICommnad As New MySqlCommand
        Dim addedStudent As Boolean = False

        If ((txtEmail.Text <> "") And (txtUsername.Text <> "")) Then
            ' If the two required fields are not empty

            ' check if the student is unique
            uniqueUsername = isUniqueUser("username", txtUsername.Text) ' test to see if the username is unique
            uniqueEmail = isUniqueUser("email", txtEmail.Text) ' test to see if the email unique

            If ((uniqueUsername = True) And (uniqueEmail = True)) Then
                ' if both required fields are unique then we can insert the user into the users table

                'create the insert command
                sqlICommnad.CommandText = "insert into users(idusers, username, password, level, fname, lname, email)" _
                                 & "VALUES(?idusers, ?username, ?password, ?level, ?fname, ?lname, ?email)"

                'subsitute the insert values
                sqlICommnad.Parameters.AddWithValue("?idusers", DBNull.Value) ' null for the id since it is auto incriment
                sqlICommnad.Parameters.AddWithValue("?username", txtUsername.Text)
                sqlICommnad.Parameters.AddWithValue("?password", "password")
                sqlICommnad.Parameters.AddWithValue("?level", 3) ' always this level for students

                If txtFname.Text = "" Then
                    ' if the first name field is blank then enter null
                    sqlICommnad.Parameters.AddWithValue("?fname", DBNull.Value)

                Else
                    ' if the first name field is not null then insert the value
                    sqlICommnad.Parameters.AddWithValue("?fname", txtFname.Text)

                End If

                If txtLname.Text = "" Then
                    ' if the last name field is blank then enter null
                    sqlICommnad.Parameters.AddWithValue("?lname", DBNull.Value)

                Else
                    ' if the last name field is not null then insert the value
                    sqlICommnad.Parameters.AddWithValue("?lname", txtLname.Text)

                End If

                sqlICommnad.Parameters.AddWithValue("?email", txtEmail.Text)

                If Me.connection.State = ConnectionState.Closed Then Me.connection.Open() ' if the connection is closed, then reopen it
                sqlICommnad.Connection = Me.connection ' assign the connection to the commane

                ' Error handling for the insert command
                Try
                    ' execute the command
                    sqlICommnad.ExecuteNonQuery() ' execute the insert
                    created = True


                Catch ex As Exception
                    ' send exception to a messagebox
                    MsgBox(ex.Message)

                End Try

                If created Then
                    MsgBox("Student Created") ' Alert the user that
                    addedStudent = addStudent(txtUsername.Text)

                End If


            End If

        End If
        Me.Close() ' close the data reader

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the window when the user clicks the cancel button
        ' This subroutine is not expecting or passing any perameters

        Me.Close()

    End Sub

    Private Function isUniqueUser(ByVal column As String, ByVal value As String) As Boolean
        ' This subroutine will determine if value passed is not already in the database for the given column
        ' This subroutine is expecting a column name and a value and will return if the value is unique

        Dim isUnique As Boolean = False
        Dim sqlUReader As MySqlDataReader
        Dim sqlUCommand As New MySqlCommand

        If Me.connection.State = ConnectionState.Closed Then
            ' If the connection state is closed then it needs to be open to perform these queries

            Me.connection.Open()

        End If

        ' query the database to make sure that the value is unique
        sqlUCommand.Connection = Me.connection
        sqlUCommand.CommandText = "select * from users where " + column + " ='" + value + "'"

        sqlUReader = sqlUCommand.ExecuteReader

        If sqlUReader.HasRows = False Then
            ' If there are not any rows returned then this is a unique value
            isUnique = True
        End If

        sqlUReader.Close()

        Return isUnique

    End Function

    Private Function addStudent(ByVal username As String) As Boolean
        ' This function will create an entry in the students table
        ' This function is expecting the username of the newly created student 

        ' declarations
        Dim sqlCommand As New MySqlCommand
        Dim sqlReader As MySqlDataReader
        Dim createdStudent As Boolean
        Dim newStudentIndex As Integer

        ' If the connection is closed, open it
        If Me.connection.State = ConnectionState.Closed Then Me.connection.Open()

        sqlCommand.Connection = Me.connection
        sqlCommand.CommandText = "select * from users where username ='" + username + "'"

        Try
            sqlReader = sqlCommand.ExecuteReader

            If sqlReader.HasRows = True Then
                ' If the newly created student was found
                createdStudent = True
                Do While sqlReader.Read
                    newStudentIndex = sqlReader.GetInt64(0)

                Loop

                sqlReader.Close()

                sqlCommand.CommandText = "insert into students(idstudents, student_user) VALUES(?idstudents, ?student_user)"
                sqlCommand.Parameters.AddWithValue("?idstudents", DBNull.Value)
                sqlCommand.Parameters.AddWithValue("student_user", newStudentIndex.ToString)

                Try
                    sqlCommand.ExecuteNonQuery() ' execute the insert


                Catch ex As Exception
                    MsgBox(ex.Message) ' this will deisplay 

                End Try
            End If
        Catch ex As Exception

        End Try

        Return createdStudent

    End Function

End Class
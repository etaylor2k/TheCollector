Imports MySql.Data.MySqlClient

Public Class LoginForm

    Dim numberOfTries As Integer

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        ' This is the subroutine that handles the authentication of the applicaitons
        ' For our purposes this sunroutine is not expecting anything and passing the identity of the user to the next form if authenticated

        Dim connection As MySqlConnection
        Dim sqlReader As MySqlDataReader
        Dim sqlCommand As New MySqlCommand
        Dim authenticated As Boolean = False

        connection = New MySqlConnection
        connection.ConnectionString = "Server=localhost; Uid=appuser; Pwd=password; Database=thecollector; Port=3306"

        Try
            connection.Open()
            sqlCommand.Connection = connection
            sqlCommand.CommandText = "select * from users where username = '" + txtUser.Text + "' and password = '" + txtPass.Text + "'"

            Try
                sqlReader = sqlCommand.ExecuteReader()
                If sqlReader.HasRows Then

                    Do While sqlReader.Read
                        ' read the users information from the query and assigns them to the MainForm's identity structure
                        MainForm.userIdentity.id = sqlReader.GetInt64(0)
                        MainForm.userIdentity.username = sqlReader.GetString(1)
                        MainForm.userIdentity.password = sqlReader.GetString(2)
                        MainForm.userIdentity.level = sqlReader.GetInt64(3)
                        MainForm.userIdentity.fname = sqlReader.GetString(4)
                        MainForm.userIdentity.lname = sqlReader.GetString(5)
                        MainForm.userIdentity.email = sqlReader.GetString(6)

                    Loop

                    authenticated = True
                    MsgBox("Welcome " + MainForm.userIdentity.fname + " " + MainForm.userIdentity.lname)

                    sqlReader.Close()

                    MainForm.connection = connection ' This conneciton 
                    MainForm.Show()
                    Me.Hide()
                Else

                    numberOfTries += 1 ' we're going to allow 3 tries

                    MsgBox("Invalid usename and password combination")

                    If numberOfTries >= 3 Then
                        ' After the user has tried three times
                        MsgBox("Maximum number of login attempts exceeded")

                    End If
                    txtUser.Text = ""
                    txtPass.Text = ""

                    sqlReader.Close()

                End If


            Catch ex As Exception
                MsgBox(ex.Message)
                sqlReader.Close()

            End Try

        Catch ex As Exception
            MsgBox("error connecting to the database: " + ex.Message)

        Finally
            connection.Dispose()
        End Try

        If ((authenticated = True) Or (numberOfTries >= 3)) Then
            Me.Close()
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the window when the user clicks the cancel button
        ' This subroutine is not expecting or passing any perameters

        Me.Close()
    End Sub

    Private Sub UsernameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUser.TextChanged

    End Sub
End Class

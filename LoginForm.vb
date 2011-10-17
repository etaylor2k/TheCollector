Imports MySql.Data.MySqlClient

Public Class LoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        ' This is the subroutine that handles the authentication of the applicaitons
        ' For our purposes this sunroutine is not expecting anything and passing the identity of the user to the next form if authenticated

        Dim connection As MySqlConnection
        Dim sqlReader As MySqlDataReader
        Dim sqlCommand As New MySqlCommand
        ' Dim connectionQuery As String = "select * from users where username = '" + txtUser + "' and password = '" + txtPass + "'"

        connection = New MySqlConnection
        connection.ConnectionString = "server =localhost; user id=appuser; password =password; database =thecollector"

        Try
            connection.Open()
            sqlCommand.Connection = connection
            sqlCommand.CommandText = "select * from users where username = '" + txtUser.Text + "' and password = '" + txtPass.Text + "'"

            Try
                sqlReader = sqlCommand.ExecuteReader()
                If sqlReader.HasRows Then
                    MainForm.Show()
                    Me.Hide()
                Else
                    MsgBox("Invalid usename and password combination")

                End If
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        Catch ex As Exception
            MsgBox("error connecting to the database")

        End Try

            Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        MainForm.Show()

        Me.Close()
    End Sub

    Private Sub UsernameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUser.TextChanged

    End Sub
End Class

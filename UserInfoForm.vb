Imports MySql.Data.MySqlClient

Public Class UserInfoForm
    ' This class is the UserInfoForm class which is representing the User Information form. With this form the user is able to update the information about their specific account

    Public connection As MySqlConnection

    Public uifUsersIdentity As identity ' The identity of the user


    Private Sub cmdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ' This subroutine will chagne the users information in the database if there is a change
        ' This subroutine is not expecting anything, but it will check the values of the text boxes on the form to see if anything has changed.

        Dim updatedEmail As Boolean = False
        Dim updatedUsername As Boolean = False
        Dim updatedFname As Boolean = False
        Dim updatedLname As Boolean = False
        Dim updatedPW As Boolean = False
        Dim updated As Boolean = False

        If (txtEmail.Text <> Me.uifUsersIdentity.email) And (Trim(txtEmail.Text) <> "") Then
            ' If the field has changed and it is not blank then upate the field
            updatedEmail = updateDatabase("email", txtEmail.Text, True)

            If updatedEmail = True Then
                ' if there was an update to the email, update the identitiy
                Me.uifUsersIdentity.email = txtEmail.Text

                ' Also need to update the email on the main form
                MainForm.userIdentity.email = txtEmail.Text

            End If

        End If

        If (txtUsername.Text <> Me.uifUsersIdentity.username) And (Trim(txtUsername.Text) <> "") Then
            ' If the field has changed and it is not blank then update the username email column
            updatedUsername = updateDatabase("username", txtUsername.Text, True)

            If updatedUsername = True Then
                ' if the username is updated then we need to update the users identity in the form
                Me.uifUsersIdentity.username = txtUsername.Text

                ' Also need to update the username on the Main Form
                MainForm.userIdentity.username = txtUsername.Text

                If updated <> True Then updated = True
            End If

        End If

        If (txtFname.Text <> Me.uifUsersIdentity.fname) And (Trim(txtFname.Text) <> "") Then
            ' If the field has changed and it is not blank then update the first name column
            updatedFname = updateDatabase("fname", txtFname.Text, False)

            If updatedFname = True Then
                ' if the first name is updated then we need to update the users identiy in the form
                Me.uifUsersIdentity.fname = txtFname.Text

                ' Also update the first name o the main form
                MainForm.userIdentity.fname = txtFname.Text

                If updated <> True Then updated = True
            End If
        End If

        If (txtLname.Text <> Me.uifUsersIdentity.lname) And (Trim(txtLname.Text) <> "") Then
            ' If the field has changed and it is not blank then update the last name column
            updatedLname = updateDatabase("lname", txtLname.Text, False)

            If updatedLname = True Then
                ' If the last name is updated then we need to update the users identitiy in the form
                Me.uifUsersIdentity.lname = txtLname.Text

                ' Also update the last name on the main form
                MainForm.userIdentity.level = txtLname.Text
                If updated <> True Then updated = True
            End If
        End If

        If (Trim(txtCurrentPassword.Text) <> "") Then
            ' If the current password field is not blank

            If ((txtCurrentPassword.Text <> txtNewPassword.Text) And (txtCurrentPassword.Text = Me.uifUsersIdentity.password) And (txtNewPassword.Text = txtConfirmPassword.Text)) Then
                ' If the user has entered a new password, the current password is correct, and they've enetered the new password in twice sucessfully then update the password

                updatedPW = updateDatabase("password", txtNewPassword.Text, False)

                If updatedPW = True Then
                    ' if the password is updated we need to update the user's identity on this form
                    Me.uifUsersIdentity.password = txtNewPassword.Text

                    ' Also update the password on the main form
                    MainForm.userIdentity.password = txtNewPassword.Text
                    If updated <> True Then updated = True
                End If
            Else
                MsgBox("Password not able to be changed")
            End If
        End If

        If updated Then MsgBox("User account Updated")
        Me.Close() ' Close the form
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the window when the user clicks the cancel button
        ' This subroutine is not expecting or passing any perameters

        Me.Close()
    End Sub

    Private Function updateDatabase(ByVal column As String, ByVal value As String, ByVal unique As Boolean) As Boolean
        ' This subroutine will update the users information to reflect the relevent changes on the User Inforamtion form
        ' This suboruine is expecting the column name and value and will not return anything

        Dim sqlCommand As New MySqlCommand
        Dim sqlReader As MySqlDataReader
        Dim isUnique As Boolean = False
        Dim updated As Boolean = False


        If Me.connection.State = ConnectionState.Closed Then
            ' If the connection state is closed then it needs to be open to perform these queries

            Me.connection.Open()

        End If

        If unique = True Then
            ' query the database to make sure that the value is unique
            sqlCommand.Connection = Me.connection
            sqlCommand.CommandText = "select * from users where " + column + " ='" + value + "'"

            sqlReader = sqlCommand.ExecuteReader

            If sqlReader.HasRows = False Then
                ' If there are not any rows returned then this is a unique value
                isUnique = True
            End If

            sqlReader.Close()

        End If


        'if this is a truely unique value or if we do not care if this field is unique
        If ((isUnique = True) And (unique = True)) Or (unique = False) Then
            'insert the value

            If Me.connection.State = ConnectionState.Closed Then
                Me.connection.Open()
            End If

            sqlCommand.Connection = Me.connection
            'sqlCommand.CommandText = ""
            sqlCommand.CommandText = "update users set " + column + "='" + value.ToString + "' where idusers ='" + Me.uifUsersIdentity.id.ToString + "'"

            Try
                sqlCommand.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("Error updating: " + column.ToString)
            End Try
            updated = True
        End If


        Return updated
    End Function

End Class
﻿Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class MainForm

    ' Custom structure to represent the columns in the table
    'Structure identity
    '    Dim id As Integer
    '    Dim username As String
    '    Dim password As String
    '    Dim level As Integer
    '    Dim fname As String
    '    Dim lname As String
    '    Dim email As String

    'End Structure

    Public userIdentity As identity
    Public connection As MySqlConnection

    ' For dynamic Menus
    Private WithEvents MenuStudentsStripMenuitem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuClassStripMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuCreateStudentMenuItem As New System.Windows.Forms.ToolStripMenuItem()


    Private Sub mnuFile_UserInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFile_UserInformation.Click
        ' This subroutine will send the users identity to the USer Inforamtion form so that the user can modify the information
        ' This subroutine is not expecting or returning anything

        ' Declare a new user informations form
        Dim usersInfoForm As New UserInfoForm
        usersInfoForm.MdiParent = Me ' declare the parent

        ' pass the information
        usersInfoForm.uifUsersIdentity.id = Me.userIdentity.id
        usersInfoForm.uifUsersIdentity.username = Me.userIdentity.username
        usersInfoForm.uifUsersIdentity.email = Me.userIdentity.email
        usersInfoForm.uifUsersIdentity.fname = Me.userIdentity.fname
        usersInfoForm.uifUsersIdentity.lname = Me.userIdentity.lname
        usersInfoForm.uifUsersIdentity.password = Me.userIdentity.password
        usersInfoForm.uifUsersIdentity.level = Me.userIdentity.level

        'populate the text fields
        usersInfoForm.txtEmail.Text = Me.userIdentity.email
        usersInfoForm.txtFname.Text = Me.userIdentity.fname
        usersInfoForm.txtLname.Text = Me.userIdentity.lname
        usersInfoForm.txtUsername.Text = Me.userIdentity.username

        'send the connection string
        usersInfoForm.connection = Me.connection

        usersInfoForm.Show()


    End Sub

    Private Sub mnuFile_Quit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_Quit.Click
        ' This subroutine will let the user exit the application
        ' This subroutine is not expecting anything or passing anything to any other entity

        Me.Close()

    End Sub

    Private Sub addClass()
        ' This subroutine will create the a class based off 
    End Sub

    Private Sub createStudent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuCreateStudentMenuItem.Click

        Dim dummy As Integer
    End Sub

    Private Sub createTeacher()

    End Sub

    Private Sub createAdminMenu()

    End Sub

    Private Sub createTeacherMenu()
        ' This subroutine will create the appropriate menus for a teacher's account
        ' This subroutine is not expecting anything or returning anything; but, will will create the menus for the teacher's account



        MenuStudentsStripMenuitem.Name = "MenuUserStripMenuitem"
        MenuStudentsStripMenuitem.Size = New System.Drawing.Size(37, 20)
        MenuStudentsStripMenuitem.Text = "Students"
        Me.MenuStrip1.Items.AddRange({MenuStudentsStripMenuitem})

        MenuClassStripMenuItem.Name = "MenuClassStripMenuItem"
        MenuClassStripMenuItem.Size = New System.Drawing.Size(37, 20)
        MenuClassStripMenuItem.Text = "Classes"
        Me.MenuStrip1.Items.AddRange({MenuClassStripMenuItem})

        MenuCreateStudentMenuItem.Name = "MenuCreateStudentMenuItem"
        MenuCreateStudentMenuItem.Size = New System.Drawing.Size(163, 22)
        MenuCreateStudentMenuItem.Text = "Create Student"
        MenuStudentsStripMenuitem.DropDownItems.AddRange({MenuCreateStudentMenuItem})


    End Sub

    Private Sub createStudentMenu()

    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim level_name As String = ""
        Dim sqlCommand As New MySqlCommand
        Dim sqlReader As MySqlDataReader

        If Me.connection.State = ConnectionState.Closed Then
            ' if the connection is closed for some reason we need to reopen it
            Me.connection.Open()

        End If

        ' query the database to make sure that the value is unique
        sqlCommand.Connection = Me.connection
        sqlCommand.CommandText = "select * from user_levels  where iduser_levels ='" + Me.userIdentity.level.ToString + "'"

        sqlReader = sqlCommand.ExecuteReader

        If sqlReader.HasRows = True Then
            Do While sqlReader.Read
                level_name = sqlReader.GetString(1) ' this will get the second column,  the user level name column
            Loop
        End If

        Select Case level_name
            Case "admin"
                Call createAdminMenu()

            Case "teacher"
                Call createTeacherMenu()

            Case "student"
                Call createStudentMenu()

        End Select


        'Dim MenuUserStripMenuitem = New System.Windows.Forms.ToolStripMenuItem()
        'Dim MenuClassStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        'Dim MenuHelpStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()

        '' for the 
        'MenuUserStripMenuitem.Name = "MenuUserStripMenuitem"
        'MenuUserStripMenuitem.Size = New System.Drawing.Size(37, 20)
        'MenuUserStripMenuitem.Text = "User"

        'MenuClassStripMenuItem.Name = "MenuClassStripMenuItem"
        'MenuClassStripMenuItem.Size = New System.Drawing.Size(37, 20)
        'MenuClassStripMenuItem.Text = "Classes"




        '' Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {MenuUserStripMenuitem})
        'Me.MenuStrip1.Items.AddRange({MenuUserStripMenuitem})


    End Sub
End Class

﻿' MainForm
' This class represents the main form of the application
' Endris Taylor for The Collective

Imports MySql.Data.MySqlClient ' MySql Fucntionality
Imports System.Windows.Forms ' windows forms

Public Class MainForm

    ' Class Variables
    Public userIdentity As identity
    Public connection As MySqlConnection

    ' For dynamic Menus
    Private WithEvents MenuStudentsStripMenuitem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuClassStripMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuCreateStudentMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuCreateClassMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuAddStudentToClassItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuQuestionStripMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuCreateQuesitonMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuTestStripMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuCreateTestMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuAssignQuestionMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuTakeTestMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuCheckGradesMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents MenuCheckRosterMenuItem As New System.Windows.Forms.ToolStripMenuItem()

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

        usersInfoForm.Show() ' Show he orm


    End Sub

    Private Sub mnuFile_AboutTheCollector_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_AboutTheCollector.Click
        ' This subroutine will let the user view the about us window
        ' This subroutine is not expecting ir returning anything

        Dim aboutTheCollectorForm As New AboutTheCollector

        aboutTheCollectorForm.MdiParent = Me
        aboutTheCollectorForm.Show() ' shw the form

    End Sub

    Private Sub mnuFile_Quit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_Quit.Click
        ' This subroutine will let the user exit the application
        ' This subroutine is not expecting anything or passing anything to any other entity

        Me.Close()

    End Sub

    Private Sub addClass(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuCreateClassMenuItem.Click
        ' This subroutine will create a class
        ' This subroutine is not expecting anything or will not return anything

        ' Declare a new create class form
        Dim createNewClassForm As New CreateClassForm
        createNewClassForm.MdiParent = Me

        createNewClassForm.connection = Me.connection
        createNewClassForm.ccfIdentity = Me.userIdentity
        createNewClassForm.Show() ' show the form

    End Sub

    Private Sub createStudent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuCreateStudentMenuItem.Click
        ' This subroutine will create a student 
        ' This subroutine does not expect anything and will not return anything. 

        ' Declare a new create student form
        Dim createStudentForm As New CreateStudent
        createStudentForm.MdiParent = Me

        createStudentForm.connection = Me.connection ' pass the connection information to the create student form

        createStudentForm.Show() ' Show the form

    End Sub

    Private Sub showClassRoster(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuCheckRosterMenuItem.Click
        ' This subroutine will show a teacher's class roster
        ' This subroutine is not expecting or returning anything

        Dim classRoster As New CheckRoster
        classRoster.MdiParent = Me

        classRoster.userIdentity = Me.userIdentity
        classRoster.connection = Me.connection

        classRoster.Show() ' Show the form

    End Sub

    Private Sub assigStudentToClass(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuAddStudentToClassItem.Click
        ' This subroutine will add a student to a specific class
        ' This subroutine does not expect anything and will not return anything.

        Dim addStudentToCalssForm As New AssignStudent
        addStudentToCalssForm.MdiParent = Me

        addStudentToCalssForm.userIdentity = Me.userIdentity
        addStudentToCalssForm.connection = Me.connection

        addStudentToCalssForm.Show() ' Show the form


    End Sub

    Private Sub takeTest(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuTakeTestMenuItem.Click
        ' This subroutine will allow the student to take the test
        ' This subroutine is not expecting or returning anything

        ' declare the form
        Dim takeTestForm As New TakeTest

        takeTestForm.MdiParent = Me
        takeTestForm.connection = Me.connection
        takeTestForm.userIdentity = Me.userIdentity
        takeTestForm.Show() ' Show the form

    End Sub

    Private Sub createQuestion(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuCreateQuesitonMenuItem.Click
        ' This subroutine will display the form to create a quesiton for the question bank
        ' This subroutine is not expecting or returning anything

        Dim createQuestion As New CreateQuestionForm

        createQuestion.userIdentity = Me.userIdentity
        createQuestion.connection = Me.connection

        createQuestion.MdiParent = Me

        createQuestion.Show() ' Show the form

    End Sub

    Private Sub addQuestionToTest(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuAssignQuestionMenuItem.Click
        ' This subroutine will assign a question to the appropriate test
        ' This subroutine does not expect or return anything

        Dim addQuestionToTest As New AssignQuestion

        addQuestionToTest.connection = Me.connection
        addQuestionToTest.userIdentity = Me.userIdentity

        addQuestionToTest.MdiParent = Me

        addQuestionToTest.Show()

    End Sub

    Private Sub createTest(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuCreateTestMenuItem.Click
        ' This subroutine will display the form to create a test
        ' This subroutine is not epecting or returning anything

        Dim createTest As New CreateTest

        createTest.userIdentity = Me.userIdentity
        createTest.connection = Me.connection

        createTest.MdiParent = Me

        createTest.Show() ' Show the form



    End Sub

    Private Sub checkGrades(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuCheckGradesMenuItem.Click
        ' This subroutine will display the form to check grades
        ' This subroutine is not expecting or returning anything

        Dim checkGrades As New CheckGrades

        checkGrades.userIdentitiy = Me.userIdentity
        checkGrades.connection = Me.connection

        checkGrades.MdiParent = Me

        checkGrades.Show() ' Show the form

    End Sub

    Private Sub createTeacherMenu()
        ' This subroutine will create the appropriate menus for a teacher's account
        ' This subroutine is not expecting anything or returning anything; but, will will create the menus for the teacher's account

        ' Creates the student Drop Down Menu
        MenuStudentsStripMenuitem.Name = "MenuUserStripMenuitem"
        MenuStudentsStripMenuitem.Size = New System.Drawing.Size(37, 20)
        MenuStudentsStripMenuitem.Text = "Students"
        Me.MenuStrip1.Items.AddRange({MenuStudentsStripMenuitem})

        ' Creates the Classes Drop Down Menu
        MenuClassStripMenuItem.Name = "MenuClassStripMenuItem"
        MenuClassStripMenuItem.Size = New System.Drawing.Size(37, 20)
        MenuClassStripMenuItem.Text = "Classes"
        Me.MenuStrip1.Items.AddRange({MenuClassStripMenuItem})

        ' Creates the Questions Drop Down Menu
        MenuQuestionStripMenuItem.Name = "MenuQuestionStripMenuItem"
        MenuQuestionStripMenuItem.Size = New System.Drawing.Size(37, 20)
        MenuQuestionStripMenuItem.Text = "Questions"
        Me.MenuStrip1.Items.AddRange({MenuQuestionStripMenuItem})

        ' Creates the Test Drop Down Menu
        MenuTestStripMenuItem.Name = "MenuTestStripMenuItem"
        MenuTestStripMenuItem.Size = New System.Drawing.Size(37, 20)
        MenuTestStripMenuItem.Text = "Tests"
        Me.MenuStrip1.Items.AddRange({MenuTestStripMenuItem})

        ' Creates the Create Student Menu item under the Students Drop Down Menu
        MenuCreateStudentMenuItem.Name = "MenuCreateStudentMenuItem"
        MenuCreateStudentMenuItem.Size = New System.Drawing.Size(163, 22)
        MenuCreateStudentMenuItem.Text = "Create Student"
        MenuStudentsStripMenuitem.DropDownItems.AddRange({MenuCreateStudentMenuItem})

        ' Creates the Assign Student to class Dropdown under the Students Drop Down Menu
        MenuAddStudentToClassItem.Name = "MenuAddStudentToClassItem"
        MenuAddStudentToClassItem.Size = New System.Drawing.Size(163, 22)
        MenuAddStudentToClassItem.Text = "Assign Student To Class"
        MenuStudentsStripMenuitem.DropDownItems.AddRange({MenuAddStudentToClassItem})

        ' Creates the Create Class Menu item under the Classes Drop Down Menu
        MenuCreateClassMenuItem.Name = "MenuCreateClassMenuItem"
        MenuCreateClassMenuItem.Size = New System.Drawing.Size(163, 22)
        MenuCreateClassMenuItem.Text = "Create Class"
        MenuClassStripMenuItem.DropDownItems.AddRange({MenuCreateClassMenuItem})

        ' Creates the Create Question Menu item under the Questions Drop Down Menu
        MenuCreateQuesitonMenuItem.Name = "MenuCreateQuesitonMenuItem"
        MenuCreateQuesitonMenuItem.Size = New System.Drawing.Size(163, 22)
        MenuCreateQuesitonMenuItem.Text = "Create Question"
        MenuQuestionStripMenuItem.DropDownItems.AddRange({MenuCreateQuesitonMenuItem})

        ' Creates the Create Test Menu item under the Tests Drop Down Menu
        MenuCreateTestMenuItem.Name = "MenuCreateTestMenuItem"
        MenuCreateTestMenuItem.Size = New System.Drawing.Size(163, 22)
        MenuCreateTestMenuItem.Text = "Create Test"
        MenuTestStripMenuItem.DropDownItems.AddRange({MenuCreateTestMenuItem})

        ' Creates the Assign Test Menu item under the Tests Drop Down Menu
        MenuAssignQuestionMenuItem.Name = "MenuAssignQuestionMenuItem"
        MenuAssignQuestionMenuItem.Size = New System.Drawing.Size(163, 22)
        MenuAssignQuestionMenuItem.Text = "Assign Question to Test"
        MenuTestStripMenuItem.DropDownItems.AddRange({MenuAssignQuestionMenuItem})

        ' Creates the Check Roster to class Dropdown under the Students Drop Down Menu
        MenuCheckRosterMenuItem.Name = "MenuCheckRosterMenuItem"
        MenuCheckRosterMenuItem.Size = New System.Drawing.Size(163, 22)
        MenuCheckRosterMenuItem.Text = "Show Roster"
        MenuClassStripMenuItem.DropDownItems.AddRange({MenuCheckRosterMenuItem})

    End Sub

    Private Sub createStudentMenu()
        ' This subroutine will create the appropriate menus for a student's account
        ' This subroutine is not expecting anything or returning anything; but, will will create the menus for the student's account

        ' Creates the test Drop Down Menu
        MenuTestStripMenuItem.Name = "MenuTestStripMenuItem"
        MenuTestStripMenuItem.Size = New System.Drawing.Size(37, 20)
        MenuTestStripMenuItem.Text = "Test"
        Me.MenuStrip1.Items.AddRange({MenuTestStripMenuItem})

        ' Creates the Take Test Menu item under the Tests Drop Down Menu
        MenuTakeTestMenuItem.Name = "MenuTakeTestMenuItem"
        MenuTakeTestMenuItem.Size = New System.Drawing.Size(163, 22)
        MenuTakeTestMenuItem.Text = "Take Test"
        MenuTestStripMenuItem.DropDownItems.AddRange({MenuTakeTestMenuItem})

        ' Creates the Check Grades Drop Down Menu
        MenuCheckGradesMenuItem.Name = "MenuCheckGradesMenuItem"
        MenuCheckGradesMenuItem.Size = New System.Drawing.Size(163, 22)
        MenuCheckGradesMenuItem.Text = "Check Grades"
        MenuTestStripMenuItem.DropDownItems.AddRange({MenuCheckGradesMenuItem})


    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' This subroutine will load the proper menus for the main form
        ' This subroutine is not expecting or returning anything

        ' declarations
        Dim level_name As String = ""
        Dim sqlCommand As New MySqlCommand
        Dim sqlReader As MySqlDataReader
        Dim welcomeScreen As New WelcomeScreen

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

        ' This will create the proper menus
        Select Case level_name
            'Case "admin"
            '    Call createAdminMenu()

            Case "teacher"
                Call createTeacherMenu()

            Case "student"
                Call createStudentMenu()

        End Select

        ' To initially show the login page
        welcomeScreen.MdiParent = Me
        welcomeScreen.Show()

    End Sub

End Class

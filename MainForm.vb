Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class MainForm

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

    Private Sub mnuFile_AboutTheCollector_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_AboutTheCollector.Click
        ' This subroutine will let the user view the about us window
        ' This subroutine is not expecting ir returning anything

        Dim aboutTheCollectorForm As New AboutTheCollector

        aboutTheCollectorForm.MdiParent = Me
        aboutTheCollectorForm.Show()

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
        createNewClassForm.Show()

    End Sub

    Private Sub createStudent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuCreateStudentMenuItem.Click
        ' This subroutine will create a student 
        ' This subroutine does not expect anything and will not return anything. 

        ' Declare a new create student form
        Dim createStudentForm As New CreateStudent
        createStudentForm.MdiParent = Me

        createStudentForm.connection = Me.connection ' pass the connection information to the create student form

        createStudentForm.Show()

    End Sub

    Private Sub assigStudentToClass(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuAddStudentToClassItem.Click
        ' This subroutine will add a student to a specific class
        ' This subroutine does not expect anything and will not return anything.

        Dim addStudentToCalssForm As New AssignStudent
        addStudentToCalssForm.MdiParent = Me

        addStudentToCalssForm.connection = Me.connection

        addStudentToCalssForm.Show()


    End Sub

    Private Sub createQuestion(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuCreateQuesitonMenuItem.Click
        ' This subroutine will display the form to create a quesiton for the question bank

        Dim createQuestion As New CreateQuestionForm

        createQuestion.userIdentity = Me.userIdentity
        createQuestion.connection = Me.connection

        createQuestion.MdiParent = Me

        createQuestion.Show()



    End Sub
    Private Sub createTeacher()

    End Sub

    Private Sub createAdminMenu()

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




    End Sub

    Private Sub createStudentMenu()

    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim level_name As String = ""
        Dim sqlCommand As New MySqlCommand
        Dim sqlReader As MySqlDataReader
        Dim aboutTheCollectorForm As New AboutTheCollector

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

        aboutTheCollectorForm.MdiParent = Me
        aboutTheCollectorForm.Show()

    End Sub
End Class

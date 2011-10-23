Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class MainForm

    ' Custom structure to represent the columns in the table
    Structure identity
        Dim id As Integer
        Dim username As String
        Dim password As String
        Dim level As Integer
        Dim fname As String
        Dim lname As String
        Dim email As String

    End Structure

    Public userIdentity As identity
    Public connection As MySqlConnection


    Private Sub mnuFile_UserInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFile_UserInformation.Click
        ' This subroutine will send the users identity to the USer Inforamtion form so that the user can modify the information
        ' This subroutine is not expecting or returning anything

        ' Declare a new user informations form
        Dim usersInfoForm As New UserInfoForm
        usersInfoForm.MdiParent = Me ' declare the parent

        ' pass the information
        usersInfoForm.uifUsersIdentity.id = Me.userIdentity.id
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

    Private Sub createStudent()

    End Sub

    Private Sub createTeacher()

    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MenuUserStripMenuitem = New System.Windows.Forms.ToolStripMenuItem()
        Dim MenuClassStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Dim MenuHelpStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()

        ' for the 
        MenuUserStripMenuitem.Name = "MenuUserStripMenuitem"
        MenuUserStripMenuitem.Size = New System.Drawing.Size(37, 20)
        MenuUserStripMenuitem.Text = "User"

        MenuClassStripMenuItem.Name = "MenuClassStripMenuItem"
        MenuClassStripMenuItem.Size = New System.Drawing.Size(37, 20)
        MenuClassStripMenuItem.Text = "Classes"




        ' Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {MenuUserStripMenuitem})
        Me.MenuStrip1.Items.AddRange({MenuUserStripMenuitem})
    End Sub
End Class

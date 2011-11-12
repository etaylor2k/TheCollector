Imports MySql.Data.MySqlClient

Public Class CreateTrueOrFalseForm
    Public connection As MySqlConnection
    Public userIdentity As Identity

    Private Sub CreateTrueOrFalseForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This sbroutine will 
    End Sub


    Private Sub checkTorF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkTorF.CheckedChanged
        ' This subroutine will change the answer of the True or False question
        ' This subroutine is not expecting anything and will not return anything

        If Me.checkTorF.Checked = True Then
            ' If the checkbox was checked then change the text to 'True'
            Me.checkTorF.Text = "True"

        Else
            ' If the checkbox was unchecked then change the text to 'False'
            Me.checkTorF.Text = "False"

        End If

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the 
    End Sub
End Class
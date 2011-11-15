Imports MySql.Data.MySqlClient

Public Class CreateMultipleChoiceForm
    Public userIdentity As Identity
    Public connection As MySqlConnection

    Private Sub CreateMultipleChoiceForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub checkA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkA.CheckedChanged
        ' This subroutine will control the checkbox for the A answer. If it is checked, it will ensure that there is not another 
        ' checkbox checked
        ' This subroutine is not expecting or returning anything

        If checkA.Checked = True Then
            ' if it is checked, uncheck the other checkbox that could be checked

            If checkB.Checked = True Then checkB.CheckState = CheckState.Unchecked
            If checkC.Checked = True Then checkC.CheckState = CheckState.Unchecked
            If checkD.Checked = True Then checkD.CheckState = CheckState.Unchecked

        End If

    End Sub

    Private Sub checkB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkB.CheckedChanged
        ' This subroutine will control the checkbox for the B answer. If it is checked, it will ensure that there is not another 
        ' checkbox checked
        ' This subroutine is not expecting or returning anything

        If checkB.Checked = True Then
            ' if it is checked, uncheck the other checkbox that could be checked

            If checkA.Checked = True Then checkA.CheckState = CheckState.Unchecked
            If checkC.Checked = True Then checkC.CheckState = CheckState.Unchecked
            If checkD.Checked = True Then checkD.CheckState = CheckState.Unchecked

        End If

    End Sub

    Private Sub checkC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkC.CheckedChanged
        ' This subroutine will control the checkbox for the C answer. If it is checked, it will ensure that there is not another 
        ' checkbox checked
        ' This subroutine is not expecting or returning anything

        If checkC.Checked = True Then
            ' if it is checked, uncheck the other checkbox that could be checked

            If checkA.Checked = True Then checkA.CheckState = CheckState.Unchecked
            If checkB.Checked = True Then checkB.CheckState = CheckState.Unchecked
            If checkD.Checked = True Then checkD.CheckState = CheckState.Unchecked

        End If

    End Sub

    Private Sub checkD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkD.CheckedChanged
        ' This subroutine will control the checkbox for the D answer. If it is checked, it will ensure that there is not another 
        ' checkbox checked
        ' This subroutine is not expecting or returning anything

        If checkD.Checked = True Then
            ' if it is checked, uncheck the other checkbox that could be checked

            If checkA.Checked = True Then checkA.CheckState = CheckState.Unchecked
            If checkB.Checked = True Then checkB.CheckState = CheckState.Unchecked
            If checkC.Checked = True Then checkC.CheckState = CheckState.Unchecked

        End If

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' This subroutine will close the form
        ' This subroutine is not expecting or returning anything

        Dim createQuestion As New CreateQuestionForm

        createQuestion.connection = Me.connection
        createQuestion.MdiParent = Me.MdiParent

        Me.Hide()
        createQuestion.Show()
        Me.Close()

    End Sub
End Class
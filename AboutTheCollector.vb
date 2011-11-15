Public NotInheritable Class AboutTheCollector

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName

        ' Override the default place where the content comes from 
        'Me.TextBoxDescription.Text = My.Application.Info.Description
        Me.TextBoxDescription.Text = "Welcome to the Collector. The world's premier test taking/creating program."
        Me.TextBoxDescription.Text = Me.TextBoxDescription.Text & vbNewLine + vbNewLine + "Please log into the Collector by entering your user name and password. The system will automatically define the role that  you belong to. It will allow the student to take a test and the teacher/facilitator to create one."
        Me.TextBoxDescription.Text = Me.TextBoxDescription.Text & vbNewLine + vbNewLine + "To start taking a test, plese click on the 'Test' menu above. To update your information, or the information of a student, please click on the 'Student' menu item above. The classes and questions are for the teacher to be able to create classes, questions, and tests."

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub LabelProductName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelProductName.Click

    End Sub

    Private Sub TextBoxDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxDescription.TextChanged

    End Sub
End Class

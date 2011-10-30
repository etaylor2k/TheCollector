<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateClassForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblCourse = New System.Windows.Forms.Label()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.comboCourse = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblCourse
        '
        Me.lblCourse.AutoSize = True
        Me.lblCourse.Location = New System.Drawing.Point(9, 18)
        Me.lblCourse.Name = "lblCourse"
        Me.lblCourse.Size = New System.Drawing.Size(40, 13)
        Me.lblCourse.TabIndex = 1
        Me.lblCourse.Text = "Course"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(57, 227)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(148, 227)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'comboCourse
        '
        Me.comboCourse.FormattingEnabled = True
        Me.comboCourse.Location = New System.Drawing.Point(12, 34)
        Me.comboCourse.Name = "comboCourse"
        Me.comboCourse.Size = New System.Drawing.Size(249, 21)
        Me.comboCourse.TabIndex = 4
        '
        'CreateClassForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.comboCourse)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lblCourse)
        Me.Name = "CreateClassForm"
        Me.Text = "Create Class"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCourse As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents comboCourse As System.Windows.Forms.ComboBox
End Class

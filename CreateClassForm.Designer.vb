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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateClassForm))
        Me.lblCourse = New System.Windows.Forms.Label()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.comboCourse = New System.Windows.Forms.ComboBox()
        Me.lblGradeLevel = New System.Windows.Forms.Label()
        Me.comboGradeLevel = New System.Windows.Forms.ComboBox()
        Me.lblSemester = New System.Windows.Forms.Label()
        Me.comboSemester = New System.Windows.Forms.ComboBox()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.numYear = New System.Windows.Forms.NumericUpDown()
        Me.comboSection = New System.Windows.Forms.ComboBox()
        CType(Me.numYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCourse
        '
        Me.lblCourse.AutoSize = True
        Me.lblCourse.BackColor = System.Drawing.Color.Transparent
        Me.lblCourse.Location = New System.Drawing.Point(9, 18)
        Me.lblCourse.Name = "lblCourse"
        Me.lblCourse.Size = New System.Drawing.Size(40, 13)
        Me.lblCourse.TabIndex = 1
        Me.lblCourse.Text = "Course"
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdOk.Location = New System.Drawing.Point(57, 227)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdCancel.Location = New System.Drawing.Point(148, 227)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'comboCourse
        '
        Me.comboCourse.FormattingEnabled = True
        Me.comboCourse.Location = New System.Drawing.Point(12, 34)
        Me.comboCourse.Name = "comboCourse"
        Me.comboCourse.Size = New System.Drawing.Size(249, 21)
        Me.comboCourse.TabIndex = 4
        '
        'lblGradeLevel
        '
        Me.lblGradeLevel.AutoSize = True
        Me.lblGradeLevel.BackColor = System.Drawing.Color.Transparent
        Me.lblGradeLevel.Location = New System.Drawing.Point(9, 67)
        Me.lblGradeLevel.Name = "lblGradeLevel"
        Me.lblGradeLevel.Size = New System.Drawing.Size(65, 13)
        Me.lblGradeLevel.TabIndex = 5
        Me.lblGradeLevel.Text = "Grade Level"
        '
        'comboGradeLevel
        '
        Me.comboGradeLevel.FormattingEnabled = True
        Me.comboGradeLevel.Location = New System.Drawing.Point(80, 67)
        Me.comboGradeLevel.Name = "comboGradeLevel"
        Me.comboGradeLevel.Size = New System.Drawing.Size(181, 21)
        Me.comboGradeLevel.TabIndex = 6
        '
        'lblSemester
        '
        Me.lblSemester.AutoSize = True
        Me.lblSemester.BackColor = System.Drawing.Color.Transparent
        Me.lblSemester.Location = New System.Drawing.Point(9, 109)
        Me.lblSemester.Name = "lblSemester"
        Me.lblSemester.Size = New System.Drawing.Size(51, 13)
        Me.lblSemester.TabIndex = 7
        Me.lblSemester.Text = "Semester"
        '
        'comboSemester
        '
        Me.comboSemester.FormattingEnabled = True
        Me.comboSemester.Location = New System.Drawing.Point(80, 106)
        Me.comboSemester.Name = "comboSemester"
        Me.comboSemester.Size = New System.Drawing.Size(181, 21)
        Me.comboSemester.TabIndex = 8
        '
        'lblSection
        '
        Me.lblSection.AutoSize = True
        Me.lblSection.BackColor = System.Drawing.Color.Transparent
        Me.lblSection.Location = New System.Drawing.Point(54, 145)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(43, 13)
        Me.lblSection.TabIndex = 9
        Me.lblSection.Text = "Section"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.BackColor = System.Drawing.Color.Transparent
        Me.lblYear.Location = New System.Drawing.Point(145, 145)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 10
        Me.lblYear.Text = "Year"
        '
        'numYear
        '
        Me.numYear.Location = New System.Drawing.Point(148, 173)
        Me.numYear.Name = "numYear"
        Me.numYear.Size = New System.Drawing.Size(113, 20)
        Me.numYear.TabIndex = 13
        '
        'comboSection
        '
        Me.comboSection.FormattingEnabled = True
        Me.comboSection.Location = New System.Drawing.Point(53, 172)
        Me.comboSection.Name = "comboSection"
        Me.comboSection.Size = New System.Drawing.Size(34, 21)
        Me.comboSection.TabIndex = 14
        '
        'CreateClassForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.comboSection)
        Me.Controls.Add(Me.numYear)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.lblSection)
        Me.Controls.Add(Me.comboSemester)
        Me.Controls.Add(Me.lblSemester)
        Me.Controls.Add(Me.comboGradeLevel)
        Me.Controls.Add(Me.lblGradeLevel)
        Me.Controls.Add(Me.comboCourse)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lblCourse)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CreateClassForm"
        Me.Text = "Create Class"
        CType(Me.numYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCourse As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents comboCourse As System.Windows.Forms.ComboBox
    Friend WithEvents lblGradeLevel As System.Windows.Forms.Label
    Friend WithEvents comboGradeLevel As System.Windows.Forms.ComboBox
    Friend WithEvents lblSemester As System.Windows.Forms.Label
    Friend WithEvents comboSemester As System.Windows.Forms.ComboBox
    Friend WithEvents lblSection As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents numYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents comboSection As System.Windows.Forms.ComboBox
End Class

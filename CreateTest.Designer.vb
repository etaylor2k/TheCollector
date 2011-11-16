<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateTest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateTest))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lblClass = New System.Windows.Forms.Label()
        Me.comboClasses = New System.Windows.Forms.ComboBox()
        Me.txtClassName = New System.Windows.Forms.TextBox()
        Me.lblTestName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(202, 170)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(330, 170)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblClass
        '
        Me.lblClass.AutoSize = True
        Me.lblClass.Location = New System.Drawing.Point(59, 26)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(43, 13)
        Me.lblClass.TabIndex = 2
        Me.lblClass.Text = "Classes"
        '
        'comboClasses
        '
        Me.comboClasses.FormattingEnabled = True
        Me.comboClasses.Location = New System.Drawing.Point(130, 23)
        Me.comboClasses.Name = "comboClasses"
        Me.comboClasses.Size = New System.Drawing.Size(275, 21)
        Me.comboClasses.TabIndex = 3
        '
        'txtClassName
        '
        Me.txtClassName.Location = New System.Drawing.Point(130, 74)
        Me.txtClassName.Name = "txtClassName"
        Me.txtClassName.Size = New System.Drawing.Size(275, 20)
        Me.txtClassName.TabIndex = 4
        '
        'lblTestName
        '
        Me.lblTestName.AutoSize = True
        Me.lblTestName.Location = New System.Drawing.Point(59, 81)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(59, 13)
        Me.lblTestName.TabIndex = 5
        Me.lblTestName.Text = "Test Name"
        '
        'CreateTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.The_Collector.My.Resources.Resources.bg
        Me.ClientSize = New System.Drawing.Size(566, 213)
        Me.Controls.Add(Me.lblTestName)
        Me.Controls.Add(Me.txtClassName)
        Me.Controls.Add(Me.comboClasses)
        Me.Controls.Add(Me.lblClass)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CreateTest"
        Me.Text = "Create Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblClass As System.Windows.Forms.Label
    Friend WithEvents comboClasses As System.Windows.Forms.ComboBox
    Friend WithEvents txtClassName As System.Windows.Forms.TextBox
    Friend WithEvents lblTestName As System.Windows.Forms.Label
End Class

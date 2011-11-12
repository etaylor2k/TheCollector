<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateTrueOrFalseForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateTrueOrFalseForm))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.checkTorF = New System.Windows.Forms.CheckBox()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(160, 103)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(306, 103)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(428, 20)
        Me.TextBox1.TabIndex = 2
        '
        'checkTorF
        '
        Me.checkTorF.AutoSize = True
        Me.checkTorF.Location = New System.Drawing.Point(476, 42)
        Me.checkTorF.Name = "checkTorF"
        Me.checkTorF.Size = New System.Drawing.Size(51, 17)
        Me.checkTorF.TabIndex = 3
        Me.checkTorF.Text = "False"
        Me.checkTorF.UseVisualStyleBackColor = True
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.Location = New System.Drawing.Point(12, 9)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(297, 13)
        Me.lblInstructions.TabIndex = 4
        Me.lblInstructions.Text = "Please type the question and indicate the true of false answer"
        '
        'CreateTrueOrFalseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.The_Collector.My.Resources.Resources.bg
        Me.ClientSize = New System.Drawing.Size(565, 136)
        Me.Controls.Add(Me.lblInstructions)
        Me.Controls.Add(Me.checkTorF)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CreateTrueOrFalseForm"
        Me.Text = "Create True or False Question"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents checkTorF As System.Windows.Forms.CheckBox
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
End Class

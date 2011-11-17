<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultipleChoiceForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultipleChoiceForm))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtQuestion = New System.Windows.Forms.TextBox()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.checkA = New System.Windows.Forms.CheckBox()
        Me.checkB = New System.Windows.Forms.CheckBox()
        Me.checkC = New System.Windows.Forms.CheckBox()
        Me.checkD = New System.Windows.Forms.CheckBox()
        Me.txtAnswerA = New System.Windows.Forms.TextBox()
        Me.txtAnswerB = New System.Windows.Forms.TextBox()
        Me.txtAnswerC = New System.Windows.Forms.TextBox()
        Me.txtAnswerD = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(154, 351)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(273, 351)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtQuestion
        '
        Me.txtQuestion.Location = New System.Drawing.Point(12, 96)
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.Size = New System.Drawing.Size(477, 20)
        Me.txtQuestion.TabIndex = 2
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.Location = New System.Drawing.Point(93, 18)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(0, 13)
        Me.lblInstructions.TabIndex = 3
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Location = New System.Drawing.Point(12, 65)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(49, 13)
        Me.lblQuestion.TabIndex = 4
        Me.lblQuestion.Text = "Question"
        '
        'checkA
        '
        Me.checkA.AutoSize = True
        Me.checkA.Location = New System.Drawing.Point(196, 139)
        Me.checkA.Name = "checkA"
        Me.checkA.Size = New System.Drawing.Size(33, 17)
        Me.checkA.TabIndex = 5
        Me.checkA.Text = "A"
        Me.checkA.UseVisualStyleBackColor = True
        '
        'checkB
        '
        Me.checkB.AutoSize = True
        Me.checkB.Location = New System.Drawing.Point(196, 183)
        Me.checkB.Name = "checkB"
        Me.checkB.Size = New System.Drawing.Size(33, 17)
        Me.checkB.TabIndex = 6
        Me.checkB.Text = "B"
        Me.checkB.UseVisualStyleBackColor = True
        '
        'checkC
        '
        Me.checkC.AutoSize = True
        Me.checkC.Location = New System.Drawing.Point(196, 228)
        Me.checkC.Name = "checkC"
        Me.checkC.Size = New System.Drawing.Size(33, 17)
        Me.checkC.TabIndex = 7
        Me.checkC.Text = "C"
        Me.checkC.UseVisualStyleBackColor = True
        '
        'checkD
        '
        Me.checkD.AutoSize = True
        Me.checkD.Location = New System.Drawing.Point(196, 268)
        Me.checkD.Name = "checkD"
        Me.checkD.Size = New System.Drawing.Size(34, 17)
        Me.checkD.TabIndex = 8
        Me.checkD.Text = "D"
        Me.checkD.UseVisualStyleBackColor = True
        '
        'txtAnswerA
        '
        Me.txtAnswerA.Location = New System.Drawing.Point(248, 139)
        Me.txtAnswerA.Name = "txtAnswerA"
        Me.txtAnswerA.Size = New System.Drawing.Size(241, 20)
        Me.txtAnswerA.TabIndex = 9
        '
        'txtAnswerB
        '
        Me.txtAnswerB.Location = New System.Drawing.Point(248, 183)
        Me.txtAnswerB.Name = "txtAnswerB"
        Me.txtAnswerB.Size = New System.Drawing.Size(241, 20)
        Me.txtAnswerB.TabIndex = 10
        '
        'txtAnswerC
        '
        Me.txtAnswerC.Location = New System.Drawing.Point(248, 226)
        Me.txtAnswerC.Name = "txtAnswerC"
        Me.txtAnswerC.Size = New System.Drawing.Size(241, 20)
        Me.txtAnswerC.TabIndex = 11
        '
        'txtAnswerD
        '
        Me.txtAnswerD.Location = New System.Drawing.Point(248, 268)
        Me.txtAnswerD.Name = "txtAnswerD"
        Me.txtAnswerD.Size = New System.Drawing.Size(241, 20)
        Me.txtAnswerD.TabIndex = 12
        '
        'MultipleChoiceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.The_Collector.My.Resources.Resources.bg
        Me.ClientSize = New System.Drawing.Size(497, 400)
        Me.Controls.Add(Me.txtAnswerD)
        Me.Controls.Add(Me.txtAnswerC)
        Me.Controls.Add(Me.txtAnswerB)
        Me.Controls.Add(Me.txtAnswerA)
        Me.Controls.Add(Me.checkD)
        Me.Controls.Add(Me.checkC)
        Me.Controls.Add(Me.checkB)
        Me.Controls.Add(Me.checkA)
        Me.Controls.Add(Me.lblQuestion)
        Me.Controls.Add(Me.lblInstructions)
        Me.Controls.Add(Me.txtQuestion)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MultipleChoiceForm"
        Me.Text = "Multiple Choice Question"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtQuestion As System.Windows.Forms.TextBox
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents lblQuestion As System.Windows.Forms.Label
    Friend WithEvents checkA As System.Windows.Forms.CheckBox
    Friend WithEvents checkB As System.Windows.Forms.CheckBox
    Friend WithEvents checkC As System.Windows.Forms.CheckBox
    Friend WithEvents checkD As System.Windows.Forms.CheckBox
    Friend WithEvents txtAnswerA As System.Windows.Forms.TextBox
    Friend WithEvents txtAnswerB As System.Windows.Forms.TextBox
    Friend WithEvents txtAnswerC As System.Windows.Forms.TextBox
    Friend WithEvents txtAnswerD As System.Windows.Forms.TextBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssignQuestion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssignQuestion))
        Me.comboTest = New System.Windows.Forms.ComboBox()
        Me.lblTest = New System.Windows.Forms.Label()
        Me.lstQuestion = New System.Windows.Forms.ListBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'comboTest
        '
        Me.comboTest.FormattingEnabled = True
        Me.comboTest.Location = New System.Drawing.Point(325, 19)
        Me.comboTest.Name = "comboTest"
        Me.comboTest.Size = New System.Drawing.Size(298, 21)
        Me.comboTest.TabIndex = 0
        '
        'lblTest
        '
        Me.lblTest.AutoSize = True
        Me.lblTest.Location = New System.Drawing.Point(247, 19)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Size = New System.Drawing.Size(28, 13)
        Me.lblTest.TabIndex = 1
        Me.lblTest.Text = "Test"
        '
        'lstQuestion
        '
        Me.lstQuestion.FormattingEnabled = True
        Me.lstQuestion.Location = New System.Drawing.Point(76, 103)
        Me.lstQuestion.Name = "lstQuestion"
        Me.lstQuestion.Size = New System.Drawing.Size(547, 147)
        Me.lstQuestion.TabIndex = 2
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(250, 322)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 3
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(391, 322)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'AssignQuestion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.The_Collector.My.Resources.Resources.bg
        Me.ClientSize = New System.Drawing.Size(738, 348)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lstQuestion)
        Me.Controls.Add(Me.lblTest)
        Me.Controls.Add(Me.comboTest)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AssignQuestion"
        Me.Text = "Assign Question to Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comboTest As System.Windows.Forms.ComboBox
    Friend WithEvents lblTest As System.Windows.Forms.Label
    Friend WithEvents lstQuestion As System.Windows.Forms.ListBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class

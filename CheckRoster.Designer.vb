<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckRoster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckRoster))
        Me.lstStudents = New System.Windows.Forms.ListBox()
        Me.comboClasses = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lstStudents
        '
        Me.lstStudents.FormattingEnabled = True
        Me.lstStudents.Location = New System.Drawing.Point(12, 12)
        Me.lstStudents.Name = "lstStudents"
        Me.lstStudents.Size = New System.Drawing.Size(156, 95)
        Me.lstStudents.TabIndex = 0
        '
        'comboClasses
        '
        Me.comboClasses.FormattingEnabled = True
        Me.comboClasses.Location = New System.Drawing.Point(191, 12)
        Me.comboClasses.Name = "comboClasses"
        Me.comboClasses.Size = New System.Drawing.Size(349, 21)
        Me.comboClasses.TabIndex = 1
        '
        'CheckRoster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(571, 169)
        Me.Controls.Add(Me.comboClasses)
        Me.Controls.Add(Me.lstStudents)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CheckRoster"
        Me.Text = "Check Class Roster"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstStudents As System.Windows.Forms.ListBox
    Friend WithEvents comboClasses As System.Windows.Forms.ComboBox
End Class

﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckGrades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckGrades))
        Me.lstTestGrades = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lstTestGrades
        '
        Me.lstTestGrades.FormattingEnabled = True
        Me.lstTestGrades.Location = New System.Drawing.Point(85, 25)
        Me.lstTestGrades.Name = "lstTestGrades"
        Me.lstTestGrades.Size = New System.Drawing.Size(338, 199)
        Me.lstTestGrades.TabIndex = 0
        '
        'CheckGrades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.The_Collector.My.Resources.Resources.bg
        Me.ClientSize = New System.Drawing.Size(508, 307)
        Me.Controls.Add(Me.lstTestGrades)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CheckGrades"
        Me.Text = "Check Test Grades"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstTestGrades As System.Windows.Forms.ListBox
End Class

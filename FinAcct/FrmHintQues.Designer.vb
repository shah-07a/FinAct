<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHintQues
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtHQues = New System.Windows.Forms.TextBox
        Me.BtnQSave = New System.Windows.Forms.Button
        Me.BtnQExit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Question ?"
        '
        'TxtHQues
        '
        Me.TxtHQues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtHQues.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtHQues.Location = New System.Drawing.Point(85, 12)
        Me.TxtHQues.MaxLength = 100
        Me.TxtHQues.Name = "TxtHQues"
        Me.TxtHQues.Size = New System.Drawing.Size(439, 22)
        Me.TxtHQues.TabIndex = 0
        '
        'BtnQSave
        '
        Me.BtnQSave.Location = New System.Drawing.Point(368, 80)
        Me.BtnQSave.Name = "BtnQSave"
        Me.BtnQSave.Size = New System.Drawing.Size(75, 26)
        Me.BtnQSave.TabIndex = 1
        Me.BtnQSave.Text = "&Save"
        Me.BtnQSave.UseVisualStyleBackColor = True
        '
        'BtnQExit
        '
        Me.BtnQExit.Location = New System.Drawing.Point(449, 80)
        Me.BtnQExit.Name = "BtnQExit"
        Me.BtnQExit.Size = New System.Drawing.Size(75, 26)
        Me.BtnQExit.TabIndex = 2
        Me.BtnQExit.Text = "&Exit"
        Me.BtnQExit.UseVisualStyleBackColor = True
        '
        'FrmHintQues
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(536, 119)
        Me.Controls.Add(Me.BtnQExit)
        Me.Controls.Add(Me.BtnQSave)
        Me.Controls.Add(Me.TxtHQues)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmHintQues"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hint Question ???"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtHQues As System.Windows.Forms.TextBox
    Friend WithEvents BtnQSave As System.Windows.Forms.Button
    Friend WithEvents BtnQExit As System.Windows.Forms.Button
End Class

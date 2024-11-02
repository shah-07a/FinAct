<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAttd
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RbAll = New System.Windows.Forms.RadioButton
        Me.RbOutTm = New System.Windows.Forms.RadioButton
        Me.RbBrkInTm = New System.Windows.Forms.RadioButton
        Me.RbBrkOutTm = New System.Windows.Forms.RadioButton
        Me.RbInTime = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.BtnOk = New System.Windows.Forms.Button
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.DtpkrDte = New System.Windows.Forms.DateTimePicker
        Me.Label31 = New System.Windows.Forms.Label
        Me.Cmbxsft = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RbAll)
        Me.Panel1.Controls.Add(Me.RbOutTm)
        Me.Panel1.Controls.Add(Me.RbBrkInTm)
        Me.Panel1.Controls.Add(Me.RbBrkOutTm)
        Me.Panel1.Controls.Add(Me.RbInTime)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(12, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(337, 209)
        Me.Panel1.TabIndex = 0
        '
        'RbAll
        '
        Me.RbAll.AutoSize = True
        Me.RbAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbAll.Location = New System.Drawing.Point(19, 184)
        Me.RbAll.Name = "RbAll"
        Me.RbAll.Size = New System.Drawing.Size(39, 17)
        Me.RbAll.TabIndex = 6
        Me.RbAll.TabStop = True
        Me.RbAll.Text = "All"
        Me.RbAll.UseVisualStyleBackColor = True
        '
        'RbOutTm
        '
        Me.RbOutTm.AutoSize = True
        Me.RbOutTm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbOutTm.Location = New System.Drawing.Point(19, 151)
        Me.RbOutTm.Name = "RbOutTm"
        Me.RbOutTm.Size = New System.Drawing.Size(76, 17)
        Me.RbOutTm.TabIndex = 5
        Me.RbOutTm.TabStop = True
        Me.RbOutTm.Text = "Out Time"
        Me.RbOutTm.UseVisualStyleBackColor = True
        '
        'RbBrkInTm
        '
        Me.RbBrkInTm.AutoSize = True
        Me.RbBrkInTm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbBrkInTm.Location = New System.Drawing.Point(19, 118)
        Me.RbBrkInTm.Name = "RbBrkInTm"
        Me.RbBrkInTm.Size = New System.Drawing.Size(104, 17)
        Me.RbBrkInTm.TabIndex = 4
        Me.RbBrkInTm.TabStop = True
        Me.RbBrkInTm.Text = "Break In Time"
        Me.RbBrkInTm.UseVisualStyleBackColor = True
        '
        'RbBrkOutTm
        '
        Me.RbBrkOutTm.AutoSize = True
        Me.RbBrkOutTm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbBrkOutTm.Location = New System.Drawing.Point(19, 85)
        Me.RbBrkOutTm.Name = "RbBrkOutTm"
        Me.RbBrkOutTm.Size = New System.Drawing.Size(113, 17)
        Me.RbBrkOutTm.TabIndex = 3
        Me.RbBrkOutTm.TabStop = True
        Me.RbBrkOutTm.Text = "Break Out Time"
        Me.RbBrkOutTm.UseVisualStyleBackColor = True
        '
        'RbInTime
        '
        Me.RbInTime.AutoSize = True
        Me.RbInTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbInTime.Location = New System.Drawing.Point(19, 52)
        Me.RbInTime.Name = "RbInTime"
        Me.RbInTime.Size = New System.Drawing.Size(67, 17)
        Me.RbInTime.TabIndex = 2
        Me.RbInTime.TabStop = True
        Me.RbInTime.Text = "In Time"
        Me.RbInTime.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(232, 20)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Select an option to mark Attendance:-"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(178, 277)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(75, 29)
        Me.BtnOk.TabIndex = 7
        Me.BtnOk.Text = "&OK"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'BtnCncl
        '
        Me.BtnCncl.Location = New System.Drawing.Point(272, 276)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(75, 30)
        Me.BtnCncl.TabIndex = 8
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'DtpkrDte
        '
        Me.DtpkrDte.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrDte.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrDte.Location = New System.Drawing.Point(63, 12)
        Me.DtpkrDte.Name = "DtpkrDte"
        Me.DtpkrDte.Size = New System.Drawing.Size(86, 20)
        Me.DtpkrDte.TabIndex = 0
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(12, 12)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(48, 20)
        Me.Label31.TabIndex = 4
        Me.Label31.Text = "Date:-"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cmbxsft
        '
        Me.Cmbxsft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxsft.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxsft.Location = New System.Drawing.Point(270, 12)
        Me.Cmbxsft.Name = "Cmbxsft"
        Me.Cmbxsft.Size = New System.Drawing.Size(80, 22)
        Me.Cmbxsft.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(220, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Shift :-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmAttd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(361, 322)
        Me.Controls.Add(Me.Cmbxsft)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtpkrDte)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmAttd"
        Me.Text = "Attendance Option"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents RbInTime As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RbAll As System.Windows.Forms.RadioButton
    Friend WithEvents RbOutTm As System.Windows.Forms.RadioButton
    Friend WithEvents RbBrkInTm As System.Windows.Forms.RadioButton
    Friend WithEvents RbBrkOutTm As System.Windows.Forms.RadioButton
    Friend WithEvents DtpkrDte As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Cmbxsft As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class

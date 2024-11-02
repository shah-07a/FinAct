<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAttendOut
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
        Me.DtpkrDt = New System.Windows.Forms.DateTimePicker
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbxShift = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblStrtTm = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblEndTm = New System.Windows.Forms.Label
        Me.LblShift = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.DatagrdOutTime = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DatagrdOutTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DtpkrDt
        '
        Me.DtpkrDt.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrDt.Location = New System.Drawing.Point(66, 9)
        Me.DtpkrDt.Name = "DtpkrDt"
        Me.DtpkrDt.Size = New System.Drawing.Size(86, 20)
        Me.DtpkrDt.TabIndex = 2
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(15, 9)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(48, 20)
        Me.Label31.TabIndex = 3
        Me.Label31.Text = "Date:-"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(3, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(713, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Attendance Register"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(238, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Start Time :-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxShift
        '
        Me.CmbxShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxShift.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxShift.Items.AddRange(New Object() {"1st", "2nd", "3rd"})
        Me.CmbxShift.Location = New System.Drawing.Point(66, 65)
        Me.CmbxShift.Name = "CmbxShift"
        Me.CmbxShift.Size = New System.Drawing.Size(80, 22)
        Me.CmbxShift.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Shift :-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblStrtTm
        '
        Me.LblStrtTm.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblStrtTm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblStrtTm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStrtTm.Location = New System.Drawing.Point(321, 64)
        Me.LblStrtTm.Name = "LblStrtTm"
        Me.LblStrtTm.Size = New System.Drawing.Size(80, 20)
        Me.LblStrtTm.TabIndex = 10
        Me.LblStrtTm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(493, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "End Time :-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblEndTm
        '
        Me.LblEndTm.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblEndTm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblEndTm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndTm.Location = New System.Drawing.Point(571, 64)
        Me.LblEndTm.Name = "LblEndTm"
        Me.LblEndTm.Size = New System.Drawing.Size(80, 20)
        Me.LblEndTm.TabIndex = 8
        Me.LblEndTm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblShift
        '
        Me.LblShift.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblShift.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShift.Location = New System.Drawing.Point(73, 42)
        Me.LblShift.Name = "LblShift"
        Me.LblShift.Size = New System.Drawing.Size(80, 20)
        Me.LblShift.TabIndex = 24
        Me.LblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label18.Location = New System.Drawing.Point(-1, 93)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(716, 10)
        Me.Label18.TabIndex = 25
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Location = New System.Drawing.Point(636, 237)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 23)
        Me.BtnClose.TabIndex = 27
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCncl
        '
        Me.BtnCncl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCncl.Location = New System.Drawing.Point(541, 237)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(75, 23)
        Me.BtnCncl.TabIndex = 28
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(451, 237)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 29
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'DatagrdOutTime
        '
        Me.DatagrdOutTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DatagrdOutTime.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DatagrdOutTime.Location = New System.Drawing.Point(2, 121)
        Me.DatagrdOutTime.Name = "DatagrdOutTime"
        Me.DatagrdOutTime.Size = New System.Drawing.Size(713, 84)
        Me.DatagrdOutTime.TabIndex = 30
        '
        'Column1
        '
        Me.Column1.HeaderText = "Employee Id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Employee Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = "Status"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 120
        '
        'Column4
        '
        Me.Column4.HeaderText = "Reporting Status"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 140
        '
        'Column5
        '
        Me.Column5.HeaderText = "Out Time"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 110
        '
        'FrmAttendOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(719, 273)
        Me.Controls.Add(Me.DatagrdOutTime)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.LblShift)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbxShift)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblStrtTm)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblEndTm)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtpkrDt)
        Me.Controls.Add(Me.Label31)
        Me.Name = "FrmAttendOut"
        Me.Text = "FrmAttendOut"
        CType(Me.DatagrdOutTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DtpkrDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbxShift As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblStrtTm As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblEndTm As System.Windows.Forms.Label
    Friend WithEvents LblShift As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents DatagrdOutTime As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

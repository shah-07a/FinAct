<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMatrntyLev
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
        Me.Dtpkrdt1 = New System.Windows.Forms.DateTimePicker
        Me.Label31 = New System.Windows.Forms.Label
        Me.CmbxShift = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbxEmpnm = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.DtpkrDt2 = New System.Windows.Forms.DateTimePicker
        Me.DtpkrDt3 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbxType = New System.Windows.Forms.ComboBox
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.BtnCls = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnFind = New System.Windows.Forms.Button
        Me.LblSrch = New System.Windows.Forms.Label
        Me.CmbxSrchEmp = New System.Windows.Forms.ComboBox
        Me.LblPress = New System.Windows.Forms.Label
        Me.TxtEmpnm = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dtpkrdt1
        '
        Me.Dtpkrdt1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpkrdt1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpkrdt1.Location = New System.Drawing.Point(80, 12)
        Me.Dtpkrdt1.Name = "Dtpkrdt1"
        Me.Dtpkrdt1.Size = New System.Drawing.Size(90, 20)
        Me.Dtpkrdt1.TabIndex = 0
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(26, 12)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(48, 20)
        Me.Label31.TabIndex = 2
        Me.Label31.Text = "Date:-"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxShift
        '
        Me.CmbxShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxShift.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxShift.Items.AddRange(New Object() {"1st", "2nd", "3rd"})
        Me.CmbxShift.Location = New System.Drawing.Point(337, 10)
        Me.CmbxShift.Name = "CmbxShift"
        Me.CmbxShift.Size = New System.Drawing.Size(80, 22)
        Me.CmbxShift.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(282, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Shift :-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxEmpnm
        '
        Me.CmbxEmpnm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxEmpnm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxEmpnm.Location = New System.Drawing.Point(131, 21)
        Me.CmbxEmpnm.Name = "CmbxEmpnm"
        Me.CmbxEmpnm.Size = New System.Drawing.Size(205, 22)
        Me.CmbxEmpnm.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Employee Name:-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 16)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = " From:-"
        '
        'DtpkrDt2
        '
        Me.DtpkrDt2.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrDt2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrDt2.Location = New System.Drawing.Point(131, 63)
        Me.DtpkrDt2.Name = "DtpkrDt2"
        Me.DtpkrDt2.Size = New System.Drawing.Size(90, 20)
        Me.DtpkrDt2.TabIndex = 62
        '
        'DtpkrDt3
        '
        Me.DtpkrDt3.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrDt3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrDt3.Location = New System.Drawing.Point(312, 63)
        Me.DtpkrDt3.Name = "DtpkrDt3"
        Me.DtpkrDt3.Size = New System.Drawing.Size(90, 20)
        Me.DtpkrDt3.TabIndex = 64
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(254, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 16)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "To:-"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtEmpnm)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.CmbxType)
        Me.Panel1.Controls.Add(Me.DtpkrDt3)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpkrDt2)
        Me.Panel1.Controls.Add(Me.CmbxEmpnm)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(12, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(455, 153)
        Me.Panel1.TabIndex = 65
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 20)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Type:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxType
        '
        Me.CmbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxType.Items.AddRange(New Object() {"With Pay", "Without Pay"})
        Me.CmbxType.Location = New System.Drawing.Point(131, 101)
        Me.CmbxType.Name = "CmbxType"
        Me.CmbxType.Size = New System.Drawing.Size(128, 22)
        Me.CmbxType.TabIndex = 66
        '
        'BtnCncl
        '
        Me.BtnCncl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCncl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCncl.Location = New System.Drawing.Point(294, 302)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(75, 23)
        Me.BtnCncl.TabIndex = 68
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'BtnCls
        '
        Me.BtnCls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCls.Location = New System.Drawing.Point(390, 302)
        Me.BtnCls.Name = "BtnCls"
        Me.BtnCls.Size = New System.Drawing.Size(75, 23)
        Me.BtnCls.TabIndex = 69
        Me.BtnCls.Text = "&Close"
        Me.BtnCls.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnSave.Location = New System.Drawing.Point(95, 304)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 66
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnFind
        '
        Me.BtnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnFind.Location = New System.Drawing.Point(197, 304)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(75, 23)
        Me.BtnFind.TabIndex = 67
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = True
        '
        'LblSrch
        '
        Me.LblSrch.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblSrch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSrch.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSrch.Location = New System.Drawing.Point(15, 221)
        Me.LblSrch.Name = "LblSrch"
        Me.LblSrch.Size = New System.Drawing.Size(170, 20)
        Me.LblSrch.TabIndex = 70
        Me.LblSrch.Text = "Select an Employee Name:-"
        Me.LblSrch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxSrchEmp
        '
        Me.CmbxSrchEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxSrchEmp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxSrchEmp.Location = New System.Drawing.Point(15, 254)
        Me.CmbxSrchEmp.Name = "CmbxSrchEmp"
        Me.CmbxSrchEmp.Size = New System.Drawing.Size(205, 22)
        Me.CmbxSrchEmp.TabIndex = 71
        '
        'LblPress
        '
        Me.LblPress.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblPress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPress.ForeColor = System.Drawing.Color.Crimson
        Me.LblPress.Location = New System.Drawing.Point(226, 254)
        Me.LblPress.Name = "LblPress"
        Me.LblPress.Size = New System.Drawing.Size(143, 20)
        Me.LblPress.TabIndex = 72
        Me.LblPress.Text = "Press Enter to Continue"
        Me.LblPress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtEmpnm
        '
        Me.TxtEmpnm.Location = New System.Drawing.Point(131, 23)
        Me.TxtEmpnm.Name = "TxtEmpnm"
        Me.TxtEmpnm.Size = New System.Drawing.Size(186, 20)
        Me.TxtEmpnm.TabIndex = 67
        '
        'FrmMatrntyLev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(479, 339)
        Me.Controls.Add(Me.LblPress)
        Me.Controls.Add(Me.LblSrch)
        Me.Controls.Add(Me.CmbxSrchEmp)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.BtnCls)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.CmbxShift)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Dtpkrdt1)
        Me.Name = "FrmMatrntyLev"
        Me.Text = "FrmMatrntyLev"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dtpkrdt1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents CmbxShift As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbxEmpnm As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DtpkrDt2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpkrDt3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbxType As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents BtnCls As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents LblSrch As System.Windows.Forms.Label
    Friend WithEvents CmbxSrchEmp As System.Windows.Forms.ComboBox
    Friend WithEvents LblPress As System.Windows.Forms.Label
    Friend WithEvents TxtEmpnm As System.Windows.Forms.TextBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShrtLeve
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
        Me.DtpkrDt_SL = New System.Windows.Forms.DateTimePicker
        Me.Label31 = New System.Windows.Forms.Label
        Me.CmbSft = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbEmName = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DtpkrTo = New System.Windows.Forms.DateTimePicker
        Me.DtpkrRepTm = New System.Windows.Forms.DateTimePicker
        Me.DtpkrFrm = New System.Windows.Forms.DateTimePicker
        Me.TxtEmpnm = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmType = New System.Windows.Forms.ComboBox
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnCls = New System.Windows.Forms.Button
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.BtnFnd = New System.Windows.Forms.Button
        Me.ListVew = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.CmbxType_Fnd = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Dtpkr_Fnd = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.LblPress = New System.Windows.Forms.Label
        Me.LblSrch = New System.Windows.Forms.Label
        Me.CmbxSrchEmp = New System.Windows.Forms.ComboBox
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtpkrDt_SL
        '
        Me.DtpkrDt_SL.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrDt_SL.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrDt_SL.Location = New System.Drawing.Point(61, 14)
        Me.DtpkrDt_SL.Name = "DtpkrDt_SL"
        Me.DtpkrDt_SL.Size = New System.Drawing.Size(86, 20)
        Me.DtpkrDt_SL.TabIndex = 8
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(10, 14)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(48, 20)
        Me.Label31.TabIndex = 9
        Me.Label31.Text = "Date:-"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbSft
        '
        Me.CmbSft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSft.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbSft.Items.AddRange(New Object() {"1st", "2nd", "3rd"})
        Me.CmbSft.Location = New System.Drawing.Point(333, 12)
        Me.CmbSft.Name = "CmbSft"
        Me.CmbSft.Size = New System.Drawing.Size(80, 22)
        Me.CmbSft.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(278, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Shift :-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Employee Name:-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbEmName
        '
        Me.CmbEmName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEmName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbEmName.Items.AddRange(New Object() {"1st", "2nd", "3rd"})
        Me.CmbEmName.Location = New System.Drawing.Point(130, 60)
        Me.CmbEmName.Name = "CmbEmName"
        Me.CmbEmName.Size = New System.Drawing.Size(205, 22)
        Me.CmbEmName.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.DtpkrTo)
        Me.Panel1.Controls.Add(Me.DtpkrRepTm)
        Me.Panel1.Controls.Add(Me.DtpkrFrm)
        Me.Panel1.Controls.Add(Me.TxtEmpnm)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.CmType)
        Me.Panel1.Controls.Add(Me.CmbEmName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CmbSft)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.DtpkrDt_SL)
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Location = New System.Drawing.Point(11, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(451, 282)
        Me.Panel1.TabIndex = 15
        '
        'DtpkrTo
        '
        Me.DtpkrTo.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpkrTo.Location = New System.Drawing.Point(131, 185)
        Me.DtpkrTo.Name = "DtpkrTo"
        Me.DtpkrTo.ShowUpDown = True
        Me.DtpkrTo.Size = New System.Drawing.Size(88, 20)
        Me.DtpkrTo.TabIndex = 77
        '
        'DtpkrRepTm
        '
        Me.DtpkrRepTm.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpkrRepTm.Location = New System.Drawing.Point(131, 229)
        Me.DtpkrRepTm.Name = "DtpkrRepTm"
        Me.DtpkrRepTm.ShowUpDown = True
        Me.DtpkrRepTm.Size = New System.Drawing.Size(88, 20)
        Me.DtpkrRepTm.TabIndex = 76
        '
        'DtpkrFrm
        '
        Me.DtpkrFrm.CustomFormat = ""
        Me.DtpkrFrm.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpkrFrm.Location = New System.Drawing.Point(131, 143)
        Me.DtpkrFrm.Name = "DtpkrFrm"
        Me.DtpkrFrm.ShowUpDown = True
        Me.DtpkrFrm.Size = New System.Drawing.Size(88, 20)
        Me.DtpkrFrm.TabIndex = 75
        '
        'TxtEmpnm
        '
        Me.TxtEmpnm.Location = New System.Drawing.Point(130, 61)
        Me.TxtEmpnm.Name = "TxtEmpnm"
        Me.TxtEmpnm.Size = New System.Drawing.Size(205, 20)
        Me.TxtEmpnm.TabIndex = 74
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 233)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 16)
        Me.Label11.TabIndex = 63
        Me.Label11.Text = " Reporting Time :-"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 189)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 16)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "To:-"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 147)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 16)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = " From:-"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Type:-"
        '
        'CmType
        '
        Me.CmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmType.FormattingEnabled = True
        Me.CmType.Items.AddRange(New Object() {"Official", "Personal"})
        Me.CmType.Location = New System.Drawing.Point(130, 103)
        Me.CmType.Name = "CmType"
        Me.CmType.Size = New System.Drawing.Size(121, 21)
        Me.CmType.TabIndex = 55
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnSave.Location = New System.Drawing.Point(99, 524)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 16
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCls
        '
        Me.BtnCls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCls.Location = New System.Drawing.Point(385, 524)
        Me.BtnCls.Name = "BtnCls"
        Me.BtnCls.Size = New System.Drawing.Size(75, 23)
        Me.BtnCls.TabIndex = 18
        Me.BtnCls.Text = "&Close"
        Me.BtnCls.UseVisualStyleBackColor = True
        '
        'BtnCncl
        '
        Me.BtnCncl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCncl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCncl.Location = New System.Drawing.Point(289, 524)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(75, 23)
        Me.BtnCncl.TabIndex = 17
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'BtnFnd
        '
        Me.BtnFnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnFnd.Location = New System.Drawing.Point(192, 524)
        Me.BtnFnd.Name = "BtnFnd"
        Me.BtnFnd.Size = New System.Drawing.Size(75, 23)
        Me.BtnFnd.TabIndex = 19
        Me.BtnFnd.Text = "&Find"
        Me.BtnFnd.UseVisualStyleBackColor = True
        '
        'ListVew
        '
        Me.ListVew.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListVew.FullRowSelect = True
        Me.ListVew.GridLines = True
        Me.ListVew.Location = New System.Drawing.Point(472, 12)
        Me.ListVew.Name = "ListVew"
        Me.ListVew.Size = New System.Drawing.Size(529, 282)
        Me.ListVew.TabIndex = 76
        Me.ListVew.UseCompatibleStateImageBehavior = False
        Me.ListVew.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Date"
        Me.ColumnHeader1.Width = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Employee Id"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Employee Name"
        Me.ColumnHeader3.Width = 135
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "From"
        Me.ColumnHeader4.Width = 76
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "To"
        Me.ColumnHeader5.Width = 76
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Reporting Time"
        Me.ColumnHeader6.Width = 88
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Shift"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Type"
        Me.ColumnHeader8.Width = 0
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CmbxType_Fnd)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Dtpkr_Fnd)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.LblPress)
        Me.Panel2.Controls.Add(Me.LblSrch)
        Me.Panel2.Controls.Add(Me.CmbxSrchEmp)
        Me.Panel2.Location = New System.Drawing.Point(12, 308)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(450, 185)
        Me.Panel2.TabIndex = 74
        '
        'CmbxType_Fnd
        '
        Me.CmbxType_Fnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxType_Fnd.FormattingEnabled = True
        Me.CmbxType_Fnd.Items.AddRange(New Object() {"Official", "Personal"})
        Me.CmbxType_Fnd.Location = New System.Drawing.Point(89, 139)
        Me.CmbxType_Fnd.Name = "CmbxType_Fnd"
        Me.CmbxType_Fnd.Size = New System.Drawing.Size(121, 21)
        Me.CmbxType_Fnd.TabIndex = 93
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 20)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Type:-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Dtpkr_Fnd
        '
        Me.Dtpkr_Fnd.CustomFormat = "MMMM/yyyy"
        Me.Dtpkr_Fnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpkr_Fnd.Location = New System.Drawing.Point(91, 97)
        Me.Dtpkr_Fnd.Name = "Dtpkr_Fnd"
        Me.Dtpkr_Fnd.Size = New System.Drawing.Size(116, 20)
        Me.Dtpkr_Fnd.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 20)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Month:-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblPress
        '
        Me.LblPress.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblPress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPress.ForeColor = System.Drawing.Color.Crimson
        Me.LblPress.Location = New System.Drawing.Point(216, 140)
        Me.LblPress.Name = "LblPress"
        Me.LblPress.Size = New System.Drawing.Size(143, 20)
        Me.LblPress.TabIndex = 90
        Me.LblPress.Text = "Press Enter to Continue"
        Me.LblPress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSrch
        '
        Me.LblSrch.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblSrch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSrch.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSrch.Location = New System.Drawing.Point(10, 18)
        Me.LblSrch.Name = "LblSrch"
        Me.LblSrch.Size = New System.Drawing.Size(170, 20)
        Me.LblSrch.TabIndex = 88
        Me.LblSrch.Text = "Select an Employee Name:-"
        Me.LblSrch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxSrchEmp
        '
        Me.CmbxSrchEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxSrchEmp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxSrchEmp.Location = New System.Drawing.Point(10, 51)
        Me.CmbxSrchEmp.Name = "CmbxSrchEmp"
        Me.CmbxSrchEmp.Size = New System.Drawing.Size(205, 22)
        Me.CmbxSrchEmp.TabIndex = 89
        '
        'FrmShrtLeve
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(472, 561)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ListVew)
        Me.Controls.Add(Me.BtnFnd)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.BtnCls)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmShrtLeve"
        Me.Text = "Short Leave"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DtpkrDt_SL As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents CmbSft As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbEmName As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmType As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnCls As System.Windows.Forms.Button
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents BtnFnd As System.Windows.Forms.Button
    Friend WithEvents ListVew As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblPress As System.Windows.Forms.Label
    Friend WithEvents LblSrch As System.Windows.Forms.Label
    Friend WithEvents CmbxSrchEmp As System.Windows.Forms.ComboBox
    Friend WithEvents Dtpkr_Fnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtEmpnm As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CmbxType_Fnd As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtpkrFrm As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpkrRepTm As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpkrTo As System.Windows.Forms.DateTimePicker
End Class

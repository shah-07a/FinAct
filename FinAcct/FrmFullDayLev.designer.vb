<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFullDayLev
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CmbxEmp = New System.Windows.Forms.ComboBox
        Me.TxtResn = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.DtpkrTo = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DtpkrFrm = New System.Windows.Forms.DateTimePicker
        Me.LblEmpid = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label31 = New System.Windows.Forms.Label
        Me.DtpkrDt = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbSft = New System.Windows.Forms.ComboBox
        Me.BtnFnd = New System.Windows.Forms.Button
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.BtnCls = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.CmbxType_Fnd = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Dtpkr_Fnd = New System.Windows.Forms.DateTimePicker
        Me.LblPress = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.LblSrch = New System.Windows.Forms.Label
        Me.CmbxSrchEmp = New System.Windows.Forms.ComboBox
        Me.LstvewLev = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.Lstvew2 = New System.Windows.Forms.ListView
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Type:-"
        '
        'CmType
        '
        Me.CmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmType.FormattingEnabled = True
        Me.CmType.Items.AddRange(New Object() {"Sick Leave", "Casual Leave", "Earn Leave", "Compensatory Off"})
        Me.CmType.Location = New System.Drawing.Point(127, 110)
        Me.CmType.Name = "CmType"
        Me.CmType.Size = New System.Drawing.Size(121, 21)
        Me.CmType.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Employee Name:-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CmbxEmp)
        Me.Panel1.Controls.Add(Me.TxtResn)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.DtpkrTo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.DtpkrFrm)
        Me.Panel1.Controls.Add(Me.LblEmpid)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.CmType)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(515, 224)
        Me.Panel1.TabIndex = 1
        '
        'CmbxEmp
        '
        Me.CmbxEmp.FormattingEnabled = True
        Me.CmbxEmp.Location = New System.Drawing.Point(127, 14)
        Me.CmbxEmp.Name = "CmbxEmp"
        Me.CmbxEmp.Size = New System.Drawing.Size(177, 21)
        Me.CmbxEmp.TabIndex = 2
        '
        'TxtResn
        '
        Me.TxtResn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtResn.Location = New System.Drawing.Point(127, 157)
        Me.TxtResn.Multiline = True
        Me.TxtResn.Name = "TxtResn"
        Me.TxtResn.Size = New System.Drawing.Size(234, 42)
        Me.TxtResn.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 20)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Reason:-"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtpkrTo
        '
        Me.DtpkrTo.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrTo.Location = New System.Drawing.Point(399, 63)
        Me.DtpkrTo.Name = "DtpkrTo"
        Me.DtpkrTo.Size = New System.Drawing.Size(86, 20)
        Me.DtpkrTo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(332, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 20)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "To:-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 20)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "From:-"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtpkrFrm
        '
        Me.DtpkrFrm.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrFrm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrFrm.Location = New System.Drawing.Point(127, 63)
        Me.DtpkrFrm.Name = "DtpkrFrm"
        Me.DtpkrFrm.Size = New System.Drawing.Size(87, 20)
        Me.DtpkrFrm.TabIndex = 3
        '
        'LblEmpid
        '
        Me.LblEmpid.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblEmpid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblEmpid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmpid.Location = New System.Drawing.Point(399, 16)
        Me.LblEmpid.Name = "LblEmpid"
        Me.LblEmpid.Size = New System.Drawing.Size(93, 20)
        Me.LblEmpid.TabIndex = 88
        Me.LblEmpid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(334, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 20)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Emp Id:-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label31)
        Me.Panel2.Controls.Add(Me.DtpkrDt)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.CmbSft)
        Me.Panel2.Location = New System.Drawing.Point(12, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(515, 43)
        Me.Panel2.TabIndex = 0
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(10, 13)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(48, 20)
        Me.Label31.TabIndex = 80
        Me.Label31.Text = "Date:-"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtpkrDt
        '
        Me.DtpkrDt.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrDt.Location = New System.Drawing.Point(61, 13)
        Me.DtpkrDt.Name = "DtpkrDt"
        Me.DtpkrDt.Size = New System.Drawing.Size(86, 20)
        Me.DtpkrDt.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(332, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Shift :-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbSft
        '
        Me.CmbSft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSft.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbSft.Items.AddRange(New Object() {"1st", "2nd", "3rd"})
        Me.CmbSft.Location = New System.Drawing.Point(387, 11)
        Me.CmbSft.Name = "CmbSft"
        Me.CmbSft.Size = New System.Drawing.Size(80, 22)
        Me.CmbSft.TabIndex = 1
        '
        'BtnFnd
        '
        Me.BtnFnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnFnd.Location = New System.Drawing.Point(441, 545)
        Me.BtnFnd.Name = "BtnFnd"
        Me.BtnFnd.Size = New System.Drawing.Size(75, 23)
        Me.BtnFnd.TabIndex = 8
        Me.BtnFnd.Text = "&Find"
        Me.BtnFnd.UseVisualStyleBackColor = True
        '
        'BtnCncl
        '
        Me.BtnCncl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCncl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCncl.Location = New System.Drawing.Point(538, 545)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(75, 23)
        Me.BtnCncl.TabIndex = 9
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'BtnCls
        '
        Me.BtnCls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCls.Location = New System.Drawing.Point(634, 545)
        Me.BtnCls.Name = "BtnCls"
        Me.BtnCls.Size = New System.Drawing.Size(75, 23)
        Me.BtnCls.TabIndex = 10
        Me.BtnCls.Text = "&Close"
        Me.BtnCls.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnSave.Location = New System.Drawing.Point(348, 545)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'CmbxType_Fnd
        '
        Me.CmbxType_Fnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxType_Fnd.FormattingEnabled = True
        Me.CmbxType_Fnd.Items.AddRange(New Object() {"Sick Leave", "Casual Leave", "Earn Leave", "Compensatory Off"})
        Me.CmbxType_Fnd.Location = New System.Drawing.Point(89, 139)
        Me.CmbxType_Fnd.Name = "CmbxType_Fnd"
        Me.CmbxType_Fnd.Size = New System.Drawing.Size(121, 21)
        Me.CmbxType_Fnd.TabIndex = 93
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 20)
        Me.Label8.TabIndex = 92
        Me.Label8.Text = "Type:-"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.CmbxType_Fnd)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Dtpkr_Fnd)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.LblPress)
        Me.Panel3.Controls.Add(Me.LblSrch)
        Me.Panel3.Controls.Add(Me.CmbxSrchEmp)
        Me.Panel3.Location = New System.Drawing.Point(569, 61)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(513, 185)
        Me.Panel3.TabIndex = 75
        Me.Panel3.Visible = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 20)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "Month:-"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'LstvewLev
        '
        Me.LstvewLev.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.LstvewLev.FullRowSelect = True
        Me.LstvewLev.GridLines = True
        Me.LstvewLev.Location = New System.Drawing.Point(12, 297)
        Me.LstvewLev.Name = "LstvewLev"
        Me.LstvewLev.Size = New System.Drawing.Size(701, 230)
        Me.LstvewLev.TabIndex = 76
        Me.LstvewLev.UseCompatibleStateImageBehavior = False
        Me.LstvewLev.View = System.Windows.Forms.View.Details
        Me.LstvewLev.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Date"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Shift"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "EmpId"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Employee Name"
        Me.ColumnHeader4.Width = 130
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "From Date"
        Me.ColumnHeader5.Width = 68
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "To Date"
        Me.ColumnHeader6.Width = 65
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Type"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Reason"
        Me.ColumnHeader8.Width = 150
        '
        'Lstvew2
        '
        Me.Lstvew2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.Lstvew2.FullRowSelect = True
        Me.Lstvew2.GridLines = True
        Me.Lstvew2.Location = New System.Drawing.Point(13, 297)
        Me.Lstvew2.Name = "Lstvew2"
        Me.Lstvew2.Size = New System.Drawing.Size(696, 230)
        Me.Lstvew2.TabIndex = 77
        Me.Lstvew2.UseCompatibleStateImageBehavior = False
        Me.Lstvew2.View = System.Windows.Forms.View.Details
        Me.Lstvew2.Visible = False
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Date"
        Me.ColumnHeader9.Width = 80
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Shift"
        Me.ColumnHeader10.Width = 70
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Empid"
        Me.ColumnHeader11.Width = 95
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Employee Name"
        Me.ColumnHeader12.Width = 155
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Type"
        Me.ColumnHeader13.Width = 125
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Reason"
        Me.ColumnHeader14.Width = 160
        '
        'FrmFullDayLev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 580)
        Me.Controls.Add(Me.Lstvew2)
        Me.Controls.Add(Me.LstvewLev)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.BtnFnd)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.BtnCls)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmFullDayLev"
        Me.Text = "FrmFullDayLev"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblEmpid As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtpkrTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtResn As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents DtpkrDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbSft As System.Windows.Forms.ComboBox
    Friend WithEvents DtpkrFrm As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnFnd As System.Windows.Forms.Button
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents BtnCls As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents CmbxEmp As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxType_Fnd As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Dtpkr_Fnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblPress As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblSrch As System.Windows.Forms.Label
    Friend WithEvents CmbxSrchEmp As System.Windows.Forms.ComboBox
    Friend WithEvents LstvewLev As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Lstvew2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
End Class

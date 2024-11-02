<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptForm13A
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
        Me.BtnEPF13a = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.CmbxPemplrEpf = New System.Windows.Forms.ComboBox
        Me.Cmbxemplr = New System.Windows.Forms.ComboBox
        Me.TxtPensnNo = New System.Windows.Forms.TextBox
        Me.TxtPfAcNo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txtemplradrs = New System.Windows.Forms.TextBox
        Me.DtpickLev = New System.Windows.Forms.DateTimePicker
        Me.TxtemplrName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbxEpfEmpname = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.CrVewEPFfrm13A = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptfrm13A1 = New FinAcct.CrRptfrm13A
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnEPF13a)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.CmbxEpfEmpname)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1005, 187)
        Me.Panel1.TabIndex = 0
        '
        'BtnEPF13a
        '
        Me.BtnEPF13a.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEPF13a.Location = New System.Drawing.Point(673, 156)
        Me.BtnEPF13a.Name = "BtnEPF13a"
        Me.BtnEPF13a.Size = New System.Drawing.Size(316, 23)
        Me.BtnEPF13a.TabIndex = 11
        Me.BtnEPF13a.Text = "View Report"
        Me.BtnEPF13a.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CmbxPemplrEpf)
        Me.Panel2.Controls.Add(Me.Cmbxemplr)
        Me.Panel2.Controls.Add(Me.TxtPensnNo)
        Me.Panel2.Controls.Add(Me.TxtPfAcNo)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Txtemplradrs)
        Me.Panel2.Controls.Add(Me.DtpickLev)
        Me.Panel2.Controls.Add(Me.TxtemplrName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(6, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(983, 114)
        Me.Panel2.TabIndex = 3
        '
        'CmbxPemplrEpf
        '
        Me.CmbxPemplrEpf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxPemplrEpf.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxPemplrEpf.FormattingEnabled = True
        Me.CmbxPemplrEpf.Items.AddRange(New Object() {"Unexempted", "Uncovered"})
        Me.CmbxPemplrEpf.Location = New System.Drawing.Point(204, 82)
        Me.CmbxPemplrEpf.Name = "CmbxPemplrEpf"
        Me.CmbxPemplrEpf.Size = New System.Drawing.Size(229, 22)
        Me.CmbxPemplrEpf.TabIndex = 7
        '
        'Cmbxemplr
        '
        Me.Cmbxemplr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxemplr.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxemplr.FormattingEnabled = True
        Me.Cmbxemplr.Items.AddRange(New Object() {"Unexempted", "Exempted", "Uncovered"})
        Me.Cmbxemplr.Location = New System.Drawing.Point(666, 28)
        Me.Cmbxemplr.Name = "Cmbxemplr"
        Me.Cmbxemplr.Size = New System.Drawing.Size(312, 22)
        Me.Cmbxemplr.TabIndex = 8
        '
        'TxtPensnNo
        '
        Me.TxtPensnNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPensnNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPensnNo.Location = New System.Drawing.Point(666, 56)
        Me.TxtPensnNo.MaxLength = 30
        Me.TxtPensnNo.Name = "TxtPensnNo"
        Me.TxtPensnNo.Size = New System.Drawing.Size(312, 21)
        Me.TxtPensnNo.TabIndex = 9
        '
        'TxtPfAcNo
        '
        Me.TxtPfAcNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPfAcNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPfAcNo.Location = New System.Drawing.Point(204, 56)
        Me.TxtPfAcNo.MaxLength = 30
        Me.TxtPfAcNo.Name = "TxtPfAcNo"
        Me.TxtPfAcNo.Size = New System.Drawing.Size(229, 21)
        Me.TxtPfAcNo.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(554, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 18)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Date Leaving  :-"
        '
        'Txtemplradrs
        '
        Me.Txtemplradrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtemplradrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtemplradrs.Location = New System.Drawing.Point(205, 30)
        Me.Txtemplradrs.MaxLength = 70
        Me.Txtemplradrs.Name = "Txtemplradrs"
        Me.Txtemplradrs.Size = New System.Drawing.Size(379, 21)
        Me.Txtemplradrs.TabIndex = 5
        '
        'DtpickLev
        '
        Me.DtpickLev.CustomFormat = "dd/MM/yyyy"
        Me.DtpickLev.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpickLev.Location = New System.Drawing.Point(666, 80)
        Me.DtpickLev.Name = "DtpickLev"
        Me.DtpickLev.Size = New System.Drawing.Size(161, 21)
        Me.DtpickLev.TabIndex = 10
        '
        'TxtemplrName
        '
        Me.TxtemplrName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtemplrName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtemplrName.Location = New System.Drawing.Point(205, 4)
        Me.TxtemplrName.MaxLength = 70
        Me.TxtemplrName.Name = "TxtemplrName"
        Me.TxtemplrName.Size = New System.Drawing.Size(773, 21)
        Me.TxtemplrName.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(-3, -1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 35)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Details of  previous Employer"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(443, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(220, 21)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Previous Pension Fund  Ac. No. :-"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(52, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(146, 18)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Previous PF Ac. No. :-"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(128, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 18)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Address :- "
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(122, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 18)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Whether :- "
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(142, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 18)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Name :- "
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(589, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 18)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Whether :- "
        '
        'CmbxEpfEmpname
        '
        Me.CmbxEpfEmpname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxEpfEmpname.FormattingEnabled = True
        Me.CmbxEpfEmpname.Location = New System.Drawing.Point(212, 7)
        Me.CmbxEpfEmpname.Name = "CmbxEpfEmpname"
        Me.CmbxEpfEmpname.Size = New System.Drawing.Size(525, 21)
        Me.CmbxEpfEmpname.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(70, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 18)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Employee's  Name :-"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(820, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Date :-"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(875, 7)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.Size = New System.Drawing.Size(114, 21)
        Me.Dtpick1.TabIndex = 2
        '
        'CrVewEPFfrm13A
        '
        Me.CrVewEPFfrm13A.ActiveViewIndex = 0
        Me.CrVewEPFfrm13A.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEPFfrm13A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEPFfrm13A.DisplayGroupTree = False
        Me.CrVewEPFfrm13A.Location = New System.Drawing.Point(1, 195)
        Me.CrVewEPFfrm13A.Name = "CrVewEPFfrm13A"
        Me.CrVewEPFfrm13A.ReportSource = Me.CrRptfrm13A1
        Me.CrVewEPFfrm13A.ShowGroupTreeButton = False
        Me.CrVewEPFfrm13A.ShowRefreshButton = False
        Me.CrVewEPFfrm13A.Size = New System.Drawing.Size(1005, 0)
        Me.CrVewEPFfrm13A.TabIndex = 10
        '
        'FrmCrRptForm13A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 193)
        Me.Controls.Add(Me.CrVewEPFfrm13A)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptForm13A"
        Me.Text = "EPF (Form No.13-A)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbxEpfEmpname As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrVewEPFfrm13A As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptfrm13A1 As fINACCT.CrRptfrm13A
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Cmbxemplr As System.Windows.Forms.ComboBox
    Friend WithEvents TxtPensnNo As System.Windows.Forms.TextBox
    Friend WithEvents TxtPfAcNo As System.Windows.Forms.TextBox
    Friend WithEvents Txtemplradrs As System.Windows.Forms.TextBox
    Friend WithEvents TxtemplrName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbxPemplrEpf As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DtpickLev As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnEPF13a As System.Windows.Forms.Button
End Class

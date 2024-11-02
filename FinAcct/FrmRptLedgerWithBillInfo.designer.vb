<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptLedgerWithBillInfo
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
        Me.Gbox1 = New System.Windows.Forms.GroupBox
        Me.RbBoth = New System.Windows.Forms.RadioButton
        Me.RbCr = New System.Windows.Forms.RadioButton
        Me.Rbdr = New System.Windows.Forms.RadioButton
        Me.CmbxLdgr = New System.Windows.Forms.ComboBox
        Me.ChkLdgrAll = New System.Windows.Forms.CheckBox
        Me.ChkRptLdgr = New System.Windows.Forms.CheckBox
        Me.BtnRptVewLdgr = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpLdgr2 = New System.Windows.Forms.DateTimePicker
        Me.DtpLdgr1 = New System.Windows.Forms.DateTimePicker
        Me.CrRptVewLdgr = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptLedgerWithBillInfo1 = New FinAcct.CrRptLedgerWithBillInfo
        Me.Panel1.SuspendLayout()
        Me.Gbox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Gbox1)
        Me.Panel1.Controls.Add(Me.CmbxLdgr)
        Me.Panel1.Controls.Add(Me.ChkLdgrAll)
        Me.Panel1.Controls.Add(Me.ChkRptLdgr)
        Me.Panel1.Controls.Add(Me.BtnRptVewLdgr)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpLdgr2)
        Me.Panel1.Controls.Add(Me.DtpLdgr1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(2, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1006, 59)
        Me.Panel1.TabIndex = 0
        '
        'Gbox1
        '
        Me.Gbox1.Controls.Add(Me.RbBoth)
        Me.Gbox1.Controls.Add(Me.RbCr)
        Me.Gbox1.Controls.Add(Me.Rbdr)
        Me.Gbox1.Location = New System.Drawing.Point(183, -6)
        Me.Gbox1.Name = "Gbox1"
        Me.Gbox1.Size = New System.Drawing.Size(218, 61)
        Me.Gbox1.TabIndex = 2
        Me.Gbox1.TabStop = False
        '
        'RbBoth
        '
        Me.RbBoth.AutoSize = True
        Me.RbBoth.Checked = True
        Me.RbBoth.Location = New System.Drawing.Point(7, 43)
        Me.RbBoth.Name = "RbBoth"
        Me.RbBoth.Size = New System.Drawing.Size(51, 17)
        Me.RbBoth.TabIndex = 5
        Me.RbBoth.TabStop = True
        Me.RbBoth.Text = "Both"
        Me.RbBoth.UseVisualStyleBackColor = True
        '
        'RbCr
        '
        Me.RbCr.AutoSize = True
        Me.RbCr.Location = New System.Drawing.Point(7, 26)
        Me.RbCr.Name = "RbCr"
        Me.RbCr.Size = New System.Drawing.Size(182, 17)
        Me.RbCr.TabIndex = 4
        Me.RbCr.Text = "Having Credit Balance Only"
        Me.RbCr.UseVisualStyleBackColor = True
        '
        'Rbdr
        '
        Me.Rbdr.AutoSize = True
        Me.Rbdr.Location = New System.Drawing.Point(7, 9)
        Me.Rbdr.Name = "Rbdr"
        Me.Rbdr.Size = New System.Drawing.Size(177, 17)
        Me.Rbdr.TabIndex = 3
        Me.Rbdr.Text = "Having Debit Balance Only"
        Me.Rbdr.UseVisualStyleBackColor = True
        '
        'CmbxLdgr
        '
        Me.CmbxLdgr.FormattingEnabled = True
        Me.CmbxLdgr.Location = New System.Drawing.Point(470, 29)
        Me.CmbxLdgr.Name = "CmbxLdgr"
        Me.CmbxLdgr.Size = New System.Drawing.Size(387, 21)
        Me.CmbxLdgr.TabIndex = 8
        '
        'ChkLdgrAll
        '
        Me.ChkLdgrAll.AutoSize = True
        Me.ChkLdgrAll.Checked = True
        Me.ChkLdgrAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkLdgrAll.Location = New System.Drawing.Point(424, 31)
        Me.ChkLdgrAll.Name = "ChkLdgrAll"
        Me.ChkLdgrAll.Size = New System.Drawing.Size(40, 17)
        Me.ChkLdgrAll.TabIndex = 7
        Me.ChkLdgrAll.Text = "All"
        Me.ChkLdgrAll.UseVisualStyleBackColor = True
        '
        'ChkRptLdgr
        '
        Me.ChkRptLdgr.AutoSize = True
        Me.ChkRptLdgr.Checked = True
        Me.ChkRptLdgr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptLdgr.Location = New System.Drawing.Point(424, 2)
        Me.ChkRptLdgr.Name = "ChkRptLdgr"
        Me.ChkRptLdgr.Size = New System.Drawing.Size(211, 17)
        Me.ChkRptLdgr.TabIndex = 6
        Me.ChkRptLdgr.Text = "Company Information Required "
        Me.ChkRptLdgr.UseVisualStyleBackColor = True
        '
        'BtnRptVewLdgr
        '
        Me.BtnRptVewLdgr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRptVewLdgr.BackgroundImage = Global.FinAcct.My.Resources.Resources.btnLarge
        Me.BtnRptVewLdgr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVewLdgr.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVewLdgr.Location = New System.Drawing.Point(863, 12)
        Me.BtnRptVewLdgr.Name = "BtnRptVewLdgr"
        Me.BtnRptVewLdgr.Size = New System.Drawing.Size(134, 33)
        Me.BtnRptVewLdgr.TabIndex = 9
        Me.BtnRptVewLdgr.Text = "Report View"
        Me.BtnRptVewLdgr.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From"
        '
        'DtpLdgr2
        '
        Me.DtpLdgr2.CustomFormat = "dd/MM/yyyy"
        Me.DtpLdgr2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpLdgr2.Location = New System.Drawing.Point(44, 32)
        Me.DtpLdgr2.Name = "DtpLdgr2"
        Me.DtpLdgr2.Size = New System.Drawing.Size(114, 21)
        Me.DtpLdgr2.TabIndex = 1
        '
        'DtpLdgr1
        '
        Me.DtpLdgr1.CustomFormat = "dd/MM/yyyy"
        Me.DtpLdgr1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpLdgr1.Location = New System.Drawing.Point(45, 3)
        Me.DtpLdgr1.Name = "DtpLdgr1"
        Me.DtpLdgr1.Size = New System.Drawing.Size(114, 21)
        Me.DtpLdgr1.TabIndex = 0
        '
        'CrRptVewLdgr
        '
        Me.CrRptVewLdgr.ActiveViewIndex = 0
        Me.CrRptVewLdgr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewLdgr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewLdgr.Location = New System.Drawing.Point(0, 65)
        Me.CrRptVewLdgr.Name = "CrRptVewLdgr"
        Me.CrRptVewLdgr.ReportSource = Me.CrRptLedgerWithBillInfo1
        Me.CrRptVewLdgr.ShowRefreshButton = False
        Me.CrRptVewLdgr.Size = New System.Drawing.Size(1010, 0)
        Me.CrRptVewLdgr.TabIndex = 1
        '
        'FrmRptLedgerWithBillInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1009, 62)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrRptVewLdgr)
        Me.Name = "FrmRptLedgerWithBillInfo"
        Me.Text = "Report Customer/Vendor(Supplier) Ledger With Bill Details"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Gbox1.ResumeLayout(False)
        Me.Gbox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptVewLdgr As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbxLdgr As System.Windows.Forms.ComboBox
    Friend WithEvents ChkLdgrAll As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRptLdgr As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRptVewLdgr As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpLdgr2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpLdgr1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Gbox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rbdr As System.Windows.Forms.RadioButton
    Friend WithEvents RbBoth As System.Windows.Forms.RadioButton
    Friend WithEvents RbCr As System.Windows.Forms.RadioButton
    Friend WithEvents CrRptLedgerWithBillInfo1 As FinAcct.CrRptLedgerWithBillInfo
End Class

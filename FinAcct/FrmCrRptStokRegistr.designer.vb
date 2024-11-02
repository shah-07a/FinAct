<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptStokRegistr
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
        Me.CmbxAct = New System.Windows.Forms.ComboBox
        Me.ChkAllac = New System.Windows.Forms.CheckBox
        Me.ChkOpnBal = New System.Windows.Forms.CheckBox
        Me.CmbxLdgr = New System.Windows.Forms.ComboBox
        Me.ChkLdgrAll = New System.Windows.Forms.CheckBox
        Me.ChkRptLdgr = New System.Windows.Forms.CheckBox
        Me.BtnRptVewLdgr = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpLdgr2 = New System.Windows.Forms.DateTimePicker
        Me.DtpLdgr1 = New System.Windows.Forms.DateTimePicker
        Me.CrRptVewLdgr = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptStockRegistr1 = New FinAcct.CrRptStockRegistr
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CmbxAct)
        Me.Panel1.Controls.Add(Me.ChkAllac)
        Me.Panel1.Controls.Add(Me.ChkOpnBal)
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
        'CmbxAct
        '
        Me.CmbxAct.Enabled = False
        Me.CmbxAct.FormattingEnabled = True
        Me.CmbxAct.Location = New System.Drawing.Point(266, 7)
        Me.CmbxAct.Name = "CmbxAct"
        Me.CmbxAct.Size = New System.Drawing.Size(341, 21)
        Me.CmbxAct.TabIndex = 3
        '
        'ChkAllac
        '
        Me.ChkAllac.AutoSize = True
        Me.ChkAllac.Checked = True
        Me.ChkAllac.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAllac.Location = New System.Drawing.Point(183, 8)
        Me.ChkAllac.Name = "ChkAllac"
        Me.ChkAllac.Size = New System.Drawing.Size(74, 17)
        Me.ChkAllac.TabIndex = 2
        Me.ChkAllac.Text = "All Party"
        Me.ChkAllac.UseVisualStyleBackColor = True
        '
        'ChkOpnBal
        '
        Me.ChkOpnBal.AutoSize = True
        Me.ChkOpnBal.Checked = True
        Me.ChkOpnBal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkOpnBal.Location = New System.Drawing.Point(623, 33)
        Me.ChkOpnBal.Name = "ChkOpnBal"
        Me.ChkOpnBal.Size = New System.Drawing.Size(179, 17)
        Me.ChkOpnBal.TabIndex = 7
        Me.ChkOpnBal.Text = "Opening Balance Included."
        Me.ChkOpnBal.UseVisualStyleBackColor = True
        '
        'CmbxLdgr
        '
        Me.CmbxLdgr.Enabled = False
        Me.CmbxLdgr.FormattingEnabled = True
        Me.CmbxLdgr.Location = New System.Drawing.Point(266, 32)
        Me.CmbxLdgr.Name = "CmbxLdgr"
        Me.CmbxLdgr.Size = New System.Drawing.Size(341, 21)
        Me.CmbxLdgr.TabIndex = 5
        '
        'ChkLdgrAll
        '
        Me.ChkLdgrAll.AutoSize = True
        Me.ChkLdgrAll.Checked = True
        Me.ChkLdgrAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkLdgrAll.Location = New System.Drawing.Point(183, 34)
        Me.ChkLdgrAll.Name = "ChkLdgrAll"
        Me.ChkLdgrAll.Size = New System.Drawing.Size(77, 17)
        Me.ChkLdgrAll.TabIndex = 4
        Me.ChkLdgrAll.Text = "All Items"
        Me.ChkLdgrAll.UseVisualStyleBackColor = True
        '
        'ChkRptLdgr
        '
        Me.ChkRptLdgr.AutoSize = True
        Me.ChkRptLdgr.Checked = True
        Me.ChkRptLdgr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptLdgr.Location = New System.Drawing.Point(623, 8)
        Me.ChkRptLdgr.Name = "ChkRptLdgr"
        Me.ChkRptLdgr.Size = New System.Drawing.Size(211, 17)
        Me.ChkRptLdgr.TabIndex = 6
        Me.ChkRptLdgr.Text = "Company Information Required "
        Me.ChkRptLdgr.UseVisualStyleBackColor = True
        '
        'BtnRptVewLdgr
        '
        Me.BtnRptVewLdgr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRptVewLdgr.BackgroundImage = Global.FinAcct.My.Resources.Resources.METALC2A
        Me.BtnRptVewLdgr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRptVewLdgr.FlatAppearance.BorderSize = 0
        Me.BtnRptVewLdgr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnRptVewLdgr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVewLdgr.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVewLdgr.Location = New System.Drawing.Point(863, 12)
        Me.BtnRptVewLdgr.Name = "BtnRptVewLdgr"
        Me.BtnRptVewLdgr.Size = New System.Drawing.Size(134, 33)
        Me.BtnRptVewLdgr.TabIndex = 8
        Me.BtnRptVewLdgr.Text = "&View Report"
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
        Me.CrRptVewLdgr.ReportSource = Me.CrRptStockRegistr1
        Me.CrRptVewLdgr.ShowRefreshButton = False
        Me.CrRptVewLdgr.Size = New System.Drawing.Size(1010, 2)
        Me.CrRptVewLdgr.TabIndex = 1
        '
        'FrmCrRptStokRegistr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1009, 62)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrRptVewLdgr)
        Me.Name = "FrmCrRptStokRegistr"
        Me.Text = "Report Of Raw Materials (Detailed)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents CrRptStockRegistr1 As FinAcct.CrRptStockRegistr
    Friend WithEvents CmbxAct As System.Windows.Forms.ComboBox
    Friend WithEvents ChkAllac As System.Windows.Forms.CheckBox
    Friend WithEvents ChkOpnBal As System.Windows.Forms.CheckBox
End Class

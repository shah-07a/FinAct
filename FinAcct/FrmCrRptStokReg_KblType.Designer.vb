<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptStokReg_KblType
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CmbxItms = New System.Windows.Forms.ComboBox
        Me.ChkBxAll = New System.Windows.Forms.CheckBox
        Me.BtnRptVewLdgr = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpLdgr2 = New System.Windows.Forms.DateTimePicker
        Me.DtpLdgr1 = New System.Windows.Forms.DateTimePicker
        Me.CrRptVewStokReg = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptItmStokReg_KBL_Type1 = New FinAcct.CrRptItmStokReg_KBL_Type
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CmbxItms)
        Me.Panel1.Controls.Add(Me.ChkBxAll)
        Me.Panel1.Controls.Add(Me.BtnRptVewLdgr)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpLdgr2)
        Me.Panel1.Controls.Add(Me.DtpLdgr1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(881, 61)
        Me.Panel1.TabIndex = 0
        '
        'CmbxItms
        '
        Me.CmbxItms.Enabled = False
        Me.CmbxItms.FormattingEnabled = True
        Me.CmbxItms.Location = New System.Drawing.Point(272, 20)
        Me.CmbxItms.Name = "CmbxItms"
        Me.CmbxItms.Size = New System.Drawing.Size(442, 21)
        Me.CmbxItms.TabIndex = 8
        '
        'ChkBxAll
        '
        Me.ChkBxAll.AutoSize = True
        Me.ChkBxAll.Checked = True
        Me.ChkBxAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBxAll.Location = New System.Drawing.Point(180, 20)
        Me.ChkBxAll.Name = "ChkBxAll"
        Me.ChkBxAll.Size = New System.Drawing.Size(86, 17)
        Me.ChkBxAll.TabIndex = 7
        Me.ChkBxAll.Text = "ALL ITEMS"
        Me.ChkBxAll.UseVisualStyleBackColor = True
        '
        'BtnRptVewLdgr
        '
        Me.BtnRptVewLdgr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRptVewLdgr.BackgroundImage = Global.FinAcct.My.Resources.Resources.METALC8B
        Me.BtnRptVewLdgr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRptVewLdgr.FlatAppearance.BorderSize = 0
        Me.BtnRptVewLdgr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnRptVewLdgr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVewLdgr.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVewLdgr.Location = New System.Drawing.Point(742, 13)
        Me.BtnRptVewLdgr.Name = "BtnRptVewLdgr"
        Me.BtnRptVewLdgr.Size = New System.Drawing.Size(130, 33)
        Me.BtnRptVewLdgr.TabIndex = 9
        Me.BtnRptVewLdgr.Text = "&View Report"
        Me.BtnRptVewLdgr.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 30)
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
        Me.DtpLdgr2.Enabled = False
        Me.DtpLdgr2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpLdgr2.Location = New System.Drawing.Point(45, 30)
        Me.DtpLdgr2.Name = "DtpLdgr2"
        Me.DtpLdgr2.Size = New System.Drawing.Size(114, 21)
        Me.DtpLdgr2.TabIndex = 2
        '
        'DtpLdgr1
        '
        Me.DtpLdgr1.CustomFormat = "dd/MM/yyyy"
        Me.DtpLdgr1.Enabled = False
        Me.DtpLdgr1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpLdgr1.Location = New System.Drawing.Point(45, 3)
        Me.DtpLdgr1.Name = "DtpLdgr1"
        Me.DtpLdgr1.Size = New System.Drawing.Size(114, 21)
        Me.DtpLdgr1.TabIndex = 1
        '
        'CrRptVewStokReg
        '
        Me.CrRptVewStokReg.ActiveViewIndex = 0
        Me.CrRptVewStokReg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewStokReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewStokReg.Location = New System.Drawing.Point(1, 71)
        Me.CrRptVewStokReg.Name = "CrRptVewStokReg"
        Me.CrRptVewStokReg.ReportSource = Me.CrRptItmStokReg_KBL_Type1
        Me.CrRptVewStokReg.ShowRefreshButton = False
        Me.CrRptVewStokReg.Size = New System.Drawing.Size(881, 0)
        Me.CrRptVewStokReg.TabIndex = 1
        '
        'FrmCrRptStokReg_KblType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(884, 71)
        Me.Controls.Add(Me.CrRptVewStokReg)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(890, 99)
        Me.Name = "FrmCrRptStokReg_KblType"
        Me.Text = "STOCK REGISTER"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnRptVewLdgr As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpLdgr2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpLdgr1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbxItms As System.Windows.Forms.ComboBox
    Friend WithEvents ChkBxAll As System.Windows.Forms.CheckBox
    Friend WithEvents CrRptVewStokReg As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptItmStokReg_KBL_Type1 As FinAcct.CrRptItmStokReg_KBL_Type
End Class

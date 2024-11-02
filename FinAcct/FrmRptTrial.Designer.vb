<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptTrial
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbd = New System.Windows.Forms.RadioButton
        Me.rbg = New System.Windows.Forms.RadioButton
        Me.rbs = New System.Windows.Forms.RadioButton
        Me.ChkRptLdgr = New System.Windows.Forms.CheckBox
        Me.BtnRptVewLdgr = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpLdgr2 = New System.Windows.Forms.DateTimePicker
        Me.DtpLdgr1 = New System.Windows.Forms.DateTimePicker
        Me.CrRptVewTrialBal = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptTrial1 = New FinAcct.CrRptTrial
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.ChkRptLdgr)
        Me.Panel1.Controls.Add(Me.BtnRptVewLdgr)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpLdgr2)
        Me.Panel1.Controls.Add(Me.DtpLdgr1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(593, 59)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbd)
        Me.GroupBox1.Controls.Add(Me.rbg)
        Me.GroupBox1.Controls.Add(Me.rbs)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(165, -7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 63)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'rbd
        '
        Me.rbd.AutoSize = True
        Me.rbd.Location = New System.Drawing.Point(6, 9)
        Me.rbd.Name = "rbd"
        Me.rbd.Size = New System.Drawing.Size(72, 17)
        Me.rbd.TabIndex = 3
        Me.rbd.Text = "Detailed"
        Me.rbd.UseVisualStyleBackColor = True
        '
        'rbg
        '
        Me.rbg.AutoSize = True
        Me.rbg.Checked = True
        Me.rbg.Location = New System.Drawing.Point(6, 27)
        Me.rbg.Name = "rbg"
        Me.rbg.Size = New System.Drawing.Size(163, 17)
        Me.rbg.TabIndex = 4
        Me.rbg.TabStop = True
        Me.rbg.Text = "Group Wise With Details"
        Me.rbg.UseVisualStyleBackColor = True
        '
        'rbs
        '
        Me.rbs.AutoSize = True
        Me.rbs.Location = New System.Drawing.Point(6, 44)
        Me.rbs.Name = "rbs"
        Me.rbs.Size = New System.Drawing.Size(171, 17)
        Me.rbs.TabIndex = 5
        Me.rbs.Text = "Summarized Group  Wise"
        Me.rbs.UseVisualStyleBackColor = True
        '
        'ChkRptLdgr
        '
        Me.ChkRptLdgr.AutoSize = True
        Me.ChkRptLdgr.Checked = True
        Me.ChkRptLdgr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptLdgr.Location = New System.Drawing.Point(401, 20)
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
        Me.BtnRptVewLdgr.Location = New System.Drawing.Point(445, 12)
        Me.BtnRptVewLdgr.Name = "BtnRptVewLdgr"
        Me.BtnRptVewLdgr.Size = New System.Drawing.Size(132, 33)
        Me.BtnRptVewLdgr.TabIndex = 7
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
        'CrRptVewTrialBal
        '
        Me.CrRptVewTrialBal.ActiveViewIndex = 0
        Me.CrRptVewTrialBal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewTrialBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewTrialBal.Location = New System.Drawing.Point(1, 66)
        Me.CrRptVewTrialBal.Name = "CrRptVewTrialBal"
        Me.CrRptVewTrialBal.ReportSource = Me.CrRptTrial1
        Me.CrRptVewTrialBal.Size = New System.Drawing.Size(593, 16)
        Me.CrRptVewTrialBal.TabIndex = 0
        '
        'FrmRptTrial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(884, 59)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrRptVewTrialBal)
        Me.Name = "FrmRptTrial"
        Me.Text = "Trial Balance"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptVewTrialBal As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptTrial1 As FinAcct.CrRptTrial
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnRptVewLdgr As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpLdgr2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpLdgr1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkRptLdgr As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbd As System.Windows.Forms.RadioButton
    Friend WithEvents rbg As System.Windows.Forms.RadioButton
    Friend WithEvents rbs As System.Windows.Forms.RadioButton
End Class

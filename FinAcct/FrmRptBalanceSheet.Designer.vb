<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptBalanceSheet
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
        Me.CrRptVewBalSheet = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Txtvalue = New System.Windows.Forms.TextBox
        Me.lblvalue = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbd = New System.Windows.Forms.RadioButton
        Me.rbg = New System.Windows.Forms.RadioButton
        Me.ChkRptLdgr = New System.Windows.Forms.CheckBox
        Me.BtnRptVewLdgr = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpLdgr2 = New System.Windows.Forms.DateTimePicker
        Me.DtpLdgr1 = New System.Windows.Forms.DateTimePicker
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrRptVewBalSheet
        '
        Me.CrRptVewBalSheet.ActiveViewIndex = -1
        Me.CrRptVewBalSheet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewBalSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewBalSheet.DisplayGroupTree = False
        Me.CrRptVewBalSheet.Location = New System.Drawing.Point(1, 65)
        Me.CrRptVewBalSheet.Name = "CrRptVewBalSheet"
        Me.CrRptVewBalSheet.SelectionFormula = ""
        Me.CrRptVewBalSheet.Size = New System.Drawing.Size(1007, 0)
        Me.CrRptVewBalSheet.TabIndex = 0
        Me.CrRptVewBalSheet.ViewTimeSelectionFormula = ""
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Txtvalue)
        Me.Panel1.Controls.Add(Me.lblvalue)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.ChkRptLdgr)
        Me.Panel1.Controls.Add(Me.BtnRptVewLdgr)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpLdgr2)
        Me.Panel1.Controls.Add(Me.DtpLdgr1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1007, 59)
        Me.Panel1.TabIndex = 1
        '
        'Txtvalue
        '
        Me.Txtvalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtvalue.Location = New System.Drawing.Point(328, 23)
        Me.Txtvalue.Name = "Txtvalue"
        Me.Txtvalue.Size = New System.Drawing.Size(135, 21)
        Me.Txtvalue.TabIndex = 5
        Me.Txtvalue.Text = "0"
        Me.Txtvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblvalue
        '
        Me.lblvalue.AutoSize = True
        Me.lblvalue.Location = New System.Drawing.Point(325, 7)
        Me.lblvalue.Name = "lblvalue"
        Me.lblvalue.Size = New System.Drawing.Size(121, 13)
        Me.lblvalue.TabIndex = 8
        Me.lblvalue.Text = "Rate Of Gross Profit"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbd)
        Me.GroupBox1.Controls.Add(Me.rbg)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(166, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(154, 53)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Method Of Calculation "
        '
        'rbd
        '
        Me.rbd.AutoSize = True
        Me.rbd.Checked = True
        Me.rbd.Location = New System.Drawing.Point(6, 15)
        Me.rbd.Name = "rbd"
        Me.rbd.Size = New System.Drawing.Size(71, 17)
        Me.rbd.TabIndex = 3
        Me.rbd.TabStop = True
        Me.rbd.Text = "GP Rate"
        Me.rbd.UseVisualStyleBackColor = True
        '
        'rbg
        '
        Me.rbg.AutoSize = True
        Me.rbg.Location = New System.Drawing.Point(6, 33)
        Me.rbg.Name = "rbg"
        Me.rbg.Size = New System.Drawing.Size(103, 17)
        Me.rbg.TabIndex = 4
        Me.rbg.TabStop = True
        Me.rbg.Text = "Closing Stock"
        Me.rbg.UseVisualStyleBackColor = True
        '
        'ChkRptLdgr
        '
        Me.ChkRptLdgr.AutoSize = True
        Me.ChkRptLdgr.Checked = True
        Me.ChkRptLdgr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptLdgr.Location = New System.Drawing.Point(489, 21)
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
        Me.BtnRptVewLdgr.Location = New System.Drawing.Point(734, 12)
        Me.BtnRptVewLdgr.Name = "BtnRptVewLdgr"
        Me.BtnRptVewLdgr.Size = New System.Drawing.Size(257, 33)
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
        'FrmRptBalanceSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1009, 65)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrRptVewBalSheet)
        Me.Name = "FrmRptBalanceSheet"
        Me.Text = "FrmRptBalanceSheet"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptVewBalSheet As CrystalDecisions.Windows.Forms.CrystalReportViewer

    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Txtvalue As System.Windows.Forms.TextBox
    Friend WithEvents lblvalue As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbd As System.Windows.Forms.RadioButton
    Friend WithEvents rbg As System.Windows.Forms.RadioButton
    Friend WithEvents ChkRptLdgr As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRptVewLdgr As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpLdgr2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpLdgr1 As System.Windows.Forms.DateTimePicker
End Class

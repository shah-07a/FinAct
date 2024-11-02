<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRpt_KBL_SaleBillPrinting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCrRpt_KBL_SaleBillPrinting))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ChkbxPaytrm = New System.Windows.Forms.CheckBox
        Me.GrpBxPrntOpn1 = New System.Windows.Forms.GroupBox
        Me.Rbset3 = New System.Windows.Forms.RadioButton
        Me.Rbset4 = New System.Windows.Forms.RadioButton
        Me.Rbset5 = New System.Windows.Forms.RadioButton
        Me.GrpBxPrntOptn = New System.Windows.Forms.GroupBox
        Me.Rbfab = New System.Windows.Forms.RadioButton
        Me.RbMach = New System.Windows.Forms.RadioButton
        Me.BtnPrnt = New System.Windows.Forms.Button
        Me.CmbxLdgr = New System.Windows.Forms.ComboBox
        Me.BtnRptVewLdgr = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpLdgr2 = New System.Windows.Forms.DateTimePicker
        Me.DtpLdgr1 = New System.Windows.Forms.DateTimePicker
        Me.CrRptVewSaleBill = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRpt_KBL_SaleBillMech1 = New FinAcct.CrRpt_KBL_SaleBillMech
        Me.CrRpt_KBL_SaleBill1 = New FinAcct.CrRpt_KBL_SaleBill
        Me.Panel1.SuspendLayout()
        Me.GrpBxPrntOpn1.SuspendLayout()
        Me.GrpBxPrntOptn.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ChkbxPaytrm)
        Me.Panel1.Controls.Add(Me.GrpBxPrntOpn1)
        Me.Panel1.Controls.Add(Me.GrpBxPrntOptn)
        Me.Panel1.Controls.Add(Me.BtnPrnt)
        Me.Panel1.Controls.Add(Me.CmbxLdgr)
        Me.Panel1.Controls.Add(Me.BtnRptVewLdgr)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpLdgr2)
        Me.Panel1.Controls.Add(Me.DtpLdgr1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(881, 59)
        Me.Panel1.TabIndex = 2
        '
        'ChkbxPaytrm
        '
        Me.ChkbxPaytrm.AutoSize = True
        Me.ChkbxPaytrm.Checked = True
        Me.ChkbxPaytrm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkbxPaytrm.Location = New System.Drawing.Point(329, 37)
        Me.ChkbxPaytrm.Name = "ChkbxPaytrm"
        Me.ChkbxPaytrm.Size = New System.Drawing.Size(186, 17)
        Me.ChkbxPaytrm.TabIndex = 9
        Me.ChkbxPaytrm.Text = "Is Payment Term Required?"
        Me.ChkbxPaytrm.UseVisualStyleBackColor = True
        '
        'GrpBxPrntOpn1
        '
        Me.GrpBxPrntOpn1.Controls.Add(Me.Rbset3)
        Me.GrpBxPrntOpn1.Controls.Add(Me.Rbset4)
        Me.GrpBxPrntOpn1.Controls.Add(Me.Rbset5)
        Me.GrpBxPrntOpn1.Location = New System.Drawing.Point(153, -6)
        Me.GrpBxPrntOpn1.Name = "GrpBxPrntOpn1"
        Me.GrpBxPrntOpn1.Size = New System.Drawing.Size(106, 62)
        Me.GrpBxPrntOpn1.TabIndex = 8
        Me.GrpBxPrntOpn1.TabStop = False
        '
        'Rbset3
        '
        Me.Rbset3.AutoSize = True
        Me.Rbset3.Location = New System.Drawing.Point(6, 43)
        Me.Rbset3.Name = "Rbset3"
        Me.Rbset3.Size = New System.Drawing.Size(72, 17)
        Me.Rbset3.TabIndex = 0
        Me.Rbset3.Text = "Set Of 3"
        Me.Rbset3.UseVisualStyleBackColor = True
        '
        'Rbset4
        '
        Me.Rbset4.AutoSize = True
        Me.Rbset4.Location = New System.Drawing.Point(6, 26)
        Me.Rbset4.Name = "Rbset4"
        Me.Rbset4.Size = New System.Drawing.Size(72, 17)
        Me.Rbset4.TabIndex = 0
        Me.Rbset4.Text = "Set Of 4"
        Me.Rbset4.UseVisualStyleBackColor = True
        '
        'Rbset5
        '
        Me.Rbset5.AutoSize = True
        Me.Rbset5.Checked = True
        Me.Rbset5.Location = New System.Drawing.Point(6, 9)
        Me.Rbset5.Name = "Rbset5"
        Me.Rbset5.Size = New System.Drawing.Size(76, 17)
        Me.Rbset5.TabIndex = 0
        Me.Rbset5.TabStop = True
        Me.Rbset5.Text = "Set Of 5 "
        Me.Rbset5.UseVisualStyleBackColor = True
        '
        'GrpBxPrntOptn
        '
        Me.GrpBxPrntOptn.Controls.Add(Me.Rbfab)
        Me.GrpBxPrntOptn.Controls.Add(Me.RbMach)
        Me.GrpBxPrntOptn.Location = New System.Drawing.Point(4, -6)
        Me.GrpBxPrntOptn.Name = "GrpBxPrntOptn"
        Me.GrpBxPrntOptn.Size = New System.Drawing.Size(133, 60)
        Me.GrpBxPrntOptn.TabIndex = 7
        Me.GrpBxPrntOptn.TabStop = False
        '
        'Rbfab
        '
        Me.Rbfab.AutoSize = True
        Me.Rbfab.Checked = True
        Me.Rbfab.Location = New System.Drawing.Point(6, 11)
        Me.Rbfab.Name = "Rbfab"
        Me.Rbfab.Size = New System.Drawing.Size(99, 17)
        Me.Rbfab.TabIndex = 2
        Me.Rbfab.TabStop = True
        Me.Rbfab.Text = "Fabrics Mode"
        Me.Rbfab.UseVisualStyleBackColor = True
        '
        'RbMach
        '
        Me.RbMach.AutoSize = True
        Me.RbMach.Location = New System.Drawing.Point(6, 38)
        Me.RbMach.Name = "RbMach"
        Me.RbMach.Size = New System.Drawing.Size(117, 17)
        Me.RbMach.TabIndex = 3
        Me.RbMach.Text = "Machinery Mode"
        Me.RbMach.UseVisualStyleBackColor = True
        '
        'BtnPrnt
        '
        Me.BtnPrnt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrnt.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrnt.BackgroundImage = CType(resources.GetObject("BtnPrnt.BackgroundImage"), System.Drawing.Image)
        Me.BtnPrnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrnt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPrnt.Enabled = False
        Me.BtnPrnt.FlatAppearance.BorderSize = 0
        Me.BtnPrnt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnPrnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrnt.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrnt.Location = New System.Drawing.Point(751, 13)
        Me.BtnPrnt.Name = "BtnPrnt"
        Me.BtnPrnt.Size = New System.Drawing.Size(119, 33)
        Me.BtnPrnt.TabIndex = 6
        Me.BtnPrnt.Text = "&Print A Set"
        Me.BtnPrnt.UseVisualStyleBackColor = False
        '
        'CmbxLdgr
        '
        Me.CmbxLdgr.FormattingEnabled = True
        Me.CmbxLdgr.Location = New System.Drawing.Point(329, 6)
        Me.CmbxLdgr.Name = "CmbxLdgr"
        Me.CmbxLdgr.Size = New System.Drawing.Size(109, 21)
        Me.CmbxLdgr.TabIndex = 4
        '
        'BtnRptVewLdgr
        '
        Me.BtnRptVewLdgr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRptVewLdgr.BackColor = System.Drawing.Color.Transparent
        Me.BtnRptVewLdgr.BackgroundImage = CType(resources.GetObject("BtnRptVewLdgr.BackgroundImage"), System.Drawing.Image)
        Me.BtnRptVewLdgr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRptVewLdgr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRptVewLdgr.FlatAppearance.BorderSize = 0
        Me.BtnRptVewLdgr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnRptVewLdgr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVewLdgr.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVewLdgr.Location = New System.Drawing.Point(626, 13)
        Me.BtnRptVewLdgr.Name = "BtnRptVewLdgr"
        Me.BtnRptVewLdgr.Size = New System.Drawing.Size(119, 33)
        Me.BtnRptVewLdgr.TabIndex = 5
        Me.BtnRptVewLdgr.Text = "Report View"
        Me.BtnRptVewLdgr.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(265, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Bill No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(570, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(482, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From"
        Me.Label1.Visible = False
        '
        'DtpLdgr2
        '
        Me.DtpLdgr2.CustomFormat = "dd/MM/yyyy"
        Me.DtpLdgr2.Enabled = False
        Me.DtpLdgr2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpLdgr2.Location = New System.Drawing.Point(614, 1)
        Me.DtpLdgr2.Name = "DtpLdgr2"
        Me.DtpLdgr2.Size = New System.Drawing.Size(32, 21)
        Me.DtpLdgr2.TabIndex = 1
        Me.DtpLdgr2.Visible = False
        '
        'DtpLdgr1
        '
        Me.DtpLdgr1.CustomFormat = "dd/MM/yyyy"
        Me.DtpLdgr1.Enabled = False
        Me.DtpLdgr1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpLdgr1.Location = New System.Drawing.Point(524, 1)
        Me.DtpLdgr1.Name = "DtpLdgr1"
        Me.DtpLdgr1.Size = New System.Drawing.Size(31, 21)
        Me.DtpLdgr1.TabIndex = 0
        Me.DtpLdgr1.Visible = False
        '
        'CrRptVewSaleBill
        '
        Me.CrRptVewSaleBill.ActiveViewIndex = 0
        Me.CrRptVewSaleBill.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewSaleBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewSaleBill.Location = New System.Drawing.Point(1, 67)
        Me.CrRptVewSaleBill.Name = "CrRptVewSaleBill"
        Me.CrRptVewSaleBill.ReportSource = Me.CrRpt_KBL_SaleBillMech1
        Me.CrRptVewSaleBill.ShowRefreshButton = False
        Me.CrRptVewSaleBill.Size = New System.Drawing.Size(881, 1)
        Me.CrRptVewSaleBill.TabIndex = 3
        '
        'FrmCrRpt_KBL_SaleBillPrinting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(884, 63)
        Me.Controls.Add(Me.CrRptVewSaleBill)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRpt_KBL_SaleBillPrinting"
        Me.Text = "Sale Bill Printing..................."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GrpBxPrntOpn1.ResumeLayout(False)
        Me.GrpBxPrntOpn1.PerformLayout()
        Me.GrpBxPrntOptn.ResumeLayout(False)
        Me.GrpBxPrntOptn.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbxLdgr As System.Windows.Forms.ComboBox
    Friend WithEvents BtnRptVewLdgr As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpLdgr2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpLdgr1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrRptVewSaleBill As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CrRpt_KBL_SaleBill1 As FinAcct.CrRpt_KBL_SaleBill
    Friend WithEvents RbMach As System.Windows.Forms.RadioButton
    Friend WithEvents Rbfab As System.Windows.Forms.RadioButton
    Friend WithEvents CrRpt_KBL_SaleBillMech1 As FinAcct.CrRpt_KBL_SaleBillMech
    Friend WithEvents BtnPrnt As System.Windows.Forms.Button
    Friend WithEvents GrpBxPrntOptn As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBxPrntOpn1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rbset3 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbset4 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbset5 As System.Windows.Forms.RadioButton
    Friend WithEvents ChkbxPaytrm As System.Windows.Forms.CheckBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptPurRegstr
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.ChkBxTaxCat = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbxTaxCat = New System.Windows.Forms.ComboBox
        Me.CmbxLdgr = New System.Windows.Forms.ComboBox
        Me.ChkLdgrAll = New System.Windows.Forms.CheckBox
        Me.ChkRptLdgr = New System.Windows.Forms.CheckBox
        Me.BtnRptVewLdgr = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpLdgr2 = New System.Windows.Forms.DateTimePicker
        Me.DtpLdgr1 = New System.Windows.Forms.DateTimePicker
        Me.CrRptVewPurRegstr = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptPurRegstr1 = New FinAcct.CrRptPurRegstr
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.ChkBxTaxCat)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.CmbxTaxCat)
        Me.Panel1.Controls.Add(Me.CmbxLdgr)
        Me.Panel1.Controls.Add(Me.ChkLdgrAll)
        Me.Panel1.Controls.Add(Me.ChkRptLdgr)
        Me.Panel1.Controls.Add(Me.BtnRptVewLdgr)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpLdgr2)
        Me.Panel1.Controls.Add(Me.DtpLdgr1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1006, 84)
        Me.Panel1.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(250, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Customer"
        '
        'ChkBxTaxCat
        '
        Me.ChkBxTaxCat.AutoSize = True
        Me.ChkBxTaxCat.Checked = True
        Me.ChkBxTaxCat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBxTaxCat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBxTaxCat.Location = New System.Drawing.Point(333, 28)
        Me.ChkBxTaxCat.Name = "ChkBxTaxCat"
        Me.ChkBxTaxCat.Size = New System.Drawing.Size(43, 17)
        Me.ChkBxTaxCat.TabIndex = 11
        Me.ChkBxTaxCat.Text = "All"
        Me.ChkBxTaxCat.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(219, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Tax Category"
        '
        'CmbxTaxCat
        '
        Me.CmbxTaxCat.Enabled = False
        Me.CmbxTaxCat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxTaxCat.FormattingEnabled = True
        Me.CmbxTaxCat.Location = New System.Drawing.Point(381, 28)
        Me.CmbxTaxCat.Name = "CmbxTaxCat"
        Me.CmbxTaxCat.Size = New System.Drawing.Size(389, 21)
        Me.CmbxTaxCat.TabIndex = 12
        '
        'CmbxLdgr
        '
        Me.CmbxLdgr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxLdgr.FormattingEnabled = True
        Me.CmbxLdgr.Location = New System.Drawing.Point(381, 54)
        Me.CmbxLdgr.Name = "CmbxLdgr"
        Me.CmbxLdgr.Size = New System.Drawing.Size(387, 21)
        Me.CmbxLdgr.TabIndex = 4
        '
        'ChkLdgrAll
        '
        Me.ChkLdgrAll.AutoSize = True
        Me.ChkLdgrAll.Checked = True
        Me.ChkLdgrAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkLdgrAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkLdgrAll.Location = New System.Drawing.Point(333, 54)
        Me.ChkLdgrAll.Name = "ChkLdgrAll"
        Me.ChkLdgrAll.Size = New System.Drawing.Size(43, 17)
        Me.ChkLdgrAll.TabIndex = 3
        Me.ChkLdgrAll.Text = "All"
        Me.ChkLdgrAll.UseVisualStyleBackColor = True
        '
        'ChkRptLdgr
        '
        Me.ChkRptLdgr.AutoSize = True
        Me.ChkRptLdgr.Checked = True
        Me.ChkRptLdgr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptLdgr.Location = New System.Drawing.Point(333, 3)
        Me.ChkRptLdgr.Name = "ChkRptLdgr"
        Me.ChkRptLdgr.Size = New System.Drawing.Size(258, 20)
        Me.ChkRptLdgr.TabIndex = 2
        Me.ChkRptLdgr.Text = "Company Information Required "
        Me.ChkRptLdgr.UseVisualStyleBackColor = True
        '
        'BtnRptVewLdgr
        '
        Me.BtnRptVewLdgr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRptVewLdgr.BackColor = System.Drawing.Color.Transparent
        Me.BtnRptVewLdgr.BackgroundImage = Global.FinAcct.My.Resources.Resources.EMB_R4C
        Me.BtnRptVewLdgr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRptVewLdgr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRptVewLdgr.FlatAppearance.BorderSize = 0
        Me.BtnRptVewLdgr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnRptVewLdgr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVewLdgr.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVewLdgr.ForeColor = System.Drawing.Color.Navy
        Me.BtnRptVewLdgr.Location = New System.Drawing.Point(860, 28)
        Me.BtnRptVewLdgr.Name = "BtnRptVewLdgr"
        Me.BtnRptVewLdgr.Size = New System.Drawing.Size(134, 33)
        Me.BtnRptVewLdgr.TabIndex = 5
        Me.BtnRptVewLdgr.Text = "Report View"
        Me.BtnRptVewLdgr.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From"
        '
        'DtpLdgr2
        '
        Me.DtpLdgr2.CustomFormat = "dd/MM/yyyy"
        Me.DtpLdgr2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpLdgr2.Location = New System.Drawing.Point(53, 54)
        Me.DtpLdgr2.Name = "DtpLdgr2"
        Me.DtpLdgr2.Size = New System.Drawing.Size(130, 23)
        Me.DtpLdgr2.TabIndex = 1
        '
        'DtpLdgr1
        '
        Me.DtpLdgr1.CustomFormat = "dd/MM/yyyy"
        Me.DtpLdgr1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpLdgr1.Location = New System.Drawing.Point(54, 3)
        Me.DtpLdgr1.Name = "DtpLdgr1"
        Me.DtpLdgr1.Size = New System.Drawing.Size(130, 23)
        Me.DtpLdgr1.TabIndex = 0
        '
        'CrRptVewPurRegstr
        '
        Me.CrRptVewPurRegstr.ActiveViewIndex = 0
        Me.CrRptVewPurRegstr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewPurRegstr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewPurRegstr.DisplayGroupTree = False
        Me.CrRptVewPurRegstr.Location = New System.Drawing.Point(2, 91)
        Me.CrRptVewPurRegstr.Name = "CrRptVewPurRegstr"
        Me.CrRptVewPurRegstr.ReportSource = Me.CrRptPurRegstr1
        Me.CrRptVewPurRegstr.ShowGroupTreeButton = False
        Me.CrRptVewPurRegstr.ShowRefreshButton = False
        Me.CrRptVewPurRegstr.Size = New System.Drawing.Size(1006, 2)
        Me.CrRptVewPurRegstr.TabIndex = 3
        '
        'FrmCrRptPurRegstr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.SpringGreen
        Me.ClientSize = New System.Drawing.Size(1009, 86)
        Me.Controls.Add(Me.CrRptVewPurRegstr)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmCrRptPurRegstr"
        Me.Text = "Report Of Purchase Register"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbxLdgr As System.Windows.Forms.ComboBox
    Friend WithEvents ChkLdgrAll As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRptLdgr As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRptVewLdgr As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpLdgr2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpLdgr1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrRptVewPurRegstr As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptPurRegstr1 As FinAcct.CrRptPurRegstr
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChkBxTaxCat As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbxTaxCat As System.Windows.Forms.ComboBox
End Class

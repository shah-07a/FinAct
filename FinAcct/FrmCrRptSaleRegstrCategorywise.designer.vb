<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptSaleRegstrCategorywise
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
        Me.ChkRptType = New System.Windows.Forms.CheckBox
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
        Me.CrRptVewSaleRegstr = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptSaleRptHeadWise1 = New FinAcct.CrRptSaleRptHeadWise
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ChkRptType)
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
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1006, 80)
        Me.Panel1.TabIndex = 3
        '
        'ChkRptType
        '
        Me.ChkRptType.AutoSize = True
        Me.ChkRptType.Location = New System.Drawing.Point(411, 43)
        Me.ChkRptType.Name = "ChkRptType"
        Me.ChkRptType.Size = New System.Drawing.Size(87, 20)
        Me.ChkRptType.TabIndex = 10
        Me.ChkRptType.Text = "Detailed"
        Me.ChkRptType.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(669, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Customer"
        Me.Label5.Visible = False
        '
        'ChkBxTaxCat
        '
        Me.ChkBxTaxCat.AutoSize = True
        Me.ChkBxTaxCat.Checked = True
        Me.ChkBxTaxCat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBxTaxCat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBxTaxCat.Location = New System.Drawing.Point(783, 27)
        Me.ChkBxTaxCat.Name = "ChkBxTaxCat"
        Me.ChkBxTaxCat.Size = New System.Drawing.Size(43, 17)
        Me.ChkBxTaxCat.TabIndex = 3
        Me.ChkBxTaxCat.Text = "All"
        Me.ChkBxTaxCat.UseVisualStyleBackColor = True
        Me.ChkBxTaxCat.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(669, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tax Category"
        Me.Label4.Visible = False
        '
        'CmbxTaxCat
        '
        Me.CmbxTaxCat.Enabled = False
        Me.CmbxTaxCat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxTaxCat.FormattingEnabled = True
        Me.CmbxTaxCat.Location = New System.Drawing.Point(831, 23)
        Me.CmbxTaxCat.Name = "CmbxTaxCat"
        Me.CmbxTaxCat.Size = New System.Drawing.Size(22, 21)
        Me.CmbxTaxCat.TabIndex = 4
        Me.CmbxTaxCat.Visible = False
        '
        'CmbxLdgr
        '
        Me.CmbxLdgr.Enabled = False
        Me.CmbxLdgr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxLdgr.FormattingEnabled = True
        Me.CmbxLdgr.Location = New System.Drawing.Point(831, 51)
        Me.CmbxLdgr.Name = "CmbxLdgr"
        Me.CmbxLdgr.Size = New System.Drawing.Size(22, 21)
        Me.CmbxLdgr.TabIndex = 6
        Me.CmbxLdgr.Visible = False
        '
        'ChkLdgrAll
        '
        Me.ChkLdgrAll.AutoSize = True
        Me.ChkLdgrAll.Checked = True
        Me.ChkLdgrAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkLdgrAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkLdgrAll.Location = New System.Drawing.Point(783, 51)
        Me.ChkLdgrAll.Name = "ChkLdgrAll"
        Me.ChkLdgrAll.Size = New System.Drawing.Size(43, 17)
        Me.ChkLdgrAll.TabIndex = 5
        Me.ChkLdgrAll.Text = "All"
        Me.ChkLdgrAll.UseVisualStyleBackColor = True
        Me.ChkLdgrAll.Visible = False
        '
        'ChkRptLdgr
        '
        Me.ChkRptLdgr.AutoSize = True
        Me.ChkRptLdgr.Checked = True
        Me.ChkRptLdgr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptLdgr.Location = New System.Drawing.Point(411, 17)
        Me.ChkRptLdgr.Name = "ChkRptLdgr"
        Me.ChkRptLdgr.Size = New System.Drawing.Size(206, 20)
        Me.ChkRptLdgr.TabIndex = 2
        Me.ChkRptLdgr.Text = "Company Info. Required "
        Me.ChkRptLdgr.UseVisualStyleBackColor = True
        '
        'BtnRptVewLdgr
        '
        Me.BtnRptVewLdgr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRptVewLdgr.BackColor = System.Drawing.Color.Transparent
        Me.BtnRptVewLdgr.BackgroundImage = Global.FinAcct.My.Resources.Resources.EMB_C1B
        Me.BtnRptVewLdgr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRptVewLdgr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRptVewLdgr.FlatAppearance.BorderSize = 0
        Me.BtnRptVewLdgr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnRptVewLdgr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVewLdgr.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVewLdgr.ForeColor = System.Drawing.Color.Navy
        Me.BtnRptVewLdgr.Location = New System.Drawing.Point(863, 23)
        Me.BtnRptVewLdgr.Name = "BtnRptVewLdgr"
        Me.BtnRptVewLdgr.Size = New System.Drawing.Size(134, 33)
        Me.BtnRptVewLdgr.TabIndex = 7
        Me.BtnRptVewLdgr.Text = "View Report"
        Me.BtnRptVewLdgr.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 54)
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
        Me.DtpLdgr2.Location = New System.Drawing.Point(52, 54)
        Me.DtpLdgr2.Name = "DtpLdgr2"
        Me.DtpLdgr2.Size = New System.Drawing.Size(141, 23)
        Me.DtpLdgr2.TabIndex = 1
        '
        'DtpLdgr1
        '
        Me.DtpLdgr1.CustomFormat = "dd/MM/yyyy"
        Me.DtpLdgr1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpLdgr1.Location = New System.Drawing.Point(52, 3)
        Me.DtpLdgr1.Name = "DtpLdgr1"
        Me.DtpLdgr1.Size = New System.Drawing.Size(141, 23)
        Me.DtpLdgr1.TabIndex = 0
        '
        'CrRptVewSaleRegstr
        '
        Me.CrRptVewSaleRegstr.ActiveViewIndex = 0
        Me.CrRptVewSaleRegstr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewSaleRegstr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewSaleRegstr.DisplayGroupTree = False
        Me.CrRptVewSaleRegstr.Location = New System.Drawing.Point(1, 94)
        Me.CrRptVewSaleRegstr.Name = "CrRptVewSaleRegstr"
        Me.CrRptVewSaleRegstr.ReportSource = Me.CrRptSaleRptHeadWise1
        Me.CrRptVewSaleRegstr.ShowRefreshButton = False
        Me.CrRptVewSaleRegstr.Size = New System.Drawing.Size(1006, 0)
        Me.CrRptVewSaleRegstr.TabIndex = 4
        '
        'FrmCrRptSaleRegstrCategorywise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Turquoise
        Me.ClientSize = New System.Drawing.Size(1009, 82)
        Me.Controls.Add(Me.CrRptVewSaleRegstr)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "FrmCrRptSaleRegstrCategorywise"
        Me.Text = "Report Of Sale Register (Head-Wise)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbxLdgr As System.Windows.Forms.ComboBox
    Friend WithEvents ChkLdgrAll As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRptVewLdgr As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpLdgr2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpLdgr1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrRptVewSaleRegstr As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbxTaxCat As System.Windows.Forms.ComboBox
    Friend WithEvents ChkBxTaxCat As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChkRptLdgr As System.Windows.Forms.CheckBox
    Friend WithEvents CrRptSaleRptHeadWise1 As FinAcct.CrRptSaleRptHeadWise
    Friend WithEvents ChkRptType As System.Windows.Forms.CheckBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptBOMCosting
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnOthr = New System.Windows.Forms.Button
        Me.BtnOk = New System.Windows.Forms.Button
        Me.RbCalVal = New System.Windows.Forms.RadioButton
        Me.Rbcalpcent = New System.Windows.Forms.RadioButton
        Me.TxtMrp = New System.Windows.Forms.TextBox
        Me.TxtACom = New System.Windows.Forms.TextBox
        Me.TxtPval = New System.Windows.Forms.TextBox
        Me.TxtOc = New System.Windows.Forms.TextBox
        Me.TxtLc = New System.Windows.Forms.TextBox
        Me.TxtMc = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtTwC = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtEc = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.CmbxMthd = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpbc1 = New System.Windows.Forms.DateTimePicker
        Me.CmbxBcName = New System.Windows.Forms.ComboBox
        Me.ChkRptLdgr = New System.Windows.Forms.CheckBox
        Me.BtnRptVewLdgr = New System.Windows.Forms.Button
        Me.DgBOMcost = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CntxtMsBom = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtRemrks = New System.Windows.Forms.TextBox
        Me.DgDtlChrgs = New System.Windows.Forms.DataGridView
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.DgBOMcost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CntxtMsBom.SuspendLayout()
        CType(Me.DgDtlChrgs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnOthr)
        Me.Panel1.Controls.Add(Me.BtnOk)
        Me.Panel1.Controls.Add(Me.RbCalVal)
        Me.Panel1.Controls.Add(Me.Rbcalpcent)
        Me.Panel1.Controls.Add(Me.TxtMrp)
        Me.Panel1.Controls.Add(Me.TxtACom)
        Me.Panel1.Controls.Add(Me.TxtPval)
        Me.Panel1.Controls.Add(Me.TxtOc)
        Me.Panel1.Controls.Add(Me.TxtLc)
        Me.Panel1.Controls.Add(Me.TxtMc)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.TxtTwC)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TxtEc)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.CmbxMthd)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpbc1)
        Me.Panel1.Controls.Add(Me.CmbxBcName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1272, 556)
        Me.Panel1.TabIndex = 0
        '
        'BtnOthr
        '
        Me.BtnOthr.BackgroundImage = Global.FinAcct.My.Resources.Resources.btn
        Me.BtnOthr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOthr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOthr.Location = New System.Drawing.Point(348, 100)
        Me.BtnOthr.Name = "BtnOthr"
        Me.BtnOthr.Size = New System.Drawing.Size(177, 22)
        Me.BtnOthr.TabIndex = 8
        Me.BtnOthr.Text = "Details Of Other Charges"
        Me.BtnOthr.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.BackgroundImage = Global.FinAcct.My.Resources.Resources.btn
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOk.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(828, 103)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(44, 23)
        Me.BtnOk.TabIndex = 15
        Me.BtnOk.Text = "&Ok"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'RbCalVal
        '
        Me.RbCalVal.AutoSize = True
        Me.RbCalVal.Location = New System.Drawing.Point(633, 29)
        Me.RbCalVal.Name = "RbCalVal"
        Me.RbCalVal.Size = New System.Drawing.Size(189, 18)
        Me.RbCalVal.TabIndex = 11
        Me.RbCalVal.Text = "Profit Calculation By Value"
        Me.RbCalVal.UseVisualStyleBackColor = True
        '
        'Rbcalpcent
        '
        Me.Rbcalpcent.AutoSize = True
        Me.Rbcalpcent.Checked = True
        Me.Rbcalpcent.Location = New System.Drawing.Point(633, 7)
        Me.Rbcalpcent.Name = "Rbcalpcent"
        Me.Rbcalpcent.Size = New System.Drawing.Size(226, 18)
        Me.Rbcalpcent.TabIndex = 10
        Me.Rbcalpcent.TabStop = True
        Me.Rbcalpcent.Text = "Profit Calculation By Percentage"
        Me.Rbcalpcent.UseVisualStyleBackColor = True
        '
        'TxtMrp
        '
        Me.TxtMrp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMrp.Location = New System.Drawing.Point(760, 103)
        Me.TxtMrp.Name = "TxtMrp"
        Me.TxtMrp.Size = New System.Drawing.Size(66, 22)
        Me.TxtMrp.TabIndex = 14
        Me.TxtMrp.Text = "0.00"
        Me.TxtMrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtACom
        '
        Me.TxtACom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtACom.Location = New System.Drawing.Point(760, 77)
        Me.TxtACom.Name = "TxtACom"
        Me.TxtACom.Size = New System.Drawing.Size(66, 22)
        Me.TxtACom.TabIndex = 13
        Me.TxtACom.Text = "0.00"
        Me.TxtACom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPval
        '
        Me.TxtPval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPval.Location = New System.Drawing.Point(760, 51)
        Me.TxtPval.Name = "TxtPval"
        Me.TxtPval.Size = New System.Drawing.Size(66, 22)
        Me.TxtPval.TabIndex = 12
        Me.TxtPval.Text = "0.00"
        Me.TxtPval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtOc
        '
        Me.TxtOc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOc.Location = New System.Drawing.Point(528, 100)
        Me.TxtOc.Name = "TxtOc"
        Me.TxtOc.ReadOnly = True
        Me.TxtOc.Size = New System.Drawing.Size(100, 22)
        Me.TxtOc.TabIndex = 9
        Me.TxtOc.Text = "0.00"
        Me.TxtOc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtLc
        '
        Me.TxtLc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtLc.Location = New System.Drawing.Point(528, 69)
        Me.TxtLc.Name = "TxtLc"
        Me.TxtLc.Size = New System.Drawing.Size(100, 22)
        Me.TxtLc.TabIndex = 7
        Me.TxtLc.Text = "0.00"
        Me.TxtLc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtMc
        '
        Me.TxtMc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMc.Location = New System.Drawing.Point(528, 38)
        Me.TxtMc.Name = "TxtMc"
        Me.TxtMc.Size = New System.Drawing.Size(100, 22)
        Me.TxtMc.TabIndex = 6
        Me.TxtMc.Text = "0.00"
        Me.TxtMc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(633, 106)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 14)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Add MRP(%)"
        '
        'TxtTwC
        '
        Me.TxtTwC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTwC.Location = New System.Drawing.Point(528, 7)
        Me.TxtTwC.Name = "TxtTwC"
        Me.TxtTwC.Size = New System.Drawing.Size(100, 22)
        Me.TxtTwC.TabIndex = 5
        Me.TxtTwC.Text = "0.00"
        Me.TxtTwC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(633, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 14)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Agent's Comm.(%)"
        '
        'TxtEc
        '
        Me.TxtEc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtEc.Location = New System.Drawing.Point(130, 100)
        Me.TxtEc.Name = "TxtEc"
        Me.TxtEc.Size = New System.Drawing.Size(100, 22)
        Me.TxtEc.TabIndex = 4
        Me.TxtEc.Text = "0.00"
        Me.TxtEc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(633, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(111, 14)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Profit  (%/Value)"
        '
        'CmbxMthd
        '
        Me.CmbxMthd.FormattingEnabled = True
        Me.CmbxMthd.Items.AddRange(New Object() {"Manual", "Last Purchase Rate", "First Purchase Rate", "Average Purchase Rate"})
        Me.CmbxMthd.Location = New System.Drawing.Point(130, 69)
        Me.CmbxMthd.Name = "CmbxMthd"
        Me.CmbxMthd.Size = New System.Drawing.Size(209, 22)
        Me.CmbxMthd.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(404, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 14)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Labour Charges"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(404, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Marketting Cost"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(402, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tear &&  Wear Cost"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Electricity Charges"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Method"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 14)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Item Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 14)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Date "
        '
        'Dtpbc1
        '
        Me.Dtpbc1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpbc1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpbc1.Location = New System.Drawing.Point(130, 7)
        Me.Dtpbc1.Name = "Dtpbc1"
        Me.Dtpbc1.Size = New System.Drawing.Size(100, 22)
        Me.Dtpbc1.TabIndex = 1
        Me.Dtpbc1.TabStop = False
        '
        'CmbxBcName
        '
        Me.CmbxBcName.FormattingEnabled = True
        Me.CmbxBcName.Location = New System.Drawing.Point(130, 38)
        Me.CmbxBcName.Name = "CmbxBcName"
        Me.CmbxBcName.Size = New System.Drawing.Size(265, 22)
        Me.CmbxBcName.TabIndex = 2
        '
        'ChkRptLdgr
        '
        Me.ChkRptLdgr.AutoSize = True
        Me.ChkRptLdgr.Checked = True
        Me.ChkRptLdgr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptLdgr.Location = New System.Drawing.Point(1, 516)
        Me.ChkRptLdgr.Name = "ChkRptLdgr"
        Me.ChkRptLdgr.Size = New System.Drawing.Size(226, 18)
        Me.ChkRptLdgr.TabIndex = 14
        Me.ChkRptLdgr.Text = "Company Information Required "
        Me.ChkRptLdgr.UseVisualStyleBackColor = True
        '
        'BtnRptVewLdgr
        '
        Me.BtnRptVewLdgr.BackgroundImage = Global.FinAcct.My.Resources.Resources.btnLarge
        Me.BtnRptVewLdgr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVewLdgr.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVewLdgr.Location = New System.Drawing.Point(568, 523)
        Me.BtnRptVewLdgr.Name = "BtnRptVewLdgr"
        Me.BtnRptVewLdgr.Size = New System.Drawing.Size(100, 33)
        Me.BtnRptVewLdgr.TabIndex = 16
        Me.BtnRptVewLdgr.Text = "&Print"
        Me.BtnRptVewLdgr.UseVisualStyleBackColor = True
        '
        'DgBOMcost
        '
        Me.DgBOMcost.AllowUserToAddRows = False
        Me.DgBOMcost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgBOMcost.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.DgBOMcost.ContextMenuStrip = Me.CntxtMsBom
        Me.DgBOMcost.Location = New System.Drawing.Point(-4, 145)
        Me.DgBOMcost.Name = "DgBOMcost"
        Me.DgBOMcost.Size = New System.Drawing.Size(879, 365)
        Me.DgBOMcost.TabIndex = 13
        '
        'Column1
        '
        Me.Column1.HeaderText = "S.No."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.HeaderText = "Particulars"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 250
        '
        'Column3
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N3"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "Quantity"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 130
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.HeaderText = "Ratio"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 130
        '
        'Column5
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Rate"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 130
        '
        'Column6
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column6.HeaderText = "Amount"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'CntxtMsBom
        '
        Me.CntxtMsBom.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem, Me.CancelToolStripMenuItem, Me.RefreshToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.CntxtMsBom.Name = "CntxtMsBom"
        Me.CntxtMsBom.Size = New System.Drawing.Size(114, 92)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.CancelToolStripMenuItem.Text = "Cancel"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'BtnExit
        '
        Me.BtnExit.BackgroundImage = Global.FinAcct.My.Resources.Resources.btnLarge
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(780, 523)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(100, 33)
        Me.BtnExit.TabIndex = 18
        Me.BtnExit.Text = "&Exit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'BtnCncl
        '
        Me.BtnCncl.BackgroundImage = Global.FinAcct.My.Resources.Resources.btnLarge
        Me.BtnCncl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCncl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCncl.Location = New System.Drawing.Point(674, 523)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(100, 33)
        Me.BtnCncl.TabIndex = 17
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 532)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 14)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Remarks :-"
        '
        'TxtRemrks
        '
        Me.TxtRemrks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRemrks.Location = New System.Drawing.Point(85, 529)
        Me.TxtRemrks.MaxLength = 150
        Me.TxtRemrks.Name = "TxtRemrks"
        Me.TxtRemrks.Size = New System.Drawing.Size(452, 22)
        Me.TxtRemrks.TabIndex = 15
        '
        'DgDtlChrgs
        '
        Me.DgDtlChrgs.AllowUserToAddRows = False
        Me.DgDtlChrgs.BackgroundColor = System.Drawing.Color.BlanchedAlmond
        Me.DgDtlChrgs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgDtlChrgs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.Column8, Me.Column9})
        Me.DgDtlChrgs.Enabled = False
        Me.DgDtlChrgs.Location = New System.Drawing.Point(900, 145)
        Me.DgDtlChrgs.Name = "DgDtlChrgs"
        Me.DgDtlChrgs.Size = New System.Drawing.Size(372, 150)
        Me.DgDtlChrgs.TabIndex = 19
        Me.DgDtlChrgs.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "Id"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        Me.Column7.Width = 5
        '
        'Column8
        '
        Me.Column8.HeaderText = "Expenses Head Name"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 200
        '
        'Column9
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column9.HeaderText = "Amount"
        Me.Column9.MaxInputLength = 14
        Me.Column9.Name = "Column9"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "S.No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 60
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Particulars"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 250
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N3"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn3.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 130
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ratio"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 130
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn5.HeaderText = "Rate"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 130
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn6.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 130
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 5
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Expenses Head Name"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 200
        '
        'DataGridViewTextBoxColumn9
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn9.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn9.MaxInputLength = 14
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'FrmCrRptBOMCosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(899, 564)
        Me.Controls.Add(Me.TxtRemrks)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DgDtlChrgs)
        Me.Controls.Add(Me.DgBOMcost)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnRptVewLdgr)
        Me.Controls.Add(Me.ChkRptLdgr)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCrRptBOMCosting"
        Me.Text = "Bill Of Material Costing (BOM Costing)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgBOMcost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CntxtMsBom.ResumeLayout(False)
        CType(Me.DgDtlChrgs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpbc1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbxBcName As System.Windows.Forms.ComboBox
    Friend WithEvents ChkRptLdgr As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRptVewLdgr As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbxMthd As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtEc As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtOc As System.Windows.Forms.TextBox
    Friend WithEvents TxtLc As System.Windows.Forms.TextBox
    Friend WithEvents TxtMc As System.Windows.Forms.TextBox
    Friend WithEvents TxtTwC As System.Windows.Forms.TextBox
    Friend WithEvents DgBOMcost As System.Windows.Forms.DataGridView
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents TxtPval As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RbCalVal As System.Windows.Forms.RadioButton
    Friend WithEvents Rbcalpcent As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtRemrks As System.Windows.Forms.TextBox
    Friend WithEvents CntxtMsBom As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnOthr As System.Windows.Forms.Button
    Friend WithEvents DgDtlChrgs As System.Windows.Forms.DataGridView
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtMrp As System.Windows.Forms.TextBox
    Friend WithEvents TxtACom As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBnkReconcile
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBnkReconcile))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CmbxDrCr = New System.Windows.Forms.ComboBox
        Me.LblBalType2 = New System.Windows.Forms.Label
        Me.TxtBnkBal = New System.Windows.Forms.TextBox
        Me.LblBnkBal = New System.Windows.Forms.Label
        Me.Cmbxbb = New System.Windows.Forms.ComboBox
        Me.BtnRptVewbb = New System.Windows.Forms.Button
        Me.BtnExt = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpbb2 = New System.Windows.Forms.DateTimePicker
        Me.Dtpbb1 = New System.Windows.Forms.DateTimePicker
        Me.CrRptBnkBook1 = New FinAcct.CrRptBnkBook
        Me.DgBnkRecon = New System.Windows.Forms.DataGridView
        Me.LstvewBank1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.LstvewBnk2 = New System.Windows.Forms.ListView
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.Pnlbnk = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblCr = New System.Windows.Forms.Label
        Me.LblDr = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Pnlsumry = New System.Windows.Forms.Panel
        Me.lBLdIFF = New System.Windows.Forms.Label
        Me.LBLBNKBAL1 = New System.Windows.Forms.Label
        Me.LblnetBal = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblchdep = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Lblbokbal1 = New System.Windows.Forms.Label
        Me.lblchisue = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.LblBalance = New System.Windows.Forms.Label
        Me.LblChDepost = New System.Windows.Forms.Label
        Me.LblChissued = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.BtnReconSave = New System.Windows.Forms.Button
        Me.CmSBnkRecon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OKToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RECONCILEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CHECKALLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CLEARALLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PRINTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EXITToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.DgBnkRecon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnlbnk.SuspendLayout()
        Me.Pnlsumry.SuspendLayout()
        Me.CmSBnkRecon.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CmbxDrCr)
        Me.Panel1.Controls.Add(Me.LblBalType2)
        Me.Panel1.Controls.Add(Me.TxtBnkBal)
        Me.Panel1.Controls.Add(Me.LblBnkBal)
        Me.Panel1.Controls.Add(Me.Cmbxbb)
        Me.Panel1.Controls.Add(Me.BtnRptVewbb)
        Me.Panel1.Controls.Add(Me.BtnExt)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpbb2)
        Me.Panel1.Controls.Add(Me.Dtpbb1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1015, 54)
        Me.Panel1.TabIndex = 0
        '
        'CmbxDrCr
        '
        Me.CmbxDrCr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxDrCr.FormattingEnabled = True
        Me.CmbxDrCr.Items.AddRange(New Object() {"Dr", "Cr"})
        Me.CmbxDrCr.Location = New System.Drawing.Point(703, 30)
        Me.CmbxDrCr.Name = "CmbxDrCr"
        Me.CmbxDrCr.Size = New System.Drawing.Size(45, 21)
        Me.CmbxDrCr.TabIndex = 5
        '
        'LblBalType2
        '
        Me.LblBalType2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblBalType2.Location = New System.Drawing.Point(369, 31)
        Me.LblBalType2.Name = "LblBalType2"
        Me.LblBalType2.Size = New System.Drawing.Size(32, 20)
        Me.LblBalType2.TabIndex = 11
        '
        'TxtBnkBal
        '
        Me.TxtBnkBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBnkBal.Location = New System.Drawing.Point(603, 30)
        Me.TxtBnkBal.Name = "TxtBnkBal"
        Me.TxtBnkBal.Size = New System.Drawing.Size(100, 21)
        Me.TxtBnkBal.TabIndex = 4
        Me.TxtBnkBal.Text = "0"
        Me.TxtBnkBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblBnkBal
        '
        Me.LblBnkBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblBnkBal.Location = New System.Drawing.Point(270, 31)
        Me.LblBnkBal.Name = "LblBnkBal"
        Me.LblBnkBal.Size = New System.Drawing.Size(100, 20)
        Me.LblBnkBal.TabIndex = 9
        Me.LblBnkBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmbxbb
        '
        Me.Cmbxbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxbb.FormattingEnabled = True
        Me.Cmbxbb.Location = New System.Drawing.Point(270, 3)
        Me.Cmbxbb.Name = "Cmbxbb"
        Me.Cmbxbb.Size = New System.Drawing.Size(478, 21)
        Me.Cmbxbb.TabIndex = 3
        '
        'BtnRptVewbb
        '
        Me.BtnRptVewbb.BackgroundImage = Global.FinAcct.My.Resources.Resources.btnLarge
        Me.BtnRptVewbb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVewbb.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVewbb.Location = New System.Drawing.Point(754, 10)
        Me.BtnRptVewbb.Name = "BtnRptVewbb"
        Me.BtnRptVewbb.Size = New System.Drawing.Size(80, 33)
        Me.BtnRptVewbb.TabIndex = 6
        Me.BtnRptVewbb.Text = "&Ok"
        Me.BtnRptVewbb.UseVisualStyleBackColor = True
        '
        'BtnExt
        '
        Me.BtnExt.BackgroundImage = CType(resources.GetObject("BtnExt.BackgroundImage"), System.Drawing.Image)
        Me.BtnExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExt.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExt.Location = New System.Drawing.Point(926, 10)
        Me.BtnExt.Name = "BtnExt"
        Me.BtnExt.Size = New System.Drawing.Size(80, 33)
        Me.BtnExt.TabIndex = 8
        Me.BtnExt.Text = "&Exit"
        Me.BtnExt.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(840, 10)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(80, 33)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "&Reconcile"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(403, 33)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(199, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Balance (As Per Bank Statement)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(159, 33)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 13)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Closing Balance :-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(159, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Bank Name :-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From"
        '
        'Dtpbb2
        '
        Me.Dtpbb2.CustomFormat = "dd/MM/yyyy"
        Me.Dtpbb2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpbb2.Location = New System.Drawing.Point(49, 27)
        Me.Dtpbb2.Name = "Dtpbb2"
        Me.Dtpbb2.Size = New System.Drawing.Size(104, 21)
        Me.Dtpbb2.TabIndex = 2
        '
        'Dtpbb1
        '
        Me.Dtpbb1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpbb1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpbb1.Location = New System.Drawing.Point(50, 3)
        Me.Dtpbb1.Name = "Dtpbb1"
        Me.Dtpbb1.Size = New System.Drawing.Size(104, 21)
        Me.Dtpbb1.TabIndex = 1
        '
        'DgBnkRecon
        '
        Me.DgBnkRecon.AllowDrop = True
        Me.DgBnkRecon.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgBnkRecon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgBnkRecon.Location = New System.Drawing.Point(1, 56)
        Me.DgBnkRecon.Name = "DgBnkRecon"
        Me.DgBnkRecon.RowTemplate.Height = 25
        Me.DgBnkRecon.Size = New System.Drawing.Size(1015, 606)
        Me.DgBnkRecon.TabIndex = 1
        '
        'LstvewBank1
        '
        Me.LstvewBank1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.LstvewBank1.GridLines = True
        Me.LstvewBank1.Location = New System.Drawing.Point(8, 20)
        Me.LstvewBank1.Name = "LstvewBank1"
        Me.LstvewBank1.Size = New System.Drawing.Size(496, 184)
        Me.LstvewBank1.TabIndex = 3
        Me.LstvewBank1.UseCompatibleStateImageBehavior = False
        Me.LstvewBank1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Date"
        Me.ColumnHeader1.Width = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Account"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Particulars"
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Debit"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 100
        '
        'LstvewBnk2
        '
        Me.LstvewBnk2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.LstvewBnk2.GridLines = True
        Me.LstvewBnk2.Location = New System.Drawing.Point(510, 20)
        Me.LstvewBnk2.Name = "LstvewBnk2"
        Me.LstvewBnk2.Size = New System.Drawing.Size(496, 184)
        Me.LstvewBnk2.TabIndex = 4
        Me.LstvewBnk2.UseCompatibleStateImageBehavior = False
        Me.LstvewBnk2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Date"
        Me.ColumnHeader6.Width = 90
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Account"
        Me.ColumnHeader7.Width = 150
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Particulars"
        Me.ColumnHeader8.Width = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Credit"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader9.Width = 100
        '
        'Pnlbnk
        '
        Me.Pnlbnk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pnlbnk.AutoScroll = True
        Me.Pnlbnk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnlbnk.Controls.Add(Me.Label7)
        Me.Pnlbnk.Controls.Add(Me.Label6)
        Me.Pnlbnk.Controls.Add(Me.LblCr)
        Me.Pnlbnk.Controls.Add(Me.LblDr)
        Me.Pnlbnk.Controls.Add(Me.Label5)
        Me.Pnlbnk.Controls.Add(Me.Label4)
        Me.Pnlbnk.Controls.Add(Me.LstvewBank1)
        Me.Pnlbnk.Controls.Add(Me.LstvewBnk2)
        Me.Pnlbnk.Enabled = False
        Me.Pnlbnk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnlbnk.Location = New System.Drawing.Point(1, 279)
        Me.Pnlbnk.Name = "Pnlbnk"
        Me.Pnlbnk.Size = New System.Drawing.Size(1015, 226)
        Me.Pnlbnk.TabIndex = 5
        Me.Pnlbnk.Visible = False
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Location = New System.Drawing.Point(841, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Total:->"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(339, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Total:->"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblCr
        '
        Me.LblCr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCr.Location = New System.Drawing.Point(902, 203)
        Me.LblCr.Name = "LblCr"
        Me.LblCr.Size = New System.Drawing.Size(101, 20)
        Me.LblCr.TabIndex = 7
        Me.LblCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDr
        '
        Me.LblDr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblDr.Location = New System.Drawing.Point(400, 203)
        Me.LblDr.Name = "LblDr"
        Me.LblDr.Size = New System.Drawing.Size(101, 20)
        Me.LblDr.TabIndex = 6
        Me.LblDr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(507, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(302, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Cheque(s) Deposited But Not Cleared  In Bank Yet."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(291, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Cheque(s) Issued But Not Presented In Bank Yet."
        '
        'Pnlsumry
        '
        Me.Pnlsumry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnlsumry.Controls.Add(Me.lBLdIFF)
        Me.Pnlsumry.Controls.Add(Me.LBLBNKBAL1)
        Me.Pnlsumry.Controls.Add(Me.LblnetBal)
        Me.Pnlsumry.Controls.Add(Me.Label9)
        Me.Pnlsumry.Controls.Add(Me.lblchdep)
        Me.Pnlsumry.Controls.Add(Me.Label15)
        Me.Pnlsumry.Controls.Add(Me.Lblbokbal1)
        Me.Pnlsumry.Controls.Add(Me.lblchisue)
        Me.Pnlsumry.Controls.Add(Me.Label14)
        Me.Pnlsumry.Controls.Add(Me.LblBalance)
        Me.Pnlsumry.Controls.Add(Me.LblChDepost)
        Me.Pnlsumry.Controls.Add(Me.LblChissued)
        Me.Pnlsumry.Controls.Add(Me.Label8)
        Me.Pnlsumry.Enabled = False
        Me.Pnlsumry.Location = New System.Drawing.Point(250, 504)
        Me.Pnlsumry.Name = "Pnlsumry"
        Me.Pnlsumry.Size = New System.Drawing.Size(508, 158)
        Me.Pnlsumry.TabIndex = 6
        Me.Pnlsumry.Visible = False
        '
        'lBLdIFF
        '
        Me.lBLdIFF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lBLdIFF.Location = New System.Drawing.Point(369, 128)
        Me.lBLdIFF.Name = "lBLdIFF"
        Me.lBLdIFF.Size = New System.Drawing.Size(133, 20)
        Me.lBLdIFF.TabIndex = 8
        Me.lBLdIFF.Text = "0"
        Me.lBLdIFF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLBNKBAL1
        '
        Me.LBLBNKBAL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBLBNKBAL1.Location = New System.Drawing.Point(369, 106)
        Me.LBLBNKBAL1.Name = "LBLBNKBAL1"
        Me.LBLBNKBAL1.Size = New System.Drawing.Size(133, 20)
        Me.LBLBNKBAL1.TabIndex = 8
        Me.LBLBNKBAL1.Text = "0"
        Me.LBLBNKBAL1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblnetBal
        '
        Me.LblnetBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblnetBal.Location = New System.Drawing.Point(369, 84)
        Me.LblnetBal.Name = "LblnetBal"
        Me.LblnetBal.Size = New System.Drawing.Size(133, 20)
        Me.LblnetBal.TabIndex = 8
        Me.LblnetBal.Text = "0"
        Me.LblnetBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(4, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "DIFFERENCE (If Any)"
        '
        'lblchdep
        '
        Me.lblchdep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblchdep.Location = New System.Drawing.Point(369, 62)
        Me.lblchdep.Name = "lblchdep"
        Me.lblchdep.Size = New System.Drawing.Size(133, 20)
        Me.lblchdep.TabIndex = 8
        Me.lblchdep.Text = "0"
        Me.lblchdep.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(4, 109)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(179, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "BALANCE AS PER BANK RECORD"
        '
        'Lblbokbal1
        '
        Me.Lblbokbal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblbokbal1.Location = New System.Drawing.Point(369, 17)
        Me.Lblbokbal1.Name = "Lblbokbal1"
        Me.Lblbokbal1.Size = New System.Drawing.Size(133, 20)
        Me.Lblbokbal1.TabIndex = 8
        Me.Lblbokbal1.Text = "0"
        Me.Lblbokbal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblchisue
        '
        Me.lblchisue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblchisue.Location = New System.Drawing.Point(369, 40)
        Me.lblchisue.Name = "lblchisue"
        Me.lblchisue.Size = New System.Drawing.Size(133, 20)
        Me.lblchisue.TabIndex = 8
        Me.lblchisue.Text = "0"
        Me.lblchisue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(4, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "BALANCE "
        '
        'LblBalance
        '
        Me.LblBalance.AutoSize = True
        Me.LblBalance.BackColor = System.Drawing.Color.Transparent
        Me.LblBalance.Location = New System.Drawing.Point(3, 20)
        Me.LblBalance.Name = "LblBalance"
        Me.LblBalance.Size = New System.Drawing.Size(138, 13)
        Me.LblBalance.TabIndex = 7
        Me.LblBalance.Text = "BALANCE AS PER BOOKS"
        '
        'LblChDepost
        '
        Me.LblChDepost.AutoSize = True
        Me.LblChDepost.BackColor = System.Drawing.Color.Transparent
        Me.LblChDepost.Location = New System.Drawing.Point(4, 65)
        Me.LblChDepost.Name = "LblChDepost"
        Me.LblChDepost.Size = New System.Drawing.Size(138, 13)
        Me.LblChDepost.TabIndex = 7
        Me.LblChDepost.Text = "BALANCE AS PER BOOKS"
        '
        'LblChissued
        '
        Me.LblChissued.AutoSize = True
        Me.LblChissued.BackColor = System.Drawing.Color.Transparent
        Me.LblChissued.Location = New System.Drawing.Point(4, 43)
        Me.LblChissued.Name = "LblChissued"
        Me.LblChissued.Size = New System.Drawing.Size(138, 13)
        Me.LblChissued.TabIndex = 7
        Me.LblChissued.Text = "BALANCE AS PER BOOKS"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.NavajoWhite
        Me.Label8.Location = New System.Drawing.Point(1, -1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(506, 18)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "SUMMARY"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnReconSave
        '
        Me.BtnReconSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReconSave.BackgroundImage = Global.FinAcct.My.Resources.Resources.btn
        Me.BtnReconSave.Enabled = False
        Me.BtnReconSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReconSave.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReconSave.Location = New System.Drawing.Point(908, 620)
        Me.BtnReconSave.Name = "BtnReconSave"
        Me.BtnReconSave.Size = New System.Drawing.Size(100, 33)
        Me.BtnReconSave.TabIndex = 7
        Me.BtnReconSave.Text = "&Print"
        Me.BtnReconSave.UseVisualStyleBackColor = True
        Me.BtnReconSave.Visible = False
        '
        'CmSBnkRecon
        '
        Me.CmSBnkRecon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OKToolStripMenuItem, Me.RECONCILEToolStripMenuItem, Me.CHECKALLToolStripMenuItem, Me.CLEARALLToolStripMenuItem, Me.PRINTToolStripMenuItem, Me.EXITToolStripMenuItem})
        Me.CmSBnkRecon.Name = "CmSBnkRecon"
        Me.CmSBnkRecon.Size = New System.Drawing.Size(137, 136)
        '
        'OKToolStripMenuItem
        '
        Me.OKToolStripMenuItem.Name = "OKToolStripMenuItem"
        Me.OKToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.OKToolStripMenuItem.Text = "OK"
        '
        'RECONCILEToolStripMenuItem
        '
        Me.RECONCILEToolStripMenuItem.Name = "RECONCILEToolStripMenuItem"
        Me.RECONCILEToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.RECONCILEToolStripMenuItem.Text = "RECONCILE"
        '
        'CHECKALLToolStripMenuItem
        '
        Me.CHECKALLToolStripMenuItem.Name = "CHECKALLToolStripMenuItem"
        Me.CHECKALLToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.CHECKALLToolStripMenuItem.Text = "CHECK ALL"
        '
        'CLEARALLToolStripMenuItem
        '
        Me.CLEARALLToolStripMenuItem.Name = "CLEARALLToolStripMenuItem"
        Me.CLEARALLToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.CLEARALLToolStripMenuItem.Text = "CLEAR ALL"
        '
        'PRINTToolStripMenuItem
        '
        Me.PRINTToolStripMenuItem.Name = "PRINTToolStripMenuItem"
        Me.PRINTToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.PRINTToolStripMenuItem.Text = "PRINT"
        '
        'EXITToolStripMenuItem
        '
        Me.EXITToolStripMenuItem.Name = "EXITToolStripMenuItem"
        Me.EXITToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.EXITToolStripMenuItem.Text = "EXIT"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "DATE"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "PARTICULARS"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 250
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn3.HeaderText = "DEBIT"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn4.HeaderText = "CREDIT"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "N2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn5.HeaderText = "DIFFERENCE (If Any)"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "REMARKS"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 190
        '
        'FrmBnkReconcile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1017, 664)
        Me.ContextMenuStrip = Me.CmSBnkRecon
        Me.Controls.Add(Me.BtnReconSave)
        Me.Controls.Add(Me.Pnlsumry)
        Me.Controls.Add(Me.Pnlbnk)
        Me.Controls.Add(Me.DgBnkRecon)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmBnkReconcile"
        Me.Text = "Report Bank Book"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgBnkRecon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnlbnk.ResumeLayout(False)
        Me.Pnlbnk.PerformLayout()
        Me.Pnlsumry.ResumeLayout(False)
        Me.Pnlsumry.PerformLayout()
        Me.CmSBnkRecon.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptBnkBook1 As FinAcct.CrRptBnkBook
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnRptVewbb As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpbb2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtpbb1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cmbxbb As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgBnkRecon As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnExt As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents LstvewBank1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LstvewBnk2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Pnlbnk As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblDr As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblCr As System.Windows.Forms.Label
    Friend WithEvents Pnlsumry As System.Windows.Forms.Panel
    Friend WithEvents LblChissued As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LBLBNKBAL1 As System.Windows.Forms.Label
    Friend WithEvents LblnetBal As System.Windows.Forms.Label
    Friend WithEvents lblchdep As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblchisue As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents LblChDepost As System.Windows.Forms.Label
    Friend WithEvents LblBnkBal As System.Windows.Forms.Label
    Friend WithEvents TxtBnkBal As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LblBalType2 As System.Windows.Forms.Label
    Friend WithEvents CmbxDrCr As System.Windows.Forms.ComboBox
    Friend WithEvents Lblbokbal1 As System.Windows.Forms.Label
    Friend WithEvents LblBalance As System.Windows.Forms.Label
    Friend WithEvents lBLdIFF As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnReconSave As System.Windows.Forms.Button
    Friend WithEvents CmSBnkRecon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OKToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RECONCILEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CHECKALLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CLEARALLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PRINTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EXITToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class

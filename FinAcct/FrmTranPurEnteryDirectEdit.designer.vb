<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTranPurEnteryDirectEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTranPurEnteryDirectEdit))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TxtSurChrg = New System.Windows.Forms.TextBox
        Me.TxtVATamt = New System.Windows.Forms.TextBox
        Me.TxtTxableAmt = New System.Windows.Forms.TextBox
        Me.LblVATCST = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.LblRondOff = New System.Windows.Forms.Label
        Me.LblSurCharg = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.LbltablAmt = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.mskTxtVAtCst = New System.Windows.Forms.MaskedTextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.lblgross = New System.Windows.Forms.Label
        Me.lbldiscount = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.lbltoc = New System.Windows.Forms.Label
        Me.lblsubttl = New System.Windows.Forms.Label
        Me.Tplitem = New System.Windows.Forms.TableLayoutPanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label39 = New System.Windows.Forms.Label
        Me.CmbxStokGrup = New System.Windows.Forms.ComboBox
        Me.RbxiName = New System.Windows.Forms.RadioButton
        Me.Rbxicode = New System.Windows.Forms.RadioButton
        Me.TxtItmcode = New System.Windows.Forms.TextBox
        Me.LstVewItem = New System.Windows.Forms.ListView
        Me.ColIcode = New System.Windows.Forms.ColumnHeader
        Me.ColIname = New System.Windows.Forms.ColumnHeader
        Me.Coliid = New System.Windows.Forms.ColumnHeader
        Me.Colicost = New System.Windows.Forms.ColumnHeader
        Me.Colmin = New System.Windows.Forms.ColumnHeader
        Me.Colmax = New System.Windows.Forms.ColumnHeader
        Me.Colopn = New System.Windows.Forms.ColumnHeader
        Me.Colunt = New System.Windows.Forms.ColumnHeader
        Me.Collocid = New System.Windows.Forms.ColumnHeader
        Me.DgPurDirect = New System.Windows.Forms.DataGridView
        Me.ContxtDg1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tplcustlist = New System.Windows.Forms.TableLayoutPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RbxName = New System.Windows.Forms.RadioButton
        Me.Rbxcode = New System.Windows.Forms.RadioButton
        Me.Txtcustcode = New System.Windows.Forms.TextBox
        Me.lstvewcustlist = New System.Windows.Forms.ListView
        Me.custCode = New System.Windows.Forms.ColumnHeader
        Me.custName = New System.Windows.Forms.ColumnHeader
        Me.custId = New System.Windows.Forms.ColumnHeader
        Me.FullAddress = New System.Windows.Forms.ColumnHeader
        Me.splrspcatid = New System.Windows.Forms.ColumnHeader
        Me.Colcarrid = New System.Windows.Forms.ColumnHeader
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Btnundrgrp = New System.Windows.Forms.Button
        Me.CmbxLdgrHead = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.MTxtTotlamt = New System.Windows.Forms.MaskedTextBox
        Me.BtnEditmode = New System.Windows.Forms.Button
        Me.btnSpcatadd = New System.Windows.Forms.Button
        Me.Label28 = New System.Windows.Forms.Label
        Me.Cmbxspcatid = New System.Windows.Forms.ComboBox
        Me.Chkbdisc = New System.Windows.Forms.CheckBox
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Mtxtdisvalue = New System.Windows.Forms.MaskedTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Cmbxdistype = New System.Windows.Forms.ComboBox
        Me.ChkbOthrCharg = New System.Windows.Forms.CheckBox
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.TxtPlcyno = New System.Windows.Forms.TextBox
        Me.TxtinsCo = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.MskInscharg = New System.Windows.Forms.MaskedTextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Mskothrchrg = New System.Windows.Forms.MaskedTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.MskPostcharg = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.MtxtPkgcharg = New System.Windows.Forms.MaskedTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ChkbCariDetals = New System.Windows.Forms.CheckBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Dtpgrdt = New System.Windows.Forms.DateTimePicker
        Me.mtxtulcharg = New System.Windows.Forms.MaskedTextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.MtxtfrtChargs = New System.Windows.Forms.MaskedTextBox
        Me.TxtCariNo = New System.Windows.Forms.TextBox
        Me.Txtgrno = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Txtuload = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPurBillNo = New System.Windows.Forms.TextBox
        Me.BtnAddCarri = New System.Windows.Forms.Button
        Me.BtnAddCust = New System.Windows.Forms.Button
        Me.Btnaddware = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Txtcoment = New System.Windows.Forms.TextBox
        Me.CmbxCarri = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbxWareh = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblAdrsfull = New System.Windows.Forms.Label
        Me.TxtVname = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.DtppurDue = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtvCode = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblType = New System.Windows.Forms.Label
        Me.LblCurBal = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.ChkBx1 = New System.Windows.Forms.CheckBox
        Me.Cmbxstatus = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.dtpordrdt = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Chkprnt = New System.Windows.Forms.CheckBox
        Me.BtnPe_exit = New System.Windows.Forms.Button
        Me.BtnPe_Save = New System.Windows.Forms.Button
        Me.DtpInvDt = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Tplitem.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DgPurDirect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContxtDg1.SuspendLayout()
        Me.tplcustlist.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtSurChrg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtVATamt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtTxableAmt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblVATCST)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label32)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label40)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblRondOff)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblSurCharg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label41)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label42)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label43)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LbltablAmt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label26)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mskTxtVAtCst)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label35)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblgross)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbldiscount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label29)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbltoc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblsubttl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tplitem)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgPurDirect)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tplcustlist)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnPe_exit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnPe_Save)
        Me.SplitContainer1.Size = New System.Drawing.Size(1301, 619)
        Me.SplitContainer1.SplitterDistance = 576
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
        '
        'TxtSurChrg
        '
        Me.TxtSurChrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSurChrg.Enabled = False
        Me.TxtSurChrg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSurChrg.Location = New System.Drawing.Point(830, 542)
        Me.TxtSurChrg.Name = "TxtSurChrg"
        Me.TxtSurChrg.Size = New System.Drawing.Size(149, 21)
        Me.TxtSurChrg.TabIndex = 120
        Me.TxtSurChrg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtSurChrg.Visible = False
        '
        'TxtVATamt
        '
        Me.TxtVATamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVATamt.Enabled = False
        Me.TxtVATamt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVATamt.Location = New System.Drawing.Point(830, 517)
        Me.TxtVATamt.Name = "TxtVATamt"
        Me.TxtVATamt.Size = New System.Drawing.Size(149, 21)
        Me.TxtVATamt.TabIndex = 119
        Me.TxtVATamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtVATamt.Visible = False
        '
        'TxtTxableAmt
        '
        Me.TxtTxableAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTxableAmt.Enabled = False
        Me.TxtTxableAmt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTxableAmt.Location = New System.Drawing.Point(830, 493)
        Me.TxtTxableAmt.Name = "TxtTxableAmt"
        Me.TxtTxableAmt.Size = New System.Drawing.Size(149, 21)
        Me.TxtTxableAmt.TabIndex = 118
        Me.TxtTxableAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTxableAmt.Visible = False
        '
        'LblVATCST
        '
        Me.LblVATCST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblVATCST.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVATCST.Location = New System.Drawing.Point(653, 495)
        Me.LblVATCST.Name = "LblVATCST"
        Me.LblVATCST.Size = New System.Drawing.Size(149, 20)
        Me.LblVATCST.TabIndex = 117
        Me.LblVATCST.Text = "0"
        Me.LblVATCST.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(491, 514)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(140, 13)
        Me.Label32.TabIndex = 115
        Me.Label32.Text = "Surcharge (00.00%)"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(213, 552)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(146, 13)
        Me.Label40.TabIndex = 116
        Me.Label40.Text = "Diff Due To Round Off"
        '
        'LblRondOff
        '
        Me.LblRondOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRondOff.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRondOff.Location = New System.Drawing.Point(376, 552)
        Me.LblRondOff.Name = "LblRondOff"
        Me.LblRondOff.Size = New System.Drawing.Size(73, 20)
        Me.LblRondOff.TabIndex = 113
        Me.LblRondOff.Text = "0"
        Me.LblRondOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblSurCharg
        '
        Me.LblSurCharg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSurCharg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSurCharg.Location = New System.Drawing.Point(653, 514)
        Me.LblSurCharg.Name = "LblSurCharg"
        Me.LblSurCharg.Size = New System.Drawing.Size(149, 20)
        Me.LblSurCharg.TabIndex = 114
        Me.LblSurCharg.Text = "0"
        Me.LblSurCharg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(259, 476)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(100, 13)
        Me.Label41.TabIndex = 112
        Me.Label41.Text = "Less Discount:"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(526, 476)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(110, 13)
        Me.Label42.TabIndex = 110
        Me.Label42.Text = " = Taxable Amt."
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(12, 476)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(65, 13)
        Me.Label43.TabIndex = 111
        Me.Label43.Text = " Amount:"
        '
        'LbltablAmt
        '
        Me.LbltablAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbltablAmt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbltablAmt.Location = New System.Drawing.Point(653, 476)
        Me.LbltablAmt.Name = "LbltablAmt"
        Me.LbltablAmt.Size = New System.Drawing.Size(149, 20)
        Me.LbltablAmt.TabIndex = 109
        Me.LbltablAmt.Text = "0"
        Me.LbltablAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(577, 495)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 13)
        Me.Label26.TabIndex = 108
        Me.Label26.Text = "VAT/CST"
        '
        'mskTxtVAtCst
        '
        Me.mskTxtVAtCst.AsciiOnly = True
        Me.mskTxtVAtCst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskTxtVAtCst.Enabled = False
        Me.mskTxtVAtCst.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskTxtVAtCst.Location = New System.Drawing.Point(93, 510)
        Me.mskTxtVAtCst.Name = "mskTxtVAtCst"
        Me.mskTxtVAtCst.ReadOnly = True
        Me.mskTxtVAtCst.Size = New System.Drawing.Size(107, 21)
        Me.mskTxtVAtCst.TabIndex = 42
        Me.mskTxtVAtCst.Text = "0"
        Me.mskTxtVAtCst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.mskTxtVAtCst.Visible = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(561, 552)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(81, 13)
        Me.Label35.TabIndex = 87
        Me.Label35.Text = "Gross Total"
        '
        'lblgross
        '
        Me.lblgross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblgross.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgross.Location = New System.Drawing.Point(653, 552)
        Me.lblgross.Name = "lblgross"
        Me.lblgross.Size = New System.Drawing.Size(149, 20)
        Me.lblgross.TabIndex = 85
        Me.lblgross.Text = "0"
        Me.lblgross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbldiscount
        '
        Me.lbldiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbldiscount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldiscount.Location = New System.Drawing.Point(376, 476)
        Me.lbldiscount.Name = "lbldiscount"
        Me.lbldiscount.Size = New System.Drawing.Size(149, 20)
        Me.lbldiscount.TabIndex = 83
        Me.lbldiscount.Text = "0"
        Me.lbldiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(522, 533)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(115, 13)
        Me.Label29.TabIndex = 82
        Me.Label29.Text = "Total Of Charges"
        '
        'lbltoc
        '
        Me.lbltoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltoc.Location = New System.Drawing.Point(653, 533)
        Me.lbltoc.Name = "lbltoc"
        Me.lbltoc.Size = New System.Drawing.Size(149, 20)
        Me.lbltoc.TabIndex = 81
        Me.lbltoc.Text = "0"
        Me.lbltoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblsubttl
        '
        Me.lblsubttl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblsubttl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubttl.Location = New System.Drawing.Point(90, 476)
        Me.lblsubttl.Name = "lblsubttl"
        Me.lblsubttl.Size = New System.Drawing.Size(149, 20)
        Me.lblsubttl.TabIndex = 79
        Me.lblsubttl.Text = "0"
        Me.lblsubttl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Tplitem
        '
        Me.Tplitem.BackColor = System.Drawing.Color.Khaki
        Me.Tplitem.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tplitem.ColumnCount = 1
        Me.Tplitem.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tplitem.Controls.Add(Me.Panel3, 0, 0)
        Me.Tplitem.Controls.Add(Me.LstVewItem, 0, 1)
        Me.Tplitem.Enabled = False
        Me.Tplitem.Location = New System.Drawing.Point(826, 272)
        Me.Tplitem.Name = "Tplitem"
        Me.Tplitem.RowCount = 2
        Me.Tplitem.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.78182!))
        Me.Tplitem.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.21818!))
        Me.Tplitem.Size = New System.Drawing.Size(452, 194)
        Me.Tplitem.TabIndex = 35
        Me.Tplitem.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label39)
        Me.Panel3.Controls.Add(Me.CmbxStokGrup)
        Me.Panel3.Controls.Add(Me.RbxiName)
        Me.Panel3.Controls.Add(Me.Rbxicode)
        Me.Panel3.Controls.Add(Me.TxtItmcode)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(444, 37)
        Me.Panel3.TabIndex = 36
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(2, -2)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(73, 13)
        Me.Label39.TabIndex = 45
        Me.Label39.Text = "Item Group"
        '
        'CmbxStokGrup
        '
        Me.CmbxStokGrup.Enabled = False
        Me.CmbxStokGrup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxStokGrup.FormattingEnabled = True
        Me.CmbxStokGrup.Location = New System.Drawing.Point(4, 13)
        Me.CmbxStokGrup.Name = "CmbxStokGrup"
        Me.CmbxStokGrup.Size = New System.Drawing.Size(191, 21)
        Me.CmbxStokGrup.TabIndex = 44
        '
        'RbxiName
        '
        Me.RbxiName.AutoSize = True
        Me.RbxiName.Location = New System.Drawing.Point(200, 17)
        Me.RbxiName.Name = "RbxiName"
        Me.RbxiName.Size = New System.Drawing.Size(77, 17)
        Me.RbxiName.TabIndex = 37
        Me.RbxiName.Text = "By Name"
        Me.RbxiName.UseVisualStyleBackColor = True
        '
        'Rbxicode
        '
        Me.Rbxicode.AutoSize = True
        Me.Rbxicode.Checked = True
        Me.Rbxicode.Location = New System.Drawing.Point(200, 1)
        Me.Rbxicode.Name = "Rbxicode"
        Me.Rbxicode.Size = New System.Drawing.Size(74, 17)
        Me.Rbxicode.TabIndex = 37
        Me.Rbxicode.TabStop = True
        Me.Rbxicode.Text = "By Code"
        Me.Rbxicode.UseVisualStyleBackColor = True
        '
        'TxtItmcode
        '
        Me.TxtItmcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtItmcode.Location = New System.Drawing.Point(280, 9)
        Me.TxtItmcode.Name = "TxtItmcode"
        Me.TxtItmcode.Size = New System.Drawing.Size(157, 21)
        Me.TxtItmcode.TabIndex = 36
        '
        'LstVewItem
        '
        Me.LstVewItem.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.LstVewItem.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColIcode, Me.ColIname, Me.Coliid, Me.Colicost, Me.Colmin, Me.Colmax, Me.Colopn, Me.Colunt, Me.Collocid})
        Me.LstVewItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstVewItem.FullRowSelect = True
        Me.LstVewItem.GridLines = True
        Me.LstVewItem.Location = New System.Drawing.Point(4, 48)
        Me.LstVewItem.MultiSelect = False
        Me.LstVewItem.Name = "LstVewItem"
        Me.LstVewItem.Size = New System.Drawing.Size(444, 142)
        Me.LstVewItem.TabIndex = 38
        Me.LstVewItem.UseCompatibleStateImageBehavior = False
        Me.LstVewItem.View = System.Windows.Forms.View.Details
        '
        'ColIcode
        '
        Me.ColIcode.Text = "Code"
        '
        'ColIname
        '
        Me.ColIname.Text = "Name "
        Me.ColIname.Width = 250
        '
        'Coliid
        '
        Me.Coliid.Text = "Id"
        Me.Coliid.Width = 0
        '
        'Colicost
        '
        Me.Colicost.Text = "Rate"
        Me.Colicost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Colicost.Width = 100
        '
        'Colmin
        '
        Me.Colmin.Text = "Minimum Qnty."
        Me.Colmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Colmax
        '
        Me.Colmax.Text = "Maximum Qnty."
        Me.Colmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Colopn
        '
        Me.Colopn.Text = "Opening Qnty."
        Me.Colopn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Colunt
        '
        Me.Colunt.Text = "Unit Type"
        Me.Colunt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Collocid
        '
        Me.Collocid.Text = "Item Loc"
        Me.Collocid.Width = 0
        '
        'DgPurDirect
        '
        Me.DgPurDirect.AllowUserToAddRows = False
        Me.DgPurDirect.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.DgPurDirect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgPurDirect.ContextMenuStrip = Me.ContxtDg1
        Me.DgPurDirect.Location = New System.Drawing.Point(4, 307)
        Me.DgPurDirect.Name = "DgPurDirect"
        Me.DgPurDirect.Size = New System.Drawing.Size(816, 165)
        Me.DgPurDirect.TabIndex = 43
        Me.DgPurDirect.TabStop = False
        '
        'ContxtDg1
        '
        Me.ContxtDg1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem1, Me.ToolStripMenuItem5, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem})
        Me.ContxtDg1.Name = "ContxtDg1"
        Me.ContxtDg1.Size = New System.Drawing.Size(170, 158)
        Me.ContxtDg1.Text = "F&ile"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SaveToolStripMenuItem.Text = "&Update"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem3.Text = "Add New Item"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem4.Text = "Ed&it Taxable Value"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem1.Text = "E&dit VAT/CST"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem5.Text = "Edi&t Surcharge"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem2.Text = "De&lete "
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'tplcustlist
        '
        Me.tplcustlist.BackColor = System.Drawing.Color.Khaki
        Me.tplcustlist.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tplcustlist.ColumnCount = 1
        Me.tplcustlist.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tplcustlist.Controls.Add(Me.Panel2, 0, 0)
        Me.tplcustlist.Controls.Add(Me.lstvewcustlist, 0, 1)
        Me.tplcustlist.Enabled = False
        Me.tplcustlist.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tplcustlist.Location = New System.Drawing.Point(837, 4)
        Me.tplcustlist.Name = "tplcustlist"
        Me.tplcustlist.RowCount = 2
        Me.tplcustlist.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.99553!))
        Me.tplcustlist.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.00447!))
        Me.tplcustlist.Size = New System.Drawing.Size(392, 164)
        Me.tplcustlist.TabIndex = 45
        Me.tplcustlist.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RbxName)
        Me.Panel2.Controls.Add(Me.Rbxcode)
        Me.Panel2.Controls.Add(Me.Txtcustcode)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(384, 31)
        Me.Panel2.TabIndex = 46
        '
        'RbxName
        '
        Me.RbxName.AutoSize = True
        Me.RbxName.Checked = True
        Me.RbxName.Location = New System.Drawing.Point(3, 15)
        Me.RbxName.Name = "RbxName"
        Me.RbxName.Size = New System.Drawing.Size(121, 17)
        Me.RbxName.TabIndex = 47
        Me.RbxName.TabStop = True
        Me.RbxName.Text = "Search By Name"
        Me.RbxName.UseVisualStyleBackColor = True
        '
        'Rbxcode
        '
        Me.Rbxcode.AutoSize = True
        Me.Rbxcode.Location = New System.Drawing.Point(3, -1)
        Me.Rbxcode.Name = "Rbxcode"
        Me.Rbxcode.Size = New System.Drawing.Size(118, 17)
        Me.Rbxcode.TabIndex = 47
        Me.Rbxcode.Text = "Search By Code"
        Me.Rbxcode.UseVisualStyleBackColor = True
        '
        'Txtcustcode
        '
        Me.Txtcustcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtcustcode.Location = New System.Drawing.Point(135, 4)
        Me.Txtcustcode.Name = "Txtcustcode"
        Me.Txtcustcode.Size = New System.Drawing.Size(244, 21)
        Me.Txtcustcode.TabIndex = 46
        '
        'lstvewcustlist
        '
        Me.lstvewcustlist.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstvewcustlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.custCode, Me.custName, Me.custId, Me.FullAddress, Me.splrspcatid, Me.Colcarrid})
        Me.lstvewcustlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstvewcustlist.FullRowSelect = True
        Me.lstvewcustlist.GridLines = True
        Me.lstvewcustlist.Location = New System.Drawing.Point(4, 42)
        Me.lstvewcustlist.MultiSelect = False
        Me.lstvewcustlist.Name = "lstvewcustlist"
        Me.lstvewcustlist.Size = New System.Drawing.Size(384, 118)
        Me.lstvewcustlist.TabIndex = 48
        Me.lstvewcustlist.UseCompatibleStateImageBehavior = False
        Me.lstvewcustlist.View = System.Windows.Forms.View.Details
        '
        'custCode
        '
        Me.custCode.Text = "Code"
        '
        'custName
        '
        Me.custName.Text = "Name "
        Me.custName.Width = 250
        '
        'custId
        '
        Me.custId.Text = "Id"
        Me.custId.Width = 0
        '
        'FullAddress
        '
        Me.FullAddress.Text = "Full Address"
        Me.FullAddress.Width = 400
        '
        'splrspcatid
        '
        Me.splrspcatid.Text = "VAT/CST Id"
        Me.splrspcatid.Width = 0
        '
        'Colcarrid
        '
        Me.Colcarrid.Text = "Carri Id"
        Me.Colcarrid.Width = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.DtpInvDt)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Btnundrgrp)
        Me.Panel5.Controls.Add(Me.CmbxLdgrHead)
        Me.Panel5.Controls.Add(Me.Label27)
        Me.Panel5.Controls.Add(Me.MTxtTotlamt)
        Me.Panel5.Controls.Add(Me.BtnEditmode)
        Me.Panel5.Controls.Add(Me.btnSpcatadd)
        Me.Panel5.Controls.Add(Me.Label28)
        Me.Panel5.Controls.Add(Me.Cmbxspcatid)
        Me.Panel5.Controls.Add(Me.Chkbdisc)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.ChkbOthrCharg)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.ChkbCariDetals)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.TxtPurBillNo)
        Me.Panel5.Controls.Add(Me.BtnAddCarri)
        Me.Panel5.Controls.Add(Me.BtnAddCust)
        Me.Panel5.Controls.Add(Me.Btnaddware)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.Txtcoment)
        Me.Panel5.Controls.Add(Me.CmbxCarri)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.CmbxWareh)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.lblAdrsfull)
        Me.Panel5.Controls.Add(Me.TxtVname)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.DtppurDue)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.txtvCode)
        Me.Panel5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(4, 40)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(816, 266)
        Me.Panel5.TabIndex = 4
        '
        'Btnundrgrp
        '
        Me.Btnundrgrp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btnundrgrp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnundrgrp.Location = New System.Drawing.Point(454, 34)
        Me.Btnundrgrp.Name = "Btnundrgrp"
        Me.Btnundrgrp.Size = New System.Drawing.Size(26, 21)
        Me.Btnundrgrp.TabIndex = 101
        Me.Btnundrgrp.TabStop = False
        Me.Btnundrgrp.Text = "...."
        Me.Btnundrgrp.UseVisualStyleBackColor = True
        '
        'CmbxLdgrHead
        '
        Me.CmbxLdgrHead.AllowDrop = True
        Me.CmbxLdgrHead.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxLdgrHead.Location = New System.Drawing.Point(113, 35)
        Me.CmbxLdgrHead.Name = "CmbxLdgrHead"
        Me.CmbxLdgrHead.Size = New System.Drawing.Size(339, 21)
        Me.CmbxLdgrHead.Sorted = True
        Me.CmbxLdgrHead.TabIndex = 5
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(4, 35)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 13)
        Me.Label27.TabIndex = 100
        Me.Label27.Text = "Ldgr- Head"
        '
        'MTxtTotlamt
        '
        Me.MTxtTotlamt.AsciiOnly = True
        Me.MTxtTotlamt.BeepOnError = True
        Me.MTxtTotlamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MTxtTotlamt.Location = New System.Drawing.Point(649, 7)
        Me.MTxtTotlamt.Name = "MTxtTotlamt"
        Me.MTxtTotlamt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MTxtTotlamt.Size = New System.Drawing.Size(161, 21)
        Me.MTxtTotlamt.TabIndex = 4
        Me.MTxtTotlamt.Text = "0"
        Me.MTxtTotlamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnEditmode
        '
        Me.BtnEditmode.Enabled = False
        Me.BtnEditmode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditmode.Location = New System.Drawing.Point(454, 88)
        Me.BtnEditmode.Name = "BtnEditmode"
        Me.BtnEditmode.Size = New System.Drawing.Size(25, 21)
        Me.BtnEditmode.TabIndex = 83
        Me.BtnEditmode.TabStop = False
        Me.BtnEditmode.Text = "...."
        Me.BtnEditmode.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnEditmode.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtnEditmode.UseCompatibleTextRendering = True
        Me.BtnEditmode.UseVisualStyleBackColor = True
        '
        'btnSpcatadd
        '
        Me.btnSpcatadd.Location = New System.Drawing.Point(406, 232)
        Me.btnSpcatadd.Name = "btnSpcatadd"
        Me.btnSpcatadd.Size = New System.Drawing.Size(27, 22)
        Me.btnSpcatadd.TabIndex = 70
        Me.btnSpcatadd.TabStop = False
        Me.btnSpcatadd.Text = "...."
        Me.btnSpcatadd.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(3, 234)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(64, 13)
        Me.Label28.TabIndex = 78
        Me.Label28.Text = "VAT/CST"
        '
        'Cmbxspcatid
        '
        Me.Cmbxspcatid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxspcatid.Enabled = False
        Me.Cmbxspcatid.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxspcatid.FormattingEnabled = True
        Me.Cmbxspcatid.Items.AddRange(New Object() {"Discount Value", "Discount Percentage"})
        Me.Cmbxspcatid.Location = New System.Drawing.Point(80, 234)
        Me.Cmbxspcatid.Name = "Cmbxspcatid"
        Me.Cmbxspcatid.Size = New System.Drawing.Size(325, 21)
        Me.Cmbxspcatid.TabIndex = 29
        '
        'Chkbdisc
        '
        Me.Chkbdisc.AutoSize = True
        Me.Chkbdisc.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Chkbdisc.Location = New System.Drawing.Point(436, 231)
        Me.Chkbdisc.Name = "Chkbdisc"
        Me.Chkbdisc.Size = New System.Drawing.Size(35, 31)
        Me.Chkbdisc.TabIndex = 30
        Me.Chkbdisc.Text = "Dis."
        Me.Chkbdisc.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.Mtxtdisvalue)
        Me.Panel8.Controls.Add(Me.Label25)
        Me.Panel8.Controls.Add(Me.Label24)
        Me.Panel8.Controls.Add(Me.Cmbxdistype)
        Me.Panel8.Enabled = False
        Me.Panel8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel8.Location = New System.Drawing.Point(488, 232)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(322, 31)
        Me.Panel8.TabIndex = 31
        '
        'Mtxtdisvalue
        '
        Me.Mtxtdisvalue.AsciiOnly = True
        Me.Mtxtdisvalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Mtxtdisvalue.Location = New System.Drawing.Point(252, 3)
        Me.Mtxtdisvalue.Name = "Mtxtdisvalue"
        Me.Mtxtdisvalue.Size = New System.Drawing.Size(65, 21)
        Me.Mtxtdisvalue.TabIndex = 34
        Me.Mtxtdisvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(185, 4)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 61
        Me.Label25.Text = "Dis. Rate"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(4, 4)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(43, 13)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "Type."
        '
        'Cmbxdistype
        '
        Me.Cmbxdistype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxdistype.FormattingEnabled = True
        Me.Cmbxdistype.Items.AddRange(New Object() {"Discount Value", "Discount Percentage"})
        Me.Cmbxdistype.Location = New System.Drawing.Point(50, 3)
        Me.Cmbxdistype.Name = "Cmbxdistype"
        Me.Cmbxdistype.Size = New System.Drawing.Size(129, 21)
        Me.Cmbxdistype.TabIndex = 32
        '
        'ChkbOthrCharg
        '
        Me.ChkbOthrCharg.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ChkbOthrCharg.Location = New System.Drawing.Point(7, 143)
        Me.ChkbOthrCharg.Name = "ChkbOthrCharg"
        Me.ChkbOthrCharg.Size = New System.Drawing.Size(74, 54)
        Me.ChkbOthrCharg.TabIndex = 21
        Me.ChkbOthrCharg.Text = "Other Charges "
        Me.ChkbOthrCharg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkbOthrCharg.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.TxtPlcyno)
        Me.Panel7.Controls.Add(Me.TxtinsCo)
        Me.Panel7.Controls.Add(Me.Label22)
        Me.Panel7.Controls.Add(Me.Label21)
        Me.Panel7.Controls.Add(Me.MskInscharg)
        Me.Panel7.Controls.Add(Me.Label20)
        Me.Panel7.Controls.Add(Me.Mskothrchrg)
        Me.Panel7.Controls.Add(Me.Label16)
        Me.Panel7.Controls.Add(Me.MskPostcharg)
        Me.Panel7.Controls.Add(Me.Label8)
        Me.Panel7.Controls.Add(Me.MtxtPkgcharg)
        Me.Panel7.Controls.Add(Me.Label5)
        Me.Panel7.Enabled = False
        Me.Panel7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.Location = New System.Drawing.Point(81, 143)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(398, 86)
        Me.Panel7.TabIndex = 22
        '
        'TxtPlcyno
        '
        Me.TxtPlcyno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPlcyno.Location = New System.Drawing.Point(283, 31)
        Me.TxtPlcyno.Name = "TxtPlcyno"
        Me.TxtPlcyno.Size = New System.Drawing.Size(111, 21)
        Me.TxtPlcyno.TabIndex = 27
        '
        'TxtinsCo
        '
        Me.TxtinsCo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtinsCo.Location = New System.Drawing.Point(276, 59)
        Me.TxtinsCo.Name = "TxtinsCo"
        Me.TxtinsCo.Size = New System.Drawing.Size(118, 21)
        Me.TxtinsCo.TabIndex = 28
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(200, 59)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 72
        Me.Label22.Text = "Ins. Co."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(200, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 13)
        Me.Label21.TabIndex = 71
        Me.Label21.Text = "Ins. Pl. No."
        '
        'MskInscharg
        '
        Me.MskInscharg.AsciiOnly = True
        Me.MskInscharg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MskInscharg.Location = New System.Drawing.Point(297, 2)
        Me.MskInscharg.Name = "MskInscharg"
        Me.MskInscharg.Size = New System.Drawing.Size(97, 21)
        Me.MskInscharg.TabIndex = 26
        Me.MskInscharg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(200, 2)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(89, 13)
        Me.Label20.TabIndex = 69
        Me.Label20.Text = "Ins. Charges"
        '
        'Mskothrchrg
        '
        Me.Mskothrchrg.AsciiOnly = True
        Me.Mskothrchrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Mskothrchrg.Location = New System.Drawing.Point(102, 59)
        Me.Mskothrchrg.Name = "Mskothrchrg"
        Me.Mskothrchrg.Size = New System.Drawing.Size(97, 21)
        Me.Mskothrchrg.TabIndex = 25
        Me.Mskothrchrg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(-1, 59)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 13)
        Me.Label16.TabIndex = 67
        Me.Label16.Text = "Other Charges"
        '
        'MskPostcharg
        '
        Me.MskPostcharg.AsciiOnly = True
        Me.MskPostcharg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MskPostcharg.Location = New System.Drawing.Point(102, 31)
        Me.MskPostcharg.Name = "MskPostcharg"
        Me.MskPostcharg.Size = New System.Drawing.Size(97, 21)
        Me.MskPostcharg.TabIndex = 24
        Me.MskPostcharg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(-1, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Post. Charges"
        '
        'MtxtPkgcharg
        '
        Me.MtxtPkgcharg.AsciiOnly = True
        Me.MtxtPkgcharg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MtxtPkgcharg.Location = New System.Drawing.Point(102, 2)
        Me.MtxtPkgcharg.Name = "MtxtPkgcharg"
        Me.MtxtPkgcharg.Size = New System.Drawing.Size(97, 21)
        Me.MtxtPkgcharg.TabIndex = 23
        Me.MtxtPkgcharg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(-1, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Pack. Charges"
        '
        'ChkbCariDetals
        '
        Me.ChkbCariDetals.AutoSize = True
        Me.ChkbCariDetals.Location = New System.Drawing.Point(488, 94)
        Me.ChkbCariDetals.Name = "ChkbCariDetals"
        Me.ChkbCariDetals.Size = New System.Drawing.Size(135, 17)
        Me.ChkbCariDetals.TabIndex = 12
        Me.ChkbCariDetals.Text = "Carriage Details "
        Me.ChkbCariDetals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkbCariDetals.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Dtpgrdt)
        Me.Panel6.Controls.Add(Me.mtxtulcharg)
        Me.Panel6.Controls.Add(Me.Label19)
        Me.Panel6.Controls.Add(Me.Label18)
        Me.Panel6.Controls.Add(Me.Label17)
        Me.Panel6.Controls.Add(Me.Label15)
        Me.Panel6.Controls.Add(Me.MtxtfrtChargs)
        Me.Panel6.Controls.Add(Me.TxtCariNo)
        Me.Panel6.Controls.Add(Me.Txtgrno)
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.Txtuload)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Enabled = False
        Me.Panel6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.Location = New System.Drawing.Point(488, 120)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(322, 109)
        Me.Panel6.TabIndex = 13
        '
        'Dtpgrdt
        '
        Me.Dtpgrdt.CustomFormat = "dd/MM/yyyy"
        Me.Dtpgrdt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpgrdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpgrdt.Location = New System.Drawing.Point(235, 27)
        Me.Dtpgrdt.Name = "Dtpgrdt"
        Me.Dtpgrdt.Size = New System.Drawing.Size(82, 20)
        Me.Dtpgrdt.TabIndex = 17
        '
        'mtxtulcharg
        '
        Me.mtxtulcharg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mtxtulcharg.Location = New System.Drawing.Point(107, 55)
        Me.mtxtulcharg.Name = "mtxtulcharg"
        Me.mtxtulcharg.Size = New System.Drawing.Size(77, 21)
        Me.mtxtulcharg.TabIndex = 18
        Me.mtxtulcharg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 57)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(86, 13)
        Me.Label19.TabIndex = 86
        Me.Label19.Text = "U-L Charges"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 81)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 13)
        Me.Label18.TabIndex = 85
        Me.Label18.Text = "Un-Loaded By "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 28)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 13)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "Carriage No."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(186, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 83
        Me.Label15.Text = "GR Dt."
        '
        'MtxtfrtChargs
        '
        Me.MtxtfrtChargs.AsciiOnly = True
        Me.MtxtfrtChargs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MtxtfrtChargs.Location = New System.Drawing.Point(107, 3)
        Me.MtxtfrtChargs.Name = "MtxtfrtChargs"
        Me.MtxtfrtChargs.Size = New System.Drawing.Size(77, 21)
        Me.MtxtfrtChargs.TabIndex = 14
        Me.MtxtfrtChargs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCariNo
        '
        Me.TxtCariNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCariNo.Location = New System.Drawing.Point(107, 29)
        Me.TxtCariNo.Name = "TxtCariNo"
        Me.TxtCariNo.Size = New System.Drawing.Size(77, 21)
        Me.TxtCariNo.TabIndex = 16
        '
        'Txtgrno
        '
        Me.Txtgrno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtgrno.Location = New System.Drawing.Point(243, 1)
        Me.Txtgrno.Name = "Txtgrno"
        Me.Txtgrno.Size = New System.Drawing.Size(74, 21)
        Me.Txtgrno.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(191, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "GR No."
        '
        'Txtuload
        '
        Me.Txtuload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtuload.Location = New System.Drawing.Point(107, 79)
        Me.Txtuload.Name = "Txtuload"
        Me.Txtuload.Size = New System.Drawing.Size(210, 21)
        Me.Txtuload.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 13)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "Feight Charges"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(579, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Inv. Amt."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Invoice  No."
        '
        'TxtPurBillNo
        '
        Me.TxtPurBillNo.BackColor = System.Drawing.Color.White
        Me.TxtPurBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPurBillNo.Location = New System.Drawing.Point(113, 6)
        Me.TxtPurBillNo.Name = "TxtPurBillNo"
        Me.TxtPurBillNo.Size = New System.Drawing.Size(122, 21)
        Me.TxtPurBillNo.TabIndex = 2
        '
        'BtnAddCarri
        '
        Me.BtnAddCarri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddCarri.Location = New System.Drawing.Point(785, 64)
        Me.BtnAddCarri.Name = "BtnAddCarri"
        Me.BtnAddCarri.Size = New System.Drawing.Size(25, 21)
        Me.BtnAddCarri.TabIndex = 69
        Me.BtnAddCarri.TabStop = False
        Me.BtnAddCarri.Text = "...."
        Me.BtnAddCarri.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAddCarri.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtnAddCarri.UseCompatibleTextRendering = True
        Me.BtnAddCarri.UseVisualStyleBackColor = True
        '
        'BtnAddCust
        '
        Me.BtnAddCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddCust.Location = New System.Drawing.Point(454, 61)
        Me.BtnAddCust.Name = "BtnAddCust"
        Me.BtnAddCust.Size = New System.Drawing.Size(25, 21)
        Me.BtnAddCust.TabIndex = 67
        Me.BtnAddCust.Text = "...."
        Me.BtnAddCust.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAddCust.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtnAddCust.UseCompatibleTextRendering = True
        Me.BtnAddCust.UseVisualStyleBackColor = True
        '
        'Btnaddware
        '
        Me.Btnaddware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnaddware.Location = New System.Drawing.Point(785, 35)
        Me.Btnaddware.Name = "Btnaddware"
        Me.Btnaddware.Size = New System.Drawing.Size(25, 21)
        Me.Btnaddware.TabIndex = 68
        Me.Btnaddware.TabStop = False
        Me.Btnaddware.Text = "...."
        Me.Btnaddware.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btnaddware.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.Btnaddware.UseCompatibleTextRendering = True
        Me.Btnaddware.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Comments"
        '
        'Txtcoment
        '
        Me.Txtcoment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtcoment.Location = New System.Drawing.Point(113, 120)
        Me.Txtcoment.Name = "Txtcoment"
        Me.Txtcoment.Size = New System.Drawing.Size(366, 21)
        Me.Txtcoment.TabIndex = 20
        '
        'CmbxCarri
        '
        Me.CmbxCarri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCarri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxCarri.FormattingEnabled = True
        Me.CmbxCarri.Location = New System.Drawing.Point(547, 64)
        Me.CmbxCarri.Name = "CmbxCarri"
        Me.CmbxCarri.Size = New System.Drawing.Size(236, 21)
        Me.CmbxCarri.TabIndex = 11
        Me.CmbxCarri.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(485, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Tpt. Co."
        '
        'CmbxWareh
        '
        Me.CmbxWareh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxWareh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxWareh.FormattingEnabled = True
        Me.CmbxWareh.Location = New System.Drawing.Point(597, 35)
        Me.CmbxWareh.Name = "CmbxWareh"
        Me.CmbxWareh.Size = New System.Drawing.Size(187, 21)
        Me.CmbxWareh.TabIndex = 10
        Me.CmbxWareh.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(485, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Store Location"
        '
        'lblAdrsfull
        '
        Me.lblAdrsfull.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblAdrsfull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAdrsfull.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdrsfull.Location = New System.Drawing.Point(113, 85)
        Me.lblAdrsfull.Name = "lblAdrsfull"
        Me.lblAdrsfull.Size = New System.Drawing.Size(339, 32)
        Me.lblAdrsfull.TabIndex = 57
        Me.lblAdrsfull.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtVname
        '
        Me.TxtVname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVname.Location = New System.Drawing.Point(170, 62)
        Me.TxtVname.Name = "TxtVname"
        Me.TxtVname.ReadOnly = True
        Me.TxtVname.Size = New System.Drawing.Size(282, 20)
        Me.TxtVname.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Vender Name"
        '
        'DtppurDue
        '
        Me.DtppurDue.CustomFormat = "dd/MM/yyyy"
        Me.DtppurDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtppurDue.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtppurDue.Location = New System.Drawing.Point(475, 5)
        Me.DtppurDue.Name = "DtppurDue"
        Me.DtppurDue.Size = New System.Drawing.Size(98, 20)
        Me.DtppurDue.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(404, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Due Date"
        '
        'txtvCode
        '
        Me.txtvCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtvCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvCode.Location = New System.Drawing.Point(113, 62)
        Me.txtvCode.Name = "txtvCode"
        Me.txtvCode.ReadOnly = True
        Me.txtvCode.Size = New System.Drawing.Size(53, 20)
        Me.txtvCode.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LblType)
        Me.Panel1.Controls.Add(Me.LblCurBal)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.ChkBx1)
        Me.Panel1.Controls.Add(Me.Cmbxstatus)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.dtpordrdt)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Chkprnt)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(819, 35)
        Me.Panel1.TabIndex = 0
        '
        'LblType
        '
        Me.LblType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblType.ForeColor = System.Drawing.Color.Black
        Me.LblType.Location = New System.Drawing.Point(731, 7)
        Me.LblType.Name = "LblType"
        Me.LblType.Size = New System.Drawing.Size(24, 20)
        Me.LblType.TabIndex = 129
        Me.LblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCurBal
        '
        Me.LblCurBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCurBal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurBal.ForeColor = System.Drawing.Color.Black
        Me.LblCurBal.Location = New System.Drawing.Point(596, 7)
        Me.LblCurBal.Name = "LblCurBal"
        Me.LblCurBal.Size = New System.Drawing.Size(129, 20)
        Me.LblCurBal.TabIndex = 128
        Me.LblCurBal.Text = "0.00"
        Me.LblCurBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(448, 7)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(142, 20)
        Me.Label23.TabIndex = 127
        Me.Label23.Text = "CLOSING BALANCE:-"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChkBx1
        '
        Me.ChkBx1.AutoSize = True
        Me.ChkBx1.Location = New System.Drawing.Point(152, 7)
        Me.ChkBx1.Name = "ChkBx1"
        Me.ChkBx1.Size = New System.Drawing.Size(101, 17)
        Me.ChkBx1.TabIndex = 65
        Me.ChkBx1.TabStop = False
        Me.ChkBx1.Text = "+ Customer"
        Me.ChkBx1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkBx1.UseVisualStyleBackColor = True
        '
        'Cmbxstatus
        '
        Me.Cmbxstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxstatus.FormattingEnabled = True
        Me.Cmbxstatus.Items.AddRange(New Object() {"Cash Purchase", "Credit Purchase"})
        Me.Cmbxstatus.Location = New System.Drawing.Point(310, 7)
        Me.Cmbxstatus.Name = "Cmbxstatus"
        Me.Cmbxstatus.Size = New System.Drawing.Size(127, 21)
        Me.Cmbxstatus.Sorted = True
        Me.Cmbxstatus.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(258, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Status"
        '
        'dtpordrdt
        '
        Me.dtpordrdt.CustomFormat = "dd/MM/yyyy"
        Me.dtpordrdt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpordrdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpordrdt.Location = New System.Drawing.Point(47, 7)
        Me.dtpordrdt.Name = "dtpordrdt"
        Me.dtpordrdt.Size = New System.Drawing.Size(99, 20)
        Me.dtpordrdt.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Date"
        '
        'Chkprnt
        '
        Me.Chkprnt.AutoSize = True
        Me.Chkprnt.Location = New System.Drawing.Point(759, 7)
        Me.Chkprnt.Name = "Chkprnt"
        Me.Chkprnt.Size = New System.Drawing.Size(57, 17)
        Me.Chkprnt.TabIndex = 3
        Me.Chkprnt.Text = "Prnt."
        Me.Chkprnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Chkprnt.UseVisualStyleBackColor = True
        '
        'BtnPe_exit
        '
        Me.BtnPe_exit.BackColor = System.Drawing.Color.Transparent
        Me.BtnPe_exit.BackgroundImage = CType(resources.GetObject("BtnPe_exit.BackgroundImage"), System.Drawing.Image)
        Me.BtnPe_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPe_exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPe_exit.FlatAppearance.BorderSize = 0
        Me.BtnPe_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPe_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPe_exit.ForeColor = System.Drawing.Color.Navy
        Me.BtnPe_exit.Location = New System.Drawing.Point(689, 3)
        Me.BtnPe_exit.Name = "BtnPe_exit"
        Me.BtnPe_exit.Size = New System.Drawing.Size(133, 33)
        Me.BtnPe_exit.TabIndex = 45
        Me.BtnPe_exit.Text = "&Close"
        Me.BtnPe_exit.UseVisualStyleBackColor = False
        '
        'BtnPe_Save
        '
        Me.BtnPe_Save.BackColor = System.Drawing.Color.Transparent
        Me.BtnPe_Save.BackgroundImage = CType(resources.GetObject("BtnPe_Save.BackgroundImage"), System.Drawing.Image)
        Me.BtnPe_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPe_Save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPe_Save.FlatAppearance.BorderSize = 0
        Me.BtnPe_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPe_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPe_Save.ForeColor = System.Drawing.Color.Navy
        Me.BtnPe_Save.Location = New System.Drawing.Point(551, 3)
        Me.BtnPe_Save.Name = "BtnPe_Save"
        Me.BtnPe_Save.Size = New System.Drawing.Size(133, 33)
        Me.BtnPe_Save.TabIndex = 44
        Me.BtnPe_Save.Text = "&Update"
        Me.BtnPe_Save.UseVisualStyleBackColor = False
        '
        'DtpInvDt
        '
        Me.DtpInvDt.CustomFormat = "dd/MM/yyyy"
        Me.DtpInvDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpInvDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpInvDt.Location = New System.Drawing.Point(302, 5)
        Me.DtpInvDt.Name = "DtpInvDt"
        Me.DtpInvDt.Size = New System.Drawing.Size(98, 20)
        Me.DtpInvDt.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(239, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Inv. Dt."
        '
        'FrmTranPurEnteryDirectEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Turquoise
        Me.ClientSize = New System.Drawing.Size(1038, 622)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTranPurEnteryDirectEdit"
        Me.Text = "Purchase Entry Edit  (Direct Purchase Without Purchase Order)"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Tplitem.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DgPurDirect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContxtDg1.ResumeLayout(False)
        Me.tplcustlist.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Chkprnt As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    'Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents BtnPe_Save As System.Windows.Forms.Button
    Friend WithEvents BtnPe_exit As System.Windows.Forms.Button
    Friend WithEvents dtpordrdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPurBillNo As System.Windows.Forms.TextBox
    Friend WithEvents BtnAddCarri As System.Windows.Forms.Button
    Friend WithEvents BtnAddCust As System.Windows.Forms.Button
    Friend WithEvents Btnaddware As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Txtcoment As System.Windows.Forms.TextBox
    Friend WithEvents CmbxCarri As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbxWareh As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblAdrsfull As System.Windows.Forms.Label
    Friend WithEvents TxtVname As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DtppurDue As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtvCode As System.Windows.Forms.TextBox
    Friend WithEvents Cmbxstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ChkbCariDetals As System.Windows.Forms.CheckBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TxtCariNo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txtuload As System.Windows.Forms.TextBox
    Friend WithEvents Txtgrno As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents MtxtfrtChargs As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents mtxtulcharg As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Dtpgrdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkbOthrCharg As System.Windows.Forms.CheckBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents MtxtPkgcharg As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Mskothrchrg As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents MskPostcharg As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents MskInscharg As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtPlcyno As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtinsCo As System.Windows.Forms.TextBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Chkbdisc As System.Windows.Forms.CheckBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Cmbxdistype As System.Windows.Forms.ComboBox
    Friend WithEvents Mtxtdisvalue As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents tplcustlist As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Txtcustcode As System.Windows.Forms.TextBox
    Friend WithEvents lstvewcustlist As System.Windows.Forms.ListView
    Friend WithEvents custCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents custName As System.Windows.Forms.ColumnHeader
    Friend WithEvents custId As System.Windows.Forms.ColumnHeader
    Friend WithEvents FullAddress As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Cmbxspcatid As System.Windows.Forms.ComboBox
    Friend WithEvents btnSpcatadd As System.Windows.Forms.Button
    Friend WithEvents splrspcatid As System.Windows.Forms.ColumnHeader
    Friend WithEvents DgPurDirect As System.Windows.Forms.DataGridView
    Friend WithEvents Tplitem As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtItmcode As System.Windows.Forms.TextBox
    Friend WithEvents LstVewItem As System.Windows.Forms.ListView
    Friend WithEvents ColIcode As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColIname As System.Windows.Forms.ColumnHeader
    Friend WithEvents Coliid As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colicost As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colmin As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colmax As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colopn As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colunt As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContxtDg1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsubttl As System.Windows.Forms.Label
    Friend WithEvents lbldiscount As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lbltoc As System.Windows.Forms.Label
    Friend WithEvents mskTxtVAtCst As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lblgross As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Collocid As System.Windows.Forms.ColumnHeader
    Friend WithEvents RbxName As System.Windows.Forms.RadioButton
    Friend WithEvents Rbxcode As System.Windows.Forms.RadioButton
    Friend WithEvents RbxiName As System.Windows.Forms.RadioButton
    Friend WithEvents Rbxicode As System.Windows.Forms.RadioButton
    Friend WithEvents Colcarrid As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChkBx1 As System.Windows.Forms.CheckBox
    Friend WithEvents LblVATCST As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents LblRondOff As System.Windows.Forms.Label
    Friend WithEvents LblSurCharg As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents LbltablAmt As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents BtnEditmode As System.Windows.Forms.Button
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents CmbxStokGrup As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtSurChrg As System.Windows.Forms.TextBox
    Friend WithEvents TxtVATamt As System.Windows.Forms.TextBox
    Friend WithEvents TxtTxableAmt As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MTxtTotlamt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Btnundrgrp As System.Windows.Forms.Button
    Friend WithEvents CmbxLdgrHead As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents LblType As System.Windows.Forms.Label
    Friend WithEvents LblCurBal As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DtpInvDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

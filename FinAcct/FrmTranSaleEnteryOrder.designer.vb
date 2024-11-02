<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTranSaleEnteryOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTranSaleEnteryOrder))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.CmbxAdnlDis = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.RbAdnl2 = New System.Windows.Forms.RadioButton
        Me.RbAdnl1 = New System.Windows.Forms.RadioButton
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.LblVATCST = New System.Windows.Forms.Label
        Me.LblRondOff = New System.Windows.Forms.Label
        Me.LblSurCharg = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.LbltablAmt = New System.Windows.Forms.Label
        Me.MskAdlDis = New System.Windows.Forms.MaskedTextBox
        Me.LblAdlDis = New System.Windows.Forms.Label
        Me.ChkVatInfo = New System.Windows.Forms.CheckBox
        Me.Pnlvatinfo = New System.Windows.Forms.Panel
        Me.MskinvVat = New System.Windows.Forms.MaskedTextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.MskInvamt = New System.Windows.Forms.MaskedTextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.DtpInvvatdt = New System.Windows.Forms.DateTimePicker
        Me.TxtVatinvno = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.mskTxtVAtCst = New System.Windows.Forms.MaskedTextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.lblgross = New System.Windows.Forms.Label
        Me.lbldiscount = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.lbltoc = New System.Windows.Forms.Label
        Me.lblsubttl = New System.Windows.Forms.Label
        Me.Tplitem = New System.Windows.Forms.TableLayoutPanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Cmbxitem = New System.Windows.Forms.ComboBox
        Me.TxtItmname = New System.Windows.Forms.TextBox
        Me.TxtItmcode = New System.Windows.Forms.TextBox
        Me.BtnItem = New System.Windows.Forms.Button
        Me.LstVewItem = New System.Windows.Forms.ListView
        Me.ColIcode = New System.Windows.Forms.ColumnHeader
        Me.ColIname = New System.Windows.Forms.ColumnHeader
        Me.Coliid = New System.Windows.Forms.ColumnHeader
        Me.Colicost = New System.Windows.Forms.ColumnHeader
        Me.Colmin = New System.Windows.Forms.ColumnHeader
        Me.Colmax = New System.Windows.Forms.ColumnHeader
        Me.Colopn = New System.Windows.Forms.ColumnHeader
        Me.Colunt = New System.Windows.Forms.ColumnHeader
        Me.DgSaleDirect = New System.Windows.Forms.DataGridView
        Me.tplcustlist = New System.Windows.Forms.TableLayoutPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Txtcustname = New System.Windows.Forms.TextBox
        Me.Txtcustcode = New System.Windows.Forms.TextBox
        Me.BtnCloselist = New System.Windows.Forms.Button
        Me.lstvewcustlist = New System.Windows.Forms.ListView
        Me.custCode = New System.Windows.Forms.ColumnHeader
        Me.custName = New System.Windows.Forms.ColumnHeader
        Me.custId = New System.Windows.Forms.ColumnHeader
        Me.FullAddress = New System.Windows.Forms.ColumnHeader
        Me.splrspcatid = New System.Windows.Forms.ColumnHeader
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Btnundrgrp = New System.Windows.Forms.Button
        Me.CmbxLdgrHead = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.CmbxAgent = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
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
        Me.MTxtTotlamt = New System.Windows.Forms.MaskedTextBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Rbpaid = New System.Windows.Forms.RadioButton
        Me.Rb2pay = New System.Windows.Forms.RadioButton
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtPvtMrk = New System.Windows.Forms.TextBox
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
        Me.TxtGrsWt = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtSaleBillNo = New System.Windows.Forms.TextBox
        Me.BtnAddCarri = New System.Windows.Forms.Button
        Me.Btnaddware = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Txtcoment = New System.Windows.Forms.TextBox
        Me.CmbxPlist = New System.Windows.Forms.ComboBox
        Me.CmbxCarri = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbxWareh = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblAdrsfull = New System.Windows.Forms.Label
        Me.TxtVname = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.DtpSaleDue = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtvCode = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblType = New System.Windows.Forms.Label
        Me.LblCurBal = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.RbSbill2 = New System.Windows.Forms.RadioButton
        Me.RbSbill1 = New System.Windows.Forms.RadioButton
        Me.Cmbxstatus = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.dtpordrdt = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnPe_exit = New System.Windows.Forms.Button
        Me.BtnPe_Save = New System.Windows.Forms.Button
        Me.ContxtDg1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Pnlvatinfo.SuspendLayout()
        Me.Tplitem.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DgSaleDirect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tplcustlist.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.ContxtDg1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbxAdnlDis)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label33)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RbAdnl2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RbAdnl1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label32)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label40)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label41)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblVATCST)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblRondOff)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblSurCharg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label42)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label43)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label44)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label45)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LbltablAmt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MskAdlDis)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblAdlDis)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkVatInfo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Pnlvatinfo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mskTxtVAtCst)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label35)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblgross)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbldiscount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label29)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbltoc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblsubttl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tplitem)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgSaleDirect)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1229, 631)
        Me.SplitContainer1.SplitterDistance = 590
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
        '
        'CmbxAdnlDis
        '
        Me.CmbxAdnlDis.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxAdnlDis.FormattingEnabled = True
        Me.CmbxAdnlDis.Items.AddRange(New Object() {"SPECIAL ADDITIONAL DISCOUNT.", "SPECIAL FESTIVAL DISCOUNT.", "DIWALI  DISCOUNT.", "HOLI DISCOUNT.", "NEW YEAR DISCOUNT."})
        Me.CmbxAdnlDis.Location = New System.Drawing.Point(236, 514)
        Me.CmbxAdnlDis.Name = "CmbxAdnlDis"
        Me.CmbxAdnlDis.Size = New System.Drawing.Size(247, 21)
        Me.CmbxAdnlDis.TabIndex = 107
        Me.CmbxAdnlDis.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(163, 515)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(68, 13)
        Me.Label33.TabIndex = 108
        Me.Label33.Text = "Spl. Narr."
        Me.Label33.Visible = False
        '
        'RbAdnl2
        '
        Me.RbAdnl2.AutoSize = True
        Me.RbAdnl2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbAdnl2.Location = New System.Drawing.Point(553, 511)
        Me.RbAdnl2.Name = "RbAdnl2"
        Me.RbAdnl2.Size = New System.Drawing.Size(51, 17)
        Me.RbAdnl2.TabIndex = 48
        Me.RbAdnl2.Text = "(%)"
        Me.RbAdnl2.UseVisualStyleBackColor = True
        Me.RbAdnl2.Visible = False
        '
        'RbAdnl1
        '
        Me.RbAdnl1.AutoSize = True
        Me.RbAdnl1.Checked = True
        Me.RbAdnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbAdnl1.Location = New System.Drawing.Point(488, 511)
        Me.RbAdnl1.Name = "RbAdnl1"
        Me.RbAdnl1.Size = New System.Drawing.Size(61, 17)
        Me.RbAdnl1.TabIndex = 48
        Me.RbAdnl1.TabStop = True
        Me.RbAdnl1.Text = "Value"
        Me.RbAdnl1.UseVisualStyleBackColor = True
        Me.RbAdnl1.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(534, 529)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(140, 13)
        Me.Label32.TabIndex = 100
        Me.Label32.Text = "Surcharge (00.00%)"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(254, 567)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(146, 13)
        Me.Label40.TabIndex = 101
        Me.Label40.Text = "Diff Due To Round Off"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(610, 510)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(64, 13)
        Me.Label41.TabIndex = 99
        Me.Label41.Text = "VAT/CST"
        '
        'LblVATCST
        '
        Me.LblVATCST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblVATCST.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVATCST.Location = New System.Drawing.Point(678, 510)
        Me.LblVATCST.Name = "LblVATCST"
        Me.LblVATCST.Size = New System.Drawing.Size(123, 20)
        Me.LblVATCST.TabIndex = 97
        Me.LblVATCST.Text = "0"
        Me.LblVATCST.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblRondOff
        '
        Me.LblRondOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRondOff.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRondOff.Location = New System.Drawing.Point(404, 567)
        Me.LblRondOff.Name = "LblRondOff"
        Me.LblRondOff.Size = New System.Drawing.Size(73, 20)
        Me.LblRondOff.TabIndex = 98
        Me.LblRondOff.Text = "0"
        Me.LblRondOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblSurCharg
        '
        Me.LblSurCharg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSurCharg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSurCharg.Location = New System.Drawing.Point(678, 529)
        Me.LblSurCharg.Name = "LblSurCharg"
        Me.LblSurCharg.Size = New System.Drawing.Size(123, 20)
        Me.LblSurCharg.TabIndex = 96
        Me.LblSurCharg.Text = "0"
        Me.LblSurCharg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(328, 491)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(72, 13)
        Me.Label42.TabIndex = 94
        Me.Label42.Text = "Adnl. Dis.:"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(165, 491)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(68, 13)
        Me.Label43.TabIndex = 95
        Me.Label43.Text = "Less Dis.:"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(568, 491)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(106, 13)
        Me.Label44.TabIndex = 92
        Me.Label44.Text = "= Taxable Amt."
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(2, 491)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(61, 13)
        Me.Label45.TabIndex = 93
        Me.Label45.Text = "Amount:"
        '
        'LbltablAmt
        '
        Me.LbltablAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbltablAmt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbltablAmt.Location = New System.Drawing.Point(678, 491)
        Me.LbltablAmt.Name = "LbltablAmt"
        Me.LbltablAmt.Size = New System.Drawing.Size(123, 20)
        Me.LbltablAmt.TabIndex = 91
        Me.LbltablAmt.Text = "0"
        Me.LbltablAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MskAdlDis
        '
        Me.MskAdlDis.AsciiOnly = True
        Me.MskAdlDis.BackColor = System.Drawing.Color.White
        Me.MskAdlDis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MskAdlDis.Enabled = False
        Me.MskAdlDis.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MskAdlDis.Location = New System.Drawing.Point(404, 491)
        Me.MskAdlDis.Name = "MskAdlDis"
        Me.MskAdlDis.Size = New System.Drawing.Size(80, 21)
        Me.MskAdlDis.TabIndex = 47
        Me.MskAdlDis.Text = "0"
        Me.MskAdlDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblAdlDis
        '
        Me.LblAdlDis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAdlDis.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdlDis.Location = New System.Drawing.Point(486, 491)
        Me.LblAdlDis.Name = "LblAdlDis"
        Me.LblAdlDis.Size = New System.Drawing.Size(78, 20)
        Me.LblAdlDis.TabIndex = 89
        Me.LblAdlDis.Text = "0"
        Me.LblAdlDis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChkVatInfo
        '
        Me.ChkVatInfo.AutoSize = True
        Me.ChkVatInfo.Enabled = False
        Me.ChkVatInfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkVatInfo.Location = New System.Drawing.Point(237, 544)
        Me.ChkVatInfo.Name = "ChkVatInfo"
        Me.ChkVatInfo.Size = New System.Drawing.Size(118, 17)
        Me.ChkVatInfo.TabIndex = 41
        Me.ChkVatInfo.Text = "VAT/CST Info."
        Me.ChkVatInfo.UseVisualStyleBackColor = True
        Me.ChkVatInfo.Visible = False
        '
        'Pnlvatinfo
        '
        Me.Pnlvatinfo.BackColor = System.Drawing.Color.SpringGreen
        Me.Pnlvatinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnlvatinfo.Controls.Add(Me.MskinvVat)
        Me.Pnlvatinfo.Controls.Add(Me.Label38)
        Me.Pnlvatinfo.Controls.Add(Me.MskInvamt)
        Me.Pnlvatinfo.Controls.Add(Me.Label37)
        Me.Pnlvatinfo.Controls.Add(Me.Label36)
        Me.Pnlvatinfo.Controls.Add(Me.DtpInvvatdt)
        Me.Pnlvatinfo.Controls.Add(Me.TxtVatinvno)
        Me.Pnlvatinfo.Controls.Add(Me.Label34)
        Me.Pnlvatinfo.Enabled = False
        Me.Pnlvatinfo.Location = New System.Drawing.Point(837, 166)
        Me.Pnlvatinfo.Name = "Pnlvatinfo"
        Me.Pnlvatinfo.Size = New System.Drawing.Size(176, 104)
        Me.Pnlvatinfo.TabIndex = 42
        Me.Pnlvatinfo.Visible = False
        '
        'MskinvVat
        '
        Me.MskinvVat.AsciiOnly = True
        Me.MskinvVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MskinvVat.Location = New System.Drawing.Point(68, 80)
        Me.MskinvVat.Name = "MskinvVat"
        Me.MskinvVat.Size = New System.Drawing.Size(100, 20)
        Me.MskinvVat.TabIndex = 46
        Me.MskinvVat.Text = "0"
        Me.MskinvVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(3, 83)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(57, 13)
        Me.Label38.TabIndex = 35
        Me.Label38.Text = "VAT/CST "
        '
        'MskInvamt
        '
        Me.MskInvamt.AsciiOnly = True
        Me.MskInvamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MskInvamt.Location = New System.Drawing.Point(68, 54)
        Me.MskInvamt.Name = "MskInvamt"
        Me.MskInvamt.Size = New System.Drawing.Size(100, 20)
        Me.MskInvamt.TabIndex = 45
        Me.MskInvamt.Text = "0"
        Me.MskInvamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(3, 57)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(64, 13)
        Me.Label37.TabIndex = 4
        Me.Label37.Text = "Inv. Amount"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(3, 32)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(30, 13)
        Me.Label36.TabIndex = 3
        Me.Label36.Text = "Date"
        '
        'DtpInvvatdt
        '
        Me.DtpInvvatdt.CustomFormat = "dd/MM/yyyy"
        Me.DtpInvvatdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpInvvatdt.Location = New System.Drawing.Point(68, 28)
        Me.DtpInvvatdt.Name = "DtpInvvatdt"
        Me.DtpInvvatdt.Size = New System.Drawing.Size(100, 20)
        Me.DtpInvvatdt.TabIndex = 44
        '
        'TxtVatinvno
        '
        Me.TxtVatinvno.Location = New System.Drawing.Point(68, 2)
        Me.TxtVatinvno.Name = "TxtVatinvno"
        Me.TxtVatinvno.Size = New System.Drawing.Size(100, 20)
        Me.TxtVatinvno.TabIndex = 43
        Me.TxtVatinvno.Text = "0"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(3, 5)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(59, 13)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "Invoice No"
        '
        'mskTxtVAtCst
        '
        Me.mskTxtVAtCst.AsciiOnly = True
        Me.mskTxtVAtCst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskTxtVAtCst.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskTxtVAtCst.Location = New System.Drawing.Point(60, 544)
        Me.mskTxtVAtCst.Name = "mskTxtVAtCst"
        Me.mskTxtVAtCst.ReadOnly = True
        Me.mskTxtVAtCst.Size = New System.Drawing.Size(107, 21)
        Me.mskTxtVAtCst.TabIndex = 48
        Me.mskTxtVAtCst.Text = "0"
        Me.mskTxtVAtCst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(594, 567)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(81, 13)
        Me.Label35.TabIndex = 87
        Me.Label35.Text = "Gross Total"
        '
        'lblgross
        '
        Me.lblgross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblgross.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgross.Location = New System.Drawing.Point(678, 567)
        Me.lblgross.Name = "lblgross"
        Me.lblgross.Size = New System.Drawing.Size(123, 20)
        Me.lblgross.TabIndex = 85
        Me.lblgross.Text = "0"
        Me.lblgross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbldiscount
        '
        Me.lbldiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbldiscount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldiscount.Location = New System.Drawing.Point(237, 491)
        Me.lbldiscount.Name = "lbldiscount"
        Me.lbldiscount.Size = New System.Drawing.Size(90, 20)
        Me.lbldiscount.TabIndex = 83
        Me.lbldiscount.Text = "0"
        Me.lbldiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(560, 548)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(115, 13)
        Me.Label29.TabIndex = 82
        Me.Label29.Text = "Total Of Charges"
        '
        'lbltoc
        '
        Me.lbltoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltoc.Location = New System.Drawing.Point(678, 548)
        Me.lbltoc.Name = "lbltoc"
        Me.lbltoc.Size = New System.Drawing.Size(123, 20)
        Me.lbltoc.TabIndex = 81
        Me.lbltoc.Text = "0"
        Me.lbltoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblsubttl
        '
        Me.lblsubttl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblsubttl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubttl.Location = New System.Drawing.Point(67, 491)
        Me.lblsubttl.Name = "lblsubttl"
        Me.lblsubttl.Size = New System.Drawing.Size(95, 20)
        Me.lblsubttl.TabIndex = 79
        Me.lblsubttl.Text = "0"
        Me.lblsubttl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Tplitem
        '
        Me.Tplitem.BackColor = System.Drawing.Color.SpringGreen
        Me.Tplitem.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tplitem.ColumnCount = 1
        Me.Tplitem.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tplitem.Controls.Add(Me.Panel3, 0, 0)
        Me.Tplitem.Controls.Add(Me.LstVewItem, 0, 1)
        Me.Tplitem.Enabled = False
        Me.Tplitem.Location = New System.Drawing.Point(837, 272)
        Me.Tplitem.Name = "Tplitem"
        Me.Tplitem.RowCount = 2
        Me.Tplitem.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.65285!))
        Me.Tplitem.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.34715!))
        Me.Tplitem.Size = New System.Drawing.Size(452, 194)
        Me.Tplitem.TabIndex = 35
        Me.Tplitem.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Cmbxitem)
        Me.Panel3.Controls.Add(Me.TxtItmname)
        Me.Panel3.Controls.Add(Me.TxtItmcode)
        Me.Panel3.Controls.Add(Me.BtnItem)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(444, 29)
        Me.Panel3.TabIndex = 36
        '
        'Cmbxitem
        '
        Me.Cmbxitem.FormattingEnabled = True
        Me.Cmbxitem.Location = New System.Drawing.Point(278, 2)
        Me.Cmbxitem.Name = "Cmbxitem"
        Me.Cmbxitem.Size = New System.Drawing.Size(139, 21)
        Me.Cmbxitem.TabIndex = 39
        '
        'TxtItmname
        '
        Me.TxtItmname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtItmname.Location = New System.Drawing.Point(60, 3)
        Me.TxtItmname.Name = "TxtItmname"
        Me.TxtItmname.Size = New System.Drawing.Size(215, 20)
        Me.TxtItmname.TabIndex = 38
        '
        'TxtItmcode
        '
        Me.TxtItmcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtItmcode.Location = New System.Drawing.Point(3, 3)
        Me.TxtItmcode.Name = "TxtItmcode"
        Me.TxtItmcode.Size = New System.Drawing.Size(55, 20)
        Me.TxtItmcode.TabIndex = 37
        '
        'BtnItem
        '
        Me.BtnItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnItem.FlatAppearance.BorderSize = 0
        Me.BtnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnItem.ForeColor = System.Drawing.Color.Red
        Me.BtnItem.Location = New System.Drawing.Point(419, 3)
        Me.BtnItem.Name = "BtnItem"
        Me.BtnItem.Size = New System.Drawing.Size(22, 23)
        Me.BtnItem.TabIndex = 39
        Me.BtnItem.Text = "X"
        Me.BtnItem.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnItem.UseVisualStyleBackColor = True
        '
        'LstVewItem
        '
        Me.LstVewItem.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.LstVewItem.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColIcode, Me.ColIname, Me.Coliid, Me.Colicost, Me.Colmin, Me.Colmax, Me.Colopn, Me.Colunt})
        Me.LstVewItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstVewItem.FullRowSelect = True
        Me.LstVewItem.GridLines = True
        Me.LstVewItem.Location = New System.Drawing.Point(4, 40)
        Me.LstVewItem.MultiSelect = False
        Me.LstVewItem.Name = "LstVewItem"
        Me.LstVewItem.Size = New System.Drawing.Size(444, 150)
        Me.LstVewItem.TabIndex = 40
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
        'DgSaleDirect
        '
        Me.DgSaleDirect.AllowUserToAddRows = False
        Me.DgSaleDirect.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.DgSaleDirect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgSaleDirect.Location = New System.Drawing.Point(4, 322)
        Me.DgSaleDirect.Name = "DgSaleDirect"
        Me.DgSaleDirect.Size = New System.Drawing.Size(816, 165)
        Me.DgSaleDirect.TabIndex = 48
        Me.DgSaleDirect.TabStop = False
        '
        'tplcustlist
        '
        Me.tplcustlist.BackColor = System.Drawing.Color.SpringGreen
        Me.tplcustlist.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tplcustlist.ColumnCount = 1
        Me.tplcustlist.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tplcustlist.Controls.Add(Me.Panel2, 0, 0)
        Me.tplcustlist.Controls.Add(Me.lstvewcustlist, 0, 1)
        Me.tplcustlist.Enabled = False
        Me.tplcustlist.Location = New System.Drawing.Point(837, 4)
        Me.tplcustlist.Name = "tplcustlist"
        Me.tplcustlist.RowCount = 2
        Me.tplcustlist.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.6319!))
        Me.tplcustlist.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.3681!))
        Me.tplcustlist.Size = New System.Drawing.Size(392, 164)
        Me.tplcustlist.TabIndex = 45
        Me.tplcustlist.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Txtcustname)
        Me.Panel2.Controls.Add(Me.Txtcustcode)
        Me.Panel2.Controls.Add(Me.BtnCloselist)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(384, 25)
        Me.Panel2.TabIndex = 46
        '
        'Txtcustname
        '
        Me.Txtcustname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtcustname.Location = New System.Drawing.Point(101, 3)
        Me.Txtcustname.Name = "Txtcustname"
        Me.Txtcustname.Size = New System.Drawing.Size(253, 20)
        Me.Txtcustname.TabIndex = 48
        '
        'Txtcustcode
        '
        Me.Txtcustcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtcustcode.Location = New System.Drawing.Point(3, 3)
        Me.Txtcustcode.Name = "Txtcustcode"
        Me.Txtcustcode.Size = New System.Drawing.Size(95, 20)
        Me.Txtcustcode.TabIndex = 47
        '
        'BtnCloselist
        '
        Me.BtnCloselist.FlatAppearance.BorderSize = 0
        Me.BtnCloselist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCloselist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCloselist.ForeColor = System.Drawing.Color.Red
        Me.BtnCloselist.Location = New System.Drawing.Point(358, 3)
        Me.BtnCloselist.Name = "BtnCloselist"
        Me.BtnCloselist.Size = New System.Drawing.Size(22, 23)
        Me.BtnCloselist.TabIndex = 49
        Me.BtnCloselist.Text = "X"
        Me.BtnCloselist.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCloselist.UseVisualStyleBackColor = True
        '
        'lstvewcustlist
        '
        Me.lstvewcustlist.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstvewcustlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.custCode, Me.custName, Me.custId, Me.FullAddress, Me.splrspcatid})
        Me.lstvewcustlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstvewcustlist.FullRowSelect = True
        Me.lstvewcustlist.GridLines = True
        Me.lstvewcustlist.HotTracking = True
        Me.lstvewcustlist.HoverSelection = True
        Me.lstvewcustlist.Location = New System.Drawing.Point(4, 36)
        Me.lstvewcustlist.MultiSelect = False
        Me.lstvewcustlist.Name = "lstvewcustlist"
        Me.lstvewcustlist.Size = New System.Drawing.Size(384, 124)
        Me.lstvewcustlist.TabIndex = 50
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
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Btnundrgrp)
        Me.Panel5.Controls.Add(Me.CmbxLdgrHead)
        Me.Panel5.Controls.Add(Me.Label27)
        Me.Panel5.Controls.Add(Me.CmbxAgent)
        Me.Panel5.Controls.Add(Me.Label31)
        Me.Panel5.Controls.Add(Me.btnSpcatadd)
        Me.Panel5.Controls.Add(Me.Label28)
        Me.Panel5.Controls.Add(Me.Cmbxspcatid)
        Me.Panel5.Controls.Add(Me.Chkbdisc)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.ChkbOthrCharg)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.ChkbCariDetals)
        Me.Panel5.Controls.Add(Me.MTxtTotlamt)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.TxtSaleBillNo)
        Me.Panel5.Controls.Add(Me.BtnAddCarri)
        Me.Panel5.Controls.Add(Me.Btnaddware)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.Txtcoment)
        Me.Panel5.Controls.Add(Me.CmbxPlist)
        Me.Panel5.Controls.Add(Me.CmbxCarri)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.CmbxWareh)
        Me.Panel5.Controls.Add(Me.Label30)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.lblAdrsfull)
        Me.Panel5.Controls.Add(Me.TxtVname)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.DtpSaleDue)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.txtvCode)
        Me.Panel5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(4, 36)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(816, 283)
        Me.Panel5.TabIndex = 4
        '
        'Btnundrgrp
        '
        Me.Btnundrgrp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btnundrgrp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnundrgrp.Location = New System.Drawing.Point(448, 31)
        Me.Btnundrgrp.Name = "Btnundrgrp"
        Me.Btnundrgrp.Size = New System.Drawing.Size(26, 21)
        Me.Btnundrgrp.TabIndex = 98
        Me.Btnundrgrp.TabStop = False
        Me.Btnundrgrp.Text = "...."
        Me.Btnundrgrp.UseVisualStyleBackColor = True
        '
        'CmbxLdgrHead
        '
        Me.CmbxLdgrHead.AllowDrop = True
        Me.CmbxLdgrHead.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxLdgrHead.Location = New System.Drawing.Point(81, 32)
        Me.CmbxLdgrHead.Name = "CmbxLdgrHead"
        Me.CmbxLdgrHead.Size = New System.Drawing.Size(365, 21)
        Me.CmbxLdgrHead.Sorted = True
        Me.CmbxLdgrHead.TabIndex = 5
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(-2, 32)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 13)
        Me.Label27.TabIndex = 97
        Me.Label27.Text = "Ldgr- Head"
        '
        'CmbxAgent
        '
        Me.CmbxAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxAgent.FormattingEnabled = True
        Me.CmbxAgent.Location = New System.Drawing.Point(533, 100)
        Me.CmbxAgent.Name = "CmbxAgent"
        Me.CmbxAgent.Size = New System.Drawing.Size(251, 21)
        Me.CmbxAgent.TabIndex = 79
        Me.CmbxAgent.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(478, 100)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(49, 13)
        Me.Label31.TabIndex = 80
        Me.Label31.Text = "Agent "
        '
        'btnSpcatadd
        '
        Me.btnSpcatadd.Location = New System.Drawing.Point(390, 257)
        Me.btnSpcatadd.Name = "btnSpcatadd"
        Me.btnSpcatadd.Size = New System.Drawing.Size(32, 22)
        Me.btnSpcatadd.TabIndex = 70
        Me.btnSpcatadd.TabStop = False
        Me.btnSpcatadd.Text = "...."
        Me.btnSpcatadd.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(3, 259)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(64, 13)
        Me.Label28.TabIndex = 78
        Me.Label28.Text = "VAT/CST"
        '
        'Cmbxspcatid
        '
        Me.Cmbxspcatid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxspcatid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxspcatid.FormattingEnabled = True
        Me.Cmbxspcatid.Items.AddRange(New Object() {"Discount Value", "Discount Percentage"})
        Me.Cmbxspcatid.Location = New System.Drawing.Point(65, 257)
        Me.Cmbxspcatid.Name = "Cmbxspcatid"
        Me.Cmbxspcatid.Size = New System.Drawing.Size(323, 22)
        Me.Cmbxspcatid.TabIndex = 29
        Me.Cmbxspcatid.TabStop = False
        '
        'Chkbdisc
        '
        Me.Chkbdisc.AutoSize = True
        Me.Chkbdisc.Location = New System.Drawing.Point(433, 257)
        Me.Chkbdisc.Name = "Chkbdisc"
        Me.Chkbdisc.Size = New System.Drawing.Size(50, 17)
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
        Me.Panel8.Location = New System.Drawing.Point(488, 253)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(323, 27)
        Me.Panel8.TabIndex = 31
        '
        'Mtxtdisvalue
        '
        Me.Mtxtdisvalue.AsciiOnly = True
        Me.Mtxtdisvalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Mtxtdisvalue.Location = New System.Drawing.Point(244, 1)
        Me.Mtxtdisvalue.Name = "Mtxtdisvalue"
        Me.Mtxtdisvalue.Size = New System.Drawing.Size(72, 21)
        Me.Mtxtdisvalue.TabIndex = 33
        Me.Mtxtdisvalue.Text = "0"
        Me.Mtxtdisvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(182, 3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 61
        Me.Label25.Text = "Dis. Rate"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(-2, 4)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(43, 13)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "Type."
        '
        'Cmbxdistype
        '
        Me.Cmbxdistype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxdistype.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxdistype.FormattingEnabled = True
        Me.Cmbxdistype.Items.AddRange(New Object() {"Discount Value", "Discount Percentage"})
        Me.Cmbxdistype.Location = New System.Drawing.Point(40, 1)
        Me.Cmbxdistype.Name = "Cmbxdistype"
        Me.Cmbxdistype.Size = New System.Drawing.Size(140, 22)
        Me.Cmbxdistype.TabIndex = 32
        '
        'ChkbOthrCharg
        '
        Me.ChkbOthrCharg.AutoSize = True
        Me.ChkbOthrCharg.Location = New System.Drawing.Point(6, 141)
        Me.ChkbOthrCharg.Name = "ChkbOthrCharg"
        Me.ChkbOthrCharg.Size = New System.Drawing.Size(123, 17)
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
        Me.Panel7.Location = New System.Drawing.Point(6, 163)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(398, 91)
        Me.Panel7.TabIndex = 22
        '
        'TxtPlcyno
        '
        Me.TxtPlcyno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPlcyno.Location = New System.Drawing.Point(266, 32)
        Me.TxtPlcyno.Name = "TxtPlcyno"
        Me.TxtPlcyno.Size = New System.Drawing.Size(126, 21)
        Me.TxtPlcyno.TabIndex = 27
        '
        'TxtinsCo
        '
        Me.TxtinsCo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtinsCo.Location = New System.Drawing.Point(266, 61)
        Me.TxtinsCo.Name = "TxtinsCo"
        Me.TxtinsCo.Size = New System.Drawing.Size(126, 21)
        Me.TxtinsCo.TabIndex = 28
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(191, 61)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 72
        Me.Label22.Text = "Ins. Co."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(191, 32)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 13)
        Me.Label21.TabIndex = 71
        Me.Label21.Text = "Ins. P. No."
        '
        'MskInscharg
        '
        Me.MskInscharg.AsciiOnly = True
        Me.MskInscharg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MskInscharg.Location = New System.Drawing.Point(289, 3)
        Me.MskInscharg.Name = "MskInscharg"
        Me.MskInscharg.Size = New System.Drawing.Size(103, 21)
        Me.MskInscharg.TabIndex = 26
        Me.MskInscharg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(191, 3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(97, 13)
        Me.Label20.TabIndex = 69
        Me.Label20.Text = "Insu. Charges"
        '
        'Mskothrchrg
        '
        Me.Mskothrchrg.AsciiOnly = True
        Me.Mskothrchrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Mskothrchrg.Location = New System.Drawing.Point(93, 61)
        Me.Mskothrchrg.Name = "Mskothrchrg"
        Me.Mskothrchrg.Size = New System.Drawing.Size(97, 21)
        Me.Mskothrchrg.TabIndex = 25
        Me.Mskothrchrg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(-1, 61)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 67
        Me.Label16.Text = "Othr.Charges"
        '
        'MskPostcharg
        '
        Me.MskPostcharg.AsciiOnly = True
        Me.MskPostcharg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MskPostcharg.Location = New System.Drawing.Point(93, 32)
        Me.MskPostcharg.Name = "MskPostcharg"
        Me.MskPostcharg.Size = New System.Drawing.Size(97, 21)
        Me.MskPostcharg.TabIndex = 24
        Me.MskPostcharg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(-1, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Post. Charges"
        '
        'MtxtPkgcharg
        '
        Me.MtxtPkgcharg.AsciiOnly = True
        Me.MtxtPkgcharg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MtxtPkgcharg.Location = New System.Drawing.Point(93, 3)
        Me.MtxtPkgcharg.Name = "MtxtPkgcharg"
        Me.MtxtPkgcharg.Size = New System.Drawing.Size(97, 21)
        Me.MtxtPkgcharg.TabIndex = 23
        Me.MtxtPkgcharg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(-1, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Pac. Charges"
        '
        'ChkbCariDetals
        '
        Me.ChkbCariDetals.AutoSize = True
        Me.ChkbCariDetals.Location = New System.Drawing.Point(410, 121)
        Me.ChkbCariDetals.Name = "ChkbCariDetals"
        Me.ChkbCariDetals.Size = New System.Drawing.Size(115, 17)
        Me.ChkbCariDetals.TabIndex = 12
        Me.ChkbCariDetals.Text = "Carri. Details "
        Me.ChkbCariDetals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkbCariDetals.UseVisualStyleBackColor = True
        '
        'MTxtTotlamt
        '
        Me.MTxtTotlamt.AsciiOnly = True
        Me.MTxtTotlamt.BeepOnError = True
        Me.MTxtTotlamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MTxtTotlamt.Location = New System.Drawing.Point(621, 3)
        Me.MTxtTotlamt.Name = "MTxtTotlamt"
        Me.MTxtTotlamt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MTxtTotlamt.Size = New System.Drawing.Size(163, 21)
        Me.MTxtTotlamt.TabIndex = 4
        Me.MTxtTotlamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Rbpaid)
        Me.Panel6.Controls.Add(Me.Rb2pay)
        Me.Panel6.Controls.Add(Me.Label26)
        Me.Panel6.Controls.Add(Me.TxtPvtMrk)
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
        Me.Panel6.Controls.Add(Me.TxtGrsWt)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Enabled = False
        Me.Panel6.Location = New System.Drawing.Point(410, 143)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(401, 111)
        Me.Panel6.TabIndex = 13
        '
        'Rbpaid
        '
        Me.Rbpaid.AutoSize = True
        Me.Rbpaid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbpaid.Location = New System.Drawing.Point(343, 81)
        Me.Rbpaid.Name = "Rbpaid"
        Me.Rbpaid.Size = New System.Drawing.Size(48, 18)
        Me.Rbpaid.TabIndex = 94
        Me.Rbpaid.Text = "Paid"
        Me.Rbpaid.UseVisualStyleBackColor = True
        '
        'Rb2pay
        '
        Me.Rb2pay.AutoSize = True
        Me.Rb2pay.Checked = True
        Me.Rb2pay.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb2pay.Location = New System.Drawing.Point(279, 81)
        Me.Rb2pay.Name = "Rb2pay"
        Me.Rb2pay.Size = New System.Drawing.Size(57, 18)
        Me.Rb2pay.TabIndex = 93
        Me.Rb2pay.TabStop = True
        Me.Rb2pay.Text = "Topay"
        Me.Rb2pay.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 81)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(68, 13)
        Me.Label26.TabIndex = 90
        Me.Label26.Text = "Pvt. Mark"
        '
        'TxtPvtMrk
        '
        Me.TxtPvtMrk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPvtMrk.Location = New System.Drawing.Point(111, 81)
        Me.TxtPvtMrk.Name = "TxtPvtMrk"
        Me.TxtPvtMrk.Size = New System.Drawing.Size(162, 21)
        Me.TxtPvtMrk.TabIndex = 20
        '
        'Dtpgrdt
        '
        Me.Dtpgrdt.CustomFormat = "dd/MM/yyyy"
        Me.Dtpgrdt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpgrdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpgrdt.Location = New System.Drawing.Point(294, 30)
        Me.Dtpgrdt.Name = "Dtpgrdt"
        Me.Dtpgrdt.Size = New System.Drawing.Size(100, 20)
        Me.Dtpgrdt.TabIndex = 17
        '
        'mtxtulcharg
        '
        Me.mtxtulcharg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mtxtulcharg.Location = New System.Drawing.Point(111, 55)
        Me.mtxtulcharg.Name = "mtxtulcharg"
        Me.mtxtulcharg.Size = New System.Drawing.Size(100, 21)
        Me.mtxtulcharg.TabIndex = 18
        Me.mtxtulcharg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 55)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(110, 13)
        Me.Label19.TabIndex = 86
        Me.Label19.Text = "U-Load Charges"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 13)
        Me.Label18.TabIndex = 85
        Me.Label18.Text = "G. Wt. (Kg.)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 13)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "Carriage No."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(218, 30)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 13)
        Me.Label15.TabIndex = 83
        Me.Label15.Text = "GR. Date"
        '
        'MtxtfrtChargs
        '
        Me.MtxtfrtChargs.AsciiOnly = True
        Me.MtxtfrtChargs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MtxtfrtChargs.Location = New System.Drawing.Point(294, 55)
        Me.MtxtfrtChargs.Name = "MtxtfrtChargs"
        Me.MtxtfrtChargs.Size = New System.Drawing.Size(100, 21)
        Me.MtxtfrtChargs.TabIndex = 19
        Me.MtxtfrtChargs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCariNo
        '
        Me.TxtCariNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCariNo.Location = New System.Drawing.Point(111, 30)
        Me.TxtCariNo.Name = "TxtCariNo"
        Me.TxtCariNo.Size = New System.Drawing.Size(100, 21)
        Me.TxtCariNo.TabIndex = 16
        '
        'Txtgrno
        '
        Me.Txtgrno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtgrno.Location = New System.Drawing.Point(294, 3)
        Me.Txtgrno.Name = "Txtgrno"
        Me.Txtgrno.Size = New System.Drawing.Size(100, 21)
        Me.Txtgrno.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(217, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "GR. No."
        '
        'TxtGrsWt
        '
        Me.TxtGrsWt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGrsWt.Location = New System.Drawing.Point(111, 3)
        Me.TxtGrsWt.Name = "TxtGrsWt"
        Me.TxtGrsWt.Size = New System.Drawing.Size(100, 21)
        Me.TxtGrsWt.TabIndex = 14
        Me.TxtGrsWt.Text = "0"
        Me.TxtGrsWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(211, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "Frght.Charg."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(478, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Invoice Amount"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Invoice No."
        '
        'TxtSaleBillNo
        '
        Me.TxtSaleBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSaleBillNo.Location = New System.Drawing.Point(81, 3)
        Me.TxtSaleBillNo.Name = "TxtSaleBillNo"
        Me.TxtSaleBillNo.Size = New System.Drawing.Size(176, 21)
        Me.TxtSaleBillNo.TabIndex = 2
        '
        'BtnAddCarri
        '
        Me.BtnAddCarri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddCarri.Location = New System.Drawing.Point(787, 75)
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
        'Btnaddware
        '
        Me.Btnaddware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnaddware.Location = New System.Drawing.Point(787, 28)
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
        Me.Txtcoment.Enabled = False
        Me.Txtcoment.Location = New System.Drawing.Point(81, 120)
        Me.Txtcoment.Multiline = True
        Me.Txtcoment.Name = "Txtcoment"
        Me.Txtcoment.Size = New System.Drawing.Size(323, 20)
        Me.Txtcoment.TabIndex = 20
        '
        'CmbxPlist
        '
        Me.CmbxPlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxPlist.Enabled = False
        Me.CmbxPlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxPlist.FormattingEnabled = True
        Me.CmbxPlist.Location = New System.Drawing.Point(568, 52)
        Me.CmbxPlist.Name = "CmbxPlist"
        Me.CmbxPlist.Size = New System.Drawing.Size(216, 21)
        Me.CmbxPlist.TabIndex = 11
        Me.CmbxPlist.TabStop = False
        '
        'CmbxCarri
        '
        Me.CmbxCarri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCarri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxCarri.FormattingEnabled = True
        Me.CmbxCarri.Location = New System.Drawing.Point(568, 76)
        Me.CmbxCarri.Name = "CmbxCarri"
        Me.CmbxCarri.Size = New System.Drawing.Size(216, 21)
        Me.CmbxCarri.TabIndex = 11
        Me.CmbxCarri.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(478, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Tran. Co."
        '
        'CmbxWareh
        '
        Me.CmbxWareh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxWareh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxWareh.FormattingEnabled = True
        Me.CmbxWareh.Location = New System.Drawing.Point(568, 28)
        Me.CmbxWareh.Name = "CmbxWareh"
        Me.CmbxWareh.Size = New System.Drawing.Size(217, 21)
        Me.CmbxWareh.TabIndex = 10
        Me.CmbxWareh.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(479, 52)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(67, 13)
        Me.Label30.TabIndex = 58
        Me.Label30.Text = "Price List"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(478, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Delivery At"
        '
        'lblAdrsfull
        '
        Me.lblAdrsfull.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblAdrsfull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAdrsfull.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdrsfull.Location = New System.Drawing.Point(81, 82)
        Me.lblAdrsfull.Name = "lblAdrsfull"
        Me.lblAdrsfull.Size = New System.Drawing.Size(392, 32)
        Me.lblAdrsfull.TabIndex = 57
        Me.lblAdrsfull.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtVname
        '
        Me.TxtVname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVname.Enabled = False
        Me.TxtVname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVname.Location = New System.Drawing.Point(133, 59)
        Me.TxtVname.Name = "TxtVname"
        Me.TxtVname.Size = New System.Drawing.Size(340, 20)
        Me.TxtVname.TabIndex = 9
        Me.TxtVname.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Name"
        '
        'DtpSaleDue
        '
        Me.DtpSaleDue.CustomFormat = "dd/MM/yyyy"
        Me.DtpSaleDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpSaleDue.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpSaleDue.Location = New System.Drawing.Point(341, 3)
        Me.DtpSaleDue.Name = "DtpSaleDue"
        Me.DtpSaleDue.Size = New System.Drawing.Size(132, 20)
        Me.DtpSaleDue.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(270, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Due Date"
        '
        'txtvCode
        '
        Me.txtvCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtvCode.Enabled = False
        Me.txtvCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvCode.Location = New System.Drawing.Point(81, 59)
        Me.txtvCode.Name = "txtvCode"
        Me.txtvCode.Size = New System.Drawing.Size(50, 20)
        Me.txtvCode.TabIndex = 8
        Me.txtvCode.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LblType)
        Me.Panel1.Controls.Add(Me.LblCurBal)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Panel9)
        Me.Panel1.Controls.Add(Me.Cmbxstatus)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.dtpordrdt)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(817, 29)
        Me.Panel1.TabIndex = 0
        '
        'LblType
        '
        Me.LblType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblType.ForeColor = System.Drawing.Color.White
        Me.LblType.Location = New System.Drawing.Point(694, 3)
        Me.LblType.Name = "LblType"
        Me.LblType.Size = New System.Drawing.Size(29, 20)
        Me.LblType.TabIndex = 141
        Me.LblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCurBal
        '
        Me.LblCurBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCurBal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurBal.ForeColor = System.Drawing.Color.White
        Me.LblCurBal.Location = New System.Drawing.Point(556, 3)
        Me.LblCurBal.Name = "LblCurBal"
        Me.LblCurBal.Size = New System.Drawing.Size(137, 20)
        Me.LblCurBal.TabIndex = 140
        Me.LblCurBal.Text = "0.00"
        Me.LblCurBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(413, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 20)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "CLOSING BALANCE:-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.RbSbill2)
        Me.Panel9.Controls.Add(Me.RbSbill1)
        Me.Panel9.Location = New System.Drawing.Point(742, 3)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(72, 21)
        Me.Panel9.TabIndex = 65
        '
        'RbSbill2
        '
        Me.RbSbill2.AutoSize = True
        Me.RbSbill2.Checked = True
        Me.RbSbill2.ForeColor = System.Drawing.Color.White
        Me.RbSbill2.Location = New System.Drawing.Point(37, 3)
        Me.RbSbill2.Name = "RbSbill2"
        Me.RbSbill2.Size = New System.Drawing.Size(32, 18)
        Me.RbSbill2.TabIndex = 1
        Me.RbSbill2.TabStop = True
        Me.RbSbill2.Text = "X"
        Me.RbSbill2.UseVisualStyleBackColor = True
        '
        'RbSbill1
        '
        Me.RbSbill1.AutoSize = True
        Me.RbSbill1.ForeColor = System.Drawing.Color.White
        Me.RbSbill1.Location = New System.Drawing.Point(4, 2)
        Me.RbSbill1.Name = "RbSbill1"
        Me.RbSbill1.Size = New System.Drawing.Size(31, 18)
        Me.RbSbill1.TabIndex = 0
        Me.RbSbill1.TabStop = True
        Me.RbSbill1.Text = "+"
        Me.RbSbill1.UseVisualStyleBackColor = True
        '
        'Cmbxstatus
        '
        Me.Cmbxstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxstatus.FormattingEnabled = True
        Me.Cmbxstatus.Items.AddRange(New Object() {"Cash Sale", "Credit Sale"})
        Me.Cmbxstatus.Location = New System.Drawing.Point(259, 3)
        Me.Cmbxstatus.Name = "Cmbxstatus"
        Me.Cmbxstatus.Size = New System.Drawing.Size(132, 21)
        Me.Cmbxstatus.Sorted = True
        Me.Cmbxstatus.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(168, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 14)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Invoice Status"
        '
        'dtpordrdt
        '
        Me.dtpordrdt.CustomFormat = "dd/MM/yyyy"
        Me.dtpordrdt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpordrdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpordrdt.Location = New System.Drawing.Point(41, 3)
        Me.dtpordrdt.Name = "dtpordrdt"
        Me.dtpordrdt.Size = New System.Drawing.Size(113, 20)
        Me.dtpordrdt.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Date"
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
        Me.BtnPe_exit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPe_exit.ForeColor = System.Drawing.Color.Navy
        Me.BtnPe_exit.Location = New System.Drawing.Point(687, 1)
        Me.BtnPe_exit.Name = "BtnPe_exit"
        Me.BtnPe_exit.Size = New System.Drawing.Size(133, 33)
        Me.BtnPe_exit.TabIndex = 50
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
        Me.BtnPe_Save.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPe_Save.ForeColor = System.Drawing.Color.Navy
        Me.BtnPe_Save.Location = New System.Drawing.Point(548, 1)
        Me.BtnPe_Save.Name = "BtnPe_Save"
        Me.BtnPe_Save.Size = New System.Drawing.Size(133, 33)
        Me.BtnPe_Save.TabIndex = 49
        Me.BtnPe_Save.Text = "&Save"
        Me.BtnPe_Save.UseVisualStyleBackColor = False
        '
        'ContxtDg1
        '
        Me.ContxtDg1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.ContxtDg1.Name = "ContxtDg1"
        Me.ContxtDg1.Size = New System.Drawing.Size(146, 70)
        Me.ContxtDg1.Text = "F&ile"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.SaveToolStripMenuItem.Text = "Sa&ve"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(145, 22)
        Me.ToolStripMenuItem1.Text = "E&dit VAT/CST"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'FrmTranSaleEnteryOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Turquoise
        Me.ClientSize = New System.Drawing.Size(1020, 632)
        Me.ContextMenuStrip = Me.ContxtDg1
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTranSaleEnteryOrder"
        Me.Text = "Sale Entry (Through Sale  Order)"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Pnlvatinfo.ResumeLayout(False)
        Me.Pnlvatinfo.PerformLayout()
        Me.Tplitem.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DgSaleDirect, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.ContxtDg1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    'Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents BtnPe_Save As System.Windows.Forms.Button
    Friend WithEvents BtnPe_exit As System.Windows.Forms.Button
    Friend WithEvents dtpordrdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSaleBillNo As System.Windows.Forms.TextBox
    Friend WithEvents BtnAddCarri As System.Windows.Forms.Button
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
    Friend WithEvents DtpSaleDue As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtvCode As System.Windows.Forms.TextBox
    Friend WithEvents Cmbxstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ChkbCariDetals As System.Windows.Forms.CheckBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TxtCariNo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtGrsWt As System.Windows.Forms.TextBox
    Friend WithEvents Txtgrno As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MTxtTotlamt As System.Windows.Forms.MaskedTextBox
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
    Friend WithEvents Txtcustname As System.Windows.Forms.TextBox
    Friend WithEvents Txtcustcode As System.Windows.Forms.TextBox
    Friend WithEvents BtnCloselist As System.Windows.Forms.Button
    Friend WithEvents lstvewcustlist As System.Windows.Forms.ListView
    Friend WithEvents custCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents custName As System.Windows.Forms.ColumnHeader
    Friend WithEvents custId As System.Windows.Forms.ColumnHeader
    Friend WithEvents FullAddress As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Cmbxspcatid As System.Windows.Forms.ComboBox
    Friend WithEvents btnSpcatadd As System.Windows.Forms.Button
    Friend WithEvents splrspcatid As System.Windows.Forms.ColumnHeader
    Friend WithEvents DgSaleDirect As System.Windows.Forms.DataGridView
    Friend WithEvents Tplitem As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Cmbxitem As System.Windows.Forms.ComboBox
    Friend WithEvents TxtItmname As System.Windows.Forms.TextBox
    Friend WithEvents TxtItmcode As System.Windows.Forms.TextBox
    Friend WithEvents BtnItem As System.Windows.Forms.Button
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
    Friend WithEvents Pnlvatinfo As System.Windows.Forms.Panel
    Friend WithEvents MskinvVat As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents MskInvamt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents DtpInvvatdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtVatinvno As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtPvtMrk As System.Windows.Forms.TextBox
    Friend WithEvents ChkVatInfo As System.Windows.Forms.CheckBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents CmbxPlist As System.Windows.Forms.ComboBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents RbSbill2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbSbill1 As System.Windows.Forms.RadioButton
    Friend WithEvents MskAdlDis As System.Windows.Forms.MaskedTextBox
    Friend WithEvents LblAdlDis As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents LblVATCST As System.Windows.Forms.Label
    Friend WithEvents LblRondOff As System.Windows.Forms.Label
    Friend WithEvents LblSurCharg As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents LbltablAmt As System.Windows.Forms.Label
    Friend WithEvents RbAdnl2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbAdnl1 As System.Windows.Forms.RadioButton
    Friend WithEvents CmbxAdnlDis As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents CmbxAgent As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Rbpaid As System.Windows.Forms.RadioButton
    Friend WithEvents Rb2pay As System.Windows.Forms.RadioButton
    Friend WithEvents Btnundrgrp As System.Windows.Forms.Button
    Friend WithEvents CmbxLdgrHead As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents LblType As System.Windows.Forms.Label
    Friend WithEvents LblCurBal As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

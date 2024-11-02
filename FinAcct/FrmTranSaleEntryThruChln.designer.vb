<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTranSaleEntryThruChln
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTranSaleEntryThruChln))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.LstVewPurItms = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ContxtDg1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BtnOk = New System.Windows.Forms.Button
        Me.BtnItm = New System.Windows.Forms.Button
        Me.BtnGrup = New System.Windows.Forms.Button
        Me.CmbxItmName = New System.Windows.Forms.ComboBox
        Me.CmbxItmGrup = New System.Windows.Forms.ComboBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.lblsubttl = New System.Windows.Forms.Label
        Me.TxtItmRate = New System.Windows.Forms.TextBox
        Me.TxtQnty = New System.Windows.Forms.TextBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.LblType = New System.Windows.Forms.Label
        Me.LblCurBal = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnEditmode = New System.Windows.Forms.Button
        Me.CmbxSplr = New System.Windows.Forms.ComboBox
        Me.Txtcoment = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPurBillNo = New System.Windows.Forms.TextBox
        Me.BtnAddCarri = New System.Windows.Forms.Button
        Me.BtnAddCust = New System.Windows.Forms.Button
        Me.Btnaddware = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbxCarri = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbxWareh = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblAdrsfull = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ChkBx1 = New System.Windows.Forms.CheckBox
        Me.dtpordrdt = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnSe_exit = New System.Windows.Forms.Button
        Me.BtnSe_Save = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContxtDg1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.LstVewPurItms)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnOk)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnItm)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnGrup)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbxItmName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbxItmGrup)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label43)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblsubttl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtItmRate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtQnty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnFind)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnSe_exit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnSe_Save)
        Me.SplitContainer1.Size = New System.Drawing.Size(921, 619)
        Me.SplitContainer1.SplitterDistance = 575
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
        '
        'LstVewPurItms
        '
        Me.LstVewPurItms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstVewPurItms.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader7, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.LstVewPurItms.ContextMenuStrip = Me.ContxtDg1
        Me.LstVewPurItms.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVewPurItms.FullRowSelect = True
        Me.LstVewPurItms.GridLines = True
        Me.LstVewPurItms.Location = New System.Drawing.Point(3, 322)
        Me.LstVewPurItms.Name = "LstVewPurItms"
        Me.LstVewPurItms.Size = New System.Drawing.Size(912, 224)
        Me.LstVewPurItms.TabIndex = 93
        Me.LstVewPurItms.UseCompatibleStateImageBehavior = False
        Me.LstVewPurItms.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Item Name"
        Me.ColumnHeader1.Width = 400
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Quantity"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "U.O.M."
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Rate (Per UOM)"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 115
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Amount"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 150
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Group Id"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Item Id"
        Me.ColumnHeader6.Width = 0
        '
        'ContxtDg1
        '
        Me.ContxtDg1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem})
        Me.ContxtDg1.Name = "ContxtDg1"
        Me.ContxtDg1.Size = New System.Drawing.Size(181, 70)
        Me.ContxtDg1.Text = "F&ile"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveToolStripMenuItem.Text = "Sa&ve"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem2.Text = "&Delete Selected Row"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'BtnOk
        '
        Me.BtnOk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(506, 295)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(62, 21)
        Me.BtnOk.TabIndex = 12
        Me.BtnOk.Text = "&OK"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'BtnItm
        '
        Me.BtnItm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnItm.Location = New System.Drawing.Point(574, 261)
        Me.BtnItm.Name = "BtnItm"
        Me.BtnItm.Size = New System.Drawing.Size(28, 21)
        Me.BtnItm.TabIndex = 92
        Me.BtnItm.TabStop = False
        Me.BtnItm.Text = "...."
        Me.BtnItm.UseVisualStyleBackColor = True
        '
        'BtnGrup
        '
        Me.BtnGrup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrup.Location = New System.Drawing.Point(574, 229)
        Me.BtnGrup.Name = "BtnGrup"
        Me.BtnGrup.Size = New System.Drawing.Size(28, 21)
        Me.BtnGrup.TabIndex = 92
        Me.BtnGrup.TabStop = False
        Me.BtnGrup.Text = "...."
        Me.BtnGrup.UseVisualStyleBackColor = True
        '
        'CmbxItmName
        '
        Me.CmbxItmName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxItmName.FormattingEnabled = True
        Me.CmbxItmName.Location = New System.Drawing.Point(123, 261)
        Me.CmbxItmName.Name = "CmbxItmName"
        Me.CmbxItmName.Size = New System.Drawing.Size(445, 21)
        Me.CmbxItmName.TabIndex = 9
        '
        'CmbxItmGrup
        '
        Me.CmbxItmGrup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxItmGrup.FormattingEnabled = True
        Me.CmbxItmGrup.Location = New System.Drawing.Point(123, 229)
        Me.CmbxItmGrup.Name = "CmbxItmGrup"
        Me.CmbxItmGrup.Size = New System.Drawing.Size(445, 21)
        Me.CmbxItmGrup.TabIndex = 8
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(617, 549)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(98, 13)
        Me.Label43.TabIndex = 90
        Me.Label43.Text = " Total Value :-"
        '
        'lblsubttl
        '
        Me.lblsubttl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblsubttl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubttl.Location = New System.Drawing.Point(730, 549)
        Me.lblsubttl.Name = "lblsubttl"
        Me.lblsubttl.Size = New System.Drawing.Size(151, 20)
        Me.lblsubttl.TabIndex = 79
        Me.lblsubttl.Text = "0"
        Me.lblsubttl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtItmRate
        '
        Me.TxtItmRate.BackColor = System.Drawing.Color.White
        Me.TxtItmRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtItmRate.Location = New System.Drawing.Point(343, 293)
        Me.TxtItmRate.Name = "TxtItmRate"
        Me.TxtItmRate.Size = New System.Drawing.Size(125, 21)
        Me.TxtItmRate.TabIndex = 11
        Me.TxtItmRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtQnty
        '
        Me.TxtQnty.BackColor = System.Drawing.Color.White
        Me.TxtQnty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtQnty.Location = New System.Drawing.Point(123, 293)
        Me.TxtQnty.Name = "TxtQnty"
        Me.TxtQnty.Size = New System.Drawing.Size(125, 21)
        Me.TxtQnty.TabIndex = 10
        Me.TxtQnty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.LblType)
        Me.Panel5.Controls.Add(Me.LblCurBal)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.BtnEditmode)
        Me.Panel5.Controls.Add(Me.CmbxSplr)
        Me.Panel5.Controls.Add(Me.Txtcoment)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.TxtPurBillNo)
        Me.Panel5.Controls.Add(Me.BtnAddCarri)
        Me.Panel5.Controls.Add(Me.BtnAddCust)
        Me.Panel5.Controls.Add(Me.Btnaddware)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.CmbxCarri)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.CmbxWareh)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.lblAdrsfull)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(4, 40)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(914, 186)
        Me.Panel5.TabIndex = 2
        '
        'LblType
        '
        Me.LblType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblType.ForeColor = System.Drawing.Color.Black
        Me.LblType.Location = New System.Drawing.Point(848, 9)
        Me.LblType.Name = "LblType"
        Me.LblType.Size = New System.Drawing.Size(29, 20)
        Me.LblType.TabIndex = 141
        Me.LblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCurBal
        '
        Me.LblCurBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCurBal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurBal.ForeColor = System.Drawing.Color.Black
        Me.LblCurBal.Location = New System.Drawing.Point(695, 9)
        Me.LblCurBal.Name = "LblCurBal"
        Me.LblCurBal.Size = New System.Drawing.Size(152, 20)
        Me.LblCurBal.TabIndex = 140
        Me.LblCurBal.Text = "0.00"
        Me.LblCurBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(567, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 20)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "CLOSING BALANCE:-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnEditmode
        '
        Me.BtnEditmode.Enabled = False
        Me.BtnEditmode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditmode.Location = New System.Drawing.Point(884, 58)
        Me.BtnEditmode.Name = "BtnEditmode"
        Me.BtnEditmode.Size = New System.Drawing.Size(27, 21)
        Me.BtnEditmode.TabIndex = 84
        Me.BtnEditmode.TabStop = False
        Me.BtnEditmode.Text = "...."
        Me.BtnEditmode.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnEditmode.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtnEditmode.UseCompatibleTextRendering = True
        Me.BtnEditmode.UseVisualStyleBackColor = True
        '
        'CmbxSplr
        '
        Me.CmbxSplr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxSplr.FormattingEnabled = True
        Me.CmbxSplr.Location = New System.Drawing.Point(119, 35)
        Me.CmbxSplr.Name = "CmbxSplr"
        Me.CmbxSplr.Size = New System.Drawing.Size(759, 21)
        Me.CmbxSplr.TabIndex = 4
        '
        'Txtcoment
        '
        Me.Txtcoment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtcoment.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcoment.Location = New System.Drawing.Point(119, 162)
        Me.Txtcoment.Name = "Txtcoment"
        Me.Txtcoment.Size = New System.Drawing.Size(759, 21)
        Me.Txtcoment.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Challan  No."
        '
        'TxtPurBillNo
        '
        Me.TxtPurBillNo.BackColor = System.Drawing.Color.White
        Me.TxtPurBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPurBillNo.Location = New System.Drawing.Point(119, 6)
        Me.TxtPurBillNo.Name = "TxtPurBillNo"
        Me.TxtPurBillNo.Size = New System.Drawing.Size(125, 21)
        Me.TxtPurBillNo.TabIndex = 3
        '
        'BtnAddCarri
        '
        Me.BtnAddCarri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddCarri.Location = New System.Drawing.Point(570, 133)
        Me.BtnAddCarri.Name = "BtnAddCarri"
        Me.BtnAddCarri.Size = New System.Drawing.Size(28, 21)
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
        Me.BtnAddCust.Location = New System.Drawing.Point(884, 35)
        Me.BtnAddCust.Name = "BtnAddCust"
        Me.BtnAddCust.Size = New System.Drawing.Size(27, 21)
        Me.BtnAddCust.TabIndex = 67
        Me.BtnAddCust.TabStop = False
        Me.BtnAddCust.Text = "...."
        Me.BtnAddCust.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAddCust.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtnAddCust.UseCompatibleTextRendering = True
        Me.BtnAddCust.UseVisualStyleBackColor = True
        '
        'Btnaddware
        '
        Me.Btnaddware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnaddware.Location = New System.Drawing.Point(570, 104)
        Me.Btnaddware.Name = "Btnaddware"
        Me.Btnaddware.Size = New System.Drawing.Size(28, 21)
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
        Me.Label12.Location = New System.Drawing.Point(14, 162)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Comments"
        '
        'CmbxCarri
        '
        Me.CmbxCarri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCarri.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxCarri.FormattingEnabled = True
        Me.CmbxCarri.Location = New System.Drawing.Point(119, 133)
        Me.CmbxCarri.Name = "CmbxCarri"
        Me.CmbxCarri.Size = New System.Drawing.Size(445, 21)
        Me.CmbxCarri.TabIndex = 6
        Me.CmbxCarri.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Transport Co."
        '
        'CmbxWareh
        '
        Me.CmbxWareh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxWareh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxWareh.FormattingEnabled = True
        Me.CmbxWareh.Location = New System.Drawing.Point(119, 104)
        Me.CmbxWareh.Name = "CmbxWareh"
        Me.CmbxWareh.Size = New System.Drawing.Size(445, 21)
        Me.CmbxWareh.TabIndex = 5
        Me.CmbxWareh.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 104)
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
        Me.lblAdrsfull.Location = New System.Drawing.Point(119, 60)
        Me.lblAdrsfull.Name = "lblAdrsfull"
        Me.lblAdrsfull.Size = New System.Drawing.Size(759, 35)
        Me.lblAdrsfull.TabIndex = 57
        Me.lblAdrsfull.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(259, 293)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Item Rate"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ChkBx1)
        Me.Panel1.Controls.Add(Me.dtpordrdt)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(915, 35)
        Me.Panel1.TabIndex = 0
        '
        'ChkBx1
        '
        Me.ChkBx1.AutoSize = True
        Me.ChkBx1.ForeColor = System.Drawing.Color.Black
        Me.ChkBx1.Location = New System.Drawing.Point(567, 6)
        Me.ChkBx1.Name = "ChkBx1"
        Me.ChkBx1.Size = New System.Drawing.Size(185, 17)
        Me.ChkBx1.TabIndex = 1
        Me.ChkBx1.TabStop = False
        Me.ChkBx1.Text = "Is Vendor List Required?"
        Me.ChkBx1.UseVisualStyleBackColor = True
        '
        'dtpordrdt
        '
        Me.dtpordrdt.CustomFormat = "dd/MM/yyyy"
        Me.dtpordrdt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpordrdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpordrdt.Location = New System.Drawing.Point(119, 7)
        Me.dtpordrdt.Name = "dtpordrdt"
        Me.dtpordrdt.Size = New System.Drawing.Size(96, 20)
        Me.dtpordrdt.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Tran. Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 293)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Quantity"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Item Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Item Group"
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = System.Drawing.Color.Transparent
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFind.FlatAppearance.BorderSize = 0
        Me.BtnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.ForeColor = System.Drawing.Color.Navy
        Me.BtnFind.Location = New System.Drawing.Point(698, 5)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(100, 29)
        Me.BtnFind.TabIndex = 14
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = False
        '
        'BtnSe_exit
        '
        Me.BtnSe_exit.BackColor = System.Drawing.Color.Transparent
        Me.BtnSe_exit.BackgroundImage = CType(resources.GetObject("BtnSe_exit.BackgroundImage"), System.Drawing.Image)
        Me.BtnSe_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSe_exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSe_exit.FlatAppearance.BorderSize = 0
        Me.BtnSe_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSe_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSe_exit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSe_exit.ForeColor = System.Drawing.Color.Navy
        Me.BtnSe_exit.Location = New System.Drawing.Point(814, 5)
        Me.BtnSe_exit.Name = "BtnSe_exit"
        Me.BtnSe_exit.Size = New System.Drawing.Size(100, 29)
        Me.BtnSe_exit.TabIndex = 15
        Me.BtnSe_exit.Text = "&Close"
        Me.BtnSe_exit.UseVisualStyleBackColor = False
        '
        'BtnSe_Save
        '
        Me.BtnSe_Save.BackColor = System.Drawing.Color.Transparent
        Me.BtnSe_Save.BackgroundImage = CType(resources.GetObject("BtnSe_Save.BackgroundImage"), System.Drawing.Image)
        Me.BtnSe_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSe_Save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSe_Save.FlatAppearance.BorderSize = 0
        Me.BtnSe_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSe_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSe_Save.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSe_Save.ForeColor = System.Drawing.Color.Navy
        Me.BtnSe_Save.Location = New System.Drawing.Point(582, 5)
        Me.BtnSe_Save.Name = "BtnSe_Save"
        Me.BtnSe_Save.Size = New System.Drawing.Size(100, 29)
        Me.BtnSe_Save.TabIndex = 13
        Me.BtnSe_Save.Text = "&Save"
        Me.BtnSe_Save.UseVisualStyleBackColor = False
        '
        'FrmTranSaleEntryThruChln
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Turquoise
        Me.ClientSize = New System.Drawing.Size(921, 619)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTranSaleEntryThruChln"
        Me.Text = "Sale Entry Through Challan"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContxtDg1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    'Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents BtnSe_Save As System.Windows.Forms.Button
    Friend WithEvents BtnSe_exit As System.Windows.Forms.Button
    Friend WithEvents dtpordrdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPurBillNo As System.Windows.Forms.TextBox
    Friend WithEvents BtnAddCarri As System.Windows.Forms.Button
    Friend WithEvents BtnAddCust As System.Windows.Forms.Button
    Friend WithEvents Btnaddware As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbxCarri As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbxWareh As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblAdrsfull As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ContxtDg1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsubttl As System.Windows.Forms.Label
    Friend WithEvents Txtcoment As System.Windows.Forms.TextBox
    Friend WithEvents ChkBx1 As System.Windows.Forms.CheckBox
    Friend WithEvents CmbxSplr As System.Windows.Forms.ComboBox
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents BtnEditmode As System.Windows.Forms.Button
    Friend WithEvents CmbxItmName As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxItmGrup As System.Windows.Forms.ComboBox
    Friend WithEvents TxtQnty As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtItmRate As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnItm As System.Windows.Forms.Button
    Friend WithEvents BtnGrup As System.Windows.Forms.Button
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents LstVewPurItms As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblType As System.Windows.Forms.Label
    Friend WithEvents LblCurBal As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

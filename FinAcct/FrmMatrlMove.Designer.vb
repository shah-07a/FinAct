<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMatrlMove
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMatrlMove))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.BtnMMSave = New System.Windows.Forms.Button
        Me.BtnMMCancel = New System.Windows.Forms.Button
        Me.BtnMMexit = New System.Windows.Forms.Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Tplitem = New System.Windows.Forms.TableLayoutPanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.RbxiName = New System.Windows.Forms.RadioButton
        Me.Rbxicode = New System.Windows.Forms.RadioButton
        Me.Txticode = New System.Windows.Forms.TextBox
        Me.LstVewItem = New System.Windows.Forms.ListView
        Me.ColIcode = New System.Windows.Forms.ColumnHeader
        Me.ColIname = New System.Windows.Forms.ColumnHeader
        Me.Coliid = New System.Windows.Forms.ColumnHeader
        Me.Colicost = New System.Windows.Forms.ColumnHeader
        Me.Colmin = New System.Windows.Forms.ColumnHeader
        Me.Colmax = New System.Windows.Forms.ColumnHeader
        Me.Colopn = New System.Windows.Forms.ColumnHeader
        Me.Colunt = New System.Windows.Forms.ColumnHeader
        Me.Colitmtype1 = New System.Windows.Forms.ColumnHeader
        Me.ColType = New System.Windows.Forms.ColumnHeader
        Me.ColitmType = New System.Windows.Forms.ColumnHeader
        Me.Lstvewitmall = New System.Windows.Forms.ListView
        Me.Colitmname = New System.Windows.Forms.ColumnHeader
        Me.Colstore = New System.Windows.Forms.ColumnHeader
        Me.ColItmQnty = New System.Windows.Forms.ColumnHeader
        Me.Colrqnty = New System.Windows.Forms.ColumnHeader
        Me.ColSih = New System.Windows.Forms.ColumnHeader
        Me.colblokstok = New System.Windows.Forms.ColumnHeader
        Me.colfreestock = New System.Windows.Forms.ColumnHeader
        Me.Colitmid = New System.Windows.Forms.ColumnHeader
        Me.Colchk1 = New System.Windows.Forms.ColumnHeader
        Me.Colunit = New System.Windows.Forms.ColumnHeader
        Me.collocid = New System.Windows.Forms.ColumnHeader
        Me.ColShort = New System.Windows.Forms.ColumnHeader
        Me.Label3 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.LblNet = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpMovedt = New System.Windows.Forms.DateTimePicker
        Me.lblunit = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblmachinname = New System.Windows.Forms.Label
        Me.txtremark = New System.Windows.Forms.TextBox
        Me.lbldesc = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Txtitmcode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtmovqnty = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblbatno = New System.Windows.Forms.Label
        Me.CmbxWrkrName = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Lblissueto = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblalrt = New System.Windows.Forms.Label
        Me.lblSuggest = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblmax = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblmin = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LblResStock = New System.Windows.Forms.Label
        Me.lblsih = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Tplitem.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnMMSave)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnMMCancel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnMMexit)
        Me.SplitContainer1.Panel1.Enabled = False
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.GhostWhite
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(909, 568)
        Me.SplitContainer1.SplitterDistance = 82
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 0
        Me.SplitContainer1.TabStop = False
        '
        'BtnMMSave
        '
        Me.BtnMMSave.BackgroundImage = CType(resources.GetObject("BtnMMSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnMMSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnMMSave.FlatAppearance.BorderSize = 0
        Me.BtnMMSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnMMSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMMSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMMSave.ForeColor = System.Drawing.Color.Navy
        Me.BtnMMSave.Location = New System.Drawing.Point(4, 461)
        Me.BtnMMSave.Name = "BtnMMSave"
        Me.BtnMMSave.Size = New System.Drawing.Size(72, 29)
        Me.BtnMMSave.TabIndex = 23
        Me.BtnMMSave.Text = "&Ok"
        Me.BtnMMSave.UseVisualStyleBackColor = True
        '
        'BtnMMCancel
        '
        Me.BtnMMCancel.BackgroundImage = CType(resources.GetObject("BtnMMCancel.BackgroundImage"), System.Drawing.Image)
        Me.BtnMMCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnMMCancel.FlatAppearance.BorderSize = 0
        Me.BtnMMCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnMMCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMMCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMMCancel.ForeColor = System.Drawing.Color.Navy
        Me.BtnMMCancel.Location = New System.Drawing.Point(4, 496)
        Me.BtnMMCancel.Name = "BtnMMCancel"
        Me.BtnMMCancel.Size = New System.Drawing.Size(72, 29)
        Me.BtnMMCancel.TabIndex = 24
        Me.BtnMMCancel.Text = "&Cancel"
        Me.BtnMMCancel.UseVisualStyleBackColor = True
        '
        'BtnMMexit
        '
        Me.BtnMMexit.BackgroundImage = CType(resources.GetObject("BtnMMexit.BackgroundImage"), System.Drawing.Image)
        Me.BtnMMexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnMMexit.FlatAppearance.BorderSize = 0
        Me.BtnMMexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnMMexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMMexit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMMexit.ForeColor = System.Drawing.Color.Navy
        Me.BtnMMexit.Location = New System.Drawing.Point(4, 531)
        Me.BtnMMexit.Name = "BtnMMexit"
        Me.BtnMMexit.Size = New System.Drawing.Size(72, 29)
        Me.BtnMMexit.TabIndex = 25
        Me.BtnMMexit.Text = "&Exit"
        Me.BtnMMexit.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 199)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.09693!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.90308!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(818, 386)
        Me.TableLayoutPanel2.TabIndex = 13
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Tplitem)
        Me.Panel5.Controls.Add(Me.Lstvewitmall)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Location = New System.Drawing.Point(4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(810, 378)
        Me.Panel5.TabIndex = 24
        '
        'Tplitem
        '
        Me.Tplitem.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tplitem.ColumnCount = 1
        Me.Tplitem.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tplitem.Controls.Add(Me.Panel3, 0, 0)
        Me.Tplitem.Controls.Add(Me.LstVewItem, 0, 1)
        Me.Tplitem.Enabled = False
        Me.Tplitem.Location = New System.Drawing.Point(148, 52)
        Me.Tplitem.Name = "Tplitem"
        Me.Tplitem.RowCount = 2
        Me.Tplitem.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.35688!))
        Me.Tplitem.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.64312!))
        Me.Tplitem.Size = New System.Drawing.Size(452, 274)
        Me.Tplitem.TabIndex = 5
        Me.Tplitem.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.RbxiName)
        Me.Panel3.Controls.Add(Me.Rbxicode)
        Me.Panel3.Controls.Add(Me.Txticode)
        Me.Panel3.Location = New System.Drawing.Point(4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(444, 38)
        Me.Panel3.TabIndex = 6
        '
        'RbxiName
        '
        Me.RbxiName.AutoSize = True
        Me.RbxiName.Location = New System.Drawing.Point(3, 19)
        Me.RbxiName.Name = "RbxiName"
        Me.RbxiName.Size = New System.Drawing.Size(105, 17)
        Me.RbxiName.TabIndex = 9
        Me.RbxiName.Text = "Search By Name"
        Me.RbxiName.UseVisualStyleBackColor = True
        '
        'Rbxicode
        '
        Me.Rbxicode.AutoSize = True
        Me.Rbxicode.Checked = True
        Me.Rbxicode.Location = New System.Drawing.Point(3, 2)
        Me.Rbxicode.Name = "Rbxicode"
        Me.Rbxicode.Size = New System.Drawing.Size(102, 17)
        Me.Rbxicode.TabIndex = 8
        Me.Rbxicode.TabStop = True
        Me.Rbxicode.Text = "Search By Code"
        Me.Rbxicode.UseVisualStyleBackColor = True
        '
        'Txticode
        '
        Me.Txticode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txticode.Location = New System.Drawing.Point(109, 9)
        Me.Txticode.Name = "Txticode"
        Me.Txticode.Size = New System.Drawing.Size(332, 20)
        Me.Txticode.TabIndex = 7
        '
        'LstVewItem
        '
        Me.LstVewItem.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.LstVewItem.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColIcode, Me.ColIname, Me.Coliid, Me.Colicost, Me.Colmin, Me.Colmax, Me.Colopn, Me.Colunt, Me.Colitmtype1, Me.ColType, Me.ColitmType})
        Me.LstVewItem.FullRowSelect = True
        Me.LstVewItem.GridLines = True
        Me.LstVewItem.Location = New System.Drawing.Point(4, 49)
        Me.LstVewItem.MultiSelect = False
        Me.LstVewItem.Name = "LstVewItem"
        Me.LstVewItem.Size = New System.Drawing.Size(444, 221)
        Me.LstVewItem.TabIndex = 10
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
        'Colitmtype1
        '
        Me.Colitmtype1.Text = "ColiType"
        '
        'ColType
        '
        Me.ColType.Text = "Item Type"
        Me.ColType.Width = 0
        '
        'ColitmType
        '
        Me.ColitmType.Text = "Item Type"
        Me.ColitmType.Width = 0
        '
        'Lstvewitmall
        '
        Me.Lstvewitmall.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Colitmname, Me.Colstore, Me.ColItmQnty, Me.Colrqnty, Me.ColSih, Me.colblokstok, Me.colfreestock, Me.Colitmid, Me.Colchk1, Me.Colunit, Me.collocid, Me.ColShort})
        Me.Lstvewitmall.FullRowSelect = True
        Me.Lstvewitmall.GridLines = True
        Me.Lstvewitmall.Location = New System.Drawing.Point(0, 25)
        Me.Lstvewitmall.Name = "Lstvewitmall"
        Me.Lstvewitmall.Size = New System.Drawing.Size(804, 339)
        Me.Lstvewitmall.TabIndex = 26
        Me.Lstvewitmall.UseCompatibleStateImageBehavior = False
        Me.Lstvewitmall.View = System.Windows.Forms.View.Details
        '
        'Colitmname
        '
        Me.Colitmname.Text = "Process & Item Name"
        Me.Colitmname.Width = 210
        '
        'Colstore
        '
        Me.Colstore.Text = "Location"
        Me.Colstore.Width = 70
        '
        'ColItmQnty
        '
        Me.ColItmQnty.Text = "Qnty. Per Unit"
        Me.ColItmQnty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColItmQnty.Width = 85
        '
        'Colrqnty
        '
        Me.Colrqnty.Text = "Required "
        Me.Colrqnty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColSih
        '
        Me.ColSih.DisplayIndex = 5
        Me.ColSih.Text = "Stock In Hand"
        Me.ColSih.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColSih.Width = 90
        '
        'colblokstok
        '
        Me.colblokstok.DisplayIndex = 6
        Me.colblokstok.Text = "In Demand"
        Me.colblokstok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colblokstok.Width = 70
        '
        'colfreestock
        '
        Me.colfreestock.DisplayIndex = 7
        Me.colfreestock.Text = "Available "
        Me.colfreestock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colfreestock.Width = 65
        '
        'Colitmid
        '
        Me.Colitmid.DisplayIndex = 8
        Me.Colitmid.Text = "Item Id"
        Me.Colitmid.Width = 0
        '
        'Colchk1
        '
        Me.Colchk1.DisplayIndex = 9
        Me.Colchk1.Text = "Issue Status"
        Me.Colchk1.Width = 75
        '
        'Colunit
        '
        Me.Colunit.DisplayIndex = 4
        Me.Colunit.Text = "Unit Type"
        Me.Colunit.Width = 0
        '
        'collocid
        '
        Me.collocid.Text = "Location Id"
        Me.collocid.Width = 0
        '
        'ColShort
        '
        Me.ColShort.Text = "Short Status"
        Me.ColShort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColShort.Width = 75
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Cyan
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(0, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(803, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Attached Item(s) Movement Schema "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LblNet, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DtpMovedt, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblunit, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label20, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label19, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblmachinname, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtremark, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lbldesc, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Txtitmcode, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtmovqnty, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblbatno, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbxWrkrName, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Lblissueto, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label21, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblalrt, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSuggest, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 2, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143507!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143506!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.140894!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.144075!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.144075!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143506!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143506!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(817, 193)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'LblNet
        '
        Me.LblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblNet.Location = New System.Drawing.Point(533, 55)
        Me.LblNet.Name = "LblNet"
        Me.LblNet.Size = New System.Drawing.Size(98, 20)
        Me.LblNet.TabIndex = 28
        Me.LblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'DtpMovedt
        '
        Me.DtpMovedt.CustomFormat = "dd/MM/yyyy"
        Me.DtpMovedt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpMovedt.Location = New System.Drawing.Point(126, 4)
        Me.DtpMovedt.Name = "DtpMovedt"
        Me.DtpMovedt.Size = New System.Drawing.Size(115, 20)
        Me.DtpMovedt.TabIndex = 2
        '
        'lblunit
        '
        Me.lblunit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblunit.Location = New System.Drawing.Point(126, 136)
        Me.lblunit.Name = "lblunit"
        Me.lblunit.Size = New System.Drawing.Size(98, 20)
        Me.lblunit.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Units"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(411, 109)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 13)
        Me.Label20.TabIndex = 25
        Me.Label20.Text = "Machine/Tool  Name"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(411, 136)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(115, 26)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Remarks"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblmachinname
        '
        Me.lblmachinname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblmachinname.Location = New System.Drawing.Point(533, 109)
        Me.lblmachinname.Name = "lblmachinname"
        Me.lblmachinname.Size = New System.Drawing.Size(280, 21)
        Me.lblmachinname.TabIndex = 13
        '
        'txtremark
        '
        Me.txtremark.Location = New System.Drawing.Point(533, 139)
        Me.txtremark.MaxLength = 150
        Me.txtremark.Name = "txtremark"
        Me.txtremark.Size = New System.Drawing.Size(280, 20)
        Me.txtremark.TabIndex = 21
        '
        'lbldesc
        '
        Me.lbldesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbldesc.Location = New System.Drawing.Point(126, 109)
        Me.lbldesc.Name = "lbldesc"
        Me.lbldesc.Size = New System.Drawing.Size(278, 20)
        Me.lbldesc.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Item'sDescription"
        '
        'Txtitmcode
        '
        Me.Txtitmcode.BackColor = System.Drawing.Color.White
        Me.Txtitmcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtitmcode.Location = New System.Drawing.Point(126, 85)
        Me.Txtitmcode.Name = "Txtitmcode"
        Me.Txtitmcode.ReadOnly = True
        Me.Txtitmcode.Size = New System.Drawing.Size(115, 20)
        Me.Txtitmcode.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Item Code"
        '
        'txtmovqnty
        '
        Me.txtmovqnty.Location = New System.Drawing.Point(126, 58)
        Me.txtmovqnty.Name = "txtmovqnty"
        Me.txtmovqnty.Size = New System.Drawing.Size(100, 20)
        Me.txtmovqnty.TabIndex = 3
        Me.txtmovqnty.Text = "1"
        Me.txtmovqnty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Qnty. To Produce" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(4, 28)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 13)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "Batch No."
        '
        'lblbatno
        '
        Me.lblbatno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblbatno.Location = New System.Drawing.Point(126, 28)
        Me.lblbatno.Name = "lblbatno"
        Me.lblbatno.Size = New System.Drawing.Size(115, 20)
        Me.lblbatno.TabIndex = 30
        Me.lblbatno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxWrkrName
        '
        Me.CmbxWrkrName.FormattingEnabled = True
        Me.CmbxWrkrName.Location = New System.Drawing.Point(533, 85)
        Me.CmbxWrkrName.Name = "CmbxWrkrName"
        Me.CmbxWrkrName.Size = New System.Drawing.Size(275, 21)
        Me.CmbxWrkrName.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 26)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Move/Issue To Process "
        '
        'Lblissueto
        '
        Me.Lblissueto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblissueto.Location = New System.Drawing.Point(126, 163)
        Me.Lblissueto.Name = "Lblissueto"
        Me.Lblissueto.Size = New System.Drawing.Size(278, 20)
        Me.Lblissueto.TabIndex = 31
        Me.Lblissueto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(411, 82)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 13)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "Worker Name"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(411, 1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 26)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Re-Order Level (Min. Qnty.)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblalrt
        '
        Me.lblalrt.BackColor = System.Drawing.Color.Yellow
        Me.lblalrt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblalrt.Location = New System.Drawing.Point(411, 163)
        Me.lblalrt.Name = "lblalrt"
        Me.lblalrt.Size = New System.Drawing.Size(115, 26)
        Me.lblalrt.TabIndex = 25
        Me.lblalrt.Text = "Alert!"
        Me.lblalrt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblalrt.Visible = False
        '
        'lblSuggest
        '
        Me.lblSuggest.BackColor = System.Drawing.Color.LightYellow
        Me.lblSuggest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuggest.ForeColor = System.Drawing.Color.Navy
        Me.lblSuggest.Location = New System.Drawing.Point(533, 163)
        Me.lblSuggest.Name = "lblSuggest"
        Me.lblSuggest.Size = New System.Drawing.Size(280, 29)
        Me.lblSuggest.TabIndex = 31
        Me.lblSuggest.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblmax)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.lblmin)
        Me.Panel1.Location = New System.Drawing.Point(533, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(280, 20)
        Me.Panel1.TabIndex = 32
        '
        'lblmax
        '
        Me.lblmax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblmax.Location = New System.Drawing.Point(196, 0)
        Me.lblmax.Name = "lblmax"
        Me.lblmax.Size = New System.Drawing.Size(78, 20)
        Me.lblmax.TabIndex = 26
        Me.lblmax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(113, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 13)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Maximum Qnty."
        '
        'lblmin
        '
        Me.lblmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblmin.Location = New System.Drawing.Point(0, 0)
        Me.lblmin.Name = "lblmin"
        Me.lblmin.Size = New System.Drawing.Size(98, 20)
        Me.lblmin.TabIndex = 25
        Me.lblmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LblResStock)
        Me.Panel2.Controls.Add(Me.lblsih)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(533, 31)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(280, 20)
        Me.Panel2.TabIndex = 33
        '
        'LblResStock
        '
        Me.LblResStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblResStock.Location = New System.Drawing.Point(196, 0)
        Me.LblResStock.Name = "LblResStock"
        Me.LblResStock.Size = New System.Drawing.Size(78, 20)
        Me.LblResStock.TabIndex = 28
        Me.LblResStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblsih
        '
        Me.lblsih.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblsih.Location = New System.Drawing.Point(0, 0)
        Me.lblsih.Name = "lblsih"
        Me.lblsih.Size = New System.Drawing.Size(98, 20)
        Me.lblsih.TabIndex = 28
        Me.lblsih.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(103, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Restricted  Stock"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(411, 28)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(115, 26)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Stock In Hand"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(411, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 26)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Net Position Of  The Stock"
        '
        'FrmMatrlMove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(914, 573)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmMatrlMove"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "In House Material Movement cum Material Requirment Planner (MRP)"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Tplitem.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents BtnMMSave As System.Windows.Forms.Button
    Friend WithEvents BtnMMCancel As System.Windows.Forms.Button
    Friend WithEvents BtnMMexit As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txtitmcode As System.Windows.Forms.TextBox
    Friend WithEvents DtpMovedt As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbldesc As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CmbxWrkrName As System.Windows.Forms.ComboBox
    Friend WithEvents lblmachinname As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtmovqnty As System.Windows.Forms.TextBox
    Friend WithEvents lblunit As System.Windows.Forms.Label
    Friend WithEvents Tplitem As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Txticode As System.Windows.Forms.TextBox
    Friend WithEvents LstVewItem As System.Windows.Forms.ListView
    Friend WithEvents ColIcode As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColIname As System.Windows.Forms.ColumnHeader
    Friend WithEvents Coliid As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colicost As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colmin As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colmax As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colopn As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colunt As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblsih As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblmin As System.Windows.Forms.Label
    Friend WithEvents lblmax As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblbatno As System.Windows.Forms.Label
    Friend WithEvents txtremark As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Colitmtype1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Lstvewitmall As System.Windows.Forms.ListView
    Friend WithEvents Colitmname As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colstore As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColItmQnty As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colrqnty As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ColSih As System.Windows.Forms.ColumnHeader
    Friend WithEvents colblokstok As System.Windows.Forms.ColumnHeader
    Friend WithEvents colfreestock As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colitmid As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colchk1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colunit As System.Windows.Forms.ColumnHeader
    Friend WithEvents Lblissueto As System.Windows.Forms.Label
    Friend WithEvents lblalrt As System.Windows.Forms.Label
    Friend WithEvents lblSuggest As System.Windows.Forms.Label
    Friend WithEvents collocid As System.Windows.Forms.ColumnHeader
    Friend WithEvents RbxiName As System.Windows.Forms.RadioButton
    Friend WithEvents Rbxicode As System.Windows.Forms.RadioButton
    Friend WithEvents ColType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColitmType As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblResStock As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblNet As System.Windows.Forms.Label
    Friend WithEvents ColShort As System.Windows.Forms.ColumnHeader
End Class

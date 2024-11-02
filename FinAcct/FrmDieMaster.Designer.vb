<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDieMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDieMaster))
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.DieDg = New System.Windows.Forms.DataGridView
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.lblsubp = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.lblname = New System.Windows.Forms.Label
        Me.lblMainp = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.lblloc = New System.Windows.Forms.Label
        Me.BtnDieSave = New System.Windows.Forms.Button
        Me.BtnDie = New System.Windows.Forms.Button
        Me.BtnDieCancl = New System.Windows.Forms.Button
        Me.BtnDieExit = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDieCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDieName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.NudDieCapcty = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.NudMaxProd = New System.Windows.Forms.NumericUpDown
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.NudDiePlosh = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.DtpDie = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnDLoc = New System.Windows.Forms.Button
        Me.CmbxDieLoc = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Cmbxitem = New System.Windows.Forms.ComboBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.CmbxDieMaker = New System.Windows.Forms.ComboBox
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DieDg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.NudDieCapcty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudMaxProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDiePlosh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(629, 73)
        Me.Panel4.TabIndex = 28
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(556, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 75)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.DieDg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnDieSave)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnDie)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnDieCancl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnDieExit)
        Me.SplitContainer1.Panel1.Enabled = False
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.GhostWhite
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(629, 413)
        Me.SplitContainer1.SplitterDistance = 164
        Me.SplitContainer1.TabIndex = 29
        Me.SplitContainer1.TabStop = False
        '
        'DieDg
        '
        Me.DieDg.AllowUserToOrderColumns = True
        Me.DieDg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DieDg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DieDg.Location = New System.Drawing.Point(3, 187)
        Me.DieDg.Name = "DieDg"
        Me.DieDg.Size = New System.Drawing.Size(159, 38)
        Me.DieDg.TabIndex = 31
        Me.DieDg.Visible = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.lblsubp)
        Me.Panel8.Controls.Add(Me.Label26)
        Me.Panel8.Controls.Add(Me.Label32)
        Me.Panel8.Controls.Add(Me.lblname)
        Me.Panel8.Controls.Add(Me.lblMainp)
        Me.Panel8.Controls.Add(Me.Label28)
        Me.Panel8.Controls.Add(Me.Label30)
        Me.Panel8.Controls.Add(Me.lblloc)
        Me.Panel8.Location = New System.Drawing.Point(3, 4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(159, 163)
        Me.Panel8.TabIndex = 30
        Me.Panel8.Visible = False
        '
        'lblsubp
        '
        Me.lblsubp.AutoSize = True
        Me.lblsubp.ForeColor = System.Drawing.Color.Snow
        Me.lblsubp.Location = New System.Drawing.Point(7, 138)
        Me.lblsubp.Name = "lblsubp"
        Me.lblsubp.Size = New System.Drawing.Size(45, 13)
        Me.lblsubp.TabIndex = 0
        Me.lblsubp.Text = "Label26"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(6, 4)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(38, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "NAME"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Yellow
        Me.Label32.Location = New System.Drawing.Point(7, 123)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(83, 13)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "SUB POSITION"
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.ForeColor = System.Drawing.Color.Snow
        Me.lblname.Location = New System.Drawing.Point(6, 19)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(45, 13)
        Me.lblname.TabIndex = 0
        Me.lblname.Text = "Label26"
        '
        'lblMainp
        '
        Me.lblMainp.AutoSize = True
        Me.lblMainp.ForeColor = System.Drawing.Color.Snow
        Me.lblMainp.Location = New System.Drawing.Point(7, 98)
        Me.lblMainp.Name = "lblMainp"
        Me.lblMainp.Size = New System.Drawing.Size(45, 13)
        Me.lblMainp.TabIndex = 0
        Me.lblMainp.Text = "Label26"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.Yellow
        Me.Label28.Location = New System.Drawing.Point(6, 44)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(61, 13)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "LOCATION"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.Yellow
        Me.Label30.Location = New System.Drawing.Point(7, 85)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(88, 13)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "MAIN POSITION"
        '
        'lblloc
        '
        Me.lblloc.AutoSize = True
        Me.lblloc.ForeColor = System.Drawing.Color.Snow
        Me.lblloc.Location = New System.Drawing.Point(7, 59)
        Me.lblloc.Name = "lblloc"
        Me.lblloc.Size = New System.Drawing.Size(45, 13)
        Me.lblloc.TabIndex = 0
        Me.lblloc.Text = "Label26"
        '
        'BtnDieSave
        '
        Me.BtnDieSave.BackgroundImage = CType(resources.GetObject("BtnDieSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnDieSave.Location = New System.Drawing.Point(3, 266)
        Me.BtnDieSave.Name = "BtnDieSave"
        Me.BtnDieSave.Size = New System.Drawing.Size(158, 31)
        Me.BtnDieSave.TabIndex = 13
        Me.BtnDieSave.Text = "&Save"
        Me.BtnDieSave.UseVisualStyleBackColor = True
        '
        'BtnDie
        '
        Me.BtnDie.BackgroundImage = CType(resources.GetObject("BtnDie.BackgroundImage"), System.Drawing.Image)
        Me.BtnDie.Location = New System.Drawing.Point(3, 303)
        Me.BtnDie.Name = "BtnDie"
        Me.BtnDie.Size = New System.Drawing.Size(158, 31)
        Me.BtnDie.TabIndex = 14
        Me.BtnDie.Text = "&Find"
        Me.BtnDie.UseVisualStyleBackColor = True
        '
        'BtnDieCancl
        '
        Me.BtnDieCancl.BackgroundImage = CType(resources.GetObject("BtnDieCancl.BackgroundImage"), System.Drawing.Image)
        Me.BtnDieCancl.Location = New System.Drawing.Point(3, 340)
        Me.BtnDieCancl.Name = "BtnDieCancl"
        Me.BtnDieCancl.Size = New System.Drawing.Size(158, 31)
        Me.BtnDieCancl.TabIndex = 15
        Me.BtnDieCancl.Text = "&Cancel"
        Me.BtnDieCancl.UseVisualStyleBackColor = True
        '
        'BtnDieExit
        '
        Me.BtnDieExit.BackgroundImage = CType(resources.GetObject("BtnDieExit.BackgroundImage"), System.Drawing.Image)
        Me.BtnDieExit.Location = New System.Drawing.Point(3, 377)
        Me.BtnDieExit.Name = "BtnDieExit"
        Me.BtnDieExit.Size = New System.Drawing.Size(158, 31)
        Me.BtnDieExit.TabIndex = 16
        Me.BtnDieExit.Text = "&Exit"
        Me.BtnDieExit.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.89183!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.10817!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtDieCode, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtDieName, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.NudDieCapcty, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.NudMaxProd, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.NudDiePlosh, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.DtpDie, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 7)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11229!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11229!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11229!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.1088!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.1088!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11563!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11229!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.1088!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.1088!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(454, 408)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Die Code"
        '
        'TxtDieCode
        '
        Me.TxtDieCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDieCode.Location = New System.Drawing.Point(153, 4)
        Me.TxtDieCode.MaxLength = 8
        Me.TxtDieCode.Name = "TxtDieCode"
        Me.TxtDieCode.Size = New System.Drawing.Size(109, 22)
        Me.TxtDieCode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Die Name"
        '
        'TxtDieName
        '
        Me.TxtDieName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDieName.Location = New System.Drawing.Point(153, 49)
        Me.TxtDieName.MaxLength = 100
        Me.TxtDieName.Name = "TxtDieName"
        Me.TxtDieName.Size = New System.Drawing.Size(297, 22)
        Me.TxtDieName.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Location"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Capacity"
        '
        'NudDieCapcty
        '
        Me.NudDieCapcty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NudDieCapcty.Location = New System.Drawing.Point(153, 139)
        Me.NudDieCapcty.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NudDieCapcty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDieCapcty.Name = "NudDieCapcty"
        Me.NudDieCapcty.Size = New System.Drawing.Size(109, 22)
        Me.NudDieCapcty.TabIndex = 5
        Me.NudDieCapcty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 28)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Maximum Production In One Hour"
        '
        'NudMaxProd
        '
        Me.NudMaxProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NudMaxProd.Location = New System.Drawing.Point(153, 184)
        Me.NudMaxProd.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NudMaxProd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMaxProd.Name = "NudMaxProd"
        Me.NudMaxProd.Size = New System.Drawing.Size(109, 22)
        Me.NudMaxProd.TabIndex = 6
        Me.NudMaxProd.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 271)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 28)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Item To Be Produce By This Die"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 14)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Polish Required After"
        '
        'NudDiePlosh
        '
        Me.NudDiePlosh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NudDiePlosh.Location = New System.Drawing.Point(153, 229)
        Me.NudDiePlosh.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NudDiePlosh.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDiePlosh.Name = "NudDiePlosh"
        Me.NudDiePlosh.Size = New System.Drawing.Size(109, 22)
        Me.NudDiePlosh.TabIndex = 7
        Me.NudDiePlosh.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 316)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Die Maker Name"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 361)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 14)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Date "
        '
        'DtpDie
        '
        Me.DtpDie.CustomFormat = "dd/MM/yyyy"
        Me.DtpDie.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDie.Location = New System.Drawing.Point(153, 364)
        Me.DtpDie.Name = "DtpDie"
        Me.DtpDie.Size = New System.Drawing.Size(109, 22)
        Me.DtpDie.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnDLoc)
        Me.Panel1.Controls.Add(Me.CmbxDieLoc)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(153, 94)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(297, 38)
        Me.Panel1.TabIndex = 3
        '
        'BtnDLoc
        '
        Me.BtnDLoc.BackgroundImage = CType(resources.GetObject("BtnDLoc.BackgroundImage"), System.Drawing.Image)
        Me.BtnDLoc.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDLoc.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnDLoc.Location = New System.Drawing.Point(256, 1)
        Me.BtnDLoc.Name = "BtnDLoc"
        Me.BtnDLoc.Size = New System.Drawing.Size(37, 23)
        Me.BtnDLoc.TabIndex = 4
        Me.BtnDLoc.TabStop = False
        Me.BtnDLoc.Text = "...."
        Me.BtnDLoc.UseVisualStyleBackColor = True
        '
        'CmbxDieLoc
        '
        Me.CmbxDieLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxDieLoc.FormattingEnabled = True
        Me.CmbxDieLoc.Location = New System.Drawing.Point(0, 1)
        Me.CmbxDieLoc.Name = "CmbxDieLoc"
        Me.CmbxDieLoc.Size = New System.Drawing.Size(250, 22)
        Me.CmbxDieLoc.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Cmbxitem)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(153, 274)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(297, 38)
        Me.Panel2.TabIndex = 8
        '
        'Cmbxitem
        '
        Me.Cmbxitem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxitem.FormattingEnabled = True
        Me.Cmbxitem.Location = New System.Drawing.Point(0, 0)
        Me.Cmbxitem.Name = "Cmbxitem"
        Me.Cmbxitem.Size = New System.Drawing.Size(297, 22)
        Me.Cmbxitem.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.CmbxDieMaker)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(153, 319)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(297, 38)
        Me.Panel3.TabIndex = 10
        '
        'CmbxDieMaker
        '
        Me.CmbxDieMaker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxDieMaker.FormattingEnabled = True
        Me.CmbxDieMaker.Location = New System.Drawing.Point(0, 0)
        Me.CmbxDieMaker.Name = "CmbxDieMaker"
        Me.CmbxDieMaker.Size = New System.Drawing.Size(297, 22)
        Me.CmbxDieMaker.TabIndex = 11
        '
        'FrmDieMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(630, 491)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmDieMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Die Master"
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DieDg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.NudDieCapcty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudMaxProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDiePlosh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtDieCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDieName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbxDieLoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NudDieCapcty As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NudMaxProd As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NudDiePlosh As System.Windows.Forms.NumericUpDown
    Friend WithEvents Cmbxitem As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DtpDie As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnDieSave As System.Windows.Forms.Button
    Friend WithEvents BtnDie As System.Windows.Forms.Button
    Friend WithEvents BtnDieCancl As System.Windows.Forms.Button
    Friend WithEvents BtnDieExit As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtnDLoc As System.Windows.Forms.Button
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents lblsubp As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents lblMainp As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblloc As System.Windows.Forms.Label
    Friend WithEvents CmbxDieMaker As System.Windows.Forms.ComboBox
    Friend WithEvents DieDg As System.Windows.Forms.DataGridView
End Class

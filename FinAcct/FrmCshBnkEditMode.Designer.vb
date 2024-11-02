<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCshBnkEditMode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCshBnkEditMode))
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BTNoK = New System.Windows.Forms.Button
        Me.Btnbok = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.LblCrNo = New System.Windows.Forms.Label
        Me.LblCr = New System.Windows.Forms.Label
        Me.TxtBokAmt = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbBokName = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.EntryType = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpkrCbnk = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Lblvno = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Mskdbxdate = New System.Windows.Forms.MaskedTextBox
        Me.BtnDrawn = New System.Windows.Forms.Button
        Me.CmbxDrawn = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnCon = New System.Windows.Forms.Button
        Me.BtnPay = New System.Windows.Forms.Button
        Me.BtnRecd = New System.Windows.Forms.Button
        Me.CmbxNar = New System.Windows.Forms.ComboBox
        Me.BtnNarr = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbxACname = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Txtamt = New System.Windows.Forms.TextBox
        Me.LblDr = New System.Windows.Forms.Label
        Me.BtnAct = New System.Windows.Forms.Button
        Me.BtnOkAmt = New System.Windows.Forms.Button
        Me.LstVewAmtDetails = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.CmsEditMode = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LstVewAmtDetailsBackup = New System.Windows.Forms.ListView
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.CmsEditMode.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.BackColor = System.Drawing.Color.NavajoWhite
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnAdd)
        Me.Panel4.Controls.Add(Me.BtnClose)
        Me.Panel4.Location = New System.Drawing.Point(4, 524)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(638, 45)
        Me.Panel4.TabIndex = 30
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.BackgroundImage = CType(resources.GetObject("BtnAdd.BackgroundImage"), System.Drawing.Image)
        Me.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdd.FlatAppearance.BorderSize = 0
        Me.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Navy
        Me.BtnAdd.Location = New System.Drawing.Point(362, 5)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(132, 33)
        Me.BtnAdd.TabIndex = 13
        Me.BtnAdd.Text = "&Update"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.Transparent
        Me.BtnClose.BackgroundImage = CType(resources.GetObject("BtnClose.BackgroundImage"), System.Drawing.Image)
        Me.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClose.FlatAppearance.BorderSize = 0
        Me.BtnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.Navy
        Me.BtnClose.Location = New System.Drawing.Point(500, 5)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(132, 33)
        Me.BtnClose.TabIndex = 16
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SpringGreen
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BTNoK)
        Me.Panel2.Controls.Add(Me.Btnbok)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.LblCrNo)
        Me.Panel2.Controls.Add(Me.LblCr)
        Me.Panel2.Controls.Add(Me.TxtBokAmt)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.CmbBokName)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.EntryType)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.DtpkrCbnk)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Lblvno)
        Me.Panel2.Location = New System.Drawing.Point(3, 49)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(639, 151)
        Me.Panel2.TabIndex = 26
        '
        'BTNoK
        '
        Me.BTNoK.BackColor = System.Drawing.Color.Transparent
        Me.BTNoK.Location = New System.Drawing.Point(261, 118)
        Me.BTNoK.Name = "BTNoK"
        Me.BTNoK.Size = New System.Drawing.Size(35, 23)
        Me.BTNoK.TabIndex = 21
        Me.BTNoK.TabStop = False
        Me.BTNoK.Text = "&OK"
        Me.BTNoK.UseVisualStyleBackColor = False
        '
        'Btnbok
        '
        Me.Btnbok.BackColor = System.Drawing.Color.Transparent
        Me.Btnbok.Location = New System.Drawing.Point(601, 64)
        Me.Btnbok.Name = "Btnbok"
        Me.Btnbok.Size = New System.Drawing.Size(35, 23)
        Me.Btnbok.TabIndex = 21
        Me.Btnbok.TabStop = False
        Me.Btnbok.Text = "...."
        Me.Btnbok.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(420, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 20)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Cash Receipt No.:-"
        Me.Label10.Visible = False
        '
        'LblCrNo
        '
        Me.LblCrNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCrNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCrNo.Location = New System.Drawing.Point(546, 16)
        Me.LblCrNo.Name = "LblCrNo"
        Me.LblCrNo.Size = New System.Drawing.Size(88, 20)
        Me.LblCrNo.TabIndex = 19
        Me.LblCrNo.Text = "0"
        Me.LblCrNo.Visible = False
        '
        'LblCr
        '
        Me.LblCr.AutoSize = True
        Me.LblCr.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCr.ForeColor = System.Drawing.Color.Black
        Me.LblCr.Location = New System.Drawing.Point(117, 95)
        Me.LblCr.Name = "LblCr"
        Me.LblCr.Size = New System.Drawing.Size(24, 16)
        Me.LblCr.TabIndex = 6
        Me.LblCr.Text = "Cr"
        Me.LblCr.Visible = False
        '
        'TxtBokAmt
        '
        Me.TxtBokAmt.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBokAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBokAmt.Location = New System.Drawing.Point(120, 120)
        Me.TxtBokAmt.MaxLength = 29
        Me.TxtBokAmt.Name = "TxtBokAmt"
        Me.TxtBokAmt.Size = New System.Drawing.Size(136, 21)
        Me.TxtBokAmt.TabIndex = 7
        Me.TxtBokAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cash/Bank"
        '
        'CmbBokName
        '
        Me.CmbBokName.Location = New System.Drawing.Point(120, 65)
        Me.CmbBokName.Name = "CmbBokName"
        Me.CmbBokName.Size = New System.Drawing.Size(476, 21)
        Me.CmbBokName.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 122)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 16)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Amount :-"
        '
        'EntryType
        '
        Me.EntryType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EntryType.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EntryType.Location = New System.Drawing.Point(120, 16)
        Me.EntryType.Name = "EntryType"
        Me.EntryType.Size = New System.Drawing.Size(150, 20)
        Me.EntryType.TabIndex = 5
        Me.EntryType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(0, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(638, 7)
        Me.Label1.TabIndex = 1
        '
        'DtpkrCbnk
        '
        Me.DtpkrCbnk.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrCbnk.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrCbnk.Location = New System.Drawing.Point(6, 12)
        Me.DtpkrCbnk.Name = "DtpkrCbnk"
        Me.DtpkrCbnk.Size = New System.Drawing.Size(111, 21)
        Me.DtpkrCbnk.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(276, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "  No."
        '
        'Lblvno
        '
        Me.Lblvno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblvno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblvno.Location = New System.Drawing.Point(321, 16)
        Me.Lblvno.Name = "Lblvno"
        Me.Lblvno.Size = New System.Drawing.Size(77, 20)
        Me.Lblvno.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(474, 462)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 16)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Date : "
        '
        'Mskdbxdate
        '
        Me.Mskdbxdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Mskdbxdate.Location = New System.Drawing.Point(535, 462)
        Me.Mskdbxdate.Mask = "00/00/0000"
        Me.Mskdbxdate.Name = "Mskdbxdate"
        Me.Mskdbxdate.Size = New System.Drawing.Size(100, 21)
        Me.Mskdbxdate.TabIndex = 29
        Me.Mskdbxdate.Text = "00000000"
        Me.Mskdbxdate.ValidatingType = GetType(Date)
        '
        'BtnDrawn
        '
        Me.BtnDrawn.BackColor = System.Drawing.Color.Transparent
        Me.BtnDrawn.Location = New System.Drawing.Point(369, 460)
        Me.BtnDrawn.Name = "BtnDrawn"
        Me.BtnDrawn.Size = New System.Drawing.Size(35, 23)
        Me.BtnDrawn.TabIndex = 32
        Me.BtnDrawn.TabStop = False
        Me.BtnDrawn.Text = "...."
        Me.BtnDrawn.UseVisualStyleBackColor = False
        '
        'CmbxDrawn
        '
        Me.CmbxDrawn.FormattingEnabled = True
        Me.CmbxDrawn.Location = New System.Drawing.Point(123, 462)
        Me.CmbxDrawn.MaxLength = 100
        Me.CmbxDrawn.Name = "CmbxDrawn"
        Me.CmbxDrawn.Size = New System.Drawing.Size(241, 21)
        Me.CmbxDrawn.TabIndex = 28
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.NavajoWhite
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnCon)
        Me.Panel1.Controls.Add(Me.BtnPay)
        Me.Panel1.Controls.Add(Me.BtnRecd)
        Me.Panel1.Location = New System.Drawing.Point(3, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(639, 40)
        Me.Panel1.TabIndex = 23
        '
        'BtnCon
        '
        Me.BtnCon.BackColor = System.Drawing.Color.Transparent
        Me.BtnCon.BackgroundImage = CType(resources.GetObject("BtnCon.BackgroundImage"), System.Drawing.Image)
        Me.BtnCon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCon.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCon.FlatAppearance.BorderSize = 0
        Me.BtnCon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCon.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCon.ForeColor = System.Drawing.Color.Navy
        Me.BtnCon.Location = New System.Drawing.Point(502, 4)
        Me.BtnCon.Name = "BtnCon"
        Me.BtnCon.Size = New System.Drawing.Size(132, 32)
        Me.BtnCon.TabIndex = 3
        Me.BtnCon.Text = "< Contra >"
        Me.BtnCon.UseVisualStyleBackColor = False
        '
        'BtnPay
        '
        Me.BtnPay.BackColor = System.Drawing.Color.Transparent
        Me.BtnPay.BackgroundImage = CType(resources.GetObject("BtnPay.BackgroundImage"), System.Drawing.Image)
        Me.BtnPay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPay.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnPay.FlatAppearance.BorderSize = 0
        Me.BtnPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPay.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPay.ForeColor = System.Drawing.Color.Navy
        Me.BtnPay.Location = New System.Drawing.Point(243, 4)
        Me.BtnPay.Name = "BtnPay"
        Me.BtnPay.Size = New System.Drawing.Size(132, 32)
        Me.BtnPay.TabIndex = 2
        Me.BtnPay.Text = "< Payment >"
        Me.BtnPay.UseVisualStyleBackColor = False
        '
        'BtnRecd
        '
        Me.BtnRecd.BackColor = System.Drawing.Color.Transparent
        Me.BtnRecd.BackgroundImage = CType(resources.GetObject("BtnRecd.BackgroundImage"), System.Drawing.Image)
        Me.BtnRecd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRecd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRecd.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnRecd.FlatAppearance.BorderSize = 0
        Me.BtnRecd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnRecd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRecd.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRecd.ForeColor = System.Drawing.Color.Navy
        Me.BtnRecd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRecd.Location = New System.Drawing.Point(3, 4)
        Me.BtnRecd.Name = "BtnRecd"
        Me.BtnRecd.Size = New System.Drawing.Size(132, 32)
        Me.BtnRecd.TabIndex = 1
        Me.BtnRecd.Tag = ""
        Me.BtnRecd.Text = "< Receipt >"
        Me.BtnRecd.UseVisualStyleBackColor = False
        '
        'CmbxNar
        '
        Me.CmbxNar.FormattingEnabled = True
        Me.CmbxNar.Location = New System.Drawing.Point(124, 495)
        Me.CmbxNar.MaxLength = 150
        Me.CmbxNar.Name = "CmbxNar"
        Me.CmbxNar.Size = New System.Drawing.Size(476, 21)
        Me.CmbxNar.TabIndex = 31
        '
        'BtnNarr
        '
        Me.BtnNarr.BackColor = System.Drawing.Color.Transparent
        Me.BtnNarr.Location = New System.Drawing.Point(604, 493)
        Me.BtnNarr.Name = "BtnNarr"
        Me.BtnNarr.Size = New System.Drawing.Size(35, 23)
        Me.BtnNarr.TabIndex = 33
        Me.BtnNarr.TabStop = False
        Me.BtnNarr.Text = "...."
        Me.BtnNarr.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 462)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Drawn On : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 495)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 16)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Narration : "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Amount :-"
        '
        'CmbxACname
        '
        Me.CmbxACname.Location = New System.Drawing.Point(120, 4)
        Me.CmbxACname.Name = "CmbxACname"
        Me.CmbxACname.Size = New System.Drawing.Size(475, 21)
        Me.CmbxACname.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Account Name"
        '
        'Txtamt
        '
        Me.Txtamt.BackColor = System.Drawing.SystemColors.Window
        Me.Txtamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtamt.Enabled = False
        Me.Txtamt.Location = New System.Drawing.Point(120, 55)
        Me.Txtamt.MaxLength = 29
        Me.Txtamt.Name = "Txtamt"
        Me.Txtamt.Size = New System.Drawing.Size(135, 21)
        Me.Txtamt.TabIndex = 9
        Me.Txtamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDr
        '
        Me.LblDr.AutoSize = True
        Me.LblDr.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDr.ForeColor = System.Drawing.Color.Black
        Me.LblDr.Location = New System.Drawing.Point(116, 31)
        Me.LblDr.Name = "LblDr"
        Me.LblDr.Size = New System.Drawing.Size(24, 16)
        Me.LblDr.TabIndex = 6
        Me.LblDr.Text = "Dr"
        Me.LblDr.Visible = False
        '
        'BtnAct
        '
        Me.BtnAct.BackColor = System.Drawing.Color.Transparent
        Me.BtnAct.Location = New System.Drawing.Point(600, 3)
        Me.BtnAct.Name = "BtnAct"
        Me.BtnAct.Size = New System.Drawing.Size(35, 23)
        Me.BtnAct.TabIndex = 21
        Me.BtnAct.TabStop = False
        Me.BtnAct.Text = "...."
        Me.BtnAct.UseVisualStyleBackColor = False
        '
        'BtnOkAmt
        '
        Me.BtnOkAmt.BackColor = System.Drawing.Color.Transparent
        Me.BtnOkAmt.Location = New System.Drawing.Point(261, 54)
        Me.BtnOkAmt.Name = "BtnOkAmt"
        Me.BtnOkAmt.Size = New System.Drawing.Size(35, 23)
        Me.BtnOkAmt.TabIndex = 21
        Me.BtnOkAmt.TabStop = False
        Me.BtnOkAmt.Text = "&OK"
        Me.BtnOkAmt.UseVisualStyleBackColor = False
        '
        'LstVewAmtDetails
        '
        Me.LstVewAmtDetails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.LstVewAmtDetails.ContextMenuStrip = Me.CmsEditMode
        Me.LstVewAmtDetails.FullRowSelect = True
        Me.LstVewAmtDetails.GridLines = True
        Me.LstVewAmtDetails.Location = New System.Drawing.Point(120, 85)
        Me.LstVewAmtDetails.Name = "LstVewAmtDetails"
        Me.LstVewAmtDetails.Size = New System.Drawing.Size(512, 155)
        Me.LstVewAmtDetails.TabIndex = 23
        Me.LstVewAmtDetails.UseCompatibleStateImageBehavior = False
        Me.LstVewAmtDetails.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 360
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Amount"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 125
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Act Id"
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Rec Id"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Edit Flag"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Split Status"
        Me.ColumnHeader6.Width = 0
        '
        'CmsEditMode
        '
        Me.CmsEditMode.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem1, Me.DeleteSelectedToolStripMenuItem, Me.UpdateToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.CmsEditMode.Name = "CmsEditMode"
        Me.CmsEditMode.Size = New System.Drawing.Size(124, 114)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(123, 22)
        Me.ToolStripMenuItem2.Text = "Add New"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 22)
        Me.ToolStripMenuItem1.Text = "Edit "
        '
        'DeleteSelectedToolStripMenuItem
        '
        Me.DeleteSelectedToolStripMenuItem.Name = "DeleteSelectedToolStripMenuItem"
        Me.DeleteSelectedToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.DeleteSelectedToolStripMenuItem.Text = "Delete  "
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightGreen
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.LstVewAmtDetailsBackup)
        Me.Panel3.Controls.Add(Me.LstVewAmtDetails)
        Me.Panel3.Controls.Add(Me.BtnOkAmt)
        Me.Panel3.Controls.Add(Me.BtnAct)
        Me.Panel3.Controls.Add(Me.LblDr)
        Me.Panel3.Controls.Add(Me.Txtamt)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.CmbxACname)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(3, 205)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(638, 247)
        Me.Panel3.TabIndex = 27
        '
        'LstVewAmtDetailsBackup
        '
        Me.LstVewAmtDetailsBackup.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12})
        Me.LstVewAmtDetailsBackup.ContextMenuStrip = Me.CmsEditMode
        Me.LstVewAmtDetailsBackup.Enabled = False
        Me.LstVewAmtDetailsBackup.GridLines = True
        Me.LstVewAmtDetailsBackup.Location = New System.Drawing.Point(8, 85)
        Me.LstVewAmtDetailsBackup.Name = "LstVewAmtDetailsBackup"
        Me.LstVewAmtDetailsBackup.Size = New System.Drawing.Size(93, 43)
        Me.LstVewAmtDetailsBackup.TabIndex = 24
        Me.LstVewAmtDetailsBackup.UseCompatibleStateImageBehavior = False
        Me.LstVewAmtDetailsBackup.View = System.Windows.Forms.View.Details
        Me.LstVewAmtDetailsBackup.Visible = False
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Name"
        Me.ColumnHeader7.Width = 360
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Amount"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader8.Width = 125
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Act Id"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Rec Id"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Edit Flag"
        Me.ColumnHeader11.Width = 0
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Split Status"
        Me.ColumnHeader12.Width = 0
        '
        'FrmCshBnkEditMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(645, 574)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Mskdbxdate)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.BtnDrawn)
        Me.Controls.Add(Me.CmbxDrawn)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CmbxNar)
        Me.Controls.Add(Me.BtnNarr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCshBnkEditMode"
        Me.Text = "Cash/Bank Entries Edit Mode"
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.CmsEditMode.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BTNoK As System.Windows.Forms.Button
    Friend WithEvents Btnbok As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblCrNo As System.Windows.Forms.Label
    Friend WithEvents LblCr As System.Windows.Forms.Label
    Friend WithEvents TxtBokAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbBokName As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents EntryType As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpkrCbnk As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lblvno As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Mskdbxdate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BtnDrawn As System.Windows.Forms.Button
    Friend WithEvents CmbxDrawn As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnCon As System.Windows.Forms.Button
    Friend WithEvents BtnPay As System.Windows.Forms.Button
    Friend WithEvents BtnRecd As System.Windows.Forms.Button
    Friend WithEvents CmbxNar As System.Windows.Forms.ComboBox
    Friend WithEvents BtnNarr As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbxACname As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txtamt As System.Windows.Forms.TextBox
    Friend WithEvents LblDr As System.Windows.Forms.Label
    Friend WithEvents BtnAct As System.Windows.Forms.Button
    Friend WithEvents BtnOkAmt As System.Windows.Forms.Button
    Friend WithEvents LstVewAmtDetails As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CmsEditMode As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LstVewAmtDetailsBackup As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
End Class

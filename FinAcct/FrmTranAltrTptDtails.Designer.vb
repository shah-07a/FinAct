<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTranAltrTptDtails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTranAltrTptDtails))
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbxBillno = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtPvtMrk = New System.Windows.Forms.TextBox
        Me.Dtpgrdt = New System.Windows.Forms.DateTimePicker
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtCariNo = New System.Windows.Forms.TextBox
        Me.Txtgrno = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtFrght = New System.Windows.Forms.TextBox
        Me.TxtLodchrgs = New System.Windows.Forms.TextBox
        Me.TxtGrsWt = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.BtnAddCarri = New System.Windows.Forms.Button
        Me.Btnaddware = New System.Windows.Forms.Button
        Me.CmbxCarri = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbxWareh = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Txtname = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Lbldt = New System.Windows.Forms.Label
        Me.TxtBillAmt = New System.Windows.Forms.TextBox
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.DtpBilldt = New System.Windows.Forms.DateTimePicker
        Me.Rbpaid = New System.Windows.Forms.RadioButton
        Me.Rb2pay = New System.Windows.Forms.RadioButton
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INVOICE/BILL NO."
        '
        'CmbxBillno
        '
        Me.CmbxBillno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxBillno.FormattingEnabled = True
        Me.CmbxBillno.Location = New System.Drawing.Point(136, 8)
        Me.CmbxBillno.Name = "CmbxBillno"
        Me.CmbxBillno.Size = New System.Drawing.Size(166, 22)
        Me.CmbxBillno.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Rbpaid)
        Me.Panel1.Controls.Add(Me.Rb2pay)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.TxtPvtMrk)
        Me.Panel1.Controls.Add(Me.Dtpgrdt)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.TxtCariNo)
        Me.Panel1.Controls.Add(Me.Txtgrno)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.TxtFrght)
        Me.Panel1.Controls.Add(Me.TxtLodchrgs)
        Me.Panel1.Controls.Add(Me.TxtGrsWt)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(15, 214)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(494, 231)
        Me.Panel1.TabIndex = 5
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 163)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(131, 16)
        Me.Label26.TabIndex = 88
        Me.Label26.Text = "FREIGHT CHARGES"
        '
        'TxtPvtMrk
        '
        Me.TxtPvtMrk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPvtMrk.Location = New System.Drawing.Point(206, 203)
        Me.TxtPvtMrk.Name = "TxtPvtMrk"
        Me.TxtPvtMrk.Size = New System.Drawing.Size(236, 22)
        Me.TxtPvtMrk.TabIndex = 12
        '
        'Dtpgrdt
        '
        Me.Dtpgrdt.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpgrdt.CustomFormat = "dd/MM/yyyy"
        Me.Dtpgrdt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpgrdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpgrdt.Location = New System.Drawing.Point(374, 123)
        Me.Dtpgrdt.Name = "Dtpgrdt"
        Me.Dtpgrdt.Size = New System.Drawing.Size(111, 20)
        Me.Dtpgrdt.TabIndex = 10
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 83)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(199, 16)
        Me.Label19.TabIndex = 86
        Me.Label19.Text = "LOADING/CARTAGE CHARGES"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 203)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 16)
        Me.Label18.TabIndex = 85
        Me.Label18.Text = "PRIVATE MARK"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 16)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "CARRIAGE No."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(307, 123)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 16)
        Me.Label15.TabIndex = 83
        Me.Label15.Text = "GR DATE"
        '
        'TxtCariNo
        '
        Me.TxtCariNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCariNo.Location = New System.Drawing.Point(206, 43)
        Me.TxtCariNo.Name = "TxtCariNo"
        Me.TxtCariNo.Size = New System.Drawing.Size(236, 22)
        Me.TxtCariNo.TabIndex = 7
        '
        'Txtgrno
        '
        Me.Txtgrno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtgrno.Location = New System.Drawing.Point(206, 123)
        Me.Txtgrno.Name = "Txtgrno"
        Me.Txtgrno.Size = New System.Drawing.Size(97, 22)
        Me.Txtgrno.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 123)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(140, 16)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "GOODS RECEIPT No."
        '
        'TxtFrght
        '
        Me.TxtFrght.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFrght.Location = New System.Drawing.Point(206, 163)
        Me.TxtFrght.Name = "TxtFrght"
        Me.TxtFrght.Size = New System.Drawing.Size(97, 22)
        Me.TxtFrght.TabIndex = 11
        Me.TxtFrght.Text = "0"
        Me.TxtFrght.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtLodchrgs
        '
        Me.TxtLodchrgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtLodchrgs.Location = New System.Drawing.Point(206, 83)
        Me.TxtLodchrgs.Name = "TxtLodchrgs"
        Me.TxtLodchrgs.Size = New System.Drawing.Size(97, 22)
        Me.TxtLodchrgs.TabIndex = 8
        Me.TxtLodchrgs.Text = "0"
        Me.TxtLodchrgs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtGrsWt
        '
        Me.TxtGrsWt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGrsWt.Location = New System.Drawing.Point(206, 3)
        Me.TxtGrsWt.Name = "TxtGrsWt"
        Me.TxtGrsWt.Size = New System.Drawing.Size(97, 22)
        Me.TxtGrsWt.TabIndex = 6
        Me.TxtGrsWt.Text = "0"
        Me.TxtGrsWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(144, 16)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "GROSS WEIGHT (Kg.)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 16)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "INVOICE AMOUNT"
        '
        'BtnAddCarri
        '
        Me.BtnAddCarri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddCarri.Location = New System.Drawing.Point(484, 173)
        Me.BtnAddCarri.Name = "BtnAddCarri"
        Me.BtnAddCarri.Size = New System.Drawing.Size(25, 21)
        Me.BtnAddCarri.TabIndex = 87
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
        Me.Btnaddware.Location = New System.Drawing.Point(484, 132)
        Me.Btnaddware.Name = "Btnaddware"
        Me.Btnaddware.Size = New System.Drawing.Size(25, 21)
        Me.Btnaddware.TabIndex = 86
        Me.Btnaddware.TabStop = False
        Me.Btnaddware.Text = "...."
        Me.Btnaddware.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btnaddware.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.Btnaddware.UseCompatibleTextRendering = True
        Me.Btnaddware.UseVisualStyleBackColor = True
        '
        'CmbxCarri
        '
        Me.CmbxCarri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxCarri.FormattingEnabled = True
        Me.CmbxCarri.Location = New System.Drawing.Point(136, 173)
        Me.CmbxCarri.Name = "CmbxCarri"
        Me.CmbxCarri.Size = New System.Drawing.Size(343, 21)
        Me.CmbxCarri.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 16)
        Me.Label10.TabIndex = 85
        Me.Label10.Text = "TRANSPORT CO."
        '
        'CmbxWareh
        '
        Me.CmbxWareh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxWareh.FormattingEnabled = True
        Me.CmbxWareh.Location = New System.Drawing.Point(136, 132)
        Me.CmbxWareh.Name = "CmbxWareh"
        Me.CmbxWareh.Size = New System.Drawing.Size(343, 21)
        Me.CmbxWareh.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "DELIVERY AT"
        '
        'Txtname
        '
        Me.Txtname.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Txtname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtname.Location = New System.Drawing.Point(136, 50)
        Me.Txtname.Name = "Txtname"
        Me.Txtname.ReadOnly = True
        Me.Txtname.Size = New System.Drawing.Size(373, 20)
        Me.Txtname.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 16)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "PARTY'S NAME"
        '
        'Lbldt
        '
        Me.Lbldt.BackColor = System.Drawing.Color.LightYellow
        Me.Lbldt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbldt.Location = New System.Drawing.Point(302, 9)
        Me.Lbldt.Name = "Lbldt"
        Me.Lbldt.Size = New System.Drawing.Size(128, 22)
        Me.Lbldt.TabIndex = 0
        '
        'TxtBillAmt
        '
        Me.TxtBillAmt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtBillAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBillAmt.Location = New System.Drawing.Point(136, 90)
        Me.TxtBillAmt.Name = "TxtBillAmt"
        Me.TxtBillAmt.ReadOnly = True
        Me.TxtBillAmt.Size = New System.Drawing.Size(163, 22)
        Me.TxtBillAmt.TabIndex = 2
        Me.TxtBillAmt.Text = "0"
        Me.TxtBillAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnCncl
        '
        Me.BtnCncl.BackColor = System.Drawing.Color.Transparent
        Me.BtnCncl.BackgroundImage = CType(resources.GetObject("BtnCncl.BackgroundImage"), System.Drawing.Image)
        Me.BtnCncl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCncl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCncl.FlatAppearance.BorderSize = 0
        Me.BtnCncl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnCncl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCncl.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCncl.ForeColor = System.Drawing.Color.Navy
        Me.BtnCncl.Location = New System.Drawing.Point(277, 451)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(100, 30)
        Me.BtnCncl.TabIndex = 15
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = False
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
        Me.BtnFind.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.ForeColor = System.Drawing.Color.Navy
        Me.BtnFind.Location = New System.Drawing.Point(146, 451)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(100, 30)
        Me.BtnFind.TabIndex = 14
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.Transparent
        Me.BtnExit.BackgroundImage = CType(resources.GetObject("BtnExit.BackgroundImage"), System.Drawing.Image)
        Me.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnExit.FlatAppearance.BorderSize = 0
        Me.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.ForeColor = System.Drawing.Color.Navy
        Me.BtnExit.Location = New System.Drawing.Point(408, 451)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(100, 30)
        Me.BtnExit.TabIndex = 16
        Me.BtnExit.Text = "&Exit"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Navy
        Me.BtnSave.Location = New System.Drawing.Point(15, 451)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(100, 30)
        Me.BtnSave.TabIndex = 13
        Me.BtnSave.Text = "&Update"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'DtpBilldt
        '
        Me.DtpBilldt.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpBilldt.CustomFormat = "dd/MM/yyyy"
        Me.DtpBilldt.Enabled = False
        Me.DtpBilldt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpBilldt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpBilldt.Location = New System.Drawing.Point(436, 10)
        Me.DtpBilldt.Name = "DtpBilldt"
        Me.DtpBilldt.Size = New System.Drawing.Size(68, 20)
        Me.DtpBilldt.TabIndex = 10
        Me.DtpBilldt.Visible = False
        '
        'Rbpaid
        '
        Me.Rbpaid.AutoSize = True
        Me.Rbpaid.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbpaid.Location = New System.Drawing.Point(374, 163)
        Me.Rbpaid.Name = "Rbpaid"
        Me.Rbpaid.Size = New System.Drawing.Size(55, 20)
        Me.Rbpaid.TabIndex = 91
        Me.Rbpaid.Text = "Paid"
        Me.Rbpaid.UseVisualStyleBackColor = True
        '
        'Rb2pay
        '
        Me.Rb2pay.AutoSize = True
        Me.Rb2pay.Checked = True
        Me.Rb2pay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb2pay.Location = New System.Drawing.Point(307, 163)
        Me.Rb2pay.Name = "Rb2pay"
        Me.Rb2pay.Size = New System.Drawing.Size(64, 20)
        Me.Rb2pay.TabIndex = 90
        Me.Rb2pay.TabStop = True
        Me.Rb2pay.Text = "Topay"
        Me.Rb2pay.UseVisualStyleBackColor = True
        '
        'FrmTranAltrTptDtails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.MediumTurquoise
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(524, 488)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.DtpBilldt)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnAddCarri)
        Me.Controls.Add(Me.Btnaddware)
        Me.Controls.Add(Me.CmbxCarri)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CmbxWareh)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txtname)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CmbxBillno)
        Me.Controls.Add(Me.Lbldt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtBillAmt)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTranAltrTptDtails"
        Me.Text = "ALTER TRANSPORTATION DETAILS"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbxBillno As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtPvtMrk As System.Windows.Forms.TextBox
    Friend WithEvents Dtpgrdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtCariNo As System.Windows.Forms.TextBox
    Friend WithEvents Txtgrno As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtGrsWt As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnAddCarri As System.Windows.Forms.Button
    Friend WithEvents Btnaddware As System.Windows.Forms.Button
    Friend WithEvents CmbxCarri As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbxWareh As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Lbldt As System.Windows.Forms.Label
    Friend WithEvents TxtBillAmt As System.Windows.Forms.TextBox
    Friend WithEvents TxtFrght As System.Windows.Forms.TextBox
    Friend WithEvents TxtLodchrgs As System.Windows.Forms.TextBox
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents DtpBilldt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Rbpaid As System.Windows.Forms.RadioButton
    Friend WithEvents Rb2pay As System.Windows.Forms.RadioButton
End Class

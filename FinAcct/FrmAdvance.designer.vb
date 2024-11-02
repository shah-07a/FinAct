<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdvance
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
        Me.DtPkrAdvDt = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.CmbxEmpNm = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblBscSlry = New System.Windows.Forms.Label
        Me.RbAdvnce = New System.Windows.Forms.RadioButton
        Me.RbLoan = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnSve = New System.Windows.Forms.Button
        Me.PnlEmpAdv = New System.Windows.Forms.Panel
        Me.LblMnths = New System.Windows.Forms.Label
        Me.NumRepay = New System.Windows.Forms.NumericUpDown
        Me.PnlIntrst = New System.Windows.Forms.Panel
        Me.RbFlat = New System.Windows.Forms.RadioButton
        Me.RbReduc = New System.Windows.Forms.RadioButton
        Me.DtpkrEffDt = New System.Windows.Forms.DateTimePicker
        Me.LblEffDt = New System.Windows.Forms.Label
        Me.LblRepay = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TxtOvrTime = New System.Windows.Forms.NumericUpDown
        Me.LblHrs = New System.Windows.Forms.Label
        Me.LblOvrTm = New System.Windows.Forms.Label
        Me.TxtAbsnt = New System.Windows.Forms.TextBox
        Me.LblAbsnt = New System.Windows.Forms.Label
        Me.LblEAmtRs = New System.Windows.Forms.Label
        Me.LblErnAmt = New System.Windows.Forms.Label
        Me.LblEAmt = New System.Windows.Forms.Label
        Me.LblInst = New System.Windows.Forms.Label
        Me.LblRs = New System.Windows.Forms.Label
        Me.LblMnthInst = New System.Windows.Forms.Label
        Me.LblMCalc = New System.Windows.Forms.Label
        Me.LblAnly = New System.Windows.Forms.Label
        Me.RbIntNo = New System.Windows.Forms.RadioButton
        Me.RbIntYes = New System.Windows.Forms.RadioButton
        Me.LblRtInt = New System.Windows.Forms.Label
        Me.TxtRtInt = New System.Windows.Forms.TextBox
        Me.LblIntAppl = New System.Windows.Forms.Label
        Me.TxtAmt = New System.Windows.Forms.TextBox
        Me.LblAmt = New System.Windows.Forms.Label
        Me.TxtAdvAmt = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.LblAdcAmt = New System.Windows.Forms.Label
        Me.BtnFnd = New System.Windows.Forms.Button
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.PnlFnd = New System.Windows.Forms.Panel
        Me.BtnFnd_OK = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.PnlRbLoan = New System.Windows.Forms.RadioButton
        Me.PnlRbAdvnc = New System.Windows.Forms.RadioButton
        Me.LstVewAdv = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.PnlEmpAdv.SuspendLayout()
        CType(Me.NumRepay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlIntrst.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtOvrTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFnd.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtPkrAdvDt
        '
        Me.DtPkrAdvDt.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrAdvDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrAdvDt.Location = New System.Drawing.Point(172, 17)
        Me.DtPkrAdvDt.Name = "DtPkrAdvDt"
        Me.DtPkrAdvDt.Size = New System.Drawing.Size(93, 20)
        Me.DtPkrAdvDt.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 20)
        Me.Label17.TabIndex = 45
        Me.Label17.Text = "Date:-"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxEmpNm
        '
        Me.CmbxEmpNm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxEmpNm.FormattingEnabled = True
        Me.CmbxEmpNm.Location = New System.Drawing.Point(172, 61)
        Me.CmbxEmpNm.Name = "CmbxEmpNm"
        Me.CmbxEmpNm.Size = New System.Drawing.Size(186, 21)
        Me.CmbxEmpNm.TabIndex = 1
        Me.CmbxEmpNm.TabStop = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 20)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Employee Name:-"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 20)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Basic Salary:-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblBscSlry
        '
        Me.LblBscSlry.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblBscSlry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblBscSlry.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBscSlry.Location = New System.Drawing.Point(172, 108)
        Me.LblBscSlry.Name = "LblBscSlry"
        Me.LblBscSlry.Size = New System.Drawing.Size(122, 20)
        Me.LblBscSlry.TabIndex = 49
        Me.LblBscSlry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RbAdvnce
        '
        Me.RbAdvnce.AutoSize = True
        Me.RbAdvnce.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbAdvnce.Location = New System.Drawing.Point(7, 7)
        Me.RbAdvnce.Name = "RbAdvnce"
        Me.RbAdvnce.Size = New System.Drawing.Size(74, 19)
        Me.RbAdvnce.TabIndex = 2
        Me.RbAdvnce.Text = "Advance"
        Me.RbAdvnce.UseVisualStyleBackColor = True
        '
        'RbLoan
        '
        Me.RbLoan.AutoSize = True
        Me.RbLoan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbLoan.Location = New System.Drawing.Point(94, 7)
        Me.RbLoan.Name = "RbLoan"
        Me.RbLoan.Size = New System.Drawing.Size(53, 19)
        Me.RbLoan.TabIndex = 3
        Me.RbLoan.Text = "Loan"
        Me.RbLoan.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 20)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Type:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(299, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Rs."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSve
        '
        Me.BtnSve.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnSve.Location = New System.Drawing.Point(207, 540)
        Me.BtnSve.Name = "BtnSve"
        Me.BtnSve.Size = New System.Drawing.Size(85, 33)
        Me.BtnSve.TabIndex = 55
        Me.BtnSve.TabStop = False
        Me.BtnSve.Text = "&Save"
        Me.BtnSve.UseVisualStyleBackColor = True
        '
        'PnlEmpAdv
        '
        Me.PnlEmpAdv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlEmpAdv.Controls.Add(Me.LblMnths)
        Me.PnlEmpAdv.Controls.Add(Me.NumRepay)
        Me.PnlEmpAdv.Controls.Add(Me.PnlIntrst)
        Me.PnlEmpAdv.Controls.Add(Me.DtpkrEffDt)
        Me.PnlEmpAdv.Controls.Add(Me.LblEffDt)
        Me.PnlEmpAdv.Controls.Add(Me.LblRepay)
        Me.PnlEmpAdv.Controls.Add(Me.Panel1)
        Me.PnlEmpAdv.Controls.Add(Me.TxtOvrTime)
        Me.PnlEmpAdv.Controls.Add(Me.LblHrs)
        Me.PnlEmpAdv.Controls.Add(Me.LblOvrTm)
        Me.PnlEmpAdv.Controls.Add(Me.TxtAbsnt)
        Me.PnlEmpAdv.Controls.Add(Me.LblAbsnt)
        Me.PnlEmpAdv.Controls.Add(Me.LblEAmtRs)
        Me.PnlEmpAdv.Controls.Add(Me.LblErnAmt)
        Me.PnlEmpAdv.Controls.Add(Me.LblEAmt)
        Me.PnlEmpAdv.Controls.Add(Me.LblInst)
        Me.PnlEmpAdv.Controls.Add(Me.LblRs)
        Me.PnlEmpAdv.Controls.Add(Me.LblMnthInst)
        Me.PnlEmpAdv.Controls.Add(Me.LblMCalc)
        Me.PnlEmpAdv.Controls.Add(Me.LblAnly)
        Me.PnlEmpAdv.Controls.Add(Me.RbIntNo)
        Me.PnlEmpAdv.Controls.Add(Me.RbIntYes)
        Me.PnlEmpAdv.Controls.Add(Me.LblRtInt)
        Me.PnlEmpAdv.Controls.Add(Me.TxtRtInt)
        Me.PnlEmpAdv.Controls.Add(Me.LblIntAppl)
        Me.PnlEmpAdv.Controls.Add(Me.TxtAmt)
        Me.PnlEmpAdv.Controls.Add(Me.LblAmt)
        Me.PnlEmpAdv.Controls.Add(Me.TxtAdvAmt)
        Me.PnlEmpAdv.Controls.Add(Me.Label7)
        Me.PnlEmpAdv.Controls.Add(Me.LblAdcAmt)
        Me.PnlEmpAdv.Controls.Add(Me.Label1)
        Me.PnlEmpAdv.Controls.Add(Me.Label9)
        Me.PnlEmpAdv.Controls.Add(Me.Label4)
        Me.PnlEmpAdv.Controls.Add(Me.DtPkrAdvDt)
        Me.PnlEmpAdv.Controls.Add(Me.Label17)
        Me.PnlEmpAdv.Controls.Add(Me.CmbxEmpNm)
        Me.PnlEmpAdv.Controls.Add(Me.Label3)
        Me.PnlEmpAdv.Controls.Add(Me.LblBscSlry)
        Me.PnlEmpAdv.Location = New System.Drawing.Point(13, 13)
        Me.PnlEmpAdv.Name = "PnlEmpAdv"
        Me.PnlEmpAdv.Size = New System.Drawing.Size(399, 654)
        Me.PnlEmpAdv.TabIndex = 0
        '
        'LblMnths
        '
        Me.LblMnths.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblMnths.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMnths.Location = New System.Drawing.Point(218, 419)
        Me.LblMnths.Name = "LblMnths"
        Me.LblMnths.Size = New System.Drawing.Size(59, 20)
        Me.LblMnths.TabIndex = 91
        Me.LblMnths.Text = "months"
        Me.LblMnths.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NumRepay
        '
        Me.NumRepay.Location = New System.Drawing.Point(171, 419)
        Me.NumRepay.Name = "NumRepay"
        Me.NumRepay.Size = New System.Drawing.Size(41, 20)
        Me.NumRepay.TabIndex = 90
        Me.NumRepay.TabStop = False
        '
        'PnlIntrst
        '
        Me.PnlIntrst.Controls.Add(Me.RbFlat)
        Me.PnlIntrst.Controls.Add(Me.RbReduc)
        Me.PnlIntrst.Location = New System.Drawing.Point(172, 365)
        Me.PnlIntrst.Name = "PnlIntrst"
        Me.PnlIntrst.Size = New System.Drawing.Size(142, 28)
        Me.PnlIntrst.TabIndex = 89
        '
        'RbFlat
        '
        Me.RbFlat.AutoSize = True
        Me.RbFlat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbFlat.Location = New System.Drawing.Point(87, 2)
        Me.RbFlat.Name = "RbFlat"
        Me.RbFlat.Size = New System.Drawing.Size(45, 19)
        Me.RbFlat.TabIndex = 70
        Me.RbFlat.Text = "Flat"
        Me.RbFlat.UseVisualStyleBackColor = True
        '
        'RbReduc
        '
        Me.RbReduc.AutoSize = True
        Me.RbReduc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbReduc.Location = New System.Drawing.Point(3, 2)
        Me.RbReduc.Name = "RbReduc"
        Me.RbReduc.Size = New System.Drawing.Size(78, 19)
        Me.RbReduc.TabIndex = 69
        Me.RbReduc.Text = "Reducing"
        Me.RbReduc.UseVisualStyleBackColor = True
        '
        'DtpkrEffDt
        '
        Me.DtpkrEffDt.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrEffDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrEffDt.Location = New System.Drawing.Point(170, 515)
        Me.DtpkrEffDt.Name = "DtpkrEffDt"
        Me.DtpkrEffDt.Size = New System.Drawing.Size(94, 20)
        Me.DtpkrEffDt.TabIndex = 88
        Me.DtpkrEffDt.TabStop = False
        '
        'LblEffDt
        '
        Me.LblEffDt.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblEffDt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblEffDt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEffDt.Location = New System.Drawing.Point(12, 515)
        Me.LblEffDt.Name = "LblEffDt"
        Me.LblEffDt.Size = New System.Drawing.Size(135, 20)
        Me.LblEffDt.TabIndex = 87
        Me.LblEffDt.Text = "Effective Date:-"
        Me.LblEffDt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblRepay
        '
        Me.LblRepay.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblRepay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRepay.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRepay.Location = New System.Drawing.Point(12, 417)
        Me.LblRepay.Name = "LblRepay"
        Me.LblRepay.Size = New System.Drawing.Size(136, 20)
        Me.LblRepay.TabIndex = 85
        Me.LblRepay.Text = "Repayment Period:-"
        Me.LblRepay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RbLoan)
        Me.Panel1.Controls.Add(Me.RbAdvnce)
        Me.Panel1.Location = New System.Drawing.Point(165, 149)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(159, 35)
        Me.Panel1.TabIndex = 84
        '
        'TxtOvrTime
        '
        Me.TxtOvrTime.Location = New System.Drawing.Point(196, 577)
        Me.TxtOvrTime.Maximum = New Decimal(New Integer() {672, 0, 0, 0})
        Me.TxtOvrTime.Name = "TxtOvrTime"
        Me.TxtOvrTime.Size = New System.Drawing.Size(43, 20)
        Me.TxtOvrTime.TabIndex = 82
        Me.TxtOvrTime.TabStop = False
        '
        'LblHrs
        '
        Me.LblHrs.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblHrs.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHrs.Location = New System.Drawing.Point(245, 575)
        Me.LblHrs.Name = "LblHrs"
        Me.LblHrs.Size = New System.Drawing.Size(32, 20)
        Me.LblHrs.TabIndex = 83
        Me.LblHrs.Text = "hrs"
        Me.LblHrs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblOvrTm
        '
        Me.LblOvrTm.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblOvrTm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOvrTm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOvrTm.Location = New System.Drawing.Point(304, 622)
        Me.LblOvrTm.Name = "LblOvrTm"
        Me.LblOvrTm.Size = New System.Drawing.Size(78, 20)
        Me.LblOvrTm.TabIndex = 81
        Me.LblOvrTm.Text = "Overtime:-"
        Me.LblOvrTm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtAbsnt
        '
        Me.TxtAbsnt.Location = New System.Drawing.Point(181, 625)
        Me.TxtAbsnt.MaxLength = 2
        Me.TxtAbsnt.Name = "TxtAbsnt"
        Me.TxtAbsnt.Size = New System.Drawing.Size(58, 20)
        Me.TxtAbsnt.TabIndex = 78
        Me.TxtAbsnt.TabStop = False
        Me.TxtAbsnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblAbsnt
        '
        Me.LblAbsnt.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblAbsnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAbsnt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAbsnt.Location = New System.Drawing.Point(14, 556)
        Me.LblAbsnt.Name = "LblAbsnt"
        Me.LblAbsnt.Size = New System.Drawing.Size(133, 39)
        Me.LblAbsnt.TabIndex = 77
        Me.LblAbsnt.Text = "Absent / Leave Without Pay:-"
        Me.LblAbsnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblEAmtRs
        '
        Me.LblEAmtRs.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblEAmtRs.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEAmtRs.Location = New System.Drawing.Point(299, 602)
        Me.LblEAmtRs.Name = "LblEAmtRs"
        Me.LblEAmtRs.Size = New System.Drawing.Size(34, 20)
        Me.LblEAmtRs.TabIndex = 76
        Me.LblEAmtRs.Text = "Rs."
        Me.LblEAmtRs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblErnAmt
        '
        Me.LblErnAmt.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblErnAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblErnAmt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblErnAmt.Location = New System.Drawing.Point(14, 602)
        Me.LblErnAmt.Name = "LblErnAmt"
        Me.LblErnAmt.Size = New System.Drawing.Size(137, 20)
        Me.LblErnAmt.TabIndex = 74
        Me.LblErnAmt.Text = "Earned Amount:-"
        Me.LblErnAmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblEAmt
        '
        Me.LblEAmt.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblEAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblEAmt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEAmt.Location = New System.Drawing.Point(173, 602)
        Me.LblEAmt.Name = "LblEAmt"
        Me.LblEAmt.Size = New System.Drawing.Size(122, 20)
        Me.LblEAmt.TabIndex = 75
        Me.LblEAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblInst
        '
        Me.LblInst.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblInst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblInst.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInst.Location = New System.Drawing.Point(171, 465)
        Me.LblInst.Name = "LblInst"
        Me.LblInst.Size = New System.Drawing.Size(122, 20)
        Me.LblInst.TabIndex = 73
        Me.LblInst.Text = "                              "
        Me.LblInst.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblRs
        '
        Me.LblRs.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblRs.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRs.Location = New System.Drawing.Point(298, 465)
        Me.LblRs.Name = "LblRs"
        Me.LblRs.Size = New System.Drawing.Size(34, 20)
        Me.LblRs.TabIndex = 72
        Me.LblRs.Text = "Rs."
        Me.LblRs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblMnthInst
        '
        Me.LblMnthInst.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblMnthInst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblMnthInst.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMnthInst.Location = New System.Drawing.Point(13, 465)
        Me.LblMnthInst.Name = "LblMnthInst"
        Me.LblMnthInst.Size = New System.Drawing.Size(135, 20)
        Me.LblMnthInst.TabIndex = 71
        Me.LblMnthInst.Text = "Monthly Installment:-"
        Me.LblMnthInst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblMCalc
        '
        Me.LblMCalc.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblMCalc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblMCalc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMCalc.Location = New System.Drawing.Point(12, 357)
        Me.LblMCalc.Name = "LblMCalc"
        Me.LblMCalc.Size = New System.Drawing.Size(137, 36)
        Me.LblMCalc.TabIndex = 68
        Me.LblMCalc.Text = "Method of Interest Calculation:-"
        Me.LblMCalc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblAnly
        '
        Me.LblAnly.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblAnly.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAnly.Location = New System.Drawing.Point(11, 318)
        Me.LblAnly.Name = "LblAnly"
        Me.LblAnly.Size = New System.Drawing.Size(124, 20)
        Me.LblAnly.TabIndex = 67
        Me.LblAnly.Text = "(i.e.Annually)"
        Me.LblAnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RbIntNo
        '
        Me.RbIntNo.AutoSize = True
        Me.RbIntNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbIntNo.Location = New System.Drawing.Point(254, 249)
        Me.RbIntNo.Name = "RbIntNo"
        Me.RbIntNo.Size = New System.Drawing.Size(40, 19)
        Me.RbIntNo.TabIndex = 6
        Me.RbIntNo.Text = "No"
        Me.RbIntNo.UseVisualStyleBackColor = True
        '
        'RbIntYes
        '
        Me.RbIntYes.AutoSize = True
        Me.RbIntYes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbIntYes.Location = New System.Drawing.Point(170, 249)
        Me.RbIntYes.Name = "RbIntYes"
        Me.RbIntYes.Size = New System.Drawing.Size(46, 19)
        Me.RbIntYes.TabIndex = 5
        Me.RbIntYes.Text = "Yes"
        Me.RbIntYes.UseVisualStyleBackColor = True
        '
        'LblRtInt
        '
        Me.LblRtInt.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblRtInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRtInt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRtInt.Location = New System.Drawing.Point(12, 297)
        Me.LblRtInt.Name = "LblRtInt"
        Me.LblRtInt.Size = New System.Drawing.Size(136, 20)
        Me.LblRtInt.TabIndex = 63
        Me.LblRtInt.Text = "Rate of Interest:-"
        Me.LblRtInt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtRtInt
        '
        Me.TxtRtInt.Location = New System.Drawing.Point(170, 298)
        Me.TxtRtInt.MaxLength = 5
        Me.TxtRtInt.Name = "TxtRtInt"
        Me.TxtRtInt.Size = New System.Drawing.Size(48, 20)
        Me.TxtRtInt.TabIndex = 7
        Me.TxtRtInt.TabStop = False
        Me.TxtRtInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblIntAppl
        '
        Me.LblIntAppl.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblIntAppl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblIntAppl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIntAppl.Location = New System.Drawing.Point(12, 248)
        Me.LblIntAppl.Name = "LblIntAppl"
        Me.LblIntAppl.Size = New System.Drawing.Size(136, 20)
        Me.LblIntAppl.TabIndex = 61
        Me.LblIntAppl.Text = "Interest Applicable:-"
        Me.LblIntAppl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtAmt
        '
        Me.TxtAmt.Location = New System.Drawing.Point(170, 201)
        Me.TxtAmt.Name = "TxtAmt"
        Me.TxtAmt.Size = New System.Drawing.Size(121, 20)
        Me.TxtAmt.TabIndex = 4
        Me.TxtAmt.TabStop = False
        Me.TxtAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblAmt
        '
        Me.LblAmt.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAmt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAmt.Location = New System.Drawing.Point(12, 200)
        Me.LblAmt.Name = "LblAmt"
        Me.LblAmt.Size = New System.Drawing.Size(77, 20)
        Me.LblAmt.TabIndex = 59
        Me.LblAmt.Text = "Amount:-"
        Me.LblAmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtAdvAmt
        '
        Me.TxtAdvAmt.Location = New System.Drawing.Point(173, 649)
        Me.TxtAdvAmt.Name = "TxtAdvAmt"
        Me.TxtAdvAmt.Size = New System.Drawing.Size(121, 20)
        Me.TxtAdvAmt.TabIndex = 58
        Me.TxtAdvAmt.TabStop = False
        Me.TxtAdvAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(297, 648)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 20)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Rs."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblAdcAmt
        '
        Me.LblAdcAmt.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblAdcAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAdcAmt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdcAmt.Location = New System.Drawing.Point(14, 648)
        Me.LblAdcAmt.Name = "LblAdcAmt"
        Me.LblAdcAmt.Size = New System.Drawing.Size(138, 20)
        Me.LblAdcAmt.TabIndex = 55
        Me.LblAdcAmt.Text = "Advanced Amount:-"
        Me.LblAdcAmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnFnd
        '
        Me.BtnFnd.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnFnd.Location = New System.Drawing.Point(308, 540)
        Me.BtnFnd.Name = "BtnFnd"
        Me.BtnFnd.Size = New System.Drawing.Size(85, 33)
        Me.BtnFnd.TabIndex = 57
        Me.BtnFnd.TabStop = False
        Me.BtnFnd.Text = "&Find"
        Me.BtnFnd.UseVisualStyleBackColor = True
        '
        'BtnCncl
        '
        Me.BtnCncl.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnCncl.Location = New System.Drawing.Point(411, 540)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(85, 33)
        Me.BtnCncl.TabIndex = 58
        Me.BtnCncl.TabStop = False
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnClose.Location = New System.Drawing.Point(515, 540)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(85, 33)
        Me.BtnClose.TabIndex = 56
        Me.BtnClose.TabStop = False
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'PnlFnd
        '
        Me.PnlFnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlFnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlFnd.Controls.Add(Me.BtnFnd_OK)
        Me.PnlFnd.Controls.Add(Me.Label2)
        Me.PnlFnd.Controls.Add(Me.PnlRbLoan)
        Me.PnlFnd.Controls.Add(Me.PnlRbAdvnc)
        Me.PnlFnd.Location = New System.Drawing.Point(418, 31)
        Me.PnlFnd.Name = "PnlFnd"
        Me.PnlFnd.Size = New System.Drawing.Size(208, 111)
        Me.PnlFnd.TabIndex = 92
        '
        'BtnFnd_OK
        '
        Me.BtnFnd_OK.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFnd_OK.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFnd_OK.Location = New System.Drawing.Point(141, 83)
        Me.BtnFnd_OK.Name = "BtnFnd_OK"
        Me.BtnFnd_OK.Size = New System.Drawing.Size(62, 23)
        Me.BtnFnd_OK.TabIndex = 3
        Me.BtnFnd_OK.TabStop = False
        Me.BtnFnd_OK.Text = "OK"
        Me.BtnFnd_OK.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(13, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 20)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Type:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnlRbLoan
        '
        Me.PnlRbLoan.AutoSize = True
        Me.PnlRbLoan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlRbLoan.ForeColor = System.Drawing.Color.Navy
        Me.PnlRbLoan.Location = New System.Drawing.Point(87, 35)
        Me.PnlRbLoan.Name = "PnlRbLoan"
        Me.PnlRbLoan.Size = New System.Drawing.Size(53, 19)
        Me.PnlRbLoan.TabIndex = 1
        Me.PnlRbLoan.Text = "Loan"
        Me.PnlRbLoan.UseVisualStyleBackColor = True
        '
        'PnlRbAdvnc
        '
        Me.PnlRbAdvnc.AutoSize = True
        Me.PnlRbAdvnc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlRbAdvnc.ForeColor = System.Drawing.Color.Navy
        Me.PnlRbAdvnc.Location = New System.Drawing.Point(87, 10)
        Me.PnlRbAdvnc.Name = "PnlRbAdvnc"
        Me.PnlRbAdvnc.Size = New System.Drawing.Size(74, 19)
        Me.PnlRbAdvnc.TabIndex = 0
        Me.PnlRbAdvnc.Text = "Advance"
        Me.PnlRbAdvnc.UseVisualStyleBackColor = True
        '
        'LstVewAdv
        '
        Me.LstVewAdv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.LstVewAdv.FullRowSelect = True
        Me.LstVewAdv.GridLines = True
        Me.LstVewAdv.Location = New System.Drawing.Point(430, 13)
        Me.LstVewAdv.Name = "LstVewAdv"
        Me.LstVewAdv.Size = New System.Drawing.Size(405, 244)
        Me.LstVewAdv.TabIndex = 59
        Me.LstVewAdv.UseCompatibleStateImageBehavior = False
        Me.LstVewAdv.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "AdvEmpid"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Employee Name"
        Me.ColumnHeader2.Width = 180
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Advanced Amount"
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Basic Salary"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Intrst Appli"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Rate of Intrst"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Methd of Intrst"
        Me.ColumnHeader8.Width = 0
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Repay Perd"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Mnthly Inst"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "LnEffDt"
        Me.ColumnHeader11.Width = 0
        '
        'FrmAdvance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(804, 585)
        Me.Controls.Add(Me.PnlFnd)
        Me.Controls.Add(Me.LstVewAdv)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.BtnFnd)
        Me.Controls.Add(Me.PnlEmpAdv)
        Me.Controls.Add(Me.BtnSve)
        Me.MaximizeBox = False
        Me.Name = "FrmAdvance"
        Me.Text = "Advance"
        Me.PnlEmpAdv.ResumeLayout(False)
        Me.PnlEmpAdv.PerformLayout()
        CType(Me.NumRepay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlIntrst.ResumeLayout(False)
        Me.PnlIntrst.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TxtOvrTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFnd.ResumeLayout(False)
        Me.PnlFnd.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DtPkrAdvDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CmbxEmpNm As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblBscSlry As System.Windows.Forms.Label
    Friend WithEvents RbAdvnce As System.Windows.Forms.RadioButton
    Friend WithEvents RbLoan As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnSve As System.Windows.Forms.Button
    Friend WithEvents PnlEmpAdv As System.Windows.Forms.Panel
    Friend WithEvents BtnFnd As System.Windows.Forms.Button
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblAdcAmt As System.Windows.Forms.Label
    Friend WithEvents TxtAdvAmt As System.Windows.Forms.TextBox
    Friend WithEvents LblRtInt As System.Windows.Forms.Label
    Friend WithEvents TxtRtInt As System.Windows.Forms.TextBox
    Friend WithEvents LblIntAppl As System.Windows.Forms.Label
    Friend WithEvents TxtAmt As System.Windows.Forms.TextBox
    Friend WithEvents LblAmt As System.Windows.Forms.Label
    Friend WithEvents RbIntNo As System.Windows.Forms.RadioButton
    Friend WithEvents RbIntYes As System.Windows.Forms.RadioButton
    Friend WithEvents LblAnly As System.Windows.Forms.Label
    Friend WithEvents LblMCalc As System.Windows.Forms.Label
    Friend WithEvents LblRs As System.Windows.Forms.Label
    Friend WithEvents LblMnthInst As System.Windows.Forms.Label
    Friend WithEvents LblInst As System.Windows.Forms.Label
    Friend WithEvents LblEAmtRs As System.Windows.Forms.Label
    Friend WithEvents LblErnAmt As System.Windows.Forms.Label
    Friend WithEvents LblEAmt As System.Windows.Forms.Label
    Friend WithEvents TxtAbsnt As System.Windows.Forms.TextBox
    Friend WithEvents LblAbsnt As System.Windows.Forms.Label
    Friend WithEvents LblOvrTm As System.Windows.Forms.Label
    Friend WithEvents TxtOvrTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblHrs As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblRepay As System.Windows.Forms.Label
    Friend WithEvents DtpkrEffDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblEffDt As System.Windows.Forms.Label
    Friend WithEvents PnlIntrst As System.Windows.Forms.Panel
    Friend WithEvents RbFlat As System.Windows.Forms.RadioButton
    Friend WithEvents RbReduc As System.Windows.Forms.RadioButton
    Friend WithEvents LblMnths As System.Windows.Forms.Label
    Friend WithEvents NumRepay As System.Windows.Forms.NumericUpDown
    Friend WithEvents PnlFnd As System.Windows.Forms.Panel
    Friend WithEvents PnlRbLoan As System.Windows.Forms.RadioButton
    Friend WithEvents PnlRbAdvnc As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnFnd_OK As System.Windows.Forms.Button
    Friend WithEvents LstVewAdv As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
End Class

Imports System.Data
Imports System.Data.SqlClient
Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.Data.Odbc
Imports System.Data.Odbc.OdbcParameter

Public Class FrmCshBnk

    Inherits System.Windows.Forms.Form
    Dim Csh_Bnk_Cmd As SqlCommand
    Dim Csh_Bnk_rdr As SqlDataReader
    Dim Csh_Bnk_Sqladptr As SqlDataAdapter
    Dim Csh_Bnk_Dset As DataSet
    Dim OdbcCmd As OdbcCommand
    Dim OdbcRdr As OdbcDataReader

    Dim Cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim Add_Edit_Flag As Boolean
    Dim splrid As Integer
    Dim Delstatus As Integer
    Dim TranType As String
    Dim TranMode As String
    Dim IndxMstr As Integer
    Dim CustId As Integer
    Dim CurrentDate As Date
    Dim Vnback As Integer
    Dim BookName As String = ""
    Dim BookName1 As String = ""
    Dim chk_entry As String = ""
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim CbRecId As Integer = 0
    Dim xBokType As String = ""
    Dim xHndlLeave As Integer = 0

    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BalTxt As System.Windows.Forms.Label
    Friend WithEvents LblCr As System.Windows.Forms.Label
    Friend WithEvents LblDr As System.Windows.Forms.Label
    Friend WithEvents Lblbal2 As System.Windows.Forms.Label
    Friend WithEvents Lblbdr As System.Windows.Forms.Label
    Friend WithEvents Lblbcr As System.Windows.Forms.Label
    Friend WithEvents txtbal2 As System.Windows.Forms.Label
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents lblLdt As System.Windows.Forms.Label
    Friend WithEvents CmbxNar As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblCrNo As System.Windows.Forms.Label
    Friend WithEvents Btnbok As System.Windows.Forms.Button
    Friend WithEvents BtnNarr As System.Windows.Forms.Button
    Friend WithEvents BtnAct As System.Windows.Forms.Button
    Friend WithEvents CmbxDrawn As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnDrawn As System.Windows.Forms.Button
    Friend WithEvents Mskdbxdate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BTNoK As System.Windows.Forms.Button
    Friend WithEvents TxtBokAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LstVewAmtDetails As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnOkAmt As System.Windows.Forms.Button
    Dim res1 As ComboBox

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnPay As System.Windows.Forms.Button
    Friend WithEvents BtnRecd As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DtpkrCbnk As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EntryType As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lblvno As System.Windows.Forms.Label
    Friend WithEvents CmbBokName As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCon As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbxACname As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txtamt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtnEdt As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCshBnk))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnCon = New System.Windows.Forms.Button
        Me.BtnPay = New System.Windows.Forms.Button
        Me.BtnRecd = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BTNoK = New System.Windows.Forms.Button
        Me.Btnbok = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.LblCrNo = New System.Windows.Forms.Label
        Me.lblLdt = New System.Windows.Forms.Label
        Me.Lblbdr = New System.Windows.Forms.Label
        Me.LblCr = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtBokAmt = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbBokName = New System.Windows.Forms.ComboBox
        Me.BalTxt = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.EntryType = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpkrCbnk = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Lblvno = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LstVewAmtDetails = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.BtnOkAmt = New System.Windows.Forms.Button
        Me.BtnAct = New System.Windows.Forms.Button
        Me.Lblbcr = New System.Windows.Forms.Label
        Me.Lblbal2 = New System.Windows.Forms.Label
        Me.LblDr = New System.Windows.Forms.Label
        Me.Txtamt = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtbal2 = New System.Windows.Forms.Label
        Me.CmbxACname = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Mskdbxdate = New System.Windows.Forms.MaskedTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.BtnDrawn = New System.Windows.Forms.Button
        Me.BtnNarr = New System.Windows.Forms.Button
        Me.CmbxDrawn = New System.Windows.Forms.ComboBox
        Me.CmbxNar = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.BtnEdt = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.NavajoWhite
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnCon)
        Me.Panel1.Controls.Add(Me.BtnPay)
        Me.Panel1.Controls.Add(Me.BtnRecd)
        Me.Panel1.Location = New System.Drawing.Point(8, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(639, 43)
        Me.Panel1.TabIndex = 0
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
        Me.BtnCon.Location = New System.Drawing.Point(502, 5)
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
        Me.BtnPay.Location = New System.Drawing.Point(243, 5)
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
        Me.BtnRecd.Location = New System.Drawing.Point(3, 5)
        Me.BtnRecd.Name = "BtnRecd"
        Me.BtnRecd.Size = New System.Drawing.Size(132, 32)
        Me.BtnRecd.TabIndex = 1
        Me.BtnRecd.Tag = ""
        Me.BtnRecd.Text = "< Receipt >"
        Me.BtnRecd.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SpringGreen
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BTNoK)
        Me.Panel2.Controls.Add(Me.Btnbok)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.label8)
        Me.Panel2.Controls.Add(Me.LblCrNo)
        Me.Panel2.Controls.Add(Me.lblLdt)
        Me.Panel2.Controls.Add(Me.Lblbdr)
        Me.Panel2.Controls.Add(Me.LblCr)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TxtBokAmt)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.CmbBokName)
        Me.Panel2.Controls.Add(Me.BalTxt)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.EntryType)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.DtpkrCbnk)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Lblvno)
        Me.Panel2.Location = New System.Drawing.Point(8, 51)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(639, 156)
        Me.Panel2.TabIndex = 4
        '
        'BTNoK
        '
        Me.BTNoK.BackColor = System.Drawing.Color.Transparent
        Me.BTNoK.Location = New System.Drawing.Point(261, 120)
        Me.BTNoK.Name = "BTNoK"
        Me.BTNoK.Size = New System.Drawing.Size(38, 23)
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
        Me.Btnbok.Size = New System.Drawing.Size(32, 23)
        Me.Btnbok.TabIndex = 21
        Me.Btnbok.TabStop = False
        Me.Btnbok.Text = "...."
        Me.Btnbok.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(420, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 20)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Cash Receipt No.:-"
        Me.Label10.Visible = False
        '
        'label8
        '
        Me.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.Location = New System.Drawing.Point(430, 5)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(106, 20)
        Me.label8.TabIndex = 20
        Me.label8.Text = "Last Used Date:-"
        '
        'LblCrNo
        '
        Me.LblCrNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCrNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCrNo.Location = New System.Drawing.Point(546, 30)
        Me.LblCrNo.Name = "LblCrNo"
        Me.LblCrNo.Size = New System.Drawing.Size(88, 20)
        Me.LblCrNo.TabIndex = 19
        Me.LblCrNo.Text = "0"
        Me.LblCrNo.Visible = False
        '
        'lblLdt
        '
        Me.lblLdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLdt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLdt.Location = New System.Drawing.Point(546, 5)
        Me.lblLdt.Name = "lblLdt"
        Me.lblLdt.Size = New System.Drawing.Size(88, 20)
        Me.lblLdt.TabIndex = 19
        '
        'Lblbdr
        '
        Me.Lblbdr.AutoSize = True
        Me.Lblbdr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblbdr.ForeColor = System.Drawing.Color.DimGray
        Me.Lblbdr.Location = New System.Drawing.Point(563, 121)
        Me.Lblbdr.Name = "Lblbdr"
        Me.Lblbdr.Size = New System.Drawing.Size(13, 14)
        Me.Lblbdr.TabIndex = 7
        Me.Lblbdr.Text = "0"
        Me.Lblbdr.Visible = False
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(306, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Current Balance"
        '
        'TxtBokAmt
        '
        Me.TxtBokAmt.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBokAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBokAmt.Location = New System.Drawing.Point(120, 121)
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
        'BalTxt
        '
        Me.BalTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BalTxt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BalTxt.Location = New System.Drawing.Point(420, 121)
        Me.BalTxt.Name = "BalTxt"
        Me.BalTxt.Size = New System.Drawing.Size(137, 20)
        Me.BalTxt.TabIndex = 6
        Me.BalTxt.Text = "   "
        Me.BalTxt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 121)
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
        Me.DtpkrCbnk.Location = New System.Drawing.Point(5, 14)
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightGreen
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.LstVewAmtDetails)
        Me.Panel3.Controls.Add(Me.BtnOkAmt)
        Me.Panel3.Controls.Add(Me.BtnAct)
        Me.Panel3.Controls.Add(Me.Lblbcr)
        Me.Panel3.Controls.Add(Me.Lblbal2)
        Me.Panel3.Controls.Add(Me.LblDr)
        Me.Panel3.Controls.Add(Me.Txtamt)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtbal2)
        Me.Panel3.Controls.Add(Me.CmbxACname)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(8, 212)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(638, 248)
        Me.Panel3.TabIndex = 7
        '
        'LstVewAmtDetails
        '
        Me.LstVewAmtDetails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.LstVewAmtDetails.GridLines = True
        Me.LstVewAmtDetails.Location = New System.Drawing.Point(120, 86)
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
        Me.ColumnHeader4.Text = "Type"
        Me.ColumnHeader4.Width = 0
        '
        'BtnOkAmt
        '
        Me.BtnOkAmt.BackColor = System.Drawing.Color.Transparent
        Me.BtnOkAmt.Location = New System.Drawing.Point(261, 54)
        Me.BtnOkAmt.Name = "BtnOkAmt"
        Me.BtnOkAmt.Size = New System.Drawing.Size(38, 23)
        Me.BtnOkAmt.TabIndex = 21
        Me.BtnOkAmt.TabStop = False
        Me.BtnOkAmt.Text = "&OK"
        Me.BtnOkAmt.UseVisualStyleBackColor = False
        '
        'BtnAct
        '
        Me.BtnAct.BackColor = System.Drawing.Color.Transparent
        Me.BtnAct.Location = New System.Drawing.Point(600, 3)
        Me.BtnAct.Name = "BtnAct"
        Me.BtnAct.Size = New System.Drawing.Size(32, 23)
        Me.BtnAct.TabIndex = 21
        Me.BtnAct.TabStop = False
        Me.BtnAct.Text = "...."
        Me.BtnAct.UseVisualStyleBackColor = False
        '
        'Lblbcr
        '
        Me.Lblbcr.AutoSize = True
        Me.Lblbcr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblbcr.ForeColor = System.Drawing.Color.DimGray
        Me.Lblbcr.Location = New System.Drawing.Point(562, 54)
        Me.Lblbcr.Name = "Lblbcr"
        Me.Lblbcr.Size = New System.Drawing.Size(13, 14)
        Me.Lblbcr.TabIndex = 12
        Me.Lblbcr.Text = "0"
        Me.Lblbcr.Visible = False
        '
        'Lblbal2
        '
        Me.Lblbal2.AutoSize = True
        Me.Lblbal2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblbal2.ForeColor = System.Drawing.Color.Blue
        Me.Lblbal2.Location = New System.Drawing.Point(307, 54)
        Me.Lblbal2.Name = "Lblbal2"
        Me.Lblbal2.Size = New System.Drawing.Size(108, 14)
        Me.Lblbal2.TabIndex = 8
        Me.Lblbal2.Text = "Current Balance"
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
        'Txtamt
        '
        Me.Txtamt.BackColor = System.Drawing.SystemColors.Window
        Me.Txtamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtamt.Location = New System.Drawing.Point(120, 54)
        Me.Txtamt.MaxLength = 29
        Me.Txtamt.Name = "Txtamt"
        Me.Txtamt.Size = New System.Drawing.Size(135, 21)
        Me.Txtamt.TabIndex = 9
        Me.Txtamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtbal2
        '
        Me.txtbal2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbal2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbal2.Location = New System.Drawing.Point(421, 54)
        Me.txtbal2.Name = "txtbal2"
        Me.txtbal2.Size = New System.Drawing.Size(136, 20)
        Me.txtbal2.TabIndex = 6
        Me.txtbal2.Text = "   "
        Me.txtbal2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CmbxACname
        '
        Me.CmbxACname.Location = New System.Drawing.Point(120, 4)
        Me.CmbxACname.Name = "CmbxACname"
        Me.CmbxACname.Size = New System.Drawing.Size(475, 21)
        Me.CmbxACname.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Amount :-"
        '
        'Mskdbxdate
        '
        Me.Mskdbxdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Mskdbxdate.Location = New System.Drawing.Point(540, 468)
        Me.Mskdbxdate.Mask = "00/00/0000"
        Me.Mskdbxdate.Name = "Mskdbxdate"
        Me.Mskdbxdate.Size = New System.Drawing.Size(107, 21)
        Me.Mskdbxdate.TabIndex = 11
        Me.Mskdbxdate.Text = "00000000"
        Me.Mskdbxdate.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(479, 468)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Date : "
        '
        'BtnDrawn
        '
        Me.BtnDrawn.BackColor = System.Drawing.Color.Transparent
        Me.BtnDrawn.Location = New System.Drawing.Point(439, 466)
        Me.BtnDrawn.Name = "BtnDrawn"
        Me.BtnDrawn.Size = New System.Drawing.Size(32, 23)
        Me.BtnDrawn.TabIndex = 21
        Me.BtnDrawn.TabStop = False
        Me.BtnDrawn.Text = "...."
        Me.BtnDrawn.UseVisualStyleBackColor = False
        '
        'BtnNarr
        '
        Me.BtnNarr.BackColor = System.Drawing.Color.Transparent
        Me.BtnNarr.Location = New System.Drawing.Point(615, 497)
        Me.BtnNarr.Name = "BtnNarr"
        Me.BtnNarr.Size = New System.Drawing.Size(32, 23)
        Me.BtnNarr.TabIndex = 21
        Me.BtnNarr.TabStop = False
        Me.BtnNarr.Text = "...."
        Me.BtnNarr.UseVisualStyleBackColor = False
        '
        'CmbxDrawn
        '
        Me.CmbxDrawn.FormattingEnabled = True
        Me.CmbxDrawn.Location = New System.Drawing.Point(128, 468)
        Me.CmbxDrawn.MaxLength = 100
        Me.CmbxDrawn.Name = "CmbxDrawn"
        Me.CmbxDrawn.Size = New System.Drawing.Size(305, 21)
        Me.CmbxDrawn.TabIndex = 10
        '
        'CmbxNar
        '
        Me.CmbxNar.FormattingEnabled = True
        Me.CmbxNar.Location = New System.Drawing.Point(129, 499)
        Me.CmbxNar.MaxLength = 150
        Me.CmbxNar.Name = "CmbxNar"
        Me.CmbxNar.Size = New System.Drawing.Size(481, 21)
        Me.CmbxNar.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 468)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Drawn On : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 499)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Narration : "
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.NavajoWhite
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnEdt)
        Me.Panel4.Controls.Add(Me.BtnAdd)
        Me.Panel4.Controls.Add(Me.BtnClose)
        Me.Panel4.Location = New System.Drawing.Point(9, 530)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(638, 45)
        Me.Panel4.TabIndex = 11
        '
        'BtnEdt
        '
        Me.BtnEdt.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdt.BackgroundImage = CType(resources.GetObject("BtnEdt.BackgroundImage"), System.Drawing.Image)
        Me.BtnEdt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnEdt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEdt.FlatAppearance.BorderSize = 0
        Me.BtnEdt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnEdt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdt.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdt.ForeColor = System.Drawing.Color.Navy
        Me.BtnEdt.Location = New System.Drawing.Point(251, 5)
        Me.BtnEdt.Name = "BtnEdt"
        Me.BtnEdt.Size = New System.Drawing.Size(132, 33)
        Me.BtnEdt.TabIndex = 15
        Me.BtnEdt.Text = "&Cancel"
        Me.BtnEdt.UseVisualStyleBackColor = False
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
        Me.BtnAdd.Location = New System.Drawing.Point(2, 5)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(132, 33)
        Me.BtnAdd.TabIndex = 13
        Me.BtnAdd.Text = "&Save"
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
        'FrmCshBnk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.ClientSize = New System.Drawing.Size(656, 580)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Mskdbxdate)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnDrawn)
        Me.Controls.Add(Me.CmbxDrawn)
        Me.Controls.Add(Me.CmbxNar)
        Me.Controls.Add(Me.BtnNarr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCshBnk"
        Me.Text = "Cash and Bank Book"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmCshBnk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Panel1.Enabled = True
            Add_Edit_Flag = True
            Fill_Combobox("Nrrid", "Narration", "finact_Narration", "NRRDELSTATUS", CInt(1), Me.CmbxNar)
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpkrCbnk, Me.DtpkrCbnk)
            SetControlCurrentDate(Me.DtpkrCbnk)
            fetch_bokname(Me.CmbBokName)
            fetch_splr_Name(Me.CmbxACname)
            Fill_Combobox("DrwnId", "DrwnName", "Finact_DrawnNameMstr", "DRWNDELSTATUS", CInt(1), Me.CmbxDrawn)
            Me.Top = 0
            Me.Width = 662
            Me.Height = 608
            xUsr_xRol_xStatus(xMdi_LnkName.Trim)
            Me.CmbxDrawn.SelectedIndex = -1
            Me.CmbxACname.SelectedIndex = -1
            Me.CmbBokName.SelectedIndex = -1
            Me.CmbxNar.SelectedIndex = -1
            Me.BtnRecd.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub CheckAcess_Btn_frm(ByVal BtnnSave As Button, ByVal BtnnEdt As Button, _
    ByVal BtnnDel As Button)
        Try
            Select Case Trim(AcessRight)
                Case "OwnrFull"
                    BtnnSave.Enabled = True
                    BtnnEdt.Enabled = True
                    BtnnDel.Enabled = True
                Case "DataEntryMstr"
                    BtnnSave.Enabled = True
                    BtnnSave.Location = New System.Drawing.Point(177, 11)
                    BtnnEdt.Visible = False
                    BtnnDel.Visible = False
                Case "DataEntry"
                    BtnnSave.Enabled = True
                    BtnnSave.Location = New System.Drawing.Point(177, 11)
                    BtnnEdt.Visible = False
                    BtnnDel.Visible = False
                Case "PayRoll"
                    BtnnSave.Enabled = True
                    BtnnSave.Location = New System.Drawing.Point(177, 11)
                    BtnnEdt.Visible = False
                    BtnnDel.Visible = False
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Function fetch_start_date() As Date
        Try
            Csh_Bnk_Cmd = New SqlCommand("Select costrtdt  from FinActcogatemstr ", FinActConn)
            Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader

            Csh_Bnk_rdr.Read()
            If Csh_Bnk_rdr.IsDBNull(0) = False Then
                Return Csh_Bnk_rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Csh_Bnk_rdr.Close()
            Csh_Bnk_Cmd = Nothing
        End Try
    End Function
    Private Sub Clr_Values_Ins()
        Try
            Me.Lblvno.Text = ""
            Me.Txtamt.Text = 0
            Me.TxtBokAmt.Text = 0
            Me.Label10.Visible = False
            Me.LblCrNo.Visible = False
            Me.LblCrNo.Text = 0
            Me.label8.Location = New System.Drawing.Point(430, 16)
            Me.lblLdt.Location = New System.Drawing.Point(546, 16)
            Me.txtbal2.Text = 0
            Me.BalTxt.Text = 0
            Me.CmbxDrawn.SelectedIndex = -1
            Me.CmbxACname.SelectedIndex = -1
            Me.CmbBokName.SelectedIndex = -1
            Me.CmbxNar.SelectedIndex = -1
            Me.LstVewAmtDetails.Items.Clear()
            Me.Mskdbxdate.Text = "  /  /"
        Catch ex As Exception

        End Try

    End Sub

    Private Function fetch_splr_Type() As String
        Dim xStr As String = ""
        Try
            Csh_Bnk_Cmd = New SqlCommand("select splrid,splrtype from Finactsplrmstr SPLRDELSTATUS=1 AND where splrid=@x1Splrid ", FinActConn)
            Csh_Bnk_Cmd.Parameters.AddWithValue("@x1Splrid", Me.CmbBokName.SelectedValue)
            Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader
            While Csh_Bnk_rdr.Read
                If Csh_Bnk_rdr.IsDBNull(0) = False Then
                    xStr = Trim(Csh_Bnk_rdr("splrtype"))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Csh_Bnk_rdr.Close()
            Csh_Bnk_Cmd = Nothing

        End Try
        Return xStr
    End Function
    'fetch cash only&bank only recds
    Private Sub fetch_splr_Name_Contra(ByVal Combox As ComboBox, ByVal RecType As String)
        Dim splrType As String

        If CmbBokName.Text = "Bank Book" Then
            splrType = "Bank Account"
            Try
                Csh_Bnk_Cmd = New SqlCommand("select splrname from Finactsplrmstr where  SPLRDELSTATUS=1 AND splrtype='" & (splrType) & "' ", FinActConn)
                Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader
                If Trim(RecType) <> "" Then
                    While Csh_Bnk_rdr.Read()
                        CmbxACname.Items.Add(Csh_Bnk_rdr(0))
                    End While

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

                Csh_Bnk_rdr.Close()
                Csh_Bnk_Cmd = Nothing
            End Try

        ElseIf CmbBokName.Text = "Cash Book" Then
            splrType = "Cash Book"
            Try
                Csh_Bnk_Cmd = New SqlCommand("select splrname from Finactsplrmstr  where splrtype='" & (splrType) & "'", FinActConn)
                Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader
                If Trim(RecType) <> "" Then
                    While Csh_Bnk_rdr.Read()
                        CmbxACname.Items.Add(Csh_Bnk_rdr(0))
                    End While

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

                Csh_Bnk_rdr.Close()
                Csh_Bnk_Cmd = Nothing
            End Try
        End If

    End Sub
    'fetch only clients records
    Private Sub fetch_splr_Name(ByVal x2Combox As ComboBox)
        Try
            Csh_Bnk_Cmd = New SqlCommand("select splrid,splrname from Finactsplrmstr where SPLRDELSTATUS=1 AND splrtype not In ( 'Bank'  , 'Cash Book' ) order by splrname ", FinActConn)

            Csh_Bnk_Sqladptr = New SqlDataAdapter(Csh_Bnk_Cmd)
            Csh_Bnk_Dset = New DataSet(Csh_Bnk_Cmd.CommandText)
            Csh_Bnk_Dset.Tables.Clear()
            Csh_Bnk_Sqladptr.Fill(Csh_Bnk_Dset)

            x2Combox.DataSource = Csh_Bnk_Dset.Tables(0)
            x2Combox.ValueMember = "Splrid"
            x2Combox.DisplayMember = "Splrname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Csh_Bnk_Cmd.Dispose()
            Csh_Bnk_Sqladptr.Dispose()
        End Try

    End Sub
    Private Function fetch_Vou_No() As Integer '===It generates datewise voucher no.
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Csh_Bnk_Cmd = New SqlCommand("Finact_CshBnk_GenerateVno", FinActConn)
            Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
            Csh_Bnk_Cmd.Parameters.AddWithValue("@Trandt", Me.DtpkrCbnk.Value.Date)
            Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader

            Csh_Bnk_rdr.Read()
            If Csh_Bnk_rdr.IsDBNull(0) = False Then
                Return Csh_Bnk_rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Csh_Bnk_rdr.Close()
            Csh_Bnk_Cmd = Nothing
        End Try

    End Function
    Private Sub CshBnkSaverec()
        Try
            Dim Contsplrid As Integer
            Dim ContCashid As Integer
            Lblvno.Text = xFetchVno_dynamic("FinActCshBnk", "CBTranvno")
            ContCashid = Me.CmbBokName.SelectedValue
            If Trim(EntryType.Text) = "Contra" Then
                TranType = "Contra"
                Contsplrid = Me.CmbxACname.SelectedValue
            Else
                splrid = Me.CmbxACname.SelectedValue
            End If

            If Trim(EntryType.Text) = "Receipt" Then
                TranType = "Credit"
                chk_entry = "Receipt"
            ElseIf Trim(EntryType.Text) = "Payment" Then
                TranType = "Debit"
                chk_entry = "Payment"
            ElseIf Trim(EntryType.Text) = "Contra" Then
                TranType = "Contra"
                chk_entry = "Contra"
            End If
            BookName = Fetch_BokType(Me.CmbBokName.SelectedValue)
            BookName1 = Fetch_BokType(Me.CmbxACname.SelectedValue)
            If Trim(EntryType.Text) = "Contra" And BookName = Trim("Cash Book") And BookName1 <> Trim("Cash Book") Then
                TranMode = "CshBnk"
            ElseIf Trim(EntryType.Text) = "Contra" And BookName <> Trim("Cash Book") And BookName1 = Trim("Cash Book") Then
                TranMode = "BnkCsh"
            ElseIf Trim(EntryType.Text) = "Contra" And BookName <> Trim("Cash Book") And BookName1 <> Trim("Cash Book") Then
                TranMode = "BnkBnk"
            ElseIf Trim(EntryType.Text) = "Contra" And BookName = Trim("Cash Book") And BookName1 = Trim("Cash Book") Then
                TranMode = "CshCsh"
            ElseIf Trim(EntryType.Text) = "Receipt" And BookName = Trim("Cash Book") Then
                TranMode = "Csh"
            ElseIf Trim(EntryType.Text) = "Receipt" And BookName <> Trim("Cash Book") Then
                TranMode = "Bnk"
            ElseIf Trim(EntryType.Text) = "Payment" And BookName = Trim("Cash Book") Then
                TranMode = "Csh"
            ElseIf Trim(EntryType.Text) = "Payment" And BookName <> Trim("Cash Book") Then
                TranMode = "Bnk"
            End If
            Try

                If TranType <> "Contra" Then
                    Dim SetContr As Integer = Me.LstVewAmtDetails.Items.Count
                    Dim xNewSplrid As Integer = 0
                    Dim xNewBokId As Integer = 0
                    Dim xNewSplt As Integer = 0
                    Dim xNewType As String = ""
                    Dim Amt As Double = 0

                    For xxSveContr As Integer = 0 To SetContr '- 1
                        If SetContr > 1 Then
                            If xxSveContr = 0 Then
                                xNewSplrid = ContCashid
                                xNewBokId = 0
                                xNewSplt = 1
                                If chk_entry.Trim = "Receipt" Then
                                    TranType = "Debit"
                                Else
                                    TranType = "Credit"
                                End If
                                Amt = FormatNumber(CDbl(Txtamt.Text), 2)
                            Else
                                xNewSplt = 0
                                If chk_entry.Trim = "Receipt" Then
                                    TranType = "Credit"
                                Else
                                    TranType = "Debit"
                                End If
                                xNewSplrid = CInt(Me.LstVewAmtDetails.Items(xxSveContr - 1).SubItems(2).Text)
                                xNewBokId = 0
                                Amt = CDbl(Me.LstVewAmtDetails.Items(xxSveContr - 1).SubItems(1).Text)
                            End If
                        Else
                            Amt = FormatNumber(CDbl(Txtamt.Text), 2)
                            xNewSplrid = splrid
                            xNewBokId = ContCashid
                        End If
                        If SetContr = 1 And xxSveContr = 1 Then
                            MsgBox("Record has been Successfully Saved", MsgBoxStyle.Information, Me.Text)
                            Clr_Values_Ins()
                            Me.CmbxNar.SelectedIndex = -1
                            Exit Sub
                        End If

                        If Me.BtnAdd.Text = "&Save" Then
                            Csh_Bnk_Cmd = New SqlCommand("Finact_CshBnk_Insert", FinActConn)
                            Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
                            Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranCustId", xNewSplrid)
                            Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranaddt", Now)
                            Csh_Bnk_Cmd.Parameters.AddWithValue("@cbadusrid", Current_UsrId)
                            Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranVNo", Trim(Me.Lblvno.Text))
                            Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranCshRno", CInt(Me.LblCrNo.Text))
                            Csh_Bnk_Cmd.Parameters.AddWithValue("@CbTranSpltStatus", CInt(xNewSplt))
                            'Csh_Bnk_Cmd.Parameters.AddWithValue("@CbTranRptBokId", CInt(ContCashid))
                        ElseIf Me.BtnAdd.Text = "&Update" Then
                            ''Csh_Bnk_Cmd = New SqlCommand("Finact_CshBnk_Update", FinActConn)
                            ''Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
                            ''Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranCustId", xNewSplrid)
                            ''Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranedtdt", Now)
                            ''Csh_Bnk_Cmd.Parameters.AddWithValue("@cbedtusrid", Current_UsrId)
                            ''Vnback = CInt(Lblvno.Text)
                            ''Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranVNo", Trim(Vnback))
                            ''Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtransid", CInt(Me.CbRecId))
                        End If
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtrandelstatus", 1)

                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranAmtDrCr", (Amt))
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranBokName", xNewBokId)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranDt", DtpkrCbnk.Value.Date)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranmode", TranMode)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranNraTn", Trim(CmbxNar.Text))
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranType", TranType)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CbTranDrawnOn", CInt(Me.CmbxDrawn.SelectedValue))
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CbTranDrawndt", Me.Mskdbxdate.Text)
                        Csh_Bnk_Cmd.ExecuteNonQuery()
                    Next '--xxSveContr
                ElseIf TranType = "Contra" Then
                    If Me.BtnAdd.Text = "&Save" Then
                        Csh_Bnk_Cmd = New SqlCommand("Finact_CshBnk_Insert", FinActConn)
                        Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranCustId", Contsplrid)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranaddt", Now)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@cbadusrid", Current_UsrId)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranVNo", Trim(Me.Lblvno.Text))
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranCshRno", CInt(Me.LblCrNo.Text))
                    ElseIf Me.BtnAdd.Text = "&Update" Then
                        ''Csh_Bnk_Cmd = New SqlCommand("Finact_CshBnk_Update", FinActConn)
                        ''Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
                        ''Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranedtdt", Now)
                        ''Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranCustId", Contsplrid)
                        ''Csh_Bnk_Cmd.Parameters.AddWithValue("@cbedtusrid", Current_UsrId)
                        ''Vnback = CInt(Lblvno.Text)
                        ''Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranVNo", Trim(Vnback))
                        ''Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtransid", CInt(Me.CbRecId))
                    End If
                    Dim Amt1 As Double
                    Amt1 = FormatNumber(Txtamt.Text, 2)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranAmtDrCr", (Amt1))
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtrandelstatus", 1)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranBokName", ContCashid)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranDt", DtpkrCbnk.Value.Date)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranmode", TranMode)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranNraTn", Trim(CmbxNar.Text))
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranType", TranType)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CbTranDrawnOn", CInt(Me.CmbxDrawn.SelectedValue))
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CbTranDrawndt", Me.Mskdbxdate.Text)
                    Csh_Bnk_Cmd.ExecuteNonQuery()
                End If

                MsgBox("Record has been Successfully Saved", MsgBoxStyle.Information, Me.Text)
                Clr_Values_Ins()
                Me.CmbxNar.SelectedIndex = -1
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Csh_Bnk_Cmd = Nothing
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub BtnRecd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecd.Click
        Try
            EntryType.Text = "Receipt"
            Panel2.Enabled = True
            If Add_Edit_Flag = True Then
                If Txtamt.Text <> "" Or BalTxt.Text <> "" Then
                    'Txtamt.Text = ""
                    'BalTxt.Text = ""
                End If

            End If
            fetch_splr_Name(Me.CmbxACname)
            LblDr.Visible = True
            LblDr.Text = "Amount is Being Credited"
            LblCr.Visible = True
            LblCr.Text = "Amount is Being Debited"

            ' CmbBokName.Focus()
            DtpkrCbnk.Focus()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub BtnPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPay.Click
        Try
            EntryType.Text = "Payment"
            Panel2.Enabled = True


            If Add_Edit_Flag = True Then
                If Txtamt.Text <> "" Or BalTxt.Text <> "" Then
                    ' Txtamt.Text = ""
                    ' BalTxt.Text = ""
                    'CmbBokName.Focus()
                End If
            End If
            fetch_splr_Name(Me.CmbxACname)
            LblDr.Visible = True
            LblDr.Text = "Amount is Being Debited"
            LblCr.Visible = True
            LblCr.Text = "Amount is Being Credited"
            DtpkrCbnk.Focus()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub BtnCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon.Click
        Try
            xCancelValues()
            EntryType.Text = "Contra"
            LblDr.Visible = True
            LblDr.Text = "Amount is Being Credited"

            LblCr.Visible = True
            LblCr.Text = "Amount is Being Debited"

            Panel2.Enabled = True

            If Add_Edit_Flag = True Then
                If Txtamt.Text <> "" Or BalTxt.Text <> "" Then
                    'Txtamt.Text = ""
                    'BalTxt.Text = ""
                    ' CmbBokName.Focus()
                End If
            ElseIf Add_Edit_Flag = False Then

            End If
            '  Me.CmbxACname.DataSource = Nothing
            If EntryType.Text.Trim = "Contra" Then
                fetch_bokname(Me.CmbxACname)
            End If

            DtpkrCbnk.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Chk_val()
        Try
            With Lblvno
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip

                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With CmbBokName
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip

                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With CmbxACname

                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip

                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If

            End With

            With Txtamt
                If Trim(.Text) = "" Or .Text = 0 Then
                    .BackColor = Color.PapayaWhip

                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With CmbxNar
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip

                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try

            Chk_val()


            If IndxMstr <> 0 Then
                IndxMstr = 0
                Exit Sub
            Else
                If CDbl(Me.Txtamt.Text) <> CDbl(Me.TxtBokAmt.Text) Then
                    MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                    Exit Sub
                End If
                If Me.BtnAdd.Text = "&Save" Then

                    If MessageBox.Show("Are you sure to Save current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        CshBnkSaverec()
                    Else
                        Return
                    End If

                    Clr_Values_Ins()
                    BtnEdt.Text = "&Cancel"
                    Panel1.Enabled = True
                    'MsgBox(chk_entry)
                    If chk_entry = Trim("Receipt") Then
                        EntryType.Text = "Receipt"
                        BtnRecd.Focus()

                    ElseIf chk_entry = Trim("Payment") Then
                        EntryType.Text = "Payment"
                        BtnPay.Focus()

                    ElseIf chk_entry = Trim("Contra") Then
                        EntryType.Text = "Contra"
                        BtnCon.Focus()

                    End If

                    Panel2.Enabled = False
                    Panel3.Enabled = False

                ElseIf Me.BtnAdd.Text = "&Update" Then
                    If MessageBox.Show("Are you sure to Update current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        CshBnkSaverec()
                    Else
                        Return
                    End If

                    Clr_Values_Ins()
                    BtnEdt.Text = "&Cancel"
                    If chk_entry = Trim("Receipt") Then
                        EntryType.Text = "Receipt"
                        BtnRecd.Focus()

                    ElseIf chk_entry = Trim("Payment") Then
                        EntryType.Text = "Payment"
                        BtnPay.Focus()

                    ElseIf chk_entry = Trim("Contra") Then
                        EntryType.Text = "Contra"
                        BtnCon.Focus()

                    End If

                    Panel2.Enabled = False
                    Panel3.Enabled = False
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub


    ''Private Sub Csh_Bnk_Delrec1()
    ''    Try
    ''        Delstatus = 0

    ''        Vnback = Lblvno.Text
    ''        Delstatus = 0

    ''        Csh_Bnk_Cmd = New SqlCommand("Finact_CshBnk_Delete", FinActConn)
    ''        Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
    ''        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranCustId", Me.CmbxACname.SelectedValue)
    ''        'Csh_Bnk_Cmd.Parameters.AddWithValue("@Cbdelusrid", Current_UsrId)
    ''        'Csh_Bnk_Cmd.Parameters.AddWithValue("@Cbdeldt", Now)
    ''        'Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtrandelStatus", Delstatus)
    ''        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranVNo", Vnback)
    ''        Csh_Bnk_Cmd.ExecuteNonQuery()
    ''        MsgBox("Current Record has been Deleted", MsgBoxStyle.Information, "Record Deleted")

    ''    Catch EX As Exception
    ''        MsgBox(EX.Message)
    ''    Finally
    ''        Csh_Bnk_Cmd = Nothing
    ''        Clr_Values_Ins()
    ''    End Try
    ''End Sub
    ''Private Sub Delbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Try
    ''        If Trim(Me.Lblvno.Text) = "" Then
    ''            MsgBox("Invalid input", MsgBoxStyle.Critical, "Nothing to delete!!!!")
    ''            Exit Sub
    ''        End If
    ''        BtnEdt.Text = "&Cancel"
    ''        Dim delconfrm As String
    ''        delconfrm = MsgBox("Are you sure to delete this record", MsgBoxStyle.YesNo, "Delete Section")
    ''        If delconfrm = vbYes Then
    ''            Csh_Bnk_Delrec1()
    ''        Else
    ''            'Delbtn.Focus()
    ''        End If
    ''    Catch ex As Exception

    ''    End Try


    ''End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Try
            Dim delconfrm As String
            delconfrm = MsgBox("Are you sure to Exit without save", MsgBoxStyle.YesNo, "Exit")
            If delconfrm = vbYes Then
                Me.Close()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnEdt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdt.Click
        Try
            xCancelValues()
            ''Lblvno.Text = fetch_Vou_No() 'It Generates Datewise Voucher No.
            Lblvno.Text = xFetchVno_dynamic("FinActCshBnk", "CBTranvno")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub xCancelValues()
        Try
            BalTxt.Text = ""
            txtbal2.Text = ""
            CmbBokName.SelectedIndex = -1
            CmbxACname.SelectedIndex = -1
            Me.LstVewAmtDetails.Items.Clear()
            Txtamt.Clear()
            TxtBokAmt.Clear()
            Me.Panel2.Enabled = True
            Me.Panel3.Enabled = True
            BtnAdd.Enabled = True
            BtnRecd.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Lblvno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lblvno.Click
        Try
            ''  Lblvno.Text = fetch_Vou_No() 'It Generates Datewise Voucher No.
            Lblvno.Text = xFetchVno_dynamic("FinActCshBnk", "CBTranvno")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Txtamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtamt.GotFocus
        Try
            xHndlLeave = 0
            Me.Txtamt.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtamt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtamt.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Txtamt_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtamt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtamt.Leave
        Try
            If Len(Me.Txtamt.Text.Trim) = 0 Then
                Me.Txtamt.Focus()
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

            If xChk_numericValidation(Me.Txtamt) = False Then
                Txtamt.Text = FormatNumber(Txtamt.Text, 2)
                Me.BtnOkAmt.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function xAmtTotal() As Double
        Try
            Dim xxAmtTotl As Double = 0
            If Me.LstVewAmtDetails.Items.Count > 0 Then
                For Each xitm As ListViewItem In Me.LstVewAmtDetails.Items
                    xxAmtTotl += xitm.SubItems(1).Text
                Next
            End If
            Return xxAmtTotl
        Catch ex As Exception

        End Try

    End Function


    Private Sub DtpkrCbnk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrCbnk.GotFocus
        Try

            Date.TryParse(fetch_MxDate(), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
            lblLdt.Text = Format(CurrDate, "dd/MM/yyyy")

        Catch ex As Exception

        End Try
    End Sub
    Private Function fetch_MxDate() As Date
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Csh_Bnk_Cmd = New SqlCommand("Finact_CshBnk_MaxDate", FinActConn)
            Csh_Bnk_Cmd.Parameters.AddWithValue("@xIndx", 0)
            Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader

            Csh_Bnk_rdr.Read()
            If Csh_Bnk_rdr.IsDBNull(0) = False Then
                Return Csh_Bnk_rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Csh_Bnk_rdr.Close()
            Csh_Bnk_Cmd = Nothing
        End Try
    End Function
    Private Sub DtpkrCbnk_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrCbnk.Leave
        Try
            CurrentDate = DtpkrCbnk.Value
            If Add_Edit_Flag = True Then
                ''=== Lblvno.Text = fetch_Vou_No()  '===It generates datewise voucher no.
                Lblvno.Text = xFetchVno_dynamic("FinActCshBnk", "CBTranvno")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fetch_bokname(ByVal xCmboBox As ComboBox)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Csh_Bnk_Cmd = New SqlCommand("select splrid,splrname from Finactsplrmstr where SPLRDELSTATUS=1 AND splrtype In ( 'Bank'  , 'Cash Book' ) order by splrname ", FinActConn)

            Csh_Bnk_Sqladptr = New SqlDataAdapter(Csh_Bnk_Cmd)
            Csh_Bnk_Dset = New DataSet(Csh_Bnk_Cmd.CommandText)
            Csh_Bnk_Dset.Tables.Clear()
            Csh_Bnk_Sqladptr.Fill(Csh_Bnk_Dset)

            xCmboBox.DataSource = Csh_Bnk_Dset.Tables(0)
            xCmboBox.ValueMember = "Splrid"
            xCmboBox.DisplayMember = "Splrname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Csh_Bnk_Cmd.Dispose()
            Csh_Bnk_Sqladptr.Dispose()
        End Try


    End Sub

    Private Function Fetch_BokType(ByVal BokId As Integer) As String
        Fetch_BokType = ""
        Try

            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Csh_Bnk_Cmd = New SqlCommand("select splrid,splrtype from Finactsplrmstr where SPLRDELSTATUS=1 AND splrid=@B_id", FinActConn)
            Csh_Bnk_Cmd.Parameters.AddWithValue("@B_id", BokId)
            Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader
            While Csh_Bnk_rdr.Read()
                If Csh_Bnk_rdr.IsDBNull(0) = False Then
                    Return Csh_Bnk_rdr(1)
                Else
                    Return ""
                End If

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Csh_Bnk_rdr.Close()
            Csh_Bnk_Cmd = Nothing

        End Try

    End Function
    ''Private Sub fetch_Cashid()

    ''    Try
    ''        If FinActConn.State Then FinActConn.Close()
    ''        FinActConn.Open()
    ''        Csh_Bnk_Cmd = New SqlCommand("select splrid from Finactsplrmstr where splrtype = '" & ("Cash Book") & " ' ", FinActConn)
    ''        Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader
    ''        While Csh_Bnk_rdr.Read()
    ''            CmbBokName.Items.Add(Csh_Bnk_rdr(0))
    ''        End While


    ''    Catch ex As Exception
    ''        MsgBox(ex.Message)
    ''    Finally

    ''        Csh_Bnk_rdr.Close()
    ''        Csh_Bnk_Cmd = Nothing
    ''    End Try
    ''End Sub

    Private Sub CmbBokName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBokName.GotFocus
        'Done by Rm
        Try
            If xCmbxRefresh = True Then
                fetch_bokname(Me.CmbxACname)
            End If
            If Me.CmbBokName.Items.Count > 0 Then
                If Me.CmbBokName.SelectedIndex = -1 Then
                    Me.CmbBokName.SelectedIndex = 0
                End If
            End If
            If Add_Edit_Flag = True Then
                Me.CmbBokName.DroppedDown = True
            End If
            Me.CmbBokName.SelectAll()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbBokName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBokName.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbBokName) = True Then
                Panel3.Enabled = True
                Fetch_bal_bnk(Me.CmbBokName.SelectedValue, 0)
                xBokType = xDynamic_Find_xAnItem_xInA_Table_1cond_String("SplrType", "Splrid", CInt(Me.CmbBokName.SelectedValue), "Finactsplrmstr")
                If xBokType.Trim = "Cash Book" And EntryType.Text = "Receipt" Then
                    If xIniCshRecptNo = 0 Then
                        CmbxACname.Focus()
                        Exit Sub
                    End If

                    Me.Label10.Visible = True
                    Me.LblCrNo.Visible = True
                    Me.label8.Location = New System.Drawing.Point(430, 5)
                    Me.lblLdt.Location = New System.Drawing.Point(546, 5)
                    Me.LblCrNo.Text = xSetCRNO(xIniCshRecptNo)
                Else
                    Me.Label10.Visible = False
                    Me.LblCrNo.Visible = False
                    Me.LblCrNo.Text = 0
                    Me.label8.Location = New System.Drawing.Point(430, 16)
                    Me.lblLdt.Location = New System.Drawing.Point(546, 16)
                End If
                Me.TxtBokAmt.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Function xSetCRNO(ByVal xxCRNO As Integer) As Integer
        Try
            If xxCRNO > 0 Then
                Dim xMXX As Integer = xFetchMxVal_dynamic_1Cond("FINACTCSHBNK", "CBTranCshRno", "CBTRANMODE", "Csh")
                If xMXX > 0 Then
                    Return xMXX + 1
                Else
                    Return xxCRNO
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub CmbxACname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxACname.GotFocus
        Try
            If xCmbxRefresh = True Then
                If Trim(EntryType.Text) = "Contra" Then
                    fetch_bokname(Me.CmbxACname)
                Else
                    fetch_splr_Name(Me.CmbxACname)
                End If
            End If

            If Me.CmbxACname.Items.Count > 0 Then
                If Me.CmbxACname.SelectedIndex = -1 Then
                    Me.CmbxACname.SelectedIndex = 0
                End If
            End If
            If Add_Edit_Flag = True Then
                Me.CmbxACname.DroppedDown = True
            End If
            Me.CmbxACname.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Trannar_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            If CmbxNar.Text <> "" Then
                BtnAdd.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub FrmCshBnk_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            BtnRecd.Focus()
            Panel2.Enabled = False
            Panel3.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnaLL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRecd.GotFocus, BtnAdd.GotFocus, BtnClose.GotFocus, BtnCon.GotFocus, BtnEdt.GotFocus, BtnPay.GotFocus
        Try
            Try
                Dim xBtn As Button = CType(sender, Button)
                xBtn.BackColor = Color.Blue
                If xBtn.Name.Trim = "BtnRecd" Or xBtn.Name.Trim = "BtnPay" Or xBtn.Name.Trim = "BtnCon" Then
                    xBtn.ForeColor = Color.White
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BalTxt.KeyDown, BtnAdd.KeyDown, BtnClose.KeyDown, BtnCon.KeyDown, BtnEdt.KeyDown, BtnPay.KeyDown, BtnRecd.KeyDown, CmbBokName.KeyDown, CmbxACname.KeyDown, DtpkrCbnk.KeyDown, EntryType.KeyDown, Label1.KeyDown, Label2.KeyDown, Label3.KeyDown, Label4.KeyDown, Label5.KeyDown, Label6.KeyDown, Label7.KeyDown, Lblbal2.KeyDown, LblCr.KeyDown, LblDr.KeyDown, Lblvno.KeyDown, Panel1.KeyDown, Panel3.KeyDown, Panel2.KeyDown, Panel4.KeyDown, txtbal2.KeyDown, Label9.KeyDown, Label12.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub CmbBokName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbBokName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbBokName_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxACname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxACname.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxACname_Leave(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TranNar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxNar.GotFocus
        Try
            If xCmbxRefresh = True Then
                Fill_Combobox("Nrrid", "Narration", "finact_Narration", "NRRDELSTATUS", CInt(1), Me.CmbxNar)
            End If
            Me.CmbxNar.DroppedDown = True
            Me.CmbxNar.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fetch_bal_bnk(ByVal x3Splrid As Integer, ByVal xType As Integer) 'for bnk & csh book
        Dim Fet_typ As String = ""

        '-------for bokname
        Dim DrCrType As String = ""
        Dim Bokidx As Integer = 0
        Dim Bookname As String = ""
        Dim FDr As Double = 0
        Dim FCr As Double = 0
        Dim FOpnDr As Double = 0
        Dim FOpnCr As Double = 0
        Dim TotalCharges As Double = 0.0
        Dim RebDis As Double = 0.0
        Dim AmtVatable As Double = 0.0
        Dim NetAmt As Double = 0.0
        Bokidx = x3Splrid

        Try
            Csh_Bnk_Cmd = New SqlCommand("select splropnbal, splrbaltype,splrtype from Finactsplrmstr where  SPLRDELSTATUS=1 AND splrid=@xSplrid", FinActConn)
            Csh_Bnk_Cmd.Parameters.AddWithValue("@xSplrid", Bokidx)
            Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader

            While Csh_Bnk_rdr.Read()
                DrCrType = Trim(Csh_Bnk_rdr(1))
                If DrCrType = "Debit" Then
                    FOpnDr = Csh_Bnk_rdr(0)
                ElseIf DrCrType = "Credit" Then
                    FOpnCr = Csh_Bnk_rdr(0)
                End If
                Fet_typ = Trim(Csh_Bnk_rdr(2))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Csh_Bnk_rdr.Close()
            Csh_Bnk_Cmd = Nothing
        End Try

        '--------------------------------*bnkbok_Cashbook

        Try
            Dim Val0, Val1, Val2, Val3, Val4, Val5 As Double
            Val0 = 0
            Val1 = 0
            Val2 = 0
            Val3 = 0
            Val4 = 0
            Val5 = 0


            Csh_Bnk_Cmd = New SqlCommand("Finact_Cshbnk_Select_Debit_Credit_For_A_Account", FinActConn1)
            Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
            Csh_Bnk_Cmd.Parameters.AddWithValue("@Bokid", Bokidx)
            Csh_Bnk_Cmd.Parameters.AddWithValue("@Custid", Bokidx)

            Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader
            While Csh_Bnk_rdr.Read
                'credit Entries
                If Csh_Bnk_rdr.IsDBNull(0) = False Then
                    Val0 = Csh_Bnk_rdr(0)
                End If

                If Csh_Bnk_rdr.IsDBNull(1) = False Then
                    Val1 = Csh_Bnk_rdr(1)
                End If

                If Csh_Bnk_rdr.IsDBNull(2) = False Then
                    Val2 = Csh_Bnk_rdr(2)
                End If

                'Debit Entries
                If Csh_Bnk_rdr.IsDBNull(3) = False Then
                    Val3 = Csh_Bnk_rdr(3)
                End If

                If Csh_Bnk_rdr.IsDBNull(4) = False Then
                    Val4 = Csh_Bnk_rdr(4)
                End If

                If Csh_Bnk_rdr.IsDBNull(5) = False Then
                    Val5 = Csh_Bnk_rdr(5)
                End If
                FDr = (Val3 + Val4 + Val5)
                FCr = (Val0 + Val1 + Val2)

            End While
            FDr = FDr + FOpnDr
            FCr = FCr + FOpnCr
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Csh_Bnk_rdr.Close()
            Csh_Bnk_Cmd.Dispose()

        End Try

        '--------SALE  ENTERIES

        Try


            Cmd = New SqlCommand("Select sum(saleenttotlamt)as SaleAmt from finactsaleentry WHERE saleentdelstatus='" & (1) & "' and  saleentsplrid = '" & (Bokidx) & " '", FinActConn1)
            rdr = Cmd.ExecuteReader
            NetAmt = 0.0


            While rdr.Read
                If rdr.IsDBNull(0) = False Then

                    NetAmt = rdr("Saleamt")
                    FDr += NetAmt
                End If

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            rdr.Close()
            Cmd = Nothing
        End Try

        ' -------------PURCHASE ENTERIES
        Try
            Cmd = New SqlCommand("Select sum(purenttotlamt)as PurAmount from finactpurentry WHERE purentdelstatus='" & (1) & "' and  purentsplrid = '" & (Bokidx) & " '", FinActConn1)
            rdr = Cmd.ExecuteReader

            NetAmt = 0.0


            While rdr.Read
                If rdr.IsDBNull(0) = False Then
                    NetAmt = rdr("PurAmount")
                    FCr += NetAmt

                End If

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            rdr.Close()
            Cmd = Nothing
        End Try


        If xType = 0 Then
            Dim TbalDrCr As Double = 0
            TbalDrCr = FDr - FCr
            If FDr > FCr Then
                Lblbdr.Visible = True
                Lblbdr.Text = "Dr"
                BalTxt.Text = FormatNumber(Abs(TbalDrCr), 2)
            ElseIf FCr > FDr Then
                Lblbdr.Visible = True
                Lblbdr.Text = "Cr"
                BalTxt.Text = FormatNumber(Abs(TbalDrCr), 2)
            ElseIf TbalDrCr = 0 Then
                BalTxt.Text = FormatNumber(Abs(TbalDrCr), 2)
            End If
        ElseIf xType = 1 Then
            Dim TbalDrCr As Double = 0
            TbalDrCr = FDr - FCr
            If FDr > FCr Then
                Lblbcr.Visible = True
                Lblbcr.Text = "Dr"
                txtbal2.Text = FormatNumber(Abs(TbalDrCr), 2)
            ElseIf FCr > FDr Then
                Lblbcr.Visible = True
                Lblbcr.Text = "Cr"
                txtbal2.Text = FormatNumber(Abs(TbalDrCr), 2)
            ElseIf TbalDrCr = 0 Then
                txtbal2.Text = FormatNumber(Abs(TbalDrCr), 2)
            End If

        End If


    End Sub



    Private Sub CmbxACname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxACname.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxACname) = True Then
                Fetch_bal_bnk(Me.CmbxACname.SelectedValue, 1)
                If EntryType.Text = "Contra" Then
                    Me.Txtamt.Enabled = False
                    Me.BtnOkAmt.Focus()
                Else
                    Me.Txtamt.Enabled = True
                    Me.Txtamt.Focus()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Allcontrolss_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrCbnk.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub TranNar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxNar.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.BtnAdd.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub BtnALL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Leave, BtnClose.Leave, BtnCon.Leave, BtnEdt.Leave, BtnPay.Leave, BtnRecd.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
            If xBtn.Name.Trim = "BtnRecd" Or xBtn.Name.Trim = "BtnPay" Or xBtn.Name.Trim = "BtnCon" Then
                xBtn.ForeColor = Color.Navy
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnbok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnbok.Click
        Try
            xCall_LinkFrm(FrmActMstr, Me.CmbBokName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAct.Click
        Try
            xCall_LinkFrm(FrmActMstr, Me.CmbxACname)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNarr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNarr.Click
        Try
            xCall_LinkFrm(FrmNarrationMstr, Me.CmbxNar)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDrawn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDrawn.Click
        Try
            xCall_LinkFrm(FrmDrawnNameMstr, Me.CmbxDrawn)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxDrawn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDrawn.GotFocus
        Try
            If xCmbxRefresh = True Then
                Fill_Combobox("DrwnId", "DrwnName", "Finact_DrawnNameMstr", "DRWNDELSTATUS", CInt(1), Me.CmbxDrawn)
            End If
            Me.CmbxDrawn.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxDrawn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxDrawn.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Mskdbxdate.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Mskdbxdate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mskdbxdate.GotFocus
        Try
            Me.Mskdbxdate.SelectAll()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Mskdbxdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Mskdbxdate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxNar.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Mskdbxdate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mskdbxdate.Leave
        Try
            If Me.Mskdbxdate.Text = "  /  /" Then
                Me.Mskdbxdate.Text = "00/00/0000"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTNoK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNoK.Click
        Try
            TxtBokAmt_Leave(sender, e)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub TxtBokAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBokAmt.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.TxtBokAmt_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBokAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBokAmt.Leave
        Try
            If Len(Me.TxtBokAmt.Text.Trim) = 0 Then
                Me.TxtBokAmt.Focus()
                Exit Sub
            End If

            If xChk_numericValidation(Me.TxtBokAmt) = False Then
                If Me.TxtBokAmt.Text = 0 Then
                    Me.TxtBokAmt.Focus()
                    Me.TxtBokAmt.SelectAll()
                    Exit Sub
                End If
                Me.TxtBokAmt.Text = FormatNumber(CDbl(Me.TxtBokAmt.Text), 2)
                Me.Txtamt.Text = FormatNumber(CDbl(Me.TxtBokAmt.Text), 2)
                Me.CmbxACname.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnOkAmt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOkAmt.Click
        Try
            Dim xLstTotal As Double = CDbl(xAmtTotal())
            Dim xCurAmt As Double = CDbl(Me.Txtamt.Text)
            If CDbl(xLstTotal) + CDbl(xCurAmt) = CDbl(Me.TxtBokAmt.Text) Then
                Me.Txtamt.Text = FormatNumber(CDbl(xLstTotal) + CDbl(xCurAmt), 2, , TriState.False)
                Me.Panel2.Enabled = False
                Me.Panel3.Enabled = False
                Me.CmbxDrawn.Focus()
            ElseIf CDbl(xLstTotal) + CDbl(xCurAmt) > CDbl(Me.TxtBokAmt.Text) Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                Me.Txtamt.Focus()
                Exit Sub
            Else
                Me.Txtamt.Text = CDbl(Me.TxtBokAmt.Text) - (CDbl(xLstTotal) + CDbl(xCurAmt))
                Me.CmbxACname.Focus()
            End If

            Dim xlitm As ListViewItem
            xlitm = Me.LstVewAmtDetails.Items.Add(Me.CmbxACname.Text.Trim)
            xlitm.SubItems.Add(FormatNumber(CDbl(xCurAmt), 2))
            xlitm.SubItems.Add(Me.CmbxACname.SelectedValue)
            xlitm.SubItems.Add(Me.EntryType.Text.Trim)

        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnokAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOkAmt.GotFocus, BTNoK.GotFocus

        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTNokAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNoK.Leave, BtnOkAmt.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent

        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub CmbxNar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxNar.SelectedIndexChanged

    End Sub

    Private Sub DtpkrCbnk_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpkrCbnk.ValueChanged

    End Sub

    Private Sub CmbBokName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBokName.SelectedIndexChanged

    End Sub
End Class

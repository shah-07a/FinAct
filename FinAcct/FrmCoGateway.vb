Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports fINACCT.EnCryp_DeCryp_String
Imports System.Reflection
Imports System
Public Class FrmCoGateway
    Inherits System.Windows.Forms.Form
    Dim Indx As Integer
    Dim CoGateCmd As SqlCommand
    Dim val_flag As Boolean = False
    Dim count As Integer = 0
    Dim CogateAdrs As SqlCommand
    Dim CogateId As SqlCommand
    Dim DtaRdr As SqlDataReader
    Dim SelIndx As Integer = 0
    Dim hintid As Integer = 0
    Dim fso As Object
    Dim Chk_CsC As Boolean
    Dim MySource As String
    Dim ImagePath As String = "None"
    Dim sel_idx As Integer = 0
    Dim Costat As String = ""
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents PnlAdmn As System.Windows.Forms.Panel
    Friend WithEvents TxtadmnPass As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtadmnpass1 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtcologo1 As System.Windows.Forms.Label
    Friend WithEvents Cmbxcty As System.Windows.Forms.TextBox
    Friend WithEvents Cmbxcontry As System.Windows.Forms.TextBox
    Friend WithEvents Cmbxstate As System.Windows.Forms.TextBox
    Friend WithEvents lblAns As System.Windows.Forms.Label
    Friend WithEvents cmbxHint As System.Windows.Forms.ComboBox
    Friend WithEvents lblHint As System.Windows.Forms.Label
    Friend WithEvents txtans As System.Windows.Forms.TextBox
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
    Friend WithEvents Txtesi As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Txtpf As System.Windows.Forms.TextBox
    Friend WithEvents TxtOnrAdrs As System.Windows.Forms.TextBox
    Friend WithEvents TxtOnrAdrs1 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtOnrDesi As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Picbox As System.Windows.Forms.PictureBox
    Friend WithEvents Lnklbl As System.Windows.Forms.LinkLabel
    Friend WithEvents SfD1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rbfirm As System.Windows.Forms.RadioButton
    Friend WithEvents Rbindv As System.Windows.Forms.RadioButton
    Friend WithEvents BtnQues As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxtLbrOnPur As System.Windows.Forms.TextBox
    Friend WithEvents TxtTDSlmt As System.Windows.Forms.TextBox
    Friend WithEvents TxtLbrOnSale As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TxtTDSrate As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtadrs As System.Windows.Forms.TextBox

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
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPin As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtPhwrk As System.Windows.Forms.TextBox
    Friend WithEvents TxtExtnNo As System.Windows.Forms.TextBox
    Friend WithEvents TxtPhResi As System.Windows.Forms.TextBox
    Friend WithEvents TxtAlPhno As System.Windows.Forms.TextBox
    Friend WithEvents TxtMobNo As System.Windows.Forms.TextBox
    Friend WithEvents TxtFxNo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtWeb As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCoOnr As System.Windows.Forms.TextBox
    Friend WithEvents TxtPAN As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtVAT As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtCST As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtAdrs1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtAlMobl As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtpkrStrtdt As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPin = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtPhwrk = New System.Windows.Forms.TextBox
        Me.TxtExtnNo = New System.Windows.Forms.TextBox
        Me.TxtPhResi = New System.Windows.Forms.TextBox
        Me.TxtAlPhno = New System.Windows.Forms.TextBox
        Me.TxtMobNo = New System.Windows.Forms.TextBox
        Me.TxtFxNo = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.TxtWeb = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCoOnr = New System.Windows.Forms.TextBox
        Me.TxtPAN = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtVAT = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtCST = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxtAdrs1 = New System.Windows.Forms.TextBox
        Me.TxtAlMobl = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DtpkrStrtdt = New System.Windows.Forms.DateTimePicker
        Me.Label21 = New System.Windows.Forms.Label
        Me.TxtEmail = New System.Windows.Forms.TextBox
        Me.PnlAdmn = New System.Windows.Forms.Panel
        Me.BtnQues = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Rbfirm = New System.Windows.Forms.RadioButton
        Me.Rbindv = New System.Windows.Forms.RadioButton
        Me.lblAns = New System.Windows.Forms.Label
        Me.cmbxHint = New System.Windows.Forms.ComboBox
        Me.lblHint = New System.Windows.Forms.Label
        Me.txtans = New System.Windows.Forms.TextBox
        Me.txtadmnpass1 = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtadmnPass = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.txtcologo1 = New System.Windows.Forms.Label
        Me.Cmbxcty = New System.Windows.Forms.TextBox
        Me.Cmbxcontry = New System.Windows.Forms.TextBox
        Me.Cmbxstate = New System.Windows.Forms.TextBox
        Me.txtadrs = New System.Windows.Forms.TextBox
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnClos = New System.Windows.Forms.Button
        Me.Txtesi = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Txtpf = New System.Windows.Forms.TextBox
        Me.TxtOnrAdrs = New System.Windows.Forms.TextBox
        Me.TxtOnrAdrs1 = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TxtOnrDesi = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Picbox = New System.Windows.Forms.PictureBox
        Me.Lnklbl = New System.Windows.Forms.LinkLabel
        Me.SfD1 = New System.Windows.Forms.SaveFileDialog
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtLbrOnPur = New System.Windows.Forms.TextBox
        Me.TxtTDSlmt = New System.Windows.Forms.TextBox
        Me.TxtLbrOnSale = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.TxtTDSrate = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.PnlAdmn.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Picbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtName
        '
        Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtName.Location = New System.Drawing.Point(128, 5)
        Me.TxtName.MaxLength = 75
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(290, 20)
        Me.TxtName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(6, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Name"
        '
        'TxtPin
        '
        Me.TxtPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPin.Location = New System.Drawing.Point(405, 222)
        Me.TxtPin.MaxLength = 6
        Me.TxtPin.Name = "TxtPin"
        Me.TxtPin.Size = New System.Drawing.Size(136, 20)
        Me.TxtPin.TabIndex = 11
        Me.TxtPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(6, 197)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 14)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "City "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(6, 221)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 14)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Country "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(279, 197)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 14)
        Me.Label11.TabIndex = 104
        Me.Label11.Text = "State"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(279, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 14)
        Me.Label12.TabIndex = 103
        Me.Label12.Text = "Postal Code  "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(6, 294)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(115, 14)
        Me.Label13.TabIndex = 102
        Me.Label13.Text = "Phone  No. (Works) "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(278, 295)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 14)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Extention No. "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(279, 272)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 14)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "Phone No.(Resi) "
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(277, 318)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 14)
        Me.Label16.TabIndex = 92
        Me.Label16.Text = "Alternative Phone No. "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(6, 318)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 14)
        Me.Label17.TabIndex = 95
        Me.Label17.Text = "Mobile No. "
        '
        'TxtPhwrk
        '
        Me.TxtPhwrk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPhwrk.Location = New System.Drawing.Point(127, 294)
        Me.TxtPhwrk.MaxLength = 12
        Me.TxtPhwrk.Name = "TxtPhwrk"
        Me.TxtPhwrk.Size = New System.Drawing.Size(136, 20)
        Me.TxtPhwrk.TabIndex = 16
        Me.TxtPhwrk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtExtnNo
        '
        Me.TxtExtnNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtExtnNo.Location = New System.Drawing.Point(405, 294)
        Me.TxtExtnNo.MaxLength = 12
        Me.TxtExtnNo.Name = "TxtExtnNo"
        Me.TxtExtnNo.Size = New System.Drawing.Size(136, 20)
        Me.TxtExtnNo.TabIndex = 17
        Me.TxtExtnNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPhResi
        '
        Me.TxtPhResi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPhResi.Location = New System.Drawing.Point(405, 270)
        Me.TxtPhResi.MaxLength = 12
        Me.TxtPhResi.Name = "TxtPhResi"
        Me.TxtPhResi.Size = New System.Drawing.Size(136, 20)
        Me.TxtPhResi.TabIndex = 15
        Me.TxtPhResi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtAlPhno
        '
        Me.TxtAlPhno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAlPhno.Location = New System.Drawing.Point(405, 318)
        Me.TxtAlPhno.MaxLength = 12
        Me.TxtAlPhno.Name = "TxtAlPhno"
        Me.TxtAlPhno.Size = New System.Drawing.Size(136, 20)
        Me.TxtAlPhno.TabIndex = 19
        Me.TxtAlPhno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtMobNo
        '
        Me.TxtMobNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMobNo.Location = New System.Drawing.Point(127, 318)
        Me.TxtMobNo.MaxLength = 12
        Me.TxtMobNo.Name = "TxtMobNo"
        Me.TxtMobNo.Size = New System.Drawing.Size(136, 20)
        Me.TxtMobNo.TabIndex = 18
        Me.TxtMobNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtFxNo
        '
        Me.TxtFxNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFxNo.Location = New System.Drawing.Point(127, 342)
        Me.TxtFxNo.MaxLength = 12
        Me.TxtFxNo.Name = "TxtFxNo"
        Me.TxtFxNo.Size = New System.Drawing.Size(136, 20)
        Me.TxtFxNo.TabIndex = 20
        Me.TxtFxNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(6, 342)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(51, 14)
        Me.Label19.TabIndex = 96
        Me.Label19.Text = "Fax No.  "
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(279, 366)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 14)
        Me.Label20.TabIndex = 97
        Me.Label20.Text = "Web Site "
        '
        'TxtWeb
        '
        Me.TxtWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtWeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtWeb.Location = New System.Drawing.Point(405, 368)
        Me.TxtWeb.MaxLength = 50
        Me.TxtWeb.Name = "TxtWeb"
        Me.TxtWeb.Size = New System.Drawing.Size(136, 20)
        Me.TxtWeb.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(7, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Start Date"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(7, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "Owner's Name"
        '
        'TxtCoOnr
        '
        Me.TxtCoOnr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCoOnr.Location = New System.Drawing.Point(128, 53)
        Me.TxtCoOnr.MaxLength = 75
        Me.TxtCoOnr.Name = "TxtCoOnr"
        Me.TxtCoOnr.Size = New System.Drawing.Size(290, 20)
        Me.TxtCoOnr.TabIndex = 2
        '
        'TxtPAN
        '
        Me.TxtPAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPAN.Location = New System.Drawing.Point(127, 270)
        Me.TxtPAN.MaxLength = 10
        Me.TxtPAN.Name = "TxtPAN"
        Me.TxtPAN.Size = New System.Drawing.Size(136, 20)
        Me.TxtPAN.TabIndex = 14
        Me.TxtPAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(6, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "PAN"
        '
        'TxtVAT
        '
        Me.TxtVAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVAT.Location = New System.Drawing.Point(127, 246)
        Me.TxtVAT.MaxLength = 11
        Me.TxtVAT.Name = "TxtVAT"
        Me.TxtVAT.Size = New System.Drawing.Size(136, 20)
        Me.TxtVAT.TabIndex = 12
        Me.TxtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(6, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "VAT No "
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(279, 246)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 16)
        Me.Label8.TabIndex = 113
        Me.Label8.Text = "CST No."
        '
        'TxtCST
        '
        Me.TxtCST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCST.Location = New System.Drawing.Point(405, 246)
        Me.TxtCST.MaxLength = 11
        Me.TxtCST.Name = "TxtCST"
        Me.TxtCST.Size = New System.Drawing.Size(136, 20)
        Me.TxtCST.TabIndex = 13
        Me.TxtCST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(6, 148)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(121, 16)
        Me.Label23.TabIndex = 108
        Me.Label23.Text = "Company's Address"
        '
        'TxtAdrs1
        '
        Me.TxtAdrs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAdrs1.Location = New System.Drawing.Point(128, 170)
        Me.TxtAdrs1.MaxLength = 50
        Me.TxtAdrs1.Name = "TxtAdrs1"
        Me.TxtAdrs1.Size = New System.Drawing.Size(414, 20)
        Me.TxtAdrs1.TabIndex = 7
        '
        'TxtAlMobl
        '
        Me.TxtAlMobl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAlMobl.Location = New System.Drawing.Point(405, 342)
        Me.TxtAlMobl.MaxLength = 12
        Me.TxtAlMobl.Name = "TxtAlMobl"
        Me.TxtAlMobl.Size = New System.Drawing.Size(136, 20)
        Me.TxtAlMobl.TabIndex = 21
        Me.TxtAlMobl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(276, 342)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 14)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "Alternative Mobile  No. "
        '
        'DtpkrStrtdt
        '
        Me.DtpkrStrtdt.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrStrtdt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpkrStrtdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrStrtdt.Location = New System.Drawing.Point(128, 28)
        Me.DtpkrStrtdt.MaxDate = New Date(2143, 8, 30, 0, 0, 0, 0)
        Me.DtpkrStrtdt.MinDate = New Date(2000, 4, 1, 0, 0, 0, 0)
        Me.DtpkrStrtdt.Name = "DtpkrStrtdt"
        Me.DtpkrStrtdt.Size = New System.Drawing.Size(100, 22)
        Me.DtpkrStrtdt.TabIndex = 1
        Me.DtpkrStrtdt.Value = New Date(2000, 4, 1, 0, 0, 0, 0)
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(6, 366)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(90, 14)
        Me.Label21.TabIndex = 101
        Me.Label21.Text = "E-Mail Address"
        '
        'TxtEmail
        '
        Me.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtEmail.Location = New System.Drawing.Point(127, 366)
        Me.TxtEmail.MaxLength = 50
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(136, 20)
        Me.TxtEmail.TabIndex = 22
        '
        'PnlAdmn
        '
        Me.PnlAdmn.BackColor = System.Drawing.Color.Aqua
        Me.PnlAdmn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlAdmn.Controls.Add(Me.BtnQues)
        Me.PnlAdmn.Controls.Add(Me.GroupBox1)
        Me.PnlAdmn.Controls.Add(Me.lblAns)
        Me.PnlAdmn.Controls.Add(Me.cmbxHint)
        Me.PnlAdmn.Controls.Add(Me.lblHint)
        Me.PnlAdmn.Controls.Add(Me.txtans)
        Me.PnlAdmn.Controls.Add(Me.txtadmnpass1)
        Me.PnlAdmn.Controls.Add(Me.Label25)
        Me.PnlAdmn.Controls.Add(Me.TxtadmnPass)
        Me.PnlAdmn.Controls.Add(Me.Label24)
        Me.PnlAdmn.Location = New System.Drawing.Point(1, 468)
        Me.PnlAdmn.Name = "PnlAdmn"
        Me.PnlAdmn.Size = New System.Drawing.Size(540, 121)
        Me.PnlAdmn.TabIndex = 30
        '
        'BtnQues
        '
        Me.BtnQues.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnQues.ForeColor = System.Drawing.Color.Red
        Me.BtnQues.Location = New System.Drawing.Point(499, 60)
        Me.BtnQues.Name = "BtnQues"
        Me.BtnQues.Size = New System.Drawing.Size(35, 23)
        Me.BtnQues.TabIndex = 108
        Me.BtnQues.TabStop = False
        Me.BtnQues.Text = "...."
        Me.BtnQues.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnQues.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rbfirm)
        Me.GroupBox1.Controls.Add(Me.Rbindv)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(309, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(94, 46)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        '
        'Rbfirm
        '
        Me.Rbfirm.AutoSize = True
        Me.Rbfirm.Location = New System.Drawing.Point(1, 26)
        Me.Rbfirm.Name = "Rbfirm"
        Me.Rbfirm.Size = New System.Drawing.Size(77, 18)
        Me.Rbfirm.TabIndex = 1
        Me.Rbfirm.Text = "Company"
        Me.Rbfirm.UseVisualStyleBackColor = True
        '
        'Rbindv
        '
        Me.Rbindv.AutoSize = True
        Me.Rbindv.Checked = True
        Me.Rbindv.Location = New System.Drawing.Point(1, 7)
        Me.Rbindv.Name = "Rbindv"
        Me.Rbindv.Size = New System.Drawing.Size(77, 18)
        Me.Rbindv.TabIndex = 0
        Me.Rbindv.TabStop = True
        Me.Rbindv.Text = "Individual"
        Me.Rbindv.UseVisualStyleBackColor = True
        '
        'lblAns
        '
        Me.lblAns.BackColor = System.Drawing.Color.Transparent
        Me.lblAns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAns.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAns.Location = New System.Drawing.Point(2, 88)
        Me.lblAns.Name = "lblAns"
        Me.lblAns.Size = New System.Drawing.Size(125, 20)
        Me.lblAns.TabIndex = 107
        Me.lblAns.Text = "Type answer"
        '
        'cmbxHint
        '
        Me.cmbxHint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxHint.FormattingEnabled = True
        Me.cmbxHint.Location = New System.Drawing.Point(134, 60)
        Me.cmbxHint.Name = "cmbxHint"
        Me.cmbxHint.Size = New System.Drawing.Size(359, 22)
        Me.cmbxHint.TabIndex = 34
        '
        'lblHint
        '
        Me.lblHint.BackColor = System.Drawing.Color.Transparent
        Me.lblHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHint.Location = New System.Drawing.Point(3, 58)
        Me.lblHint.Name = "lblHint"
        Me.lblHint.Size = New System.Drawing.Size(126, 20)
        Me.lblHint.TabIndex = 106
        Me.lblHint.Text = "Select Hint Question"
        '
        'txtans
        '
        Me.txtans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtans.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtans.Location = New System.Drawing.Point(134, 89)
        Me.txtans.MaxLength = 32
        Me.txtans.Name = "txtans"
        Me.txtans.Size = New System.Drawing.Size(359, 21)
        Me.txtans.TabIndex = 35
        '
        'txtadmnpass1
        '
        Me.txtadmnpass1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtadmnpass1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadmnpass1.Location = New System.Drawing.Point(133, 33)
        Me.txtadmnpass1.MaxLength = 22
        Me.txtadmnpass1.Name = "txtadmnpass1"
        Me.txtadmnpass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(88)
        Me.txtadmnpass1.Size = New System.Drawing.Size(150, 20)
        Me.txtadmnpass1.TabIndex = 32
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Location = New System.Drawing.Point(3, 33)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(123, 16)
        Me.Label25.TabIndex = 103
        Me.Label25.Text = "Confirm Password :-"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtadmnPass
        '
        Me.TxtadmnPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtadmnPass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtadmnPass.Location = New System.Drawing.Point(133, 8)
        Me.TxtadmnPass.MaxLength = 22
        Me.TxtadmnPass.Name = "TxtadmnPass"
        Me.TxtadmnPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(88)
        Me.TxtadmnPass.Size = New System.Drawing.Size(150, 20)
        Me.TxtadmnPass.TabIndex = 31
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Location = New System.Drawing.Point(3, 8)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(75, 16)
        Me.Label24.TabIndex = 103
        Me.Label24.Text = "Password :-"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtcologo1
        '
        Me.txtcologo1.AutoSize = True
        Me.txtcologo1.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcologo1.Location = New System.Drawing.Point(270, 400)
        Me.txtcologo1.Name = "txtcologo1"
        Me.txtcologo1.Size = New System.Drawing.Size(0, 12)
        Me.txtcologo1.TabIndex = 120
        '
        'Cmbxcty
        '
        Me.Cmbxcty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cmbxcty.Location = New System.Drawing.Point(128, 195)
        Me.Cmbxcty.MaxLength = 30
        Me.Cmbxcty.Name = "Cmbxcty"
        Me.Cmbxcty.Size = New System.Drawing.Size(136, 20)
        Me.Cmbxcty.TabIndex = 8
        Me.Cmbxcty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cmbxcontry
        '
        Me.Cmbxcontry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cmbxcontry.Location = New System.Drawing.Point(128, 219)
        Me.Cmbxcontry.MaxLength = 30
        Me.Cmbxcontry.Name = "Cmbxcontry"
        Me.Cmbxcontry.Size = New System.Drawing.Size(136, 20)
        Me.Cmbxcontry.TabIndex = 10
        Me.Cmbxcontry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cmbxstate
        '
        Me.Cmbxstate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cmbxstate.Location = New System.Drawing.Point(405, 197)
        Me.Cmbxstate.MaxLength = 30
        Me.Cmbxstate.Name = "Cmbxstate"
        Me.Cmbxstate.Size = New System.Drawing.Size(136, 20)
        Me.Cmbxstate.TabIndex = 9
        Me.Cmbxstate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtadrs
        '
        Me.txtadrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtadrs.Location = New System.Drawing.Point(128, 148)
        Me.txtadrs.MaxLength = 50
        Me.txtadrs.Name = "txtadrs"
        Me.txtadrs.Size = New System.Drawing.Size(413, 20)
        Me.txtadrs.TabIndex = 6
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.LightCyan
        Me.BtnSave.BackgroundImage = Global.FinAcct.My.Resources.Resources.bg
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Location = New System.Drawing.Point(1, 595)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(158, 22)
        Me.BtnSave.TabIndex = 36
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnClos
        '
        Me.BtnClos.BackColor = System.Drawing.Color.LightCyan
        Me.BtnClos.BackgroundImage = Global.FinAcct.My.Resources.Resources.bg
        Me.BtnClos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClos.Location = New System.Drawing.Point(383, 595)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(158, 22)
        Me.BtnClos.TabIndex = 37
        Me.BtnClos.Text = "&Close"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'Txtesi
        '
        Me.Txtesi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtesi.Location = New System.Drawing.Point(127, 392)
        Me.Txtesi.MaxLength = 50
        Me.Txtesi.Name = "Txtesi"
        Me.Txtesi.Size = New System.Drawing.Size(136, 20)
        Me.Txtesi.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(276, 392)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 14)
        Me.Label5.TabIndex = 123
        Me.Label5.Text = "PF Registration No"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(6, 392)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(110, 14)
        Me.Label18.TabIndex = 124
        Me.Label18.Text = "ESI Registration No"
        '
        'Txtpf
        '
        Me.Txtpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtpf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtpf.Location = New System.Drawing.Point(405, 393)
        Me.Txtpf.MaxLength = 50
        Me.Txtpf.Name = "Txtpf"
        Me.Txtpf.Size = New System.Drawing.Size(136, 20)
        Me.Txtpf.TabIndex = 25
        '
        'TxtOnrAdrs
        '
        Me.TxtOnrAdrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOnrAdrs.Location = New System.Drawing.Point(128, 77)
        Me.TxtOnrAdrs.MaxLength = 75
        Me.TxtOnrAdrs.Name = "TxtOnrAdrs"
        Me.TxtOnrAdrs.Size = New System.Drawing.Size(290, 20)
        Me.TxtOnrAdrs.TabIndex = 3
        '
        'TxtOnrAdrs1
        '
        Me.TxtOnrAdrs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOnrAdrs1.Location = New System.Drawing.Point(129, 100)
        Me.TxtOnrAdrs1.MaxLength = 75
        Me.TxtOnrAdrs1.Name = "TxtOnrAdrs1"
        Me.TxtOnrAdrs1.Size = New System.Drawing.Size(289, 20)
        Me.TxtOnrAdrs1.TabIndex = 4
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(7, 77)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(114, 20)
        Me.Label22.TabIndex = 110
        Me.Label22.Text = "Owner's Address"
        '
        'TxtOnrDesi
        '
        Me.TxtOnrDesi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOnrDesi.Location = New System.Drawing.Point(129, 122)
        Me.TxtOnrDesi.MaxLength = 75
        Me.TxtOnrDesi.Name = "TxtOnrDesi"
        Me.TxtOnrDesi.Size = New System.Drawing.Size(156, 20)
        Me.TxtOnrDesi.TabIndex = 5
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(6, 122)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(122, 20)
        Me.Label26.TabIndex = 110
        Me.Label26.Text = "Owner's Designation"
        '
        'Picbox
        '
        Me.Picbox.BackColor = System.Drawing.Color.Cyan
        Me.Picbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picbox.Enabled = False
        Me.Picbox.Location = New System.Drawing.Point(424, 5)
        Me.Picbox.Name = "Picbox"
        Me.Picbox.Size = New System.Drawing.Size(109, 115)
        Me.Picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picbox.TabIndex = 125
        Me.Picbox.TabStop = False
        Me.Picbox.Visible = False
        '
        'Lnklbl
        '
        Me.Lnklbl.AutoSize = True
        Me.Lnklbl.BackColor = System.Drawing.Color.Transparent
        Me.Lnklbl.Enabled = False
        Me.Lnklbl.Location = New System.Drawing.Point(421, 123)
        Me.Lnklbl.Name = "Lnklbl"
        Me.Lnklbl.Size = New System.Drawing.Size(71, 14)
        Me.Lnklbl.TabIndex = 126
        Me.Lnklbl.TabStop = True
        Me.Lnklbl.Text = "Load Image"
        Me.Lnklbl.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Location = New System.Drawing.Point(6, 419)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(134, 14)
        Me.Label27.TabIndex = 123
        Me.Label27.Text = "Labour %  On Purchase"
        '
        'TxtLbrOnPur
        '
        Me.TxtLbrOnPur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtLbrOnPur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLbrOnPur.Location = New System.Drawing.Point(181, 419)
        Me.TxtLbrOnPur.MaxLength = 50
        Me.TxtLbrOnPur.Name = "TxtLbrOnPur"
        Me.TxtLbrOnPur.Size = New System.Drawing.Size(82, 20)
        Me.TxtLbrOnPur.TabIndex = 26
        Me.TxtLbrOnPur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTDSlmt
        '
        Me.TxtTDSlmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTDSlmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTDSlmt.Location = New System.Drawing.Point(431, 419)
        Me.TxtTDSlmt.MaxLength = 50
        Me.TxtTDSlmt.Name = "TxtTDSlmt"
        Me.TxtTDSlmt.Size = New System.Drawing.Size(110, 20)
        Me.TxtTDSlmt.TabIndex = 28
        Me.TxtTDSlmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtLbrOnSale
        '
        Me.TxtLbrOnSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtLbrOnSale.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLbrOnSale.Location = New System.Drawing.Point(181, 444)
        Me.TxtLbrOnSale.MaxLength = 50
        Me.TxtLbrOnSale.Name = "TxtLbrOnSale"
        Me.TxtLbrOnSale.Size = New System.Drawing.Size(82, 20)
        Me.TxtLbrOnSale.TabIndex = 27
        Me.TxtLbrOnSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(6, 444)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(102, 14)
        Me.Label28.TabIndex = 123
        Me.Label28.Text = "Labour % On Sale"
        '
        'TxtTDSrate
        '
        Me.TxtTDSrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTDSrate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTDSrate.Location = New System.Drawing.Point(460, 444)
        Me.TxtTDSrate.MaxLength = 50
        Me.TxtTDSrate.Name = "TxtTDSrate"
        Me.TxtTDSrate.Size = New System.Drawing.Size(81, 20)
        Me.TxtTDSrate.TabIndex = 29
        Me.TxtTDSrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Location = New System.Drawing.Point(276, 419)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(149, 14)
        Me.Label29.TabIndex = 123
        Me.Label29.Text = "TDS  Limit (WorkContract)"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(276, 444)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 14)
        Me.Label30.TabIndex = 123
        Me.Label30.Text = "TDS Rate"
        '
        'FrmCoGateway
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.BackgroundImage = Global.FinAcct.My.Resources.Resources.smallf_Bgrm
        Me.ClientSize = New System.Drawing.Size(545, 622)
        Me.Controls.Add(Me.Lnklbl)
        Me.Controls.Add(Me.Picbox)
        Me.Controls.Add(Me.Txtesi)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TxtTDSlmt)
        Me.Controls.Add(Me.TxtTDSrate)
        Me.Controls.Add(Me.TxtLbrOnSale)
        Me.Controls.Add(Me.TxtLbrOnPur)
        Me.Controls.Add(Me.Txtpf)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnClos)
        Me.Controls.Add(Me.Cmbxstate)
        Me.Controls.Add(Me.Cmbxcontry)
        Me.Controls.Add(Me.Cmbxcty)
        Me.Controls.Add(Me.txtcologo1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PnlAdmn)
        Me.Controls.Add(Me.DtpkrStrtdt)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPin)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtPhwrk)
        Me.Controls.Add(Me.TxtExtnNo)
        Me.Controls.Add(Me.TxtPhResi)
        Me.Controls.Add(Me.TxtAlPhno)
        Me.Controls.Add(Me.TxtMobNo)
        Me.Controls.Add(Me.TxtFxNo)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TxtWeb)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtOnrDesi)
        Me.Controls.Add(Me.TxtOnrAdrs1)
        Me.Controls.Add(Me.TxtOnrAdrs)
        Me.Controls.Add(Me.TxtCoOnr)
        Me.Controls.Add(Me.TxtPAN)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtVAT)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtCST)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtadrs)
        Me.Controls.Add(Me.TxtAdrs1)
        Me.Controls.Add(Me.TxtAlMobl)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCoGateway"
        Me.Text = "Company Profile (Gateway)"
        Me.PnlAdmn.ResumeLayout(False)
        Me.PnlAdmn.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Picbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub FrmCoGateway_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 0
        Me.Top = 0
        SelIndx = Nothing
        Dim DcrypConame As New EnCryp_DeCryp_String
        CoGateCmd = New SqlCommand("select * from finactcogatemstr", FinActConn)
        Try
            DtaRdr = CoGateCmd.ExecuteReader
            DtaRdr.Read()
            If DtaRdr.HasRows = True Then
                TxtName.Enabled = False
                DtpkrStrtdt.Enabled = False
                Altr_FrmCogate = False
                MsgBox("You have already created a company profile" & Chr(13) & " Created Company Name :-  " & DcrypConame.Decrypt(DtaRdr("coname")))
                DtaRdr.Close()
                CoGateCmd = Nothing
                EdtCompany()
            ElseIf DtaRdr.HasRows = False Then
                DtaRdr.Close()
                CoGateCmd = Nothing
                'CsCcmbxRecrd(Cmbxcty, cmbxState, Cmbxcontry)
                Altr_FrmCogate = True
                TxtName.Enabled = True
                DtpkrStrtdt.Enabled = True
            End If
            DtaRdr.Close()
            CoGateCmd = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Company Profile")
        End Try
        If Altr_FrmCogate = False Then
            ' Me.BtnAddWithValue.Text = "&Alter"
            Me.TxtName.Enabled = False
        Else
            ' Me.BtnAddWithValue.Text = "&Add"
            Me.TxtName.Enabled = True
        End If
        Dim onPaste1 As New TextBoxOnPaste(Me.TxtAlPhno)
        Dim onPaste2 As New TextBoxOnPaste(Me.TxtCST)
        Dim onPaste3 As New TextBoxOnPaste(Me.TxtExtnNo)
        Dim onPaste4 As New TextBoxOnPaste(Me.TxtFxNo)
        Dim onPaste5 As New TextBoxOnPaste(Me.TxtMobNo)
        Dim onPaste6 As New TextBoxOnPaste(Me.TxtPhResi)
        Dim onPaste7 As New TextBoxOnPaste(Me.TxtPhwrk)
        Dim onPaste8 As New TextBoxOnPaste(Me.TxtPin)
        Dim onPaste9 As New TextBoxOnPaste(Me.TxtVAT)
        Dim onPaste10 As New TextBoxOnPaste(Me.TxtAlMobl)
    End Sub

    Private Sub ChekEmpty()
        With TxtName
            If Trim(.Text) = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With

        With TxtAdrs1
            If Trim(.Text) = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Focus()
                Indx = Indx + 1
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With

        With TxtPhwrk
            If Trim(.Text) = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Focus()
                Indx = Indx + 1
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With

        With TxtPin
            If Trim(.Text) = "" Or Len(.Text) < 6 Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Focus()
                Indx = Indx + 1
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With

        With Cmbxcty
            If Trim(.Text) = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Focus()
                Indx = Indx + 1
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
        With Cmbxcontry
            If Trim(.Text) = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Focus()
                Indx = Indx + 1
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
        With Cmbxstate
            If Trim(.Text) = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Focus()
                Indx = Indx + 1
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
        With TxtCoOnr
            If Trim(.Text) = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Focus()
                Indx = Indx + 1
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
        With TxtMobNo
            If Trim(.Text) = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Focus()
                Indx = Indx + 1
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
        With TxtadmnPass
            If Trim(.Text) = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Focus()
                Indx = Indx + 1
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
        With TxtVAT
            If Trim(.Text) <> "" Then
                If Trim(Len(.Text)) < 11 Then
                    .BackColor = Color.LemonChiffon
                    .ForeColor = Color.Black
                    .Focus()
                    Indx = Indx + 1
                Else
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End If
            End If
        End With
        With TxtCST
            If Trim(.Text) <> "" Then
                If Trim(Len(.Text)) < 11 Then
                    .BackColor = Color.LemonChiffon
                    .ForeColor = Color.Black
                    .Focus()
                    Indx = Indx + 1
                Else
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End If
            End If
        End With
        With TxtPAN
            If Trim(.Text) <> "" Then
                If Trim(Len(.Text)) < 10 Then
                    .BackColor = Color.LemonChiffon
                    .ForeColor = Color.Black
                    .Focus()
                    Indx = Indx + 1
                Else
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End If
            End If
        End With
        With txtadmnpass1
            If Trim(.Text) = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Focus()
                Indx = Indx + 1
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
        With TxtEmail
            If Trim(.Text) <> "" Then
                If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                Else
                    .BackColor = Color.LemonChiffon
                    .ForeColor = Color.Black
                    .Focus()
                    Indx = Indx + 1
                End If
            End If
        End With
        With TxtWeb
            If Trim(.Text) <> "" Then
                Searchstring(TxtWeb.Text, "WWW.")
                If OkFormat = False Then
                    Searchstring(TxtWeb.Text, "HTTP://WWW.")
                End If
                If OkFormat = True Then
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                Else
                    .BackColor = Color.LemonChiffon
                    .ForeColor = Color.Black
                    Indx = Indx + 1
                    .Focus()
                    .SelectAll()
                End If
            End If

        End With
        If Trim(Len(TxtadmnPass.Text)) < 8 Then
            TxtadmnPass.Focus()
            MsgBox("Password must have atleast 8 Character long", MsgBoxStyle.Information, "Password Info")
            TxtadmnPass.SelectAll()
            Indx += 1
        End If
        If txtans.Text <> "" Then
            If cmbxHint.Text = "" Then
                cmbxHint.Focus()
                Indx += 1
            End If
        End If

        If cmbxHint.Text <> "" Then
            If txtans.Text = "" Then
                txtans.Focus()
                Indx += 1
            End If

        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim Confrm As String

        If Trim(TxtName.Text) = "" Then
            TxtName.BackColor = Color.LemonChiffon
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Owner's Name")
            TxtName.Focus()

            Exit Sub
        End If
        If Trim(TxtCoOnr.Text) = "" Then
            TxtCoOnr.BackColor = Color.LemonChiffon
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Owner's Name")
            TxtCoOnr.Focus()
            Exit Sub
        End If

        If Trim(TxtAdrs1.Text) = "" Then
            TxtAdrs1.BackColor = Color.LemonChiffon
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Owner's Address")
            TxtAdrs1.Focus()
            Exit Sub
        End If

        If Trim(TxtPhwrk.Text) = "" Then
            TxtPhwrk.BackColor = Color.LemonChiffon
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Phone No.(Works)")
            TxtPhwrk.Focus()
            Exit Sub
        End If


        If Trim(TxtPin.Text) = "" Then
            TxtPin.BackColor = Color.LemonChiffon
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Postal Code")
            TxtPin.Focus()
            Exit Sub
        ElseIf Len(TxtPin.Text) < 6 Then
            TxtPin.BackColor = Color.LemonChiffon
            MsgBox("Postal Code must be atleast 6 character long", MsgBoxStyle.Information, "Postal Code")
            TxtPin.SelectAll()
            TxtPin.Focus()
            Exit Sub
        End If
        If Trim(TxtVAT.Text) <> "" Then
            If Trim(Len(TxtVAT.Text)) < 11 Then
                TxtVAT.BackColor = Color.LemonChiffon
                MsgBox("Vat No. must be atleast 11 character long", MsgBoxStyle.Information, "Vat No.")
                TxtVAT.Focus()
                Exit Sub
            End If
        End If
        If Trim(TxtCST.Text) <> "" Then
            If Trim(Len(TxtCST.Text)) < 11 Then
                TxtCST.BackColor = Color.LemonChiffon
                MsgBox("CST No. must be atleast 11 character long", MsgBoxStyle.Information, "CST No.")
                TxtCST.Focus()
                Exit Sub
            End If
        End If
        If Trim(TxtPAN.Text) <> "" Then
            If Trim(Len(TxtPAN.Text)) < 10 Then
                TxtPAN.BackColor = Color.LemonChiffon
                MsgBox("PAN No. must be atleast 10 digits long", MsgBoxStyle.Information, "PAN No.")
                TxtPAN.Focus()
                Exit Sub
            End If
        End If
        If Trim(Cmbxcty.Text) = "" Then
            Cmbxcty.BackColor = Color.LemonChiffon
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "City")
            Cmbxcty.Focus()
            Exit Sub
        End If

        If Trim(Cmbxcontry.Text) = "" Then
            Cmbxcontry.BackColor = Color.LemonChiffon
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Country")
            Cmbxcontry.Focus()
            Exit Sub
        End If

        If Trim(Cmbxstate.Text) = "" Then
            Cmbxstate.BackColor = Color.LemonChiffon
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "State")
            Cmbxstate.Focus()
            Exit Sub
        End If

        If Trim(TxtMobNo.Text) = "" Then
            TxtMobNo.BackColor = Color.LemonChiffon
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Mobie No.")
            TxtMobNo.Focus()
            Exit Sub
        End If

        If Trim(TxtEmail.Text) <> "" Then
            If InStr(TxtEmail.Text$, "@") > 0 And InStr(TxtEmail.Text$, ".") > 0 Then
                TxtEmail.BackColor = Color.White
                TxtEmail.ForeColor = Color.Black
            Else
                TxtEmail.BackColor = Color.LemonChiffon
                TxtEmail.ForeColor = Color.Black
                MsgBox("Invalid E-Mail Address", MsgBoxStyle.Information, "E-Mail Address")
                TxtEmail.SelectAll()
                TxtEmail.Focus()
                Exit Sub
            End If
        End If
        If Trim(TxtWeb.Text) <> "" Then
            Searchstring(TxtWeb.Text, "WWW.")
            If OkFormat = False Then
                Searchstring(TxtWeb.Text, "HTTP://WWW.")
            End If
            If OkFormat = True Then
                TxtWeb.BackColor = Color.White
                TxtWeb.ForeColor = Color.Black
            Else
                TxtWeb.BackColor = Color.LemonChiffon
                TxtWeb.ForeColor = Color.Black
                MsgBox("Invalid Website", MsgBoxStyle.Information, "Website")
                TxtWeb.SelectAll()
                TxtWeb.Focus()
                Exit Sub
            End If
        End If

        If Trim(TxtadmnPass.Text) = "" Then
            TxtadmnPass.BackColor = Color.LemonChiffon
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Password")
            TxtadmnPass.Focus()
            Exit Sub
        End If
        If Trim(Len(TxtadmnPass.Text)) < 8 Then
            TxtadmnPass.BackColor = Color.LemonChiffon
            MsgBox("Password must be atleast 8 Character long", MsgBoxStyle.Information, "Password Info")
            TxtadmnPass.SelectAll()
            TxtadmnPass.Focus()
            Exit Sub
        End If

        If Trim(txtadmnpass1.Text) = "" Then
            txtadmnpass1.BackColor = Color.LemonChiffon
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Confirm Password")
            txtadmnpass1.Focus()
            Exit Sub
        End If


        If txtans.Text <> "" Then
            If cmbxHint.Text = "" Then
                MsgBox("First Select Hint Question", MsgBoxStyle.Information, "Hint Question")
                cmbxHint.Focus()
                Exit Sub
            End If
        End If

        If cmbxHint.Text <> "" Then
            If txtans.Text = "" Then
                txtans.BackColor = Color.LemonChiffon
                MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Hint Answer")

                txtans.Focus()
                Exit Sub
            End If

        End If

        Confrm = MsgBox("Are you sure to save this record?", MsgBoxStyle.YesNo, "Compay Profile Master")

        If Confrm = vbYes Then
            If Rbindv.Checked = True Then
                Costat = "Indvl"
            Else
                Costat = "CoFrm"
            End If
            ChkCoStatus = Costat
            If Altr_FrmCogate = True Then
                AddnewRecord()
            ElseIf Altr_FrmCogate = False Then
                EditRecord()
            End If
        ElseIf Confrm = vbNo Then
            TxtName.Focus()
        End If
        SelIndx = Nothing
    End Sub

    Private Sub BtnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClos.Click

        Dim delconfrm As String
        delconfrm = MsgBox("Are you sure to Exit?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Exit")
        If delconfrm = vbYes Then
            Me.Close()
        End If

    End Sub

    Private Sub txtadmnpass1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtadmnpass1.Validating
        If Trim(txtadmnpass1.Text) <> Trim(TxtadmnPass.Text) Then
            MsgBox("Invalid password", MsgBoxStyle.Critical, "Password Info")
            TxtadmnPass.Focus()
            TxtadmnPass.SelectAll()
        End If
    End Sub
    Private Sub EdtCompany()
        Dim fet_hint_id As Integer = 0
        Dim adrsId As Integer
        Dim DcrpPass As New EnCryp_DeCryp_String
        CoGateCmd = New SqlCommand("Select * from finactcogatemstr", FinActConn)
        DtaRdr = CoGateCmd.ExecuteReader
        Try
            DtaRdr.Read()
            adrsId = DtaRdr("Coid")
            TxtName.Text = DcrpPass.Decrypt(DtaRdr("coname"))
            'ImgPath = (DtaRdr("cologo"))
            TxtCoOnr.Text = DtaRdr("coonwr")
            TxtOnrAdrs.Text = DtaRdr("coonradrs")
            TxtOnrAdrs1.Text = DtaRdr("coonradrs1")
            TxtOnrDesi.Text = DtaRdr("coonrdesi")
            DtpkrStrtdt.Value = Format((DtaRdr("costrtdt")), "dd/MM/yyyy")
            TxtCST.Text = DtaRdr("cocst")
            TxtPAN.Text = DtaRdr("copan")
            TxtVAT.Text = DtaRdr("covat")
            TxtadmnPass.Text = DcrpPass.Decrypt(DtaRdr("coadmnpass"))
            txtadmnpass1.Text = DcrpPass.Decrypt(DtaRdr("coadmnpass"))
            If Trim(DtaRdr("costatus")) = "Indvl" Then
                Rbindv.Checked = True
            Else
                Rbfirm.Checked = True
            End If
            TxtAdrs1.Text = DtaRdr("adrs1")
            txtadrs.Text = DtaRdr("adrs2")
            Cmbxcty.Text = DtaRdr("adrscty")
            Cmbxstate.Text = DtaRdr("adrsstate")
            Cmbxcontry.Text = DtaRdr("adrscontry")
            TxtPhwrk.Text = DtaRdr("adrsphwork")
            TxtPin.Text = DtaRdr("adrspin")
            TxtPhResi.Text = DtaRdr("adrsphresi")
            TxtExtnNo.Text = DtaRdr("adrsphextn")
            TxtMobNo.Text = DtaRdr("adrsmoble")
            TxtAlPhno.Text = DtaRdr("adrsph2")
            TxtFxNo.Text = DtaRdr("adrsfaxno")
            TxtAlMobl.Text = DtaRdr("adrsmoble2")
            TxtEmail.Text = DtaRdr("adrsemail")
            TxtWeb.Text = DtaRdr("adrsweb")
            fet_hint_id = DtaRdr("cohintques")
            txtans.Text = DtaRdr("cohintans")
            If DtaRdr("coEsiNo") <> "" Then
                Txtesi.Text = DtaRdr("coEsiNo")
            Else
                Txtesi.Text = ""
            End If
            If DtaRdr("coPfNo") <> "" Then
                Txtpf.Text = DtaRdr("coPfNo")
            Else
                Txtpf.Text = ""
            End If
            Me.TxtLbrOnPur.Text = FormatNumber(DtaRdr("COLBRPUR"), 2)
            Me.TxtLbrOnSale.Text = FormatNumber(DtaRdr("COLBRSALE"), 2)
            Me.TxtTDSlmt.Text = FormatNumber(DtaRdr("COTDSLMT"), 2)
            Me.TxtTDSrate.Text = FormatNumber(DtaRdr("COTDSRATE"), 2)
            DtaRdr.Close()
            CoGateCmd = Nothing
            ''If ImgPath <> Trim("None") Then
            ''    PicLogo.Image = Image.FromFile(ImgPath)
            ''End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DtaRdr.Close()
            CoGateCmd = Nothing

        End Try

        cmbxHint.Items.Clear()
        Try
            CoGateCmd = New SqlCommand("select hintques from finactHintQues where hintid='" & (fet_hint_id) & "'", FinActConn)
            DtaRdr = CoGateCmd.ExecuteReader
            While DtaRdr.Read()
                If DtaRdr.HasRows = True Then
                    cmbxHint.Items.Add(DtaRdr(0))

                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CoGateCmd = Nothing
            DtaRdr.Close()
        End Try
        If cmbxHint.Items.Count > 0 Then
            cmbxHint.SelectedIndex = 0
        End If
    End Sub


    Private Sub AddnewRecord()

        Dim CryptPass As New EnCryp_DeCryp_String
        fetch_hint_id()
        Try
            CoGateCmd = New SqlCommand("finact_Cogatemstr_adrsmstr_Insert", FinActConn)
            CoGateCmd.CommandType = CommandType.StoredProcedure
            CoGateCmd.Parameters.AddWithValue("@coname", CryptPass.Encrypt(Trim(TxtName.Text)))
            'CoGateCmd.Parameters.AddWithValue("@cologo", ImagePath)
            CoGateCmd.Parameters.AddWithValue("@coonr", Trim(TxtCoOnr.Text))
            CoGateCmd.Parameters.AddWithValue("@coonradrs", Trim(TxtOnrAdrs.Text))
            CoGateCmd.Parameters.AddWithValue("@coonradrs1", Trim(TxtOnrAdrs1.Text))
            CoGateCmd.Parameters.AddWithValue("@coonrdesi", Trim(TxtOnrDesi.Text))
            CoGateCmd.Parameters.AddWithValue("@costrtdt", (DtpkrStrtdt.Text))
            CoGateCmd.Parameters.AddWithValue("@cocst", Trim(TxtCST.Text))
            CoGateCmd.Parameters.AddWithValue("@copan", Trim(TxtPAN.Text))
            CoGateCmd.Parameters.AddWithValue("@covat", Trim(TxtVAT.Text))
            CoGateCmd.Parameters.AddWithValue("@coadmn", ("Administrator"))
            CoGateCmd.Parameters.AddWithValue("@costatus", Costat)
            CoGateCmd.Parameters.AddWithValue("@copass1", CryptPass.Encrypt(TxtadmnPass.Text))
            CoGateCmd.Parameters.AddWithValue("@coaddt", (Now))
            CoGateCmd.Parameters.AddWithValue("@adrs1", Trim(TxtAdrs1.Text))
            CoGateCmd.Parameters.AddWithValue("@adrs2", Trim(txtadrs.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsstate", Trim(Cmbxstate.Text))
            CoGateCmd.Parameters.AddWithValue("@adrscty", Trim(Cmbxcty.Text))
            CoGateCmd.Parameters.AddWithValue("@adrscontry", Trim(Cmbxcontry.Text))
            CoGateCmd.Parameters.AddWithValue("@adrspin", Trim(TxtPin.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsphwork", Trim(TxtPhwrk.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsphextn", Trim(TxtExtnNo.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsphresi", Trim(TxtPhResi.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsph2", Trim(TxtAlPhno.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsmoble", Trim(TxtMobNo.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsmoble2", Trim(TxtAlMobl.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsfxno", Trim(TxtFxNo.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsemail", Trim(TxtEmail.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsweb", Trim(TxtWeb.Text))
            CoGateCmd.Parameters.AddWithValue("@codefusr", 0)
            CoGateCmd.Parameters.AddWithValue("@corempass", 0)
            CoGateCmd.Parameters.AddWithValue("@Cohintques", hintid)
            CoGateCmd.Parameters.AddWithValue("@Cohintans", Trim(txtans.Text))
            CoGateCmd.Parameters.AddWithValue("@CoEsiNo", Trim(Txtesi.Text))
            CoGateCmd.Parameters.AddWithValue("@CoPfNo", Trim(Txtpf.Text))
            CoGateCmd.Parameters.AddWithValue("@CoSys", Trim(0))
            If Len(Me.TxtLbrOnPur.Text.Trim) = 0 Then Me.TxtLbrOnPur.Text = 0
            If Len(Me.TxtLbrOnSale.Text.Trim) = 0 Then Me.TxtLbrOnSale.Text = 0
            If Len(Me.TxtTDSlmt.Text.Trim) = 0 Then Me.TxtTDSlmt.Text = 0
            If Len(Me.TxtTDSrate.Text.Trim) = 0 Then Me.TxtTDSrate.Text = 0
            CoGateCmd.Parameters.AddWithValue("@CoLBRPUR", CDbl(Me.TxtLbrOnPur.Text))
            CoGateCmd.Parameters.AddWithValue("@CoLBRSALE", CDbl(Me.TxtLbrOnSale.Text))
            CoGateCmd.Parameters.AddWithValue("@CoTDSLMT", CDbl(Me.TxtTDSlmt.Text))
            CoGateCmd.Parameters.AddWithValue("@CoTDSRATE", CDbl(Me.TxtTDSrate.Text))

            If Trim(ImagePath) <> "None" Then
                fso.CopyFile(MySource, ImagePath, True)

            End If
            CoGateCmd.ExecuteNonQuery()
            MsgBox("New Company has been Successfully Created. System is going to restart application.", MsgBoxStyle.Information)
            Application.Restart()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CoGateCmd = Nothing
            Me.Close()
        End Try
    End Sub
    Private Sub EditRecord()

        Dim CrpPass As New EnCryp_DeCryp_String
        fetch_hint_id()
        Try
            CoGateCmd = New SqlCommand("finact_Cogatemstr_adrsmstr_update", FinActConn)
            CoGateCmd.CommandType = CommandType.StoredProcedure
            'CoGateCmd.Parameters.AddWithValue("@coname", CrpPass.Encrypt(Trim(TxtName.Text)))
            'CoGateCmd.Parameters.AddWithValue("@cologo", ImagePath)
            CoGateCmd.Parameters.AddWithValue("@coonr", Trim(TxtCoOnr.Text))
            CoGateCmd.Parameters.AddWithValue("@coonradrs", Trim(TxtOnrAdrs.Text))
            CoGateCmd.Parameters.AddWithValue("@coonradrs1", Trim(TxtOnrAdrs1.Text))
            CoGateCmd.Parameters.AddWithValue("@coonrdesi", Trim(TxtOnrDesi.Text))
            CoGateCmd.Parameters.AddWithValue("@costrtdt", (DtpkrStrtdt.Text))
            CoGateCmd.Parameters.AddWithValue("@cocst", Trim(TxtCST.Text))
            CoGateCmd.Parameters.AddWithValue("@copan", Trim(TxtPAN.Text))
            CoGateCmd.Parameters.AddWithValue("@covat", Trim(TxtVAT.Text))
            CoGateCmd.Parameters.AddWithValue("@coadmn", ("Administrator"))
            CoGateCmd.Parameters.AddWithValue("@costatus", Costat)
            CoGateCmd.Parameters.AddWithValue("@copass1", CrpPass.Encrypt(TxtadmnPass.Text))
            'CoGateCmd.Parameters.AddWithValue("@coaddt", (Now))
            CoGateCmd.Parameters.AddWithValue("@adrs1", Trim(TxtAdrs1.Text))
            CoGateCmd.Parameters.AddWithValue("@adrs2", Trim(txtadrs.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsstate", Trim(Cmbxstate.Text))
            CoGateCmd.Parameters.AddWithValue("@adrscty", Trim(Cmbxcty.Text))
            CoGateCmd.Parameters.AddWithValue("@adrscontry", Trim(Cmbxcontry.Text))
            CoGateCmd.Parameters.AddWithValue("@adrspin", Trim(TxtPin.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsphwork", Trim(TxtPhwrk.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsphextn", Trim(TxtExtnNo.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsphresi", Trim(TxtPhResi.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsph2", Trim(TxtAlPhno.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsmoble", Trim(TxtMobNo.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsmoble2", Trim(TxtAlMobl.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsfxno", Trim(TxtFxNo.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsemail", Trim(TxtEmail.Text))
            CoGateCmd.Parameters.AddWithValue("@adrsweb", Trim(TxtWeb.Text))
            CoGateCmd.Parameters.AddWithValue("@Edtdt", (Now))
            CoGateCmd.Parameters.AddWithValue("@Edtusr", (Current_UsrId))
            CoGateCmd.Parameters.AddWithValue("@cohintques", hintid)
            CoGateCmd.Parameters.AddWithValue("@cohintans", Trim(txtans.Text))
            CoGateCmd.Parameters.AddWithValue("@CoEsiNo", Trim(Txtesi.Text))
            CoGateCmd.Parameters.AddWithValue("@CoPfNo", Trim(Txtpf.Text))
            CoGateCmd.Parameters.AddWithValue("@CoSys", Trim(0))
            If Len(Me.TxtLbrOnPur.Text.Trim) = 0 Then Me.TxtLbrOnPur.Text = 0
            If Len(Me.TxtLbrOnSale.Text.Trim) = 0 Then Me.TxtLbrOnSale.Text = 0
            If Len(Me.TxtTDSlmt.Text.Trim) = 0 Then Me.TxtTDSlmt.Text = 0
            If Len(Me.TxtTDSrate.Text.Trim) = 0 Then Me.TxtTDSrate.Text = 0
            CoGateCmd.Parameters.AddWithValue("@CoLBRPUR", CDbl(Me.TxtLbrOnPur.Text))
            CoGateCmd.Parameters.AddWithValue("@CoLBRSALE", CDbl(Me.TxtLbrOnSale.Text))
            CoGateCmd.Parameters.AddWithValue("@CoTDSLMT", CDbl(Me.TxtTDSlmt.Text))
            CoGateCmd.Parameters.AddWithValue("@CoTDSRATE", CDbl(Me.TxtTDSrate.Text))

            'If ImagePath <> "None" Then
            '    fso.CopyFile(MySource, ImagePath, True)
            'End If

            CoGateCmd.ExecuteNonQuery()
            MsgBox("Record has been Successfully saved", MsgBoxStyle.Information)
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CoGateCmd = Nothing
        End Try
    End Sub
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCST.KeyPress, TxtVAT.KeyPress, TxtPin.KeyPress, TxtPhResi.KeyPress, TxtPhwrk.KeyPress, TxtMobNo.KeyPress, TxtAlPhno.KeyPress, TxtAlMobl.KeyPress, TxtExtnNo.KeyPress, TxtFxNo.KeyPress

        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            'If adding the character to the end of the current TextBox value results in
            ' a numeric value, go on. Otherwise, set e.Handled to True, and don't let
            ' the character to be added.
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)


        ElseIf e.KeyChar = "." Then
            'For the decimal character (.) we need a different rule:
            'If adding a decimal to the end of the current value of the TextBox results
            ' in a numeric value, it can be added. If not, this means we already have a
            ' decimal in the TextBox value, so we only allow the new decimal to sit in
            ' when it is overwriting the previous decimal.
            If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                e.Handled = True
            End If
        ElseIf e.KeyChar = "-" Then
            'A negative sign is prevented if the "-" key is pressed in any location
            ' other than the begining of the number, or if the number already has a
            ' negative sign
            If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                e.Handled = True
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            'IsControl is checked, because without that, keys like BackSpace couldn't
            ' work correctly.
            e.Handled = True
        End If
    End Sub



    Dim Clrtxt As Control
    Private Sub Clr_Zero()
        If TxtCST.Text = 0 Then
            TxtCST.Text = ""
        End If
        If TxtPAN.Text = 0 Then
            TxtPAN.Text = ""
        End If
        If TxtVAT.Text = 0 Then
            TxtVAT.Text = ""
        End If
        If TxtEmail.Text = CStr(0) Then
            TxtEmail.Text = ""
        End If
        If TxtWeb.Text = CStr(0) Then
            TxtWeb.Text = ""
        End If

    End Sub
    Private Sub txtadmnpass1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtadmnpass1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbxHint.Focus()

        End If
    End Sub
    Private Sub Presesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxcontry.KeyDown, Cmbxcty.KeyDown, Cmbxstate.KeyDown, DtpkrStrtdt.KeyDown, Label1.KeyDown, Label10.KeyDown, Label11.KeyDown, Label12.KeyDown, Label13.KeyDown, Label14.KeyDown, Label15.KeyDown, Label16.KeyDown, Label17.KeyDown, Label19.KeyDown, Label2.KeyDown, Label20.KeyDown, Label21.KeyDown, Label23.KeyDown, Label24.KeyDown, Label25.KeyDown, Label3.KeyDown, Label4.KeyDown, Label6.KeyDown, Label7.KeyDown, Label8.KeyDown, Label9.KeyDown, PnlAdmn.KeyDown, TxtadmnPass.KeyDown, txtadmnpass1.KeyDown, TxtAdrs1.KeyDown, TxtAlMobl.KeyDown, TxtAlPhno.KeyDown, txtcologo1.KeyDown, TxtCoOnr.KeyDown, TxtCST.KeyDown, TxtEmail.KeyDown, TxtExtnNo.KeyDown, TxtFxNo.KeyDown, TxtMobNo.KeyDown, TxtName.KeyDown, TxtPAN.KeyDown, TxtPhResi.KeyDown, TxtPhwrk.KeyDown, TxtPhwrk.KeyDown, TxtVAT.KeyDown, TxtWeb.KeyDown, txtadrs.KeyDown, Label22.KeyDown, TxtOnrAdrs1.KeyDown, TxtOnrAdrs.KeyDown, TxtOnrDesi.KeyDown, Label26.KeyDown
        Dim delconfrm As String
        If e.KeyCode = Keys.Escape Then
            delconfrm = MsgBox("Are you sure to Exit ", MsgBoxStyle.YesNo, "Exit")
            If delconfrm = vbYes Then
                Me.Close()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If TxtEmail.Text <> "" And TxtEmail.TextLength > 1 And Not (TxtEmail.Text.Contains("@") And TxtEmail.Text.Contains(".")) And TxtEmail.Text.EndsWith(".") Or TxtEmail.Text.EndsWith("@") Then
                MsgBox("Invalid Email id")
                TxtEmail.Focus()
                TxtEmail.SelectAll()
            End If
            If TxtWeb.Text <> "" Then
                count = 0
                If TxtWeb.Text.StartsWith("WWW.") = True Then
                    validation()
                Else
                    MsgBox("Invalid Website", MsgBoxStyle.Information, "Invalid")
                    TxtWeb.Focus()
                    TxtWeb.SelectAll()
                End If
            End If
        End If
    End Sub

    Private Sub validation()
        Dim str As String = ""
        Dim lenth As Integer = 0
        Dim lenth1 As Integer = 0
        Dim a As Integer = 0
        Dim diff As Integer = 0
        Dim i As Integer
        str = TxtWeb.Text
        i = 4
        While i <= str.Length - 1
            If str.Chars(i) = "." Then
                If i = 4 Or i = 5 Or i = 6 Then
                    MsgBox("Invalid Website", MsgBoxStyle.Information, "Invalid")
                    TxtWeb.Focus()
                    TxtWeb.SelectAll()
                    Exit While
                    Exit Sub
                End If
                If count = 0 Then 'fetch 1 .
                    a = i + 1
                    count += 1
                    val_flag = True
                End If
                If count > 0 And val_flag = False Then
                    MsgBox("Enter valid Website", MsgBoxStyle.Information, "Invalid Website")
                    TxtWeb.Focus()
                    TxtWeb.SelectAll()
                    Exit While
                    Exit Sub
                End If
            End If
            i += 1
            val_flag = False
        End While
        If count = 0 Then
            MsgBox("Enter valid website", MsgBoxStyle.Information, "Invalid Website")
            TxtWeb.Focus()
            Exit Sub
        End If
        If count <> 0 Then
            If TxtWeb.Text.EndsWith(".") Then
                MsgBox("Enter valid website", MsgBoxStyle.Information, "Invalid Website")
                TxtWeb.Focus()
                lenth = TxtWeb.Text.Length
                Exit Sub
            End If
        End If
        lenth1 = TxtWeb.Text.Length
        diff = 0
        While a < lenth1
            diff += 1
            a += 1
        End While
        If diff <> 3 Then
            MsgBox("enter valid domain")
            TxtWeb.Focus()
            TxtWeb.SelectAll()
        End If
    End Sub

    Private Sub cmbxHint_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxHint.GotFocus
        Dim edttxt As String
        edttxt = Trim(cmbxHint.Text).ToString

        cmbxHint.Items.Clear()
        fetch_hint_ques()
        If cmbxHint.Items.Count > 0 Then
            cmbxHint.SelectedIndex = SelIndx
            cmbxHint.DroppedDown = True
            cmbxHint.FindStringExact(edttxt.ToString)

        End If

    End Sub
    Private Sub fetch_hint_ques()
        Dim idx As Integer = 0
        Try
            CoGateCmd = New SqlCommand("select hintques from finactHintQues", FinActConn)
            DtaRdr = CoGateCmd.ExecuteReader
            While DtaRdr.Read()
                If DtaRdr.HasRows = True Then
                    cmbxHint.Items.Add(DtaRdr(0))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CoGateCmd = Nothing
            DtaRdr.Close()
        End Try

    End Sub

    Private Sub cmbxHint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxHint.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtans.Focus()
        End If
        Dim delconfrm As String
        If e.KeyCode = Keys.Escape Then
            delconfrm = MsgBox("Are you sure to Exit without save", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Exit")
            If delconfrm = vbYes Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtans.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtans.Text <> "" Then
                BtnSave.Focus()
            Else
                txtans.Focus()
            End If
        End If
    End Sub

    Private Sub cmbxHint_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxHint.Leave
        cmbxHint.DroppedDown = False
        If cmbxHint.Text <> "" Then
            fetch_hint_id()
        End If
        If cmbxHint.Items.Count > 0 Then
            SelIndx = cmbxHint.SelectedIndex
        End If
    End Sub

    Private Sub fetch_hint_id()
        hintid = 0
        Try
            CoGateCmd = New SqlCommand("select hintid from finactHintQues where hintques='" & cmbxHint.Text & "'", FinActConn)
            DtaRdr = CoGateCmd.ExecuteReader
            DtaRdr.Read()
            If DtaRdr.HasRows = True Then
                hintid = DtaRdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CoGateCmd = Nothing
            DtaRdr.Close()
        End Try
    End Sub

    Private Sub textonly_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmbxcty.KeyPress, Cmbxcontry.KeyPress, Cmbxstate.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
                  Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
                  And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
                  Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'Allowed space
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        ' Allowed backspace
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If

    End Sub

    Private Sub Txtpf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTDSrate.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(13)
                If PnlAdmn.Enabled = True Then
                    TxtadmnPass.Focus()
                Else
                    BtnSave.Focus()
                End If

            Case Microsoft.VisualBasic.ChrW(9)
                If PnlAdmn.Enabled = True Then
                    TxtadmnPass.Focus()
                Else
                    BtnSave.Focus()

                End If
        End Select
    End Sub

    Private Sub Lnklbl_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Lnklbl.LinkClicked
        Dim ImageName As String
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            MySource = OpenFileDialog1.FileName
            ImageName = OpenFileDialog1.FileName
            Picbox.Image = Image.FromFile(MySource)
            ImagePath = ImageName 'Application.StartupPath & "\images\" & ImageName
        End If
    End Sub

    Private Sub BtnQues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQues.Click
        Dim frmQ As New FrmHintQues
        frmQ.ShowInTaskbar = False
        frmQ.ShowDialog()
    End Sub

    Private Sub TxtLbrOnPur_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLbrOnPur.Leave, TxtLbrOnSale.Leave, TxtTDSlmt.Leave, TxtTDSrate.Leave
        Try
            Dim xTxt As TextBox = CType(sender, TextBox)
            If xChk_numericValidation(xTxt) = False Then
                xTxt.Text = FormatNumber(xTxt.Text, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub

 
    Private Sub Txtpf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtpf.TextChanged

    End Sub
End Class

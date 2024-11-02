

Imports System.Data
Imports System.Data.SqlClient


Public Class FrmActMstr
    Inherits System.Windows.Forms.Form

    Dim Ctyid As Integer
    Dim Actgrpcmd As SqlCommand
    Dim Findcmd As SqlCommand
    Dim FindRdr As SqlDataReader

    Dim ActOpnCmd As SqlCommand
    Dim ActOpnRdr As SqlDataReader

    Dim Actrdr As SqlDataReader
    Dim SelReccmd As SqlCommand
    Dim SelRecrdr As SqlDataReader
    Dim Grupnamcmd As SqlCommand
    Dim Grupnamrdr As SqlDataReader
    Dim Adrscmd As SqlCommand
    Dim Adrsrdr As SqlDataReader
    Dim Citycmd As SqlCommand
    Dim Cityrdr As SqlDataReader
    Dim lblpan As New Label


    Dim Splrlst As ListViewItem
    Dim AddEdit_Flag As Boolean
    Dim Splid As Integer
    Dim x As Integer = 1
    Dim y As Integer = 0
    Dim BalType As String = ""
    Dim OpnDr As Double = 0.0
    Dim OpnCr As Double = 0.0
    Dim OpnDrCr As Double = 0.0
    Dim OpnBalType As String = ""
    Dim SharRatio As Double = 0.0
    Dim CoStatus As String = ""
    Dim CurrRatio As Double = 0.0
    Dim Alowfinal As Boolean = True

    'Dim Onpaste1 As New TextBoxOnPaste(Me.Txtactname)
    Friend WithEvents CmbxCty As System.Windows.Forms.ComboBox
    Friend WithEvents Lblstate As System.Windows.Forms.Label
    Friend WithEvents Lblcontry As System.Windows.Forms.Label
    Friend WithEvents state As System.Windows.Forms.Label
    Friend WithEvents contry As System.Windows.Forms.Label
    Friend WithEvents NumUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents DtpkrEffct As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CmbxCost As System.Windows.Forms.ComboBox
    Friend WithEvents RBCr As System.Windows.Forms.RadioButton
    Friend WithEvents RBdr As System.Windows.Forms.RadioButton
    Friend WithEvents Txtopnblnce As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblOpnbal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtperofcal As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CmbxFbt As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxVat As System.Windows.Forms.ComboBox
    Friend WithEvents lstvew1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblPercent As System.Windows.Forms.Label
    Friend WithEvents Lblshare As System.Windows.Forms.Label
    Friend WithEvents txtprofit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lblpcnt As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Tlp1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CmbxUndrGrup As System.Windows.Forms.ComboBox
    Friend WithEvents Txtactname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbxActtype As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnUg As System.Windows.Forms.Button
    Friend WithEvents Tlp2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Tlp3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Tlp4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Txtsetlmt As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CmbxInt As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Txtmail As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Txtmob As System.Windows.Forms.TextBox
    Friend WithEvents Txtsite As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Btncty As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tlp4a As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Nuddays As System.Windows.Forms.NumericUpDown
    Friend WithEvents Txtdis As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents NudNetday As System.Windows.Forms.NumericUpDown
    Friend WithEvents CmbxIncenType As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtIncenTar As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TxtIncenval As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Tlp4b As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Cmbxagent As System.Windows.Forms.ComboBox
    Friend WithEvents BtnAgent As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents BtnCont As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents BtnDeladrs As System.Windows.Forms.Button
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Txtcontperson As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Btnitematch As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Txtsurfix As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents btnsrfix As System.Windows.Forms.Button
    Friend WithEvents TtxtSaleAgnt As System.Windows.Forms.TextBox
    Friend WithEvents lblagntadrs As System.Windows.Forms.Label
    Friend WithEvents CmbxVatCst As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents BtnVatCst As System.Windows.Forms.Button
    Friend WithEvents CmbxPrceLst As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents LblEdt As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents CmbxCarri As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCarri As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Cmbxsertax As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxInvtVal As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label

    Dim indxActmstr As Integer



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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Txtadrs As System.Windows.Forms.TextBox
    Friend WithEvents txtadrsarea As System.Windows.Forms.TextBox
    Friend WithEvents txtadrsland As System.Windows.Forms.TextBox
    Friend WithEvents txtPin As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtPan As System.Windows.Forms.TextBox
    Friend WithEvents txtVat As System.Windows.Forms.TextBox
    Friend WithEvents txtPhwork As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtExcise As System.Windows.Forms.TextBox
    Friend WithEvents Btndel As System.Windows.Forms.Button
    Friend WithEvents Btnfnd As System.Windows.Forms.Button
    Friend WithEvents Btnnew As System.Windows.Forms.Button
    Friend WithEvents Btnclos As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmActMstr))
        Me.contry = New System.Windows.Forms.Label
        Me.state = New System.Windows.Forms.Label
        Me.Lblstate = New System.Windows.Forms.Label
        Me.Lblcontry = New System.Windows.Forms.Label
        Me.CmbxCty = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Txtadrs = New System.Windows.Forms.TextBox
        Me.txtadrsarea = New System.Windows.Forms.TextBox
        Me.txtadrsland = New System.Windows.Forms.TextBox
        Me.txtPin = New System.Windows.Forms.TextBox
        Me.txtPhwork = New System.Windows.Forms.TextBox
        Me.txtPan = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtVat = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtExcise = New System.Windows.Forms.TextBox
        Me.Btndel = New System.Windows.Forms.Button
        Me.Btnfnd = New System.Windows.Forms.Button
        Me.Btnnew = New System.Windows.Forms.Button
        Me.Btnclos = New System.Windows.Forms.Button
        Me.txtperofcal = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.CmbxFbt = New System.Windows.Forms.ComboBox
        Me.CmbxVat = New System.Windows.Forms.ComboBox
        Me.NumUD = New System.Windows.Forms.NumericUpDown
        Me.DtpkrEffct = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.CmbxCost = New System.Windows.Forms.ComboBox
        Me.Lblpcnt = New System.Windows.Forms.Label
        Me.txtprofit = New System.Windows.Forms.NumericUpDown
        Me.LblPercent = New System.Windows.Forms.Label
        Me.Lblshare = New System.Windows.Forms.Label
        Me.RBCr = New System.Windows.Forms.RadioButton
        Me.RBdr = New System.Windows.Forms.RadioButton
        Me.Txtopnblnce = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblOpnbal = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lstvew1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Tlp4b = New System.Windows.Forms.TableLayoutPanel
        Me.Tlp4a = New System.Windows.Forms.TableLayoutPanel
        Me.Tlp2 = New System.Windows.Forms.TableLayoutPanel
        Me.Tlp4 = New System.Windows.Forms.TableLayoutPanel
        Me.Label31 = New System.Windows.Forms.Label
        Me.Txtmail = New System.Windows.Forms.TextBox
        Me.Txtsetlmt = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Txtsite = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Txtmob = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Btncty = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Tlp1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnUg = New System.Windows.Forms.Button
        Me.CmbxUndrGrup = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbxActtype = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.btnsrfix = New System.Windows.Forms.Button
        Me.Txtsurfix = New System.Windows.Forms.ComboBox
        Me.Txtactname = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.lblagntadrs = New System.Windows.Forms.Label
        Me.TtxtSaleAgnt = New System.Windows.Forms.TextBox
        Me.Tlp3 = New System.Windows.Forms.TableLayoutPanel
        Me.LblEdt = New System.Windows.Forms.Label
        Me.CmbxPrceLst = New System.Windows.Forms.ComboBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Nuddays = New System.Windows.Forms.NumericUpDown
        Me.NudNetday = New System.Windows.Forms.NumericUpDown
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtIncenTar = New System.Windows.Forms.TextBox
        Me.CmbxIncenType = New System.Windows.Forms.ComboBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.TxtIncenval = New System.Windows.Forms.TextBox
        Me.BtnAgent = New System.Windows.Forms.Button
        Me.Label36 = New System.Windows.Forms.Label
        Me.Cmbxagent = New System.Windows.Forms.ComboBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.Txtcontperson = New System.Windows.Forms.TextBox
        Me.BtnCont = New System.Windows.Forms.Button
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.BtnDeladrs = New System.Windows.Forms.Button
        Me.Btnitematch = New System.Windows.Forms.Button
        Me.Label41 = New System.Windows.Forms.Label
        Me.CmbxVatCst = New System.Windows.Forms.ComboBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.BtnVatCst = New System.Windows.Forms.Button
        Me.Label44 = New System.Windows.Forms.Label
        Me.CmbxCarri = New System.Windows.Forms.ComboBox
        Me.BtnCarri = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Txtdis = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.CmbxInt = New System.Windows.Forms.ComboBox
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label46 = New System.Windows.Forms.Label
        Me.Cmbxsertax = New System.Windows.Forms.ComboBox
        Me.CmbxInvtVal = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.NumUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtprofit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Tlp1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Tlp3.SuspendLayout()
        CType(Me.Nuddays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudNetday, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'contry
        '
        Me.contry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.contry.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contry.ForeColor = System.Drawing.SystemColors.ControlText
        Me.contry.Location = New System.Drawing.Point(234, 226)
        Me.contry.Name = "contry"
        Me.contry.Size = New System.Drawing.Size(203, 25)
        Me.contry.TabIndex = 34
        Me.contry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'state
        '
        Me.state.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.state.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.state.ForeColor = System.Drawing.SystemColors.ControlText
        Me.state.Location = New System.Drawing.Point(234, 200)
        Me.state.Name = "state"
        Me.state.Size = New System.Drawing.Size(203, 25)
        Me.state.TabIndex = 33
        Me.state.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lblstate
        '
        Me.Lblstate.BackColor = System.Drawing.Color.Transparent
        Me.Lblstate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblstate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lblstate.Location = New System.Drawing.Point(4, 200)
        Me.Lblstate.Name = "Lblstate"
        Me.Lblstate.Size = New System.Drawing.Size(64, 16)
        Me.Lblstate.TabIndex = 14
        Me.Lblstate.Text = "State :-"
        '
        'Lblcontry
        '
        Me.Lblcontry.BackColor = System.Drawing.Color.Transparent
        Me.Lblcontry.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblcontry.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lblcontry.Location = New System.Drawing.Point(4, 226)
        Me.Lblcontry.Name = "Lblcontry"
        Me.Lblcontry.Size = New System.Drawing.Size(88, 16)
        Me.Lblcontry.TabIndex = 13
        Me.Lblcontry.Text = "Country :-"
        '
        'CmbxCty
        '
        Me.CmbxCty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxCty.Location = New System.Drawing.Point(1, 1)
        Me.CmbxCty.Name = "CmbxCty"
        Me.CmbxCty.Size = New System.Drawing.Size(196, 22)
        Me.CmbxCty.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(4, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 16)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Address :-"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(4, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 24)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Area :-"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(4, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 23)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Land Mark :-"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(4, 145)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 16)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "City :-"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(4, 174)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Pin No.  :-"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(4, 252)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 16)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Phone No.  :-"
        '
        'Txtadrs
        '
        Me.Txtadrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtadrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtadrs.Location = New System.Drawing.Point(234, 70)
        Me.Txtadrs.MaxLength = 30
        Me.Txtadrs.Name = "Txtadrs"
        Me.Txtadrs.Size = New System.Drawing.Size(325, 21)
        Me.Txtadrs.TabIndex = 2
        '
        'txtadrsarea
        '
        Me.txtadrsarea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtadrsarea.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadrsarea.Location = New System.Drawing.Point(234, 96)
        Me.txtadrsarea.MaxLength = 30
        Me.txtadrsarea.Name = "txtadrsarea"
        Me.txtadrsarea.Size = New System.Drawing.Size(325, 21)
        Me.txtadrsarea.TabIndex = 3
        '
        'txtadrsland
        '
        Me.txtadrsland.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtadrsland.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadrsland.Location = New System.Drawing.Point(234, 122)
        Me.txtadrsland.MaxLength = 30
        Me.txtadrsland.Name = "txtadrsland"
        Me.txtadrsland.Size = New System.Drawing.Size(325, 21)
        Me.txtadrsland.TabIndex = 4
        '
        'txtPin
        '
        Me.txtPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPin.Location = New System.Drawing.Point(234, 177)
        Me.txtPin.MaxLength = 6
        Me.txtPin.Name = "txtPin"
        Me.txtPin.Size = New System.Drawing.Size(124, 21)
        Me.txtPin.TabIndex = 6
        '
        'txtPhwork
        '
        Me.txtPhwork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhwork.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhwork.Location = New System.Drawing.Point(234, 255)
        Me.txtPhwork.MaxLength = 26
        Me.txtPhwork.Name = "txtPhwork"
        Me.txtPhwork.Size = New System.Drawing.Size(325, 21)
        Me.txtPhwork.TabIndex = 7
        '
        'txtPan
        '
        Me.txtPan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPan.Location = New System.Drawing.Point(439, 94)
        Me.txtPan.MaxLength = 11
        Me.txtPan.Name = "txtPan"
        Me.txtPan.Size = New System.Drawing.Size(120, 22)
        Me.txtPan.TabIndex = 21
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(307, 91)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(123, 22)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "PAN /IT No."
        '
        'txtVat
        '
        Me.txtVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVat.Location = New System.Drawing.Point(439, 64)
        Me.txtVat.MaxLength = 11
        Me.txtVat.Name = "txtVat"
        Me.txtVat.Size = New System.Drawing.Size(120, 22)
        Me.txtVat.TabIndex = 19
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(4, 91)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(71, 20)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Excise No."
        '
        'txtExcise
        '
        Me.txtExcise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExcise.Location = New System.Drawing.Point(130, 94)
        Me.txtExcise.MaxLength = 11
        Me.txtExcise.Name = "txtExcise"
        Me.txtExcise.Size = New System.Drawing.Size(152, 22)
        Me.txtExcise.TabIndex = 20
        '
        'Btndel
        '
        Me.Btndel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btndel.BackColor = System.Drawing.Color.SteelBlue
        Me.Btndel.BackgroundImage = CType(resources.GetObject("Btndel.BackgroundImage"), System.Drawing.Image)
        Me.Btndel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btndel.FlatAppearance.BorderSize = 0
        Me.Btndel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btndel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btndel.ForeColor = System.Drawing.Color.Navy
        Me.Btndel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btndel.Location = New System.Drawing.Point(340, 18)
        Me.Btndel.Name = "Btndel"
        Me.Btndel.Size = New System.Drawing.Size(125, 33)
        Me.Btndel.TabIndex = 36
        Me.Btndel.Text = "&Delete"
        Me.Btndel.UseVisualStyleBackColor = False
        Me.Btndel.Visible = False
        '
        'Btnfnd
        '
        Me.Btnfnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btnfnd.BackColor = System.Drawing.Color.SteelBlue
        Me.Btnfnd.BackgroundImage = CType(resources.GetObject("Btnfnd.BackgroundImage"), System.Drawing.Image)
        Me.Btnfnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnfnd.FlatAppearance.BorderSize = 0
        Me.Btnfnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Btnfnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnfnd.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnfnd.ForeColor = System.Drawing.Color.Navy
        Me.Btnfnd.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btnfnd.Location = New System.Drawing.Point(175, 18)
        Me.Btnfnd.Name = "Btnfnd"
        Me.Btnfnd.Size = New System.Drawing.Size(125, 33)
        Me.Btnfnd.TabIndex = 35
        Me.Btnfnd.Text = "&Find"
        Me.Btnfnd.UseVisualStyleBackColor = False
        Me.Btnfnd.Visible = False
        '
        'Btnnew
        '
        Me.Btnnew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btnnew.BackColor = System.Drawing.Color.SteelBlue
        Me.Btnnew.BackgroundImage = CType(resources.GetObject("Btnnew.BackgroundImage"), System.Drawing.Image)
        Me.Btnnew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnnew.FlatAppearance.BorderSize = 0
        Me.Btnnew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnnew.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnnew.ForeColor = System.Drawing.Color.Navy
        Me.Btnnew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btnnew.Location = New System.Drawing.Point(10, 18)
        Me.Btnnew.Name = "Btnnew"
        Me.Btnnew.Size = New System.Drawing.Size(125, 33)
        Me.Btnnew.TabIndex = 34
        Me.Btnnew.Text = "&New"
        Me.Btnnew.UseVisualStyleBackColor = False
        Me.Btnnew.Visible = False
        '
        'Btnclos
        '
        Me.Btnclos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btnclos.BackColor = System.Drawing.Color.SteelBlue
        Me.Btnclos.BackgroundImage = CType(resources.GetObject("Btnclos.BackgroundImage"), System.Drawing.Image)
        Me.Btnclos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnclos.FlatAppearance.BorderSize = 0
        Me.Btnclos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Btnclos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnclos.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnclos.ForeColor = System.Drawing.Color.Navy
        Me.Btnclos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btnclos.Location = New System.Drawing.Point(505, 18)
        Me.Btnclos.Name = "Btnclos"
        Me.Btnclos.Size = New System.Drawing.Size(125, 33)
        Me.Btnclos.TabIndex = 37
        Me.Btnclos.Text = "&Close"
        Me.Btnclos.UseVisualStyleBackColor = False
        '
        'txtperofcal
        '
        Me.txtperofcal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtperofcal.Enabled = False
        Me.txtperofcal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtperofcal.Location = New System.Drawing.Point(439, 4)
        Me.txtperofcal.MaxLength = 6
        Me.txtperofcal.Name = "txtperofcal"
        Me.txtperofcal.Size = New System.Drawing.Size(120, 21)
        Me.txtperofcal.TabIndex = 13
        Me.txtperofcal.Text = "0.000"
        Me.txtperofcal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(307, 1)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(125, 22)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "Percentage  of Interest "
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(4, 61)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(119, 28)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "IS A REGD. DEALER?"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Enabled = False
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(66, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(10, 22)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "FBT App. "
        Me.Label20.Visible = False
        '
        'CmbxFbt
        '
        Me.CmbxFbt.BackColor = System.Drawing.Color.White
        Me.CmbxFbt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxFbt.Enabled = False
        Me.CmbxFbt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxFbt.ForeColor = System.Drawing.Color.Navy
        Me.CmbxFbt.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxFbt.Location = New System.Drawing.Point(47, 0)
        Me.CmbxFbt.Name = "CmbxFbt"
        Me.CmbxFbt.Size = New System.Drawing.Size(10, 23)
        Me.CmbxFbt.TabIndex = 15
        Me.CmbxFbt.Visible = False
        '
        'CmbxVat
        '
        Me.CmbxVat.BackColor = System.Drawing.Color.White
        Me.CmbxVat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxVat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxVat.ForeColor = System.Drawing.Color.Navy
        Me.CmbxVat.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxVat.Location = New System.Drawing.Point(130, 64)
        Me.CmbxVat.Name = "CmbxVat"
        Me.CmbxVat.Size = New System.Drawing.Size(77, 23)
        Me.CmbxVat.TabIndex = 18
        '
        'NumUD
        '
        Me.NumUD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumUD.Location = New System.Drawing.Point(126, 1)
        Me.NumUD.Name = "NumUD"
        Me.NumUD.Size = New System.Drawing.Size(77, 21)
        Me.NumUD.TabIndex = 14
        '
        'DtpkrEffct
        '
        Me.DtpkrEffct.CalendarForeColor = System.Drawing.SystemColors.WindowText
        Me.DtpkrEffct.CalendarMonthBackground = System.Drawing.SystemColors.Menu
        Me.DtpkrEffct.CalendarTitleForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.DtpkrEffct.CalendarTrailingForeColor = System.Drawing.SystemColors.HotTrack
        Me.DtpkrEffct.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrEffct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpkrEffct.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrEffct.Location = New System.Drawing.Point(234, 4)
        Me.DtpkrEffct.Name = "DtpkrEffct"
        Me.DtpkrEffct.Size = New System.Drawing.Size(96, 20)
        Me.DtpkrEffct.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(304, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 22)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Inv. Value Affected "
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(307, 211)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(125, 20)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Cost Centre "
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(4, 1)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(143, 37)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Effective Date for Reconciliation ?"
        '
        'CmbxCost
        '
        Me.CmbxCost.BackColor = System.Drawing.Color.White
        Me.CmbxCost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCost.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxCost.ForeColor = System.Drawing.Color.Navy
        Me.CmbxCost.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxCost.Location = New System.Drawing.Point(439, 214)
        Me.CmbxCost.Name = "CmbxCost"
        Me.CmbxCost.Size = New System.Drawing.Size(77, 23)
        Me.CmbxCost.TabIndex = 29
        '
        'Lblpcnt
        '
        Me.Lblpcnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblpcnt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblpcnt.ForeColor = System.Drawing.Color.Black
        Me.Lblpcnt.Location = New System.Drawing.Point(139, 3)
        Me.Lblpcnt.Name = "Lblpcnt"
        Me.Lblpcnt.Size = New System.Drawing.Size(43, 20)
        Me.Lblpcnt.TabIndex = 27
        Me.Lblpcnt.Text = "[ % ]"
        '
        'txtprofit
        '
        Me.txtprofit.Location = New System.Drawing.Point(4, 3)
        Me.txtprofit.Maximum = New Decimal(New Integer() {101, 0, 0, 0})
        Me.txtprofit.Name = "txtprofit"
        Me.txtprofit.Size = New System.Drawing.Size(63, 20)
        Me.txtprofit.TabIndex = 10
        Me.txtprofit.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblPercent
        '
        Me.LblPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblPercent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPercent.ForeColor = System.Drawing.Color.Black
        Me.LblPercent.Location = New System.Drawing.Point(70, 3)
        Me.LblPercent.Name = "LblPercent"
        Me.LblPercent.Size = New System.Drawing.Size(66, 20)
        Me.LblPercent.TabIndex = 26
        '
        'Lblshare
        '
        Me.Lblshare.BackColor = System.Drawing.Color.Transparent
        Me.Lblshare.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblshare.ForeColor = System.Drawing.Color.Black
        Me.Lblshare.Location = New System.Drawing.Point(5, 56)
        Me.Lblshare.Name = "Lblshare"
        Me.Lblshare.Size = New System.Drawing.Size(140, 24)
        Me.Lblshare.TabIndex = 25
        Me.Lblshare.Text = "SHARE OF PROFIT :-"
        '
        'RBCr
        '
        Me.RBCr.AutoSize = True
        Me.RBCr.BackColor = System.Drawing.Color.Transparent
        Me.RBCr.Location = New System.Drawing.Point(59, 27)
        Me.RBCr.Name = "RBCr"
        Me.RBCr.Size = New System.Drawing.Size(35, 17)
        Me.RBCr.TabIndex = 8
        Me.RBCr.Text = "Cr"
        Me.RBCr.UseVisualStyleBackColor = False
        '
        'RBdr
        '
        Me.RBdr.AutoSize = True
        Me.RBdr.BackColor = System.Drawing.Color.Transparent
        Me.RBdr.Checked = True
        Me.RBdr.Location = New System.Drawing.Point(3, 27)
        Me.RBdr.Name = "RBdr"
        Me.RBdr.Size = New System.Drawing.Size(36, 17)
        Me.RBdr.TabIndex = 7
        Me.RBdr.TabStop = True
        Me.RBdr.Text = "Dr"
        Me.RBdr.UseVisualStyleBackColor = False
        '
        'Txtopnblnce
        '
        Me.Txtopnblnce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtopnblnce.Location = New System.Drawing.Point(3, 5)
        Me.Txtopnblnce.MaxLength = 29
        Me.Txtopnblnce.Name = "Txtopnblnce"
        Me.Txtopnblnce.Size = New System.Drawing.Size(145, 20)
        Me.Txtopnblnce.TabIndex = 6
        Me.Txtopnblnce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(5, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 34)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "OPENING BALANCE  :-"
        '
        'LblOpnbal
        '
        Me.LblOpnbal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOpnbal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOpnbal.Location = New System.Drawing.Point(154, 22)
        Me.LblOpnbal.Name = "LblOpnbal"
        Me.LblOpnbal.Size = New System.Drawing.Size(245, 18)
        Me.LblOpnbal.TabIndex = 9
        Me.LblOpnbal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(151, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(220, 14)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Diff. IN OPENING BALANCE :-"
        '
        'lstvew1
        '
        Me.lstvew1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstvew1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstvew1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstvew1.FullRowSelect = True
        Me.lstvew1.GridLines = True
        Me.lstvew1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstvew1.Location = New System.Drawing.Point(216, 219)
        Me.lstvew1.Name = "lstvew1"
        Me.lstvew1.Size = New System.Drawing.Size(416, 140)
        Me.lstvew1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstvew1.TabIndex = 42
        Me.lstvew1.TabStop = False
        Me.lstvew1.UseCompatibleStateImageBehavior = False
        Me.lstvew1.View = System.Windows.Forms.View.Details
        Me.lstvew1.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 390
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Id"
        Me.ColumnHeader2.Width = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(8, 75)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstvew1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tlp4b)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tlp4a)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tlp2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tlp4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.SplitContainer1.Panel2.Controls.Add(Me.Btnclos)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Btnnew)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Btndel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Btnfnd)
        Me.SplitContainer1.Size = New System.Drawing.Size(656, 437)
        Me.SplitContainer1.SplitterDistance = 368
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 43
        '
        'Tlp4b
        '
        Me.Tlp4b.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.Tlp4b.Location = New System.Drawing.Point(422, 319)
        Me.Tlp4b.Name = "Tlp4b"
        Me.Tlp4b.Size = New System.Drawing.Size(200, 100)
        Me.Tlp4b.TabIndex = 45
        Me.Tlp4b.Visible = False
        '
        'Tlp4a
        '
        Me.Tlp4a.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.Tlp4a.Location = New System.Drawing.Point(216, 319)
        Me.Tlp4a.Name = "Tlp4a"
        Me.Tlp4a.Size = New System.Drawing.Size(200, 100)
        Me.Tlp4a.TabIndex = 3
        Me.Tlp4a.Visible = False
        '
        'Tlp2
        '
        Me.Tlp2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.Tlp2.Location = New System.Drawing.Point(10, 213)
        Me.Tlp2.Name = "Tlp2"
        Me.Tlp2.Size = New System.Drawing.Size(200, 100)
        Me.Tlp2.TabIndex = 0
        '
        'Tlp4
        '
        Me.Tlp4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.Tlp4.Location = New System.Drawing.Point(10, 319)
        Me.Tlp4.Name = "Tlp4"
        Me.Tlp4.Size = New System.Drawing.Size(200, 100)
        Me.Tlp4.TabIndex = 2
        Me.Tlp4.Visible = False
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(4, 304)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(88, 16)
        Me.Label31.TabIndex = 2
        Me.Label31.Text = "E-Mail   :-"
        '
        'Txtmail
        '
        Me.Txtmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtmail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtmail.Location = New System.Drawing.Point(234, 307)
        Me.Txtmail.MaxLength = 50
        Me.Txtmail.Name = "Txtmail"
        Me.Txtmail.Size = New System.Drawing.Size(203, 21)
        Me.Txtmail.TabIndex = 10
        '
        'Txtsetlmt
        '
        Me.Txtsetlmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtsetlmt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtsetlmt.Location = New System.Drawing.Point(234, 44)
        Me.Txtsetlmt.MaxLength = 29
        Me.Txtsetlmt.Name = "Txtsetlmt"
        Me.Txtsetlmt.Size = New System.Drawing.Size(177, 20)
        Me.Txtsetlmt.TabIndex = 1
        Me.Txtsetlmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(4, 41)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(133, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Set Credit Limits ?"
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(4, 330)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(88, 16)
        Me.Label32.TabIndex = 2
        Me.Label32.Text = "Website   :-"
        '
        'Txtsite
        '
        Me.Txtsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtsite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtsite.Location = New System.Drawing.Point(234, 333)
        Me.Txtsite.MaxLength = 50
        Me.Txtsite.Name = "Txtsite"
        Me.Txtsite.Size = New System.Drawing.Size(203, 21)
        Me.Txtsite.TabIndex = 11
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(4, 278)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(91, 16)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "Mobile No.   :-"
        '
        'Txtmob
        '
        Me.Txtmob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtmob.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtmob.Location = New System.Drawing.Point(234, 281)
        Me.Txtmob.MaxLength = 26
        Me.Txtmob.Name = "Txtmob"
        Me.Txtmob.Size = New System.Drawing.Size(325, 21)
        Me.Txtmob.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Btncty)
        Me.Panel2.Controls.Add(Me.CmbxCty)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(234, 148)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(325, 22)
        Me.Panel2.TabIndex = 5
        '
        'Btncty
        '
        Me.Btncty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btncty.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btncty.Location = New System.Drawing.Point(201, 0)
        Me.Btncty.Name = "Btncty"
        Me.Btncty.Size = New System.Drawing.Size(39, 20)
        Me.Btncty.TabIndex = 6
        Me.Btncty.TabStop = False
        Me.Btncty.Text = "...."
        Me.Btncty.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btncty.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(210, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 5
        '
        'Tlp1
        '
        Me.Tlp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Tlp1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tlp1.ColumnCount = 2
        Me.Tlp1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147.0!))
        Me.Tlp1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp1.Controls.Add(Me.Panel1, 1, 1)
        Me.Tlp1.Controls.Add(Me.Label6, 0, 2)
        Me.Tlp1.Controls.Add(Me.CmbxActtype, 1, 2)
        Me.Tlp1.Controls.Add(Me.Label1, 0, 0)
        Me.Tlp1.Controls.Add(Me.Label2, 0, 1)
        Me.Tlp1.Controls.Add(Me.Panel3, 1, 0)
        Me.Tlp1.Location = New System.Drawing.Point(19, 86)
        Me.Tlp1.Name = "Tlp1"
        Me.Tlp1.RowCount = 3
        Me.Tlp1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Tlp1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Tlp1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Tlp1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Tlp1.Size = New System.Drawing.Size(626, 203)
        Me.Tlp1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.BtnUg)
        Me.Panel1.Controls.Add(Me.CmbxUndrGrup)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(152, 71)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(470, 60)
        Me.Panel1.TabIndex = 2
        '
        'BtnUg
        '
        Me.BtnUg.BackgroundImage = Global.FinAcct.My.Resources.Resources.SOFTT06A
        Me.BtnUg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnUg.FlatAppearance.BorderSize = 0
        Me.BtnUg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUg.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUg.Location = New System.Drawing.Point(425, 3)
        Me.BtnUg.Name = "BtnUg"
        Me.BtnUg.Size = New System.Drawing.Size(36, 22)
        Me.BtnUg.TabIndex = 4
        Me.BtnUg.TabStop = False
        Me.BtnUg.Text = "...."
        Me.BtnUg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnUg.UseVisualStyleBackColor = True
        '
        'CmbxUndrGrup
        '
        Me.CmbxUndrGrup.BackColor = System.Drawing.Color.White
        Me.CmbxUndrGrup.Location = New System.Drawing.Point(3, 4)
        Me.CmbxUndrGrup.Name = "CmbxUndrGrup"
        Me.CmbxUndrGrup.Size = New System.Drawing.Size(418, 21)
        Me.CmbxUndrGrup.Sorted = True
        Me.CmbxUndrGrup.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 21)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TYPE "
        '
        'CmbxActtype
        '
        Me.CmbxActtype.BackColor = System.Drawing.Color.White
        Me.CmbxActtype.Items.AddRange(New Object() {"Bank", "Cash Book", "Customer", "General Account", "Sales Agent        ", "Share Holder", "Vendor"})
        Me.CmbxActtype.Location = New System.Drawing.Point(152, 138)
        Me.CmbxActtype.MaxDropDownItems = 4
        Me.CmbxActtype.Name = "CmbxActtype"
        Me.CmbxActtype.Size = New System.Drawing.Size(218, 21)
        Me.CmbxActtype.Sorted = True
        Me.CmbxActtype.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NAME"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "UNDER GROUP "
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnsrfix)
        Me.Panel3.Controls.Add(Me.Txtsurfix)
        Me.Panel3.Controls.Add(Me.Txtactname)
        Me.Panel3.Controls.Add(Me.Label39)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(152, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(470, 60)
        Me.Panel3.TabIndex = 0
        '
        'btnsrfix
        '
        Me.btnsrfix.BackgroundImage = CType(resources.GetObject("btnsrfix.BackgroundImage"), System.Drawing.Image)
        Me.btnsrfix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnsrfix.Enabled = False
        Me.btnsrfix.FlatAppearance.BorderSize = 0
        Me.btnsrfix.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsrfix.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsrfix.Location = New System.Drawing.Point(178, 0)
        Me.btnsrfix.Name = "btnsrfix"
        Me.btnsrfix.Size = New System.Drawing.Size(36, 22)
        Me.btnsrfix.TabIndex = 1
        Me.btnsrfix.TabStop = False
        Me.btnsrfix.Text = "...."
        Me.btnsrfix.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnsrfix.UseVisualStyleBackColor = True
        Me.btnsrfix.Visible = False
        '
        'Txtsurfix
        '
        Me.Txtsurfix.FormattingEnabled = True
        Me.Txtsurfix.Location = New System.Drawing.Point(53, 1)
        Me.Txtsurfix.MaxLength = 10
        Me.Txtsurfix.Name = "Txtsurfix"
        Me.Txtsurfix.Size = New System.Drawing.Size(119, 21)
        Me.Txtsurfix.TabIndex = 0
        '
        'Txtactname
        '
        Me.Txtactname.BackColor = System.Drawing.Color.White
        Me.Txtactname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtactname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtactname.Location = New System.Drawing.Point(53, 29)
        Me.Txtactname.MaxLength = 69
        Me.Txtactname.Name = "Txtactname"
        Me.Txtactname.Size = New System.Drawing.Size(412, 20)
        Me.Txtactname.TabIndex = 1
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(7, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(42, 20)
        Me.Label39.TabIndex = 53
        Me.Label39.Text = "Code"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblagntadrs
        '
        Me.lblagntadrs.Location = New System.Drawing.Point(0, 0)
        Me.lblagntadrs.Name = "lblagntadrs"
        Me.lblagntadrs.Size = New System.Drawing.Size(100, 23)
        Me.lblagntadrs.TabIndex = 0
        '
        'TtxtSaleAgnt
        '
        Me.TtxtSaleAgnt.Location = New System.Drawing.Point(0, 0)
        Me.TtxtSaleAgnt.Name = "TtxtSaleAgnt"
        Me.TtxtSaleAgnt.Size = New System.Drawing.Size(100, 20)
        Me.TtxtSaleAgnt.TabIndex = 0
        '
        'Tlp3
        '
        Me.Tlp3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tlp3.ColumnCount = 4
        Me.Tlp3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.Tlp3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176.0!))
        Me.Tlp3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131.0!))
        Me.Tlp3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158.0!))
        Me.Tlp3.Controls.Add(Me.LblEdt, 3, 12)
        Me.Tlp3.Controls.Add(Me.CmbxPrceLst, 1, 12)
        Me.Tlp3.Controls.Add(Me.Label43, 0, 12)
        Me.Tlp3.Controls.Add(Me.Label13, 0, 5)
        Me.Tlp3.Controls.Add(Me.Nuddays, 1, 5)
        Me.Tlp3.Controls.Add(Me.CmbxVat, 1, 2)
        Me.Tlp3.Controls.Add(Me.NudNetday, 3, 5)
        Me.Tlp3.Controls.Add(Me.Label26, 2, 5)
        Me.Tlp3.Controls.Add(Me.Label21, 0, 2)
        Me.Tlp3.Controls.Add(Me.Label30, 0, 6)
        Me.Tlp3.Controls.Add(Me.txtIncenTar, 1, 6)
        Me.Tlp3.Controls.Add(Me.CmbxIncenType, 3, 6)
        Me.Tlp3.Controls.Add(Me.Label34, 2, 6)
        Me.Tlp3.Controls.Add(Me.Label35, 0, 7)
        Me.Tlp3.Controls.Add(Me.TxtIncenval, 1, 7)
        Me.Tlp3.Controls.Add(Me.CmbxCost, 3, 7)
        Me.Tlp3.Controls.Add(Me.Label16, 2, 7)
        Me.Tlp3.Controls.Add(Me.BtnAgent, 3, 9)
        Me.Tlp3.Controls.Add(Me.Label36, 0, 9)
        Me.Tlp3.Controls.Add(Me.Cmbxagent, 1, 9)
        Me.Tlp3.Controls.Add(Me.Label40, 0, 10)
        Me.Tlp3.Controls.Add(Me.Txtcontperson, 1, 10)
        Me.Tlp3.Controls.Add(Me.BtnCont, 3, 10)
        Me.Tlp3.Controls.Add(Me.Label37, 2, 10)
        Me.Tlp3.Controls.Add(Me.Label38, 0, 11)
        Me.Tlp3.Controls.Add(Me.BtnDeladrs, 1, 11)
        Me.Tlp3.Controls.Add(Me.Btnitematch, 3, 11)
        Me.Tlp3.Controls.Add(Me.Label41, 2, 11)
        Me.Tlp3.Controls.Add(Me.CmbxVatCst, 1, 8)
        Me.Tlp3.Controls.Add(Me.Label42, 0, 8)
        Me.Tlp3.Controls.Add(Me.BtnVatCst, 3, 8)
        Me.Tlp3.Controls.Add(Me.Label44, 0, 13)
        Me.Tlp3.Controls.Add(Me.CmbxCarri, 1, 13)
        Me.Tlp3.Controls.Add(Me.BtnCarri, 3, 13)
        Me.Tlp3.Controls.Add(Me.txtPan, 3, 3)
        Me.Tlp3.Controls.Add(Me.Label24, 2, 3)
        Me.Tlp3.Controls.Add(Me.Label12, 0, 4)
        Me.Tlp3.Controls.Add(Me.Txtdis, 1, 4)
        Me.Tlp3.Controls.Add(Me.TextBox1, 3, 4)
        Me.Tlp3.Controls.Add(Me.Label45, 2, 4)
        Me.Tlp3.Controls.Add(Me.Label18, 0, 0)
        Me.Tlp3.Controls.Add(Me.CmbxInt, 1, 0)
        Me.Tlp3.Controls.Add(Me.txtperofcal, 3, 0)
        Me.Tlp3.Controls.Add(Me.Label27, 2, 0)
        Me.Tlp3.Controls.Add(Me.Panel8, 0, 1)
        Me.Tlp3.Controls.Add(Me.txtExcise, 1, 3)
        Me.Tlp3.Controls.Add(Me.Label29, 0, 3)
        Me.Tlp3.Controls.Add(Me.txtVat, 3, 2)
        Me.Tlp3.Controls.Add(Me.Label25, 2, 2)
        Me.Tlp3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tlp3.Location = New System.Drawing.Point(670, 82)
        Me.Tlp3.Name = "Tlp3"
        Me.Tlp3.RowCount = 14
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.213078!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.210054!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.213077!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.458829!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.944427!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.213077!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.213077!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.213077!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.257167!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.257167!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.738801!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.738801!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.067938!))
        Me.Tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.261429!))
        Me.Tlp3.Size = New System.Drawing.Size(580, 427)
        Me.Tlp3.TabIndex = 11
        '
        'LblEdt
        '
        Me.LblEdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblEdt.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEdt.ForeColor = System.Drawing.Color.Black
        Me.LblEdt.Location = New System.Drawing.Point(439, 357)
        Me.LblEdt.Name = "LblEdt"
        Me.LblEdt.Size = New System.Drawing.Size(120, 20)
        Me.LblEdt.TabIndex = 53
        Me.LblEdt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxPrceLst
        '
        Me.Tlp3.SetColumnSpan(Me.CmbxPrceLst, 2)
        Me.CmbxPrceLst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxPrceLst.FormattingEnabled = True
        Me.CmbxPrceLst.Location = New System.Drawing.Point(130, 360)
        Me.CmbxPrceLst.Name = "CmbxPrceLst"
        Me.CmbxPrceLst.Size = New System.Drawing.Size(282, 22)
        Me.CmbxPrceLst.TabIndex = 33
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(4, 357)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(119, 20)
        Me.Label43.TabIndex = 53
        Me.Label43.Text = "Select A Price List"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(4, 151)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 20)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Discount Days"
        '
        'Nuddays
        '
        Me.Nuddays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nuddays.Location = New System.Drawing.Point(130, 154)
        Me.Nuddays.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.Nuddays.Name = "Nuddays"
        Me.Nuddays.Size = New System.Drawing.Size(77, 21)
        Me.Nuddays.TabIndex = 24
        '
        'NudNetday
        '
        Me.NudNetday.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudNetday.Location = New System.Drawing.Point(439, 154)
        Me.NudNetday.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.NudNetday.Name = "NudNetday"
        Me.NudNetday.Size = New System.Drawing.Size(77, 21)
        Me.NudNetday.TabIndex = 25
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(307, 151)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(110, 20)
        Me.Label26.TabIndex = 40
        Me.Label26.Text = "Due Days"
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(4, 181)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(119, 20)
        Me.Label30.TabIndex = 42
        Me.Label30.Text = "Incentive Target"
        '
        'txtIncenTar
        '
        Me.txtIncenTar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIncenTar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIncenTar.Location = New System.Drawing.Point(130, 184)
        Me.txtIncenTar.MaxLength = 18
        Me.txtIncenTar.Name = "txtIncenTar"
        Me.txtIncenTar.Size = New System.Drawing.Size(170, 22)
        Me.txtIncenTar.TabIndex = 26
        Me.txtIncenTar.Text = "0.00"
        Me.txtIncenTar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmbxIncenType
        '
        Me.CmbxIncenType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbxIncenType.BackColor = System.Drawing.Color.White
        Me.CmbxIncenType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxIncenType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxIncenType.ForeColor = System.Drawing.Color.Navy
        Me.CmbxIncenType.Items.AddRange(New Object() {"Percentage", "Value"})
        Me.CmbxIncenType.Location = New System.Drawing.Point(439, 184)
        Me.CmbxIncenType.Name = "CmbxIncenType"
        Me.CmbxIncenType.Size = New System.Drawing.Size(152, 23)
        Me.CmbxIncenType.TabIndex = 27
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(307, 181)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(125, 20)
        Me.Label34.TabIndex = 44
        Me.Label34.Text = "Incentive Type"
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(4, 211)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(119, 20)
        Me.Label35.TabIndex = 46
        Me.Label35.Text = "Incentive"
        '
        'TxtIncenval
        '
        Me.TxtIncenval.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIncenval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIncenval.Location = New System.Drawing.Point(130, 214)
        Me.TxtIncenval.MaxLength = 18
        Me.TxtIncenval.Name = "TxtIncenval"
        Me.TxtIncenval.Size = New System.Drawing.Size(170, 22)
        Me.TxtIncenval.TabIndex = 28
        Me.TxtIncenval.Text = "0.00"
        Me.TxtIncenval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnAgent
        '
        Me.BtnAgent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAgent.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgent.Location = New System.Drawing.Point(439, 274)
        Me.BtnAgent.Name = "BtnAgent"
        Me.BtnAgent.Size = New System.Drawing.Size(42, 23)
        Me.BtnAgent.TabIndex = 33
        Me.BtnAgent.TabStop = False
        Me.BtnAgent.Text = "...."
        Me.BtnAgent.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(4, 271)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(119, 20)
        Me.Label36.TabIndex = 48
        Me.Label36.Text = "Sales Agent"
        '
        'Cmbxagent
        '
        Me.Cmbxagent.BackColor = System.Drawing.Color.White
        Me.Tlp3.SetColumnSpan(Me.Cmbxagent, 2)
        Me.Cmbxagent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxagent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxagent.ForeColor = System.Drawing.Color.Navy
        Me.Cmbxagent.Items.AddRange(New Object() {"Percentage", "Value"})
        Me.Cmbxagent.Location = New System.Drawing.Point(130, 274)
        Me.Cmbxagent.Name = "Cmbxagent"
        Me.Cmbxagent.Size = New System.Drawing.Size(273, 23)
        Me.Cmbxagent.TabIndex = 31
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(4, 301)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(119, 20)
        Me.Label40.TabIndex = 56
        Me.Label40.Text = "Contact Person"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtcontperson
        '
        Me.Txtcontperson.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtcontperson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtcontperson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtcontperson.Location = New System.Drawing.Point(130, 304)
        Me.Txtcontperson.Name = "Txtcontperson"
        Me.Txtcontperson.Size = New System.Drawing.Size(170, 22)
        Me.Txtcontperson.TabIndex = 32
        '
        'BtnCont
        '
        Me.BtnCont.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCont.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCont.Location = New System.Drawing.Point(439, 304)
        Me.BtnCont.Name = "BtnCont"
        Me.BtnCont.Size = New System.Drawing.Size(42, 21)
        Me.BtnCont.TabIndex = 35
        Me.BtnCont.TabStop = False
        Me.BtnCont.Text = "...."
        Me.BtnCont.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(307, 301)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(125, 20)
        Me.Label37.TabIndex = 50
        Me.Label37.Text = "Contact Details"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(4, 329)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(119, 20)
        Me.Label38.TabIndex = 52
        Me.Label38.Text = "Delivery Address"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnDeladrs
        '
        Me.BtnDeladrs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDeladrs.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDeladrs.Location = New System.Drawing.Point(130, 332)
        Me.BtnDeladrs.Name = "BtnDeladrs"
        Me.BtnDeladrs.Size = New System.Drawing.Size(44, 21)
        Me.BtnDeladrs.TabIndex = 36
        Me.BtnDeladrs.TabStop = False
        Me.BtnDeladrs.Text = "...."
        Me.BtnDeladrs.UseVisualStyleBackColor = True
        '
        'Btnitematch
        '
        Me.Btnitematch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btnitematch.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnitematch.Location = New System.Drawing.Point(439, 332)
        Me.Btnitematch.Name = "Btnitematch"
        Me.Btnitematch.Size = New System.Drawing.Size(42, 21)
        Me.Btnitematch.TabIndex = 37
        Me.Btnitematch.TabStop = False
        Me.Btnitematch.Text = "...."
        Me.Btnitematch.UseVisualStyleBackColor = True
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(307, 329)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(125, 20)
        Me.Label41.TabIndex = 57
        Me.Label41.Text = "Attach Items"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxVatCst
        '
        Me.Tlp3.SetColumnSpan(Me.CmbxVatCst, 2)
        Me.CmbxVatCst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxVatCst.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxVatCst.FormattingEnabled = True
        Me.CmbxVatCst.Location = New System.Drawing.Point(130, 244)
        Me.CmbxVatCst.Name = "CmbxVatCst"
        Me.CmbxVatCst.Size = New System.Drawing.Size(273, 23)
        Me.CmbxVatCst.TabIndex = 30
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(4, 241)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(92, 14)
        Me.Label42.TabIndex = 59
        Me.Label42.Text = "VAT/CST Rate"
        '
        'BtnVatCst
        '
        Me.BtnVatCst.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnVatCst.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVatCst.Location = New System.Drawing.Point(439, 244)
        Me.BtnVatCst.Name = "BtnVatCst"
        Me.BtnVatCst.Size = New System.Drawing.Size(42, 23)
        Me.BtnVatCst.TabIndex = 31
        Me.BtnVatCst.TabStop = False
        Me.BtnVatCst.Text = "...."
        Me.BtnVatCst.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(4, 387)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(119, 20)
        Me.Label44.TabIndex = 53
        Me.Label44.Text = "Transport Company"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxCarri
        '
        Me.Tlp3.SetColumnSpan(Me.CmbxCarri, 2)
        Me.CmbxCarri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCarri.FormattingEnabled = True
        Me.CmbxCarri.Location = New System.Drawing.Point(130, 390)
        Me.CmbxCarri.Name = "CmbxCarri"
        Me.CmbxCarri.Size = New System.Drawing.Size(282, 22)
        Me.CmbxCarri.TabIndex = 34
        '
        'BtnCarri
        '
        Me.BtnCarri.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCarri.Location = New System.Drawing.Point(439, 390)
        Me.BtnCarri.Name = "BtnCarri"
        Me.BtnCarri.Size = New System.Drawing.Size(42, 23)
        Me.BtnCarri.TabIndex = 60
        Me.BtnCarri.TabStop = False
        Me.BtnCarri.Text = "...."
        Me.BtnCarri.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCarri.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(4, 122)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 20)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Discount [%] "
        '
        'Txtdis
        '
        Me.Txtdis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtdis.Location = New System.Drawing.Point(130, 125)
        Me.Txtdis.MaxLength = 11
        Me.Txtdis.Name = "Txtdis"
        Me.Txtdis.Size = New System.Drawing.Size(152, 22)
        Me.Txtdis.TabIndex = 22
        Me.Txtdis.Text = "0.000"
        Me.Txtdis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(439, 125)
        Me.TextBox1.MaxLength = 11
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(120, 22)
        Me.TextBox1.TabIndex = 23
        Me.TextBox1.Text = "0.000"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(307, 122)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(125, 20)
        Me.Label45.TabIndex = 36
        Me.Label45.Text = "Spl. Discount [%] "
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(4, 1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(119, 22)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Interest Calculations "
        '
        'CmbxInt
        '
        Me.CmbxInt.BackColor = System.Drawing.Color.White
        Me.CmbxInt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxInt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxInt.ForeColor = System.Drawing.Color.Navy
        Me.CmbxInt.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxInt.Location = New System.Drawing.Point(130, 4)
        Me.CmbxInt.Name = "CmbxInt"
        Me.CmbxInt.Size = New System.Drawing.Size(77, 23)
        Me.CmbxInt.TabIndex = 12
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tlp3.SetColumnSpan(Me.Panel8, 4)
        Me.Panel8.Controls.Add(Me.Label46)
        Me.Panel8.Controls.Add(Me.NumUD)
        Me.Panel8.Controls.Add(Me.Cmbxsertax)
        Me.Panel8.Controls.Add(Me.CmbxInvtVal)
        Me.Panel8.Controls.Add(Me.Label7)
        Me.Panel8.Controls.Add(Me.CmbxFbt)
        Me.Panel8.Controls.Add(Me.Label20)
        Me.Panel8.Controls.Add(Me.Label19)
        Me.Panel8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel8.Location = New System.Drawing.Point(4, 34)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(587, 23)
        Me.Panel8.TabIndex = 14
        '
        'Label46
        '
        Me.Label46.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(3, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(38, 14)
        Me.Label46.TabIndex = 47
        Me.Label46.Text = "Rank"
        '
        'Cmbxsertax
        '
        Me.Cmbxsertax.BackColor = System.Drawing.Color.White
        Me.Cmbxsertax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxsertax.Enabled = False
        Me.Cmbxsertax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxsertax.ForeColor = System.Drawing.Color.Navy
        Me.Cmbxsertax.Items.AddRange(New Object() {"Yes", "No"})
        Me.Cmbxsertax.Location = New System.Drawing.Point(106, 0)
        Me.Cmbxsertax.Name = "Cmbxsertax"
        Me.Cmbxsertax.Size = New System.Drawing.Size(10, 23)
        Me.Cmbxsertax.TabIndex = 14
        Me.Cmbxsertax.Visible = False
        '
        'CmbxInvtVal
        '
        Me.CmbxInvtVal.BackColor = System.Drawing.Color.White
        Me.CmbxInvtVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxInvtVal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxInvtVal.ForeColor = System.Drawing.Color.Navy
        Me.CmbxInvtVal.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxInvtVal.Location = New System.Drawing.Point(436, 0)
        Me.CmbxInvtVal.Name = "CmbxInvtVal"
        Me.CmbxInvtVal.Size = New System.Drawing.Size(77, 22)
        Me.CmbxInvtVal.TabIndex = 15
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Enabled = False
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(82, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 22)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Sr.Tax "
        Me.Label19.Visible = False
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(307, 61)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(125, 22)
        Me.Label25.TabIndex = 1
        Me.Label25.Text = "TIN/VAT/CST NO."
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Txtopnblnce)
        Me.Panel6.Controls.Add(Me.RBdr)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.LblOpnbal)
        Me.Panel6.Controls.Add(Me.RBCr)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(154, 5)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(404, 46)
        Me.Panel6.TabIndex = 17
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Lblpcnt)
        Me.Panel7.Controls.Add(Me.txtprofit)
        Me.Panel7.Controls.Add(Me.LblPercent)
        Me.Panel7.Location = New System.Drawing.Point(154, 59)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(399, 25)
        Me.Panel7.TabIndex = 26
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Location = New System.Drawing.Point(-2, 1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1285, 73)
        Me.Panel5.TabIndex = 44
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(1204, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'FrmActMstr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.SpringGreen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1026, 514)
        Me.Controls.Add(Me.Tlp1)
        Me.Controls.Add(Me.Tlp3)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmActMstr"
        Me.ShowIcon = False
        Me.Text = "Account Master"
        CType(Me.NumUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtprofit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Tlp1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Tlp3.ResumeLayout(False)
        Me.Tlp3.PerformLayout()
        CType(Me.Nuddays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudNetday, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmActMstr_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            If MessageBox.Show("Are you sure to exit account creation master?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                If Tlp1.Visible = True Then
                    Txtactname.Focus()
                ElseIf Tlp4.Visible = True Then
                    DtpkrEffct.Focus()
                End If
                e.Cancel = True
                Return
            Else
                If FrmShow_flag(5) = True Then FrmShow_flag(5) = False
                If FrmShow_flag(24) = True Then FrmShow_flag(24) = False
                e.Cancel = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmActMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Left = 0
            Me.Top = 0
            Me.Width = 679
            Me.Height = 528
            Btnfnd.Text = "&Back"
            Btnfnd.Enabled = False
            Btndel.Text = "&Next"
            Btndel.Enabled = False
            Btnclos.Text = "&Cancel"
            If_Type_Bank_Then()
            fetch_rec_grup()
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)
            Tlp3.Visible = False
            Tlp4.Visible = False

            If Cl_Kbl = True Or Cl_Ltg = True Then
                Me.Label39.Location = New System.Drawing.Point(5, 26)
                Me.Txtsurfix.Location = New System.Drawing.Point(90, 28)
                Me.btnsrfix.Location = New System.Drawing.Point(218, 25)
                Me.Txtactname.Location = New System.Drawing.Point(3, 3)
                Me.Label39.Visible = False
                Me.Txtsurfix.Visible = False
                Me.btnsrfix.Visible = False
                Me.Txtactname.Focus()
                Me.Txtactname.SelectAll()
            Else

                Me.Label39.Location = New System.Drawing.Point(7, 0)
                Me.Txtsurfix.Location = New System.Drawing.Point(53, 1)
                Me.btnsrfix.Location = New System.Drawing.Point(178, 0)
                Me.Txtactname.Location = New System.Drawing.Point(53, 29)
                Me.Label39.Visible = True
                Me.Txtsurfix.Visible = True
                Me.btnsrfix.Visible = False
                Me.Txtsurfix.Focus()
                Me.Txtsurfix.SelectAll()
            End If

            ''=====Don't place more code after this block
            If FrmShow_flag(24) = True Then  '===For Purchase related Forms
                Me.CmbxActtype.SelectedIndex = 6
                Me.CmbxActtype.Enabled = False
                Exit Sub '=== It's because of frmshow_flag(5) is also used in purchase forms and state as true, prevent to reach it.
            Else
                Me.CmbxActtype.Enabled = True
            End If
            If FrmShow_flag(5) = True Then
                Me.CmbxActtype.SelectedIndex = 2
                Me.CmbxActtype.Enabled = False
            Else
                Me.CmbxActtype.Enabled = True
            End If
            ''=================================
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CheckAcess_Btn_frm(ByVal BtnnSave As Button, ByVal BtnnEdt As Button, _
         ByVal BtnnDel As Button)
        Select Case Trim(AcessRight)
            Case "OwnrFull"
                BtnnSave.Enabled = True
                BtnnEdt.Enabled = True
                BtnnDel.Enabled = True
            Case "DataEntryMstr"
                BtnnSave.Enabled = True
                BtnnSave.Location = New System.Drawing.Point(432, 574)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
            Case "PayRoll"
                BtnnSave.Enabled = True
                BtnnSave.Location = New System.Drawing.Point(432, 574)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
        End Select
    End Sub
    Private Sub fetch_rec_grup()
        Try
            Actgrpcmd = New SqlCommand("select cogrpid,Cogrupnam from FinactGrupname where cogrupnam<>'Primary' and codelstatus=1 order by Cogrupnam ", FinActConn)
            Actrdr = Actgrpcmd.ExecuteReader
            CmbxUndrGrup.Items.Clear()
            While Actrdr.Read()
                CmbxUndrGrup.Items.Add(Actrdr(1))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try
    End Sub

    Private Sub fetch_rec_statecontry()
        Try
            Actgrpcmd = New SqlCommand("select * from FinactCscmstr where cscctyname=@city", FinActConn)
            Actgrpcmd.Parameters.AddWithValue("@city", CmbxCty.Text)
            Actrdr = Actgrpcmd.ExecuteReader
            If Trim(CmbxCty.Text) <> "" Then
                Actrdr.Read()
                Ctyid = Actrdr("cscid")
                state.Text = Actrdr("cscstatename")
                contry.Text = Actrdr("csccontry")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try
    End Sub

    Private Sub chkemptval()
        Try
            'If Me.CmbxPrceLst.Enabled = True Then
            '    With Me.CmbxPrceLst
            '        If .Text = "" Then
            '            .BackColor = Color.Cyan
            '            .Focus()
            '            indxActmstr = indxActmstr + 1
            '        Else
            '            .BackColor = Color.White
            '        End If
            '    End With
            'End If
            If Panel1.Enabled = True Then
                With Txtactname
                    If .Text = "" Then
                        .BackColor = Color.PapayaWhip
                        .Focus()
                        indxActmstr = indxActmstr + 1
                    Else
                        .BackColor = Color.White

                    End If
                End With
                With CmbxUndrGrup
                    If .Text = "" Then
                        .BackColor = Color.PapayaWhip
                        .Focus()
                        indxActmstr = indxActmstr + 1
                    Else
                        .BackColor = Color.White

                    End If
                End With

                ' If cmbxOnrType.Enabled = True Then
                If Val(LblPercent.Text) = 0 Or Val(LblPercent.Text) < 0 Then
                    txtprofit.Focus()
                    txtprofit.BackColor = Color.PapayaWhip
                    LblPercent.BackColor = Color.PapayaWhip
                    indxActmstr = indxActmstr + 1
                Else
                    txtprofit.BackColor = Color.White
                    LblPercent.BackColor = Color.PapayaWhip

                End If

                With CmbxActtype
                    If .Text = "" Then
                        .Focus()
                        .BackColor = Color.PapayaWhip
                        indxActmstr = indxActmstr + 1
                    Else
                        .BackColor = Color.White
                    End If
                End With
            End If

            With Txtopnblnce
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.PapayaWhip
                    indxActmstr = indxActmstr + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Txtadrs
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.PapayaWhip
                    indxActmstr = indxActmstr + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With CmbxCty
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.PapayaWhip
                    indxActmstr = indxActmstr + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Txtmail
                If Trim(.Text) <> "" Then
                    If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then

                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.LemonChiffon
                        .ForeColor = Color.Black
                        .Focus()
                        indxActmstr = indxActmstr + 1
                    End If
                End If
            End With
            With Txtsite
                If Trim(.Text) <> "" Then
                    Searchstring(Txtsite.Text, "WWW.")

                    If OkFormat = False Then
                        Searchstring(Txtsite.Text, "HTTP://WWW.")

                    End If
                    If OkFormat = True Then
                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.LemonChiffon
                        .ForeColor = Color.Black
                        indxActmstr = indxActmstr + 1
                        .SelectAll()
                    End If
                End If


            End With
            '' End If
        Catch ex As Exception
            MsgBox("Press New Button to proceed", MsgBoxStyle.Information, "Error Handler")
            Btnnew.Focus()
        End Try
    End Sub

    Private Sub Invaliddata()

        With Txtmail
            If Trim(.Text) <> "" Then
                If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then

                    .BackColor = Color.White
                    .ForeColor = Color.Black
                Else
                    .BackColor = Color.LemonChiffon
                    .ForeColor = Color.Black
                    .Focus()
                    indxActmstr = indxActmstr + 1
                End If
            End If
        End With
        With Txtsite
            If Trim(.Text) <> "" Then
                Searchstring(Txtsite.Text, "WWW.")

                If OkFormat = False Then
                    Searchstring(Txtsite.Text, "HTTP://WWW.")

                End If
                If OkFormat = True Then
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                Else
                    .BackColor = Color.LemonChiffon
                    .ForeColor = Color.Black
                    indxActmstr = indxActmstr + 1
                    .SelectAll()
                End If
            End If


        End With


    End Sub

    Private Sub numericTextboxKeyPress1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "." Then
            If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                e.Handled = True
            End If
        ElseIf e.KeyChar = "-" Then

            If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                e.Handled = True
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    'Private Sub numericTextboxKeyPress2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVat.KeyPress, txtCst.KeyPress, txtExcise.KeyPress, txtPin.KeyPress, txtPhwork.KeyPress, Txtmob.KeyPress
    '    Dim tb As TextBox = CType(sender, TextBox)
    '    Dim chr As Char = e.KeyChar
    '    If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
    '        e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
    '    ElseIf e.KeyChar <> "." Then
    '        If (tb.SelectedText <> "." Or IsNumeric(tb.Text & e.KeyChar)) Then
    '            e.Handled = True
    '        End If
    '    ElseIf e.KeyChar = "-" Then

    '        If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
    '            e.Handled = True
    '        End If
    '    ElseIf Not Char.IsControl(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub


    Private Sub clrvalue()
        Dim cntr As Control
        For Each cntr In Me.Tlp1.Controls
            If TypeOf cntr Is TextBox Then
                cntr.Text = ""
            End If
        Next

        For Each cntr In Me.Tlp3.Controls
            If TypeOf cntr Is TextBox Then
                cntr.Text = ""
            End If
        Next

        For Each cntr In Me.Tlp4.Controls
            If TypeOf cntr Is TextBox Then
                cntr.Text = ""
            End If
        Next
        For Each cntr In Me.Tlp4a.Controls
            If TypeOf cntr Is TextBox Then
                cntr.Text = ""
            End If
        Next
        For Each cntr In Me.Tlp4b.Controls
            If TypeOf cntr Is TextBox Then
                cntr.Text = ""
            End If
        Next
        For Each cntr In Me.Panel1.Controls
            If TypeOf cntr Is TextBox Then
                cntr.Text = ""
            End If
        Next
        For Each cntr In Me.Panel2.Controls
            If TypeOf cntr Is TextBox Then
                cntr.Text = ""
            End If
        Next
        For Each cntr In Me.Panel5.Controls
            If TypeOf cntr Is TextBox Then
                cntr.Text = ""
            End If
        Next
        For Each cntr In Me.Panel6.Controls
            If TypeOf cntr Is TextBox Then
                cntr.Text = ""
            End If
        Next
        For Each cntr In Me.Panel7.Controls
            If TypeOf cntr Is TextBox Then
                cntr.Text = ""
            End If
        Next
        Me.Txtactname.Clear()
        Me.Txtsurfix.SelectedIndex = -1
        CmbxUndrGrup.Text = ""
        CmbxActtype.Text = ""
        DtpkrEffct.Text = ""
        NumUD.Value = 1
        CmbxCty.Text = ""
        state.Text = ""
        contry.Text = ""
        LblOpnbal.Text = ""
    End Sub

    Private Sub actmstrsave_rec()

        Dim YesNo1, YesNo2, YesNo3, YesNo4, YesNo5, YesNo6 As Integer
        Dim ctyid As Integer
        Dim grupid As Integer
        Alowfinal = True
        Try
            Actgrpcmd = New SqlCommand("select cscid from FinactCscmstr where cscctyname=@city", FinActConn)
            Actgrpcmd.Parameters.AddWithValue("@city", CmbxCty.Text)
            Actrdr = Actgrpcmd.ExecuteReader
            If Trim(CmbxCty.Text) <> "" Then
                Actrdr.Read()
                ctyid = Actrdr("cscid")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try
        Try
            If RBdr.Checked = True Then
                BalType = Trim("Debit")
            ElseIf RBCr.Checked = True Then
                BalType = Trim("Credit")
            End If
            Actgrpcmd = New SqlCommand("select cogrpid from FinactGrupname where cogrupnam=@gname ", FinActConn)
            Actgrpcmd.Parameters.AddWithValue("@gname", CmbxUndrGrup.Text)
            Actrdr = Actgrpcmd.ExecuteReader
            Actrdr.Read()
            grupid = (Actrdr(0))

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try

        Try
            Actgrpcmd = New SqlCommand("finact_splrmstr_adrsmstr_insert", FinActConn)
            Actgrpcmd.CommandType = CommandType.StoredProcedure
            Actgrpcmd.Parameters.AddWithValue("@splrname", Txtactname.Text)
            Actgrpcmd.Parameters.AddWithValue("@splrundrgrup", grupid)
            Actgrpcmd.Parameters.AddWithValue("@Splrtype", CmbxActtype.Text)
            Actgrpcmd.Parameters.AddWithValue("@splropnbal", (Txtopnblnce.Text))
            Actgrpcmd.Parameters.AddWithValue("@splrbaltype", BalType)
            Actgrpcmd.Parameters.AddWithValue("@splradusrid", Current_UsrId)
            Actgrpcmd.Parameters.AddWithValue("@splrAddt", Now)
            If Len(Trim(Txtsurfix.Text)) <> 0 Then

                Actgrpcmd.Parameters.AddWithValue("@splrsurfix", Trim(Txtsurfix.Text))
            Else

                Actgrpcmd.Parameters.AddWithValue("@splrsurfix", 0)
            End If
            If Trim(ChkCoStatus) = "Indvl" Then
                Actgrpcmd.Parameters.AddWithValue("@splrcostatus", Trim("Proprietor"))
                Actgrpcmd.Parameters.AddWithValue("@splrcapshare", (LblPercent.Text))
            Else
                Actgrpcmd.Parameters.AddWithValue("@splrcostatus", "Partner")
                Actgrpcmd.Parameters.AddWithValue("@splrcapshare", CDbl(0.0))
            End If


            If Trim(CmbxActtype.Text) = "Customer" Or Trim(CmbxActtype.Text) = "Vendor" Then
                If Trim(Txtsetlmt.Text) <> "" Then
                    Actgrpcmd.Parameters.AddWithValue("@splrcrlmt", (Txtsetlmt.Text))
                Else
                    Actgrpcmd.Parameters.AddWithValue("@splrcrlmt", 0)
                End If

                Actgrpcmd.Parameters.AddWithValue("@splrpan", txtPan.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrvatno", txtVat.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrcst", txtVat.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrExciseno", txtExcise.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrrank", NumUD.Value)
                Actgrpcmd.Parameters.AddWithValue("@splrdiscom", Txtdis.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrtarget", txtIncenTar.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrincentype", CmbxIncenType.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrincenval", TxtIncenval.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrdisdays", Nuddays.Value)
                Actgrpcmd.Parameters.AddWithValue("@splrnetday", NudNetday.Value)
                If Trim(CmbxActtype.Text) = "Customer" Then
                    If Cmbxagent.SelectedIndex <> -1 Then
                        Actgrpcmd.Parameters.AddWithValue("@splragntid", Cmbxagent.SelectedValue)
                    Else
                        Actgrpcmd.Parameters.AddWithValue("@splragntid", 0)
                    End If
                Else
                    Actgrpcmd.Parameters.AddWithValue("@splragntid", 0)
                End If
                Actgrpcmd.Parameters.AddWithValue("@splrspcatid", CmbxVatCst.SelectedValue)
                Actgrpcmd.Parameters.AddWithValue("@splrcontid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrshipid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrnotes", "")
                'Actgrpcmd.Parameters.AddWithValue("@splrsurfix", Trim(Txtsurfix.Text))
                Actgrpcmd.Parameters.AddWithValue("@splrcontname", Trim(Txtcontperson.Text))

                If Trim(CmbxInvtVal.Text) = "Yes" Then
                    YesNo1 = 1
                ElseIf Trim(CmbxInvtVal.Text) = "No" Then
                    YesNo1 = 0
                End If
                Actgrpcmd.Parameters.AddWithValue("@splrInvntafect", YesNo1)
                If Trim(CmbxCost.Text) = "Yes" Then
                    YesNo2 = 1
                ElseIf Trim(CmbxCost.Text) = "No" Then
                    YesNo2 = 0
                End If
                Actgrpcmd.Parameters.AddWithValue("@splrcostafect", YesNo2)
                If Trim(CmbxInt.Text) = "Yes" Then
                    YesNo3 = 1
                ElseIf Trim(CmbxInt.Text) = "No" Then
                    YesNo3 = 0

                End If
                Actgrpcmd.Parameters.AddWithValue("@splrIntcal", YesNo3)
                Actgrpcmd.Parameters.AddWithValue("@splrafectdt", 0) 'DtpkrEffct.Value)
                If Trim(Cmbxsertax.Text) = "Yes" Then
                    YesNo4 = 1
                ElseIf (Cmbxsertax.Text) = "No" Then
                    YesNo4 = 0
                End If
                Actgrpcmd.Parameters.AddWithValue("@splrSrtx", YesNo4)
                If Trim(CmbxFbt.Text) = "Yes" Then
                    YesNo5 = 1
                ElseIf Trim(CmbxFbt.Text) = "No" Then
                    YesNo5 = 0
                End If
                Actgrpcmd.Parameters.AddWithValue("@splrFbtapp", YesNo5)
                If Trim(CmbxVat.Text) = "Yes" Then
                    YesNo6 = 1
                ElseIf Trim(CmbxVat.Text) = "No" Then
                    YesNo6 = 0
                End If
                Actgrpcmd.Parameters.AddWithValue("@splrusedvat", YesNo6)
                Actgrpcmd.Parameters.AddWithValue("@splrperofint", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrs1", Txtadrs.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs2", txtadrsarea.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs3", txtadrsland.Text)
                Actgrpcmd.Parameters.AddWithValue("adrsctyid", ctyid)
                Actgrpcmd.Parameters.AddWithValue("@adrspin", txtPin.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsphwork", txtPhwork.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsmoble", Txtmob.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsemail", Txtmail.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsweb", Txtsite.Text)

            ElseIf Trim(CmbxActtype.Text) = "Share Holder" Then
                Actgrpcmd.Parameters.AddWithValue("@splrcrlmt", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrpan", txtPan.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs1", Txtadrs.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs2", txtadrsarea.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs3", txtadrsland.Text)
                Actgrpcmd.Parameters.AddWithValue("adrsctyid", ctyid)
                Actgrpcmd.Parameters.AddWithValue("@adrspin", txtPin.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsphwork", txtPhwork.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsmoble", Txtmob.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsemail", Txtmail.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsweb", Txtsite.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrvatno", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcst", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrExciseno", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrrank", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrInvntafect", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcostafect", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrIntcal", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrafectdt", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrSrtx", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrFbtapp", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrusedvat", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrperofint", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrspcatid", 0)

                Actgrpcmd.Parameters.AddWithValue("@splrdiscom", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrtarget", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrincentype", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrincenval", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrdisdays", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrnetday", 0)
                Actgrpcmd.Parameters.AddWithValue("@splragntid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcontid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrshipid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrnotes", "")
                ' Actgrpcmd.Parameters.AddWithValue("@splrsurfix", "")
                Actgrpcmd.Parameters.AddWithValue("@splrcontname", "")



            ElseIf Trim(CmbxActtype.Text) = "Cash Book" Or Trim(CmbxActtype.Text) = "General Account" Then
                Actgrpcmd.Parameters.AddWithValue("@splrcrlmt", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrpan", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrs1", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrs2", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrs3", 0)
                Actgrpcmd.Parameters.AddWithValue("adrsctyid", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrspin", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrsphwork", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrsmoble", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrsemail", "")
                Actgrpcmd.Parameters.AddWithValue("@adrsweb", "")

                Actgrpcmd.Parameters.AddWithValue("@splrspcatid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrvatno", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcst", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrExciseno", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrrank", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrInvntafect", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcostafect", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrIntcal", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrafectdt", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrSrtx", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrFbtapp", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrusedvat", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrperofint", 0)

                Actgrpcmd.Parameters.AddWithValue("@splrdiscom", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrtarget", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrincentype", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrincenval", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrdisdays", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrnetday", 0)
                Actgrpcmd.Parameters.AddWithValue("@splragntid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcontid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrshipid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrnotes", "")
                ' Actgrpcmd.Parameters.AddWithValue("@splrsurfix", "")
                Actgrpcmd.Parameters.AddWithValue("@splrcontname", "")

            ElseIf Trim(CmbxActtype.Text) = "Sales Agent" Then

                Actgrpcmd.Parameters.AddWithValue("@splrcrlmt", TtxtSaleAgnt.Text) '
                Actgrpcmd.Parameters.AddWithValue("@splrpan", txtPan.Text) '
                Actgrpcmd.Parameters.AddWithValue("@splrvatno", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrcst", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrExciseno", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrrank", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrInvntafect", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrcostafect", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrspcatid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrdiscom", Txtdis.Text) '
                Actgrpcmd.Parameters.AddWithValue("@splrtarget", txtIncenTar.Text) '
                Actgrpcmd.Parameters.AddWithValue("@splrincentype", CmbxIncenType.Text) '
                Actgrpcmd.Parameters.AddWithValue("@splrincenval", TxtIncenval.Text) '
                Actgrpcmd.Parameters.AddWithValue("@splrdisdays", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrnetday", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splragntid", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrcontid", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrshipid", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrnotes", "") '
                ' Actgrpcmd.Parameters.AddWithValue("@splrsurfix", "") '
                Actgrpcmd.Parameters.AddWithValue("@splrcontname", "") '

                If Trim(CmbxInt.Text) = "Yes" Then
                    YesNo3 = 1
                ElseIf Trim(CmbxInt.Text) = "No" Then
                    YesNo3 = 0
                End If
                Actgrpcmd.Parameters.AddWithValue("@splrIntcal", YesNo3) '
                Actgrpcmd.Parameters.AddWithValue("@splrafectdt", DtpkrEffct.Value) '
                Actgrpcmd.Parameters.AddWithValue("@splrSrtx", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrFbtapp", 0) '
                Actgrpcmd.Parameters.AddWithValue("@splrusedvat", 0) '
                If txtperofcal.Enabled = True And Trim(txtperofcal.Text) <> "" Then
                    Actgrpcmd.Parameters.AddWithValue("@splrperofint", CDbl(txtperofcal.Text)) '
                Else
                    Actgrpcmd.Parameters.AddWithValue("@splrperofint", 0) '
                End If
                Actgrpcmd.Parameters.AddWithValue("@adrs1", Txtadrs.Text) '
                Actgrpcmd.Parameters.AddWithValue("@adrs2", txtadrsarea.Text) '
                Actgrpcmd.Parameters.AddWithValue("@adrs3", txtadrsland.Text) '
                Actgrpcmd.Parameters.AddWithValue("adrsctyid", ctyid) '
                Actgrpcmd.Parameters.AddWithValue("@adrspin", txtPin.Text) '
                Actgrpcmd.Parameters.AddWithValue("@adrsphwork", txtPhwork.Text) '
                Actgrpcmd.Parameters.AddWithValue("@adrsmoble", Txtmob.Text) '
                Actgrpcmd.Parameters.AddWithValue("@adrsemail", Txtmail.Text) '
                Actgrpcmd.Parameters.AddWithValue("@adrsweb", Txtsite.Text) '
            ElseIf Trim(CmbxActtype.Text) = "Bank" Then

                Actgrpcmd.Parameters.AddWithValue("@splrcrlmt", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrpan", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrvatno", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcst", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrExciseno", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrrank", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrInvntafect", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcostafect", 0)

                Actgrpcmd.Parameters.AddWithValue("@splrspcatid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrdiscom", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrtarget", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrincentype", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrincenval", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrdisdays", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrnetday", 0)
                Actgrpcmd.Parameters.AddWithValue("@splragntid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcontid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrshipid", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrnotes", "")
                ' Actgrpcmd.Parameters.AddWithValue("@splrsurfix", "")
                Actgrpcmd.Parameters.AddWithValue("@splrcontname", "")

                If Trim(CmbxInt.Text) = "Yes" Then
                    YesNo3 = 1
                ElseIf Trim(CmbxInt.Text) = "No" Then
                    YesNo3 = 0
                End If
                Actgrpcmd.Parameters.AddWithValue("@splrIntcal", YesNo3)
                Actgrpcmd.Parameters.AddWithValue("@splrafectdt", DtpkrEffct.Value)
                Actgrpcmd.Parameters.AddWithValue("@splrSrtx", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrFbtapp", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrusedvat", 0)
                If txtperofcal.Enabled = True And Trim(txtperofcal.Text) <> "" Then
                    Actgrpcmd.Parameters.AddWithValue("@splrperofint", CDbl(txtperofcal.Text))
                Else
                    Actgrpcmd.Parameters.AddWithValue("@splrperofint", 0)
                End If

                Actgrpcmd.Parameters.AddWithValue("@adrs1", Txtadrs.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs2", txtadrsarea.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs3", txtadrsland.Text)
                Actgrpcmd.Parameters.AddWithValue("adrsctyid", ctyid)
                Actgrpcmd.Parameters.AddWithValue("@adrspin", txtPin.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsphwork", txtPhwork.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsmoble", Txtmob.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsemail", Txtmail.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsweb", Txtsite.Text)
            End If
            Actgrpcmd.Parameters.AddWithValue("@adrsAdusrid", Current_UsrId)
            Actgrpcmd.Parameters.AddWithValue("@adrsAdDt", Now)
            Actgrpcmd.Parameters.AddWithValue("@splrDelstatus", 1)
            Actgrpcmd.Parameters.AddWithValue("@adrsDelstatus", 1)

            If Me.CmbxPrceLst.Enabled = True Then
                If Me.CmbxPrceLst.Items.Count > 0 And Trim(Me.CmbxPrceLst.Text) <> "" Then
                    Actgrpcmd.Parameters.AddWithValue("@alsplmstrid", Me.CmbxPrceLst.SelectedValue)
                Else
                    Actgrpcmd.Parameters.AddWithValue("@alsplmstrid", 0)
                End If
            Else
                Actgrpcmd.Parameters.AddWithValue("@alsplmstrid", 0)
            End If


            Chk_ProfitShareRatio()
            If Val(LblPercent.Text) > 0 Then
                Dim CurSharRatio As Double = (SharRatio - CurrRatio) + CDbl(LblPercent.Text) - 1
                If CurSharRatio > 100 Then
                    Alowfinal = False
                    If ChkCoStatus = "Indvl" Then
                        MsgBox("Invalid input!", MsgBoxStyle.Critical, "Company Status as Individual")
                    Else
                        MsgBox("Invalid input! Profit share is exceeded than 100 ", MsgBoxStyle.Critical)
                        txtprofit.Focus()
                    End If

                    Exit Sub
                    Exit Try
                End If
            End If
            If FrmShow_flag1 = True Then
                StrCmbxAgent = Trim(Txtactname.Text)
            End If
            If FrmShow_flag(5) = True Then      '+***** used for purchase order 
                IntHtCmMm(5) = Trim(Txtactname.Text)
            End If

            Actgrpcmd.Parameters.AddWithValue("@splrCarriId", Me.CmbxCarri.SelectedValue)
            Actgrpcmd.ExecuteNonQuery()

            If SplrStatus4Shp = True Then
                SplrName4Shp = Trim(Txtactname.Text)
                SplrSurfix4Shp = Trim(Txtsurfix.SelectedIndex)
                Me.Btndel.Enabled = False
                Me.Btnfnd.Text = "&Ok"

            Else
                MsgBox("Current record has been successfully saved!", MsgBoxStyle.Information, "Save Record")

                SplrName4Shp = ""
                SplrSurfix4Shp = 0
                Me.Btndel.Enabled = True
                Me.Btnfnd.Text = "&Back"
            End If
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MessageBox.Show("Invalid input! System found a record already existed with the same value. Try another value.", "Already Existed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtactname.Focus()
                Txtactname.SelectAll()
            Else
                MsgBox(ex.Message)
            End If
        Finally
            Actgrpcmd.Dispose()
        End Try
    End Sub


    Private Sub Btnfnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnfnd.Click
        If Trim(Btnfnd.Text) = "&Ok" Then
            clrvalue()
            Btnfnd.Enabled = False
            Btnfnd.Visible = False
            Tlp1.Visible = True
            Tlp2.Visible = True
            If Btndel.Visible = True Then Btndel.Visible = False
            If Tlp4.Visible = True Then Tlp4.Visible = False
            If Tlp4a.Visible = True Then Tlp4a.Visible = False
            If Tlp4b.Visible = True Then Tlp4b.Visible = False
            If Tlp3.Visible = True Then Tlp3.Visible = False
            Me.Width = 679
            Me.Height = 528
            Me.SplitContainer1.SplitterDistance = 352
            Me.Txtactname.Focus()
            Exit Sub
        End If
        If Tlp4.Visible = True Or Tlp4a.Visible = True Or Tlp4b.Visible = True Then
            Btnfnd.Enabled = False
            Tlp1.Visible = True
            Tlp2.Visible = True
            Btndel.Text = "&Next"
            If Tlp4.Visible = True Then Tlp4.Visible = False
            If Tlp4a.Visible = True Then Tlp4a.Visible = False
            If Tlp4b.Visible = True Then Tlp4b.Visible = False
            Me.Width = 679
            Me.Height = 528
            Me.SplitContainer1.SplitterDistance = 352
        ElseIf Tlp3.Visible = True Then
            Tlp4.Visible = True
            Tlp3.Visible = False
            Btndel.Text = "&Next"
        End If


    End Sub

    Private Sub findrec()

        Try
            Actgrpcmd = New SqlCommand("select splrname,splrid from Finactsplrmstr where splrDelstatus='" & (1) & "'order by splrid ", FinActConn)
            Actrdr = Actgrpcmd.ExecuteReader
            While Actrdr.Read()
                If Actrdr.HasRows = True Then
                    Splrlst = lstvew1.Items.Add(Actrdr("splrname"))
                    Splrlst.SubItems.Add(Actrdr("splrid"))
                End If
            End While
        Catch ex As Exception
            Throw ex
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()

        End Try

    End Sub


    Private Sub Btnclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnclos.Click

        Me.Close()

    End Sub

    Private Sub actmstredit()
        Dim YesNo1, YesNo2, YesNo3, YesNo4, YesNo5, YesNo6 As Integer
        Dim ctyid As Integer
        Dim grupid As Integer
        Alowfinal = True
        Try
            Actgrpcmd = New SqlCommand("select cscid from FinactCscmstr where cscctyname=@city", FinActConn)
            Actgrpcmd.Parameters.AddWithValue("@city", CmbxCty.Text)
            Actrdr = Actgrpcmd.ExecuteReader
            If Trim(CmbxCty.Text) <> "" Then
                Actrdr.Read()
                ctyid = Actrdr("cscid")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try
        Try
            Actgrpcmd = New SqlCommand("select cogrpid from FinactGrupname where cogrupnam=@gname ", FinActConn)
            Actgrpcmd.Parameters.AddWithValue("@gname", CmbxUndrGrup.Text)
            Actrdr = Actgrpcmd.ExecuteReader
            If Trim(CmbxUndrGrup.Text) <> "" Then
                Actrdr.Read()
                grupid = (Actrdr(0))
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try

        Try
            If RBdr.Checked = True Then
                BalType = Trim("Debit")
            ElseIf RBCr.Checked = True Then
                BalType = Trim("Credit")
            End If
            Actgrpcmd = New SqlCommand("finact_splrmstr_adrsmstr_update", FinActConn)
            Actgrpcmd.CommandType = CommandType.StoredProcedure
            Actgrpcmd.Parameters.AddWithValue("@splrid", Splid)
            Actgrpcmd.Parameters.AddWithValue("@splrname", Trim(Txtactname.Text))
            Actgrpcmd.Parameters.AddWithValue("@splrundrgrup", grupid)
            Actgrpcmd.Parameters.AddWithValue("@Splrtype", CmbxActtype.Text)
            Actgrpcmd.Parameters.AddWithValue("@splropnbal", CDbl(Txtopnblnce.Text))
            Actgrpcmd.Parameters.AddWithValue("@splrbaltype", BalType)
            ''If cmbxOnrType.Enabled = True Then
            Actgrpcmd.Parameters.AddWithValue("@splrcostatus", Trim(""))
            Actgrpcmd.Parameters.AddWithValue("@splrcapshare", CDbl(LblPercent.Text))
            '' Else
            Actgrpcmd.Parameters.AddWithValue("@splrcostatus", "none")
            Actgrpcmd.Parameters.AddWithValue("@splrcapshare", CDbl(0.0))
            '' End If
            If CmbxActtype.Text = "Client Ledger" Then
                Actgrpcmd.Parameters.AddWithValue("@splrcrlmt", CDbl(Txtsetlmt.Text))
                Actgrpcmd.Parameters.AddWithValue("@splrpan", txtPan.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrvatno", txtVat.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrcst", txtVat.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrExciseno", txtExcise.Text)
                Actgrpcmd.Parameters.AddWithValue("@splrrank", NumUD.Value)
                If Trim(CmbxInvtVal.Text) = "Yes" Then
                    YesNo1 = 1
                ElseIf Trim(CmbxInvtVal.Text) = "No" Then
                    YesNo1 = 0

                End If
                Actgrpcmd.Parameters.AddWithValue("@splrInvntafect", YesNo1)
                If Trim(CmbxCost.Text) = "Yes" Then
                    YesNo2 = 1
                ElseIf Trim(CmbxCost.Text) = "No" Then
                    YesNo2 = 0

                End If
                Actgrpcmd.Parameters.AddWithValue("@splrcostafect", YesNo2)
                If Trim(CmbxInt.Text) = "Yes" Then
                    YesNo3 = 1
                ElseIf Trim(CmbxInt.Text) = "No" Then
                    YesNo3 = 0

                End If
                Actgrpcmd.Parameters.AddWithValue("@splrIntcal", YesNo3)
                Actgrpcmd.Parameters.AddWithValue("@splrafectdt", 0) 'DtpkrEffct.Value)
                If Trim(Cmbxsertax.Text) = "Yes" Then
                    YesNo4 = 1
                ElseIf (Cmbxsertax.Text) = "No" Then
                    YesNo4 = 0
                End If
                Actgrpcmd.Parameters.AddWithValue("@splrSrtx", YesNo4)
                If Trim(CmbxFbt.Text) = "Yes" Then
                    YesNo5 = 1
                ElseIf Trim(CmbxFbt.Text) = "No" Then
                    YesNo5 = 0

                End If
                Actgrpcmd.Parameters.AddWithValue("@splrFbtapp", YesNo5)
                If Trim(CmbxVat.Text) = "Yes" Then
                    YesNo6 = 1
                ElseIf Trim(CmbxVat.Text) = "No" Then
                    YesNo6 = 0
                End If
                Actgrpcmd.Parameters.AddWithValue("@splrusedvat", YesNo6)
                Actgrpcmd.Parameters.AddWithValue("@splrperofint", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrs1", Txtadrs.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs2", txtadrsarea.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs3", txtadrsland.Text)
                Actgrpcmd.Parameters.AddWithValue("adrsctyid", ctyid)
                Actgrpcmd.Parameters.AddWithValue("@adrspin", txtPin.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsphwork", txtPhwork.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsmoble", Txtmob.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsemail", Txtmail.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsweb", Txtsite.Text)

            ElseIf CmbxActtype.Text = "Cash Book" Or CmbxActtype.Text = "General Account" Then
                Actgrpcmd.Parameters.AddWithValue("@splrcrlmt", 0)

                '' If cmbxOnrType.Enabled = True Then
                Actgrpcmd.Parameters.AddWithValue("@splrpan", txtPan.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs1", Txtadrs.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs2", txtadrsarea.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs3", txtadrsland.Text)
                Actgrpcmd.Parameters.AddWithValue("adrsctyid", ctyid)
                Actgrpcmd.Parameters.AddWithValue("@adrspin", txtPin.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsphwork", txtPhwork.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsmoble", Txtmob.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsemail", Txtmail.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsweb", Txtsite.Text)
                ''Else
                Actgrpcmd.Parameters.AddWithValue("@splrpan", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrs1", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrs2", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrs3", 0)
                Actgrpcmd.Parameters.AddWithValue("adrsctyid", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrspin", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrsphwork", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrsmoble", 0)
                Actgrpcmd.Parameters.AddWithValue("@adrsemail", "")
                Actgrpcmd.Parameters.AddWithValue("@adrsweb", "")
                '' End If
                Actgrpcmd.Parameters.AddWithValue("@splrvatno", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcst", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrExciseno", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrrank", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrInvntafect", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcostafect", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrIntcal", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrafectdt", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrSrtx", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrFbtapp", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrusedvat", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrperofint", 0)

            ElseIf CmbxActtype.Text = "Bank" Then
                Actgrpcmd.Parameters.AddWithValue("@splrcrlmt", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrpan", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrvatno", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcst", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrExciseno", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrrank", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrInvntafect", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrcostafect", 0)
                If Trim(CmbxInt.Text) = "Yes" Then
                    YesNo3 = 1
                ElseIf Trim(CmbxInt.Text) = "No" Then
                    YesNo3 = 0

                End If
                Actgrpcmd.Parameters.AddWithValue("@splrIntcal", YesNo3)
                Actgrpcmd.Parameters.AddWithValue("@splrafectdt", DtpkrEffct.Value)
                Actgrpcmd.Parameters.AddWithValue("@splrSrtx", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrFbtapp", 0)
                Actgrpcmd.Parameters.AddWithValue("@splrusedvat", 0)
                If txtperofcal.Enabled = True And Trim(txtperofcal.Text) <> "" Then
                    Actgrpcmd.Parameters.AddWithValue("@splrperofint", CDbl(txtperofcal.Text))
                Else
                    Actgrpcmd.Parameters.AddWithValue("@splrperofint", 0)
                End If
                Actgrpcmd.Parameters.AddWithValue("@adrs1", Txtadrs.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs2", txtadrsarea.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrs3", txtadrsland.Text)
                Actgrpcmd.Parameters.AddWithValue("adrsctyid", ctyid)
                Actgrpcmd.Parameters.AddWithValue("@adrspin", (txtPin.Text))
                Actgrpcmd.Parameters.AddWithValue("@adrsphwork", (txtPhwork.Text))
                Actgrpcmd.Parameters.AddWithValue("@adrsmoble", (Txtmob.Text))
                Actgrpcmd.Parameters.AddWithValue("@adrsemail", Txtmail.Text)
                Actgrpcmd.Parameters.AddWithValue("@adrsweb", Txtsite.Text)
            End If
            Actgrpcmd.Parameters.AddWithValue("@adrsEdtusrid", Current_UsrId)
            Actgrpcmd.Parameters.AddWithValue("@adrsEdtdt", Now)
            Actgrpcmd.Parameters.AddWithValue("@splrDelstatus", 1)
            Actgrpcmd.Parameters.AddWithValue("@adrsDelstatus", 1)
            Actgrpcmd.Parameters.AddWithValue("@splrEdtusrid", Current_UsrId)
            Actgrpcmd.Parameters.AddWithValue("@splrEdtdt", Now)
            Chk_ProfitShareRatio()
            ''If cmbxOnrType.Enabled = True And Val(LblPercent.Text) > 0 Then
            Dim CurSharRatio As Double = (SharRatio - CurrRatio) + CDbl(LblPercent.Text)

            If CurSharRatio > 100 Then
                Alowfinal = False
                MsgBox("Invalid input! Profit share is exceeded than 100 ", MsgBoxStyle.Critical)
                txtprofit.Focus()
                Exit Sub
                ''eIf Trim(CoStatus) <> Trim(cmbxOnrType.Text) Then
                Alowfinal = False
                MsgBox("Invalid input! OnwerShip is different from earlier saved.", MsgBoxStyle.Critical)
                '' cmbxOnrType.Focus()
                Exit Sub
            End If
            ''End If

            Actgrpcmd.ExecuteNonQuery()
            MsgBox("Record Updated", MsgBoxStyle.Information, "Edit Record")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub Btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndel.Click
        If Tlp1.Visible = True Then
            If ChkExit_Record() = True Then
                MsgBox("Invalid input! System has found a record already existed with the same name.Try another value", MsgBoxStyle.Critical, "Already Existed!")
                Txtsurfix.Focus()
                Txtsurfix.SelectAll()
                Exit Sub
            End If
            If Trim(Txtactname.Text) = "" Or Trim(CmbxUndrGrup.Text) = "" Then
                Txtactname.BackColor = Color.Cyan
                CmbxUndrGrup.BackColor = Color.Cyan
                Txtactname.Focus()
                Txtactname.SelectAll()
                Exit Sub
            Else
                Txtactname.BackColor = Color.White
                CmbxUndrGrup.BackColor = Color.White
                SplrStatus4Shp = False
                If Trim(CmbxActtype.Text) = "Cash Book" Or Trim(CmbxActtype.Text) = "General Account" Then
                    AddEdit_Flag = True
                    actmstrsave_rec()
                    clrvalue()
                    Tlp1.Visible = True
                    Me.Txtsurfix.Focus()
                    Me.Width = 679
                    Me.Height = 528
                    Me.Btndel.Visible = False
                    Me.Btnfnd.Visible = False
                    Tlp2.Visible = True
                    Tlp4.Visible = False
                    Tlp4a.Visible = False
                    Tlp4b.Visible = False
                    Tlp3.Visible = False
                    Exit Sub
                End If
            End If
        End If
        If Tlp4.Visible = True Or Tlp4a.Visible = True Then

            If Trim(Txtadrs.Text) = "" Or Trim(CmbxCty.Text) = "" Then
                If Trim(Txtadrs.Text) = "" Then
                    Txtadrs.BackColor = Color.Cyan
                    Txtadrs.Focus()
                End If
                If Trim(CmbxCty.Text) = "" Then
                    CmbxCty.BackColor = Color.Cyan
                    CmbxCty.Focus()
                End If
                Exit Sub
            Else
                Txtadrs.BackColor = Color.White
                CmbxCty.BackColor = Color.White
            End If
        End If
        If validation_Tlp3() Then
            Exit Sub
        End If

        If validationof_Tlp4b() = True Then
            Exit Sub
        End If

        If Trim(CmbxActtype.Text) = "Customer" Or Trim(CmbxActtype.Text) = "Vendor" Then
            FrmShow_flag(21) = False
            If Tlp3.Visible = True Then
                '  If Btndel.Visible = True Then
                If Trim(Btndel.Text) = "&Save" Then

                    If SplrStatus4Shp = False Then
                        AddEdit_Flag = True
                        actmstrsave_rec()
                        clrvalue()
                        Tlp1.Visible = True
                        Me.Width = 679
                        Me.Height = 528
                        Me.SplitContainer1.SplitterDistance = 351
                        Me.Btndel.Visible = False
                        Me.Btnfnd.Visible = False
                        Tlp2.Visible = True
                        Tlp4.Visible = False
                        Tlp4a.Visible = False
                        Tlp4b.Visible = False
                        Tlp3.Visible = False
                        If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                            Me.Txtsurfix.Focus()
                        Else
                            Me.Txtactname.Clear()
                            Me.Txtactname.Focus()
                        End If
                        Exit Sub
                    Else
                        AddEdit_Flag = True
                        actmstrsave_rec()
                        clrvalue()
                        Exit Sub
                    End If
                End If
            End If
        ElseIf Trim(CmbxActtype.Text) = "Sales Agent" Then
            If Tlp4b.Visible = True Then
                'If Btndel.Visible = True Then
                If Trim(Btndel.Text) = "&Save" Then
                    If SplrStatus4Shp = False Then
                        AddEdit_Flag = True
                        actmstrsave_rec()
                        clrvalue()
                        Me.Width = 679
                        Me.Height = 528
                        Me.SplitContainer1.SplitterDistance = 351
                        Me.Btndel.Visible = False
                        Me.Btnfnd.Visible = False
                        Tlp2.Visible = True
                        Tlp4.Visible = False
                        Tlp4a.Visible = False
                        Tlp4b.Visible = False
                        Tlp3.Visible = False
                        Tlp1.Visible = True
                        If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                            Me.Txtsurfix.Focus()
                        Else
                            Me.Txtactname.Clear()
                            Me.Txtactname.Focus()
                        End If
                        Exit Sub
                    Else
                        AddEdit_Flag = True
                        actmstrsave_rec()
                        clrvalue()
                        Exit Sub
                    End If
                End If
            End If
        ElseIf Trim(CmbxActtype.Text) = "Bank" Then
            If Tlp4.Visible = True Then
                If Trim(Btndel.Text) = "&Save" Then
                    AddEdit_Flag = True
                    actmstrsave_rec()
                    Tlp1.Visible = True
                    clrvalue()
                    Me.Width = 679
                    Me.Height = 528
                    Me.SplitContainer1.SplitterDistance = 351
                    Tlp2.Visible = True
                    Tlp4.Visible = False
                    Tlp4a.Visible = False
                    Tlp4b.Visible = False
                    Tlp3.Visible = False
                    Me.Btndel.Visible = False
                    Me.Btnfnd.Visible = False
                    If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                        Me.Txtsurfix.Focus()
                    Else
                        Me.Txtactname.Clear()
                        Me.Txtactname.Focus()
                    End If
                    Exit Sub
                End If

            End If

        ElseIf Trim(CmbxActtype.Text) = "Share Holder" Then
            If Tlp4a.Visible = True Then
                If Trim(Btndel.Text) = "&Save" Then
                    AddEdit_Flag = True
                    actmstrsave_rec()
                    Tlp1.Visible = True
                    clrvalue()
                    Me.Width = 679
                    Me.Height = 528
                    Me.SplitContainer1.SplitterDistance = 351
                    Tlp2.Visible = True
                    Tlp4.Visible = False
                    Tlp4a.Visible = False
                    Tlp4b.Visible = False
                    Tlp3.Visible = False
                    Me.Btndel.Visible = False
                    Me.Btnfnd.Visible = False
                    If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                        Me.Txtsurfix.Focus()
                    Else
                        Me.Txtactname.Clear()
                        Me.Txtactname.Focus()
                    End If
                    Exit Sub
                End If
            End If
        End If

        If txtprofit.Visible = True Then
            If txtprofit.Value = 0 Then
                txtprofit.Value = 1
            Else
                txtprofit.Value = 0
            End If
        End If


        If Btndel.Enabled = True Then
            Select Case Trim(CmbxActtype.Text)
                Case "Bank"
                    Tlp1.Visible = False
                    Tlp2.Visible = False
                    Tlp4.Visible = False
                    Tlp4a.Visible = False
                    Tlp4b.Visible = False
                    Tlp3.Visible = False
                    Me.Height = 625
                    if_bank_then_tlp4()
                    Me.Tlp4.Location = New System.Drawing.Point(19, 10)
                    Me.Tlp4.Size = New System.Drawing.Size(628, 427)
                    Me.SplitContainer1.SplitterDistance = 450
                    Dim cond As String = "Outer"
                    Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", Me.CmbxCty, cond, "CSCDELSTATUS", CInt(1))
                    Tlp4.Visible = True
                    Btnfnd.Enabled = True
                    Btnfnd.Visible = True
                    Btndel.Text = "&Save"
                    Me.DtpkrEffct.Focus()

                Case "Cash Book"
                    Btndel.Text = "&Save"
                    Btndel.Focus()
                Case "General Ledger"
                    Btndel.Text = "&Save"
                    Btndel.Focus()
                Case "Customer"
                    If Tlp4.Visible = False Then
                        Tlp1.Visible = False
                        Tlp2.Visible = False
                        Tlp4.Visible = False
                        Tlp4a.Visible = False
                        Tlp4b.Visible = False
                        Tlp3.Visible = False
                        Me.Height = 625
                        if_bank_then_tlp4()
                        Me.Tlp4.Location = New System.Drawing.Point(19, 10)
                        Me.Tlp4.Size = New System.Drawing.Size(628, 427)
                        Me.SplitContainer1.SplitterDistance = 450
                        Dim cond As String = ""
                        cond = "Sale"
                        Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", CmbxVatCst, cond, "SPCATDELSTATUS", CInt(1))
                        cond = "Outer"
                        Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", Me.CmbxCty, cond, "CSCDELSTATUS", CInt(1))
                        Tlp4.Visible = True
                        Btnfnd.Enabled = True
                        Btnfnd.Visible = True
                        Btndel.Text = "&Next"
                        Me.DtpkrEffct.Focus()
                    Else
                        Tlp1.Visible = False
                        Tlp2.Visible = False
                        Tlp4.Visible = False
                        Tlp4b.Visible = False
                        Tlp4a.Visible = False
                        Tlp3.Visible = False
                        Me.Height = 625
                        Me.Tlp3.Location = New System.Drawing.Point(10, 10)
                        Me.Tlp3.Size = New System.Drawing.Size(628, 427)
                        Me.SplitContainer1.SplitterDistance = 450
                        Me.SplitContainer1.Panel1.Controls.Add(Me.Tlp3)
                        Dim cond As String = "Sales Agent"
                        Select_2rec_where("splrid", "splrname", "splrtype", "Finactsplrmstr", Cmbxagent, cond, "SPLRDELSTATUS", CInt(1))
                        Me.Cmbxagent.Enabled = True
                        Me.BtnAgent.Enabled = True
                        Me.CmbxPrceLst.Enabled = True
                        Tlp3.Visible = True
                        If_Tlp3_Then()
                        Btnfnd.Enabled = True
                        Btnfnd.Visible = True
                        Btndel.Text = "&Save"
                        Me.CmbxInt.Focus()
                        ''Me.NumUD.Focus()
                        ''Me.NumUD.Select(0, Len(NumUD.Value))
                    End If

                Case "Vendor"
                    If Tlp4.Visible = False Then
                        Tlp1.Visible = False
                        Tlp2.Visible = False
                        Tlp4.Visible = False
                        Tlp4a.Visible = False
                        Tlp4b.Visible = False
                        Tlp3.Visible = False
                        Me.Height = 625
                        if_bank_then_tlp4()
                        Me.Tlp4.Location = New System.Drawing.Point(19, 10)
                        Me.Tlp4.Size = New System.Drawing.Size(628, 427)
                        Me.SplitContainer1.SplitterDistance = 450
                        Dim cond As String = ""
                        cond = "Purchase"
                        Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", CmbxVatCst, cond, "SPCATDELSTATUS", CInt(1))
                        cond = "Outer"
                        Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", Me.CmbxCty, cond, "CSCDELSTATUS", CInt(1))
                        Tlp4.Visible = True
                        Btnfnd.Enabled = True
                        Btnfnd.Visible = True
                        Btndel.Text = "&Next"
                        Me.DtpkrEffct.Focus()
                    Else
                        Tlp1.Visible = False
                        Tlp2.Visible = False
                        Tlp4.Visible = False
                        Tlp4b.Visible = False
                        Tlp4a.Visible = False
                        Tlp3.Visible = False
                        Me.Height = 625
                        Me.Tlp3.Location = New System.Drawing.Point(10, 10)
                        Me.Tlp3.Size = New System.Drawing.Size(628, 427)
                        Me.SplitContainer1.SplitterDistance = 450
                        Me.SplitContainer1.Panel1.Controls.Add(Me.Tlp3)
                        'Dim cond As String = "Sales Agent"
                        'Select_2rec_where("splrid", "splrname", "splrtype", "Finactsplrmstr", Cmbxagent, cond,"SPLRDELSTATUS",CINT(1))
                        Me.Cmbxagent.Enabled = False
                        Me.BtnAgent.Enabled = False
                        Me.CmbxPrceLst.Enabled = False
                        Tlp3.Visible = True
                        If_Tlp3_Then()
                        Btnfnd.Enabled = True
                        Btnfnd.Visible = True
                        Btndel.Text = "&Save"
                        Me.CmbxInt.Focus()
                        ''Me.NumUD.Focus()
                        ''Me.NumUD.Select(0, Len(NumUD.Value))
                    End If

                Case "Share Holder"
                    Tlp1.Visible = False
                    Tlp2.Visible = False
                    Tlp4.Visible = False
                    Tlp4a.Visible = False
                    Tlp4b.Visible = False
                    Tlp3.Visible = False
                    Me.Height = 575
                    If_shareholder_tlp4_then()
                    Me.Tlp4a.Location = New System.Drawing.Point(12, 10)
                    Me.Tlp4a.Size = New System.Drawing.Size(628, 377)
                    Me.SplitContainer1.SplitterDistance = 400
                    Dim cond As String = "Outer"
                    Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", Me.CmbxCty, cond, "CSCDELSTATUS", CInt(1))
                    Tlp4a.Visible = True
                    Btnfnd.Enabled = True
                    Btnfnd.Visible = True
                    Btndel.Text = "&Save"
                    txtPan.Focus()
                    txtPan.SelectAll()
                Case "Sales Agent"
                    Tlp1.Visible = False
                    Tlp2.Visible = False
                    Tlp4.Visible = False
                    Tlp4b.Visible = False
                    Tlp4a.Visible = False
                    Tlp3.Visible = False
                    Me.Height = 700
                    If_SalesAgent_Then_Tlp4b()
                    Me.Tlp4b.Location = New System.Drawing.Point(19, 10)
                    Me.Tlp4b.Size = New System.Drawing.Size(628, 507)
                    Me.SplitContainer1.SplitterDistance = 525
                    Dim cond As String = "Outer"
                    Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", Me.CmbxCty, cond, "CSCDELSTATUS", CInt(1))
                    Tlp4b.Visible = True
                    Btnfnd.Enabled = True
                    Btnfnd.Visible = True
                    Btndel.Text = "&Save"
                    txtPan.Focus()

            End Select

        End If

    End Sub
    Private Sub Btnnew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnnew.Click
        If Btnnew.Text = "&New" Then
            ''AddEdit_Flag = True
            clrvalue()
            Panel1.Enabled = True
            lstvew1.Visible = False
            Btnnew.Text = "&Save"
            Btnfnd.Text = "&Find"
            Txtactname.Focus()
        ElseIf Btnnew.Text = "&Save" Then
            If AddEdit_Flag = True Then
                actmstrsave_rec()
                clrvalue()
            ElseIf AddEdit_Flag = False Then
                actmstredit()
            End If
            If Alowfinal = True Then
                clrvalue()
                Btnnew.Text = "&New"
                Btnfnd.Text = "&Find"
            End If

        End If
        ''End If
        Splid = Nothing
    End Sub

    Private Sub CmbxActtype_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxActtype.Click

        If CmbxActtype.SelectedIndex = -1 Then
            CmbxActtype.SelectedIndex = 0
        End If

    End Sub

    Private Sub CmbxCty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCty.GotFocus
        CmbxCty.DroppedDown = True
        If FrmShow_flag(0) = True Then
            Dim cond As String = "Outer"
            Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", CmbxCty, cond, "CSCDELSTATUS", CInt(1))
            Dim Indxht As Integer = CmbxCty.FindString(IntHtCmMm(0), 0)
            CmbxCty.SelectedIndex = Indxht
        Else
            If CmbxCty.Items.Count > 0 And CmbxCty.SelectedIndex = -1 Then
                CmbxCty.SelectedIndex = 0
            End If

        End If

    End Sub

    Private Sub CmbxCty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCty.Leave
        fetch_rec_statecontry()
        If FrmShow_flag(0) = True Then
            FrmShow_flag(0) = False
            txtPin.Focus()
        End If
    End Sub
    Private Sub CmbxUndrGrup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxUndrGrup.GotFocus

        Try
            CmbxUndrGrup.DroppedDown = True
            If FrmShow_flag(0) = True Then
                fetch_rec_grup()
                Dim Indxht As Integer = CmbxUndrGrup.FindString(IntHtCmMm(0), 0)
                CmbxUndrGrup.SelectedIndex = Indxht
            Else
                ''If CmbxUndrGrup.Items.Count > 0 And CmbxUndrGrup.SelectedIndex = -1 Then
                ''    CmbxUndrGrup.SelectedIndex = 0
                ''End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxActtype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxActtype.GotFocus
        If FrmShow_flag1 = True Then
            Dim IndxX As Integer = CmbxActtype.FindString("Sales Agent", 0)
            CmbxActtype.SelectedIndex = IndxX
            CmbxActtype.Enabled = False
            Exit Sub
        Else
            CmbxActtype.Enabled = True
        End If
        CmbxActtype.DroppedDown = True
        If CmbxActtype.Items.Count > 0 Then
            If CmbxActtype.SelectedIndex = -1 Then
                CmbxActtype.SelectedIndex = 0
            Else
                CmbxActtype_SelectedIndexChanged(sender, e)

            End If
        End If

    End Sub
    Private Sub CmbxActtype_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxActtype.Leave
        If CmbxActtype.SelectedIndex = -1 Then
            CmbxActtype.Focus()
            Exit Sub
        End If
        If Trim(CmbxActtype.Text) = "Share Holder" Then
            If_Type_ShareHolder_Then()
        Else
            If_Type_Bank_Then()
        End If


    End Sub

    Private Sub Txtactname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtactname.GotFocus
        If Trim(Txtactname.Text) <> "" Then
            Txtactname.SelectAll()
        End If
    End Sub

    Private Sub Txtactname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtactname.Leave
        Try
            If Trim(Txtactname.Text) <> "" Then
                Txtactname.BackColor = Color.White
                If ChkExit_Record() = True Then
                    MsgBox("Invalid input! System has found a record already existed with the same name.Try another value", MsgBoxStyle.Critical, "Already Existed!")
                    If Me.Txtsurfix.Visible = True Then
                        Txtsurfix.Focus()
                        Txtsurfix.SelectAll()
                    Else
                        Me.Txtactname.Focus()
                        Me.Txtactname.SelectAll()
                    End If
                    Exit Sub
                End If

            End If
            Me.lstvew1.Visible = False
            Me.lstvew1.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnfnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnfnd.Leave
        If Btnfnd.Text = "&Edit" Then
            AddEdit_Flag = False
            Btnfnd.Text = "&Find"
            Btnnew.Text = "&Save"
        End If
    End Sub

    Private Sub Txtsetlmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtsetlmt.GotFocus
        If Trim(Txtsetlmt.Text) = "" Then
            Txtsetlmt.Text = FormatNumber(0.0, 2)
        End If
    End Sub

    Private Sub Txtsetlmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtsetlmt.Leave ', RBCr.CheckedChanged
        If Trim(Txtsetlmt.Text) <> "" Then
            If IsNumeric(Txtsetlmt.Text) = True Then
                Txtsetlmt.Text = FormatNumber(Txtsetlmt.Text, 2)
                Txtsetlmt.BackColor = Color.White
            Else
                Txtsetlmt.BackColor = Color.Cyan
                Txtsetlmt.Focus()
                Txtsetlmt.SelectAll()
            End If
        End If

    End Sub

    Private Sub Btnnew_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnnew.GotFocus, Btnclos.GotFocus, Btndel.GotFocus, Btnfnd.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Btnnew_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnnew.Leave, Btnclos.Leave, Btndel.Leave, Btnfnd.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.SteelBlue
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCty.KeyDown, contry.KeyDown, Label10.KeyDown, Label11.KeyDown, Btnclos.KeyDown, Btndel.KeyDown, Btnfnd.KeyDown, Btnnew.KeyDown, CmbxActtype.KeyDown, CmbxUndrGrup.KeyDown, Label1.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxUndrGrp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxUndrGrup.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxUndrGrup_Leave(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Opening_Bal_Hndler()
        Dim DrCrType As String = ""
        OpnDrCr = CDbl(0.0)
        OpnDr = CDbl(0.0)
        OpnCr = CDbl(0.0)
        ActOpnCmd = New SqlCommand("SELECT SPLRID,Splrname,SPLROPNBAL,SPLRBALTYPE  FROM FINACTSPLRMSTR WHERE FINACTSPLRMSTR.SPLROPNBAL>0 and finactsplrmstr.splrdelstatus=1  ", FinActConn)
        Try
            ActOpnRdr = ActOpnCmd.ExecuteReader
            While ActOpnRdr.Read
                If ActOpnRdr.HasRows = True Then
                    DrCrType = Trim(ActOpnRdr("splrbaltype"))
                    If DrCrType = "Debit" Then
                        OpnDr += ActOpnRdr("splropnbal")

                    ElseIf DrCrType = "Credit" Then
                        OpnCr += ActOpnRdr("splropnbal")
                    End If
                End If
            End While
            If OpnDr > OpnCr Then
                OpnDrCr = OpnDr - OpnCr
                LblOpnbal.Text = "Dr > Cr   " & FormatNumber(OpnDrCr, 2)
                OpnBalType = "Dr"
            ElseIf OpnCr > OpnDr Then
                OpnDrCr = OpnCr - OpnDr
                LblOpnbal.Text = "Cr > Dr   " & FormatNumber(OpnDrCr, 2)
                OpnBalType = "Cr"
            End If
            If OpnDrCr > 0 Then
                LblOpnbal.BackColor = Color.White
            Else
                LblOpnbal.BackColor = Color.DarkGray
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ActOpnCmd = Nothing
            ActOpnRdr.Close()
        End Try
    End Sub

    Private Sub txtprofit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprofit.GotFocus
        txtprofit.Select(0, Len(txtprofit.Value))
    End Sub
    Private Function Chk_ProfitShareRatio() As Double
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            SharRatio = 0
            ActOpnCmd = New SqlCommand("xChk_ProfitShareRatio_Select ", FinActConn1)
            ActOpnCmd.CommandType = CommandType.StoredProcedure
            Actrdr = ActOpnCmd.ExecuteReader
            While Actrdr.Read
                If Actrdr.HasRows = True Then
                    If Actrdr.IsDBNull(0) = False Then
                        SharRatio += Actrdr(0)
                        CoStatus = Actrdr(1).ToString()
                    End If

                End If
            End While
            Return SharRatio
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ActOpnCmd.Dispose()
            Actrdr.Close()
        End Try
    End Function

    Private Sub Txtopnblnce_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtopnblnce.GotFocus
        Opening_Bal_Hndler()

        If Not (Val(Txtopnblnce.Text)) > 0 Then
            Txtopnblnce.Text = CDbl(FormatNumber(0, 2))
        End If
    End Sub

    Private Sub Txtopnblnce_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtopnblnce.Leave
        If IsNumeric(Txtopnblnce.Text) = False Then
            MsgBox("Only valid numericals are allowed", MsgBoxStyle.Information)
            Txtopnblnce.SelectAll()
            Txtopnblnce.Focus()
            Exit Sub
        Else
            Txtopnblnce.Text = FormatNumber(Txtopnblnce.Text, 2)
        End If
    End Sub

    Private Sub CmbxUndrGrup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxUndrGrup.Leave
        Try
            If Me.CmbxUndrGrup.Text.Trim = "TAX DEDUCTION AT SOURCE (TDS)" Or Me.CmbxUndrGrup.Text.Trim = "VALUE ADDED TAX (VAT INPUT)" _
            Or Me.CmbxUndrGrup.Text.Trim = "CENTRAL SALES TAX (CST)" Or Me.CmbxUndrGrup.Text.Trim = "VALUE ADDED TAX (VAT OUTPUT)" Or Me.CmbxUndrGrup.Text.Trim = "CASH-IN-HAND" Then
                Dim xUGid As Integer = CInt(xDynamic_Find_xAnItem_xInA_Table_1cond("COGRPID", "CogrupNam", Me.CmbxUndrGrup.Text.Trim, "Finactgrupname"))

                If CInt(xDynamic_Find_xAnItem_xInA_Table_1cond("SplrID", "SplrUndrgrup", CInt(xUGid), "Finactsplrmstr")) > 0 Then
                    MsgBox("Invalid input! an account under the current group already existed.", MsgBoxStyle.Critical, Me.Text)
                    Me.CmbxUndrGrup.Focus()
                    Exit Sub
                End If

            End If

            If CheckBlank_Cmbx(Me.CmbxUndrGrup) = True Then
                If FrmShow_flag(24) = True Then  '===For Purchase related Forms
                    Me.CmbxActtype.SelectedIndex = 6
                    Me.CmbxActtype.Enabled = False
                    Exit Sub
                Else
                    Me.CmbxActtype.Enabled = True
                End If

                If FrmShow_flag(5) = True Then
                    Me.CmbxActtype.SelectedIndex = 2
                    Me.CmbxActtype.Enabled = False
                    Exit Sub
                Else
                    Me.CmbxActtype.Enabled = True
                End If
                If CmbxUndrGrup.Items.Count = 0 Then
                    If Trim(CmbxUndrGrup.Text) = "CASH IN HAND" Then
                        Dim ix As Integer = CmbxActtype.FindStringExact("Cash Book", 0)
                        CmbxActtype.SelectedIndex = ix
                        CmbxActtype.Enabled = False
                    ElseIf Trim(CmbxUndrGrup.Text) = "SUNDRY CREDTORS" Then
                        Dim ix As Integer = CmbxActtype.FindStringExact("Vendor", 0)
                        CmbxActtype.SelectedIndex = ix
                        CmbxActtype.Enabled = True
                    ElseIf Trim(CmbxUndrGrup.Text) = "SUNDRY DEBTORS" Then
                        Dim ix As Integer = CmbxActtype.FindStringExact("Customer", 0)
                        CmbxActtype.SelectedIndex = ix
                        CmbxActtype.Enabled = True
                    ElseIf Trim(CmbxUndrGrup.Text) = "CAPITAL ACCOUNT" Then
                        Dim ix As Integer = CmbxActtype.FindStringExact("Share Holder", 0)
                        CmbxActtype.SelectedIndex = ix
                        CmbxActtype.Enabled = True
                    Else
                        CmbxActtype.Enabled = True
                        CmbxActtype.SelectedIndex = 0
                    End If
                End If
                If FrmShow_flag(0) = True Then
                    FrmShow_flag(0) = False
                    ' CmbxActtype.Focus()
                End If
                If FrmShow_flag1 = True Then
                    'CmbxActtype.Focus()
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub


    Private Sub RBdr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBdr.CheckedChanged
        Dim Curbal As Double = CDbl(0.0)
        Dim Finlbal As Double = CDbl(0.0)

        If Val(Txtopnblnce.Text) > 0 And IsNumeric(Txtopnblnce.Text) = True Then
            Curbal = 0
            Curbal = (Txtopnblnce.Text)
        End If

        If RBdr.Checked = True Then
            If OpnBalType = "Cr" Then
                Finlbal = FormatNumber((OpnDrCr - Curbal), 2)
                If Finlbal > OpnDrCr Then
                    LblOpnbal.Text = "Cr > Dr " & FormatNumber(Finlbal, 2)
                Else
                    LblOpnbal.Text = "Dr > Cr " & FormatNumber(Finlbal, 2)
                End If
            ElseIf OpnBalType = "Dr" Then
                Finlbal = FormatNumber((OpnDrCr + Curbal), 2)
                If Finlbal > OpnDrCr Then
                    LblOpnbal.Text = "Dr > Cr " & FormatNumber(Finlbal, 2)
                Else
                    LblOpnbal.Text = "Cr > Dr " & FormatNumber(Finlbal, 2)
                End If
            End If
        Else
            If OpnBalType = "Cr" Then
                Finlbal = FormatNumber((OpnDrCr + Curbal), 2)
                If Finlbal > OpnDrCr Then
                    LblOpnbal.Text = "Cr > Dr " & FormatNumber(Finlbal, 2)
                Else
                    LblOpnbal.Text = "Dr > Cr " & FormatNumber(Finlbal, 2)
                End If
            ElseIf OpnBalType = "Dr" Then
                Finlbal = FormatNumber((OpnDrCr - Curbal), 2)
                If Finlbal > OpnDrCr Then
                    LblOpnbal.Text = "Dr > Cr " & FormatNumber(Finlbal, 2)
                Else
                    LblOpnbal.Text = "Cr > Dr " & FormatNumber(Finlbal, 2)
                End If
            End If
        End If

    End Sub

    Private Sub CmbxActtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxActtype.SelectedIndexChanged
        If CmbxActtype.SelectedIndex <> -1 Then
            If Trim(Txtactname.Text) <> "" Or Trim(CmbxUndrGrup.Text) <> "" Then
                Btndel.Visible = True
                Btndel.Enabled = True
                If Trim(CmbxActtype.Text) = "Cash Book" Or Trim(CmbxActtype.Text) = "General Account" Then
                    Btndel.Text = "&Save"
                Else
                    Btndel.Text = "&Next"

                End If
            Else
                Btndel.Enabled = False
                Btndel.Visible = False
            End If
        End If
    End Sub
    Private Sub If_Type_Bank_Then()
        'Tlp2
        '
        Me.Tlp2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tlp2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.Tlp2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.Tlp2.ColumnCount = 2
        Me.Tlp2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.42857!))
        Me.Tlp2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.57143!))
        Me.Tlp2.Controls.Add(Me.Panel6, 1, 0)
        Me.Tlp2.Controls.Add(Me.Label4, 0, 0)
        Me.Lblpcnt.Enabled = False
        Me.LblPercent.Enabled = False
        Me.txtprofit.Enabled = False
        Me.txtprofit.Value = 0
        Me.LblPercent.Text = 0
        Me.Tlp2.Location = New System.Drawing.Point(10, 214)
        Me.Tlp2.Name = "Tlp2"
        Me.Tlp2.RowCount = 1
        Me.Tlp2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp2.Size = New System.Drawing.Size(628, 55)
        Me.Tlp2.TabIndex = 4
        Me.Tlp2.Visible = True
        Me.Panel7.Enabled = False
        Me.Panel7.Visible = False
        Me.Lblshare.Visible = False
        Me.Txtopnblnce.Focus()

    End Sub

    Private Sub BtnUg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUg.Click
        Dim frmact As New FrmGrupMstr
        FrmShow_flag(0) = True
        frmact.ShowInTaskbar = False
        frmact.ShowDialog()
    End Sub

    Private Sub BtnUg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUg.GotFocus
        If FrmShow_flag(0) = True Then
            CmbxUndrGrup.Focus()
        End If
    End Sub

    Private Sub CmbxUndrGrup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxUndrGrup.SelectedIndexChanged
        Try

            If CmbxUndrGrup.Items.Count > 0 Then
                If Trim(CmbxUndrGrup.Text) = "CASH IN HAND" Then
                    Dim ix As Integer = CmbxActtype.FindStringExact("Cash Book", 0)
                    CmbxActtype.SelectedIndex = ix
                    CmbxActtype.Enabled = False
                ElseIf Trim(CmbxUndrGrup.Text) = "SUNDRY CREDTORS" Then
                    Dim ix As Integer = CmbxActtype.FindStringExact("Vendor", 0)
                    CmbxActtype.SelectedIndex = ix
                    CmbxActtype.Enabled = True
                ElseIf Trim(CmbxUndrGrup.Text) = "SUNDRY DEBTORS" Then
                    Dim ix As Integer = CmbxActtype.FindStringExact("Customer", 0)
                    CmbxActtype.SelectedIndex = ix
                    CmbxActtype.Enabled = True
                ElseIf Trim(CmbxUndrGrup.Text) = "CAPITAL ACCOUNT" Then
                    Dim ix As Integer = CmbxActtype.FindStringExact("Share Holder", 0)
                    CmbxActtype.SelectedIndex = ix
                    CmbxActtype.Enabled = True
                Else
                    CmbxActtype.Enabled = True
                    CmbxActtype.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub If_Type_ShareHolder_Then()
        'Tlp2
        '
        Me.Tlp2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tlp2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.Tlp2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.Tlp2.ColumnCount = 2
        Me.Tlp2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.42857!))
        Me.Tlp2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.57143!))
        Me.Tlp2.Controls.Add(Me.Panel6, 1, 0)
        Me.Tlp2.Controls.Add(Me.Label4, 0, 0)
        Me.Tlp2.Controls.Add(Me.Panel7, 1, 1)
        Me.Tlp2.Controls.Add(Me.Lblshare, 0, 1)
        Me.Lblshare.Visible = True
        Me.Panel7.Visible = True
        Me.Tlp2.Location = New System.Drawing.Point(10, 214)
        Me.Tlp2.Name = "Tlp2"
        Me.Tlp2.RowCount = 2
        Me.Tlp2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp2.Size = New System.Drawing.Size(628, 110)
        Me.Tlp2.TabIndex = 4
        Me.Tlp2.Visible = True
        ChkCoStatus = Trim(xDynamic_Find_xAnItem_xInA_Table_String("CoStatus", "Finactcogatemstr"))
        If Trim(ChkCoStatus) = "Indvl" Then
            Me.Panel7.Enabled = False
            ' Me.Lblpcnt.Enabled = False
            Me.LblPercent.Enabled = False
            Me.txtprofit.Value = 100
            Me.LblPercent.Text = txtprofit.Value
            Me.txtprofit.Enabled = False
            Me.RBCr.Checked = True
        Else
            Me.Panel7.Enabled = True
            Me.Lblpcnt.Enabled = True
            Me.LblPercent.Enabled = True
            Me.txtprofit.Enabled = True
            Me.RBCr.Checked = True

        End If
        Me.Txtopnblnce.Focus()


    End Sub

    Private Sub Btncty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btncty.Click
        Dim frmcty As New FrmCsCMstr
        FrmShow_flag(0) = True
        frmcty.ShowInTaskbar = False
        frmcty.ShowDialog()
    End Sub

    Private Sub Btncty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncty.GotFocus
        If FrmShow_flag(0) = True Then
            CmbxCty.Focus()
        End If
    End Sub

    Private Sub If_shareholder_tlp4_then()
        'Tlp4
        '
        'Me.Tlp4 = New System.Windows.Forms.TableLayoutPanel
        'Me.SplitContainer1.Panel1.Controls.Add(Me.Tlp4)
        Me.Tlp4a.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tlp4a.ColumnCount = 2
        Me.Tlp4a.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.69039!))
        Me.Tlp4a.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.30961!))
        Me.Tlp4a.Controls.Add(lblpan, 0, 0)
        Me.Tlp4a.Controls.Add(Me.txtPan, 1, 0)
        Me.Tlp4a.Controls.Add(Me.Lblstate, 0, 6)
        Me.Tlp4a.Controls.Add(Me.state, 1, 6)
        Me.Tlp4a.Controls.Add(Me.Lblcontry, 0, 7)
        Me.Tlp4a.Controls.Add(Me.Label31, 0, 10)
        Me.Tlp4a.Controls.Add(Me.Txtmail, 1, 10)
        Me.Tlp4a.Controls.Add(Me.contry, 1, 7)
        Me.Tlp4a.Controls.Add(Me.txtPin, 1, 5)
        Me.Tlp4a.Controls.Add(Me.Label14, 0, 5)
        Me.Tlp4a.Controls.Add(Me.Label11, 0, 4)
        Me.Tlp4a.Controls.Add(Me.Label10, 0, 3)
        Me.Tlp4a.Controls.Add(Me.txtadrsland, 1, 3)
        Me.Tlp4a.Controls.Add(Me.txtadrsarea, 1, 2)
        Me.Tlp4a.Controls.Add(Me.Txtadrs, 1, 1)
        Me.Tlp4a.Controls.Add(Me.Label9, 0, 2)
        Me.Tlp4a.Controls.Add(Me.Label8, 0, 1)
        Me.Tlp4a.Controls.Add(Me.Label17, 0, 8)
        Me.Tlp4a.Controls.Add(Me.txtPhwork, 1, 8)
        Me.Tlp4a.Controls.Add(Me.Label32, 0, 11)
        Me.Tlp4a.Controls.Add(Me.Txtsite, 1, 11)
        Me.Tlp4a.Controls.Add(Me.Label33, 0, 9)
        Me.Tlp4a.Controls.Add(Me.Txtmob, 1, 9)
        Me.Tlp4a.Controls.Add(Me.Panel2, 1, 4)
        Me.Tlp4a.Location = New System.Drawing.Point(19, 10)
        Me.Tlp4a.Name = "Tlp4"
        Me.Tlp4a.RowCount = 12
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.088305!))
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4a.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329013!))
        Me.Tlp4a.Size = New System.Drawing.Size(563, 365)
        Me.Tlp4a.TabIndex = 0
        lblpan.Text = "PAN"
        txtPan.Size = New System.Drawing.Size(100, 20)
        txtPan.TextAlign = HorizontalAlignment.Left
        txtPan.MaxLength = 11
        txtPan.TabIndex = 0
        Me.txtPan.Focus()

    End Sub
    Private Sub if_bank_then_tlp4()
        '
        'Tlp4
        '
        'Me.Tlp4 = New System.Windows.Forms.TableLayoutPanel
        'Me.SplitContainer1.Panel1.Controls.Add(Me.Tlp4)
        Me.Tlp4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tlp4.ColumnCount = 2
        Me.Tlp4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.69039!))
        Me.Tlp4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.30961!))
        Me.Tlp4.Controls.Add(Me.DtpkrEffct, 1, 0)
        Me.Tlp4.Controls.Add(Me.Label23, 0, 0)
        If Trim(CmbxActtype.Text) <> "Bank" Then
            Me.Label23.Text = "Opn. Bal. Due Date"
        Else
            Me.Label23.Text = "Effective Date for Reconciliation ?"
        End If
        Me.Tlp4.Controls.Add(Me.Lblstate, 0, 7)
        Me.Tlp4.Controls.Add(Me.state, 1, 7)
        Me.Tlp4.Controls.Add(Me.Lblcontry, 0, 8)
        Me.Tlp4.Controls.Add(Me.Label31, 0, 11)
        Me.Tlp4.Controls.Add(Me.Txtmail, 1, 11)
        Me.Tlp4.Controls.Add(Me.Txtsetlmt, 1, 1)
        Me.Tlp4.Controls.Add(Me.Label22, 0, 1)
        Me.Tlp4.Controls.Add(Me.contry, 1, 8)
        Me.Tlp4.Controls.Add(Me.txtPin, 1, 6)
        Me.Tlp4.Controls.Add(Me.Label14, 0, 6)
        Me.Tlp4.Controls.Add(Me.Label11, 0, 5)
        Me.Tlp4.Controls.Add(Me.Label10, 0, 4)
        Me.Tlp4.Controls.Add(Me.txtadrsland, 1, 4)
        Me.Tlp4.Controls.Add(Me.txtadrsarea, 1, 3)
        Me.Tlp4.Controls.Add(Me.Txtadrs, 1, 2)
        Me.Tlp4.Controls.Add(Me.Label9, 0, 3)
        Me.Tlp4.Controls.Add(Me.Label8, 0, 2)
        Me.Tlp4.Controls.Add(Me.Label17, 0, 9)
        Me.Tlp4.Controls.Add(Me.txtPhwork, 1, 9)
        Me.Tlp4.Controls.Add(Me.Label32, 0, 12)
        Me.Tlp4.Controls.Add(Me.Txtsite, 1, 12)
        Me.Tlp4.Controls.Add(Me.Label33, 0, 10)
        Me.Tlp4.Controls.Add(Me.Txtmob, 1, 10)
        Me.Tlp4.Controls.Add(Me.Panel2, 1, 5)
        Me.Tlp4.Location = New System.Drawing.Point(19, 10)
        Me.Tlp4.Name = "Tlp4"
        Me.Tlp4.RowCount = 13
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.29253!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.088305!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329013!))
        Me.Tlp4.Size = New System.Drawing.Size(563, 365)
        Me.Tlp4.TabIndex = 0
        Me.DtpkrEffct.Focus()
    End Sub

    Private Sub BtnUg_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUg.MouseHover
        Me.Label3.Text = "Click me to create new group"
    End Sub

    Private Sub BtnUg_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUg.MouseLeave
        Me.Label3.Text = ""
    End Sub


    Private Sub If_Tlp3_Then()
        Me.CmbxCost.SelectedIndex = 1
        Me.CmbxCost.SelectedIndex = 1
        Me.CmbxFbt.SelectedIndex = 1
        Me.CmbxInvtVal.SelectedIndex = 1
        Me.CmbxVat.SelectedIndex = 1
        Me.Cmbxsertax.SelectedIndex = 1
        Me.CmbxInt.SelectedIndex = 1
        Me.CmbxIncenType.SelectedIndex = 0
    End Sub

    Private Sub txtperofcal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtperofcal.Leave
        If Trim(txtperofcal.Text) <> "" Then
            If IsNumeric(txtperofcal.Text) = True Then
                txtperofcal.Text = FormatNumber(txtperofcal.Text, 3)
                txtperofcal.BackColor = Color.White
            Else
                MsgBox("Invalid Input! Only numbers are allowed.", MsgBoxStyle.Critical, "Invalid!")
                txtperofcal.Focus()
                txtperofcal.SelectAll()
            End If
        End If
    End Sub

    Private Sub Txtdis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtdis.Leave, TextBox1.Leave
        If Trim(Txtdis.Text) <> "" Then
            If IsNumeric(Txtdis.Text) = True Then
                Txtdis.Text = FormatNumber(Txtdis.Text, 3)
                Txtdis.BackColor = Color.White
            Else
                MsgBox("Invalid Input! Only numbers are allowed.", MsgBoxStyle.Critical, "Invalid!")
                Txtdis.Focus()
                Txtdis.SelectAll()

            End If

        End If
    End Sub

    Private Sub txtIncenTar_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncenTar.Leave
        If Trim(txtIncenTar.Text) <> "" Then
            If IsNumeric(txtIncenTar.Text) = True Then
                txtIncenTar.Text = FormatNumber(txtIncenTar.Text, 2)
                txtIncenTar.BackColor = Color.White
            Else
                MsgBox("Invalid Input!, Only numbers are allowed.", MsgBoxStyle.Critical, "Invalid!")
                txtIncenTar.Focus()
                txtIncenTar.SelectAll()
            End If
        End If
    End Sub

    Private Sub TxtIncenval_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIncenval.Leave
        If Not Val(txtIncenTar.Text) > 0 Then
            TxtIncenval.Text = 0.0
            Exit Sub
        End If
        If Trim(TxtIncenval.Text) <> "" Then
            If IsNumeric(TxtIncenval.Text) = True Then
                If Trim(CmbxIncenType.Text) = "Percentage" Then
                    TxtIncenval.Text = FormatNumber(TxtIncenval.Text, 3)
                Else
                    TxtIncenval.Text = FormatNumber(TxtIncenval.Text, 2)
                End If
            Else
                MsgBox("Invaid input! Only numbers are allowed", MsgBoxStyle.Critical, "Alphabet are not valid input")
                TxtIncenval.Focus()
                TxtIncenval.SelectAll()
            End If
        End If
    End Sub

    Private Sub If_SalesAgent_Then_Tlp4b()
        Me.TxtIncenval.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  ), System.Windows.Forms.AnchorStyles)
        Me.CmbxIncenType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                            ), System.Windows.Forms.AnchorStyles)
        Me.txtIncenTar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                           ), System.Windows.Forms.AnchorStyles)

        Me.Tlp4b.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tlp4b.ColumnCount = 2
        Me.Tlp4b.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.69039!))
        Me.Tlp4b.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.30961!))
        Me.Tlp4b.Controls.Add(lblpan, 0, 0)
        Me.Tlp4b.Controls.Add(Me.txtPan, 1, 0)
        Me.txtPan.TabIndex = 0
        Me.Tlp4b.Controls.Add(Me.Label12, 0, 1)
        Me.Label12.Text = "Commission [%]"
        Me.Tlp4b.Controls.Add(Me.Txtdis, 1, 1)
        Me.Txtdis.TabIndex = 1
        Me.Tlp4b.Controls.Add(Me.Label30, 0, 2)
        Me.Label30.Text = "Sale Target"
        Me.Tlp4b.Controls.Add(Me.txtIncenTar, 1, 2)
        Me.txtIncenTar.TabIndex = 2
        Me.Tlp4b.Controls.Add(Me.Label34, 0, 3)
        Me.Label34.Text = "Type"
        Me.Tlp4b.Controls.Add(Me.CmbxIncenType, 1, 3)
        Me.CmbxIncenType.TabIndex = 3
        Me.Tlp4b.Controls.Add(Me.Label35, 0, 4)
        Me.Label35.Text = "Incentive"
        Me.Tlp4b.Controls.Add(Me.TxtIncenval, 1, 4)
        Me.TxtIncenval.TabIndex = 4
        Me.Tlp4b.Controls.Add(Me.Lblstate, 0, 10)
        Me.Tlp4b.Controls.Add(Me.state, 1, 10)
        Me.Tlp4b.Controls.Add(Me.Lblcontry, 0, 11)
        Me.Tlp4b.Controls.Add(Me.Label31, 0, 14)
        Me.Tlp4b.Controls.Add(Me.Txtmail, 1, 14)
        Me.Txtmail.TabIndex = 14
        Me.Tlp4b.Controls.Add(Me.contry, 1, 11)
        Me.Tlp4b.Controls.Add(Me.txtPin, 1, 9)
        Me.txtPin.TabIndex = 9
        Me.Tlp4b.Controls.Add(Me.Label14, 0, 9)
        Me.Tlp4b.Controls.Add(Me.Label11, 0, 8)
        Me.Tlp4b.Controls.Add(Me.Label10, 0, 7)
        Me.Tlp4b.Controls.Add(Me.txtadrsland, 1, 7)
        Me.txtadrsland.TabIndex = 7
        Me.Tlp4b.Controls.Add(Me.txtadrsarea, 1, 6)
        Me.txtadrsarea.TabIndex = 6
        Me.Tlp4b.Controls.Add(Me.Txtadrs, 1, 5)
        Me.Txtadrs.TabIndex = 5
        Me.Tlp4b.Controls.Add(Me.Label9, 0, 6)
        Me.Tlp4b.Controls.Add(Me.Label8, 0, 5)
        Me.Tlp4b.Controls.Add(Me.Label17, 0, 12)
        Me.Tlp4b.Controls.Add(Me.txtPhwork, 1, 12)
        Me.txtPhwork.TabIndex = 12
        Me.Tlp4b.Controls.Add(Me.Label32, 0, 15)
        Me.Tlp4b.Controls.Add(Me.Txtsite, 1, 15)
        Me.Txtsite.TabIndex = 15
        Me.Tlp4b.Controls.Add(Me.Label33, 0, 13)
        Me.Tlp4b.Controls.Add(Me.Txtmob, 1, 13)
        Me.Tlp4b.Controls.Add(lblagntadrs, 0, 16)
        lblagntadrs.Text = "Credit Limit"
        Me.Tlp4b.Controls.Add(Me.TtxtSaleAgnt, 1, 16)
        Me.TtxtSaleAgnt.Text = ""
        Me.TtxtSaleAgnt.Size = New System.Drawing.Point(200, 20)
        Me.TtxtSaleAgnt.MaxLength = 18
        Me.TtxtSaleAgnt.TabIndex = 16
        Me.TtxtSaleAgnt.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtmob.TabIndex = 13
        Me.Tlp4b.Controls.Add(Me.Panel2, 1, 8)
        Me.Panel2.TabIndex = 8
        Me.Tlp4b.Location = New System.Drawing.Point(19, 10)
        Me.Tlp4b.Name = "Tlp4"
        Me.Tlp4b.RowCount = 17
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.088305!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329013!))
        Me.Tlp4b.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.329014!))
        Me.Tlp4b.Size = New System.Drawing.Size(563, 365)
        Me.Tlp4b.TabIndex = 0
        lblpan.Text = "PAN"
        txtPan.Size = New System.Drawing.Size(100, 20)
        Me.txtIncenTar.Size = New System.Drawing.Size(150, 20)
        txtPan.TextAlign = HorizontalAlignment.Left
        txtPan.MaxLength = 11
        txtPan.TabIndex = 0
        Me.txtPan.Focus()
    End Sub

    Private Sub NudNetday_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles NudNetday.Leave
        If NudNetday.Value < Nuddays.Value Then
            MsgBox("Discount Days should be less or equal to net days", MsgBoxStyle.Critical, "Discount Days Error")
            Me.NudNetday.Focus()
            Me.NudNetday.Select(0, Len(NudNetday.Value))

        End If
    End Sub

    Private Sub Cmbxagent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxagent.GotFocus
        Cmbxagent.DroppedDown = True
        If FrmShow_flag1 = True Then
            Dim cond As String = "Sales Agent"
            Select_2rec_where("splrid", "splrname", "splrtype", "Finactsplrmstr", Cmbxagent, cond, "SPLRDELSTATUS", CInt(1))
            Dim Indxht As Integer = Cmbxagent.FindString(StrCmbxAgent, 0)
            Cmbxagent.SelectedIndex = Indxht
        Else
            If Cmbxagent.Items.Count > 0 And Cmbxagent.SelectedIndex = -1 Then
                Cmbxagent.SelectedIndex = 0
            End If

        End If
    End Sub

    Private Sub Cmbxagent_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxagent.Leave
        If Trim(Cmbxagent.Text) <> "" Then
            Cmbxagent.BackColor = Color.White
        End If
        If FrmShow_flag1 = True Then
            FrmShow_flag1 = False
            BtnCont.Focus()
        End If
    End Sub

    Private Sub BtnAgent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgent.Click
        Dim frmagent As New FrmActMstr
        frmagent.ShowInTaskbar = False
        FrmShow_flag1 = True
        frmagent.ShowDialog()

    End Sub

    Private Sub BtnAgent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAgent.GotFocus
        If FrmShow_flag1 = True Then
            Cmbxagent.Focus()
        End If
    End Sub

    Private Sub BtnDeladrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeladrs.Click
        If validation_Tlp3() Then
            Exit Sub
        End If
        If SplrStatus4Shp = False Then
            If MessageBox.Show("Would you like to save current record?", "Save this first", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SplrStatus4Shp = True
                Me.Btndel_Click(sender, e)
            Else
                Return
            End If
        End If
        Dim frmShpadrs As New FrmShipadrs
        frmShpadrs.ShowInTaskbar = False
        frmShpadrs.ShowDialog()
        Me.Left = 100
        Me.Top = 0

    End Sub

    Private Function validation_Tlp3() As Boolean
        If Tlp3.Visible = True Then
            If Trim(CmbxActtype.Text) = "Customer" Then
                Dim CustX As Integer
                If Me.Cmbxagent.Items.Count > 0 And Me.Cmbxagent.SelectedIndex = -1 Then
                    Cmbxagent.BackColor = Color.Cyan
                    Cmbxagent.Focus()
                    CustX += 1
                ElseIf Not Me.Cmbxagent.Items.Count > 0 Then
                    Cmbxagent.BackColor = Color.Cyan
                    Cmbxagent.Focus()
                    CustX += 1
                End If
                If Me.CmbxVatCst.Items.Count > 0 And Me.CmbxVatCst.SelectedIndex = -1 Then
                    CmbxVatCst.BackColor = Color.Cyan
                    CmbxVatCst.Focus()
                    CustX += 1
                ElseIf Not Me.CmbxVatCst.Items.Count > 0 Then
                    CmbxVatCst.BackColor = Color.Cyan
                    CmbxVatCst.Focus()
                    CustX += 1
                End If
                If CustX <> 0 Then
                    Return True
                Else
                    Return False
                End If

            ElseIf Trim(CmbxActtype.Text) = "Vendor" Then

                If Me.CmbxVatCst.Items.Count > 0 And Me.CmbxVatCst.SelectedIndex = -1 Then
                    CmbxVatCst.BackColor = Color.Cyan
                    CmbxVatCst.Focus()
                    Return True
                ElseIf Not Me.CmbxVatCst.Items.Count > 0 Then
                    CmbxVatCst.BackColor = Color.Cyan
                    CmbxVatCst.Focus()
                    Return True
                Else
                    Return False
                End If
            End If
        End If

    End Function

    Private Sub BtnCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCont.Click
        If validation_Tlp3() Then
            Exit Sub
        End If
        If SplrStatus4Shp = False Then
            If MessageBox.Show("Would you like to save current record?", "Save this first", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SplrStatus4Shp = True
                Me.Btndel_Click(sender, e)
            Else
                Return
            End If
        End If

        Me.Left = 50
        Me.Top = 0
        Dim frmCont As New FrmShipConts
        frmCont.ShowInTaskbar = False
        frmCont.ShowDialog()
    End Sub

    Private Sub Btnitematch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnitematch.Click
        If validation_Tlp3() Then
            Exit Sub
        End If
        If FrmShow_flag(21) = True Then
            MsgBox("System found one or more item(s) already attached. It is suggested to use account edit option to add more items", MsgBoxStyle.Information, "Items Already attached")
            Exit Sub
        End If
        If SplrStatus4Shp = False Then
            If MessageBox.Show("Would you like to save current record?", "Save this first", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SplrStatus4Shp = True
                Me.Btndel_Click(sender, e)
            Else
                Return
            End If
        End If
        CurrActType = Trim(Me.CmbxActtype.Text)

        Dim frmAi As New FrmAttachItem
        frmAi.ShowInTaskbar = False
        frmAi.Top = 10
        frmAi.Left = 100
        frmAi.ShowDialog()

    End Sub

    Private Sub btnsrfix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsrfix.Click
        Dim FrmSf As New Frmsrfixmstr
        FrmSf.ShowInTaskbar = False
        FrmShow_flag(0) = True
        FrmSf.ShowDialog()


    End Sub

    Private Sub btnsrfix_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsrfix.GotFocus
        If FrmShow_flag(0) = True Then
            Txtsurfix.Focus() ' it's a combobox
        End If
    End Sub

    Private Sub Txtsurfix_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtsurfix.GotFocus

        ''Txtsurfix.DroppedDown = True
        ''If FrmShow_flag(0) = True Then
        ''    Fill_Combobox_WitoutDelStatus("srfixid", "Srfixname", "Finact_srfixmstr", Txtsurfix)
        ''    Dim Indxx As Integer = Txtsurfix.FindString(Surfix4Cmbx(0), 0)
        ''    Txtsurfix.SelectedIndex = Indxx
        ''Else
        ''    If Txtsurfix.Items.Count > 0 And Txtsurfix.SelectedIndex = -1 Then
        ''        Txtsurfix.SelectedIndex = 0
        ''    End If

        ''End If

    End Sub

    Private Sub Txtsurfix_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtsurfix.Leave
        Try
            If Trim(Me.Txtsurfix.Text) = "" Then
                Me.Txtsurfix.Focus()
                Exit Sub
            End If
            If FrmShow_flag(0) = True Then
                FrmShow_flag(0) = False
                Txtactname.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ChkExit_Record() As Boolean
        Try
            Findcmd = New SqlCommand("Select splrname from finactsplrmstr where splrname=@name", FinActConn)
            Findcmd.Parameters.AddWithValue("@name", Trim(Txtactname.Text.Trim))
            '  Findcmd.Parameters.AddWithValue("@surfix", Trim(Txtsurfix.SelectedValue))
            FindRdr = Findcmd.ExecuteReader
            FindRdr.Read()
            If FindRdr.HasRows = True Then
                If FindRdr.IsDBNull(0) = False Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            Findcmd.Dispose()
            FindRdr.Close()
        End Try
    End Function
    Private Sub ttxtsaleagnt_leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TtxtSaleAgnt.Leave
        If Trim(TtxtSaleAgnt.Text) <> "" Then
            If IsNumeric(TtxtSaleAgnt.Text) = False Then
                MsgBox("Invalid input! Only number are allowed", MsgBoxStyle.Critical, "Alphabet not allowed")
                TtxtSaleAgnt.Focus()
                TtxtSaleAgnt.SelectAll()
                TtxtSaleAgnt.BackColor = Color.Cyan
            Else
                TtxtSaleAgnt.BackColor = Color.White
                TtxtSaleAgnt.Text = FormatNumber(TtxtSaleAgnt.Text, 2)
            End If
        End If
    End Sub
    Private Function validationof_Tlp4b() As Boolean
        Dim TindX As Integer = 0
        If Tlp4b.Visible = True Then
            If Trim(TtxtSaleAgnt.Text) = "" Then
                TtxtSaleAgnt.BackColor = Color.Cyan
                TindX += 1
                TtxtSaleAgnt.Focus()
            Else
                TtxtSaleAgnt.BackColor = Color.White
            End If

            If Trim(CmbxCty.Text) = "" Then
                CmbxCty.BackColor = Color.Cyan
                TindX += 1
                CmbxCty.Focus()
            Else
                CmbxCty.BackColor = Color.White
            End If

            If Trim(Txtadrs.Text) = "" Then
                Txtadrs.BackColor = Color.Cyan
                TindX += 1
                Txtadrs.Focus()
            Else
                Txtadrs.BackColor = Color.White
            End If

            If Trim(Txtdis.Text) = "" Or Not (Val(Txtdis.Text)) > 0 Then
                Txtdis.BackColor = Color.Cyan
                TindX += 1
                Txtdis.Focus()
                Txtdis.SelectAll()
            Else
                Txtdis.BackColor = Color.White
            End If

            If TindX <> 0 Then
                TindX = 0
                Return True
            Else
                Return False
            End If

        End If
    End Function

    Private Sub txtPin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPin.KeyPress
        Dim chr As Char = e.KeyChar
        If e.KeyChar = "." Or e.KeyChar = "-" Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtPin_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPin.Leave
        If Trim(txtPin.Text) <> "" Then
            If IsNumeric(txtPin.Text) = False Then
                MsgBox("Invalid input!, Only Numbers are allowed", MsgBoxStyle.Critical, "Alphabet not allowed")
                txtPin.Focus()
                txtPin.SelectAll()
            Else

            End If
        End If
    End Sub

    Private Sub Txtadrs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtadrs.Leave
        If Trim(Txtadrs.Text) <> "" Then
            Txtadrs.BackColor = Color.White
        End If
    End Sub

    Private Sub BtnVatCst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVatCst.Click
        Dim frmvat As New FrmSalePurCatgry
        frmvat.ShowInTaskbar = False
        FrmShow_flag(10) = True
        frmvat.ShowDialog()
    End Sub

    Private Sub BtnVatCst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVatCst.GotFocus
        If FrmShow_flag(10) = True Then
            Me.CmbxVatCst.Focus()
        End If
    End Sub

    Private Sub CmbxVatCst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxVatCst.GotFocus
        CmbxVatCst.DroppedDown = True
        Dim cond As String = ""
        If FrmShow_flag(10) = True Then
            If Me.CmbxActtype.Text = "Customer" Then
                cond = "Sale"
            ElseIf Me.CmbxActtype.Text = "Vendor" Then
                cond = "Purchase"
            End If
            Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", CmbxVatCst, cond, "SPCATDELSTATUS", CInt(1))
            Dim Indxht As Integer = CmbxVatCst.FindString(IntHtCmMm(10), 0)
            CmbxVatCst.SelectedIndex = Indxht
        Else
            If CmbxVatCst.Items.Count > 0 And CmbxVatCst.SelectedIndex = -1 Then
                CmbxVatCst.SelectedIndex = 0
            End If

        End If
    End Sub
    Private Sub CmbxVatCst_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxVatCst.Leave
        If Trim(CmbxVatCst.Text) <> "" Then
            CmbxVatCst.BackColor = Color.White
        End If
        If FrmShow_flag(10) = True Then
            FrmShow_flag(10) = False
            Cmbxagent.Focus()
        End If
    End Sub

    Private Sub CmbxVatCst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxVatCst.SelectedIndexChanged

    End Sub

    Private Sub CmbxPrceLst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPrceLst.GotFocus
        Try
            Me.CmbxPrceLst.DroppedDown = True
            If Me.CmbxPrceLst.Items.Count > 0 Then
                If Me.CmbxPrceLst.SelectedIndex = -1 Then
                    Me.CmbxPrceLst.SelectedIndex = 0
                End If
                EfctDate_Select_AcMstr()
            Else
                Fill_Combobox("spl_id", "spl_name", "Finact_salepricelstmstr", "SPl_DELSTATUS", CInt(1), Me.CmbxPrceLst)
                If Me.CmbxPrceLst.Items.Count > 0 Then
                    EfctDate_Select_AcMstr()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EfctDate_Select_AcMstr()
        Try
            Findcmd = New SqlCommand("Finact_salepricelstMstr_SelectEfecteddate", FinActConn1)
            Findcmd.CommandType = CommandType.StoredProcedure
            Findcmd.Parameters.AddWithValue("@splmastrid", Me.CmbxPrceLst.SelectedValue)
            FindRdr = Findcmd.ExecuteReader
            While FindRdr.Read
                If FindRdr.IsDBNull(0) = False Then
                    Me.LblEdt.Text = Format(FindRdr(1), "dd/MM/yyyy")
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Findcmd.Dispose()
            FindRdr.Close()

        End Try
    End Sub

    Private Sub CmbxPrceLst_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPrceLst.SelectionChangeCommitted
        Try
            EfctDate_Select_AcMstr()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCarri_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.GotFocus
        Try
            CmbxCarri.DroppedDown = True
            If FrmShow_flag(7) = True Then
                Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)
                Dim IntCari As Integer = CmbxCarri.FindString(IntHtCmMm(7), 0)
                CmbxCarri.SelectedIndex = IntCari
            Else
                If CmbxCarri.Items.Count > 0 And CmbxCarri.SelectedIndex = -1 Then
                    CmbxCarri.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxCarri_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.Leave
        Try
            If FrmShow_flag(7) = True Then
                FrmShow_flag(7) = False
            End If
            Me.Btndel.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCarri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCarri.Click
        Try
            Dim frmcaria As New FrmCarriermstr
            frmcaria.ShowInTaskbar = False
            FrmShow_flag(7) = True
            frmcaria.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCarri_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCarri.GotFocus
        If FrmShow_flag(7) = True Then
            Me.CmbxCarri.Focus()
        End If
    End Sub

    Private Sub CmbxInt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxInt.GotFocus
        Try
            Me.CmbxInt.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxIncenType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxIncenType.GotFocus
        Try
            If Me.CmbxIncenType.SelectedIndex = -1 Then
                Me.CmbxIncenType.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxInvtVal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxInvtVal.GotFocus
        Try
            Me.CmbxInvtVal.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxVat_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxVat.GotFocus
        Try
            Me.CmbxVat.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub


    Private Sub AllControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtprofit.KeyDown, CmbxActtype.KeyDown, Cmbxagent.KeyDown, CmbxCarri.KeyDown, CmbxCost.KeyDown, CmbxCty.KeyDown, CmbxFbt.KeyDown, CmbxInt.KeyDown, CmbxPrceLst.KeyDown, CmbxUndrGrup.KeyDown, CmbxVat.KeyDown, CmbxVatCst.KeyDown, DtpkrEffct.KeyDown, Nuddays.KeyDown, NudNetday.KeyDown, NumUD.KeyDown, TtxtSaleAgnt.KeyDown, Txtactname.KeyDown, Txtadrs.KeyDown, txtadrsarea.KeyDown, txtadrsland.KeyDown, Txtcontperson.KeyDown, Txtdis.KeyDown, txtExcise.KeyDown, txtIncenTar.KeyDown, TxtIncenval.KeyDown, Txtmail.KeyDown, Txtmob.KeyDown, Txtopnblnce.KeyDown, txtPan.KeyDown, txtPan.KeyDown, txtperofcal.KeyDown, txtPhwork.KeyDown, txtPin.KeyDown, txtprofit.KeyDown, Txtsetlmt.KeyDown, Txtsite.KeyDown, Txtsurfix.KeyDown, txtVat.KeyDown, TextBox1.KeyDown, CmbxIncenType.KeyDown, CmbxInvtVal.KeyDown, Cmbxsertax.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RBCr_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RBCr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                ' Me.RBCr.SelectNextControl(CType(sender, Control), False, True, True, True)
                If Me.CmbxActtype.SelectedIndex = 5 Then
                    Dim xCapVal As Double = 0
                    Me.NumUD.Value = Chk_ProfitShareRatio()
                    Me.NumUD.Focus()
                Else
                    Me.Btndel.Focus()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub RBdr_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RBdr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                'Me.RBdr.SelectNextControl(CType(sender, Control), False, True, True, True)
                Me.RBCr.Focus()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtsite_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtsite.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Txtsite.SelectNextControl(CType(sender, Control), False, True, True, True)
                Me.Btnfnd.Focus()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxPrceLst_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPrceLst.Leave
        Try
            Me.CmbxPrceLst.DroppedDown = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxInt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxInt.Leave
        Try
            If Me.CmbxInt.SelectedIndex = 0 Then
                Me.txtperofcal.Enabled = True
                Me.txtperofcal.Focus()
            Else
                Me.txtperofcal.Enabled = False
                Me.NumUD.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxVat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxVat.Leave
        Try
            If Me.CmbxVat.SelectedIndex = 1 Then
                Me.txtVat.Text = "UN-REGD"
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub txtVat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVat.Leave
        Try
            If Me.CmbxVat.SelectedIndex = 0 Then
                If Len(Me.txtVat.Text.Trim) = 0 Or Len(Me.txtVat.Text.Trim) <> 11 Then
                    MsgBox("Invalid Input! Valid VAT/CST NO. Required.", MsgBoxStyle.Critical, Me.Text)
                    Me.txtVat.Focus()
                End If
            Else
                Me.txtVat.Text = "UN-REGD"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtactname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtactname.TextChanged
        Try
            If Len(Me.Txtactname.Text.Trim) > 0 Then
                xFillLstVewWith2Recrd(Me.lstvew1, Me.Txtactname.Text.Trim, "Splrid", "SplrName", "FinactSplrMstr", "SplrName")
            Else
                Me.lstvew1.Visible = False
                Me.lstvew1.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class



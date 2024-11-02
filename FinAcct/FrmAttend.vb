Imports System.Data
Imports System.Data.SqlClient
Imports System.math

Public Class FrmAttend
    Inherits System.Windows.Forms.Form

    Dim dgr As DataGridViewRow
    Dim cel As DataGridViewTextBoxCell
    Dim com As DataGridViewCheckBoxCell
    Dim combo, combo1 As New DataGridViewComboBoxCell
    Dim Attd_Sift_Cmd As SqlCommand
    Dim Attd_Sift_Rdr As SqlDataReader
    Dim Attd_Sift_Cmd1 As SqlCommand
    Dim Attd_Sift_Rdr1 As SqlDataReader
    Dim Attd_FullLeve_Cmd As SqlCommand
    Dim Attd_FullLeve_rdr As SqlDataReader
    Dim StrtTime As Date
    Dim EndTime As Date
    ' Private WithEvents dtp As New DateTimePicker
    Dim BrkFrm As Date
    Dim count_FD_rec As Integer
    Friend WithEvents CmbxEmpName As System.Windows.Forms.ComboBox
    Dim BrkTo As Date
    Dim LstEmpName As ListViewItem
    Dim Add_Edit_Flag As Boolean
    Dim Empid As Integer
    Dim Deptid As Integer
    Dim Desiid As Integer
    Dim LstCount As Integer
    Dim DeptName As String
    Dim DesigName As String
    Dim Shift As String
    Dim EmpStatus As String
    Dim cmbxDeptid As Integer
    Dim TotRecrds As Integer
    Dim EId As Integer
    Dim Id As Integer
    Dim curntdt As Date
    Dim Recrds As Integer
    Dim counter As Integer
    Dim counter1 As Integer
    Dim counter_fnd As Integer
    Dim strtmins As Single = 0
    Dim endmins As Single = 0
    Dim frmmins As Single = 0
    Dim repmins As Single = 0
    Dim tomins As Single = 0
    Dim diff As Single = 0
    Dim i As Integer = 0
    Dim FD_Type As String
    Dim res As Single = 0
    Dim res1 As Single = 0
    Dim Caslv As Double
    Dim Sicklv As Double
    Dim Ernlv As Double
    Dim Srtlv As Double
    Dim Mnth As Single
    Dim year As Single
    Dim Totsrtlv As Double
    Dim Totcaslv As Double
    Dim Totsicklv As Double
    Dim Tot_fd_caslv As Double
    Dim Tot_fd_sicklv As Double
    Dim Tot_1hf_caslv As Double
    Dim Tot_1hf_sicklv As Double
    Dim Tot_2hf_caslv As Double
    Dim Tot_2hf_sicklv As Double
    Dim strtdt As Date
    Dim Emlid As Integer
    Dim Dept_Name_Cmd As SqlCommand
    Dim Dept_Name_Rdr As SqlDataReader
    Dim Desig_Name_Cmd As SqlCommand
    Dim Srch_Eid_Cmd As SqlCommand
    Dim Srch_Eid_Rdr As SqlDataReader
    Dim P_Roll_Attd_Cmd As SqlCommand
    Dim P_Roll_Attd_Rdr As SqlDataReader
    Dim offshft As String
    Dim offday As Double
    Dim Fromdt, Todt As Date
    Dim count_offrecrd As Integer
    Dim fetch_offday As Integer
    Dim first_recrd As Integer
    Dim cnfrmmsg As String
    Dim edit_flag As Boolean
    Dim Srt_Levs As Integer = 0

    Dim Strt_Mnth As Integer
    Dim Presnt_Cnt1 As Integer
    Dim Presnt_Cnt2 As Double
    Dim Totl_Presnt As Double
    Dim Fetch_ErnLevs As Double
    Dim Fetch_ErnLevs_FD As Integer
    Dim Fetch_ErnLevs_1HF As Double
    Dim Fetch_ErnLevs_2HF As Double
    Dim ErnLevs As Integer
    Dim ErnLev_Type As String
    Dim Lev_flag As Boolean

    Dim hrs, mins As String
    Dim a As Integer
    Dim str As String
    Dim tm As String
    Dim secs As String
    Dim max_date As Date
    Dim min_date As Date
    Dim sel_flag As Boolean = False
    Dim dtval As Date
    Dim Attd_Sift_Cmd2 As SqlCommand
    Dim Attd_Sift_Rdr2 As SqlDataReader
    Dim FD_Levdt As Date
    Dim FD_LevFrm As Date
    Dim FD_Levto As Date
    Dim FD_Categ As String
    Dim FD_Id As Integer
    Dim FD_flag As Boolean = False
    Dim max_Levdt As Date


    Friend WithEvents RbAll As System.Windows.Forms.RadioButton
    Friend WithEvents CmbxDept As System.Windows.Forms.ComboBox
    Friend WithEvents PnlFnd As System.Windows.Forms.Panel
    Friend WithEvents RBEid As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RBOrdEname As System.Windows.Forms.RadioButton
    Friend WithEvents RBOrdDept As System.Windows.Forms.RadioButton
    Friend WithEvents BtnLeave As System.Windows.Forms.Button
    Friend WithEvents BtnAbsnt As System.Windows.Forms.Button
    Friend WithEvents BtnPresnt As System.Windows.Forms.Button
    Friend WithEvents BtnLate As System.Windows.Forms.Button
    Friend WithEvents BtnFnd As System.Windows.Forms.Button
    Friend WithEvents LblLine As System.Windows.Forms.Label
    Friend WithEvents Cmbxsift1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblSft As System.Windows.Forms.Label
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents PnlOrdr As System.Windows.Forms.Panel
    Friend WithEvents PnlTotEmp As System.Windows.Forms.Panel
    Friend WithEvents LblHfLeve As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblFDLeve As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents PnlLate As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnLateCncl As System.Windows.Forms.Button
    Friend WithEvents BtnLateOk As System.Windows.Forms.Button
    Friend WithEvents BtnHoliday As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents CmbxOptn As System.Windows.Forms.ComboBox
    Friend WithEvents GrpBxOptn As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGrpCncl As System.Windows.Forms.Button
    Friend WithEvents BtnGrpOk As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbxshft As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents CmbxDays As System.Windows.Forms.ComboBox
    Friend WithEvents DtpkrTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpkrFrm As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PnlErnLev As System.Windows.Forms.Panel
    Friend WithEvents BtnOkErn As System.Windows.Forms.Button
    Friend WithEvents BtnCnclErn As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents RbFDErn As System.Windows.Forms.RadioButton
    Friend WithEvents Rb2HFErn As System.Windows.Forms.RadioButton
    Friend WithEvents Rb1HFErn As System.Windows.Forms.RadioButton
    Friend WithEvents DtTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents PnlReprtLate As System.Windows.Forms.Panel
    Friend WithEvents RbMatrntyLev As System.Windows.Forms.RadioButton
    Friend WithEvents RbErnLev As System.Windows.Forms.RadioButton
    Friend WithEvents Rb2HFLeve As System.Windows.Forms.RadioButton
    Friend WithEvents Rb1HFLeve As System.Windows.Forms.RadioButton
    Friend WithEvents RbFDLeve As System.Windows.Forms.RadioButton
    Friend WithEvents RbShrtLeve As System.Windows.Forms.RadioButton
    Friend WithEvents BtnRptOK As System.Windows.Forms.Button
    Friend WithEvents BtnRptCncl As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Datagrd As System.Windows.Forms.DataGridView
    Friend WithEvents PnlAttd As System.Windows.Forms.Panel
    Friend WithEvents Rball_sel As System.Windows.Forms.RadioButton
    Friend WithEvents Rball_attd As System.Windows.Forms.RadioButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PnlBrkOut As System.Windows.Forms.Panel
    Friend WithEvents RbOut_Sel As System.Windows.Forms.RadioButton
    Friend WithEvents RbOut_All As System.Windows.Forms.RadioButton
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Dim Desig_Name_Rdr As SqlDataReader



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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPrsentAll As System.Windows.Forms.Button
    Friend WithEvents cmbxsift As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblStrtTime As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblEndTime As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblPresnt As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblTotEmpl As System.Windows.Forms.Label
    Friend WithEvents LblAbsnt As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblBrkFrm As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LblBrkTo As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LblShrtLeve As System.Windows.Forms.Label
    Friend WithEvents LblReprtlat As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents BtnabsntAll As System.Windows.Forms.Button
    Friend WithEvents Btnrest As System.Windows.Forms.Button
    Friend WithEvents Btnsve As System.Windows.Forms.Button
    Friend WithEvents Btnclos As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents DtpkrDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents RbDept As System.Windows.Forms.RadioButton
    Friend WithEvents RbEname As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PnlBrkOut = New System.Windows.Forms.Panel
        Me.RbOut_Sel = New System.Windows.Forms.RadioButton
        Me.RbOut_All = New System.Windows.Forms.RadioButton
        Me.Label20 = New System.Windows.Forms.Label
        Me.PnlAttd = New System.Windows.Forms.Panel
        Me.Rball_sel = New System.Windows.Forms.RadioButton
        Me.Rball_attd = New System.Windows.Forms.RadioButton
        Me.Label17 = New System.Windows.Forms.Label
        Me.PnlLate = New System.Windows.Forms.Panel
        Me.DtTime = New System.Windows.Forms.DateTimePicker
        Me.BtnLateCncl = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.BtnLateOk = New System.Windows.Forms.Button
        Me.PnlReprtLate = New System.Windows.Forms.Panel
        Me.RbMatrntyLev = New System.Windows.Forms.RadioButton
        Me.RbErnLev = New System.Windows.Forms.RadioButton
        Me.Rb2HFLeve = New System.Windows.Forms.RadioButton
        Me.Rb1HFLeve = New System.Windows.Forms.RadioButton
        Me.RbFDLeve = New System.Windows.Forms.RadioButton
        Me.RbShrtLeve = New System.Windows.Forms.RadioButton
        Me.BtnRptOK = New System.Windows.Forms.Button
        Me.BtnRptCncl = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Datagrd = New System.Windows.Forms.DataGridView
        Me.BtnHoliday = New System.Windows.Forms.Button
        Me.PnlTotEmp = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblFDLeve = New System.Windows.Forms.Label
        Me.LblHfLeve = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.LblTotEmpl = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LblPresnt = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.LblAbsnt = New System.Windows.Forms.Label
        Me.LblReprtlat = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.LblShrtLeve = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.LblSft = New System.Windows.Forms.Label
        Me.BtnFnd = New System.Windows.Forms.Button
        Me.BtnLate = New System.Windows.Forms.Button
        Me.BtnLeave = New System.Windows.Forms.Button
        Me.BtnAbsnt = New System.Windows.Forms.Button
        Me.BtnPresnt = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbxsift = New System.Windows.Forms.ComboBox
        Me.btnPrsentAll = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnabsntAll = New System.Windows.Forms.Button
        Me.Btnrest = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblStrtTime = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblEndTime = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.LblBrkFrm = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.LblBrkTo = New System.Windows.Forms.Label
        Me.Btnsve = New System.Windows.Forms.Button
        Me.Btnclos = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.PnlErnLev = New System.Windows.Forms.Panel
        Me.BtnOkErn = New System.Windows.Forms.Button
        Me.BtnCnclErn = New System.Windows.Forms.Button
        Me.Label36 = New System.Windows.Forms.Label
        Me.RbFDErn = New System.Windows.Forms.RadioButton
        Me.Rb2HFErn = New System.Windows.Forms.RadioButton
        Me.Rb1HFErn = New System.Windows.Forms.RadioButton
        Me.GrpBxOptn = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cmbxshft = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.CmbxDays = New System.Windows.Forms.ComboBox
        Me.DtpkrTo = New System.Windows.Forms.DateTimePicker
        Me.DtpkrFrm = New System.Windows.Forms.DateTimePicker
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.BtnGrpCncl = New System.Windows.Forms.Button
        Me.BtnGrpOk = New System.Windows.Forms.Button
        Me.PnlFnd = New System.Windows.Forms.Panel
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.PnlOrdr = New System.Windows.Forms.Panel
        Me.RBEid = New System.Windows.Forms.RadioButton
        Me.RBOrdDept = New System.Windows.Forms.RadioButton
        Me.RBOrdEname = New System.Windows.Forms.RadioButton
        Me.BtnOk = New System.Windows.Forms.Button
        Me.Cmbxsift1 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.LblLine = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.RbEname = New System.Windows.Forms.RadioButton
        Me.CmbxDept = New System.Windows.Forms.ComboBox
        Me.RbAll = New System.Windows.Forms.RadioButton
        Me.CmbxEmpName = New System.Windows.Forms.ComboBox
        Me.RbDept = New System.Windows.Forms.RadioButton
        Me.Label31 = New System.Windows.Forms.Label
        Me.DtpkrDt = New System.Windows.Forms.DateTimePicker
        Me.Label28 = New System.Windows.Forms.Label
        Me.CmbxOptn = New System.Windows.Forms.ComboBox
        Me.Panel1.SuspendLayout()
        Me.PnlBrkOut.SuspendLayout()
        Me.PnlAttd.SuspendLayout()
        Me.PnlLate.SuspendLayout()
        Me.PnlReprtLate.SuspendLayout()
        CType(Me.Datagrd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlTotEmp.SuspendLayout()
        Me.PnlErnLev.SuspendLayout()
        Me.GrpBxOptn.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PnlFnd.SuspendLayout()
        Me.PnlOrdr.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PnlBrkOut)
        Me.Panel1.Controls.Add(Me.PnlAttd)
        Me.Panel1.Controls.Add(Me.PnlLate)
        Me.Panel1.Controls.Add(Me.PnlReprtLate)
        Me.Panel1.Controls.Add(Me.Datagrd)
        Me.Panel1.Controls.Add(Me.BtnHoliday)
        Me.Panel1.Controls.Add(Me.PnlTotEmp)
        Me.Panel1.Controls.Add(Me.LblSft)
        Me.Panel1.Controls.Add(Me.BtnFnd)
        Me.Panel1.Controls.Add(Me.BtnLate)
        Me.Panel1.Controls.Add(Me.BtnLeave)
        Me.Panel1.Controls.Add(Me.BtnAbsnt)
        Me.Panel1.Controls.Add(Me.BtnPresnt)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbxsift)
        Me.Panel1.Controls.Add(Me.btnPrsentAll)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BtnabsntAll)
        Me.Panel1.Controls.Add(Me.Btnrest)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LblStrtTime)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.LblEndTime)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.LblBrkFrm)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.LblBrkTo)
        Me.Panel1.Controls.Add(Me.Btnsve)
        Me.Panel1.Controls.Add(Me.Btnclos)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Location = New System.Drawing.Point(6, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(996, 561)
        Me.Panel1.TabIndex = 0
        '
        'PnlBrkOut
        '
        Me.PnlBrkOut.BackColor = System.Drawing.Color.LightCyan
        Me.PnlBrkOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBrkOut.Controls.Add(Me.RbOut_Sel)
        Me.PnlBrkOut.Controls.Add(Me.RbOut_All)
        Me.PnlBrkOut.Controls.Add(Me.Label20)
        Me.PnlBrkOut.Location = New System.Drawing.Point(365, 513)
        Me.PnlBrkOut.Name = "PnlBrkOut"
        Me.PnlBrkOut.Size = New System.Drawing.Size(312, 35)
        Me.PnlBrkOut.TabIndex = 36
        Me.PnlBrkOut.Visible = False
        '
        'RbOut_Sel
        '
        Me.RbOut_Sel.AutoSize = True
        Me.RbOut_Sel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbOut_Sel.Location = New System.Drawing.Point(217, 7)
        Me.RbOut_Sel.Name = "RbOut_Sel"
        Me.RbOut_Sel.Size = New System.Drawing.Size(67, 17)
        Me.RbOut_Sel.TabIndex = 59
        Me.RbOut_Sel.TabStop = True
        Me.RbOut_Sel.Text = "Selected"
        Me.RbOut_Sel.UseVisualStyleBackColor = True
        '
        'RbOut_All
        '
        Me.RbOut_All.AutoSize = True
        Me.RbOut_All.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbOut_All.Location = New System.Drawing.Point(161, 7)
        Me.RbOut_All.Name = "RbOut_All"
        Me.RbOut_All.Size = New System.Drawing.Size(36, 17)
        Me.RbOut_All.TabIndex = 58
        Me.RbOut_All.TabStop = True
        Me.RbOut_All.Text = "All"
        Me.RbOut_All.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.LightCyan
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(22, 4)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(162, 20)
        Me.Label20.TabIndex = 25
        Me.Label20.Text = "Mark Break Time:-"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnlAttd
        '
        Me.PnlAttd.BackColor = System.Drawing.Color.LightCyan
        Me.PnlAttd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlAttd.Controls.Add(Me.Rball_sel)
        Me.PnlAttd.Controls.Add(Me.Rball_attd)
        Me.PnlAttd.Controls.Add(Me.Label17)
        Me.PnlAttd.Location = New System.Drawing.Point(8, 465)
        Me.PnlAttd.Name = "PnlAttd"
        Me.PnlAttd.Size = New System.Drawing.Size(404, 35)
        Me.PnlAttd.TabIndex = 34
        Me.PnlAttd.Visible = False
        '
        'Rball_sel
        '
        Me.Rball_sel.AutoSize = True
        Me.Rball_sel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rball_sel.Location = New System.Drawing.Point(217, 7)
        Me.Rball_sel.Name = "Rball_sel"
        Me.Rball_sel.Size = New System.Drawing.Size(67, 17)
        Me.Rball_sel.TabIndex = 59
        Me.Rball_sel.TabStop = True
        Me.Rball_sel.Text = "Selected"
        Me.Rball_sel.UseVisualStyleBackColor = True
        '
        'Rball_attd
        '
        Me.Rball_attd.AutoSize = True
        Me.Rball_attd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rball_attd.Location = New System.Drawing.Point(161, 7)
        Me.Rball_attd.Name = "Rball_attd"
        Me.Rball_attd.Size = New System.Drawing.Size(36, 17)
        Me.Rball_attd.TabIndex = 58
        Me.Rball_attd.TabStop = True
        Me.Rball_attd.Text = "All"
        Me.Rball_attd.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightCyan
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(22, 4)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(162, 20)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "Mark Break OutTime:-"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnlLate
        '
        Me.PnlLate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlLate.Controls.Add(Me.DtTime)
        Me.PnlLate.Controls.Add(Me.BtnLateCncl)
        Me.PnlLate.Controls.Add(Me.Label11)
        Me.PnlLate.Controls.Add(Me.BtnLateOk)
        Me.PnlLate.Location = New System.Drawing.Point(431, 243)
        Me.PnlLate.Name = "PnlLate"
        Me.PnlLate.Size = New System.Drawing.Size(267, 114)
        Me.PnlLate.TabIndex = 33
        Me.PnlLate.Visible = False
        '
        'DtTime
        '
        Me.DtTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtTime.Location = New System.Drawing.Point(159, 19)
        Me.DtTime.Name = "DtTime"
        Me.DtTime.Size = New System.Drawing.Size(91, 20)
        Me.DtTime.TabIndex = 31
        '
        'BtnLateCncl
        '
        Me.BtnLateCncl.BackColor = System.Drawing.Color.LightCyan
        Me.BtnLateCncl.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnLateCncl.Location = New System.Drawing.Point(148, 78)
        Me.BtnLateCncl.Name = "BtnLateCncl"
        Me.BtnLateCncl.Size = New System.Drawing.Size(67, 23)
        Me.BtnLateCncl.TabIndex = 27
        Me.BtnLateCncl.Text = "&Cancel"
        Me.BtnLateCncl.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(22, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 17)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = " Reporting Time :-"
        '
        'BtnLateOk
        '
        Me.BtnLateOk.BackColor = System.Drawing.Color.LightCyan
        Me.BtnLateOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnLateOk.Location = New System.Drawing.Point(63, 77)
        Me.BtnLateOk.Name = "BtnLateOk"
        Me.BtnLateOk.Size = New System.Drawing.Size(39, 24)
        Me.BtnLateOk.TabIndex = 21
        Me.BtnLateOk.Text = "&OK"
        Me.BtnLateOk.UseVisualStyleBackColor = False
        '
        'PnlReprtLate
        '
        Me.PnlReprtLate.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.PnlReprtLate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlReprtLate.Controls.Add(Me.RbMatrntyLev)
        Me.PnlReprtLate.Controls.Add(Me.RbErnLev)
        Me.PnlReprtLate.Controls.Add(Me.Rb2HFLeve)
        Me.PnlReprtLate.Controls.Add(Me.Rb1HFLeve)
        Me.PnlReprtLate.Controls.Add(Me.RbFDLeve)
        Me.PnlReprtLate.Controls.Add(Me.RbShrtLeve)
        Me.PnlReprtLate.Controls.Add(Me.BtnRptOK)
        Me.PnlReprtLate.Controls.Add(Me.BtnRptCncl)
        Me.PnlReprtLate.Controls.Add(Me.Label6)
        Me.PnlReprtLate.Location = New System.Drawing.Point(321, 23)
        Me.PnlReprtLate.Name = "PnlReprtLate"
        Me.PnlReprtLate.Size = New System.Drawing.Size(356, 169)
        Me.PnlReprtLate.TabIndex = 28
        '
        'RbMatrntyLev
        '
        Me.RbMatrntyLev.AutoSize = True
        Me.RbMatrntyLev.Location = New System.Drawing.Point(220, 81)
        Me.RbMatrntyLev.Name = "RbMatrntyLev"
        Me.RbMatrntyLev.Size = New System.Drawing.Size(101, 17)
        Me.RbMatrntyLev.TabIndex = 57
        Me.RbMatrntyLev.TabStop = True
        Me.RbMatrntyLev.Text = "Maternity Leave"
        Me.RbMatrntyLev.UseVisualStyleBackColor = True
        '
        'RbErnLev
        '
        Me.RbErnLev.AutoSize = True
        Me.RbErnLev.Location = New System.Drawing.Point(81, 81)
        Me.RbErnLev.Name = "RbErnLev"
        Me.RbErnLev.Size = New System.Drawing.Size(80, 17)
        Me.RbErnLev.TabIndex = 56
        Me.RbErnLev.TabStop = True
        Me.RbErnLev.Text = "Earn Leave"
        Me.RbErnLev.UseVisualStyleBackColor = True
        '
        'Rb2HFLeve
        '
        Me.Rb2HFLeve.AutoSize = True
        Me.Rb2HFLeve.Location = New System.Drawing.Point(220, 52)
        Me.Rb2HFLeve.Name = "Rb2HFLeve"
        Me.Rb2HFLeve.Size = New System.Drawing.Size(120, 17)
        Me.Rb2HFLeve.TabIndex = 50
        Me.Rb2HFLeve.TabStop = True
        Me.Rb2HFLeve.Text = "2nd Half Day Leave"
        Me.Rb2HFLeve.UseVisualStyleBackColor = True
        '
        'Rb1HFLeve
        '
        Me.Rb1HFLeve.AutoSize = True
        Me.Rb1HFLeve.Location = New System.Drawing.Point(81, 52)
        Me.Rb1HFLeve.Name = "Rb1HFLeve"
        Me.Rb1HFLeve.Size = New System.Drawing.Size(116, 17)
        Me.Rb1HFLeve.TabIndex = 49
        Me.Rb1HFLeve.TabStop = True
        Me.Rb1HFLeve.Text = "1st Half Day Leave"
        Me.Rb1HFLeve.UseVisualStyleBackColor = True
        '
        'RbFDLeve
        '
        Me.RbFDLeve.AutoSize = True
        Me.RbFDLeve.Location = New System.Drawing.Point(220, 23)
        Me.RbFDLeve.Name = "RbFDLeve"
        Me.RbFDLeve.Size = New System.Drawing.Size(96, 17)
        Me.RbFDLeve.TabIndex = 48
        Me.RbFDLeve.TabStop = True
        Me.RbFDLeve.Text = "Full Day Leave"
        Me.RbFDLeve.UseVisualStyleBackColor = True
        '
        'RbShrtLeve
        '
        Me.RbShrtLeve.AutoSize = True
        Me.RbShrtLeve.Location = New System.Drawing.Point(81, 23)
        Me.RbShrtLeve.Name = "RbShrtLeve"
        Me.RbShrtLeve.Size = New System.Drawing.Size(83, 17)
        Me.RbShrtLeve.TabIndex = 47
        Me.RbShrtLeve.TabStop = True
        Me.RbShrtLeve.Text = "Short Leave"
        Me.RbShrtLeve.UseVisualStyleBackColor = True
        '
        'BtnRptOK
        '
        Me.BtnRptOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnRptOK.BackColor = System.Drawing.Color.LightCyan
        Me.BtnRptOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnRptOK.Location = New System.Drawing.Point(92, 134)
        Me.BtnRptOK.Name = "BtnRptOK"
        Me.BtnRptOK.Size = New System.Drawing.Size(63, 24)
        Me.BtnRptOK.TabIndex = 21
        Me.BtnRptOK.Text = "&OK"
        Me.BtnRptOK.UseVisualStyleBackColor = False
        '
        'BtnRptCncl
        '
        Me.BtnRptCncl.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnRptCncl.BackColor = System.Drawing.Color.LightCyan
        Me.BtnRptCncl.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnRptCncl.Location = New System.Drawing.Point(202, 135)
        Me.BtnRptCncl.Name = "BtnRptCncl"
        Me.BtnRptCncl.Size = New System.Drawing.Size(66, 23)
        Me.BtnRptCncl.TabIndex = 27
        Me.BtnRptCncl.Text = "&Cancel"
        Me.BtnRptCncl.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 16)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Leave:-"
        '
        'Datagrd
        '
        Me.Datagrd.AllowUserToAddRows = False
        Me.Datagrd.AllowUserToDeleteRows = False
        Me.Datagrd.AllowUserToResizeColumns = False
        Me.Datagrd.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Datagrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Datagrd.DefaultCellStyle = DataGridViewCellStyle2
        Me.Datagrd.Location = New System.Drawing.Point(3, 110)
        Me.Datagrd.Name = "Datagrd"
        Me.Datagrd.Size = New System.Drawing.Size(989, 347)
        Me.Datagrd.TabIndex = 31
        '
        'BtnHoliday
        '
        Me.BtnHoliday.BackColor = System.Drawing.Color.LightCyan
        Me.BtnHoliday.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnHoliday.Location = New System.Drawing.Point(613, 468)
        Me.BtnHoliday.Name = "BtnHoliday"
        Me.BtnHoliday.Size = New System.Drawing.Size(84, 32)
        Me.BtnHoliday.TabIndex = 3
        Me.BtnHoliday.Text = "Mark Holiday"
        Me.BtnHoliday.UseVisualStyleBackColor = False
        '
        'PnlTotEmp
        '
        Me.PnlTotEmp.Controls.Add(Me.GroupBox1)
        Me.PnlTotEmp.Controls.Add(Me.LblFDLeve)
        Me.PnlTotEmp.Controls.Add(Me.LblHfLeve)
        Me.PnlTotEmp.Controls.Add(Me.Label14)
        Me.PnlTotEmp.Controls.Add(Me.Label9)
        Me.PnlTotEmp.Controls.Add(Me.Label10)
        Me.PnlTotEmp.Controls.Add(Me.LblTotEmpl)
        Me.PnlTotEmp.Controls.Add(Me.Label7)
        Me.PnlTotEmp.Controls.Add(Me.LblPresnt)
        Me.PnlTotEmp.Controls.Add(Me.Label21)
        Me.PnlTotEmp.Controls.Add(Me.LblAbsnt)
        Me.PnlTotEmp.Controls.Add(Me.LblReprtlat)
        Me.PnlTotEmp.Controls.Add(Me.Label12)
        Me.PnlTotEmp.Controls.Add(Me.LblShrtLeve)
        Me.PnlTotEmp.Controls.Add(Me.Label16)
        Me.PnlTotEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlTotEmp.Location = New System.Drawing.Point(-1, 69)
        Me.PnlTotEmp.Name = "PnlTotEmp"
        Me.PnlTotEmp.Size = New System.Drawing.Size(996, 26)
        Me.PnlTotEmp.TabIndex = 24
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(409, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'LblFDLeve
        '
        Me.LblFDLeve.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblFDLeve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblFDLeve.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFDLeve.Location = New System.Drawing.Point(825, 0)
        Me.LblFDLeve.Name = "LblFDLeve"
        Me.LblFDLeve.Size = New System.Drawing.Size(30, 20)
        Me.LblFDLeve.TabIndex = 28
        Me.LblFDLeve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblHfLeve
        '
        Me.LblHfLeve.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblHfLeve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblHfLeve.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHfLeve.Location = New System.Drawing.Point(659, 0)
        Me.LblHfLeve.Name = "LblHfLeve"
        Me.LblHfLeve.Size = New System.Drawing.Size(40, 20)
        Me.LblHfLeve.TabIndex = 26
        Me.LblHfLeve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(708, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 20)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Full Day Leave :-"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 20)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Total Employees :-"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(573, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 20)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Half Leave :-"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotEmpl
        '
        Me.LblTotEmpl.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblTotEmpl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTotEmpl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotEmpl.Location = New System.Drawing.Point(143, 0)
        Me.LblTotEmpl.Name = "LblTotEmpl"
        Me.LblTotEmpl.Size = New System.Drawing.Size(32, 20)
        Me.LblTotEmpl.TabIndex = 4
        Me.LblTotEmpl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(192, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Present  :-"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblPresnt
        '
        Me.LblPresnt.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblPresnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblPresnt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPresnt.Location = New System.Drawing.Point(270, 0)
        Me.LblPresnt.Name = "LblPresnt"
        Me.LblPresnt.Size = New System.Drawing.Size(31, 20)
        Me.LblPresnt.TabIndex = 4
        Me.LblPresnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(861, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(90, 20)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Report Late  :-"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblAbsnt
        '
        Me.LblAbsnt.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblAbsnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAbsnt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAbsnt.Location = New System.Drawing.Point(389, 0)
        Me.LblAbsnt.Name = "LblAbsnt"
        Me.LblAbsnt.Size = New System.Drawing.Size(37, 20)
        Me.LblAbsnt.TabIndex = 4
        Me.LblAbsnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblReprtlat
        '
        Me.LblReprtlat.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblReprtlat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblReprtlat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReprtlat.Location = New System.Drawing.Point(957, 0)
        Me.LblReprtlat.Name = "LblReprtlat"
        Me.LblReprtlat.Size = New System.Drawing.Size(32, 20)
        Me.LblReprtlat.TabIndex = 4
        Me.LblReprtlat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(320, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 20)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Absent :-"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblShrtLeve
        '
        Me.LblShrtLeve.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblShrtLeve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblShrtLeve.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShrtLeve.Location = New System.Drawing.Point(531, 0)
        Me.LblShrtLeve.Name = "LblShrtLeve"
        Me.LblShrtLeve.Size = New System.Drawing.Size(31, 20)
        Me.LblShrtLeve.TabIndex = 4
        Me.LblShrtLeve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(432, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 20)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Short Leave :-"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSft
        '
        Me.LblSft.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblSft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSft.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSft.Location = New System.Drawing.Point(56, 10)
        Me.LblSft.Name = "LblSft"
        Me.LblSft.Size = New System.Drawing.Size(80, 20)
        Me.LblSft.TabIndex = 23
        Me.LblSft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnFnd
        '
        Me.BtnFnd.BackColor = System.Drawing.Color.LightCyan
        Me.BtnFnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFnd.Location = New System.Drawing.Point(861, 468)
        Me.BtnFnd.Name = "BtnFnd"
        Me.BtnFnd.Size = New System.Drawing.Size(62, 32)
        Me.BtnFnd.TabIndex = 21
        Me.BtnFnd.Text = "&Find"
        Me.BtnFnd.UseVisualStyleBackColor = False
        '
        'BtnLate
        '
        Me.BtnLate.BackColor = System.Drawing.Color.LightCyan
        Me.BtnLate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnLate.Location = New System.Drawing.Point(524, 469)
        Me.BtnLate.Name = "BtnLate"
        Me.BtnLate.Size = New System.Drawing.Size(82, 31)
        Me.BtnLate.TabIndex = 19
        Me.BtnLate.Text = "Mark &Late"
        Me.BtnLate.UseVisualStyleBackColor = False
        '
        'BtnLeave
        '
        Me.BtnLeave.BackColor = System.Drawing.Color.LightCyan
        Me.BtnLeave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnLeave.Location = New System.Drawing.Point(419, 469)
        Me.BtnLeave.Name = "BtnLeave"
        Me.BtnLeave.Size = New System.Drawing.Size(100, 32)
        Me.BtnLeave.TabIndex = 18
        Me.BtnLeave.Text = "Mark On Leave"
        Me.BtnLeave.UseVisualStyleBackColor = False
        '
        'BtnAbsnt
        '
        Me.BtnAbsnt.BackColor = System.Drawing.Color.LightCyan
        Me.BtnAbsnt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAbsnt.Location = New System.Drawing.Point(324, 469)
        Me.BtnAbsnt.Name = "BtnAbsnt"
        Me.BtnAbsnt.Size = New System.Drawing.Size(91, 32)
        Me.BtnAbsnt.TabIndex = 17
        Me.BtnAbsnt.Text = "Mark &Absent "
        Me.BtnAbsnt.UseVisualStyleBackColor = False
        '
        'BtnPresnt
        '
        Me.BtnPresnt.BackColor = System.Drawing.Color.LightCyan
        Me.BtnPresnt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnPresnt.Location = New System.Drawing.Point(226, 469)
        Me.BtnPresnt.Name = "BtnPresnt"
        Me.BtnPresnt.Size = New System.Drawing.Size(94, 32)
        Me.BtnPresnt.TabIndex = 16
        Me.BtnPresnt.Text = "Mark &Present"
        Me.BtnPresnt.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label18.Location = New System.Drawing.Point(0, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(988, 8)
        Me.Label18.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(174, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Start Time :-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbxsift
        '
        Me.cmbxsift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxsift.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbxsift.Location = New System.Drawing.Point(56, 32)
        Me.cmbxsift.Name = "cmbxsift"
        Me.cmbxsift.Size = New System.Drawing.Size(112, 22)
        Me.cmbxsift.TabIndex = 3
        '
        'btnPrsentAll
        '
        Me.btnPrsentAll.BackColor = System.Drawing.Color.LightCyan
        Me.btnPrsentAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrsentAll.Location = New System.Drawing.Point(6, 468)
        Me.btnPrsentAll.Name = "btnPrsentAll"
        Me.btnPrsentAll.Size = New System.Drawing.Size(107, 33)
        Me.btnPrsentAll.TabIndex = 2
        Me.btnPrsentAll.Text = "Mark &Present All"
        Me.btnPrsentAll.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(982, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Attendance Register"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnabsntAll
        '
        Me.BtnabsntAll.BackColor = System.Drawing.Color.LightCyan
        Me.BtnabsntAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnabsntAll.Location = New System.Drawing.Point(117, 469)
        Me.BtnabsntAll.Name = "BtnabsntAll"
        Me.BtnabsntAll.Size = New System.Drawing.Size(103, 32)
        Me.BtnabsntAll.TabIndex = 2
        Me.BtnabsntAll.Text = "Mark &Absent  All"
        Me.BtnabsntAll.UseVisualStyleBackColor = False
        '
        'Btnrest
        '
        Me.Btnrest.BackColor = System.Drawing.Color.LightCyan
        Me.Btnrest.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btnrest.Location = New System.Drawing.Point(706, 469)
        Me.Btnrest.Name = "Btnrest"
        Me.Btnrest.Size = New System.Drawing.Size(70, 32)
        Me.Btnrest.TabIndex = 2
        Me.Btnrest.Text = "&Reset"
        Me.Btnrest.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Shift :-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblStrtTime
        '
        Me.LblStrtTime.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblStrtTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblStrtTime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStrtTime.Location = New System.Drawing.Point(257, 32)
        Me.LblStrtTime.Name = "LblStrtTime"
        Me.LblStrtTime.Size = New System.Drawing.Size(80, 20)
        Me.LblStrtTime.TabIndex = 4
        Me.LblStrtTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(366, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "End Time :-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblEndTime
        '
        Me.LblEndTime.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblEndTime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndTime.Location = New System.Drawing.Point(444, 32)
        Me.LblEndTime.Name = "LblEndTime"
        Me.LblEndTime.Size = New System.Drawing.Size(80, 20)
        Me.LblEndTime.TabIndex = 4
        Me.LblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(562, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 20)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Break Time From :- "
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblBrkFrm
        '
        Me.LblBrkFrm.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblBrkFrm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblBrkFrm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBrkFrm.Location = New System.Drawing.Point(685, 32)
        Me.LblBrkFrm.Name = "LblBrkFrm"
        Me.LblBrkFrm.Size = New System.Drawing.Size(100, 20)
        Me.LblBrkFrm.TabIndex = 4
        Me.LblBrkFrm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(819, 32)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 20)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "To :-"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblBrkTo
        '
        Me.LblBrkTo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblBrkTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblBrkTo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBrkTo.Location = New System.Drawing.Point(858, 32)
        Me.LblBrkTo.Name = "LblBrkTo"
        Me.LblBrkTo.Size = New System.Drawing.Size(95, 20)
        Me.LblBrkTo.TabIndex = 4
        Me.LblBrkTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Btnsve
        '
        Me.Btnsve.BackColor = System.Drawing.Color.LightCyan
        Me.Btnsve.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btnsve.Location = New System.Drawing.Point(787, 468)
        Me.Btnsve.Name = "Btnsve"
        Me.Btnsve.Size = New System.Drawing.Size(66, 32)
        Me.Btnsve.TabIndex = 2
        Me.Btnsve.Text = "&Save "
        Me.Btnsve.UseVisualStyleBackColor = False
        '
        'Btnclos
        '
        Me.Btnclos.BackColor = System.Drawing.Color.LightCyan
        Me.Btnclos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btnclos.Location = New System.Drawing.Point(930, 468)
        Me.Btnclos.Name = "Btnclos"
        Me.Btnclos.Size = New System.Drawing.Size(59, 32)
        Me.Btnclos.TabIndex = 2
        Me.Btnclos.Text = "&Close"
        Me.Btnclos.UseVisualStyleBackColor = False
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label22.Location = New System.Drawing.Point(0, 98)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(988, 8)
        Me.Label22.TabIndex = 5
        '
        'PnlErnLev
        '
        Me.PnlErnLev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlErnLev.Controls.Add(Me.BtnOkErn)
        Me.PnlErnLev.Controls.Add(Me.BtnCnclErn)
        Me.PnlErnLev.Controls.Add(Me.Label36)
        Me.PnlErnLev.Controls.Add(Me.RbFDErn)
        Me.PnlErnLev.Controls.Add(Me.Rb2HFErn)
        Me.PnlErnLev.Controls.Add(Me.Rb1HFErn)
        Me.PnlErnLev.Location = New System.Drawing.Point(12, 326)
        Me.PnlErnLev.Name = "PnlErnLev"
        Me.PnlErnLev.Size = New System.Drawing.Size(314, 155)
        Me.PnlErnLev.TabIndex = 28
        Me.PnlErnLev.Visible = False
        '
        'BtnOkErn
        '
        Me.BtnOkErn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnOkErn.BackColor = System.Drawing.Color.LightCyan
        Me.BtnOkErn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOkErn.Location = New System.Drawing.Point(77, 116)
        Me.BtnOkErn.Name = "BtnOkErn"
        Me.BtnOkErn.Size = New System.Drawing.Size(63, 24)
        Me.BtnOkErn.TabIndex = 63
        Me.BtnOkErn.Text = "&OK"
        Me.BtnOkErn.UseVisualStyleBackColor = False
        '
        'BtnCnclErn
        '
        Me.BtnCnclErn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnCnclErn.BackColor = System.Drawing.Color.LightCyan
        Me.BtnCnclErn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCnclErn.Location = New System.Drawing.Point(155, 117)
        Me.BtnCnclErn.Name = "BtnCnclErn"
        Me.BtnCnclErn.Size = New System.Drawing.Size(66, 23)
        Me.BtnCnclErn.TabIndex = 64
        Me.BtnCnclErn.Text = "&Cancel"
        Me.BtnCnclErn.UseVisualStyleBackColor = False
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(121, 14)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(87, 16)
        Me.Label36.TabIndex = 60
        Me.Label36.Text = "Earn Leave"
        '
        'RbFDErn
        '
        Me.RbFDErn.AutoSize = True
        Me.RbFDErn.Location = New System.Drawing.Point(26, 74)
        Me.RbFDErn.Name = "RbFDErn"
        Me.RbFDErn.Size = New System.Drawing.Size(96, 17)
        Me.RbFDErn.TabIndex = 59
        Me.RbFDErn.TabStop = True
        Me.RbFDErn.Text = "Full Day Leave"
        Me.RbFDErn.UseVisualStyleBackColor = True
        '
        'Rb2HFErn
        '
        Me.Rb2HFErn.AutoSize = True
        Me.Rb2HFErn.Location = New System.Drawing.Point(165, 45)
        Me.Rb2HFErn.Name = "Rb2HFErn"
        Me.Rb2HFErn.Size = New System.Drawing.Size(120, 17)
        Me.Rb2HFErn.TabIndex = 58
        Me.Rb2HFErn.TabStop = True
        Me.Rb2HFErn.Text = "2nd Half Day Leave"
        Me.Rb2HFErn.UseVisualStyleBackColor = True
        '
        'Rb1HFErn
        '
        Me.Rb1HFErn.AutoSize = True
        Me.Rb1HFErn.Location = New System.Drawing.Point(26, 45)
        Me.Rb1HFErn.Name = "Rb1HFErn"
        Me.Rb1HFErn.Size = New System.Drawing.Size(116, 17)
        Me.Rb1HFErn.TabIndex = 57
        Me.Rb1HFErn.TabStop = True
        Me.Rb1HFErn.Text = "1st Half Day Leave"
        Me.Rb1HFErn.UseVisualStyleBackColor = True
        '
        'GrpBxOptn
        '
        Me.GrpBxOptn.Controls.Add(Me.Panel2)
        Me.GrpBxOptn.Controls.Add(Me.BtnGrpCncl)
        Me.GrpBxOptn.Controls.Add(Me.BtnGrpOk)
        Me.GrpBxOptn.Location = New System.Drawing.Point(620, 1)
        Me.GrpBxOptn.Name = "GrpBxOptn"
        Me.GrpBxOptn.Size = New System.Drawing.Size(351, 181)
        Me.GrpBxOptn.TabIndex = 27
        Me.GrpBxOptn.TabStop = False
        Me.GrpBxOptn.Text = "Change Weekly Break"
        Me.GrpBxOptn.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmbxshft)
        Me.Panel2.Controls.Add(Me.Label33)
        Me.Panel2.Controls.Add(Me.Label35)
        Me.Panel2.Controls.Add(Me.CmbxDays)
        Me.Panel2.Controls.Add(Me.DtpkrTo)
        Me.Panel2.Controls.Add(Me.DtpkrFrm)
        Me.Panel2.Controls.Add(Me.Label30)
        Me.Panel2.Controls.Add(Me.Label34)
        Me.Panel2.Location = New System.Drawing.Point(11, 19)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(321, 113)
        Me.Panel2.TabIndex = 28
        '
        'cmbxshft
        '
        Me.cmbxshft.FormattingEnabled = True
        Me.cmbxshft.Location = New System.Drawing.Point(62, 83)
        Me.cmbxshft.Name = "cmbxshft"
        Me.cmbxshft.Size = New System.Drawing.Size(77, 21)
        Me.cmbxshft.TabIndex = 46
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(3, 47)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(51, 20)
        Me.Label33.TabIndex = 41
        Me.Label33.Text = "From :-"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(3, 83)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(51, 20)
        Me.Label35.TabIndex = 45
        Me.Label35.Text = "Shift :-"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxDays
        '
        Me.CmbxDays.FormattingEnabled = True
        Me.CmbxDays.Items.AddRange(New Object() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.CmbxDays.Location = New System.Drawing.Point(62, 8)
        Me.CmbxDays.Name = "CmbxDays"
        Me.CmbxDays.Size = New System.Drawing.Size(112, 21)
        Me.CmbxDays.TabIndex = 40
        '
        'DtpkrTo
        '
        Me.DtpkrTo.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrTo.Location = New System.Drawing.Point(212, 47)
        Me.DtpkrTo.Name = "DtpkrTo"
        Me.DtpkrTo.Size = New System.Drawing.Size(98, 20)
        Me.DtpkrTo.TabIndex = 44
        '
        'DtpkrFrm
        '
        Me.DtpkrFrm.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrFrm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrFrm.Location = New System.Drawing.Point(62, 47)
        Me.DtpkrFrm.Name = "DtpkrFrm"
        Me.DtpkrFrm.Size = New System.Drawing.Size(98, 20)
        Me.DtpkrFrm.TabIndex = 42
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(3, 8)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(43, 20)
        Me.Label30.TabIndex = 39
        Me.Label30.Text = "Day :-"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(169, 47)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(37, 20)
        Me.Label34.TabIndex = 43
        Me.Label34.Text = "To :-"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnGrpCncl
        '
        Me.BtnGrpCncl.BackColor = System.Drawing.Color.LightCyan
        Me.BtnGrpCncl.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrpCncl.Location = New System.Drawing.Point(273, 139)
        Me.BtnGrpCncl.Name = "BtnGrpCncl"
        Me.BtnGrpCncl.Size = New System.Drawing.Size(57, 23)
        Me.BtnGrpCncl.TabIndex = 35
        Me.BtnGrpCncl.Text = "&Cancel"
        Me.BtnGrpCncl.UseVisualStyleBackColor = False
        '
        'BtnGrpOk
        '
        Me.BtnGrpOk.BackColor = System.Drawing.Color.LightCyan
        Me.BtnGrpOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrpOk.Location = New System.Drawing.Point(208, 139)
        Me.BtnGrpOk.Name = "BtnGrpOk"
        Me.BtnGrpOk.Size = New System.Drawing.Size(51, 23)
        Me.BtnGrpOk.TabIndex = 34
        Me.BtnGrpOk.Text = "&OK"
        Me.BtnGrpOk.UseVisualStyleBackColor = False
        '
        'PnlFnd
        '
        Me.PnlFnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlFnd.Controls.Add(Me.BtnCncl)
        Me.PnlFnd.Controls.Add(Me.PnlOrdr)
        Me.PnlFnd.Controls.Add(Me.BtnOk)
        Me.PnlFnd.Controls.Add(Me.Cmbxsift1)
        Me.PnlFnd.Controls.Add(Me.Label8)
        Me.PnlFnd.Controls.Add(Me.LblLine)
        Me.PnlFnd.Controls.Add(Me.Label32)
        Me.PnlFnd.Controls.Add(Me.Label4)
        Me.PnlFnd.Controls.Add(Me.RbEname)
        Me.PnlFnd.Controls.Add(Me.CmbxDept)
        Me.PnlFnd.Controls.Add(Me.RbAll)
        Me.PnlFnd.Controls.Add(Me.CmbxEmpName)
        Me.PnlFnd.Controls.Add(Me.RbDept)
        Me.PnlFnd.Location = New System.Drawing.Point(93, 100)
        Me.PnlFnd.Name = "PnlFnd"
        Me.PnlFnd.Size = New System.Drawing.Size(229, 176)
        Me.PnlFnd.TabIndex = 14
        '
        'BtnCncl
        '
        Me.BtnCncl.BackColor = System.Drawing.Color.LightCyan
        Me.BtnCncl.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCncl.Location = New System.Drawing.Point(123, 128)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(51, 23)
        Me.BtnCncl.TabIndex = 26
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = False
        '
        'PnlOrdr
        '
        Me.PnlOrdr.Controls.Add(Me.RBEid)
        Me.PnlOrdr.Controls.Add(Me.RBOrdDept)
        Me.PnlOrdr.Controls.Add(Me.RBOrdEname)
        Me.PnlOrdr.Location = New System.Drawing.Point(107, 159)
        Me.PnlOrdr.Name = "PnlOrdr"
        Me.PnlOrdr.Size = New System.Drawing.Size(92, 76)
        Me.PnlOrdr.TabIndex = 24
        '
        'RBEid
        '
        Me.RBEid.AutoSize = True
        Me.RBEid.Location = New System.Drawing.Point(3, 4)
        Me.RBEid.Name = "RBEid"
        Me.RBEid.Size = New System.Drawing.Size(64, 17)
        Me.RBEid.TabIndex = 10
        Me.RBEid.TabStop = True
        Me.RBEid.Text = " Emp. Id"
        Me.RBEid.UseVisualStyleBackColor = True
        '
        'RBOrdDept
        '
        Me.RBOrdDept.AutoSize = True
        Me.RBOrdDept.Location = New System.Drawing.Point(3, 50)
        Me.RBOrdDept.Name = "RBOrdDept"
        Me.RBOrdDept.Size = New System.Drawing.Size(83, 17)
        Me.RBOrdDept.TabIndex = 9
        Me.RBOrdDept.TabStop = True
        Me.RBOrdDept.Text = " Department"
        Me.RBOrdDept.UseVisualStyleBackColor = True
        '
        'RBOrdEname
        '
        Me.RBOrdEname.AutoSize = True
        Me.RBOrdEname.Location = New System.Drawing.Point(3, 27)
        Me.RBOrdEname.Name = "RBOrdEname"
        Me.RBOrdEname.Size = New System.Drawing.Size(83, 17)
        Me.RBOrdEname.TabIndex = 8
        Me.RBOrdEname.TabStop = True
        Me.RBOrdEname.Text = " Emp. Name"
        Me.RBOrdEname.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.Color.LightCyan
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOk.Location = New System.Drawing.Point(53, 128)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(39, 23)
        Me.BtnOk.TabIndex = 25
        Me.BtnOk.Text = "&OK"
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'Cmbxsift1
        '
        Me.Cmbxsift1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxsift1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxsift1.Location = New System.Drawing.Point(115, 11)
        Me.Cmbxsift1.Name = "Cmbxsift1"
        Me.Cmbxsift1.Size = New System.Drawing.Size(80, 22)
        Me.Cmbxsift1.Sorted = True
        Me.Cmbxsift1.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 20)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Shift:-"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblLine
        '
        Me.LblLine.BackColor = System.Drawing.Color.PaleTurquoise
        Me.LblLine.Location = New System.Drawing.Point(0, 133)
        Me.LblLine.Name = "LblLine"
        Me.LblLine.Size = New System.Drawing.Size(228, 5)
        Me.LblLine.TabIndex = 13
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(3, 48)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(79, 20)
        Me.Label32.TabIndex = 7
        Me.Label32.Text = "Search By :-"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Order By :-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RbEname
        '
        Me.RbEname.AutoSize = True
        Me.RbEname.Location = New System.Drawing.Point(115, 48)
        Me.RbEname.Name = "RbEname"
        Me.RbEname.Size = New System.Drawing.Size(83, 17)
        Me.RbEname.TabIndex = 8
        Me.RbEname.TabStop = True
        Me.RbEname.Text = " Emp. Name"
        Me.RbEname.UseVisualStyleBackColor = True
        '
        'CmbxDept
        '
        Me.CmbxDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxDept.FormattingEnabled = True
        Me.CmbxDept.Location = New System.Drawing.Point(14, 117)
        Me.CmbxDept.Name = "CmbxDept"
        Me.CmbxDept.Size = New System.Drawing.Size(144, 21)
        Me.CmbxDept.Sorted = True
        Me.CmbxDept.TabIndex = 13
        '
        'RbAll
        '
        Me.RbAll.AutoSize = True
        Me.RbAll.Location = New System.Drawing.Point(115, 94)
        Me.RbAll.Name = "RbAll"
        Me.RbAll.Size = New System.Drawing.Size(36, 17)
        Me.RbAll.TabIndex = 12
        Me.RbAll.TabStop = True
        Me.RbAll.Text = "All"
        Me.RbAll.UseVisualStyleBackColor = True
        '
        'CmbxEmpName
        '
        Me.CmbxEmpName.FormattingEnabled = True
        Me.CmbxEmpName.Location = New System.Drawing.Point(15, 109)
        Me.CmbxEmpName.Name = "CmbxEmpName"
        Me.CmbxEmpName.Size = New System.Drawing.Size(136, 21)
        Me.CmbxEmpName.Sorted = True
        Me.CmbxEmpName.TabIndex = 11
        '
        'RbDept
        '
        Me.RbDept.AutoSize = True
        Me.RbDept.Location = New System.Drawing.Point(115, 71)
        Me.RbDept.Name = "RbDept"
        Me.RbDept.Size = New System.Drawing.Size(83, 17)
        Me.RbDept.TabIndex = 9
        Me.RbDept.TabStop = True
        Me.RbDept.Text = " Department"
        Me.RbDept.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(6, 4)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(48, 20)
        Me.Label31.TabIndex = 1
        Me.Label31.Text = "Date:-"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtpkrDt
        '
        Me.DtpkrDt.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrDt.Location = New System.Drawing.Point(57, 4)
        Me.DtpkrDt.Name = "DtpkrDt"
        Me.DtpkrDt.Size = New System.Drawing.Size(118, 20)
        Me.DtpkrDt.TabIndex = 0
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(692, 4)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(73, 20)
        Me.Label28.TabIndex = 2
        Me.Label28.Text = "Options :-"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxOptn
        '
        Me.CmbxOptn.FormattingEnabled = True
        Me.CmbxOptn.Items.AddRange(New Object() {"Change Weekly Break", "None"})
        Me.CmbxOptn.Location = New System.Drawing.Point(771, 5)
        Me.CmbxOptn.Name = "CmbxOptn"
        Me.CmbxOptn.Size = New System.Drawing.Size(189, 21)
        Me.CmbxOptn.TabIndex = 3
        Me.CmbxOptn.Text = "Select"
        '
        'FrmAttend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(1011, 594)
        Me.Controls.Add(Me.PnlErnLev)
        Me.Controls.Add(Me.GrpBxOptn)
        Me.Controls.Add(Me.CmbxOptn)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.DtpkrDt)
        Me.Controls.Add(Me.PnlFnd)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmAttend"
        Me.Text = "Attendance"
        Me.Panel1.ResumeLayout(False)
        Me.PnlBrkOut.ResumeLayout(False)
        Me.PnlBrkOut.PerformLayout()
        Me.PnlAttd.ResumeLayout(False)
        Me.PnlAttd.PerformLayout()
        Me.PnlLate.ResumeLayout(False)
        Me.PnlReprtLate.ResumeLayout(False)
        Me.PnlReprtLate.PerformLayout()
        CType(Me.Datagrd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlTotEmp.ResumeLayout(False)
        Me.PnlErnLev.ResumeLayout(False)
        Me.PnlErnLev.PerformLayout()
        Me.GrpBxOptn.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.PnlFnd.ResumeLayout(False)
        Me.PnlFnd.PerformLayout()
        Me.PnlOrdr.ResumeLayout(False)
        Me.PnlOrdr.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub FrmAttend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 45
        Me.Left = 5
        fetch_Strtdt()
        DtpkrDt.Focus()
        DtpkrDt.MinDate = strtdt.Date
        CmbxEmpName.Visible = False
        CmbxDept.Visible = False
        PnlReprtLate.Visible = False
        PnlFnd.Visible = False
        LblSft.Visible = False
        PnlLate.Visible = False
        PnlErnLev.Visible = False
        DtTime.ShowUpDown = True
        Datagrd.Columns.Clear()
        Dim chkcol As New DataGridViewCheckBoxColumn

        Me.Datagrd.Columns.Add(chkcol)                      '0
        Me.Datagrd.Columns.Add("Employee Id", "Employee Id") '1
        Me.Datagrd.Columns.Add("Employee Name", "Employee Name") '2
        Me.Datagrd.Columns.Add("Status", "Status") '3
        Me.Datagrd.Columns.Add("Reporting Status", "Reporting Status") '4
        Me.Datagrd.Columns.Add("Reason", "Reason") '5
        AddColumns()


        Me.Datagrd.Columns(0).Width = 30
        Me.Datagrd.Columns(1).Width = 100
        Me.Datagrd.Columns(2).Width = 200
        Me.Datagrd.Columns(3).Width = 110
        Me.Datagrd.Columns(4).Width = 100
        Me.Datagrd.Columns(5).Width = 10
        Me.Datagrd.Columns(6).Width = 100
        Me.Datagrd.Columns(7).Width = 100
        Me.Datagrd.Columns(8).Width = 100
        Me.Datagrd.Columns(9).Width = 100

        Me.Datagrd.Columns(5).Visible = False

        Me.Datagrd.Columns(1).ReadOnly = True
        Me.Datagrd.Columns(2).ReadOnly = True
        Me.Datagrd.Columns(3).ReadOnly = True
        Me.Datagrd.Columns(4).ReadOnly = True

        If Attd_Type = 1 Then
            Me.Datagrd.Columns(7).Visible = False
            Me.Datagrd.Columns(8).Visible = False
            Me.Datagrd.Columns(9).Visible = False

            btnPrsentAll.Visible = True
            BtnabsntAll.Visible = True
            BtnPresnt.Visible = True
            BtnAbsnt.Visible = True
            BtnLeave.Visible = True
            BtnLate.Visible = True
            BtnHoliday.Visible = True

            btnPrsentAll.Location = New System.Drawing.Point(6, 468)
            BtnabsntAll.Location = New System.Drawing.Point(117, 469)
            BtnPresnt.Location = New System.Drawing.Point(226, 469)
            BtnAbsnt.Location = New System.Drawing.Point(324, 469)
            BtnLeave.Location = New System.Drawing.Point(419, 469)
            BtnLate.Location = New System.Drawing.Point(524, 469)
            BtnHoliday.Location = New System.Drawing.Point(613, 468)
            Btnrest.Location = New System.Drawing.Point(706, 469)
            Btnsve.Location = New System.Drawing.Point(787, 468)
            BtnFnd.Location = New System.Drawing.Point(861, 468)
            Btnclos.Location = New System.Drawing.Point(930, 468)
            Btnrest.Size = New System.Drawing.Point(70, 32)
            Btnsve.Size = New System.Drawing.Point(66, 32)
            BtnFnd.Size = New System.Drawing.Point(62, 32)
            Btnclos.Size = New System.Drawing.Point(59, 32)
            PnlAttd.Visible = False
            Panel1.Size = New System.Drawing.Point(996, 507)
            Me.Size = New System.Drawing.Point(1017, 565)
            PnlBrkOut.Visible = False

        ElseIf Attd_Type = 2 Then
            Me.Datagrd.Columns(6).ReadOnly = True
            Me.Datagrd.Columns(7).Visible = True
            Me.Datagrd.Columns(8).Visible = False
            Me.Datagrd.Columns(9).Visible = False

            btnPrsentAll.Visible = False
            BtnabsntAll.Visible = False
            BtnPresnt.Visible = False
            BtnAbsnt.Visible = False
            BtnLeave.Visible = False
            BtnLate.Visible = False
            BtnHoliday.Visible = False

            PnlAttd.Visible = True
            Label17.Text = "Mark Break OutTime:-"
            Rball_attd.Checked = False
            Rball_sel.Checked = False
            Btnrest.Size = New System.Drawing.Point(95, 32)
            Btnrest.Location = New System.Drawing.Point(450, 469)

            Btnsve.Size = New System.Drawing.Point(90, 32)
            Btnsve.Location = New System.Drawing.Point(590, 469)

            BtnFnd.Size = New System.Drawing.Point(90, 32)
            BtnFnd.Location = New System.Drawing.Point(720, 469)

            Btnclos.Size = New System.Drawing.Point(90, 32)
            Btnclos.Location = New System.Drawing.Point(850, 469)

            Panel1.Size = New System.Drawing.Point(996, 507)
            Me.Size = New System.Drawing.Point(1017, 565)
            PnlBrkOut.Visible = False

        ElseIf Attd_Type = 3 Then
            Me.Datagrd.Columns(6).ReadOnly = True
            Me.Datagrd.Columns(7).ReadOnly = True
            Me.Datagrd.Columns(8).Visible = True
            Me.Datagrd.Columns(9).Visible = False

            btnPrsentAll.Visible = False
            BtnabsntAll.Visible = False
            BtnPresnt.Visible = False
            BtnAbsnt.Visible = False
            BtnLeave.Visible = False
            BtnLate.Visible = False
            BtnHoliday.Visible = False

            PnlAttd.Visible = True
            Label17.Text = "Mark Break InTime:-"
            Rball_attd.Checked = False
            Rball_sel.Checked = False
            Btnrest.Size = New System.Drawing.Point(95, 32)
            Btnrest.Location = New System.Drawing.Point(450, 469)

            Btnsve.Size = New System.Drawing.Point(90, 32)
            Btnsve.Location = New System.Drawing.Point(590, 469)

            BtnFnd.Size = New System.Drawing.Point(90, 32)
            BtnFnd.Location = New System.Drawing.Point(720, 469)

            Btnclos.Size = New System.Drawing.Point(90, 32)
            Btnclos.Location = New System.Drawing.Point(850, 469)

            Panel1.Size = New System.Drawing.Point(996, 507)
            Me.Size = New System.Drawing.Point(1017, 565)
            PnlBrkOut.Visible = False
        ElseIf Attd_Type = 4 Then
            Me.Datagrd.Columns(6).ReadOnly = True
            Me.Datagrd.Columns(7).ReadOnly = True
            Me.Datagrd.Columns(8).ReadOnly = True
            Me.Datagrd.Columns(9).Visible = True

            btnPrsentAll.Visible = False
            BtnabsntAll.Visible = False
            BtnPresnt.Visible = False
            BtnAbsnt.Visible = False
            BtnLeave.Visible = False
            BtnLate.Visible = False
            BtnHoliday.Visible = False

            PnlAttd.Visible = True
            Label17.Text = "Mark OutTime:-"
            Rball_attd.Checked = False
            Rball_sel.Checked = False
            Btnrest.Size = New System.Drawing.Point(95, 32)
            Btnrest.Location = New System.Drawing.Point(450, 469)

            Btnsve.Size = New System.Drawing.Point(90, 32)
            Btnsve.Location = New System.Drawing.Point(590, 469)

            BtnFnd.Size = New System.Drawing.Point(90, 32)
            BtnFnd.Location = New System.Drawing.Point(720, 469)

            Btnclos.Size = New System.Drawing.Point(90, 32)
            Btnclos.Location = New System.Drawing.Point(850, 469)

            Panel1.Size = New System.Drawing.Point(996, 507)
            Me.Size = New System.Drawing.Point(1017, 565)
            PnlBrkOut.Visible = False

        ElseIf Attd_Type = 5 Then


            btnPrsentAll.Visible = True
            BtnabsntAll.Visible = True
            BtnPresnt.Visible = True
            BtnAbsnt.Visible = True
            BtnLeave.Visible = True
            BtnLate.Visible = True
            BtnHoliday.Visible = True

            btnPrsentAll.Location = New System.Drawing.Point(6, 468)
            BtnabsntAll.Location = New System.Drawing.Point(117, 469)
            BtnPresnt.Location = New System.Drawing.Point(226, 469)
            BtnAbsnt.Location = New System.Drawing.Point(324, 469)
            BtnLeave.Location = New System.Drawing.Point(419, 469)
            BtnLate.Location = New System.Drawing.Point(524, 469)
            BtnHoliday.Location = New System.Drawing.Point(613, 468)
            Btnrest.Location = New System.Drawing.Point(706, 469)
            Btnsve.Location = New System.Drawing.Point(787, 468)
            BtnFnd.Location = New System.Drawing.Point(861, 468)
            Btnclos.Location = New System.Drawing.Point(930, 468)
            Btnrest.Size = New System.Drawing.Point(70, 32)
            Btnsve.Size = New System.Drawing.Point(66, 32)
            BtnFnd.Size = New System.Drawing.Point(62, 32)
            Btnclos.Size = New System.Drawing.Point(59, 32)
            PnlAttd.Visible = False

            Panel1.Size = New System.Drawing.Point(996, 561)
            Me.Size = New System.Drawing.Point(1017, 619)
            PnlBrkOut.Visible = True

        End If
        cmbxsift.Visible = True

        fetch_ComboShift(cmbxsift)
        DtpkrDt.Text = Attd_Date

        cmbxsift.Text = Attd_Shift
        ''DtpkrDt.Enabled = False
        ''cmbxsift.Enabled = False
        


        Btnsve.Focus()



    End Sub


    Private Sub AddColumns()

        Dim dtp, dtp1, dtp2, dtp3 As New CalendarColumn1()

        Try
            dtp.HeaderText = "In Time"
            dtp.Name = "INTime"
            Datagrd.Columns.Add(dtp)

            dtp1.HeaderText = "BreakOut Time"
            dtp1.Name = "Break Out Time"
            Datagrd.Columns.Add(dtp1)

            dtp2.HeaderText = "BreakIn Time"
            dtp2.Name = "Break In Time"
            Datagrd.Columns.Add(dtp2)

            dtp3.HeaderText = "Out Time"
            dtp3.Name = "Out Time"
            Datagrd.Columns.Add(dtp3)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fetch_Strtdt()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select costrtdt from Finactcogatemstr  ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            While Attd_Sift_Rdr.Read
                If Attd_Sift_Rdr.HasRows = True Then
                    strtdt = Attd_Sift_Rdr(0)
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub


    Private Sub Btnclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnclos.Click
        Dim cnfrmclos As String
        cnfrmclos = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmclos = vbYes Then
            Me.Close()
        End If

    End Sub

    Private Sub Fetch_Shft_Recrd()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select Empstdtime,Empendtime,Empbrkfrom,Empbrkto from FinactEmpTimeMstr where EmpSift='" & (cmbxsift.Text) & "' ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            If Trim(cmbxsift.Text) <> "" Then
                Attd_Sift_Rdr.Read()
                If Attd_Sift_Rdr.HasRows = True Then
                    StrtTime = Attd_Sift_Rdr(0)
                    LblStrtTime.Text = Format(StrtTime, "HH:mm:ss")
                    EndTime = Attd_Sift_Rdr(1)
                    LblEndTime.Text = Format(EndTime, "HH:mm:ss")
                    BrkFrm = Attd_Sift_Rdr(2)
                    LblBrkFrm.Text = Format(BrkFrm, "HH:mm:ss")
                    BrkTo = Attd_Sift_Rdr(3)
                    LblBrkTo.Text = Format(BrkTo, "HH:mm:ss")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Mstr_Lst_Sunday_Recrd()


        LblPresnt.Text = 0
        LblAbsnt.Text = 0
        LblShrtLeve.Text = 0
        LblReprtlat.Text = 0
        LblShrtLeve.Text = 0
        LblHfLeve.Text = 0
        LblFDLeve.Text = 0

        Dim i As Integer = 0
        If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then
            Try
                Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift,finactdept.deptid from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid where empdelstatus=1 and empcateg='Working' and empothrsift='" & (cmbxsift.Text) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "' ", FinActConn)
                Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
                While Attd_Sift_Rdr.Read()
                    If Attd_Sift_Rdr.HasRows = True Then
                        'Datagrd.Rows.Add()
                        i = 0
                        dgr = New DataGridViewRow

                        'checkbox cell
                        com = New DataGridViewCheckBoxCell
                        dgr.Cells.Add(com)

                        Empid = Attd_Sift_Rdr(0)

                        'employee id
                        cel = New DataGridViewTextBoxCell
                        cel.Value = Empid
                        dgr.Cells.Add(cel)

                        cel = New DataGridViewTextBoxCell
                        cel.Value = Attd_Sift_Rdr(1)
                        dgr.Cells.Add(cel)

                        cel = New DataGridViewTextBoxCell
                        cel.Value = "Holiday"
                        dgr.Cells.Add(cel)

                        cel = New DataGridViewTextBoxCell
                        cel.Value = "Holiday"
                        dgr.Cells.Add(cel)

                       

                        cel = New DataGridViewTextBoxCell
                        cel.Value = "OffDay"
                        dgr.Cells.Add(cel)

                        Me.Datagrd.Rows.Add(dgr)


                    End If
                    i += 1
                End While
                For i = 0 To Me.Datagrd.Rows.Count - 1
                    Me.Datagrd.Rows(i).Cells(6).Value = DateTime.MinValue
                    Me.Datagrd.Rows(i).Cells(7).Value = DateTime.MinValue
                    Me.Datagrd.Rows(i).Cells(8).Value = DateTime.MinValue
                    Me.Datagrd.Rows(i).Cells(9).Value = DateTime.MinValue
                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
            Finally
                ' If Attd_Sift_Rdr.HasRows = True Then
                If Attd_Sift_Rdr.HasRows = False Then
                    MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")

                End If


                Attd_Sift_Rdr.Close()
                Attd_Sift_Cmd = Nothing
            End Try
        End If


        Dim TotRecrd, Counter1 As Integer
        TotRecrd = Datagrd.Rows.Count
        Counter1 = 0
        While Counter1 < TotRecrd
            Id = Datagrd.Rows(Counter1).Cells(1).Value
            Search_Eid()
            Try
                Attd_Sift_Cmd = New SqlCommand("Finact_Attd_Insert", FinActConn)
                Attd_Sift_Cmd.CommandType = CommandType.StoredProcedure
                Attd_Sift_Cmd.Parameters.AddWithValue("@Attdadusrid", Current_UsrId)
                Attd_Sift_Cmd.Parameters.AddWithValue("@Attdaddt", Now)
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdSft", cmbxsift.Text)
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdStrtime", LblStrtTime.Text)
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdEndtime", LblEndTime.Text)
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdEmpid", Id)

                Attd_Sift_Cmd.Parameters.AddWithValue("@Attddt", DtpkrDt.Value.Date)
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdStatus", Datagrd.Rows(Counter1).Cells(3).Value)
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdRepStatus", Datagrd.Rows(Counter1).Cells(4).Value)
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdMonth", 0)
                Attd_Sift_Cmd.Parameters.AddWithValue("@SlrySlip", 0)
                dtval = Datagrd.Rows(Counter1).Cells(6).Value
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdInTime", Format(dtval, "HH:mm:ss"))
                dtval = Datagrd.Rows(Counter1).Cells(7).Value
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdBrkOutTime", Format(dtval, "HH:mm:ss"))
                dtval = Datagrd.Rows(Counter1).Cells(8).Value
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdBrkInTime", Format(dtval, "HH:mm:ss"))
                dtval = Datagrd.Rows(Counter1).Cells(9).Value
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdOutTime", Format(dtval, "HH:mm:ss"))
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdLeveRsn", Datagrd.Rows(Counter1).Cells(5).Value)
                Attd_Sift_Cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
            Finally
                Attd_Sift_Cmd = Nothing
            End Try

            Counter1 = Counter1 + 1
        End While


    End Sub
    Private Sub Chek_Date()
        fetch_Strtdt()
        If DtpkrDt.Value.Date = strtdt Then
            counter = 1
        Else
            Try
                Attd_Sift_Cmd = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdSft='" & (cmbxsift.Text) & "'and Attddt='" & (DtpkrDt.Value.Date.AddDays(-1)) & "' ", FinActConn)
                Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
                If Trim(cmbxsift.Text) <> "" Then
                    Attd_Sift_Rdr.Read()
                    If Attd_Sift_Rdr.IsDBNull(0) = False Then
                        counter = Attd_Sift_Rdr(0)

                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
            Finally
                Attd_Sift_Rdr.Close()
                Attd_Sift_Cmd = Nothing
            End Try
        End If
    End Sub

    Private Sub Chek_OutTime()

        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdOutTime) from Finact_Attd where AttdSft='" & (cmbxsift.Text) & "'and Attddt='" & (DtpkrDt.Value.Date.AddDays(-1)) & "' ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            If Trim(cmbxsift.Text) <> "" Then
                Attd_Sift_Rdr.Read()
                If Attd_Sift_Rdr.IsDBNull(0) = False Then
                    counter = Attd_Sift_Rdr(0)

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try

    End Sub

    Private Sub Chek_Date1()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdSft='" & (cmbxsift.Text) & "'and Attddt='" & (DtpkrDt.Value.Date) & "' ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            If Trim(cmbxsift.Text) <> "" Then
                Attd_Sift_Rdr.Read()
                If Attd_Sift_Rdr.IsDBNull(0) = False Then
                    counter1 = Attd_Sift_Rdr(0)

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Count_offdayrecrd()

        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(offid) from FinactAttdoffday where offdelstatus=1 and fromdt<='" & (DtpkrDt.Value.Date) & "' and todt>='" & (DtpkrDt.Value.Date) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()

            If Attd_Sift_Rdr.IsDBNull(0) = False Then
                count_offrecrd = Attd_Sift_Rdr(0)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_offdayrecrd()

        Dim fetch_fromdt, fetch_todt As Date
        Dim fetch_offshft As String
        Try
            Attd_Sift_Cmd = New SqlCommand("Select offday,fromdt,todt,offshft from FinactAttdoffday where offdelstatus=1 and fromdt<='" & (DtpkrDt.Value.Date) & "' and todt>='" & (DtpkrDt.Value.Date) & "'and offshft='" & (cmbxsift.Text) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()

            If Attd_Sift_Rdr.HasRows = True Then

                fetch_offday = Attd_Sift_Rdr(0)
                fetch_fromdt = Attd_Sift_Rdr(1)
                fetch_todt = Attd_Sift_Rdr(2)
                fetch_offshft = Attd_Sift_Rdr(3)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub chk_firstrecrd()

        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdId) from Finact_Attd where AttdSft='" & (cmbxsift.Text) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()

            If Attd_Sift_Rdr.IsDBNull(0) = False Then
                first_recrd = Attd_Sift_Rdr(0)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Max_Attd()

        Try
            Attd_Sift_Cmd = New SqlCommand("Select max(Attddt),min(Attddt) from Finact_Attd where AttdSft='" & (cmbxsift.Text) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()

            If Attd_Sift_Rdr.HasRows = True Then
                max_date = Attd_Sift_Rdr(0)
                min_date = Attd_Sift_Rdr(1)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub
    Private Sub cmbxsift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxsift.SelectedIndexChanged
        Dim weekly_offday As Integer
        PnlTotEmp.Visible = True
        Label22.Visible = True
        PnlFnd.Visible = False
        CountRecrds()
        Datagrd.Rows.Clear()
        If TotRecrds = 0 Then
            MsgBox("No Record Found", MsgBoxStyle.Information, "Record")
            DtpkrDt.Focus()
            Exit Sub
        End If
        chk_firstrecrd()
        Chek_Date()
        Chek_Date1()
        Count_offdayrecrd()
        Fetch_offdayrecrd()
        If count_offrecrd = 0 Then
            weekly_offday = 0
        ElseIf count_offrecrd > 0 Then
            weekly_offday = fetch_offday

        End If
        Fetch_TotRecrds()
        Fetch_Shft_Recrd()
        LblTotEmpl.Text = TotRecrds
        If counter > 0 Then
            If Recrds = 0 And DtpkrDt.Value.DayOfWeek <> weekly_offday Then
                FrmAttd.Close()

                Fetch_Mstr_Lst_Recrd()
            ElseIf Recrds = 0 And DtpkrDt.Value.DayOfWeek = weekly_offday And first_recrd >= 0 Then

                FrmAttd.Close()
                Fetch_Mstr_Lst_Sunday_Recrd()

            ElseIf Recrds <> 0 Then
                FrmAttd.Close()
                Fetch_Attd_Lst_Recrd()
            End If

        ElseIf counter = 0 And first_recrd = 0 And counter1 = 0 Then

            If DtpkrDt.Value.DayOfWeek <> weekly_offday And counter1 = 0 Then
                FrmAttd.Close()
                Fetch_Mstr_Lst_Recrd()
            ElseIf DtpkrDt.Value.DayOfWeek = weekly_offday And counter1 = 0 Then
                FrmAttd.Close()
                Fetch_Mstr_Lst_Sunday_Recrd()

            End If
        ElseIf counter = 0 And first_recrd > 0 And counter1 > 0 Then
            FrmAttd.Close()
            Fetch_Attd_Lst_Recrd()
        ElseIf counter = 0 And DtpkrDt.Value.DayOfWeek <> weekly_offday Or counter = 0 And cmbxsift.Text <> offshft Or counter = 0 And DtpkrDt.Value.Date < Fromdt And DtpkrDt.Value.Date > Todt Then

            Datagrd.Rows.Clear()

            Fetch_Max_Attd()

            If DtpkrDt.Value.Date < min_date Then
                MsgBox("Starting Date of Attendance is '" & (Format(min_date, "dd/MM/yyyy")) & "' of the selected shift", MsgBoxStyle.Information, "Start Date")
            Else
                Me.Text = "Attendence!!! Alert >>> " & "First mark the pending Attendance of '" & (Format(max_date.AddDays(+1), "dd/MM/yyyy"))
                Me.cmbxshft.Focus()
                Exit Sub
            End If
            Me.Text = "Attendence"
            FrmAttd.Focus()
            Me.Close()

            DtpkrDt.Focus()

            Exit Sub

        ElseIf counter = 0 And DtpkrDt.Value.DayOfWeek = weekly_offday And cmbxsift.Text = offshft And counter1 = 0 Then
            FrmAttd.Close()

            Datagrd.Rows.Clear()
            Fetch_TotRecrds()
            Fetch_Shft_Recrd()
            CountRecrds()
            LblTotEmpl.Text = TotRecrds

            Fetch_Mstr_Lst_Sunday_Recrd()

        ElseIf DtpkrDt.Value.DayOfWeek = weekly_offday And cmbxsift.Text = offshft And counter1 > 0 Then
            FrmAttd.Close()
            Datagrd.Rows.Clear()
            Fetch_TotRecrds()
            Fetch_Shft_Recrd()
            CountRecrds()
            LblTotEmpl.Text = TotRecrds
            Fetch_Attd_Lst_Recrd()
        End If


    End Sub

    Private Sub Fetch_EmpName_recrds()
        Dim Emplid As Integer
        curntdt = DtpkrDt.Value.Date
        Try
            Attd_Sift_Cmd = New SqlCommand("Select empid from FinactEmpmstr where empname='" & (CmbxEmpName.Text) & " 'and empjnDt<='" & (DtpkrDt.Value.Date) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.HasRows = True Then
                Emplid = Attd_Sift_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdEmpid) from Finact_Attd where Attddt='" & (curntdt) & "'and AttdSft='" & (Cmbxsift1.Text) & "'and AttdEmpid='" & (Emplid) & " '", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then

                Recrds = (Attd_Sift_Rdr(0))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub RbEname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbEname.CheckedChanged

        If RbEname.Checked = True Then
            RbDept.Visible = False
            RbAll.Visible = False
            CmbxEmpName.Visible = True
            CmbxEmpName.Location = New System.Drawing.Point(63, 90)
            fetch_Cmbx_Ename()
            CmbxEmpName.Focus()
            Datagrd.Rows.Clear()

            PnlFnd.Height = 161
            PnlFnd.Location = New System.Drawing.Point(412, 156)
            LblLine.Visible = False
            BtnOk.Location = New System.Drawing.Point(53, 128)
            BtnCncl.Location = New System.Drawing.Point(123, 128)

        End If
    End Sub

    Private Sub fetch_Cmbx_Ename()
        CmbxEmpName.Items.Clear()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select empname from FinactEmpmstr where empdelstatus=1 and empcateg='Working' and empothrsift='" & (Cmbxsift1.Text) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "' order by empname ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            While Attd_Sift_Rdr.Read
                If Attd_Sift_Rdr.HasRows = True Then
                    CmbxEmpName.Items.Add(Attd_Sift_Rdr(0))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub


    Private Sub Fetch_DeptName()
        DeptName = ""
        Try
            Dept_Name_Cmd = New SqlCommand("Select deptname from finactdept where deptid='" & (Deptid) & "'", FinActConn)
            Dept_Name_Rdr = Dept_Name_Cmd.ExecuteReader
            If Trim(Deptid) <> "" Then
                Dept_Name_Rdr.Read()
                If Dept_Name_Rdr.HasRows = True Then
                    DeptName = Dept_Name_Rdr(0)

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Dept_Name_Rdr.Close()
            Dept_Name_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_DesigName()
        DesigName = ""
        Try
            Desig_Name_Cmd = New SqlCommand("Select deptname from finactdept where deptid='" & (Desiid) & "'", FinActConn)
            Desig_Name_Rdr = Desig_Name_Cmd.ExecuteReader
            If Trim(Desiid) <> "" Then
                Desig_Name_Rdr.Read()
                If Desig_Name_Rdr.HasRows = True Then
                    DesigName = Desig_Name_Rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Desig_Name_Rdr.Close()
            Desig_Name_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Sift()
        Shift = ""
        Try
            Attd_Sift_Cmd = New SqlCommand("Select empothrsift from FinactEmpmstr where empid='" & (Empid) & "' ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            If Trim(Empid) <> "" Then
                Attd_Sift_Rdr.Read()
                If Attd_Sift_Rdr.HasRows = True Then

                    Shift = Attd_Sift_Rdr(0)

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub


    Private Sub RbDept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbDept.CheckedChanged
        If RbDept.Checked = True Then
            RbDept.Location = New System.Drawing.Point(115, 52)
            CmbxDept.Location = New System.Drawing.Point(55, 94)

            Datagrd.Rows.Clear()
            cmbxsift.Visible = False
            LblSft.Visible = True
            LblSft.Text = Cmbxsift1.Text
            CmbxDept.Visible = True
            RbEname.Visible = False
            RbAll.Visible = False
            CmbxDept.Focus()
            fetch_Cmbx_Dept()

            PnlFnd.Height = 161
            PnlFnd.Location = New System.Drawing.Point(412, 156)
            LblLine.Visible = False
            BtnOk.Location = New System.Drawing.Point(53, 128)
            BtnCncl.Location = New System.Drawing.Point(123, 128)
        Else
            RBOrdDept.Checked = False
            CmbxDept.Visible = False
        End If
    End Sub

    Private Sub fetch_Cmbx_Dept()
        CmbxDept.Items.Clear()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select deptname from finactDept where Depttype='Dept'order by deptname ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            While Attd_Sift_Rdr.Read
                If Attd_Sift_Rdr.HasRows = True Then
                    CmbxDept.Items.Add(Attd_Sift_Rdr(0))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Deptid()

        Try
            Attd_Sift_Cmd = New SqlCommand("Select deptid from FinactDept where deptname='" & (CmbxDept.Text) & "' ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            If Trim(CmbxDept.Text) <> "" Then
                Attd_Sift_Rdr.Read()
                If Attd_Sift_Rdr.HasRows = True Then
                    cmbxDeptid = Attd_Sift_Rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_DeptName_recrds()
        Fetch_Deptid()
        curntdt = DtpkrDt.Value.Date
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdEmpid) from Finact_Attd where Attddt='" & (curntdt) & "'and AttdSft='" & (Cmbxsift1.Text) & "'and AttdDeptid='" & (cmbxDeptid) & " '", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then

                Recrds = (Attd_Sift_Rdr(0))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_AllOrdr_recrds()
        curntdt = DtpkrDt.Value.Date
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdEmpid) from Finact_Attd where Attddt='" & (curntdt) & "'and AttdSft='" & (Cmbxsift1.Text) & " '", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then

                Recrds = (Attd_Sift_Rdr(0))
            Else
                MsgBox("No Record Found", MsgBoxStyle.Information, "Find")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub CountRecrds()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(empid) from FinactEmpmstr where empdelstatus=1 and empcateg='Working' and empothrsift='" & (cmbxsift.Text) & "' and empjnDt<='" & (DtpkrDt.Value.Date) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then

                TotRecrds = Attd_Sift_Rdr(0)
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_TotRecrds()
        curntdt = DtpkrDt.Value.Date
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdEmpid) from Finact_Attd where Attddt='" & (curntdt) & "'and AttdSft='" & (cmbxsift.Text) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then

                Recrds = (Attd_Sift_Rdr(0))

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Attd_Lst_Recrd()
        LblPresnt.Text = 0
        LblAbsnt.Text = 0
        LblShrtLeve.Text = 0
        LblReprtlat.Text = 0
        LblShrtLeve.Text = 0
        LblHfLeve.Text = 0
        LblFDLeve.Text = 0
        Dim Status As String
        Dim Repstatus As String
        Dim InTme As Date
        Dim i As Integer = 0

        Dim strttm, endtm, add As Date
        Datagrd.Rows.Clear()
        curntdt = DtpkrDt.Value.Date
        ' cmbxsift.Visible = True And
        If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then
            Try
                Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname," _
                & " finactDesi.desiname,FinactEmpmstr.empothrsift,Finact_Attd.AttdStatus,Finact_Attd.AttdRepStatus," _
                & " Finact_Attd.AttdInTime,finactdept.deptid,Finact_Attd.AttdLeveRsn,Finact_Attd.AttdBrkOutTime,Finact_Attd.AttdBrkInTime,Finact_Attd.AttdOutTime,Finact_Attd.AttdStrtime,Finact_Attd.AttdEndtime from FinactEmpmstr inner join finactDept" _
                & " on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid" _
                & " inner join Finact_Attd on" _
                & " Finactempmstr.empid=Finact_Attd.AttdEmpid where empdelstatus=1 and empcateg='Working' and empothrsift='" & (cmbxsift.Text) & "'and Attddt='" & (curntdt) & "'", FinActConn)
                Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
                i = 0
                While Attd_Sift_Rdr.Read()
                    If Attd_Sift_Rdr.HasRows = True Then

                        'Datagrd.Rows.Add()
                        dgr = New DataGridViewRow

                        'checkbox cell
                        com = New DataGridViewCheckBoxCell
                        dgr.Cells.Add(com)

                        Empid = Attd_Sift_Rdr(0)

                        'employee id
                        cel = New DataGridViewTextBoxCell
                        cel.Value = Empid
                        dgr.Cells.Add(cel)

                        cel = New DataGridViewTextBoxCell
                        cel.Value = Attd_Sift_Rdr(1)
                        dgr.Cells.Add(cel)

                        Status = Attd_Sift_Rdr(5)
                        If Status = "Present" Then
                            LblPresnt.Text = LblPresnt.Text + 1
                        ElseIf Status = "Absent" Then
                            LblAbsnt.Text = LblAbsnt.Text + 1
                        End If
                        cel = New DataGridViewTextBoxCell
                        cel.Value = Status
                        dgr.Cells.Add(cel)

                        Repstatus = Attd_Sift_Rdr(6)
                        cel = New DataGridViewTextBoxCell
                        cel.Value = Repstatus
                        dgr.Cells.Add(cel)
                        If Repstatus = "Short Leave" Then
                            LblShrtLeve.Text = LblShrtLeve.Text + 1
                        ElseIf Repstatus = "1st Half Leave" Or Repstatus = "2nd Half Leave" Then
                            LblHfLeve.Text = LblHfLeve.Text + 1
                        ElseIf Repstatus = "Full Day Leave" Then
                            LblFDLeve.Text = LblFDLeve.Text + 1
                        ElseIf Repstatus = "Late" Then
                            LblReprtlat.Text = LblReprtlat.Text + 1
                        End If

                        cel = New DataGridViewTextBoxCell
                        cel.Value = Attd_Sift_Rdr(9)
                        dgr.Cells.Add(cel)

                        InTme = Format(Attd_Sift_Rdr(7), "HH:mm:ss")
                        'InTme = ConvertTime(InTme)
                        strttm = Format(Attd_Sift_Rdr(10), "HH:mm:ss")
                        ' strttm = ConvertTime(strttm)
                        endtm = Format(Attd_Sift_Rdr(11), "HH:mm:ss")
                        ' endtm = ConvertTime(endtm)
                        add = Format(Attd_Sift_Rdr(12), "HH:mm:ss")
                        'add = ConvertTime(endtm)

                        Me.Datagrd.Rows.Add(dgr)
                        Me.Datagrd.Rows(i).Cells(6).Value = InTme
                        Me.Datagrd.Rows(i).Cells(7).Value = strttm
                        Me.Datagrd.Rows(i).Cells(8).Value = endtm
                        Me.Datagrd.Rows(i).Cells(9).Value = add
                    Else
                        MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")
                    End If
                    i += 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
            Finally
                If Attd_Sift_Rdr.HasRows = False Then
                    MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")
                End If
                Attd_Sift_Rdr.Close()
                Attd_Sift_Cmd = Nothing
            End Try
        End If


    End Sub


    Private Sub Fetch_Mstr_Lst_Recrd()
        LblPresnt.Text = 0
        LblAbsnt.Text = 0
        LblShrtLeve.Text = 0
        LblReprtlat.Text = 0
        LblShrtLeve.Text = 0
        LblHfLeve.Text = 0
        LblFDLeve.Text = 0
        Dim i As Integer = 0
        Dim frm_dt As Date
        frm_dt = DtpkrDt.Value.Date
        Dim Mater_dt_frm As Date
        Dim Mater_dt_to As Date
        'If RbAll.Checked = True Then
        'RBEid.Checked = True
        Datagrd.Rows.Clear()
        ' cmbxsift.Visible = True And
        If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then

            Try
                Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift,finactdept.deptid from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid where empdelstatus=1 and empcateg='Working' and empothrsift='" & (cmbxsift.Text) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "' order by empid", FinActConn)
                Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
                'Attd_Sift_Rdr.Read()
                While Attd_Sift_Rdr.Read()
                    If Attd_Sift_Rdr.HasRows = True Then
                        i = 0

                        dgr = New DataGridViewRow

                        'checkbox cell
                        com = New DataGridViewCheckBoxCell
                        dgr.Cells.Add(com)

                        Empid = Attd_Sift_Rdr(0)

                        'employee id
                        cel = New DataGridViewTextBoxCell
                        cel.Value = Empid
                        dgr.Cells.Add(cel)

                        cel = New DataGridViewTextBoxCell
                        cel.Value = Attd_Sift_Rdr(1)
                        dgr.Cells.Add(cel)


                        Dim day1 As Integer = 0


                        Attd_Sift_Cmd1 = New SqlCommand("Select Mlevdt,Mlevfrm,MlevTo from Finact_Attd_Matrnitylev  where Mlevdelstatus=0  and Mlevshft='" & (cmbxsift.Text) & "'and MLevEmpid='" & (Empid) & "' ", FinActConn1)
                        Attd_Sift_Rdr1 = Attd_Sift_Cmd1.ExecuteReader

                        While Attd_Sift_Rdr1.Read()
                            If Attd_Sift_Rdr1.HasRows = True Then
                                Mater_dt_frm = Attd_Sift_Rdr1(1)
                                Mater_dt_to = Attd_Sift_Rdr1(2)
                                If Mater_dt_frm.Year = frm_dt.Year And Mater_dt_frm.Month = frm_dt.Month And Mater_dt_frm.Day = frm_dt.Day Then
                                    cel = New DataGridViewTextBoxCell
                                    cel.Value = "On leave"
                                    dgr.Cells.Add(cel)

                                    cel = New DataGridViewTextBoxCell
                                    cel.Value = "Maternity Leave"
                                    dgr.Cells.Add(cel)


                                    cel = New DataGridViewTextBoxCell
                                    cel.Value = "Maternity Leave"
                                    dgr.Cells.Add(cel)

                                    Me.Datagrd.Rows.Add(dgr)



                                ElseIf Mater_dt_frm.Year = frm_dt.Year And Mater_dt_frm.Month = frm_dt.Month And frm_dt >= Mater_dt_frm And frm_dt <= Mater_dt_to Then
                                    Mater_dt_to = Attd_Sift_Rdr1(2)
                                    day1 = Mater_dt_to.Day
                                    Dim diff As Integer = 0
                                    While Mater_dt_frm <= Mater_dt_to
                                        diff += 1
                                        Mater_dt_frm = Mater_dt_frm.AddDays(1)
                                        If Mater_dt_frm.Day = frm_dt.Day Then

                                            cel = New DataGridViewTextBoxCell
                                            cel.Value = "On leave"
                                            dgr.Cells.Add(cel)

                                            cel = New DataGridViewTextBoxCell
                                            cel.Value = "Maternity Leave"
                                            dgr.Cells.Add(cel)



                                            cel = New DataGridViewTextBoxCell
                                            cel.Value = "Maternity Leave"
                                            dgr.Cells.Add(cel)

                                            Me.Datagrd.Rows.Add(dgr)


                                        End If
                                    End While
                                    For i = 0 To Me.Datagrd.Rows.Count - 1
                                        Me.Datagrd.Rows(i).Cells(6).Value = DateTime.MinValue
                                        Me.Datagrd.Rows(i).Cells(7).Value = DateTime.MinValue
                                        Me.Datagrd.Rows(i).Cells(8).Value = DateTime.MinValue
                                        Me.Datagrd.Rows(i).Cells(9).Value = DateTime.MinValue '00:00:00
                                    Next
                                Else

                                    cel = New DataGridViewTextBoxCell
                                    cel.Value = "Nothing"
                                    dgr.Cells.Add(cel)

                                    cel = New DataGridViewTextBoxCell
                                    cel.Value = "Nothing"
                                    dgr.Cells.Add(cel)

                                    cel = New DataGridViewTextBoxCell
                                    cel.Value = ""
                                    dgr.Cells.Add(cel)

                                    Me.Datagrd.Rows.Add(dgr)


                                End If
                            End If
                        End While
                        For i = 0 To Me.Datagrd.Rows.Count - 1
                            Me.Datagrd.Rows(i).Cells(6).Value = DateTime.MinValue
                            Me.Datagrd.Rows(i).Cells(7).Value = DateTime.MinValue
                            Me.Datagrd.Rows(i).Cells(8).Value = DateTime.MinValue
                            Me.Datagrd.Rows(i).Cells(9).Value = DateTime.MinValue '00:00:00
                        Next
                        If Attd_Sift_Rdr1.HasRows = False Then

                            cel = New DataGridViewTextBoxCell
                            cel.Value = "Nothing"
                            dgr.Cells.Add(cel)

                            cel = New DataGridViewTextBoxCell
                            cel.Value = "Nothing"
                            dgr.Cells.Add(cel)


                            cel = New DataGridViewTextBoxCell
                            cel.Value = ""
                            dgr.Cells.Add(cel)


                            Me.Datagrd.Rows.Add(dgr)

                        End If

                        For i = 0 To Me.Datagrd.Rows.Count - 1
                            Me.Datagrd.Rows(i).Cells(6).Value = "00:00:00" 'DateTime.Now
                            Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00" 'DateTime.Now
                            Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00" ' DateTime.Now
                            Me.Datagrd.Rows(i).Cells(9).Value = "00:00:00" 'DateTime.Now
                        Next
                        Attd_Sift_Rdr1.Close()
                        Attd_Sift_Cmd1 = Nothing



                    End If
                    i += 1

                End While
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
            Finally
                'If Attd_Sift_Rdr.HasRows = True Then
                If Attd_Sift_Rdr.HasRows = False Then
                    MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")

                End If
                Attd_Sift_Rdr.Close()
                Attd_Sift_Cmd = Nothing
            End Try
        End If
        For i = 0 To Me.Datagrd.Rows.Count - 1
            FD_Id = Me.Datagrd.Rows(i).Cells(1).Value
            Chek_Recrd()
            If FD_flag = True Then
                If DtpkrDt.Value.Date = FD_LevFrm Or DtpkrDt.Value.Date > FD_LevFrm And DtpkrDt.Value.Date <= FD_Levto Then
                    Me.Datagrd.Rows(i).Cells(3).Value = "Leave"
                    If FD_Categ = "Full Day Leave" Then
                        Me.Datagrd.Rows(i).Cells(4).Value = "Full Day Leave"
                        Me.Datagrd.Rows(i).Cells(5).Value = FD_Type
                        Me.Datagrd.Rows(i).Cells(6).Value = "00:00:00" 'DateTime.Now
                        Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00" 'DateTime.Now
                        Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00" ' DateTime.Now
                        Me.Datagrd.Rows(i).Cells(9).Value = "00:00:00" 'DateTime.Now
                    ElseIf FD_Categ = "1st Half Day Leave" Then
                        Me.Datagrd.Rows(i).Cells(4).Value = "ist Half Day Leave"
                        Me.Datagrd.Rows(i).Cells(5).Value = FD_Type
                        Me.Datagrd.Rows(i).Cells(6).Value = LblBrkTo.Text 'DateTime.Now
                        Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00" 'DateTime.Now
                        Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00" ' DateTime.Now
                        Me.Datagrd.Rows(i).Cells(9).Value = LblEndTime.Text 'DateTime.Now
                    ElseIf FD_Categ = "2nd Half Day Leave" Then
                        Me.Datagrd.Rows(i).Cells(4).Value = "2nd Half Day Leave"
                        Me.Datagrd.Rows(i).Cells(5).Value = FD_Type
                        Me.Datagrd.Rows(i).Cells(6).Value = LblStrtTime.Text 'DateTime.Now
                        Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00" 'DateTime.Now
                        Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00" ' DateTime.Now
                        Me.Datagrd.Rows(i).Cells(9).Value = LblBrkFrm.Text 'DateTime.Now

                    End If
                End If
            End If
        Next


    End Sub

    Private Sub Chek_Recrd()
        Fetch_MaxDt()
        Try
            Attd_FullLeve_Cmd = New SqlCommand("Select LevDt,LevFrm,LevTo,LevCateg,LevType from  Finact_Attd_FDLeave where LevEmpid='" & (FD_Id) & "'and Levdelstatus=0 and LevDt='" & (max_Levdt) & "'", FinActConn)
            Attd_FullLeve_rdr = Attd_FullLeve_Cmd.ExecuteReader

            Attd_FullLeve_rdr.Read()
            If Attd_FullLeve_rdr.HasRows = True Then
                FD_Levdt = Attd_FullLeve_rdr(0)
                FD_LevFrm = Attd_FullLeve_rdr(1)
                FD_Levto = Attd_FullLeve_rdr(2)
                FD_Categ = Attd_FullLeve_rdr(3)
                FD_Type = Attd_FullLeve_rdr(4)
                FD_flag = True

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            If Attd_FullLeve_rdr.HasRows = False Then
                FD_flag = False
            End If
            Attd_FullLeve_rdr.Close()
            Attd_FullLeve_Cmd = Nothing
        End Try

        'i = i + 1
    End Sub

    Private Sub Fetch_MaxDt()

        Try
            Attd_FullLeve_Cmd = New SqlCommand("Select max(LevDt) from  Finact_Attd_FDLeave where LevEmpid='" & (FD_Id) & "'and Levdelstatus=0", FinActConn)
            Attd_FullLeve_rdr = Attd_FullLeve_Cmd.ExecuteReader

            Attd_FullLeve_rdr.Read()
            If Attd_FullLeve_rdr.IsDBNull(0) = False Then
                max_Levdt = Attd_FullLeve_rdr(0)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally

            Attd_FullLeve_rdr.Close()
            Attd_FullLeve_Cmd = Nothing
        End Try

        'i = i + 1
    End Sub

    Private Sub RbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAll.CheckedChanged
        If RbAll.Checked = True Then
            PnlFnd.Height = 283
            PnlFnd.Location = New System.Drawing.Point(412, 156)
            BtnOk.Location = New System.Drawing.Point(41, 255)
            BtnCncl.Location = New System.Drawing.Point(110, 255)
            LblLine.Visible = True
            'RBEid.Checked = True
            PnlOrdr.Visible = True
            RBEid.Visible = True
            RBEid.Checked = True
            RBOrdEname.Visible = True
            RBOrdDept.Visible = True
        End If
    End Sub

    Private Sub RBEid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBEid.CheckedChanged
        If RBEid.Checked = True Then
            RbAll.Checked = True

        End If
    End Sub

    Private Sub fetch_EmpId()
        'Try
        '    Attd_Sift_Cmd = New SqlCommand("Select empid from FinactEmpmstr inner join Finactempothr on FinactEmpmstr.empid=Finactempothr.empothrconcrnid where empdelstatus=1 and empothrsift='" & (Cmbxsift1.Text) & "' order by empid ", FinActConn)
        '    Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
        '    While Attd_Sift_Rdr.Read()
        '        If Attd_Sift_Rdr.HasRows = True Then
        '            CmbxEid.Items.Add(Attd_Sift_Rdr(0))

        '        End If
        '    End While
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        'Finally
        '    Attd_Sift_Rdr.Close()
        '    Attd_Sift_Cmd = Nothing
        'End Try
    End Sub


    Private Sub RBOrdEname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBOrdEname.CheckedChanged
        'If RbEname.Checked = True And RBOrdEname.Checked = True Then
        '    CmbxEmpName.Visible = True
        '    CmbxEmpName.Focus()
        '    fetch_Cmbx_Ename()
        'Else
        '    CmbxEmpName.Visible = False
        'End If
    End Sub


    Private Sub RBOrdDept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBOrdDept.CheckedChanged
        If RbDept.Checked = True And RBOrdDept.Checked = True Then
            CmbxDept.Visible = True
            CmbxDept.Focus()
            fetch_Cmbx_Dept()
        Else
            CmbxDept.Visible = False
        End If
    End Sub

    Private Sub DtpkrDt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrDt.GotFocus
        DtpkrDt.MaxDate = Now.Date

    End Sub

    Private Sub DtpkrDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDt.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            cmbxsift.Focus()
        End If
    End Sub

    Private Sub cmbxsift_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxsift.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then

            Dim weekly_offday As Integer
            PnlTotEmp.Visible = True
            Label22.Visible = True
            PnlFnd.Visible = False
            CountRecrds()
            Datagrd.Rows.Clear()
            If TotRecrds = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information, "Record")
                DtpkrDt.Focus()
                Exit Sub
            End If
            chk_firstrecrd()
            Chek_Date()
            Chek_Date1()
            Count_offdayrecrd()
            Fetch_offdayrecrd()
            If count_offrecrd = 0 Then
                weekly_offday = 0
            ElseIf count_offrecrd > 0 Then
                weekly_offday = fetch_offday

            End If
            Fetch_TotRecrds()
            Fetch_Shft_Recrd()
            LblTotEmpl.Text = TotRecrds
            If counter > 0 Then
                If Recrds = 0 And DtpkrDt.Value.DayOfWeek <> weekly_offday Then
                    'Or Recrds = 0 And cmbxsift.Text <> offshft Or Recrds = 0 And Fromdt < DtpkrDt.Value.Date And DtpkrDt.Value.Date > Todt Then
                    Fetch_Mstr_Lst_Recrd()
                ElseIf Recrds = 0 And DtpkrDt.Value.DayOfWeek = weekly_offday And first_recrd >= 0 Then
                    'And cmbxsift.Text = offshft Then
                    Fetch_Mstr_Lst_Sunday_Recrd()

                ElseIf Recrds <> 0 Then
                    Fetch_Attd_Lst_Recrd()
                End If
                'ElseIf counter > 0 And DtpkrDt.Value.DayOfWeek = DayOfWeek.Sunday Then
                '   Datagrd.Rows.Clear()
                '    Fetch_TotRecrds()
                '    Fetch_Shft_Recrd()
                '    CountRecrds()
                '    LblTotEmpl.Text = TotRecrds
                '    Fetch_Mstr_Lst_Sunday_Recrd()

            ElseIf counter = 0 And first_recrd = 0 And counter1 = 0 Then

                If DtpkrDt.Value.DayOfWeek <> weekly_offday And counter1 = 0 Then
                    Fetch_Mstr_Lst_Recrd()
                ElseIf DtpkrDt.Value.DayOfWeek = weekly_offday And counter1 = 0 Then
                    Fetch_Mstr_Lst_Sunday_Recrd()

                End If
            ElseIf counter = 0 And first_recrd > 0 And counter1 > 0 Then

                Fetch_Attd_Lst_Recrd()
            ElseIf counter = 0 And DtpkrDt.Value.DayOfWeek <> weekly_offday Or counter = 0 And cmbxsift.Text <> offshft Or counter = 0 And DtpkrDt.Value.Date < Fromdt And DtpkrDt.Value.Date > Todt Then

                Datagrd.Rows.Clear()


                MsgBox("Please mark the Attendance of Yesterday first", MsgBoxStyle.Information, "Attendance")
                DtpkrDt.Focus()
                ' DtpkrDt.Focus()

                'If cmbxsift.SelectedIndex >= 1 Then
                '    cmbxsift.SelectedValue = 0
                '    cmbxsift.SelectedIndex = 0

                'End If


                'cmbxsift.Text = ""
                Exit Sub

            ElseIf counter = 0 And DtpkrDt.Value.DayOfWeek = weekly_offday And cmbxsift.Text = offshft And counter1 = 0 Then
                Datagrd.Rows.Clear()
                Fetch_TotRecrds()
                Fetch_Shft_Recrd()
                CountRecrds()
                LblTotEmpl.Text = TotRecrds

                '   If Recrds = 0 Then
                Fetch_Mstr_Lst_Sunday_Recrd()


                'ElseIf Recrds <> 0 Then
                ' Fetch_Attd_Lst_Recrd()
                ' End If
            ElseIf DtpkrDt.Value.DayOfWeek = weekly_offday And cmbxsift.Text = offshft And counter1 > 0 Then
                Datagrd.Rows.Clear()
                Fetch_TotRecrds()
                Fetch_Shft_Recrd()
                CountRecrds()
                LblTotEmpl.Text = TotRecrds


                Fetch_Attd_Lst_Recrd()
            End If


            ''If Datagrd.Rows.Count > 0 Then
            ''    btnPrsentAll.Focus()
            ''Else
            ''    DtpkrDt.Focus()

            ''End If
        End If
    End Sub

    Private Sub clrval()
        Datagrd.Rows.Clear()
        LblStrtTime.Text = ""
        LblEndTime.Text = ""
        LblBrkFrm.Text = ""
        LblBrkTo.Text = ""
        LblTotEmpl.Text = ""
        LblPresnt.Text = ""
        LblAbsnt.Text = ""
        LblShrtLeve.Text = ""
        LblReprtlat.Text = ""
        LblShrtLeve.Text = ""
        LblHfLeve.Text = ""
        LblFDLeve.Text = ""
        cmbxsift.Text = ""
        RbDept.Checked = False
        RbAll.Checked = False
        RBEid.Checked = False
        RBOrdEname.Checked = False
        RBOrdDept.Checked = False
        LblSft.Text = ""
        RbOut_All.Checked = False
        RbOut_Sel.Checked = False
    End Sub


    Private Sub Btnrest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnrest.Click
        i = 0
        If Attd_Type = 1 Then
            For i = 0 To Me.Datagrd.Rows.Count - 1
                Me.Datagrd.Rows(i).Cells(3).Value = "Nothing"
                Me.Datagrd.Rows(i).Cells(4).Value = "Nothing"
                Me.Datagrd.Rows(i).Cells(5).Value = "Nothing"
                Me.Datagrd.Rows(i).Cells(6).Value = "00:00:00"
                Me.Datagrd.Rows(i).Cells(0).Value = False
            Next
        ElseIf Attd_Type = 2 Then
            For i = 0 To Me.Datagrd.Rows.Count - 1
                Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00"
                Me.Datagrd.Rows(i).Cells(0).Value = False
            Next
        ElseIf Attd_Type = 3 Then
            For i = 0 To Me.Datagrd.Rows.Count - 1
                Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00"
                Me.Datagrd.Rows(i).Cells(0).Value = False
            Next
        ElseIf Attd_Type = 4 Then
            For i = 0 To Me.Datagrd.Rows.Count - 1
                Me.Datagrd.Rows(i).Cells(9).Value = "00:00:00"
                Me.Datagrd.Rows(i).Cells(0).Value = False
            Next
        ElseIf Attd_Type = 5 Then
            For i = 0 To Me.Datagrd.Rows.Count - 1
                Me.Datagrd.Rows(i).Cells(3).Value = "Nothing"
                Me.Datagrd.Rows(i).Cells(4).Value = "Nothing"
                Me.Datagrd.Rows(i).Cells(5).Value = "Nothing"
                Me.Datagrd.Rows(i).Cells(6).Value = "00:00:00"
                Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00"
                Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00"
                Me.Datagrd.Rows(i).Cells(9).Value = "00:00:00"
                Me.Datagrd.Rows(i).Cells(0).Value = False
            Next
        End If
        LblAbsnt.Text = 0
        LblPresnt.Text = 0
        LblShrtLeve.Text = 0
        LblFDLeve.Text = 0
        LblHfLeve.Text = 0
        LblReprtlat.Text = 0
        Rball_attd.Checked = False
        Rball_sel.Checked = False
        RbOut_All.Checked = False
        RbOut_Sel.Checked = False
        

    End Sub

    Private Sub btnPrsentAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrsentAll.Click

        LstCount = Datagrd.Rows.Count
        Dim counter As Integer = 0
        Count_offdayrecrd()
        Fetch_offdayrecrd()
        If LstCount <> 0 Then
            While counter < LstCount
                If Datagrd.Rows(counter).Cells(3).Value = "Holiday" And count_offrecrd > 0 And DtpkrDt.Value.DayOfWeek = fetch_offday Then
                    edit_flag = True
                ElseIf Datagrd.Rows(counter).Cells(3).Value = "Holiday" And count_offrecrd = 0 And DtpkrDt.Value.DayOfWeek = 0 Then
                    edit_flag = True
                Else
                    edit_flag = False
                End If
                counter = counter + 1
            End While
            If edit_flag = True Then
                MsgBox(String.Format("This day is marked as Weekday off/Holiday.If status is changed then{0} the system will count it as Overtime/Paid Holiday{0}", Environment.NewLine), MsgBoxStyle.Exclamation, "Warning")
                cnfrmmsg = MsgBox("Do you want to change the Status?", MsgBoxStyle.YesNo, "Confirmation")
                If cnfrmmsg = vbNo Then
                    Exit Sub
                End If
            End If
            counter = 0

            While counter < LstCount

                If Datagrd.Rows(counter).Cells(4).Value <> "Maternity Leave" And Datagrd.Rows(counter).Cells(4).Value <> "Full Day Leave" And Datagrd.Rows(counter).Cells(4).Value <> "1st Half Day Leave" And Datagrd.Rows(counter).Cells(4).Value <> "2nd Half Day Leave" Then

                    If Datagrd.Rows(counter).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                        LblAbsnt.Text = LblAbsnt.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                        LblPresnt.Text = LblPresnt.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                        LblShrtLeve.Text = LblShrtLeve.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                        LblFDLeve.Text = LblFDLeve.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                        LblReprtlat.Text = LblReprtlat.Text - 1
                    End If
                    If edit_flag = False Then
                        Datagrd.Rows(counter).Cells(3).Value = "Present"
                    ElseIf edit_flag = True Then
                        Datagrd.Rows(counter).Cells(3).Value = "Paid Holiday"
                    End If

                    Datagrd.Rows(counter).Cells(4).Value = "On Time"
                    Datagrd.Rows(counter).Cells(5).Value = "Present"
                    Me.Datagrd.Rows(counter).Cells(6).Value = LblStrtTime.Text
                    If Attd_Type = 1 Or Attd_Type = 2 Or Attd_Type = 3 Then
                        Me.Datagrd.Rows(counter).Cells(9).Value = "00:00:00"
                    ElseIf Attd_Type = 5 Or Attd_Type = 4 Then

                        Me.Datagrd.Rows(counter).Cells(9).Value = LblEndTime.Text
                    End If
                    'Else

                    '    MsgBox("Can't be mark as Present")
                End If

                counter = counter + 1
            End While
            '  Next
            LblPresnt.Text = LblPresnt.Text + LstCount
        Else
            MsgBox("No Record Found in the List to mark Present", MsgBoxStyle.Information, "Find")

        End If


    End Sub

    Private Sub BtnabsntAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnabsntAll.Click
        LstCount = Datagrd.Rows.Count
        Dim counter As Integer = 0
        Count_offdayrecrd()
        Fetch_offdayrecrd()
        If LstCount <> 0 Then
            While counter < LstCount
                If Datagrd.Rows(counter).Cells(3).Value = "Holiday" And count_offrecrd > 0 And DtpkrDt.Value.DayOfWeek = fetch_offday Then
                    edit_flag = True
                ElseIf Datagrd.Rows(counter).Cells(3).Value = "Holiday" And count_offrecrd = 0 And DtpkrDt.Value.DayOfWeek = 0 Then
                    edit_flag = True
                Else
                    edit_flag = False
                End If
                counter = counter + 1
            End While
            If edit_flag = True Then
                MsgBox(String.Format("This day is marked as Weekday off/Holiday.If status is changed then{0} the system will count it as Overtime/Paid Holiday{0}", Environment.NewLine), MsgBoxStyle.Exclamation, "Warning")
                cnfrmmsg = MsgBox("Do you want to change the Status?", MsgBoxStyle.YesNo, "Confirmation")
                If cnfrmmsg = vbNo Then
                    Exit Sub
                End If
            End If
            counter = 0
            While counter < LstCount

                If Datagrd.Rows(counter).Cells(4).Value <> "Maternity Leave" And Datagrd.Rows(counter).Cells(4).Value <> "Full Day Leave" And Datagrd.Rows(counter).Cells(4).Value <> "1st Half Day Leave" And Datagrd.Rows(counter).Cells(4).Value <> "2nd Half Day Leave" Then
                    If Datagrd.Rows(counter).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                        LblAbsnt.Text = LblAbsnt.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                        LblPresnt.Text = LblPresnt.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                        LblShrtLeve.Text = LblShrtLeve.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                        LblFDLeve.Text = LblFDLeve.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.Rows(counter).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                        LblReprtlat.Text = LblReprtlat.Text - 1
                    End If
                    If edit_flag = False Then
                        Datagrd.Rows(counter).Cells(3).Value = "Absent"
                    ElseIf edit_flag = True Then
                        Datagrd.Rows(counter).Cells(3).Value = "Paid Holiday"
                    End If
                    Datagrd.Rows(counter).Cells(4).Value = "Absent"
                    Datagrd.Rows(counter).Cells(5).Value = "Absent"
                    Datagrd.Rows(counter).Cells(6).Value = "00:00:00"
                    Datagrd.Rows(counter).Cells(9).Value = "00:00:00" '"Absent"
                End If
                counter = counter + 1
            End While
            LblAbsnt.Text = LblAbsnt.Text + LstCount
        Else
            MsgBox("No Record Found in the List to mark Absent", MsgBoxStyle.Information, "Find")

        End If
    End Sub

    Private Sub BtnPresnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPresnt.Click

        If Datagrd.Rows.Count > 0 Then
            LstCount = Datagrd.SelectedRows.Count
        End If
        For i = 0 To Me.Datagrd.Rows.Count - 1

            If Me.Datagrd.Rows(i).Cells(0).Value = True Then
                If Datagrd.Rows(i).Cells(3).Value = "Holiday" And count_offrecrd > 0 And DtpkrDt.Value.DayOfWeek = fetch_offday Then
                    edit_flag = True
                ElseIf Datagrd.Rows(i).Cells(3).Value = "Holiday" And count_offrecrd = 0 And DtpkrDt.Value.DayOfWeek = 0 Then
                    edit_flag = True
                Else
                    edit_flag = False
                End If
                If edit_flag = True Then
                    MsgBox(String.Format("This day is marked as Weekday off/Holiday.If status is changed then{0} the system will count it as Overtime/Paid Holiday{0}", Environment.NewLine), MsgBoxStyle.Exclamation, "Warning")
                    cnfrmmsg = MsgBox("Do you want to change the Status?", MsgBoxStyle.YesNo, "Confirmation")
                    If cnfrmmsg = vbNo Then
                        Exit Sub
                    End If
                End If
                If Datagrd.Rows(i).Cells(3).Value = "Full Day Leave" Then
                    MsgBox("System has found a Full Day Leave", MsgBoxStyle.Information, "Leave")
                    MsgBox("Do you want to change the Status?", MsgBoxStyle.YesNo, "Status")


                ElseIf Datagrd.Rows(i).Cells(3).Value <> "Maternity Leave" Then
                    If Datagrd.Rows(i).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                        LblAbsnt.Text = LblAbsnt.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                        LblPresnt.Text = LblPresnt.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                        LblShrtLeve.Text = LblShrtLeve.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                        LblFDLeve.Text = LblFDLeve.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                        LblReprtlat.Text = LblReprtlat.Text - 1
                    End If
                    If edit_flag = False Then
                        Datagrd.Rows(i).Cells(3).Value = "Present"
                    ElseIf edit_flag = True Then
                        Datagrd.Rows(i).Cells(3).Value = "Paid Holiday"
                    End If

                    Datagrd.Rows(i).Cells(4).Value = "On Time"
                    Datagrd.Rows(i).Cells(5).Value = "Present"
                    Datagrd.Rows(i).Cells(6).Value = LblStrtTime.Text
                    If Attd_Type = 1 Or Attd_Type = 2 Or Attd_Type = 3 Then
                        Datagrd.Rows(i).Cells(9).Value = "00:00:00"
                    ElseIf Attd_Type = 5 Or Attd_Type = 4 Then

                        Datagrd.Rows(i).Cells(9).Value = LblEndTime.Text
                    End If
                Else
                    MsgBox("Can't change the Status as Maternity Leave is being issued.", MsgBoxStyle.Information, "Present Status")
                End If

                LblPresnt.Text = LblPresnt.Text + LstCount
                sel_flag = True
            End If

        Next
        Dim counter As Integer = 0
        Count_offdayrecrd()
        Fetch_offdayrecrd()
        If LstCount <> 0 Then
            While counter < LstCount
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Holiday" And count_offrecrd > 0 And DtpkrDt.Value.DayOfWeek = fetch_offday Then
                    edit_flag = True
                ElseIf Datagrd.SelectedRows(counter).Cells(3).Value = "Holiday" And count_offrecrd = 0 And DtpkrDt.Value.DayOfWeek = 0 Then
                    edit_flag = True
                Else
                    edit_flag = False
                End If
                counter = counter + 1
            End While
            If edit_flag = True Then
                MsgBox(String.Format("This day is marked as Weekday off/Holiday.If status is changed then{0} the system will count it as Overtime/Paid Holiday{0}", Environment.NewLine), MsgBoxStyle.Exclamation, "Warning")
                cnfrmmsg = MsgBox("Do you want to change the Status?", MsgBoxStyle.YesNo, "Confirmation")
                If cnfrmmsg = vbNo Then
                    Exit Sub
                End If
            End If
            counter = 0
            While counter < LstCount
                If Datagrd.SelectedRows(counter).Cells(4).Value = "Full Day Leave" Then
                    MsgBox("System has found a Full Day Leave of '" & (Datagrd.SelectedRows(counter).Cells(2).Value) & "'", MsgBoxStyle.Information, "Leave")
                    cnfrmmsg = MsgBox("Do you want to change the Status?", MsgBoxStyle.YesNo, "Status")
                    If cnfrmmsg = vbYes Then
                        FD_Id = Datagrd.SelectedRows(counter).Cells(1).Value
                        DelRec_FDLeave()
                        If Datagrd.SelectedRows(counter).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                            LblAbsnt.Text = LblAbsnt.Text - 1
                        End If
                        If Datagrd.SelectedRows(counter).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                            LblPresnt.Text = LblPresnt.Text - 1
                        End If
                        If Datagrd.SelectedRows(counter).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                            LblShrtLeve.Text = LblShrtLeve.Text - 1
                        End If
                        If Datagrd.SelectedRows(counter).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                            LblFDLeve.Text = LblFDLeve.Text - 1
                        End If
                        If Datagrd.SelectedRows(counter).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                            LblHfLeve.Text = LblHfLeve.Text - 1
                        End If
                        If Datagrd.SelectedRows(counter).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                            LblHfLeve.Text = LblHfLeve.Text - 1
                        End If
                        If Datagrd.SelectedRows(counter).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                            LblReprtlat.Text = LblReprtlat.Text - 1
                        End If
                        If edit_flag = False Then
                            Datagrd.SelectedRows(counter).Cells(3).Value = "Present"
                        ElseIf edit_flag = True Then
                            Datagrd.SelectedRows(counter).Cells(3).Value = "Paid Holiday"
                        End If

                        Datagrd.SelectedRows(counter).Cells(4).Value = "On Time"
                        Datagrd.SelectedRows(counter).Cells(5).Value = "Present"
                        Datagrd.SelectedRows(counter).Cells(6).Value = LblStrtTime.Text
                        If Attd_Type = 1 Or Attd_Type = 2 Or Attd_Type = 3 Then
                            Datagrd.Rows(counter).Cells(9).Value = "00:00:00"
                        ElseIf Attd_Type = 5 Or Attd_Type = 4 Then

                            Datagrd.Rows(counter).Cells(9).Value = LblEndTime.Text
                        End If
                    End If
                ElseIf Datagrd.SelectedRows(counter).Cells(4).Value <> "Maternity Leave" Then
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                        LblAbsnt.Text = LblAbsnt.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                        LblPresnt.Text = LblPresnt.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                        LblShrtLeve.Text = LblShrtLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                        LblFDLeve.Text = LblFDLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                        LblReprtlat.Text = LblReprtlat.Text - 1
                    End If
                    If edit_flag = False Then
                        Datagrd.SelectedRows(counter).Cells(3).Value = "Present"
                    ElseIf edit_flag = True Then
                        Datagrd.SelectedRows(counter).Cells(3).Value = "Paid Holiday"
                    End If

                    Datagrd.SelectedRows(counter).Cells(4).Value = "On Time"
                    Datagrd.SelectedRows(counter).Cells(5).Value = "Present"
                    Datagrd.SelectedRows(counter).Cells(6).Value = LblStrtTime.Text
                    If Attd_Type = 1 Or Attd_Type = 2 Or Attd_Type = 3 Then
                        Datagrd.Rows(counter).Cells(9).Value = "00:00:00"
                    ElseIf Attd_Type = 5 Or Attd_Type = 4 Then

                        Datagrd.Rows(counter).Cells(9).Value = LblEndTime.Text
                    End If
                Else
                    MsgBox("Can't change the Status as Maternity Leave is being issued.", MsgBoxStyle.Information, "Present Status")
                End If
                counter = counter + 1
            End While
            LblPresnt.Text = LblPresnt.Text + LstCount
        ElseIf LstCount = 0 And sel_flag = False Then
            MsgBox("No Record Selected in the List", MsgBoxStyle.Information, "Find")
        End If
    End Sub


    Private Sub DelRec_FDLeave()

        Try
            Attd_FullLeve_Cmd = New SqlCommand("Finact_Delete_FDleave", FinActConn)
            Attd_FullLeve_Cmd.CommandType = CommandType.StoredProcedure
            Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevEmpid", FD_Id)
            Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levdelusrid", Current_UsrId)
            Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levdeldt", Now)
            Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levdelstatus", 1)
            Attd_FullLeve_Cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_FullLeve_Cmd = Nothing
        End Try

    End Sub


    Private Sub BtnAbsnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbsnt.Click
        LstCount = Datagrd.SelectedRows.Count

        For i = 0 To Me.Datagrd.Rows.Count - 1

            If Me.Datagrd.Rows(i).Cells(0).Value = True Then
                If Datagrd.Rows(i).Cells(3).Value = "Holiday" And count_offrecrd > 0 And DtpkrDt.Value.DayOfWeek = fetch_offday Then
                    edit_flag = True
                ElseIf Datagrd.Rows(i).Cells(3).Value = "Holiday" And count_offrecrd = 0 And DtpkrDt.Value.DayOfWeek = 0 Then
                    edit_flag = True
                Else
                    edit_flag = False
                End If
                If edit_flag = True Then
                    MsgBox(String.Format("This day is marked as Weekday off/Holiday.If status is changed then{0} the system will count it as Overtime/Paid Holiday{0}", Environment.NewLine), MsgBoxStyle.Exclamation, "Warning")
                    cnfrmmsg = MsgBox("Do you want to change the Status?", MsgBoxStyle.YesNo, "Confirmation")
                    If cnfrmmsg = vbNo Then
                        Exit Sub
                    End If
                End If
                If Datagrd.Rows(i).Cells(3).Value <> "Maternity Leave" Then
                    If Datagrd.Rows(i).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                        LblAbsnt.Text = LblAbsnt.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                        LblPresnt.Text = LblPresnt.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                        LblShrtLeve.Text = LblShrtLeve.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                        LblFDLeve.Text = LblFDLeve.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.Rows(i).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                        LblReprtlat.Text = LblReprtlat.Text - 1
                    End If
                    If edit_flag = False Then
                        Datagrd.Rows(i).Cells(3).Value = "Absent"
                    ElseIf edit_flag = True Then
                        Datagrd.Rows(i).Cells(3).Value = "Paid Holiday"
                    End If

                    Datagrd.Rows(i).Cells(4).Value = "Absent"
                    Datagrd.Rows(i).Cells(5).Value = "Absent"
                    Datagrd.Rows(i).Cells(6).Value = "00:00:00"

                    Datagrd.Rows(i).Cells(9).Value = "00:00:00 "
                Else
                    MsgBox("Can't change the Status as Maternity Leave is being issued.", MsgBoxStyle.Information, "Present Status")
                End If

                LblAbsnt.Text = LblAbsnt.Text + LstCount
                sel_flag = True
            End If

        Next


        Dim counter As Integer = 0
        Count_offdayrecrd()
        Fetch_offdayrecrd()
        If LstCount <> 0 Then
            While counter < LstCount
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Holiday" And count_offrecrd > 0 And DtpkrDt.Value.DayOfWeek = fetch_offday Then
                    edit_flag = True
                ElseIf Datagrd.SelectedRows(counter).Cells(3).Value = "Holiday" And count_offrecrd = 0 And DtpkrDt.Value.DayOfWeek = 0 Then
                    edit_flag = True
                Else
                    edit_flag = False
                End If
                counter = counter + 1
            End While
            If edit_flag = True Then
                MsgBox(String.Format("This day is marked as Weekday off/Holiday.If status is changed then{0} the system will count it as Overtime/Paid Holiday{0}", Environment.NewLine), MsgBoxStyle.Exclamation, "Warning")
                cnfrmmsg = MsgBox("Do you want to change the Status?", MsgBoxStyle.YesNo, "Confirmation")
                If cnfrmmsg = vbNo Then
                    Exit Sub
                End If

            End If
            counter = 0
            While counter < LstCount
                If Datagrd.SelectedRows(counter).Cells(3).Value <> "Maternity Leave" Then
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                        LblAbsnt.Text = LblAbsnt.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                        LblPresnt.Text = LblPresnt.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                        LblShrtLeve.Text = LblShrtLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                        LblFDLeve.Text = LblFDLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                        LblReprtlat.Text = LblReprtlat.Text - 1
                    End If
                    If edit_flag = False Then
                        Datagrd.SelectedRows(counter).Cells(3).Value = "Absent"
                    ElseIf edit_flag = True Then
                        Datagrd.SelectedRows(counter).Cells(3).Value = "Paid Holiday"
                    End If
                    Datagrd.SelectedRows(counter).Cells(4).Value = "Absent"
                    Datagrd.SelectedRows(counter).Cells(5).Value = "Absent"
                    Datagrd.SelectedRows(counter).Cells(6).Value = "00:00:00"
                    Datagrd.SelectedRows(counter).Cells(9).Value = "00:00:00" '"Absent"
                Else
                    MsgBox("Can't change the Status as Maternity Leave is being issued.", MsgBoxStyle.Information, "Absent Status")
                End If
                counter = counter + 1
            End While
            LblAbsnt.Text = LblAbsnt.Text + LstCount
        ElseIf LstCount = 0 And sel_flag = False Then
            MsgBox("No Record Selected in the List", MsgBoxStyle.Information, "Find")

        End If
    End Sub


    Private Sub Fetch_Num_of_Levs_Mstr()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select Empcasual,Empsicklv,Empsrtlv from FinactEmplevMstr where Empdelstatus=0", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.HasRows = True Then
                Caslv = Attd_Sift_Rdr(0)
                Sicklv = Attd_Sift_Rdr(1)
                Srtlv = Attd_Sift_Rdr(2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Count_Num_of_SrtLevs_Attd()
        ' Mnth = Format(DtpkrDt.Value, "MM")
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdRepStatus) from Finact_Attd where Month(Attddt)='" & (DtpkrDt.Value.Date.Month) & "'and Year(Attddt)='" & (DtpkrDt.Value.Date.Year) & "'and AttdRepStatus='Short Leave'and AttdLeveRsn='Personal' and AttdEmpid='" & (Emlid) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then

                Totsrtlv = (Attd_Sift_Rdr(0))
                MsgBox(Totsrtlv)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Count_Num_of_FDCasLevs_Attd()

        year = Format(DtpkrDt.Value, "yyyy")
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdRepStatus) from Finact_Attd where AttdMonth='" & (year) & "'and AttdRepStatus='Full Day Leave'and AttdLeveRsn='Casual Leave' and AttdEmpid='" & (Emlid) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then

                Tot_fd_caslv = (Attd_Sift_Rdr(0))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Count_Num_of_FDSickLevs_Attd()
        year = Format(DtpkrDt.Value, "yyyy")
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdRepStatus) from Finact_Attd where AttdMonth='" & (year) & "'and AttdRepStatus='Full Day Leave'and AttdLeveRsn='Sick Leave' and AttdEmpid='" & (Emlid) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then

                Tot_fd_sicklv = (Attd_Sift_Rdr(0))

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Count_Num_of_1HFCasLevs_Attd()
        Dim caslev1hf As Integer
        year = Format(DtpkrDt.Value, "yyyy")
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdRepStatus) from Finact_Attd where AttdMonth='" & (year) & "'and AttdRepStatus='1st Half Day Leave'and AttdLeveRsn='Casual Leave' and AttdEmpid='" & (Emlid) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then
                caslev1hf = (Attd_Sift_Rdr(0))
                Tot_1hf_caslv = caslev1hf / 2

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Count_Num_of_1HFSickLevs_Attd()
        Dim sicklev1hf As Integer
        year = Format(DtpkrDt.Value, "yyyy")
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdRepStatus) from Finact_Attd where AttdMonth='" & (year) & "'and AttdRepStatus='1st Half Day Leave'and AttdLeveRsn='Sick Leave' and AttdEmpid='" & (Emlid) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then
                sicklev1hf = (Attd_Sift_Rdr(0))
                Tot_1hf_sicklv = sicklev1hf / 2

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Count_Num_of_2HFCasLevs_Attd()
        Dim caslev2hf As Integer
        year = Format(DtpkrDt.Value, "yyyy")
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdRepStatus) from Finact_Attd where AttdMonth='" & (year) & "'and AttdRepStatus='2nd Half Day Leave'and AttdLeveRsn='Casual Leave' and AttdEmpid='" & (Emlid) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then
                caslev2hf = (Attd_Sift_Rdr(0))
                Tot_2hf_caslv = caslev2hf / 2
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub Count_Num_of_2HFSickLevs_Attd()
        Dim sicklev2hf As Integer
        year = Format(DtpkrDt.Value, "yyyy")
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdRepStatus) from Finact_Attd where AttdMonth='" & (year) & "'and AttdRepStatus='2nd Half Day Leave'and AttdLeveRsn='Sick Leave' and AttdEmpid='" & (Emlid) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then
                sicklev2hf = (Attd_Sift_Rdr(0))
                Tot_2hf_sicklv = sicklev2hf / 2

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub


    Private Sub Count_Num_of_EarnLevs_Attd()
        year = Format(DtpkrDt.Value, "yyyy")
        Dim Crntdt, Strt_dt, finl_dt1, finl_dt2 As Date
        Dim Crntmnth As Integer

        Crntdt = DtpkrDt.Value.Date
        Crntmnth = Crntdt.Month
        If Strt_Mnth < Crntmnth Then
            diff = Crntmnth - Strt_Mnth
            Strt_dt = Crntdt.AddMonths(-diff)

            finl_dt1 = DateSerial((Strt_dt.Date.Year), Month(Strt_dt.Date), 1)
            finl_dt2 = finl_dt1.AddMonths(+12)
            finl_dt2 = DateSerial((finl_dt2.Date.Year), Month(finl_dt2.Date), -1).AddDays(+1)
        ElseIf Strt_Mnth > Crntmnth Then
            Crntdt = DtpkrDt.Value.Date.AddMonths(-Crntmnth)
            Crntmnth = Crntdt.Month
            diff = Crntmnth - Strt_Mnth
            Strt_dt = Crntdt.AddMonths(-diff)

            finl_dt1 = DateSerial((Strt_dt.Date.Year), Month(Strt_dt.Date), 1)
            finl_dt2 = finl_dt1.AddMonths(+12)
            finl_dt2 = DateSerial((finl_dt2.Date.Year), Month(finl_dt2.Date), -1).AddDays(+1)

        End If

        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdId) from Finact_Attd where AttdRepStatus  ='1st Half Day ErnLev'  and AttdEmpid='" & (Emlid) & "'and Attddt between '" & (finl_dt1) & "'and '" & (finl_dt2) & "'  ", FinActConn)
            'Attd_Sift_Cmd = New SqlCommand("Select count(AttdRepStatus) from Finact_Attd where AttdMonth='" & (year) & "'and AttdRepStatus='Full Day Leave'and AttdLeveRsn='Casual Leave' and AttdEmpid='" & (Emlid) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then

                Fetch_ErnLevs_1HF = (Attd_Sift_Rdr(0))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try

        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdId) from Finact_Attd where AttdRepStatus  ='2nd Half Day ErnLev'  and AttdEmpid='" & (Emlid) & "'and Attddt between '" & (finl_dt1) & "'and '" & (finl_dt2) & "' ", FinActConn)
            'Attd_Sift_Cmd = New SqlCommand("Select count(AttdRepStatus) from Finact_Attd where AttdMonth='" & (year) & "'and AttdRepStatus='Full Day Leave'and AttdLeveRsn='Casual Leave' and AttdEmpid='" & (Emlid) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then

                Fetch_ErnLevs_2HF = (Attd_Sift_Rdr(0))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try

        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdId) from Finact_Attd where AttdRepStatus  ='Full Day ErnLev'  and AttdEmpid='" & (Emlid) & "'and Attddt between '" & (finl_dt1) & "'and '" & (finl_dt2) & "' ", FinActConn)
            'Attd_Sift_Cmd = New SqlCommand("Select count(AttdRepStatus) from Finact_Attd where AttdMonth='" & (year) & "'and AttdRepStatus='Full Day Leave'and AttdLeveRsn='Casual Leave' and AttdEmpid='" & (Emlid) & "'", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then

                Fetch_ErnLevs_FD = (Attd_Sift_Rdr(0))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
        Fetch_ErnLevs = Fetch_ErnLevs_1HF / 2 + Fetch_ErnLevs_2HF / 2 + Fetch_ErnLevs_FD


    End Sub

    Private Sub BtnLeave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLeave.Click
        LstCount = Datagrd.SelectedRows.Count

        If LstCount = 0 Then
            MsgBox("No Record Selected in the List", MsgBoxStyle.Information, "Find")
        Else
            If Datagrd.SelectedRows(0).Cells(5).Value <> "Maternity Leave" Then

                SrtLev_Empid = Datagrd.SelectedRows(0).Cells(1).Value

                Try
                    P_Roll_Attd_Cmd = New SqlCommand("Select FinactEmpmstr.empname from   Finactempmstr  inner join FinactEmpInfo on FinactEmpmstr.empid=FinactEmpInfo.empconcrnid where  FinactEmpInfo.empsex='Female' and FinactEmpInfo.empMarital='Married' and empid='" & (SrtLev_Empid) & "'", FinActConn)
                    'P_Roll_Attd_Cmd = New SqlCommand("Select AttdEmpid,FinactEmpmstr.empname from Finact_Attd inner join  Finactempmstr on Finact_Attd.AttdEmpid=FinactEmpmstr.empid inner join FinactEmpInfo on FinactEmpmstr.empid=FinactEmpInfo.empconcrnid where AttdSft='" & (cmbxsift.Text) & "'and Attddt='" & (DtpkrDt.Value.Date) & "'and AttdStatus ='Present' and FinactEmpInfo.empsex='Female' and FinactEmpInfo.empMarital='Married' and empid='" & (SrtLev_Empid) & "'", FinActConn)
                    ' Attd_SrtLeve_Cmd = New SqlCommand("Select empid,empname from FinactEmpmstr where empdelstatus=1 and empcateg='Working' and empothrsift='" & (CmbSft.Text) & "'and empjnDt<='" & (DtpkrDt_SL.Value.Date) & "' ", FinActConn)
                    P_Roll_Attd_Rdr = P_Roll_Attd_Cmd.ExecuteReader
                    'Attd_Sift_Rdr.Read()
                    '  While P_Roll_Attd_Rdr.Read()
                    P_Roll_Attd_Rdr.Read()
                    If P_Roll_Attd_Rdr.HasRows = True Then

                        Lev_flag = True

                        ' CmbxEmpnm.Items.Add(P_Roll_Attd_Rdr(1))

                    End If
                    ' End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
                Finally
                    If P_Roll_Attd_Rdr.HasRows = False Then
                        Lev_flag = False
                        '  MsgBox("Can't issue this leave.", "Find Record")
                        ' Dtpkrdt1.Focus()

                    End If

                    P_Roll_Attd_Rdr.Close()
                    P_Roll_Attd_Cmd = Nothing
                End Try

                GroupBox1.Visible = True
                Emlid = Datagrd.SelectedRows(0).Cells(1).Value
                PnlReprtLate.Visible = True
                RbShrtLeve.Checked = False
                RbFDLeve.Checked = False
                Rb1HFLeve.Checked = False
                Rb2HFLeve.Checked = False
                If Lev_flag = True Then
                    RbMatrntyLev.Checked = False
                    RbMatrntyLev.Visible = True
                ElseIf Lev_flag = False Then
                    RbMatrntyLev.Visible = False
                End If
                PnlReprtLate.Location = New System.Drawing.Point(342, 249)
                PnlReprtLate.Size = New System.Drawing.Point(356, 145)
                GroupBox1.Size = New System.Drawing.Point(348, 80)
                BtnRptOK.Location = New System.Drawing.Point(114, 107)
                BtnRptOK.Size = New System.Drawing.Point(39, 24)
                BtnRptCncl.Location = New System.Drawing.Point(206, 107)
                BtnRptCncl.Size = New System.Drawing.Point(55, 23)
                'PnlRT.Visible = False
                'PnlRPTime.Visible = False
                'LblResn.Visible = False
                'CmbxResn.Visible = False
                'If CmbxResn.SelectedIndex >= 1 Then
                '    CmbxResn.SelectedValue = 0
                '    CmbxResn.SelectedIndex = -1
                'End If
                'CmbxResn.Text = ""
                'Cmbxrsn2.Visible = False
                'If Cmbxrsn2.SelectedIndex >= 1 Then
                '    Cmbxrsn2.SelectedValue = 0
                '    Cmbxrsn2.SelectedIndex = -1
                'End If
                'Cmbxrsn2.Text = ""
                'LblReptm.Text = ""
                'LblSrtlvTo.Text = ""
                'LblRTime.Text = ""
            Else
                MsgBox("Can't change the Status as Maternity Leave is being issued.", MsgBoxStyle.Information, "Leave Status")
            End If
        End If
    End Sub

    Private Sub Fetch_Time_1stHF()
        Dim Brktimeto As Date
        Dim hrs As String = ""
        Dim min As String = ""
        Brktimeto = LblBrkTo.Text
        hrs = Format(Brktimeto, "hh")
        ' CmbxHrs.Items.Add(hrs)
        min = Format(Brktimeto, "mm")
        ' CmbxMint.Items.Add(min)
        ' LblReptm.Text = LblBrkTo.Text
    End Sub

    Private Sub Search_Eid()
        curntdt = DtpkrDt.Value.Date
        Try
            Srch_Eid_Cmd = New SqlCommand("select AttdEmpid from Finact_Attd where AttdEmpid='" & (Id) & "'and Attddt='" & (curntdt) & "'", FinActConn)
            Srch_Eid_Rdr = Srch_Eid_Cmd.ExecuteReader
            Srch_Eid_Rdr.Read()
            If Srch_Eid_Rdr.HasRows = True Then
                Add_Edit_Flag = False
            Else
                Add_Edit_Flag = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Srch_Eid_Cmd = Nothing
            Srch_Eid_Rdr.Close()

        End Try

    End Sub

    Private Sub Btnsve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsve.Click
        If LblStrtTime.Text = "" Or LblPresnt.Text = "" Then

            MsgBox("First select any shift to mark Attendance", MsgBoxStyle.Information, "Save")
            cmbxsift.Focus()
            Exit Sub
        End If
        Dim TotRecrd, Counter2 As Integer
        Dim Stats As String
        Dim Rpstats As String
        Dim dtval As Date
        TotRecrd = Datagrd.Rows.Count
        Counter2 = 0
        While Counter2 < TotRecrd
            Stats = Datagrd.Rows(Counter2).Cells(3).Value
            If Stats = "Nothing" Then
                MsgBox("Can't accept Status as Nothing")
                Exit Sub
            End If
            Counter2 = Counter2 + 1
        End While
        Dim Counter1 As Integer
        Counter1 = 0
        'fetch_Exprnid()
        While Counter1 < TotRecrd
            Id = Datagrd.Rows(Counter1).Cells(1).Value
            Search_Eid()

            Try
                If Add_Edit_Flag = True Then
                    Attd_Sift_Cmd = New SqlCommand("Finact_Attd_Insert", FinActConn)
                    Attd_Sift_Cmd.CommandType = CommandType.StoredProcedure
                    Attd_Sift_Cmd.Parameters.AddWithValue("@Attdadusrid", Current_UsrId)
                    Attd_Sift_Cmd.Parameters.AddWithValue("@Attdaddt", Now)

                    If cmbxsift.Visible = True Then
                        Attd_Sift_Cmd.Parameters.AddWithValue("@AttdSft", cmbxsift.Text)
                    Else
                        Attd_Sift_Cmd.Parameters.AddWithValue("@AttdSft", LblSft.Text)
                    End If

                    Attd_Sift_Cmd.Parameters.AddWithValue("@AttdStrtime", LblStrtTime.Text)
                    Attd_Sift_Cmd.Parameters.AddWithValue("@AttdEndtime", LblEndTime.Text)
                    Attd_Sift_Cmd.Parameters.AddWithValue("@AttdEmpid", Datagrd.Rows(Counter1).Cells(1).Value)
                    'Attd_Sift_Cmd.Parameters.AddWithValue("@AttdDeptid", Datagrd.Rows(Counter1).Cells(8).Text)
                    Attd_Sift_Cmd.Parameters.AddWithValue("@SlrySlip", 0)

                ElseIf Add_Edit_Flag = False Then
                    Attd_Sift_Cmd = New SqlCommand("Finact_Attd_Update", FinActConn)
                    Attd_Sift_Cmd.CommandType = CommandType.StoredProcedure
                    Attd_Sift_Cmd.Parameters.AddWithValue("@AttdEmpid", Id)
                    Attd_Sift_Cmd.Parameters.AddWithValue("@Attdedtusrid", Current_UsrId)
                    Attd_Sift_Cmd.Parameters.AddWithValue("@Attdedtdt", Now)

                End If
                Attd_Sift_Cmd.Parameters.AddWithValue("@Attddt", DtpkrDt.Value.Date)

                Rpstats = Datagrd.Rows(Counter1).Cells(4).Value
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdRepStatus", Rpstats)
                If Rpstats = "Short Leave" Then
                    Mnth = Format(DtpkrDt.Value, "MM")
                    Attd_Sift_Cmd.Parameters.AddWithValue("@AttdMonth", Mnth)
                ElseIf Rpstats = "Full Day Leave" Or Rpstats = "1st Half Day Leave" Or Rpstats = "2nd Half Day Leave" Or Rpstats = "1st Half Day ErnLev" Or Rpstats = "2nd Half Day ErnLev" Or Rpstats = "Full Day ErnLev" Or Rpstats = "Maternity Leave" Then
                    year = Format(DtpkrDt.Value, "yyyy")
                    Attd_Sift_Cmd.Parameters.AddWithValue("@AttdMonth", year)
                ElseIf Rpstats = "On Time" Or Rpstats = "Absent" Or Rpstats = "Late" Or Rpstats = "Holiday" Then
                    Attd_Sift_Cmd.Parameters.AddWithValue("@AttdMonth", 0)
                End If
                If Rpstats = "1st Half Day Leave" Or Rpstats = "2nd Half Day Leave" Or Rpstats = "1st Half Day ErnLev" Or Rpstats = "2nd Half Day ErnLev" Or Rpstats = "Maternity Leave" Then
                    Attd_Sift_Cmd.Parameters.AddWithValue("@AttdStatus", "PresntCumLev")
                Else
                    Attd_Sift_Cmd.Parameters.AddWithValue("@AttdStatus", Datagrd.Rows(Counter1).Cells(3).Value)
                End If

                dtval = (Datagrd.Rows(Counter1).Cells(6).Value)
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdInTime", Format(dtval, "HH:mm:ss"))

                dtval = (Datagrd.Rows(Counter1).Cells(7).Value)
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdBrkOutTime", Format(dtval, "HH:mm:ss"))
                dtval = (Datagrd.Rows(Counter1).Cells(8).Value)
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdBrkInTime", Format(dtval, "HH:mm:ss"))
                dtval = (Datagrd.Rows(Counter1).Cells(9).Value)
                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdOutTime", Format(dtval, "HH:mm:ss"))

                Attd_Sift_Cmd.Parameters.AddWithValue("@AttdLeveRsn", Datagrd.Rows(Counter1).Cells(5).Value)

                Attd_Sift_Cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
            Finally
                Attd_Sift_Cmd = Nothing
            End Try

            Counter1 = Counter1 + 1
        End While
        MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
        clrval()
        Me.Close()
    End Sub


    Private Sub BtnLate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLate.Click
        LstCount = Datagrd.SelectedRows.Count
        If LstCount = 0 Then
            MsgBox("No Record Selected in the List", MsgBoxStyle.Information, "Find")
        Else
            If Datagrd.SelectedRows(0).Cells(4).Value <> "Maternity Leave" Then
                Count_offdayrecrd()
                Fetch_offdayrecrd()
                counter = 0
                While counter < LstCount
                    If Datagrd.SelectedRows(0).Cells(4).Value = "Holiday" And count_offrecrd > 0 And DtpkrDt.Value.DayOfWeek = fetch_offday Then
                        edit_flag = True
                    ElseIf Datagrd.SelectedRows(0).Cells(4).Value = "Holiday" And count_offrecrd = 0 And DtpkrDt.Value.DayOfWeek = 0 Then
                        edit_flag = True
                    Else
                        edit_flag = False
                    End If
                    counter = counter + 1
                End While
                If edit_flag = True Then
                    MsgBox(String.Format("This day is marked as Weekday off/Holiday.If status is changed then{0} the system will count it as Overtime/Paid Holiday{0}", Environment.NewLine), MsgBoxStyle.Exclamation, "Warning")
                    cnfrmmsg = MsgBox("Do you want to change the Status?", MsgBoxStyle.YesNo, "Confirmation")
                    If cnfrmmsg = vbNo Then
                        Exit Sub
                    End If
                End If

                PnlLate.Visible = True
                PnlLate.Location = New System.Drawing.Point(556, 327)
                PnlLate.Size = New System.Drawing.Point(338, 129)

            Else
                MsgBox("Can't change the Status as Maternity Leave is being issued.", MsgBoxStyle.Information, "Report Late")
            End If

        End If


    End Sub



    Private Sub Chek_Date_Fnd()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(AttdStatus) from Finact_Attd where  Attddt='" & (DtpkrDt.Value.Date) & "' ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then
                counter_fnd = Attd_Sift_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub
    Private Sub BtnFnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd.Click
        Chek_Date_Fnd()
        If counter_fnd > 0 Then
            clrval()
            PnlFnd.Visible = True
            RbEname.Visible = True
            RbDept.Visible = True
            RbAll.Visible = True
            cmbxsift.Visible = False
            LblSft.Visible = True
            Cmbxsift1.Focus()
            CmbxEmpName.Visible = False
            CmbxDept.Visible = False
            PnlFnd.Height = 161
            PnlFnd.Location = New System.Drawing.Point(412, 156)
            LblLine.Visible = False
            BtnOk.Location = New System.Drawing.Point(53, 128)
            BtnCncl.Location = New System.Drawing.Point(123, 128)
            RbDept.Location = New System.Drawing.Point(115, 71)
        ElseIf counter_fnd = 0 Then
            Datagrd.Rows.Clear()
            MsgBox("First mark the Attendance of this date by selecting the shift", MsgBoxStyle.Information, "Attendance")
        End If
    End Sub
    Private Sub Fetch_Shft_Recrd_Fnd()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select Empstdtime,Empendtime,Empbrkfrom,Empbrkto from FinactEmpTimeMstr where EmpSift='" & (Cmbxsift1.Text) & "' ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            If Trim(Cmbxsift1.Text) <> "" Then
                Attd_Sift_Rdr.Read()
                If Attd_Sift_Rdr.HasRows = True Then
                    StrtTime = Attd_Sift_Rdr(0)
                    LblStrtTime.Text = Format(StrtTime, "hh:mm:ss")
                    EndTime = Attd_Sift_Rdr(1)
                    LblEndTime.Text = Format(EndTime, "hh:mm:ss")
                    BrkFrm = Attd_Sift_Rdr(2)
                    LblBrkFrm.Text = Format(BrkFrm, "hh:mm:ss")
                    BrkTo = Attd_Sift_Rdr(3)
                    LblBrkTo.Text = Format(BrkTo, "hh:mm:ss")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub fetch_ComboShift(ByVal cmbx As ComboBox)
        cmbx.Items.Clear()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select EmpSift from FinactEmpTimeMstr where Empdelstatus=0", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            While Attd_Sift_Rdr.Read
                If Attd_Sift_Rdr.HasRows = True Then
                    cmbx.Items.Add(Attd_Sift_Rdr(0))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub


    Private Sub cmbxsift_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxsift.GotFocus

        fetch_ComboShift(cmbxsift)
        If cmbxsift.Items.Count > 0 And cmbxsift.Text = "" Then
            cmbxsift.SelectedIndex = 0
            cmbxsift.DroppedDown = True
        End If
        ' cmbxsift.DroppedDown = True
    End Sub

    Private Sub Cmbxsift1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxsift1.GotFocus
        Cmbxsift1.Items.Clear()
        fetch_ComboShift(Cmbxsift1)
        If Cmbxsift1.Items.Count > 0 And Cmbxsift1.Text = "" Then
            Cmbxsift1.SelectedIndex = 0
            Cmbxsift1.DroppedDown = True
        End If
    End Sub

    Private Sub CmbxEmpName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEmpName.GotFocus
        CmbxEmpName.DroppedDown = True

    End Sub

    Private Sub CmbxDept_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDept.GotFocus
        CmbxDept.DroppedDown = True

    End Sub
    Private Sub CountRecrds_Fnd()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select count(empid) from FinactEmpmstr where empdelstatus=1 and empcateg='Working' and empothrsift='" & (Cmbxsift1.Text) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "' ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.IsDBNull(0) = False Then
                TotRecrds = Attd_Sift_Rdr(0)
            ElseIf Attd_Sift_Rdr.IsDBNull(0) = True Then
                MsgBox("No Record Found", MsgBoxStyle.Information, "Find")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub
   

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If RbEname.Checked = True Or RbDept.Checked = True Or RbAll.Checked = True Then
            LblPresnt.Text = 0
            LblAbsnt.Text = 0
            LblShrtLeve.Text = 0
            LblReprtlat.Text = 0
            LblShrtLeve.Text = 0
            LblHfLeve.Text = 0
            LblFDLeve.Text = 0

            If CmbxEmpName.Visible = True Or CmbxDept.Visible = True Then
                btnPrsentAll.Enabled = False
                BtnabsntAll.Enabled = False
                BtnPresnt.Enabled = False
                BtnAbsnt.Enabled = False
                BtnLeave.Enabled = False
                BtnLate.Enabled = False
                Btnsve.Enabled = False
            Else
                btnPrsentAll.Enabled = True
                BtnabsntAll.Enabled = True
                BtnPresnt.Enabled = True
                BtnAbsnt.Enabled = True
                BtnLeave.Enabled = True
                BtnLate.Enabled = True
                Btnsve.Enabled = True
            End If
            If CmbxEmpName.Visible = True Then
                PnlTotEmp.Visible = False
                Label22.Visible = False
                PnlFnd.Visible = False

                CmbxEmpName.Visible = False
                Datagrd.Rows.Clear()

                Fetch_Shft_Recrd_Fnd()
                Fetch_EmpName_recrds()

                If Recrds = 0 Then
                    Try
                        Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift,finactdept.deptid from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid where empname='" & (CmbxEmpName.Text) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "'", FinActConn)
                        Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
                        If Trim(CmbxEmpName.Text) <> "" Then
                            Attd_Sift_Rdr.Read()
                            If Attd_Sift_Rdr.HasRows = True Then
                                Datagrd.Rows.Add()
                                Empid = Attd_Sift_Rdr(0)
                                Datagrd.Rows(0).Cells(1).Value = Empid
                                Datagrd.Rows(0).Cells(2).Value = Attd_Sift_Rdr(1)
                                Datagrd.Rows(0).Cells(3).Value = "Nothing"
                                Datagrd.Rows(0).Cells(4).Value = "Nothing"
                                Datagrd.Rows(0).Cells(5).Value = "00:00:00"
                                Datagrd.Rows(0).Cells(9).Value = "Nothing"

                            End If
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
                    Finally
                        Attd_Sift_Rdr.Close()
                        Attd_Sift_Cmd = Nothing
                    End Try
                    LblPresnt.Text = 0
                    LblAbsnt.Text = 0
                    LblShrtLeve.Text = 0
                    LblReprtlat.Text = 0
                    LblShrtLeve.Text = 0
                    LblHfLeve.Text = 0
                    LblFDLeve.Text = 0
                ElseIf Recrds <> 0 Then
                    Dim Status As String
                    Dim RepStatus As String
                    Dim InTme As Date
                    Datagrd.Rows.Clear()
                    ' cmbxsift.Visible = True And
                    If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then

                        Try
                            Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift,Finact_Attd.AttdStatus,Finact_Attd.AttdRepStatus,Finact_Attd.AttdInTime,finactdept.deptid ,Finact_Attd.AttdLeveRsn from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid inner join Finact_Attd on Finactempmstr.empid=Finact_Attd.AttdEmpid where empdelstatus=1 and empcateg='Working' and empothrsift='" & (Cmbxsift1.Text) & "'and Attddt='" & (curntdt) & "'and empname='" & (CmbxEmpName.Text) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "' ", FinActConn)
                            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
                            Attd_Sift_Rdr.Read()
                            If Attd_Sift_Rdr.HasRows = True Then
                                Datagrd.Rows.Add()
                                Empid = Attd_Sift_Rdr(0)
                                Datagrd.Rows(0).Cells(1).Value = Empid
                                Datagrd.Rows(0).Cells(2).Value = Attd_Sift_Rdr(1)

                                Status = Attd_Sift_Rdr(5)
                                Datagrd.Rows(0).Cells(3).Value = Status
                                If Status = "Present" Then
                                    LblPresnt.Text = LblPresnt.Text + 1
                                ElseIf Status = "Absent" Then
                                    LblAbsnt.Text = LblAbsnt.Text + 1
                                End If
                                RepStatus = Attd_Sift_Rdr(6)
                                Datagrd.Rows(0).Cells(4).Value = RepStatus
                                If RepStatus = "Short Leave" Then
                                    LblShrtLeve.Text = LblShrtLeve.Text + 1
                                ElseIf RepStatus = "1st Half Leave" Or RepStatus = "2nd Half Leave" Then
                                    LblHfLeve.Text = LblHfLeve.Text + 1
                                ElseIf RepStatus = "Full Day Leave" Then
                                    LblFDLeve.Text = LblFDLeve.Text + 1
                                ElseIf RepStatus = "Late" Then
                                    LblReprtlat.Text = LblReprtlat.Text + 1
                                End If
                                InTme = Attd_Sift_Rdr(7)
                                Datagrd.Rows(0).Cells(5).Value = InTme
                                LstEmpName.SubItems.Add(Attd_Sift_Rdr(8))
                                Datagrd.Rows(0).Cells(5).Value = Attd_Sift_Rdr(9)
                            Else
                                MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")

                            End If

                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
                        Finally
                            Attd_Sift_Rdr.Close()
                            Attd_Sift_Cmd = Nothing
                        End Try
                    End If
                    'Else
                    ' RBEid.Checked = False

                    'End If
                End If

                'RbEname.Checked = False
                'RBOrdEname.Checked = False
            ElseIf CmbxDept.Visible = True Then
                PnlTotEmp.Visible = False
                Label22.Visible = False
                PnlFnd.Visible = False

                CmbxDept.Visible = False
                Datagrd.Rows.Clear()
                Fetch_Shft_Recrd_Fnd()
                Fetch_Deptid()
                Fetch_DeptName_recrds()

                If Recrds = 0 Then
                    'cmbxsift.Visible = True And
                    If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then
                        i = 0
                        Try
                            Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift,finactdept.deptid  from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid where empdeptid='" & (cmbxDeptid) & "'and empothrsift='" & (Cmbxsift1.Text) & "' and empcateg='Working' and empjnDt<='" & (DtpkrDt.Value.Date) & "'", FinActConn)
                            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
                            If Trim(cmbxDeptid) <> "" Then
                                Attd_Sift_Rdr.Read()
                                If Attd_Sift_Rdr.HasRows = True Then
                                    While Attd_Sift_Rdr.Read()
                                        Datagrd.Rows.Add()
                                        Empid = Attd_Sift_Rdr(0)
                                        Datagrd.Rows(i).Cells(1).Value = Empid
                                        Datagrd.Rows(i).Cells(2).Value = Attd_Sift_Rdr(1)
                                        Datagrd.Rows(i).Cells(3).Value = "Nothing"
                                        Datagrd.Rows(i).Cells(4).Value = "Nothing"
                                        Datagrd.Rows(i).Cells(5).Value = "00:00:00"
                                        Datagrd.Rows(i).Cells(9).Value = "Nothing"

                                        i = i + 1

                                    End While
                                ElseIf Attd_Sift_Rdr.HasRows = False Then
                                    MsgBox("No Record Found", MsgBoxStyle.Information, "Find")
                                    RbDept.Checked = False
                                    RBOrdDept.Checked = False
                                    Exit Sub
                                End If
                            End If

                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
                        Finally
                            If Attd_Sift_Rdr.HasRows = True Then
                            ElseIf Attd_Sift_Rdr.HasRows = False Then
                                MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")

                            End If
                            Attd_Sift_Rdr.Close()
                            Attd_Sift_Cmd = Nothing
                        End Try
                    End If
                ElseIf Recrds <> 0 Then
                    Dim Status As String
                    Dim RepStatus As String
                    Dim InTme As Date
                    Datagrd.Rows.Clear()
                    curntdt = DtpkrDt.Value.Date
                    ' cmbxsift.Visible = True And
                    If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then
                        i = 0
                        Try
                            Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift,Finact_Attd.AttdStatus,Finact_Attd.AttdRepStatus,Finact_Attd.AttdInTime,finactDept.deptid ,Finact_Attd.AttdLeveRsn from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid inner join Finact_Attd on Finactempmstr.empid=Finact_Attd.AttdEmpid where empdelstatus=1 and empcateg='Working' and empothrsift='" & (Cmbxsift1.Text) & "'and Attddt='" & (curntdt) & "'and empdeptid='" & (cmbxDeptid) & "' and empjnDt<='" & (DtpkrDt.Value.Date) & "'", FinActConn)
                            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader

                            If Trim(cmbxDeptid) <> "" Then
                                While Attd_Sift_Rdr.Read()
                                    Datagrd.Rows.Add()

                                    Empid = Attd_Sift_Rdr(0)
                                    Datagrd.Rows(i).Cells(1).Value = Empid
                                    Datagrd.Rows(i).Cells(2).Value = Attd_Sift_Rdr(1)

                                    Status = Attd_Sift_Rdr(5)
                                    Datagrd.Rows(i).Cells(3).Value = Status
                                    If Status = "Present" Then
                                        LblPresnt.Text = LblPresnt.Text + 1
                                    ElseIf Status = "Absent" Then
                                        LblAbsnt.Text = LblAbsnt.Text + 1
                                    End If
                                    RepStatus = Attd_Sift_Rdr(6)
                                    Datagrd.Rows(i).Cells(4).Value = RepStatus
                                    If RepStatus = "Short Leave" Then
                                        LblShrtLeve.Text = LblShrtLeve.Text + 1
                                    ElseIf RepStatus = "1st Half Leave" Or RepStatus = "2nd Half Leave" Then
                                        LblHfLeve.Text = LblHfLeve.Text + 1
                                    ElseIf RepStatus = "Full Day Leave" Then
                                        LblFDLeve.Text = LblFDLeve.Text + 1
                                    ElseIf RepStatus = "Late" Then
                                        LblReprtlat.Text = LblReprtlat.Text + 1
                                    End If
                                    InTme = Attd_Sift_Rdr(7)
                                    Datagrd.Rows(i).Cells(5).Value = InTme
                                    Datagrd.Rows(i).Cells(9).Value = Attd_Sift_Rdr(9)
                                    i = i + 1
                                End While
                            Else
                                MsgBox("No Record Found", MsgBoxStyle.Information, "Find")
                                RbDept.Checked = False
                                RBOrdDept.Checked = False
                                Exit Sub
                            End If


                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
                        Finally
                            If Attd_Sift_Rdr.HasRows = True Then
                            ElseIf Attd_Sift_Rdr.HasRows = False Then
                                MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")

                            End If
                            Attd_Sift_Rdr.Close()
                            Attd_Sift_Cmd = Nothing
                        End Try
                    End If
                End If
                ' RbDept.Checked = False
                'RBOrdDept.Checked = False
            ElseIf RBEid.Checked = True Then
                PnlTotEmp.Visible = True
                Label22.Visible = True
                PnlFnd.Visible = False

                RBEid.Checked = False
                Datagrd.Rows.Clear()
                Fetch_AllOrdr_recrds()
                Fetch_Shft_Recrd_Fnd()
                CountRecrds_Fnd()
                LblTotEmpl.Text = TotRecrds
                If Recrds = 0 Then
                    '  cmbxsift.Visible = True And 
                    If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then

                        i = 0
                        Try
                            Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift,finactdept.deptid  from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid where empothrsift='" & (Cmbxsift1.Text) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "' order by empid ", FinActConn)
                            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
                            While Attd_Sift_Rdr.Read()
                                If Attd_Sift_Rdr.HasRows = True Then
                                    Datagrd.Rows.Add()
                                    Empid = Attd_Sift_Rdr(0)
                                    Datagrd.Rows(i).Cells(1).Value = Empid
                                    Datagrd.Rows(i).Cells(2).Value = Attd_Sift_Rdr(1)
                                    Datagrd.Rows(i).Cells(3).Value = "Nothing"
                                    Datagrd.Rows(i).Cells(4).Value = "Nothing"
                                    Datagrd.Rows(i).Cells(5).Value = "00:00:00"
                                    Datagrd.Rows(i).Cells(9).Value = "Nothing"
                                    i = i + 1

                                ElseIf Attd_Sift_Rdr.HasRows = False Then
                                    MsgBox("No Record Found", MsgBoxStyle.Information, "Find")
                                    RbDept.Checked = False
                                    Exit Sub
                                End If
                            End While

                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
                        Finally
                            If Attd_Sift_Rdr.HasRows = True Then
                            ElseIf Attd_Sift_Rdr.HasRows = False Then
                                MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")

                            End If
                            Attd_Sift_Rdr.Close()
                            Attd_Sift_Cmd = Nothing
                        End Try
                    End If
                ElseIf Recrds <> 0 Then
                    Dim Status As String
                    Dim RepStatus As String
                    Dim InTme As Date
                    Datagrd.Rows.Clear()
                    curntdt = DtpkrDt.Value.Date
                    ' cmbxsift.Visible = True And
                    If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then
                        i = 0
                        Try
                            Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift,Finact_Attd.AttdStatus,Finact_Attd.AttdRepStatus,Finact_Attd.AttdInTime,finactdept.deptid ,Finact_Attd.AttdLeveRsn from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid inner join Finact_Attd on Finactempmstr.empid=Finact_Attd.AttdEmpid where empdelstatus=1 and empothrsift='" & (Cmbxsift1.Text) & "'and Attddt='" & (curntdt) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "'order by empid", FinActConn)
                            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
                            While Attd_Sift_Rdr.Read()
                                If Attd_Sift_Rdr.HasRows = True Then
                                    Datagrd.Rows.Add()
                                    Empid = Attd_Sift_Rdr(0)
                                    Datagrd.Rows(i).Cells(1).Value = Empid
                                    Datagrd.Rows(i).Cells(2).Value = Attd_Sift_Rdr(1)
                                    Status = Attd_Sift_Rdr(5)
                                    Datagrd.Rows(i).Cells(3).Value = Status
                                    If Status = "Present" Then
                                        LblPresnt.Text = LblPresnt.Text + 1
                                    ElseIf Status = "Absent" Then
                                        LblAbsnt.Text = LblAbsnt.Text + 1
                                    End If
                                    RepStatus = Attd_Sift_Rdr(6)
                                    Datagrd.Rows(i).Cells(4).Value = RepStatus
                                    If RepStatus = "Short Leave" Then
                                        LblShrtLeve.Text = LblShrtLeve.Text + 1
                                    ElseIf RepStatus = "1st Half Leave" Or RepStatus = "2nd Half Leave" Then
                                        LblHfLeve.Text = LblHfLeve.Text + 1
                                    ElseIf RepStatus = "Full Day Leave" Then
                                        LblFDLeve.Text = LblFDLeve.Text + 1
                                    ElseIf RepStatus = "Late" Then
                                        LblReprtlat.Text = LblReprtlat.Text + 1
                                    End If
                                    InTme = Attd_Sift_Rdr(7)
                                    Datagrd.Rows(i).Cells(5).Value = Format(InTme, "hh:mm:ss")

                                    Datagrd.Rows(i).Cells(3).Value = Attd_Sift_Rdr(9)
                                    i = i + 1
                                ElseIf Attd_Sift_Rdr.HasRows = False Then
                                    MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")
                                    Exit Sub
                                End If
                            End While
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
                        Finally
                            If Attd_Sift_Rdr.HasRows = True Then
                            ElseIf Attd_Sift_Rdr.HasRows = False Then
                                MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")

                            End If
                            Attd_Sift_Rdr.Close()
                            Attd_Sift_Cmd = Nothing
                        End Try
                    End If
                End If
            ElseIf RBOrdEname.Checked = True Then
                PnlTotEmp.Visible = True
                Label22.Visible = True
                PnlFnd.Visible = False

                RBOrdEname.Checked = False
                Datagrd.Rows.Clear()
                Fetch_AllOrdr_recrds()
                Fetch_Shft_Recrd_Fnd()
                CountRecrds_Fnd()
                LblTotEmpl.Text = TotRecrds
                If Recrds = 0 Then
                    'cmbxsift.Visible = True And 
                    If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then
                        Try
                            Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift ,finactdept.deptid from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid where empothrsift='" & (Cmbxsift1.Text) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "' order by empname ", FinActConn)
                            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader

                            While Attd_Sift_Rdr.Read()
                                If Attd_Sift_Rdr.HasRows = True Then
                                    Datagrd.Rows.Add()
                                    Empid = Attd_Sift_Rdr(0)

                                    Datagrd.Rows(i).Cells(1).Value = Empid
                                    Datagrd.Rows(i).Cells(2).Value = Attd_Sift_Rdr(1)
                                    Datagrd.Rows(i).Cells(3).Value = "Nothing"
                                    Datagrd.Rows(i).Cells(4).Value = "Nothing"
                                    Datagrd.Rows(i).Cells(5).Value = "00:00:00"
                                    Datagrd.Rows(i).Cells(9).Value = "Nothing"
                                    i = i + 1

                                    'ElseIf Attd_Sift_Rdr.HasRows = False Then
                                    '    MsgBox("No Record Found", MsgBoxStyle.Information, "Find")
                                    '    RbDept.Checked = False
                                    '    Exit Sub
                                End If
                            End While
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
                        Finally

                            If Attd_Sift_Rdr.HasRows = False Then
                                MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")
                                RbDept.Checked = False
                            End If
                            Attd_Sift_Rdr.Close()
                            Attd_Sift_Cmd = Nothing
                        End Try
                    End If
                ElseIf Recrds <> 0 Then

                    Dim Status As String
                    Dim Repstatus As String
                    Dim InTme As Date
                    Datagrd.Rows.Clear()
                    ' cmbxsift.Visible = True And
                    If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then
                        Try
                            Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift,Finact_Attd.AttdStatus,Finact_Attd.AttdRepStatus,Finact_Attd.AttdInTime,finactDept.deptid ,Finact_Attd.AttdLeveRsn from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid inner join Finact_Attd on Finactempmstr.empid=Finact_Attd.AttdEmpid where empdelstatus=1 and empcateg='Working' and empothrsift='" & (Cmbxsift1.Text) & "'and Attddt='" & (curntdt) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "'order by empname", FinActConn)
                            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader

                            While Attd_Sift_Rdr.Read()
                                If Attd_Sift_Rdr.HasRows = True Then
                                    Datagrd.Rows.Add()
                                    Empid = Attd_Sift_Rdr(0)
                                    Datagrd.Rows(i).Cells(1).Value = Empid
                                    Datagrd.Rows(i).Cells(2).Value = Attd_Sift_Rdr(1)
                                    Status = Attd_Sift_Rdr(5)
                                    Datagrd.Rows(i).Cells(3).Value = Status
                                    If Status = "Present" Then
                                        LblPresnt.Text = LblPresnt.Text + 1
                                    ElseIf Status = "Absent" Then
                                        LblAbsnt.Text = LblAbsnt.Text + 1
                                    End If
                                    Repstatus = Attd_Sift_Rdr(6)
                                    Datagrd.Rows(i).Cells(4).Value = Repstatus
                                    If Repstatus = "Short Leave" Then
                                        LblShrtLeve.Text = LblShrtLeve.Text + 1
                                    ElseIf Repstatus = "1st Half Leave" Or Repstatus = "2nd Half Leave" Then
                                        LblHfLeve.Text = LblHfLeve.Text + 1
                                    ElseIf Repstatus = "Full Day Leave" Then
                                        LblFDLeve.Text = LblFDLeve.Text + 1
                                    ElseIf Repstatus = "Late" Then
                                        LblReprtlat.Text = LblReprtlat.Text + 1
                                    End If
                                    InTme = Attd_Sift_Rdr(7)
                                    Datagrd.Rows(i).Cells(5).Value = Format(InTme, "hh:mm:ss")
                                    Datagrd.Rows(i).Cells(9).Value = Attd_Sift_Rdr(9)
                                    i = i + 1
                                ElseIf Attd_Sift_Rdr.HasRows = False Then
                                    MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")
                                    Exit Sub
                                End If
                            End While
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
                        Finally
                            If Attd_Sift_Rdr.HasRows = True Then
                            ElseIf Attd_Sift_Rdr.HasRows = False Then
                                MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")

                            End If
                            Attd_Sift_Rdr.Close()
                            Attd_Sift_Cmd = Nothing
                        End Try
                    End If
                End If
            ElseIf RBOrdDept.Checked = True Then
                PnlTotEmp.Visible = True
                Label22.Visible = True
                PnlFnd.Visible = False
                RBOrdDept.Checked = False
                Datagrd.Rows.Clear()
                Fetch_AllOrdr_recrds()
                Fetch_Shft_Recrd_Fnd()
                CountRecrds_Fnd()
                LblTotEmpl.Text = TotRecrds
                If Recrds = 0 Then
                    '  cmbxsift.Visible = True And
                    If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then
                        Try
                            Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift ,finactdept.deptid from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid where empothrsift='" & (Cmbxsift1.Text) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "' order by deptname ", FinActConn)
                            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
                            While Attd_Sift_Rdr.Read()
                                If Attd_Sift_Rdr.HasRows = True Then
                                    Datagrd.Rows.Add()

                                    Empid = Attd_Sift_Rdr(0)
                                    Datagrd.Rows(i).Cells(1).Value = Empid
                                    Datagrd.Rows(i).Cells(2).Value = Attd_Sift_Rdr(1)
                                    Datagrd.Rows(i).Cells(3).Value = "Nothing"
                                    Datagrd.Rows(i).Cells(4).Value = "Nothing"
                                    Datagrd.Rows(i).Cells(5).Value = "00:00:00"
                                    Datagrd.Rows(i).Cells(9).Value = "Nothing"
                                    i = i + 1

                                ElseIf Attd_Sift_Rdr.HasRows = False Then
                                    MsgBox("No Record Found", MsgBoxStyle.Information, "Find")
                                    RbDept.Checked = False
                                    Exit Sub
                                End If
                            End While
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
                        Finally
                            If Attd_Sift_Rdr.HasRows = True Then
                            ElseIf Attd_Sift_Rdr.HasRows = False Then
                                MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")

                            End If
                            Attd_Sift_Rdr.Close()
                            Attd_Sift_Cmd = Nothing
                        End Try
                    End If
                ElseIf Recrds <> 0 Then
                    'Dim Shft As String
                    Dim Status As String
                    Dim Repstatus As String
                    Dim InTme As Date
                    Datagrd.Rows.Clear()
                    '  cmbxsift.Visible = True And
                    If cmbxsift.SelectedIndex >= 0 Or LblSft.Visible = True Then
                        Try
                            Attd_Sift_Cmd = New SqlCommand("Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname,finactDesi.desiname,FinactEmpmstr.empothrsift,Finact_Attd.AttdStatus,Finact_Attd.AttdRepStatus,Finact_Attd.AttdInTime,finactDept.deptid ,Finact_Attd.AttdLeveRsn from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid inner join Finact_Attd on Finactempmstr.empid=Finact_Attd.AttdEmpid where empdelstatus=1 and empcateg='Working' and empothrsift='" & (Cmbxsift1.Text) & "'and Attddt='" & (curntdt) & "'and empjnDt<='" & (DtpkrDt.Value.Date) & "'order by deptname", FinActConn)
                            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader

                            While Attd_Sift_Rdr.Read()
                                If Attd_Sift_Rdr.HasRows = True Then
                                    Datagrd.Rows.Add()
                                    Empid = Attd_Sift_Rdr(0)
                                    Datagrd.Rows(i).Cells(1).Value = Empid
                                    Datagrd.Rows(i).Cells(2).Value = Attd_Sift_Rdr(1)

                                    Status = Attd_Sift_Rdr(5)
                                    Datagrd.Rows(i).Cells(3).Value = Status
                                    If Status = "Present" Then
                                        LblPresnt.Text = LblPresnt.Text + 1
                                    ElseIf Status = "Absent" Then
                                        LblAbsnt.Text = LblAbsnt.Text + 1
                                    End If
                                    Repstatus = Attd_Sift_Rdr(6)
                                    Datagrd.Rows(i).Cells(4).Value = Repstatus
                                    If Repstatus = "Short Leave" Then
                                        LblShrtLeve.Text = LblShrtLeve.Text + 1
                                    ElseIf Repstatus = "1st Half Leave" Or Repstatus = "2nd Half Leave" Then
                                        LblHfLeve.Text = LblHfLeve.Text + 1
                                    ElseIf Repstatus = "Full Day Leave" Then
                                        LblFDLeve.Text = LblFDLeve.Text + 1
                                    ElseIf Repstatus = "Late" Then
                                        LblReprtlat.Text = LblReprtlat.Text + 1
                                    End If

                                    InTme = Attd_Sift_Rdr(7)
                                    Datagrd.Rows(i).Cells(5).Value = Format(InTme, "hh:mm:ss")

                                    Datagrd.Rows(i).Cells(9).Value = Attd_Sift_Rdr(9)
                                    i = i + 1
                                ElseIf Attd_Sift_Rdr.HasRows = False Then
                                    MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")

                                    Exit Sub
                                End If
                            End While
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
                        Finally
                            If Attd_Sift_Rdr.HasRows = True Then
                            ElseIf Attd_Sift_Rdr.HasRows = False Then
                                MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")

                            End If
                            Attd_Sift_Rdr.Close()
                            Attd_Sift_Cmd = Nothing
                        End Try
                    End If
                End If
            End If
            cmbxsift.Visible = False
            LblSft.Visible = True
            LblSft.Text = Cmbxsift1.Text
            RBEid.Checked = False
            RbAll.Checked = False

            RbEname.Checked = False
            RbDept.Checked = False
            RbAll.Checked = False
            If Cmbxsift1.SelectedIndex >= 1 Then
                Cmbxsift1.SelectedValue = 0
                Cmbxsift1.SelectedIndex = -1
            End If
            Cmbxsift1.Text = ""
            If CmbxEmpName.SelectedIndex >= 1 Then
                CmbxEmpName.SelectedValue = 0
                CmbxEmpName.SelectedIndex = -1
            End If
            CmbxEmpName.Text = ""
        End If


    End Sub


    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        CmbxEmpName.Visible = False
        CmbxEmpName.DroppedDown = False
        PnlFnd.Visible = False
        cmbxsift.Visible = True
        LblSft.Visible = False
        'Btnrest_Click(sender, e)
    End Sub

    Private Sub BtnRptOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptOK.Click
        Dim counter As Integer = 0
        LstCount = Datagrd.SelectedRows.Count
        If RbFDLeve.Checked = True Then
            'attd_flag = True
            'Leve_flag = 4
            'FrmFullDayLev.DtpkrDt.Value = Me.DtpkrDt.Value
            'FrmFullDayLev.ShowDialog()

            While counter < LstCount
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                    LblAbsnt.Text = LblAbsnt.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                    LblPresnt.Text = LblPresnt.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                    LblShrtLeve.Text = LblShrtLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                    LblFDLeve.Text = LblFDLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                    LblHfLeve.Text = LblHfLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                    LblHfLeve.Text = LblHfLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                    LblReprtlat.Text = LblReprtlat.Text - 1
                End If
                Datagrd.SelectedRows(counter).Cells(3).Value = "Leave"
                Datagrd.SelectedRows(counter).Cells(4).Value = "Full Day Leave"
                Datagrd.SelectedRows(counter).Cells(6).Value = "00:00:00"
                Datagrd.SelectedRows(counter).Cells(5).Value = Type_Lev
                Datagrd.SelectedRows(counter).Cells(7).Value = "00:00:00"
                Datagrd.SelectedRows(counter).Cells(8).Value = "00:00:00"
                Datagrd.SelectedRows(counter).Cells(9).Value = "00:00:00"

                counter = counter + 1
            End While
            LblFDLeve.Text = LblFDLeve.Text + LstCount
            PnlReprtLate.Visible = False
        ElseIf Rb1HFLeve.Checked = True Then

            While counter < LstCount
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                    LblAbsnt.Text = LblAbsnt.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                    LblPresnt.Text = LblPresnt.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                    LblShrtLeve.Text = LblShrtLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                    LblFDLeve.Text = LblFDLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                    LblHfLeve.Text = LblHfLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                    LblHfLeve.Text = LblHfLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                    LblReprtlat.Text = LblReprtlat.Text - 1
                End If
                'Datagrd.SelectedRows(counter).Cells(4).Value = "Leave"
                Datagrd.SelectedRows(counter).Cells(4).Value = "1st Half Day Leave"
                Datagrd.SelectedRows(counter).Cells(6).Value = LblBrkTo.Text
                Datagrd.SelectedRows(counter).Cells(5).Value = Type_Lev
                Datagrd.SelectedRows(counter).Cells(7).Value = "00:00:00"
                Datagrd.SelectedRows(counter).Cells(8).Value = "00:00:00"
                Datagrd.SelectedRows(counter).Cells(9).Value = LblEndTime.Text
                counter = counter + 1
            End While
            LblHfLeve.Text = LblHfLeve.Text + LstCount
            LblPresnt.Text = LblPresnt.Text + 1
            PnlReprtLate.Visible = False
        ElseIf Rb2HFLeve.Checked = True Then

            While counter < LstCount
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                    LblAbsnt.Text = LblAbsnt.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                    LblPresnt.Text = LblPresnt.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                    LblShrtLeve.Text = LblShrtLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                    LblFDLeve.Text = LblFDLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                    LblHfLeve.Text = LblHfLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                    LblHfLeve.Text = LblHfLeve.Text - 1
                End If
                If Datagrd.SelectedRows(counter).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                    LblReprtlat.Text = LblReprtlat.Text - 1
                End If
                'Datagrd.SelectedRows(counter).Cells(4).Value = "Leave"
                Datagrd.SelectedRows(counter).Cells(4).Value = "2nd Half Day Leave"
                Datagrd.SelectedRows(counter).Cells(6).Value = LblStrtTime.Text
                Datagrd.SelectedRows(counter).Cells(5).Value = Type_Lev
                Datagrd.SelectedRows(counter).Cells(7).Value = "00:00:00"
                Datagrd.SelectedRows(counter).Cells(8).Value = "00:00:00"
                Datagrd.SelectedRows(counter).Cells(9).Value = LblBrkFrm.Text
                counter = counter + 1
            End While
            LblHfLeve.Text = LblHfLeve.Text + LstCount
            LblPresnt.Text = LblPresnt.Text + 1
            PnlReprtLate.Visible = False



        ElseIf RbShrtLeve.Checked = True Then
            ''If CmbxResn.Text = "" Then
            'PnlReprtLate.Visible = True
            'MsgBox("Field left empty", MsgBoxStyle.Information, "Blank Field")
            'CmbxResn.Focus()
            'If LblReptm.Text = "" Then
            '    PnlReprtLate.Visible = True
            '    MsgBox("Please select the hours and minutes", MsgBoxStyle.Information, "Validity")
            'ElseIf LblReptm.Text = Trim(CmbxHrs.Text) & " : :00" Then
            '    PnlReprtLate.Visible = True
            '    MsgBox("Please select the minutes", MsgBoxStyle.Information, "Validity")
            'ElseIf LblReptm.Text = " : " & Trim(CmbxMint.Text) & ":00" Then
            '    PnlReprtLate.Visible = True
            '    MsgBox("Please select the hours", MsgBoxStyle.Information, "Validity")

            ''Else
            ''    Tconvr()
            ''    If frmmins = endmins Or frmmins = endmins - 1 Then
            ''        MsgBox("Short Leave not allowed", MsgBoxStyle.Information, "Leave")
            ''        Exit Sub

            ''    ElseIf diff > 0 Then
            ''        PnlReprtLate.Visible = True
            ''        MsgBox("Try for Half Day Leave or Full Day Leave", MsgBoxStyle.Information, "Validity")
            ''        Exit Sub

            ''    Else
            If SrtLevMark_flag = True Then
                While counter < LstCount
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                        LblAbsnt.Text = LblAbsnt.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                        LblPresnt.Text = LblPresnt.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                        LblShrtLeve.Text = LblShrtLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                        LblFDLeve.Text = LblFDLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                        LblReprtlat.Text = LblReprtlat.Text - 1
                    End If
                    Datagrd.SelectedRows(counter).Cells(3).Value = "Present"
                    Datagrd.SelectedRows(counter).Cells(4).Value = "Short Leave"
                    ' Lstvewattend.SelectedItems(counter).SubItems(7).Text = LblRTime.Text
                    Datagrd.SelectedRows(counter).Cells(6).Value = SrtLev_RepTm
                    'Lstvewattend.SelectedItems(counter).SubItems(9).Text = CmbxResn.Text
                    Datagrd.SelectedRows(counter).Cells(5).Value = SrtLev_Type
                    counter = counter + 1
                End While
                LblPresnt.Text = LblPresnt.Text + 1
                LblShrtLeve.Text = LblShrtLeve.Text + LstCount
            End If
            'End If
            'End If

            PnlReprtLate.Visible = False
        ElseIf RbMatrntyLev.Checked = True Then

            If MatrntyLev_flag = True Then
                While counter < LstCount
                    If Datagrd.SelectedRows(counter).Cells(4).Value = "Absent" And LblAbsnt.Text <> 0 Then
                        LblAbsnt.Text = LblAbsnt.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(4).Value = "Present" And LblPresnt.Text <> 0 Then
                        LblPresnt.Text = LblPresnt.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(4).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                        LblShrtLeve.Text = LblShrtLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(4).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                        LblFDLeve.Text = LblFDLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(4).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(4).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                        LblHfLeve.Text = LblHfLeve.Text - 1
                    End If
                    If Datagrd.SelectedRows(counter).Cells(4).Value = "Late" And LblReprtlat.Text <> 0 Then
                        LblReprtlat.Text = LblReprtlat.Text - 1
                    End If
                    Datagrd.SelectedRows(counter).Cells(3).Value = "On Leave"
                    Datagrd.SelectedRows(counter).Cells(4).Value = "Maternity Leave"
                    ' Lstvewattend.SelectedItems(counter).SubItems(7).Text = LblRTime.Text
                    Datagrd.SelectedRows(counter).Cells(6).Value = "00:00:00"
                    'Lstvewattend.SelectedItems(counter).SubItems(9).Text = CmbxResn.Text
                    Datagrd.SelectedRows(counter).Cells(5).Value = "Maternity Leave"
                    counter = counter + 1
                End While
                LblPresnt.Text = LblPresnt.Text + 1
                LblShrtLeve.Text = LblShrtLeve.Text + LstCount

            End If
            PnlReprtLate.Visible = False
            '    Save_ShrtLev()
        End If
        'End If
        ' Save_ShrtLev()

        'End If

        'LblReptm.Text = ""
        'If Lsthr.SelectedIndex >= 1 Then
        '    Lsthr.SelectedIndex = 0
        'End If
        'If Lstmint.SelectedIndex >= 1 Then
        '    Lstmint.SelectedIndex = 0
        'End If
    End Sub

    Private Sub BtnRptCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptCncl.Click
        PnlReprtLate.Visible = False
        FrmMatrntyLev.Close()
        FrmShrtLeve.Close()

        ' Btnrest_Click(sender, e)
    End Sub

    Private Sub RbShrtLeve_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbShrtLeve.CheckedChanged
        If RbShrtLeve.Checked = True Then
            ''PnlReprtLate.Size = New System.Drawing.Point(356, 291)
            ''GroupBox1.Size = New System.Drawing.Point(348, 253)
            ''PnlReprtLate.Location = New System.Drawing.Point(342, 155)
            ''BtnRptOK.Location = New System.Drawing.Point(93, 262)
            ''BtnRptCncl.Location = New System.Drawing.Point(178, 262)
            ''PnlRT.Visible = True
            ''PnlRPTime.Visible = True
            ''LblResn.Visible = True
            ''CmbxResn.Visible = True
            ''Cmbxrsn2.Visible = False
            ''CmbxHrs.Items.Clear()
            ''EmpStatus = Lstvewattend.SelectedItems(0).SubItems(5).Text
            ' '' If EmpStatus = "Present" Then
            ''Fetch_Lsthr()
            ''Fetch_Lsthr_RpTime()
            ' ''End If
            attd_flag = True
            'LblResn.Visible = False
            'Cmbxrsn2.Visible = False

            SrtLev_dt = DtpkrDt.Value.Date
            SrtLev_Shift = cmbxsift.Text
            SrtLev_Empnm = Datagrd.SelectedRows(0).Cells(2).Value
            SrtLev_Empid = Datagrd.SelectedRows(0).Cells(1).Value
            FrmShrtLeve.Show()
            FrmShrtLeve.Location = New System.Drawing.Point(320, 220)
            PnlReprtLate.Size = New System.Drawing.Point(356, 180)
            BtnRptOK.Location = New System.Drawing.Point(114, 120)
            BtnRptOK.Size = New System.Drawing.Point(39, 24)
            BtnRptCncl.Location = New System.Drawing.Point(206, 120)
            BtnRptCncl.Size = New System.Drawing.Point(55, 23)
            'attd_flag = False
        End If

    End Sub

    Private Sub Rb1HFLeve_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rb1HFLeve.CheckedChanged
        If Rb1HFLeve.Checked = True Then

            attd_flag = True
            Leve_flag = 2
            FrmFullDayLev.DtpkrDt.Value = Me.DtpkrDt.Value
            FDayLev_dt = DtpkrDt.Value.Date
            FDayLev_Shift = cmbxsift.Text
            FDayLev_Empnm = Datagrd.SelectedRows(0).Cells(2).Value
            FdayLev_Empid = Datagrd.SelectedRows(0).Cells(1).Value

            FrmFullDayLev.ShowDialog()

            ' ''PnlReprtLate.Location = New System.Drawing.Point(342, 249)
            ' ''PnlReprtLate.Size = New System.Drawing.Point(356, 193)
            ' ''GroupBox1.Size = New System.Drawing.Point(348, 112)
            ' ''BtnRptOK.Location = New System.Drawing.Point(114, 155)
            ' ''BtnRptOK.Size = New System.Drawing.Point(39, 24)
            ' ''BtnRptCncl.Location = New System.Drawing.Point(200, 155)
            ' ''BtnRptCncl.Size = New System.Drawing.Point(55, 23)
            'PnlRPTime.Visible = False
            'PnlRT.Visible = False
            'LblResn.Visible = True
            'CmbxResn.Visible = False
            'Cmbxrsn2.Visible = True
            'Cmbxrsn2.Location = New System.Drawing.Point(88, 116)
        End If
    End Sub

    Private Sub Rb2HFLeve_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rb2HFLeve.CheckedChanged
        If Rb2HFLeve.Checked = True Then

            attd_flag = True
            Leve_flag = 3
            FrmFullDayLev.DtpkrDt.Value = Me.DtpkrDt.Value
            FDayLev_dt = DtpkrDt.Value.Date
            FDayLev_Shift = cmbxsift.Text
            FDayLev_Empnm = Datagrd.SelectedRows(0).Cells(2).Value
            FdayLev_Empid = Datagrd.SelectedRows(0).Cells(1).Value

            FrmFullDayLev.ShowDialog()

            ' ''PnlReprtLate.Location = New System.Drawing.Point(342, 249)
            ' ''PnlReprtLate.Size = New System.Drawing.Point(356, 193)
            ' ''GroupBox1.Size = New System.Drawing.Point(348, 112)
            ' ''BtnRptOK.Location = New System.Drawing.Point(114, 155)
            ' ''BtnRptOK.Size = New System.Drawing.Point(39, 24)
            ' ''BtnRptCncl.Location = New System.Drawing.Point(200, 155)
            ' ''BtnRptCncl.Size = New System.Drawing.Point(55, 23)
            'PnlRPTime.Visible = False
            'PnlRT.Visible = False
            'LblResn.Visible = True
            'CmbxResn.Visible = False
            'Cmbxrsn2.Visible = True
            'Cmbxrsn2.Location = New System.Drawing.Point(88, 116)
        End If
    End Sub

    Private Sub RbFDLeve_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbFDLeve.CheckedChanged
        If RbFDLeve.Checked = True Then
            attd_flag = True
            Leve_flag = 4
            FrmFullDayLev.DtpkrDt.Value = Me.DtpkrDt.Value

            FDayLev_dt = DtpkrDt.Value.Date
            FDayLev_Shift = cmbxsift.Text
            FDayLev_Empnm = Datagrd.SelectedRows(0).Cells(2).Value
            FdayLev_Empid = Datagrd.SelectedRows(0).Cells(1).Value
            FrmFullDayLev.ShowDialog()
            'Leve_flag = 4
            'FrmFullDayLev.ShowDialog()

            ' PnlReprtLate.Location = New System.Drawing.Point(342, 249)
            ' PnlReprtLate.Size = New System.Drawing.Point(356, 230)
            '  GroupBox1.Size = New System.Drawing.Point(348, 112)
            '  BtnRptOK.Location = New System.Drawing.Point(87, 201)
            ' BtnRptOK.Size = New System.Drawing.Point(39, 24)
            ' BtnRptCncl.Location = New System.Drawing.Point(165, 202)
            ' BtnRptCncl.Size = New System.Drawing.Point(55, 23)
            'PnlRPTime.Visible = False
            ' PnlRT.Visible = True
            'LblResn.Visible = True
            ' CmbxResn.Visible = False
            ' Cmbxrsn2.Visible = True
            ' Cmbxrsn2.Location = New System.Drawing.Point(88, 116)
        End If

    End Sub


    'Private Sub Save_ShrtLev()
    '    Try
    '        P_Roll_Attd_Cmd = New SqlCommand("Finact_Insert_SrtLev", FinActConn)
    '        P_Roll_Attd_Cmd.CommandType = CommandType.StoredProcedure
    '        P_Roll_Attd_Cmd.Parameters.AddWithValue("@SrtLevDate", DtpkrDt.Value.Date)
    '        If cmbxsift.Visible = True Then
    '            P_Roll_Attd_Cmd.Parameters.AddWithValue("@SrtLevShift", cmbxsift.Text)
    '        ElseIf LblSft.Visible = True Then
    '            P_Roll_Attd_Cmd.Parameters.AddWithValue("@SrtLevShift", cmbxsift.Text)
    '        End If
    '        'P_Roll_Attd_Cmd.Parameters.AddWithValue("@SrtLevEmpid", Lstvewattend.SelectedItems(0).SubItems(0).Text)
    '        P_Roll_Attd_Cmd.Parameters.AddWithValue("@SrtLevType", CmbxResn.Text)
    '        '  '  P_Roll_Attd_Cmd.Parameters.AddWithValue("@SrtLevStrtTm", LblReptm.Text)
    '        ' ' P_Roll_Attd_Cmd.Parameters.AddWithValue("@SrtLevEndTm", LblSrtlvTo.Text)
    '        P_Roll_Attd_Cmd.Parameters.AddWithValue("@SrtLevRepTm", LblRTime.Text)
    '        P_Roll_Attd_Cmd.Parameters.AddWithValue("@SrtLevadusrid", Current_UsrId)
    '        P_Roll_Attd_Cmd.Parameters.AddWithValue("@SrtLevaddt", Now)
    '        P_Roll_Attd_Cmd.Parameters.AddWithValue("@SrtLevdelstatus", 0)

    '        P_Roll_Attd_Cmd.ExecuteNonQuery()
    '        ''MsgBox("Record has been Saved Successfully.", MsgBoxStyle.Information, "Save")
    '        ''Clrvalue()
    '        ''DtpkrDt_SL.Focus()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
    '    Finally
    '        P_Roll_Attd_Cmd = Nothing
    '    End Try
    'End Sub


    Private Sub BtnLateOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLateOk.Click
        Dim counter As Integer = 0
        ''If LblTime.Text = "" Then
        ''    PnlLate.Visible = True
        ''    MsgBox("Please select the hours and minutes", MsgBoxStyle.Information, "Validity")
        ''ElseIf LblTime.Text = Trim(Lsthrs.Text) & " : :00" Then
        ''    PnlLate.Visible = True
        ''    MsgBox("Please select the minutes", MsgBoxStyle.Information, "Validity")
        ''ElseIf LblTime.Text = " : " & Trim(Lstmins.Text) & ":00" Then
        ''    PnlLate.Visible = True
        ''    MsgBox("Please select the hours", MsgBoxStyle.Information, "Validity")
        ''Else
        ''    Timeconvr2()
        ''    If res = 0 Or res1 = 0 Then
        ''        PnlLate.Visible = True
        ''        MsgBox("Invalid Value", MsgBoxStyle.Information, "Validity")
        ''        LblTime.Text = ""
        ''        Exit Sub
        ''    Else

        While counter < LstCount
            If Datagrd.SelectedRows(counter).Cells(3).Value = "Absent" And LblAbsnt.Text <> 0 Then
                LblAbsnt.Text = LblAbsnt.Text - 1
            End If
            If Datagrd.SelectedRows(counter).Cells(3).Value = "Present" And LblPresnt.Text <> 0 Then
                LblPresnt.Text = LblPresnt.Text - 1
            End If
            If Datagrd.SelectedRows(counter).Cells(3).Value = "Short Leave" And LblShrtLeve.Text <> 0 Then
                LblShrtLeve.Text = LblShrtLeve.Text - 1
            End If
            If Datagrd.SelectedRows(counter).Cells(3).Value = "Full Day Leave" And LblFDLeve.Text <> 0 Then
                LblFDLeve.Text = LblFDLeve.Text - 1
            End If
            If Datagrd.SelectedRows(counter).Cells(3).Value = "1st Half Leave" And LblHfLeve.Text <> 0 Then
                LblHfLeve.Text = LblHfLeve.Text - 1
            End If
            If Datagrd.SelectedRows(counter).Cells(3).Value = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
                LblHfLeve.Text = LblHfLeve.Text - 1
            End If
            If Datagrd.SelectedRows(counter).Cells(3).Value = "Late" And LblReprtlat.Text <> 0 Then
                LblReprtlat.Text = LblReprtlat.Text - 1
            End If
            If edit_flag = False Then
                Datagrd.SelectedRows(counter).Cells(3).Value = "Present"
            ElseIf edit_flag = True Then
                Datagrd.SelectedRows(counter).Cells(3).Value = "Paid Holiday"
            End If
            Datagrd.SelectedRows(counter).Cells(4).Value = "Late"
            Datagrd.SelectedRows(counter).Cells(6).Value = DtTime.Text
            Datagrd.SelectedRows(counter).Cells(5).Value = "Late"
            counter = counter + 1
        End While
        LblPresnt.Text = LblPresnt.Text + 1
        LblReprtlat.Text = LblReprtlat.Text + LstCount
        PnlLate.Visible = False

        ''    End If
        ''End If
        ''LblTime.Text = ""
        ''If Lsthrs.SelectedIndex >= 1 Then
        ''    Lsthrs.SelectedIndex = 0
        ''End If
        ''If Lstmins.SelectedIndex >= 1 Then
        ''    Lstmins.SelectedIndex = 0
        ''End If

    End Sub

    Private Sub BtnLateCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLateCncl.Click
        'Btnrest_Click(sender, e)
        PnlLate.Visible = False
    End Sub

    ''Private Sub Lsthrs_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    ''    LblTime.Text = Trim(Lsthrs.Text) & " : " & Trim(Lstmins.Text) & ":00"


    ''End Sub

    ''Private Sub Lstmins_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    ''    LblTime.Text = Trim(Lsthrs.Text) & " : " & Trim(Lstmins.Text) & ":00"
    ''End Sub
    Private Sub Timeconvr()
        'Dim strttime As Date
        'Dim frmtime As Date
        'Dim th1 As Single = 0
        'Dim tm1 As Single = 0
        'Dim th2 As Single = 0
        'Dim tm2 As Single = 0
        'Dim endtime As Date
        'Dim th3 As Single = 0
        'Dim tm3 As Single = 0
        'strttime = LblStrtTime.Text
        'th1 = Format(strttime, "HH")
        'th1 = th1 * 60
        'tm1 = Format(strttime, "mm")
        'tm1 = th1 + tm1
        'frmtime = LblReptm.Text
        'th2 = Format(frmtime, "HH")
        'th2 = th2 * 60
        'tm2 = Format(frmtime, "mm")
        'tm2 = th2 + tm2
        'res = (tm2 - tm1)
        'endtime = LblEndTime.Text
        'th3 = Format(endtime, "HH")
        'th3 = th3 * 60
        'tm3 = Format(endtime, "mm")
        'tm3 = th3 + tm3
        'res1 = tm3 - tm2

    End Sub



    Private Sub Timeconvr1()
        'Dim strttime As Date
        'Dim rptime As Date
        'Dim th1 As Single = 0
        'Dim tm1 As Single = 0
        'Dim th2 As Single = 0
        'Dim tm2 As Single = 0
        'Dim endtime As Date
        'Dim th3 As Single = 0
        'Dim tm3 As Single = 0

        'strttime = LblSrtlvTo.Text
        'th1 = Format(strttime, "HH")
        'th1 = th1 * 60
        'tm1 = Format(strttime, "mm")
        'tm1 = th1 + tm1
        'rptime = LblRTime.Text
        'th2 = Format(rptime, "HH")
        'th2 = th2 * 60
        'tm2 = Format(rptime, "mm")
        'tm2 = th2 + tm2
        'res = (tm2 - tm1)
        'endtime = LblEndTime.Text
        'th3 = Format(endtime, "HH")
        'th3 = th3 * 60
        'tm3 = Format(endtime, "mm")
        'tm3 = th3 + tm3
        'res1 = tm3 - tm2
    End Sub
    Private Sub Timeconvr2()
        res = 0
        res1 = 0
        Dim strttime As Date
        Dim endtime As Date
        Dim rptime As Date
        Dim th1 As Single = 0
        Dim tm1 As Single = 0
        Dim th2 As Single = 0
        Dim tm2 As Single = 0
        Dim th3 As Single = 0
        Dim tm3 As Single = 0
        strttime = LblStrtTime.Text
        th1 = Format(strttime, "HH")
        th1 = th1 * 60
        tm1 = Format(strttime, "mm")
        tm1 = th1 + tm1
        ' rptime = LblTime.Text
        th2 = Format(rptime, "HH")
        th2 = th2 * 60
        tm2 = Format(rptime, "mm")
        tm2 = th2 + tm2
        res = (tm2 - tm1)
        endtime = LblEndTime.Text
        th3 = Format(endtime, "HH")
        th3 = th3 * 60
        tm3 = Format(endtime, "mm")
        tm3 = th3 + tm3
        res1 = tm3 - tm2
    End Sub


    'Private Sub Cmbxrsn2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Totcaslv1 As Double
    '    Dim Totsicklv1 As Double
    '    Totcaslv1 = Caslv - 0.5
    '    Totsicklv1 = Sicklv - 0.5
    '    Fetch_Num_of_Levs_Mstr()
    '    Count_Num_of_FDCasLevs_Attd()
    '    Count_Num_of_1HFCasLevs_Attd()
    '    Count_Num_of_2HFCasLevs_Attd()
    '    Totcaslv = Tot_fd_caslv + Tot_1hf_caslv + Tot_2hf_caslv

    '    Count_Num_of_FDSickLevs_Attd()
    '    Count_Num_of_1HFSickLevs_Attd()
    '    Count_Num_of_2HFSickLevs_Attd()
    '    Totsicklv = Tot_fd_sicklv + Tot_1hf_sicklv + Tot_2hf_sicklv
    '    If RbFDLeve.Checked = True And Cmbxrsn2.Text = "Casual Leave" Then
    '        If Totcaslv = Caslv Then
    '            MsgBox("No Casual Leave Available", MsgBoxStyle.Information, "Leave")
    '            PnlReprtLate.Visible = True
    '            Exit Sub
    '        ElseIf Totcaslv = Totcaslv1 Then
    '            MsgBox("Try for Half Day Leave ", MsgBoxStyle.Information, "Leave")
    '            PnlReprtLate.Visible = True
    '            Exit Sub
    '        End If
    '    ElseIf RbFDLeve.Checked = True And Cmbxrsn2.Text = "Sick Leave" Then
    '        If Totsicklv = Sicklv Then
    '            MsgBox("No Sick Leave Available", MsgBoxStyle.Information, "Leave")
    '            PnlReprtLate.Visible = True
    '            Exit Sub
    '        ElseIf Totsicklv = Totsicklv1 Then
    '            MsgBox("Try for Half Day Leave ", MsgBoxStyle.Information, "Leave")
    '            PnlReprtLate.Visible = True
    '            Exit Sub

    '        End If
    '    ElseIf Rb1HFLeve.Checked = True And Cmbxrsn2.Text = "Casual Leave" Then
    '        If Totcaslv = Caslv Then
    '            MsgBox("No Casual Leave Available", MsgBoxStyle.Information, "Leave")
    '            PnlReprtLate.Visible = True
    '            Exit Sub
    '        End If
    '    ElseIf Rb1HFLeve.Checked = True And Cmbxrsn2.Text = "Sick Leave" Then
    '        If Totsicklv = Sicklv Then
    '            MsgBox("No Sick Leave Available", MsgBoxStyle.Information, "Leave")
    '            PnlReprtLate.Visible = True
    '            Exit Sub
    '        End If
    '    ElseIf Rb2HFLeve.Checked = True And Cmbxrsn2.Text = "Casual Leave" Then
    '        If Totcaslv = Caslv Then
    '            MsgBox("No Casual Leave Available", MsgBoxStyle.Information, "Leave")
    '            PnlReprtLate.Visible = True
    '            Exit Sub
    '        End If
    '    ElseIf Rb2HFLeve.Checked = True And Cmbxrsn2.Text = "Sick Leave" Then
    '        If Totsicklv = Sicklv Then
    '            MsgBox("No Sick Leave Available", MsgBoxStyle.Information, "Leave")
    '            PnlReprtLate.Visible = True
    '            Exit Sub
    '        End If
    '    End If

    'End Sub





    'Private Sub Tconvr()
    '    Dim strttm As Date
    '    Dim endtm As Date
    '    Dim frmtime As Date
    '    Dim totime As Date
    '    Dim reptime As Date

    '    Dim strthrs As Single = 0
    '    strtmins = 0

    '    Dim endhrs As Single = 0
    '    endmins = 0

    '    Dim frmhrs As Single = 0
    '    frmmins = 0

    '    Dim rephrs As Single = 0
    '    repmins = 0

    '    Dim tohrs As Single = 0
    '    tomins = 0
    '    diff = 0

    '    strttm = LblStrtTime.Text
    '    strthrs = Format(strttm, "HH")
    '    strthrs = strthrs * 60
    '    strtmins = Format(StrtTime, "mm")
    '    strtmins = strthrs + strtmins

    '    ' frmtime = LblReptm.Text
    '    frmhrs = Format(frmtime, "HH")
    '    frmhrs = frmhrs * 60
    '    frmmins = Format(frmtime, "mm")
    '    frmmins = frmhrs + frmmins

    '    ' totime = LblSrtlvTo.Text
    '    tohrs = Format(totime, "HH")
    '    tohrs = tohrs * 60
    '    tomins = Format(totime, "mm")
    '    tomins = tohrs + tomins


    '    endtm = LblEndTime.Text
    '    endhrs = Format(endtm, "HH")
    '    endhrs = endhrs * 60
    '    endmins = Format(EndTime, "mm")
    '    endmins = endhrs + endmins

    '    reptime = LblRTime.Text
    '    rephrs = Format(reptime, "HH")
    '    rephrs = rephrs * 60
    '    repmins = Format(reptime, "mm")
    '    repmins = rephrs + repmins
    '    diff = repmins - tomins

    'End Sub



    Private Sub BtnHoliday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHoliday.Click
        LstCount = Datagrd.Rows.Count
        Dim counter As Integer = 0
        If LstCount <> 0 Then
            While counter < LstCount
                Datagrd.Rows(counter).Cells(3).Value = "Holiday"
                Datagrd.Rows(counter).Cells(4).Value = "Holiday"
                Datagrd.Rows(counter).Cells(5).Value = "00:00:00"
                Datagrd.Rows(counter).Cells(9).Value = "Holiday"
                counter = counter + 1
            End While
        Else
            MsgBox("No Record Found in the List to mark Holiday", MsgBoxStyle.Information, "Find")

        End If
    End Sub


    Private Sub DtpkrDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpkrDt.ValueChanged
        clrval()
        LblSft.Visible = False
        cmbxsift.Visible = True
    End Sub


    Private Sub CmbxOptn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxOptn.SelectedIndexChanged
        If CmbxOptn.SelectedIndex = 0 Then
            GrpBxOptn.Location = New System.Drawing.Point(338, 172)
            GrpBxOptn.Visible = True
            CmbxDays.Focus()
            DtpkrFrm.MinDate = DtpkrDt.Value.Date
            DtpkrFrm.Text = DtpkrFrm.MinDate


        End If
    End Sub


    Private Sub BtnGrpCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrpCncl.Click
        CmbxDays.DroppedDown = False
        GrpBxOptn.Visible = False
        CmbxDays.DroppedDown = False
        If CmbxOptn.SelectedIndex >= 0 Then
            CmbxOptn.SelectedIndex = -1
            CmbxOptn.Text = "Select"
        End If


    End Sub


    Private Sub BtnGrpOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrpOk.Click
        Dim dayname As String
        If cmbxshft.Text = "" Then
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Fields")
            cmbxshft.Focus()
            Exit Sub
        End If
        dayname = CmbxDays.Text
        If dayname = "Sunday" Then
            offday = 0
        ElseIf dayname = "Monday" Then
            offday = 1
        ElseIf dayname = "Tuesday" Then
            offday = 2
        ElseIf dayname = "Wednesday" Then
            offday = 3
        ElseIf dayname = "Thursday" Then
            offday = 4
        ElseIf dayname = "Friday" Then
            offday = 5
        ElseIf dayname = "Saturday" Then
            offday = 6
        End If
        Fromdt = DtpkrFrm.Value.Date
        Todt = DtpkrTo.Value.Date
        offshft = cmbxshft.Text

        Try
            P_Roll_Attd_Cmd = New SqlCommand("Finact_EmpAttdoffday_Insert", FinActConn)
            P_Roll_Attd_Cmd.CommandType = CommandType.StoredProcedure
            P_Roll_Attd_Cmd.Parameters.AddWithValue("@offday", offday)
            P_Roll_Attd_Cmd.Parameters.AddWithValue("@fromdt", Fromdt)
            P_Roll_Attd_Cmd.Parameters.AddWithValue("@todt", Todt)
            P_Roll_Attd_Cmd.Parameters.AddWithValue("@offshft", offshft)
            P_Roll_Attd_Cmd.Parameters.AddWithValue("@offadusrid", Current_UsrId)
            P_Roll_Attd_Cmd.Parameters.AddWithValue("@offaddt", Now)
            P_Roll_Attd_Cmd.Parameters.AddWithValue("@offdelstatus", 1)

            P_Roll_Attd_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            P_Roll_Attd_Cmd = Nothing
        End Try


        CmbxDays.DroppedDown = False
        GrpBxOptn.Visible = False
        CmbxDays.DroppedDown = False
    End Sub

    Private Sub CmbxDays_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDays.GotFocus
        CmbxDays.SelectedIndex = 0
        CmbxDays.DroppedDown = True

    End Sub

    Private Sub cmbxshft_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxshft.GotFocus
        fetch_ComboShift(cmbxshft)
        If cmbxshft.Items.Count > 0 And cmbxshft.Text = "" Then
            cmbxshft.SelectedIndex = 0
            cmbxshft.DroppedDown = True
        End If
    End Sub

    Private Sub CmbxDays_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxDays.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            DtpkrFrm.Focus()

        End If
    End Sub

    Private Sub DtpkrFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrFrm.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            DtpkrTo.Focus()

        End If
    End Sub

    Private Sub DtpkrTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrTo.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            cmbxshft.Focus()

        End If
    End Sub


    Private Sub cmbxshft_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxshft.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            BtnGrpOk.Focus()
        End If
    End Sub

    Private Sub DtpkrFrm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrFrm.Leave
        DtpkrTo.MinDate = DtpkrFrm.Value.Date
        DtpkrTo.Text = DtpkrTo.MinDate
    End Sub


    'Private Sub CmbxResn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If CmbxResn.Items.Count > 0 Then
    '        CmbxResn.SelectedIndex = 0
    '        CmbxResn.DroppedDown = True

    '    End If
    'End Sub




    'Private Sub CmbxResn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
    '        If CmbxResn.Text = "Personal" Then


    '            Fetch_Num_of_Levs_Mstr()
    '            Count_Num_of_SrtLevs_Attd()

    '            If Srtlv < Totsrtlv Then
    '                Fetch_SrtLeaves()
    '                If Srtlv + Srt_Levs >= Totsrtlv Then
    '                    MsgBox("All issued Short Leaves(Personal) have been used.", MsgBoxStyle.Information, "Short Leave")
    '                    PnlReprtLate.Visible = True
    '                Else
    '                    ' CmbxHrs.Focus()
    '                End If
    '            ElseIf Srtlv >= Totsrtlv And CmbxResn.Text = "Personal" Then
    '                MsgBox("All issued Short Leaves(Personal) have been used.", MsgBoxStyle.Information, "Short Leave")
    '            End If
    '        Else
    '            ' CmbxHrs.Focus()

    '        End If

    '    End If
    'End Sub




    Private Sub Fetch_SrtLeaves()
        fetch_EmpId()
        Try
            P_Roll_Attd_Cmd = New SqlCommand("Select count(SrtLevId) from Finact_Attd_SrtLev where SrtLevType='Personal' and SrtLevEmpid='" & (Empid) & "'and month(SrtLevDate)='" & (DtpkrDt.Value.Date.Month) & "'and Year(SrtLevDate)='" & (DtpkrDt.Value.Date.Year) & "' ", FinActConn)
            P_Roll_Attd_Rdr = P_Roll_Attd_Cmd.ExecuteReader
            P_Roll_Attd_Rdr.Read()
            If P_Roll_Attd_Rdr.HasRows = True Then
                Srt_Levs = P_Roll_Attd_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            'If Attd_SrtLeve_Rdr.HasRows = False Then

            'End If
            P_Roll_Attd_Rdr.Close()
            P_Roll_Attd_Cmd = Nothing
        End Try
    End Sub

    Private Sub RbShrtLeve_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbShrtLeve.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnRptOK.Focus()

        End If
    End Sub


    Private Sub CmbxHrs_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'If CmbxHrs.Items.Count > 0 Then
        '    CmbxHrs.SelectedIndex = 0
        '    CmbxHrs.DroppedDown = True
        'End If
    End Sub

    Private Sub CmbxHrs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then
        '    CmbxMint.Focus()
        'End If
    End Sub

    'Private Sub CmbxMint_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'If CmbxMint.Items.Count > 0 Then
    '    '    CmbxMint.SelectedIndex = 0
    '    '    CmbxMint.DroppedDown = True
    '    'End If
    'End Sub

    'Private Sub CmbxMint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
    '        Cmbxhrs1.Focus()
    '    End If
    'End Sub

    'Private Sub Cmbxhrs1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Cmbxhrs1.Items.Count > 0 Then
    '        Cmbxhrs1.SelectedIndex = 0
    '        Cmbxhrs1.DroppedDown = True
    '    End If
    'End Sub

    Private Sub CmbxHrs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'LblReptm.Text = Trim(CmbxHrs.Text) & " : " & Trim(CmbxMint.Text) & ":00"
        'LblSrtlvTo.Text = Trim(CmbxHrs.Text + 2) & ":" & Trim(CmbxMint.Text) & ":00"
        'Cmbxhrs1.Text = Mid(LblSrtlvTo.Text, 1, 2)
        'CmbxMint1.Text = Mid(LblSrtlvTo.Text, 4, 2)
        'LblRTime.Text = Trim(CmbxHrs.Text + 2) & ":" & Trim(CmbxMint.Text) & ":00"
    End Sub

    'Private Sub Cmbxhrs1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
    '        CmbxMint1.Focus()
    '    End If
    'End Sub

    'Private Sub Cmbxhrs1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LblRTime.Text = Trim(Cmbxhrs1.Text) & " : " & Trim(CmbxMint1.Text) & ":00"
    'End Sub

    'Private Sub CmbxMint1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If CmbxMint1.Items.Count > 0 Then
    '        CmbxMint1.SelectedIndex = 0
    '        CmbxMint1.DroppedDown = True
    '    End If
    'End Sub

    Private Sub CmbxMint1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            BtnRptOK.Focus()
        End If
    End Sub

    'Private Sub CmbxMint1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LblRTime.Text = Trim(Cmbxhrs1.Text) & " : " & Trim(CmbxMint1.Text) & ":00"
    'End Sub

    'Private Sub CmbxMint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'If CmbxHrs.Text <> "" Then
    '    '    LblReptm.Text = Trim(CmbxHrs.Text) & " : " & Trim(CmbxMint.Text) & ":00"
    '    '    LblSrtlvTo.Text = Trim(CmbxHrs.Text + 2) & ":" & Trim(CmbxMint.Text) & ":00"
    '    '    Cmbxhrs1.Text = Mid(LblSrtlvTo.Text, 1, 2)
    '    '    CmbxMint1.Text = Mid(LblSrtlvTo.Text, 4, 2)
    '    '    LblRTime.Text = Trim(CmbxHrs.Text + 2) & ":" & Trim(CmbxMint.Text) & ":00"
    '    'Else
    '    '    MsgBox("Please select the Hours", MsgBoxStyle.Information, "Time")

    '    'End If
    'End Sub

    Private Sub RbFDLeve_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbFDLeve.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnRptOK.Focus()
        End If
    End Sub

    'Private Sub Cmbxrsn2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Cmbxrsn2.Items.Count > 0 Then
    '        Cmbxrsn2.SelectedIndex = 0
    '        Cmbxrsn2.DroppedDown = True
    '    End If
    'End Sub

    'Private Sub Cmbxrsn2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    BtnRptOK.Focus()
    'End Sub

    Private Sub Rb1HFLeve_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Rb1HFLeve.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnRptOK.Focus()
        End If
    End Sub

    Private Sub Rb2HFLeve_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Rb2HFLeve.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnRptOK.Focus()
        End If
    End Sub

    Private Sub Fetch_StrtMnth()
        Try
            P_Roll_Attd_Cmd = New SqlCommand("Select strtmnth from Finactcogatemstr ", FinActConn)
            P_Roll_Attd_Rdr = P_Roll_Attd_Cmd.ExecuteReader
            P_Roll_Attd_Rdr.Read()
            If P_Roll_Attd_Rdr.HasRows = True Then
                Strt_Mnth = P_Roll_Attd_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            'If Attd_SrtLeve_Rdr.HasRows = False Then

            'End If
            P_Roll_Attd_Rdr.Close()
            P_Roll_Attd_Cmd = Nothing
        End Try

    End Sub

    Private Sub Fetch_Presnt()
        Fetch_StrtMnth()
        Dim Crntdt, Strt_dt, finl_dt1, finl_dt2 As Date
        Dim Crntmnth As Integer

        Crntdt = DtpkrDt.Value.Date
        Crntmnth = Crntdt.Month
        If Strt_Mnth < Crntmnth Then
            diff = Crntmnth - Strt_Mnth
            Strt_dt = Crntdt.AddMonths(-diff)

            finl_dt1 = DateSerial((Strt_dt.Date.Year), Month(Strt_dt.Date), 1)
            finl_dt2 = finl_dt1.AddMonths(+12)
            finl_dt2 = DateSerial((finl_dt2.Date.Year), Month(finl_dt2.Date), -1).AddDays(+1)
        ElseIf Strt_Mnth > Crntmnth Then
            Crntdt = DtpkrDt.Value.Date.AddMonths(-Crntmnth)
            Crntmnth = Crntdt.Month
            diff = Crntmnth - Strt_Mnth
            Strt_dt = Crntdt.AddMonths(-diff)

            finl_dt1 = DateSerial((Strt_dt.Date.Year), Month(Strt_dt.Date), 1)
            finl_dt2 = finl_dt1.AddMonths(+12)
            finl_dt2 = DateSerial((finl_dt2.Date.Year), Month(finl_dt2.Date), -1).AddDays(+1)

        End If


        Try
            P_Roll_Attd_Cmd = New SqlCommand("Select count(AttdId) from Finact_Attd where AttdStatus='Present' and AttdRepStatus='On Time' and AttdEmpid='" & (Emlid) & "'and Attddt between '" & (finl_dt1) & "'and '" & (finl_dt2) & "' and Year(Attddt)='" & (DtpkrDt.Value.Date.Year) & "' ", FinActConn)
            P_Roll_Attd_Rdr = P_Roll_Attd_Cmd.ExecuteReader
            P_Roll_Attd_Rdr.Read()
            If P_Roll_Attd_Rdr.HasRows = True Then
                Presnt_Cnt1 = P_Roll_Attd_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            'If Attd_SrtLeve_Rdr.HasRows = False Then

            'End If
            P_Roll_Attd_Rdr.Close()
            P_Roll_Attd_Cmd = Nothing
        End Try

        Try
            P_Roll_Attd_Cmd = New SqlCommand("Select count(AttdId) from Finact_Attd where AttdStatus='PresntCumLev' and AttdEmpid='" & (Emlid) & "'and Attddt between '" & (finl_dt1) & "'and '" & (finl_dt2) & "' and Year(Attddt)='" & (DtpkrDt.Value.Date.Year) & "' ", FinActConn)
            P_Roll_Attd_Rdr = P_Roll_Attd_Cmd.ExecuteReader
            P_Roll_Attd_Rdr.Read()
            If P_Roll_Attd_Rdr.HasRows = True Then
                Presnt_Cnt2 = P_Roll_Attd_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
        Finally
            'If Attd_SrtLeve_Rdr.HasRows = False Then

            'End If
            P_Roll_Attd_Rdr.Close()
            P_Roll_Attd_Cmd = Nothing
        End Try
        Totl_Presnt = Presnt_Cnt1 + Presnt_Cnt2 / 2

    End Sub


    Private Sub RbErnLev_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbErnLev.CheckedChanged
        If RbErnLev.Checked = True Then
            'LblResn.Visible = False
            'Cmbxrsn2.Visible = False
            Fetch_Num_of_Levs_Mstr()
            Count_Num_of_FDCasLevs_Attd()
            Count_Num_of_1HFCasLevs_Attd()
            Count_Num_of_2HFCasLevs_Attd()
            Totcaslv = Tot_fd_caslv + Tot_1hf_caslv + Tot_2hf_caslv

            Count_Num_of_FDSickLevs_Attd()
            Count_Num_of_1HFSickLevs_Attd()
            Count_Num_of_2HFSickLevs_Attd()
            Totsicklv = Tot_fd_sicklv + Tot_1hf_sicklv + Tot_2hf_sicklv


            If Totcaslv + Totsicklv = Caslv + Sicklv Then

                Fetch_Presnt()
                If Totl_Presnt >= 20 Then
                    ErnLevs = DivRem(CInt(Totl_Presnt), 20, 0)
                    Count_Num_of_EarnLevs_Attd()
                    If Fetch_ErnLevs = ErnLevs Then
                        MsgBox("All Earn Leaves have been issued.", MsgBoxStyle.Information, "Earn Leaves")
                    ElseIf Fetch_ErnLevs < ErnLevs Then
                        PnlReprtLate.Visible = False
                        PnlErnLev.Visible = True
                        PnlErnLev.Location = New System.Drawing.Point(342, 245)
                        Rb1HFErn.Checked = False
                        Rb2HFErn.Checked = False
                        RbFDErn.Checked = False
                        'PnlReprtLate.Size = New System.Drawing.Point(356, 193)
                        'GroupBox1.Size = New System.Drawing.Point(348, 112)
                        'BtnRptOK.Location = New System.Drawing.Point(114, 155)
                        'BtnRptOK.Size = New System.Drawing.Point(39, 24)
                        'BtnRptCncl.Location = New System.Drawing.Point(200, 155)
                        'BtnRptCncl.Size = New System.Drawing.Point(55, 23)
                        'PnlRPTime.Visible = False
                        'PnlRT.Visible = False
                        'LblResn.Visible = True
                        'CmbxResn.Visible = False
                        'Cmbxrsn2.Visible = True
                        'Cmbxrsn2.Location = New System.Drawing.Point(88, 116)
                    End If
                ElseIf Totl_Presnt < 20 Then

                    MsgBox("System has found no Earn Leaves.", MsgBoxStyle.Information, "Earn Leaves")
                    RbErnLev.Checked = False
                End If
            Else
                MsgBox("First use 1st Half, 2nd Half or Full Day Leave.", MsgBoxStyle.Information, "Leave")
                RbErnLev.Checked = False
            End If
        End If
    End Sub



    Private Sub RbMatrntyLev_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbMatrntyLev.CheckedChanged
        If RbMatrntyLev.Checked = True Then
            Dim Lev_cnt As Integer
            attd_flag = True
            SrtLev_dt = DtpkrDt.Value.Date
            SrtLev_Shift = cmbxsift.Text
            SrtLev_Empnm = Datagrd.SelectedRows(0).Cells(2).Value
            SrtLev_Empid = Datagrd.SelectedRows(0).Cells(1).Value
            Try
                P_Roll_Attd_Cmd = New SqlCommand("Select count(MLevDt) from Finact_Attd_MatrnityLev  where MLevEmpId ='" & (SrtLev_Empid) & "'and MLevDt<='" & (DtpkrDt.Value.Date) & "'", FinActConn)
                'P_Roll_Attd_Cmd = New SqlCommand("Select SrtLevDate,SrtLevEmpid,Finactempmstr.empname,SrtLevStrtTm,SrtLevEndTm,SrtLevRepTm,SrtLevShift,SrtLevType from  Finact_Attd_SrtLev inner join FinactEmpmstr on Finact_Attd_SrtLev.SrtLevEmpid=FinactEmpmstr.empid where SrtLevEmpid='" & (SrtLev_Empid) & "'and month(SrtLevDate)='" & (DtpkrDt.Value.Date.Month) & "'and year(SrtLevDate)='" & (DtpkrDt.Value.Date.Year) & "'and SrtLevdelstatus=0 ", FinActConn)
                P_Roll_Attd_Rdr = P_Roll_Attd_Cmd.ExecuteReader

                P_Roll_Attd_Rdr.Read()
                If P_Roll_Attd_Rdr.HasRows = True Then

                    Lev_cnt = P_Roll_Attd_Rdr(0)

                End If


            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Attendence !!!!")
            Finally

                P_Roll_Attd_Rdr.Close()
                P_Roll_Attd_Cmd = Nothing
            End Try
            If Lev_cnt = 0 Then

                FrmMatrntyLev.Show()
                FrmMatrntyLev.Location = New System.Drawing.Point(320, 250)
            ElseIf Lev_cnt > 0 Then

                MsgBox("This Leave has already been issued to '" & (SrtLev_Empnm) & "'", MsgBoxStyle.Information, "Maternity Leave")
                MatrntyLev_flag = True
                FrmMatrntyLev.Show()
                FrmMatrntyLev.Location = New System.Drawing.Point(320, 250)
            End If
        End If
    End Sub


    Private Sub BtnCnclErn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCnclErn.Click
        PnlErnLev.Visible = False
        PnlReprtLate.Visible = True
        RbErnLev.Checked = False
    End Sub


    Public Shared Function ConvertTime(ByVal strtdate As String) As Date
        Return DateTime.ParseExact(strtdate, "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
    End Function


    Private Sub BtnOkErn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOkErn.Click
        If Rb1HFErn.Checked = True Then
            ErnLev_Type = "1st Half Day ErnLev"
        ElseIf Rb2HFErn.Checked = True Then
            ErnLev_Type = "2nd Half Day ErnLev"
        ElseIf RbFDErn.Checked = True Then
            ErnLev_Type = "Full Day ErnLev"
        End If


        PnlErnLev.Visible = False
        PnlReprtLate.Visible = False
        counter = 0

        ' If RbErnLev.Checked = True Then
        If Rb1HFErn.Checked = True Then
            'While counter < LstCount
            ''        If Lstvewattend.SelectedItems(counter).SubItems(5).Text = "Absent" And LblAbsnt.Text <> 0 Then
            ''            LblAbsnt.Text = LblAbsnt.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(5).Text = "Present" And LblPresnt.Text <> 0 Then
            ''            LblPresnt.Text = LblPresnt.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "Short Leave" And LblShrtLeve.Text <> 0 Then
            ''            LblShrtLeve.Text = LblShrtLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "Full Day Leave" And LblFDLeve.Text <> 0 Then
            ''            LblFDLeve.Text = LblFDLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "1st Half Leave" And LblHfLeve.Text <> 0 Then
            ''            LblHfLeve.Text = LblHfLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
            ''            LblHfLeve.Text = LblHfLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "Late" And LblReprtlat.Text <> 0 Then
            ''            LblReprtlat.Text = LblReprtlat.Text - 1
            ''        End If
            ''        Lstvewattend.SelectedItems(counter).SubItems(5).Text = "PresntCumLev"
            ''        Lstvewattend.SelectedItems(counter).SubItems(6).Text = ErnLev_Type
            ''        ' Lstvewattend.SelectedItems(counter).SubItems(7).Text = "00:00:00"
            ''        Lstvewattend.SelectedItems(counter).SubItems(9).Text = "Earn"
            ''        counter = counter + 1
            ''    End While
            ''    LblFDLeve.Text = LblFDLeve.Text + LstCount
            ''    PnlReprtLate.Visible = False
            ''ElseIf Rb2HFErn.Checked = True Then
            ''    While counter < LstCount
            ''        If Lstvewattend.SelectedItems(counter).SubItems(5).Text = "Absent" And LblAbsnt.Text <> 0 Then
            ''            LblAbsnt.Text = LblAbsnt.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(5).Text = "Present" And LblPresnt.Text <> 0 Then
            ''            LblPresnt.Text = LblPresnt.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "Short Leave" And LblShrtLeve.Text <> 0 Then
            ''            LblShrtLeve.Text = LblShrtLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "Full Day Leave" And LblFDLeve.Text <> 0 Then
            ''            LblFDLeve.Text = LblFDLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "1st Half Leave" And LblHfLeve.Text <> 0 Then
            ''            LblHfLeve.Text = LblHfLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
            ''            LblHfLeve.Text = LblHfLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "Late" And LblReprtlat.Text <> 0 Then
            ''            LblReprtlat.Text = LblReprtlat.Text - 1
            ''        End If
            ''        Lstvewattend.SelectedItems(counter).SubItems(5).Text = "PresntCumLev"
            ''        Lstvewattend.SelectedItems(counter).SubItems(6).Text = "ErnLev_Type"
            ''        Lstvewattend.SelectedItems(counter).SubItems(7).Text = LblBrkTo.Text
            ''        Lstvewattend.SelectedItems(counter).SubItems(9).Text = "Earn"
            ''        counter = counter + 1
            ''    End While
            ''    LblHfLeve.Text = LblHfLeve.Text + LstCount
            ''    LblPresnt.Text = LblPresnt.Text + 1
            ''    PnlReprtLate.Visible = False
            ''ElseIf RbFDErn.Checked = True Then
            ''    While counter < LstCount
            ''        If Lstvewattend.SelectedItems(counter).SubItems(5).Text = "Absent" And LblAbsnt.Text <> 0 Then
            ''            LblAbsnt.Text = LblAbsnt.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(5).Text = "Present" And LblPresnt.Text <> 0 Then
            ''            LblPresnt.Text = LblPresnt.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "Short Leave" And LblShrtLeve.Text <> 0 Then
            ''            LblShrtLeve.Text = LblShrtLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "Full Day Leave" And LblFDLeve.Text <> 0 Then
            ''            LblFDLeve.Text = LblFDLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "1st Half Leave" And LblHfLeve.Text <> 0 Then
            ''            LblHfLeve.Text = LblHfLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "2nd Half Leave" And LblHfLeve.Text <> 0 Then
            ''            LblHfLeve.Text = LblHfLeve.Text - 1
            ''        End If
            ''        If Lstvewattend.SelectedItems(counter).SubItems(6).Text = "Late" And LblReprtlat.Text <> 0 Then
            ''            LblReprtlat.Text = LblReprtlat.Text - 1
            ''        End If
            ''        Lstvewattend.SelectedItems(counter).SubItems(5).Text = "Leave"
            ''        Lstvewattend.SelectedItems(counter).SubItems(6).Text = "ErnLev_Type"
            ''        Lstvewattend.SelectedItems(counter).SubItems(7).Text = LblStrtTime.Text
            ''        Lstvewattend.SelectedItems(counter).SubItems(9).Text = "Earn"
            ''        counter = counter + 1
            ''    End While
            LblHfLeve.Text = LblHfLeve.Text + LstCount
            LblPresnt.Text = LblPresnt.Text + 1
            PnlReprtLate.Visible = False
        End If
        ' End If
    End Sub

    Private Sub Rball_attd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rball_attd.CheckedChanged

        If Rball_attd.Checked = True Then
            If Attd_Type = 2 Then

                For i = 0 To Me.Datagrd.Rows.Count - 1

                    Me.Datagrd.Rows(i).Cells(7).Value = LblBrkFrm.Text
                    If Datagrd.Rows(i).Cells(4).Value = "Absent" Or Datagrd.Rows(i).Cells(4).Value = "Maternity Leave" Or Datagrd.Rows(i).Cells(4).Value = "Full Day Leave" Or Datagrd.Rows(i).Cells(4).Value = "1st Half Day Leave" Or Datagrd.Rows(i).Cells(4).Value = "2nd Half Day Leave" Then
                        Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00"
                        ' Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00"
                    End If


                Next
            ElseIf Attd_Type = 3 Then
                For i = 0 To Me.Datagrd.Rows.Count - 1

                    Me.Datagrd.Rows(i).Cells(8).Value = LblBrkTo.Text
                    If Datagrd.Rows(i).Cells(4).Value = "Absent" Or Datagrd.Rows(i).Cells(4).Value = "Maternity Leave" Or Datagrd.Rows(i).Cells(4).Value = "Full Day Leave" Or Datagrd.Rows(i).Cells(4).Value = "1st Half Day Leave" Or Datagrd.Rows(i).Cells(4).Value = "2nd Half Day Leave" Then
                        ' Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00"
                        Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00"
                    End If


                Next
            ElseIf Attd_Type = 4 Then
                For i = 0 To Me.Datagrd.Rows.Count - 1

                    Me.Datagrd.Rows(i).Cells(9).Value = LblEndTime.Text
                    If Datagrd.Rows(i).Cells(4).Value = "Absent" Or Datagrd.Rows(i).Cells(4).Value = "Maternity Leave" Or Datagrd.Rows(i).Cells(4).Value = "Full Day Leave" Or Datagrd.Rows(i).Cells(4).Value = "1st Half Day Leave" Or Datagrd.Rows(i).Cells(4).Value = "2nd Half Day Leave" Then

                        Me.Datagrd.Rows(i).Cells(9).Value = "00:00:00"
                    End If


                Next

            End If

        End If



    End Sub

    Private Sub Rball_sel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rball_sel.CheckedChanged

        If Rball_sel.Checked = True Then
            If Attd_Type = 2 Then
                For i = 0 To Me.Datagrd.Rows.Count - 1
                    If Me.Datagrd.Rows(i).Cells(0).Value = True Then
                        Me.Datagrd.Rows(i).Cells(7).Value = LblBrkFrm.Text
                        If Datagrd.Rows(i).Cells(4).Value = "Absent" Or Datagrd.Rows(i).Cells(4).Value = "Maternity Leave" Or Datagrd.Rows(i).Cells(4).Value = "Full Day Leave" Then
                            Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00"
                            'Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00"
                        End If

                    End If
                Next
            ElseIf Attd_Type = 3 Then
                For i = 0 To Me.Datagrd.Rows.Count - 1
                    If Me.Datagrd.Rows(i).Cells(0).Value = True Then
                        Me.Datagrd.Rows(i).Cells(8).Value = LblBrkTo.Text

                        If Datagrd.Rows(i).Cells(4).Value = "Absent" Or Datagrd.Rows(i).Cells(4).Value = "Maternity Leave" Or Datagrd.Rows(i).Cells(4).Value = "Full Day Leave" Then
                            ' Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00"
                            Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00"
                        End If

                    End If
                Next
            ElseIf Attd_Type = 4 Then
                For i = 0 To Me.Datagrd.Rows.Count - 1
                    If Me.Datagrd.Rows(i).Cells(0).Value = True Then
                        Me.Datagrd.Rows(i).Cells(9).Value = LblEndTime.Text
                        If Datagrd.Rows(i).Cells(4).Value = "Absent" Or Datagrd.Rows(i).Cells(4).Value = "Maternity Leave" Or Datagrd.Rows(i).Cells(4).Value = "Full Day Leave" Then
                            'Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00"
                            Me.Datagrd.Rows(i).Cells(9).Value = "00:00:00"
                        End If

                    End If
                Next
            End If
        End If

    End Sub

    Private Sub RbOut_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbOut_All.CheckedChanged
        If RbOut_All.Checked = True Then
            If Attd_Type = 5 Then

                For i = 0 To Me.Datagrd.Rows.Count - 1

                    Me.Datagrd.Rows(i).Cells(7).Value = LblBrkFrm.Text
                    Me.Datagrd.Rows(i).Cells(8).Value = LblBrkTo.Text
                    If Datagrd.Rows(i).Cells(4).Value = "Absent" Or Datagrd.Rows(i).Cells(4).Value = "Maternity Leave" Or Datagrd.Rows(i).Cells(4).Value = "Full Day Leave" Or Datagrd.Rows(i).Cells(4).Value = "1st Half Day Leave" Or Datagrd.Rows(i).Cells(4).Value = "2nd Half Day Leave" Then
                        Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00"
                        Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00"
                    End If

                    If Me.Datagrd.Rows(i).Cells(0).Value = True Then

                        Me.Datagrd.Rows(i).Cells(0).Value = False
                    End If
                Next

            End If

        End If

    End Sub


    Private Sub RbOut_Sel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbOut_Sel.CheckedChanged
        If RbOut_Sel.Checked = True Then
            If Attd_Type = 5 Then
                For i = 0 To Me.Datagrd.Rows.Count - 1
                    If Me.Datagrd.Rows(i).Cells(0).Value = True Then
                        Me.Datagrd.Rows(i).Cells(7).Value = LblBrkFrm.Text
                        Me.Datagrd.Rows(i).Cells(8).Value = LblBrkTo.Text
                        If Datagrd.Rows(i).Cells(4).Value = "Absent" Or Datagrd.Rows(i).Cells(4).Value = "Maternity Leave" Or Datagrd.Rows(i).Cells(4).Value = "Full Day Leave" Then
                            Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00"
                            Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00"

                        End If

                    Else
                        Me.Datagrd.Rows(i).Cells(7).Value = "00:00:00"
                        Me.Datagrd.Rows(i).Cells(8).Value = "00:00:00"
                    End If
                Next

            End If
        End If
    End Sub

    Private Sub Datagrd_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Datagrd.CellBeginEdit
        For i = 0 To Me.Datagrd.Rows.Count - 1
            If Me.Datagrd.Rows(i).Cells(4).Value = "Full Day Leave" Or Datagrd.Rows(i).Cells(4).Value = "Absent" Or Datagrd.Rows(i).Cells(4).Value = "Maternity Leave" Then
                Me.Datagrd.Rows(i).ReadOnly = True
            ElseIf Me.Datagrd.Rows(i).Cells(3).Value = "Present" Then
                Me.Datagrd.Rows(i).ReadOnly = False
            End If

        Next
    End Sub

    'Private Sub Datagrd_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagrd.CellClick
    '    For i = 0 To Me.Datagrd.Rows.Count - 1

    '        If Me.Datagrd.Rows(i).Cells(5).Value = "Full Day Leave" Then
    '            MsgBox("hello")

    '        End If

    '    Next
    'End Sub

    'Private Sub RbIn_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If RbIn_All.Checked = True Then
    '        If Attd_Type = 5 Then

    '            For i = 0 To Me.Datagrd.Rows.Count - 1

    '                Me.Datagrd.Rows(i).Cells(8).Value = LblBrkTo.Text

    '            Next

    '        End If

    '    End If
    'End Sub

    'Private Sub RbIn_Sel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If RbIn_Sel.Checked = True Then
    '        If Attd_Type = 5 Then
    '            For i = 0 To Me.Datagrd.Rows.Count - 1
    '                If Me.Datagrd.Rows(i).Cells(0).Value = True Then
    '                    Me.Datagrd.Rows(i).Cells(8).Value = LblBrkTo.Text
    '                End If
    '            Next

    '        End If
    '    End If
    'End Sub

    Private Sub Datagrd_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagrd.CellDoubleClick

    End Sub

    Private Sub PnlReprtLate_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PnlReprtLate.Paint

    End Sub
End Class

#Region "Custom Calendar Classes"

Public Class CalendarColumn1
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New CalendarCell1())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell1)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell1")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

Public Class CalendarCell1
    Inherits DataGridViewTextBoxCell

    Public Sub New()

        Me.Style.Format = "HH:mm:ss"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)


        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As CalendarEditingControl1 = _
            CType(DataGridView.EditingControl, CalendarEditingControl1)
        'If Me.Value <> "" Then ctl.Value = CType(Me.Value, DateTime)

    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get

            Return GetType(CalendarEditingControl1)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get

            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            Return DateTime.Now
        End Get
    End Property

End Class

Class CalendarEditingControl1
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.CustomFormat = "HH:mm:ss"
        Me.Format = DateTimePickerFormat.Custom
        Me.ShowUpDown = True

    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Value
        End Get

        Set(ByVal value As Object)
            If TypeOf value Is String Then
                Me.Value = DateTime.Parse(CStr(value))
            End If
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Value

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey


        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return False
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit


    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)

    End Sub

End Class
#End Region
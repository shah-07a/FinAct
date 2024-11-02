Imports System.Data
Imports System.Data.SqlClient

Public Class FrmPayhed    'updated
    Inherits System.Windows.Forms.Form
    Dim cmdb As SqlCommandBuilder
    Dim da1 As SqlDataAdapter
    Dim ds As DataSet
    Dim adptr As SqlDataAdapter
    Dim arr_EmpFormulaid(100) As Integer
    Dim datgrid_flag As Boolean = False
    Dim mainhedrd As Boolean = False
    Dim nord_fg As Boolean = False
    Dim chkdupliitm As Boolean = False
    Dim chk_dupli_name As String = ""
    Dim count_formulaid As Integer = 0
    Dim str_CmbxPtype As String = ""
    Dim Pay_Head_Cmd As SqlCommand
    Dim One_slab_flag As Boolean = False
    Dim Pay_Head_Rdr As SqlDataReader
    Dim Pay_Head_Cmd1 As SqlCommand
    Dim ACT_DT_FETCH As Date
    Dim Pay_Head_Rdr1 As SqlDataReader
    Dim add_new_flag_rate As Boolean = False
    Dim fetch_rd_flag As Boolean = False
    Dim Indx As Integer
    Dim new_ph As Integer = 0
    Dim can_fg As Boolean = False
    Dim new_ph1 As Integer = 0
    Dim plus_flag As Boolean = False
    Dim flag As Boolean = False
    Dim Add_Edit_Flag As Boolean
    Dim Strtminyear As Date
    Dim delstatus As Boolean
    Dim count_rateid As Integer = 0
    Dim CmbxPtext As String
    Dim Edit_Srt As String
    Dim foc_falg As Boolean = False
    Dim ConCerId As Integer
    Dim listIndex As Integer
    Dim rateid As Integer
    Dim rate_arr(100) As Integer
    Dim rate_arr_count As Integer = 0
    Dim EmpFormulaid As Integer
    Dim Gruity As Boolean
    Dim x As Integer = 0
    Dim comboflag As Boolean = False
    Dim ACTUAL_MTD As String = ""
    Dim mainhid As Integer
    Dim id_ext As Integer
    Dim cnt_record As Integer = 0
    Dim enterflag As Boolean = False
    Dim Chek_VPF_Flag As Boolean = False
    Friend WithEvents BtnEdt As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Dim y As Integer = 0
    Dim Flag1 As Boolean
    Friend WithEvents CmbxType As System.Windows.Forms.ComboBox
    Friend WithEvents pnlPhSlab As System.Windows.Forms.Panel
    Friend WithEvents TxtToamt As System.Windows.Forms.TextBox
    Friend WithEvents TxtFromamt As System.Windows.Forms.TextBox
    Friend WithEvents LstvewPhSlab As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Lblcompu As System.Windows.Forms.Label
    Friend WithEvents TxtSlabrate As System.Windows.Forms.TextBox
    Friend WithEvents Lblphname As System.Windows.Forms.Label
    Friend WithEvents Lblhtype As System.Windows.Forms.Label
    Friend WithEvents Lblutype As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lblslipnm As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Lblmd As System.Windows.Forms.Label
    Friend WithEvents Lblcomtyp As System.Windows.Forms.Label
    Friend WithEvents CmbxPtype As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxUndrType As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxMoCal As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxComptype As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RbYn2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbYn1 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RbYn3 As System.Windows.Forms.RadioButton
    Friend WithEvents Lblid As System.Windows.Forms.Label
    Friend WithEvents Cmbxid As System.Windows.Forms.ComboBox
    Friend WithEvents Lblslpnm As System.Windows.Forms.Label
    Friend WithEvents Btndel As System.Windows.Forms.Button
    Friend WithEvents RbYn4 As System.Windows.Forms.RadioButton
    Friend WithEvents DataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Labenter As System.Windows.Forms.Label
    Friend WithEvents Labformula As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Radf2 As System.Windows.Forms.RadioButton
    Friend WithEvents Radf1 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Radf4 As System.Windows.Forms.RadioButton
    Friend WithEvents Radf3 As System.Windows.Forms.RadioButton
    Friend WithEvents Lblfor_ph As System.Windows.Forms.Label
    Friend WithEvents Lblgrdfor As System.Windows.Forms.Label
    Friend WithEvents Txtabove As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lblbonus As System.Windows.Forms.Label
    Friend WithEvents Txtbonus As System.Windows.Forms.TextBox
    Friend WithEvents Lblper As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Lefec As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Dim tb As TextBox
    Friend WithEvents Lstemp As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Dim maxslrymnth As Date
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Txtamt As System.Windows.Forms.TextBox
    Friend WithEvents labamt As System.Windows.Forms.Label
    Friend WithEvents Link3 As System.Windows.Forms.LinkLabel
    Friend WithEvents Link1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Link2 As System.Windows.Forms.LinkLabel
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblPF As System.Windows.Forms.Label
    Friend WithEvents TxtPF As System.Windows.Forms.TextBox
    Friend WithEvents LblPerc1 As System.Windows.Forms.Label
    Friend WithEvents LblPensn As System.Windows.Forms.Label
    Friend WithEvents TxtPens As System.Windows.Forms.TextBox
    Friend WithEvents LblPerc2 As System.Windows.Forms.Label
    Dim save_flag As Boolean = False





#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'AddWithValue any initialization after the InitializeComponent() call
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
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtPayhed As System.Windows.Forms.TextBox
    Friend WithEvents TxtApearName As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtPayhed = New System.Windows.Forms.TextBox
        Me.TxtApearName = New System.Windows.Forms.TextBox
        Me.BtnEdt = New System.Windows.Forms.Button
        Me.btnclose = New System.Windows.Forms.Button
        Me.CmbxType = New System.Windows.Forms.ComboBox
        Me.pnlPhSlab = New System.Windows.Forms.Panel
        Me.Txtabove = New System.Windows.Forms.TextBox
        Me.LstvewPhSlab = New System.Windows.Forms.ListView
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.TxtSlabrate = New System.Windows.Forms.TextBox
        Me.TxtToamt = New System.Windows.Forms.TextBox
        Me.TxtFromamt = New System.Windows.Forms.TextBox
        Me.Lblcompu = New System.Windows.Forms.Label
        Me.Lblphname = New System.Windows.Forms.Label
        Me.Lblhtype = New System.Windows.Forms.Label
        Me.Lblutype = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Lblslipnm = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Lblmd = New System.Windows.Forms.Label
        Me.Lblcomtyp = New System.Windows.Forms.Label
        Me.CmbxPtype = New System.Windows.Forms.ComboBox
        Me.CmbxUndrType = New System.Windows.Forms.ComboBox
        Me.CmbxMoCal = New System.Windows.Forms.ComboBox
        Me.CmbxComptype = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RbYn2 = New System.Windows.Forms.RadioButton
        Me.RbYn1 = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RbYn4 = New System.Windows.Forms.RadioButton
        Me.RbYn3 = New System.Windows.Forms.RadioButton
        Me.Lblid = New System.Windows.Forms.Label
        Me.Cmbxid = New System.Windows.Forms.ComboBox
        Me.Lblslpnm = New System.Windows.Forms.Label
        Me.Btndel = New System.Windows.Forms.Button
        Me.DataGrid = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Labenter = New System.Windows.Forms.Label
        Me.Labformula = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Radf2 = New System.Windows.Forms.RadioButton
        Me.Radf1 = New System.Windows.Forms.RadioButton
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Radf4 = New System.Windows.Forms.RadioButton
        Me.Radf3 = New System.Windows.Forms.RadioButton
        Me.Lblfor_ph = New System.Windows.Forms.Label
        Me.Lblgrdfor = New System.Windows.Forms.Label
        Me.Lblbonus = New System.Windows.Forms.Label
        Me.Txtbonus = New System.Windows.Forms.TextBox
        Me.Lblper = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Lefec = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.dtp1 = New System.Windows.Forms.DateTimePicker
        Me.Lstemp = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Txtamt = New System.Windows.Forms.TextBox
        Me.labamt = New System.Windows.Forms.Label
        Me.Link3 = New System.Windows.Forms.LinkLabel
        Me.Link1 = New System.Windows.Forms.LinkLabel
        Me.Link2 = New System.Windows.Forms.LinkLabel
        Me.LblPF = New System.Windows.Forms.Label
        Me.TxtPF = New System.Windows.Forms.TextBox
        Me.LblPerc1 = New System.Windows.Forms.Label
        Me.LblPensn = New System.Windows.Forms.Label
        Me.TxtPens = New System.Windows.Forms.TextBox
        Me.LblPerc2 = New System.Windows.Forms.Label
        Me.pnlPhSlab.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.Location = New System.Drawing.Point(84, 478)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 28)
        Me.BtnAdd.TabIndex = 20
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'TxtPayhed
        '
        Me.TxtPayhed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPayhed.Location = New System.Drawing.Point(141, 22)
        Me.TxtPayhed.MaxLength = 50
        Me.TxtPayhed.Name = "TxtPayhed"
        Me.TxtPayhed.Size = New System.Drawing.Size(184, 20)
        Me.TxtPayhed.TabIndex = 0
        '
        'TxtApearName
        '
        Me.TxtApearName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtApearName.Location = New System.Drawing.Point(141, 193)
        Me.TxtApearName.MaxLength = 50
        Me.TxtApearName.Name = "TxtApearName"
        Me.TxtApearName.Size = New System.Drawing.Size(167, 20)
        Me.TxtApearName.TabIndex = 6
        '
        'BtnEdt
        '
        Me.BtnEdt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnEdt.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtnEdt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEdt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdt.Location = New System.Drawing.Point(165, 478)
        Me.BtnEdt.Name = "BtnEdt"
        Me.BtnEdt.Size = New System.Drawing.Size(77, 28)
        Me.BtnEdt.TabIndex = 21
        Me.BtnEdt.Text = "&Find"
        Me.BtnEdt.UseVisualStyleBackColor = False
        '
        'btnclose
        '
        Me.btnclose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnclose.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Location = New System.Drawing.Point(326, 478)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(73, 28)
        Me.btnclose.TabIndex = 23
        Me.btnclose.Text = "&Close"
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'CmbxType
        '
        Me.CmbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxType.FormattingEnabled = True
        Me.CmbxType.Items.AddRange(New Object() {"Percentage", "Value"})
        Me.CmbxType.Location = New System.Drawing.Point(222, 4)
        Me.CmbxType.Name = "CmbxType"
        Me.CmbxType.Size = New System.Drawing.Size(108, 23)
        Me.CmbxType.TabIndex = 17
        '
        'pnlPhSlab
        '
        Me.pnlPhSlab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPhSlab.Controls.Add(Me.Txtabove)
        Me.pnlPhSlab.Controls.Add(Me.LstvewPhSlab)
        Me.pnlPhSlab.Controls.Add(Me.TxtSlabrate)
        Me.pnlPhSlab.Controls.Add(Me.TxtToamt)
        Me.pnlPhSlab.Controls.Add(Me.TxtFromamt)
        Me.pnlPhSlab.Controls.Add(Me.CmbxType)
        Me.pnlPhSlab.Enabled = False
        Me.pnlPhSlab.Location = New System.Drawing.Point(419, 210)
        Me.pnlPhSlab.Name = "pnlPhSlab"
        Me.pnlPhSlab.Size = New System.Drawing.Size(437, 245)
        Me.pnlPhSlab.TabIndex = 14
        '
        'Txtabove
        '
        Me.Txtabove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtabove.Location = New System.Drawing.Point(110, 5)
        Me.Txtabove.MaxLength = 29
        Me.Txtabove.Name = "Txtabove"
        Me.Txtabove.Size = New System.Drawing.Size(108, 20)
        Me.Txtabove.TabIndex = 16
        Me.Txtabove.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtabove.Visible = False
        '
        'LstvewPhSlab
        '
        Me.LstvewPhSlab.BackColor = System.Drawing.Color.LightCyan
        Me.LstvewPhSlab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstvewPhSlab.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.LstvewPhSlab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstvewPhSlab.ForeColor = System.Drawing.Color.Brown
        Me.LstvewPhSlab.FullRowSelect = True
        Me.LstvewPhSlab.GridLines = True
        Me.LstvewPhSlab.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstvewPhSlab.Location = New System.Drawing.Point(-1, 27)
        Me.LstvewPhSlab.MultiSelect = False
        Me.LstvewPhSlab.Name = "LstvewPhSlab"
        Me.LstvewPhSlab.Size = New System.Drawing.Size(436, 215)
        Me.LstvewPhSlab.TabIndex = 18
        Me.LstvewPhSlab.UseCompatibleStateImageBehavior = False
        Me.LstvewPhSlab.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "From Amount"
        Me.ColumnHeader2.Width = 108
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Up to Amount"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 108
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Slab Type"
        Me.ColumnHeader4.Width = 108
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Value Basis"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 108
        '
        'TxtSlabrate
        '
        Me.TxtSlabrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSlabrate.Location = New System.Drawing.Point(332, 4)
        Me.TxtSlabrate.MaxLength = 29
        Me.TxtSlabrate.Name = "TxtSlabrate"
        Me.TxtSlabrate.Size = New System.Drawing.Size(99, 20)
        Me.TxtSlabrate.TabIndex = 18
        Me.TxtSlabrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtToamt
        '
        Me.TxtToamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtToamt.Location = New System.Drawing.Point(112, 5)
        Me.TxtToamt.MaxLength = 29
        Me.TxtToamt.Name = "TxtToamt"
        Me.TxtToamt.Size = New System.Drawing.Size(108, 20)
        Me.TxtToamt.TabIndex = 16
        Me.TxtToamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtFromamt
        '
        Me.TxtFromamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFromamt.Location = New System.Drawing.Point(0, 4)
        Me.TxtFromamt.MaxLength = 29
        Me.TxtFromamt.Name = "TxtFromamt"
        Me.TxtFromamt.Size = New System.Drawing.Size(108, 20)
        Me.TxtFromamt.TabIndex = 15
        Me.TxtFromamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lblcompu
        '
        Me.Lblcompu.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblcompu.ForeColor = System.Drawing.Color.Navy
        Me.Lblcompu.Location = New System.Drawing.Point(419, 9)
        Me.Lblcompu.Name = "Lblcompu"
        Me.Lblcompu.Size = New System.Drawing.Size(400, 20)
        Me.Lblcompu.TabIndex = 1
        Me.Lblcompu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lblphname
        '
        Me.Lblphname.AutoSize = True
        Me.Lblphname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblphname.Location = New System.Drawing.Point(7, 25)
        Me.Lblphname.Name = "Lblphname"
        Me.Lblphname.Size = New System.Drawing.Size(97, 14)
        Me.Lblphname.TabIndex = 1
        Me.Lblphname.Text = "Pay Heads Name"
        '
        'Lblhtype
        '
        Me.Lblhtype.AutoSize = True
        Me.Lblhtype.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblhtype.Location = New System.Drawing.Point(7, 57)
        Me.Lblhtype.Name = "Lblhtype"
        Me.Lblhtype.Size = New System.Drawing.Size(86, 14)
        Me.Lblhtype.TabIndex = 1
        Me.Lblhtype.Text = "Pay Head Type"
        '
        'Lblutype
        '
        Me.Lblutype.AutoSize = True
        Me.Lblutype.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblutype.Location = New System.Drawing.Point(7, 90)
        Me.Lblutype.Name = "Lblutype"
        Me.Lblutype.Size = New System.Drawing.Size(70, 14)
        Me.Lblutype.TabIndex = 1
        Me.Lblutype.Text = "Under Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 14)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Appears In Pay-Slip"
        '
        'Lblslipnm
        '
        Me.Lblslipnm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblslipnm.Location = New System.Drawing.Point(776, -192)
        Me.Lblslipnm.Name = "Lblslipnm"
        Me.Lblslipnm.Size = New System.Drawing.Size(97, 28)
        Me.Lblslipnm.TabIndex = 1
        Me.Lblslipnm.Text = "Name to Appear In Pay-Slip "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 230)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 14)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Use of Gratuity "
        '
        'Lblmd
        '
        Me.Lblmd.AutoSize = True
        Me.Lblmd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblmd.Location = New System.Drawing.Point(7, 268)
        Me.Lblmd.Name = "Lblmd"
        Me.Lblmd.Size = New System.Drawing.Size(129, 14)
        Me.Lblmd.TabIndex = 1
        Me.Lblmd.Text = "Method of Calculation "
        '
        'Lblcomtyp
        '
        Me.Lblcomtyp.AutoSize = True
        Me.Lblcomtyp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblcomtyp.Location = New System.Drawing.Point(7, 303)
        Me.Lblcomtyp.Name = "Lblcomtyp"
        Me.Lblcomtyp.Size = New System.Drawing.Size(108, 14)
        Me.Lblcomtyp.TabIndex = 1
        Me.Lblcomtyp.Text = "Computation Type"
        '
        'CmbxPtype
        '
        Me.CmbxPtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxPtype.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxPtype.FormattingEnabled = True
        Me.CmbxPtype.Items.AddRange(New Object() {"Deduction From Employee", "Earnings For Employee", "Reimbursements to Employee", "Deduction From Employee For ESI", "Deduction From Employee For PF", "Employer's Contribution For ESI", "Employer's Contribution For PF", "Bonus", "Incentive"})
        Me.CmbxPtype.Location = New System.Drawing.Point(141, 53)
        Me.CmbxPtype.Name = "CmbxPtype"
        Me.CmbxPtype.Size = New System.Drawing.Size(246, 23)
        Me.CmbxPtype.TabIndex = 1
        '
        'CmbxUndrType
        '
        Me.CmbxUndrType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxUndrType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxUndrType.FormattingEnabled = True
        Me.CmbxUndrType.Items.AddRange(New Object() {"Direct Expenses", "Indirect Expenses"})
        Me.CmbxUndrType.Location = New System.Drawing.Point(141, 86)
        Me.CmbxUndrType.Name = "CmbxUndrType"
        Me.CmbxUndrType.Size = New System.Drawing.Size(234, 23)
        Me.CmbxUndrType.TabIndex = 2
        '
        'CmbxMoCal
        '
        Me.CmbxMoCal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxMoCal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxMoCal.FormattingEnabled = True
        Me.CmbxMoCal.Items.AddRange(New Object() {"As User Defined Value", "As Computed Value", "on Production/Performance value"})
        Me.CmbxMoCal.Location = New System.Drawing.Point(141, 265)
        Me.CmbxMoCal.Name = "CmbxMoCal"
        Me.CmbxMoCal.Size = New System.Drawing.Size(246, 23)
        Me.CmbxMoCal.TabIndex = 9
        '
        'CmbxComptype
        '
        Me.CmbxComptype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxComptype.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxComptype.FormattingEnabled = True
        Me.CmbxComptype.Items.AddRange(New Object() {"On Basic", "On Specified Formula"})
        Me.CmbxComptype.Location = New System.Drawing.Point(141, 299)
        Me.CmbxComptype.Name = "CmbxComptype"
        Me.CmbxComptype.Size = New System.Drawing.Size(246, 23)
        Me.CmbxComptype.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RbYn2)
        Me.Panel1.Controls.Add(Me.RbYn1)
        Me.Panel1.Location = New System.Drawing.Point(141, 153)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 26)
        Me.Panel1.TabIndex = 4
        '
        'RbYn2
        '
        Me.RbYn2.AutoSize = True
        Me.RbYn2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbYn2.Location = New System.Drawing.Point(96, 2)
        Me.RbYn2.Name = "RbYn2"
        Me.RbYn2.Size = New System.Drawing.Size(40, 19)
        Me.RbYn2.TabIndex = 5
        Me.RbYn2.Text = "No"
        Me.RbYn2.UseVisualStyleBackColor = True
        '
        'RbYn1
        '
        Me.RbYn1.AutoSize = True
        Me.RbYn1.Checked = True
        Me.RbYn1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbYn1.Location = New System.Drawing.Point(4, 2)
        Me.RbYn1.Name = "RbYn1"
        Me.RbYn1.Size = New System.Drawing.Size(46, 19)
        Me.RbYn1.TabIndex = 4
        Me.RbYn1.TabStop = True
        Me.RbYn1.Text = "Yes"
        Me.RbYn1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RbYn4)
        Me.Panel2.Controls.Add(Me.RbYn3)
        Me.Panel2.Location = New System.Drawing.Point(141, 227)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(144, 26)
        Me.Panel2.TabIndex = 7
        '
        'RbYn4
        '
        Me.RbYn4.AutoSize = True
        Me.RbYn4.Checked = True
        Me.RbYn4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbYn4.Location = New System.Drawing.Point(101, 4)
        Me.RbYn4.Name = "RbYn4"
        Me.RbYn4.Size = New System.Drawing.Size(40, 19)
        Me.RbYn4.TabIndex = 8
        Me.RbYn4.TabStop = True
        Me.RbYn4.Text = "No"
        Me.RbYn4.UseVisualStyleBackColor = True
        '
        'RbYn3
        '
        Me.RbYn3.AutoSize = True
        Me.RbYn3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbYn3.Location = New System.Drawing.Point(4, 4)
        Me.RbYn3.Name = "RbYn3"
        Me.RbYn3.Size = New System.Drawing.Size(46, 19)
        Me.RbYn3.TabIndex = 7
        Me.RbYn3.Text = "Yes"
        Me.RbYn3.UseVisualStyleBackColor = True
        '
        'Lblid
        '
        Me.Lblid.AutoSize = True
        Me.Lblid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblid.Location = New System.Drawing.Point(11, 384)
        Me.Lblid.Name = "Lblid"
        Me.Lblid.Size = New System.Drawing.Size(109, 15)
        Me.Lblid.TabIndex = 16
        Me.Lblid.Text = "Select a Pay Head"
        '
        'Cmbxid
        '
        Me.Cmbxid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxid.DropDownWidth = 50
        Me.Cmbxid.Enabled = False
        Me.Cmbxid.FormattingEnabled = True
        Me.Cmbxid.Location = New System.Drawing.Point(9, 403)
        Me.Cmbxid.Name = "Cmbxid"
        Me.Cmbxid.Size = New System.Drawing.Size(142, 21)
        Me.Cmbxid.TabIndex = 19
        '
        'Lblslpnm
        '
        Me.Lblslpnm.AutoSize = True
        Me.Lblslpnm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblslpnm.Location = New System.Drawing.Point(7, 192)
        Me.Lblslpnm.Name = "Lblslpnm"
        Me.Lblslpnm.Size = New System.Drawing.Size(89, 15)
        Me.Lblslpnm.TabIndex = 19
        Me.Lblslpnm.Text = "Pay-Slip Name"
        '
        'Btndel
        '
        Me.Btndel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btndel.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Btndel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btndel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btndel.Location = New System.Drawing.Point(248, 478)
        Me.Btndel.Name = "Btndel"
        Me.Btndel.Size = New System.Drawing.Size(72, 28)
        Me.Btndel.TabIndex = 22
        Me.Btndel.Text = "&Delete"
        Me.Btndel.UseVisualStyleBackColor = False
        '
        'DataGrid
        '
        Me.DataGrid.AllowUserToAddRows = False
        Me.DataGrid.AllowUserToResizeColumns = False
        Me.DataGrid.AllowUserToResizeRows = False
        Me.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.DataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGrid.Location = New System.Drawing.Point(419, 38)
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGrid.Size = New System.Drawing.Size(328, 149)
        Me.DataGrid.TabIndex = 13
        Me.DataGrid.Visible = False
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.Width = 30
        '
        'Column2
        '
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "Pay Head Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column3.HeaderText = "Type"
        Me.Column3.Items.AddRange(New Object() {"Add", "Minus"})
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column4
        '
        Me.Column4.HeaderText = "id"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 5
        '
        'Labenter
        '
        Me.Labenter.BackColor = System.Drawing.Color.LightCyan
        Me.Labenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Labenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labenter.ForeColor = System.Drawing.Color.Blue
        Me.Labenter.Location = New System.Drawing.Point(157, 400)
        Me.Labenter.Name = "Labenter"
        Me.Labenter.Size = New System.Drawing.Size(151, 21)
        Me.Labenter.TabIndex = 67
        Me.Labenter.Text = " Press  enter  key to continue"
        Me.Labenter.Visible = False
        '
        'Labformula
        '
        Me.Labformula.AutoSize = True
        Me.Labformula.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labformula.Location = New System.Drawing.Point(11, 338)
        Me.Labformula.Name = "Labformula"
        Me.Labformula.Size = New System.Drawing.Size(82, 14)
        Me.Labformula.TabIndex = 68
        Me.Labformula.Text = "Formula Type"
        Me.Labformula.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Radf2)
        Me.Panel3.Controls.Add(Me.Radf1)
        Me.Panel3.Location = New System.Drawing.Point(144, 333)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(234, 29)
        Me.Panel3.TabIndex = 10
        Me.Panel3.Visible = False
        '
        'Radf2
        '
        Me.Radf2.AutoSize = True
        Me.Radf2.Checked = True
        Me.Radf2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radf2.Location = New System.Drawing.Point(85, 3)
        Me.Radf2.Name = "Radf2"
        Me.Radf2.Size = New System.Drawing.Size(146, 19)
        Me.Radf2.TabIndex = 11
        Me.Radf2.TabStop = True
        Me.Radf2.Text = "Compound(stepwise)"
        Me.Radf2.UseVisualStyleBackColor = True
        '
        'Radf1
        '
        Me.Radf1.AutoSize = True
        Me.Radf1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radf1.Location = New System.Drawing.Point(3, 2)
        Me.Radf1.Name = "Radf1"
        Me.Radf1.Size = New System.Drawing.Size(74, 19)
        Me.Radf1.TabIndex = 10
        Me.Radf1.Text = "Flat Rate"
        Me.Radf1.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Radf4)
        Me.Panel4.Controls.Add(Me.Radf3)
        Me.Panel4.Location = New System.Drawing.Point(141, 333)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(246, 29)
        Me.Panel4.TabIndex = 11
        Me.Panel4.Visible = False
        '
        'Radf4
        '
        Me.Radf4.AutoSize = True
        Me.Radf4.Checked = True
        Me.Radf4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radf4.Location = New System.Drawing.Point(126, 3)
        Me.Radf4.Name = "Radf4"
        Me.Radf4.Size = New System.Drawing.Size(117, 19)
        Me.Radf4.TabIndex = 12
        Me.Radf4.TabStop = True
        Me.Radf4.Text = "Achieved Target"
        Me.Radf4.UseVisualStyleBackColor = True
        '
        'Radf3
        '
        Me.Radf3.AutoSize = True
        Me.Radf3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radf3.Location = New System.Drawing.Point(3, 2)
        Me.Radf3.Name = "Radf3"
        Me.Radf3.Size = New System.Drawing.Size(112, 19)
        Me.Radf3.TabIndex = 11
        Me.Radf3.Text = "Earned Amount"
        Me.Radf3.UseVisualStyleBackColor = True
        '
        'Lblfor_ph
        '
        Me.Lblfor_ph.BackColor = System.Drawing.Color.LightCyan
        Me.Lblfor_ph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblfor_ph.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblfor_ph.ForeColor = System.Drawing.Color.Red
        Me.Lblfor_ph.Location = New System.Drawing.Point(141, 365)
        Me.Lblfor_ph.Name = "Lblfor_ph"
        Me.Lblfor_ph.Size = New System.Drawing.Size(242, 21)
        Me.Lblfor_ph.TabIndex = 69
        Me.Lblfor_ph.Visible = False
        '
        'Lblgrdfor
        '
        Me.Lblgrdfor.BackColor = System.Drawing.Color.LightCyan
        Me.Lblgrdfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblgrdfor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblgrdfor.ForeColor = System.Drawing.Color.Navy
        Me.Lblgrdfor.Location = New System.Drawing.Point(10, 364)
        Me.Lblgrdfor.Name = "Lblgrdfor"
        Me.Lblgrdfor.Size = New System.Drawing.Size(115, 21)
        Me.Lblgrdfor.TabIndex = 70
        Me.Lblgrdfor.Text = "Specified Formula "
        Me.Lblgrdfor.Visible = False
        '
        'Lblbonus
        '
        Me.Lblbonus.AutoSize = True
        Me.Lblbonus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblbonus.Location = New System.Drawing.Point(8, 154)
        Me.Lblbonus.Name = "Lblbonus"
        Me.Lblbonus.Size = New System.Drawing.Size(69, 14)
        Me.Lblbonus.TabIndex = 71
        Me.Lblbonus.Text = "Bonus Rate"
        Me.Lblbonus.Visible = False
        '
        'Txtbonus
        '
        Me.Txtbonus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtbonus.Location = New System.Drawing.Point(3, 8)
        Me.Txtbonus.MaxLength = 50
        Me.Txtbonus.Name = "Txtbonus"
        Me.Txtbonus.Size = New System.Drawing.Size(61, 20)
        Me.Txtbonus.TabIndex = 4
        '
        'Lblper
        '
        Me.Lblper.AutoSize = True
        Me.Lblper.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblper.Location = New System.Drawing.Point(70, 11)
        Me.Lblper.Name = "Lblper"
        Me.Lblper.Size = New System.Drawing.Size(16, 14)
        Me.Lblper.TabIndex = 73
        Me.Lblper.Text = "%"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Txtbonus)
        Me.Panel5.Controls.Add(Me.Lblper)
        Me.Panel5.Location = New System.Drawing.Point(138, 146)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(97, 31)
        Me.Panel5.TabIndex = 4
        Me.Panel5.Visible = False
        '
        'Lefec
        '
        Me.Lefec.AutoSize = True
        Me.Lefec.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lefec.Location = New System.Drawing.Point(7, 123)
        Me.Lefec.Name = "Lefec"
        Me.Lefec.Size = New System.Drawing.Size(86, 14)
        Me.Lefec.TabIndex = 72
        Me.Lefec.Text = "Effective From"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.dtp1)
        Me.Panel6.Location = New System.Drawing.Point(138, 121)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(118, 26)
        Me.Panel6.TabIndex = 3
        '
        'dtp1
        '
        Me.dtp1.CustomFormat = "MMMM/yyyy"
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp1.Location = New System.Drawing.Point(3, 3)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(115, 20)
        Me.dtp1.TabIndex = 79
        '
        'Lstemp
        '
        Me.Lstemp.BackColor = System.Drawing.Color.LightCyan
        Me.Lstemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lstemp.CheckBoxes = True
        Me.Lstemp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader6, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.Lstemp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lstemp.ForeColor = System.Drawing.Color.Brown
        Me.Lstemp.FullRowSelect = True
        Me.Lstemp.GridLines = True
        Me.Lstemp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.Lstemp.Location = New System.Drawing.Point(384, -6)
        Me.Lstemp.MultiSelect = False
        Me.Lstemp.Name = "Lstemp"
        Me.Lstemp.Size = New System.Drawing.Size(366, 134)
        Me.Lstemp.TabIndex = 19
        Me.Lstemp.UseCompatibleStateImageBehavior = False
        Me.Lstemp.View = System.Windows.Forms.View.Details
        Me.Lstemp.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Department"
        Me.ColumnHeader7.Width = 120
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Designation"
        Me.ColumnHeader8.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Id"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "phed"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Mainid"
        Me.ColumnHeader10.Width = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Txtamt)
        Me.Panel7.Location = New System.Drawing.Point(136, 294)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(97, 31)
        Me.Panel7.TabIndex = 10
        Me.Panel7.Visible = False
        '
        'Txtamt
        '
        Me.Txtamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtamt.Location = New System.Drawing.Point(5, 3)
        Me.Txtamt.MaxLength = 7
        Me.Txtamt.Name = "Txtamt"
        Me.Txtamt.Size = New System.Drawing.Size(61, 20)
        Me.Txtamt.TabIndex = 10
        '
        'labamt
        '
        Me.labamt.AutoSize = True
        Me.labamt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labamt.Location = New System.Drawing.Point(9, 303)
        Me.labamt.Name = "labamt"
        Me.labamt.Size = New System.Drawing.Size(51, 14)
        Me.labamt.TabIndex = 75
        Me.labamt.Text = "Amount"
        Me.labamt.Visible = False
        '
        'Link3
        '
        Me.Link3.AutoSize = True
        Me.Link3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link3.ForeColor = System.Drawing.Color.Navy
        Me.Link3.LinkColor = System.Drawing.Color.Blue
        Me.Link3.Location = New System.Drawing.Point(383, 557)
        Me.Link3.Name = "Link3"
        Me.Link3.Size = New System.Drawing.Size(74, 18)
        Me.Link3.TabIndex = 76
        Me.Link3.TabStop = True
        Me.Link3.Text = "Select All"
        Me.Link3.Visible = False
        '
        'Link1
        '
        Me.Link1.AutoSize = True
        Me.Link1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link1.ForeColor = System.Drawing.Color.Navy
        Me.Link1.LinkColor = System.Drawing.Color.Blue
        Me.Link1.Location = New System.Drawing.Point(244, 155)
        Me.Link1.Name = "Link1"
        Me.Link1.Size = New System.Drawing.Size(74, 18)
        Me.Link1.TabIndex = 77
        Me.Link1.TabStop = True
        Me.Link1.Text = "Select All"
        Me.Link1.Visible = False
        '
        'Link2
        '
        Me.Link2.AutoSize = True
        Me.Link2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link2.ForeColor = System.Drawing.Color.Navy
        Me.Link2.LinkColor = System.Drawing.Color.Blue
        Me.Link2.Location = New System.Drawing.Point(251, 303)
        Me.Link2.Name = "Link2"
        Me.Link2.Size = New System.Drawing.Size(74, 18)
        Me.Link2.TabIndex = 78
        Me.Link2.TabStop = True
        Me.Link2.Text = "Select All"
        Me.Link2.Visible = False
        '
        'LblPF
        '
        Me.LblPF.AutoSize = True
        Me.LblPF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPF.Location = New System.Drawing.Point(8, 192)
        Me.LblPF.Name = "LblPF"
        Me.LblPF.Size = New System.Drawing.Size(55, 14)
        Me.LblPF.TabIndex = 80
        Me.LblPF.Text = "PF Share"
        Me.LblPF.Visible = False
        '
        'TxtPF
        '
        Me.TxtPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPF.Location = New System.Drawing.Point(141, 193)
        Me.TxtPF.MaxLength = 50
        Me.TxtPF.Name = "TxtPF"
        Me.TxtPF.Size = New System.Drawing.Size(61, 20)
        Me.TxtPF.TabIndex = 79
        Me.TxtPF.Visible = False
        '
        'LblPerc1
        '
        Me.LblPerc1.AutoSize = True
        Me.LblPerc1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPerc1.Location = New System.Drawing.Point(208, 196)
        Me.LblPerc1.Name = "LblPerc1"
        Me.LblPerc1.Size = New System.Drawing.Size(16, 14)
        Me.LblPerc1.TabIndex = 81
        Me.LblPerc1.Text = "%"
        Me.LblPerc1.Visible = False
        '
        'LblPensn
        '
        Me.LblPensn.AutoSize = True
        Me.LblPensn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPensn.Location = New System.Drawing.Point(8, 231)
        Me.LblPensn.Name = "LblPensn"
        Me.LblPensn.Size = New System.Drawing.Size(87, 14)
        Me.LblPensn.TabIndex = 83
        Me.LblPensn.Text = "Pension Share"
        Me.LblPensn.Visible = False
        '
        'TxtPens
        '
        Me.TxtPens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPens.Location = New System.Drawing.Point(141, 232)
        Me.TxtPens.MaxLength = 50
        Me.TxtPens.Name = "TxtPens"
        Me.TxtPens.ReadOnly = True
        Me.TxtPens.Size = New System.Drawing.Size(61, 20)
        Me.TxtPens.TabIndex = 82
        Me.TxtPens.Visible = False
        '
        'LblPerc2
        '
        Me.LblPerc2.AutoSize = True
        Me.LblPerc2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPerc2.Location = New System.Drawing.Point(208, 235)
        Me.LblPerc2.Name = "LblPerc2"
        Me.LblPerc2.Size = New System.Drawing.Size(16, 14)
        Me.LblPerc2.TabIndex = 84
        Me.LblPerc2.Text = "%"
        Me.LblPerc2.Visible = False
        '
        'FrmPayhed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(866, 509)
        Me.Controls.Add(Me.LblPensn)
        Me.Controls.Add(Me.TxtPens)
        Me.Controls.Add(Me.LblPF)
        Me.Controls.Add(Me.LblPerc2)
        Me.Controls.Add(Me.TxtPF)
        Me.Controls.Add(Me.LblPerc1)
        Me.Controls.Add(Me.Link2)
        Me.Controls.Add(Me.Link1)
        Me.Controls.Add(Me.Link3)
        Me.Controls.Add(Me.labamt)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Lstemp)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Lefec)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Lblbonus)
        Me.Controls.Add(Me.Lblgrdfor)
        Me.Controls.Add(Me.Lblfor_ph)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Labformula)
        Me.Controls.Add(Me.DataGrid)
        Me.Controls.Add(Me.Labenter)
        Me.Controls.Add(Me.Btndel)
        Me.Controls.Add(Me.Lblslpnm)
        Me.Controls.Add(Me.Cmbxid)
        Me.Controls.Add(Me.Lblid)
        Me.Controls.Add(Me.pnlPhSlab)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CmbxComptype)
        Me.Controls.Add(Me.CmbxMoCal)
        Me.Controls.Add(Me.CmbxUndrType)
        Me.Controls.Add(Me.CmbxPtype)
        Me.Controls.Add(Me.TxtApearName)
        Me.Controls.Add(Me.TxtPayhed)
        Me.Controls.Add(Me.Lblcomtyp)
        Me.Controls.Add(Me.Lblmd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Lblslipnm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Lblutype)
        Me.Controls.Add(Me.Lblhtype)
        Me.Controls.Add(Me.Lblcompu)
        Me.Controls.Add(Me.Lblphname)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.BtnEdt)
        Me.Controls.Add(Me.BtnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmPayhed"
        Me.Text = "Pay Heads"
        Me.pnlPhSlab.ResumeLayout(False)
        Me.pnlPhSlab.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmPayhed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 0
        Me.Top = 0
        Me.Width = 413
        Me.Height = 413
        CheckAcess_Btn_frm(BtnAdd, BtnEdt, Btndel)
        Lblid.Visible = False
        Cmbxid.Visible = False
        Btndel.Enabled = False
        If CmbxComptype.SelectedIndex = -1 Then
            CmbxComptype.SelectedIndex = 0
        End If
        If CmbxPtype.SelectedIndex = -1 Then
            CmbxPtype.SelectedIndex = 0
        End If
        If CmbxMoCal.SelectedIndex = -1 Then
            CmbxMoCal.SelectedIndex = 0
        End If
        If CmbxUndrType.SelectedIndex = -1 Then
            CmbxUndrType.SelectedIndex = 0
        End If
        enable_flse()
        fetch_Costrtdate()
        dtp1.MinDate = Strtminyear
        BtnAdd.Focus()

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
                BtnnSave.Location = New System.Drawing.Point(245, 432)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
            Case "DataEntry"
                BtnnSave.Enabled = True
                BtnnSave.Location = New System.Drawing.Point(245, 432)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
            Case "PayRoll"
                BtnnSave.Enabled = True
                BtnnSave.Location = New System.Drawing.Point(245, 432)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
        End Select
    End Sub

    Private Sub CmbxMoCal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxMoCal.GotFocus
       
        If CmbxPtype.SelectedIndex = 8 Then
            CmbxMoCal.Items.Clear()
            CmbxMoCal.Items.Add("As User Defined Value")
            CmbxMoCal.Items.Add("on Production/Performance value")
        ElseIf CmbxPtype.SelectedIndex = 8 Then
            CmbxMoCal.Items.Clear()
            CmbxMoCal.Items.Add("As User Defined Value")
            CmbxMoCal.Items.Add("As Computed Value")
            CmbxMoCal.Items.Add("on Production/Performance value")
        End If
        If CmbxMoCal.SelectedIndex = -1 Then
            CmbxMoCal.SelectedIndex = 0
        End If
        CmbxMoCal.DroppedDown = True

    End Sub

    Private Sub CmbxMoCal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxMoCal.KeyDown

        If e.KeyCode = Keys.Enter Then
            CmbxMoCal_LostFocus(sender, e)

            If CmbxMoCal.SelectedIndex = 0 Then
                labamt.Visible = True
                Panel7.Visible = True
                Txtamt.Focus()
            ElseIf CmbxMoCal.SelectedIndex = 1 Then
                CmbxComptype.Focus()
            ElseIf CmbxMoCal.SelectedIndex = 2 Then
                CmbxComptype.Focus()
            End If
        End If

    End Sub

    Private Sub CmbxMoCal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxMoCal.LostFocus

        If CmbxPtype.SelectedIndex = 8 Then
           
            If CmbxMoCal.SelectedIndex = 0 Then
                labamt.Visible = True
                Panel7.Visible = True
                CmbxComptype.Visible = False
                Labformula.Visible = False
                Labenter.Visible = False
                Me.pnlPhSlab.Visible = False
                Panel4.Visible = False
                Panel3.Visible = False
                DataGrid.Visible = False
                Me.Width = 413
                Lblcomtyp.Visible = False

            ElseIf CmbxMoCal.SelectedIndex = 1 Then
                labamt.Visible = False
                Panel7.Visible = False
                Me.Height = 500

                If Add_Edit_Flag = True And CmbxMoCal.Text <> "As User Defined Value" Then
                    Labformula.Visible = True
                    Panel4.Visible = False
                    Panel3.Visible = True
                    Radf2.Checked = True
                    Me.Width = 872 '957
                    Me.pnlPhSlab.Enabled = True
                    Me.pnlPhSlab.Visible = True
                    Me.pnlPhSlab.Location = New System.Drawing.Point(419, 38)
                    Me.Lblcompu.Text = Me.CmbxComptype.Text
                    DataGrid.Visible = False
                    TxtFromamt.Focus()
                End If
                'Lblcomtyp.Visible = True
                'Me.Lblcomtyp.Location = New System.Drawing.Point(7, 297)
                'CmbxComptype.Visible = True
                'Me.CmbxComptype.Location = New System.Drawing.Point(141, 297)
                ' CmbxComptype.Focus()

                End If


        ElseIf CmbxPtype.SelectedIndex <> 8 Then

            If CmbxMoCal.SelectedIndex = 0 Then
                labamt.Visible = True
                Panel7.Visible = True
                CmbxComptype.Visible = False
                Labformula.Visible = False
                Labenter.Visible = False
                Me.pnlPhSlab.Visible = False
                Panel4.Visible = False
                Panel3.Visible = False
                DataGrid.Visible = False
                Me.Width = 413
                Lblcomtyp.Visible = False

            ElseIf CmbxMoCal.SelectedIndex = 1 Then
                labamt.Visible = False
                Panel7.Visible = False
                Me.Height = 520
                Lblcomtyp.Visible = True
                Me.Lblcomtyp.Location = New System.Drawing.Point(7, 297)
                CmbxComptype.Visible = True
                Me.CmbxComptype.Location = New System.Drawing.Point(141, 297)
                'CmbxComptype.Focus()

            ElseIf CmbxMoCal.SelectedIndex = 2 Then
                labamt.Visible = False
                Panel7.Visible = False
                Me.Height = 520
                Lblcomtyp.Visible = True
                Me.Lblcomtyp.Location = New System.Drawing.Point(7, 297)
                CmbxComptype.Visible = True
                Me.CmbxComptype.Location = New System.Drawing.Point(141, 297)
                ' CmbxComptype.Focus()

            End If
        End If

    End Sub
    Private Sub CmbxComptype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxComptype.GotFocus

        If CmbxComptype.SelectedIndex = -1 Then
            CmbxComptype.SelectedIndex = 0
        End If
        CmbxComptype.DroppedDown = True

    End Sub
    Private Sub CmbxComptype_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxComptype.KeyDown

        If e.KeyCode = Keys.Enter Then
            CmbxComptype_SelectedIndexChanged(sender, e)
        End If

    End Sub
    Private Sub TxtPayhed_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPayhed.KeyDown

        If e.KeyCode = Keys.Enter Then
            CmbxPtype.Focus()
        End If

    End Sub
    Private Sub CmbxPtype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPtype.GotFocus
        '  Flag1 = False

        If CmbxPtype.Items.Count > 0 Then
            If CmbxPtype.SelectedIndex = -1 Then
                CmbxPtype.SelectedIndex = 0
            End If
        End If
        If Flag1 = True Then
            Flag1 = False
            Exit Sub
        End If
        CmbxPtype.DroppedDown = True

    End Sub

    Private Sub CmbxPtype_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxPtype.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Flag1 = False Then
                CmbxPtype_Leave(sender, e)
            End If
            If Flag1 = False Then
                CmbxUndrType.Focus()
            Else
                Flag1 = False
                CmbxPtype.Focus()
            End If
        End If

    End Sub
    Private Sub CmbxUndrType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxUndrType.GotFocus

        CmbxUndrType.DroppedDown = True

    End Sub
    Private Sub CmbxUndrType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxUndrType.KeyDown

        If e.KeyCode = Keys.Enter Then
            dtp1.Focus()
        End If

    End Sub
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click

        Dim delconfrm As String
        delconfrm = MsgBox("Are you sure to exit", MsgBoxStyle.YesNo, "Close Section")
        If delconfrm = vbYes Then
            Me.Close()
        End If

    End Sub
    Private Sub Chk_val()

        With TxtPayhed
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxPtype
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxUndrType
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxMoCal
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        If Panel5.Visible = True Then
            With Txtbonus
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    Indx += 1
                Else
                    .BackColor = Color.White
                End If
            End With

        End If
        If CmbxComptype.Visible = True Then
            With CmbxComptype
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    Indx += 1
                Else
                    .BackColor = Color.White
                End If
            End With
        End If
        If CmbxComptype.Visible = True Then
            'If CmbxComptype.Text = "On Basic" Or CmbxMoCal.Text = "on Production/Performance value" Then
            If pnlPhSlab.Visible = True Then
                With LstvewPhSlab
                    If LstvewPhSlab.Items.Count = 0 Then
                        Chk_list_Items()
                        Indx += 1
                        TxtToamt.Focus()
                        TxtToamt.SelectAll()
                    End If
                    If LstvewPhSlab.Items.Count > 0 Then
                        Dim i As Integer = 0
                        Dim Sublst As ListViewItem
                        Sublst = LstvewPhSlab.Items(0)
                        While i < LstvewPhSlab.Items.Count
                            If LstvewPhSlab.Items(i).SubItems(1).Text = "Above" Then
                                Indx = 0
                                Exit While
                            Else
                                Indx = 1
                            End If
                            i += 1

                        End While
                        If CmbxPtype.SelectedIndex = 3 Or CmbxPtype.SelectedIndex = 4 Then '|+
                            If LstvewPhSlab.Items.Count = 1 Then
                                One_slab_flag = True
                            End If
                        End If
                        If Indx = 1 And One_slab_flag = False Then
                            Txtabove.Visible = True
                            Txtabove.Text = "Above"
                            MsgBox("Enter above slab", MsgBoxStyle.Information, "Alert")
                            TxtToamt.Text = 0
                            Dim counter As Integer
                            Dim total As Integer
                            total = LstvewPhSlab.Items.Count
                            counter = 0
                            While counter < total
                                If LstvewPhSlab.Items(counter).SubItems(1).Text <> "" Then
                                    If LstvewPhSlab.Items(counter).SubItems(1).Text <> "Above" Then
                                        TxtFromamt.Text = CDbl(LstvewPhSlab.Items(counter).SubItems(1).Text) + 1
                                    End If
                                End If
                                counter += 1
                            End While
                            CmbxType.Focus()
                        ElseIf Indx = 1 And One_slab_flag = True Then
                            Indx = 0
                            If LstvewPhSlab.Items.Count = 0 Then
                                Chk_list_Items()
                                Indx += 1
                                TxtToamt.Focus()
                                TxtToamt.SelectAll()
                            End If
                        End If
                    End If
                End With
            End If
        End If
        If DataGrid.Visible = True And CmbxComptype.Text = "On Specified Formula" Then
            Dim i As Integer = 0
            Dim total_sel As Integer = 0
            While i < DataGrid.Rows.Count
                If DataGrid.Rows(i).Cells(0).Value = "True" Then
                    total_sel += 1
                End If
                i += 1
            End While
            If total_sel = 0 Then
                Indx += 1
                MsgBox("Select the PayHead from list", MsgBoxStyle.Information, "Alert")
                DataGrid.Focus()
                DataGrid.Rows(0).Cells(1).Selected = True
            End If
        End If

        If Panel7.Visible = True Then
            If Txtamt.Text = "" Then
                Txtamt.BackColor = Color.PapayaWhip
                Txtamt.Focus()
                Indx += 1
            Else
                Txtamt.BackColor = Color.White
            End If
        End If
        If TxtPF.Visible = True Then
            If TxtPF.Text = "" Then
                TxtPF.BackColor = Color.PapayaWhip
                TxtPF.Focus()
                Indx += 1
            Else
                TxtPF.BackColor = Color.White
            End If
        End If

    End Sub

    Private Sub Save_VPF()

        Try
            If Add_Edit_Flag = True Then
                Pay_Head_Cmd = New SqlCommand("FinAct_PayHead_Insert", FinActConn)
                Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadAdddt", Now)
                Pay_Head_Cmd.Parameters.AddWithValue("@Pheadaddusrid", Current_UsrId)

                Pay_Head_Cmd.Parameters.AddWithValue("@PheadName", "VPF")
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadType", "DEEmpVPF")
                Pay_Head_Cmd.Parameters.AddWithValue("@PUnderType", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadSlipname", "VPF")
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadGrauty", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadCalmtd", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadComp", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadRate", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@PFshare", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@Pensnshare", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@PhFormulaType", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@PhEfecdt", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadDelstatus", 0)

            End If


            Pay_Head_Cmd.ExecuteNonQuery()
        Catch EX As Exception
            MsgBox(EX.Message)

        Finally

            Pay_Head_Cmd = Nothing

        End Try



    End Sub

    Private Sub Chek_VPF()

        Try
            Pay_Head_Cmd = New SqlCommand("Select PheadId from FinactPayHead where PheadName='VPF'", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader

            Pay_Head_Rdr.Read()
            If Pay_Head_Rdr.HasRows = True Then

                Chek_VPF_Flag = True

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Pay_Head_Rdr.HasRows = False Then

                Chek_VPF_Flag = False

            End If

            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing
        End Try


    End Sub

    Private Sub Saverrecord()

        Dim counter As Integer
        Dim graty As String
        Dim total As Integer
        Dim total_sel As Integer = 0
        Dim i As Integer = 0
        Dim strtlop As Integer = 0
        Dim gridrows As Integer = 0
        Dim Slipname As String
        Dim delstatus1 As Integer = 0
        delstatus1 = 0
        fetch_srt_names()
        If RbYn3.Checked = True Then
            graty = "Yes"
        Else
            graty = "No"
        End If
        Try
            '  Fetch_Concrnid()
            If Add_Edit_Flag = True Then
                Pay_Head_Cmd = New SqlCommand("FinAct_PayHead_Insert", FinActConn)
                Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadAdddt", Now)
                Pay_Head_Cmd.Parameters.AddWithValue("@Pheadaddusrid", Current_UsrId)
            ElseIf Add_Edit_Flag = False Then

                fetch_head_id()
                Pay_Head_Cmd = New SqlCommand("FinAct_PayHead_Update", FinActConn)
                Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadEdtdt", Now)
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadEdtusrid", Current_UsrId)
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadId", mainhid)
            End If
            Pay_Head_Cmd.Parameters.AddWithValue("@PheadName", Trim(TxtPayhed.Text))
            Pay_Head_Cmd.Parameters.AddWithValue("@PheadType", Trim(CmbxPtext))

            '=============Bonus,Esi,Pf case
            If Trim(CmbxPtext) = Trim("Employer's Contribution For ESI") Or Trim(CmbxPtext) = Trim("Employer's Contribution For PF") Or Trim(CmbxPtext) = Trim("Bonus") Then
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadRate", CDbl(Txtbonus.Text))
                Pay_Head_Cmd.Parameters.AddWithValue("@PUnderType", CmbxUndrType.Text)
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadSlipname", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadGrauty", "No")
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadCalmtd", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadComp", "")
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadDelStatus", delstatus1)
                Pay_Head_Cmd.Parameters.AddWithValue("@PhFormulaType", "")

                '############################
                Dim dtproc1 As Date
                dtproc1 = DateSerial(Year(dtp1.Value.Date), Month(dtp1.Value.Date), 1)
                Pay_Head_Cmd.Parameters.AddWithValue("@PhEfecdt", dtproc1.Date)

                If Trim(CmbxPtext) = Trim("Employer's Contribution For PF") Then
                    Pay_Head_Cmd.Parameters.AddWithValue("@PFshare", TxtPF.Text)
                    Pay_Head_Cmd.Parameters.AddWithValue("@Pensnshare", TxtPens.Text)
                Else
                    Pay_Head_Cmd.Parameters.AddWithValue("@PFshare", 0)
                    Pay_Head_Cmd.Parameters.AddWithValue("@Pensnshare", 0)
                End If

                Pay_Head_Cmd.ExecuteNonQuery()
                Pay_Head_Cmd = Nothing




                MsgBox("Record has been Saved Successfully")
                If Add_Edit_Flag = True Then
                    Exit Sub
                ElseIf Add_Edit_Flag <> True Then
                    Fetch_Concrnid()
                    If ConCerId <> 0 Then
                        Try
                            Pay_Head_Cmd = New SqlCommand("Finact_Slabrate_Delete", FinActConn)
                            Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                            Pay_Head_Cmd.Parameters.AddWithValue("@Sratedelusrid", Current_UsrId)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateDeldt", Now)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateDelStatus", 1)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateConId", ConCerId)
                            Pay_Head_Cmd.ExecuteNonQuery()
                        Catch EX As Exception
                            MsgBox(EX.Message)
                        Finally
                            Pay_Head_Cmd = Nothing
                        End Try
                        Try
                            Pay_Head_Cmd = New SqlCommand("FinAct_PayHeadFormula_Delete", FinActConn)
                            Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                            Pay_Head_Cmd.Parameters.AddWithValue("@EmpDelStatus", 1)
                            Pay_Head_Cmd.Parameters.AddWithValue("@PayheadConId", ConCerId)
                            Pay_Head_Cmd.Parameters.AddWithValue("@EmpPhDeldt", Now)
                            Pay_Head_Cmd.ExecuteNonQuery()
                        Catch EX As Exception
                            MsgBox(EX.Message)
                        Finally
                            Pay_Head_Cmd = Nothing
                        End Try
                        Exit Sub
                    End If
                End If
            End If '=============end  Bonus,Esi,Pf case
            If CmbxMoCal.Text = "As User Defined Value" Then
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadRate", CDbl(Txtamt.Text))
            Else
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadRate", 0)
            End If
            Pay_Head_Cmd.Parameters.AddWithValue("@PUnderType", CmbxUndrType.Text)
            Slipname = TxtApearName.Text

            If Slipname <> "" Then
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadSlipname", TxtApearName.Text)
            Else
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadSlipname", "")
            End If

            Pay_Head_Cmd.Parameters.AddWithValue("@PheadGrauty", graty)
            Pay_Head_Cmd.Parameters.AddWithValue("@PheadCalmtd", CmbxMoCal.Text)
            If CmbxMoCal.Text <> "As User Defined Value" Then
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadComp", CmbxComptype.Text)
            Else
                Pay_Head_Cmd.Parameters.AddWithValue("@PheadComp", "")
            End If
            If CmbxMoCal.Text <> "As User Defined Value" Then
                If Panel3.Visible = True And Radf1.Checked = True Then
                    Pay_Head_Cmd.Parameters.AddWithValue("@PhFormulaType", Radf1.Text)
                ElseIf Panel3.Visible = True And Radf2.Checked = True Then
                    Pay_Head_Cmd.Parameters.AddWithValue("@PhFormulaType", Radf2.Text)
                ElseIf Panel4.Visible = True And Radf3.Checked = True Then
                    Pay_Head_Cmd.Parameters.AddWithValue("@PhFormulaType", Radf3.Text)
                ElseIf Panel4.Visible = True And Radf4.Checked = True Then
                    Pay_Head_Cmd.Parameters.AddWithValue("@PhFormulaType", Radf4.Text)
                End If
            Else
                Pay_Head_Cmd.Parameters.AddWithValue("@PhFormulaType", "")
            End If
            Pay_Head_Cmd.Parameters.AddWithValue("@PheadDelStatus", delstatus1)

            Dim dtproc As Date
            dtproc = DateSerial(Year(dtp1.Value.Date), Month(dtp1.Value.Date), 1)
            Pay_Head_Cmd.Parameters.AddWithValue("@PhEfecdt", dtproc.Date)
            '###############################3
            If Trim(CmbxPtext) = Trim("Employer's Contribution For PF") Then
                Pay_Head_Cmd.Parameters.AddWithValue("@PFshare", TxtPF.Text)
                Pay_Head_Cmd.Parameters.AddWithValue("@Pensnshare", TxtPens.Text)
            Else
                Pay_Head_Cmd.Parameters.AddWithValue("@PFshare", 0)
                Pay_Head_Cmd.Parameters.AddWithValue("@Pensnshare", 0)
            End If
            Pay_Head_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Pay_Head_Cmd = Nothing
        End Try


      
        '####################To save rd in slabrate tableAs Computed Value###########
        If CmbxMoCal.Text <> "As User Defined Value" Then
            total = LstvewPhSlab.Items.Count
            counter = 0
            Fetch_Concrnid()
            If Add_Edit_Flag = True Or add_new_flag_rate = True Then
                While counter < total
                    Try
                        delstatus1 = 0
                        Pay_Head_Cmd = New SqlCommand("FinAct_Slabrate_Insert", FinActConn)
                        Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateAdddt", Now)
                        Pay_Head_Cmd.Parameters.AddWithValue("@Srateaddusrid", Current_UsrId)
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateConId", ConCerId)
                        'Pay_Head_Cmd.Parameters.AddWithValue("@SrateEFrom", LstvewPhSlab.Items(counter).SubItems(0).Text)
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateFAmt", FormatNumber(LstvewPhSlab.Items(counter).SubItems(0).Text, 2))
                        If LstvewPhSlab.Items(counter).SubItems(1).Text <> "Above" Then
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateUpAmt", FormatNumber(LstvewPhSlab.Items(counter).SubItems(1).Text, 2))
                        Else
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateUpAmt", LstvewPhSlab.Items(counter).SubItems(1).Text)
                        End If

                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateType", LstvewPhSlab.Items(counter).SubItems(2).Text)
                        Pay_Head_Cmd.Parameters.AddWithValue("@Sratevalue", LstvewPhSlab.Items(counter).SubItems(3).Text)
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateDelstatus", 0)

                        Pay_Head_Cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Pay_Head_Cmd = Nothing
                    End Try
                    counter += 1
                End While
            ElseIf Add_Edit_Flag = False And add_new_flag_rate = False Then
                counter = 0
                fetch_rate_id()
                count_rate_id()
                If total = count_rateid And count_rateid <> 0 Then
                    While counter < count_rateid
                        Pay_Head_Cmd = New SqlCommand("FinAct_Slabrate_Update", FinActConn)
                        Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateEdtdt", Now)
                        Pay_Head_Cmd.Parameters.AddWithValue("@Srateedtusrid", Current_UsrId)
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateConId", ConCerId)
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateId", rate_arr(counter))
                        '' Pay_Head_Cmd.Parameters.AddWithValue("@SrateEFrom", LstvewPhSlab.Items(counter).SubItems(0).Text)
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateFAmt", FormatNumber(LstvewPhSlab.Items(counter).SubItems(0).Text, 2))
                        If LstvewPhSlab.Items(counter).SubItems(1).Text <> "Above" Then
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateUpAmt", FormatNumber(LstvewPhSlab.Items(counter).SubItems(1).Text, 2))
                        Else
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateUpAmt", LstvewPhSlab.Items(counter).SubItems(1).Text)
                        End If
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateType", LstvewPhSlab.Items(counter).SubItems(2).Text)
                        Pay_Head_Cmd.Parameters.AddWithValue("@Sratevalue", LstvewPhSlab.Items(counter).SubItems(3).Text)
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateDelstatus", 0)
                        Pay_Head_Cmd.ExecuteNonQuery()
                        'rateid += 1
                        counter += 1
                    End While
                ElseIf total > count_rateid And count_rateid <> 0 Then
                    While counter < count_rateid
                        Pay_Head_Cmd = New SqlCommand("FinAct_Slabrate_Update", FinActConn)
                        Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateEdtdt", Now)
                        Pay_Head_Cmd.Parameters.AddWithValue("@Srateedtusrid", Current_UsrId)
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateConId", ConCerId)
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateId", rate_arr(counter))
                        '' Pay_Head_Cmd.Parameters.AddWithValue("@SrateEFrom", LstvewPhSlab.Items(counter).SubItems(0).Text)
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateFAmt", FormatNumber(LstvewPhSlab.Items(counter).SubItems(0).Text, 2))
                        If LstvewPhSlab.Items(counter).SubItems(1).Text <> "Above" Then
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateUpAmt", FormatNumber(LstvewPhSlab.Items(counter).SubItems(1).Text, 2))
                        Else
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateUpAmt", LstvewPhSlab.Items(counter).SubItems(1).Text)
                        End If
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateType", LstvewPhSlab.Items(counter).SubItems(2).Text)
                        Pay_Head_Cmd.Parameters.AddWithValue("@Sratevalue", LstvewPhSlab.Items(counter).SubItems(3).Text)
                        Pay_Head_Cmd.Parameters.AddWithValue("@SrateDelstatus", 0)
                        Pay_Head_Cmd.ExecuteNonQuery()
                        counter += 1
                    End While
                    While counter < total
                        Try
                            Pay_Head_Cmd = New SqlCommand("FinAct_Slabrate_Insert", FinActConn)
                            Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateAdddt", Now)
                            Pay_Head_Cmd.Parameters.AddWithValue("@Srateaddusrid", Current_UsrId)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateConId", ConCerId)
                            ''Pay_Head_Cmd.Parameters.AddWithValue("@SrateEFrom", LstvewPhSlab.Items(counter).SubItems(0).Text)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateFAmt", FormatNumber(LstvewPhSlab.Items(counter).SubItems(0).Text, 2))
                            If LstvewPhSlab.Items(counter).SubItems(1).Text <> "Above" Then
                                Pay_Head_Cmd.Parameters.AddWithValue("@SrateUpAmt", FormatNumber(LstvewPhSlab.Items(counter).SubItems(1).Text, 2))
                            Else
                                Pay_Head_Cmd.Parameters.AddWithValue("@SrateUpAmt", LstvewPhSlab.Items(counter).SubItems(1).Text)
                            End If
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateType", LstvewPhSlab.Items(counter).SubItems(2).Text)
                            Pay_Head_Cmd.Parameters.AddWithValue("@Sratevalue", LstvewPhSlab.Items(counter).SubItems(3).Text)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateDelstatus", 0)
                            Pay_Head_Cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Pay_Head_Cmd = Nothing
                        End Try
                        counter += 1
                    End While
                ElseIf count_rateid = 0 Then
                    While counter < total
                        Try
                            delstatus = 0
                            Pay_Head_Cmd = New SqlCommand("FinAct_Slabrate_Insert", FinActConn)
                            Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateAdddt", Now)
                            Pay_Head_Cmd.Parameters.AddWithValue("@Srateaddusrid", Current_UsrId)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateConId", ConCerId)
                            ''Pay_Head_Cmd.Parameters.AddWithValue("@SrateEFrom", LstvewPhSlab.Items(counter).SubItems(0).Text)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateFAmt", FormatNumber(LstvewPhSlab.Items(counter).SubItems(0).Text, 2))
                            If LstvewPhSlab.Items(counter).SubItems(1).Text <> "Above" Then
                                Pay_Head_Cmd.Parameters.AddWithValue("@SrateUpAmt", FormatNumber(LstvewPhSlab.Items(counter).SubItems(1).Text, 2))
                            Else
                                Pay_Head_Cmd.Parameters.AddWithValue("@SrateUpAmt", LstvewPhSlab.Items(counter).SubItems(1).Text)
                            End If
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateType", LstvewPhSlab.Items(counter).SubItems(2).Text)
                            Pay_Head_Cmd.Parameters.AddWithValue("@Sratevalue", LstvewPhSlab.Items(counter).SubItems(3).Text)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SrateDelstatus", 0)
                            Pay_Head_Cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Pay_Head_Cmd = Nothing
                        End Try

                        counter += 1
                    End While
                End If '<<

            End If '>>
        ElseIf (CmbxMoCal.Text = "As User Defined Value" Or CmbxComptype.Text <> "On Specified Formula") And Add_Edit_Flag = False Then
            Fetch_Concrnid()
            If ConCerId <> 0 Then
                Try
                    Pay_Head_Cmd = New SqlCommand("Finact_Slabrate_Delete", FinActConn)
                    Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                    Pay_Head_Cmd.Parameters.AddWithValue("@Sratedelusrid", Current_UsrId)
                    Pay_Head_Cmd.Parameters.AddWithValue("@SrateDeldt", Now)
                    Pay_Head_Cmd.Parameters.AddWithValue("@SrateDelStatus", 1)
                    Pay_Head_Cmd.Parameters.AddWithValue("@SrateConId", ConCerId)
                    Pay_Head_Cmd.ExecuteNonQuery()
                Catch EX As Exception
                    MsgBox(EX.Message)
                Finally
                    Pay_Head_Cmd = Nothing
                End Try

            End If
        End If
        '###########################Formula###################
        If CmbxComptype.Text = "On Specified Formula" And CmbxMoCal.Text <> "As User Defined Value" Then
            Fetch_Concrnid()
            counter = 0

            gridrows = DataGrid.Rows.Count
            While i < gridrows
                If DataGrid.Rows(i).Cells(0).Value = "True" Then
                    total_sel += 1
                End If
                i += 1
            End While
            i = 0
            If Add_Edit_Flag = True Then
                While i < gridrows

                    If DataGrid.Rows(i).Cells(0).Value = "True" Then
                        Try
                            delstatus = 0

                            Pay_Head_Cmd = New SqlCommand("FinAct_PayHeadFormula_Insert", FinActConn)
                            Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                            Pay_Head_Cmd.Parameters.AddWithValue("@PayheadConId", ConCerId)
                            Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayformulaid", CInt(DataGrid.Rows(i).Cells(3).Value))
                            Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayType", DataGrid.Rows(i).Cells(2).Value)
                            Pay_Head_Cmd.Parameters.AddWithValue("@EmpDelstatus", 0)
                            Pay_Head_Cmd.Parameters.AddWithValue("@EmpPhAdddt", Now)
                            Pay_Head_Cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Pay_Head_Cmd = Nothing
                        End Try
                    End If
                    i += 1
                End While
            ElseIf Add_Edit_Flag = False Then
                count_EmpPayFormula_id()
                fetch_EmpPayFormula_id()
                i = 0
                If total_sel = count_formulaid And count_formulaid <> 0 Then
                    While strtlop < count_formulaid
                        If DataGrid.Rows(i).Cells(0).Value = "True" Then
                            Try
                                Pay_Head_Cmd = New SqlCommand("FinAct_PayHeadFormula_Update", FinActConn)
                                Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                                Pay_Head_Cmd.Parameters.AddWithValue("@PayheadConId", ConCerId)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayId", arr_EmpFormulaid(strtlop))
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayformulaid", CInt(DataGrid.Rows(i).Cells(3).Value))
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayType", DataGrid.Rows(i).Cells(2).Value)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpDelstatus", 0)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPhEdtdt", Now)
                                Pay_Head_Cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                Pay_Head_Rdr.Close()
                                Pay_Head_Cmd = Nothing

                            End Try
                            strtlop += 1
                        End If
                        i += 1
                    End While
                ElseIf total_sel < count_formulaid And count_formulaid <> 0 Then
                    While strtlop < total_sel
                        If DataGrid.Rows(i).Cells(0).Value = "True" Then
                            Try
                                Pay_Head_Cmd = New SqlCommand("FinAct_PayHeadFormula_Update", FinActConn)
                                Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                                Pay_Head_Cmd.Parameters.AddWithValue("@PayheadConId", ConCerId)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayId", arr_EmpFormulaid(strtlop))
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayformulaid", CInt(DataGrid.Rows(i).Cells(3).Value))
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayType", DataGrid.Rows(i).Cells(2).Value)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpDelstatus", 0)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPhEdtdt", Now)
                                Pay_Head_Cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                Pay_Head_Cmd = Nothing
                            End Try
                            strtlop += 1
                        End If
                        i += 1
                    End While

                    While strtlop < count_formulaid
                        Try
                            Pay_Head_Cmd = New SqlCommand("update Finact_EmpPayHeadFormula  set Empdelstatus = '" & (1) & "' where EmpPayid='" & (arr_EmpFormulaid(strtlop)) & "'", FinActConn)
                            Pay_Head_Cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Pay_Head_Cmd = Nothing
                        End Try
                        strtlop += 1
                    End While

                ElseIf total_sel > count_formulaid And count_formulaid <> 0 Then
                    While strtlop < count_formulaid
                        If DataGrid.Rows(i).Cells(0).Value = "True" Then
                            Try
                                Pay_Head_Cmd = New SqlCommand("FinAct_PayHeadFormula_Update", FinActConn)
                                Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                                Pay_Head_Cmd.Parameters.AddWithValue("@PayheadConId", ConCerId)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayId", arr_EmpFormulaid(strtlop))
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayformulaid", CInt(DataGrid.Rows(i).Cells(3).Value))
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayType", DataGrid.Rows(i).Cells(2).Value)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpDelstatus", 0)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPhEdtdt", Now)
                                Pay_Head_Cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                Pay_Head_Cmd = Nothing
                            End Try
                            strtlop += 1
                        End If
                        i += 1
                    End While
                    While strtlop < total_sel
                        Try
                            delstatus = 0

                            Pay_Head_Cmd = New SqlCommand("FinAct_PayHeadFormula_Insert", FinActConn)
                            Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                            Pay_Head_Cmd.Parameters.AddWithValue("@PayheadConId", ConCerId)
                            Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayformulaid", CInt(DataGrid.Rows(i).Cells(3).Value))
                            Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayType", DataGrid.Rows(i).Cells(2).Value)
                            Pay_Head_Cmd.Parameters.AddWithValue("@EmpDelstatus", 0)
                            Pay_Head_Cmd.Parameters.AddWithValue("@EmpPhAdddt", Now)
                            Pay_Head_Cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Pay_Head_Cmd = Nothing
                        End Try
                        strtlop += 1

                    End While


                ElseIf count_formulaid = 0 Then
                    i = 0
                    While strtlop < total_sel
                        If DataGrid.Rows(i).Cells(0).Value = "True" Then

                            Try
                                delstatus = 0
                                Pay_Head_Cmd = New SqlCommand("FinAct_PayHeadFormula_Insert", FinActConn)
                                Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                                Pay_Head_Cmd.Parameters.AddWithValue("@PayheadConId", ConCerId)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayformulaid", CInt(DataGrid.Rows(i).Cells(3).Value))
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPayType", DataGrid.Rows(i).Cells(2).Value)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpDelstatus", 0)
                                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPhAdddt", Now)
                                Pay_Head_Cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                Pay_Head_Cmd = Nothing
                            End Try
                            strtlop += 1
                        End If
                        i += 1
                    End While
                End If
            End If
            i += 1
        ElseIf CmbxMoCal.Text = "As User Defined Value" Or CmbxComptype.Text <> "On Specified Formula" And Add_Edit_Flag = False Then
            Fetch_Concrnid()
            If ConCerId <> 0 Then
                Try
                    Pay_Head_Cmd = New SqlCommand("FinAct_PayHeadFormula_Delete", FinActConn)
                    Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                    Pay_Head_Cmd.Parameters.AddWithValue("@EmpDelStatus", 1)
                    Pay_Head_Cmd.Parameters.AddWithValue("@PayheadConId", ConCerId)
                    Pay_Head_Cmd.Parameters.AddWithValue("@EmpPhDeldt", Now)
                    Pay_Head_Cmd.ExecuteNonQuery()
                Catch EX As Exception
                    MsgBox(EX.Message)
                Finally
                    Pay_Head_Cmd = Nothing
                End Try
            End If
        End If 'end of cond
        '' If save_flag <> True Then
        Chek_VPF()
        If Chek_VPF_Flag = False Then
            If CmbxPtext = "DEEmpPF" And Add_Edit_Flag = True Then
                Save_VPF()
            End If
        End If
        MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
        '' End If
    End Sub

    Private Sub count_rate_id() 'to fetch slabrate autogenerateid's

        Fetch_Concrnid()
        count_rateid = 0
        Try
            Pay_Head_Cmd = New SqlCommand("Select SrateId from FinactSlabRate where SrateConId='" & (ConCerId) & "'", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
            While Pay_Head_Rdr.Read()
                If Pay_Head_Rdr.HasRows = True Then
                    count_rateid += 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Pay_Head_Rdr.HasRows = False Then
                count_rateid = 0
            End If
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing

        End Try

    End Sub

    Private Sub fetch_rate_id() 'to fetch slabrate autogenerateid's

        Fetch_Concrnid()
        rate_arr_count = 0
        Try
            Pay_Head_Cmd = New SqlCommand("Select SrateId from FinactSlabRate where SrateConId='" & (ConCerId) & "'", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
            While Pay_Head_Rdr.Read()
                If Pay_Head_Rdr.IsDBNull(0) = False Then
                    rate_arr(rate_arr_count) = Pay_Head_Rdr(0)
                Else
                    rateid = 0
                End If
                rate_arr_count += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing

        End Try
        '++++++++++add
        If rateid = 0 Then
            Try
                Pay_Head_Cmd = New SqlCommand("Select Max(SrateId) from FinactSlabRate ", FinActConn)
                Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
                Pay_Head_Rdr.Read()
                If Pay_Head_Rdr.IsDBNull(0) = False Then
                    add_new_flag_rate = True
                    rateid = Pay_Head_Rdr(0)
                Else
                    add_new_flag_rate = True
                    rateid = rateid + 1
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Pay_Head_Rdr.Close()
                Pay_Head_Cmd = Nothing
            End Try

        End If

    End Sub
    Private Sub fetch_EmpPayFormula_id() 'to fetch EmpPayFormula autogenerateid's
        Fetch_Concrnid()
        Dim i As Integer = 0
        Try
            Pay_Head_Cmd = New SqlCommand("Select EmpPayId from Finact_EmpPayHeadFormula where PayheadConId='" & (ConCerId) & "'", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
            While Pay_Head_Rdr.Read()
                If Pay_Head_Rdr.IsDBNull(0) = False Then
                    arr_EmpFormulaid(i) = Pay_Head_Rdr(0)
                End If
                i += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing
        End Try

    End Sub
    Private Sub count_EmpPayFormula_id() 'to count EmpPayFormula autogenerateid's

        Fetch_Concrnid()
        Try
            Pay_Head_Cmd = New SqlCommand("Select EmpPayId from Finact_EmpPayHeadFormula where PayheadConId='" & (ConCerId) & "'AND Empdelstatus='" & (0) & "'", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
            While Pay_Head_Rdr.Read()
                If Pay_Head_Rdr.IsDBNull(0) = False Then
                    count_formulaid += 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing

        End Try

    End Sub

    Private Sub Fetch_Concrnid()

        Try
            If Add_Edit_Flag = True Then
                Pay_Head_Cmd = New SqlCommand("Select MAX(PheadId) from FinActPayHead   ", FinActConn) 'where PheadDelstatus='" & (0) & "'
                Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
                Pay_Head_Rdr.Read()
                If Pay_Head_Rdr.HasRows = True Then
                    ConCerId = Pay_Head_Rdr(0)
                End If
            ElseIf Add_Edit_Flag = False Then
                'Pay_Head_Cmd = New SqlCommand("Select MAX(PheadId) from FinActPayHead  where PheadName='" & (Cmbxid.Text) & "' ", FinActConn)
                'Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
                'Pay_Head_Rdr.Read()
                'If Pay_Head_Rdr.HasRows = True Then
                '    ConCerId = Pay_Head_Rdr(0)
                'End If
                ConCerId = Cmbxid.SelectedValue
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing
        End Try

    End Sub
    Private Sub fetch_srt_fullnm()

        If CmbxPtext = "DEEmp" Then
            Edit_Srt = "Deduction From Employee"
        ElseIf CmbxPtext = "EREmp" Then
            Edit_Srt = "Earnings For Employee"
        ElseIf CmbxPtext = "REB" Then
            Edit_Srt = "Reimbursements to Employee"
        ElseIf CmbxPtext = "DEEmpESI" Then
            Edit_Srt = "Deduction From Employee For ESI"
        ElseIf CmbxPtext = "DEEmpPF" Then
            Edit_Srt = "Deduction From Employee For PF"
        ElseIf CmbxPtext = "Employer's Contribution For ESI" Then
            Edit_Srt = "Employer's Contribution For ESI"
        ElseIf CmbxPtext = "Employer's Contribution For PF" Then
            Edit_Srt = "Employer's Contribution For PF"
        ElseIf CmbxPtext = "Bonus" Then
            Edit_Srt = "Bonus"
        ElseIf CmbxPtext = "Incentive" Then
            Edit_Srt = "Incentive"
        End If

    End Sub
    Private Sub chk_dupli_pheadname() 'to check Duplicate record

        If Add_Edit_Flag = True And chkdupliitm <> True Then
            Try
                Pay_Head_Cmd = New SqlCommand("Select Pheadname from FinActPayHead where PheadDelstatus='" & (0) & "'  ", FinActConn)
                Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
                While Pay_Head_Rdr.Read()
                    If Pay_Head_Rdr.HasRows = True Then
                        chk_dupli_name = Pay_Head_Rdr(0)
                        If Trim(TxtPayhed.Text.ToUpper) = Trim(chk_dupli_name.ToUpper) Then
                            new_ph = 1
                            MsgBox("System found same Pay Head Name in data table, try again with another Pay Head Name", MsgBoxStyle.Information, "Duplicate Value")
                            chkdupliitm = True
                            TxtPayhed.Focus()
                            TxtPayhed.SelectAll()
                            Pay_Head_Rdr.Close()
                            Pay_Head_Cmd = Nothing
                            Exit Sub
                        End If
                    End If
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Pay_Head_Rdr.Close()
                Pay_Head_Cmd = Nothing
            End Try

        ElseIf Add_Edit_Flag = False And chkdupliitm <> True Then
            Fetch_Concrnid()
            Try
                Pay_Head_Cmd = New SqlCommand("Select Pheadname from FinActPayHead where PheadDelstatus='" & (0) & "' and pheadid <>'" & (ConCerId) & "'", FinActConn)
                Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
                While Pay_Head_Rdr.Read()
                    If Pay_Head_Rdr.HasRows = True Then
                        chk_dupli_name = Pay_Head_Rdr(0)
                        If Trim(TxtPayhed.Text.ToUpper) = Trim(chk_dupli_name.ToUpper) Then
                            new_ph = 1
                            MsgBox("System found same Pay Head Name in data table, try again with another Pay Head Name", MsgBoxStyle.Information, "Duplicate Value")
                            chkdupliitm = True
                            TxtPayhed.Focus()
                            TxtPayhed.SelectAll()
                            Pay_Head_Rdr.Close()
                            Pay_Head_Cmd = Nothing
                            Exit Sub
                        End If
                    End If
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Pay_Head_Rdr.Close()
                Pay_Head_Cmd = Nothing
            End Try
        End If
        chkdupliitm = False

    End Sub
    Private Sub chk_dupli_pheadtype() 'to check Duplicate record type

        If Add_Edit_Flag = True And chkdupliitm <> True Then
            CmbxPtext = ""
            Try
                Pay_Head_Cmd = New SqlCommand("Select Pheadtype  from FinActPayHead where PheadDelstatus='" & (0) & "' ", FinActConn)
                Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
                While Pay_Head_Rdr.Read()
                    If Pay_Head_Rdr.HasRows = True Then
                        CmbxPtext = Pay_Head_Rdr(0)
                        fetch_srt_fullnm()
                        If Edit_Srt = "Bonus" Or Edit_Srt = "Employer's Contribution For ESI" Or Edit_Srt = "Employer's Contribution For PF" Or Edit_Srt = "Deduction From Employee For ESI" Or Edit_Srt = "Deduction From Employee For PF" Then
                            If Trim(str_CmbxPtype.ToUpper) = Trim(Edit_Srt.ToUpper) Then
                                chkdupliitm = True
                                MsgBox("System found same Pay Head type in data table, try again with another Pay Headtype", MsgBoxStyle.Information, "Duplicate Value")
                                CmbxPtype.Focus()
                                CmbxPtype.SelectAll()
                                Pay_Head_Rdr.Close()
                                Pay_Head_Cmd = Nothing
                                Exit Sub
                            End If
                        End If
                    End If
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Pay_Head_Rdr.Close()
                Pay_Head_Cmd = Nothing
            End Try

        ElseIf Add_Edit_Flag = False And chkdupliitm <> True Then
            Fetch_Concrnid()
            Try
                Pay_Head_Cmd = New SqlCommand("Select Pheadtype from FinActPayHead where PheadDelstatus='" & (0) & "' and pheadid <>'" & (ConCerId) & "'", FinActConn)
                Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
                While Pay_Head_Rdr.Read()
                    If Pay_Head_Rdr.HasRows = True Then
                        CmbxPtext = Pay_Head_Rdr(0)
                        fetch_srt_fullnm()
                        If Edit_Srt = "Bonus" Or Edit_Srt = "Employer's Contribution For ESI" Or Edit_Srt = "Employer's Contribution For PF" Or Edit_Srt = "Deduction From Employee For ESI" Or Edit_Srt = "Deduction From Employee For PF" Then
                            If Trim(str_CmbxPtype.ToUpper) = Trim(Edit_Srt.ToUpper) Then
                                chkdupliitm = True
                                MsgBox("System found same Pay Head type in data table, try again with another Pay Headtype", MsgBoxStyle.Information, "Duplicate Value")
                                CmbxPtype.Focus()
                                CmbxPtype.SelectAll()
                                Pay_Head_Rdr.Close()
                                Pay_Head_Cmd = Nothing
                                Exit Sub
                            End If
                        End If
                    End If
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Pay_Head_Rdr.Close()
                Pay_Head_Cmd = Nothing
            End Try
        End If
        chkdupliitm = False

    End Sub
    Private Sub lstvewboxClear()

        TxtFromamt.Text = ""
        TxtToamt.Text = ""
        CmbxType.Text = ""
        TxtSlabrate.Text = ""

    End Sub
    Private Sub BtnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Click

        If BtnAdd.Text = "&Add" Then
            datgrid_flag = False
            Lblid.Visible = False
            Cmbxid.Visible = False
            BtnAdd.Text = "&Save"
            BtnEdt.Text = "&Cancel"
            enable_true()
            TxtPayhed.Focus()
            Add_Edit_Flag = True
            If CmbxComptype.SelectedIndex = -1 Then
                CmbxComptype.SelectedIndex = 0
            End If ''
            If CmbxPtype.SelectedIndex = -1 Then
                CmbxPtype.SelectedIndex = 0
            End If ''
            If CmbxMoCal.SelectedIndex = -1 Then
                CmbxMoCal.SelectedIndex = 0
            End If '
            If CmbxUndrType.SelectedIndex = -1 Then
                CmbxUndrType.SelectedIndex = 0
            End If '
        ElseIf BtnAdd.Text = "&Save" Then
            If save_flag <> True Then
                Dim delconfrm1 As String
                delconfrm1 = MsgBox("Are you sure to save the record?", MsgBoxStyle.YesNo, "Alert")
                If delconfrm1 = vbYes Then
                    Chk_val()
                    If Indx <> 0 Then
                        Indx = 0
                        Exit Sub
                    ElseIf Add_Edit_Flag = True Then
                        countrds()
                        If cnt_record <> 0 And Trim(CmbxPtype.Text) <> Trim("Incentive") Then

                            ' Me.Height = 647
                            set_height_emplst()
                            fetch_rd_emplst()
                            If Trim(CmbxPtype.Text) = Trim("Employer's Contribution For PF") Then
                                Link1.Visible = False
                                If Lstemp.Items.Count > 0 Then
                                    Dim i As Integer = 0
                                    While i < Lstemp.Items.Count
                                        Lstemp.Items(i).Checked = True
                                        i += 1
                                    End While
                                    Lstemp.Enabled = False
                                    MsgBox((TxtPayhed.Text) & " will be applicable to all employees displayed in the list", MsgBoxStyle.Information, "Payhead")
                                End If
                            ElseIf Trim(CmbxPtype.Text) <> Trim("Incentive") Then
                                MsgBox("First Select the Employees to whom this PayHead will be applicable", MsgBoxStyle.Information, "Alert")
                            End If

                            save_flag = True
                            Exit Sub
                        Else
                            set_height() 'when no emprd is found
                            '********************fetch_rd_emplst()
                            ' save_flag = True
                            '########add######################
                            Saverrecord()
                            Clrvalues()
                            Me.Height = 413
                            LstvewPhSlab.Items.Clear()
                            lstvewboxClear()
                            enable_flse()
                            BtnEdt.Text = "&Find"
                        End If


                    ElseIf Add_Edit_Flag = False Then
                        chk_Phed_appli()
                        If id_ext <> 0 Then  'compare with date when payhed created for first time
                            If dtp1.Text = ACT_DT_FETCH Then
                                MsgBox("Record Can't be Update as Pay head has been already Applicable", MsgBoxStyle.Information)
                                Clrvalues()
                                LstvewPhSlab.Items.Clear()
                                lstvewboxClear()
                                enable_flse()
                                BtnEdt.Text = "&Find"
                                Exit Sub
                            End If
                            fetch_maxslryslp()
                            If dtp1.Text < maxslrymnth Then 'compare with date when payhed applicable 
                                MsgBox("Record Can't be Update as Efective Date should be >" & maxslrymnth, MsgBoxStyle.Information)
                                Clrvalues()
                                LstvewPhSlab.Items.Clear()
                                lstvewboxClear()
                                enable_flse()
                                BtnEdt.Text = "&Find"
                                Exit Sub
                            End If
                            If ACTUAL_MTD <> CmbxMoCal.Text Then 'compare  payhed applicable  with change type
                                MsgBox("Record Can't be Update as Pay head has been already Applicable with type of " & ACTUAL_MTD, MsgBoxStyle.Information)
                                Clrvalues()
                                LstvewPhSlab.Items.Clear()
                                lstvewboxClear()
                                enable_flse()
                                BtnEdt.Text = "&Find"
                                Exit Sub
                            End If
                        End If
                        If id_ext <> 0 Then '**WHEN PAYHED IS APPLICABLE AND SAME PAYHED WILL SAVE WITH NEW NAME
                            Add_Edit_Flag = True 'done new 
                            chk_dupli_pheadname()
                            If new_ph = 1 Then
                                new_ph = 0
                                new_ph1 = 1
                                TxtApearName.Enabled = False
                                Add_Edit_Flag = False
                                TxtPayhed.Focus()
                                Exit Sub
                            Else
                                new_ph1 = 0
                            End If
                        End If '******************END 
                        Saverrecord()
                        Clrvalues()
                       
                        LstvewPhSlab.Items.Clear()
                        lstvewboxClear()
                        enable_flse()
                        BtnEdt.Text = "&Find"
                    End If


                End If
            ElseIf save_flag = True Then
                Saverrecord()
                If Trim(CmbxPtype.Text) <> Trim("Incentive") Then
                    save_emplst()
                End If
                Clrvalues()
                Me.Height = 413
                LstvewPhSlab.Items.Clear()
                lstvewboxClear()
                enable_flse()
                BtnEdt.Text = "&Find"
                End If
                ''ElseIf Add_Edit_Flag = False Then
                ''    If dtp1.Value.Date < maxslrymnth.AddDays(1) Then
                ''        MsgBox("Record Can't be Update as Efective Date should be >" & Format(maxslrymnth.AddDays(1), "dd/MM/yyyy"), MsgBoxStyle.Information)
                ''        Clrvalues()
                ''        LstvewPhSlab.Items.Clear()
                ''        lstvewboxClear()
                ''        enable_flse()
                ''        BtnEdt.Text = "&Find"
                ''        Exit Sub
                ''    End If
                ''    If ACTUAL_MTD <> CmbxMoCal.Text Then
                ''        chk_Phed_appli()
                ''        If id_ext <> 0 Then
                ''            MsgBox("Record Can't be Update as Pay head has been already Applicable ", MsgBoxStyle.Information)
                ''            Clrvalues()
                ''            LstvewPhSlab.Items.Clear()
                ''            lstvewboxClear()
                ''            enable_flse()
                ''            BtnEdt.Text = "&Find"
                ''            Exit Sub
                ''        End If
                ''    End If
                ''    Saverrecord()
                ''    Clrvalues()
                ''    LstvewPhSlab.Items.Clear()
                ''    lstvewboxClear()
                ''    enable_flse()
                ''    BtnEdt.Text = "&Find"
        End If
        'End If

        nord_fg = False
        count_formulaid = 0
        fetch_rd_flag = False
        chkdupliitm = False
        One_slab_flag = False

    End Sub
    Private Sub chk_Phed_appli()
        id_ext = 0
        Try
            Pay_Head_Cmd = New SqlCommand("Select pheadid,AspdFmid from FinactAutoSalary_Payhed inner join FinactPayhead on pheadid=AspdFmid where PheadName='" & (Cmbxid.Text) & "' and AsPddelstatus=0", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
            Pay_Head_Rdr.Read()
            'If Pay_Head_Rdr.IsDBNull(0) = False Then
            If Pay_Head_Rdr.HasRows = True Then
                id_ext = Pay_Head_Rdr(1)

            End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Pay_Head_Rdr.HasRows = False Then
                id_ext = 0
                Pay_Head_Rdr.Close()
                Pay_Head_Cmd = Nothing
            End If
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing
        End Try

    End Sub
    Private Sub TxtApearName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtApearName.KeyDown

        If e.KeyCode = Keys.Enter Then
            RbYn3.Focus()
        End If

    End Sub
    Private Sub fetch_Costrtdate() '-------------to fetch srtdate,year of company and add items in year combo
        Try
            Pay_Head_Cmd = New SqlCommand("Select Costrtdt from finactcogatemstr ", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
            Pay_Head_Rdr.Read()
            If Pay_Head_Rdr.IsDBNull(0) = False Then
                If Pay_Head_Rdr.HasRows = True Then
                    Strtminyear = Pay_Head_Rdr(0)
                Else
                    Strtminyear = Format("1 / 1 / 1900", "dd/MM/yyyy")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing
        End Try

    End Sub
    Private Sub fetch_srt_names() 'to save short names

        If CmbxPtype.SelectedIndex = 0 Then
            CmbxPtext = "DEEmp"  'deduct
        ElseIf CmbxPtype.SelectedIndex = 1 Then
            CmbxPtext = "EREmp" 'earn from emp
        ElseIf CmbxPtype.SelectedIndex = 2 Then
            CmbxPtext = "REB" 'Reimburse
        ElseIf CmbxPtype.SelectedIndex = 3 Then
            CmbxPtext = "DEEmpESI"
        ElseIf CmbxPtype.SelectedIndex = 4 Then
            CmbxPtext = "DEEmpPF"
        ElseIf CmbxPtype.SelectedIndex = 5 Then
            CmbxPtext = "Employer's Contribution For ESI"
        ElseIf CmbxPtype.SelectedIndex = 6 Then
            CmbxPtext = "Employer's Contribution For PF"
        ElseIf CmbxPtype.SelectedIndex = 7 Then
            CmbxPtext = "Bonus"
        ElseIf CmbxPtype.SelectedIndex = 8 Then
            CmbxPtext = "Incentive"
        End If

    End Sub

    Private Sub enable_flse()
        TxtPayhed.Enabled = False
        CmbxMoCal.Enabled = False
        CmbxPtype.Enabled = False
        CmbxUndrType.Enabled = False
        Panel1.Enabled = False
        Panel2.Enabled = False
        CmbxComptype.Enabled = False
        TxtApearName.Enabled = False
        dtp1.Enabled = False
    End Sub
    Private Sub enable_true()
        TxtPayhed.Enabled = True
        CmbxMoCal.Enabled = True
        CmbxPtype.Enabled = True
        CmbxUndrType.Enabled = True
        Panel1.Enabled = True
        Panel2.Enabled = True
        CmbxComptype.Enabled = True
        TxtApearName.Enabled = True
        dtp1.Enabled = True
    End Sub

    Private Sub fetch_rd()
        ACTUAL_MTD = ""
        Dim Formula_type As String = ""
        Dim CTypetext As String
        Dim Slipname As String
        Dim Chkgraty As String
        Dim calmtd As String = ""
        Dim calway As String = ""
        Dim bonusrt As Double = 0.0
        Dim maxdt As Date
        Try
            Pay_Head_Cmd = New SqlCommand("Select max(PhEfecdt) from FinActPayHead where Pheadname='" & (Cmbxid.Text) & "' and Pheaddelstatus='" & (0) & "' ", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
            Pay_Head_Rdr.Read()
            If Pay_Head_Rdr.HasRows = True Then
                maxdt = Pay_Head_Rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing
        End Try


        Try
            Pay_Head_Cmd = New SqlCommand("Select * from FinActPayHead where Pheadname='" & (Cmbxid.Text) & "' and Pheaddelstatus='" & (0) & "'and Phefecdt='" & (maxdt) & "' ", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
            Pay_Head_Rdr.Read()
            If Pay_Head_Rdr.HasRows = True Then
                TxtPayhed.Text = Pay_Head_Rdr("PheadName")
                dtp1.Text = Pay_Head_Rdr("PhEfecdt")
                ACT_DT_FETCH = dtp1.Text

                CTypetext = Pay_Head_Rdr("PheadType")
                If CTypetext = "DEEmp" Then
                    CmbxPtype.SelectedIndex = 0
                    Edit_Srt = "Deduction From Employee"
                ElseIf CTypetext = "EREmp" Then
                    CmbxPtype.SelectedIndex = 1
                    Edit_Srt = "Earnings For Employee"
                ElseIf CTypetext = "REB" Then
                    CmbxPtype.SelectedIndex = 2
                    Edit_Srt = "Reimbursements to Employee"
                ElseIf CTypetext = "DEEmpESI" Then
                    CmbxPtype.SelectedIndex = 3
                    Edit_Srt = "Deduction From Employee For ESI"
                ElseIf CTypetext = "DEEmpPF" Then
                    CmbxPtype.SelectedIndex = 4
                    Edit_Srt = "Deduction From Employee For PF"
                ElseIf CTypetext = "Employer's Contribution For ESI" Then
                    CmbxPtype.SelectedIndex = 5
                    Edit_Srt = "Employer's Contribution For ESI"
                ElseIf CTypetext = "Employer's Contribution For PF" Then
                    CmbxPtype.SelectedIndex = 6
                    Edit_Srt = "Employer's Contribution For PF"
                ElseIf CTypetext = "Bonus" Then
                    CmbxPtype.SelectedIndex = 7
                    Edit_Srt = "Bonus"
                ElseIf CTypetext = "Incentive" Then
                    CmbxPtype.SelectedIndex = 8
                    Edit_Srt = "Incentive"

                End If
                'If Edit_Srt = "Bonus" Then
                '    CmbxPtype.SelectedIndex = 7
                'Else
                '    CmbxPtype.Text = Edit_Srt
                'End If
                If CTypetext = "Employer's Contribution For PF" Then
                    Lblmd.Visible = False
                    Lblcomtyp.Visible = False

                    LblPF.Visible = True
                    LblPensn.Visible = True
                    TxtPF.Visible = True
                    TxtPens.Visible = True
                    LblPerc1.Visible = True
                    LblPerc2.Visible = True
                    TxtPF.Text = Pay_Head_Rdr("PFshare")
                    TxtPens.Text = Pay_Head_Rdr("Pensnshare")

                Else
                    Lblmd.Visible = True
                    Lblcomtyp.Visible = True

                    LblPF.Visible = False
                    LblPensn.Visible = False
                    TxtPF.Visible = False
                    TxtPens.Visible = False
                    LblPerc1.Visible = False
                    LblPerc2.Visible = False

                End If

                CmbxUndrType.Text = Pay_Head_Rdr("PUnderType")
                Slipname = Pay_Head_Rdr("PheadSlipname")
                bonusrt = Pay_Head_Rdr("PheadRate")

                If Slipname <> "" Then
                    TxtApearName.Text = Slipname
                    RbYn1.Checked = True
                Else
                    TxtApearName.ReadOnly = True
                    TxtApearName.Text = ""
                    RbYn2.Checked = True
                End If
                calmtd = Pay_Head_Rdr("PheadCalmtd")
                If bonusrt > 0 And calmtd <> "As User Defined Value" Then
                    DataGrid.Visible = False
                    DataGrid.Rows.Clear()
                    Txtbonus.Text = bonusrt
                    CmbxComptype.Visible = False
                    Me.pnlPhSlab.Visible = False
                    Lblcomtyp.Visible = False
                    Me.Height = 276
                    If CTypetext = "Employer's Contribution For PF" Then
                        Me.Height = 350
                    End If
                    Me.Width = 413
                    ena_tru()
                    cmbxyype_false()
                    Exit Sub
                ElseIf bonusrt > 0 And calmtd = "As User Defined Value" Then
                    Panel7.Visible = True
                    labamt.Visible = True
                    Txtamt.Text = bonusrt
                End If

                Chkgraty = Pay_Head_Rdr("PheadGrauty")
                If Chkgraty = "No" Then
                    RbYn4.Checked = True
                Else
                    RbYn3.Checked = True
                End If
                Me.Lblcompu.Text = calmtd
                ACTUAL_MTD = calmtd
                ' calmtd1 = Pay_Head_Rdr("PheadCalmtd")
                If calmtd = "As User Defined Value" Then
                    DataGrid.Visible = False
                    DataGrid.Rows.Clear()
                    CmbxComptype.Visible = False
                    Me.pnlPhSlab.Visible = False
                    Me.Width = 412 '422
                    Lblcomtyp.Visible = False
                ElseIf calmtd <> "As User Defined Value" Then
                    Me.pnlPhSlab.Visible = True
                    Me.Width = 872 ' 957
                    Lblcomtyp.Visible = True
                    Me.Lblcomtyp.Location = New System.Drawing.Point(7, 297)
                    CmbxComptype.Visible = True
                    Me.CmbxComptype.Location = New System.Drawing.Point(141, 297)
                End If
                '
                ''  CmbxMoCal.Text = calmtd

                CmbxMoCal.Text = Pay_Head_Rdr("PheadCalmtd")
                If CmbxMoCal.Text <> "As User Defined Value" Then
                    mainhedrd = True
                End If
                CmbxComptype.Text = Pay_Head_Rdr("PheadComp")
                calway = Pay_Head_Rdr("PheadComp")
                Formula_type = Pay_Head_Rdr("PhFormulaType")
                If Formula_type <> "" Then
                    mainhedrd = True

                    If Formula_type = Radf1.Text Then
                        Labformula.Visible = True
                        Panel3.Visible = True
                        Panel4.Visible = False
                        Radf1.Checked = True
                    ElseIf Formula_type = Radf2.Text Then
                        Labformula.Visible = True
                        Panel3.Visible = True
                        Panel4.Visible = False
                        Radf2.Checked = True
                    ElseIf Formula_type = Radf3.Text Then
                        Labformula.Visible = True
                        Panel4.Visible = True
                        Panel3.Visible = False
                        Radf3.Checked = True
                    ElseIf Formula_type = Radf4.Text Then
                        Labformula.Visible = True
                        Panel4.Visible = True
                        Panel3.Visible = False
                        Radf4.Checked = True
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing

        End Try

        If CmbxPtype.Text = "Incentive" Then
            Lblcomtyp.Visible = False
            CmbxComptype.Visible = False
        Else
            Lblcomtyp.Visible = True
            CmbxComptype.Visible = True
        End If
      
        If calmtd <> "As User Defined Value" And (Formula_type <> Radf3.Text Or Formula_type <> Radf4.Text) Then
            fetch_rd_flag = True
            mainhedrd = False
            Me.Width = 872 '957
            Try
                fetch_head_id()
                pnlPhSlab.Visible = True
                pnlPhSlab.Enabled = True
                LstvewPhSlab.Items.Clear()
                LstvewPhSlab.Visible = True
                Dim Sublst As ListViewItem
                Pay_Head_Cmd = New SqlCommand("Select * from FinactslabRate where SrateConId='" & (mainhid) & "' and SrateDelstatus='" & (0) & "' ", FinActConn)
                Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
                While Pay_Head_Rdr.Read()
                    If Pay_Head_Rdr.HasRows = True Then
                        ''Sublst = LstvewPhSlab.Items.Add((Pay_Head_Rdr(2)))
                        ''Sublst.SubItems.Add((Pay_Head_Rdr(3)))
                        ''Sublst.SubItems.Add((Pay_Head_Rdr(4)))
                        ''Sublst.SubItems.Add((Pay_Head_Rdr(5)))
                        ''Sublst.SubItems.Add((Pay_Head_Rdr(6)))
                        Sublst = LstvewPhSlab.Items.Add((Pay_Head_Rdr(2)))
                        Sublst.SubItems.Add((Pay_Head_Rdr(3)))
                        Sublst.SubItems.Add((Pay_Head_Rdr(4)))
                        Sublst.SubItems.Add((Pay_Head_Rdr(5)))
                        '' Sublst.SubItems.Add((Pay_Head_Rdr(6)))
                    End If
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Pay_Head_Rdr.Close()
                Pay_Head_Cmd = Nothing

            End Try
        ElseIf calmtd = "As User Defined Value" Then
            Labformula.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
        End If
       

        '+++++++++++++++++++++
        If calway = "On Specified Formula" And CmbxMoCal.Text <> "on Production/Performance value" Then

            If Formula_type = Radf3.Text Then
                fetch_rd_flag = True
                mainhedrd = False
                Me.Width = 872 '957
                pnlPhSlab.Visible = False
                Me.DataGrid.Location = New System.Drawing.Point(419, 38) '419,13
                fetch_head_id()
            Else
                Me.pnlPhSlab.Location = New System.Drawing.Point(419, 210)
                Me.DataGrid.Location = New System.Drawing.Point(419, 38)
            End If

            Dim i As Integer = 0
            DataGrid.Visible = True
            DataGrid.Rows.Clear()
            Me.DataGrid.AllowUserToAddRows = True
            i = 0
            Try
                Pay_Head_Cmd = New SqlCommand("Select PheadName,Pheadid from FinActPayHead where PheadDelstatus='" & (0) & "' order by PheadName", FinActConn)
                Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader

                While Pay_Head_Rdr.Read()
                    If Pay_Head_Rdr.HasRows = True Then
                        DataGrid.Rows.Add()
                        DataGrid.Rows(i).Cells(1).Value = Pay_Head_Rdr(0)
                        DataGrid.Rows(i).Cells(2).Value = Me.Column3.Items.Item(0)
                        DataGrid.Rows(i).Cells(3).Value = Pay_Head_Rdr(1)
                        i += 1
                    End If
                End While
                Me.DataGrid.AllowUserToAddRows = False
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Pay_Head_Rdr.Close()
                Pay_Head_Cmd = Nothing
            End Try
            i = 0
            '****************to check already add values
            Try

                'Pay_Head_Cmd = New SqlCommand("Select EmpPayformulaid,EmpPayType from FinAct_EmpPayHeadFormula where EmpDelstatus='" & (0) & "' and PayheadConId='" & (mainhid) & "' order by EmpPayheadName", FinActConn)
                Pay_Head_Cmd = New SqlCommand("Select PheadName,EmpPayType from FinAct_EmpPayHeadFormula inner join  FinActPayHead on  Pheadid=EmpPayformulaid where EmpDelstatus='" & (0) & "' and PayheadConId='" & (mainhid) & "' and PheadDelstatus<>'" & (1) & "' order by PheadName", FinActConn)
                Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
                While Pay_Head_Rdr.Read()
                    If Pay_Head_Rdr.HasRows = True Then
                        i = 0
                        While i < DataGrid.Rows.Count
                            If Trim(DataGrid.Rows(i).Cells(1).Value) = Trim(Pay_Head_Rdr(0)) Then
                                DataGrid.Rows(i).Cells(0).Value = True
                                If Trim(Pay_Head_Rdr(1).ToString) = Trim("Add") Then
                                    DataGrid.Rows(i).Cells(2).Value = Me.Column3.Items.Item(0)
                                ElseIf Trim(Pay_Head_Rdr(1).ToString) = Trim("Minus") Then
                                    DataGrid.Rows(i).Cells(2).Value = Me.Column3.Items.Item(1)
                                End If
                            End If
                            i += 1
                        End While
                    End If
                End While
                Me.DataGrid.AllowUserToAddRows = False
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Pay_Head_Rdr.Close()
                Pay_Head_Cmd = Nothing
            End Try


        ElseIf calway <> "On Specified Formula" And CmbxMoCal.Text <> "on Production/Performance value" Then
            DataGrid.Visible = False
            DataGrid.Rows.Clear()
            Me.pnlPhSlab.Location = New System.Drawing.Point(419, 38)
        ElseIf calway <> "On Specified Formula" And CmbxMoCal.Text = "on Production/Performance value" Then '== im i cond
            DataGrid.Visible = False
            DataGrid.Rows.Clear()
            Me.pnlPhSlab.Location = New System.Drawing.Point(419, 38)
        End If
        fetch_maxslryslp()
      

        'dtp1.MinDate = maxslrymnth.AddDays(1)
    End Sub
    Private Sub fetch_maxslryslp()

        Try
            Pay_Head_Cmd = New SqlCommand("Select max(aslryyear) from FinactAutoSalary where AslryDelstatus<>'" & (1) & "' ", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
            Pay_Head_Rdr.Read()
            If Pay_Head_Rdr.IsDBNull(0) = False Then
                If Pay_Head_Rdr.HasRows = True Then
                    maxslrymnth = Format(Pay_Head_Rdr(0), "MMMM/yyyy")
                End If
            Else
                maxslrymnth = Format(Strtminyear, "MMMM/yyyy")
            End If

            maxslrymnth = maxslrymnth.AddMonths(1)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Pay_Head_Rdr.HasRows = False Then
                maxslrymnth = Format(Strtminyear, "MMMM/yyyy")
                Pay_Head_Rdr.Close()
                Pay_Head_Cmd = Nothing
                'MsgBox("No record has been found", MsgBoxStyle.Critical, "Find Item Section")
            End If
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing
        End Try
        'MsgBox(maxslrymnth)

    End Sub

    Private Sub fetch_head_name() 'to fetch payhead name
        ds = New DataSet
        ds.Tables.Clear()
        Try
            Pay_Head_Cmd = New SqlCommand("Select PheadName,PheadId from FinActPayHead where PheadDelstatus<>'" & (1) & "' order by PheadName", FinActConn)
            adptr = New SqlDataAdapter(Pay_Head_Cmd)
            ds = New DataSet(Pay_Head_Cmd.CommandText)
            adptr.Fill(ds)
            Cmbxid.DataSource = ds.Tables(0)
            Me.Cmbxid.ValueMember = "PheadId"
            Me.Cmbxid.DisplayMember = "PheadName"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If ds.Tables(0).Rows.Count = 0 Then
                nord_fg = True
                Pay_Head_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Critical, "Find Item Section")
            End If
            Pay_Head_Cmd = Nothing
        End Try

        If Cmbxid.SelectedIndex = -1 And Cmbxid.Items.Count > 0 Then
            Cmbxid.SelectedIndex = 0
        End If
       

    End Sub
    Private Sub fetch_head_id() 'to fetch payhead id's

        Try
            Pay_Head_Cmd = New SqlCommand("Select Pheadid from FinActPayHead where PheadDelstatus<>'" & (1) & "' and PheadName='" & (Cmbxid.Text) & "'", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader

            While Pay_Head_Rdr.Read()
                mainhid = Pay_Head_Rdr(0)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing
        End Try
    End Sub
    Private Sub countrds()
        Try
            Pay_Head_Cmd = New SqlCommand("Select empname,empid,desiname,deptname,SBphed,SBid   from finactEmpMstr inner join   FinactEmp_slryBrkUp on SBEmpConcrnid=empid  inner join   Finactdesi on desiid=empdesiid  inner join  finactdept on empdeptid=deptid   where  finactEmpMstr.empdelstatus=1 and SBdelstatus=1 and sbphed=1 order by empname", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader

            While Pay_Head_Rdr.Read()
                If Pay_Head_Rdr.HasRows = True Then
                    cnt_record = 1
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing
        End Try
    End Sub
    Private Sub fetch_rd_emplst()
        Lstemp.Items.Clear()
        Lstemp.Visible = True
        Dim Sublst As ListViewItem
        Try
            Pay_Head_Cmd = New SqlCommand("Select empname,empid,desiname,deptname,SBphed,SBid   from finactEmpMstr inner join   FinactEmp_slryBrkUp on SBEmpConcrnid=empid  inner join   Finactdesi on desiid=empdesiid  inner join  finactdept on empdeptid=deptid   where  finactEmpMstr.empcateg='" & Trim("Working") & "' and SBdelstatus=1 and sbphed=1 order by empname", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
            While Pay_Head_Rdr.Read()
                If Pay_Head_Rdr.HasRows = True Then
                    Sublst = Lstemp.Items.Add((Pay_Head_Rdr(0)))
                    Sublst.SubItems.Add((Pay_Head_Rdr(2)))
                    Sublst.SubItems.Add((Pay_Head_Rdr(3)))
                    Sublst.SubItems.Add((Pay_Head_Rdr(1)))
                    Sublst.SubItems.Add((Pay_Head_Rdr(4)))
                    Sublst.SubItems.Add((Pay_Head_Rdr(5)))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing
        End Try


    End Sub
    Private Sub save_emplst()
        Dim maxid As Integer = 0
        Try
            Pay_Head_Cmd = New SqlCommand("Select max(Pheadid) from FinActPayHead ", FinActConn)
            Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
            While Pay_Head_Rdr.Read()
                maxid = Pay_Head_Rdr(0)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Pay_Head_Rdr.Close()
            Pay_Head_Cmd = Nothing
        End Try
        Dim i As Integer = 0
        Try
            If Lstemp.Items.Count > 0 Then
                While i < Lstemp.Items.Count
                    If Lstemp.Items(i).Checked = True Then
                        If Lstemp.Items(i).SubItems(4).Text = "True" Then '---------to insert in detail table
                            Pay_Head_Cmd = New SqlCommand("Finact_EmpSlryPhed_Insert", FinActConn)
                            Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                            Pay_Head_Cmd.Parameters.AddWithValue("@Pdadusrid", Current_UsrId)
                            Pay_Head_Cmd.Parameters.AddWithValue("@PdSlryConcrnid", CInt(Lstemp.Items(i).SubItems(5).Text))
                            Pay_Head_Cmd.Parameters.AddWithValue("@Pdaddt", Now)
                            Pay_Head_Cmd.Parameters.AddWithValue("@Pddelstatus", 1)
                            Pay_Head_Cmd.Parameters.AddWithValue("@PdPhedId", maxid)
                            Pay_Head_Cmd.ExecuteNonQuery()
                            Pay_Head_Cmd = Nothing
                        ElseIf Lstemp.Items(i).SubItems(4).Text = "False" Then
                            Pay_Head_Cmd = New SqlCommand("Finact_EmpSlryBrkup_Insert_phed", FinActConn)
                            Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                            Pay_Head_Cmd.Parameters.AddWithValue("@SBedtdt", Now)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SBEmpConcrnId", CInt(Lstemp.Items(i).SubItems(3).Text))
                            Pay_Head_Cmd.Parameters.AddWithValue("@SBphed", 1)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SBEdtusrid", Current_UsrId)
                            Pay_Head_Cmd.Parameters.AddWithValue("@SBdelstatus", 1)
                            Pay_Head_Cmd.ExecuteNonQuery()
                            Pay_Head_Cmd = Nothing

                            Pay_Head_Cmd = New SqlCommand("Finact_EmpSlryPhed_Insert", FinActConn)
                            Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                            Pay_Head_Cmd.Parameters.AddWithValue("@Pdadusrid", Current_UsrId)
                            Pay_Head_Cmd.Parameters.AddWithValue("@PdSlryConcrnid", CInt(Lstemp.Items(i).SubItems(5).Text))
                            Pay_Head_Cmd.Parameters.AddWithValue("@Pdaddt", Now)
                            Pay_Head_Cmd.Parameters.AddWithValue("@Pddelstatus", 1)
                            Pay_Head_Cmd.Parameters.AddWithValue("@PdPhedId", maxid)
                            Pay_Head_Cmd.ExecuteNonQuery()
                            Pay_Head_Cmd = Nothing
                        End If


                    End If
                    i += 1
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' MsgBox("Record has been Successfully Saved", MsgBoxStyle.Information, "Save Record")
    End Sub
    Private Sub BtnEdt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEdt.Click
        If BtnEdt.Text = "&Find" Then
            BtnEdt.Text = "&Cancel"
            Add_Edit_Flag = False
            comboflag = False
            fetch_head_name()
            If nord_fg = True Then
                Clrvalues()
                Exit Sub
            End If
            LstvewPhSlab.Items.Clear()
            Me.Width = 412
            Me.Height = 540
            Btndel.Enabled = True
            Lblid.Visible = True
            Cmbxid.Visible = True
            Cmbxid.Enabled = True
            enable_flse()
            BtnAdd.Text = Trim("&Save")
            Cmbxid.Focus()
        ElseIf BtnEdt.Text = "&Cancel" Then
            can_fg = True
            Flag1 = False
            Clrvalues()
            BtnEdt.Text = "&Find"

            Lblmd.Visible = True

            LblPF.Visible = False
            LblPensn.Visible = False
            TxtPF.Visible = False
            TxtPens.Visible = False
            LblPerc1.Visible = False
            LblPerc2.Visible = False
        End If

    End Sub

    Private Sub Cmbxid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxid.GotFocus

        'Cmbxid.Items.Clear()
        fetch_head_name()
        If Cmbxid.Items.Count > 0 Then
            Cmbxid.DroppedDown = True
        End If
        Labenter.Visible = True
    End Sub

    Private Sub Cmbxid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmbxid_Leave(sender, e)
        End If
    End Sub

    Private Sub Cmbxid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxid.Leave
        If Cmbxid.Text <> "" And comboflag <> True Then
            Cmbxid.Enabled = True
            comboflag = True
            LstvewPhSlab.Items.Clear()
            fetch_rd()
            Dim i As Integer = 0
            Add_Edit_Flag = False
            enable_true()
            Cmbxid.Enabled = False
            Labenter.Visible = False
            BtnAdd.Text = "&Save"
            fetch_rd_flag = False
            '********************to remove same headname in datagrid
            While i < DataGrid.Rows.Count
                If DataGrid.Rows(i).Cells(1).Value = Cmbxid.Text Then
                    DataGrid.Rows.RemoveAt(i)
                End If
                i += 1
            End While
            If (DataGrid.Visible = True) Then
                Try
                    i = 0
                    Lblfor_ph.Text = ""
                    Lblfor_ph.Text = "Basic"
                    While i < DataGrid.Rows.Count
                        If DataGrid.Rows(i).Cells(0).Value = "True" Then
                            Lblfor_ph.Visible = True
                            Lblgrdfor.Visible = True
                            If DataGrid.Rows(i).Cells(2).Value = "Add" Then
                                Lblfor_ph.Text += " + " & DataGrid.Rows(i).Cells(1).Value
                            Else
                                Lblfor_ph.Text += " - " & DataGrid.Rows(i).Cells(1).Value
                            End If
                        End If
                        i += 1
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                TxtPayhed.Focus()
            Else
                TxtPayhed.Focus()

            End If
            Cmbxid.Focus()
        End If
    End Sub

    Private Sub Clrvalues()
        cnt_record = 0
        Add_Edit_Flag = True
        TxtPayhed.Text = ""
        TxtApearName.ReadOnly = False
        If CmbxPtype.SelectedIndex >= 1 Then
            CmbxPtype.SelectedValue = 0
            CmbxPtype.SelectedIndex = 0
        End If
        CmbxPtype.Text = ""
        If CmbxUndrType.SelectedIndex >= 1 Then
            CmbxUndrType.SelectedValue = 0
            CmbxUndrType.SelectedIndex = 0
        End If
        TxtApearName.Text = ""
        If CmbxMoCal.SelectedIndex >= 1 Then
            CmbxMoCal.SelectedValue = 0
            CmbxMoCal.SelectedText = 0
        End If
        If CmbxComptype.SelectedIndex >= 1 Then
            CmbxComptype.SelectedValue = 0
            CmbxComptype.SelectedIndex = 0
        End If
        DataGrid.Visible = False
        LstvewPhSlab.Items.Clear()
        BtnAdd.Text = "&Add"
        BtnEdt.Text = "&Find"
        Btndel.Enabled = False
        Lblid.Visible = False
        ' Cmbxid.Items.Clear()
        Cmbxid.Visible = False
        Cmbxid.Enabled = False
        add_new_flag_rate = False
        fetch_rd_flag = False
        chkdupliitm = False
        One_slab_flag = False
        nord_fg = False
        Labformula.Visible = False
        Labenter.Visible = False
        mainhedrd = False
        Radf3.Enabled = True
        datgrid_flag = False
        TxtToamt.Text = ""
        TxtSlabrate.Text = ""
        TxtFromamt.Text = "0"
        Lblfor_ph.Visible = False
        Lblgrdfor.Visible = False
        Txtabove.Visible = False
        comboflag = False
        '0000000000
        CmbxComptype.Visible = False
        Labformula.Visible = False
        Labenter.Visible = False
        Me.pnlPhSlab.Visible = False
        Panel4.Visible = False
        Panel3.Visible = False
        DataGrid.Visible = False
        Me.Width = 413
        Me.Height = 413
        Lblcomtyp.Visible = False
        Panel5.Visible = False
        Lblbonus.Visible = False
        CmbxMoCal.Visible = True
        CmbxUndrType.Visible = True
        Panel1.Visible = True
        Panel2.Visible = True
        TxtApearName.Visible = True
        Lblutype.Visible = True
        Label4.Visible = True
        Lblslpnm.Visible = True
        Flag1 = False
        dtp1.MinDate = Strtminyear
        save_flag = False
        Lstemp.Visible = False
        labamt.Visible = False
        Panel7.Visible = False
        Txtamt.Text = ""
        Txtbonus.Text = ""
        Link1.Visible = False
        Link2.Visible = False
        Link3.Visible = False
        new_ph = 0
        new_ph1 = 0
        TxtPF.Text = ""
        TxtPens.Text = ""
        Lblmd.Visible = True

        LblPF.Visible = False
        LblPensn.Visible = False
        TxtPF.Visible = False
        TxtPens.Visible = False
        LblPerc1.Visible = False
        LblPerc2.Visible = False
        BtnAdd.Focus()
    End Sub

    Private Sub Txtamt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtamt.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnAdd.Focus()
        End If
    End Sub

    Private Sub TxtFromamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromamt.KeyPress, TxtSlabrate.KeyPress, Txtamt.KeyPress
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "." Then
            e.Handled = False
            If Not (IsNumeric(tb.Text & e.KeyChar)) Then
                e.Handled = True
                MsgBox("Enter Valid Number")
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub Txttoamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToamt.KeyPress
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "." Then
            e.Handled = False
            If Not (IsNumeric(tb.Text & e.KeyChar)) Then
                e.Handled = True
                MsgBox("Enter Valid Number")
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtSlabrate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSlabrate.GotFocus
        TxtSlabrate.SelectAll()
    End Sub
    '***********************no use *******************************
    Private Sub TxtSlabrate_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) 'Handles TxtSlabrate.KeyDown
        Dim a As Double
        If e.KeyCode = Keys.Enter Then
            If LstvewPhSlab.SelectedItems.Count = 0 Then
                If Trim(TxtToamt.Text) = Trim(TxtFromamt.Text) Then
                    Me.Width = 412 '422
                ElseIf Trim(TxtSlabrate.Text) = "" Or Trim(Val(TxtSlabrate.Text)) = 0 Then
                    TxtSlabrate.Focus()
                    TxtSlabrate.SelectAll()
                    Exit Sub
                Else
                    Chk_list_Items()
                    If Indx <> 0 Then
                        Indx = 0
                        Exit Sub
                    ElseIf TxtSlabrate.Text <> "" And a <> Trim(TxtToamt.Text) Then
                        If CmbxPtype.SelectedIndex = 3 Then

                        End If
                        Dim totrd As Integer = 0
                        Dim cnt2 As Integer = 0
                        Dim proces As String = ""
                        totrd = LstvewPhSlab.Items.Count
                        cnt2 = 0
                        If LstvewPhSlab.Items.Count > 0 Then
                            While cnt2 < totrd
                                proces = LstvewPhSlab.Items(cnt2).SubItems(2).Text
                                If proces = TxtToamt.Text Then
                                    MsgBox("Duplicate Slab Can't be Enter", MsgBoxStyle.Information, "Duplicate Record")
                                    TxtFromamt.Focus()
                                    Exit Sub
                                End If
                                cnt2 = cnt2 + 1
                            End While
                        End If
                        Dim Sublst As ListViewItem
                        'Sublst = LstvewPhSlab.Items.Add(Dtpkrefctdt.Text)
                        Sublst = LstvewPhSlab.Items.Add(FormatNumber(TxtFromamt.Text, 2))
                        Sublst.SubItems.Add(FormatNumber(TxtToamt.Text, 2))
                        Sublst.SubItems.Add(CmbxType.Text)
                        Sublst.SubItems.Add(TxtSlabrate.Text)
                        TxtFromamt_Enter(sender, e)
                        a = TxtToamt.Text
                        Dim delconfrm As String
                        delconfrm = MsgBox("Do u want to add more Slab rate", MsgBoxStyle.YesNo, "Alert")
                        If delconfrm = vbYes Then
                            TxtToamt.Focus()
                            TxtToamt.SelectAll()
                        Else
                            BtnAdd.Focus()
                        End If
                    Else
                        MsgBox("jljkljl")
                    End If
                End If
            End If
        End If
        If (Add_Edit_Flag = False Or Add_Edit_Flag = True) And TxtToamt.Text <> "" Then
            If LstvewPhSlab.SelectedItems.Count > 0 Then '10 june
                listIndex = LstvewPhSlab.SelectedItems(0).Index
                Dim totrd As Integer = 0
                Dim cnt2 As Integer = 0
                Dim proces As Double = 0.0
                totrd = LstvewPhSlab.Items.Count
                cnt2 = 0
                If LstvewPhSlab.Items.Count > 0 Then
                    While cnt2 < totrd
                        If cnt2 <> listIndex Then
                            proces = CDbl(LstvewPhSlab.Items(cnt2).SubItems(1).Text)
                            If CDbl(TxtToamt.Text) >= proces Then
                                MsgBox("Duplicate Slab range Can't be Enter should be less than " & LstvewPhSlab.Items(cnt2).SubItems(1).Text, MsgBoxStyle.Information, "Duplicate Record")
                                TxtToamt.Focus()
                                TxtToamt.SelectAll()
                                Exit Sub
                            End If
                        End If
                        cnt2 = cnt2 + 1
                    End While
                End If
                Dim sublst As ListViewItem
                sublst = LstvewPhSlab.Items(listIndex)
                sublst.SubItems(2).Text = FormatNumber(TxtToamt.Text, 2)
                sublst.SubItems(3).Text = CmbxType.Text
                sublst.SubItems(4).Text = TxtSlabrate.Text
                LstvewPhSlab.Items(listIndex).Selected = False
                Dim delconfrm As String
                delconfrm = MsgBox("Do u want to add more Slab rate", MsgBoxStyle.YesNo, "Alert")
                If delconfrm = vbYes Then
                    TxtToamt.Focus()
                    TxtToamt.SelectAll()
                    TxtFromamt_Enter(sender, e)
                Else
                    BtnAdd.Focus()
                End If
            End If
        End If
    End Sub


    Private Sub TxtSlabrate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSlabrate.KeyDown
        Dim a As Double
        Dim Txtto As Double
        If Txtabove.Visible = False Then
            If e.KeyCode = Keys.Enter Then
                If LstvewPhSlab.SelectedItems.Count = 0 Then
                    If Trim(TxtToamt.Text) = Trim(TxtFromamt.Text) Then
                        Me.Width = 412 '422
                    ElseIf Trim(TxtSlabrate.Text) = "" Or Trim(Val(TxtSlabrate.Text)) = 0 Then
                        TxtSlabrate.Focus()
                        TxtSlabrate.SelectAll()
                        Exit Sub
                    Else
                        If TxtToamt.Text <> "Above" Then
                            If TxtToamt.Text <> "" Then
                                Txtto = CDbl(TxtToamt.Text)
                            End If
                        Else
                            Txtto = 1
                            a = 0
                        End If
                        Chk_list_Items()
                        If Indx <> 0 Then
                            Indx = 0
                            Exit Sub
                        ElseIf TxtSlabrate.Text <> "" And a <> Txtto Then
                            Dim totrd As Integer = 0
                            Dim cnt2 As Integer = 0
                            Dim proces As String = ""
                            totrd = LstvewPhSlab.Items.Count
                            cnt2 = 0
                            If CmbxPtype.SelectedIndex = 3 Or CmbxPtype.SelectedIndex = 4 Then '|+
                                If LstvewPhSlab.Items.Count = 1 Then
                                    One_slab_flag = True
                                    MsgBox("Slab Can be one only", MsgBoxStyle.Information, "Alert")
                                    BtnAdd.Focus()
                                    Exit Sub
                                ElseIf LstvewPhSlab.Items.Count > 1 And Add_Edit_Flag = False Then
                                    MsgBox("Slab Can be one only", MsgBoxStyle.Information, "Alert")
                                    LstvewPhSlab.Items.Clear()
                                    TxtFromamt.Text = "0"
                                    TxtToamt.Text = ""
                                    TxtFromamt.Focus()
                                    Exit Sub
                                End If

                            End If '+++++++++++
                            If LstvewPhSlab.Items.Count > 0 Then
                                While cnt2 < totrd
                                    proces = LstvewPhSlab.Items(cnt2).SubItems(1).Text

                                    If proces = TxtToamt.Text And proces <> "Above" Then
                                        MsgBox("Duplicate Slab Can't be Enter", MsgBoxStyle.Information, "Duplicate Record")
                                        TxtFromamt.Focus()
                                        Exit Sub
                                    ElseIf proces = "Above" Then
                                        LstvewPhSlab.Items(cnt2).Remove()

                                    End If
                                    cnt2 = cnt2 + 1
                                End While
                            End If
                            '
                            Dim Sublst As ListViewItem
                            ' Sublst = LstvewPhSlab.Items.Add(Dtpkrefctdt.Text)
                            Sublst = LstvewPhSlab.Items.Add(FormatNumber(TxtFromamt.Text, 2))
                            If TxtToamt.Text <> "Above" Then
                                Sublst.SubItems.Add(FormatNumber(TxtToamt.Text, 2))
                            Else
                                Sublst.SubItems.Add(TxtToamt.Text)
                            End If
                            Sublst.SubItems.Add(CmbxType.Text)
                            Sublst.SubItems.Add(TxtSlabrate.Text)
                            ' Else
                            ' TxtToamt.Focus()
                            'Exit Sub
                            'End If
                            TxtFromamt_Enter(sender, e)
                            If TxtToamt.Text <> "Above" Then
                                a = TxtToamt.Text

                            End If
                            Dim delconfrm As String
                            delconfrm = MsgBox("Do u want to add more Slab rate", MsgBoxStyle.YesNo, "Alert")
                            If delconfrm = vbYes Then
                                TxtToamt.Focus()
                                TxtToamt.SelectAll()
                            Else
                                TxtFromamt_Enter(sender, e)
                                Txtabove.Visible = True
                                Txtabove.Text = "Above"
                                TxtSlabrate.Focus()
                                Exit Sub
                            End If
                        Else
                            '&''MsgBox("jljkljl") 'done by sr
                        End If
                    End If
                End If
            End If
        End If
        If Txtabove.Visible = True Then
            If e.KeyCode = Keys.Enter Then
                If LstvewPhSlab.SelectedItems.Count = 0 Then
                    If Trim(TxtSlabrate.Text) = "" Or Trim(Val(TxtSlabrate.Text)) = 0 Then
                        TxtSlabrate.Focus()
                        TxtSlabrate.SelectAll()
                        Exit Sub
                    Else
                        Chk_list_Items()
                        If Indx <> 0 Then
                            Indx = 0
                            Exit Sub
                        End If
                        Dim totrd As Integer = 0
                        Dim cnt2 As Integer = 0
                        Dim proces As String = ""
                        totrd = LstvewPhSlab.Items.Count
                        cnt2 = 0
                        If CmbxPtype.SelectedIndex = 3 Or CmbxPtype.SelectedIndex = 4 Then
                            If LstvewPhSlab.Items.Count = 1 Then
                                One_slab_flag = True
                                MsgBox("Slab Can be one only", MsgBoxStyle.Information, "Alert")
                                BtnAdd.Focus()
                                Exit Sub
                            End If
                        End If
                        If LstvewPhSlab.Items.Count > 0 Then
                            While cnt2 < totrd
                                proces = LstvewPhSlab.Items(cnt2).SubItems(1).Text
                                If proces = Txtabove.Text And proces <> "Above" Then
                                    MsgBox("Duplicate Slab Can't be Enter", MsgBoxStyle.Information, "Duplicate Record")
                                    TxtSlabrate.Focus()
                                    TxtSlabrate.SelectAll()
                                    Exit Sub
                                ElseIf proces = "Above" Then
                                    LstvewPhSlab.Items(cnt2).Remove()

                                End If
                                cnt2 = cnt2 + 1
                            End While
                        End If
                        Dim Sublst As ListViewItem
                        ' Sublst = LstvewPhSlab.Items.Add(Dtpkrefctdt.Text)
                        Sublst = LstvewPhSlab.Items.Add(FormatNumber(TxtFromamt.Text, 2))
                        Sublst.SubItems.Add(Txtabove.Text)
                        Sublst.SubItems.Add(CmbxType.Text)
                        Sublst.SubItems.Add(TxtSlabrate.Text)
                        BtnAdd.Focus()
                    End If
                ElseIf LstvewPhSlab.SelectedItems.Count > 0 Then
                    If Trim(TxtSlabrate.Text) = "" Or Trim(Val(TxtSlabrate.Text)) = 0 Then
                        TxtSlabrate.Focus()
                        TxtSlabrate.SelectAll()
                        Exit Sub
                    Else
                        Chk_list_Items()
                        If Indx <> 0 Then
                            Indx = 0
                            Exit Sub
                        End If
                        Dim totrd As Integer = 0
                        Dim cnt2 As Integer = 0
                        Dim proces As String = ""
                        totrd = LstvewPhSlab.Items.Count
                        cnt2 = 0
                        If LstvewPhSlab.Items.Count > 0 Then
                            While cnt2 < totrd
                                proces = LstvewPhSlab.Items(cnt2).SubItems(1).Text
                                If proces = Txtabove.Text Then
                                    MsgBox("Duplicate Slab Can't be Enter", MsgBoxStyle.Information, "Duplicate Record")
                                    TxtSlabrate.Focus()
                                    TxtSlabrate.SelectAll()
                                    Exit Sub
                                End If
                                cnt2 = cnt2 + 1
                            End While
                        End If
                        Dim Sublst As ListViewItem
                        '   Sublst = LstvewPhSlab.Items.Add(Dtpkrefctdt.Text)
                        Sublst = LstvewPhSlab.Items.Add(FormatNumber(TxtFromamt.Text, 2))
                        Sublst.SubItems.Add(Txtabove.Text)
                        Sublst.SubItems.Add(CmbxType.Text)
                        Sublst.SubItems.Add(TxtSlabrate.Text)
                        BtnAdd.Focus()
                    End If
                End If
            End If
        End If
        If (Add_Edit_Flag = False Or Add_Edit_Flag = True) And TxtToamt.Text <> "" Or Txtabove.Visible = True And e.KeyCode = Keys.Enter Then
            If e.KeyCode = Keys.Enter Then
                If LstvewPhSlab.SelectedItems.Count > 0 Then '10 june
                    listIndex = LstvewPhSlab.SelectedItems(0).Index
                    Dim totrd As Integer = 0
                    Dim changeval As Double = 0.0
                    Dim diff As Double = 0.0
                    Dim fromamt As Double = 0.0
                    Dim toamt As Double = 0.0
                    Dim res As Double = 0.0
                    Dim cnt2 As Integer = 0
                    Dim proces As Double = 0.0
                    totrd = LstvewPhSlab.Items.Count
                    cnt2 = 0
                    If LstvewPhSlab.Items.Count > 0 Then
                        While cnt2 < totrd
                            If cnt2 > listIndex Then ' Or (cnt2 = listIndex And Txtabove.Visible <> True)
                                proces = CDbl(LstvewPhSlab.Items(cnt2).SubItems(0).Text)
                                ' If TxtToamt.Text <> "Above" Then
                                If CDbl(TxtToamt.Text) >= proces Then 'this will automaticaly update in chainCDbl(TxtToamt.Text) <= proces 
                                    Dim delconfrm1 As String
                                    delconfrm1 = MsgBox("Slab range is greater than " & LstvewPhSlab.Items(cnt2).SubItems(1).Text & " do u want to continue", MsgBoxStyle.YesNo, "Close Section")
                                    If delconfrm1 = vbYes Then
                                        changeval = CDbl(TxtToamt.Text)
                                        While cnt2 < LstvewPhSlab.Items.Count
                                            fromamt = CDbl(LstvewPhSlab.Items(cnt2).SubItems(0).Text)
                                            If LstvewPhSlab.Items(cnt2).SubItems(1).Text <> "Above" Then
                                                toamt = CDbl(LstvewPhSlab.Items(cnt2).SubItems(1).Text)
                                                diff = Math.Abs(fromamt - toamt)
                                                changeval += 1
                                                LstvewPhSlab.Items(cnt2).SubItems(0).Text = FormatNumber(changeval, 2)
                                                res = changeval + diff
                                                LstvewPhSlab.Items(cnt2).SubItems(1).Text = FormatNumber(res, 2)
                                                changeval = CDbl(LstvewPhSlab.Items(cnt2).SubItems(1).Text)
                                                cnt2 += 1
                                            Else
                                                changeval += 1
                                                LstvewPhSlab.Items(cnt2).SubItems(0).Text = FormatNumber(changeval, 2)
                                                LstvewPhSlab.Items(cnt2).SubItems(1).Text = "Above"
                                                cnt2 += 1
                                            End If
                                        End While
                                    Else
                                        TxtToamt.Focus()
                                        TxtToamt.SelectAll()
                                        Exit Sub
                                    End If
                                    'ElseIf CDbl(TxtToamt.Text) <= proces Then
                                    '    TxtToamt.Focus()
                                    '    TxtToamt.SelectAll()
                                    '    Exit Sub
                                End If
                            End If
                            ' End If
                            cnt2 = cnt2 + 1
                        End While
                    End If
                    Dim sublst As ListViewItem
                    sublst = LstvewPhSlab.Items(listIndex)
                    If sublst.SubItems(1).Text <> "Above" And TxtToamt.Text <> "Above" Then
                        sublst.SubItems(1).Text = FormatNumber(TxtToamt.Text, 2)
                    Else
                        sublst.SubItems(1).Text = TxtToamt.Text
                    End If
                    sublst.SubItems(2).Text = CmbxType.Text
                    sublst.SubItems(3).Text = TxtSlabrate.Text
                    LstvewPhSlab.Items(listIndex).Selected = False
                    Dim delconfrm As String
                    delconfrm = MsgBox("Do u want to add more Slab rate", MsgBoxStyle.YesNo, "Alert")
                    If delconfrm = vbYes Then
                        Dim i As Integer = 0
                        While i < LstvewPhSlab.Items.Count
                            If LstvewPhSlab.Items(i).SubItems(1).Text = "Above" Then
                                LstvewPhSlab.Items.RemoveAt(i)
                                Exit While
                            End If
                            i += 1
                        End While
                        TxtToamt.Focus()
                        TxtToamt.SelectAll()
                        TxtFromamt_Enter(sender, e)
                    Else
                        Dim i As Integer = 0
                        Dim flag As Integer = 0
                        While i < LstvewPhSlab.Items.Count
                            If LstvewPhSlab.Items(i).SubItems(1).Text = "Above" Then
                                flag = 1
                                BtnAdd.Focus()
                                Exit Sub
                            End If
                            i += 1
                        End While
                        TxtFromamt_Enter(sender, e)
                        Txtabove.Visible = True
                        Txtabove.Text = "Above"
                        TxtSlabrate.Focus()
                        Exit Sub
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Chk_list_Items()
        With TxtFromamt
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With


        With CmbxType
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        If Txtabove.Visible = False Then
            With TxtToamt
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    Indx += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtSlabrate
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    Indx += 1
                Else
                    .BackColor = Color.White
                End If
            End With

            Dim val As Double
            If TxtFromamt.Text <> "" Then
                val = TxtFromamt.Text
            End If
            If TxtToamt.Text <> "" And TxtToamt.Text <> "Above" Then

                If TxtToamt.Text <= val Then
                    TxtToamt.BackColor = Color.PapayaWhip
                    TxtToamt.SelectAll()
                    TxtToamt.Focus()
                    Indx += 1
                Else
                    TxtToamt.BackColor = Color.White
                End If
            End If
        End If
        'If Txtabove.Visible = True Then
        '    Dim i As Integer = 0
        '    Dim Sublst As ListViewItem
        '    Sublst = LstvewPhSlab.Items(0)
        '    While i < LstvewPhSlab.Items.Count
        '        If Sublst.SubItems.Item(i).Text = "Above" Then
        '            Indx = 0
        '            Exit Sub
        '        Else
        '            Indx += 1
        '        End If
        '        i += 1
        '    End While
        'End If
    End Sub

    Private Sub Fetch_list_text()
        If LstvewPhSlab.Items.Count > 0 Then
            Dim Sublst As ListViewItem
            listIndex = LstvewPhSlab.SelectedItems(0).Index
            Sublst = LstvewPhSlab.SelectedItems(0)
            'Dtpkrefctdt.Text = Sublst.SubItems.Item(0).Text
            TxtFromamt.Text = Sublst.SubItems.Item(0).Text
            If Sublst.SubItems.Item(1).Text <> "Above" Then
                TxtToamt.Text = Sublst.SubItems.Item(1).Text
                CmbxType.Text = Sublst.SubItems.Item(2).Text
                TxtSlabrate.Text = Sublst.SubItems.Item(3).Text
            Else
                TxtToamt.Text = ""
                CmbxType.Text = Sublst.SubItems.Item(2).Text
                TxtSlabrate.Text = Sublst.SubItems.Item(3).Text

                LstvewPhSlab.Items(listIndex).Remove()

            End If

            Txtabove.Visible = False
        End If
    End Sub

    Private Sub LstvewPhSlab_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstvewPhSlab.DoubleClick
        Fetch_list_text()
        If TxtToamt.Text = "" Then
            TxtToamt.Focus()

        End If
    End Sub

    Private Sub TxtPayhed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPayhed.TextChanged
        If new_ph1 <> 1 Then
            TxtApearName.Text = Trim(TxtPayhed.Text.ToUpper)
        End If

    End Sub

    Private Sub RbYn2_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbYn2.Click
        If RbYn2.Checked = True Then
            TxtApearName.Text = Trim("")
            TxtApearName.ReadOnly = True
            RbYn3.Focus()
        End If
    End Sub

    Private Sub Dtpkrefctdt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            TxtFromamt.Focus()
        End If
    End Sub

    Private Sub TxtFromamt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFromamt.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtToamt.Focus()
        End If
    End Sub

    Private Sub TxtToamt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtToamt.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbxType.Focus()
        End If
    End Sub

    Private Sub CmbxType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxType.GotFocus
        If CmbxType.SelectedIndex = -1 Then
            CmbxType.SelectedIndex = 0
        End If
    End Sub
    Private Sub CmbxType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not CmbxType.SelectedIndex = -1 Then
                TxtSlabrate.Focus()
            End If
        End If
    End Sub

    Private Sub del_rd()
        delstatus = 1
        If CmbxMoCal.Text <> "As User Defined Value" Then
            Fetch_Concrnid()
            Try
                Pay_Head_Cmd = New SqlCommand("Finact_Slabrate_Delete", FinActConn)
                Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                Pay_Head_Cmd.Parameters.AddWithValue("@Sratedelusrid", Current_UsrId)
                Pay_Head_Cmd.Parameters.AddWithValue("@SrateDeldt", Now)
                Pay_Head_Cmd.Parameters.AddWithValue("@SrateDelStatus", delstatus)
                Pay_Head_Cmd.Parameters.AddWithValue("@SrateConId", ConCerId)
                Pay_Head_Cmd.ExecuteNonQuery()
            Catch EX As Exception
                MsgBox(EX.Message)
            Finally
                Pay_Head_Cmd = Nothing
            End Try
            Try
                Pay_Head_Cmd = New SqlCommand("FinAct_PayHeadFormula_Delete", FinActConn)
                Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
                Pay_Head_Cmd.Parameters.AddWithValue("@EmpDelStatus", delstatus)
                Pay_Head_Cmd.Parameters.AddWithValue("@PayheadConId", ConCerId)
                Pay_Head_Cmd.Parameters.AddWithValue("@EmpPhDeldt", Now)
                Pay_Head_Cmd.ExecuteNonQuery()
            Catch EX As Exception
                MsgBox(EX.Message)
            Finally
                Pay_Head_Cmd = Nothing
            End Try
        End If
        Try
            fetch_head_id()
            Pay_Head_Cmd = New SqlCommand("Finact_PayHead_Delete", FinActConn)
            Pay_Head_Cmd.CommandType = CommandType.StoredProcedure
            Pay_Head_Cmd.Parameters.AddWithValue("@PheadDelusrid", Current_UsrId)
            Pay_Head_Cmd.Parameters.AddWithValue("@PheadDeldt", Now)
            Pay_Head_Cmd.Parameters.AddWithValue("@PheadDelStatus", delstatus)
            Pay_Head_Cmd.Parameters.AddWithValue("@PheadId ", mainhid)
            Pay_Head_Cmd.ExecuteNonQuery()
        Catch EX As Exception
            MsgBox(EX.Message)
        Finally
            Pay_Head_Cmd = Nothing
        End Try
        MsgBox("Current Record has been Deleted", MsgBoxStyle.Information, "Record Deleted")
    End Sub

    Private Sub Btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndel.Click
        Dim delconfrm As String
        delconfrm = MsgBox("Are you sure to delete record", MsgBoxStyle.YesNo, "Delete Record")
        If delconfrm = vbYes Then
            del_rd()
            Clrvalues()
        End If
    End Sub

    Private Sub TxtFromamt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFromamt.Enter
        TxtFromamt.Text = 0
        Dim counter As Integer
        Dim total As Integer
        total = LstvewPhSlab.Items.Count
        counter = 0
        While counter < total
            If LstvewPhSlab.Items(counter).SubItems(1).Text <> "" Then
                If LstvewPhSlab.Items(counter).SubItems(1).Text <> "Above" Then
                    TxtFromamt.Text = CDbl(LstvewPhSlab.Items(counter).SubItems(1).Text) + 1
                End If
            End If
            counter += 1
        End While
    End Sub

    Private Sub RbYn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbYn1.Click
        If RbYn1.Checked = True Then
            TxtApearName.Text = Trim(TxtPayhed.Text.ToUpper)
            TxtApearName.ReadOnly = False
            TxtApearName.Focus()
        End If
    End Sub


    Private Sub CmbxComptype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxComptype.SelectedIndexChanged
        Dim i As Integer = 0
        Radf3.Enabled = True
        If CmbxMoCal.Text <> "As User Defined Value" And CmbxMoCal.Text <> "" Then
            If CmbxComptype.Text = "On Specified Formula" And Add_Edit_Flag = True Then
                Labformula.Visible = True
                If CmbxMoCal.Text = "on Production/Performance value" Then
                    Panel4.Visible = True
                    Panel3.Visible = False
                    Radf4.Checked = True
                    Me.Width = 872 '957 'Acheved target
                    Me.pnlPhSlab.Enabled = True
                    Me.DataGrid.Visible = False
                    Me.pnlPhSlab.Visible = True
                    Me.Lblcompu.Text = Me.CmbxComptype.Text
                    Me.pnlPhSlab.Location = New System.Drawing.Point(419, 38) '419, 13)'19 june
                    'Me.DataGrid.Location = New System.Drawing.Point(419, 13) '422, 263)
                Else
                    Panel4.Visible = False
                    Panel3.Visible = True
                    Radf2.Checked = True
                    Me.Width = 872 '957
                    Me.pnlPhSlab.Enabled = True
                    Me.pnlPhSlab.Visible = True
                    Me.pnlPhSlab.Location = New System.Drawing.Point(419, 210) '419, 13)
                    Me.DataGrid.Location = New System.Drawing.Point(419, 38) '422, 263)
                    Me.Lblcompu.Text = Me.CmbxComptype.Text
                    DataGrid.Visible = True
                    DataGrid.Rows.Clear()
                    Me.DataGrid.AllowUserToAddRows = True
                    Try
                        Pay_Head_Cmd = New SqlCommand("Select PheadName,Pheadid from FinActPayHead where PheadDelstatus<>'" & (1) & "' order by PheadName", FinActConn)
                        Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
                        While Pay_Head_Rdr.Read()
                            datgrid_flag = False
                            DataGrid.Rows.Add()
                            DataGrid.Rows(i).Cells(1).Value = Pay_Head_Rdr(0)
                            DataGrid.Rows(i).Cells(3).Value = Pay_Head_Rdr(1)
                            i += 1
                        End While
                        Me.DataGrid.AllowUserToAddRows = False
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        If Pay_Head_Rdr.HasRows = False Then
                            Pay_Head_Rdr.Close()
                            Pay_Head_Cmd = Nothing
                            DataGrid.Visible = False
                            Radf3.Enabled = False
                            If datgrid_flag = False Then
                                datgrid_flag = True
                                Me.Width = 413
                                MsgBox("No Formula Can be added choose another option", MsgBoxStyle.Critical, "Find Item Section")
                            End If
                        End If
                        Pay_Head_Rdr.Close()
                        Pay_Head_Cmd = Nothing
                    End Try
                    i = 0
                    While i < DataGrid.Rows.Count
                        DataGrid.Rows(i).Cells(2).Value = Me.Column3.Items.Item(0)
                        i += 1
                    End While
                    If datgrid_flag = True Then
                        '
                        CmbxComptype.Focus()
                        Exit Sub
                    End If
                    DataGrid.Focus()
                    If DataGrid.Rows.Count > 0 Then
                        DataGrid.CurrentCell = DataGrid.Rows(0).Cells(0)
                    End If

                End If
            ElseIf CmbxComptype.Text = "On Basic" And Add_Edit_Flag = True And CmbxMoCal.Text <> "As User Defined Value" Then
                Labformula.Visible = True
                Panel4.Visible = False
                Panel3.Visible = True
                Radf2.Checked = True
                Me.Width = 872 '957
                Me.pnlPhSlab.Enabled = True
                Me.pnlPhSlab.Visible = True
                Me.pnlPhSlab.Location = New System.Drawing.Point(419, 38)
                Me.Lblcompu.Text = Me.CmbxComptype.Text
                DataGrid.Visible = False
                TxtFromamt.Focus()
            ElseIf Add_Edit_Flag = False And CmbxMoCal.Text <> "As User Defined Value" And fetch_rd_flag = False And mainhedrd = False Then
                Labformula.Visible = True
                If CmbxMoCal.Text = "on Production/Performance value" And CmbxComptype.Text = "On Specified Formula" Then
                    Panel4.Visible = True
                    Radf4.Checked = True
                    Panel3.Visible = False
                    Me.Width = 872 '957 'Acheved target
                    Me.pnlPhSlab.Enabled = True
                    Me.pnlPhSlab.Visible = True
                    Me.Lblcompu.Text = Me.CmbxComptype.Text
                    Me.pnlPhSlab.Location = New System.Drawing.Point(419, 38)
                    DataGrid.Visible = False
                    TxtFromamt.Focus()
                ElseIf CmbxComptype.Text <> "On Basic" And CmbxMoCal.Text <> "on Production/Performance value" Then
                    Panel4.Visible = False
                    Panel3.Visible = True
                    Radf2.Checked = True
                    Me.Width = 872 '957
                    Me.pnlPhSlab.Enabled = True
                    Me.pnlPhSlab.Visible = True
                    Me.Lblcompu.Text = Me.CmbxComptype.Text
                    Me.pnlPhSlab.Location = New System.Drawing.Point(419, 210)
                    Me.DataGrid.Location = New System.Drawing.Point(419, 38)
                    DataGrid.Visible = True
                    DataGrid.Rows.Clear()
                    Me.DataGrid.AllowUserToAddRows = True
                    Try
                        Pay_Head_Cmd = New SqlCommand("Select PheadName,Pheadid from FinActPayHead where PheadDelstatus<>'" & (1) & "' order by PheadName", FinActConn)
                        Pay_Head_Rdr = Pay_Head_Cmd.ExecuteReader
                        While Pay_Head_Rdr.Read()
                            DataGrid.Rows.Add()
                            DataGrid.Rows(i).Cells(1).Value = Pay_Head_Rdr(0)
                            DataGrid.Rows(i).Cells(3).Value = Pay_Head_Rdr(1)
                            i += 1
                        End While
                        Me.DataGrid.AllowUserToAddRows = False
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        If Pay_Head_Rdr.HasRows = False Then
                            Pay_Head_Rdr.Close()
                            Pay_Head_Cmd = Nothing
                            DataGrid.Visible = False
                            Radf3.Enabled = False
                            If datgrid_flag = False Then
                                datgrid_flag = True
                                MsgBox("No Formula Can be added choose another option", MsgBoxStyle.Critical, "Find Item Section")
                            End If
                        End If
                        Pay_Head_Rdr.Close()
                        Pay_Head_Cmd = Nothing
                    End Try
                    i = 0
                    While i < DataGrid.Rows.Count
                        DataGrid.Rows(i).Cells(2).Value = Me.Column3.Items.Item(0)
                        i += 1
                    End While
                    If datgrid_flag = True Then
                        CmbxComptype.Focus()
                        Exit Sub
                    End If
                    DataGrid.Focus()
                    If DataGrid.Rows.Count > 0 Then
                        DataGrid.CurrentCell = DataGrid.Rows(0).Cells(0)
                    End If
                ElseIf CmbxComptype.Text = "On Basic" And CmbxMoCal.Text <> "As User Defined Value" Then
                    Labformula.Visible = True
                    Panel4.Visible = False
                    Panel3.Visible = True
                    Radf2.Checked = True
                    Me.Width = 872 '957
                    Me.pnlPhSlab.Enabled = True
                    Me.pnlPhSlab.Visible = True
                    Me.pnlPhSlab.Location = New System.Drawing.Point(419, 38)
                    Me.Lblcompu.Text = Me.CmbxComptype.Text
                    DataGrid.Visible = False
                    TxtFromamt.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub TxtFromamt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFromamt.TextChanged
        TxtFromamt.ReadOnly = True
    End Sub

    Private Sub TxtPayhed_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPayhed.Validating
        If Trim(TxtPayhed.Text.Length) = 0 Then
            TxtPayhed.Focus()
            Beep()
        End If
    End Sub

    Private Sub RbYn1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbYn1.KeyDown
        If e.KeyCode = Keys.Enter Then
            RbYn1_Click(sender, e)
        End If
    End Sub

    Private Sub RbYn2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbYn2.KeyDown
        If e.KeyCode = Keys.Enter Then
            RbYn2_click(sender, e)
        End If
    End Sub
    Private Sub TxtApearName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtApearName.Validated
        If Trim(TxtApearName.Text.Length) = 0 And new_ph1 <> 1 Then
            TxtApearName.Text = Trim(TxtPayhed.Text.ToUpper)
        End If
    End Sub

    Private Sub RbYn3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbYn3.Click
        If RbYn3.Checked = True Then
            Gruity = True
        Else
            Gruity = False
        End If
        CmbxMoCal.Focus()
    End Sub

    Private Sub RbYn4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbYn4.Click
        If RbYn4.Checked = True Then
            Gruity = False
        Else
            Gruity = True
        End If
        CmbxMoCal.Focus()
    End Sub

    Private Sub RbYn3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbYn3.KeyDown
        If e.KeyCode = Keys.Enter Then
            RbYn3_Click(sender, e)
        End If
    End Sub

    Private Sub RbYn4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbYn4.KeyDown
        If e.KeyCode = Keys.Enter Then
            RbYn4_Click(sender, e)
        End If
    End Sub

    Private Sub TxtToamt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtToamt.Validated
        If Trim(TxtToamt.TextLength) = 0 Then
            TxtToamt.Focus()
        End If
    End Sub

    Private Sub Esckpress_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxComptype.KeyDown
        If e.KeyCode = Keys.Enter Then
            If CmbxComptype.Text = Trim("On Specified Formula") Then
                TxtToamt.Focus()
                If DataGrid.Rows.Count > 0 Then
                    DataGrid.CurrentCell = DataGrid.Rows(0).Cells(0)
                End If
            ElseIf CmbxComptype.Text = Trim("On Basic") Then
                DataGrid.Visible = False
                TxtToamt.Focus()
            End If
        End If
    End Sub

    Private Sub LstvewPhSlab_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstvewPhSlab.KeyDown
        If e.KeyCode = Keys.Enter And Add_Edit_Flag = False Then
            If LstvewPhSlab.Items.Count > 0 Then
                Fetch_list_text()
            End If
        End If
    End Sub
    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnAdd.KeyDown, btnclose.KeyDown, Btndel.KeyDown, BtnEdt.KeyDown, CmbxComptype.KeyDown, Cmbxid.KeyDown, CmbxMoCal.KeyDown, CmbxPtype.KeyDown, CmbxType.KeyDown, CmbxUndrType.KeyDown, Label4.KeyDown, Label6.KeyDown, Lblcompu.KeyDown, Lblcomtyp.KeyDown, Lblhtype.KeyDown, Lblid.KeyDown, Lblmd.KeyDown, Lblphname.KeyDown, Lblslipnm.KeyDown, Lblslpnm.KeyDown, Lblslpnm.KeyDown, Lblutype.KeyDown, LstvewPhSlab.KeyDown, Panel1.KeyDown, Panel2.KeyDown, pnlPhSlab.KeyDown, RbYn1.KeyDown, RbYn2.KeyDown, RbYn3.KeyDown, RbYn4.KeyDown, TxtApearName.KeyDown, TxtFromamt.KeyDown, TxtPayhed.KeyDown, TxtSlabrate.KeyDown, TxtToamt.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub DataGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGrid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim delconfrm As String
            delconfrm = MsgBox("Are you sure to Exit", MsgBoxStyle.YesNo, "Exit")
            If delconfrm = vbYes Then
                If pnlPhSlab.Visible = True Then
                    TxtToamt.Focus()
                Else
                    BtnAdd.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub TxtPayhed_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPayhed.Leave

        If TxtPayhed.Text <> "" Then
            chk_dupli_pheadname()
            chkdupliitm = False
        End If
        comboflag = False

    End Sub
    Private Sub Radf3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Radf3.CheckedChanged
        Dim datgrid_flag As Boolean = False
        If Radf3.Checked = True And fetch_rd_flag <> True And mainhedrd = False Then
            If CmbxMoCal.Text = "on Production/Performance value" Then
                Panel4.Visible = True
                Panel3.Visible = False
                Me.Width = 872 '957 'Acheved target
                Me.pnlPhSlab.Enabled = True
                Me.pnlPhSlab.Visible = True
                Me.Lblcompu.Text = Me.CmbxComptype.Text
                Me.pnlPhSlab.Location = New System.Drawing.Point(419, 38)
                DataGrid.Visible = False
                TxtFromamt.Focus()
            End If
        End If
    End Sub
    Private Sub Radf4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Radf4.CheckedChanged
        If Radf4.Checked = True And fetch_rd_flag <> True And mainhedrd = False Then
            If CmbxMoCal.Text = "on Production/Performance value" Then
                Panel4.Visible = True
                Panel3.Visible = False
                Me.Width = 872 '957 'Acheved target
                Me.pnlPhSlab.Enabled = True
                Me.pnlPhSlab.Visible = True
                Me.Lblcompu.Text = Me.CmbxComptype.Text
                Me.pnlPhSlab.Location = New System.Drawing.Point(419, 38)
                DataGrid.Visible = False
                TxtFromamt.Focus()
            End If
        End If
    End Sub
    Private Sub CmbxComptype_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxComptype.Leave
        datgrid_flag = False
    End Sub
    Private Sub DataGrid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid.Leave
        Dim i As Integer = 0
        If DataGrid.Visible = True Then
            Lblfor_ph.Text = ""
            Lblfor_ph.Text = "Basic"
            While i < DataGrid.Rows.Count
                If DataGrid.Rows(i).Cells(0).Value = "True" Then
                    Lblfor_ph.Visible = True
                    Lblgrdfor.Visible = True
                    If DataGrid.Rows(i).Cells(2).Value = "Add" Then
                        Lblfor_ph.Text += " + " & DataGrid.Rows(i).Cells(1).Value
                        plus_flag = True
                    Else
                        Lblfor_ph.Text += " - " & DataGrid.Rows(i).Cells(1).Value
                    End If
                End If
                i += 1
            End While
        End If
    End Sub
    Private Sub Radf2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Radf2.CheckedChanged
        If Radf2.Checked = True And fetch_rd_flag <> True And mainhedrd = False Then
            If pnlPhSlab.Visible = True And DataGrid.Visible = False Then
                TxtToamt.Focus()
            ElseIf pnlPhSlab.Visible = False And DataGrid.Visible = True Then
                TxtToamt.Focus()
                If DataGrid.Rows.Count > 0 Then
                    DataGrid.CurrentCell = DataGrid.Rows(0).Cells(0)
                End If
            End If
        End If
    End Sub
    Private Sub Radf1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Radf1.CheckedChanged
        If Radf1.Checked = True And fetch_rd_flag <> True And mainhedrd = False Then
            If pnlPhSlab.Visible = True And DataGrid.Visible = False Then
                TxtToamt.Focus()
            ElseIf pnlPhSlab.Visible = False And DataGrid.Visible = True Then
                TxtToamt.Focus()
                If DataGrid.Rows.Count > 0 Then
                    DataGrid.CurrentCell = DataGrid.Rows(0).Cells(0)
                End If
            End If
        End If
    End Sub
    Private Sub ena_tru()
        Panel5.Visible = True
        Lblbonus.Visible = True
        Label6.Visible = False
    End Sub
    Private Sub cmbxyype_false()

        CmbxMoCal.Visible = False
        Panel1.Visible = False
        Panel2.Visible = False
        CmbxComptype.Visible = False
        TxtApearName.Visible = False
        Label4.Visible = False
        Lblslpnm.Visible = False

    End Sub

    Private Sub CmbxPtype_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPtype.Leave
        str_CmbxPtype = ""
        If CmbxPtype.Text <> "" Then
            str_CmbxPtype = CmbxPtype.Text
            chk_dupli_pheadtype()
            If chkdupliitm <> False Then
                CmbxPtype.Focus()
                chkdupliitm = False
                Flag1 = True
                Exit Sub
            End If
            If CmbxPtype.SelectedIndex = 6 Then
                Lblmd.Visible = False
                Lblcomtyp.Visible = False

                LblPF.Visible = True
                LblPensn.Visible = True
                TxtPF.Visible = True
                TxtPens.Visible = True
                LblPerc1.Visible = True
                LblPerc2.Visible = True
            Else
                Lblmd.Visible = True
                Lblcomtyp.Visible = True

                LblPF.Visible = False
                LblPensn.Visible = False
                TxtPF.Visible = False
                TxtPens.Visible = False
                LblPerc1.Visible = False
                LblPerc2.Visible = False
            End If
            If CmbxPtype.SelectedIndex = 5 Then
                Me.Height = 276 '236
                Me.Width = 413
                Lblbonus.Text = "ESI Rate"
                ena_tru()

                cmbxyype_false()
            ElseIf CmbxPtype.SelectedIndex = 6 Then
                Me.Height = 276 '236
                Me.Width = 413
                Lblbonus.Text = "PF Rate"
               

                LblPF.Location = New System.Drawing.Point(8, 192)
                LblPensn.Location = New System.Drawing.Point(8, 231)
                TxtPF.Location = New System.Drawing.Point(141, 193)
                TxtPens.Location = New System.Drawing.Point(141, 232)
                LblPerc1.Location = New System.Drawing.Point(208, 196)
                LblPerc2.Location = New System.Drawing.Point(208, 235)
                'Lblmd.Visible = False
                'Lblcomtyp.Visible = False
                Me.Size = New System.Drawing.Point(419, 343)
                ena_tru()
                cmbxyype_false()
            ElseIf CmbxPtype.SelectedIndex = 7 Then
                Me.Height = 276 '236
                Me.Width = 413
                Lblbonus.Text = "Bonus Rate"
                ena_tru()
                cmbxyype_false()

            ElseIf CmbxPtype.SelectedIndex <> 5 Or CmbxPtype.SelectedIndex <> 6 Or CmbxPtype.SelectedIndex <> 7 Then
                If Add_Edit_Flag = True Then
                    'Me.Width = 957
                    'Me.Height = 521
                    CmbxComptype.Visible = False
                    Labformula.Visible = False
                    Labenter.Visible = False
                    Me.pnlPhSlab.Visible = False
                    Panel4.Visible = False
                    Panel3.Visible = False
                    DataGrid.Visible = False
                    Lblcomtyp.Visible = False
                    Panel5.Visible = False
                    Lblbonus.Visible = False
                    CmbxMoCal.Visible = True
                    CmbxUndrType.Visible = True
                    Panel1.Visible = True
                    Panel2.Visible = True
                    TxtApearName.Visible = True
                    Lblutype.Visible = True
                    Label4.Visible = True
                    Label6.Visible = True
                    Lblslpnm.Visible = True

                End If
                If Add_Edit_Flag = False Then
                    If pnlPhSlab.Visible = True Then
                        Me.Width = 872 '957
                        Me.Height = 521
                        Label6.Visible = True
                        Panel5.Visible = False
                        Lblbonus.Visible = False
                        CmbxMoCal.Visible = True
                        CmbxUndrType.Visible = True
                        CmbxComptype.Visible = True
                        Panel1.Visible = True
                        Panel2.Visible = True
                        TxtApearName.Visible = True
                        Lblutype.Visible = True
                        Label4.Visible = True
                        Lblslpnm.Visible = True
                    Else
                        Me.Width = 413
                        Me.Height = 521
                        Panel5.Visible = False
                        Lblbonus.Visible = False
                        CmbxMoCal.Visible = True
                        CmbxUndrType.Visible = True
                        ' CmbxComptype.Visible = True
                        Panel1.Visible = True
                        Panel2.Visible = True
                        TxtApearName.Visible = True
                        Lblutype.Visible = True
                        Label4.Visible = True
                        Lblslpnm.Visible = True
                        Label6.Visible = True
                    End If
                Else
                    Me.Height = 413
                    Me.Width = 413
                End If
            End If
        End If
    End Sub
    Private Sub set_height()
        If CmbxPtype.SelectedIndex = 5 Then
            Me.Height = 276 '236
            Me.Width = 413
        ElseIf CmbxPtype.SelectedIndex = 6 Then
            Me.Height = 276 '236
            Me.Width = 413


        ElseIf CmbxPtype.SelectedIndex = 7 Then
            Me.Height = 276 '236
            Me.Width = 413


        ElseIf CmbxPtype.SelectedIndex <> 5 Or CmbxPtype.SelectedIndex <> 6 Or CmbxPtype.SelectedIndex <> 7 Then
            If CmbxPtype.SelectedIndex <> 0 Then


                If pnlPhSlab.Visible = True Then
                    Me.Width = 872 '957
                    Me.Height = 521
                Else
                    Me.Width = 413
                    Me.Height = 521
                End If
            Else
                Me.Height = 413
                Me.Width = 413
            End If

        End If
    End Sub

    Private Sub set_height_emplst()
        If CmbxPtype.SelectedIndex = 5 Then
            Me.Height = 456 ' 276 '236
            Link1.Visible = True
            Link2.Visible = False
            Link3.Visible = False
            Lstemp.Location = New System.Drawing.Point(9, 189)
            Me.Width = 413
        ElseIf CmbxPtype.SelectedIndex = 6 Then
            Me.Height = 550
            Link1.Visible = True
            Link2.Visible = False
            Link3.Visible = False
            ' Me.Height = 456 ' 276 '236
            Lstemp.Location = New System.Drawing.Point(11, 268)
            Me.Width = 413

        ElseIf CmbxPtype.SelectedIndex = 7 Then
            Link1.Visible = True
            Link2.Visible = False
            Link3.Visible = False
            Me.Height = 456 ' 276 '236
            Lstemp.Location = New System.Drawing.Point(9, 189)
            Me.Width = 413

        ElseIf CmbxPtype.SelectedIndex <> 5 Or CmbxPtype.SelectedIndex <> 6 Or CmbxPtype.SelectedIndex <> 7 Then
            'If CmbxPtype.SelectedIndex <> 0 Then


            If pnlPhSlab.Visible = True Then
                If Lblfor_ph.Visible = False Then
                    Link3.Visible = True
                    Link1.Visible = False
                    Link2.Visible = False
                    Me.Height = 641 ' 276 '236
                    Lstemp.Location = New System.Drawing.Point(18, 365)
                    Me.Width = 872 '957
                Else
                    Link3.Visible = True
                    Link1.Visible = False
                    Link2.Visible = False
                    Me.Height = 652
                    ' Me.Height = 872
                    Lstemp.Location = New System.Drawing.Point(25, 393)

                    Me.Width = 872 '957
                End If

            Else
                Link2.Visible = True
                Link1.Visible = False
                Link3.Visible = False
                Me.Height = 603 ' 276 '236
                Lstemp.Location = New System.Drawing.Point(21, 331)
                Me.Width = 413
            End If
            'Else
            ' Me.Height = 603 ' 276 '236
            'Lstemp.Location = New System.Drawing.Point(21, 331)
            '     Me.Width = 413
        End If

        'End If
    End Sub
    Private Sub Txtbonus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbonus.GotFocus
        foc_falg = False
    End Sub
    Private Sub Txtbonus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtbonus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txtbonus.Text = "" Then
                Txtbonus.Focus()
            Else
                TxtPF.Focus()
            End If
        End If
    End Sub
    Private Sub Txtbonus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtbonus.KeyPress
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "." Then
            e.Handled = False
            If Not (IsNumeric(tb.Text & e.KeyChar)) Then
                e.Handled = True
                MsgBox("Enter Valid Number")
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtbonus_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbonus.Leave
        If Txtbonus.Text <> "" And foc_falg = False Then
            Dim bons As Double
            bons = CDbl(Txtbonus.Text)
            If bons < 8.33 And CmbxType.Text = Trim("Bonus") Then
                foc_falg = True
                MsgBox("Bonus must be >= 8.33 %", MsgBoxStyle.Information, "Alert")
                Txtbonus.Focus()
                Txtbonus.SelectAll()
            ElseIf bons <= 0 Then
                foc_falg = True
                MsgBox("Esi/Pf can't be 0 %", MsgBoxStyle.Information, "Alert")
                Txtbonus.Focus()
                Txtbonus.SelectAll()
            End If
        End If

        'If CmbxPtype.Text = "Employer's Contribution For PF" Then
        '    If TxtPF.Text <> "" And TxtPens.Text <> "" Then
        '        TxtPF.Text = ""

        '    End If
        'End If
    End Sub
    Private Sub dtp1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txtbonus.Visible = True Then
                Txtbonus.Focus()
                Exit Sub
            End If
            RbYn1.Focus()
        End If
    End Sub

    Private Sub FrmPayhed_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        BtnAdd.Focus()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link3.LinkClicked, Link2.LinkClicked, Link1.LinkClicked
        If Lstemp.Items.Count > 0 Then
            Dim i As Integer = 0
            While i < Lstemp.Items.Count
                Lstemp.Items(i).Checked = True
                i += 1
            End While
        End If
    End Sub


    Private Sub TxtPF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPF.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtPF.Text = "" Then
                TxtPF.Focus()
            Else
                TxtPens.Text = CDbl(Txtbonus.Text) - CDbl(TxtPF.Text)
                TxtPens.Focus()
            End If
        End If
    End Sub


    Private Sub TxtPens_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPens.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtPens.Text = "" Then
                TxtPens.Focus()
            Else
                BtnAdd.Focus()
            End If
        End If
    End Sub
  
    Private Sub TxtPF_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPF.Leave
        If Txtbonus.Text <> "" And TxtPF.Text <> "" Then
            TxtPens.Text = CDbl(Txtbonus.Text) - CDbl(TxtPF.Text)
        End If

    End Sub


    Private Sub Cmbxid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxid.SelectedIndexChanged

    End Sub

    Private Sub CmbxPtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxPtype.SelectedIndexChanged

    End Sub

    Private Sub LstvewPhSlab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstvewPhSlab.SelectedIndexChanged

    End Sub
End Class

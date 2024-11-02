Imports System.Data
Imports System.Data.SqlClient
Public Class FrmJrnl
    Inherits System.Windows.Forms.Form
    Dim Csh_Bnk_Cmd As SqlCommand
    Dim Csh_Bnk_rdr As SqlDataReader
    Dim Csh_Bnk_Cmd1 As SqlCommand
    Dim Csh_Bnk_rdr1 As SqlDataReader
    Dim Csh_Bnk_Sqladptr As SqlDataAdapter
    Dim Csh_Bnk_Dset As DataSet
    Dim CurrentDate As Date
    Dim TranType As String
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim AcGdgr As DataGridViewRow
    Dim AcGcel As DataGridViewTextBoxCell
    Dim AcGcom As DataGridViewComboBoxCell
    Dim xXcol As Integer = 0, xYrow As Integer = 0
    Dim IndxMstr As Integer
    Friend WithEvents Ballabel As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Dim invalid As Integer
    Dim Add_Edit_Flag As Boolean
    Dim SaveStatus As Boolean = False
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DgCrNote As System.Windows.Forms.DataGridView
    Friend WithEvents lblDiff As System.Windows.Forms.Label
    Friend WithEvents lblDR As System.Windows.Forms.Label
    Friend WithEvents lblCR As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLdt As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Btnclose As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblCurBal As System.Windows.Forms.Label
    Friend WithEvents LblType As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Dim Vnback As Integer

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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CmbBokName As System.Windows.Forms.ComboBox
    Friend WithEvents DtpkrJrnl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lblvno As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnFnd As System.Windows.Forms.Button
    Friend WithEvents TxtNarr As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJrnl))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblLdt = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Ballabel = New System.Windows.Forms.Label
        Me.DtpkrJrnl = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Lblvno = New System.Windows.Forms.Label
        Me.CmbBokName = New System.Windows.Forms.ComboBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtNarr = New System.Windows.Forms.TextBox
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.BtnFnd = New System.Windows.Forms.Button
        Me.Btnclose = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DgCrNote = New System.Windows.Forms.DataGridView
        Me.lblDiff = New System.Windows.Forms.Label
        Me.lblDR = New System.Windows.Forms.Label
        Me.lblCR = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LblCurBal = New System.Windows.Forms.Label
        Me.LblType = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DgCrNote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblLdt)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Ballabel)
        Me.Panel2.Controls.Add(Me.DtpkrJrnl)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Lblvno)
        Me.Panel2.Location = New System.Drawing.Point(7, 8)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(919, 37)
        Me.Panel2.TabIndex = 0
        '
        'lblLdt
        '
        Me.lblLdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLdt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLdt.Location = New System.Drawing.Point(314, 7)
        Me.lblLdt.Name = "lblLdt"
        Me.lblLdt.Size = New System.Drawing.Size(105, 20)
        Me.lblLdt.TabIndex = 115
        Me.lblLdt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(206, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 20)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "Last Used Date :-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(8, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 20)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Date:-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(289, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 10
        '
        'Ballabel
        '
        Me.Ballabel.AutoSize = True
        Me.Ballabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ballabel.Location = New System.Drawing.Point(259, 133)
        Me.Ballabel.Name = "Ballabel"
        Me.Ballabel.Size = New System.Drawing.Size(0, 15)
        Me.Ballabel.TabIndex = 9
        '
        'DtpkrJrnl
        '
        Me.DtpkrJrnl.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrJrnl.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrJrnl.Location = New System.Drawing.Point(68, 7)
        Me.DtpkrJrnl.Name = "DtpkrJrnl"
        Me.DtpkrJrnl.Size = New System.Drawing.Size(132, 20)
        Me.DtpkrJrnl.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(704, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 20)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "No."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lblvno
        '
        Me.Lblvno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblvno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblvno.Location = New System.Drawing.Point(750, 7)
        Me.Lblvno.Name = "Lblvno"
        Me.Lblvno.Size = New System.Drawing.Size(164, 20)
        Me.Lblvno.TabIndex = 112
        '
        'CmbBokName
        '
        Me.CmbBokName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbBokName.DropDownHeight = 95
        Me.CmbBokName.Enabled = False
        Me.CmbBokName.IntegralHeight = False
        Me.CmbBokName.Location = New System.Drawing.Point(44, 96)
        Me.CmbBokName.Name = "CmbBokName"
        Me.CmbBokName.Size = New System.Drawing.Size(483, 21)
        Me.CmbBokName.TabIndex = 2
        Me.CmbBokName.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.DeleteAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(122, 70)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'DeleteAllToolStripMenuItem
        '
        Me.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem"
        Me.DeleteAllToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.DeleteAllToolStripMenuItem.Text = "DeleteAll"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(4, 512)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Narration:"
        '
        'TxtNarr
        '
        Me.TxtNarr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNarr.Enabled = False
        Me.TxtNarr.Location = New System.Drawing.Point(78, 512)
        Me.TxtNarr.MaxLength = 150
        Me.TxtNarr.Name = "TxtNarr"
        Me.TxtNarr.Size = New System.Drawing.Size(674, 20)
        Me.TxtNarr.TabIndex = 6
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.BackgroundImage = CType(resources.GetObject("BtnAdd.BackgroundImage"), System.Drawing.Image)
        Me.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnAdd.FlatAppearance.BorderSize = 0
        Me.BtnAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Navy
        Me.BtnAdd.Location = New System.Drawing.Point(492, 560)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(132, 33)
        Me.BtnAdd.TabIndex = 7
        Me.BtnAdd.Text = "&Save"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'BtnFnd
        '
        Me.BtnFnd.BackColor = System.Drawing.Color.Transparent
        Me.BtnFnd.BackgroundImage = CType(resources.GetObject("BtnFnd.BackgroundImage"), System.Drawing.Image)
        Me.BtnFnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFnd.FlatAppearance.BorderColor = System.Drawing.Color.LightGreen
        Me.BtnFnd.FlatAppearance.BorderSize = 0
        Me.BtnFnd.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.BtnFnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnFnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFnd.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFnd.ForeColor = System.Drawing.Color.Navy
        Me.BtnFnd.Location = New System.Drawing.Point(643, 560)
        Me.BtnFnd.Name = "BtnFnd"
        Me.BtnFnd.Size = New System.Drawing.Size(132, 33)
        Me.BtnFnd.TabIndex = 8
        Me.BtnFnd.Text = "&Edit"
        Me.BtnFnd.UseVisualStyleBackColor = False
        '
        'Btnclose
        '
        Me.Btnclose.BackColor = System.Drawing.Color.Transparent
        Me.Btnclose.BackgroundImage = CType(resources.GetObject("Btnclose.BackgroundImage"), System.Drawing.Image)
        Me.Btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnclose.FlatAppearance.BorderColor = System.Drawing.Color.LightGreen
        Me.Btnclose.FlatAppearance.BorderSize = 0
        Me.Btnclose.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.Btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnclose.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnclose.ForeColor = System.Drawing.Color.Navy
        Me.Btnclose.Location = New System.Drawing.Point(794, 560)
        Me.Btnclose.Name = "Btnclose"
        Me.Btnclose.Size = New System.Drawing.Size(132, 33)
        Me.Btnclose.TabIndex = 10
        Me.Btnclose.Text = "&Close"
        Me.Btnclose.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'DgCrNote
        '
        Me.DgCrNote.AllowUserToAddRows = False
        Me.DgCrNote.BackgroundColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgCrNote.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgCrNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgCrNote.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DgCrNote.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgCrNote.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgCrNote.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgCrNote.GridColor = System.Drawing.Color.NavajoWhite
        Me.DgCrNote.Location = New System.Drawing.Point(7, 75)
        Me.DgCrNote.Name = "DgCrNote"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgCrNote.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgCrNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgCrNote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgCrNote.Size = New System.Drawing.Size(919, 395)
        Me.DgCrNote.TabIndex = 3
        '
        'lblDiff
        '
        Me.lblDiff.AutoSize = True
        Me.lblDiff.BackColor = System.Drawing.Color.SteelBlue
        Me.lblDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiff.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiff.ForeColor = System.Drawing.Color.White
        Me.lblDiff.Location = New System.Drawing.Point(408, 48)
        Me.lblDiff.Name = "lblDiff"
        Me.lblDiff.Size = New System.Drawing.Size(19, 18)
        Me.lblDiff.TabIndex = 113
        Me.lblDiff.Text = "0"
        Me.lblDiff.Visible = False
        '
        'lblDR
        '
        Me.lblDR.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDR.Location = New System.Drawing.Point(550, 471)
        Me.lblDR.Name = "lblDR"
        Me.lblDR.Size = New System.Drawing.Size(180, 20)
        Me.lblDR.TabIndex = 114
        Me.lblDR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCR
        '
        Me.lblCR.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblCR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCR.Location = New System.Drawing.Point(729, 471)
        Me.lblCR.Name = "lblCR"
        Me.lblCR.Size = New System.Drawing.Size(180, 20)
        Me.lblCR.TabIndex = 114
        Me.lblCR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(492, 472)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "TOTAL >"
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(7, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(155, 20)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "CURRENT NET BALANCE:-"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCurBal
        '
        Me.LblCurBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCurBal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurBal.ForeColor = System.Drawing.Color.Blue
        Me.LblCurBal.Location = New System.Drawing.Point(164, 50)
        Me.LblCurBal.Name = "LblCurBal"
        Me.LblCurBal.Size = New System.Drawing.Size(177, 20)
        Me.LblCurBal.TabIndex = 116
        Me.LblCurBal.Text = "0.00"
        Me.LblCurBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblType
        '
        Me.LblType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblType.ForeColor = System.Drawing.Color.Blue
        Me.LblType.Location = New System.Drawing.Point(343, 50)
        Me.LblType.Name = "LblType"
        Me.LblType.Size = New System.Drawing.Size(29, 20)
        Me.LblType.TabIndex = 117
        Me.LblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ACCOUNT NAME"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 480
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn2.HeaderText = "DEBIT"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 190
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn3.HeaderText = "CREDIT"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 190
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "SPLR ID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "TRAN ID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "ACCOUNT NAME"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 480
        '
        'Column2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "DEBIT"
        Me.Column2.MaxInputLength = 20
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 190
        '
        'Column3
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column3.HeaderText = "CREDIT"
        Me.Column3.MaxInputLength = 20
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 190
        '
        'Column4
        '
        Me.Column4.HeaderText = "SPLR ID"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "TRAN ID"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'FrmJrnl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGreen
        Me.ClientSize = New System.Drawing.Size(938, 599)
        Me.Controls.Add(Me.CmbBokName)
        Me.Controls.Add(Me.LblType)
        Me.Controls.Add(Me.LblCurBal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblCR)
        Me.Controls.Add(Me.lblDR)
        Me.Controls.Add(Me.DgCrNote)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TxtNarr)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblDiff)
        Me.Controls.Add(Me.Btnclose)
        Me.Controls.Add(Me.BtnFnd)
        Me.Controls.Add(Me.BtnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmJrnl"
        Me.Text = "Journal Register"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DgCrNote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub FrmJrnl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Add_Edit_Flag = True
            fetch_splr_Name(CmbBokName)
            ' Me.CmbBokName.Visible = False
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpkrJrnl, Me.DtpkrJrnl)
            Me.DtpkrJrnl.Focus()
        Catch ex As Exception

        End Try
    End Sub


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

    Private Sub CmbBokName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBokName.GotFocus
        Try
            CmbBokName.DroppedDown = True
            If Not Me.DgCrNote.CurrentRow.Cells(3).Value = Nothing Then
                Dim Idx As Integer = 0
                Idx = Me.DgCrNote.CurrentRow.Cells(3).Value
                Me.CmbBokName.FindString(Idx, 0)
                Me.CmbBokName.SelectedValue = Idx
            End If

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
    Private Sub DtpkrJrnl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrJrnl.GotFocus

        Try
            Date.TryParse(fetch_MxDate(), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
            lblLdt.Text = CurrDate 'Format(CurrDate, "dd/MM/yyyy")
            DtpkrJrnl.Value = CurrDate.Date
        Catch ex As Exception
            '  MsgBox(ex.Message)

        End Try
    End Sub
    Private Function SetDtpCurrentDate() As Date
        Try
            Dim xDt As Date = GetServerCurrentDate()

            If FinEnddt > xDt Then
                Return xDt.Date
            Else
                Return FinEnddt.Date
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Function
    Private Function fetch_Vou_No() As Integer
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Csh_Bnk_Cmd = New SqlCommand("Finact_CshBnk_GenerateVno", FinActConn)
            Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
            Csh_Bnk_Cmd.Parameters.AddWithValue("@Trandt", Me.DtpkrJrnl.Value.Date)
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
    Private Function fetch_MxDate() As Date
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Csh_Bnk_Cmd = New SqlCommand("Finact_CshBnk_MaxDate", FinActConn)
            Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
            Csh_Bnk_Cmd.Parameters.AddWithValue("@xIndx", 1)
            Csh_Bnk_Cmd.Parameters.AddWithValue("@xCondVal", "Journal")
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


    Private Sub Btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnclose.Click
        Dim delconfrm As String
        delconfrm = MsgBox("Are you sure to Exit without save", MsgBoxStyle.YesNo, "Exit")
        If delconfrm = vbYes Then
            Me.Close()
        End If
    End Sub
    Private Sub panel_enable()
        Try
            DtpkrJrnl.Enabled = True
            CmbBokName.Enabled = True
            Lblvno.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub panel_enable_fls()
        Lblvno.Text = ""
        CmbBokName.Text = ""
        CmbBokName.Enabled = False
        TxtNarr.Enabled = False

    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If Chk_BothDrCr_Zero() = True Then
                MsgBox("Invalid Input!,Both column can't be zero", MsgBoxStyle.Critical, "Debit and Credit is Zero")
                Exit Sub
            End If
            GridTotalDrCr()
            Dim xdr As Double = Me.lblDR.Text
            Dim xcr As Double = Me.lblCR.Text
            If xdr = 0 Or xcr = 0 Then
                MsgBox("Invalid Input!, column can't be zero", MsgBoxStyle.Critical, "Debit or Credit is Zero")
                Exit Sub
            ElseIf xdr <> xcr Then
                MsgBox("Invalid Input!, Total is not equal", MsgBoxStyle.Critical, "Debit or Credit are not Equal")
                Exit Sub
            End If
            If Add_Edit_Flag = True Then
                'en_load()
                BtnFnd.Text = "&Cancel"
            ElseIf Add_Edit_Flag = False Then
                BtnFnd.Text = "&Edit"
            End If


            If BtnAdd.Text = Trim("&Save") Then

                If MessageBox.Show("Are you sure to save current record?", "Credit Note Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Saverecord1()
                Else
                    Return
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Clr_Values_Ins()
        Try
            Lblvno.Text = ""
            Me.TxtNarr.BackColor = Color.White
            Me.TxtNarr.ForeColor = Color.Black
            TxtNarr.Text = ""
            TxtNarr.Enabled = False
            Lblvno.Text = fetch_Vou_No()
            Me.lblCR.Text = ""
            Me.lblDR.Text = ""
            Me.lblDiff.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'To check Banlance Entry
    Private Function Chk_bal() As Double
        Try
            Dim diff As Double = 0
            Dim Dr As Double = 0
            Dim Cr As Double = 0
            For Each Rw As DataGridViewRow In Me.DgCrNote.Rows
                If Not Rw.Cells(1).Value = Nothing Then
                    Dr += Rw.Cells(1).Value
                Else
                    Dr += 0
                End If
                If Not Rw.Cells(2).Value = Nothing Then
                    Cr += Rw.Cells(2).Value
                Else
                    Cr += 0
                End If
            Next
            If Dr > Cr Then
                diff = Dr - Cr
                Me.lblDiff.Visible = True
                Me.lblDiff.Text = "Debit Is Greater Than Credit By " & FormatNumber(diff, 2)

            ElseIf Cr > Dr Then
                diff = Cr - Dr
                Me.lblDiff.Visible = True
                Me.lblDiff.Text = "Credit Is Greater Than Debit By " & FormatNumber(diff, 2)
            ElseIf Dr = Cr Or Cr = Dr Then
                diff = Dr - Cr
                Me.lblDiff.Visible = False
            End If
            Return diff
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Sub BtnFnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd.Click
        Try
            If BtnFnd.Text = "&Edit" Then
                'Me.WindowState = FormWindowState.Minimized
                Dim FrmCrnEdt As New FrmJrnlEdit
                FrmCrnEdt.ShowInTaskbar = False
                FrmCrnEdt.ShowDialog()
                Exit Sub
                BtnFnd.Text = "&Cancel"
                BtnAdd.Text = "&Update"
                panel_enable_fls()
                DtpkrJrnl.Enabled = True
            ElseIf BtnFnd.Text = "&Cancel" Then
                Add_Edit_Flag = True
                Clr_Values_Ins()
                BtnFnd.Text = "&Edit"
                BtnAdd.Text = "&Save"
                DtpkrJrnl.Enabled = False

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Chk_val()
        With TxtNarr
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                '.Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With

    End Sub


    Private Sub Saverecord1() 'save record

        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            If Chk_bal() > 0 Then
                MsgBox("Invalid Input!, Both Debit and Credit Should be Equal", MsgBoxStyle.Critical, "Total Difference!!!!")
                Exit Sub
            End If

            Dim ltype As String = "Jrnl"
            Lblvno.Text = xFetchVno_dynamic("FinActCshBnk", "CBTranvno")
            For Each Rwx As DataGridViewRow In Me.DgCrNote.Rows
                If Rwx.Cells(1).Value = 0 Then
                    TranType = "Credit"
                Else
                    TranType = "Debit"
                End If
                Try
                    Csh_Bnk_Cmd = New SqlCommand("Finact_Jrnl_Insert", FinActConn)
                    Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranCustId", Rwx.Cells(3).Value)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranaddt", Now)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@cbadusrid", Current_UsrId)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranVNo", Lblvno.Text)

                    If Rwx.Cells(1).Value > 0 Then
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranAmtDrCr", CDbl(Rwx.Cells(1).Value))
                    Else
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranAmtDrCr", CDbl(Rwx.Cells(2).Value))
                    End If
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranBokName", Trim("Journal"))
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtrandelstatus", 1)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranDt", DtpkrJrnl.Value.Date)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranmode", Trim(ltype))
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranNraTn", Trim(TxtNarr.Text))
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranType", Trim(TranType))
                    Csh_Bnk_Cmd.ExecuteNonQuery()
                    SaveStatus = True
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally

                End Try

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Csh_Bnk_Cmd = Nothing
            If SaveStatus = True Then
                MsgBox("Current Records has been sucessfully saved.", MsgBoxStyle.Critical, "Credit Note Saved")
                Clr_Values_Ins()
                Add_Edit_Flag = True
                Me.DgCrNote.Rows.Clear()
                Me.DtpkrJrnl.Focus()
                Me.DtpkrJrnl.Select()
               
            End If

        End Try
    End Sub

    Private Sub DtpkrJrnl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrJrnl.Leave
        Try
            If Add_Edit_Flag = True Then
                Lblvno.Text = xFetchVno_dynamic("FinActCshBnk", "CBTranvno")
                If Me.DgCrNote.Rows.Count = Nothing Then
                    Me.DgCrNote.Rows.Clear()
                    Me.DgCrNote.Rows.Add()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DtpkrJrnl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrJrnl.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNarr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNarr.GotFocus
        Try
            Me.TxtNarr.BackColor = Color.Blue
            Me.TxtNarr.ForeColor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNarr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNarr.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnAdd.Focus()
        End If
    End Sub

    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.GotFocus, Btnclose.GotFocus, BtnFnd.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnAdd.KeyDown, CmbBokName.KeyDown, DtpkrJrnl.KeyDown, TxtNarr.KeyDown, Label2.KeyDown, BtnFnd.KeyDown, Btnclose.KeyDown
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

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Dim cnt As Integer
        Dim sel_cnt As Integer


        If Add_Edit_Flag = False And cnt <> 0 Then

            If sel_cnt <> 0 Then
                Try


                Catch ex As Exception

                Finally

                End Try

            ElseIf sel_cnt = 0 Then
                MsgBox("No record Selected  to Update", MsgBoxStyle.Information, "Update")
            End If
        ElseIf Add_Edit_Flag = True And cnt <> 0 Then
            If sel_cnt <> 0 Then
                Try




                Catch ex As Exception

                Finally

                End Try

            ElseIf sel_cnt = 0 Then
                MsgBox("No record Selected  to Update", MsgBoxStyle.Information, "Update")
            End If
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try

            Dim delconfrm As String
            delconfrm = MsgBox("Are you sure to delete this row record", MsgBoxStyle.YesNo, "Delete Section")
            If delconfrm = vbYes Then
                If Me.DgCrNote.CurrentRow.Index > 0 Then
                    ' If Me.DgCrNote.SelectedRows.Count = 1 Then
                    Me.DgCrNote.Rows.RemoveAt(Me.DgCrNote.CurrentRow.Index)
                    'End If
                Else
                    MsgBox("Invalid Input!, System can't delete this row", MsgBoxStyle.Critical, "System Reserve Row")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub del_to_selrecrd()


        Dim cnt As Integer

        Dim sel_cnt As Integer
        If Add_Edit_Flag = True Then
            If cnt <> 0 Or sel_cnt <> 0 Then
                MsgBox("Deleted", MsgBoxStyle.Information, "Delete Record")
            ElseIf cnt = 0 Then
                MsgBox("No record to delete", MsgBoxStyle.Information, "Delete")
            ElseIf sel_cnt = 0 Then
                MsgBox("No record Selected ", MsgBoxStyle.Information, "Delete")
            End If
        ElseIf Add_Edit_Flag = False Then

            If sel_cnt <> 0 Then


                cnt = 0
                While cnt < sel_cnt
                    ' DelStatus = 0
                    Try

                    Catch ex As Exception
                    Finally
                    End Try

                    Try
                        Csh_Bnk_Cmd = New SqlCommand("Finact_Jrnl_Delete", FinActConn)
                        Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranid", Vnback)
                        Csh_Bnk_Cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Csh_Bnk_Cmd = Nothing
                    End Try
                    cnt = cnt + 1

                End While
                MsgBox("Record has been Deleted successfully", MsgBoxStyle.Information)
            ElseIf sel_cnt = 0 Then
                MsgBox("No record Selected  to delete", MsgBoxStyle.Information, "Delete")
            End If
        End If
    End Sub

    Private Sub DeleteAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAllToolStripMenuItem.Click
        Try

            Dim delconfrm As String
            delconfrm = MsgBox("Are you sure to delete All record", MsgBoxStyle.YesNo, "Delete Section")
            If delconfrm = vbYes Then


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgCrNote_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgCrNote.CellEndEdit
        Try
            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
                Me.DgCrNote.CurrentCell.Value = FormatNumber(Me.DgCrNote.CurrentCell.Value, 2)
                GridTotalDrCr()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DgCrNote_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgCrNote.CellEnter
        Try
            If e.ColumnIndex = 0 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
                Me.DgCrNote.CurrentRow.Cells(e.ColumnIndex).ReadOnly = True
            End If

            If e.ColumnIndex = 0 Then
                xXcol = e.ColumnIndex
                xYrow = e.RowIndex
                Dim LOC As Object = DgCrNote.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
                Dim WID As Double = DgCrNote.CurrentCell.Size.Width
                Me.CmbBokName.Width = WID
                Me.CmbBokName.Location = New Point(LOC.x, LOC.y + Me.DgCrNote.Top)
                Me.CmbBokName.Enabled = True
                Me.CmbBokName.Visible = True
                Me.CmbBokName.Focus()
                Exit Sub
            End If
            If e.ColumnIndex = 1 And Not Me.DgCrNote.CurrentRow.Cells(2).Value > 0 Then
                Me.DgCrNote.BeginEdit(True)

            End If
            If e.ColumnIndex = 2 And Not Me.DgCrNote.CurrentRow.Cells(1).Value > 0 Then
                Me.DgCrNote.BeginEdit(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DgCrNote_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgCrNote.CellLeave
        Try

            If e.ColumnIndex = 1 Then
                '==========
                If Me.DgCrNote.CurrentCell.ColumnIndex = 1 Then
                    If Len(Trim(Me.DgCrNote.CurrentCell.Value)) = 0 Then Me.DgCrNote.CurrentCell.Value = 0

                    If Me.DgCrNote.CurrentCell.Value > 0 Then
                        Me.DgCrNote.CurrentRow.Cells(2).ReadOnly = True
                    Else
                        Me.DgCrNote.CurrentRow.Cells(2).ReadOnly = False
                    End If

                End If
                '==========
                Me.DgCrNote.CurrentRow.Cells(1).Value = CDbl(FormatNumber(Me.DgCrNote.CurrentRow.Cells(1).Value, 2))
                Me.DgCrNote.EndEdit()

            End If
            If e.ColumnIndex = 2 Then
                If Len(Trim(Me.DgCrNote.CurrentCell.Value)) = 0 Then Me.DgCrNote.CurrentCell.Value = 0
                Me.DgCrNote.CurrentRow.Cells(2).Value = CDbl(FormatNumber(Me.DgCrNote.CurrentRow.Cells(2).Value, 2))
                Me.DgCrNote.EndEdit()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DgCrNote_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgCrNote.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgCrNote.Rows.Count '- 1
            If Cr_Row <> Me.DgCrNote.CurrentRow.Index Then
                If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgCrNote.CurrentCell.ErrorText = "Only Number are allowed"
                        Me.DgCrNote.CurrentCell.Value = 0
                        ' Me.dgcrnoteCurrentRow.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        Me.DgCrNote.CurrentCell.ErrorText = ""
                        ' Me.dgcrnoteCurrentRow.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DgCrNote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgCrNote.KeyDown
        Try
            Dim intx As Integer = DgCrNote.CurrentCell.ColumnIndex

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
              
                If Me.DgCrNote.CurrentCell.ColumnIndex = 1 Then
                    If Me.DgCrNote.CurrentCell.Value > 0 Then
                        Me.DgCrNote.CurrentRow.Cells(2).ReadOnly = True
                    Else
                        Me.DgCrNote.CurrentRow.Cells(2).ReadOnly = False
                    End If

                End If

                If Me.DgCrNote.CurrentCell.ColumnIndex = 2 Then
                    If Me.DgCrNote.CurrentCell.Value > 0 Then
                        Me.DgCrNote.CurrentRow.Cells(1).ReadOnly = True
                    Else
                        Me.DgCrNote.CurrentRow.Cells(1).ReadOnly = False
                    End If

                End If

                If DgCrNote.CurrentCell.ColumnIndex = 2 Then 'dgcrnote.ColumnCount = 3 Then
                    If Me.DgCrNote.CurrentRow.Index = Me.DgCrNote.Rows.Count - 1 Then
                        If Chk_Error() = True Then Exit Sub
                        If Chk_bal() = 0 Then
                            '  Me.DgCrNote.SelectedCells(3).Selected = False
                            Me.TxtNarr.Enabled = True
                            Me.TxtNarr.Focus()
                            Exit Sub
                        Else
                            Me.TxtNarr.Enabled = False
                        End If
                        If Chk_BlankId() = True Then
                            MsgBox("Invalid input!, ID is not valid", MsgBoxStyle.Critical, "Invalid Id")
                            Exit Sub
                        End If

                        Me.DgCrNote.Rows.Add()
                        '' xNewRow()

                    End If

                    If DgCrNote.CurrentCell.RowIndex < DgCrNote.RowCount - 1 Then
                        DgCrNote.CurrentCell = DgCrNote.Item(0, DgCrNote.CurrentCell.RowIndex + 1)
                    End If
                Else

                    DgCrNote.CurrentCell = DgCrNote.Item(DgCrNote.CurrentCell.ColumnIndex + 1, DgCrNote.CurrentCell.RowIndex)


                End If
                e.Handled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function Chk_Error() As Boolean
        Try
            For Each Rx As DataGridViewRow In Me.DgCrNote.Rows
                If Rx.Cells(1).ErrorText <> "" Or Rx.Cells(2).ErrorText <> "" Then
                    Return True
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function Chk_BlankId() As Boolean
        Try
            For Each Rx As DataGridViewRow In Me.DgCrNote.Rows
                If Rx.Cells(3).Value = "" Then
                    Return True
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function Chk_BothDrCr_Zero() As Boolean
        Try
            For Each Rx As DataGridViewRow In Me.DgCrNote.Rows
                If Rx.Cells(1).Value = 0 And Rx.Cells(2).Value = 0 Then
                    Return True
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub GridTotalDrCr()
        Try
            Dim Dr As Double = 0
            Dim Cr As Double = 0

            For Each Rx As DataGridViewRow In Me.DgCrNote.Rows
                If Len(Trim(Rx.Cells(1).Value)) = 0 Then Rx.Cells(1).Value = 0
                If Len(Trim(Rx.Cells(2).Value)) = 0 Then Rx.Cells(2).Value = 0
                Dr += CDbl(Rx.Cells(1).Value)
                Cr += CDbl(Rx.Cells(2).Value)
            Next
            Me.lblDR.Text = FormatNumber(Dr, 2)
            Me.lblCR.Text = FormatNumber(Cr, 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub TxtNarr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNarr.Leave
        Try
            Me.TxtNarr.BackColor = Color.White
            Me.TxtNarr.ForeColor = Color.Black

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnALL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Leave, Btnclose.Leave, BtnFnd.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbBokName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBokName.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbBokName) = True Then
                If CmbBokName.SelectedIndex = 0 Then
                    Me.LblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(Me.CmbBokName.SelectedValue), Me.LblType), 2)
                End If
                '=========
                If Me.CmbBokName.Visible = True Then
                    Me.DgCrNote.Rows(xYrow).Cells(xXcol).Value = Trim(Me.CmbBokName.Text)
                End If
              
                Me.DgCrNote.Rows(xYrow).Cells(xXcol + 3).Value = Trim(Me.CmbBokName.SelectedValue)
                Me.CmbBokName.Visible = False
                '==========
                DgCrNote.CurrentCell = DgCrNote.Item(xXcol + 1, DgCrNote.CurrentCell.RowIndex)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbBokName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBokName.SelectedIndexChanged
        Try
            If CmbBokName.SelectedIndex > 0 Then
                Me.LblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(Me.CmbBokName.SelectedValue), Me.LblType), 2)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DtpkrJrnl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpkrJrnl.ValueChanged

    End Sub
End Class

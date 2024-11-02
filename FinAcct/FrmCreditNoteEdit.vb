Imports System.Data
Imports System.Data.SqlClient
Public Class FrmCreditNoteEdit
    Inherits System.Windows.Forms.Form
    Dim Csh_Bnk_Cmd As SqlCommand
    Dim Csh_Bnk_rdr As SqlDataReader
    Dim Csh_Bnk_Cmd1 As SqlCommand
    Dim Csh_Bnk_rdr1 As SqlDataReader
    Dim Csh_Bnk_Sqladptr As SqlDataAdapter
    Dim Csh_Bnk_Dset As DataSet
   
    Dim a As Integer
    Dim Voucher As Integer
    Dim xXcol As Integer = 0, xYrow As Integer = 0
    Dim Bookitem As Integer
    Dim HitInfo As DataGridView.HitTestInfo
    Dim xFill As Boolean = False

    
    Friend WithEvents Ballabel As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Dim invalid As Integer
    Dim Add_Edit_Flag As Boolean
    Friend WithEvents Combolbl As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DgCrNote As System.Windows.Forms.DataGridView
    Friend WithEvents lblDiff As System.Windows.Forms.Label
    Friend WithEvents lblDR As System.Windows.Forms.Label
    Friend WithEvents lblCR As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents LblType As System.Windows.Forms.Label
    Friend WithEvents LblCurBal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lblvno As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnFnd As System.Windows.Forms.Button
    Friend WithEvents BtnDel As System.Windows.Forms.Button
    Friend WithEvents Btnclose As System.Windows.Forms.Button
    Friend WithEvents TxtNarr As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCreditNoteEdit))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Combolbl = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Ballabel = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.Lblvno = New System.Windows.Forms.Label
        Me.CmbBokName = New System.Windows.Forms.ComboBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtNarr = New System.Windows.Forms.TextBox
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.BtnFnd = New System.Windows.Forms.Button
        Me.BtnDel = New System.Windows.Forms.Button
        Me.Btnclose = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DgCrNote = New System.Windows.Forms.DataGridView
        Me.lblDiff = New System.Windows.Forms.Label
        Me.lblDR = New System.Windows.Forms.Label
        Me.lblCR = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblType = New System.Windows.Forms.Label
        Me.LblCurBal = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DgCrNote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Combolbl)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Ballabel)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.lblDate)
        Me.Panel2.Controls.Add(Me.Lblvno)
        Me.Panel2.Location = New System.Drawing.Point(7, 8)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(919, 37)
        Me.Panel2.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(511, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Select an Entery No."
        '
        'Combolbl
        '
        Me.Combolbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Combolbl.Enabled = False
        Me.Combolbl.FormattingEnabled = True
        Me.Combolbl.Location = New System.Drawing.Point(637, 7)
        Me.Combolbl.Name = "Combolbl"
        Me.Combolbl.Size = New System.Drawing.Size(266, 21)
        Me.Combolbl.TabIndex = 1
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
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(6, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 20)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Date:-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(240, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 20)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "No."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDate
        '
        Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(56, 7)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(164, 20)
        Me.lblDate.TabIndex = 112
        '
        'Lblvno
        '
        Me.Lblvno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblvno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblvno.Location = New System.Drawing.Point(282, 7)
        Me.Lblvno.Name = "Lblvno"
        Me.Lblvno.Size = New System.Drawing.Size(91, 20)
        Me.Lblvno.TabIndex = 112
        '
        'CmbBokName
        '
        Me.CmbBokName.Location = New System.Drawing.Point(7, 476)
        Me.CmbBokName.Name = "CmbBokName"
        Me.CmbBokName.Size = New System.Drawing.Size(328, 21)
        Me.CmbBokName.TabIndex = 2
        Me.CmbBokName.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(4, 511)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Narration:"
        '
        'TxtNarr
        '
        Me.TxtNarr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNarr.Location = New System.Drawing.Point(78, 511)
        Me.TxtNarr.MaxLength = 150
        Me.TxtNarr.Name = "TxtNarr"
        Me.TxtNarr.Size = New System.Drawing.Size(848, 20)
        Me.TxtNarr.TabIndex = 4
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
        Me.BtnAdd.Location = New System.Drawing.Point(508, 559)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(100, 33)
        Me.BtnAdd.TabIndex = 5
        Me.BtnAdd.Text = "&Update"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'BtnFnd
        '
        Me.BtnFnd.BackColor = System.Drawing.Color.Transparent
        Me.BtnFnd.BackgroundImage = CType(resources.GetObject("BtnFnd.BackgroundImage"), System.Drawing.Image)
        Me.BtnFnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFnd.FlatAppearance.BorderSize = 0
        Me.BtnFnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnFnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFnd.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFnd.ForeColor = System.Drawing.Color.Navy
        Me.BtnFnd.Location = New System.Drawing.Point(614, 559)
        Me.BtnFnd.Name = "BtnFnd"
        Me.BtnFnd.Size = New System.Drawing.Size(100, 33)
        Me.BtnFnd.TabIndex = 0
        Me.BtnFnd.Text = "&Find"
        Me.BtnFnd.UseVisualStyleBackColor = False
        '
        'BtnDel
        '
        Me.BtnDel.BackColor = System.Drawing.Color.Transparent
        Me.BtnDel.BackgroundImage = CType(resources.GetObject("BtnDel.BackgroundImage"), System.Drawing.Image)
        Me.BtnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDel.Enabled = False
        Me.BtnDel.FlatAppearance.BorderSize = 0
        Me.BtnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDel.ForeColor = System.Drawing.Color.Navy
        Me.BtnDel.Location = New System.Drawing.Point(720, 559)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(100, 33)
        Me.BtnDel.TabIndex = 6
        Me.BtnDel.Text = "&Delete"
        Me.BtnDel.UseVisualStyleBackColor = False
        '
        'Btnclose
        '
        Me.Btnclose.BackColor = System.Drawing.Color.Transparent
        Me.Btnclose.BackgroundImage = CType(resources.GetObject("Btnclose.BackgroundImage"), System.Drawing.Image)
        Me.Btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnclose.FlatAppearance.BorderSize = 0
        Me.Btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnclose.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnclose.ForeColor = System.Drawing.Color.Navy
        Me.Btnclose.Location = New System.Drawing.Point(826, 559)
        Me.Btnclose.Name = "Btnclose"
        Me.Btnclose.Size = New System.Drawing.Size(100, 33)
        Me.Btnclose.TabIndex = 7
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
        Me.DgCrNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgCrNote.BackgroundColor = System.Drawing.Color.LightGray
        Me.DgCrNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgCrNote.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DgCrNote.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgCrNote.GridColor = System.Drawing.Color.WhiteSmoke
        Me.DgCrNote.Location = New System.Drawing.Point(7, 75)
        Me.DgCrNote.Name = "DgCrNote"
        Me.DgCrNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgCrNote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgCrNote.Size = New System.Drawing.Size(919, 389)
        Me.DgCrNote.TabIndex = 3
        '
        'lblDiff
        '
        Me.lblDiff.AutoSize = True
        Me.lblDiff.BackColor = System.Drawing.Color.Navy
        Me.lblDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiff.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiff.ForeColor = System.Drawing.Color.White
        Me.lblDiff.Location = New System.Drawing.Point(380, 50)
        Me.lblDiff.Name = "lblDiff"
        Me.lblDiff.Size = New System.Drawing.Size(16, 17)
        Me.lblDiff.TabIndex = 113
        Me.lblDiff.Text = "0"
        Me.lblDiff.Visible = False
        '
        'lblDR
        '
        Me.lblDR.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDR.Location = New System.Drawing.Point(552, 466)
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
        Me.lblCR.Location = New System.Drawing.Point(731, 466)
        Me.lblCR.Name = "lblCR"
        Me.lblCR.Size = New System.Drawing.Size(180, 20)
        Me.lblCR.TabIndex = 114
        Me.lblCR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(492, 467)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "TOTAL >"
        '
        'LblType
        '
        Me.LblType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblType.ForeColor = System.Drawing.Color.Blue
        Me.LblType.Location = New System.Drawing.Point(343, 50)
        Me.LblType.Name = "LblType"
        Me.LblType.Size = New System.Drawing.Size(29, 20)
        Me.LblType.TabIndex = 126
        Me.LblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCurBal
        '
        Me.LblCurBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCurBal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurBal.ForeColor = System.Drawing.Color.Blue
        Me.LblCurBal.Location = New System.Drawing.Point(164, 50)
        Me.LblCurBal.Name = "LblCurBal"
        Me.LblCurBal.Size = New System.Drawing.Size(177, 20)
        Me.LblCurBal.TabIndex = 125
        Me.LblCurBal.Text = "0.00"
        Me.LblCurBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(7, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 20)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "CURRENT NET BALANCE:-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmCreditNoteEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.LimeGreen
        Me.ClientSize = New System.Drawing.Size(938, 599)
        Me.Controls.Add(Me.LblType)
        Me.Controls.Add(Me.LblCurBal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCR)
        Me.Controls.Add(Me.lblDR)
        Me.Controls.Add(Me.DgCrNote)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtNarr)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblDiff)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CmbBokName)
        Me.Controls.Add(Me.Btnclose)
        Me.Controls.Add(Me.BtnDel)
        Me.Controls.Add(Me.BtnFnd)
        Me.Controls.Add(Me.BtnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCreditNoteEdit"
        Me.Text = "Credit Note Edit Mode"
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
            xFill = False
            CheckAcess_Btn_frm(BtnAdd, BtnFnd, BtnDel)
            CreateNewRow()
            fetch_splr_Name(CmbBokName)
            Me.DgCrNote.Controls.Add(Me.CmbBokName)
            Me.DgCrNote.Enabled = False
            Me.TxtNarr.Enabled = False
            Me.BtnFnd.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CreateNewRow()
        Try
            Me.DgCrNote.Columns.Add("ColName", "Account Name")
            Me.DgCrNote.Columns.Add("ColCode", "Code")
            Me.DgCrNote.Columns.Add("ColDr", "Debit")
            Me.DgCrNote.Columns.Add("ColCr", "Credit")
            Me.DgCrNote.Columns.Add("ColSplrid", "Splr Id")
            Me.DgCrNote.Columns.Add("ColTranid", "Tran Id")
            Me.DgCrNote.Columns(2).DefaultCellStyle.Format = "N2"
            Me.DgCrNote.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DgCrNote.Columns(3).DefaultCellStyle.Format = "N2"
            Me.DgCrNote.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DgCrNote.Columns(0).Width = 480
            Me.DgCrNote.Columns(1).Width = 0
            Me.DgCrNote.Columns(1).Visible = False
            Me.DgCrNote.Columns(2).Width = 190
            Me.DgCrNote.Columns(3).Width = 190
            Me.DgCrNote.Columns(4).Width = 0
            Me.DgCrNote.Columns(5).Width = 0
            Me.DgCrNote.Columns(4).Visible = False
            Me.DgCrNote.Columns(5).Visible = False
            Me.DgCrNote.Rows.Add()
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
                BtnnSave.Location = New System.Drawing.Point(275, 439)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
            Case "DataEntry"
                BtnnSave.Enabled = True
                BtnnSave.Location = New System.Drawing.Point(275, 439)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
            Case "PayRoll"
                BtnnSave.Enabled = True
                BtnnSave.Location = New System.Drawing.Point(275, 439)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
        End Select
    End Sub
    Private Sub fetch_splr_Name(ByVal x2Combox As ComboBox)
        Try
            Csh_Bnk_Cmd = New SqlCommand("select splrid,splrname from Finactsplrmstr where splrtype not In ( 'Bank'  , 'Cash Book' ) AND SPLRDELSTATUS=1 order by splrname ", FinActConn)

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
            If Not Me.DgCrNote.CurrentRow.Cells(4).Value = Nothing Then
                Dim Idx As Integer = Me.DgCrNote.CurrentRow.Cells(4).Value
                Me.CmbBokName.FindString(Idx, 0)
                Me.CmbBokName.SelectedValue = Idx
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnclose.Click
        Dim delconfrm As String
        delconfrm = MsgBox("Are you sure to Exit without save", MsgBoxStyle.YesNo, "Exit")
        If delconfrm = vbYes Then
            Me.Close()
        End If
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

            If BtnAdd.Text = Trim("&Update") Then

                Updaterecord()
                Clr_Values_Ins()

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Clr_Values_Ins()
        Try
            Lblvno.Text = ""
            Me.lblCR.Text = ""
            Me.lblDR.Text = ""
            Me.lblDiff.Text = ""
            Me.TxtNarr.BackColor = Color.White
            Me.TxtNarr.ForeColor = Color.Black
            TxtNarr.Text = ""
            TxtNarr.Enabled = False
            Combolbl.Enabled = False
            Me.DgCrNote.Rows.Clear()
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
                If Not Rw.Cells(2).Value = Nothing Then
                    Dr += Rw.Cells(2).Value
                Else
                    Dr += 0
                End If
                If Not Rw.Cells(3).Value = Nothing Then
                    Cr += Rw.Cells(3).Value
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



    Private Sub fetch_record_list() 'display records on find depend on vnocombobox
        Try
            Dim i As Integer = 0

            Me.DgCrNote.Rows.Clear()
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Csh_Bnk_Cmd = New SqlCommand("Finact_CreditNoteEdit_Select", FinActConn)
            Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
            Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTVno", Trim(Me.Lblvno.Text))
            Csh_Bnk_Cmd.Parameters.AddWithValue("@CBbkName", Trim("CrNote"))
            Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader

            While Csh_Bnk_rdr.Read()

                If Csh_Bnk_rdr.IsDBNull(0) = False Then
                    Me.DgCrNote.Rows.Add()
                    Me.DgCrNote.Rows(i).Cells(0).Value = Csh_Bnk_rdr(0)
                    Me.DgCrNote.Rows(i).Cells(1).Value = 0
                    Dim AmtType As String = Trim(Csh_Bnk_rdr(2))
                    If AmtType = "Debit" Then
                        Me.DgCrNote.Rows(i).Cells(2).Value = Csh_Bnk_rdr(3)
                        Me.DgCrNote.Rows(i).Cells(3).Value = CDbl(0.0)
                    ElseIf AmtType = "Credit" Then
                        Me.DgCrNote.Rows(i).Cells(2).Value = CDbl(0.0)
                        Me.DgCrNote.Rows(i).Cells(3).Value = Csh_Bnk_rdr(3)
                    End If
                    Me.DgCrNote.Rows(i).Cells(4).Value = Csh_Bnk_rdr(1)
                    Me.TxtNarr.Text = Trim(Csh_Bnk_rdr(4))
                    lblDate.Text = Format(Csh_Bnk_rdr(5), "dd/MM/yyyy")
                    Me.DgCrNote.Rows(i).Cells(5).Value = Csh_Bnk_rdr(8)

                    i += 1
                End If

            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Csh_Bnk_rdr.Close()
            Csh_Bnk_Cmd = Nothing
        End Try
    End Sub


    Private Sub BtnFnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd.Click
        Try
            If BtnFnd.Text = "&Find" Then
                Try
                    Combolbl.Items.Clear()
                    fetch_vno_list()
                    If Me.Combolbl.Items.Count > 0 Then
                        Me.Combolbl.SelectedIndex = 0
                    End If
                Catch ex As Exception

                End Try

                xFill = True
                BtnFnd.Text = "&Cancel"
                Combolbl.Enabled = True
                BtnDel.Enabled = True
                Me.Combolbl.Focus()
            ElseIf BtnFnd.Text = "&Cancel" Then
                Add_Edit_Flag = True
                Clr_Values_Ins()
                BtnFnd.Text = "&Find"
                BtnDel.Enabled = False
                Me.DgCrNote.Rows.Clear()
            End If
        Catch ex As Exception

        End Try

    End Sub



    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Try
            If Me.DgCrNote.RowCount > 0 Then
                If MessageBox.Show("Are you sure to delete selected record(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    xDel_A_Rec_FromTable_dynamicly("FinactCshBnk", "Cbtranvno", CInt(Me.Combolbl.Text))
                    Me.DgCrNote.Rows.Clear()
                    MsgBox("Selected record has been successfully deleted.", MsgBoxStyle.Information)
                Else
                    Return
                End If
                MsgBox("Invalid Indput!", MsgBoxStyle.Critical, Me.Text)
            End If

        Catch ex As Exception

        End Try



    End Sub


    Private Sub Updaterecord() 'update record

        Try
            Dim TranType As String = ""
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            For Each Rx As DataGridViewRow In Me.DgCrNote.Rows
                Csh_Bnk_Cmd = New SqlCommand("FinAct_CreditNote_Update", FinActConn)
                Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
                Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranedtdt", Now)
                Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranCustId", Rx.Cells(4).Value)
                Csh_Bnk_Cmd.Parameters.AddWithValue("@cbedtusrid", Current_UsrId)
                Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranVNo", Lblvno.Text)
                Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtransid", Rx.Cells(5).Value)
                If Rx.Cells(2).Value > 0 Then
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranAmtDrCr", Rx.Cells(2).Value)
                    TranType = "Debit"
                Else
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranAmtDrCr", Rx.Cells(3).Value)
                    TranType = "Credit"
                End If
                Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranType", Trim(TranType))
                Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranNraTn", Trim(TxtNarr.Text))
                Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtrandelstatus", 1)
                Csh_Bnk_Cmd.ExecuteNonQuery()
            Next
            MsgBox("Current Record has been Successfully Updated", MsgBoxStyle.Information, "Record Saved")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Csh_Bnk_Cmd = Nothing
        End Try


    End Sub
    Private Sub fetch_vno_list()
        Dim Ltype As String
        Ltype = "Jrnl"

        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Csh_Bnk_Cmd = New SqlCommand("Select DISTINCT(CBtranVNo) From FinActCshBnk where cbtranbokname=@bName and CBtranmode=@ltype And cbtrandelstatus=1", FinActConn)
            Csh_Bnk_Cmd.Parameters.AddWithValue("@bname", "CrNote")
            Csh_Bnk_Cmd.Parameters.AddWithValue("@ltype", Ltype)
            Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader
            While Csh_Bnk_rdr.Read()
                Combolbl.Items.Add(Csh_Bnk_rdr(0))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Csh_Bnk_rdr.Close()
            Csh_Bnk_Cmd = Nothing

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

    Private Sub Combolbl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combolbl.GotFocus
        Try
            Me.Combolbl.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Combolbl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combolbl.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Combolbl_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Combolbl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combolbl.Leave
        Try
            If CheckBlank_Cmbx(Me.Combolbl) = True Then
                If Me.Combolbl.SelectedIndex = 0 Then
                    If xFill = True Then
                        Me.Lblvno.Text = Trim(Me.Combolbl.Text)
                        fetch_record_list()
                        GridTotalDrCr()
                    End If
                End If
                Me.DgCrNote.Enabled = True
                Me.TxtNarr.Enabled = True
                Me.DgCrNote.Focus()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Combolbl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combolbl.SelectedIndexChanged
        Try
            If Me.Combolbl.SelectedIndex > 0 Then
                If xFill = True Then
                    Me.Lblvno.Text = Trim(Me.Combolbl.Text)
                    fetch_record_list()
                    GridTotalDrCr()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "??")

        End Try
    End Sub

    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.GotFocus, Btnclose.GotFocus, BtnDel.GotFocus, BtnFnd.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnAdd.KeyDown, Btnclose.KeyDown, CmbBokName.KeyDown, TxtNarr.KeyDown, Label2.KeyDown, BtnFnd.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub OnEnter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbBokName.KeyDown
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
                    'If Me.DgCrNote.SelectedRows.Count = 1 Then
                    Me.DgCrNote.Rows.RemoveAt(Me.DgCrNote.CurrentRow.Index)
                    'End If
                Else
                    MsgBox("Invalid Input!, System can't delete this row", MsgBoxStyle.Critical, "System Reserve Row")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbBokName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBokName.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbBokName) = True Then
                If CmbBokName.SelectedIndex = 0 Then
                    Me.lblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(Me.CmbBokName.SelectedValue), Me.lblType), 2)
                End If
                DgCrNote.CurrentCell = DgCrNote.Item(DgCrNote.CurrentCell.ColumnIndex + 2, DgCrNote.CurrentCell.RowIndex)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbBokName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBokName.SelectedIndexChanged
        Try
            If CmbBokName.SelectedIndex > 0 Then
                Me.lblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(Me.CmbBokName.SelectedValue), Me.lblType), 2)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DgCrNote_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgCrNote.CellClick
        Try
            If e.ColumnIndex = 0 And Not e.RowIndex = -1 Then
                xXcol = e.ColumnIndex
                xYrow = e.RowIndex
                Dim LOC As Object = DgCrNote.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
                Dim WID As Double = DgCrNote.CurrentCell.Size.Width
                Me.CmbBokName.Width = WID
                Me.CmbBokName.Location = New Point(LOC.x, LOC.y)
                Me.CmbBokName.Visible = True
                Me.CmbBokName.BringToFront()
                Me.CmbBokName.Visible = True
                Me.CmbBokName.Focus()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DgCrNote_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgCrNote.CellEndEdit
        Try
            If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
                Me.DgCrNote.CurrentCell.Value = FormatNumber(Me.DgCrNote.CurrentCell.Value, 2)
                GridTotalDrCr()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DgCrNote_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgCrNote.CellEnter
        Try
            If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
                Me.DgCrNote.CurrentRow.Cells(e.ColumnIndex).ReadOnly = True
            End If



            If e.ColumnIndex = 2 And Not Me.DgCrNote.CurrentRow.Cells(3).Value > 0 Then
                Me.DgCrNote.BeginEdit(True)

            End If
            If e.ColumnIndex = 3 And Not Me.DgCrNote.CurrentRow.Cells(2).Value > 0 Then
                Me.DgCrNote.BeginEdit(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DgCrNote_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgCrNote.CellLeave
        Try
            If e.ColumnIndex = 0 Then

                Me.DgCrNote.Focus()
                If Me.CmbBokName.Visible = True Then
                    Me.DgCrNote.Rows(xYrow).Cells(xXcol).Value = Trim(Me.CmbBokName.Text)
                    Me.CmbBokName.Visible = False
                End If

                If Not Me.DgCrNote.Rows(xYrow).Cells(xXcol + 2).Value > 0 Then
                    Me.DgCrNote.Rows(xYrow).Cells(xXcol + 2).Value = CDbl(0.0)
                End If
                If Not Me.DgCrNote.Rows(xYrow).Cells(xXcol + 3).Value > 0 Then
                    Me.DgCrNote.Rows(xYrow).Cells(xXcol + 3).Value = CDbl(0.0)
                End If
                Me.DgCrNote.Rows(xYrow).Cells(xXcol + 4).Value = Trim(Me.CmbBokName.SelectedValue)
            End If

            If e.ColumnIndex = 2 Then
                '==========
                If Me.DgCrNote.CurrentCell.ColumnIndex = 2 Then
                    If Me.DgCrNote.CurrentCell.Value > 0 Then
                        Me.DgCrNote.CurrentRow.Cells(3).ReadOnly = True
                    Else
                        Me.DgCrNote.CurrentRow.Cells(3).ReadOnly = False
                    End If

                End If
                '==========
                ' If Not Me.DgCrNote.CurrentRow.Cells(2).Value = "" Then
                Me.DgCrNote.CurrentRow.Cells(2).Value = CDbl(FormatNumber(Me.DgCrNote.CurrentRow.Cells(2).Value, 2))

                'End If
                Me.DgCrNote.EndEdit()

            End If
            If e.ColumnIndex = 3 Then
                ' If Not Me.DgCrNote.CurrentRow.Cells(3).Value = "" Then
                Me.DgCrNote.CurrentRow.Cells(3).Value = CDbl(FormatNumber(Me.DgCrNote.CurrentRow.Cells(3).Value, 2))
                'End If
                Me.DgCrNote.EndEdit()

            End If
            Me.CmbBokName.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub DgCrNote_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgCrNote.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgCrNote.Rows.Count '- 1
            If Cr_Row <> Me.DgCrNote.CurrentRow.Index Then
                If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgCrNote.CurrentCell.ErrorText = "Only Number are allowed"
                        Me.DgCrNote.CurrentCell.Value = 0
                        e.Cancel = True
                    Else
                        Me.DgCrNote.CurrentCell.ErrorText = ""
                        ' Me.dgcrnoteCurrentRow.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgCrNote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgCrNote.KeyDown
        Try
            Dim intx As Integer = DgCrNote.CurrentCell.ColumnIndex

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then

                If Me.DgCrNote.CurrentCell.ColumnIndex = 2 Then
                    If Me.DgCrNote.CurrentCell.Value > 0 Then
                        Me.DgCrNote.CurrentRow.Cells(3).ReadOnly = True
                    Else
                        Me.DgCrNote.CurrentRow.Cells(3).ReadOnly = False
                    End If

                End If

                If Me.DgCrNote.CurrentCell.ColumnIndex = 3 Then
                    If Me.DgCrNote.CurrentCell.Value > 0 Then
                        Me.DgCrNote.CurrentRow.Cells(2).ReadOnly = True
                    Else
                        Me.DgCrNote.CurrentRow.Cells(2).ReadOnly = False
                    End If

                End If

                If DgCrNote.CurrentCell.ColumnIndex = 3 Then 'dgcrnote.ColumnCount = 3 Then
                    If Me.DgCrNote.CurrentRow.Index = Me.DgCrNote.Rows.Count - 1 Then
                        If Chk_Error() = True Then Exit Sub
                        If Chk_bal() = 0 Then
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

                        ' Me.DgCrNote.Rows.Add()

                    End If

                    If DgCrNote.CurrentCell.RowIndex < DgCrNote.RowCount - 1 Then
                        DgCrNote.CurrentCell = DgCrNote.Item(0, DgCrNote.CurrentCell.RowIndex + 1)
                    End If
                Else
                    Select Case Me.DgCrNote.CurrentCell.ColumnIndex
                        Case 0
                            DgCrNote.CurrentCell = DgCrNote.Item(DgCrNote.CurrentCell.ColumnIndex + 2, DgCrNote.CurrentCell.RowIndex)
                        Case Else
                            DgCrNote.CurrentCell = DgCrNote.Item(DgCrNote.CurrentCell.ColumnIndex + 1, DgCrNote.CurrentCell.RowIndex)

                    End Select


                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Function Chk_Error() As Boolean
        Try
            For Each Rx As DataGridViewRow In Me.DgCrNote.Rows
                If Rx.Cells(2).ErrorText <> "" Or Rx.Cells(3).ErrorText <> "" Then
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
                If Rx.Cells(4).Value = "" Then
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
                If Rx.Cells(2).Value = 0 And Rx.Cells(3).Value = 0 Then
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
                Dr += CDbl(Rx.Cells(2).Value)
                Cr += CDbl(Rx.Cells(3).Value)
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
    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Leave, Btnclose.Leave, BtnDel.Leave, BtnFnd.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
End Class

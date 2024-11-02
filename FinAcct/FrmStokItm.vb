
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmStokItm
    Inherits System.Windows.Forms.Form
    Dim insertcom As SqlCommand
    Dim grupnamcom As SqlCommand
    Dim grpidcom As SqlCommand
    Dim itmnamcom As SqlCommand
    Dim cmbitmcom As SqlCommand
    Dim updtcom As SqlCommand
    Dim stcom As SqlCommand
    Dim delstcom As SqlCommand
    Dim sql As inv_sql
    Dim sql1 As inv_sql
    Dim Itmdgr As DataGridViewRow
    Dim Itmcel As DataGridViewTextBoxCell
    Dim Itmcom As DataGridViewComboBoxCell
    Dim ItmBtn As DataGridViewButtonCell
    Dim grupnamdr As SqlDataReader
    Dim grpiddr As SqlDataReader
    Dim itmnamdr As SqlDataReader
    Dim cmbitmdr As SqlDataReader
    Dim st As SqlDataReader
    Dim C12, C13 As Double
    Dim Fso As Object
    Dim ImageName As String = ""
    Dim ImagePath As String = "None"
    Dim F_name As String = ""
    Dim MySource As String

    Dim yn As Integer
    Dim grupid As Integer
    Dim sid As Integer
    Dim excinfo As Integer
    Dim DelStatus As Integer = 1
    Dim grupnam As String
    Friend WithEvents txtval As System.Windows.Forms.TextBox
    Friend WithEvents txtper As System.Windows.Forms.TextBox
    Friend WithEvents txtsno As System.Windows.Forms.TextBox
    Friend WithEvents labelsn As System.Windows.Forms.Label
    Friend WithEvents LblAlrt1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents stitsave As System.Windows.Forms.Button
    Friend WithEvents stitdelete As System.Windows.Forms.Button
    Friend WithEvents stitfind As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cmbxht As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Cmbxwdth As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxLnth As System.Windows.Forms.ComboBox
    Friend WithEvents Cmbxgrad As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CmbxMatrl As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ItmDg As System.Windows.Forms.DataGridView
    Friend WithEvents Btnht As System.Windows.Forms.Button
    Friend WithEvents Btnwdth As System.Windows.Forms.Button
    Friend WithEvents btnlnth As System.Windows.Forms.Button
    Friend WithEvents Btngrad As System.Windows.Forms.Button
    Friend WithEvents Btnmatrl As System.Windows.Forms.Button
    Friend WithEvents Btnundrgrp As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents gBoxUse As System.Windows.Forms.GroupBox
    Friend WithEvents rBTradingOnly As System.Windows.Forms.RadioButton
    Friend WithEvents rBPurchaseOnly As System.Windows.Forms.RadioButton
    Friend WithEvents rBSaleOnly As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Txtmax As System.Windows.Forms.TextBox
    Friend WithEvents btnimage As System.Windows.Forms.Button
    Friend WithEvents PicItm As System.Windows.Forms.PictureBox
    Friend WithEvents OpnFDlog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Txtratechek1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents TxtItmname As System.Windows.Forms.TextBox
    Friend WithEvents Txtitmremrk As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Cmbxloc As System.Windows.Forms.ComboBox
    Friend WithEvents Btnloc As System.Windows.Forms.Button
    Friend WithEvents lblsubp As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblMainp As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblloc As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Cmbxstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LstVew2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstvew1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblF2 As System.Windows.Forms.Label
    Dim indx As Integer


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
    Friend WithEvents Txtcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbxStokGrup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbxunit As System.Windows.Forms.ComboBox
    Friend WithEvents Txtratechek As System.Windows.Forms.TextBox
    Friend WithEvents txtreordr As System.Windows.Forms.TextBox
    Friend WithEvents txtopnstok As System.Windows.Forms.TextBox
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents cmbxexcise As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents stitclose As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStokItm))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Txtitmremrk = New System.Windows.Forms.TextBox
        Me.LstVew2 = New System.Windows.Forms.ListView
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.Label24 = New System.Windows.Forms.Label
        Me.lstvew1 = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.Btnloc = New System.Windows.Forms.Button
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Cmbxht = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.CmbxMatrl = New System.Windows.Forms.ComboBox
        Me.Cmbxgrad = New System.Windows.Forms.ComboBox
        Me.CmbxLnth = New System.Windows.Forms.ComboBox
        Me.Cmbxwdth = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Cmbxloc = New System.Windows.Forms.ComboBox
        Me.LblAlrt1 = New System.Windows.Forms.Label
        Me.Btnundrgrp = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.labelsn = New System.Windows.Forms.Label
        Me.cmbxunit = New System.Windows.Forms.ComboBox
        Me.txtsno = New System.Windows.Forms.TextBox
        Me.CmbxStokGrup = New System.Windows.Forms.ComboBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Txtratechek1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Txtratechek = New System.Windows.Forms.TextBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Txtmax = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtreordr = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.TxtItmname = New System.Windows.Forms.TextBox
        Me.Txtcode = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Btnmatrl = New System.Windows.Forms.Button
        Me.Btnwdth = New System.Windows.Forms.Button
        Me.Btngrad = New System.Windows.Forms.Button
        Me.Btnht = New System.Windows.Forms.Button
        Me.btnlnth = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnimage = New System.Windows.Forms.Button
        Me.PicItm = New System.Windows.Forms.PictureBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Label27 = New System.Windows.Forms.Label
        Me.cmbxexcise = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtval = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtper = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtrate = New System.Windows.Forms.TextBox
        Me.txtopnstok = New System.Windows.Forms.TextBox
        Me.Cmbxstatus = New System.Windows.Forms.ComboBox
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.stitclose = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.LblF2 = New System.Windows.Forms.Label
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.lblsubp = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.lblname = New System.Windows.Forms.Label
        Me.lblMainp = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.lblloc = New System.Windows.Forms.Label
        Me.gBoxUse = New System.Windows.Forms.GroupBox
        Me.rBTradingOnly = New System.Windows.Forms.RadioButton
        Me.rBPurchaseOnly = New System.Windows.Forms.RadioButton
        Me.rBSaleOnly = New System.Windows.Forms.RadioButton
        Me.ItmDg = New System.Windows.Forms.DataGridView
        Me.stitdelete = New System.Windows.Forms.Button
        Me.stitfind = New System.Windows.Forms.Button
        Me.stitsave = New System.Windows.Forms.Button
        Me.OpnFDlog1 = New System.Windows.Forms.OpenFileDialog
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PicItm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.gBoxUse.SuspendLayout()
        CType(Me.ItmDg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Txtitmremrk)
        Me.Panel1.Controls.Add(Me.LstVew2)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.lstvew1)
        Me.Panel1.Controls.Add(Me.Btnloc)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel1.Controls.Add(Me.LblAlrt1)
        Me.Panel1.Controls.Add(Me.Btnundrgrp)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Btnmatrl)
        Me.Panel1.Controls.Add(Me.Btnwdth)
        Me.Panel1.Controls.Add(Me.Btngrad)
        Me.Panel1.Controls.Add(Me.Btnht)
        Me.Panel1.Controls.Add(Me.btnlnth)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 377)
        Me.Panel1.TabIndex = 1
        '
        'Txtitmremrk
        '
        Me.Txtitmremrk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtitmremrk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtitmremrk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtitmremrk.Location = New System.Drawing.Point(73, 334)
        Me.Txtitmremrk.MaxLength = 250
        Me.Txtitmremrk.Name = "Txtitmremrk"
        Me.Txtitmremrk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txtitmremrk.Size = New System.Drawing.Size(523, 21)
        Me.Txtitmremrk.TabIndex = 19
        '
        'LstVew2
        '
        Me.LstVew2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstVew2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7})
        Me.LstVew2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVew2.FullRowSelect = True
        Me.LstVew2.GridLines = True
        Me.LstVew2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LstVew2.Location = New System.Drawing.Point(325, 180)
        Me.LstVew2.Name = "LstVew2"
        Me.LstVew2.Size = New System.Drawing.Size(269, 13)
        Me.LstVew2.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LstVew2.TabIndex = 59
        Me.LstVew2.TabStop = False
        Me.LstVew2.UseCompatibleStateImageBehavior = False
        Me.LstVew2.View = System.Windows.Forms.View.Details
        Me.LstVew2.Visible = False
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Name"
        Me.ColumnHeader6.Width = 245
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Id"
        Me.ColumnHeader7.Width = 0
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Navy
        Me.Label24.Location = New System.Drawing.Point(3, 337)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(64, 13)
        Me.Label24.TabIndex = 43
        Me.Label24.Text = "Remarks"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstvew1
        '
        Me.lstvew1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstvew1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lstvew1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstvew1.FullRowSelect = True
        Me.lstvew1.GridLines = True
        Me.lstvew1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstvew1.Location = New System.Drawing.Point(325, 196)
        Me.lstvew1.Name = "lstvew1"
        Me.lstvew1.Size = New System.Drawing.Size(106, 10)
        Me.lstvew1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstvew1.TabIndex = 58
        Me.lstvew1.TabStop = False
        Me.lstvew1.UseCompatibleStateImageBehavior = False
        Me.lstvew1.View = System.Windows.Forms.View.Details
        Me.lstvew1.Visible = False
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Name"
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Id"
        Me.ColumnHeader5.Width = 0
        '
        'Btnloc
        '
        Me.Btnloc.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btnloc.Location = New System.Drawing.Point(293, 310)
        Me.Btnloc.Name = "Btnloc"
        Me.Btnloc.Size = New System.Drawing.Size(26, 20)
        Me.Btnloc.TabIndex = 54
        Me.Btnloc.TabStop = False
        Me.Btnloc.Text = "...."
        Me.Btnloc.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.91228!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.08772!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label25, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Label13, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Cmbxht, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label17, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.CmbxMatrl, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Cmbxgrad, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.CmbxLnth, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Cmbxwdth, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label16, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label15, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label14, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Cmbxloc, 1, 5)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(1, 176)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.643!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.64301!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.64301!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.64301!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.64301!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.64301!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(286, 154)
        Me.TableLayoutPanel3.TabIndex = 6
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 126)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(121, 24)
        Me.Label25.TabIndex = 36
        Me.Label25.Text = "Store"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 24)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Height"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cmbxht
        '
        Me.Cmbxht.AllowDrop = True
        Me.Cmbxht.DropDownHeight = 80
        Me.Cmbxht.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxht.IntegralHeight = False
        Me.Cmbxht.ItemHeight = 13
        Me.Cmbxht.Location = New System.Drawing.Point(132, 4)
        Me.Cmbxht.Name = "Cmbxht"
        Me.Cmbxht.Size = New System.Drawing.Size(150, 21)
        Me.Cmbxht.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(4, 101)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 24)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Material "
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxMatrl
        '
        Me.CmbxMatrl.AllowDrop = True
        Me.CmbxMatrl.DropDownHeight = 80
        Me.CmbxMatrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxMatrl.IntegralHeight = False
        Me.CmbxMatrl.ItemHeight = 13
        Me.CmbxMatrl.Location = New System.Drawing.Point(132, 104)
        Me.CmbxMatrl.Name = "CmbxMatrl"
        Me.CmbxMatrl.Size = New System.Drawing.Size(150, 21)
        Me.CmbxMatrl.TabIndex = 17
        '
        'Cmbxgrad
        '
        Me.Cmbxgrad.AllowDrop = True
        Me.Cmbxgrad.DropDownHeight = 80
        Me.Cmbxgrad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxgrad.IntegralHeight = False
        Me.Cmbxgrad.ItemHeight = 13
        Me.Cmbxgrad.Location = New System.Drawing.Point(132, 79)
        Me.Cmbxgrad.Name = "Cmbxgrad"
        Me.Cmbxgrad.Size = New System.Drawing.Size(150, 21)
        Me.Cmbxgrad.TabIndex = 16
        '
        'CmbxLnth
        '
        Me.CmbxLnth.AllowDrop = True
        Me.CmbxLnth.DropDownHeight = 80
        Me.CmbxLnth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxLnth.IntegralHeight = False
        Me.CmbxLnth.ItemHeight = 13
        Me.CmbxLnth.Location = New System.Drawing.Point(132, 54)
        Me.CmbxLnth.Name = "CmbxLnth"
        Me.CmbxLnth.Size = New System.Drawing.Size(150, 21)
        Me.CmbxLnth.TabIndex = 15
        '
        'Cmbxwdth
        '
        Me.Cmbxwdth.AllowDrop = True
        Me.Cmbxwdth.DropDownHeight = 80
        Me.Cmbxwdth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxwdth.IntegralHeight = False
        Me.Cmbxwdth.ItemHeight = 13
        Me.Cmbxwdth.Location = New System.Drawing.Point(132, 29)
        Me.Cmbxwdth.Name = "Cmbxwdth"
        Me.Cmbxwdth.Size = New System.Drawing.Size(150, 21)
        Me.Cmbxwdth.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(4, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 24)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Grade"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(4, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 24)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Length"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(4, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(121, 24)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Width/Dia "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cmbxloc
        '
        Me.Cmbxloc.AllowDrop = True
        Me.Cmbxloc.DropDownHeight = 80
        Me.Cmbxloc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxloc.IntegralHeight = False
        Me.Cmbxloc.ItemHeight = 13
        Me.Cmbxloc.Location = New System.Drawing.Point(132, 129)
        Me.Cmbxloc.Name = "Cmbxloc"
        Me.Cmbxloc.Size = New System.Drawing.Size(150, 21)
        Me.Cmbxloc.TabIndex = 18
        '
        'LblAlrt1
        '
        Me.LblAlrt1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAlrt1.ForeColor = System.Drawing.Color.Red
        Me.LblAlrt1.Location = New System.Drawing.Point(96, 359)
        Me.LblAlrt1.Name = "LblAlrt1"
        Me.LblAlrt1.Size = New System.Drawing.Size(369, 12)
        Me.LblAlrt1.TabIndex = 43
        Me.LblAlrt1.Text = "Invalid Input, Only Numbers are valid."
        Me.LblAlrt1.Visible = False
        '
        'Btnundrgrp
        '
        Me.Btnundrgrp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btnundrgrp.Location = New System.Drawing.Point(558, 35)
        Me.Btnundrgrp.Name = "Btnundrgrp"
        Me.Btnundrgrp.Size = New System.Drawing.Size(26, 21)
        Me.Btnundrgrp.TabIndex = 48
        Me.Btnundrgrp.TabStop = False
        Me.Btnundrgrp.Text = "...."
        Me.Btnundrgrp.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(5, 359)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 12)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Error  : -"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label18.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.18841!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.81159!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.labelsn, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbxunit, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtsno, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbxStokGrup, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 1, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(1, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.17632!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.17632!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.17632!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.17632!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.11838!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.17632!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(553, 174)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Item Code && Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Under Group"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Sale Price"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Units "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelsn
        '
        Me.labelsn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelsn.Location = New System.Drawing.Point(4, 57)
        Me.labelsn.Name = "labelsn"
        Me.labelsn.Size = New System.Drawing.Size(91, 13)
        Me.labelsn.TabIndex = 27
        Me.labelsn.Text = "Serial No"
        Me.labelsn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbxunit
        '
        Me.cmbxunit.AllowDrop = True
        Me.cmbxunit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxunit.Items.AddRange(New Object() {"Kg", "No", "Pc", "Pair", "Litre", "meter", "Bag", "Box", "Gross", "Packet", "Dozen", "Set"})
        Me.cmbxunit.Location = New System.Drawing.Point(132, 88)
        Me.cmbxunit.Name = "cmbxunit"
        Me.cmbxunit.Size = New System.Drawing.Size(194, 21)
        Me.cmbxunit.TabIndex = 6
        '
        'txtsno
        '
        Me.txtsno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsno.Location = New System.Drawing.Point(132, 60)
        Me.txtsno.MaxLength = 50
        Me.txtsno.Name = "txtsno"
        Me.txtsno.Size = New System.Drawing.Size(343, 20)
        Me.txtsno.TabIndex = 5
        '
        'CmbxStokGrup
        '
        Me.CmbxStokGrup.AllowDrop = True
        Me.CmbxStokGrup.Location = New System.Drawing.Point(132, 32)
        Me.CmbxStokGrup.Name = "CmbxStokGrup"
        Me.CmbxStokGrup.Size = New System.Drawing.Size(414, 21)
        Me.CmbxStokGrup.Sorted = True
        Me.CmbxStokGrup.TabIndex = 4
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Txtratechek1)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.Txtratechek)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(132, 116)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(417, 25)
        Me.Panel5.TabIndex = 7
        '
        'Txtratechek1
        '
        Me.Txtratechek1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtratechek1.Location = New System.Drawing.Point(226, 2)
        Me.Txtratechek1.MaxLength = 18
        Me.Txtratechek1.Name = "Txtratechek1"
        Me.Txtratechek1.Size = New System.Drawing.Size(117, 20)
        Me.Txtratechek1.TabIndex = 9
        Me.Txtratechek1.Text = "0"
        Me.Txtratechek1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtratechek1.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(142, 4)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Sale Price"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Visible = False
        '
        'Txtratechek
        '
        Me.Txtratechek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtratechek.Location = New System.Drawing.Point(3, 2)
        Me.Txtratechek.MaxLength = 18
        Me.Txtratechek.Name = "Txtratechek"
        Me.Txtratechek.Size = New System.Drawing.Size(122, 20)
        Me.Txtratechek.TabIndex = 8
        Me.Txtratechek.Text = "0"
        Me.Txtratechek.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Txtmax)
        Me.Panel6.Controls.Add(Me.Label23)
        Me.Panel6.Controls.Add(Me.txtreordr)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(132, 148)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(417, 22)
        Me.Panel6.TabIndex = 10
        '
        'Txtmax
        '
        Me.Txtmax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtmax.Location = New System.Drawing.Point(226, 0)
        Me.Txtmax.MaxLength = 18
        Me.Txtmax.Name = "Txtmax"
        Me.Txtmax.Size = New System.Drawing.Size(117, 20)
        Me.Txtmax.TabIndex = 12
        Me.Txtmax.Text = "0"
        Me.Txtmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(142, 2)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 13)
        Me.Label23.TabIndex = 31
        Me.Label23.Text = "Max. Qnty "
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtreordr
        '
        Me.txtreordr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtreordr.Location = New System.Drawing.Point(3, 0)
        Me.txtreordr.MaxLength = 18
        Me.txtreordr.Name = "txtreordr"
        Me.txtreordr.Size = New System.Drawing.Size(122, 20)
        Me.txtreordr.TabIndex = 11
        Me.txtreordr.Text = "0"
        Me.txtreordr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Re-Order Level"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.TxtItmname)
        Me.Panel7.Controls.Add(Me.Txtcode)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(132, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(417, 21)
        Me.Panel7.TabIndex = 1
        '
        'TxtItmname
        '
        Me.TxtItmname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtItmname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtItmname.Location = New System.Drawing.Point(81, 0)
        Me.TxtItmname.MaxLength = 70
        Me.TxtItmname.Name = "TxtItmname"
        Me.TxtItmname.Size = New System.Drawing.Size(333, 20)
        Me.TxtItmname.TabIndex = 3
        '
        'Txtcode
        '
        Me.Txtcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtcode.Location = New System.Drawing.Point(0, 0)
        Me.Txtcode.MaxLength = 20
        Me.Txtcode.Name = "Txtcode"
        Me.Txtcode.Size = New System.Drawing.Size(78, 20)
        Me.Txtcode.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(325, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(325, 296)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(46, 13)
        Me.Label22.TabIndex = 47
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(325, 267)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(46, 13)
        Me.Label21.TabIndex = 46
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(325, 238)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 13)
        Me.Label20.TabIndex = 45
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(325, 209)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 13)
        Me.Label19.TabIndex = 44
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Btnmatrl
        '
        Me.Btnmatrl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btnmatrl.Location = New System.Drawing.Point(293, 284)
        Me.Btnmatrl.Name = "Btnmatrl"
        Me.Btnmatrl.Size = New System.Drawing.Size(26, 20)
        Me.Btnmatrl.TabIndex = 53
        Me.Btnmatrl.TabStop = False
        Me.Btnmatrl.Text = "...."
        Me.Btnmatrl.UseVisualStyleBackColor = True
        '
        'Btnwdth
        '
        Me.Btnwdth.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btnwdth.Location = New System.Drawing.Point(293, 205)
        Me.Btnwdth.Name = "Btnwdth"
        Me.Btnwdth.Size = New System.Drawing.Size(26, 20)
        Me.Btnwdth.TabIndex = 50
        Me.Btnwdth.TabStop = False
        Me.Btnwdth.Text = "...."
        Me.Btnwdth.UseVisualStyleBackColor = True
        '
        'Btngrad
        '
        Me.Btngrad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btngrad.Location = New System.Drawing.Point(293, 257)
        Me.Btngrad.Name = "Btngrad"
        Me.Btngrad.Size = New System.Drawing.Size(26, 20)
        Me.Btngrad.TabIndex = 52
        Me.Btngrad.TabStop = False
        Me.Btngrad.Text = "...."
        Me.Btngrad.UseVisualStyleBackColor = True
        '
        'Btnht
        '
        Me.Btnht.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btnht.Location = New System.Drawing.Point(293, 179)
        Me.Btnht.Name = "Btnht"
        Me.Btnht.Size = New System.Drawing.Size(26, 20)
        Me.Btnht.TabIndex = 49
        Me.Btnht.TabStop = False
        Me.Btnht.Text = "...."
        Me.Btnht.UseVisualStyleBackColor = True
        '
        'btnlnth
        '
        Me.btnlnth.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnlnth.Location = New System.Drawing.Point(293, 231)
        Me.btnlnth.Name = "btnlnth"
        Me.btnlnth.Size = New System.Drawing.Size(26, 20)
        Me.btnlnth.TabIndex = 51
        Me.btnlnth.TabStop = False
        Me.btnlnth.Text = "...."
        Me.btnlnth.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnimage)
        Me.Panel2.Controls.Add(Me.PicItm)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(3, 378)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(466, 176)
        Me.Panel2.TabIndex = 20
        '
        'btnimage
        '
        Me.btnimage.BackColor = System.Drawing.Color.Transparent
        Me.btnimage.BackgroundImage = Global.FinAcct.My.Resources.Resources.btn
        Me.btnimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnimage.Location = New System.Drawing.Point(243, 139)
        Me.btnimage.Name = "btnimage"
        Me.btnimage.Size = New System.Drawing.Size(215, 34)
        Me.btnimage.TabIndex = 24
        Me.btnimage.TabStop = False
        Me.btnimage.Text = "&Image"
        Me.btnimage.UseVisualStyleBackColor = False
        '
        'PicItm
        '
        Me.PicItm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicItm.InitialImage = Nothing
        Me.PicItm.Location = New System.Drawing.Point(243, 5)
        Me.PicItm.Name = "PicItm"
        Me.PicItm.Size = New System.Drawing.Size(215, 129)
        Me.PicItm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicItm.TabIndex = 12
        Me.PicItm.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.17857!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.82143!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label27, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbxexcise, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtval, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtper, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtrate, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtopnstok, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Cmbxstatus, 1, 5)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(1, 5)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.23325!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.23391!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.23391!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.23391!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.53244!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.53257!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(236, 167)
        Me.TableLayoutPanel2.TabIndex = 20
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Navy
        Me.Label27.Location = New System.Drawing.Point(4, 134)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(87, 26)
        Me.Label27.TabIndex = 56
        Me.Label27.Text = "Status "
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbxexcise
        '
        Me.cmbxexcise.AllowDrop = True
        Me.cmbxexcise.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmbxexcise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxexcise.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbxexcise.ForeColor = System.Drawing.Color.Navy
        Me.cmbxexcise.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmbxexcise.Location = New System.Drawing.Point(98, 108)
        Me.cmbxexcise.Name = "cmbxexcise"
        Me.cmbxexcise.Size = New System.Drawing.Size(99, 23)
        Me.cmbxexcise.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(4, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 24)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Opening Stock"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtval
        '
        Me.txtval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtval.Location = New System.Drawing.Point(98, 82)
        Me.txtval.Name = "txtval"
        Me.txtval.ReadOnly = True
        Me.txtval.Size = New System.Drawing.Size(130, 21)
        Me.txtval.TabIndex = 55
        Me.txtval.TabStop = False
        Me.txtval.Text = "0"
        Me.txtval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Navy
        Me.Label12.Location = New System.Drawing.Point(4, 105)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 28)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "Excise Details"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(4, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 24)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Value "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtper
        '
        Me.txtper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtper.Location = New System.Drawing.Point(98, 56)
        Me.txtper.Name = "txtper"
        Me.txtper.ReadOnly = True
        Me.txtper.Size = New System.Drawing.Size(99, 21)
        Me.txtper.TabIndex = 55
        Me.txtper.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(4, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 24)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Rate"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(4, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 25)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Per"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtrate
        '
        Me.txtrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtrate.Location = New System.Drawing.Point(98, 30)
        Me.txtrate.MaxLength = 18
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(130, 21)
        Me.txtrate.TabIndex = 21
        Me.txtrate.Text = "0"
        Me.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtopnstok
        '
        Me.txtopnstok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtopnstok.Location = New System.Drawing.Point(98, 4)
        Me.txtopnstok.MaxLength = 18
        Me.txtopnstok.Name = "txtopnstok"
        Me.txtopnstok.Size = New System.Drawing.Size(130, 21)
        Me.txtopnstok.TabIndex = 20
        Me.txtopnstok.Text = "0"
        Me.txtopnstok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cmbxstatus
        '
        Me.Cmbxstatus.AllowDrop = True
        Me.Cmbxstatus.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Cmbxstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxstatus.Enabled = False
        Me.Cmbxstatus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxstatus.ForeColor = System.Drawing.Color.Navy
        Me.Cmbxstatus.Items.AddRange(New Object() {"Consumable", "Non-Consumable"})
        Me.Cmbxstatus.Location = New System.Drawing.Point(98, 137)
        Me.Cmbxstatus.Name = "Cmbxstatus"
        Me.Cmbxstatus.Size = New System.Drawing.Size(130, 23)
        Me.Cmbxstatus.TabIndex = 23
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        '
        'stitclose
        '
        Me.stitclose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stitclose.BackColor = System.Drawing.Color.Transparent
        Me.stitclose.BackgroundImage = CType(resources.GetObject("stitclose.BackgroundImage"), System.Drawing.Image)
        Me.stitclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.stitclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold
        Me.stitclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.stitclose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stitclose.ForeColor = System.Drawing.Color.Navy
        Me.stitclose.Location = New System.Drawing.Point(4, 515)
        Me.stitclose.Name = "stitclose"
        Me.stitclose.Size = New System.Drawing.Size(164, 33)
        Me.stitclose.TabIndex = 28
        Me.stitclose.Text = "&Close"
        Me.stitclose.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.ForeColor = System.Drawing.Color.Navy
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 1)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.BackgroundImage = Global.FinAcct.My.Resources.Resources._8131hi
        Me.SplitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblF2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gBoxUse)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ItmDg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.stitclose)
        Me.SplitContainer1.Panel1.Controls.Add(Me.stitdelete)
        Me.SplitContainer1.Panel1.Controls.Add(Me.stitfind)
        Me.SplitContainer1.Panel1.Controls.Add(Me.stitsave)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.GhostWhite
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Size = New System.Drawing.Size(787, 557)
        Me.SplitContainer1.SplitterDistance = 175
        Me.SplitContainer1.TabIndex = 100
        Me.SplitContainer1.TabStop = False
        '
        'LblF2
        '
        Me.LblF2.BackColor = System.Drawing.Color.LightYellow
        Me.LblF2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblF2.ForeColor = System.Drawing.Color.Black
        Me.LblF2.Location = New System.Drawing.Point(4, 107)
        Me.LblF2.Name = "LblF2"
        Me.LblF2.Size = New System.Drawing.Size(164, 57)
        Me.LblF2.TabIndex = 37
        Me.LblF2.Text = "Error  : -"
        Me.LblF2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblF2.Visible = False
        '
        'Panel8
        '
        Me.Panel8.AutoScroll = True
        Me.Panel8.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.lblsubp)
        Me.Panel8.Controls.Add(Me.Label26)
        Me.Panel8.Controls.Add(Me.Label32)
        Me.Panel8.Controls.Add(Me.lblname)
        Me.Panel8.Controls.Add(Me.lblMainp)
        Me.Panel8.Controls.Add(Me.Label28)
        Me.Panel8.Controls.Add(Me.Label30)
        Me.Panel8.Controls.Add(Me.lblloc)
        Me.Panel8.Location = New System.Drawing.Point(3, 175)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(166, 199)
        Me.Panel8.TabIndex = 29
        Me.Panel8.Visible = False
        '
        'lblsubp
        '
        Me.lblsubp.AutoSize = True
        Me.lblsubp.ForeColor = System.Drawing.Color.Snow
        Me.lblsubp.Location = New System.Drawing.Point(7, 138)
        Me.lblsubp.Name = "lblsubp"
        Me.lblsubp.Size = New System.Drawing.Size(58, 13)
        Me.lblsubp.TabIndex = 0
        Me.lblsubp.Text = "Label26"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(6, 4)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(43, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "NAME"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Yellow
        Me.Label32.Location = New System.Drawing.Point(7, 123)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(99, 13)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "SUB POSITION"
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.ForeColor = System.Drawing.Color.Snow
        Me.lblname.Location = New System.Drawing.Point(6, 19)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(58, 13)
        Me.lblname.TabIndex = 0
        Me.lblname.Text = "Label26"
        '
        'lblMainp
        '
        Me.lblMainp.AutoSize = True
        Me.lblMainp.ForeColor = System.Drawing.Color.Snow
        Me.lblMainp.Location = New System.Drawing.Point(7, 98)
        Me.lblMainp.Name = "lblMainp"
        Me.lblMainp.Size = New System.Drawing.Size(58, 13)
        Me.lblMainp.TabIndex = 0
        Me.lblMainp.Text = "Label26"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.Yellow
        Me.Label28.Location = New System.Drawing.Point(6, 44)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 13)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "LOCATION"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.Yellow
        Me.Label30.Location = New System.Drawing.Point(7, 85)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(108, 13)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "MAIN POSITION"
        '
        'lblloc
        '
        Me.lblloc.AutoSize = True
        Me.lblloc.ForeColor = System.Drawing.Color.Snow
        Me.lblloc.Location = New System.Drawing.Point(7, 59)
        Me.lblloc.Name = "lblloc"
        Me.lblloc.Size = New System.Drawing.Size(58, 13)
        Me.lblloc.TabIndex = 0
        Me.lblloc.Text = "Label26"
        '
        'gBoxUse
        '
        Me.gBoxUse.Controls.Add(Me.rBTradingOnly)
        Me.gBoxUse.Controls.Add(Me.rBPurchaseOnly)
        Me.gBoxUse.Controls.Add(Me.rBSaleOnly)
        Me.gBoxUse.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gBoxUse.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.gBoxUse.Location = New System.Drawing.Point(4, -1)
        Me.gBoxUse.Name = "gBoxUse"
        Me.gBoxUse.Size = New System.Drawing.Size(165, 105)
        Me.gBoxUse.TabIndex = 0
        Me.gBoxUse.TabStop = False
        Me.gBoxUse.Text = "Available For"
        Me.gBoxUse.Visible = False
        '
        'rBTradingOnly
        '
        Me.rBTradingOnly.AutoSize = True
        Me.rBTradingOnly.Location = New System.Drawing.Point(7, 47)
        Me.rBTradingOnly.Name = "rBTradingOnly"
        Me.rBTradingOnly.Size = New System.Drawing.Size(75, 18)
        Me.rBTradingOnly.TabIndex = 0
        Me.rBTradingOnly.Text = "Trading"
        Me.rBTradingOnly.UseVisualStyleBackColor = True
        '
        'rBPurchaseOnly
        '
        Me.rBPurchaseOnly.AutoSize = True
        Me.rBPurchaseOnly.Checked = True
        Me.rBPurchaseOnly.Location = New System.Drawing.Point(7, 20)
        Me.rBPurchaseOnly.Name = "rBPurchaseOnly"
        Me.rBPurchaseOnly.Size = New System.Drawing.Size(86, 18)
        Me.rBPurchaseOnly.TabIndex = 0
        Me.rBPurchaseOnly.TabStop = True
        Me.rBPurchaseOnly.Text = "Purchase"
        Me.rBPurchaseOnly.UseVisualStyleBackColor = True
        '
        'rBSaleOnly
        '
        Me.rBSaleOnly.AutoSize = True
        Me.rBSaleOnly.Location = New System.Drawing.Point(6, 76)
        Me.rBSaleOnly.Name = "rBSaleOnly"
        Me.rBSaleOnly.Size = New System.Drawing.Size(54, 18)
        Me.rBSaleOnly.TabIndex = 0
        Me.rBSaleOnly.Text = "Sale"
        Me.rBSaleOnly.UseVisualStyleBackColor = True
        '
        'ItmDg
        '
        Me.ItmDg.AllowUserToOrderColumns = True
        Me.ItmDg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ItmDg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ItmDg.Location = New System.Drawing.Point(3, 138)
        Me.ItmDg.Name = "ItmDg"
        Me.ItmDg.Size = New System.Drawing.Size(166, 0)
        Me.ItmDg.TabIndex = 17
        Me.ItmDg.Visible = False
        '
        'stitdelete
        '
        Me.stitdelete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stitdelete.BackColor = System.Drawing.Color.Transparent
        Me.stitdelete.BackgroundImage = CType(resources.GetObject("stitdelete.BackgroundImage"), System.Drawing.Image)
        Me.stitdelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.stitdelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold
        Me.stitdelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.stitdelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stitdelete.ForeColor = System.Drawing.Color.Navy
        Me.stitdelete.Location = New System.Drawing.Point(5, 476)
        Me.stitdelete.Name = "stitdelete"
        Me.stitdelete.Size = New System.Drawing.Size(164, 33)
        Me.stitdelete.TabIndex = 27
        Me.stitdelete.Text = "Ca&ncle"
        Me.stitdelete.UseVisualStyleBackColor = False
        '
        'stitfind
        '
        Me.stitfind.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stitfind.BackColor = System.Drawing.Color.Transparent
        Me.stitfind.BackgroundImage = CType(resources.GetObject("stitfind.BackgroundImage"), System.Drawing.Image)
        Me.stitfind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.stitfind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold
        Me.stitfind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.stitfind.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stitfind.ForeColor = System.Drawing.Color.Navy
        Me.stitfind.Location = New System.Drawing.Point(4, 437)
        Me.stitfind.Name = "stitfind"
        Me.stitfind.Size = New System.Drawing.Size(164, 33)
        Me.stitfind.TabIndex = 26
        Me.stitfind.Text = "&Find"
        Me.stitfind.UseVisualStyleBackColor = False
        '
        'stitsave
        '
        Me.stitsave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stitsave.BackColor = System.Drawing.Color.Transparent
        Me.stitsave.BackgroundImage = CType(resources.GetObject("stitsave.BackgroundImage"), System.Drawing.Image)
        Me.stitsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.stitsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold
        Me.stitsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.stitsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stitsave.ForeColor = System.Drawing.Color.Navy
        Me.stitsave.Location = New System.Drawing.Point(4, 398)
        Me.stitsave.Name = "stitsave"
        Me.stitsave.Size = New System.Drawing.Size(164, 33)
        Me.stitsave.TabIndex = 25
        Me.stitsave.Text = "&Save"
        Me.stitsave.UseVisualStyleBackColor = False
        '
        'OpnFDlog1
        '
        Me.OpnFDlog1.FileName = "OpenFileDialog1"
        '
        'FrmStokItm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(788, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmStokItm"
        Me.Text = "Item   Master"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PicItm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.gBoxUse.ResumeLayout(False)
        Me.gBoxUse.PerformLayout()
        CType(Me.ItmDg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub tabindx()
        Panel1.Focus()
        Txtcode.TabIndex = 1
        CmbxStokGrup.TabIndex = 2
        txtsno.TabIndex = 3
        cmbxunit.TabIndex = 4
        Txtratechek.TabIndex = 5
        txtreordr.TabIndex = 6
        Panel2.Focus()
        txtopnstok.TabIndex = 2
        txtrate.TabIndex = 3
        cmbxexcise.TabIndex = 3
    End Sub

    Private Sub FrmStokItm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            sql = New inv_sql
            sql1 = New inv_sql
            CheckAcess_Btn_frm(stitsave, stitfind, stitdelete)
            C12 = 0
            C13 = 0
            'tabindx()
            fill_Cmbxundrgrup()
            Fill_Combobox_WitoutDelStatus("itmhtid", "itmhtin", "finact_itmhgtmstr", Cmbxht)
            Fill_Combobox_WitoutDelStatus("itmwdthid", "itmwdthin", "finact_itmwdthmstr", Cmbxwdth)
            Fill_Combobox_WitoutDelStatus("itmlnthid", "itmlnthin", "finact_itmlnthmstr", CmbxLnth)
            Fill_Combobox_WitoutDelStatus("itmgradid", "itmgradname", "finact_itmgradmstr", Cmbxgrad)
            Fill_Combobox_WitoutDelStatus("itmgradid", "itmmatrlname", "finact_itmmatrlmstr", CmbxMatrl)
            Dim cond As String = "Inner"
            Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", Cmbxloc, cond, "CSCDELSTATUS", CInt(1))
            If xItmMstrOptn = 0 Then
                Me.Text = "FINISHED ITEMS (SALES)" & "  Current User Name :- " & " " & Current_UserName
                Me.rBSaleOnly.Checked = True
            ElseIf xItmMstrOptn = 1 Then
                Me.Text = "TRADING ITEMS" & "  Current User Name :- " & " " & Current_UserName
                If FrmShow_flag(3) = True Then
                    Me.rBTradingOnly.Checked = True
                End If
            End If


            setcontrols()
            Me.SplitContainer1.IsSplitterFixed = True
            'Me.SplitContainer1.Panel1.Enabled = False
            Me.cmbxexcise.SelectedIndex = 1
            Me.Cmbxstatus.SelectedIndex = 1
            If FrmShow_flag(2) = True Then
                If Rbstatus(0) = 1 Then
                    Me.rBSaleOnly.Checked = True
                ElseIf Rbstatus(0) = 2 Then
                    Me.rBPurchaseOnly.Checked = True
                End If
            End If

            Me.cmbxexcise.SelectedIndex = 1
            FrmShow_flag(19) = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub fill_Cmbxundrgrup()
        Try
            grupnamcom = New SqlCommand("select Cogrupnam from FinactstokGrupname where codelstatus=1 and Cogrupnam!='" & ("Primary") & "' order by Cogrupnam ", FinActConn)
            grupnamdr = grupnamcom.ExecuteReader()
            While grupnamdr.Read()
                If grupnamdr.HasRows = True Then
                    CmbxStokGrup.Items.Add(grupnamdr(0))
                End If

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            grupnamdr.Close()
            grupnamcom = Nothing

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
                BtnnSave.Location = New System.Drawing.Point(268, 479)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
            Case "PayRoll"
                BtnnSave.Enabled = True
                BtnnSave.Location = New System.Drawing.Point(268, 479)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
        End Select
    End Sub
    Private Sub chkblan_val()

        With cmbxexcise
            If .Text = "" Then
                .BackColor = Color.Cyan
                indx = indx + 1
                .Focus()
            Else
                .BackColor = Color.White
            End If
        End With

        If Trim(txtopnstok.Text) <> "" And Trim(txtrate.Text) <> "" Then
            With txtrate
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    indx = indx + 1
                    .Focus()
                Else
                    .BackColor = Color.White
                End If
            End With
            With txtopnstok
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    indx = indx + 1
                    .Focus()
                Else
                    .BackColor = Color.White
                End If
            End With
        End If
        With Txtmax
            If .Text = "" Then
                .BackColor = Color.Cyan
                indx = indx + 1
                .Focus()
            Else
                .BackColor = Color.White
            End If
        End With
        With txtreordr
            If .Text = "" Then
                .BackColor = Color.Cyan
                indx = indx + 1
                .Focus()
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtratechek
            If .Text = "" Then
                .BackColor = Color.Cyan
                indx = indx + 1
                .Focus()
            Else
                .BackColor = Color.White
            End If
        End With
        If Txtratechek1.Visible = True Then
            With Txtratechek1
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    indx = indx + 1
                    .Focus()
                Else
                    .BackColor = Color.White
                End If
            End With
        End If


        With cmbxunit
            If .Text = "" Then
                .BackColor = Color.Cyan
                indx = indx + 1
                .Focus()
            Else
                .BackColor = Color.White
            End If
        End With

        With CmbxStokGrup
            If .Text = "" Then
                .BackColor = Color.Cyan
                indx = indx + 1
                .Focus()
            Else
                .BackColor = Color.White
            End If
        End With

        With TxtItmname
            If .Text = "" Then
                .BackColor = Color.Cyan
                indx = indx + 1
                .Focus()
                TxtItmname.Focus()
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtcode
            If .Text = "" Then
                .BackColor = Color.Cyan
                indx = indx + 1
                .Focus()
                Txtcode.Focus()
            Else
                .BackColor = Color.White
            End If
        End With

    End Sub

    Private Sub txtrate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.Leave
        Dim val1 As Double = 0
        Dim val2 As Double = 0
        Try
            If Len(Me.txtrate.Text.Trim) = 0 Then
                Me.txtrate.Text = 0
            End If
            If Trim(txtrate.Text) <> "" Then
                If IsNumeric(txtrate.Text) = False Or Trim(txtrate.Text.EndsWith("-")) = True Or Trim(txtrate.Text.StartsWith("-")) = True Then
                    txtrate.Focus()
                    txtrate.SelectAll()
                    LblAlrt1.Visible = True
                Else
                    txtrate.Text = FormatNumber(txtrate.Text, 2)
                    LblAlrt1.Visible = False
                End If
            Else
                LblAlrt1.Visible = False
            End If

            If Trim(txtopnstok.Text) <> "" And Trim(txtrate.Text) <> "" And IsNumeric(txtopnstok.Text) = True And IsNumeric(txtrate.Text) = True Then
                val1 = Trim(txtopnstok.Text)
                val2 = CDbl(txtrate.Text)
            End If

            txtval.Text = FormatNumber(val1 * val2, 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmbxunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxunit.GotFocus
        If cmbxunit.SelectedIndex = -1 Then
            cmbxunit.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbxunit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxunit.Leave
        Try
            If CheckBlank_IndxCmbx(Me.cmbxunit) = True Then
                txtper.Text = cmbxunit.Text
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub stitclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stitclose.Click
        Me.Close()
    End Sub

    Private Sub clrflds()
        Txtcode.Text = ""
        TxtItmname.Text = ""

        txtsno.Text = ""

        Txtratechek.Text = ""
        Txtratechek1.Text = ""
        txtreordr.Text = ""
        Txtmax.Text = ""
        txtopnstok.Text = ""
        txtrate.Text = ""
        txtval.Text = ""

        Me.Txtitmremrk.Text = ""
        Me.PicItm.Image = Nothing

    End Sub

    Private Sub stkitminsert()
        Try
            grpidcom = New SqlCommand("select cogrpid from FinactstokGrupname where Cogrupnam='" & (CmbxStokGrup.Text) & "' and Coprmtype='" & ("Stok") & "'", FinActConn)
            grpiddr = grpidcom.ExecuteReader()
            grpiddr.Read()
            grupid = grpiddr("cogrpid")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            grpiddr.Close()
            grpidcom = Nothing
        End Try
        Try
            insertcom = New SqlCommand("Finact_Itmmstr_Insert", FinActConn)
            insertcom.CommandType = CommandType.StoredProcedure
            insertcom.Parameters.AddWithValue("@itmcode", Txtcode.Text)
            insertcom.Parameters.AddWithValue("@itmname", TxtItmname.Text)
            insertcom.Parameters.AddWithValue("@itmcatid", grupid)
            insertcom.Parameters.AddWithValue("@itmsrno", txtsno.Text)
            insertcom.Parameters.AddWithValue("@itmunttype", cmbxunit.Text)
            insertcom.Parameters.AddWithValue("@itmwtetc", 0)

            If Txtratechek1.Visible = True Then
                If Trim(Txtratechek.Text) <> "" Then
                    insertcom.Parameters.AddWithValue("@itmratechek", (Txtratechek.Text))
                Else
                    insertcom.Parameters.AddWithValue("@itmratechek", 0) 'CDbl(0.00Txtratechek.Text))
                End If
                If Trim(Txtratechek1.Text) <> "" Then
                    insertcom.Parameters.AddWithValue("@itmsalerate", (Txtratechek1.Text))
                Else
                    insertcom.Parameters.AddWithValue("@itmsalerate", 0) 'CDbl(0.00Txtratechek.Text))
                End If
            Else
                If rBSaleOnly.Checked = True Then
                    insertcom.Parameters.AddWithValue("@itmratechek", (0.0))
                    insertcom.Parameters.AddWithValue("@itmsalerate", (Txtratechek.Text))
                ElseIf rBPurchaseOnly.Checked = True Then
                    insertcom.Parameters.AddWithValue("@itmratechek", (Txtratechek.Text))
                    insertcom.Parameters.AddWithValue("@itmsalerate", (0.0))
                End If

            End If

            insertcom.Parameters.AddWithValue("@itmreorder", txtreordr.Text)
            insertcom.Parameters.AddWithValue("@itmmax", Txtmax.Text)
            If Trim(txtopnstok.Text) <> "" Then
                insertcom.Parameters.AddWithValue("@itmopnqnty", txtopnstok.Text)
            Else
                insertcom.Parameters.AddWithValue("@itmopnqnty", 0)
            End If

            If Trim(txtrate.Text) <> "" Then
                insertcom.Parameters.AddWithValue("@itmopnrate", (txtrate.Text))
            Else
                insertcom.Parameters.AddWithValue("@itmopnrate", 0) ' CDbl(txtrate.Text))
            End If
            insertcom.Parameters.AddWithValue("@itmht", Cmbxht.SelectedValue)
            insertcom.Parameters.AddWithValue("@itmwdth", Cmbxwdth.SelectedValue)
            insertcom.Parameters.AddWithValue("@itmlnth", CmbxLnth.SelectedValue)
            insertcom.Parameters.AddWithValue("@itmgrad", Cmbxgrad.SelectedValue)
            insertcom.Parameters.AddWithValue("@itmmatrl", CmbxMatrl.SelectedValue)
            insertcom.Parameters.AddWithValue("@itmloc", 0) 'CInt(Cmbxloc.SelectedValue))
            insertcom.Parameters.AddWithValue("@itmopnval", (txtval.Text))
            If cmbxexcise.Text = "Yes" Then
                yn = 1
            Else
                yn = 0
            End If
            insertcom.Parameters.AddWithValue("@itmexciseinfo", yn)
            insertcom.Parameters.AddWithValue("@itmstatus", Trim(Cmbxstatus.Text))
            insertcom.Parameters.AddWithValue("@itmvatrate", 0) ' txtVat.Text)
            If Trim(ImagePath) <> "None" Then
                insertcom.Parameters.AddWithValue("@itmipath", ImagePath)
                SaveStyleImage()
            Else
                insertcom.Parameters.AddWithValue("@itmipath", "None")
            End If

            insertcom.Parameters.AddWithValue("@itmremrk", Trim(Txtitmremrk.Text))
            Dim TypeofItem As String = ""
            If rBSaleOnly.Checked = True Then
                TypeofItem = "Sale"
            ElseIf rBPurchaseOnly.Checked = True Then
                TypeofItem = "Purchase"
            ElseIf rBTradingOnly.Checked = True Then
                TypeofItem = "Trading"
            End If
            insertcom.Parameters.AddWithValue("@itmtype", Trim(TypeofItem))
            insertcom.Parameters.AddWithValue("@itmtype1", Trim("RawItem"))
            insertcom.Parameters.AddWithValue("@itmconcrnid", 0)
            insertcom.Parameters.AddWithValue("@itmadusrid", Current_UsrId)
            insertcom.Parameters.AddWithValue("@itmaddt", Now)
            insertcom.Parameters.AddWithValue("@itmdelstatus", DelStatus)
            insertcom.Parameters.AddWithValue("@itmInrbox", 0)
            insertcom.Parameters.AddWithValue("@itmOtrbox", 0)
            insertcom.ExecuteNonQuery()


            If FrmShow_flag(1) = True Then 'for item master
                IntHtCmMm(1) = Trim(Txtcode.Text)
            End If
            If FrmShow_flag(2) = True Then 'for bom master 
                IntHtCmMm(2) = Trim(Txtcode.Text)
            End If
            If FrmShow_flag(3) = True Then 'for bom master 
                IntHtCmMm(3) = Trim(Txtcode.Text)
            End If
            MessageBox.Show("Current Record Has Been Saved", "Current Item Saved! ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clrflds()
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MessageBox.Show("Invalid input! System has found a record already existed with the same value. Try another valuew", "Already Existed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MsgBox(ex.Message)
            End If

        Finally
            insertcom = Nothing
        End Try

    End Sub
    Private Sub SaveStyleImage()
        Dim xx As Boolean = False
        Try
            If Not ImagePath = Nothing Then
                Dim fileExists As Boolean
                If fileExists = My.Computer.FileSystem.FileExists(ImagePath) = True Then
                    My.Computer.FileSystem.CopyFile(MySource, ImagePath)
                Else
                    If MessageBox.Show("There is already an image with the same name in this location. Would you like to overwite it?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Return
                    Else
                        MySource = Application.StartupPath & "\" & ImagePath
                        Dim NewImageName As String = ""
                        For Each x As Char In Me.ImagePath
                            If x = "." Then
                                NewImageName += "N_1."
                            Else
                                NewImageName += x
                            End If
                        Next

                        My.Computer.FileSystem.CopyFile(MySource, NewImageName, True)
                        ''StyleImagePathUpdate(NewImageName)

                        xx = True
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If xx = True Then
                ' My.Computer.FileSystem.DeleteFile(ImagePath)
            End If
        End Try
    End Sub
    Private Sub StyleImagePathUpdate(ByVal xImgPath As String)
        ' ''Try
        ' ''    If FinActConn.State Then FinActConn.Close()
        ' ''    FinActConn.Open()
        ' ''    stcom = New SqlCommand("Finact_StyleImagePath_Update", FinActConn)
        ' ''    stcom.CommandType = CommandType.StoredProcedure
        ' ''    stcom.Parameters.AddWithValue("@stlid", Me.CmbxFind.SelectedValue)
        ' ''    stcom.Parameters.AddWithValue("@imagepath", Trim(xImgPath))
        ' ''    stcom.ExecuteNonQuery()
        ' ''Catch ex As Exception
        ' ''    MsgBox(ex.ToString)
        ' ''Finally
        ' ''    stcom.Dispose()
        ' ''End Try
    End Sub

    Private Sub stitsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stitsave.Click

        Try
            If stitsave.Text = "&Save" Then
                chkblan_val()
                If indx <> 0 Then
                    indx = 0
                    Exit Sub
                Else
                    stkitminsert()
                    Txtcode.Focus()
                    Txtcode.SelectAll()
                End If
            ElseIf stitsave.Text = "&Edit" Then
                If Me.ItmDg.SelectedRows.Count = 1 Then
                    ItmId_for_Alter = Me.ItmDg.SelectedRows(0).Cells(0).Value
                    Dim FrmAltr As New FrmAlterSelectedItem
                    FrmAltr.ShowInTaskbar = False
                    FrmAltr.ShowDialog()
                Else
                    MsgBox("System could not find any selected item.", MsgBoxStyle.Critical, "Select an Item")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub txtrate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrate.TextChanged
        Dim val1 As Double = 0
        Dim val2 As Double = 0
        Try
            If Trim(txtopnstok.Text) <> "" And Trim(txtrate.Text) <> "" And IsNumeric(txtopnstok.Text) = True And IsNumeric(txtrate.Text) = True Then
                val1 = Trim(txtopnstok.Text)
                val2 = CDbl(txtrate.Text)
            End If
            txtval.Text = FormatNumber(val1 * val2, 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtopnstok_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtopnstok.GotFocus
        Try
            Me.txtopnstok.SelectAll()

            Me.LblF2.Visible = True
            Me.LblF2.Text = "For Jump To Save Button, Press F2"
        
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtopnstok_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtopnstok.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                Me.stitsave.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtopnstok_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtopnstok.Leave
        Try
            If Len(Me.txtopnstok.Text.Trim) = 0 Then
                Me.txtopnstok.Text = 0
            End If
            txtrate_Leave(sender, e)
            If Trim(txtopnstok.Text) <> "" Then
                If IsNumeric(txtopnstok.Text) = False Or Trim(txtopnstok.Text.EndsWith("-")) = True Or Trim(txtopnstok.Text.StartsWith("-")) = True Then
                    txtopnstok.Focus()
                    txtopnstok.SelectAll()
                    LblAlrt1.Visible = True
                Else
                    LblAlrt1.Visible = False
                End If
            Else
                LblAlrt1.Visible = False
            End If
            Me.LblF2.Visible = False
            Me.LblF2.Text = ""
        Catch ex As Exception

        End Try

    End Sub

    Private Sub stitfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stitfind.Click

        Try
            If stitfind.Text = "&Find" Then
                Panel1.Visible = False
                Panel2.Visible = False
                Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 50
                Me.SplitContainer1.SplitterDistance = 138
                Me.SplitContainer1.IsSplitterFixed = True
                Create_fill_ItmDg()
                stitsave.Text = "&Edit"
                stitfind.Text = "&Delete"
            Else
                If MessageBox.Show("Are you sure to delete?", "Item configuration", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                Try
                    If ItmDg.SelectedRows.Count > 0 Then
                        Dim i As Integer = 0

                        For i = 0 To ItmDg.SelectedRows.Count - 1
                            itmnamcom = New SqlCommand("Delete from finactitmmstr where itmid=@itmid", FinActConn)
                            itmnamcom.Parameters.AddWithValue("@itmid", Me.ItmDg.SelectedRows(i).Cells(0).Value)
                            itmnamcom.ExecuteNonQuery()
                        Next
                        MsgBox("Current record has been successfully  deleted ", MsgBoxStyle.Information)
                        Create_fill_ItmDg()
                    Else
                        MsgBox("System could not found any selected item to delete, Make it sure atleast one item should be selected.", MsgBoxStyle.Information, Me.Text)
                    End If

                Catch ex As SqlException
                    If ex.Number.Equals(8178) = True Then
                        MsgBox("System could not found any selected item to delete, Make it sure atleast one item should be selected.", MsgBoxStyle.Information, Me.Text)
                    Else
                        MessageBox.Show(ex.Message)
                    End If

                Finally
                    If ItmDg.SelectedRows.Count > 0 Then
                        itmnamcom.Dispose()
                    End If
                End Try
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally


        End Try

    End Sub
    Private Sub itmdelete()
        DelStatus = 0
        Try
            delstcom = New SqlCommand("Finact_Itmmstr_Delst", FinActConn)
            delstcom.CommandType = CommandType.StoredProcedure
            delstcom.Parameters.AddWithValue("@itmname", Txtcode.Text)
            delstcom.Parameters.AddWithValue("@itmdelusrid", Current_UsrId)
            delstcom.Parameters.AddWithValue("@itmdeldt", Now)
            delstcom.Parameters.AddWithValue("@itmdelstatus", DelStatus)
            delstcom.ExecuteNonQuery()

            MsgBox("Record Deleted")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            delstcom = Nothing
        End Try
    End Sub

    Private Sub stitdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stitdelete.Click

        If stitfind.Text = "&Delete" Then
            ItmDg.Visible = False
            Panel1.Visible = True
            Panel2.Visible = True
            Me.Width = 794
            Me.SplitContainer1.IsSplitterFixed = False
            Me.SplitContainer1.SplitterDistance = 175
            stitsave.Text = "&Save"
            stitfind.Text = "&Find"
        Else
            clrflds()
        End If
    End Sub


    Private Sub CmbxStokGrup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.GotFocus
        Try
            CmbxStokGrup.DroppedDown = True
            If xCmbxRefresh = True Then
                CmbxStokGrup.Items.Clear()
                fill_Cmbxundrgrup()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtratechek_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtratechek.GotFocus
        Try
            Me.LblF2.Visible = True
            Me.LblF2.Text = "For Jump To Store Column, Press F2"
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Txtratechek_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtratechek.Leave
        Try
            Check_Minus_Dot(Txtratechek, LblAlrt1)
            If Len(Me.Txtratechek.Text.Trim) = 0 Then
                Me.Txtratechek.Text = 0
            End If

            If Trim(Txtratechek.Text) <> "" Then
                If IsNumeric(Txtratechek.Text) = False Or Trim(Txtratechek.Text.EndsWith("-")) = True Or Trim(Txtratechek.Text.StartsWith("-")) = True Then
                    Txtratechek.Focus()
                    Txtratechek.SelectAll()
                    LblAlrt1.Visible = True
                Else

                    Txtratechek.Text = FormatNumber(Txtratechek.Text, 2)
                    LblAlrt1.Visible = False
                End If
            Else
                LblAlrt1.Visible = False
            End If
            Me.LblF2.Visible = False
            Me.LblF2.Text = ""
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtreordr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtreordr.Leave
        Try
            If Len(txtreordr.Text.Trim) = 0 Then
                Me.txtreordr.Text = 0
            End If
            If Trim(txtreordr.Text) <> "" Then
                If IsNumeric(txtreordr.Text) = False Then
                    txtreordr.Focus()
                    txtreordr.SelectAll()
                    LblAlrt1.Visible = True
                Else
                    LblAlrt1.Visible = False
                End If
            Else
                LblAlrt1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxexcise_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxexcise.GotFocus
        If cmbxexcise.Items.Count > 0 Then
            If cmbxexcise.SelectedIndex = -1 Then
                cmbxexcise.SelectedIndex = 0
            End If
        End If
    End Sub


    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Panel2.KeyDown, txtrate.KeyDown, txtsno.KeyDown, Txtratechek.KeyDown, txtsno.KeyDown, txtopnstok.KeyDown, txtval.KeyDown, Panel2.KeyDown, Label9.KeyDown, LblAlrt1.KeyDown, Label10.KeyDown, Label12.KeyDown, Label2.KeyDown, Label4.KeyDown, cmbxexcise.KeyDown, Label3.KeyDown, Label4.KeyDown, Label5.KeyDown, Label7.KeyDown, Label8.KeyDown, Label9.KeyDown, labelsn.KeyDown, CmbxStokGrup.KeyDown, cmbxunit.KeyDown, Label1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            Exit Sub
        End If

    End Sub
    Private Sub ALLkeydownEnter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtrate.KeyDown, txtsno.KeyDown, Txtratechek.KeyDown, txtopnstok.KeyDown, txtval.KeyDown, cmbxexcise.KeyDown, CmbxStokGrup.KeyDown, cmbxunit.KeyDown, Cmbxgrad.KeyDown, Cmbxht.KeyDown, CmbxLnth.KeyDown, Cmbxloc.KeyDown, CmbxMatrl.KeyDown, Cmbxstatus.KeyDown, Cmbxwdth.KeyDown, rBPurchaseOnly.KeyDown, rBSaleOnly.KeyDown, rBTradingOnly.KeyDown, Txtcode.KeyDown, TxtItmname.KeyDown, Txtitmremrk.KeyDown, Txtmax.KeyDown, txtper.KeyDown, Txtratechek1.KeyDown, txtreordr.KeyDown, Panel5.KeyDown, Panel6.KeyDown, Panel7.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Txtratechek_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtratechek.KeyDown, Cmbxht.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                Me.Cmbxloc.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub AllCombox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.GotFocus, Cmbxgrad.GotFocus, Cmbxht.GotFocus, CmbxLnth.GotFocus, Cmbxloc.GotFocus, CmbxMatrl.GotFocus, Cmbxstatus.GotFocus, CmbxStokGrup.GotFocus, cmbxunit.GotFocus, Cmbxwdth.GotFocus
        Try
            Dim Cmbx As ComboBox = Nothing
            Cmbx = CType(sender, ComboBox)

            Cmbx.DroppedDown = True
        Catch ex As Exception

        End Try

    End Sub
    Private Sub AllCombox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.Leave, Cmbxgrad.Leave, Cmbxht.Leave, CmbxLnth.Leave, Cmbxloc.Leave, CmbxMatrl.Leave, Cmbxstatus.Leave, CmbxStokGrup.Leave, cmbxunit.Leave, Cmbxwdth.Leave
        Try
            Dim Cmbx As ComboBox = Nothing
            Cmbx = CType(sender, ComboBox)

            Cmbx.DroppedDown = False
            If Cmbx.Name = Me.Cmbxht.Name Then
                Me.LblF2.Visible = False
                Me.LblF2.Text = ""
            End If
        Catch ex As Exception

        End Try

    End Sub



    Private Sub Cmbxht_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxht.GotFocus
        Try
            Me.LblF2.Visible = True
            Me.LblF2.Text = "For Jump To Store Column, Press F2"
            If FrmShow_flag(1) = True Then
                Fill_Combobox_WitoutDelStatus("itmhtid", "itmhtin", "finact_itmhgtmstr", Cmbxht)
                Dim Indxht As Integer = Cmbxht.FindString(IntHtCmMm(1), 0)
                Cmbxht.SelectedIndex = Indxht
            Else
                If Cmbxht.Items.Count > 0 And Cmbxht.SelectedIndex = -1 Then
                    Cmbxht.SelectedIndex = 0
                    Dim Xitmid As Integer = 0
                    Chk_Exisit2("finact_itmhgtmstr", "itmhttype", "itmhtid", Xitmid)
                    Label6.Text = ""
                    Label6.Text = xStr2.ToString
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Cmbxht_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxht.Leave
        If FrmShow_flag(1) = True Then
            FrmShow_flag(1) = False

        End If
        If Trim(Cmbxht.Text) = "" Then
            Cmbxht.Text = 0.0
        End If

    End Sub

    Private Sub Cmbxht_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxht.SelectedIndexChanged
        If Cmbxht.SelectedIndex > 0 Then
            Dim Xitmid As Integer = CInt(Cmbxht.SelectedValue)
            Chk_Exisit2("finact_itmhgtmstr", "itmhttype", "itmhtid", Xitmid)
            Label6.Text = ""
            Label6.Text = xStr2.ToString
        Else
            Cmbxht_GotFocus(sender, e)
        End If

    End Sub

    Private Sub Cmbxwdth_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxwdth.GotFocus
        If FrmShow_flag(1) = True Then
            Fill_Combobox_WitoutDelStatus("itmwdthid", "itmwdthin", "finact_itmwdthmstr", Cmbxwdth)
            Dim Indxht As Integer = Cmbxwdth.FindString(IntHtCmMm(1), 0)
            Cmbxwdth.SelectedIndex = Indxht
        Else
            If Cmbxwdth.Items.Count > 0 And Cmbxwdth.SelectedIndex = -1 Then
                Cmbxwdth.SelectedIndex = 0
                Dim Xitmid As Integer = 0
                Chk_Exisit2("finact_itmwdthmstr", "itmwdthtype", "itmwdthid", Xitmid)
                Label19.Text = ""
                Label19.Text = xStr2.ToString
            End If

        End If

    End Sub

    Private Sub Cmbxwdth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxwdth.Leave
        If FrmShow_flag(1) = True Then
            FrmShow_flag(1) = False
            ' CmbxLnth.Focus()
        End If
        If Trim(Cmbxwdth.Text) = "" Then
            Cmbxwdth.Text = 0.0
        End If
    End Sub


    Private Sub Cmbxwdth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxwdth.SelectedIndexChanged
        If Cmbxwdth.SelectedIndex > 0 Then
            Dim Xitmid As Integer = CInt(Cmbxwdth.SelectedValue)
            Chk_Exisit2("finact_itmwdthmstr", "itmwdthtype", "itmwdthid", Xitmid)
            Label19.Text = ""
            Label19.Text = xStr2.ToString
        Else
            Cmbxwdth_GotFocus(sender, e)
        End If
    End Sub

    Private Sub CmbxLnth_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxLnth.GotFocus

        If FrmShow_flag(1) = True Then
            Fill_Combobox_WitoutDelStatus("itmlnthid", "itmlnthin", "finact_itmlnthmstr", CmbxLnth)
            Dim Indxht As Integer = CmbxLnth.FindString(IntHtCmMm(1), 0)
            CmbxLnth.SelectedIndex = Indxht
        Else
            If CmbxLnth.Items.Count > 0 And CmbxLnth.SelectedIndex = -1 Then
                CmbxLnth.SelectedIndex = 0
                Dim Xitmid As Integer = 0
                Chk_Exisit2("finact_itmlnthmstr", "itmhttype", "itmlnthid", Xitmid)
                Label20.Text = ""
                Label20.Text = xStr2.ToString

            End If

        End If

    End Sub

    Private Sub CmbxLnth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxLnth.Leave
        If FrmShow_flag(1) = True Then
            FrmShow_flag(1) = False
        End If
        If Trim(CmbxLnth.Text) = "" Then
            CmbxLnth.Text = 0.0
        End If
    End Sub

    Private Sub CmbxLnth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxLnth.SelectedIndexChanged
        If CmbxLnth.SelectedIndex > 0 Then
            Dim Xitmid As Integer = CInt(CmbxLnth.SelectedValue)
            Chk_Exisit2("finact_itmlnthmstr", "itmhttype", "itmlnthid", Xitmid)
            Label20.Text = ""
            Label20.Text = xStr2.ToString
        Else
            CmbxLnth_GotFocus(sender, e)
        End If
    End Sub

    Private Sub Cmbxgrad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxgrad.GotFocus

        If FrmShow_flag(1) = True Then
            Fill_Combobox_WitoutDelStatus("itmgradid", "itmgradname", "finact_itmgradmstr", Cmbxgrad)
            Dim Indxht As Integer = Cmbxgrad.FindString(IntHtCmMm(1), 0)
            Cmbxgrad.SelectedIndex = Indxht
        Else
            If Cmbxgrad.Items.Count > 0 And Cmbxgrad.SelectedIndex = -1 Then
                Cmbxgrad.SelectedIndex = 0
            End If

        End If

    End Sub


    Private Sub CmbxMatrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxMatrl.GotFocus
        If FrmShow_flag(1) = True Then
            Fill_Combobox_WitoutDelStatus("itmgradid", "itmmatrlname", "finact_itmmatrlmstr", CmbxMatrl)
            Dim Indxht As Integer = CmbxMatrl.FindString(IntHtCmMm(1), 0)
            CmbxMatrl.SelectedIndex = Indxht
        Else
            If CmbxMatrl.Items.Count > 0 And CmbxMatrl.SelectedIndex = -1 Then
                CmbxMatrl.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub Create_fill_ItmDg()

        Try
            ItmDg.Columns.Clear()
            ItmDg.Rows.Clear()
            ItmDg.ReadOnly = True
            ItmDg.Size = New Drawing.Size(Me.Width - Me.SplitContainer1.SplitterDistance - 10, Me.Height - (0 + 40))
            ItmDg.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            ItmDg.ForeColor = Color.Navy
            ItmDg.Columns.Add("iid", "Id")
            ItmDg.Columns.Add("icode", "Code")
            ItmDg.Columns.Add("in", "Name Of The Item")
            ItmDg.Columns(1).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns.Add("Group", "Under Group")
            ItmDg.Columns.Add("srno", "Serial No.")
            ItmDg.Columns.Add("units", "Units")
            ItmDg.Columns.Add("untMearmnt", "Measurement")
            ItmDg.Columns.Add("ratecheck", "Purchase Check Rate")
            ItmDg.Columns.Add("salr", "Sale Rate")
            ItmDg.Columns.Add("reorder", "Reorder Level")
            ItmDg.Columns.Add("max", "Max. Qnty")
            ItmDg.Columns.Add("ht", "Height")
            ItmDg.Columns.Add("wdth", "Width")
            ItmDg.Columns.Add("lnth", "Length")
            ItmDg.Columns.Add("grad", "Grade")
            ItmDg.Columns.Add("matrl", "Material")
            ItmDg.Columns.Add("loc", "Location")
            ItmDg.Columns.Add("opnstok", "Opening Stock")
            ItmDg.Columns.Add("rate", "Rate")
            ItmDg.Columns.Add("per", "Per")
            ItmDg.Columns.Add("value", "Value")
            ItmDg.Columns.Add("excise", "Excise Detail")
            ItmDg.Columns.Add("ITms", "Status")
            ItmDg.Columns.Add("ipath", "Item Image Path")
            ItmDg.Columns.Add("iremrk", "Item Remarks")
            ItmDg.Columns.Add("itype", "Item Type")
            ItmDg.Columns.Add("itype1", "Item Nature")
            ItmDg.Columns.Add("conid", "Concern Item Status")
            ItmDg.Columns.Add("Adusr", "Add User")
            ItmDg.Columns.Add("addt", "Add Date")
            ItmDg.Columns.Add("edtusr", "Edit User")
            ItmDg.Columns.Add("edtdt", "Edit Date")
            ItmDg.Columns.Add("Inbox", "Inner Box")
            ItmDg.Columns.Add("Outbox", "Outer Box")
            ' ItmDg.Columns(18).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(19).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(20).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(25).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(26).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(27).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(28).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(29).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(30).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(31).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(29).Width = 250
            ItmDg.Columns(31).Width = 250
            ItmDg.Columns(16).Width = 0
            ItmDg.Columns(16).Visible = False
            ItmDg.Columns(11).Visible = False
            ItmDg.Columns(12).Visible = False
            ItmDg.Columns(13).Visible = False
            ItmDg.Columns(14).Visible = False
            ItmDg.Columns(15).Visible = False
            ItmDg.Columns(21).Visible = False
            ItmDg.Columns(22).Visible = False
            ItmDg.Columns(23).Visible = False
            ItmDg.Columns(25).Visible = False
            ItmDg.Columns(26).Visible = False
            ItmDg.Columns(27).Visible = False
            ItmDg.Columns(32).Visible = False
            ItmDg.Columns(33).Visible = False
            ItmDg.Columns(5).DisplayIndex = 4
            ItmDg.Columns(9).DisplayIndex = 5
            ItmDg.Columns(10).DisplayIndex = 6
            ItmDg.Columns(17).DisplayIndex = 7
            ItmDg.Columns(18).DisplayIndex = 8

            ItmDg.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.ColumnHeadersHeight = 60
            ItmDg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            ItmDg.BorderStyle = BorderStyle.FixedSingle
            ItmDg.BackgroundColor = Color.Snow
            Me.SplitContainer1.Panel2.Controls.Add(ItmDg)
            ItmDg.Visible = True
            ItmDg.Left = 0
            ItmDg.Top = 2
            ItmDg.Columns(0).Visible = False
            ItmDg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            Dim pn1(0), pv1(0) As String ''Arrays for procedure argu name n value
            'pn1(0) = "@tblname"
            'pv1(0) = "FinactItmmstr"
            'sql.get_data("finact_select_all", pn1, pv1, "ItmMaster")
            Dim pn11(2), pv11(2) As String ''Arrays for procedure argu name n value
            Dim ItmType As String = ""
            If Me.rBPurchaseOnly.Checked = True Then
                ItmType = "Purchase"
            ElseIf Me.rBSaleOnly.Checked = True Then
                ItmType = "Sale"
            ElseIf Me.rBTradingOnly.Checked = True Then
                ItmType = "Trading"
            End If
            pn11(0) = "@ta"
            pn11(1) = "@id"
            pn11(2) = "@idval"

            pv11(0) = "FinactItmmstr"
            pv11(1) = "itmtype"
            pv11(2) = ItmType

            sql.get_data("select_where_like_selective", pn11, pv11, "ItmMaster") ' "ItmMaster" stands for ItemMaster
            Dim mk As Integer
            For mk = 0 To sql.ds.Tables("ItmMaster").Rows.Count - 1
                Itmdgr = New DataGridViewRow()
                'for fetching id
                Itmcel = New DataGridViewTextBoxCell()
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(0).ToString()
                Itmdgr.Cells.Add(Itmcel)

                ' for fetching code
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(1).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(1).ReadOnly = True


                ' for fetching name
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(2).ToString()
                Itmdgr.Cells.Add(Itmcel)


                'for fetching groupname
                Itmcel = New DataGridViewTextBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finactstokgrupname"
                pv11(1) = "cogrpid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(3).ToString()

                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcel.Value = (sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
                sql1.ds.Tables("IM").Dispose()
                Itmdgr.Cells.Add(Itmcel)

                ' for fetching Sr No.
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(4).ToString()
                Itmdgr.Cells.Add(Itmcel)

                'for fetching Units
                Itmcel = New DataGridViewTextBoxCell

                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(5).ToString()
                Itmdgr.Cells.Add(Itmcel)

                'for fetching unit Measurement
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(6).ToString(), 3)
                Itmdgr.Cells.Add(Itmcel)

                'for fetching ratechecker
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(7).ToString(), 2)
                Itmdgr.Cells.Add(Itmcel)

                'for fetching sale rate
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(8).ToString(), 2)
                Itmdgr.Cells.Add(Itmcel)


                'for fetching Reorder
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(9).ToString()
                Itmdgr.Cells.Add(Itmcel)

                'for fetching Maximum
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(10).ToString()
                Itmdgr.Cells.Add(Itmcel)


                'for fetching item height
                Itmcel = New DataGridViewTextBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finact_itmhgtmstr"
                pv11(1) = "itmhtid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(12).ToString()
                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcel.Value = (sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
                sql1.ds.Tables("IM").Dispose()
                Itmdgr.Cells.Add(Itmcel)

                'for fetching item Width
                Itmcel = New DataGridViewTextBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finact_itmwdthmstr"
                pv11(1) = "itmwdthid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(13).ToString()

                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcel.Value = (sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
                sql1.ds.Tables("IM").Dispose()
                Itmdgr.Cells.Add(Itmcel)

                'for fetching item Length
                Itmcel = New DataGridViewTextBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finact_itmlnthmstr"
                pv11(1) = "itmlnthid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(14).ToString()

                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcel.Value = (sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
                sql1.ds.Tables("IM").Dispose()
                Itmdgr.Cells.Add(Itmcel)


                'for fetching item Grade
                Itmcel = New DataGridViewTextBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finact_itmgradmstr"
                pv11(1) = "itmgradid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(15).ToString()

                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcel.Value = (sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
                sql1.ds.Tables("IM").Dispose()
                Itmdgr.Cells.Add(Itmcel)

                'for fetching item Material
                Itmcel = New DataGridViewTextBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finact_itmmatrlmstr"
                pv11(1) = "itmgradid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(16).ToString()

                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcel.Value = (sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
                sql1.ds.Tables("IM").Dispose()
                Itmdgr.Cells.Add(Itmcel)

                'for fetching item location
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = "None"
                Itmdgr.Cells.Add(Itmcel)


                'for fetching OPENING STOCK QNTY
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(11).ToString()
                Itmdgr.Cells.Add(Itmcel)

                'for fetching opnstock rate
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(18).ToString(), 2)
                Itmdgr.Cells.Add(Itmcel)

                'for fetching per type
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = Itmdgr.Cells(5).Value
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(19).ReadOnly = True


                'for fetching stockvalue
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(19).ToString(), 2)
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(20).ReadOnly = True


                'for fetching excise yesno status
                Itmcel = New DataGridViewTextBoxCell
                Dim ysno As String = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(20).ToString()
                If ysno = 1 Then
                    Itmcel.Value = "Yes"
                Else
                    Itmcel.Value = "No"
                End If
                Itmdgr.Cells.Add(Itmcel)

                'for fetching item status
                Itmcel = New DataGridViewTextBoxCell
                Dim a As String = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(21).ToString()
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(21).ToString()
                Itmdgr.Cells.Add(Itmcel)


                ' for fetching image path
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(23).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(23).ReadOnly = True

                ' for fetching item remarks
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(24).ToString()
                Itmdgr.Cells.Add(Itmcel)



                ' for fetching item type
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(25).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(25).ReadOnly = True

                ' for fetching item nature
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(26).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(26).ReadOnly = True

                ' for fetching item concern id
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(27).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(27).ReadOnly = True

                'for fetching add user
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(28).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(28).ReadOnly = True


                'for fetching add date
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(29).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(29).ReadOnly = True


                'for fetching edit user
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(30).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(30).ReadOnly = True

                'for fetching edit date
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(31).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(31).ReadOnly = True

                'for fetching Inner Box pack
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(35).ToString(), 3)
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(32).ReadOnly = True

                'for fetching Outer Box pack
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(36).ToString(), 3)
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(33).ReadOnly = True


                ItmDg.Rows.Add(Itmdgr)

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sql.cnn.Close()
            sql.ds.Dispose()
            ItmDg.AllowUserToAddRows = False
        End Try
    End Sub


    Private Sub Btnundrgrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnundrgrp.Click
        Try
            xCall_LinkFrm(FrmStokgrup, Me.CmbxStokGrup)
            'Dim frmUg As New FrmStokgrup
            'frmUg.ShowInTaskbar = False
            FrmShow_flag(1) = True
            'frmUg.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btnundrgrp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnundrgrp.GotFocus
        If FrmShow_flag(1) = True Then
            Me.CmbxStokGrup.Focus()
        End If
    End Sub

    Private Sub CmbxStokGrup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxStokGrup) = True Then
                If FrmShow_flag(1) = True Then
                    FrmShow_flag(1) = False
                    txtsno.Focus()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btnht_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnht.Click
        Dim frmht As New FrmHghtMstr
        frmht.ShowInTaskbar = False
        FrmShow_flag(1) = True
        frmht.ShowDialog()

    End Sub


    Private Sub Btnht_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnht.GotFocus
        If FrmShow_flag(1) = True Then
            Cmbxht.Focus()
        End If
    End Sub

    Private Sub Btnwdth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnwdth.Click
        Dim frmwdth As New FrmWdthMstr
        frmwdth.ShowInTaskbar = False
        FrmShow_flag(1) = True
        frmwdth.ShowDialog()
    End Sub

    Private Sub Btnwdth_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnwdth.GotFocus
        If FrmShow_flag(1) = True Then
            Cmbxwdth.Focus()
        End If
    End Sub

    Private Sub btnlnth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlnth.Click
        Dim frmlnth As New FrmLnthMstr
        frmlnth.ShowInTaskbar = False
        FrmShow_flag(1) = True
        frmlnth.ShowDialog()
    End Sub

    Private Sub btnlnth_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlnth.GotFocus
        If FrmShow_flag(1) = True Then
            CmbxLnth.Focus()
        End If
    End Sub

    Private Sub Btnmatrl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnmatrl.Click
        Dim frmmatrl As New FrmMatrlMstr
        frmmatrl.ShowInTaskbar = False
        FrmShow_flag(1) = True
        frmmatrl.ShowDialog()
    End Sub

    Private Sub Btnmatrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnmatrl.GotFocus
        If FrmShow_flag(1) = True Then
            CmbxMatrl.Focus()
        End If
    End Sub

    Private Sub Btngrad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btngrad.Click
        Dim frmgrad As New FrmGradMstr
        frmgrad.ShowInTaskbar = False
        FrmShow_flag(1) = True
        frmgrad.ShowDialog()
    End Sub

    Private Sub Btngrad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btngrad.GotFocus
        If FrmShow_flag(1) = True Then
            Cmbxgrad.Focus()
        End If
    End Sub

    Private Sub Cmbxgrad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxgrad.Leave
        If FrmShow_flag(1) = True Then
            FrmShow_flag(1) = False
        End If
        If Trim(Cmbxgrad.Text) = "" Then
            Cmbxgrad.Text = "<None>"
        End If
    End Sub

    Private Sub btnimage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimage.Click
        Try
            Dim ImageName As String
            If OpnFDlog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                MySource = OpnFDlog1.FileName
                ImageName = OpnFDlog1.FileName
                Me.PicItm.Image = Image.FromFile(MySource)
                ImagePath = "StyleImages\" & IO.Path.GetFileName(ImageName)
                Dim xxlen As Integer = Len(ImagePath)
                If xxlen > 199 Then
                    Me.PicItm.Image = Nothing
                    ImagePath = Nothing
                    MsgBox("Invalid input!, Image Path is too long to adjust within given lenth", MsgBoxStyle.Critical, Me.Text)
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
        ''Try
        ''    If OpnFDlog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        ''        ImageName = OpnFDlog1.FileName
        ''        PicItm.Image = Image.FromFile(ImageName)
        ''        Txtitmremrk.Focus()
        ''        Txtitmremrk.SelectAll()
        ''    Else
        ''        ImageName = ""
        ''        Txtitmremrk.Focus()
        ''        Txtitmremrk.SelectAll()
        ''    End If
        ''Catch ex As Exception
        ''    MsgBox(ex.Message)
        ''End Try
    End Sub
    Private Function Searchstr_Getafilename(ByVal StringToSearch1 As String) As String ' this function returns a file name from a string.
        Dim intStartingFrom1 As Long
        intStartingFrom1 = Len(StringToSearch1)
        Dim x As Integer
        For x = 0 To intStartingFrom1 - 1
            If StringToSearch1.Chars(x) = "\" Then
                F_name = ""
            Else
                F_name += StringToSearch1.Chars(x)
            End If
        Next
        Return F_name
        F_name = ""
    End Function


    Private Sub Txtratechek1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtratechek1.Leave
        Try
            Check_Minus_Dot(Txtratechek1, LblAlrt1)
            If Len(Me.Txtratechek1.Text.Trim) = 0 Then
                Me.Txtratechek1.Text = 0
            End If
            If Trim(Txtratechek1.Text) <> "" Then
                If IsNumeric(Txtratechek1.Text) = False Or Trim(Txtratechek1.Text.EndsWith("-")) = True Or Trim(Txtratechek1.Text.StartsWith("-")) = True Then
                    Txtratechek1.Focus()
                    Txtratechek1.SelectAll()
                    LblAlrt1.Visible = True
                Else
                    Txtratechek1.Text = FormatNumber(Txtratechek1.Text, 2)
                    Dim Pval As Double = FormatNumber(Txtratechek.Text, 2)
                    Dim Sval As Double = FormatNumber(Txtratechek1.Text, 2)
                    If Sval < Pval Then
                        Txtratechek1.Focus()
                        Txtratechek1.SelectAll()
                        MsgBox("Sale rate should be greater than Purchase rate")
                    End If
                    LblAlrt1.Visible = False
                End If
            Else
                LblAlrt1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtmax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtmax.Leave
        Try
            If Len(Me.Txtmax.Text.Trim) = 0 Then
                Me.Txtmax.Text = 0
            End If
            If Trim(Txtmax.Text) <> "" Then
                If IsNumeric(Txtmax.Text) = False Or Trim(Txtmax.Text.EndsWith("-")) = True Or Trim(Txtmax.Text.StartsWith("-")) = True Then
                    Txtmax.Focus()
                    Txtmax.SelectAll()
                    LblAlrt1.Visible = True
                Else
                    LblAlrt1.Visible = False
                    Dim Mval As Double = FormatNumber(Txtmax.Text, 2)
                    Dim Rval As Double = FormatNumber(txtreordr.Text, 2)

                    If Rval > Mval Then
                        MsgBox("Invalid input, Maximum Quantity should be greater than Minimum Quantity", MsgBoxStyle.Critical, "Input Greater")
                        Txtmax.Focus()
                        Txtmax.SelectAll()
                    End If
                End If
            Else
                LblAlrt1.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub setcontrols()
        Try
            Me.Text = ""
            If rBSaleOnly.Checked = True Then
                Me.Txtratechek1.Visible = False
                Me.Label11.Visible = False
                Me.Cmbxstatus.Text = "Non-Consumable"
                Me.Cmbxstatus.Enabled = False
                Me.Label4.Text = Trim("Sale Price")
                Me.Text = Me.Text & "  Current User Name :- " & " " & Current_UserName & " Is Creating Sale Item...."
            ElseIf rBPurchaseOnly.Checked = True Then
                Me.Txtratechek1.Visible = False
                Me.Label11.Visible = False
                Me.Label4.Text = Trim("Purchase Check Rate")
                Me.Cmbxstatus.Enabled = True
                Me.Text = Me.Text & "  Current User Name :- " & " " & Current_UserName & " Is Creating Purchase/Raw Material Item...."

            ElseIf rBTradingOnly.Checked = True Then
                Me.Txtratechek1.Visible = True
                Me.Label11.Visible = True
                Me.Cmbxstatus.Text = "Non-Consumable"
                Me.Cmbxstatus.Enabled = False
                Me.Label4.Text = Trim("Purchase Check Rate")
                Me.Text = Me.Text & "  Current User Name :- " & " " & Current_UserName & " Is Creating Ready To Use/Trading Item...."
            End If
            Txtcode.Focus()
            Txtcode.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcode.Leave
        Try
            If Trim(Txtcode.Text) <> "" Then
                Txtcode.BackColor = Color.White
            End If
            Me.lstvew1.Visible = False
            Me.lstvew1.Enabled = False
            Me.lstvew1.Height = 10
        Catch ex As Exception

        End Try
    End Sub


    Private Sub rBSaleOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rBSaleOnly.CheckedChanged
        setcontrols()
    End Sub

    Private Sub rBPurchaseOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rBPurchaseOnly.CheckedChanged
        setcontrols()
    End Sub

    Private Sub rBTradingOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rBTradingOnly.CheckedChanged
        setcontrols()
    End Sub

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        setcontrols()
    End Sub

    Private Sub Txtitmremrk_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtitmremrk.Leave
        Try
            Me.txtopnstok.Focus()
            Me.txtopnstok.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxloc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxloc.GotFocus
        If FrmShow_flag(1) = True Then
            Dim cond As String = "Inner"
            Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", Cmbxloc, cond, "CSCDELSTATUS", CInt(1))
            Dim Indxht As Integer = Cmbxloc.FindStringExact(IntHtCmMm(1), 0)
            Cmbxloc.SelectedIndex = Indxht
        Else
            If Cmbxloc.Items.Count > 0 And Cmbxloc.SelectedIndex = -1 Then
                Cmbxloc.SelectedIndex = 0
            End If
            If Trim(Cmbxloc.Text) <> "" Then
                fetchRecFromlocation()
            End If

        End If
        Me.Panel8.Visible = True
    End Sub

    Private Sub Btnloc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnloc.Click
        Dim frmiL As New FrmInLocat
        frmiL.ShowInTaskbar = False
        FrmShow_flag(1) = True
        frmiL.ShowDialog()
    End Sub

    Private Sub Btnloc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnloc.GotFocus
        If FrmShow_flag(1) = True Then
            Cmbxloc.Focus()
        End If

    End Sub

    Private Sub CmbxMatrl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxMatrl.Leave
        If FrmShow_flag(1) = True Then
            FrmShow_flag(1) = False
        End If
        If Trim(CmbxMatrl.Text) = "" Then
            CmbxMatrl.Text = "<None>"
        End If
    End Sub
    Private Sub Cmbxloc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxloc.Leave
        If FrmShow_flag(1) = True Then
            FrmShow_flag(1) = False

        End If
        If Trim(Cmbxloc.Text) = "" Then
            Cmbxloc.Text = "<None>"
        End If
        Me.Panel8.Visible = False
        Txtitmremrk.Focus()
        Txtitmremrk.SelectAll()
    End Sub

    Private Sub TxtItmname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItmname.Leave
        Try
            If Trim(TxtItmname.Text) <> "" Then
                TxtItmname.BackColor = Color.White
            End If
            Me.LstVew2.Visible = False
            Me.LstVew2.Enabled = False
            Me.LstVew2.Height = 10
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fetchRecFromlocation()
        Dim Cname As String = Trim(Cmbxloc.Text)
        stcom = New SqlCommand("Select * from finactcscmstr where cscctyname='" & (Cname) & "' and csctype='Inner' order by cscctyname ", FinActConn)
        Try
            st = stcom.ExecuteReader
            Dim x As Integer
            x = 0
            While st.Read()
                If st.HasRows = True Then
                    lblname.Text = st("cscctyname")
                    lblloc.Text = st("cscid")
                    lblMainp.Text = st("cscstatename")
                    lblsubp.Text = st("csccontry")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        Finally
            st.Close()
            stcom = Nothing

        End Try
    End Sub

    Private Sub Cmbxloc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxloc.SelectedIndexChanged
        If Trim(Cmbxloc.Text) <> "" Then
            fetchRecFromlocation()
        End If
    End Sub

    Private Function validate_input() As Boolean
        Dim i, j As Integer
        For i = 0 To Me.ItmDg.SelectedRows.Count - 1
            'Check item name that should not be blank/empty
            For j = i + 1 To Me.ItmDg.Rows.Count '- 1
                If Me.ItmDg.Rows(i).Cells(2).Value = "" Then
                    Me.ItmDg.Rows(i).Cells(2).ErrorText = "Empty not allowed"
                    Return True
                Else
                    Me.ItmDg.Rows(i).Cells(2).ErrorText = ""
                    'Return False
                End If

            Next
        Next
        Return False
    End Function

    Private Sub txtreordr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtreordr.TextChanged
        Try
            If Me.cmbxunit.SelectedIndex <> -1 Then
                If Trim(Me.cmbxunit.Text) = "Kg" Then
                    Check_Minus_Dot_Kgformat(txtreordr)
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtopnstok_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtopnstok.TextChanged
        Try
            If Me.cmbxunit.SelectedIndex <> -1 Then
                If Trim(Me.cmbxunit.Text) = "Kg" Then
                    Check_Minus_Dot_Kgformat(txtopnstok)
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub Txtmax_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtmax.TextChanged
        Try
            If Me.cmbxunit.SelectedIndex <> -1 Then
                If Trim(Me.cmbxunit.Text) = "Kg" Then
                    Check_Minus_Dot_Kgformat(Txtmax)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

   
    Private Function validate_ChekError() As Boolean
        Dim i, j As Integer
        For i = 0 To Me.ItmDg.SelectedRows.Count - 1
            'Check item name that should not be blank/empty
            For j = i + 1 To Me.ItmDg.Rows.Count '  - 1
                If Trim(Me.ItmDg.Rows(i).Cells(j).ErrorText) <> "" Then
                    Return True
                End If

            Next
        Next
        Return False
    End Function

    Private Sub stitsave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles stitsave.GotFocus
        Try
            If stitsave.Text = "&Edit" Then
                If FrmShow_flag(19) = True Then
                    FrmShow_flag(19) = False
                    Create_fill_ItmDg()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcode.TextChanged
        Try
            If Len(Me.Txtcode.Text.Trim) > 0 Then
                Me.lstvew1.Height = 172
                Me.lstvew1.Location = New Point(325, 180)
                xFillLstVewWith2Recrd(Me.lstvew1, Me.Txtcode.Text.Trim, "Itmid", "Itmcode", "FinactitmMstr", "Itmcode")
            Else
                Me.lstvew1.Visible = False
                Me.lstvew1.Enabled = False
                Me.lstvew1.Height = 10
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtItmname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtItmname.TextChanged
        Try
            If Len(Me.TxtItmname.Text.Trim) > 0 Then
                Me.LstVew2.Height = 172
                Me.LstVew2.Location = New Point(325, 160)
                xFillLstVewWith2Recrd(Me.LstVew2, Me.TxtItmname.Text.Trim, "Itmid", "Itmname", "FinactitmMstr", "Itmname")
            Else
                Me.LstVew2.Visible = False
                Me.LstVew2.Enabled = False
                Me.LstVew2.Height = 10
            End If
        Catch ex As Exception

        End Try
    End Sub

  
    Private Sub Txtratechek_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtratechek.TextChanged

    End Sub
End Class

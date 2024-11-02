Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmGrupMstr
    Inherits System.Windows.Forms.Form
    Dim GrupNamCmd As SqlCommand
    Dim GrupNamCmd1 As SqlCommand
    Dim GrupNamRdr As SqlDataReader
    Dim Con1 As SqlConnection
    Dim Constr As String
    Dim Indx As Integer
    Dim Editid As Integer = 0
    Dim DelStatus As Integer = 0
    Dim Delid As Integer = 0
    Dim Grpid As Integer = 0
    Dim Grupid As Integer = 0
    Dim GrpConcrnid As String = ""
    Dim AdDate, EdtDate As Date
    Dim AcGdgr As DataGridViewRow
    Dim AcGcel As DataGridViewTextBoxCell
    Dim AcGcom As DataGridViewComboBoxCell
    Dim sql As inv_sql
    Dim sql1 As inv_sql
    Dim Flagcelval, FlagCelVal1 As String
    Dim FlagEditAllow As Boolean

    Friend WithEvents CmbxGrplst1 As System.Windows.Forms.ComboBox
    Friend WithEvents Btnsave As System.Windows.Forms.Button
    Friend WithEvents Btndel As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
    Friend WithEvents Btnedit As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CmbxMpurinv As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DgaCgrup As System.Windows.Forms.DataGridView
    Friend WithEvents lstvew1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Dim FindGrupname As String = ""

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbxNg As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxAgp As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxGlsl As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbxUcal As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGrupMstr))
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbxNg = New System.Windows.Forms.ComboBox
        Me.CmbxAgp = New System.Windows.Forms.ComboBox
        Me.CmbxMpurinv = New System.Windows.Forms.ComboBox
        Me.CmbxUcal = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CmbxGlsl = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbxGrplst1 = New System.Windows.Forms.ComboBox
        Me.Btnsave = New System.Windows.Forms.Button
        Me.Btndel = New System.Windows.Forms.Button
        Me.BtnClos = New System.Windows.Forms.Button
        Me.Btnedit = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lstvew1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.DgaCgrup = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DgaCgrup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name :-"
        '
        'TxtName
        '
        Me.TxtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(165, 4)
        Me.TxtName.MaxLength = 70
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(387, 22)
        Me.TxtName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(4, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Under Group :-"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 156)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(552, 190)
        Me.Panel1.TabIndex = 3
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.19415!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.80585!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbxNg, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbxAgp, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbxMpurinv, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbxUcal, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbxGlsl, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(480, 190)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(4, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Nature of Group "
        '
        'CmbxNg
        '
        Me.CmbxNg.BackColor = System.Drawing.SystemColors.Window
        Me.CmbxNg.ForeColor = System.Drawing.Color.Navy
        Me.CmbxNg.Items.AddRange(New Object() {"Assets", "Expenses", "Income", "Liabilities", "TradingExpenses", "TradingIncome"})
        Me.CmbxNg.Location = New System.Drawing.Point(163, 4)
        Me.CmbxNg.Name = "CmbxNg"
        Me.CmbxNg.Size = New System.Drawing.Size(258, 23)
        Me.CmbxNg.Sorted = True
        Me.CmbxNg.TabIndex = 5
        '
        'CmbxAgp
        '
        Me.CmbxAgp.BackColor = System.Drawing.SystemColors.Window
        Me.CmbxAgp.ForeColor = System.Drawing.Color.Navy
        Me.CmbxAgp.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxAgp.Location = New System.Drawing.Point(163, 97)
        Me.CmbxAgp.Name = "CmbxAgp"
        Me.CmbxAgp.Size = New System.Drawing.Size(97, 23)
        Me.CmbxAgp.TabIndex = 6
        '
        'CmbxMpurinv
        '
        Me.CmbxMpurinv.BackColor = System.Drawing.SystemColors.Window
        Me.CmbxMpurinv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxMpurinv.Enabled = False
        Me.CmbxMpurinv.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxMpurinv.ForeColor = System.Drawing.Color.Navy
        Me.CmbxMpurinv.Items.AddRange(New Object() {"Not Applicable", "Appropriate by Qnty.", "Appropriate by Value", "No Appropriation"})
        Me.CmbxMpurinv.Location = New System.Drawing.Point(163, 192)
        Me.CmbxMpurinv.Name = "CmbxMpurinv"
        Me.CmbxMpurinv.Size = New System.Drawing.Size(133, 22)
        Me.CmbxMpurinv.TabIndex = 9
        Me.CmbxMpurinv.Visible = False
        '
        'CmbxUcal
        '
        Me.CmbxUcal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbxUcal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxUcal.Enabled = False
        Me.CmbxUcal.ForeColor = System.Drawing.Color.Navy
        Me.CmbxUcal.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxUcal.Location = New System.Drawing.Point(163, 191)
        Me.CmbxUcal.Name = "CmbxUcal"
        Me.CmbxUcal.Size = New System.Drawing.Size(97, 23)
        Me.CmbxUcal.TabIndex = 8
        Me.CmbxUcal.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Enabled = False
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(4, 189)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(152, 1)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Method to allocate when used in Purchase invoices "
        Me.Label8.Visible = False
        '
        'CmbxGlsl
        '
        Me.CmbxGlsl.BackColor = System.Drawing.SystemColors.Window
        Me.CmbxGlsl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxGlsl.Enabled = False
        Me.CmbxGlsl.ForeColor = System.Drawing.Color.Navy
        Me.CmbxGlsl.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxGlsl.Location = New System.Drawing.Point(163, 190)
        Me.CmbxGlsl.Name = "CmbxGlsl"
        Me.CmbxGlsl.Size = New System.Drawing.Size(97, 23)
        Me.CmbxGlsl.TabIndex = 7
        Me.CmbxGlsl.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Enabled = False
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(4, 188)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 1)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Used for Calculations. (eg. Taxes, Discounts) For Sales Invoices entry "
        Me.Label7.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(4, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 18)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Affect on Gross Profit "
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(4, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 1)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Like a Sub Ledger "
        Me.Label6.Visible = False
        '
        'CmbxGrplst1
        '
        Me.CmbxGrplst1.BackColor = System.Drawing.SystemColors.Window
        Me.CmbxGrplst1.ForeColor = System.Drawing.Color.Navy
        Me.CmbxGrplst1.Location = New System.Drawing.Point(165, 57)
        Me.CmbxGrplst1.Name = "CmbxGrplst1"
        Me.CmbxGrplst1.Size = New System.Drawing.Size(346, 22)
        Me.CmbxGrplst1.TabIndex = 2
        '
        'Btnsave
        '
        Me.Btnsave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btnsave.BackColor = System.Drawing.Color.Transparent
        Me.Btnsave.BackgroundImage = CType(resources.GetObject("Btnsave.BackgroundImage"), System.Drawing.Image)
        Me.Btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnsave.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Btnsave.FlatAppearance.BorderSize = 0
        Me.Btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnsave.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnsave.ForeColor = System.Drawing.Color.Navy
        Me.Btnsave.Location = New System.Drawing.Point(6, 195)
        Me.Btnsave.Name = "Btnsave"
        Me.Btnsave.Size = New System.Drawing.Size(151, 33)
        Me.Btnsave.TabIndex = 10
        Me.Btnsave.Text = "&Save"
        Me.Btnsave.UseVisualStyleBackColor = False
        '
        'Btndel
        '
        Me.Btndel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btndel.BackColor = System.Drawing.Color.Transparent
        Me.Btndel.BackgroundImage = CType(resources.GetObject("Btndel.BackgroundImage"), System.Drawing.Image)
        Me.Btndel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btndel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btndel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Btndel.FlatAppearance.BorderSize = 0
        Me.Btndel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btndel.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btndel.ForeColor = System.Drawing.Color.Navy
        Me.Btndel.Location = New System.Drawing.Point(6, 273)
        Me.Btndel.Name = "Btndel"
        Me.Btndel.Size = New System.Drawing.Size(151, 33)
        Me.Btndel.TabIndex = 12
        Me.Btndel.Text = "&Cancle"
        Me.Btndel.UseVisualStyleBackColor = False
        '
        'BtnClos
        '
        Me.BtnClos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClos.BackColor = System.Drawing.Color.Transparent
        Me.BtnClos.BackgroundImage = CType(resources.GetObject("BtnClos.BackgroundImage"), System.Drawing.Image)
        Me.BtnClos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClos.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClos.FlatAppearance.BorderSize = 0
        Me.BtnClos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BtnClos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClos.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClos.ForeColor = System.Drawing.Color.Navy
        Me.BtnClos.Location = New System.Drawing.Point(6, 312)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(151, 33)
        Me.BtnClos.TabIndex = 13
        Me.BtnClos.Text = "&Close"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'Btnedit
        '
        Me.Btnedit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btnedit.BackColor = System.Drawing.Color.Transparent
        Me.Btnedit.BackgroundImage = CType(resources.GetObject("Btnedit.BackgroundImage"), System.Drawing.Image)
        Me.Btnedit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnedit.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Btnedit.FlatAppearance.BorderSize = 0
        Me.Btnedit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnedit.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnedit.ForeColor = System.Drawing.Color.Navy
        Me.Btnedit.Location = New System.Drawing.Point(5, 234)
        Me.Btnedit.Name = "Btnedit"
        Me.Btnedit.Size = New System.Drawing.Size(151, 33)
        Me.Btnedit.TabIndex = 11
        Me.Btnedit.Text = "&Find"
        Me.Btnedit.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 1)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.GhostWhite
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstvew1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel2.BackgroundImage = Global.FinAcct.My.Resources.Resources._7717hi
        Me.SplitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgaCgrup)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Btnsave)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnClos)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Btndel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Btnedit)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Size = New System.Drawing.Size(731, 353)
        Me.SplitContainer1.SplitterDistance = 564
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 16
        '
        'lstvew1
        '
        Me.lstvew1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstvew1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstvew1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstvew1.FullRowSelect = True
        Me.lstvew1.GridLines = True
        Me.lstvew1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstvew1.Location = New System.Drawing.Point(169, 34)
        Me.lstvew1.Name = "lstvew1"
        Me.lstvew1.Size = New System.Drawing.Size(386, 10)
        Me.lstvew1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstvew1.TabIndex = 43
        Me.lstvew1.TabStop = False
        Me.lstvew1.UseCompatibleStateImageBehavior = False
        Me.lstvew1.View = System.Windows.Forms.View.Details
        Me.lstvew1.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 350
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Id"
        Me.ColumnHeader2.Width = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.00901!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.99099!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbxGrplst1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.9975!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0025!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(556, 108)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'DgaCgrup
        '
        Me.DgaCgrup.AllowUserToDeleteRows = False
        Me.DgaCgrup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgaCgrup.Location = New System.Drawing.Point(33, 9)
        Me.DgaCgrup.Name = "DgaCgrup"
        Me.DgaCgrup.Size = New System.Drawing.Size(92, 38)
        Me.DgaCgrup.TabIndex = 16
        Me.DgaCgrup.Visible = False
        '
        'FrmGrupMstr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(735, 357)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmGrupMstr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Group Master"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DgaCgrup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub FrmGrupMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            fill_gruplist()
            sql = New inv_sql
            sql1 = New inv_sql
            CheckAcess_Btn_frm(Btnsave, Btnedit, Btndel)
            CmbxNg.SelectedIndex = 0
            CmbxAgp.SelectedIndex = 1
            CmbxGlsl.SelectedIndex = 1
            CmbxUcal.SelectedIndex = 1
            CmbxMpurinv.SelectedIndex = 0
            Me.TxtName.Focus()
        Catch ex As Exception

        End Try
    End Sub
    '############20march
    Private Sub CheckAcess_Btn_frm(ByVal BtnnSave As Button, ByVal BtnnEdt As Button, _
    ByVal BtnnDel As Button)
        Select Case Trim(AcessRight)
            Case "OwnrFull"
                BtnnSave.Enabled = True
                BtnnEdt.Enabled = True
                BtnnDel.Enabled = True
            Case "DataEntryMstr"
                BtnnSave.Enabled = True
                BtnnSave.Location = New System.Drawing.Point(183, 372)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
        End Select
    End Sub
    Private Sub SaveGrupName()
        Dim YesNo1, YesNo2, YesNo3 As Integer
        Try
            GrupNamCmd = New SqlCommand("select cogrpid,copconcrnprmid from finactgrupname where coprmtype='" & ("Actt") & "' and cogrupnam=@Gname", FinActConn)
            GrupNamCmd.Parameters.AddWithValue("@gname", CmbxGrplst1.Text)
            GrupNamCmd.CommandType = CommandType.Text
            GrupNamRdr = GrupNamCmd.ExecuteReader
            GrupNamRdr.Read()
            Grupid = GrupNamRdr("cogrpid")
            'GrpConcrnid = GrupNamRdr("copConcrnprmid")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            GrupNamCmd = Nothing
            GrupNamRdr.Close()
        End Try
        Try
            GrupNamCmd = New SqlCommand("Finact_GrupName_Insert", FinActConn)
            GrupNamCmd.CommandType = CommandType.StoredProcedure
            GrupNamCmd.Parameters.AddWithValue("@Cogrupnam", Trim(TxtName.Text))
            GrupNamCmd.Parameters.AddWithValue("@CoUndrgrup", Grupid)
            GrupNamCmd.Parameters.AddWithValue("@coptype", "Actt")
            GrupNamCmd.Parameters.AddWithValue("@copconid", Grupid)
            GrupNamCmd.Parameters.AddWithValue("@cobalhed", CmbxNg.Text)
            If Trim(CmbxAgp.Text) = "Yes" Then
                YesNo1 = 1
            ElseIf Trim(CmbxAgp.Text) = "No" Then
                YesNo1 = 0
            End If
            GrupNamCmd.Parameters.AddWithValue("@CoAfect", YesNo1)
            If Trim(CmbxGlsl.Text) = "Yes" Then
                YesNo2 = 1
            ElseIf Trim(CmbxGlsl.Text) = "No" Then
                YesNo2 = 0
            End If
            GrupNamCmd.Parameters.AddWithValue("@coliksub", YesNo2)
            If Trim(CmbxUcal.Text) = "Yes" Then
                YesNo3 = 1
            ElseIf Trim(CmbxUcal.Text) = "No" Then
                YesNo3 = 0
            End If
            GrupNamCmd.Parameters.AddWithValue("@coforcal", YesNo3)

            GrupNamCmd.Parameters.AddWithValue("@comethd", CmbxMpurinv.Text)
            GrupNamCmd.Parameters.AddWithValue("@coaddt", Now)
            GrupNamCmd.Parameters.AddWithValue("@coadusrid", Current_UsrId)
            GrupNamCmd.Parameters.AddWithValue("@coDelStatus", DelStatus) ' if record not deleted 0 for Deleted recor
            IntHtCmMm(0) = Trim(TxtName.Text).ToString
            GrupNamCmd.ExecuteNonQuery()
            MsgBox("Current record has been successfully save", MsgBoxStyle.Information, "Group Name")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Chk_Blnk()
        With TxtName
            If .Text = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxNg
            If .SelectedIndex = -1 Then
                .Focus()
                Indx += 1
            End If
        End With

        With CmbxGrplst1
            If .SelectedIndex = -1 Then
                .Focus()
                Indx += 1
            End If
        End With
        With CmbxAgp
            If .SelectedIndex = -1 Then
                .Focus()
                Indx += 1
            End If
        End With
        With CmbxGlsl
            If .SelectedIndex = -1 Then
                .Focus()
                Indx += 1
            End If
        End With

        With CmbxUcal
            If .SelectedIndex = -1 Then
                .Focus()
                Indx += 1
            End If
        End With
        With CmbxMpurinv
            If .SelectedIndex = -1 Then
                .Focus()
                Indx += 1
            End If
        End With
    End Sub

    Private Sub CmbxMpurinv_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxMpurinv.Leave
        If Btnsave.Enabled = True Then
            Btnsave.Focus()
        End If
    End Sub

    Private Sub GrupnamEdt()
        Dim YesNo1, YesNo2, YesNo3, Grupid As Integer
        Dim Xa As Integer
        Dim dgcont As Integer = DgaCgrup.Rows.Count - 1
        Dim dgcont1 As Integer = DgaCgrup.CurrentRow.Index
        If dgcont = dgcont1 Then
            MsgBox("Invalid Input! System could not found any record to update", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If
        Xa = DgaCgrup.SelectedRows.Count
        Try
            Dim Xi As Integer = 0
            If Xa > 0 Then
                For Xi = 0 To DgaCgrup.SelectedRows.Count - 1
                    If FlagEditAllow = True Then
                        If validate_input() Then
                            MsgBox("Invalid input, system found a record with same value, try another value", MsgBoxStyle.Critical)
                            Me.DgaCgrup.SelectedRows(Xi).Cells(1).Value = Trim(FlagCelVal1.ToUpper)
                            Xa = 0
                            FlagEditAllow = False
                            Exit Sub
                        End If
                    End If


                    GrupNamCmd = New SqlCommand("Finact_GrupName_Update", FinActConn)
                    GrupNamCmd.CommandType = CommandType.StoredProcedure
                    'for fetching grupid 
                    Try
                        GrupNamCmd1 = New SqlCommand("select cogrpid,copconcrnprmid from finactgrupname" _
                        & " where coprmtype='" & ("Actt") & "' and cogrupnam=@Gname", FinActConn1)
                        GrupNamCmd1.Parameters.AddWithValue("@gname", Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(2).Value))

                        GrupNamCmd1.CommandType = CommandType.Text
                        GrupNamRdr = GrupNamCmd1.ExecuteReader
                        GrupNamRdr.Read()
                        Grupid = GrupNamRdr("cogrpid")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        GrupNamCmd1 = Nothing
                        GrupNamRdr.Close()
                    End Try
                    GrupNamCmd.Parameters.AddWithValue("@Cogrupnam", Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(1).Value))
                    GrupNamCmd.Parameters.AddWithValue("@CoUndrgrup", Grupid)
                    GrupNamCmd.Parameters.AddWithValue("@coptype", "Actt")
                    GrupNamCmd.Parameters.AddWithValue("@copconid", Grupid)
                    GrupNamCmd.Parameters.AddWithValue("@cobalhed", Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(3).Value))
                    If Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(4).Value) = "True" Then
                        YesNo1 = 1
                    ElseIf Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(4).Value) = "False" Then
                        YesNo1 = 0
                    End If
                    GrupNamCmd.Parameters.AddWithValue("@CoAfect", YesNo1)
                    If Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(5).Value) = "True" Then
                        YesNo2 = 1
                    ElseIf Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(5).Value) = "False" Then
                        YesNo2 = 0
                    End If
                    GrupNamCmd.Parameters.AddWithValue("@coliksub", YesNo2)
                    If Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(6).Value) = "True" Then
                        YesNo3 = 1
                    ElseIf Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(6).Value) = "False" Then
                        YesNo3 = 0
                    End If
                    GrupNamCmd.Parameters.AddWithValue("@coforcal", YesNo3)

                    GrupNamCmd.Parameters.AddWithValue("@comethd", Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(7).Value))
                    GrupNamCmd.Parameters.AddWithValue("@coDelStatus", DelStatus) ' if record not deleted 0 for Deleted record
                    GrupNamCmd.Parameters.AddWithValue("@Cogrpid", Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(0).Value))
                    GrupNamCmd.Parameters.AddWithValue("@coEdtusrid", Editid)
                    GrupNamCmd.Parameters.AddWithValue("@coedtdt", Now)
                    IntHtCmMm(0) = Trim(Me.DgaCgrup.SelectedRows(Xi).Cells(1).Value)
                    GrupNamCmd.ExecuteNonQuery()
                Next
                MsgBox("Record has been successfully updated", MsgBoxStyle.Information, "Record Updated")
                Create_fill_AcGDgaCgrup()
            Else
                MsgBox("No record selected for updation.", MsgBoxStyle.Critical, Me.Text)
                Exit Sub

            End If
        Catch ex As SqlException
            Dim a As Integer = ex.Number
            If ex.Number = 2627 Then
                MsgBox("Invalid input! system found a record exisited with same value, Try another value", MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            End If
        Finally
            If Xa > 0 Then
                GrupNamCmd.Dispose()
            End If
        End Try

    End Sub


    Private Sub TxtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.GotFocus
        TxtName.SelectAll()
    End Sub



    Private Sub CmbxGrplst1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxGrplst1.GotFocus
        Try
            Me.CmbxGrplst1.DroppedDown = True
            If CmbxGrplst1.Items.Count > 0 Then
                If CmbxGrplst1.SelectedIndex = -1 Then
                    CmbxGrplst1.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CmbxGrplst1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxGrplst1.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxGrplst1) = True Then
                Panel1.Enabled = True
                CmbxNg.Focus()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btnsave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsave.Click
        DelStatus = 1

        If Btnsave.Text = "&Save" Then
            Chk_Blnk()
            If Indx <> 0 Then
                Indx = 0
                Exit Sub
            Else
                Dim Txtstr As String = Trim(TxtName.Text)
                Chk_Exisit("finactgrupname", "cogrupnam", Txtstr)
                If xStr1.ToUpper.Equals(Txtstr.ToUpper) = True Then
                    MsgBox("Invalid input, system found a record with same value, try another value", MsgBoxStyle.Critical)
                    TxtName.Focus()
                    TxtName.SelectAll()
                    Exit Sub
                End If
                SaveGrupName()
                TxtName.Text = ""
                TxtName.Focus()
            End If
        ElseIf Btnsave.Text = "&Update" Then

            Delid = 0
            Editid = Current_UsrId
            GrupnamEdt()

        End If
    End Sub

    Private Sub Btnedit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnedit.Click

        Try
            If Btnedit.Text = "&Find" Then
                Panel1.Visible = False
                Me.TableLayoutPanel1.Visible = False
                Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 50
                Me.Left = 0
                Me.Top = 0
                Me.Height = Screen.PrimaryScreen.WorkingArea.Height / 1.25
                Me.SplitContainer1.SplitterDistance = Me.Width - 150
                Me.SplitContainer1.IsSplitterFixed = True
                Create_fill_AcGDgaCgrup()
                Btnsave.Text = "&Update"
                Btnedit.Text = "&Delete"
            Else


                If MessageBox.Show("Are you sure to delete?", "Item configuration", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                Try
                    If DgaCgrup.SelectedRows.Count > 0 Then


                        Dim i As Integer = 0
                        Dim flg As Integer = 0
                        For i = 0 To DgaCgrup.SelectedRows.Count - 1
                            Try
                                If FinActConn.State Then FinActConn.Close()
                                FinActConn.Open()
                                GrupNamCmd = New SqlCommand("Select codelflag from finactgrupname where cogrpid=@itmid", FinActConn)
                                GrupNamCmd.Parameters.AddWithValue("@itmid", Me.DgaCgrup.SelectedRows(i).Cells(0).Value)
                                GrupNamCmd.ExecuteNonQuery()
                                GrupNamRdr = GrupNamCmd.ExecuteReader
                                While GrupNamRdr.Read
                                    flg = GrupNamRdr(0)
                                End While
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                GrupNamCmd.Dispose()
                                GrupNamRdr.Close()
                            End Try
                            If flg = 0 Then
                                MsgBox("System could not delete current record.", MsgBoxStyle.Critical, "System Reserved Group!!!")
                                Exit Sub
                            Else
                                If Chk_Exisit2("finactsplrmstr", "Splrundrgrup", "Splrundrgrup", Me.DgaCgrup.SelectedRows(i).Cells(0).Value) = True Then
                                    MsgBox("System could not delete current record, as it has a relation with other record(s).", MsgBoxStyle.Critical, "Record has relation(s)!!!")
                                    Exit Sub
                                End If

                                If FinActConn.State Then FinActConn.Close()
                                FinActConn.Open()
                                GrupNamCmd = New SqlCommand("Delete from finactgrupname where cogrpid=@itmid", FinActConn)
                                GrupNamCmd.Parameters.AddWithValue("@itmid", Me.DgaCgrup.SelectedRows(i).Cells(0).Value)
                                GrupNamCmd.ExecuteNonQuery()
                            End If
                        Next
                        MsgBox("Current record has been successfully  deleted ", MsgBoxStyle.Information)
                        Create_fill_AcGDgaCgrup()
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
                    If DgaCgrup.SelectedRows.Count > 0 Then
                        GrupNamCmd.Dispose()
                    End If
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally


        End Try
    End Sub

    Private Sub Btndel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndel.Click
        If Btnedit.Text = "&Delete" Then
            DgaCgrup.Visible = False
            Me.TableLayoutPanel1.Visible = True
            Panel1.Visible = True
            Me.Width = 741
            Me.Height = 389
            Me.SplitContainer1.SplitterDistance = 564
            Me.SplitContainer1.IsSplitterFixed = False

            Btnsave.Text = "&Save"
            Btnedit.Text = "&Find"
        End If
    End Sub

    Private Sub BtnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClos.Click
        Me.Close()
    End Sub
    Private Sub fill_gruplist()
        GrupNamCmd = New SqlCommand("select * from finactgrupname where coprmtype='" & ("Actt") & "'and codelstatus=1 order by cogrupnam", FinActConn)
        Try
            GrupNamRdr = GrupNamCmd.ExecuteReader
            CmbxGrplst1.Items.Clear()
            While GrupNamRdr.Read
                CmbxGrplst1.Items.Add(GrupNamRdr("cogrupnam"))
            End While
            GrupNamRdr.Close()
            GrupNamCmd = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CmbxNg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxNg.GotFocus
        Try
            Me.CmbxNg.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxAgp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxAgp.GotFocus
        Try
            Me.CmbxAgp.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnClos.KeyDown, Btndel.KeyDown, Btnedit.KeyDown, Btnsave.KeyDown, CmbxAgp.KeyDown, CmbxGlsl.KeyDown, CmbxGrplst1.KeyDown, CmbxNg.KeyDown, CmbxUcal.KeyDown, Label1.KeyDown, Label2.KeyDown, Label4.KeyDown, Label5.KeyDown, Label6.KeyDown, Label7.KeyDown, Panel1.KeyDown, TxtName.KeyDown, Label8.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()

        End If
    End Sub
    Private Sub CmbxApg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxAgp.KeyDown
        Try
            Me.CmbxAgp_Leave(sender, e)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub allControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxGlsl.KeyDown, CmbxMpurinv.KeyDown, CmbxUcal.KeyDown, TxtName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxGrplst1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxGrplst1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxGrplst1_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxNg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxNg.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxNg_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Btnsave_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.MouseHover, BtnClos.MouseHover, Btndel.MouseHover, Btnedit.MouseHover
        Dim tb As Button = CType(sender, Button)
        tb.ForeColor = Color.Blue


    End Sub

    Private Sub BtnClos_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.MouseLeave, BtnClos.MouseLeave, Btndel.MouseLeave, Btnedit.MouseLeave
        Dim tb As Button = CType(sender, Button)
        tb.ForeColor = Color.Black
    End Sub

    Private Sub Create_fill_AcGDgaCgrup()
        Try
            DgaCgrup.Columns.Clear()
            DgaCgrup.Rows.Clear()
            DgaCgrup.Size = New Drawing.Size(Me.Width - 150, Me.Height - (0 + 50))
            DgaCgrup.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DgaCgrup.ForeColor = Color.Navy
            DgaCgrup.Columns.Add("iid", "Id")
            DgaCgrup.Columns.Add("gn", "Name Of The Group")
            DgaCgrup.Columns(1).DefaultCellStyle.BackColor = Color.LightSteelBlue
            DgaCgrup.Columns.Add("ug", "Under Group")
            DgaCgrup.Columns.Add("nog", "Nature Of Group")
            DgaCgrup.Columns.Add("agp", "Affect on GP")
            DgaCgrup.Columns.Add("lsl", "Like a Sub")
            DgaCgrup.Columns.Add("ufc", "Used For Cal.")
            DgaCgrup.Columns.Add("moa", "Method to Allocation")
            DgaCgrup.Columns.Add("Adusr", "Add User")
            DgaCgrup.Columns.Add("addt", "Add Date")
            DgaCgrup.Columns.Add("edtusr", "Edit User")
            DgaCgrup.Columns.Add("edtdt", "Edit Date")
            DgaCgrup.Columns(8).DefaultCellStyle.BackColor = Color.LightGray
            DgaCgrup.Columns(9).DefaultCellStyle.BackColor = Color.LightGray
            DgaCgrup.Columns(10).DefaultCellStyle.BackColor = Color.LightGray
            DgaCgrup.Columns(11).DefaultCellStyle.BackColor = Color.LightGray
            DgaCgrup.Columns(1).Width = 200
            DgaCgrup.Columns(2).Width = 150
            DgaCgrup.Columns(3).Width = 150
            DgaCgrup.Columns(4).Width = 80
            DgaCgrup.Columns(5).Width = 80
            DgaCgrup.Columns(6).Width = 80
            DgaCgrup.Columns(7).Width = 200
            DgaCgrup.Columns(9).Width = 230
            DgaCgrup.Columns(11).Width = 230
            DgaCgrup.ColumnHeadersHeight = 60
            DgaCgrup.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            DgaCgrup.BorderStyle = BorderStyle.FixedSingle
            DgaCgrup.BackgroundColor = Color.Snow
            Me.SplitContainer1.Panel1.Controls.Add(DgaCgrup)
            DgaCgrup.Visible = True
            DgaCgrup.Left = 0
            DgaCgrup.Top = 2
            DgaCgrup.Columns(0).Visible = False
            DgaCgrup.Columns(5).Visible = False
            DgaCgrup.Columns(6).Visible = False
            DgaCgrup.Columns(7).Visible = False
            DgaCgrup.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red
            Dim pn1(0), pv1(0) As String
            Dim pn11(2), pv11(2) As String ''Arrays for procedure argu name n value
            pn11(0) = "@ta"
            pn11(1) = "@id"
            pn11(2) = "@idval"

            pv11(0) = "finactgrupname"
            pv11(1) = "cogrupnam"
            pv11(2) = "PRIMARY"
            sql.get_data("select_where_Not_like", pn11, pv11, "AcgMaster")


            Dim mk, r As Integer
            For mk = 0 To sql.ds.Tables("AcgMaster").Rows.Count - 1
                AcGdgr = New DataGridViewRow()
                'for fetching id
                AcGcel = New DataGridViewTextBoxCell()
                AcGcel.Value = sql.ds.Tables("AcgMaster").Rows(mk).ItemArray(0).ToString()
                AcGdgr.Cells.Add(AcGcel)


                ' for fetching name
                AcGcel = New DataGridViewTextBoxCell
                AcGcel.Value = sql.ds.Tables("AcgMaster").Rows(mk).ItemArray(1).ToString()
                Dim xStr As String = Trim(sql.ds.Tables("AcgMaster").Rows(mk).ItemArray(1).ToString())
                AcGdgr.Cells.Add(AcGcel)
                ' AcGdgr.Cells(1).ReadOnly = True


                'for fetching groupname
                AcGcom = New DataGridViewComboBoxCell()

                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finactgrupname"
                pv11(1) = "cogrpid"
                pv11(2) = sql.ds.Tables("acgMaster").Rows(mk).ItemArray(2).ToString()

                sql1.get_data("select_where", pn11, pv11, "acg") ' acg stands for Account group Master
                AcGcom.Items.Add(sql1.ds.Tables("acg").Rows(0).ItemArray(1).ToString())

                pn1(0) = "@ta"
                pv1(0) = "finactgrupname"
                sql1.get_data("select_all", pn1, pv1, "acga")

                For r = 0 To sql1.ds.Tables("acga").Rows.Count - 1
                    If sql1.ds.Tables("acga").Rows(r).ItemArray(1).ToString() <> AcGcom.Items(0) Then
                        If Trim(xStr) <> Trim(sql1.ds.Tables("acga").Rows(r).ItemArray(1).ToString()) Then
                            AcGcom.Items.Add(Trim((sql1.ds.Tables("acga").Rows(r).ItemArray(1).ToString())))
                        End If
                    End If
                Next
                sql1.ds.Tables("acga").Dispose()
                AcGcom.Value = Trim(AcGcom.Items(0))

                AcGcom.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

                AcGdgr.Cells.Add(AcGcom)


                'for fetching nature of group
                AcGcom = New DataGridViewComboBoxCell()
                AcGcom.Items.Add("Assets")
                AcGcom.Items.Add("Expenses")
                AcGcom.Items.Add("TradingExpenses")
                AcGcom.Items.Add("Income")
                AcGcom.Items.Add("Liabilities")
                AcGcom.Items.Add("TradingIncome")
                AcGcom.Value = sql.ds.Tables("acgMaster").Rows(mk).ItemArray(5).ToString()
                AcGcom.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                AcGdgr.Cells.Add(AcGcom)

                'for fetching affect on GP
                AcGcom = New DataGridViewComboBoxCell
                AcGcom.Items.Add("True")
                AcGcom.Items.Add("False")
                AcGcom.Value = sql.ds.Tables("acgMaster").Rows(mk).ItemArray(6).ToString()
                AcGcom.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                AcGdgr.Cells.Add(AcGcom)

                'for fetching like a sub ledger
                AcGcom = New DataGridViewComboBoxCell
                AcGcom.Items.Add("True")
                AcGcom.Items.Add("False")
                AcGcom.Value = sql.ds.Tables("acgMaster").Rows(mk).ItemArray(7).ToString()
                AcGcom.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                AcGdgr.Cells.Add(AcGcom)

                'for fetching used for calcution
                AcGcom = New DataGridViewComboBoxCell
                AcGcom.Items.Add("True")
                AcGcom.Items.Add("False")
                AcGcom.Value = sql.ds.Tables("acgMaster").Rows(mk).ItemArray(8).ToString()
                AcGcom.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                AcGdgr.Cells.Add(AcGcom)

                'For fetching method of allocatin
                AcGcom = New DataGridViewComboBoxCell
                AcGcom.Items.Add("Not Applicable")
                AcGcom.Items.Add("Appropriate by Qnty.")
                AcGcom.Items.Add("Not Applicable")
                AcGcom.Items.Add("Appropriate by Value")
                AcGcom.Items.Add("No Appropriation")
                AcGcom.Value = sql.ds.Tables("acgMaster").Rows(mk).ItemArray(9).ToString()
                AcGcom.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

                AcGdgr.Cells.Add(AcGcom)

                'for fetching add date
                AcGcel = New DataGridViewTextBoxCell
                AcGcel.Value = sql.ds.Tables("acgmaster").Rows(mk).ItemArray(11).ToString()
                AcGdgr.Cells.Add(AcGcel)
                AcGdgr.Cells(8).ReadOnly = True

                'for fetching add user
                AcGcel = New DataGridViewTextBoxCell
                AcGcel.Value = sql.ds.Tables("acgmaster").Rows(mk).ItemArray(10).ToString()
                AcGdgr.Cells.Add(AcGcel)
                AcGdgr.Cells(9).ReadOnly = True


                'for fetching edit user
                AcGcel = New DataGridViewTextBoxCell
                AcGcel.Value = sql.ds.Tables("acgmaster").Rows(mk).ItemArray(15).ToString()
                AcGdgr.Cells.Add(AcGcel)
                AcGdgr.Cells(10).ReadOnly = True

                'for fetching edit date
                AcGcel = New DataGridViewTextBoxCell
                AcGcel.Value = sql.ds.Tables("acgmaster").Rows(mk).ItemArray(16).ToString()
                AcGdgr.Cells.Add(AcGcel)
                AcGdgr.Cells(11).ReadOnly = True
                DgaCgrup.Rows.Add(AcGdgr)

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sql.cnn.Close()
            sql.ds.Dispose()
        End Try
    End Sub

    Private Function validate_input() As Boolean
        Dim i, j As Integer
        For i = 0 To Me.DgaCgrup.Rows.Count - 1
            For j = i + 1 To Me.DgaCgrup.Rows.Count - 1
                If Me.DgaCgrup.Rows(i).Cells(1).Value = Me.DgaCgrup.Rows(j).Cells(1).Value Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function

    Private Sub DgaCgrup_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgaCgrup.CellClick
        If DgaCgrup.CurrentCell.ColumnIndex = 1 Then
            FlagCelVal1 = Trim(Me.DgaCgrup.CurrentCell.Value).ToUpper
        End If
    End Sub

    Private Sub DgaCgrup_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgaCgrup.CellEnter
        Try
            Dim xRecid As Integer = Me.DgaCgrup.CurrentRow.Cells(0).Value
            If CInt(xDynamic_Find_xAnItem_xInA_Table_1cond_TrueFalse("codelflag", "cogrpid", xRecid, "FinactGrupname")) = 0 Then
                Me.DgaCgrup.CurrentRow.ReadOnly = True
            Else
                Me.DgaCgrup.CurrentRow.ReadOnly = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DgaCgrup_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgaCgrup.CellValueChanged
        If DgaCgrup.CurrentCell.ColumnIndex = 1 Then
            FlagEditAllow = True
            Flagcelval = Trim(DgaCgrup.CurrentCell.Value).ToUpper
            DgaCgrup.CurrentCell.Value = Trim(Flagcelval.ToUpper)

        End If
    End Sub


    Private Sub CmbxNg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxNg.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxNg) = True Then
                Me.CmbxAgp.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxAgp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxAgp.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxAgp) = True Then
                Me.Btnsave.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.Leave
        Try
            Me.lstvew1.Height = 10
            Me.lstvew1.Visible = False
            Me.lstvew1.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtName.TextChanged
        Try
            If Len(Me.TxtName.Text.Trim) > 0 Then
                Me.lstvew1.Height = 213
                xFillLstVewWith2Recrd(Me.lstvew1, Me.TxtName.Text.Trim, "Cogrpid", "CogrupNam", "Finactgrupname", "Cogrupnam")
            Else
                Me.lstvew1.Visible = False
                Me.lstvew1.Enabled = False
                Me.lstvew1.Height = 10
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class

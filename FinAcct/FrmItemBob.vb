
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO


Public Class FrmItemBoM
    Inherits System.Windows.Forms.Form
    Dim insertcom As SqlCommand
    Dim insertdr As SqlDataReader
    Dim grupnamcom As SqlCommand
    Dim grpidcom As SqlCommand
    Dim itmnamcom As SqlCommand
    Dim cmbitmcom As SqlCommand
    Dim updtcom As SqlCommand
    Dim stcom As SqlCommand
    Dim delstcom As SqlCommand
    Dim MM_cmd As SqlCommand
    Dim MM_rdr As SqlDataReader
    Dim MM_Adptr As SqlDataAdapter
    Dim MM_Dset As DataSet
    Dim sql As inv_sql
    Dim sql1 As inv_sql
    Dim Itmdgr As DataGridViewRow
    Dim Itmcel As DataGridViewTextBoxCell
    Dim Itmcom As DataGridViewComboBoxCell
    Dim ItmBtn As DataGridViewButtonCell
    Dim ItmImage As DataGridViewImageCell
    Dim grupnamdr As SqlDataReader
    Dim grpiddr As SqlDataReader
    Dim itmnamdr As SqlDataReader
    Dim cmbitmdr As SqlDataReader
    Dim st As SqlDataReader
    Dim C12, C13 As Double
    Dim Fso As Object
    Dim ImageName As String = ""
    Dim ImagePath As String = "None"
    Dim MySource As String
    Dim F_name As String = ""
    Dim SelStrg As String = ""
    Dim SelIndex As Boolean = False
    Dim ItemId As Integer = 0
    Dim Li As Integer = Nothing
    Dim yn As Integer
    Dim grupid As Integer
    Dim sid As Integer
    Dim excinfo As Integer
    Dim DelStatus As Integer = 1
    Dim grupnam As String
    Dim LstViewEdit_Flag, Inr_Flag, Otr_Flag As Boolean
    Dim CurrentItmid As Integer = 0
    Dim xrVal, xratio As Double

    'Private ItmDetail As New ArrayList()


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
    Friend WithEvents rBPurchaseOnly As System.Windows.Forms.RadioButton
    Friend WithEvents rBSaleOnly As System.Windows.Forms.RadioButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Txtmax As System.Windows.Forms.TextBox
    Friend WithEvents btnimage As System.Windows.Forms.Button
    Friend WithEvents PicItm As System.Windows.Forms.PictureBox
    Friend WithEvents OpnFDlog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents TxtItmname As System.Windows.Forms.TextBox
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
    Friend WithEvents BomLstVew As System.Windows.Forms.ListView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Txtitmremrk As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbBom As System.Windows.Forms.RadioButton
    Friend WithEvents Rbraw As System.Windows.Forms.RadioButton
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents lblig As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents lblin As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lblic As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblsr As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblpr As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents lblut As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents lblmq As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents lblrol As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Rbboth As System.Windows.Forms.RadioButton
    Friend WithEvents txtqnty As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lblAval As System.Windows.Forms.Label
    Friend WithEvents lblnoitms As System.Windows.Forms.Label
    Friend WithEvents itmcode As System.Windows.Forms.ColumnHeader
    Friend WithEvents itmname As System.Windows.Forms.ColumnHeader
    Friend WithEvents itmqnty As System.Windows.Forms.ColumnHeader
    Friend WithEvents itmrate As System.Windows.Forms.ColumnHeader
    Friend WithEvents itmamt As System.Windows.Forms.ColumnHeader
    Friend WithEvents itmid As System.Windows.Forms.ColumnHeader
    Friend WithEvents itmnature As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstvewContextms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btnaditm As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Lstvewitmsel As System.Windows.Forms.ListView
    Friend WithEvents Colitm1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColItemid As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colqnty As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSelItm1 As System.Windows.Forms.Button
    Friend WithEvents BtnItmUnsel As System.Windows.Forms.Button
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Btnmove1 As System.Windows.Forms.Button
    Friend WithEvents BtnMove2 As System.Windows.Forms.Button
    Friend WithEvents Btnmove3 As System.Windows.Forms.Button
    Friend WithEvents Btnmove4 As System.Windows.Forms.Button
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents colsih As System.Windows.Forms.ColumnHeader
    Friend WithEvents rbSpBoth As System.Windows.Forms.RadioButton
    Friend WithEvents colchek As System.Windows.Forms.ColumnHeader
    Friend WithEvents Lstbxprocs As System.Windows.Forms.ListView
    Friend WithEvents Colid1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colpname As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstbxprocs1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColpGrupid As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CmbxSelItm As System.Windows.Forms.ComboBox
    Friend WithEvents Colratio As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnQntOk As System.Windows.Forms.Button
    Friend WithEvents ColPackChek As System.Windows.Forms.ColumnHeader
    Friend WithEvents Txtitmconversn As System.Windows.Forms.TextBox
    Friend WithEvents lblitmconvrsn As System.Windows.Forms.Label
    Friend WithEvents Txtcod1 As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtboxpcs As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtMPack As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents TxtboxCost As System.Windows.Forms.TextBox
    Friend WithEvents lstvew1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LstVew2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbxunit As System.Windows.Forms.ComboBox
    Friend WithEvents txtreordr As System.Windows.Forms.TextBox
    Friend WithEvents txtopnstok As System.Windows.Forms.TextBox
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents cmbxexcise As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents stitclose As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmItemBoM))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LstVew2 = New System.Windows.Forms.ListView
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.lstvew1 = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.lblitmconvrsn = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Txtitmremrk = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.btnimage = New System.Windows.Forms.Button
        Me.Btnloc = New System.Windows.Forms.Button
        Me.PicItm = New System.Windows.Forms.PictureBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.LblAlrt1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
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
        Me.Label50 = New System.Windows.Forms.Label
        Me.Cmbxloc = New System.Windows.Forms.ComboBox
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
        Me.Btnundrgrp = New System.Windows.Forms.Button
        Me.Txtitmconversn = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.labelsn = New System.Windows.Forms.Label
        Me.cmbxunit = New System.Windows.Forms.ComboBox
        Me.txtsno = New System.Windows.Forms.TextBox
        Me.CmbxStokGrup = New System.Windows.Forms.ComboBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Txtmax = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxtMPack = New System.Windows.Forms.TextBox
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
        Me.CmbxSelItm = New System.Windows.Forms.ComboBox
        Me.Txtcod1 = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Btnaditm = New System.Windows.Forms.Button
        Me.lblAval = New System.Windows.Forms.Label
        Me.lblnoitms = New System.Windows.Forms.Label
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.txtboxpcs = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.BtnQntOk = New System.Windows.Forms.Button
        Me.Label41 = New System.Windows.Forms.Label
        Me.TxtboxCost = New System.Windows.Forms.TextBox
        Me.txtqnty = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Rbboth = New System.Windows.Forms.RadioButton
        Me.RbBom = New System.Windows.Forms.RadioButton
        Me.Rbraw = New System.Windows.Forms.RadioButton
        Me.BomLstVew = New System.Windows.Forms.ListView
        Me.itmcode = New System.Windows.Forms.ColumnHeader
        Me.itmname = New System.Windows.Forms.ColumnHeader
        Me.itmqnty = New System.Windows.Forms.ColumnHeader
        Me.itmrate = New System.Windows.Forms.ColumnHeader
        Me.itmamt = New System.Windows.Forms.ColumnHeader
        Me.itmnature = New System.Windows.Forms.ColumnHeader
        Me.itmid = New System.Windows.Forms.ColumnHeader
        Me.colchek = New System.Windows.Forms.ColumnHeader
        Me.ColpGrupid = New System.Windows.Forms.ColumnHeader
        Me.Colratio = New System.Windows.Forms.ColumnHeader
        Me.ColPackChek = New System.Windows.Forms.ColumnHeader
        Me.lstvewContextms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.stitclose = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.lblmq = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.lblrol = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.lblsr = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.lblpr = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.lblut = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.lblig = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.lblin = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.lblic = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
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
        Me.rbSpBoth = New System.Windows.Forms.RadioButton
        Me.rBPurchaseOnly = New System.Windows.Forms.RadioButton
        Me.rBSaleOnly = New System.Windows.Forms.RadioButton
        Me.ItmDg = New System.Windows.Forms.DataGridView
        Me.stitdelete = New System.Windows.Forms.Button
        Me.stitfind = New System.Windows.Forms.Button
        Me.stitsave = New System.Windows.Forms.Button
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Lstvewitmsel = New System.Windows.Forms.ListView
        Me.Colitm1 = New System.Windows.Forms.ColumnHeader
        Me.ColItemid = New System.Windows.Forms.ColumnHeader
        Me.Colqnty = New System.Windows.Forms.ColumnHeader
        Me.colsih = New System.Windows.Forms.ColumnHeader
        Me.btnSelItm1 = New System.Windows.Forms.Button
        Me.BtnItmUnsel = New System.Windows.Forms.Button
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.Btnmove1 = New System.Windows.Forms.Button
        Me.BtnMove2 = New System.Windows.Forms.Button
        Me.Btnmove3 = New System.Windows.Forms.Button
        Me.Btnmove4 = New System.Windows.Forms.Button
        Me.Label47 = New System.Windows.Forms.Label
        Me.Lstbxprocs = New System.Windows.Forms.ListView
        Me.Colid1 = New System.Windows.Forms.ColumnHeader
        Me.Colpname = New System.Windows.Forms.ColumnHeader
        Me.lstbxprocs1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.OpnFDlog1 = New System.Windows.Forms.OpenFileDialog
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PicItm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.lstvewContextms.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.gBoxUse.SuspendLayout()
        CType(Me.ItmDg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LstVew2)
        Me.Panel1.Controls.Add(Me.lstvew1)
        Me.Panel1.Controls.Add(Me.lblitmconvrsn)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.btnimage)
        Me.Panel1.Controls.Add(Me.Btnloc)
        Me.Panel1.Controls.Add(Me.PicItm)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.LblAlrt1)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(Me.Btnundrgrp)
        Me.Panel1.Controls.Add(Me.Txtitmconversn)
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
        Me.Panel1.Size = New System.Drawing.Size(654, 533)
        Me.Panel1.TabIndex = 1
        '
        'LstVew2
        '
        Me.LstVew2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstVew2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7})
        Me.LstVew2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVew2.FullRowSelect = True
        Me.LstVew2.GridLines = True
        Me.LstVew2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LstVew2.Location = New System.Drawing.Point(364, 156)
        Me.LstVew2.Name = "LstVew2"
        Me.LstVew2.Size = New System.Drawing.Size(283, 10)
        Me.LstVew2.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LstVew2.TabIndex = 57
        Me.LstVew2.TabStop = False
        Me.LstVew2.UseCompatibleStateImageBehavior = False
        Me.LstVew2.View = System.Windows.Forms.View.Details
        Me.LstVew2.Visible = False
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Name"
        Me.ColumnHeader6.Width = 260
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Id"
        Me.ColumnHeader7.Width = 0
        '
        'lstvew1
        '
        Me.lstvew1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstvew1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lstvew1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstvew1.FullRowSelect = True
        Me.lstvew1.GridLines = True
        Me.lstvew1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstvew1.Location = New System.Drawing.Point(364, 172)
        Me.lstvew1.Name = "lstvew1"
        Me.lstvew1.Size = New System.Drawing.Size(106, 10)
        Me.lstvew1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstvew1.TabIndex = 56
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
        'lblitmconvrsn
        '
        Me.lblitmconvrsn.AutoSize = True
        Me.lblitmconvrsn.Location = New System.Drawing.Point(462, 334)
        Me.lblitmconvrsn.Name = "lblitmconvrsn"
        Me.lblitmconvrsn.Size = New System.Drawing.Size(72, 13)
        Me.lblitmconvrsn.TabIndex = 55
        Me.lblitmconvrsn.Text = "Conversion"
        Me.lblitmconvrsn.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Txtitmremrk)
        Me.Panel3.Controls.Add(Me.Label24)
        Me.Panel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(348, 361)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(300, 167)
        Me.Panel3.TabIndex = 24
        '
        'Txtitmremrk
        '
        Me.Txtitmremrk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtitmremrk.Location = New System.Drawing.Point(2, 21)
        Me.Txtitmremrk.MaxLength = 250
        Me.Txtitmremrk.Multiline = True
        Me.Txtitmremrk.Name = "Txtitmremrk"
        Me.Txtitmremrk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txtitmremrk.Size = New System.Drawing.Size(293, 142)
        Me.Txtitmremrk.TabIndex = 30
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.SteelBlue
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(0, 1)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(298, 19)
        Me.Label24.TabIndex = 43
        Me.Label24.Text = "Remarks"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnimage
        '
        Me.btnimage.BackColor = System.Drawing.Color.Transparent
        Me.btnimage.BackgroundImage = Global.FinAcct.My.Resources.Resources.btn
        Me.btnimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnimage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnimage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnimage.ForeColor = System.Drawing.Color.Black
        Me.btnimage.Location = New System.Drawing.Point(203, 507)
        Me.btnimage.Name = "btnimage"
        Me.btnimage.Size = New System.Drawing.Size(123, 23)
        Me.btnimage.TabIndex = 29
        Me.btnimage.Text = "&Image"
        Me.btnimage.UseVisualStyleBackColor = False
        '
        'Btnloc
        '
        Me.Btnloc.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btnloc.Location = New System.Drawing.Point(332, 314)
        Me.Btnloc.Name = "Btnloc"
        Me.Btnloc.Size = New System.Drawing.Size(26, 20)
        Me.Btnloc.TabIndex = 54
        Me.Btnloc.TabStop = False
        Me.Btnloc.Text = "...."
        Me.Btnloc.UseVisualStyleBackColor = True
        '
        'PicItm
        '
        Me.PicItm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicItm.InitialImage = Nothing
        Me.PicItm.Location = New System.Drawing.Point(203, 362)
        Me.PicItm.Name = "PicItm"
        Me.PicItm.Size = New System.Drawing.Size(122, 144)
        Me.PicItm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicItm.TabIndex = 12
        Me.PicItm.TabStop = False
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(5, 346)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 13)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Error  : -"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label18.Visible = False
        '
        'LblAlrt1
        '
        Me.LblAlrt1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAlrt1.ForeColor = System.Drawing.Color.Red
        Me.LblAlrt1.Location = New System.Drawing.Point(77, 346)
        Me.LblAlrt1.Name = "LblAlrt1"
        Me.LblAlrt1.Size = New System.Drawing.Size(269, 13)
        Me.LblAlrt1.TabIndex = 43
        Me.LblAlrt1.Text = "Invalid Input, Only Numbers are valid."
        Me.LblAlrt1.Visible = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.8483!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.1517!))
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
        Me.TableLayoutPanel3.Controls.Add(Me.Label50, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Cmbxloc, 1, 5)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(1, 149)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.67143!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(324, 194)
        Me.TableLayoutPanel3.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Cmbxht.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxht.Location = New System.Drawing.Point(206, 4)
        Me.Cmbxht.Name = "Cmbxht"
        Me.Cmbxht.Size = New System.Drawing.Size(114, 21)
        Me.Cmbxht.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(4, 129)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 24)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Material "
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxMatrl
        '
        Me.CmbxMatrl.AllowDrop = True
        Me.CmbxMatrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxMatrl.Location = New System.Drawing.Point(206, 132)
        Me.CmbxMatrl.Name = "CmbxMatrl"
        Me.CmbxMatrl.Size = New System.Drawing.Size(114, 21)
        Me.CmbxMatrl.TabIndex = 17
        '
        'Cmbxgrad
        '
        Me.Cmbxgrad.AllowDrop = True
        Me.Cmbxgrad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxgrad.Location = New System.Drawing.Point(206, 100)
        Me.Cmbxgrad.Name = "Cmbxgrad"
        Me.Cmbxgrad.Size = New System.Drawing.Size(114, 21)
        Me.Cmbxgrad.TabIndex = 16
        '
        'CmbxLnth
        '
        Me.CmbxLnth.AllowDrop = True
        Me.CmbxLnth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxLnth.Location = New System.Drawing.Point(206, 68)
        Me.CmbxLnth.Name = "CmbxLnth"
        Me.CmbxLnth.Size = New System.Drawing.Size(114, 21)
        Me.CmbxLnth.TabIndex = 15
        '
        'Cmbxwdth
        '
        Me.Cmbxwdth.AllowDrop = True
        Me.Cmbxwdth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxwdth.Location = New System.Drawing.Point(206, 36)
        Me.Cmbxwdth.Name = "Cmbxwdth"
        Me.Cmbxwdth.Size = New System.Drawing.Size(114, 21)
        Me.Cmbxwdth.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(4, 97)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 24)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Grade"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(4, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 24)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Length"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(4, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(144, 24)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Width/Dia "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label50
        '
        Me.Label50.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(4, 161)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(192, 32)
        Me.Label50.TabIndex = 35
        Me.Label50.Text = "Item Location (Opening Stock Only)"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cmbxloc
        '
        Me.Cmbxloc.AllowDrop = True
        Me.Cmbxloc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxloc.Location = New System.Drawing.Point(206, 164)
        Me.Cmbxloc.Name = "Cmbxloc"
        Me.Cmbxloc.Size = New System.Drawing.Size(114, 21)
        Me.Cmbxloc.TabIndex = 18
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.74359!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.25641!))
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
        Me.TableLayoutPanel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(1, 361)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.30559!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.02609!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.02609!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.02609!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.308!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.30813!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(196, 169)
        Me.TableLayoutPanel2.TabIndex = 19
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Navy
        Me.Label27.Location = New System.Drawing.Point(4, 137)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(90, 26)
        Me.Label27.TabIndex = 56
        Me.Label27.Text = "Status "
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbxexcise
        '
        Me.cmbxexcise.AllowDrop = True
        Me.cmbxexcise.BackColor = System.Drawing.Color.White
        Me.cmbxexcise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxexcise.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbxexcise.ForeColor = System.Drawing.Color.Navy
        Me.cmbxexcise.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmbxexcise.Location = New System.Drawing.Point(101, 111)
        Me.cmbxexcise.Name = "cmbxexcise"
        Me.cmbxexcise.Size = New System.Drawing.Size(89, 23)
        Me.cmbxexcise.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(4, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 24)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Opening Stock"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtval
        '
        Me.txtval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtval.Location = New System.Drawing.Point(101, 85)
        Me.txtval.Name = "txtval"
        Me.txtval.ReadOnly = True
        Me.txtval.Size = New System.Drawing.Size(89, 21)
        Me.txtval.TabIndex = 55
        Me.txtval.TabStop = False
        Me.txtval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Navy
        Me.Label12.Location = New System.Drawing.Point(4, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 27)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "Excise Details"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(4, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 24)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Value "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtper
        '
        Me.txtper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtper.Location = New System.Drawing.Point(101, 59)
        Me.txtper.Name = "txtper"
        Me.txtper.ReadOnly = True
        Me.txtper.Size = New System.Drawing.Size(89, 21)
        Me.txtper.TabIndex = 55
        Me.txtper.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(4, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 24)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Rate"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(4, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 25)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Per"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtrate
        '
        Me.txtrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtrate.Location = New System.Drawing.Point(101, 33)
        Me.txtrate.MaxLength = 18
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(89, 21)
        Me.txtrate.TabIndex = 20
        Me.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtopnstok
        '
        Me.txtopnstok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtopnstok.Location = New System.Drawing.Point(101, 4)
        Me.txtopnstok.MaxLength = 18
        Me.txtopnstok.Name = "txtopnstok"
        Me.txtopnstok.Size = New System.Drawing.Size(89, 21)
        Me.txtopnstok.TabIndex = 19
        Me.txtopnstok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cmbxstatus
        '
        Me.Cmbxstatus.AllowDrop = True
        Me.Cmbxstatus.BackColor = System.Drawing.Color.White
        Me.Cmbxstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxstatus.Enabled = False
        Me.Cmbxstatus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxstatus.ForeColor = System.Drawing.Color.Navy
        Me.Cmbxstatus.Items.AddRange(New Object() {"Consumable", "Non-Consumable"})
        Me.Cmbxstatus.Location = New System.Drawing.Point(101, 140)
        Me.Cmbxstatus.Name = "Cmbxstatus"
        Me.Cmbxstatus.Size = New System.Drawing.Size(89, 23)
        Me.Cmbxstatus.TabIndex = 22
        '
        'Btnundrgrp
        '
        Me.Btnundrgrp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btnundrgrp.Location = New System.Drawing.Point(622, 35)
        Me.Btnundrgrp.Name = "Btnundrgrp"
        Me.Btnundrgrp.Size = New System.Drawing.Size(26, 21)
        Me.Btnundrgrp.TabIndex = 48
        Me.Btnundrgrp.TabStop = False
        Me.Btnundrgrp.Text = "...."
        Me.Btnundrgrp.UseVisualStyleBackColor = True
        '
        'Txtitmconversn
        '
        Me.Txtitmconversn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtitmconversn.Enabled = False
        Me.Txtitmconversn.Location = New System.Drawing.Point(544, 334)
        Me.Txtitmconversn.Name = "Txtitmconversn"
        Me.Txtitmconversn.Size = New System.Drawing.Size(20, 21)
        Me.Txtitmconversn.TabIndex = 18
        Me.Txtitmconversn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtitmconversn.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.95269!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.04731!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.labelsn, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbxunit, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtsno, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbxStokGrup, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 1, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(1, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(614, 147)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "BOM Code && Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Under Group"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Units "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelsn
        '
        Me.labelsn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelsn.Location = New System.Drawing.Point(4, 59)
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
        Me.cmbxunit.Location = New System.Drawing.Point(206, 91)
        Me.cmbxunit.Name = "cmbxunit"
        Me.cmbxunit.Size = New System.Drawing.Size(157, 21)
        Me.cmbxunit.TabIndex = 6
        '
        'txtsno
        '
        Me.txtsno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsno.Location = New System.Drawing.Point(206, 62)
        Me.txtsno.MaxLength = 50
        Me.txtsno.Name = "txtsno"
        Me.txtsno.Size = New System.Drawing.Size(325, 21)
        Me.txtsno.TabIndex = 5
        '
        'CmbxStokGrup
        '
        Me.CmbxStokGrup.AllowDrop = True
        Me.CmbxStokGrup.Location = New System.Drawing.Point(206, 33)
        Me.CmbxStokGrup.Name = "CmbxStokGrup"
        Me.CmbxStokGrup.Size = New System.Drawing.Size(376, 21)
        Me.CmbxStokGrup.Sorted = True
        Me.CmbxStokGrup.TabIndex = 4
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Txtmax)
        Me.Panel6.Controls.Add(Me.Label39)
        Me.Panel6.Controls.Add(Me.Label25)
        Me.Panel6.Controls.Add(Me.Label23)
        Me.Panel6.Controls.Add(Me.TxtMPack)
        Me.Panel6.Controls.Add(Me.txtreordr)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(206, 120)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(404, 23)
        Me.Panel6.TabIndex = 10
        '
        'Txtmax
        '
        Me.Txtmax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtmax.Location = New System.Drawing.Point(320, 1)
        Me.Txtmax.MaxLength = 18
        Me.Txtmax.Name = "Txtmax"
        Me.Txtmax.Size = New System.Drawing.Size(81, 21)
        Me.Txtmax.TabIndex = 12
        Me.Txtmax.Text = "0"
        Me.Txtmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(6, 4)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(47, 13)
        Me.Label39.TabIndex = 31
        Me.Label39.Text = "M.Pack"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(93, 5)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 13)
        Me.Label25.TabIndex = 31
        Me.Label25.Text = "Min. Qnty "
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(248, 4)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(69, 13)
        Me.Label23.TabIndex = 31
        Me.Label23.Text = "Max. Qnty "
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtMPack
        '
        Me.TxtMPack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMPack.Location = New System.Drawing.Point(54, 1)
        Me.TxtMPack.MaxLength = 18
        Me.TxtMPack.Name = "TxtMPack"
        Me.TxtMPack.Size = New System.Drawing.Size(32, 21)
        Me.TxtMPack.TabIndex = 11
        Me.TxtMPack.Text = "0"
        Me.TxtMPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtreordr
        '
        Me.txtreordr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtreordr.Location = New System.Drawing.Point(161, 1)
        Me.txtreordr.MaxLength = 18
        Me.txtreordr.Name = "txtreordr"
        Me.txtreordr.Size = New System.Drawing.Size(81, 21)
        Me.txtreordr.TabIndex = 11
        Me.txtreordr.Text = "0"
        Me.txtreordr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(179, 26)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Master Packing and Re-Order Level "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.TxtItmname)
        Me.Panel7.Controls.Add(Me.Txtcode)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(206, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(404, 22)
        Me.Panel7.TabIndex = 1
        '
        'TxtItmname
        '
        Me.TxtItmname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtItmname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtItmname.Location = New System.Drawing.Point(83, 0)
        Me.TxtItmname.MaxLength = 70
        Me.TxtItmname.Name = "TxtItmname"
        Me.TxtItmname.Size = New System.Drawing.Size(318, 21)
        Me.TxtItmname.TabIndex = 3
        '
        'Txtcode
        '
        Me.Txtcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtcode.Location = New System.Drawing.Point(0, 0)
        Me.Txtcode.MaxLength = 8
        Me.Txtcode.Name = "Txtcode"
        Me.Txtcode.Size = New System.Drawing.Size(80, 21)
        Me.Txtcode.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(364, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(364, 284)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(46, 13)
        Me.Label22.TabIndex = 47
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(364, 252)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(46, 13)
        Me.Label21.TabIndex = 46
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(364, 221)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 13)
        Me.Label20.TabIndex = 45
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(364, 188)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 13)
        Me.Label19.TabIndex = 44
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Btnmatrl
        '
        Me.Btnmatrl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btnmatrl.Location = New System.Drawing.Point(332, 280)
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
        Me.Btnwdth.Location = New System.Drawing.Point(332, 185)
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
        Me.Btngrad.Location = New System.Drawing.Point(332, 249)
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
        Me.Btnht.Location = New System.Drawing.Point(332, 153)
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
        Me.btnlnth.Location = New System.Drawing.Point(332, 218)
        Me.btnlnth.Name = "btnlnth"
        Me.btnlnth.Size = New System.Drawing.Size(26, 20)
        Me.btnlnth.TabIndex = 51
        Me.btnlnth.TabStop = False
        Me.btnlnth.Text = "...."
        Me.btnlnth.UseVisualStyleBackColor = True
        '
        'CmbxSelItm
        '
        Me.CmbxSelItm.FormattingEnabled = True
        Me.CmbxSelItm.Location = New System.Drawing.Point(72, 29)
        Me.CmbxSelItm.Name = "CmbxSelItm"
        Me.CmbxSelItm.Size = New System.Drawing.Size(257, 21)
        Me.CmbxSelItm.TabIndex = 5
        '
        'Txtcod1
        '
        Me.Txtcod1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtcod1.Location = New System.Drawing.Point(72, 4)
        Me.Txtcod1.Name = "Txtcod1"
        Me.Txtcod1.Size = New System.Drawing.Size(105, 21)
        Me.Txtcod1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Btnaditm)
        Me.Panel2.Controls.Add(Me.lblAval)
        Me.Panel2.Controls.Add(Me.lblnoitms)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel2.Controls.Add(Me.Label38)
        Me.Panel2.Controls.Add(Me.Label36)
        Me.Panel2.Controls.Add(Me.Label34)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.BomLstVew)
        Me.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(3, 538)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(473, 277)
        Me.Panel2.TabIndex = 0
        Me.Panel2.Visible = False
        '
        'Btnaditm
        '
        Me.Btnaditm.Location = New System.Drawing.Point(437, 40)
        Me.Btnaditm.Name = "Btnaditm"
        Me.Btnaditm.Size = New System.Drawing.Size(31, 21)
        Me.Btnaditm.TabIndex = 44
        Me.Btnaditm.TabStop = False
        Me.Btnaditm.Text = "...."
        Me.Btnaditm.UseVisualStyleBackColor = True
        '
        'lblAval
        '
        Me.lblAval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAval.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAval.ForeColor = System.Drawing.Color.Black
        Me.lblAval.Location = New System.Drawing.Point(273, 128)
        Me.lblAval.Name = "lblAval"
        Me.lblAval.Size = New System.Drawing.Size(87, 15)
        Me.lblAval.TabIndex = 44
        Me.lblAval.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblnoitms
        '
        Me.lblnoitms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblnoitms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnoitms.ForeColor = System.Drawing.Color.Black
        Me.lblnoitms.Location = New System.Drawing.Point(100, 128)
        Me.lblnoitms.Name = "lblnoitms"
        Me.lblnoitms.Size = New System.Drawing.Size(87, 15)
        Me.lblnoitms.TabIndex = 43
        Me.lblnoitms.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.49689!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.50311!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label31, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.CmbxSelItm, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label29, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Txtcod1, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label51, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel11, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel12, 1, 3)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(100, 7)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.66563!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.33222!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.50344!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.49869!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(333, 118)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(4, 85)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(61, 27)
        Me.Label31.TabIndex = 39
        Me.Label31.Text = "Quantity"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(4, 26)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(61, 26)
        Me.Label29.TabIndex = 38
        Me.Label29.Text = "Item Name"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label51
        '
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(4, 1)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(60, 24)
        Me.Label51.TabIndex = 38
        Me.Label51.Text = "Code"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 27)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Ratio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.txtboxpcs)
        Me.Panel11.Controls.Add(Me.Label11)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(72, 56)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(257, 25)
        Me.Panel11.TabIndex = 6
        '
        'txtboxpcs
        '
        Me.txtboxpcs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtboxpcs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxpcs.Location = New System.Drawing.Point(3, 2)
        Me.txtboxpcs.MaxLength = 5
        Me.txtboxpcs.Name = "txtboxpcs"
        Me.txtboxpcs.Size = New System.Drawing.Size(54, 21)
        Me.txtboxpcs.TabIndex = 6
        Me.txtboxpcs.Text = "1"
        Me.txtboxpcs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Yellow
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(62, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(192, 18)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "After How Much Pcs It Required."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Visible = False
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.BtnQntOk)
        Me.Panel12.Controls.Add(Me.Label41)
        Me.Panel12.Controls.Add(Me.TxtboxCost)
        Me.Panel12.Controls.Add(Me.txtqnty)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(72, 88)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(257, 26)
        Me.Panel12.TabIndex = 7
        '
        'BtnQntOk
        '
        Me.BtnQntOk.Location = New System.Drawing.Point(219, 1)
        Me.BtnQntOk.Name = "BtnQntOk"
        Me.BtnQntOk.Size = New System.Drawing.Size(31, 23)
        Me.BtnQntOk.TabIndex = 9
        Me.BtnQntOk.Text = "&Ok"
        Me.BtnQntOk.UseVisualStyleBackColor = True
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(82, 4)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(32, 14)
        Me.Label41.TabIndex = 39
        Me.Label41.Text = "Cost"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtboxCost
        '
        Me.TxtboxCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtboxCost.Location = New System.Drawing.Point(117, 2)
        Me.TxtboxCost.MaxLength = 18
        Me.TxtboxCost.Name = "TxtboxCost"
        Me.TxtboxCost.ReadOnly = True
        Me.TxtboxCost.Size = New System.Drawing.Size(92, 21)
        Me.TxtboxCost.TabIndex = 8
        Me.TxtboxCost.Text = "0"
        Me.TxtboxCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtqnty
        '
        Me.txtqnty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtqnty.Location = New System.Drawing.Point(3, 2)
        Me.txtqnty.MaxLength = 18
        Me.txtqnty.Name = "txtqnty"
        Me.txtqnty.Size = New System.Drawing.Size(73, 21)
        Me.txtqnty.TabIndex = 7
        Me.txtqnty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Navy
        Me.Label38.Location = New System.Drawing.Point(191, 128)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(72, 13)
        Me.Label38.TabIndex = 42
        Me.Label38.Text = "Aprx. Value"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Navy
        Me.Label36.Location = New System.Drawing.Point(6, 128)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(75, 13)
        Me.Label36.TabIndex = 41
        Me.Label36.Text = "No. of items"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Red
        Me.Label34.Location = New System.Drawing.Point(6, 149)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(462, 13)
        Me.Label34.TabIndex = 40
        Me.Label34.Text = "Currently Selected Item name "
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label34.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Rbboth)
        Me.GroupBox1.Controls.Add(Me.RbBom)
        Me.GroupBox1.Controls.Add(Me.Rbraw)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(8, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(89, 93)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item Filter"
        '
        'Rbboth
        '
        Me.Rbboth.AutoSize = True
        Me.Rbboth.Checked = True
        Me.Rbboth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbboth.ForeColor = System.Drawing.Color.Black
        Me.Rbboth.Location = New System.Drawing.Point(6, 71)
        Me.Rbboth.Name = "Rbboth"
        Me.Rbboth.Size = New System.Drawing.Size(51, 17)
        Me.Rbboth.TabIndex = 1
        Me.Rbboth.TabStop = True
        Me.Rbboth.Text = "Both"
        Me.Rbboth.UseVisualStyleBackColor = True
        '
        'RbBom
        '
        Me.RbBom.AutoSize = True
        Me.RbBom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbBom.ForeColor = System.Drawing.Color.Black
        Me.RbBom.Location = New System.Drawing.Point(6, 45)
        Me.RbBom.Name = "RbBom"
        Me.RbBom.Size = New System.Drawing.Size(51, 17)
        Me.RbBom.TabIndex = 0
        Me.RbBom.Text = "BOM"
        Me.RbBom.UseVisualStyleBackColor = True
        '
        'Rbraw
        '
        Me.Rbraw.AutoSize = True
        Me.Rbraw.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbraw.ForeColor = System.Drawing.Color.Black
        Me.Rbraw.Location = New System.Drawing.Point(6, 19)
        Me.Rbraw.Name = "Rbraw"
        Me.Rbraw.Size = New System.Drawing.Size(86, 17)
        Me.Rbraw.TabIndex = 0
        Me.Rbraw.Text = "Raw Items"
        Me.Rbraw.UseVisualStyleBackColor = True
        '
        'BomLstVew
        '
        Me.BomLstVew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BomLstVew.CheckBoxes = True
        Me.BomLstVew.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.itmcode, Me.itmname, Me.itmqnty, Me.itmrate, Me.itmamt, Me.itmnature, Me.itmid, Me.colchek, Me.ColpGrupid, Me.Colratio, Me.ColPackChek})
        Me.BomLstVew.ContextMenuStrip = Me.lstvewContextms
        Me.BomLstVew.FullRowSelect = True
        Me.BomLstVew.GridLines = True
        Me.BomLstVew.Location = New System.Drawing.Point(9, 165)
        Me.BomLstVew.Name = "BomLstVew"
        Me.BomLstVew.Size = New System.Drawing.Size(461, 111)
        Me.BomLstVew.TabIndex = 0
        Me.BomLstVew.UseCompatibleStateImageBehavior = False
        Me.BomLstVew.View = System.Windows.Forms.View.Details
        '
        'itmcode
        '
        Me.itmcode.Text = " Code"
        Me.itmcode.Width = 76
        '
        'itmname
        '
        Me.itmname.Text = "Item Name"
        Me.itmname.Width = 166
        '
        'itmqnty
        '
        Me.itmqnty.Text = "Quantity"
        Me.itmqnty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.itmqnty.Width = 74
        '
        'itmrate
        '
        Me.itmrate.Text = " Rate"
        Me.itmrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.itmrate.Width = 61
        '
        'itmamt
        '
        Me.itmamt.Text = " Amount"
        Me.itmamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.itmamt.Width = 78
        '
        'itmnature
        '
        Me.itmnature.DisplayIndex = 6
        Me.itmnature.Text = "Nature"
        Me.itmnature.Width = 50
        '
        'itmid
        '
        Me.itmid.DisplayIndex = 5
        Me.itmid.Text = "Item Id"
        Me.itmid.Width = 90
        '
        'colchek
        '
        Me.colchek.Text = "colchek"
        Me.colchek.Width = 90
        '
        'ColpGrupid
        '
        Me.ColpGrupid.Text = "Procsgrupid"
        Me.ColpGrupid.Width = 90
        '
        'Colratio
        '
        Me.Colratio.Text = "Ratio"
        Me.Colratio.Width = 90
        '
        'ColPackChek
        '
        Me.ColPackChek.Text = "Check Pack Status"
        Me.ColPackChek.Width = 90
        '
        'lstvewContextms
        '
        Me.lstvewContextms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.lstvewContextms.Name = "lstvewContextms"
        Me.lstvewContextms.Size = New System.Drawing.Size(108, 70)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
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
        Me.stitclose.ForeColor = System.Drawing.Color.Black
        Me.stitclose.Location = New System.Drawing.Point(7, 518)
        Me.stitclose.Name = "stitclose"
        Me.stitclose.Size = New System.Drawing.Size(160, 33)
        Me.stitclose.TabIndex = 34
        Me.stitclose.Text = "&Close"
        Me.stitclose.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.ForeColor = System.Drawing.Color.Navy
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 1)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.BackgroundImage = Global.FinAcct.My.Resources.Resources._8131hi
        Me.SplitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel10)
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Size = New System.Drawing.Size(1029, 557)
        Me.SplitContainer1.SplitterDistance = 175
        Me.SplitContainer1.TabIndex = 100
        Me.SplitContainer1.TabStop = False
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel10.Controls.Add(Me.lblmq)
        Me.Panel10.Controls.Add(Me.Label46)
        Me.Panel10.Controls.Add(Me.lblrol)
        Me.Panel10.Controls.Add(Me.Label48)
        Me.Panel10.Controls.Add(Me.lblsr)
        Me.Panel10.Controls.Add(Me.Label40)
        Me.Panel10.Controls.Add(Me.lblpr)
        Me.Panel10.Controls.Add(Me.Label42)
        Me.Panel10.Controls.Add(Me.lblut)
        Me.Panel10.Controls.Add(Me.Label44)
        Me.Panel10.Controls.Add(Me.lblig)
        Me.Panel10.Controls.Add(Me.Label37)
        Me.Panel10.Controls.Add(Me.lblin)
        Me.Panel10.Controls.Add(Me.Label35)
        Me.Panel10.Controls.Add(Me.lblic)
        Me.Panel10.Controls.Add(Me.Label33)
        Me.Panel10.Location = New System.Drawing.Point(1, 54)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(169, 321)
        Me.Panel10.TabIndex = 30
        Me.Panel10.Visible = False
        '
        'lblmq
        '
        Me.lblmq.AutoSize = True
        Me.lblmq.ForeColor = System.Drawing.Color.White
        Me.lblmq.Location = New System.Drawing.Point(9, 302)
        Me.lblmq.Name = "lblmq"
        Me.lblmq.Size = New System.Drawing.Size(0, 13)
        Me.lblmq.TabIndex = 8
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.ForeColor = System.Drawing.Color.Yellow
        Me.Label46.Location = New System.Drawing.Point(3, 282)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(128, 13)
        Me.Label46.TabIndex = 9
        Me.Label46.Text = "Maximum Quantity"
        '
        'lblrol
        '
        Me.lblrol.AutoSize = True
        Me.lblrol.ForeColor = System.Drawing.Color.White
        Me.lblrol.Location = New System.Drawing.Point(9, 262)
        Me.lblrol.Name = "lblrol"
        Me.lblrol.Size = New System.Drawing.Size(0, 13)
        Me.lblrol.TabIndex = 10
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.ForeColor = System.Drawing.Color.Yellow
        Me.Label48.Location = New System.Drawing.Point(3, 242)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(105, 13)
        Me.Label48.TabIndex = 7
        Me.Label48.Text = "Re-Order Level"
        '
        'lblsr
        '
        Me.lblsr.AutoSize = True
        Me.lblsr.ForeColor = System.Drawing.Color.White
        Me.lblsr.Location = New System.Drawing.Point(9, 226)
        Me.lblsr.Name = "lblsr"
        Me.lblsr.Size = New System.Drawing.Size(0, 13)
        Me.lblsr.TabIndex = 4
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.ForeColor = System.Drawing.Color.Yellow
        Me.Label40.Location = New System.Drawing.Point(3, 206)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(68, 13)
        Me.Label40.TabIndex = 5
        Me.Label40.Text = "Sale Rate"
        '
        'lblpr
        '
        Me.lblpr.AutoSize = True
        Me.lblpr.ForeColor = System.Drawing.Color.White
        Me.lblpr.Location = New System.Drawing.Point(9, 186)
        Me.lblpr.Name = "lblpr"
        Me.lblpr.Size = New System.Drawing.Size(0, 13)
        Me.lblpr.TabIndex = 6
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.ForeColor = System.Drawing.Color.Yellow
        Me.Label42.Location = New System.Drawing.Point(3, 166)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(100, 13)
        Me.Label42.TabIndex = 1
        Me.Label42.Text = "Purchase Rate"
        '
        'lblut
        '
        Me.lblut.AutoSize = True
        Me.lblut.ForeColor = System.Drawing.Color.White
        Me.lblut.Location = New System.Drawing.Point(9, 146)
        Me.lblut.Name = "lblut"
        Me.lblut.Size = New System.Drawing.Size(0, 13)
        Me.lblut.TabIndex = 2
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.ForeColor = System.Drawing.Color.Yellow
        Me.Label44.Location = New System.Drawing.Point(3, 126)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(69, 13)
        Me.Label44.TabIndex = 3
        Me.Label44.Text = "Unit Type"
        '
        'lblig
        '
        Me.lblig.AutoSize = True
        Me.lblig.ForeColor = System.Drawing.Color.White
        Me.lblig.Location = New System.Drawing.Point(9, 106)
        Me.lblig.Name = "lblig"
        Me.lblig.Size = New System.Drawing.Size(0, 13)
        Me.lblig.TabIndex = 0
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.ForeColor = System.Drawing.Color.Yellow
        Me.Label37.Location = New System.Drawing.Point(3, 86)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(81, 13)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "Item Group"
        '
        'lblin
        '
        Me.lblin.AutoSize = True
        Me.lblin.ForeColor = System.Drawing.Color.White
        Me.lblin.Location = New System.Drawing.Point(9, 66)
        Me.lblin.Name = "lblin"
        Me.lblin.Size = New System.Drawing.Size(0, 13)
        Me.lblin.TabIndex = 0
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ForeColor = System.Drawing.Color.Yellow
        Me.Label35.Location = New System.Drawing.Point(3, 46)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(79, 13)
        Me.Label35.TabIndex = 0
        Me.Label35.Text = "Item Name"
        '
        'lblic
        '
        Me.lblic.AutoSize = True
        Me.lblic.ForeColor = System.Drawing.Color.White
        Me.lblic.Location = New System.Drawing.Point(9, 26)
        Me.lblic.Name = "lblic"
        Me.lblic.Size = New System.Drawing.Size(15, 13)
        Me.lblic.TabIndex = 0
        Me.lblic.Text = "  "
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.Yellow
        Me.Label33.Location = New System.Drawing.Point(3, 6)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(86, 13)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Item Nature"
        '
        'Panel8
        '
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
        Me.Panel8.Location = New System.Drawing.Point(2, 25)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(169, 23)
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
        Me.Label26.Location = New System.Drawing.Point(6, 4)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(43, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "NAME"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
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
        Me.lblname.Size = New System.Drawing.Size(0, 13)
        Me.lblname.TabIndex = 0
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
        Me.Label28.Location = New System.Drawing.Point(6, 44)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 13)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "LOCATION"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
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
        Me.gBoxUse.Controls.Add(Me.rbSpBoth)
        Me.gBoxUse.Controls.Add(Me.rBPurchaseOnly)
        Me.gBoxUse.Controls.Add(Me.rBSaleOnly)
        Me.gBoxUse.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gBoxUse.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.gBoxUse.Location = New System.Drawing.Point(8, 4)
        Me.gBoxUse.Name = "gBoxUse"
        Me.gBoxUse.Size = New System.Drawing.Size(116, 19)
        Me.gBoxUse.TabIndex = 0
        Me.gBoxUse.TabStop = False
        Me.gBoxUse.Text = "Available For"
        Me.gBoxUse.Visible = False
        '
        'rbSpBoth
        '
        Me.rbSpBoth.AutoSize = True
        Me.rbSpBoth.Location = New System.Drawing.Point(7, 53)
        Me.rbSpBoth.Name = "rbSpBoth"
        Me.rbSpBoth.Size = New System.Drawing.Size(55, 18)
        Me.rbSpBoth.TabIndex = 0
        Me.rbSpBoth.Text = "Both"
        Me.rbSpBoth.UseVisualStyleBackColor = True
        '
        'rBPurchaseOnly
        '
        Me.rBPurchaseOnly.AutoSize = True
        Me.rBPurchaseOnly.Checked = True
        Me.rBPurchaseOnly.Location = New System.Drawing.Point(7, 34)
        Me.rBPurchaseOnly.Name = "rBPurchaseOnly"
        Me.rBPurchaseOnly.Size = New System.Drawing.Size(96, 18)
        Me.rBPurchaseOnly.TabIndex = 0
        Me.rBPurchaseOnly.TabStop = True
        Me.rBPurchaseOnly.Text = "Porduction"
        Me.rBPurchaseOnly.UseVisualStyleBackColor = True
        '
        'rBSaleOnly
        '
        Me.rBSaleOnly.AutoSize = True
        Me.rBSaleOnly.Location = New System.Drawing.Point(7, 16)
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
        Me.ItmDg.Location = New System.Drawing.Point(4, 147)
        Me.ItmDg.Name = "ItmDg"
        Me.ItmDg.Size = New System.Drawing.Size(0, 19)
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
        Me.stitdelete.ForeColor = System.Drawing.Color.Black
        Me.stitdelete.Location = New System.Drawing.Point(7, 481)
        Me.stitdelete.Name = "stitdelete"
        Me.stitdelete.Size = New System.Drawing.Size(160, 33)
        Me.stitdelete.TabIndex = 33
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
        Me.stitfind.ForeColor = System.Drawing.Color.Black
        Me.stitfind.Location = New System.Drawing.Point(7, 443)
        Me.stitfind.Name = "stitfind"
        Me.stitfind.Size = New System.Drawing.Size(160, 33)
        Me.stitfind.TabIndex = 32
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
        Me.stitsave.ForeColor = System.Drawing.Color.Black
        Me.stitsave.Location = New System.Drawing.Point(7, 406)
        Me.stitsave.Name = "stitsave"
        Me.stitsave.Size = New System.Drawing.Size(160, 33)
        Me.stitsave.TabIndex = 31
        Me.stitsave.Text = "&Save"
        Me.stitsave.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.84013!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.31464!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.84523!))
        Me.TableLayoutPanel6.Controls.Add(Me.Panel5, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.Label49, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Panel9, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Label47, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Lstbxprocs, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.lstbxprocs1, 2, 1)
        Me.TableLayoutPanel6.Enabled = False
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(658, 2)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.451128!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.20301!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.15789!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(400, 530)
        Me.TableLayoutPanel6.TabIndex = 46
        Me.TableLayoutPanel6.Visible = False
        '
        'Panel5
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.Panel5, 3)
        Me.Panel5.Controls.Add(Me.Lstvewitmsel)
        Me.Panel5.Controls.Add(Me.btnSelItm1)
        Me.Panel5.Controls.Add(Me.BtnItmUnsel)
        Me.Panel5.Controls.Add(Me.Label43)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(4, 198)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(392, 328)
        Me.Panel5.TabIndex = 24
        '
        'Lstvewitmsel
        '
        Me.Lstvewitmsel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lstvewitmsel.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Colitm1, Me.ColItemid, Me.Colqnty, Me.colsih})
        Me.Lstvewitmsel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lstvewitmsel.FullRowSelect = True
        Me.Lstvewitmsel.GridLines = True
        Me.Lstvewitmsel.Location = New System.Drawing.Point(1, 19)
        Me.Lstvewitmsel.Name = "Lstvewitmsel"
        Me.Lstvewitmsel.Size = New System.Drawing.Size(391, 282)
        Me.Lstvewitmsel.TabIndex = 26
        Me.Lstvewitmsel.UseCompatibleStateImageBehavior = False
        Me.Lstvewitmsel.View = System.Windows.Forms.View.Details
        '
        'Colitm1
        '
        Me.Colitm1.Text = "Group &  Item Name"
        Me.Colitm1.Width = 205
        '
        'ColItemid
        '
        Me.ColItemid.Text = "Item Code"
        Me.ColItemid.Width = 97
        '
        'Colqnty
        '
        Me.Colqnty.Text = "Quantity"
        Me.Colqnty.Width = 88
        '
        'colsih
        '
        Me.colsih.Text = "Stock In Hand"
        Me.colsih.Width = 0
        '
        'btnSelItm1
        '
        Me.btnSelItm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelItm1.Location = New System.Drawing.Point(2, 304)
        Me.btnSelItm1.Name = "btnSelItm1"
        Me.btnSelItm1.Size = New System.Drawing.Size(193, 24)
        Me.btnSelItm1.TabIndex = 16
        Me.btnSelItm1.Text = "&Add Item(s)"
        Me.btnSelItm1.UseVisualStyleBackColor = True
        '
        'BtnItmUnsel
        '
        Me.BtnItmUnsel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnItmUnsel.Location = New System.Drawing.Point(198, 304)
        Me.BtnItmUnsel.Name = "BtnItmUnsel"
        Me.BtnItmUnsel.Size = New System.Drawing.Size(193, 24)
        Me.BtnItmUnsel.TabIndex = 17
        Me.BtnItmUnsel.Text = "&Remove Item(s)"
        Me.BtnItmUnsel.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Cyan
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(1, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(391, 20)
        Me.Label43.TabIndex = 6
        Me.Label43.Text = "Make A Cutomise Movement Of Items, According To The Process"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(227, 1)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(168, 26)
        Me.Label49.TabIndex = 1
        Me.Label49.Text = "Make A Sequel Of Required Processes"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Btnmove1)
        Me.Panel9.Controls.Add(Me.BtnMove2)
        Me.Panel9.Controls.Add(Me.Btnmove3)
        Me.Panel9.Controls.Add(Me.Btnmove4)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(178, 33)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(42, 158)
        Me.Panel9.TabIndex = 15
        '
        'Btnmove1
        '
        Me.Btnmove1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnmove1.Location = New System.Drawing.Point(1, 46)
        Me.Btnmove1.Name = "Btnmove1"
        Me.Btnmove1.Size = New System.Drawing.Size(40, 24)
        Me.Btnmove1.TabIndex = 16
        Me.Btnmove1.Text = ">"
        Me.Btnmove1.UseVisualStyleBackColor = True
        '
        'BtnMove2
        '
        Me.BtnMove2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMove2.Location = New System.Drawing.Point(1, 74)
        Me.BtnMove2.Name = "BtnMove2"
        Me.BtnMove2.Size = New System.Drawing.Size(40, 24)
        Me.BtnMove2.TabIndex = 17
        Me.BtnMove2.Text = "<"
        Me.BtnMove2.UseVisualStyleBackColor = True
        '
        'Btnmove3
        '
        Me.Btnmove3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnmove3.Location = New System.Drawing.Point(1, 102)
        Me.Btnmove3.Name = "Btnmove3"
        Me.Btnmove3.Size = New System.Drawing.Size(40, 24)
        Me.Btnmove3.TabIndex = 18
        Me.Btnmove3.Text = ">>"
        Me.Btnmove3.UseVisualStyleBackColor = True
        '
        'Btnmove4
        '
        Me.Btnmove4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnmove4.Location = New System.Drawing.Point(1, 130)
        Me.Btnmove4.Name = "Btnmove4"
        Me.Btnmove4.Size = New System.Drawing.Size(40, 24)
        Me.Btnmove4.TabIndex = 19
        Me.Btnmove4.Text = "<<"
        Me.Btnmove4.UseVisualStyleBackColor = True
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(4, 1)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(120, 13)
        Me.Label47.TabIndex = 0
        Me.Label47.Text = "Available Processes"
        '
        'Lstbxprocs
        '
        Me.Lstbxprocs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lstbxprocs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Colid1, Me.Colpname})
        Me.Lstbxprocs.FullRowSelect = True
        Me.Lstbxprocs.GridLines = True
        Me.Lstbxprocs.Location = New System.Drawing.Point(4, 33)
        Me.Lstbxprocs.Name = "Lstbxprocs"
        Me.Lstbxprocs.Size = New System.Drawing.Size(167, 158)
        Me.Lstbxprocs.TabIndex = 25
        Me.Lstbxprocs.UseCompatibleStateImageBehavior = False
        Me.Lstbxprocs.View = System.Windows.Forms.View.Details
        '
        'Colid1
        '
        Me.Colid1.Text = "Id"
        Me.Colid1.Width = 0
        '
        'Colpname
        '
        Me.Colpname.Text = "Process Name"
        Me.Colpname.Width = 165
        '
        'lstbxprocs1
        '
        Me.lstbxprocs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstbxprocs1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lstbxprocs1.FullRowSelect = True
        Me.lstbxprocs1.GridLines = True
        Me.lstbxprocs1.Location = New System.Drawing.Point(227, 33)
        Me.lstbxprocs1.MultiSelect = False
        Me.lstbxprocs1.Name = "lstbxprocs1"
        Me.lstbxprocs1.Size = New System.Drawing.Size(167, 158)
        Me.lstbxprocs1.TabIndex = 25
        Me.lstbxprocs1.UseCompatibleStateImageBehavior = False
        Me.lstbxprocs1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Selected Process Name"
        Me.ColumnHeader2.Width = 165
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Colchkprocs"
        Me.ColumnHeader3.Width = 0
        '
        'OpnFDlog1
        '
        Me.OpnFDlog1.FileName = "OpenFileDialog1"
        '
        'FrmItemBoM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1030, 564)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmItemBoM"
        Me.Text = "Bill Of Material Master"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PicItm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.lstvewContextms.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.gBoxUse.ResumeLayout(False)
        Me.gBoxUse.PerformLayout()
        CType(Me.ItmDg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub tabindx()
        Panel1.Focus()
        Txtcode.TabIndex = 1
        CmbxStokGrup.TabIndex = 2
        txtsno.TabIndex = 3
        cmbxunit.TabIndex = 4

        txtreordr.TabIndex = 6
        Panel2.Focus()
        txtopnstok.TabIndex = 2
        txtrate.TabIndex = 3
        Panel3.Focus()
        cmbxexcise.TabIndex = 3


    End Sub

    Private Sub FrmStokItm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Width = 851
            Me.Height = 592

            sql = New inv_sql
            sql1 = New inv_sql
            CheckAcess_Btn_frm(stitsave, stitfind, stitdelete)
            C12 = 0
            C13 = 0
            'tabindx()
            fill_Cmbxundrgrup()
            Fill_lstbx()
            Fill_Combobox_WitoutDelStatus("itmhtid", "itmhtin", "finact_itmhgtmstr", Cmbxht)
            Fill_Combobox_WitoutDelStatus("itmwdthid", "itmwdthin", "finact_itmwdthmstr", Cmbxwdth)
            Fill_Combobox_WitoutDelStatus("itmlnthid", "itmlnthin", "finact_itmlnthmstr", CmbxLnth)
            Fill_Combobox_WitoutDelStatus("itmgradid", "itmgradname", "finact_itmgradmstr", Cmbxgrad)
            Fill_Combobox_WitoutDelStatus("itmgradid", "itmmatrlname", "finact_itmmatrlmstr", CmbxMatrl)

            Dim cond As String = "Inner"
            Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", Cmbxloc, cond, "CSCDELSTATUS", CInt(1))
            Me.Text = Me.Text & "  Current User Name :- " & " " & Current_UsrId
            setcontrols()
            Me.SplitContainer1.SplitterDistance = 175
            Me.SplitContainer1.IsSplitterFixed = True
            'Me.SplitContainer1.Panel1.Enabled = False
            If Chk_Exisit2("finactitmmstr", "itmid", "itmtype1", "BomItem") = True Then
                Me.stitfind.Visible = True
                Me.stitsave.Location = New System.Drawing.Point(7, 406)
                Me.stitsave.Text = "&Next"
            Else
                Me.stitfind.Visible = False
                Me.stitsave.Location = New System.Drawing.Point(7, 443)
                Me.stitsave.Text = "&Next"
            End If
            set_Condition()
            Spl_Fill_Combobox(SelStrg, CmbxSelItm)

            Me.Panel2.Enabled = False
            Me.cmbxexcise.SelectedIndex = 1
            Me.Cmbxstatus.SelectedIndex = 1
            Me.BomLstVew.AllowColumnReorder = True
            ' Me.BomLstVew.LabelEdit = True
            Inr_Flag = False
            Otr_Flag = False
            FrmShow_flag(20) = False
            FrmShow_flag(22) = True

        Catch ex As Exception

        End Try
    End Sub
    Private Sub fill_Cmbxundrgrup()
        Try
            grupnamcom = New SqlCommand("select Cogrupnam from FinactstokGrupname where Codelstatus=1 and Cogrupnam<>'" & ("Primary") & "' order by Cogrupnam ", FinActConn)
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
        If Me.BomLstVew.Items.Count > 0 And Trim(Me.stitsave.Text) <> "&Next" Then
            For Each ckItm As ListViewItem In Me.BomLstVew.Items
                If Trim(ckItm.SubItems(7).Text) = "NotAded" Then
                    ckItm.BackColor = Color.Yellow
                    indx = indx + 1
                Else
                    ckItm.BackColor = Color.White
                End If
            Next

        End If
        With Me.txtboxpcs
            If Trim(.Text) = "" Then
                .Text = 0
            End If
        End With


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
        ' cmbxunit.DroppedDown = True
        If cmbxunit.SelectedIndex = -1 Then
            cmbxunit.SelectedIndex = 0
            'Dim str As Integer = Trim(cmbxunit.FindStringExact("Gross", 0))' to find a particular item combobox.
            'cmbxunit.SelectedIndex = str

        End If
    End Sub

    Private Sub cmbxunit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxunit.Leave

        Try
            txtper.Text = cmbxunit.Text

            Select Case Trim(Me.cmbxunit.Text)
                Case "Kg"
                    Me.lblitmconvrsn.Text = Trim("No.of Piece(s)in one Kg.")
                    Me.Txtitmconversn.Enabled = True
                Case "Pcs"
                    Me.lblitmconvrsn.Text = Trim("Wt.of One Piece (In Kg.)")
                    Me.Txtitmconversn.Enabled = True
                Case "Gross"
                    Me.lblitmconvrsn.Text = Trim("Wt.of One Gross (In Kg.)")
                    Me.Txtitmconversn.Enabled = True
                Case "Dozen"
                    Me.lblitmconvrsn.Text = Trim("Wt.of One Dozen (In Kg.)")
                    Me.Txtitmconversn.Enabled = True
                Case "Bag"
                    Me.lblitmconvrsn.Text = Trim("Wt.of One Bag (In Kg.)")
                    Me.Txtitmconversn.Enabled = True
                Case "Packet"
                    Me.lblitmconvrsn.Text = Trim("Wt.of One Packet (In Kg.)")
                    Me.Txtitmconversn.Enabled = True
                Case "Liter"
                    Me.lblitmconvrsn.Text = Trim("")
                    Me.Txtitmconversn.Enabled = False
                Case "Meter"
                    Me.lblitmconvrsn.Text = Trim("")
                    Me.Txtitmconversn.Enabled = False
            End Select
        Catch ex As Exception

        End Try


    End Sub

    Private Sub stitclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stitclose.Click
        Me.Close()
    End Sub

    Private Sub clrflds()
        Txtcode.Text = ""
        TxtItmname.Text = ""
        If CmbxStokGrup.SelectedIndex >= 1 Then
            CmbxStokGrup.SelectedValue = 0
            CmbxStokGrup.SelectedIndex = -1
        End If
        txtsno.Text = ""
        If cmbxunit.SelectedIndex >= 1 Then
            cmbxunit.SelectedValue = 0
            cmbxunit.SelectedIndex = -1
        End If
        txtopnstok.Text = ""
        txtrate.Text = ""
        txtval.Text = ""
        Txtitmremrk.Text = ""
        txtreordr.Text = ""
        Txtmax.Text = ""
        PicItm.Image = Nothing
        CmbxSelItm.DataSource = Nothing
        BomLstVew.Items.Clear()
        If cmbxexcise.SelectedIndex >= 1 Then
            cmbxexcise.SelectedValue = 0
            cmbxexcise.SelectedIndex = -1
        End If

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
            If Trim(Txtitmconversn.Text) <> "" Then
                insertcom.Parameters.AddWithValue("@itmwtetc", Me.Txtitmconversn.Text)
            Else
                insertcom.Parameters.AddWithValue("@itmwtetc", 0)
            End If

            If rBSaleOnly.Checked = True Then
                insertcom.Parameters.AddWithValue("@itmratechek", 0)
                insertcom.Parameters.AddWithValue("@itmsalerate", lblAval.Text)
            Else
                insertcom.Parameters.AddWithValue("@itmratechek", lblAval.Text)
                insertcom.Parameters.AddWithValue("@itmsalerate", 0)
            End If


            insertcom.Parameters.AddWithValue("@itmreorder", txtreordr.Text)
            insertcom.Parameters.AddWithValue("@itmmax", Txtmax.Text)
            If Trim(txtopnstok.Text) <> "" Then
                insertcom.Parameters.AddWithValue("@itmopnqnty", txtopnstok.Text)
            Else
                insertcom.Parameters.AddWithValue("@itmopnqnty", 0)
            End If

            If Trim(txtrate.Text) <> "" Then
                insertcom.Parameters.AddWithValue("@itmopnrate", txtrate.Text)
            Else
                insertcom.Parameters.AddWithValue("@itmopnrate", 0) ' CDbl(txtrate.Text))
            End If
            insertcom.Parameters.AddWithValue("@itmht", Cmbxht.SelectedValue)
            insertcom.Parameters.AddWithValue("@itmwdth", Cmbxwdth.SelectedValue)
            insertcom.Parameters.AddWithValue("@itmlnth", CmbxLnth.SelectedValue)
            insertcom.Parameters.AddWithValue("@itmgrad", Cmbxgrad.SelectedValue)
            insertcom.Parameters.AddWithValue("@itmmatrl", CmbxMatrl.SelectedValue)
            insertcom.Parameters.AddWithValue("@itmloc", Cmbxloc.SelectedValue)
            If Trim(txtval.Text) <> "" Then
                insertcom.Parameters.AddWithValue("@itmopnval", (txtval.Text))
            Else
                insertcom.Parameters.AddWithValue("@itmopnval", 0)
            End If

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
            ''If Trim(ImageName) <> "" Then
            ''    Dim img As String = Searchstr_Getafilename(ImageName)
            ''    ImagePath = Application.StartupPath & "\ItemImages\" & img
            ''    Fso = CreateObject("Scripting.FileSystemObject")
            ''    Fso.CopyFile(ImageName, ImagePath, True)
            ''    insertcom.Parameters.AddWithValue("@itmipath", ImagePath)
            ''Else
            ''    insertcom.Parameters.AddWithValue("@itmipath", "None")
            ''End If

            insertcom.Parameters.AddWithValue("@itmremrk", Trim(Txtitmremrk.Text))
            Dim TypeofItem As String = ""
            If rBSaleOnly.Checked = True Then
                TypeofItem = "Sale"
            ElseIf rBPurchaseOnly.Checked = True Then
                TypeofItem = "Production"
            ElseIf rbSpBoth.Checked = True Then
                TypeofItem = "Both"
            End If
            insertcom.Parameters.AddWithValue("@itmtype", Trim(TypeofItem))
            insertcom.Parameters.AddWithValue("@itmtype1", Trim("BomItem"))
            insertcom.Parameters.AddWithValue("@itmconcrnid", 1)
            insertcom.Parameters.AddWithValue("@itmadusrid", Current_UsrId)
            insertcom.Parameters.AddWithValue("@itmaddt", Now)
            insertcom.Parameters.AddWithValue("@itmdelstatus", DelStatus)
            insertcom.Parameters.AddWithValue("@itmInrbox", 0) 'Me.txtboxpcs.Text)
            If Len(Me.TxtMPack.Text) = 0 Then
                insertcom.Parameters.AddWithValue("@itmOtrbox", CInt(0))
            Else
                insertcom.Parameters.AddWithValue("@itmOtrbox", CInt(Me.TxtMPack.Text))
            End If


            insertcom.ExecuteNonQuery()
            save_Bomitems()
            MessageBox.Show("Current Record Has Been Saved", "Current Item Saved! ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clrflds()
            Me.Panel1.Enabled = True
            Me.Panel1.Visible = True
            Me.Panel2.Visible = False
            Me.Panel2.Enabled = False
            Me.stitsave.Text = "&Next"
            Me.stitsave.Location = New System.Drawing.Point(7, 406)
            Me.stitfind.Visible = True
            Me.stitfind.Text = "&Find"
            Me.Width = 851

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


    Private Sub stitsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stitsave.Click
        Try
            If stitsave.Text = "&Next" Then
                chkblan_val()
                If indx <> 0 Then
                    indx = 0
                    Exit Sub
                Else
                    Me.Panel1.Enabled = False
                    Me.Panel1.Visible = False
                    Me.SplitContainer1.Panel2.AutoScroll = True
                    Me.Height = 592
                    Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 50
                    Me.Panel2.Top = 2
                    Me.Panel2.Left = 0
                    Me.Panel2.Height = Me.Height - (0 + 55)
                    Me.Panel2.Width = Me.Panel1.Width + 379
                    Me.Panel2.Visible = True
                    Me.Panel2.Enabled = True
                    Me.TableLayoutPanel6.Visible = True
                    Me.TableLayoutPanel6.Enabled = True
                    Me.Panel2.Controls.Add(Me.TableLayoutPanel6)
                    Me.TableLayoutPanel6.Left = 475
                    Me.TableLayoutPanel6.Width = 400
                    Me.stitsave.Text = "&Save"
                    Me.stitsave.Location = New System.Drawing.Point(7, 406)
                    Me.stitfind.Visible = True
                    Me.stitfind.Text = "&Back"
                    Me.BomLstVew.Size = New System.Drawing.Point(461, Me.Panel2.Height - 167) ' 192) '(Me.SplitContainer1.Panel2.Width - 10, 192) ' Me.Panel2.Height / 2) '- 105)
                    Me.Text = "Bill Of Material Master" & "   " & "  Current User Name :- " & " " & Current_UsrId & "   Current Item Name:-  " & Trim(Me.TxtItmname.Text).ToUpper
                    Me.Txtcod1.Focus()
                    Me.Txtcod1.SelectAll()
                    SelIndex = True

                End If
            ElseIf stitsave.Text = "&Save" Then
                chkblan_val()
                If indx <> 0 Then
                    indx = 0
                    Exit Sub
                Else
                    Dim lstCont As Integer = Me.lstbxprocs1.Items.Count
                    If Not lstCont >= 2 Then '++ make sure that there are atleat two process selected. 
                        MsgBox("No of Processes should be atleast '2'" & Chr(13) & "For Example... " & Chr(13) & "(1)..Material Requirement Check/Item(s) Issue From Store" & Chr(13) & "(2).. Process in which current item to be produce.", MsgBoxStyle.Information, "MRP....")
                        Exit Sub
                    End If

                    If Not BomLstVew.Items.Count > 0 Then '++ Make sure that atleat one item attached to current BoM
                        MsgBox("Invalid input! One or more items should be attached to a BOM", MsgBoxStyle.Critical, "Items are required")
                        Exit Sub
                    End If

                    If Me.Lstvewitmsel.Items.Count > 0 Then '++ Make sure that first process have atleat one record.
                        Dim ChkItm As String = Trim(Me.lstbxprocs1.Items(0).SubItems(1).Text)
                        Dim xItm As Integer = 0
                        Dim Flag1 As Boolean = False
                        For xItm = 0 To Me.Lstvewitmsel.Items.Count - 1
                            If Trim(ChkItm) = Trim(Me.Lstvewitmsel.Items(xItm).Group.Name) Then
                                Flag1 = True
                                Exit For
                            End If
                        Next
                        If Flag1 = False Then
                            MsgBox("First Process should have atleat one item in movement schema", MsgBoxStyle.Critical, "Invalid movement schema!!")
                            Exit Sub
                        End If

                    End If
                    stkitminsert()
                    Me.Lstbxprocs.Items.Clear()
                    Fill_lstbx()
                    Me.lstbxprocs1.Items.Clear()
                    Me.Lstvewitmsel.Items.Clear()
                    Me.Lstvewitmsel.Groups.Clear()
                    Me.SplitContainer1.Panel2.AutoScroll = False
                    Txtcode.Focus()
                    Txtcode.SelectAll()
                End If

            ElseIf stitsave.Text = "&Edit" Then
                If Me.ItmDg.SelectedRows.Count = 1 Then
                    BomId_for_Alter = Me.ItmDg.SelectedRows(0).Cells(0).Value
                    Dim FrmAltr As New FrmAlterSelectedBOM
                    FrmAltr.ShowInTaskbar = False
                    FrmAltr.ShowDialog()
                Else
                    MsgBox("System could not find any selected item.", MsgBoxStyle.Critical, "Select an Item")
                End If

            End If
        Catch ex As Exception

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

    Private Sub txtopnstok_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtopnstok.Leave
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

    End Sub

    Private Sub stitfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stitfind.Click
        Try
            If stitfind.Text = "&Find" Then
                Panel1.Visible = False
                Panel2.Visible = False
                Panel3.Visible = False
                Me.TableLayoutPanel6.Visible = False
                Me.TableLayoutPanel6.Enabled = False
                Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 20
                Me.SplitContainer1.SplitterDistance = 175
                Me.SplitContainer1.IsSplitterFixed = True
                Create_fill_ItmDg()
                stitsave.Text = "&Edit"
                stitfind.Text = "&Delete"
            ElseIf stitfind.Text = "&Back" Then
                Me.Panel1.Enabled = True
                Me.Panel1.Visible = True
                Me.Panel2.Visible = False
                Me.Panel2.Enabled = False
                Inr_Flag = False
                Otr_Flag = False
                Me.SplitContainer1.Panel2.AutoScroll = False
                Me.Height = 592
                Me.Width = 851
                If Chk_Exisit2("finactitmmstr", "itmid", "itmtype1", "BomItem") = True Then
                    Me.stitfind.Visible = True
                    Me.stitsave.Location = New System.Drawing.Point(7, 406)
                    Me.stitsave.Text = "&Next"
                    Me.stitfind.Text = "&Find"
                Else
                    Me.stitfind.Visible = False
                    Me.stitsave.Location = New System.Drawing.Point(7, 443)
                    Me.stitsave.Text = "&Next"
                End If

            ElseIf stitfind.Text = "&Delete" Then
                If MessageBox.Show("Are you sure to delete?", "Item Deleting!!!", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                'MsgBox("System found the current item has some relationship with other table(s), so you can't delete this record", MsgBoxStyle.Critical, "Record has relationship")
                'Exit Sub
                Try
                    If ItmDg.SelectedRows.Count > 0 Then
                        Dim i As Integer = 0
                        For i = 0 To ItmDg.SelectedRows.Count - 1
                            itmnamcom = New SqlCommand("Finact_ItmMstr_BomMstr_SqlMstr_Items_Delete", FinActConn)
                            itmnamcom.CommandType = CommandType.StoredProcedure
                            itmnamcom.Parameters.AddWithValue("@Selitmid", Me.ItmDg.SelectedRows(i).Cells(0).Value)
                            CurrentItmid = Me.ItmDg.SelectedRows.Item(0).Cells(0).Value
                            If deletbomitem() = False Then Exit Sub
                            itmnamcom.ExecuteNonQuery()
                        Next
                        MsgBox("Current record has been successfully  deleted ", MsgBoxStyle.Information)
                        Create_fill_ItmDg()
                    Else
                        MsgBox("System could not found any selected item to delete, Make it sure atleast one item should be selected.", MsgBoxStyle.Information, Me.Text)
                    End If

                Catch ex1 As Exception

                    MessageBox.Show(ex1.Message)

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
    Private Function deletbomitem() As Boolean
        Try
            delstcom = New SqlCommand("delete from finact_bommstr where bomconcrnid=@bomid", FinActConn2)
            delstcom.Parameters.AddWithValue("@bomid", CurrentItmid)
            delstcom.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            delstcom.Dispose()
        End Try


    End Function
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
            Panel3.Visible = True
            Me.SplitContainer1.SplitterDistance = 173
            Me.SplitContainer1.IsSplitterFixed = False
            Me.Width = 851
            stitsave.Text = "&Next"
            stitfind.Text = "&Find"
            ' Else
            clrflds()
            Me.Txtcode.Focus()
        End If
    End Sub


    Private Sub CmbxStokGrup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.GotFocus
        'CmbxStokGrup.DroppedDown = True
        If FrmShow_flag(2) = True Then
            CmbxStokGrup.Items.Clear()
            fill_Cmbxundrgrup()
            Dim CmbxIndx As Integer = CmbxStokGrup.FindStringExact(StrUndrgrup, 0)
            CmbxStokGrup.SelectedIndex = CmbxIndx
        Else
            If Me.CmbxStokGrup.Items.Count > 0 Then
                If Me.CmbxStokGrup.SelectedIndex = -1 Then
                    Me.CmbxStokGrup.SelectedIndex = 0
                End If
            End If

        End If

    End Sub
    Private Sub AllCombox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.GotFocus, Cmbxgrad.GotFocus, Cmbxht.GotFocus, CmbxLnth.GotFocus, Cmbxloc.GotFocus, CmbxMatrl.GotFocus, CmbxSelItm.GotFocus, Cmbxstatus.GotFocus, CmbxStokGrup.GotFocus, cmbxunit.GotFocus, Cmbxwdth.GotFocus
        Try
            Dim Cmbx As ComboBox = Nothing
            Cmbx = CType(sender, ComboBox)

            Cmbx.DroppedDown = True
        Catch ex As Exception

        End Try

    End Sub




    Private Sub txtreordr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtreordr.Leave
        If Trim(txtreordr.Text) <> "" Then
            If IsNumeric(txtreordr.Text) = False Or Trim(txtreordr.Text.EndsWith("-")) = True Or Trim(txtreordr.Text.StartsWith("-")) = True Then
                txtreordr.Focus()
                txtreordr.SelectAll()
                LblAlrt1.Visible = True
            Else
                LblAlrt1.Visible = False
            End If
        Else
            LblAlrt1.Visible = False
        End If


    End Sub

    Private Sub cmbxexcise_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxexcise.GotFocus
        If cmbxexcise.Items.Count > 0 Then
            If cmbxexcise.SelectedIndex = -1 Then
                cmbxexcise.SelectedIndex = 1
            End If
        End If
    End Sub


    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Panel2.KeyDown, txtrate.KeyDown, txtsno.KeyDown, txtsno.KeyDown, txtopnstok.KeyDown, txtval.KeyDown, Panel2.KeyDown, Label9.KeyDown, LblAlrt1.KeyDown, Label10.KeyDown, Label12.KeyDown, Label2.KeyDown, cmbxexcise.KeyDown, Label3.KeyDown, Label5.KeyDown, Label7.KeyDown, Label8.KeyDown, Label9.KeyDown, labelsn.KeyDown, CmbxStokGrup.KeyDown, cmbxunit.KeyDown, Label1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            Exit Sub
        End If

    End Sub
    Private Sub CmbxStokGrup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxStokGrup.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxStokGrup_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ALLkeydownEnter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtrate.KeyDown, Txtcode.KeyDown, TxtItmname.KeyDown, txtsno.KeyDown, txtopnstok.KeyDown, txtval.KeyDown, txtqnty.KeyDown, txtboxpcs.KeyDown, Txtitmremrk.KeyDown, Txtmax.KeyDown, txtper.KeyDown, txtreordr.KeyDown, RbBom.KeyDown, Rbboth.KeyDown, Rbraw.KeyDown, cmbxunit.KeyDown, Cmbxgrad.KeyDown, Cmbxht.KeyDown, CmbxLnth.KeyDown, Cmbxloc.KeyDown, CmbxMatrl.KeyDown, Cmbxstatus.KeyDown, Cmbxwdth.KeyDown, cmbxexcise.KeyDown, Panel5.KeyDown, Panel6.KeyDown, Panel7.KeyDown, Txtcod1.KeyDown, TxtMPack.KeyDown, TxtboxCost.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Cmbxht_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxht.GotFocus
        If FrmShow_flag(2) = True Then
            Fill_Combobox_WitoutDelStatus("itmhtid", "itmhtin", "finact_itmhgtmstr", Cmbxht)
            Dim Indxht As Integer = Cmbxht.FindString(IntHtCmMm(2), 0)
            Cmbxht.SelectedIndex = Indxht
        Else
            If Cmbxht.SelectedIndex = -1 Then
                Cmbxht.SelectedIndex = 0
                Dim Xitmid As Integer = 0
                Chk_Exisit2("finact_itmhgtmstr", "itmhttype", "itmhtid", Xitmid)
                Label6.Text = ""
                Label6.Text = xStr2.ToString
            End If

        End If


    End Sub

    Private Sub Cmbxht_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxht.Leave
        If FrmShow_flag(2) = True Then
            FrmShow_flag(2) = False
            'Cmbxwdth.Focus()
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
        If FrmShow_flag(2) = True Then
            Fill_Combobox_WitoutDelStatus("itmwdthid", "itmwdthin", "finact_itmwdthmstr", Cmbxwdth)
            Dim Indxht As Integer = Cmbxwdth.FindString(IntHtCmMm(2), 0)
            Cmbxwdth.SelectedIndex = Indxht
        Else
            If Cmbxwdth.SelectedIndex = -1 Then
                Cmbxwdth.SelectedIndex = 0
                Dim Xitmid As Integer = 0
                Chk_Exisit2("finact_itmwdthmstr", "itmwdthtype", "itmwdthid", Xitmid)
                Label19.Text = ""
                Label19.Text = xStr2.ToString
            End If

        End If

    End Sub

    Private Sub Cmbxwdth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxwdth.Leave
        If FrmShow_flag(2) = True Then
            FrmShow_flag(2) = False
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

        If FrmShow_flag(2) = True Then
            Fill_Combobox_WitoutDelStatus("itmlnthid", "itmlnthin", "finact_itmlnthmstr", CmbxLnth)
            Dim Indxht As Integer = CmbxLnth.FindString(IntHtCmMm(2), 0)
            CmbxLnth.SelectedIndex = Indxht
        Else
            If CmbxLnth.SelectedIndex = -1 Then
                CmbxLnth.SelectedIndex = 0
                Dim Xitmid As Integer = 0
                Chk_Exisit2("finact_itmlnthmstr", "itmhttype", "itmlnthid", Xitmid)
                Label20.Text = ""
                Label20.Text = xStr2.ToString

            End If

        End If

    End Sub

    Private Sub CmbxLnth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxLnth.Leave
        If FrmShow_flag(2) = True Then
            FrmShow_flag(2) = False
            'Cmbxgrad.Focus()
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

        If FrmShow_flag(2) = True Then
            Fill_Combobox_WitoutDelStatus("itmgradid", "itmgradname", "finact_itmgradmstr", Cmbxgrad)
            Dim Indxht As Integer = Cmbxgrad.FindString(IntHtCmMm(2), 0)
            Cmbxgrad.SelectedIndex = Indxht
        Else
            If Cmbxgrad.Items.Count > 0 And Cmbxgrad.SelectedIndex = -1 Then
                Cmbxgrad.SelectedIndex = 0
            End If

        End If

    End Sub


    Private Sub CmbxMatrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxMatrl.GotFocus
        If FrmShow_flag(2) = True Then
            Fill_Combobox_WitoutDelStatus("itmgradid", "itmmatrlname", "finact_itmmatrlmstr", CmbxMatrl)
            Dim Indxht As Integer = CmbxMatrl.FindString(IntHtCmMm(2), 0)
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
            Me.ItmDg.ReadOnly = True
            ItmDg.Size = New Drawing.Size(Me.Width - Me.SplitContainer1.SplitterDistance - 10, Me.Height - (0 + 50))
            ItmDg.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            ItmDg.ForeColor = Color.Navy
            ItmDg.Columns.Add("iid", "Id")
            ItmDg.Columns.Add("itmd", "BOM Details")
            ItmDg.Columns.Add("icode", "Code")
            ItmDg.Columns.Add("in", "Name Of The Item")
            ItmDg.Columns(2).DefaultCellStyle.BackColor = Color.LightGray
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
            ItmDg.Columns(21).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(20).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(25).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(26).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(27).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(28).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(29).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(30).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(31).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(32).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(30).Width = 250
            ItmDg.Columns(32).Width = 250
            ItmDg.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(12).Visible = False
            ItmDg.Columns(13).Visible = False
            ItmDg.Columns(14).Visible = False
            ItmDg.Columns(15).Visible = False
            ItmDg.Columns(16).Visible = False
            ItmDg.Columns(22).Visible = False
            ItmDg.Columns(23).Visible = False
            ItmDg.Columns(24).Visible = False
            ItmDg.Columns(26).Visible = False
            ItmDg.Columns(27).Visible = False
            ItmDg.Columns(28).Visible = False
            ItmDg.Columns(6).DisplayIndex = 5
            ItmDg.Columns(10).DisplayIndex = 6
            ItmDg.Columns(11).DisplayIndex = 7
            ItmDg.Columns(18).DisplayIndex = 8
            ItmDg.Columns(19).DisplayIndex = 9
            ItmDg.Columns(3).Width = 300
            ItmDg.Columns(4).Width = 150
            ItmDg.Columns(5).Width = 50
            ItmDg.Columns(6).Width = 70
            ItmDg.Columns(7).Width = 70
            ItmDg.Columns(8).Width = 70

            ItmDg.ColumnHeadersHeight = 60
            ItmDg.RowTemplate.Height = 30
            ItmDg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            ItmDg.BorderStyle = BorderStyle.FixedSingle
            ItmDg.BackgroundColor = Color.Snow
            Me.SplitContainer1.Panel2.Controls.Add(ItmDg)
            ItmDg.Visible = True
            ItmDg.Left = 0
            ItmDg.Top = 2
            ItmDg.Columns(0).Visible = False
            ItmDg.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red

            Dim pn1(0), pv1(0) As String ''Arrays for procedure argu name n value
            Dim pn11(2), pv11(2) As String ''Arrays for procedure argu name n value
            Dim BomType As String = ""
            If Me.rBPurchaseOnly.Checked = True Then
                BomType = "Production"
            ElseIf Me.rBSaleOnly.Checked = True Then
                BomType = "Sale"
            ElseIf Me.rbSpBoth.Checked = True Then
                BomType = "Both"
            End If
            pn11(0) = "@ta"
            pn11(1) = "@id"
            pn11(2) = "@idval"

            pv11(0) = "FinactItmmstr"
            pv11(1) = "itmtype"
            pv11(2) = BomType '"BomItem"

            sql.get_data("select_where_like_selective_Bom", pn11, pv11, "ItmMaster") ' "ItmMaster" stands for ItemMaster


            Dim mk As Integer
            For mk = 0 To sql.ds.Tables("ItmMaster").Rows.Count - 1
                Itmdgr = New DataGridViewRow()
                'for fetching id
                Itmcel = New DataGridViewTextBoxCell()
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(0).ToString()
                Itmdgr.Cells.Add(Itmcel)

                'add button for bom details
                ItmBtn = New DataGridViewButtonCell
                ItmBtn.Value = "Attached Items"
                Itmdgr.Cells.Add(ItmBtn)

                ' for fetching code
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(1).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(2).ReadOnly = True


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
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finactcscmstr"
                pv11(1) = "cscid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(17).ToString()
                If Val(pv11(2)) > 0 Then
                    sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                    Itmcel.Value = (sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
                    sql1.ds.Tables("IM").Dispose()
                    Itmdgr.Cells.Add(Itmcel)
                End If


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
                Itmcel.Value = 0 ' Itmdgr.Cells(6).Value
                Itmdgr.Cells.Add(Itmcel)
                'Itmdgr.Cells(20).ReadOnly = True


                'for fetching stockvalue
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(19).ToString(), 2)
                Itmdgr.Cells.Add(Itmcel)
                ' Itmdgr.Cells(21).ReadOnly = True


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
                Itmcel.ToolTipText = "Clik Me to Load new Image"
                Itmdgr.Cells.Add(Itmcel)
                'Itmdgr.Cells(23).ReadOnly = True

                ' for fetching item remarks
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(24).ToString()
                Itmdgr.Cells.Add(Itmcel)



                ' for fetching item type
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(25).ToString()
                Itmdgr.Cells.Add(Itmcel)
                ' Itmdgr.Cells(25).ReadOnly = True

                ' for fetching item nature
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(26).ToString()
                Itmdgr.Cells.Add(Itmcel)
                'Itmdgr.Cells(26).ReadOnly = True

                ' for fetching item concern id
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(27).ToString()
                Itmdgr.Cells.Add(Itmcel)
                'Itmdgr.Cells(27).ReadOnly = True

                'for fetching add user
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(28).ToString()
                Itmdgr.Cells.Add(Itmcel)
                'Itmdgr.Cells(28).ReadOnly = True


                'for fetching add date
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(29).ToString()
                Itmdgr.Cells.Add(Itmcel)
                'Itmdgr.Cells(29).ReadOnly = True


                'for fetching edit user
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(30).ToString()
                Itmdgr.Cells.Add(Itmcel)
                ' Itmdgr.Cells(30).ReadOnly = True

                'for fetching edit date
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(31).ToString()
                Itmdgr.Cells.Add(Itmcel)
                'Itmdgr.Cells(31).ReadOnly = True
                'Itmdgr.Cells(32).ReadOnly = True


                'for fetching Inner Box pack
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(35).ToString(), 0)
                Itmdgr.Cells.Add(Itmcel)
                'for fetching Outer Box pack
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(36).ToString(), 0)
                Itmdgr.Cells.Add(Itmcel)

                ItmDg.Rows.Add(Itmdgr)

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sql.cnn.Close()
            sql.ds.Dispose()
            Me.ItmDg.AllowUserToAddRows = False
        End Try
    End Sub

    Private Sub Btnundrgrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnundrgrp.Click
        Dim frmUg As New FrmStokgrup
        frmUg.ShowInTaskbar = False
        FrmShow_flag(2) = True
        frmUg.ShowDialog()
    End Sub

    Private Sub Btnundrgrp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnundrgrp.GotFocus
        If FrmShow_flag(2) = True Then
            Me.CmbxStokGrup.Focus()
        End If
    End Sub

    Private Sub CmbxStokGrup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxStokGrup) = True Then
                txtsno.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnht_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnht.Click
        Dim frmht As New FrmHghtMstr
        frmht.ShowInTaskbar = False
        FrmShow_flag(2) = True
        frmht.ShowDialog()

    End Sub


    Private Sub Btnht_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnht.GotFocus
        If FrmShow_flag(2) = True Then
            Cmbxht.Focus()
        End If
    End Sub

    Private Sub Btnwdth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnwdth.Click
        Dim frmwdth As New FrmWdthMstr
        frmwdth.ShowInTaskbar = False
        FrmShow_flag(2) = True
        frmwdth.ShowDialog()
    End Sub

    Private Sub Btnwdth_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnwdth.GotFocus
        If FrmShow_flag(2) = True Then
            Cmbxwdth.Focus()
        End If
    End Sub

    Private Sub btnlnth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlnth.Click
        Dim frmlnth As New FrmLnthMstr
        frmlnth.ShowInTaskbar = False
        FrmShow_flag(2) = True
        frmlnth.ShowDialog()
    End Sub

    Private Sub btnlnth_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlnth.GotFocus
        If FrmShow_flag(2) = True Then
            CmbxLnth.Focus()
        End If
    End Sub

    Private Sub Btnmatrl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnmatrl.Click
        Dim frmmatrl As New FrmMatrlMstr
        frmmatrl.ShowInTaskbar = False
        FrmShow_flag(2) = True
        frmmatrl.ShowDialog()
    End Sub

    Private Sub Btnmatrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnmatrl.GotFocus
        If FrmShow_flag(2) = True Then
            CmbxMatrl.Focus()
        End If
    End Sub

    Private Sub Btngrad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btngrad.Click
        Dim frmgrad As New FrmGradMstr
        frmgrad.ShowInTaskbar = False
        FrmShow_flag(2) = True
        frmgrad.ShowDialog()
    End Sub

    Private Sub Btngrad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btngrad.GotFocus
        If FrmShow_flag(2) = True Then
            Cmbxgrad.Focus()
        End If
    End Sub

    Private Sub Cmbxgrad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxgrad.Leave
        If FrmShow_flag(2) = True Then
            FrmShow_flag(2) = False
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
        ''If OpnFDlog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        ''    ImageName = OpnFDlog1.FileName
        ''    PicItm.Image = Image.FromFile(ImageName)
        ''    Txtitmremrk.Focus()
        ''    Txtitmremrk.SelectAll()
        ''Else
        ''    ImageName = ""
        ''    Txtitmremrk.Focus()
        ''    Txtitmremrk.SelectAll()
        ''End If
    End Sub



    Private Sub Txtmax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtmax.Leave
        Try
            If Trim(Txtmax.Text) <> "" Then
                If IsNumeric(Txtmax.Text) = False Or Trim(Txtmax.Text.EndsWith("-")) = True Or Trim(Txtmax.Text.StartsWith("-")) = True Then
                    Txtmax.Focus()
                    Txtmax.SelectAll()
                    LblAlrt1.Visible = True
                Else
                    LblAlrt1.Visible = False
                    Dim Mval As Double = FormatNumber(Txtmax.Text, 2)
                    Dim Rval As Double = FormatNumber(txtreordr.Text, 2)

                    If Mval < Rval Then
                        MsgBox("Invalid input, Maximum Quantity should be greater than Minimum Quantity", MsgBoxStyle.Critical, "Input Greater")
                        Txtmax.Focus()
                        Txtmax.SelectAll()
                    End If
                End If
            Else
                LblAlrt1.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub setcontrols()
        If rBSaleOnly.Checked = True Or rbSpBoth.Checked = True Then
            Me.Cmbxstatus.Text = "Non-Consumable"
            Me.Cmbxstatus.Enabled = False
        ElseIf rBPurchaseOnly.Checked = True Then
            ' Me.Cmbxstatus.Enabled = True
            Me.Cmbxstatus.Text = "Non-Consumable"
            Me.Cmbxstatus.Enabled = False
        End If
        Txtcode.Focus()
        Txtcode.SelectAll()
    End Sub

    Private Sub Txtcode_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtcode.KeyDown
        'Try
        '    If e.KeyCode = Keys.Enter Then
        '        Me.Txtcode.SelectNextControl(CType(sender, Control), False, True, True, True)
        '        Me.TxtItmname.Focus()
        '        Me.TxtItmname.SelectAll()

        '    End If

        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub Txtcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcode.Leave
        Try

            If Trim(Txtcode.Text) <> "" Then

                Chk_Exisit("Finactitmmstr", "ItmCode", Trim(Me.Txtcode.Text))
                Dim xCod As String = xStr1
                If Trim(xCod) = Trim(Me.Txtcode.Text) Then
                    Me.Txtcode.BackColor = Color.Cyan
                    Me.Txtcode.Focus()
                    Me.Txtcode.SelectAll()
                    MsgBox("This Code is already existed. Try another value", MsgBoxStyle.Critical, "Duplicate Code")

                    Exit Sub
                End If
                Txtcode.BackColor = Color.White

            End If
            Me.lstvew1.Visible = False
            Me.lstvew1.Enabled = False
            Me.lstvew1.Height = 10
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcode.TextChanged
        Try
            If Len(Me.Txtcode.Text.Trim) > 0 Then
                Me.lstvew1.Height = 172
                Me.lstvew1.Location = New Point(364, 156)
                xFillLstVewWith2Recrd(Me.lstvew1, Me.Txtcode.Text.Trim, "Itmid", "Itmcode", "FinactitmMstr", "Itmcode")
            Else
                Me.lstvew1.Visible = False
                Me.lstvew1.Enabled = False
                Me.lstvew1.Height = 10
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rBSaleOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rBSaleOnly.CheckedChanged
        setcontrols()
    End Sub

    Private Sub rBPurchaseOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rBPurchaseOnly.CheckedChanged
        setcontrols()
    End Sub

    Private Sub rBTradingOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        setcontrols()
    End Sub

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        setcontrols()
    End Sub

    Private Sub Txtitmremrk_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        stitsave.Focus()
    End Sub

    Private Sub Cmbxloc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxloc.GotFocus
        If FrmShow_flag(2) = True Then
            Dim cond As String = "Inner"
            Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", Cmbxloc, cond, "CSCDELSTATUS", CInt(1))
            Dim Indxht As Integer = Cmbxloc.FindStringExact(IntHtCmMm(2), 0)
            Cmbxloc.SelectedIndex = Indxht
        Else
            If Cmbxloc.Items.Count > 0 And Cmbxloc.SelectedIndex = -1 Then
                Cmbxloc.SelectedIndex = 0
            End If
            If Trim(Cmbxloc.Text) <> "" Then
                fetchRecFromlocation()
            End If

        End If
        Me.Panel8.Location = New System.Drawing.Point(8, 175)
        Me.Panel8.Size = New System.Drawing.Point(160, 176)
        Me.Panel8.Visible = True
    End Sub

    Private Sub Btnloc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnloc.Click
        Dim frmiL As New FrmInLocat
        frmiL.ShowInTaskbar = False
        FrmShow_flag(2) = True
        frmiL.ShowDialog()
    End Sub

    Private Sub Btnloc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnloc.GotFocus
        If FrmShow_flag(2) = True Then
            Cmbxloc.Focus()
        End If

    End Sub

    Private Sub CmbxMatrl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxMatrl.Leave
        If FrmShow_flag(2) = True Then
            FrmShow_flag(2) = False

        End If
        If Trim(CmbxMatrl.Text) = "" Then
            CmbxMatrl.Text = "<None>"
        End If

    End Sub
    Private Sub Cmbxloc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxloc.Leave
        Try
            If FrmShow_flag(2) = True Then
                FrmShow_flag(2) = False
            End If
            If Trim(Cmbxloc.Text) = "" Then
                Cmbxloc.Text = "<None>"
            End If
            Me.Txtitmconversn.Focus()
            Me.Txtitmconversn.SelectAll()
        Catch ex As Exception
        Finally
            Me.Panel8.Visible = False

        End Try



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
                    lblloc.Text = st("cscstatename")
                    lblMainp.Text = st("csccontry")
                    lblsubp.Text = st("csccontry1")
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



    Private Sub set_Condition()
        If rBSaleOnly.Checked = True Then
            If Rbraw.Checked = True Then
                SelStrg = "Select itmid, itmname from finactitmmstr where ITMDELSTATUS=1 AND  itmtype in ('Sale','Trading') and itmtype1='RawItem' order by itmcode"
            ElseIf RbBom.Checked = True Then
                SelStrg = "Select itmid,itmname from finactitmmstr where ITMDELSTATUS=1 AND itmtype in ('Sale','Trading') and itmtype1='BomItem'order by itmname"
            ElseIf Rbboth.Checked = True Then
                SelStrg = "Select itmid, itmname from finactitmmstr where ITMDELSTATUS=1 AND itmtype in ('Sale','Trading','Production') and itmtype1 in('RawItem','BomItem')order by itmname"
            End If

        ElseIf rBPurchaseOnly.Checked = True Then
            If Rbraw.Checked = True Then
                SelStrg = "Select itmid, itmname from finactitmmstr where ITMDELSTATUS=1 AND itmtype in ('Purchase','Trading') and itmtype1='RawItem'order by itmname"
            ElseIf RbBom.Checked = True Then
                SelStrg = "Select itmid, itmname from finactitmmstr where ITMDELSTATUS=1 AND itmtype in ('Purchase','Trading') and itmtype1='BomItem'order by itmname"
            ElseIf Rbboth.Checked = True Then
                SelStrg = "Select itmid, itmname from finactitmmstr where ITMDELSTATUS=1 AND itmtype in ('Purchase','Trading','Production') and itmtype1 in('RawItem','BomItem')order by itmname"
            End If
        ElseIf rbSpBoth.Checked = True Then
            If Rbraw.Checked = True Then
                SelStrg = "Select itmid, itmname from finactitmmstr where ITMDELSTATUS=1 AND itmtype in ('Sale','Purchase','Trading') and itmtype1='RawItem'order by itmname"
            ElseIf RbBom.Checked = True Then
                SelStrg = "Select itmid, itmname from finactitmmstr where ITMDELSTATUS=1 AND itmtype in ('Sale','Purchase','Trading') and itmtype1='BomItem'order by itmname"
            ElseIf Rbboth.Checked = True Then
                SelStrg = "Select itmid, itmname from finactitmmstr where ITMDELSTATUS=1 AND itmtype in ('Sale','Purchase','Trading','Production') and itmtype1 in('RawItem','BomItem')order by itmname"
            End If
        End If
    End Sub

    Private Sub Txtitmremrk_Leave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtitmremrk.Leave
        stitsave.Focus()
    End Sub


    Private Sub SelRec_Itemmaster()
        Dim Ix As Boolean = True
        Try

            Try
                ItemId = CmbxSelItm.SelectedValue
            Catch ex As Exception
                Ix = False
                Exit Sub

            End Try


            stcom = New SqlCommand("select itmcode,itmname,itmcatid,itmunttype,itmratechek,itmsalerate,itmreorder,itmmax,itmtype from finactitmmstr where itmid='" & (ItemId) & "' ", FinActConn)
            st = stcom.ExecuteReader
            st.Read()
            If st.HasRows = True Then
                lblic.Text = Trim(st(8))
                lblin.Text = Trim(st(1))
                Dim Gid As Integer = st(2)
                grpidcom = New SqlCommand("select cogrupnam from finactstokgrupname where cogrpid='" & (Gid) & "'", FinActConn1)
                grpiddr = grpidcom.ExecuteReader
                grpiddr.Read()
                If grpiddr.HasRows = True Then
                    lblig.Text = Trim(grpiddr(0))
                End If
                grpidcom.Dispose()
                grpiddr.Close()
                ' Me.Panel10.Visible = True
                lblut.Text = Trim(st(3))
                lblpr.Text = FormatNumber(st(4), 2)
                lblsr.Text = FormatNumber(st(5), 2)
                lblrol.Text = FormatNumber(st(6), 3)
                lblmq.Text = FormatNumber(st(7), 3)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Ix = True Then
                stcom.Dispose()
                st.Close()
            End If

        End Try
    End Sub

    Private Sub Spl_Fill_Combobox(ByVal xSelstring As String, ByVal Xcombobx As ComboBox)
        Dim xStr As String = xSelstring
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            itmnamcom = New SqlCommand(xStr, FinActConn1)
            SqlAdptr = New SqlDataAdapter(itmnamcom)
            dtaset = New DataSet(itmnamcom.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = "itmid"
            Xcombobx.DisplayMember = "itmNAME"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            itmnamcom.Dispose()
            SqlAdptr.Dispose()
            SelIndex = True
        End Try
    End Sub

    Private Sub txtqnty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqnty.GotFocus
        txtqnty.SelectAll()
    End Sub

    Private Sub txtqnty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqnty.Leave
        If Trim(txtqnty.Text) <> "" Then
            If IsNumeric(txtqnty.Text) = False Or Trim(txtqnty.Text.EndsWith("-")) = True Or Trim(txtqnty.Text.StartsWith("-")) = True Then
                MsgBox("Invalid Input! Only numbers are allowed", MsgBoxStyle.Critical, "Enter number like 1,2,3...")
                txtqnty.Focus()
                txtqnty.SelectAll()
                Exit Sub
            Else
                If LstViewEdit_Flag = True Then
                    ' LstViewEdit_Flag = False
                Else
                    ' If MessageBox.Show("Are you sure to add this item", "Item adding to BOM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim qval As Double = txtqnty.Text
                    Dim rtio As Double = Me.txtboxpcs.Text
                    Dim rval As Double
                    'If rBSaleOnly.Checked = True Then
                    '    rval = lblsr.Text
                    'Else
                    If Len(Trim(Me.lblpr.Text)) = 0 Then Me.lblpr.Text = 0
                    rval = CDbl(lblpr.Text)
                    'End If
                    xrVal = rval
                    xratio = rtio
                    Me.TxtboxCost.Text = FormatNumber(qval * rval / rtio, 2)
                    Me.TxtboxCost.Focus()
                    Me.TxtboxCost.SelectAll()

                End If
            End If
        Else
            txtqnty.BackColor = Color.Cyan
        End If


    End Sub

    Private Function find_itemfromlstvew() As Boolean
        Try
            If BomLstVew.Items.Count > 0 Then
                Dim i As Integer = 0
                For i = 0 To BomLstVew.Items.Count - 1
                    If Trim(CmbxSelItm.Text.ToUpper) = Trim(BomLstVew.Items(i).SubItems(1).Text.ToUpper) Then
                        MsgBox("This item is already added to BOM", MsgBoxStyle.Critical, "Already entered")
                        Return True
                    Else

                    End If
                Next
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Sub find_item_Nos_Total()
        Try
            Me.lblnoitms.Text = ""
            Me.lblAval.Text = ""
            If BomLstVew.Items.Count > 0 Then
                Dim i As Integer = 0
                Dim Itm_Nos As Integer = 0
                Dim Itm_Valtotal As Double = 0
                For i = 0 To BomLstVew.Items.Count - 1
                    Itm_Valtotal += CDbl(BomLstVew.Items(i).SubItems(4).Text)
                Next
                lblnoitms.Text = i
                lblAval.Text = FormatNumber(Itm_Valtotal, 2)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub

    Private Sub save_Bomitems()
        Dim CurbomId As Integer
        Try
            Dim ix As Integer = 0
            Dim CurBomName As String = Trim(Me.TxtItmname.Text)
            CurbomId = FindcurrentId(CurBomName)
            If BomLstVew.Items.Count > 0 Then

                For ix = 0 To BomLstVew.Items.Count - 1
                    insertcom = New SqlCommand("finact_bommstr_insert", FinActConn)
                    insertcom.CommandType = CommandType.StoredProcedure
                    insertcom.Parameters.AddWithValue("@bomconcrnid", CurbomId)
                    insertcom.Parameters.AddWithValue("@bomconcrnitmid", BomLstVew.Items(ix).SubItems(6).Text)
                    insertcom.Parameters.AddWithValue("@bomitmqnty", BomLstVew.Items(ix).SubItems(2).Text)
                    insertcom.Parameters.AddWithValue("@bomitmrate", BomLstVew.Items(ix).SubItems(3).Text)
                    insertcom.Parameters.AddWithValue("@bomitmamt", BomLstVew.Items(ix).SubItems(4).Text)
                    insertcom.Parameters.AddWithValue("@bomitmPrcsGid", BomLstVew.Items(ix).SubItems(8).Text)
                    insertcom.Parameters.AddWithValue("@bomitmratio", BomLstVew.Items(ix).SubItems(9).Text)
                    insertcom.ExecuteNonQuery()
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        Finally
            insertcom.Dispose()
            Dim Ixx As Integer
            Try
                For Ixx = 0 To Me.lstbxprocs1.Items.Count - 1
                    insertcom = New SqlCommand("Finact_ProcesMoveSql_Insert", FinActConn)
                    insertcom.CommandType = CommandType.StoredProcedure
                    insertcom.Parameters.AddWithValue("@pmbomconid", CurbomId)
                    insertcom.Parameters.AddWithValue("@pmprcsconid", Me.lstbxprocs1.Items(Ixx).Text)
                    insertcom.Parameters.AddWithValue("@pmmoveno", Ixx)
                    insertcom.Parameters.AddWithValue("@pmadusrid", Current_UsrId)
                    insertcom.Parameters.AddWithValue("@pmaddt", Now)
                    insertcom.Parameters.AddWithValue("@pmdelstatus", 1)
                    insertcom.ExecuteNonQuery()
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Try

    End Sub

    Private Function FindcurrentId(ByVal Xname As String) As Integer
        Try
            Dim Curritmid As Integer = 0
            insertcom = New SqlCommand("select itmid from finactitmmstr where itmname=@name and itmtype1=@type1", FinActConn1)
            insertcom.Parameters.AddWithValue("@name", Trim(Xname))
            insertcom.Parameters.AddWithValue("@type1", Trim("BomItem"))
            insertdr = insertcom.ExecuteReader
            insertdr.Read()
            If insertdr.HasRows = True Then
                Curritmid = insertdr(0)
                Return Curritmid
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            insertdr.Close()
            insertcom.Dispose()
        End Try

    End Function
    Private Sub txtqnty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqnty.TextChanged
        Try
            txtqnty.BackColor = Color.White
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try

            Dim lst As ListViewItem


            lst = BomLstVew.FocusedItem


            If MessageBox.Show("Are you sure to delete this row", "Deleting Current row....", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            Else
                If BomLstVew.Items.Count > 0 Then
                    lst.Remove()
                    find_item_Nos_Total()
                    find_item_Nos_Total()
                Else
                    MsgBox("No record found for delete", MsgBoxStyle.Information, "Record Deleting")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            Dim lst As ListViewItem
            ' BomLstVew.LabelEdit = True
            lst = BomLstVew.FocusedItem

            If BomLstVew.Items.Count > 0 Then
                Li = lst.Index
                txtqnty.Text = CDbl(lst.SubItems(2).Text)
                Me.txtboxpcs.Text = lst.SubItems(9).Text
                xrVal = CDbl(lst.SubItems(3).Text)
                Me.TxtboxCost.Text = CDbl(lst.SubItems(4).Text)
                txtboxpcs.Focus()
                txtboxpcs.SelectAll()
                LstViewEdit_Flag = True
                GroupBox1.Enabled = False
                CmbxSelItm.Enabled = False

            Else
                MsgBox("No record found for edit", MsgBoxStyle.Information, "Record Editing....")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try



    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            CmbxSelItm.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnaditm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnaditm.Click
        Try
            Dim frmiLa As New FrmStokItm
            frmiLa.ShowInTaskbar = False
            FrmShow_flag(2) = True

            If rBSaleOnly.Checked = True Then
                Rbstatus(0) = 1 'Sales
            ElseIf rBPurchaseOnly.Checked = True Then
                Rbstatus(0) = 2 'Production
            End If
            frmiLa.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnaditm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnaditm.GotFocus
        Try
            If FrmShow_flag(2) = True Then
                CmbxSelItm.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtitmconversn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtitmconversn.Leave
        Try
            Me.Panel8.Location = New System.Drawing.Point(8, 121)
            Me.Panel8.Size = New System.Drawing.Point(160, 27)
            Me.Panel8.Visible = False
            txtopnstok.Focus()
            txtopnstok.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtitmconversn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtitmconversn.TextChanged
        Try
            If IsNumeric(Me.Txtitmconversn.Text) = False Then
                Me.Label18.Visible = True
                Me.LblAlrt1.Visible = True
                Me.Txtitmconversn.Focus()
                Me.Txtitmconversn.SelectAll()
                Exit Sub
            Else
                Me.Label18.Visible = False
                Me.LblAlrt1.Visible = False

            End If
            If Me.cmbxunit.SelectedIndex <> -1 Then
                ' If Trim(Me.cmbxunit.Text) = "Kg" Then
                Check_Minus_Dot_Kgformat(Txtitmconversn)
                'End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtboxpcs_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            tb.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtboxpcs_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Trim(Me.txtboxpcs.Text) <> "" Then
                If IsNumeric(Me.txtboxpcs.Text) = True Then
                    Me.txtboxpcs.Text = FormatNumber(Me.txtboxpcs.Text, 0)
                    Dim bval As Integer = Me.txtboxpcs.Text
                    If bval > 0 Then
                        Me.CmbxSelItm.Enabled = True
                        Me.Txtcod1.Enabled = True
                        Me.Txtcod1.Focus()
                    Else
                        Me.CmbxSelItm.Enabled = False
                        Me.Txtcod1.Enabled = False

                    End If

                    Me.Label18.Visible = False
                    Me.LblAlrt1.Visible = False
                Else
                    Me.txtboxpcs.Focus()
                    Me.txtboxpcs.SelectAll()
                    Me.Label18.Visible = True
                    Me.LblAlrt1.Visible = True
                End If
            Else
                Me.txtboxpcs.Text = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbSpBoth_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSpBoth.CheckedChanged
        Try
            setcontrols()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstbxprocs_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ' If Trim(Me.txtmovqnty.Text) = "" Or Me.txtmovqnty.Text = 0 Then Exit Sub
            If Me.Lstbxprocs.Items.Count > 0 Then
                If Me.Lstbxprocs.SelectedItems.Count = -1 Then

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Btnmove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnmove1.Click
        Dim itm As Integer
        Try
            If Me.Lstbxprocs.SelectedItems.Count = 1 Then
                itm = Me.Lstbxprocs.SelectedItems(0).Index
                Dim lstp2 As New ListViewItem
                lstp2.Text = Me.Lstbxprocs.SelectedItems(0).Text
                lstp2.SubItems.Add(Trim(Me.Lstbxprocs.SelectedItems(0).SubItems(1).Text))
                lstp2.SubItems.Add(Trim(""))
                Me.lstbxprocs1.Items.Add(lstp2)
                Me.Lstbxprocs.Items.RemoveAt(itm)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnMove2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMove2.Click
        Dim itm As Integer
        Try
            If Me.lstbxprocs1.SelectedItems.Count = 1 Then
                itm = Me.lstbxprocs1.SelectedItems(0).Index
                Dim ChkItm As String = Trim(Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text)
                Dim xItm As Integer = 0
                If Me.Lstvewitmsel.Items.Count > 0 Then
                    For xItm = 0 To Me.Lstvewitmsel.Items.Count - 1
                        If Trim(ChkItm) = Trim(Me.Lstvewitmsel.Items(xItm).Group.Name) Then Exit Sub

                    Next
                End If
                '  If Trim(Me.lstbxprocs1.SelectedItems(0).SubItems(2).Text) = "Fixed" Then Exit Sub
                Dim lstp3 As New ListViewItem
                lstp3.Text = Me.lstbxprocs1.SelectedItems(0).Text
                lstp3.SubItems.Add(Trim(Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text))
                Me.Lstbxprocs.Items.Add(lstp3)
                Me.lstbxprocs1.Items.RemoveAt(itm)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Btnmove3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnmove3.Click
        ' Dim itm As String = ""
        Try
            For Each itm As ListViewItem In Me.Lstbxprocs.Items
                Dim lstp5 As New ListViewItem
                lstp5.Text = itm.Text
                lstp5.SubItems.Add(Trim(itm.SubItems(1).Text))
                lstp5.SubItems.Add(Trim(""))
                Me.lstbxprocs1.Items.Add(lstp5)
                Me.Lstbxprocs.Items.RemoveAt(itm.Index)
            Next
            ' Me.Lstbxprocs.Items.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Btnmove4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnmove4.Click
        'Dim itm As String = ""
        Try
            For Each itm As ListViewItem In Me.lstbxprocs1.Items
                'itm = Me.lstbxprocs1.SelectedItems(0).Index
                Dim ChkItm As String = Trim(itm.SubItems(1).Text)
                Dim xItm As Integer = 0
                If Me.Lstvewitmsel.Items.Count > 0 Then
                    For xItm = 0 To Me.Lstvewitmsel.Items.Count - 1
                        If Trim(ChkItm) = Trim(Me.Lstvewitmsel.Items(xItm).Group.Name) Then Exit Sub

                    Next
                End If
                'If Trim(itm.SubItems(2).Text) = "Fixed" Then Exit Sub
                Dim lstp4 As New ListViewItem
                lstp4.Text = itm.Text
                lstp4.SubItems.Add(Trim(itm.SubItems(1).Text))
                Me.Lstbxprocs.Items.Add(lstp4)
                Me.lstbxprocs1.Items.RemoveAt(itm.Index)
            Next
            Me.lstbxprocs1.Items.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Fill_lstbx()
        Try
            Dim xStr As String = "Select process_id,Process_name from finact_processmstr  order by process_name"
            dtaset = New DataSet
            dtaset.Tables.Clear()

            MM_cmd = New SqlCommand(xStr, FinActConn1)
            SqlAdptr = New SqlDataAdapter(MM_cmd)
            dtaset = New DataSet(MM_cmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Dim xf As Integer = 0

            For xf = 0 To dtaset.Tables(0).Rows.Count - 1
                Dim lstpr As New ListViewItem
                lstpr.Text = dtaset.Tables(0).Rows(xf).ItemArray(0)
                lstpr.SubItems.Add(Trim(dtaset.Tables(0).Rows(xf).ItemArray(1).ToString()))
                Me.Lstbxprocs.Items.Add(lstpr)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd.Dispose()
            SqlAdptr.Dispose()
        End Try



    End Sub

    Private Sub btnSelItm1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelItm1.Click
        Try
            If Me.lstbxprocs1.SelectedItems.Count >= 1 Then
                If Me.BomLstVew.CheckedItems.Count > 0 Then
                    CreateOffLineTableItemMove()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnItmUnsel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnItmUnsel.Click
        Try
            If Me.Lstvewitmsel.Items.Count > 0 Then
                If Me.Lstvewitmsel.SelectedItems.Count > 0 Then
                    For Each SelItm As ListViewItem In Me.Lstvewitmsel.SelectedItems
                        Dim Idx1 As Integer = Me.Lstvewitmsel.SelectedItems(0).Index
                        For Each SelItm1 As ListViewItem In Me.BomLstVew.Items
                            If Trim(SelItm.SubItems(1).Text) = Trim(SelItm1.SubItems(0).Text) Then
                                SelItm1.ForeColor = Color.Black
                                SelItm1.BackColor = Color.White
                                SelItm1.SubItems(7).Text = Trim("NotAded")
                                SelItm1.SubItems(8).Text = Trim("")
                                SelItm1.Checked = False
                            End If
                        Next
                        Me.Lstvewitmsel.Items.RemoveAt(Idx1)

                    Next

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CreateOffLineTableItemMove()
        Try
            DynaRptDt = New DataTable("SetItemMove")
            DynaRptDt.Columns.Add("Item Name")
            DynaRptDt.Columns.Add("Item Id")
            DynaRptDt.Columns.Add("Quantity")
            DynaRptDt.Columns.Add("Item Group")
            DynaRptDt.Columns.Add("Item Group Id")

            DynaRptDt.Columns(1).Unique = True

            For Each itm As ListViewItem In Me.BomLstVew.CheckedItems
                If Trim(itm.SubItems(7).Text) <> "Aded" Then
                    DynaRptDtrow = DynaRptDt.NewRow
                    DynaRptDtrow(1) = itm.Text
                    DynaRptDtrow(0) = itm.SubItems(1).Text
                    DynaRptDtrow(2) = itm.SubItems(2).Text
                    Dim b As Integer = Me.lstbxprocs1.SelectedItems(0).Text
                    Dim bx As String = Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text
                    DynaRptDtrow(3) = Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text
                    DynaRptDtrow(4) = Me.lstbxprocs1.SelectedItems(0).Text
                    DynaRptDt.Rows.Add(DynaRptDtrow)
                    Dim idx As Integer = itm.Index
                    itm.SubItems(0).ForeColor = Color.DarkGray
                    itm.SubItems(0).BackColor = Color.LightCyan
                    itm.SubItems(7).Text = "Aded"
                    itm.SubItems(8).Text = b
                    Me.lstbxprocs1.SelectedItems(0).SubItems(2).Text = "Fixed"
                    Me.lstbxprocs1.SelectedItems(0).BackColor = Color.LightCyan
                End If
            Next
            Me.Lstvewitmsel.Groups.Add(Trim(Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text), Trim(Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text))
            Me.Lstvewitmsel.BeginUpdate()
            For Each ItmRow As DataRow In DynaRptDt.Rows
                Dim lstVitm As New ListViewItem
                lstVitm.Text = ItmRow(0).ToString
                lstVitm.SubItems.Add(ItmRow(1))
                lstVitm.SubItems.Add(ItmRow(2))
                Dim a As String = ItmRow(2)
                lstVitm.Group = Me.Lstvewitmsel.Groups(ItmRow(3))

                Lstvewitmsel.Items.Add(lstVitm)

            Next
            Me.Lstvewitmsel.EndUpdate()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub

    Private Sub BomLstVew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BomLstVew.Click

        Try
            Dim xI As Integer
            If Me.BomLstVew.CheckedItems.Count > 0 Then
                xI = (Me.BomLstVew.SelectedItems(0).Index)
                If Me.BomLstVew.Items(xI).SubItems(7).Text = "Aded" Then 'Or Me.BomLstVew.Items(xI).SubItems(9).Text >= 1 Then
                    Me.lstvewContextms.Enabled = False
                Else
                    Me.lstvewContextms.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BomLstVew_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles BomLstVew.ItemChecked
        Try
            If Me.BomLstVew.CheckedItems.Count > 0 Then
                If Trim(Me.BomLstVew.Items(e.Item.Index).SubItems(7).Text) = "Aded" Then
                    e.Item.Checked = 1
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub _Fill_Combobox_PACKMTRL(ByVal Xcombobx1 As ComboBox)
        Try
            Dim xStr As String = "Finact_ItemMaster_Only_PackingMaterial_Select"
            MM_Dset = New DataSet
            MM_Dset.Tables.Clear()

            MM_cmd = New SqlCommand(xStr, FinActConn1)
            MM_cmd.CommandType = CommandType.StoredProcedure
            MM_Adptr = New SqlDataAdapter(MM_cmd)
            MM_Dset = New DataSet(MM_cmd.CommandText)
            MM_Adptr.Fill(MM_Dset)
            Xcombobx1.DataSource = MM_Dset.Tables(0)
            Xcombobx1.ValueMember = "itmid"
            Xcombobx1.DisplayMember = "itmname"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd.Dispose()
            MM_Adptr.Dispose()
        End Try
    End Sub
    Private Sub _Fill_Combobox_PACKMTRL_WhereNotItmId(ByVal NotItmid As Integer, ByVal Xcombox2 As ComboBox)
        Try
            Dim xStr As String = "Finact_ItemMaster_Only_PackingMaterial_Select_Where_Not"
            MM_Dset = New DataSet
            MM_Dset.Tables.Clear()

            MM_cmd = New SqlCommand(xStr, FinActConn1)
            MM_cmd.CommandType = CommandType.StoredProcedure
            MM_cmd.Parameters.AddWithValue("@NotItmid", NotItmid)
            MM_Adptr = New SqlDataAdapter(MM_cmd)
            MM_Dset = New DataSet(MM_cmd.CommandText)
            MM_Adptr.Fill(MM_Dset)
            Xcombox2.DataSource = MM_Dset.Tables(0)
            Xcombox2.ValueMember = "itmid"
            Xcombox2.DisplayMember = "itmname"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd.Dispose()
            MM_Adptr.Dispose()
        End Try

    End Sub
    Private Function Select_ItmCodeOnly(ByVal ItmIdx As Integer) As String
        Dim xtr As Integer = 0
        Try
            Dim xStr As String = "Finact_ItemMaster_Only_PackingMaterial_Select_ItmCode"

            MM_cmd = New SqlCommand(xStr, FinActConn1)
            MM_cmd.CommandType = CommandType.StoredProcedure
            MM_cmd.Parameters.AddWithValue("@ItmIdx", Trim(ItmIdx))
            MM_rdr = MM_cmd.ExecuteReader
            While MM_rdr.Read
                If MM_rdr.IsDBNull(0) = False Then
                    xtr = MM_rdr(0)
                    Return MM_rdr(1)
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd.Dispose()
            MM_rdr.Close()
        End Try
        ' If xtr = 0 Then
        Return ""
        'End If
    End Function

    Private Function Select_ItmCode(ByVal xItmCode As String) As Integer
        Try
            Dim xStr As String = "Finact_ItemMaster_Only_PackingMaterial_Select_Code"
            MM_cmd = New SqlCommand(xStr, FinActConn1)
            MM_cmd.CommandType = CommandType.StoredProcedure
            MM_cmd.Parameters.AddWithValue("@ItmCode", Trim(xItmCode))
            MM_rdr = MM_cmd.ExecuteReader
            While MM_rdr.Read
                If MM_rdr.IsDBNull(0) = False Then
                    Return MM_rdr(0)
                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd.Dispose()
            MM_rdr.Close()
        End Try

    End Function
    Private Sub CmbxSelItm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSelItm.GotFocus
        Me.Label34.Visible = False
        If Not CmbxSelItm.Items.Count > 0 Then
            set_Condition()
            Spl_Fill_Combobox(SelStrg, CmbxSelItm)
        End If

        If FrmShow_flag(2) = True Then
            set_Condition()
            Spl_Fill_Combobox(SelStrg, CmbxSelItm)
            Dim Indxht As Integer = CmbxSelItm.FindStringExact(IntHtCmMm(2), 0)
            CmbxSelItm.SelectedIndex = Indxht
        End If

        If CmbxSelItm.Items.Count > 0 Then
            If CmbxSelItm.SelectedIndex = -1 Then
                CmbxSelItm.SelectedIndex = 0
            End If
        End If
        If SelIndex = True Then
            Me.Panel10.Visible = True
            Me.Panel8.Visible = False
            Me.Panel10.Location = New System.Drawing.Point(3, 80)
            Me.Panel10.Size = New System.Drawing.Point(169, 327)
            SelRec_Itemmaster()
        End If

    End Sub


    Private Sub BtnQntOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQntOk.Click
        Try
            If LstViewEdit_Flag = True Then
                LstViewEdit_Flag = False
                GroupBox1.Enabled = True
                CmbxSelItm.Enabled = True
                BomLstVew.Items(Li).SubItems(2).Text = FormatNumber(txtqnty.Text, 3)
                Dim qval As Double = BomLstVew.Items(Li).SubItems(2).Text
                Dim rval As Double = CDbl(Me.TxtboxCost.Text) / qval 'BomLstVew.Items(Li).SubItems(3).Text
                Dim rtio As Double = Me.txtboxpcs.Text
                BomLstVew.Items(Li).SubItems(3).Text = FormatNumber(rval, 2)
                BomLstVew.Items(Li).SubItems(4).Text = FormatNumber(qval * rval / rtio, 2)
                ' Me.TxtboxCost.Text = FormatNumber(qval * rval / rtio, 2)
                BomLstVew.Items(Li).SubItems(9).Text = rtio
                txtqnty.Text = ""
                Me.txtboxpcs.Text = 1
                find_item_Nos_Total()
                Me.TxtboxCost.Text = 0
                CmbxSelItm.Focus()
            Else
                If Not Me.txtqnty.Text > 0 Then Exit Sub
                If find_itemfromlstvew() = True Then
                    txtqnty.Text = ""
                    Me.TxtboxCost.Text = 0
                    CmbxSelItm.Focus()
                    Exit Sub
                End If
                Dim BomLV As ListViewItem
                BomLV = BomLstVew.Items.Add(Trim(Me.Txtcod1.Text)) 'CmbxSelItm.Text))
                BomLV.SubItems.Add(Trim(lblin.Text))
                Dim xQ As Double = FormatNumber(txtqnty.Text, 3)
                Dim xr As Double = CDbl(Me.TxtboxCost.Text)
                If Not xrVal > 0 Then
                    xrVal = xr * xQ
                End If
                BomLV.SubItems.Add(FormatNumber(xQ, 3))
                BomLV.SubItems.Add(FormatNumber(xrVal, 2))
                BomLV.SubItems.Add(FormatNumber(xr, 2))
                BomLV.SubItems.Add(Trim(lblic.Text))
                BomLV.SubItems.Add(ItemId)
                BomLV.SubItems.Add("NotAded")
                BomLV.SubItems.Add("")
                BomLV.SubItems.Add(xratio)
                BomLV.SubItems.Add("None")
                find_item_Nos_Total()
                txtqnty.Text = ""
                Me.TxtboxCost.Text = 0
                Me.txtboxpcs.Text = 1
                Me.Txtcod1.Focus()
                Me.Txtcod1.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Remov_PackItems()
        Dim Cont As Integer = 0
        For Cont = 0 To Me.BomLstVew.Items.Count - 1
            If Trim(Me.BomLstVew.Items(Cont).SubItems(10).Text) = "Packing" Then
                Me.BomLstVew.Items(Cont).Remove()
            End If
        Next

    End Sub

    Private Sub txtboxpcs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Inr_Flag = True
            Otr_Flag = True
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CmbxSelItm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxSelItm.SelectedIndexChanged
        Try
            If Me.CmbxSelItm.Items.Count > 0 Then
                Me.Txtcod1.Text = Trim(Select_ItmCodeOnly(Me.CmbxSelItm.SelectedValue))
            Else
                Me.Txtcod1.Text = ""
            End If
        Catch ex As Exception

        End Try
        Try
            If Me.CmbxSelItm.Items.Count > 0 And Not Me.CmbxSelItm.SelectedIndex = -1 Then
                SelRec_Itemmaster()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub stitsave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles stitsave.GotFocus
        Try
            If stitsave.Text = "&Edit" Then
                If FrmShow_flag(20) = True Then
                    FrmShow_flag(20) = False
                    Create_fill_ItmDg()
                End If
            End If
        Catch ex As Exception

        End Try
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

    Private Sub ItmDg_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ItmDg.CellClick
        Try
            With ItmDg
                If e.ColumnIndex = 1 Then
                    If (.Rows.Count > 0 And e.RowIndex <> .Rows.Count) Then
                        '.Rows.RemoveAt(e.RowIndex)
                        Dim fbomd As New FrmBomDetails
                        fbomd.ShowInTaskbar = False
                        fbomd.Top = Me.Top + 5
                        ItmCurId = Me.ItmDg.CurrentRow.Cells(0).Value
                        BomCurType = Me.ItmDg.CurrentRow.Cells("itype").Value
                        CurrBOMname = Trim(Me.ItmDg.CurrentRow.Cells(3).Value)
                        fbomd.ShowDialog()
                    End If
                End If

            End With

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Txtcod1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcod1.Leave
        Try
            Dim xIid As Integer = Select_ItmCode(Trim(Txtcod1.Text))
            If xIid > 0 Then
                Me.CmbxSelItm.SelectedValue = xIid
                If Me.CmbxSelItm.SelectedValue <> xIid Then
                    MsgBox("Invalid input!", MsgBoxStyle.Critical, "No Record Found!!!")
                    Me.Txtcod1.Focus()
                    Me.Txtcod1.SelectAll()
                End If
            Else
                Me.Txtcod1.Text = ""
                MsgBox("Invalid input!", MsgBoxStyle.Critical, "No Record Found!!!")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSelItm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSelItm.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxStokGrup) = True Then
                If Trim(Me.lblic.Text) = "" Then
                    SelRec_Itemmaster()
                End If
                If FrmShow_flag(2) = True Then
                    FrmShow_flag(2) = False
                    Me.txtboxpcs.Focus()
                    Me.txtboxpcs.SelectAll()
                End If
                Me.Panel10.Visible = False
                If Trim(lblin.Text) <> "" Then
                    Me.Label34.Text = "Currently Selected Item Is " & Trim(lblin.Text)
                    Me.Label34.Visible = True
                Else
                    Me.Label34.Visible = False
                End If
                Me.txtboxpcs.Focus()
                Me.txtboxpcs.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSelItm_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSelItm.SelectionChangeCommitted
        Try
            SelRec_Itemmaster()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtboxpcs_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtboxpcs.GotFocus
        Try
            'Me.txtboxpcs.Text = 1
            txtboxpcs.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtboxpcs_Leave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtboxpcs.Leave
        Try
            If Trim(txtboxpcs.Text) <> "" Then
                Me.txtboxpcs.BackColor = Color.White
                If IsNumeric(txtboxpcs.Text) = False Or Trim(txtboxpcs.Text.EndsWith("-")) = True Or Trim(txtboxpcs.Text.StartsWith("-")) = True Then
                    MsgBox("Invalid Input! Only numbers are allowed", MsgBoxStyle.Critical, "Enter number like 1,2,3...")
                    txtboxpcs.Focus()
                    txtboxpcs.SelectAll()
                    Exit Sub
                End If
            Else
                Me.txtboxpcs.BackColor = Color.Cyan
                Me.txtboxpcs.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseHover
        Try
            Me.Label11.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        Try
            Me.Label11.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtboxpcs_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtboxpcs.TextChanged

    End Sub

    Private Sub Rbraw_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbraw.CheckedChanged, RbBom.CheckedChanged, Rbboth.CheckedChanged
        Try
            If FrmShow_flag(22) = True Then
                set_Condition()
                Spl_Fill_Combobox(SelStrg, CmbxSelItm)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtMPack_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMPack.Leave
        If Trim(TxtMPack.Text) <> "" Then
            If IsNumeric(TxtMPack.Text) = False Or Trim(TxtMPack.Text.EndsWith("-")) = True Or Trim(TxtMPack.Text.StartsWith("-")) = True Then
                TxtMPack.Focus()
                TxtMPack.SelectAll()
                LblAlrt1.Visible = True
            Else
                LblAlrt1.Visible = False
                Me.TxtMPack.Text = FormatNumber(Me.TxtMPack.Text, 0)
            End If
        Else
            Me.TxtMPack.Text = 0
            LblAlrt1.Visible = False
        End If
    End Sub

    Private Sub CmbxSelItm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSelItm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxSelItm_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtboxCost_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtboxCost.Leave
        Try
            If xChk_numericValidation(Me.TxtboxCost) = False Then
                If Len(Trim(TxtboxCost.Text)) = 0 Then
                    Me.TxtboxCost.Text = 0
                End If
                Me.TxtboxCost.Text = FormatNumber(Me.TxtboxCost.Text, 2)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtItmname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItmname.TextChanged
        Try
            If Len(Me.TxtItmname.Text.Trim) > 0 Then
                Me.LstVew2.Height = 172
                Me.LstVew2.Location = New Point(364, 156)
                xFillLstVewWith2Recrd(Me.LstVew2, Me.TxtItmname.Text.Trim, "Itmid", "Itmname", "FinactitmMstr", "Itmname")
            Else
                Me.LstVew2.Visible = False
                Me.LstVew2.Enabled = False
                Me.LstVew2.Height = 10
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxStokGrup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.SelectedIndexChanged

    End Sub
End Class

Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmPayRoll

    Inherits System.Windows.Forms.Form
    Dim P_Roll_Mstr_Cmd As SqlCommand
    Dim P_Roll_Mstr_rdr As SqlDataReader
    Dim P_Roll_Info_Cmd As SqlCommand
    Dim P_Roll_Info_Rdr As SqlDataReader
    Dim P_Roll_Info_Cmd1 As SqlCommand
    Dim P_Roll_Info_Rdr1 As SqlDataReader
    Dim Info_Cty_Cmd As SqlCommand
    Dim Info_Cty_Rdr As SqlDataReader
    Dim Info_Cty_Cmd1 As SqlCommand
    Dim Info_Cty_Rdr1 As SqlDataReader
    Dim Info_Cty_Cmd2 As SqlCommand
    Dim Info_Cty_Rdr2 As SqlDataReader
    Dim P_Roll_Othr_Cmd As SqlCommand
    Dim P_Roll_Othr_Rdr As SqlDataReader
    Dim P_Roll_Exprn_Cmd As SqlCommand
    Dim P_Roll_Exprn_rdr As SqlDataReader
    Dim P_Roll_Fmly_Cmd As SqlCommand
    Dim P_Roll_Fmly_rdr As SqlDataReader
    Dim P_Roll_Fmly_Cmd1 As SqlCommand
    Dim P_Roll_Fmly_rdr1 As SqlDataReader
    Dim P_Roll_Acad_Cmd As SqlCommand
    Dim P_Roll_Acad_rdr As SqlDataReader
    Dim P_Roll_Empid_Cmd As SqlCommand
    Dim P_Roll_Empid_Rdr As SqlDataReader
    Dim P_Roll_Fmlyid_Cmd As SqlCommand
    Dim P_Roll_Fmlyid_Rdr As SqlDataReader
    Dim P_Roll_Acadid_Cmd As SqlCommand
    Dim P_Roll_Acadid_Rdr As SqlDataReader
    Dim P_Roll_Exprnid_Cmd As SqlCommand
    Dim P_Roll_Exprnid_Rdr As SqlDataReader
    Dim P_Roll_Degree_Cmd As SqlCommand
    Dim P_Roll_Degree_rdr As SqlDataReader
    Dim P_Roll_Emplrnam_Cmd As SqlCommand
    Dim P_Roll_Emplrnam_Rdr As SqlDataReader

    Dim dgr As DataGridViewRow
    Dim cel As DataGridViewTextBoxCell
    Dim com As DataGridViewComboBoxCell

    Dim lst As ListViewItem
    Dim LstFmly As ListViewItem
    Dim LstAcad As ListViewItem
    Dim LstExprn As ListViewItem

    Dim same_adrs_flag As Boolean = False
    ' Dim Fetch_PFId As Integer = 0
    Dim relatn As String
    Dim Status As String

    Dim arr_nmid(100) As Integer
    Dim k As Integer = 0
    Dim Fnl_Slry As Double = 0

    Dim fso As Object
    Dim Chk_CsC As Boolean
    Dim MySource, DptName As String
    Dim ImagePath As String = "None"
    Dim DptId, BnkId As Integer
    Dim Bnknam As String
    Dim ctytype As String = "Outer"
    Dim EiD As Integer
    Dim Add_Edit_Flag As Boolean
    Dim ctyid1 As Integer
    Dim ctyid2 As Integer
    Dim ctyid3 As Integer
    Dim temp As String
    Dim DesiId As Integer
    Dim DesId As Integer
    Dim Fmlyid As Integer
    Dim Acadid As Integer
    Dim Exprnid As Integer
    Dim empid As Integer
    Dim Joindate As Date
    Dim Infomode As String
    Dim Apntmode As String
    Dim Cnfrmmode As String
    Dim Fmlymode As String
    Dim ProFndmode As String
    Dim Acadmode As String
    Dim Exprncmode As String
    Dim Othermode As String
    Dim Fmlyrec As Integer
    Dim Totfmly As Integer
    Dim Indx As Integer
    Dim relname As String
    Dim Famlyid As Integer
    Dim Degrename As String
    Dim Acadmicid As Integer
    Dim Emplrname As String
    Dim Exprnceid As Integer
    Dim cntr As Integer
    Dim Fmly_cntr As Integer
    Dim Fmly_cnt As Integer
    Dim Fmly_sel_cnt As Integer
    Dim cntr_updt As Integer
    Dim cntr_save As Integer
    Dim cntr_save1 As Integer
    Dim cntr_del As Integer
    Dim Fmlyname, Frelatn As String
    Dim Fdob As Date
    Dim fmlyrelatn As String
    Dim Dblclick As Integer = 0
    Dim cntr_save_acad As Integer
    Dim cntr_save_acad1 As Integer
    Dim fetch_Acadmic_cntr As Integer
    Dim Acad_cntr As Integer
    Dim AcadDegree, AcadClass, AcadSubjts, AcadInsti As String
    Dim AcadPassyr As Integer
    Dim Acad_cnt, Acad_sel_cnt As Integer
    Dim AcadInstitu As String
    Dim expEmplr, ExpJndesi, ExpLevdesi, ExpAchive As String
    Dim ExpJndt, ExpLevdt As Date
    Dim ExpSlry As Integer
    Dim Expr_cnt As Integer
    Dim Expr_sel_cnt As Integer
    Dim cntr_save_exprn As Integer
    Dim cntr_save_exprn1 As Integer
    Dim Expr_cntr As Integer
    Dim fetch_Exp_cntr As Integer
    Dim ExprAchieve As String
    Dim doj_flag As Boolean
    Dim SlryBrkup_Id As Integer



    Dim Fetch_Payhed_Cmd As SqlCommand
    Dim Fetch_Payhed_Rdr As SqlDataReader
    Dim Count_Payhead As Integer
    Dim Min_Payhead As Integer
    Dim Max_Payhead As Integer
    Dim Payhead_Name As String
    Dim Payhead_Type As String
    Dim Phed_Calmtd As String
    Dim Ern_Deduc As String
    Dim Phed_Comp As String
    Dim PheadType As String
    Dim Phed_Formulatype As String
    Dim Phed_Id As Integer
    Dim totslab_flag As Boolean
    Dim TotSlabAmt As Double
    Dim j1 As Integer
    Dim l1 As Integer
    Dim TotSlabAmt1 As Double
    Dim Payhead_Name1 As String
    Dim Arr_Ern_Deduc1(100) As String
    Dim Phed_Comp1 As String
    Dim Arr_Phed_Type21(100) As String
    Dim Phed_Calmtd1 As String
    Dim Phed_Formulatype1 As String
    Dim Phed_Id1 As Integer
    Dim phed_detls As Boolean
    Dim Count_SlabId As Integer
    Dim Count_SlabId1 As Integer
    Dim RateId11 As Integer
    Dim Target_Amt As Double
    Dim RateId As Integer
    Dim FromAmt1 As Double
    Dim UptoAmt1 As Double
    Dim Rateval1 As Double
    Dim BscAmt As Double
    Dim finalamt As Double
    Dim Sec_Phed_id As Integer
    Dim str_PheadFormula As String
    Dim recursve_flag As Boolean
    Dim Rem_amt As Double
    Dim BscSry_cng As Double
    Dim VPF_Pcent As Double
    Dim VPF_Amt As Double
    Dim DiffAmt1 As Double
    Dim SlabAmt1 As Double
    Dim BscSlry1 As Double
    Dim loopvar_flag As Boolean
    Dim BscSlry As Double
    Dim Arr_Pay_Type(100) As String
    Dim contr As Integer
    Dim m As Integer
    Dim ctr As Integer
    Dim p As Integer
    Dim arr_srateid(100) As Integer
    Dim arr_srateid1(100) As Integer
    Dim i As Integer
    Dim lst_cntr As Integer
    Dim result As Double
    Dim UsrPhed_Amt As Double
    Dim j As Integer
    Dim SlryBrk_Id As Integer
    Dim SlryBrk_ovrtm As Boolean
    Dim SlryBrk_phed As Boolean
    Dim SlryBrkmode As String
    Dim arr_PhedId(100) As Integer
    Dim fetch_recrd As Boolean = False


    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents txtprobation As System.Windows.Forms.NumericUpDown
    Friend WithEvents DtpkrDob As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents CmbxBrnch As System.Windows.Forms.ComboBox
    Friend WithEvents DtpkrDocon As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtEmpName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtdispl As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Dtpkrdoj As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbxCat As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxDesi As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxDept As System.Windows.Forms.ComboBox
    Friend WithEvents TxtScale As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Txtwrkid As System.Windows.Forms.ComboBox
    Friend WithEvents Txtbnkname As System.Windows.Forms.ComboBox
    Friend WithEvents TxtAccType As System.Windows.Forms.ComboBox
    Friend WithEvents LstVewSelRec As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtExprDel As System.Windows.Forms.Button
    Friend WithEvents BtExprEd As System.Windows.Forms.Button
    Friend WithEvents BtmFmlyCancl As System.Windows.Forms.Button
    Friend WithEvents BtnExpCncl As System.Windows.Forms.Button
    Friend WithEvents BtnAcadCncl As System.Windows.Forms.Button
    Friend WithEvents CmbxEmpStat As System.Windows.Forms.ComboBox
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblClickMe As System.Windows.Forms.Label
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents CmbxSift As System.Windows.Forms.ComboBox
    Friend WithEvents RbAccept As System.Windows.Forms.RadioButton
    Friend WithEvents RbReject As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txtpassyr As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ChkBxResi As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BtnApntBrse As System.Windows.Forms.Button
    Friend WithEvents BtnCnfrmBrws As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog3 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DtpkrTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbxCateg As System.Windows.Forms.ComboBox
    Friend WithEvents LblCateg As System.Windows.Forms.Label
    Friend WithEvents TabSlryBrkup As System.Windows.Forms.TabPage
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents LstvewPhed As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents RbNoPhed As System.Windows.Forms.RadioButton
    Friend WithEvents RbYes_Phed As System.Windows.Forms.RadioButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents RbYes As System.Windows.Forms.RadioButton
    Friend WithEvents RbNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents LblGrossSlry As System.Windows.Forms.Label
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents RbNoCmpo As System.Windows.Forms.RadioButton
    Friend WithEvents RbYesCmpo As System.Windows.Forms.RadioButton
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TxtVPpercnt As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents TxtInsId As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents TxtInsurdAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents TxtNewPfNo As System.Windows.Forms.TextBox
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents CmbxBonus As System.Windows.Forms.ComboBox
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents TxtNmShare As System.Windows.Forms.TextBox
    Friend WithEvents LnkLblVew As System.Windows.Forms.LinkLabel
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents Label124 As System.Windows.Forms.Label
    Friend WithEvents Lblscale As System.Windows.Forms.Label
    Dim IndxMstr As Integer
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
    Friend WithEvents PayRolTab As System.Windows.Forms.TabControl
    Friend WithEvents TabMstr As System.Windows.Forms.TabPage
    Friend WithEvents TabPrsonl As System.Windows.Forms.TabPage
    Friend WithEvents TabPfEsi As System.Windows.Forms.TabPage
    Friend WithEvents TabPrev As System.Windows.Forms.TabPage
    Friend WithEvents TabConfrmltr As System.Windows.Forms.TabPage
    Friend WithEvents TabAppLtr As System.Windows.Forms.TabPage
    Friend WithEvents TabOthrs As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Rbcash As System.Windows.Forms.RadioButton
    Friend WithEvents Rbchq As System.Windows.Forms.RadioButton
    Friend WithEvents RbTfr As System.Windows.Forms.RadioButton
    Friend WithEvents Grpbxbnk As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtbCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtAccNo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents EmpImage As System.Windows.Forms.PictureBox
    Friend WithEvents Lnklempimag As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtAddrs As System.Windows.Forms.TextBox
    Friend WithEvents TxtAddrs1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtLndmrk As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CmbxCty1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents txtPin As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtphno As System.Windows.Forms.TextBox
    Friend WithEvents Txtmobno As System.Windows.Forms.TextBox
    Friend WithEvents txtEmlid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbxCurCty As System.Windows.Forms.ComboBox
    Friend WithEvents TxtCurAddrs As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TxtCurAdd1 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TxtCurLnd As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents TxtCurPin As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TxtCurPhno As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents CmbxSex As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents CmbxMStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Txtnatnl As System.Windows.Forms.TextBox
    Friend WithEvents DtpkrAnivrsry As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbxRelign As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents TxtPan As System.Windows.Forms.TextBox
    Friend WithEvents Txtward As System.Windows.Forms.TextBox
    Friend WithEvents TxtGir As System.Windows.Forms.TextBox
    Friend WithEvents Txtrange As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents TxtIdmark1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdmark2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtFhname As System.Windows.Forms.TextBox
    Friend WithEvents TxtMoname As System.Windows.Forms.TextBox
    Friend WithEvents TxtSposName As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents TxtEmrgncyNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents DtpkrSettldt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents DtpkrPfJdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkPFappli As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEsicAppli As System.Windows.Forms.CheckBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents TxtAmtpf As System.Windows.Forms.TextBox
    Friend WithEvents TxtTfrdamt As System.Windows.Forms.TextBox
    Friend WithEvents TxtPFNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPolicno As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents DtpkrRenewdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtEsic As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents TxtDispName As System.Windows.Forms.TextBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents LnklblSame As System.Windows.Forms.LinkLabel
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Txtsubjts As System.Windows.Forms.TextBox
    Friend WithEvents TxtInsti As System.Windows.Forms.TextBox
    Friend WithEvents CmbxDegree As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxClass As System.Windows.Forms.ComboBox
    Friend WithEvents Lstvew1 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Lstvew2 As System.Windows.Forms.ListView
    Friend WithEvents TxtJnDesi As System.Windows.Forms.TextBox
    Friend WithEvents TxtLevdesi As System.Windows.Forms.TextBox
    Friend WithEvents Txtslry As System.Windows.Forms.TextBox
    Friend WithEvents TxtEmplr As System.Windows.Forms.TextBox
    Friend WithEvents DtpkrJndt As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpkrLevDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txtachive As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents LSTVEW3 As System.Windows.Forms.ListView
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents TxtName1 As System.Windows.Forms.TextBox
    Friend WithEvents DtpkrDob1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbxRelatn As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents TxtNomine As System.Windows.Forms.TextBox
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents cmbxrelt As System.Windows.Forms.ComboBox
    Friend WithEvents Dtpkrdob2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txtadrsnomi As System.Windows.Forms.TextBox
    Friend WithEvents txtadrsnomi1 As System.Windows.Forms.TextBox
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Cmbxctynomi As System.Windows.Forms.ComboBox
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents TxtPinNomi As System.Windows.Forms.TextBox
    Friend WithEvents RchtxtCnfrmltr As System.Windows.Forms.RichTextBox
    Friend WithEvents Rcjtxtappnt As System.Windows.Forms.RichTextBox
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents TxtRecAgncy As System.Windows.Forms.TextBox
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents TxtBnkMandte As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTptRute As System.Windows.Forms.TextBox
    Friend WithEvents cmbxWrkLoc As System.Windows.Forms.ComboBox
    Friend WithEvents txtCoVeclNo As System.Windows.Forms.TextBox
    Friend WithEvents CmbxCoVeclType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents TxtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Txtlaptop As System.Windows.Forms.TextBox
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents Txtmailid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents TxtReason As System.Windows.Forms.TextBox
    Friend WithEvents DtpkrSubmit As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpkrAccept As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpkrRelev As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents Btnclos As System.Windows.Forms.Button
    Friend WithEvents Btndel As System.Windows.Forms.Button
    Friend WithEvents btnedt As System.Windows.Forms.Button
    Friend WithEvents Btnsave As System.Windows.Forms.Button
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblState As System.Windows.Forms.Label
    Friend WithEvents LblContry As System.Windows.Forms.Label
    Friend WithEvents LblCurState As System.Windows.Forms.Label
    Friend WithEvents LblCurContry As System.Windows.Forms.Label
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents txtcurmobno As System.Windows.Forms.TextBox
    Friend WithEvents LblContryNomi As System.Windows.Forms.Label
    Friend WithEvents LblStatenomi As System.Windows.Forms.Label
    Friend WithEvents BtFmlyadd As System.Windows.Forms.Button
    Friend WithEvents BtExprAdd As System.Windows.Forms.Button
    Friend WithEvents BtnAcadDel As System.Windows.Forms.Button
    Friend WithEvents BtnAcadEd As System.Windows.Forms.Button
    Friend WithEvents BtnAcadad As System.Windows.Forms.Button
    Friend WithEvents NoHtFt As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Nodepnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents Txtgrdian As System.Windows.Forms.TextBox
    Friend WithEvents cmbxstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents BtnFmlydel As System.Windows.Forms.Button
    Friend WithEvents BtnFmlyedit As System.Windows.Forms.Button
    Friend WithEvents TxtRemks As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Btnclos = New System.Windows.Forms.Button
        Me.Btndel = New System.Windows.Forms.Button
        Me.btnedt = New System.Windows.Forms.Button
        Me.Btnsave = New System.Windows.Forms.Button
        Me.PayRolTab = New System.Windows.Forms.TabControl
        Me.TabMstr = New System.Windows.Forms.TabPage
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Lblscale = New System.Windows.Forms.Label
        Me.Label121 = New System.Windows.Forms.Label
        Me.Label124 = New System.Windows.Forms.Label
        Me.Label120 = New System.Windows.Forms.Label
        Me.CmbxBonus = New System.Windows.Forms.ComboBox
        Me.Label119 = New System.Windows.Forms.Label
        Me.CmbxCateg = New System.Windows.Forms.ComboBox
        Me.LblCateg = New System.Windows.Forms.Label
        Me.Label95 = New System.Windows.Forms.Label
        Me.CmbxSift = New System.Windows.Forms.ComboBox
        Me.CmbxEmpStat = New System.Windows.Forms.ComboBox
        Me.Label93 = New System.Windows.Forms.Label
        Me.Txtwrkid = New System.Windows.Forms.ComboBox
        Me.Label113 = New System.Windows.Forms.Label
        Me.txtprobation = New System.Windows.Forms.NumericUpDown
        Me.DtpkrDob = New System.Windows.Forms.DateTimePicker
        Me.Label36 = New System.Windows.Forms.Label
        Me.CmbxBrnch = New System.Windows.Forms.ComboBox
        Me.DtpkrDocon = New System.Windows.Forms.DateTimePicker
        Me.TxtEmpName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtdispl = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Dtpkrdoj = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbxCat = New System.Windows.Forms.ComboBox
        Me.CmbxDesi = New System.Windows.Forms.ComboBox
        Me.CmbxDept = New System.Windows.Forms.ComboBox
        Me.TxtScale = New System.Windows.Forms.TextBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LstVewSelRec = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.Label107 = New System.Windows.Forms.Label
        Me.Lnklempimag = New System.Windows.Forms.LinkLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.EmpImage = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Grpbxbnk = New System.Windows.Forms.GroupBox
        Me.TxtAccType = New System.Windows.Forms.ComboBox
        Me.Txtbnkname = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtbCode = New System.Windows.Forms.TextBox
        Me.TxtAccNo = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Rbcash = New System.Windows.Forms.RadioButton
        Me.Rbchq = New System.Windows.Forms.RadioButton
        Me.RbTfr = New System.Windows.Forms.RadioButton
        Me.TabAppLtr = New System.Windows.Forms.TabPage
        Me.BtnApntBrse = New System.Windows.Forms.Button
        Me.Rcjtxtappnt = New System.Windows.Forms.RichTextBox
        Me.TabPrsonl = New System.Windows.Forms.TabPage
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.TxtEmrgncyNo = New System.Windows.Forms.TextBox
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.TxtPan = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.Txtward = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.TxtGir = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.Txtrange = New System.Windows.Forms.TextBox
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.TxtFhname = New System.Windows.Forms.TextBox
        Me.TxtMoname = New System.Windows.Forms.TextBox
        Me.TxtSposName = New System.Windows.Forms.TextBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.CmbxSex = New System.Windows.Forms.ComboBox
        Me.Txtnatnl = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.CmbxMStatus = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.DtpkrAnivrsry = New System.Windows.Forms.DateTimePicker
        Me.Label39 = New System.Windows.Forms.Label
        Me.CmbxRelign = New System.Windows.Forms.ComboBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.TxtIdmark1 = New System.Windows.Forms.TextBox
        Me.TxtIdmark2 = New System.Windows.Forms.TextBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.LblClickMe = New System.Windows.Forms.Label
        Me.LnklblSame = New System.Windows.Forms.LinkLabel
        Me.cmbxCurCty = New System.Windows.Forms.ComboBox
        Me.TxtCurAddrs = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.TxtCurAdd1 = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.TxtCurLnd = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.LblCurState = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.LblCurContry = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.TextBox16 = New System.Windows.Forms.TextBox
        Me.TxtCurPin = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.TxtCurPhno = New System.Windows.Forms.TextBox
        Me.Label108 = New System.Windows.Forms.Label
        Me.txtcurmobno = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.NoHtFt = New System.Windows.Forms.NumericUpDown
        Me.CmbxCty1 = New System.Windows.Forms.ComboBox
        Me.TxtAddrs = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TxtAddrs1 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TxtLndmrk = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.LblState = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.LblContry = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.txtPin = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtphno = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Txtmobno = New System.Windows.Forms.TextBox
        Me.txtEmlid = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label109 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.TabPfEsi = New System.Windows.Forms.TabPage
        Me.GroupBox16 = New System.Windows.Forms.GroupBox
        Me.LnkLblVew = New System.Windows.Forms.LinkLabel
        Me.TxtNmShare = New System.Windows.Forms.TextBox
        Me.Label123 = New System.Windows.Forms.Label
        Me.Label122 = New System.Windows.Forms.Label
        Me.Label111 = New System.Windows.Forms.Label
        Me.Dtpkrdob2 = New System.Windows.Forms.DateTimePicker
        Me.cmbxstatus = New System.Windows.Forms.ComboBox
        Me.cmbxrelt = New System.Windows.Forms.ComboBox
        Me.Label83 = New System.Windows.Forms.Label
        Me.TxtNomine = New System.Windows.Forms.TextBox
        Me.Label84 = New System.Windows.Forms.Label
        Me.Label85 = New System.Windows.Forms.Label
        Me.Label112 = New System.Windows.Forms.Label
        Me.Label86 = New System.Windows.Forms.Label
        Me.Txtadrsnomi = New System.Windows.Forms.TextBox
        Me.Txtgrdian = New System.Windows.Forms.TextBox
        Me.txtadrsnomi1 = New System.Windows.Forms.TextBox
        Me.Label87 = New System.Windows.Forms.Label
        Me.LblContryNomi = New System.Windows.Forms.Label
        Me.LblStatenomi = New System.Windows.Forms.Label
        Me.Label88 = New System.Windows.Forms.Label
        Me.Label89 = New System.Windows.Forms.Label
        Me.Cmbxctynomi = New System.Windows.Forms.ComboBox
        Me.Label90 = New System.Windows.Forms.Label
        Me.TxtPinNomi = New System.Windows.Forms.TextBox
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.BtmFmlyCancl = New System.Windows.Forms.Button
        Me.Nodepnd = New System.Windows.Forms.NumericUpDown
        Me.Label44 = New System.Windows.Forms.Label
        Me.BtnFmlydel = New System.Windows.Forms.Button
        Me.BtnFmlyedit = New System.Windows.Forms.Button
        Me.BtFmlyadd = New System.Windows.Forms.Button
        Me.cmbxRelatn = New System.Windows.Forms.ComboBox
        Me.DtpkrDob1 = New System.Windows.Forms.DateTimePicker
        Me.LSTVEW3 = New System.Windows.Forms.ListView
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader18 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label80 = New System.Windows.Forms.Label
        Me.Label81 = New System.Windows.Forms.Label
        Me.Label82 = New System.Windows.Forms.Label
        Me.TxtName1 = New System.Windows.Forms.TextBox
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.TxtEsic = New System.Windows.Forms.TextBox
        Me.ChkEsicAppli = New System.Windows.Forms.CheckBox
        Me.TxtDispName = New System.Windows.Forms.TextBox
        Me.Label67 = New System.Windows.Forms.Label
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.TxtInsurdAmt = New System.Windows.Forms.TextBox
        Me.Label115 = New System.Windows.Forms.Label
        Me.DtpkrTo = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.DtpkrRenewdt = New System.Windows.Forms.DateTimePicker
        Me.Label65 = New System.Windows.Forms.Label
        Me.TxtPolicno = New System.Windows.Forms.TextBox
        Me.Label63 = New System.Windows.Forms.Label
        Me.TxtInsId = New System.Windows.Forms.TextBox
        Me.Label64 = New System.Windows.Forms.Label
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.TxtNewPfNo = New System.Windows.Forms.TextBox
        Me.Label118 = New System.Windows.Forms.Label
        Me.ChkPFappli = New System.Windows.Forms.CheckBox
        Me.DtpkrPfJdt = New System.Windows.Forms.DateTimePicker
        Me.Label57 = New System.Windows.Forms.Label
        Me.TxtVPpercnt = New System.Windows.Forms.TextBox
        Me.TxtPFNo = New System.Windows.Forms.TextBox
        Me.TxtAmtpf = New System.Windows.Forms.TextBox
        Me.TxtTfrdamt = New System.Windows.Forms.TextBox
        Me.Label58 = New System.Windows.Forms.Label
        Me.Label62 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.DtpkrSettldt = New System.Windows.Forms.DateTimePicker
        Me.Label59 = New System.Windows.Forms.Label
        Me.Label60 = New System.Windows.Forms.Label
        Me.TabPrev = New System.Windows.Forms.TabPage
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.BtnExpCncl = New System.Windows.Forms.Button
        Me.BtExprDel = New System.Windows.Forms.Button
        Me.BtExprEd = New System.Windows.Forms.Button
        Me.BtExprAdd = New System.Windows.Forms.Button
        Me.DtpkrJndt = New System.Windows.Forms.DateTimePicker
        Me.Lstvew2 = New System.Windows.Forms.ListView
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteAllToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label74 = New System.Windows.Forms.Label
        Me.Label75 = New System.Windows.Forms.Label
        Me.Label76 = New System.Windows.Forms.Label
        Me.Label77 = New System.Windows.Forms.Label
        Me.TxtJnDesi = New System.Windows.Forms.TextBox
        Me.TxtLevdesi = New System.Windows.Forms.TextBox
        Me.Txtslry = New System.Windows.Forms.TextBox
        Me.TxtEmplr = New System.Windows.Forms.TextBox
        Me.DtpkrLevDt = New System.Windows.Forms.DateTimePicker
        Me.Label78 = New System.Windows.Forms.Label
        Me.Label79 = New System.Windows.Forms.Label
        Me.Txtachive = New System.Windows.Forms.TextBox
        Me.GroupBox14 = New System.Windows.Forms.GroupBox
        Me.Txtpassyr = New System.Windows.Forms.NumericUpDown
        Me.BtnAcadCncl = New System.Windows.Forms.Button
        Me.BtnAcadEd = New System.Windows.Forms.Button
        Me.BtnAcadDel = New System.Windows.Forms.Button
        Me.BtnAcadad = New System.Windows.Forms.Button
        Me.Lstvew1 = New System.Windows.Forms.ListView
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteAllToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CmbxDegree = New System.Windows.Forms.ComboBox
        Me.Label69 = New System.Windows.Forms.Label
        Me.Label70 = New System.Windows.Forms.Label
        Me.Label71 = New System.Windows.Forms.Label
        Me.Label72 = New System.Windows.Forms.Label
        Me.Label73 = New System.Windows.Forms.Label
        Me.Txtsubjts = New System.Windows.Forms.TextBox
        Me.TxtInsti = New System.Windows.Forms.TextBox
        Me.CmbxClass = New System.Windows.Forms.ComboBox
        Me.TabConfrmltr = New System.Windows.Forms.TabPage
        Me.BtnCnfrmBrws = New System.Windows.Forms.Button
        Me.RchtxtCnfrmltr = New System.Windows.Forms.RichTextBox
        Me.TabOthrs = New System.Windows.Forms.TabPage
        Me.GroupBox18 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.RbReject = New System.Windows.Forms.RadioButton
        Me.RbAccept = New System.Windows.Forms.RadioButton
        Me.DtpkrSubmit = New System.Windows.Forms.DateTimePicker
        Me.Label102 = New System.Windows.Forms.Label
        Me.Label103 = New System.Windows.Forms.Label
        Me.Label104 = New System.Windows.Forms.Label
        Me.TxtReason = New System.Windows.Forms.TextBox
        Me.DtpkrAccept = New System.Windows.Forms.DateTimePicker
        Me.DtpkrRelev = New System.Windows.Forms.DateTimePicker
        Me.Label105 = New System.Windows.Forms.Label
        Me.Label106 = New System.Windows.Forms.Label
        Me.TxtRemks = New System.Windows.Forms.TextBox
        Me.GroupBox17 = New System.Windows.Forms.GroupBox
        Me.ChkBxResi = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label99 = New System.Windows.Forms.Label
        Me.TxtMobile = New System.Windows.Forms.TextBox
        Me.Label100 = New System.Windows.Forms.Label
        Me.Txtlaptop = New System.Windows.Forms.TextBox
        Me.Label101 = New System.Windows.Forms.Label
        Me.Txtmailid = New System.Windows.Forms.TextBox
        Me.TxtBnkMandte = New System.Windows.Forms.GroupBox
        Me.TxtRecAgncy = New System.Windows.Forms.TextBox
        Me.Label91 = New System.Windows.Forms.Label
        Me.Label94 = New System.Windows.Forms.Label
        Me.Label96 = New System.Windows.Forms.Label
        Me.Label97 = New System.Windows.Forms.Label
        Me.TxtTptRute = New System.Windows.Forms.TextBox
        Me.cmbxWrkLoc = New System.Windows.Forms.ComboBox
        Me.Label98 = New System.Windows.Forms.Label
        Me.txtCoVeclNo = New System.Windows.Forms.TextBox
        Me.CmbxCoVeclType = New System.Windows.Forms.ComboBox
        Me.TabSlryBrkup = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.RbNoCmpo = New System.Windows.Forms.RadioButton
        Me.RbYesCmpo = New System.Windows.Forms.RadioButton
        Me.Label117 = New System.Windows.Forms.Label
        Me.Label116 = New System.Windows.Forms.Label
        Me.LblGrossSlry = New System.Windows.Forms.Label
        Me.Label114 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.RbNoPhed = New System.Windows.Forms.RadioButton
        Me.RbYes_Phed = New System.Windows.Forms.RadioButton
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.RbYes = New System.Windows.Forms.RadioButton
        Me.RbNo = New System.Windows.Forms.RadioButton
        Me.Label110 = New System.Windows.Forms.Label
        Me.LstvewPhed = New System.Windows.Forms.ListView
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader19 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader20 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader21 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader23 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader24 = New System.Windows.Forms.ColumnHeader
        Me.Label92 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog
        Me.OpenFileDialog3 = New System.Windows.Forms.OpenFileDialog
        Me.Panel1.SuspendLayout()
        Me.PayRolTab.SuspendLayout()
        Me.TabMstr.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.txtprobation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.EmpImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Grpbxbnk.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabAppLtr.SuspendLayout()
        Me.TabPrsonl.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.NoHtFt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPfEsi.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        CType(Me.Nodepnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.TabPrev.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        CType(Me.Txtpassyr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.TabConfrmltr.SuspendLayout()
        Me.TabOthrs.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.TxtBnkMandte.SuspendLayout()
        Me.TabSlryBrkup.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Btnclos)
        Me.Panel1.Controls.Add(Me.Btndel)
        Me.Panel1.Controls.Add(Me.btnedt)
        Me.Panel1.Controls.Add(Me.Btnsave)
        Me.Panel1.Controls.Add(Me.PayRolTab)
        Me.Panel1.Location = New System.Drawing.Point(0, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(891, 537)
        Me.Panel1.TabIndex = 0
        '
        'Btnclos
        '
        Me.Btnclos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnclos.Location = New System.Drawing.Point(796, 509)
        Me.Btnclos.Name = "Btnclos"
        Me.Btnclos.Size = New System.Drawing.Size(75, 23)
        Me.Btnclos.TabIndex = 3
        Me.Btnclos.Text = "C&lose"
        Me.Btnclos.UseVisualStyleBackColor = True
        '
        'Btndel
        '
        Me.Btndel.Enabled = False
        Me.Btndel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btndel.Location = New System.Drawing.Point(713, 509)
        Me.Btndel.Name = "Btndel"
        Me.Btndel.Size = New System.Drawing.Size(75, 23)
        Me.Btndel.TabIndex = 2
        Me.Btndel.Text = "&Delete"
        Me.Btndel.UseVisualStyleBackColor = True
        '
        'btnedt
        '
        Me.btnedt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnedt.Location = New System.Drawing.Point(630, 509)
        Me.btnedt.Name = "btnedt"
        Me.btnedt.Size = New System.Drawing.Size(75, 23)
        Me.btnedt.TabIndex = 1
        Me.btnedt.Text = "&Edit"
        Me.btnedt.UseVisualStyleBackColor = True
        '
        'Btnsave
        '
        Me.Btnsave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnsave.Location = New System.Drawing.Point(547, 509)
        Me.Btnsave.Name = "Btnsave"
        Me.Btnsave.Size = New System.Drawing.Size(75, 23)
        Me.Btnsave.TabIndex = 0
        Me.Btnsave.Text = "&New"
        Me.Btnsave.UseVisualStyleBackColor = True
        '
        'PayRolTab
        '
        Me.PayRolTab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.PayRolTab.Controls.Add(Me.TabMstr)
        Me.PayRolTab.Controls.Add(Me.TabAppLtr)
        Me.PayRolTab.Controls.Add(Me.TabPrsonl)
        Me.PayRolTab.Controls.Add(Me.TabPfEsi)
        Me.PayRolTab.Controls.Add(Me.TabPrev)
        Me.PayRolTab.Controls.Add(Me.TabConfrmltr)
        Me.PayRolTab.Controls.Add(Me.TabOthrs)
        Me.PayRolTab.Controls.Add(Me.TabSlryBrkup)
        Me.PayRolTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayRolTab.HotTrack = True
        Me.PayRolTab.Location = New System.Drawing.Point(8, 8)
        Me.PayRolTab.Name = "PayRolTab"
        Me.PayRolTab.Padding = New System.Drawing.Point(2, 3)
        Me.PayRolTab.SelectedIndex = 0
        Me.PayRolTab.Size = New System.Drawing.Size(875, 502)
        Me.PayRolTab.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.PayRolTab.TabIndex = 1
        '
        'TabMstr
        '
        Me.TabMstr.AutoScroll = True
        Me.TabMstr.BackColor = System.Drawing.Color.Transparent
        Me.TabMstr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabMstr.Controls.Add(Me.Panel5)
        Me.TabMstr.Controls.Add(Me.Panel3)
        Me.TabMstr.Controls.Add(Me.Lnklempimag)
        Me.TabMstr.Controls.Add(Me.Panel2)
        Me.TabMstr.Controls.Add(Me.GroupBox1)
        Me.TabMstr.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TabMstr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabMstr.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabMstr.Location = New System.Drawing.Point(4, 26)
        Me.TabMstr.Name = "TabMstr"
        Me.TabMstr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabMstr.Size = New System.Drawing.Size(867, 472)
        Me.TabMstr.TabIndex = 0
        Me.TabMstr.Text = "Master"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Lblscale)
        Me.Panel5.Controls.Add(Me.Label121)
        Me.Panel5.Controls.Add(Me.Label124)
        Me.Panel5.Controls.Add(Me.Label120)
        Me.Panel5.Controls.Add(Me.CmbxBonus)
        Me.Panel5.Controls.Add(Me.Label119)
        Me.Panel5.Controls.Add(Me.CmbxCateg)
        Me.Panel5.Controls.Add(Me.LblCateg)
        Me.Panel5.Controls.Add(Me.Label95)
        Me.Panel5.Controls.Add(Me.CmbxSift)
        Me.Panel5.Controls.Add(Me.CmbxEmpStat)
        Me.Panel5.Controls.Add(Me.Label93)
        Me.Panel5.Controls.Add(Me.Txtwrkid)
        Me.Panel5.Controls.Add(Me.Label113)
        Me.Panel5.Controls.Add(Me.txtprobation)
        Me.Panel5.Controls.Add(Me.DtpkrDob)
        Me.Panel5.Controls.Add(Me.Label36)
        Me.Panel5.Controls.Add(Me.CmbxBrnch)
        Me.Panel5.Controls.Add(Me.DtpkrDocon)
        Me.Panel5.Controls.Add(Me.TxtEmpName)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.txtdispl)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Dtpkrdoj)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.CmbxCat)
        Me.Panel5.Controls.Add(Me.CmbxDesi)
        Me.Panel5.Controls.Add(Me.CmbxDept)
        Me.Panel5.Controls.Add(Me.TxtScale)
        Me.Panel5.Enabled = False
        Me.Panel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(3, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(430, 465)
        Me.Panel5.TabIndex = 0
        '
        'Lblscale
        '
        Me.Lblscale.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Lblscale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblscale.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblscale.ForeColor = System.Drawing.Color.Black
        Me.Lblscale.Location = New System.Drawing.Point(144, 381)
        Me.Lblscale.Name = "Lblscale"
        Me.Lblscale.Size = New System.Drawing.Size(93, 20)
        Me.Lblscale.TabIndex = 87
        Me.Lblscale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label121
        '
        Me.Label121.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label121.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label121.ForeColor = System.Drawing.Color.Black
        Me.Label121.Location = New System.Drawing.Point(245, 383)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(36, 20)
        Me.Label121.TabIndex = 57
        Me.Label121.Text = "Rs."
        '
        'Label124
        '
        Me.Label124.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label124.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label124.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label124.ForeColor = System.Drawing.Color.Black
        Me.Label124.Location = New System.Drawing.Point(38, 380)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(99, 21)
        Me.Label124.TabIndex = 56
        Me.Label124.Text = "Current Scale:-"
        Me.Label124.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label120
        '
        Me.Label120.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label120.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label120.ForeColor = System.Drawing.Color.Black
        Me.Label120.Location = New System.Drawing.Point(245, 354)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(36, 20)
        Me.Label120.TabIndex = 54
        Me.Label120.Text = "Rs."
        '
        'CmbxBonus
        '
        Me.CmbxBonus.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxBonus.FormattingEnabled = True
        Me.CmbxBonus.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxBonus.Location = New System.Drawing.Point(144, 438)
        Me.CmbxBonus.Name = "CmbxBonus"
        Me.CmbxBonus.Size = New System.Drawing.Size(68, 22)
        Me.CmbxBonus.TabIndex = 15
        '
        'Label119
        '
        Me.Label119.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label119.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label119.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label119.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label119.Location = New System.Drawing.Point(8, 441)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(129, 20)
        Me.Label119.TabIndex = 52
        Me.Label119.Text = "Bonus Applicable:-"
        Me.Label119.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbxCateg
        '
        Me.CmbxCateg.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxCateg.FormattingEnabled = True
        Me.CmbxCateg.Items.AddRange(New Object() {"Salary", "Wages"})
        Me.CmbxCateg.Location = New System.Drawing.Point(326, 317)
        Me.CmbxCateg.Name = "CmbxCateg"
        Me.CmbxCateg.Size = New System.Drawing.Size(96, 22)
        Me.CmbxCateg.TabIndex = 12
        '
        'LblCateg
        '
        Me.LblCateg.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblCateg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCateg.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCateg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblCateg.Location = New System.Drawing.Point(245, 318)
        Me.LblCateg.Name = "LblCateg"
        Me.LblCateg.Size = New System.Drawing.Size(72, 20)
        Me.LblCateg.TabIndex = 50
        Me.LblCateg.Text = "Category:-"
        '
        'Label95
        '
        Me.Label95.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label95.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label95.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.ForeColor = System.Drawing.Color.Black
        Me.Label95.Location = New System.Drawing.Point(85, 321)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(52, 20)
        Me.Label95.TabIndex = 19
        Me.Label95.Text = "Shift :-"
        Me.Label95.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbxSift
        '
        Me.CmbxSift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxSift.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxSift.Location = New System.Drawing.Point(144, 318)
        Me.CmbxSift.Name = "CmbxSift"
        Me.CmbxSift.Size = New System.Drawing.Size(79, 22)
        Me.CmbxSift.TabIndex = 11
        '
        'CmbxEmpStat
        '
        Me.CmbxEmpStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxEmpStat.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxEmpStat.Items.AddRange(New Object() {"Temporary", "Permanent", "Trainee", "Daily Basis"})
        Me.CmbxEmpStat.Location = New System.Drawing.Point(144, 410)
        Me.CmbxEmpStat.Name = "CmbxEmpStat"
        Me.CmbxEmpStat.Size = New System.Drawing.Size(235, 22)
        Me.CmbxEmpStat.TabIndex = 14
        '
        'Label93
        '
        Me.Label93.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label93.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label93.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label93.Location = New System.Drawing.Point(8, 410)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(129, 20)
        Me.Label93.TabIndex = 49
        Me.Label93.Text = "Employment Status:-"
        Me.Label93.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txtwrkid
        '
        Me.Txtwrkid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Txtwrkid.FormattingEnabled = True
        Me.Txtwrkid.Location = New System.Drawing.Point(144, 58)
        Me.Txtwrkid.Name = "Txtwrkid"
        Me.Txtwrkid.Size = New System.Drawing.Size(235, 23)
        Me.Txtwrkid.TabIndex = 2
        '
        'Label113
        '
        Me.Label113.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label113.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label113.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label113.ForeColor = System.Drawing.Color.Black
        Me.Label113.Location = New System.Drawing.Point(189, 145)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(61, 20)
        Me.Label113.TabIndex = 48
        Me.Label113.Text = "Month(s)"
        '
        'txtprobation
        '
        Me.txtprobation.Location = New System.Drawing.Point(144, 145)
        Me.txtprobation.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.txtprobation.Name = "txtprobation"
        Me.txtprobation.Size = New System.Drawing.Size(43, 21)
        Me.txtprobation.TabIndex = 5
        '
        'DtpkrDob
        '
        Me.DtpkrDob.Checked = False
        Me.DtpkrDob.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrDob.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrDob.Location = New System.Drawing.Point(144, 88)
        Me.DtpkrDob.Name = "DtpkrDob"
        Me.DtpkrDob.Size = New System.Drawing.Size(106, 21)
        Me.DtpkrDob.TabIndex = 3
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(38, 88)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(99, 21)
        Me.Label36.TabIndex = 46
        Me.Label36.Text = "Date of Birth :-"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbxBrnch
        '
        Me.CmbxBrnch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxBrnch.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxBrnch.Location = New System.Drawing.Point(144, 201)
        Me.CmbxBrnch.Name = "CmbxBrnch"
        Me.CmbxBrnch.Size = New System.Drawing.Size(235, 22)
        Me.CmbxBrnch.TabIndex = 7
        '
        'DtpkrDocon
        '
        Me.DtpkrDocon.Checked = False
        Me.DtpkrDocon.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrDocon.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrDocon.Location = New System.Drawing.Point(144, 172)
        Me.DtpkrDocon.Name = "DtpkrDocon"
        Me.DtpkrDocon.Size = New System.Drawing.Size(105, 21)
        Me.DtpkrDocon.TabIndex = 6
        '
        'TxtEmpName
        '
        Me.TxtEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtEmpName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEmpName.Location = New System.Drawing.Point(144, 2)
        Me.TxtEmpName.Name = "TxtEmpName"
        Me.TxtEmpName.Size = New System.Drawing.Size(278, 21)
        Me.TxtEmpName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(73, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Name :-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtdispl
        '
        Me.txtdispl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdispl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdispl.Location = New System.Drawing.Point(144, 29)
        Me.txtdispl.Name = "txtdispl"
        Me.txtdispl.Size = New System.Drawing.Size(236, 21)
        Me.txtdispl.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(38, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 20)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Display Name :-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(2, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 20)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Machine/Work Name :-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(45, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Joining Date :-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(15, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 20)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Probation Period  :-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 21)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Confirmation Date  :-"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dtpkrdoj
        '
        Me.Dtpkrdoj.CustomFormat = "dd/MM/yyyy"
        Me.Dtpkrdoj.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpkrdoj.Location = New System.Drawing.Point(144, 117)
        Me.Dtpkrdoj.Name = "Dtpkrdoj"
        Me.Dtpkrdoj.Size = New System.Drawing.Size(105, 21)
        Me.Dtpkrdoj.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(73, 201)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 21)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Branch  :-"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(73, 229)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 21)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Grade  :-"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(41, 259)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 21)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Designation   :-"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(50, 289)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 21)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Department :-"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(44, 351)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 21)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Basic Scale:-"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbxCat
        '
        Me.CmbxCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCat.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxCat.Location = New System.Drawing.Point(144, 229)
        Me.CmbxCat.Name = "CmbxCat"
        Me.CmbxCat.Size = New System.Drawing.Size(236, 22)
        Me.CmbxCat.TabIndex = 8
        '
        'CmbxDesi
        '
        Me.CmbxDesi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxDesi.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxDesi.Location = New System.Drawing.Point(144, 259)
        Me.CmbxDesi.Name = "CmbxDesi"
        Me.CmbxDesi.Size = New System.Drawing.Size(236, 22)
        Me.CmbxDesi.TabIndex = 9
        '
        'CmbxDept
        '
        Me.CmbxDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxDept.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxDept.Location = New System.Drawing.Point(144, 289)
        Me.CmbxDept.Name = "CmbxDept"
        Me.CmbxDept.Size = New System.Drawing.Size(236, 22)
        Me.CmbxDept.TabIndex = 10
        '
        'TxtScale
        '
        Me.TxtScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtScale.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtScale.Location = New System.Drawing.Point(144, 351)
        Me.TxtScale.Name = "TxtScale"
        Me.TxtScale.Size = New System.Drawing.Size(96, 22)
        Me.TxtScale.TabIndex = 13
        Me.TxtScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.LstVewSelRec)
        Me.Panel3.Controls.Add(Me.Label107)
        Me.Panel3.Enabled = False
        Me.Panel3.Location = New System.Drawing.Point(450, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(225, 53)
        Me.Panel3.TabIndex = 0
        '
        'LstVewSelRec
        '
        Me.LstVewSelRec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstVewSelRec.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.LstVewSelRec.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVewSelRec.FullRowSelect = True
        Me.LstVewSelRec.GridLines = True
        Me.LstVewSelRec.Location = New System.Drawing.Point(5, 27)
        Me.LstVewSelRec.MultiSelect = False
        Me.LstVewSelRec.Name = "LstVewSelRec"
        Me.LstVewSelRec.Size = New System.Drawing.Size(219, 25)
        Me.LstVewSelRec.TabIndex = 1
        Me.LstVewSelRec.UseCompatibleStateImageBehavior = False
        Me.LstVewSelRec.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 219
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Id No"
        Me.ColumnHeader2.Width = 0
        '
        'Label107
        '
        Me.Label107.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label107.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label107.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label107.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.ForeColor = System.Drawing.Color.Black
        Me.Label107.Location = New System.Drawing.Point(5, 4)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(106, 20)
        Me.Label107.TabIndex = 0
        Me.Label107.Text = "Select a record :-"
        '
        'Lnklempimag
        '
        Me.Lnklempimag.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnklempimag.Location = New System.Drawing.Point(693, 219)
        Me.Lnklempimag.Name = "Lnklempimag"
        Me.Lnklempimag.Size = New System.Drawing.Size(152, 16)
        Me.Lnklempimag.TabIndex = 26
        Me.Lnklempimag.TabStop = True
        Me.Lnklempimag.Text = "Load Employee's Image"
        Me.Lnklempimag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LemonChiffon
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.EmpImage)
        Me.Panel2.Location = New System.Drawing.Point(693, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(152, 194)
        Me.Panel2.TabIndex = 14
        '
        'EmpImage
        '
        Me.EmpImage.BackColor = System.Drawing.Color.White
        Me.EmpImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EmpImage.Location = New System.Drawing.Point(11, 11)
        Me.EmpImage.Name = "EmpImage"
        Me.EmpImage.Size = New System.Drawing.Size(128, 170)
        Me.EmpImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.EmpImage.TabIndex = 0
        Me.EmpImage.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Grpbxbnk)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(439, 267)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(416, 176)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mode Of Payment"
        '
        'Grpbxbnk
        '
        Me.Grpbxbnk.Controls.Add(Me.TxtAccType)
        Me.Grpbxbnk.Controls.Add(Me.Txtbnkname)
        Me.Grpbxbnk.Controls.Add(Me.Label15)
        Me.Grpbxbnk.Controls.Add(Me.Label16)
        Me.Grpbxbnk.Controls.Add(Me.TxtbCode)
        Me.Grpbxbnk.Controls.Add(Me.TxtAccNo)
        Me.Grpbxbnk.Controls.Add(Me.Label17)
        Me.Grpbxbnk.Controls.Add(Me.Label18)
        Me.Grpbxbnk.Enabled = False
        Me.Grpbxbnk.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grpbxbnk.Location = New System.Drawing.Point(129, 20)
        Me.Grpbxbnk.Name = "Grpbxbnk"
        Me.Grpbxbnk.Size = New System.Drawing.Size(274, 148)
        Me.Grpbxbnk.TabIndex = 21
        Me.Grpbxbnk.TabStop = False
        Me.Grpbxbnk.Text = "Bank Info."
        '
        'TxtAccType
        '
        Me.TxtAccType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtAccType.FormattingEnabled = True
        Me.TxtAccType.Items.AddRange(New Object() {"Saving Account" & Global.Microsoft.VisualBasic.ChrW(9), "Current Account", "Salary Account" & Global.Microsoft.VisualBasic.ChrW(9), "Car O/D Account", "O/D Account", ""})
        Me.TxtAccType.Location = New System.Drawing.Point(98, 118)
        Me.TxtAccType.Name = "TxtAccType"
        Me.TxtAccType.Size = New System.Drawing.Size(166, 23)
        Me.TxtAccType.TabIndex = 25
        '
        'Txtbnkname
        '
        Me.Txtbnkname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Txtbnkname.FormattingEnabled = True
        Me.Txtbnkname.Location = New System.Drawing.Point(98, 24)
        Me.Txtbnkname.Name = "Txtbnkname"
        Me.Txtbnkname.Size = New System.Drawing.Size(166, 23)
        Me.Txtbnkname.TabIndex = 22
        '
        'Label15
        '
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(3, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 21)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Bank Name :-"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(3, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 21)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Branch Code :-"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtbCode
        '
        Me.TxtbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtbCode.Location = New System.Drawing.Point(98, 56)
        Me.TxtbCode.Name = "TxtbCode"
        Me.TxtbCode.Size = New System.Drawing.Size(166, 21)
        Me.TxtbCode.TabIndex = 23
        '
        'TxtAccNo
        '
        Me.TxtAccNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAccNo.Location = New System.Drawing.Point(98, 88)
        Me.TxtAccNo.Name = "TxtAccNo"
        Me.TxtAccNo.Size = New System.Drawing.Size(166, 21)
        Me.TxtAccNo.TabIndex = 24
        '
        'Label17
        '
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(3, 88)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 21)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Account No. :-"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(3, 120)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(91, 21)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Account type :-"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightGray
        Me.GroupBox2.Controls.Add(Me.Rbcash)
        Me.GroupBox2.Controls.Add(Me.Rbchq)
        Me.GroupBox2.Controls.Add(Me.RbTfr)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(14, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(108, 117)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        '
        'Rbcash
        '
        Me.Rbcash.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Rbcash.Checked = True
        Me.Rbcash.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Rbcash.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbcash.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Rbcash.Location = New System.Drawing.Point(8, 18)
        Me.Rbcash.Name = "Rbcash"
        Me.Rbcash.Size = New System.Drawing.Size(94, 24)
        Me.Rbcash.TabIndex = 18
        Me.Rbcash.TabStop = True
        Me.Rbcash.Text = "By Cash "
        Me.Rbcash.UseVisualStyleBackColor = False
        '
        'Rbchq
        '
        Me.Rbchq.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Rbchq.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Rbchq.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbchq.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Rbchq.Location = New System.Drawing.Point(8, 50)
        Me.Rbchq.Name = "Rbchq"
        Me.Rbchq.Size = New System.Drawing.Size(94, 24)
        Me.Rbchq.TabIndex = 19
        Me.Rbchq.Text = "By  Cheque"
        Me.Rbchq.UseVisualStyleBackColor = False
        '
        'RbTfr
        '
        Me.RbTfr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RbTfr.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RbTfr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbTfr.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.RbTfr.Location = New System.Drawing.Point(8, 82)
        Me.RbTfr.Name = "RbTfr"
        Me.RbTfr.Size = New System.Drawing.Size(94, 24)
        Me.RbTfr.TabIndex = 20
        Me.RbTfr.Text = "By Transfer"
        Me.RbTfr.UseVisualStyleBackColor = False
        '
        'TabAppLtr
        '
        Me.TabAppLtr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabAppLtr.Controls.Add(Me.BtnApntBrse)
        Me.TabAppLtr.Controls.Add(Me.Rcjtxtappnt)
        Me.TabAppLtr.Location = New System.Drawing.Point(4, 26)
        Me.TabAppLtr.Name = "TabAppLtr"
        Me.TabAppLtr.Size = New System.Drawing.Size(867, 472)
        Me.TabAppLtr.TabIndex = 7
        Me.TabAppLtr.Text = "Appointment Letter"
        Me.TabAppLtr.UseVisualStyleBackColor = True
        Me.TabAppLtr.Visible = False
        '
        'BtnApntBrse
        '
        Me.BtnApntBrse.Location = New System.Drawing.Point(760, 398)
        Me.BtnApntBrse.Name = "BtnApntBrse"
        Me.BtnApntBrse.Size = New System.Drawing.Size(85, 24)
        Me.BtnApntBrse.TabIndex = 1
        Me.BtnApntBrse.Text = "&Browse"
        Me.BtnApntBrse.UseVisualStyleBackColor = True
        '
        'Rcjtxtappnt
        '
        Me.Rcjtxtappnt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rcjtxtappnt.Location = New System.Drawing.Point(8, 8)
        Me.Rcjtxtappnt.Name = "Rcjtxtappnt"
        Me.Rcjtxtappnt.Size = New System.Drawing.Size(845, 384)
        Me.Rcjtxtappnt.TabIndex = 0
        Me.Rcjtxtappnt.Text = ""
        '
        'TabPrsonl
        '
        Me.TabPrsonl.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPrsonl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPrsonl.Controls.Add(Me.GroupBox7)
        Me.TabPrsonl.Controls.Add(Me.GroupBox6)
        Me.TabPrsonl.Controls.Add(Me.GroupBox5)
        Me.TabPrsonl.Controls.Add(Me.GroupBox4)
        Me.TabPrsonl.ForeColor = System.Drawing.Color.Blue
        Me.TabPrsonl.Location = New System.Drawing.Point(4, 26)
        Me.TabPrsonl.Name = "TabPrsonl"
        Me.TabPrsonl.Size = New System.Drawing.Size(867, 472)
        Me.TabPrsonl.TabIndex = 1
        Me.TabPrsonl.Text = "Personal Info."
        Me.TabPrsonl.UseVisualStyleBackColor = True
        Me.TabPrsonl.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox7.Controls.Add(Me.Label47)
        Me.GroupBox7.Controls.Add(Me.GroupBox8)
        Me.GroupBox7.Controls.Add(Me.Label41)
        Me.GroupBox7.Controls.Add(Me.TxtPan)
        Me.GroupBox7.Controls.Add(Me.Label42)
        Me.GroupBox7.Controls.Add(Me.Txtward)
        Me.GroupBox7.Controls.Add(Me.Label43)
        Me.GroupBox7.Controls.Add(Me.TxtGir)
        Me.GroupBox7.Controls.Add(Me.Label46)
        Me.GroupBox7.Controls.Add(Me.Txtrange)
        Me.GroupBox7.Controls.Add(Me.Label48)
        Me.GroupBox7.Controls.Add(Me.Label49)
        Me.GroupBox7.Controls.Add(Me.TxtFhname)
        Me.GroupBox7.Controls.Add(Me.TxtMoname)
        Me.GroupBox7.Controls.Add(Me.TxtSposName)
        Me.GroupBox7.Controls.Add(Me.Label50)
        Me.GroupBox7.Controls.Add(Me.Label54)
        Me.GroupBox7.Controls.Add(Me.Label55)
        Me.GroupBox7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.Black
        Me.GroupBox7.Location = New System.Drawing.Point(427, 213)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(422, 238)
        Me.GroupBox7.TabIndex = 3
        Me.GroupBox7.TabStop = False
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.LightYellow
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label47.Location = New System.Drawing.Point(2, 64)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(372, 3)
        Me.Label47.TabIndex = 7
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TxtEmrgncyNo)
        Me.GroupBox8.Controls.Add(Me.Label56)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 157)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(369, 48)
        Me.GroupBox8.TabIndex = 6
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Emergency Information"
        '
        'TxtEmrgncyNo
        '
        Me.TxtEmrgncyNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtEmrgncyNo.Location = New System.Drawing.Point(98, 18)
        Me.TxtEmrgncyNo.Name = "TxtEmrgncyNo"
        Me.TxtEmrgncyNo.Size = New System.Drawing.Size(262, 20)
        Me.TxtEmrgncyNo.TabIndex = 30
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label56.Location = New System.Drawing.Point(5, 18)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(91, 21)
        Me.Label56.TabIndex = 5
        Me.Label56.Text = "Contact Nos.  :-"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.Location = New System.Drawing.Point(32, 16)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(48, 21)
        Me.Label41.TabIndex = 4
        Me.Label41.Text = "PAN  :-"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPan
        '
        Me.TxtPan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPan.Location = New System.Drawing.Point(83, 16)
        Me.TxtPan.Name = "TxtPan"
        Me.TxtPan.Size = New System.Drawing.Size(85, 20)
        Me.TxtPan.TabIndex = 23
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Location = New System.Drawing.Point(184, 40)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(64, 21)
        Me.Label42.TabIndex = 4
        Me.Label42.Text = "Ward No :- "
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtward
        '
        Me.Txtward.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtward.Location = New System.Drawing.Point(250, 40)
        Me.Txtward.Name = "Txtward"
        Me.Txtward.Size = New System.Drawing.Size(72, 20)
        Me.Txtward.TabIndex = 26
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Location = New System.Drawing.Point(184, 16)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(64, 21)
        Me.Label43.TabIndex = 4
        Me.Label43.Text = "GIR NO.  :-"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtGir
        '
        Me.TxtGir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGir.Location = New System.Drawing.Point(250, 16)
        Me.TxtGir.Name = "TxtGir"
        Me.TxtGir.Size = New System.Drawing.Size(93, 20)
        Me.TxtGir.TabIndex = 24
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label46.Location = New System.Drawing.Point(24, 40)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(56, 21)
        Me.Label46.TabIndex = 4
        Me.Label46.Text = "Range  :-"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtrange
        '
        Me.Txtrange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtrange.Location = New System.Drawing.Point(83, 40)
        Me.Txtrange.Name = "Txtrange"
        Me.Txtrange.Size = New System.Drawing.Size(85, 20)
        Me.Txtrange.TabIndex = 25
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Location = New System.Drawing.Point(8, 72)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(144, 21)
        Me.Label48.TabIndex = 4
        Me.Label48.Text = "Father/Husband Name :-"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label49.Location = New System.Drawing.Point(56, 96)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(96, 21)
        Me.Label49.TabIndex = 4
        Me.Label49.Text = "Mother  Name :-"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFhname
        '
        Me.TxtFhname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFhname.Location = New System.Drawing.Point(155, 72)
        Me.TxtFhname.Name = "TxtFhname"
        Me.TxtFhname.Size = New System.Drawing.Size(205, 20)
        Me.TxtFhname.TabIndex = 27
        '
        'TxtMoname
        '
        Me.TxtMoname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMoname.Location = New System.Drawing.Point(155, 96)
        Me.TxtMoname.Name = "TxtMoname"
        Me.TxtMoname.Size = New System.Drawing.Size(181, 20)
        Me.TxtMoname.TabIndex = 28
        '
        'TxtSposName
        '
        Me.TxtSposName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSposName.Location = New System.Drawing.Point(155, 120)
        Me.TxtSposName.Name = "TxtSposName"
        Me.TxtSposName.Size = New System.Drawing.Size(181, 20)
        Me.TxtSposName.TabIndex = 29
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label50.Location = New System.Drawing.Point(48, 120)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(104, 21)
        Me.Label50.TabIndex = 4
        Me.Label50.Text = "Spouse  Name :-"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.LightYellow
        Me.Label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label54.Location = New System.Drawing.Point(2, 146)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(372, 3)
        Me.Label54.TabIndex = 3
        '
        'Label55
        '
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label55.Location = New System.Drawing.Point(48, 120)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(96, 21)
        Me.Label55.TabIndex = 4
        Me.Label55.Text = "Spouse  Name :-"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox6.Controls.Add(Me.CmbxSex)
        Me.GroupBox6.Controls.Add(Me.Txtnatnl)
        Me.GroupBox6.Controls.Add(Me.Label35)
        Me.GroupBox6.Controls.Add(Me.Label37)
        Me.GroupBox6.Controls.Add(Me.CmbxMStatus)
        Me.GroupBox6.Controls.Add(Me.Label38)
        Me.GroupBox6.Controls.Add(Me.DtpkrAnivrsry)
        Me.GroupBox6.Controls.Add(Me.Label39)
        Me.GroupBox6.Controls.Add(Me.CmbxRelign)
        Me.GroupBox6.Controls.Add(Me.Label40)
        Me.GroupBox6.Controls.Add(Me.Label51)
        Me.GroupBox6.Controls.Add(Me.TxtIdmark1)
        Me.GroupBox6.Controls.Add(Me.TxtIdmark2)
        Me.GroupBox6.Controls.Add(Me.Label52)
        Me.GroupBox6.Controls.Add(Me.Label53)
        Me.GroupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(8, 285)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(410, 166)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        '
        'CmbxSex
        '
        Me.CmbxSex.Items.AddRange(New Object() {"Male", "Female"})
        Me.CmbxSex.Location = New System.Drawing.Point(87, 16)
        Me.CmbxSex.Name = "CmbxSex"
        Me.CmbxSex.Size = New System.Drawing.Size(77, 22)
        Me.CmbxSex.TabIndex = 9
        '
        'Txtnatnl
        '
        Me.Txtnatnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtnatnl.Location = New System.Drawing.Point(275, 80)
        Me.Txtnatnl.Name = "Txtnatnl"
        Me.Txtnatnl.Size = New System.Drawing.Size(93, 20)
        Me.Txtnatnl.TabIndex = 13
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Location = New System.Drawing.Point(17, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(62, 21)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "Gender :-"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Location = New System.Drawing.Point(181, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(91, 21)
        Me.Label37.TabIndex = 2
        Me.Label37.Text = "Marital Status :-"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxMStatus
        '
        Me.CmbxMStatus.Items.AddRange(New Object() {"Married", "UnMarried", "Never Married", "Divorcee"})
        Me.CmbxMStatus.Location = New System.Drawing.Point(275, 16)
        Me.CmbxMStatus.Name = "CmbxMStatus"
        Me.CmbxMStatus.Size = New System.Drawing.Size(88, 22)
        Me.CmbxMStatus.TabIndex = 10
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Location = New System.Drawing.Point(5, 77)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(83, 21)
        Me.Label38.TabIndex = 2
        Me.Label38.Text = "Anniversary :-"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtpkrAnivrsry
        '
        Me.DtpkrAnivrsry.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrAnivrsry.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrAnivrsry.Location = New System.Drawing.Point(95, 78)
        Me.DtpkrAnivrsry.Name = "DtpkrAnivrsry"
        Me.DtpkrAnivrsry.Size = New System.Drawing.Size(88, 20)
        Me.DtpkrAnivrsry.TabIndex = 12
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.Location = New System.Drawing.Point(204, 48)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(67, 21)
        Me.Label39.TabIndex = 2
        Me.Label39.Text = "Religion :-"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxRelign
        '
        Me.CmbxRelign.Items.AddRange(New Object() {"Christen", "Muslim", "Hindu", "Sikh", "Jain", "Budha", "Others"})
        Me.CmbxRelign.Location = New System.Drawing.Point(274, 48)
        Me.CmbxRelign.Name = "CmbxRelign"
        Me.CmbxRelign.Size = New System.Drawing.Size(88, 22)
        Me.CmbxRelign.TabIndex = 11
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.Location = New System.Drawing.Point(197, 80)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(75, 21)
        Me.Label40.TabIndex = 2
        Me.Label40.Text = "Nationality :-"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label51.Location = New System.Drawing.Point(5, 108)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(171, 20)
        Me.Label51.TabIndex = 2
        Me.Label51.Text = "Personal Identification Mark :-"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtIdmark1
        '
        Me.TxtIdmark1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdmark1.Location = New System.Drawing.Point(200, 108)
        Me.TxtIdmark1.Name = "TxtIdmark1"
        Me.TxtIdmark1.Size = New System.Drawing.Size(66, 20)
        Me.TxtIdmark1.TabIndex = 14
        '
        'TxtIdmark2
        '
        Me.TxtIdmark2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdmark2.Location = New System.Drawing.Point(290, 108)
        Me.TxtIdmark2.Name = "TxtIdmark2"
        Me.TxtIdmark2.Size = New System.Drawing.Size(78, 20)
        Me.TxtIdmark2.TabIndex = 15
        '
        'Label52
        '
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label52.Location = New System.Drawing.Point(181, 108)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(16, 20)
        Me.Label52.TabIndex = 2
        Me.Label52.Text = "1)"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label53
        '
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label53.Location = New System.Drawing.Point(271, 108)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(16, 20)
        Me.Label53.TabIndex = 2
        Me.Label53.Text = "2)"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox5.Controls.Add(Me.LblClickMe)
        Me.GroupBox5.Controls.Add(Me.LnklblSame)
        Me.GroupBox5.Controls.Add(Me.cmbxCurCty)
        Me.GroupBox5.Controls.Add(Me.TxtCurAddrs)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.TxtCurAdd1)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.TxtCurLnd)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.LblCurState)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.LblCurContry)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Controls.Add(Me.Label33)
        Me.GroupBox5.Controls.Add(Me.TextBox16)
        Me.GroupBox5.Controls.Add(Me.TxtCurPin)
        Me.GroupBox5.Controls.Add(Me.Label34)
        Me.GroupBox5.Controls.Add(Me.TxtCurPhno)
        Me.GroupBox5.Controls.Add(Me.Label108)
        Me.GroupBox5.Controls.Add(Me.txtcurmobno)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(429, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(420, 207)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Current Address"
        '
        'LblClickMe
        '
        Me.LblClickMe.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblClickMe.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblClickMe.Location = New System.Drawing.Point(261, 13)
        Me.LblClickMe.Name = "LblClickMe"
        Me.LblClickMe.Size = New System.Drawing.Size(59, 16)
        Me.LblClickMe.TabIndex = 4
        Me.LblClickMe.Text = "Click Me"
        Me.LblClickMe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LnklblSame
        '
        Me.LnklblSame.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LnklblSame.LinkColor = System.Drawing.Color.RoyalBlue
        Me.LnklblSame.Location = New System.Drawing.Point(132, 13)
        Me.LnklblSame.Name = "LnklblSame"
        Me.LnklblSame.Size = New System.Drawing.Size(139, 16)
        Me.LnklblSame.TabIndex = 16
        Me.LnklblSame.TabStop = True
        Me.LnklblSame.Text = "Same as Permanent"
        '
        'cmbxCurCty
        '
        Me.cmbxCurCty.Location = New System.Drawing.Point(82, 111)
        Me.cmbxCurCty.Name = "cmbxCurCty"
        Me.cmbxCurCty.Size = New System.Drawing.Size(112, 22)
        Me.cmbxCurCty.TabIndex = 19
        '
        'TxtCurAddrs
        '
        Me.TxtCurAddrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCurAddrs.Location = New System.Drawing.Point(82, 32)
        Me.TxtCurAddrs.Name = "TxtCurAddrs"
        Me.TxtCurAddrs.Size = New System.Drawing.Size(224, 20)
        Me.TxtCurAddrs.TabIndex = 16
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(16, 32)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(64, 21)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "Address :-"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCurAdd1
        '
        Me.TxtCurAdd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCurAdd1.Location = New System.Drawing.Point(82, 54)
        Me.TxtCurAdd1.Name = "TxtCurAdd1"
        Me.TxtCurAdd1.Size = New System.Drawing.Size(224, 20)
        Me.TxtCurAdd1.TabIndex = 17
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(4, 80)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(75, 21)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Land Mark :-"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCurLnd
        '
        Me.TxtCurLnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCurLnd.Location = New System.Drawing.Point(81, 80)
        Me.TxtCurLnd.Name = "TxtCurLnd"
        Me.TxtCurLnd.Size = New System.Drawing.Size(224, 20)
        Me.TxtCurLnd.TabIndex = 18
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(40, 111)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(40, 21)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "City :-"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCurState
        '
        Me.LblCurState.BackColor = System.Drawing.SystemColors.Window
        Me.LblCurState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCurState.ForeColor = System.Drawing.Color.Black
        Me.LblCurState.Location = New System.Drawing.Point(251, 110)
        Me.LblCurState.Name = "LblCurState"
        Me.LblCurState.Size = New System.Drawing.Size(117, 21)
        Me.LblCurState.TabIndex = 0
        Me.LblCurState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(197, 111)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(51, 21)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "State :-"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCurContry
        '
        Me.LblCurContry.BackColor = System.Drawing.SystemColors.Window
        Me.LblCurContry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCurContry.ForeColor = System.Drawing.Color.Black
        Me.LblCurContry.Location = New System.Drawing.Point(83, 142)
        Me.LblCurContry.Name = "LblCurContry"
        Me.LblCurContry.Size = New System.Drawing.Size(112, 21)
        Me.LblCurContry.TabIndex = 0
        Me.LblCurContry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(20, 142)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(61, 21)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Country :-"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(209, 142)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(40, 21)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Pin :-"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox16
        '
        Me.TextBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox16.Location = New System.Drawing.Point(81, 80)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(224, 20)
        Me.TextBox16.TabIndex = 1
        '
        'TxtCurPin
        '
        Me.TxtCurPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCurPin.Location = New System.Drawing.Point(251, 142)
        Me.TxtCurPin.Name = "TxtCurPin"
        Me.TxtCurPin.Size = New System.Drawing.Size(118, 20)
        Me.TxtCurPin.TabIndex = 20
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(6, 174)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(75, 21)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "Phone No. :-"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCurPhno
        '
        Me.TxtCurPhno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCurPhno.Location = New System.Drawing.Point(83, 174)
        Me.TxtCurPhno.Name = "TxtCurPhno"
        Me.TxtCurPhno.Size = New System.Drawing.Size(85, 20)
        Me.TxtCurPhno.TabIndex = 21
        '
        'Label108
        '
        Me.Label108.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label108.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label108.ForeColor = System.Drawing.Color.Black
        Me.Label108.Location = New System.Drawing.Point(174, 174)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(74, 21)
        Me.Label108.TabIndex = 0
        Me.Label108.Text = "Mobile No. :-"
        Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtcurmobno
        '
        Me.txtcurmobno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcurmobno.Location = New System.Drawing.Point(251, 174)
        Me.txtcurmobno.Name = "txtcurmobno"
        Me.txtcurmobno.Size = New System.Drawing.Size(86, 20)
        Me.txtcurmobno.TabIndex = 22
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox4.Controls.Add(Me.NoHtFt)
        Me.GroupBox4.Controls.Add(Me.CmbxCty1)
        Me.GroupBox4.Controls.Add(Me.TxtAddrs)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.TxtAddrs1)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.TxtLndmrk)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.LblState)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.LblContry)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.TextBox9)
        Me.GroupBox4.Controls.Add(Me.txtPin)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.txtphno)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.Txtmobno)
        Me.GroupBox4.Controls.Add(Me.txtEmlid)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.Label109)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(410, 273)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Permanent Address"
        '
        'NoHtFt
        '
        Me.NoHtFt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NoHtFt.Location = New System.Drawing.Point(82, 227)
        Me.NoHtFt.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.NoHtFt.Name = "NoHtFt"
        Me.NoHtFt.Size = New System.Drawing.Size(40, 20)
        Me.NoHtFt.TabIndex = 8
        Me.NoHtFt.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'CmbxCty1
        '
        Me.CmbxCty1.Location = New System.Drawing.Point(82, 101)
        Me.CmbxCty1.Name = "CmbxCty1"
        Me.CmbxCty1.Size = New System.Drawing.Size(112, 22)
        Me.CmbxCty1.TabIndex = 3
        '
        'TxtAddrs
        '
        Me.TxtAddrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAddrs.Location = New System.Drawing.Point(82, 21)
        Me.TxtAddrs.Name = "TxtAddrs"
        Me.TxtAddrs.Size = New System.Drawing.Size(224, 20)
        Me.TxtAddrs.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(16, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 21)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Address :-"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtAddrs1
        '
        Me.TxtAddrs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAddrs1.Location = New System.Drawing.Point(82, 43)
        Me.TxtAddrs1.Name = "TxtAddrs1"
        Me.TxtAddrs1.Size = New System.Drawing.Size(224, 20)
        Me.TxtAddrs1.TabIndex = 1
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(5, 69)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 21)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Land Mark :-"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtLndmrk
        '
        Me.TxtLndmrk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtLndmrk.Location = New System.Drawing.Point(82, 69)
        Me.TxtLndmrk.Name = "TxtLndmrk"
        Me.TxtLndmrk.Size = New System.Drawing.Size(224, 20)
        Me.TxtLndmrk.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(40, 101)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 21)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "City :-"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblState
        '
        Me.LblState.BackColor = System.Drawing.SystemColors.Window
        Me.LblState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblState.ForeColor = System.Drawing.Color.Black
        Me.LblState.Location = New System.Drawing.Point(251, 101)
        Me.LblState.Name = "LblState"
        Me.LblState.Size = New System.Drawing.Size(117, 21)
        Me.LblState.TabIndex = 0
        Me.LblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(203, 101)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(45, 21)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "State :-"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblContry
        '
        Me.LblContry.BackColor = System.Drawing.SystemColors.Window
        Me.LblContry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblContry.ForeColor = System.Drawing.Color.Black
        Me.LblContry.Location = New System.Drawing.Point(82, 133)
        Me.LblContry.Name = "LblContry"
        Me.LblContry.Size = New System.Drawing.Size(112, 21)
        Me.LblContry.TabIndex = 0
        Me.LblContry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(19, 133)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 21)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Country :-"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(208, 133)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 21)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Pin :-"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox9
        '
        Me.TextBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox9.Location = New System.Drawing.Point(82, 69)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(224, 20)
        Me.TextBox9.TabIndex = 1
        '
        'txtPin
        '
        Me.txtPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPin.Location = New System.Drawing.Point(250, 133)
        Me.txtPin.Name = "txtPin"
        Me.txtPin.Size = New System.Drawing.Size(118, 20)
        Me.txtPin.TabIndex = 4
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(6, 165)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(74, 21)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Phone No. :-"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtphno
        '
        Me.txtphno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtphno.Location = New System.Drawing.Point(82, 165)
        Me.txtphno.Name = "txtphno"
        Me.txtphno.Size = New System.Drawing.Size(86, 20)
        Me.txtphno.TabIndex = 5
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(174, 165)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(74, 21)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Mobile No. :-"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtmobno
        '
        Me.Txtmobno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtmobno.Location = New System.Drawing.Point(251, 165)
        Me.Txtmobno.Name = "Txtmobno"
        Me.Txtmobno.Size = New System.Drawing.Size(86, 20)
        Me.Txtmobno.TabIndex = 6
        '
        'txtEmlid
        '
        Me.txtEmlid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmlid.Location = New System.Drawing.Point(82, 197)
        Me.txtEmlid.Name = "txtEmlid"
        Me.txtEmlid.Size = New System.Drawing.Size(222, 20)
        Me.txtEmlid.TabIndex = 7
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(12, 197)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(68, 21)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "E-Mail Id. :-"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label109
        '
        Me.Label109.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label109.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label109.ForeColor = System.Drawing.Color.Black
        Me.Label109.Location = New System.Drawing.Point(124, 227)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(35, 20)
        Me.Label109.TabIndex = 0
        Me.Label109.Text = "cm"
        Me.Label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(23, 227)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(56, 21)
        Me.Label45.TabIndex = 0
        Me.Label45.Text = "Height  :-"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPfEsi
        '
        Me.TabPfEsi.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPfEsi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPfEsi.Controls.Add(Me.GroupBox16)
        Me.TabPfEsi.Controls.Add(Me.GroupBox13)
        Me.TabPfEsi.Controls.Add(Me.GroupBox12)
        Me.TabPfEsi.Controls.Add(Me.GroupBox11)
        Me.TabPfEsi.Controls.Add(Me.GroupBox9)
        Me.TabPfEsi.Location = New System.Drawing.Point(4, 26)
        Me.TabPfEsi.Name = "TabPfEsi"
        Me.TabPfEsi.Size = New System.Drawing.Size(867, 472)
        Me.TabPfEsi.TabIndex = 3
        Me.TabPfEsi.Text = "Family and PF/ESI Info."
        Me.TabPfEsi.UseVisualStyleBackColor = True
        Me.TabPfEsi.Visible = False
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.LnkLblVew)
        Me.GroupBox16.Controls.Add(Me.TxtNmShare)
        Me.GroupBox16.Controls.Add(Me.Label123)
        Me.GroupBox16.Controls.Add(Me.Label122)
        Me.GroupBox16.Controls.Add(Me.Label111)
        Me.GroupBox16.Controls.Add(Me.Dtpkrdob2)
        Me.GroupBox16.Controls.Add(Me.cmbxstatus)
        Me.GroupBox16.Controls.Add(Me.cmbxrelt)
        Me.GroupBox16.Controls.Add(Me.Label83)
        Me.GroupBox16.Controls.Add(Me.TxtNomine)
        Me.GroupBox16.Controls.Add(Me.Label84)
        Me.GroupBox16.Controls.Add(Me.Label85)
        Me.GroupBox16.Controls.Add(Me.Label112)
        Me.GroupBox16.Controls.Add(Me.Label86)
        Me.GroupBox16.Controls.Add(Me.Txtadrsnomi)
        Me.GroupBox16.Controls.Add(Me.Txtgrdian)
        Me.GroupBox16.Controls.Add(Me.txtadrsnomi1)
        Me.GroupBox16.Controls.Add(Me.Label87)
        Me.GroupBox16.Controls.Add(Me.LblContryNomi)
        Me.GroupBox16.Controls.Add(Me.LblStatenomi)
        Me.GroupBox16.Controls.Add(Me.Label88)
        Me.GroupBox16.Controls.Add(Me.Label89)
        Me.GroupBox16.Controls.Add(Me.Cmbxctynomi)
        Me.GroupBox16.Controls.Add(Me.Label90)
        Me.GroupBox16.Controls.Add(Me.TxtPinNomi)
        Me.GroupBox16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox16.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox16.Location = New System.Drawing.Point(456, 200)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(393, 268)
        Me.GroupBox16.TabIndex = 4
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Nominee Details"
        '
        'LnkLblVew
        '
        Me.LnkLblVew.AutoSize = True
        Me.LnkLblVew.Location = New System.Drawing.Point(309, 247)
        Me.LnkLblVew.Name = "LnkLblVew"
        Me.LnkLblVew.Size = New System.Drawing.Size(77, 13)
        Me.LnkLblVew.TabIndex = 32
        Me.LnkLblVew.TabStop = True
        Me.LnkLblVew.Text = "View Details"
        '
        'TxtNmShare
        '
        Me.TxtNmShare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNmShare.Location = New System.Drawing.Point(304, 124)
        Me.TxtNmShare.Name = "TxtNmShare"
        Me.TxtNmShare.Size = New System.Drawing.Size(42, 20)
        Me.TxtNmShare.TabIndex = 22
        '
        'Label123
        '
        Me.Label123.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label123.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label123.ForeColor = System.Drawing.Color.Black
        Me.Label123.Location = New System.Drawing.Point(349, 123)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(19, 20)
        Me.Label123.TabIndex = 28
        Me.Label123.Text = "%"
        Me.Label123.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label122
        '
        Me.Label122.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label122.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label122.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label122.ForeColor = System.Drawing.Color.Black
        Me.Label122.Location = New System.Drawing.Point(231, 122)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(64, 20)
        Me.Label122.TabIndex = 26
        Me.Label122.Text = "Share:-"
        Me.Label122.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label111
        '
        Me.Label111.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label111.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label111.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label111.ForeColor = System.Drawing.Color.Black
        Me.Label111.Location = New System.Drawing.Point(25, 149)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(83, 32)
        Me.Label111.TabIndex = 8
        Me.Label111.Text = "Gaurdian's Name :-"
        Me.Label111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Dtpkrdob2
        '
        Me.Dtpkrdob2.CustomFormat = "dd\MM\yyyy"
        Me.Dtpkrdob2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpkrdob2.Location = New System.Drawing.Point(290, 44)
        Me.Dtpkrdob2.Name = "Dtpkrdob2"
        Me.Dtpkrdob2.Size = New System.Drawing.Size(96, 20)
        Me.Dtpkrdob2.TabIndex = 17
        '
        'cmbxstatus
        '
        Me.cmbxstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxstatus.Items.AddRange(New Object() {"Major", "Minor"})
        Me.cmbxstatus.Location = New System.Drawing.Point(114, 121)
        Me.cmbxstatus.Name = "cmbxstatus"
        Me.cmbxstatus.Size = New System.Drawing.Size(94, 21)
        Me.cmbxstatus.Sorted = True
        Me.cmbxstatus.TabIndex = 20
        '
        'cmbxrelt
        '
        Me.cmbxrelt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxrelt.Items.AddRange(New Object() {"Brother", "Daughter", "Father", "Mother", "Sister", "Son", "Wife"})
        Me.cmbxrelt.Location = New System.Drawing.Point(114, 43)
        Me.cmbxrelt.Name = "cmbxrelt"
        Me.cmbxrelt.Size = New System.Drawing.Size(94, 21)
        Me.cmbxrelt.Sorted = True
        Me.cmbxrelt.TabIndex = 16
        '
        'Label83
        '
        Me.Label83.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label83.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label83.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.Black
        Me.Label83.Location = New System.Drawing.Point(8, 19)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(100, 16)
        Me.Label83.TabIndex = 2
        Me.Label83.Text = "Name :-"
        Me.Label83.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtNomine
        '
        Me.TxtNomine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomine.Location = New System.Drawing.Point(114, 19)
        Me.TxtNomine.Name = "TxtNomine"
        Me.TxtNomine.Size = New System.Drawing.Size(232, 20)
        Me.TxtNomine.TabIndex = 15
        '
        'Label84
        '
        Me.Label84.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label84.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label84.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.Black
        Me.Label84.Location = New System.Drawing.Point(20, 44)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(88, 20)
        Me.Label84.TabIndex = 2
        Me.Label84.Text = "Relationship :-"
        Me.Label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label85
        '
        Me.Label85.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label85.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label85.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.Black
        Me.Label85.Location = New System.Drawing.Point(244, 44)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(40, 20)
        Me.Label85.TabIndex = 2
        Me.Label85.Text = "DOB"
        Me.Label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label112
        '
        Me.Label112.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label112.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label112.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.ForeColor = System.Drawing.Color.Black
        Me.Label112.Location = New System.Drawing.Point(20, 121)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(88, 20)
        Me.Label112.TabIndex = 2
        Me.Label112.Text = "Status:-"
        Me.Label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label86
        '
        Me.Label86.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label86.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.ForeColor = System.Drawing.Color.Black
        Me.Label86.Location = New System.Drawing.Point(20, 70)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(88, 20)
        Me.Label86.TabIndex = 2
        Me.Label86.Text = "Address :-"
        Me.Label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtadrsnomi
        '
        Me.Txtadrsnomi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtadrsnomi.Location = New System.Drawing.Point(114, 70)
        Me.Txtadrsnomi.Name = "Txtadrsnomi"
        Me.Txtadrsnomi.Size = New System.Drawing.Size(272, 20)
        Me.Txtadrsnomi.TabIndex = 18
        '
        'Txtgrdian
        '
        Me.Txtgrdian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtgrdian.Location = New System.Drawing.Point(114, 156)
        Me.Txtgrdian.Name = "Txtgrdian"
        Me.Txtgrdian.Size = New System.Drawing.Size(272, 20)
        Me.Txtgrdian.TabIndex = 21
        '
        'txtadrsnomi1
        '
        Me.txtadrsnomi1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtadrsnomi1.Location = New System.Drawing.Point(114, 96)
        Me.txtadrsnomi1.Name = "txtadrsnomi1"
        Me.txtadrsnomi1.Size = New System.Drawing.Size(272, 20)
        Me.txtadrsnomi1.TabIndex = 19
        '
        'Label87
        '
        Me.Label87.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label87.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label87.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.ForeColor = System.Drawing.Color.Black
        Me.Label87.Location = New System.Drawing.Point(59, 187)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(49, 20)
        Me.Label87.TabIndex = 2
        Me.Label87.Text = "City :-"
        Me.Label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblContryNomi
        '
        Me.LblContryNomi.BackColor = System.Drawing.SystemColors.Window
        Me.LblContryNomi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblContryNomi.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblContryNomi.ForeColor = System.Drawing.Color.Black
        Me.LblContryNomi.Location = New System.Drawing.Point(114, 243)
        Me.LblContryNomi.Name = "LblContryNomi"
        Me.LblContryNomi.Size = New System.Drawing.Size(104, 20)
        Me.LblContryNomi.TabIndex = 26
        Me.LblContryNomi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblStatenomi
        '
        Me.LblStatenomi.BackColor = System.Drawing.SystemColors.Window
        Me.LblStatenomi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblStatenomi.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatenomi.ForeColor = System.Drawing.Color.Black
        Me.LblStatenomi.Location = New System.Drawing.Point(114, 215)
        Me.LblStatenomi.Name = "LblStatenomi"
        Me.LblStatenomi.Size = New System.Drawing.Size(104, 20)
        Me.LblStatenomi.TabIndex = 25
        Me.LblStatenomi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label88
        '
        Me.Label88.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label88.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label88.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.ForeColor = System.Drawing.Color.Black
        Me.Label88.Location = New System.Drawing.Point(44, 215)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(64, 20)
        Me.Label88.TabIndex = 2
        Me.Label88.Text = "State :-"
        Me.Label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label89
        '
        Me.Label89.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label89.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label89.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.ForeColor = System.Drawing.Color.Black
        Me.Label89.Location = New System.Drawing.Point(44, 242)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(64, 20)
        Me.Label89.TabIndex = 2
        Me.Label89.Text = "Country :-"
        Me.Label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cmbxctynomi
        '
        Me.Cmbxctynomi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxctynomi.Location = New System.Drawing.Point(114, 187)
        Me.Cmbxctynomi.Name = "Cmbxctynomi"
        Me.Cmbxctynomi.Size = New System.Drawing.Size(128, 21)
        Me.Cmbxctynomi.Sorted = True
        Me.Cmbxctynomi.TabIndex = 23
        '
        'Label90
        '
        Me.Label90.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label90.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.Black
        Me.Label90.Location = New System.Drawing.Point(255, 188)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(40, 20)
        Me.Label90.TabIndex = 2
        Me.Label90.Text = "Pin :-"
        Me.Label90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPinNomi
        '
        Me.TxtPinNomi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPinNomi.Location = New System.Drawing.Point(301, 188)
        Me.TxtPinNomi.Name = "TxtPinNomi"
        Me.TxtPinNomi.Size = New System.Drawing.Size(85, 20)
        Me.TxtPinNomi.TabIndex = 24
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.BtmFmlyCancl)
        Me.GroupBox13.Controls.Add(Me.Nodepnd)
        Me.GroupBox13.Controls.Add(Me.Label44)
        Me.GroupBox13.Controls.Add(Me.BtnFmlydel)
        Me.GroupBox13.Controls.Add(Me.BtnFmlyedit)
        Me.GroupBox13.Controls.Add(Me.BtFmlyadd)
        Me.GroupBox13.Controls.Add(Me.cmbxRelatn)
        Me.GroupBox13.Controls.Add(Me.DtpkrDob1)
        Me.GroupBox13.Controls.Add(Me.LSTVEW3)
        Me.GroupBox13.Controls.Add(Me.Label80)
        Me.GroupBox13.Controls.Add(Me.Label81)
        Me.GroupBox13.Controls.Add(Me.Label82)
        Me.GroupBox13.Controls.Add(Me.TxtName1)
        Me.GroupBox13.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox13.Location = New System.Drawing.Point(7, 208)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(432, 260)
        Me.GroupBox13.TabIndex = 3
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Family Details"
        '
        'BtmFmlyCancl
        '
        Me.BtmFmlyCancl.ForeColor = System.Drawing.Color.Black
        Me.BtmFmlyCancl.Location = New System.Drawing.Point(307, 233)
        Me.BtmFmlyCancl.Name = "BtmFmlyCancl"
        Me.BtmFmlyCancl.Size = New System.Drawing.Size(75, 23)
        Me.BtmFmlyCancl.TabIndex = 9
        Me.BtmFmlyCancl.Text = "&Cancel"
        Me.BtmFmlyCancl.UseVisualStyleBackColor = True
        '
        'Nodepnd
        '
        Me.Nodepnd.Location = New System.Drawing.Point(266, 19)
        Me.Nodepnd.Name = "Nodepnd"
        Me.Nodepnd.Size = New System.Drawing.Size(58, 20)
        Me.Nodepnd.TabIndex = 0
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(160, 19)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(84, 21)
        Me.Label44.TabIndex = 7
        Me.Label44.Text = "Dependents :-"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnFmlydel
        '
        Me.BtnFmlydel.ForeColor = System.Drawing.Color.Black
        Me.BtnFmlydel.Location = New System.Drawing.Point(214, 232)
        Me.BtnFmlydel.Name = "BtnFmlydel"
        Me.BtnFmlydel.Size = New System.Drawing.Size(75, 23)
        Me.BtnFmlydel.TabIndex = 6
        Me.BtnFmlydel.Text = "&Delete"
        Me.BtnFmlydel.UseVisualStyleBackColor = True
        '
        'BtnFmlyedit
        '
        Me.BtnFmlyedit.ForeColor = System.Drawing.Color.Black
        Me.BtnFmlyedit.Location = New System.Drawing.Point(117, 232)
        Me.BtnFmlyedit.Name = "BtnFmlyedit"
        Me.BtnFmlyedit.Size = New System.Drawing.Size(75, 23)
        Me.BtnFmlyedit.TabIndex = 6
        Me.BtnFmlyedit.Text = "&Update"
        Me.BtnFmlyedit.UseVisualStyleBackColor = True
        '
        'BtFmlyadd
        '
        Me.BtFmlyadd.ForeColor = System.Drawing.Color.Black
        Me.BtFmlyadd.Location = New System.Drawing.Point(18, 232)
        Me.BtFmlyadd.Name = "BtFmlyadd"
        Me.BtFmlyadd.Size = New System.Drawing.Size(75, 23)
        Me.BtFmlyadd.TabIndex = 4
        Me.BtFmlyadd.Text = "&Save"
        Me.BtFmlyadd.UseVisualStyleBackColor = True
        '
        'cmbxRelatn
        '
        Me.cmbxRelatn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxRelatn.Items.AddRange(New Object() {"Brother", "Daughter", "Father", "Grand Father", "Grand Mother", "Mother", "Sister", "Son", "Wife"})
        Me.cmbxRelatn.Location = New System.Drawing.Point(248, 79)
        Me.cmbxRelatn.Name = "cmbxRelatn"
        Me.cmbxRelatn.Size = New System.Drawing.Size(152, 22)
        Me.cmbxRelatn.Sorted = True
        Me.cmbxRelatn.TabIndex = 3
        '
        'DtpkrDob1
        '
        Me.DtpkrDob1.CustomFormat = "dd\MM\yyyy"
        Me.DtpkrDob1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrDob1.Location = New System.Drawing.Point(160, 79)
        Me.DtpkrDob1.Name = "DtpkrDob1"
        Me.DtpkrDob1.Size = New System.Drawing.Size(80, 20)
        Me.DtpkrDob1.TabIndex = 2
        '
        'LSTVEW3
        '
        Me.LSTVEW3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18})
        Me.LSTVEW3.ContextMenuStrip = Me.ContextMenuStrip1
        Me.LSTVEW3.FullRowSelect = True
        Me.LSTVEW3.GridLines = True
        Me.LSTVEW3.Location = New System.Drawing.Point(8, 111)
        Me.LSTVEW3.Name = "LSTVEW3"
        Me.LSTVEW3.Size = New System.Drawing.Size(392, 116)
        Me.LSTVEW3.TabIndex = 3
        Me.LSTVEW3.UseCompatibleStateImageBehavior = False
        Me.LSTVEW3.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Name"
        Me.ColumnHeader16.Width = 145
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "DOB"
        Me.ColumnHeader17.Width = 90
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Relationship"
        Me.ColumnHeader18.Width = 152
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.DeleteAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 48)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'DeleteAllToolStripMenuItem
        '
        Me.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem"
        Me.DeleteAllToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.DeleteAllToolStripMenuItem.Text = "Delete All"
        '
        'Label80
        '
        Me.Label80.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label80.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.Black
        Me.Label80.Location = New System.Drawing.Point(8, 55)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(48, 20)
        Me.Label80.TabIndex = 0
        Me.Label80.Text = "Name "
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label81
        '
        Me.Label81.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label81.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label81.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.Black
        Me.Label81.Location = New System.Drawing.Point(160, 55)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(32, 20)
        Me.Label81.TabIndex = 0
        Me.Label81.Text = "DOB"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label82
        '
        Me.Label82.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label82.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.Black
        Me.Label82.Location = New System.Drawing.Point(248, 55)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(80, 20)
        Me.Label82.TabIndex = 0
        Me.Label82.Text = "Relationship"
        Me.Label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtName1
        '
        Me.TxtName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtName1.Location = New System.Drawing.Point(8, 79)
        Me.TxtName1.Name = "TxtName1"
        Me.TxtName1.Size = New System.Drawing.Size(144, 20)
        Me.TxtName1.TabIndex = 1
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label66)
        Me.GroupBox12.Controls.Add(Me.TxtEsic)
        Me.GroupBox12.Controls.Add(Me.ChkEsicAppli)
        Me.GroupBox12.Controls.Add(Me.TxtDispName)
        Me.GroupBox12.Controls.Add(Me.Label67)
        Me.GroupBox12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(456, 105)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(393, 95)
        Me.GroupBox12.TabIndex = 2
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "ESIC"
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label66.Location = New System.Drawing.Point(6, 40)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(102, 20)
        Me.Label66.TabIndex = 9
        Me.Label66.Text = "Insurance No.  :- "
        '
        'TxtEsic
        '
        Me.TxtEsic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtEsic.Location = New System.Drawing.Point(114, 38)
        Me.TxtEsic.Name = "TxtEsic"
        Me.TxtEsic.Size = New System.Drawing.Size(155, 20)
        Me.TxtEsic.TabIndex = 13
        '
        'ChkEsicAppli
        '
        Me.ChkEsicAppli.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkEsicAppli.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkEsicAppli.Location = New System.Drawing.Point(4, 13)
        Me.ChkEsicAppli.Name = "ChkEsicAppli"
        Me.ChkEsicAppli.Size = New System.Drawing.Size(128, 20)
        Me.ChkEsicAppli.TabIndex = 6
        Me.ChkEsicAppli.Text = "ESIC  Applicable :-    "
        Me.ChkEsicAppli.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtDispName
        '
        Me.TxtDispName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDispName.Location = New System.Drawing.Point(114, 64)
        Me.TxtDispName.Name = "TxtDispName"
        Me.TxtDispName.Size = New System.Drawing.Size(155, 20)
        Me.TxtDispName.TabIndex = 14
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label67.Location = New System.Drawing.Point(4, 64)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(104, 20)
        Me.Label67.TabIndex = 9
        Me.Label67.Text = "Dispensary No  :- "
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.TxtInsurdAmt)
        Me.GroupBox11.Controls.Add(Me.Label115)
        Me.GroupBox11.Controls.Add(Me.DtpkrTo)
        Me.GroupBox11.Controls.Add(Me.Label14)
        Me.GroupBox11.Controls.Add(Me.DtpkrRenewdt)
        Me.GroupBox11.Controls.Add(Me.Label65)
        Me.GroupBox11.Controls.Add(Me.TxtPolicno)
        Me.GroupBox11.Controls.Add(Me.Label63)
        Me.GroupBox11.Controls.Add(Me.TxtInsId)
        Me.GroupBox11.Controls.Add(Me.Label64)
        Me.GroupBox11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(456, 8)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(393, 98)
        Me.GroupBox11.TabIndex = 1
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Mediclaim/Accidental Insurance"
        '
        'TxtInsurdAmt
        '
        Me.TxtInsurdAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInsurdAmt.Location = New System.Drawing.Point(307, 17)
        Me.TxtInsurdAmt.Name = "TxtInsurdAmt"
        Me.TxtInsurdAmt.Size = New System.Drawing.Size(80, 20)
        Me.TxtInsurdAmt.TabIndex = 16
        '
        'Label115
        '
        Me.Label115.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label115.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label115.Location = New System.Drawing.Point(195, 17)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(108, 20)
        Me.Label115.TabIndex = 15
        Me.Label115.Text = "Insured Amount:-"
        '
        'DtpkrTo
        '
        Me.DtpkrTo.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrTo.Location = New System.Drawing.Point(307, 69)
        Me.DtpkrTo.Name = "DtpkrTo"
        Me.DtpkrTo.Size = New System.Drawing.Size(79, 20)
        Me.DtpkrTo.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Location = New System.Drawing.Point(262, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 20)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "To :-"
        '
        'DtpkrRenewdt
        '
        Me.DtpkrRenewdt.CustomFormat = "dd\MM\yyyy"
        Me.DtpkrRenewdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrRenewdt.Location = New System.Drawing.Point(95, 71)
        Me.DtpkrRenewdt.Name = "DtpkrRenewdt"
        Me.DtpkrRenewdt.Size = New System.Drawing.Size(78, 20)
        Me.DtpkrRenewdt.TabIndex = 12
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label65.Location = New System.Drawing.Point(39, 69)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(53, 20)
        Me.Label65.TabIndex = 8
        Me.Label65.Text = "From :-"
        '
        'TxtPolicno
        '
        Me.TxtPolicno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPolicno.Location = New System.Drawing.Point(95, 17)
        Me.TxtPolicno.Name = "TxtPolicno"
        Me.TxtPolicno.Size = New System.Drawing.Size(97, 20)
        Me.TxtPolicno.TabIndex = 10
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label63.Location = New System.Drawing.Point(9, 17)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(83, 20)
        Me.Label63.TabIndex = 6
        Me.Label63.Text = "Policy No. :- "
        '
        'TxtInsId
        '
        Me.TxtInsId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInsId.Location = New System.Drawing.Point(95, 44)
        Me.TxtInsId.Name = "TxtInsId"
        Me.TxtInsId.Size = New System.Drawing.Size(97, 20)
        Me.TxtInsId.TabIndex = 11
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label64.Location = New System.Drawing.Point(4, 44)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(88, 20)
        Me.Label64.TabIndex = 6
        Me.Label64.Text = "Insurance Id  :- "
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.TxtNewPfNo)
        Me.GroupBox9.Controls.Add(Me.Label118)
        Me.GroupBox9.Controls.Add(Me.ChkPFappli)
        Me.GroupBox9.Controls.Add(Me.DtpkrPfJdt)
        Me.GroupBox9.Controls.Add(Me.Label57)
        Me.GroupBox9.Controls.Add(Me.TxtVPpercnt)
        Me.GroupBox9.Controls.Add(Me.TxtPFNo)
        Me.GroupBox9.Controls.Add(Me.TxtAmtpf)
        Me.GroupBox9.Controls.Add(Me.TxtTfrdamt)
        Me.GroupBox9.Controls.Add(Me.Label58)
        Me.GroupBox9.Controls.Add(Me.Label62)
        Me.GroupBox9.Controls.Add(Me.Label61)
        Me.GroupBox9.Controls.Add(Me.DtpkrSettldt)
        Me.GroupBox9.Controls.Add(Me.Label59)
        Me.GroupBox9.Controls.Add(Me.Label60)
        Me.GroupBox9.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(431, 201)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Providend Fund"
        '
        'TxtNewPfNo
        '
        Me.TxtNewPfNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNewPfNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNewPfNo.Location = New System.Drawing.Point(265, 96)
        Me.TxtNewPfNo.Name = "TxtNewPfNo"
        Me.TxtNewPfNo.Size = New System.Drawing.Size(95, 20)
        Me.TxtNewPfNo.TabIndex = 11
        Me.TxtNewPfNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label118
        '
        Me.Label118.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label118.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label118.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label118.Location = New System.Drawing.Point(147, 96)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(96, 20)
        Me.Label118.TabIndex = 10
        Me.Label118.Text = "New PF A/c No:- "
        '
        'ChkPFappli
        '
        Me.ChkPFappli.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPFappli.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPFappli.Location = New System.Drawing.Point(4, 18)
        Me.ChkPFappli.Name = "ChkPFappli"
        Me.ChkPFappli.Size = New System.Drawing.Size(110, 20)
        Me.ChkPFappli.TabIndex = 3
        Me.ChkPFappli.Text = "PF Applicable :-    "
        Me.ChkPFappli.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpkrPfJdt
        '
        Me.DtpkrPfJdt.CustomFormat = "dd\MM\yyyy"
        Me.DtpkrPfJdt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpkrPfJdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrPfJdt.Location = New System.Drawing.Point(265, 121)
        Me.DtpkrPfJdt.Name = "DtpkrPfJdt"
        Me.DtpkrPfJdt.Size = New System.Drawing.Size(85, 20)
        Me.DtpkrPfJdt.TabIndex = 1
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label57.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(142, 19)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(101, 20)
        Me.Label57.TabIndex = 0
        Me.Label57.Text = "Settlement Date :- "
        '
        'TxtVPpercnt
        '
        Me.TxtVPpercnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVPpercnt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVPpercnt.Location = New System.Drawing.Point(265, 172)
        Me.TxtVPpercnt.Name = "TxtVPpercnt"
        Me.TxtVPpercnt.Size = New System.Drawing.Size(48, 20)
        Me.TxtVPpercnt.TabIndex = 8
        '
        'TxtPFNo
        '
        Me.TxtPFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPFNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPFNo.Location = New System.Drawing.Point(265, 45)
        Me.TxtPFNo.Name = "TxtPFNo"
        Me.TxtPFNo.Size = New System.Drawing.Size(80, 20)
        Me.TxtPFNo.TabIndex = 9
        '
        'TxtAmtpf
        '
        Me.TxtAmtpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAmtpf.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmtpf.Location = New System.Drawing.Point(265, 70)
        Me.TxtAmtpf.Name = "TxtAmtpf"
        Me.TxtAmtpf.Size = New System.Drawing.Size(96, 20)
        Me.TxtAmtpf.TabIndex = 7
        Me.TxtAmtpf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTfrdamt
        '
        Me.TxtTfrdamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTfrdamt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTfrdamt.Location = New System.Drawing.Point(265, 147)
        Me.TxtTfrdamt.Name = "TxtTfrdamt"
        Me.TxtTfrdamt.Size = New System.Drawing.Size(96, 20)
        Me.TxtTfrdamt.TabIndex = 8
        Me.TxtTfrdamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(193, 121)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(50, 20)
        Me.Label58.TabIndex = 0
        Me.Label58.Text = "Date :- "
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label62.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(123, 44)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(120, 20)
        Me.Label62.TabIndex = 1
        Me.Label62.Text = "Previous PF A/c No:-"
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label61.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(48, 147)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(195, 20)
        Me.Label61.TabIndex = 1
        Me.Label61.Text = "Amount Transferred to New A/c:-"
        '
        'DtpkrSettldt
        '
        Me.DtpkrSettldt.CustomFormat = "dd\MM\yyyy"
        Me.DtpkrSettldt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpkrSettldt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrSettldt.Location = New System.Drawing.Point(265, 19)
        Me.DtpkrSettldt.Name = "DtpkrSettldt"
        Me.DtpkrSettldt.Size = New System.Drawing.Size(87, 20)
        Me.DtpkrSettldt.TabIndex = 0
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label59.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(171, 172)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(72, 20)
        Me.Label59.TabIndex = 7
        Me.Label59.Text = "VPF [%]  :- "
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label60.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(114, 70)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(129, 20)
        Me.Label60.TabIndex = 1
        Me.Label60.Text = "Settled Amount :- "
        '
        'TabPrev
        '
        Me.TabPrev.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPrev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPrev.Controls.Add(Me.GroupBox15)
        Me.TabPrev.Controls.Add(Me.GroupBox14)
        Me.TabPrev.Location = New System.Drawing.Point(4, 26)
        Me.TabPrev.Name = "TabPrev"
        Me.TabPrev.Size = New System.Drawing.Size(867, 472)
        Me.TabPrev.TabIndex = 4
        Me.TabPrev.Text = "Academic and  Experience Record"
        Me.TabPrev.UseVisualStyleBackColor = True
        Me.TabPrev.Visible = False
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.BtnExpCncl)
        Me.GroupBox15.Controls.Add(Me.BtExprDel)
        Me.GroupBox15.Controls.Add(Me.BtExprEd)
        Me.GroupBox15.Controls.Add(Me.BtExprAdd)
        Me.GroupBox15.Controls.Add(Me.DtpkrJndt)
        Me.GroupBox15.Controls.Add(Me.Lstvew2)
        Me.GroupBox15.Controls.Add(Me.Label68)
        Me.GroupBox15.Controls.Add(Me.Label74)
        Me.GroupBox15.Controls.Add(Me.Label75)
        Me.GroupBox15.Controls.Add(Me.Label76)
        Me.GroupBox15.Controls.Add(Me.Label77)
        Me.GroupBox15.Controls.Add(Me.TxtJnDesi)
        Me.GroupBox15.Controls.Add(Me.TxtLevdesi)
        Me.GroupBox15.Controls.Add(Me.Txtslry)
        Me.GroupBox15.Controls.Add(Me.TxtEmplr)
        Me.GroupBox15.Controls.Add(Me.DtpkrLevDt)
        Me.GroupBox15.Controls.Add(Me.Label78)
        Me.GroupBox15.Controls.Add(Me.Label79)
        Me.GroupBox15.Controls.Add(Me.Txtachive)
        Me.GroupBox15.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox15.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox15.Location = New System.Drawing.Point(8, 240)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(842, 228)
        Me.GroupBox15.TabIndex = 1
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Previous Experience Record"
        '
        'BtnExpCncl
        '
        Me.BtnExpCncl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExpCncl.ForeColor = System.Drawing.Color.Black
        Me.BtnExpCncl.Location = New System.Drawing.Point(744, 199)
        Me.BtnExpCncl.Name = "BtnExpCncl"
        Me.BtnExpCncl.Size = New System.Drawing.Size(75, 23)
        Me.BtnExpCncl.TabIndex = 8
        Me.BtnExpCncl.Text = "&Cancel"
        Me.BtnExpCncl.UseVisualStyleBackColor = True
        '
        'BtExprDel
        '
        Me.BtExprDel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtExprDel.ForeColor = System.Drawing.Color.Black
        Me.BtExprDel.Location = New System.Drawing.Point(648, 199)
        Me.BtExprDel.Name = "BtExprDel"
        Me.BtExprDel.Size = New System.Drawing.Size(75, 23)
        Me.BtExprDel.TabIndex = 7
        Me.BtExprDel.Text = "&Delete"
        Me.BtExprDel.UseVisualStyleBackColor = True
        '
        'BtExprEd
        '
        Me.BtExprEd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtExprEd.ForeColor = System.Drawing.Color.Black
        Me.BtExprEd.Location = New System.Drawing.Point(560, 199)
        Me.BtExprEd.Name = "BtExprEd"
        Me.BtExprEd.Size = New System.Drawing.Size(75, 23)
        Me.BtExprEd.TabIndex = 6
        Me.BtExprEd.Text = "&Update"
        Me.BtExprEd.UseVisualStyleBackColor = True
        '
        'BtExprAdd
        '
        Me.BtExprAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtExprAdd.ForeColor = System.Drawing.Color.Black
        Me.BtExprAdd.Location = New System.Drawing.Point(472, 199)
        Me.BtExprAdd.Name = "BtExprAdd"
        Me.BtExprAdd.Size = New System.Drawing.Size(75, 23)
        Me.BtExprAdd.TabIndex = 13
        Me.BtExprAdd.Text = "&Save"
        Me.BtExprAdd.UseVisualStyleBackColor = True
        '
        'DtpkrJndt
        '
        Me.DtpkrJndt.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrJndt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrJndt.Location = New System.Drawing.Point(176, 40)
        Me.DtpkrJndt.Name = "DtpkrJndt"
        Me.DtpkrJndt.Size = New System.Drawing.Size(88, 20)
        Me.DtpkrJndt.TabIndex = 7
        '
        'Lstvew2
        '
        Me.Lstvew2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.Lstvew2.ContextMenuStrip = Me.ContextMenuStrip3
        Me.Lstvew2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lstvew2.FullRowSelect = True
        Me.Lstvew2.GridLines = True
        Me.Lstvew2.Location = New System.Drawing.Point(8, 70)
        Me.Lstvew2.Name = "Lstvew2"
        Me.Lstvew2.Size = New System.Drawing.Size(810, 115)
        Me.Lstvew2.TabIndex = 3
        Me.Lstvew2.UseCompatibleStateImageBehavior = False
        Me.Lstvew2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Employer Name"
        Me.ColumnHeader8.Width = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Joining Date"
        Me.ColumnHeader9.Width = 100
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Leaving Date"
        Me.ColumnHeader10.Width = 100
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Joining as"
        Me.ColumnHeader11.Width = 110
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Leaving as"
        Me.ColumnHeader12.Width = 110
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Salary"
        Me.ColumnHeader13.Width = 95
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Achievement"
        Me.ColumnHeader14.Width = 140
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem2, Me.DeleteAllToolStripMenuItem2})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(125, 48)
        '
        'DeleteToolStripMenuItem2
        '
        Me.DeleteToolStripMenuItem2.Name = "DeleteToolStripMenuItem2"
        Me.DeleteToolStripMenuItem2.Size = New System.Drawing.Size(124, 22)
        Me.DeleteToolStripMenuItem2.Text = "Delete"
        '
        'DeleteAllToolStripMenuItem2
        '
        Me.DeleteAllToolStripMenuItem2.Name = "DeleteAllToolStripMenuItem2"
        Me.DeleteAllToolStripMenuItem2.Size = New System.Drawing.Size(124, 22)
        Me.DeleteAllToolStripMenuItem2.Text = "Delete All"
        '
        'Label68
        '
        Me.Label68.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label68.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.Black
        Me.Label68.Location = New System.Drawing.Point(8, 16)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(96, 20)
        Me.Label68.TabIndex = 0
        Me.Label68.Text = "Employer Name"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label74
        '
        Me.Label74.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label74.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.Black
        Me.Label74.Location = New System.Drawing.Point(176, 16)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(72, 20)
        Me.Label74.TabIndex = 0
        Me.Label74.Text = "Joining Dt."
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label75.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.Black
        Me.Label75.Location = New System.Drawing.Point(368, 16)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(74, 20)
        Me.Label75.TabIndex = 0
        Me.Label75.Text = "Joining as "
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label76
        '
        Me.Label76.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label76.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.Black
        Me.Label76.Location = New System.Drawing.Point(472, 16)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(80, 20)
        Me.Label76.TabIndex = 0
        Me.Label76.Text = "Leaving as"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label77
        '
        Me.Label77.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label77.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.Black
        Me.Label77.Location = New System.Drawing.Point(582, 16)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(48, 20)
        Me.Label77.TabIndex = 0
        Me.Label77.Text = "Salary "
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtJnDesi
        '
        Me.TxtJnDesi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtJnDesi.Location = New System.Drawing.Point(368, 40)
        Me.TxtJnDesi.Name = "TxtJnDesi"
        Me.TxtJnDesi.Size = New System.Drawing.Size(96, 20)
        Me.TxtJnDesi.TabIndex = 9
        '
        'TxtLevdesi
        '
        Me.TxtLevdesi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtLevdesi.Location = New System.Drawing.Point(472, 40)
        Me.TxtLevdesi.Name = "TxtLevdesi"
        Me.TxtLevdesi.Size = New System.Drawing.Size(96, 20)
        Me.TxtLevdesi.TabIndex = 10
        '
        'Txtslry
        '
        Me.Txtslry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtslry.Location = New System.Drawing.Point(582, 40)
        Me.Txtslry.Name = "Txtslry"
        Me.Txtslry.Size = New System.Drawing.Size(64, 20)
        Me.Txtslry.TabIndex = 11
        Me.Txtslry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtEmplr
        '
        Me.TxtEmplr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtEmplr.Location = New System.Drawing.Point(8, 40)
        Me.TxtEmplr.Name = "TxtEmplr"
        Me.TxtEmplr.Size = New System.Drawing.Size(160, 20)
        Me.TxtEmplr.TabIndex = 6
        '
        'DtpkrLevDt
        '
        Me.DtpkrLevDt.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrLevDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrLevDt.Location = New System.Drawing.Point(272, 40)
        Me.DtpkrLevDt.Name = "DtpkrLevDt"
        Me.DtpkrLevDt.Size = New System.Drawing.Size(88, 20)
        Me.DtpkrLevDt.TabIndex = 8
        '
        'Label78
        '
        Me.Label78.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label78.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.ForeColor = System.Drawing.Color.Black
        Me.Label78.Location = New System.Drawing.Point(272, 16)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(72, 20)
        Me.Label78.TabIndex = 0
        Me.Label78.Text = "Leaving Dt."
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label79
        '
        Me.Label79.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label79.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label79.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.Black
        Me.Label79.Location = New System.Drawing.Point(675, 16)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(88, 20)
        Me.Label79.TabIndex = 0
        Me.Label79.Text = "Achievements"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtachive
        '
        Me.Txtachive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtachive.Location = New System.Drawing.Point(675, 40)
        Me.Txtachive.Name = "Txtachive"
        Me.Txtachive.Size = New System.Drawing.Size(104, 20)
        Me.Txtachive.TabIndex = 12
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.Txtpassyr)
        Me.GroupBox14.Controls.Add(Me.BtnAcadCncl)
        Me.GroupBox14.Controls.Add(Me.BtnAcadEd)
        Me.GroupBox14.Controls.Add(Me.BtnAcadDel)
        Me.GroupBox14.Controls.Add(Me.BtnAcadad)
        Me.GroupBox14.Controls.Add(Me.Lstvew1)
        Me.GroupBox14.Controls.Add(Me.CmbxDegree)
        Me.GroupBox14.Controls.Add(Me.Label69)
        Me.GroupBox14.Controls.Add(Me.Label70)
        Me.GroupBox14.Controls.Add(Me.Label71)
        Me.GroupBox14.Controls.Add(Me.Label72)
        Me.GroupBox14.Controls.Add(Me.Label73)
        Me.GroupBox14.Controls.Add(Me.Txtsubjts)
        Me.GroupBox14.Controls.Add(Me.TxtInsti)
        Me.GroupBox14.Controls.Add(Me.CmbxClass)
        Me.GroupBox14.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox14.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox14.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(842, 226)
        Me.GroupBox14.TabIndex = 0
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Academic Details"
        '
        'Txtpassyr
        '
        Me.Txtpassyr.Location = New System.Drawing.Point(193, 42)
        Me.Txtpassyr.Maximum = New Decimal(New Integer() {2059, 0, 0, 0})
        Me.Txtpassyr.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.Txtpassyr.Name = "Txtpassyr"
        Me.Txtpassyr.Size = New System.Drawing.Size(55, 20)
        Me.Txtpassyr.TabIndex = 1
        Me.Txtpassyr.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'BtnAcadCncl
        '
        Me.BtnAcadCncl.ForeColor = System.Drawing.Color.Black
        Me.BtnAcadCncl.Location = New System.Drawing.Point(743, 190)
        Me.BtnAcadCncl.Name = "BtnAcadCncl"
        Me.BtnAcadCncl.Size = New System.Drawing.Size(75, 23)
        Me.BtnAcadCncl.TabIndex = 6
        Me.BtnAcadCncl.Text = "&Cancel"
        Me.BtnAcadCncl.UseVisualStyleBackColor = True
        '
        'BtnAcadEd
        '
        Me.BtnAcadEd.ForeColor = System.Drawing.Color.Black
        Me.BtnAcadEd.Location = New System.Drawing.Point(559, 190)
        Me.BtnAcadEd.Name = "BtnAcadEd"
        Me.BtnAcadEd.Size = New System.Drawing.Size(75, 23)
        Me.BtnAcadEd.TabIndex = 4
        Me.BtnAcadEd.Text = "&Update"
        Me.BtnAcadEd.UseVisualStyleBackColor = True
        '
        'BtnAcadDel
        '
        Me.BtnAcadDel.ForeColor = System.Drawing.Color.Black
        Me.BtnAcadDel.Location = New System.Drawing.Point(647, 190)
        Me.BtnAcadDel.Name = "BtnAcadDel"
        Me.BtnAcadDel.Size = New System.Drawing.Size(75, 23)
        Me.BtnAcadDel.TabIndex = 5
        Me.BtnAcadDel.Text = "&Delete"
        Me.BtnAcadDel.UseVisualStyleBackColor = True
        '
        'BtnAcadad
        '
        Me.BtnAcadad.ForeColor = System.Drawing.Color.Black
        Me.BtnAcadad.Location = New System.Drawing.Point(471, 190)
        Me.BtnAcadad.Name = "BtnAcadad"
        Me.BtnAcadad.Size = New System.Drawing.Size(75, 23)
        Me.BtnAcadad.TabIndex = 5
        Me.BtnAcadad.Text = "&Save"
        Me.BtnAcadad.UseVisualStyleBackColor = True
        '
        'Lstvew1
        '
        Me.Lstvew1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.Lstvew1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.Lstvew1.FullRowSelect = True
        Me.Lstvew1.GridLines = True
        Me.Lstvew1.Location = New System.Drawing.Point(14, 70)
        Me.Lstvew1.Name = "Lstvew1"
        Me.Lstvew1.Size = New System.Drawing.Size(805, 114)
        Me.Lstvew1.TabIndex = 3
        Me.Lstvew1.UseCompatibleStateImageBehavior = False
        Me.Lstvew1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Certi/Degree"
        Me.ColumnHeader3.Width = 170
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Year"
        Me.ColumnHeader4.Width = 90
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Class"
        Me.ColumnHeader5.Width = 90
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Subjects"
        Me.ColumnHeader6.Width = 200
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Institution"
        Me.ColumnHeader7.Width = 250
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem1, Me.DeleteAllToolStripMenuItem1})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(125, 48)
        '
        'DeleteToolStripMenuItem1
        '
        Me.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1"
        Me.DeleteToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.DeleteToolStripMenuItem1.Text = "Delete"
        '
        'DeleteAllToolStripMenuItem1
        '
        Me.DeleteAllToolStripMenuItem1.Name = "DeleteAllToolStripMenuItem1"
        Me.DeleteAllToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.DeleteAllToolStripMenuItem1.Text = "Delete All"
        '
        'CmbxDegree
        '
        Me.CmbxDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxDegree.Items.AddRange(New Object() {"Matric", "Senior Secondary", "Diploma", "BA", "BCA", "B.Com", "BBA", "B.Sc(Medical)", "B.Sc(Non-Medical)", "B.Sc(IT)", "B.Tech", "MA", "MCA", "M.Com", "MBA", "M.Sc(Medical)", "M.Sc(Non-Medical)", "M.Sc(IT)", "M.Tech", "PGDCA"})
        Me.CmbxDegree.Location = New System.Drawing.Point(16, 40)
        Me.CmbxDegree.Name = "CmbxDegree"
        Me.CmbxDegree.Size = New System.Drawing.Size(167, 22)
        Me.CmbxDegree.TabIndex = 0
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label69.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.ForeColor = System.Drawing.Color.Black
        Me.Label69.Location = New System.Drawing.Point(16, 16)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(152, 20)
        Me.Label69.TabIndex = 0
        Me.Label69.Text = "Certificate/Degree Course "
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label70
        '
        Me.Label70.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label70.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.ForeColor = System.Drawing.Color.Black
        Me.Label70.Location = New System.Drawing.Point(194, 16)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(48, 20)
        Me.Label70.TabIndex = 0
        Me.Label70.Text = "Year "
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label71
        '
        Me.Label71.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label71.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label71.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.ForeColor = System.Drawing.Color.Black
        Me.Label71.Location = New System.Drawing.Point(282, 16)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(48, 20)
        Me.Label71.TabIndex = 0
        Me.Label71.Text = "Class"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label72
        '
        Me.Label72.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label72.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.Black
        Me.Label72.Location = New System.Drawing.Point(368, 16)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(64, 20)
        Me.Label72.TabIndex = 0
        Me.Label72.Text = "Subjects "
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label73
        '
        Me.Label73.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label73.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.Black
        Me.Label73.Location = New System.Drawing.Point(567, 16)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(136, 20)
        Me.Label73.TabIndex = 0
        Me.Label73.Text = "Name of the Institution "
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtsubjts
        '
        Me.Txtsubjts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtsubjts.Location = New System.Drawing.Point(368, 40)
        Me.Txtsubjts.Name = "Txtsubjts"
        Me.Txtsubjts.Size = New System.Drawing.Size(168, 20)
        Me.Txtsubjts.TabIndex = 3
        '
        'TxtInsti
        '
        Me.TxtInsti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInsti.Location = New System.Drawing.Point(567, 40)
        Me.TxtInsti.Name = "TxtInsti"
        Me.TxtInsti.Size = New System.Drawing.Size(256, 20)
        Me.TxtInsti.TabIndex = 4
        '
        'CmbxClass
        '
        Me.CmbxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxClass.Items.AddRange(New Object() {"1st Class", "2nd Class", "3rd Class"})
        Me.CmbxClass.Location = New System.Drawing.Point(280, 40)
        Me.CmbxClass.Name = "CmbxClass"
        Me.CmbxClass.Size = New System.Drawing.Size(64, 22)
        Me.CmbxClass.TabIndex = 2
        '
        'TabConfrmltr
        '
        Me.TabConfrmltr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabConfrmltr.Controls.Add(Me.BtnCnfrmBrws)
        Me.TabConfrmltr.Controls.Add(Me.RchtxtCnfrmltr)
        Me.TabConfrmltr.Location = New System.Drawing.Point(4, 26)
        Me.TabConfrmltr.Name = "TabConfrmltr"
        Me.TabConfrmltr.Size = New System.Drawing.Size(867, 472)
        Me.TabConfrmltr.TabIndex = 6
        Me.TabConfrmltr.Text = "Confirmation Letter"
        Me.TabConfrmltr.UseVisualStyleBackColor = True
        Me.TabConfrmltr.Visible = False
        '
        'BtnCnfrmBrws
        '
        Me.BtnCnfrmBrws.Location = New System.Drawing.Point(777, 398)
        Me.BtnCnfrmBrws.Name = "BtnCnfrmBrws"
        Me.BtnCnfrmBrws.Size = New System.Drawing.Size(74, 24)
        Me.BtnCnfrmBrws.TabIndex = 1
        Me.BtnCnfrmBrws.Text = "&Browse"
        Me.BtnCnfrmBrws.UseVisualStyleBackColor = True
        '
        'RchtxtCnfrmltr
        '
        Me.RchtxtCnfrmltr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RchtxtCnfrmltr.Location = New System.Drawing.Point(8, 8)
        Me.RchtxtCnfrmltr.Name = "RchtxtCnfrmltr"
        Me.RchtxtCnfrmltr.Size = New System.Drawing.Size(848, 384)
        Me.RchtxtCnfrmltr.TabIndex = 0
        Me.RchtxtCnfrmltr.Text = ""
        '
        'TabOthrs
        '
        Me.TabOthrs.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabOthrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabOthrs.Controls.Add(Me.GroupBox18)
        Me.TabOthrs.Controls.Add(Me.GroupBox17)
        Me.TabOthrs.Controls.Add(Me.TxtBnkMandte)
        Me.TabOthrs.Location = New System.Drawing.Point(4, 26)
        Me.TabOthrs.Name = "TabOthrs"
        Me.TabOthrs.Size = New System.Drawing.Size(867, 472)
        Me.TabOthrs.TabIndex = 8
        Me.TabOthrs.Text = "Others"
        Me.TabOthrs.UseVisualStyleBackColor = True
        Me.TabOthrs.Visible = False
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.Label7)
        Me.GroupBox18.Controls.Add(Me.RbReject)
        Me.GroupBox18.Controls.Add(Me.RbAccept)
        Me.GroupBox18.Controls.Add(Me.DtpkrSubmit)
        Me.GroupBox18.Controls.Add(Me.Label102)
        Me.GroupBox18.Controls.Add(Me.Label103)
        Me.GroupBox18.Controls.Add(Me.Label104)
        Me.GroupBox18.Controls.Add(Me.TxtReason)
        Me.GroupBox18.Controls.Add(Me.DtpkrAccept)
        Me.GroupBox18.Controls.Add(Me.DtpkrRelev)
        Me.GroupBox18.Controls.Add(Me.Label105)
        Me.GroupBox18.Controls.Add(Me.Label106)
        Me.GroupBox18.Controls.Add(Me.TxtRemks)
        Me.GroupBox18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox18.Location = New System.Drawing.Point(433, 0)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(417, 416)
        Me.GroupBox18.TabIndex = 2
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Resignation"
        Me.GroupBox18.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 20)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Resignation:- "
        '
        'RbReject
        '
        Me.RbReject.AutoSize = True
        Me.RbReject.Location = New System.Drawing.Point(239, 52)
        Me.RbReject.Name = "RbReject"
        Me.RbReject.Size = New System.Drawing.Size(73, 18)
        Me.RbReject.TabIndex = 11
        Me.RbReject.TabStop = True
        Me.RbReject.Text = "Rejected"
        Me.RbReject.UseVisualStyleBackColor = True
        '
        'RbAccept
        '
        Me.RbAccept.AutoSize = True
        Me.RbAccept.Location = New System.Drawing.Point(145, 52)
        Me.RbAccept.Name = "RbAccept"
        Me.RbAccept.Size = New System.Drawing.Size(77, 18)
        Me.RbAccept.TabIndex = 10
        Me.RbAccept.TabStop = True
        Me.RbAccept.Text = "Accepted"
        Me.RbAccept.UseVisualStyleBackColor = True
        '
        'DtpkrSubmit
        '
        Me.DtpkrSubmit.CustomFormat = "dd\MM\yyyy"
        Me.DtpkrSubmit.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrSubmit.Location = New System.Drawing.Point(145, 18)
        Me.DtpkrSubmit.Name = "DtpkrSubmit"
        Me.DtpkrSubmit.Size = New System.Drawing.Size(96, 20)
        Me.DtpkrSubmit.TabIndex = 9
        '
        'Label102
        '
        Me.Label102.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label102.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label102.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label102.Location = New System.Drawing.Point(8, 20)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(120, 20)
        Me.Label102.TabIndex = 2
        Me.Label102.Text = "Date of Submitting:-                                       "
        '
        'Label103
        '
        Me.Label103.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label103.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label103.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.Location = New System.Drawing.Point(8, 83)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(120, 20)
        Me.Label103.TabIndex = 2
        Me.Label103.Text = "Date of Accepting:-                                        "
        '
        'Label104
        '
        Me.Label104.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label104.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.Location = New System.Drawing.Point(32, 117)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(96, 20)
        Me.Label104.TabIndex = 2
        Me.Label104.Text = " Releave Date:-                                      "
        '
        'TxtReason
        '
        Me.TxtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtReason.Location = New System.Drawing.Point(119, 156)
        Me.TxtReason.Multiline = True
        Me.TxtReason.Name = "TxtReason"
        Me.TxtReason.Size = New System.Drawing.Size(236, 110)
        Me.TxtReason.TabIndex = 14
        '
        'DtpkrAccept
        '
        Me.DtpkrAccept.Checked = False
        Me.DtpkrAccept.CustomFormat = "dd\MM\yyyy"
        Me.DtpkrAccept.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrAccept.Location = New System.Drawing.Point(145, 81)
        Me.DtpkrAccept.Name = "DtpkrAccept"
        Me.DtpkrAccept.ShowCheckBox = True
        Me.DtpkrAccept.Size = New System.Drawing.Size(96, 20)
        Me.DtpkrAccept.TabIndex = 12
        '
        'DtpkrRelev
        '
        Me.DtpkrRelev.CustomFormat = "dd\MM\yyyy"
        Me.DtpkrRelev.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrRelev.Location = New System.Drawing.Point(145, 115)
        Me.DtpkrRelev.Name = "DtpkrRelev"
        Me.DtpkrRelev.Size = New System.Drawing.Size(96, 20)
        Me.DtpkrRelev.TabIndex = 13
        '
        'Label105
        '
        Me.Label105.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label105.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label105.Location = New System.Drawing.Point(8, 156)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(87, 32)
        Me.Label105.TabIndex = 2
        Me.Label105.Text = "Reason of Resignation:-         "
        '
        'Label106
        '
        Me.Label106.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label106.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label106.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.Location = New System.Drawing.Point(13, 291)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(82, 24)
        Me.Label106.TabIndex = 2
        Me.Label106.Text = "Remarks:-                                    "
        '
        'TxtRemks
        '
        Me.TxtRemks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRemks.Location = New System.Drawing.Point(118, 291)
        Me.TxtRemks.Multiline = True
        Me.TxtRemks.Name = "TxtRemks"
        Me.TxtRemks.Size = New System.Drawing.Size(236, 106)
        Me.TxtRemks.TabIndex = 15
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.ChkBxResi)
        Me.GroupBox17.Controls.Add(Me.Label13)
        Me.GroupBox17.Controls.Add(Me.Label99)
        Me.GroupBox17.Controls.Add(Me.TxtMobile)
        Me.GroupBox17.Controls.Add(Me.Label100)
        Me.GroupBox17.Controls.Add(Me.Txtlaptop)
        Me.GroupBox17.Controls.Add(Me.Label101)
        Me.GroupBox17.Controls.Add(Me.Txtmailid)
        Me.GroupBox17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox17.Location = New System.Drawing.Point(8, 240)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(406, 176)
        Me.GroupBox17.TabIndex = 1
        Me.GroupBox17.TabStop = False
        '
        'ChkBxResi
        '
        Me.ChkBxResi.AutoSize = True
        Me.ChkBxResi.Location = New System.Drawing.Point(226, 143)
        Me.ChkBxResi.Name = "ChkBxResi"
        Me.ChkBxResi.Size = New System.Drawing.Size(15, 14)
        Me.ChkBxResi.TabIndex = 10
        Me.ChkBxResi.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(94, 142)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 20)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Resignation:-"
        '
        'Label99
        '
        Me.Label99.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label99.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label99.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.Location = New System.Drawing.Point(6, 16)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(184, 20)
        Me.Label99.TabIndex = 2
        Me.Label99.Text = "Company Provided Mobile No:-"
        '
        'TxtMobile
        '
        Me.TxtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMobile.Location = New System.Drawing.Point(202, 16)
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(176, 20)
        Me.TxtMobile.TabIndex = 6
        '
        'Label100
        '
        Me.Label100.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label100.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.Location = New System.Drawing.Point(22, 58)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(168, 20)
        Me.Label100.TabIndex = 2
        Me.Label100.Text = "Company Provided Lap Top:-"
        '
        'Txtlaptop
        '
        Me.Txtlaptop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtlaptop.Location = New System.Drawing.Point(202, 57)
        Me.Txtlaptop.Name = "Txtlaptop"
        Me.Txtlaptop.Size = New System.Drawing.Size(176, 20)
        Me.Txtlaptop.TabIndex = 7
        '
        'Label101
        '
        Me.Label101.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label101.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.Location = New System.Drawing.Point(30, 104)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(160, 20)
        Me.Label101.TabIndex = 2
        Me.Label101.Text = "Company  Alloted Mail Id:-"
        '
        'Txtmailid
        '
        Me.Txtmailid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtmailid.Location = New System.Drawing.Point(202, 103)
        Me.Txtmailid.Name = "Txtmailid"
        Me.Txtmailid.Size = New System.Drawing.Size(176, 20)
        Me.Txtmailid.TabIndex = 8
        '
        'TxtBnkMandte
        '
        Me.TxtBnkMandte.Controls.Add(Me.TxtRecAgncy)
        Me.TxtBnkMandte.Controls.Add(Me.Label91)
        Me.TxtBnkMandte.Controls.Add(Me.Label94)
        Me.TxtBnkMandte.Controls.Add(Me.Label96)
        Me.TxtBnkMandte.Controls.Add(Me.Label97)
        Me.TxtBnkMandte.Controls.Add(Me.TxtTptRute)
        Me.TxtBnkMandte.Controls.Add(Me.cmbxWrkLoc)
        Me.TxtBnkMandte.Controls.Add(Me.Label98)
        Me.TxtBnkMandte.Controls.Add(Me.txtCoVeclNo)
        Me.TxtBnkMandte.Controls.Add(Me.CmbxCoVeclType)
        Me.TxtBnkMandte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBnkMandte.Location = New System.Drawing.Point(8, 0)
        Me.TxtBnkMandte.Name = "TxtBnkMandte"
        Me.TxtBnkMandte.Size = New System.Drawing.Size(406, 232)
        Me.TxtBnkMandte.TabIndex = 0
        Me.TxtBnkMandte.TabStop = False
        '
        'TxtRecAgncy
        '
        Me.TxtRecAgncy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRecAgncy.Location = New System.Drawing.Point(156, 18)
        Me.TxtRecAgncy.Name = "TxtRecAgncy"
        Me.TxtRecAgncy.Size = New System.Drawing.Size(216, 20)
        Me.TxtRecAgncy.TabIndex = 1
        '
        'Label91
        '
        Me.Label91.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label91.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label91.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.Location = New System.Drawing.Point(22, 18)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(128, 20)
        Me.Label91.TabIndex = 0
        Me.Label91.Text = "Recuritment Agency:- "
        '
        'Label94
        '
        Me.Label94.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label94.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label94.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.Location = New System.Drawing.Point(30, 57)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(120, 20)
        Me.Label94.TabIndex = 0
        Me.Label94.Text = "Transport Route:-"
        '
        'Label96
        '
        Me.Label96.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label96.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label96.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label96.Location = New System.Drawing.Point(54, 97)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(96, 20)
        Me.Label96.TabIndex = 0
        Me.Label96.Text = "Work Location:-"
        '
        'Label97
        '
        Me.Label97.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label97.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label97.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label97.Location = New System.Drawing.Point(6, 142)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(144, 20)
        Me.Label97.TabIndex = 0
        Me.Label97.Text = "Company Vehicle Type:-"
        '
        'TxtTptRute
        '
        Me.TxtTptRute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTptRute.Location = New System.Drawing.Point(156, 57)
        Me.TxtTptRute.Name = "TxtTptRute"
        Me.TxtTptRute.Size = New System.Drawing.Size(216, 20)
        Me.TxtTptRute.TabIndex = 2
        '
        'cmbxWrkLoc
        '
        Me.cmbxWrkLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxWrkLoc.Location = New System.Drawing.Point(156, 95)
        Me.cmbxWrkLoc.Name = "cmbxWrkLoc"
        Me.cmbxWrkLoc.Size = New System.Drawing.Size(136, 22)
        Me.cmbxWrkLoc.TabIndex = 3
        '
        'Label98
        '
        Me.Label98.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label98.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label98.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.Location = New System.Drawing.Point(8, 189)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(142, 20)
        Me.Label98.TabIndex = 0
        Me.Label98.Text = "Company Vehicle No:-"
        '
        'txtCoVeclNo
        '
        Me.txtCoVeclNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoVeclNo.Location = New System.Drawing.Point(156, 188)
        Me.txtCoVeclNo.Name = "txtCoVeclNo"
        Me.txtCoVeclNo.Size = New System.Drawing.Size(216, 20)
        Me.txtCoVeclNo.TabIndex = 5
        '
        'CmbxCoVeclType
        '
        Me.CmbxCoVeclType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCoVeclType.Items.AddRange(New Object() {"None", "Cycle", "Moped", "Scooter", "Motor Cycle", "Car"})
        Me.CmbxCoVeclType.Location = New System.Drawing.Point(156, 140)
        Me.CmbxCoVeclType.Name = "CmbxCoVeclType"
        Me.CmbxCoVeclType.Size = New System.Drawing.Size(136, 22)
        Me.CmbxCoVeclType.TabIndex = 4
        '
        'TabSlryBrkup
        '
        Me.TabSlryBrkup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabSlryBrkup.Controls.Add(Me.GroupBox3)
        Me.TabSlryBrkup.Location = New System.Drawing.Point(4, 26)
        Me.TabSlryBrkup.Name = "TabSlryBrkup"
        Me.TabSlryBrkup.Size = New System.Drawing.Size(867, 472)
        Me.TabSlryBrkup.TabIndex = 9
        Me.TabSlryBrkup.Text = " Salary Breakup"
        Me.TabSlryBrkup.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel8)
        Me.GroupBox3.Controls.Add(Me.Label117)
        Me.GroupBox3.Controls.Add(Me.Label116)
        Me.GroupBox3.Controls.Add(Me.LblGrossSlry)
        Me.GroupBox3.Controls.Add(Me.Label114)
        Me.GroupBox3.Controls.Add(Me.Panel7)
        Me.GroupBox3.Controls.Add(Me.Panel6)
        Me.GroupBox3.Controls.Add(Me.Label110)
        Me.GroupBox3.Controls.Add(Me.LstvewPhed)
        Me.GroupBox3.Controls.Add(Me.Label92)
        Me.GroupBox3.Location = New System.Drawing.Point(19, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(841, 423)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.RbNoCmpo)
        Me.Panel8.Controls.Add(Me.RbYesCmpo)
        Me.Panel8.Location = New System.Drawing.Point(185, 64)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(184, 21)
        Me.Panel8.TabIndex = 22
        '
        'RbNoCmpo
        '
        Me.RbNoCmpo.AutoSize = True
        Me.RbNoCmpo.Location = New System.Drawing.Point(103, 3)
        Me.RbNoCmpo.Name = "RbNoCmpo"
        Me.RbNoCmpo.Size = New System.Drawing.Size(39, 18)
        Me.RbNoCmpo.TabIndex = 20
        Me.RbNoCmpo.Text = "No"
        Me.RbNoCmpo.UseVisualStyleBackColor = True
        '
        'RbYesCmpo
        '
        Me.RbYesCmpo.AutoSize = True
        Me.RbYesCmpo.Location = New System.Drawing.Point(3, 3)
        Me.RbYesCmpo.Name = "RbYesCmpo"
        Me.RbYesCmpo.Size = New System.Drawing.Size(46, 18)
        Me.RbYesCmpo.TabIndex = 19
        Me.RbYesCmpo.Text = "Yes"
        Me.RbYesCmpo.UseVisualStyleBackColor = True
        '
        'Label117
        '
        Me.Label117.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label117.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label117.ForeColor = System.Drawing.Color.Black
        Me.Label117.Location = New System.Drawing.Point(18, 64)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(139, 21)
        Me.Label117.TabIndex = 21
        Me.Label117.Text = "Compensatory Off :-"
        Me.Label117.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label116
        '
        Me.Label116.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label116.ForeColor = System.Drawing.Color.Black
        Me.Label116.Location = New System.Drawing.Point(807, 382)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(27, 21)
        Me.Label116.TabIndex = 20
        Me.Label116.Text = "Rs."
        Me.Label116.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblGrossSlry
        '
        Me.LblGrossSlry.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblGrossSlry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblGrossSlry.ForeColor = System.Drawing.Color.Black
        Me.LblGrossSlry.Location = New System.Drawing.Point(708, 382)
        Me.LblGrossSlry.Name = "LblGrossSlry"
        Me.LblGrossSlry.Size = New System.Drawing.Size(95, 21)
        Me.LblGrossSlry.TabIndex = 19
        Me.LblGrossSlry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label114
        '
        Me.Label114.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label114.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label114.ForeColor = System.Drawing.Color.Black
        Me.Label114.Location = New System.Drawing.Point(600, 382)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(95, 21)
        Me.Label114.TabIndex = 18
        Me.Label114.Text = "Gross Salary:-"
        Me.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.RbNoPhed)
        Me.Panel7.Controls.Add(Me.RbYes_Phed)
        Me.Panel7.Location = New System.Drawing.Point(185, 100)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(184, 21)
        Me.Panel7.TabIndex = 17
        '
        'RbNoPhed
        '
        Me.RbNoPhed.AutoSize = True
        Me.RbNoPhed.Location = New System.Drawing.Point(103, 3)
        Me.RbNoPhed.Name = "RbNoPhed"
        Me.RbNoPhed.Size = New System.Drawing.Size(39, 18)
        Me.RbNoPhed.TabIndex = 22
        Me.RbNoPhed.Text = "No"
        Me.RbNoPhed.UseVisualStyleBackColor = True
        '
        'RbYes_Phed
        '
        Me.RbYes_Phed.AutoSize = True
        Me.RbYes_Phed.Location = New System.Drawing.Point(3, 3)
        Me.RbYes_Phed.Name = "RbYes_Phed"
        Me.RbYes_Phed.Size = New System.Drawing.Size(46, 18)
        Me.RbYes_Phed.TabIndex = 21
        Me.RbYes_Phed.Text = "Yes"
        Me.RbYes_Phed.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.RbYes)
        Me.Panel6.Controls.Add(Me.RbNo)
        Me.Panel6.Location = New System.Drawing.Point(185, 27)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(184, 22)
        Me.Panel6.TabIndex = 16
        '
        'RbYes
        '
        Me.RbYes.AutoSize = True
        Me.RbYes.Location = New System.Drawing.Point(3, 1)
        Me.RbYes.Name = "RbYes"
        Me.RbYes.Size = New System.Drawing.Size(46, 18)
        Me.RbYes.TabIndex = 17
        Me.RbYes.Text = "Yes"
        Me.RbYes.UseVisualStyleBackColor = True
        '
        'RbNo
        '
        Me.RbNo.AutoSize = True
        Me.RbNo.Location = New System.Drawing.Point(103, 1)
        Me.RbNo.Name = "RbNo"
        Me.RbNo.Size = New System.Drawing.Size(39, 18)
        Me.RbNo.TabIndex = 18
        Me.RbNo.Text = "No"
        Me.RbNo.UseVisualStyleBackColor = True
        '
        'Label110
        '
        Me.Label110.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label110.ForeColor = System.Drawing.Color.Black
        Me.Label110.Location = New System.Drawing.Point(18, 27)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(139, 21)
        Me.Label110.TabIndex = 10
        Me.Label110.Text = "OverTime Applicable :-"
        Me.Label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LstvewPhed
        '
        Me.LstvewPhed.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
        Me.LstvewPhed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstvewPhed.CheckBoxes = True
        Me.LstvewPhed.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader15, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader23, Me.ColumnHeader24})
        Me.LstvewPhed.GridLines = True
        Me.LstvewPhed.Location = New System.Drawing.Point(185, 139)
        Me.LstvewPhed.Name = "LstvewPhed"
        Me.LstvewPhed.Size = New System.Drawing.Size(645, 227)
        Me.LstvewPhed.TabIndex = 23
        Me.LstvewPhed.UseCompatibleStateImageBehavior = False
        Me.LstvewPhed.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Payhead Name"
        Me.ColumnHeader15.Width = 160
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Payhead Id"
        Me.ColumnHeader19.Width = 0
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Display Name"
        Me.ColumnHeader20.Width = 160
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Type"
        Me.ColumnHeader21.Width = 200
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "PhedType"
        Me.ColumnHeader23.Width = 0
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Amount(Rs.)"
        Me.ColumnHeader24.Width = 120
        '
        'Label92
        '
        Me.Label92.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label92.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label92.ForeColor = System.Drawing.Color.Black
        Me.Label92.Location = New System.Drawing.Point(18, 100)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(139, 21)
        Me.Label92.TabIndex = 8
        Me.Label92.Text = "Payheads Applicable :-"
        Me.Label92.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'OpenFileDialog3
        '
        Me.OpenFileDialog3.FileName = "OpenFileDialog3"
        '
        'FrmPayRoll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(896, 552)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmPayRoll"
        Me.Text = "Pay Roll Section"
        Me.Panel1.ResumeLayout(False)
        Me.PayRolTab.ResumeLayout(False)
        Me.TabMstr.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.txtprobation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.EmpImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Grpbxbnk.ResumeLayout(False)
        Me.Grpbxbnk.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabAppLtr.ResumeLayout(False)
        Me.TabPrsonl.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.NoHtFt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPfEsi.ResumeLayout(False)
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        CType(Me.Nodepnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.TabPrev.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        CType(Me.Txtpassyr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.TabConfrmltr.ResumeLayout(False)
        Me.TabOthrs.ResumeLayout(False)
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.TxtBnkMandte.ResumeLayout(False)
        Me.TxtBnkMandte.PerformLayout()
        Me.TabSlryBrkup.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub DtpkrPfJdt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrPfJdt.GotFocus
        DtpkrPfJdt.Value = DtpkrSettldt.Value.Date.AddDays(-1)

        DtpkrPfJdt.MaxDate = DtpkrSettldt.Value.Date
    End Sub


    Private Sub fetch_rec()
        Try
            Info_Cty_Cmd = New SqlCommand("select cscid,cscctyname from FinactCscmstr where csctype='" & (ctytype) & "'", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            While Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    Cmbxctynomi.Items.Add(Info_Cty_Rdr("cscctyname"))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()

        End Try
    End Sub

    Private Sub fill_grid()
        Dim rowcnt As Integer = 0
        'FrmNmDetails.DataGridView1.Rows.Clear()
        dgr = New DataGridViewRow()


        cel = New DataGridViewTextBoxCell()
        cel.Value = TxtNomine.Text
        dgr.Cells.Add(cel)

        com = New DataGridViewComboBoxCell
        com.Items.Add("Father")
        com.Items.Add("Mother")
        com.Items.Add("Brother")
        com.Items.Add("Sister")
        com.Items.Add("Daughter")
        com.Items.Add("Son")
        com.Items.Add("Wife")

        relatn = cmbxrelt.Text
        If relatn = "Father" Then
            com.Value = com.Items(0)
        ElseIf relatn = "Mother" Then
            com.Value = com.Items(1)
        ElseIf relatn = "Brother" Then
            com.Value = com.Items(2)
        ElseIf relatn = "Sister" Then
            com.Value = com.Items(3)
        ElseIf relatn = "Daughter" Then
            com.Value = com.Items(4)
        ElseIf relatn = "Son" Then
            com.Value = com.Items(5)
        ElseIf relatn = "Wife" Then
            com.Value = com.Items(6)
        End If

        dgr.Cells.Add(com)


        com = New DataGridViewComboBoxCell
        com.Items.Add("Major")
        com.Items.Add("Minor")

        Status = cmbxstatus.Text
        If Status = "Minor" Then
            com.Value = com.Items(1)
        ElseIf Status = "Major" Then
            com.Value = com.Items(0)
        End If

        dgr.Cells.Add(com)

        cel = New DataGridViewTextBoxCell()
        cel.Value = TxtNmShare.Text
        dgr.Cells.Add(cel)
        'cel = New DataGridViewTextBoxCell()
        'cel.Value = DtpkrDob.Value.Date
        'dgr.Cells.Add(cel)
        cel = New DataGridViewTextBoxCell()
        cel.Value = Txtadrsnomi.Text
        dgr.Cells.Add(cel)
        cel = New DataGridViewTextBoxCell()
        cel.Value = txtadrsnomi1.Text
        dgr.Cells.Add(cel)
        cel = New DataGridViewTextBoxCell()
        cel.Value = Txtgrdian.Text
        dgr.Cells.Add(cel)

        com = New DataGridViewComboBoxCell
        Try
            Info_Cty_Cmd = New SqlCommand("select cscid,cscctyname from FinactCscmstr where csctype='Outer'", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            While Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    ' Cmbxctynomi.Items.Add(Info_Cty_Rdr("cscctyname"))
                    com.Items.Add(Info_Cty_Rdr("cscctyname"))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()

        End Try

        com.Value = com.Items(Cmbxctynomi.SelectedIndex)
        dgr.Cells.Add(com)


        cel = New DataGridViewTextBoxCell()
        cel.Value = TxtPinNomi.Text
        dgr.Cells.Add(cel)


        cel = New DataGridViewTextBoxCell()
        cel.Value = 0
        dgr.Cells.Add(cel)


        FrmNmDetails.DataGridView1.Rows.Add(dgr)
        rowcnt = FrmNmDetails.DataGridView1.Rows.Count
        FrmNmDetails.DataGridView1.Rows(rowcnt - 1).Cells(10).Value = Dtpkrdob2.Value.Date


    End Sub

    Private Sub Dtpkrdob2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpkrdob2.GotFocus
        Dtpkrdob2.MaxDate = Today.Date
    End Sub

    Private Sub DtpkrJndt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrJndt.GotFocus
        DtpkrJndt.MaxDate = Dtpkrdoj.Value.Date.AddDays(-2)
        If DtpkrSettldt.Value.Date < Dtpkrdoj.Value.Date Then
            DtpkrJndt.MaxDate = DtpkrSettldt.Value.Date
        End If

    End Sub

    Private Sub CmbxDegree_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDegree.GotFocus
        If CmbxDegree.Items.Count > 0 Then
            If CmbxDegree.Text = "" Then
                CmbxDegree.SelectedIndex = 0

            End If
            CmbxDegree.DroppedDown = True

        End If

    End Sub


    Private Sub Txtpassyr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtpassyr.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxClass.Focus()
        End If
    End Sub


    Private Sub Txtinsid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtInsId.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            DtpkrRenewdt.Focus()
        End If
    End Sub

    Private Sub CmbxClass_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxClass.GotFocus
        If CmbxClass.Items.Count > 0 Then
            If CmbxClass.Text = "" Then
                CmbxClass.SelectedIndex = 0
            End If
            CmbxClass.DroppedDown = True
        End If

    End Sub

    Private Sub FrmPayRoll_MyKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAddrs.KeyDown, TxtAddrs1.KeyDown, TxtLndmrk.KeyDown, CmbxDegree.KeyDown, Rcjtxtappnt.KeyDown, ChkEsicAppli.KeyDown, ChkPFappli.KeyDown, CmbxCty1.KeyDown, txtPin.KeyDown, txtphno.KeyDown, Txtmobno.KeyDown, txtEmlid.KeyDown, CmbxSex.KeyDown, CmbxMStatus.KeyDown, DtpkrAnivrsry.KeyDown, CmbxRelign.KeyDown, Txtnatnl.KeyDown, TxtIdmark1.KeyDown, TxtIdmark2.KeyDown, TxtCurAddrs.KeyDown, TxtCurAdd1.KeyDown, TxtCurLnd.KeyDown, cmbxCurCty.KeyDown, TxtCurPin.KeyDown, TxtCurPhno.KeyDown, txtcurmobno.KeyDown, TxtPan.KeyDown, TxtGir.KeyDown, Txtrange.KeyDown, Txtward.KeyDown, TxtFhname.KeyDown, TxtMoname.KeyDown, TxtSposName.KeyDown, TxtEmrgncyNo.KeyDown, Nodepnd.KeyDown, TxtName1.KeyDown, DtpkrDob1.KeyDown, cmbxRelatn.KeyDown, DtpkrSettldt.KeyDown, DtpkrPfJdt.KeyDown, TxtAmtpf.KeyDown, TxtTfrdamt.KeyDown, TxtPFNo.KeyDown, TxtPolicno.KeyDown, DtpkrRenewdt.KeyDown, DtpkrTo.KeyDown, TxtEsic.KeyDown, TxtDispName.KeyDown, TxtNomine.KeyDown, cmbxrelt.KeyDown, Dtpkrdob2.KeyDown, Txtadrsnomi.KeyDown, txtadrsnomi1.KeyDown, Cmbxctynomi.KeyDown, TxtPinNomi.KeyDown, cmbxstatus.KeyDown, Txtgrdian.KeyDown, CmbxDegree.KeyDown, CmbxClass.KeyDown, Txtsubjts.KeyDown, TxtInsti.KeyDown, TxtEmplr.KeyDown, DtpkrJndt.KeyDown, DtpkrLevDt.KeyDown, TxtJnDesi.KeyDown, TxtLevdesi.KeyDown, Txtslry.KeyDown, Txtachive.KeyDown, TxtRecAgncy.KeyDown, CmbxEmpStat.KeyDown, TxtTptRute.KeyDown, cmbxWrkLoc.KeyDown, CmbxCoVeclType.KeyDown, txtCoVeclNo.KeyDown, TxtMobile.KeyDown, Txtlaptop.KeyDown, Txtmailid.KeyDown, DtpkrSubmit.KeyDown, DtpkrAccept.KeyDown, DtpkrRelev.KeyDown, TxtReason.KeyDown, TxtRemks.KeyDown, RchtxtCnfrmltr.KeyDown, TxtInsId.KeyDown
        ' If PayRolTab.SelectedIndex = 2 Then
        If e.KeyCode = Keys.Escape Then
            PayRolTab.SelectedIndex = 0
        End If
        'End If
      
    End Sub

    Private Sub FrmPayRoll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        DtColmn_Flag = False
        DtpkrDob.MaxDate = Today.AddYears(-15)
        DtpkrDob.MinDate = DtpkrDob.MaxDate.AddYears(-51)
        Dtpkrdoj.MinDate = (DtpkrDob.Value.AddYears(15))
        Dtpkrdoj.MaxDate = Dtpkrdoj.Value.AddYears(51)
        DtpkrDocon.MinDate = Dtpkrdoj.MinDate
        ' DtpkrDoResi.MinDate = Dtpkrdoj.MinDate
        DtpkrDocon.Checked = False
        'DtpkrDoResi.Checked = False
        Btndel.Enabled = False
        Enablefals()
        fetch_rec_city()
        fetch_rec_statecontry1()
        fetch_rec_city1()
        fetch_rec_statecontry2()
        fetch_rec_city2()
        fetch_rec_statecontry3()
        fetch_rec_city3()
        fetch_ComboShift()
        Dim onPaste1 As New TextBoxOnPaste(Me.TxtScale)
        Dim onPaste2 As New TextBoxOnPaste(Me.TxtScale)
        LblClickMe.Visible = False
        Lnklempimag.Enabled = False
        'If Btnsave.Text = "&New" Then
        Btnsave.Focus()
        Fill_Combobox("Machinid", "Machinname", "finact_MachinMstr", "MachinDelStatus", CInt(1), Me.Txtwrkid)
        'End If
        If ChkPFappli.Checked = False Then
            DtpkrSettldt.Enabled = False
            TxtPFNo.Enabled = False
            TxtAmtpf.Enabled = False
            TxtNewPfNo.Enabled = False
            DtpkrPfJdt.Enabled = False
            TxtTfrdamt.Enabled = False
            TxtVPpercnt.Enabled = False

        End If
        If ChkEsicAppli.Checked = False Then
            TxtEsic.Enabled = False
            TxtDispName.Enabled = False
        End If

    End Sub

    Private Sub Enablefals()
        GroupBox4.Enabled = False
        GroupBox5.Enabled = False
        GroupBox6.Enabled = False
        GroupBox7.Enabled = False
        GroupBox8.Enabled = False
        GroupBox9.Enabled = False
        GroupBox11.Enabled = False
        GroupBox12.Enabled = False
        GroupBox13.Enabled = False
        GroupBox14.Enabled = False
        GroupBox15.Enabled = False
        GroupBox16.Enabled = False
        GroupBox17.Enabled = False
        GroupBox18.Enabled = False
        TxtBnkMandte.Enabled = False
        Rcjtxtappnt.Enabled = False
        RchtxtCnfrmltr.Enabled = False
        GroupBox3.Enabled = False

    End Sub

    Private Sub Enabletru()
        ' Select Case PayRolTab.SelectedIndex
        '  Case 2
        GroupBox4.Enabled = True
        GroupBox5.Enabled = True
        GroupBox6.Enabled = True
        GroupBox7.Enabled = True
        GroupBox8.Enabled = True
        '   Case 3

        GroupBox9.Enabled = True
        GroupBox11.Enabled = True
        GroupBox12.Enabled = True
        GroupBox13.Enabled = True
        GroupBox14.Enabled = True
        GroupBox15.Enabled = True
        GroupBox16.Enabled = True
        GroupBox17.Enabled = True
        GroupBox18.Enabled = True
        TxtBnkMandte.Enabled = True
        Rcjtxtappnt.Enabled = True
        RchtxtCnfrmltr.Enabled = True
        GroupBox3.Enabled = True
        '  End Select
    End Sub

    Private Sub Btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsave.Click
        Try
            Select Case PayRolTab.SelectedIndex
                Case 0
                    If Btnsave.Text = "&New" Then
                        Btnsave.Text = "&Save"
                        btnedt.Text = "&Cancel"
                        Add_Edit_Flag = True
                        doj_flag = False
                        Me.Panel5.Enabled = True
                        Me.GroupBox1.Enabled = True
                        Lnklempimag.Enabled = True
                        Panel3.Height = 53
                        LstVewSelRec.Items.Clear()
                        LstVewSelRec.Height = 25
                        Me.Panel3.Enabled = False

                        TxtEmpName.Focus()
                    ElseIf Btnsave.Text = "&Save" Then
                        Chk_val_tabmaster()
                        If IndxMstr <> 0 Then
                            If IndxMstr = 5 Then
                                TxtEmpName.Focus()
                            End If
                            IndxMstr = 0
                            MsgBox("Blank Fields not allowed", MsgBoxStyle.Information, "Blank Fields")
                            Exit Sub
                        Else
                            EmpMstrSaveRec()
                            If Add_Edit_Flag = True Then
                                MsgBox("Master Record has been Saved Successfully", MsgBoxStyle.Information, "Employee's Master")
                                'Enabletru()
                                Me.Panel5.Enabled = False
                                Me.GroupBox1.Enabled = False
                                Panel3.Height = 53
                                LstVewSelRec.Items.Clear()
                                LstVewSelRec.Height = 25
                                Me.Panel3.Enabled = False
                                Lnklempimag.Enabled = False
                                Btnsave.Text = "&New"
                                btnedt.Text = "&Edit"


                            Else
                                MsgBox("Master Record has been Updated Successfully", MsgBoxStyle.Information, "Edit Record")

                                Clr_Values_mstr()
                                Clr_Values_Info()
                                Clr_Values_Other()
                                Clr_Values_Acad()
                                Clr_Values_Exprn()
                                Clr_Values_Fmly()
                                Clr_Values_PF()
                                Clr_Values_ApntLetr()
                                Clr_Values_CnfrmLetr()
                                Clr_Values_SlryBrkup()
                                Enablefals()
                                Panel5.Enabled = False
                                GroupBox1.Enabled = False
                                Btnsave.Text = "&New"
                                btnedt.Text = "&Edit"
                            End If
                            Dim fileExists As Boolean
                            If fileExists = My.Computer.FileSystem.FileExists(ImagePath) = True Then
                                My.Computer.FileSystem.CopyFile(MySource, ImagePath)
                            End If

                            EmpImage.Image = Nothing
                        End If
                        Lnklempimag.Enabled = False
                        Btnsave.Text = "&New"
                        btnedt.Text = "&Edit"
                        Btnsave.Focus()

                    End If
                Case 1
                    If Btnsave.Text = "&New" Then
                        PayRolTab.SelectedIndex = 0
                        Panel5.Enabled = True
                        GroupBox1.Enabled = True
                        TxtEmpName.Focus()
                        'Btnsave.Text = "&Save"
                        btnedt.Text = "&Cancel"
                        Add_Edit_Flag = True

                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Edit" Then
                        Add_Edit_Flag = True
                        Chk_val_ApntLetr()
                        If IndxMstr <> 0 Then
                            IndxMstr = 0
                            MsgBox("Invalid value", MsgBoxStyle.Information, "Validity")
                            Exit Sub

                        Else
                            EmpApntLetrSaverec()
                            MsgBox("Employee's Appointment Letter has been Saved Successfully", MsgBoxStyle.Information, "Employee's Pesonal Info")
                            Clr_Values_mstr()
                            Clr_Values_Info()
                            Clr_Values_Other()
                            Clr_Values_Acad()
                            Clr_Values_Exprn()
                            Clr_Values_Fmly()
                            Clr_Values_PF()
                            Clr_Values_ApntLetr()
                            Clr_Values_CnfrmLetr()
                            Clr_Values_SlryBrkup()
                            Btnsave.Text = "&New"
                            btnedt.Text = "&Edit"
                            Btnsave.Focus()
                        End If

                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Cancel" Then
                        If Apntmode = "edit" Then
                            Add_Edit_Flag = False
                            Chk_val_ApntLetr()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Invalid value", MsgBoxStyle.Information, "Validity")
                                Exit Sub
                            Else
                                EmpApntLetrSaverec()
                                MsgBox("Employee's Appointment Letter has been Updated Successfully", MsgBoxStyle.Information, "Edit Record")
                                Clr_Values_mstr()
                                Clr_Values_Info()
                                Clr_Values_Other()
                                Clr_Values_Acad()
                                Clr_Values_Exprn()
                                Clr_Values_Fmly()
                                Clr_Values_PF()
                                Clr_Values_ApntLetr()
                                Clr_Values_CnfrmLetr()
                                Clr_Values_SlryBrkup()
                                Enablefals()
                                Panel5.Enabled = False
                                GroupBox1.Enabled = False
                                Btnsave.Text = "&New"
                                btnedt.Text = "&Edit"
                                Btnsave.Focus()
                            End If

                        ElseIf Apntmode = "add" Then
                            Add_Edit_Flag = True
                            Chk_val_ApntLetr()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Invalid value", MsgBoxStyle.Information, "Validity")
                                Exit Sub
                            Else
                                EmpApntLetrSaverec()
                                MsgBox("Employee's Appointment Letter has been Saved Successfully", MsgBoxStyle.Information, "Employee's Pesonal Info")
                                Clr_Values_mstr()
                                Clr_Values_Info()
                                Clr_Values_Other()
                                Clr_Values_Acad()
                                Clr_Values_Exprn()
                                Clr_Values_Fmly()
                                Clr_Values_PF()
                                Clr_Values_ApntLetr()
                                Clr_Values_CnfrmLetr()
                                Clr_Values_SlryBrkup()
                                Enablefals()
                                Panel5.Enabled = False
                                GroupBox1.Enabled = False
                                Btnsave.Text = "&New"
                                btnedt.Text = "&Edit"
                                Btnsave.Focus()
                            End If
                        End If
                    End If

                Case 2
                    If Btnsave.Text = "&New" Then
                        PayRolTab.SelectedIndex = 0
                        Panel5.Enabled = True
                        GroupBox1.Enabled = True
                        btnedt.Text = "&Cancel"
                        Add_Edit_Flag = True
                        TxtEmpName.Focus()
                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Edit" Then
                        Add_Edit_Flag = True
                        Chk_val_tabInfo()
                        If IndxMstr <> 0 Then
                            IndxMstr = 0
                            MsgBox("Fields left empty", MsgBoxStyle.Information, "Blank Fields")
                            Exit Sub
                        Else
                            InvalidEmlid()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Invalid Email id:", MsgBoxStyle.Information, "Email id")
                                Exit Sub
                            Else
                                EmpInfoSaveRec()
                                MsgBox("Employee's Personal Info. has been Saved Successfully", MsgBoxStyle.Information, "Employee's Pesonal Info")
                                Clr_Values_mstr()
                                Clr_Values_Info()
                                Clr_Values_Other()
                                Clr_Values_Acad()
                                Clr_Values_Exprn()
                                Clr_Values_Fmly()
                                Clr_Values_PF()
                                Clr_Values_ApntLetr()
                                Clr_Values_CnfrmLetr()
                                Clr_Values_SlryBrkup()
                                Btnsave.Text = "&New"
                                btnedt.Text = "&Edit"
                                Btnsave.Focus()
                            End If
                        End If
                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Cancel" Then
                        If Infomode = "edit" Then
                            Add_Edit_Flag = False
                            Chk_val_tabInfo()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Blank Fields not allowed", MsgBoxStyle.Information, "Blank Fields")
                                Exit Sub
                            Else
                                InvalidEmlid()
                                If IndxMstr <> 0 Then
                                    IndxMstr = 0
                                    MsgBox("Invalid Email id:", MsgBoxStyle.Information, "Email id")
                                    Exit Sub
                                Else
                                    EmpInfoSaveRec()
                                    MsgBox("Employee's Personal Info. has been Updated Successfully", MsgBoxStyle.Information, "Edit Record")
                                    Clr_Values_mstr()
                                    Clr_Values_Info()
                                    Clr_Values_Other()
                                    Clr_Values_Acad()
                                    Clr_Values_Exprn()
                                    Clr_Values_Fmly()
                                    Clr_Values_PF()
                                    Clr_Values_ApntLetr()
                                    Clr_Values_CnfrmLetr()
                                    Clr_Values_SlryBrkup()
                                    Enablefals()
                                    Panel5.Enabled = False
                                    GroupBox1.Enabled = False
                                    Btnsave.Text = "&New"
                                    btnedt.Text = "&Edit"
                                    Btnsave.Focus()
                                End If
                            End If
                        ElseIf Infomode = "add" Then
                            Add_Edit_Flag = True
                            Chk_val_tabInfo()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Blank Fields not allowed", MsgBoxStyle.Information, "Blank Fields")
                                Exit Sub
                            Else
                                InvalidEmlid()
                                If IndxMstr <> 0 Then
                                    IndxMstr = 0
                                    MsgBox("Invalid Email id:", MsgBoxStyle.Information, "Email id")
                                    Exit Sub
                                Else
                                    EmpInfoSaveRec()
                                    MsgBox("Employee's Personal Info. has has been Saved Successfully", MsgBoxStyle.Information, "Employee's Pesonal Info")
                                    Clr_Values_mstr()
                                    Clr_Values_Info()
                                    Clr_Values_Other()
                                    Clr_Values_Acad()
                                    Clr_Values_Exprn()
                                    Clr_Values_Fmly()
                                    Clr_Values_PF()
                                    Clr_Values_ApntLetr()
                                    Clr_Values_CnfrmLetr()
                                    Clr_Values_SlryBrkup()
                                    Enablefals()
                                    Panel5.Enabled = False
                                    GroupBox1.Enabled = False
                                    Btnsave.Text = "&New"
                                    btnedt.Text = "&Edit"
                                    Btnsave.Focus()
                                End If
                            End If
                        End If
                    End If
                Case 3

                    If Btnsave.Text = "&New" Then
                        PayRolTab.SelectedIndex = 0
                        Panel5.Enabled = True
                        GroupBox1.Enabled = True
                        TxtEmpName.Focus()
                        'Btnsave.Text = "&Save"
                        btnedt.Text = "&Cancel"
                        Add_Edit_Flag = True
                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Edit" Then
                        Add_Edit_Flag = True
                        'EmpFmlySaverec()
                        Chk_val_tabProFn()
                        If IndxMstr <> 0 Then
                            IndxMstr = 0
                            MsgBox("Blank Fields not allowed", MsgBoxStyle.Information, "Blank Fields")
                            Exit Sub
                        Else
                            EmpProFndSaverec()
                            EmpNomineeSaverec()

                            MsgBox("Employee's Provident Fund Info. has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                            Clr_Values_mstr()
                            Clr_Values_Info()
                            Clr_Values_Other()
                            Clr_Values_Acad()
                            Clr_Values_Exprn()
                            Clr_Values_Fmly()
                            Clr_Values_PF()
                            Clr_Values_ApntLetr()
                            Clr_Values_CnfrmLetr()
                            Clr_Values_SlryBrkup()
                            Btnsave.Text = "&New"
                            btnedt.Text = "&Edit"
                            Btnsave.Focus()
                        End If
                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Cancel" Then
                        If ProFndmode = "edit" And Fmlymode = "edit" Then
                            Add_Edit_Flag = False
                            EmpProFndSaverec()
                            EmpNomineeSaverec()
                            MsgBox("Employee's Provident Fund Info. has been Updated Successfully", MsgBoxStyle.Information, "Edit Record")
                            Clr_Values_mstr()
                            Clr_Values_Info()
                            Clr_Values_Other()
                            Clr_Values_Acad()
                            Clr_Values_Exprn()
                            Clr_Values_Fmly()
                            Clr_Values_PF()
                            Clr_Values_ApntLetr()
                            Clr_Values_CnfrmLetr()
                            Clr_Values_SlryBrkup()
                            Enablefals()
                            Panel5.Enabled = False
                            GroupBox1.Enabled = False
                            Btnsave.Text = "&New"
                            btnedt.Text = "&Edit"
                            Btnsave.Focus()
                        ElseIf ProFndmode = "add" And Fmlymode = "add" Then
                            Add_Edit_Flag = True
                            'EmpFmlySaverec()
                            Chk_val_tabProFn()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Blank Fields not allowed", MsgBoxStyle.Information, "Blank Fields")
                                Exit Sub
                            Else
                                EmpProFndSaverec()
                                EmpNomineeSaverec()
                                MsgBox("Employee's Provident Fund Info. has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                                Clr_Values_mstr()
                                Clr_Values_Info()
                                Clr_Values_Other()
                                Clr_Values_Acad()
                                Clr_Values_Exprn()
                                Clr_Values_Fmly()
                                Clr_Values_PF()
                                Clr_Values_ApntLetr()
                                Clr_Values_CnfrmLetr()
                                Clr_Values_SlryBrkup()
                                Enablefals()
                                Panel5.Enabled = False
                                GroupBox1.Enabled = False
                                Btnsave.Text = "&New"
                                btnedt.Text = "&Edit"
                                Btnsave.Focus()
                            End If
                        ElseIf ProFndmode = "add" And Fmlymode = "edit" Then
                            Add_Edit_Flag = True
                            Chk_val_tabProFn()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Blank Fields not allowed", MsgBoxStyle.Information, "Blank Fields")
                                Exit Sub
                            Else
                                EmpProFndSaverec()
                                EmpNomineeSaverec()
                                Add_Edit_Flag = False
                                EmpMstrSaveRec()
                                MsgBox("Employee's Provident Fund Info. has been Updated Successfully", MsgBoxStyle.Information, "Edit Record")
                                Clr_Values_mstr()
                                Clr_Values_Info()
                                Clr_Values_Other()
                                Clr_Values_Acad()
                                Clr_Values_Exprn()
                                Clr_Values_Fmly()
                                Clr_Values_PF()
                                Clr_Values_ApntLetr()
                                Clr_Values_CnfrmLetr()
                                Clr_Values_SlryBrkup()
                                Enablefals()
                                Panel5.Enabled = False
                                GroupBox1.Enabled = False
                                Btnsave.Text = "&New"
                                btnedt.Text = "&Edit"
                                Btnsave.Focus()
                            End If
                        ElseIf ProFndmode = "edit" And Fmlymode = "add" Then
                            'Add_Edit_Flag = True
                            'EmpFmlySaverec()
                            Add_Edit_Flag = False
                            EmpProFndSaverec()
                            EmpNomineeSaverec()
                            MsgBox("Employee's Provident Fund Info. has been Updated Successfully", MsgBoxStyle.Information, "Edit Record")
                            ' Add_Edit_Flag = False
                            ' EmpMstrSaveRec()
                            Clr_Values_mstr()
                            Clr_Values_Info()
                            Clr_Values_Other()
                            Clr_Values_Acad()
                            Clr_Values_Exprn()
                            Clr_Values_Fmly()
                            Clr_Values_PF()
                            Clr_Values_ApntLetr()
                            Clr_Values_CnfrmLetr()
                            Clr_Values_SlryBrkup()
                            Enablefals()
                            Panel5.Enabled = False
                            GroupBox1.Enabled = False
                            Btnsave.Text = "&New"
                            btnedt.Text = "&Edit"
                            Btnsave.Focus()
                        End If
                    End If

                Case 4
                    If Btnsave.Text = "&New" Then
                        PayRolTab.SelectedIndex = 0
                        Panel5.Enabled = True
                        GroupBox1.Enabled = True
                        TxtEmpName.Focus()
                        'Btnsave.Text = "&Save"
                        btnedt.Text = "&Cancel"
                        Add_Edit_Flag = True
                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Edit" Then
                        Add_Edit_Flag = True
                        'EmpAcadmicSaverec()
                        ' EmpExprnSaverec()
                        Clr_Values_mstr()
                        Clr_Values_Info()
                        Clr_Values_Other()
                        Clr_Values_Acad()
                        Clr_Values_Exprn()
                        Clr_Values_Fmly()
                        Clr_Values_PF()
                        Clr_Values_ApntLetr()
                        Clr_Values_CnfrmLetr()
                        Clr_Values_SlryBrkup()
                        'MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information, "Employee's Details")
                        Btnsave.Text = "&New"
                        btnedt.Text = "&Edit"
                        Btnsave.Focus()
                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Cancel" Then
                        If Acadmode = "edit" And Exprncmode = "edit" Then
                            Add_Edit_Flag = False
                            'EmpMstrSaveRec()
                            ' MsgBox("Record has been Updated", MsgBoxStyle.Information, "Edit Record")
                            Clr_Values_mstr()
                            Clr_Values_Info()
                            Clr_Values_Other()
                            Clr_Values_Acad()
                            Clr_Values_Exprn()
                            Clr_Values_Fmly()
                            Clr_Values_PF()
                            Clr_Values_ApntLetr()
                            Clr_Values_CnfrmLetr()
                            Clr_Values_SlryBrkup()
                            Enablefals()
                            Panel5.Enabled = False
                            GroupBox1.Enabled = False
                            Btnsave.Text = "&New"
                            btnedt.Text = "&Edit"
                            Btnsave.Focus()
                        ElseIf Acadmode = "add" And Exprncmode = "add" Then
                            Add_Edit_Flag = True
                            ' EmpAcadmicSaverec()
                            ' EmpExprnSaverec()
                            'MsgBox("Record has been Updated Successfully", MsgBoxStyle.Information, "Employee's Pesonal Info")
                            ' Add_Edit_Flag = False
                            ' EmpMstrSaveRec()
                            Clr_Values_mstr()
                            Clr_Values_Info()
                            Clr_Values_Other()
                            Clr_Values_Acad()
                            Clr_Values_Exprn()
                            Clr_Values_Fmly()
                            Clr_Values_PF()
                            Clr_Values_ApntLetr()
                            Clr_Values_CnfrmLetr()
                            Clr_Values_SlryBrkup()
                            Enablefals()
                            Panel5.Enabled = False
                            GroupBox1.Enabled = False
                            Btnsave.Text = "&New"
                            btnedt.Text = "&Edit"
                            Btnsave.Focus()
                        ElseIf Acadmode = "add" And Exprncmode = "edit" Then
                            Add_Edit_Flag = True
                            ' EmpAcadmicSaverec()
                            Add_Edit_Flag = False
                            'EmpMstrSaveRec()
                            ' MsgBox("Record has been Updated Successfully", MsgBoxStyle.Information, "Employee's Pesonal Info")
                            Clr_Values_mstr()
                            Clr_Values_Info()
                            Clr_Values_Other()
                            Clr_Values_Acad()
                            Clr_Values_Exprn()
                            Clr_Values_Fmly()
                            Clr_Values_PF()
                            Clr_Values_ApntLetr()
                            Clr_Values_CnfrmLetr()
                            Clr_Values_SlryBrkup()
                            Enablefals()
                            Panel5.Enabled = False
                            GroupBox1.Enabled = False
                            Btnsave.Text = "&New"
                            btnedt.Text = "&Edit"
                            Btnsave.Focus()
                        ElseIf Acadmode = "edit" And Exprncmode = "add" Then
                            Add_Edit_Flag = True
                            'EmpExprnSaverec()
                            Add_Edit_Flag = False
                            'EmpMstrSaveRec()
                            'MsgBox("Record has been Updated Successfully", MsgBoxStyle.Information, "Employee's Pesonal Info")
                            Clr_Values_mstr()
                            Clr_Values_Info()
                            Clr_Values_Other()
                            Clr_Values_Acad()
                            Clr_Values_Exprn()
                            Clr_Values_Fmly()
                            Clr_Values_PF()
                            Clr_Values_ApntLetr()
                            Clr_Values_CnfrmLetr()
                            Clr_Values_SlryBrkup()
                            Enablefals()
                            Panel5.Enabled = False
                            GroupBox1.Enabled = False
                            Btnsave.Text = "&New"
                            btnedt.Text = "&Edit"
                            Btnsave.Focus()
                        End If
                    End If
                Case 5
                    If Btnsave.Text = "&New" Then
                        PayRolTab.SelectedIndex = 0
                        Panel5.Enabled = True
                        GroupBox1.Enabled = True
                        TxtEmpName.Focus()
                        'Btnsave.Text = "&Save"
                        btnedt.Text = "&Cancel"
                        Add_Edit_Flag = True

                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Edit" Then
                        Add_Edit_Flag = True
                        Chk_val_CnfrmLetr()
                        If IndxMstr <> 0 Then
                            IndxMstr = 0
                            MsgBox("Invalid value", MsgBoxStyle.Information, "Validity")
                            Exit Sub

                        Else
                            EmpCnfrmLetrSaverec()
                            MsgBox("Employee's Confirmation Letter has been Saved Successfully", MsgBoxStyle.Information, "Employee's Pesonal Info")
                            Clr_Values_mstr()
                            Clr_Values_Info()
                            Clr_Values_Other()
                            Clr_Values_Acad()
                            Clr_Values_Exprn()
                            Clr_Values_Fmly()
                            Clr_Values_PF()
                            Clr_Values_ApntLetr()
                            Clr_Values_CnfrmLetr()
                            Clr_Values_SlryBrkup()
                            Btnsave.Text = "&New"
                            btnedt.Text = "&Edit"
                            Btnsave.Focus()
                        End If

                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Cancel" Then
                        If Cnfrmmode = "edit" Then
                            Add_Edit_Flag = False
                            Chk_val_CnfrmLetr()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Invalid value", MsgBoxStyle.Information, "Validity")
                                Exit Sub
                            Else
                                EmpCnfrmLetrSaverec()
                                MsgBox("Employee's Confirmation Letter has been Updated Successfully", MsgBoxStyle.Information, "Edit Record")
                                Clr_Values_mstr()
                                Clr_Values_Info()
                                Clr_Values_Other()
                                Clr_Values_Acad()
                                Clr_Values_Exprn()
                                Clr_Values_Fmly()
                                Clr_Values_PF()
                                Clr_Values_ApntLetr()
                                Clr_Values_CnfrmLetr()
                                Clr_Values_SlryBrkup()
                                Enablefals()
                                Panel5.Enabled = False
                                GroupBox1.Enabled = False
                                Btnsave.Text = "&New"
                                btnedt.Text = "&Edit"
                                Btnsave.Focus()
                            End If

                        ElseIf Cnfrmmode = "add" Then
                            Add_Edit_Flag = True
                            Chk_val_CnfrmLetr()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Invalid value", MsgBoxStyle.Information, "Validity")
                                Exit Sub
                            Else
                                EmpCnfrmLetrSaverec()
                                MsgBox("Employee's Confirmation Letter has been Saved Successfully", MsgBoxStyle.Information, "Employee's Pesonal Info")
                                Clr_Values_mstr()
                                Clr_Values_Info()
                                Clr_Values_Other()
                                Clr_Values_Acad()
                                Clr_Values_Exprn()
                                Clr_Values_Fmly()
                                Clr_Values_PF()
                                Clr_Values_ApntLetr()
                                Clr_Values_CnfrmLetr()
                                Clr_Values_SlryBrkup()
                                Enablefals()
                                Panel5.Enabled = False
                                GroupBox1.Enabled = False
                                Btnsave.Text = "&New"
                                btnedt.Text = "&Edit"
                                Btnsave.Focus()
                            End If
                        End If
                    End If

                Case 6
                    If Btnsave.Text = "&New" Then
                        PayRolTab.SelectedIndex = 0
                        Panel5.Enabled = True
                        GroupBox1.Enabled = True
                        TxtEmpName.Focus()
                        'Btnsave.Text = "&Save"
                        btnedt.Text = "&Cancel"
                        Add_Edit_Flag = True
                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Edit" Then
                        Add_Edit_Flag = True
                        Chk_val_tabOthers()
                        If IndxMstr <> 0 Then
                            IndxMstr = 0
                            MsgBox("Blank Fields not allowed", MsgBoxStyle.Information, "Blank Fields")
                            Exit Sub
                        Else
                            Invalidmailid()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Invalid Email id:", MsgBoxStyle.Information, "Email id")
                                Exit Sub
                            Else
                                EmpOtherSaverec()
                                MsgBox("Employee's Other Info. has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                                Clr_Values_mstr()
                                Clr_Values_Info()
                                Clr_Values_Other()
                                Clr_Values_Acad()
                                Clr_Values_Exprn()
                                Clr_Values_Fmly()
                                Clr_Values_PF()
                                Clr_Values_ApntLetr()
                                Clr_Values_CnfrmLetr()
                                Clr_Values_SlryBrkup()
                                Btnsave.Text = "&New"
                                btnedt.Text = "&Edit"
                                Btnsave.Focus()
                            End If
                        End If
                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Cancel" Then
                        If Othermode = "edit" Then
                            Add_Edit_Flag = False
                            Invalidmailid()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Invalid Email id:", MsgBoxStyle.Information, "Email id")
                                Exit Sub
                            Else
                                EmpOtherSaverec()
                                MsgBox("Employee's Other Info. has been Updated Successfully", MsgBoxStyle.Information, "Edit Record")
                                Clr_Values_mstr()
                                Clr_Values_Info()
                                Clr_Values_Other()
                                Clr_Values_Acad()
                                Clr_Values_Exprn()
                                Clr_Values_Fmly()
                                Clr_Values_PF()
                                Clr_Values_ApntLetr()
                                Clr_Values_CnfrmLetr()
                                Clr_Values_SlryBrkup()
                                Enablefals()
                                Panel5.Enabled = False
                                GroupBox1.Enabled = False
                                Btnsave.Text = "&New"
                                btnedt.Text = "&Edit"
                                Btnsave.Focus()
                            End If
                        ElseIf Othermode = "add" Then
                            Add_Edit_Flag = True
                            Chk_val_tabOthers()
                            If IndxMstr <> 0 Then
                                IndxMstr = 0
                                MsgBox("Blank Fields not allowed", MsgBoxStyle.Information, "Blank Fields")
                                Exit Sub
                            Else
                                Invalidmailid()
                                If IndxMstr <> 0 Then
                                    IndxMstr = 0
                                    MsgBox("Invalid Email id:", MsgBoxStyle.Information, "Email id")
                                    Exit Sub
                                Else
                                    EmpOtherSaverec()
                                    MsgBox(" Employee's Other Info. has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                                    Clr_Values_mstr()
                                    Clr_Values_Info()
                                    Clr_Values_Other()
                                    Clr_Values_Acad()
                                    Clr_Values_Exprn()
                                    Clr_Values_Fmly()
                                    Clr_Values_PF()
                                    Clr_Values_ApntLetr()
                                    Clr_Values_CnfrmLetr()
                                    Clr_Values_SlryBrkup()
                                    Enablefals()
                                    Panel5.Enabled = False
                                    GroupBox1.Enabled = False
                                    Btnsave.Text = "&New"
                                    btnedt.Text = "&Edit"
                                    Btnsave.Focus()
                                End If
                            End If
                        End If
                    End If

                Case 7
                    If Btnsave.Text = "&New" Then
                        PayRolTab.SelectedIndex = 0
                        Panel5.Enabled = True
                        GroupBox1.Enabled = True
                        TxtEmpName.Focus()
                        'Btnsave.Text = "&Save"
                        btnedt.Text = "&Cancel"
                        Add_Edit_Flag = True
                        'ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Edit" Then
                        ' ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Cancel" Then


                    ElseIf Btnsave.Text = "&Save" And btnedt.Text = "&Cancel" Then

                        If SlryBrkmode = "edit" Then
                            Add_Edit_Flag = False
                            If RbYes.Checked = False And RbNo.Checked = False Then
                                MsgBox("Select Yes/No for OverTime Applicability.", MsgBoxStyle.Information, "Yes/No")
                                Exit Sub
                            End If
                            If RbYes_Phed.Checked = False And RbNoPhed.Checked = False Then
                                MsgBox("Select Yes/No for Payhead Applicability.", MsgBoxStyle.Information, "Yes/No")
                                Exit Sub
                            End If

                            EmpSlryBrkupSaverec()
                            MsgBox("Employee's Salary Breakup has been Updated Successfully", MsgBoxStyle.Information, "Save Record")
                            Clr_Values_mstr()
                            Clr_Values_Info()
                            Clr_Values_Other()
                            Clr_Values_Acad()
                            Clr_Values_Exprn()
                            Clr_Values_Fmly()
                            Clr_Values_PF()
                            Clr_Values_ApntLetr()
                            Clr_Values_CnfrmLetr()
                            Clr_Values_SlryBrkup()
                            Enablefals()
                            Panel5.Enabled = False
                            GroupBox1.Enabled = False
                            Btnsave.Text = "&New"
                            btnedt.Text = "&Edit"
                            Btnsave.Focus()
                        ElseIf SlryBrkmode = "add" Then
                            Add_Edit_Flag = True
                            If RbYes.Checked = False And RbNo.Checked = False Then
                                MsgBox("Select Yes/No for OverTime Applicability.", MsgBoxStyle.Information, "Yes/No")
                                Exit Sub
                            End If
                            If RbYes_Phed.Checked = False And RbNoPhed.Checked = False Then
                                MsgBox("Select Yes/No for Payhead Applicability.", MsgBoxStyle.Information, "Yes/No")
                                Exit Sub
                            End If

                            EmpSlryBrkupSaverec()
                            MsgBox("Employee's Salary Breakup has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                            Clr_Values_mstr()
                            Clr_Values_Info()
                            Clr_Values_Other()
                            Clr_Values_Acad()
                            Clr_Values_Exprn()
                            Clr_Values_Fmly()
                            Clr_Values_PF()
                            Clr_Values_ApntLetr()
                            Clr_Values_CnfrmLetr()
                            Clr_Values_SlryBrkup()
                            Enablefals()
                            Panel5.Enabled = False
                            GroupBox1.Enabled = False
                            Btnsave.Text = "&New"
                            btnedt.Text = "&Edit"
                            Btnsave.Focus()

                        End If
                    End If

            End Select
        Catch ex As Exception
        End Try



    End Sub

    Private Sub Chk_val_tabmaster()
        With TxtEmpName
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With txtdispl
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtwrkid
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With txtprobation
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxBrnch
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxCat
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxDesi
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxDept
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxEmpStat
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With TxtScale
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With

        If RbTfr.Checked = True Then
            With Txtbnkname
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtbCode
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtAccNo
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtAccType
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With CmbxSift
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
        End If

    End Sub

    Private Sub Chk_val_tabInfo()
        With TxtAddrs
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxCty1
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With txtPin
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With txtphno
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxSex
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxMStatus
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxRelign
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtnatnl
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With TxtIdmark1
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With TxtCurAddrs
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With cmbxCurCty
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With

        With TxtFhname
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With TxtMoname
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With TxtEmrgncyNo
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        If CmbxMStatus.Text = "Married" Or CmbxMStatus.Text = "Divorcee" Then

            With TxtSposName
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
        End If
    End Sub

    Private Sub RbTfr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbTfr.CheckedChanged
        If RbTfr.Checked = True Then
            Grpbxbnk.Enabled = True
            'Txtbnkname.Focus()
        Else
            Grpbxbnk.Enabled = False
        End If
    End Sub

    Private Sub fetch_Record_from_diffTable(ByVal Combox As ComboBox, ByVal RecType As String)
        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Select deptname from finactdept where depttype='" & (RecType) & "'and deptdelstatus=1", FinActConn)
            P_Roll_Mstr_rdr = P_Roll_Mstr_Cmd.ExecuteReader
            Combox.Items.Clear()
            If Trim(RecType) <> "" Then
                While P_Roll_Mstr_rdr.Read
                    If P_Roll_Mstr_rdr.HasRows = True Then
                        Combox.Items.Add(P_Roll_Mstr_rdr(0))
                    End If
                End While
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_rdr.Close()
            P_Roll_Mstr_Cmd = Nothing
        End Try

    End Sub

    Private Sub fetch_Record_from_desi()
        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Select desiname from finactdesi where desitype='Desi'and desidelstatus=1", FinActConn)
            P_Roll_Mstr_rdr = P_Roll_Mstr_Cmd.ExecuteReader
            CmbxDesi.Items.Clear()

            While P_Roll_Mstr_rdr.Read
                If P_Roll_Mstr_rdr.HasRows = True Then
                    CmbxDesi.Items.Add(P_Roll_Mstr_rdr(0))
                End If
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_rdr.Close()
            P_Roll_Mstr_Cmd = Nothing
        End Try

    End Sub
    Private Sub Chk_val_tabFmly()
        With cmbxRelatn
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With TxtName1
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With

    End Sub

    Private Sub Chk_val_tabProFn()


        If ChkPFappli.Checked = True Then
            With TxtVPpercnt
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtAmtpf
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtTfrdamt
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtPFNo
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtNewPfNo
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip
                    .Focus()
                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
        End If
        With TxtNomine
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With cmbxrelt
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtadrsnomi
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With cmbxstatus
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With

        With TxtNmShare
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With


    End Sub

    Private Sub Chk_val_tabAcadmic()
        With CmbxDegree
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtpassyr
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxClass
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtsubjts
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With TxtInsti
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
    End Sub

    Private Sub Chk_val_tabExprnce()
        With TxtEmplr
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With TxtJnDesi
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With TxtLevdesi
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtslry
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With

    End Sub
    Private Sub Chk_val_ApntLetr()
        With Rcjtxtappnt
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With

    End Sub
    Private Sub Chk_val_CnfrmLetr()
        With RchtxtCnfrmltr
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With

    End Sub
    Private Sub Chk_val_tabOthers()
        With cmbxWrkLoc
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                IndxMstr += 1
            Else
                .BackColor = Color.White
            End If
        End With
        'If CmbxCoVeclType.Text <> "" Then
        '    With txtCoVeclNo
        '        If Trim(.Text) = "" Then
        '            .BackColor = Color.PapayaWhip
        '            .Focus()
        '            IndxMstr += 1
        '        Else
        '            .BackColor = Color.White
        '        End If
        '    End With
        'End If

    End Sub

    Private Sub Chk_val_tabSlryBrkup()

        If RbYes.Checked = False And RbNo.Checked = False Then
            MsgBox("Select Yes/No for OverTime Applicability.", MsgBoxStyle.Information, "Yes/No")

        End If
        If RbYes_Phed.Checked = False And RbNoPhed.Checked = False Then
            MsgBox("Select Yes/No for Payhead Applicability.", MsgBoxStyle.Information, "Yes/No")

        End If


    End Sub


    Private Sub btnedt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedt.Click
        Select Case PayRolTab.SelectedIndex
            Case 0
                If btnedt.Text = "&Edit" Then
                    fetch_AllRec_from_Table()
                    LstVewSelRec.Focus()
                    Dim Lstcount As Integer = 0
                    Lstcount = LstVewSelRec.Items.Count
                    If Lstcount <> 0 Then
                        LstVewSelRec.Items(0).Selected = True
                    End If

                    Btndel.Enabled = False
                    btnedt.Text = "&Cancel"
                    Btnsave.Text = "&Save"
                    Add_Edit_Flag = False
                    Me.Panel3.Enabled = True

                    Panel3.Height = 228
                    LstVewSelRec.Height = 200
                    LstVewSelRec.Focus()
                    ' Panel5.Enabled = True
                    ' GroupBox1.Enabled = True
                    'Enabletru()

                ElseIf btnedt.Text = "&Cancel" Then
                    EmpImage.Image = Nothing
                    Clr_Values_mstr()
                    Clr_Values_Info()
                    Clr_Values_Fmly()
                    Clr_Values_PF()
                    Clr_Values_Acad()
                    Clr_Values_Exprn()
                    Clr_Values_Other()
                    Clr_Values_ApntLetr()
                    Clr_Values_CnfrmLetr()
                    Clr_Values_SlryBrkup()
                    Panel3.Height = 53
                    LstVewSelRec.Items.Clear()
                    LstVewSelRec.Height = 25
                    Me.Panel3.Enabled = False
                    btnedt.Text = "&Edit"
                    Btnsave.Text = "&New"
                    Panel5.Enabled = False
                    GroupBox1.Enabled = False
                    Enablefals()
                    Lnklempimag.Enabled = False
                    Btndel.Enabled = False
                    Btnsave.Focus()

                End If
            Case 1
                If btnedt.Text = "&Cancel" Then
                    Clr_Values_mstr()
                    Clr_Values_Info()
                    Clr_Values_Fmly()
                    Clr_Values_PF()
                    Clr_Values_Acad()
                    Clr_Values_Exprn()
                    Clr_Values_Other()
                    Clr_Values_ApntLetr()
                    Clr_Values_CnfrmLetr()
                    Clr_Values_SlryBrkup()
                    Panel3.Height = 53
                    LstVewSelRec.Items.Clear()
                    LstVewSelRec.Height = 25
                    Me.Panel3.Enabled = False
                    btnedt.Text = "&Edit"
                    Btnsave.Text = "&New"
                    Panel5.Enabled = False
                    GroupBox1.Enabled = False
                    Enablefals()
                    Btndel.Enabled = False
                End If
            Case 2
                If btnedt.Text = "&Cancel" Then
                    Clr_Values_mstr()
                    Clr_Values_Info()
                    Clr_Values_Fmly()
                    Clr_Values_PF()
                    Clr_Values_Acad()
                    Clr_Values_Exprn()
                    Clr_Values_Other()
                    Clr_Values_ApntLetr()
                    Clr_Values_CnfrmLetr()
                    Clr_Values_SlryBrkup()
                    Panel3.Height = 53
                    LstVewSelRec.Items.Clear()
                    LstVewSelRec.Height = 25
                    Me.Panel3.Enabled = False
                    btnedt.Text = "&Edit"
                    Btnsave.Text = "&New"
                    Panel5.Enabled = False
                    GroupBox1.Enabled = False
                    Enablefals()
                    Btndel.Enabled = False
                End If
            Case 3
                If btnedt.Text = "&Cancel" Then
                    Clr_Values_mstr()
                    Clr_Values_Info()
                    Clr_Values_Fmly()
                    Clr_Values_PF()
                    Clr_Values_Acad()
                    Clr_Values_Exprn()
                    Clr_Values_Other()
                    Clr_Values_ApntLetr()
                    Clr_Values_CnfrmLetr()
                    Clr_Values_SlryBrkup()
                    Panel3.Height = 53
                    LstVewSelRec.Items.Clear()
                    LstVewSelRec.Height = 25
                    Me.Panel3.Enabled = False
                    btnedt.Text = "&Edit"
                    Btnsave.Text = "&New"
                    Panel5.Enabled = False
                    GroupBox1.Enabled = False
                    Enablefals()
                    Btndel.Enabled = False
                End If
            Case 4
                If btnedt.Text = "&Cancel" Then
                    Clr_Values_mstr()
                    Clr_Values_Info()
                    Clr_Values_Fmly()
                    Clr_Values_PF()
                    Clr_Values_Acad()
                    Clr_Values_Exprn()
                    Clr_Values_Other()
                    Clr_Values_ApntLetr()
                    Clr_Values_CnfrmLetr()
                    Clr_Values_SlryBrkup()
                    Panel3.Height = 53
                    LstVewSelRec.Items.Clear()
                    LstVewSelRec.Height = 25
                    Me.Panel3.Enabled = False
                    btnedt.Text = "&Edit"
                    Btnsave.Text = "&New"
                    Panel5.Enabled = False
                    GroupBox1.Enabled = False
                    Enablefals()
                    Btndel.Enabled = False
                End If
            Case 5
                If btnedt.Text = "&Cancel" Then
                    Clr_Values_mstr()
                    Clr_Values_Info()
                    Clr_Values_Fmly()
                    Clr_Values_PF()
                    Clr_Values_Acad()
                    Clr_Values_Exprn()
                    Clr_Values_Other()
                    Clr_Values_ApntLetr()
                    Clr_Values_CnfrmLetr()
                    Clr_Values_SlryBrkup()
                    Panel3.Height = 53
                    LstVewSelRec.Items.Clear()
                    LstVewSelRec.Height = 25
                    Me.Panel3.Enabled = False
                    btnedt.Text = "&Edit"
                    Btnsave.Text = "&New"
                    Panel5.Enabled = False
                    GroupBox1.Enabled = False
                    Enablefals()
                    Btndel.Enabled = False
                End If
            Case 6
                If btnedt.Text = "&Cancel" Then
                    Clr_Values_mstr()
                    Clr_Values_Info()
                    Clr_Values_Fmly()
                    Clr_Values_PF()
                    Clr_Values_Acad()
                    Clr_Values_Exprn()
                    Clr_Values_Other()
                    Clr_Values_ApntLetr()
                    Clr_Values_CnfrmLetr()
                    Clr_Values_SlryBrkup()
                    Panel3.Height = 53
                    LstVewSelRec.Items.Clear()
                    LstVewSelRec.Height = 25
                    Me.Panel3.Enabled = False
                    btnedt.Text = "&Edit"
                    Btnsave.Text = "&New"
                    Panel5.Enabled = False
                    GroupBox1.Enabled = False
                    Enablefals()
                    Btndel.Enabled = False
                End If

            Case 7
                If btnedt.Text = "&Cancel" Then
                    Clr_Values_mstr()
                    Clr_Values_Info()
                    Clr_Values_Fmly()
                    Clr_Values_PF()
                    Clr_Values_Acad()
                    Clr_Values_Exprn()
                    Clr_Values_Other()
                    Clr_Values_ApntLetr()
                    Clr_Values_CnfrmLetr()
                    Clr_Values_SlryBrkup()
                    Panel3.Height = 53
                    LstVewSelRec.Items.Clear()
                    LstVewSelRec.Height = 25
                    Me.Panel3.Enabled = False
                    btnedt.Text = "&Edit"
                    Btnsave.Text = "&New"
                    Panel5.Enabled = False
                    GroupBox1.Enabled = False
                    Enablefals()
                    Btndel.Enabled = False
                End If
        End Select
    End Sub

    Private Sub EmpMstrSaveRec()
        Dim BrnchId, CatId, DeptId, WrkId, BnkId1 As Integer
        fetch_Ids_from_diffTable(CmbxBrnch, CmbxBrnch.Text)
        BrnchId = DptId
        fetch_Ids_from_diffTable(CmbxCat, CmbxCat.Text)
        CatId = DptId
        fetch_Ids_from_diffTable(CmbxDept, CmbxDept.Text)
        DeptId = DptId
        ' fetch_Ids_from_diffTable(CmbxDesi, CmbxDesi.Text)
        ' DesiId = DptId
        fetch_Ids_from_desi()
        fetch_Ids_from_diffTable(Txtwrkid, Txtwrkid.Text)
        WrkId = Me.Txtwrkid.SelectedValue
        fetch_Bnkid_from_Table(Txtbnkname, Txtbnkname.Text)
        BnkId1 = BnkId
        temp = Trim(TxtEmpName.Text)
        Dim Paymode As String = ""
        Try
            If Add_Edit_Flag = True Then
                P_Roll_Mstr_Cmd = New SqlCommand("Finact_EmpMstr_insert", FinActConn)
                P_Roll_Mstr_Cmd.CommandType = CommandType.StoredProcedure
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Eadusrid", Current_UsrId)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Eaddt", Now)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empcateg", "Working")
            ElseIf Add_Edit_Flag = False Then
                P_Roll_Mstr_Cmd = New SqlCommand("Finact_EmpMstr_update", FinActConn)
                P_Roll_Mstr_Cmd.CommandType = CommandType.StoredProcedure
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@EEid", EiD)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Eedtusrid", Current_UsrId)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Eedtdt", Now)
                'EmpInfoSaveRec()
                'EmpFmlySaverec()
                If TxtVPpercnt.Text <> "" And TxtAmtpf.Text <> "" And TxtTfrdamt.Text <> "" Then
                    EmpProFndSaverec()
                    EmpNomineeSaverec()
                End If
                'EmpAcadmicSaverec()
                'EmpExprnSaverec()
                'EmpOtherSaverec()
            End If

            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@ename", Trim(TxtEmpName.Text))
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@edisname", Trim(txtdispl.Text))
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@ewrkid", WrkId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Edob", DtpkrDob.Value)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ejndt", Dtpkrdoj.Value)

            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Eprbprd", txtprobation.Value)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Econfrmdt", DtpkrDocon.Value)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Eresistatus", 1)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebrnchid", BrnchId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ecatid", CatId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Edeptid", DeptId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Edesiid", DesiId)

            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Escale", CDbl(Lblscale.Text))
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empbscgrade", CDbl(TxtScale.Text))
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empcategory", CmbxCateg.Text)
            If CmbxBonus.Text = "Yes" Then
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empbonusappli", 1)
            ElseIf CmbxBonus.Text = "No" Then
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empbonusappli", 0)
            End If
            If Rbcash.Checked = True Then
                Paymode = "ByCash"
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnkid", 0)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnkcode", 0)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnkactno", 0)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnktype", 0)
            ElseIf Rbchq.Checked = True Then
                Paymode = "ByCheque"
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnkid", 0)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnkcode", 0)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnkactno", 0)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnktype", 0)
            ElseIf RbTfr.Checked = True Then
                Paymode = "ByBankTransfer"
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnkid", BnkId1)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnkcode", TxtbCode.Text)
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnkactno", Trim(TxtAccNo.Text))
                P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Ebnktype", TxtAccType.Text)

            End If
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@EPayMode", Trim(Paymode))
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Edelstatus", 1)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Eimage", ImagePath)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@emplstatus", CmbxEmpStat.Text)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empothrsift", CmbxSift.Text)

            P_Roll_Mstr_Cmd.ExecuteNonQuery()

            Clr_Values_mstr()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_Cmd = Nothing
        End Try

    End Sub

    Private Sub fetch_rec_city()
        Try
            Info_Cty_Cmd = New SqlCommand("select cscid,cscctyname from FinactCscmstr where csctype='" & (ctytype) & "'", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            While Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    CmbxCty1.Items.Add(Info_Cty_Rdr("cscctyname"))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try
    End Sub

    Private Sub fetch_rec_statecontry1()
        Try
            Info_Cty_Cmd = New SqlCommand("select * from FinactCscmstr where cscctyname=@city", FinActConn)
            Info_Cty_Cmd.Parameters.AddWithValue("@city", CmbxCty1.Text)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            If Trim(CmbxCty1.Text) <> "" Then
                Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    ctyid1 = Info_Cty_Rdr("cscid")
                    LblState.Text = Info_Cty_Rdr("cscstatename")
                    LblContry.Text = Info_Cty_Rdr("csccontry")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try
    End Sub

    Private Sub fetch_rec_city1()
        Try
            Info_Cty_Cmd = New SqlCommand("select cscid,cscctyname from FinactCscmstr where csctype='" & (ctytype) & "'", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            While Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    cmbxCurCty.Items.Add(Info_Cty_Rdr("cscctyname"))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()

        End Try
    End Sub

    Private Sub fetch_rec_statecontry2()
        Try
            Info_Cty_Cmd = New SqlCommand("select * from FinactCscmstr where cscctyname=@city", FinActConn)
            Info_Cty_Cmd.Parameters.AddWithValue("@city", cmbxCurCty.Text)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            If Trim(cmbxCurCty.Text) <> "" Then
                Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    ctyid2 = Info_Cty_Rdr("cscid")
                    LblCurState.Text = Info_Cty_Rdr("cscstatename")
                    LblCurContry.Text = Info_Cty_Rdr("csccontry")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try
    End Sub

    Private Sub fetch_rec_city2()
        Try
            Info_Cty_Cmd = New SqlCommand("select cscid,cscctyname from FinactCscmstr where csctype='" & (ctytype) & "'", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            While Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    Cmbxctynomi.Items.Add(Info_Cty_Rdr("cscctyname"))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()

        End Try
    End Sub

    Private Sub fetch_rec_statecontry3()
        Try
            Info_Cty_Cmd = New SqlCommand("select * from FinactCscmstr where cscctyname=@city", FinActConn)
            Info_Cty_Cmd.Parameters.AddWithValue("@city", Cmbxctynomi.Text)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            If Trim(Cmbxctynomi.Text) <> "" Then
                Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    ctyid3 = Info_Cty_Rdr("cscid")
                    LblStatenomi.Text = Info_Cty_Rdr("cscstatename")
                    LblContryNomi.Text = Info_Cty_Rdr("csccontry")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try
    End Sub

    Private Sub fetch_rec_city3()
        ctytype = "Inner"
        Try
            Info_Cty_Cmd = New SqlCommand("select cscid,cscctyname from FinactCscmstr where csctype='" & (ctytype) & "'", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            While Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    cmbxWrkLoc.Items.Add(Info_Cty_Rdr("cscctyname"))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()

        End Try
    End Sub

    Private Sub fetch_empid()
        Try
            P_Roll_Empid_Cmd = New SqlCommand("select empid from FinactEmpmstr where empname='" & (temp) & "' ", FinActConn)
            P_Roll_Empid_Rdr = P_Roll_Empid_Cmd.ExecuteReader
            P_Roll_Empid_Rdr.Read()
            If P_Roll_Empid_Rdr.HasRows = True Then
                empid = (P_Roll_Empid_Rdr(0))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Empid_Cmd = Nothing
            P_Roll_Empid_Rdr.Close()
        End Try
    End Sub
    Private Sub EmpApntLetrSaverec()

        Try
            If Add_Edit_Flag = True Then
                P_Roll_Exprn_Cmd = New SqlCommand("Finact_EmpApntLetr_Insert", FinActConn)
                P_Roll_Exprn_Cmd.CommandType = CommandType.StoredProcedure
                fetch_empid()
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empapntconcrnid", empid)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empapntadusrid", Current_UsrId)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empapntaddt", Now)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empapntdelstatus", 1)
            ElseIf Add_Edit_Flag = False Then
                P_Roll_Exprn_Cmd = New SqlCommand("Finact_EmpApntLetr_Update", FinActConn)
                P_Roll_Exprn_Cmd.CommandType = CommandType.StoredProcedure
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empapntconcrnid", EiD)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empapntedtusrid", Current_UsrId)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empapntedtdt", Now)
                Exprnid = Exprnid + 1
            End If
            P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empapntletr", Rcjtxtappnt.Text)

            P_Roll_Exprn_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Exprn_Cmd = Nothing
        End Try

    End Sub

    Private Sub EmpCnfrmLetrSaverec()

        Try
            If Add_Edit_Flag = True Then
                P_Roll_Exprn_Cmd = New SqlCommand("Finact_EmpCnfrmLetr_Insert", FinActConn)
                P_Roll_Exprn_Cmd.CommandType = CommandType.StoredProcedure
                fetch_empid()
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empcnfrmconcrnid", empid)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empcnfrmadusrid", Current_UsrId)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empcnfrmaddt", Now)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empcnfrmdelstatus", 1)
            ElseIf Add_Edit_Flag = False Then
                P_Roll_Exprn_Cmd = New SqlCommand("Finact_EmpCnfrmLetr_Update", FinActConn)
                P_Roll_Exprn_Cmd.CommandType = CommandType.StoredProcedure
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empcnfrmconcrnid", EiD)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empcnfrmedtusrid", Current_UsrId)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empcnfrmedtdt", Now)
                Exprnid = Exprnid + 1
            End If
            P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empcnfrmletr", RchtxtCnfrmltr.Text)

            P_Roll_Exprn_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Exprn_Cmd = Nothing
        End Try

    End Sub
    Private Sub EmpInfoSaveRec()
        Dim Ctyid1 As Integer
        Dim Ctyid2 As Integer
        Try
            Info_Cty_Cmd = New SqlCommand("select cscid from FinactCscmstr where cscctyname=@city", FinActConn)
            Info_Cty_Cmd.Parameters.AddWithValue("@city", CmbxCty1.Text)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            If Trim(CmbxCty1.Text) <> "" Then
                Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    Ctyid1 = Info_Cty_Rdr("cscid")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try

        Try
            Info_Cty_Cmd = New SqlCommand("select cscid from FinactCscmstr where cscctyname=@city", FinActConn)
            Info_Cty_Cmd.Parameters.AddWithValue("@city", cmbxCurCty.Text)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            If Trim(cmbxCurCty.Text) <> "" Then
                Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    Ctyid2 = Info_Cty_Rdr("cscid")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try

        Try
            If Add_Edit_Flag = True Then
                P_Roll_Info_Cmd = New SqlCommand("Finact_EmpInfo_Insert", FinActConn)
                P_Roll_Info_Cmd.CommandType = CommandType.StoredProcedure
                fetch_empid()
                P_Roll_Info_Cmd.Parameters.AddWithValue("@empconcrnid", empid)
                P_Roll_Info_Cmd.Parameters.AddWithValue("@empadusrid", Current_UsrId)
                P_Roll_Info_Cmd.Parameters.AddWithValue("@empaddt", Now)

            ElseIf Add_Edit_Flag = False Then
                P_Roll_Info_Cmd = New SqlCommand("Finact_EmpInfo_Update", FinActConn)
                P_Roll_Info_Cmd.CommandType = CommandType.StoredProcedure
                P_Roll_Info_Cmd.Parameters.AddWithValue("@empconcrnid", EiD)

                P_Roll_Info_Cmd.Parameters.AddWithValue("@empedtusrid", Current_UsrId)
                P_Roll_Info_Cmd.Parameters.AddWithValue("@empedtdt", Now)
            End If
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empdelstatus", 1)
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empadrs1", Trim(TxtAddrs.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empadrs2", Trim(TxtAddrs1.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empadrs3", Trim(TxtLndmrk.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("empctyid", Ctyid1)
            P_Roll_Info_Cmd.Parameters.AddWithValue("@emppin", Trim(txtPin.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empphno", Trim(txtphno.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empmobno", Trim(Txtmobno.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empemail", Trim(txtEmlid.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@emphight", NoHtFt.Value)
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empMarital", CmbxMStatus.Text)
            If CmbxMStatus.Text = "UnMarried" Or CmbxMStatus.Text = "Never Married" Then
                P_Roll_Info_Cmd.Parameters.AddWithValue("@empanniver", 0)
            Else
                P_Roll_Info_Cmd.Parameters.AddWithValue("@empanniver", DtpkrAnivrsry.Text)
            End If
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empsex", CmbxSex.Text)
            P_Roll_Info_Cmd.Parameters.AddWithValue("@emprelign", CmbxRelign.Text)
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empnation", Trim(Txtnatnl.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@emppersonid", Trim(TxtIdmark1.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@emppersonid1", Trim(TxtIdmark2.Text))

            P_Roll_Info_Cmd.Parameters.AddWithValue("@empcuradrs1", Trim(TxtCurAddrs.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empcuradrs2", Trim(TxtCurAdd1.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empcuradrs3", Trim(TxtCurLnd.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("empcurctyid", Ctyid2)
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empcurpin", Trim(TxtCurPin.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empcurphno", Trim(TxtCurPhno.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empcurmobno", Trim(txtcurmobno.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@emppan", Trim(TxtPan.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empgirno", Trim(TxtGir.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empitrange", Trim(Txtrange.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empitward", Trim(Txtward.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empfather", Trim(TxtFhname.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empmother", Trim(TxtMoname.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empspose", Trim(TxtSposName.Text))
            P_Roll_Info_Cmd.Parameters.AddWithValue("@empEmrgency", Trim(TxtEmrgncyNo.Text))
            If same_adrs_flag = True Then
                P_Roll_Info_Cmd.Parameters.AddWithValue("@empadrssame", 1)
            ElseIf same_adrs_flag = False Then
                P_Roll_Info_Cmd.Parameters.AddWithValue("@empadrssame", 0)
            End If

            P_Roll_Info_Cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Info_Cmd = Nothing
        End Try
    End Sub


    Private Sub EmpOtherSaverec()
        Try
            If Add_Edit_Flag = True Then
                P_Roll_Othr_Cmd = New SqlCommand("Finact_EmpOthr_Insert", FinActConn)
                P_Roll_Othr_Cmd.CommandType = CommandType.StoredProcedure
                fetch_empid()
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrconcrnid", empid)
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothradusrid", Current_UsrId)
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothraddt", Now)

            ElseIf Add_Edit_Flag = False Then
                P_Roll_Othr_Cmd = New SqlCommand("Finact_EmpOthr_Update", FinActConn)
                P_Roll_Othr_Cmd.CommandType = CommandType.StoredProcedure
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrconcrnid", EiD)
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothredtusrid", Current_UsrId)
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothredtdt", Now)
            End If
            P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrdelstatus", 1)
            P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrrec", Trim(TxtRecAgncy.Text))

            P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrrote", TxtTptRute.Text)

            P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrwrklocatn", cmbxWrkLoc.Text)
            P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrcoVtype", CmbxCoVeclType.Text)
            If CmbxCoVeclType.Text = "None" Then
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrcoVNo", 0)
            Else
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrcoVNo", txtCoVeclNo.Text)
            End If
            P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrmobno", TxtMobile.Text)
            P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrcolaptop", Txtlaptop.Text)
            P_Roll_Othr_Cmd.Parameters.AddWithValue("empothrcomailid", Txtmailid.Text)

            If ChkBxResi.Checked = True Then
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrresi", "Yes")
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrdtofresi", DtpkrSubmit.Value.Date)
                If RbAccept.Checked = True Then

                    P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrresiacptdt", DtpkrAccept.Value.Date)

                ElseIf RbAccept.Checked = False Then
                    P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrresiacptdt", 0)

                End If
                If DtpkrRelev.Enabled = True Then
                    P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrrelevdt", DtpkrRelev.Value.Date)
                ElseIf DtpkrRelev.Enabled = False Then
                    P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrrelevdt", 0)
                End If

                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrresireson", TxtReason.Text)
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrresiremrk", TxtRemks.Text)

            ElseIf ChkBxResi.Checked = False Then
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrresi", "No")
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrdtofresi", 0)
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrresiacptdt", 0)
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrrelevdt", 0)
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrresireson", "")
                P_Roll_Othr_Cmd.Parameters.AddWithValue("@empothrresiremrk", "")
            End If
            P_Roll_Othr_Cmd.ExecuteNonQuery()


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Othr_Cmd = Nothing
        End Try
        If DtpkrAccept.Checked = True Then
            Try
                P_Roll_Mstr_Cmd = New SqlCommand("update finactempmstr set empcateg='Non-Working' where empid='" & (EiD) & "'", FinActConn)
                P_Roll_Mstr_Cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Mstr_rdr.Close()
                P_Roll_Mstr_Cmd = Nothing

            End Try
        End If

    End Sub

    Private Sub fetch_Acadid()
        Try
            P_Roll_Acadid_Cmd = New SqlCommand("select min(empAcadmicid) from FinActEmpAcadmic where empAcadmicconcrnid='" & (EiD) & "' ", FinActConn)
            P_Roll_Acadid_Rdr = P_Roll_Acadid_Cmd.ExecuteReader
            P_Roll_Acadid_Rdr.Read()
            Acadid = (P_Roll_Acadid_Rdr(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Acadid_Cmd = Nothing
            P_Roll_Acadid_Rdr.Close()
        End Try
    End Sub

    Private Sub EmpAcadmicSaverec()
        Dim TotAcad, Counter As Integer
        Counter = 0
        TotAcad = Lstvew1.Items.Count
        cntr_save_acad = 0
        While Counter < TotAcad
            Try
                If Acadmode = "add" Then
                    P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpAcad_Insert", FinActConn)
                    P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure
                    fetch_empid()
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicconcrnid", empid)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicadusrid", Current_UsrId)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicaddt", Now)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdelstatus", 1)

                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdigre", Lstvew1.Items(Counter).SubItems(0).Text)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicPasYr", Lstvew1.Items(Counter).SubItems(1).Text)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicClass", Lstvew1.Items(Counter).SubItems(2).Text)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicSubjct", Lstvew1.Items(Counter).SubItems(3).Text)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicInsti", Lstvew1.Items(Counter).SubItems(4).Text)
                    P_Roll_Acad_Cmd.ExecuteNonQuery()
                    cntr_save_acad = cntr_save_acad + 1
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Acad_Cmd = Nothing
            End Try
            Counter = Counter + 1
        End While
        Dblclick = 0
    End Sub



    Private Sub Fetch_SlryBrkup()
        Try
            Info_Cty_Cmd = New SqlCommand("select max(SBid) from FinactEmp_SlryBrkup", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            Info_Cty_Rdr.Read()
            If Info_Cty_Rdr.HasRows = True Then
                SlryBrkup_Id = Info_Cty_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try
    End Sub



    Private Sub EmpSlryBrkupSaverec()

        Try
            If Add_Edit_Flag = True Then
                P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpSlryBrkup_Insert", FinActConn)
                P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure
                fetch_empid()
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBEmpConcrnId", empid)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBadusrid", Current_UsrId)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBaddt", Now)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBdelstatus", 1)

            ElseIf Add_Edit_Flag = False Then
                P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpSlryBrkup_Update", FinActConn)
                P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBEmpConcrnId", EiD)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBedtusrid", Current_UsrId)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBedtdt", Now)
            End If
            If RbYes.Checked = True And RbNo.Checked = False Then
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBovrtm", 1)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBcompo", 0)
            ElseIf RbYes.Checked = False And RbNo.Checked = True Then
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBovrtm", 0)
                If RbYesCmpo.Checked = True Then
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBcompo", 1)
                ElseIf RbYesCmpo.Checked = False Then
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBcompo", 0)
                ElseIf RbYesCmpo.Checked = False And RbNoCmpo.Checked = False Then
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBcompo", 0)

                End If
            End If

            If RbYes_Phed.Checked = True Then
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBphed", 1)
            ElseIf RbYes_Phed.Checked = False Then
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@SBphed", 0)
            End If
            P_Roll_Acad_Cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Acad_Cmd = Nothing
        End Try

        If RbYes_Phed.Checked = True Then
            If fetch_recrd = False Then
                Add_Edit_Flag = True
                Phed_Save()
            ElseIf fetch_recrd = True Then
                Dim cnt_phed, cnt, cnt_list, cnt_arr As Integer
                j = 0
                Try
                    P_Roll_Acad_Cmd = New SqlCommand("Select PdPhedId from FinactEmp_SlryPhed where PdSlryConcrnId='" & (SlryBrk_Id) & "'", FinActConn)
                    P_Roll_Acad_rdr = P_Roll_Acad_Cmd.ExecuteReader
                    If Trim(EiD) <> "" Then
                        If P_Roll_Acad_rdr.HasRows = True Then
                            While P_Roll_Acad_rdr.Read()

                                arr_PhedId(j) = P_Roll_Acad_rdr(0)
                                j = j + 1
                            End While
                            cnt_arr = j

                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    P_Roll_Acad_rdr.Close()
                    P_Roll_Acad_Cmd = Nothing
                End Try

                Dim update_flag As Boolean = False

                cnt_phed = 0
                cnt = 0
                cnt_list = LstvewPhed.Items.Count
                While cnt < cnt_list
                    cnt_phed = 0

                    While cnt_phed < cnt_arr
                        If LstvewPhed.Items(cnt).SubItems(1).Text = arr_PhedId(cnt_phed) Then
                            If LstvewPhed.Items(cnt).Checked = False Then
                                update_flag = True
                                Try

                                    P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpSlryPhed_Update", FinActConn)
                                    P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure

                                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdedtusrid", Current_UsrId)
                                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdedtdt", Now)
                                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pddelstatus", 0)

                                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdSlryConcrnid", SlryBrk_Id)

                                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdPhedId", LstvewPhed.Items(cnt).SubItems(1).Text)

                                    P_Roll_Acad_Cmd.ExecuteNonQuery()

                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                Finally
                                    P_Roll_Acad_Cmd = Nothing
                                End Try
                                'cnt_phed = cnt_phed + 1
                                cnt_phed = cnt_arr

                            ElseIf LstvewPhed.Items(cnt).Checked = True Then
                                update_flag = True
                                Try

                                    P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpSlryPhed_Update", FinActConn)
                                    P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure

                                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdedtusrid", Current_UsrId)
                                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdedtdt", Now)
                                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pddelstatus", 1)

                                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdSlryConcrnid", SlryBrk_Id)

                                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdPhedId", LstvewPhed.Items(cnt).SubItems(1).Text)

                                    P_Roll_Acad_Cmd.ExecuteNonQuery()

                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                Finally
                                    P_Roll_Acad_Cmd = Nothing
                                End Try

                            End If
                            ' cnt_phed = cnt_phed + 1
                            cnt_phed = cnt_arr
                        Else
                            ''If LstvewPhed.Items(cnt).Checked = True Then
                            ''    Try

                            ''        P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpSlryPhed_Insert", FinActConn)
                            ''        P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure

                            ''        P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdadusrid", Current_UsrId)
                            ''        P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdaddt", Now)
                            ''        P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pddelstatus", 1)

                            ''        P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdSlryConcrnid", SlryBrk_Id)

                            ''        P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdPhedId", LstvewPhed.Items(cnt).SubItems(1).Text)

                            ''        P_Roll_Acad_Cmd.ExecuteNonQuery()

                            ''    Catch ex As Exception
                            ''        MsgBox(ex.Message)
                            ''    Finally
                            ''        P_Roll_Acad_Cmd = Nothing
                            ''    End Try
                            ''End If
                            cnt_phed = cnt_phed + 1
                            update_flag = False
                            ''cnt_phed = cnt_arr
                        End If


                    End While
                    If update_flag = False Then
                        If LstvewPhed.Items(cnt).Checked = True Then
                            Try

                                P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpSlryPhed_Insert", FinActConn)
                                P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure

                                P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdadusrid", Current_UsrId)
                                P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdaddt", Now)
                                P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pddelstatus", 1)

                                P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdSlryConcrnid", SlryBrk_Id)

                                P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdPhedId", LstvewPhed.Items(cnt).SubItems(1).Text)

                                P_Roll_Acad_Cmd.ExecuteNonQuery()

                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                P_Roll_Acad_Cmd = Nothing
                            End Try
                        End If

                    End If

                    cnt = cnt + 1
                End While
            End If
            'Fetch_SlryBrkup()
            'Dim cntr_phed, Totl_recrds As Integer
            'cntr_phed = 0
            'Totl_recrds = LstvewPhed.Items.Count
            'While cntr_phed < Totl_recrds
            '    If LstvewPhed.Items(cntr_phed).Checked = True Then
            '        Try
            '            If Add_Edit_Flag = True Then
            '                P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpSlryPhed_Insert", FinActConn)
            '                P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure

            '                P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdadusrid", Current_UsrId)
            '                P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdaddt", Now)
            '                P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pddelstatus", 1)

            '            ElseIf Add_Edit_Flag = False Then
            '                P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpSlryPhed_Update", FinActConn)
            '                P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure

            '                P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdedtusrid", Current_UsrId)
            '                P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdedtdt", Now)
            '            End If

            '            P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdSlryConcrnid", SlryBrkup_Id)

            '            P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdPhedId", LstvewPhed.Items(cntr_phed).SubItems(1).Text)

            '            P_Roll_Acad_Cmd.ExecuteNonQuery()

            '        Catch ex As Exception
            '            MsgBox(ex.Message)
            '        Finally
            '            P_Roll_Acad_Cmd = Nothing
            '        End Try
            '    End If
            '    cntr_phed = cntr_phed + 1

            'End While
        ElseIf RbYes_Phed.Checked = False And RbNoPhed.Checked = True Then
            If fetch_recrd = True Then

                Try

                    P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpSlryPhed_Delete", FinActConn)
                    P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdSlryConcrnid", SlryBrk_Id)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pddelusrid", Current_UsrId)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pddeldt", Now)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pddelstatus", 0)
                    P_Roll_Acad_Cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    P_Roll_Acad_Cmd = Nothing
                End Try
            End If

        End If



    End Sub


    Private Sub Phed_Save()

        Fetch_SlryBrkup()
        Dim cntr_phed, Totl_recrds As Integer
        cntr_phed = 0
        Totl_recrds = LstvewPhed.Items.Count
        While cntr_phed < Totl_recrds
            If LstvewPhed.Items(cntr_phed).Checked = True Then
                Try
                    If Add_Edit_Flag = True Then
                        P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpSlryPhed_Insert", FinActConn)
                        P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure

                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdadusrid", Current_UsrId)
                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pdaddt", Now)
                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@Pddelstatus", 1)

                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdSlryConcrnid", SlryBrkup_Id)

                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@PdPhedId", LstvewPhed.Items(cntr_phed).SubItems(1).Text)

                        P_Roll_Acad_Cmd.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    P_Roll_Acad_Cmd = Nothing
                End Try
            End If
            cntr_phed = cntr_phed + 1

        End While

    End Sub



    Private Sub fetch_Acad_cntr()
        Try
            Info_Cty_Cmd = New SqlCommand("select count(empAcadmicid) from FinActEmpAcadmic where empAcadmicconcrnid='" & (EiD) & "'and empAcadmicdelstatus=1", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            Info_Cty_Rdr.Read()
            If Info_Cty_Rdr.IsDBNull(0) = False Then
                Acad_cntr = Info_Cty_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try
    End Sub

    Private Sub EmpAcadmicSaverec1()
        Dim TotAcad, Counter_Acad As Integer
        fetch_Acad_cntr()
        Counter_Acad = Acad_cntr
        TotAcad = Lstvew1.Items.Count
        fetch_Acadid()
        cntr_save_acad1 = 0
        While Counter_Acad < TotAcad
            Try
                If Acadmode = "edit" Then
                    P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpAcad_Insert", FinActConn)
                    P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure
                    fetch_empid()
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicconcrnid", empid)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicadusrid", Current_UsrId)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicaddt", Now)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdelstatus", 1)

                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdigre", Lstvew1.Items(Counter_Acad).SubItems(0).Text)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicPasYr", Lstvew1.Items(Counter_Acad).SubItems(1).Text)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicClass", Lstvew1.Items(Counter_Acad).SubItems(2).Text)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicSubjct", Lstvew1.Items(Counter_Acad).SubItems(3).Text)
                    P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicInsti", Lstvew1.Items(Counter_Acad).SubItems(4).Text)
                    P_Roll_Acad_Cmd.ExecuteNonQuery()
                    cntr_save_acad1 = cntr_save_acad1 + 1
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Acad_Cmd = Nothing
            End Try
            Counter_Acad = Counter_Acad + 1
        End While
        Dblclick = 0
    End Sub

    Private Sub fetch_Exprnid()
        Try
            P_Roll_Exprnid_Cmd = New SqlCommand("select min(empExprid) from FinActempExprnce where empexprconcrnid='" & (EiD) & "' ", FinActConn)
            P_Roll_Exprnid_Rdr = P_Roll_Exprnid_Cmd.ExecuteReader
            P_Roll_Exprnid_Rdr.Read()
            Exprnid = (P_Roll_Exprnid_Rdr(0))

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Exprnid_Cmd = Nothing
            P_Roll_Exprnid_Rdr.Close()
        End Try
    End Sub

    Private Sub EmpExprnSaverec()

        Dim TotExprn, Counter1 As Integer
        TotExprn = Lstvew2.Items.Count
        Counter1 = 0
        cntr_save_exprn = 0
        While Counter1 < TotExprn
            Try
                If Exprncmode = "add" Then
                    P_Roll_Exprn_Cmd = New SqlCommand("Finact_EmpExprn_Insert", FinActConn)
                    P_Roll_Exprn_Cmd.CommandType = CommandType.StoredProcedure
                    fetch_empid()
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprconcrnid", empid)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexpradusrid", Current_UsrId)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexpraddt", Now)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprdelstatus", 1)

                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexpremplr", Lstvew2.Items(Counter1).SubItems(0).Text)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprjndt", Lstvew2.Items(Counter1).SubItems(1).Text)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprlevdt", Lstvew2.Items(Counter1).SubItems(2).Text)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprjnas", Lstvew2.Items(Counter1).SubItems(3).Text)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprlevas", Lstvew2.Items(Counter1).SubItems(4).Text)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprsalry", CDbl(Lstvew2.Items(Counter1).SubItems(5).Text))

                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprAchiv", Lstvew2.Items(Counter1).SubItems(6).Text)

                    P_Roll_Exprn_Cmd.ExecuteNonQuery()
                    cntr_save_exprn = cntr_save_exprn + 1
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Exprn_Cmd = Nothing
            End Try
            Counter1 = Counter1 + 1
        End While
        Dblclick = 0
    End Sub

    Private Sub fetch_Exprn_cntr()
        Try
            Info_Cty_Cmd = New SqlCommand("select count(empExprid) from FinActEmpExprnce where empexprconcrnid='" & (EiD) & "'and empexprdelstatus=1", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            Info_Cty_Rdr.Read()
            If Info_Cty_Rdr.IsDBNull(0) = False Then
                Expr_cntr = Info_Cty_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try
    End Sub

    Private Sub EmpExprnSaverec1()
        Dim TotExprn, Counter_Exprnc As Integer
        fetch_Exprn_cntr()
        TotExprn = Lstvew2.Items.Count
        Counter_Exprnc = Expr_cntr
        fetch_Exprnid()
        cntr_save_exprn1 = 0
        While Counter_Exprnc < TotExprn
            Try
                If Exprncmode = "edit" Then
                    P_Roll_Exprn_Cmd = New SqlCommand("Finact_EmpExprn_Insert", FinActConn)
                    P_Roll_Exprn_Cmd.CommandType = CommandType.StoredProcedure
                    fetch_empid()
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprconcrnid", empid)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexpradusrid", Current_UsrId)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexpraddt", Now)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprdelstatus", 1)

                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexpremplr", Lstvew2.Items(Counter_Exprnc).SubItems(0).Text)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprjndt", Lstvew2.Items(Counter_Exprnc).SubItems(1).Text)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprlevdt", Lstvew2.Items(Counter_Exprnc).SubItems(2).Text)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprjnas", Lstvew2.Items(Counter_Exprnc).SubItems(3).Text)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprlevas", Lstvew2.Items(Counter_Exprnc).SubItems(4).Text)
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprsalry", CDbl(Lstvew2.Items(Counter_Exprnc).SubItems(5).Text))
                    P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprAchiv", Lstvew2.Items(Counter_Exprnc).SubItems(6).Text)

                    P_Roll_Exprn_Cmd.ExecuteNonQuery()
                    cntr_save_exprn1 = cntr_save_exprn1 + 1
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Exprn_Cmd = Nothing
            End Try
            Counter_Exprnc = Counter_Exprnc + 1
        End While
        Dblclick = 0
    End Sub

    Private Sub fetch_Fmlyid()
        Try
            P_Roll_Fmlyid_Cmd = New SqlCommand("select min(empfmlyid) from FinactEmpFmly where empfmlyconcrnid='" & (EiD) & "' ", FinActConn)
            P_Roll_Fmlyid_Rdr = P_Roll_Fmlyid_Cmd.ExecuteReader
            P_Roll_Fmlyid_Rdr.Read()
            Fmlyid = (P_Roll_Fmlyid_Rdr(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Fmlyid_Cmd = Nothing
            P_Roll_Fmlyid_Rdr.Close()
        End Try
    End Sub


    Private Sub EmpFmlySaverec()
        Dim Counter2 As Integer
        Totfmly = LSTVEW3.Items.Count
        Counter2 = 0
        cntr_save = 0
        While Counter2 < Totfmly

            Try
                If Fmlymode = "add" Then
                    P_Roll_Fmly_Cmd = New SqlCommand("Finact_EmpFmly_Insert", FinActConn)
                    P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
                    fetch_empid()
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyconcrnid", empid)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyadusrid", Current_UsrId)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyaddt", Now)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydelstatus", 1)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydpend", Totfmly)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlymembr", LSTVEW3.Items(Counter2).SubItems(0).Text)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlymembrdob", LSTVEW3.Items(Counter2).SubItems(1).Text) ' dob)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyrelatn", LSTVEW3.Items(Counter2).SubItems(2).Text)
                    P_Roll_Fmly_Cmd.ExecuteNonQuery()
                    cntr_save = cntr_save + 1
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Fmly_Cmd = Nothing
            End Try
            Counter2 = Counter2 + 1
            Nodepnd.Value = Nodepnd.Value + 1
        End While
        Dblclick = 0
    End Sub

    Private Sub fetch_Fmly_cntr()
        Try
            Info_Cty_Cmd = New SqlCommand("select count(empfmlyid) from FinactEmpFmly where empfmlyconcrnid='" & (EiD) & "'and empfmlydelstatus=1", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            Info_Cty_Rdr.Read()
            If Info_Cty_Rdr.IsDBNull(0) = False Then
                Fmly_cntr = Info_Cty_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try
    End Sub

    Private Sub EmpFmlySaverec1()
        Dim Counter3 As Integer
        Totfmly = LSTVEW3.Items.Count
        fetch_Fmly_cntr()
        Counter3 = Fmly_cntr
        cntr_save1 = 0
        While Counter3 < Totfmly

            Try
                If Fmlymode = "edit" Then

                    P_Roll_Fmly_Cmd = New SqlCommand("Finact_EmpFmly_Insert", FinActConn)
                    P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
                    fetch_empid()
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyconcrnid", empid)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyadusrid", Current_UsrId)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyaddt", Now)

                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydelstatus", 1)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydpend", Totfmly)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlymembr", LSTVEW3.Items(Counter3).SubItems(0).Text)

                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlymembrdob", LSTVEW3.Items(Counter3).SubItems(1).Text)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyrelatn", LSTVEW3.Items(Counter3).SubItems(2).Text)
                    P_Roll_Fmly_Cmd.ExecuteNonQuery()
                    cntr_save1 = cntr_save1 + 1
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Fmly_Cmd = Nothing
            End Try
            Counter3 = Counter3 + 1
        End While
        Dblclick = 0
    End Sub

    Private Sub EmpProFndSaverec()
        Dim Ctyid3 As Integer
        Try
            Info_Cty_Cmd = New SqlCommand("select cscid from FinactCscmstr where cscctyname=@city", FinActConn)
            Info_Cty_Cmd.Parameters.AddWithValue("@city", Cmbxctynomi.Text)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            If Trim(Cmbxctynomi.Text) <> "" Then
                Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    Ctyid3 = Info_Cty_Rdr("cscid")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try

        Try
            If Add_Edit_Flag = True Then
                P_Roll_Fmly_Cmd = New SqlCommand("Finact_EmpProFn_Insert", FinActConn)
                P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
                fetch_empid()
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("emppfconcrnid", empid)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@emppfadusrid", Current_UsrId)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@emppfaddt", Now)

            ElseIf Add_Edit_Flag = False Then
                P_Roll_Fmly_Cmd = New SqlCommand("Finact_EmpProFn_Update", FinActConn)
                P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("emppfconcrnid", EiD)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@emppfedtusrid", Current_UsrId)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@emppfedtdt", Now)
            End If
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@emppfdelstatus", 1)
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empPfSetldt", DtpkrSettldt.Value)
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empPfJndt", DtpkrPfJdt.Value)

            If ChkPFappli.Checked = True Then
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empPfApli", 1)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empvpfPcent", Trim(TxtVPpercnt.Text))
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empAmtPf", CDbl(TxtAmtpf.Text))
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empamtTfrd", CDbl(TxtTfrdamt.Text))
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empPfno", TxtPFNo.Text)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnewpfno", TxtNewPfNo.Text)
            ElseIf ChkPFappli.Checked = False Then
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empPfApli", 0)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empvpfPcent", 0)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empAmtPf", CDbl(0))
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empamtTfrd", CDbl(0))
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empPfno", 0)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnewpfno", 0)
            End If

            If ChkEsicAppli.Checked = True Then
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empesiapli", 1)
            ElseIf ChkEsicAppli.Checked = False Then
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empesiapli", 0)
            End If


            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@emplicpno", TxtPolicno.Text)
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@emplicid", TxtInsId.Text)
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@emplicprmdt", DtpkrRenewdt.Value.Date)
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@emplicprmdtto", DtpkrTo.Value.Date)
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empEsicno", TxtEsic.Text)
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empDispensry", TxtDispName.Text)
            'P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnominame", TxtNomine.Text)
            'P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomireltn", cmbxrelt.Text)
            'P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomidob", DtpkrDob.Value)
            'P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomiadrs", Txtadrsnomi.Text)
            'P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomiadrs1", txtadrsnomi1.Text)
            'P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomictyid", Ctyid3)
            'P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomipin", TxtPinNomi.Text)
            'If cmbxstatus.Text = "Major" Then
            '    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomistatus", 1)       'If Status is Major
            'Else
            '    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomistatus", 0)       'If Status is Minor
            'End If
            'P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomigrdian", Txtgrdian.Text)
            P_Roll_Fmly_Cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Fmly_Cmd = Nothing
        End Try
    End Sub


    Private Sub EmpNomineeSaverec()
        Dim counter1 As Integer = 0
        Dim lstcnt As Integer = 0
        Dim PFId As Integer = 0
        lstcnt = FrmNmDetails.DataGridView1.Rows.Count

        Dim Ctyid3 As Integer
        k = 0
        While counter1 < lstcnt
            Try
                Info_Cty_Cmd = New SqlCommand("select cscid from FinactCscmstr where cscctyname=@city", FinActConn)
                Info_Cty_Cmd.Parameters.AddWithValue("@city", FrmNmDetails.DataGridView1.Rows(counter1).Cells(7).Value)
                Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader

                Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    Ctyid3 = Info_Cty_Rdr("cscid")
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Info_Cty_Cmd = Nothing
                Info_Cty_Rdr.Close()
            End Try

            Try
                Info_Cty_Cmd = New SqlCommand("select max(empPfEsiId) from FinActEmpPfEsi where emppfdelstatus=1", FinActConn)

                Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader

                Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    PFId = Info_Cty_Rdr(0)
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Info_Cty_Cmd = Nothing
                Info_Cty_Rdr.Close()
            End Try

            Try
                If Add_Edit_Flag = True Then
                    P_Roll_Fmly_Cmd = New SqlCommand("Finact_NmDetls_Insert", FinActConn)
                    P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
                    ' fetch_empid()
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("PfConcrnId", PFId)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmadusrid", Current_UsrId)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmaddt", Now)

                ElseIf Add_Edit_Flag = False Then
                    P_Roll_Fmly_Cmd = New SqlCommand("Finact_NmDetails_Update", FinActConn)
                    P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("PfConcrnId", Fetch_PFId)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("NmId", arr_nmid(k))
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmedtusrid", Current_UsrId)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmedtdt", Now)
                    k = k + 1
                End If
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmdelstatus", 1)

                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnominame", FrmNmDetails.DataGridView1.Rows(counter1).Cells(0).Value)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomireltn", FrmNmDetails.DataGridView1.Rows(counter1).Cells(1).Value)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomidob", FrmNmDetails.DataGridView1.Rows(counter1).Cells(10).Value)

                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomiadrs", FrmNmDetails.DataGridView1.Rows(counter1).Cells(4).Value)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomiadrs1", FrmNmDetails.DataGridView1.Rows(counter1).Cells(5).Value)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomictyid", Ctyid3)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomipin", FrmNmDetails.DataGridView1.Rows(counter1).Cells(8).Value)
                If FrmNmDetails.DataGridView1.Rows(counter1).Cells(2).Value = "Major" Then
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomistatus", 1)       'If Status is Major
                Else
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomistatus", 0)       'If Status is Minor
                End If
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomigrdian", FrmNmDetails.DataGridView1.Rows(counter1).Cells(6).Value)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomishare", FrmNmDetails.DataGridView1.Rows(counter1).Cells(3).Value)
                P_Roll_Fmly_Cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Fmly_Cmd = Nothing
            End Try
            counter1 = counter1 + 1

        End While
    End Sub


    Private Sub DtpkrDob_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpkrDob.ValueChanged
        Dtpkrdoj.MinDate = (DtpkrDob.Value.AddYears(15))
        Dtpkrdoj.MaxDate = Dtpkrdoj.Value.AddYears(51)
        Dtpkrdoj.Value = (DtpkrDob.Value.AddYears(15))
        DtpkrDocon.MinDate = Dtpkrdoj.MinDate
        DtpkrDocon.Value = Dtpkrdoj.MinDate
        'DtpkrDoResi.MinDate = Dtpkrdoj.MinDate
        ' DtpkrDoResi.Value = Dtpkrdoj.MinDate
    End Sub

    Private Sub CmbxDept_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDept.GotFocus
        fetch_Record_from_diffTable(CmbxDept, "Dept")

        If CmbxDept.Items.Count > 0 Then
            If CmbxDept.Text = "" Then
                CmbxDept.SelectedIndex = 0
            End If
            CmbxDept.DroppedDown = True
        End If
    End Sub

    Private Sub CmbxCat_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCat.GotFocus
        fetch_Record_from_diffTable(CmbxCat, "Catgri")

        If CmbxCat.Items.Count > 0 Then
            If CmbxCat.Text = "" Then
                CmbxCat.SelectedIndex = 0
            End If
            CmbxCat.DroppedDown = True
        End If

    End Sub

    Private Sub CmbxDesi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDesi.GotFocus
        'fetch_Record_from_diffTable(CmbxDesi, "Desi")
        fetch_Record_from_desi()
        If CmbxDesi.Items.Count > 0 Then
            If CmbxDesi.Text = "" Then
                CmbxDesi.SelectedIndex = 0
            End If
            CmbxDesi.DroppedDown = True
        End If

    End Sub

    Private Sub txtdispl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdispl.GotFocus
        txtdispl.SelectAll()
    End Sub

    Private Sub CmbxBrnch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxBrnch.GotFocus
        fetch_Record_from_diffTable(CmbxBrnch, "Brnch")

        If CmbxBrnch.Items.Count > 0 Then
            If CmbxBrnch.Text = "" Then
                CmbxBrnch.SelectedIndex = 0
            End If
            CmbxBrnch.DroppedDown = True
        End If
    End Sub


    Private Sub TxtEmpName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmpName.TextChanged
        txtdispl.Text = Trim(TxtEmpName.Text)
        txtdispl.ReadOnly = True
        If TxtEmpName.BackColor <> Color.White Then
            TxtEmpName.BackColor = Color.White
            txtdispl.BackColor = Color.White
        End If
    End Sub

    Private Sub DtpkrDoResi_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        'DtpkrDoResi.MinDate = Dtpkrdoj.Value
    End Sub

    Private Sub DtpkrDocon_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrDocon.GotFocus
        'DtpkrDocon.MinDate = Dtpkrdoj.Value.Date
        ' If btnedt.Text = "&Edit" Then
        DtpkrDocon.MinDate = Dtpkrdoj.Value.Date.AddMonths(txtprobation.Text)
        'End If
    End Sub

    Private Sub Dtpkrdoj_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpkrdoj.GotFocus
        If doj_flag = False Then
            Dtpkrdoj.Value = Today.Date
        End If
        ''''Dtpkrdoj.MinDate = (DtpkrDob.Value.AddYears(15))
        ''''Dtpkrdoj.MaxDate = Dtpkrdoj.Value.AddYears(51)
        Dtpkrdoj.MaxDate = Dtpkrdoj.Value.AddMonths(6)
        DtpkrDocon.MinDate = Dtpkrdoj.MinDate
        ' DtpkrSubmit.MinDate = Dtpkrdoj.Value.AddDays(+1)
        'DtpkrAccept.MinDate = DtpkrSubmit.Value.Date
        'DtpkrDoResi.MinDate = Today
    End Sub

    Private Sub Dtpkrdoj_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtpkrdoj.ValueChanged

        DtpkrDocon.MinDate = Dtpkrdoj.Value
        'DtpkrDoResi.MinDate = Dtpkrdoj.Value
        DtpkrJndt.MaxDate = Dtpkrdoj.Value.Date.AddMonths(-3)

        DtpkrLevDt.MaxDate = Dtpkrdoj.Value.Date.AddDays(-1)


    End Sub


    Private Sub Lnklempimag_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Lnklempimag.LinkClicked
        Try
            Dim ImageName As String
            fso = CreateObject("Scripting.FileSystemObject")
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                MySource = OpenFileDialog1.FileName
                ImageName = Path.GetFileName(MySource)
                EmpImage.Image = Image.FromFile(MySource)
                ImagePath = Application.StartupPath & "\images\" & ImageName
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Btnclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnclos.Click
        Dim cnfrmcls As String
        cnfrmcls = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmcls = vbYes Then
            Me.Close()
        ElseIf cnfrmcls = vbNo Then
            Btnsave.Focus()
        End If


    End Sub

    Private Sub fetch_Ids_from_diffTable(ByVal Combox As ComboBox, ByVal DptName As String)
        DptId = 0
        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Select deptid from finactdept where deptname='" & (DptName) & "'", FinActConn)
            P_Roll_Mstr_rdr = P_Roll_Mstr_Cmd.ExecuteReader
            If Trim(DptName) <> "" Then
                P_Roll_Mstr_rdr.Read()
                If P_Roll_Mstr_rdr.HasRows = True Then
                    DptId = P_Roll_Mstr_rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_rdr.Close()
            P_Roll_Mstr_Cmd = Nothing
        End Try

    End Sub

    Private Sub fetch_Ids_from_desi()
        DesiId = 0
        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Select desiid from finactDesi where desiname='" & (CmbxDesi.Text) & "'", FinActConn)
            P_Roll_Mstr_rdr = P_Roll_Mstr_Cmd.ExecuteReader
            If Trim(CmbxDesi.Text) <> "" Then
                P_Roll_Mstr_rdr.Read()
                If P_Roll_Mstr_rdr.HasRows = True Then
                    DesiId = P_Roll_Mstr_rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_rdr.Close()
            P_Roll_Mstr_Cmd = Nothing
        End Try

    End Sub
    Private Sub Txtwrkid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtwrkid.GotFocus

        Try
            If Txtwrkid.Items.Count > 0 Then
                If Me.Txtwrkid.SelectedIndex = -1 Then
                    Txtwrkid.SelectedIndex = 0
                End If
            Else
                Fill_Combobox("Machinid", "Machinname", "finact_MachinMstr", "MachinDelStatus", CInt(1), Me.Txtwrkid)
            End If
            Txtwrkid.DroppedDown = True
        Catch ex As Exception

        End Try


    End Sub

    Private Sub fetch_Bnkid_from_Table(ByVal Combox As ComboBox, ByVal BnkName As String)
        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Select splrid from finactsplrmstr where splrname='" & (BnkName) & "'", FinActConn)
            P_Roll_Mstr_rdr = P_Roll_Mstr_Cmd.ExecuteReader
            If Trim(BnkName) <> "" Then
                P_Roll_Mstr_rdr.Read()
                If P_Roll_Mstr_rdr.HasRows = True Then
                    BnkId = P_Roll_Mstr_rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_rdr.Close()
            P_Roll_Mstr_Cmd = Nothing
        End Try

    End Sub
    Private Sub fetch_BnkName_from_Table(ByVal Combox As ComboBox, ByVal RecType As String)
        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Select splrname from finactsplrmstr where splrtype='" & (RecType) & "'", FinActConn)
            P_Roll_Mstr_rdr = P_Roll_Mstr_Cmd.ExecuteReader
            Combox.Items.Clear()
            If Trim(RecType) <> "" Then
                While P_Roll_Mstr_rdr.Read
                    If P_Roll_Mstr_rdr.HasRows = True Then
                        Combox.Items.Add(P_Roll_Mstr_rdr(0))
                    End If
                End While
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_rdr.Close()
            P_Roll_Mstr_Cmd = Nothing
        End Try
    End Sub

    Private Sub Txtbnkname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbnkname.GotFocus
        fetch_BnkName_from_Table(Txtbnkname, "Bank")
        Txtbnkname.DroppedDown = True
        If Txtbnkname.Items.Count > 0 And Txtbnkname.Text = "" Then
            Txtbnkname.SelectedIndex = 0
        End If


    End Sub

    Private Sub numericTextboxKeyPress1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtScale.KeyPress, Txtslry.KeyPress, TxtAmtpf.KeyPress, TxtTfrdamt.KeyPress

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

    Private Sub numericTextboxKeyPress2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMobile.KeyPress, TxtPinNomi.KeyPress, txtPin.KeyPress, txtphno.KeyPress, Txtmobno.KeyPress, TxtCurPin.KeyPress, TxtCurPhno.KeyPress, txtcurmobno.KeyPress, TxtEmrgncyNo.KeyPress
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar <> "." Then
            If (tb.SelectedText <> "." Or IsNumeric(tb.Text & e.KeyChar)) Then
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

    Private Sub numericTextboxKeyPress3(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPan.KeyPress, TxtGir.KeyPress, TxtbCode.KeyPress, TxtAccNo.KeyPress, TxtPolicno.KeyPress, TxtEsic.KeyPress, TxtJnDesi.KeyPress, TxtLevdesi.KeyPress, TxtInsId.KeyPress

        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar

        If e.KeyChar = "." Then
            If (tb.SelectedText <> ".") Then
                e.Handled = True
            ElseIf IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = IsNumeric(tb.Text & e.KeyChar)

            End If

        End If
    End Sub

    Private Sub numericTextboxKeyPress4(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFhname.KeyPress

        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar

        If e.KeyChar = "." Then
            If (tb.SelectedText <> ".") Then
                e.Handled = True
            End If


        End If
    End Sub

    Private Sub Invaliddata()

        With Txtmailid
            If Trim(.Text) <> "" Then
                If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then

                    .BackColor = Color.White
                    .ForeColor = Color.Black
                Else
                    .BackColor = Color.LemonChiffon
                    .ForeColor = Color.Black
                    .Focus()
                    IndxMstr = IndxMstr + 1
                End If
            End If
        End With
        With txtEmlid
            If Trim(.Text) <> "" Then
                If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then

                    .BackColor = Color.White
                    .ForeColor = Color.Black
                Else
                    .BackColor = Color.LemonChiffon
                    .ForeColor = Color.Black
                    .Focus()
                    IndxMstr = IndxMstr + 1
                End If
            End If
        End With
    End Sub

    Private Sub Clr_Values_mstr()
        TxtEmpName.Clear()
        txtdispl.Clear()
        If CmbxDept.SelectedIndex >= 1 Then
            CmbxDept.SelectedIndex = 0

        End If
        If CmbxDesi.SelectedIndex >= 1 Then
            CmbxDesi.SelectedIndex = 0
        End If

        If Txtwrkid.SelectedIndex >= 1 Then
            Txtwrkid.SelectedIndex = 0
        End If

        txtprobation.Value = 0
        If CmbxBrnch.SelectedIndex >= 1 Then
            CmbxBrnch.SelectedIndex = 0
        End If

        If CmbxCat.SelectedIndex >= 1 Then
            CmbxCat.SelectedIndex = 0
        End If

        If CmbxEmpStat.SelectedIndex >= 1 Then
            CmbxEmpStat.SelectedIndex = 0
        End If

        If CmbxCateg.SelectedIndex >= 1 Then
            CmbxCateg.SelectedIndex = 0
        End If
        If CmbxSift.SelectedIndex >= 1 Then
            CmbxSift.SelectedIndex = 0
        End If

        TxtScale.Clear()
        TxtbCode.Clear()
        TxtAccNo.Clear()
        Lblscale.Text = ""
        If TxtEmpName.BackColor <> Color.White Then
            TxtEmpName.BackColor = Color.White
        End If
        If txtdispl.BackColor <> Color.White Then
            txtdispl.BackColor = Color.White
        End If
        If TxtScale.BackColor <> Color.White Then
            TxtScale.BackColor = Color.White
        End If
        If TxtbCode.BackColor <> Color.White Then
            TxtbCode.BackColor = Color.White
        End If
        If TxtAccNo.BackColor <> Color.White Then
            TxtAccNo.BackColor = Color.White
        End If
        'EmpImage.Image = ""
    End Sub

    Private Sub Clr_Values_Info()
        TxtAddrs.Clear()
        TxtAddrs1.Clear()
        TxtLndmrk.Clear()
        If CmbxCty1.SelectedIndex >= 0 Or CmbxCty1.SelectedIndex = -1 Then
            CmbxCty1.SelectedIndex = 0

        End If

        LblState.Text = ""
        LblContry.Text = ""
        txtPin.Clear()
        txtphno.Clear()
        Txtmobno.Clear()
        txtEmlid.Clear()
        If CmbxSex.SelectedIndex >= 0 Or CmbxSex.SelectedIndex = -1 Then
            CmbxSex.SelectedIndex = 0
        End If

        If CmbxMStatus.SelectedIndex >= 1 Or CmbxMStatus.SelectedIndex = -1 Then
            CmbxMStatus.SelectedIndex = 0
        End If

        If CmbxRelign.SelectedIndex >= 1 Or CmbxRelign.SelectedIndex = -1 Then
            CmbxRelign.SelectedIndex = 0
        End If

        Txtnatnl.Clear()
        TxtIdmark1.Clear()
        TxtIdmark2.Clear()
        TxtCurAddrs.Clear()
        TxtCurAdd1.Clear()
        TxtCurLnd.Clear()
        If cmbxCurCty.SelectedIndex >= 1 Or cmbxCurCty.SelectedIndex = -1 Then
            cmbxCurCty.SelectedIndex = 0
        End If

        LblCurState.Text = ""
        LblCurContry.Text = ""
        TxtCurPin.Clear()
        TxtCurPhno.Clear()
        txtcurmobno.Clear()
        TxtPan.Clear()
        TxtGir.Clear()
        Txtrange.Clear()
        Txtward.Clear()
        TxtFhname.Clear()
        TxtMoname.Clear()
        TxtSposName.Clear()
        TxtEmrgncyNo.Clear()
        'if txtaddrs.BackColor=
    End Sub

    Private Sub Clr_Values_Other()
        TxtRecAgncy.Clear()
        TxtTptRute.Clear()
        If cmbxWrkLoc.SelectedIndex >= 1 Then
            'Or cmbxWrkLoc.SelectedIndex = -1 Then
            cmbxWrkLoc.SelectedIndex = 0
        End If

        If CmbxCoVeclType.SelectedIndex >= 1 Then
            ' Or CmbxCoVeclType.SelectedIndex = -1 Then
            CmbxCoVeclType.SelectedIndex = 0
        End If

        txtCoVeclNo.Clear()
        TxtMobile.Clear()
        Txtlaptop.Clear()
        Txtmailid.Clear()
        TxtReason.Clear()
        TxtRemks.Clear()

    End Sub

    Private Sub Clr_Values_Exprn()
        TxtEmplr.Clear()
        TxtJnDesi.Clear()
        TxtLevdesi.Clear()
        Txtslry.Clear()
        Txtachive.Clear()
        Lstvew2.Items.Clear()

    End Sub

    Private Sub Clr_Values_ApntLetr()
        Rcjtxtappnt.Text = ""
    End Sub

    Private Sub Clr_Values_CnfrmLetr()
        RchtxtCnfrmltr.Text = ""
    End Sub

    Private Sub Clr_Values_Acad()
        If CmbxDegree.SelectedIndex >= 1 Or CmbxDegree.SelectedIndex = -1 Then
            CmbxDegree.SelectedIndex = 0

        End If

        'Txtpassyr.Clear()
        If CmbxClass.SelectedIndex >= 1 Or CmbxClass.SelectedIndex = -1 Then
            CmbxClass.SelectedIndex = 0

        End If

        Txtsubjts.Clear()
        TxtInsti.Clear()
        Lstvew1.Items.Clear()

    End Sub

    Private Sub Clr_Values_Fmly()
        Nodepnd.Value = 0
        TxtName1.Clear()
        If cmbxRelatn.SelectedIndex >= 1 Or cmbxRelatn.SelectedIndex = -1 Then
            cmbxRelatn.SelectedIndex = 0

        End If

        LSTVEW3.Items.Clear()

    End Sub

    Private Sub Clr_Values_PF()
        TxtVPpercnt.Clear()
        ChkPFappli.CheckState = CheckState.Unchecked
      
        ChkEsicAppli.CheckState = CheckState.Unchecked
        TxtAmtpf.Clear()
        TxtTfrdamt.Clear()
        TxtPFNo.Clear()
        TxtPolicno.Clear()
        TxtInsId.Clear()
        TxtEsic.Clear()
        TxtDispName.Clear()
        TxtNomine.Clear()
        If cmbxrelt.SelectedIndex >= 1 Or cmbxrelt.SelectedIndex = -1 Then
            cmbxrelt.SelectedIndex = 0

        End If

        Txtadrsnomi.Clear()
        txtadrsnomi1.Clear()
        If Cmbxctynomi.SelectedIndex >= 1 Or Cmbxctynomi.SelectedIndex = -1 Then
            Cmbxctynomi.SelectedIndex = 0

        End If

        LblStatenomi.Text = ""
        LblContryNomi.Text = ""
        TxtPinNomi.Clear()
        If cmbxstatus.SelectedIndex >= 1 Or cmbxstatus.SelectedIndex = -1 Then
            cmbxstatus.SelectedIndex = 0

        End If

        Txtgrdian.Clear()

    End Sub

    Private Sub Clr_Values_SlryBrkup()

        If RbYes.Checked = True Then
            RbYes.Checked = False
        End If

        If RbNo.Checked = True Then
            RbNo.Checked = False
        End If
        If RbYes_Phed.Checked = True Then
            RbYes_Phed.Checked = False

        End If
        If RbNoPhed.Checked = True Then
            RbNoPhed.Checked = False

        End If
        LstvewPhed.Items.Clear()

    End Sub


    Private Sub fetch_AllRec_from_Table()
        Dim SelLst As ListViewItem

        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Select empname,empid from finactempmstr where empdelstatus<>'" & (0) & "'order by empname", FinActConn)
            P_Roll_Mstr_rdr = P_Roll_Mstr_Cmd.ExecuteReader
            LstVewSelRec.Items.Clear()
            While P_Roll_Mstr_rdr.Read
                If P_Roll_Mstr_rdr.HasRows = True Then
                    SelLst = LstVewSelRec.Items.Add(P_Roll_Mstr_rdr(0))
                    SelLst.SubItems.Add((P_Roll_Mstr_rdr(1)))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_rdr.Close()
            P_Roll_Mstr_Cmd = Nothing
        End Try
    End Sub



    Private Sub fetch_Crnt_Slry()
        Try
            Info_Cty_Cmd = New SqlCommand("select max(ApFnlSlry) from FinactEmpAppraisal where ApEid='" & (EiD) & "'and Apdelstatus=0 and month(ApEfDt)<='" & (Month(Today.Date)) & "'and year(ApEfDt)<='" & (Year(Today.Date)) & "'", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            Info_Cty_Rdr.Read()
            If Info_Cty_Rdr.IsDBNull(0) = False Then
                Fnl_Slry = Info_Cty_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Info_Cty_Rdr.IsDBNull(0) = True Then
                Fnl_Slry = 0
            End If

            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try
    End Sub

    Private Sub updt_crnt_slry()

        Try
            Info_Cty_Cmd = New SqlCommand("Update  FinactEmpmstr set empgrade=@empgrade where empid='" & (EiD) & "' ", FinActConn)
            ' where(Month(Attddt) = 6)
            Info_Cty_Cmd.Parameters.AddWithValue("empgrade", Fnl_Slry)
            Info_Cty_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
        End Try


    End Sub


    Private Sub LstVewSelRec_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewSelRec.DoubleClick
        FrmNmDetails.DataGridView1.Rows.Clear()
        EmpImage.Image = Nothing
        Btndel.Enabled = True
        Panel5.Enabled = True
        GroupBox1.Enabled = True
        doj_flag = True
        Enabletru()
        EiD = 0
        Dim Wrkid, BrnchId, Catid, DeptId, Bnkid2 As Integer
        Dim Pymode As String = ""
        Dim Cityid As Integer
        Dim Cityid1 As Integer
        Dim Cityid2 As Integer
        Dim Status As Integer
        Dim Pfapli As Integer
        Dim esiapli As Integer
        Dim bonusapli As Boolean = False

        EiD = LstVewSelRec.SelectedItems(0).SubItems.Item(1).Text.ToString()
        fetch_Crnt_Slry()

        'FETCH MASTER RECORD

        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Select * from finactempmstr where empid='" & (EiD) & "'", FinActConn)
            P_Roll_Mstr_rdr = P_Roll_Mstr_Cmd.ExecuteReader
            LstVewSelRec.Items.Clear()
            If Trim(EiD) <> "" Then
                P_Roll_Mstr_rdr.Read()
                If P_Roll_Mstr_rdr.HasRows = True Then
                    TxtEmpName.Text = P_Roll_Mstr_rdr("empname")
                    temp = Trim(TxtEmpName.Text)
                    Emname = temp
                    txtdispl.Text = P_Roll_Mstr_rdr("empdsplaname")
                    Wrkid = P_Roll_Mstr_rdr("empwrkid")
                    DtpkrDob.Value = P_Roll_Mstr_rdr("empdobdt")
                    txtprobation.Value = P_Roll_Mstr_rdr("empprobprd")
                    Dtpkrdoj.Value = P_Roll_Mstr_rdr("empjndt")
                    DtpkrDocon.Value = P_Roll_Mstr_rdr("empconfrmdt")

                    BrnchId = P_Roll_Mstr_rdr("empbrnchid")
                    Catid = P_Roll_Mstr_rdr("empcatid")
                    DesId = P_Roll_Mstr_rdr("empdesiid")
                    DeptId = P_Roll_Mstr_rdr("empdeptid")
                    CmbxEmpStat.Text = P_Roll_Mstr_rdr("emplstatus")
                    CmbxCateg.Text = P_Roll_Mstr_rdr("empcategory")
                    Dim str As String
                    str = P_Roll_Mstr_rdr("empothrsift")
                    CmbxSift.Text = str
                    Pymode = P_Roll_Mstr_rdr("emppaymode")
                    If P_Roll_Mstr_rdr.IsDBNull(19) = False Then
                        ImagePath = P_Roll_Mstr_rdr("empimagepath")
                        If ImagePath <> "None" Then
                            EmpImage.Image = Image.FromFile(P_Roll_Mstr_rdr("empimagepath"))
                            ' End If
                        Else
                            EmpImage.Image = Nothing
                        End If
                    End If

                    If Trim(Pymode) = "ByCash" Then
                        Rbcash.Checked = True
                    ElseIf Trim(Pymode) = "ByCheque" Then
                        Rbchq.Checked = True
                    ElseIf Trim(Pymode) = "ByBankTransfer" Then
                        RbTfr.Checked = True
                        Bnkid2 = P_Roll_Mstr_rdr("empbnkid")
                        TxtbCode.Text = P_Roll_Mstr_rdr("empbnkcode")
                        TxtAccNo.Text = P_Roll_Mstr_rdr("empbnkac")
                        TxtAccType.Text = P_Roll_Mstr_rdr("empbnkactype")
                    End If
                    TxtScale.Text = FormatNumber(P_Roll_Mstr_rdr("empbscgrade"), 2)
                    lblScale.Text = FormatNumber(P_Roll_Mstr_rdr("empgrade"), 2)
                    bonusapli = P_Roll_Mstr_rdr("empbonusappli")
                    If bonusapli = True Then
                        CmbxBonus.Text = "Yes"
                    ElseIf bonusapli = False Then
                        CmbxBonus.Text = "No"
                    End If


                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_rdr.Close()
            P_Roll_Mstr_Cmd = Nothing
            Me.Panel5.Enabled = True
            Me.GroupBox1.Enabled = True
            Panel3.Height = 53
            LstVewSelRec.Items.Clear()
            LstVewSelRec.Height = 25
            Me.Panel3.Enabled = False
            TxtEmpName.Focus()
            Btndel.Enabled = True
        End Try
        If Fnl_Slry > 0 Then
            Lblscale.Text = FormatNumber(Fnl_Slry, 2)
            updt_crnt_slry()
        End If

        Txtwrkid.DropDownStyle = ComboBoxStyle.DropDown
        CmbxBrnch.DropDownStyle = ComboBoxStyle.DropDown
        CmbxCat.DropDownStyle = ComboBoxStyle.DropDown
        CmbxDesi.DropDownStyle = ComboBoxStyle.DropDown
        CmbxDept.DropDownStyle = ComboBoxStyle.DropDown
        Txtbnkname.DropDownStyle = ComboBoxStyle.DropDown

        ' fetch_Name_from_diffTable(Txtwrkid, Wrkid)
        Me.Txtwrkid.SelectedValue = Wrkid
        ' Txtwrkid.Text = Trim(DptName)
        fetch_Name_from_diffTable(CmbxBrnch, BrnchId)
        CmbxBrnch.Text = Trim(DptName)
        fetch_Name_from_diffTable(CmbxCat, Catid)
        CmbxCat.Text = Trim(DptName)
        fetch_Name_from_desi()
        fetch_Name_from_diffTable(CmbxDept, DeptId)
        CmbxDept.Text = Trim(DptName)
        If Trim(Pymode) = "ByBankTransfer" Then
            fetch_Bnkid_from_Table(Txtbnkname, Bnkid2)
            Txtbnkname.Text = Bnknam
        End If



        'FETCH PERSONAL INFO

        Try
            P_Roll_Info_Cmd1 = New SqlCommand("Select * from FinActEmpInfo where empconcrnid='" & (EiD) & "'", FinActConn)
            P_Roll_Info_Rdr1 = P_Roll_Info_Cmd1.ExecuteReader
            If Trim(EiD) <> "" Then
                P_Roll_Info_Rdr1.Read()
                If P_Roll_Info_Rdr1.HasRows = True Then

                    TxtAddrs.Text = P_Roll_Info_Rdr1("empadrs1")
                    TxtAddrs1.Text = P_Roll_Info_Rdr1("empadrs2")
                    TxtLndmrk.Text = P_Roll_Info_Rdr1("empadrs3")
                    Cityid1 = P_Roll_Info_Rdr1("empctyid")
                    txtPin.Text = P_Roll_Info_Rdr1("emppin")
                    txtphno.Text = P_Roll_Info_Rdr1("empphno")
                    Txtmobno.Text = P_Roll_Info_Rdr1("empmobno")
                    txtEmlid.Text = P_Roll_Info_Rdr1("empemail")
                    NoHtFt.Value = P_Roll_Info_Rdr1("emphight")
                    CmbxSex.Text = P_Roll_Info_Rdr1("empsex")
                    CmbxMStatus.Text = P_Roll_Info_Rdr1("empMarital")
                    If CmbxMStatus.Text = "UnMarried" Or CmbxMStatus.Text = "Never Married" Then
                        DtpkrAnivrsry.Enabled = False
                    Else
                        DtpkrAnivrsry.Enabled = True
                        DtpkrAnivrsry.Text = P_Roll_Info_Rdr1("empanniver")
                    End If
                    CmbxRelign.Text = P_Roll_Info_Rdr1("emprelign")
                    Txtnatnl.Text = P_Roll_Info_Rdr1("empnation")
                    TxtIdmark1.Text = P_Roll_Info_Rdr1("emppersonid")
                    TxtIdmark2.Text = P_Roll_Info_Rdr1("emppersonid1")
                    TxtCurAddrs.Text = P_Roll_Info_Rdr1("empcuradrs1")
                    TxtCurAdd1.Text = P_Roll_Info_Rdr1("empcuradrs2")
                    TxtCurLnd.Text = P_Roll_Info_Rdr1("empcuradrs3")
                    Cityid2 = P_Roll_Info_Rdr1("empcurctyid")
                    TxtCurPin.Text = P_Roll_Info_Rdr1("empcurpin")
                    TxtCurPhno.Text = P_Roll_Info_Rdr1("empcurphno")
                    txtcurmobno.Text = P_Roll_Info_Rdr1("empcurmobno")
                    TxtPan.Text = P_Roll_Info_Rdr1("emppan")
                    TxtGir.Text = P_Roll_Info_Rdr1("empgirno")
                    Txtrange.Text = P_Roll_Info_Rdr1("empitrange")
                    Txtward.Text = P_Roll_Info_Rdr1("empitward")
                    TxtFhname.Text = P_Roll_Info_Rdr1("empfather")
                    TxtMoname.Text = P_Roll_Info_Rdr1("empmother")
                    TxtSposName.Text = P_Roll_Info_Rdr1("empspose")
                    TxtEmrgncyNo.Text = P_Roll_Info_Rdr1("empEmrgency")
                    Infomode = "edit"
                Else
                    Infomode = "add"

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Info_Rdr1.Close()
            P_Roll_Info_Cmd1 = Nothing
        End Try

        Try

            Info_Cty_Cmd1 = New SqlCommand("select cscctyname,cscstatename,csccontry from FinactCscmstr where cscid='" & (Cityid1) & "' ", FinActConn)
            Info_Cty_Rdr1 = Info_Cty_Cmd1.ExecuteReader
            If Trim(Cityid1) <> "" Then
                Info_Cty_Rdr1.Read()
                If Info_Cty_Rdr1.HasRows = True Then
                    CmbxCty1.Text = Info_Cty_Rdr1("cscctyname")
                    LblState.Text = Info_Cty_Rdr1("cscstatename")
                    LblContry.Text = Info_Cty_Rdr1("csccontry")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd1 = Nothing
            Info_Cty_Rdr1.Close()
        End Try

        Try
            Info_Cty_Cmd = New SqlCommand("select cscctyname,cscstatename,csccontry from FinactCscmstr where cscid='" & (Cityid2) & "' ", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            If Trim(Cityid2) <> "" Then
                Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    cmbxCurCty.Text = Info_Cty_Rdr("cscctyname")
                    LblCurState.Text = Info_Cty_Rdr("cscstatename")
                    LblCurContry.Text = Info_Cty_Rdr("csccontry")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try

        'FETCH FAMILY RECORD
        cntr = 0
        Try
            P_Roll_Fmly_Cmd1 = New SqlCommand("Select * from FinActEmpFmly where empfmlyconcrnid='" & (EiD) & "'and empfmlydelstatus='" & (1) & "' ", FinActConn)
            P_Roll_Fmly_rdr1 = P_Roll_Fmly_Cmd1.ExecuteReader
            If Trim(EiD) <> "" Then
                If P_Roll_Fmly_rdr1.HasRows = True Then
                    While P_Roll_Fmly_rdr1.Read()

                        Nodepnd.Value = P_Roll_Fmly_rdr1("empfmlydpend")
                        lst = LSTVEW3.Items.Add(P_Roll_Fmly_rdr1("empfmlymembr"))
                        lst.SubItems.Add(P_Roll_Fmly_rdr1("empfmlymembrdob"))
                        lst.SubItems.Add(P_Roll_Fmly_rdr1("empfmlyrelatn"))
                        Fmlymode = "edit"
                        cntr = cntr + 1
                    End While

                Else
                    Fmlymode = "add"
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Fmly_rdr1.Close()
            P_Roll_Fmly_Cmd1 = Nothing
        End Try

        'FETCH APPOINTMENT LETTER
        Try
            P_Roll_Fmly_Cmd1 = New SqlCommand("Select empapntletr from FinactAppntLetr where empapntconcrnid='" & (EiD) & "'and empapntdelstatus='" & (1) & "' ", FinActConn)
            P_Roll_Fmly_rdr1 = P_Roll_Fmly_Cmd1.ExecuteReader
            If Trim(EiD) <> "" Then
                If P_Roll_Fmly_rdr1.HasRows = True Then
                    P_Roll_Fmly_rdr1.Read()

                    Rcjtxtappnt.Text = P_Roll_Fmly_rdr1("empapntletr")

                    Apntmode = "edit"

                Else
                    Apntmode = "add"
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Fmly_rdr1.Close()
            P_Roll_Fmly_Cmd1 = Nothing
        End Try

        'FETCH CONFIRMATION LETTER
        Try
            P_Roll_Fmly_Cmd1 = New SqlCommand("Select empcnfrmletr from FinactCnfrmLetr where empcnfrmconcrnid='" & (EiD) & "'and empcnfrmdelstatus='" & (1) & "' ", FinActConn)
            P_Roll_Fmly_rdr1 = P_Roll_Fmly_Cmd1.ExecuteReader
            If Trim(EiD) <> "" Then
                If P_Roll_Fmly_rdr1.HasRows = True Then
                    P_Roll_Fmly_rdr1.Read()

                    RchtxtCnfrmltr.Text = P_Roll_Fmly_rdr1("empcnfrmletr")

                    Cnfrmmode = "edit"

                Else
                    Cnfrmmode = "add"
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Fmly_rdr1.Close()
            P_Roll_Fmly_Cmd1 = Nothing
        End Try

        'FETCH PROVIDENT INFO
        Try
            P_Roll_Fmly_Cmd = New SqlCommand("Select * from FinActEmpPfEsi where emppfconcrnid='" & (EiD) & "'", FinActConn)
            P_Roll_Fmly_rdr = P_Roll_Fmly_Cmd.ExecuteReader
            If Trim(EiD) <> "" Then
                P_Roll_Fmly_rdr.Read()
                If P_Roll_Fmly_rdr.HasRows = True Then

                    Fetch_PFId = P_Roll_Fmly_rdr("empPfEsiId")
                    DtpkrSettldt.Text = P_Roll_Fmly_rdr("empPfSetldt")
                    DtpkrPfJdt.Text = P_Roll_Fmly_rdr("empPfJndt")
                    TxtVPpercnt.Text = P_Roll_Fmly_rdr("empvpfPcent")
                    Pfapli = P_Roll_Fmly_rdr("empPfApli")
                    If Pfapli = 0 Then
                        ChkPFappli.Checked = False
                    Else
                        ChkPFappli.Checked = True
                    End If

                    esiapli = P_Roll_Fmly_rdr("empesiapli")
                    If esiapli = 0 Then
                        ChkEsicAppli.Checked = False
                    Else
                        ChkEsicAppli.Checked = True
                    End If
                    TxtAmtpf.Text = FormatNumber(P_Roll_Fmly_rdr("empAmtPf"), 2)
                    TxtTfrdamt.Text = FormatNumber(P_Roll_Fmly_rdr("empamtTfrd"), 2)
                    TxtPFNo.Text = P_Roll_Fmly_rdr("empPfno")
                    TxtPolicno.Text = P_Roll_Fmly_rdr("emplicpno")
                    TxtInsId.Text = P_Roll_Fmly_rdr("emplicid")
                    DtpkrRenewdt.Text = P_Roll_Fmly_rdr("emplicprmdt")
                    DtpkrTo.Text = P_Roll_Fmly_rdr("emplicprmdtto")
                    TxtEsic.Text = P_Roll_Fmly_rdr("empEsicno")
                    TxtDispName.Text = P_Roll_Fmly_rdr("empDispensry")
                    TxtNewPfNo.Text = P_Roll_Fmly_rdr("empnewpfno")
                    ''TxtNomine.Text = P_Roll_Fmly_rdr("empnominame")
                    ''cmbxrelt.Text = P_Roll_Fmly_rdr("empnomireltn")
                    ''Dtpkrdob2.Text = P_Roll_Fmly_rdr("empnomidob")
                    ''Txtadrsnomi.Text = P_Roll_Fmly_rdr("empnomiadrs")
                    ''txtadrsnomi1.Text = P_Roll_Fmly_rdr("empnomiadrs1")
                    ''Cityid = P_Roll_Fmly_rdr("empnomictyid")
                    ''TxtPinNomi.Text = P_Roll_Fmly_rdr("empnomipin")
                    ''Status = P_Roll_Fmly_rdr("empnomistatus")
                    ''If Status = 0 Then
                    ''    cmbxstatus.Text = "Minor"
                    ''Else
                    ''    cmbxstatus.Text = "Major"
                    ''End If
                    ''Txtgrdian.Text = P_Roll_Fmly_rdr("empnomigrdian")
                    ProFndmode = "edit"
                Else
                    ProFndmode = "add"
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Fmly_rdr.Close()
            P_Roll_Fmly_Cmd = Nothing
        End Try

        ''Fetch Nominee Records
        Try
            P_Roll_Fmly_Cmd = New SqlCommand("Select * from FinactPFNomi where PfConcrnId='" & (Fetch_PFId) & "'AND Nmdelstatus=1", FinActConn)
            P_Roll_Fmly_rdr = P_Roll_Fmly_Cmd.ExecuteReader
            If Trim(Fetch_PFId) <> "" Then
                P_Roll_Fmly_rdr.Read()
                If P_Roll_Fmly_rdr.HasRows = True Then

                    TxtNomine.Text = P_Roll_Fmly_rdr("empnominame")
                    cmbxrelt.Text = P_Roll_Fmly_rdr("empnomireltn")
                    Dtpkrdob2.Text = P_Roll_Fmly_rdr("empnomidob")
                    Txtadrsnomi.Text = P_Roll_Fmly_rdr("empnomiadrs")
                    txtadrsnomi1.Text = P_Roll_Fmly_rdr("empnomiadrs1")
                    Cityid = P_Roll_Fmly_rdr("empnomictyid")
                    TxtPinNomi.Text = P_Roll_Fmly_rdr("empnomipin")
                    Status = P_Roll_Fmly_rdr("empnomistatus")
                    If Status = 0 Then
                        cmbxstatus.Text = "Minor"
                    Else
                        cmbxstatus.Text = "Major"
                    End If
                    Txtgrdian.Text = P_Roll_Fmly_rdr("empnomigrdian")
                    TxtNmShare.Text = P_Roll_Fmly_rdr("empnomishare")
                    ProFndmode = "edit"
                Else
                    ProFndmode = "add"
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Fmly_rdr.Close()
            P_Roll_Fmly_Cmd = Nothing
        End Try
        FrmNmDetails.DataGridView1.Rows.Clear()
        AddColumns()
        Dim s As Integer = 0
        k = 0
        Try
            P_Roll_Fmly_Cmd = New SqlCommand("Select * from FinactPFNomi where PfConcrnId='" & (Fetch_PFId) & "'and Nmdelstatus=1", FinActConn2)
            P_Roll_Fmly_rdr = P_Roll_Fmly_Cmd.ExecuteReader
            If Trim(Fetch_PFId) <> "" Then
                While P_Roll_Fmly_rdr.Read()
                    If P_Roll_Fmly_rdr.HasRows = True Then

                        dgr = New DataGridViewRow()


                        cel = New DataGridViewTextBoxCell()
                        cel.Value = P_Roll_Fmly_rdr("empnominame")
                        dgr.Cells.Add(cel)

                        com = New DataGridViewComboBoxCell
                        com.Items.Add("Father")
                        com.Items.Add("Mother")
                        com.Items.Add("Brother")
                        com.Items.Add("Sister")
                        com.Items.Add("Daughter")
                        com.Items.Add("Son")
                        com.Items.Add("Wife")
                        relatn = P_Roll_Fmly_rdr("empnomireltn")
                        If relatn = "Father" Then
                            com.Value = com.Items(0)
                        ElseIf relatn = "Mother" Then
                            com.Value = com.Items(1)
                        ElseIf relatn = "Brother" Then
                            com.Value = com.Items(2)
                        ElseIf relatn = "Sister" Then
                            com.Value = com.Items(3)
                        ElseIf relatn = "Daughter" Then
                            com.Value = com.Items(4)
                        ElseIf relatn = "Son" Then
                            com.Value = com.Items(5)
                        ElseIf relatn = "Wife" Then
                            com.Value = com.Items(6)
                        End If

                        ' com.Value = com.Items(P_Roll_Fmly_rdr("empnomireltn"))
                        dgr.Cells.Add(com)


                        com = New DataGridViewComboBoxCell
                        com.Items.Add("Major")
                        com.Items.Add("Minor")
                        Status = P_Roll_Fmly_rdr("empnomistatus")
                        If Status = 0 Then
                            com.Value = com.Items(1)
                        Else
                            com.Value = com.Items(0)
                        End If

                        dgr.Cells.Add(com)

                        cel = New DataGridViewTextBoxCell()
                        cel.Value = P_Roll_Fmly_rdr("empnomishare")
                        dgr.Cells.Add(cel)
                        'cel = New DataGridViewTextBoxCell()
                        'cel.Value = Format(P_Roll_Fmly_rdr("empnomidob"), "dd/MM/yyyy")
                        ' Me.Datagrd.Rows(i).Cells(6).Value = InTme
                        'dgr.Cells.Add(cel)

                        cel = New DataGridViewTextBoxCell()
                        cel.Value = P_Roll_Fmly_rdr("empnomiadrs")
                        dgr.Cells.Add(cel)
                        cel = New DataGridViewTextBoxCell()
                        cel.Value = P_Roll_Fmly_rdr("empnomiadrs1")
                        dgr.Cells.Add(cel)
                        cel = New DataGridViewTextBoxCell()
                        cel.Value = P_Roll_Fmly_rdr("empnomigrdian")
                        dgr.Cells.Add(cel)
                        Cityid = P_Roll_Fmly_rdr("empnomictyid")
                        com = New DataGridViewComboBoxCell
                        Try
                            Info_Cty_Cmd = New SqlCommand("select cscid,cscctyname from FinactCscmstr where csctype='Outer'", FinActConn1)
                            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
                            While Info_Cty_Rdr.Read()
                                If Info_Cty_Rdr.HasRows = True Then
                                    ' Cmbxctynomi.Items.Add(Info_Cty_Rdr("cscctyname"))
                                    com.Items.Add(Info_Cty_Rdr("cscctyname"))
                                End If
                            End While
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Info_Cty_Cmd = Nothing
                            Info_Cty_Rdr.Close()

                        End Try

                        com.Value = com.Items(0)
                        dgr.Cells.Add(com)


                        cel = New DataGridViewTextBoxCell()
                        cel.Value = P_Roll_Fmly_rdr("empnomipin")
                        dgr.Cells.Add(cel)


                        cel = New DataGridViewTextBoxCell()
                        cel.Value = P_Roll_Fmly_rdr("NmId")
                        arr_nmid(k) = P_Roll_Fmly_rdr("NmId")
                        dgr.Cells.Add(cel)

                        FrmNmDetails.DataGridView1.Rows.Add(dgr)
                        FrmNmDetails.DataGridView1.Rows(s).Cells(10).Value = P_Roll_Fmly_rdr("empnomidob") 'Format(P_Roll_Fmly_rdr("empnomidob"), "dd/MM/yyyy")
                        s = s + 1
                        LnkLblVew.Visible = True



                        '    TxtNomine.Text = P_Roll_Fmly_rdr("empnominame")
                        '    cmbxrelt.Text = P_Roll_Fmly_rdr("empnomireltn")
                        '    Dtpkrdob2.Text = P_Roll_Fmly_rdr("empnomidob")
                        '    Txtadrsnomi.Text = P_Roll_Fmly_rdr("empnomiadrs")
                        '    txtadrsnomi1.Text = P_Roll_Fmly_rdr("empnomiadrs1")
                        '    Cityid = P_Roll_Fmly_rdr("empnomictyid")
                        '    TxtPinNomi.Text = P_Roll_Fmly_rdr("empnomipin")
                        '    Status = P_Roll_Fmly_rdr("empnomistatus")
                        '    If Status = 0 Then
                        '        cmbxstatus.Text = "Minor"
                        '    Else
                        '        cmbxstatus.Text = "Major"
                        '    End If
                        '    Txtgrdian.Text = P_Roll_Fmly_rdr("empnomigrdian")
                        '    TxtNmShare.Text = P_Roll_Fmly_rdr("empnomishare")
                        ProFndmode = "edit"
                    Else
                        ProFndmode = "add"
                    End If
                    k = k + 1
                End While

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Fmly_rdr.Close()
            P_Roll_Fmly_Cmd = Nothing
        End Try



        If FrmNmDetails.DataGridView1.Rows.Count > 0 Then
            LnkLblVew.Visible = True
        Else
            LnkLblVew.Visible = False
        End If




        Try
            Info_Cty_Cmd = New SqlCommand("select cscctyname,cscstatename,csccontry from FinactCscmstr where cscid='" & (Cityid) & "' ", FinActConn)
            Info_Cty_Rdr = Info_Cty_Cmd.ExecuteReader
            If Trim(Cityid) <> "" Then
                Info_Cty_Rdr.Read()
                If Info_Cty_Rdr.HasRows = True Then
                    Cmbxctynomi.Text = Info_Cty_Rdr("cscctyname")
                    LblStatenomi.Text = Info_Cty_Rdr("cscstatename")
                    LblContryNomi.Text = Info_Cty_Rdr("csccontry")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_Rdr.Close()
        End Try

        'FETCH ACADMIC RECORD
        Dim Listview As ListViewItem
        fetch_Acadmic_cntr = 0
        Try
            P_Roll_Acad_Cmd = New SqlCommand("Select * from FinActEmpAcadmic where empAcadmicconcrnid='" & (EiD) & "'and empAcadmicdelstatus='" & (1) & "' ", FinActConn)
            P_Roll_Acad_rdr = P_Roll_Acad_Cmd.ExecuteReader
            If Trim(EiD) <> "" Then
                If P_Roll_Acad_rdr.HasRows = True Then
                    While P_Roll_Acad_rdr.Read()

                        Listview = Lstvew1.Items.Add(P_Roll_Acad_rdr("empAcadmicdigre"))
                        Listview.SubItems.Add(P_Roll_Acad_rdr("empAcadmicPasYr"))
                        Listview.SubItems.Add(P_Roll_Acad_rdr("empAcadmicClass"))
                        Listview.SubItems.Add(P_Roll_Acad_rdr("empAcadmicSubjct"))
                        Listview.SubItems.Add(P_Roll_Acad_rdr("empAcadmicInsti"))
                        Acadmode = "edit"
                        fetch_Acadmic_cntr = fetch_Acadmic_cntr + 1
                    End While
                Else
                    Acadmode = "add"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Acad_rdr.Close()
            P_Roll_Acad_Cmd = Nothing
        End Try
        Dim Listview1 As ListViewItem
        fetch_Exp_cntr = 0
        Try
            P_Roll_Exprn_Cmd = New SqlCommand("Select * from FinActempExprnce where empexprconcrnid='" & (EiD) & "'and empexprdelstatus='" & (1) & "' ", FinActConn)
            P_Roll_Exprn_rdr = P_Roll_Exprn_Cmd.ExecuteReader
            If Trim(EiD) <> "" Then
                If P_Roll_Exprn_rdr.HasRows = True Then
                    While P_Roll_Exprn_rdr.Read()

                        Listview1 = Lstvew2.Items.Add(P_Roll_Exprn_rdr("empexpremplr"))
                        Listview1.SubItems.Add(P_Roll_Exprn_rdr("empexprjndt"))
                        Listview1.SubItems.Add(P_Roll_Exprn_rdr("empexprlevdt"))
                        Listview1.SubItems.Add(P_Roll_Exprn_rdr("empexprjnas"))
                        Listview1.SubItems.Add(P_Roll_Exprn_rdr("empexprlevas"))
                        Listview1.SubItems.Add(P_Roll_Exprn_rdr("empexprsalry"))
                        Listview1.SubItems.Add(P_Roll_Exprn_rdr("empexprAchiv"))
                        Exprncmode = "edit"
                        fetch_Exp_cntr = fetch_Exp_cntr + 1

                    End While
                Else
                    Exprncmode = "add"

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Exprn_rdr.Close()
            P_Roll_Exprn_Cmd = Nothing
        End Try
        Dim AcptDt, RelvDt As Date
        Dim resistatus As String
        Try
            P_Roll_Othr_Cmd = New SqlCommand("Select * from Finactempothr where empothrconcrnid='" & (EiD) & "'", FinActConn)
            P_Roll_Othr_Rdr = P_Roll_Othr_Cmd.ExecuteReader
            If Trim(EiD) <> "" Then
                P_Roll_Othr_Rdr.Read()
                If P_Roll_Othr_Rdr.HasRows = True Then
                    TxtRecAgncy.Text = P_Roll_Othr_Rdr("empothrrec")
                    TxtTptRute.Text = P_Roll_Othr_Rdr("empothrrote")
                    cmbxWrkLoc.Text = P_Roll_Othr_Rdr("empothrwrklocatn")
                    CmbxCoVeclType.Text = P_Roll_Othr_Rdr("empothrcoVtype")
                    If CmbxCoVeclType.Text = "None" Then
                        txtCoVeclNo.Enabled = False
                    Else
                        txtCoVeclNo.Enabled = True
                        txtCoVeclNo.Text = P_Roll_Othr_Rdr("empothrcoVNo")
                    End If

                    TxtMobile.Text = P_Roll_Othr_Rdr("empothrmobno")
                    Txtlaptop.Text = P_Roll_Othr_Rdr("empothrcolaptop")
                    Txtmailid.Text = P_Roll_Othr_Rdr("empothrcomailid")
                    DtpkrSubmit.Text = P_Roll_Othr_Rdr("empothrdtofresi")
                    AcptDt = P_Roll_Othr_Rdr("empothrresiacptdt")
                    resistatus = P_Roll_Othr_Rdr("empothrresi")
                    If resistatus = "Yes" Then
                        ChkBxResi.Checked = True
                    ElseIf resistatus = "No" Then
                        ChkBxResi.Checked = False
                    End If
                    If AcptDt = "1/1/1900" Then
                        DtpkrAccept.Text = DtpkrAccept.MinDate
                        DtpkrAccept.Checked = False
                        RbReject.Checked = True
                    Else
                        DtpkrAccept.Text = AcptDt
                        DtpkrAccept.Checked = True
                        RbAccept.Checked = True


                    End If
                    RelvDt = P_Roll_Othr_Rdr("empothrrelevdt")
                    If RelvDt = "1/1/1900" Then
                        DtpkrRelev.Text = DtpkrRelev.MinDate
                        DtpkrRelev.Enabled = False
                    Else
                        DtpkrRelev.Text = RelvDt
                        DtpkrRelev.Enabled = True

                    End If
                    TxtReason.Text = P_Roll_Othr_Rdr("empothrresireson")
                    TxtRemks.Text = P_Roll_Othr_Rdr("empothrresiremrk")
                    Othermode = "edit"
                Else
                    Othermode = "add"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Othr_Rdr.Close()
            P_Roll_Othr_Cmd = Nothing
        End Try

        'Fetch Salary Breakup
        LstvewPhed.Items.Clear()
        Fetch_Payheds()
        Fetch_Payhead_Name()
        Dim SlryBrk_cmpo As Boolean = False

        Try
            P_Roll_Acad_Cmd = New SqlCommand("Select SBid,SBovrtm,SBphed,SBcompo from FinactEmp_SlryBrkup where SBEmpConcrnId='" & (EiD) & "'and SBdelstatus='" & (1) & "' ", FinActConn)
            P_Roll_Acad_rdr = P_Roll_Acad_Cmd.ExecuteReader
            If Trim(EiD) <> "" Then
                If P_Roll_Acad_rdr.HasRows = True Then
                    P_Roll_Acad_rdr.Read()

                    SlryBrk_Id = P_Roll_Acad_rdr(0)
                    SlryBrk_ovrtm = P_Roll_Acad_rdr(1)
                    SlryBrk_cmpo = P_Roll_Acad_rdr(3)
                    If SlryBrk_ovrtm = True Then
                        RbYes.Checked = True
                    ElseIf SlryBrk_ovrtm = False Then
                        RbYes.Checked = False
                        RbNo.Checked = True
                        RbYesCmpo.Enabled = True
                        RbNoCmpo.Enabled = True
                        If SlryBrk_cmpo = True Then
                            RbYesCmpo.Checked = True
                        ElseIf SlryBrk_cmpo = False Then
                            RbNoCmpo.Checked = True

                        End If
                    End If
                    SlryBrk_phed = P_Roll_Acad_rdr(2)

                    If SlryBrk_phed = "true" Then
                        RbYes_Phed.Checked = True
                    ElseIf SlryBrk_phed = "false" Then
                        RbYes_Phed.Checked = False
                        RbNoPhed.Checked = True

                    End If

                    SlryBrkmode = "edit"
                Else
                    SlryBrkmode = "add"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Acad_rdr.Close()
            P_Roll_Acad_Cmd = Nothing
        End Try
        If SlryBrk_phed = True And SlryBrkmode = "edit" Then
            fetch_recrd = True
            Dim cnt_phed, cnt_arr, cnt, cnt_list As Integer
            j = 0
            Try
                P_Roll_Acad_Cmd = New SqlCommand("Select PdPhedId from FinactEmp_SlryPhed where PdSlryConcrnId='" & (SlryBrk_Id) & "'and Pddelstatus='" & (1) & "' ", FinActConn)
                P_Roll_Acad_rdr = P_Roll_Acad_Cmd.ExecuteReader
                If Trim(EiD) <> "" Then
                    If P_Roll_Acad_rdr.HasRows = True Then
                        While P_Roll_Acad_rdr.Read()

                            arr_PhedId(j) = P_Roll_Acad_rdr(0)
                            j = j + 1
                        End While
                        cnt_arr = j

                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Acad_rdr.Close()
                P_Roll_Acad_Cmd = Nothing
            End Try
            cnt_phed = 0
            cnt = 0
            cnt_list = LstvewPhed.Items.Count
            While cnt < cnt_list
                cnt_phed = 0

                While cnt_phed < cnt_arr
                    If LstvewPhed.Items(cnt).SubItems(1).Text = arr_PhedId(cnt_phed) Then
                        LstvewPhed.Items(cnt).Checked = True
                    End If
                    cnt_phed = cnt_phed + 1
                End While
                cnt = cnt + 1
            End While
        Else
            fetch_recrd = False
        End If
    End Sub


    Private Sub fetch_Name_from_diffTable(ByVal Combox As ComboBox, ByVal Dptid1 As String)
        DptName = ""
        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Select deptname from finactdept where deptid='" & (Dptid1) & "'", FinActConn)
            P_Roll_Mstr_rdr = P_Roll_Mstr_Cmd.ExecuteReader
            If Trim(Dptid1) <> "" Then
                P_Roll_Mstr_rdr.Read()
                If P_Roll_Mstr_rdr.HasRows = True Then
                    DptName = P_Roll_Mstr_rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_rdr.Close()
            P_Roll_Mstr_Cmd = Nothing
        End Try
    End Sub

    Private Sub fetch_Name_from_desi()

        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Select desiname from finactdesi where desiid='" & (DesId) & "'", FinActConn)
            P_Roll_Mstr_rdr = P_Roll_Mstr_Cmd.ExecuteReader
            If Trim(DesiId) <> "" Then
                P_Roll_Mstr_rdr.Read()
                If P_Roll_Mstr_rdr.HasRows = True Then
                    CmbxDesi.Text = P_Roll_Mstr_rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_rdr.Close()
            P_Roll_Mstr_Cmd = Nothing
        End Try
    End Sub
    Private Sub fetch_Bnkid_from_Table(ByVal Combox As ComboBox, ByVal BnkName As Integer)
        Bnknam = ""

        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Select splrname from finactsplrmstr where splrid='" & (BnkName) & "'", FinActConn)
            P_Roll_Mstr_rdr = P_Roll_Mstr_Cmd.ExecuteReader
            If Trim(BnkName) <> "" Then
                P_Roll_Mstr_rdr.Read()
                If P_Roll_Mstr_rdr.HasRows = True Then
                    Bnknam = P_Roll_Mstr_rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Mstr_rdr.Close()
            P_Roll_Mstr_Cmd = Nothing
        End Try

    End Sub

    Private Sub Btnsave_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.Leave
        'If Btnsave.Text = "&New" Then
        '    Btnsave.Text = "&Save"
        'End If
    End Sub


    Private Sub Emp_mstr_delrec()
        Try
            P_Roll_Mstr_Cmd = New SqlCommand("Finact_EmpMstr_delete", FinActConn)
            P_Roll_Mstr_Cmd.CommandType = CommandType.StoredProcedure
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@EEid", EiD)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Edelusrid", Current_UsrId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Edeldt", Now)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@Edelstatus", 0)

            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empdelusrid", Current_UsrId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empdeldt", Now)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empdelstatus", 0)

            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empfmlydelusrid", Current_UsrId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empfmlydeldt", Now)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empfmlydelstatus", 0)

            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@emppfdelusrid", Current_UsrId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@emppfdeldt", Now)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@emppfdelstatus", 0)

            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empAcadmicdelusrid", Current_UsrId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empAcadmicdeldt", Now)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empAcadmicdelstatus", 0)

            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empexprdelusrid", Current_UsrId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empexprdeldt", Now)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empexprdelstatus", 0)

            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empothrdelusrid", Current_UsrId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empothrdeldt", Now)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empothrdelstatus", 0)

            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empapntdelusrid", Current_UsrId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empapntdeldt", Now)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empapntdelstatus", 0)

            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empcnfrmdelusrid", Current_UsrId)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empcnfrmdeldt", Now)
            P_Roll_Mstr_Cmd.Parameters.AddWithValue("@empcnfrmdelstatus", 0)


            P_Roll_Mstr_Cmd.ExecuteNonQuery()
            MsgBox("Current Record has been Deleted", MsgBoxStyle.Information, "Record Deleted")
            Clr_Values_mstr()
            Clr_Values_Info()
            Clr_Values_Fmly()
            Clr_Values_PF()
            Clr_Values_Acad()
            Clr_Values_Exprn()
            Clr_Values_Other()
            Clr_Values_SlryBrkup()
        Catch EX As Exception
            MsgBox(EX.Message)
        Finally
            P_Roll_Mstr_Cmd = Nothing
            Btndel.Enabled = False
            Btnsave.Text = "&New"
            btnedt.Text = "&Edit"
        End Try


    End Sub

    Private Sub Btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndel.Click
        Select Case PayRolTab.SelectedIndex
            Case 0
                Dim cnfrmmsg As String
                cnfrmmsg = MsgBox("Are you sure to delete record?", MsgBoxStyle.YesNo, "Delete")
                If cnfrmmsg = vbYes Then
                    Emp_mstr_delrec()
                    Dim fileExists As Boolean
                    If fileExists = My.Computer.FileSystem.FileExists(ImagePath) = True Then
                        My.Computer.FileSystem.CopyFile(MySource, ImagePath)
                    End If

                    EmpImage.Image = Nothing
                    Enablefals()
                    Panel5.Enabled = False
                    GroupBox1.Enabled = False
                    Btndel.Enabled = False
                    Lnklempimag.Enabled = False

                End If

        End Select

    End Sub

    Private Sub LSTVEW3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LSTVEW3.DoubleClick
        Dim Indx As Integer = 0
        Fmlyname = ""
        Frelatn = ""
        Dblclick = 1
        relname = LSTVEW3.SelectedItems(0).SubItems(0).Text
        Indx = LSTVEW3.SelectedItems(0).Index
        TxtName1.Text = LSTVEW3.Items(Indx).SubItems(0).Text
        Fmlyname = LSTVEW3.Items(Indx).SubItems(0).Text

        DtpkrDob1.Text = LSTVEW3.Items(Indx).SubItems(1).Text
        Fdob = LSTVEW3.Items(Indx).SubItems(1).Text
        cmbxRelatn.Text = LSTVEW3.Items(Indx).SubItems(2).Text
        Frelatn = LSTVEW3.Items(Indx).SubItems(2).Text
        LSTVEW3.Items(Indx).Remove()
    End Sub

    Private Sub Lstvew1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lstvew1.DoubleClick
        Dim Indx1 As Integer
        Dblclick = 1
        Indx1 = Lstvew1.SelectedItems(0).Index
        Degrename = Lstvew1.SelectedItems(0).SubItems(0).Text
        CmbxDegree.Text = Lstvew1.Items(Indx1).SubItems(0).Text
        AcadDegree = Lstvew1.Items(Indx1).SubItems(0).Text
        Txtpassyr.Text = Lstvew1.Items(Indx1).SubItems(1).Text
        AcadPassyr = Lstvew1.Items(Indx1).SubItems(1).Text
        CmbxClass.Text = Lstvew1.Items(Indx1).SubItems(2).Text
        AcadClass = Lstvew1.Items(Indx1).SubItems(2).Text
        Txtsubjts.Text = Lstvew1.Items(Indx1).SubItems(3).Text
        AcadSubjts = Lstvew1.Items(Indx1).SubItems(3).Text
        TxtInsti.Text = Lstvew1.Items(Indx1).SubItems(4).Text
        AcadInsti = Lstvew1.Items(Indx1).SubItems(4).Text
        Lstvew1.Items(Indx1).Remove()
    End Sub

    Private Sub Lstvew2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lstvew2.DoubleClick
        Dim Indx2 As Integer
        Dblclick = 1
        Indx2 = Lstvew2.SelectedItems(0).Index
        Emplrname = Lstvew2.SelectedItems(0).SubItems(0).Text
        TxtEmplr.Text = Lstvew2.Items(Indx2).SubItems(0).Text
        expEmplr = Lstvew2.Items(Indx2).SubItems(0).Text
        DtpkrJndt.Text = Lstvew2.Items(Indx2).SubItems(1).Text
        ExpJndt = Lstvew2.Items(Indx2).SubItems(1).Text
        DtpkrLevDt.Text = Lstvew2.Items(Indx2).SubItems(2).Text
        ExpLevdt = Lstvew2.Items(Indx2).SubItems(2).Text
        TxtJnDesi.Text = Lstvew2.Items(Indx2).SubItems(3).Text
        ExpJndesi = Lstvew2.Items(Indx2).SubItems(3).Text
        TxtLevdesi.Text = Lstvew2.Items(Indx2).SubItems(4).Text
        ExpLevdesi = Lstvew2.Items(Indx2).SubItems(4).Text
        Txtslry.Text = Lstvew2.Items(Indx2).SubItems(5).Text
        ExpSlry = Lstvew2.Items(Indx2).SubItems(5).Text
        Txtachive.Text = Lstvew2.Items(Indx2).SubItems(6).Text
        ExpAchive = Lstvew2.Items(Indx2).SubItems(6).Text
        Lstvew2.Items(Indx2).Remove()
    End Sub


    Private Sub PayRolTab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayRolTab.Click

        Select Case PayRolTab.SelectedIndex
            Case 0
                Btnsave.Focus()
                btnedt.Enabled = True

                If btnedt.Text = "&Edit" Then
                    Btnsave.Text = "&New"
                    Btndel.Enabled = False
                ElseIf btnedt.Text = "&Cancel" Then
                    Btndel.Enabled = True
                End If
            Case 1
                Rcjtxtappnt.Focus()
                btnedt.Enabled = False
                Btndel.Enabled = False

            Case 2
                TxtAddrs.Focus()
                Btndel.Enabled = False
            Case 3
                DtpkrSettldt.Focus()
                Btndel.Enabled = False
            Case 4
                CmbxDegree.Focus()
                Btndel.Enabled = False
            Case 5
                RchtxtCnfrmltr.Focus()
                Btndel.Enabled = False
            Case 6
                TxtRecAgncy.Focus()
                Btndel.Enabled = False

            Case 7
                If SlryBrkmode = "add" Then
                    Fetch_Payheds()
                    Fetch_Payhead_Name()
                    RbYesCmpo.Enabled = False
                    RbNoCmpo.Enabled = False
                  
                End If
                If RbYes_Phed.Checked = False And RbNoPhed.Checked = False Then
                    LstvewPhed.Enabled = False
                End If
               


        End Select


    End Sub


    Private Sub BtFmlyadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFmlyadd.Click
        Dim cnt As Integer
        cnt = LSTVEW3.Items.Count
        If cnt <> 0 And cntr = 0 And cntr_save = 0 Then
            EmpFmlySaverec()
            MsgBox("Record has been Saved successfully", MsgBoxStyle.Information, "Family Details")
            cnt = LSTVEW3.Items.Count
        ElseIf cnt = cntr + cntr_updt + cntr_save + cntr_save1 - cntr_del Or cnt = cntr Then
            MsgBox("First Insert some New Record", MsgBoxStyle.Information, "Save Record")
            TxtName1.Focus()
        ElseIf cnt <> 0 And cntr <> 0 Then
            EmpFmlySaverec1()
            MsgBox("Record has been Updated successfully", MsgBoxStyle.Information, "Family Details")
        ElseIf cntr_save > 0 Then
            Fmlymode = "edit"
            EmpFmlySaverec1()
            MsgBox("Record has been Updated successfully", MsgBoxStyle.Information, "Family Details")
        ElseIf cnt = 0 Then
            MsgBox("No record to Save", MsgBoxStyle.Information, "Save Record")
        End If

    End Sub

    Private Sub BtnFmlydel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFmlydel.Click

        Fmly_del_to_selrecrd()

    End Sub

    Private Sub BtnFmlyedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFmlyedit.Click

        If LSTVEW3.Items.Count = 0 And TxtName1.Text = "" Then
            MsgBox("No record to Edit", MsgBoxStyle.Information, "Edit")
            Exit Sub
        ElseIf TxtName1.Text = "" Then
            MsgBox("First double click any record to Edit", MsgBoxStyle.Information, "Edit")
            Exit Sub
        Else
            Dim relname1 As String
            relname1 = relname
            fetch_empid()
            cntr_updt = 0
            Try
                P_Roll_Fmly_Cmd = New SqlCommand("Select empfmlyid from FinActEmpFmly where empfmlymembr='" & (relname1) & "'and empfmlyconcrnid='" & (empid) & "'", FinActConn)
                P_Roll_Fmly_rdr = P_Roll_Fmly_Cmd.ExecuteReader
                P_Roll_Fmly_rdr.Read()
                If P_Roll_Fmly_rdr.HasRows = True Then
                    Famlyid = (P_Roll_Fmly_rdr(0))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Fmly_Cmd = Nothing
                P_Roll_Fmly_rdr.Close()
            End Try

            Try
                P_Roll_Fmly_Cmd = New SqlCommand("Finact_EmpFmly_Edit", FinActConn)
                P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyid", Famlyid)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyedtusrid", Current_UsrId)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyedtdt", Now)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydelstatus", 1)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydpend", LSTVEW3.Items.Count)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlymembr", TxtName1.Text)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlymembrdob", DtpkrDob1.Value.Date)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyrelatn", cmbxRelatn.Text)
                P_Roll_Fmly_Cmd.ExecuteNonQuery()
                LstFmly = LSTVEW3.Items.Add(TxtName1.Text)
                LstFmly.SubItems.Add(DtpkrDob1.Value.Date)
                LstFmly.SubItems.Add(cmbxRelatn.Text)
                TxtName1.Clear()
                DtpkrDob.Text = ""
                If cmbxRelatn.SelectedIndex >= 1 Then
                    cmbxRelatn.SelectedValue = 0
                    cmbxRelatn.SelectedIndex = -1
                End If
                cmbxRelatn.Text = ""
                MsgBox("Record has been Updated successfully", MsgBoxStyle.Information, "Family Details")
                cntr_updt = cntr_updt + 1
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Fmly_Cmd = Nothing
            End Try

        End If
        Dblclick = 0
    End Sub

    Private Sub BtnAcadad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcadad.Click
        Dim cntAcad As Integer = 0
        cntAcad = Lstvew1.Items.Count
        If Dblclick = 1 Then
            MsgBox("Press Update Button to update the record", MsgBoxStyle.Information, "Update")
            Exit Sub
        ElseIf cntAcad = 0 Then
            MsgBox("No record to Save", MsgBoxStyle.Information, "Save Record")
        ElseIf cntAcad <> 0 And fetch_Acadmic_cntr = 0 And cntr_save_acad = 0 Then
            EmpAcadmicSaverec()
            MsgBox("Record has been Saved successfully", MsgBoxStyle.Information, "Acadmic Details")
        ElseIf cntAcad = fetch_Acadmic_cntr + cntr_updt + cntr_save_acad + cntr_save_acad1 - cntr_del Or cntAcad = fetch_Acadmic_cntr Then
            MsgBox("First Insert some New Record", MsgBoxStyle.Information, "Save Record")
            CmbxDegree.Focus()
        ElseIf cntAcad <> 0 And fetch_Acadmic_cntr <> 0 Then
            EmpAcadmicSaverec1()
            MsgBox("Record has been Updated successfully", MsgBoxStyle.Information, "Acadmic Details")
        ElseIf cntr_save_acad > 0 Then
            Acadmode = "edit"
            EmpAcadmicSaverec1()
            MsgBox("Record has been Updated successfully", MsgBoxStyle.Information, "Acadmic Details")

        End If

    End Sub

    Private Sub fetch_Acadmicid()
        fetch_empid()
        Try
            P_Roll_Degree_Cmd = New SqlCommand("Select empAcadmicid from FinActEmpAcadmic where empAcadmicdigre='" & (Degrename) & "'and empAcadmicconcrnid='" & (empid) & "'and empAcadmicdelstatus=1", FinActConn)
            P_Roll_Degree_rdr = P_Roll_Degree_Cmd.ExecuteReader
            P_Roll_Degree_rdr.Read()
            If P_Roll_Degree_rdr.HasRows = True Then
                Acadmicid = (P_Roll_Degree_rdr(0))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Degree_Cmd = Nothing
            P_Roll_Degree_rdr.Close()
        End Try
    End Sub

    Private Sub BtnAcadDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcadDel.Click
        Acad_del_to_selrecrd()

    End Sub

    Private Sub BtnAcadEd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcadEd.Click
        If TxtInsti.Text = "" Then
            MsgBox("First double click any record to Edit", MsgBoxStyle.Information, "Edit")

        Else

            Dim Degrename1 As String
            Degrename1 = Degrename
            fetch_empid()
            Try
                P_Roll_Degree_Cmd = New SqlCommand("Select empAcadmicid from FinActEmpAcadmic where empAcadmicdigre='" & (Degrename1) & "'and empAcadmicconcrnid='" & (empid) & "'", FinActConn)
                P_Roll_Degree_rdr = P_Roll_Degree_Cmd.ExecuteReader
                P_Roll_Degree_rdr.Read()
                If P_Roll_Degree_rdr.HasRows = True Then
                    Acadmicid = (P_Roll_Degree_rdr(0))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Degree_Cmd = Nothing
                P_Roll_Degree_rdr.Close()
            End Try

            If TxtInsti.Text <> "" Then
                LstAcad = Lstvew1.Items.Add(CmbxDegree.Text)
                LstAcad.SubItems.Add(Txtpassyr.Text)
                LstAcad.SubItems.Add(CmbxClass.Text)
                LstAcad.SubItems.Add(Txtsubjts.Text)
                LstAcad.SubItems.Add(TxtInsti.Text)
            End If
            Try
                P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpAcad_Edit", FinActConn)
                P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicid", Acadmicid)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdigre", CmbxDegree.Text)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicPasYr", Txtpassyr.Text)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicClass", CmbxClass.Text)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicSubjct", Txtsubjts.Text)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicInsti", TxtInsti.Text)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicedtusrid", Current_UsrId)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicedtdt", Now)
                P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdelstatus", 1)
                P_Roll_Acad_Cmd.ExecuteNonQuery()
                If CmbxDegree.SelectedIndex >= 1 Then
                    CmbxDegree.SelectedValue = 0
                    CmbxDegree.SelectedIndex = -1
                End If
                CmbxDegree.Text = ""
                ' Txtpassyr.Clear()
                If CmbxClass.SelectedIndex >= 1 Then
                    CmbxClass.SelectedValue = 0
                    CmbxClass.SelectedIndex = -1
                End If
                CmbxClass.Text = ""
                Txtsubjts.Clear()
                TxtInsti.Clear()
                MsgBox("Record has been Updated successfully", MsgBoxStyle.Information, "Acadmic Details")
                Dblclick = 0

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Acad_Cmd = Nothing
            End Try
        End If
    End Sub


    Private Sub BtExprAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExprAdd.Click
        'Dblclick = 0
        Dim cntExp As Integer = 0
        cntExp = Lstvew2.Items.Count
        If Dblclick = 1 Then
            MsgBox("Press Update Button to update the record", MsgBoxStyle.Information, "Update")
            Exit Sub
        ElseIf cntExp = 0 Then
            MsgBox("No record to Save", MsgBoxStyle.Information, "Save Record")
        ElseIf cntExp <> 0 And fetch_Exp_cntr = 0 And cntr_save_exprn = 0 Then
            EmpExprnSaverec()
            MsgBox("Record has been Saved successfully", MsgBoxStyle.Information, "Experience Details")
        ElseIf cntExp = fetch_Exp_cntr + cntr_updt + cntr_save_exprn + cntr_save_exprn1 - cntr_del Or cntExp = fetch_Exp_cntr Then
            MsgBox("First Insert some New Record", MsgBoxStyle.Information, "Save Record")
            TxtEmplr.Focus()
        ElseIf cntExp <> 0 And fetch_Exp_cntr <> 0 Then
            EmpExprnSaverec1()
            Dblclick = 0
            MsgBox("Record has been Updated successfully", MsgBoxStyle.Information, "Experience Details")

        ElseIf cntr_save_acad > 0 Then
            Exprncmode = "edit"
            EmpExprnSaverec1()
            Dblclick = 0
            MsgBox("Record has been Updated successfully", MsgBoxStyle.Information, "Experience Details")

        End If
    End Sub

    Private Sub fetch_Exprnceid()
        fetch_empid()
        Try
            P_Roll_Emplrnam_Cmd = New SqlCommand("Select empExprid from FinActempExprnce where empexpremplr='" & (Emplrname) & "'and empexprconcrnid='" & (empid) & "'", FinActConn)
            P_Roll_Emplrnam_Rdr = P_Roll_Emplrnam_Cmd.ExecuteReader
            P_Roll_Emplrnam_Rdr.Read()
            If P_Roll_Emplrnam_Rdr.HasRows = True Then
                Exprnceid = (P_Roll_Emplrnam_Rdr(0))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Emplrnam_Cmd = Nothing
            P_Roll_Emplrnam_Rdr.Close()
        End Try
    End Sub


    Private Sub BtExprDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExprDel.Click
        Expr_del_to_selrecrd()
    End Sub

    Private Sub BtExprEd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExprEd.Click
        If Txtachive.Text = "" Then
            MsgBox("First double click any record to Edit", MsgBoxStyle.Information, "Edit")

        Else
            Dim Emplrname1 As String
            Emplrname1 = Emplrname
            fetch_empid()
            Try
                P_Roll_Emplrnam_Cmd = New SqlCommand("Select empExprid from FinActempExprnce where empexpremplr='" & (Emplrname1) & "'and empexprconcrnid='" & (empid) & "'", FinActConn)
                P_Roll_Emplrnam_Rdr = P_Roll_Emplrnam_Cmd.ExecuteReader
                P_Roll_Emplrnam_Rdr.Read()
                If P_Roll_Emplrnam_Rdr.HasRows = True Then
                    Exprnceid = (P_Roll_Emplrnam_Rdr(0))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Emplrnam_Cmd = Nothing
                P_Roll_Emplrnam_Rdr.Close()
            End Try

            If Txtachive.Text <> "" Then
                LstExprn = Lstvew2.Items.Add(TxtEmplr.Text)
                LstExprn.SubItems.Add(DtpkrJndt.Value.Date)
                LstExprn.SubItems.Add(DtpkrLevDt.Value.Date)
                LstExprn.SubItems.Add(TxtJnDesi.Text)
                LstExprn.SubItems.Add(TxtLevdesi.Text)
                LstExprn.SubItems.Add(CDbl(Txtslry.Text))
                LstExprn.SubItems.Add(Txtachive.Text)
            End If
            Try
                P_Roll_Exprn_Cmd = New SqlCommand("Finact_EmpExprn_Edit", FinActConn)
                P_Roll_Exprn_Cmd.CommandType = CommandType.StoredProcedure
                fetch_empid()
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empExprid", Exprnceid)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexpredtusrid", Current_UsrId)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexpredtdt", Now)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprdelstatus", 1)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexpremplr", TxtEmplr.Text)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprjndt", DtpkrJndt.Value.Date)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprlevdt", DtpkrLevDt.Value.Date)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprjnas", TxtJnDesi.Text)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprlevas", TxtLevdesi.Text)
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprsalry", CDbl(Txtslry.Text))
                P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprAchiv", Txtachive.Text)
                P_Roll_Exprn_Cmd.ExecuteNonQuery()
                TxtEmplr.Clear()
                TxtJnDesi.Clear()
                TxtLevdesi.Clear()
                Txtslry.Clear()
                Txtachive.Clear()
                MsgBox("Record has been Updated successfully", MsgBoxStyle.Information, "Experience Details")
                Dblclick = 0

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Exprn_Cmd = Nothing
            End Try
        End If
    End Sub

    Private Sub InvalidEmlid()
        With txtEmlid
            If Trim(.Text) <> "" Then
                If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then

                    .BackColor = Color.White
                    .ForeColor = Color.Black
                Else
                    .BackColor = Color.PapayaWhip
                    .ForeColor = Color.Black
                    .Focus()
                    IndxMstr = IndxMstr + 1
                End If
            End If
        End With
    End Sub

    Private Sub Invalidmailid()
        With Txtmailid
            If Trim(.Text) <> "" Then
                If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then

                    .BackColor = Color.White
                    .ForeColor = Color.Black
                Else
                    .BackColor = Color.PapayaWhip
                    .ForeColor = Color.Black
                    .Focus()
                    IndxMstr = IndxMstr + 1
                End If
            End If
        End With
    End Sub

    Private Sub CmbxMStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxMStatus.SelectedIndexChanged
        If CmbxMStatus.Text = "UnMarried" Or CmbxMStatus.Text = "Never Married" Then
            DtpkrAnivrsry.Enabled = False
        Else
            DtpkrAnivrsry.Enabled = True
        End If
    End Sub

    Private Sub CmbxCty1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCty1.Click
        fetch_rec_statecontry1()

    End Sub

    Private Sub cmbxCurCty_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxCurCty.Click
        fetch_rec_statecontry2()

    End Sub

    Private Sub Cmbxctynomi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxctynomi.Click
        '''' fetch_rec_statecontry3()
    End Sub

    Private Sub BtmFmlyCancl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmFmlyCancl.Click
        Dim Fcont As Integer
        If Fmlymode = "add" Then
            TxtName1.Text = ""
            If cmbxRelatn.SelectedIndex >= 1 Then
                cmbxRelatn.SelectedValue = 0
                cmbxRelatn.SelectedIndex = -1
            End If
        ElseIf Fmlymode = "edit" And Dblclick > 0 Then
            LstFmly = LSTVEW3.Items.Add(Fmlyname)
            LstFmly.SubItems.Add(Fdob)
            LstFmly.SubItems.Add(Frelatn)
            TxtName1.Text = ""
            If cmbxRelatn.SelectedIndex >= 1 Then
                cmbxRelatn.SelectedValue = 0
                cmbxRelatn.SelectedIndex = -1
            End If
        ElseIf Fmlymode = "edit" And Dblclick = 0 Then
            If fmlyrelatn <> "" Then
                TxtName1.Text = ""
                If cmbxRelatn.SelectedIndex >= 1 Then
                    cmbxRelatn.SelectedValue = 0
                    cmbxRelatn.SelectedIndex = -1
                End If
                Fcont = LSTVEW3.Items.Count
                Lstvew1.Items(Fcont - 1).Remove()
            ElseIf fmlyrelatn = "" Then
                TxtName1.Text = ""
                If cmbxRelatn.SelectedIndex >= 1 Then
                    cmbxRelatn.SelectedValue = 0
                    cmbxRelatn.SelectedIndex = -1
                End If
            End If
        End If
        Dblclick = 0

    End Sub

    Private Sub BtnAcadCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcadCncl.Click

        Dim Acont As Integer
        If Acadmode = "add" Then
            If CmbxDegree.SelectedIndex >= 1 Then
                CmbxDegree.SelectedValue = 0
                CmbxDegree.SelectedIndex = -1
            End If
            Txtpassyr.Text = ""
            If CmbxClass.SelectedIndex >= 1 Then
                CmbxClass.SelectedValue = 0
                CmbxClass.SelectedIndex = -1
            End If
            Txtsubjts.Text = ""
            TxtInsti.Text = ""
        ElseIf Acadmode = "edit" And Dblclick > 0 Then
            LstAcad = Lstvew1.Items.Add(AcadDegree)
            LstAcad.SubItems.Add(AcadPassyr)
            LstAcad.SubItems.Add(AcadClass)
            LstAcad.SubItems.Add(AcadSubjts)
            LstAcad.SubItems.Add(AcadInsti)
            If CmbxDegree.SelectedIndex >= 1 Then
                CmbxDegree.SelectedValue = 0
                CmbxDegree.SelectedIndex = -1
            End If
            Txtpassyr.Text = ""
            If CmbxClass.SelectedIndex >= 1 Then
                CmbxClass.SelectedValue = 0
                CmbxClass.SelectedIndex = -1
            End If
            Txtsubjts.Text = ""
            TxtInsti.Text = ""
            Dblclick = 0
        ElseIf Acadmode = "edit" And Dblclick = 0 Then
            If AcadInstitu <> "" Then
                If CmbxDegree.SelectedIndex >= 1 Then
                    CmbxDegree.SelectedValue = 0
                    CmbxDegree.SelectedIndex = -1
                End If
                Txtpassyr.Text = ""
                If CmbxClass.SelectedIndex >= 1 Then
                    CmbxClass.SelectedValue = 0
                    CmbxClass.SelectedIndex = -1
                End If
                Txtsubjts.Text = ""
                TxtInsti.Text = ""
                Acont = Lstvew1.Items.Count
                Lstvew1.Items(Acont - 1).Remove()
            ElseIf AcadInstitu = "" Then
                If CmbxDegree.SelectedIndex >= 1 Then
                    CmbxDegree.SelectedValue = 0
                    CmbxDegree.SelectedIndex = -1
                End If
                Txtpassyr.Text = ""
                If CmbxClass.SelectedIndex >= 1 Then
                    CmbxClass.SelectedValue = 0
                    CmbxClass.SelectedIndex = -1
                End If
                Txtsubjts.Text = ""
                TxtInsti.Text = ""
            End If
        End If

        Dblclick = 0
        If Txtsubjts.BackColor = Color.PapayaWhip Then
            Txtsubjts.BackColor = Color.White
        End If
        If TxtInsti.BackColor = Color.PapayaWhip Then
            TxtInsti.BackColor = Color.White

        End If


    End Sub


    Private Sub BtnExpCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExpCncl.Click

        Dim Econt As Integer
        If Exprncmode = "add" Then
            TxtEmplr.Text = ""
            TxtJnDesi.Text = ""
            TxtLevdesi.Text = ""
            Txtslry.Text = ""
            Txtachive.Text = ""
        ElseIf Exprncmode = "edit" And Dblclick > 0 Then
            LstFmly = Lstvew2.Items.Add(expEmplr)
            LstFmly.SubItems.Add(ExpJndt)
            LstFmly.SubItems.Add(ExpLevdt)
            LstFmly.SubItems.Add(ExpJndesi)
            LstFmly.SubItems.Add(ExpLevdesi)
            LstFmly.SubItems.Add(ExpSlry)
            LstFmly.SubItems.Add(ExpAchive)
            TxtEmplr.Text = ""
            TxtJnDesi.Text = ""
            TxtLevdesi.Text = ""
            Txtslry.Text = ""
            Txtachive.Text = ""
        ElseIf Exprncmode = "edit" And Dblclick = 0 Then
            If ExprAchieve <> "" Then
                TxtEmplr.Text = ""
                TxtJnDesi.Text = ""
                TxtLevdesi.Text = ""
                Txtslry.Text = ""
                Txtachive.Text = ""
                Econt = Lstvew2.Items.Count
                Lstvew2.Items(Econt - 1).Remove()
            ElseIf ExprAchieve = "" Then
                TxtEmplr.Text = ""
                TxtJnDesi.Text = ""
                TxtLevdesi.Text = ""
                Txtslry.Text = ""
                Txtachive.Text = ""
            End If
        End If
        Dblclick = 0
        If TxtEmplr.BackColor <> Color.White Then
            TxtEmplr.BackColor = Color.White
        End If
        If TxtJnDesi.BackColor <> Color.White Then
            TxtJnDesi.BackColor = Color.White
        End If
        If TxtLevdesi.BackColor <> Color.White Then
            TxtLevdesi.BackColor = Color.White
        End If
        If Txtslry.BackColor <> Color.White Then
            Txtslry.BackColor = Color.White
        End If


    End Sub

    Private Sub TxtEmpName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEmpName.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtwrkid.Focus()
        End If
    End Sub

    Private Sub Txtwrkid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtwrkid.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            DtpkrDob.Focus()
        End If
    End Sub

    Private Sub DtpkrDob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDob.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Dtpkrdoj.Focus()
        End If
    End Sub

    Private Sub Dtpkrdoj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpkrdoj.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            doj_flag = True
            txtprobation.Focus()
        End If
    End Sub

    Private Sub txtprobation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtprobation.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            DtpkrDocon.Focus()
        End If
    End Sub


    Private Sub DtpkrDocon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDocon.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxBrnch.Focus()
        End If
    End Sub


    Private Sub DtpkrDoResi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxBrnch.Focus()
        End If
    End Sub


    Private Sub CmbxBrnch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxBrnch.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxCat.Focus()
        End If
    End Sub


    Private Sub CmbxCat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCat.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxDesi.Focus()
        End If
    End Sub

    Private Sub CmbxDesi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxDesi.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxDept.Focus()
        End If
    End Sub

    Private Sub CmbxDept_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxDept.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxSift.Focus()

        End If
    End Sub

    Private Sub CmbxSift_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSift.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxCateg.Focus()
        End If
    End Sub

    Private Sub TxtScale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtScale.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxEmpStat.Focus()
        End If
    End Sub


    Private Sub CmbxEmpStat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEmpStat.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxBonus.Focus()
        End If
    End Sub

    Private Sub CmbxCateg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCateg.GotFocus
        If CmbxCateg.Items.Count > 0 Then
            If CmbxCateg.Text = "" Then
                CmbxCateg.SelectedIndex = 0

            End If
            CmbxCateg.DroppedDown = True
        End If

    End Sub

    Private Sub CmbxCateg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCateg.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtScale.Focus()
        End If
    End Sub

    Private Sub Rbcash_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Rbcash.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Rbchq.Focus()
        End If
    End Sub

    Private Sub Rbchq_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Rbchq.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            RbTfr.Focus()
        End If
    End Sub

    Private Sub RbTfr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbTfr.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtbnkname.Focus()
        End If
    End Sub

    Private Sub Txtbnkname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtbnkname.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtbCode.Focus()
        End If
    End Sub

    Private Sub TxtbCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtbCode.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtAccNo.Focus()
        End If
    End Sub

    Private Sub TxtAccNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAccNo.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtAccType.Focus()
        End If
    End Sub

    Private Sub TxtAccType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAccType.GotFocus
        TxtAccType.DroppedDown = True
        If TxtAccType.Items.Count > 0 And TxtAccType.Text = "" Then
            TxtAccType.SelectedIndex = 0
        End If
    End Sub

    Private Sub TxtAccType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAccType.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Btnsave.Focus()
        End If
    End Sub

    'Personal Info

    Private Sub TxtAddrs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAddrs.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtAddrs1.Focus()
        End If
    End Sub

    Private Sub TxtAddrs1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAddrs1.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtLndmrk.Focus()
        End If
    End Sub

    Private Sub TxtLndmrk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLndmrk.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxCty1.Focus()
        End If
    End Sub
    Private Sub CmbxCty1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCty1.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            txtPin.Focus()
        End If
    End Sub
    Private Sub txtPin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPin.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            txtphno.Focus()
        End If
    End Sub
    Private Sub txtphno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtphno.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If txtphno.Text.Length < 6 Then
                MsgBox("Phone No must contain atleast 6 digits", MsgBoxStyle.Information, "Minimum Length")
                txtphno.Focus()
            ElseIf txtphno.Text.Length > 6 Then
                Txtmobno.Focus()
            End If
        End If
    End Sub
    Private Sub Txtmobno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtmobno.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            txtEmlid.Focus()
        End If
    End Sub

    Private Sub txtEmlid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmlid.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            NoHtFt.Focus()
        End If
    End Sub

    Private Sub NoHtFt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NoHtFt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxSex.Focus()
        End If
    End Sub


    Private Sub CmbxSex_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSex.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxMStatus.Focus()
        End If
    End Sub
    Private Sub CmbxMStatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxMStatus.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxRelign.Focus()
        End If
    End Sub

    Private Sub CmbxRelign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxRelign.KeyDown

        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If DtpkrAnivrsry.Enabled = True Then
                DtpkrAnivrsry.Focus()

            Else
                Txtnatnl.Focus()
            End If
        End If

    End Sub
    Private Sub DtpkrAnivrsry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrAnivrsry.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtnatnl.Focus()
        End If
    End Sub

    Private Sub Txtnatnl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtnatnl.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtIdmark1.Focus()
        End If
    End Sub

    Private Sub TxtIdmark1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIdmark1.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtIdmark2.Focus()
        End If
    End Sub

    Private Sub TxtIdmark2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIdmark2.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtCurAddrs.Focus()

        End If
    End Sub

    Private Sub TxtCurAddrs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCurAddrs.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtCurAdd1.Focus()
        End If
    End Sub

    Private Sub TxtCurAdd1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCurAdd1.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtCurLnd.Focus()
        End If
    End Sub

    Private Sub TxtCurLnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCurLnd.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            cmbxCurCty.Focus()
        End If
    End Sub

    Private Sub cmbxCurCty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxCurCty.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtCurPin.Focus()
        End If
    End Sub
    Private Sub TxtCurPin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCurPin.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtCurPhno.Focus()
        End If
    End Sub
    Private Sub TxtCurPhno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCurPhno.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            txtcurmobno.Focus()
        End If
    End Sub
    Private Sub txtcurmobno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcurmobno.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtPan.Focus()
        End If
    End Sub
    Private Sub TxtPan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPan.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtGir.Focus()
        End If
    End Sub
    Private Sub TxtGir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGir.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtrange.Focus()
        End If
    End Sub

    Private Sub Txtrange_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtrange.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtward.Focus()
        End If
    End Sub

    Private Sub Txtward_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtward.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtFhname.Focus()
        End If
    End Sub

    Private Sub TxtFhname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFhname.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtMoname.Focus()
        End If
    End Sub

    Private Sub TxtMoname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMoname.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtSposName.Focus()
        End If
    End Sub

    Private Sub TxtSposName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSposName.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtEmrgncyNo.Focus()
        End If
    End Sub
    Private Sub TxtEmrgncyNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEmrgncyNo.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Btnsave.Focus()
        End If
    End Sub
    'PF 

    Private Sub DtpkrSettldt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrSettldt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtPFNo.Focus()
        End If
    End Sub

    Private Sub DtpkrPfJdt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrPfJdt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtTfrdamt.Focus()
        End If
    End Sub


    Private Sub ChkPFappli_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkPFappli.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            DtpkrSettldt.Focus()
        End If
    End Sub


    Private Sub ChkEsicAppli_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkEsicAppli.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtAmtpf.Focus()
        End If
    End Sub
    Private Sub TxtAmtpf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAmtpf.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtNewPfNo.Focus()
        End If
    End Sub
    Private Sub TxtTfrdamt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTfrdamt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtVPpercnt.Focus()
        End If
    End Sub

    Private Sub TxtPFNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPFNo.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtAmtpf.Focus()
        End If
    End Sub

    Private Sub TxtPolicno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPolicno.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtInsurdAmt.Focus()
        End If
    End Sub

   

    Private Sub DtpkrRenewdt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrRenewdt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            DtpkrTo.Focus()
        End If
    End Sub

    Private Sub DtpkrTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrTo.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If ChkEsicAppli.Checked = True Then
                TxtEsic.Focus()
            Else
                TxtNomine.Focus()
            End If
        End If
    End Sub

    Private Sub TxtEsic_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEsic.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtDispName.Focus()
        End If
    End Sub

    Private Sub TxtDispName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDispName.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtNomine.Focus()
        End If
    End Sub

    Private Sub TxtNomine_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNomine.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            cmbxrelt.Focus()
        End If
    End Sub

    Private Sub cmbxRelt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxrelt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Dtpkrdob2.Focus()
        End If
    End Sub

    Private Sub Dtpkrdob2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpkrdob2.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtadrsnomi.Focus()
        End If
    End Sub

    Private Sub Txtadrsnomi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtadrsnomi.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            txtadrsnomi1.Focus()
        End If
    End Sub

    Private Sub txtadrsnomi1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtadrsnomi1.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            cmbxstatus.Focus()
        End If
    End Sub

    Private Sub cmbxstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxstatus.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If cmbxstatus.Text = "Minor" Then
                Txtgrdian.Focus()
            ElseIf cmbxstatus.Text = "Major" Then
                TxtNmShare.Focus()
                '  Cmbxctynomi.Focus()
            End If
        End If
    End Sub

    Private Sub Txtgrdian_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtgrdian.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtNmShare.Focus()
            ' Cmbxctynomi.Focus()
        End If
    End Sub

    Private Sub Cmbxctynomi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxctynomi.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            fetch_rec_statecontry3()
            TxtPinNomi.Focus()
        End If
    End Sub

    Private Sub TxtPinNomi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPinNomi.KeyDown

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then

            If FrmNmDetails.DataGridView1.Rows.Count > 0 Then
                Dim totlshr As Double = 0
                Dim count As Integer = 0
                Dim total As Integer = 0
                Dim actual As Double = 0
                total = FrmNmDetails.DataGridView1.Rows.Count
                While count < total
                    totlshr = totlshr + FrmNmDetails.DataGridView1.Rows(count).Cells(3).Value
                    count = count + 1
                End While
                If totlshr + TxtNmShare.Text <= 100 Then
                    fill_grid()
                    ' AddColumns()''
                    'Dim Lstnmdetls As ListViewItem
                    'Lstnmdetls = FrmNmDetails.LstDetls.Items.Add(TxtNomine.Text)
                    'Lstnmdetls.SubItems.Add(cmbxrelt.Text)
                    'Lstnmdetls.SubItems.Add(cmbxstatus.Text)
                    'Lstnmdetls.SubItems.Add(TxtNmShare.Text)
                    'Lstnmdetls.SubItems.Add(DtpkrDob.Value.Date)
                    'Lstnmdetls.SubItems.Add(Txtadrsnomi.Text)
                    'Lstnmdetls.SubItems.Add(Txtgrdian.Text)
                    'Lstnmdetls.SubItems.Add(Cmbxctynomi.Text)
                    'Lstnmdetls.SubItems.Add(LblStatenomi.Text)
                    'Lstnmdetls.SubItems.Add(LblContryNomi.Text)
                    'Lstnmdetls.SubItems.Add(TxtPinNomi.Text)
                    LnkLblVew.Visible = True
                Else
                    actual = 100 - totlshr
                    MsgBox("" & (TxtNomine.Text) & "'s Share can't exceed than " & (actual) & "% as total of all Nominee's Share should be 100%", MsgBoxStyle.Information, "Nominee Share")
                    TxtNmShare.SelectAll()
                    TxtNmShare.Focus()
                    Exit Sub
                End If
            End If


            If FrmNmDetails.DataGridView1.Rows.Count = 0 Then
                If TxtNmShare.Text < 100 Then
                    fill_grid()
                    ' AddColumns()
                    'FrmNmDetails.DataGridView1.Rows(0).Cells(0).Value = TxtNomine.Text
                    'FrmNmDetails.DataGridView1.Rows(0).Cells(1).Value = cmbxrelt.Text
                    'FrmNmDetails.DataGridView1.Rows(0).Cells(2).Value = cmbxstatus.Text
                    'FrmNmDetails.DataGridView1.Rows(0).Cells(3).Value = TxtNmShare.Text
                    'FrmNmDetails.DataGridView1.Rows(0).Cells(4).Value = DtpkrDob.Value.Date
                    'FrmNmDetails.DataGridView1.Rows(0).Cells(5).Value = Txtadrsnomi.Text
                    'FrmNmDetails.DataGridView1.Rows(0).Cells(6).Value = Txtgrdian.Text
                    'FrmNmDetails.DataGridView1.Rows(0).Cells(7).Value = Cmbxctynomi.Text
                    'FrmNmDetails.DataGridView1.Rows(0).Cells(8).Value = LblStatenomi.Text
                    'FrmNmDetails.DataGridView1.Rows(0).Cells(8).Value = LblContryNomi.Text
                    'FrmNmDetails.DataGridView1.Rows(0).Cells(8).Value = TxtPinNomi.Text



                    'Dim Lstnmdetls As ListViewItem
                    'Lstnmdetls = FrmNmDetails.LstDetls.Items.Add(TxtNomine.Text)
                    'Lstnmdetls.SubItems.Add(cmbxrelt.Text)
                    'Lstnmdetls.SubItems.Add(cmbxstatus.Text)
                    'Lstnmdetls.SubItems.Add(TxtNmShare.Text)
                    'Lstnmdetls.SubItems.Add(DtpkrDob.Value.Date)
                    'Lstnmdetls.SubItems.Add(Txtadrsnomi.Text)
                    'Lstnmdetls.SubItems.Add(Txtgrdian.Text)
                    'Lstnmdetls.SubItems.Add(Cmbxctynomi.Text)
                    'Lstnmdetls.SubItems.Add(LblStatenomi.Text)
                    'Lstnmdetls.SubItems.Add(LblContryNomi.Text)
                    'Lstnmdetls.SubItems.Add(TxtPinNomi.Text)
                    LnkLblVew.Visible = True

                    MsgBox("Since Nominee's Share is less than 100% ,so Enter details of other Nominee", MsgBoxStyle.Information, "Nominee Details")
                    ClearNomi()
                    TxtNomine.Focus()
                Else
                    Btnsave.Focus()
                End If

            ElseIf FrmNmDetails.DataGridView1.Rows.Count > 0 Then
                Dim totlshare As Double = 0
                Dim cnt As Integer = 0
                Dim totl As Integer = 0
                totl = FrmNmDetails.DataGridView1.Rows.Count
                While cnt < totl
                    totlshare = totlshare + FrmNmDetails.DataGridView1.Rows(cnt).Cells(3).Value
                    cnt = cnt + 1
                End While
                If totlshare < 100 Then

                    MsgBox("Since Nominee's Share is less than 100% ,so Enter details of other Nominee", MsgBoxStyle.Information, "Nominee Details")
                    ClearNomi()
                    TxtNomine.Focus()
                Else
                    Btnsave.Focus()
                End If
            End If
        End If
        'Btnsave.Focus()

    End Sub
    'Family

    Private Sub Nodepnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Nodepnd.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtName1.Focus()
        End If
    End Sub

    Private Sub TxtName1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName1.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            DtpkrDob1.Focus()
        End If
    End Sub

    Private Sub DtpkrDob1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDob1.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            cmbxRelatn.Focus()
        End If
    End Sub

    Private Sub cmbxRelatn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxRelatn.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            BtFmlyadd.Focus()
        End If
    End Sub

    Private Sub BtFmlyadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtFmlyadd.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            BtmFmlyCancl.Focus()
        End If
    End Sub

    Private Sub BtmFmlyCancl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtmFmlyCancl.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtName1.Focus()
        End If
    End Sub

    'Acadmic

    Private Sub CmbxDegree_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxDegree.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtpassyr.Focus()
        End If
    End Sub


    Private Sub CmbxClass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxClass.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtsubjts.Focus()
        End If
    End Sub

    Private Sub Txtsubjts_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtsubjts.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtInsti.Focus()
        End If
    End Sub

    Private Sub TxtInsti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtInsti.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            BtnAcadad.Focus()
        End If
    End Sub

    'Experience


    Private Sub TxtEmplr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEmplr.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            DtpkrJndt.Focus()
        End If
    End Sub
    Private Sub DtpkrJndt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrJndt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            DtpkrLevDt.Focus()
        End If
    End Sub

    Private Sub DtpkrLevDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrLevDt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtJnDesi.Focus()
        End If
    End Sub

    Private Sub TxtJnDesi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtJnDesi.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtLevdesi.Focus()
        End If
    End Sub

    Private Sub TxtLevdesi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLevdesi.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtslry.Focus()
        End If
    End Sub
    Private Sub Txtslry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtslry.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtachive.Focus()
        End If
    End Sub
    Private Sub Txtachive_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtachive.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            BtExprAdd.Focus()
        End If
    End Sub
    'OTHERS
    Private Sub TxtRecAgncy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRecAgncy.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtTptRute.Focus()
        End If
    End Sub

    Private Sub TxtTptRute_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTptRute.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            cmbxWrkLoc.Focus()
        End If
    End Sub


    Private Sub cmbxWrkLoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxWrkLoc.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxCoVeclType.Focus()
        End If
    End Sub

    Private Sub CmbxCoVeclType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCoVeclType.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If CmbxCoVeclType.Text = "None" Then
                txtCoVeclNo.Text = ""
                txtCoVeclNo.Enabled = False
                TxtMobile.Focus()
            Else
                txtCoVeclNo.Enabled = True
                txtCoVeclNo.Focus()
            End If
        End If
    End Sub

    Private Sub txtCoVeclNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoVeclNo.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtMobile.Focus()
        End If
    End Sub
    Private Sub TxtMobile_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMobile.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtlaptop.Focus()
        End If
    End Sub

    Private Sub Txtlaptop_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtlaptop.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Txtmailid.Focus()
        End If
    End Sub

    Private Sub Txtmailid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtmailid.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            DtpkrSubmit.Focus()
        End If
    End Sub

    Private Sub DtpkrSubmit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrSubmit.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            RbAccept.Focus()
        End If
    End Sub
    Private Sub RbAccept_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbAccept.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            RbReject.Focus()
        End If
    End Sub
    Private Sub RbReject_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbReject.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            DtpkrAccept.Focus()
        End If
    End Sub

    Private Sub DtpkrAccept_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrAccept.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            DtpkrRelev.Focus()
        End If
    End Sub

    Private Sub DtpkrRelev_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrRelev.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtReason.Focus()
        End If
    End Sub

    Private Sub TxtReason_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtReason.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtRemks.Focus()
        End If
    End Sub

    Private Sub TxtRemks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRemks.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Btnsave.Focus()
        End If
    End Sub


    Private Sub DtpkrJndt_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrJndt.ValueChanged
        DtpkrLevDt.MinDate = DtpkrJndt.Value
    End Sub

    Private Sub DtpkrAccept_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrAccept.Leave
        'If DtpkrAccept.Value < DtpkrSubmit.Value Then
        '    MsgBox("Invalid value", MsgBoxStyle.Information, "Validity")
        'End If
    End Sub

    Private Sub CmbxEmpStat_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEmpStat.GotFocus
        If CmbxEmpStat.Items.Count > 0 And CmbxEmpStat.Text = "" Then
            CmbxEmpStat.SelectedIndex = 0

        End If
        CmbxEmpStat.DroppedDown = True
    End Sub

    Private Sub DtpkrAccept_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpkrAccept.ValueChanged
        'If Add_Edit_Flag = True Then
        If DtpkrAccept.Checked = True Then
            DtpkrAccept.MinDate = DtpkrSubmit.Value.Date
            DtpkrRelev.MinDate = DtpkrAccept.Value.Date
            RbAccept.Checked = True
            RbReject.Checked = False
            DtpkrRelev.Enabled = True
        ElseIf DtpkrAccept.Checked = False Then
            RbReject.Checked = True
            RbAccept.Checked = False
            DtpkrRelev.Enabled = False
        End If
        '  End If
    End Sub

    Private Sub DtpkrSubmit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrSubmit.Leave

        If RbAccept.Checked = True Then
            DtpkrAccept.MinDate = DtpkrSubmit.Value.Date

            ' DtpkrRelev.MinDate = DtpkrAccept.Value.Date

        End If

    End Sub

    Private Sub DtpkrSubmit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrSubmit.GotFocus
        DtpkrSubmit.MinDate = Dtpkrdoj.Value.AddDays(+1)
        'DtpkrSubmit.MaxDate = Today
    End Sub

    Private Sub DtpkrSubmit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpkrSubmit.ValueChanged

    End Sub

    Private Sub PayRolTab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayRolTab.SelectedIndexChanged
        If PayRolTab.SelectedIndex = 0 Then
            btnedt.Enabled = True
        End If
    End Sub

    Private Sub CmbxCty1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCty1.LostFocus
        CmbxCty1_Click(sender, e)
    End Sub

    Private Sub Cmbxctynomi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxctynomi.GotFocus
        fetch_rec_statecontry3()
        If Cmbxctynomi.Items.Count > 0 Then
            If Cmbxctynomi.Text = "" Then
                Cmbxctynomi.SelectedIndex = 0
            End If
            Cmbxctynomi.DroppedDown = True
        End If


    End Sub

    Private Sub cmbxCurCty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxCurCty.LostFocus
        fetch_rec_statecontry2()
    End Sub

    Private Sub CmbxCty1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCty1.GotFocus
        If CmbxCty1.Items.Count > 0 Then
            If CmbxCty1.Text = "" Then
                CmbxCty1.SelectedIndex = 0

            End If
            CmbxCty1.DroppedDown = True
        End If


    End Sub

    Private Sub cmbxCurCty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxCurCty.GotFocus
        If cmbxCurCty.Items.Count > 0 Then
            If cmbxCurCty.Text = "" Then
                cmbxCurCty.SelectedIndex = 0

            End If
            cmbxCurCty.DroppedDown = True
        End If


    End Sub

    Private Sub CmbxSex_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSex.GotFocus
        If CmbxSex.Items.Count > 0 Then
            If CmbxSex.Text = "" Then
                CmbxSex.SelectedIndex = 0

            End If
            CmbxSex.DroppedDown = True
        End If

    End Sub

    Private Sub CmbxMStatus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxMStatus.GotFocus
        If CmbxMStatus.Items.Count > 0 Then
            If CmbxMStatus.Text = "" Then
                CmbxMStatus.SelectedIndex = 0
            End If
        End If
        CmbxMStatus.DroppedDown = True

    End Sub

    Private Sub CmbxRelign_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxRelign.GotFocus
        If CmbxRelign.Items.Count > 0 Then
            If CmbxRelign.Text = "" Then
                CmbxRelign.SelectedIndex = 0
            End If
            CmbxRelign.DroppedDown = True
        End If

    End Sub

    Private Sub LnklblSame_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnklblSame.LinkClicked
        If LnklblSame.Text = "Same as Permanent" Then
            TxtCurAddrs.Text = TxtAddrs.Text
            TxtCurAdd1.Text = TxtAddrs1.Text
            TxtCurLnd.Text = TxtLndmrk.Text
            cmbxCurCty.Text = CmbxCty1.Text
            TxtCurPin.Text = txtPin.Text
            TxtCurPhno.Text = txtphno.Text
            txtcurmobno.Text = Txtmobno.Text
            LblCurState.Text = LblState.Text
            LblCurContry.Text = LblContry.Text
            same_adrs_flag = True
            TxtCurAddrs.Enabled = False
            TxtCurAdd1.Enabled = False
            TxtCurLnd.Enabled = False
            cmbxCurCty.Enabled = False
            TxtCurPin.Enabled = False
            TxtCurPhno.Enabled = False
            txtcurmobno.Enabled = False
            LblCurState.Enabled = False
            LblCurContry.Enabled = False
            LnklblSame.Text = "Change the address"
            TxtPan.Focus()
        ElseIf LnklblSame.Text = "Change the address" Then

            TxtCurAddrs.Text = ""
            TxtCurAdd1.Text = ""
            TxtCurLnd.Text = ""
            If cmbxCurCty.SelectedIndex > 0 Then
                cmbxCurCty.SelectedIndex = 0
            End If

            TxtCurPin.Text = ""
            TxtCurPhno.Text = ""
            txtcurmobno.Text = ""
            LblCurState.Text = ""
            LblCurContry.Text = ""
            same_adrs_flag = False
            TxtCurAddrs.Enabled = True
            TxtCurAdd1.Enabled = True
            TxtCurLnd.Enabled = True
            cmbxCurCty.Enabled = True
            TxtCurPin.Enabled = True
            TxtCurPhno.Enabled = True
            txtcurmobno.Enabled = True
            LblCurState.Enabled = True
            LblCurContry.Enabled = True
            LnklblSame.Text = "Same as Permanent"
            TxtCurAddrs.Focus()

        End If

    End Sub

    Private Sub LnklblSame_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnklblSame.MouseHover
        LblClickMe.Visible = True

    End Sub

    Private Sub LnklblSame_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnklblSame.MouseLeave
        LblClickMe.Visible = False
    End Sub

    Private Sub cmbxstatus_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxstatus.Leave
        'If CmbxMStatus.Text = "Minor" Then
        '    Txtgrdian.Enabled = True
        'ElseIf CmbxMStatus.Text = "Major" Then
        '    Txtgrdian.Enabled = False

        'End If
    End Sub

    Private Sub cmbxRelatn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxRelatn.GotFocus
        If cmbxRelatn.Items.Count > 0 Then
            If cmbxRelatn.Text = "" Then
                cmbxRelatn.SelectedIndex = 0
            End If
            cmbxRelatn.DroppedDown = True
        End If


    End Sub

    Private Sub cmbxrelt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxrelt.GotFocus
        If cmbxrelt.Items.Count > 0 Then
            If cmbxrelt.Text = "" Then
                cmbxrelt.SelectedIndex = 0

            End If
            cmbxrelt.DroppedDown = True
        End If

    End Sub

    Private Sub cmbxstatus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxstatus.GotFocus
        If cmbxstatus.Items.Count > 0 Then
            If cmbxstatus.Text = "" Then
                cmbxstatus.SelectedIndex = 0
            End If
            cmbxstatus.DroppedDown = True
        End If

    End Sub

    Private Sub DtpkrSettldt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrSettldt.GotFocus
        'DtpkrSettldt.Value = DtpkrJndt.Value.Date
        'DtpkrSettldt.MaxDate = DtpkrJndt.Value.Date
        'DtpkrSettldt.Value = Dtpkrdoj.Value.Date
        DtpkrSettldt.MaxDate = Dtpkrdoj.Value.Date
    End Sub


    Private Sub cmbxstatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxstatus.SelectedIndexChanged
        If cmbxstatus.SelectedIndex = 0 Then
            Txtgrdian.Enabled = False
        ElseIf cmbxstatus.SelectedIndex = 1 Then
            Txtgrdian.Enabled = True

        End If
    End Sub


    Private Sub RbAccept_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAccept.CheckedChanged
        If RbAccept.Checked = True Then
            DtpkrAccept.Checked = True
            DtpkrRelev.Enabled = True
            DtpkrAccept.MinDate = DtpkrSubmit.Value.Date
            'DtpkrRelev.MinDate = DtpkrAccept.Value.Date
            'ElseIf RbAccept.Checked = False Then
            '    DtpkrAccept.Checked = False
            '    DtpkrRelev.Enabled = False
        End If
    End Sub

    Private Sub RbReject_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbReject.CheckedChanged
        If RbReject.Checked = True Then

            DtpkrAccept.Checked = False
            DtpkrRelev.Enabled = False

            'ElseIf RbReject.Checked = False Then
            '    DtpkrAccept.MinDate = DtpkrSubmit.Value.Date
            '    DtpkrAccept.Checked = True
        End If
    End Sub

    Private Sub txtprobation_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprobation.Leave
        DtpkrDocon.MinDate = Dtpkrdoj.Value.Date.AddMonths(txtprobation.Text)
    End Sub

    Private Sub ChkBxResi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBxResi.CheckedChanged
        If ChkBxResi.Checked = True Then
            GroupBox18.Visible = True

        ElseIf ChkBxResi.Checked = False Then
            GroupBox18.Visible = False
        End If
    End Sub


    Private Sub cmbxRelatn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxRelatn.LostFocus

        If TxtName1.Text = "" Or cmbxRelatn.Text = "" Then
            MsgBox("Blank Field not Allowed", MsgBoxStyle.Information, "Blank Fields")
            TxtName1.Focus()
            Exit Sub
        ElseIf Dblclick = 0 Then

            LstFmly = LSTVEW3.Items.Add(TxtName1.Text)
            LstFmly.SubItems.Add(DtpkrDob1.Value.Date)
            LstFmly.SubItems.Add(cmbxRelatn.Text)
            fmlyrelatn = cmbxRelatn.Text
            Nodepnd.Value = LSTVEW3.Items.Count
            TxtName1.Clear()
            If cmbxRelatn.SelectedIndex >= 1 Then
                cmbxRelatn.SelectedValue = 0
                cmbxRelatn.SelectedIndex = -1
            End If
            cmbxRelatn.Text = ""
            TxtName1.Focus()
        End If

    End Sub

    Private Sub Fmly_del_to_selrecrd()
        Dim fcntr As Integer
        Fmly_cnt = LSTVEW3.Items.Count
        Fmly_sel_cnt = LSTVEW3.SelectedItems.Count

        If Fmlymode = "add" Then
            If Fmly_sel_cnt = 0 Then
                MsgBox("No record Selected in the list to delete", MsgBoxStyle.Information, "Delete")
                Exit Sub
            ElseIf Fmly_cnt <> 0 Or Fmly_sel_cnt <> 0 Then
                Indx = LSTVEW3.SelectedItems(0).Index
                LSTVEW3.Items(Indx).Remove()
                MsgBox("Deleted", MsgBoxStyle.Information, "Delete Record")
            ElseIf Fmly_cnt = 0 Then
                MsgBox("No record in the list to delete", MsgBoxStyle.Information, "Delete")

            End If
        ElseIf Fmlymode = "edit" Then
            If Fmly_sel_cnt <> 0 Then
                fcntr = 0
                While fcntr < Fmly_sel_cnt
                    relname = LSTVEW3.SelectedItems(0).Text
                    fetch_empid()
                    cntr_del = 0
                    Try
                        P_Roll_Fmly_Cmd = New SqlCommand("Select empfmlyid from FinActEmpFmly where empfmlymembr='" & (relname) & "'and empfmlyconcrnid='" & (empid) & "'and empfmlydelstatus=1", FinActConn)
                        P_Roll_Fmly_rdr = P_Roll_Fmly_Cmd.ExecuteReader
                        P_Roll_Fmly_rdr.Read()
                        If P_Roll_Fmly_rdr.HasRows = True Then
                            Famlyid = (P_Roll_Fmly_rdr(0))
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        P_Roll_Fmly_Cmd = Nothing
                        P_Roll_Fmly_rdr.Close()
                    End Try
                    Try
                        P_Roll_Fmly_Cmd = New SqlCommand("Finact_EmpFmly_Delete", FinActConn)
                        P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
                        P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyid", Famlyid)
                        P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydelusrid", Current_UsrId)
                        P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydeldt", Now)
                        P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydelstatus", 0)
                        P_Roll_Fmly_Cmd.ExecuteNonQuery()
                        Indx = LSTVEW3.SelectedItems(0).Index
                        LSTVEW3.Items(Indx).Remove()
                        cntr_del = cntr_del + 1

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        P_Roll_Fmly_Cmd = Nothing
                    End Try
                    fcntr = fcntr + 1
                    Nodepnd.Value = Nodepnd.Value - 1
                End While
                MsgBox("Record has been Deleted successfully", MsgBoxStyle.Information, "Family Details")
            ElseIf Fmly_sel_cnt = 0 Then
                MsgBox("No record Selected in the list to delete", MsgBoxStyle.Information, "Delete")
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Fmly_del_to_selrecrd()

    End Sub

    Private Sub Fmly_delete_all()
        Dim Fmly_cntr1 As Integer
        Fmly_cnt = LSTVEW3.Items.Count
        If Fmlymode = "add" Then
            If Fmly_cnt <> 0 Then
                LSTVEW3.Items.Clear()
            Else
                MsgBox("No record in the list to delete", MsgBoxStyle.Information, "Delete")
            End If
        ElseIf Fmlymode = "edit" Then

            Fmly_cntr1 = 0
            If Fmly_cnt <> 0 Then
                While Fmly_cntr1 < Fmly_cnt
                    relname = LSTVEW3.Items(0).Text
                    fetch_empid()
                    cntr_del = 0
                    Try
                        P_Roll_Fmly_Cmd = New SqlCommand("Select empfmlyid from FinActEmpFmly where empfmlymembr='" & (relname) & "'and empfmlyconcrnid='" & (empid) & "'and empfmlydelstatus=1", FinActConn)
                        P_Roll_Fmly_rdr = P_Roll_Fmly_Cmd.ExecuteReader
                        P_Roll_Fmly_rdr.Read()
                        If P_Roll_Fmly_rdr.HasRows = True Then
                            Famlyid = (P_Roll_Fmly_rdr(0))
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        P_Roll_Fmly_Cmd = Nothing
                        P_Roll_Fmly_rdr.Close()
                    End Try
                    Try
                        P_Roll_Fmly_Cmd = New SqlCommand("Finact_EmpFmly_Delete", FinActConn)
                        P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
                        P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlyid", Famlyid)
                        P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydelusrid", Current_UsrId)
                        P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydeldt", Now)
                        P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empfmlydelstatus", 0)
                        P_Roll_Fmly_Cmd.ExecuteNonQuery()
                        Indx = LSTVEW3.Items(0).Index
                        LSTVEW3.Items(Indx).Remove()
                        cntr_del = cntr_del + 1

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        P_Roll_Fmly_Cmd = Nothing
                    End Try
                    Fmly_cntr1 = Fmly_cntr1 + 1
                    ' Nodepnd.Value = Nodepnd.Value - 1
                End While
                MsgBox("Record has been Deleted successfully", MsgBoxStyle.Information, "Family Details")
            Else
                MsgBox("No record in the list to delete", MsgBoxStyle.Information, "Delete")

            End If
        End If
    End Sub

    Private Sub DeleteAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAllToolStripMenuItem.Click
        Fmly_delete_all()
    End Sub


    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click
        Acad_del_to_selrecrd()
    End Sub

    Private Sub DeleteAllToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAllToolStripMenuItem1.Click
        Acad_delete_all()
    End Sub


    Private Sub DeleteToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem2.Click
        Expr_del_to_selrecrd()
    End Sub


    Private Sub DeleteAllToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAllToolStripMenuItem2.Click
        Expr_del_All()
    End Sub


    Private Sub TxtInsti_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtInsti.LostFocus
        If Txtsubjts.Text = "" Or TxtInsti.Text = "" Then
            'If Txtsubjts.Text = "" And TxtInsti.Text = "" Then
            '    Txtsubjts.BackColor = Color.PapayaWhip
            '    TxtInsti.BackColor = Color.PapayaWhip
            '    Txtsubjts.Focus()
            'ElseIf TxtInsti.Text = "" Then
            '    TxtInsti.BackColor = Color.PapayaWhip
            '    TxtInsti.Focus()
            'ElseIf Txtsubjts.Text = "" Then
            '    Txtsubjts.BackColor = Color.PapayaWhip
            '    Txtsubjts.Focus()
            'End If

            MsgBox("Blank Field not Allowed", MsgBoxStyle.Information, "Blank Fields")
            Txtsubjts.Focus()
            Exit Sub
        ElseIf Dblclick = 0 Then

            LstFmly = Lstvew1.Items.Add(CmbxDegree.Text)
            LstFmly.SubItems.Add(Txtpassyr.Text)
            LstFmly.SubItems.Add(CmbxClass.Text)
            LstFmly.SubItems.Add(Txtsubjts.Text)
            LstFmly.SubItems.Add(TxtInsti.Text)
            AcadInstitu = TxtInsti.Text
            Txtsubjts.Clear()
            TxtInsti.Clear()
            If CmbxDegree.SelectedIndex >= 1 Or CmbxDegree.SelectedIndex = -1 Then
                CmbxDegree.SelectedIndex = 0
            End If
            If cmbxRelatn.SelectedIndex >= 1 Or cmbxRelatn.SelectedIndex = -1 Then
                cmbxRelatn.SelectedIndex = 0
            End If

            CmbxDegree.Focus()
        End If
    End Sub

    Private Sub Acad_delete_all()
        Dim Acad_cntr1 As Integer
        Acad_cnt = Lstvew1.Items.Count

        If Acadmode = "add" Then
            If Acad_cnt <> 0 Then
                Lstvew1.Items.Clear()
            Else
                MsgBox("No record in the list to delete", MsgBoxStyle.Information, "Delete")
            End If
        ElseIf Acadmode = "edit" Then
            Acad_cntr1 = 0
            If Acad_cnt <> 0 Then

                While Acad_cntr1 < Acad_cnt
                    Degrename = Lstvew1.Items(0).Text
                    fetch_empid()
                    fetch_Acadmicid()
                    cntr_del = 0

                    Try
                        P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpAcad_Delete", FinActConn)
                        P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure
                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicid", Acadmicid)
                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdelusrid", Current_UsrId)
                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdeldt", Now)
                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdelstatus", 0)
                        P_Roll_Acad_Cmd.ExecuteNonQuery()
                        Indx = Lstvew1.SelectedItems(0).Index
                        Lstvew1.Items(Indx).Remove()
                        cntr_del = cntr_del + 1

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        P_Roll_Fmly_Cmd = Nothing
                    End Try
                    Acad_cntr1 = Acad_cntr1 + 1

                End While
                MsgBox("Record has been Deleted successfully", MsgBoxStyle.Information, "Acadmic Details")
            Else
                MsgBox("No record in the list to delete", MsgBoxStyle.Information, "Delete")
            End If
        End If
    End Sub

    Private Sub Acad_del_to_selrecrd()
        Dim Acntr As Integer
        Acad_cnt = Lstvew1.Items.Count
        Acad_sel_cnt = Lstvew1.SelectedItems.Count

        If Acadmode = "add" Then
            If Acad_sel_cnt = 0 Then
                MsgBox("No record Selected in the list to delete", MsgBoxStyle.Information, "Delete")
                Exit Sub
            ElseIf Acad_cnt <> 0 Or Acad_sel_cnt <> 0 Then
                Indx = Lstvew1.SelectedItems(0).Index
                Lstvew1.Items(Indx).Remove()
                MsgBox("Deleted", MsgBoxStyle.Information, "Delete Record")
            ElseIf Acad_cnt = 0 Then
                MsgBox("No record in the list to delete", MsgBoxStyle.Information, "Delete")

            End If
        ElseIf Acadmode = "edit" Then
            If Acad_sel_cnt <> 0 Then
                Acntr = 0
                While Acntr < Acad_sel_cnt
                    Degrename = Lstvew1.SelectedItems(0).Text
                    fetch_Acadmicid()
                    cntr_del = 0

                    Try
                        P_Roll_Acad_Cmd = New SqlCommand("Finact_EmpAcad_Delete", FinActConn)
                        P_Roll_Acad_Cmd.CommandType = CommandType.StoredProcedure
                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicid", Acadmicid)
                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdelusrid", Current_UsrId)
                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdeldt", Now)
                        P_Roll_Acad_Cmd.Parameters.AddWithValue("@empAcadmicdelstatus", 0)
                        P_Roll_Acad_Cmd.ExecuteNonQuery()
                        Indx = Lstvew1.SelectedItems(0).Index
                        Lstvew1.Items(Indx).Remove()
                        cntr_del = cntr_del + 1

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        P_Roll_Fmly_Cmd = Nothing
                    End Try
                    Acntr = Acntr + 1

                End While
                MsgBox("Record has been Deleted successfully", MsgBoxStyle.Information, "Acadmic Details")
            ElseIf Acad_sel_cnt = 0 Then
                MsgBox("No record Selected in the list to delete", MsgBoxStyle.Information, "Delete")
            End If
        End If
    End Sub

    Private Sub Txtachive_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtachive.LostFocus
        Chk_val_tabExprnce()
        If IndxMstr <> 0 Then
            IndxMstr = 0
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Fields")
            Exit Sub
        Else
            Joindate = Dtpkrdoj.Value
            If Joindate < DtpkrJndt.Value Then
                MsgBox("Joining Date should be Less than " & Joindate.Date, MsgBoxStyle.Information, "Joining Date")
                Exit Sub
            ElseIf DtpkrLevDt.Value < DtpkrJndt.Value Then
                MsgBox("Leaving Date should be greater than " & DtpkrJndt.Text, MsgBoxStyle.Information, "Leaving Date")
                Exit Sub
            ElseIf Joindate <= DtpkrLevDt.Value Then
                MsgBox("Leaving Date should be less than " & DtpkrLevDt.Text, MsgBoxStyle.Information, "Leaving Date")
                Exit Sub
            End If
            If Dblclick = 0 Then

                LstExprn = Lstvew2.Items.Add(TxtEmplr.Text)
                LstExprn.SubItems.Add(DtpkrJndt.Value.Date)
                LstExprn.SubItems.Add(DtpkrLevDt.Value.Date)
                LstExprn.SubItems.Add(TxtJnDesi.Text)
                LstExprn.SubItems.Add(TxtLevdesi.Text)
                LstExprn.SubItems.Add(Txtslry.Text)
                LstExprn.SubItems.Add(Txtachive.Text)
                ExprAchieve = Txtachive.Text
                TxtEmplr.Clear()
                DtpkrJndt.Text = DtpkrJndt.MinDate
                DtpkrLevDt.Text = DtpkrLevDt.MinDate
                TxtJnDesi.Clear()
                TxtLevdesi.Clear()
                Txtslry.Clear()
                Txtachive.Clear()
                TxtEmplr.Focus()
            End If

        End If


    End Sub


    Private Sub Expr_del_to_selrecrd()
        Dim Ecntr As Integer
        Expr_cnt = Lstvew2.Items.Count
        Expr_sel_cnt = Lstvew2.SelectedItems.Count

        If Exprncmode = "add" Then
            If Expr_sel_cnt = 0 Then
                MsgBox("No record Selected in the list to delete", MsgBoxStyle.Information, "Delete")
                Exit Sub
            ElseIf Expr_cnt <> 0 Or Expr_sel_cnt <> 0 Then
                Indx = Lstvew2.SelectedItems(0).Index
                Lstvew2.Items(Indx).Remove()
                MsgBox("Deleted", MsgBoxStyle.Information, "Delete Record")
            ElseIf Expr_cnt = 0 Then
                MsgBox("No record in the list to delete", MsgBoxStyle.Information, "Delete")

            End If
        ElseIf Exprncmode = "edit" Then
            If Expr_sel_cnt <> 0 Then
                Ecntr = 0
                While Ecntr < Expr_sel_cnt
                    Emplrname = Lstvew2.SelectedItems(0).Text
                    fetch_Exprnceid()
                    cntr_del = 0
                    Try
                        P_Roll_Exprn_Cmd = New SqlCommand("Finact_EmpExpr_Delete", FinActConn)
                        P_Roll_Exprn_Cmd.CommandType = CommandType.StoredProcedure
                        P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empExprid", Exprnceid)
                        P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprdelusrid", Current_UsrId)
                        P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprdeldt", Now)
                        P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprdelstatus", 0)
                        P_Roll_Exprn_Cmd.ExecuteNonQuery()
                        Indx = Lstvew2.SelectedItems(0).Index
                        Lstvew2.Items(Indx).Remove()
                        cntr_del = cntr_del + 1

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        P_Roll_Exprn_Cmd = Nothing
                    End Try
                    Ecntr = Ecntr + 1

                End While
                MsgBox("Record has been Deleted successfully", MsgBoxStyle.Information, "Acadmic Details")
            ElseIf Acad_sel_cnt = 0 Then
                MsgBox("No record Selected in the list to delete", MsgBoxStyle.Information, "Delete")
            End If
        End If


    End Sub

    Private Sub Expr_del_All()
        Dim Expr_cntr1 As Integer
        Expr_cnt = Lstvew2.Items.Count

        If Exprncmode = "add" Then
            If Expr_cnt <> 0 Then
                Lstvew2.Items.Clear()
            Else
                MsgBox("No record in the list to delete", MsgBoxStyle.Information, "Delete")
            End If
        ElseIf Exprncmode = "edit" Then
            Expr_cntr1 = 0
            If Expr_cnt <> 0 Then

                While Expr_cntr1 < Expr_cnt
                    Emplrname = TxtEmplr.Text
                    fetch_empid()
                    fetch_Exprnceid()
                    cntr_del = 0

                    Try
                        P_Roll_Exprn_Cmd = New SqlCommand("Finact_EmpExpr_Delete", FinActConn)
                        P_Roll_Exprn_Cmd.CommandType = CommandType.StoredProcedure
                        P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empExprid", Exprnceid)
                        P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprdelusrid", Current_UsrId)
                        P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprdeldt", Now)
                        P_Roll_Exprn_Cmd.Parameters.AddWithValue("@empexprdelstatus", 0)
                        P_Roll_Exprn_Cmd.ExecuteNonQuery()
                        Indx = Lstvew2.SelectedItems(0).Index
                        Lstvew2.Items(Indx).Remove()
                        cntr_del = cntr_del + 1

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        P_Roll_Exprn_Cmd = Nothing
                    End Try
                    Expr_cntr1 = Expr_cntr1 + 1

                End While
                MsgBox("Record has been Deleted successfully", MsgBoxStyle.Information, "Acadmic Details")
            Else
                MsgBox("No record Selected in the list to delete", MsgBoxStyle.Information, "Delete")
            End If
        End If


    End Sub


    Private Sub BtnApntBrse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApntBrse.Click
        ' Dim str As String = ""
        fso = CreateObject("Scripting.FileSystemObject")
        If OpenFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            MySource = OpenFileDialog2.FileName
            Dim Sqltxt As New IO.FileStream(MySource, FileMode.Open, FileAccess.ReadWrite)
            Dim SqltxtReader As New StreamReader(Sqltxt)
            Rcjtxtappnt.Clear()
            SqltxtReader.BaseStream.Seek(0, SeekOrigin.Begin)
            While SqltxtReader.Peek > -1

                Rcjtxtappnt.Text += Trim(SqltxtReader.ReadLine() & " " & ControlChars.CrLf)
            End While
            SqltxtReader.Close()
        End If

    End Sub

    Private Sub BtnCnfrmBrws_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCnfrmBrws.Click
        fso = CreateObject("Scripting.FileSystemObject")
        If OpenFileDialog3.ShowDialog = Windows.Forms.DialogResult.OK Then
            MySource = OpenFileDialog3.FileName
            Dim Sqltxt1 As New IO.FileStream(MySource, FileMode.Open, FileAccess.ReadWrite)
            Dim SqltxtReader1 As New StreamReader(Sqltxt1)
            RchtxtCnfrmltr.Clear()

            SqltxtReader1.BaseStream.Seek(0, SeekOrigin.Begin)
            While SqltxtReader1.Peek > -1
                RchtxtCnfrmltr.Text += SqltxtReader1.ReadLine() & " " & ControlChars.CrLf
            End While
            SqltxtReader1.Close()
        End If

    End Sub


    Private Sub Txtslry_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtslry.Leave
        If Txtslry.Text <> "" Then
            Txtslry.Text = FormatNumber(Txtslry.Text, 2)
        End If

    End Sub

    Private Sub fetch_ComboShift()
        CmbxSift.Items.Clear()
        Try
            P_Roll_Exprn_Cmd = New SqlCommand("Select EmpSift from FinactEmpTimeMstr where Empdelstatus=0", FinActConn)
            P_Roll_Exprn_rdr = P_Roll_Exprn_Cmd.ExecuteReader
            While P_Roll_Exprn_rdr.Read
                If P_Roll_Exprn_rdr.HasRows = True Then
                    CmbxSift.Items.Add(P_Roll_Exprn_rdr(0))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Exprn_rdr.Close()
            P_Roll_Exprn_Cmd = Nothing
        End Try
    End Sub

    Private Sub CmbxSift_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSift.GotFocus
        fetch_ComboShift()
        If CmbxSift.Items.Count > 0 Then
            If CmbxSift.Text = "" Then
                CmbxSift.SelectedIndex = 0
            End If
            CmbxSift.DroppedDown = True
        End If

    End Sub


    Private Sub TxtScale_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtScale.Leave
        If TxtScale.Text <> "" Then
            TxtScale.Text = FormatNumber(TxtScale.Text, 2)
        End If

    End Sub

    Private Sub TxtAmtpf_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAmtpf.Leave
        If TxtAmtpf.Text <> "" Then
            TxtAmtpf.Text = FormatNumber(TxtAmtpf.Text, 2)
        End If
    End Sub

    Private Sub cmbxWrkLoc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxWrkLoc.GotFocus
        If cmbxWrkLoc.Items.Count > 0 Then
            If cmbxWrkLoc.Text = "" Then
                cmbxWrkLoc.SelectedIndex = 0
            End If
            cmbxWrkLoc.DroppedDown = True
        End If

    End Sub

    Private Sub CmbxCoVeclType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCoVeclType.GotFocus
        If CmbxCoVeclType.Items.Count > 0 Then
            If CmbxCoVeclType.Text = "" Then
                CmbxCoVeclType.SelectedIndex = 0
            End If
            CmbxCoVeclType.DroppedDown = True
        End If

    End Sub

    Private Sub txtphno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtphno.Leave
        'If txtphno.Text.Length < 6 Then
        '    MsgBox("Phone No must contain atleast 6 digits", MsgBoxStyle.Information, "Minimum Length")
        '    txtphno.Focus()
        'End If
    End Sub

    Private Sub Txtmobno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtmobno.Leave
        If Txtmobno.Text.Length < 10 Then
            MsgBox("Mobile No must contain atleast 10 digits", MsgBoxStyle.Information, "Minimum Length")
            Txtmobno.Focus()
        End If
    End Sub


    Private Sub TxtTfrdamt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTfrdamt.Leave
        If TxtTfrdamt.Text <> "" Then
            Dim amt, tramt As Double
            amt = TxtAmtpf.Text
            tramt = TxtTfrdamt.Text
            If tramt > amt Then
                MsgBox("Transfer Amount cannot be greater than the Amount", MsgBoxStyle.Information, "Amount check")
                TxtTfrdamt.Focus()
                TxtTfrdamt.SelectAll()
            End If
        End If
    End Sub


    Private Sub TxtScale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtScale.TextChanged
        If TxtScale.BackColor <> Color.White Then
            TxtScale.BackColor = Color.White
        End If
        If TxtScale.Text <> "" Then
            Lblscale.Text = FormatNumber(TxtScale.Text, 2)
        End If
    End Sub

    Private Sub TxtbCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtbCode.TextChanged
        If TxtbCode.BackColor <> Color.White Then
            TxtbCode.BackColor = Color.White
        End If
    End Sub

    Private Sub TxtAccNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAccNo.TextChanged
        If TxtAccNo.BackColor <> Color.White Then
            TxtAccNo.BackColor = Color.White
        End If
    End Sub


    Private Sub LstVewSelRec_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewSelRec.KeyDown
        If e.KeyCode = Keys.Enter And LstVewSelRec.SelectedItems.Count > 0 Then
            LstVewSelRec_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub LstVewSelRec_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewSelRec.Leave
        Txtwrkid.DropDownStyle = ComboBoxStyle.DropDownList
        CmbxBrnch.DropDownStyle = ComboBoxStyle.DropDownList
        CmbxCat.DropDownStyle = ComboBoxStyle.DropDownList
        CmbxDesi.DropDownStyle = ComboBoxStyle.DropDownList
        CmbxDept.DropDownStyle = ComboBoxStyle.DropDownList
        Txtbnkname.DropDownStyle = ComboBoxStyle.DropDownList
        Lnklempimag.Enabled = True

    End Sub


    Private Sub ChkPFappli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPFappli.CheckedChanged
        If ChkPFappli.Checked = True Then
            DtpkrSettldt.Enabled = True
            TxtPFNo.Enabled = True
            TxtAmtpf.Enabled = True
            TxtNewPfNo.Enabled = True
            DtpkrPfJdt.Enabled = True
            TxtTfrdamt.Enabled = True
            TxtVPpercnt.Enabled = True
            DtpkrSettldt.Focus()
        ElseIf ChkPFappli.Checked = False Then
            DtpkrSettldt.Enabled = False
            TxtPFNo.Enabled = False
            TxtAmtpf.Enabled = False
            TxtNewPfNo.Enabled = False
            DtpkrPfJdt.Enabled = False
            TxtTfrdamt.Enabled = False
            TxtVPpercnt.Enabled = False

        End If
    End Sub

    Private Sub ChkEsicAppli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEsicAppli.CheckedChanged
        If ChkEsicAppli.Checked = True Then
            TxtEsic.Enabled = True
            TxtDispName.Enabled = True
            TxtEsic.Focus()
        ElseIf ChkEsicAppli.Checked = False Then
            TxtEsic.Enabled = False
            TxtDispName.Enabled = False
        End If
    End Sub


    Private Sub RbNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) 
        If e.KeyCode = Keys.Tab Then
            RbYes_Phed.Focus()

        End If
    End Sub


    Private Sub RbYes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) 
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            RbNo.Focus()
        End If
    End Sub

    Private Sub Fetch_Payheds()
        LstvewPhed.Items.Clear()
        Dim LstPayhed As ListViewItem
        Try
            P_Roll_Exprn_Cmd = New SqlCommand("Select PheadName,PheadId,PheadSlipname,PheadCalmtd,PheadType from FinactPayHead where PheadDelstatus=0 and PheadType not LIKE 'Bonus'and PheadType not LIKE 'Employer_s Contribution For ESI' and PheadType not LIKE 'Employer_s contribution For PF'and PheadType not LIKE 'DEEmpESI'and PheadType not LIKE 'DEEmpPF' and PheadType not LIKE 'Incentive' and PheadType not LIKE 'DEEmpVPF' ", FinActConn)

            ''PheadType<>'Bonus'and PheadType<>'Contribution for Employers ESI' and PheadType<>'Contribution for Employers PF'
            P_Roll_Exprn_rdr = P_Roll_Exprn_Cmd.ExecuteReader
            While P_Roll_Exprn_rdr.Read
                If P_Roll_Exprn_rdr.HasRows = True Then
                    LstPayhed = LstvewPhed.Items.Add(P_Roll_Exprn_rdr(0))
                    LstPayhed.SubItems.Add(P_Roll_Exprn_rdr(1))
                    LstPayhed.SubItems.Add(P_Roll_Exprn_rdr(2))
                    LstPayhed.SubItems.Add(P_Roll_Exprn_rdr(3))
                    LstPayhed.SubItems.Add(P_Roll_Exprn_rdr(4))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            P_Roll_Exprn_rdr.Close()
            P_Roll_Exprn_Cmd = Nothing
        End Try

    End Sub


   






    Private Sub Fetch_BscSlry()
        fetch_empid()
        Try
            Fetch_Payhed_Cmd = New SqlCommand("select empgrade from FinactEmpmstr where empid='" & (empid) & "'", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            Fetch_Payhed_Rdr.Read()
            If Fetch_Payhed_Rdr.HasRows = True Then
                BscSlry = Fetch_Payhed_Rdr(0)
              
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try
    End Sub


    Private Sub Fetch_UsrPhed_Amt()
        Try
            Fetch_Payhed_Cmd = New SqlCommand("select PheadRate from FinactPayhead where PheadId='" & (Phed_Id) & "'", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            Fetch_Payhed_Rdr.Read()
            If Fetch_Payhed_Rdr.HasRows = True Then
                UsrPhed_Amt = Fetch_Payhed_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_UsrPhed_Amt1()
        Try
            Fetch_Payhed_Cmd = New SqlCommand("select PheadRate from FinactPayhead where PheadId='" & (Phed_Id1) & "'", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            Fetch_Payhed_Rdr.Read()
            If Fetch_Payhed_Rdr.HasRows = True Then
                UsrPhed_Amt = Fetch_Payhed_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try
    End Sub


    Private Sub Fetch_Payhead_Name()
        Dim count As Integer = 0
        Dim list_add As Boolean
        ' Fetch_Payhead()
        Count_Payhead = LstvewPhed.Items.Count
        lst_cntr = 0
        While count < Count_Payhead
            Try
                Fetch_Payhed_Cmd = New SqlCommand("select PheadName,PheadCalmtd,PheadComp ,PheadType,PhFormulatype,PheadId from FinactPayHead where PheadDelstatus=0 and PheadId='" & (LstvewPhed.Items(count).SubItems(1).Text) & "'", FinActConn)
                Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                Fetch_Payhed_Rdr.Read()
                If Fetch_Payhed_Rdr.HasRows = True Then
                    Payhead_Name = Fetch_Payhed_Rdr(0)
                    Payhead_Type = Fetch_Payhed_Rdr(1)
                    Phed_Calmtd = Fetch_Payhed_Rdr(1)
                    Ern_Deduc = Fetch_Payhed_Rdr(2)
                    Phed_Comp = Fetch_Payhed_Rdr(2)
                    PheadType = Fetch_Payhed_Rdr(3)
                    Phed_Formulatype = Fetch_Payhed_Rdr(4)
                    Phed_Id = Fetch_Payhed_Rdr(5)
                    list_add = True

                    'ElseIf Fetch_Payhed_Rdr.HasRows = False Then
                    '    list_add = False
                    '    Count_Payhead = Count_Payhead + 1

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Fetch_Payhed_Rdr.Close()
                Fetch_Payhed_Cmd = Nothing
            End Try

            If list_add = True Then
                totslab_flag = False
                Fetch_Payhead_Amt()
            End If
            'Min_Payhead = Min_Payhead + 1
            count = count + 1
            lst_cntr = lst_cntr + 1
        End While
        'PnlPayhed.Visible = True
        'PnlPayhed.Location = New System.Drawing.Point(342, 317)
        LblGrossSlry.Text = FormatNumber(BscSlry, 2)
        Btnsave.Focus()
    End Sub



    Private Sub Fetch_Payhead_Amt()
        Fetch_BscSlry()

        Dim res As Double = 0.0
        Dim counter As Integer = 0
        If Phed_Calmtd = "As Computed Value" Or Phed_Calmtd = "on Production/Performance value" Then
            If Phed_Comp = "On Basic" Then
                Fetch_Slab_RateId()
                Fetch_slabrate()
            ElseIf Phed_Comp = "On Specified Formula" Then
                If Phed_Formulatype = "Compound(stepwise)" Or Phed_Formulatype = "Flat Rate" Then
                    Dim Rateval, RateId1 As Integer
                    Dim FromAmt, UptoAmt, SlabAmt, DiffAmt As Double
                    ' Dim LstPayhed As ListViewItem
                    Dim recrd_flag As Boolean
                    TotSlabAmt = 0
                    Dim Arr_Pay_Type(100) As String
                    Dim Arr_PhedId(100), Arr_PFId(100) As Integer
                    Dim m As Integer
                    m = 0
                    Try
                        '  Loan_Salry_Cmd = New SqlCommand("select EmpPayHeadName,EmpPayType from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (Phed_Id) & "'", FinActConn)
                        Fetch_Payhed_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PayheadConId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (Phed_Id) & "' ", FinActConn)
                        Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                        While Fetch_Payhed_Rdr.Read()
                            If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                Arr_PFId(m) = Fetch_Payhed_Rdr(0)
                                Arr_Pay_Type(m) = Fetch_Payhed_Rdr(1)
                                Arr_PhedId(m) = Fetch_Payhed_Rdr(2)

                            End If
                            m = m + 1
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Fetch_Payhed_Rdr.Close()
                        Fetch_Payhed_Cmd = Nothing
                    End Try

                    Dim contr As Integer = 0
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&Recursive begin------------------------------------
                    While contr < m
                        counter = 0
                        j1 = 0
                        l1 = 0
                        TotSlabAmt1 = 0
                        Try
                            Fetch_Payhed_Cmd = New SqlCommand("select PheadName,PheadComp,PheadType,PheadCalmtd,PhFormulatype,PheadId from FinactPayHead where PheadDelstatus=0 and PheadId='" & (Arr_PFId(contr)) & " '", FinActConn) 'and PheadCalmtd<>'As User Defined Value'", FinActConn)
                            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                            Fetch_Payhed_Rdr.Read()
                            If Fetch_Payhed_Rdr.HasRows = True Then
                                Payhead_Name1 = Fetch_Payhed_Rdr(0)
                                Arr_Ern_Deduc1(j1) = Fetch_Payhed_Rdr(1)
                                Phed_Comp1 = Fetch_Payhed_Rdr(1)
                                Arr_Phed_Type21(l1) = Fetch_Payhed_Rdr(2)
                                Phed_Calmtd1 = Fetch_Payhed_Rdr(3)
                                Phed_Formulatype1 = Fetch_Payhed_Rdr(4)
                                Phed_Id1 = Fetch_Payhed_Rdr(5)
                                j1 = j1 + 1
                                l1 = l1 + 1
                            End If '--
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Fetch_Payhed_Rdr.Close()
                            Fetch_Payhed_Cmd = Nothing
                        End Try
                        If Phed_Calmtd1 = "As Computed Value" Or Phed_Calmtd1 = "on Production/Performance value" Then
                            phed_detls = True
                            If Phed_Comp1 = "On Basic" Then
                                Fetch_Slab_RateId()
                                Fetch_SrateId()
                                Fetch_SrateId1()
                                '--------Fetch_slabrate()
                                Rateval = 0
                                RateId1 = 0
                                FromAmt = 0
                                UptoAmt = 0

                                SlabAmt = 0
                                DiffAmt = 0
                                counter = 0
                                recrd_flag = False
                                Dim extsub_flag As Boolean = False
                                TotSlabAmt = 0
                                i = 0
                                While counter < Count_SlabId
                                    If phed_detls = False Then
                                        Try
                                            Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0 and SrateId='" & (arr_srateid(i)) & "'", FinActConn)
                                            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                            Fetch_Payhed_Rdr.Read()
                                            If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                recrd_flag = True
                                                RateId1 = Fetch_Payhed_Rdr(0)
                                                FromAmt = Fetch_Payhed_Rdr(1)
                                                If Fetch_Payhed_Rdr(2) <> "Above" Then
                                                    UptoAmt = Fetch_Payhed_Rdr(2)
                                                Else
                                                    UptoAmt = 9999999999999
                                                End If
                                                Rateval = Fetch_Payhed_Rdr(3)
                                            End If

                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        Finally
                                            If Fetch_Payhed_Rdr.IsDBNull(0) = True Then
                                                recrd_flag = False
                                            End If
                                            Fetch_Payhed_Rdr.Close()
                                            Fetch_Payhed_Cmd = Nothing
                                        End Try
                                    ElseIf phed_detls = True Then
                                        Try
                                            Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 and SrateId ='" & (arr_srateid1(i)) & "'", FinActConn)
                                            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                            Fetch_Payhed_Rdr.Read()
                                            If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                recrd_flag = True
                                                RateId11 = Fetch_Payhed_Rdr(0)
                                                FromAmt = Fetch_Payhed_Rdr(1)
                                                If Fetch_Payhed_Rdr(2) <> "Above" Then
                                                    UptoAmt = Fetch_Payhed_Rdr(2)
                                                Else
                                                    UptoAmt = 9999999999999
                                                End If
                                                Rateval = Fetch_Payhed_Rdr(3)
                                            End If
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        Finally
                                            If Fetch_Payhed_Rdr.IsDBNull(0) = True Then
                                                recrd_flag = False
                                            End If
                                            Fetch_Payhed_Rdr.Close()
                                            Fetch_Payhed_Cmd = Nothing
                                        End Try
                                    End If
                                    'If BscSlry <> "" Then
                                    '    'BscSlry = CDbl(LblBscSlry.Text)
                                    BscSlry = CDbl(BscSlry)
                                    If UptoAmt = 9999999999999 Then
                                        UptoAmt = BscSlry
                                    End If
                                    'End If
                                    If UptoAmt > BscSlry And Phed_Formulatype1 <> "Achieved Target" Then
                                        UptoAmt = BscSlry
                                    End If
                                    If Phed_Formulatype1 = "Compound(stepwise)" Then
                                        If FromAmt = 0 Then
                                            DiffAmt = (UptoAmt - FromAmt)
                                        ElseIf FromAmt > 0 Then
                                            DiffAmt = (UptoAmt - FromAmt) + 1
                                        End If
                                        If FromAmt <= BscSlry Then
                                            SlabAmt = FormatNumber((DiffAmt * Rateval) / 100, 2)
                                            TotSlabAmt = TotSlabAmt + SlabAmt
                                            TotSlabAmt = CDbl(TotSlabAmt)
                                        End If
                                    ElseIf Phed_Formulatype1 = "Flat Rate" Then
                                        If BscSlry <= UptoAmt And BscSlry >= FromAmt Then
                                            TotSlabAmt = 0
                                            SlabAmt = FormatNumber((BscSlry * Rateval) / 100, 2)
                                            TotSlabAmt = SlabAmt
                                            TotSlabAmt = CDbl(TotSlabAmt)
                                        End If
                                    ElseIf Phed_Formulatype1 = "Achieved Target" Then
                                        If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                                            TotSlabAmt = 0
                                            SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                                            TotSlabAmt = CDbl(SlabAmt)
                                        End If
                                    ElseIf Phed_Formulatype1 = "Earned Amount" Then
                                        If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                                            TotSlabAmt = 0
                                            SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                                            TotSlabAmt = CDbl(SlabAmt)
                                        End If
                                    End If
                                    If phed_detls = False Then
                                        RateId = RateId + 1
                                    ElseIf phed_detls = True Then
                                        RateId11 = RateId11 + 1
                                    End If
                                    counter = counter + 1
                                    extsub_flag = True
                                    i = i + 1
                                End While
                                If counter = Count_SlabId Then
                                    ' Dim LstPayhed1 As ListViewItem
                                    TotSlabAmt = FormatNumber(TotSlabAmt, 2)
                                    If recrd_flag = True And extsub_flag <> True Then
                                        LstvewPhed.Items(lst_cntr).SubItems.Add(TotSlabAmt)
                                    ElseIf recrd_flag = False And extsub_flag <> True Then
                                        LstvewPhed.Items(lst_cntr).SubItems.Add(TotSlabAmt)
                                    End If
                                    'If extsub_flag <> True Then
                                    '    LstPayhed1.SubItems.Add(Payhead_Name)
                                    '    LstPayhed1.SubItems.Add(Payhead_Type)
                                    '    LstPayhed1.SubItems.Add(Ern_Deduc)
                                    '    If Payhead_Type = "As User Defined Value" Then
                                    '        LstPayhed1.SubItems.Add("Not Edit")
                                    '    Else
                                    '        LstPayhed1.SubItems.Add("Edit")
                                    '    End If
                                    '    LstPayhed1.SubItems.Add(PheadType)
                                    '    LstPayhed1.SubItems.Add(Phed_Id)
                                    'End If
                                    'End If
                                End If
                                '''''''''''''''''''''''''''''contr = contr + 1
                            ElseIf Phed_Comp1 = "On Specified Formula" Then
                                Dim m1 As Integer
                                Dim loopvar As Integer = 0
                                Dim Target_Amt1 As Double = 0.0
                                Dim Arr_Pay_Type1(100) As String
                                Dim Arr_PhedId1(100), Arr_PFId1(100) As Integer
                                If Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Or Phed_Formulatype1 = "Achieved Target" Or Phed_Formulatype1 = "Earned Amount" Then
                                    If Phed_Formulatype1 <> "Achieved Target" And Phed_Formulatype1 <> "Earned Amount" Then
                                        TotSlabAmt1 = 0

                                        m1 = 0
                                        Try
                                            Fetch_Payhed_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PheadId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (Phed_Id1) & "'", FinActConn)
                                            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                            While Fetch_Payhed_Rdr.Read()
                                                If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                    Arr_PFId1(m1) = Fetch_Payhed_Rdr(0)
                                                    Arr_Pay_Type1(m1) = Fetch_Payhed_Rdr(1)
                                                    Arr_PhedId1(m1) = Fetch_Payhed_Rdr(2)

                                                End If
                                                m1 = m1 + 1
                                            End While
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        Finally
                                            Fetch_Payhed_Rdr.Close()
                                            Fetch_Payhed_Cmd = Nothing
                                        End Try
                                        TotSlabAmt1 = 0
                                    End If
                                    If Phed_Formulatype1 = "Achieved Target" Or Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Or Phed_Formulatype1 = "Earned Amount" Then
                                        If Phed_Formulatype1 = "Achieved Target" Then
                                            ' Arr_PhedId(loopvar) = Phed_Id1
                                            Arr_PFId(loopvar) = Phed_Id1
                                            m1 = 1
                                            Try
                                                Fetch_Payhed_Cmd = New SqlCommand("select Amt from Finact_Target where EId='" & (empid) & "'", FinActConn)
                                                Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                                Fetch_Payhed_Rdr.Read()
                                                If Fetch_Payhed_Rdr.HasRows = True Then
                                                    Target_Amt1 = CDbl(Fetch_Payhed_Rdr(0))
                                                End If
                                            Catch ex As Exception
                                                MsgBox(ex.Message)
                                            Finally
                                                If Fetch_Payhed_Rdr.HasRows = False Then
                                                    Target_Amt1 = CDbl(0)
                                                End If
                                                Fetch_Payhed_Rdr.Close()
                                                Fetch_Payhed_Cmd = Nothing
                                            End Try
                                        End If
                                        If Phed_Formulatype1 = "Earned Amount" Then
                                            'Arr_PhedId(loopvar) = Phed_Id1
                                            Arr_PFId(loopvar) = Phed_Id1
                                            m1 = 1
                                            Target_Amt1 = CDbl(BscSlry)
                                        End If


                                        While loopvar < m1
                                            If Phed_Formulatype1 = "Earned Amount" Or Phed_Formulatype1 = "Achieved Target" Then

                                                Try
                                                    Fetch_Payhed_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                                    Fetch_Payhed_Rdr.Read()
                                                    If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                        Count_SlabId1 = Fetch_Payhed_Rdr(0)
                                                    End If
                                                Catch ex As Exception
                                                    MsgBox(ex.Message)
                                                Finally
                                                    Fetch_Payhed_Rdr.Close()
                                                    Fetch_Payhed_Cmd = Nothing
                                                End Try
                                                If Count_SlabId1 > 0 Then
                                                    Try
                                                        Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                                        Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                                        Fetch_Payhed_Rdr.Read()
                                                        If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                            RateId11 = Fetch_Payhed_Rdr(0)
                                                        End If
                                                    Catch ex As Exception
                                                        MsgBox(ex.Message)
                                                    Finally
                                                        Fetch_Payhed_Rdr.Close()
                                                        Fetch_Payhed_Cmd = Nothing
                                                    End Try
                                                End If

                                                While counter < Count_SlabId1

                                                    Try
                                                        Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Arr_PFId(loopvar)) & "'and PheadDelstatus=0 and SrateId='" & (RateId11) & "'", FinActConn)
                                                        Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                                        Fetch_Payhed_Rdr.Read()
                                                        If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                            RateId11 = Fetch_Payhed_Rdr(0)
                                                            FromAmt1 = Fetch_Payhed_Rdr(1)
                                                            If Fetch_Payhed_Rdr(2) <> "Above" Then
                                                                UptoAmt1 = Fetch_Payhed_Rdr(2)
                                                            Else
                                                                UptoAmt1 = 9999999999999
                                                            End If

                                                            Rateval1 = Fetch_Payhed_Rdr(3)
                                                        End If

                                                    Catch ex As Exception
                                                        MsgBox(ex.Message)
                                                    Finally
                                                        If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                            recrd_flag = True
                                                        ElseIf Fetch_Payhed_Rdr.IsDBNull(0) = True Then
                                                            recrd_flag = False
                                                        End If
                                                        Fetch_Payhed_Rdr.Close()
                                                        Fetch_Payhed_Cmd = Nothing
                                                    End Try
                                                    'If LblBscSlry.Text <> "" Then
                                                    '  BscSlry1 = CDbl(LblBscSlry.Text)
                                                    BscSlry = CDbl(BscSlry)
                                                    If UptoAmt1 = 9999999999999 Then
                                                        UptoAmt1 = BscSlry
                                                    End If

                                                    'End If
                                                    If UptoAmt1 > BscSlry And Phed_Formulatype1 <> "Achieved Target" Then
                                                        UptoAmt1 = BscSlry
                                                    End If
                                                    If Phed_Formulatype1 = "Compound(stepwise)" Then
                                                        If FromAmt1 = 0 Then
                                                            DiffAmt1 = (UptoAmt1 - FromAmt1)
                                                        ElseIf FromAmt > 0 Then
                                                            DiffAmt1 = (UptoAmt1 - FromAmt1) + 1
                                                        End If
                                                        If FromAmt <= BscSlry Then
                                                            SlabAmt1 = FormatNumber((DiffAmt1 * Rateval1) / 100, 2)
                                                            TotSlabAmt1 = TotSlabAmt1 + SlabAmt1
                                                            TotSlabAmt1 = CDbl(TotSlabAmt1)
                                                        End If
                                                    ElseIf Phed_Formulatype1 = "Flat Rate" Then
                                                        If BscSlry <= UptoAmt1 And BscSlry >= FromAmt1 Then
                                                            TotSlabAmt1 = 0
                                                            SlabAmt1 = FormatNumber((BscSlry * Rateval1) / 100, 2)
                                                            TotSlabAmt1 = SlabAmt1
                                                            TotSlabAmt1 = CDbl(TotSlabAmt1)
                                                        End If
                                                    ElseIf Phed_Formulatype1 = "Achieved Target" Then
                                                        If Target_Amt1 <= UptoAmt1 And Target_Amt1 >= FromAmt1 Then
                                                            TotSlabAmt1 = 0
                                                            SlabAmt1 = FormatNumber(Target_Amt1 * Rateval1 / 100, 2)
                                                            TotSlabAmt1 = CDbl(SlabAmt1)
                                                        End If
                                                    ElseIf Phed_Formulatype1 = "Earned Amount" Then
                                                        If Target_Amt1 <= UptoAmt1 And Target_Amt1 >= FromAmt1 Then
                                                            TotSlabAmt1 = 0
                                                            SlabAmt1 = FormatNumber(Target_Amt1 * Rateval1 / 100, 2)
                                                            TotSlabAmt1 = CDbl(SlabAmt1)
                                                        End If
                                                    End If
                                                    TotSlabAmt = TotSlabAmt1
                                                    RateId11 = RateId11 + 1
                                                    RateId = RateId + 1
                                                    counter = counter + 1
                                                End While
                                            ElseIf Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Then
                                                'Arr_PhedId(loopvar) = Phed_Id1
                                                Arr_PFId(loopvar) = Phed_Id1
                                                Sec_Phed_id = Phed_Id1
                                                str_PheadFormula = Phed_Formulatype1
                                                ' recfun_payhead(Payhead_Name1, Phed_Id1)
                                                recursve_flag = False
                                                Phed_Formulatype1 = str_PheadFormula
                                                m1 = 1
                                            End If

                                            loopvar += 1
                                            If loopvar = m1 Then
                                                loopvar_flag = True
                                                totslab_flag = True
                                                phed_detls = True
                                                'If Phed_Formulatype1 <> "Achieved Target" And Phed_Formulatype1 <> "Earned Amount" Then
                                                '    BscAmt = CDbl(TotSlabAmt)
                                                '    finalamt = BscSlry - BscAmt
                                                '    BscAmt = CDbl(finalamt)
                                                '    Fetch_Slab_RateId()
                                                '    Fetch_slabrate()
                                                'End If
                                            End If
                                        End While 'lop[






                                    End If 'COME()
                                End If
                                '''''''''''''''''''''contr = contr + 1
                            End If
                        ElseIf Phed_Calmtd1 = "As User Defined Value" Then 'USER---------------


                            Fetch_UsrPhed_Amt1()
                            TotSlabAmt = UsrPhed_Amt

                            '    End If
                            '        j += 1
                            'End While
                            ' End If
                        End If


                        'If LblBscSlry.Text <> "" Then
                        ' BscSlry = CDbl(LblBscSlry.Text)
                        BscSlry = CDbl(BscSlry)
                        ' End If
                        If contr = m Then
                            totslab_flag = True
                            phed_detls = False
                            BscAmt = CDbl(TotSlabAmt)
                            finalamt = BscSlry - BscAmt
                            BscAmt = CDbl(finalamt)
                            Fetch_Slab_RateId()
                            Fetch_slabrate()
                        End If
                        If Trim(Arr_Pay_Type(contr)) = Trim("Add") Then
                            If contr = 0 Then
                                res = BscSlry + TotSlabAmt
                            ElseIf contr <> 0 Then
                                res += TotSlabAmt
                            End If
                        ElseIf Trim(Arr_Pay_Type(contr)) = Trim("Minus") Then
                            If contr = 0 Then
                                res = BscSlry - TotSlabAmt
                            ElseIf contr <> 0 Then
                                res -= TotSlabAmt
                            End If
                            '
                        End If
                        contr = contr + 1
                    End While 'main while
                    phed_detls = False
                    BscSlry = res
                    BscSry_cng = res
                    totslab_flag = True
                    Fetch_Slab_RateId()
                    Fetch_slabrate()

                ElseIf Phed_Formulatype = "Achieved Target" Then

                    Try
                        Fetch_Payhed_Cmd = New SqlCommand("select Amt from Finact_Target where EId='" & (empid) & "'", FinActConn)
                        Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                        Fetch_Payhed_Rdr.Read()
                        If Fetch_Payhed_Rdr.HasRows = True Then
                            Target_Amt = CDbl(Fetch_Payhed_Rdr(0))
                            ctr = ctr + 1
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        If Fetch_Payhed_Rdr.HasRows = False Then
                            Target_Amt = CDbl(0)
                        End If
                        Fetch_Payhed_Rdr.Close()
                        Fetch_Payhed_Cmd = Nothing
                    End Try
                    Fetch_Slab_RateId()
                    Fetch_slabrate()
                    p = p + 1

                ElseIf Phed_Formulatype = "Earned Amount" Then

                    Target_Amt = CDbl(BscSlry)
                    Fetch_Slab_RateId()
                    Fetch_slabrate()
                    p = p + 1
                    ' End If
                End If
            End If

        ElseIf Phed_Calmtd = "As User Defined Value" Then
            Fetch_UsrPhed_Amt()
            TotSlabAmt = FormatNumber(UsrPhed_Amt, 2)
            LstvewPhed.Items(lst_cntr).SubItems.Add(TotSlabAmt)
            'Dim j As Integer = 0
            'Dim lstpay As ListViewItem
            'If Datagrdusrdef.Rows.Count > 0 Then
            '    While j < Datagrdusrdef.Rows.Count
            '        If Datagrdusrdef.Rows(j).Cells(0).Value = Payhead_Name Then
            '            TotSlabAmt = Datagrdusrdef.Rows(j).Cells(1).Value
            '            Exit While
            '        End If
            '        j += 1
            '    End While
            '    lstpay = LstvewPhed.Items.Add(TotSlabAmt)
            '    lstpay.SubItems.Add(Payhead_Name)
            '    lstpay.SubItems.Add(Payhead_Type)
            '    lstpay.SubItems.Add(Ern_Deduc)
            '    lstpay.SubItems.Add("Not Edit")
            '    lstpay.SubItems.Add(PheadType)
            '    lstpay.SubItems.Add(Phed_Id)
            'End If
        End If
    End Sub



    Private Sub Count_Slab_RateId()
        If phed_detls = True Then
            Try
                Fetch_Payhed_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and  PheadDelstatus=0 and PheadId='" & (Phed_Id1) & "'", FinActConn)
                Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                Fetch_Payhed_Rdr.Read()
                If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                    Count_SlabId = Fetch_Payhed_Rdr(0)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Fetch_Payhed_Rdr.Close()
                Fetch_Payhed_Cmd = Nothing
            End Try
        ElseIf phed_detls = False Then
            Try
                Fetch_Payhed_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and  PheadDelstatus=0 and PheadId='" & (Phed_Id) & "'", FinActConn)
                Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                Fetch_Payhed_Rdr.Read()
                If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                    Count_SlabId = Fetch_Payhed_Rdr(0)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Fetch_Payhed_Rdr.Close()
                Fetch_Payhed_Cmd = Nothing
            End Try
        End If


    End Sub




    Private Sub Fetch_Slab_RateId()

        Count_Slab_RateId()
        If phed_detls = True Then
            If Count_SlabId > 0 Then
                Try
                    Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0", FinActConn)
                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                    Fetch_Payhed_Rdr.Read()
                    If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                        RateId11 = Fetch_Payhed_Rdr(0)

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Fetch_Payhed_Rdr.Close()
                    Fetch_Payhed_Cmd = Nothing
                End Try
            End If
        ElseIf phed_detls = False Then
            If Count_SlabId > 0 Then
                Try
                    Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0", FinActConn)
                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                    Fetch_Payhed_Rdr.Read()
                    If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                        RateId = Fetch_Payhed_Rdr(0)

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Fetch_Payhed_Rdr.Close()
                    Fetch_Payhed_Cmd = Nothing
                End Try
            End If
        End If

    End Sub

    Private Sub Fetch_SrateId()
        i = 0
        Try
            Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0 ", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            While Fetch_Payhed_Rdr.Read()
                If Fetch_Payhed_Rdr.HasRows = True Then
                    arr_srateid(i) = Fetch_Payhed_Rdr(0)
                    i = i + 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'If Loan_Salry_Rdr.IsDBNull(0) = False Then
            'recrd_flag = True
            'Else'

            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try

    End Sub


    Private Sub Fetch_SrateId1()
        i = 0
        Try
            Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 ", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            While Fetch_Payhed_Rdr.Read()
                If Fetch_Payhed_Rdr.HasRows = True Then
                    arr_srateid1(i) = Fetch_Payhed_Rdr(0)
                    i = i + 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'If Loan_Salry_Rdr.IsDBNull(0) = False Then
            'recrd_flag = True
            'Else'

            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try

    End Sub


    Private Sub Fetch_slabrate()
        'Fetch_BscSlry()
        Dim Rateval As Double
        Dim RateId1 As Integer
        Dim FromAmt, UptoAmt, SlabAmt, DiffAmt As Double
        Dim counter As Integer = 0
        'Dim LstPayhed As ListViewItem
        Dim recrd_flag As Boolean
        Dim extsub_flag As Boolean = False
        Dim Rem_flag As Boolean = False
        TotSlabAmt = 0
        Fetch_SrateId()
        Fetch_SrateId1()
        i = 0
        While counter < Count_SlabId
            If phed_detls = False Then
                Try
                    Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0 and SrateId='" & (arr_srateid(i)) & "'", FinActConn)
                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                    Fetch_Payhed_Rdr.Read()
                    If Fetch_Payhed_Rdr.HasRows = True Then
                        recrd_flag = True
                        RateId1 = Fetch_Payhed_Rdr(0)
                        FromAmt = Fetch_Payhed_Rdr(1)
                        If Fetch_Payhed_Rdr(2) <> "Above" Then
                            UptoAmt = Fetch_Payhed_Rdr(2)
                        Else
                            UptoAmt = 9999999999999
                        End If
                        Rateval = Fetch_Payhed_Rdr(3)
                    End If
                    If counter = 0 Then
                        ' If all_flag = False Then
                        If BscSlry > UptoAmt And PheadType = "DEEmpPF" Then
                            Rem_amt = CDbl(BscSlry) - UptoAmt
                            Rem_flag = True
                        End If
                        'ElseIf all_flag = True Then
                        '    If arr_ernamt(cntr) > UptoAmt And Phed_type2 = "DEEmpPF" Then

                        '        Rem_Amt = CDbl(arr_ernamt(cntr)) - UptoAmt
                        '        Rem_flag = True
                        '    End If
                        'End If

                    End If


                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    'If Loan_Salry_Rdr.IsDBNull(0) = False Then
                    'recrd_flag = True
                    'Else'
                    If Fetch_Payhed_Rdr.HasRows = False Then

                        recrd_flag = False
                    End If
                    Fetch_Payhed_Rdr.Close()
                    Fetch_Payhed_Cmd = Nothing
                End Try
            ElseIf phed_detls = True Then
                Try
                    Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 and SrateId='" & (arr_srateid1(i)) & "'", FinActConn)
                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                    Fetch_Payhed_Rdr.Read()
                    If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                        recrd_flag = True
                        RateId11 = Fetch_Payhed_Rdr(0)
                        FromAmt = Fetch_Payhed_Rdr(1)
                        If Fetch_Payhed_Rdr(2) <> "Above" Then
                            UptoAmt = Fetch_Payhed_Rdr(2)
                        Else
                            UptoAmt = 9999999999999
                        End If
                        Rateval = Fetch_Payhed_Rdr(3)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    'If Loan_Salry_Rdr.IsDBNull(0) = False Then
                    'recrd_flag = True
                    'Else'
                    If Fetch_Payhed_Rdr.IsDBNull(0) = True Then
                        recrd_flag = False
                    End If
                    Fetch_Payhed_Rdr.Close()
                    Fetch_Payhed_Cmd = Nothing
                End Try
            End If
            'If LblBscSlry.Text <> "" Then
            If (phed_detls = False Or recursve_flag = True) And totslab_flag = True Then
                BscSlry = BscSry_cng
            Else
                ' BscSlry = CDbl(LblBscSlry.Text)
                BscSlry = CDbl(BscSlry)
                If UptoAmt = 9999999999999 Then
                    UptoAmt = BscSlry
                End If
                '________________
                'BscSlry = BscAmt
                'extsub_flag = True
            End If
            'ElseIf all_flag = True Then
            '    If (phed_detls = False Or recursve_flag = True) And totslab_flag = True Then
            '        extsub_flag = False
            '        BscSlry = BscSry_cng 'BscAmt
            '    Else
            '        BscSlry = arr_ernamt(cntr)
            '    End If
            '    If UptoAmt = 9999999999999 Then
            '        UptoAmt = BscSlry
            '    End If
            'End If
            If UptoAmt > BscSlry And Phed_Formulatype <> "Achieved Target" Then
                UptoAmt = BscSlry
            End If
            If phed_detls = False Then
                If Phed_Formulatype = "Compound(stepwise)" Then
                    If FromAmt = 0 Then
                        DiffAmt = (UptoAmt - FromAmt)
                    ElseIf FromAmt > 0 Then
                        DiffAmt = (UptoAmt - FromAmt) + 1
                    End If
                    If FromAmt <= BscSlry Then
                        SlabAmt = FormatNumber((DiffAmt * Rateval) / 100, 2)
                        TotSlabAmt = TotSlabAmt + SlabAmt
                        TotSlabAmt = CDbl(TotSlabAmt)
                    End If
                ElseIf Phed_Formulatype = "Flat Rate" Then
                    If BscSlry <= UptoAmt And BscSlry >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = FormatNumber((BscSlry * Rateval) / 100, 2)
                        TotSlabAmt = SlabAmt
                        TotSlabAmt = CDbl(TotSlabAmt)
                    End If
                ElseIf Phed_Formulatype = "Achieved Target" Then
                    If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                        TotSlabAmt = CDbl(SlabAmt)
                    End If
                ElseIf Phed_Formulatype = "Earned Amount" Then
                    If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                        TotSlabAmt = CDbl(SlabAmt)
                    End If
                End If
            ElseIf phed_detls = True Then
                If Phed_Formulatype1 = "Compound(stepwise)" Then
                    If FromAmt = 0 Then
                        DiffAmt = (UptoAmt - FromAmt)
                    ElseIf FromAmt > 0 Then
                        DiffAmt = (UptoAmt - FromAmt) + 1
                    End If
                    If FromAmt <= BscSlry Then
                        SlabAmt = FormatNumber((DiffAmt * Rateval) / 100, 2)
                        TotSlabAmt = TotSlabAmt + SlabAmt
                        TotSlabAmt = CDbl(TotSlabAmt)
                    End If
                ElseIf Phed_Formulatype1 = "Flat Rate" Then
                    If BscSlry <= UptoAmt And BscSlry >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = CDbl(FormatNumber((BscSlry * Rateval) / 100, 2))
                        TotSlabAmt = SlabAmt
                        TotSlabAmt = CDbl(TotSlabAmt)
                    End If
                ElseIf Phed_Formulatype1 = "Achieved Target" Then
                    If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                        TotSlabAmt = CDbl(SlabAmt)
                    End If
                ElseIf Phed_Formulatype1 = "Earned Amount" Then
                    If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                        TotSlabAmt = CDbl(SlabAmt)
                    End If
                End If
            End If
            If phed_detls = False Then
                RateId = RateId + 1
            ElseIf phed_detls = True Then
                RateId11 = RateId11 + 1
            End If

            i = i + 1
            counter = counter + 1

        End While
        If extsub_flag = True Then
            extsub_flag = False
            Exit Sub
        End If
        If counter = Count_SlabId Then
            'And BscSlry > UptoAmt Then

            'If Phed_Formulatype = "Compound(stepwise)" Then
            '    DiffAmt = (BscSlry - UptoAmt)
            '    SlabAmt = FormatNumber((DiffAmt * Rateval) / 100, 2)
            '    TotSlabAmt = TotSlabAmt + SlabAmt
            'ElseIf Phed_Formulatype = "Flat Rate" Then
            '    TotSlabAmt = 0
            '    SlabAmt = FormatNumber((BscSlry * Rateval) / 100, 2)
            '    TotSlabAmt = TotSlabAmt + SlabAmt
            '    TotSlabAmt = CDbl(TotSlabAmt)
            'End If

            'If loopvar_flag = True Then
            '    loopvar_flag = False
            '    Exit Sub
            'End If

            If recursve_flag = False And phed_detls = False Then
                If recrd_flag = True Then
                    If PheadType = "DEEmpPF" And Rem_flag = True Then
                        Fetch_VPF()
                        VPF_Amt = CDbl((Rem_amt * VPF_Pcent) / 100)
                        TotSlabAmt = FormatNumber((TotSlabAmt + VPF_Amt), 2)
                        Rem_flag = False
                    End If
                    If PheadType = "DEEmpESI" And BscSlry > 10000 Then
                        TotSlabAmt = FormatNumber(CDbl(0), 2)
                    End If

                    LstvewPhed.Items(lst_cntr).SubItems.Add(TotSlabAmt)
                    'lst_cntr).SubItems(4)

                ElseIf recrd_flag = False Then
                    LstvewPhed.Items(lst_cntr).SubItems.Add(0)
                    'LstPayhed.SubItems.Add(0)

                End If

               
                'ElseIf all_flag = True And recursve_flag = False And phed_detls = False Then

                '    If recrd_flag = True Then
                '        If Phed_type2 = "DEEmpPF" And Rem_flag = True Then
                '            Fetch_VPF_All()
                '            VPF_Amt = CDbl((Rem_Amt * VPF_Pcent) / 100)
                '            TotSlabAmt = FormatNumber(TotSlabAmt + VPF_Amt, 2)
                '            Rem_flag = False
                '        End If
                '        If Phed_type2 = "DEEmpESI" And arr_ernamt(cntr) > 10000 Then
                '            TotSlabAmt = CDbl(0)
                '        End If
                '        If STRT = 0 Then
                '            phed_arr(0) = TotSlabAmt
                '            STRT += 1
                '            INC_ARR += 1
                '        ElseIf STRT <> 0 Then
                '            phed_arr(INC_ARR) = TotSlabAmt
                '            INC_ARR += 1
                '        End If
                'LstvewAll.Items(i).SubItems(15).Text = TotSlabAmt
                'ElseIf recrd_flag = False Then
                '    'LstvewAll.Items(i).SubItems(13).Text = 0
                'End If
            End If
        End If

    End Sub


    Private Sub Fetch_VPF()

        Try
            Fetch_Payhed_Cmd = New SqlCommand("select empvpfPcent from FinActEmpPfEsi where emppfdelstatus=1 and emppfconcrnid='" & (empid) & "'", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            Fetch_Payhed_Rdr.Read()
            If Fetch_Payhed_Rdr.HasRows = True Then
                VPF_Pcent = Fetch_Payhed_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try

    End Sub

    Private Function recfun_payhead(ByVal headname As String, ByVal headid As Integer) As String

        Dim Rateval, RateId1, counter As Integer
        Dim FromAmt, UptoAmt, BscSlry, SlabAmt, DiffAmt As Double
        'Dim LstPayhed As ListViewItem
        Dim recrd_flag As Boolean
        TotSlabAmt = 0
        Dim Arr_Pay_Type(100) As String
        Dim Arr_PhedId(100), Arr_PFId(100) As Integer
        Dim m As Integer
        m = 0
        Try
            Fetch_Payhed_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PheadId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (headid) & "' ", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            While Fetch_Payhed_Rdr.Read()
                If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                    Arr_PFId(m) = Fetch_Payhed_Rdr(0)
                    Arr_Pay_Type(m) = Fetch_Payhed_Rdr(1)
                    Arr_PhedId(m) = Fetch_Payhed_Rdr(2)
                End If
                m = m + 1
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try

        Dim contr As Integer = 0
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&Recursive begin------------------------------------
        While contr < m
            counter = 0
            j1 = 0
            l1 = 0
            Try
                Fetch_Payhed_Cmd = New SqlCommand("select PheadName,PheadComp,PheadType,PheadCalmtd,PhFormulatype,PheadId from FinactPayHead where PheadDelstatus=0 and PheadId='" & (Arr_PFId(contr)) & "'", FinActConn) 'and PheadCalmtd<>'As User Defined Value' 
                Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                Fetch_Payhed_Rdr.Read()
                If Fetch_Payhed_Rdr.HasRows = True Then
                    Payhead_Name1 = Fetch_Payhed_Rdr(0)
                    Arr_Ern_Deduc1(j1) = Fetch_Payhed_Rdr(1)
                    Phed_Comp1 = Fetch_Payhed_Rdr(1)
                    Arr_Phed_Type21(l1) = Fetch_Payhed_Rdr(2)
                    Phed_Calmtd1 = Fetch_Payhed_Rdr(3)
                    Phed_Formulatype1 = Fetch_Payhed_Rdr(4)
                    Phed_Id1 = Fetch_Payhed_Rdr(5)
                    j1 = j1 + 1
                    l1 = l1 + 1
                End If '--
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Fetch_Payhed_Rdr.Close()
                Fetch_Payhed_Cmd = Nothing
            End Try
            If Phed_Calmtd1 = "As Computed Value" Or Phed_Calmtd1 = "on Production/Performance value" Then
                phed_detls = True
                If Phed_Comp1 = "On Basic" Then
                    Fetch_Slab_RateId()
                    '--------Fetch_slabrate()
                    Rateval = 0
                    RateId1 = 0
                    FromAmt = 0
                    UptoAmt = 0
                    BscSlry = 0
                    SlabAmt = 0
                    DiffAmt = 0
                    counter = 0
                    recrd_flag = False
                    Dim extsub_flag As Boolean = False
                    TotSlabAmt = 0
                    While counter < Count_SlabId
                        If phed_detls = True Then
                            Try
                                Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 and SrateId='" & (RateId11) & "'", FinActConn)
                                Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                Fetch_Payhed_Rdr.Read()
                                If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                    recrd_flag = True
                                    RateId11 = Fetch_Payhed_Rdr(0)
                                    FromAmt = Fetch_Payhed_Rdr(1)
                                    If Fetch_Payhed_Rdr(2) <> "Above" Then
                                        UptoAmt = Fetch_Payhed_Rdr(2)
                                    Else
                                        UptoAmt = 9999999999999
                                    End If
                                    Rateval = Fetch_Payhed_Rdr(3)
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                If Fetch_Payhed_Rdr.IsDBNull(0) = True Then
                                    recrd_flag = False
                                End If
                                Fetch_Payhed_Rdr.Close()
                                Fetch_Payhed_Cmd = Nothing
                            End Try
                        End If
                        'If LblBscSlry.Text <> "" Then
                        ' BscSlry = CDbl(LblBscSlry.Text)
                        BscSlry = CDbl(BscSlry)
                        If UptoAmt = 9999999999999 Then
                            UptoAmt = BscSlry
                        End If
                        'End If
                        If UptoAmt > BscSlry And Phed_Formulatype1 <> "Achieved Target" Then
                            UptoAmt = BscSlry
                        End If
                        If Phed_Formulatype1 = "Compound(stepwise)" Then
                            If FromAmt = 0 Then
                                DiffAmt = (UptoAmt - FromAmt)
                            ElseIf FromAmt > 0 Then
                                DiffAmt = (UptoAmt - FromAmt) + 1
                            End If
                            If FromAmt <= BscSlry Then
                                SlabAmt = FormatNumber((DiffAmt * Rateval) / 100, 2)
                                TotSlabAmt = TotSlabAmt + SlabAmt
                                TotSlabAmt = CDbl(TotSlabAmt)
                            End If
                        ElseIf Phed_Formulatype1 = "Flat Rate" Then
                            If BscSlry <= UptoAmt And BscSlry >= FromAmt Then
                                TotSlabAmt = 0
                                SlabAmt = FormatNumber((BscSlry * Rateval) / 100, 2)
                                TotSlabAmt = SlabAmt
                                TotSlabAmt = CDbl(TotSlabAmt)
                            End If
                        ElseIf Phed_Formulatype1 = "Achieved Target" Then
                            If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                                TotSlabAmt = 0
                                SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                                TotSlabAmt = CDbl(SlabAmt)
                            End If
                        ElseIf Phed_Formulatype1 = "Earned Amount" Then
                            If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                                TotSlabAmt = 0
                                SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                                TotSlabAmt = CDbl(SlabAmt)
                            End If
                        End If
                        If phed_detls = False Then
                            RateId = RateId + 1
                        ElseIf phed_detls = True Then
                            RateId11 = RateId11 + 1
                        End If
                        counter = counter + 1
                        extsub_flag = True
                    End While
                    If counter = Count_SlabId Then
                        ' Dim LstPayhed1 As ListViewItem
                        'If all_flag = False Then
                        If recrd_flag = True And extsub_flag <> True Then
                            'LstPayhed1 = LstvewPayhed.Items.Add(TotSlabAmt)
                        ElseIf recrd_flag = False And extsub_flag <> True Then
                            ' LstPayhed1 = LstvewPayhed.Items.Add(0)
                        End If
                        If extsub_flag <> True Then
                            'LstPayhed1.SubItems.Add(Payhead_Name)
                            'LstPayhed1.SubItems.Add(Payhead_Type)
                            'LstPayhed1.SubItems.Add(Ern_Deduc)
                            'If Payhead_Type = "As User Defined Value" Then
                            '    LstPayhed1.SubItems.Add("Not Edit")
                            'Else
                            '    LstPayhed1.SubItems.Add("Edit")
                            'End If
                            'LstPayhed1.SubItems.Add(PheadType)
                        End If
                        'End If
                    End If
                    ''''''''''''''''''''''''''''' contr = contr + 1
                ElseIf Phed_Comp1 = "On Specified Formula" Then
                    Dim m1 As Integer
                    Dim loopvar As Integer = 0
                    Dim Target_Amt1 As Double = 0.0
                    Dim Arr_Pay_Type1(100) As String
                    Dim Arr_PhedId1(100), Arr_PFid1(100) As Integer

                    If Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Or Phed_Formulatype1 = "Achieved Target" Or Phed_Formulatype1 = "Earned Amount" Then
                        If Phed_Formulatype1 <> "Achieved Target" And Phed_Formulatype1 <> "Earned Amount" Then
                            TotSlabAmt1 = 0

                            m1 = 0
                            Try
                                Fetch_Payhed_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PheadId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (Phed_Id1) & "'", FinActConn)
                                Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                While Fetch_Payhed_Rdr.Read()
                                    If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                        Arr_PFid1(m1) = Fetch_Payhed_Rdr(0)
                                        Arr_Pay_Type1(m1) = Fetch_Payhed_Rdr(1)
                                        Arr_PhedId1(m1) = Fetch_Payhed_Rdr(2)
                                    End If
                                    m1 = m1 + 1
                                End While
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                Fetch_Payhed_Rdr.Close()
                                Fetch_Payhed_Cmd = Nothing
                            End Try
                            TotSlabAmt1 = 0

                        End If
                        If Phed_Formulatype1 = "Achieved Target" Or Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Or Phed_Formulatype1 = "Earned Amount" Then
                            If Phed_Formulatype1 = "Achieved Target" Then
                                ' Arr_PhedId(loopvar) = Phed_Id1
                                Arr_PFId(loopvar) = Phed_Id1
                                m1 = 1
                                Try
                                    Fetch_Payhed_Cmd = New SqlCommand("select Amt from Finact_Target where EId='" & (empid) & "'", FinActConn)
                                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                    Fetch_Payhed_Rdr.Read()
                                    If Fetch_Payhed_Rdr.HasRows = True Then
                                        Target_Amt1 = CDbl(Fetch_Payhed_Rdr(0))
                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                Finally
                                    If Fetch_Payhed_Rdr.HasRows = False Then
                                        Target_Amt1 = CDbl(0)
                                    End If
                                    Fetch_Payhed_Rdr.Close()
                                    Fetch_Payhed_Cmd = Nothing
                                End Try

                            End If
                            If Phed_Formulatype1 = "Earned Amount" Then
                                'Arr_PhedId(loopvar) = Phed_Id1
                                Arr_PFId(loopvar) = Phed_Id1
                                m1 = 1
                                Target_Amt1 = CDbl(BscSlry)
                            End If
                            If Phed_Formulatype1 = "Compound(stepwise)" Then
                                'Arr_PhedId(loopvar) = Phed_Id1
                                Arr_PFId(loopvar) = Phed_Id1
                                ' m1 = 1
                                ' Target_Amt1 = CDbl(LblErnAmt.Text)
                            End If




                            While loopvar < m1

                                Try
                                    Fetch_Payhed_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                    Fetch_Payhed_Rdr.Read()
                                    If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                        Count_SlabId1 = Fetch_Payhed_Rdr(0)
                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                Finally
                                    Fetch_Payhed_Rdr.Close()
                                    Fetch_Payhed_Cmd = Nothing
                                End Try
                                If Count_SlabId1 > 0 Then
                                    Try
                                        Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                        Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                        Fetch_Payhed_Rdr.Read()
                                        If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                            RateId11 = Fetch_Payhed_Rdr(0)
                                        End If
                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                    Finally
                                        Fetch_Payhed_Rdr.Close()
                                        Fetch_Payhed_Cmd = Nothing
                                    End Try

                                End If

                                While counter < Count_SlabId1

                                    Try
                                        Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Arr_PFId(loopvar)) & "'and PheadDelstatus=0 and SrateId='" & (RateId11) & "'", FinActConn)
                                        Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                        Fetch_Payhed_Rdr.Read()
                                        If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                            RateId11 = Fetch_Payhed_Rdr(0)
                                            FromAmt1 = Fetch_Payhed_Rdr(1)
                                            If Fetch_Payhed_Rdr(2) <> "Above" Then
                                                UptoAmt1 = Fetch_Payhed_Rdr(2)
                                            Else
                                                UptoAmt1 = 9999999999999
                                            End If

                                            Rateval1 = Fetch_Payhed_Rdr(3)
                                        End If

                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                    Finally
                                        If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                            recrd_flag = True
                                        ElseIf Fetch_Payhed_Rdr.IsDBNull(0) = True Then
                                            recrd_flag = False
                                        End If
                                        Fetch_Payhed_Rdr.Close()
                                        Fetch_Payhed_Cmd = Nothing
                                    End Try
                                    'If LblBscSlry.Text <> "" Then
                                    'BscSlry1 = CDbl(LblBscSlry.Text)
                                    BscSlry1 = CDbl(BscSlry)
                                    If UptoAmt1 = 9999999999999 Then
                                        UptoAmt1 = BscSlry
                                    End If
                                    'ElseIf all_flag = True Then
                                    'BscSlry1 = Arr_Bscsalary(cntr)
                                    'If UptoAmt1 = 9999999999999 Then
                                    '    UptoAmt1 = BscSlry1
                                    'End If
                                    'End If
                                    If UptoAmt1 > BscSlry1 And Phed_Formulatype1 <> "Achieved Target" Then
                                        UptoAmt1 = BscSlry1
                                    End If
                                    If Phed_Formulatype1 = "Compound(stepwise)" Then
                                        If FromAmt1 = 0 Then
                                            DiffAmt1 = (UptoAmt1 - FromAmt1)
                                        ElseIf FromAmt > 0 Then
                                            DiffAmt1 = (UptoAmt1 - FromAmt1) + 1
                                        End If
                                        If FromAmt1 <= BscSlry1 Then
                                            SlabAmt1 = FormatNumber((DiffAmt1 * Rateval1) / 100, 2)
                                            TotSlabAmt1 = TotSlabAmt1 + SlabAmt1
                                            TotSlabAmt1 = CDbl(TotSlabAmt1)
                                        End If
                                    ElseIf Phed_Formulatype1 = "Flat Rate" Then
                                        If BscSlry1 <= UptoAmt1 And BscSlry1 >= FromAmt1 Then
                                            TotSlabAmt1 = 0
                                            SlabAmt1 = FormatNumber((BscSlry1 * Rateval1) / 100, 2)
                                            TotSlabAmt1 = SlabAmt1
                                            TotSlabAmt1 = CDbl(TotSlabAmt1)
                                        End If
                                    ElseIf Phed_Formulatype1 = "Achieved Target" Then
                                        If Target_Amt1 <= UptoAmt1 And Target_Amt1 >= FromAmt1 Then
                                            TotSlabAmt1 = 0
                                            SlabAmt1 = FormatNumber(Target_Amt1 * Rateval1 / 100, 2)
                                            TotSlabAmt1 = CDbl(SlabAmt1)
                                        End If
                                    ElseIf Phed_Formulatype1 = "Earned Amount" Then
                                        If Target_Amt1 <= UptoAmt1 And Target_Amt1 >= FromAmt1 Then
                                            TotSlabAmt1 = 0
                                            SlabAmt1 = FormatNumber(Target_Amt1 * Rateval1 / 100, 2)
                                            TotSlabAmt1 = CDbl(SlabAmt1)
                                        End If
                                    End If
                                    TotSlabAmt = TotSlabAmt1
                                    RateId11 = RateId11 + 1
                                    RateId = RateId + 1
                                    counter = counter + 1
                                End While
                                loopvar += 1
                                If loopvar = m1 Then
                                    loopvar_flag = True
                                    totslab_flag = True
                                    phed_detls = True
                                    If Phed_Formulatype1 <> "Achieved Target" And Phed_Formulatype1 <> "Earned Amount" Then
                                        BscAmt = CDbl(TotSlabAmt)
                                        finalamt = BscSlry1 - BscAmt
                                        BscAmt = CDbl(finalamt)
                                        Fetch_Slab_RateId()
                                        Fetch_slabrate()
                                    End If
                                End If
                            End While 'lop[
                        End If 'COME()
                    End If
                    '''''''''''''''''''''contr = contr + 1

                End If
            ElseIf Phed_Calmtd1 = "As User Defined Value" Then 'USER---------------
                Fetch_UsrPhed_Amt1()
                TotSlabAmt = FormatNumber(UsrPhed_Amt, 2)

            End If
            'If  LblBscSlry.Text <> "" Then
            'BscSlry = CDbl(LblBscSlry.Text)
            BscSlry = CDbl(BscSlry)

            'End If
            If contr = m Then
                totslab_flag = True
                phed_detls = False
                BscAmt = CDbl(TotSlabAmt)
                finalamt = BscSlry - BscAmt
                BscAmt = CDbl(finalamt)
                Fetch_Slab_RateId()
                Fetch_slabrate()
            End If
            If Trim(Arr_Pay_Type(contr)) = Trim("Add") Then
                If contr = 0 Then
                    result = BscSlry + TotSlabAmt
                ElseIf contr <> 0 Then
                    result += TotSlabAmt
                End If
            ElseIf Trim(Arr_Pay_Type(contr)) = Trim("Minus") Then
                If contr = 0 Then
                    result = BscSlry - TotSlabAmt
                ElseIf contr <> 0 Then
                    result -= TotSlabAmt
                End If
                '
            End If
            contr = contr + 1
        End While 'main while
        phed_detls = False
        BscSlry = result
        totslab_flag = True
        BscSry_cng = result
        Payhead_Name1 = headname
        phed_detls = True
        Phed_Formulatype1 = str_PheadFormula
        Phed_Id1 = Sec_Phed_id
        recursve_flag = True
        Fetch_Slab_RateId()
        Fetch_slabrate()
        result = TotSlabAmt
        Return result

    End Function



    Private Sub RbNoPhed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbNoPhed.CheckedChanged
        If RbNoPhed.Checked = True Then
            LstvewPhed.Enabled = False

        End If
    End Sub

   
    Private Sub RbYes_Phed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbYes_Phed.CheckedChanged
        If RbYes_Phed.Checked = True Then
            LstvewPhed.Enabled = True
        ElseIf RbYes_Phed.Checked = False Then
            RbNoPhed.Focus()
        End If
    End Sub

    Private Sub RbNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbNo.CheckedChanged
        If RbNo.Checked = True Then
            RbYesCmpo.Enabled = True
            RbNoCmpo.Enabled = True
        ElseIf RbNo.Checked = False Then
            RbYesCmpo.Enabled = False
            RbNoCmpo.Enabled = False
            RbYesCmpo.Checked = False
            RbNoCmpo.Checked = False
        End If
    End Sub


    Private Sub LstvewPhed_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles LstvewPhed.ItemCheck
        Dim add, minus As Double
        Dim Ptype As String = ""
        LblGrossSlry.Text = ""
        i = 0
        For i = 0 To LstvewPhed.Items.Count - 1
            ' MsgBox(LstvewPhed.Items(i).Checked)
            If LstvewPhed.Items(i).Checked = True Then
                Ptype = LstvewPhed.Items(i).SubItems(4).Text
                If Ptype = "EREmp" Or Ptype = "REB" Then
                    add = CDbl(add) + CDbl(LstvewPhed.Items(i).SubItems(5).Text)
                    ' LblGrossSlry.Text = FormatNumber(CDbl(TxtScale.Text) + CDbl(LstvewPhed.Items(i).SubItems(5).Text), 2)
                ElseIf Ptype = "DEEmp" Or Ptype = "ESDed" Or Ptype = "ESCon" Or Ptype = "DEEmpPF" Or Ptype = "DEEmpESI" Then
                    minus = CDbl(minus) + CDbl(LstvewPhed.Items(i).SubItems(5).Text)

                    ' LblGrossSlry.Text = FormatNumber(CDbl(TxtScale.Text) - CDbl(LstvewPhed.Items(i).SubItems(5).Text), 2)
                End If
               
            End If
        Next

        LblGrossSlry.Text = FormatNumber((CDbl(TxtScale.Text) + add - minus), 2)


    End Sub

   
    Private Sub TxtVPpercnt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVPpercnt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TxtPolicno.Focus()

        End If
    End Sub

    Private Sub TxtInsurdAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtInsurdAmt.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            TxtInsId.Focus()
        End If
    End Sub

 
    Private Sub TxtNewPfNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNewPfNo.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            DtpkrPfJdt.Focus()
        End If
    End Sub

    Private Sub CmbxBonus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxBonus.GotFocus
        If CmbxBonus.Items.Count > 0 Then
            If CmbxBonus.Text = "" Then
                CmbxBonus.SelectedIndex = 0
            End If
            CmbxBonus.DroppedDown = True
        End If

    End Sub

    Private Sub CmbxBonus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxBonus.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Rbcash.Focus()
        End If
    End Sub

    Private Sub TxtNmShare_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNmShare.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If TxtNmShare.Text = "" Then
                MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Field")
                TxtNmShare.BackColor = Color.PapayaWhip
                TxtNmShare.Focus()
            ElseIf TxtNmShare.Text > 100 Then
                MsgBox("Nominee's Share value can't exceed than 100%", MsgBoxStyle.Information, "Share")
                TxtNmShare.SelectAll()
                TxtNmShare.Focus()
            Else
                Cmbxctynomi.Focus()
            End If
        End If
    End Sub


    Private Sub ClearNomi()
        TxtNomine.Clear()
        If cmbxrelt.SelectedIndex > 0 Then
            cmbxrelt.SelectedIndex = 0
        End If
        Txtadrsnomi.Clear()
        txtadrsnomi1.Clear()
        If cmbxstatus.SelectedIndex > 0 Then
            cmbxstatus.SelectedIndex = 0
        End If
        TxtNmShare.Clear()
        Txtgrdian.Clear()
        If Cmbxctynomi.SelectedIndex > 0 Then
            Cmbxctynomi.SelectedIndex = 0
        End If
        TxtPinNomi.Clear()
        LblStatenomi.Text = ""
        LblContryNomi.Text = ""

    End Sub

    Private Sub LnkLblVew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkLblVew.LinkClicked
        FrmNmDetails.ShowDialog()
    End Sub

    Private Sub TxtNmShare_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNmShare.TextChanged
        If TxtNmShare.BackColor <> Color.White Then
            TxtNmShare.BackColor = Color.White
        End If
    End Sub

    Private Sub CmbxFrm2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 

    End Sub


    Private Sub AddColumns()
        Dim dtp As New CalendarColumn()
        Dim DOB_Flag As Boolean = False

        i = 0
        While i < FrmNmDetails.DataGridView1.Columns.Count
            If FrmNmDetails.DataGridView1.Columns(i).HeaderText = "DOB" Then
                DOB_Flag = True
                i = FrmNmDetails.DataGridView1.Columns.Count
            Else
                DOB_Flag = False
                i = i + 1
            End If
        End While
        If DOB_Flag = False Then
            Try
                dtp.HeaderText = "DOB"
                dtp.Name = "DOB"
                'cel.Value = Dtpkrdob2.Text
                dtp.DisplayIndex = 4
                FrmNmDetails.DataGridView1.Columns.Add(dtp)

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub LstVewSelRec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVewSelRec.SelectedIndexChanged

    End Sub

    Private Sub Txtwrkid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtwrkid.SelectedIndexChanged

    End Sub
End Class




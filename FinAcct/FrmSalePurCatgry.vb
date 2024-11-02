Imports System.Data.SqlClient
Imports System.Data.DataTable
Imports System.Data
Public Class FrmSalePurCatgry
    Dim Indx As Integer
    Dim CatCmd As SqlCommand
    Dim DtaRdr As SqlDataReader
    Dim addFlag As Boolean
    Dim EdtFlag As Boolean
    Dim AllowEdt As Boolean = False
    Dim EdtRecrdNo As Integer
    Dim DelStatus As Integer
    Dim SPType As String = ""
    Dim Vatrate As Double
    Dim Chkexisit_catname, Chkexisit_cattype, Chkedit_catname As String
    Dim Chkexisit_catrate, Chkedit_catrate As Double
    Dim SpFlag As Boolean = False
    Dim xSalePurType As String = ""

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        Try
            Dim SveCnfrm As String
            SveCnfrm = MsgBox("Are u sure to Save this record", MsgBoxStyle.YesNo)
          
            Dim Vc As String = ""
            If xSalePurType.Trim = "INTER STATE" Then
                Vc = " CST "
                If Me.ChkbxCform.CheckState = CheckState.Checked Then
                    If CDbl(Me.Vatpercent.Text) <= 0 Then
                        MsgBox("Invalid Input! Pl. Check C Form Status. CST Rate should be greater than zero", MsgBoxStyle.Critical, Me.Text)
                        Exit Sub
                    End If
                End If
            Else
                Vc = " VAT "
                If Me.ChkbxCform.CheckState = CheckState.Checked Then
                    MsgBox("Invalid Input! Pl. Check C Form Status.", MsgBoxStyle.Critical, Me.Text)
                    Exit Sub
                End If
            End If
            If SveCnfrm = vbYes Then
                If addFlag = True Then
                    Chk_CatExisit()

                    If Trim(SPType) = Trim(Chkexisit_cattype) And Trim(TxtDept.Text) = Trim(Chkexisit_catname) And Vatrate = Chkexisit_catrate Then
                        MsgBox("Invalid input! system has found a record with same value, Try another value", MsgBoxStyle.Critical)
                        TxtDept.SelectAll()
                        TxtDept.Focus()
                        Exit Sub
                    End If
                    Vatrate = CDbl(Me.Vatpercent.Text)

                    Dim VatName As String = ""
                    Dim xName As String = Trim(Me.Cmbxtxtype.Text.ToUpper)
                    If Me.Vatpercent.Text > 0 Then
                        VatName = (xName) & Vc & Vatrate & "%"
                    Else
                        VatName = (xName)
                    End If

                    CatCmd = New SqlCommand("Finact_SalePurCategory_Insert", FinActConn)
                    CatCmd.CommandType = CommandType.StoredProcedure
                    CatCmd.Parameters.AddWithValue("@deptname", Trim(VatName))
                    CatCmd.Parameters.AddWithValue("@type", SPType)
                    CatCmd.Parameters.AddWithValue("@spcattxrate", CDbl(Vatrate))
                    CatCmd.Parameters.AddWithValue("@SurCharg", CDbl(Me.TxtSurcharg.Text))
                    If Me.ChkbxCform.CheckState = CheckState.Checked Then
                        CatCmd.Parameters.AddWithValue("@Cform", 1)
                    Else
                        CatCmd.Parameters.AddWithValue("@Cform", 0)
                    End If
                    CatCmd.Parameters.AddWithValue("@adusrid", Current_UsrId)
                    CatCmd.Parameters.AddWithValue("@addt", Now)
                    CatCmd.Parameters.AddWithValue("@delstatus", 1)
                    CatCmd.Parameters.AddWithValue("@sptypeid", Me.Cmbxtxtype.SelectedValue)
                ElseIf EdtFlag = True Then
                    Chk_CatExisit()
                    If Trim(SPType) = Trim(Chkexisit_cattype) And Trim(TxtDept.Text) <> Trim(Chkedit_catname) And (Vatrate) <> Chkedit_catrate Then
                        If Trim(SPType) = Trim(Chkexisit_cattype) And Trim(TxtDept.Text) = Trim(Chkexisit_catname) And Vatrate = Chkexisit_catrate Then
                            MsgBox("Invalid input! system has found a record with same value, Try another value", MsgBoxStyle.Critical)
                            TxtDept.SelectAll()
                            TxtDept.Focus()
                            Exit Sub
                        End If
                    End If
                    Vatrate = Me.Vatpercent.Text
                    Dim VatName As String = ""
                    Dim xName As String = Trim(Me.Cmbxtxtype.Text.ToUpper)
                    If Me.Vatpercent.Text > 0 Then
                        VatName = (xName) & Vc & Vatrate & "%"
                    Else
                        VatName = (xName)
                    End If

                    CatCmd = New SqlCommand("Finact_SalePurCategory_update", FinActConn)
                    CatCmd.CommandType = CommandType.StoredProcedure
                    CatCmd.Parameters.AddWithValue("@deptname", Trim(VatName))
                    CatCmd.Parameters.AddWithValue("@type", SPType)
                    CatCmd.Parameters.AddWithValue("@spcattxrate", CDbl(Vatrate))
                    CatCmd.Parameters.AddWithValue("@deptid", EdtRecrdNo)
                    CatCmd.Parameters.AddWithValue("@delstatus", 1)
                    CatCmd.Parameters.AddWithValue("@SurCharg", CDbl(Me.TxtSurcharg.Text))
                    If Me.ChkbxCform.CheckState = CheckState.Checked Then
                        CatCmd.Parameters.AddWithValue("@Cform", 1)
                    Else
                        CatCmd.Parameters.AddWithValue("@Cform", 0)
                    End If
                    CatCmd.Parameters.AddWithValue("@edtusrid", Current_UsrId)
                    CatCmd.Parameters.AddWithValue("@edtdt", Now)
                    CatCmd.Parameters.AddWithValue("@sptypeid", Me.Cmbxtxtype.SelectedValue)

                End If
                Try
                    CatCmd.ExecuteNonQuery()
                    MsgBox("Record Has been Successfully Saved/Updated", MsgBoxStyle.Information)
                    ClrValue()
                    If FrmShow_flag(10) = True Then
                        IntHtCmMm(10) = Trim(TxtDept.Text)
                    End If
                    If FrmShow_flag(11) = True Then
                        IntHtCmMm(11) = Trim(TxtDept.Text)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Sale Purchase Category")
                    TxtDept.SelectAll()
                    TxtDept.Focus()
                    Exit Try
                Finally
                    CatCmd = Nothing
                    Btnadd.Focus()

                End Try
            ElseIf SveCnfrm = vbNo Then
                TxtDept.Focus()
            End If
            Me.Label1.Visible = False
            Me.TxtDept.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        

    End Sub

    Private Sub FrmdeptMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 502 'MeWidth / 1.45
            Me.Height = 458 'MeHeight / 3.7
            Me.StartPosition = FormStartPosition.CenterScreen
            CheckAcess_Btn_frm(Btnadd, Btnedt, BtnDele, BtnFind)
            addFlag = True
            EdtFlag = False
            Me.Cmbxtxtype.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CheckAcess_Btn_frm(ByVal BtnnAdd As Button, ByVal BtnnEdt As Button, _
         ByVal BtnnDel As Button, ByVal BtnnFnd As Button)
        Select Case Trim(AcessRight)
            Case "OwnrFull"
                BtnnAdd.Enabled = True
                BtnnEdt.Enabled = True
                BtnnDel.Enabled = True
                BtnnFnd.Enabled = True
            Case "DataEntryMstr"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(204, 128)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
                BtnnFnd.Visible = False
            Case "PayRoll"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(204, 128)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
                BtnnFnd.Visible = False
        End Select
    End Sub
    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        If Trim(SPType) <> "" Then
            Me.Width = 858
            Me.Height = 458
            ClrValue()
            LstVewFnd.Clear()
            LstVewFnd.Columns.Add("Name Of Branch", LstVewFnd.Width, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Id", LstVewFnd.Width \ 1, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Type", LstVewFnd.Width \ 1, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("VatRate", LstVewFnd.Width \ 1, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Type id", LstVewFnd.Width \ 1, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("SURCHARGE", LstVewFnd.Width \ 1, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("C Form", LstVewFnd.Width \ 1, HorizontalAlignment.Left)

            Dim LstItem As ListViewItem
            LstVewFnd.Visible = True
            CatCmd = New SqlCommand("Select * from finactSalePurCatgry where spcatdelstatus=1 and spcattype='" & Trim(SPType) & "' order by spcatname ", FinActConn)
            Try
                DtaRdr = CatCmd.ExecuteReader
                Dim x As Integer
                x = 0
                While DtaRdr.Read()
                    LstItem = LstVewFnd.Items.Add(DtaRdr("spcatname"), 1)
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("spcatid"))
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("spcattype"))
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("spcattxrate"))
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("sptypeid"))
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("SURCHARG"))
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("cform"))
                    x += 1
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            Finally
                DtaRdr.Close()
                CatCmd = Nothing
                LstVewFnd.Focus()
                LstVewFnd.Select()
            End Try
            addFlag = False
            EdtFlag = True
        Else
            RbSale.Focus()
        End If

    End Sub
    Private Sub BtnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClos.Click
        Me.Close()
    End Sub

    Private Sub BtnDele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDele.Click
        If TxtDept.Text = "" Then
            MsgBox("No record is present to delete", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtDept.Text <> "" Then
            Try
                ''CatCmd = New SqlCommand("delete from finactsalepurcatgry where spcatid='" & (EdtRecrdNo) & "'", FinActConn)
                ''CatCmd.ExecuteNonQuery()
                MsgBox("System could not delete this record.", MsgBoxStyle.Critical, "System Reserved Account!!")
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Try
            Finally
                CatCmd = Nothing
                TxtDept.Text = ""
            End Try
        End If

    End Sub

    Private Sub Btnedt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnedt.Click
        Try
            If AllowEdt = True Then
                TxtDept.Focus()
                addFlag = False
                EdtFlag = True
            Else
                MsgBox("Invalid Input", MsgBoxStyle.Critical, "Invalid")
                Btnadd.Focus()
            End If
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
    End Sub


    Private Sub LstVewFnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewFnd.DoubleClick
        Try
            TxtDept.Text = LstVewFnd.SelectedItems(0).Text
            EdtRecrdNo = LstVewFnd.SelectedItems.Item(0).SubItems.Item(1).Text
            Vatpercent.Text = LstVewFnd.SelectedItems.Item(0).SubItems.Item(3).Text
            If Trim(LstVewFnd.SelectedItems(0).SubItems.Item(2).Text) = "Sale" Then
                RbSale.Checked = True
            ElseIf Trim(LstVewFnd.SelectedItems(0).SubItems.Item(2).Text) = "Purchase" Then
                RbPur.Checked = True
            End If
            Chkedit_catname = Trim(LstVewFnd.SelectedItems(0).Text)
            Chkedit_catrate = LstVewFnd.SelectedItems(0).SubItems.Item(3).Text
            Me.Cmbxtxtype.SelectedValue = LstVewFnd.SelectedItems(0).SubItems.Item(4).Text
            Me.TxtSurcharg.Text = FormatNumber(CDbl(LstVewFnd.SelectedItems(0).SubItems.Item(5).Text), 2)
            Dim xCf As Boolean = LstVewFnd.SelectedItems(0).SubItems.Item(6).Text
            If xCf = True Then
                Me.ChkbxCform.CheckState = CheckState.Checked
            Else
                Me.ChkbxCform.CheckState = CheckState.Unchecked
            End If
            LstVewFnd.Visible = False
            Me.Size = New Size(502, 458)
            Btnedt.Enabled = True
            AllowEdt = True
            Btnedt.Focus()
            Me.Label1.Visible = True
            Me.TxtDept.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub


    Private Sub LstVewFnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewFnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            LstVewFnd_DoubleClick(sender, e)
        ElseIf e.KeyCode = Keys.Escape Then
            LstVewFnd.Visible = False
            Me.Size = New Size(502, 458)
        End If
    End Sub

    Private Sub TxtDept_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDept.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtDept_Leave(sender, e)
        End If
    End Sub


    Private Sub TxtDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDept.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(13)
                Vatpercent.Focus()
            Case Microsoft.VisualBasic.ChrW(9)
                Vatpercent.Focus()
            Case Else
        End Select


    End Sub
    Private Sub TxtDept_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDept.Leave
        If Trim(SPType) = "" Then
            RbSale.Focus()
        Else
            Vatpercent.Focus()
        End If

    End Sub
    Private Sub ChekEmpty()
        With TxtDept
            If .Text = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                Indx = Indx + 1
                .Focus()
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
    End Sub
    Private Sub ClrValue()
        TxtDept.Text = ""
        Me.TxtSurcharg.Text = 0
        Me.Vatpercent.Text = 0
        Me.Cmbxtxtype.SelectedIndex = -1
        Me.ChkbxCform.CheckState = CheckState.Unchecked
    End Sub

    Private Sub Btnadd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        Try
            ClrValue()
            addFlag = True
            EdtFlag = False
            AllowEdt = False
            Me.Cmbxtxtype.Focus()
            If LstVewFnd.Visible = True Then
                LstVewFnd.Visible = False
                Me.Size = New Size(502, 458)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub RbSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbSale.CheckedChanged, RbPur.CheckedChanged
        Try
            If Me.LstVewFnd.Visible = True Then
                LstVewFnd.Visible = False
                Me.Size = New Size(502, 458)
                Btnedt.Enabled = True
                AllowEdt = True
                Btnedt.Focus()
            End If

            Me.Cmbxtxtype.DataSource = Nothing
            If RbSale.Checked = True Then
                SPType = "Sale"
                Select_2rec_where("SalePur_id", "SalePur_Name", "SalePurtype1", "Finact_SalePurchaseType", Me.Cmbxtxtype, "SALE", "SALEPURDELSTATUS", CInt(1))
            ElseIf RbPur.Checked = True Then
                SPType = "Purchase"
                Select_2rec_where("SalePur_id", "SalePur_Name", "SalePurtype1", "Finact_SalePurchaseType", Me.Cmbxtxtype, "PURCHASE", "SALEPURDELSTATUS", CInt(1))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    

    Private Sub Vatpercent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Vatpercent.GotFocus
        Try
            Me.Vatpercent.SelectAll()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Vatpercent_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Vatpercent.Leave
        Try
            If xChk_numericValidation(Me.Vatpercent) = False Then
                If Len(Me.Vatpercent.Text) = 0 Then
                    Me.Vatpercent.Text = 0
                End If
                Vatrate = Vatpercent.Text
                If Not Me.Cmbxtxtype.SelectedIndex = -1 Then
                    TxtSurcharg.Focus()
                Else
                    Me.Cmbxtxtype.Focus()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Vatpercent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Vatpercent.TextChanged
        Try
            lblVatRate.Text = Vatpercent.Text & " %"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllBtn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.GotFocus, BtnClos.GotFocus, BtnDele.GotFocus _
    , Btnedt.GotFocus, BtnFind.GotFocus, BtnSave.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSurcharg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSurcharg.GotFocus
        Try
            Me.TxtSurcharg.SelectAll()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Label1.KeyDown, _
    LstVewFnd.KeyDown, BtnClos.KeyDown, BtnDele.KeyDown, Btnedt.KeyDown, BtnFind.KeyDown, BtnSave.KeyDown, Btnadd.KeyDown, _
  Label3.KeyDown, GroupBox1.KeyDown, GroupBox2.KeyDown, lblVatRate.KeyDown, RbPur.KeyDown, RbSale.KeyDown, TxtDept.KeyDown, Vatpercent.KeyDown, Label4.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Cmbxtxtype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxtxtype.GotFocus
        Try
            If SpFlag = True Then
                Me.Cmbxtxtype.DataSource = Nothing
                If RbSale.Checked = True Then
                    SPType = "Sale"
                    Select_2rec_where("SalePur_id", "SalePur_Name", "SalePurtype1", "Finact_SalePurchaseType", Me.Cmbxtxtype, "SALE", "SALEPURDELSTATUS", CInt(1))
                ElseIf RbPur.Checked = True Then
                    SPType = "Purchase"
                    Select_2rec_where("SalePur_id", "SalePur_Name", "SalePurtype1", "Finact_SalePurchaseType", Me.Cmbxtxtype, "PURCHASE", "SALEPURDELSTATUS", CInt(1))
                End If
                SpFlag = False
            End If
            Me.Cmbxtxtype.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Allcontrol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbPur.KeyDown, RbSale.KeyDown, TxtDept.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Vatpercent_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Vatpercent.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Vatpercent_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Chk_CatExisit()
        Try
            CatCmd = New SqlCommand("select spcatname,spcattype,spcattxrate from finactsalepurcatgry" _
            & " where spcatname='" & Trim(TxtDept.Text) & "' and spcattype='" & (SPType) & "' and spcattxrate='" & (Vatrate) & "'order by spcatname ", FinActConn)
            DtaRdr = CatCmd.ExecuteReader
            While DtaRdr.Read
                If DtaRdr.HasRows = True Then
                    Chkexisit_catname = Trim(DtaRdr(0).ToString)
                    Chkexisit_cattype = Trim(DtaRdr(1).ToString)
                    Chkexisit_catrate = DtaRdr(2)
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CatCmd.Dispose()
            DtaRdr.Close()
        End Try
       
    End Sub

    
    Private Sub Btnsp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsp.Click
        Try
            If Me.RbSale.Checked = True Then
                xSalePurCatType = "SALE"
            ElseIf Me.RbPur.Checked = True Then
                xSalePurCatType = "PURCHASE"
            End If
            Dim frmsp As New FrmSalePurchaseMstr
            frmsp.ShowInTaskbar = False
            frmsp.ShowDialog()
            SpFlag = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxtxtype_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxtxtype.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Cmbxtxtype_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxtxtype_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxtxtype.Leave
        Try
            If CheckBlank_Cmbx(Me.Cmbxtxtype) = True Then
                If Me.Cmbxtxtype.SelectedIndex = 0 Then
                    xSalePurType = xDynamic_Find_xAnItem_xInA_Table_1cond_String("salepurtype", "Salepur_id", CInt(Me.Cmbxtxtype.SelectedValue), "Finact_SalePurchaseType").Trim
                    If xSalePurType.Trim = "INTER STATE TAX FREE" Or xSalePurType.Trim = "WITHIN STATE TAX FREE" Then
                        ''==EXEMPTED SALES
                        Me.Vatpercent.Text = 0
                        Me.Vatpercent.Enabled = False
                    ElseIf xSalePurType.Trim = "EXPORT" Then
                        ''==EXPORT SALES
                        Me.Vatpercent.Text = 0
                        Me.Vatpercent.Enabled = True
                    Else
                        Me.Vatpercent.Enabled = True
                    End If
                End If
                If Me.Vatpercent.Enabled = True Then
                    Me.Vatpercent.Focus()
                Else
                    Me.BtnSave.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xAllBtn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.Leave, BtnClos.Leave, BtnDele.Leave _
    , Btnedt.Leave, BtnFind.Leave, BtnSave.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    

    Private Sub Cmbxtxtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxtxtype.SelectedIndexChanged
        Try
            If Me.Cmbxtxtype.SelectedIndex > 0 Then
                xSalePurType = xDynamic_Find_xAnItem_xInA_Table_1cond_String("salepurtype", "Salepur_id", CInt(Me.Cmbxtxtype.SelectedValue), "Finact_SalePurchaseType").Trim
                If xSalePurType.Trim = "INTER STATE TAX FREE" Or xSalePurType.Trim = "WITHIN STATE TAX FREE" Then
                    ''==EXEMPTED SALES
                    Me.Vatpercent.Text = 0
                    Me.Vatpercent.Enabled = False
                ElseIf xSalePurType.Trim = "EXPORT" Then
                    ''==EXPORT SALES
                    Me.Vatpercent.Text = 0
                    Me.Vatpercent.Enabled = True
                Else
                    Me.Vatpercent.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSurcharg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSurcharg.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.TxtSurcharg_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSurcharg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSurcharg.Leave
        Try
            If xChk_numericValidation(Me.TxtSurcharg) = True Then
                Exit Sub
            End If
            If Len(Me.TxtSurcharg.Text) = 0 Then
                Me.TxtSurcharg.Text = 0
            End If
            Me.TxtSurcharg.Text = FormatNumber(Me.TxtSurcharg.Text, 2)
            Me.BtnSave.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    
    Private Sub TxtSurcharg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSurcharg.TextChanged

    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Public Class FrmActFindEdit
    Dim ActFE_Cmd As SqlCommand
    Dim ActFE_Rdr As SqlDataReader
    Dim ActFE_Cmd1 As SqlCommand
    Dim ActFE_Rdr1 As SqlDataReader
    Dim ActFE_Adptr As SqlDataAdapter
    Dim ActFE_DataSet As DataSet
    Dim xOpnBalType As String = ""
    Dim xActFeIndx, xSplrId As Integer
    Dim SharRatio, CurrRatio As Double
    Dim xActFeSrFix, xActFeName, BalType, CoStatus As String

    Private Sub FrmActFindEdit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If FrmShow_flag(5) = True Then FrmShow_flag(5) = False
            If FrmShow_flag(24) = True Then FrmShow_flag(24) = False
        Catch ex As Exception

        End Try
    End Sub
   
    Private Sub FrmActFindEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            If FrmShow_flag(24) = True Then
                Me.TabcontrlAct.SelectedIndex = 5 '===Vendor

                Exit Sub
            End If
            If FrmShow_flag(5) = True Then
                Me.TabcontrlAct.SelectedIndex = 1 '===Customer
                xFillControls_Cust_Tab(CInt(1))
                For Each xLit As ListViewItem In Me.LstCust.Items
                    If CInt(xLit.SubItems(1).Text) = xCustId_EditMode Then
                        xLit.Selected = True
                        Exit For
                    End If
                Next
                Me.LstCust_Leave(sender, e)
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnbnkupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnbnkupdate.Click
        Try
            ActFe_chkemptval()
            If xActFeIndx <> 0 Then
                xActFeIndx = 0
                Exit Sub
            End If
            If Me.LstvewBank.SelectedItems.Count > 0 Then
                ActFeUpdate_BankActt()
            Else
                MsgBox("Invalid input!", MsgBoxStyle.Critical, "No selected row found")
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub TabcontrlAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabcontrlAct.Click
        Try
            xFillControls_Cust_Tab(CInt(Me.TabcontrlAct.SelectedIndex))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub xFillControls_Cust_Tab(ByVal xSelTabIndx As Integer)
        Try
            Dim SetCondtn_val As String = ""
            Select Case xSelTabIndx
                Case 0 'Bank
                    Me.Width = 950
                    SetCondtn_val = "Bank"
                    Me.LstvewBank.Items.Clear()
                    'Fill_Combobox("srfixid", "Srfixname", "Finact_srfixmstr", Me.CmbxSrFx)
                    Fill_Combobox_where_Not_cond("cogrpid", "cogrupnam", "cogrupnam", "finactgrupname", "PRIMARY", Me.CmbxBUgrup, "Codelstatus", CInt(1))
                    Select_2rec_where("Cscid", "Cscctyname", "Csctype", "finactcscmstr", Me.CmbxBCty, "Outer", "CSCDELSTATUS", CInt(1))
                Case 1 'Customer 
                    Me.Width = 1000
                    Me.LstCust.Items.Clear()
                    'Fill_Combobox("splrid", "Srfixname", "Finact_srfixmstr", Me.CmbxCSrfix)
                    Fill_Combobox_where_Not_cond("cogrpid", "cogrupnam", "cogrupnam", "finactgrupname", "PRIMARY", Me.CmbxCUndrGrup, "Codelstatus", CInt(1))
                    Fill_Combobox_where_Not_cond("cogrpid", "cogrupnam", "cogrupnam", "finactgrupname", "PRIMARY", Me.CmbxFltr, "Codelstatus", CInt(1))
                    Select_2rec_where("Cscid", "Cscctyname", "Csctype", "finactcscmstr", Me.CmbxCcty, "Outer", "CSCDELSTATUS", CInt(1))
                    Dim cond As String = "Sales Agent"
                    Select_2rec_where("splrid", "splrname", "splrtype", "Finactsplrmstr", Me.CmbxCsalagnt, cond, "SPLRDELSTATUS", CInt(1))
                    cond = "Sale"
                    Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", Me.CmbxVATCST, cond, "SPCATDELSTATUS", CInt(1))
                    Fill_Combobox("spl_id", "spl_name", "Finact_salepricelstmstr", "SPl_DELSTATUS", CInt(1), Me.CmbxCprice)
                    Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarrix)
                    xCurrActType = "Customer"
                    SetCondtn_val = "Customer"


                Case 2 'General Account
                    Me.Width = 950
                    Me.LstVewGen.Items.Clear()
                    SetCondtn_val = "General Account"
                    ''Fill_Combobox("srfixid", "Srfixname", "Finact_srfixmstr", Me.CmbxGsrfix)
                    Fill_Combobox_where_Not_cond("cogrpid", "cogrupnam", "cogrupnam", "finactgrupname", "PRIMARY", Me.CmbxGundrGrup, "Codelstatus", CInt(1))
                Case 3 ' Sales Agent
                    Me.Width = 950
                    Me.lstVewSl.Items.Clear()
                    SetCondtn_val = "Sales Agent"
                    ''Fill_Combobox("srfixid", "Srfixname", "Finact_srfixmstr", Me.CmbxSlsrfix)
                    Fill_Combobox_where_Not_cond("cogrpid", "cogrupnam", "cogrupnam", "finactgrupname", "PRIMARY", Me.CmbxSlundrgrup, "Codelstatus", CInt(1))
                    Select_2rec_where("Cscid", "Cscctyname", "Csctype", "finactcscmstr", Me.cmbxSlCty, "Outer", "CSCDELSTATUS", CInt(1))

                Case 4 'Share Holder
                    Me.Width = 950
                    Me.Lstvewshare.Items.Clear()
                    SetCondtn_val = "Share Holder"
                    '' Fill_Combobox("srfixid", "Srfixname", "Finact_srfixmstr", Me.CmbxShSrfix)
                    Fill_Combobox_where_Not_cond("cogrpid", "cogrupnam", "cogrupnam", "finactgrupname", "PRIMARY", Me.cmbxshundrgrup, "Codelstatus", CInt(1))
                    Select_2rec_where("Cscid", "Cscctyname", "Csctype", "finactcscmstr", Me.cmbxshcty, "Outer", "CSCDELSTATUS", CInt(1))

                Case 5 'Vendor
                    Me.Width = 1000
                    Me.lstvewvendr.Items.Clear()
                    SetCondtn_val = "Vendor"
                    ''Fill_Combobox("srfixid", "Srfixname", "Finact_srfixmstr", Me.CmbxVSrfx)
                    Fill_Combobox_where_Not_cond("cogrpid", "cogrupnam", "cogrupnam", "finactgrupname", "PRIMARY", Me.CmbxVUndrGrp, "Codelstatus", CInt(1))
                    Select_2rec_where("Cscid", "Cscctyname", "Csctype", "finactcscmstr", Me.CmbxVcty, "Outer", "CSCDELSTATUS", CInt(1))
                    Dim cond As String = "Purchase"
                    Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", Me.CmbxVVatCst, cond, "SPCATDELSTATUS", CInt(1))
                    Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxVcarrix)
                    xCurrActType = "Vendor"

            End Select
            Fill_ListView_Categorywise(SetCondtn_val)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub LstvewBank_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstvewBank.DoubleClick
        Try
            Me.LstvewBank_Leave(sender, e)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LstvewBank_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstvewBank.GotFocus
        Try
            Me.TableLayoutPanel2.Enabled = False
            Me.Btnbnkupdate.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstvewBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstvewBank.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Try
                    Me.LstvewBank_Leave(sender, e)
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LstvewBank_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstvewBank.Leave
        Try
            Me.TableLayoutPanel2.Enabled = True
            Me.Btnbnkupdate.Enabled = True
            Me.Txtbname.Focus()
            Me.Txtbname.SelectAll()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fill_ListView_Categorywise(ByVal SetCondtn_val As String)
        Try
            ActFE_Cmd = New SqlCommand("Finact_SplrMstr_EdtFind_FillLstVew_AsRequired", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            ActFE_Cmd.Parameters.AddWithValue("@Condtn", Trim(SetCondtn_val))
            ActFE_Rdr = ActFE_Cmd.ExecuteReader
            While ActFE_Rdr.Read
                If ActFE_Rdr.IsDBNull(0) = False Then
                    Dim ActFeLst As New ListViewItem
                    ActFeLst.Text = ActFE_Rdr(1)
                    ActFeLst.SubItems.Add(Trim(ActFE_Rdr(0)))
                    Select Case SetCondtn_val
                        Case "Bank"
                            Me.LstvewBank.Items.Add(ActFeLst)
                        Case "Customer"
                            Me.LstCust.Items.Add(ActFeLst)
                        Case "General Account"
                            Me.LstVewGen.Items.Add(ActFeLst)
                        Case "Sales Agent"
                            Me.lstVewSl.Items.Add(ActFeLst)
                        Case "Share Holder"
                            Me.Lstvewshare.Items.Add(ActFeLst)
                        Case "Vendor"
                            Me.lstvewvendr.Items.Add(ActFeLst)
                    End Select

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()
            ActFE_Rdr.Close()

        End Try
    End Sub
    Private Sub Fill_ListView_SelectedGrup(ByVal SetCondtn_val As String, ByVal xGrupid As Integer)
        Try
            ActFE_Cmd = New SqlCommand("Finact_SplrMstr_EdtFind_FillLstVew_SelectedGrup", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            ActFE_Cmd.Parameters.AddWithValue("@Condtn", Trim(SetCondtn_val))
            ActFE_Cmd.Parameters.AddWithValue("@Grupid", xGrupid)
            ActFE_Rdr = ActFE_Cmd.ExecuteReader
            While ActFE_Rdr.Read
                If ActFE_Rdr.IsDBNull(0) = False Then
                    Dim ActFeLst As New ListViewItem
                    ActFeLst.Text = ActFE_Rdr(1)
                    ActFeLst.SubItems.Add(Trim(ActFE_Rdr(0)))
                    Select Case SetCondtn_val
                        Case "Bank"
                            Me.LstvewBank.Items.Add(ActFeLst)
                        Case "Customer"
                            Me.LstCust.Items.Add(ActFeLst)
                        Case "General Account"
                            Me.LstVewGen.Items.Add(ActFeLst)
                        Case "Sales Agent"
                            Me.lstVewSl.Items.Add(ActFeLst)
                        Case "Share Holder"
                            Me.Lstvewshare.Items.Add(ActFeLst)
                        Case "Vendor"
                            Me.lstvewvendr.Items.Add(ActFeLst)
                    End Select

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()
            ActFE_Rdr.Close()

        End Try
    End Sub


    Private Sub LstvewBank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstvewBank.SelectedIndexChanged
        Try
            ActFE_Cmd = New SqlCommand("Finact_SplrMstr_EdtFind_Fillall_AsRequired", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            xSplrId = Me.LstvewBank.SelectedItems(0).SubItems(1).Text
            ActFE_Cmd.Parameters.AddWithValue("@Condtnid", xSplrId)
            ActFE_Rdr = ActFE_Cmd.ExecuteReader
            While ActFE_Rdr.Read
                If ActFE_Rdr.IsDBNull(0) = False Then
                    Me.CmbxSrFx.Text = ActFE_Rdr(31)
                    Me.Txtbname.Text = Trim(ActFE_Rdr(1))
                    Me.CmbxBUgrup.SelectedValue = ActFE_Rdr(2)
                    If ActFE_Rdr.IsDBNull(10) = False Then
                        Me.TxtbOpnbal.Text = FormatNumber(ActFE_Rdr(10), 2)
                    Else
                        Me.TxtbOpnbal.Text = 0.0
                    End If
                    Dim xBalType As String = Trim(ActFE_Rdr(11))
                    If Trim(xBalType) = "Credit" Then
                        Me.rBbcr.Checked = True
                    ElseIf Trim(xBalType) = "Debit" Then
                        Me.rBbdr.Checked = True
                    End If
                    
                    If ActFE_Rdr.IsDBNull(4) = False Then
                        Me.txtBcrlmt.Text = FormatNumber(ActFE_Rdr(4), 2)
                    Else
                        Me.txtBcrlmt.Text = 0.0
                    End If

                    If ActFE_Rdr.IsDBNull(49) = False Then
                        Me.txtbadrs1.Text = Trim(ActFE_Rdr(49))
                    Else
                        Me.txtbadrs1.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(50) = False Then
                        Me.txtbadrs2.Text = Trim(ActFE_Rdr(50))
                    Else
                        Me.txtbadrs2.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(51) = False Then
                        Me.txtbadrs3.Text = Trim(ActFE_Rdr(51))
                    Else
                        Me.txtbadrs3.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(52) = False Then
                        Me.CmbxBCty.SelectedValue = Trim(ActFE_Rdr(52))
                    End If

                    If ActFE_Rdr.IsDBNull(53) = False Then
                        Me.txtbpin.Text = Trim(ActFE_Rdr(53))
                    Else
                        Me.txtbpin.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(54) = False Then
                        Me.txtbphno.Text = Trim(ActFE_Rdr(54))
                    Else
                        Me.txtbphno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(55) = False Then
                        Me.txtbmobno.Text = Trim(ActFE_Rdr(55))
                    Else
                        Me.txtbmobno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(56) = False Then
                        Me.txtbemail.Text = Trim(ActFE_Rdr(56))
                    Else
                        Me.txtbemail.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(57) = False Then
                        Me.txtbweb.Text = Trim(ActFE_Rdr(57))
                    Else
                        Me.txtbweb.Text = ""
                    End If
                    
                End If


            End While
        Catch ex As Exception
            '  MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()
            ActFE_Rdr.Close()
            Opening_Bal_Hndler(Me.lblDiff, xOpnBalType)
        End Try
    End Sub

    Private Sub CmbxBCty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxBCty.SelectedIndexChanged
        Try
            xCmboBox_backColrChange(Me.CmbxBCty)
            Select_State_Contry_where_id("Cscstatename", "CscContry", "Cscid", "finactcscmstr", Me.lblbstate, Me.lblbcontry, Me.CmbxBCty.SelectedValue)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbname.GotFocus
        Try
            xActFeSrFix = Trim(Me.CmbxSrFx.Text)
            xActFeName = Trim(Me.Txtbname.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllCmbx_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSrFx.GotFocus, CmbxBCty.GotFocus _
    , CmbxBUgrup.GotFocus, CmbxCarrix.GotFocus, CmbxCcty.GotFocus, cmbxCFbtapp.GotFocus, CmbxCIncType.GotFocus, CmbxCIntstatus.GotFocus _
    , CmbxCinvtry.GotFocus, cmbxCost.GotFocus, CmbxCprice.GotFocus, CmbxCsalagnt.GotFocus, CmbxCsrTx.GotFocus, CmbxCUndrGrup.GotFocus _
    , cmbxCVatRtn.GotFocus, CmbxGsrfix.GotFocus, CmbxGundrGrup.GotFocus, cmbxshcty.GotFocus, CmbxShSrfix.GotFocus, cmbxshundrgrup.GotFocus _
    , cmbxSlCty.GotFocus, CmbxSlsrfix.GotFocus, cmbxsltype.GotFocus, CmbxSlundrgrup.GotFocus, CmbxVATCST.GotFocus, CmbxVcarrix.GotFocus _
    , CmbxVcost.GotFocus, CmbxVcty.GotFocus, CmbxVFbtapp.GotFocus, CmbxVintry.GotFocus, CmbxVintstatus.GotFocus, CmbxVSrfx.GotFocus, CmbxVSrtx.GotFocus _
    , CmbxVTrgttype.GotFocus, CmbxVUndrGrp.GotFocus, CmbxVVatCst.GotFocus, CmbxVVatRtn.GotFocus
        Try
            Dim cmbx As ComboBox = CType(sender, ComboBox)
            cmbx.DroppedDown = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AllControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtbname.KeyDown, CmbxBUgrup.KeyDown _
    , CmbxBUgrup.KeyDown, CmbxBCty.KeyDown, CmbxCcty.KeyDown, cmbxCFbtapp.KeyDown, CmbxCIncType.KeyDown, CmbxCIntstatus.KeyDown _
    , CmbxCinvtry.KeyDown, cmbxCost.KeyDown, CmbxCprice.KeyDown, CmbxCsalagnt.KeyDown, CmbxCSrfix.KeyDown, CmbxCsrTx.KeyDown _
    , CmbxCUndrGrup.KeyDown, cmbxCVatRtn.KeyDown, CmbxGsrfix.KeyDown, cmbxsltype.KeyDown, CmbxGundrGrup.KeyDown, cmbxshcty.KeyDown _
    , CmbxShSrfix.KeyDown, cmbxshundrgrup.KeyDown, cmbxSlCty.KeyDown, CmbxSlsrfix.KeyDown, CmbxSlundrgrup.KeyDown, CmbxSrFx.KeyDown _
    , CmbxVATCST.KeyDown, CmbxVcarrix.KeyDown, CmbxVcost.KeyDown, CmbxVcty.KeyDown, CmbxVFbtapp.KeyDown, CmbxVintry.KeyDown, CmbxVintstatus.KeyDown _
    , CmbxVSrfx.KeyDown, CmbxVSrtx.KeyDown, CmbxVTrgttype.KeyDown, CmbxVUndrGrp.KeyDown, CmbxVVatRtn.KeyDown _
    , DtpbRec.KeyDown, DtpCust.KeyDown, dTpVndr.KeyDown, NudCrnk.KeyDown, NudDisdy.KeyDown, Nudnetdys.KeyDown, nudShare.KeyDown, NudVdisdys.KeyDown _
    , NudVrnk.KeyDown, Nupntdys.KeyDown, rBbcr.KeyDown, rBbdr.KeyDown, rbcCr.KeyDown, rbCdr.KeyDown _
    , rbshcr.KeyDown, rbShdr.KeyDown, rbslcr.KeyDown, rbsldr.KeyDown, rbVcr.KeyDown, rbVdr.KeyDown, TxtAdrs1.KeyDown, TxtAdrs2.KeyDown _
    , TxtAdrs3.KeyDown, txtbadrs1.KeyDown, txtbadrs2.KeyDown, txtbadrs3.KeyDown, txtBcrlmt.KeyDown, txtbemail.KeyDown, txtbmobno.KeyDown _
    , TxtbOpnbal.KeyDown, txtbphno.KeyDown, txtbpin.KeyDown, TxtCadrs1.KeyDown, TxtCadrs2.KeyDown, TxtCadrs3.KeyDown _
    , TxtCCntactPrsn.KeyDown, TxtCCrlmt.KeyDown, TxtCCstno.KeyDown, TxtCDisc.KeyDown, TxtCemail.KeyDown, TxtCExcise.KeyDown, txtCmobno.KeyDown, TxtCname.KeyDown _
    , TxtCopnbal.KeyDown, TxtCpan.KeyDown, TxtCphno.KeyDown, TxtCpin.KeyDown, TxtCroint.KeyDown, TxtCtarget.KeyDown, TxtCTinVat.KeyDown, TxtCweb.KeyDown _
    , txtGname.KeyDown, TxtGopnBal.KeyDown, TxtIncVal.KeyDown, txtshadrs1.KeyDown, txtshadrs2.KeyDown, txtshadrs3.KeyDown, txtshemailid.KeyDown _
    , txtshmobno.KeyDown, txtShname.KeyDown, txtshopnbal.KeyDown, txtshpan.KeyDown, txtshphno.KeyDown, txtshpin.KeyDown _
    , txtsladrs1.KeyDown, txtsladrs2.KeyDown, txtsladrs3.KeyDown, Txtslcomm.KeyDown, TxtslCrlmt.KeyDown, txtslemail.KeyDown, txtslincentive.KeyDown _
    , txtslmobno.KeyDown, TxtSlname.KeyDown, txtslopnbal.KeyDown, txtslpan.KeyDown, txtslphno.KeyDown, txtslpin.KeyDown, Txtsltrget.KeyDown _
    , TxtVCntactprsn.KeyDown, txtVCstno.KeyDown, TxtVdis.KeyDown, txtVemail.KeyDown, TxtVexcise.KeyDown, txtVmobno.KeyDown, TxtVname.KeyDown, TxtVopnbal.KeyDown _
    , txtVpan.KeyDown, txtVphno.KeyDown, txtVpin.KeyDown, TxtVroint.KeyDown, txtVTrget.KeyDown, TxtVTrgtrate.KeyDown, txtVVAtno.KeyDown, txtVweb.KeyDown, txVcrlmt.KeyDown ', Txtbname.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try


    End Sub


    Private Sub Txtbname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbname.Leave

        Try
            If Validate_EditMode(Me.Txtbname) = True Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function ChkExit_Record() As Boolean
        Try
            ActFE_Cmd = New SqlCommand("Select splrname from finactsplrmstr where splrname=@name and splrsurfix=@surfix", FinActConn)
            ActFE_Cmd.Parameters.AddWithValue("@name", Trim(Me.Txtbname.Text))
            ActFE_Cmd.Parameters.AddWithValue("@surfix", Trim(Me.CmbxSrFx.SelectedValue))
            ActFE_Rdr = ActFE_Cmd.ExecuteReader
            ActFE_Rdr.Read()
            If ActFE_Rdr.HasRows = True Then
                If ActFE_Rdr.IsDBNull(0) = False Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()
            ActFE_Rdr.Close()
        End Try
    End Function
    Private Sub Opening_Bal_Hndler(ByVal xlblOpnBal As Label, ByVal xOpnbalTyp As String)
        Dim DrCrType As String = ""
        Dim OpnDrCr, OpnDr, OpnCr As Double
        OpnDrCr = 0
        OpnDr = 0
        OpnCr = 0
        ActFE_Cmd = New SqlCommand("SELECT SPLRID,Splrname,SPLROPNBAL,SPLRBALTYPE  FROM FINACTSPLRMSTR WHERE FINACTSPLRMSTR.SPLROPNBAL>0 and finactsplrmstr.splrdelstatus=1  ", FinActConn)
        Try
            ActFE_Rdr = ActFE_Cmd.ExecuteReader
            While ActFE_Rdr.Read
                If ActFE_Rdr.HasRows = True Then
                    DrCrType = Trim(ActFE_Rdr("splrbaltype"))
                    If DrCrType = "Debit" Then
                        OpnDr += ActFE_Rdr("splropnbal")

                    ElseIf DrCrType = "Credit" Then
                        OpnCr += ActFE_Rdr("splropnbal")
                    End If
                End If
            End While
            If OpnDr > OpnCr Then
                OpnDrCr = OpnDr - OpnCr
                xlblOpnBal.Text = "Dr > Cr  " & FormatNumber(OpnDrCr, 2)
                xOpnbalTyp = "Dr"
            ElseIf OpnCr > OpnDr Then
                OpnDrCr = OpnCr - OpnDr
                xlblOpnBal.Text = "Cr > Dr  " & FormatNumber(OpnDrCr, 2)
                xOpnbalTyp = "Cr"
            End If
            If OpnDrCr > 0 Then
                xlblOpnBal.Visible = True
            Else
                xlblOpnBal.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ActFE_Cmd = Nothing
            ActFE_Rdr.Close()
        End Try
    End Sub

    Private Sub TxtbOpnbal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtbOpnbal.Leave
        Try
            xChk_numericValidation(Me.TxtbOpnbal)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtBcrlmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBcrlmt.Leave
        Try
            xChk_numericValidation(Me.txtBcrlmt)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub ActFe_chkemptval()
        Try

            With Me.txtbweb
                If Trim(.Text) <> "" Then
                    Searchstring(txtbweb.Text, "WWW.")

                    If OkFormat = False Then
                        Searchstring(txtbweb.Text, "HTTP://WWW.")

                    End If
                    If OkFormat = True Then
                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.Cyan
                        .ForeColor = Color.Black
                        xActFeIndx = xActFeIndx + 1
                        .SelectAll()
                    End If
                End If
            End With

            With Me.txtbemail
                If Trim(.Text) <> "" Then
                    If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then

                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.Cyan
                        .ForeColor = Color.Black
                        .Focus()
                        xActFeIndx = xActFeIndx + 1
                    End If
                End If
            End With

            With Me.CmbxBCty
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.Cyan
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Me.txtbadrs1
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.Cyan
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Me.CmbxBUgrup
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Txtbname
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White

                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ActFe_chkemptvalGen()
        Try
            

            With Me.CmbxGundrGrup
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With txtGname
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White

                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ActFe_chkemptval_customer()
        Try
            With Me.TxtCtarget
                If Trim(.Text) > 0 Then
                    If Trim(Me.TxtIncVal.Text) = "" Then
                        Me.TxtIncVal.BackColor = Color.Cyan
                        xActFeIndx += 1
                        Me.TxtIncVal.Focus()
                    Else
                        Me.TxtIncVal.BackColor = Color.White
                    End If
                Else
                    Me.TxtIncVal.Text = 0
                End If
            End With
            With Me.TxtCweb
                If Trim(.Text) <> "" Then
                    Searchstring(TxtCweb.Text, "WWW.")

                    If OkFormat = False Then
                        Searchstring(TxtCweb.Text, "HTTP://WWW.")

                    End If
                    If OkFormat = True Then
                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.Cyan
                        .ForeColor = Color.Black
                        xActFeIndx = xActFeIndx + 1
                        .SelectAll()
                    End If
                End If
            End With

            With Me.TxtCemail
                If Trim(.Text) <> "" Then
                    If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then

                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.Cyan
                        .ForeColor = Color.Black
                        .Focus()
                        xActFeIndx = xActFeIndx + 1
                    End If
                End If
            End With

            With Me.CmbxCcty
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.Cyan
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Me.TxtCadrs1
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.Cyan
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Me.CmbxCUndrGrup
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With TxtCname
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White

                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ActFe_chkemptval_SaleAgent()
        Try
            With Me.Txtsltrget
                If Trim(.Text) > 0 Then
                    If Trim(Me.txtslincentive.Text) = "" Then
                        Me.txtslincentive.BackColor = Color.Cyan
                        xActFeIndx += 1
                        Me.txtslincentive.Focus()
                    Else
                        Me.txtslincentive.BackColor = Color.White
                    End If
                Else
                    Me.txtslincentive.Text = 0
                End If
            End With

            With Me.txtslweb
                If Trim(.Text) <> "" Then
                    Searchstring(txtslweb.Text, "WWW.")

                    If OkFormat = False Then
                        Searchstring(txtslweb.Text, "HTTP://WWW.")

                    End If
                    If OkFormat = True Then
                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.Cyan
                        .ForeColor = Color.Black
                        xActFeIndx = xActFeIndx + 1
                        .SelectAll()
                    End If
                End If
            End With

            With Me.txtslemail
                If Trim(.Text) <> "" Then
                    If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then

                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.Cyan
                        .ForeColor = Color.Black
                        .Focus()
                        xActFeIndx = xActFeIndx + 1
                    End If
                End If
            End With

            With Me.cmbxSlCty
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.Cyan
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Me.txtsladrs1
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.Cyan
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Me.CmbxSlundrgrup
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With TxtSlname
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White

                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ActFe_chkemptval_Share()
        Try

            With Me.txtshweb
                If Trim(.Text) <> "" Then
                    Searchstring(txtshweb.Text, "WWW.")

                    If OkFormat = False Then
                        Searchstring(txtshweb.Text, "HTTP://WWW.")

                    End If
                    If OkFormat = True Then
                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.Cyan
                        .ForeColor = Color.Black
                        xActFeIndx = xActFeIndx + 1
                        .SelectAll()
                    End If
                End If
            End With

            With Me.txtshemailid
                If Trim(.Text) <> "" Then
                    If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then

                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.Cyan
                        .ForeColor = Color.Black
                        .Focus()
                        xActFeIndx = xActFeIndx + 1
                    End If
                End If
            End With

            With Me.cmbxshcty
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.Cyan
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Me.txtshadrs1
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.Cyan
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Me.cmbxshundrgrup
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With txtShname
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White

                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ActFe_chkemptval_Vendor()
        Try
            With Me.txtVTrget
                If Trim(.Text) > 0 Then
                    If Trim(Me.TxtVTrgtrate.Text) = "" Then
                        Me.TxtVTrgtrate.BackColor = Color.Cyan
                        xActFeIndx += 1
                        Me.TxtVTrgtrate.Focus()
                    Else
                        Me.TxtVTrgtrate.BackColor = Color.White
                    End If
                Else
                    Me.TxtVTrgtrate.Text = 0
                End If
            End With
            With Me.txtVweb
                If Trim(.Text) <> "" Then
                    Searchstring(txtVweb.Text, "WWW.")

                    If OkFormat = False Then
                        Searchstring(txtVweb.Text, "HTTP://WWW.")

                    End If
                    If OkFormat = True Then
                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.Cyan
                        .ForeColor = Color.Black
                        xActFeIndx = xActFeIndx + 1
                        .SelectAll()
                    End If
                End If
            End With

            With Me.txtVemail
                If Trim(.Text) <> "" Then
                    If InStr(.Text$, "@") > 0 And InStr(.Text$, ".") > 0 Then

                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.Cyan
                        .ForeColor = Color.Black
                        .Focus()
                        xActFeIndx = xActFeIndx + 1
                    End If
                End If
            End With

            With Me.CmbxVcty
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.Cyan
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Me.TxtAdrs1
                If .Text = "" Then
                    .Focus()
                    .BackColor = Color.Cyan
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Me.CmbxVUndrGrp
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With TxtVname
                If .Text = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White

                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CmbxBUgrup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxBUgrup.SelectedIndexChanged
        Try
            xCmboBox_backColrChange(Me.CmbxBUgrup)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtbname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtbname.TextChanged
        Try
            xTxtbox_BackColrChange(Me.Txtbname)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbadrs1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbadrs1.TextChanged
        Try
            xTxtbox_BackColrChange(Me.txtbadrs1)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ActFeUpdate_BankActt()

        Try
            If Me.rBbdr.Checked = True Then
                BalType = Trim("Debit")
            ElseIf Me.rBbcr.Checked = True Then
                BalType = Trim("Credit")
            End If
            ActFE_Cmd = New SqlCommand("finact_splrmstr_BankAct_update", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            ActFE_Cmd.Parameters.AddWithValue("@Bnksplrid", xSplrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrname", Trim(Txtbname.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrundrgrup", Me.CmbxBUgrup.SelectedValue)
            If Trim(Me.TxtbOpnbal.Text) <> "" Then
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", (TxtbOpnbal.Text))
            Else
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", 0)
            End If
            ActFE_Cmd.Parameters.AddWithValue("@splrbaltype", BalType)
            If Trim(Me.txtBcrlmt.Text) <> "" Then
                ActFE_Cmd.Parameters.AddWithValue("@splrcrlmt", Me.txtBcrlmt.Text)
            Else
                ActFE_Cmd.Parameters.AddWithValue("@splrcrlmt", 0)
            End If
            ActFE_Cmd.Parameters.AddWithValue("@splrafectdt", Me.DtpbRec.Value.Date)
            ActFE_Cmd.Parameters.AddWithValue("@splrSrfix", Me.CmbxSrFx.Text)

            ActFE_Cmd.Parameters.AddWithValue("@adrs1", Trim(Me.txtbadrs1.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrs2", Trim(Me.txtbadrs2.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrs3", Trim(Me.txtbadrs3.Text))

            ActFE_Cmd.Parameters.AddWithValue("adrsctyid", Me.CmbxBCty.SelectedValue)
            ActFE_Cmd.Parameters.AddWithValue("@adrspin", (Me.txtbpin.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsphwork", Trim(Me.txtbphno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsmoble", Trim(Me.txtbmobno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsemail", Trim(Me.txtbemail.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsweb", Trim(Me.txtbweb.Text))

            ActFE_Cmd.Parameters.AddWithValue("@adrsEdtusrid", Current_UsrId)
            ActFE_Cmd.Parameters.AddWithValue("@adrsEdtdt", Now)
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtusrid", Current_UsrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtdt", Now)
            ActFE_Cmd.ExecuteNonQuery()
            MsgBox("Current Record has been successfully Updated", MsgBoxStyle.Information, "Edit Record")
            Me.LstvewBank.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub ActFeUpdate_GeneralActt()

        Try
            If Me.rbGdr.Checked = True Then
                BalType = Trim("Debit")
            ElseIf Me.rbGcr.Checked = True Then
                BalType = Trim("Credit")
            End If
            ActFE_Cmd = New SqlCommand("finact_splrmstr_GeneralAct_update", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            ActFE_Cmd.Parameters.AddWithValue("@Gensplrid", xSplrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrname", Trim(txtGname.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrundrgrup", Me.CmbxGundrGrup.SelectedValue)
            If Trim(Me.TxtGopnBal.Text) <> "" Then
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", (TxtGopnBal.Text))
            Else
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", 0)
            End If

            ActFE_Cmd.Parameters.AddWithValue("@splrbaltype", BalType)
            ActFE_Cmd.Parameters.AddWithValue("@splrSrfix", Me.CmbxGsrfix.Text)
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtusrid", Current_UsrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtdt", Now)
            ActFE_Cmd.ExecuteNonQuery()
            MsgBox("Current Record has been successfully Updated", MsgBoxStyle.Information, "Edit Record")
            Me.LstvewBank.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub BtnBnkExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBnkExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstCust_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstCust.DoubleClick
        Try
            Me.LstCust_Leave(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstCust_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstCust.GotFocus
        Try
            Me.TableLayoutPanel3.Enabled = False
            Me.Btncutupdate.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstCust_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstCust.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Try
                    Me.LstCust_Leave(sender, e)
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstCust_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstCust.Leave
        Try
            If Me.LstCust.Items.Count > 0 Then
                Me.TableLayoutPanel3.Enabled = True
                Me.Btncutupdate.Enabled = True
                Me.TxtCname.Focus()
                Me.TxtCname.SelectAll()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstCust_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstCust.SelectedIndexChanged
        Try
            xSplrId = Me.LstCust.SelectedItems(0).SubItems(1).Text
            SplrID_Editx = xSplrId
            xSel_CustDetails(xSplrId)
        Catch ex As Exception
            '  MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub xSel_CustDetails(ByVal xCustId As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            ActFE_Cmd = New SqlCommand("Finact_SplrMstr_EdtFind_Fillall_AsRequired", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            xSplrId = xCustId
            SplrID_Editx = xSplrId
            ActFE_Cmd.Parameters.AddWithValue("@Condtnid", xSplrId)
            ActFE_Rdr = ActFE_Cmd.ExecuteReader
            While ActFE_Rdr.Read
                If ActFE_Rdr.IsDBNull(0) = False Then
                    Me.CmbxCSrfix.Text = ActFE_Rdr(31)
                    Me.TxtCname.Text = Trim(ActFE_Rdr(1))
                    Me.CmbxCUndrGrup.SelectedValue = ActFE_Rdr(2)
                    If ActFE_Rdr.IsDBNull(10) = False Then
                        Me.TxtCopnbal.Text = FormatNumber(ActFE_Rdr(10), 2)
                    Else
                        Me.TxtCopnbal.Text = 0.0
                    End If
                    Dim xBalType As String = Trim(ActFE_Rdr(11))
                    If Trim(xBalType) = "Credit" Then
                        Me.rbcCr.Checked = True
                    ElseIf Trim(xBalType) = "Debit" Then
                        Me.rbCdr.Checked = True
                    End If

                    If ActFE_Rdr.IsDBNull(4) = False Then
                        Me.TxtCCrlmt.Text = FormatNumber(ActFE_Rdr(4), 2)
                    Else
                        Me.TxtCCrlmt.Text = 0.0
                    End If

                    If ActFE_Rdr.IsDBNull(5) = False Then
                        Me.TxtCpan.Text = Trim(ActFE_Rdr(5))
                    Else
                        Me.TxtCpan.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(6) = False Then
                        Me.TxtCTinVat.Text = Trim(ActFE_Rdr(6))
                    Else
                        Me.TxtCTinVat.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(7) = False Then
                        Me.TxtCCstno.Text = Trim(ActFE_Rdr(7))
                    Else
                        Me.TxtCCstno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(8) = False Then
                        Me.TxtCExcise.Text = Trim(ActFE_Rdr(8))
                    Else
                        Me.TxtCExcise.Text = ""
                    End If

                    If ActFE_Rdr.IsDBNull(9) = False Then
                        Me.NudCrnk.Value = Trim(ActFE_Rdr(9))
                    Else
                        Me.NudCrnk.Value = 0
                    End If
                    If ActFE_Rdr.IsDBNull(12) = False Then
                        If Trim(ActFE_Rdr(12)) = "False" Then
                            Me.CmbxCinvtry.Text = "No"
                        Else
                            Me.CmbxCinvtry.Text = "Yes"
                        End If
                    End If

                    If ActFE_Rdr.IsDBNull(14) = False Then
                        If Trim(ActFE_Rdr(14)) = "False" Then
                            Me.CmbxCIntstatus.Text = "No"
                        Else
                            Me.CmbxCIntstatus.Text = "Yes"
                        End If
                    End If


                    If ActFE_Rdr.IsDBNull(16) = False Then
                        If Trim(ActFE_Rdr(16)) = "False" Then
                            Me.CmbxCsrTx.Text = "No"
                        Else
                            Me.CmbxCsrTx.Text = "Yes"
                        End If
                    End If
                    If ActFE_Rdr.IsDBNull(17) = False Then
                        If Trim(ActFE_Rdr(17)) = "False" Then
                            Me.cmbxCFbtapp.Text = "No"
                        Else
                            Me.cmbxCFbtapp.Text = "Yes"
                        End If
                    End If
                    If ActFE_Rdr.IsDBNull(18) = False Then
                        If Trim(ActFE_Rdr(18)) = "False" Then
                            Me.cmbxCVatRtn.Text = "No"
                        Else
                            Me.cmbxCVatRtn.Text = "Yes"
                        End If
                    End If
                    If ActFE_Rdr.IsDBNull(19) = False Then
                        Me.TxtCroint.Text = Trim(ActFE_Rdr(19))
                    Else
                        Me.TxtCroint.Text = 0.0
                    End If

                    If ActFE_Rdr.IsDBNull(22) = False Then
                        Me.TxtCDisc.Text = Trim(ActFE_Rdr(22))
                    Else
                        Me.TxtCDisc.Text = 0.0
                    End If
                    If ActFE_Rdr.IsDBNull(23) = False Then
                        Me.TxtCtarget.Text = Trim(ActFE_Rdr(23))
                    Else
                        Me.TxtCtarget.Text = 0.0
                    End If
                    If ActFE_Rdr.IsDBNull(24) = False Then
                        Me.CmbxCIncType.Text = Trim(ActFE_Rdr(24))
                    Else
                        Me.CmbxCIncType.SelectedIndex = 0
                    End If

                    If ActFE_Rdr.IsDBNull(25) = False Then
                        Me.TxtIncVal.Text = Trim(ActFE_Rdr(25))
                    Else
                        Me.TxtIncVal.Text = 0.0
                    End If
                    If ActFE_Rdr.IsDBNull(26) = False Then
                        Me.NudDisdy.Value = Trim(ActFE_Rdr(26))
                    Else
                        Me.NudDisdy.Value = 0
                    End If

                    If ActFE_Rdr.IsDBNull(27) = False Then
                        Me.Nupntdys.Value = Trim(ActFE_Rdr(27))
                    Else
                        Me.Nupntdys.Value = 0
                    End If

                    If ActFE_Rdr.IsDBNull(28) = False Then
                        Me.CmbxCsalagnt.SelectedValue = ActFE_Rdr(28)
                    End If

                    If ActFE_Rdr.IsDBNull(30) = False Then
                        Me.TxtCCntactPrsn.Text = Trim(ActFE_Rdr(30))
                    Else
                        Me.TxtCCntactPrsn.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(33) = False Then
                        Me.CmbxVATCST.SelectedValue = (ActFE_Rdr(33))
                    End If
                    If ActFE_Rdr.IsDBNull(42) = False Then
                        Me.CmbxCarrix.SelectedValue = (ActFE_Rdr(42))
                    End If

                    If ActFE_Rdr.IsDBNull(49) = False Then
                        Me.TxtCadrs1.Text = Trim(ActFE_Rdr(49))
                    Else
                        Me.TxtCadrs1.Text = ""
                    End If
                    ' Me.TxtCadrs1.Text = Trim(ActFE_Rdr(45))

                    If ActFE_Rdr.IsDBNull(50) = False Then
                        Me.TxtCadrs2.Text = Trim(ActFE_Rdr(50))
                    Else
                        Me.TxtCadrs2.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(51) = False Then
                        Me.TxtCadrs3.Text = Trim(ActFE_Rdr(51))
                    Else
                        Me.TxtCadrs3.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(52) = False Then
                        Dim a As Object = Trim(ActFE_Rdr(52))
                        Me.CmbxCcty.SelectedValue = Trim(ActFE_Rdr(52))
                    End If

                    If ActFE_Rdr.IsDBNull(53) = False Then
                        Me.TxtCpin.Text = Trim(ActFE_Rdr(53))
                    Else
                        Me.TxtCpin.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(54) = False Then
                        Me.TxtCphno.Text = Trim(ActFE_Rdr(54))
                    Else
                        Me.TxtCphno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(55) = False Then
                        Me.txtCmobno.Text = Trim(ActFE_Rdr(55))
                    Else
                        Me.txtCmobno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(56) = False Then
                        Me.TxtCemail.Text = Trim(ActFE_Rdr(56))
                    Else
                        Me.TxtCemail.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(57) = False Then
                        Me.TxtCweb.Text = Trim(ActFE_Rdr(57))
                    Else
                        Me.TxtCweb.Text = ""
                    End If

                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()
            ActFE_Rdr.Close()
            Opening_Bal_Hndler(Me.lblDiff, xOpnBalType)
        End Try
    End Sub
    Private Sub Btncutupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btncutupdate.Click
        Try
            ActFe_chkemptval_customer()
            If xActFeIndx <> 0 Then
                xActFeIndx = 0
                Exit Sub
            End If
            If Me.LstCust.SelectedItems.Count > 0 Then
                ActFeUpdate_CustomerActt()
            Else
                MsgBox("Invalid input!", MsgBoxStyle.Critical, "No selected row found")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCustexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCustexit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCname.GotFocus
        Try
            xActFeSrFix = Trim(Me.CmbxCSrfix.Text)
            xActFeName = Trim(Me.TxtCname.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCname.Leave

        Try
            If Validate_EditMode(Me.TxtCname) = True Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub TxtCname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCname.TextChanged
        Try
            xTxtbox_BackColrChange(Me.TxtCname)
        Catch ex As Exception

        End Try
    End Sub

    Private Function Validate_EditMode(ByVal xTxtBox As TextBox) As Boolean
        Try
            If Trim(xTxtBox.Text) <> "" Then
                xTxtBox.BackColor = Color.White
                If Trim(CmbxSrFx.Text.ToUpper) = Trim(xActFeSrFix.ToUpper) And Trim(xTxtBox.Text.ToUpper) = Trim(xActFeName.ToUpper) Then Exit Function
                If ChkExit_Record() = True Then
                    MsgBox("Invalid input! System has found a record already existed with the same name.Try another value", MsgBoxStyle.Critical, "Already Existed!")
                    xTxtBox.Text = Trim(xActFeName)
                    xTxtBox.Focus()
                    xTxtBox.SelectAll()
                    Return True
                End If
            Else
                xTxtBox.BackColor = Color.Cyan
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Sub xTxtbox_BackColrChange(ByVal xTxtBox As TextBox)
        Try
            If Trim(xTxtBox.Text) <> "" Then
                xTxtBox.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xCmboBox_backColrChange(ByVal xCmbx As ComboBox)
        Try
            If Trim(xCmbx.Text) <> "" Then
                xCmbx.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCUndrGrup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCUndrGrup.SelectedIndexChanged
        Try
            xCmboBox_backColrChange(Me.CmbxCUndrGrup)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xChk_numericValidation(ByVal xNumTxt As TextBox)
        Try
            If Trim(xNumTxt.Text) <> "" Then
                If IsNumeric(xNumTxt.Text) = False Or Trim(xNumTxt.Text.EndsWith("-")) = True Or Trim(xNumTxt.Text.StartsWith("-")) = True Then
                    xNumTxt.Focus()
                    xNumTxt.SelectAll()
                    xNumTxt.BackColor = Color.Cyan
                Else
                    xNumTxt.BackColor = Color.White
                    'xNumTxt.Text = FormatNumber(xNumTxt.Text, 2)
                End If
            Else
                xNumTxt.BackColor = Color.White
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub TxtCopnbal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCopnbal.Leave
        Try
            If Len(Me.TxtCopnbal.Text.Trim) = 0 Then
                Me.TxtCopnbal.Text = 0
            End If
            xChk_numericValidation(Me.TxtCopnbal)
            Me.TxtCopnbal.Text = FormatNumber(Me.TxtCopnbal.Text, 2)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

   
    Private Sub txtBcrlmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBcrlmt.TextChanged

    End Sub

    Private Sub TxtCCrlmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCCrlmt.Leave
        Try
            xChk_numericValidation(Me.TxtCCrlmt)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub TxtCadrs1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCadrs1.TextChanged
        Try
            xTxtbox_BackColrChange(Me.TxtCadrs1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCcty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCcty.SelectedIndexChanged
        Try
            'If Me.CmbxCcty.SelectedIndex > 0 Then
            xCmboBox_backColrChange(Me.CmbxCcty)
            Select_State_Contry_where_id("Cscstatename", "CscContry", "Cscid", "finactcscmstr", Me.LblCstate, Me.LblCcontry, Me.CmbxCcty.SelectedValue)
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCsalagnt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCsalagnt.GotFocus
        Try
            If CmbxCsalagnt.Items.Count > 0 And CmbxCsalagnt.SelectedIndex = -1 Then
                CmbxCsalagnt.SelectedIndex = 0
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCIntstatus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCIntstatus.GotFocus
        Try
            xSetComboVal(Me.CmbxCIntstatus)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xSetComboVal(ByVal xCmbox As ComboBox)
        Try
            If xCmbox.SelectedIndex = -1 Then
                xCmbox.SelectedIndex = 1
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxCsrTx_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCsrTx.GotFocus, cmbxCost.GotFocus
        Try
            xSetComboVal(Me.CmbxCsrTx)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCinvtry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCinvtry.GotFocus
        Try
            xSetComboVal(Me.CmbxCinvtry)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxCVatRtn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxCVatRtn.GotFocus
        Try
            xSetComboVal(Me.cmbxCVatRtn)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxCFbtapp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxCFbtapp.GotFocus
        Try
            xSetComboVal(Me.cmbxCFbtapp)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NudDisdy_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudDisdy.ValueChanged

    End Sub

    Private Sub CmbxCIncType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCIncType.GotFocus
        Try
            xSetComboVal(Me.CmbxCIncType)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ActFeUpdate_CustomerActt()
        Try
            If Me.rbCdr.Checked = True Then
                BalType = Trim("Debit")
            ElseIf Me.rbcCr.Checked = True Then
                BalType = Trim("Credit")
            End If
            ActFE_Cmd = New SqlCommand("finact_splrmstr_CustAcct_update", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            ActFE_Cmd.Parameters.AddWithValue("@splrid", xSplrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrname", Trim(TxtCname.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrundrgrup", Me.CmbxCUndrGrup.SelectedValue)
            If Trim(Me.TxtCopnbal.Text) <> "" Then
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", CDbl(TxtCopnbal.Text))
            Else
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", 0)
            End If
            ActFE_Cmd.Parameters.AddWithValue("@splrbaltype", BalType)
            If Trim(Me.TxtCCrlmt.Text) <> "" Then
                ActFE_Cmd.Parameters.AddWithValue("@splrcrlmt", CDbl(Me.TxtCCrlmt.Text))
            Else
                ActFE_Cmd.Parameters.AddWithValue("@splrcrlmt", 0)
            End If
            ActFE_Cmd.Parameters.AddWithValue("@splrafectdt", Me.DtpCust.Value.Date)
            ActFE_Cmd.Parameters.AddWithValue("@splrSurfix", Me.CmbxCSrfix.Text)
            ActFE_Cmd.Parameters.AddWithValue("@splrrank", Me.NudCrnk.Value)
            ActFE_Cmd.Parameters.AddWithValue("@splrpan", Trim(Me.TxtCpan.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrvatno", Trim(Me.TxtCTinVat.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrcst", Trim(Me.TxtCCstno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrExciseno", Trim(Me.TxtCExcise.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrsrtx", Trim(Me.CmbxCsrTx.SelectedIndex))
            ActFE_Cmd.Parameters.AddWithValue("@splrInvntafect", Trim(Me.CmbxCinvtry.SelectedIndex))
            ActFE_Cmd.Parameters.AddWithValue("@splrcostafect", Me.cmbxCost.SelectedIndex)
            ActFE_Cmd.Parameters.AddWithValue("@splrIntcal", Trim(Me.CmbxCIntstatus.SelectedIndex))
            ActFE_Cmd.Parameters.AddWithValue("@splrFbtapp", Trim(Me.cmbxCFbtapp.SelectedIndex))
            ActFE_Cmd.Parameters.AddWithValue("@splrusedvat", Trim(Me.cmbxCVatRtn.SelectedIndex))
            ActFE_Cmd.Parameters.AddWithValue("@splrperofint", Trim(Me.TxtCroint.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrdiscom", Trim(Me.TxtCDisc.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrtarget", Trim(Me.TxtCtarget.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrincentype", Trim(Me.CmbxCIncType.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrincenval", Trim(Me.TxtIncVal.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrdisdays", Me.NudDisdy.Value)
            ActFE_Cmd.Parameters.AddWithValue("@splrnetday", Me.Nupntdys.Value)
            ActFE_Cmd.Parameters.AddWithValue("@splragntid", Me.CmbxCsalagnt.SelectedValue)
            ActFE_Cmd.Parameters.AddWithValue("@splrspcatid", Me.CmbxVATCST.SelectedValue)
            ActFE_Cmd.Parameters.AddWithValue("@splrcontname", Trim(Me.TxtCCntactPrsn.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtusrid", Current_UsrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtdt", Now)
            ActFE_Cmd.Parameters.AddWithValue("@splrcarriid", Me.CmbxCarrix.SelectedValue)
            '--adress-------------
            ActFE_Cmd.Parameters.AddWithValue("@adrs1", Trim(Me.TxtCadrs1.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrs2", Trim(Me.TxtCadrs2.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrs3", Trim(Me.TxtCadrs3.Text))
            ActFE_Cmd.Parameters.AddWithValue("adrsctyid", Me.CmbxCcty.SelectedValue)
            ActFE_Cmd.Parameters.AddWithValue("@adrspin", (Me.TxtCpin.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsphwork", Trim(Me.TxtCphno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsmoble", Trim(Me.txtCmobno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsemail", Trim(Me.TxtCemail.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsweb", Trim(Me.TxtCweb.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsEdtusrid", Current_UsrId)
            ActFE_Cmd.Parameters.AddWithValue("@adrsEdtdt", Now)

            ActFE_Cmd.ExecuteNonQuery()
            MsgBox("Current Record has been successfully Updated", MsgBoxStyle.Information, "Edit Record")
            Me.LstCust.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()

        End Try
    End Sub
    Private Sub ActFeUpdate_SalesagentActt()
        Try
            If Me.rbsldr.Checked = True Then
                BalType = Trim("Debit")
            ElseIf Me.rbslcr.Checked = True Then
                BalType = Trim("Credit")
            End If
            ActFE_Cmd = New SqlCommand("finact_splrmstr_SalesAgentAcct_update", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            ActFE_Cmd.Parameters.AddWithValue("@splrid", xSplrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrname", Trim(TxtSlname.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrundrgrup", Me.CmbxSlundrgrup.SelectedValue)
            If Trim(Me.txtslopnbal.Text) <> "" Then
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", (txtslopnbal.Text))
            Else
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", 0)
            End If
            ActFE_Cmd.Parameters.AddWithValue("@splrbaltype", BalType)
            If Trim(Me.TxtslCrlmt.Text) <> "" Then
                ActFE_Cmd.Parameters.AddWithValue("@splrcrlmt", Me.TxtslCrlmt.Text)
            Else
                ActFE_Cmd.Parameters.AddWithValue("@splrcrlmt", 0)
            End If

            ActFE_Cmd.Parameters.AddWithValue("@splrSurfix", Me.CmbxSlsrfix.Text)
            ActFE_Cmd.Parameters.AddWithValue("@splrpan", Trim(Me.txtslpan.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrdiscom", Trim(Me.Txtslcomm.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrtarget", Trim(Me.Txtsltrget.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrincentype", Trim(Me.cmbxsltype.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrincenval", Trim(Me.txtslincentive.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtusrid", Current_UsrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtdt", Now)
            '--adress-------------
            ActFE_Cmd.Parameters.AddWithValue("@adrs1", Trim(Me.txtsladrs1.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrs2", Trim(Me.txtsladrs2.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrs3", Trim(Me.txtsladrs3.Text))
            ActFE_Cmd.Parameters.AddWithValue("adrsctyid", Me.cmbxSlCty.SelectedValue)
            ActFE_Cmd.Parameters.AddWithValue("@adrspin", (Me.txtslpin.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsphwork", Trim(Me.txtslphno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsmoble", Trim(Me.txtslmobno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsemail", Trim(Me.txtslemail.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsweb", Trim(Me.txtslweb.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsEdtusrid", Current_UsrId)
            ActFE_Cmd.Parameters.AddWithValue("@adrsEdtdt", Now)

            ActFE_Cmd.ExecuteNonQuery()
            MsgBox("Current Record has been successfully Updated", MsgBoxStyle.Information, "Edit Record")
            Me.LstCust.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()

        End Try
    End Sub
    Private Sub ActFeUpdate_ShareActt()
        Try
            If Me.rbShdr.Checked = True Then
                BalType = Trim("Debit")
            ElseIf Me.rbshcr.Checked = True Then
                BalType = Trim("Credit")
            End If
            ActFE_Cmd = New SqlCommand("finact_splrmstr_ShareAcct_update", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            ActFE_Cmd.Parameters.AddWithValue("@splrid", xSplrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrname", Trim(txtShname.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrundrgrup", Me.cmbxshundrgrup.SelectedValue)
            If Trim(Me.txtshopnbal.Text) <> "" Then
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", (txtshopnbal.Text))
            Else
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", 0)
            End If
            ActFE_Cmd.Parameters.AddWithValue("@splrbaltype", BalType)
            

            ActFE_Cmd.Parameters.AddWithValue("@splrSurfix", Me.CmbxShSrfix.Text)
            ActFE_Cmd.Parameters.AddWithValue("@splrpan", Trim(Me.txtshpan.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtusrid", Current_UsrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtdt", Now)
            '--adress-------------
            ActFE_Cmd.Parameters.AddWithValue("@adrs1", Trim(Me.txtshadrs1.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrs2", Trim(Me.txtshadrs2.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrs3", Trim(Me.txtshadrs3.Text))
            ActFE_Cmd.Parameters.AddWithValue("adrsctyid", Me.cmbxshcty.SelectedValue)
            ActFE_Cmd.Parameters.AddWithValue("@adrspin", (Me.txtshpin.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsphwork", Trim(Me.txtshphno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsmoble", Trim(Me.txtshmobno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsemail", Trim(Me.txtshemailid.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsweb", Trim(Me.txtshweb.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsEdtusrid", Current_UsrId)
            ActFE_Cmd.Parameters.AddWithValue("@adrsEdtdt", Now)

            ActFE_Cmd.ExecuteNonQuery()
            MsgBox("Current Record has been successfully Updated", MsgBoxStyle.Information, "Edit Record")
            Me.LstCust.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()

        End Try
    End Sub
    Private Sub ActFeUpdate_VendorActt()
        Try
            If Me.rbVdr.Checked = True Then
                BalType = Trim("Debit")
            ElseIf Me.rbVcr.Checked = True Then
                BalType = Trim("Credit")
            End If
            ActFE_Cmd = New SqlCommand("finact_splrmstr_CustAcct_update", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            ActFE_Cmd.Parameters.AddWithValue("@splrid", xSplrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrname", Trim(TxtVname.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrundrgrup", Me.CmbxVUndrGrp.SelectedValue)
            If Trim(Me.TxtVopnbal.Text) <> "" Then
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", (TxtVopnbal.Text))
            Else
                ActFE_Cmd.Parameters.AddWithValue("@splropnbal", 0)
            End If
            ActFE_Cmd.Parameters.AddWithValue("@splrbaltype", BalType)
            If Trim(Me.txVcrlmt.Text) <> "" Then
                ActFE_Cmd.Parameters.AddWithValue("@splrcrlmt", Me.txVcrlmt.Text)
            Else
                ActFE_Cmd.Parameters.AddWithValue("@splrcrlmt", 0)
            End If
            ActFE_Cmd.Parameters.AddWithValue("@splrafectdt", Me.dTpVndr.Value.Date)
            ActFE_Cmd.Parameters.AddWithValue("@splrSurfix", Me.CmbxVSrfx.Text)
            ActFE_Cmd.Parameters.AddWithValue("@splrrank", Me.NudVrnk.Value)
            ActFE_Cmd.Parameters.AddWithValue("@splrpan", Trim(Me.txtVpan.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrvatno", Trim(Me.txtVVAtno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrcst", Trim(Me.txtVCstno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrExciseno", Trim(Me.TxtVexcise.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrsrtx", Trim(Me.CmbxVSrtx.SelectedIndex))
            ActFE_Cmd.Parameters.AddWithValue("@splrInvntafect", Trim(Me.CmbxVintry.SelectedIndex))
            ActFE_Cmd.Parameters.AddWithValue("@splrcostafect", Me.CmbxVcost.SelectedIndex)
            ActFE_Cmd.Parameters.AddWithValue("@splrIntcal", Trim(Me.CmbxVintstatus.SelectedIndex))
            ActFE_Cmd.Parameters.AddWithValue("@splrFbtapp", Trim(Me.CmbxVFbtapp.SelectedIndex))
            ActFE_Cmd.Parameters.AddWithValue("@splrusedvat", Trim(Me.CmbxVVatRtn.SelectedIndex))
            ActFE_Cmd.Parameters.AddWithValue("@splrperofint", Trim(Me.TxtVroint.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrdiscom", Trim(Me.TxtVdis.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrtarget", Trim(Me.txtVTrget.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrincentype", Trim(Me.CmbxVTrgttype.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrincenval", Trim(Me.TxtVTrgtrate.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrdisdays", Me.NudVdisdys.Value)
            ActFE_Cmd.Parameters.AddWithValue("@splrnetday", Me.Nupntdys.Value)
            ActFE_Cmd.Parameters.AddWithValue("@splragntid", 0) 'Me.CmbxCsalagnt.SelectedValue)
            ActFE_Cmd.Parameters.AddWithValue("@splrspcatid", Me.CmbxVVatCst.SelectedValue)
            ActFE_Cmd.Parameters.AddWithValue("@splrcontname", Trim(Me.TxtVCntactprsn.Text))
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtusrid", Current_UsrId)
            ActFE_Cmd.Parameters.AddWithValue("@splrEdtdt", Now)
            ActFE_Cmd.Parameters.AddWithValue("@splrcarriid", Me.CmbxVcarrix.SelectedValue)
            '--adress-------------
            ActFE_Cmd.Parameters.AddWithValue("@adrs1", Trim(Me.TxtAdrs1.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrs2", Trim(Me.TxtAdrs2.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrs3", Trim(Me.TxtAdrs3.Text))
            ActFE_Cmd.Parameters.AddWithValue("adrsctyid", Me.CmbxVcty.SelectedValue)
            ActFE_Cmd.Parameters.AddWithValue("@adrspin", (Me.txtVpin.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsphwork", Trim(Me.txtVphno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsmoble", Trim(Me.txtVmobno.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsemail", Trim(Me.txtVemail.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsweb", Trim(Me.txtVweb.Text))
            ActFE_Cmd.Parameters.AddWithValue("@adrsEdtusrid", Current_UsrId)
            ActFE_Cmd.Parameters.AddWithValue("@adrsEdtdt", Now)

            ActFE_Cmd.ExecuteNonQuery()
            MsgBox("Current Record has been successfully Updated", MsgBoxStyle.Information, "Edit Record")
            Me.lstvewvendr.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()

        End Try
    End Sub
    Private Sub TxtIncVal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lstvewvendr_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvewvendr.DoubleClick
        Try
            Me.lstvewvendr_Leave(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstvewvendr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvewvendr.GotFocus
        Try
            Me.TableLayoutPanel4.Enabled = False
            Me.BtnVupdate.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstvewvendr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstvewvendr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Try
                    Me.lstvewvendr_Leave(sender, e)
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstvewvendr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvewvendr.Leave
        Try
            Me.TableLayoutPanel4.Enabled = True
            Me.BtnVupdate.Enabled = True
            Me.TxtVname.Focus()
            Me.TxtVname.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstvewvendr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvewvendr.SelectedIndexChanged
        Try
            ActFE_Cmd = New SqlCommand("Finact_SplrMstr_EdtFind_Fillall_AsRequired", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            xSplrId = Me.lstvewvendr.SelectedItems(0).SubItems(1).Text
            SplrID_Editx = xSplrId
            ActFE_Cmd.Parameters.AddWithValue("@Condtnid", xSplrId)
            ActFE_Rdr = ActFE_Cmd.ExecuteReader
            While ActFE_Rdr.Read
                If ActFE_Rdr.IsDBNull(0) = False Then
                    Me.CmbxVSrfx.Text = ActFE_Rdr(31)
                    Me.TxtVname.Text = Trim(ActFE_Rdr(1))
                    Me.CmbxVUndrGrp.SelectedValue = ActFE_Rdr(2)
                    If ActFE_Rdr.IsDBNull(10) = False Then
                        Me.TxtVopnbal.Text = FormatNumber(ActFE_Rdr(10), 2)
                    Else
                        Me.TxtVopnbal.Text = 0.0
                    End If
                    Dim xBalType As String = Trim(ActFE_Rdr(11))
                    If Trim(xBalType) = "Credit" Then
                        Me.rbVcr.Checked = True
                    ElseIf Trim(xBalType) = "Debit" Then
                        Me.rbVdr.Checked = True
                    End If

                    If ActFE_Rdr.IsDBNull(4) = False Then
                        Me.txVcrlmt.Text = FormatNumber(ActFE_Rdr(4), 2)
                    Else
                        Me.txVcrlmt.Text = 0.0
                    End If

                    If ActFE_Rdr.IsDBNull(5) = False Then
                        Me.txtVpan.Text = Trim(ActFE_Rdr(5))
                    Else
                        Me.txtVpan.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(6) = False Then
                        Me.txtVVAtno.Text = Trim(ActFE_Rdr(6))
                    Else
                        Me.txtVVAtno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(7) = False Then
                        Me.txtVCstno.Text = Trim(ActFE_Rdr(7))
                    Else
                        Me.txtVCstno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(8) = False Then
                        Me.TxtVexcise.Text = Trim(ActFE_Rdr(8))
                    Else
                        Me.TxtVexcise.Text = ""
                    End If

                    If ActFE_Rdr.IsDBNull(9) = False Then
                        Me.NudVrnk.Value = Trim(ActFE_Rdr(9))
                    Else
                        Me.NudVrnk.Value = 0
                    End If
                    If ActFE_Rdr.IsDBNull(12) = False Then
                        If Trim(ActFE_Rdr(12)) = "False" Then
                            Me.CmbxVintry.Text = "No"
                        Else
                            Me.CmbxVintry.Text = "Yes"
                        End If
                    End If

                    If ActFE_Rdr.IsDBNull(14) = False Then
                        If Trim(ActFE_Rdr(14)) = "False" Then
                            Me.CmbxVintstatus.Text = "No"
                        Else
                            Me.CmbxVintstatus.Text = "Yes"
                        End If
                    End If


                    If ActFE_Rdr.IsDBNull(16) = False Then
                        If Trim(ActFE_Rdr(16)) = "False" Then
                            Me.CmbxVSrtx.Text = "No"
                        Else
                            Me.CmbxVSrtx.Text = "Yes"
                        End If
                    End If
                    If ActFE_Rdr.IsDBNull(17) = False Then
                        If Trim(ActFE_Rdr(17)) = "False" Then
                            Me.CmbxVFbtapp.Text = "No"
                        Else
                            Me.CmbxVFbtapp.Text = "Yes"
                        End If
                    End If
                    If ActFE_Rdr.IsDBNull(18) = False Then
                        If Trim(ActFE_Rdr(18)) = "False" Then
                            Me.CmbxVVatRtn.Text = "No"
                        Else
                            Me.CmbxVVatRtn.Text = "Yes"
                        End If
                    End If
                    If ActFE_Rdr.IsDBNull(19) = False Then
                        Me.TxtVroint.Text = Trim(ActFE_Rdr(19))
                    Else
                        Me.TxtVroint.Text = 0.0
                    End If

                    If ActFE_Rdr.IsDBNull(22) = False Then
                        Me.TxtVdis.Text = Trim(ActFE_Rdr(22))
                    Else
                        Me.TxtVdis.Text = 0.0
                    End If
                    If ActFE_Rdr.IsDBNull(23) = False Then
                        Me.txtVTrget.Text = Trim(ActFE_Rdr(23))
                    Else
                        Me.txtVTrget.Text = 0.0
                    End If
                    If ActFE_Rdr.IsDBNull(24) = False Then
                        Me.CmbxVTrgttype.Text = Trim(ActFE_Rdr(24))
                    Else
                        Me.CmbxVTrgttype.SelectedIndex = 0
                    End If
                    If ActFE_Rdr.IsDBNull(25) = False Then
                        Me.TxtVTrgtrate.Text = Trim(ActFE_Rdr(25))
                    End If
                    If ActFE_Rdr.IsDBNull(26) = False Then
                        Me.NudVdisdys.Value = Trim(ActFE_Rdr(26))
                    Else
                        Me.NudVdisdys.Value = 0
                    End If

                    If ActFE_Rdr.IsDBNull(27) = False Then
                        Me.Nudnetdys.Value = Trim(ActFE_Rdr(27))
                    Else
                        Me.Nudnetdys.Value = 0
                    End If

                    If ActFE_Rdr.IsDBNull(30) = False Then
                        Me.TxtVCntactprsn.Text = Trim(ActFE_Rdr(30))
                    Else
                        Me.TxtVCntactprsn.Text = ""
                    End If

                    If ActFE_Rdr.IsDBNull(33) = False Then
                        Me.CmbxVVatCst.SelectedValue = (ActFE_Rdr(33))
                    End If
                    If ActFE_Rdr.IsDBNull(42) = False Then
                        Me.CmbxVcarrix.SelectedValue = (ActFE_Rdr(42))
                    End If

                    If ActFE_Rdr.IsDBNull(49) = False Then
                        Me.txtsladrs1.Text = Trim(ActFE_Rdr(49))
                    Else
                        Me.txtsladrs1.Text = ""
                    End If

                    If ActFE_Rdr.IsDBNull(50) = False Then
                        Me.TxtAdrs2.Text = Trim(ActFE_Rdr(50))
                    Else
                        Me.TxtAdrs2.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(51) = False Then
                        Me.TxtAdrs3.Text = Trim(ActFE_Rdr(51))
                    Else
                        Me.TxtAdrs3.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(52) = False Then
                        Me.CmbxVcty.SelectedValue = Trim(ActFE_Rdr(52))
                    End If

                    If ActFE_Rdr.IsDBNull(53) = False Then
                        Me.txtVpin.Text = Trim(ActFE_Rdr(53))
                    Else
                        Me.txtVpin.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(54) = False Then
                        Me.txtVphno.Text = Trim(ActFE_Rdr(54))
                    Else
                        Me.txtVphno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(55) = False Then
                        Me.txtVmobno.Text = Trim(ActFE_Rdr(55))
                    Else
                        Me.txtVmobno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(56) = False Then
                        Me.txtVemail.Text = Trim(ActFE_Rdr(56))
                    Else
                        Me.txtVemail.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(57) = False Then
                        Me.txtVweb.Text = Trim(ActFE_Rdr(57))
                    Else
                        Me.txtVweb.Text = ""
                    End If

                End If
            End While
          
        Catch ex As Exception
            '  MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()
            ActFE_Rdr.Close()
            Opening_Bal_Hndler(Me.lblDiff, xOpnBalType)
        End Try
    End Sub

    Private Sub BtnVupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVupdate.Click
        Try
            ActFe_chkemptval_Vendor()
            If xActFeIndx <> 0 Then
                xActFeIndx = 0
                Exit Sub
            End If
            If Me.lstvewvendr.SelectedItems.Count > 0 Then
                ActFeUpdate_VendorActt()
            Else
                MsgBox("Invalid Input", MsgBoxStyle.Critical, "No Selected row found")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtVname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVname.GotFocus
        Try
            xActFeSrFix = Trim(Me.CmbxVSrfx.Text)
            xActFeName = Trim(Me.TxtVname.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtVname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVname.Leave
        Try
            If Validate_EditMode(Me.TxtVname) = True Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtVname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVname.TextChanged
        Try
            xTxtbox_BackColrChange(Me.TxtVname)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxVUndrGrp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxVUndrGrp.SelectedIndexChanged
        Try
            xCmboBox_backColrChange(Me.CmbxVUndrGrp)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtVopnbal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVopnbal.Leave
        Try
            xChk_numericValidation(Me.TxtVopnbal)
            If Len(Me.TxtVopnbal.Text.Trim) = 0 Then
                Me.TxtVopnbal.Text = 0
            End If
            Me.TxtVopnbal.Text = FormatNumber(Me.TxtVopnbal.Text, 2)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

   
    Private Sub txVcrlmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txVcrlmt.Leave
        Try
            xChk_numericValidation(Me.txVcrlmt)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try  
    End Sub

    Private Sub TxtAdrs1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAdrs1.TextChanged
        Try
            xTxtbox_BackColrChange(Me.TxtAdrs1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxVcty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxVcty.SelectedIndexChanged
        Try
            xCmboBox_backColrChange(Me.CmbxVcty)
            Select_State_Contry_where_id("Cscstatename", "CscContry", "Cscid", "finactcscmstr", Me.lblVstate, Me.lblvContry, Me.CmbxVcty.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtVTrget_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVTrget.Leave
        Try
            xChk_numericValidation(Me.txtVTrget)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub TxtVTrgtrate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVTrgtrate.Leave
        Try
            xChk_numericValidation(Me.TxtVTrgtrate)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub TxtCtarget_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCtarget.Leave
        Try
            xChk_numericValidation(Me.TxtCtarget)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub TxtIncVal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIncVal.Leave
        Try
            xChk_numericValidation(Me.TxtIncVal)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub LstVewGen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewGen.DoubleClick
        Try
            Me.LstVewGen_Leave(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewGen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewGen.GotFocus
        Try
            Me.TableLayoutPanel7.Enabled = False
            Me.BtnGupdate.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewGen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewGen.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Try
                    Me.LstVewGen_Leave(sender, e)
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LstVewGen_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewGen.Leave
        Try
            Me.TableLayoutPanel7.Enabled = True
            Me.BtnGupdate.Enabled = True
            Me.txtGname.Focus()
            Me.txtGname.SelectAll()
            If CInt(xDynamic_Find_xAnItem_xInA_Table_3INcond("splrid", "Finactsplrmstr", "splrid", "splrundrgrup", xSplrId, 11, 10, 19)) > 0 Then
                Me.CmbxGundrGrup.Enabled = False
            Else
                If Me.CmbxGundrGrup.Text.Trim = "TAX DEDUCTION AT SOURCE (TDS)" Or Me.CmbxGundrGrup.Text.Trim = "VALUE ADDED TAX (VAT INPUT)" Or Me.CmbxGundrGrup.Text.Trim = "CENTRAL SALES TAX (CST)" Or Me.CmbxGundrGrup.Text.Trim = "VALUE ADDED TAX (VAT OUTPUT)" Or Me.CmbxGundrGrup.Text.Trim = "CASH-IN-HAND" Then
                    Me.CmbxGundrGrup.Enabled = False
                Else
                    Me.CmbxGundrGrup.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewGen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewGen.SelectedIndexChanged
        Try
            ActFE_Cmd = New SqlCommand("Finact_SplrMstr_EdtFind_Fillall_AsRequired", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            xSplrId = Me.LstVewGen.SelectedItems(0).SubItems(1).Text
            ActFE_Cmd.Parameters.AddWithValue("@Condtnid", xSplrId)
            ActFE_Rdr = ActFE_Cmd.ExecuteReader
            While ActFE_Rdr.Read
                If ActFE_Rdr.IsDBNull(0) = False Then
                    Me.CmbxGsrfix.Text = ActFE_Rdr(31)
                    Me.txtGname.Text = Trim(ActFE_Rdr(1))
                    Me.CmbxGundrGrup.SelectedValue = ActFE_Rdr(2)
                   
                    If ActFE_Rdr.IsDBNull(10) = False Then
                        Me.TxtGopnBal.Text = FormatNumber(ActFE_Rdr(10), 2)
                    Else
                        Me.TxtGopnBal.Text = 0.0
                    End If
                    Dim xBalType As String = Trim(ActFE_Rdr(11))
                    If Trim(xBalType) = "Credit" Then
                        Me.rbGcr.Checked = True
                    ElseIf Trim(xBalType) = "Debit" Then
                        Me.rbGdr.Checked = True
                    End If
                End If


            End While
        Catch ex As Exception
            '  MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()
            ActFE_Rdr.Close()
            Opening_Bal_Hndler(Me.lblDiff, xOpnBalType)
        End Try
    End Sub

    Private Sub BtnGupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGupdate.Click
        Try
            ActFe_chkemptvalGen()
            If xActFeIndx <> 0 Then
                xActFeIndx = 0
                Exit Sub
            End If
            If Me.LstVewGen.SelectedItems.Count > 0 Then
                ActFeUpdate_GeneralActt()
            Else
                MsgBox("Invalid input!", MsgBoxStyle.Critical, "No selected row found")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnGexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGexit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtGname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGname.GotFocus
        Try
            xActFeSrFix = Trim(Me.CmbxGsrfix.Text)
            xActFeName = Trim(Me.txtGname.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtGname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGname.Leave
        Try
            xTxtbox_BackColrChange(Me.txtGname)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtGname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGname.TextChanged
        Try
            xTxtbox_BackColrChange(Me.txtGname)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CmbxGundrGrup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxGundrGrup.SelectedIndexChanged
        Try
            xCmboBox_backColrChange(Me.CmbxGundrGrup)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TxtGopnBal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGopnBal.Leave
        Try
            xChk_numericValidation(Me.TxtGopnBal)
            If Len(Me.TxtGopnBal.Text.Trim) = 0 Then
                Me.TxtGopnBal.Text = 0
            End If
            Me.TxtGopnBal.Text = FormatNumber(Me.TxtGopnBal.Text, 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub lstVewSl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVewSl.DoubleClick
        Try
            Me.Lstvewsl_Leave(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstVewSl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVewSl.GotFocus
        Try
            Me.TableLayoutPanel6.Enabled = False
            Me.Btnslupdate.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstVewSl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstVewSl.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Try
                    Me.lstVewSl_Leave(sender, e)
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstVewSl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVewSl.Leave
        Try
            Me.TableLayoutPanel6.Enabled = True
            Me.Btnslupdate.Enabled = True
            Me.TxtSlname.Focus()
            Me.TxtSlname.SelectAll()
            If Me.lstVewSl.SelectedItems.Item(0).Index = 0 Then
                xFillCntrlswithSelRecds()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstVewSl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVewSl.SelectedIndexChanged
        Try

            xFillCntrlswithSelRecds()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub xFillCntrlswithSelRecds()
        Try
            ActFE_Cmd = New SqlCommand("Finact_SplrMstr_EdtFind_Fillall_AsRequired", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            xSplrId = Me.lstVewSl.SelectedItems(0).SubItems(1).Text
            ActFE_Cmd.Parameters.AddWithValue("@Condtnid", xSplrId)
            ActFE_Rdr = ActFE_Cmd.ExecuteReader
            While ActFE_Rdr.Read
                If ActFE_Rdr.IsDBNull(0) = False Then
                    Me.CmbxSlsrfix.Text = ActFE_Rdr(31)
                    Me.TxtSlname.Text = Trim(ActFE_Rdr(1))
                    Me.CmbxSlundrgrup.SelectedValue = ActFE_Rdr(2)
                    If ActFE_Rdr.IsDBNull(10) = False Then
                        Me.txtslopnbal.Text = FormatNumber(ActFE_Rdr(10), 2)
                    Else
                        Me.txtslopnbal.Text = 0.0
                    End If
                    Dim xBalType As String = Trim(ActFE_Rdr(11))
                    If Trim(xBalType) = "Credit" Then
                        Me.rbslcr.Checked = True
                    ElseIf Trim(xBalType) = "Debit" Then
                        Me.rbsldr.Checked = True
                    End If

                    If ActFE_Rdr.IsDBNull(4) = False Then
                        Me.TxtslCrlmt.Text = FormatNumber(ActFE_Rdr(4), 2)
                    Else
                        Me.TxtslCrlmt.Text = 0.0
                    End If

                    If ActFE_Rdr.IsDBNull(5) = False Then
                        Me.txtslpan.Text = Trim(ActFE_Rdr(5))
                    Else
                        Me.txtslpan.Text = ""
                    End If

                    If ActFE_Rdr.IsDBNull(22) = False Then
                        Me.Txtslcomm.Text = Trim(ActFE_Rdr(22))
                    Else
                        Me.Txtslcomm.Text = 0.0
                    End If

                    If ActFE_Rdr.IsDBNull(23) = False Then
                        Me.Txtsltrget.Text = Trim(ActFE_Rdr(23))
                    Else
                        Me.Txtsltrget.Text = 0.0
                    End If

                    If ActFE_Rdr.IsDBNull(24) = False Then
                        Me.cmbxsltype.Text = Trim(ActFE_Rdr(24))
                        If Trim(cmbxsltype.Text) = "" Then
                            Me.cmbxsltype.SelectedIndex = 0
                        End If
                    Else
                        Me.cmbxsltype.SelectedIndex = 0
                    End If

                    If ActFE_Rdr.IsDBNull(25) = False Then
                        Me.txtslincentive.Text = Trim(ActFE_Rdr(25))
                    Else
                        Me.txtslincentive.Text = 0.0
                    End If


                    If ActFE_Rdr.IsDBNull(49) = False Then
                        Me.txtsladrs1.Text = Trim(ActFE_Rdr(49))
                    Else
                        Me.txtsladrs1.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(50) = False Then
                        Me.txtsladrs2.Text = Trim(ActFE_Rdr(50))
                    Else
                        Me.txtsladrs2.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(51) = False Then
                        Me.txtsladrs3.Text = Trim(ActFE_Rdr(51))
                    Else
                        Me.txtsladrs3.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(52) = False Then
                        Me.cmbxSlCty.SelectedValue = Trim(ActFE_Rdr(52))
                    End If

                    If ActFE_Rdr.IsDBNull(53) = False Then
                        Me.txtslpin.Text = Trim(ActFE_Rdr(53))
                    Else
                        Me.txtslpin.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(54) = False Then
                        Me.txtslphno.Text = Trim(ActFE_Rdr(54))
                    Else
                        Me.txtslphno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(55) = False Then
                        Me.txtslmobno.Text = Trim(ActFE_Rdr(55))
                    Else
                        Me.txtslmobno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(56) = False Then
                        Me.txtslemail.Text = Trim(ActFE_Rdr(56))
                    Else
                        Me.txtslemail.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(57) = False Then
                        Me.txtslweb.Text = Trim(ActFE_Rdr(57))
                    Else
                        Me.txtslweb.Text = ""
                    End If

                End If
            End While
        Catch ex As Exception
            '  MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()
            ActFE_Rdr.Close()
            Opening_Bal_Hndler(Me.lblsldiff, xOpnBalType)
        End Try

    End Sub
    Private Sub Btnslupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnslupdate.Click
        Try
            ActFe_chkemptval_SaleAgent()
            If xActFeIndx <> 0 Then
                xActFeIndx = 0
                Exit Sub
            End If
            If Me.lstVewSl.SelectedItems.Count > 0 Then
                ActFeUpdate_SalesagentActt()
            Else
                MsgBox("Invlid input", MsgBoxStyle.Critical, "No Selected row found")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSlname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSlname.GotFocus
        Try
            xActFeSrFix = Trim(Me.CmbxSlsrfix.Text)
            xActFeName = Trim(Me.TxtSlname.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSlname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSlname.Leave

        Try
            If Validate_EditMode(Me.TxtSlname) = True Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSlname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSlname.TextChanged
        Try
            xTxtbox_BackColrChange(Me.TxtSlname)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSlundrgrup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSlundrgrup.SelectedIndexChanged
        Try
            xCmboBox_backColrChange(Me.CmbxSlundrgrup)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCopnbal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCopnbal.TextChanged

    End Sub

    Private Sub txtslopnbal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtslopnbal.Leave
        Try
            xChk_numericValidation(Me.txtslopnbal)
            If Len(Me.txtslopnbal.Text.Trim) = 0 Then
                Me.txtslopnbal.Text = 0
            End If
            Me.txtslopnbal.Text = FormatNumber(Me.txtslopnbal.Text, 2)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Txtsltrget_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtsltrget.Leave
        Try
            xChk_numericValidation(Me.Txtsltrget)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub txtslincentive_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtslincentive.Leave
        Try
            xChk_numericValidation(Me.txtslincentive)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub cmbxSlCty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxSlCty.SelectedIndexChanged
        Try
            xCmboBox_backColrChange(Me.cmbxSlCty)
            Select_State_Contry_where_id("Cscstatename", "CscContry", "Cscid", "finactcscmstr", Me.lblslstate, Me.lblslcontry, Me.cmbxSlCty.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtslCrlmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtslCrlmt.Leave
        Try
            xChk_numericValidation(Me.TxtslCrlmt)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Txtslcomm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtslcomm.Leave
        Try
            xChk_numericValidation(Me.Txtslcomm)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Txtslcomm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtslcomm.TextChanged

    End Sub

    Private Sub txtshopnbal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtshopnbal.Leave
        Try
            xChk_numericValidation(Me.txtshopnbal)
            If Len(Me.txtshopnbal.Text.Trim) = 0 Then
                Me.txtshopnbal.Text = 0
            End If
            Me.txtshopnbal.Text = FormatNumber(Me.txtshopnbal.Text, 2)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub txtshopnbal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtshopnbal.TextChanged

    End Sub

    Private Sub txtShname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShname.GotFocus
        Try
            xActFeSrFix = Trim(Me.CmbxShSrfix.Text)
            xActFeName = Trim(Me.txtShname.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtShname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShname.Leave
        Try
            If Validate_EditMode(Me.txtShname) = True Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtShname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShname.TextChanged
        Try
            xTxtbox_BackColrChange(Me.txtShname)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxshundrgrup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxshundrgrup.SelectedIndexChanged
        Try
            xCmboBox_backColrChange(Me.cmbxshundrgrup)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Lstvewshare_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lstvewshare.DoubleClick
        Try
            Me.lstVewShare_Leave(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Lstvewshare_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lstvewshare.GotFocus
        Try
            Me.TableLayoutPanel5.Enabled = False
            Me.btnShupdate.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Lstvewshare_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Lstvewshare.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Try
                    Me.Lstvewshare_Leave(sender, e)
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Lstvewshare_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lstvewshare.Leave
        Try
            Me.TableLayoutPanel5.Enabled = True
            Me.btnShupdate.Enabled = True
            Me.txtShname.Focus()
            Me.txtShname.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Lstvewshare_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lstvewshare.SelectedIndexChanged
        Try
            ActFE_Cmd = New SqlCommand("Finact_SplrMstr_EdtFind_Fillall_AsRequired", FinActConn)
            ActFE_Cmd.CommandType = CommandType.StoredProcedure
            xSplrId = Me.Lstvewshare.SelectedItems(0).SubItems(1).Text
            ActFE_Cmd.Parameters.AddWithValue("@Condtnid", xSplrId)
            ActFE_Rdr = ActFE_Cmd.ExecuteReader
            While ActFE_Rdr.Read
                If ActFE_Rdr.IsDBNull(0) = False Then
                    Me.CmbxSlsrfix.Text = ActFE_Rdr(31)
                    Me.txtShname.Text = Trim(ActFE_Rdr(1))
                    Me.cmbxshundrgrup.SelectedValue = ActFE_Rdr(2)
                    If ActFE_Rdr.IsDBNull(10) = False Then
                        Me.txtshopnbal.Text = FormatNumber(ActFE_Rdr(10), 2)
                    Else
                        Me.txtshopnbal.Text = 0.0
                    End If
                    Dim xBalType As String = Trim(ActFE_Rdr(11))
                    If Trim(xBalType) = "Credit" Then
                        Me.rbshcr.Checked = True
                    ElseIf Trim(xBalType) = "Debit" Then
                        Me.rbShdr.Checked = True
                    End If


                    If ActFE_Rdr.IsDBNull(5) = False Then
                        Me.txtshpan.Text = Trim(ActFE_Rdr(5))
                    Else
                        Me.txtshpan.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(20) = False Then
                        Dim Cos As String = Trim(ActFE_Rdr(20))
                        If Cos = "Proprietor" Then
                            Me.nudShare.Enabled = False
                        Else
                            Me.nudShare.Enabled = True
                        End If
                    End If
                    If ActFE_Rdr.IsDBNull(21) = False Then
                        Me.nudShare.Value = Trim(ActFE_Rdr(21))
                        CurrRatio = Trim(ActFE_Rdr(21))
                    End If

                    'If ActFE_Rdr.IsDBNull(21) = False Then
                    '    Me.nudShare.Value = Trim(ActFE_Rdr(21))
                    'End If




                    If ActFE_Rdr.IsDBNull(49) = False Then
                        Me.txtsladrs1.Text = Trim(ActFE_Rdr(49))
                    Else
                        Me.txtsladrs1.Text = ""
                    End If

                    If ActFE_Rdr.IsDBNull(50) = False Then
                        Me.txtshadrs2.Text = Trim(ActFE_Rdr(50))
                    Else
                        Me.txtshadrs2.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(51) = False Then
                        Me.txtshadrs3.Text = Trim(ActFE_Rdr(51))
                    Else
                        Me.txtshadrs3.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(52) = False Then
                        Me.cmbxshcty.SelectedValue = Trim(ActFE_Rdr(52))
                    End If

                    If ActFE_Rdr.IsDBNull(53) = False Then
                        Me.txtshpin.Text = Trim(ActFE_Rdr(53))
                    Else
                        Me.txtshpin.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(54) = False Then
                        Me.txtshphno.Text = Trim(ActFE_Rdr(54))
                    Else
                        Me.txtshphno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(55) = False Then
                        Me.txtshmobno.Text = Trim(ActFE_Rdr(55))
                    Else
                        Me.txtshmobno.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(56) = False Then
                        Me.txtshemailid.Text = Trim(ActFE_Rdr(56))
                    Else
                        Me.txtshemailid.Text = ""
                    End If
                    If ActFE_Rdr.IsDBNull(57) = False Then
                        Me.txtshweb.Text = Trim(ActFE_Rdr(57))
                    Else
                        Me.txtshweb.Text = ""
                    End If

                End If
            End While
        Catch ex As Exception
            '  MsgBox(ex.Message)
        Finally
            ActFE_Cmd.Dispose()
            ActFE_Rdr.Close()
            Opening_Bal_Hndler(Me.lblshdiff, xOpnBalType)
        End Try

    End Sub

    Private Sub btnShupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShupdate.Click
        Try
            ActFe_chkemptval_Share()
            If xActFeIndx <> 0 Then
                xActFeIndx = 0
                Exit Sub
            End If
            If Me.Lstvewshare.SelectedItems.Count > 0 Then
                ActFeUpdate_ShareActt()
            Else
                MsgBox("Invlid input", MsgBoxStyle.Critical, "No Selected row found")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnshexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshexit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxshcty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxshcty.SelectedIndexChanged
        Try
            xCmboBox_backColrChange(Me.cmbxshcty)
            Select_State_Contry_where_id("Cscstatename", "CscContry", "Cscid", "finactcscmstr", Me.lblshstate, Me.lblshcontry, Me.cmbxshcty.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Chk_ProfitShareRatio()
        Try
            SharRatio = 0
            ActFE_Cmd1 = New SqlCommand("Select splrcapshare,splrcostatus from finactsplrmstr where splrcapshare>0 ", FinActConn1)
            ActFE_Rdr = ActFE_Cmd1.ExecuteReader
            While ActFE_Rdr.Read
                If ActFE_Rdr.HasRows = True Then
                    If ActFE_Rdr.IsDBNull(0) = False Then
                        SharRatio += ActFE_Rdr(0)
                        CoStatus = ActFE_Rdr(1).ToString()
                    End If

                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ActFE_Cmd1.Dispose()
            ActFE_Rdr.Close()
        End Try
    End Sub

    Private Sub nudShare_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudShare.Leave
        Chk_ProfitShareRatio()
        If Val(lblshare.Text) > 0 Then
            Dim CurSharRatio As Double = (SharRatio - CurrRatio) + CDbl(lblshare.Text) - 1
            If CurSharRatio > 100 Then

                MsgBox("Invalid input! Profit share is exceeded than 100 ", MsgBoxStyle.Critical)
                Me.nudShare.Focus()
            End If
        End If

    End Sub

    Private Sub nudShare_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudShare.ValueChanged
        Try
            Me.lblshare.Text = FormatNumber(Me.nudShare.Value, 4)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnVexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVexit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnslexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnslexit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnVdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVdetails.Click
        Try
            FrmShow_flag(14) = True
            SplrStatus4Shp = True
            FrmShow_flag(17) = True
            Dim frmVCont As New FrmShipConts
            frmVCont.ShowInTaskbar = False
            frmVCont.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCdetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCdetail.Click
        Try
            FrmShow_flag(14) = True
            FrmShow_flag(17) = True
            Dim frmcCont As New FrmShipConts
            frmcCont.ShowInTaskbar = False
            frmcCont.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCDelAdrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCDelAdrs.Click
        Try
            FrmShow_flag(15) = True
            FrmShow_flag(18) = True
            SplrStatus4Shp = True
            Dim frmcShpadrs As New FrmShipadrs
            frmcShpadrs.ShowInTaskbar = False
            frmcShpadrs.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnVAtchitm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVAtchitm.Click
        Try
            'FrmShow_flag(14) = True
            'SplrStatus4Shp = True
            'FrmShow_flag(17) = True
            Dim frmVaitmedt As New FrmAttachItemAlter
            frmVaitmedt.ShowInTaskbar = False
            frmVaitmedt.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub BtnCAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCAttach.Click
        Try
            Dim frmVaitmedt As New FrmAttachItemAlter
            frmVaitmedt.ShowInTaskbar = False
            frmVaitmedt.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CmbxVVatCst_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxVVatCst.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Btnbnkupdate.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtshweb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtshweb.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.btnShupdate.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtslweb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtslweb.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Btnslupdate.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbxcarrix_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCarrix.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Btncutupdate.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtbweb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbweb.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Btnbnkupdate.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtbweb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbweb.TextChanged

    End Sub

    Private Sub rbGdr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rbGdr.KeyDown, rbGcr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.BtnGupdate.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxFltr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxFltr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxFltr_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFltr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxFltr.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxFltr) = False Then
                Me.CmbxFltr.Focus()
                Me.CmbxFltr.BackColor = Color.Cyan
                Exit Sub
            Else
                Me.CmbxFltr.BackColor = Color.White
                Me.LstCust.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFltr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxFltr.SelectedIndexChanged
        Try
            If Me.CmbxFltr.SelectedIndex > 0 Then
                Me.LstCust.Items.Clear()
                Fill_ListView_SelectedGrup("Customer", Me.CmbxFltr.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxCVatRtn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxCVatRtn.Leave
        Try
            If Me.cmbxCVatRtn.SelectedIndex = 1 Then
                Me.TxtCTinVat.Text = "UN-REGD"
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub txtVat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCTinVat.Leave
        Try
            If Me.cmbxCVatRtn.SelectedIndex = 1 Then
                If Len(Me.TxtCTinVat.Text.Trim) = 0 Or Len(Me.TxtCTinVat.Text.Trim) <> 11 Then
                    MsgBox("Invalid Input! Valid VAT/CST NO. Required.", MsgBoxStyle.Critical, Me.Text)
                    Me.TxtCTinVat.Focus()
                End If
            Else
                Me.TxtCTinVat.Text = "UN-REGD"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCCstno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCCstno.Leave
        Try
            If Me.cmbxCVatRtn.SelectedIndex = 1 Then
                If Len(Me.TxtCCstno.Text.Trim) = 0 Or Len(Me.TxtCCstno.Text.Trim) <> 11 Then
                    MsgBox("Invalid Input! Valid VAT/CST NO. Required.", MsgBoxStyle.Critical, Me.Text)
                    Me.TxtCCstno.Focus()
                End If
            Else
                Me.TxtCCstno.Text = "UN-REGD"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCCstno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCCstno.TextChanged
        Try
            Me.TxtCTinVat.Text = Me.TxtCCstno.Text.Trim
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxVVatRtn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxVVatRtn.Leave
        Try
            If Me.CmbxVVatRtn.SelectedIndex = 1 Then
                Me.txtVVAtno.Text = "UN-REGD"
                Me.txtVCstno.Text = "UN-REGD"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtVCstno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVCstno.Leave
        Try
            If Me.CmbxVVatRtn.SelectedIndex = 1 Then
                If Len(Me.txtVCstno.Text.Trim) = 0 Or Len(Me.txtVCstno.Text.Trim) <> 11 Then
                    MsgBox("Invalid Input! Valid VAT/CST NO. Required.", MsgBoxStyle.Critical, Me.Text)
                    Me.txtVCstno.Focus()
                End If
            Else
                Me.txtVCstno.Text = "UN-REGD"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtVVAtno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVVAtno.Leave
        Try
            If Me.CmbxVVatRtn.SelectedIndex = 1 Then
                If Len(Me.txtVVAtno.Text.Trim) = 0 Or Len(Me.txtVVAtno.Text.Trim) <> 11 Then
                    MsgBox("Invalid Input! Valid VAT/CST NO. Required.", MsgBoxStyle.Critical, Me.Text)
                    Me.txtVVAtno.Focus()
                End If
            Else
                Me.txtVVAtno.Text = "UN-REGD"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtVCstno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVCstno.TextChanged
        Try
            Me.txtVVAtno.Text = Me.txtVCstno.Text.Trim
        Catch ex As Exception

        End Try
    End Sub
End Class
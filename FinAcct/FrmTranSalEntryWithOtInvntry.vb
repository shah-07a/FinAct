Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmTranSalEntryWithOtInvntry
    Dim TpoCmd As SqlCommand
    Dim TpoRdr As SqlDataReader
    Dim TpoAdptr As SqlDataAdapter
    Dim TpoCmd1 As SqlCommand
    Dim TpoRdr1 As SqlDataReader
    Dim TpoDtSet As DataSet
    Dim CurIndx As Integer
    Dim Nrow As DataGridViewRow
    Dim SplrId As Integer = 0
    Dim MaxSplid As Integer = 0
    Dim SetCur_Dupli_vali As Boolean
    Dim DefltVatCst As Integer
    Dim ErrIndx, SpCid As Integer
    Dim DisVal As Double
    Dim Alrdy_Ordr As Double
    Dim xExl_MxDt As Date
    Dim SaveFlag As Boolean = False
    Dim xRondOff As Double = 0
    Dim xSumOfField As Double = 0

    Private Sub FrmTranSaleOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New System.Drawing.Point(948, 650)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.ChkBx1.Checked = False
            Me.SplitContainer1.SplitterDistance = 580
            Me.Top = 0
            Me.Left = 0
            Select_2rec_with_where(Me.CmbxWareh, SplrId)
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)

            Dim cond As String = "Sale"
            Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", Cmbxspcatid, cond, "SPCATDELSTATUS", CInt(1))
            Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxCust, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Customer", "Customer", 1)
            Dim cond1 As String = "Sales Agent"
            Select_2rec_where("splrid", "splrname", "splrtype", "Finactsplrmstr", CmbxAgent, cond1, "SPLRDELSTATUS", CInt(1))
            If Not Me.CmbxAgent.Items.Count > 0 Then
                MsgBox("Invalid Input! Sales Agent Required", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRUNDRGRUP", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), CInt(10), Me.CmbxStokGrup)
            If xWrkContrctSale_Flag = True Then
                xCOINFO_WRKCONTRCT()
                Me.RbAdnl1.Visible = False
                Me.RbAdnl2.Visible = False
                Me.MskAdlDis.Text = FormatNumber(xWrkContRate1, 2)
                Me.LblLbrDis.Text = "Labour Charges"
                ToolStripMenuItem3.Enabled = True
                If xDynamic_COUNT_xAnItem_xInA_Table_1cond("Saleentid", "SaleentBILLtype", "JBWRK", "FinactSaleentry") > 0 Then
                    Me.BtnFind.Enabled = True
                Else
                    Me.BtnFind.Enabled = False
                End If
                Me.Text = "Sale Billing (Job/Work-Contract)" & "  (CURRENT USER NAME:- " & Trim(Current_UserName) & ",DESIGNATION:- " & Trim(Current_UserDesi)
                Me.Label42txabl.Text = " + Taxable Amt."
            Else
                If xDynamic_COUNT_xAnItem_xInA_Table_1cond("Purentid", "PurentBILLtype", "NOINV", "FinactPurentry") > 0 Then
                    Me.BtnFind.Enabled = True
                Else
                    Me.BtnFind.Enabled = False
                End If
                ToolStripMenuItem3.Enabled = False
                Me.LblLbrDis.Text = "Less Adnl. Dis.:"
                Me.RbAdnl1.Visible = True
                Me.RbAdnl2.Visible = True
                Me.Text = "Sale Billing (Without Inventory)" & "  (CURRENT USER NAME:- " & Trim(Current_UserName) & ",DESIGNATION:- " & Trim(Current_UserDesi)
                Me.Label42txabl.Text = " = Taxable Amt."
            End If
            'Dim CurOrderNo As Integer = Curr_MaxId()
            'Me.TxtSaleBillNo.Text = (CurOrderNo + 1)
            'If Curr_MaxId() > 0 Then
            '    Me.dtpordrdt.MinDate = Curr_Maxdate()
            'Else
            Me.dtpordrdt.MinDate = FinStartDt.Date
            ' End If
            Me.dtpordrdt.MaxDate = FinEnddt.Date
            Cmbxstatus.SelectedIndex = 1
            CreateGridColumns()
            If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                Me.ChkVatInfo.Visible = True
                Me.ChkVatInfo.Enabled = True
            Else
                Me.ChkVatInfo.Visible = False
                Me.ChkVatInfo.Enabled = False
            End If
            Me.Panel5.Enabled = True
            Me.dtpordrdt.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub




    Private Sub BtnAddCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCust.Click
        Try
            FrmShow_flag(5) = True
            xCall_LinkFrm(FrmActMstr, Me.CmbxCust)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnaddware_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnaddware.Click
        Dim frmW As New FrmInLocat
        frmW.ShowInTaskbar = False
        FrmShow_flag(6) = True
        frmW.ShowDialog()
    End Sub

    Private Sub Btnaddware_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnaddware.GotFocus
        If FrmShow_flag(6) = True Then
            CmbxWareh.Focus()
        End If
    End Sub

    Private Sub CmbxWareh_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWareh.GotFocus
        If FrmShow_flag(6) = True Then
            Select_2rec_with_where(Me.CmbxWareh, SplrId)
            Dim IntW As Integer = CmbxWareh.FindString(IntHtCmMm(6), 0)
            CmbxWareh.SelectedIndex = IntW
        Else
            Select_2rec_with_where(Me.CmbxWareh, SplrId)
            If CmbxWareh.Items.Count > 0 And CmbxWareh.SelectedIndex = -1 Then
                CmbxWareh.SelectedIndex = 0
            End If
        End If
    End Sub
    Private Sub CmbxWareh_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWareh.Leave
        If FrmShow_flag(6) = True Then
            FrmShow_flag(6) = False

        End If
        ' Me.CmbxCarri.Focus()
    End Sub

    Private Sub BtnAddCarri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCarri.Click
        Dim frmcari As New FrmCarriermstr
        frmcari.ShowInTaskbar = False
        FrmShow_flag(7) = True
        frmcari.ShowDialog()
    End Sub

    Private Sub BtnAddCarri_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddCarri.GotFocus
        If FrmShow_flag(7) = True Then
            Me.CmbxCarri.Focus()
        End If
    End Sub

    Private Sub CmbxCarri_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.GotFocus
        'CmbxCarri.DroppedDown = True
        If FrmShow_flag(7) = True Then
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)
            Dim IntCari As Integer = CmbxCarri.FindString(IntHtCmMm(7), 0)
            CmbxCarri.SelectedIndex = IntCari
        Else
            If CmbxCarri.Items.Count > 0 And CmbxCarri.SelectedIndex = -1 Then
                CmbxCarri.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub CmbxCarri_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.Leave
        If FrmShow_flag(7) = True Then
            FrmShow_flag(7) = False
        End If
    End Sub

    Private Sub Cmbxstatus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxstatus.GotFocus
        Try
            If Cmbxstatus.Items.Count > 0 And Cmbxstatus.SelectedIndex = -1 Then
                Cmbxstatus.SelectedIndex = 2
            End If
            Me.Cmbxstatus.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dtpreqstdt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpSaleDue.ValueChanged
        Me.DtpSaleDue.MinDate = dtpordrdt.Value.Date
    End Sub

    Private Sub MskAdlDis_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MskAdlDis.GotFocus
        Try
            Me.MskAdlDis.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Mtxtdisvalue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mtxtdisvalue.GotFocus
        Try
            Me.Mtxtdisvalue.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSaleBillNo_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSaleBillNo.HandleCreated

    End Sub


    Private Sub allControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkbCariDetals.KeyDown, Chkbdisc.KeyDown _
    , ChkbOthrCharg.KeyDown, ChkVatInfo.KeyDown, CmbxCarri.KeyDown, Cmbxdistype.KeyDown, CmbxWareh.KeyDown, Dtpgrdt.KeyDown, DtpInvvatdt.KeyDown, dtpordrdt.KeyDown, DtpSaleDue.KeyDown, MskInscharg.KeyDown, MskInvamt.KeyDown, MskinvVat.KeyDown _
    , Mskothrchrg.KeyDown, MskPostcharg.KeyDown, mskTxtVAtCst.KeyDown, TxtCariNo.KeyDown _
    , Txtgrno.KeyDown, TxtPlcyno.KeyDown, TxtPvtMrk.KeyDown, TxtSaleBillNo.KeyDown, TxtGrsWt.KeyDown _
    , TxtVatinvno.KeyDown, RbSbill1.KeyDown, RbSbill2.KeyDown, Mtxtdisvalue.KeyDown, MtxtfrtChargs.KeyDown, MtxtPkgcharg.KeyDown, MTxtTotlamt.KeyDown, mtxtulcharg.KeyDown, MskAdlDis.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtpordrdt_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpordrdt.ValueChanged
        Try
            Me.DtpSaleDue.MinDate = Me.dtpordrdt.Value
            Me.DtpInvvatdt.MinDate = Me.dtpordrdt.Value
            Me.DtpInvvatdt.MaxDate = Me.dtpordrdt.MaxDate
        Catch ex As Exception

        End Try
    End Sub

    Private Function validate_input() As Boolean
        Try
            If Me.DgSaleDirect.CurrentRow.Cells(CurIndx).Value = Nothing Then
                Me.DgSaleDirect.CurrentRow.Cells(CurIndx).ErrorText = "Empty not allowed"
                Return True
            Else
                Me.DgSaleDirect.CurrentRow.Cells(CurIndx).ErrorText = ""
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Function


    Private Sub BtnO_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSe_exit.Click
        Me.Close()
    End Sub

    Private Sub BtnPe_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSe_Save.Click
        Try
            If Me.CmbxStokGrup.SelectedIndex = -1 Then
                MsgBox("Invalid Input! control having no value not allowed.", MsgBoxStyle.Critical, Me.Text)
                Me.CmbxStokGrup.Focus()
                Exit Sub
            End If
            If Me.SaveFlag = False Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

            If Chk_zeroQnty() = True Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, "Zero Qnty.")
                Exit Sub
            End If

            Dim val1, val2, val3 As Double
            val1 = FormatNumber(Me.MTxtTotlamt.Text, 2)
            val2 = FormatNumber(Me.lblgross.Text, 2)
            val3 = FormatNumber(xRondOff, 2)
            If FormatNumber(val1, 2) <> FormatNumber(val2 + val3, 2) Then
                MsgBox("Invoice amount does not match with Gross Amount", MsgBoxStyle.Critical, "Check Invoice Amount...")
                Me.DgSaleDirect.Focus()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure to save this record", "Salechase Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                BtnSe_Save.Focus()
                Return
            Else
                SaleEntrySave()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub SaleEntrySave()
        If Me.DgSaleDirect.Rows.Count > 0 Then
            Try
                TpoCmd = New SqlCommand("Finact_Saleentry_Insert", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@Saleentdt", (Me.dtpordrdt.Value.Date))
                TpoCmd.Parameters.AddWithValue("@Salebilstatus", Trim(Me.Cmbxstatus.Text))
                Me.TxtSaleBillNo.Text = xFetchVno_AccordingVATBillType(SplrId, CInt(Me.Cmbxspcatid.SelectedValue), Me.dtpordrdt)
                TpoCmd.Parameters.AddWithValue("@Saleentvno", Trim(TxtSaleBillNo.Text))

                TpoCmd.Parameters.AddWithValue("@Saleentduedt", Me.DtpSaleDue.Value)
                TpoCmd.Parameters.AddWithValue("@Saleenttotlamt", CDbl(Me.MTxtTotlamt.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentsplrid", CInt(Me.CmbxCust.SelectedValue))
                TpoCmd.Parameters.AddWithValue("@Saleentlocid", Me.CmbxWareh.SelectedValue)
                TpoCmd.Parameters.AddWithValue("@Saleentcarri", Me.CmbxCarri.SelectedValue)
                If Trim(Me.MtxtfrtChargs.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Saleentfrtcharg", CDbl(Me.MtxtfrtChargs.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Saleentfrtcharg", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@Saleentgrno", Me.Txtgrno.Text)
                TpoCmd.Parameters.AddWithValue("@Saleentcarino", Me.TxtCariNo.Text)
                TpoCmd.Parameters.AddWithValue("@Saleentgrdt", Me.Dtpgrdt.Value)
                If Trim(Me.mtxtulcharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Saleentulcharg", CDbl(Me.mtxtulcharg.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Saleentulcharg", CDbl(0.0))
                End If
                If Len(Me.TxtGrsWt.Text) = 0 Then Me.TxtGrsWt.Text = 0
                If Len(Me.MskinvVat.Text) = 0 Then Me.MskinvVat.Text = 0
                If Len(Me.MskInvamt.Text) = 0 Then Me.MskInvamt.Text = 0
                TpoCmd.Parameters.AddWithValue("@Saleentuload", CDbl(Me.TxtGrsWt.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentcoment", Me.Txtcoment.Text)

                If Trim(Me.MtxtPkgcharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Saleentpkgcharg", CDbl(Me.MtxtPkgcharg.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Saleentpkgcharg", CDbl(0.0))
                End If

                If Trim(Me.MskPostcharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Saleentpostcharg", CDbl(Me.MskPostcharg.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Saleentpostcharg", CDbl(0.0))
                End If

                If Trim(Me.Mskothrchrg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Saleentothrcharg", CDbl(Me.Mskothrchrg.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Saleentothrcharg", CDbl(0.0))
                End If

                If Trim(Me.MskInscharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Saleentinscharg", CDbl(Me.MskInscharg.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Saleentinscharg", CDbl(0.0))
                End If

                TpoCmd.Parameters.AddWithValue("@Saleentpolcyno", Me.TxtPlcyno.Text)
                TpoCmd.Parameters.AddWithValue("@Saleentinsco", Me.TxtinsCo.Text)
                TpoCmd.Parameters.AddWithValue("@Saleentdisonamt", CDbl(Me.lblsubttl.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentdistype", Me.Cmbxdistype.Text)

                If Trim(Me.Mtxtdisvalue.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Saleentdisrate", CDbl(Me.Mtxtdisvalue.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Saleentdisrate", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@Saleentdisvalue", CDbl(Me.lbldiscount.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentvatrate", Me.Cmbxspcatid.SelectedValue)

                If Trim(Me.mskTxtVAtCst.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Saleentvatamt", CDbl(Me.mskTxtVAtCst.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Saleentvatamt", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@Saleentorderid", 0)

                TpoCmd.Parameters.AddWithValue("@Saleentvatinvno", Trim(Me.TxtVatinvno.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentvatdt", Me.DtpInvvatdt.Value)
                TpoCmd.Parameters.AddWithValue("@Saleentinvamt", CDbl(Me.MskInvamt.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentinvvat", CDbl(Me.MskinvVat.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentpvtmrk", Trim(Me.TxtPvtMrk.Text))


                If xWrkContrctSale_Flag Then
                    TpoCmd.Parameters.AddWithValue("@SaleEntTxAbleAmt", CDbl(0))
                Else
                    TpoCmd.Parameters.AddWithValue("@SaleEntTxAbleAmt", CDbl(Me.LbltablAmt.Text))
                End If
                TpoCmd.Parameters.AddWithValue("@SaleEntVATSurChrg", Trim(Me.LblSurCharg.Text))
                TpoCmd.Parameters.AddWithValue("@SaleEntRondOff", Trim(Me.xRondOff))

                TpoCmd.Parameters.AddWithValue("@Saleentadusrid", Current_UsrId)
                TpoCmd.Parameters.AddWithValue("@Saleentaddt", Now)
                TpoCmd.Parameters.AddWithValue("@Saleentdelstatus", 1)
                TpoCmd.Parameters.AddWithValue("@Saleplistid", 0)


                If Me.CmbxAdnlDis.Visible = True Then
                    TpoCmd.Parameters.AddWithValue("@SaleDisNarr", Me.CmbxAdnlDis.Text.Trim)
                Else
                    TpoCmd.Parameters.AddWithValue("@SaleDisNarr", "None")
                End If
                TpoCmd.Parameters.AddWithValue("@SaleEntAgntid", CInt(Me.CmbxAgent.SelectedValue))
                If Me.Rb2pay.Checked = True Then
                    TpoCmd.Parameters.AddWithValue("@SaleEntFrgtType", CInt(0))
                Else
                    TpoCmd.Parameters.AddWithValue("@SaleEntFrgtType", CInt(1))
                End If
                If xWrkContrctSale_Flag = True Then
                    TpoCmd.Parameters.AddWithValue("@SaleENTBILLTYPE", "JBWRK")
                Else
                    TpoCmd.Parameters.AddWithValue("@SaleENTBILLTYPE", "NOINV")
                End If
                If xWrkContrctSale_Flag = True Then
                    TpoCmd.Parameters.AddWithValue("@SaleEntJOBRATE", CDbl(Me.MskAdlDis.Text))
                    TpoCmd.Parameters.AddWithValue("@SaleEntJOBAMT", CDbl(Me.LblAdlDis.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@SaleentAdnlDis", CDbl(Me.LblAdlDis.Text))
                    TpoCmd.Parameters.AddWithValue("@SaleentadnldisRate", CDbl(Me.MskAdlDis.Text))
                    If Me.RbAdnl1.Checked = True Then
                        TpoCmd.Parameters.AddWithValue("@SaleAdnlType", 0) '== 0 for Value
                    Else
                        TpoCmd.Parameters.AddWithValue("@SaleAdnlType", 1) '== 1 for percentage
                    End If
                End If
                TpoCmd.Parameters.AddWithValue("@SaleEntRETAILvNO", Trim(TxtSaleBillNo.Text))

                TpoCmd.Parameters.AddWithValue("@SaleEnt_UGRUP", CInt(Me.CmbxStokGrup.SelectedValue)) ' For without Inventory entrires only.
                TpoCmd.ExecuteNonQuery()
            Catch ex As SqlException
                If ex.Number = 8114 Then
                    MsgBox("Data overflow, check maximum limit of a control", MsgBoxStyle.Critical, "Check Lenth of data")
                Else
                    MsgBox(ex.Message)
                End If

                Exit Sub
            Finally
                TpoCmd.Dispose()
            End Try

            Dim CurrPbillId As Integer = FindlastId(Trim(TxtSaleBillNo.Text), CInt(Me.CmbxCust.SelectedValue))
            Try
                Dim DgCntr As Integer
                For DgCntr = 0 To Me.DgSaleDirect.Rows.Count - 1

                    TpoCmd = New SqlCommand("Finact_Saleentry_Details_Insert", FinActConn)
                    TpoCmd.CommandType = CommandType.StoredProcedure
                    TpoCmd.Parameters.AddWithValue("@dSaleentconcrnid", (CurrPbillId))
                    TpoCmd.Parameters.AddWithValue("@dSaleent_con_dSaleid", 0)
                    TpoCmd.Parameters.AddWithValue("@dSaleentitmid", 0)
                    TpoCmd.Parameters.AddWithValue("@dSaleentqntyissue", CDbl(Me.DgSaleDirect.Rows(DgCntr).Cells(0).Value))
                    TpoCmd.Parameters.AddWithValue("@dSaleentDescrpt", Trim(Me.DgSaleDirect.Rows(DgCntr).Cells(1).Value))
                    TpoCmd.Parameters.AddWithValue("@dSaleentitmrate", CDbl(Me.DgSaleDirect.Rows(DgCntr).Cells(2).Value))
                    TpoCmd.Parameters.AddWithValue("@dSaleentlocid", Me.CmbxWareh.SelectedValue)
                    TpoCmd.Parameters.AddWithValue("@SaleEntCartNo", (Me.DgSaleDirect.Rows(DgCntr).Cells(5).Value))
                    TpoCmd.ExecuteNonQuery()

                Next
                MsgBox("Current Record Has Been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                If Me.RbSbill1.Checked = True Then
                    x_SBill_Type = 1
                Else
                    x_SBill_Type = 2
                End If
                x_SBillNo_x = Trim(Me.TxtSaleBillNo.Text)

                Clear_Values()
                If MessageBox.Show("Do you want to print this sale bill?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim frmsbPrnt As New FrmCrRptSaleBillPrinting
                    frmsbPrnt.Visible = False
                    frmsbPrnt.ShowInTaskbar = False
                    frmsbPrnt.BringToFront()
                    frmsbPrnt.ShowDialog()
                End If
                Me.TxtSaleBillNo.Focus()
                Me.TxtSaleBillNo.SelectAll()
                Nrow = New DataGridViewRow
                Me.DgSaleDirect.Rows.Add(Nrow)
                Me.DgSaleDirect.Rows(0).HeaderCell.Value = "1"
                Me.DgSaleDirect.Rows(0).Cells(0).Value = 1
                Me.DgSaleDirect.Rows(0).Cells(1).Value = "Sale Item(s)"

            Catch ex As SqlException
                If ex.Number = 8114 Then
                    MsgBox("Data overflow, check maximum limit of a control", MsgBoxStyle.Critical, "Check Lenth of data")
                Else
                    MsgBox(ex.Message)
                End If
                Try
                    TpoCmd1 = New SqlCommand("Delete from finactSaleentry where Saleentid=@pid", FinActConn1)
                    TpoCmd1.Parameters.AddWithValue("@pid", CurrPbillId)
                    TpoCmd1.ExecuteNonQuery()
                Catch ex1 As Exception
                Finally
                    TpoCmd1.Dispose()
                End Try
            Finally
                TpoCmd.Dispose()
            End Try
        Else
            MsgBox("Invalid action! System could not found any record to save", MsgBoxStyle.Critical, "Empty Table")
            Me.DgSaleDirect.Focus()

        End If

    End Sub
    Private Function FindlastId(ByVal P_billno As String, ByVal Splr_id As Integer) As Integer
        Try

            TpoCmd1 = New SqlCommand("select Saleentid from finactSaleentry where Saleentvno=@Ono and Saleentsplrid=@sid", FinActConn1)
            TpoCmd1.Parameters.AddWithValue("@Ono", Trim(P_billno))
            TpoCmd1.Parameters.AddWithValue("@sid", Trim(Splr_id))
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.HasRows = True Then
                MaxSplid = TpoRdr1(0)
                Return MaxSplid
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoRdr1.Close()
            TpoCmd1.Dispose()
        End Try

    End Function
    Private Function Curr_MaxId() As Integer
        Try
            Dim Curr_MaxSaleid As Integer = 0
            TpoCmd1 = New SqlCommand("select max(Saleentid) from finactSaleentry ", FinActConn1)
            ''where Saleentdt=@xdt
            ''TpoCmd1.Parameters.AddWithValue("@xdt", Me.dtpordrdt.Value.Date)
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.IsDBNull(0) = False Then
                Curr_MaxSaleid = TpoRdr1(0)
            Else
                Curr_MaxSaleid = 0
            End If
            Return Curr_MaxSaleid
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoRdr1.Close()
            TpoCmd1.Dispose()
        End Try
    End Function
    Private Function Curr_Maxdate() As Date
        Try
            Dim Curr_MaxSaledt As Date
            TpoCmd1 = New SqlCommand("select max(Saleentdt) from finactSaleentry where  Saleentdelstatus=1", FinActConn1)

            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.IsDBNull(0) = False Then
                Curr_MaxSaledt = TpoRdr1(0)
                Return Curr_MaxSaledt
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoRdr1.Close()
            TpoCmd1.Dispose()
        End Try

    End Function


    Private Sub CreateGridColumns()

        Me.DgSaleDirect.Columns.Clear()
        Me.DgSaleDirect.Rows.Clear()
        '0
        Me.DgSaleDirect.Columns.Add("Qnty", "Quantity")
        Me.DgSaleDirect.Columns("Qnty").Width = 130
        Me.DgSaleDirect.Columns("Qnty").DefaultCellStyle.Format = "N3"
        Me.DgSaleDirect.Columns("Qnty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        '1
        Me.DgSaleDirect.Columns.Add("Iname", "Description")
        Me.DgSaleDirect.Columns("Iname").Width = 300
        Me.DgSaleDirect.Columns("Iname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '2
        Me.DgSaleDirect.Columns.Add("rate", "Rate")
        Me.DgSaleDirect.Columns("rate").Width = 130
        Me.DgSaleDirect.Columns("rate").DefaultCellStyle.Format = "N2"
        Me.DgSaleDirect.Columns("rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' Me.DgSaleDirect.Columns("rate").ReadOnly = True
        '3
        Me.DgSaleDirect.Columns.Add("amt", "Amount")
        Me.DgSaleDirect.Columns("amt").Width = 200
        Me.DgSaleDirect.Columns("amt").DefaultCellStyle.Format = "N2"
        Me.DgSaleDirect.Columns("amt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.DgSaleDirect.Columns("amt").ReadOnly = True

        '4
        Me.DgSaleDirect.Columns.Add("Flag", "Flag")
        Me.DgSaleDirect.Columns("Flag").Width = 0
        Me.DgSaleDirect.Columns("Flag").Visible = False

        '5
        Me.DgSaleDirect.Columns.Add("xCartNo", "Carton No.")
        Me.DgSaleDirect.Columns("xCartNo").Width = 100
        Me.DgSaleDirect.Columns("xCartNo").Visible = True

        Nrow = New DataGridViewRow
        Me.DgSaleDirect.Rows.Add(Nrow)
        Dim rx As Integer = Me.DgSaleDirect.Rows.Count - 1
        Me.DgSaleDirect.Rows(rx).Cells(0).Selected = False
        Me.DgSaleDirect.Rows(0).HeaderCell.Value = "1"
        Me.DgSaleDirect.Rows(0).Cells(0).Value = 1
        Me.DgSaleDirect.Rows(0).Cells(1).Value = "Sale Item(s)"

    End Sub

    Private Sub ChkbCariDetals_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbCariDetals.CheckedChanged
        Try
            If Me.ChkbCariDetals.Checked = True Then
                Me.Panel6.Enabled = True
                Me.TxtGrsWt.Focus()
            Else
                Me.Panel6.Enabled = False
                OnCarriChkBxFalse()
                Me.Txtcoment.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChkbOthrCharg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbOthrCharg.CheckedChanged
        If Me.ChkbOthrCharg.Checked = True Then
            Me.Panel7.Enabled = True
            Me.MtxtPkgcharg.Focus()
        Else
            Me.Panel7.Enabled = False
            OnOthrChkBxFalse()
            Me.Cmbxspcatid.Focus()
        End If
    End Sub

    Private Sub Txtcoment_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcoment.GotFocus
        Try
            Me.Txtcoment.BackColor = Color.Cyan
            Me.Txtcoment.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtcoment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtcoment.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Txtcoment_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtinsCo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtinsCo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.TxtinsCo_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtinsCo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtinsCo.Leave
        Try
            Me.CmbxStokGrup.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MTxtTotlamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MTxtTotlamt.GotFocus
        Try
            Me.MTxtTotlamt.BackColor = Color.White
            Me.MTxtTotlamt.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MTxtTotlamt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MTxtTotlamt.Leave
        If Chk_formatedvalue(MTxtTotlamt) = True Then
            Me.MTxtTotlamt.BackColor = Color.White
        End If
    End Sub
    Private Function Chk_formatedvalue(ByVal MskTxt As MaskedTextBox) As Boolean
        If Trim(MskTxt.Text) <> "" Then
            If IsNumeric(MskTxt.Text) = True Then
                MskTxt.Text = FormatNumber(MskTxt.Text, 2)
                Return True
            Else
                MskTxt.Focus()
                MskTxt.SelectAll()
                Return False
            End If
        End If
    End Function

    Private Sub MtxtPkgcharg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MtxtPkgcharg.Leave
        Try
            Chk_formatedvalue(MtxtPkgcharg)
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            If_VAtrate_changed_then()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MskPostcharg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MskPostcharg.Leave
        Try
            Chk_formatedvalue(MskPostcharg)
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            If_VAtrate_changed_then()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Mskothrchrg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mskothrchrg.Leave
        Try
            Chk_formatedvalue(Mskothrchrg)
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            If_VAtrate_changed_then()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MskInscharg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MskInscharg.Leave
        Try
            Chk_formatedvalue(MskInscharg)
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            If_VAtrate_changed_then()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MtxtfrtChargs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MtxtfrtChargs.Leave
        Try
            Chk_formatedvalue(MtxtfrtChargs)
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            If_VAtrate_changed_then()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub mtxtulcharg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtxtulcharg.Leave
        Try
            Chk_formatedvalue(mtxtulcharg)
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            If_VAtrate_changed_then()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Clear_Values()
        Me.TxtGrsWt.Text = 0
        Me.TxtSaleBillNo.Clear()
        Me.TxtCariNo.Clear()
        Me.Txtcoment.Clear()
        Me.Txtgrno.Clear()
        Me.TxtinsCo.Clear()
        Me.TxtPlcyno.Clear()
        Me.DgSaleDirect.Rows.Clear()
        Me.MTxtTotlamt.Text = 0
        Me.MskInscharg.Text = 0
        Me.Mskothrchrg.Text = 0
        Me.MskPostcharg.Text = 0
        Me.Mtxtdisvalue.Text = 0
        Me.MtxtfrtChargs.Text = 0
        Me.MtxtPkgcharg.Text = 0
        Me.mtxtulcharg.Text = 0
        Me.lblsubttl.Text = 0
        Me.lbltoc.Text = 0
        Me.lbldiscount.Text = 0
        Me.lblgross.Text = 0
        Me.mskTxtVAtCst.Text = 0
        Me.LbltablAmt.Text = 0
        Me.LblSurCharg.Text = 0
        Me.Label33.Visible = False
        Me.RbAdnl1.Visible = False
        Me.RbAdnl2.Visible = False
        Me.CmbxAdnlDis.Visible = False

    End Sub

    Private Function SumOf_Txtvalues() As Double
        Me.lbltoc.Text = 0
        Dim v1, v2, v3, v4, v5, v6, v7 As Double
        If Trim(Me.MtxtfrtChargs.Text) <> "" Then
            If Me.Rb2pay.Checked = True Then
                v1 = 0
            Else
                v1 = Me.MtxtfrtChargs.Text
            End If
        Else
            v1 = 0
        End If
        If Trim(Me.mtxtulcharg.Text) <> "" Then
            v2 = Me.mtxtulcharg.Text
        Else
            v2 = 0
        End If
        If Trim(Me.MskInscharg.Text) <> "" Then
            v3 = Me.MskInscharg.Text
        Else
            v3 = 0
        End If
        If Trim(Me.MtxtPkgcharg.Text) <> "" Then
            v4 = Me.MtxtPkgcharg.Text
        Else
            v4 = 0
        End If
        If Trim(Me.MskPostcharg.Text) <> "" Then
            v5 = Me.MskPostcharg.Text
        Else
            v5 = 0
        End If
        If Trim(Me.Mskothrchrg.Text) <> "" Then
            v6 = Me.Mskothrchrg.Text
        Else
            v6 = 0
        End If
        v7 = (v1 + v2 + v3 + v4 + v5 + v6)
        Return v7
    End Function


    Private Sub Cmbxspcatid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.GotFocus
        Try
            Cmbxspcatid.DroppedDown = True
            If xCmbxRefresh = True Then
                Dim cond As String = "Sale"
                Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", Cmbxspcatid, cond.Trim, "SPCATDELSTATUS", CInt(1))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Cmbxspcatid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.Leave
        Try
            If CheckBlank_Cmbx(Me.Cmbxspcatid) = True Then
                If Me.Cmbxspcatid.SelectedValue > 0 Then
                    Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))
                Else
                    Me.Cmbxspcatid.SelectedValue = SpCid
                End If
                Me.TxtSaleBillNo.Text = xFetchVno_AccordingVATBillType(SplrId, CInt(Me.Cmbxspcatid.SelectedValue), Me.dtpordrdt)
                chk_Emptyvalue()
                If ErrIndx <> 0 Then
                    ErrIndx = 0
                    Me.DgSaleDirect.ReadOnly = True
                    Exit Sub
                Else
                    Me.DgSaleDirect.ReadOnly = False
                End If
                lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)

                If Me.Cmbxspcatid.SelectedIndex = 0 Then
                    VATCST = Fetch_vatrate(Me.Cmbxspcatid.SelectedValue)
                End If
                If_VAtrate_changed_then()
                If Me.Panel8.Enabled = False Then

                    Me.DgSaleDirect.Focus()
                    If Me.DgSaleDirect.Rows.Count = 0 Then
                        Nrow = New DataGridViewRow
                        Me.DgSaleDirect.Rows.Add()
                        Me.DgSaleDirect.Rows(0).HeaderCell.Value = "1"
                        Me.DgSaleDirect.Rows(0).Cells(0).Value = 1
                        Me.DgSaleDirect.Rows(0).Cells(1).Value = "Sale Item(s)"
                        Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(2, 0)
                    End If
                    Dim rx As Integer = Me.DgSaleDirect.Rows.Count - 1
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(2, rx)
                    Me.DgSaleDirect.Rows(rx).Cells(2).Selected = True
                Else
                    Me.Chkbdisc.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSpcatadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpcatadd.Click
        Try
            xCall_LinkFrm(FrmSalePurCatgry, Me.Cmbxspcatid)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSpcatadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSpcatadd.GotFocus
        If FrmShow_flag(11) = True Then
            Me.Cmbxspcatid.Focus()
        End If
    End Sub

    Private Sub DgSaleDirect_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSaleDirect.CellEndEdit

        Try

            If e.ColumnIndex = 0 Or e.ColumnIndex = 2 Then
                If IsDBNull(Me.DgSaleDirect.CurrentRow.Cells(0).Value) = False And IsDBNull(Me.DgSaleDirect.CurrentRow.Cells(2).Value) = False Then
                    CalculateCellValues()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgSaleDirect_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSaleDirect.CellLeave
        Try
            If e.ColumnIndex = 0 Then
                Me.DgSaleDirect.CurrentCell.Value = FormatNumber(Me.DgSaleDirect.CurrentCell.Value, 3)
            ElseIf e.ColumnIndex = 2 Then
                Me.DgSaleDirect.CurrentCell.Value = FormatNumber(Me.DgSaleDirect.CurrentCell.Value, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub DgSaleDirect_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgSaleDirect.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgSaleDirect.Rows.Count '- 1
            If Cr_Row <> Me.DgSaleDirect.CurrentRow.Index Then
                If e.ColumnIndex = 0 Or e.ColumnIndex = 2 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgSaleDirect.CurrentCell.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        Me.DgSaleDirect.CurrentCell.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgSaleDirect_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSaleDirect.CellValueChanged
        Try
            If Me.DgSaleDirect.RowCount > 0 Then
                If e.ColumnIndex = 0 Or e.ColumnIndex = 2 Then
                    CalculateCellValues()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub DgSaleDirect_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgSaleDirect.EditingControlShowing
        Try

            If TypeOf e.Control Is TextBox Then
                Dim tb As TextBox = e.Control
                tb.AcceptsTab = True

            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgSaleDirect_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgSaleDirect.KeyDown

        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If Me.DgSaleDirect.CurrentCell.ColumnIndex = 2 Then
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(5, Me.DgSaleDirect.CurrentCell.RowIndex)
                    Exit Sub
                End If

                If Me.DgSaleDirect.CurrentCell.ColumnIndex = 5 Then ' Me.DgSaleDirect.ColumnCount = 3 Then
                    If IsDBNull(Me.DgSaleDirect.CurrentRow.Cells(0).Value) = False And IsDBNull(Me.DgSaleDirect.CurrentRow.Cells(1).Value) = False And IsDBNull(Me.DgSaleDirect.CurrentRow.Cells(2).Value) = False Then
                        Dim Val1 As Double
                        Dim Val2 As Double
                        Dim ic As String
                        ic = Me.DgSaleDirect.CurrentRow.Cells(1).Value

                        Val1 = Me.DgSaleDirect.CurrentRow.Cells(0).Value
                        Val2 = Me.DgSaleDirect.CurrentRow.Cells(2).Value

                        If Not (Val1) > 0 Then
                            Me.DgSaleDirect.CurrentRow.Cells(0).ErrorText = "Value should be greater than zero"
                        ElseIf Not (Val2) > 0 Then
                            Me.DgSaleDirect.CurrentRow.Cells(2).ErrorText = "Value should be greater than zero"
                        Else
                            If Trim(Me.DgSaleDirect.CurrentRow.Cells(0).ErrorText) <> "" Or Trim(Me.DgSaleDirect.CurrentRow.Cells(1).ErrorText) <> "" Then
                                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                                Me.SaveFlag = False
                                Exit Sub
                            Else
                                Me.SaveFlag = True
                                If MessageBox.Show("Do you want to add more items?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                    If Me.DgSaleDirect.CurrentRow.Index = Me.DgSaleDirect.Rows.Count - 1 Then
                                        Nrow = New DataGridViewRow
                                        Me.DgSaleDirect.Rows.Add()
                                        Dim xsno As Integer = Me.DgSaleDirect.Rows.Count
                                        Me.DgSaleDirect.Rows(xsno - 1).HeaderCell.Value = xsno.ToString
                                    End If
                                Else
                                    If Me.MskAdlDis.Enabled = True Then
                                        Me.MskAdlDis.Focus()
                                        Me.MskAdlDis.SelectAll()
                                    Else
                                        Me.BtnSe_Save.Focus()
                                    End If

                                End If

                            End If


                        End If
                    End If

                    If Me.DgSaleDirect.CurrentCell.RowIndex < Me.DgSaleDirect.RowCount - 1 Then
                        Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(2, Me.DgSaleDirect.CurrentCell.RowIndex + 1)
                        Me.DgSaleDirect.CurrentRow.Cells(0).Value = 1
                        Me.DgSaleDirect.CurrentRow.Cells(1).Value = "Sale Item(s)"
                    End If
                Else
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(Me.DgSaleDirect.CurrentCell.ColumnIndex + 1, Me.DgSaleDirect.CurrentCell.RowIndex)
                End If
            End If
            e.Handled = True
        Catch ex As Exception

        End Try

    End Sub
    Private Sub chk_Emptyvalue()
        Try
            With Me.CmbxCust
                If .SelectedIndex = -1 Then
                    .BackColor = Color.Cyan
                    '.Focus()
                    ErrIndx += 1
                End If
            End With
            With Me.Cmbxspcatid
                If .SelectedIndex = -1 Then
                    .BackColor = Color.Cyan
                    '.Focus()
                    ErrIndx += 1
                End If
            End With
            With MTxtTotlamt
                If Len(Trim(.Text)) = 0 Then
                    .BackColor = Color.Cyan
                    '.Focus()
                    ErrIndx += 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With TxtSaleBillNo
                If Trim(.Text) = "" Then
                    .BackColor = Color.Cyan
                    '.Focus()
                    ErrIndx += 1
                Else
                    .BackColor = Color.White
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Me.BtnPe_Save_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.BtnO_exit_Click(sender, e)
    End Sub

    Private Sub mskTxtVAtCst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.GotFocus
        Me.mskTxtVAtCst.SelectAll()
    End Sub
    Private Sub mskTxtVAtCst_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.Leave
        Try
            If Chk_formatedvalue(mskTxtVAtCst) = False Then
                Exit Sub
            Else
                Dim val1, val2, val3, val4 As Double
                val2 = 0
                val3 = 0
                val4 = 0
                If IsNumeric(val1 = Me.lbldiscount.Text) Then
                    val1 = Me.lbldiscount.Text
                Else
                    val1 = 0
                End If
                val1 = val1 + CDbl(Me.LblAdlDis.Text)
                If IsNumeric(Me.mskTxtVAtCst.Text) Then
                    val2 = Me.mskTxtVAtCst.Text
                Else
                    val2 = 0
                End If
                If IsNumeric(Me.lbltoc.Text) Then
                    val3 = Me.lbltoc.Text
                Else
                    val3 = 0
                End If
                If IsNumeric(Me.lblsubttl.Text) Then
                    val4 = Me.lblsubttl.Text
                Else
                    val4 = 0
                End If


                Me.lblgross.Text = FormatNumber((val4 + val2 + val3) - val1, 2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                Me.mskTxtVAtCst.Focus()
                Me.mskTxtVAtCst.SelectAll()
            Else
                MsgBox("Access Denied.", MsgBoxStyle.Critical, Me.Text)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub If_VAtrate_changed_then()
        Try
            Dim val4, val5, val6, val7 As Double
            val4 = 0
            If Me.DgSaleDirect.Rows.Count > 0 Then
                For Each Rxx As DataGridViewRow In Me.DgSaleDirect.Rows
                    val4 += Rxx.Cells(3).Value  'Sub total
                    If DisVal > 0 Then
                        Me.lbldiscount.Text = FormatNumber(val4 * DisVal / 100, 2)
                    Else
                        Me.lbldiscount.Text = Me.Mtxtdisvalue.Text
                    End If
                    If IsNumeric(Me.lbldiscount.Text) Then
                        val5 = Me.lbldiscount.Text
                    Else
                        val5 = 0
                    End If
                    Me.lblsubttl.Text = FormatNumber(val4, 2)
                    Dim xAdl As Double = 0
                    If xWrkContrctSale_Flag = True Then
                        xAdl = CDbl(Me.lblsubttl.Text) * CDbl(Me.MskAdlDis.Text) / 100
                        Me.LblAdlDis.Text = FormatNumber(xAdl, 2)
                    End If
                    Me.mskTxtVAtCst.Text = FormatNumber((val4 - (val5 + xAdl)) * VATCST / 100, 2)

                    If IsNumeric(Me.mskTxtVAtCst.Text) Then
                        val6 = Me.mskTxtVAtCst.Text
                    Else
                        val6 = 0
                    End If
                    val7 = Me.lbltoc.Text
                    '' Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Cmbxdistype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxdistype.TextChanged
        Try
            Me.Mtxtdisvalue.Text = 0
            Me.lbldiscount.Text = 0
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ChkVatInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkVatInfo.CheckedChanged
        Try
            If ChkVatInfo.Checked = True Then
                Me.Pnlvatinfo.Enabled = True
                Me.Pnlvatinfo.Visible = True
                Me.Pnlvatinfo.Location = New Drawing.Point(480, 411)
                Me.TxtVatinvno.Focus()
                Me.TxtVatinvno.SelectAll()
            Else
                Me.Pnlvatinfo.Enabled = False
                Me.Pnlvatinfo.Visible = False
                Me.Pnlvatinfo.Location = New Drawing.Point(837, 169)
                Me.mskTxtVAtCst.Focus()
                Me.mskTxtVAtCst.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MskInvamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MskInvamt.GotFocus
        Try
            Me.MskInvamt.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MskInvamt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MskInvamt.Leave

        Try
            If Chk_formatedvalue(MskInvamt) = False Then
                Exit Sub
            Else

            End If
            If Trim(MskInvamt.Text) = "" Then
                Me.MskInvamt.Text = 0
            End If
            Dim valvat1 As Double = Me.MskInvamt.Text
            Dim valvat2 As Double = valvat1 * VATCST / 100
            Me.MskinvVat.Text = FormatNumber(valvat2, 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MskinvVat_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MskinvVat.GotFocus
        Try
            Me.MskinvVat.SelectAll()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub MskinvVat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MskinvVat.Leave
        Try
            If Trim(Me.MskinvVat.Text) = "" Then
                Me.MskinvVat.Text = 0
            End If

            If Chk_formatedvalue(MskinvVat) = False Then
                Exit Sub
            Else
                Me.mskTxtVAtCst.Text = Me.MskinvVat.Text
                Me.ChkVatInfo.Checked = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CalculateCellValues()
        Try
            Dim val1, val2, val3, val4, val5, val6, val7, val8 As Double
            val4 = 0

            If Me.DgSaleDirect.CurrentCell.ColumnIndex = 0 Then
                'RedirectingCell = True
                If IsDBNull(Me.DgSaleDirect.CurrentRow.Cells(0).Value) = False Then
                    val1 = Me.DgSaleDirect.CurrentRow.Cells(2).Value
                    val2 = Me.DgSaleDirect.CurrentRow.Cells(0).Value
                    val3 = val1 * val2
                    Me.DgSaleDirect.CurrentRow.Cells(2).Value = (val1)
                    Me.DgSaleDirect.CurrentRow.Cells(0).Value = (val2)
                    Me.DgSaleDirect.CurrentRow.Cells(3).Value = (val3)

                    For Each DgRx As DataGridViewRow In Me.DgSaleDirect.Rows
                        If IsDBNull(DgRx.Cells(3).Value) = False Then
                            val4 += (DgRx.Cells(3).Value)  'Sub total
                        Else
                            val4 += 0
                        End If

                        If DisVal > 0 Then
                            Me.lbldiscount.Text = FormatNumber(val4 * DisVal / 100, 2)
                        Else
                            Me.lbldiscount.Text = Me.Mtxtdisvalue.Text
                        End If
                        If IsNumeric(Me.lbldiscount.Text) Then
                            val5 = Me.lbldiscount.Text
                        Else
                            val5 = 0
                        End If
                        Me.lblsubttl.Text = FormatNumber(val4, 2)
                        Dim xAdl As Double = 0
                        If xWrkContrctSale_Flag = True Then
                            xAdl = CDbl(Me.lblsubttl.Text) * CDbl(Me.MskAdlDis.Text) / 100
                            Me.LblAdlDis.Text = FormatNumber(xAdl, 2)
                            val8 = val4 - (val5 + xAdl)
                        Else
                            val8 = val4 - (val5 + CDbl(Me.LblAdlDis.Text))
                        End If

                        Me.mskTxtVAtCst.Text = FormatNumber(Math.Round(val8 * VATCST / 100, 1), 2)
                        If IsNumeric(Me.mskTxtVAtCst.Text) Then
                            val6 = Me.mskTxtVAtCst.Text
                        Else
                            val6 = 0
                        End If
                        val7 = Me.lbltoc.Text
                        '  Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                        ' End If
                    Next

                End If
            End If
            If Me.DgSaleDirect.CurrentCell.ColumnIndex = 2 Then
                'RedirectingCell = True
                If IsDBNull(Me.DgSaleDirect.CurrentRow.Cells(2).Value) = False Then
                    val1 = Me.DgSaleDirect.CurrentRow.Cells(2).Value
                    val2 = Me.DgSaleDirect.CurrentRow.Cells(0).Value
                    val3 = val1 * val2
                    Me.DgSaleDirect.CurrentRow.Cells(2).Value = (val1)
                    Me.DgSaleDirect.CurrentRow.Cells(0).Value = (val2)
                    Me.DgSaleDirect.CurrentRow.Cells(3).Value = (val3)

                    For Each DgRx As DataGridViewRow In Me.DgSaleDirect.Rows
                        If IsDBNull(DgRx.Cells(3).Value) = False Then
                            val4 += (DgRx.Cells(3).Value)  'Sub total
                        Else
                            val4 += 0
                        End If

                        If DisVal > 0 Then
                            Me.lbldiscount.Text = FormatNumber(val4 * DisVal / 100, 2)
                        Else
                            Me.lbldiscount.Text = Me.Mtxtdisvalue.Text
                        End If
                        If IsNumeric(Me.lbldiscount.Text) Then
                            val5 = Me.lbldiscount.Text
                        Else
                            val5 = 0
                        End If
                        Me.lblsubttl.Text = FormatNumber(val4, 2)
                        Dim xAdl As Double = 0
                        If xWrkContrctSale_Flag = True Then
                            xAdl = CDbl(Me.lblsubttl.Text) * CDbl(Me.MskAdlDis.Text) / 100
                            Me.LblAdlDis.Text = FormatNumber(xAdl, 2)
                            val8 = val4 - (val5 + xAdl)
                        Else
                            val8 = val4 - (val5 + CDbl(Me.LblAdlDis.Text))
                        End If
                        Me.mskTxtVAtCst.Text = FormatNumber(val8 * VATCST / 100, 2)
                        If IsNumeric(Me.mskTxtVAtCst.Text) Then
                            val6 = Me.mskTxtVAtCst.Text
                        Else
                            val6 = 0
                        End If
                        val7 = Me.lbltoc.Text
                        ' Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                        ' End If
                    Next

                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CalculateCellValues_ifCurrentpricelistchanged()
        Try
            Dim val1, val2, val3, val4, val5, val6, val7, val8 As Double
            Dim xcc As Integer = 0
            For xcc = 0 To Me.DgSaleDirect.Rows.Count - 1
                val4 = 0

                If IsDBNull(Me.DgSaleDirect.Rows(xcc).Cells(0).Value) = False Then
                    val1 = Me.DgSaleDirect.Rows(xcc).Cells(2).Value
                    val2 = Me.DgSaleDirect.Rows(xcc).Cells(0).Value
                    val3 = val1 * val2
                    Me.DgSaleDirect.Rows(xcc).Cells(2).Value = (val1)
                    Me.DgSaleDirect.Rows(xcc).Cells(0).Value = (val2)
                    Me.DgSaleDirect.Rows(xcc).Cells(3).Value = (val3)

                    For Each DgRx As DataGridViewRow In Me.DgSaleDirect.Rows
                        If IsDBNull(DgRx.Cells(3).Value) = False Then
                            val4 += (DgRx.Cells(3).Value)  'Sub total
                        Else
                            val4 += 0
                        End If

                        If DisVal > 0 Then
                            Me.lbldiscount.Text = FormatNumber(val4 * DisVal / 100, 2)
                        Else
                            Me.lbldiscount.Text = Me.Mtxtdisvalue.Text
                        End If
                        If IsNumeric(Me.lbldiscount.Text) Then
                            val5 = Me.lbldiscount.Text
                        Else
                            val5 = 0
                        End If
                        Me.lblsubttl.Text = FormatNumber(val4, 2)
                        Dim xAdl As Double = 0
                        If xWrkContrctSale_Flag = True Then
                            xAdl = CDbl(Me.lblsubttl.Text) * CDbl(Me.MskAdlDis.Text) / 100
                            Me.LblAdlDis.Text = FormatNumber(xAdl, 2)
                            val8 = val4 - (val5 + xAdl)
                        Else
                            val8 = val4 - (val5 + CDbl(Me.LblAdlDis.Text))
                        End If

                        Me.mskTxtVAtCst.Text = FormatNumber(val8 * VATCST / 100, 2)
                        If IsNumeric(Me.mskTxtVAtCst.Text) Then
                            val6 = Me.mskTxtVAtCst.Text
                        Else
                            val6 = 0
                        End If
                        val7 = Me.lbltoc.Text
                        '' Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)

                    Next

                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

    End Sub

    Private Sub lblgross_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblgross.TextChanged, LblSurCharg.TextChanged, LblVATCST.TextChanged, LblRondOff.TextChanged
        Try
            Me.MTxtTotlamt.Text = FormatNumber(Math.Round(CDbl(Me.lblgross.Text), 0), 2)
            xRondOff = CDbl(Me.MTxtTotlamt.Text) - CDbl(Me.lblgross.Text)
            Me.LblRondOff.Text = FormatNumber(xRondOff, 2)
        Catch ex As Exception

        End Try
    End Sub


    Private Function Select_Salepircelst_Maxid(ByVal xSpl_Splrid As Integer) As Integer
        Dim xStr As String = "Finact_SalePriceList_Select_MaxEfectDate"

        Try
            TpoCmd = New SqlCommand(xStr, FinActConn1)
            TpoCmd.CommandType = CommandType.StoredProcedure
            TpoCmd.Parameters.AddWithValue("@AtchSplid", xSpl_Splrid)
            TpoRdr = TpoCmd.ExecuteReader
            While TpoRdr.Read
                If TpoRdr.IsDBNull(0) = False Then
                    Return TpoRdr(0)
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd.Dispose()
            TpoRdr.Close()
        End Try
    End Function
    Private Function Select_Salepircelst_Rate(ByVal xSplM_id As Integer, ByVal xSplI_id As Integer) As Double
        Dim xStr As String = "Finact_SalePriceList_Select_Rate"

        Try
            TpoCmd = New SqlCommand(xStr, FinActConn1)
            TpoCmd.CommandType = CommandType.StoredProcedure
            TpoCmd.Parameters.AddWithValue("@SplM_id", xSplM_id)
            TpoCmd.Parameters.AddWithValue("@SplI_id ", xSplI_id)
            TpoRdr = TpoCmd.ExecuteReader
            While TpoRdr.Read
                If TpoRdr.IsDBNull(0) = False Then
                    Return TpoRdr(0)
                Else
                    Return 0.0
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd.Dispose()
            TpoRdr.Close()
        End Try
    End Function

    Private Sub ChkbCariDetals_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkbCariDetals.GotFocus
        Try
            Me.ChkbCariDetals.BackColor = Color.Blue
            Me.ChkbCariDetals.ForeColor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkbCariDetals_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkbCariDetals.Leave
        Try
            Me.ChkbCariDetals.BackColor = Color.Transparent
            Me.ChkbCariDetals.ForeColor = Color.Black
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ChkbOthrCharg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkbOthrCharg.GotFocus
        Try
            Me.ChkbOthrCharg.BackColor = Color.Blue
            Me.ChkbOthrCharg.ForeColor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkbOthrCharg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkbOthrCharg.Leave
        Try
            Me.ChkbOthrCharg.BackColor = Color.Transparent
            Me.ChkbOthrCharg.ForeColor = Color.Black
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkbdisc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkbdisc.GotFocus
        Try
            Me.Chkbdisc.BackColor = Color.Blue
            Me.Chkbdisc.ForeColor = Color.White

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkbdisc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkbdisc.Leave
        Try
            Me.Chkbdisc.BackColor = Color.Transparent
            Me.Chkbdisc.ForeColor = Color.Black

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Cmbxspcatid_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.SelectionChangeCommitted
        Try
            CalculateCellValues_ifCurrentpricelistchanged()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function Chk_zeroQnty() As Boolean
        Try
            Dim xxc As Integer = 0
            For xxc = 0 To Me.DgSaleDirect.RowCount - 1
                If Not (Me.DgSaleDirect.Rows(xxc).Cells(0).Value) > 0 Or Not (Me.DgSaleDirect.Rows(xxc).Cells(2).Value) > 0 Then
                    Me.DgSaleDirect.Rows(xxc).Cells(0).ErrorText = "Quantity should be greater than zero"
                    Me.DgSaleDirect.Rows(xxc).DefaultCellStyle.BackColor = Color.Yellow
                    Return True
                Else
                    Me.DgSaleDirect.Rows(xxc).Cells(0).ErrorText = ""
                    Me.DgSaleDirect.Rows(xxc).DefaultCellStyle.BackColor = Color.White

                End If
            Next
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File Name :- " & Me.Name & " Private Function Chk_zeroQnty(),Line No.2281")
        End Try
    End Function




    Private Sub Txtcoment_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcoment.Leave
        Try
            Me.Txtcoment.BackColor = Color.White
            Me.ChkbOthrCharg.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkBx1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBx1.CheckedChanged
        Try
            If Me.ChkBx1.Checked = True Then
                xCust_Vend = True
                Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxCust, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Customer", "Vendor", 1)
            Else
                xCust_Vend = False
                Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxCust, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Customer", "Customer", 1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxstatus.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Cmbxstatus_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxstatus_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxstatus.Leave
        Try
            If CheckBlank_Cmbx(Me.Cmbxstatus) = True Then
                Me.TxtSaleBillNo.Focus()
                Me.TxtSaleBillNo.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Cmbxspcatid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxspcatid.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Cmbxspcatid_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxspcatid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.SelectedIndexChanged
        Try
            If Me.Cmbxspcatid.SelectedIndex > 0 Then
                VATCST = Fetch_vatrate(Me.Cmbxspcatid.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCust_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCust.GotFocus
        Try
            Me.CmbxCust.DroppedDown = True
            If xCmbxRefresh = True Then
                If Me.ChkBx1.Checked = True Then
                    Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxCust, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Customer", "Vendor", 1)
                Else
                    Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxCust, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Customer", "Customer", 1)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSe_Save.GotFocus, BtnSe_exit.GotFocus, BtnFind.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSe_exit.Leave, BtnSe_Save.Leave, BtnFind.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCust_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCust.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxCust_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCust_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCust.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxCust) = True Then
                Dim xAgntId As Integer = CInt(xDynamic_Find_xAnItem_xInA_Table_1cond("splrAgntId", "Splrid", CInt(Me.CmbxCust.SelectedValue), "FinactSplrmstr"))

                If xAgntId > 0 Then
                    Me.CmbxAgent.SelectedValue = xAgntId
                Else
                    Me.CmbxAgent.SelectedIndex = 0
                End If
                SplrId = CInt(Me.CmbxCust.SelectedValue)
                xCustId_EditMode = SplrId '===For use in Edit mode at run time
                If Me.CmbxCarri.Items.Count > 0 Then
                    Me.CmbxCarri.SelectedValue = xDynamic_Find_xAnItem_xInA_Table_1cond("SplrCarriid", "Splrid", SplrId, "FinactSplrmstr")
                End If
                Me.LblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(Me.CmbxCust.SelectedValue), Me.LblType), 2)
                Me.ChkbCariDetals.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub OnOthrChkBxFalse()
        Try
            Me.TxtinsCo.Clear()
            Me.TxtPlcyno.Clear()
            Me.MskInscharg.Clear()
            Me.Mskothrchrg.Clear()
            Me.MskPostcharg.Clear()
            Me.MtxtPkgcharg.Clear()
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub lbltoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbltoc.TextChanged
        Try
            Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub OnCarriChkBxFalse()
        Try
            Me.TxtGrsWt.Clear()
            Me.TxtCariNo.Clear()
            Me.Txtgrno.Clear()
            Me.MtxtfrtChargs.Clear()
            Me.mtxtulcharg.Clear()
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            If_VAtrate_changed_then()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MtxtPkgcharg_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MtxtPkgcharg.MaskInputRejected

    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        Try
            Dim xS As New FrmTranSalEntryWithOtInvntryEdit
            xS.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xS)
            xS.BringToFront()
            xS.Show()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MtxtaLL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MtxtPkgcharg.GotFocus, MskInscharg.GotFocus _
  , Mskothrchrg.GotFocus, MskPostcharg.GotFocus, MtxtfrtChargs.GotFocus, mtxtulcharg.GotFocus
        Try
            Dim xMtx As MaskedTextBox = CType(sender, MaskedTextBox)
            xMtx.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            If Me.DgSaleDirect.SelectedRows.Count > 0 Then
                Me.DgSaleDirect.Rows.RemoveAt(Me.DgSaleDirect.CurrentRow.Index)
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''Private Sub mskTxtVAtCst_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.TextChanged
    ''    Try
    ''        Dim xV As Double = CDbl(Me.mskTxtVAtCst.Text)
    ''        Me.LblVATCST.Text = FormatNumber(Math.Round(xV, 1), 2)
    ''        Dim xSur As Double = Math.Round(xV * 10 / 100, 1)
    ''        Me.LblSurCharg.Text = FormatNumber(xSur, 2)
    ''        Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub

    Private Sub lblsubttl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblsubttl.TextChanged
        Try
            Me.LbltablAmt.Text = FormatNumber(CDbl(Me.lblsubttl.Text) - (CDbl(CDbl(Me.lbldiscount.Text) + CDbl(Me.LblAdlDis.Text))), 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lbldiscount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbldiscount.TextChanged
        Try
            Me.LbltablAmt.Text = FormatNumber(CDbl(Me.lblsubttl.Text) - (CDbl(CDbl(Me.lbldiscount.Text) + CDbl(Me.LblAdlDis.Text))), 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblAdlDis_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblAdlDis.TextChanged
        Try
            If CDbl(Me.MskAdlDis.Text) > 0 And Me.MskAdlDis.Text.Equals("100.00") Then
                Me.LbltablAmt.Text = FormatNumber(CDbl(Me.LblAdlDis.Text), 2)
            Else
                Me.LbltablAmt.Text = FormatNumber(CDbl(Me.lblsubttl.Text) - (CDbl(CDbl(Me.lbldiscount.Text) + CDbl(Me.LblAdlDis.Text))), 2)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkbdisc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkbdisc.CheckedChanged
        Try
            If Me.Chkbdisc.Checked = True Then
                Me.MskAdlDis.Enabled = True
                Me.Cmbxdistype.SelectedIndex = 0
                Me.Panel8.Enabled = True
            Else
                Me.MskAdlDis.Enabled = False
                Me.Panel8.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub mskTxtVAtCst_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.TextChanged
        'Try
        '    Dim xV As Double = CDbl(Me.mskTxtVAtCst.Text)

        '    Dim xSur As Double = 0
        '    Select Case xCheckxSalePur_VATStatus(xSalxPurxType)
        '        Case 1 '==SurCharge applicable.
        '            xSur = Math.Round(xV * 10 / 100, 1)
        '            Me.Label32.Text = "Surcharge (10%)"
        '        Case 2 '==SurCharge and Labour Charges Applicable.
        '            Me.Label32.Text = "Surcharge (10%)"
        '        Case 3 '==Labour Charges Applicable (InterStates).
        '            Me.Label32.Text = "Surcharge (0%)"
        '        Case Else
        '            xSur = Math.Round(0, 1)
        '            Me.Label32.Text = "Surcharge (0%)"
        '    End Select
        '    Me.LblVATCST.Text = FormatNumber(Math.Round(xV, 1), 2)
        '    Me.LblSurCharg.Text = FormatNumber(xSur, 2)
        '    Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
        'Catch ex As Exception

        'End Try
        Try
            Dim xV As Double = CDbl(Me.mskTxtVAtCst.Text)

            ''If Len(xSalxPurxType.Trim) = 0 And Not Me.Cmbxspcatid.SelectedIndex = -1 Then
            ''    Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))
            ''End If

            Dim xSur As Double = xCal_xInvoiceSurCharge(Me.Cmbxspcatid.SelectedValue, xV, Me.Label32)
            ''Select Case xCheckxSalePur_VATStatus(xSalxPurxType)
            ''    Case 1 '==SurCharge applicable.
            ''        xSur = Math.Round(xV * 10 / 100, 3)
            ''        Me.Label32.Text = "Surcharge (10%)"
            ''    Case 2 '==SurCharge and Labour Charges Applicable.
            ''        Me.Label32.Text = "Surcharge (10%)"
            ''    Case 3 '==Labour Charges Applicable (InterStates).
            ''        Me.Label32.Text = "Surcharge (0%)"
            ''    Case Else
            ''        xSur = Math.Round(0, 3)
            ''        Me.Label32.Text = "Surcharge (0%)"
            ''End Select
            Me.LblVATCST.Text = FormatNumber(Math.Round(xV, 3), 2)
            Me.LblSurCharg.Text = FormatNumber(xSur, 2)

            If xWrkContrctSale_Flag = True Then
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblAdlDis.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
            Else
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub xAllContrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSbill1.GotFocus, RbSbill2.GotFocus _
     , ChkbCariDetals.GotFocus, Chkbdisc.GotFocus, ChkbOthrCharg.GotFocus, CmbxCarri.GotFocus, CmbxWareh.GotFocus _
     , Cmbxstatus.GotFocus, MTxtTotlamt.GotFocus
        Try
            Dim xx As Control = CType(sender, Control)
            xx.BackColor = Color.Yellow
        Catch ex As Exception

        End Try

    End Sub
    Private Sub xAllContrl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSbill1.Leave, RbSbill2.Leave _
   , ChkbCariDetals.Leave, Chkbdisc.Leave, ChkbOthrCharg.Leave, CmbxCarri.Leave, CmbxWareh.Leave _
   , Cmbxstatus.Leave, MTxtTotlamt.Leave
        Try
            Dim xx As Control = CType(sender, Control)
            xx.BackColor = Color.Transparent
        Catch ex As Exception

        End Try

    End Sub
    Private Sub MskAdlDis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MskAdlDis.Leave
      
        Try
            If Chk_formatedvalue(MskAdlDis) = False Then
                Exit Sub
            Else
                Dim xamt As Double = Me.lblsubttl.Text
                Dim xdis As Double = CDbl(Me.lbldiscount.Text)
                Dim xAdis As Double = CDbl(Me.MskAdlDis.Text)
                Dim xBal As Double = 0
                Dim xAdl As Double = 0
                If xWrkContrctSale_Flag = True Then
                    If xAdis.Equals(100.0) Then
                        xAdl = xamt
                        xBal = xamt
                    Else
                        xAdl = xamt * xAdis / 100
                        xBal = xamt - xdis
                    End If
                   
                Else
                    If Not Len(MskAdlDis.Text) = 0 Then
                        If Me.lbldiscount.Text > 0 Then
                            xBal = xamt - xdis
                            xAdl = 0
                            If Me.RbAdnl2.Checked = True Then
                                xAdl = xBal * xAdis / 100
                            Else
                                xAdl = xAdis
                            End If
                        End If
                    End If
                End If
                Me.LblAdlDis.Text = FormatNumber(xAdl, 2)
                Me.mskTxtVAtCst.Text = FormatNumber(((xBal - xAdl) * VATCST / 100), 2)
                Dim xgrs As Double = xBal + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text)
                If xWrkContrctSale_Flag = True Then
                    Me.lblgross.Text = FormatNumber(xgrs, 2)
                Else
                    Me.lblgross.Text = FormatNumber(xgrs - xAdl, 2)
                End If
                Me.BtnSe_Save.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Mtxtdisvalue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mtxtdisvalue.Leave
        Try
            If Chk_formatedvalue(Mtxtdisvalue) = False Then
                Exit Sub
            Else
                If Trim(Me.Cmbxdistype.Text) = "Discount Value" Then
                    Me.lbldiscount.Text = FormatNumber(Me.Mtxtdisvalue.Text, 2)
                ElseIf Trim(Me.Cmbxdistype.Text) = "Discount Percentage" Then
                    DisVal = Me.Mtxtdisvalue.Text
                End If
                Me.DgSaleDirect.Focus()
                Dim rx As Integer = Me.DgSaleDirect.Rows.Count - 1
                Me.DgSaleDirect.Rows(rx).Cells(0).Selected = True
                If rx >= 0 Then
                    If_VAtrate_changed_then()
                End If
                If Not Me.Mtxtdisvalue.Text > 0 Then
                    Me.MskAdlDis.Enabled = False
                    Me.RbAdnl1.Visible = False
                    Me.RbAdnl2.Visible = False
                    Me.CmbxAdnlDis.Visible = False
                    Me.Label33.Visible = False
                    Me.Mtxtdisvalue.Text = 0
                Else
                    Me.MskAdlDis.Enabled = True
                    Me.RbAdnl1.Visible = True
                    Me.RbAdnl2.Visible = True
                    Me.CmbxAdnlDis.Visible = True
                    Me.Label33.Visible = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub RbAdnl1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAdnl1.CheckedChanged, RbAdnl2.CheckedChanged
        Try
            If Not Me.DgSaleDirect.RowCount > 0 Then Exit Sub
            Me.MskAdlDis.Text = CDbl(0.0)
            Me.MskAdlDis_Leave(sender, e)
            Me.MskAdlDis.Focus()
            Me.MskAdlDis.SelectAll()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtGrsWt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGrsWt.Leave
        Try
            xChk_numericValidation(Me.TxtGrsWt)
            If Len(Me.TxtGrsWt.Text.Trim) = 0 Then
                Me.TxtGrsWt.Text = 0
            End If
            Me.TxtGrsWt.Text = FormatNumber(CDbl(Me.TxtGrsWt.Text), 3)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxCarri_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxCarri.SelectedIndexChanged
        Try
            If Me.CmbxCarri.SelectedIndex > 0 Then
                Me.ChkbCariDetals.Enabled = True
            Else
                Me.ChkbCariDetals.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnEditmode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditmode.Click
        Try
            Dim frmact As New FrmActFindEdit
            frmact.ShowInTaskbar = False
            FrmShow_flag(5) = True
            frmact.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnEditmode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEditmode.GotFocus
        Try
            If FrmShow_flag(5) = False Then
                Me.dtpordrdt.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LbltablAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbltablAmt.TextChanged
        'Try
        '    If Len(lbltoc.Text.Trim) = 0 Then
        '        Me.lbltoc.Text = 0
        '    End If
        '    Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
        'Catch ex As Exception

        'End Try
        Try
            If Len(lbltoc.Text.Trim) = 0 Then
                Me.lbltoc.Text = 0
            End If
            If xWrkContrctSale_Flag = True Then
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblAdlDis.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
            Else
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            If xWrkContrctSale_Flag = True Then
                Me.MskAdlDis.Enabled = True
                Me.MskAdlDis.Focus()
                Me.MskAdlDis.SelectAll()
            Else
                Me.MskAdlDis.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnundrgrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnundrgrp.Click
        Try
            xCall_LinkFrm(FrmActMstr, Me.CmbxStokGrup)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxStokGrup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.GotFocus
        Try
            If xCmbxRefresh = True Then
                Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRUNDRGRUP", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), CInt(10), Me.CmbxStokGrup)
            End If
            Me.CmbxStokGrup.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxStokGrup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxStokGrup.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxStokGrup_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxStokGrup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxStokGrup) = True Then
                Me.Cmbxspcatid.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

  
    Private Sub LblAdlDis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAdlDis.Click

    End Sub
End Class




Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmTranPurEntryWithOtInvntryEdit
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
    Dim xAllowChangeFlag As Boolean = False

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

    Private Sub FrmTranSaleOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New System.Drawing.Point(948, 650)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.ChkBx1.Checked = False
            Me.SplitContainer1.SplitterDistance = 580
            Me.Top = 0
            Select_2rec_with_where(Me.CmbxWareh, SplrId)
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)

            Dim cond As String = "Purchase"
            Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", Cmbxspcatid, cond, "SPCATDELSTATUS", CInt(1))
            Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxSplr, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Vendor", "Vendor", 1)
            Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRUNDRGRUP", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), CInt(11), Me.CmbxStokGrup)
            If xWrkContrct_Flag = True Then
                xCOINFO_WRKCONTRCT()
                Me.RbAdnl1.Visible = False
                Me.RbAdnl2.Visible = False
                Me.MskAdlDis.Text = FormatNumber(xWrkContRate, 2)
                Me.LblLbrDis.Text = "Labour Charges"
                ToolStripMenuItem3.Enabled = True
                Me.Text = "Purchase Entry (Job/Work-Contract) Edit-Mode" & "  (CURRENT USER NAME:- " & Trim(Current_UserName) & ",DESIGNATION:- " & Trim(Current_UserDesi)
                Me.ChkbxTds.Visible = True
                Me.Label42txabl.Text = " + Taxable Amt."
            Else
                ToolStripMenuItem3.Enabled = False
                Me.LblLbrDis.Text = "Less Adnl. Dis.:"
                Me.RbAdnl1.Visible = True
                Me.RbAdnl2.Visible = True
                Me.Text = "Purchase Entry (Without Inventory) Edit-Mode" & "  (CURRENT USER NAME:- " & Trim(Current_UserName) & ",DESIGNATION:- " & Trim(Current_UserDesi)
                Me.ChkbxTds.Visible = False
                Me.Label42txabl.Text = " = Taxable Amt."
                Me.Panel2.Visible = False
            End If
            If xWrkContrct_Flag = True Then
                Fill_Combobox_where_cond("Purentid", "Purentvno", "PurentBILLtype", "FinactPurentry", "PURENTDELSTATUS", CInt(1), "JBWRK", Me.CmbxBillno)
            Else
                Fill_Combobox_where_cond("Purentid", "Purentvno", "PurentBILLtype", "FinactPurentry", "PURENTDELSTATUS", CInt(1), "NOINV", Me.CmbxBillno)
            End If

            CreateGridColumns()
            If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                Me.ChkVatInfo.Enabled = True
                Me.ChkVatInfo.Visible = True
            Else
                Me.ChkVatInfo.Enabled = False
                Me.ChkVatInfo.Visible = False
            End If
            Me.Panel5.Enabled = True
            Me.CmbxBillno.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub




    Private Sub BtnAddCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCust.Click
        Try
            FrmShow_flag(24) = True '===For use to set account type Vendor by default and enabled false of cmbx
            xCall_LinkFrm(FrmActMstr, Me.CmbxSplr)
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

    Private Sub Dtpreqstdt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpPurDue.ValueChanged
        Me.DtpPurDue.MinDate = dtpordrdt.Value.Date
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

    Private Sub allControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkbCariDetals.KeyDown, Chkbdisc.KeyDown _
    , ChkbOthrCharg.KeyDown, ChkVatInfo.KeyDown, CmbxCarri.KeyDown, Cmbxdistype.KeyDown, CmbxWareh.KeyDown, Dtpgrdt.KeyDown, DtpInvvatdt.KeyDown, dtpordrdt.KeyDown, DtpPurDue.KeyDown, MskInscharg.KeyDown, MskInvamt.KeyDown, MskinvVat.KeyDown _
    , Mskothrchrg.KeyDown, MskPostcharg.KeyDown, mskTxtVAtCst.KeyDown, TxtCariNo.KeyDown _
    , Txtgrno.KeyDown, TxtinsCo.KeyDown, TxtinsCo.KeyDown, TxtPlcyno.KeyDown, TxtPvtMrk.KeyDown, Txtuload.KeyDown _
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
            Me.DtpPurDue.MinDate = Me.dtpordrdt.Value
            Me.DtpInvvatdt.MinDate = Me.dtpordrdt.Value
            Me.DtpInvvatdt.MaxDate = Me.dtpordrdt.MaxDate
        Catch ex As Exception

        End Try
    End Sub

    Private Function validate_input() As Boolean
        Try
            If Me.DgPurDirect.CurrentRow.Cells(CurIndx).Value = Nothing Then
                Me.DgPurDirect.CurrentRow.Cells(CurIndx).ErrorText = "Empty not allowed"
                Return True
            Else
                Me.DgPurDirect.CurrentRow.Cells(CurIndx).ErrorText = ""
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
                Me.DgPurDirect.Focus()
                Exit Sub
            End If
            If Me.CmbxCarri.SelectedIndex = -1 Then
                Me.CmbxCarri.SelectedIndex = 0
            End If
            If Me.CmbxWareh.SelectedIndex = -1 Then
                Me.CmbxWareh.SelectedIndex = 0
            End If
            If MessageBox.Show("Are you sure to update this record", "Purchase Entry updating......", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                BtnSe_Save.Focus()
                Return
            Else
                PurEntryupdate()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub PurEntryupdate()
        If Me.DgPurDirect.Rows.Count > 0 Then
            Try
                TpoCmd = New SqlCommand("Finact_Purentry_update", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@Purentid", CInt(Me.CmbxBillno.SelectedValue))
                TpoCmd.Parameters.AddWithValue("@Purentdt", (Me.dtpordrdt.Value.Date))
                TpoCmd.Parameters.AddWithValue("@Purentvno", Trim(Me.CmbxBillno.Text.Trim))
                TpoCmd.Parameters.AddWithValue("@Purbilstatus", Trim(Me.Cmbxstatus.Text))
                TpoCmd.Parameters.AddWithValue("@Purentduedt", Me.DtpPurDue.Value)
                TpoCmd.Parameters.AddWithValue("@Purenttotlamt", CDbl(Me.MTxtTotlamt.Text))
                TpoCmd.Parameters.AddWithValue("@Purentsplrid", CInt(Me.CmbxSplr.SelectedValue))
                TpoCmd.Parameters.AddWithValue("@Purentlocid", Me.CmbxWareh.SelectedValue)
                TpoCmd.Parameters.AddWithValue("@Purentcarri", Me.CmbxCarri.SelectedValue)
                If Trim(Me.MtxtfrtChargs.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Purentfrtcharg", CDbl(Me.MtxtfrtChargs.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Purentfrtcharg", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@Purentgrno", Me.Txtgrno.Text)
                TpoCmd.Parameters.AddWithValue("@Purentcarino", Me.TxtCariNo.Text)
                TpoCmd.Parameters.AddWithValue("@Purentgrdt", Me.Dtpgrdt.Value)
                If Trim(Me.mtxtulcharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Purentulcharg", CDbl(Me.mtxtulcharg.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Purentulcharg", CDbl(0.0))
                End If

                TpoCmd.Parameters.AddWithValue("@Purentuload", Me.Txtuload.Text)
                TpoCmd.Parameters.AddWithValue("@Purentcoment", Me.Txtcoment.Text)

                If Trim(Me.MtxtPkgcharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Purentpkgcharg", CDbl(Me.MtxtPkgcharg.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Purentpkgcharg", CDbl(0.0))
                End If

                If Trim(Me.MskPostcharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Purentpostcharg", CDbl(Me.MskPostcharg.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Purentpostcharg", CDbl(0.0))
                End If

                If Trim(Me.Mskothrchrg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Purentothrcharg", CDbl(Me.Mskothrchrg.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Purentothrcharg", CDbl(0.0))
                End If

                If Trim(Me.MskInscharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Purentinscharg", CDbl(Me.MskInscharg.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Purentinscharg", CDbl(0.0))
                End If

                TpoCmd.Parameters.AddWithValue("@Purentpolcyno", Me.TxtPlcyno.Text)
                TpoCmd.Parameters.AddWithValue("@Purentinsco", Me.TxtinsCo.Text)
                TpoCmd.Parameters.AddWithValue("@Purentdisonamt", CDbl(Me.lblsubttl.Text))
                TpoCmd.Parameters.AddWithValue("@Purentdistype", Me.Cmbxdistype.Text)

                If Trim(Me.Mtxtdisvalue.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Purentdisrate", CDbl(Me.Mtxtdisvalue.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Purentdisrate", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@Purentdisvalue", CDbl(Me.lbldiscount.Text))
                TpoCmd.Parameters.AddWithValue("@Purentvatrate", Me.Cmbxspcatid.SelectedValue)

                If Trim(Me.mskTxtVAtCst.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Purentvatamt", CDbl(Me.mskTxtVAtCst.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Purentvatamt", CDbl(0.0))
                End If

                TpoCmd.Parameters.AddWithValue("@PurEntTxAbleAmt", CDbl(Me.LbltablAmt.Text))
                TpoCmd.Parameters.AddWithValue("@PurEntVATSurChrg", Trim(Me.LblSurCharg.Text))
                TpoCmd.Parameters.AddWithValue("@PurEntRondOff", Trim(Me.xRondOff))

                TpoCmd.Parameters.AddWithValue("@Purentorderid", 0)

                TpoCmd.Parameters.AddWithValue("@PurentEdtusrid", Current_UsrId)
                TpoCmd.Parameters.AddWithValue("@Purentedtdt", Now)
                If xWrkContrct_Flag = True Then
                    TpoCmd.Parameters.AddWithValue("@PurEntJOBRATE", CDbl(Me.MskAdlDis.Text))
                    TpoCmd.Parameters.AddWithValue("@PurEntJOBAMT", CDbl(Me.LblAdlDis.Text))
                    TpoCmd.Parameters.AddWithValue("@PurEntTDSRATE", CDbl(xWrkContTDSRate))
                    TpoCmd.Parameters.AddWithValue("@PurEntTDSAMT", CDbl(Me.LblTDSAmt.Text))
                Else
                    If Me.RbAdnl1.Checked = True Then
                        TpoCmd.Parameters.AddWithValue("@PURAdnlType", 0) '== 0 for Value
                    Else
                        TpoCmd.Parameters.AddWithValue("@PURAdnlType", 1) '== 1 for percentage
                    End If
                    TpoCmd.Parameters.AddWithValue("@PurEntAdnlDis", CDbl(Me.LblAdlDis.Text))
                    TpoCmd.Parameters.AddWithValue("@PurEntAdnlDisRate", CDbl(Me.MskAdlDis.Text))
                    TpoCmd.Parameters.AddWithValue("@PurEntInvDt", Me.DateTimePicker1.Value.Date)
                End If
                TpoCmd.Parameters.AddWithValue("@PurEnt_UGRUP", CInt(Me.CmbxStokGrup.SelectedValue)) ' For without Inventory entrires only.
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


            Try
                Dim DgCntr As Integer
                For DgCntr = 0 To Me.DgPurDirect.Rows.Count - 1
                    If Me.DgPurDirect.Rows(DgCntr).Cells(4).Value = 1 Then
                        TpoCmd = New SqlCommand("Finact_Purentry_Details_update", FinActConn)
                        TpoCmd.CommandType = CommandType.StoredProcedure
                        TpoCmd.Parameters.AddWithValue("@dPurentconcrnid", CInt(Me.CmbxBillno.SelectedValue))
                        ' TpoCmd.Parameters.AddWithValue("@dPurent_con_dpurid", 0)
                        TpoCmd.Parameters.AddWithValue("@dPurentid", (Me.DgPurDirect.Rows(DgCntr).Cells(5).Value))
                        TpoCmd.Parameters.AddWithValue("@dPurentitmid", 0)
                        TpoCmd.Parameters.AddWithValue("@dPurentqnty", CDbl(Me.DgPurDirect.Rows(DgCntr).Cells(0).Value))
                        TpoCmd.Parameters.AddWithValue("@dPurentitmrate", CDbl(Me.DgPurDirect.Rows(DgCntr).Cells(2).Value))
                        TpoCmd.Parameters.AddWithValue("@dPurentlocid", CInt(Me.CmbxWareh.SelectedValue))
                        TpoCmd.ExecuteNonQuery()
                    ElseIf Me.DgPurDirect.Rows(DgCntr).Cells(4).Value = 2 Then
                        TpoCmd = New SqlCommand("Finact_Purentry_Details_Insert", FinActConn)
                        TpoCmd.CommandType = CommandType.StoredProcedure
                        TpoCmd.Parameters.AddWithValue("@dPurentconcrnid", CInt(Me.CmbxBillno.SelectedValue))
                        TpoCmd.Parameters.AddWithValue("@dPurent_con_dpurid", 0)
                        TpoCmd.Parameters.AddWithValue("@dPurentitmid", 0)
                        TpoCmd.Parameters.AddWithValue("@dPurentqnty", CDbl(Me.DgPurDirect.Rows(DgCntr).Cells(0).Value))
                        TpoCmd.Parameters.AddWithValue("@dPurentDescrpt", Trim(Me.DgPurDirect.Rows(DgCntr).Cells(1).Value))
                        TpoCmd.Parameters.AddWithValue("@dPurentitmrate", CDbl(Me.DgPurDirect.Rows(DgCntr).Cells(2).Value))
                        TpoCmd.Parameters.AddWithValue("@dPurentlocid", Me.CmbxWareh.SelectedValue)
                        TpoCmd.ExecuteNonQuery()
                    End If

                Next
                MsgBox("Current Record Has Been updated Successfully", MsgBoxStyle.Information, "Save Record")
                If Me.RbSbill1.Checked = True Then
                    x_SBill_Type = 1
                Else
                    x_SBill_Type = 2
                End If
                '' x_SBillNo_x = Trim(Me.TxtSaleBillNo.Text)

                Clear_Values()
                If MessageBox.Show("Do you want to print this Pur bill?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim frmsbPrnt As New FrmCrRptSaleBillPrinting
                    frmsbPrnt.Visible = False
                    frmsbPrnt.ShowInTaskbar = False
                    frmsbPrnt.BringToFront()
                    frmsbPrnt.ShowDialog()
                End If

            Catch ex As SqlException
                If ex.Number = 8114 Then
                    MsgBox("Data overflow, check maximum limit of a control", MsgBoxStyle.Critical, "Check Lenth of data")
                Else
                    MsgBox(ex.Message)
                End If

            Finally
                TpoCmd.Dispose()
            End Try
        Else
            MsgBox("Invalid action! System could not found any record to save", MsgBoxStyle.Critical, "Empty Table")
            Me.DgPurDirect.Focus()

        End If

    End Sub
    Private Function FindlastId(ByVal P_billno As String, ByVal Splr_id As Integer) As Integer
        Try

            TpoCmd1 = New SqlCommand("select Purentid from finactPurentry where Purentvno=@Ono and Purentsplrid=@pid", FinActConn1)
            TpoCmd1.Parameters.AddWithValue("@Ono", Trim(P_billno))
            TpoCmd1.Parameters.AddWithValue("@pid", Trim(Splr_id))
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
            TpoCmd1 = New SqlCommand("select max(Purentid) from finactPurentry ", FinActConn1)
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
            TpoCmd1 = New SqlCommand("select max(purentdt) from finactPurentry where  purentdelstatus=1", FinActConn1)

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

        Me.DgPurDirect.Columns.Clear()
        Me.DgPurDirect.Rows.Clear()
        '0
        Me.DgPurDirect.Columns.Add("Qnty", "Quantity")
        Me.DgPurDirect.Columns("Qnty").Width = 150
        Me.DgPurDirect.Columns("Qnty").DefaultCellStyle.Format = "N3"
        Me.DgPurDirect.Columns("Qnty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        '1
        Me.DgPurDirect.Columns.Add("Iname", "Description")
        Me.DgPurDirect.Columns("Iname").Width = 360
        Me.DgPurDirect.Columns("Iname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '2
        Me.DgPurDirect.Columns.Add("rate", "Rate")
        Me.DgPurDirect.Columns("rate").Width = 150
        Me.DgPurDirect.Columns("rate").DefaultCellStyle.Format = "N2"
        Me.DgPurDirect.Columns("rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' Me.DgSaleDirect.Columns("rate").ReadOnly = True
        '3
        Me.DgPurDirect.Columns.Add("amt", "Amount")
        Me.DgPurDirect.Columns("amt").Width = 200
        Me.DgPurDirect.Columns("amt").DefaultCellStyle.Format = "N2"
        Me.DgPurDirect.Columns("amt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.DgSaleDirect.Columns("amt").ReadOnly = True

        '4
        Me.DgPurDirect.Columns.Add("Flag", "Flag")
        Me.DgPurDirect.Columns("Flag").Width = 0
        Me.DgPurDirect.Columns("Flag").Visible = False

        '5
        Me.DgPurDirect.Columns.Add("Rec_Id", "Recid")
        Me.DgPurDirect.Columns("Rec_Id").Width = 0
        Me.DgPurDirect.Columns("Rec_Id").Visible = False

    End Sub

    Private Sub ChkbCariDetals_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbCariDetals.CheckedChanged
        If Me.ChkbCariDetals.Checked = True Then
            Me.Panel6.Enabled = True
            Me.MtxtfrtChargs.Focus()
        Else
            Me.Panel6.Enabled = False
            OnCarriChkBxFalse()
            Me.Txtcoment.Focus()
        End If
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

    Private Sub TxtinsCo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtinsCo.Leave
        Me.CmbxStokGrup.Focus()
    End Sub

    Private Sub Chkbdisc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkbdisc.CheckedChanged
        Try
            If Me.Chkbdisc.Checked = True Then
                Me.Cmbxdistype.SelectedIndex = 0
                Me.MskAdlDis.Enabled = True
                Me.Panel8.Enabled = True
            Else
                Me.MskAdlDis.Enabled = False
                Me.MskAdlDis.Text = 0
                Me.Panel8.Enabled = False
            End If
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
        Me.Txtuload.Text = 0
        Me.TxtCariNo.Clear()
        Me.Txtcoment.Clear()
        Me.Txtgrno.Clear()
        Me.TxtinsCo.Clear()
        Me.TxtPlcyno.Clear()
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
        Me.DgPurDirect.Rows.Clear()
        Me.mskTxtVAtCst.Text = 0

    End Sub

    Private Function SumOf_Txtvalues() As Double
        Me.lbltoc.Text = 0
        Dim v1, v2, v3, v4, v5, v6, v7 As Double
        If Trim(Me.MtxtfrtChargs.Text) <> "" Then
            v1 = Me.MtxtfrtChargs.Text
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
                Dim cond As String = "Purchase"
                Select_2rec_where("spcatid", "spcatname", "spcattype", "FinactPurpurcatgry", Cmbxspcatid, cond.Trim, "SPCATDELSTATUS", CInt(1))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Cmbxspcatid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.Leave
        Try
            If CheckBlank_Cmbx(Me.Cmbxspcatid) = True Then

                chk_Emptyvalue()
                If ErrIndx <> 0 Then
                    ErrIndx = 0
                    Me.DgPurDirect.ReadOnly = True
                    Exit Sub
                Else
                    Me.DgPurDirect.ReadOnly = False
                End If
                lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)

                If Me.Cmbxspcatid.SelectedIndex = 0 Then
                    VATCST = Fetch_vatrate(Me.Cmbxspcatid.SelectedValue)
                End If
                If_VAtrate_changed_then()
                If Me.Panel8.Enabled = False Then

                    Me.DgPurDirect.Focus()
                    If Me.DgPurDirect.Rows.Count = 0 Then
                        Nrow = New DataGridViewRow
                        Me.DgPurDirect.Rows.Add()
                    End If
                    Dim rx As Integer = Me.DgPurDirect.Rows.Count - 1
                    Me.DgPurDirect.Rows(rx).Cells(0).Selected = True

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

    Private Sub DgSaleDirect_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPurDirect.CellEndEdit

        Try

            If e.ColumnIndex = 0 Or e.ColumnIndex = 2 Then
                If IsDBNull(Me.DgPurDirect.CurrentRow.Cells(0).Value) = False And IsDBNull(Me.DgPurDirect.CurrentRow.Cells(2).Value) = False Then
                    CalculateCellValues()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgSaleDirect_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPurDirect.CellLeave
        Try
            If e.ColumnIndex = 0 Then
                Me.DgPurDirect.CurrentCell.Value = FormatNumber(Me.DgPurDirect.CurrentCell.Value, 3)
            ElseIf e.ColumnIndex = 2 Then
                Me.DgPurDirect.CurrentCell.Value = FormatNumber(Me.DgPurDirect.CurrentCell.Value, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub DgSaleDirect_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgPurDirect.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgPurDirect.Rows.Count '- 1
            If Cr_Row <> Me.DgPurDirect.CurrentRow.Index Then
                If e.ColumnIndex = 0 Or e.ColumnIndex = 2 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgPurDirect.CurrentCell.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        Me.DgPurDirect.CurrentCell.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgSaleDirect_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPurDirect.CellValueChanged
        Try
            If Me.DgPurDirect.RowCount > 0 Then
                If e.ColumnIndex = 0 Or e.ColumnIndex = 2 Then
                    CalculateCellValues()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub DgSaleDirect_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgPurDirect.EditingControlShowing
        Try

            If TypeOf e.Control Is TextBox Then
                Dim tb As TextBox = e.Control
                tb.AcceptsTab = True

            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgSaleDirect_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgPurDirect.KeyDown

        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If Me.DgPurDirect.CurrentCell.ColumnIndex = 2 Then ' Me.DgSaleDirect.ColumnCount = 3 Then
                    If IsDBNull(Me.DgPurDirect.CurrentRow.Cells(0).Value) = False And IsDBNull(Me.DgPurDirect.CurrentRow.Cells(1).Value) = False And IsDBNull(Me.DgPurDirect.CurrentRow.Cells(3).Value) = False Then
                        Dim Val1 As Double
                        Dim ic As String
                        ic = Me.DgPurDirect.CurrentRow.Cells(1).Value

                        Val1 = Me.DgPurDirect.CurrentRow.Cells(0).Value

                        If Not (Val1) > 0 Then
                            Me.DgPurDirect.CurrentRow.Cells(0).ErrorText = "Value should be greater than zero"
                        Else
                            If Trim(Me.DgPurDirect.CurrentRow.Cells(0).ErrorText) <> "" Or Trim(Me.DgPurDirect.CurrentRow.Cells(1).ErrorText) <> "" Then
                                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                                Me.SaveFlag = False
                                Exit Sub
                            Else

                                Me.SaveFlag = True
                                If Me.DgPurDirect.CurrentRow.Index = Me.DgPurDirect.RowCount - 1 Then
                                    If MessageBox.Show("Do you want to add more items?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                        If Me.DgPurDirect.CurrentRow.Index = Me.DgPurDirect.Rows.Count - 1 Then
                                            Nrow = New DataGridViewRow
                                            Me.DgPurDirect.Rows.Add()
                                            Dim xsno As Integer = Me.DgPurDirect.Rows.Count
                                            Me.DgPurDirect.Rows(xsno - 1).HeaderCell.Value = xsno.ToString
                                            Me.DgPurDirect.Rows(xsno - 1).Cells(4).Value = 2
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
                    End If

                    If Me.DgPurDirect.CurrentCell.RowIndex < Me.DgPurDirect.RowCount - 1 Then
                        Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(0, Me.DgPurDirect.CurrentCell.RowIndex + 1)
                        If Me.DgPurDirect.CurrentRow.Cells(4).Value = 2 Then
                            Me.DgPurDirect.CurrentCell.Value = 0
                        End If

                    End If
                Else
                    Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(Me.DgPurDirect.CurrentCell.ColumnIndex + 1, Me.DgPurDirect.CurrentCell.RowIndex)
                End If
            End If
            e.Handled = True
        Catch ex As Exception

        End Try

    End Sub
    Private Sub chk_Emptyvalue()
        Try
            With Me.CmbxSplr
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


        Catch ex As Exception

        End Try
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


                '' Me.lblgross.Text = FormatNumber((val4 + val2 + val3) - val1, 2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub If_VAtrate_changed_then()
        Try
            Dim val4, val5, val6, val7 As Double
            val4 = 0
            If Me.DgPurDirect.Rows.Count > 0 Then
                For Each Rxx As DataGridViewRow In Me.DgPurDirect.Rows
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
                    If xWrkContrct_Flag = True Then
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

            If Me.DgPurDirect.CurrentCell.ColumnIndex = 0 Then
                'RedirectingCell = True
                If IsDBNull(Me.DgPurDirect.CurrentRow.Cells(0).Value) = False Then
                    val1 = Me.DgPurDirect.CurrentRow.Cells(2).Value
                    val2 = Me.DgPurDirect.CurrentRow.Cells(0).Value
                    val3 = val1 * val2
                    Me.DgPurDirect.CurrentRow.Cells(2).Value = (val1)
                    Me.DgPurDirect.CurrentRow.Cells(0).Value = (val2)
                    Me.DgPurDirect.CurrentRow.Cells(3).Value = (val3)

                    For Each DgRx As DataGridViewRow In Me.DgPurDirect.Rows
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
                        If xWrkContrct_Flag = True Then
                            xAdl = CDbl(Me.lblsubttl.Text) * CDbl(Me.MskAdlDis.Text) / 100
                            Me.LblAdlDis.Text = FormatNumber(xAdl, 2)
                        End If

                        val8 = val4 - (val5 + xAdl)
                        Me.mskTxtVAtCst.Text = FormatNumber(val8 * VATCST / 100, 2)
                        If IsNumeric(Me.mskTxtVAtCst.Text) Then
                            val6 = Me.mskTxtVAtCst.Text
                        Else
                            val6 = 0
                        End If
                        val7 = Me.lbltoc.Text
                        '' Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                        ' End If
                    Next

                End If
            End If
            If Me.DgPurDirect.CurrentCell.ColumnIndex = 2 Then
                'RedirectingCell = True
                If IsDBNull(Me.DgPurDirect.CurrentRow.Cells(2).Value) = False Then
                    val1 = Me.DgPurDirect.CurrentRow.Cells(2).Value
                    val2 = Me.DgPurDirect.CurrentRow.Cells(0).Value
                    val3 = val1 * val2
                    Me.DgPurDirect.CurrentRow.Cells(2).Value = (val1)
                    Me.DgPurDirect.CurrentRow.Cells(0).Value = (val2)
                    Me.DgPurDirect.CurrentRow.Cells(3).Value = (val3)

                    For Each DgRx As DataGridViewRow In Me.DgPurDirect.Rows
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
                        If xWrkContrct_Flag = True Then
                            xAdl = CDbl(Me.lblsubttl.Text) * CDbl(Me.MskAdlDis.Text) / 100
                            Me.LblAdlDis.Text = FormatNumber(xAdl, 2)
                        End If

                        val8 = val4 - (val5 + xAdl)
                        Me.mskTxtVAtCst.Text = FormatNumber(val8 * VATCST / 100, 2)
                        If IsNumeric(Me.mskTxtVAtCst.Text) Then
                            val6 = Me.mskTxtVAtCst.Text
                        Else
                            val6 = 0
                        End If
                        val7 = Me.lbltoc.Text
                        '' Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
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
            For xcc = 0 To Me.DgPurDirect.Rows.Count - 1
                val4 = 0

                If IsDBNull(Me.DgPurDirect.Rows(xcc).Cells(0).Value) = False Then
                    val1 = Me.DgPurDirect.Rows(xcc).Cells(2).Value
                    val2 = Me.DgPurDirect.Rows(xcc).Cells(0).Value
                    val3 = val1 * val2
                    Me.DgPurDirect.Rows(xcc).Cells(2).Value = (val1)
                    Me.DgPurDirect.Rows(xcc).Cells(0).Value = (val2)
                    Me.DgPurDirect.Rows(xcc).Cells(3).Value = (val3)

                    For Each DgRx As DataGridViewRow In Me.DgPurDirect.Rows
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
                        If xWrkContrct_Flag = True Then
                            xAdl = CDbl(Me.lblsubttl.Text) * CDbl(Me.MskAdlDis.Text) / 100
                            Me.LblAdlDis.Text = FormatNumber(xAdl, 2)
                        End If

                        val8 = val4 - (val5 + xAdl)
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

    Private Sub lblgross_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblgross.TextChanged
        Try
            Me.MTxtTotlamt.Text = FormatNumber(Math.Round(CDbl(Me.lblgross.Text), 0), 2)
            xRondOff = CDbl(Me.MTxtTotlamt.Text) - CDbl(Me.lblgross.Text)
            Me.LblRondOff.Text = FormatNumber(xRondOff, 2)
        Catch ex As Exception

        End Try
    End Sub



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
            For xxc = 0 To Me.DgPurDirect.RowCount - 1
                If Not (Me.DgPurDirect.Rows(xxc).Cells(0).Value) > 0 Then
                    Me.DgPurDirect.Rows(xxc).Cells(0).ErrorText = "Quantity should be greater than zero"
                    Me.DgPurDirect.Rows(xxc).DefaultCellStyle.BackColor = Color.Yellow
                    Return True
                Else
                    Me.DgPurDirect.Rows(xxc).Cells(0).ErrorText = ""
                    Me.DgPurDirect.Rows(xxc).DefaultCellStyle.BackColor = Color.White

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
                Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxSplr, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Customer", "Vendor", 1)
            Else
                xCust_Vend = False
                Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxSplr, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Vendor", "Vendor", 1)
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
                Me.MTxtTotlamt.Focus()
                Me.MTxtTotlamt.SelectAll()
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

    Private Sub CmbxCust_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSplr.GotFocus
        Try
            Me.CmbxSplr.DroppedDown = True
            If xCmbxRefresh = True Then
                If Me.ChkBx1.Checked = True Then
                    Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxSplr, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Customer", "Vendor", 1)
                Else
                    Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxSplr, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Vendor", "Vendor", 1)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSe_Save.GotFocus, BtnSe_exit.GotFocus, BtnNew.GotFocus, BtnDele.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSe_exit.Leave, BtnSe_Save.Leave, BtnNew.Leave, BtnDele.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCust_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSplr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxCust_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCust_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSplr.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxSplr) = True Then
                SplrId = CInt(Me.CmbxSplr.SelectedValue)
                xCustId_EditMode = SplrId '===For use in Edit mode at run time
                If Me.CmbxCarri.Items.Count > 0 Then
                    Me.CmbxCarri.SelectedValue = xDynamic_Find_xAnItem_xInA_Table_1cond("SplrCarriid", "Splrid", SplrId, "FinactSplrmstr")
                End If

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
            Me.lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub OnCarriChkBxFalse()
        Try
            Me.Txtuload.Clear()
            Me.TxtCariNo.Clear()
            Me.Txtgrno.Clear()
            Me.MtxtfrtChargs.Clear()
            Me.mtxtulcharg.Clear()
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            If_VAtrate_changed_then()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxBillno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxBillno.GotFocus
        Try
            Me.CmbxBillno.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxBillno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxBillno.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxBillno_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxBillno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxBillno.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxBillno) = True Then
                If Me.CmbxBillno.SelectedIndex = 0 Then
                    xFin_n_Fill_Purentry_Edit(Me.CmbxBillno.SelectedValue)
                End If
                Me.DgPurDirect.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xFin_n_Fill_Purentry_Edit(ByVal xBillid As Integer)
        Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
        Dim CurrDate As Date
        Try
            xAllowChangeFlag = False '==It prevent the change event of mskTxtVAtCst control while in edit mode
            TpoCmd1 = New SqlCommand("Finact_purEntry_Select_Where_id", FinActConn1)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@InvoiceId", CInt(Me.CmbxBillno.SelectedValue))
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.IsDBNull(0) = False Then
                Me.MTxtTotlamt.Text = FormatNumber(TpoRdr1("Purenttotlamt"), 2)
                Date.TryParse(TpoRdr1("Purentdt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.dtpordrdt.MinDate = CurrDate
                Me.dtpordrdt.Value = CurrDate
                Me.Cmbxstatus.Text = Trim(TpoRdr1("Purbilstatus"))
                Date.TryParse(TpoRdr1("Purentduedt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.DtpPurDue.Value = CurrDate
                Me.DateTimePicker1.Value = TpoRdr1("PurEntInvDt")
                Me.CmbxSplr.SelectedValue = CInt(TpoRdr1("Purentsplrid"))
                Me.LblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(Me.CmbxSplr.SelectedValue), Me.LblType), 2)
                Me.CmbxWareh.SelectedValue = TpoRdr1("Purentlocid")
                Me.CmbxCarri.SelectedValue = TpoRdr1("Purentcarri")
                Me.Txtcoment.Text = Trim(TpoRdr1("Purentcoment"))
                Me.MtxtfrtChargs.Text = FormatNumber(TpoRdr1("Purentfrtcharg"), 2)
                Me.Txtgrno.Text = TpoRdr1("Purentgrno")
                Me.TxtCariNo.Text = TpoRdr1("Purentcarino")
                Date.TryParse(TpoRdr1("Purentgrdt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.Dtpgrdt.Value = CurrDate
                Me.mtxtulcharg.Text = FormatNumber(TpoRdr1("Purentulcharg"), 2)
                Me.Txtuload.Text = TpoRdr1("Purentuload")
                Me.MtxtPkgcharg.Text = FormatNumber(TpoRdr1("Purentpkgcharg"), 2)
                Me.MskPostcharg.Text = FormatNumber(TpoRdr1("Purentpostcharg"), 2)
                Me.Mskothrchrg.Text = FormatNumber(TpoRdr1("Purentothrcharg"), 2)
                Me.MskInscharg.Text = FormatNumber(TpoRdr1("Purentinscharg"), 2)
                Me.TxtPlcyno.Text = TpoRdr1("Purentpolcyno")
                Me.TxtinsCo.Text = TpoRdr1("Purentinsco")
                Me.Cmbxdistype.Text = TpoRdr1("Purentdistype")


                DisVal = TpoRdr1("Purentdisrate")

                If DisVal > 0 Then
                    Me.Chkbdisc.Checked = True
                    Me.Cmbxdistype.SelectedIndex = 1
                Else
                    Me.Chkbdisc.Checked = False
                    Me.Cmbxdistype.SelectedIndex = 0
                End If
                Me.Mtxtdisvalue.Text = FormatNumber(TpoRdr1("Purentdisrate"), 2)
                Me.lbldiscount.Text = FormatNumber(TpoRdr1("Purentdisvalue"), 2) '
                Me.Cmbxspcatid.SelectedValue = TpoRdr1("Purentvatrate")
                VATCST = Fetch_vatrate(Me.Cmbxspcatid.SelectedValue)
                '  Me.mskTxtVAtCst.Text = FormatNumber(TpoRdr1("Purentvatamt"), 2)
                Me.lblsubttl.Text = FormatNumber(TpoRdr1("Purentdisonamt"), 2)
                Me.LbltablAmt.Text = FormatNumber(TpoRdr1("PurEntTxAbleAmt"), 2)
                Me.LblVATCST.Text = FormatNumber(TpoRdr1("Purentvatamt"), 2)
                xCal_xInvoiceSurCharge(Me.Cmbxspcatid.SelectedValue, 0, Me.Label32)
                Me.LblSurCharg.Text = FormatNumber(TpoRdr1("PurEntVATSurChrg"), 2)
                Me.LblRondOff.Text = FormatNumber(TpoRdr1("PurEntRondOff"), 2)
                Me.lblgross.Text = FormatNumber(TpoRdr1("Purenttotlamt") - TpoRdr1("PurEntRondOff"), 2)

                If xWrkContrct_Flag = True Then
                    Me.MskAdlDis.Text = FormatNumber(TpoRdr1("PURENTJOBRATE"), 2)
                    Me.LblAdlDis.Text = FormatNumber(TpoRdr1("PURENTJOBAMT"), 2)
                    Me.LblTDSAmt.Text = FormatNumber(TpoRdr1("PURENTTDSAMT"), 0)
                    If CDbl(Me.LblTDSAmt.Text) > 0 Then
                        Me.ChkbxTds.CheckState = CheckState.Checked
                    Else
                        Me.ChkbxTds.CheckState = CheckState.Unchecked
                    End If
                Else
                    If TpoRdr1("PurentAdnlDisType") = True Then
                        Me.RbAdnl2.Checked = True
                    Else
                        Me.RbAdnl1.Checked = True
                    End If
                    Me.MskAdlDis.Text = FormatNumber(TpoRdr1("PurEntAdnlDisRate"), 2)
                    Me.LblAdlDis.Text = FormatNumber(TpoRdr1("PurEntAdnlDis"), 2)

                End If
                Me.CmbxStokGrup.SelectedValue = CInt(TpoRdr1("PurEnt_UGRUP"))

            End If

        Catch ex As Exception
            TpoCmd1.Dispose()
            TpoRdr1.Close()
            MsgBox(ex.Message)

            Exit Sub
        Finally
            TpoCmd1.Dispose()
            TpoRdr1.Close()
        End Try
        Try
            TpoCmd1 = New SqlCommand("Finact_PurEntry_Details_Where_PurEntid", FinActConn1)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@xPurEntid", CInt(Me.CmbxBillno.SelectedValue))
            TpoRdr1 = TpoCmd1.ExecuteReader
            Me.DgPurDirect.Rows.Clear()
            Dim Dinx As Integer = 0
            While TpoRdr1.Read
                If TpoRdr1.IsDBNull(0) = False Then
                    Me.DgPurDirect.Rows.Add()
                    Me.DgPurDirect.Rows(Dinx).Cells(0).Value = FormatNumber(TpoRdr1("dPurentqnty"), 3)
                    Me.DgPurDirect.Rows(Dinx).Cells(1).Value = Trim(TpoRdr1("dPurentDescrpt"))
                    Me.DgPurDirect.Rows(Dinx).Cells(2).Value = FormatNumber(TpoRdr1("dPurentitmrate"), 2)
                    Me.DgPurDirect.Rows(Dinx).Cells(3).Value = FormatNumber(CDbl(TpoRdr1("dPurentqnty") * TpoRdr1("dPurentitmrate")), 2)
                    Me.DgPurDirect.Rows(Dinx).Cells(4).Value = 1
                    Me.DgPurDirect.Rows(Dinx).Cells(5).Value = CInt(TpoRdr1("DPurEntid"))
                    Dinx += 1
                End If
            End While
            Me.DgPurDirect.MultiSelect = False
            Me.DgPurDirect.AllowUserToDeleteRows = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd1.Dispose()
            TpoRdr1.Close()
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            If_VAtrate_changed_then()
            If xWrkContrct_Flag = True Then
                xSumOfField = xDynamic_SumOfFld_2cond("Finactpurentry", "purenttotlamt", "purentsplrid", "purentbilltype", CInt(Me.CmbxSplr.SelectedValue), "JBWRK")
            End If
            Me.SaveFlag = True
            xAllowChangeFlag = True '==It allow the change event of mskTxtVAtCst control while in edit mode
        End Try
    End Sub

    Private Sub CmbxBillno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxBillno.SelectedIndexChanged
        Try
            If Me.CmbxBillno.SelectedIndex > 0 Then
                xFin_n_Fill_Purentry_Edit(Me.CmbxBillno.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            Dim xS As New FrmTranPurEntryWithOtInvntry
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
            Me.LbltablAmt.Text = FormatNumber(CDbl(Me.lblsubttl.Text) - (CDbl(CDbl(Me.lbldiscount.Text) + CDbl(Me.LblAdlDis.Text))), 2)
        Catch ex As Exception

        End Try
    End Sub

    ''Private Sub mskTxtVAtCst_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.TextChanged
    ''    Try
    ''        Dim xV As Double = CDbl(Me.mskTxtVAtCst.Text)

    ''        Dim xSur As Double = 0
    ''        Select Case xCheckxSalePur_VATStatus(xSalxPurxType)
    ''            Case 1 '==SurCharge applicable.
    ''                xSur = Math.Round(xV * 10 / 100, 1)
    ''                Me.Label32.Text = "Surcharge (10%)"
    ''            Case 2 '==SurCharge and Labour Charges Applicable.
    ''                Me.Label32.Text = "Surcharge (10%)"
    ''            Case 3 '==Labour Charges Applicable (InterStates).
    ''                Me.Label32.Text = "Surcharge (0%)"
    ''            Case Else
    ''                xSur = Math.Round(0, 1)
    ''                Me.Label32.Text = "Surcharge (0%)"
    ''        End Select
    ''        Me.LblVATCST.Text = FormatNumber(Math.Round(xV, 1), 2)
    ''        Me.LblSurCharg.Text = FormatNumber(xSur, 2)
    ''        Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub
    Private Sub xAllContrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkbCariDetals.GotFocus, Chkbdisc.GotFocus, ChkbOthrCharg.GotFocus, CmbxCarri.GotFocus, CmbxWareh.GotFocus _
    , Cmbxstatus.GotFocus, MTxtTotlamt.GotFocus
        Try
            Dim xx As Control = CType(sender, Control)
            xx.BackColor = Color.Yellow
        Catch ex As Exception

        End Try

    End Sub
    Private Sub xAllContrl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkbCariDetals.Leave, Chkbdisc.Leave, ChkbOthrCharg.Leave, CmbxCarri.Leave, CmbxWareh.Leave _
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
                If xWrkContrct_Flag = True Then
                    xAdl = xamt * xAdis / 100
                    xBal = xamt - xdis
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
                        Else
                            xBal = xamt - xdis
                        End If
                    End If
                End If
                Me.LblAdlDis.Text = FormatNumber(xAdl, 2)
                Me.mskTxtVAtCst.Text = FormatNumber(((xBal - xAdl) * VATCST / 100), 2)
                Dim xgrs As Double = xBal + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text)
                If xWrkContrct_Flag = True Then
                    Me.lblgross.Text = FormatNumber(xgrs, 2)
                Else
                    Me.lblgross.Text = FormatNumber(xgrs - xAdl, 2)
                End If
                Me.BtnSe_Save.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Try
        '    If Chk_formatedvalue(MskAdlDis) = False Then
        '        Exit Sub
        '    Else
        '        If Not Len(MskAdlDis.Text) = 0 Then
        '            If Me.lbldiscount.Text > 0 Then
        '                Dim xamt As Double = Me.lblsubttl.Text
        '                Dim xdis As Double = Me.lbldiscount.Text
        '                Dim xAdis As Double = Me.MskAdlDis.Text
        '                Dim xBal As Double = xamt - xdis
        '                Dim xAdl As Double = 0
        '                If Me.RbAdnl2.Checked = True Then
        '                    xAdl = xBal * xAdis / 100
        '                Else
        '                    xAdl = xAdis
        '                End If
        '                Me.LblAdlDis.Text = FormatNumber(xAdl, 2)
        '                Me.mskTxtVAtCst.Text = FormatNumber(((xBal - xAdl) * VATCST / 100), 2)
        '                Dim xgrs As Double = xBal + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text)
        '                Me.lblgross.Text = FormatNumber(xgrs, 2)
        '            End If
        '        End If
        '        Me.BtnSe_Save.Focus()
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
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
                Me.DgPurDirect.Focus()
                Dim rx As Integer = Me.DgPurDirect.Rows.Count - 1
                Me.DgPurDirect.Rows(rx).Cells(0).Selected = True
                If rx >= 0 Then
                    If_VAtrate_changed_then()
                End If
                If Not Me.Mtxtdisvalue.Text > 0 Then
                    Me.MskAdlDis.Enabled = False
                    Me.RbAdnl1.Visible = False
                    Me.RbAdnl2.Visible = False
                    Me.Mtxtdisvalue.Text = 0
                Else
                    Me.MskAdlDis.Enabled = True
                    Me.RbAdnl1.Visible = True
                    Me.RbAdnl2.Visible = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RbAdnl1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAdnl1.CheckedChanged, RbAdnl2.CheckedChanged
        Try
            If Not Me.DgPurDirect.RowCount > 0 Then Exit Sub
            Me.MskAdlDis.Text = CDbl(0.0)
            Me.MskAdlDis_Leave(sender, e)
            Me.MskAdlDis.Focus()
            Me.MskAdlDis.SelectAll()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub BtnEditmode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditmode.Click
        Try
            Dim frmact As New FrmActFindEdit
            frmact.ShowInTaskbar = False
            FrmShow_flag(24) = True
            frmact.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnEditmode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEditmode.GotFocus
        Try
            If FrmShow_flag(24) = False Then
                Me.dtpordrdt.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub mskTxtVAtCst_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.TextChanged
        Try
            If xAllowChangeFlag = False Then Exit Sub
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
            If xWrkContrct_Flag = True Then
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblAdlDis.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
                If Me.ChkbxTds.CheckState = CheckState.Unchecked And CDbl(Me.lblgross.Text) > xTDSminLmt Then
                    Me.ChkbxTds.CheckState = CheckState.Checked
                ElseIf Me.ChkbxTds.CheckState = CheckState.Checked And (CDbl(Me.lblgross.Text) + xSumOfField) <= xTDSminLmt Then
                    Me.ChkbxTds.CheckState = CheckState.Unchecked
                End If
                If Me.ChkbxTds.CheckState = CheckState.Checked Then
                    Me.Panel2.Visible = True
                    Me.LblTDSAmt.Text = FormatNumber(CDbl(Me.lblgross.Text) * xWrkContTDSRate / 100, 0)
                Else
                    Me.Panel2.Visible = False
                End If
            Else
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LbltablAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbltablAmt.TextChanged
        Try

            If Len(lbltoc.Text.Trim) = 0 Then
                Me.lbltoc.Text = 0
            End If
            If xWrkContrct_Flag = True Then
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblAdlDis.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
                If Me.ChkbxTds.CheckState = CheckState.Checked Then
                    Me.Panel2.Visible = True
                    Me.LblTDSAmt.Text = FormatNumber(CDbl(Me.lblgross.Text) * xWrkContTDSRate / 100, 0)
                Else
                    Me.LblTDSAmt.Text = 0
                    Me.Panel2.Visible = False
                End If
            Else
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        Try
            If Len(Me.LbltablAmt.Text) > 0 Then
                Me.TxtTxableAmt.Text = FormatNumber(Me.LbltablAmt.Text, 2)
                Me.TxtTxableAmt.Location = New System.Drawing.Point(786, 478)
                Me.TxtTxableAmt.Visible = True
                Me.TxtTxableAmt.Enabled = True
                Me.TxtTxableAmt.Focus()
                Me.TxtTxableAmt.SelectAll()
            Else
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        Try
            If Len(Me.LblSurCharg.Text) > 0 Then
                Me.TxtSurChrg.Text = FormatNumber(Me.LblSurCharg.Text, 2)
                Me.TxtSurChrg.Location = New System.Drawing.Point(786, 516)
                Me.TxtSurChrg.Visible = True
                Me.TxtSurChrg.Enabled = True
                Me.TxtSurChrg.Focus()
                Me.TxtSurChrg.SelectAll()
            Else
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtTAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTxableAmt.GotFocus, TxtVATamt.GotFocus, TxtSurChrg.GotFocus
        Try
            Dim xTxt As TextBox = CType(sender, TextBox)
            xTxt.SelectAll()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TxtSurChrg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSurChrg.Leave
        Try
            If xChk_numericValidation(Me.TxtSurChrg) = False Then
                Dim xDiff As Double = CDbl(Me.LblSurCharg.Text) - CDbl(Me.TxtSurChrg.Text)
                If Math.Abs(xDiff) > 1 Then
                    MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                    Me.TxtSurChrg.Focus()
                    Exit Sub
                End If
                Me.LblSurCharg.Text = FormatNumber(Me.TxtSurChrg.Text, 2)
                ' Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
                Me.TxtSurChrg.Location = New System.Drawing.Point(841, 553)
                Me.TxtSurChrg.Enabled = False
                Me.TxtSurChrg.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtVATamt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVATamt.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.TxtVATamt.Text = FormatNumber(Me.LblVATCST.Text, 2)
                Me.mskTxtVAtCst.Text = FormatNumber(CDbl(Me.TxtVATamt.Text), 2)
                Me.TxtVATamt.Location = New System.Drawing.Point(841, 534)
                Me.TxtVATamt.Enabled = False
                Me.TxtVATamt.Visible = False
            End If
            If e.KeyCode = Keys.Enter Then
                Me.TxtVATamt_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtVATamt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVATamt.Leave
        Try
            If xChk_numericValidation(Me.TxtVATamt) = False Then
                Dim xDiff As Double = CDbl(Me.LblVATCST.Text) - CDbl(Me.TxtVATamt.Text)
                If Math.Abs(xDiff) > 1 Then
                    MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                    Me.TxtVATamt.Focus()
                    Exit Sub
                End If
                Me.LblVATCST.Text = FormatNumber(Me.TxtVATamt.Text, 2)
                Me.TxtVATamt.Location = New System.Drawing.Point(841, 534)
                Me.TxtVATamt.Enabled = False
                Me.TxtVATamt.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtTxableAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTxableAmt.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.TxtTxableAmt.Text = FormatNumber(Me.LbltablAmt.Text, 2)
                Me.TxtTxableAmt.Location = New System.Drawing.Point(841, 515)
                Me.TxtTxableAmt.Enabled = False
                Me.TxtTxableAmt.Visible = False
            End If
            If e.KeyCode = Keys.Enter Then
                Me.TxtTxableAmt_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtTxableAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTxableAmt.Leave
        Try
            If xChk_numericValidation(Me.TxtTxableAmt) = False Then
                Dim xDiff As Double = CDbl(Me.LbltablAmt.Text) - CDbl(Me.TxtTxableAmt.Text)
                If Math.Abs(xDiff) > 1 Then
                    MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                    Me.TxtTxableAmt.Focus()
                    Exit Sub
                End If
                Me.LbltablAmt.Text = FormatNumber(Me.TxtTxableAmt.Text, 2)
                Me.TxtTxableAmt.Location = New System.Drawing.Point(841, 515)
                Me.TxtTxableAmt.Enabled = False
                Me.TxtTxableAmt.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtTxableAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTxableAmt.TextChanged
        Try
            If xChk_numericValidation(Me.TxtTxableAmt) = False Then
                Dim val8 As Double = CDbl(Me.TxtTxableAmt.Text)
                Me.mskTxtVAtCst.Text = FormatNumber(val8 * VATCST / 100, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtVATamt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVATamt.TextChanged
        Try
            If xChk_numericValidation(Me.TxtVATamt) = False Then
                Me.mskTxtVAtCst.Text = FormatNumber(CDbl(Me.TxtVATamt.Text), 2)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LbltablAmt_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbltablAmt.DoubleClick
        Try
            ToolStripMenuItem10_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblVATCST_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblVATCST.DoubleClick
        Try
            ToolStripMenuItem1_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblSurCharg_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblSurCharg.DoubleClick
        Try
            ToolStripMenuItem11_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If Len(Me.LblVATCST.Text) > 0 Then
                Me.TxtVATamt.Text = FormatNumber(Me.LblVATCST.Text, 2)
                Me.TxtVATamt.Location = New System.Drawing.Point(786, 497)
                Me.TxtVATamt.Visible = True
                Me.TxtVATamt.Enabled = True
                Me.TxtVATamt.Focus()
                Me.TxtVATamt.SelectAll()
            Else
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TxtSurChrg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSurChrg.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.LblSurCharg.Text = FormatNumber(Me.LblSurCharg.Text, 2)
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
                Me.TxtSurChrg.Location = New System.Drawing.Point(841, 553)
                Me.TxtSurChrg.Enabled = False
                Me.TxtSurChrg.Visible = False
            End If
            If e.KeyCode = Keys.Enter Then
                Me.TxtSurChrg_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Me.BtnPe_Save_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.BtnO_exit_Click(sender, e)
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            If Me.DgPurDirect.SelectedRows.Count > 0 Then
                Me.DgPurDirect.Rows.RemoveAt(Me.DgPurDirect.CurrentRow.Index)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChkbxTds_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbxTds.CheckedChanged
        Try
            If ChkbxTds.CheckState = CheckState.Checked Then
                Me.ChkbxTds.Text = "TDS Is Applied"
                Me.Panel2.Visible = True
                Me.LblTDSAmt.Text = FormatNumber(CDbl(Me.lblgross.Text) * xWrkContTDSRate / 100, 0)
                Me.LabeltdsGT.Text = "TDS Deduct On:"
            Else
                Me.ChkbxTds.Text = "TDS Not Applied"
                Me.LabeltdsGT.Text = "Gross Total:"
                Me.LblTDSAmt.Text = 0
                Me.Panel2.Visible = False
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
                Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRUNDRGRUP", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), CInt(11), Me.CmbxStokGrup)
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

    Private Sub LblSurCharg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblSurCharg.TextChanged
        Try
            If xWrkContrct_Flag = True Then
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblAdlDis.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
            Else
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub lbltoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbltoc.TextChanged
        Try
            Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnDele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDele.Click
        Try
            If Not Me.CmbxBillno.SelectedIndex = -1 And Not Me.CmbxSplr.SelectedIndex = -1 Then
                If MessageBox.Show("It is strognly suggested not to delete entry(ies). Are you sure to delete current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim Delid As Integer = CInt(Me.CmbxBillno.SelectedValue)
                        FinActCmd = New SqlCommand("Finact_DelEntry_PurEntry_WthOutInvntry_Delete", FinActConn)
                        FinActCmd.CommandType = CommandType.StoredProcedure
                        FinActCmd.Parameters.AddWithValue("@xpurentid", CInt(Me.CmbxBillno.SelectedValue))
                        FinActRdr = FinActCmd.ExecuteReader
                        While FinActRdr.Read
                            Dim x As Object = FinActRdr("xMessage")
                            If FinActRdr("xMessage") = True Then
                                MsgBox("Access denied!, system could not delete current record.", MsgBoxStyle.Critical, "Relationship Developed")
                            Else
                                MsgBox("Current item has been successfully deleted", MsgBoxStyle.Information, Me.Text)


                            End If
                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Exit Sub
                    Finally
                        FinActCmd.Dispose()
                        FinActRdr.Close()
                        Clear_Values()
                        If xWrkContrct_Flag = True Then
                            Fill_Combobox_where_cond("Purentid", "Purentvno", "PurentBILLtype", "FinactPurentry", "PURENTDELSTATUS", CInt(1), "JBWRK", Me.CmbxBillno)
                        Else
                            Fill_Combobox_where_cond("Purentid", "Purentvno", "PurentBILLtype", "FinactPurentry", "PURENTDELSTATUS", CInt(1), "NOINV", Me.CmbxBillno)
                        End If
                    End Try

                Else
                    Return
                End If
            Else
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Mtxtdisvalue_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles Mtxtdisvalue.MaskInputRejected

    End Sub

    Private Sub MskAdlDis_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MskAdlDis.MaskInputRejected

    End Sub
End Class




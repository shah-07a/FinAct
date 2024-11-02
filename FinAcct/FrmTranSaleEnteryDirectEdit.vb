Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
'Imports FinAcct.cLSmYgrid
Public Class FrmTranSaleEnteryDirectEdit
    Dim TpoCmd As SqlCommand
    Dim TpoRdr As SqlDataReader
    Dim TpoAdptr As SqlDataAdapter
    Dim TpoCmd1 As SqlCommand
    Dim TpoRdr1 As SqlDataReader
    Dim TxtCond As Boolean 'for Custmor list
    Dim TxtCond1 As Integer = 0 'for item list
    Dim CurIndx As Integer
    Dim Nrow As DataGridViewRow
    Dim Ntc As DataGridViewTextBoxCell
    Dim ValQnty As Double = 0
    Dim ValRate As Double = 0
    Dim ValAmt As Double
    Dim SplrId As Integer = 0
    Dim MaxSplid As Integer = 0
    Dim SetCur_Dupli_vali As Boolean
    Dim DefltVatCst As Integer
    Dim ErrIndx, SpCid, Prvs_Splrid As Integer
    Dim DisVal As Double
    Dim CurItemlocId2 As Integer = 0
    Dim TpoDtSet As DataSet
    Dim LstIndx As Integer = 0
    Dim xTptId As Integer = 0
    Dim Alrdy_Ordr, xDisPercentage As Double
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim xxExl_Mxdt As Date
    Dim UpdateFlag As Boolean = False
    Dim xFlag As Boolean = False
    Dim DgQnty() As Double
    Dim DgCode() As String
    Dim xRondOff As Double = 0
    Dim xUpdateFlag As Boolean = False

    Private Sub FrmTranSaleEnteryDirectEdit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If xUpdateFlag = True Then
                SaleEntryupdate()
            End If
            FrmTranSaleentryMain.fill_Saleentgridview()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmTranSaleOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Size = New System.Drawing.Point(834, 650)
            Me.Top = 0
            Me.Left = 0
            Me.SplitContainer1.SplitterDistance = 578
            Me.SplitContainer1.IsSplitterFixed = True
            Me.ChkBx1.Checked = False
            Select_2rec_with_where(Me.CmbxWareh, SplrId)
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)
            Dim cond As String = "Sale"
            Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", Cmbxspcatid, cond, "SPCATDELSTATUS", CInt(1))
            Dim cond1 As String = "Sales Agent"
            Select_2rec_where("splrid", "splrname", "splrtype", "Finactsplrmstr", CmbxAgent, cond1, "SPLRDELSTATUS", CInt(1))
            Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRUNDRGRUP", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), CInt(10), Me.CmbxLdgrHead)
            Dim CurOrderNo As Integer = Curr_MaxId()
            If Curr_MaxId() > 0 Then
                Me.dtpordrdt.MinDate = Curr_Maxdate()
            Else
                Me.dtpordrdt.MinDate = FinStartDt.Date
            End If
            Me.dtpordrdt.MaxDate = FinEnddt.Date
            xFlag = False
            CreateGridColumns_Saleentr_Edit()
            xFlag = True

            Me.RbxName.Checked = True
            Dim tStr As String = Trim(Txtcustcode.Text)
            find_Customer_list(tStr)
            If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                Me.ChkVatInfo.Enabled = True
                Me.ChkVatInfo.Visible = True
            Else
                Me.ChkVatInfo.Enabled = False
                Me.ChkVatInfo.Visible = False
            End If
            If Cl_Kbl = True And xMACH_xBILLING = True Then
                Fill_Combobox("cogrpid", "cogrupnam", "FinactStokGrupname", "CoDelStatus", CInt(1), Me.CmbxStokGrup)
                'Fill_Combobox_where_cond("cogrpid", "cogrupnam", "coundrgrup", "FinactStokGrupname", CInt(5), Me.CmbxStokGrup)
            Else
                Dim ItmStr As String = Trim(TxtItmcode.Text)
                find_Item_list(ItmStr)
            End If
            Me.Text = "Sale Entry (Sale Without Sale Order) Edit-Mode  " & "  (CURRENT USER NAME:- " & Trim(Current_UserName) & ",DESIGNATION:- " & Trim(Current_UserDesi)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub find_Customer_list(ByVal CurString As String)
        Dim i, splrid_vat As Integer
        lstvewcustlist.Items.Clear()
        Try
            If Cl_Kbl = True Then
                TpoCmd = New SqlCommand("FinAct_SplrMstr_KBLtYPE_Select_Like", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@GRUPNAME", "%Mach%")
                If xMACH_xBILLING = True Then
                    TpoCmd.Parameters.AddWithValue("@xtype", CInt(2))
                Else
                    TpoCmd.Parameters.AddWithValue("@xtype", CInt(1))
                End If
            Else
                TpoCmd = New SqlCommand("FinAct_SplrMstr_Select_Like", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
            End If


            TpoCmd.Parameters.AddWithValue("@currval", Trim(CurString))
            If Me.Rbxcode.Checked = True Then
                TpoCmd.Parameters.AddWithValue("@currfield", "SplrSurFix")
            ElseIf Me.RbxName.Checked = True Then
                TpoCmd.Parameters.AddWithValue("@currfield", "splrname")
            End If
            If xCust_Vend = True Then
                TpoCmd.Parameters.AddWithValue("@splrtype", Trim("Both"))
            Else
                TpoCmd.Parameters.AddWithValue("@splrtype", Trim("Customer"))
            End If
            TpoRdr = TpoCmd.ExecuteReader
            i = 0
            While (TpoRdr.Read)
                If TpoRdr.HasRows = True Then
                    Dim lstvew As ListViewItem
                    lstvew = Me.lstvewcustlist.Items.Add(TpoRdr(4)) 'id
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(1)) '+ " " + TpoRdr(2)) 'name
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(0))
                    Me.lstvewcustlist.Items(i).SubItems.Add(Trim(TpoRdr(5)) & " " & Trim(TpoRdr(6)) & " " & Trim(TpoRdr(7)) & " " & Trim(TpoRdr(8)) & " " & Trim(TpoRdr(9)) & " " & Trim(TpoRdr(10))) 'adrs
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(3))
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(11))
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(12))


                End If
                i = i + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd = Nothing
            TpoRdr.Close()
            If splrid_vat > 0 Then
                Try
                    TpoCmd = New SqlCommand("Select splrspcatid from finactsplrmstr where splrid=@splid", FinActConn)
                    TpoCmd.Parameters.AddWithValue("@splid", splrid_vat)
                    TpoRdr = TpoCmd.ExecuteReader
                    TpoRdr.Read()
                    If TpoRdr.IsDBNull(0) = False Then
                        Me.Cmbxspcatid.SelectedValue = TpoRdr(0)
                        SpCid = TpoRdr(0)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    TpoCmd.Dispose()
                    TpoRdr.Close()
                End Try
            End If
        End Try

        If (lstvewcustlist.Items.Count > 0) Then

            If TxtCond = False Then
                Txtcustcode.Focus()
            End If
            lstvewcustlist.Items(0).Selected = True

        Else
            If TxtCond = False Then
                Txtcustcode.Focus()
            End If
        End If

    End Sub

    Private Sub TxtVcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvCode.GotFocus
        TxtCond = False
        Me.tplcustlist.Location = New System.Drawing.Point(87, 61)
        Me.tplcustlist.Visible = True
        Me.tplcustlist.Enabled = True
        Me.Txtcustcode.Text = Trim(Me.txtvCode.Text)
        Me.Txtcustcode.Focus()
    End Sub
    Private Sub Txtcustcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcustcode.GotFocus
        Try
            TxtCond = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CalculateCellValues_ifCurrentpricelistchanged()
        Try
            Dim val1, val2, val3, val4, val5, val6, val7, val8 As Double
            Dim xcc As Integer = 0
            For xcc = 0 To Me.DgSaleDirect.Rows.Count - 1
                val4 = 0
                Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))

                If Me.DgSaleDirect.Rows(xcc).Cells(0).Value <> Nothing Then
                    val1 = Me.DgSaleDirect.Rows(xcc).Cells(3).Value
                    val2 = Me.DgSaleDirect.Rows(xcc).Cells(0).Value
                    val3 = val1 * val2
                    Me.DgSaleDirect.Rows(xcc).Cells(3).Value = (val1)
                    Me.DgSaleDirect.Rows(xcc).Cells(0).Value = (val2)
                    Me.DgSaleDirect.Rows(xcc).Cells(5).Value = (val3)
                    Dim Rc As Integer
                    For Rc = 0 To Me.DgSaleDirect.Rows.Count - 1
                        If IsNumeric(Me.DgSaleDirect.Rows(Rc).Cells(5).Value) Then
                            val4 += (Me.DgSaleDirect.Rows(Rc).Cells(5).Value)  'Sub total
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
                        val8 = val4 - (val5 + CDbl(Me.LblAdlDis.Text))
                        Me.mskTxtVAtCst.Text = FormatNumber(val8 * VATCST / 100, 2)
                        If IsNumeric(Me.mskTxtVAtCst.Text) Then
                            val6 = Me.mskTxtVAtCst.Text
                        Else
                            val6 = 0
                        End If
                        val7 = Me.lbltoc.Text
                        'Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)

                    Next

                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally


        End Try

    End Sub
    Private Sub ResetPriceList_AllGridItems()
        Try
            Try
                Dim xC As Integer = 0
                For xC = 0 To Me.DgSaleDirect.Rows.Count - 1
                    If Me.DgSaleDirect.Rows(xC).Cells(7).Value <> 0 Then
                        Dim xCurItemId As Integer = Me.DgSaleDirect.Rows(xC).Cells(7).Value
                        Dim Spl_id As Integer = Me.CmbxPlist.SelectedValue
                        Me.DgSaleDirect.Rows(xC).Cells(3).Value = FormatNumber(Select_Salepircelst_Rate(Spl_id, xCurItemId), 2)
                    End If
                Next
                CalculateCellValues_ifCurrentpricelistchanged()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtcustcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtcustcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                lstvewcustlistDoubleClick()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtcustcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcustcode.Leave
        Try
            'Me.tplcustlist.Location = New System.Drawing.Point(837, 5)
            'Me.tplcustlist.Visible = False
            'Me.tplcustlist.Enabled = False
            If Not LstIndx >= 0 Then
                Me.Txtcustcode.Focus()
                Me.Txtcustcode.SelectAll()
            End If
            'If Trim(Me.txtvCode.Text) <> "" Then
            '    Me.CmbxWareh.Focus()
            '    Me.CmbxWareh.SelectAll()
            'Else
            '    Me.MTxtTotlamt.Focus()
            '    Me.MTxtTotlamt.SelectAll()
            'End If
            'If Trim(Me.Txtcustcode.Text) = "" Then
            '    Me.lstvewcustlist.Focus()
            'Else
            '    lstvewcustlistDoubleClick()
            '    Me.CmbxWareh.SelectAll()
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Txtcustcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcustcode.TextChanged
        Try
            Dim tStr As String = Trim(Txtcustcode.Text)
            find_Customer_list(tStr)
            For Each itm As ListViewItem In Me.lstvewcustlist.Items
                itm.BackColor = Color.White
                itm.ForeColor = Color.Black
            Next
            GoToItem(Me.lstvewcustlist, Me.Txtcustcode)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub lstvewcustlist_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvewcustlist.Click
        Try
            For Each itmx As ListViewItem In Me.lstvewcustlist.Items
                itmx.BackColor = Color.White
                itmx.ForeColor = Color.Black
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstvewcustlist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvewcustlist.DoubleClick
        Try
            LstIndx = Me.lstvewcustlist.SelectedItems(0).Index
            lstvewcustlistDoubleClick()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstvewcustlist_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvewcustlist.GotFocus
        Try
            Me.lstvewcustlist.Items(0).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstvewcustlist_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstvewcustlist.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                lstvewcustlist_DoubleClick(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtcustname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TxtCond = True
    End Sub

    Private Sub TxtVname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVname.GotFocus
        TxtCond = True
        Me.tplcustlist.Location = New System.Drawing.Point(91, 133)
        Me.tplcustlist.Visible = True
        Me.tplcustlist.Enabled = True
    End Sub

    Private Sub BtnAddCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCust.Click
        Dim frmact As New FrmActMstr
        frmact.ShowInTaskbar = False
        FrmShow_flag(5) = True
        frmact.ShowDialog()
    End Sub

    Private Sub BtnAddCust_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddCust.GotFocus
        If FrmShow_flag(5) = True Then
            txtvCode.Focus()
        End If
    End Sub

    Private Sub txtvCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvCode.Leave
        If FrmShow_flag(5) = True Then
            FrmShow_flag(5) = False
        End If
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
        'CmbxWareh.DroppedDown = True
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

    Private Sub CmbxCarri_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.Leave, CmbxPlist.Leave
        If FrmShow_flag(7) = True Then
            FrmShow_flag(7) = False
        End If
    End Sub

    Private Sub Cmbxstatus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxstatus.GotFocus
        If Cmbxstatus.Items.Count > 0 And Cmbxstatus.SelectedIndex = -1 Then
            Cmbxstatus.SelectedIndex = 1
        Else
            If Me.DgSaleDirect.Rows.Count >= 0 Then
                Me.DgSaleDirect.Focus()
                Dim Rcnt As Integer = Me.DgSaleDirect.Rows.Count - 1
                Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Rcnt)
            End If

        End If
    End Sub

    Private Sub Dtpreqstdt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpSaleDue.ValueChanged
        Me.DtpSaleDue.MinDate = dtpordrdt.Value.Date
    End Sub
    Private Sub dtpordrdt_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpordrdt.ValueChanged
        Me.DtpSaleDue.MinDate = dtpordrdt.Value
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

    Private Sub lstvewcustlist_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvewcustlist.Leave

        Try
            If lstvewcustlist.Items.Count > 0 Then
                lstvewcustlist_DoubleClick(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtItmcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItmcode.GotFocus
        Try
            TxtCond1 = 1 'set filter as Itme code
            ' Me.DgSaleDirect.CurrentRow.Cells(1).Selected = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub find_Item_list(ByVal CurString1 As String)
        Dim i As Integer
        Me.LstVewItem.Items.Clear()
        Try
            If Cl_Kbl = True Then
                TpoCmd = New SqlCommand("FinAct_ItemMstr_KBLtype_Select_Like", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure

                If xMACH_xBILLING = True Then
                    TpoCmd.Parameters.AddWithValue("@xtype", CInt(2))
                    TpoCmd.Parameters.AddWithValue("@GRUPNAME", CInt(Me.CmbxStokGrup.SelectedValue))
                Else
                    TpoCmd.Parameters.AddWithValue("@xtype", CInt(1))
                    TpoCmd.Parameters.AddWithValue("@GRUPNAME", "%Mach%")
                End If

            Else
                TpoCmd = New SqlCommand("FinAct_ItemMstr_Select_Like", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
            End If


            TpoCmd.Parameters.AddWithValue("@Sale_Pur_Type1", "Sale")
            TpoCmd.Parameters.AddWithValue("@currval1", Trim(CurString1))


            If Me.Rbxicode.Checked = True Then
                TpoCmd.Parameters.AddWithValue("@currfield1", "itmcode")
            ElseIf Me.RbxiName.Checked = True Then
                TpoCmd.Parameters.AddWithValue("@currfield1", "itmname")
            End If

            If TxtCond1 = 3 Then
                TpoCmd.Parameters.AddWithValue("@currfield1", "itmcatid")
            End If
            TpoRdr = TpoCmd.ExecuteReader
            i = 0
            While (TpoRdr.Read)
                If TpoRdr.HasRows = True Then
                    Dim lstvew1 As ListViewItem
                    lstvew1 = Me.LstVewItem.Items.Add(TpoRdr("itmcode")) '0
                    Me.LstVewItem.Items(i).SubItems.Add(TpoRdr("itmname")) '1
                    Me.LstVewItem.Items(i).SubItems.Add(TpoRdr("itmid")) '2
                    Me.LstVewItem.Items(i).SubItems.Add(TpoRdr("itmratechek")) '3
                    Me.LstVewItem.Items(i).SubItems.Add(TpoRdr("itmreorder")) '4
                    Me.LstVewItem.Items(i).SubItems.Add(TpoRdr("itmmax")) '5
                    Me.LstVewItem.Items(i).SubItems.Add(TpoRdr("itmopnqnty")) '6
                    Me.LstVewItem.Items(i).SubItems.Add(TpoRdr("itmunttype")) '7
                    Me.LstVewItem.Items(i).SubItems.Add(TpoRdr("itmloc")) '8
                End If
                i = i + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd = Nothing
            TpoRdr.Close()
        End Try

        If (lstvewcustlist.Items.Count > 0) Then

            If TxtCond1 = 1 Then
                TxtItmcode.Focus()
            End If
        Else
            If TxtCond1 = 1 Then
                TxtItmcode.Focus()
            End If
        End If

    End Sub


    Private Sub TxtItmcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtItmcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then
                Me.Tplitem.Location = New System.Drawing.Point(837, 243)
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False

                If Me.DgSaleDirect.CurrentRow.Cells(0).Value > 0 Then
                    If Convert.IsDBNull(Me.DgSaleDirect.CurrentRow.Cells(11).Value) = True Then
                        Me.DgSaleDirect.CurrentRow.Cells(11).Value = 2 ' 2 stands for new entry
                    End If
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(3, Me.DgSaleDirect.CurrentRow.Index)
                    Me.DgSaleDirect.CurrentCell.Selected = True
                Else
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentRow.Index)
                    Me.DgSaleDirect.CurrentCell.Selected = True
                End If
                Me.DgSaleDirect.Focus()
            End If
            If e.KeyCode = Keys.Enter Then
                If Trim(Me.TxtItmcode.Text) = "" Then
                    Me.LstVewItem.Focus()
                Else
                    LstVewItemDoubleClick()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LstVewItemDoubleClick()

        Try
            If LstIndx >= 0 Then
                Dim CurItemId As Integer = Trim(LstVewItem.Items(LstIndx).SubItems(2).Text)
                If Me.DgSaleDirect.CurrentRow.Cells(0).Value > 0 Then
                    Me.DgSaleDirect.CurrentRow.Cells(1).Value = Trim(LstVewItem.Items(0).Text)
                    Dim CurSih As Double = SumOf_In_and_Outward_Items(CurItemId, CurItemId)
                    Dim CurIndx As Integer = Me.DgSaleDirect.CurrentRow.Index
                    Dim CurCode As String = Trim(Me.DgSaleDirect.CurrentRow.Cells(1).Value)
                    If CurCode = Me.DgCode(CurIndx) Then
                        CurSih += Me.DgQnty(CurIndx)
                    End If
                    Me.lblSih.Text = FormatNumber(CurSih, 2)
                    If Me.DgSaleDirect.CurrentRow.Cells(0).Value > CurSih Then
                        Me.DgSaleDirect.CurrentRow.Cells(0).ErrorText = "Negetive Stock"
                        Me.DgSaleDirect.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow
                        ''Me.DgSaleDirect.CurrentRow.HeaderCell.ErrorText = "Negetive Stock"
                    End If

                    If Trim(Me.DgSaleDirect.CurrentRow.Cells(11).Value) = "" Then
                        Me.DgSaleDirect.CurrentRow.Cells(11).Value = 2 ' 2 stands for new entry
                    End If
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(3, Me.DgSaleDirect.CurrentRow.Index)
                Else
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentRow.Index)
                End If

                SetCur_Dupli_vali = False
                Me.DgSaleDirect.CurrentRow.Cells(1).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(0).Text)
                Me.DgSaleDirect.CurrentRow.Cells(2).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(1).Text)
                Me.DgSaleDirect.CurrentRow.Cells(6).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(2).Text)

                'exclusive rate list
                Dim SplIdxx As Integer = xxSelect_Salepircelst_Exclusive_where(SplrId)
                Dim Spl_id As Integer = Me.CmbxPlist.SelectedValue
                Dim RtCat As String = ""
                If SplIdxx > 0 Then
                    Dim Dt1, Dt2 As Date
                    Date.TryParse(xxExl_Mxdt, CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, Dt1)
                    Date.TryParse(Me.dtpordrdt.Value.Date, CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, Dt2)
                    If Not Dt2.Date > Dt1.Date Then
                        Dim Rtxx As Double = Select_Salepircelst_Rate(SplIdxx, CurItemId)
                        If Not Rtxx = Nothing Then
                            Me.DgSaleDirect.CurrentRow.Cells(3).Value = FormatNumber(Rtxx, 2)
                            RtCat = "  * Exclusive Rate"
                        Else
                            Me.DgSaleDirect.CurrentRow.Cells(3).Value = FormatNumber(Select_Salepircelst_Rate(Spl_id, CurItemId), 2)
                            RtCat = ""
                        End If
                    Else
                        Me.DgSaleDirect.CurrentRow.Cells(3).Value = FormatNumber(Select_Salepircelst_Rate(Spl_id, CurItemId), 2)
                        RtCat = ""
                    End If
                Else
                    Me.DgSaleDirect.CurrentRow.Cells(3).Value = FormatNumber(Select_Salepircelst_Rate(Spl_id, CurItemId), 2)
                    RtCat = ""
                End If
                'Dim Spl_id As Integer = Me.CmbxPlist.SelectedValue
                'Me.DgSaleDirect.CurrentRow.Cells(3).Value = FormatNumber(Select_Salepircelst_Rate(Spl_id, CurItemId), 2)
                'Me.lblSih.Text = FormatNumber(SumOf_In_and_Outward_Items(CurItemId, CurItemId), 2)

                Me.DgSaleDirect.CurrentRow.Cells(4).Value = Trim(LstVewItem.Items(LstIndx).SubItems(7).Text)
                Me.DgSaleDirect.CurrentRow.Cells(7).Value = Trim(LstVewItem.Items(LstIndx).SubItems(2).Text)
                Me.Tplitem.Location = New System.Drawing.Point(837, 243)
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
                Me.DgSaleDirect.Focus()
                Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(3, Me.DgSaleDirect.CurrentRow.Index)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub
    Private Function xxSelect_Salepircelst_Exclusive_where(ByVal Spl_Splrid As Integer) As Integer
        Dim xStr As String = "Finact_SalePriceList_Exclusive_Select"
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            TpoCmd = New SqlCommand(xStr, FinActConn2)
            TpoCmd.CommandType = CommandType.StoredProcedure
            TpoCmd.Parameters.AddWithValue("@AtchSplid", Spl_Splrid)
            TpoRdr = TpoCmd.ExecuteReader
            While TpoRdr.Read
                If TpoRdr.IsDBNull(0) = False Then
                    xxExl_Mxdt = Format(TpoRdr(1), "dd/MM/yyyy")
                    Return TpoRdr(0)

                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd.Dispose()
            TpoRdr.Close()
        End Try
    End Function
    Private Sub lstvewcustlistDoubleClick()
        Try
            If Me.lstvewcustlist.Items.Count > 0 Then
                Me.txtvCode.Text = Trim(Me.lstvewcustlist.Items(LstIndx).Text)
                Me.TxtVname.Text = Trim(Me.lstvewcustlist.Items(LstIndx).SubItems(1).Text)
                SplrId = Trim(Me.lstvewcustlist.Items(LstIndx).SubItems(2).Text)
                Me.lblAdrsfull.Text = Trim(Me.lstvewcustlist.Items(LstIndx).SubItems(3).Text)
                DefltVatCst = Trim(Me.lstvewcustlist.Items(LstIndx).SubItems(4).Text)
                xTptId = Trim(Me.lstvewcustlist.Items(LstIndx).SubItems(5).Text)
                DisVal = (Me.lstvewcustlist.Items(LstIndx).SubItems(6).Text)
                Me.Cmbxdistype.SelectedIndex = 1

                If DisVal > 0 Then
                    Me.Chkbdisc.Checked = True
                Else
                    Me.Chkbdisc.Checked = False
                End If
                Me.Mtxtdisvalue.Text = FormatNumber(DisVal, 3)

                Me.tplcustlist.Location = New System.Drawing.Point(837, 5)
                Me.tplcustlist.Visible = False
                Me.tplcustlist.Enabled = False
                If Cmbxspcatid.Items.Count > 0 Then
                    Cmbxspcatid.SelectedValue = DefltVatCst
                End If
                Me.CmbxWareh.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            xCustId_EditMode = SplrId '===For use in Edit mode at run time
            If Me.CmbxCarri.Items.Count > 0 Then
                Me.CmbxCarri.SelectedValue = xDynamic_Find_xAnItem_xInA_Table_1cond("SplrCarriid", "Splrid", SplrId, "FinactSplrmstr")
            End If

            Select_Salepircelst_where(Me.CmbxPlist, SplrId)

            If Me.CmbxPlist.Items.Count > 0 Then
                Dim xid As Integer = Select_Salepircelst_Maxid(SplrId)
                Me.CmbxPlist.SelectedValue = CInt(xid)
            Else
                Fill_Combobox_where_cond("spl_id", "spl_name", "spl_id", "Finact_SalePriceLstMstr", "SPL_DELSTATUS", CInt(1), CInt(1), Me.CmbxPlist)
                Me.CmbxPlist.SelectedIndex = 0
            End If

            If Me.DgSaleDirect.Rows.Count - 1 > 0 And Prvs_Splrid > 0 Then
                If Prvs_Splrid <> SplrId Then
                    ResetPriceList_AllGridItems()
                End If
            End If
            Dim xd As Integer = CInt(xBill_xDuedays("Finactsplrmstr", "splrnetday", "Splrid", SplrId))
            Me.DtpSaleDue.Value = Me.dtpordrdt.Value.AddDays(xd)


        End Try
    End Sub


    Private Sub TxtItmcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItmcode.Leave
        Try
            If Not LstIndx >= 0 Then
                Me.TxtItmcode.Focus()
                Me.TxtItmcode.SelectAll()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtItmcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtItmcode.TextChanged

        Try
            Dim ItmStr As String = Trim(TxtItmcode.Text)
            find_Item_list(ItmStr)
            For Each itm As ListViewItem In Me.LstVewItem.Items
                itm.BackColor = Color.White
                itm.ForeColor = Color.Black
            Next
            GoToItem(Me.LstVewItem, Me.TxtItmcode)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub LstVewItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.Click
        Try
            For Each itmx As ListViewItem In Me.LstVewItem.Items
                itmx.BackColor = Color.White
                itmx.ForeColor = Color.Black
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LstVewItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.DoubleClick
        Try
            LstIndx = Me.LstVewItem.SelectedItems(0).Index
            LstVewItemDoubleClick()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LstVewItem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.GotFocus
        Try
            Me.LstVewItem.Items(0).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewItem.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                If Me.LstVewItem.Items.Count > 0 Then
                    LstVewItem_DoubleClick(sender, e)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function validate_input_Duplicate() As Boolean
        Dim i, j As Integer
        If FrmShow_flag(8) = True Then
            For i = 0 To Me.DgSaleDirect.Rows.Count - 1
                For j = i + 1 To Me.DgSaleDirect.Rows.Count - 1
                    If Trim(Me.DgSaleDirect.Rows(i).Cells(1).Value) <> Nothing Then
                        If Trim(Me.DgSaleDirect.Rows(i).Cells(1).Value) = Trim(Me.DgSaleDirect.Rows(j).Cells(1).Value) Then ' And me.DgSaleDirect.Rows(i).Cells(2).Value = me.DgSaleDirect.Rows(j).Cells(2).Value Then
                            Return True
                        End If
                    End If
                Next
            Next
            Return False
        End If
        If FrmShow_flag(9) = True Then
            For i = 0 To Me.DgSaleDirect.Rows.Count - 1
                For j = i + 1 To Me.DgSaleDirect.Rows.Count - 1
                    If Trim(Me.DgSaleDirect.Rows(i).Cells(1).Value) <> Nothing Then
                        If Trim(Me.DgSaleDirect.Rows(i).Cells(1).Value) = Trim(Me.DgSaleDirect.Rows(j).Cells(1).Value) Then ' And me.DgSaleDirect.Rows(i).Cells(2).Value = me.DgSaleDirect.Rows(j).Cells(2).Value Then
                            Return True
                        End If
                    End If
                Next
            Next
            Return False
        End If
    End Function
    Private Function SumOf_In_and_Outward_Items(ByVal SalItemId As Integer, ByVal SaleItemId As Integer) As Double
        Try
            TpoCmd1 = New SqlCommand("Finact_Sum_In_out_Sale_Particularitem", FinActConn2)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@SaleItemId", SalItemId)
            'TpoCmd1.Parameters.AddWithValue("@Saleitmlocid", Me.CmbxWareh.SelectedValue)
            TpoRdr1 = TpoCmd1.ExecuteReader
            While TpoRdr1.Read
                If TpoRdr1.IsDBNull(1) = False Then
                    Alrdy_Ordr = TpoRdr1(1)
                Else
                    Alrdy_Ordr = 0
                End If
                If TpoRdr1.IsDBNull(0) = False Then
                    Return TpoRdr1(0)
                Else
                    Return 0
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd1.Dispose()
            TpoRdr1.Close()
        End Try
    End Function


    Private Sub BtnO_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSe_exit.Click
        Me.Close()
    End Sub

    Private Sub BtnPe_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSe_Save.Click

        Try
            If Me.CmbxLdgrHead.SelectedIndex = -1 Then
                MsgBox("Invalid Input! control having no value not allowed.", MsgBoxStyle.Critical, Me.Text)
                Me.CmbxLdgrHead.Focus()
                Exit Sub
            End If
            If Me.DgSaleDirect.Rows.Count > 0 Then
                If Me.DgSaleDirect.Rows(0).Cells(11).Value <> 1 And Me.DgSaleDirect.Rows(0).Cells(11).Value <> 2 Then
                    MsgBox("Invalid action", MsgBoxStyle.Critical, "No Row to save")
                    Exit Sub
                End If
            Else
                MsgBox("Invalid action", MsgBoxStyle.Critical, "No Row to save")
                Exit Sub
            End If

            Dim val1, val2, val3 As Double
            val1 = FormatNumber(Me.MTxtTotlamt.Text, 2)
            val2 = FormatNumber(Me.lblgross.Text, 2)
            val3 = FormatNumber(Me.LblRondOff.Text, 2)
            If FormatNumber(val1, 2) <> FormatNumber(val2 + val3, 2) Then

                MsgBox("Invoice amount does not match with Gross Amount", MsgBoxStyle.Critical, "Check Invoice Amount...")
                Me.DgSaleDirect.Focus()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure to update this record", "Salechase Entry Updating", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                BtnSe_Save.Focus()
                Return
            Else
                Cmbxspcatid_Leave(sender, e)
                SaleEntryupdate()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaleEntryupdate()
        If Me.DgSaleDirect.Rows.Count >= 1 Then
            Try
                TpoCmd = New SqlCommand("Finact_SaleEntry_Direct_Update", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@Saleentid", Selected_xInvoice_xId)
                TpoCmd.Parameters.AddWithValue("@Salebilstatus", Trim(Me.Cmbxstatus.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentduedt", Me.DtpSaleDue.Value)
                TpoCmd.Parameters.AddWithValue("@Saleenttotlamt", CDbl(Me.MTxtTotlamt.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentsplrid", SplrId)
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

                If Trim(Me.Mtxtdisvalue.Text) <> "" And Trim(Me.Cmbxdistype.Text) = "Discount Percentage" Then
                    TpoCmd.Parameters.AddWithValue("@Saleentdisrate", CDbl(Me.Mtxtdisvalue.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Saleentdisrate", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@Saleentdisvalue", CDbl(Me.lbldiscount.Text))
                TpoCmd.Parameters.AddWithValue("@SaleentAdnldis", CDbl(Me.LblAdlDis.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentadnldisrate", CDbl(Me.MskAdlDis.Text))

                TpoCmd.Parameters.AddWithValue("@Saleentvatrate", Me.Cmbxspcatid.SelectedValue)

                If (Me.mskTxtVAtCst.Text) > 0 Then
                    TpoCmd.Parameters.AddWithValue("@Saleentvatamt", CDbl(Me.LblVATCST.Text))
                    ''TpoCmd.Parameters.AddWithValue("@Saleentvatamt", CDbl(Me.mskTxtVAtCst.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Saleentvatamt", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@Saleentorderid", 0)
                TpoCmd.Parameters.AddWithValue("@SaleEntTxAbleAmt", CDbl(Me.LbltablAmt.Text))
                TpoCmd.Parameters.AddWithValue("@SaleEntVATSurChrg", CDbl(Me.LblSurCharg.Text))
                TpoCmd.Parameters.AddWithValue("@SaleEntRondOff", CDbl(Me.LblRondOff.Text))

                TpoCmd.Parameters.AddWithValue("@Saleentvatinvno", Trim(Me.TxtVatinvno.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentvatdt", Me.DtpInvvatdt.Value)
                TpoCmd.Parameters.AddWithValue("@Saleentinvamt", CDbl(Me.MskInvamt.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentinvvat", CDbl(Me.MskinvVat.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentpvtmrk", Trim(Me.TxtPvtMrk.Text))

                TpoCmd.Parameters.AddWithValue("@Saleentedtusrid", Current_UsrId)
                TpoCmd.Parameters.AddWithValue("@Saleentedtdt", Now)
                TpoCmd.Parameters.AddWithValue("@Saleplistid", Me.CmbxPlist.SelectedValue)
                If Me.RbAdnl1.Checked = True Then
                    TpoCmd.Parameters.AddWithValue("@SaleAdnlType", 0) '== 0 for Value
                Else
                    TpoCmd.Parameters.AddWithValue("@SaleAdnlType", 1) '== 1 for percentage
                End If
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
                TpoCmd.Parameters.AddWithValue("@SaleEntPONo", Me.TxtPono.Text.Trim)
                TpoCmd.Parameters.AddWithValue("@SaleEnt_UGRUP", CInt(Me.CmbxLdgrHead.SelectedValue))
                TpoCmd.ExecuteNonQuery()
            Catch ex As Exception

                MsgBox(ex.Message)

                Exit Sub
            Finally
                TpoCmd.Dispose()
            End Try

            ' Dim CurrPbillId As Integer = FindlastId(Trim(TxtSaleBillNo.Text), Trim(SplrId))
            Try
                Dim DgCntr As Integer
                For DgCntr = 0 To Me.DgSaleDirect.Rows.Count - 1
                    If Me.DgSaleDirect.Rows(DgCntr).Cells(11).Value = 1 Then
                        TpoCmd = New SqlCommand("Finact_Saleentry_Details_update", FinActConn)
                        TpoCmd.CommandType = CommandType.StoredProcedure
                        TpoCmd.Parameters.AddWithValue("@dSaleentconcrnid", Selected_xInvoice_xId)
                        ' TpoCmd.Parameters.AddWithValue("@dSaleent_con_dSaleid", 0)
                        TpoCmd.Parameters.AddWithValue("@dSaleentid", (Me.DgSaleDirect.Rows(DgCntr).Cells(6).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleentitmid", (Me.DgSaleDirect.Rows(DgCntr).Cells(7).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleentqntyissue", CDbl(Me.DgSaleDirect.Rows(DgCntr).Cells(0).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleentitmrate", CDbl(Me.DgSaleDirect.Rows(DgCntr).Cells(3).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleentlocid", Me.CmbxWareh.SelectedValue)
                        TpoCmd.Parameters.AddWithValue("@SaleEntCartNo", (Me.DgSaleDirect.Rows(DgCntr).Cells(9).Value))
                        TpoCmd.ExecuteNonQuery()
                    ElseIf Me.DgSaleDirect.Rows(DgCntr).Cells(11).Value = 2 Then
                        TpoCmd = New SqlCommand("Finact_Saleentry_Details_Insert", FinActConn)
                        TpoCmd.CommandType = CommandType.StoredProcedure
                        TpoCmd.Parameters.AddWithValue("@dSaleentconcrnid", Selected_xInvoice_xId)
                        TpoCmd.Parameters.AddWithValue("@dSaleent_con_dSaleid", 0)
                        TpoCmd.Parameters.AddWithValue("@dSaleentitmid", (Me.DgSaleDirect.Rows(DgCntr).Cells(7).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleentqntyissue", CDbl(Me.DgSaleDirect.Rows(DgCntr).Cells(0).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleentitmrate", CDbl(Me.DgSaleDirect.Rows(DgCntr).Cells(3).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleentlocid", Me.CmbxWareh.SelectedValue)
                        TpoCmd.Parameters.AddWithValue("@SaleEntCartNo", (Me.DgSaleDirect.Rows(DgCntr).Cells(9).Value))
                        TpoCmd.ExecuteNonQuery()
                    End If
                Next
                xUpdateFlag = False
                MsgBox("Current Record Has Been Updated Successfully", MsgBoxStyle.Information, "Update Record")
                Clear_Values()
                Me.Close()
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
            MsgBox("Invalid action! System could not found any record to update", MsgBoxStyle.Critical, "Empty Table")
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


    Private Sub TxtSaleBillNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSaleBillNo.GotFocus
        If MaxSplid > 0 Then
            Me.TxtSaleBillNo.Text = (MaxSplid + 1)
        End If

    End Sub

    Private Sub Txtcoment_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcoment.Leave
        If Me.Panel7.Enabled = False Then
            ' Me.Cmbxspcatid.Focus()
        End If
    End Sub
    Private Sub TxtinsCo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtinsCo.Leave
        Me.Cmbxspcatid.Focus()
    End Sub

    Private Sub Mtxtdisvalue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mtxtdisvalue.GotFocus
        Try
            Me.Mtxtdisvalue.SelectAll()
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
    Private Sub Clear_Values()
        Me.txtvCode.Clear()
        Me.TxtGrsWt.Clear()
        Me.TxtSaleBillNo.Clear()
        Me.TxtCariNo.Clear()
        Me.Txtcoment.Clear()
        Me.Txtgrno.Clear()
        Me.TxtinsCo.Clear()
        Me.TxtPlcyno.Clear()
        Me.TxtVname.Clear()
        Me.MTxtTotlamt.Clear()
        Me.MskInscharg.Clear()
        Me.Mskothrchrg.Clear()
        Me.MskPostcharg.Clear()
        Me.Mtxtdisvalue.Text = 0
        Me.MtxtfrtChargs.Clear()
        Me.MtxtPkgcharg.Clear()
        Me.mtxtulcharg.Clear()
        Me.lblsubttl.Text = 0
        Me.lbltoc.Text = 0
        Me.lbldiscount.Text = 0
        Me.lblgross.Text = 0
        'Me.DgSaleDirect.Rows.Clear()
        Me.mskTxtVAtCst.Text = 0
        Me.Label33.Visible = False
        Me.RbAdnl1.Visible = False
        Me.RbAdnl2.Visible = False
        Me.CmbxAdnlDis.Visible = False

    End Sub

    Private Function SumOf_Txtvalues() As Double
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
            Dim cond As String = ""
            If FrmShow_flag(11) = True Then
                cond = "Sale"
                Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", Cmbxspcatid, cond, "SPCATDELSTATUS", CInt(1))
                Dim Indxht As Integer = Cmbxspcatid.FindString(IntHtCmMm(11), 0)
                Cmbxspcatid.SelectedIndex = Indxht
            Else
                If Cmbxspcatid.Items.Count > 0 Then
                    Cmbxspcatid.SelectedValue = DefltVatCst
                    If Cmbxspcatid.SelectedIndex = -1 Then
                        Me.Cmbxspcatid.SelectedIndex = 0
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Cmbxspcatid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.Leave
        Try
            chk_Emptyvalue()
            If ErrIndx <> 0 Then
                ErrIndx = 0
                Me.DgSaleDirect.ReadOnly = True
                Exit Sub
            Else
                Me.DgSaleDirect.ReadOnly = False
            End If
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            If Me.Cmbxspcatid.SelectedValue > 0 Then
                Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))
            Else
                Me.Cmbxspcatid.SelectedValue = SpCid
            End If

            If_VAtrate_changed_then()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSpcatadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpcatadd.Click
        Dim frmvat As New FrmSalePurCatgry
        frmvat.ShowInTaskbar = False
        FrmShow_flag(11) = True
        frmvat.ShowDialog()
    End Sub

    Private Sub btnSpcatadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSpcatadd.GotFocus
        If FrmShow_flag(11) = True Then
            Me.Cmbxspcatid.Focus()
        End If
    End Sub

    Private Sub DgSaleDirect_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSaleDirect.CellEndEdit
        Try
            If e.ColumnIndex = 0 Or e.ColumnIndex = 3 Then
                Dim CurItemId As Integer = Trim(Me.DgSaleDirect.CurrentRow.Cells(7).Value)
                Dim CurSih As Double = SumOf_In_and_Outward_Items(CurItemId, CurItemId)
                Dim CurIndx As Integer = Me.DgSaleDirect.CurrentRow.Index
                Dim CurCode As String = Trim(Me.DgSaleDirect.CurrentRow.Cells(1).Value)
                If CurCode = Me.DgCode(CurIndx) Then
                    CurSih += Me.DgQnty(CurIndx)
                End If
                Me.lblSih.Text = FormatNumber(CurSih, 2)
                If Me.DgSaleDirect.CurrentRow.Cells(0).Value > CurSih Then
                    Me.DgSaleDirect.CurrentRow.Cells(0).ErrorText = "Negetive Stock"
                    Me.DgSaleDirect.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow
                    '' Me.DgSaleDirect.CurrentRow.HeaderCell.ErrorText = "Negetive Stock"
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub DgSaleDirect_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSaleDirect.CellEnter
        If e.ColumnIndex >= 0 Then
            Me.Tplitem.Visible = False
            Me.Tplitem.Enabled = False
            chk_Emptyvalue()
            If ErrIndx <> 0 Then
                ErrIndx = 0
                Me.DgSaleDirect.ReadOnly = True
                Exit Sub
            Else
                Me.DgSaleDirect.ReadOnly = False
            End If
        End If

        If e.ColumnIndex = 1 Then
            Me.Tplitem.Location = New System.Drawing.Point(268, 221)
            Me.Tplitem.Visible = True
            Me.Tplitem.Enabled = True

            SetCur_Dupli_vali = True
            Me.Tplitem.Focus()
            If IsDBNull(Me.DgSaleDirect.CurrentRow.Cells(1).Value) = False Then
                Me.TxtItmcode.Text = Trim(Me.DgSaleDirect.CurrentRow.Cells(1).Value)
                Me.TxtItmcode.Focus()
            End If
            If Cl_Kbl = True And xMACH_xBILLING = True Then
                Me.CmbxStokGrup.Enabled = True
                Me.CmbxStokGrup.Focus()

            Else
                Me.CmbxStokGrup.Enabled = False
                Me.TxtItmcode.Focus()
                Me.TxtItmcode.SelectAll()
            End If
        End If

        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 4 Then
            Me.DgSaleDirect.CurrentRow.Cells(e.ColumnIndex).ReadOnly = True
        End If

    End Sub

    Private Sub DgSaleDirect_CellErrorTextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSaleDirect.CellErrorTextChanged

    End Sub

    Private Sub DgSaleDirect_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgSaleDirect.CellValidating
        Dim Cr_Row As Integer = Me.DgSaleDirect.Rows.Count '- 1
        If Cr_Row <> Me.DgSaleDirect.CurrentRow.Index Then
            If e.ColumnIndex = 0 Or e.ColumnIndex = 3 Then
                If Not Double.TryParse(e.FormattedValue, Nothing) Then
                    Me.DgSaleDirect.CurrentCell.ErrorText = "Only Number are allowed"
                    e.Cancel = True
                Else
                    Me.DgSaleDirect.CurrentCell.ErrorText = ""
                    e.Cancel = False
                End If
            End If
        End If

    End Sub

    Private Sub DgSaleDirect_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSaleDirect.CellValueChanged
        Try
            If xFlag = True Then
                Dim val1, val2, val3, val4, val5, val6, val7 As Double
                val4 = 0
                If e.ColumnIndex = 0 Then
                    If (Me.DgSaleDirect.CurrentRow.Cells(0).Value) > 0 Then
                        If IsNumeric(Me.DgSaleDirect.CurrentRow.Cells(0).Value) Then
                            val1 = (Me.DgSaleDirect.CurrentRow.Cells(0).Value)
                        Else
                            val1 = 0
                        End If
                        val1 = (Me.DgSaleDirect.CurrentRow.Cells(0).Value)
                        If IsNumeric(Me.DgSaleDirect.CurrentRow.Cells(3).Value) Then
                            val2 = (Me.DgSaleDirect.CurrentRow.Cells(3).Value)
                        Else
                            val2 = 0
                        End If

                        val3 = val1 * val2
                        Me.DgSaleDirect.CurrentRow.Cells(5).Value = val3
                        Dim Rc As Integer
                        For Rc = 0 To Me.DgSaleDirect.Rows.Count - 1
                            If IsNumeric(Me.DgSaleDirect.Rows(Rc).Cells(5).Value) Then
                                val4 += (Me.DgSaleDirect.Rows(Rc).Cells(5).Value)  'Sub total
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
                            Me.mskTxtVAtCst.Text = FormatNumber((val4 - val5) * VATCST / 100, 2)
                            If IsNumeric(Me.mskTxtVAtCst.Text) Then
                                val6 = Me.mskTxtVAtCst.Text
                            Else
                                val6 = 0
                            End If

                            val7 = Me.lbltoc.Text
                            ''Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                            'End If
                        Next

                    End If
                End If
                If e.ColumnIndex = 3 Then
                    If (Me.DgSaleDirect.CurrentRow.Cells(3).Value) > 0 Then
                        If IsNumeric(Me.DgSaleDirect.CurrentRow.Cells(0).Value) Then
                            val1 = (Me.DgSaleDirect.CurrentRow.Cells(0).Value)
                        Else
                            val1 = 0
                        End If
                        val1 = (Me.DgSaleDirect.CurrentRow.Cells(0).Value)
                        If IsNumeric(Me.DgSaleDirect.CurrentRow.Cells(3).Value) Then
                            val2 = (Me.DgSaleDirect.CurrentRow.Cells(3).Value)
                        Else
                            val2 = 0
                        End If
                        val3 = val1 * val2
                        Me.DgSaleDirect.CurrentRow.Cells(5).Value = val3

                        Dim Rc As Integer
                        For Rc = 0 To Me.DgSaleDirect.Rows.Count - 1
                            If IsNumeric(Me.DgSaleDirect.Rows(Rc).Cells(5).Value) Then
                                val4 += (Me.DgSaleDirect.Rows(Rc).Cells(5).Value)  'Sub total
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
                            Me.mskTxtVAtCst.Text = FormatNumber((val4 - val5) * VATCST / 100, 2)
                            If IsNumeric(Me.mskTxtVAtCst.Text) Then
                                val6 = Me.mskTxtVAtCst.Text
                            Else
                                val6 = 0
                            End If

                            val7 = Me.lbltoc.Text
                            '' Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                            'End If
                        Next
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgSaleDirect_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgSaleDirect.EditingControlShowing

        If TypeOf e.Control Is TextBox Then
            Dim tb As TextBox = e.Control
            tb.AcceptsTab = True
        End If
    End Sub

    Private Sub DgSaleDirect_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgSaleDirect.KeyDown

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If Me.DgSaleDirect.CurrentCell.ColumnIndex = 3 Then
                Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(9, Me.DgSaleDirect.CurrentCell.RowIndex)
                Exit Sub
            End If
            If Me.DgSaleDirect.CurrentCell.ColumnIndex = 9 Then
                If Me.DgSaleDirect.CurrentRow.Cells(0).Value <> Nothing And Trim(Me.DgSaleDirect.CurrentRow.Cells(1).Value) <> Nothing And (Me.DgSaleDirect.CurrentRow.Cells(3).Value) <> Nothing Then
                    Dim Val1 As Double
                    Dim ic As String
                    ic = Me.DgSaleDirect.CurrentRow.Cells(1).Value

                    Val1 = Me.DgSaleDirect.CurrentRow.Cells(0).Value

                    If Not (Val1) > 0 Then
                        Me.DgSaleDirect.CurrentRow.Cells(0).ErrorText = "Value should be greater than zero"
                    Else

                        If Trim(Me.DgSaleDirect.CurrentRow.Cells(0).ErrorText) <> "" Then
                            MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                            Me.UpdateFlag = False
                            Exit Sub
                        Else
                            Me.UpdateFlag = True
                        End If
                        If Me.DgSaleDirect.CurrentRow.Index = Me.DgSaleDirect.Rows.Count - 1 Then
                            If MessageBox.Show("Do you want to add new item?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                Nrow = New DataGridViewRow
                                Me.DgSaleDirect.AllowUserToAddRows = True

                                ReDim DgQnty(Me.DgSaleDirect.RowCount - 1)
                                ReDim DgCode(Me.DgSaleDirect.RowCount - 1)
                                Dim rc As Integer = 0
                                For rc = 0 To Me.DgSaleDirect.Rows.Count - 2
                                    DgQnty(rc) = Me.DgSaleDirect.Rows(rc).Cells(0).Value
                                    DgCode(rc) = Me.DgSaleDirect.Rows(rc).Cells(1).Value
                                Next
                                Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentCell.RowIndex + 1)
                                Me.DgSaleDirect.CurrentCell.Value = 0
                            Else
                                Me.BtnSe_Save.Focus()
                            End If
                        Else
                            Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentCell.RowIndex + 1)
                        End If

                    End If
                End If

                If Me.DgSaleDirect.CurrentCell.RowIndex < Me.DgSaleDirect.RowCount - 1 Then
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentCell.RowIndex + 1)
                    Me.DgSaleDirect.CurrentCell.Value = 0

                End If
            Else
                Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(Me.DgSaleDirect.CurrentCell.ColumnIndex + 1, Me.DgSaleDirect.CurrentCell.RowIndex)
            End If
        End If
        e.Handled = True

    End Sub
    Private Sub chk_Emptyvalue()
        With Me.Cmbxspcatid
            If .SelectedIndex = -1 Then
                .SelectedValue = SpCid
            End If
        End With
        With MTxtTotlamt
            If Trim(.Text) = "" Then
                .BackColor = Color.Cyan
                '.Focus()
                ErrIndx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Me.TxtVname
            If Trim(.Text) = "" Then
                .BackColor = Color.Cyan
                '.Focus()
                ErrIndx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Me.txtvCode
            If Trim(.Text) = "" Then
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
    End Sub
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Me.BtnPe_Save_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.BtnO_exit_Click(sender, e)
    End Sub
    Private Sub mskTxtVAtCst_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.Leave
        If Chk_formatedvalue(mskTxtVAtCst) = False Then
            Exit Sub
        Else
            Dim val1, val2, val3, val4, val5 As Double
            val1 = 0
            val2 = 0
            val3 = 0
            val4 = 0
            val5 = 0
            val1 = CDbl(Me.lbldiscount.Text) + CDbl(Me.LblAdlDis.Text)
            val3 = Me.lbltoc.Text
            val4 = Me.lblsubttl.Text
            val2 = Me.mskTxtVAtCst.Text
            Me.lblgross.Text = FormatNumber((val4 + val2 + val3) - val1, 2)

        End If
    End Sub


    Private Function Fetch_vatname(ByVal Selval As Integer) As String
        Dim Vatname As String = ""
        Try

            TpoCmd = New SqlCommand("select spcatid, spcatname from finactSalepurCatgry where spcatid=@catid", FinActConn)
            TpoCmd.Parameters.AddWithValue("@catid", Selval)
            TpoRdr = TpoCmd.ExecuteReader
            TpoRdr.Read()
            If TpoRdr.IsDBNull(0) = False Then
                Vatname = Trim(TpoRdr(1))

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd.Dispose()
            TpoRdr.Close()

        End Try
        Return Vatname
    End Function


    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Me.mskTxtVAtCst.Focus()
        Me.mskTxtVAtCst.SelectAll()
    End Sub

    Private Sub CreateGridColumns_Saleentr_Edit()
        Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
        Dim CurrDate As Date
        Try
            TpoCmd1 = New SqlCommand("Finact_SaleEntry_Select_Where_id", FinActConn)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@InvoiceId", Selected_xInvoice_xId)
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.IsDBNull(0) = False Then
                Me.TxtSaleBillNo.Text = Trim(TpoRdr1("Saleentvno"))
                Me.MTxtTotlamt.Text = FormatNumber(TpoRdr1("Saleenttotlamt"), 2)
                Date.TryParse(TpoRdr1("Saleentdt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.dtpordrdt.MinDate = CurrDate
                Me.dtpordrdt.Value = CurrDate
                Me.Cmbxstatus.Text = Trim(TpoRdr1("Salebilstatus"))
                Date.TryParse(TpoRdr1("Saleentduedt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.DtpSaleDue.Value = CurrDate
                SplrId = Trim(TpoRdr1("Saleentsplrid"))
                Me.LblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(SplrId), Me.LblType), 2)
                Select_Salepircelst_where(Me.CmbxPlist, SplrId)
                If Me.CmbxPlist.Items.Count > 0 Then
                    Me.CmbxPlist.SelectedValue = CInt(TpoRdr1("Saleentplistid"))
                Else
                    Fill_Combobox_where_cond("spl_id", "spl_name", "spl_id", "Finact_SalePriceLstMstr", "SPL_DELSTATUS", CInt(1), CInt(1), Me.CmbxPlist)
                    Me.CmbxPlist.SelectedIndex = 0
                End If
                ''==========

                Me.txtvCode.Text = Trim(TpoRdr1("Splr_code"))
                Me.TxtVname.Text = Trim(TpoRdr1("splr_name"))
                Me.CmbxWareh.SelectedValue = TpoRdr1("Saleentlocid")
                Me.CmbxCarri.SelectedValue = TpoRdr1("Saleentcarri")
                Me.Txtcoment.Text = Trim(TpoRdr1("Saleentcoment"))
                Me.MtxtfrtChargs.Text = FormatNumber(TpoRdr1("Saleentfrtcharg"), 2)
                Me.Txtgrno.Text = TpoRdr1("Saleentgrno")
                Me.TxtCariNo.Text = TpoRdr1("Saleentcarino")
                Date.TryParse(TpoRdr1("Saleentgrdt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.Dtpgrdt.Value = CurrDate
                Me.mtxtulcharg.Text = FormatNumber(TpoRdr1("Saleentulcharg"), 2)
                Me.TxtGrsWt.Text = TpoRdr1("Saleentuload")
                Me.MtxtPkgcharg.Text = FormatNumber(TpoRdr1("Saleentpkgcharg"), 2)
                Me.MskPostcharg.Text = FormatNumber(TpoRdr1("Saleentpostcharg"), 2)
                Me.Mskothrchrg.Text = FormatNumber(TpoRdr1("Saleentothrcharg"), 2)
                Me.MskInscharg.Text = FormatNumber(TpoRdr1("Saleentinscharg"), 2)
                Me.TxtPlcyno.Text = TpoRdr1("Saleentpolcyno")
                Me.TxtinsCo.Text = TpoRdr1("Saleentinsco")
                Me.Cmbxdistype.Text = TpoRdr1("Saleentdistype")


                DisVal = TpoRdr1("Saleentdisrate")

                If DisVal > 0 Then
                    Me.Chkbdisc.Checked = True
                    Me.RbAdnl1.Visible = True
                    Me.RbAdnl2.Visible = True
                    Me.CmbxAdnlDis.Visible = True
                    Me.Label33.Visible = True
                    Me.Cmbxdistype.SelectedIndex = 1
                Else
                    Me.Chkbdisc.Checked = False
                    Me.RbAdnl1.Visible = False
                    Me.RbAdnl2.Visible = False
                    Me.CmbxAdnlDis.Visible = False
                    Me.Label33.Visible = False
                    Me.Cmbxdistype.SelectedIndex = 0
                End If
                Me.Mtxtdisvalue.Text = FormatNumber(TpoRdr1("Saleentdisrate"), 2)
                Me.lbldiscount.Text = FormatNumber(TpoRdr1("Saleentdisvalue"), 2) '

                Me.LblAdlDis.Text = FormatNumber(TpoRdr1("SaleentAdnlDis"), 2) '
                Me.MskAdlDis.Text = FormatNumber(TpoRdr1("SaleentAdnlDisRate"), 2) '
                Me.Cmbxspcatid.SelectedValue = TpoRdr1("Saleentvatrate")
                Me.mskTxtVAtCst.Text = FormatNumber(TpoRdr1("Saleentvatamt"), 2)
                Me.lblgross.Text = FormatNumber(TpoRdr1("Saleenttotlamt"), 2)
                Me.lblsubttl.Text = FormatNumber(TpoRdr1("Saleentdisonamt"), 2)
                Me.TxtVatinvno.Text = TpoRdr1("Saleentvatinvno")
                Me.DtpInvvatdt.Value = TpoRdr1("Saleentinvvatdt")
                Me.MskInvamt.Text = FormatNumber(TpoRdr1("Saleentinvamt"), 2)
                Me.MskinvVat.Text = FormatNumber(TpoRdr1("Saleentinvvat"), 2)
                Me.TxtPvtMrk.Text = TpoRdr1("Saleentpvtmrk")
                Dim xAdnlDisType As Boolean = TpoRdr1("SaleentAdnlDisType")
                If xAdnlDisType = True Then
                    Me.RbAdnl2.Checked = True
                Else
                    Me.RbAdnl1.Checked = True
                End If
                Me.CmbxAdnlDis.Text = TpoRdr1("SaleentAdnlDisNarr")
                Me.CmbxAgent.SelectedValue = CInt(TpoRdr1("SaleEntAgntId"))
                Dim xFrgt As Integer = CInt(TpoRdr1("SaleEntFrgtType"))
                If xFrgt = 0 Then
                    Me.Rb2pay.Checked = True
                Else
                    Me.Rbpaid.Checked = True
                End If
                Me.TxtPono.Text = Trim(TpoRdr1("SaleentPONo"))
                Me.CmbxLdgrHead.SelectedValue = CInt(TpoRdr1("SaleEnt_UGRUP"))
            End If




        Catch ex As Exception
            MsgBox(ex.Message)
            TpoCmd1.Dispose()
            TpoRdr1.Close()
            Exit Sub
        Finally
            TpoCmd1.Dispose()
            TpoRdr1.Close()
        End Try
        Try
            Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))
            Dim DgItms As DataGridView
            DgItms = Me.DgSaleDirect
            DgItms.Columns.Clear()
            TpoCmd1 = New SqlCommand("Finact_Saleentry_Details_Where_Concrnid", FinActConn1)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@SaleentConcrnid", Selected_xInvoice_xId)

            TpoAdptr = New Data.SqlClient.SqlDataAdapter(TpoCmd1)
            dtaset = New Data.DataSet()
            TpoAdptr.Fill(dtaset, "finactSaleentry_details")
            DgItms.DataSource = dtaset.Tables("finactSaleentry_details")
            ' DgItms.Columns.Add("ColQnty", "Quantity")
            '0
            DgItms.Columns(0).HeaderText = "Quantity"
            DgItms.Columns(0).Name = "ColQnty"
            Dim dt As DataGridViewTextBoxColumn = TryCast(DgItms.Columns(0), DataGridViewTextBoxColumn)
            dt.MaxInputLength = 10
            DgItms.Columns(0).Width = 100
            DgItms.Columns(0).DefaultCellStyle.Format = "N3"
            DgItms.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(0).DefaultCellStyle.NullValue = Nothing
            '1
            'DgItms.Columns.Add("ColItemid", "Item Code")
            DgItms.Columns(1).HeaderText = "Item Code"
            DgItms.Columns(1).Name = "ColItemid"
            DgItms.Columns(1).Width = 100
            DgItms.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '2
            'DgItms.Columns.Add("ColDiscription", "Item Name")
            DgItms.Columns(2).HeaderText = "Discription"
            DgItms.Columns(2).Name = "ColDiscription"
            DgItms.Columns(2).Width = 180
            '3
            ' DgItms.Columns.Add("colCost", "Rate")
            DgItms.Columns(3).HeaderText = "Rate"
            DgItms.Columns(3).Name = "colCost"
            DgItms.Columns(3).Width = 100
            DgItms.Columns(3).DefaultCellStyle.Format = "N2"
            DgItms.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(3).DefaultCellStyle.NullValue = Nothing
            '4
            'DgItms.Columns.Add("ColUnittype", "Unit Type")
            DgItms.Columns(4).HeaderText = "Unit Type"
            DgItms.Columns(4).Name = "ColUnittype"
            DgItms.Columns(4).Width = 60
            DgItms.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '5
            ' DgItms.Columns.Add("colAmt", "Amount")
            DgItms.Columns(5).HeaderText = "Amount"
            DgItms.Columns(5).Name = "colAmt"
            DgItms.Columns(5).Width = 145
            DgItms.Columns(5).DefaultCellStyle.Format = "N2"
            DgItms.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '6
            'DgItms.Columns.Add("ColITmId", "Item id")
            DgItms.Columns(6).HeaderText = "Item id"
            DgItms.Columns(6).Name = "ColITmId"
            DgItms.Columns(6).Width = 100
            DgItms.Columns(6).Visible = False
            '7
            '  DgItms.Columns.Add("CoICode", "Item Code")
            DgItms.Columns(7).HeaderText = "Item Code"
            DgItms.Columns(7).Name = "CoICode"
            DgItms.Columns(7).DefaultCellStyle.Format.ToString()
            DgItms.Columns(7).Width = 100
            DgItms.Columns(7).Visible = False
            '8
            'DgItms.Columns.Add("ColStatus", "itemcode")
            DgItms.Columns(8).HeaderText = "Item con-Code"
            DgItms.Columns(8).Name = "ColStatus"
            DgItms.Columns(8).Width = 100
            DgItms.Columns(8).Visible = False
            DgItms.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            '9 Carton No.
            Me.DgSaleDirect.Columns.Add("xCrtNo", "Carton No.")
            Me.DgSaleDirect.Columns(9).Width = 85
            Me.DgSaleDirect.Columns(9).ReadOnly = False

            DgItms.Columns.Add("ColInStok", "Sotck In Hand")
            DgItms.Columns(10).Width = 0
            DgItms.Columns(10).Visible = False
            DgItms.Columns(10).DefaultCellStyle.Format = "N3"
            DgItms.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(10).DefaultCellStyle.NullValue = Nothing

            DgItms.Columns.Add("ColresStok", "Edit Flag")
            DgItms.Columns(11).Width = 0
            DgItms.Columns(11).ReadOnly = True
            DgItms.Columns(11).Visible = False

            Dim rc As Integer = 0
            ReDim DgQnty(Me.DgSaleDirect.RowCount - 1)
            ReDim DgCode(Me.DgSaleDirect.RowCount - 1)
            For rc = 0 To Me.DgSaleDirect.Rows.Count - 1
                Me.DgSaleDirect.Rows(rc).Cells(11).Value = 1 '1 is  satand for already existed record.
                DgQnty(rc) = Me.DgSaleDirect.Rows(rc).Cells(0).Value
                DgCode(rc) = Me.DgSaleDirect.Rows(rc).Cells(1).Value
            Next

            DgItms.MultiSelect = False
            DgItms.AllowUserToDeleteRows = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd1.Dispose()
            TpoAdptr.Dispose()
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            Dim xcol As Integer = Me.DgSaleDirect.ColumnCount - 1
            Me.DgSaleDirect.Columns(xcol).Visible = False
            Me.DgSaleDirect.Focus()

        End Try
    End Sub

    Private Sub DgSaleDirect_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DgSaleDirect.UserAddedRow
        If e.Row.IsNewRow Then
            ' Me.DgSaleDirect.Rows.RemoveAt(Me.DgSaleDirect.CurrentCell.RowIndex + 1)
            Me.DgSaleDirect.AllowUserToAddRows = False
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        If Me.DgSaleDirect.SelectedRows.Count = 1 Then
            If Me.DgSaleDirect.Rows.Count > 1 Then
                If MessageBox.Show("It will remove this record permanently. Are you sure to delete this row?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    xUpdateFlag = False
                    Return
                Else
                    Try
                        TpoCmd = New SqlCommand("delete from finactSaleentry_details where dSaleentid=@Selctdid", FinActConn1)
                        TpoCmd.Parameters.AddWithValue("@selctdid", Me.DgSaleDirect.SelectedRows(0).Cells(6).Value)
                        TpoCmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        TpoCmd.Dispose()
                        If Me.DgSaleDirect.CurrentRow.IsNewRow = False Then
                            Me.DgSaleDirect.Rows.RemoveAt(Me.DgSaleDirect.CurrentRow.Index)
                        Else
                            MsgBox("Invalid action", MsgBoxStyle.Critical, "Uncommitted row can't be deleted!")
                        End If

                    End Try
                End If
            Else
                MsgBox("Atleast one record should be remained with this invoice", MsgBoxStyle.Critical, "Only One Record Left")
                Exit Sub
            End If
        Else
            MsgBox("Select an item to delete", MsgBoxStyle.Information, "No Item Selected")
            Me.DgSaleDirect.Focus()
        End If
    End Sub

    Private Sub LstVewItem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.Leave
        Try
            If Me.LstVewItem.Items.Count > 0 Then
                LstVewItem_DoubleClick(sender, e)
            Else
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
                Me.Tplitem.Location = New System.Drawing.Point(837, 243)
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub GoToItem(ByVal LsV As ListView, ByVal Txt As TextBox)
        Try
            Dim itmX As ListViewItem = LsV.FindItemWithText(Trim(Txt.Text), True, 0)
            If Not itmX Is Nothing Then
                itmX.Selected = True
                LstIndx = itmX.Index
                LsV.Items(itmX.Index).Selected = True
                LsV.Items(itmX.Index).BackColor = Color.Blue
                LsV.Items(itmX.Index).ForeColor = Color.White
                itmX.EnsureVisible()
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message) do not uncomment it
            LstIndx = -1
        End Try
    End Sub
    Private Sub If_VAtrate_changed_then()
        Try
            ' lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            ' Fetch_vatrate(cint(Me.Cmbxspcatid.SelectedValue ))
            Dim val4, val5, val6, val7 As Double
            val4 = 0
            Dim Rc As Integer
            If Me.DgSaleDirect.Rows.Count > 0 Then
                For Rc = 0 To Me.DgSaleDirect.Rows.Count - 1
                    If IsNumeric(Me.DgSaleDirect.Rows(Rc).Cells(5).Value) Then
                        val4 += (Me.DgSaleDirect.Rows(Rc).Cells(5).Value)  'Sub total
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
                    val5 = val5 + CDbl(Me.LblAdlDis.Text)
                    Me.lblsubttl.Text = FormatNumber(val4, 2)
                    Me.mskTxtVAtCst.Text = FormatNumber((val4 - val5) * VATCST / 100, 2)
                    If IsNumeric(Me.mskTxtVAtCst.Text) Then
                        val6 = Me.mskTxtVAtCst.Text
                    Else
                        val6 = 0
                    End If
                    val7 = Me.lbltoc.Text
                    'Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Cmbxdistype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxdistype.TextChanged
        'Me.Mtxtdisvalue.Text = 0
        'Me.lbldiscount.Text = 0
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
            If Me.Panel8.Enabled = False Then
                Me.DgSaleDirect.Focus()
                If Me.DgSaleDirect.Rows.Count = 0 Then
                    Nrow = New DataGridViewRow
                    Me.DgSaleDirect.Rows.Add()
                End If
                Dim rx As Integer = Me.DgSaleDirect.Rows.Count - 1
                Me.DgSaleDirect.Rows(rx).Cells(0).Selected = True
            Else
                Me.Cmbxdistype.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Select_Salepircelst_where(ByVal xCombobox As ComboBox, ByVal Spl_Splrid As Integer)
        Dim xStr As String = "Finact_SalePriceList_Select"
        Try
            TpoCmd = New SqlCommand(xStr, FinActConn2)
            TpoCmd.CommandType = CommandType.StoredProcedure
            TpoCmd.Parameters.AddWithValue("@AtchSplid", Spl_Splrid)
            TpoAdptr = New SqlDataAdapter(TpoCmd)
            TpoDtSet = New DataSet(TpoCmd.CommandText)
            TpoDtSet.Tables.Clear()
            TpoAdptr.Fill(TpoDtSet)
            xCombobox.DataSource = TpoDtSet.Tables(0)
            xCombobox.ValueMember = "spl_id"
            xCombobox.DisplayMember = "spl_name"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd.Dispose()
            TpoAdptr.Dispose()
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

    Private Sub CmbxPlist_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPlist.SelectionChangeCommitted
        Try
            ResetPriceList_AllGridItems()
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

    Private Sub ChkBx1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBx1.CheckedChanged
        Try
            If Me.ChkBx1.Checked = True Then
                xCust_Vend = True
            Else
                xCust_Vend = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '===============
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

    Private Sub allControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkbCariDetals.KeyDown _
     , ChkbOthrCharg.KeyDown, ChkVatInfo.KeyDown, CmbxCarri.KeyDown, Cmbxdistype.KeyDown, CmbxPlist.KeyDown, Cmbxspcatid.KeyDown _
     , Cmbxstatus.KeyDown, CmbxWareh.KeyDown, Dtpgrdt.KeyDown, DtpInvvatdt.KeyDown, dtpordrdt.KeyDown, DtpSaleDue.KeyDown, MskInscharg.KeyDown, MskInvamt.KeyDown, MskinvVat.KeyDown _
     , Mskothrchrg.KeyDown, MskPostcharg.KeyDown, mskTxtVAtCst.KeyDown, TxtCariNo.KeyDown _
     , Txtgrno.KeyDown, TxtinsCo.KeyDown, TxtinsCo.KeyDown, TxtPlcyno.KeyDown, TxtPvtMrk.KeyDown, TxtSaleBillNo.KeyDown, TxtGrsWt.KeyDown _
     , TxtVatinvno.KeyDown, txtvCode.KeyDown, TxtVname.KeyDown, Rbxcode.KeyDown, Rbxicode.KeyDown, RbxiName.KeyDown, RbxName.KeyDown _
     , Mtxtdisvalue.KeyDown, MtxtfrtChargs.KeyDown, MtxtPkgcharg.KeyDown, MTxtTotlamt.KeyDown, mtxtulcharg.KeyDown, TxtPono.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
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


    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSe_Save.GotFocus, BtnSe_exit.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSe_Save.Leave, BtnSe_exit.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkbCariDetals_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbCariDetals.CheckedChanged
        Try
            If Len(Me.txtvCode.Text.Trim) = 0 Then
                Me.ChkbCariDetals.CheckState = CheckState.Unchecked
                Me.txtvCode.Focus()
                Exit Sub
            End If
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
        Try
            If Len(Me.txtvCode.Text.Trim) = 0 Then
                Me.ChkbOthrCharg.CheckState = CheckState.Unchecked
                Me.txtvCode.Focus()
                Exit Sub
            End If
            If Me.ChkbOthrCharg.Checked = True Then
                Me.Panel7.Enabled = True
                Me.MtxtPkgcharg.Focus()
            Else
                Me.Panel7.Enabled = False
                OnOthrChkBxFalse()
                Me.Cmbxspcatid.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Chkbdisc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkbdisc.CheckedChanged
        Try
            If Len(Me.txtvCode.Text.Trim) = 0 Then
                Me.Chkbdisc.CheckState = CheckState.Unchecked
                Me.txtvCode.Focus()
                Exit Sub
            End If
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
            Me.LbltablAmt.Text = FormatNumber(CDbl(Me.lblsubttl.Text) - (CDbl(CDbl(Me.lbldiscount.Text) + CDbl(Me.LblAdlDis.Text))), 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MskAdlDis_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MskAdlDis.GotFocus
        Try
            Me.MskAdlDis.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MskAdlDis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MskAdlDis.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.MskAdlDis_Leave(sender, e)
            End If
        Catch ex As Exception

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
    Private Function Chk_formatedvalue(ByVal MskTxt As MaskedTextBox) As Boolean
        Try
            If Len(MskTxt.Text.Trim) = 0 Then MskTxt.Text = 0
            If IsNumeric(MskTxt.Text) = True Then
                MskTxt.Text = FormatNumber(MskTxt.Text, 2)
                Return True
            Else
                MskTxt.Focus()
                MskTxt.SelectAll()
                Return False
            End If
        Catch ex As Exception

        End Try

    End Function

    Private Sub Chkbdisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkbdisc.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Chkbdisc_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mskTxtVAtCst_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.TextChanged
        Try
            Dim xV As Double = CDbl(Me.mskTxtVAtCst.Text)

            Dim xSur As Double = xCal_xInvoiceSurCharge(Me.Cmbxspcatid.SelectedValue, xV, Me.Label40)
            ''Select Case xCheckxSalePur_VATStatus(xSalxPurxType)
            ''    Case 1 '==SurCharge applicable.
            ''        xSur = Math.Round(xV * 10 / 100, 3)
            ''        Me.Label40.Text = "Surcharge (10%)"
            ''    Case 2 '==SurCharge and Labour Charges Applicable.
            ''        Me.Label40.Text = "Surcharge (10%)"
            ''    Case 3 '==Labour Charges Applicable (InterStates).
            ''        Me.Label40.Text = "Surcharge (0%)"
            ''    Case Else
            ''        xSur = Math.Round(0, 3)
            ''        Me.Label40.Text = "Surcharge (0%)"
            ''End Select
            Me.LblVATCST.Text = FormatNumber(Math.Round(xV, 3), 2)
            Me.LblSurCharg.Text = FormatNumber(xSur, 2)
            Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xAllContrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkbCariDetals.GotFocus, Chkbdisc.GotFocus, ChkbOthrCharg.GotFocus, Chkprnt.GotFocus, CmbxCarri.GotFocus, CmbxWareh.GotFocus _
    , Cmbxstatus.GotFocus, MTxtTotlamt.GotFocus
        Try
            Dim xx As Control = CType(sender, Control)
            xx.BackColor = Color.Yellow
        Catch ex As Exception

        End Try

    End Sub
    Private Sub xAllContrl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkbCariDetals.Leave, Chkbdisc.Leave, ChkbOthrCharg.Leave, Chkprnt.Leave, CmbxCarri.Leave, CmbxWareh.Leave _
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
                If Not Len(MskAdlDis.Text) = 0 Then
                    If Me.lbldiscount.Text > 0 Then
                        Dim xamt As Double = Me.lblsubttl.Text
                        Dim xdis As Double = Me.lbldiscount.Text
                        Dim xAdis As Double = Me.MskAdlDis.Text
                        Dim xBal As Double = xamt - xdis
                        Dim xAdl As Double = 0
                        If Me.RbAdnl2.Checked = True Then
                            xAdl = xBal * xAdis / 100
                        Else
                            xAdl = xAdis
                        End If
                        Me.LblAdlDis.Text = FormatNumber(xAdl, 2)
                        Me.mskTxtVAtCst.Text = FormatNumber(((xBal - xAdl) * VATCST / 100), 2)
                        Dim xgrs As Double = xBal + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text)
                        Me.lblgross.Text = FormatNumber(xgrs - xAdl, 2)
                    End If
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
                Me.txtvCode.Text = 0
                Me.TxtVname.Text = ""
                Me.dtpordrdt.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtvCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvCode.TextChanged
        Try
            If Len(txtvCode.Text) > 0 Then
                Me.BtnEditmode.Enabled = True
            Else
                Me.BtnEditmode.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxStokGrup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.GotFocus
        Try
            '  Me.LstVewItem.Clear()
            Me.CmbxStokGrup.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxStokGrup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxStokGrup.KeyDown

    End Sub

    Private Sub CmbxStokGrup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxStokGrup) = True Then
                If CmbxStokGrup.SelectedIndex = 0 Then
                    Dim ItmStr As String = Trim(TxtItmcode.Text)
                    find_Item_list(ItmStr)
                End If
                'Me.TxtItmcode.Text = ""
                Me.TxtItmcode.Focus()
                Me.TxtItmcode.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxStokGrup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxStokGrup.SelectedIndexChanged
        Try
            If CmbxStokGrup.SelectedIndex > 0 Then
                Dim ItmStr As String = Trim(TxtItmcode.Text)
                find_Item_list(ItmStr)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            If Len(Me.DgSaleDirect.Rows(0).Cells(0).Value) > 0 Then
                FrmShow_flag(3) = True
                xCall_LinkFrmDgVew(FrmStokItm, Me.DgSaleDirect)
            Else

                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LbltablAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbltablAmt.TextChanged
        Try
            If Len(lbltoc.Text.Trim) = 0 Then
                Me.lbltoc.Text = 0
            End If
            Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Btnundrgrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnundrgrp.Click
        Try
            xCall_LinkFrm(FrmActMstr, Me.CmbxLdgrHead)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxLdgrHead_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxLdgrHead.GotFocus
        Try
            If xCmbxRefresh = True Then
                Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRUNDRGRUP", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), CInt(10), Me.CmbxLdgrHead)
            End If
            Me.CmbxLdgrHead.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxLdgrHead_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxLdgrHead.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxLdgrHead_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxLdgrHead_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxLdgrHead.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxLdgrHead) = True Then
                '   Me.txtvCode.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
End Class




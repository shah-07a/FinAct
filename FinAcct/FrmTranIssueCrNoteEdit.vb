Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
'Imports FinAcct.cLSmYgrid
Public Class FrmTranIssuecrNoteEdit
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
    Dim ErrIndx, SpCid As Integer
    Dim DisVal As Double
    Dim LstIndx As Integer = 0
    Dim xTptId As Integer = 0
    Dim TpoDtSet As DataSet
    Dim Alrdy_Ordr As Double
    Dim CurItemLocId1 As Integer = 0
    Dim xExl_MxDt As Date
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim SaveFlag1 As Boolean
    Dim xxSelRowIndx As Integer
    Dim xRondOff As Double = 0
    Dim xVatRtrnStatus As Boolean = False


    Private Sub FrmTranSaleOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.Width = 834
            Me.Height = 640
            Me.Top = 0
            Me.Left = 0
            Me.SplitContainer1.SplitterDistance = 560
            Me.SplitContainer1.IsSplitterFixed = True
            Me.ChkBx1.Checked = False
            Me.Text = Me.Text.Trim & "  " & Trim(Current_UserName) & "  " & Trim(Current_UserDesi)
            Select_2rec_with_where(Me.CmbxWareh, SplrId)
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)

            Dim cond As String = "Purchase"
            Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", Cmbxspcatid, cond, "SPCATDELSTATUS", CInt(1))
            Dim CurOrderNo As Integer = Curr_MaxId()
            Me.TxtSaleBillNo.Text = (CurOrderNo + 5000)
            If Curr_MaxId() > 0 Then
                Me.dtpordrdt.MinDate = Curr_Maxdate()
            Else
                Me.dtpordrdt.MinDate = FinStartDt.Date
            End If
            Me.dtpordrdt.MaxDate = FinEnddt.Date

            CreateGridColumns_Purentr_Edit()

            Dim tStr As String = Trim(Txtcustcode.Text)
            find_Customer_list(tStr)

            Dim ItmStr As String = Trim(TxtItmcode.Text)
            find_Item_list(ItmStr)
            xVatRtrnStatus = xxVATrtrnStatus("SBR_Entid", "SBRVATrtrnFlg", Selected_xInvoice_xId, "FinactSaleItemBackRecdEntry")
            If xVatRtrnStatus = True Then
                Me.Panel1.Enabled = False
                Me.Panel5.Enabled = False
                Me.SplitContainer1.Panel2.Enabled = False
                Me.DgSaleDirect.ReadOnly = True
                Me.txtlbltot.ReadOnly = True
                Me.ContxtDg1.Enabled = False
                Me.Text = Me.Text & "   == ONLY VIEW MODE AS CURRENT RECORD HAS A RELATION WITH VAT RETURN== "
            Else
                Me.Panel1.Enabled = True
                Me.Panel5.Enabled = True
                Me.SplitContainer1.Panel2.Enabled = True
                Me.DgSaleDirect.ReadOnly = False
                Me.txtlbltot.ReadOnly = False
                Me.ContxtDg1.Enabled = True
            End If
            FrmShow_flag(23) = False

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub AllControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkprnt.KeyDown _
   , ChkVatInfo.KeyDown, CmbxCarri.KeyDown, Cmbxdistype.KeyDown, Cmbxspcatid.KeyDown, CmbxWareh.KeyDown, DtpInvvatdt.KeyDown, dtpordrdt.KeyDown _
   , DtpSaleDue.KeyDown, MskInvamt.KeyDown, MskinvVat.KeyDown, mskTxtVAtCst.KeyDown, Mtxtdisvalue.KeyDown, MTxtTotlamt.KeyDown, Rbxcode.KeyDown, Rbxicode.KeyDown _
   , RbxiName.KeyDown, RbxName.KeyDown, Txtcoment.KeyDown, txtlbltot.KeyDown, TxtSaleBillNo.KeyDown, TxtVatinvno.KeyDown, txtvCode.KeyDown, TxtVname.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CreateGridColumns_Purentr_Edit()
        Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
        Dim CurrDate As Date
        Try
            TpoCmd1 = New SqlCommand("Finact_FinactPurItemBackRecdEntry_Select_Where_id", FinActConn1)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@InvoiceId", Selected_xInvoice_xId)
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.IsDBNull(0) = False Then
                Me.TxtSaleBillNo.Text = Trim(TpoRdr1("SBR_entvno"))
                Me.MTxtTotlamt.Text = FormatNumber(TpoRdr1("SBR_enttotlamt"), 2)
                Date.TryParse(TpoRdr1("SBR_entdt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.dtpordrdt.MinDate = CurrDate
                Me.dtpordrdt.Value = CurrDate
                SplrId = Trim(TpoRdr1("SBR_entsplrid"))
                Me.txtvCode.Text = Trim(TpoRdr1("splrsurfix"))
                Me.TxtVname.Text = Trim(TpoRdr1("splrname"))
                Me.CmbxWareh.SelectedValue = TpoRdr1("SBR_entlocid")
                Me.CmbxCarri.SelectedValue = TpoRdr1("SBR_entcarri")
                Me.Txtcoment.Text = Trim(TpoRdr1("SBR_entcoment"))
                Me.txtlbltot.Text = FormatNumber(TpoRdr1("SBR_entothrcharg"), 2)


                DisVal = TpoRdr1("SBR_entdisrate")

                If DisVal > 0 Then
                    Me.Chkbdisc.Checked = True
                Else
                    Me.Chkbdisc.Checked = False
                End If
                Me.Cmbxdistype.Text = TpoRdr1("SBR_entdistype")
                Me.Mtxtdisvalue.Text = TpoRdr1("SBR_entdisrate")
                Me.lbldiscount.Text = TpoRdr1("SBR_entdisvalue") '
                ' Dim SelVatname As Integer = Me.Cmbxspcatid.FindString(Trim(Fetch_vatname()), 0)
                Me.Cmbxspcatid.SelectedValue = TpoRdr1("SBR_entvatrate")
                Me.mskTxtVAtCst.Text = TpoRdr1("SBR_entvatamt")
                Me.lblsubttl.Text = TpoRdr1("SBR_entdisonamt")
                Me.TxtVatinvno.Text = TpoRdr1("SBR_entvatinvno")
                Me.DtpInvvatdt.Value = TpoRdr1("SBR_entinvvatdt")
                Me.MskInvamt.Text = TpoRdr1("SBR_entinvamt")
                Me.MskinvVat.Text = TpoRdr1("SBR_entinvvat")


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

            TpoCmd1 = New SqlCommand("Finact_FinactPurItemBackRecdEntry_Details__Where_Concrnid", FinActConn1)
            TpoCmd1.Parameters.AddWithValue("@SaleentConcrnid", Selected_xInvoice_xId)


            TpoCmd1.CommandType = CommandType.StoredProcedure


            TpoAdptr = New Data.SqlClient.SqlDataAdapter(TpoCmd1)
            dtaset = New Data.DataSet()
            TpoAdptr.Fill(dtaset, "FinactPurItemBackRecdEntry_Details")
            DgItms.DataSource = dtaset.Tables("FinactPurItemBackRecdEntry_Details")

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
            DgItms.Columns(2).Width = 260
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
            DgItms.Columns(5).Width = 150
            DgItms.Columns(5).DefaultCellStyle.Format = "N2"
            DgItms.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '6
            'DgItms.Columns.Add("ColITmId", "Item id") 
            DgItms.Columns(6).HeaderText = "Item id" 'recid
            DgItms.Columns(6).Name = "ColITmId"
            DgItms.Columns(6).Width = 100
            DgItms.Columns(6).Visible = False

            '  DgItms.Columns.Add("CoICode", "Item Code")
            DgItms.Columns(7).HeaderText = "Item Code"
            DgItms.Columns(7).Name = "CoICode"
            DgItms.Columns(7).DefaultCellStyle.Format.ToString()
            DgItms.Columns(7).Width = 100
            DgItms.Columns(7).Visible = False

            'DgItms.Columns.Add("ColStatus", "itemcode")
            DgItms.Columns(8).HeaderText = "Item con-Code"
            DgItms.Columns(8).Name = "ColStatus"
            DgItms.Columns(8).Width = 100
            DgItms.Columns(8).Visible = False
            DgItms.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DgItms.Columns.Add("ColInStok", "Sotck In Hand")
            ''DgItms.Columns(9).HeaderText = "Sotck In Hand"
            ''DgItms.Columns(9).Name = "ColInStok"
            DgItms.Columns(9).Width = 0
            DgItms.Columns(9).Visible = False
            DgItms.Columns(9).DefaultCellStyle.Format = "N3"
            DgItms.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(9).DefaultCellStyle.NullValue = Nothing

            DgItms.Columns.Add("ColresStok", "Edit Flag")
            DgItms.Columns(10).HeaderText = "Edit Flag"
            'DgItms.Columns(10).Name = "ColresStok"
            DgItms.Columns(10).Width = 10
            DgItms.Columns(10).Visible = False
            'DgItms.Columns(10).DefaultCellStyle.Format = "No"
            DgItms.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DgItms.Columns(10).DefaultCellStyle.NullValue = Nothing
            Dim rc As Integer = 0
            For rc = 0 To Me.DgSaleDirect.Rows.Count - 1
                Me.DgSaleDirect.Rows(rc).Cells(10).Value = 1 '1 is  satand for already existed record.
            Next
            DgItms.MultiSelect = False
            DgItms.AllowUserToDeleteRows = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd1.Dispose()
            TpoAdptr.Dispose()
            Me.DgSaleDirect.Focus()

        End Try
    End Sub
    Private Sub find_Customer_list(ByVal CurString As String)

        Dim i, splrid_vat As Integer
        lstvewcustlist.Items.Clear()
        Try
            TpoCmd = New SqlCommand("FinAct_SplrMstr_SelectRecHavingPurchaseBills_Like", FinActConn)
            TpoCmd.CommandType = CommandType.StoredProcedure

            TpoCmd.Parameters.AddWithValue("@currval", Trim(CurString))
            If Me.Rbxcode.Checked = True Then
                TpoCmd.Parameters.AddWithValue("@currfield", "SplrSurFix")
            ElseIf Me.RbxName.Checked = True Then
                TpoCmd.Parameters.AddWithValue("@currfield", "splrname")
            End If
            If xCust_Vend = True Then
                TpoCmd.Parameters.AddWithValue("@splrtype", Trim("Both"))
            Else
                TpoCmd.Parameters.AddWithValue("@splrtype", Trim("Vendor"))
            End If
            TpoRdr = TpoCmd.ExecuteReader
            i = 0
            While (TpoRdr.Read)
                If TpoRdr.HasRows = True Then
                    Dim lstvew As ListViewItem
                    lstvew = Me.lstvewcustlist.Items.Add(TpoRdr(4)) 'id
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(1)) '+ " " + TpoRdr(2)) 'name
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(0))
                    splrid_vat = TpoRdr(0)
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
            ''If splrid_vat > 0 Then
            ''    Try
            ''        TpoCmd = New SqlCommand("Select splrspcatid from finactsplrmstr where splrid=@splid", FinActConn)
            ''        TpoCmd.Parameters.AddWithValue("@splid", splrid_vat)
            ''        TpoRdr = TpoCmd.ExecuteReader
            ''        TpoRdr.Read()
            ''        If TpoRdr.IsDBNull(0) = False Then
            ''            Me.Cmbxspcatid.SelectedValue = TpoRdr(0)
            ''            SpCid = TpoRdr(0)
            ''        End If
            ''    Catch ex As Exception
            ''        MsgBox(ex.Message)
            ''    Finally
            ''        TpoCmd.Dispose()
            ''        TpoRdr.Close()
            ''    End Try
            ''End If
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
        Me.Txtcustcode.Focus()
    End Sub
    Private Sub Txtcustcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcustcode.GotFocus
        Try
            TxtCond = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Txtcustcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtcustcode.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.tplcustlist.Location = New System.Drawing.Point(837, 5)
                Me.tplcustlist.Visible = False
                Me.tplcustlist.Enabled = False
                If Trim(Me.txtvCode.Text) <> "" Then
                    Me.CmbxWareh.Focus()
                    Me.CmbxWareh.SelectAll()
                Else
                    Me.MTxtTotlamt.Focus()
                    Me.MTxtTotlamt.SelectAll()
                End If
            End If
            If e.KeyCode = Keys.Enter Then
                If Trim(Me.Txtcustcode.Text) = "" Then
                    Me.lstvewcustlist.Focus()
                Else
                    lstvewcustlistDoubleClick()
                    Me.CmbxWareh.SelectAll()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtcustcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcustcode.Leave
        Try
            'lstvewcustlistDoubleClick()
            If Not LstIndx >= 0 Then
                Me.Txtcustcode.Focus()
                Me.Txtcustcode.SelectAll()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- BtnSave_Click, Line No. 189 ")

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- BtnSave_Click, Line No. 201 ")

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
    Private Sub lstvewcustlistDoubleClick()
        Dim Prvs_Splrid As Integer = SplrId

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
            If Me.CmbxCarri.Items.Count > 0 Then
                Me.CmbxCarri.SelectedValue = xTptId
            End If


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

    Private Sub lstvewcustlist_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstvewcustlist.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                lstvewcustlist_DoubleClick(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub TxtVname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVname.GotFocus
        TxtCond = True
        Me.tplcustlist.Location = New System.Drawing.Point(91, 133)
        Me.tplcustlist.Visible = True
        Me.tplcustlist.Enabled = True


    End Sub

    Private Sub BtnAddCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCust.Click
        Dim frmact As New FrmActMstrOld
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

    Private Sub CmbxCarri_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.Leave
        If FrmShow_flag(7) = True Then
            FrmShow_flag(7) = False
        End If
    End Sub

    Private Sub Dtpreqstdt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpSaleDue.ValueChanged
        Me.DtpSaleDue.MinDate = dtpordrdt.Value.Date
    End Sub
    Private Sub dtpordrdt_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpordrdt.ValueChanged
        Me.DtpSaleDue.MinDate = Me.dtpordrdt.Value
        Me.DtpInvvatdt.MinDate = Me.dtpordrdt.Value
        Me.DtpInvvatdt.MaxDate = Me.dtpordrdt.MaxDate
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

            TpoCmd = New SqlCommand("FinAct_ItemMstr_Select_Like", FinActConn)
            TpoCmd.CommandType = CommandType.StoredProcedure
            TpoCmd.Parameters.AddWithValue("@Sale_Pur_Type1", "Purchase")
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
            If e.KeyCode = Keys.Escape Then
                Me.Tplitem.Location = New System.Drawing.Point(837, 243)
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False

                If Me.DgSaleDirect.CurrentRow.Cells(1).Value <> "" Then
                    If Trim(Me.DgSaleDirect.CurrentRow.Cells(6).Value) = "" Then
                        Me.DgSaleDirect.CurrentRow.Cells(6).Value = 1 ' 1 stands for new entry
                    End If
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(3, Me.DgSaleDirect.CurrentRow.Index)
                Else
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentRow.Index)
                End If
                Me.DgSaleDirect.Focus()
            End If
            If e.KeyCode = Keys.Enter Then
                If Me.TxtItmcode.Text.Trim <> "" Then
                    LstVewItemDoubleClick()
                    Me.TxtItmcode.BackColor = Color.White
                Else
                    Me.TxtItmcode.BackColor = Color.Cyan
                    Me.TxtItmcode.Focus()
                End If

            End If
        Catch ex As Exception

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
    Private Sub LstVewItemDoubleClick()

        Try
            If LstIndx >= 0 Then
                Dim CurItemId As Integer = Trim(LstVewItem.Items(LstIndx).SubItems(2).Text)
                If Me.DgSaleDirect.CurrentRow.Cells(0).Value > 0 Then
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(3, Me.DgSaleDirect.CurrentRow.Index)
                Else
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentRow.Index)
                End If

                SetCur_Dupli_vali = False

                Me.DgSaleDirect.CurrentRow.Cells(1).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(0).Text)
                Me.DgSaleDirect.CurrentRow.Cells(2).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(1).Text)

                Me.DgSaleDirect.CurrentRow.Cells(4).Value = Trim(LstVewItem.Items(LstIndx).SubItems(7).Text)
                Dim amt1 As Double = Me.DgSaleDirect.CurrentRow.Cells(0).Value
                Dim amt2 As Double = Me.DgSaleDirect.CurrentRow.Cells(3).Value
                Dim amt3 As Double = amt1 * amt2
                Me.DgSaleDirect.CurrentRow.Cells(5).Value = amt3
                Me.DgSaleDirect.CurrentRow.Cells(7).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(2).Text)
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



    Private Sub BtnO_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSe_exit.Click
        Me.Close()
    End Sub

    Public Sub BtnPe_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSe_Save.Click
        If Me.DgSaleDirect.Rows.Count > 0 Then
            If Me.DgSaleDirect.Rows(0).Cells(10).Value <> 1 Then
                MsgBox("Invalid action", MsgBoxStyle.Critical, "No Row to save")
                Exit Sub
            End If
        Else
            MsgBox("Invalid action", MsgBoxStyle.Critical, "No Row to save")
            Exit Sub
        End If
        If Chk_zeroQnty() = True Then
            MsgBox("Invalid Input", MsgBoxStyle.Critical, "Zero Qnty.")
            Exit Sub
        End If
        Dim val1, val2 As Double
        val1 = FormatNumber(Me.MTxtTotlamt.Text, 2)
        val2 = FormatNumber(Me.lblgross.Text, 2)

        If val1.Equals(val2 + xRondOff) = False Then
            MsgBox("Invoice amount does not match with Gross Amount", MsgBoxStyle.Critical, "Check Invoice Amount...")
            Me.DgSaleDirect.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Are you sure to update this record", "Updating Current Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            BtnSe_Save.Focus()
            Return
        Else
            PurEntryUpdate()


        End If


    End Sub

    Private Sub PurEntryUpdate()
        If Me.DgSaleDirect.Rows.Count >= 1 Then
            Try
                TpoCmd = New SqlCommand("finact_PurItemBackRecdEntry_update", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@SBR_Entid", Selected_xInvoice_xId)
                TpoCmd.Parameters.AddWithValue("@SBR_enttotlamt", Me.MTxtTotlamt.Text)
                TpoCmd.Parameters.AddWithValue("@SBR_entsplrid", SplrId)
                TpoCmd.Parameters.AddWithValue("@SBR_entlocid", Me.CmbxWareh.SelectedValue)
                TpoCmd.Parameters.AddWithValue("@SBR_entcarri", Me.CmbxCarri.SelectedValue)
                TpoCmd.Parameters.AddWithValue("@SBR_entcoment", 0) ' Me.Txtcoment.Text)
                TpoCmd.Parameters.AddWithValue("@SBR_entothrcharg", CDbl(Me.txtlbltot.Text))
                TpoCmd.Parameters.AddWithValue("@SBR_entdisonamt", Me.lblsubttl.Text)
                TpoCmd.Parameters.AddWithValue("@SBR_entdistype", Me.Cmbxdistype.Text)

                If Trim(Me.Mtxtdisvalue.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@SBR_entdisrate", Me.Mtxtdisvalue.Text)
                Else
                    TpoCmd.Parameters.AddWithValue("@SBR_entdisrate", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@SBR_entdisvalue", Me.lbldiscount.Text)
                TpoCmd.Parameters.AddWithValue("@SBR_entvatrate", Me.Cmbxspcatid.SelectedValue)

                If Trim(Me.mskTxtVAtCst.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@SBR_entvatamt", Me.mskTxtVAtCst.Text)
                Else
                    TpoCmd.Parameters.AddWithValue("@SBR_entvatamt", CDbl(0.0))
                End If

                TpoCmd.Parameters.AddWithValue("@SBR_entvatinvno", Trim(Me.TxtVatinvno.Text))
                TpoCmd.Parameters.AddWithValue("@SBR_entvatdt", Me.DtpInvvatdt.Value)
                TpoCmd.Parameters.AddWithValue("@SBR_entinvamt", Me.MskInvamt.Text)
                TpoCmd.Parameters.AddWithValue("@SBR_entinvvat", Me.MskinvVat.Text)
                TpoCmd.Parameters.AddWithValue("@SBR_entedtusrid", Current_UsrId)
                TpoCmd.Parameters.AddWithValue("@SBR_entedtdt", Now)
                TpoCmd.Parameters.AddWithValue("@SBR_plistid", 0)
                TpoCmd.Parameters.AddWithValue("@SBREntTxAbleAmt", CDbl(Me.LbltablAmt.Text))
                TpoCmd.Parameters.AddWithValue("@SBREntVATSurChrg", Trim(Me.LblSurCharg.Text))
                TpoCmd.Parameters.AddWithValue("@SBREntRondOff", Trim(Me.xRondOff))
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

            Dim CurrPbillId As Integer = Selected_xInvoice_xId
            SBRCurrId = CurrPbillId
            Try
                Dim DgCntr As Integer
                If FinActConn.State Then FinActConn.Close()
                FinActConn.Open()
                For DgCntr = 0 To Me.DgSaleDirect.Rows.Count - 1
                    If Me.DgSaleDirect.Rows(DgCntr).Cells(10).Value = 1 Then
                        Dim xxItemId As Integer = Me.DgSaleDirect.Rows(DgCntr).Cells(7).Value
                        Dim xxRecid As Integer = Me.DgSaleDirect.Rows(DgCntr).Cells(6).Value
                        TpoCmd = New SqlCommand("Finact_SBR_FirstQltyOtherThanBom_Pur_Details_update", FinActConn)
                        TpoCmd.CommandType = CommandType.StoredProcedure
                        TpoCmd.Parameters.AddWithValue("@dPurentconcrnid", (CurrPbillId))
                        TpoCmd.Parameters.AddWithValue("@dRecid", xxRecid)
                        TpoCmd.Parameters.AddWithValue("@dPurentitmid", xxItemId)
                        TpoCmd.Parameters.AddWithValue("@dPurentqntyissue", (Me.DgSaleDirect.Rows(DgCntr).Cells(0).Value))
                        TpoCmd.Parameters.AddWithValue("@dPurentitmrate", (Me.DgSaleDirect.Rows(DgCntr).Cells(3).Value))
                        TpoCmd.Parameters.AddWithValue("@dPurentlocid", Me.CmbxWareh.SelectedValue)
                        TpoCmd.Parameters.AddWithValue("@dPurent_Isprod", 2)
                        TpoCmd.ExecuteNonQuery()
                        TpoCmd.Dispose()
                    End If
                Next
                MsgBox("Current Record Has Been updated Successfully", MsgBoxStyle.Information, "Save Record")
                Me.Close()
            Catch ex As Exception

                MsgBox(ex.Message, MsgBoxStyle.Critical, "File Name :- " & Me.Name & "SaleEntrySave(), Line No. 935")
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

            TpoCmd1 = New SqlCommand("select SBR_entid from FinactPurItemBackRecdEntry where SBR_entvno=@Ono and SBR_entsplrid=@sid", FinActConn1)
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
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            TpoCmd1 = New SqlCommand("select max(SBR_entid) from FinactPurItemBackRecdEntry ", FinActConn1)
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
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            TpoCmd1 = New SqlCommand("select max(SBR_entdt) from FinactPurItemBackRecdEntry where  SBR_entdelstatus=1", FinActConn1)

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





    Private Sub TxtinsCo_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cmbxspcatid.Focus()
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
                chk_Emptyvalue()
                If ErrIndx <> 0 Then
                    ErrIndx = 0
                    Me.dtpordrdt.Focus()
                    Exit Sub
                End If
                ''Me.Panel5.Enabled = False
                ''Me.DgSaleDirect.Enabled = True
                ''Me.txtlbltot.Enabled = True
                ''Me.BtnSe_Save.Enabled = True
                Me.DgSaleDirect.Focus()
                Dim rx As Integer = Me.DgSaleDirect.Rows.Count
                If rx > 0 Then
                    If_VAtrate_changed_then()
                End If
                Me.DgSaleDirect.Rows(rx - 1).Cells(0).Selected = True

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub MTxtTotlamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MTxtTotlamt.GotFocus
        Me.MTxtTotlamt.BackColor = Color.White
    End Sub

    Private Sub MTxtTotlamt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MTxtTotlamt.Leave
        If Chk_formatedvalue(MTxtTotlamt) = True Then
            Me.MTxtTotlamt.BackColor = Color.White
        End If
    End Sub

    Private Sub Clear_Values()
        Try
            Me.txtvCode.Clear()
            Me.TxtSaleBillNo.Clear()
            Me.Txtcoment.Clear()
            Me.TxtVname.Clear()
            Me.MTxtTotlamt.Clear()
            Me.Mtxtdisvalue.Text = 0
            Me.lblsubttl.Text = 0
            Me.lbltoc.Text = 0
            Me.lbldiscount.Text = 0
            Me.lblgross.Text = 0
            Me.DgSaleDirect.Rows.Clear()
            Me.mskTxtVAtCst.Text = 0
            Me.LblVATCST.Text = 0
            Me.LblSurCharg.Text = 0
            Me.LbltablAmt.Text = 0
            Me.LblRondOff.Text = 0
            Me.txtlbltot.Text = 0
            Me.lblSih.Text = 0
            Me.lblAdrsfull.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxspcatid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.GotFocus
        Try
            'Cmbxspcatid.DroppedDown = True
            Dim cond As String = ""
            If FrmShow_flag(11) = True Then
                cond = "Salechase"
                Select_2rec_where("spcatid", "spcatname", "spcattype", "FinactsaleSalecatgry", Cmbxspcatid, cond, "DELSTATUS", CInt(1))
                Dim Indxht As Integer = Cmbxspcatid.FindString(IntHtCmMm(11), 0)
                Cmbxspcatid.SelectedIndex = Indxht
            Else
                If Cmbxspcatid.Items.Count > 0 Then
                    Cmbxspcatid.SelectedValue = DefltVatCst
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

            If Me.Cmbxspcatid.SelectedValue > 0 Then
                Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))
            Else
                Me.Cmbxspcatid.SelectedValue = SpCid
            End If

            If_VAtrate_changed_then()
            Me.Chkbdisc.Focus()

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
                Me.DgSaleDirect.CurrentCell.ErrorText = ""
                CalculateCellValues()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgSaleDirect_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSaleDirect.CellEnter
        Try
            If e.ColumnIndex >= 0 Then
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
                ''chk_Emptyvalue()
                ''If ErrIndx <> 0 Then
                ''    ErrIndx = 0
                ''    Me.DgSaleDirect.ReadOnly = True
                ''    Exit Sub
                ''Else
                ''    Me.DgSaleDirect.ReadOnly = False
                ''End If

            End If

            If e.ColumnIndex = 1 Then

                Me.Tplitem.Location = New System.Drawing.Point(268, 221)
                Me.Tplitem.Visible = True
                Me.Tplitem.Enabled = True
                SetCur_Dupli_vali = True
                Me.Tplitem.Focus()
                Me.TxtItmcode.Focus()

            End If

            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 4 Or e.ColumnIndex = 7 Then
                Me.DgSaleDirect.CurrentRow.Cells(e.ColumnIndex).ReadOnly = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgSaleDirect_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgSaleDirect.CellValidating
        Try
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
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgSaleDirect_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSaleDirect.CellValueChanged
        Try
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
                        ' Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
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
                        'Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                        'End If
                    Next
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
                If Me.DgSaleDirect.CurrentCell.ColumnIndex = 3 Then ' Me.DgSaleDirect.ColumnCount = 3 Then
                    If Trim(Me.DgSaleDirect.CurrentRow.Cells(0).Value) <> Nothing And Trim(Me.DgSaleDirect.CurrentRow.Cells(1).Value) <> Nothing And Trim(Me.DgSaleDirect.CurrentRow.Cells(3).Value) <> Nothing Then
                        Dim Val1 As Double
                        Dim ic As String
                        ic = Me.DgSaleDirect.CurrentRow.Cells(1).Value

                        Val1 = Me.DgSaleDirect.CurrentRow.Cells(0).Value

                        If Not (Val1) > 0 Then
                            Me.DgSaleDirect.CurrentRow.Cells(0).ErrorText = "Value should be greater than zero"
                        Else
                            Me.DgSaleDirect.CurrentRow.Cells(0).ErrorText = ""
                            If Me.DgSaleDirect.CurrentRow.Index = Me.DgSaleDirect.Rows.Count - 1 Then
                                Me.txtlbltot.Focus()
                            End If

                        End If
                    End If

                    If Me.DgSaleDirect.CurrentCell.RowIndex < Me.DgSaleDirect.RowCount - 1 Then
                        Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentCell.RowIndex + 1)
                        '   Me.DgSaleDirect.CurrentCell.Value = 0
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

    ''Private Sub Fetch_vatrate(cint(Me.Cmbxspcatid.SelectedValue ))
    ''    Try
    ''        TpoCmd = New SqlCommand("select spcattxrate from finactSalepurCatgry where spcatid=@catid", FinActConn)
    ''        TpoCmd.Parameters.AddWithValue("@catid", Me.Cmbxspcatid.SelectedValue)
    ''        TpoRdr = TpoCmd.ExecuteReader
    ''        TpoRdr.Read()
    ''        If TpoRdr.IsDBNull(0) = False Then
    ''            VATCST = TpoRdr(0)
    ''        Else
    ''            VATCST = 0
    ''        End If
    ''    Catch ex As Exception
    ''        MsgBox(ex.Message)
    ''    Finally
    ''        TpoCmd.Dispose()
    ''        TpoRdr.Close()
    ''    End Try


    ''End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.mskTxtVAtCst.Focus()
        Me.mskTxtVAtCst.SelectAll()
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
            Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))
            If Me.DgSaleDirect.CurrentCell.ColumnIndex = 0 Then
                'RedirectingCell = True
                If Me.DgSaleDirect.CurrentRow.Cells(0).Value <> Nothing Then
                    val1 = Me.DgSaleDirect.CurrentRow.Cells(3).Value
                    val2 = Me.DgSaleDirect.CurrentRow.Cells(0).Value
                    val3 = val1 * val2
                    Me.DgSaleDirect.CurrentRow.Cells(3).Value = (val1)
                    Me.DgSaleDirect.CurrentRow.Cells(0).Value = (val2)
                    Me.DgSaleDirect.CurrentRow.Cells(5).Value = (val3)
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
                        val8 = val4 - val5
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
            If Me.DgSaleDirect.CurrentCell.ColumnIndex = 3 Then
                'RedirectingCell = True
                If Me.DgSaleDirect.CurrentRow.Cells(3).Value <> Nothing Then
                    val1 = Me.DgSaleDirect.CurrentRow.Cells(3).Value
                    val2 = Me.DgSaleDirect.CurrentRow.Cells(0).Value
                    val3 = val1 * val2
                    Me.DgSaleDirect.CurrentRow.Cells(3).Value = (val1)
                    Me.DgSaleDirect.CurrentRow.Cells(0).Value = (val2)
                    Me.DgSaleDirect.CurrentRow.Cells(5).Value = (val3)
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
                        val8 = val4 - val5
                        Me.mskTxtVAtCst.Text = FormatNumber(val8 * VATCST / 100, 2)
                        If IsNumeric(Me.mskTxtVAtCst.Text) Then
                            val6 = Me.mskTxtVAtCst.Text
                        Else
                            val6 = 0
                        End If
                        val7 = Me.lbltoc.Text
                        'Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                        ' End If
                    Next

                End If
            End If
        Catch ex As Exception

        End Try
        'End If
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
                        val8 = val4 - val5
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
                ''Me.Panel5.Enabled = False
                ''Me.DgSaleDirect.Enabled = True
                ''Me.txtlbltot.Enabled = True
                ''Me.BtnSe_Save.Enabled = True
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

    Private Sub Cmbxspcatid_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.SelectionChangeCommitted
        Try
            CalculateCellValues_ifCurrentpricelistchanged()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Function ChkExistingInBom(ByVal xxId As Integer) As Boolean
        Try
            TpoCmd = New SqlCommand("Select * from finact_bommstr where bomconcrnid=@Citmid order by bomid ", FinActConn)
            TpoCmd.Parameters.AddWithValue("@citmid", xxId)
            TpoRdr = TpoCmd.ExecuteReader
            While TpoRdr.Read()
                If TpoRdr.IsDBNull(0) = False Then
                    Return True
                Else
                    Return False
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd.Dispose()
            TpoRdr.Close()

        End Try
    End Function
   

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            If Me.DgSaleDirect.RowCount > 1 And Me.DgSaleDirect.SelectedRows.Count = 1 Then
                Me.DgSaleDirect.Rows.RemoveAt(Me.DgSaleDirect.SelectedRows(0).Index)
            Else
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, "Invalid!!!!!")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function Chk_zeroQnty() As Boolean
        Try
            Dim xxc As Integer = 0
            For xxc = 0 To Me.DgSaleDirect.RowCount - 1
                If Not (Me.DgSaleDirect.Rows(xxc).Cells(0).Value) > 0 Then
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

    Private Sub MskLbltot_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private Sub txtlbltot_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlbltot.GotFocus
        Try
            Me.txtlbltot.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtlbltot_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlbltot.Leave
        Try
            If Trim(txtlbltot.Text) <> "" Then
                If IsNumeric(Me.txtlbltot.Text) = False Then
                    Me.txtlbltot.Focus()
                    Me.txtlbltot.BackColor = Color.Cyan
                    Exit Sub
                Else
                    Me.txtlbltot.BackColor = Color.White
                    Me.txtlbltot.Text = FormatNumber(Me.txtlbltot.Text, 2)
                    Me.lbltoc.Text = Me.txtlbltot.Text
                    hndleOtherCharges()
                End If
            Else
                Me.txtlbltot.Text = FormatNumber(0, 2)
            End If
            Me.BtnSe_Save.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub hndleOtherCharges()
        Try
            Dim val1, val2, val3, val4 As Double
            val2 = 0
            val3 = 0
            val4 = 0
            If IsNumeric(val1 = Me.lbldiscount.Text) Then
                val1 = Me.lbldiscount.Text
            Else
                val1 = 0
            End If
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
        Catch ex As Exception

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

    Private Sub Chkbdisc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkbdisc.CheckedChanged
        Try
            If Me.Chkbdisc.Checked = True Then
                Me.Cmbxdistype.SelectedIndex = 0
                Me.Panel8.Enabled = True
            Else
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
            Me.LbltablAmt.Text = FormatNumber(CDbl(Me.lblsubttl.Text) - CDbl(Me.lbldiscount.Text), 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lbldiscount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbldiscount.TextChanged
        Try
            Me.LbltablAmt.Text = FormatNumber(CDbl(Me.lblsubttl.Text) - CDbl(Me.lbldiscount.Text), 2)
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

    Private Sub txtlbltot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlbltot.TextChanged
        Try
            If Not Len(txtlbltot.Text.Trim) = 0 Then
                If IsNumeric(txtlbltot.Text) = True Then
                    Me.lbltoc.Text = FormatNumber(Me.txtlbltot.Text, 2)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Mtxtdisvalue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mtxtdisvalue.GotFocus
        Try
            Me.Mtxtdisvalue.Select(0, Len(Me.Mtxtdisvalue.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mskTxtVAtCst_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.TextChanged
        Try
            Dim xV As Double = CDbl(Me.mskTxtVAtCst.Text)
            Dim xSur As Double = xCal_xInvoiceSurCharge(Me.Cmbxspcatid.SelectedValue, xV, Me.Label8)
            ''Select Case xCheckxSalePur_VATStatus(xSalxPurxType)
            ''    Case 1 '==SurCharge applicable.
            ''        xSur = Math.Round(xV * 10 / 100, 1)
            ''        Me.Label8.Text = "Surcharge (10%)"
            ''    Case 2 '==SurCharge and Labour Charges Applicable.
            ''        Me.Label8.Text = "Surcharge (10%)"
            ''    Case 3 '==Labour Charges Applicable (InterStates).
            ''        Me.Label8.Text = "Surcharge (0%)"
            ''    Case Else
            ''        xSur = Math.Round(0, 1)
            ''        Me.Label8.Text = "Surcharge (0%)"
            ''End Select
            Me.LblVATCST.Text = FormatNumber(Math.Round(xV, 1), 2)
            Me.LblSurCharg.Text = FormatNumber(xSur, 2)
            Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xAllContrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkbdisc.GotFocus, Chkprnt.GotFocus, CmbxCarri.GotFocus, CmbxWareh.GotFocus _
    , MTxtTotlamt.GotFocus
        Try
            Dim xx As Control = CType(sender, Control)
            xx.BackColor = Color.Yellow
        Catch ex As Exception

        End Try

    End Sub
    Private Sub xAllContrl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkbdisc.Leave, Chkprnt.Leave, CmbxCarri.Leave, CmbxWareh.Leave _
   , MTxtTotlamt.Leave
        Try
            Dim xx As Control = CType(sender, Control)
            xx.BackColor = Color.Transparent
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mskTxtVAtCst_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskTxtVAtCst.MaskInputRejected

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub
End Class




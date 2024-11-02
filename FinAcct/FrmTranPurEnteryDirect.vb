Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports FinAcct.cLSmYgrid
Public Class FrmTranPurEnteryDirect
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
    Dim ErrIndx, SpCId As Integer
    Dim DisVal As Double
    Dim chkStok1 As Double = 0
    Dim ChkItmid As Integer = 0
    Dim chkStok As Double = 0
    Dim LstIndx As Integer = 0
    Dim CurItmLocid As Integer = 0
    Dim xTptid As Integer = 0
    Dim xRondOff As Double = 0

    Private Sub FrmTranPurEnteryDirect_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FrmTranPurentryMain.fill_Purentgridview()
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
    Private Sub FrmTranPurOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New System.Drawing.Point(742, 600)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.ChkBx1.Checked = False
            Me.SplitContainer1.SplitterDistance = 535
            Me.Top = 0

            Select_2rec_where("Cscid", "Cscctyname", "csctype", "finactcscmstr", Me.CmbxWareh, "Inner", "CSCDELSTATUS", CInt(1))
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)
            Dim cond As String = "Purchase"
            Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", Cmbxspcatid, cond, "SPCATDELSTATUS", CInt(1))
            Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRUNDRGRUP", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), CInt(11), Me.CmbxLdgrHead)
            Dim CurOrderNo As Integer = Curr_MaxId()
            Me.TxtPurBillNo.Text = (CurOrderNo + 1)

            Me.dtpordrdt.MinDate = FinStartDt.Date
            Me.dtpordrdt.MaxDate = FinEnddt.Date
            If Curr_MaxId() > 0 Then
                Me.dtpordrdt.Value = Curr_Maxdate()
            Else
                Me.dtpordrdt.Value = Now
            End If
            Cmbxstatus.SelectedIndex = 1
            CreateGridColumns()
            Me.Text = "New Purchase Entry (Without P.O.) " & "  (CURRENT USER NAME:- " & Trim(Current_UserName) & ",DESIGNATION:- " & Trim(Current_UserDesi)
            Me.BtnPe_Save.Text = "&Save"

            Me.RbxName.Checked = True
            Dim tStr As String = Trim(Txtcustcode.Text)
            find_Customer_list(tStr)

            If Cl_Kbl = True And xMACH_xPurxBILLING = True Then
                Fill_Combobox("cogrpid", "cogrupnam", "FinactStokGrupname", "CoDelStatus", CInt(1), Me.CmbxStokGrup)

            Else
                Dim ItmStr As String = Trim(TxtItmcode.Text)
                find_Item_list(ItmStr)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub find_Customer_list(ByVal CurString As String)
        Dim i, splrid_vat1 As Integer
        lstvewcustlist.Items.Clear()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            TpoCmd = New SqlCommand("FinAct_SplrMstr_Select_Like", FinActConn)
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
                    splrid_vat1 = TpoRdr(0)
                    Me.lstvewcustlist.Items(i).SubItems.Add(Trim(TpoRdr(5)) & " " & Trim(TpoRdr(6)) & " " & Trim(TpoRdr(7)) & " " & Trim(TpoRdr(8)) & " " & Trim(TpoRdr(9)) & " " & Trim(TpoRdr(10))) 'adrs
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(3))
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(11))
                End If
                i = i + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd = Nothing
            TpoRdr.Close()
            If splrid_vat1 > 0 Then
                Try
                    TpoCmd = New SqlCommand("Select splrspcatid from finactsplrmstr where splrid=@splid", FinActConn)
                    TpoCmd.Parameters.AddWithValue("@splid", splrid_vat1)
                    TpoRdr = TpoCmd.ExecuteReader
                    TpoRdr.Read()
                    If TpoRdr.IsDBNull(0) = False Then
                        Me.Cmbxspcatid.SelectedValue = TpoRdr(0)
                        SpCId = TpoRdr(0)
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
        Me.Txtcustcode.Focus()
    End Sub
    Private Sub Txtcustcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcustcode.GotFocus
        Try
            TxtCond = False
            'Dim tStr As String = Trim(Txtcustcode.Text)
            'find_Customer_list(tStr)
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
        Catch ex As Exception

        End Try
        Try
            If e.KeyCode = Keys.Enter Then
                If Trim(Me.Txtcustcode.Text) = "" Then
                    Me.lstvewcustlist.Focus()
                Else
                    lstvewcustlistDoubleClick()
                    Me.CmbxWareh.Focus()
                    Me.CmbxWareh.SelectAll()
                End If
            End If
        Catch ex As Exception

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
        Try
            If Me.lstvewcustlist.Items.Count > 0 Then
                Me.txtvCode.Text = Trim(Me.lstvewcustlist.Items(LstIndx).Text)
                Me.TxtVname.Text = Trim(Me.lstvewcustlist.Items(LstIndx).SubItems(1).Text)
                SplrId = Trim(Me.lstvewcustlist.Items(LstIndx).SubItems(2).Text)
                Me.lblAdrsfull.Text = Trim(Me.lstvewcustlist.Items(LstIndx).SubItems(3).Text)
                DefltVatCst = Trim(Me.lstvewcustlist.Items(LstIndx).SubItems(4).Text)
                xTptid = Trim(Me.lstvewcustlist.Items(LstIndx).SubItems(5).Text)
                Me.tplcustlist.Location = New System.Drawing.Point(837, 5)
                Me.tplcustlist.Visible = False
                Me.tplcustlist.Enabled = False
                If Cmbxspcatid.Items.Count > 0 Then
                    Cmbxspcatid.SelectedValue = DefltVatCst
                    SpCId = DefltVatCst
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
            Dim xd As Integer = CInt(xBill_xDuedays("Finactsplrmstr", "splrnetday", "Splrid", SplrId))
            Me.DtppurDue.Value = Me.dtpordrdt.Value.AddDays(xd)
            Me.LblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(SplrId), Me.LblType), 2)

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

    Private Sub TxtVname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVname.GotFocus
        Try
            TxtCond = True
            Me.tplcustlist.Location = New System.Drawing.Point(91, 133)
            Me.tplcustlist.Visible = True
            Me.tplcustlist.Enabled = True
            Me.Txtcustcode.Focus()
            Me.Txtcustcode.SelectAll()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnAddCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCust.Click
        Dim frmact As New FrmActMstr
        frmact.ShowInTaskbar = False
        FrmShow_flag(5) = True
        FrmShow_flag(24) = True '===For use to set account type Vendor by default and enabled false of cmbx
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
        ' CmbxWareh.DroppedDown = True
        If FrmShow_flag(6) = True Then
            Select_2rec_where("Cscid", "Cscctyname", "csctype", "finactcscmstr", Me.CmbxWareh, "Inner", "CSCDELSTATUS", CInt(1))
            Dim IntW As Integer = CmbxWareh.FindString(IntHtCmMm(6), 0)
            CmbxWareh.SelectedIndex = IntW
        Else
            If CmbxWareh.Items.Count > 0 And CmbxWareh.SelectedIndex = -1 Then
                CmbxWareh.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub CmbxWareh_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWareh.Leave
        If FrmShow_flag(6) = True Then
            FrmShow_flag(6) = False

        End If
        'Me.CmbxCarri.Focus()
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
        If Cmbxstatus.Items.Count > 0 And Cmbxstatus.SelectedIndex = -1 Then
            Cmbxstatus.SelectedIndex = 2
        End If

    End Sub

    Private Sub DtppurDue_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtppurDue.ValueChanged
        Me.DtppurDue.MinDate = dtpordrdt.Value.Date
        Me.DtpInvDt.Value = dtpordrdt.Value.Date
    End Sub

    Private Sub dtpordrdt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpordrdt.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.TxtPurBillNo.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtpordrdt_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpordrdt.ValueChanged
        Me.DtppurDue.MinDate = dtpordrdt.Value
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
            'Dim ItmStr As String = Trim(TxtItmcode.Text)
            'find_Item_list(ItmStr)
            'me.DgPurDirect.CurrentRow.Cells(1).Selected = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtItmname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TxtCond1 = 2 'set filter as Itme name
    End Sub

    Private Sub Cmbxitem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TxtCond1 = 3 'set filter as Itme group
    End Sub

    Private Sub find_Item_list(ByVal CurString1 As String)
        Dim i As Integer
        Me.LstVewItem.Items.Clear()
        Try
            If Cl_Kbl = True Then
                TpoCmd = New SqlCommand("FinAct_ItemMstr_KBLtype_Select_Like", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                If xMACH_xPurxBILLING = True Then
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

            TpoCmd.Parameters.AddWithValue("@Sale_Pur_Type1", "Purchase")
            Dim loc As Object = Me.CmbxWareh.SelectedValue
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
                'TxtItmcode.Focus()
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

                If Me.DgPurDirect.CurrentRow.Cells(1).Value <> "" Then
                    If Trim(Me.DgPurDirect.CurrentRow.Cells(6).Value) = "" Then
                        Me.DgPurDirect.CurrentRow.Cells(6).Value = 1 ' 1 stands for new entry
                    End If
                    Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(3, Me.DgPurDirect.CurrentRow.Index)
                Else
                    Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(0, Me.DgPurDirect.CurrentRow.Index)
                End If
                Me.DgPurDirect.Focus()
            End If
            If e.KeyCode = Keys.Enter Then
                If Me.TxtItmcode.Text.Trim <> "" Then
                    LstVewItemDoubleClick()
                Else
                    Me.LstVewItem.Focus()
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
            For Each itm As ListViewItem In Me.LstVewItem.Items
                itm.BackColor = Color.White
                itm.ForeColor = Color.Black
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
                If Me.DgPurDirect.CurrentRow.Cells(0).Value > 0 Then

                    If Trim(Me.DgPurDirect.CurrentRow.Cells(6).Value) = "" Then
                        Me.DgPurDirect.CurrentRow.Cells(6).Value = 1 ' 1 stands for new entry
                    End If
                    Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(3, Me.DgPurDirect.CurrentRow.Index)
                Else
                    Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(0, Me.DgPurDirect.CurrentRow.Index)
                End If
                Me.DgPurDirect.CurrentRow.Cells(1).Value = Trim(LstVewItem.Items(LstIndx).SubItems(0).Text)
                Me.DgPurDirect.CurrentRow.Cells(2).Value = Trim(LstVewItem.Items(LstIndx).SubItems(1).Text)
                Me.DgPurDirect.CurrentRow.Cells(5).Value = Trim(LstVewItem.Items(LstIndx).SubItems(2).Text)
                Me.DgPurDirect.CurrentRow.Cells(3).Value = Trim(LstVewItem.Items(LstIndx).SubItems(3).Text)
                ' Me.DgPurDirect.CurrentRow.Cells(7).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(7).Text)
                ChkItmid = (LstVewItem.Items(LstIndx).SubItems(2).Text)
                chkStok1 = (LstVewItem.Items(LstIndx).SubItems(5).Text)

                Me.LblLastRate.Text = FormatNumber(xFetch_xLastPurRate_SelAcct(CInt(SplrId), CInt(ChkItmid), Me.LblLastDt), 2)

                Me.Tplitem.Location = New System.Drawing.Point(837, 243)
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
                Me.DgPurDirect.Focus()
                Try
                    chkStok = SumOf_In_and_Outward_Items(ChkItmid, ChkItmid)
                    Dim meval1 As Double = Me.DgPurDirect.CurrentRow.Cells(0).Value
                    If (chkStok + meval1) > chkStok1 Then
                        Me.lblwarnmess.Text = "You are exceeding the maximum stock limit " & FormatNumber(chkStok1, 3) & "  of current item. Sotck in hand  " & FormatNumber(chkStok, 3)
                        Me.lblwarnmess.Visible = True
                        Me.lblWarn.Visible = True
                    Else
                        Me.lblwarnmess.Visible = False
                        Me.lblWarn.Visible = False
                    End If
                Catch ex As Exception

                End Try

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub

    Private Sub LstVewItem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.GotFocus
        Try
            If Me.LstVewItem.Items.Count > 0 Then
                Me.LstVewItem.Items(0).Selected = True
            End If
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

    Private Sub LstVewItem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.Leave
        Try
            If Me.LstVewItem.Items.Count > 0 Then
                If Me.DgPurDirect.CurrentRow.Cells(1).Value = "" Then
                    LstVewItem_DoubleClick(sender, e)
                Else
                    Me.DgPurDirect.Focus()
                    If Me.DgPurDirect.CurrentRow.Cells(0).Value > 0 Then
                        If Trim(Me.DgPurDirect.CurrentRow.Cells(6).Value) = "" Then
                            Me.DgPurDirect.CurrentRow.Cells(6).Value = 1 ' 1 stands for new entry
                        End If
                        Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(3, Me.DgPurDirect.CurrentRow.Index)
                    Else
                        Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(0, Me.DgPurDirect.CurrentRow.Index)
                    End If
                End If
            Else
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
                Me.Tplitem.Location = New System.Drawing.Point(837, 243)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxitem_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        'LstVewItem.Focus()
        If LstVewItem.Items.Count > 0 Then
            LstVewItem.Items(0).Selected = True
        Else
            TxtItmcode.Focus()

        End If

    End Sub

    Private Sub BtnItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.LstVewItem.Items.Count > 0 Then
            LstVewItem_DoubleClick(sender, e)
        Else
            Me.Tplitem.Visible = False
            Me.Tplitem.Enabled = False
            Me.Tplitem.Location = New System.Drawing.Point(837, 243)
        End If
    End Sub



    Private Function validate_input_Duplicate() As Boolean
        Dim i, j As Integer
        '  If FrmShow_flag(8) = True Then
        For i = 0 To Me.DgPurDirect.Rows.Count - 1
            For j = i + 1 To Me.DgPurDirect.Rows.Count - 1
                If Trim(Me.DgPurDirect.Rows(i).Cells(1).Value) <> Nothing Then
                    If Trim(Me.DgPurDirect.Rows(i).Cells(1).Value) = Trim(Me.DgPurDirect.Rows(j).Cells(1).Value) Then ' And me.DgPurDirect.Rows(i).Cells(2).Value = me.DgPurDirect.Rows(j).Cells(2).Value Then
                        Return True
                    End If
                End If
            Next
        Next
        Return False
        'End If
        If FrmShow_flag(9) = True Then
            For i = 0 To Me.DgPurDirect.Rows.Count - 1
                For j = i + 1 To Me.DgPurDirect.Rows.Count - 1
                    If Trim(Me.DgPurDirect.Rows(i).Cells(1).Value) <> Nothing Then
                        If Trim(Me.DgPurDirect.Rows(i).Cells(1).Value) = Trim(Me.DgPurDirect.Rows(j).Cells(1).Value) Then ' And me.DgPurDirect.Rows(i).Cells(2).Value = me.DgPurDirect.Rows(j).Cells(2).Value Then
                            Return True
                        End If
                    End If
                Next
            Next
            Return False
        End If
    End Function
    Private Function SumOf_In_and_Outward_Items(ByVal SalItemId As Integer, ByVal PurItemId As Integer) As Double
        Try
            TpoCmd1 = New SqlCommand("Finact_Sum_In_out_pur_Particularitem", FinActConn2)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@PurItemid", PurItemId)
            ' TpoCmd1.Parameters.AddWithValue("@puritmLocid", CurItmLocid)
            TpoRdr1 = TpoCmd1.ExecuteReader
            While TpoRdr1.Read
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


    Private Sub BtnO_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPe_exit.Click
        Me.Close()
    End Sub

    Private Sub BtnPe_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPe_Save.Click
        Try
            If Me.CmbxLdgrHead.SelectedIndex = -1 Then
                MsgBox("Invalid Input! control having no value not allowed.", MsgBoxStyle.Critical, Me.Text)
                Me.CmbxLdgrHead.Focus()
                Exit Sub
            End If
            If Me.DgPurDirect.Rows.Count > 0 Then
                If Me.DgPurDirect.Rows(0).Cells(6).Value <> 1 Then
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
                Me.MTxtTotlamt.Focus()
                Me.MTxtTotlamt.SelectAll()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure to save this record", "Purchase Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                BtnPe_Save.Focus()
                Return
            Else
                PurEntrySave()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub PurEntrySave()
        If Me.DgPurDirect.Rows.Count >= 1 Then
            Try
                TpoCmd = New SqlCommand("Finact_Purentry_Insert", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@purentdt", (Me.dtpordrdt.Value.Date))
                TpoCmd.Parameters.AddWithValue("@purbilstatus", Trim(Me.Cmbxstatus.Text))
                TpoCmd.Parameters.AddWithValue("@purentvno", Trim(TxtPurBillNo.Text))
                TpoCmd.Parameters.AddWithValue("@purentduedt", Me.DtppurDue.Value)
                TpoCmd.Parameters.AddWithValue("@purenttotlamt", Me.MTxtTotlamt.Text)
                TpoCmd.Parameters.AddWithValue("@purentsplrid", SplrId)
                TpoCmd.Parameters.AddWithValue("@purentlocid", Me.CmbxWareh.SelectedValue)
                TpoCmd.Parameters.AddWithValue("@purentcarri", Me.CmbxCarri.SelectedValue)
                If Trim(Me.MtxtfrtChargs.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@purentfrtcharg", Me.MtxtfrtChargs.Text)
                Else
                    TpoCmd.Parameters.AddWithValue("@purentfrtcharg", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@purentgrno", Me.Txtgrno.Text)
                TpoCmd.Parameters.AddWithValue("@purentcarino", Me.TxtCariNo.Text)
                TpoCmd.Parameters.AddWithValue("@purentgrdt", Me.Dtpgrdt.Value)
                If Trim(Me.mtxtulcharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@purentulcharg", Me.mtxtulcharg.Text)
                Else
                    TpoCmd.Parameters.AddWithValue("@purentulcharg", CDbl(0.0))
                End If

                TpoCmd.Parameters.AddWithValue("@purentuload", Me.Txtuload.Text)
                TpoCmd.Parameters.AddWithValue("@purentcoment", Me.Txtcoment.Text)

                If Trim(Me.MtxtPkgcharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@purentpkgcharg", Me.MtxtPkgcharg.Text)
                Else
                    TpoCmd.Parameters.AddWithValue("@purentpkgcharg", CDbl(0.0))
                End If

                If Trim(Me.MskPostcharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@purentpostcharg", Me.MskPostcharg.Text)
                Else
                    TpoCmd.Parameters.AddWithValue("@purentpostcharg", CDbl(0.0))
                End If

                If Trim(Me.Mskothrchrg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@purentothrcharg", Me.Mskothrchrg.Text)
                Else
                    TpoCmd.Parameters.AddWithValue("@purentothrcharg", CDbl(0.0))
                End If

                If Trim(Me.MskInscharg.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@purentinscharg", Me.MskInscharg.Text)
                Else
                    TpoCmd.Parameters.AddWithValue("@purentinscharg", CDbl(0.0))
                End If

                TpoCmd.Parameters.AddWithValue("@purentpolcyno", Me.TxtPlcyno.Text)
                TpoCmd.Parameters.AddWithValue("@purentinsco", Me.TxtinsCo.Text)
                TpoCmd.Parameters.AddWithValue("@purentdisonamt", Me.lblsubttl.Text)
                TpoCmd.Parameters.AddWithValue("@purentdistype", Me.Cmbxdistype.Text)

                If Trim(Me.Mtxtdisvalue.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@purentdisrate", Me.Mtxtdisvalue.Text)
                Else
                    TpoCmd.Parameters.AddWithValue("@purentdisrate", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@purentdisvalue", Me.lbldiscount.Text)
                TpoCmd.Parameters.AddWithValue("@purentvatrate", Me.Cmbxspcatid.SelectedValue)

                If Trim(Me.mskTxtVAtCst.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@purentvatamt", Me.mskTxtVAtCst.Text)
                Else
                    TpoCmd.Parameters.AddWithValue("@purentvatamt", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@PurEntTxAbleAmt", CDbl(Me.LbltablAmt.Text))
                TpoCmd.Parameters.AddWithValue("@PurEntVATSurChrg", Trim(Me.LblSurCharg.Text))
                TpoCmd.Parameters.AddWithValue("@PurEntRondOff", Trim(Me.xRondOff))
                TpoCmd.Parameters.AddWithValue("@purentorderid", 0)
                TpoCmd.Parameters.AddWithValue("@purentadusrid", Current_UsrId)
                TpoCmd.Parameters.AddWithValue("@purentaddt", Now)
                TpoCmd.Parameters.AddWithValue("@purentdelstatus", 1)
                TpoCmd.Parameters.AddWithValue("@PurEnt_UGRUP", CInt(Me.CmbxLdgrHead.SelectedValue))
                If xMACH_xPurxBILLING = True Then
                    TpoCmd.Parameters.AddWithValue("@PurENTBILLTYPE", "MACH")
                Else
                    TpoCmd.Parameters.AddWithValue("@PurENTBILLTYPE", "FAB")
                End If
                TpoCmd.Parameters.AddWithValue("@purentInvDt", Me.DtpInvDt.Value.Date)
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

            Dim CurrPbillId As Integer = FindlastId(Trim(TxtPurBillNo.Text), Trim(SplrId))
            Try
                Dim DgCntr As Integer
                For DgCntr = 0 To Me.DgPurDirect.Rows.Count - 1
                    If Me.DgPurDirect.Rows(DgCntr).Cells(6).Value = 1 Then
                        TpoCmd = New SqlCommand("Finact_Purentry_Details_Insert", FinActConn)
                        TpoCmd.CommandType = CommandType.StoredProcedure
                        TpoCmd.Parameters.AddWithValue("@dpurentconcrnid", (CurrPbillId))
                        TpoCmd.Parameters.AddWithValue("@dpurent_con_dpurid", 0)
                        TpoCmd.Parameters.AddWithValue("@dpurentitmid", (Me.DgPurDirect.Rows(DgCntr).Cells(5).Value))
                        TpoCmd.Parameters.AddWithValue("@dpurentqnty", (Me.DgPurDirect.Rows(DgCntr).Cells(0).Value))
                        TpoCmd.Parameters.AddWithValue("@dpurentitmrate", (Me.DgPurDirect.Rows(DgCntr).Cells(3).Value))
                        TpoCmd.Parameters.AddWithValue("@dpurentlocid", Me.CmbxWareh.SelectedValue)
                        TpoCmd.ExecuteNonQuery()
                    End If
                Next
                MsgBox("Current Record Has Been Saved Successfully", MsgBoxStyle.Information, "Save Record")

                x_PBillNO_x = Trim(Me.TxtPurBillNo.Text)
                Clear_Values()
                If Me.Chkprnt.Checked = True Then
                    If MessageBox.Show("Do you want to print this bill?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim frmPbillPrnt As New FrmCrRptPurBillPrinting
                        frmPbillPrnt.Visible = False
                        frmPbillPrnt.ShowInTaskbar = False
                        frmPbillPrnt.BringToFront()
                        frmPbillPrnt.ShowDialog()
                    End If
                End If
                Me.TxtPurBillNo.Focus()
                Me.TxtPurBillNo.SelectAll()
                Nrow = New DataGridViewRow
                Me.DgPurDirect.Rows.Add(Nrow)

            Catch ex As SqlException
                If ex.Number = 8114 Then
                    MsgBox("Data overflow, check maximum limit of a control", MsgBoxStyle.Critical, "Check Lenth of data")
                Else
                    MsgBox(ex.Message)
                End If
                Try
                    TpoCmd1 = New SqlCommand("Delete from finactpurentry where purentid=@pid", FinActConn1)
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
            Me.DgPurDirect.Focus()

        End If

    End Sub
    Private Function FindlastId(ByVal P_billno As String, ByVal Splr_id As Integer) As Integer
        Try

            TpoCmd1 = New SqlCommand("select purentid from finactpurentry where purentvno=@Ono and purentsplrid=@sid", FinActConn1)
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
            Dim Curr_MaxPurid As Integer = 0
            TpoCmd1 = New SqlCommand("select max(purentid) from finactpurentry ", FinActConn1)
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.IsDBNull(0) = False Then
                Curr_MaxPurid = TpoRdr1(0)
            Else
                Curr_MaxPurid = 0
            End If
            Return Curr_MaxPurid
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoRdr1.Close()
            TpoCmd1.Dispose()
        End Try

    End Function
    Private Function Curr_Maxdate() As Date
        Try
            Dim Curr_MaxPurdt As Date
            TpoCmd1 = New SqlCommand("select max(purentdt) from finactpurentry where  purentdelstatus=1", FinActConn1)

            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.IsDBNull(0) = False Then
                Curr_MaxPurdt = TpoRdr1(0)
                Return Curr_MaxPurdt
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoRdr1.Close()
            TpoCmd1.Dispose()
        End Try

    End Function


    Private Sub TxtPurBillNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPurBillNo.GotFocus
        If MaxSplid > 0 Then
            Me.TxtPurBillNo.Text = (MaxSplid + 1)
        End If

    End Sub


    Private Sub CreateGridColumns()

        Me.DgPurDirect.Columns.Clear()
        Me.DgPurDirect.Rows.Clear()

        Me.DgPurDirect.Columns.Add("Qnty", "Quantity")
        Me.DgPurDirect.Columns("Qnty").Width = 100
        Me.DgPurDirect.Columns("Qnty").DefaultCellStyle.Format = "N3"
        Me.DgPurDirect.Columns("Qnty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Me.DgPurDirect.Columns.Add("Icode", "Item Code")
        Me.DgPurDirect.Columns("Icode").Width = 95
        Me.DgPurDirect.Columns("Icode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Me.DgPurDirect.Columns.Add("Iname", "Description")
        Me.DgPurDirect.Columns("Iname").Width = 234
        Me.DgPurDirect.Columns("Iname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Me.DgPurDirect.Columns.Add("rate", "Rate")
        Me.DgPurDirect.Columns("rate").Width = 95
        Me.DgPurDirect.Columns("rate").DefaultCellStyle.Format = "N2"
        Me.DgPurDirect.Columns("rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Me.DgPurDirect.Columns.Add("amt", "Amount")
        Me.DgPurDirect.Columns("amt").Width = 120
        Me.DgPurDirect.Columns("amt").DefaultCellStyle.Format = "N2"
        Me.DgPurDirect.Columns("amt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Me.DgPurDirect.Columns.Add("Iid", "Id")
        Me.DgPurDirect.Columns("Iid").Width = 0
        Me.DgPurDirect.Columns("Iid").Visible = False

        Me.DgPurDirect.Columns.Add("Flag", "Flag")
        Me.DgPurDirect.Columns("Flag").Width = 0
        Me.DgPurDirect.Columns("Flag").Visible = False
        Me.DgPurDirect.RowHeadersWidth = 60

        Nrow = New DataGridViewRow
        Me.DgPurDirect.Rows.Add(Nrow)
        Dim rx As Integer = Me.DgPurDirect.Rows.Count - 1
        Me.DgPurDirect.Rows(rx).Cells(0).Selected = False
        Me.DgPurDirect.Rows(0).HeaderCell.Value = "1"

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
    Private Sub Mtxtdisvalue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mtxtdisvalue.Leave
        Try
            If Chk_formatedvalue(Mtxtdisvalue) = False Then
                Exit Sub
            Else
                ' If Len(Me.Mtxtdisvalue.Text.Trim) = 0 Then Me.Mtxtdisvalue.Text = 0
                If Trim(Me.Cmbxdistype.Text) = "Discount Value" Then
                    Me.lbldiscount.Text = FormatNumber(Me.Mtxtdisvalue.Text, 2)
                ElseIf Trim(Me.Cmbxdistype.Text) = "Discount Percentage" Then
                    DisVal = Me.Mtxtdisvalue.Text
                End If
                Me.DgPurDirect.Focus()
                Dim rx As Integer = Me.DgPurDirect.Rows.Count - 1
                Me.DgPurDirect.Rows(rx).Cells(0).Selected = True
                If_VAtrate_changed_then()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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
                Me.Cmbxdistype.SelectedIndex = 0
                Me.Panel8.Enabled = True
            Else
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
        Try
            ''If Len(Me.MTxtTotlamt.Text.Trim) = 0 Then Me.MTxtTotlamt.Text = 0
            If Chk_formatedvalue(MTxtTotlamt) = True Then
                Me.MTxtTotlamt.BackColor = Color.White
            End If
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
    Private Sub Clear_Values()
        Me.txtvCode.Clear()
        Me.Txtuload.Clear()
        Me.TxtPurBillNo.Clear()
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
        Me.DgPurDirect.Rows.Clear()
        Me.mskTxtVAtCst.Text = 0

    End Sub

    Private Function SumOf_Txtvalues() As Double
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
            Dim cond As String = ""
            If FrmShow_flag(11) = True Then
                cond = "Purchase"
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
                Me.DgPurDirect.ReadOnly = True
                Exit Sub
            Else
                Me.DgPurDirect.ReadOnly = False
            End If
            lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
            If Me.Cmbxspcatid.SelectedValue > 0 Then
                Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))
            Else
                Me.Cmbxspcatid.SelectedValue = SpCId
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
        Catch ex As Exception

        End Try
        ''lbltoc.Text = FormatNumber(SumOf_Txtvalues(), 2)
        ''Fetch_vatrate(cint(Me.Cmbxspcatid.SelectedValue ))
        ''If_VAtrate_changed_then()
        ''If Me.Panel8.Enabled = False Then
        ''    Me.DgPurDirect.Focus()
        ''    If Me.DgPurDirect.Rows.Count = 0 Then
        ''        Nrow = New DataGridViewRow
        ''        Me.DgPurDirect.Rows.Add()
        ''    End If
        ''    Dim rx As Integer = Me.DgPurDirect.Rows.Count - 1
        ''    Me.DgPurDirect.Rows(rx).Cells(0).Selected = True

        ''End If
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

    Private Sub DgPurDirect_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPurDirect.CellEndEdit
        Try
            If e.ColumnIndex = 0 Or e.ColumnIndex = 3 Then
                Me.DgPurDirect.CurrentCell.ErrorText = ""
                CalculateCellValues()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgPurDirect_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPurDirect.CellEnter
        Try
            If e.ColumnIndex >= 0 Then
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
                chk_Emptyvalue()
                If ErrIndx <> 0 Then
                    ErrIndx = 0
                    Me.DgPurDirect.ReadOnly = True
                    Exit Sub
                Else
                    Me.DgPurDirect.ReadOnly = False

                End If

            End If

            If e.ColumnIndex = 1 Then
                Me.Tplitem.Location = New System.Drawing.Point(268, 221)
                Me.Tplitem.Visible = True
                Me.Tplitem.Enabled = True
                SetCur_Dupli_vali = True
                Me.Tplitem.Focus()
                Me.TxtItmcode.Focus()
                If Cl_Kbl = True And xMACH_xPurxBILLING = True Then
                    Me.CmbxStokGrup.Enabled = True
                    Me.CmbxStokGrup.Focus()
                Else
                    Me.CmbxStokGrup.Enabled = False
                    '  Me.TxtItmcode.Text = ""
                    Me.TxtItmcode.Focus()
                    Me.TxtItmcode.SelectAll()
                End If
            End If

            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 4 Then
                Me.DgPurDirect.CurrentRow.Cells(e.ColumnIndex).ReadOnly = True
            End If
        Catch ex As Exception

        End Try
        Try
            If e.ColumnIndex = 3 Then
                If Me.DgPurDirect.Rows.Count > 1 Then
                    If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                        If validate_input_Duplicate() = True Then
                            Me.DgPurDirect.CurrentRow.Cells(1).ErrorText = "Current Item is already existed"
                            Exit Sub
                        Else
                            Me.DgPurDirect.CurrentRow.Cells(1).ErrorText = ""
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgPurDirect_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgPurDirect.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgPurDirect.Rows.Count '- 1
            If Cr_Row <> Me.DgPurDirect.CurrentRow.Index Then
                If e.ColumnIndex = 0 Or e.ColumnIndex = 3 Then
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

    Private Sub DgPurDirect_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPurDirect.CellValueChanged
        Try
            Dim val1, val2, val3, val4, val5, val6, val7, val8 As Double
            val4 = 0

            '  val1 = Me.DgPurDirect.CurrentRow.Cells(0).Value
            If e.ColumnIndex = 0 Then
                If Me.lblwarnmess.Visible = True Then
                    Try
                        chkStok = SumOf_In_and_Outward_Items(ChkItmid, ChkItmid)
                        Dim meval1 As Double = Me.DgPurDirect.CurrentRow.Cells(0).Value
                        If (chkStok + meval1) > chkStok1 Then
                            Me.lblwarnmess.Text = "You are exceeding the maximum stock limit " & FormatNumber(chkStok1, 3) & "  of current item. Sotck in hand  " & FormatNumber(chkStok, 3)
                            Me.lblwarnmess.Visible = True
                            Me.lblWarn.Visible = True
                        Else
                            Me.lblwarnmess.Visible = False
                            Me.lblWarn.Visible = False
                        End If
                    Catch ex As Exception

                    End Try
                End If

                If Me.DgPurDirect.CurrentRow.Cells(0).Value <> Nothing Then
                    val1 = Me.DgPurDirect.CurrentRow.Cells(0).Value
                    val2 = Me.DgPurDirect.CurrentRow.Cells(3).Value
                    'Else
                    '    val1 = 0
                    val3 = val1 * val2
                    Me.DgPurDirect.CurrentRow.Cells(0).Value = FormatNumber(val1, 3)
                    Me.DgPurDirect.CurrentRow.Cells(3).Value = FormatNumber(val2, 2)
                    Me.DgPurDirect.CurrentRow.Cells(4).Value = FormatNumber(val3, 2)
                    Dim Rc As Integer
                    For Rc = 0 To Me.DgPurDirect.Rows.Count - 1
                        Dim a As String = Me.DgPurDirect.CurrentRow.Cells(6).Value
                        If Me.DgPurDirect.CurrentRow.Cells(6).Value = 1 Then
                            If IsNumeric(Me.DgPurDirect.Rows(Rc).Cells(4).Value) Then
                                val4 += (Me.DgPurDirect.Rows(Rc).Cells(4).Value)  'Sub total
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
                        End If
                    Next

                End If
            End If
            If e.ColumnIndex = 3 Then
                If Me.DgPurDirect.CurrentRow.Cells(3).Value <> Nothing Then

                    val1 = Me.DgPurDirect.CurrentRow.Cells(0).Value
                    val2 = Me.DgPurDirect.CurrentRow.Cells(3).Value
                    val3 = val1 * val2
                    Me.DgPurDirect.CurrentRow.Cells(0).Value = FormatNumber(val1, 3)
                    Me.DgPurDirect.CurrentRow.Cells(3).Value = FormatNumber(val2, 2)
                    Me.DgPurDirect.CurrentRow.Cells(4).Value = FormatNumber(val3, 2)
                    Dim Rc As Integer
                    For Rc = 0 To Me.DgPurDirect.Rows.Count - 1
                        If Me.DgPurDirect.CurrentRow.Cells(6).Value = 1 Then
                            If IsNumeric(Me.DgPurDirect.Rows(Rc).Cells(4).Value) Then
                                val4 += (Me.DgPurDirect.Rows(Rc).Cells(4).Value)  'Sub total
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
                            '  Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgPurDirect_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgPurDirect.EditingControlShowing
        Try

            If TypeOf e.Control Is TextBox Then
                Dim tb As TextBox = e.Control
                tb.AcceptsTab = True

            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgPurDirect_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgPurDirect.KeyDown

        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If Me.DgPurDirect.CurrentCell.ColumnIndex = Me.DgPurDirect.ColumnCount - 3 Then
                    If Trim(Me.DgPurDirect.CurrentRow.Cells(0).Value) <> Nothing And Trim(Me.DgPurDirect.CurrentRow.Cells(1).Value) <> Nothing And Trim(Me.DgPurDirect.CurrentRow.Cells(3).Value) <> Nothing Then
                        Dim Val1 As Double
                        Dim ic As String
                        ic = Me.DgPurDirect.CurrentRow.Cells(1).Value

                        Val1 = Me.DgPurDirect.CurrentRow.Cells(0).Value

                        If Not (Val1) > 0 Then
                            Me.DgPurDirect.CurrentRow.Cells(0).ErrorText = "Value should be greater than zero"
                        Else
                            If Trim(Me.DgPurDirect.CurrentRow.Cells(0).ErrorText) <> "" Or Trim(Me.DgPurDirect.CurrentRow.Cells(1).ErrorText) <> "" Then
                                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                                Exit Sub
                            Else
                                If MessageBox.Show("Do you want to add more item?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                    Me.DgPurDirect.CurrentRow.Cells(0).ErrorText = ""
                                    If Me.DgPurDirect.CurrentRow.Index = Me.DgPurDirect.Rows.Count - 1 Then
                                        Nrow = New DataGridViewRow
                                        Me.DgPurDirect.Rows.Add()
                                        Dim xsno As Integer = Me.DgPurDirect.Rows.Count
                                        Me.DgPurDirect.Rows(xsno - 1).HeaderCell.Value = xsno.ToString
                                    End If
                                Else
                                    Me.BtnPe_Save.Focus()
                                End If
                            End If
                        End If
                    End If

                    If Me.DgPurDirect.CurrentCell.RowIndex < Me.DgPurDirect.RowCount - 1 Then
                        Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(0, Me.DgPurDirect.CurrentCell.RowIndex + 1)
                        ' Me.DgPurDirect.CurrentCell.Value = 0
                    End If
                Else
                    Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(Me.DgPurDirect.CurrentCell.ColumnIndex + 1, Me.DgPurDirect.CurrentCell.RowIndex)
                End If
            End If
            e.Handled = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Allcontrols_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkbCariDetals.KeyDown, Chkbdisc.KeyDown, ChkbOthrCharg.KeyDown _
    , CmbxCarri.KeyDown, Cmbxdistype.KeyDown, Cmbxspcatid.KeyDown, Cmbxstatus.KeyDown, CmbxWareh.KeyDown, Dtpgrdt.KeyDown, DtppurDue.KeyDown _
    , MskInscharg.KeyDown, Mskothrchrg.KeyDown, MskPostcharg.KeyDown, mskTxtVAtCst.KeyDown, Mtxtdisvalue.KeyDown, MtxtfrtChargs.KeyDown, MtxtPkgcharg.KeyDown, MTxtTotlamt.KeyDown, mtxtulcharg.KeyDown _
    , Rbxcode.KeyDown, Rbxicode.KeyDown, RbxiName.KeyDown, RbxName.KeyDown, TxtCariNo.KeyDown, Txtcoment.KeyDown, Txtgrno.KeyDown, TxtinsCo.KeyDown _
    , TxtPlcyno.KeyDown, Chkprnt.KeyDown, Txtuload.KeyDown, txtvCode.KeyDown, TxtVname.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub chk_Emptyvalue()
        Try
            With MTxtTotlamt
                If Trim(.Text) = "" Then
                    .BackColor = Color.Cyan
                    ErrIndx += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With Me.TxtVname
                If Trim(.Text) = "" Then
                    .BackColor = Color.Cyan
                    ErrIndx += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With Me.txtvCode
                If Trim(.Text) = "" Then
                    .BackColor = Color.Cyan
                    ' .Focus()
                    ErrIndx += 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With TxtPurBillNo
                If Trim(.Text) = "" Then
                    .BackColor = Color.Cyan
                    ' .Focus()
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


                '  Me.lblgross.Text = FormatNumber((val4 + val2 + val3) - val1, 2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If Len(Me.LblVATCST.Text) > 0 Then
                Me.TxtVATamt.Text = FormatNumber(Me.LblVATCST.Text, 2)
                Me.TxtVATamt.Location = New System.Drawing.Point(580, 462)
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

    Private Sub If_VAtrate_changed_then()
        Try
            Dim val4, val5, val6, val7 As Double
            val4 = 0
            Dim Rc As Integer
            If Me.DgPurDirect.Rows.Count > 0 Then
                For Rc = 0 To Me.DgPurDirect.Rows.Count - 1
                    If IsNumeric(Me.DgPurDirect.Rows(Rc).Cells(4).Value) Then
                        val4 += (Me.DgPurDirect.Rows(Rc).Cells(4).Value)  'Sub total
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


    Private Sub CalculateCellValues()
        Try
            Dim val1, val2, val3, val4, val5, val6, val7, val8 As Double
            val4 = 0
            Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))
            If Me.DgPurDirect.CurrentCell.ColumnIndex = 0 Then
                'RedirectingCell = True
                If Me.DgPurDirect.CurrentRow.Cells(0).Value <> Nothing Then
                    val1 = Me.DgPurDirect.CurrentRow.Cells(3).Value
                    val2 = Me.DgPurDirect.CurrentRow.Cells(0).Value
                    val3 = val1 * val2
                    Me.DgPurDirect.CurrentRow.Cells(3).Value = (val1)
                    Me.DgPurDirect.CurrentRow.Cells(0).Value = (val2)
                    Me.DgPurDirect.CurrentRow.Cells(4).Value = (val3)
                    Dim Rc As Integer
                    For Rc = 0 To Me.DgPurDirect.Rows.Count - 1
                        If IsNumeric(Me.DgPurDirect.Rows(Rc).Cells(4).Value) Then
                            val4 += (Me.DgPurDirect.Rows(Rc).Cells(4).Value)  'Sub total
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
                        '' Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                        ' End If
                    Next

                End If
            End If
            If Me.DgPurDirect.CurrentCell.ColumnIndex = 3 Then
                'RedirectingCell = True
                If Me.DgPurDirect.CurrentRow.Cells(3).Value <> Nothing Then
                    val1 = Me.DgPurDirect.CurrentRow.Cells(3).Value
                    val2 = Me.DgPurDirect.CurrentRow.Cells(0).Value
                    val3 = val1 * val2
                    Me.DgPurDirect.CurrentRow.Cells(3).Value = (val1)
                    Me.DgPurDirect.CurrentRow.Cells(0).Value = (val2)
                    Me.DgPurDirect.CurrentRow.Cells(4).Value = (val3)
                    Dim Rc As Integer
                    For Rc = 0 To Me.DgPurDirect.Rows.Count - 1
                        If IsNumeric(Me.DgPurDirect.Rows(Rc).Cells(4).Value) Then
                            val4 += (Me.DgPurDirect.Rows(Rc).Cells(4).Value)  'Sub total
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
                        ''Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                        ' End If
                    Next

                End If
            End If
        Catch ex As Exception

        End Try
        'End If
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


    Private Sub BtnPe_all_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPe_exit.GotFocus, BtnPe_Save.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPe_all_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPe_exit.Leave, BtnPe_Save.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
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


    Private Sub ChkbCariDetals_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbCariDetals.CheckedChanged
        Try
            If Len(Me.txtvCode.Text.Trim) = 0 Then
                Me.ChkbCariDetals.CheckState = CheckState.Unchecked
                Me.txtvCode.Focus()
                Exit Sub
            End If

            If Me.ChkbCariDetals.Checked = True Then
                Me.Panel6.Enabled = True
                Me.MtxtfrtChargs.Focus()
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
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxStokGrup_Leave(sender, e)
            End If
            If e.KeyCode = Keys.Escape Then
                Me.Tplitem.Location = New System.Drawing.Point(837, 243)
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
                Dim rNo As Integer = Me.DgPurDirect.RowCount - 1
                Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(0, rNo)
            End If
        Catch ex As Exception

        End Try
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

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            If Len(Me.DgPurDirect.Rows(0).Cells(0).Value) > 0 Then
                FrmShow_flag(3) = True
                xCall_LinkFrmDgVew(FrmStokItm, Me.DgPurDirect)
            Else

                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub mskTxtVAtCst_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.TextChanged
        Try
            Dim xV As Double = CDbl(Me.mskTxtVAtCst.Text)
            Dim xSur As Double = xCal_xInvoiceSurCharge(Me.Cmbxspcatid.SelectedValue, xV, Me.Label32)
            ''Dim xSur As Double = 0
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
            Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
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


    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            If Len(Me.LbltablAmt.Text) > 0 Then
                Me.TxtTxableAmt.Text = FormatNumber(Me.LbltablAmt.Text, 2)
                Me.TxtTxableAmt.Location = New System.Drawing.Point(580, 446)
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


    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Try
            If Len(Me.LblSurCharg.Text) > 0 Then
                Me.TxtSurChrg.Text = FormatNumber(Me.LblSurCharg.Text, 2)
                Me.TxtSurChrg.Location = New System.Drawing.Point(580, 477)
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
                Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(lbltoc.Text), 2)
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
            ToolStripMenuItem3_Click(sender, e)
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
            ToolStripMenuItem4_Click(sender, e)
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
                Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRUNDRGRUP", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), CInt(11), Me.CmbxLdgrHead)
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
                Me.txtvCode.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtPurBillNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPurBillNo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxLdgrHead.Focus()
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

    Private Sub CmbxLdgrHead_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxLdgrHead.SelectedIndexChanged

    End Sub

    Private Sub MtxtPkgcharg_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MtxtPkgcharg.MaskInputRejected

    End Sub
End Class




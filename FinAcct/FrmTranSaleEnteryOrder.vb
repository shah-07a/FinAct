Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
'Imports FinAcct.cLSmYgrid
Public Class FrmTranSaleEnteryOrder
    Dim TpoCmd As SqlCommand
    Dim TpoRdr As SqlDataReader
    Dim TpoAdptr As SqlDataAdapter
    Dim TpoCmd1 As SqlCommand
    Dim TpoRdr1 As SqlDataReader
    Dim TpoDtset As DataSet
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
    Dim ErrIndx, SpCid, Prordid As Integer
    Dim DisVal As Double
    Dim dy As Double = 0
    Dim WishedForCell As DataGridViewCell = Nothing
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim xRondOff As Double = 0

    Private Sub FrmTranSaleOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New System.Drawing.Point(834, 660)
            Me.Top = 0
            Me.Left = 0
            Me.SplitContainer1.SplitterDistance = 590
            Me.SplitContainer1.IsSplitterFixed = True
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)
            Dim cond As String = "Sale"
            Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", Cmbxspcatid, cond, "SPCATDELSTATUS", CInt(1))
            Dim cond1 As String = "Sales Agent"
            Select_2rec_where("splrid", "splrname", "splrtype", "Finactsplrmstr", CmbxAgent, cond1, "SPLRDELSTATUS", CInt(1))
            Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRUNDRGRUP", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), CInt(10), Me.CmbxLdgrHead)
            If Not Me.CmbxAgent.Items.Count > 0 Then
                MsgBox("Invalid Input! Sales Agent Required", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            If Cl_Kbl = False Then '== KBL HAS SET HIS SEPERATE SERIES.
                Dim CurOrderNo As Integer = Curr_MaxId()
                Me.TxtSaleBillNo.Text = (CurOrderNo + 1)
            End If
            If Curr_MaxId() > 0 Then
                Date.TryParse(Curr_Maxdate(), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.dtpordrdt.MinDate = CurrDate.Date
            Else
                Date.TryParse(FinStartDt.Date, CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.dtpordrdt.MinDate = CurrDate.Date
            End If
            If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                Me.ChkVatInfo.Enabled = True
                Me.ChkVatInfo.Visible = True
            Else
                Me.ChkVatInfo.Enabled = False
                Me.ChkVatInfo.Visible = False
            End If

            Me.dtpordrdt.MaxDate = FinEnddt.Date
            Cmbxstatus.SelectedIndex = 1
            Me.Text = "Sale Entry (Through  Sale Order)  " & "  (CURRENT USER NAME:- " & Trim(Current_UserName) & ",DESIGNATION:- " & Trim(Current_UserDesi)
            CreateGridColumns()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub find_Customer_list(ByVal CurString As String)
        Dim i As Integer
        lstvewcustlist.Items.Clear()
        Try
            TpoCmd = New SqlCommand("FinAct_SplrMstr_Select_Like", FinActConn)
            TpoCmd.CommandType = CommandType.StoredProcedure

            TpoCmd.Parameters.AddWithValue("@currval", Trim(CurString))
            If TxtCond = False Then
                TpoCmd.Parameters.AddWithValue("@currfield", "SplrSurFix")
            ElseIf TxtCond = True Then
                TpoCmd.Parameters.AddWithValue("@currfield", "splrname")
            End If
            TpoCmd.Parameters.AddWithValue("@splrtype", Trim("Customer"))
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

            If TxtCond = False Then
                Txtcustcode.Focus()
            Else
                Txtcustname.Focus()
            End If
            lstvewcustlist.Items(0).Selected = True

        Else
            If TxtCond = False Then
                Txtcustcode.Focus()
            Else
                Txtcustname.Focus()
            End If
        End If

    End Sub

    Private Sub Txtcustcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcustcode.GotFocus
        TxtCond = False
    End Sub

    Private Sub Txtcustcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtcustcode.KeyDown, Txtcustname.KeyDown
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
    End Sub
    Private Sub Txtcustcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcustcode.TextChanged
        Dim tStr As String = Trim(Txtcustcode.Text)
        find_Customer_list(tStr)
    End Sub

    Private Sub lstvewcustlist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvewcustlist.DoubleClick
        If Me.lstvewcustlist.Items.Count > 0 Then
            Me.txtvCode.Text = Trim(lstvewcustlist.SelectedItems.Item(0).Text)
            Me.TxtVname.Text = Trim(lstvewcustlist.SelectedItems.Item(0).SubItems(1).Text)
            SplrId = Trim(lstvewcustlist.SelectedItems.Item(0).SubItems(2).Text)
            Me.lblAdrsfull.Text = Trim(lstvewcustlist.SelectedItems.Item(0).SubItems(3).Text)
            DefltVatCst = Trim(lstvewcustlist.SelectedItems.Item(0).SubItems(4).Text)
            Me.tplcustlist.Location = New System.Drawing.Point(837, 5)
            Me.tplcustlist.Visible = False
            Me.tplcustlist.Enabled = False
            If Cmbxspcatid.Items.Count > 0 Then
                Cmbxspcatid.SelectedValue = DefltVatCst
            End If
            Me.CmbxWareh.Focus()
        End If
    End Sub

    Private Sub lstvewcustlist_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstvewcustlist.KeyDown
        If e.KeyCode = Keys.Enter Then
            lstvewcustlist_DoubleClick(sender, e)
        End If
    End Sub
    Private Sub BtnCloselist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCloselist.Click
        lstvewcustlist_DoubleClick(sender, e)
    End Sub


    Private Sub Txtcustname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcustname.GotFocus
        TxtCond = True
    End Sub

    Private Sub Txtcustname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcustname.TextChanged
        Dim tStr As String = Trim(Txtcustname.Text)
        find_Customer_list(tStr)
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
        CmbxWareh.DroppedDown = True
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
        Me.CmbxCarri.Focus()
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

    Private Sub CmbxCarri_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.GotFocus, CmbxPlist.GotFocus
        CmbxCarri.DroppedDown = True
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
            Cmbxstatus.SelectedIndex = 2
        End If
    End Sub

    Private Sub Dtpreqstdt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpSaleDue.ValueChanged
        Me.DtpSaleDue.MinDate = dtpordrdt.Value.Date
    End Sub

    Private Sub Cmbxdistype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxdistype.GotFocus
        Try
            Me.Cmbxdistype.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSaleBillNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSaleBillNo.GotFocus
        Try
            If Cl_Kbl = False Then
                If MaxSplid > 0 Then
                    Me.TxtSaleBillNo.Text = (MaxSplid + 1)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub allControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkbCariDetals.KeyDown, Chkbdisc.KeyDown _
    , ChkbOthrCharg.KeyDown, ChkVatInfo.KeyDown, CmbxCarri.KeyDown, Cmbxdistype.KeyDown, Cmbxitem.KeyDown, CmbxPlist.KeyDown, Cmbxspcatid.KeyDown _
    , Cmbxstatus.KeyDown, CmbxWareh.KeyDown, DtpSaleDue.KeyDown, Dtpgrdt.KeyDown, DtpInvvatdt.KeyDown, MskInscharg.KeyDown, MskInvamt.KeyDown, MskinvVat.KeyDown _
    , Mskothrchrg.KeyDown, MskPostcharg.KeyDown, mskTxtVAtCst.KeyDown, TxtCariNo.KeyDown, Txtcoment.KeyDown, Txtcustcode.KeyDown, Txtcustname.KeyDown _
    , Txtgrno.KeyDown, TxtinsCo.KeyDown, TxtinsCo.KeyDown, TxtItmcode.KeyDown, TxtItmname.KeyDown, TxtPlcyno.KeyDown, TxtPvtMrk.KeyDown, TxtSaleBillNo.KeyDown, TxtGrsWt.KeyDown _
    , TxtVatinvno.KeyDown, txtvCode.KeyDown, TxtVname.KeyDown, RbSbill1.KeyDown, RbSbill2.KeyDown, MTxtTotlamt.KeyDown, MtxtfrtChargs.KeyDown, mtxtulcharg.KeyDown, MtxtPkgcharg.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpordrdt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpordrdt.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.DtpSaleDue.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtpordrdt_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpordrdt.ValueChanged
        Try
            Me.DtpSaleDue.MinDate = dtpordrdt.Value
            Me.DtpSaleDue.Value = dtpordrdt.Value.AddDays(dy)
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

    Private Sub lstvewcustlist_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvewcustlist.Leave
        If lstvewcustlist.Items.Count > 0 Then
            lstvewcustlist_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub TxtItmcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItmcode.GotFocus
        TxtCond1 = 1 'set filter as Itme code
        'me.DgSaleDirect.CurrentRow.Cells(1).Selected = False

    End Sub

    Private Sub TxtItmname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItmname.GotFocus
        TxtCond1 = 2 'set filter as Itme name
    End Sub

    Private Sub Cmbxitem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxitem.GotFocus
        TxtCond1 = 3 'set filter as Itme group
    End Sub

    Private Sub find_Item_list(ByVal CurString1 As String)
        Dim i As Integer
        Me.LstVewItem.Items.Clear()
        Try
            If TxtCond1 = 0 Then
                TpoCmd = New SqlCommand("FinAct_ItemMstr_Select_ALL", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@Sale_Pur_Type1", "Sale")
            Else
                TpoCmd = New SqlCommand("FinAct_ItemMstr_Select_Like", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@Sale_Pur_Type1", "Sale")
                TpoCmd.Parameters.AddWithValue("@currval1", Trim(CurString1))
            End If

            If TxtCond1 = 1 Then
                TpoCmd.Parameters.AddWithValue("@currfield1", "itmcode")
            ElseIf TxtCond1 = 2 Then
                TpoCmd.Parameters.AddWithValue("@currfield1", "itmname")
            ElseIf TxtCond1 = 3 Then
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
            ElseIf TxtCond1 = 2 Then
                TxtItmname.Focus()
            Else
                Me.Cmbxitem.Focus()
            End If
        Else
            If TxtCond1 = 1 Then
                TxtItmcode.Focus()
            ElseIf TxtCond1 = 2 Then
                TxtItmname.Focus()
            Else
                Me.Cmbxitem.Focus()
            End If
        End If

    End Sub

    Private Sub TxtItmcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtItmcode.KeyDown, TxtItmname.KeyDown, Cmbxitem.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then
            Me.Tplitem.Location = New System.Drawing.Point(837, 243)
            Me.Tplitem.Visible = False
            Me.Tplitem.Enabled = False
            Me.DgSaleDirect.Focus()
            If Me.DgSaleDirect.CurrentRow.Cells(1).Value <> "" Then
                If Trim(Me.DgSaleDirect.CurrentRow.Cells(6).Value) = "" Then
                    Me.DgSaleDirect.CurrentRow.Cells(6).Value = 1 ' 1 stands for new entry
                End If
                Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(3, Me.DgSaleDirect.CurrentRow.Index)
            Else
                Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentRow.Index)
            End If

        End If
    End Sub

    Private Sub TxtItmcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtItmcode.TextChanged
        Dim ItmStr As String = Trim(TxtItmcode.Text)
        find_Item_list(ItmStr)
    End Sub
    Private Sub TxtItmname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtItmname.TextChanged
        Dim ItmStr As String = Trim(TxtItmname.Text)
        find_Item_list(ItmStr)
    End Sub
    Private Sub LstVewItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.DoubleClick
        Try
            If Me.LstVewItem.SelectedItems.Count > 0 Then
                If Me.DgSaleDirect.CurrentRow.Cells(0).Value > 0 Then
                    If Trim(Me.DgSaleDirect.CurrentRow.Cells(6).Value) = "" Then
                        Me.DgSaleDirect.CurrentRow.Cells(6).Value = 1 ' 1 stands for new entry
                    End If
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(3, Me.DgSaleDirect.CurrentRow.Index)
                Else
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentRow.Index)
                End If
                Me.DgSaleDirect.CurrentRow.Cells(1).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(0).Text)
                Me.DgSaleDirect.CurrentRow.Cells(2).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(1).Text)
                Me.DgSaleDirect.CurrentRow.Cells(5).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(2).Text)
                Me.DgSaleDirect.CurrentRow.Cells(3).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(3).Text)
                Me.Tplitem.Location = New System.Drawing.Point(837, 243)
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
                Me.DgSaleDirect.Focus()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub

    Private Sub LstVewItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.LstVewItem.Items.Count > 0 Then
                If Me.DgSaleDirect.CurrentRow.Cells(1).Value = "" Then
                    LstVewItem_DoubleClick(sender, e)
                Else
                    Me.DgSaleDirect.Focus()
                    If Me.DgSaleDirect.CurrentRow.Cells(0).Value > 0 Then
                        If Trim(Me.DgSaleDirect.CurrentRow.Cells(6).Value) = "" Then
                            Me.DgSaleDirect.CurrentRow.Cells(6).Value = 1 ' 1 stands for new entry
                        End If
                        Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(3, Me.DgSaleDirect.CurrentRow.Index)
                    Else
                        Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentRow.Index)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub LstVewItem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.Leave
        If Me.LstVewItem.Items.Count > 0 Then
            If Me.DgSaleDirect.CurrentRow.Cells(1).Value = "" Then
                LstVewItem_DoubleClick(sender, e)
            Else
                Me.DgSaleDirect.Focus()
                If Me.DgSaleDirect.CurrentRow.Cells(0).Value > 0 Then
                    If Trim(Me.DgSaleDirect.CurrentRow.Cells(6).Value) = "" Then
                        Me.DgSaleDirect.CurrentRow.Cells(6).Value = 1 ' 1 stands for new entry
                    End If
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(3, Me.DgSaleDirect.CurrentRow.Index)
                Else
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentRow.Index)
                End If
            End If
        Else
            Me.Tplitem.Visible = False
            Me.Tplitem.Enabled = False
            Me.Tplitem.Location = New System.Drawing.Point(837, 243)
        End If
    End Sub

    Private Sub Cmbxitem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxitem.Leave
        'LstVewItem.Focus()
        If LstVewItem.Items.Count > 0 Then
            LstVewItem.Items(0).Selected = True
        Else
            TxtItmcode.Focus()

        End If

    End Sub

    Private Sub BtnItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnItem.Click
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
        Try
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
        Catch ex As Exception

        End Try
    End Function
    Private Function SumOf_In_and_Outward_Items(ByVal SalItemId As Integer, ByVal SaleItemId As Integer) As Double
        Try
            TpoCmd1 = New SqlCommand("Finact_Sum_In_out_Sale_Particularitem", FinActConn2)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@SaleItemid", SaleItemId)
            'TpoCmd1.Parameters.AddWithValue("@SaleItemId", SalItemId)
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
            Dim Xx As Integer = 0
            If Me.CmbxLdgrHead.SelectedIndex = -1 Then
                MsgBox("Invalid Input! control having no value not allowed.", MsgBoxStyle.Critical, Me.Text)
                Me.CmbxLdgrHead.Focus()
                Exit Sub
            End If
            ResetPriceList_AllGridItems()
            For Xx = 0 To Me.DgSaleDirect.Rows.Count - 1
                If Trim(Me.DgSaleDirect.Rows(Xx).Cells(11).ErrorText) <> "" Then
                    MsgBox("System could not save current record(s)", MsgBoxStyle.Critical, "Check the status!!! ")
                    Exit Sub
                End If
            Next
            chk_Emptyvalue()
            If ErrIndx <> 0 Then
                ErrIndx = 0
                Me.DgSaleDirect.ReadOnly = True
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
            If MessageBox.Show("Are you sure to save this record", "Salechase Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                BtnPe_Save.Focus()
                Return
            Else
                SaleEntrySave()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub SaleEntrySave()
        If Me.DgSaleDirect.Rows.Count >= 1 Then
            Try
                TpoCmd = New SqlCommand("Finact_Saleentry_Insert", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@Saleentdt", (Me.dtpordrdt.Value))
                TpoCmd.Parameters.AddWithValue("@Salebilstatus", Trim(Me.Cmbxstatus.Text))
                If Cl_TimeIndia = False Then
                    Me.TxtSaleBillNo.Text = xFetchVno_AccordingVATBillType(SplrId, CInt(Me.Cmbxspcatid.SelectedValue), dtpordrdt)
                End If
                TpoCmd.Parameters.AddWithValue("@Saleentvno", Trim(TxtSaleBillNo.Text))
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
                    TpoCmd.Parameters.AddWithValue("@Saleentothrcharg", Me.Mskothrchrg.Text)
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
                TpoCmd.Parameters.AddWithValue("@Saleentdisvalue", Me.lbldiscount.Text)
                TpoCmd.Parameters.AddWithValue("@SaleentAdnlDis", CDbl(Me.LblAdlDis.Text))
                TpoCmd.Parameters.AddWithValue("@SaleentadnldisRate", CDbl(Me.MskAdlDis.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentvatrate", Me.Cmbxspcatid.SelectedValue)

                If Trim(Me.mskTxtVAtCst.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@Saleentvatamt", CDbl(Me.LblVATCST.Text))
                    ''TpoCmd.Parameters.AddWithValue("@Saleentvatamt", CDbl(Me.mskTxtVAtCst.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@Saleentvatamt", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@SaleEntTxAbleAmt", CDbl(Me.LbltablAmt.Text))
                TpoCmd.Parameters.AddWithValue("@SaleEntVATSurChrg", CDbl(Me.LblSurCharg.Text))
                TpoCmd.Parameters.AddWithValue("@SaleEntRondOff", CDbl(Me.LblRondOff.Text))

                TpoCmd.Parameters.AddWithValue("@Saleentorderid", Prordid)

                TpoCmd.Parameters.AddWithValue("@Saleentvatinvno", Trim(Me.TxtVatinvno.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentvatdt", Me.DtpInvvatdt.Value.Date)
                TpoCmd.Parameters.AddWithValue("@Saleentinvamt", CDbl(Me.MskInvamt.Text))
                TpoCmd.Parameters.AddWithValue("@Saleentinvvat", Me.MskinvVat.Text)
                TpoCmd.Parameters.AddWithValue("@Saleentpvtmrk", Trim(Me.TxtPvtMrk.Text))

                TpoCmd.Parameters.AddWithValue("@Saleentadusrid", Current_UsrId)
                TpoCmd.Parameters.AddWithValue("@Saleentaddt", Now)
                TpoCmd.Parameters.AddWithValue("@Saleentdelstatus", 1)
                TpoCmd.Parameters.AddWithValue("@salePlistid", Me.CmbxPlist.SelectedValue)
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
                TpoCmd.Parameters.AddWithValue("@SaleEnt_UGRUP", CInt(Me.CmbxLdgrHead.SelectedValue))
                Dim xCurBillno As Integer = CInt(Me.TxtSaleBillNo.Text)
                If xCurBillno >= xSaleRetailVno Then
                    TpoCmd.Parameters.AddWithValue("@SaleEntRETAILvNO", CInt(Me.TxtSaleBillNo.Text))
                    TpoCmd.Parameters.AddWithValue("@SaleEntVATvNO", CInt(0))
                Else
                    TpoCmd.Parameters.AddWithValue("@SaleEntVATvNO", CInt(Me.TxtSaleBillNo.Text))
                    TpoCmd.Parameters.AddWithValue("@SaleEntRETAILvNO", CInt(0))
                End If
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
            Dim CurrPbillId As Integer = FindlastId(Trim(TxtSaleBillNo.Text), Trim(SplrId))
            Try
                Dim DgCntr As Integer
                For DgCntr = 0 To Me.DgSaleDirect.Rows.Count - 1
                    If Me.DgSaleDirect.Rows(DgCntr).Cells(11).Value > 0 Then
                        TpoCmd = New SqlCommand("Finact_Saleentry_Details_Insert", FinActConn)
                        TpoCmd.CommandType = CommandType.StoredProcedure
                        TpoCmd.Parameters.AddWithValue("@dSaleentconcrnid", (CurrPbillId))
                        TpoCmd.Parameters.AddWithValue("@dSaleent_con_dSaleid", (Me.DgSaleDirect.Rows(DgCntr).Cells(6).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleentitmid", (Me.DgSaleDirect.Rows(DgCntr).Cells(7).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleentqntyissue", CDbl(Me.DgSaleDirect.Rows(DgCntr).Cells(11).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleentitmrate", CDbl(Me.DgSaleDirect.Rows(DgCntr).Cells(3).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleentlocid", Me.CmbxWareh.SelectedValue)
                        TpoCmd.Parameters.AddWithValue("@dSaleEntOrderId", CInt(Me.DgSaleDirect.Rows(DgCntr).Cells(9).Value))
                        TpoCmd.Parameters.AddWithValue("@SaleEntCartNo", (Me.DgSaleDirect.Rows(DgCntr).Cells(10).Value))
                        TpoCmd.ExecuteNonQuery()
                    End If
                Next

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


            Try
                'Dim DgCntr As Integer
                For Each DgCntr As DataGridViewRow In Me.DgSaleDirect.Rows
                    If DgCntr.Cells(11).Value > 0 Then
                        TpoCmd = New SqlCommand("Finact_SaleEntryRecd_Details_Update", FinActConn)
                        TpoCmd.CommandType = CommandType.StoredProcedure
                        TpoCmd.Parameters.AddWithValue("@dSaleid", CInt(DgCntr.Cells(6).Value))
                        TpoCmd.Parameters.AddWithValue("@dSalerecdqnty", CDbl(DgCntr.Cells(11).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleqntyrecddt", Now)
                        TpoCmd.Parameters.AddWithValue("@dSaleitmdiscr", Trim(DgCntr.Cells(2).Value))
                        TpoCmd.Parameters.AddWithValue("@dSaleitmrate", CDbl(DgCntr.Cells(3).Value))
                        TpoCmd.ExecuteNonQuery()
                    End If
                Next
                '====FOLLOWING CODE WILL SET THE STATUS OF ORDERS
                For xx As Integer = 0 To Selected_xSelectedOrdr_xId.Length - 1
                    If Change_XStatus(Selected_xSelectedOrdr_xId(xx)) = False Then
                        Change_XStatus1(Selected_xSelectedOrdr_xId(xx))
                    End If
                Next


                MsgBox("Current Record Has Been Updated Successfully", MsgBoxStyle.Information, "Update Record")
                If Me.RbSbill1.Checked = True Then
                    x_SBill_Type = 1
                Else
                    x_SBill_Type = 2
                End If
                x_SBillNo_x = Trim(Me.TxtSaleBillNo.Text)
                Clear_Values()
                If MessageBox.Show("Do you want to print this sale bill?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    xSaleBillId = CInt(CurrPbillId)
                    xSaleBillSplrid = CInt(Me.SplrId)
                    xSaleBillSpcatid = CInt(Me.Cmbxspcatid.SelectedValue)
                    Dim frmsbPrnt As Form
                    If Cl_Ltg = True Then
                        frmsbPrnt = New FrmCrRptSaleBillltG
                    Else
                        frmsbPrnt = New FrmCrRptSaleBillPrinting
                    End If

                    frmsbPrnt.Visible = False
                    frmsbPrnt.ShowInTaskbar = False
                    frmsbPrnt.BringToFront()
                    frmsbPrnt.ShowDialog()
                End If

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
            MsgBox("Invalid action! System could not found any record to save", MsgBoxStyle.Critical, "Empty Table")
            Me.DgSaleDirect.Focus()
        End If

    End Sub

    Private Function Change_XStatus(ByVal cSaleid As Integer) As Boolean
        Try

            TpoCmd1 = New SqlCommand("select dSalerecdstatus from FinactSaleOrder_Details where dSaleconcrnid=@dSaleconcrnid and dSalerecdstatus=@dprStatus", FinActConn1)
            TpoCmd1.Parameters.AddWithValue("@dSaleconcrnid", cSaleid)
            TpoCmd1.Parameters.AddWithValue("@dprStatus", "Yet_Delvd")
            TpoRdr1 = TpoCmd1.ExecuteReader
            While TpoRdr1.Read()
                If Trim(TpoRdr1(0)) = Trim("Yet_Delvd") Then
                    Return True
                Else
                    Return False
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd1.Dispose()
            TpoRdr1.Close()
        End Try
    End Function
    Private Sub Change_XStatus1(ByVal Cprordrid As Integer)
        Try

            TpoCmd1 = New SqlCommand("update finactSaleorder set Salestatus=@cStatusas where Saleid=@CSaleid1", FinActConn1)
            TpoCmd1.Parameters.AddWithValue("@CSaleid1", Cprordrid)
            TpoCmd1.Parameters.AddWithValue("@cStatusas", "Completed")
            TpoCmd1.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd1.Dispose()
        End Try

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
            TpoCmd1 = New SqlCommand("select max(Saleentdt) from finactSaleentry where Saleentdelstatus=1", FinActConn1)
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


    ''Private Sub TxtSaleBillNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSaleBillNo.GotFocus
    ''    If MaxSplid > 0 Then
    ''        Me.TxtSaleBillNo.Text = (MaxSplid + 1)
    ''    End If

    ''End Sub

    Private Sub Select_Salepircelst_where(ByVal xCombobox As ComboBox, ByVal Spl_Splrid As Integer)
        Dim xStr As String = "Finact_SalePriceList_Select"
        Try
            TpoCmd = New SqlCommand(xStr, FinActConn2)
            TpoCmd.CommandType = CommandType.StoredProcedure
            TpoCmd.Parameters.AddWithValue("@AtchSplid", Spl_Splrid)
            TpoAdptr = New SqlDataAdapter(TpoCmd)
            TpoDtset = New DataSet(TpoCmd.CommandText)
            TpoDtset.Tables.Clear()
            TpoAdptr.Fill(TpoDtset)
            xCombobox.DataSource = TpoDtset.Tables(0)
            xCombobox.ValueMember = "spl_id"
            xCombobox.DisplayMember = "spl_name"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd.Dispose()
            TpoAdptr.Dispose()
        End Try
    End Sub

    Private Sub CreateGridColumns()
        SpCid = 0

        Try
            TpoCmd1 = New SqlCommand("Finact_SaleOrder_Select_Where_id", FinActConn)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@orderid", Selected_xSelectedOrdr_xId(0))
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.HasRows = True Then
                'If TpoRdr1.IsDBNull(12) = True Then
                Me.MTxtTotlamt.Text = FormatNumber(0, 2)
                'End If
                Date.TryParse(TpoRdr1("Saleorddt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.dtpordrdt.MinDate = CurrDate.Date
                Me.dtpordrdt.Value = Now.Date 'CurrDate.Date 
                Me.Text = Trim("Sale Entry(Through Sale Order)") & " -Order No. " & Trim(TpoRdr1("Saleordno")) & " -Date " & Format(CurrDate, "dd/MM/yyyy") & "  Aprx. Amount =" & FormatNumber(TpoRdr1("Saleamt"), 2)
                Me.Cmbxstatus.Text = Trim(TpoRdr1("Salestatus"))
                Date.TryParse(TpoRdr1("Saledelvrydt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                ' Me.Dtpreqstdt.Value = CurrDate
                SplrId = Trim(TpoRdr1("Salesplrid"))
                Me.LblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(SplrId), Me.LblType), 2)
                Prordid = Trim(TpoRdr1("Saleid"))
                Me.txtvCode.Text = Trim(TpoRdr1("Splr_code"))
                Me.TxtVname.Text = Trim(TpoRdr1("splr_name"))
                Select_2rec_with_where(Me.CmbxWareh, SplrId)
                Me.CmbxWareh.SelectedValue = TpoRdr1("Salelocid")
                Me.CmbxCarri.SelectedValue = TpoRdr1("Saleshpid")
                Select_Salepircelst_where(Me.CmbxPlist, SplrId)
                Me.CmbxPlist.SelectedValue = TpoRdr1("Salepriceid")
                SpCid = TpoRdr1("SPlr_spcatid") ' Me.Cmbxspcatid.FindString(Trim(Fetch_vatname()), 0)
                DefltVatCst = SpCid
                If SpCid > 0 Then
                    Me.Cmbxspcatid.SelectedValue = SpCid 'TpoRdr1("SPlr_spcatid")
                    ''Me.Cmbxspcatid.Enabled = False
                Else
                    '' Me.Cmbxspcatid.Enabled = True
                    Me.Cmbxspcatid.SelectedIndex = 0
                End If
                ''If Cl_Kbl = True Then
                ''    Me.TxtSaleBillNo.Text = xFetchVno_AccordingVATBillType(SplrId, CInt(Me.Cmbxspcatid.SelectedValue))
                ''End If
                Me.Txtcoment.Text = Trim(TpoRdr1("Salermrk"))
                Dim xAgntId As Integer = CInt(xDynamic_Find_xAnItem_xInA_Table_1cond("splrAgntId", "Splrid", CInt(SplrId), "FinactSplrmstr"))
                If xAgntId > 0 Then
                    Me.CmbxAgent.SelectedValue = xAgntId
                Else
                    Me.CmbxAgent.SelectedIndex = 0
                End If

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            TpoCmd1.Dispose()
            TpoRdr1.Close()
            Exit Sub
        Finally
            TpoCmd1.Dispose()
            TpoRdr1.Close()
            XSelect_from_Xsplrmstr_Xinfo("Customer", SplrId)
            Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))
        End Try
        Try
            Dim DgItms As DataGridView
            DgItms = Me.DgSaleDirect
            DgItms.Columns.Clear()
            Dim xx As Integer = 0
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            For xx = 0 To Selected_xSelectedOrdr_xId.Length - 1
                TpoCmd1 = New SqlCommand("Finact_SaleOrderEntry_Details_Where_Concrnid", FinActConn1)
                TpoCmd1.CommandType = CommandType.StoredProcedure
                TpoCmd1.Parameters.AddWithValue("@PordConcrnid", Selected_xSelectedOrdr_xId(xx))
                TpoCmd1.ExecuteNonQuery()
                TpoCmd1.Dispose()
            Next

            TpoCmd1 = New SqlCommand("Finact_Temp_SaleOrderEntry_Details_SELECT", FinActConn1)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoAdptr = New Data.SqlClient.SqlDataAdapter(TpoCmd1)
            dtaset = New Data.DataSet()
            TpoAdptr.Fill(dtaset, "finactSaleorder_details")
            DgItms.DataSource = dtaset.Tables("finactSaleorder_details")

            ' DgItms.Columns.Add("ColQnty", "Quantity")
            '0
            DgItms.Columns(0).HeaderText = "Quantity"
            DgItms.Columns(0).Name = "ColQnty"
            Dim dt As DataGridViewTextBoxColumn = TryCast(DgItms.Columns(0), DataGridViewTextBoxColumn)
            dt.MaxInputLength = 10
            DgItms.Columns(0).Width = 80
            DgItms.Columns(0).DefaultCellStyle.Format = "N3"
            DgItms.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(0).DefaultCellStyle.NullValue = Nothing
            DgItms.Columns(0).ReadOnly = True

            '1
            'DgItms.Columns.Add("ColItemid", "Item Name")
            DgItms.Columns(1).HeaderText = "Item Name"
            DgItms.Columns(1).Name = "ColItemid"
            DgItms.Columns(1).Width = 200
            DgItms.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ' DgItms.Columns(2).ReadOnly = True
            '2
            'DgItms.Columns.Add("ColDiscription", "Discription")
            DgItms.Columns(2).HeaderText = "Discription"
            DgItms.Columns(2).Name = "ColDiscription"
            DgItms.Columns(2).Width = 0
            DgItms.Columns(2).Visible = False
            '3
            ' DgItms.Columns.Add("colCost", "Rate")
            DgItms.Columns(3).HeaderText = "Rate"
            DgItms.Columns(3).Name = "colCost"
            DgItms.Columns(3).Width = 80
            DgItms.Columns(3).DefaultCellStyle.Format = "N2"
            DgItms.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(3).DefaultCellStyle.NullValue = Nothing
            '4
            'DgItms.Columns.Add("ColUnittype", "Unit Type")
            DgItms.Columns(4).HeaderText = "Unit Type"
            DgItms.Columns(4).Name = "ColUnittype"
            DgItms.Columns(4).Width = 50
            DgItms.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '5
            ' DgItms.Columns.Add("colAmt", "Amount")
            DgItms.Columns(5).HeaderText = "Amount"
            DgItms.Columns(5).Name = "colAmt"
            DgItms.Columns(5).Width = 100
            DgItms.Columns(5).DefaultCellStyle.Format = "N2"
            DgItms.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '6
            'DgItms.Columns.Add("ColITmId", "Item id") 'Rec id
            DgItms.Columns(6).HeaderText = "Item id"
            DgItms.Columns(6).Name = "ColITmId"
            DgItms.Columns(6).Width = 0
            DgItms.Columns(6).Visible = False
            '7
            '  DgItms.Columns.Add("CoICode", "Item Code") 'Item id
            DgItms.Columns(7).HeaderText = "Item id"
            DgItms.Columns(7).Name = "CoICode"
            DgItms.Columns(7).DefaultCellStyle.Format.ToString()
            DgItms.Columns(7).Width = 0
            DgItms.Columns(7).Visible = False
            '8
            'DgItms.Columns.Add("ColStatus", "itemcode")
            DgItms.Columns(8).HeaderText = "Item Code"
            DgItms.Columns(8).Name = "ColStatus"
            DgItms.Columns(8).Width = 80
            DgItms.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DgItms.Columns(8).Visible = True
            '9
            ' DgItms.Columns.Add("xOrdrNo", "Order No.") 'Sale Order Id
            DgItms.Columns(9).HeaderText = "Order No."
            DgItms.Columns(9).Name = "xOrdrNo"
            DgItms.Columns(9).Width = 0
            DgItms.Columns(9).Visible = False

            '10
            ' DgItms.Columns.Add("xCartNo", "Carton No.")
            DgItms.Columns(10).HeaderText = "Carton No."
            DgItms.Columns(10).Name = "xCartNo"
            DgItms.Columns(10).Width = 90
            DgItms.Columns(10).Visible = True
            DgItms.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DgItms.Columns(10).DefaultCellStyle.NullValue = Nothing

            '11
            DgItms.Columns.Add("ColRQnty", "Issued Qnty.")
            'DgItms.Columns(11).HeaderText = "Issued Quantity"
            'DgItms.Columns(11).Name = "ColRQnty"
            Dim dt1 As DataGridViewTextBoxColumn = TryCast(DgItms.Columns(0), DataGridViewTextBoxColumn)
            dt1.MaxInputLength = 10
            DgItms.Columns(11).Width = 100
            DgItms.Columns(11).DefaultCellStyle.Format = "N3"
            DgItms.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(11).DefaultCellStyle.NullValue = Nothing
            DgItms.Columns(11).DisplayIndex = 3
            Dim rc As Integer = 0
            For rc = 0 To Me.DgSaleDirect.Rows.Count - 1
                Me.DgSaleDirect.Rows(rc).Cells(11).Value = Me.DgSaleDirect.Rows(rc).Cells(0).Value 'handle null value
            Next
            '12
            DgItms.Columns.Add("ColInStok", "Sotck In Hand")
            DgItms.Columns(12).Width = 0
            DgItms.Columns(12).DefaultCellStyle.Format = "N3"
            DgItms.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(12).DefaultCellStyle.NullValue = Nothing
            DgItms.Columns(12).Visible = False

            '13
            DgItms.Columns.Add("ColresStok", "Edit Flag")
            DgItms.Columns(13).Width = 0
            DgItms.Columns(13).Visible = False
            DgItms.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DgItms.Columns(13).DefaultCellStyle.NullValue = Nothing

            DgItms.MultiSelect = False
            DgItms.AllowUserToDeleteRows = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd1.Dispose()
            TpoAdptr.Dispose()
            'Dim xcol As Integer = Me.DgSaleDirect.ColumnCount - 1
            'Me.DgSaleDirect.Columns(xcol).Visible = False
        End Try
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

    Private Sub Mtxtdisvalue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Mtxtdisvalue.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Mtxtdisvalue_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub MTxtTotlamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MTxtTotlamt.GotFocus
        Me.MTxtTotlamt.BackColor = Color.White
        Me.MTxtTotlamt.SelectAll()
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
        ' Me.DgSaleDirect.Rows.Clear()
        Me.mskTxtVAtCst.Text = 0
        Me.Label33.Visible = False
        Me.RbAdnl1.Visible = False
        Me.RbAdnl2.Visible = False
        Me.CmbxAdnlDis.Visible = False


    End Sub

    Private Function SumOf_Txtvalues() As Double
        Dim v1, v2, v3, v4, v5, v6, v7 As Double
        v7 = 0
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
            Cmbxspcatid.DroppedDown = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Cmbxspcatid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.Leave
        Try
            If Cl_TimeIndia = False Then
                Me.TxtSaleBillNo.Text = xFetchVno_AccordingVATBillType(SplrId, CInt(Me.Cmbxspcatid.SelectedValue), dtpordrdt)
            End If

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

            If Me.Panel8.Enabled = False Then

                Me.DgSaleDirect.Focus()
                If Me.DgSaleDirect.Rows.Count = 0 Then
                    Nrow = New DataGridViewRow
                    Me.DgSaleDirect.Rows.Add()
                End If
                Dim rx As Integer = Me.DgSaleDirect.Rows.Count - 1
                Me.DgSaleDirect.Rows(rx).Cells(0).Selected = True

            End If

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

        If e.ColumnIndex = 11 Or e.ColumnIndex = 3 Then
            If Me.DgSaleDirect.CurrentRow.Cells(11).Value > Me.DgSaleDirect.CurrentRow.Cells(0).Value Then
                Me.DgSaleDirect.CurrentCell.ErrorText = "Quantity should be equal or less than Ordered Quantity"
            Else
                Me.DgSaleDirect.CurrentCell.ErrorText = ""
                Dim xCurItemId As Integer = Me.DgSaleDirect.CurrentRow.Cells(7).Value
                If Me.DgSaleDirect.CurrentRow.Cells(11).Value > SumOf_In_and_Outward_Items(xCurItemId, xCurItemId) Then
                    Me.DgSaleDirect.CurrentRow.Cells(11).ErrorText = "Negetive Stock"
                    Me.DgSaleDirect.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow
                    '  Me.DgSaleDirect.CurrentRow.HeaderCell.ErrorText = "Negetive Stock"
                End If
                CalculateCellValues()
            End If
        End If

    End Sub
    Private Sub ResetPriceList_AllGridItems()
        Try
            Try
                Dim xC As Integer = 0
                For xC = 0 To Me.DgSaleDirect.Rows.Count - 1
                    Dim xCurItemId As Integer = Me.DgSaleDirect.Rows(xC).Cells(7).Value
                    If Me.DgSaleDirect.Rows(xC).Cells(11).Value > SumOf_In_and_Outward_Items(xCurItemId, xCurItemId) Then
                        Me.DgSaleDirect.Rows(xC).Cells(11).ErrorText = "Negetive Stock"
                        Me.DgSaleDirect.Rows(xC).DefaultCellStyle.BackColor = Color.Yellow
                        '  Me.DgSaleDirect.Rows(xC).HeaderCell.ErrorText = "Negetive Stock"
                    End If
                Next
                CalculateCellValues_ifCurrentpricelistchanged()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
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
                    val2 = Me.DgSaleDirect.Rows(xcc).Cells(11).Value
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
                        ' Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)

                    Next

                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally


        End Try

    End Sub

    Private Sub DgSaleDirect_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSaleDirect.CellEnter
        Try
            If e.ColumnIndex >= 0 Then
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
            End If

            If e.ColumnIndex = 1 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
                Me.DgSaleDirect.CurrentRow.Cells(e.ColumnIndex).ReadOnly = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgSaleDirect_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgSaleDirect.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgSaleDirect.Rows.Count '- 1
            If Cr_Row <> Me.DgSaleDirect.CurrentRow.Index Then
                If e.ColumnIndex = 0 Or e.ColumnIndex = 3 Or e.ColumnIndex = 11 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        'Me.DgSaleDirect.CurrentCell.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        'Me.DgSaleDirect.CurrentCell.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgSaleDirect_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSaleDirect.CellValueChanged
        Static RedirectingCell As Boolean = False 'also consider keyup event of this grid
        If Not RedirectingCell Then
            Try
                RedirectingCell = False
                Dim val1, val2, val3, val4, val5, val6, val7, val8 As Double
                val4 = 0
                If e.ColumnIndex = 0 Then
                    RedirectingCell = True
                    If Me.DgSaleDirect.CurrentRow.Cells(0).Value <> Nothing Then
                        val1 = Me.DgSaleDirect.CurrentRow.Cells(0).Value
                        val2 = Me.DgSaleDirect.CurrentRow.Cells(3).Value
                        val3 = val1 * val2
                        Me.DgSaleDirect.CurrentRow.Cells(0).Value = (val1)
                        Me.DgSaleDirect.CurrentRow.Cells(3).Value = (val2)
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
                            val8 = val4 - (val5 + CDbl(Me.LblAdlDis.Text))
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
                If e.ColumnIndex = 3 Then
                    RedirectingCell = True
                    If Me.DgSaleDirect.CurrentRow.Cells(3).Value <> Nothing Then

                        val1 = Me.DgSaleDirect.CurrentRow.Cells(0).Value
                        val2 = Me.DgSaleDirect.CurrentRow.Cells(3).Value
                        val3 = val1 * val2
                        Me.DgSaleDirect.CurrentRow.Cells(0).Value = FormatNumber(val1, 3)
                        Me.DgSaleDirect.CurrentRow.Cells(3).Value = FormatNumber(val2, 2)
                        Me.DgSaleDirect.CurrentRow.Cells(5).Value = FormatNumber(val3, 2)
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
                            ''  Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                            ' End If
                        Next
                    End If
                End If
            Catch ex As Exception

            End Try
        End If

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
                If Me.DgSaleDirect.CurrentCell.ColumnIndex = 3 Then
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(10, Me.DgSaleDirect.CurrentCell.RowIndex)
                    Exit Sub
                End If
                If Me.DgSaleDirect.CurrentCell.ColumnIndex = 10 Then
                    If Trim(Me.DgSaleDirect.CurrentRow.Cells(0).Value) <> Nothing And Trim(Me.DgSaleDirect.CurrentRow.Cells(1).Value) <> Nothing And Trim(Me.DgSaleDirect.CurrentRow.Cells(3).Value) <> Nothing Then
                        Dim Val1 As Double
                        Dim ic As String
                        ic = Me.DgSaleDirect.CurrentRow.Cells(1).Value
                        Val1 = Me.DgSaleDirect.CurrentRow.Cells(0).Value

                        If Not (Val1) > 0 Then
                            Me.DgSaleDirect.CurrentRow.Cells(0).ErrorText = "Value should be greater than zero"
                        Else
                            Me.DgSaleDirect.CurrentRow.Cells(0).ErrorText = ""
                            If Me.DgSaleDirect.CurrentCell.RowIndex < Me.DgSaleDirect.RowCount - 1 Then
                                Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentCell.RowIndex + 1)
                            Else
                                Me.BtnPe_Save.Focus()
                            End If

                        End If
                    End If
                    If Me.DgSaleDirect.CurrentCell.RowIndex < Me.DgSaleDirect.RowCount - 1 Then
                        Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(0, Me.DgSaleDirect.CurrentCell.RowIndex + 1)
                    End If
                Else
                    Dim xx As Integer = CInt(Me.DgSaleDirect.CurrentCell.ColumnIndex)
                    Dim xxx As Integer = 1
                    If xx = 1 Then
                        xxx = 2 '==because of coloumn no 2 is visible false, so it jump that col.
                    Else
                        xxx = 1
                    End If
                    Me.DgSaleDirect.CurrentCell = Me.DgSaleDirect.Item(Me.DgSaleDirect.CurrentCell.ColumnIndex + xxx, Me.DgSaleDirect.CurrentCell.RowIndex)
                End If
            End If
            e.Handled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub chk_Emptyvalue()
        Try
            With Me.Cmbxspcatid
                If .SelectedIndex = -1 Then
                    .SelectedValue = SpCid
                Else
                    .BackColor = Color.White
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
            MsgBox(ex.Message)
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

    ''Private Sub Fetch_vatrate(cint(Me.Cmbxspcatid.SelectedValue ))
    ''    Try
    ''        TpoCmd = New SqlCommand("select spcattxrate from Finactsalepurcatgry where spcatid=@catid", FinActConn)
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
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Me.mskTxtVAtCst.Focus()
        Me.mskTxtVAtCst.SelectAll()
    End Sub

    Private Sub If_VAtrate_changed_then()
        Try
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
                    '' Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Cmbxdistype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxdistype.TextChanged
        Me.Mtxtdisvalue.Text = 0
        Me.lbldiscount.Text = 0
    End Sub

    Private Sub Txtcustname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcustname.Leave
        If Me.lstvewcustlist.Items.Count > 0 Then
            Me.lstvewcustlist.Focus()
        Else
            Me.Txtcustname.Focus()
        End If
    End Sub

    Private Sub DgSaleDirect_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgSaleDirect.KeyUp
        If Me.DgSaleDirect.CurrentCell IsNot Nothing AndAlso WishedForCell IsNot Nothing Then
            Me.DgSaleDirect.CurrentCell = WishedForCell
            WishedForCell = Nothing
        End If
    End Sub


    Private Sub CalculateCellValues()
        Try
            Dim val1, val2, val3, val4, val5, val6, val7, val8 As Double
            val4 = 0
            If Me.DgSaleDirect.CurrentCell.ColumnIndex = 10 Then
                'RedirectingCell = True
                If Me.DgSaleDirect.CurrentRow.Cells(11).Value <> Nothing Then
                    val1 = Me.DgSaleDirect.CurrentRow.Cells(3).Value
                    val2 = Me.DgSaleDirect.CurrentRow.Cells(11).Value
                    val3 = val1 * val2
                    Me.DgSaleDirect.CurrentRow.Cells(3).Value = (val1)
                    Me.DgSaleDirect.CurrentRow.Cells(11).Value = (val2)
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
                        val8 = val4 - (val5 + CDbl(Me.LblAdlDis.Text))
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
            If Me.DgSaleDirect.CurrentCell.ColumnIndex = 3 Then
                'RedirectingCell = True
                If Me.DgSaleDirect.CurrentRow.Cells(3).Value <> Nothing Then
                    val1 = Me.DgSaleDirect.CurrentRow.Cells(3).Value
                    val2 = Me.DgSaleDirect.CurrentRow.Cells(11).Value
                    val3 = val1 * val2
                    Me.DgSaleDirect.CurrentRow.Cells(3).Value = (val1)
                    Me.DgSaleDirect.CurrentRow.Cells(11).Value = (val2)
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
                        val8 = val4 - (val5 + CDbl(Me.LblAdlDis.Text))
                        Me.mskTxtVAtCst.Text = FormatNumber(val8 * VATCST / 100, 2)
                        If IsNumeric(Me.mskTxtVAtCst.Text) Then
                            val6 = Me.mskTxtVAtCst.Text
                        Else
                            val6 = 0
                        End If
                        val7 = Me.lbltoc.Text
                        ''  Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                        ' End If
                    Next

                End If
            End If
        Catch ex As Exception

        End Try
        'End If
    End Sub
    Private Function XSelect_from_Xsplrmstr_Xinfo(ByVal SpType As String, ByVal Spid As Integer) As Boolean
        Try
            TpoCmd = New SqlCommand("Select splrid,splrname,splrcrlmt,splrtype,splrdiscom,splrdisdays,splrnetday from finactsplrmstr where splrtype=@sptype and splrid=@spid", FinActConn)
            TpoCmd.Parameters.AddWithValue("@sptype", SpType)
            TpoCmd.Parameters.AddWithValue("@spid", Spid)
            TpoRdr = TpoCmd.ExecuteReader
            TpoRdr.Read()
            If TpoRdr.IsDBNull(0) = False Then
                dy = TpoRdr(6)
                If dy > 0 Then
                    Me.DtpSaleDue.Value = Me.dtpordrdt.Value.AddDays(dy)
                Else
                    Me.DtpSaleDue.Value = Me.dtpordrdt.Value
                End If
                Dim dis As Double = TpoRdr(4)
                If dis > 0 Then
                    Me.Cmbxdistype.SelectedIndex = 1
                    Me.Mtxtdisvalue.Text = FormatNumber(dis, 3)
                    DisVal = Me.Mtxtdisvalue.Text
                Else
                    Me.Mtxtdisvalue.Text = 0
                End If
                Return True
            Else
                Return False

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd.Dispose()
            TpoRdr.Close()
        End Try
    End Function


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

    Private Sub Cmbxspcatid_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.SelectionChangeCommitted
        Try
            CalculateCellValues_ifCurrentpricelistchanged()
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


    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPe_Save.GotFocus, BtnPe_exit.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPe_Save.Leave, BtnPe_exit.Leave
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
    Private Sub mskTxtVAtCst_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.TextChanged
        Try
            Dim xV As Double = CDbl(Me.mskTxtVAtCst.Text)

            Dim xSur As Double = xCal_xInvoiceSurCharge(Me.Cmbxspcatid.SelectedValue, xV, Me.Label31)
            ''Select Case xCheckxSalePur_VATStatus(xSalxPurxType)
            ''    Case 1 '==SurCharge applicable.
            ''        xSur = Math.Round(xV * 10 / 100, 3)
            ''        Me.Label31.Text = "Surcharge (10%)"
            ''    Case 2 '==SurCharge and Labour Charges Applicable.
            ''        Me.Label31.Text = "Surcharge (10%)"
            ''    Case 3 '==Labour Charges Applicable (InterStates).
            ''        Me.Label31.Text = "Surcharge (0%)"
            ''    Case Else
            ''        xSur = Math.Round(0, 3)
            ''        Me.Label31.Text = "Surcharge (0%)"
            ''End Select
            Me.LblVATCST.Text = FormatNumber(Math.Round(xV, 3), 2)
            Me.LblSurCharg.Text = FormatNumber(xSur, 2)
            If Len(lbltoc.Text.Trim) = 0 Then
                Me.lbltoc.Text = 0
            End If
            Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
        Catch ex As Exception
            '' MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub xAllContrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSbill1.GotFocus, RbSbill2.GotFocus, ChkbCariDetals.GotFocus, Chkbdisc.GotFocus, ChkbOthrCharg.GotFocus
        Try
            Dim xx As Control = CType(sender, Control)
            xx.BackColor = Color.Yellow
        Catch ex As Exception

        End Try

    End Sub
    Private Sub xAllContrl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSbill1.Leave, RbSbill2.Leave, ChkbCariDetals.Leave, Chkbdisc.Leave, ChkbOthrCharg.Leave
        Try
            Dim xx As Control = CType(sender, Control)
            xx.BackColor = Color.Transparent
            If xx.Name = "ChkbOthrCharg" Then
                If Me.ChkbOthrCharg.Checked = True Then
                    Me.Panel7.Enabled = True
                    Me.MtxtPkgcharg.Focus()
                Else
                    Me.Panel7.Enabled = False
                    OnOthrChkBxFalse()
                    Me.Cmbxspcatid.Focus()
                End If
            End If
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
                Me.BtnPe_Save.Focus()
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
                    Me.CmbxAdnlDis.SelectedIndex = 0
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
                Me.ChkbCariDetals.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class



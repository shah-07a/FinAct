Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports FinAcct.cLSmYgrid
Public Class FrmTranPurEnteryOrder
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
    Dim ErrIndx, SpCid, Prordid As Integer
    Dim DisVal As Double
    Dim dy As Double = 0
    Dim WishedForCell As DataGridViewCell = Nothing
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim xRondOff As Double = 0

    Private Sub FrmTranPurEnteryDirect_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            FrmTranPurEntrySelectOrder.fill_gridview1()
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
    Private Sub FrmTranPurOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Size = New System.Drawing.Point(834, 650)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.SplitContainer1.SplitterDistance = 575
            Me.SplitContainer1.IsSplitterFixed = True
            Select_2rec_where("Cscid", "Cscctyname", "csctype", "finactcscmstr", Me.CmbxWareh, "Inner", "CSCDELSTATUS", CInt(1))
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)
            Dim cond As String = "Purchase"
            Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", Cmbxspcatid, cond, "SPCATDELSTATUS", CInt(1))
            Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRUNDRGRUP", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), CInt(11), Me.CmbxLdgrHead)
            Dim CurOrderNo As Integer = Curr_MaxId()
            Me.TxtPurBillNo.Text = (CurOrderNo + 1)
            Date.TryParse(FinStartDt.Date, CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
            Me.dtpordrdt.MinDate = CurrDate.Date
            Me.dtpordrdt.MaxDate = FinEnddt.Date
            If Curr_MaxId() > 0 Then
                Me.dtpordrdt.Value = Curr_Maxdate()
            Else
                Me.dtpordrdt.Value = Now
            End If
            Cmbxstatus.SelectedIndex = 1
            Me.Text = "Purchase Entry (Through P.O.)" & "  (CURRENT USER NAME:- " & Trim(Current_UserName) & ",DESIGNATION:- " & Trim(Current_UserDesi)
            CreateGridColumns()
            Me.MTxtTotlamt.Text = FormatNumber(Me.lblgross.Text, 2)
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

    Private Sub CmbxCarri_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.GotFocus
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

    Private Sub CmbxCarri_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.Leave
        If FrmShow_flag(7) = True Then
            FrmShow_flag(7) = False
        End If
    End Sub

    Private Sub Cmbxstatus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxstatus.GotFocus
        If Cmbxstatus.Items.Count > 0 And Cmbxstatus.SelectedIndex = -1 Then
            Cmbxstatus.SelectedIndex = 2
        End If
        Me.Cmbxstatus.DroppedDown = True
    End Sub

    Private Sub Dtpreqstdt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtppurDue.ValueChanged
        Me.DtppurDue.MinDate = dtpordrdt.Value.Date
    End Sub

    Private Sub Mtxtdisvalue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mtxtdisvalue.GotFocus
        Try
            Me.Mtxtdisvalue.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxdistype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxdistype.GotFocus
        Try
            Me.Cmbxdistype.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Allcontrols_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkbCariDetals.KeyDown, Chkbdisc.KeyDown, ChkbOthrCharg.KeyDown _
    , Chkprnt.KeyDown, CmbxCarri.KeyDown, Cmbxdistype.KeyDown, Cmbxspcatid.KeyDown, Cmbxstatus.KeyDown, CmbxWareh.KeyDown, Dtpgrdt.KeyDown, DtppurDue.KeyDown _
    , MskInscharg.KeyDown, Mskothrchrg.KeyDown, MskPostcharg.KeyDown, mskTxtVAtCst.KeyDown, Mtxtdisvalue.KeyDown, MtxtfrtChargs.KeyDown, MtxtPkgcharg.KeyDown, MTxtTotlamt.KeyDown, mtxtulcharg.KeyDown _
    , TxtCariNo.KeyDown, Txtcoment.KeyDown, Txtcustcode.KeyDown, Txtgrno.KeyDown, TxtinsCo.KeyDown _
    , TxtItmcode.KeyDown, TxtPlcyno.KeyDown, Txtuload.KeyDown, txtvCode.KeyDown, TxtVname.KeyDown
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
                Me.TxtPurBillNo.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpordrdt_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpordrdt.ValueChanged
        Me.DtppurDue.MinDate = dtpordrdt.Value
        Me.DtppurDue.Value = dtpordrdt.Value.AddDays(dy)
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
        If lstvewcustlist.Items.Count > 0 Then
            lstvewcustlist_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub TxtItmcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItmcode.GotFocus
        TxtCond1 = 1 'set filter as Itme code
        'me.DgPurDirect.CurrentRow.Cells(1).Selected = False

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
                TpoCmd.Parameters.AddWithValue("@Sale_Pur_Type1", "Purchase")

            Else
                TpoCmd = New SqlCommand("FinAct_ItemMstr_Select_Like", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@Sale_Pur_Type1", "Purchase")
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
        If e.KeyCode = Keys.Escape Then
            Me.Tplitem.Location = New System.Drawing.Point(837, 243)
            Me.Tplitem.Visible = False
            Me.Tplitem.Enabled = False
            Me.DgPurDirect.Focus()
            If Me.DgPurDirect.CurrentRow.Cells(1).Value <> "" Then
                If Trim(Me.DgPurDirect.CurrentRow.Cells(6).Value) = "" Then
                    Me.DgPurDirect.CurrentRow.Cells(6).Value = 1 ' 1 stands for new entry
                End If
                Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(3, Me.DgPurDirect.CurrentRow.Index)
            Else
                Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(0, Me.DgPurDirect.CurrentRow.Index)
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
                If Me.DgPurDirect.CurrentRow.Cells(0).Value > 0 Then
                    If Trim(Me.DgPurDirect.CurrentRow.Cells(6).Value) = "" Then
                        Me.DgPurDirect.CurrentRow.Cells(6).Value = 1 ' 1 stands for new entry
                    End If
                    Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(3, Me.DgPurDirect.CurrentRow.Index)
                Else
                    Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(0, Me.DgPurDirect.CurrentRow.Index)
                End If
                Me.DgPurDirect.CurrentRow.Cells(1).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(0).Text)
                Me.DgPurDirect.CurrentRow.Cells(2).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(1).Text)
                Me.DgPurDirect.CurrentRow.Cells(5).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(2).Text)
                Me.DgPurDirect.CurrentRow.Cells(3).Value = Trim(LstVewItem.SelectedItems.Item(0).SubItems(3).Text)
                Me.Tplitem.Location = New System.Drawing.Point(837, 243)
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
                Me.DgPurDirect.Focus()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub

    Private Sub LstVewItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewItem.KeyDown
        If e.KeyCode = Keys.Enter Then
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
            End If
        End If
    End Sub

    Private Sub LstVewItem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.Leave
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
        Catch ex As Exception

        End Try
    End Function
    Private Function SumOf_In_and_Outward_Items(ByVal SalItemId As Integer, ByVal PurItemId As Integer) As Double
        Try
            TpoCmd1 = New SqlCommand("Finact_Sum_In_out_pur_Particularitem", FinActConn2)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@PurItemid", PurItemId)
            'TpoCmd1.Parameters.AddWithValue("@SaleItemId", SalItemId)
            TpoRdr1 = TpoCmd1.ExecuteReader
            While TpoRdr1.Read
                If TpoRdr1.HasRows = True Then
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
            Dim Xx As Integer = 0

            For Xx = 0 To Me.DgPurDirect.Rows.Count - 1
                If Trim(Me.DgPurDirect.Rows(Xx).Cells(11).ErrorText) <> "" Then
                    MsgBox("System could not save current records due to some error", MsgBoxStyle.Critical, "Remove Error!!! ")
                    Exit Sub
                End If
            Next
            chk_Emptyvalue()
            If ErrIndx <> 0 Then
                ErrIndx = 0
                Me.DgPurDirect.ReadOnly = True
                Exit Sub
            End If
            Dim val1, val2, val3 As Double
            val1 = FormatNumber(Me.MTxtTotlamt.Text, 2)
            val2 = FormatNumber(Me.lblgross.Text, 2)
            val3 = FormatNumber(Me.LblRondOff.Text, 2)
            If FormatNumber(val1, 2) <> FormatNumber(val2 + val3, 2) Then
                MsgBox("Invoice amount does not match with Gross Amount", MsgBoxStyle.Critical, "Check Invoice Amount...")
                Me.DgPurDirect.Focus()
                Exit Sub
            End If


            If MessageBox.Show("Are you sure to save this record", "Purchase Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                BtnPe_Save.Focus()
                Return
            Else
                PurEntrySave()


            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub PurEntrySave()
        If Me.DgPurDirect.Rows.Count >= 1 Then
            Try
                TpoCmd = New SqlCommand("Finact_Purentry_Insert", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@purentdt", (Me.dtpordrdt.Value))
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

                If Trim(Me.LblVATCST.Text) <> "" Then
                    TpoCmd.Parameters.AddWithValue("@purentvatamt", CDbl(Me.LblVATCST.Text))
                Else
                    TpoCmd.Parameters.AddWithValue("@purentvatamt", CDbl(0.0))
                End If
                TpoCmd.Parameters.AddWithValue("@PurEntTxAbleAmt", CDbl(Me.LbltablAmt.Text))
                TpoCmd.Parameters.AddWithValue("@PurEntVATSurChrg", Trim(Me.LblSurCharg.Text))
                TpoCmd.Parameters.AddWithValue("@PurEntRondOff", Trim(Me.xRondOff))
                TpoCmd.Parameters.AddWithValue("@purentorderid", Prordid)
                TpoCmd.Parameters.AddWithValue("@purentadusrid", Current_UsrId)
                TpoCmd.Parameters.AddWithValue("@purentaddt", Now)
                TpoCmd.Parameters.AddWithValue("@purentdelstatus", 1)
                TpoCmd.Parameters.AddWithValue("@PurEnt_UGRUP", CInt(Me.CmbxLdgrHead.SelectedValue))
                TpoCmd.Parameters.AddWithValue("@purentInvdt", Me.DtpInvDt.Value.Date)
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
                    If Me.DgPurDirect.Rows(DgCntr).Cells(11).Value > 0 Then
                        TpoCmd = New SqlCommand("Finact_Purentry_Details_Insert", FinActConn)
                        TpoCmd.CommandType = CommandType.StoredProcedure
                        TpoCmd.Parameters.AddWithValue("@dpurentconcrnid", (CurrPbillId))
                        TpoCmd.Parameters.AddWithValue("@dpurent_con_dpurid", (Me.DgPurDirect.Rows(DgCntr).Cells(6).Value))
                        TpoCmd.Parameters.AddWithValue("@dpurentitmid", (Me.DgPurDirect.Rows(DgCntr).Cells(7).Value))
                        TpoCmd.Parameters.AddWithValue("@dpurentqnty", (Me.DgPurDirect.Rows(DgCntr).Cells(11).Value))
                        TpoCmd.Parameters.AddWithValue("@dpurentitmrate", (Me.DgPurDirect.Rows(DgCntr).Cells(3).Value))
                        TpoCmd.Parameters.AddWithValue("@dpurentlocid", Me.CmbxWareh.SelectedValue)
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


            Try
                Dim DgCntr As Integer
                For DgCntr = 0 To Me.DgPurDirect.Rows.Count - 1
                    If Me.DgPurDirect.Rows(DgCntr).Cells(11).Value > 0 Then
                        TpoCmd = New SqlCommand("Finact_PurEntryRecd_Details_Update", FinActConn)
                        TpoCmd.CommandType = CommandType.StoredProcedure
                        TpoCmd.Parameters.AddWithValue("@dpurid", Trim(Me.DgPurDirect.Rows(DgCntr).Cells(6).Value))
                        TpoCmd.Parameters.AddWithValue("@dpurrecdqnty", Trim(Me.DgPurDirect.Rows(DgCntr).Cells(11).Value))
                        TpoCmd.Parameters.AddWithValue("@dpurqntyrecddt", Now)
                        TpoCmd.Parameters.AddWithValue("@dpuritmdiscr", Trim(Me.DgPurDirect.Rows(DgCntr).Cells(2).Value))
                        TpoCmd.Parameters.AddWithValue("@dpuritmrate", Trim(Me.DgPurDirect.Rows(DgCntr).Cells(3).Value))
                        TpoCmd.ExecuteNonQuery()
                    End If
                Next
                MsgBox("Current Record Has Been Updated Successfully", MsgBoxStyle.Information, "Update Record")

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
                If Change_XStatus(Prordid) = False Then
                    Change_XStatus1(Prordid)
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
            Me.DgPurDirect.Focus()
        End If

    End Sub

    Private Function Change_XStatus(ByVal cpurid As Integer) As Boolean
        Try

            TpoCmd1 = New SqlCommand("select dpurrecdstatus from FinactPurOrder_Details where dpurconcrnid=@dpurconcrnid and dpurrecdstatus=@dprStatus", FinActConn1)
            TpoCmd1.Parameters.AddWithValue("@dpurconcrnid", cpurid)
            TpoCmd1.Parameters.AddWithValue("@dprStatus", "Yet_Recd")
            TpoRdr1 = TpoCmd1.ExecuteReader
            While TpoRdr1.Read()
                If Trim(TpoRdr1(0)) = Trim("Yet_Recd") Then
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

            TpoCmd1 = New SqlCommand("update finactpurorder set purstatus=@cStatusas where purid=@Cpurid1", FinActConn1)
            TpoCmd1.Parameters.AddWithValue("@Cpurid1", Cprordrid)
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
            TpoCmd1 = New SqlCommand("select max(purentdt) from finactpurentry where purentdelstatus=1", FinActConn1)
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
        SpCid = 0

        Try
            TpoCmd1 = New SqlCommand("Finact_PurOrder_Select_Where_id", FinActConn1)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@orderid", Selected_xSelectedOrdr_xId(0))
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.HasRows = True Then
                'If TpoRdr1.IsDBNull(12) = True Then
                Me.MTxtTotlamt.Text = FormatNumber(0, 2)
                'End If
                Date.TryParse(TpoRdr1("Purorddt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.dtpordrdt.MinDate = CurrDate.Date
                Me.dtpordrdt.Value = CurrDate.Date 'Now.Date

                Me.Text = Trim("Purchase Entry(Through Purchase Order)") & " -Order No. " & Trim(TpoRdr1("purordno")) & " -Date " & Format(CurrDate, "dd/MM/yyyy") & "  Aprx. Amount =" & FormatNumber(TpoRdr1("puramt"), 2)
                Me.Cmbxstatus.Text = Trim(TpoRdr1("purstatus"))
                Date.TryParse(TpoRdr1("Purdelvrydt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                ' Me.Dtpreqstdt.Value = CurrDate
                SplrId = Trim(TpoRdr1("pursplrid"))
                Me.LblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(SplrId), Me.LblType), 2)
                Prordid = Trim(TpoRdr1("purid"))
                Me.txtvCode.Text = Trim(TpoRdr1("Splr_code"))
                Me.TxtVname.Text = Trim(TpoRdr1("splr_name"))
                Me.CmbxWareh.SelectedValue = TpoRdr1("purlocid")
                Me.CmbxCarri.SelectedValue = TpoRdr1("purshpid")
                SpCid = TpoRdr1("SPlr_spcatid") ' Me.Cmbxspcatid.FindString(Trim(Fetch_vatname()), 0)
                If SpCid > 0 Then
                    Me.Cmbxspcatid.SelectedValue = TpoRdr1("SPlr_spcatid")
                Else
                    Me.Cmbxspcatid.SelectedIndex = 0
                End If

                Me.Txtcoment.Text = Trim(TpoRdr1("purrmrk"))
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            TpoCmd1.Dispose()
            TpoRdr1.Close()
            Exit Sub
        Finally
            TpoCmd1.Dispose()
            TpoRdr1.Close()
            XSelect_from_Xsplrmstr_Xinfo("Vendor", SplrId)
            Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))
        End Try
        Try
            Dim DgItms As DataGridView
            DgItms = Me.DgPurDirect
            DgItms.Columns.Clear()
            TpoCmd1 = New SqlCommand("Finact_PurOrderEntry_Details_Where_Concrnid", FinActConn1)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@PordConcrnid", Selected_xSelectedOrdr_xId(0))

            TpoAdptr = New Data.SqlClient.SqlDataAdapter(TpoCmd1)
            dtaset = New Data.DataSet()
            TpoAdptr.Fill(dtaset, "finactpurorder_details")
            DgItms.DataSource = dtaset.Tables("finactpurorder_details")

            ' DgItms.Columns.Add("ColQnty", "Quantity")

            DgItms.Columns(0).HeaderText = "Order Quantity"
            DgItms.Columns(0).Name = "ColQnty"
            Dim dt As DataGridViewTextBoxColumn = TryCast(DgItms.Columns(0), DataGridViewTextBoxColumn)
            dt.MaxInputLength = 10
            DgItms.Columns(0).Width = 100
            DgItms.Columns(0).DefaultCellStyle.Format = "N3"
            DgItms.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(0).DefaultCellStyle.NullValue = Nothing
            DgItms.Columns(0).ReadOnly = True

            'DgItms.Columns.Add("ColItemid", "Item Name")
            DgItms.Columns(1).HeaderText = "Item Name"
            DgItms.Columns(1).Name = "ColItemid"
            DgItms.Columns(1).Width = 275
            DgItms.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ' DgItms.Columns(2).ReadOnly = True

            'DgItms.Columns.Add("ColDiscription", "Discription")
            DgItms.Columns(2).HeaderText = "Discription"
            DgItms.Columns(2).Name = "ColDiscription"
            DgItms.Columns(2).Width = 0
            DgItms.Columns(2).Visible = False

            ' DgItms.Columns.Add("colCost", "Rate")
            DgItms.Columns(3).HeaderText = "Rate"
            DgItms.Columns(3).Name = "colCost"
            DgItms.Columns(3).Width = 100
            DgItms.Columns(3).DefaultCellStyle.Format = "N2"
            DgItms.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(3).DefaultCellStyle.NullValue = Nothing
            DgItms.Columns(3).ReadOnly = True

            'DgItms.Columns.Add("ColUnittype", "Unit Type")
            DgItms.Columns(4).HeaderText = "Unit Type"
            DgItms.Columns(4).Name = "ColUnittype"
            DgItms.Columns(4).Width = 50
            DgItms.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ' DgItms.Columns.Add("colAmt", "Amount")
            DgItms.Columns(5).HeaderText = "Amount"
            DgItms.Columns(5).Name = "colAmt"
            DgItms.Columns(5).Width = 150
            DgItms.Columns(5).DefaultCellStyle.Format = "N2"
            DgItms.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(5).ReadOnly = True

            'DgItms.Columns.Add("ColITmId", "Item id")
            DgItms.Columns(6).HeaderText = "Item id"
            DgItms.Columns(6).Name = "ColITmId"
            DgItms.Columns(6).Width = 0
            DgItms.Columns(6).Visible = False

            '  DgItms.Columns.Add("CoICode", "Item Code")
            DgItms.Columns(7).HeaderText = "Item Code"
            DgItms.Columns(7).Name = "CoICode"
            DgItms.Columns(7).DefaultCellStyle.Format.ToString()
            DgItms.Columns(7).Width = 0
            'DgItms.Columns(7).Visible = False

            'DgItms.Columns.Add("ColStatus", "itemcode")
            DgItms.Columns(8).HeaderText = "Item Code"
            DgItms.Columns(8).Name = "ColStatus"
            DgItms.Columns(8).Width = 0
            DgItms.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DgItms.Columns(8).Visible = False

            DgItms.Columns.Add("ColInStok", "Sotck In Hand")
            ''DgItms.Columns(9).HeaderText = "Sotck In Hand"
            ''DgItms.Columns(9).Name = "ColInStok"
            DgItms.Columns(9).Width = 100
            DgItms.Columns(9).DefaultCellStyle.Format = "N3"
            DgItms.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(9).DefaultCellStyle.NullValue = Nothing
            DgItms.Columns(9).Visible = False

            DgItms.Columns.Add("ColresStok", "Edit Flag")
            'DgItms.Columns(10).HeaderText = "Edit Flag"
            'DgItms.Columns(10).Name = "ColresStok"
            DgItms.Columns(10).Width = 10
            DgItms.Columns(10).Visible = False
            'DgItms.Columns(10).DefaultCellStyle.Format = "No"
            DgItms.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DgItms.Columns(10).DefaultCellStyle.NullValue = Nothing

            DgItms.Columns.Add("ColRQnty", "Received Quantity")
            'DgItms.Columns(11).HeaderText = "Received Quantity"
            'DgItms.Columns(11).Name = "ColRQnty"
            Dim dt1 As DataGridViewTextBoxColumn = TryCast(DgItms.Columns(0), DataGridViewTextBoxColumn)
            dt1.MaxInputLength = 10
            DgItms.Columns(11).Width = 100
            DgItms.Columns(11).DefaultCellStyle.Format = "N3"
            DgItms.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(11).DefaultCellStyle.NullValue = Nothing
            DgItms.Columns(11).DisplayIndex = 3
            Dim rc As Integer = 0
            For rc = 0 To Me.DgPurDirect.Rows.Count - 1
                Me.DgPurDirect.Rows(rc).Cells(11).Value = Me.DgPurDirect.Rows(rc).Cells(0).Value 'handle null value

            Next
            DgItms.MultiSelect = False
            DgItms.AllowUserToDeleteRows = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd1.Dispose()
            TpoAdptr.Dispose()

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
    Private Sub Mtxtdisvalue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mtxtdisvalue.Leave
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
            If_VAtrate_changed_then()
        End If
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
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Cmbxspcatid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.Leave
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
            Me.Cmbxspcatid.SelectedValue = SpCid
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

        If e.ColumnIndex = 11 Or e.ColumnIndex = 3 Then
            If Me.DgPurDirect.CurrentRow.Cells(11).Value > Me.DgPurDirect.CurrentRow.Cells(0).Value Then
                Me.DgPurDirect.CurrentCell.ErrorText = "Quantity should be equal or less than Ordered Quantity"
            Else
                Me.DgPurDirect.CurrentCell.ErrorText = ""
                CalculateCellValues()
            End If
        End If

    End Sub

    Private Sub DgPurDirect_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPurDirect.CellEnter
        Try
            If e.ColumnIndex >= 0 Then
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
            End If

            If e.ColumnIndex = 1 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
                Me.DgPurDirect.CurrentRow.Cells(e.ColumnIndex).ReadOnly = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgPurDirect_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgPurDirect.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgPurDirect.Rows.Count '- 1
            If Cr_Row <> Me.DgPurDirect.CurrentRow.Index Then
                If e.ColumnIndex = 0 Or e.ColumnIndex = 3 Or e.ColumnIndex = 11 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        'Me.DgPurDirect.CurrentCell.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        'Me.DgPurDirect.CurrentCell.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgPurDirect_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPurDirect.CellValueChanged
        Static RedirectingCell As Boolean = False 'also consider keyup event of this grid
        If Not RedirectingCell Then
            Try
                RedirectingCell = False
                Dim val1, val2, val3, val4, val5, val6, val7, val8 As Double
                val4 = 0
                If e.ColumnIndex = 0 Then
                    RedirectingCell = True
                    If Me.DgPurDirect.CurrentRow.Cells(0).Value <> Nothing Then
                        val1 = Me.DgPurDirect.CurrentRow.Cells(0).Value
                        val2 = Me.DgPurDirect.CurrentRow.Cells(3).Value
                        val3 = val1 * val2
                        Me.DgPurDirect.CurrentRow.Cells(0).Value = (val1)
                        Me.DgPurDirect.CurrentRow.Cells(3).Value = (val2)
                        Me.DgPurDirect.CurrentRow.Cells(5).Value = (val3)
                        Dim Rc As Integer
                        For Rc = 0 To Me.DgPurDirect.Rows.Count - 1
                            If IsNumeric(Me.DgPurDirect.Rows(Rc).Cells(5).Value) Then
                                val4 += (Me.DgPurDirect.Rows(Rc).Cells(5).Value)  'Sub total
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
                            Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                            ' End If
                        Next

                    End If
                End If
                If e.ColumnIndex = 3 Then
                    RedirectingCell = True
                    If Me.DgPurDirect.CurrentRow.Cells(3).Value <> Nothing Then

                        val1 = Me.DgPurDirect.CurrentRow.Cells(0).Value
                        val2 = Me.DgPurDirect.CurrentRow.Cells(3).Value
                        val3 = val1 * val2
                        Me.DgPurDirect.CurrentRow.Cells(0).Value = FormatNumber(val1, 3)
                        Me.DgPurDirect.CurrentRow.Cells(3).Value = FormatNumber(val2, 2)
                        Me.DgPurDirect.CurrentRow.Cells(5).Value = FormatNumber(val3, 2)
                        Dim Rc As Integer
                        For Rc = 0 To Me.DgPurDirect.Rows.Count - 1

                            If IsNumeric(Me.DgPurDirect.Rows(Rc).Cells(5).Value) Then
                                val4 += (Me.DgPurDirect.Rows(Rc).Cells(5).Value)  'Sub total
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
                            Me.lblgross.Text = FormatNumber((val4 + val6 + val7) - val5, 2)
                            ' End If
                        Next
                    End If
                End If
            Catch ex As Exception

            End Try
        End If

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
                If Me.DgPurDirect.CurrentCell.ColumnIndex = 3 Then
                    If Trim(Me.DgPurDirect.CurrentRow.Cells(0).Value) <> Nothing And Trim(Me.DgPurDirect.CurrentRow.Cells(1).Value) <> Nothing And Trim(Me.DgPurDirect.CurrentRow.Cells(3).Value) <> Nothing Then
                        Dim Val1 As Double
                        Dim ic As String
                        ic = Me.DgPurDirect.CurrentRow.Cells(1).Value
                        Val1 = Me.DgPurDirect.CurrentRow.Cells(0).Value

                        If Not (Val1) > 0 Then
                            Me.DgPurDirect.CurrentRow.Cells(0).ErrorText = "Value should be greater than zero"
                        Else
                            'Me.DgPurDirect.CurrentRow.Cells(0).ErrorText = ""
                            If Trim(Me.DgPurDirect.CurrentRow.Cells(0).ErrorText) <> "" Or Trim(Me.DgPurDirect.CurrentRow.Cells(1).ErrorText) <> "" Then
                                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                                Exit Sub
                            Else
                                Me.DgPurDirect.CurrentRow.Cells(0).ErrorText = ""
                                If Me.DgPurDirect.CurrentCell.RowIndex < Me.DgPurDirect.RowCount - 1 Then
                                    Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(0, Me.DgPurDirect.CurrentCell.RowIndex + 1)
                                Else
                                    Me.BtnPe_Save.Focus()
                                End If

                            End If

                        End If
                    End If

                    If Me.DgPurDirect.CurrentCell.RowIndex < Me.DgPurDirect.RowCount - 1 Then
                        Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(0, Me.DgPurDirect.CurrentCell.RowIndex + 1)
                    End If
                Else
                    Dim xx As Integer = CInt(Me.DgPurDirect.CurrentCell.ColumnIndex)
                    Dim xxx As Integer = 1
                    If xx = 1 Then
                        xxx = 2 '==because of coloumn no 2 is visible false, so it jump that col.
                    Else
                        xxx = 1
                    End If
                    Me.DgPurDirect.CurrentCell = Me.DgPurDirect.Item(Me.DgPurDirect.CurrentCell.ColumnIndex + xxx, Me.DgPurDirect.CurrentCell.RowIndex)
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

            With TxtPurBillNo
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
    ''        TpoCmd = New SqlCommand("select spcattxrate from finactSalePurCatgry where spcatid=@catid", FinActConn)
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
    ''Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
    ''    Me.mskTxtVAtCst.Focus()
    ''    Me.mskTxtVAtCst.SelectAll()
    ''End Sub

    Private Sub If_VAtrate_changed_then()
        Try
            Dim val4, val5, val6, val7 As Double
            val4 = 0
            Dim Rc As Integer
            If Me.DgPurDirect.Rows.Count > 0 Then
                For Rc = 0 To Me.DgPurDirect.Rows.Count - 1
                    If IsNumeric(Me.DgPurDirect.Rows(Rc).Cells(5).Value) Then
                        val4 += (Me.DgPurDirect.Rows(Rc).Cells(5).Value)  'Sub total
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

    Private Sub DgPurDirect_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgPurDirect.KeyUp
        If Me.DgPurDirect.CurrentCell IsNot Nothing AndAlso WishedForCell IsNot Nothing Then
            Me.DgPurDirect.CurrentCell = WishedForCell
            WishedForCell = Nothing
        End If
    End Sub

    Private Sub Cmbxspcatid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.SelectedIndexChanged

    End Sub
    Private Sub CalculateCellValues()
        Try
            Dim val1, val2, val3, val4, val5, val6, val7, val8 As Double
            val4 = 0
            If Me.DgPurDirect.CurrentCell.ColumnIndex = 11 Then
                'RedirectingCell = True
                If Me.DgPurDirect.CurrentRow.Cells(11).Value <> Nothing Then
                    val1 = Me.DgPurDirect.CurrentRow.Cells(3).Value
                    val2 = Me.DgPurDirect.CurrentRow.Cells(11).Value
                    val3 = val1 * val2
                    Me.DgPurDirect.CurrentRow.Cells(3).Value = (val1)
                    Me.DgPurDirect.CurrentRow.Cells(11).Value = (val2)
                    Me.DgPurDirect.CurrentRow.Cells(5).Value = (val3)
                    Dim Rc As Integer
                    For Rc = 0 To Me.DgPurDirect.Rows.Count - 1
                        If IsNumeric(Me.DgPurDirect.Rows(Rc).Cells(5).Value) Then
                            val4 += (Me.DgPurDirect.Rows(Rc).Cells(5).Value)  'Sub total
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
                    val2 = Me.DgPurDirect.CurrentRow.Cells(11).Value
                    val3 = val1 * val2
                    Me.DgPurDirect.CurrentRow.Cells(3).Value = (val1)
                    Me.DgPurDirect.CurrentRow.Cells(11).Value = (val2)
                    Me.DgPurDirect.CurrentRow.Cells(5).Value = (val3)
                    Dim Rc As Integer
                    For Rc = 0 To Me.DgPurDirect.Rows.Count - 1
                        If IsNumeric(Me.DgPurDirect.Rows(Rc).Cells(5).Value) Then
                            val4 += (Me.DgPurDirect.Rows(Rc).Cells(5).Value)  'Sub total
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
                    Me.DtppurDue.Value = Me.dtpordrdt.Value.AddDays(dy)
                Else
                    Me.DtppurDue.Value = Me.dtpordrdt.Value
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

    Private Sub Cmbxspcatid_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxspcatid.SelectionChangeCommitted
        Try
            CalculateCellValues()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPeall_Save_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPe_Save.GotFocus, BtnPe_Save.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPe_Save_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPe_Save.Leave, BtnPe_exit.Leave
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
    Private Sub lbltoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbltoc.TextChanged
        Try
            Me.lblgross.Text = FormatNumber(CDbl(Me.LbltablAmt.Text) + CDbl(Me.LblVATCST.Text) + CDbl(Me.LblSurCharg.Text) + CDbl(Me.lbltoc.Text), 2)
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


    Private Sub mskTxtVAtCst_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskTxtVAtCst.TextChanged
        Try
            Dim xV As Double = CDbl(Me.mskTxtVAtCst.Text)

            If Len(xSalxPurxType.Trim) = 0 And Not Me.Cmbxspcatid.SelectedIndex = -1 Then
                Fetch_vatrate(CInt(Me.Cmbxspcatid.SelectedValue))
            End If

            Dim xSur As Double = xCal_xInvoiceSurCharge(Me.Cmbxspcatid.SelectedValue, xV, Me.Label32)

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


    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            If Len(Me.LbltablAmt.Text) > 0 Then
                Me.TxtTxableAmt.Text = FormatNumber(Me.LbltablAmt.Text, 2)
                Me.TxtTxableAmt.Location = New System.Drawing.Point(653, 472)
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


    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            If Len(Me.LblSurCharg.Text) > 0 Then
                Me.TxtSurChrg.Text = FormatNumber(Me.LblSurCharg.Text, 2)
                Me.TxtSurChrg.Location = New System.Drawing.Point(653, 510)
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
            ToolStripMenuItem2_Click(sender, e)
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
            ToolStripMenuItem3_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If Len(Me.LblVATCST.Text) > 0 Then
                Me.TxtVATamt.Text = FormatNumber(Me.LblVATCST.Text, 2)
                Me.TxtVATamt.Location = New System.Drawing.Point(653, 491)
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
                Me.Cmbxspcatid.Focus()
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

    Private Sub MTxtTotlamt_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MTxtTotlamt.MaskInputRejected

    End Sub
End Class




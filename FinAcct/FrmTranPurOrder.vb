Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports FinAcct.cLSmYgrid
Public Class FrmTranPurOrder
    Dim TpoCmd As SqlCommand
    Dim TpoRdr As SqlDataReader
    Dim TpoAdptr As SqlDataAdapter
    Dim TpoCmd1 As SqlCommand
    Dim TpoRdr1 As SqlDataReader
    Dim TxtCond As Boolean 'for Custmor list
    Dim TxtCond1 As Integer = 0 'for item list
    Dim CurIndx As Integer
    Dim NewRow As DataGridViewRow
    Dim ValQnty As Double = 0
    Dim ValRate As Double = 0
    Dim ValAmt As Double
    Dim SplrId As Integer = 0
    Dim MaxSplid As Integer = 0
    Dim LstIndx As Integer = 0
    Dim TptId As Integer = 0
    Dim AlRdy_Ordr As Double = 0
    Dim xLes As Integer = 0
    Dim xMin, xMax As Double
    Dim SetCur_Dupli_vali As Boolean
    Dim xStatusIndx1 As Integer = 0


    Private Sub FrmTranPurOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New System.Drawing.Point(930, 613)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.ChkBx1.Checked = False
            Me.SplitContainer1.SplitterDistance = 466
            Me.Top = 0
            Me.Left = 0
            Me.lblusrname.Text = Trim(Current_UserName)
            Me.lblusrdesi.Text = Trim(Current_UserDesi)
            Select_2rec_with_Union_where(Me.CmbxWareh, SplrId)
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)
            Dim CurOrderNo As Integer = Curr_MaxId()
            Me.Txtordrno.Text = (CurOrderNo + 1)
            If Curr_MaxId() > 0 Then
                Me.dtpordrdt.MinDate = Curr_Maxdate(Curr_MaxId)
            Else
                Me.dtpordrdt.MinDate = FinStartDt.Date
            End If

            Me.dtpordrdt.MaxDate = FinEnddt.Date

            CmbxFret.SelectedIndex = 3
            Me.Cmbxstatus.Items.Clear()
            If FrmShow_flag(9) = True Then 'Edit Mode
                Me.Cmbxstatus.Items.AddRange(New Object() {"Comleted", "Cancelled", "On Order", "WorkSheet"}) 'Indx 1,0,2,3
                CreateGridColumns()
                Dim Cinx As Integer
                Select Case x_OrdrStatus
                    Case Trim("Completed")
                        Cinx = 1
                    Case Trim("Cancelled")
                        Cinx = 0
                    Case Trim("On Order")
                        Cinx = 2
                    Case Trim("Worksheet")
                        Cinx = 3
                End Select
                Cmbxstatus.SelectedIndex = Cinx

            Else
                Me.Cmbxstatus.Items.AddRange(New Object() {"On Order", "WorkSheet"})
                Cmbxstatus.SelectedIndex = 0
                Me.Dgitmems.Rows.Add()
            End If
            Me.CmbxFret.SelectedIndex = 0
            If SetCaptions = True Then
                Me.Text = "New Purchase Order"
                Me.BtnO_Save.Text = "&Save"
            ElseIf SetCaptions = False Then
                Me.Text = "Edit Purchase Order"
                Me.BtnO_Save.Text = "&Update"
            End If
            Me.RbxName.Checked = True
            Dim tStr As String = Trim(Txtcustcode.Text)
            find_Customer_list(tStr)
            Dim ItmStr As String = Trim(TxtItmcode.Text)
            find_Item_list(ItmStr)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub Fetch_VenderRecord()
        TpoCmd = New SqlCommand()
    End Sub
    Private Sub find_Customer_list(ByVal CurString As String)
        Dim i As Integer
        lstvewcustlist.Items.Clear()
        Try
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
                If TpoRdr.IsDBNull(0) = False Then
                    Dim lstvew As ListViewItem
                    lstvew = Me.lstvewcustlist.Items.Add(TpoRdr(4)) 'id
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(1)) '+ " " + TpoRdr(2)) 'name
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(0))
                    Me.lstvewcustlist.Items(i).SubItems.Add(Trim(TpoRdr(5)) & " " & Trim(TpoRdr(6)) & " " & Trim(TpoRdr(7)) & " " & Trim(TpoRdr(8)) & " " & Trim(TpoRdr(9)) & " " & Trim(TpoRdr(10))) 'adrs
                    Me.lstvewcustlist.Items(i).SubItems.Add(TpoRdr(11))
                End If
                i = i + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd = Nothing
            TpoRdr.Close()
        End Try

        Try
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
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtVcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvCode.GotFocus
        Try
            TxtCond = False
            Me.tplcustlist.Location = New System.Drawing.Point(91, 133)
            Me.tplcustlist.Visible = True
            Me.tplcustlist.Enabled = True
            If Me.BtnO_Save.Text.Trim = "&Update" Then
                Me.Txtcustcode.Text = Trim("")
            Else
                Me.Txtcustcode.Text = Trim(Me.txtvCode.Text)
            End If
            Me.Txtcustcode.Focus()
        Catch ex As Exception

        End Try
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
                Me.tplcustlist.Visible = False
                Me.tplcustlist.Enabled = False
                If Trim(Me.txtvCode.Text) <> "" Then
                    Me.CmbxWareh.Focus()
                Else
                    Me.Dtpreqstdt.Focus()
                End If
            End If
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

    Private Sub Txtcustcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcustcode.Leave
        Try
            'lstvewcustlistDoubleClick()
            If Not LstIndx >= 0 Then
                Me.Txtcustcode.Focus()
                Me.Txtcustcode.SelectAll()
            End If
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
    Private Sub GoToItemByVal(ByVal LsV As ListView, ByVal Txt As String)
        Try
            Dim itmX As ListViewItem = LsV.FindItemWithText(Trim(Txt), False, 1)
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
            ' LstIndx = -1
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
                TptId = Trim(Me.lstvewcustlist.Items(LstIndx).SubItems(4).Text)
                Me.tplcustlist.Location = New System.Drawing.Point(837, 5)
                Me.tplcustlist.Visible = False
                Me.tplcustlist.Enabled = False
                Me.Txtcustcode.Text = ""
                Me.CmbxWareh.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xCustId_EditMode = SplrId '===For use in Edit mode at run time
            If Me.CmbxCarri.Items.Count > 0 Then
                Me.CmbxCarri.SelectedValue = xDynamic_Find_xAnItem_xInA_Table_1cond("SplrCarriid", "Splrid", SplrId, "FinactSplrmstr")
            End If
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

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnAddCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCust.Click
        Try
            Dim frmact As New FrmActMstr
            frmact.ShowInTaskbar = False
            FrmShow_flag(5) = True
            FrmShow_flag(24) = True '===For use to set account type Vendor by default and enabled false of cmbx
            frmact.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAddCust_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddCust.GotFocus
        Try
            If FrmShow_flag(5) = True Then
                txtvCode.Focus()
            End If
        Catch ex As Exception

        End Try
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
        Try
            CmbxWareh.DroppedDown = True
            If FrmShow_flag(6) = True Then
                Select_2rec_with_Union_where(Me.CmbxWareh, SplrId)
                Dim IntW As Integer = CmbxWareh.FindString(IntHtCmMm(6), 0)
                CmbxWareh.SelectedIndex = IntW
            Else
                Select_2rec_with_Union_where(Me.CmbxWareh, SplrId)
                If CmbxWareh.Items.Count > 0 And CmbxWareh.SelectedIndex = -1 Then
                    CmbxWareh.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxWareh_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWareh.Leave
        If FrmShow_flag(6) = True Then
            FrmShow_flag(6) = False
        End If
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
        Try
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
        Catch ex As Exception

        End Try
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
            xStatusIndx1 = Me.Cmbxstatus.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFret_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxFret.GotFocus
        Try
            Me.CmbxFret.DroppedDown = True
            If CmbxFret.Items.Count > 0 And CmbxFret.SelectedIndex = -1 Then
                CmbxFret.SelectedIndex = 3
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Dtpreqstdt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpreqstdt.GotFocus
        Try
            Me.Dtpreqstdt.MinDate = dtpordrdt.Value.Date
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtpordrdt_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpordrdt.ValueChanged
        Try
            Me.Dtpreqstdt.MinDate = dtpordrdt.Value.Date
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgitmems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgitmems.CellClick
        Try
            'Me.Panel5.Visible = False
            If FrmShow_flag(9) = True Then
                If Me.Dgitmems.Rows.Count > 0 Then
                    ' Me.DeleteToolStripMenuItem.Enabled = False
                End If
            Else
                If Me.Dgitmems.Rows.Count > 0 Then
                    Me.DeleteToolStripMenuItem.Enabled = False
                Else
                    Me.DeleteToolStripMenuItem.Enabled = True
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgitmems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgitmems.CellEndEdit
        CurIndx = e.ColumnIndex
        If FrmShow_flag(8) = True Then
            If e.ColumnIndex = 0 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Then
                If Trim(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value) = Nothing And IsNumeric(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value) = True Then
                    Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value = FormatNumber(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value, 3)
                End If
            ElseIf e.ColumnIndex = 3 Or e.ColumnIndex = 5 Then
                If Trim(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value) = Nothing And IsNumeric(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value) = True Then
                    Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value = FormatNumber(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value, 2)
                End If
            End If

            If CurIndx = 0 Or CurIndx = 3 Then
                If validate_input() = True Then Exit Sub

                If e.ColumnIndex = 0 Or e.ColumnIndex = 3 Then
                    CalculateValues()
                End If

            End If
            If e.ColumnIndex = 0 Then
                If Trim(Me.Dgitmems.CurrentRow.Cells(1).Value) <> "" Then
                    Dim min As Double = Me.Dgitmems.CurrentRow.Cells(13).Value
                    Dim max As Double = Me.Dgitmems.CurrentRow.Cells(14).Value
                    Dim curval As Double = Me.Dgitmems.CurrentRow.Cells(0).Value
                    Dim Stok As Double = Me.Dgitmems.CurrentRow.Cells(8).Value

                    If (curval + Stok) > max Then
                        Me.Dgitmems.CurrentRow.ErrorText = "Current maximum limit has crossed by:- " & max - (curval + Stok)
                        Me.Dgitmems.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow
                        Me.Dgitmems.CurrentRow.Cells(10).Value = "Max limit crossed"
                    Else
                        Me.Dgitmems.CurrentRow.ErrorText = ""
                        Me.Dgitmems.CurrentRow.DefaultCellStyle.BackColor = Color.White
                        Me.Dgitmems.CurrentRow.Cells(10).Value = "Ok"
                    End If
                End If
            End If
        End If
        If FrmShow_flag(9) = True Then
            If e.ColumnIndex = 0 Then
                If Trim(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value) = Nothing And IsNumeric(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value) = True Then
                    Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value = FormatNumber(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value, 3)
                End If
            ElseIf e.ColumnIndex = 3 Or e.ColumnIndex = 5 Then
                If Trim(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value) = Nothing And IsNumeric(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value) = True Then
                    Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value = FormatNumber(Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).Value, 2)
                End If
            End If

            If CurIndx = 0 Or CurIndx = 3 Then
                If validate_input() = True Then Exit Sub

                If e.ColumnIndex = 0 Or e.ColumnIndex = 3 Then
                    If Me.Dgitmems.CurrentRow.Cells(9).Value <> 1 And e.ColumnIndex = 0 Then
                        'Me.Dgitmems.CurrentRow.Cells(3).Value = 0
                    End If
                    CalculateValues()
                End If

            End If
            If e.ColumnIndex = 0 Then
                If Trim(Me.Dgitmems.CurrentRow.Cells(1).Value) <> "" Then
                    Dim Idno As Integer = Me.Dgitmems.CurrentRow.Cells(7).Value
                    MinMax_Items(Idno)
                    Dim curval As Double = Me.Dgitmems.CurrentRow.Cells(0).Value
                    Dim Stok As Double = SumOf_In_and_Outward_Items(Idno, Idno)
                    Me.lblStok1.Text = FormatNumber(Stok, 3)
                    Me.lblRes.Text = FormatNumber(0, 3)
                    Me.Lblavail.Text = FormatNumber(Stok - 0, 3)
                    Me.lblBaln.Text = FormatNumber(AlRdy_Ordr, 3)
                    Me.Panel5.Visible = True
                    If (curval + Stok + AlRdy_Ordr) > xMax Then
                        Me.Dgitmems.CurrentRow.ErrorText = "Current maximum limit has crossed by:- " & Math.Abs(xMax - (curval + Stok + AlRdy_Ordr))
                        Me.Dgitmems.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow
                    Else
                        Me.Dgitmems.CurrentRow.ErrorText = ""
                        Me.Dgitmems.CurrentRow.DefaultCellStyle.BackColor = Color.White
                    End If
                End If
            End If
        End If




    End Sub

    Private Sub Dgitmems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgitmems.CellEnter
        Try
            If e.ColumnIndex >= 0 Then
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
                If Trim(txtvCode.Text) = "" Or Trim(Txtordrno.Text) = "" Then
                    Me.Dgitmems.ReadOnly = True
                    Me.txtvCode.Focus()
                    Exit Sub
                Else
                    Me.Dgitmems.ReadOnly = False
                End If
            End If
            If e.ColumnIndex = 1 Then
                ''Dim txtb As String

                ''txtb = Trim(Me.Dgitmems.CurrentRow.Cells(8).Value)
                ''GoToItemByVal(Me.lstvewcustlist, txtb)
                Me.Tplitem.Location = New System.Drawing.Point(268, 221)
                Me.Tplitem.Visible = True
                Me.Tplitem.Enabled = True
                'Dim Str1 As String = ""

                If FrmShow_flag(9) = True Then
                    SetCur_Dupli_vali = True
                Else
                    SetCur_Dupli_vali = False
                End If
                Me.Panel5.Visible = False
                Me.Tplitem.Focus()
                If FrmShow_flag(9) = True Then
                    Me.TxtItmcode.Text = Trim(Me.Dgitmems.CurrentRow.Cells(8).Value)
                Else
                    Me.TxtItmcode.Text = Trim(Me.Dgitmems.CurrentRow.Cells(12).Value)
                End If

                Me.TxtItmcode.Focus()

            End If
            If FrmShow_flag(8) = True Then
                If e.ColumnIndex = 1 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Or e.ColumnIndex = 10 Or e.ColumnIndex = 11 Or e.ColumnIndex = 12 Or e.ColumnIndex = 13 Or e.ColumnIndex = 14 Then
                    Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).ReadOnly = True
                End If
            End If
            If FrmShow_flag(9) = True Then
                If e.ColumnIndex = 1 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Or e.ColumnIndex = 10 Or e.ColumnIndex = 11 Or e.ColumnIndex = 12 Or e.ColumnIndex = 13 Or e.ColumnIndex = 14 Then
                    Me.Dgitmems.CurrentRow.Cells(e.ColumnIndex).ReadOnly = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Function validate_input() As Boolean
        Try
            If Not (Me.Dgitmems.CurrentRow.Cells(CurIndx).Value) >= 0 Then
                Me.Dgitmems.CurrentRow.Cells(CurIndx).ErrorText = "Empty not allowed"
                Return True
            Else
                Me.Dgitmems.CurrentRow.Cells(CurIndx).ErrorText = ""
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Function
    Private Function Chk_Error() As Boolean
        Try
            If Len(Me.txtvCode.Text.Trim) = 0 Or Len(Me.TxtVname.Text.Trim) = 0 Then
                Return True
            End If
            Dim Err As Integer = 0
            For Err = 0 To Me.Dgitmems.Rows.Count - 1
                If Trim(Me.Dgitmems.Rows(Err).ErrorText) <> "" Or Len(Trim(Me.Dgitmems.Rows(Err).Cells(0).Value)) = 0 Then
                    Return True
                End If
            Next
        Catch ex As Exception

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

    Private Sub Dgitmems_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles Dgitmems.CellValidating
        Try
            Dim Cr_Row As Integer = Me.Dgitmems.Rows.Count '- 1
            If Cr_Row <> Me.Dgitmems.CurrentRow.Index Then
                If e.ColumnIndex = 0 Or e.ColumnIndex = 3 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.Dgitmems.CurrentCell.ErrorText = "Only Number are allowed"
                        ' Me.Dgitmems.CurrentRow.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        Me.Dgitmems.CurrentCell.ErrorText = ""
                        ' Me.Dgitmems.CurrentRow.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Function CleanInputAlphabet(ByVal str As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(str, "[0-9\b\s-]", "")
    End Function

    Private Function CleanInputNumber(ByVal str As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(str, "[a-zA-Z\b\s-.]", "")
    End Function

    Private Sub TxtItmcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItmcode.GotFocus
        Try
            TxtCond1 = 1 'set filter as Itme code
            Me.Dgitmems.CurrentRow.Cells(1).Selected = False
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

    Private Sub TxtItmname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtItmcode.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False

                If Me.Dgitmems.CurrentRow.Cells(1).Value <> "" Then
                    Me.Dgitmems.CurrentCell = Me.Dgitmems.Item(3, Me.Dgitmems.CurrentRow.Index)
                Else
                    Me.Dgitmems.CurrentCell = Me.Dgitmems.Item(0, Me.Dgitmems.CurrentRow.Index)
                End If
                Me.Dgitmems.Focus()
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
        If FrmShow_flag(8) = True Then
            Try
                If LstIndx >= 0 Then
                    Me.Dgitmems.CurrentRow.Cells(1).Value = Trim(LstVewItem.Items(LstIndx).SubItems(1).Text)
                    SetCur_Dupli_vali = False

                    Dim CurItemId As Integer = Trim(LstVewItem.Items(LstIndx).SubItems(2).Text)
                    Dim xSiH1 As Double = SumOf_In_and_Outward_Items(CurItemId, CurItemId)
                    Me.Dgitmems.CurrentRow.Cells(6).Value = FormatNumber(xSiH1, 3)
                    Me.Dgitmems.CurrentRow.Cells(7).Value = FormatNumber(xCheck_StokInDemand_ParticularItem(CurItemId), 3)
                    Me.Dgitmems.CurrentRow.Cells(8).Value = FormatNumber(xSiH1 - Me.Dgitmems.CurrentRow.Cells(7).Value, 3)
                    Me.Dgitmems.CurrentRow.Cells(9).Value = FormatNumber(AlRdy_Ordr, 3)
                    Me.Dgitmems.CurrentRow.Cells(4).Value = Trim(LstVewItem.Items(LstIndx).SubItems(7).Text)
                    Dim Min As Double = LstVewItem.Items(LstIndx).SubItems(4).Text
                    Dim Max As Double = LstVewItem.Items(LstIndx).SubItems(5).Text
                    Dim Lmt As Double = (Me.Dgitmems.CurrentRow.Cells(8).Value + AlRdy_Ordr)

                    If (Me.Dgitmems.CurrentRow.Cells(0).Value + Lmt) > Max Then
                        Me.Dgitmems.CurrentRow.ErrorText = "Current maximum limit has crossed by:- " & Max - (Me.Dgitmems.CurrentRow.Cells(0).Value + Lmt)
                        Me.Dgitmems.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow
                        Me.Dgitmems.CurrentRow.Cells(10).Value = "Max limit crossed"
                    Else
                        Me.Dgitmems.CurrentRow.ErrorText = ""
                        Me.Dgitmems.CurrentRow.DefaultCellStyle.BackColor = Color.White
                        Me.Dgitmems.CurrentRow.Cells(10).Value = "Ok"
                    End If


                    Me.Dgitmems.CurrentRow.Cells(11).Value = Trim(LstVewItem.Items(LstIndx).SubItems(2).Text)
                    Me.Dgitmems.CurrentRow.Cells(12).Value = Trim(LstVewItem.Items(LstIndx).Text)
                    Me.Dgitmems.CurrentRow.Cells(13).Value = FormatNumber(Min, 3)
                    Me.Dgitmems.CurrentRow.Cells(14).Value = FormatNumber(Max, 3)
                    Me.Tplitem.Location = New System.Drawing.Point(837, 243)
                    Me.Tplitem.Visible = False
                    Me.Tplitem.Enabled = False
                    Me.TxtItmcode.Text = ""
                    Me.Dgitmems.CurrentCell = Me.Dgitmems.Item(3, Me.Dgitmems.CurrentRow.Index)
                    Me.Dgitmems.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try
        End If

        If FrmShow_flag(9) = True Then
            Try
                If LstIndx >= 0 Then
                    SetCur_Dupli_vali = False
                    Me.Dgitmems.CurrentRow.Cells(1).Value = Trim(LstVewItem.Items(LstIndx).SubItems(1).Text)

                    Dim CurItemId As Integer = Trim(LstVewItem.Items(LstIndx).SubItems(2).Text)
                    Dim xSiH1 As Double = SumOf_In_and_Outward_Items(CurItemId, CurItemId)

                    Me.Dgitmems.CurrentRow.Cells(9).Value = xSiH1

                    Me.Dgitmems.CurrentRow.Cells(4).Value = Trim(LstVewItem.Items(LstIndx).SubItems(7).Text)
                    Me.Dgitmems.CurrentRow.Cells(7).Value = Trim(LstVewItem.Items(LstIndx).SubItems(2).Text)
                    Dim IcodeStr As String = Trim(LstVewItem.Items(LstIndx).Text)
                    Me.Dgitmems.CurrentRow.Cells(8).Value = IcodeStr.ToString

                    Dim Min As Double = LstVewItem.Items(LstIndx).SubItems(4).Text
                    Dim Max As Double = LstVewItem.Items(LstIndx).SubItems(5).Text
                    Me.lblStok1.Text = FormatNumber(xSiH1, 3)
                    Me.lblRes.Text = FormatNumber(0, 3)
                    Me.Lblavail.Text = FormatNumber(xSiH1 - 0, 3)
                    Me.lblBaln.Text = FormatNumber(AlRdy_Ordr, 3)
                    Me.Panel5.Visible = True
                    Dim Lmt As Double = (xSiH1 + AlRdy_Ordr)
                    If (Me.Dgitmems.CurrentRow.Cells(0).Value + Lmt) > Max Then
                        Me.Dgitmems.CurrentRow.ErrorText = "Current maximum limit has crossed by:- " & Math.Abs(Max - (Me.Dgitmems.CurrentRow.Cells(0).Value + Lmt))
                        Me.Dgitmems.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow

                    Else
                        Me.Dgitmems.CurrentRow.ErrorText = ""
                        Me.Dgitmems.CurrentRow.DefaultCellStyle.BackColor = Color.White

                    End If
                    Me.Tplitem.Location = New System.Drawing.Point(837, 243)
                    Me.Tplitem.Visible = False
                    Me.Tplitem.Enabled = False
                    Me.Dgitmems.CurrentCell = Me.Dgitmems.Item(3, Me.Dgitmems.CurrentRow.Index)
                    Me.Dgitmems.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try
        End If


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

    Private Sub CalculateValues()
        Try
            If FrmShow_flag(8) = True Then
                If Trim(Me.Dgitmems.CurrentRow.Cells(0).Value) <> Nothing Then
                    ValQnty = Me.Dgitmems.CurrentRow.Cells(0).Value
                Else
                    ValQnty = 0
                End If
                If Trim(Me.Dgitmems.CurrentRow.Cells(3).Value) <> Nothing Then
                    ValRate = Me.Dgitmems.CurrentRow.Cells(3).Value
                Else
                    ValRate = 0
                End If
                ValAmt = ValRate * ValQnty

                Me.Dgitmems.CurrentRow.Cells(5).Value = FormatNumber(ValAmt, 2)
            End If
            If FrmShow_flag(9) = True Then
                If Trim(Me.Dgitmems.CurrentRow.Cells(0).Value) <> Nothing Then
                    ValQnty = Me.Dgitmems.CurrentRow.Cells(0).Value
                Else
                    ValQnty = 0
                End If

                If Trim(Me.Dgitmems.CurrentRow.Cells(3).Value) <> Nothing Then
                    ValRate = Me.Dgitmems.CurrentRow.Cells(3).Value
                Else
                    ValRate = 0
                End If
                ValAmt = ValRate * ValQnty
                Dim amt1 As Double = FormatNumber(ValAmt, 2)
                Me.Dgitmems.CurrentRow.Cells(5).Value = amt1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function validate_input_Duplicate() As Boolean
        Dim i, j As Integer
        If FrmShow_flag(8) = True Then
            For i = 0 To Me.Dgitmems.Rows.Count - 1
                For j = i + 1 To Me.Dgitmems.Rows.Count - 1
                    If Trim(Me.Dgitmems.Rows(i).Cells(1).Value) <> Nothing Then
                        If Trim(Me.Dgitmems.Rows(i).Cells(1).Value) = Trim(Me.Dgitmems.Rows(j).Cells(1).Value) Then ' And Me.Dgitmems.Rows(i).Cells(2).Value = Me.Dgitmems.Rows(j).Cells(2).Value Then
                            Return True
                        End If
                    End If
                Next
            Next
            Return False
        End If
        If FrmShow_flag(9) = True Then
            For i = 0 To Me.Dgitmems.Rows.Count - 1
                For j = i + 1 To Me.Dgitmems.Rows.Count - 1
                    If Trim(Me.Dgitmems.Rows(i).Cells(1).Value) <> Nothing Then
                        If Trim(Me.Dgitmems.Rows(i).Cells(1).Value) = Trim(Me.Dgitmems.Rows(j).Cells(1).Value) Then ' And Me.Dgitmems.Rows(i).Cells(2).Value = Me.Dgitmems.Rows(j).Cells(2).Value Then
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
            TpoRdr1 = TpoCmd1.ExecuteReader
            While TpoRdr1.Read
                If TpoRdr1.IsDBNull(1) = False Then
                    AlRdy_Ordr = TpoRdr1(1)
                Else
                    AlRdy_Ordr = 0
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
    Private Sub MinMax_Items(ByVal mmItemId As Integer)
        Try
            TpoCmd1 = New SqlCommand("Finact_Min_Max_Particularitem", FinActConn2)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@mmItemid", mmItemId)
            TpoRdr1 = TpoCmd1.ExecuteReader
            While TpoRdr1.Read
                If TpoRdr1.IsDBNull(0) = False Then
                    xMin = TpoRdr1(0)
                    xMax = TpoRdr1(1)
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd1.Dispose()
            TpoRdr1.Close()
        End Try
    End Sub
    Private Sub Dgitmems_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgitmems.CellLeave
        If e.ColumnIndex = 1 Then
            If SetCur_Dupli_vali = False Then
                If validate_input_Duplicate() = True Then
                    Me.Dgitmems.CurrentRow.Cells(1).ErrorText = ("Invalid Input! Current item already existed")
                Else
                    Me.Dgitmems.CurrentRow.Cells(1).ErrorText = ("")
                End If
            End If
        End If

        If FrmShow_flag(9) = True Then
            If e.ColumnIndex = 0 Then
                Dim a As Integer = Me.Dgitmems.CurrentRow.Cells(10).Value
                If a <> 1 And a <> 2 Then
                    Me.Dgitmems.CurrentRow.Cells(10).Value = 3
                End If
            End If

            If e.ColumnIndex = 1 Then
                If Me.Dgitmems.CurrentRow.Cells(10).Value <> 1 Then
                    Me.Dgitmems.CurrentRow.Cells(10).Value = 2
                End If
            End If

        End If

    End Sub

    Private Sub BtnO_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnO_exit.Click
        Me.Close()
    End Sub

    Private Sub BtnO_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnO_Save.Click
        Try

            'If FrmShow_flag(8) = True Then
            '    xLes = 2
            'Else
            If FrmShow_flag(9) = True Then
                xLes = Me.Dgitmems.Rows.Count - 1
            End If
            Dim Nix As Integer
            Dim AllowSave As Boolean = True
            For Nix = 0 To xLes - 1
                If FrmShow_flag(8) = True Then
                    If Me.Dgitmems.Rows(Nix).Cells(11).Value = "" Then ''Exit For
                        MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                        Exit Sub
                    End If
                End If
                If Me.Dgitmems.Rows(Nix).Cells(0).Value <= 0 Then
                    Me.Dgitmems.Rows(Nix).Cells(0).ErrorText = "Quantity Should be Greater than Zero"
                    AllowSave = False
                    Exit Sub
                Else
                    Me.Dgitmems.Rows(Nix).Cells(0).ErrorText = ""
                    AllowSave = True
                End If
                If Trim(Me.Dgitmems.Rows(Nix).Cells(1).Value) = "" Then
                    Me.Dgitmems.Rows(Nix).Cells(1).ErrorText = "Item Name Required"
                    AllowSave = False
                Else
                    Me.Dgitmems.Rows(Nix).Cells(1).ErrorText = ""
                    AllowSave = True
                End If
                If Trim(Me.Dgitmems.Rows(Nix).Cells(0).ErrorText) <> "" Or Trim(Me.Dgitmems.Rows(Nix).Cells(1).ErrorText) <> "" Then
                    MsgBox("Invalid input! Check alert message", MsgBoxStyle.Critical, "Duplicate/Zero Value record found")
                    Exit Sub
                End If
            Next

            If FrmShow_flag(9) = True Then
                If MessageBox.Show("Are you sure to update", "Purchase Order updating", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                    BtnO_Save.Focus()
                    Return
                Else
                    If Chk_Error() = True Then
                        MsgBox("System could not save current record(s). Check alert message!!", MsgBoxStyle.Critical, "Check Alert!!!")
                        Exit Sub
                    Else
                        Porder_Update()
                        Exit Sub
                    End If

                End If

            End If

            If AllowSave = True Then
                If MessageBox.Show("Are you sure to save", "Purchase Order Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                    BtnO_Save.Focus()
                    Return
                Else
                    If Chk_Error() = True Then
                        MsgBox("System could not save current record(s). Check alert message!!", MsgBoxStyle.Critical, "Check Alert!!!")
                        Exit Sub
                    Else
                        PurordrSave()
                    End If

                End If
            Else
                Me.Dgitmems.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally


        End Try

    End Sub

    Private Sub PurordrSave()
        If Me.Dgitmems.Rows.Count > 0 Then
            Try
                If ConnectionState.Closed Then FinActConn.Open()
                TpoCmd = New SqlCommand("Finact_PurOrdr_Insert", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@purorddt", (dtpordrdt.Value.Date))
                TpoCmd.Parameters.AddWithValue("@purordno", Trim(Txtordrno.Text))
                TpoCmd.Parameters.AddWithValue("@purcat", Trim("Purduction"))
                TpoCmd.Parameters.AddWithValue("@pursplrid", Trim(SplrId))
                TpoCmd.Parameters.AddWithValue("@purrmrk", Trim(Txtcoment.Text))
                TpoCmd.Parameters.AddWithValue("@purordrdis", 0)
                TpoCmd.Parameters.AddWithValue("@purshpid", Me.CmbxCarri.SelectedValue)
                TpoCmd.Parameters.AddWithValue("@purfrtstatus", Trim(CmbxFret.Text))
                TpoCmd.Parameters.AddWithValue("@purstatus", Trim(Cmbxstatus.Text))
                TpoCmd.Parameters.AddWithValue("@purdelvrydt", (Dtpreqstdt.Value.Date))
                TpoCmd.Parameters.AddWithValue("@puramt", Me.lblamt.Text)
                TpoCmd.Parameters.AddWithValue("@purlocid", Me.CmbxWareh.SelectedValue)
                TpoCmd.Parameters.AddWithValue("@puradusrid", Current_UsrId)
                TpoCmd.Parameters.AddWithValue("@puraddt", Now)
                TpoCmd.Parameters.AddWithValue("@purdelstatus", 1)
                TpoCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            Finally
                TpoCmd.Dispose()
            End Try

            Dim CurrOrderId As Integer = FindlastId(Trim(Txtordrno.Text), Trim(SplrId))
            Try
                For Each DgCntr As DataGridViewRow In Me.Dgitmems.Rows
                    If FrmShow_flag(8) = True And DgCntr.Cells(11).Value = "" Then Exit For
                    TpoCmd = New SqlCommand("Finact_PurOrdr_Details_Insert", FinActConn)
                    TpoCmd.CommandType = CommandType.StoredProcedure
                    TpoCmd.Parameters.AddWithValue("@dpurconcrnid", Trim(CurrOrderId))
                    TpoCmd.Parameters.AddWithValue("@dpuritmid", CInt(DgCntr.Cells(11).Value))
                    TpoCmd.Parameters.AddWithValue("@dpurordqnty", CDbl(DgCntr.Cells(0).Value))
                    TpoCmd.Parameters.AddWithValue("@dpurrecdqnty", 0)
                    TpoCmd.Parameters.AddWithValue("@dpurrecdstatus", "Yet_Recd")
                    TpoCmd.Parameters.AddWithValue("@dpurqntyrecddt", Now)
                    TpoCmd.Parameters.AddWithValue("@dpuritmcode", Trim(DgCntr.Cells(12).Value))
                    TpoCmd.Parameters.AddWithValue("@dpuritmdiscr", Trim(DgCntr.Cells(2).Value))
                    TpoCmd.Parameters.AddWithValue("@dpuritmrate", CDbl(DgCntr.Cells(3).Value))
                    TpoCmd.ExecuteNonQuery()
                Next
                MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                Clrear_Values()
                Me.Dgitmems.Rows.Add()
                Me.Txtordrno.Focus()
                Me.Txtordrno.SelectAll()
            Catch ex As Exception
                MsgBox(ex.Message)
                Try
                    TpoCmd1 = New SqlCommand("Delete from finactpurorder where purid=@id", FinActConn1)
                    TpoCmd1.Parameters.AddWithValue("@id", CurrOrderId)
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
            Me.Dgitmems.Focus()

        End If

    End Sub
    Private Function FindlastId(ByVal P_Order As String, ByVal Splr_id As Integer) As Integer
        Try

            TpoCmd1 = New SqlCommand("select purid from finactpurorder where purordno=@Ono and pursplrid=@sid", FinActConn1)
            TpoCmd1.Parameters.AddWithValue("@Ono", Trim(P_Order))
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
            TpoCmd1 = New SqlCommand("select max(purid) from finactpurorder ", FinActConn1)
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
    Private Function Curr_Maxdate(ByVal Mxid As Integer) As Date
        Try
            Dim Curr_MaxPurdt As Date
            TpoCmd1 = New SqlCommand("select max(purorddt) from finactpurorder where purid=@mxid and purdelstatus=1", FinActConn1)
            TpoCmd1.Parameters.AddWithValue("@mxid", Mxid)
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.HasRows = True Then
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

    Private Sub Clrear_Values()
        Me.Txtordrno.Text = ""
        Me.txtvCode.Text = ""
        Me.TxtVname.Text = ""
        Me.lblamt.Text = ""
        Me.Txtcoment.Text = ""
        Me.Dgitmems.Rows.Clear()
    End Sub


    Private Sub Txtordrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtordrno.GotFocus
        If MaxSplid > 0 Then
            Me.Txtordrno.Text = (MaxSplid + 1)
        End If

    End Sub

    Private Sub Dgitmems_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgitmems.CellValueChanged
        If e.ColumnIndex = 5 Then
            Dim Rw As Integer
            Dim Rt As Double = 0
            Me.lblamt.Text = ""
            For Rw = 0 To Me.Dgitmems.Rows.Count - 1
                Rt += Me.Dgitmems.Rows(Rw).Cells(5).Value
            Next
            Me.lblamt.Text = FormatNumber(Rt, 2)
        End If
    End Sub

    Private Sub Dgitmems_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles Dgitmems.RowsRemoved
        Try
            Dim Rw As Integer
            Dim Rt As Double = 0
            Me.lblamt.Text = ""
            For Rw = 0 To Me.Dgitmems.Rows.Count - 1
                Rt += Me.Dgitmems.Rows(Rw).Cells(5).Value
            Next
            Me.lblamt.Text = FormatNumber(Rt, 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub CreateGridColumns()
        Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
        Dim CurrDate As Date
        Try
            TpoCmd1 = New SqlCommand("Finact_PurOrder_Select_Where_id", FinActConn1)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@orderid", Selected_xOrdr_xId)
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.HasRows = True Then
                Me.Txtordrno.Text = Trim(TpoRdr1("purordno"))
                If TpoRdr1.IsDBNull(12) = True Then
                    Me.lblamt.Text = FormatNumber(0, 2)
                Else
                    Me.lblamt.Text = FormatNumber(TpoRdr1("puramt"), 2)
                End If
                Date.TryParse(TpoRdr1("Purorddt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.dtpordrdt.MinDate = CurrDate
                Me.dtpordrdt.Value = CurrDate
                Me.Cmbxstatus.Text = Trim(TpoRdr1("purstatus"))
                Date.TryParse(TpoRdr1("Purdelvrydt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.Dtpreqstdt.Value = CurrDate
                SplrId = Trim(TpoRdr1("pursplrid"))
                Me.txtvCode.Text = Trim(TpoRdr1("Splr_code"))
                Me.TxtVname.Text = Trim(TpoRdr1("splr_name"))
                Me.CmbxWareh.SelectedValue = TpoRdr1("purlocid")
                Me.CmbxCarri.SelectedValue = TpoRdr1("purshpid")
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
            Me.dtpordrdt.Enabled = False
            Me.Txtordrno.Enabled = False
        End Try
        Try
            Dim DgItms As DataGridView
            DgItms = Me.Dgitmems
            DgItms.Columns.Clear()

            TpoCmd1 = New SqlCommand("Finact_PurOrder_Details_Where_Concrnid", FinActConn1)
            TpoCmd1.CommandType = CommandType.StoredProcedure
            TpoCmd1.Parameters.AddWithValue("@PordConcrnid", Selected_xOrdr_xId)

            TpoAdptr = New Data.SqlClient.SqlDataAdapter(TpoCmd1)
            dtaset = New Data.DataSet()
            TpoAdptr.Fill(dtaset, "finactpurorder_details")
            DgItms.DataSource = dtaset.Tables("finactpurorder_details")

            ' DgItms.Columns.Add("ColQnty", "Quantity")

            DgItms.Columns(0).HeaderText = "Quantity"
            DgItms.Columns(0).Name = "ColQnty"
            Dim dt As DataGridViewTextBoxColumn = TryCast(DgItms.Columns(0), DataGridViewTextBoxColumn)
            dt.MaxInputLength = 10
            DgItms.Columns(0).Width = 100
            DgItms.Columns(0).DefaultCellStyle.Format = "N3"
            DgItms.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(0).DefaultCellStyle.NullValue = Nothing


            'DgItms.Columns.Add("ColItemid", "Item Name")
            DgItms.Columns(1).HeaderText = "Item Name"
            DgItms.Columns(1).Name = "ColItemid"
            DgItms.Columns(1).Width = 290
            DgItms.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            'DgItms.Columns.Add("ColDiscription", "Discription")
            DgItms.Columns(2).HeaderText = "Discription"
            DgItms.Columns(2).Name = "ColDiscription"
            DgItms.Columns(2).Width = 0
            DgItms.Columns(2).Visible = False

            ' DgItms.Columns.Add("colCost", "Rate")
            DgItms.Columns(3).HeaderText = "Rate"
            DgItms.Columns(3).Name = "colCost"
            DgItms.Columns(3).Width = 125
            DgItms.Columns(3).DefaultCellStyle.Format = "N2"
            DgItms.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(3).DefaultCellStyle.NullValue = Nothing

            'DgItms.Columns.Add("ColUnittype", "Unit Type")
            DgItms.Columns(4).HeaderText = "Unit Type"
            DgItms.Columns(4).Name = "ColUnittype"
            DgItms.Columns(4).Width = 75
            DgItms.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ' DgItms.Columns.Add("colAmt", "Amount")
            DgItms.Columns(5).HeaderText = "Amount"
            DgItms.Columns(5).Name = "colAmt"
            DgItms.Columns(5).Width = 175
            DgItms.Columns(5).DefaultCellStyle.Format = "N2"
            DgItms.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'DgItms.Columns.Add("ColITmId", "Item id")
            DgItms.Columns(6).HeaderText = "Item id"
            DgItms.Columns(6).Name = "ColITmId"
            DgItms.Columns(6).Width = 0
            DgItms.Columns(6).Visible = False

            'DgItms.Columns.Add("CoICode", "Item Code")
            DgItms.Columns(7).HeaderText = "Item Code"
            DgItms.Columns(7).Name = "CoICode"
            DgItms.Columns(7).DefaultCellStyle.Format.ToString()
            DgItms.Columns(7).Width = 0
            DgItms.Columns(7).Visible = False


            ' DgItms.Columns.Add("ColStatus", "itemcode")
            DgItms.Columns(8).HeaderText = "Item Code"
            DgItms.Columns(8).Name = "ColStatus"
            DgItms.Columns(8).Width = 0
            DgItms.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DgItms.Columns(8).Visible = False

            DgItms.Columns.Add("ColInStok", "Sotck In Hand")
            DgItms.Columns(9).Width = 100
            DgItms.Columns(9).DefaultCellStyle.Format = "N3"
            DgItms.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(9).DefaultCellStyle.NullValue = Nothing
            'DgItms.Columns(9).DisplayIndex = 5
            ' DgItms.Columns(9).Visible = False

            DgItms.Columns.Add("ColresStok", "Edit Flag")
            'DgItms.Columns(10).HeaderText = "Edit Flag"
            'DgItms.Columns(10).Name = "ColresStok"
            DgItms.Columns(10).Width = 0
            'DgItms.Columns(10).DefaultCellStyle.Format = "No"
            DgItms.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DgItms.Columns(10).DefaultCellStyle.NullValue = Nothing
            Dim rc As Integer = 0
            For rc = 0 To Me.Dgitmems.Rows.Count - 1
                Me.Dgitmems.Rows(rc).Cells(10).Value = 1 '1 is  satand for already existed record.
            Next
            DgItms.Columns(10).Visible = False
            DgItms.MultiSelect = False
            DgItms.AllowUserToDeleteRows = False
            DgItms.AllowUserToAddRows = False

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd1.Dispose()
            TpoAdptr.Dispose()

        End Try



    End Sub

    Private Sub Porder_Update()
        If Me.Dgitmems.Rows.Count > 0 Then
            Try
                TpoCmd = New SqlCommand("finact_purordr_update", FinActConn)
                TpoCmd.CommandType = CommandType.StoredProcedure
                TpoCmd.Parameters.AddWithValue("@purid", Selected_xOrdr_xId)
                TpoCmd.Parameters.AddWithValue("@pursplrid", Trim(SplrId))
                TpoCmd.Parameters.AddWithValue("@purrmrk", Trim(Txtcoment.Text))
                TpoCmd.Parameters.AddWithValue("@purshpid", Me.CmbxCarri.SelectedValue)
                TpoCmd.Parameters.AddWithValue("@purfrtstatus", Trim(CmbxFret.Text))
                TpoCmd.Parameters.AddWithValue("@purstatus", Trim(Cmbxstatus.Text))
                TpoCmd.Parameters.AddWithValue("@purdelvrydt", (Dtpreqstdt.Value.Date))
                TpoCmd.Parameters.AddWithValue("@puramt", Me.lblamt.Text)
                TpoCmd.Parameters.AddWithValue("@purlocid", Me.CmbxWareh.SelectedValue)
                TpoCmd.Parameters.AddWithValue("@puredtusrid", Current_UsrId)
                TpoCmd.Parameters.AddWithValue("@puredtdt", Now)
                TpoCmd.ExecuteNonQuery()
            Catch ex As Exception

                MsgBox(ex.Message)

                Exit Sub
            Finally
                TpoCmd.Dispose()
            End Try

            Try
                Dim DgCntr As Integer
                For DgCntr = 0 To xLes '- 1
                    If Me.Dgitmems.Rows(DgCntr).Cells(10).Value = 1 Then
                        Try
                            Dim Cr_Itemid As Integer = Me.Dgitmems.Rows(DgCntr).Cells(6).Value
                            TpoCmd = New SqlCommand("Finact_PurOrdr_Details_update", FinActConn)
                            TpoCmd.CommandType = CommandType.StoredProcedure
                            TpoCmd.Parameters.AddWithValue("@dpurid", Cr_Itemid)
                            TpoCmd.Parameters.AddWithValue("@dpurconcrnid", Trim(Selected_xOrdr_xId))
                            TpoCmd.Parameters.AddWithValue("@dpuritmid", Trim(Me.Dgitmems.Rows(DgCntr).Cells(7).Value))
                            TpoCmd.Parameters.AddWithValue("@dpurordqnty", Trim(Me.Dgitmems.Rows(DgCntr).Cells(0).Value))
                            TpoCmd.Parameters.AddWithValue("@dpuritmcode", Trim(Me.Dgitmems.Rows(DgCntr).Cells(8).Value))
                            TpoCmd.Parameters.AddWithValue("@dpuritmdiscr", Trim(Me.Dgitmems.Rows(DgCntr).Cells(2).Value))
                            TpoCmd.Parameters.AddWithValue("@dpuritmrate", Trim(Me.Dgitmems.Rows(DgCntr).Cells(3).Value))
                            TpoCmd.ExecuteNonQuery()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            TpoCmd.Dispose()
                        End Try
                    ElseIf Me.Dgitmems.Rows(DgCntr).Cells(10).Value = 2 Then
                        TpoCmd = New SqlCommand("Finact_PurOrdr_Details_Insert", FinActConn)
                        TpoCmd.CommandType = CommandType.StoredProcedure
                        TpoCmd.Parameters.AddWithValue("@dpurconcrnid", Trim(Selected_xOrdr_xId))
                        TpoCmd.Parameters.AddWithValue("@dpuritmid", Trim(Me.Dgitmems.Rows(DgCntr).Cells(7).Value))
                        TpoCmd.Parameters.AddWithValue("@dpurordqnty", Trim(Me.Dgitmems.Rows(DgCntr).Cells(0).Value))
                        TpoCmd.Parameters.AddWithValue("@dpurrecdqnty", 0)
                        TpoCmd.Parameters.AddWithValue("@dpurrecdstatus", "Yet_Recd")
                        TpoCmd.Parameters.AddWithValue("@dpurqntyrecddt", Now)
                        TpoCmd.Parameters.AddWithValue("@dpuritmcode", Trim(Me.Dgitmems.Rows(DgCntr).Cells(8).Value))
                        TpoCmd.Parameters.AddWithValue("@dpuritmdiscr", "Nothing") 'Trim(Me.Dgitmems.Rows(DgCntr).Cells(2).Value))
                        TpoCmd.Parameters.AddWithValue("@dpuritmrate", Trim(Me.Dgitmems.Rows(DgCntr).Cells(3).Value))
                        TpoCmd.ExecuteNonQuery()
                    End If
                Next
                MsgBox("Record has been Updated Successfully", MsgBoxStyle.Information, "Update Record")
                Me.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                TpoCmd.Dispose()
            End Try
        Else
            MsgBox("Invalid action! System could not found any record to save", MsgBoxStyle.Critical, "Empty Table")
            Me.Dgitmems.Focus()

        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If FrmShow_flag(9) = False Then
                If Me.Dgitmems.CurrentRow.Cells(10).Value = "Max limit crossed" Or Me.Dgitmems.CurrentRow.Cells(10).Value = "Ok" Or Me.Dgitmems.CurrentRow.Cells(10).Value = "" Then
                    Dim LastRow As Integer = Me.Dgitmems.Rows.Count '- 1
                    If MessageBox.Show("Are you sure to delete this row", "Deleting row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Dgitmems.Rows.Remove(Me.Dgitmems.CurrentRow)
                        xLes -= 1
                        Exit Sub
                    Else
                        Return
                    End If
                End If
            Else
                If Me.Dgitmems.Rows.Count = 1 Then
                    MsgBox("Invalid Input!, At least one row should be there, you can't delete it.", MsgBoxStyle.Critical, Me.Text)
                    Exit Sub
                End If
                If Chk_Del_Xstatus(Me.Dgitmems.SelectedRows(0).Cells(6).Value) = False Then
                    MsgBox("Invalid Input!,Current item has been partly or fully received.", MsgBoxStyle.Critical, Me.Text)
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure to delete this row", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    For Each rx As DataGridViewRow In Me.Dgitmems.SelectedRows
                        Try
                            TpoCmd = New SqlCommand("delete from FinactPurOrder_Details where dpurid=@purid1 and dpurrecdqnty=0 and dpurrecdstatus='Yet_Recd'", FinActConn)
                            TpoCmd.Parameters.AddWithValue("@purid1", Me.Dgitmems.SelectedRows(0).Cells(6).Value)
                            TpoCmd.ExecuteNonQuery()
                            Me.Dgitmems.Rows.Remove(Me.Dgitmems.CurrentRow)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            TpoCmd.Dispose()
                        End Try
                    Next
                Else
                    Return
                End If
            End If
        Catch ex As Exception

        End Try



    End Sub
    Private Function Chk_Del_Xstatus(ByVal xp_Id As Integer) As Boolean
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            TpoCmd = New SqlCommand("Finact_PurOrder_Details_checkDelStatus", FinActConn)
            TpoCmd.CommandType = CommandType.StoredProcedure
            TpoCmd.Parameters.AddWithValue("@Xp_Id", xp_Id)
            TpoRdr = TpoCmd.ExecuteReader
            While TpoRdr.Read
                If TpoRdr(0) = "Yes" Then
                    Return True
                Else
                    Return False
                End If
            End While
           
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            TpoCmd.Dispose()
            TpoRdr.Close()
        End Try
    End Function

    Private Sub Dgitmems_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgitmems.RowHeaderMouseClick

        Try
            If Me.Dgitmems.Rows.Count > 1 Then
                ''If (Me.Dgitmems.CurrentRow.Cells(0).Value) = "" And (Me.Dgitmems.CurrentRow.Cells(1).Value) = "" Then
                ''    Me.Dgitmems.CurrentRow.Selected = False
                ''    Exit Sub
                ''End If
                If Me.Tplitem.Visible = True Then
                    Me.Dgitmems.CurrentRow.Selected = False
                    Exit Sub
                End If
                If Me.Dgitmems.SelectedRows.Count = 1 Then
                    Me.DeleteToolStripMenuItem.Enabled = True
                End If
            Else
                Me.DeleteToolStripMenuItem.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgitmems_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgitmems.RowHeaderMouseDoubleClick
        Dgitmems_RowHeaderMouseClick(sender, e)
    End Sub


    Private Sub Dgitmems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgitmems.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If Me.Dgitmems.CurrentCell.ColumnIndex = 4 Then ' Me.Dgitmems.ColumnCount = 3 Then
                    If Trim(Me.Dgitmems.CurrentRow.Cells(0).Value) <> Nothing And Trim(Me.Dgitmems.CurrentRow.Cells(1).Value) <> Nothing And Trim(Me.Dgitmems.CurrentRow.Cells(3).Value) <> Nothing Then
                        Dim Val1 As Double
                        Dim ic As String
                        ic = Me.Dgitmems.CurrentRow.Cells(1).Value

                        Val1 = Me.Dgitmems.CurrentRow.Cells(0).Value

                        If Not (Val1) > 0 Then
                            Me.Dgitmems.CurrentRow.Cells(0).ErrorText = "Value should be greater than zero"
                        Else
                            Me.Dgitmems.CurrentRow.Cells(0).ErrorText = ""
                            If MessageBox.Show("Do you want to add more items?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                If Me.Dgitmems.CurrentRow.Index = Me.Dgitmems.Rows.Count - 1 Then
                                    Me.Dgitmems.Rows.Add()
                                    xLes += 1
                                End If
                            Else
                                Me.BtnO_Save.Focus()
                            End If

                        End If
                    End If

                    If Me.Dgitmems.CurrentCell.RowIndex < Me.Dgitmems.RowCount - 1 Then
                        Me.Dgitmems.CurrentCell = Me.Dgitmems.Item(0, Me.Dgitmems.CurrentCell.RowIndex + 1)
                        If Not Me.Dgitmems.CurrentCell.Value > 0 Then
                            Me.Dgitmems.CurrentCell.Value = 0
                        End If
                    End If
                Else
                    Me.Dgitmems.CurrentCell = Me.Dgitmems.Item(Me.Dgitmems.CurrentCell.ColumnIndex + 1, Me.Dgitmems.CurrentCell.RowIndex)
                End If
            End If
            e.Handled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgitmems_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Dgitmems.EditingControlShowing
        Try

            If TypeOf e.Control Is TextBox Then
                Dim tb As TextBox = e.Control
                tb.AcceptsTab = True
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Function xCheck_StokInDemand_ParticularItem(ByVal CurrItemId As Integer) As Double
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            TpoCmd = New SqlCommand("finact_Chek_StockInDemand_OfItemDependency_Select", FinActConn2)
            TpoCmd.CommandType = CommandType.StoredProcedure
            TpoCmd.Parameters.AddWithValue("@CurrItemId", CurrItemId)

            TpoRdr = TpoCmd.ExecuteReader
            While TpoRdr.Read
                If TpoRdr.IsDBNull(0) = False Then
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

    Private Sub Dgitmems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgitmems.CellContentClick

    End Sub

    Private Sub AllRb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rbpur.GotFocus, rbattach.GotFocus 
        Try
            Dim rb As RadioButton = CType(sender, RadioButton)
            rb.BackColor = Color.LightPink
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AllRb_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rbpur.Leave, rbattach.Leave 
        Try
            Dim rb As RadioButton = CType(sender, RadioButton)
            rb.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AllRb1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rbxcode.GotFocus, RbxiName.GotFocus, RbxName.GotFocus
        Try
            Dim rb As RadioButton = CType(sender, RadioButton)
            rb.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AllRb1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rbxcode.Leave, RbxiName.Leave, RbxName.Leave
        Try
            Dim rb As RadioButton = CType(sender, RadioButton)
            rb.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkprnt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkprnt.GotFocus
        Try
            Me.Chkprnt.BackColor = Color.LightPink

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllTxtordrno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkprnt.KeyDown, CmbxCarri.KeyDown _
    , CmbxFret.KeyDown, Cmbxstatus.KeyDown, CmbxWareh.KeyDown, dtpordrdt.KeyDown, Dtpreqstdt.KeyDown, rbattach.KeyDown, Rbpur.KeyDown, Rbxcode.KeyDown _
    , Rbxcode.KeyDown, RbxiName.KeyDown, RbxName.KeyDown, Txtcoment.KeyDown, Txtordrno.KeyDown, txtvCode.KeyDown, TxtVname.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkprnt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkprnt.Leave
        Try
            Me.Chkprnt.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxstatus_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxstatus.Leave
        Try
            If FrmShow_flag(9) = True Then
                If Me.Dgitmems.Rows.Count > 0 Then
                    For Each xrr As DataGridViewRow In Me.Dgitmems.Rows
                        If Chk_Del_Xstatus(xrr.Cells(6).Value) = False Then
                            Me.Dgitmems.CurrentCell.ReadOnly = True
                            Me.Cmbxstatus.SelectedIndex = xStatusIndx1
                            MsgBox("Invalid Input!,Current item has been partly or fully Received", MsgBoxStyle.Critical, Me.Text)
                            Exit Sub
                        End If
                    Next
                End If
            End If
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

    Private Sub BtnOAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnO_Save.GotFocus, BtnO_exit.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnO_exit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnO_exit.Leave, BtnO_Save.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkBx1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBx1.GotFocus
        Try
            Me.ChkBx1.BackColor = Color.LightPink
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkBx1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBx1.Leave
        Try
            Me.ChkBx1.BackColor = Color.Transparent
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

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If Len(Me.Dgitmems.Rows(0).Cells(0).Value) > 0 Then
                FrmShow_flag(3) = True
                xCall_LinkFrmDgVew(FrmStokItm, Me.Dgitmems)
            Else

                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)

            End If

        Catch ex As Exception

        End Try
    End Sub
End Class




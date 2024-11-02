Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmTranSaleEntryThruChln
    Dim TpoCmd As SqlCommand
    Dim TpoRdr As SqlDataReader
    Dim TpoCmd1 As SqlCommand
    Dim TpoRdr1 As SqlDataReader
    Dim SplrId As Integer = 0
    Dim MaxSplid As Integer = 0

    Private Sub FrmTranPurOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New System.Drawing.Point(927, 647)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.ChkBx1.Checked = False
            Me.SplitContainer1.SplitterDistance = 575
            Me.Top = 0
            Me.Left = 0
            Select_2rec_with_where(Me.CmbxWareh, SplrId)
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)
            Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxSplr, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Customer", "Customer", 1)
            Me.CmbxItmName.DataSource = Nothing
            Fill_Combobox("cogrpid", "cogrupnam", "FinactStokGrupname", "CoDelStatus", CInt(1), Me.CmbxItmGrup)
            Me.LstVewPurItms.Items.Clear()
            Me.dtpordrdt.MinDate = FinStartDt.Date
            Me.dtpordrdt.MaxDate = FinEnddt.Date
            If Curr_MaxId() > 0 Then
                Me.dtpordrdt.Value = Curr_Maxdate()
            Else
                Me.dtpordrdt.Value = Now
            End If
            Me.Text = "Sale Entry (Through Challan)" & "  (CURRENT USER NAME:- " & Trim(Current_UserName) & ",DESIGNATION:- " & Trim(Current_UserDesi)
            Me.Panel5.Enabled = True
            Me.dtpordrdt.Focus()
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
        Try
            Dim frmW As New FrmInLocat
            frmW.ShowInTaskbar = False
            FrmShow_flag(6) = True
            frmW.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnaddware_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnaddware.GotFocus
        If FrmShow_flag(6) = True Then
            CmbxWareh.Focus()
        End If
    End Sub

    Private Sub CmbxWareh_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWareh.GotFocus
        Try
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

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxWareh_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWareh.Leave
        Try
            If FrmShow_flag(6) = True Then
                FrmShow_flag(6) = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAddCarri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCarri.Click
        Try
            Dim frmcari As New FrmCarriermstr
            frmcari.ShowInTaskbar = False
            FrmShow_flag(7) = True
            frmcari.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAddCarri_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddCarri.GotFocus
        Try
            If FrmShow_flag(7) = True Then
                Me.CmbxCarri.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCarri_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.GotFocus
        Try
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCarri_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.Leave
        Try
            If FrmShow_flag(7) = True Then
                FrmShow_flag(7) = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub allControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCarri.KeyDown, CmbxWareh.KeyDown, dtpordrdt.KeyDown, TxtPurBillNo.KeyDown, TxtQnty.KeyDown, TxtItmRate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnO_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSe_exit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPe_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSe_Save.Click
        Try
            If MessageBox.Show("Are you sure to save this record", "Purchase Entry Through Challan....", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                BtnSe_Save.Focus()
                Return
            Else
                PurEntrySave()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub PurEntrySave()
        Try
            If Me.LstVewPurItms.Items.Count > 0 Then
                For Each xli As ListViewItem In Me.LstVewPurItms.Items
                    TpoCmd = New SqlCommand("Finact_Purentry_Details_Challan_Insert", FinActConn)
                    TpoCmd.CommandType = CommandType.StoredProcedure
                    TpoCmd.Parameters.AddWithValue("@dPurentconcrnid", CInt(Me.CmbxSplr.SelectedValue))
                    TpoCmd.Parameters.AddWithValue("@dPurent_con_dPurid", 0)
                    TpoCmd.Parameters.AddWithValue("@dPurentitmid", CInt(xli.SubItems(6).Text))
                    TpoCmd.Parameters.AddWithValue("@dpurentqnty", CDbl(xli.SubItems(1).Text))
                    TpoCmd.Parameters.AddWithValue("@dPurentDescrpt", 0)
                    TpoCmd.Parameters.AddWithValue("@dPurentitmrate", CDbl(xli.SubItems(3).Text))
                    TpoCmd.Parameters.AddWithValue("@dPurentlocid", Me.CmbxWareh.SelectedValue)
                    TpoCmd.Parameters.AddWithValue("@dpurentChlnNo", Me.TxtPurBillNo.Text.Trim) '
                    TpoCmd.Parameters.AddWithValue("@dpurentBilled", 0)
                    TpoCmd.Parameters.AddWithValue("@dpurentproddt", Me.dtpordrdt.Value.Date)
                    TpoCmd.Parameters.AddWithValue("@dpurentChlnAdusrid", Current_UsrId)
                    TpoCmd.Parameters.AddWithValue("@dpurentChlnAddt", Now)
                    TpoCmd.ExecuteNonQuery()
                Next
                MsgBox("Current Record Has Been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                Clear_Values()
                Me.TxtPurBillNo.Focus()
                Me.TxtPurBillNo.SelectAll()
            Else
                MsgBox("Invalid action! System could not found any record to save", MsgBoxStyle.Critical, "Empty Table")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoCmd.Dispose()
        End Try


    End Sub
    Private Function Curr_MaxId() As Integer
        Try
            Dim Curr_MaxPurid As Integer = 0
            TpoCmd1 = New SqlCommand("select max(Purentid) from finactPurentry ", FinActConn1)
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
            TpoCmd1 = New SqlCommand("select max(Purentdt) from finactPurentry where  Purentdelstatus=1", FinActConn1)

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

    Private Sub Clear_Values()
        Try
            Me.TxtPurBillNo.Clear()
            Me.CmbxSplr.SelectedIndex = -1
            Me.CmbxItmName.DataSource = Nothing
            Me.TxtQnty.Text = 0
            Me.TxtItmRate.Text = 0
            Me.Txtcoment.Clear()
            Me.LstVewPurItms.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Function chk_Emptyvalue() As Integer
        Try
            Dim ErrIndx As Integer = 0
            With Me.CmbxSplr
                If .SelectedIndex = -1 Then
                    .BackColor = Color.Cyan
                    ErrIndx += 1
                End If
            End With

            With TxtPurBillNo
                If Len(.Text) = 0 Then
                    .BackColor = Color.Cyan
                    ErrIndx += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtQnty
                If Len(.Text.Trim) = 0 Then
                    .BackColor = Color.Cyan
                    ErrIndx += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtItmRate
                If Len(.Text.Trim) = 0 Then
                    .BackColor = Color.Cyan
                    ErrIndx += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            Return ErrIndx
        Catch ex As Exception

        End Try
    End Function
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            Me.BtnPe_Save_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.BtnO_exit_Click(sender, e)
    End Sub

    Private Sub Txtcoment_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcoment.Leave
        Try
            Me.Txtcoment.BackColor = Color.White
            Me.CmbxItmGrup.Focus()
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
                Me.LblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(Me.CmbxSplr.SelectedValue), Me.LblType), 2)
                Me.Txtcoment.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        Try
            Dim xS As New FrmTranSaleEntryThruChlnEdit
            xS.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xS)
            xS.BringToFront()
            xS.Show()
            Me.Close()
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

    Private Sub CmbxItmGrup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxItmGrup.GotFocus
        Try
            If xCmbxRefresh = True Then
                Fill_Combobox("cogrpid", "cogrupnam", "FinactStokGrupname", "CoDelStatus", CInt(1), Me.CmbxItmGrup)
            End If
            Me.CmbxItmGrup.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxItmGrup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxItmGrup.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxItmGrup_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxItmGrup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxItmGrup.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxItmGrup) = True Then
                Me.CmbxItmName.DataSource = Nothing
                Fill_Combobox_where_cond("ItmId", "ItmName", "Itmcatid", "FinactItmmstr", "ITMDELSTATUS", CInt(1), Me.CmbxItmGrup.SelectedValue, Me.CmbxItmName)
                Me.CmbxItmName.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxItmName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxItmName.GotFocus
        Try
            If xCmbxRefresh = True Then
                Fill_Combobox_where_cond("ItmId", "ItmName", "Itmcatid", "FinactItmmstr", "ITMDELSTATUS", CInt(1), Me.CmbxItmGrup.SelectedValue, Me.CmbxItmName)
            End If
            CmbxItmName.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxItmName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxItmName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxItmName_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxItmName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxItmName.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxItmName) = True Then
                Me.TxtQnty.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnGrup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrup.Click
        Try
            xCall_LinkFrm(FrmStokgrup, Me.CmbxItmGrup)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnItm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnItm.Click
        Try
            xCall_LinkFrm(FrmStokItm, Me.CmbxItmName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtQnty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQnty.Leave
        Try
            If Len(Me.TxtQnty.Text.Trim) = 0 Then
                Me.TxtQnty.Focus()
                Exit Sub
            End If
            If xChk_numericValidation(Me.TxtQnty) = False Then
                If Me.TxtQnty.Text = 0 Then
                    MsgBox("Invalid Input!  Quantity Should not be Zero.", MsgBoxStyle.Critical, Me.Text)
                    Me.TxtQnty.Focus()
                    Exit Sub
                End If
                Me.TxtQnty.Text = FormatNumber(Me.TxtQnty.Text, 3)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtItmRate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItmRate.Leave
        Try
            If Len(Me.TxtItmRate.Text.Trim) = 0 Then
                Me.TxtItmRate.Text = 0
            End If
            If xChk_numericValidation(Me.TxtItmRate) = False Then
                Me.TxtItmRate.Text = FormatNumber(Me.TxtItmRate.Text, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If chk_Emptyvalue() > 0 Then
                MsgBox("Invalid Input!.......", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

            If MessageBox.Show("Are you sure to add current Item?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim xLsti As ListViewItem
                xLsti = Me.LstVewPurItms.Items.Add(Me.CmbxItmName.Text.Trim) '0
                xLsti.SubItems.Add(Me.TxtQnty.Text) '1
                xLsti.SubItems.Add(Trim(xDynamic_Find_xAnItem_xInA_Table_1cond_String("ItmUntType", "ItmId", CInt(Me.CmbxItmName.SelectedValue), "finactitmmstr"))) '2
                xLsti.SubItems.Add(Me.TxtItmRate.Text) '3
                xLsti.SubItems.Add(CDbl(CDbl(Me.TxtQnty.Text) * CDbl(Me.TxtItmRate.Text))) '4
                xLsti.SubItems.Add(Me.CmbxItmGrup.SelectedValue) '5
                xLsti.SubItems.Add(Me.CmbxItmName.SelectedValue) '6
                If MessageBox.Show("Current Item has been successfully added. Do you want add more Item?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.TxtQnty.Text = 0
                    Me.TxtItmRate.Text = 0
                    Me.CmbxItmGrup.Focus()
                Else
                    Me.BtnSe_Save.Focus()
                End If

            Else
                Me.CmbxItmGrup.Focus()
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            If Me.LstVewPurItms.SelectedItems.Count > 0 Then
                If MessageBox.Show("Are you sure to remove current selected item(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    For Each xxli As ListViewItem In Me.LstVewPurItms.SelectedItems
                        Me.LstVewPurItms.Items.RemoveAt(xxli.Index)
                    Next
                Else
                    Return
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CmbxSplr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxSplr.SelectedIndexChanged

    End Sub
End Class




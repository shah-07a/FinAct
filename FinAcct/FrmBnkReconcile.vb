Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class FrmBnkReconcile
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim rdr As SqlDataReader
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CrRptbb As New CrRptBnkBook
    Dim sql As inv_sql
    Dim sql1 As inv_sql
    Dim AcGdgr As DataGridViewRow
    Dim AcGcel As DataGridViewTextBoxCell
    Dim AcGcom As DataGridViewComboBoxCell
    Dim AcGdtp As CalendarColumn



    Private Sub FrmRptBnkBook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            Dim xInt As Integer = 0
            For Each xxr As DataGridViewRow In Me.DgBnkRecon.Rows
                If xxr.Cells(9).Value = True Then
                    xInt += 1
                End If
            Next
            If xInt > 0 Then
                If MessageBox.Show("Do you want to save current session as reconciled?", "Bank Reconcile Session", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    For Each xRow As DataGridViewRow In Me.DgBnkRecon.Rows
                        If xRow.Cells(9).Value = True Then
                            If xRow.Cells(6).Value = 0 Then
                                xSetOpnBalStatusAsReconciled(Me.Cmbxbb.SelectedValue)
                            End If
                            xUpdateBnkReconciledRec(CInt(xRow.Cells(6).Value), CDate(xRow.Cells(8).Value))
                        End If
                    Next
                End If
            End If
            cmd = New SqlCommand("Delete from FINACT_TEMP_bbookReconcile_all", FinActConn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
        End Try
    End Sub
    Private Sub xUpdateBnkReconciledRec(ByVal xRecNo As Integer, ByVal xBnkdt As DateTime)
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            FinActCmd = New SqlCommand("Finact_Bank_Reconciled_Status_Update", FinActConn2)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xRecId", CInt(xRecNo))
            FinActCmd.Parameters.AddWithValue("@xBnkDt", xBnkdt.Date)
            FinActCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
        End Try
    End Sub

    Private Sub xSetOpnBalStatusAsReconciled(ByVal xActId As Integer)
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            FinActCmd = New SqlCommand("Finact_Bank_Reconciled_OPNBAL_Status_Update", FinActConn2)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xActId", CInt(xActId))
            FinActCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
        End Try
    End Sub
    Private Sub FrmRptBnkBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Top = 0
            sql = New inv_sql
            sql1 = New inv_sql
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.Dtpbb1, Me.Dtpbb2)
            Select_2rec_where("splrid", "Splrname", "Splrtype", "Finactsplrmstr", Me.Cmbxbb, "Bank", "SPLRDELSTATUS", CInt(1))
            FillTempTable_BB()
            Me.Dtpbb1.MaxDate = Me.Dtpbb1.MinDate.AddYears(1)
            Me.Dtpbb1.Focus()

        Catch ex As Exception

        End Try



    End Sub

    Private Sub FillTempTable_BB()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Finact_Rpt_BankBook_Reconcile_FillTalbe", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Sel_Dt1", Me.Dtpbb1.Value.Date)
            cmd.Parameters.AddWithValue("@Sel_Dt2", Me.Dtpbb2.Value.Date)
            'cmd.Parameters.AddWithValue("@xbnkid", Me.Cmbxbb.SelectedValue)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- FillTempTable_BB, Line No. 38 ")
        Finally
            cmd.Dispose()

        End Try

    End Sub


    Private Sub BtnRptVewbb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRptVewbb.Click
        Try
            Handle_P_Bar_Part_I(Me)
            Handle_P_Bar(Me)
            Me.DgBnkRecon.Columns.Clear()
            Me.DgBnkRecon.Refresh()
            Fetch_BnkReconcile_Record()
            If Me.DgBnkRecon.Rows.Count > 0 Then
                Dim AmtCr As Double = SumOfDg_Cr(Me.DgBnkRecon)
                Dim AmtDr As Double = SumOfDg_Dr(Me.DgBnkRecon)

                If AmtCr > AmtDr Then
                    Me.LblBnkBal.Text = FormatNumber(AmtCr - AmtDr, 2)
                    Me.LblBalType2.Text = "Cr"
                ElseIf AmtDr > AmtCr Then
                    Me.LblBnkBal.Text = FormatNumber(AmtDr - AmtCr, 2)
                    Me.LblBalType2.Text = "Dr"
                Else
                    Me.LblBnkBal.Text = FormatNumber(0, 2)
                    Me.LblBalType2.Text = ""

                End If

            End If
            Me.DgBnkRecon.Height = 606
            Me.Pnlbnk.Visible = False
            Me.Pnlbnk.Enabled = False
            Me.Pnlsumry.Visible = False
            Me.Pnlsumry.Enabled = False
            Me.Height = Screen.PrimaryScreen.WorkingArea.Height - 20
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 20
            Me.DgBnkRecon.Width = Me.Width - 40
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SelRecd_Fromtable_BB()
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_BB, Line No. 236 ")
        End Try


    End Sub

    Private Sub Cmbxbb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxbb.GotFocus
        Try
            Me.Cmbxbb.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBnkBal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBnkBal.GotFocus
        Try
            TxtBnkBal.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpbb2.KeyDown, Cmbxbb.KeyDown _
    , Dtpbb1.KeyDown, CmbxDrCr.KeyDown, TxtBnkBal.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fetch_BnkReconcile_Record()
        Try
            cmd = New SqlCommand("Finact_Rpt_BankReconcile_Select", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@xDt1", Me.Dtpbb1.Value.Date)
            cmd.Parameters.AddWithValue("@xDt2", Me.Dtpbb2.Value.Date)
            cmd.Parameters.AddWithValue("@xbnkid", Me.Cmbxbb.SelectedValue)
            FinActDset = New DataSet(cmd.CommandText)
            FinActDset.Tables.Clear()
            FinActSqlAdptr = New SqlDataAdapter(cmd)
            FinActSqlAdptr.Fill(FinActDset)
            Me.DgBnkRecon.AutoGenerateColumns = False
            Me.DgBnkRecon.AllowUserToAddRows = False
            Me.DgBnkRecon.RowHeadersWidth = 30
            Me.DgBnkRecon.EnableHeadersVisualStyles = True
            Me.DgBnkRecon.DataSource = FinActDset.Tables(0)
            Dim DGColumn1 As New DataGridViewTextBoxColumn 'DATE
            DGColumn1.Name = "DATE"
            DGColumn1.DataPropertyName = "DATE"
            DGColumn1.DefaultCellStyle.Format = "dd/MM/yyyy"
            DGColumn1.ReadOnly = True
            DGColumn1.Width = "100"
            DgBnkRecon.Columns.Insert(0, DGColumn1)

            Dim DGColumn2 As New DataGridViewTextBoxColumn 'ACCOUNT
            DGColumn2.Name = "ACCOUNT_NAME"
            DGColumn2.DataPropertyName = "ACCOUNT_NAME"
            DGColumn2.ReadOnly = True
            DGColumn2.Width = "0"
            DgBnkRecon.Columns.Insert(1, DGColumn2)
            DGColumn2.Visible = False

            Dim DGColumn3 As New DataGridViewTextBoxColumn 'PARTICULARS
            DGColumn3.Name = "PARTICULARS"
            DGColumn3.DataPropertyName = "PARTICULARS"
            DGColumn3.ReadOnly = True
            DGColumn3.Width = "330"
            DgBnkRecon.Columns.Insert(2, DGColumn3)

            Dim DGColumn4 As New DataGridViewTextBoxColumn 'VOUCHER NO
            DGColumn4.Name = "V_NO"
            DGColumn4.DataPropertyName = "V_NO"
            DGColumn4.ReadOnly = True
            DGColumn4.Width = "60"
            DgBnkRecon.Columns.Insert(3, DGColumn4)

            Dim DGColumn5 As New DataGridViewTextBoxColumn 'DEBIT
            DGColumn5.Name = "DEBIT"
            DGColumn5.DataPropertyName = "DEBIT"
            DGColumn5.DefaultCellStyle.Format = "N2"
            DGColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGColumn5.ReadOnly = True
            DGColumn5.Width = "120"
            DgBnkRecon.Columns.Insert(4, DGColumn5)

            Dim DGColumn6 As New DataGridViewTextBoxColumn 'CREDIT
            DGColumn6.Name = "CREDIT"
            DGColumn6.DataPropertyName = "CREDIT"
            DGColumn6.DefaultCellStyle.Format = "N2"
            DGColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGColumn6.ReadOnly = True
            DGColumn6.Width = "120"
            DgBnkRecon.Columns.Insert(5, DGColumn6)

            Dim DGColumn7 As New DataGridViewTextBoxColumn 'TRANSID
            DGColumn7.Name = "TRANS_ID"
            DGColumn7.DataPropertyName = "TRANS_ID"
            DGColumn7.ReadOnly = True
            DGColumn7.Visible = False
            DGColumn7.Width = "100" '0
            DgBnkRecon.Columns.Insert(6, DGColumn7)

            Dim DGColumn8 As New DataGridViewTextBoxColumn 'ReconStatus
            DGColumn8.Name = "RECONSTATUS"
            DGColumn8.DataPropertyName = "RECONSTATUS"
            DGColumn8.ReadOnly = True
            DGColumn8.Visible = False
            DGColumn8.Width = "100" '0
            DgBnkRecon.Columns.Insert(7, DGColumn8)


            Dim DGColumn9 As New CalendarColumn() 'bankdate
            DGColumn9.Name = "BANK DATE"
            DGColumn9.DataPropertyName = "BANK_DT"
            DGColumn9.ReadOnly = False
            DGColumn9.Width = "100"
            DgBnkRecon.Columns.Insert(8, DGColumn9)

            Dim DGColumn10 As New DataGridViewCheckBoxColumn 'checkbox
            DGColumn10.Name = "STATUS"
            DGColumn10.DataPropertyName = "STATUS"
            DGColumn10.ReadOnly = False
            DGColumn10.Width = "90"
            DgBnkRecon.Columns.Insert(9, DGColumn10)

            Dim DGColumn11 As New DataGridViewTextBoxColumn 'Custid
            DGColumn11.Name = "STATUS"
            DGColumn11.DataPropertyName = "STATUS"
            DGColumn11.ReadOnly = False
            DGColumn11.Visible = False
            DGColumn11.Width = "100" '0
            DgBnkRecon.Columns.Insert(10, DGColumn11)

            DgBnkRecon.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DgBnkRecon.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DgBnkRecon.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            DgBnkRecon.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            DgBnkRecon.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            DgBnkRecon.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            DgBnkRecon.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
            DgBnkRecon.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
            DgBnkRecon.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
            DgBnkRecon.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
            DgBnkRecon.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable

            Dim row As DataGridViewRow
            For Each row In Me.DgBnkRecon.Rows
                row.Cells(8).Value = Format(row.Cells(0).Value, "dd/MM/yyyy")
                If row.Cells(7).Value > 0 Then
                    row.Cells(9).Value = True
                Else
                    row.Cells(9).Value = False
                End If
            Next row

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing

        End Try
    End Sub

    Private Sub FillLstVew_1_and_2()
        Try
            Me.LstvewBank1.Items.Clear()
            Me.LstvewBnk2.Items.Clear()
            Dim xLst1 As ListViewItem
            Dim xLst2 As ListViewItem
            Dim x1 As Integer = 0
            For Each xRw As DataGridViewRow In Me.DgBnkRecon.Rows
                If IsDBNull(xRw.Cells(7).Value) Then xRw.Cells(7).Value = 0
                If xRw.Cells(7).Value = 0 And Not IsDBNull(xRw.Cells(4).Value) Then 'Debit
                    xLst2 = Me.LstvewBnk2.Items.Add(Format(xRw.Cells(0).Value, "dd/MM/yyyy"))
                    xLst2.SubItems.Add(xRw.Cells(1).Value)
                    xLst2.SubItems.Add(xRw.Cells(2).Value)
                    xLst2.SubItems.Add(FormatNumber(xRw.Cells(4).Value, 2))
                ElseIf xRw.Cells(7).Value = 0 And Not IsDBNull(xRw.Cells(5).Value) Then 'Credit
                    xLst1 = Me.LstvewBank1.Items.Add(Format(xRw.Cells(0).Value, "dd/MM/yyyy"))
                    xLst1.SubItems.Add(xRw.Cells(1).Value)
                    xLst1.SubItems.Add(xRw.Cells(2).Value)
                    xLst1.SubItems.Add(FormatNumber(xRw.Cells(5).Value, 2))
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Me.DgBnkRecon.Rows.Count > 0 Then
                If Trim(Me.BtnSave.Text) = "&Reconcile" Then
                    If Me.CmbxDrCr.SelectedIndex = -1 Then
                        Me.CmbxDrCr.SelectedIndex = 0
                    End If
                    Me.DgBnkRecon.Height = 225
                    Me.Pnlbnk.Visible = True
                    Me.Pnlbnk.Enabled = True
                    Me.Pnlsumry.Visible = True
                    Me.Pnlsumry.Enabled = True
                    Me.BtnReconSave.Enabled = True
                    Me.BtnReconSave.Visible = True
                    Me.BtnSave.Text = "&Back"
                    Me.RECONCILEToolStripMenuItem.Text = "&Back"
                    Me.DgBnkRecon.Enabled = False
                    Me.BtnRptVewbb.Enabled = False
                    Me.Cmbxbb.Enabled = False
                    FillLstVew_1_and_2()
                    Me.LblDr.Text = FormatNumber(SumOfLstvew(Me.LstvewBank1), 2)
                    Me.LblCr.Text = FormatNumber(SumOfLstvew(Me.LstvewBnk2), 2)
                    Set_Bnk_Rec_formula()
                ElseIf Trim(Me.BtnSave.Text) = "&Back" Then
                    Me.DgBnkRecon.Height = 606
                    Me.Pnlbnk.Visible = False
                    Me.Pnlbnk.Enabled = False
                    Me.Pnlsumry.Visible = False
                    Me.Pnlsumry.Enabled = False
                    Me.BtnReconSave.Enabled = False
                    Me.BtnReconSave.Visible = False
                    Me.BtnSave.Text = "&Reconcile"
                    Me.RECONCILEToolStripMenuItem.Text = "&Reconcile"
                    Me.DgBnkRecon.Enabled = True
                    Me.BtnRptVewbb.Enabled = True
                    Me.Cmbxbb.Enabled = True
                End If
            
            Else
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Function SumOfLstvew(ByVal xLstVew As ListView) As Double
        Try
            Dim xAmt As Double = 0
            For Each xItm As ListViewItem In xLstVew.Items
                xAmt += xItm.SubItems(3).Text
            Next
            Return xAmt
        Catch ex As Exception

        End Try
    End Function

    Private Function SumOfDg_Cr(ByVal xxDg1 As DataGridView) As Double
        Try
            Dim xAmt1 As Double = 0
            For Each xRwsx As DataGridViewRow In xxDg1.Rows
                If IsDBNull(xRwsx.Cells(5).Value) = False Then
                    xAmt1 += xRwsx.Cells(5).Value
                End If
            Next
            Return xAmt1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Private Function SumOfDg_Dr(ByVal xDg1 As DataGridView) As Double
        Try
            Dim xAmtx As Double = 0
            For Each xRws1 As DataGridViewRow In xDg1.Rows
                If IsDBNull(xRws1.Cells(4).Value) = False Then
                    xAmtx += xRws1.Cells(4).Value
                End If
            Next
            Return xAmtx
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Private Sub DgBnkRecon_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgBnkRecon.CellValueChanged
        Try
            If e.ColumnIndex = 9 Then
                If Me.DgBnkRecon.CurrentCell.Value = True Then
                    Me.DgBnkRecon.CurrentRow.Cells(7).Value = 1
                ElseIf Me.DgBnkRecon.CurrentCell.Value = False Then
                    Me.DgBnkRecon.CurrentRow.Cells(7).Value = 0
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExt.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtBnkBal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBnkBal.Leave
        Try
            If xChk_numericValidation(Me.TxtBnkBal) = True Then

                Exit Sub
            Else
                If Trim(Me.TxtBnkBal.Text) = "" Then Me.TxtBnkBal.Text = 0
                Me.TxtBnkBal.Text = FormatNumber(Me.TxtBnkBal.Text, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxDrCr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDrCr.GotFocus
        Try
            Me.CmbxDrCr.DroppedDown = True
            If Me.CmbxDrCr.SelectedIndex = -1 Then
                Me.CmbxDrCr.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Set_Bnk_Rec_formula()
        Try
            Dim XDR As Double = Me.LblDr.Text 'ch issued
            Dim xCr As Double = Me.LblCr.Text 'ch deposit
            Dim xbokbal As Double = Me.LblBnkBal.Text 'book bal
            Dim xbnkbal As Double = Me.TxtBnkBal.Text 'bank bal
            Dim XDBAL As Double = 0
            If Trim(Me.LblBalType2.Text) = "Cr" Then
                Me.Lblbokbal1.Text = FormatNumber(xbokbal, 2)
                Me.LblChissued.Text = "CHEQUE(S) NOT PRESENTED IN BANK YET (-)"
                Me.lblchisue.Text = FormatNumber(XDR, 2)
                Me.LblChDepost.Text = "CHEQUE(S)NOT CLEARED IN BANK YET (+)"
                Me.lblchdep.Text = FormatNumber(xCr, 2)
                Me.LBLBNKBAL1.Text = FormatNumber(xbnkbal, 2)
                Dim XNBAL As Double = XDR - xCr
                Me.LblnetBal.Text = FormatNumber(xbokbal - XNBAL, 2)
                XDBAL = Me.LblnetBal.Text
                If Me.CmbxDrCr.Text = "Dr" Then
                    Me.lBLdIFF.Text = FormatNumber(xbnkbal - XDBAL, 2)
                ElseIf Me.CmbxDrCr.Text = "Cr" Then
                    Me.lBLdIFF.Text = FormatNumber(xbnkbal + XDBAL, 2)
                End If

            ElseIf Trim(Me.LblBalType2.Text) = "Dr" Then
                Me.Lblbokbal1.Text = FormatNumber(xbokbal, 2)
                Me.LblChissued.Text = "CHEQUE(S) NOT PRESENTED IN BANK YET (+)"
                Me.lblchisue.Text = FormatNumber(XDR, 2)
                Me.LblChDepost.Text = "CHEQUE(S)NOT CLEARED IN BANK YET (-)"
                Me.lblchdep.Text = FormatNumber(xCr, 2)
                Me.LBLBNKBAL1.Text = FormatNumber(xbnkbal, 2)
                Dim XNBAL As Double = XDR - xCr
                Me.LblnetBal.Text = FormatNumber(xbokbal + XNBAL, 2)
                XDBAL = Me.LblnetBal.Text
                If Me.CmbxDrCr.Text = "Dr" Then
                    Me.lBLdIFF.Text = FormatNumber(xbnkbal + XDBAL, 2)
                ElseIf Me.CmbxDrCr.Text = "Cr" Then
                    Me.lBLdIFF.Text = FormatNumber(xbnkbal - XDBAL, 2)
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxDrCr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxDrCr.SelectedIndexChanged

    End Sub

    Private Sub Dtpbb2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtpbb2.ValueChanged
        Try
            Me.Dtpbb2.MinDate = Me.Dtpbb1.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dtpbb1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpbb1.ValueChanged
        Try
            Me.Dtpbb2.MinDate = Me.Dtpbb1.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBnkBal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBnkBal.TextChanged

    End Sub

    Private Sub BtnReconSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReconSave.Click
        Try
            SaveDataForPrint()
            SaveDataForBnkReconcile()
            Dim FrmRec As New FrmCrRptReconcilePrint
            FrmRec.ShowInTaskbar = False
            FrmRec.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SaveDataForPrint()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            If Me.LstvewBank1.Items.Count > 0 Then
                For Each Itmx As ListViewItem In Me.LstvewBank1.Items
                    cmd = New SqlCommand("Finact_Rpt_BankReconcile_Simmary_Insert", FinActConn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@xDt1", Itmx.SubItems(0).Text.Trim)
                    cmd.Parameters.AddWithValue("@xname", Itmx.SubItems(1).Text)
                    cmd.Parameters.AddWithValue("@xDetails", Itmx.SubItems(2).Text)
                    'cmd.Parameters.AddWithValue("@xvno", Format(Itmx.SubItems(0).Text, "yyyyMMdd"))
                    cmd.Parameters.AddWithValue("@xDr", CDbl(Itmx.SubItems(3).Text))
                    cmd.Parameters.AddWithValue("@xCr", 0)
                    cmd.Parameters.AddWithValue("@xtype", "ChIssued")
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                Next
            End If
            If Me.LstvewBnk2.Items.Count > 0 Then
                For Each Itmx As ListViewItem In Me.LstvewBnk2.Items
                    cmd = New SqlCommand("Finact_Rpt_BankReconcile_Simmary_Insert", FinActConn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@xDt1", Itmx.SubItems(0).Text)
                    cmd.Parameters.AddWithValue("@xname", Itmx.SubItems(1).Text)
                    cmd.Parameters.AddWithValue("@xDetails", Itmx.SubItems(2).Text)
                    'cmd.Parameters.AddWithValue("@xvno", Format(Itmx.SubItems(0).Text, "yyyyMMdd"))
                    cmd.Parameters.AddWithValue("@xcr", CDbl(Itmx.SubItems(3).Text))
                    cmd.Parameters.AddWithValue("@xdr", 0)
                    cmd.Parameters.AddWithValue("@xtype", "ChDeposit")
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            'cmd.Dispose()

        End Try
    End Sub

    Private Sub SaveDataForBnkReconcile()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Finact_Rpt_Temp_BnkReconSummary_Insert", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@xtxt", Trim(Me.LblBalance.Text))
            cmd.Parameters.AddWithValue("@xamt", CDbl(Me.Lblbokbal1.Text))
            cmd.Parameters.AddWithValue("@xtype", 1)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = New SqlCommand("Finact_Rpt_Temp_BnkReconSummary_Insert", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@xtxt", Trim(Me.LblChissued.Text))
            cmd.Parameters.AddWithValue("@xamt", CDbl(Me.lblchisue.Text))
            cmd.Parameters.AddWithValue("@xtype", 2)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = New SqlCommand("Finact_Rpt_Temp_BnkReconSummary_Insert", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@xtxt", Trim(Me.LblChDepost.Text))
            cmd.Parameters.AddWithValue("@xamt", CDbl(Me.lblchdep.Text))
            cmd.Parameters.AddWithValue("@xtype", 3)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = New SqlCommand("Finact_Rpt_Temp_BnkReconSummary_Insert", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@xtxt", Trim(Me.Label14.Text))
            cmd.Parameters.AddWithValue("@xamt", CDbl(Me.LblnetBal.Text))
            cmd.Parameters.AddWithValue("@xtype", 4)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = New SqlCommand("Finact_Rpt_Temp_BnkReconSummary_Insert", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@xtxt", Trim(Me.Label15.Text))
            cmd.Parameters.AddWithValue("@xamt", CDbl(Me.LBLBNKBAL1.Text))
            cmd.Parameters.AddWithValue("@xtype", 5)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = New SqlCommand("Finact_Rpt_Temp_BnkReconSummary_Insert", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@xtxt", Trim(Me.Label9.Text))
            cmd.Parameters.AddWithValue("@xamt", CDbl(Me.lBLdIFF.Text))
            cmd.Parameters.AddWithValue("@xtype", 6)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()

        End Try
    End Sub
    
    Private Sub OKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKToolStripMenuItem.Click
        Try
            If Me.BtnReconSave.Visible = True Then Exit Sub
            Me.BtnRptVewbb_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RECONCILEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECONCILEToolStripMenuItem.Click
        Try
          
            Me.BtnSave_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CHECKALLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHECKALLToolStripMenuItem.Click
        Try
            If Me.BtnReconSave.Visible = True Then Exit Sub
            For Each xdgr As DataGridViewRow In Me.DgBnkRecon.Rows
                xdgr.Cells(7).Value = 1
                xdgr.Cells(9).Value = True
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CLEARALLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLEARALLToolStripMenuItem.Click
        Try
            If Me.BtnReconSave.Visible = True Then Exit Sub
            For Each xdgr As DataGridViewRow In Me.DgBnkRecon.Rows
                xdgr.Cells(7).Value = 0
                xdgr.Cells(9).Value = False
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PRINTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTToolStripMenuItem.Click
        Try
            If Me.BtnReconSave.Visible = False Then Exit Sub
            Me.BtnReconSave_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EXITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXITToolStripMenuItem.Click
        Try
            Me.BtnExt_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub
End Class
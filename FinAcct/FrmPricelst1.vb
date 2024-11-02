Imports System.Data
Imports System.Data.SqlClient

Public Class FrmPricelst1
    Dim SplCmd As SqlCommand
    Dim SplRdr As SqlDataReader

    Private Sub FrmPricelst1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 20
            Fill_Combobox_where_Not_In_cond("Cogrpid", "Cogrupnam", "Cogrpid", "FinactStokGrupName", CInt(1), CInt(1), Me.CmbxUndrGrup, "CODELSTATUS", CInt(1))
            Me.CmbxUndrGrup.SelectedIndex = -1
            Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxPlst, "finact_salepricelstmstr", "spl_id", "spl_name", "splitmtype", "Spl_delstatus", "FAB", "MACH", 1)
            Me.CmbxPlst.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPlst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPlst.GotFocus
        Try
            Me.CmbxPlst.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPlst_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxPlst.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxPlst_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPlst_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPlst.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxPlst) = True Then
                Me.Chkbxall.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xFillDgItm(ByVal ItmId As Integer, ByVal xType As Integer, ByVal xGrupId As Integer)
        Try
            Me.DgItms.Rows.Clear()
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            If Cl_Kbl = True Then
                SplCmd = New SqlCommand("Finact_SalePriceList_AddnewItem_kbltype_Select", FinActConn)
                SplCmd.Parameters.AddWithValue("@GRUPid", CInt(xGrupId))
                SplCmd.Parameters.AddWithValue("@xtype", CInt(xType))
            Else
                SplCmd = New SqlCommand("Finact_SalePriceList_AddnewItem_Select", FinActConn)
            End If

            SplCmd.CommandType = CommandType.StoredProcedure
            SplCmd.Parameters.AddWithValue("@xSpl_id", ItmId)
            SplRdr = SplCmd.ExecuteReader
            Dim xr As Integer = 0
            While SplRdr.Read
                Me.DgItms.Rows.Add()
                Me.DgItms.Rows(xr).Cells(1).Value = SplRdr("Itmcode")
                Me.DgItms.Rows(xr).Cells(2).Value = SplRdr("Itmname")
                Me.DgItms.Rows(xr).Cells(3).Value = SplRdr("Itmunttype")
                Me.DgItms.Rows(xr).Cells(4).Value = SplRdr("Itmotrbox")
                Me.DgItms.Rows(xr).Cells(5).Value = SplRdr("Itmsalerate")
                Me.DgItms.Rows(xr).Cells(6).Value = SplRdr("Itmid")
                xr += 1
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            SplCmd.Dispose()
            SplRdr.Close()
        End Try

    End Sub
    Private Sub xSaveNewItm()
        Try

            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            For Each Chkd As ListViewItem In Me.LstvewPlist.CheckedItems
                Dim xSplId As Integer = CInt(Chkd.SubItems(1).Text)
                For Each Dgr As DataGridViewRow In Me.DgItms.Rows
                    If Dgr.Cells(0).Value = True Then
                        SplCmd = New SqlCommand("finact_salepricelstmstr_Child_Addnew_insert", FinActConn)
                        SplCmd.CommandType = CommandType.StoredProcedure
                        SplCmd.Parameters.AddWithValue("@splid", CInt(xSplId))
                        SplCmd.Parameters.AddWithValue("@clditmid", CInt(Dgr.Cells(6).Value))
                        SplCmd.Parameters.AddWithValue("@cldrate", CDbl(Dgr.Cells(5).Value))
                        SplCmd.Parameters.AddWithValue("@splcld_mstrpack", CInt(Dgr.Cells(4).Value))
                        SplCmd.ExecuteNonQuery()
                    End If
                Next
            Next
            MsgBox("Current Selected Item(s) has/have been successfully added", MsgBoxStyle.Information, Me.Text)
            Me.DgItms.Rows.Clear()
            Me.LstvewPlist.Items.Clear()
            Me.CmbxUndrGrup.SelectedIndex = -1
            Me.Chkbxall.CheckState = CheckState.Checked
            Me.CmbxPlst.Focus()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            SplCmd.Dispose()
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Me.CmbxPlst.SelectedIndex = -1 Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            Dim Chk As Integer = 0
            For Each xDgr As DataGridViewRow In Me.DgItms.Rows
                If xDgr.Cells(0).Value = True Then
                    Chk += 1
                End If
            Next
            If Chk = 0 Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            If Me.LstvewPlist.CheckedItems.Count = 0 Then
                Me.LstvewPlist.Focus()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure to add selected item(s) to current price list?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                xSaveNewItm()
            Else
                Return
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgItms_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgItms.CellEndEdit
        Try
            If e.ColumnIndex = 5 Then
                Me.DgItms.CurrentRow.Cells(e.ColumnIndex).Value = FormatNumber(Me.DgItms.CurrentRow.Cells(e.ColumnIndex).Value, 2, , TriState.False)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgItms_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgItms.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgItms.Rows.Count '- 1
            If Cr_Row <> Me.DgItms.CurrentRow.Index Then
                If e.ColumnIndex = 5 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgItms.CurrentRow.Cells(5).ErrorText = "Invalid Input! Only Numbers are allowed"
                        MsgBox("Invalid Input", MsgBoxStyle.Critical, "Number only!!!")
                        e.Cancel = True
                    Else
                        Me.DgItms.CurrentRow.Cells(5).ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Chkbxall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkbxall.CheckedChanged
        Try
            If Me.Chkbxall.CheckState = CheckState.Checked Then
                Me.CmbxUndrGrup.Enabled = False
                Me.CmbxUndrGrup.SelectedIndex = -1
            Else
                Me.CmbxUndrGrup.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkbxall_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkbxall.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.Chkbxall.CheckState = CheckState.Checked Then
                    Me.BtnxOk.Focus()
                Else
                    Me.CmbxUndrGrup.Focus()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxUndrGrup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxUndrGrup.GotFocus
        Try
            Me.CmbxUndrGrup.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxUndrGrup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxUndrGrup.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxUndrGrup) = True Then
                Me.BtnxOk.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub BtnxOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnxOk.Click
        Try
            If Me.CmbxPlst.SelectedIndex = -1 Then
                Me.CmbxPlst.Focus()
                Exit Sub
            End If
            If Me.Chkbxall.CheckState = CheckState.Unchecked And Me.CmbxUndrGrup.SelectedIndex = -1 Then
                Me.CmbxUndrGrup.Focus()
                Exit Sub
            End If
            If Me.Chkbxall.CheckState = CheckState.Checked Then
                xFillDgItm(CInt(Me.CmbxPlst.SelectedValue), 1, 0)
            Else
                xFillDgItm(CInt(Me.CmbxPlst.SelectedValue), 2, CInt(Me.CmbxUndrGrup.SelectedValue))
            End If
            If Me.DgItms.RowCount = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            Fill_Lstbox_Dynamiclly_Where_In_Cond2()
            Me.DgItms.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fill_Lstbox_Dynamiclly_Where_In_Cond2()
        Dim xStr As String = "Finact_xTbl_xCond2_where_In_Select"
        Try
            SplCmd = New SqlCommand(xStr, FinActConn1)
            SplCmd.CommandType = CommandType.StoredProcedure
            SplCmd.Parameters.AddWithValue("@Fld1", "spl_id")
            SplCmd.Parameters.AddWithValue("@Fld2", "spl_name")
            SplCmd.Parameters.AddWithValue("@FldCond", "splitmtype")
            SplCmd.Parameters.AddWithValue("@FldCond1", "Spl_delstatus")
            SplCmd.Parameters.AddWithValue("@CondVal", "FAB")
            SplCmd.Parameters.AddWithValue("@CondVal1", "MACH")
            SplCmd.Parameters.AddWithValue("@CondVal2", 1)
            SplCmd.Parameters.AddWithValue("@TblName", "finact_salepricelstmstr")
            SplRdr = SplCmd.ExecuteReader
            Me.LstvewPlist.Items.Clear()
            Dim xPlst As ListViewItem
            While SplRdr.Read
                If SplRdr.IsDBNull(0) = False Then
                    xPlst = Me.LstvewPlist.Items.Add(Trim(SplRdr("spl_name")))
                    xPlst.SubItems.Add(SplRdr("spl_id"))
                End If
            End While
           
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SplCmd.Dispose()
            SplRdr.Close()

        End Try
    End Sub

    Private Sub CmbxPlst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxPlst.SelectedIndexChanged

    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmAcctSuspend

    Private Sub LstVewAcctSuspend_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles LstVewAcctSuspend.ItemChecked
        Try
            If e.Item.Checked = True Then
                If CInt(xCheckRecordExistence(CInt(Me.CmbxType.SelectedIndex), CInt(e.Item.SubItems(2).Text))) > 0 Then
                    e.Item.Checked = False
                Else
                    e.Item.SubItems(0).Text = "Deactivate"
                    e.Item.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xFillLstVew(ByVal xSelIndx As Integer)
        Try
            Dim xTblname As String = String.Empty
            Dim xFld1name As String = String.Empty
            Dim xFld2name As String = String.Empty
            Dim xFld3name As String = String.Empty
            Dim xCondFldName As String = String.Empty
            Dim xCondVal As String = String.Empty

            Select Case xSelIndx
                Case 0
                    xTblname = "FinActSplrMstr"
                    xFld1name = "SplrDelStatus"
                    xFld2name = "SplrName"
                    xFld3name = "Splrid"
                    xCondFldName = "SplrType"
                    xCondVal = "Customer"
                Case 1
                    xTblname = "FinActDept"
                    xFld1name = "DeptDelStatus"
                    xFld2name = "DeptName"
                    xFld3name = "Deptid"
                    xCondFldName = "DeptType"
                    xCondVal = "DEPT"
                Case 2
                    xTblname = "FinActDesi"
                    xFld1name = "DesiDelStatus"
                    xFld2name = "DesiName"
                    xFld3name = "Desiid"
                    xCondFldName = "DesiType"
                    xCondVal = "Desi"
                Case 3
                    xTblname = "FinActgrupName"
                    xFld1name = "CoDelStatus"
                    xFld2name = "CogrupNam"
                    xFld3name = "Cogrpid"
                    xCondFldName = "CoPrmType"
                    xCondVal = "Actt"
                Case 4
                    xTblname = "FinActSplrMstr"
                    xFld1name = "SplrDelStatus"
                    xFld2name = "SplrName"
                    xFld3name = "Splrid"
                    xCondFldName = "SplrType"
                    xCondVal = "Vendor"
                Case 5
                    xTblname = "FinActSalePurCatgry"
                    xFld1name = "SpCatDelStatus"
                    xFld2name = "SpCatName"
                    xFld3name = "SpCatid"
                    xCondFldName = "None"
                    xCondVal = "0"
            End Select
            Fill_xLstVew_Dynamic_xSelct_3Fld_Where_1_Cond_isOptional(xFld1name, xFld2name, xFld3name, xCondFldName, xCondVal, xTblname, Me.LstVewAcctSuspend)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub CmbxType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxType.GotFocus
        Try
            Me.LstVewAcctSuspend.Items.Clear()
            Me.CmbxType.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxType.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxType_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxType.Leave
        Try
            If CheckBlank_IndxCmbx(Me.CmbxType) = True Then
                xFillLstVew(Me.CmbxType.SelectedIndex)
                Me.LstVewAcctSuspend.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Me.CmbxType.SelectedIndex = -1 Then
                Me.CmbxType.Focus()
                Exit Sub
            End If
            If Not Me.LstVewAcctSuspend.Items.Count > 0 Then
                Me.CmbxType.Focus()
                Exit Sub
            End If
            If MessageBox.Show("Are you sure to update current session?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                xUpdateFromLstVew(Me.CmbxType.SelectedIndex)
            Else
                Return
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xUpdateFromLstVew(ByVal xSelIndx As Integer)
        Try
            Select Case xSelIndx
                Case 0
                    For Each xLstItm As ListViewItem In Me.LstVewAcctSuspend.Items
                        If xLstItm.Checked = True Then
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("SplrDelStatus", "SplrDelUsrid", "SplrDelDt", CInt(0), CInt(Current_UsrId), Now, "splrid", CInt(xLstItm.SubItems(2).Text), "FinactSplrMstr")
                        Else
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("SplrDelStatus", "SplrDelUsrid", "SplrDelDt", CInt(1), CInt(Current_UsrId), Now, "splrid", CInt(xLstItm.SubItems(2).Text), "FinactSplrMstr")
                        End If
                    Next
                Case 1
                    For Each xLstItm As ListViewItem In Me.LstVewAcctSuspend.Items
                        If xLstItm.Checked = True Then
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("DeptDelStatus", "DeptDelUsrid", "DeptDelDt", CInt(0), CInt(Current_UsrId), Now, "Deptid", CInt(xLstItm.SubItems(2).Text), "FinactDept")
                        Else
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("DeptDelStatus", "DeptDelUsrid", "DeptDelDt", CInt(1), CInt(Current_UsrId), Now, "Deptid", CInt(xLstItm.SubItems(2).Text), "FinactDept")
                        End If
                    Next
                Case 2
                    For Each xLstItm As ListViewItem In Me.LstVewAcctSuspend.Items
                        If xLstItm.Checked = True Then
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("DesiDelStatus", "DesiDelUsrid", "DesiDelDt", CInt(0), CInt(Current_UsrId), Now, "Desiid", CInt(xLstItm.SubItems(2).Text), "FinactDesi")
                        Else
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("DesiDelStatus", "DesiDelUsrid", "DesiDelDt", CInt(1), CInt(Current_UsrId), Now, "Desiid", CInt(xLstItm.SubItems(2).Text), "FinactDesi")
                        End If
                    Next
                Case 3
                    For Each xLstItm As ListViewItem In Me.LstVewAcctSuspend.Items
                        If xLstItm.Checked = True Then
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("coDelStatus", "coDelUsrid", "coDelDt", CInt(0), CInt(Current_UsrId), Now, "cogrpid", CInt(xLstItm.SubItems(2).Text), "FinactGrupName")
                        Else
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("coDelStatus", "coDelUsrid", "coDelDt", CInt(1), CInt(Current_UsrId), Now, "cogrpid", CInt(xLstItm.SubItems(2).Text), "FinactGrupName")
                        End If
                    Next

                Case 4
                    For Each xLstItm As ListViewItem In Me.LstVewAcctSuspend.Items
                        If xLstItm.Checked = True Then
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("SplrDelStatus", "SplrDelUsrid", "SplrDelDt", CInt(0), CInt(Current_UsrId), Now, "splrid", CInt(xLstItm.SubItems(2).Text), "FinactSplrMstr")
                        Else
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("SplrDelStatus", "SplrDelUsrid", "SplrDelDt", CInt(1), CInt(Current_UsrId), Now, "splrid", CInt(xLstItm.SubItems(2).Text), "FinactSplrMstr")
                        End If

                    Next
                Case 5
                    For Each xLstItm As ListViewItem In Me.LstVewAcctSuspend.Items
                        If xLstItm.Checked = True Then
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("SpCatDelStatus", "SpCatDelUsrid", "SpCatDelDt", CInt(0), CInt(Current_UsrId), Now, "SpCatid", CInt(xLstItm.SubItems(2).Text), "FinactSalePurCatgry")
                        Else
                            xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond("SpCatDelStatus", "SpCatDelUsrid", "SpCatDelDt", CInt(1), CInt(Current_UsrId), Now, "SpCatid", CInt(xLstItm.SubItems(2).Text), "FinactSalePurCatgry")
                        End If
                    Next
            End Select
            MsgBox("Current session has been successfully updated.", MsgBoxStyle.Information, Me.Text)
            Me.LstVewAcctSuspend.Items.Clear()
            Me.CmbxType.SelectedIndex = -1
            Me.CmbxType.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmAcctSuspend_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 10
            Me.CmbxType.Focus()

        Catch ex As Exception

        End Try
    End Sub
    Private Function xCheckRecordExistence(ByVal xIndx As Integer, ByVal xCondVal As Integer) As Integer
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_Utility_ChkRecordExistence_SELECT", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@Indx", CInt(xIndx))
            FinActCmd.Parameters.AddWithValue("@CondId", CInt(xCondVal))
            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                Dim xx As Integer = FinActRdr(0)
                Return FinActRdr(0)
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
End Class
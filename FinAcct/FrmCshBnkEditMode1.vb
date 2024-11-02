Imports System.Data
Imports System.Data.SqlClient
Imports System.Math
Public Class FrmCshBnkEditMode1
    Dim xActCont As Integer = 0
    Private Sub CmbxSr1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSr1.GotFocus
        Try
            Me.ChkBxAll1.CheckState = CheckState.Checked
            Me.AutoScroll = False
            Me.Size = New System.Drawing.Point(499, 90)
            Me.CmbxSr1.DroppedDown = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSr1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSr1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxSr1_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSr1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSr1.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxSr1) = True Then
                Dim xxFlg As Boolean = False
                If Me.CmbxSr1.SelectedIndex = 1 Then
                    xActCont = xDynamic_COUNT_xAnItem_xInA_Table_1cond("splrid", "Splrtype", "Bank", "finactsplrmstr")
                    If xActCont > 1 Then
                        Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRTYPE", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), "Bank", Me.CmbxSr2)
                        xxFlg = True
                    End If
                ElseIf Me.CmbxSr1.SelectedIndex = 2 Then
                    xActCont = xDynamic_COUNT_xAnItem_xInA_Table_1cond("splrid", "Splrtype", "Cash Book", "finactsplrmstr")
                    If xActCont > 1 Then
                        Fill_Combobox_where_cond("SPLRID", "SPLRNAME", "SPLRTYPE", "FINACTSPLRMSTR", "SPLRDELSTATUS", CInt(1), "Cash Book", Me.CmbxSr2)
                        xxFlg = True
                    End If
                End If
                If xxFlg = True Then
                    Me.Size = New System.Drawing.Point(950, 117)
                    Me.ChkBxAll1.Visible = True
                    Me.CmbxSr2.Visible = True
                    Me.CmbxSr2.Enabled = False
                    Me.CmbxSr2.SelectedIndex = -1
                    Me.ChkBxAll1.Enabled = True
                    Me.ChkBxAll1.Focus()
                    Exit Sub
                Else
                    Me.ChkBxAll1.Enabled = False
                    Me.Size = New System.Drawing.Point(499, 117)
                    Me.BtnOk.Focus()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmCshBnkEditMode1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("TRUNCATE TABLE FinAct_TEMP_CBook_EdtMode", FinActConn)
            FinActCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
        End Try
    End Sub
    Private Sub FrmCshBnkEditMode1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 10
            Me.CmbxSr1.SelectedIndex = 0
            Me.Size = New System.Drawing.Point(499, 90)
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.Dtpfrom, Me.DtpTo)
            xFillxCshBnkTABLE()
            Me.Dtpfrom.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkBxAll1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBxAll1.CheckedChanged
        Try
            Me.AutoScroll = False
            If Me.ChkBxAll1.CheckState = CheckState.Checked Then
                Me.CmbxSr2.SelectedIndex = -1
                Me.CmbxSr2.Enabled = False
            Else
                Me.CmbxSr2.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If xActCont > 1 Then
                If Me.ChkBxAll1.CheckState = CheckState.Unchecked Then
                    If Me.CmbxSr2.SelectedIndex = -1 Then
                        MsgBox("Invalid Input!", MsgBoxStyle.Critical)
                        Me.CmbxSr2.Focus()
                        Exit Sub
                    End If
                End If
            End If
            Dim xxFlg As Boolean = False
            Select Case Me.CmbxSr1.SelectedIndex
                Case 0
                    xxFlg = False
                    Me.ChkBxAll1.Visible = False
                    Me.CmbxSr2.Visible = False
                Case 1
                    If xActCont > 1 Then
                        If Me.ChkBxAll1.CheckState = CheckState.Checked Then
                            xxFlg = False
                        Else
                            xxFlg = True
                        End If
                        Me.ChkBxAll1.Visible = True
                        Me.CmbxSr2.Visible = True
                    Else
                        xxFlg = False
                        Me.ChkBxAll1.Visible = False
                        Me.CmbxSr2.Visible = False
                    End If
                Case 2
                    If xActCont > 1 Then
                        If Me.ChkBxAll1.CheckState = CheckState.Checked Then
                            xxFlg = False
                        Else
                            xxFlg = True
                        End If
                        Me.ChkBxAll1.Visible = True
                        Me.CmbxSr2.Visible = True
                    Else
                        xxFlg = False
                        Me.ChkBxAll1.Visible = False
                        Me.CmbxSr2.Visible = False
                    End If
            End Select
            If xxFlg = False Then
                xFillxCshBnkLSTVEW(CInt(Me.CmbxSr1.SelectedIndex), 0)
            Else
                xFillxCshBnkLSTVEW(CInt(3), CInt(Me.CmbxSr2.SelectedValue))
            End If
            Me.Size = New System.Drawing.Point(950, Screen.PrimaryScreen.WorkingArea.Height - 80)
            Me.AutoScroll = True
            Me.LstVewCB.Height = Me.Height - 145
            Me.Panel4.Top = Me.Height - 71
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFillxCshBnkTABLE()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_CshBnk_EdtMode_FillTalbe", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@Sel_Dt1", Me.Dtpfrom.Value.Date)
            FinActCmd.Parameters.AddWithValue("@Sel_Dt2", Me.DtpTo.Value.Date)
            FinActCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
        End Try
    End Sub

    Private Sub xFillxCshBnkLSTVEW(ByVal xTMODE As Integer, ByVal xBOKID As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_CshBnk_EdtMode_SELECT", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@Sel_Dt1", Me.Dtpfrom.Value.Date)
            FinActCmd.Parameters.AddWithValue("@Sel_Dt2", Me.DtpTo.Value.Date)
            FinActCmd.Parameters.AddWithValue("@xTMODE", CInt(xTMODE))
            FinActCmd.Parameters.AddWithValue("@xBOKID", CInt(xBOKID))
            FinActRdr = FinActCmd.ExecuteReader
            Me.LstVewCB.Items.Clear()
            Dim xlsti As ListViewItem
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    xlsti = Me.LstVewCB.Items.Add(Format(FinActRdr("COLtdate"), "dd/MM/yyyy"))
                    xlsti.SubItems.Add(Trim(FinActRdr("COLdetails")))
                    xlsti.SubItems.Add(Trim(FinActRdr("COLName")))
                    xlsti.SubItems.Add(FormatNumber(FinActRdr("COLdr"), 2))
                    xlsti.SubItems.Add(FormatNumber(FinActRdr("COLcr"), 2))
                    xlsti.SubItems.Add(CInt(FinActRdr("COL1id")))
                    xlsti.SubItems.Add(FinActRdr("ColSpltType"))
                    xlsti.SubItems.Add(CInt(FinActRdr("ColVno")))
                    Dim xMode As String = Trim(FinActRdr("COLtmode"))
                    Dim xType As String = Trim(FinActRdr("coltype"))
                    If xMode.Trim = "CshBnk" Or xMode.Trim = "CshCsh" Or xMode.Trim = "BnkCsh" Or xMode.Trim = "BnkBnk" Then
                        xlsti.SubItems.Add("Contra")
                    ElseIf xMode.Trim = "Csh" Or xMode.Trim = "Bnk" And xType.Trim = "Debit" Then
                        xlsti.SubItems.Add("Payment")
                    ElseIf xMode.Trim = "Csh" Or xMode.Trim = "Bnk" And xType.Trim = "Credit" Then
                        xlsti.SubItems.Add("Receipt")
                    End If
                    xlsti.SubItems.Add(Trim(FinActRdr("ColPartY")))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Sub

    Private Sub BtnEdt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdt.Click
        Try
            If Me.LstVewCB.SelectedItems.Count > 0 Then
                If MessageBox.Show("Are you sure to delete selected record(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    For Each xlll As ListViewItem In Me.LstVewCB.SelectedItems
                        xDel_A_Rec_FromTable_dynamicly("FinactCshBnk", "Cbtranvno", xlll.SubItems(7).Text)
                    Next
                    xFillxCshBnkTABLE()
                    MsgBox("Selected record has been successfully deleted.", MsgBoxStyle.Information)
                    Me.BtnOk_Click(sender, e)
                Else
                    Return
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewCB_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewCB.DoubleClick
        Try
            If Me.LstVewCB.SelectedItems.Count = 1 Then
                xCBedtmode_RecId = CInt(Me.LstVewCB.SelectedItems(0).SubItems(5).Text)
                xCBedtmode_splttype = Me.LstVewCB.SelectedItems(0).SubItems(6).Text
                xCBedtmode_Vno = CInt(Me.LstVewCB.SelectedItems(0).SubItems(7).Text)
                xCBedtmode_Mode = Trim(Me.LstVewCB.SelectedItems(0).SubItems(8).Text)
                Dim xFrmCBedtmode As New FrmCshBnkEditMode
                xFrmCBedtmode.ShowInTaskbar = False
                xFrmCBedtmode.ShowDialog()
            Else
                MsgBox("Invalid Input!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub


    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            Me.LstVewCB_DoubleClick(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub All_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpfrom.KeyDown, DtpTo.KeyDown, ChkBxAll1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSr2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSr2.GotFocus
        Try
            Me.AutoScroll = False
            Me.CmbxSr2.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSr2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSr2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxSr2_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSr2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSr2.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxSr2) = True Then
                Me.BtnOk.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Try
            xFillxCshBnkTABLE()
            Me.BtnOk_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewCB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewCB.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.LstVewCB_DoubleClick(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ChbxPDC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChbxPDC.CheckedChanged
        Try
            If Me.ChbxPDC.CheckState = CheckState.Checked Then
                xFillxCshBnkTABLE()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
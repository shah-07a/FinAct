Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmCrRptStokProdSemiProdSemiDetailed
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd1 As SqlCommand
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CrRptStokProdSemi As New CrRptStockRegProdSemiDetailed

    Private Sub FrmRptGenLdgr_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cmd = New SqlCommand("Delete from FINACT_TEMP_StokIssueDetails", FinActConn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            ' FrmMainMdi.MenuItem261.Enabled = True
        End Try
    End Sub

    Private Sub FrmRptGenLdgr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, 102)
            If Cl_TimeIndia = True Then
                Me.ChkRptLdgr.Checked = False
            Else
                Me.ChkRptLdgr.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpLdgr1, Me.DtpLdgr2)
            FillTempTable_StokReg()
            Fill_CMBX_DYNAMIC_WITH_INNERJOIN_DISTINCT_SELECT("ITMDELSTATUS", CInt(1), "ITMID", "ITMNAME", "FINACTITMMSTR", "ITMID", "xITMID", "FINACT_TEMP_STOKISSUEDETAILS", Me.CmbxLdgr)

            Me.DtpLdgr1.Focus()
        Catch ex As Exception

        End Try


    End Sub
    Private Sub FillTempTable_StokReg()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Finact_Rpt_StokDetails_Production_FillTable", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@sDt", FinStartDt)
            'cmd.Parameters.AddWithValue("@F_Dt", Me.DtpLdgr1.Value.Date)
            'cmd.Parameters.AddWithValue("@T_Dt", Me.DtpLdgr2.Value.Date)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- FillTempTable_Ldgr, Line No. 38 ")
        Finally
            cmd.Dispose()

        End Try

    End Sub

    Private Sub BtnRptVewLdgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click
        Try
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_ProdSemi()
            Handle_P_Bar(Me)
        Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, Screen.PrimaryScreen.WorkingArea.Height - 50)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_ProdSemi()
        Try
            '===================
            Dim Stype, Sbtype As Integer
            If Me.ChkLdgrAll.CheckState = CheckState.Checked And Me.ChkOpnBal.CheckState = CheckState.Checked Then
                Stype = 1 'ALL ITEM WITH OPENING BALANCE
            ElseIf Me.ChkLdgrAll.CheckState = CheckState.Checked And Me.ChkOpnBal.CheckState = CheckState.Unchecked Then
                Stype = 2 ' ALL ITEM WITHOUT OPENING BALANCE
            ElseIf Me.ChkLdgrAll.CheckState = CheckState.Unchecked And Me.ChkOpnBal.CheckState = CheckState.Checked Then
                Stype = 3 'SELECTED ITEM WITH OPENING BALANCE
            ElseIf Me.ChkLdgrAll.CheckState = CheckState.Unchecked And Me.ChkOpnBal.CheckState = CheckState.Unchecked Then
                Stype = 4 'SELECTED ITEM WITHOUT OPENING BALANCE
            Else
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
            End If

            Sbtype = CInt(0)
            Dim Selact As Integer = CInt(Me.CmbxLdgr.SelectedValue)
            Fetch1_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_StokIssueDetails_Prod_Semi_OpnBal_with_without_Select", Me.CrRptStokProdSemi, Me.CrRptVewLdgr, Me.DtpLdgr1.Value, Me.DtpLdgr2.Value, Selact, Stype, Sbtype)

            If Me.ChkRptLdgr.Checked = True Then
                CoprofileParamsRest_Adrs(Me.CrRptStokProdSemi, Me.CrRptVewLdgr, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptStokProdSemi, Me.CrRptVewLdgr, True, False, Me.DtpLdgr1, Me.DtpLdgr2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_Ldgr, Line No. 234 ")
        End Try
    End Sub

    Private Sub ChkRptLdgr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptLdgr.CheckedChanged
        Try
            Me.BtnRptVewLdgr_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpLdgr1.KeyDown, ChkLdgrAll.KeyDown _
     , ChkRptLdgr.KeyDown, DtpLdgr2.KeyDown, ChkOpnBal.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxLdgr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxLdgr.GotFocus
        Try
            Me.CmbxLdgr.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxLdgr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxLdgr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxLdgr_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxLdgr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxLdgr.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxLdgr) = True Then
                Me.BtnRptVewLdgr.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DtpLdgr1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpLdgr1.Leave
        Try
            If Me.ChkLdgrAll.CheckState = CheckState.Checked Then
                Me.CmbxLdgr.SelectedIndex = -1
            End If
        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub ChkLdgrAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLdgrAll.CheckedChanged
        Try
            If Me.ChkLdgrAll.CheckState = CheckState.Checked Then
                Me.CmbxLdgr.Enabled = False
            Else
                Me.CmbxLdgr.Enabled = True
            End If
            Me.CmbxLdgr.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub
End Class
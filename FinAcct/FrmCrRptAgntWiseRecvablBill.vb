Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmCrRptAgntWiseRecvablBill
    Dim RSBCMD As SqlCommand
    Dim RSBRDR As SqlDataReader
    Dim xCrRpt As New CrRptAgentWiseRecvableBill

    Private Sub FrmCrRptRecvablBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 20, 110)
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpFrom, Me.DtpTo)
            xFilltable()
            xFillCmbxHavingbal()
            Me.Cmbxrange.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFilltable()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            RSBCMD = New SqlCommand("Finact_SALEENTRY_PENDINGBILLRECVABLES_Select", FinActConn)
            RSBCMD.CommandType = CommandType.StoredProcedure
            RSBCMD.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            RSBCMD.Dispose()
        End Try
    End Sub

    Private Sub CHKBXALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKBXALL.CheckedChanged
        Try
            If Me.CHKBXALL.CheckState = CheckState.Checked Then
                Me.Cmbxrange.Enabled = False
                Me.Cmbxrange.SelectedIndex = -1
            Else
                Me.Cmbxrange.Enabled = True
                Me.Cmbxrange.Focus()
            End If
            Me.CrRptVewOverDueBills.ReportSource = Nothing
            Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 20, 113)
        Catch ex As Exception

        End Try
    End Sub
  

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If Me.CHKBXALL.CheckState = CheckState.Unchecked And Me.Cmbxrange.SelectedIndex = -1 Then Exit Sub
            Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 20, 113)
            SelRecd_Fromtable_OvrDueBills()
            Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 20, Screen.PrimaryScreen.WorkingArea.Height - 50)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFillCmbxHavingbal()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            dtaset = New DataSet
            dtaset.Tables.Clear()
            RSBCMD = New SqlCommand("FINACT_Rpt_TEMP_SALEBILL_OVERDUE_DISTINCT_AGNT_FILLCMBX_Select", FinActConn)
            RSBCMD.CommandType = CommandType.StoredProcedure
            SqlAdptr = New SqlDataAdapter(RSBCMD)
            dtaset = New DataSet(RSBCMD.CommandText)
            SqlAdptr.Fill(dtaset)
            Me.Cmbxrange.DataSource = dtaset.Tables(0)
            Me.Cmbxrange.ValueMember = "Splrid"
            Me.Cmbxrange.DisplayMember = "SplrName"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            RSBCMD.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub

    Private Sub Cmbxrange_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxrange.GotFocus
        Try
            Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 20, 113)
            Me.CrRptVewOverDueBills.ReportSource = Nothing
            Me.Cmbxrange.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxrange_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxrange.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Cmbxrange_Leave(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxrange_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxrange.Leave
        Try
            If CheckBlank_Cmbx(Me.Cmbxrange) = True Then
                Me.BtnOk.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.GotFocus
        Try
            Me.BtnOk.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Leave
        Try
            Me.BtnOk.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_OvrDueBills()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            RSBCMD = New SqlCommand("FINACT_Rpt_TEMP_SALEBILL_OD_AgntWise_Select", FinActConn)
            RSBCMD.CommandType = CommandType.StoredProcedure
            RSBCMD.Parameters.AddWithValue("@DtF", Me.DtpFrom.Value.Date)
            RSBCMD.Parameters.AddWithValue("@DtT", Me.DtpTo.Value.Date)
            If Me.CHKBXALL.CheckState = CheckState.Checked Then
                RSBCMD.Parameters.AddWithValue("@Optn", 0)
                RSBCMD.Parameters.AddWithValue("@Pid", 0)
            Else
                RSBCMD.Parameters.AddWithValue("@Optn", 1)
                RSBCMD.Parameters.AddWithValue("@Pid", Me.Cmbxrange.SelectedValue)
            End If

            FinActDset = New DataSet(RSBCMD.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(RSBCMD)
            FinActSqlAdptr.Fill(FinActDset)
            xCrRpt.SetDataSource(FinActDset.Tables(0))
            CoprofileParamsRest_Adrs(Me.xCrRpt, Me.CrRptVewOverDueBills, True, True, Me.DtpFrom, Me.DtpTo)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.CrRptVewOverDueBills.ReportSource = xCrRpt
            RSBCMD.Dispose()
            FinActDset.Clear()
            FinActSqlAdptr.Dispose()

        End Try
    End Sub
End Class
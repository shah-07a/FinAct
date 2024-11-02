Imports System.Data.SqlClient
Public Class FrmRptCashBook
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim rdr As SqlDataReader
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CrRptCbook As New CrRptCashBook

    Private Sub FrmRptCashBook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            cmd = New SqlCommand("Delete from FINACT_TEMP_cbook", FinActConn)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            ''FrmMainMdi.MenuItem74.Enabled = True
        End Try
    End Sub

    Private Sub FrmRptCashBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 50, 89)
            Me.Top = 0
            Me.Left = 0
            If Cl_TimeIndia = True Then
                Me.ChkRptcbook.Checked = False
            Else
                Me.ChkRptcbook.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpCb1, Me.DtpCb2)
            FillTempTable_Cbook()
            Me.ChkRptcbook.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillTempTable_Cbook()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Finact_Rpt_CashBook_FillTalbe", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Sel_Dt1", Me.DtpCb1.Value.Date)
            cmd.Parameters.AddWithValue("@Sel_Dt2", Me.DtpCb2.Value.Date)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- FillTempTable_Cbook, Line No. 31 ")
        Finally
            cmd.Dispose()

        End Try
    End Sub

    Private Sub BtnRptVewCb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewCb.Click

        Try
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_cb()
            ''FrmMainMdi.MenuItem74.Enabled = False
            Handle_P_Bar(Me)
          Me.Size=New Point(Screen.PrimaryScreen.WorkingArea.Width-50,Screen.PrimaryScreen.WorkingArea.Height-80)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try

    End Sub
    Private Sub SelRecd_Fromtable_cb()
        Try
            Fetch_Stock_Record_SelectedDateRange("Finact_Rpt_CashBook_Select", Me.CrRptCbook, Me.CrRptVewCBook, Me.DtpCb1.Value.Date, Me.DtpCb2.Value.Date)
            If Me.ChkRptcbook.Checked = True Then
                CoprofileParamsRest_Adrs(Me.CrRptCbook, Me.CrRptVewCBook, True, True, Me.DtpCb1, Me.DtpCb2)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptCbook, Me.CrRptVewCBook, True, False, Me.DtpCb1, Me.DtpCb2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_cb, Line No.211 ")
        End Try
    End Sub

    Private Sub ChkRptcbook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptcbook.CheckedChanged
        Try
            Me.BtnRptVewCb_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpCb1.KeyDown, ChkRptcbook.KeyDown _
    , DtpCb2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
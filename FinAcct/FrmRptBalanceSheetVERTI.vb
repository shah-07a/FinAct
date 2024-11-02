Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmRptBalanceSheetVERTI

    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd1 As SqlCommand
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim Dta_tbl As DataTable
    Dim Dta_Ro As DataRow
    Dim xDset As DataSet
    Dim xTexp As Double = 0
    Dim xTinc As Double = 0
    Dim xInInc As Double = 0
    Dim xInExp As Double = 0
    Dim xGp As Double = 0
    Dim xClstok As Double = 0
    Dim xSretd As Double = 0
    Dim xPretd As Double = 0
    Dim xAdptr As SqlDataAdapter
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim CrRPtBal As New CrRptBalSheetVerti

    Private Sub FrmRptBalanceSheet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            cmd = New SqlCommand("Delete from FINACT_TEMP_Trial", FinActConn)
            'cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
        End Try
        cmd = New SqlCommand("Delete from FINACT_TEMP_balancesheet1", FinActConn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing

        End Try
    End Sub
    Private Sub FrmRptBalanceSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 50, 100)
            Me.Top = 0
            Me.Left = 10
            If Cl_TimeIndia = True Then
                Me.ChkRptLdgr.Checked = False
            Else
                Me.ChkRptLdgr.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpLdgr1, Me.DtpLdgr2)

            Dim StartDt As Date
            Date.TryParse(FinStartDt.Date, CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, StartDt)
            Me.DtpLdgr1.Value = StartDt.Date 'Format(StartDt.Date, "MM/dd/yyyy")
            FillTempTable_Trial_Bal()

            Me.DtpLdgr1.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File Name:- " & Me.Name & " ,Private Sub FrmRptTrial_Load, Line No.33")
        End Try

    End Sub
    Private Sub FillTempTable_Trial_Bal()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Finact_Rpt_TrialBalance_FillTalbe", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@F_Dt", Me.DtpLdgr1.Value.Date)
            cmd.Parameters.AddWithValue("@T_Dt", Me.DtpLdgr2.Value.Date)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File Name:-  " & Me.Name & " ,Private Sub FillTempTable_Trial, Line No 55")
        Finally
            cmd = Nothing
        End Try




    End Sub
    Private Sub SelRecd_Fromtable_BalanSheet()
        Try
            Dim xGpValue As Double = 0
            Dim xCstok As Double = 0
            If Me.rbd.Checked = True Then
                xGpValue = Me.Txtvalue.Text
                xCstok = 0
            ElseIf Me.rbg.Checked = True Then
                xCstok = Me.Txtvalue.Text
                xGpValue = 0
            End If
            Fetch_Stock_Record_SelectedGp("FIANCT_Rpt_BalanSheet_GoupwiseSUM_FILL", CrRPtBal, Me.CrRptVewBalSheet, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, xGpValue, xCstok)

            If Me.ChkRptLdgr.Checked = True Then
                CoprofileParamsRest_Adrs(CrRPtBal, Me.CrRptVewBalSheet, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
            Else
                CoprofileParamsRest_Adrs(CrRPtBal, Me.CrRptVewBalSheet, True, False, Me.DtpLdgr1, Me.DtpLdgr2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_Ldgr, Line No. 234 ")
        End Try
    End Sub
    Private Sub Fetch_Stock_Record_SelectedGp(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object, ByVal SelDt1 As Date, ByVal SelDt2 As Date, ByVal xGprate As Double, ByVal xCstok As Double)
        Try  '
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand(xStr, FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SelDt1", SelDt1)
            cmd.Parameters.AddWithValue("@SelDt2", SelDt2)
            cmd.Parameters.AddWithValue("@xClosingStock", xCstok)
            cmd.Parameters.AddWithValue("@xGprate", xGprate)
            xDset = New DataSet(cmd.CommandText)
            xAdptr = New SqlDataAdapter(cmd)
            xAdptr.Fill(xDset)
            xCrRpt.SetDataSource(xDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            CrRptVew.ReportSource = xCrRpt
            cmd = Nothing
        End Try
    End Sub

    Private Sub BtnRptVewLdgr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click
        Try

            If Not Me.Txtvalue.Text > 0 Then
                MsgBox("Invalid Input! Enter a valid value to calculate gross profit befor proceeding further", MsgBoxStyle.Critical, "GP Rate or C.Stock Value!!!!")
                Me.Txtvalue.BackColor = Color.Cyan
                Me.Txtvalue.Focus()
                Me.Txtvalue.SelectAll()
                Exit Sub
            Else
                Me.Txtvalue.BackColor = Color.White
            End If
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_BalanSheet()

            Handle_P_Bar(Me)
            Me.Height = 0
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 50, Screen.PrimaryScreen.WorkingArea.Height - 80)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub DtpLdgr1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpLdgr1.ValueChanged
        Try
            Date.TryParse(Me.DtpLdgr1.Value.Date, CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
            Me.DtpLdgr2.MinDate = (CurrDate.Date)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkRptLdgr_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkRptLdgr.CheckedChanged
        Try
            If Me.Txtvalue.Text > 0 Then
                Me.BtnRptVewLdgr_Click(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub rbd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbd.CheckedChanged, rbg.CheckedChanged
        Try
            If rbd.Checked = True Then
                Me.lblvalue.Text = "Rate Of Gross Profit"
            ElseIf Me.rbg.Checked = True Then
                Me.lblvalue.Text = "Value Of Closing Stock"
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Txtvalue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtvalue.GotFocus
        Try
            Me.Txtvalue.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Handle_KeyDownForall(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpLdgr1.KeyDown, _
    DtpLdgr2.KeyDown, rbd.KeyDown, rbg.KeyDown, Txtvalue.KeyDown, ChkRptLdgr.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtvalue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtvalue.Leave
        Try
            If Trim(Me.Txtvalue.Text) <> "" Then
                If IsNumeric(Txtvalue.Text) = False Then
                    MsgBox("Invalid Input! Only valid numerics are allowed", MsgBoxStyle.Critical, "Number only")
                    Me.Txtvalue.Focus()
                    Me.Txtvalue.SelectAll()
                Else
                    Me.Txtvalue.Text = FormatNumber(Me.Txtvalue.Text, 2)
                    Me.ChkRptLdgr.Focus()
                End If
            Else
                Me.Txtvalue.Text = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

   
End Class
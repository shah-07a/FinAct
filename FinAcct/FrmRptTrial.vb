Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class FrmRptTrial
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd1 As SqlCommand
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim Dta_tbl As DataTable
    Dim Dta_Ro As DataRow
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim CrRptTrla As CrRptTrialDetailed
    Dim CrRptTrlb As New CrRptTrial
    Dim CrRptTrlc As New CrRptTrialSummrized
    Dim Flag1 As Boolean = False
    Dim xDEBIT As Double = 0
    Dim xCREDIT As Double = 0
    

    Private Sub FrmRptTrial_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Delete from FINACT_TEMP_Trialbalance", FinActConn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            ''FrmMainMdi.MenuItem90.Enabled = True
        End Try

    End Sub

    Private Sub FrmRptTrial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 50, 102)
            Me.Top = 0
            Me.Left = 0
            If Cl_TimeIndia = True Then
                Me.ChkRptLdgr.Checked = False
            Else
                Me.ChkRptLdgr.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpLdgr1, Me.DtpLdgr2)
            'Dim StartDt As Date
            'Date.TryParse(FinStartDt.Date, CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, StartDt)
            'Me.DtpLdgr1.Value = Format(StartDt.Date, "MM/dd/yyyy")

            FillTempTable_Trial()
            ''FrmMainMdi.MenuItem90.Enabled = False
            Flag1 = False
            Me.DtpLdgr1.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File Name:- " & Me.Name & " ,Private Sub FrmRptTrial_Load, Line No.33")
        End Try
    End Sub
    Private Sub FillTempTable_Trial()
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

        End Try


    End Sub
    Private Sub SelRecd_Fromtable_TrialBalance()
        Try
            Dim CrRPtTrl As Object = Nothing
            ''CrRPtTrl = New CrRptTrialDetailed
            '' CrRPtTrl = New CrRptTrailBalanceWithOpeningBal
            If Me.rbd.Checked = True Then
                ''CrRPtTrl = New CrRptTrialDetailed
                CrRPtTrl = New CrRptTrailBalanceWithOpeningBal
                Fetch_Stock_Record_SelectedDateRange("usp_Finact_Rpt_TrialBalanceWithOpening_Select", CrRPtTrl, Me.CrRptVewTrialBal, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date)
            ElseIf Me.rbg.Checked = True Then
                '' CrRPtTrl = New CrRptTrial
                CrRPtTrl = New CrRptTrialBalanceGroupWise
                Fetch_Stock_Record_SelectedDateRange("usp_Finact_Rpt_TrialBalanceGroupByGroupName_Select", CrRPtTrl, Me.CrRptVewTrialBal, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date)
            ElseIf Me.rbs.Checked = True Then
                '' CrRPtTrl = New CrRptTrialSummrized
                CrRPtTrl = New CrRptTrialBalanceSummarised
                Fetch_Stock_Record_SelectedDateRange("usp_Finact_Rpt_TrialBalanceGroupByGroupName_Select", CrRPtTrl, Me.CrRptVewTrialBal, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date)
            End If


            '' Fetch_Stock_Record_SelectedDateRange("Finact_Rpt_TrialBalance_Select", CrRPtTrl, Me.CrRptVewTrialBal, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date)


            SetExtraPramtoCrRpt(CrRPtTrl)
            If Me.ChkRptLdgr.Checked = True Then
                CoprofileParamsRest_Adrs(CrRPtTrl, Me.CrRptVewTrialBal, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
            Else
                CoprofileParamsRest_Adrs(CrRPtTrl, Me.CrRptVewTrialBal, True, False, Me.DtpLdgr1, Me.DtpLdgr2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_Ldgr, Line No. 234 ")
        End Try
    End Sub


    Private Sub BtnRptVewLdgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click

        Try
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_TrialBalance()
            ''FrmMainMdi.MenuItem90.Enabled = False
            Handle_P_Bar(Me)
        Me.Size=New Point(Screen.PrimaryScreen.WorkingArea.Width-50,Screen.PrimaryScreen.WorkingArea.Height-80)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ChkRptLdgr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkRptLdgr.GotFocus
        Try
            Flag1 = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpLdgr1.KeyDown, ChkRptLdgr.KeyDown _
    , DtpLdgr2.KeyDown, rbd.KeyDown, rbg.KeyDown, rbs.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DtpLdgr1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpLdgr1.ValueChanged

        Try
            Date.TryParse(Me.DtpLdgr1.Value.Date, CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
            Me.DtpLdgr2.MinDate = (CurrDate.Date)
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub ChkRptLdgr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptLdgr.CheckedChanged
        Try
            If Flag1 = True Then
                Me.BtnRptVewLdgr_Click(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Trial_Sum_DebitCredit()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            If Me.rbs.Checked = True Then
                cmd = New SqlCommand("FIANCT_T_TRIAL_GoupwiseSUM_FILL", FinActConn)
            Else
                cmd = New SqlCommand("FIANCT_T_TRIAL_SUM_FILL", FinActConn)
            End If


            cmd.CommandType = CommandType.StoredProcedure
            rdr = cmd.ExecuteReader
            While rdr.Read
                If rdr.IsDBNull(0) = False Then
                    xDEBIT = rdr(0)
                End If
                If rdr.IsDBNull(1) = False Then
                    xCREDIT = rdr(1)
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            rdr.Close()
            cmd.Dispose()
        End Try
    End Sub
    Private Sub SetExtraPramtoCrRpt(ByVal xCrRpt As Object)
        Try
            Dim ParmVal1 As ParameterValues = New ParameterValues()
            Dim DisVal1 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal1.Value = 1
            ParmVal1.Add(DisVal1)

            Dim ParmVal2 As ParameterValues = New ParameterValues()
            Dim DisVal2 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal2.Value = 2
            ParmVal2.Add(DisVal2)

            Trial_Sum_DebitCredit()

            ParmVal1.AddValue(xDEBIT)
            ParmVal2.AddValue(xCREDIT)


            xCrRpt.DataDefinition.ParameterFields("ParmSumDr").ApplyCurrentValues(ParmVal1)
            xCrRpt.DataDefinition.ParameterFields("ParmSumCR").ApplyCurrentValues(ParmVal2)


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
End Class
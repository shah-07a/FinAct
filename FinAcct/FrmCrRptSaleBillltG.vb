
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCrRptSaleBillltG
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd1 As SqlCommand
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CrRptSbill1 As Object = Nothing
    Dim CrRptSbill2 As Object = Nothing
    Dim xxPageCont As Integer = 0



    Private Sub FrmCrRptSaleBill_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cmd = New SqlCommand("Delete from FINACT_TEMP_PurEntry", FinActConn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            ' FrmMainMdi.MenuItem261.Enabled = True
        End Try
    End Sub
    Private Sub FrmCrRptSaleBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, 101)
            Me.Top = 0
            Me.Left = 0
            If Cl_TimeIndia = True Then
                Me.ChkRptLdgr.Checked = False
            Else
                Me.ChkRptLdgr.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpLdgr1, Me.DtpLdgr2)
            Fill_Combobox_DistinctSaleSplrid(Me.CmbxLdgr)
            FillTempTable_BillPrinting()
            'BtnRptVewLdgr_Click(sender, e)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub FillTempTable_BillPrinting()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            If Cl_Kbl = True Or Cl_Ltg = True Then
                cmd = New SqlCommand("Finact_Rpt_SaleentryBillPrint_KBLtype_FillTable", FinActConn)
            Else
                cmd = New SqlCommand("Finact_Rpt_SaleentryBillPrint_FillTable", FinActConn)
            End If
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SBillNo", Trim(x_SBillNo_x))
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()

        End Try

    End Sub

    Private Sub ChkLdgrAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLdgrAll.CheckedChanged
        Try
            If Me.ChkLdgrAll.Checked = True Then
                Me.CmbxLdgr.Enabled = False
            Else
                Me.CmbxLdgr.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRptVewLdgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click
        Try
            Handle_P_Bar_Part_I(Me)

            SelRecd_Fromtable_StokIssue(xxPageCont)
            ' FrmMainMdi.MenuItem261.Enabled = False
            Handle_P_Bar(Me)
             Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, Screen.PrimaryScreen.WorkingArea.Height - 50)

            Me.Top = 0
            Me.Left = 0
            xxPageCont += 1
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_StokIssue(ByVal XRPT As Integer)
        Try

            Dim Stype, Sbtype As Integer
            If Me.ChkLdgrAll.Checked = True Then
                Stype = 1

            Else
                Stype = 2

            End If
            Sbtype = 0
            Dim Selact As String = Trim(Me.CmbxLdgr.SelectedValue)

            If x_SBill_Type = 1 Then
                If Cl_Kbl = True Then
                    CrRptSbill1 = New CrRpt_KBL_SaleBillMech
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_KBLtype_Select", Me.CrRptSbill1, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                ElseIf Cl_Ltg = True Then
                    CrRptSbill1 = New CrRpt_LTG_SaleBill
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_Select", Me.CrRptSbill1, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                Else
                    CrRptSbill1 = New CrRptSaleBill
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_Select", Me.CrRptSbill1, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                End If

                SetExtraPramtoCrRpt(XRPT)
                If Me.ChkRptLdgr.Checked = True Then
                    CoprofileParamsRest_Adrs(Me.CrRptSbill1, Me.CrRptVewSaleBill, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
                Else
                    CoprofileParamsRest_Adrs(Me.CrRptSbill1, Me.CrRptVewSaleBill, True, False, Me.DtpLdgr1, Me.DtpLdgr2)
                End If
            Else
                If Cl_Kbl = True Then
                    CrRptSbill2 = New CrRpt_KBL_SaleBillMech
                    Selact = xSaleBillId
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_KBLtype_Select", Me.CrRptSbill2, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                ElseIf Cl_Ltg = True Then
                    CrRptSbill2 = New CrRpt_LTG_SaleBill
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_KBLtype_Select", Me.CrRptSbill2, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                Else
                    CrRptSbill2 = New CrRptSaleBill
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_Select", Me.CrRptSbill2, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                End If

                SetExtraPramtoCrRpt(XRPT)
                If Cl_Ltg = True Then
                Else
                    If Me.ChkRptLdgr.Checked = True Then
                        CoprofileParamsRest_Adrs(Me.CrRptSbill2, Me.CrRptVewSaleBill, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
                    Else
                        CoprofileParamsRest_Adrs(Me.CrRptSbill2, Me.CrRptVewSaleBill, True, False, Me.DtpLdgr1, Me.DtpLdgr2)
                    End If
                End If
               
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_Ldgr, Line No. 234 ")
        End Try
    End Sub

    Private Sub ChkRptLdgr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptLdgr.CheckedChanged
        Try
            '  Me.BtnRptVewLdgr_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpLdgr1.KeyDown, ChkLdgrAll.KeyDown _
    , ChkRptLdgr.KeyDown, DtpLdgr2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetExtraPramtoCrRpt(ByVal xPage As Integer)
        Try
            Dim ParmVal1 As ParameterValues = New ParameterValues()
            Dim DisVal1 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal1.Value = 1
            ParmVal1.Add(DisVal1)

            Dim ParmVal2 As ParameterValues = New ParameterValues()
            Dim DisVal2 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal2.Value = 2
            ParmVal2.Add(DisVal2)

            Dim ParmVal3 As ParameterValues = New ParameterValues()
            Dim DisVal3 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal3.Value = 3
            ParmVal3.Add(DisVal3)

            Dim ParmVal4 As ParameterValues = New ParameterValues()
            Dim DisVal4 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal4.Value = 4
            ParmVal4.Add(DisVal4)

            Dim ParmVal5 As ParameterValues = New ParameterValues()
            Dim DisVal5 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal5.Value = 5
            ParmVal5.Add(DisVal5)

            Dim ParmVal6 As ParameterValues = New ParameterValues()
            Dim DisVal6 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal6.Value = 6
            ParmVal6.Add(DisVal6)


            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            cmd = New SqlCommand("Select cocst from finactcogatemstr", FinActConn1)
            rdr = cmd.ExecuteReader
            While rdr.Read
                ParmVal1.AddValue(rdr(0))
            End While
            cmd.Dispose()
            rdr.Close()


            If Cl_Kbl = True Then
                FinActCmd = New SqlCommand("Finact_xSaleBill_Terms", FinActConn1)
                FinActCmd.CommandType = CommandType.StoredProcedure
                FinActCmd.Parameters.AddWithValue("@XXSPLRID", xSaleBillSplrid)
                FinActCmd.Parameters.AddWithValue("@xxSpCatid", xSaleBillSpcatid)
                Dim xVal4 As String = ""
                Dim xVal4A As String = "THIS COPY DOES NOT ENTITLE THE HOLDER TO CLAIM INPUT TAX CREDIT"
                FinActRdr = FinActCmd.ExecuteReader
                While FinActRdr.Read
                    If FinActRdr.IsDBNull(0) = False Then
                        ParmVal2.AddValue(FinActRdr(1))
                        xVal4 = Trim(FinActRdr(2))
                        ParmVal5.AddValue(FinActRdr(0))
                    End If
                End While
                FinActCmd.Dispose()
                FinActRdr.Close()
                Select Case xPage
                    Case 2
                        ParmVal3.AddValue("ORIGINAL FOR BUYER")
                        ParmVal4.AddValue(xVal4.Trim)
                    Case 3
                        ParmVal3.AddValue("DUPLICATE FOR TRANSPORT")
                        ParmVal4.AddValue(xVal4A.Trim)
                    Case 4
                        ParmVal3.AddValue("OFFICE COPY")
                        ParmVal4.AddValue(xVal4A.Trim)
                    Case 5
                        ParmVal3.AddValue("EXTRA/AGENT COPY")
                        ParmVal4.AddValue(xVal4A.Trim)
                End Select

                Me.CrRptSbill2.DataDefinition.ParameterFields("vattin").ApplyCurrentValues(ParmVal1)
                Me.CrRptSbill2.DataDefinition.ParameterFields("INVTYPE").ApplyCurrentValues(ParmVal2)
                Me.CrRptSbill2.DataDefinition.ParameterFields("INVPAGETYPE").ApplyCurrentValues(ParmVal3)

                Me.CrRptSbill2.DataDefinition.ParameterFields("INputCredit").ApplyCurrentValues(ParmVal4)
                Me.CrRptSbill2.DataDefinition.ParameterFields("PmtTerms").ApplyCurrentValues(ParmVal5)

                CrRptVewSaleBill.ReportSource = CrRptSbill2
            ElseIf Cl_Ltg = True Then
                '===========
                FinActCmd = New SqlCommand("Finact_xSaleBill_Terms", FinActConn1)
                FinActCmd.CommandType = CommandType.StoredProcedure
                FinActCmd.Parameters.AddWithValue("@xxSaleBillId", CInt(xSaleBillId))
                FinActRdr = FinActCmd.ExecuteReader
                Dim xTxAblAmt As Double = 0
                While FinActRdr.Read
                    If FinActRdr.IsDBNull(0) = False Then
                        xTxAblAmt = CDbl(FinActRdr(3))
                    End If
                End While
                FinActCmd.Dispose()
                FinActRdr.Close()
                ParmVal6.AddValue(RupeesToWord(xTxAblAmt))
                ' Me.CrRptSbill2.DataDefinition.ParameterFields("vattin").ApplyCurrentValues(ParmVal1)
                Me.CrRptSbill2.DataDefinition.ParameterFields("Num2Word").ApplyCurrentValues(ParmVal6)
                'Me.CrRptSbill1.DataDefinition.ParameterFields("INVTYPE").ApplyCurrentValues(ParmVal2)
                'Me.CrRptSbill1.DataDefinition.ParameterFields("INVPAGETYPE").ApplyCurrentValues(ParmVal3)
                CrRptVewSaleBill.ReportSource = CrRptSbill2
                '==========
                
            Else
                Me.CrRptSbill1.DataDefinition.ParameterFields("vattin").ApplyCurrentValues(ParmVal1)
                'Me.CrRptSbill1.DataDefinition.ParameterFields("INVTYPE").ApplyCurrentValues(ParmVal2)
                'Me.CrRptSbill1.DataDefinition.ParameterFields("INVPAGETYPE").ApplyCurrentValues(ParmVal3)
                CrRptVewSaleBill.ReportSource = CrRptSbill1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally


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

    Private Sub CmbxLdgr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxLdgr.SelectedIndexChanged

    End Sub
End Class

Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine


Public Class FrmCrRptSaleBillPrinting
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
            Me.Top = 0
            Me.Left = 0
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 30
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
            If Cl_Kbl = True Then
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

            '----------------
            If xxPageCont >= 4 Then Exit Sub
            Handle_P_Bar_Part_I(Me)

            For xxPageCont = 1 To 4
                SelRecd_Fromtable_StokIssue(xxPageCont)
            Next
            Handle_P_Bar(Me)
            Me.Height = Screen.PrimaryScreen.WorkingArea.Width - 50
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 80
            Me.Top = 0
            Me.Left = 0
          
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
            x_SBill_Type = 2
            If x_SBill_Type = 1 Then
                If Cl_Kbl = True Then
                    If xMACH_xBILLING = True Then
                        CrRptSbill2 = New CrRpt_KBL_SaleBillMech
                    Else
                        CrRptSbill2 = New CrRpt_KBL_SaleBill
                    End If

                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_KBLtype_Select", Me.CrRptSbill2, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                Else
                    CrRptSbill1 = New CrRptSaleBill
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_Select", Me.CrRptSbill2, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                End If

                SetExtraPramtoCrRpt(XRPT)
                If Me.ChkRptLdgr.Checked = True Then
                    CoprofileParamsRest_Adrs(Me.CrRptSbill2, Me.CrRptVewSaleBill, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
                Else
                    CoprofileParamsRest_Adrs(Me.CrRptSbill2, Me.CrRptVewSaleBill, True, False, Me.DtpLdgr1, Me.DtpLdgr2)
                End If
            Else
                If Cl_Kbl = True Then
                    If xMACH_xBILLING = True Then
                        CrRptSbill2 = New CrRpt_KBL_SaleBillMech
                    Else
                        CrRptSbill2 = New CrRpt_KBL_SaleBill
                    End If
                    Selact = xSaleBillId
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_KBLtype_Select", Me.CrRptSbill2, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                Else
                    CrRptSbill2 = New CrRptSaleBill
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_Select", Me.CrRptSbill2, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                End If

                SetExtraPramtoCrRpt(XRPT)
                If Me.ChkRptLdgr.Checked = True Then
                    CoprofileParamsRest_Adrs(Me.CrRptSbill2, Me.CrRptVewSaleBill, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
                Else
                    CoprofileParamsRest_Adrs(Me.CrRptSbill2, Me.CrRptVewSaleBill, True, False, Me.DtpLdgr1, Me.DtpLdgr2)
                End If
                xCrRpt_SaveAndPrint(Me.CrRptSbill2, xxPageCont)
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

            Dim ParmVal7 As ParameterValues = New ParameterValues()
            Dim DisVal7 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal7.Value = 7
            ParmVal7.Add(DisVal7)

            Dim ParmVal8 As ParameterValues = New ParameterValues()
            Dim DisVal8 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal8.Value = 8
            ParmVal8.Add(DisVal8)

            Dim ParmVal9 As ParameterValues = New ParameterValues()
            Dim DisVal9 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal9.Value = 9
            ParmVal9.Add(DisVal9)


            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            cmd = New SqlCommand("Select cocst from finactcogatemstr", FinActConn1)
            rdr = cmd.ExecuteReader
            While rdr.Read
                ParmVal1.AddValue(rdr(0))
                Dim prm1 As Object = rdr(0)
            End While
            cmd.Dispose()
            rdr.Close()
            If Cl_Kbl = True Then
                FinActCmd = New SqlCommand("Finact_xSaleBill_Terms", FinActConn1)
                FinActCmd.CommandType = CommandType.StoredProcedure
                FinActCmd.Parameters.AddWithValue("@XXSPLRID", xSaleBillSplrid)
                FinActCmd.Parameters.AddWithValue("@xxSpCatid", xSaleBillSpcatid)
                FinActCmd.Parameters.AddWithValue("@xxSaleBillId", xSaleBillId)

                Dim xVal4 As String = ""
                Dim xVal4A As String = "THIS COPY DOES NOT ENTITLE THE HOLDER TO CLAIM INPUT TAX CREDIT"
                FinActRdr = FinActCmd.ExecuteReader
                While FinActRdr.Read
                    If FinActRdr.IsDBNull(0) = False Then
                        If FinActRdr.IsDBNull(1) = False Then
                            ParmVal2.AddValue(FinActRdr(1))
                        Else
                            ParmVal2.AddValue("")
                        End If

                        If FinActRdr.IsDBNull(2) = False Then
                            xVal4 = Trim(FinActRdr(2))
                        Else
                            xVal4 = ""
                        End If

                        If Me.ChkbxPaytrm.CheckState = CheckState.Checked Then
                            ParmVal5.AddValue(FinActRdr(0))
                        Else
                            ParmVal5.AddValue(" ")
                        End If

                        If FinActRdr.IsDBNull(3) = False Then
                            xxRptNetAmt = CDbl(FinActRdr(3))
                        Else
                            xxRptNetAmt = 0
                        End If

                        If FinActRdr.IsDBNull(4) = False Then
                            ParmVal7.AddValue(FinActRdr(4))
                        Else
                            ParmVal7.AddValue("")
                        End If


                    End If
                End While
                FinActCmd.Dispose()
                FinActRdr.Close()
                Select Case xPage
                    Case 1
                        ParmVal3.AddValue("ORIGINAL FOR BUYER")
                        ParmVal4.AddValue(xVal4.Trim)
                    Case 2
                        ParmVal3.AddValue("DUPLICATE FOR TRANSPORT")
                        ParmVal4.AddValue(xVal4A.Trim)
                    Case 3
                        ParmVal3.AddValue("OFFICE COPY")
                        ParmVal4.AddValue(xVal4A.Trim)
                    Case 4
                        ParmVal3.AddValue("EXTRA/AGENT COPY")
                        ParmVal4.AddValue(xVal4A.Trim)
                End Select

                ParmVal6.AddValue(RupeesToWord(xxRptNetAmt))

                Me.CrRptSbill2.DataDefinition.ParameterFields("vattin").ApplyCurrentValues(ParmVal1)
                Me.CrRptSbill2.DataDefinition.ParameterFields("INVTYPE").ApplyCurrentValues(ParmVal2)
                Me.CrRptSbill2.DataDefinition.ParameterFields("INVPAGETYPE").ApplyCurrentValues(ParmVal3)

                Me.CrRptSbill2.DataDefinition.ParameterFields("INputCredit").ApplyCurrentValues(ParmVal4)
                Me.CrRptSbill2.DataDefinition.ParameterFields("PmtTerms").ApplyCurrentValues(ParmVal5)
                Me.CrRptSbill2.DataDefinition.ParameterFields("Num2Word").ApplyCurrentValues(ParmVal6)
                Me.CrRptSbill2.DataDefinition.ParameterFields("PONo").ApplyCurrentValues(ParmVal7)
                Me.CrRptSbill2.DataDefinition.ParameterFields("AdnlDis").ApplyCurrentValues(ParmVal8)
                Me.CrRptSbill2.DataDefinition.ParameterFields("AdnlDisRate").ApplyCurrentValues(ParmVal9)
                CrRptVewSaleBill.ReportSource = CrRptSbill2
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

    Private Sub BtnPrnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrnt.Click
        Try
            Dim xPcnt As Integer = 0
            xxPageCont = 0
            BtnRptVewLdgr_Click(sender, e)
            If Me.Rbset5.Checked = True Then
                xPcnt = 4 'set of 5
            ElseIf Me.Rbset4.Checked = True Then
                xPcnt = 4 'set of 4
            ElseIf Me.Rbset3.Checked = True Then
                xPcnt = 3 'set of 3
            End If

            For xxx As Integer = 1 To xPcnt

                Dim psi As New ProcessStartInfo
                Dim xxCrRpt As String = "xxCrRptBill" & xxx
                Dim xfiles As String = Application.StartupPath + "\" + xxCrRpt + ".rtf"
                psi.FileName = xfiles
                psi.UseShellExecute = True
                psi.Verb = "print"
                psi.CreateNoWindow = False
                Process.Start(psi)


            Next

            If Me.Rbset5.Checked = True Then
                Dim psi As New ProcessStartInfo
                Dim xxCrRpt As String = "xxCrRptBill" & 2
                Dim xfiles As String = Application.StartupPath + "\" + xxCrRpt + ".rtf"
                psi.FileName = xfiles
                psi.UseShellExecute = True
                psi.Verb = "print"
                psi.CreateNoWindow = False

                Process.Start(psi)
            End If

        Catch ex As Exception
            ''MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CmbxLdgr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxLdgr.SelectedIndexChanged

    End Sub
End Class
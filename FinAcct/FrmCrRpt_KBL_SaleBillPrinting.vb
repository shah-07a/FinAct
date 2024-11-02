
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions
Imports System.Drawing.Printing
Imports System.Threading
Imports System.Diagnostics
Imports System.IO
Imports AcroPDFLib


Public Class FrmCrRpt_KBL_SaleBillPrinting
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd1 As SqlCommand
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CrRptSbill1 As Object = Nothing
    Dim CrRptSbill2 As Object = Nothing
    Dim xxPageCont As Integer = 0
    Dim xSpcatID As Integer = 0
    Dim xBillId As Integer = 0

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
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 80
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpLdgr1, Me.DtpLdgr2)
            Me.CmbxLdgr.Focus()
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
            cmd.Parameters.AddWithValue("@SBillNo", Trim(Me.CmbxLdgr.Text))
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()

        End Try

    End Sub



    Private Sub BtnRptVewLdgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click
        Try
            If xxPageCont >= 4 Then Exit Sub
            FillTempTable_BillPrinting()
            Handle_P_Bar_Part_I(Me)
            If Cl_Kbl = True Then
                For xxPageCont = 1 To 4
                    SelRecd_Fromtable_StokIssue(xxPageCont)
                Next
            Else
                SelRecd_Fromtable_StokIssue(xxPageCont)
            End If
         
            Handle_P_Bar(Me)
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, Screen.PrimaryScreen.WorkingArea.Height - 30)
            Me.Top = 0
            Me.Left = 0
            Me.BtnPrnt.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_StokIssue(ByVal XRPT As Integer)
        Try
            Dim Stype, Sbtype As Integer
            Stype = 1
            Sbtype = 0
            Dim Selact As String = Trim(Me.CmbxLdgr.SelectedValue)

            If x_SBill_Type = 1 Then
                If Cl_Kbl = True Then
                    If Me.Rbfab.Checked = True Then
                        CrRptSbill1 = New CrRpt_KBL_SaleBill
                    Else
                        CrRptSbill1 = New CrRpt_KBL_SaleBillMech
                    End If

                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_KBLtype_Select", Me.CrRptSbill1, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                Else
                    CrRptSbill1 = New CrRptSaleBill
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_Select", Me.CrRptSbill1, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                End If

                SetExtraPramtoCrRpt(XRPT)
                CoprofileParamsRest_Adrs(Me.CrRptSbill1, Me.CrRptVewSaleBill, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
            Else
                If Cl_Kbl = True Then
                    If Me.Rbfab.Checked = True Then
                        CrRptSbill2 = New CrRpt_KBL_SaleBill
                    Else
                        CrRptSbill2 = New CrRpt_KBL_SaleBillMech
                    End If
                    Selact = xSaleBillId
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_KBLtype_Select", Me.CrRptSbill2, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                ElseIf Cl_Ltg = True Then

                    CrRptSbill2 = New CrRpt_LTG_SaleBill
                    Selact = xSaleBillId
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_KBLtype_Select", Me.CrRptSbill2, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)

                Else
                    CrRptSbill2 = New CrRptSaleBill
                    Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_TEMP_PurEntry_Select", Me.CrRptSbill2, Me.CrRptVewSaleBill, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
                End If

                SetExtraPramtoCrRpt(XRPT)
                CoprofileParamsRest_Adrs(Me.CrRptSbill2, Me.CrRptVewSaleBill, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
                xCrRpt_SaveAndPrint(Me.CrRptSbill2, xxPageCont)


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_Ldgr, Line No. 234 ")
        End Try
    End Sub


    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpLdgr1.KeyDown, DtpLdgr2.KeyDown
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
            End While
            cmd.Dispose()
            rdr.Close()


            If Cl_Kbl = True Then
                FinActCmd = New SqlCommand("Finact_xSaleBill_Terms", FinActConn1)
                FinActCmd.CommandType = CommandType.StoredProcedure
                FinActCmd.Parameters.AddWithValue("@XXSPLRID", CInt(Me.CmbxLdgr.SelectedValue)) 'xSaleBillSplrid)
                FinActCmd.Parameters.AddWithValue("@xxSpCatid", CInt(xSpcatID)) ' xSaleBillSpcatid)
                FinActCmd.Parameters.AddWithValue("@xxSaleBillId", CInt(xBillId))

                Dim xVal4 As String = ""
                Dim xVal4A As String = "THIS COPY DOES NOT ENTITLE THE HOLDER TO CLAIM INPUT TAX CREDIT"
                FinActRdr = FinActCmd.ExecuteReader
                While FinActRdr.Read
                    If FinActRdr.IsDBNull(0) = False Then
                        ParmVal2.AddValue(FinActRdr(1))
                        xVal4 = Trim(FinActRdr(2))
                        If Me.ChkbxPaytrm.CheckState = CheckState.Checked Then
                            ParmVal5.AddValue(FinActRdr(0))
                        Else
                            ParmVal5.AddValue(" ")
                        End If

                        xxRptNetAmt = CDbl(FinActRdr(3))
                        ParmVal7.AddValue(FinActRdr(4))

                        xxRptAdnlDisAmt = CDbl(FinActRdr(5))
                        ParmVal8.AddValue(FinActRdr(5))
                        ParmVal9.AddValue(FinActRdr(6))
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
            ElseIf Cl_Ltg = True Then
                Me.CrRptSbill2.DataDefinition.ParameterFields("vattin").ApplyCurrentValues(ParmVal1)
                'Me.CrRptSbill1.DataDefinition.ParameterFields("INVTYPE").ApplyCurrentValues(ParmVal2)
                'Me.CrRptSbill1.DataDefinition.ParameterFields("INVPAGETYPE").ApplyCurrentValues(ParmVal3)
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
                If Me.CmbxLdgr.SelectedIndex = 0 Then
                    xSpcatID = CInt(xDynamic_Find_xAnItem_xInA_Table_1cond("SaleEntVatrate", "SaleEntSplrid", CInt(Me.CmbxLdgr.SelectedValue), "FinactSaleEntry"))
                    xBillId = CInt(xDynamic_Find_xAnItem_xInA_Table_1cond("saleentid", "SaleentVno", Me.CmbxLdgr.Text.Trim, "Finactsaleentry"))
                End If
                xxPageCont = 0
                Me.BtnRptVewLdgr.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxLdgr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxLdgr.SelectedIndexChanged
        Try
            If Me.CmbxLdgr.SelectedIndex > 0 Then
                xSpcatID = CInt(xDynamic_Find_xAnItem_xInA_Table_1cond("SaleEntVatrate", "SaleEntSplrid", CInt(Me.CmbxLdgr.SelectedValue), "FinactSaleEntry"))
                xBillId = CInt(xDynamic_Find_xAnItem_xInA_Table_1cond("saleentid", "SaleentVno", Me.CmbxLdgr.Text.Trim, "Finactsaleentry"))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbfab.CheckedChanged, RbMach.CheckedChanged
        Try
            If Me.Rbfab.Checked = True Then
                Fill_Cmbx_xDynamic_WHERECond_CONVRTvar2iNT_Select("Saleentsplrid", "Saleentvno", "SaleentBillType", "finactSaleentry", "FAB", Me.CmbxLdgr, "SaleEntDelStatus", CInt(1))
                Me.Rbset5.Checked = True
            Else
                Fill_Cmbx_xDynamic_WHERECond_CONVRTvar2iNT_Select("Saleentsplrid", "Saleentvno", "SaleentBillType", "finactSaleentry", "MACH", Me.CmbxLdgr, "SaleEntDelStatus", CInt(1))
                Me.Rbset4.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPrnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrnt.Click
        Try
            Dim xPcnt As Integer = 0
            If Me.Rbset5.Checked = True Then
                xPcnt = 4 'set of 5
            ElseIf Me.Rbset4.Checked = True Then
                xPcnt = 4 'set of 4
            ElseIf Me.Rbset3.Checked = True Then
                xPcnt = 3 'set of 3
            End If
            Dim psi As New ProcessStartInfo
            psi.UseShellExecute = True
            psi.Verb = "print"
            psi.CreateNoWindow = False
            For xxx As Integer = 1 To xPcnt
                Dim xxCrRpt As String = "xxCrRptBill" & xxx
                Dim xfiles As String = Application.StartupPath + "\" + xxCrRpt + ".rtf" '=== Directory.GetFiles(TextBoxPath.Text, "*.pdf", SearchOption.TopDirectoryOnly)
                psi.FileName = xfiles
                Process.Start(psi)
            Next
                If Me.Rbset5.Checked = True Then
                Dim xxCrRpt As String = "xxCrRptBill" & 2
                Dim xfiles As String = Application.StartupPath + "\" + xxCrRpt + ".rtf"
                psi.FileName = xfiles
                Process.Start(psi)
                End If
            Me.BtnPrnt.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

 
    Private Sub ChkbxPaytrm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbxPaytrm.CheckedChanged

    End Sub
End Class
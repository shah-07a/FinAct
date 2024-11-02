Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat16
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader
    Private Sub BtnPRDMSTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPRDMSTR.Click
        Try
            xCall_LinkFrm(FrmPirdMstr, Me.CmbxPeriod)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPeriod_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPeriod.GotFocus
        Try
            Me.CmbxPeriod.DroppedDown = True
            If xCmbxRefresh = True Then
                Fill_Combobox("Perdid", "PerdName", "Finact_PerdMstr", "PerdDelStatus", CInt(1), Me.CmbxPeriod)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmVAT_vat15_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Try
                xTRUNCATETABLES()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xTRUNCATETABLES()
        Try
            Try
                If FinActConn.State Then FinActConn.Close()
                FinActConn.Open()
                VATcmd = New SqlCommand("TRUNCATE TABLE Finact_Temp_VAT_PurEntry", FinActConn)
                VATcmd.ExecuteNonQuery()
                VATcmd.Dispose()
                VATcmd = New SqlCommand("TRUNCATE TABLE Finact_Temp_VAT_SaleEntry", FinActConn)
                VATcmd.ExecuteNonQuery()
                VATcmd.Dispose()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmVAT_vat15_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Fill_Combobox("Perdid", "PerdName", "Finact_PerdMstr", "PerdDelStatus", CInt(1), Me.CmbxPeriod)
            Me.CmbxPeriod.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFillSelRec(ByVal xPerdid As Integer)
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            VATcmd = New SqlCommand("Finact_PerdMstr_Select", FinActConn1)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATcmd.Parameters.AddWithValue("@PerdId", CInt(xPerdid))
            VATrdr = VATcmd.ExecuteReader
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DtpVAT1.Value = VATrdr("perdFdt")
                    Me.DtpVAT2.Value = VATrdr("PerdTdt")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            VATcmd.Dispose()
            VATrdr.Close()
        End Try
    End Sub

    Private Sub CmbxPeriod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxPeriod.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxPeriod_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPeriod_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPeriod.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxPeriod) = True Then
                If Me.CmbxPeriod.SelectedIndex = 0 Then
                    xFillSelRec(Me.CmbxPeriod.SelectedValue)
                End If
                Me.BtnOK.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxPeriod.SelectedIndexChanged
        Try
            If Me.CmbxPeriod.SelectedIndex > 0 Then
                xFillSelRec(Me.CmbxPeriod.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Try
            If Me.BtnOK.Text.Trim = "&OK" Then
                Me.BtnOK.Text = "&RESET"
                Me.CmbxPeriod.Enabled = False
                Me.BtnPRDMSTR.Enabled = False
                x_VAT_Forms_xFillSalePurTable("Finact_Rpt_VAT_Saleentry_FillTable", Me.DtpVAT1.Value.Date, Me.DtpVAT2.Value.Date)
                x_VAT_Forms_xFillSalePurTable("Finact_Rpt_VAT_Purentry_FillTable", Me.DtpVAT1.Value.Date, Me.DtpVAT2.Value.Date)
                xFill_DgSale_WithSaleCategories()
                xFill_DgPurchase_WithPurchaseCategories()
                xGEN_PURCHASE_CrRpt()
                xGEN_SALES_CrRpt()
                xVATCALS()
                Me.TXTDATE.Text = Format(Today.Date, "dd/MM/yyyy")
                Me.TxtBFitc.Focus()
            Else
                Me.BtnOK.Text = "&OK"
                Me.DgSales.Rows.Clear()
                Me.DgPurchase.Rows.Clear()
                xTRUNCATETABLES()
                Me.CmbxPeriod.Enabled = True
                Me.BtnPRDMSTR.Enabled = True
                xReSETvALS()
                Me.CmbxPeriod.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.GotFocus, BtneEXIT.GotFocus, BtnV16.GotFocus
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Blue
            Me.BtnOK.ForeColor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOK_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.Leave, BtneEXIT.Leave, BtnV16.Leave
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Transparent
            Me.BtnOK.ForeColor = Color.Navy
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xFill_DgSale_WithSaleCategories()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            VATcmd = New SqlCommand("Finact_SalePurCatgry_Sale_Vat15_Select", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader
            Me.DgSales.Rows.Clear()
            Me.DgSales.AllowUserToAddRows = False
            Dim xS As Integer = 0
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DgSales.Rows.Add()
                    Me.DgSales.Rows(xS).Cells(0).Value = Trim(VATrdr("SALETYPE"))
                    Me.DgSales.Rows(xS).Cells(1).Value = FormatNumber(VATrdr("VRATE"), 3)
                    Me.DgSales.Rows(xS).Cells(2).Value = FormatNumber(VATrdr("TXABLAMT"), 2)
                    Me.DgSales.Rows(xS).Cells(3).Value = FormatNumber(VATrdr("VAMT"), 2)
                    Me.DgSales.Rows(xS).Cells(4).Value = FormatNumber(VATrdr("SURCHARG"), 2) 'surcharge
                    Me.DgSales.Rows(xS).Cells(5).Value = FormatNumber(0, 2) 'return
                    Me.DgSales.Rows(xS).Cells(6).Value = FormatNumber(0, 2) 'vat/cst on return
                    Me.DgSales.Rows(xS).Cells(7).Value = Trim(VATrdr("PURENTTYPE")) 'TYPE
                    xS += 1
                End If
            End While
            VATcmd.Dispose()
            VATrdr.Close()
            Dim xTGS As Double = 0
            Dim xVAMT As Double = 0
            Dim xSur As Double = 0
            Dim xRtrn As Double = 0
            Dim xVCR As Double = 0
            Me.DgSales.Rows.Add()

            Dim xMax As Integer = Me.DgSales.RowCount - 1
            Me.DgSales.Rows(xMax).Cells(2).Style.BackColor = Color.Yellow
            Me.DgSales.Rows(xMax).Cells(3).Style.BackColor = Color.Yellow
            Me.DgSales.Rows(xMax).Cells(4).Style.BackColor = Color.Yellow
            Me.DgSales.Rows(xMax).Cells(5).Style.BackColor = Color.Yellow
            Me.DgSales.Rows(xMax).Cells(6).Style.BackColor = Color.Yellow

            For Each dgr As DataGridViewRow In Me.DgSales.Rows
                xTGS += dgr.Cells(2).Value
                xVAMT += dgr.Cells(3).Value
                xSur += dgr.Cells(4).Value
                xRtrn += dgr.Cells(5).Value
                xVCR += dgr.Cells(6).Value
            Next
            Me.DgSales.Rows(xMax).Cells(2).Value = FormatNumber(xTGS, 2)
            Me.DgSales.Rows(xMax).Cells(3).Value = FormatNumber(xVAMT, 2)
            Me.DgSales.Rows(xMax).Cells(4).Value = FormatNumber(xSur, 2)
            Me.DgSales.Rows(xMax).Cells(5).Value = FormatNumber(xRtrn, 2)
            Me.DgSales.Rows(xMax).Cells(6).Value = FormatNumber(xVCR, 2)
            Me.DgSales.Rows.Add()
            ' Me.DgSales.Rows.Add()
            VATcmd = New SqlCommand("Finact_SalePurCatgry_SALE_Vat15_Summary_Select", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader
            Dim xSMX As Integer = Me.DgSales.RowCount
            Dim xSaleRtd As Integer = xSMX - 2
            xVAT_DgSaleRowIndx = CInt(xSMX)
            Me.DgSales.Rows(xSMX - 1).Cells(0).Value = "SUMMARY"
            Me.DgSales.Rows(xSMX - 1).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgSales.Rows(xSMX - 1).Cells(0).Style.ForeColor = Color.Black

            Me.DgSales.Rows(xSMX - 1).Cells(1).Style.ForeColor = Color.Black
            Me.DgSales.Rows(xSMX - 1).Cells(1).Value = "<--G.TOTAL-->"
            Me.DgSales.Rows(xSMX - 1).Cells(1).Style.ForeColor = Color.Black

            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DgSales.Rows.Add()
                    Me.DgSales.Rows(xSMX).Cells(0).Value = Trim(VATrdr("SALETYPE"))
                    Me.DgSales.Rows(xSMX).Cells(1).Value = FormatNumber(CDbl(VATrdr("TXABLAMT")) + CDbl(VATrdr("VAMT")) + CDbl(VATrdr("SURCHARG")), 2)
                    Me.DgSales.Rows(xSMX).Cells(2).Value = FormatNumber(VATrdr("TXABLAMT"), 2)
                    Me.DgSales.Rows(xSMX).Cells(3).Value = FormatNumber(VATrdr("VAMT"), 2)
                    Me.DgSales.Rows(xSMX).Cells(4).Value = FormatNumber(VATrdr("SURCHARG"), 2)
                    xSMX += 1
                End If
            End While
            VATcmd.Dispose()
            VATrdr.Close()
            '--------------------
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub
    Private Sub xFill_DgPurchase_WithPurchaseCategories()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            VATcmd = New SqlCommand("Finact_SalePurCatgry_Purchase_Vat15_Select", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader
            Me.DgPurchase.Rows.Clear()
            Me.DgPurchase.AllowUserToAddRows = False
            Dim xP As Integer = 0
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DgPurchase.Rows.Add()
                    Me.DgPurchase.Rows(xP).Cells(0).Value = Trim(VATrdr("PURTYPE"))
                    Me.DgPurchase.Rows(xP).Cells(1).Value = FormatNumber(VATrdr("VRATE"), 2)
                    Me.DgPurchase.Rows(xP).Cells(2).Value = FormatNumber(VATrdr("TXABLAMT"), 2)
                    Me.DgPurchase.Rows(xP).Cells(3).Value = FormatNumber(VATrdr("VAMT"), 2)
                    Me.DgPurchase.Rows(xP).Cells(4).Value = FormatNumber(VATrdr("SURCHARG"), 2) 'surcharge
                    Me.DgPurchase.Rows(xP).Cells(5).Value = FormatNumber(0, 2) 'return
                    Me.DgPurchase.Rows(xP).Cells(6).Value = FormatNumber(0, 2) 'vat/cst on return
                    Me.DgPurchase.Rows(xP).Cells(7).Value = Trim(VATrdr("PURENTTYPE")) 'TYPE
                    xP += 1
                End If
            End While

            VATcmd.Dispose()
            VATrdr.Close()

            Dim xTGS As Double = 0
            Dim xVAMT As Double = 0
            Dim xSur As Double = 0
            Dim xRtrn As Double = 0
            Dim xVCR As Double = 0
            Me.DgPurchase.Rows.Add()
            Dim xMax As Integer = Me.DgPurchase.RowCount - 1
            Me.DgPurchase.Rows(xMax).Cells(2).Style.BackColor = Color.Yellow
            Me.DgPurchase.Rows(xMax).Cells(3).Style.BackColor = Color.Yellow
            Me.DgPurchase.Rows(xMax).Cells(4).Style.BackColor = Color.Yellow
            Me.DgPurchase.Rows(xMax).Cells(5).Style.BackColor = Color.Yellow
            Me.DgPurchase.Rows(xMax).Cells(6).Style.BackColor = Color.Yellow

            For Each dgr As DataGridViewRow In Me.DgPurchase.Rows
                xTGS += dgr.Cells(2).Value
                xVAMT += dgr.Cells(3).Value
                xSur += dgr.Cells(4).Value
                xRtrn += dgr.Cells(5).Value
                xVCR += dgr.Cells(6).Value
            Next
            Me.DgPurchase.Rows(xMax).Cells(2).Value = FormatNumber(xTGS, 2)
            Me.DgPurchase.Rows(xMax).Cells(3).Value = FormatNumber(xVAMT, 2)
            Me.DgPurchase.Rows(xMax).Cells(4).Value = FormatNumber(xSur, 2)
            Me.DgPurchase.Rows(xMax).Cells(5).Value = FormatNumber(xRtrn, 2)
            Me.DgPurchase.Rows(xMax).Cells(6).Value = FormatNumber(xVCR, 2)
            Me.DgPurchase.Rows.Add()
            'Me.DgPurchase.Rows.Add()

            VATcmd = New SqlCommand("Finact_SalePurCatgry_Purchase_Vat15_Summary_Select", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader

            Dim xSMX As Integer = Me.DgPurchase.RowCount
            xVAT_DgPurchaseRowIndx = CInt(xSMX)
            Me.DgPurchase.Rows(xSMX - 1).Cells(0).Value = "SUMMARY"
            Me.DgPurchase.Rows(xSMX - 1).DefaultCellStyle.BackColor = Color.Cyan

            Me.DgPurchase.Rows(xSMX - 1).Cells(1).Style.ForeColor = Color.Black
            Me.DgPurchase.Rows(xSMX - 1).Cells(1).Value = "<--G.TOTAL-->"
            Me.DgPurchase.Rows(xSMX - 1).Cells(1).Style.ForeColor = Color.Black
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DgPurchase.Rows.Add()
                    Me.DgPurchase.Rows(xSMX).Cells(0).Value = Trim(VATrdr("PURTYPE"))
                    Me.DgPurchase.Rows(xSMX).Cells(1).Value = FormatNumber(CDbl(VATrdr("TXABLAMT")) + CDbl(VATrdr("VAMT")) + CDbl(VATrdr("SURCHARG")), 2)
                    Me.DgPurchase.Rows(xSMX).Cells(2).Value = FormatNumber(VATrdr("TXABLAMT"), 2)
                    Me.DgPurchase.Rows(xSMX).Cells(3).Value = FormatNumber(VATrdr("VAMT"), 2)
                    Me.DgPurchase.Rows(xSMX).Cells(4).Value = FormatNumber(VATrdr("SURCHARG"), 2)
                    xSMX += 1
                End If
            End While
            VATcmd.Dispose()
            VATrdr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub CallVatForm()
        Try



            'VAT 15
            Try
                If FinActConn1.State Then FinActConn1.Close()
                FinActConn1.Open()
                VATcmd = New SqlCommand("Finact_Temp_VAT_SalePurEntry_Select", FinActConn1)
                VATcmd.CommandType = CommandType.StoredProcedure
                VATrdr = VATcmd.ExecuteReader
                While VATrdr.Read
                  
                End While
                '--------

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                VATcmd.Dispose()
                VATrdr.Close()
            End Try


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub BtneEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtneEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ALL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpVAT1.KeyDown, DtpVAT2.KeyDown _
    , TXTCHNO.KeyDown, TXTDATE.KeyDown, TXTDRAWON.KeyDown, TxtBFitc.KeyDown, TxtCST.KeyDown, TxtInput.KeyDown, TxtNetStatus.KeyDown, TxtVAT.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBFitc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBFitc.Leave
        Try
            If xChk_numericValidation(Me.TxtBFitc) = True Then
                Exit Sub
            End If
            If Len(Me.TxtBFitc.Text) = 0 Then
                Me.TxtBFitc.Text = 0
            End If
            Me.TxtBFitc.Text = FormatNumber(Me.TxtBFitc.Text, 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBFitc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBFitc.TextChanged
        Try
            If xChk_numericValidation(Me.TxtBFitc) = False Then
                If Len(Me.TxtBFitc.Text) = 0 Then
                    Me.TxtBFitc.Text = 0
                End If
                xVATCALS()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xVATCALS()
        Try
            Dim xITCVAT As Double = CDbl(Me.TxtBFitc.Text) + CDbl(Me.TxtInput.Text)
            Dim xOutVat As Double = CDbl(Me.TxtVAT.Text) + CDbl(Me.TxtCST.Text)
            If xITCVAT > xOutVat Then
                Me.TxtNetStatus.Text = FormatNumber(xITCVAT - xOutVat, 2)
                Me.Panel1.Visible = False
                Me.LblStatus.Text = "REFUNDABLE"
            ElseIf xITCVAT = xOutVat Then
                Me.TxtNetStatus.Text = FormatNumber(xITCVAT - xOutVat, 2)
                Me.Panel1.Visible = False
                Me.LblStatus.Text = "NIL"
            Else
                Me.TxtNetStatus.Text = FormatNumber(xOutVat - xITCVAT, 2)
                Me.Panel1.Visible = True
                Me.LblStatus.Text = "PAYABLE"
                Me.TXTAMOUNT.Text = FormatNumber(CDbl(Me.TxtNetStatus.Text), 2)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTAMOUNT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTAMOUNT.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.TXTAMOUNT_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TXTAMOUNT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAMOUNT.Leave
        Try
            If xChk_numericValidation(Me.TXTAMOUNT) = True Then
                Exit Sub
            End If
            If Len(Me.TXTAMOUNT.Text) = 0 Then
                Me.TXTAMOUNT.Text = 0
            End If
            Me.TXTAMOUNT.Text = FormatNumber(Me.TXTAMOUNT.Text, 2)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xGEN_SALES_CrRpt()
        Try
            If Me.DgSales.RowCount = 0 Then Exit Sub
            xVAT_OutputTAX = 0
            xCST_OutputTAX = 0
            xxSetValZeroSaleVari()
            For Each xDgr As DataGridViewRow In Me.DgSales.Rows
                If Trim(xDgr.Cells(7).Value) = "WITHIN STATE" Or Trim(xDgr.Cells(7).Value) = "UNDER WORKS CONTRACT" Or Trim(xDgr.Cells(7).Value) = "WITHIN STATE UN-REGD. DEALER" Then
                    Select Case CDbl(xDgr.Cells(1).Value)
                        Case 1.0
                            xVAT_S1 += CDbl(xDgr.Cells(2).Value)
                            xVAT_STx1 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr1 += CDbl(xDgr.Cells(4).Value)

                        Case 4.0
                            xVAT_S4 += CDbl(xDgr.Cells(2).Value)
                            xVAT_STx4 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr4 += CDbl(xDgr.Cells(4).Value)
                        Case 5.0
                            xVAT_S5 += CDbl(xDgr.Cells(2).Value)
                            xVAT_STx5 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr5 += CDbl(xDgr.Cells(4).Value)
                        Case 8.8
                            xVAT_S8_8 += CDbl(xDgr.Cells(2).Value)
                            xVAT_STx8_8 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr8_8 = CDbl(xDgr.Cells(4).Value)
                        Case 12.5
                            xVAT_S12_5 += CDbl(xDgr.Cells(2).Value)
                            xVAT_STx8_8 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr12_5 += CDbl(xDgr.Cells(4).Value)
                        Case 20.0
                            xVAT_S20 += CDbl(xDgr.Cells(2).Value)
                            xVAT_STx20 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr20 += CDbl(xDgr.Cells(4).Value)
                        Case 22.0
                            xVAT_S22 += CDbl(xDgr.Cells(2).Value)
                            xVAT_STx22 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr22 += CDbl(xDgr.Cells(4).Value)
                        Case 27.5
                            xVAT_S27_5 += CDbl(xDgr.Cells(2).Value)
                            xVAT_STx27_5 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr27_5 += CDbl(xDgr.Cells(4).Value)
                        Case 30.0
                            xVAT_S30 += CDbl(xDgr.Cells(2).Value)
                            xVAT_STx30 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr30 += CDbl(xDgr.Cells(4).Value)
                    End Select
                End If
                '===CST SECTION
                If Trim(xDgr.Cells(7).Value) = "INTER STATE" Or Trim(xDgr.Cells(7).Value) = "INTER STATE EXEMPTED" Or Trim(xDgr.Cells(7).Value) = "UNDER WORKS CONTRACT INTERSTATE" _
                Or Trim(xDgr.Cells(7).Value) = "INTER STATE DECLARED GOODS" Or Trim(xDgr.Cells(7).Value) = "INTER STATE DECLARED GOODS UN-REGD." Or Trim(xDgr.Cells(7).Value) = "INTER STATE UN-REGD. DEALER" _
               Or Trim(xDgr.Cells(7).Value) = "INTER STATE BRANCH TRANSFER" Then
                    Select Case CDbl(xDgr.Cells(1).Value)
                        Case 1.0
                            xVAT_S1C += CDbl(xDgr.Cells(2).Value)
                            xVAT_CTx1C += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr1C += CDbl(xDgr.Cells(4).Value)
                        Case 2.0
                            xVAT_S2C += CDbl(xDgr.Cells(2).Value)
                            xVAT_CTx2C += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr2C += CDbl(xDgr.Cells(4).Value)
                        Case 4.0
                            xVAT_S4C += CDbl(xDgr.Cells(2).Value)
                            xVAT_CTx4C += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr4C += CDbl(xDgr.Cells(4).Value)
                        Case 5.0, 5.5
                            xVAT_S5C += CDbl(xDgr.Cells(2).Value)
                            xVAT_CTx5C += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr5C += CDbl(xDgr.Cells(4).Value)
                        Case 8.8
                            xVAT_S8_8C += CDbl(xDgr.Cells(2).Value)
                            xVAT_CTx8_8C += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr8_8C = CDbl(xDgr.Cells(4).Value)
                        Case 12.5
                            xVAT_S12_5C += CDbl(xDgr.Cells(2).Value)
                            xVAT_CTx12_5C += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr12_5C += CDbl(xDgr.Cells(4).Value)
                        Case 20.0
                            xVAT_S20C += CDbl(xDgr.Cells(2).Value)
                            xVAT_CTx20C += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr20C += CDbl(xDgr.Cells(4).Value)
                        Case 22.0
                            xVAT_S22C += CDbl(xDgr.Cells(2).Value)
                            xVAT_CTx22C += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr22C += CDbl(xDgr.Cells(4).Value)
                        Case 27.5
                            xVAT_S27_5C += CDbl(xDgr.Cells(2).Value)
                            xVAT_CTx27_5C += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr27_5C += CDbl(xDgr.Cells(3).Value)
                        Case 30.0
                            xVAT_S30C += CDbl(xDgr.Cells(2).Value)
                            xVAT_CTx30C += CDbl(xDgr.Cells(3).Value)
                            xVAT_Sr30C += CDbl(xDgr.Cells(4).Value)
                    End Select
                End If

                Select Case Trim(xDgr.Cells(7).Value)
                    Case "INTER STATE DECLARED GOODS"
                        xVAT_S1Cdg += CDbl(xDgr.Cells(2).Value)
                    Case "INTER STATE DECLARED GOODS UN-REGD."
                        xVAT_S1CdgUn += CDbl(xDgr.Cells(2).Value)
                    Case "INTER STATE UN-REGD. DEALER"
                        xVAT_S1CUn += CDbl(xDgr.Cells(2).Value)
                    Case "INTER STATE BRANCH TRANSFER"
                        xVAT_S1Cbt += CDbl(xDgr.Cells(2).Value)
                    Case "AGAINST H FORM", "EXPORT DIRECT"
                        VAT16EXPORTSALE += CDbl(xDgr.Cells(2).Value)

                End Select

                '===END OF CST SECTION
                If xDgr.Index = xVAT_DgSaleRowIndx - 2 Then
                    xVAT_Sale_a = CDbl(xDgr.Cells(2).Value)
                End If
            Next
            Dim xWITHINSTATE As Double = xVAT_S1 + xVAT_S4 + xVAT_S5 + xVAT_S8_8 + xVAT_S12_5 + xVAT_S20 + xVAT_S22 + xVAT_S27_5 + xVAT_S30
            Dim xOPTXSURCHARGE As Double = xVAT_Sr1 + xVAT_Sr4 + xVAT_Sr5 + xVAT_Sr8_8 + xVAT_Sr12_5 + xVAT_Sr20 + xVAT_Sr22 + xVAT_Sr27_5 + xVAT_Sr30
            Dim xOPTXVAT As Double = xVAT_STx1 + xVAT_STx4 + xVAT_STx5 + xVAT_STx8_8 + xVAT_STx12_5 + xVAT_STx20 + xVAT_STx22 + xVAT_STx27_5 + xVAT_STx30
            Dim xCSTSALE As Double = xVAT_S1C + xVAT_S2C + xVAT_S4C + xVAT_S5C + xVAT_S8_8C + xVAT_S12_5C + xVAT_S20C + xVAT_S22C + xVAT_S27_5C + xVAT_S30C
            Dim xCSTSERCHARG As Double = xVAT_Sr1C + xVAT_Sr2C + xVAT_Sr4C + xVAT_Sr5C + xVAT_Sr8_8C + xVAT_Sr12_5C + xVAT_Sr20C + xVAT_Sr22C + xVAT_Sr27_5C + xVAT_Sr30C
            Dim xCSTTX As Double = xVAT_CTx1C + xVAT_CTx2C + xVAT_CTx4C + xVAT_CTx5C + xVAT_CTx8_8C + xVAT_CTx12_5C + xVAT_CTx20C + xVAT_CTx22C + xVAT_CTx27_5C + xVAT_CTx30C
            Me.TxtVAT.Text = FormatNumber(xOPTXSURCHARGE + xOPTXVAT, 2)
            Me.TxtCST.Text = FormatNumber(xCSTSERCHARG + xCSTTX, 2)
            VAT16WITHINSTATESALE = xWITHINSTATE
            VAT16INTERSTATESALE = xCSTSALE

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub xGEN_PURCHASE_CrRpt()
        Try
            If Me.DgPurchase.RowCount = 0 Then Exit Sub
            xVAT_OutputTAX = 0
            xCST_OutputTAX = 0
            xxSetValzeroPurVari()
            For Each xDgr As DataGridViewRow In Me.DgPurchase.Rows
                If Trim(xDgr.Cells(7).Value) = "WITHIN STATE" Or Trim(xDgr.Cells(7).Value) = "UNDER WORKS CONTRACT" Then
                    Select Case CDbl(xDgr.Cells(1).Value)
                        Case 1.0
                            xVAT_P1 += CDbl(xDgr.Cells(2).Value)
                            xVAT_PTx1 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Pr1 += CDbl(xDgr.Cells(4).Value)
                        Case 4.0
                            xVAT_P4 += CDbl(xDgr.Cells(2).Value)
                            xVAT_PTx4 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Pr4 += CDbl(xDgr.Cells(4).Value)
                        Case 5.0
                            xVAT_P5 += CDbl(xDgr.Cells(2).Value)
                            xVAT_PTx5 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Pr5 += CDbl(xDgr.Cells(4).Value)
                        Case 8.8
                            xVAT_P8_8 += CDbl(xDgr.Cells(2).Value)
                            xVAT_PTx8_8 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Pr8_8 = CDbl(xDgr.Cells(4).Value)
                        Case 12.5
                            xVAT_P12_5 += CDbl(xDgr.Cells(2).Value)
                            xVAT_PTx8_8 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Pr12_5 += CDbl(xDgr.Cells(4).Value)
                        Case 20.0
                            xVAT_P20 += CDbl(xDgr.Cells(2).Value)
                            xVAT_PTx20 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Pr20 += CDbl(xDgr.Cells(4).Value)
                        Case 22.0
                            xVAT_P22 += CDbl(xDgr.Cells(2).Value)
                            xVAT_PTx22 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Pr22 += CDbl(xDgr.Cells(4).Value)
                        Case 27.5
                            xVAT_P27_5 += CDbl(xDgr.Cells(2).Value)
                            xVAT_PTx27_5 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Pr27_5 += CDbl(xDgr.Cells(4).Value)
                        Case 30.0
                            xVAT_P30 += CDbl(xDgr.Cells(2).Value)
                            xVAT_PTx30 += CDbl(xDgr.Cells(3).Value)
                            xVAT_Pr30 += CDbl(xDgr.Cells(4).Value)
                    End Select
                End If
                If xDgr.Index = xVAT_DgPurchaseRowIndx - 2 Then
                    xVAT_Purchase_a = CDbl(xDgr.Cells(2).Value)
                End If
                If xDgr.Index >= xVAT_DgPurchaseRowIndx Then
                    Dim xx As String = Trim(xDgr.Cells(0).Value)
                    Select Case Trim(xDgr.Cells(0).Value)
                        Case "IMPORT DIRECT"
                            xVAT_Purchase_b = CDbl(xDgr.Cells(2).Value)
                        Case "BRANCH/PRINCIPALS TRANSFER INTERSTATE", "INTER STATE", "INTER STATE EXEMPTED", "UNDER WORKS CONTRACT INTERSTATE"
                            xVAT_Purchase_c += CDbl(xDgr.Cells(2).Value) + CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)
                        Case "WITHIN STATE EXEMPTED"
                            xVAT_Purchase_d = CDbl(xDgr.Cells(2).Value)
                        Case "INTER STATE TAX FREE"
                            xVAT_Purchase_ea = CDbl(xDgr.Cells(2).Value)
                        Case "WITHIN STATE TAX FREE"
                            xVAT_Purchase_e = CDbl(xDgr.Cells(2).Value)
                        Case "OTHER THAN TAXABLE WITHIN STATE"
                            xVAT_Purchase_f = CDbl(xDgr.Cells(2).Value)
                        Case "OTHER THAN TAXABLE INTER STATE"
                            xVAT_PurchaseInterState_f = CDbl(xDgr.Cells(2).Value)
                        Case "AGAINST H FORM"
                            xVAT_Purchase_g = CDbl(xDgr.Cells(2).Value)
                        Case "UNDER SECTION 19(1) AND 20"
                            xVAT_Purchase_h = CDbl(xDgr.Cells(2).Value)
                            xVAT_PurchaseRtd_h = CDbl(xDgr.Cells(5).Value) ' GOODS RETURNS UNDER FORM 15
                            xVAT_PurchaseTax_Col2h = CDbl(xDgr.Cells(3).Value)
                        Case "UNDER SECTION 13(5)"
                            xVAT_Purchase_i = CDbl(xDgr.Cells(2).Value)
                        Case "WITHIN STATE", "CAPITAL GOODS", "UNDER WORKS CONTRACT"
                            xVAT_Purchase_l += CDbl(xDgr.Cells(2).Value)
                            xVAT_PurchaseTax_Col2l += CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)
                    End Select
                End If
            Next
            Dim X As Double = xVAT_P1 + xVAT_P4 + xVAT_P5 + xVAT_P8_8 + xVAT_P12_5 + xVAT_P20 + xVAT_P22 + xVAT_P27_5 + xVAT_P30
            Dim XITCSURCHARGE As Double = xVAT_Pr1 + xVAT_Pr4 + xVAT_Pr5 + xVAT_Pr8_8 + xVAT_Pr12_5 + xVAT_Pr20 + xVAT_Pr22 + xVAT_Pr27_5 + xVAT_Pr30
            Dim XITC As Double = xVAT_PTx1 + xVAT_PTx4 + xVAT_PTx5 + xVAT_PTx8_8 + xVAT_PTx12_5 + xVAT_PTx20 + xVAT_PTx22 + xVAT_PTx27_5 + xVAT_PTx30
            Me.TxtInput.Text = FormatNumber(XITC + XITCSURCHARGE, 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub xxSetValzeroPurVari()
        Try
            xVAT_P1 = 0
            xVAT_P4 = 0
            xVAT_P5 = 0
            xVAT_P8_8 = 0
            xVAT_P12_5 = 0
            xVAT_P13_5 = 0
            xVAT_P20 = 0
            xVAT_P22 = 0
            xVAT_P27_5 = 0
            xVAT_P30 = 0
            xVAT_Pothr = 0
            xVAT_Pr1 = 0
            xVAT_Pr4 = 0
            xVAT_Pr5 = 0
            xVAT_Pr8_8 = 0
            xVAT_Pr12_5 = 0
            xVAT_Pr13_5 = 0
            xVAT_Pr20 = 0
            xVAT_Pr22 = 0
            xVAT_Pr27_5 = 0
            xVAT_Pr30 = 0
            xVAT_Prothr = 0
            xVAT_Purchase_b = 0
            xVAT_Purchase_c = 0
            xVAT_Purchase_d = 0
            xVAT_Purchase_e = 0
            xVAT_Purchase_ea = 0
            xVAT_Purchase_f = 0
            xVAT_PurchaseInterState_f = 0
            xVAT_Purchase_g = 0
            xVAT_Purchase_h = 0
            xVAT_Purchase_i = 0
            xVAT_Purchase_j = 0
            xVAT_Purchase_k = 0
            xVAT_Purchase_l = 0
       
            xVAT_PTx1 = 0
            xVAT_PTx4 = 0
            xVAT_PTx5 = 0
            xVAT_PTx8_8 = 0
            xVAT_PTx12_5 = 0
            xVAT_PTx13_5 = 0
            xVAT_PTx20 = 0
            xVAT_PTx22 = 0
            xVAT_PTx27_5 = 0
            xVAT_PTx30 = 0
            xVAT_PTxothr = 0
            
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xxSetValZeroSaleVari()
        Try
            xVAT_S1 = 0
            xVAT_S4 = 0
            xVAT_S5 = 0
            xVAT_S8_8 = 0
            xVAT_S12_5 = 0
            xVAT_S13_5 = 0
            xVAT_S20 = 0
            xVAT_S22 = 0
            xVAT_S27_5 = 0
            xVAT_S30 = 0
            xVAT_Sothr = 0
            xVAT_Sr1 = 0
            xVAT_Sr4 = 0
            xVAT_Sr5 = 0
            xVAT_Sr8_8 = 0
            xVAT_Sr12_5 = 0
            xVAT_Sr13_5 = 0
            xVAT_Sr20 = 0
            xVAT_Sr22 = 0
            xVAT_Sr27_5 = 0
            xVAT_Sr30 = 0
            xVAT_Srothr = 0
            xVAT_S1C = 0
            xVAT_S4C = 0
            xVAT_S5C = 0
            xVAT_S2C = 0
            xVAT_CTx2C = 0
            xVAT_Sr2C = 0
            xVAT_S8_8C = 0
            xVAT_S12_5C = 0
            xVAT_S13_5C = 0
            xVAT_S20C = 0
            xVAT_S22C = 0
            xVAT_S27_5C = 0
            xVAT_S30C = 0
            xVAT_SothrC = 0
            xVAT_Sr1C = 0
            xVAT_Sr4C = 0
            xVAT_Sr5C = 0
            xVAT_Sr8_8C = 0
            xVAT_Sr12_5C = 0
            xVAT_Sr13_5C = 0
            xVAT_Sr20C = 0
            xVAT_Sr22C = 0
            xVAT_Sr27_5C = 0
            xVAT_Sr30C = 0
            xVAT_SrothrC = 0
            xVAT_S1Cdg = 0
            xVAT_S1CdgUn = 0
            xVAT_S1CUn = 0
            xVAT_S1Cbt = 0
            xVAT_Sale_a = 0
            xVAT_Sale_b = 0
            xVAT_Sale_c = 0
            xVAT_Sale_cA = 0
            xVAT_Sale_d = 0
            xVAT_Sale_e = 0
            xVAT_Sale_ea = 0
            xVAT_Sale_f = 0
            xVAT_Sale_g = 0
            xVAT_Sale_h = 0
            xVAT_Sale_i = 0
            xVAT_Sale_j = 0

            xVAT_STx1 = 0
            xVAT_STx4 = 0
            xVAT_STx5 = 0
            xVAT_STx8_8 = 0
            xVAT_STx12_5 = 0
            xVAT_STx13_5 = 0
            xVAT_STx20 = 0
            xVAT_STx22 = 0
            xVAT_STx27_5 = 0
            xVAT_STx30 = 0
            xVAT_STxothr = 0
            xVAT_CTx1C = 0
            xVAT_CTx4C = 0
            xVAT_CTx5C = 0
            xVAT_CTx8_8C = 0
            xVAT_CTx12_5C = 0
            xVAT_CTx13_5C = 0
            xVAT_CTx20C = 0
            xVAT_CTx22C = 0
            xVAT_CTx27_5C = 0
            xVAT_CTx30C = 0
            xVAT_CTxothrC = 0
            VAT16EXPORTSALE = 0
        Catch ex As Exception
            
        End Try
    End Sub
    Private Sub xReSETvALS()
        Try
            Me.TXTAMOUNT.Text = 0
            Me.TxtBFitc.Text = 0
            Me.TXTCHNO.Text = ""
            Me.TxtCST.Text = 0
            Me.TXTDATE.Text = ""
            Me.TXTDRAWON.Text = ""
            Me.TxtInput.Text = 0
            Me.TxtNetStatus.Text = 0
            Me.TxtVAT.Text = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnV16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnV16.Click
        Try
            xVAT_DtF = Me.DtpVAT1.Value.Date
            xVAT_DtT = Me.DtpVAT2.Value.Date
            VAT16MNAME = Me.CmbxPeriod.Text.Trim
            VAT16PRVS = CDbl(Me.TxtBFitc.Text)
            VAT16ITC = CDbl(Me.TxtInput.Text)
            VAT16VAT = CDbl(Me.TxtVAT.Text)
            VAT16CST = CDbl(Me.TxtCST.Text)
            VAT16AMOUNT = CDbl(Me.TxtNetStatus.Text)
            VAT16CHNO = Me.TXTCHNO.Text.Trim
            VAT16DT = Me.TXTDATE.Text.Trim
            VAT16DRAW = Me.TXTDRAWON.Text.Trim
            VAT16STATUS = Me.LblStatus.Text.Trim

            Dim FrmV16 As New FrmCrRptVAT16
            FrmV16.ShowInTaskbar = False
            FrmV16.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub


End Class
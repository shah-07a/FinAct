Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat15PartI
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader

    Private Sub FrmVAT_vat15_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            xVAT_Flag1_2 = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xTRUNCATETABLES()
        Try
            Try
                If FinActConn.State Then FinActConn.Close()
                FinActConn.Open()
                VATcmd = New SqlCommand("TRUNCATE TABLE Finact_Temp_VAT_SaleEntry", FinActConn)
                VATcmd.ExecuteNonQuery()
                VATcmd.Dispose()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmVAT_vat15PartI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Text = Me.Text & "      FROM:- " & xVAT_DtF & "   TO:- " & xVAT_DtT
            If xVAT_Flag1_2 = False Then
                x_VAT_Forms_xFillSalePurTable("Finact_Rpt_VAT_Saleentry_FillTable", xVAT_DtF, xVAT_DtT)
            End If
            xFill_DgSale_WithSaleCategories()
            If Me.DgSales.RowCount > 0 Then
                Me.BtnNxt.Enabled = True
                Me.BtnNxt.Visible = True
            Else
                Me.BtnNxt.Enabled = False
                Me.BtnNxt.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnOK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEXIT.GotFocus, BtnNxt.GotFocus, Btnback.GotFocus
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOK_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEXIT.Leave, BtnNxt.Leave, Btnback.Leave
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Transparent
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
                    Me.DgSales.Rows(xS).Cells(2).Value = FormatNumber(VATrdr("VRATE"), 2)
                    Dim txa As Double = FormatNumber(VATrdr("TXABLAMT"), 2)
                    Me.DgSales.Rows(xS).Cells(1).Value = FormatNumber(VATrdr("TXABLAMT"), 2)
                    Me.DgSales.Rows(xS).Cells(3).Value = FormatNumber(VATrdr("VAMT"), 0)
                    Me.DgSales.Rows(xS).Cells(4).Value = FormatNumber(VATrdr("SURCHARG"), 0) 'surcharge
                    Me.DgSales.Rows(xS).Cells(5).Value = FormatNumber(0, 0) 'return
                    Me.DgSales.Rows(xS).Cells(6).Value = FormatNumber(0, 0) 'Discount
                    Me.DgSales.Rows(xS).Cells(7).Value = FormatNumber(0, 0) 'vat/cst on return
                    Me.DgSales.Rows(xS).Cells(8).Value = Trim(VATrdr("PURENTTYPE")) 'TYPE
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
            Me.DgSales.Rows(xMax).Cells(1).Style.BackColor = Color.Yellow
            Me.DgSales.Rows(xMax).Cells(3).Style.BackColor = Color.Yellow
            Me.DgSales.Rows(xMax).Cells(4).Style.BackColor = Color.Yellow
            Me.DgSales.Rows(xMax).Cells(5).Style.BackColor = Color.Yellow
            Me.DgSales.Rows(xMax).Cells(6).Style.BackColor = Color.Yellow
            Me.DgSales.Rows(xMax).Cells(7).Style.BackColor = Color.Yellow
            For Each dgr As DataGridViewRow In Me.DgSales.Rows
                xTGS += dgr.Cells(1).Value
                xVAMT += dgr.Cells(3).Value
                xSur += dgr.Cells(4).Value
                xRtrn += dgr.Cells(5).Value
                xVCR += dgr.Cells(6).Value
            Next
            Me.DgSales.Rows(xMax).Cells(1).Value = FormatNumber(xTGS, 0)
            Me.DgSales.Rows(xMax).Cells(3).Value = FormatNumber(xVAMT, 0)
            Me.DgSales.Rows(xMax).Cells(4).Value = FormatNumber(xSur, 0)
            Me.DgSales.Rows(xMax).Cells(5).Value = FormatNumber(xRtrn, 0)
            Me.DgSales.Rows(xMax).Cells(6).Value = FormatNumber(xVCR, 0)
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

            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DgSales.Rows.Add()
                    Me.DgSales.Rows(xSMX).Cells(0).Value = Trim(VATrdr("SALETYPE"))
                    Me.DgSales.Rows(xSMX).Cells(1).Value = FormatNumber(VATrdr("TXABLAMT"), 0)
                    Me.DgSales.Rows(xSMX).Cells(3).Value = FormatNumber(VATrdr("VAMT"), 0)
                    Me.DgSales.Rows(xSMX).Cells(4).Value = FormatNumber(VATrdr("SURCHARG"), 0)
                    xSMX += 1
                End If
            End While
            Me.DgSales.Columns(0).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
            Me.DgSales.Columns(1).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgSales.Columns(2).DefaultCellStyle.BackColor = Color.LightYellow
            Me.DgSales.Columns(3).DefaultCellStyle.BackColor = Color.LightPink
            Me.DgSales.Columns(4).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgSales.Columns(5).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgSales.Columns(6).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgSales.Columns(7).DefaultCellStyle.BackColor = Color.LightCyan
            VATcmd.Dispose()
            VATrdr.Close()

            VATcmd = New SqlCommand("FinactSALEItemBackRecdEntry_Sale_Vat15_Select", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATcmd.Parameters.AddWithValue("@xDtF", xVAT_DtF)
            VATcmd.Parameters.AddWithValue("@xDtT", xVAT_DtT)
            VATrdr = VATcmd.ExecuteReader
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    For Each xDrowx As DataGridViewRow In Me.DgSales.Rows
                        If xDrowx.Index = xSaleRtd Then Exit For
                        If Trim(xDrowx.Cells(8).Value) = Trim(VATrdr("SalepurType")) And FormatNumber(xDrowx.Cells(2).Value, 2) = FormatNumber(VATrdr("VatRate"), 2) Then
                            xDrowx.Cells(5).Value = FormatNumber(VATrdr("TxAblAmt"), 0)
                            xDrowx.Cells(7).Value = FormatNumber(VATrdr("Vamt") + VATrdr("SurCharg"), 0)
                        End If

                    Next
                End If
            End While
            VATcmd.Dispose()
            VATrdr.Close()
            Dim xRtd As Double = 0
            Dim xRtdVat As Double = 0
            For Each dgr As DataGridViewRow In Me.DgSales.Rows
                If dgr.Index = xSaleRtd Then Exit For
                xRtd += dgr.Cells(5).Value
                xRtdVat += dgr.Cells(7).Value
            Next
            Me.DgSales.Rows(xSaleRtd).Cells(5).Value = FormatNumber(xRtd, 0)
            Me.DgSales.Rows(xSaleRtd).Cells(7).Value = FormatNumber(xRtdVat, 0)

            VATcmd = New SqlCommand("Finact_SaleItemBackRecdEntry_Sale_Vat15_Summary_Select", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    For Each xDrowx As DataGridViewRow In Me.DgSales.Rows
                        If xDrowx.Index > xSaleRtd Then
                            If Trim(xDrowx.Cells(0).Value) = Trim(VATrdr("SalepurType")) Then
                                xDrowx.Cells(5).Value = FormatNumber(VATrdr("TxAblAmt"), 0)
                                xDrowx.Cells(7).Value = FormatNumber(VATrdr("Vamt") + VATrdr("SurCharg"), 0)
                            End If
                        End If
                    Next
                End If
            End While
            VATcmd.Dispose()
            VATrdr.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub
    Private Sub BtnEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEXIT.Click
        Try
            If MessageBox.Show("Are you sure to quit current session?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                Me.Close()
            Else
                Return
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNxt.Click
        Try
            xOnNxtSalesCalc()
            Dim xFrmP2 As New FrmVAT_vat15PartII
            xFrmP2.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP2)
            xFrmP2.BringToFront()
            xFrmP2.Show()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xOnNxtSalesCalc()
        Try
            If Me.DgSales.RowCount = 0 Then Exit Sub
            Dim xVATRTD As Double = 0
            xVAT_OutputTAX = 0
            xCST_OutputTAX = 0
            xxSetValZeroSaleVari()
            For Each xDgr As DataGridViewRow In Me.DgSales.Rows
                If Trim(xDgr.Cells(8).Value) = "WITHIN STATE" Or Trim(xDgr.Cells(8).Value) = "UNDER WORKS CONTRACT" Or Trim(xDgr.Cells(8).Value) = "WITHIN STATE UN-REGD. DEALER" Then
                    Select Case CDbl(xDgr.Cells(2).Value)
                        Case 1.0
                            xVAT_S1 += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr1 += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 4.0
                            xVAT_S4 += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr4 += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 5.0
                            xVAT_S5 += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr5 += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 8.8
                            xVAT_S8_8 += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr8_8 = Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 12.5
                            xVAT_S12_5 += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr12_5 += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 13.5
                            xVAT_S13_5 += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr13_5 += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 20.0
                            xVAT_S20 += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr20 += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 22.0
                            xVAT_S22 += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr22 += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 27.5
                            xVAT_S27_5 += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr27_5 += Math.Round(CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value), 0)
                        Case 30.0
                            xVAT_S30 += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr30 += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case Else
                            xVAT_Sothr += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Srothr += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                    End Select
                End If
                '===CST SECTION
                If Trim(xDgr.Cells(8).Value) = "INTER STATE" Or Trim(xDgr.Cells(8).Value) = "INTER STATE EXEMPTED" Or Trim(xDgr.Cells(8).Value) = "UNDER WORKS CONTRACT INTERSTATE" _
                Or Trim(xDgr.Cells(8).Value) = "INTER STATE DECLARED GOODS" Or Trim(xDgr.Cells(8).Value) = "INTER STATE DECLARED GOODS UN-REGD." Or Trim(xDgr.Cells(8).Value) = "INTER STATE UN-REGD. DEALER" _
               Or Trim(xDgr.Cells(8).Value) = "INTER STATE BRANCH TRANSFER" Then
                    Select Case CDbl(xDgr.Cells(2).Value)
                        Case 1.0, 2.0
                            xVAT_S1C += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr1C += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 4.0
                            xVAT_S4C += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr4C += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 5.0, 5.5
                            xVAT_S5C += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr5C += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 8.8
                            xVAT_S8_8C += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr8_8C = Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 12.5
                            xVAT_S12_5C += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr12_5C += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 13.5, 13.75
                            xVAT_S13_5C += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr13_5C += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 20.0
                            xVAT_S20C += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr20C += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 22.0
                            xVAT_S22C += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr22C += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case 27.5
                            xVAT_S27_5C += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr27_5C += Math.Round(CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value), 0)
                        Case 30.0
                            xVAT_S30C += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_Sr30C += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                        Case Else
                            xVAT_SothrC += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                            xVAT_SrothrC += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                    End Select
                End If

                Select Case Trim(xDgr.Cells(8).Value)
                    Case "INTER STATE DECLARED GOODS"
                        xVAT_S1Cdg += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                    Case "INTER STATE DECLARED GOODS UN-REGD."
                        xVAT_S1CdgUn += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                    Case "INTER STATE UN-REGD. DEALER"
                        xVAT_S1CUn += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                    Case "INTER STATE BRANCH TRANSFER"
                        xVAT_S1Cbt += Math.Round(CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value), 0)
                End Select

                '===END OF CST SECTION
                If xDgr.Index = xVAT_DgSaleRowIndx - 2 Then
                    xVAT_Sale_a = Math.Round(CDbl(xDgr.Cells(1).Value), 0)
                End If
                If xDgr.Index >= xVAT_DgSaleRowIndx Then
                    Dim xx As String = Trim(xDgr.Cells(0).Value)
                    Select Case Trim(xDgr.Cells(0).Value)
                        Case "WITHIN STATE EXEMPTED"
                            xVAT_Sale_b = Math.Round(CDbl(xDgr.Cells(1).Value), 0)
                            xVAT_SaleRtd_b = Math.Round(CDbl(xDgr.Cells(5).Value), 0) ' GOODS RETURNS UNDER FORM 15
                        Case "EXPORT DIRECT"
                            xVAT_Sale_c = Math.Round(CDbl(xDgr.Cells(1).Value), 0)
                            xVAT_SaleRtd_c = Math.Round(CDbl(xDgr.Cells(5).Value), 0) ' GOODS RETURNS UNDER FORM 1
                        Case "AGAINST H FORM"
                            xVAT_Sale_cA = Math.Round(CDbl(xDgr.Cells(1).Value), 0)
                            xVAT_SaleRtd_cA = Math.Round(CDbl(xDgr.Cells(5).Value), 0) ' GOODS RETURNS UNDER FORM 1
                        Case "INTER STATE", "INTER STATE EXEMPTED", "UNDER WORKS CONTRACT INTERSTATE", "INTER STATE DECLARED GOODS", _
                        "INTER STATE DECLARED GOODS UN-REGD.", "INTER STATE UN-REGD. DEALER", "INTER STATE BRANCH TRANSFER"
                            xVAT_Sale_d += Math.Round(CDbl(xDgr.Cells(1).Value), 0)
                            xCST_OutputTAX += Math.Round(CDbl(xDgr.Cells(3).Value), 0)
                            xVAT_SaleRtd_d += Math.Round(CDbl(xDgr.Cells(5).Value), 0) ' GOODS RETURNS UNDER FORM 1
                        Case "INTER STATE TAX FREE"
                            xVAT_Sale_ea = Math.Round(CDbl(xDgr.Cells(1).Value), 0)
                            xVAT_SaleRtd_ea = Math.Round(CDbl(xDgr.Cells(5).Value), 0) ' GOODS RETURNS UNDER FORM 1
                        Case "WITHIN STATE TAX FREE"
                            xVAT_Sale_e = Math.Round(CDbl(xDgr.Cells(1).Value), 0)
                            xVAT_SaleRtd_e = Math.Round(CDbl(xDgr.Cells(5).Value), 0) ' GOODS RETURNS UNDER FORM 15
                        Case "FROM EXMPT.UNIT SOLD TO OTHER THAN TAXABLE PRSN"
                            xVAT_Sale_h = Math.Round(CDbl(xDgr.Cells(1).Value), 0)
                            xVAT_SaleRtd_h = Math.Round(CDbl(xDgr.Cells(5).Value), 0) ' GOODS RETURNS UNDER FORM 15
                        Case "WITHIN STATE", "UNDER WORKS CONTRACT", "WITHIN STATE UN-REGD. DEALER"
                            xVAT_Sale_j += Math.Round(CDbl(xDgr.Cells(1).Value), 0)
                            xVAT_OutputTAX += Math.Round((CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) - CDbl(xDgr.Cells(7).Value), 0)
                            '-- xVATRTD += CDbl(xDgr.Cells(7).Value)
                            xVAT_SaleRtd_j += Math.Round(CDbl(xDgr.Cells(5).Value), 0) ' GOODS RETURNS UNDER FORM 15
                    End Select
                End If
            Next
            xVAT_Sale_f = Math.Round(CDbl(xVAT_SaleRtd_b + xVAT_SaleRtd_e + xVAT_SaleRtd_h + xVAT_SaleRtd_j), 0)
            xVAT_Sale_g = 0
            xVAT_Sale_i = 0
        Catch ex As Exception
            MsgBox(ex.Message)
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
            xVAT_SaleRtd_b = 0
            xVAT_SaleRtd_c = 0
            xVAT_SaleRtd_cA = 0
            xVAT_SaleRtd_a = 0
            xVAT_SaleRtd_d = 0
            xVAT_SaleRtd_e = 0
            xVAT_SaleRtd_ea = 0
            xVAT_SaleRtd_f = 0
            xVAT_SaleRtd_g = 0
            xVAT_SaleRtd_h = 0
            xVAT_SaleRtd_i = 0
            xVAT_SaleRtd_j = 0
        Catch ex As Exception

        End Try
    End Sub
 
    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Try
            Me.Close()
            Dim xFrmPPA As New FrmVAT_vat15_PriorPerdAdjstmnt
            xFrmPPA.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmPPA)
            xFrmPPA.BringToFront()
            xFrmPPA.Show()
        Catch ex As Exception

        End Try
    End Sub
End Class
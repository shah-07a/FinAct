Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat15PartII
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader

    Private Sub FrmVAT_vat15_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            xVAT_Flag1_2a = True
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
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmVAT_vat15PartII_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Text = Me.Text & "      FROM:- " & xVAT_DtF & "   TO:- " & xVAT_DtT
            If xVAT_Flag1_2a = False Then
                x_VAT_Forms_xFillSalePurTable("Finact_Rpt_VAT_Purentry_FillTable", xVAT_DtF, xVAT_DtT)
            End If
            xFill_DgPurchase_WithPurchaseCategories()
            If Me.DgPurchase.RowCount > 0 Then
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
                    Me.DgPurchase.Rows(xP).Cells(2).Value = FormatNumber(VATrdr("VRATE"), 2)
                    Me.DgPurchase.Rows(xP).Cells(1).Value = FormatNumber(VATrdr("TXABLAMT"), 0)
                    Me.DgPurchase.Rows(xP).Cells(3).Value = FormatNumber(VATrdr("VAMT"), 0)
                    Me.DgPurchase.Rows(xP).Cells(4).Value = FormatNumber(VATrdr("SURCHARG"), 0) 'surcharge
                    Me.DgPurchase.Rows(xP).Cells(5).Value = FormatNumber(0, 0) 'return
                    Me.DgPurchase.Rows(xP).Cells(6).Value = FormatNumber(0, 0) 'Discount
                    Me.DgPurchase.Rows(xP).Cells(7).Value = FormatNumber(0, 0) 'vat/cst on return
                    Me.DgPurchase.Rows(xP).Cells(8).Value = Trim(VATrdr("purenttype")) 'Category
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
            Me.DgPurchase.Rows(xMax).Cells(1).Style.BackColor = Color.Yellow
            Me.DgPurchase.Rows(xMax).Cells(3).Style.BackColor = Color.Yellow
            Me.DgPurchase.Rows(xMax).Cells(4).Style.BackColor = Color.Yellow
            Me.DgPurchase.Rows(xMax).Cells(5).Style.BackColor = Color.Yellow
            Me.DgPurchase.Rows(xMax).Cells(6).Style.BackColor = Color.Yellow

            For Each dgr As DataGridViewRow In Me.DgPurchase.Rows
                xTGS += dgr.Cells(1).Value
                xVAMT += dgr.Cells(3).Value
                xSur += dgr.Cells(4).Value
                xRtrn += dgr.Cells(5).Value
                xVCR += dgr.Cells(6).Value
            Next
            Me.DgPurchase.Rows(xMax).Cells(1).Value = FormatNumber(xTGS, 0)
            Me.DgPurchase.Rows(xMax).Cells(3).Value = FormatNumber(xVAMT, 0)
            Me.DgPurchase.Rows(xMax).Cells(4).Value = FormatNumber(xSur, 0)
            Me.DgPurchase.Rows(xMax).Cells(5).Value = FormatNumber(xRtrn, 0)
            Me.DgPurchase.Rows(xMax).Cells(6).Value = FormatNumber(xVCR, 0)
            Me.DgPurchase.Rows.Add()
            'Me.DgPurchase.Rows.Add()

            VATcmd = New SqlCommand("Finact_SalePurCatgry_Purchase_Vat15_Summary_Select", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader

            Dim xSMX As Integer = Me.DgPurchase.RowCount
            Dim xPurRtd As Integer = xSMX - 2
            xVAT_DgPurchaseRowIndx = CInt(xSMX)
            Me.DgPurchase.Rows(xSMX - 1).Cells(0).Value = "SUMMARY"
            Me.DgPurchase.Rows(xSMX - 1).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgPurchase.Rows(xSMX - 1).Cells(0).Style.ForeColor = Color.Black

            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DgPurchase.Rows.Add()
                    Me.DgPurchase.Rows(xSMX).Cells(0).Value = Trim(VATrdr("PURTYPE"))
                    Me.DgPurchase.Rows(xSMX).Cells(1).Value = FormatNumber(VATrdr("TXABLAMT"), 0)
                    Me.DgPurchase.Rows(xSMX).Cells(3).Value = FormatNumber(VATrdr("VAMT"), 0)
                    Me.DgPurchase.Rows(xSMX).Cells(4).Value = FormatNumber(VATrdr("SURCHARG"), 0)
                    xSMX += 1
                End If
            End While
            Me.DgPurchase.Columns(0).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
            Me.DgPurchase.Columns(1).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgPurchase.Columns(2).DefaultCellStyle.BackColor = Color.LightYellow
            Me.DgPurchase.Columns(3).DefaultCellStyle.BackColor = Color.LightPink
            Me.DgPurchase.Columns(4).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgPurchase.Columns(5).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgPurchase.Columns(6).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgPurchase.Columns(7).DefaultCellStyle.BackColor = Color.LightCyan
            VATcmd.Dispose()
            VATrdr.Close()

            VATcmd = New SqlCommand("FinactPurItemBackRecdEntry_Purchase_Vat15_Select", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATcmd.Parameters.AddWithValue("@xDtF", xVAT_DtF)
            VATcmd.Parameters.AddWithValue("@xDtT", xVAT_DtT)
            VATrdr = VATcmd.ExecuteReader
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    For Each xDrowx As DataGridViewRow In Me.DgPurchase.Rows
                        If xDrowx.Index = xPurRtd Then Exit For
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
            For Each dgr As DataGridViewRow In Me.DgPurchase.Rows
                If dgr.Index = xPurRtd Then Exit For
                xRtd += dgr.Cells(5).Value
                xRtdVat += dgr.Cells(7).Value
            Next
            Me.DgPurchase.Rows(xPurRtd).Cells(5).Value = FormatNumber(xRtd, 0)
            Me.DgPurchase.Rows(xPurRtd).Cells(7).Value = FormatNumber(xRtdVat, 0)

            VATcmd = New SqlCommand("Finact_PurItemBackRecdEntry_Purchase_Vat15_Summary_Select", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    For Each xDrowx As DataGridViewRow In Me.DgPurchase.Rows
                        If xDrowx.Index > xPurRtd Then
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
            xOnNxtPurchaseCalc()
            Dim xFrmP2 As New FrmVAT_Vat15_Deductns
            xFrmP2.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP2)
            xFrmP2.BringToFront()
            xFrmP2.Show()
            Me.Close()
        Catch ex As Exception

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
            xVAT_Purchase_g = 0
            xVAT_Purchase_h = 0
            xVAT_Purchase_i = 0
            xVAT_Purchase_j = 0
            xVAT_Purchase_k = 0
            xVAT_Purchase_l = 0
            xVAT_PurchaseRtd_b = 0
            xVAT_PurchaseRtd_c = 0
            xVAT_PurchaseRtd_a = 0
            xVAT_PurchaseRtd_d = 0
            xVAT_PurchaseRtd_e = 0
            xVAT_PurchaseRtd_ea = 0
            xVAT_PurchaseRtd_f = 0
            xVAT_PurchaseRtd_g = 0
            xVAT_PurchaseRtd_h = 0
            xVAT_PurchaseRtd_i = 0
            xVAT_PurchaseRtd_j = 0
            xVAT_PurchaseRtd_k = 0
            xVAT_PurchaseRtd_l = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xOnNxtPurchaseCalc()
        Try
            If Me.DgPurchase.RowCount = 0 Then Exit Sub
            Dim xCST As Double = 0 'HANDLES TAX ON INTER-STATE PURCHASES AS IT IS NOT REFUNDABLE. IT IS INCLUDED IN NET PURCHASE 
            xVAT_PurchaseTax_Col2h = 0
            xVAT_PurchaseTax_Col2l = 0
            xVAT_Purchase_d = 0
            xxSetValzeroPurVari()
            For Each xDgr As DataGridViewRow In Me.DgPurchase.Rows
                If Trim(xDgr.Cells(8).Value) = "WITHIN STATE" Or Trim(xDgr.Cells(8).Value) = "UNDER WORKS CONTRACT" Or Trim(xDgr.Cells(8).Value) = "CAPITAL GOODS" Then
                    Select Case CDbl(xDgr.Cells(2).Value)
                        Case 1.0
                            xVAT_P1 += CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value)
                            xVAT_Pr1 += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                        Case 4.0
                            xVAT_P4 += CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value)
                            xVAT_Pr4 += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                        Case 5.0
                            xVAT_P5 += CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value)
                            xVAT_Pr5 += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                        Case 8.8
                            xVAT_P8_8 += CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value)
                            xVAT_Pr8_8 += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                        Case 12.5
                            xVAT_P12_5 += CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value)
                            xVAT_Pr12_5 += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                        Case 13.5
                            xVAT_P13_5 += CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value)
                            xVAT_Pr13_5 += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                        Case 20.0
                            xVAT_P20 += CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value)
                            xVAT_Pr20 += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                        Case 22.0
                            xVAT_P22 += xDgr.Cells(1).Value - CDbl(xDgr.Cells(5).Value)
                            xVAT_Pr22 += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                        Case 27.5
                            xVAT_P27_5 += CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value)
                            xVAT_Pr27_5 += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                        Case 30.0
                            xVAT_P30 += CDbl(xDgr.Cells(1).Value) - CDbl(xDgr.Cells(5).Value)
                            xVAT_Pr30 += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                        Case Else
                            xVAT_Pothr += xDgr.Cells(1).Value - CDbl(xDgr.Cells(5).Value)
                            xVAT_Prothr += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                    End Select
                End If

                If xDgr.Index = xVAT_DgPurchaseRowIndx - 2 Then
                    xVAT_Purchase_a = CDbl(xDgr.Cells(1).Value)

                End If
                If xDgr.Index >= xVAT_DgPurchaseRowIndx Then
                    Dim xx As String = Trim(xDgr.Cells(0).Value)
                    Select Case Trim(xDgr.Cells(0).Value)
                        Case "IMPORT DIRECT"
                            xVAT_Purchase_b = CDbl(xDgr.Cells(1).Value)
                            xVAT_PurchaseRtd_b = CDbl(xDgr.Cells(5).Value) ' GOODS RETURNS UNDER FORM 1
                        Case "BRANCH/PRINCIPALS TRANSFER INTERSTATE", "INTER STATE", "INTER STATE EXEMPTED", "UNDER WORKS CONTRACT INTERSTATE"
                            xVAT_Purchase_c += CDbl(xDgr.Cells(1).Value) + CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)
                            xVAT_PurchaseRtd_c += CDbl(xDgr.Cells(5).Value) ' GOODS RETURNS UNDER FORM 1
                            xCST += CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)
                        Case "WITHIN STATE EXEMPTED"
                            xVAT_Purchase_d = CDbl(xDgr.Cells(1).Value)
                            xVAT_PurchaseRtd_d = CDbl(xDgr.Cells(5).Value)  ' GOODS RETURNS UNDER FORM 15.5
                        Case "INTER STATE TAX FREE"
                            xVAT_Purchase_ea = CDbl(xDgr.Cells(1).Value)
                            xVAT_PurchaseRtd_ea = CDbl(xDgr.Cells(5).Value) ' GOODS RETURNS UNDER FORM 1
                        Case "WITHIN STATE TAX FREE"
                            xVAT_Purchase_e = CDbl(xDgr.Cells(1).Value)
                            xVAT_PurchaseRtd_e = CDbl(xDgr.Cells(5).Value) ' GOODS RETURNS UNDER FORM 15
                        Case "OTHER THAN TAXABLE"
                            xVAT_Purchase_f = CDbl(xDgr.Cells(1).Value)
                            xVAT_PurchaseRtd_f = CDbl(xDgr.Cells(5).Value) ' GOODS RETURNS UNDER FORM 15
                        Case "AGAINST H FORM"
                            xVAT_Purchase_g = CDbl(xDgr.Cells(1).Value)
                            xVAT_PurchaseRtd_g = CDbl(xDgr.Cells(5).Value) ' GOODS RETURNS UNDER FORM 1
                        Case "UNDER SECTION 19(1) AND 20"
                            xVAT_Purchase_h = CDbl(xDgr.Cells(1).Value)
                            xVAT_PurchaseRtd_h = CDbl(xDgr.Cells(5).Value) ' GOODS RETURNS UNDER FORM 15
                            xVAT_PurchaseTax_Col2h = CDbl(xDgr.Cells(3).Value)
                        Case "UNDER SECTION 13(5)"
                            xVAT_Purchase_i = CDbl(xDgr.Cells(1).Value)
                            xVAT_PurchaseRtd_i = CDbl(xDgr.Cells(5).Value) ' GOODS RETURNS UNDER FORM 15
                        Case "WITHIN STATE", "CAPITAL GOODS", "UNDER WORKS CONTRACT"
                            xVAT_Purchase_l += CDbl(xDgr.Cells(1).Value)
                            xVAT_PurchaseTax_Col2l += (CDbl(xDgr.Cells(3).Value) + CDbl(xDgr.Cells(4).Value)) + CDbl(xDgr.Cells(7).Value)
                            xVAT_PurchaseRtd_l += CDbl(xDgr.Cells(5).Value) ' GOODS RETURNS UNDER FORM 15
                    End Select
                End If
            Next
            xVAT_Purchase_a += xCST
            xVAT_Purchase_j = CDbl(xVAT_PurchaseRtd_e + xVAT_PurchaseRtd_f + xVAT_PurchaseRtd_h + xVAT_PurchaseRtd_i + xVAT_PurchaseRtd_l)
            xVAT_Purchase_k = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Try
            Me.Close()
            Dim xFrmPPA As New FrmVAT_vat15PartI
            xFrmPPA.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmPPA)
            xFrmPPA.BringToFront()
            xFrmPPA.Show()
        Catch ex As Exception

        End Try
    End Sub

  
End Class
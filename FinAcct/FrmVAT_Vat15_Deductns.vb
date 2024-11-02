Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_Vat15_Deductns
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader

    Private Sub FrmVAT_Vat15_Deductns_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            xVAT_Flag1_2 = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmVAT_vat15_Deduction(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Text = Me.Text & "      FROM:- " & xVAT_DtF & "   TO:- " & xVAT_DtT
            xxFillDgSale2()
            xxFillDgPurcase2()
            ''If xVAT_Flag1_2 = True Then
            Me.BtnNxt.Enabled = True
            ''    xVAT_Flag1_2 = False
            Me.BtnNxt.Focus()
            ''Else
            ''    Me.BtnNxt.Enabled = False
            ''    Me.BtnBack.Focus()
            ''End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNxt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNxt.Click
        Try
            Me.Close()
            Dim xFrmP3 As New FrmVAT_vat15_OutputTax
            xFrmP3.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP3)
            xFrmP3.BringToFront()
            xFrmP3.Show()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnALL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEXIT.GotFocus, BtnBack.GotFocus, BtnNxt.GotFocus
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnALL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEXIT.Leave, BtnBack.Leave, BtnNxt.Leave
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Transparent
        Catch ex As Exception

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

    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Try
            Me.Close()
            Dim xFrm15 As New FrmVAT_vat15PartII
            xFrm15.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrm15)
            xFrm15.BringToFront()
            xFrm15.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xxFillDgSale2()
        Try
            Me.DgSales.Rows.Clear()
            Me.DgSales.AllowUserToAddRows = False
            Me.DgSales.Rows.Add(10)
            Me.DgSales.Rows(0).Cells(0).Value = (" (a) GROSS SALES")
            Me.DgSales.Rows(1).Cells(0).Value = (" (b) Less: Sales Within The State By Exempted Units")
            Me.DgSales.Rows(2).Cells(0).Value = (" (c) Less: Zero Rated Sales")
            Me.DgSales.Rows(3).Cells(0).Value = (" (d) Less: Inter-State Sales")
            Me.DgSales.Rows(4).Cells(0).Value = (" (e) Less: Tax Free Sales")
            Me.DgSales.Rows(5).Cells(0).Value = (" (f)  Less: Sales Return, Cash/Trade Discount")
            Me.DgSales.Rows(6).Cells(0).Value = (" (g) Less: Tax Element Included In Sales")
            Me.DgSales.Rows(7).Height = Me.DgSales.Rows(6).Height * 1.5
            Me.DgSales.Rows(7).Cells(0).Value = (" (h) Less: Purchase Value Of Sale Of Goods, Purchased From Exempted Units And Sold To Person Other Than Taxable Persons")
            Me.DgSales.Rows(8).Cells(0).Value = (" (i)  Less: Any Other Deduction, Please Specify")
            Me.DgSales.Rows(9).Cells(0).Value = (" (j)  NET SALES SUBJECT TO VAT")

            Me.DgSales.Rows(0).Cells(1).Value = FormatNumber(xVAT_Sale_a, 2) ' (a) GROSS SALES")
            Me.DgSales.Rows(1).Cells(1).Value = FormatNumber(xVAT_Sale_b, 2) '  (b) Less: Sales within the state by exempted units")
            Me.DgSales.Rows(2).Cells(1).Value = FormatNumber(xVAT_Sale_c + xVAT_Sale_cA, 2) ' (c) Less: Zero rated sales")
            Me.DgSales.Rows(3).Cells(1).Value = FormatNumber((xVAT_Sale_d + xVAT_Sale_ea), 2) '  (d) Less: Inter-state sales")+INTERSTATE TAX FREE
            Me.DgSales.Rows(4).Cells(1).Value = FormatNumber(xVAT_Sale_e, 2) '  (e) Less: Tax free sales")
            Me.DgSales.Rows(5).Cells(1).Value = FormatNumber(xVAT_Sale_f, 2) '  (f)  Less: Sales return, Cash/trade discount")
            Me.DgSales.Rows(6).Cells(1).Value = FormatNumber(xVAT_Sale_g, 2) '  (g) Less: Tax element included in sales")
            Me.DgSales.Rows(7).Cells(1).Value = FormatNumber(xVAT_Sale_h, 2) '  (h) Less: Purchase value of sale of goods, purchased from exempted units and sold to person other than taxable persons")
            Me.DgSales.Rows(8).Cells(1).Value = FormatNumber(xVAT_Sale_i, 2) ' (i)  Less: Any other deduction, please specify")
            Me.DgSales.Rows(9).Cells(1).Value = FormatNumber(xVAT_Sale_j - xVAT_Sale_f, 2) '  (j)  NET SALES SUBJECT TO VAT")
            Me.DgSales.Rows(9).DefaultCellStyle.BackColor = Color.Yellow
            Me.DgSales.Columns(0).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgSales.Columns(1).DefaultCellStyle.BackColor = Color.LightYellow
           
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub xxFillDgPurcase2()
        Try
            Me.DgPurchase.Rows.Clear()
            Me.DgPurchase.AllowUserToAddRows = False
            Me.DgPurchase.Rows.Add(12)
            Me.DgPurchase.Rows(0).Cells(0).Value = (" (a) GROSS PURCHASE (INCLUDING CAPITAL GOODS AND GOODS RECEIVED BY STOCK TRANSFER")
            Me.DgPurchase.Rows(1).Cells(0).Value = (" (b) Less: Imports From Outside India")
            Me.DgPurchase.Rows(2).Cells(0).Value = (" (c) Less: Inter-State Purchases/Goods Received From Branches/Principals")
            Me.DgPurchase.Rows(3).Cells(0).Value = (" (d) Less: Purchases Made Directly From Exempted Units")
            Me.DgPurchase.Rows(4).Cells(0).Value = (" (e) Less: Tax Free Purchases")
            Me.DgPurchase.Rows(5).Cells(0).Value = (" (f)  Less: Purchase From Persons Other Than Taxable Persons")
            Me.DgPurchase.Rows(6).Cells(0).Value = (" (g) Less: Purchases Against 'H' Form")
            ' Me.DgPurchase.Rows(7).Height = Me.DgPurchase.Rows(6).Height * 1.5
            Me.DgPurchase.Rows(7).Cells(0).Value = (" (h) Less: Purchases Liable To Purchase Tax u/s 19(1) And 20 In The Hands Of The Person Filling The Return")
            Me.DgPurchase.Rows(8).Cells(0).Value = (" (i)  Less: Purchases Not Eligible For Input Tax Credit Under Section 13(5)")
            Me.DgPurchase.Rows(9).Cells(0).Value = (" (j)  Less: Purchases Return And Cash/Trade Discount")
            Me.DgPurchase.Rows(10).Cells(0).Value = (" (k)  Less: Any Other Deduction, Please Specify")
            Me.DgPurchase.Rows(11).Cells(0).Value = (" (l)  PURCHASE ELIGIBLE FOR INPUT TAX CREDIT[a-(b+c+d+e+f+g+h+i+j+k)]")

            Me.DgPurchase.Rows(0).Cells(1).Value = FormatNumber(xVAT_Purchase_a, 2) ' (a) GROSS PURCHASE (INCLUDING CAPITAL GOODS AND GOODS RECEIVED BY STOCK TRANSFER")
            Me.DgPurchase.Rows(1).Cells(1).Value = FormatNumber(xVAT_Purchase_b, 2) ' (b) Less: Imports from outside India")
            Me.DgPurchase.Rows(2).Cells(1).Value = FormatNumber(xVAT_Purchase_c + xVAT_Purchase_ea, 2) ' (c) Less: Inter-State purchases/goods received from branches/principals")+TAX FREE INTER STATES
            Me.DgPurchase.Rows(3).Cells(1).Value = FormatNumber(xVAT_Purchase_d, 2) ' (d) Less: Purchases made directly from exempted units")
            Me.DgPurchase.Rows(4).Cells(1).Value = FormatNumber(xVAT_Purchase_e, 2) ' (e) Less: Tax free purchases")
            Me.DgPurchase.Rows(5).Cells(1).Value = FormatNumber(xVAT_Purchase_f, 2) ' (f)  Less: Purchase from persons other than taxable persons")
            Me.DgPurchase.Rows(6).Cells(1).Value = FormatNumber(xVAT_Purchase_g, 2) ' (g) Less: Purchases against 'H' form")
            ' Me.DgPurchase.Rows(7).Height = Me.DgPurchase.Rows(6).Height * 1.5
            Me.DgPurchase.Rows(7).Cells(1).Value = FormatNumber(xVAT_Purchase_h, 2) ' (h) Less: Purchases liable to purchase tax u/s 19(1)and 20 in the hands of the person filling the return")
            Me.DgPurchase.Rows(8).Cells(1).Value = FormatNumber(xVAT_Purchase_i, 2) ' (i)  Less: Purchases not eligible for input tax credit under section 13(5)")
            Me.DgPurchase.Rows(9).Cells(1).Value = FormatNumber(xVAT_Purchase_j, 2) ' (j)  Less: Purchases return and cash/trade discount")
            Me.DgPurchase.Rows(10).Cells(1).Value = FormatNumber(xVAT_Purchase_k, 2) ' (k)  Less: Any other deduction, please specify")
            Me.DgPurchase.Rows(11).Cells(1).Value = FormatNumber(xVAT_Purchase_l - xVAT_Purchase_j, 2) ' (l)  PURCHASE ELIGIBLE FOR INPUT TAX CREDIT[a-(b+c+d+e+f+g+h+i+j+k)]")
            Me.DgPurchase.Rows(11).DefaultCellStyle.BackColor = Color.Yellow
            Me.DgPurchase.Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgPurchase.Columns(1).DefaultCellStyle.BackColor = Color.LightPink
          
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

  
End Class
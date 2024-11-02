Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat15_TAXPAYABLEEXCESS
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader

    Private Sub FrmVAT_vat15_TAXPAYABLEEXCESS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            xVAT_Flag6 = True
            xFrmPayExcs1_to_2(0) = CDbl(Me.TXT1.Text)
            xFrmPayExcs1_to_2(1) = CDbl(Me.TXT2.Text)
            xDgValuesITCOT(Me.DgITCNOTNL)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmVAT_vat15_TaxPayableExcess_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Text = Me.Text & "      FROM:- " & xVAT_DtF & "   TO:- " & xVAT_DtT
            If xVAT_Flag6 = True Then
                Me.TXT1.Text = FormatNumber(xFrmPayExcs1_to_2(0), 2)
                Me.TXT2.Text = FormatNumber(xFrmPayExcs1_to_2(1), 2)
                Me.BtnOK_Click(sender, e)
            End If
            Me.TXT1.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNxt.Click
        Try
            Me.Close()
            Dim xFrmP7 As New FrmVAT_vat15_UntAvlExmpt
            xFrmP7.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP7)
            xFrmP7.BringToFront()
            xFrmP7.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Try
            Me.Close()
            Dim xFrmP6 As New FrmVAT_vat15_ExmptUnt
            xFrmP6.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP6)
            xFrmP6.BringToFront()
            xFrmP6.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xxFillDgITCNOTNL6()
        Try
            Me.DgITCNOTNL.Rows.Clear()
            Me.DgITCNOTNL.AllowUserToAddRows = False
            Me.DgITCNOTNL.Rows.Add(21)
            Me.DgITCNOTNL.Rows(0).Cells(0).Value = (" (a) TOTAL OUTPUT TAX AS PER COL.3(d)")
            Me.DgITCNOTNL.Rows(1).Cells(0).Value = (" (b) Less: Monthly Tax Paid (As Per 2nd Pervision To Rule 36)")
            Me.DgITCNOTNL.Rows(1).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgITCNOTNL.Rows(2).Cells(0).Value = ("            (i) 1st Month Of The Quarter")
            Me.DgITCNOTNL.Rows(3).Cells(0).Value = ("            (ii) 2nd Month Of The Quarter")
            Me.DgITCNOTNL.Rows(4).Cells(0).Value = (" (c) Less: Net ITC As Per Col. 4(o)")
            Me.DgITCNOTNL.Rows(5).Cells(0).Value = (" (d) Difference (a-b-c) (If OT Is More Than IT, Balance Be Adjusted Out Of Notional ITC If Any. Otherwise Amount Is To Be Deposited)")
            Me.DgITCNOTNL.Rows(6).Cells(0).Value = (" (e) Excess ITC If Any, After Adjustment Under (d)")
            Me.DgITCNOTNL.Rows(6).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgITCNOTNL.Rows(7).Cells(0).Value = ("            (i) Actual")
            Me.DgITCNOTNL.Rows(8).Cells(0).Value = ("            (ii) Notional")
            Me.DgITCNOTNL.Rows(9).Cells(0).Value = (" (f) Less: CST Liability For The Return Period, If Any")
            Me.DgITCNOTNL.Rows(10).Cells(0).Value = (" (g) Difference (e-f) (If OT Is More Than IT, Balance Be Adjusted Out Of Notional ITC If Any. Otherwise Amount Is To Be Deposited)")
            Me.DgITCNOTNL.Rows(11).Cells(0).Value = (" (h) Excess ITC If Any, After Adjustment Under (g)")
            Me.DgITCNOTNL.Rows(11).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgITCNOTNL.Rows(12).Cells(0).Value = ("            (i) Actual")
            Me.DgITCNOTNL.Rows(13).Cells(0).Value = ("            (ii) Notional")
            Me.DgITCNOTNL.Rows(14).Cells(0).Value = (" (i) Less: Actual ITC Out Of Col. (h) To Be Claimed As Refund")
            Me.DgITCNOTNL.Rows(15).Cells(0).Value = (" (j) Balance Excess ITC, If Any To Be Carried Forward To The Return")
            Me.DgITCNOTNL.Rows(15).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgITCNOTNL.Rows(16).Cells(0).Value = ("            (i) Actual")
            Me.DgITCNOTNL.Rows(17).Cells(0).Value = ("            (ii) Notional")
            Me.DgITCNOTNL.Rows(18).Cells(0).Value = (" (k) NET TAX PAYABLE")
            Me.DgITCNOTNL.Rows(18).DefaultCellStyle.BackColor = Color.LightPink
            Me.DgITCNOTNL.Rows(19).Cells(0).Value = (" (l) (i) 90% VAT Payable Under '0040' In Challan VAT-2")
            Me.DgITCNOTNL.Rows(20).Cells(0).Value = ("     (ii) 10% VAT Payable Under Punjab Municipal Fund In Challan VAT-2A")

            Me.DgITCNOTNL.Rows(0).Cells(1).Value = FormatNumber(xVAT_OutputTAX_Col3d, 2) '(" (a) TOTAL OUTPUT TAX AS PER COL.3(d)")
            '  Me.DgITCNOTNL.Rows(1).Cells(1).Value = 'keep Blank (" (b) Less: Monthly Tax Paid (As Per 2nd Pervision To Rule 36)")
            Me.DgITCNOTNL.Rows(2).Cells(1).Value = FormatNumber(Me.TXT1.Text, 2) ' ("            (i) 1st Month Of The Quarter")
            Me.DgITCNOTNL.Rows(3).Cells(1).Value = FormatNumber(Me.TXT2.Text, 2) '("            (ii) 2nd Month Of The Quarter")
            Me.DgITCNOTNL.Rows(4).Cells(1).Value = FormatNumber(xVAT_InputTAX_Col4p, 2) '(" (c) Less: Net ITC As Per Col. 4(o)")

            Dim xMnth1 As Double = CDbl(CDbl(Me.TXT1.Text))
            Dim xMnth2 As Double = CDbl(CDbl(Me.TXT2.Text))
            Dim xOT As Double = CDbl(xVAT_OutputTAX_Col3d)
            Dim xCst As Double = CDbl(xCST_OutputTAX)
            Dim xITC As Double = CDbl(xVAT_InputTAX_Col4p)
            Dim xNetOT As Double = xOT - (xMnth1 + xMnth2)
            Dim xNotnl As Double = CDbl(xExmptUnt1_to_10(9))

            If xNetOT > (xITC + xNotnl) Then  '== in case net is payable
                Dim xNetPay As Double = CDbl(xNetOT - (xITC + xNotnl))
                Me.DgITCNOTNL.Rows(5).Cells(1).Value = FormatNumber(xNetPay, 2) ' (" (d) Difference (a-b-c) (If OT Is More Than IT, Balance Be Adjusted Out Of Notional ITC If Any. Otherwise Amount Is To Be Deposited)")
                'Me.DgITCNOTNL.Rows(6).Cells(1).Value ='Keep Blank (" (e) Excess ITC If Any, After Adjustment Under (d)")
                Me.DgITCNOTNL.Rows(7).Cells(1).Value = FormatNumber(0, 2) '("            (i) Actual")
                Me.DgITCNOTNL.Rows(8).Cells(1).Value = FormatNumber(0, 2) ' ("            (ii) Notional")
                Me.DgITCNOTNL.Rows(9).Cells(1).Value = FormatNumber(0, 2) '(" (f) Less: CST Liability For The Return Period, If Any")
                Me.DgITCNOTNL.Rows(10).Cells(1).Value = FormatNumber(0, 2) '(" (g) Difference (e-f) (If OT Is More Than IT, Balance Be Adjusted Out Of Notional ITC If Any. Otherwise Amount Is To Be Deposited)")
                'Me.DgITCNOTNL.Rows(11).Cells(1).Value =' Keep Blank'(" (h) Excess ITC If Any, After Adjustment Under (g)")
                Me.DgITCNOTNL.Rows(12).Cells(1).Value = FormatNumber(0, 2) ' ("            (i) Actual")
                Me.DgITCNOTNL.Rows(13).Cells(1).Value = FormatNumber(0, 2) '("            (ii) Notional")
                Me.DgITCNOTNL.Rows(14).Cells(1).Value = FormatNumber(0, 2) '(" (i) Less: Actual ITC Out Of Col. (h) To Be Claimed As Refund")
                'Me.DgITCNOTNL.Rows(15).Cells(1).Value ='Keep Blank (" (j) Balance Excess ITC, If Any To Be Carried Forward To The Return")
                Me.DgITCNOTNL.Rows(16).Cells(1).Value = FormatNumber(0, 2) '("            (i) Actual")
                Me.DgITCNOTNL.Rows(17).Cells(1).Value = FormatNumber(0, 2) ' ("            (ii) Notional")
                '  Me.DgITCNOTNL.Rows(18).Cells(1).Value ='Keep Blank' (" (k) NET TAX PAYABLE")
                Me.DgITCNOTNL.Rows(19).Cells(1).Value = FormatNumber(Math.Round(xNetPay * 0.9, 0), 2) ' (" (l) (i) 90% VAT Payable Under '0040' In Challan VAT-2")
                Me.DgITCNOTNL.Rows(20).Cells(1).Value = FormatNumber(Math.Round(xNetPay * 0.1, 0), 2) ' ("     (ii) 10% VAT Payable Under Punjab Municipal Fund In Challan VAT-2A")
            Else
                If xITC > xNetOT Then '== in case itc is greater than ot
                    Dim xNetx As Double = CDbl(xNetOT - xITC) ' + xNotnl))
                    Me.DgITCNOTNL.Rows(5).Cells(1).Value = FormatNumber(xNetx, 2) ' (" (d) Difference (a-b-c) (If OT Is More Than IT, Balance Be Adjusted Out Of Notional ITC If Any. Otherwise Amount Is To Be Deposited)")
                    'Me.DgITCNOTNL.Rows(6).Cells(1).Value ='Keep Blank (" (e) Excess ITC If Any, After Adjustment Under (d)")
                    Me.DgITCNOTNL.Rows(7).Cells(1).Value = FormatNumber(Math.Abs(xNetx), 2) '("            (i) Actual")
                    Me.DgITCNOTNL.Rows(8).Cells(1).Value = FormatNumber(xNotnl, 2) ' ("            (ii) Notional")
                    Me.DgITCNOTNL.Rows(9).Cells(1).Value = FormatNumber(xCst, 2) '(" (f) Less: CST Liability For The Return Period, If Any")

                    Dim xNetxx As Double = 0
                    Dim xNotnlxx As Double = 0
                    Dim xActlxx As Double = 0
                    Dim xNetxA As Double = Math.Abs(xNetx)
                    If xNetxA > xCst Then
                        xNetxx = xNetxA - xCst
                        xActlxx = xNetxx
                        xNotnlxx = xNotnl
                    ElseIf xCst > xNetxA And xCst < (xNetxA + xNotnl) Then
                        xNetxx = (xNetxA + xNotnl) - xCst
                        xActlxx = 0
                        xNotnlxx = xNetxx
                    Else
                        xNetxx = (xNetxA + xNotnl) - xCst
                        xActlxx = 0
                        xNotnlxx = 0
                    End If

                    Me.DgITCNOTNL.Rows(10).Cells(1).Value = FormatNumber(xNetxx, 2) '(" (g) Difference (e-f) (If OT Is More Than IT, Balance Be Adjusted Out Of Notional ITC If Any. Otherwise Amount Is To Be Deposited)")
                    'Me.DgITCNOTNL.Rows(11).Cells(1).Value =' Keep Blank'(" (h) Excess ITC If Any, After Adjustment Under (g)")
                    Me.DgITCNOTNL.Rows(12).Cells(1).Value = FormatNumber(xActlxx, 2) ' ("            (i) Actual")
                    Me.DgITCNOTNL.Rows(13).Cells(1).Value = FormatNumber(xNotnlxx, 2) '("            (ii) Notional")
                    If Me.Chkrefund.CheckState = CheckState.Checked Then
                        Me.DgITCNOTNL.Rows(14).Cells(1).Value = FormatNumber(xActlxx, 2) '(" (i) Less: Actual ITC Out Of Col. (h) To Be Claimed As Refund")
                        'Me.DgITCNOTNL.Rows(15).Cells(1).Value ='Keep Blank (" (j) Balance Excess ITC, If Any To Be Carried Forward To The Return")
                        Me.DgITCNOTNL.Rows(16).Cells(1).Value = FormatNumber(0, 2) '("            (i) Actual")
                    Else
                        Me.DgITCNOTNL.Rows(14).Cells(1).Value = FormatNumber(0, 2) '(" (i) Less: Actual ITC Out Of Col. (h) To Be Claimed As Refund")
                        'Me.DgITCNOTNL.Rows(15).Cells(1).Value ='Keep Blank (" (j) Balance Excess ITC, If Any To Be Carried Forward To The Return")
                        Me.DgITCNOTNL.Rows(16).Cells(1).Value = FormatNumber(xActlxx, 2) '("            (i) Actual")
                    End If
                    Me.DgITCNOTNL.Rows(17).Cells(1).Value = FormatNumber(xNotnlxx, 2) ' ("            (ii) Notional")

                    '  Me.DgITCNOTNL.Rows(18).Cells(1).Value ='Keep Blank' (" (k) NET TAX PAYABLE")
                    Me.DgITCNOTNL.Rows(19).Cells(1).Value = FormatNumber(0, 2) ' (" (l) (i) 90% VAT Payable Under '0040' In Challan VAT-2")
                    Me.DgITCNOTNL.Rows(20).Cells(1).Value = FormatNumber(0, 2) ' ("     (ii) 10% VAT Payable Under Punjab Municipal Fund In Challan VAT-2A")
                End If

            End If


       
            Me.DgITCNOTNL.Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgITCNOTNL.Columns(1).DefaultCellStyle.BackColor = Color.Cyan

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub TxtNetOPTax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT1.GotFocus, TXT2.GotFocus
        Try
            Dim xxTXT As TextBox = CType(sender, TextBox)
            xxTXT.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllContrlx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT1.KeyDown, TXT2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNetOPTax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT1.Leave, TXT2.Leave
        Try
            Dim xTXT As TextBox = CType(sender, TextBox)
            If xChk_numericValidation(xTXT) = False Then
                If Len(xTXT.Text.Trim) = 0 Then
                    xTXT.Text = 0
                End If
                xTXT.Text = FormatNumber(xTXT.Text, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            If MessageBox.Show("Are you sure to quit current session?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                Me.Close()
            Else
                Return
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnALL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.GotFocus, BtnBack.GotFocus, BtnNxt.GotFocus, BtnOK.GotFocus
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnALL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Leave, BtnBack.Leave, BtnNxt.Leave, BtnOK.Leave
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Try
            If Me.BtnOK.Text.Trim = "&OK" Then
                Me.BtnOK.Text = "&RESET"
                xxFillDgITCNOTNL6()
                Me.BtnNxt.Enabled = True
                Me.Chkrefund.Enabled = False
                Me.BtnNxt.Focus()
            Else
                Me.BtnOK.Text = "&OK"
                Me.Chkrefund.Enabled = True
                Me.DgITCNOTNL.Rows.Clear()
                Me.BtnNxt.Enabled = False

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXT1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT1.TextChanged

    End Sub
End Class
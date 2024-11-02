Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat15_OutputTax
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader

    Private Sub FrmVAT_vat15_OutputTax_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            xVAT_Flag3 = True
            xOTxPPANetOTx = CDbl(Me.TxtNetOPTax.Text)
        Catch ex As Exception

        End Try
    End Sub
   
    Private Sub FrmVAT_vat15_OUTPUTTAX_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Text = Me.Text & "              FROM:- " & xVAT_DtF & "    TO:- " & xVAT_DtT
            xFtchOTfromPPAAL(Me.TxtNetOPTax, Me.ChkBxNetOPtax)
            BtnOK_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNxt.Click
        Try
            xVAT_OutputTAX_Col3d = 0
            xVAT_OutputTAX_Col3d = CDbl(Me.DgOutputTax.Rows(3).Cells(1).Value) ' used in Taxpayable Excess 
            Me.Close()
            Dim xFrmP4 As New FrmVAT_vat15_InputTax
            xFrmP4.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP4)
            xFrmP4.BringToFront()
            xFrmP4.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Try
            Me.Close()
            Dim xFrmP2 As New FrmVAT_Vat15_Deductns()
            xFrmP2.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP2)
            xFrmP2.BringToFront()
            xFrmP2.Show()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub xxFillDgOutPutTax3()
        Try
            Me.DgOutputTax.Rows.Clear()
            Me.DgOutputTax.AllowUserToAddRows = False
            Me.DgOutputTax.Rows.Add(4)
            Me.DgOutputTax.Rows(0).Cells(0).Value = (" (a) VAT On Net Taxable Sales During The Return Period")
            Me.DgOutputTax.Rows(1).Cells(0).Value = (" (b) Add: Purchase Tax On Turnover As Per Col. 2(h)")
            Me.DgOutputTax.Rows(2).Cells(0).Value = (" (c) Add/Less: Prior Period Net Adjustment Of Output Tax")
            Me.DgOutputTax.Rows(3).Cells(0).Value = (" (d) TOTAL OUTPUT TAX")

            Me.DgOutputTax.Rows(0).Cells(1).Value = FormatNumber(xVAT_OutputTAX, 2) ' (a) VAT on net taxable sales during the return period")
            Me.DgOutputTax.Rows(1).Cells(1).Value = FormatNumber(xVAT_PurchaseTax_Col2h, 2) ' (b) Add: Purchase tax on turnover as per Col. 2(h)")
            Me.DgOutputTax.Rows(2).Cells(1).Value = FormatNumber(Me.TxtNetOPTax.Text, 2) ' (c) Add/Less: Prior period net adjustment of output tax")
            Dim xNetOutputTax As Double = 0
            If Me.ChkBxNetOPtax.CheckState = CheckState.Checked Then
                xNetOutputTax = xVAT_OutputTAX + xVAT_PurchaseTax_Col2h + CDbl(Me.TxtNetOPTax.Text)
                xOTtype = "Add"
            Else
                xNetOutputTax = (xVAT_OutputTAX + xVAT_PurchaseTax_Col2h) + CDbl(Me.TxtNetOPTax.Text)
                xOTtype = "Less"
            End If

            Me.DgOutputTax.Rows(3).Cells(1).Value = FormatNumber(xNetOutputTax, 2) '(d) TOTAL OUTPUT TAX")

            Me.DgOutputTax.Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgOutputTax.Columns(1).DefaultCellStyle.BackColor = Color.Cyan
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkBxNetOPtax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBxNetOPtax.CheckedChanged
        Try
            If Me.ChkBxNetOPtax.CheckState = CheckState.Checked Then
                Me.ChkBxNetOPtax.Text = Trim("Add")
            Else
                Me.ChkBxNetOPtax.Text = Trim("Less")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNetOPTax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNetOPTax.GotFocus
        Try
            Me.TxtNetOPTax.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllContrlx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNetOPTax.KeyDown, ChkBxNetOPtax.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNetOPTax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNetOPTax.Leave
        Try
            If xChk_numericValidation(Me.TxtNetOPTax) = False Then
                If Len(Me.TxtNetOPTax.Text.Trim) = 0 Then
                    Me.TxtNetOPTax.Text = 0
                End If
                Me.TxtNetOPTax.Text = FormatNumber(Me.TxtNetOPTax.Text, 2)
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
                Me.TxtNetOPTax.Enabled = False
                Me.ChkBxNetOPtax.Enabled = False
                xxFillDgOutPutTax3()
                Me.BtnNxt.Enabled = True
                Me.BtnNxt.Focus()
            Else
                Me.BtnOK.Text = "&OK"
                Me.TxtNetOPTax.Enabled = True
                Me.ChkBxNetOPtax.Enabled = True
                Me.DgOutputTax.Rows.Clear()
                Me.BtnNxt.Enabled = False
                Me.TxtNetOPTax.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            If MessageBox.Show("Are you sure to quit current session?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                Me.Close()
            Else
                Return
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNetOPTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNetOPTax.TextChanged

    End Sub
End Class
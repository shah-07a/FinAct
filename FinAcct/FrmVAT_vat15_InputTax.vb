Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat15_InputTax
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader

    Private Sub FrmVAT_vat15_InputTax_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            xVAT_Flag4 = True
            xOutPutTextVal()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmVAT_vat15_INPUTTAX_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Text = Me.Text & "      FROM:- " & xVAT_DtF & "   TO:- " & xVAT_DtT
            xFtchTDSfromWcAl(Me.TXT3, Me.TXT5, Me.ChkBxNetOPtax)
            If xVAT_Flag4 = True Then
                xInPutTextVal()
                Me.BtnOK_Click(sender, e)
            End If
            Me.TXT1.Focus()
            Me.TXT1.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNxt.Click
        Try
            xVAT_InputTAX_Col4p = 0
            xVAT_InputTAX_Col4p = CDbl(Me.DgInputTax.Rows(15).Cells(1).Value)
            Me.Close()
            Dim xFrmP5 As New FrmVAT_vat15_ExmptUnt
            xFrmP5.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP5)
            xFrmP5.BringToFront()
            xFrmP5.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
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
    Private Sub xOutPutTextVal()
        Try
            xITCtxt1_to_12(0) = CDbl(Me.TXT1.Text)
            xITCtxt1_to_12(1) = CDbl(Me.TXT2.Text)
            xITCtxt1_to_12(2) = CDbl(Me.TXT3.Text)
            xITCtxt1_to_12(3) = CDbl(Me.TXT4.Text)
            xITCtxt1_to_12(4) = CDbl(Me.TXT5.Text)
            xITCtxt1_to_12(5) = CDbl(Me.TXT6.Text)
            xITCtxt1_to_12(6) = CDbl(Me.TXT7.Text)
            xITCtxt1_to_12(7) = CDbl(Me.TXT8.Text)
            xITCtxt1_to_12(8) = CDbl(Me.TXT9.Text)
            xITCtxt1_to_12(9) = CDbl(Me.TXT10.Text)
            xITCtxt1_to_12(10) = CDbl(Me.TXT11.Text)
            xITCtxt1_to_12(11) = CDbl(Me.TXT12.Text)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xInPutTextVal()
        Try
            Me.TXT1.Text = FormatNumber(xITCtxt1_to_12(0), 2)
            Me.TXT2.Text = FormatNumber(xITCtxt1_to_12(1), 2)
            Me.TXT4.Text = FormatNumber(xITCtxt1_to_12(3), 2)
            Me.TXT6.Text = FormatNumber(xITCtxt1_to_12(5), 2)
            Me.TXT7.Text = FormatNumber(xITCtxt1_to_12(6), 2)
            Me.TXT8.Text = FormatNumber(xITCtxt1_to_12(7), 2)
            Me.TXT9.Text = FormatNumber(xITCtxt1_to_12(8), 2)
            Me.TXT10.Text = FormatNumber(xITCtxt1_to_12(9), 2)
            Me.TXT11.Text = FormatNumber(xITCtxt1_to_12(10), 2)
            Me.TXT12.Text = FormatNumber(xITCtxt1_to_12(11), 2)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xxFillDgInPutTax4()
        Try
            Me.DgInputTax.Rows.Clear()
            Me.DgInputTax.AllowUserToAddRows = False
            Me.DgInputTax.Rows.Add(16)
            Me.DgInputTax.Rows(0).Cells(0).Value = (" (a) ITC Brought Forward From Previous Return Period")
            Me.DgInputTax.Rows(1).Cells(0).Value = (" (b) Add: Instalment Of ITC On Stocks Held On Appointed Day")
            Me.DgInputTax.Rows(2).Cells(0).Value = (" (c) Add: TDS Against Tax Deduction Certificate")
            Me.DgInputTax.Rows(3).Cells(0).Value = (" (d) Add: ITC On Purchases Made During The Period As Per Col 2(l) ")
            Me.DgInputTax.Rows(4).Cells(0).Value = (" (e) Add: ITC Debited Earlier, On Goods Received Back After Job Work u/s 13(3)")
            Me.DgInputTax.Rows(5).Cells(0).Value = (" (f) Add/Less: Prior Period Net Adjustment To Input Tax")
            Me.DgInputTax.Rows(6).Cells(0).Value = (" (g) Add: Any Other, Please Specify")
            Me.DgInputTax.Rows(7).Cells(0).Value = (" (h) TOTAL INPUT TAX CREDIT AVAILABLE")
            Me.DgInputTax.Rows(7).DefaultCellStyle.BackColor = Color.Yellow
            Me.DgInputTax.Rows(8).Cells(0).Value = (" (i) Less: Apportionment Of ITC For Manufacturing Tax Free Goods")
            Me.DgInputTax.Rows(9).Cells(0).Value = (" (j) Less: Apportionment Of ITC For Branch Transfer")
            Me.DgInputTax.Rows(10).Cells(0).Value = (" (k) Less: Apportionment Of ITC u/s 13(4)")
            Me.DgInputTax.Rows(11).Cells(0).Value = (" (l) Less:  ITC On Goods Sent For Job Work u/s 13(3)")
            Me.DgInputTax.Rows(12).Cells(0).Value = (" (m) Less: Reversal Of ITC")
            Me.DgInputTax.Rows(13).Cells(0).Value = (" (n) Less: Any Other, Please Specify")
            Me.DgInputTax.Rows(14).Cells(0).Value = (" (o) TOTAL (i+j+k+l+m+n)")
            Me.DgInputTax.Rows(14).DefaultCellStyle.BackColor = Color.Pink
            Me.DgInputTax.Rows(15).Cells(0).Value = (" (p) NET INPUT TAX CREDIT AVAILABLE (h-o)")
            Me.DgInputTax.Rows(15).DefaultCellStyle.BackColor = Color.Yellow
            Me.DgInputTax.Rows(0).Cells(1).Value = FormatNumber(Me.TXT1.Text, 2) '  (a) ITC brought forward from previous return period")
            Me.DgInputTax.Rows(1).Cells(1).Value = FormatNumber(Me.TXT2.Text, 2) '  (b) Add: Instalment of ITC on stocks held on appointed day")
            Me.DgInputTax.Rows(2).Cells(1).Value = FormatNumber(Me.TXT3.Text, 2) '  (c) Add: TDS against Tax Deduction Certificate")
            Me.DgInputTax.Rows(3).Cells(1).Value = FormatNumber(xVAT_PurchaseTax_Col2l, 2) '  (d) Add: ITC on purchases made during the period as per Col 2(l) ")
            Me.DgInputTax.Rows(4).Cells(1).Value = FormatNumber(Me.TXT4.Text, 2) '  (e) Add: ITC debited earlier, on goods received back after job work u/s 13(3)")
            Me.DgInputTax.Rows(5).Cells(1).Value = FormatNumber(Me.TXT5.Text, 2) '  (f) Add/Less: Prior period net adjustment to input tax")
            Me.DgInputTax.Rows(6).Cells(1).Value = FormatNumber(Me.TXT6.Text, 2) '  (g) Add: Any other, please specify")
            Dim xITxCr As Double = 0
            If Me.ChkBxNetOPtax.CheckState = CheckState.Checked Then
                xITxCr = CDbl(CDbl(Me.TXT1.Text) + CDbl(TXT2.Text) + CDbl(TXT3.Text) + CDbl(xVAT_PurchaseTax_Col2l) + CDbl(TXT4.Text) + CDbl(TXT5.Text) + CDbl(TXT6.Text))
                xITCtype = "Add"
            Else
                xITxCr = CDbl(CDbl(Me.TXT1.Text) + CDbl(TXT2.Text) + CDbl(TXT3.Text) + CDbl(xVAT_PurchaseTax_Col2l) + CDbl(TXT4.Text) + CDbl(TXT6.Text)) + CDbl(TXT5.Text)
                xITCtype = "Less"
            End If
            Me.DgInputTax.Rows(7).Cells(1).Value = FormatNumber(xITxCr, 2) '  (h) TOTAL INPUT TAX CREDIT AVAILABLE")
            Me.DgInputTax.Rows(8).Cells(1).Value = FormatNumber(Me.TXT7.Text, 2) '  (i) Less: Apportionment of ITC for manufacturing tax free goods")
            Me.DgInputTax.Rows(9).Cells(1).Value = FormatNumber(Me.TXT8.Text, 2) '  (j) Less: Apportionment of ITC for branch transfer")
            Me.DgInputTax.Rows(10).Cells(1).Value = FormatNumber(Me.TXT9.Text, 2) '  (k) Less: Apportionment of ITC u/s 13(4)")
            Me.DgInputTax.Rows(11).Cells(1).Value = FormatNumber(Me.TXT10.Text, 2) '  (l) Less:  ITC on goods sent for job work u/s 13(3)")
            Me.DgInputTax.Rows(12).Cells(1).Value = FormatNumber(Me.TXT11.Text, 2) '  (m) Less: Reversal of ITC")
            Me.DgInputTax.Rows(13).Cells(1).Value = FormatNumber(Me.TXT12.Text, 2) '  (n) Less: Any other, please specify")
            Dim xITxDr As Double = CDbl(CDbl(TXT7.Text) + CDbl(TXT8.Text) + CDbl(TXT9.Text) + CDbl(TXT10.Text) + CDbl(TXT11.Text) + CDbl(TXT12.Text))
            Me.DgInputTax.Rows(14).Cells(1).Value = FormatNumber(xITxDr, 2) '  (o) TOTAL (i+j+k+l+m+n)")
            Me.DgInputTax.Rows(15).Cells(1).Value = FormatNumber(xITxCr - xITxDr, 2) '  (p) NET INPUT TAX CREDIT AVAILABLE (h-o)"
            Me.DgInputTax.Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgInputTax.Columns(1).DefaultCellStyle.BackColor = Color.Cyan

        Catch ex As Exception
            MsgBox(ex.Message)
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

    Private Sub TxtNetOPTax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT5.GotFocus, TXT3.GotFocus, TXT4.GotFocus, TXT1.GotFocus, TXT2.GotFocus, TXT6.GotFocus, TXT10.GotFocus, TXT9.GotFocus, TXT8.GotFocus, TXT7.GotFocus, TXT11.GotFocus, TXT12.GotFocus
        Try
            Dim xxTXT As TextBox = CType(sender, TextBox)
            xxTXT.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllContrlx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT5.KeyDown, ChkBxNetOPtax.KeyDown, TXT3.KeyDown, TXT4.KeyDown, TXT1.KeyDown, TXT2.KeyDown, TXT6.KeyDown, TXT10.KeyDown, TXT9.KeyDown, TXT8.KeyDown, TXT7.KeyDown, TXT11.KeyDown, TXT12.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNetOPTax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT5.Leave, TXT3.Leave, TXT4.Leave, TXT1.Leave, TXT2.Leave, TXT6.Leave, TXT10.Leave, TXT9.Leave, TXT8.Leave, TXT7.Leave, TXT11.Leave, TXT12.Leave
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
                Me.TXT5.Enabled = False
                Me.ChkBxNetOPtax.Enabled = False
                xxFillDgInPutTax4()
                Me.BtnNxt.Enabled = True
                Me.BtnNxt.Focus()
            Else
                Me.BtnOK.Text = "&OK"
                Me.TXT5.Enabled = True
                Me.ChkBxNetOPtax.Enabled = True
                Me.DgInputTax.Rows.Clear()
                Me.BtnNxt.Enabled = False
                Me.TXT5.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXT1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT1.TextChanged

    End Sub
End Class
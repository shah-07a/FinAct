Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat15_ExmptUnt
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader

    Private Sub FrmVAT_vat15_ExmptUnt_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            xVAT_Flag5 = True
            xOutPutTextVal()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmVAT_vat15_ExmptUnt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Text = Me.Text & "      FROM:- " & xVAT_DtF & "   TO:- " & xVAT_DtT
            Me.TXT1.Text = FormatNumber(xVAT_PurchaseRtd_d, 2)
            If xVAT_Flag5 = True Then
                xInputTextVal()
                Me.BtnOK_Click(sender, e)
            End If
            Me.TXT1.Focus()
            Me.TXT1.SelectAll()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xOutPutTextVal()
        Try
            ' xExmptUnt1_to_10(0) = CDbl(Me.TXT1.Text)
            xExmptUnt1_to_10(1) = CDbl(Me.TXT2.Text)
            xExmptUnt1_to_10(2) = CDbl(Me.TXT3.Text)
            xExmptUnt1_to_10(3) = CDbl(Me.TXT4.Text)
            xExmptUnt1_to_10(4) = CDbl(Me.TXT5.Text)
            xExmptUnt1_to_10(5) = CDbl(Me.TXT6.Text)
            xExmptUnt1_to_10(6) = CDbl(Me.TXT7.Text)
            xExmptUnt1_to_10(7) = CDbl(Me.TXT8.Text)
            xExmptUnt1_to_10(8) = CDbl(Me.TXT9.Text)
            xExmptUnt1_to_10(9) = CDbl(Me.TXT10.Text)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub xInputTextVal()
        Try
            '  Me.TXT1.Text = FormatNumber(xExmptUnt1_to_10(0), 2)
            Me.TXT2.Text = FormatNumber(xExmptUnt1_to_10(1), 2)
            Me.TXT3.Text = FormatNumber(xExmptUnt1_to_10(2), 2)
            Me.TXT4.Text = FormatNumber(xExmptUnt1_to_10(3), 2)
            Me.TXT5.Text = FormatNumber(xExmptUnt1_to_10(4), 2)
            Me.TXT6.Text = FormatNumber(xExmptUnt1_to_10(5), 2)
            Me.TXT7.Text = FormatNumber(xExmptUnt1_to_10(6), 2)
            Me.TXT8.Text = FormatNumber(xExmptUnt1_to_10(7), 2)
            Me.TXT9.Text = FormatNumber(xExmptUnt1_to_10(8), 2)
            Me.TXT10.Text = FormatNumber(xExmptUnt1_to_10(9), 2)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNxt.Click
        Try
            Me.Close()
            Dim xFrmP6 As New FrmVAT_vat15_TAXPAYABLEEXCESS
            xFrmP6.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP6)
            xFrmP6.BringToFront()
            xFrmP6.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Try
            Me.Close()
            Dim xFrmP4 As New FrmVAT_vat15_InputTax
            xFrmP4.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP4)
            xFrmP4.BringToFront()
            xFrmP4.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xxFillDgExemptUnt5()
        Try
            Me.DgExemptUnt.Rows.Clear()
            Me.DgExemptUnt.AllowUserToAddRows = False
            Me.DgExemptUnt.Rows.Add(10)
            Me.DgExemptUnt.Rows(0).Cells(0).Value = (" (a) Total Purchase Made During The Return Period As Per Col 2(d)")
            Me.DgExemptUnt.Rows(1).Cells(0).Value = (" (b) Less: Goods Return And Cash/Trade Discount")
            Me.DgExemptUnt.Rows(2).Cells(0).Value = (" (c) Less: Goods Used In The Manufacture Of Tax Free Goods")
            Me.DgExemptUnt.Rows(3).Cells(0).Value = (" (d) Less: Goods Exported Out Of India")
            Me.DgExemptUnt.Rows(4).Cells(0).Value = (" (e) Less: Godds Used In Consignment/Branch Transfer")
            Me.DgExemptUnt.Rows(5).Cells(0).Value = (" (f) Less: Goods Capital Goods")
            Me.DgExemptUnt.Rows(6).Cells(0).Value = (" (g) Less: Sales Made To Persons Other Than Taxable Persons")
            Me.DgExemptUnt.Rows(7).Cells(0).Value = (" (h) Less: Goods Not Eligible For ITC u/s 13(5)")
            Me.DgExemptUnt.Rows(8).Cells(0).Value = (" (i) Less: Any Other Goods On Which Notional ITC Is Not Available")
            Me.DgExemptUnt.Rows(9).Cells(0).Value = (" (j) TOTAL PURCHASE ELIGIBLE FOR NOTIONAL ITC")


            Me.DgExemptUnt.Rows(0).Cells(1).Value = FormatNumber(xVAT_Purchase_d, 2) ' (" (a) Total Purchase Made During The Return Period As Per Col 2(d)")
            Me.DgExemptUnt.Rows(1).Cells(1).Value = FormatNumber(Me.TXT1.Text, 2) ' (b) Less: Goods Return And Cash/Trade Discount")
            Me.DgExemptUnt.Rows(2).Cells(1).Value = FormatNumber(Me.TXT2.Text, 2) ' (c) Less: Goods Used In The Manufacture Of Tax Free Goods")
            Me.DgExemptUnt.Rows(3).Cells(1).Value = FormatNumber(Me.TXT3.Text, 2) '(d) Less: Goods Exported Out Of India")
            Me.DgExemptUnt.Rows(4).Cells(1).Value = FormatNumber(Me.TXT4.Text, 2) '(e) Less: Godds Used In Consignment/Branch Transfer")
            Me.DgExemptUnt.Rows(5).Cells(1).Value = FormatNumber(Me.TXT5.Text, 2) '(f) Less: Goods Capital Goods")
            Me.DgExemptUnt.Rows(6).Cells(1).Value = FormatNumber(Me.TXT6.Text, 2) ' (g) Less: Sales Made To Persons Other Than Taxable Persons")
            Me.DgExemptUnt.Rows(7).Cells(1).Value = FormatNumber(Me.TXT7.Text, 2) '(h) Less: Goods Not Eligible For ITC u/s 13(5)")
            Me.DgExemptUnt.Rows(8).Cells(1).Value = FormatNumber(Me.TXT8.Text, 2) ' (i) Less: Any Other Goods On Which Notional ITC Is Not Available")
            Dim xNetExept As Double = xVAT_Purchase_d - CDbl(CDbl(Me.TXT1.Text) + CDbl(Me.TXT2.Text) + CDbl(Me.TXT3.Text) + CDbl(Me.TXT4.Text) + CDbl(Me.TXT5.Text) + CDbl(Me.TXT6.Text) + CDbl(Me.TXT7.Text) + CDbl(Me.TXT8.Text))
            Me.DgExemptUnt.Rows(9).Cells(1).Value = FormatNumber(xNetExept, 2) ' (j) TOTAL PURCHASE ELIGIBLE FOR NOTIONAL ITC")
            Me.DgExemptUnt.Rows(9).DefaultCellStyle.BackColor = Color.LightYellow
            Me.DgExemptUnt.Rows(0).DefaultCellStyle.BackColor = Color.LightPink

            Me.DgExemptUnt.Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgExemptUnt.Columns(1).DefaultCellStyle.BackColor = Color.Cyan

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub xxFillDgITCNOTNL6()
        Try
            Me.DgITCNOTNL.Rows.Clear()
            Me.DgITCNOTNL.AllowUserToAddRows = False
            Me.DgITCNOTNL.Rows.Add(3)
            Me.DgITCNOTNL.Rows(0).Cells(0).Value = (" (a) Brought Forward From Previous Return Period")
            Me.DgITCNOTNL.Rows(1).Cells(0).Value = (" (b) Add: Notional ITC On Purchases From Exempted Units As Per Col. 5(j)")
            Me.DgITCNOTNL.Rows(2).Cells(0).Value = (" (c) TOTAL NOTIONAL ITC AVAILABLE")

            Me.DgITCNOTNL.Rows(0).Cells(1).Value = FormatNumber(Me.TXT9.Text, 2) ' (a) Brought Forward From Previous Return Period")
            Me.TXT10.Text = FormatNumber(CDbl(CDbl(Me.DgExemptUnt.Rows(9).Cells(1).Value) * 4) / 100, 0)
            Me.DgITCNOTNL.Rows(1).Cells(1).Value = FormatNumber(Me.TXT10.Text, 2) ' (b) Add: Notional ITC On Purchases From Exempted Units As Per Col. 5(j)")
            Dim xNetNOtnl As Double = FormatNumber(CDbl(CDbl(Me.TXT9.Text) + CDbl(Me.TXT10.Text)), 0)
            Me.DgITCNOTNL.Rows(2).Cells(1).Value = FormatNumber(xNetNOtnl, 2) ' (c) TOTAL NOTIONAL ITC AVAILABLE")

            Me.DgITCNOTNL.Rows(0).DefaultCellStyle.BackColor = Color.LightPink
            Me.DgITCNOTNL.Rows(2).DefaultCellStyle.BackColor = Color.Yellow

            Me.DgITCNOTNL.Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgITCNOTNL.Columns(1).DefaultCellStyle.BackColor = Color.Cyan

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtNetOPTax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT5.GotFocus, TXT3.GotFocus, TXT4.GotFocus, TXT1.GotFocus, TXT2.GotFocus, TXT7.GotFocus, TXT6.GotFocus, TXT8.GotFocus, TXT9.GotFocus, TXT10.GotFocus
        Try
            Dim xxTXT As TextBox = CType(sender, TextBox)
            xxTXT.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllContrlx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT5.KeyDown, TXT3.KeyDown, TXT4.KeyDown, TXT1.KeyDown, TXT2.KeyDown, TXT7.KeyDown, TXT6.KeyDown, TXT8.KeyDown, TXT9.KeyDown, TXT10.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNetOPTax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT5.Leave, TXT3.Leave, TXT4.Leave, TXT1.Leave, TXT2.Leave, TXT7.Leave, TXT6.Leave, TXT8.Leave, TXT9.Leave, TXT10.Leave
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
                xxFillDgExemptUnt5()
                xxFillDgITCNOTNL6()
                Me.BtnNxt.Enabled = True
                Me.BtnNxt.Focus()
            Else
                Me.BtnOK.Text = "&OK"
                Me.TXT5.Enabled = True
                Me.DgExemptUnt.Rows.Clear()
                Me.DgITCNOTNL.Rows.Clear()
                Me.BtnNxt.Enabled = False
                Me.TXT5.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

End Class
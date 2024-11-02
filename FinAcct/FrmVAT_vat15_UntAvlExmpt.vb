Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat15_UntAvlExmpt
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader

    Private Sub FrmVAT_vat15_UntAvlExmpt_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
             xVAT_Flag8 = True
            xOutPutTextVal()
            If Me.ChkBxVAT15_8.CheckState = CheckState.Checked Then
                xUAE8chk = True
            Else
                xUAE8chk = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmVAT_vat15_UntAvlExmpt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Text = Me.Text & "      FROM:- " & xVAT_DtF & "   TO:- " & xVAT_DtT
            If xVAT_Flag8 = True Then
                xInPutTextVal()
                If xUAE8chk = True Then
                    Me.ChkBxVAT15_8.CheckState = CheckState.Checked
                Else
                    Me.ChkBxVAT15_8.CheckState = CheckState.Unchecked
                End If
            End If
            Me.BtnNxt.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xOutPutTextVal()
        Try
            xUAE8 = Trim(Me.TXT1.Text)
            xUAE8dt(0) = Me.DtpVAT15_8_1.Value
            xUAE8dt(1) = Me.DtpVAT15_8_2.Value
            xUAE8_2_to_7(0) = CDbl(Me.TXT2.Text)
            xUAE8_2_to_7(1) = CDbl(Me.TXT3.Text)
            xUAE8_2_to_7(2) = CDbl(Me.TXT4.Text)
            xUAE8_2_to_7(3) = CDbl(Me.TXT5.Text)
            xUAE8_2_to_7(4) = CDbl(Me.TXT6.Text)
            xUAE8_2_to_7(5) = CDbl(Me.TXT7.Text)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xInPutTextVal()
        Try
            Me.TXT1.Text = xUAE8.Trim
            Me.TXT2.Text = FormatNumber(xUAE8_2_to_7(0), 2)
            Me.TXT3.Text = FormatNumber(xUAE8_2_to_7(1), 2)
            Me.TXT4.Text = FormatNumber(xUAE8_2_to_7(2), 2)
            Me.TXT5.Text = FormatNumber(xUAE8_2_to_7(3), 2)
            Me.TXT6.Text = FormatNumber(xUAE8_2_to_7(4), 2)
            Me.TXT7.Text = FormatNumber(xUAE8_2_to_7(5), 2)
            Me.DtpVAT15_8_1.Value = xUAE8dt(0)
            Me.DtpVAT15_8_2.Value = xUAE8dt(1)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNxt.Click
        Try
            Me.Close()
            Dim xFrmP8 As New FrmVAT_vat15_MiseInfo
            xFrmP8.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP8)
            xFrmP8.BringToFront()
            xFrmP8.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
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
    Private Sub xxFillDgInPutTax8()
        Try
            Me.DgInputTax.Rows.Clear()
            Me.DgInputTax.AllowUserToAddRows = False
            Me.DgInputTax.Rows.Add(8)
            Me.DgInputTax.Rows(0).Cells(0).Value = (" (a) Entitlement Certificate No. And Date")
            Me.DgInputTax.Rows(1).Cells(0).Value = (" (b) Date Of Expiry Of Exemption/Defferment")
            Me.DgInputTax.Rows(2).Cells(0).Value = (" (c) Total Amount Of Exemption/Defferment Allowed")
            Me.DgInputTax.Rows(3).Cells(0).Value = ("          (i) Exemption/Defferment Available At The Beginning Of The Return Period (Including Under CST Act)")
            Me.DgInputTax.Rows(4).Cells(0).Value = ("          (ii) Exemption/Defferment Availed During The Return Period")
            Me.DgInputTax.Rows(5).Cells(0).Value = ("          (iii) Balance At The End Of Return Period")
            Me.DgInputTax.Rows(6).Cells(0).Value = (" (d) Admissible Amount Of Refund On Tax Paid Purchases")
            Me.DgInputTax.Rows(7).Cells(0).Value = (" (e) Goods Sent On Consignment/Stock Transfer Basis")

            Me.DgInputTax.Rows(0).Cells(1).Value = Me.TXT1.Text.Trim & "Date:- " & Format(Me.DtpVAT15_8_1.Value.Date, "dd/MM/yyyy") '(" (a) Entitlement Certificate No. And Date")
            Me.DgInputTax.Rows(1).Cells(1).Value = Format(Me.DtpVAT15_8_1.Value.Date, "dd/MM/yyyy") ' (" (b) Date Of Expiry Of Exemption/Defferment")
            Me.DgInputTax.Rows(2).Cells(1).Value = FormatNumber(Me.TXT2.Text, 2) ' (" (c) Total Amount Of Exemption/Defferment Allowed")
            Me.DgInputTax.Rows(3).Cells(1).Value = FormatNumber(Me.TXT3.Text, 2) ' ("          (i) Exemption/Defferment Available At The Beginning Of The Return Period (Including Under CST Act)")
            Me.DgInputTax.Rows(4).Cells(1).Value = FormatNumber(Me.TXT4.Text, 2) ' ("          (ii) Exemption/Defferment Availed During The Return Period")
            Me.DgInputTax.Rows(5).Cells(1).Value = FormatNumber(Me.TXT5.Text, 2) ' ("          (iii) Balance At The End Of Return Period")
            Me.DgInputTax.Rows(6).Cells(1).Value = FormatNumber(Me.TXT6.Text, 2) ' (" (d) Admissible Amount Of Refund On Tax Paid Purchases")
            Me.DgInputTax.Rows(7).Cells(1).Value = FormatNumber(Me.TXT7.Text, 2) '(" (e) Goods Sent On Consignment/Stock Transfer Basis")
            Me.DgInputTax.Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgInputTax.Columns(1).DefaultCellStyle.BackColor = Color.Cyan

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

  

    Private Sub TxtNetOPTax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT4.GotFocus, TXT2.GotFocus, TXT3.GotFocus, TXT1.GotFocus, TXT5.GotFocus, TXT7.GotFocus, TXT6.GotFocus
        Try
            Dim xxTXT As TextBox = CType(sender, TextBox)
            xxTXT.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllContrlx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT4.KeyDown, TXT2.KeyDown _
    , TXT3.KeyDown, TXT1.KeyDown, TXT5.KeyDown, TXT7.KeyDown, TXT6.KeyDown, DtpVAT15_8_1.KeyDown, DtpVAT15_8_2.KeyDown, ChkBxVAT15_8.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNetOPTax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT4.Leave, TXT2.Leave, TXT3.Leave, TXT5.Leave, TXT7.Leave, TXT6.Leave
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
                Me.TXT4.Enabled = False

                xxFillDgInPutTax8()
                Me.BtnNxt.Enabled = True
                Me.BtnNxt.Focus()
            Else
                Me.BtnOK.Text = "&OK"
                Me.TXT4.Enabled = True
                Me.DgInputTax.Rows.Clear()
                Me.BtnNxt.Enabled = False
                Me.TXT4.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub ChkBxVAT15_8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBxVAT15_8.CheckedChanged
        Try
            If Me.ChkBxVAT15_8.CheckState = CheckState.Checked Then
                Me.Panel1.Enabled = True
                Me.BtnNxt.Enabled = False
                Me.TXT1.Focus()
            Else
                For Each xtxt As Control In Me.Panel1.Controls
                    If TypeOf xtxt Is TextBox Then
                        xtxt.Text = FormatNumber(0, 2)
                    End If
                Next
                Me.DgInputTax.Rows.Clear()
                Me.Panel1.Enabled = False
                Me.BtnNxt.Enabled = True
                Me.BtnNxt.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXT1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT1.Leave
        Try
            If Me.ChkBxVAT15_8.CheckState = CheckState.Checked Then
                If Len(TXT1.Text.Trim) = 0 Then
                    MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                    Me.TXT1.Focus()
                End If
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

 
End Class
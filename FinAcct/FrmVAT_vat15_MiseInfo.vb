Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat15_MiseInfo
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader

    Private Sub FrmVAT_vat15_MiseInfo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            xVAT_Flag9 = True
            xOutPutTextVal()
            If Me.ChkBxVAT15_9.CheckState = CheckState.Checked Then
                xMiseInfo9chk = True
            Else
                xMiseInfo9chk = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmVAT_vat15_MiseInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Text = Me.Text & "      FROM:- " & xVAT_DtF & "   TO:- " & xVAT_DtT
            If xVAT_Flag9 = True Then
                xInPutTextVal()
                If xMiseInfo9chk = True Then
                    Me.ChkBxVAT15_9.CheckState = CheckState.Checked
                Else
                    Me.ChkBxVAT15_9.CheckState = CheckState.Unchecked
                End If
            End If
            Me.ChkBxVAT15_9.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNxt.Click
        Try
            Me.Close()
            Dim xFrmP10 As New FrmVAT_vat15_WrkSheet
            xFrmP10.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmP10)
            xFrmP10.BringToFront()
            xFrmP10.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xOutPutTextVal()
        Try
            xMiseInfo9_1_to_5(0) = CDbl(Me.TXT1.Text)
            xMiseInfo9_1_to_5(1) = CDbl(Me.TXT2.Text)
            xMiseInfo9_1_to_5(2) = CDbl(Me.TXT3.Text)
            xMiseInfo9_1_to_5(3) = CDbl(Me.TXT4.Text)
            xMiseInfo9_1_to_5(4) = CDbl(Me.TXT5.Text)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xInPutTextVal()
        Try
            Me.TXT1.Text = FormatNumber(xMiseInfo9_1_to_5(0), 2)
            Me.TXT2.Text = FormatNumber(xMiseInfo9_1_to_5(1), 2)
            Me.TXT3.Text = FormatNumber(xMiseInfo9_1_to_5(2), 2)
            Me.TXT4.Text = FormatNumber(xMiseInfo9_1_to_5(3), 2)
            Me.TXT5.Text = FormatNumber(xMiseInfo9_1_to_5(4), 2)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
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
    Private Sub xxFillDgMiseInfo9()
        Try
            Me.DgMiseInfo.Rows.Clear()
            Me.DgMiseInfo.AllowUserToAddRows = False
            Me.DgMiseInfo.Rows.Add(5)
            Me.DgMiseInfo.Rows(0).Cells(0).Value = (" (a) Value Of Branch Transfer/Consignment Transfer Made During The Return Period")
            Me.DgMiseInfo.Rows(1).Cells(0).Value = (" (b) Value Of Commission Sales Made By Kacha Arthiya During The Return Period")
            Me.DgMiseInfo.Rows(2).Cells(0).Value = (" (c) Payment Made To Contractor(s), Sub-Contractor(s)")
            Me.DgMiseInfo.Rows(3).Cells(0).Value = (" (d) Proof Of Payment Of TDS")
            Me.DgMiseInfo.Rows(4).Cells(0).Value = (" (e) Value Of Capital Goods Purchased From Taxable Persons")

            Me.DgMiseInfo.Rows(0).Cells(1).Value = FormatNumber(Me.TXT1.Text, 2) ' (" (a) Value Of Branch Transfer/Consignment Transfer Made During The Return Period")
            Me.DgMiseInfo.Rows(1).Cells(1).Value = FormatNumber(Me.TXT2.Text, 2) ' (" (b) Value Of Commission Sales Made By Kacha Arthiya During The Return Period")
            Me.DgMiseInfo.Rows(2).Cells(1).Value = FormatNumber(Me.TXT3.Text, 2) '(" (c) Payment Made To Contractor(s), Sub-Contractor(s)")
            Me.DgMiseInfo.Rows(3).Cells(1).Value = FormatNumber(Me.TXT4.Text, 2) '(" (d) Proof Of Payment Of TDS")
            Me.DgMiseInfo.Rows(4).Cells(1).Value = FormatNumber(Me.TXT5.Text, 2) '(" (e) Value Of Capital Goods Purchased From Taxable Persons")


            Me.DgMiseInfo.Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgMiseInfo.Columns(1).DefaultCellStyle.BackColor = Color.Cyan

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ChkBxNetOPtax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBxVAT15_9.CheckedChanged
        Try
            If Me.ChkBxVAT15_9.CheckState = CheckState.Checked Then
                Me.Panel1.Enabled = True
                Me.BtnNxt.Enabled = False
                Me.TXT1.Focus()
            Else
                For Each xtxt As Control In Me.Panel1.Controls
                    If TypeOf xtxt Is TextBox Then
                        xtxt.Text = FormatNumber(0, 2)
                    End If
                Next
                Me.Panel1.Enabled = False
                Me.BtnNxt.Enabled = True
                Me.DgMiseInfo.Rows.Clear()
                Me.BtnNxt.Focus()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNetOPTax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT5.GotFocus, TXT3.GotFocus, TXT4.GotFocus, TXT1.GotFocus, TXT2.GotFocus
        Try
            Dim xxTXT As TextBox = CType(sender, TextBox)
            xxTXT.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllContrlx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT5.KeyDown, ChkBxVAT15_9.KeyDown, TXT3.KeyDown, TXT4.KeyDown, TXT1.KeyDown, TXT2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNetOPTax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT5.Leave, TXT3.Leave, TXT4.Leave, TXT1.Leave, TXT2.Leave
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
                xxFillDgMiseInfo9()
                Me.BtnNxt.Enabled = True
                Me.BtnNxt.Focus()
            Else
                Me.BtnOK.Text = "&OK"
                Me.TXT5.Enabled = True
                Me.DgMiseInfo.Rows.Clear()
                Me.BtnNxt.Enabled = False
                Me.TXT5.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

   
End Class
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat15_PriorPerdAdjstmnt
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader
    Dim xCalFlag As Boolean = True
    Private Sub FrmVAT_vat15_PriorPerdAdjstmnt_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            xVAT_FlagPPA = True
            xDgValuesPPA(Me.DgPPAsales, Me.DgPPApurchase)
            xOutPutValues()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmVAT_vat15_WrkSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Text = Me.Text & "      FROM:- " & xVAT_DtF & "   TO:- " & xVAT_DtT
            xxFillDgPPAsales()
            xxFillDgPPApurchase()
            If xVAT_FlagPPA = True Then
                xFetchFromPPAAl(Me.DgPPAsales, Me.DgPPApurchase)
            End If
            Me.BtnNxt.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNxt.Click
        Try
            Me.Close()
            Dim xFrm15 As New FrmVAT_vat15PartI
            xFrm15.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrm15)
            xFrm15.BringToFront()
            xFrm15.Show()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub xxFillDgPPAsales()
        Try
            Me.DgPPAsales.Rows.Clear()
            Me.DgPPAsales.AllowUserToAddRows = False
            Me.DgPPAsales.Rows.Add(10)
            ''==RATE OF VAT
            Me.DgPPAsales.Rows(0).Cells(0).Value = (" At 1%")
            Me.DgPPAsales.Rows(1).Cells(0).Value = (" At 4%")
            Me.DgPPAsales.Rows(2).Cells(0).Value = (" At 5%")
            Me.DgPPAsales.Rows(3).Cells(0).Value = (" At 8.8%")
            Me.DgPPAsales.Rows(4).Cells(0).Value = (" At 12.5%")
            '  Me.DgPPAsales.Rows(5).Cells(0).Value = (" At 13.5%")
            Me.DgPPAsales.Rows(5).Cells(0).Value = (" At 20%")
            Me.DgPPAsales.Rows(6).Cells(0).Value = (" At 22%")
            Me.DgPPAsales.Rows(7).Cells(0).Value = (" At 27.5%")
            Me.DgPPAsales.Rows(8).Cells(0).Value = (" At 30%")
            Me.DgPPAsales.Rows(9).Cells(0).Value = (" TOTAL")


            Me.DgPPAsales.Rows(0).Cells(6).Value = CDbl(1.0)
            Me.DgPPAsales.Rows(1).Cells(6).Value = CDbl(4.0)
            Me.DgPPAsales.Rows(2).Cells(6).Value = CDbl(5.0)
            Me.DgPPAsales.Rows(3).Cells(6).Value = CDbl(8.8)
            Me.DgPPAsales.Rows(4).Cells(6).Value = CDbl(12.5)
            ' Me.DgPPAsales.Rows(5).Cells(6).Value = CDbl(13.5)
            Me.DgPPAsales.Rows(5).Cells(6).Value = CDbl(20.0)
            Me.DgPPAsales.Rows(6).Cells(6).Value = CDbl(22.0)
            Me.DgPPAsales.Rows(7).Cells(6).Value = CDbl(27.5)
            Me.DgPPAsales.Rows(8).Cells(6).Value = CDbl(30.0)
            Me.DgPPAsales.Rows(9).Cells(6).Value = CDbl(0.0)



            '==SALE WITHIN STATE

            Me.DgPPAsales.Rows(9).DefaultCellStyle.BackColor = Color.Yellow
            Me.DgPPAsales.Columns(0).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgPPAsales.Columns(1).DefaultCellStyle.BackColor = Color.White
            Me.DgPPAsales.Columns(2).DefaultCellStyle.BackColor = Color.White
            Me.DgPPAsales.Columns(3).DefaultCellStyle.BackColor = Color.White
            Me.DgPPAsales.Columns(4).DefaultCellStyle.BackColor = Color.White
            Me.DgPPAsales.Columns(5).DefaultCellStyle.BackColor = Color.LightPink
            Me.DgPPAsales.Rows(9).ReadOnly = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub xxFillDgPPApurchase()
        Try
            Me.DgPPApurchase.Rows.Clear()
            Me.DgPPApurchase.AllowUserToAddRows = False
            Me.DgPPApurchase.Rows.Add(10)
            ''==RATE OF VAT
            Me.DgPPApurchase.Rows(0).Cells(0).Value = (" At 1%")
            Me.DgPPApurchase.Rows(1).Cells(0).Value = (" At 4%")
            Me.DgPPApurchase.Rows(2).Cells(0).Value = (" At 5%")
            Me.DgPPApurchase.Rows(3).Cells(0).Value = (" At 8.8%")
            Me.DgPPApurchase.Rows(4).Cells(0).Value = (" At 12.5%")
            'Me.DgPPApurchase.Rows(5).Cells(0).Value = (" At 13.5%")
            Me.DgPPApurchase.Rows(5).Cells(0).Value = (" At 20%")
            Me.DgPPApurchase.Rows(6).Cells(0).Value = (" At 22%")
            Me.DgPPApurchase.Rows(7).Cells(0).Value = (" At 27.5%")
            Me.DgPPApurchase.Rows(8).Cells(0).Value = (" At 30%")
            Me.DgPPApurchase.Rows(9).Cells(0).Value = (" TOTAL")


            Me.DgPPApurchase.Rows(0).Cells(6).Value = CDbl(1.0)
            Me.DgPPApurchase.Rows(1).Cells(6).Value = CDbl(4.0)
            Me.DgPPApurchase.Rows(2).Cells(6).Value = CDbl(5.0)
            Me.DgPPApurchase.Rows(3).Cells(6).Value = CDbl(8.8)
            Me.DgPPApurchase.Rows(4).Cells(6).Value = CDbl(12.5)
            'Me.DgPPApurchase.Rows(5).Cells(6).Value = CDbl(13.5)
            Me.DgPPApurchase.Rows(5).Cells(6).Value = CDbl(20.0)
            Me.DgPPApurchase.Rows(6).Cells(6).Value = CDbl(22.0)
            Me.DgPPApurchase.Rows(7).Cells(6).Value = CDbl(27.5)
            Me.DgPPApurchase.Rows(8).Cells(6).Value = CDbl(30.0)
            Me.DgPPApurchase.Rows(9).Cells(6).Value = CDbl(0.0)



            '==SALE WITHIN STATE

            Me.DgPPApurchase.Rows(9).DefaultCellStyle.BackColor = Color.Yellow
            Me.DgPPApurchase.Columns(0).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgPPApurchase.Columns(1).DefaultCellStyle.BackColor = Color.White
            Me.DgPPApurchase.Columns(2).DefaultCellStyle.BackColor = Color.White
            Me.DgPPApurchase.Columns(3).DefaultCellStyle.BackColor = Color.White
            Me.DgPPApurchase.Columns(4).DefaultCellStyle.BackColor = Color.White
            Me.DgPPApurchase.Columns(5).DefaultCellStyle.BackColor = Color.LightPink
            Me.DgPPApurchase.Rows(9).ReadOnly = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnALL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.GotFocus, BtnNxt.GotFocus, BtnBack.GotFocus
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.LightYellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnALL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Leave, BtnNxt.Leave, BtnBack.Leave
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub


    Private Sub DgPPAsales_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgPPAsales.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgPPAsales.Rows.Count '- 1
            If Cr_Row <> Me.DgPPAsales.CurrentRow.Index Then
                If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgPPAsales.CurrentCell.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        Me.DgPPAsales.CurrentCell.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DgPPApurchase_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgPPApurchase.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgPPApurchase.Rows.Count '- 1
            If Cr_Row <> Me.DgPPApurchase.CurrentRow.Index Then
                If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgPPApurchase.CurrentCell.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        Me.DgPPApurchase.CurrentCell.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgPPAsales_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPPAsales.CellValueChanged
        Try
            If Not Me.DgPPApurchase.RowCount > 1 Or xCalFlag = False Then Exit Sub
            If e.ColumnIndex = 1 Then
                xColCal(Me.DgPPAsales)
                Me.DgPPAsales.CurrentRow.Cells(1).Value = FormatNumber(Math.Round(CDbl(Me.DgPPAsales.CurrentRow.Cells(1).Value), 1), 2)
            End If
            If e.ColumnIndex = 2 Then
                xColCal(Me.DgPPAsales)
                Me.DgPPAsales.CurrentRow.Cells(2).Value = FormatNumber(Math.Round(CDbl(Me.DgPPAsales.CurrentRow.Cells(2).Value), 1), 2)
            End If
            If e.ColumnIndex = 3 Then
                xColCal(Me.DgPPAsales)
                Me.DgPPAsales.CurrentRow.Cells(3).Value = FormatNumber(Math.Round(CDbl(Me.DgPPAsales.CurrentRow.Cells(3).Value), 1), 2)
            End If
            If e.ColumnIndex = 4 Then
                xColCal(Me.DgPPAsales)
                Me.DgPPAsales.CurrentRow.Cells(4).Value = FormatNumber(Math.Round(CDbl(Me.DgPPAsales.CurrentRow.Cells(4).Value), 1), 2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DgPPApurchase_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPPApurchase.CellValueChanged
        Try

            If Not Me.DgPPApurchase.RowCount > 1 Or xCalFlag = False Then Exit Sub
            If e.ColumnIndex = 1 Then
                xColCal(Me.DgPPApurchase)
                Me.DgPPApurchase.CurrentRow.Cells(1).Value = FormatNumber(Math.Round(CDbl(Me.DgPPApurchase.CurrentRow.Cells(1).Value), 1), 2)
            End If
            If e.ColumnIndex = 2 Then
                xColCal(Me.DgPPApurchase)
                Me.DgPPApurchase.CurrentRow.Cells(2).Value = FormatNumber(Math.Round(CDbl(Me.DgPPApurchase.CurrentRow.Cells(2).Value), 1), 2)
            End If
            If e.ColumnIndex = 3 Then
                xColCal(Me.DgPPApurchase)
                Me.DgPPApurchase.CurrentRow.Cells(3).Value = FormatNumber(Math.Round(CDbl(Me.DgPPApurchase.CurrentRow.Cells(3).Value), 1), 2)
            End If
            If e.ColumnIndex = 4 Then
                xColCal(Me.DgPPApurchase)
                Me.DgPPApurchase.CurrentRow.Cells(4).Value = FormatNumber(Math.Round(CDbl(Me.DgPPApurchase.CurrentRow.Cells(4).Value), 1), 2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub xColCal(ByVal xDg As DataGridView)
        Try
            Dim xCol1 As Double = -CDbl(xDg.CurrentRow.Cells(1).Value)
            Dim xCol2 As Double = -CDbl(xDg.CurrentRow.Cells(2).Value)
            Dim xCol3 As Double = CDbl(xDg.CurrentRow.Cells(3).Value)
            Dim xCol4 As Double = CDbl(xDg.CurrentRow.Cells(4).Value)
            'Dim xCol5 As Double = CDbl(xDg.Rows(xrow).Cells(5).Value)
            Dim xCol6 As Double = CDbl(xDg.CurrentRow.Cells(6).Value)
            Dim xTotl As Double = (xCol1 + xCol2 + xCol3 + xCol4)
            Dim xVAT As Double = (xTotl * xCol6) / 100

            xDg.CurrentRow.Cells(5).Value = FormatNumber(Math.Round(xVAT, 1), 2)

            Dim xxCol1 As Double = 0.0
            Dim xxCol2 As Double = 0.0
            Dim xxCol3 As Double = 0.0
            Dim xxCol4 As Double = 0.0
            Dim xxCol5 As Double = 0.0
            Dim xxCol6 As Double = 0.0
            For Each xrr As DataGridViewRow In xDg.Rows
                If xrr.Index = 9 Then Exit For
                xxCol1 += CDbl(xrr.Cells(1).Value)
                xxCol2 += CDbl(xrr.Cells(2).Value)
                xxCol3 += CDbl(xrr.Cells(3).Value)
                xxCol4 += CDbl(xrr.Cells(4).Value)
                xxCol5 += CDbl(xrr.Cells(5).Value)
                xxCol6 += CDbl(xrr.Cells(6).Value)
            Next
            xCalFlag = False
            xDg.Rows(9).Cells(1).Value = FormatNumber(Math.Round(xxCol1, 1), 2)
            xDg.Rows(9).Cells(2).Value = FormatNumber(Math.Round(xxCol2, 1), 2)
            xDg.Rows(9).Cells(3).Value = FormatNumber(Math.Round(xxCol3, 1), 2)
            xDg.Rows(9).Cells(4).Value = FormatNumber(Math.Round(xxCol4, 1), 2)
            xDg.Rows(9).Cells(5).Value = FormatNumber(Math.Round(xxCol5, 1), 2)
            xDg.Rows(9).Cells(6).Value = FormatNumber(Math.Round(xxCol6, 1), 2)
            xCalFlag = True
        Catch ex As Exception
            MsgBox(ex.Message)
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

    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Try
            Me.Close()
            Dim FrmWrkCon As New FrmVAT_vat15_WrkContrct
            FrmWrkCon.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(FrmWrkCon)
            FrmWrkCon.BringToFront()
            FrmWrkCon.Show()
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub xOutPutValues()
        Try
            xPPAsc1(0) = 0
            xPPAsc1(1) = 0
            xPPAsc2(0) = 0
            xPPAsc2(1) = 0
            xPPAsc3(0) = 0
            xPPAsc3(1) = 0
            xPPAsc4(0) = 0
            xPPAsc4(1) = 0
            For Each xrow As DataGridViewRow In Me.DgPPAsales.Rows
                If xrow.Index = 9 Then Exit For
                xPPAsc1(0) += CDbl(xrow.Cells(1).Value)
                xPPAsc1(1) += FormatNumber((-CDbl(xrow.Cells(1).Value) * CDbl(xrow.Cells(6).Value)) / 100, 0)

                xPPAsc2(0) += CDbl(xrow.Cells(2).Value)
                xPPAsc2(1) += FormatNumber((-CDbl(xrow.Cells(2).Value) * CDbl(xrow.Cells(6).Value)) / 100, 0)

                xPPAsc3(0) += CDbl(xrow.Cells(3).Value)
                xPPAsc3(1) += FormatNumber((CDbl(xrow.Cells(2).Value) * CDbl(xrow.Cells(6).Value)) / 100, 0)

                xPPAsc4(0) += CDbl(xrow.Cells(4).Value)
                xPPAsc4(1) += FormatNumber((CDbl(xrow.Cells(4).Value) * CDbl(xrow.Cells(6).Value)) / 100, 0)

            Next
            xPPApc1(0) = 0
            xPPApc1(1) = 0
            xPPApc2(0) = 0
            xPPApc2(1) = 0
            xPPApc3(0) = 0
            xPPApc3(1) = 0
            xPPApc4(0) = 0
            xPPApc4(1) = 0

            For Each xrow As DataGridViewRow In Me.DgPPApurchase.Rows
                If xrow.Index = 9 Then Exit For
                xPPApc1(0) += CDbl(xrow.Cells(1).Value)
                xPPApc1(1) += FormatNumber((-CDbl(xrow.Cells(1).Value) * CDbl(xrow.Cells(6).Value)) / 100, 0)

                xPPApc2(0) += CDbl(xrow.Cells(2).Value)
                xPPApc2(1) += FormatNumber((-CDbl(xrow.Cells(2).Value) * CDbl(xrow.Cells(6).Value)) / 100, 0)

                xPPApc3(0) += CDbl(xrow.Cells(3).Value)
                xPPApc3(1) += FormatNumber((CDbl(xrow.Cells(2).Value) * CDbl(xrow.Cells(6).Value)) / 100, 0)

                xPPApc4(0) += CDbl(xrow.Cells(4).Value)
                xPPApc4(1) += FormatNumber((CDbl(xrow.Cells(4).Value) * CDbl(xrow.Cells(6).Value)) / 100, 0)
            Next

        Catch ex As Exception

        End Try
    End Sub
End Class
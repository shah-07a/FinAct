Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Math
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Runtime.InteropServices ' For COMException
Imports Microsoft.Office.Interop.Excel
Imports Excel = Microsoft.Office.Interop.Excel

Public Class FrmVAT_vat15_WrkSheet
    Private Sub FrmVAT_vat15_WrkSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Text = Me.Text & "      FROM:- " & xVAT_DtF & "   TO:- " & xVAT_DtT
            xxFillDgWrkSheet10()
            xxFillDgZroRated()
            Me.BtnSave.Focus()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If MessageBox.Show("Are you sure to save current session of VAT15?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                CallVatForm(1)
            Else
                Return
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
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
    Private Sub xxFillDgWrkSheet10()
        Try
            Me.DgWrkSheet.Rows.Clear()
            Me.DgWrkSheet.AllowUserToAddRows = False
            Me.DgWrkSheet.Rows.Add(11)
            ''==RATE OF VAT
            Me.DgWrkSheet.Rows(0).Cells(0).Value = (" At 1%")
            Me.DgWrkSheet.Rows(1).Cells(0).Value = (" At 4%")
            Me.DgWrkSheet.Rows(2).Cells(0).Value = (" At 5%")
            Me.DgWrkSheet.Rows(3).Cells(0).Value = (" At 8.8%")
            Me.DgWrkSheet.Rows(4).Cells(0).Value = (" At 12.5%")
            'Me.DgWrkSheet.Rows(5).Cells(0).Value = (" At 13.5%")
            Me.DgWrkSheet.Rows(5).Cells(0).Value = (" At 20%")
            Me.DgWrkSheet.Rows(6).Cells(0).Value = (" At 22%")
            Me.DgWrkSheet.Rows(7).Cells(0).Value = (" At 27.5%")
            Me.DgWrkSheet.Rows(8).Cells(0).Value = (" At 30%")
            Me.DgWrkSheet.Rows(9).Cells(0).Value = (" Other (Specify)")
            Me.DgWrkSheet.Rows(10).Cells(0).Value = (" TOTAL")

            '==SALE WITHIN STATE

            Me.DgWrkSheet.Rows(0).Cells(1).Value = FormatNumber(xVAT_S1, 2) ' (" At 1%")
            Me.DgWrkSheet.Rows(1).Cells(1).Value = FormatNumber(xVAT_S4, 2) '(" At 4%")
            Me.DgWrkSheet.Rows(2).Cells(1).Value = FormatNumber(xVAT_S5, 2) '(" At 5%")
            Me.DgWrkSheet.Rows(3).Cells(1).Value = FormatNumber(xVAT_S8_8, 2) '(" At 8.8%")
            Me.DgWrkSheet.Rows(4).Cells(1).Value = FormatNumber(xVAT_S12_5, 2) '(" At 12.5%")
            ' Me.DgWrkSheet.Rows(5).Cells(1).Value = FormatNumber(xVAT_S13_5, 2) '(" At 13.5%")
            Me.DgWrkSheet.Rows(5).Cells(1).Value = FormatNumber(xVAT_S20, 2) '(" At 20%")
            Me.DgWrkSheet.Rows(6).Cells(1).Value = FormatNumber(xVAT_S22, 2) '(" At 22%")
            Me.DgWrkSheet.Rows(7).Cells(1).Value = FormatNumber(xVAT_S27_5, 2) '(" At 27.5%")
            Me.DgWrkSheet.Rows(8).Cells(1).Value = FormatNumber(xVAT_S30, 2) ' (" At 30%")
            Me.DgWrkSheet.Rows(9).Cells(1).Value = FormatNumber(xVAT_Sothr, 2) '(" Other (Specify)")
            '==VAT ON SALE WITH IN STATE
            Me.DgWrkSheet.Rows(0).Cells(2).Value = FormatNumber(xVAT_Sr1, 2) ' (" At 1%")
            Me.DgWrkSheet.Rows(1).Cells(2).Value = FormatNumber(xVAT_Sr4, 2) '(" At 4%")
            Me.DgWrkSheet.Rows(2).Cells(2).Value = FormatNumber(xVAT_Sr5, 2) '(" At 5%")
            Me.DgWrkSheet.Rows(3).Cells(2).Value = FormatNumber(xVAT_Sr8_8, 2) '(" At 8.8%")
            Me.DgWrkSheet.Rows(4).Cells(2).Value = FormatNumber(xVAT_Sr12_5, 2) '(" At 12.5%")
            ' Me.DgWrkSheet.Rows(5).Cells(2).Value = FormatNumber(xVAT_Sr13_5, 2) '(" At 13.5%")
            Me.DgWrkSheet.Rows(5).Cells(2).Value = FormatNumber(xVAT_Sr20, 2) '(" At 20%")
            Me.DgWrkSheet.Rows(6).Cells(2).Value = FormatNumber(xVAT_Sr22, 2) '(" At 22%")
            Me.DgWrkSheet.Rows(7).Cells(2).Value = FormatNumber(xVAT_Sr27_5, 2) '(" At 27.5%")
            Me.DgWrkSheet.Rows(8).Cells(2).Value = FormatNumber(xVAT_Sr30, 2) ' (" At 30%")
            Me.DgWrkSheet.Rows(9).Cells(2).Value = FormatNumber(xVAT_Srothr, 2) '(" Other (Specify)")

            '==PURCHASE WITHIN STATE
            Me.DgWrkSheet.Rows(0).Cells(3).Value = FormatNumber(xVAT_P1, 2) ' (" At 1%")
            Me.DgWrkSheet.Rows(1).Cells(3).Value = FormatNumber(xVAT_P4, 2) '(" At 4%")
            Me.DgWrkSheet.Rows(2).Cells(3).Value = FormatNumber(xVAT_P5, 2) '(" At 5%")
            Me.DgWrkSheet.Rows(3).Cells(3).Value = FormatNumber(xVAT_P8_8, 2) '(" At 8.8%")
            Me.DgWrkSheet.Rows(4).Cells(3).Value = FormatNumber(xVAT_P12_5, 2) '(" At 12.5%")
            'Me.DgWrkSheet.Rows(5).Cells(3).Value = FormatNumber(xVAT_P13_5, 2) '(" At 13.5%")
            Me.DgWrkSheet.Rows(5).Cells(3).Value = FormatNumber(xVAT_P20, 2) '(" At 20%")
            Me.DgWrkSheet.Rows(6).Cells(3).Value = FormatNumber(xVAT_P22, 2) '(" At 22%")
            Me.DgWrkSheet.Rows(7).Cells(3).Value = FormatNumber(xVAT_P27_5, 2) '(" At 27.5%")
            Me.DgWrkSheet.Rows(8).Cells(3).Value = FormatNumber(xVAT_P30, 2) ' (" At 30%")
            Me.DgWrkSheet.Rows(9).Cells(3).Value = FormatNumber(xVAT_Pothr, 2) '(" Other (Specify)")
            '==VAT ON PURCHASE WITH IN STATE
            Me.DgWrkSheet.Rows(0).Cells(4).Value = FormatNumber(xVAT_Pr1, 2) ' (" At 1%")
            Me.DgWrkSheet.Rows(1).Cells(4).Value = FormatNumber(xVAT_Pr4, 2) '(" At 4%")
            Me.DgWrkSheet.Rows(2).Cells(4).Value = FormatNumber(xVAT_Pr5, 2) '(" At 5%")
            Me.DgWrkSheet.Rows(3).Cells(4).Value = FormatNumber(xVAT_Pr8_8, 2) '(" At 8.8%")
            Me.DgWrkSheet.Rows(4).Cells(4).Value = FormatNumber(xVAT_Pr12_5, 2) '(" At 12.5%")
            'Me.DgWrkSheet.Rows(5).Cells(4).Value = FormatNumber(xVAT_Pr13_5, 2) '(" At 12.5%")
            Me.DgWrkSheet.Rows(5).Cells(4).Value = FormatNumber(xVAT_Pr20, 2) '(" At 20%")
            Me.DgWrkSheet.Rows(6).Cells(4).Value = FormatNumber(xVAT_Pr22, 2) '(" At 22%")
            Me.DgWrkSheet.Rows(7).Cells(4).Value = FormatNumber(xVAT_Pr27_5, 2) '(" At 27.5%")
            Me.DgWrkSheet.Rows(8).Cells(4).Value = FormatNumber(xVAT_Pr30, 2) ' (" At 30%")
            Me.DgWrkSheet.Rows(9).Cells(4).Value = FormatNumber(xVAT_Prothr, 2) '(" Other (Specify)")

            Dim xxTotalSale As Double = 0
            Dim xxTotalVonSale As Double = 0
            Dim xxTotalPur As Double = 0
            Dim xxTotalVonPur As Double = 0
            For Each xxDgr As DataGridViewRow In Me.DgWrkSheet.Rows
                xxTotalSale += Math.Round(CDbl(xxDgr.Cells(1).Value), 0)
                xxTotalVonSale += Math.Round(CDbl(xxDgr.Cells(2).Value), 0)
                xxTotalPur += Math.Round(CDbl(xxDgr.Cells(3).Value), 0)
                xxTotalVonPur += Math.Round(CDbl(xxDgr.Cells(4).Value), 0)
            Next
            Me.DgWrkSheet.Rows(10).Cells(1).Value = FormatNumber(xxTotalSale, 2) ' (" TOTAL")
            Me.DgWrkSheet.Rows(10).Cells(2).Value = FormatNumber(xxTotalVonSale, 2) ' (" TOTAL")
            Me.DgWrkSheet.Rows(10).Cells(3).Value = FormatNumber(xxTotalPur, 2) ' (" TOTAL")
            Me.DgWrkSheet.Rows(10).Cells(4).Value = FormatNumber(xxTotalVonPur, 2) '(" TOTAL")
            Me.DgWrkSheet.Rows(10).DefaultCellStyle.BackColor = Color.Yellow
            Me.DgWrkSheet.Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgWrkSheet.Columns(1).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgWrkSheet.Columns(2).DefaultCellStyle.BackColor = Color.LightPink
            Me.DgWrkSheet.Columns(3).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
            Me.DgWrkSheet.Columns(4).DefaultCellStyle.BackColor = Color.Cyan
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub xxFillDgZroRated()
        Try
            Me.DgZroRated.Rows.Clear()
            Me.DgZroRated.AllowUserToAddRows = False
            Me.DgZroRated.Rows.Add(3)
            ''==RATE OF VAT
            Me.DgZroRated.Rows(0).Cells(0).Value = (" DIRECT EXPORT OUT OF INDIA")
            Me.DgZroRated.Rows(1).Cells(0).Value = (" SALES AGAINST 'H' FORM")
            Me.DgZroRated.Rows(2).Cells(0).Value = (" TOTAL")

            Me.DgZroRated.Rows(0).Cells(1).Value = FormatNumber(xVAT_Sale_c, 2) ' (" GROSS DIRECT EXPORT OUT OF INDIA")
            Me.DgZroRated.Rows(1).Cells(1).Value = FormatNumber(xVAT_Sale_cA, 2) '(" GROSS SALES AGAINST 'H' FORM")
            Me.DgZroRated.Rows(2).Cells(1).Value = FormatNumber(xVAT_Sale_c + xVAT_Sale_cA, 2) ' (" TOTAL")
   
            Me.DgZroRated.Rows(0).Cells(2).Value = FormatNumber(xVAT_SaleRtd_c, 2) ' (" RETURN DIRECT EXPORT OUT OF INDIA")
            Me.DgZroRated.Rows(1).Cells(2).Value = FormatNumber(xVAT_SaleRtd_cA, 2)  '(" RETURN SALES AGAINST 'H' FORM")
            Me.DgZroRated.Rows(2).Cells(2).Value = FormatNumber(xVAT_SaleRtd_c + xVAT_SaleRtd_cA, 2) ' (" TOTAL")

            Me.DgZroRated.Rows(0).Cells(3).Value = FormatNumber(0, 2) ' (" DISCOUNT DIRECT EXPORT OUT OF INDIA")
            Me.DgZroRated.Rows(1).Cells(3).Value = FormatNumber(0, 2)  '(" DISCOUNT SALES AGAINST 'H' FORM")
            Me.DgZroRated.Rows(2).Cells(3).Value = FormatNumber(0, 2) ' (" TOTAL")

            Me.DgZroRated.Rows(0).Cells(4).Value = FormatNumber(xVAT_Sale_c - xVAT_SaleRtd_c, 2) ' (" NET DIRECT EXPORT OUT OF INDIA")
            Me.DgZroRated.Rows(1).Cells(4).Value = FormatNumber(xVAT_Sale_cA - xVAT_SaleRtd_cA, 2)  '(" NET SALES AGAINST 'H' FORM")
            Me.DgZroRated.Rows(2).Cells(4).Value = FormatNumber((xVAT_Sale_c + xVAT_Sale_cA) - (xVAT_SaleRtd_c + xVAT_SaleRtd_cA), 2) ' ("NET TOTAL")

            Me.DgZroRated.Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgZroRated.Columns(1).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgZroRated.Columns(2).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgZroRated.Columns(3).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgZroRated.Rows(2).DefaultCellStyle.BackColor = Color.Yellow
           
        Catch ex As Exception
            MsgBox(ex.Message)
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

    Private Sub BtnALL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.GotFocus, BtnBack.GotFocus, BtnSave.GotFocus
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnALL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Leave, BtnBack.Leave, BtnSave.Leave
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnForm1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnForm1.Click
        Try
            If MessageBox.Show("Are you sure to save current session of VAT1?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                CallVatForm(0)
            Else
                Return
            End If


        Catch ex As Exception

        End Try
    End Sub
End Class
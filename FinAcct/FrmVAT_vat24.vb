Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Math
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Runtime.InteropServices ' For COMException
Imports Microsoft.Office.Interop.Excel
Imports Excel = Microsoft.Office.Interop.Excel
Public Class FrmVAT_vat24
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader
    Private Sub BtnPRDMSTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPRDMSTR.Click
        Try
            xCall_LinkFrm(FrmPirdMstr, Me.CmbxPeriod)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPeriod_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPeriod.GotFocus
        Try
            Me.CmbxPeriod.DroppedDown = True
            If xCmbxRefresh = True Then
                Fill_Combobox("Perdid", "PerdName", "Finact_PerdMstr", "PerdDelStatus", CInt(1), Me.CmbxPeriod)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmVAT_vat15_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Try
                xTRUNCATETABLES()
            Catch ex As Exception

            End Try
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
    Private Sub FrmVAT_vat15_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Fill_Combobox("Perdid", "PerdName", "Finact_PerdMstr", "PerdDelStatus", CInt(1), Me.CmbxPeriod)
            Me.CmbxPeriod.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFillSelRec(ByVal xPerdid As Integer)
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            VATcmd = New SqlCommand("Finact_PerdMstr_Select", FinActConn1)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATcmd.Parameters.AddWithValue("@PerdId", CInt(xPerdid))
            VATrdr = VATcmd.ExecuteReader
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DtpVAT1.Value = VATrdr("perdFdt")
                    Me.DtpVAT2.Value = VATrdr("PerdTdt")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            VATcmd.Dispose()
            VATrdr.Close()
        End Try
    End Sub

    Private Sub CmbxPeriod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxPeriod.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxPeriod_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPeriod_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPeriod.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxPeriod) = True Then
                If Me.CmbxPeriod.SelectedIndex = 0 Then
                    xFillSelRec(Me.CmbxPeriod.SelectedValue)
                End If
                Me.BtnOK.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxPeriod.SelectedIndexChanged
        Try
            If Me.CmbxPeriod.SelectedIndex > 0 Then
                xFillSelRec(Me.CmbxPeriod.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Try
            If Me.BtnOK.Text.Trim = "&OK" Then
                Me.BtnOK.Text = "&RESET"
                Me.CmbxPeriod.Enabled = False
                Me.BtnPRDMSTR.Enabled = False
                x_VAT_Forms_xFillSalePurTable("Finact_Rpt_VAT_Purentry_FillTable", Me.DtpVAT1.Value.Date, Me.DtpVAT2.Value.Date)
                xFill_DgPurchase_WithPurchaseCategoriesNEW()
            Else
                Me.BtnOK.Text = "&OK"
                Me.DgPurchase.Rows.Clear()
                xTRUNCATETABLES()
                Me.CmbxPeriod.Enabled = True
                Me.BtnPRDMSTR.Enabled = True
                Me.CmbxPeriod.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.GotFocus, BtnEXIT.GotFocus, BtnV24.GotFocus
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Blue
            Me.BtnOK.ForeColor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOK_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.Leave, BtnEXIT.Leave, BtnV24.Leave
        Try
            Dim xBTN As Button = CType(sender, Button)
            xBTN.BackColor = Color.Transparent
            Me.BtnOK.ForeColor = Color.Navy
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xFill_DgPurchase_WithPurchaseCategories()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            VATcmd = New SqlCommand("Finact_Temp_VAT24_PUREntry_INSERT", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader
            Me.DgPurchase.Rows.Clear()
            Me.DgPurchase.AllowUserToAddRows = False
            Dim xS As Integer = 0
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DgPurchase.Rows.Add()
                    Me.DgPurchase.Rows(xS).Cells(0).Value = (xS + 1)
                    Me.DgPurchase.Rows(xS).Cells(1).Value = Trim(VATrdr("SPLRVATNO"))
                    Me.DgPurchase.Rows(xS).Cells(2).Value = Trim(VATrdr("SPLRNAME"))
                    Me.DgPurchase.Rows(xS).Cells(3).Value = Trim(VATrdr("CSCCTYNAME"))
                    Me.DgPurchase.Rows(xS).Cells(4).Value = FormatNumber(VATrdr("STF"), 2)
                    Me.DgPurchase.Rows(xS).Cells(5).Value = FormatNumber(VATrdr("SEXE"), 2)
                    Me.DgPurchase.Rows(xS).Cells(6).Value = FormatNumber(VATrdr("STAX"), 2)
                    Me.DgPurchase.Rows(xS).Cells(7).Value = FormatNumber(VATrdr("Vrate"), 2)
                    Me.DgPurchase.Rows(xS).Cells(8).Value = FormatNumber(VATrdr("VAT"), 2)
                    Me.DgPurchase.Rows(xS).Cells(9).Value = FormatNumber(VATrdr("SEXP"), 2)
                    Me.DgPurchase.Rows(xS).Cells(10).Value = FormatNumber(VATrdr("OTTAX"), 2)
                    Me.DgPurchase.Rows(xS).Cells(11).Value = Trim(VATrdr("TYPE"))
                    Me.DgPurchase.Rows(xS).Cells(12).Value = 0
                    xS += 1
                End If
            End While
            VATcmd.Dispose()
            VATrdr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
          
            If Me.DgPurchase.RowCount > 0 Then
                For Each xRw As DataGridViewRow In Me.DgPurchase.Rows
                    For Each xCEL As DataGridViewCell In xRw.Cells
                        If xCEL.ColumnIndex > 3 And xCEL.ColumnIndex < 11 Then
                            If xCEL.Value > 0 Then
                                xCEL.Style.BackColor = Color.Yellow
                            End If

                        End If
                    Next
                Next
            End If
            '======================
            If Me.DgPurchase.RowCount > 0 Then
                Dim xStf As Double = 0
                Dim xSexe As Double = 0
                Dim xStax As Double = 0
                Dim xExp As Double = 0
                Dim xVat As Double = 0
                For Each xrow As DataGridViewRow In Me.DgPurchase.Rows
                    xStf += CDbl(xrow.Cells(4).Value)
                    xSexe += CDbl(xrow.Cells(5).Value)
                    xStax += CDbl(xrow.Cells(6).Value)
                    xExp += CDbl(xrow.Cells(8).Value)
                    xVat += CDbl(xrow.Cells(9).Value)
                Next
                Me.DgPurchase.Rows.Add()
                Me.DgPurchase.Rows.Add()
                Me.DgPurchase.Rows(Me.DgPurchase.RowCount - 1).Cells(4).Value = FormatNumber(xStf, 2)
                Me.DgPurchase.Rows(Me.DgPurchase.RowCount - 1).Cells(5).Value = FormatNumber(xSexe, 2)
                Me.DgPurchase.Rows(Me.DgPurchase.RowCount - 1).Cells(6).Value = FormatNumber(xStax, 2)
                Me.DgPurchase.Rows(Me.DgPurchase.RowCount - 1).Cells(8).Value = FormatNumber(xExp, 2)
                Me.DgPurchase.Rows(Me.DgPurchase.RowCount - 1).Cells(9).Value = FormatNumber(xVat, 2)
                Me.DgPurchase.Rows(Me.DgPurchase.RowCount - 1).Cells(2).Value = "TOTAL ==>"
                Me.DgPurchase.Rows(Me.DgPurchase.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow

            End If
            '======================
        End Try
    End Sub
    Private Sub xFill_DgPurchase_WithPurchaseCategoriesNEW()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            VATcmd = New SqlCommand("Finact_Temp_VAT24NEW_PUREntry_INSERT", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader
            Me.DgPurchase.Rows.Clear()
            Me.DgPurchase.AllowUserToAddRows = False
            Dim xS As Integer = 0
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DgPurchase.Rows.Add()
                    Me.DgPurchase.Rows(xS).Cells(0).Value = (xS + 1)
                    Me.DgPurchase.Rows(xS).Cells(1).Value = Trim(VATrdr("SPLRVATNO"))
                    Me.DgPurchase.Rows(xS).Cells(2).Value = Trim(VATrdr("SPLRNAME"))
                    Me.DgPurchase.Rows(xS).Cells(3).Value = Trim(VATrdr("CSCCTYNAME"))
                    ''Me.DgPurchase.Rows(xS).Cells(4).Value = FormatNumber(VATrdr("STF"), 2)
                    ''Me.DgPurchase.Rows(xS).Cells(5).Value = FormatNumber(VATrdr("SEXE"), 2)
                    Me.DgPurchase.Rows(xS).Cells(6).Value = FormatNumber(VATrdr("VRATE"), 2)
                    Me.DgPurchase.Rows(xS).Cells(7).Value = FormatNumber(VATrdr("STAX"), 2)
                    Me.DgPurchase.Rows(xS).Cells(8).Value = FormatNumber(VATrdr("VAT"), 2)
                    Me.DgPurchase.Rows(xS).Cells(9).Value = FormatNumber(VATrdr("SUR"), 2)
                    Me.DgPurchase.Rows(xS).Cells(11).Value = FormatNumber(VATrdr("TOTAL"), 2)
                    Me.DgPurchase.Rows(xS).Cells(12).Value = Trim(VATrdr("TYPE"))

                    xS += 1
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
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnV24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnV24.Click
        Try
            If Me.DgPurchase.RowCount > 0 Then
                If MessageBox.Show("Are you sure to save current session of VAT24?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.BtnV24.Enabled = False
                    xVAT_DtF = Me.DtpVAT1.Value.Date
                    xVAT_DtT = Me.DtpVAT2.Value.Date
                    CallVatForm24()
                    System.Threading.Thread.Sleep(200)
                    Me.BtnV24.Enabled = True
                Else
                    Return
                End If
            Else
                MsgBox("Invalid input!", MsgBoxStyle.Critical, Me.Text)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CallVatForm24()
        Try
            CoInfo()
            Dim AppExcl As Excel.Application
            AppExcl = New Excel.Application

            If AppExcl Is Nothing Then
                MsgBox("Invalid Action: Excel Could not be Started!", MsgBoxStyle.Critical, "Sys Error")
                Environment.ExitCode = 0
                Exit Sub
            End If
            Dim xRows As Integer = Me.DgPurchase.RowCount
            If xRows <= 100 Then
                AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-24.xls")
            ElseIf xRows > 100 Or xRows <= 500 Then
                AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-24_1.xls")
            ElseIf xRows > 500 Or xRows <= 2000 Then
                AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-24_2.xls")
            ElseIf xRows > 2000 Or xRows <= 5000 Then
                AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-24_3.xls")
            ElseIf xRows > 5000 Then
                AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-24_4.xls")
            End If

            With AppExcl
                '.Visible = False
                .Range("B6").Value = CoName.Trim
                .Range("B8").Value = Adrs1.Trim & "," & Adrs2.Trim & "-" & Cty
                .Range("B10").Value = VATNO.Trim
                .Range("K12").Value = Format(xVAT_DtF.Date, "dd/MM/yyyy")
                .Range("M12").Value = Format(xVAT_DtT.Date, "dd/MM/yyyy")
            End With
            Dim ri As Integer = 17
            For Each xDgrow As DataGridViewRow In Me.DgPurchase.Rows
                If xDgrow.Index = xRows - 2 Then Exit For
                With AppExcl
                    .Range("A" & ri).Value = xDgrow.Cells(0).Value
                    .Range("B" & ri).Value = Mid(Trim(xDgrow.Cells(1).Value), 1, 11)
                    .Range("C" & ri).Value = Mid(Trim(xDgrow.Cells(2).Value), 1, 69)
                    .Range("D" & ri).Value = Mid(Trim(xDgrow.Cells(3).Value), 1, 89)
                    .Range("G" & ri).Value = FormatNumber(xDgrow.Cells(6).Value, 2, , , TriState.False)
                    .Range("H" & ri).Value = FormatNumber(xDgrow.Cells(7).Value, 2, , , TriState.False)
                    .Range("I" & ri).Value = FormatNumber(xDgrow.Cells(8).Value, 2, , , TriState.False)
                    .Range("J" & ri).Value = FormatNumber(xDgrow.Cells(9).Value, 2, , , TriState.False)
                End With
                ri += 1
            Next
            Dim xF As String = Mid(CoName.Trim, 1, 1)
            Dim xI As Integer = 0
            For Each xCh As Char In CoName.Trim
                xI += 1
                If xCh = " " Then
                    xF += Mid(CoName.Trim, xI + 1, 1)
                End If
            Next

            Dim xPth As String = String.Empty

            With AppExcl
                xPth = xChkxOrxCreateDir(xF.ToUpper & " " & Me.CmbxPeriod.Text.Trim)
                '==.ActiveWorkbook.SaveAs(xPth & "\PVAT24_1stQtr.XLS", , , , , , XlSaveAsAccessMode.xlNoChange) 'it is working ok
                '==.ActiveWorkbook.SaveAs(xPth & "\PVAT24_1stQtr.XLS", , "mohd@786#rafiq#vat24", , , , XlSaveAsAccessMode.xlNoChange) ' it work with password
                .ActiveWorkbook.SaveAs(xPth & "\PVAT-24.xls") '==simple
                .Visible = True
                .DisplayAlerts = False
                .Workbooks.Close()
                .Quit()
                ' MsgBox("You can find current file at: " & xPth)

            End With

            Debug.WriteLine("Sleeping...")
            System.Threading.Thread.Sleep(100)
            Debug.WriteLine("End Excel")
            releaseObject(AppExcl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
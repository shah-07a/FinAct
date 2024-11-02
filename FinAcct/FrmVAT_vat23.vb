Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Math
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Runtime.InteropServices ' For COMException
Imports Microsoft.Office.Interop.Excel
Imports Excel = Microsoft.Office.Interop.Excel
Public Class FrmVAT_vat23
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
                VATcmd = New SqlCommand("TRUNCATE TABLE Finact_Temp_VAT_SaleEntry", FinActConn)
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
                x_VAT_Forms_xFillSalePurTable("Finact_Rpt_VAT_Saleentry_FillTable", Me.DtpVAT1.Value.Date, Me.DtpVAT2.Value.Date)
                xFill_DgSale_WithSaleCategoriesNEW()
            Else
                Me.BtnOK.Text = "&OK"
                Me.DgSales.Rows.Clear()
                xTRUNCATETABLES()
                Me.CmbxPeriod.Enabled = True
                Me.BtnPRDMSTR.Enabled = True
                Me.CmbxPeriod.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub BtnOK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.GotFocus, BTNEXIT.GotFocus, BTNV23.GotFocus
    '    Try
    '        Dim xBTN As Button = CType(sender, Button)
    '        xBTN.BackColor = Color.Blue
    '        Me.BtnOK.ForeColor = Color.White
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub BtnOK_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.Leave, BTNEXIT.Leave, BTNV23.Leave
    '    Try
    '        Dim xBTN As Button = CType(sender, Button)
    '        xBTN.BackColor = Color.Transparent
    '        Me.BtnOK.ForeColor = Color.Navy
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub xFill_DgSale_WithSaleCategories()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            VATcmd = New SqlCommand("Finact_Temp_VAT23_SaleEntry_INSERT", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader
            Me.DgSales.Rows.Clear()
            Me.DgSales.AllowUserToAddRows = False
            Dim xS As Integer = 0
            Dim xSTAX As Double = 0 '===UN-REGD'
            Dim xVAT As Double = 0 '===UN-REGD'
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    If Trim(VATrdr("SPLRVATNO")) <> "UN-REGD" Then
                        Me.DgSales.Rows.Add()
                        Me.DgSales.Rows(xS).Cells(0).Value = (xS + 1)
                        Me.DgSales.Rows(xS).Cells(1).Value = Trim(VATrdr("SPLRVATNO"))
                        Me.DgSales.Rows(xS).Cells(2).Value = Trim(VATrdr("SPLRNAME"))
                        Me.DgSales.Rows(xS).Cells(3).Value = Trim(VATrdr("CSCCTYNAME"))
                        Me.DgSales.Rows(xS).Cells(4).Value = FormatNumber(VATrdr("STF"), 2)
                        Me.DgSales.Rows(xS).Cells(5).Value = FormatNumber(VATrdr("SEXE"), 2)
                        Me.DgSales.Rows(xS).Cells(6).Value = FormatNumber(VATrdr("STAX"), 2)
                        Me.DgSales.Rows(xS).Cells(7).Value = FormatNumber(VATrdr("SEXP"), 2)
                        Me.DgSales.Rows(xS).Cells(8).Value = FormatNumber(VATrdr("VAT"), 2)
                        Me.DgSales.Rows(xS).Cells(9).Value = Trim(VATrdr("TYPE"))
                        Me.DgSales.Rows(xS).Cells(10).Value = 0

                        xS += 1
                    Else
                        xSTAX += VATrdr("STAX")
                        xVAT += VATrdr("VAT")
                    End If
                End If
            End While
            If xSTAX > 0 Then
                Me.DgSales.Rows.Add()
                Me.DgSales.Rows(xS).Cells(0).Value = (xS + 1)
                Me.DgSales.Rows(xS).Cells(1).Value = Trim("UN-REGD")
                Me.DgSales.Rows(xS).Cells(2).Value = Trim("SALE TO UN-REGD. DEALER WITH IN STATE")
                Me.DgSales.Rows(xS).Cells(3).Value = Trim("WITH IN STATE")
                Me.DgSales.Rows(xS).Cells(4).Value = FormatNumber(0, 2)
                Me.DgSales.Rows(xS).Cells(5).Value = FormatNumber(0, 2)
                Me.DgSales.Rows(xS).Cells(6).Value = FormatNumber(xSTAX, 2)
                Me.DgSales.Rows(xS).Cells(7).Value = FormatNumber(0, 2)
                Me.DgSales.Rows(xS).Cells(8).Value = FormatNumber(xVAT, 2)
                Me.DgSales.Rows(xS).Cells(9).Value = Trim("WITH IN STATE")
                Me.DgSales.Rows(xS).Cells(10).Value = 0
            End If
            VATcmd.Dispose()
            VATrdr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Me.DgSales.RowCount > 0 Then
                Dim xStf As Double = 0
                Dim xSexe As Double = 0
                Dim xStax As Double = 0
                Dim xExp As Double = 0
                Dim xVat As Double = 0
                For Each xrow As DataGridViewRow In Me.DgSales.Rows
                    xStf += CDbl(xrow.Cells(4).Value)
                    xSexe += CDbl(xrow.Cells(5).Value)
                    xStax += CDbl(xrow.Cells(6).Value)
                    xExp += CDbl(xrow.Cells(7).Value)
                    xVat += CDbl(xrow.Cells(8).Value)
                Next
                Me.DgSales.Rows.Add()
                Me.DgSales.Rows.Add()
                Me.DgSales.Rows(Me.DgSales.RowCount - 1).Cells(4).Value = FormatNumber(xStf, 2)
                Me.DgSales.Rows(Me.DgSales.RowCount - 1).Cells(5).Value = FormatNumber(xSexe, 2)
                Me.DgSales.Rows(Me.DgSales.RowCount - 1).Cells(6).Value = FormatNumber(xStax, 2)
                Me.DgSales.Rows(Me.DgSales.RowCount - 1).Cells(7).Value = FormatNumber(xExp, 2)
                Me.DgSales.Rows(Me.DgSales.RowCount - 1).Cells(8).Value = FormatNumber(xVat, 2)
                Me.DgSales.Rows(Me.DgSales.RowCount - 1).Cells(2).Value = "TOTAL ==>"
                Me.DgSales.Rows(Me.DgSales.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow

            End If
        End Try
    End Sub
    Private Sub xFill_DgSale_WithSaleCategoriesNEW()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            VATcmd = New SqlCommand("Finact_Temp_VAT23NEW_SaleEntry_INSERT", FinActConn)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader
            Me.DgSales.Rows.Clear()
            Me.DgSales.AllowUserToAddRows = False
            Dim xS As Integer = 0
          
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DgSales.Rows.Add()
                    Me.DgSales.Rows(xS).Cells(0).Value = (xS + 1)
                    Me.DgSales.Rows(xS).Cells(1).Value = Trim(VATrdr("SPLRVATNO"))
                    Me.DgSales.Rows(xS).Cells(2).Value = Trim(VATrdr("SPLRNAME"))
                    Me.DgSales.Rows(xS).Cells(3).Value = Trim(VATrdr("CSCCTYNAME"))
                    Me.DgSales.Rows(xS).Cells(4).Value = ""
                    Me.DgSales.Rows(xS).Cells(5).Value = ""
                    Me.DgSales.Rows(xS).Cells(6).Value = FormatNumber(VATrdr("VRATE"), 2)
                    Me.DgSales.Rows(xS).Cells(7).Value = FormatNumber(VATrdr("STAX"), 2)
                    Me.DgSales.Rows(xS).Cells(8).Value = FormatNumber(VATrdr("VAT"), 2)
                    Me.DgSales.Rows(xS).Cells(9).Value = FormatNumber(VATrdr("SUR"), 2)
                    Me.DgSales.Rows(xS).Cells(10).Value = ""
                    Me.DgSales.Rows(xS).Cells(11).Value = FormatNumber(VATrdr("TOTAL"), 2)
                    Me.DgSales.Rows(xS).Cells(12).Value = Trim(VATrdr("TYPE"))
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTNV23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNV23.Click
        Try
            If Me.DgSales.RowCount > 0 Then
                If MessageBox.Show("Are you sure to save current session of VAT23?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.BTNV23.Enabled = False
                    xVAT_DtF = Me.DtpVAT1.Value.Date
                    xVAT_DtT = Me.DtpVAT2.Value.Date
                    CallVatForm23()
                    System.Threading.Thread.Sleep(200)
                    Me.BTNV23.Enabled = True
                Else
                    Return
                End If
            Else
                MsgBox("Invalid input!", MsgBoxStyle.Critical, Me.Text)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CallVatForm23()
        Try
            CoInfo()
            Dim AppExcl As Excel.Application
            AppExcl = New Excel.Application

            If AppExcl Is Nothing Then
                MsgBox("Invalid Action: Excel Could not be Started!", MsgBoxStyle.Critical, "Sys Error")
                Environment.ExitCode = 0
                Exit Sub
            End If
            Dim xRows As Integer = Me.DgSales.RowCount
            If xRows <= 100 Then
                AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-23.xls")
            ElseIf xRows > 100 Or xRows <= 500 Then
                AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-23_1.xls")
            ElseIf xRows > 500 Or xRows <= 2000 Then
                AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-23_2).xls")
            ElseIf xRows > 2000 Or xRows <= 5000 Then
                AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-23_3).xls")
            ElseIf xRows > 5000 Then
                AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-23_4.xls")
            End If

            With AppExcl
                '.Visible = False
                .Range("B6").Value = VATNO.Trim
                .Range("E8").Value = Format(xVAT_DtF.Date, "dd/MM/yyyy")
                .Range("G8").Value = Format(xVAT_DtT.Date, "dd/MM/yyyy")
                .Range("B10").Value = CoName.Trim
                .Range("B12").Value = Adrs1.Trim & "," & Adrs2.Trim & "-" & Cty
            End With
            Dim ri As Integer = 16
            For Each xDgrow As DataGridViewRow In Me.DgSales.Rows
                ''===  If xDgrow.Index = xRows - 0 Then Exit For
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
                If Len(xPth.Trim) = 0 Then Exit Sub
                '==.ActiveWorkbook.SaveAs(xPth & "\PVAT23_1stQtr.XLS", , , , , , XlSaveAsAccessMode.xlNoChange) 'it is working ok
                '==.ActiveWorkbook.SaveAs(xPth & "\PVAT23_1stQtr.XLS", , "mohd@786#rafiq#vat23", , , , XlSaveAsAccessMode.xlNoChange) ' it work with password
                .ActiveWorkbook.SaveAs(xPth & "\PVAT-23.xls") '==simple
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
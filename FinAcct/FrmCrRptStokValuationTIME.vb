Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCrRptStokValuationTIME
    Dim StkvalCmd As SqlCommand
    Dim StkvalRdr As SqlDataReader
    Private Sub FrmStokValuation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Height = 89
            FillTempTable_StokRegsumr()
            Me.RbSALEPRICE.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If Me.BtnOk.Text = "&OK" Then
                Me.BtnOk.Text = "&CANCEL"
                Me.GroupBox1.Enabled = False
                Me.Cursor = Cursors.WaitCursor
                SelRecd_Fromtable_StokIssue()
                Me.Height = Screen.PrimaryScreen.WorkingArea.Height - 50
                Me.Cursor = Cursors.Default
            Else
                Me.BtnOk.Text = "&OK"
                Me.GroupBox1.Enabled = True
                Me.Height = 89
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.GotFocus
        Try
            Me.BtnOk.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Leave
        Try
            Me.BtnOk.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllContrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbOalAvg.KeyDown, RbSALEPRICE.KeyDown, RbMANUAL.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillTempTable_StokRegsumr()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            StkvalCmd = New SqlCommand("Finact_Rpt_STOCKVALUE_SALE_ITEM_FillTable", FinActConn)
            StkvalCmd.CommandType = CommandType.StoredProcedure
            StkvalCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- FillTempTable_Ldgr, Line No. 38 ")
        Finally
            StkvalCmd.Dispose()

        End Try

    End Sub


    Private Sub SelRecd_Fromtable_StokIssue()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_Rpt_STOCKVALUE_SALE_ITEM_FORTIME_SELECT", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            If Me.RbOalAvg.Checked = True Then
                FinActCmd.Parameters.AddWithValue("@xCMDINDX", 1)
            ElseIf Me.RbSALEPRICE.Checked = True Then
                FinActCmd.Parameters.AddWithValue("@xCMDINDX", 2)
            ElseIf Me.RbMANUAL.Checked = True Then
                FinActCmd.Parameters.AddWithValue("@xCMDINDX", 3)
            End If

            FinActRdr = FinActCmd.ExecuteReader
            Me.DgStkVal.Rows.Clear()
            Me.DgStkVal.AllowUserToAddRows = False
            Dim xdr As Integer = 0
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    Me.DgStkVal.Rows.Add()
                    Me.DgStkVal.Rows(xdr).Cells(0).Value = Trim(FinActRdr("StkItmName"))
                    Dim xQin As Double = CDbl(FinActRdr("xIN"))
                    Dim xQout As Double = CDbl(FinActRdr("xOUT"))
                    Dim xRate As Double = 0
                    If Me.RbSALEPRICE.Checked = True Then
                        xRate = CDbl(FinActRdr("xINRATE"))
                    Else
                        xRate = CDbl(FinActRdr("xOUTRATE"))
                    End If

                    Me.DgStkVal.Rows(xdr).Cells(1).Value = FormatNumber(xQin, 3)
                    Me.DgStkVal.Rows(xdr).Cells(2).Value = FormatNumber(xQout, 3)
                    Me.DgStkVal.Rows(xdr).Cells(3).Value = FormatNumber(xQin - xQout, 3)
                    Me.DgStkVal.Rows(xdr).Cells(4).Value = Trim(FinActRdr("stkisunt"))
                    Me.DgStkVal.Rows(xdr).Cells(5).Value = FormatNumber(xRate, 2)
                    Me.DgStkVal.Rows(xdr).Cells(6).Value = FormatNumber((xQin - xQout) * xRate, 2)
                    xdr += 1
                End If
            End While

            Me.DgStkVal.Rows.Add()

            Me.DgStkVal.Columns(0).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgStkVal.Columns(1).DefaultCellStyle.BackColor = Color.LightGray
            Me.DgStkVal.Columns(2).DefaultCellStyle.BackColor = Color.LightSkyBlue
            Me.DgStkVal.Columns(3).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgStkVal.Columns(4).DefaultCellStyle.BackColor = Color.LightSteelBlue
            If Me.RbMANUAL.Checked = True Then
                Me.DgStkVal.Columns(5).DefaultCellStyle.BackColor = Color.White
                Me.DgStkVal.Columns(5).ReadOnly = False
            Else
                Me.DgStkVal.Columns(5).DefaultCellStyle.BackColor = Color.LightPink
                Me.DgStkVal.Columns(5).ReadOnly = True
            End If

            Me.DgStkVal.Columns(6).DefaultCellStyle.BackColor = Color.LightYellow
            Dim xTOTL As Double = 0
            Dim xlASTROW As Integer = Me.DgStkVal.Rows.Count - 1
            For Each Drow As DataGridViewRow In Me.DgStkVal.Rows
                xTOTL += Drow.Cells(6).Value
            Next
            Me.LblITM.Text = FormatNumber(xlASTROW, 0)
            Me.LblAMT.Text = FormatNumber(xTOTL, 2)

            Me.DgStkVal.Rows(xlASTROW).Cells(0).Value = "TOTAL ========>>"
            Me.DgStkVal.Rows(xlASTROW).Cells(6).Value = FormatNumber(xTOTL, 2)
            Me.DgStkVal.Rows(xlASTROW).DefaultCellStyle.BackColor = Color.Yellow
            Me.DgStkVal.Rows(xlASTROW).ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()

        End Try
    End Sub
    Private Sub xCALC()
        Try
            Dim xTOTL As Double = 0
            Dim xlASTROW As Integer = Me.DgStkVal.Rows.Count - 1

            For ix As Integer = 0 To xlASTROW - 1
                xTOTL += Me.DgStkVal.Rows(ix).Cells(6).Value
            Next
            Me.LblITM.Text = FormatNumber(xlASTROW, 0)
            Me.LblAMT.Text = FormatNumber(xTOTL, 2)

            Me.DgStkVal.Rows(xlASTROW).Cells(0).Value = "TOTAL ========>>"
            Me.DgStkVal.Rows(xlASTROW).Cells(6).Value = FormatNumber(xTOTL, 2)
            Me.DgStkVal.Rows(xlASTROW).DefaultCellStyle.BackColor = Color.Yellow
            Me.DgStkVal.Rows(xlASTROW).ReadOnly = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgStkVal_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgStkVal.CellEndEdit
        Try
            If e.ColumnIndex = 5 Then
                Me.DgStkVal.CurrentRow.Cells(5).Value = FormatNumber(Me.DgStkVal.CurrentRow.Cells(5).Value, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgStkVal_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgStkVal.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgStkVal.Rows.Count '- 1
            If Cr_Row <> Me.DgStkVal.CurrentRow.Index Then
                If e.ColumnIndex = 5 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgStkVal.CurrentCell.ErrorText = "Only Number are allowed"
                        ' Me.DgStkVal.CurrentRow.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        Me.DgStkVal.CurrentCell.ErrorText = ""
                        ' Me.DgStkVal.CurrentRow.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

   

    Private Sub DgStkVal_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgStkVal.CellValueChanged
        Try
            If Me.DgStkVal.RowCount = 0 Then Exit Sub
            If e.ColumnIndex = 5 Then
                Me.DgStkVal.CurrentRow.Cells(6).Value = FormatNumber(CDbl(Me.DgStkVal.CurrentRow.Cells(3).Value) * CDbl(Me.DgStkVal.CurrentRow.Cells(5).Value), 2)
                xCALC()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RbMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbMANUAL.CheckedChanged

    End Sub
End Class
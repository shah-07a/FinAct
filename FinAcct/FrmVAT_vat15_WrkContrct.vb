Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat15_WrkContrct
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader

    Private Sub FrmVAT_vat15_WrkSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Text = Me.Text & "      FROM:- " & xVAT_DtF & "   TO:- " & xVAT_DtT
            xxFillDgWrkContrct11()
            xCOINFO_WRKCONTRCT()
            If xVAT_FlagWc = True Then
                xFetchFromWcAl(Me.DgWrkContrct)
            End If

            Me.BtnNxt.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNxt.Click
        Try
            xDgValuesWc(Me.DgWrkContrct)
            Me.Close()
            xVAT_FlagWc = True
            Dim xFrmPPA As New FrmVAT_vat15_PriorPerdAdjstmnt
            xFrmPPA.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(xFrmPPA)
            xFrmPPA.BringToFront()
            xFrmPPA.Show()
        Catch ex As Exception

        End Try
    End Sub

 
    Private Sub xxFillDgWrkContrct11()
        Try
            Me.DgWrkContrct.Rows.Clear()
            Me.DgWrkContrct.AllowUserToAddRows = False
            Me.DgWrkContrct.Rows.Add(10)
            ''==RATE OF VAT
            Me.DgWrkContrct.Rows(0).Cells(0).Value = (" At 1%")
            Me.DgWrkContrct.Rows(1).Cells(0).Value = (" At 4%")
            Me.DgWrkContrct.Rows(2).Cells(0).Value = (" At 5%")
            Me.DgWrkContrct.Rows(3).Cells(0).Value = (" At 8.8%")
            Me.DgWrkContrct.Rows(4).Cells(0).Value = (" At 12.5%")
            ' Me.DgWrkContrct.Rows(5).Cells(0).Value = (" At 13.5%")
            Me.DgWrkContrct.Rows(5).Cells(0).Value = (" At 20%")
            Me.DgWrkContrct.Rows(6).Cells(0).Value = (" At 22%")
            Me.DgWrkContrct.Rows(7).Cells(0).Value = (" At 27.5%")
            Me.DgWrkContrct.Rows(8).Cells(0).Value = (" At 30%")
            Me.DgWrkContrct.Rows(9).Cells(0).Value = (" TOTAL")


            Me.DgWrkContrct.Rows(0).Cells(7).Value = CDbl(1.0)
            Me.DgWrkContrct.Rows(1).Cells(7).Value = CDbl(4.0)
            Me.DgWrkContrct.Rows(2).Cells(7).Value = CDbl(5.0)
            Me.DgWrkContrct.Rows(3).Cells(7).Value = CDbl(8.8)
            Me.DgWrkContrct.Rows(4).Cells(7).Value = CDbl(12.5)
            ' Me.DgWrkContrct.Rows(5).Cells(7).Value = CDbl(13.5)
            Me.DgWrkContrct.Rows(5).Cells(7).Value = CDbl(20.0)
            Me.DgWrkContrct.Rows(6).Cells(7).Value = CDbl(22.0)
            Me.DgWrkContrct.Rows(7).Cells(7).Value = CDbl(27.5)
            Me.DgWrkContrct.Rows(8).Cells(7).Value = CDbl(30.0)
            Me.DgWrkContrct.Rows(9).Cells(7).Value = CDbl(0.0)



            '==SALE WITHIN STATE

            Me.DgWrkContrct.Rows(9).DefaultCellStyle.BackColor = Color.Yellow
            Me.DgWrkContrct.Columns(0).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgWrkContrct.Columns(1).DefaultCellStyle.BackColor = Color.White
            Me.DgWrkContrct.Columns(2).DefaultCellStyle.BackColor = Color.LightPink
            Me.DgWrkContrct.Columns(3).DefaultCellStyle.BackColor = Color.LightPink
            Me.DgWrkContrct.Columns(4).DefaultCellStyle.BackColor = Color.LightPink
            Me.DgWrkContrct.Columns(5).DefaultCellStyle.BackColor = Color.White
            Me.DgWrkContrct.Columns(6).DefaultCellStyle.BackColor = Color.LightPink
            Me.DgWrkContrct.Rows(7).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgWrkContrct.Rows(8).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgWrkContrct.Rows(7).ReadOnly = True
            Me.DgWrkContrct.Rows(8).ReadOnly = True
            Me.DgWrkContrct.Rows(9).ReadOnly = True


        Catch ex As Exception
            MsgBox(ex.ToString)
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



    Private Sub DgWrkContrct_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgWrkContrct.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgWrkContrct.Rows.Count '- 1
            If Cr_Row <> Me.DgWrkContrct.CurrentRow.Index Then
                If e.ColumnIndex = 1 Or e.ColumnIndex = 5 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgWrkContrct.CurrentCell.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        Me.DgWrkContrct.CurrentCell.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgWrkContrct_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgWrkContrct.CellValueChanged
        Try
            If Not Me.DgWrkContrct.RowCount > 1 Then Exit Sub
            If e.ColumnIndex = 1 Then
                'Dim ii As Integer = Me.DgWrkContrct.CurrentRow.Index
                Dim xGrsVal As Double = 0
                xGrsVal = CDbl(Me.DgWrkContrct.CurrentRow.Cells(1).Value)
                Me.DgWrkContrct.CurrentRow.Cells(1).Value = FormatNumber(Math.Round(xGrsVal, 1), 2)
                Dim xLbr As Double = (xGrsVal * 40) / 100
                Me.DgWrkContrct.CurrentRow.Cells(2).Value = FormatNumber(Math.Round(xLbr, 1), 2)
                Me.DgWrkContrct.CurrentRow.Cells(3).Value = FormatNumber(Math.Round(xGrsVal - xLbr, 1), 2)
                Dim xTxAbl As Double = CDbl(Me.DgWrkContrct.CurrentRow.Cells(3).Value)
                Dim xRate As Double = CDbl(Me.DgWrkContrct.CurrentRow.Cells(7).Value) / 100
                Dim xVtx As Double = (xTxAbl * xRate)
                Dim xVtxSur As Double = xVtx + (xVtx * 0.1)
                Me.DgWrkContrct.CurrentRow.Cells(4).Value = FormatNumber(Math.Round(xVtxSur, 1), 2)
                Dim xTDSVal As Double = 0
                xTDSVal = CDbl(Me.DgWrkContrct.CurrentRow.Cells(5).Value)
                Me.DgWrkContrct.CurrentRow.Cells(5).Value = FormatNumber(Math.Round(xTDSVal, 1), 2)
                Dim xOutTx As Double = CDbl(Me.DgWrkContrct.CurrentRow.Cells(4).Value)
                Me.DgWrkContrct.CurrentRow.Cells(6).Value = FormatNumber(Math.Round((xOutTx - xTDSVal), 1), 2)
                Dim c1 As Double = 0, c2 As Double = 0, c3 As Double = 0, c4 As Double = 0, c5 As Double = 0, c6 As Double = 0
                For Each xxrow As DataGridViewRow In Me.DgWrkContrct.Rows
                    If xxrow.Index = 9 Then Exit For
                    c1 += CDbl(xxrow.Cells(1).Value)
                    c2 += CDbl(xxrow.Cells(2).Value)
                    c3 += CDbl(xxrow.Cells(3).Value)
                    c4 += CDbl(xxrow.Cells(4).Value)
                    c5 += CDbl(xxrow.Cells(5).Value)
                    c6 += CDbl(xxrow.Cells(6).Value)
                Next
                Me.DgWrkContrct.Rows(9).Cells(1).Value = FormatNumber(Math.Round(c1, 1), 2) '
                Me.DgWrkContrct.Rows(9).Cells(2).Value = FormatNumber(Math.Round(c2, 1), 2) ' FormatNumber(c2, 2)
                Me.DgWrkContrct.Rows(9).Cells(3).Value = FormatNumber(Math.Round(c3, 1), 2) 'FormatNumber(c3, 2)
                Me.DgWrkContrct.Rows(9).Cells(4).Value = FormatNumber(Math.Round(c4, 1), 2) ' FormatNumber(c4, 2)
                Me.DgWrkContrct.Rows(9).Cells(5).Value = FormatNumber(Math.Round(c5, 1), 2) ' FormatNumber(c5, 2)
                Me.DgWrkContrct.Rows(9).Cells(6).Value = FormatNumber(Math.Round(c6, 1), 2) 'FormatNumber(c6, 2)
            End If
            If e.ColumnIndex = 5 Then
                Dim xTDSVal As Double = 0
                xTDSVal = CDbl(Me.DgWrkContrct.CurrentRow.Cells(5).Value)
                Me.DgWrkContrct.CurrentRow.Cells(5).Value = FormatNumber(Math.Round(xTDSVal, 1), 2)
                Dim xOutTx As Double = CDbl(Me.DgWrkContrct.CurrentRow.Cells(4).Value)
                Me.DgWrkContrct.CurrentRow.Cells(6).Value = FormatNumber(Math.Round((xOutTx - xTDSVal), 1), 2)
                Dim c5 As Double = 0, c6 As Double = 0
                For Each xxrow As DataGridViewRow In Me.DgWrkContrct.Rows
                    If xxrow.Index = 9 Then Exit For
                    c5 += CDbl(xxrow.Cells(5).Value)
                    c6 += CDbl(xxrow.Cells(6).Value)
                Next
                Me.DgWrkContrct.Rows(9).Cells(5).Value = FormatNumber(Math.Round(c5, 1), 2) ' FormatNumber(c5, 2)
                Me.DgWrkContrct.Rows(9).Cells(6).Value = FormatNumber(Math.Round(c6, 1), 2) ' FormatNumber(c6, 2)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
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
            If MessageBox.Show("Moving back from current page you will lost all data. Would you like to proceed back?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
                Dim VAT15prd As New FrmVAT_vat15_PriodSel
                VAT15prd.MdiParent = FrmMainMdi
                FrmMainMdi.SplitContainer1.Panel2.Controls.Add(VAT15prd)
                VAT15prd.BringToFront()
                VAT15prd.Show()
            Else
                Return
            End If
           
        Catch ex As Exception

        End Try
    End Sub
  
    Private Sub DgWrkContrct_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgWrkContrct.CellContentClick

    End Sub
End Class
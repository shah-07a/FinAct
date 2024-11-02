Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCrRptInttOnOvrDuePayable
    Dim RSBCMD As SqlCommand
    Dim RSBRDR As SqlDataReader

    Private Sub FrmCrRptRecvablBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Size = New System.Drawing.Point(890, 100)
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpFrom, Me.DtpTo)
            xFilltable()
            xFillCmbxHavingbal()
            Me.Cmbxrange.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFilltable()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            RSBCMD = New SqlCommand("Finact_PURENTRY_INTEREST_ONOVERDUES_Select", FinActConn)
            RSBCMD.CommandType = CommandType.StoredProcedure
            RSBCMD.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            RSBCMD.Dispose()
        End Try
    End Sub


    Private Sub xSelRec()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            RSBCMD = New SqlCommand("FINACT_Rpt_TEMP_PURCHASEBILL_OVERDUE_INTT_Select", FinActConn)
            RSBCMD.CommandType = CommandType.StoredProcedure
            RSBCMD.Parameters.AddWithValue("@DtF", Me.DtpFrom.Value.Date)
            RSBCMD.Parameters.AddWithValue("@DtT", Me.DtpTo.Value.Date)
            RSBCMD.Parameters.AddWithValue("@Optn", 1)
            RSBCMD.Parameters.AddWithValue("@Pid", Me.Cmbxrange.SelectedValue)

            RSBRDR = RSBCMD.ExecuteReader
            Dim xi As Integer = 0
            Me.DgRecvBill.Rows.Clear()
            While RSBRDR.Read
                If RSBRDR.IsDBNull(0) = False Then
                    Me.DgRecvBill.Rows.Add()
                    Me.DgRecvBill.Rows(xi).Cells(0).Value = Format(RSBRDR("DT"), "dd/MM/yyyy")
                    Me.DgRecvBill.Rows(xi).Cells(1).Value = RSBRDR("REFNO")
                    Me.DgRecvBill.Rows(xi).Cells(2).Value = FormatNumber(RSBRDR("BILBAL"), 2)
                    Me.DgRecvBill.Rows(xi).Cells(3).Value = FormatNumber(RSBRDR("INTT_RATE"), 2)
                    Me.DgRecvBill.Rows(xi).Cells(4).Value = Format(RSBRDR("DUEDT"), "dd/MM/yyyy")
                    Me.DgRecvBill.Rows(xi).Cells(5).Value = Int(RSBRDR("DUEDAY"))
                    Me.DgRecvBill.Rows(xi).Cells(6).Value = FormatNumber(RSBRDR("AMT"), 2)
                    Me.DgRecvBill.Rows(xi).Cells(7).Value = Int(RSBRDR("RECID"))
                    xi += 1
                End If
            End While
            Dim DueBilBal As Double = 0
            Me.DgRecvBill.Rows.Add()
            Me.DgRecvBill.Rows(Me.DgRecvBill.RowCount - 1).Cells(0).Value = "==TOTAL==>"
            Me.DgRecvBill.Rows(Me.DgRecvBill.RowCount - 1).ReadOnly = True
            Me.DgRecvBill.Rows(Me.DgRecvBill.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
            For Each xRow As DataGridViewRow In Me.DgRecvBill.Rows
                DueBilBal += xRow.Cells(6).Value
            Next
            Me.DgRecvBill.Rows(Me.DgRecvBill.RowCount - 1).Cells(6).Value = FormatNumber(DueBilBal, 2)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            RSBCMD.Dispose()
            RSBRDR.Close()
        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If Me.Cmbxrange.SelectedIndex = -1 Then Exit Sub
            xSelRec()
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, Screen.PrimaryScreen.WorkingArea.Height - 50)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFillCmbxHavingbal()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            dtaset = New DataSet
            dtaset.Tables.Clear()
            RSBCMD = New SqlCommand("FINACT_Rpt_TEMP_PURBILL_OVERDUE_FILLCMBX_Select", FinActConn)
            RSBCMD.CommandType = CommandType.StoredProcedure
            RSBCMD.Parameters.AddWithValue("@DtF", Me.DtpFrom.Value.Date)
            RSBCMD.Parameters.AddWithValue("@DtT", Me.DtpTo.Value.Date)
            SqlAdptr = New SqlDataAdapter(RSBCMD)
            dtaset = New DataSet(RSBCMD.CommandText)
            SqlAdptr.Fill(dtaset)
            Me.Cmbxrange.DataSource = dtaset.Tables(0)
            Me.Cmbxrange.ValueMember = "Splrid"
            Me.Cmbxrange.DisplayMember = "SplrName"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            RSBCMD.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub

    Private Sub Cmbxrange_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxrange.GotFocus
        Try
            Me.Cmbxrange.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxrange_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxrange.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Cmbxrange_Leave(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxrange_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxrange.Leave
        Try
            If CheckBlank_Cmbx(Me.Cmbxrange) = True Then
                Me.BtnOk.Focus()
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
End Class
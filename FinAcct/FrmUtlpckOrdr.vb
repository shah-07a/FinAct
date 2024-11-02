Imports System.Data
Imports System.Data.SqlClient
Public Class FrmUtlpckOrdr
    Dim xCmboBx As ComboBox
    Dim Dgcom As DataGridViewComboBoxCell
    Dim xxSplrid As Integer = 0
    Private Sub FrmUtlpckOrdr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 50
            Fill_Combobox("Itmid", "Itmcode", "finactitmmstr", "ITMDelStatus", CInt(1), Me.CmbxITMCODE)
            Fill_Combobox("saleid", "saleordno", "finactsaleorder", "SaleDelStatus", CInt(1), Me.CmbxOrdNO)
            Me.CmbxOrdNO.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxITMCODE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxITMCODE.GotFocus
        Try
            Me.CmbxITMCODE.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxITMCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxITMCODE.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxITMCODE_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxITMCODE_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxITMCODE.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxITMCODE) = True Then
                If Me.CmbxITMCODE.SelectedIndex = 0 Then
                    Me.DgPckNote.CurrentRow.Cells(3).Value = xDynamic_Find_xAnItem_xInA_Table_1cond_String("Itmname", "Itmid", CInt(Me.CmbxITMCODE.SelectedValue), "finactitmmstr")
                End If
                Me.DgPckNote.CurrentRow.Cells(2).Value = Me.CmbxITMCODE.Text.Trim
                Me.DgPckNote.CurrentRow.Cells(5).Value = CInt(Me.CmbxITMCODE.SelectedValue)
                Me.CmbxITMCODE.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CmbxITMCODE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxITMCODE.SelectedIndexChanged
        Try
            If Me.CmbxITMCODE.SelectedIndex > 0 Then
                Me.DgPckNote.CurrentRow.Cells(3).Value = xDynamic_Find_xAnItem_xInA_Table_1cond_String("Itmname", "Itmid", CInt(Me.CmbxITMCODE.SelectedValue), "finactitmmstr")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgPcknote_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPckNote.CellClick
        Try
            If Not (e.RowIndex) = -1 And e.ColumnIndex = 2 Then

                Dim r As Rectangle = Me.DgPckNote.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
                Me.CmbxITMCODE.Size = New System.Drawing.Point(r.Width, r.Height)
                xCreate_CmbxInGrid(r.X + 0, r.Y + 0)
                Me.CmbxITMCODE.Visible = True
                Me.CmbxITMCODE.Enabled = True
                Me.CmbxITMCODE.DroppedDown = True
                Me.CmbxITMCODE.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xCreate_CmbxInGrid(ByVal Rindx As Integer, ByVal Cindx As Integer)
        Try
            Me.CmbxITMCODE.Location = New System.Drawing.Point(Rindx, Cindx)
            Me.DgPckNote.Controls.Add(Me.CmbxITMCODE)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CmbxOrdNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxOrdNO.GotFocus
        Try
            Me.CmbxOrdNO.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxOrdNO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxOrdNO.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxOrdNO_Leave(Nothing, Nothing)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxOrdNO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxOrdNO.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxOrdNO) = True Then
                If CmbxOrdNO.SelectedIndex = 0 Then
                    xFillDgPckNote(CInt(Me.CmbxOrdNO.SelectedValue))
                    Me.lblName.Text = xDynamic_Find_xAnItem_xInA_Table_1cond_String("Splrname", "Splrid", CInt(xxSplrid), "Finactsplrmstr")
                    Me.DgPckNote.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxOrdNO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxOrdNO.SelectedIndexChanged
        Try
            If CmbxOrdNO.SelectedIndex > 0 Then
                xFillDgPckNote(CInt(Me.CmbxOrdNO.SelectedValue))
                Me.lblName.Text = xDynamic_Find_xAnItem_xInA_Table_1cond_String("Splrname", "Splrid", CInt(xxSplrid), "Finactsplrmstr")

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFillDgPckNote(ByVal xPckId As Integer)
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            FinActCmd = New SqlCommand("FINACT_Utl_SaleOrder_Select", FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xPckOrdNo", CInt(xPckId))
            FinActRdr = FinActCmd.ExecuteReader
            Me.DgPckNote.Rows.Clear()
            Dim xr As Integer = 0
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    Me.DgPckNote.Rows.Add()
                    Me.DgPckNote.Rows(xr).Cells(0).Value = Trim(FinActRdr("dSaleitmcode"))
                    Me.DgPckNote.Rows(xr).Cells(1).Value = Trim(FinActRdr("Item_name"))
                    Me.DgPckNote.Rows(xr).Cells(2).Value = Trim(FinActRdr("dSaleitmcode"))
                    Me.DgPckNote.Rows(xr).Cells(3).Value = Trim(FinActRdr("Item_name"))
                    Me.DgPckNote.Rows(xr).Cells(4).Value = CInt(FinActRdr("dSaleid"))
                    Me.DgPckNote.Rows(xr).Cells(5).Value = CInt(FinActRdr("dSaleitmid"))
                    Me.Lbldate.Text = Format(FinActRdr("xdt"), "dd/MM/yyyy")
                    xxSplrid = CInt(FinActRdr("xsplrid"))
                    xr += 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If Me.DgPckNote.RowCount = 0 Then
                MsgBox("System could not find any record to update.", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            If MessageBox.Show("Are you sure to update current record(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                xxUpdatePckNote()
            Else
                Return
            End If
       

        Catch ex As Exception

        End Try
    End Sub
    Private Sub xxUpdatePckNote()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            For Each xxdgr As DataGridViewRow In Me.DgPckNote.Rows
                FinActCmd = New SqlCommand("FINACT_Utl_SaleOrder_UPDATE", FinActConn1)
                FinActCmd.CommandType = CommandType.StoredProcedure
                FinActCmd.Parameters.AddWithValue("@dSaleid", CInt(xxdgr.Cells(4).Value))
                FinActCmd.Parameters.AddWithValue("@RePLACEDITMID", CInt(xxdgr.Cells(5).Value))
                FinActCmd.Parameters.AddWithValue("@RePLACEDITMCODE", Trim(xxdgr.Cells(2).Value))
                FinActCmd.ExecuteNonQuery()
            Next
            MsgBox("Current record(s) has been successfully updated", MsgBoxStyle.Information, Me.Text)
            Me.DgPckNote.Rows.Clear()
            Me.CmbxOrdNO.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
        End Try
    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmSalePricelstEdit
    Dim SplCmd As SqlCommand
    Dim SplRdr As SqlDataReader

    Private Sub FrmPricelst1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Fill_Combobox("spl_id", "spl_name", "Finact_salepricelstmstr", "SPl_DELSTATUS", CInt(1), Me.CmbxPlst)
            Me.CmbxPlst.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPlst_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxPlst.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxPlst_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPlst_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPlst.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxPlst) = True Then
                If CmbxPlst.SelectedIndex = 0 Then
                    xFillDgItm(Me.CmbxPlst.SelectedValue)
                End If
                Me.DgItms.Focus()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPlst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxPlst.SelectedIndexChanged
        Try
            If CmbxPlst.SelectedIndex > 0 Then
                xFillDgItm(Me.CmbxPlst.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFillDgItm(ByVal ItmId As Integer)
        Try
            Me.DgItms.Rows.Clear()
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()

            SplCmd = New SqlCommand("Finact_SalePriceList_EditMode_Select", FinActConn)
            SplCmd.CommandType = CommandType.StoredProcedure
            SplCmd.Parameters.AddWithValue("@xSpl_id", ItmId)
            SplRdr = SplCmd.ExecuteReader
            Dim xr As Integer = 0
            While SplRdr.Read
                Me.DgItms.Rows.Add()
                Me.DgItms.Rows(xr).Cells(1).Value = SplRdr("Itmcode")
                Me.DgItms.Rows(xr).Cells(2).Value = SplRdr("Itmname")
                Me.DgItms.Rows(xr).Cells(3).Value = SplRdr("Itmunttype")
                Me.DgItms.Rows(xr).Cells(4).Value = SplRdr("splcld_mstrpack")
                Me.DgItms.Rows(xr).Cells(5).Value = SplRdr("splcld_rate")
                Me.DgItms.Rows(xr).Cells(6).Value = SplRdr("splcld_itmid")
                Me.DgItms.Rows(xr).Cells(7).Value = SplRdr("splcld_id")
                xr += 1
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            SplCmd.Dispose()
            SplRdr.Close()
        End Try

    End Sub
    Private Sub xUpdateRate(ByVal xSplId As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            For Each Dgr As DataGridViewRow In Me.DgItms.Rows
                If Dgr.Cells(0).Value = True Then
                    SplCmd = New SqlCommand("finact_salepricelstmstr_Child_Update", FinActConn)
                    SplCmd.CommandType = CommandType.StoredProcedure
                    SplCmd.Parameters.AddWithValue("@splid", CInt(xSplId))
                    SplCmd.Parameters.AddWithValue("@clditmid", CInt(Dgr.Cells(6).Value))
                    SplCmd.Parameters.AddWithValue("@cldid", CInt(Dgr.Cells(7).Value))
                    SplCmd.Parameters.AddWithValue("@cldrate", CDbl(Dgr.Cells(5).Value))
                    SplCmd.Parameters.AddWithValue("@splcld_mstrpack", CInt(Dgr.Cells(4).Value))
                    SplCmd.ExecuteNonQuery()
                End If
            Next
            MsgBox("Current Selected Item(s) has/have been successfully added", MsgBoxStyle.Information, Me.Text)
            Me.DgItms.Rows.Clear()
            Me.CmbxPlst.Focus()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            SplCmd.Dispose()
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Me.CmbxPlst.SelectedIndex = -1 Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            Dim Chk As Integer = 0
            For Each xDgr As DataGridViewRow In Me.DgItms.Rows
                If xDgr.Cells(0).Value = True Then
                    Chk += 1
                End If
            Next
            If Chk = 0 Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

            If MessageBox.Show("Are you sure to update selected item(s) to current price list?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                xUpdateRate(Me.CmbxPlst.SelectedValue)
            Else
                Return
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgItms_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgItms.CellEndEdit
        Try
            If e.ColumnIndex = 5 Then
                Me.DgItms.CurrentRow.Cells(e.ColumnIndex).Value = FormatNumber(Me.DgItms.CurrentRow.Cells(e.ColumnIndex).Value, 2, , TriState.False)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgItms_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgItms.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgItms.Rows.Count '- 1
            If Cr_Row <> Me.DgItms.CurrentRow.Index Then
                If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgItms.CurrentRow.Cells(5).ErrorText = "Invalid Input! Only Numbers are allowed"
                        MsgBox("Invalid Input", MsgBoxStyle.Critical, "Number only!!!")
                        e.Cancel = True
                    Else
                        Me.DgItms.CurrentRow.Cells(5).ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgItms_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgItms.CellContentClick

    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmTranPurOrderMain
    Dim OrdrCmd As SqlCommand
    Dim OrdrRdr As SqlDataReader
    Dim OrdrAdptr As SqlDataAdapter
    Dim DtaSet As DataSet
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        FrmShow_flag(8) = False
        Dim FrmNewAdd As New FrmTranPurOrder
        FrmNewAdd.ShowInTaskbar = False
        SetCaptions = True
        FrmShow_flag(9) = False
        FrmShow_flag(8) = True
        FrmNewAdd.ShowDialog()
    End Sub

    Private Sub FrmTranPurOrderMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.CmbxFltr.SelectedIndex = 3
            fill_gridviewOrderMain()
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try
    End Sub
    Public Sub fill_gridviewOrderMain()
        Dim temp As String = ""
        Try
            OrdrCmd = New SqlCommand("Finact_purorder_Select", FinActConn1)
            OrdrCmd.CommandType = CommandType.StoredProcedure
            OrdrCmd.Parameters.AddWithValue("@xCond", Trim(Me.CmbxFltr.Text))
            OrdrAdptr = New Data.SqlClient.SqlDataAdapter(OrdrCmd)
            DtaSet = New Data.DataSet()
            DtaSet.Tables.Clear()
            OrdrAdptr.Fill(DtaSet, "finactpurorder")
            Me.dgOrder.DataSource = DtaSet.Tables("FinactpurOrder")
            Me.dgOrder.Columns(0).HeaderText = "Date"
            Me.dgOrder.Columns(0).Width = 100
            Me.dgOrder.Columns(0).DefaultCellStyle.ForeColor = Color.Navy
            Me.dgOrder.Columns(0).DefaultCellStyle.BackColor = Color.Cyan
            Me.dgOrder.Columns(0).DefaultCellStyle.Format = "dd/MM/yyyy"
            Me.dgOrder.Columns(1).HeaderText = "Order No."
            Me.dgOrder.Columns(1).Width = 120
            Me.dgOrder.Columns(2).HeaderText = "Req. Date"
            Me.dgOrder.Columns(2).Width = 100
            Me.dgOrder.Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
            Me.dgOrder.Columns(3).HeaderText = "Status"
            Me.dgOrder.Columns(3).Width = 120
            Me.dgOrder.Columns(4).HeaderText = "Vendor Id"
            Me.dgOrder.Columns(4).Width = 0
            Me.dgOrder.Columns(4).Visible = False
            Me.dgOrder.Columns(5).HeaderText = "Vendor Name"
            Me.dgOrder.Columns(5).Width = 260
            Me.dgOrder.Columns(6).HeaderText = "Amount"
            Me.dgOrder.Columns(6).Width = 125
            Me.dgOrder.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgOrder.Columns(6).DefaultCellStyle.Format = "N2"
            Me.dgOrder.Columns(6).DefaultCellStyle.ForeColor = Color.Navy
            Me.dgOrder.Columns(6).DefaultCellStyle.BackColor = Color.LightCyan
            Me.dgOrder.Columns(7).HeaderText = "Order Id"
            Me.dgOrder.Columns(7).Width = 0
            Me.dgOrder.Columns(7).Visible = False
            Me.dgOrder.ReadOnly = True
            Me.dgOrder.MultiSelect = False
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            OrdrCmd.Dispose()
            OrdrAdptr.Dispose()
        End Try
    End Sub
    Private Sub Btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnedit.Click
        If Me.dgOrder.SelectedRows.Count > 0 Then
            SetCaptions = False
            FrmShow_flag(9) = True
            FrmShow_flag(8) = False
            Selected_xOrdr_xId = Me.dgOrder.SelectedRows(0).Cells(7).Value
            x_OrdrStatus = Trim(Me.dgOrder.SelectedRows(0).Cells(3).Value)
            Dim FrmOrdrEdit As New FrmTranPurOrder
            FrmOrdrEdit.ShowInTaskbar = False
            FrmOrdrEdit.ShowDialog()
        Else
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Me.dgOrder.Rows.Count > 0 Then
            Me.ContxPordr.Visible = True
            If Me.dgOrder.SelectedRows.Count = 1 Then
                If Trim(Me.dgOrder.CurrentRow.Cells(3).Value) = "Cancelled" Or Trim(Me.dgOrder.CurrentRow.Cells(3).Value) = "Worksheet" Then
                    If MessageBox.Show("Are you sure to delete current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim Delid As Integer = Me.dgOrder.SelectedRows(0).Cells(7).Value
                            OrdrCmd = New SqlCommand("Delete from finactpurorder where purid=@pid", FinActConn)
                            OrdrCmd.Parameters.AddWithValue("@pid", Delid)
                            OrdrCmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Exit Sub
                        Finally
                            OrdrCmd.Dispose()
                        End Try
                        Try
                            Dim Delid As Integer = Me.dgOrder.SelectedRows(0).Cells(7).Value
                            OrdrCmd = New SqlCommand("Delete from finactpurorder_details where dpurconcrnid=@pid1", FinActConn)
                            OrdrCmd.Parameters.AddWithValue("@pid1", Delid)
                            OrdrCmd.ExecuteNonQuery()
                            MsgBox("Current item has been successfully deleted", MsgBoxStyle.Information, "Order and Details Deleting")
                            Me.dgOrder.Rows.Remove(Me.dgOrder.CurrentRow)
                            Me.dgOrder.Focus()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            OrdrCmd.Dispose()
                        End Try
                    Else
                        Return
                    End If
                Else
                    MsgBox("Invalid action! System found currently selected item has one or more relations", MsgBoxStyle.Critical, "Used item")
                    Me.dgOrder.Focus()
                End If
            Else
                MsgBox("Invalid action!, System could not found any selected item", MsgBoxStyle.Critical, "Selecting Error!!!!")
                Me.dgOrder.Focus()
            End If
        Else
            Me.ContxPordr.Visible = False
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Btnfilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnfilter.Click
        Try

            fill_gridviewOrderMain()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Btnfilter_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        MsgBox("Access Denied!", MsgBoxStyle.Exclamation, Me.Text)
    End Sub

    Private Sub CmbxFltr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxFltr.SelectedIndexChanged
        Try
            Me.Btnfilter_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            Me.Btnedit_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnfilter.GotFocus, Btnedit.GotFocus, BtnFind.GotFocus, BtnNew.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnedit.Leave, Btnfilter.Leave, BtnFind.Leave, BtnNew.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent

        Catch ex As Exception

        End Try
    End Sub
End Class
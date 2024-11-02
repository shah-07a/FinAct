Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmTranPurEntrySelectOrder
    Dim OrdrCmd As SqlCommand
    Dim OrdrRdr As SqlDataReader
    Dim OrdrAdptr As SqlDataAdapter
    Dim DtaSet As DataSet
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            If Me.dgOrder.SelectedRows.Count = 1 Then
                ReDim Selected_xSelectedOrdr_xId(0)
                Selected_xSelectedOrdr_xId(0) = Me.dgOrder.SelectedRows(0).Cells(7).Value
                Dim FrmNewAdd As New FrmTranPurEnteryOrder
                FrmNewAdd.ShowInTaskbar = False

                FrmNewAdd.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub FrmTranPurOrderMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fill_gridview1()
            Me.Top = 0
        Catch ex As Exception

        End Try
    End Sub
    Public Sub fill_gridview1()
        Dim temp As String = ""
        Try
            Me.dgOrder.DataSource = Nothing
            OrdrCmd = New SqlCommand("Finact_purorder_Select_ForPurEntry", FinActConn1)
            OrdrCmd.CommandType = CommandType.StoredProcedure
            OrdrAdptr = New Data.SqlClient.SqlDataAdapter(OrdrCmd)
            DtaSet = New Data.DataSet()
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
            Me.dgOrder.Columns(7).Width = 110
            Me.dgOrder.Columns(7).Visible = True
            Me.dgOrder.ReadOnly = True
            Me.dgOrder.MultiSelect = False
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            OrdrCmd.Dispose()
            OrdrAdptr.Dispose()
            Me.dgOrder.Refresh()
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub Btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnedit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Me.BtnNew_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnALl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNew.GotFocus, Btnedit.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnall_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnedit.Leave, BtnNew.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
End Class
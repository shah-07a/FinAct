Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmTranSaleEntrySelectOrder
    Dim OrdrCmd As SqlCommand
    Dim OrdrRdr As SqlDataReader
    Dim OrdrAdptr As SqlDataAdapter
    Dim DtaSet As DataSet
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try 'saleshpid,salelocid,salepriceid 
            If Me.dgOrder.SelectedRows.Count >= 1 Then
                Dim xSplrid As Integer = CInt(Me.dgOrder.SelectedRows(0).Cells(4).Value)
                Dim xShpid As Integer = CInt(Me.dgOrder.SelectedRows(0).Cells(8).Value)
                Dim xLocid As Integer = CInt(Me.dgOrder.SelectedRows(0).Cells(9).Value)
                Dim xPriceid As Integer = CInt(Me.dgOrder.SelectedRows(0).Cells(10).Value)
                For Each Dgrx As DataGridViewRow In Me.dgOrder.SelectedRows
                    If xSplrid <> CInt(Dgrx.Cells(4).Value) Then
                        MsgBox("Invalid Input!, Customer should be same in a selected block of order/packing notes", MsgBoxStyle.Critical, Me.Text)
                        Exit Sub
                    End If
                    If xShpid <> CInt(Dgrx.Cells(8).Value) Then
                        MsgBox("Invalid Input!, Transport should be same in a selected block of order/packing notes", MsgBoxStyle.Critical, Me.Text)
                        Exit Sub
                    End If
                    If xLocid <> CInt(Dgrx.Cells(9).Value) Then
                        MsgBox("Invalid Input!, Delivery addresses should be same in a selected block of order/packing notes", MsgBoxStyle.Critical, Me.Text)
                        Exit Sub
                    End If

                    If xPriceid <> CInt(Dgrx.Cells(10).Value) Then
                        MsgBox("Invalid Input!, Price list should be same in a selected block of order/packing notes", MsgBoxStyle.Critical, Me.Text)
                        Exit Sub
                    End If
                Next
                ReDim Selected_xSelectedOrdr_xId(dgOrder.SelectedRows.Count - 1)
                Dim Ix As Integer = 0
                For Each Dgrx As DataGridViewRow In Me.dgOrder.SelectedRows
                    Selected_xSelectedOrdr_xId(Ix) = Dgrx.Cells(7).Value
                    Ix += 1
                Next
                Dim FrmNewAdd As New FrmTranSaleEnteryOrder
                FrmNewAdd.ShowInTaskbar = False
                FrmNewAdd.ShowDialog()
            Else
                MsgBox("Invalid Input! System Could Not Find Any Selected Row.", MsgBoxStyle.Critical, Me.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub FrmTranSaleEntrySelectOrder_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '  FrmTranSaleentryOrderMain.fill_Saleentgridview()
    End Sub
    Public Sub FrmTranSaleOrderMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            fill_gridview1()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub fill_gridview1()
        Dim temp As String = ""
        Try
            OrdrCmd = New SqlCommand("Finact_Saleorder_Select_ForSaleEntry", FinActConn1)
            OrdrCmd.CommandType = CommandType.StoredProcedure
            OrdrAdptr = New Data.SqlClient.SqlDataAdapter(OrdrCmd)
            DtaSet = New Data.DataSet()
            OrdrAdptr.Fill(DtaSet, "finactSaleorder")
            Me.dgOrder.DataSource = DtaSet.Tables("FinactSaleOrder")
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
            Me.dgOrder.Columns(4).HeaderText = "Customer Id"
            Me.dgOrder.Columns(4).Width = 0
            Me.dgOrder.Columns(4).Visible = False
            Me.dgOrder.Columns(5).HeaderText = "Customer Name"
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

            Me.dgOrder.Columns(8).HeaderText = "saleshpid"
            Me.dgOrder.Columns(8).Width = 0
            Me.dgOrder.Columns(8).Visible = False

            Me.dgOrder.Columns(9).HeaderText = "Salelocid"
            Me.dgOrder.Columns(9).Width = 0
            Me.dgOrder.Columns(9).Visible = False

            Me.dgOrder.Columns(10).HeaderText = "salepriceid"
            Me.dgOrder.Columns(10).Width = 0
            Me.dgOrder.Columns(10).Visible = False


            Me.dgOrder.ReadOnly = True
            Me.dgOrder.MultiSelect = True
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

    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnedit.GotFocus, BtnNew.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnedit.Leave, BtnNew.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
End Class
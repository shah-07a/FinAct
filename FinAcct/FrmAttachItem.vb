Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmAttachItem
    Dim ItmCmd As SqlCommand
    Dim ItmRdr As SqlDataReader
    Dim DgRow As DataGridViewRow
    Dim CurSplrid As Integer = 0

    Private Sub AllControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkBoxAll.KeyDown, ChkItmGrp.KeyDown _
    , ChkItmGrp.KeyDown, rBall.KeyDown, rBpurchase.KeyDown, rBtrading.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub FrmAttachItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.SplitContainer1.IsSplitterFixed = True
            Fill_Combobox_where_Not_cond("cogrpid", "cogrupnam", "cogrupnam", "Finactstokgrupname", "PRIMARY", Me.CmbxItmgrp, "Codelstatus", CInt(1))
            If FrmShow_flag(21) = True Then
                CurSplrid = SplrID_Editx
            Else
                CurSplrid = FindMaxId(SplrName4Shp, SplrSurfix4Shp)
            End If
            Me.BtnSave.Location = New Point(9, 71)
            If CurrActType = "Customer" Then
                Me.rBpurchase.Visible = False
                Me.rBtrading.Text = "Sale Only"
                Me.rBall.Enabled = True
            ElseIf CurrActType = "Vendor" Then
                Me.rBpurchase.Visible = True
                Me.rBtrading.Text = "Ready To Use/Trading Items"
                Me.rBall.Enabled = False

            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub ChkItmGrp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkItmGrp.CheckedChanged
        Try
            If Me.ChkItmGrp.Checked = True Then
                Me.CmbxItmgrp.Enabled = False
            Else
                Me.CmbxItmgrp.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fill_DataGrid_Items(ByVal xType As String, ByVal xGrpId As Integer)
        Try
            Me.dGAttitm.Rows.Clear()
            Dim i As Integer = 0
            ItmCmd = New SqlCommand("FinAct_ItemMstr_Select_ALL", FinActConn)
            ItmCmd.CommandType = CommandType.StoredProcedure
            ItmCmd.Parameters.AddWithValue("@Sale_Pur_Type", xType)
            ItmCmd.Parameters.AddWithValue("@Sale_Pur_Type1", xGrpId)
            ItmRdr = ItmCmd.ExecuteReader
            Me.dGAttitm.AllowUserToAddRows = False
            While (ItmRdr.Read)
                If ItmRdr.IsDBNull(0) = False Then
                    Me.dGAttitm.Rows.Add()
                    Me.dGAttitm.Rows(i).Cells(1).Value = ItmRdr("itmcode") '1
                    Me.dGAttitm.Rows(i).Cells(2).Value = ItmRdr("itmname") '2
                    Dim typ As String = Trim(ItmRdr("itmtype")) '3
                    If typ = "Purchase" Then
                        Me.dGAttitm.Rows(i).Cells(3).Value = "Raw Material"
                    ElseIf typ = "Trading" Then
                        Me.dGAttitm.Rows(i).Cells(3).Value = "Trading Item"
                    ElseIf typ = "Sale" Then
                        Me.dGAttitm.Rows(i).Cells(3).Value = "Sale Item"
                    End If
                    Me.dGAttitm.Rows(i).Cells(4).Value = ItmRdr("itmid") '4
                    i += 1
                End If

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ItmCmd = Nothing
            ItmRdr.Close()
        End Try




    End Sub

   
    Private Sub ChkBoxAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBoxAll.CheckedChanged
        Try
            If Me.ChkBoxAll.Checked = True Then
                If dGAttitm.Rows.Count > 0 Then
                    Dim rx As Integer = 0
                    For rx = 0 To Me.dGAttitm.Rows.Count - 1
                        Me.dGAttitm.Rows(rx).Cells(0).Value = True
                    Next

                End If
            Else
                If dGAttitm.Rows.Count > 0 Then
                    Dim rx As Integer = 0
                    For rx = 0 To Me.dGAttitm.Rows.Count - 1
                        Me.dGAttitm.Rows(rx).Cells(0).Value = False
                    Next

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGo.Click
        Try
            Dim xtype As String = ""
            Dim xGrp As Integer = 0
            If CurrActType = "Vendor" Then
                If Me.rBpurchase.Checked = True Then
                    xtype = "RawMaterial"
                ElseIf Me.rBtrading.Checked = True Then
                    xtype = "ReadyToUse"
                ElseIf Me.rBall.Checked = True Then
                    xtype = "Purchase"
                End If

            ElseIf CurrActType = "Customer" Then
                If Me.rBtrading.Checked = True Then
                    xtype = "SaleOnly"
                Else
                    xtype = "Sale"
                End If

            End If
            If Me.ChkItmGrp.Checked = True Then
                xGrp = 0
            Else
                If Me.CmbxItmgrp.Items.Count > 0 Then
                    xGrp = Me.CmbxItmgrp.SelectedValue
                End If
            End If

            Fill_DataGrid_Items(xtype, xGrp)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndel.Click
        Try
            If Me.dGAttitm.Rows.Count > 0 Then
                For Each rw As DataGridViewRow In Me.dGAttitm.Rows
                    If rw.Selected = True Then
                        Dim inx As Integer = rw.Index
                        Me.dGAttitm.Rows.RemoveAt(inx)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Me.dGAttitm.Rows.Count > 0 Then
                If MessageBox.Show("Are you sure to save this record?", "Saving......", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    If FinActConn.State Then FinActConn.Close()
                    FinActConn.Open()
                    Dim Cont As Integer = 0
                    For Each rw As DataGridViewRow In Me.dGAttitm.Rows
                        If rw.Cells(0).Value = True Then
                            ItmCmd = New SqlCommand("Finact_AttachItem_Insert", FinActConn)
                            ItmCmd.CommandType = CommandType.StoredProcedure
                            ItmCmd.Parameters.AddWithValue("@atchConcrnid", CurSplrid)
                            ItmCmd.Parameters.AddWithValue("@atchitmid", rw.Cells(4).Value)
                            ItmCmd.ExecuteNonQuery()
                            Cont += 1
                        End If
                    Next
                    If Cont > 0 Then
                        MsgBox("Current record(s) has/have been saved", MsgBoxStyle.Information, "Saved!!!")
                        FrmShow_flag(21) = True
                        ItmCmd.Dispose()
                        Me.dGAttitm.Rows.Clear()
                        Me.Close()
                    Else
                        MsgBox("Invalid action, select atleat one record to save", MsgBoxStyle.Information, "No Record!!")
                    End If
                Else
                    Return
                End If

            Else
                MsgBox("No record found to save", MsgBoxStyle.Information, "No Record!!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            Me.BtnSave_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If Me.dGAttitm.Rows.Count > 0 Then
                If Me.ToolStripMenuItem1.Text = "Check All" Then
                    Me.ChkBoxAll.Checked = True
                    Me.ToolStripMenuItem1.Text = "Uncheck All"
                ElseIf Me.ToolStripMenuItem1.Text = "Uncheck All" Then
                    Me.ChkBoxAll.Checked = False
                    Me.ToolStripMenuItem1.Text = "Check All"
                End If
            Else
                MsgBox("Invalid action!", MsgBoxStyle.Critical, "Empty Grid")

            End If



        Catch ex As Exception

        End Try
    End Sub
End Class
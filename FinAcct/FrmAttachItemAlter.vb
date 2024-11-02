Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmAttachItemAlter
    Dim Edtitmcmd As SqlCommand
    Dim Edtitmrdr As SqlDataReader
    Dim DgRow As DataGridViewRow
    Dim DgRowEdt As DataGridViewRow
    Dim CurSplrid As Integer = 0


    Private Sub FrmAttachItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.SplitContainer1.IsSplitterFixed = True
            CurSplrid = SplrID_Editx
            Fill_DataGrid_Items(CurSplrid)

        Catch ex As Exception

        End Try

    End Sub


    Private Sub Fill_DataGrid_Items(ByVal xCurCVId As Integer)
        Try
            Me.dGAttitm.Rows.Clear()
            Dim i As Integer = 0
            Edtitmcmd = New SqlCommand("Finact_AttachItem_SelectAttached_Items", FinActConn)
            Edtitmcmd.CommandType = CommandType.StoredProcedure
            Edtitmcmd.Parameters.AddWithValue("@xcurcvid", xCurCVId)

            Edtitmrdr = Edtitmcmd.ExecuteReader
            Me.dGAttitm.AllowUserToAddRows = False
            While (Edtitmrdr.Read)
                If Edtitmrdr.IsDBNull(0) = False Then
                    Me.dGAttitm.Rows.Add()
                    Me.dGAttitm.Rows(i).Cells(0).Value = True '0
                    Me.dGAttitm.Rows(i).Cells(1).Value = Edtitmrdr("itmcode") '1
                    Me.dGAttitm.Rows(i).Cells(2).Value = Edtitmrdr("itmname") '2
                    Dim typ As String = Trim(Edtitmrdr("itmtype")) '3
                    If typ = "Purchase" Then
                        Me.dGAttitm.Rows(i).Cells(3).Value = "Raw Material"
                    ElseIf typ = "Trading" Then
                        Me.dGAttitm.Rows(i).Cells(3).Value = "Trading Item"
                    ElseIf typ = "Sale" Then
                        Me.dGAttitm.Rows(i).Cells(3).Value = "Sale Item"
                    End If
                    Me.dGAttitm.Rows(i).Cells(4).Value = Edtitmrdr("itmid") '4
                    i += 1
                End If

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Edtitmcmd = Nothing
            Edtitmrdr.Close()
        End Try




    End Sub

    Private Sub Fill_DataGrid_Items_OnlyOtherthan(ByVal xCurCVId As Integer, ByVal xtyp As String)
        Try
            Me.DgItmEdt.Rows.Clear()
            Dim i As Integer = 0
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()

            Edtitmcmd = New SqlCommand("Finact_AttachItem_Select_Not_Attached_Items", FinActConn)
            Edtitmcmd.CommandType = CommandType.StoredProcedure
            Edtitmcmd.Parameters.AddWithValue("@xcurcvid", xCurCVId)
            Edtitmcmd.Parameters.AddWithValue("@xTyp", xtyp)

            Edtitmrdr = Edtitmcmd.ExecuteReader
            Me.DgItmEdt.AllowUserToAddRows = False
            While (Edtitmrdr.Read)
                If Edtitmrdr.IsDBNull(0) = False Then
                    Me.DgItmEdt.Rows.Add()
                    Me.DgItmEdt.Rows(i).Cells(1).Value = Edtitmrdr("itmcode") '1
                    Me.DgItmEdt.Rows(i).Cells(2).Value = Edtitmrdr("itmname") '2
                    Dim typ As String = Trim(Edtitmrdr("itmtype")) '3
                    If typ = "Purchase" Then
                        Me.DgItmEdt.Rows(i).Cells(3).Value = "Raw Material"
                    ElseIf typ = "Trading" Then
                        Me.DgItmEdt.Rows(i).Cells(3).Value = "Trading Item"
                    ElseIf typ = "Sale" Then
                        Me.DgItmEdt.Rows(i).Cells(3).Value = "Sale Item"
                    End If
                    Me.DgItmEdt.Rows(i).Cells(4).Value = Edtitmrdr("itmid") '4
                    i += 1
                End If

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Edtitmcmd = Nothing
            Edtitmrdr.Close()
        End Try
    End Sub


    Private Sub ChkBoxAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBoxAll.CheckedChanged
        Try
            If Me.ChkBoxAll.Checked = True Then
                If DgItmEdt.Rows.Count > 0 Then
                    Dim rx As Integer = 0
                    For rx = 0 To Me.DgItmEdt.Rows.Count - 1
                        Me.DgItmEdt.Rows(rx).Cells(0).Value = True
                    Next

                End If
            Else
                If DgItmEdt.Rows.Count > 0 Then
                    Dim rx As Integer = 0
                    For rx = 0 To Me.DgItmEdt.Rows.Count - 1
                        Me.DgItmEdt.Rows(rx).Cells(0).Value = False
                    Next

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndel.Click
        Try
            If Me.dGAttitm.Rows.Count > 0 And Me.dGAttitm.SelectedRows.Count > 0 Then
                If MessageBox.Show("The Current Action will remove record(s) permanently. Are you sure to delete?", "Deleting....", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                Else

                    For Each rw As DataGridViewRow In Me.dGAttitm.SelectedRows
                        If rw.Selected = True Then
                            Delete_AttachedItems(CurSplrid, rw.Cells(4).Value)
                            Dim inx As Integer = rw.Index
                            Me.dGAttitm.Rows.RemoveAt(inx)
                        End If
                    Next
                    MsgBox("Current record(s) has/have been successfully deleted", MsgBoxStyle.Information, "Deleted....")
                End If

            Else
                MsgBox("Invalid action! There should be atleast one selected record to delete", MsgBoxStyle.Critical, "No Record To Delete!!!")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Delete_AttachedItems(ByVal DelId As Integer, ByVal Delid1 As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Edtitmcmd = New SqlCommand("Finact_AttachItem_Delete", FinActConn)
            Edtitmcmd.CommandType = CommandType.StoredProcedure
            Edtitmcmd.Parameters.AddWithValue("@Atchconcrnid", DelId)
            Edtitmcmd.Parameters.AddWithValue("@Atchitmid", Delid1)
            Edtitmcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Edtitmcmd.Dispose()
        End Try
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Me.BtnSave.Text = "&Update" Then
                If Me.DgItmEdt.Rows.Count > 0 Then

                    If FinActConn.State Then FinActConn.Close()
                    FinActConn.Open()
                    Dim Cont As Integer = 0
                    For Each rw As DataGridViewRow In Me.DgItmEdt.Rows
                        If rw.Cells(0).Value = True Then
                            Edtitmcmd = New SqlCommand("Finact_AttachItem_Insert", FinActConn)
                            Edtitmcmd.CommandType = CommandType.StoredProcedure
                            Edtitmcmd.Parameters.AddWithValue("@atchConcrnid", CurSplrid)
                            Edtitmcmd.Parameters.AddWithValue("@atchitmid", rw.Cells(4).Value)
                            Edtitmcmd.ExecuteNonQuery()
                            Cont += 1
                        End If
                    Next
                    If Cont > 0 Then
                        MsgBox("Current record(s) has/have been updated", MsgBoxStyle.Information, "Saved!!!")
                        Edtitmcmd.Dispose()
                        Me.DgItmEdt.Rows.Clear()
                        Me.dGAttitm.Rows.Clear()
                        Me.Close()
                    Else
                        MsgBox("Invalid action, select atleat one record to update", MsgBoxStyle.Information, "No Record!!")
                    End If
                Else
                    MsgBox("No record found to update", MsgBoxStyle.Information, "No Record!!")
                End If
            ElseIf Me.BtnSave.Text = "&Add More" Then
                If xCurrActType = "Customer" Then
                    Fill_DataGrid_Items_OnlyOtherthan(CurSplrid, "Purchase")
                ElseIf xCurrActType = "Vendor" Then
                    Fill_DataGrid_Items_OnlyOtherthan(CurSplrid, "Sale")
                End If

                If Me.DgItmEdt.Rows.Count > 0 Then
                    Me.BtnSave.Text = "&Update"
                Else
                    MsgBox("No record found! it may be all existed items already attached or no item created", MsgBoxStyle.Information, "No Record Found!!!")
                End If
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

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Me.Btndel_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AToolStripMenuItem.Click
        Try
            Me.BtnSave_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DdToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DdToolStripMenuItem.Click
        Try
            If Me.DgItmEdt.Rows.Count > 0 Then
                If Me.DdToolStripMenuItem.Text = "Check All" Then
                    Me.ChkBoxAll.Checked = True
                    Me.DdToolStripMenuItem.Text = "Uncheck All"
                ElseIf Me.DdToolStripMenuItem.Text = "Uncheck All" Then
                    Me.ChkBoxAll.Checked = False
                    Me.DdToolStripMenuItem.Text = "Check All"
                End If
            Else
                MsgBox("Invalid action!", MsgBoxStyle.Critical, "Empty Grid")

            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkBoxAll.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
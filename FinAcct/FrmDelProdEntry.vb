Imports System.Data
Imports System.Data.SqlClient

Public Class FrmDelProdEntry
    Dim MMCmd As SqlCommand
    Dim MMRdr As SqlDataReader

    Private Sub FrmDelProdEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 20

            xSel_Entry()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xSel_Entry()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            MMCmd = New SqlCommand("Finact_MaterialMovMstr_ForDel_Select", FinActConn)
            MMCmd.CommandType = CommandType.StoredProcedure
            MMRdr = MMCmd.ExecuteReader
            Me.LstvewDel.Items.Clear()
            Dim xlst As ListViewItem
            While MMRdr.Read
                If MMRdr.IsDBNull(0) = False Then
                    xlst = Me.LstvewDel.Items.Add(Format(MMRdr("Matmovdt"), "dd/MM/yyyy"))
                    xlst.SubItems.Add(Trim(MMRdr("BatchNo")))
                    xlst.SubItems.Add(Trim(MMRdr("xItmName")))
                    xlst.SubItems.Add(FormatNumber(MMRdr("mmqnty1"), 3))
                    xlst.SubItems.Add(MMRdr("MATmovid"))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            MMCmd.Dispose()
            MMRdr.Close()
        End Try
    End Sub

    Private Sub xDel_Entry_xFromDiffTables()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            For Each xiTM As ListViewItem In Me.LstvewDel.SelectedItems
                MMCmd = New SqlCommand("Finact_Production_Item_FromDiffTbl_Delete", FinActConn)
                MMCmd.CommandType = CommandType.StoredProcedure
                MMCmd.Parameters.AddWithValue("@xmovid", CInt(xiTM.SubItems(4).Text))
                MMCmd.Parameters.AddWithValue("@xBatchNo", Trim(xiTM.SubItems(1).Text))
                MMCmd.ExecuteNonQuery()
                xiTM.Remove()
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            MMCmd.Dispose()

        End Try
    End Sub

    Private Sub BtnExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExt.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Try
            If Not Me.LstvewDel.SelectedItems.Count > 0 Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            Else
                If MessageBox.Show("It will Delete permanently records from different table and change the Purchase,Sale and Stock Positions earlier you have taken. Are you sure to delete?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    xDel_Entry_xFromDiffTables()
                Else
                    Me.LstvewDel.Focus()
                    Return
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.BtnExt_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Me.BtnDel_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCrRptStokValuation
    Dim StkvalCmd As SqlCommand
    Dim StkvalRdr As SqlDataReader
    Private Sub FrmStokValuation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Height = 148
            FillTempTable_StokRegsumr()
            Fill_CMBX_DYNAMIC_WITH_INNERJOIN_DISTINCT_SELECT("ITMDELSTATUS", CInt(1), "ITMID", "ITMNAME", "FINACTITMMSTR", "ITMID", "xITMID", "FINACT_TEMP_STOKISSUEDETAILS", Me.CmbxItems)
            Me.RbPurItm.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If Me.BtnOk.Text = "&OK" Then
                Me.BtnOk.Text = "&CANCEL"
                SelRecd_Fromtable_StokIssue()
                Me.Height = Screen.PrimaryScreen.WorkingArea.Height - 50
            Else
                Me.BtnOk.Text = "&OK"
                Me.Height = 148
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

    Private Sub ChkbxItm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkbxItm.GotFocus
        Try
            Me.ChkbxItm.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllContrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkbxItm.KeyDown _
    , RbPurItm.KeyDown, RbSaleItm.KeyDown, RbFifo.KeyDown, RbOalAvg.KeyDown, RbMnthlyAvg.KeyDown, RbStnd.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkbxItm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkbxItm.Leave
        Try
            Me.ChkbxItm.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxItems.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxItems_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxItems_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxItems.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxItems) = True Then
                If Me.CmbxItems.SelectedIndex = 0 Then

                End If

            End If
           
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxItems.SelectedIndexChanged
        Try
            If Me.CmbxItems.SelectedIndex > 0 Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkbxItm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbxItm.CheckedChanged
        Try
            If Me.ChkbxItm.CheckState = CheckState.Checked Then
                Me.CmbxItems.Enabled = False
            Else
                Me.CmbxItems.Enabled = True
            End If
            Me.CmbxItems.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillTempTable_StokRegsumr()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            StkvalCmd = New SqlCommand("Finact_Rpt_STOCKVALUE_ALLITEM_FillTable", FinActConn)
            StkvalCmd.CommandType = CommandType.StoredProcedure
            StkvalCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- FillTempTable_Ldgr, Line No. 38 ")
        Finally
            StkvalCmd.Dispose()

        End Try

    End Sub

    Private Sub DtpFrom_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Me.ChkbxItm.CheckState = CheckState.Checked Then
                Me.CmbxItems.SelectedIndex = -1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SelRecd_Fromtable_StokIssue()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_Rpt_TEMP_StokIssueDetails_Finished_DateWiseWithOpnBal_Select", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            'FinActCmd.Parameters.AddWithValue("@SelDt1", Me.DtpFrom.Value.Date)
            'FinActCmd.Parameters.AddWithValue("@SelDt2", Me.DtpTo.Value.Date)
            If Not Me.CmbxItems.SelectedIndex = -1 Then
                FinActCmd.Parameters.AddWithValue("@xITMID", CInt(Me.CmbxItems.SelectedValue))
            Else
                FinActCmd.Parameters.AddWithValue("@xITMID", 0)
            End If
            FinActCmd.Parameters.AddWithValue("@Seltype", 1)
            FinActCmd.Parameters.AddWithValue("@xxSPLRID", 0)
            FinActRdr = FinActCmd.ExecuteReader
            Me.DgStkVal.AllowUserToAddRows = False
            Dim xdr As Integer = 0
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    Me.DgStkVal.Rows.Add()
                    Me.DgStkVal.Rows(xdr).Cells(0).Value = Trim(FinActRdr("stkitmid"))
                    Dim xQin As Double = CDbl(FinActRdr("stkqntyin"))
                    Dim xQout As Double = CDbl(FinActRdr("stkqntyout"))
                    Dim xRate As Double = CDbl(FinActRdr("stkratein"))
                    Me.DgStkVal.Rows(xdr).Cells(1).Value = FormatNumber(xQin, 3)
                    Me.DgStkVal.Rows(xdr).Cells(2).Value = FormatNumber(xQout, 3)
                    Me.DgStkVal.Rows(xdr).Cells(3).Value = FormatNumber(xQin - xQout, 3)
                    Me.DgStkVal.Rows(xdr).Cells(4).Value = Trim(FinActRdr("stkisunt"))
                    Me.DgStkVal.Rows(xdr).Cells(5).Value = FormatNumber(xRate, 2)
                    Me.DgStkVal.Rows(xdr).Cells(6).Value = FormatNumber((xQin - xQout) * xRate, 2)
                    xdr += 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Sub
End Class
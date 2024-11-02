Imports System.Data
Imports System.Data.SqlClient
Public Class FrmUtlBillDele

    Private Sub FrmUtlBillDele_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fill_Combobox_DistinctPURVNO_PurEntryDetails(ByVal Xcombobx As ComboBox)
        Dim xStr As String = "Finact_Saleentry_InvoiceNO_CategoryType_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            FinActCmd = New SqlCommand(xStr, FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            If Me.RbInvVAT.Checked = True Then
                FinActCmd.Parameters.AddWithValue("@xType", 1)
            ElseIf Me.RbInvRetail.Checked = True Then
                FinActCmd.Parameters.AddWithValue("@xType", 0)
            End If
            SqlAdptr = New SqlDataAdapter(FinActCmd)
            dtaset = New DataSet(FinActCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            If Me.RbInvVAT.Checked = True Then
                Xcombobx.ValueMember = "Saleentid"
                Xcombobx.DisplayMember = "SaleEntVATvNO"
            ElseIf Me.RbInvRetail.Checked = True Then
                Xcombobx.ValueMember = "Saleentid"
                Xcombobx.DisplayMember = "SaleEntRETAILvNO"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub

    Private Sub RbInvVAT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbInvVAT.CheckedChanged
        Try
            If Me.RbInvVAT.Checked = True Then
                Fill_Combobox_DistinctPURVNO_PurEntryDetails(Me.CmbxInv)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RbInvRetail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbInvRetail.CheckedChanged
        Try
            If Me.RbInvRetail.Checked = True Then
                Fill_Combobox_DistinctPURVNO_PurEntryDetails(Me.CmbxInv)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDele.Click
        Try
            If Me.CmbxInv.SelectedIndex = -1 Then
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            Else
                If MessageBox.Show("It is strognly suggested not to delete entry(ies). Are you sure to delete current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim xMamVno As Integer = 0
                        If Me.RbInvVAT.Checked = True Then
                            xMamVno = xFetchMxVal_dynamic("FinactSaleEntry", "SaleEntVATvNO") '
                        ElseIf Me.RbInvRetail.Checked = True Then
                            xMamVno = xFetchMxVal_dynamic("FinactSaleEntry", "SaleEntRETAILvNO")
                        End If
                        If CInt(Me.CmbxInv.Text) < CInt(xMamVno) Then
                            MsgBox("Invalid Input! It should be last in the selected series.", MsgBoxStyle.Information, Me.Text)
                            Exit Sub
                        End If
                        FinActCmd = New SqlCommand("Finact_DelEntry_SaleEntry_SaleOrder", FinActConn)
                        FinActCmd.CommandType = CommandType.StoredProcedure
                        FinActCmd.Parameters.AddWithValue("@xsaleentid", CInt(Me.CmbxInv.SelectedValue))
                        FinActRdr = FinActCmd.ExecuteReader
                        While FinActRdr.Read
                            Dim x As Object = FinActRdr("xMessage")
                            If FinActRdr("xMessage") = True Then
                                MsgBox("Access denied!, system could not delete current record.", MsgBoxStyle.Critical, "Relationship Developed")
                            Else
                                MsgBox("Current item has been successfully deleted", MsgBoxStyle.Information, Me.Text)
                                Fill_Combobox_DistinctPURVNO_PurEntryDetails(Me.CmbxInv)
                            End If
                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Exit Sub
                    Finally
                        FinActCmd.Dispose()
                        FinActRdr.Close()
                        Me.CmbxInv.Focus()
                    End Try
                Else
                    Return
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxInv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxInv.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxInv_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxInv_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxInv.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxInv) = True Then
                Me.BtnDele.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RbInvVAT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbInvVAT.KeyDown, RbInvRetail.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
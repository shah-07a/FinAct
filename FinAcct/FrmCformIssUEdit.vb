Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCformIssUEdit
    Dim CFcmd As SqlCommand
    Dim CFrdr As SqlDataReader

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If Me.BtnOk.Text = "&OK" Then
                If Me.CmbxCForm.SelectedIndex = -1 Then Exit Sub
                Me.BtnOk.Text = "&CANCEL"
                Me.CmbxCForm.Enabled = False
                Me.DtpFrom.Enabled = False
                Me.DtpTo.Enabled = False
                Me.BtnSave.Enabled = True
                SelRecd_Fromtable_SALEENTRY()
                Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 20, Screen.PrimaryScreen.WorkingArea.Height - 20)
                Me.Top = 0
                Me.Left = 0
                Me.DgCFORMRECD.Focus()
            Else
                Me.BtnOk.Text = "&OK"
                Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 20, 139)
                Me.CmbxCForm.Enabled = True
                Me.DtpFrom.Enabled = True
                Me.DtpTo.Enabled = True
                Me.BtnSave.Enabled = False
                Me.DgCFORMRECD.Rows.Clear()
                Me.DtpFrom.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub allcontrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.GotFocus, BtnExit.GotFocus, BtnSave.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue

        Catch ex As Exception

        End Try
    End Sub

    Private Sub allcontrl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Leave, BtnExit.Leave, BtnSave.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmCformRecveivable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 20, 139)

            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpFrom, Me.DtpTo)
            Fill_Combobox_Cforms()
            Me.DtpFrom.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCForm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCForm.GotFocus
        Try
            Me.CmbxCForm.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCForm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxCForm_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCForm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCForm.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxCForm) = True Then
                Me.BtnOk.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCForm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxCForm.SelectedIndexChanged
        Try
            If Me.CmbxCForm.SelectedIndex > 0 Then

            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub SelRecd_Fromtable_SALEENTRY()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            CFcmd = New SqlCommand("Finact_PURENTRY_CFORM_Received_Edit_Select", FinActConn)
            CFcmd.CommandType = CommandType.StoredProcedure
            CFcmd.Parameters.AddWithValue("@xSplrid", CInt(Me.CmbxCForm.SelectedValue))
            CFcmd.Parameters.AddWithValue("@xDtF", Me.DtpFrom.Value.Date)
            CFcmd.Parameters.AddWithValue("@xDtT", Me.DtpTo.Value.Date)
            CFrdr = CFcmd.ExecuteReader
            Dim xx As Integer = 0
            Me.DgCFORMRECD.Rows.Clear()
            While CFrdr.Read
                Me.DgCFORMRECD.Rows.Add()
                Me.DgCFORMRECD.Rows(xx).Cells(0).Value = CInt(CFrdr("CFORM_FLAG"))
                Me.DgCFORMRECD.Rows(xx).Cells(1).Value = Format(CFrdr("PURentdt"), "dd/MM/yyyy")
                Me.DgCFORMRECD.Rows(xx).Cells(2).Value = Trim(CFrdr("PURentvno"))
                Me.DgCFORMRECD.Rows(xx).Cells(3).Value = FormatNumber(CFrdr("PURENTTOTLAMT"), 2)
                Me.DgCFORMRECD.Rows(xx).Cells(4).Value = Trim(CFrdr("CFORMNO"))
                Me.DgCFORMRECD.Rows(xx).Cells(5).Value = Trim(CFrdr("CFORMREMARKS"))
                Me.DgCFORMRECD.Rows(xx).Cells(6).Value = CInt(CFrdr("PURentid"))
                xx += 1
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            CFcmd.Dispose()
            CFrdr.Close()
        End Try
    End Sub


    Private Sub ALLCONT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFrom.KeyDown, DtpTo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fill_Combobox_Cforms()
        Dim xStr As String = "FINACT_Rpt_CForm_FILLCMBX1_EDIT_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            CFcmd = New SqlCommand(xStr, FinActConn1)
            CFcmd.CommandType = CommandType.StoredProcedure
            CFcmd.Parameters.AddWithValue("@DtF", Me.DtpFrom.Value.Date)
            CFcmd.Parameters.AddWithValue("@DtT", Me.DtpTo.Value.Date)

            SqlAdptr = New SqlDataAdapter(CFcmd)
            dtaset = New DataSet(CFcmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Me.CmbxCForm.DataSource = dtaset.Tables(0)
            Me.CmbxCForm.ValueMember = "SPLRID"
            Me.CmbxCForm.DisplayMember = "SPLRNAME"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CFcmd.Dispose()
            SqlAdptr.Dispose()
        End Try
    End Sub

    Private Sub DgCFORMRECD_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgCFORMRECD.CellValueChanged
        Try
            If e.ColumnIndex = 0 Then
                If Me.DgCFORMRECD.CurrentCell.Value = True Then
                    Me.DgCFORMRECD.CurrentRow.Cells(4).ReadOnly = False
                    Me.DgCFORMRECD.CurrentRow.Cells(5).ReadOnly = False
                    Me.DgCFORMRECD.CurrentRow.Cells(4).Style.BackColor = Color.White
                    Me.DgCFORMRECD.CurrentRow.Cells(5).Style.BackColor = Color.White
                Else
                    Me.DgCFORMRECD.CurrentRow.Cells(4).ReadOnly = True
                    Me.DgCFORMRECD.CurrentRow.Cells(5).ReadOnly = True
                    Me.DgCFORMRECD.CurrentRow.Cells(4).Style.BackColor = Color.LightGray
                    Me.DgCFORMRECD.CurrentRow.Cells(5).Style.BackColor = Color.LightGray
                End If
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
    Private Sub xCFORMrECD_UPDATE()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            For Each xdgr As DataGridViewRow In Me.DgCFORMRECD.Rows
                If xdgr.Cells(0).Value = False Then
                    CFcmd = New SqlCommand("Finact_PURENTRY_CFORM_INSERT_UPDATE", FinActConn)
                    CFcmd.CommandType = CommandType.StoredProcedure
                    CFcmd.Parameters.AddWithValue("@xROWID", CInt(xdgr.Cells(6).Value))
                    CFcmd.Parameters.AddWithValue("@xCFNO", Trim(""))
                    CFcmd.Parameters.AddWithValue("@xCFREMARKS", Trim(""))
                    CFcmd.Parameters.AddWithValue("@xCFfLAG", 0)
                    CFcmd.ExecuteNonQuery()
                    CFcmd.Dispose()
                End If
            Next
            MsgBox("Current Record has been Updated", MsgBoxStyle.Information, Me.Text)
            Me.DgCFORMRECD.Rows.Clear()
            Me.BtnOk.Text = "&OK"
            Me.Size = New System.Drawing.Point(900, 139)
            Me.CmbxCForm.Enabled = True
            Me.DtpFrom.Enabled = True
            Me.DtpTo.Enabled = True
            Me.BtnSave.Enabled = False
            Me.DtpFrom.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Me.BtnSave.Text.Trim = "&Update" Then
                If Not (Me.DgCFORMRECD.RowCount) > 0 Then
                    MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                    Exit Sub
                End If
                Dim xIn As Integer = 0
                For Each xRR As DataGridViewRow In Me.DgCFORMRECD.Rows
                    If xRR.Cells(0).Value = False Then
                        xIn += 1
                    End If
                Next
                If xIn > 0 Then
                    If MessageBox.Show("Are you sure to update current record(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        xCFORMrECD_UPDATE()
                    Else
                        Return
                    End If

                Else
                    MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                End If
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub


End Class
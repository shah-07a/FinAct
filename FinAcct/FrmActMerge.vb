Imports System.Data
Imports System.Data.SqlClient

Public Class FrmActMerge
    Dim Comd As SqlCommand
    Dim Redr As SqlDataReader
    Dim xCond(0, 1) As String


    Private Sub CmbxType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxType.GotFocus
        Try
            Me.CmbxType.DroppedDown = True
            Me.CmbxAct.DataSource = Nothing
            Me.CmbxAct1.DataSource = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxType.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxType_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxType.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxType) = True Then
                xFillCmbx_Asper_ActType(Me.CmbxType.SelectedIndex)
                Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxAct, "FinactSplrmstr", "Splrid", "SplrName", "SplrType", "SplrDelStatus", xCond(0, 0).Trim, xCond(0, 1).Trim, 1)
                Me.CmbxAct.Enabled = True
                Me.CmbxAct.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xFillCmbx_Asper_ActType(ByVal xSelIndx As Integer)
        Try

            Select Case xSelIndx
                Case 0 '  Bank
                    xCond(0, 0) = "Bank"
                    xCond(0, 1) = "Bank"
                Case 1 'Cash Book
                    xCond(0, 0) = "Cash Book"
                    xCond(0, 1) = "Cash Book"
                Case 2 'Customer/Vendor
                    xCond(0, 0) = "Customer"
                    xCond(0, 1) = "Vendor"
                Case 3 'Sales Agent
                    xCond(0, 0) = "Sales Agent"
                    xCond(0, 1) = "Sales Agent"
                Case 4 'General Account
                    xCond(0, 0) = "General Account"
                    xCond(0, 1) = "General Account"
            End Select
          
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxAct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxAct.GotFocus
        Try
            Me.CmbxAct.DroppedDown = True
            Me.CmbxAct1.Enabled = False
            Me.CmbxAct1.DataSource = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxAct_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxAct.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxAct_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxAct_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxAct.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxAct) = True Then
                Fill_Combobox_Dynamiclly_Where_In_Cond2_And_NOT_COND(Me.CmbxAct1, "FinactSplrmstr", "Splrid", "SplrName", "SplrType", "SplrID", xCond(0, 0).Trim, xCond(0, 1).Trim, CInt(Me.CmbxAct.SelectedValue), "SplrDelStatus", CInt(1))
                Me.CmbxAct1.Enabled = True
                Me.CmbxAct1.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxAct1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxAct1.GotFocus
        Try
            Me.CmbxAct1.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxAct1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxAct1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxAct1_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxAct1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxAct1.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxAct1) = True Then
                Me.BtnOk.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmActMerge_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.CmbxType.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnext.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If Me.CmbxType.SelectedIndex = -1 Then
                Me.CmbxType.Focus()
                Exit Sub
            End If
            If Me.CmbxAct.SelectedIndex = -1 Then
                Me.CmbxAct.Focus()
                Exit Sub
            End If
            If Me.CmbxAct1.SelectedIndex = -1 Then
                Me.CmbxAct1.Focus()
                Exit Sub
            End If
            If CInt(xDynamic_Find_xAnItem_xInA_Table_3INcond("splrid", "Finactsplrmstr", "splrid", "splrundrgrup", CInt(Me.CmbxAct.SelectedValue), 11, 10, 19)) > 0 Then
                MsgBox("Invalid input1!", MsgBoxStyle.Critical, Me.Text)
                Me.CmbxType.Focus()
                Exit Sub
            End If
            Dim xUgrpId As Integer = CInt(xDynamic_Find_xAnItem_xInA_Table_1cond("SPLRUNDRGRUP", "SPLRID", CInt(Me.CmbxAct.SelectedValue), "FINACTSPLRMSTR"))
            Dim xGrupTxt As String = Trim(xDynamic_Find_xAnItem_xInA_Table_1cond_String("CogrupNam", "COGRPID", CInt(xUgrpId), "FINACTGRUPNAME"))
            If xGrupTxt.Trim = "TAX DEDUCTION AT SOURCE (TDS)" Or xGrupTxt.Trim = "VALUE ADDED TAX (VAT INPUT)" Or xGrupTxt.Trim = "CENTRAL SALES TAX (CST)" Or xGrupTxt.Trim = "VALUE ADDED TAX (VAT OUTPUT)" Or xGrupTxt.Trim = "CASH-IN-HAND" Then
                MsgBox("Invalid input!", MsgBoxStyle.Critical, Me.Text)
                Me.CmbxType.Focus()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure to perform this action?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                AutoDataBackupBeforMergeAnAcctt()
                Me.CmbxAct.DataSource = Nothing
                Me.CmbxAct1.DataSource = Nothing
                Me.LblInfo.Text = "?"
                Me.CmbxType.Focus()
            Else
                Return
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub AutoDataBackupBeforMergeAnAcctt()
        Dim Sqlstr As String
        Dim xFlag As Boolean = False
        Try
            Me.LblInfo.Text = "Taking Backup Before Merging Selected Account.............."
            Dim xDir_Backup As String = Application.StartupPath

            If Not System.IO.Directory.Exists(xDir_Backup + "\BeforeMergeAnAccttBackup") Then
                System.IO.Directory.CreateDirectory(xDir_Backup + "\BeforeMergeAnAccttBackup")
            End If

            Bakstr = xDir_Backup + "\BeforeMergeAnAccttBackup"
            Dim Dtstr As String = Format(Now, "ddMMyyyhhmmss")
            Dim xSplrId As Integer = CInt(Me.CmbxAct.SelectedValue)

            Bakstr += "\" & xSplrId & "_DataBackup" & Dtstr & ".bak"
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Sqlstr = "backup database " & (Db_FinAct) & " to disk='" + Bakstr + "' with name='Full Backup of Finact10_bak ',description='Full Backup Of FinAct10 Before Merging an Account'"

            Dim xxFileName As String = Bakstr
            Dim fileExists1 As Boolean
            fileExists1 = My.Computer.FileSystem.FileExists(xxFileName)
            If fileExists1 = True Then
                My.Computer.FileSystem.DeleteFile(xxFileName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                BackupCmd = New SqlClient.SqlCommand(Sqlstr, FinActConn)
                FrmMainMdi.Cursor = Cursors.WaitCursor
                BackupCmd.ExecuteNonQuery()
                FrmMainMdi.Cursor = Cursors.Default
            Else
                BackupCmd = New SqlClient.SqlCommand(Sqlstr, FinActConn)
                FrmMainMdi.Cursor = Cursors.WaitCursor
                BackupCmd.ExecuteNonQuery()
                FrmMainMdi.Cursor = Cursors.Default
            End If
            Me.LblInfo.Text = "Backup Is Completed."
            BackupCmd.Dispose()
            xFlag = True
        Catch ex As Exception
            MsgBox(ex.Message)
            xFlag = False
            Exit Sub
        Finally
            Try
                If xFlag = True Then
                    Me.LblInfo.Text = "Merging Selected Account.............."
                    Comd = New SqlCommand("Finact_Utility_MergeAcctt_UPDATE", FinActConn)
                    Comd.CommandType = CommandType.StoredProcedure
                    Comd.Parameters.AddWithValue("@UpDateiD", CInt(Me.CmbxAct1.SelectedValue))
                    Comd.Parameters.AddWithValue("@CondId", CInt(Me.CmbxAct.SelectedValue))
                    Comd.Parameters.AddWithValue("@Indx", Me.CmbxType.SelectedIndex)
                    Comd.ExecuteNonQuery()
                    Comd.Dispose()
                    Me.LblInfo.Text = "Current Account Merged."
                    MsgBox("Current session has been successfully done.", MsgBoxStyle.Information, Me.Text)
                Else
                    MsgBox("Current Session has been failed", MsgBoxStyle.Critical, Me.Text)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Try

    End Sub

 
End Class
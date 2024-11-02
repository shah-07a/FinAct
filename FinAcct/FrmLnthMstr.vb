
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmLnthMstr
    Dim ConvrtVal_Flag As Boolean
    Dim Itmconfig_cmd As SqlCommand
    Dim ItmConfig_rdr As SqlDataReader
    Dim ad As SqlDataAdapter
    Dim IndxConfig As Integer = 0
    Dim sql As inv_sql
    Dim dgr As DataGridViewRow
    Dim cel As DataGridViewTextBoxCell
    Dim com As DataGridViewComboBoxCell
    Dim Intype, FlagCelVal, FlagCelVal1, FlagCelVal2 As String
    Dim SaveAllow, CellChanged, FlagEditAllow As Boolean
    Private Sub FrmHghtMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.SplitContainer1.FixedPanel = FixedPanel.Panel1
            Me.Left = 10
            Me.Top = 0
            ConvrtVal_Flag = True
            sql = New inv_sql
            Me.Txthtin.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chk_Numericval()
        Dim Ntxt As Control
        For Each Ntxt In Me.TableLayoutPanel1.Controls
            If TypeOf Ntxt Is TextBox Then
                If Ntxt.Text = "" Or IsNumeric(Ntxt.Text) = False Then
                    Ntxt.BackColor = Color.PapayaWhip
                    IndxConfig += 1
                    Label9.Visible = True
                    Label2.Visible = True
                    Label9.Text = "Invalid Input!"
                Else
                    Ntxt.BackColor = Color.White
                    Label9.Visible = False
                    Label2.Visible = False
                End If
            End If
        Next
    End Sub

    Private Sub Btnclse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnclse.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            ConvrtVal_Flag = False
            Chk_Numericval()
            If IndxConfig <> 0 Then
                IndxConfig = 0
                Exit Sub
            Else

                If ChkExisiting_Rec() Then
                    MsgBox("Invalid input! a record with the same value already exisit, try another value", MsgBoxStyle.Critical, Me.Text)
                    Txthtin.Focus()
                    Txthtin.SelectAll()
                    Exit Sub
                Else
                    Save_Recd()
                End If

            End If
        Else
            Try
                Me.dg.EndEdit()
                'If validate_input() Then
                '    MsgBox("Invalid input! a record with the same value already exisit, try another value", MsgBoxStyle.Critical, Me.Text)
                '    Create_fill_datagrid()
                '    Return
                'Else
                Edit_Recd()
                'End If
            Catch ez As Exception
                MessageBox.Show(ez.Message)
            End Try

        End If
    End Sub
    Private Sub Save_Recd()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
        
            If Trim(BtnSave.Text) = "&Save" Then
                Itmconfig_cmd = New SqlCommand("finact_itmlnthmstr_insert", FinActConn)
                Itmconfig_cmd.CommandType = CommandType.StoredProcedure
            End If
            Itmconfig_cmd.Parameters.AddWithValue("@in", Txthtin.Text)
            If RBin.Checked = True Then
                Itmconfig_cmd.Parameters.AddWithValue("@type", "Inch")
            ElseIf RBCm.Checked = True Then
                Itmconfig_cmd.Parameters.AddWithValue("@type", "Cm")
            Else
                Itmconfig_cmd.Parameters.AddWithValue("@type", "Mm")
            End If
            Itmconfig_cmd.Parameters.AddWithValue("@status", "None")
            Itmconfig_cmd.Parameters.AddWithValue("@adusr", Current_UsrId)
            Itmconfig_cmd.Parameters.AddWithValue("@addt", Now)
            Itmconfig_cmd.ExecuteNonQuery()

            MsgBox("Current record has been saved", MsgBoxStyle.Information, Me.Text & " " & "Save_Recd()")
            IntHtCmMm(1) = Trim(Txthtin.Text) 'for item master
            IntHtCmMm(2) = Trim(Txthtin.Text) 'for bom master
            ClearValue()
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MsgBox("Invalid input! system found a record exisited with same value, Try another value", MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            End If
        Finally
            Itmconfig_cmd.Dispose()
            Txthtin.Focus()
            Txthtin.SelectAll()
        End Try


    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        If BtnFind.Text = "&Find" Then
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 125
            'If dg.i > 0 Then
            Me.TableLayoutPanel1.Visible = False
            Me.SplitContainer1.SplitterDistance = 129
            Me.SplitContainer1.IsSplitterFixed = True
            Create_fill_datagrid()
            BtnSave.Text = "&Update"
            BtnFind.Text = "&Delete"


        Else

            If MessageBox.Show("Are you sure to delete?", "Item configuration", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Return
            End If
            Try
                If dg.SelectedRows.Count > 0 Then
                    Dim i As Integer = 0

                    For i = 0 To dg.SelectedRows.Count - 1
                        Itmconfig_cmd = New SqlCommand("Delete from finact_itmlnthmstr where itmlnthid=@itmid", FinActConn)
                        Itmconfig_cmd.Parameters.AddWithValue("@itmid", Me.dg.SelectedRows(i).Cells(0).Value)
                        Itmconfig_cmd.ExecuteNonQuery()
                    Next
                    MsgBox("deleted successfully")
                    Create_fill_datagrid()
                Else
                    MsgBox("System could not found any selected item to delete, Make it sure atleast one item should be selected.", MsgBoxStyle.Information, Me.Text)
                End If

            Catch ex As SqlException
                If ex.Number.Equals(8178) = True Then
                    MsgBox("System could not found any selected item to delete, Make it sure atleast one item should be selected.", MsgBoxStyle.Information, Me.Text)
                Else
                    MessageBox.Show(ex.Message)
                End If

            Finally
                If dg.SelectedRows.Count > 0 Then
                    Itmconfig_cmd.Dispose()
                End If
            End Try
        End If
    End Sub

    Private Sub Create_fill_datagrid()
        Try

            dg.Columns.Clear()
            dg.Rows.Clear()
            dg.Size = New Drawing.Size(Me.Width - Me.SplitContainer1.SplitterDistance - 30, 300)
            dg.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            dg.ForeColor = Color.Navy
            dg.Columns.Add("iid", "Id")
            dg.Columns.Add("in", "Inch")
            dg.Columns(1).DefaultCellStyle.BackColor = Color.Cyan
            dg.Columns.Add("type", "Type")
            dg.Columns.Add("status", "Status")
            dg.Columns.Add("Adusr", "Add User")
            dg.Columns.Add("edtusr", "Edit User")
            dg.Columns.Add("addt", "Add Date")
            dg.Columns.Add("edtdt", "Edit Date")
            dg.Columns(6).Width = 250
            dg.Columns(7).Width = 250

            dg.ColumnHeadersHeight = 60
            dg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            dg.BorderStyle = BorderStyle.FixedSingle
            dg.BackgroundColor = Color.Snow
            Me.SplitContainer1.Panel2.Controls.Add(dg)
            dg.Visible = True
            dg.Left = 0
            dg.Columns(0).Visible = False
            dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red

            Dim pn1(0), pv1(0) As String ''Arrays for procedure argu name n value
            pn1(0) = "@tblname"
            pv1(0) = "Finact_Itmlnthmstr"
            sql.get_data("finact_select_all", pn1, pv1, "size_m")


            Dim mk As Integer
            For mk = 0 To sql.ds.Tables("size_m").Rows.Count - 1
                dgr = New DataGridViewRow()
                'for fetching id
                cel = New DataGridViewTextBoxCell()
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(0).ToString()
                dgr.Cells.Add(cel)

                ' for fetching inch
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(1).ToString()
                dgr.Cells.Add(cel)

                ' for fetching type
                com = New DataGridViewComboBoxCell
                com.Items.Add("Inch")
                com.Items.Add("Cm")
                com.Items.Add("Mm")
                com.Items.Add("None")

                com.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(2).ToString()
                dgr.Cells.Add(com)

                ' for fetching status
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(3).ToString()
                ' cel.ReadOnly = True
                dgr.Cells.Add(cel)
                dgr.Cells(3).ReadOnly = True
                ' for fetching add user
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(4).ToString()
                '  cel.ReadOnly = True
                dgr.Cells.Add(cel)
                dgr.Cells(4).ReadOnly = True
                ' for fetching edit user
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(5).ToString()
                ' cel.ReadOnly = True
                dgr.Cells.Add(cel)
                dgr.Cells(5).ReadOnly = True
                ' for fetching  add date
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(6).ToString()
                ' cel.ReadOnly = True
                dgr.Cells.Add(cel)
                dgr.Cells(6).ReadOnly = True
                ' for fetching  edit date
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(7).ToString()
                dgr.Cells.Add(cel)
                dgr.Cells(7).ReadOnly = True
                dg.Rows.Add(dgr)


            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sql.cnn.Close()
            sql.ds.Dispose()


        End Try
    End Sub

    Private Sub btndele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndele.Click
        If BtnFind.Text = "&Delete" Then
            dg.Visible = False
            Me.TableLayoutPanel1.Visible = True
            Me.SplitContainer1.SplitterDistance = 129
            Me.SplitContainer1.IsSplitterFixed = False
            Me.Width = 498
            BtnSave.Text = "&Save"
            BtnFind.Text = "&Find"
        Else
            ClearValue()
        End If
    End Sub

    Private Sub ClearValue()
        Dim Contrl As Control
        For Each Contrl In Me.TableLayoutPanel1.Controls
            If TypeOf Contrl Is TextBox Then
                Contrl.Text = ""
            ElseIf TypeOf Contrl Is ComboBox Then
                Contrl.Text = ""
            End If
        Next

    End Sub
    Private Function validate_input() As Boolean
        Dim i, j As Integer
        For i = 0 To Me.dg.Rows.Count - 1
            For j = i + 1 To Me.dg.Rows.Count - 1
                If FormatNumber(Me.dg.Rows(i).Cells(1).Value, 4) = FormatNumber(Me.dg.Rows(j).Cells(1).Value, 4) And Me.dg.Rows(i).Cells(2).Value = Me.dg.Rows(j).Cells(2).Value Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function
    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If BtnSave.Text = "&Save" Then
            BtnSave_Click(sender, e)
        End If

    End Sub

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If BtnFind.Text = "&Delete" Then
            BtnFind_Click(sender, e)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ClearValue()
        Txthtin.Focus()
        Txthtin.SelectAll()
    End Sub


    Private Sub Edit_Recd()
        Dim dgcont As Integer = dg.Rows.Count - 1
        Dim dgcont1 As Integer = dg.CurrentRow.Index
        If dgcont = dgcont1 Then
            MsgBox("Invalid Input! System could not found any record to update", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If
        Dim b As Integer = dg.SelectedRows.Count
        Try
            Dim i As Integer = 0
            'For i = 0 To dg.Rows.Count - 2

            If b > 0 Then
                For i = 0 To dg.SelectedRows.Count - 1
                    If FlagEditAllow = True Then
                        If validate_input() Then
                            MsgBox("Invalid input, system found a record with same value, try another value", MsgBoxStyle.Critical)
                            If Trim(FlagCelVal1) <> "" Then
                                Me.dg.SelectedRows(i).Cells(1).Value = FormatNumber(Trim(FlagCelVal1), 4)
                            End If
                            If Trim(FlagCelVal2) <> "" Then
                                Me.dg.SelectedRows(i).Cells(2).Value = Trim(FlagCelVal2)
                            End If

                            FlagEditAllow = False
                            b = 0
                            FlagCelVal1 = ""
                            FlagCelVal2 = ""
                            Exit Sub
                        End If
                    End If

                    Itmconfig_cmd = New SqlCommand("Finact_itmlnthmstr_update", FinActConn)
                    Itmconfig_cmd.CommandType = CommandType.StoredProcedure
                    Itmconfig_cmd.Parameters.AddWithValue("@itmId", Me.dg.SelectedRows(i).Cells(0).Value)
                    Itmconfig_cmd.Parameters.AddWithValue("@in", Me.dg.SelectedRows(i).Cells(1).Value)
                    Itmconfig_cmd.Parameters.AddWithValue("@type", Me.dg.SelectedRows(i).Cells(2).Value)
                    Itmconfig_cmd.Parameters.AddWithValue("@status", Me.dg.SelectedRows(i).Cells(3).Value)
                    Itmconfig_cmd.Parameters.AddWithValue("@edtusr", Me.dg.SelectedRows(i).Cells(5).Value)
                    Itmconfig_cmd.Parameters.AddWithValue("@edtdt", Now)
                    IntHtCmMm(1) = Trim(Me.dg.SelectedRows(i).Cells(1).Value) 'for item master
                    IntHtCmMm(2) = Trim(Me.dg.SelectedRows(i).Cells(1).Value) 'for bom master
                    Itmconfig_cmd.ExecuteNonQuery()

                Next

                MsgBox("Current record has been updated", MsgBoxStyle.Information, Me.Text & " " & "Save_Recd()")

            Else
                MsgBox("No record has been selected for updation.", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

        Catch ex As SqlException
            Dim a As Integer = ex.Number
            If ex.Number > 0 Then
                MsgBox("Invalid input! system found a record exisited with same value, Try another value", MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            End If
            Txthtin.Focus()
            Txthtin.SelectAll()
        Finally
            If b > 0 Then
                Itmconfig_cmd.Dispose()
            End If

        End Try


    End Sub
    Private Function ChkExisiting_Rec() As Boolean
        Try
            If RBin.Checked = True Then
                Intype = "Inch"
            ElseIf RBCm.Checked = True Then
                Intype = "Cm"
            Else
                Intype = "Mm"
            End If
            Itmconfig_cmd = New SqlCommand("select itmlnthin,itmhttype from finact_itmlnthmstr where itmlnthin=@in and itmhttype=@type", FinActConn)
            Itmconfig_cmd.Parameters.AddWithValue("@in", Trim(Txthtin.Text))
            Itmconfig_cmd.Parameters.AddWithValue("@type", Trim(Intype))
            ItmConfig_rdr = Itmconfig_cmd.ExecuteReader
            While ItmConfig_rdr.Read
                If ItmConfig_rdr.HasRows = True Then
                    Return True

                Else
                    Return False

                End If
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Itmconfig_cmd.Dispose()
            ItmConfig_rdr.Close()
        End Try
    End Function

    Private Sub RBin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBin.CheckedChanged
        If RBin.Checked = True Then
            Label1.Text = "Width (Inch)"

        ElseIf RBCm.Checked = True Then
            Label1.Text = "Width (Cm)"

        Else
            Label1.Text = "Width (Mm)"
        End If
    End Sub

    Private Sub RBCm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBCm.CheckedChanged
        If RBin.Checked = True Then
            Label1.Text = "Width (Inch)"

        ElseIf RBCm.Checked = True Then
            Label1.Text = "Width (Cm)"

        Else
            Label1.Text = "Width (Mm)"
        End If
    End Sub

    Private Sub Rbmm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbmm.CheckedChanged
        If RBin.Checked = True Then
            Label1.Text = "Width (Inch)"

        ElseIf RBCm.Checked = True Then
            Label1.Text = "Width (Cm)"

        Else
            Label1.Text = "Width (Mm)"
        End If
    End Sub
    Private Sub dg_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellClick
        If dg.CurrentCell.ColumnIndex = 1 Then
            FlagCelVal1 = Trim(Me.dg.CurrentCell.Value)
        End If
        If dg.CurrentCell.ColumnIndex = 2 Then
            FlagCelVal2 = Trim(Me.dg.CurrentCell.Value)
        End If
    End Sub
    Private Sub dg_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellValueChanged
        If dg.CurrentCell.ColumnIndex = 1 Or dg.CurrentCell.ColumnIndex = 2 Then
            FlagEditAllow = True
        End If
    End Sub

    Private Sub AllControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txthtin.KeyDown, RBCm.KeyDown, RBin.KeyDown, Rbmm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
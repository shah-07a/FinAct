Imports System.Data
Imports System.Data.SqlClient


Public Class FrmShipConts
    Dim ShpCmd As SqlCommand
    Dim ShpRdr As SqlDataReader
    Dim ShpDa As SqlDataAdapter
    Dim sql As New inv_sql
    Dim Sql1 As New inv_sql
    Dim Sql2 As New inv_sql
    Dim DgShpr As DataGridViewRow
    Dim Cel As DataGridViewTextBoxCell
    Dim Com As DataGridViewComboBoxCell
    Dim Allow_find As Boolean = False
    Dim CurSplrid As Integer = 0
    Dim Intype, FlagCelVal, FlagCelVal1, FlagCelVal2 As String
    Dim SaveAllow, CellChanged, FlagEditAllow As Boolean
    Private Sub FrmShipadrs_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FrmActMstrOld.Left = 50
        FrmActMstrOld.Top = 0
        FrmShow_flag(14) = False
    End Sub
    Private Sub FrmShipadrs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Fill_Combobox("desiid", "desiname", "finactdesi", "DesiDelStatus", CInt(1), Me.CmbxJobtytl)
            If FrmShow_flag(17) = True Then
                CurSplrid = SplrID_Editx
            Else
                CurSplrid = FindMaxId(SplrName4Shp, SplrSurfix4Shp)
            End If

            If Chk_Exisit2("finact_shpcontmstr", "shpid", "shpconcrnid", CurSplrid) = True Then
                Me.Left = 20
                Me.Top = 0
                Me.Width = Screen.PrimaryScreen.WorkingArea.Width / 1.2
                Me.SplitContainer1.SplitterDistance = 138
                Me.SplitContainer1.IsSplitterFixed = True
                Btnsave.Text = "&New"
                BtnDele.Visible = True
                BtnDele.Text = "&Delete"
                Create_fill_datagridShpcontMstr()
                Allow_find = True
            Else
                BtnDele.Visible = False
                Btnsave.Text = "&Save"
                Me.SplitContainer1.Panel1.Enabled = False
                Me.txtshpname.Focus()
                Me.txtshpname.SelectAll()
                Allow_find = False
            End If
            If BtnDele.Visible = False Then
                Btnsave.Location = New System.Drawing.Point(10, 276)
            Else
                Btnsave.Location = New System.Drawing.Point(10, 231)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsave.Click
        Try
            If Trim(Btnsave.Text) = "&Save" Then
                Dim svindx As Integer = 0
                If Trim(txtshpPH1.Text) = "" And Trim(Txtshpmail.Text) = "" Then
                    txtshpPH1.BackColor = Color.Cyan
                    txtshpPH1.Focus()
                    svindx += 1
                End If

                If Trim(txtshpname.Text) = "" Then
                    txtshpname.BackColor = Color.Cyan
                    txtshpname.Focus()
                    svindx += 1
                End If
                If svindx <> 0 Then
                    svindx = 0
                    Exit Sub
                Else
                    If Chk_Exisit2("finact_shpContmstr", "shpid", "shpname", Trim(txtshpname.Text)) = True Then
                        MsgBox("Invalid input!, System has found a record already existed with the similar value, Try another", MsgBoxStyle.Critical, "Duplicate found")
                        Me.txtshpname.Focus()
                        Me.txtshpname.SelectAll()
                        Exit Sub
                    Else
                        If SplrStatus4Shp = True Then
                            Save_ShpAdrs()
                        End If
                    End If
                End If
            ElseIf Trim(Btnsave.Text) = "&Update" Then
                Me.dGshp.EndEdit()
                Edit_Recd()
            ElseIf Trim(Btnsave.Text) = "&New" Then
                dGshp.Visible = False
                Me.TableLayoutPanel1.Visible = True
                Btnsave.Text = "&Save"
                BtnDele.Text = "&Find"
                Me.Width = 614
                Me.SplitContainer1.SplitterDistance = 137
                If BtnDele.Visible = False Then
                    Btnsave.Location = New System.Drawing.Point(10, 276)
                Else
                    Btnsave.Location = New System.Drawing.Point(10, 231)
                End If
                txtshpname.Focus()
                txtshpname.SelectAll()
            End If
        Catch ex As Exception
        Finally
            '  FrmShow_flag(14) = False
        End Try
    End Sub
    Private Sub Save_ShpAdrs()
        Try

            ShpCmd = New SqlCommand("finact_shpcontmstr_insert", FinActConn)
            ShpCmd.CommandType = CommandType.StoredProcedure
            If FrmShow_flag(14) = True Then
                ShpCmd.Parameters.AddWithValue("@shpconcrnid", SplrID_Editx)
            Else
                ShpCmd.Parameters.AddWithValue("@shpconcrnid", CurSplrid)
            End If
            ShpCmd.Parameters.AddWithValue("@shpname", Trim(txtshpname.Text))
            ShpCmd.Parameters.AddWithValue("@shpjobid", Trim(CmbxJobtytl.SelectedValue))
            ShpCmd.Parameters.AddWithValue("@shpph1", Trim(txtshpPH1.Text))
            ShpCmd.Parameters.AddWithValue("@shpph2", Trim(txtshpPH2.Text))
            ShpCmd.Parameters.AddWithValue("@shpex1", Trim(Txtextn1.Text))
            ShpCmd.Parameters.AddWithValue("@shpex2", Trim(Txtextn2.Text))
            ShpCmd.Parameters.AddWithValue("@shpmob", Trim(TxtShpMob.Text))
            ShpCmd.Parameters.AddWithValue("@shphome", Trim(Txtshphome.Text))
            ShpCmd.Parameters.AddWithValue("@shpfax", Trim(TxtshpFax.Text))
            ShpCmd.Parameters.AddWithValue("@shpmail", Trim(Txtshpmail.Text))
            ShpCmd.Parameters.AddWithValue("@shpremarks", Trim(txtshpremarks.Text))
            ShpCmd.Parameters.AddWithValue("@shpadusrid", Current_UsrId)
            ShpCmd.Parameters.AddWithValue("@shpaddt", Now)
            ShpCmd.Parameters.AddWithValue("@shpdelstatus", 1)
            ShpCmd.ExecuteNonQuery()
            ClrearValuesShpMstr()
            txtshpname.Focus()
            txtshpname.SelectAll()
            BtnDele.Visible = True
            BtnDele.Text = "&Find"
            Allow_find = True

            If BtnDele.Visible = False Then
                Btnsave.Location = New System.Drawing.Point(10, 276)
            Else
                Btnsave.Location = New System.Drawing.Point(10, 231)
            End If
            MsgBox("Current record has been successfully saved", MsgBoxStyle.Information, "Delivery Address")
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MsgBox("Invalid input!, System has found a record already existed with the similar value, Try another", MsgBoxStyle.Critical, "Duplicate found")
                Me.txtshpname.Focus()
                Me.txtshpname.SelectAll()
            Else
                MsgBox(ex.Message)
            End If

        Finally
            ShpCmd.Dispose()
        End Try
    End Sub

    Private Sub Create_fill_datagridShpcontMstr()
        Try
            dGshp.Columns.Clear()
            dGshp.Rows.Clear()
            dGshp.Size = New Drawing.Size(Me.SplitContainer1.Panel2.Width - 15, Me.SplitContainer1.Height - 15)
            dGshp.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            dGshp.ForeColor = Color.Navy
            dGshp.Columns.Add("iid", "Id")
            dGshp.Columns.Add("cid", "coid")
            ' dGshp.Columns(1).DefaultCellStyle.BackColor = Color.Cyan
            dGshp.Columns.Add("name", "Name")
            dGshp.Columns.Add("Job", "Job Title")
            dGshp.Columns.Add("ph1", "Phone No. Business 1.")
            dGshp.Columns.Add("extn2", "Extn. 2")
            dGshp.Columns.Add("ph2", "Phone No. Business 2.")
            dGshp.Columns.Add("extn1", "Extn. 1")
            dGshp.Columns.Add("Cellno", "Cellur No.")
            dGshp.Columns.Add("home", "Phone No. Home")
            dGshp.Columns.Add("Fax", "Fax No.")
            dGshp.Columns.Add("mail", "E Mail Id")
            dGshp.Columns.Add("Remark", "Remarks")
            dGshp.Columns.Add("ad", "Add User Name")
            dGshp.Columns.Add("Addt", "Add Date")
            dGshp.Columns.Add("edt", "Edit User Name")
            dGshp.Columns.Add("edtdt", "Edit Date")
            dGshp.Columns(14).Width = 250
            dGshp.Columns(16).Width = 250
            dGshp.ColumnHeadersHeight = 60
            dGshp.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            dGshp.BorderStyle = BorderStyle.FixedSingle
            dGshp.BackgroundColor = Color.Snow
            Me.TableLayoutPanel1.Visible = False
            Me.SplitContainer1.Panel2.Controls.Add(dGshp)
            dGshp.Visible = True
            dGshp.Left = 0
            dGshp.Columns(0).Visible = False
            dGshp.Columns(1).Visible = False
            dGshp.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red
            Dim pn11(2), pv11(2) As String
            pn11(0) = "@ta"
            pn11(1) = "@id"
            pn11(2) = "@idval"
            pv11(0) = "Finact_shpContmstr"
            pv11(1) = "Shpconcrnid"
            If FrmShow_flag(14) = True Then
                pv11(2) = SplrID_Editx
            Else
                pv11(2) = CurSplrid
            End If
            sql.get_data("select_where", pn11, pv11, "shpcont") ' shpmstr stands for shpcontmstr
            Dim pn1(0), pv1(0) As String ''Arrays for procedure argu name n value

            Dim mk, r As Integer
            For mk = 0 To sql.ds.Tables("shpcont").Rows.Count - 1
                DgShpr = New DataGridViewRow()
                'for fetching id
                Cel = New DataGridViewTextBoxCell()
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(0).ToString()
                DgShpr.Cells.Add(Cel)

                ' for fetching concern id
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(1).ToString()
                DgShpr.Cells.Add(Cel)




                ' for fetching name
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(3).ToString()
                DgShpr.Cells.Add(Cel)


                'for fetchin job id name
                Com = New DataGridViewComboBoxCell
                ''Dim pn11(2), pv11(2) As String
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finactdesi"
                pv11(1) = "desiid"
                pv11(2) = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(2).ToString()
                Sql2.get_data("select_where", pn11, pv11, "desi") ' desi stands for designation
                Com.Items.Add(Sql2.ds.Tables("desi").Rows(0).ItemArray(1).ToString())

                'Filling job combobox
                pn1(0) = "@ta"
                pv1(0) = "finactdesi"
                Sql1.get_data("select_all", pn1, pv1, "desiA")
                For r = 0 To Sql1.ds.Tables("desiA").Rows.Count - 1
                    If Sql1.ds.Tables("desiA").Rows(r).ItemArray(1).ToString() <> Com.Items(0) Then
                        Com.Items.Add(Sql1.ds.Tables("desiA").Rows(r).ItemArray(1).ToString())
                    End If
                Next
                Sql1.ds.Tables("desiA").Dispose()
                Com.Value = Com.Items(0)
                DgShpr.Cells.Add(Com)

                ' for fetching phone 1
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(4).ToString()
                DgShpr.Cells.Add(Cel)

                ' for fetching extn 1 
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(6).ToString()
                DgShpr.Cells.Add(Cel)

                'for fetching phone 2
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(5).ToString()
                DgShpr.Cells.Add(Cel)

                'for fetching extn 2
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(0).ItemArray(7).ToString()
                DgShpr.Cells.Add(Cel)

                'for fetching mobile
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(0).ItemArray(8).ToString()
                DgShpr.Cells.Add(Cel)

                'for fetching phone home
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(9).ToString()
                DgShpr.Cells.Add(Cel)

                'for fetching Fax
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(10).ToString()
                DgShpr.Cells.Add(Cel)

                'for fetching Email
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(11).ToString()
                DgShpr.Cells.Add(Cel)

                'for fetching Remarks
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(12).ToString()
                DgShpr.Cells.Add(Cel)

                ' for fetching add user
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(13).ToString()
                DgShpr.Cells.Add(Cel)
                DgShpr.Cells(13).ReadOnly = True

                ' for fetching  add date
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(14).ToString()
                DgShpr.Cells.Add(Cel)
                DgShpr.Cells(14).ReadOnly = True

                ' for fetching edit user
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(15).ToString()
                DgShpr.Cells.Add(Cel)
                DgShpr.Cells(15).ReadOnly = True

                ' for fetching  edit date
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpcont").Rows(mk).ItemArray(16).ToString()
                DgShpr.Cells.Add(Cel)
                DgShpr.Cells(16).ReadOnly = True
                dGshp.Rows.Add(DgShpr)

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sql.cnn.Close()
            sql.ds.Dispose()

        End Try
    End Sub

    Private Sub ClrearValuesShpMstr()
        Dim cntr As Control
        For Each cntr In Me.TableLayoutPanel1.Controls
            If TypeOf cntr Is TextBox Then
                cntr.Text = ""
            End If
        Next

    End Sub

    Private Sub Btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btncancel.Click
        Me.Close()
    End Sub

    Private Sub txtshpname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtshpname.GotFocus
        If Me.SplitContainer1.Panel1.Enabled = False Then Me.SplitContainer1.Panel1.Enabled = True
    End Sub

    Private Sub dGshp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGshp.Click
        If Me.dGshp.SelectedRows.Count > 0 Then
            Me.Btnsave.Text = "&Update"
            Me.BtnDele.Text = "&Delete"
        Else
            Me.BtnDele.Text = "&Delete"
            Me.Btnsave.Text = "&New"
        End If

    End Sub

    Private Sub BtnDele_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDele.Click
        If Allow_find = True Then
            If Trim(BtnDele.Text) = "&Find" Then
                Me.Width = Screen.PrimaryScreen.WorkingArea.Width / 1.2
                Me.SplitContainer1.SplitterDistance = 138
                Me.SplitContainer1.IsSplitterFixed = True
                Me.TableLayoutPanel1.Visible = False
                Create_fill_datagridShpcontMstr()
                BtnDele.Text = "&Delete"
                Btnsave.Text = "&New"

            ElseIf Trim(BtnDele.Text) = "&Delete" Then
                If MessageBox.Show("Are you sure to delete?", "Delivery Address ", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                Try
                    If dGshp.SelectedRows.Count > 0 Then
                        Dim i As Integer = 0
                        For i = 0 To dGshp.SelectedRows.Count - 1
                            ShpCmd = New SqlCommand("Delete from finact_shpcontmstr where shpid=@itmid", FinActConn)
                            ShpCmd.Parameters.AddWithValue("@itmid", Me.dGshp.SelectedRows(i).Cells(0).Value)
                            ShpCmd.ExecuteNonQuery()
                        Next
                        MsgBox("Current record has been successfully deleted", MsgBoxStyle.Information)
                        Btnsave.Text = "&New"
                        Create_fill_datagridShpcontMstr()
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
                    If dGshp.SelectedRows.Count > 0 Then
                        ShpCmd.Dispose()
                    End If
                End Try
            End If
        Else
            Me.BtnDele.Visible = False
        End If
    End Sub

    Private Sub Edit_Recd()
        Dim dgcont As Integer = dGshp.Rows.Count - 1
        Dim dgcont1 As Integer = dGshp.CurrentRow.Index
        If dgcont = dgcont1 Then
            MsgBox("Invalid Input! System could not found any record to update", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If
        Dim b As Integer = dGshp.SelectedRows.Count
        Try
            Dim i As Integer = 0

            If b > 0 Then
                For i = 0 To dGshp.SelectedRows.Count - 1
                    If FlagEditAllow = True Then
                        If validate_input() Then
                            MsgBox("Invalid input, system found a record with same value, try another value", MsgBoxStyle.Critical)
                            If Trim(FlagCelVal1) <> "" Then
                                Me.dGshp.SelectedRows(i).Cells(2).Value = Trim(FlagCelVal1)
                            End If
                            FlagEditAllow = False
                            b = 0
                            FlagCelVal1 = ""
                            Exit Sub
                        End If
                    End If
                    ShpCmd = New SqlCommand("Finact_shpcontmstr_update", FinActConn)
                    ShpCmd.CommandType = CommandType.StoredProcedure
                    ShpCmd.Parameters.AddWithValue("@shpid", Trim(Me.dGshp.SelectedRows(i).Cells(0).Value))
                    Dim pn11(2), pv11(2) As String
                    pn11(0) = "@ta"
                    pn11(1) = "@id"
                    pn11(2) = "@idval"
                    pv11(0) = "finactdesi"
                    pv11(1) = "desiname"
                    pv11(2) = Me.dGshp.SelectedRows(i).Cells(3).Value
                    Sql2.get_data("select_where_like", pn11, pv11, "desi") ' cm stands for designation
                    ShpCmd.Parameters.AddWithValue("@shpjobid", Sql2.ds.Tables("desi").Rows(0).ItemArray(0))
                    ShpCmd.Parameters.AddWithValue("@shpname", Trim(Me.dGshp.SelectedRows(i).Cells(2).Value))
                    ShpCmd.Parameters.AddWithValue("@shpph1", Trim(Me.dGshp.SelectedRows(i).Cells(4).Value))
                    ShpCmd.Parameters.AddWithValue("@shpph2", Trim(Me.dGshp.SelectedRows(i).Cells(6).Value))
                    ShpCmd.Parameters.AddWithValue("@shpex1", Trim(Me.dGshp.SelectedRows(i).Cells(5).Value))
                    ShpCmd.Parameters.AddWithValue("@shpex2", Trim(Me.dGshp.SelectedRows(i).Cells(7).Value))
                    ShpCmd.Parameters.AddWithValue("@shpmob", Trim(Me.dGshp.SelectedRows(i).Cells(8).Value))
                    ShpCmd.Parameters.AddWithValue("@shphome", Trim(Me.dGshp.SelectedRows(i).Cells(9).Value))
                    ShpCmd.Parameters.AddWithValue("@shpfax", Trim(Me.dGshp.SelectedRows(i).Cells(10).Value))
                    ShpCmd.Parameters.AddWithValue("@shpmail", Trim(Me.dGshp.SelectedRows(i).Cells(11).Value))
                    ShpCmd.Parameters.AddWithValue("@shpremarks", Trim(Me.dGshp.SelectedRows(i).Cells(12).Value))
                    ShpCmd.Parameters.AddWithValue("@shpedtusrid", Current_UsrId)
                    ShpCmd.Parameters.AddWithValue("@shpedtDt", Now)
                    ShpCmd.Parameters.AddWithValue("@shpdelstatus", 1)
                    ShpCmd.ExecuteNonQuery()
                Next
                MsgBox("Current record has been updated", MsgBoxStyle.Information, Me.Text & " " & "Save_Recd()")
            Else
                MsgBox("No record selected for updation.", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

        Catch ex As SqlException
            Dim a As Integer = ex.Number
            If ex.Number > 0 Then
                '   MsgBox("Invalid input! system found a record exisited with same value, Try another value", MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
                'Else
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            End If

        Finally
            If b > 0 Then
                ShpCmd.Dispose()
            End If

        End Try
    End Sub
    Private Function validate_input() As Boolean
        Dim i, j As Integer
        For i = 0 To Me.dGshp.Rows.Count - 1
            For j = i + 1 To Me.dGshp.Rows.Count - 1
                If (Me.dGshp.Rows(i).Cells(2).Value) = (Me.dGshp.Rows(j).Cells(2).Value) Then
                    Return True
                End If
            Next
        Next
        Return False
        End
    End Function
    Private Sub dgshp_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGshp.CellClick
        If dGshp.CurrentCell.ColumnIndex = 2 Then
            FlagCelVal1 = Trim(Me.dGshp.CurrentCell.Value)
        End If

    End Sub
    Private Sub dgshp_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGshp.CellValueChanged
        If dGshp.CurrentCell.ColumnIndex = 2 Then
            FlagEditAllow = True
        End If
    End Sub


    Private Sub Btnjobtytl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnjobtytl.Click
        Dim frmdesi As New FrmJobTitle
        frmdesi.ShowInTaskbar = False
        FrmShow_flag(0) = True
        frmdesi.ShowDialog()
        frmdesi.Top = 10
        frmdesi.Left = 50

    End Sub

    Private Sub Btnjobtytl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnjobtytl.GotFocus
        If FrmShow_flag(0) = True Then
            CmbxJobtytl.Focus()
        End If
    End Sub

    Private Sub CmbxJobtytl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxJobtytl.GotFocus
        CmbxJobtytl.DroppedDown = True
        If FrmShow_flag(0) = True Then
            Fill_Combobox("desiid", "desiname", "finactdesi", "DesiDelStatus", CInt(1), Me.CmbxJobtytl)
            Dim Indxht As Integer = CmbxJobtytl.FindString(IntHtCmMm(0), 0)
            CmbxJobtytl.SelectedIndex = Indxht
        Else
            If CmbxJobtytl.Items.Count > 0 And CmbxJobtytl.SelectedIndex = -1 Then
                CmbxJobtytl.SelectedIndex = 0
            End If

        End If
    End Sub

    Private Sub CmbxJobtytl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxJobtytl.Leave
        If FrmShow_flag(0) = True Then
            FrmShow_flag(0) = False
            txtshpPH1.Focus()
        End If

    End Sub

    Private Sub AllControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtextn1.KeyDown, CmbxJobtytl.KeyDown _
    , Txtextn2.KeyDown, TxtshpFax.KeyDown, Txtshphome.KeyDown, Txtshpmail.KeyDown, TxtShpMob.KeyDown, txtshpname.KeyDown, txtshpPH1.KeyDown, txtshpPH2.KeyDown _
    , txtshpremarks.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
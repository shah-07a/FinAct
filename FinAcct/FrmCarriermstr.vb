Imports System.Data
Imports System.Data.SqlClient


Public Class FrmCarriermstr
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
    End Sub
    Private Sub FrmShipadrs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strCond As String = "Outer"
        Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", Me.Cmbxshpcty, strCond, "CSCDELSTATUS", CInt(1))
        If Chk_Exisit2Rec("shpid", "finact_carriermstr") = True Then
            Me.Left = 20
            Me.Top = 0
            Me.SplitContainer1.IsSplitterFixed = True
            BtnDele.Visible = True
            BtnDele.Text = "&Find"
            Btnsave.Text = "&Save"
            Me.SplitContainer1.Panel1.Enabled = False
            Me.txtshpname.Focus()
            Me.txtshpname.SelectAll()
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

    End Sub

    Private Sub Btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsave.Click
        If Trim(Btnsave.Text) = "&Save" Then
            Dim svindx As Integer = 0
            If Trim(txtshpadrs.Text) = "" Then
                txtshpadrs.BackColor = Color.Cyan
                txtshpadrs.Focus()
                svindx += 1
            Else
                txtshpadrs.BackColor = Color.White
            End If
            If Trim(Cmbxshpcty.Text) = "" Then
                Cmbxshpcty.BackColor = Color.Cyan
                Cmbxshpcty.Focus()
                svindx += 1
            Else
                Cmbxshpcty.BackColor = Color.White
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
                If Chk_Exisit2("finact_Carriermstr", "shpid", "shpname", Trim(txtshpname.Text)) = True Then
                    MsgBox("Invalid input!, System has found a record already existed with the similar value, Try another", MsgBoxStyle.Critical, "Duplicate found")
                    Me.txtshpname.Focus()
                    Me.txtshpname.SelectAll()
                    Exit Sub
                Else
                    Save_ShpAdrs()
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
    End Sub
    Private Sub Save_ShpAdrs()
        Try
            ShpCmd = New SqlCommand("finact_Carriermstr_insert", FinActConn)
            ShpCmd.CommandType = CommandType.StoredProcedure
            ''ShpCmd.Parameters.AddWithValue("@shpconcrnid", CurSplrid)
            ShpCmd.Parameters.AddWithValue("@shpname", Trim(txtshpname.Text))
            ShpCmd.Parameters.AddWithValue("@shpadrs", Trim(txtshpadrs.Text))
            ShpCmd.Parameters.AddWithValue("@shpadrs1", Trim(txtshpadrs1.Text))
            ShpCmd.Parameters.AddWithValue("@shpadrs2", Trim(txtshpadrs2.Text))
            ShpCmd.Parameters.AddWithValue("@shpctyid", CInt(Cmbxshpcty.SelectedValue))
            If Trim(Me.txtshppinno.Text) = "" Then
                ShpCmd.Parameters.AddWithValue("@shppin", 0)
            Else
                ShpCmd.Parameters.AddWithValue("@shppin", Trim(txtshppinno.Text))
            End If
            ShpCmd.Parameters.AddWithValue("@shpphno", Trim(txtshpphno.Text))
            ShpCmd.Parameters.AddWithValue("@shpchk", 1) 'Trim(CmbxMode.Text))
            ShpCmd.Parameters.AddWithValue("@shpadusrid", Current_UsrId)
            ShpCmd.Parameters.AddWithValue("@shpaddt", Now)
            ShpCmd.Parameters.AddWithValue("@shpdelstatus", 1)
            If FrmShow_flag(7) = True Then
                IntHtCmMm(7) = Trim(txtshpname.Text)
            End If
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

    Private Sub Cmbxshpcty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxshpcty.GotFocus
        Cmbxshpcty.DroppedDown = True
        If FrmShow_flag(0) = True Then
            Fill_Combobox("cscid", "cscctyname", "finactcscmstr", "CSCDELSTATUS", CInt(1), Me.Cmbxshpcty)
            Dim Indxht As Integer = Cmbxshpcty.FindString(IntHtCmMm(0), 0)
            Cmbxshpcty.SelectedIndex = Indxht
        Else
            If Cmbxshpcty.Items.Count > 0 And Cmbxshpcty.SelectedIndex = -1 Then
                Cmbxshpcty.SelectedIndex = 0
            End If

        End If
    End Sub

    Private Sub Cmbxshpcty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxshpcty.Leave
        fetch_rec_statecontry()
        If FrmShow_flag(0) = True Then
            FrmShow_flag(0) = False
            txtshppinno.Focus()
        End If

    End Sub

    Private Sub fetch_rec_statecontry()
        Try
            ShpCmd = New SqlCommand("select * from FinactCscmstr where cscid=@city", FinActConn)
            Dim a As Integer = CInt(Cmbxshpcty.SelectedValue)
            ShpCmd.Parameters.AddWithValue("@city", a)
            ShpRdr = ShpCmd.ExecuteReader
            ShpRdr.Read()
            If ShpRdr.HasRows = True Then
                lblshpstate.Text = ShpRdr("cscstatename")
                lblshpcontry.Text = ShpRdr("csccontry")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ShpCmd = Nothing
            ShpRdr.Close()
        End Try
    End Sub

    Private Sub txtshppinno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtshppinno.Leave
        If Trim(txtshppinno.Text) <> "" Then
            If IsNumeric(txtshppinno.Text) = False Then
                MsgBox("Invalid input, Only Number are allowed.", MsgBoxStyle.Critical, "Input like 1234")
                txtshppinno.BackColor = Color.Cyan
                txtshppinno.Focus()
                txtshppinno.SelectAll()
            Else
                txtshppinno.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub Create_fill_datagridShpMstr()
        Try
            dGshp.Columns.Clear()
            dGshp.Rows.Clear()
            dGshp.Size = New Drawing.Size(Me.SplitContainer1.Panel2.Width - 15, Me.SplitContainer1.Height - 15)
            dGshp.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            dGshp.ForeColor = Color.Navy
            dGshp.Columns.Add("iid", "Id")
            dGshp.Columns.Add("name", "Name")
            dGshp.Columns.Add("adrs", "Address")
            dGshp.Columns.Add("adrs1", "Area")
            dGshp.Columns.Add("adrs2", "Land Mark")
            dGshp.Columns.Add("City", "City")
            dGshp.Columns.Add("state", "State")
            dGshp.Columns.Add("Contry", "Country")
            dGshp.Columns.Add("pin", "Pin No.")
            dGshp.Columns.Add("Ph", "Ph. No.")
            dGshp.Columns.Add("dflt", "Mode")
            dGshp.Columns.Add("ad", "Add User Name")
            dGshp.Columns.Add("Addt", "Add Date")
            dGshp.Columns.Add("edt", "Edit User Name")
            dGshp.Columns.Add("edtdt", "Edit Date")
            dGshp.Columns(12).Width = 250
            dGshp.Columns(14).Width = 250
            dGshp.ColumnHeadersHeight = 60
            dGshp.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            dGshp.BorderStyle = BorderStyle.FixedSingle
            dGshp.BackgroundColor = Color.Snow
            Me.TableLayoutPanel1.Visible = False
            Me.SplitContainer1.Panel2.Controls.Add(dGshp)
            dGshp.Visible = True
            dGshp.Left = 0
            dGshp.Columns(0).Visible = False
            dGshp.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red
            Dim pn11(2), pv11(2) As String
            Dim pn1(0), pv1(0) As String ''Arrays for procedure argu name n value
            pn1(0) = "@ta"
            pv1(0) = "Finact_Carriermstr"
            sql.get_data("select_all", pn1, pv1, "shpmstr") ' shpmstr stands for shpadrsmstr
            Dim mk, r As Integer
            For mk = 0 To sql.ds.Tables("shpmstr").Rows.Count - 1
                DgShpr = New DataGridViewRow()
                'for fetching id
                Cel = New DataGridViewTextBoxCell()
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(0).ToString()
                DgShpr.Cells.Add(Cel)

                ' for fetching name
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(1).ToString()
                DgShpr.Cells.Add(Cel)

                ' for fetching address
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(2).ToString()
                DgShpr.Cells.Add(Cel)

                ' for fetching Area
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(3).ToString()
                DgShpr.Cells.Add(Cel)

                'for fetching land mark
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(4).ToString()
                DgShpr.Cells.Add(Cel)

                'for fetching city
                Com = New DataGridViewComboBoxCell
                ''Dim pn11(2), pv11(2) As String
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finactcscmstr"
                pv11(1) = "cscid"
                pv11(2) = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(5).ToString()
                Sql2.get_data("select_where", pn11, pv11, "CM") ' cm stands for city master
                Com.Items.Add(Sql2.ds.Tables("CM").Rows(0).ItemArray(1).ToString())

                'Filling city combobox
                pn1(0) = "@ta"
                pv1(0) = "finactcscmstr"
                Sql1.get_data("select_all", pn1, pv1, "cMa")
                For r = 0 To Sql1.ds.Tables("cMa").Rows.Count - 1
                    If Sql1.ds.Tables("cMa").Rows(r).ItemArray(1).ToString() <> Com.Items(0) Then
                        Com.Items.Add(Sql1.ds.Tables("cMa").Rows(r).ItemArray(1).ToString())
                    End If
                Next
                Sql1.ds.Tables("cMa").Dispose()
                Com.Value = Com.Items(0)
                DgShpr.Cells.Add(Com)

                'for fetching state
                Cel = New DataGridViewTextBoxCell
                Cel.Value = Sql2.ds.Tables("CM").Rows(0).ItemArray(2).ToString()
                DgShpr.Cells.Add(Cel)
                DgShpr.Cells(6).ReadOnly = True

                'for fetching Country
                Cel = New DataGridViewTextBoxCell
                Cel.Value = Sql2.ds.Tables("CM").Rows(0).ItemArray(3).ToString()
                DgShpr.Cells.Add(Cel)
                DgShpr.Cells(7).ReadOnly = True

                'for fetching Pin no
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(6).ToString()
                DgShpr.Cells.Add(Cel)

                'for fetching phone no
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(7).ToString()
                DgShpr.Cells.Add(Cel)

                'for fetching default
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(8).ToString()
                DgShpr.Cells.Add(Cel)


                ' for fetching add user
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(9).ToString()
                DgShpr.Cells.Add(Cel)
                DgShpr.Cells(11).ReadOnly = True

                ' for fetching  add date
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(10).ToString()
                DgShpr.Cells.Add(Cel)
                DgShpr.Cells(12).ReadOnly = True

                ' for fetching edit user
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(11).ToString()
                DgShpr.Cells.Add(Cel)
                DgShpr.Cells(13).ReadOnly = True

                ' for fetching  edit date
                Cel = New DataGridViewTextBoxCell
                Cel.Value = sql.ds.Tables("Shpmstr").Rows(mk).ItemArray(12).ToString()
                DgShpr.Cells.Add(Cel)
                DgShpr.Cells(14).ReadOnly = True
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
                Create_fill_datagridShpMstr()
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
                            ShpCmd = New SqlCommand("Delete from finact_carriermstr where shpid=@itmid", FinActConn)
                            ShpCmd.Parameters.AddWithValue("@itmid", Me.dGshp.SelectedRows(i).Cells(0).Value)
                            ShpCmd.ExecuteNonQuery()
                        Next
                        MsgBox("Current record has been successfully deleted", MsgBoxStyle.Information)
                        Btnsave.Text = "&New"
                        Create_fill_datagridShpMstr()
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
                                Me.dGshp.SelectedRows(i).Cells(1).Value = Trim(FlagCelVal1)
                            End If
                            FlagEditAllow = False
                            b = 0
                            FlagCelVal1 = ""
                            Exit Sub
                        End If
                    End If
                    ShpCmd = New SqlCommand("Finact_Carriermstr_update", FinActConn)
                    ShpCmd.CommandType = CommandType.StoredProcedure
                    ShpCmd.Parameters.AddWithValue("@shpid", Me.dGshp.SelectedRows(i).Cells(0).Value)
                    ShpCmd.Parameters.AddWithValue("@shpname", Me.dGshp.SelectedRows(i).Cells(1).Value)
                    ShpCmd.Parameters.AddWithValue("@shpadrs", Me.dGshp.SelectedRows(i).Cells(2).Value)
                    ShpCmd.Parameters.AddWithValue("@shpadrs1", Me.dGshp.SelectedRows(i).Cells(3).Value)
                    ShpCmd.Parameters.AddWithValue("@shpadrs2", Me.dGshp.SelectedRows(i).Cells(4).Value)
                    Dim pn11(2), pv11(2) As String
                    pn11(0) = "@ta"
                    pn11(1) = "@id"
                    pn11(2) = "@idval"
                    pv11(0) = "finactcscmstr"
                    pv11(1) = "cscctyname"
                    pv11(2) = Me.dGshp.SelectedRows(i).Cells(5).Value
                    Sql2.get_data("select_where_like", pn11, pv11, "CM") ' cm stands for city master
                    '  Dim a As Integer = Sql2.ds.Tables("CM").Rows(0).ItemArray(0)
                    ShpCmd.Parameters.AddWithValue("@shpctyid", Sql2.ds.Tables("CM").Rows(0).ItemArray(0))

                    ShpCmd.Parameters.AddWithValue("@shppin", Me.dGshp.SelectedRows(i).Cells(8).Value)
                    ShpCmd.Parameters.AddWithValue("@shpphno", Me.dGshp.SelectedRows(i).Cells(9).Value)
                    ShpCmd.Parameters.AddWithValue("@shpchk", Me.dGshp.SelectedRows(i).Cells(10).Value)
                    ShpCmd.Parameters.AddWithValue("@shpedtusrid", Current_UsrId)
                    ShpCmd.Parameters.AddWithValue("@shpedtDt", Now)
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
                MsgBox("Invalid input! system found a record exisited with same value, Try another value", MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            Else
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
                If (Me.dGshp.Rows(i).Cells(1).Value) = (Me.dGshp.Rows(j).Cells(1).Value) Then
                    Return True
                End If
            Next
        Next
        Return False
        End
    End Function
    Private Sub dgshp_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGshp.CellClick
        If dGshp.CurrentCell.ColumnIndex = 1 Then
            FlagCelVal1 = Trim(Me.dGshp.CurrentCell.Value)
        End If

    End Sub
    Private Sub dgshp_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGshp.CellValueChanged
        If dGshp.CurrentCell.ColumnIndex = 1 Then
            FlagEditAllow = True
        End If
    End Sub

    Private Sub BtnShpcty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShpcty.Click
        Dim frmcty As New FrmCsCMstr
        FrmShow_flag(0) = True
        frmcty.ShowInTaskbar = False
        frmcty.ShowDialog()
    End Sub

    Private Sub BtnShpcty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShpcty.GotFocus
        If FrmShow_flag(0) = True Then
            Cmbxshpcty.Focus()
        End If
    End Sub

    Private Sub CmbxMode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxMode.GotFocus
        Try
            Me.CmbxMode.DroppedDown = True
            If CmbxMode.Items.Count > 0 Then
                If CmbxMode.SelectedIndex = -1 Then
                    CmbxMode.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function Chk_Exisit2Rec(ByVal xTable As Object, ByVal xFieldname As Object) As Boolean
        Dim xStr As String = ("Select " & (xTable) & " from  " & (xFieldname) & " ")
        Try
            ShpCmd = New SqlCommand(xStr, FinActConn)
            ShpRdr = ShpCmd.ExecuteReader
            While ShpRdr.Read
                If ShpRdr.HasRows = True Then
                    xStr2 = ShpRdr(0)
                    Return True
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ShpCmd.Dispose()
            ShpRdr.Close()
        End Try
    End Function

    Private Sub AllControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxMode.KeyDown, Cmbxshpcty.KeyDown _
    , txtshpadrs.KeyDown, txtshpadrs1.KeyDown, txtshpadrs2.KeyDown, txtshpname.KeyDown, txtshpphno.KeyDown, txtshppinno.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CmbxMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxMode.SelectedIndexChanged

    End Sub

    Private Sub Cmbxshpcty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxshpcty.SelectedIndexChanged

    End Sub
End Class
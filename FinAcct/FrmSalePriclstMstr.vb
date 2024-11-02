Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmSalePriclstMstr
    Dim SpL_cmd As SqlCommand
    Dim SpL_Rdr As SqlDataReader
    Dim SpL_cmd1 As SqlCommand
    Dim SpL_Rdr1 As SqlDataReader
    Dim SpL_Adptr As SqlDataAdapter
    Dim SpL_Dset As DataSet
    Dim AlowReset As Boolean = False
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim SetDgWritable As Boolean = False
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmSalePriclstMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 100
            Me.Width = 338
            Me.Height = 638
            Fill_Combobox_where_Not_In_cond("Cogrpid", "Cogrupnam", "Cogrpid", "FinactStokGrupName", CInt(1), CInt(1), Me.CmbxUndrGrup, "CODELSTATUS", CInt(1))
            Me.CmbxUndrGrup.SelectedIndex = -1
            Me.txtLstName.Focus()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CreateGridColumns_SalePriceList_Select()
        Try
            Me.DgPRice.Height = 526
            Me.LstVewSpL.Enabled = False
            Me.LstVewSpL.Visible = False
            Dim DgItms As DataGridView
            DgItms = Me.DgPRice
            DgItms.Columns.Clear()
            If Cl_Kbl = True Then
                SpL_cmd = New SqlCommand("Finact_Itemmaster_SpL_KBLTYPE_Select", FinActConn) '=== IT INCLUDES BOTH SALE AND TRADING ITEMS
                SpL_cmd.CommandType = CommandType.StoredProcedure
                SpL_cmd.Parameters.AddWithValue("@GRUPid", CInt(Me.CmbxUndrGrup.SelectedValue))
                If Me.ChkGrpAll.CheckState = CheckState.Checked Then
                    SpL_cmd.Parameters.AddWithValue("@xOptn", CInt(2))
                Else
                    SpL_cmd.Parameters.AddWithValue("@xOptn", CInt(1))
                End If
            Else
                SpL_cmd = New SqlCommand("Finact_Itemmaster_SpL_Select", FinActConn) '=== IT INCLUDES SALE ITEMS ONLY
                SpL_cmd.CommandType = CommandType.StoredProcedure
            End If



            SpL_Adptr = New Data.SqlClient.SqlDataAdapter(SpL_cmd)
            SpL_Dset = New Data.DataSet()
            SpL_Adptr.Fill(SpL_Dset, "finactitmmstr")
            DgItms.DataSource = SpL_Dset.Tables("finactitmmstr")

            ' DgItms.Columns.Add("iId", "Item Id")

            DgItms.Columns(0).HeaderText = "Item Id"
            DgItms.Columns(0).Name = "iId"
            DgItms.Columns(0).ReadOnly = True
            DgItms.Columns(0).Visible = False
            ' Dim dt As DataGridViewTextBoxColumn = TryCast(DgItms.Columns(0), DataGridViewTextBoxColumn)
            'dt.MaxInputLength = 10
            DgItms.Columns(0).Width = 0


            'DgItms.Columns.Add("ColItemid", "Item Code")
            DgItms.Columns(1).HeaderText = "Item Code"
            DgItms.Columns(1).Name = "ColItemid"
            DgItms.Columns(1).Width = 120
            DgItms.Columns(1).ReadOnly = True
            DgItms.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            'DgItms.Columns.Add("ColDescription", "Item Name")
            DgItms.Columns(2).HeaderText = "Description"
            DgItms.Columns(2).Name = "ColDescription"
            DgItms.Columns(2).Width = 320
            DgItms.Columns(2).ReadOnly = True

            'DgItms.Columns.Add("ColUnittype", "Unit Type")
            DgItms.Columns(3).HeaderText = "Unit Type"
            DgItms.Columns(3).Name = "ColUnittype"
            DgItms.Columns(3).Width = 60
            DgItms.Columns(3).ReadOnly = True
            DgItms.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DgItms.Columns(4).HeaderText = "Packing"
            DgItms.Columns(4).Name = "pack"
            DgItms.Columns(4).Width = 0
            DgItms.Columns(4).ReadOnly = True
            DgItms.Columns(4).Visible = False
            DgItms.Columns(4).DefaultCellStyle.Format = "N0"
            DgItms.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' DgItms.Columns.Add("Mpack", "Master Packing")
            DgItms.Columns(5).HeaderText = "Master Packing"
            DgItms.Columns(5).Name = "Mpack"
            DgItms.Columns(5).Width = 60
            DgItms.Columns(5).ReadOnly = False
            DgItms.Columns(5).DefaultCellStyle.Format = "N0"
            DgItms.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'DgItms.Columns.Add("colCost", "Rate")
            DgItms.Columns(6).HeaderText = "Rate"
            DgItms.Columns(6).Name = "colCost"
            DgItms.Columns(6).Width = 100
            DgItms.Columns(6).DefaultCellStyle.Format = "N2"
            DgItms.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgItms.Columns(6).DefaultCellStyle.NullValue = Nothing

            ''DgItms.Columns.Add("colSelect", "Select")
            ''DgItms.Columns(7).Width = 100

            ''DgItms.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
           

            DgItms.MultiSelect = False
            DgItms.AllowUserToDeleteRows = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SpL_cmd.Dispose()
            SpL_Adptr.Dispose()
            Me.DgPRice.Focus()
        End Try

    End Sub
    Private Sub Fill_DgExlusive()
        Try
            Me.DgExclusive.Rows.Clear()
            Dim i As Integer = 0
            If Cl_Kbl = True Then
                SpL_cmd = New SqlCommand("Finact_Itemmaster_SpL_KBLTYPE_Select", FinActConn) '=== IT INCLUDES BOTH SALE AND TRADING ITEMS
                SpL_cmd.CommandType = CommandType.StoredProcedure
                SpL_cmd.Parameters.AddWithValue("@GRUPid", CInt(Me.CmbxUndrGrup.SelectedValue))
              
            Else
                SpL_cmd = New SqlCommand("Finact_Itemmaster_SpL_Select", FinActConn) '=== IT INCLUDES SALE ITEMS ONLY
                SpL_cmd.CommandType = CommandType.StoredProcedure
            End If

            SpL_Rdr = SpL_cmd.ExecuteReader
            While SpL_Rdr.Read
                If SpL_Rdr.IsDBNull(0) = False Then
                    Me.DgExclusive.Rows.Add()
                    Me.DgExclusive.Rows(i).Cells(1).Value = SpL_Rdr(0)
                    Me.DgExclusive.Rows(i).Cells(2).Value = SpL_Rdr(1)
                    Me.DgExclusive.Rows(i).Cells(3).Value = SpL_Rdr(2)
                    Me.DgExclusive.Rows(i).Cells(4).Value = SpL_Rdr(3)
                    Me.DgExclusive.Rows(i).Cells(5).Value = SpL_Rdr(4)
                    Me.DgExclusive.Rows(i).Cells(6).Value = SpL_Rdr(5)
                    Me.DgExclusive.Rows(i).Cells(7).Value = SpL_Rdr(6)
                    i += 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SpL_cmd.Dispose()
            SpL_Rdr.Close()

        End Try
    End Sub

    Private Sub DgPRice_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPRice.CellEndEdit
       
        Try
            If e.ColumnIndex = 6 Then
                Me.DgPRice.CurrentRow.Cells(e.ColumnIndex).Value = FormatNumber(CDbl(Me.DgPRice.CurrentRow.Cells(e.ColumnIndex).Value), 2, , , TriState.False)
                Me.DgPRice.CurrentRow.Cells(e.ColumnIndex).ErrorText = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgPRice_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPRice.CellEnter
        Try
            If e.ColumnIndex = 4 Then
                If SetDgWritable = True Then
                    Me.DgPRice.CurrentRow.Cells(4).ReadOnly = False
                Else
                    Me.DgPRice.CurrentRow.Cells(4).ReadOnly = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgPRice_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgPRice.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgPRice.Rows.Count '- 1
            If Cr_Row <> Me.DgPRice.CurrentRow.Index Then
                If e.ColumnIndex = 6 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then

                        Me.DgPRice.CurrentRow.Cells(6).ErrorText = "Invalid Input! Only Numbers are allowed"
                        MsgBox("Invalid Input", MsgBoxStyle.Critical, "Number only!!!")
                        e.Cancel = True
                    Else

                        Me.DgPRice.CurrentRow.Cells(6).ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function validate_input() As Boolean
        Try
            Dim i, j As Integer
            If Me.RbNormal.Checked = True Then
                For i = 0 To Me.DgPRice.Rows.Count - 1
                    If Not Me.DgPRice.Rows(i).Cells(6).Value >= 0 Then
                        Me.DgPRice.Rows(i).Cells(6).ErrorText = "Empty Cell not allowed"
                        'Return True
                        j += 1
                    End If

                Next
            ElseIf Me.RbExclusive.Checked = True Then
                For i = 0 To Me.DgExclusive.Rows.Count - 1
                    If Not Me.DgExclusive.Rows(i).Cells(7).Value >= 0 Then
                        Me.DgExclusive.Rows(i).Cells(7).ErrorText = "Empty Cell not allowed"
                        'Return True
                        j += 1
                    End If
                Next

            End If


            
            If j <> 0 Then
                j = 0
                Return True
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Trim(Me.BtnSave.Text) = "&Save" Then
                If Trim(Me.txtLstName.Text) = "" Then
                    Me.txtLstName.Focus()
                    Exit Sub
                End If
                If validate_input() = True Then
                    MsgBox("Invalid Input! pl check alert message", MsgBoxStyle.Critical, "Alert!!!! ")
                    Exit Sub
                End If
                Save_SpLMasterChild()
            ElseIf Trim(Me.BtnSave.Text) = "&New" Then
                Me.Width = 338
                Me.DgPRice.Enabled = False
                Me.Top = 0
                Me.Left = 100
                Me.txtLstName.Text = ""
                Me.Txtremks.Text = ""
                Me.Panel1.Enabled = True
                Me.CmbxPriclst.Visible = False
                Me.CmbxPriclst.Enabled = False
                Me.BtnShow.Enabled = False
                Me.BtnShow.Visible = False
                Me.Label3.Visible = False
                Me.Label5.Visible = False
                Me.lblEdate.Visible = False
                Me.dtpEdt.Enabled = True
                Me.DtpUpTodt.Enabled = True
                Me.lblTdate.Visible = False
                Me.Label7.Visible = False
                Me.txtLstName.Focus()
                Me.BtnSave.Text = "&Save"
                Me.Btnaply.Text = "&Find"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub

    Private Sub dtpEdt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEdt.Leave
        Try
            If Me.ToolStripMenuItem4.Enabled = False Then
                Btnok_Click(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

  
    Private Sub Save_SpLMasterChild()
        Try
            Dim Xcntr As Integer
            If Me.RbNormal.Checked = True Then
                If Me.DgPRice.Rows.Count > 0 Then
                    For Xcntr = 0 To Me.DgPRice.Rows.Count - 1
                        If FinActConn.State Then FinActConn.Close()
                        FinActConn.Open()
                        SpL_cmd = New SqlCommand("finact_salepricelstmstr_insert", FinActConn)
                        SpL_cmd.CommandType = CommandType.StoredProcedure
                        '=-->Finact_SalePriceLstmstr
                        SpL_cmd.Parameters.AddWithValue("@splSaveStatus", Xcntr)
                        SpL_cmd.Parameters.AddWithValue("@splname", Trim(Me.txtLstName.Text))
                        SpL_cmd.Parameters.AddWithValue("@splefctdt", (Me.dtpEdt.Value.Date))
                        SpL_cmd.Parameters.AddWithValue("@splefcttodt", (Me.DtpUpTodt.Value.Date))
                        SpL_cmd.Parameters.AddWithValue("@spladusr", Current_UsrId)
                        SpL_cmd.Parameters.AddWithValue("@splType", "Normal")
                        SpL_cmd.Parameters.AddWithValue("@spladdt", Now)
                        SpL_cmd.Parameters.AddWithValue("@Clditmid", Me.DgPRice.Rows(Xcntr).Cells(0).Value)
                        SpL_cmd.Parameters.AddWithValue("@splcld_MstrPack", Me.DgPRice.Rows(Xcntr).Cells(5).Value)
                        SpL_cmd.Parameters.AddWithValue("@Cldrate", Me.DgPRice.Rows(Xcntr).Cells(6).Value)
                        If xMACH_xSALERATELIST = True Then
                            SpL_cmd.Parameters.AddWithValue("@SPLITMTYPE", "MACH")
                        Else
                            SpL_cmd.Parameters.AddWithValue("@SPLITMTYPE", "FAB")
                        End If

                        SpL_cmd.ExecuteNonQuery()
                    Next
                    Dim mxid As Integer = FetchMaxId(Trim(Me.txtLstName.Text))
                    MsgBox("Current Record(s) has been successfully saved", MsgBoxStyle.Information, "Sale Price List Saved!!!")
                    Fill_Combobox("spl_id", "spl_name", "Finact_salepricelstmstr", "SPl_DELSTATUS", CInt(1), Me.CmbxPriclst)
                    SetFormAfterSave()
                    If Cl_Kbl = False Then
                        If MessageBox.Show("Would you like to replace master sale price list with current sale price list", "New Sale Price List", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            Me.CmbxPriclst.SelectedValue = mxid
                            OverWriteMstrPriceLst(Me.CmbxPriclst.SelectedValue)
                        End If
                    End If
                    Me.txtLstName.Focus()
                    Me.txtLstName.Text = ""
                Else
                    MsgBox("Invalid input!!", MsgBoxStyle.Critical, "No Record Found To Save!!!")
                    Me.txtLstName.Focus()
                    Me.txtLstName.SelectAll()
                End If
            ElseIf Me.RbExclusive.Checked = True Then
                If Me.DgExclusive.Rows.Count > 0 Then
                    Dim xOk As Integer = 0
                    For Xcntr = 0 To Me.DgExclusive.Rows.Count - 1
                        If Me.DgExclusive.Rows(Xcntr).Cells(0).Value = True Then
                            If FinActConn.State Then FinActConn.Close()
                            FinActConn.Open()
                            SpL_cmd = New SqlCommand("finact_salepricelstmstr_insert", FinActConn)
                            SpL_cmd.CommandType = CommandType.StoredProcedure
                            '=-->Finact_SalePriceLstmstr
                            SpL_cmd.Parameters.AddWithValue("@splSaveStatus", Xcntr)
                            SpL_cmd.Parameters.AddWithValue("@splname", Trim(Me.txtLstName.Text))
                            SpL_cmd.Parameters.AddWithValue("@splefctdt", (Me.dtpEdt.Value.Date))
                            SpL_cmd.Parameters.AddWithValue("@splefcttodt", (Me.DtpUpTodt.Value.Date))
                            SpL_cmd.Parameters.AddWithValue("@spladusr", Current_UsrId)
                            SpL_cmd.Parameters.AddWithValue("@splType", "Exclusive")
                            SpL_cmd.Parameters.AddWithValue("@spladdt", Now)
                            SpL_cmd.Parameters.AddWithValue("@Clditmid", Me.DgExclusive.Rows(Xcntr).Cells(1).Value)
                            SpL_cmd.Parameters.AddWithValue("@splcld_MstrPack", Me.DgExclusive.Rows(Xcntr).Cells(6).Value)
                            SpL_cmd.Parameters.AddWithValue("@Cldrate", Me.DgExclusive.Rows(Xcntr).Cells(7).Value)
                            SpL_cmd.ExecuteNonQuery()
                            xOk += 1
                        End If

                    Next
                    If xOk > 0 Then
                        MsgBox("Current Record(s) has been successfully saved", MsgBoxStyle.Information, "Sale Price List Saved!!!")
                        Fill_Combobox("spl_id", "spl_name", "Finact_salepricelstmstr", "SPl_DELSTATUS", CInt(1), Me.CmbxPriclst)
                        SetFormAfterSave()
                        Me.txtLstName.Focus()
                        Me.txtLstName.Text = ""
                    Else
                        MsgBox("Invalid input!!", MsgBoxStyle.Critical, "No Record Found To Save!!!")
                        Me.txtLstName.Focus()
                        Me.txtLstName.SelectAll()
                    End If
                End If
            End If

        Catch ex As SqlException
            If ex.Number = 2627 Then
                MsgBox("This Sale Price List Name is already existed", MsgBoxStyle.Information, "Duplicate not allowed!!!")
                Me.txtLstName.Focus()
                Me.txtLstName.SelectAll()
            Else
                MsgBox(ex.Message)
            End If
        Finally
            If Me.DgPRice.Rows.Count > 0 Or Me.DgExclusive.Rows.Count > 0 Then
                SpL_cmd.Dispose()
            End If
        End Try
    End Sub
    Private Function FetchMaxId(ByVal Spl_name As String) As Integer
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            SpL_cmd = New SqlCommand("select spl_id from Finact_SalePriceLstMstr where spl_name=@name", FinActConn1)
            SpL_cmd.Parameters.AddWithValue("@name", Trim(Spl_name))
            SpL_Rdr = SpL_cmd.ExecuteReader
            SpL_Rdr.Read()
            If SpL_Rdr.HasRows = True Then
                Return SpL_Rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SpL_Rdr.Close()
            SpL_cmd.Dispose()
        End Try

    End Function
    Private Sub Update_SpLMasterChild()
        Try
            Dim Xcntr As Integer

            If Me.DgPRice.Rows.Count > 0 Then
                For Xcntr = 0 To Me.DgPRice.Rows.Count - 1
                    If FinActConn.State Then FinActConn.Close()
                    FinActConn.Open()
                    SpL_cmd = New SqlCommand("finact_salepricelstmstr_update", FinActConn)
                    SpL_cmd.CommandType = CommandType.StoredProcedure
                    '=-->Finact_SalePriceLstmstr
                    SpL_cmd.Parameters.AddWithValue("@splSaveStatus", Xcntr)
                    SpL_cmd.Parameters.AddWithValue("@splefctdt", (Me.dtpEdt.Value.Date))
                    SpL_cmd.Parameters.AddWithValue("@splefcttodt", (Me.DtpUpTodt.Value.Date))
                    SpL_cmd.Parameters.AddWithValue("@spledtusr", Current_UsrId)
                    SpL_cmd.Parameters.AddWithValue("@spledtdt", Now)
                    SpL_cmd.Parameters.AddWithValue("@Mstrid", Me.CmbxPriclst.SelectedValue)
                    SpL_cmd.Parameters.AddWithValue("@Cldrate", Me.DgPRice.Rows(Xcntr).Cells(4).Value)
                    SpL_cmd.Parameters.AddWithValue("@Clditmid", Me.DgPRice.Rows(Xcntr).Cells(5).Value)
                    SpL_cmd.ExecuteNonQuery()
                Next
                MsgBox("Current Record(s) has been successfully update", MsgBoxStyle.Information, "Sale Price List Saved!!!")
                SetFormAfterSave()
                Me.txtLstName.Focus()
                Me.txtLstName.Text = ""
            Else
                MsgBox("Invalid input!!", MsgBoxStyle.Critical, "No Record Found To update!!!")
                Me.txtLstName.Focus()
                Me.txtLstName.SelectAll()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Me.DgPRice.Rows.Count > 0 Or Me.DgExclusive.Rows.Count > 0 Then
                SpL_cmd.Dispose()
            End If
        End Try
    End Sub
    Private Sub Btncncel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btncncel.Click
        Try
            Me.Width = 338

            Me.Top = 0
            Me.Left = 100
            Me.Panel1.Enabled = True
            Me.CmbxPriclst.Visible = False
            Me.CmbxPriclst.Enabled = False
            Me.BtnShow.Enabled = False
            Me.BtnShow.Visible = False
            Me.Label3.Visible = False
            Me.Label5.Visible = False
            Me.lblEdate.Visible = False
            Me.LstVewSpL.Enabled = False
            Me.LstVewSpL.Visible = False
            Me.BtnSave.Text = "&Save"
            Me.Btnaply.Text = "&Find"
            Me.txtLstName.Text = ""
            Me.Txtremks.Text = ""
            Me.ToolStripMenuItem4.Enabled = False
            Me.DeleteToolStripMenuItem.Enabled = False
            If Me.RbExclusive.Checked = True Then
                Me.DgExclusive.Enabled = False
                Me.DgExclusive.Visible = False
            Else
                Me.DgPRice.Enabled = False
                Me.DgPRice.Visible = False
                Me.DgPRice.Columns.Clear()
                Me.DgPRice.Rows.Clear()
                Me.LstVewSpL.Items.Clear()
            End If
            
            Me.txtLstName.Focus()
            Me.txtLstName.SelectAll()
            Me.RbNormal.Checked = True

        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetFormAfterSave()
        Try
            Me.Width = 338
            Me.DgPRice.Enabled = False
            Me.Top = 0
            Me.Left = 100
            Me.Panel1.Enabled = True
            Me.CmbxPriclst.Visible = False
            Me.CmbxPriclst.Enabled = False
            Me.BtnShow.Enabled = False
            Me.BtnShow.Visible = False
            Me.Label3.Visible = False
            Me.Label5.Visible = False
            Me.lblEdate.Visible = False
            Me.LstVewSpL.Enabled = False
            Me.LstVewSpL.Visible = False
            Me.BtnSave.Text = "&Save"
            Me.Btnaply.Text = "&Find"
            Me.txtLstName.Text = ""
            Me.Txtremks.Text = ""
            Me.DgPRice.Columns.Clear()
            Me.DgPRice.Rows.Clear()
            Me.LstVewSpL.Items.Clear()
            Me.txtLstName.Focus()
            Me.txtLstName.SelectAll()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtLstName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLstName.Leave
        Try
            If Trim(Me.txtLstName.Text) = "" Then
                Me.BackColor = Color.Cyan
                Me.txtLstName.Focus()
            Else
                Me.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPriclst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPriclst.GotFocus
        Try
            Me.LstVewSpL.Items.Clear()
            If Me.RbExclusive.Checked = True Then
                Fill_Combobox_where_Not_cond("spl_id", "spl_name", "Spl_type", "Finact_salepricelstmstr", "Normal", Me.CmbxPriclst, "spl_delstatus", CInt(1))
            ElseIf Me.RbNormal.Checked = True Then
                Fill_Combobox_where_Not_cond("spl_id", "spl_name", "Spl_type", "Finact_salepricelstmstr", "Exclusive", Me.CmbxPriclst, "spl_delstatus", CInt(1))
            End If

            If Me.CmbxPriclst.Items.Count > 0 Then
                If Me.CmbxPriclst.SelectedIndex = -1 Then
                    Me.CmbxPriclst.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnaply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnaply.Click
        Try
            
            If Trim(Me.Btnaply.Text) = "&Find" Then
                If Me.RbExclusive.Checked = True Then
                    Fill_Combobox_where_Not_cond("spl_id", "spl_name", "Spl_type", "Finact_salepricelstmstr", "Normal", Me.CmbxPriclst, "spl_delstatus", CInt(1))
                ElseIf Me.RbNormal.Checked = True Then
                    Fill_Combobox_where_Not_cond("spl_id", "spl_name", "Spl_type", "Finact_salepricelstmstr", "Exclusive", Me.CmbxPriclst, "spl_delstatus", CInt(1))
                End If
                If Me.CmbxPriclst.Items.Count > 0 Then
                    Me.Width = 338
                    Me.DgPRice.Enabled = False
                    Me.Top = 0
                    Me.Left = 100
                    Me.Panel1.Enabled = False
                    Me.CmbxPriclst.Visible = True
                    Me.CmbxPriclst.Enabled = True
                    Me.BtnShow.Enabled = True
                    Me.BtnShow.Visible = True
                    Me.Label3.Visible = True
                    Me.Label5.Visible = True
                    Me.lblEdate.Visible = True
                    Me.LstVewSpL.Enabled = True
                    Me.LstVewSpL.Visible = True
                    Me.DtpUpTodt.Enabled = False
                    Me.dtpEdt.Enabled = False
                    If Me.RbExclusive.Checked = True Then
                        Me.lblTdate.Visible = True
                        Me.Label7.Visible = True
                    Else
                        Me.lblTdate.Visible = False
                        Me.Label7.Visible = False
                    End If

                    Me.CmbxPriclst.Focus()
                    Me.BtnSave.Text = "&New"
                    Me.Btnaply.Text = "&Apply"
                Else
                    MsgBox("No Sale Price List Found", MsgBoxStyle.Critical, "Make a price list first")
                    Me.Panel1.Enabled = True
                    Me.txtLstName.Focus()
                    Me.BtnSave.Text = "&Save"
                    Me.Btnaply.Text = "&Find"
                End If
            ElseIf Trim(Me.Btnaply.Text) = "&Apply" Then
                If Me.LstVewSpL.CheckedItems.Count > 0 Then
                    AtachList_Applied()
                    Btncncel_Click(sender, e)
                Else
                    MsgBox("Atleast one item should be cheked true", MsgBoxStyle.Information, "Minimum One Item Required!!!!")
                    Me.LstVewSpL.Focus()
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateGridColumns_SalePriceList_AlreadySaved_Select()
        Try
            Dim DgItms As DataGridView
            DgItms = Me.DgPRice
            DgItms.Columns.Clear()
            SpL_cmd = New SqlCommand("Finact_Itemmaster_SpL_AlreadySaved_Select", FinActConn)
            SpL_cmd.CommandType = CommandType.StoredProcedure
            SpL_cmd.Parameters.AddWithValue("@SplMstrid", Me.CmbxPriclst.SelectedValue)

            SpL_Adptr = New Data.SqlClient.SqlDataAdapter(SpL_cmd)
            SpL_Dset = New Data.DataSet()
            SpL_Adptr.Fill(SpL_Dset, "finactitmmstr")
            DgItms.DataSource = SpL_Dset.Tables("finactitmmstr")

            'DgItms.Columns.Add("ColItemid", "Item Code")
            DgItms.Columns(0).HeaderText = "Item Code"
            DgItms.Columns(0).Name = "ColItemid"
            DgItms.Columns(0).Width = 120
            DgItms.Columns(0).ReadOnly = True
            DgItms.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            'DgItms.Columns.Add("ColDescription", "Item Name")
            DgItms.Columns(1).HeaderText = "Description"
            DgItms.Columns(1).Name = "ColDescription"
            DgItms.Columns(1).Width = 320
            DgItms.Columns(1).ReadOnly = True

            'DgItms.Columns.Add("ColUnittype", "Unit Type")
            DgItms.Columns(2).HeaderText = "Unit Type"
            DgItms.Columns(2).Name = "ColUnittype"
            DgItms.Columns(2).Width = 60
            DgItms.Columns(2).ReadOnly = True
            DgItms.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


            ' DgItms.Columns.Add("Mpack", "Master Packing")
            DgItms.Columns(3).HeaderText = "Master Packing"
            DgItms.Columns(3).Name = "Mpack"
            DgItms.Columns(3).Width = 60
            DgItms.Columns(3).ReadOnly = True
            DgItms.Columns(3).DefaultCellStyle.Format = "N0"
            DgItms.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'DgItms.Columns.Add("colCost", "Rate")
            DgItms.Columns(4).HeaderText = "Rate"
            DgItms.Columns(4).Name = "colCost"
            DgItms.Columns(4).Width = 100
            DgItms.Columns(4).DefaultCellStyle.Format = "N2"
            DgItms.Columns(4).ReadOnly = True
            DgItms.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DgItms.Columns(5).HeaderText = "Item id"
            DgItms.Columns(5).Name = "ColItemid"
            DgItms.Columns(5).Width = 0
            DgItms.Columns(5).Visible = False
            DgItms.Columns(5).ReadOnly = True
            DgItms.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            
            DgItms.MultiSelect = False
            DgItms.AllowUserToDeleteRows = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SpL_cmd.Dispose()
            SpL_Adptr.Dispose()
            'Me.DgPRice.Focus()
        End Try

    End Sub

    Private Sub CmbxPriclst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxPriclst.SelectedIndexChanged
        Try
            Me.ToolStripMenuItem4.Text = "Edit"
            Me.dtpEdt.Enabled = False
            Me.DtpUpTodt.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub EfctDate_Select()
        Try
            SpL_cmd1 = New SqlCommand("Finact_salepricelstMstr_SelectEfecteddate", FinActConn1)
            SpL_cmd1.CommandType = CommandType.StoredProcedure
            SpL_cmd1.Parameters.AddWithValue("@splmastrid", Me.CmbxPriclst.SelectedValue)
            SpL_Rdr1 = SpL_cmd1.ExecuteReader
            While SpL_Rdr1.Read
                If SpL_Rdr1.IsDBNull(0) = False Then
                    Me.lblEdate.Text = Format(SpL_Rdr1(1), "dd/MM/yyyy")
                    Me.lblTdate.Text = Format(SpL_Rdr1(2), "dd/MM/yyyy")
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SpL_cmd1.Dispose()
            SpL_Rdr1.Close()

        End Try
    End Sub

    Private Sub Fill_SplListvew(ByVal xType As Integer, ByVal xfldname As String, ByVal xVal As Integer)
        Try
            Me.LstVewSpL.Items.Clear()
            If Cl_Kbl = True Then
                SpL_cmd = New SqlCommand("finact_Splrmaster_KBLTYPE_select_for_PriceList", FinActConn)
                SpL_cmd.CommandType = CommandType.StoredProcedure
                SpL_cmd.Parameters.AddWithValue("@GRUPfld", xfldname.Trim)
                SpL_cmd.Parameters.AddWithValue("@xtype", CInt(xType))
                SpL_cmd.Parameters.AddWithValue("@GrupId", CInt(xVal))
            Else
                SpL_cmd = New SqlCommand("finact_Splrmaster_select_for_PriceList", FinActConn)
                SpL_cmd.CommandType = CommandType.StoredProcedure
            End If

            SpL_cmd.Parameters.AddWithValue("@splmasterid", Me.CmbxPriclst.SelectedValue)
            SpL_Rdr = SpL_cmd.ExecuteReader
            While SpL_Rdr.Read
                If SpL_Rdr.IsDBNull(0) = False Then
                    Dim SplLst As New ListViewItem
                    SplLst.Text = SpL_Rdr(1)
                    SplLst.SubItems.Add(Trim(SpL_Rdr(2)))
                    SplLst.SubItems.Add(Trim(SpL_Rdr(3)))
                    SplLst.SubItems.Add(Trim(SpL_Rdr(4)))
                    SplLst.SubItems.Add(Trim(SpL_Rdr(0)))
                    Me.LstVewSpL.Items.Add(SplLst)
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SpL_cmd.Dispose()
            SpL_Rdr.Close()
        End Try
    End Sub

    Private Sub AtachList_Applied()
        Try
            Dim Xal As Integer = 0
            For Xal = 0 To Me.LstVewSpL.Items.Count - 1
                If Me.LstVewSpL.Items(Xal).Checked = True Then
                    SpL_cmd = New SqlCommand("Finact_Atach_SpL_Insert", FinActConn)
                    SpL_cmd.CommandType = CommandType.StoredProcedure
                    SpL_cmd.Parameters.AddWithValue("@AlSplmstrid", Me.CmbxPriclst.SelectedValue)
                    SpL_cmd.Parameters.AddWithValue("@AlSplrid", Me.LstVewSpL.Items(Xal).SubItems(4).Text)
                    SpL_cmd.Parameters.AddWithValue("@Aladusrid", Current_UsrId)
                    SpL_cmd.Parameters.AddWithValue("@Aladdt", Now)
                    SpL_cmd.Parameters.AddWithValue("@AlStatus", 1)
                    SpL_cmd.ExecuteNonQuery()
                End If
            Next
                    MsgBox("Current Sale Price List has been successfully Attached to the selected customer(s)", MsgBoxStyle.Information, "SPL Attached!!!")
            Me.Btnaply.Text = "&Find"
                    AlowReset = True

        Catch ex As Exception
            AlowReset = False
            MsgBox(ex.Message)
        Finally
            If Me.LstVewSpL.CheckedItems.Count > 0 Then
                SpL_cmd.Dispose()
            End If

        End Try
    End Sub

    Private Sub CmbxPriclst_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPriclst.Leave
        Try
            If Not Me.Width > 400 Then
                If Me.CmbxPriclst.Items.Count > 0 Then
                    Me.Width = 1065
                    Me.DgPRice.Height = 257
                    Me.DgPRice.Enabled = True
                    Me.LstVewSpL.Height = 256
                    Me.LstVewSpL.Location = New System.Drawing.Point(2, Me.DgPRice.Height + 14)
                    EfctDate_Select()
                    Fill_SplListvew(1, "", 0)
                    CreateGridColumns_SalePriceList_AlreadySaved_Select()
                    Me.DgExclusive.Enabled = False
                    Me.DgExclusive.Visible = False
                    Me.DgPRice.Enabled = True
                    Me.DgPRice.Visible = True
                    Me.ToolStripMenuItem4.Enabled = True
                    Me.DeleteToolStripMenuItem.Enabled = True
                    Me.CmbxPriclst.Enabled = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If Me.LstVewSpL.Items.Count > 0 Then
                Dim Xck As Integer
                For Xck = 0 To Me.LstVewSpL.Items.Count - 1
                    Me.LstVewSpL.Items(Xck).Checked = True
                Next
            Else
                MsgBox("System could not found any item to Check", MsgBoxStyle.Critical, "No Data found!!!!")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            If Me.LstVewSpL.Items.Count > 0 Then
                Dim Xck As Integer
                For Xck = 0 To Me.LstVewSpL.Items.Count - 1
                    Me.LstVewSpL.SelectedItems(Xck).Checked = True
                Next
            Else
                MsgBox("System could not found any item to Check", MsgBoxStyle.Critical, "No Data found!!!!")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            If Me.LstVewSpL.Items.Count > 0 Then 'And Me.LstVewSpL.SelectedItems.Count > 0 Then
                Dim Xck As Integer
                For Xck = 0 To Me.LstVewSpL.Items.Count - 1
                    Me.LstVewSpL.Items(Xck).Checked = False
                Next
            Else
                MsgBox("System could not found any selected item to Check", MsgBoxStyle.Critical, "No Data found!!!!")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpEdt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEdt.ValueChanged
        Try
            Me.DtpUpTodt.MinDate = Me.dtpEdt.Value
        Catch ex As Exception

        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnok.Click

        Try
            If Len(Me.txtLstName.Text.Trim) = 0 Then
                Me.txtLstName.Focus()
                Exit Sub
            End If

            Me.Top = 0
            Me.Width = 1065
            Me.Panel1.Enabled = False
            If Me.RbExclusive.Checked = True Then
                Me.DgExclusive.Top = 2
                Me.DgExclusive.Height = 526
                Me.DgExclusive.Visible = True
                Me.DgExclusive.Enabled = True
                Me.DgPRice.Enabled = False
                Me.DgPRice.Visible = False
                Fill_DgExlusive()
            Else
                Me.DgExclusive.Enabled = False
                Me.DgExclusive.Visible = False
                Me.DgPRice.Enabled = True
                Me.DgPRice.Visible = True
                Me.DgPRice.Height = 526
                CreateGridColumns_SalePriceList_Select()
                Me.DgPRice.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Try
            CmbxPriclst_Leave(sender, e)
           
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOverWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOverWrite.Click
        Try
            OverWriteMstrPriceLst(Me.CmbxPriclst.SelectedValue)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub OverWriteMstrPriceLst(ByVal lstid As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            SpL_cmd = New SqlCommand("finact_SalePriceList_OvrWriteWith_NewOne", FinActConn)
            SpL_cmd.CommandType = CommandType.StoredProcedure
            SpL_cmd.Parameters.AddWithValue("@SpMstrid", lstid)
            SpL_cmd.ExecuteNonQuery()
            SpL_cmd.Dispose()
            MsgBox("Earlier Master Price List Has Been Successfully Replaced With Current Price List", MsgBoxStyle.Information, "Replaced!!!")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RbExclusive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbExclusive.CheckedChanged, RbNormal.CheckedChanged
        Try
            If Me.RbExclusive.Checked = True Then
                Me.Label6.Visible = True
                Me.DtpUpTodt.Visible = True
                Me.Panel1.Height = 145
                Me.Btnok.Top = 187
            Else
                Me.Label6.Visible = False
                Me.DtpUpTodt.Visible = False
                Me.Panel1.Height = 145
                Me.Btnok.Top = 150
            End If
            
            Me.Width = 338
            Me.DgExclusive.Rows.Clear()
        Catch ex As Exception
        Finally
            Me.txtLstName.Focus()
            Me.txtLstName.SelectAll()
        End Try

    End Sub

    Private Sub DgExclusive_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgExclusive.CellEndEdit
        Try
            If e.ColumnIndex = 7 Then
                Me.DgExclusive.CurrentRow.Cells(e.ColumnIndex).Value = FormatNumber(Me.DgExclusive.CurrentRow.Cells(e.ColumnIndex).Value, 2, , TriState.False)
                Me.DgExclusive.CurrentRow.Cells(e.ColumnIndex).ErrorText = ""
            End If
            If e.ColumnIndex = 6 Then
                Me.DgExclusive.CurrentRow.Cells(e.ColumnIndex).Value = FormatNumber(Me.DgExclusive.CurrentRow.Cells(e.ColumnIndex).Value, 0, , TriState.False)
                Me.DgExclusive.CurrentRow.Cells(e.ColumnIndex).ErrorText = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgExclusive_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgExclusive.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgExclusive.Rows.Count '- 1
            If Cr_Row <> Me.DgExclusive.CurrentRow.Index Then
                If e.ColumnIndex = 7 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then

                        Me.DgExclusive.CurrentRow.Cells(7).ErrorText = "Invalid Input! Only Numbers are allowed"
                        MsgBox("Invalid Input", MsgBoxStyle.Critical, "Number only!!!")
                        e.Cancel = True
                    Else

                        Me.DgExclusive.CurrentRow.Cells(7).ErrorText = ""
                        e.Cancel = False
                    End If
                End If
                If e.ColumnIndex = 6 Then
                    If Not Integer.TryParse(e.FormattedValue, Nothing) Then

                        Me.DgExclusive.CurrentRow.Cells(6).ErrorText = "Invalid Input! Only Numbers are allowed"
                        MsgBox("Invalid Input", MsgBoxStyle.Critical, "Number only!!!")
                        e.Cancel = True
                    Else

                        Me.DgExclusive.CurrentRow.Cells(6).ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

   

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If Del_sp_list(Me.CmbxPriclst.SelectedValue) > 0 Then
                MsgBox("System could not Delete current record as it has relations with one or more records", MsgBoxStyle.Critical, "Denied Delete!!!")
            Else
                If MessageBox.Show("Are you sure to delete current record?", "Deleting......", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                Else
                    Try
                        If FinActConn.State Then FinActConn.Close()
                        FinActConn.Open()
                        SpL_cmd = New SqlCommand("Finact_salePirceList_Delete", FinActConn)
                        SpL_cmd.CommandType = CommandType.StoredProcedure
                        SpL_cmd.Parameters.AddWithValue("@xSpl_id", Me.CmbxPriclst.SelectedValue)
                        SpL_cmd.ExecuteNonQuery()
                        MsgBox("Current record has been successfully deleted.", MsgBoxStyle.Information, "Deleted!!!")
                        SetFormAfterSave()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        SpL_cmd.Dispose()
                    End Try
                End If

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Function Del_sp_list(ByVal Splid As Integer) As Integer
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            SpL_cmd = New SqlCommand("Finact_SalePriceList_CheckExist", FinActConn)
            SpL_cmd.CommandType = CommandType.StoredProcedure
            SpL_cmd.Parameters.AddWithValue("@Spl_Id", Splid)
            SpL_Rdr = SpL_cmd.ExecuteReader
            While SpL_Rdr.Read
                If SpL_Rdr.IsDBNull(0) = False Then
                    Return SpL_Rdr(0)
                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SpL_cmd.Dispose()
            SpL_Rdr.Close()

        End Try

    End Function

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Try
            If Del_sp_list(Me.CmbxPriclst.SelectedValue) > 0 Then
                MsgBox("Current sale price list has relation with one or more records." & Chr(13) & "It is strongly suggested to not alter this sale price list.", MsgBoxStyle.Critical, "Alter!!!")
                Exit Sub
            Else
                If Me.ToolStripMenuItem4.Text = "Edit" Then
                    SetDgWritable = True
                    Me.DtpUpTodt.Enabled = True
                    Me.dtpEdt.Enabled = True
                    Me.dtpEdt.Value = Me.lblEdate.Text
                    Me.DtpUpTodt.Value = Me.lblTdate.Text
                    Me.ToolStripMenuItem4.Text = "Update"
                    Me.Btnok.Enabled = False
                ElseIf Me.ToolStripMenuItem4.Text = "Update" Then
                    If MessageBox.Show("Are you sure to Update current record?", "updating......", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Return
                    Else
                        Try
                            Update_SpLMasterChild()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                    SetDgWritable = False
                    Me.ToolStripMenuItem4.Text = "Edit"
                    Me.DtpUpTodt.Enabled = False
                    Me.dtpEdt.Enabled = False
                    Me.Btnok.Enabled = True
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DtpUpTodt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpUpTodt.ValueChanged

    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxPriclst.KeyDown, dtpEdt.KeyDown _
    , DtpUpTodt.KeyDown, RbExclusive.KeyDown, RbNormal.KeyDown, txtLstName.KeyDown, Txtremks.KeyDown, ChkGrpAll.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxUndrGrup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxUndrGrup.GotFocus
        Try
            Me.CmbxUndrGrup.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxUndrGrup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxUndrGrup.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxUndrGrup_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

  
    Private Sub CmbxUndrGrup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxUndrGrup.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxUndrGrup) = True Then
                Me.dtpEdt.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkGrpAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGrpAll.CheckedChanged
        Try
            If Me.ChkGrpAll.CheckState = CheckState.Checked Then
                Me.CmbxUndrGrup.Enabled = False
                Me.CmbxUndrGrup.SelectedIndex = -1
            Else
                Me.CmbxUndrGrup.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxType.GotFocus
        Try
            Me.CmbxType.DroppedDown = True
            Me.CmbxFltrValue.DataSource = Nothing
            Fill_SplListvew(1, " ", CInt(0))

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
            If CheckBlank_IndxCmbx(Me.CmbxType) = True Then
                Select Case Me.CmbxType.SelectedIndex
                    Case 0
                        xFillCmbxSplrNameIdFromLstVew(Me.CmbxFltrValue)
                    Case 1
                        Fill_Combobox_Dynamiclly_Where_LikeCond1(Me.CmbxFltrValue, "FinActgrupname", "CogrpId", "Cogrupnam", "CogrupNam", "%SUNDRY%", "CoDelStatus", CInt(1))
                    Case 2
                        Fill_Combobox_where_cond("Cscid", "CscCtyName", "CscType", "FinactCscMstr", "CSCDELSTATUS", CInt(1), "Outer", Me.CmbxFltrValue)
                End Select
                Me.CmbxFltrValue.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub BtnfltrExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnfltrExit.Click
        Try
            Me.PnlFilter.Enabled = False
            Me.PnlFilter.Visible = False
            Me.PnlFilter.Size = New Point(317, 97)
            Me.LstVewSpL.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterToolStripMenuItem.Click
        Try
            If Me.LstVewSpL.Items.Count = 0 Then Exit Sub
            Me.PnlFilter.Enabled = True
            Me.PnlFilter.Visible = True
            Me.PnlFilter.Location = New Point(5, 300)
            Me.PnlFilter.Size = New Point(465, 97)
            Me.CmbxType.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxType.SelectedIndexChanged

    End Sub
    Private Sub xFillCmbxSplrNameIdFromLstVew(ByVal xCmbx As ComboBox)
        Try
            Dim Dtbl As DataTable
            Dim Dtblrow As DataRow
            Dtbl = New DataTable("SplrIdName")
            Dtbl.Columns.Add("xValue")
            Dtbl.Columns.Add("xDisplay")
            Dtbl.Columns(0).Unique = True
            For Each xSelItm As ListViewItem In Me.LstVewSpL.Items
                Dtblrow = Dtbl.NewRow
                Dtblrow(0) = CInt(xSelItm.SubItems(4).Text)
                Dtblrow(1) = Trim(xSelItm.SubItems(0).Text)
                Dtbl.Rows.Add(Dtblrow)

            Next
            xCmbx.DataSource = Dtbl
            xCmbx.ValueMember = "xValue"
            xCmbx.DisplayMember = "xDisplay"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
    Private Sub CmbxFltrValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxFltrValue.GotFocus
        Try
            Me.CmbxFltrValue.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFltrValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxFltrValue.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxFltrValue_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFltrValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxFltrValue.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxFltrValue) = True Then
                Me.BtnFltrOK.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnFltrOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFltrOK.Click
        Try
            If Me.CmbxType.SelectedIndex = -1 Then
                Me.CmbxType.Focus()
                Exit Sub
            End If
            If Me.CmbxFltrValue.SelectedIndex = -1 Then
                Me.CmbxFltrValue.Focus()
                Exit Sub
            End If

            Select Case Me.CmbxType.SelectedIndex
                Case 0
                    Fill_SplListvew(2, "Splrid", CInt(Me.CmbxFltrValue.SelectedValue))
                Case 1
                    Fill_SplListvew(2, "SplrUndrGrup", CInt(Me.CmbxFltrValue.SelectedValue))
                Case 2
                    Fill_SplListvew(2, "CscId", CInt(Me.CmbxFltrValue.SelectedValue))
            End Select
            BtnfltrExit_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub
End Class
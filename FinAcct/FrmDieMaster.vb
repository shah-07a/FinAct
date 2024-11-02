
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO


Public Class FrmDieMaster
    Dim Die_com As SqlCommand
    Dim delstcom As SqlCommand
    Dim Die_sql As inv_sql
    Dim Die_sql1 As inv_sql
    Dim Die_sql2 As New inv_sql
    Dim DieRow As DataGridViewRow
    Dim DieCel As DataGridViewTextBoxCell
    Dim DieCom As DataGridViewComboBoxCell
    Dim ItmBtn As DataGridViewButtonCell
    Dim Die_Rdr As SqlDataReader
    Dim Die_Adptr As SqlDataAdapter
    Dim Die_Ds As DataSet
    Dim DieIndx As Integer
   

    Private Sub FrmDieMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Dim cond As String = "Inner"
            Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", CmbxDieLoc, cond, "CSCDELSTATUS", CInt(1))
            Sel_Item4Die()
            Sel_Vendor4Die()
            Me.DtpDie.MaxDate = Now.Date
            Me.DtpDie.MinDate = Now.Date
            Die_sql = New inv_sql
            Die_sql1 = New inv_sql
            Me.TxtDieCode.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtDieCode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDieCode.GotFocus
        Try
            If Me.SplitContainer1.Panel1.Enabled = False Then Me.SplitContainer1.Panel1.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxDieLoc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDieLoc.GotFocus
        Try
            If FrmShow_flag(13) = True Then
                Dim cond As String = "Inner"
                Select_2rec_where("cscid", "cscctyname", "csctype", "finactcscmstr", CmbxDieLoc, cond, "CSCDELSTATUS", CInt(1))
                Dim Indxht As Integer = CmbxDieLoc.FindStringExact(IntHtCmMm(13), 0)
                CmbxDieLoc.SelectedIndex = Indxht
            Else
                If CmbxDieLoc.Items.Count > 0 And CmbxDieLoc.SelectedIndex = -1 Then
                    CmbxDieLoc.SelectedIndex = 0
                End If
                If Trim(CmbxDieLoc.Text) <> "" Then
                    fetchRecFromlocation()
                End If

            End If
            Me.CmbxDieLoc.DroppedDown = True
            Me.Panel8.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxDieLoc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDieLoc.Leave
        Try
            If FrmShow_flag(13) = True Then
                FrmShow_flag(13) = False

            End If
            If Trim(CmbxDieLoc.Text) = "" Then
                CmbxDieLoc.Text = "<None>"
            End If
            Me.Panel8.Visible = False
            'txtuntwt.Focus()
            'txtuntwt.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxDieLoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxDieLoc.SelectedIndexChanged
        Try
            If Trim(CmbxDieLoc.Text) <> "" Then
                fetchRecFromlocation()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub fetchRecFromlocation()
        Try
            Dim Cname As String = Trim(CmbxDieLoc.Text)
            Die_com = New SqlCommand("Select * from finactcscmstr where cscctyname='" & (Cname) & "' and csctype='Inner' order by cscctyname ", FinActConn)

            Die_Rdr = Die_com.ExecuteReader
            Dim x As Integer
            x = 0
            While Die_Rdr.Read()
                If Die_Rdr.HasRows = True Then
                    lblname.Text = Die_Rdr("cscctyname")
                    lblloc.Text = Die_Rdr("cscid")
                    lblMainp.Text = Die_Rdr("cscstatename")
                    lblsubp.Text = Die_Rdr("csccontry")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        Finally
            Die_Rdr.Close()
            Die_com = Nothing

        End Try
    End Sub

    Private Sub BtnDLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDLoc.Click
        Try
            Dim frmiL As New FrmInLocat
            frmiL.ShowInTaskbar = False
            FrmShow_flag(13) = True
            frmiL.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDLoc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDLoc.GotFocus
        Try
            If FrmShow_flag(13) = True Then
                CmbxDieLoc.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDieSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDieSave.Click
        If BtnDieSave.Text = "&Save" Then
            chkblan_val()
            If DieIndx <> 0 Then
                DieIndx = 0
                Exit Sub
            Else
                Die_insert()
                TxtDieCode.Focus()
                TxtDieCode.SelectAll()
            End If
        ElseIf BtnDieSave.Text = "&Update" Then
            If validate_input() = True Then
                Exit Sub
            End If
            If validate_ChekError() = True Then
                MsgBox("Error!! System could not update current record", MsgBoxStyle.Critical, "Error!!!")
                Exit Sub
            End If
            Die_edit()
        End If
    End Sub
    Private Sub Die_edit()

        Dim b As Integer = DieDg.SelectedRows.Count
        Try
            Dim i As Integer = 0
            Dim pv11(2), pn11(2) As String
            pn11(0) = "@ta"
            pn11(1) = "@id"
            pn11(2) = "@idval"
            If b > 0 Then
                If Not Me.DieDg.CurrentRow.Cells(0).Value > 0 Then
                    MsgBox("Invalid input! System could not found any thing to update", MsgBoxStyle.Critical, "Empty Row!!!")
                    Exit Sub
                End If
                For i = 0 To DieDg.SelectedRows.Count - 1
                    Die_com = New SqlCommand("Finact_DieMstr_Update", FinActConn)
                    Die_com.CommandType = CommandType.StoredProcedure
                    Dim cod As String = Me.DieDg.SelectedRows(i).Cells(0).Value
                    Die_com.Parameters.AddWithValue("@dieid", Me.DieDg.SelectedRows(i).Cells(0).Value)

                    Die_com.Parameters.AddWithValue("@dname", Me.DieDg.SelectedRows(i).Cells(2).Value)

                    '===For fetching Location id

                    pv11(0) = "finactcscmstr "
                    pv11(1) = "cscctyname"
                    pv11(2) = Trim(Me.DieDg.SelectedRows(i).Cells(3).Value)

                    Die_sql1.get_data("select_where_like", pn11, pv11, "Locid")
                    Die_com.Parameters.AddWithValue("@dloc", Die_sql1.ds.Tables("Locid").Rows(0).ItemArray(0))

                    '===End of fetching Location id

                    Die_com.Parameters.AddWithValue("@dcap", Me.DieDg.SelectedRows(i).Cells(4).Value)
                    Die_com.Parameters.AddWithValue("@dmax", Me.DieDg.SelectedRows(i).Cells(5).Value)
                    Die_com.Parameters.AddWithValue("@dpolish", Me.DieDg.SelectedRows(i).Cells(6).Value)

                    '===For fetching ITem  id
                    pv11(0) = "Finactitmmstr"
                    pv11(1) = "itmname"
                    pv11(2) = Me.DieDg.SelectedRows(i).Cells(7).Value
                    Die_sql1.get_data("select_where_like", pn11, pv11, "IName")
                    Die_com.Parameters.AddWithValue("@ditem", Die_sql1.ds.Tables("Iname").Rows(0).ItemArray(0))
                    '===End of fetching Item id

                    '===For fetching Vendor  id
                    pv11(0) = "Finactsplrmstr"
                    pv11(1) = "splrname"
                    pv11(2) = Me.DieDg.SelectedRows(i).Cells(8).Value
                    Die_sql1.get_data("select_where_like", pn11, pv11, "sName")
                    Die_com.Parameters.AddWithValue("@dmaker", Die_sql1.ds.Tables("sname").Rows(0).ItemArray(0))
                    '===End of fetching Vendor id

                    Die_com.Parameters.AddWithValue("@dedtusr", Current_UsrId)
                    Die_com.Parameters.AddWithValue("@dedtdt", Now)
                    Die_com.ExecuteNonQuery()
                Next
                MsgBox("Current record has been updated", MsgBoxStyle.Information, Me.Text & " " & "Item Updated ")
                Create_fill_DieDg()
            Else
                MsgBox("No record selected for updation.", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

        Catch ex As SqlException
            Dim a As Integer = ex.Number
            If ex.Number = 2627 Then
                MsgBox("Invalid input! system found a record exisited with same value, Try another value", MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            End If
        Finally
            If b > 0 Then
                Die_com.Dispose()
            End If

        End Try

    End Sub

    Private Sub Die_insert()
        Try
            Die_com = New SqlCommand("Finact_DieMstr_Insert", FinActConn)
            Die_com.CommandType = CommandType.StoredProcedure
            Die_com.Parameters.AddWithValue("@dcode", Trim(Me.TxtDieCode.Text))
            Die_com.Parameters.AddWithValue("@dname", Trim(Me.TxtDieName.Text))
            Die_com.Parameters.AddWithValue("@dloc", Me.CmbxDieLoc.SelectedValue)
            Die_com.Parameters.AddWithValue("@dcap", Me.NudDieCapcty.Value)
            Die_com.Parameters.AddWithValue("@dmax", Me.NudMaxProd.Value)
            Die_com.Parameters.AddWithValue("@dpolish", Me.NudDiePlosh.Value)
            Die_com.Parameters.AddWithValue("@ditem", Me.Cmbxitem.SelectedValue)
            Die_com.Parameters.AddWithValue("@dmaker", Me.CmbxDiemaker.SelectedValue)
            Die_com.Parameters.AddWithValue("@ddt", Me.DtpDie.Value.Date)
            Die_com.Parameters.AddWithValue("@dadusr", Current_UsrId)
            Die_com.Parameters.AddWithValue("@daddt", Now)
            Die_com.ExecuteNonQuery()
            MsgBox("Current Record Has Been Successfully Saved", MsgBoxStyle.Information, "Die Master!!! ")
            Me.TxtDieCode.Text = ""
            Me.TxtDieName.Text = ""
            Me.TxtDieCode.Focus()
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MsgBox("System found a record with the same value", MsgBoxStyle.Critical, "Duplicate not allowed!!!")
                Me.TxtDieCode.Focus()
                Me.TxtDieCode.SelectAll()
            Else
                MsgBox(ex.Message)
            End If

        Finally
            Die_com.Dispose()

        End Try

    End Sub
    Private Function validate_input() As Boolean
        Dim i, j As Integer
        For i = 0 To Me.DieDg.SelectedRows.Count - 1
            'Check item name that should not be blank/empty
            For j = i + 1 To Me.DieDg.Rows.Count - 1
                If Me.DieDg.Rows(i).Cells(2).Value = "" Then
                    Me.DieDg.Rows(i).Cells(2).ErrorText = "Empty not allowed"
                    Return True
                Else
                    Me.DieDg.Rows(i).Cells(2).ErrorText = ""
                    'Return False
                End If

            Next
        Next
        Return False
    End Function
    Private Function validate_ChekError() As Boolean
        Dim i, j As Integer
        For i = 0 To Me.DieDg.SelectedRows.Count - 1
            'Check item name that should not be blank/empty
            For j = i + 1 To Me.DieDg.Rows.Count - 1
                If Trim(Me.DieDg.Rows(i).Cells(j).ErrorText) <> "" Then
                    Return True
                End If

            Next
        Next
        Return False
    End Function
    Private Sub chkblan_val()
        With Me.CmbxDiemaker
            If .SelectedIndex = -1 Then
                .BackColor = Color.Cyan
                .Focus()
                DieIndx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Me.Cmbxitem
            If .SelectedIndex = -1 Then
                .BackColor = Color.Cyan
                .Focus()
                DieIndx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Me.CmbxDieLoc
            If .SelectedIndex = -1 Then
                .BackColor = Color.Cyan
                .Focus()
                DieIndx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Me.TxtDieCode
            If Trim(.Text) = "" Then
                .BackColor = Color.Cyan
                .Focus()
                DieIndx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Me.TxtDieName
            If Trim(.Text) = "" Then
                .BackColor = Color.Cyan
                .Focus()
                DieIndx += 1
            Else
                .BackColor = Color.White
            End If
        End With
    End Sub

    Private Sub Sel_Item4Die()
        Try
            Die_com = New SqlCommand("Finact_ItmMstr_SelectItmForDieMaster", FinActConn)
            Die_com.CommandType = CommandType.StoredProcedure
            Die_Adptr = New SqlDataAdapter(Die_com)
            Die_Ds = New DataSet(Die_com.CommandText)
            Die_Adptr.Fill(Die_Ds)
            Me.Cmbxitem.DataSource = Die_Ds.Tables(0)
            Me.Cmbxitem.ValueMember = "itmid"
            Me.Cmbxitem.DisplayMember = "itmname"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Die_com.Dispose()
            Die_Adptr.Dispose()

        End Try

    End Sub


    Private Sub Sel_Vendor4Die()
        Try
            Die_com = New SqlCommand("Finact_ItmMstr_SelectVendorForDieMaster", FinActConn)
            Die_com.CommandType = CommandType.StoredProcedure
            Die_Adptr = New SqlDataAdapter(Die_com)
            Die_Ds = New DataSet(Die_com.CommandText)
            Die_Adptr.Fill(Die_Ds)
            Me.CmbxDiemaker.DataSource = Die_Ds.Tables(0)
            Me.CmbxDieMaker.ValueMember = "splrid"
            Me.CmbxDiemaker.DisplayMember = "slprname"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Die_com.Dispose()
            Die_Adptr.Dispose()

        End Try

    End Sub
    
    Private Sub BtnDie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDie.Click

        Try
            If BtnDie.Text = "&Find" Then
                Me.TableLayoutPanel1.Enabled = False
                Me.TableLayoutPanel1.Visible = False
                Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 20
                Create_fill_DieDg()
                BtnDieSave.Text = "&Update"
                BtnDie.Text = "&Delete"
            Else


                If MessageBox.Show("Are you sure to delete?", "Deleting From Die Master", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                Try
                    If DieDg.SelectedRows.Count > 0 Then
                        Dim i As Integer = 0

                        For i = 0 To DieDg.SelectedRows.Count - 1
                            Die_com = New SqlCommand("Delete from finact_Diemstr where dieid=@itmid", FinActConn)
                            Die_com.Parameters.AddWithValue("@itmid", Me.DieDg.SelectedRows(i).Cells(0).Value)
                            Die_com.ExecuteNonQuery()
                        Next
                        MsgBox("Current record has been successfully  deleted ", MsgBoxStyle.Information)
                        Create_fill_DieDg()
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
                    If DieDg.SelectedRows.Count > 0 Then
                        Die_com.Dispose()
                    End If
                End Try
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally


        End Try
    End Sub
    Private Sub Create_fill_DieDg()
        Try
            DieDg.Columns.Clear()
            DieDg.Rows.Clear()
            Me.Left = 0
            Me.Top = 0
            DieDg.Size = New Drawing.Size(Me.Width - Me.SplitContainer1.SplitterDistance - 10, Me.Height - (Me.Panel4.Height + 50))
            DieDg.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DieDg.ForeColor = Color.Navy
            DieDg.Columns.Add("iid", "Id") '0
            DieDg.Columns.Add("icode", "Code") '1
            DieDg.Columns.Add("in", "Name Of The Die") '2
            DieDg.Columns(1).DefaultCellStyle.BackColor = Color.LightGray
            DieDg.Columns.Add("Dloc", "Location") '3
            DieDg.Columns.Add("cap", "Capacity") '4
            DieDg.Columns.Add("max", "Max. Qnty") '5
            DieDg.Columns.Add("polish", "Polish") '6
            DieDg.Columns.Add("Ditem", "Die Item") '7
            DieDg.Columns.Add("maker", "Die Maker") '8
            DieDg.Columns.Add("dt", "Date") '9
            DieDg.Columns.Add("Adusr", "Add User") '10
            DieDg.Columns.Add("addt", "Add Date") '11
            DieDg.Columns.Add("edtusr", "Edit User") '12
            DieDg.Columns.Add("edtdt", "Edit Date") '13

            ' DieDg.Columns(18).DefaultCellStyle.BackColor = Color.LightGray

            DieDg.Columns(1).DefaultCellStyle.BackColor = Color.LightGray
            DieDg.Columns(9).DefaultCellStyle.BackColor = Color.LightGray
            DieDg.Columns(10).DefaultCellStyle.BackColor = Color.LightGray
            DieDg.Columns(11).DefaultCellStyle.BackColor = Color.LightGray
            DieDg.Columns(12).DefaultCellStyle.BackColor = Color.LightGray
            DieDg.Columns(13).DefaultCellStyle.BackColor = Color.LightGray
            DieDg.Columns(11).Width = 250
            DieDg.Columns(13).Width = 250
            DieDg.Columns(2).Width = 200
            DieDg.Columns(3).Width = 150

            DieDg.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DieDg.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DieDg.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DieDg.ColumnHeadersHeight = 60
            DieDg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            DieDg.BorderStyle = BorderStyle.FixedSingle
            DieDg.BackgroundColor = Color.Snow

            Me.SplitContainer1.Panel2.Controls.Add(DieDg)
            DieDg.Visible = True
            DieDg.Left = 0
            DieDg.Top = 2
            DieDg.Columns(0).Visible = False
            'DieDg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            Dim pn1(0), pv1(0) As String ''Arrays for procedure argu name n value
            Dim pn11(2), pv11(2) As String ''Arrays for procedure argu name n value
            pn1(0) = "@tblname"
            pv1(0) = "Finact_DieMstr"
            Die_sql.get_data("finact_select_all", pn1, pv1, "DieMaster")

            Dim mk, r As Integer
            For mk = 0 To Die_sql.ds.Tables("DieMaster").Rows.Count - 1
                DieRow = New DataGridViewRow()
                'for fetching id
                DieCel = New DataGridViewTextBoxCell()
                DieCel.Value = Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(0).ToString()
                DieRow.Cells.Add(DieCel)

                ' for fetching code
                DieCel = New DataGridViewTextBoxCell
                DieCel.Value = Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(1).ToString()
                DieRow.Cells.Add(DieCel)
                DieRow.Cells(1).ReadOnly = True

                ' for fetching name
                DieCel = New DataGridViewTextBoxCell
                DieCel.Value = Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(2).ToString()
                DieRow.Cells.Add(DieCel)

                'for fetching location
                DieCom = New DataGridViewComboBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finactcscmstr"
                pv11(1) = "cscid"
                pv11(2) = Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(3).ToString()
                If Val(pv11(2)) > 0 Then
                    Die_sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                    DieCom.Items.Add(Die_sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())

                    pn11(0) = "@ta"
                    pn11(1) = "@id"
                    pn11(2) = "@idval"

                    pv11(0) = "finactcscmstr"
                    pv11(1) = "csctype"
                    pv11(2) = "Inner"

                    Die_sql1.get_data("select_where_like", pn11, pv11, "IMa") ' IM stands for ItemMaster

                    For r = 0 To Die_sql1.ds.Tables("IMa").Rows.Count - 1
                        If Die_sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString() <> DieCom.Items(0) Then
                            DieCom.Items.Add(Die_sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString())
                        End If
                    Next
                    Die_sql1.ds.Tables("IMa").Dispose()
                    DieCom.Value = DieCom.Items(0)
                    DieRow.Cells.Add(DieCom)
                End If

                'for fetching unit Capacity
                DieCel = New DataGridViewTextBoxCell
                DieCel.Value = FormatNumber(Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(4).ToString(), 3)
                DieRow.Cells.Add(DieCel)

                'for fetching MaxProduction
                DieCel = New DataGridViewTextBoxCell
                DieCel.Value = FormatNumber(Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(5).ToString(), 2)
                DieRow.Cells.Add(DieCel)

                'for fetching Polish
                DieCel = New DataGridViewTextBoxCell
                DieCel.Value = FormatNumber(Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(6).ToString(), 2)
                DieRow.Cells.Add(DieCel)

                'For fetching die item

                DieCom = New DataGridViewComboBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finactitmmstr"
                pv11(1) = "itmid"
                pv11(2) = Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(7).ToString()

                Die_sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                DieCom.Items.Add(Die_sql1.ds.Tables("IM").Rows(0).ItemArray(2).ToString())

                pv11(1) = "itmtype1"
                pv11(2) = "BomItem"
                Die_sql1.get_data("select_where_like", pn11, pv11, "IMa")

                For r = 0 To Die_sql1.ds.Tables("IMa").Rows.Count - 1
                    If Die_sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString() <> DieCom.Items(0) Then
                        DieCom.Items.Add(Die_sql1.ds.Tables("IMa").Rows(r).ItemArray(2).ToString())
                    End If
                Next

                Die_sql1.ds.Tables("IMa").Dispose()
                DieCom.Value = DieCom.Items(0)
                DieRow.Cells.Add(DieCom)


                'for fetching item Die Maker
                DieCom = New DataGridViewComboBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finactsplrmstr"
                pv11(1) = "splrid"
                pv11(2) = Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(8).ToString()

                Die_sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                DieCom.Items.Add(Die_sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
             
                pv11(1) = "splrtype"
                pv11(2) = "Vendor"
                Die_sql1.get_data("select_where_like", pn11, pv11, "IMa")
              

                For r = 0 To Die_sql1.ds.Tables("IMa").Rows.Count - 1
                    If Die_sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString() <> DieCom.Items(0) Then
                        DieCom.Items.Add(Die_sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString())
                    End If
                Next

                Die_sql1.ds.Tables("IMa").Dispose()
                DieCom.Value = DieCom.Items(0)
                DieRow.Cells.Add(DieCom)



                'for fetching date
                DieCel = New DataGridViewTextBoxCell
                DieCel.Value = Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(9).ToString()
                DieRow.Cells.Add(DieCel)
                DieRow.Cells(9).ReadOnly = True

                'for fetching add user
                DieCel = New DataGridViewTextBoxCell
                DieCel.Value = Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(10).ToString()
                DieRow.Cells.Add(DieCel)
                DieRow.Cells(10).ReadOnly = True


                'for fetching add date
                DieCel = New DataGridViewTextBoxCell
                DieCel.Value = Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(11).ToString()
                DieRow.Cells.Add(DieCel)
                DieRow.Cells(11).ReadOnly = True


                'for fetching edit user
                DieCel = New DataGridViewTextBoxCell
                DieCel.Value = Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(12).ToString()
                DieRow.Cells.Add(DieCel)
                DieRow.Cells(12).ReadOnly = True

                'for fetching edit date
                DieCel = New DataGridViewTextBoxCell
                DieCel.Value = Die_sql.ds.Tables("DieMaster").Rows(mk).ItemArray(13).ToString()
                DieRow.Cells.Add(DieCel)
                DieRow.Cells(13).ReadOnly = True


                DieDg.Rows.Add(DieRow)

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Die_sql.cnn.Close()
            Die_sql.ds.Dispose()
        End Try
    End Sub

    Private Sub BtnDieCancl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDieCancl.Click
        Try

            If BtnDie.Text = "&Delete" Then
                Me.DieDg.Visible = False
                Me.TableLayoutPanel1.Enabled = True
                Me.TableLayoutPanel1.Visible = True
                Me.Width = 636
                BtnDieSave.Text = "&Save"
                BtnDie.Text = "&Find"
            Else
                '  clrflds()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDieExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDieExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxitem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxitem.GotFocus
        Try
            Me.Cmbxitem.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxDieMaker_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDieMaker.GotFocus
        Try
            Me.CmbxDieMaker.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Allcontrols_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDieName.KeyDown, CmbxDieLoc.KeyDown _
    , CmbxDieMaker.KeyDown, Cmbxitem.KeyDown, DieDg.KeyDown, DtpDie.KeyDown, NudDieCapcty.KeyDown, NudDiePlosh.KeyDown, NudMaxProd.KeyDown, TxtDieCode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    
    Private Sub CmbxDieMaker_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxDieMaker.SelectedIndexChanged

    End Sub
End Class
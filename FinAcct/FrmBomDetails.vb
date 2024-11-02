Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmBomDetails
    Dim sql As inv_sql
    Dim sql1 As inv_sql
    Dim bomD_Cmd As SqlCommand
    Dim bomD_rdr As SqlDataReader
    Dim bomD1_Cmd As SqlCommand
    Dim bomD1_rdr As SqlDataReader
    Dim bomD_Adptr As SqlDataAdapter
    Dim bomD_dset As DataSet
    Dim SelIndex As Boolean = False
    Dim SelStrg1 As String = ""
    Dim ItemId As Integer = 0
    Dim Li As Integer = Nothing
    Dim LstViewEdit_Flag As Boolean
    Dim CurBomid As Integer = 0
    Dim iT As String = ""
    Dim OldItmCode As String
    Dim SqlProcs_flag As Boolean = False
    Dim Delid As Integer = 0
    Dim xFlag As Boolean = False

    Private Sub FrmBomDetails_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If SqlProcs_flag = True Then
                delete_SqlProcsItem(ItmCurId, Delid, 1) ' delete record(s)
            Else
                delete_SqlProcsItem(ItmCurId, Delid, 2) ' set delstatus as 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmBomDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 20
            Dim ss As Integer = Me.Width
            Me.Height = 600
            sql = New inv_sql
            sql1 = New inv_sql

            Me.SplitContainer1.SplitterDistance = Me.Width / 6.69
            Me.SplitContainer1.IsSplitterFixed = True
            fill_Lstview(ItmCurId)
            Me.TableLayoutPanel1.Enabled = False
            Me.Gbaitm.Enabled = False
            Me.btnaiadditm.Enabled = False
            Me.BomaiLstVew.Focus()
            Fill_lstvewProcess_Selected()
            Fill_lstvewProcess_NotSelected()
            fetch_groupwiseitemtofilllstvew()
            set_Condition()
            Spl_Fill_Combobox(SelStrg1, cmbxaiselitm)
            xFlag = True
            Me.Text = ""
            Me.Text = "Bill Of Material Item Attached Master  >>> Current Selected BOM Name :- " & CurrBOMname
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub fill_Lstview(ByVal curitmid As Integer)
        Dim LstBom As ListViewItem
        Dim ic, ina As String
        Dim ii As Integer = 0
        ic = ""
        ina = ""
        Try
            bomD_Cmd = New SqlCommand("Select * from finact_bommstr where bomconcrnid=@Citmid order by bomid ", FinActConn)
            bomD_Cmd.Parameters.AddWithValue("@citmid", curitmid)
            bomD_rdr = bomD_Cmd.ExecuteReader
            Dim x As Integer
            x = 0
            While bomD_rdr.Read()
                If bomD_rdr.HasRows = True Then
                    Try
                        bomD1_Cmd = New SqlCommand("Select itmid,itmcode,itmname,itmtype from finactitmmstr where itmid=@itmid  ", FinActConn1)
                        bomD1_Cmd.Parameters.AddWithValue("@itmid", bomD_rdr("bomconcrnitmid"))
                        bomD1_rdr = bomD1_Cmd.ExecuteReader
                        bomD1_rdr.Read()
                        ii = Trim(bomD1_rdr("itmid"))
                        ic = Trim(bomD1_rdr("itmcode"))
                        ina = Trim(bomD1_rdr("itmname"))
                        iT = Trim(bomD1_rdr("itmtype"))
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        bomD1_Cmd.Dispose()
                        bomD1_rdr.Close()
                    End Try
                    LstBom = BomaiLstVew.Items.Add(ic, 1)
                    BomaiLstVew.Items(x).SubItems.Add(ina)
                    BomaiLstVew.Items(x).SubItems.Add(bomD_rdr("bomitmqnty"))
                    BomaiLstVew.Items(x).SubItems.Add(bomD_rdr("bomitmrate"))
                    BomaiLstVew.Items(x).SubItems.Add(bomD_rdr("bomitmamt"))
                    BomaiLstVew.Items(x).SubItems.Add(bomD_rdr("bomid"))
                    BomaiLstVew.Items(x).SubItems.Add(iT)
                    BomaiLstVew.Items(x).SubItems.Add(bomD_rdr("bomconcrnitmid"))
                    BomaiLstVew.Items(x).SubItems.Add("Existed")
                    BomaiLstVew.Items(x).SubItems.Add("Aded")
                    BomaiLstVew.Items(x).SubItems.Add(bomD_rdr("bomitmprocsgrupid"))
                    BomaiLstVew.Items(x).SubItems.Add(bomD_rdr("bomitmratio"))
                    BomaiLstVew.Items(x).Checked = True
                    x += 1
                    find_item_Nos_Total()
                End If
            End While
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            bomD_Cmd.Dispose()
            bomD_rdr.Close()
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            Dim lst As ListViewItem
            'BomaiLstVew.LabelEdit = True
            Me.cmbxaiselitm.Enabled = False
            lst = BomaiLstVew.FocusedItem
            OldItmCode = Trim(lst.Text)
            If BomaiLstVew.Items.Count > 0 And BomaiLstVew.SelectedItems.Count > 0 Then
                Me.cmbxaiselitm.Enabled = True
                Me.TableLayoutPanel1.Enabled = True
                Me.Gbaitm.Enabled = True
                Me.btnaiadditm.Enabled = True
                Me.BomaiLstVew.Focus()
                Li = lst.Index
                txtaiqnty.Text = lst.SubItems(2).Text
                TxtRatio.Text = lst.SubItems(11).Text
                'cmbxaiselitm.Focus()
                Me.TxtRatio.Focus()
                Me.TxtRatio.SelectAll()
                Dim curitmcode As String = BomaiLstVew.SelectedItems.Item(0).Text
                Dim curCode As Integer = cmbxaiselitm.FindString(curitmcode, 0)
                cmbxaiselitm.SelectedIndex = curCode
                LstViewEdit_Flag = True
            Else
                MsgBox("No record found for edit", MsgBoxStyle.Information, "Record Editing....")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim lst As ListViewItem
        lst = BomaiLstVew.FocusedItem
        If MessageBox.Show("Are you sure to delete this record", "Deleting Current row....", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Return
        Else
            If BomaiLstVew.Items.Count > 1 And BomaiLstVew.SelectedItems.Count > 0 Then
                CurBomid = BomaiLstVew.SelectedItems.Item(0).SubItems(5).Text
                If deletbomitem() = False Then Exit Sub
                lst.Remove()
                find_item_Nos_Total()
                find_item_Nos_Total()
            Else
                If BomaiLstVew.Items.Count = 1 Then
                    MsgBox("Atleas one record should be attached to the current BOM ", MsgBoxStyle.Information, "Record Deleting")
                Else
                    MsgBox("No record found for delete", MsgBoxStyle.Information, "Record Deleting")
                End If

            End If
        End If
    End Sub
    Private Function deletbomitem() As Boolean
        Try
            bomD_Cmd = New SqlCommand("delete from finact_bommstr where bomid=@bomid", FinActConn2)
            bomD_Cmd.Parameters.AddWithValue("@bomid", CurBomid)
            bomD_Cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            bomD_Cmd.Dispose()
        End Try


    End Function

    Private Sub delete_SqlProcsItem(ByVal SelBomid As Integer, ByVal SelProcsid As Integer, ByVal DelStatus As Integer)
        Try
            bomD_Cmd = New SqlCommand("Finact_SqlMstr_SelectedItem_Delete", FinActConn2)
            bomD_Cmd.CommandType = CommandType.StoredProcedure
            bomD_Cmd.Parameters.AddWithValue("@SelBomid", SelBomid)
            bomD_Cmd.Parameters.AddWithValue("@SelProcsid", SelProcsid)
            bomD_Cmd.Parameters.AddWithValue("@DelStat", DelStatus)
            bomD_Cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            bomD_Cmd.Dispose()
        End Try


    End Sub

    Private Sub cmbxaiselitm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxaiselitm.GotFocus
        Try
            Me.cmbxaiselitm.DroppedDown = True
            Me.Label34.Visible = False
            If Not cmbxaiselitm.Items.Count > 0 Then
                set_Condition()
                Spl_Fill_Combobox(SelStrg1, cmbxaiselitm)
            End If

            If FrmShow_flag(3) = True Then
                set_Condition()
                Spl_Fill_Combobox(SelStrg1, cmbxaiselitm)
                Dim Indxht As Integer = cmbxaiselitm.FindStringExact(IntHtCmMm(3), 0)
                cmbxaiselitm.SelectedIndex = Indxht
            End If

            If cmbxaiselitm.Items.Count > 0 Then
                If cmbxaiselitm.SelectedIndex = -1 Then
                    cmbxaiselitm.SelectedIndex = 0
                End If
            End If
            If SelIndex = True Then
                Me.Panel10.Visible = True
                Me.Panel10.Location = New System.Drawing.Point(2, 5)
                Me.Panel10.Size = New System.Drawing.Point(169, 326)
                SelRec_Itemmaster()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Spl_Fill_Combobox(ByVal xSelstring As String, ByVal Xcombobx As ComboBox)
        Dim xStr As String = xSelstring
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            bomd_cmd = New SqlCommand(xStr, FinActConn1)
            SqlAdptr = New SqlDataAdapter(bomd_cmd)
            dtaset = New DataSet(bomD_Cmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = "itmid"
            Xcombobx.DisplayMember = "itmcode"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            bomD_Cmd.Dispose()
            SqlAdptr.Dispose()
            SelIndex = True
        End Try
    End Sub

    Private Sub Allcontrols_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxaiselitm.KeyDown, rbaibom.KeyDown _
    , rbaiboth.KeyDown, rbairaw.KeyDown, txtaiqnty.KeyDown, TxtRatio.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbxaiselitm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxaiselitm.Leave
        Try
            If FrmShow_flag(3) = True Then
                FrmShow_flag(3) = False
                TxtRatio.Focus()
                TxtRatio.SelectAll()
            End If
            Me.Panel10.Visible = False
            If Trim(lblin.Text) <> "" Then
                Me.Label5.Text = "Currently Selected Item Is " & Trim(lblin.Text)
                Me.Label5.Visible = True
            Else
                Me.Label5.Visible = False
            End If
        Catch ex As Exception
        Finally
            Me.cmbxaiselitm.DroppedDown = False
        End Try
    End Sub

    Private Sub cmbxaiselitm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxaiselitm.SelectedIndexChanged
        Try
            If SelIndex = True Then
                SelRec_Itemmaster()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtaiqnty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtaiqnty.Leave
        If Trim(txtaiqnty.Text) <> "" Then
            If IsNumeric(txtaiqnty.Text) = False Or Trim(txtaiqnty.Text.EndsWith("-")) = True Or Trim(txtaiqnty.Text.StartsWith("-")) = True Then
                MsgBox("Invalid Input! Only numbers are allowed", MsgBoxStyle.Critical, "Enter number like 1,2,3...")
                txtaiqnty.Focus()
                txtaiqnty.SelectAll()
                Exit Sub
            Else
                If LstViewEdit_Flag = True Then

                    BomaiLstVew.Items(Li).Text = Trim(Me.LblCode.Text) ' Trim(cmbxaiselitm.Text)
                    BomaiLstVew.Items(Li).SubItems(1).Text = Trim(lblin.Text)
                    BomaiLstVew.Items(Li).SubItems(2).Text = FormatNumber(txtaiqnty.Text, 3)
                    Dim qval As Double = txtaiqnty.Text
                    Dim rtio As Double = TxtRatio.Text
                    Dim rval As Double
                    Dim ittype As String = ""
                    If Trim(iT) = "Sale" Then
                        rval = lblsr.Text
                        ittype = "Sale"
                    ElseIf Trim(iT) = "Purchase" Then
                        rval = lblpr.Text
                        ittype = "Purchase"
                    End If
                    BomaiLstVew.Items(Li).SubItems(3).Text = FormatNumber(rval, 2)
                    BomaiLstVew.Items(Li).SubItems(4).Text = FormatNumber(qval * rval / rtio, 2)
                    BomaiLstVew.Items(Li).SubItems(6).Text = Trim(ittype)
                    ' BomaiLstVew.Items(Li).SubItems(6).Text = ItemId
                    BomaiLstVew.Items(Li).SubItems(7).Text = ItemId
                    BomaiLstVew.Items(Li).SubItems(8).Text = Trim("Edited")
                    BomaiLstVew.Items(Li).SubItems(11).Text = FormatNumber(rtio, 3)


                    txtaiqnty.Text = ""
                    Me.TxtRatio.Text = 1
                    find_item_Nos_Total()

                    For Each CodItm As ListViewItem In Me.Lstvewitmsel.Items
                        If Trim(OldItmCode) = Trim(CodItm.SubItems(1).Text) Then
                            CodItm.Text = BomaiLstVew.Items(Li).SubItems(1).Text
                            CodItm.SubItems(1).Text = BomaiLstVew.Items(Li).Text
                            CodItm.SubItems(2).Text = FormatNumber(BomaiLstVew.Items(Li).SubItems(2).Text, 3)
                            Lstvewitmsel.Items.Add(CodItm)
                        End If
                    Next

                ElseIf LstViewEdit_Flag = False Then
                    'If MessageBox.Show("Are you sure to add this item", "Item adding to BOM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    If find_itemfromlstvew() = True Then
                        txtaiqnty.Text = ""
                        cmbxaiselitm.Focus()
                        Exit Sub
                    End If
                    Dim BomLV As ListViewItem
                    BomLV = BomaiLstVew.Items.Add(Trim(cmbxaiselitm.Text))
                    BomLV.SubItems.Add(Trim(lblin.Text))
                    BomLV.SubItems.Add(FormatNumber(txtaiqnty.Text, 3))
                    Dim qval As Double = txtaiqnty.Text
                    Dim rtio As Double = TxtRatio.Text
                    Dim rval As Double

                    If Trim(iT) = "Sale" Then
                        rval = lblsr.Text
                    ElseIf Trim(iT) = "Purchase" Then
                        rval = lblpr.Text
                    End If
                    BomLV.SubItems.Add(FormatNumber(rval, 2))
                    BomLV.SubItems.Add(FormatNumber(qval * rval / rtio, 2))
                    BomLV.SubItems.Add("")
                    BomLV.SubItems.Add(Trim(lblic.Text))
                    BomLV.SubItems.Add(ItemId)
                    BomLV.SubItems.Add("AddNew")
                    BomLV.SubItems.Add("NotAded")
                    BomLV.SubItems.Add("")
                    BomLV.SubItems.Add(rtio)
                    find_item_Nos_Total()
                    txtaiqnty.Text = ""
                    Me.TxtRatio.Text = 1
                    cmbxaiselitm.Focus()

                End If
            End If
        Else
            txtaiqnty.BackColor = Color.Cyan
        End If
    End Sub


    Private Sub txtaiqnty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtaiqnty.TextChanged
        txtaiqnty.BackColor = Color.White
    End Sub
    Private Function FindcurrentId(ByVal Xname As String) As Integer
        Try
            Dim Curritmid As Integer = 0
            bomd_cmd = New SqlCommand("select itmid from finactitmmstr where itmname=@name and itmtype1=@type1", FinActConn1)
            bomd_cmd.Parameters.AddWithValue("@name", Trim(Xname))
            bomd_cmd.Parameters.AddWithValue("@type1", Trim("BomItem"))
            bomd_rdr = bomd_cmd.ExecuteReader
            bomd_rdr.Read()
            If bomd_rdr.HasRows = True Then
                Curritmid = bomD_rdr(0)
                Return Curritmid
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            bomD_rdr.Close()
            bomD_Cmd.Dispose()
        End Try

    End Function
    Private Sub save_Bomitems()
        Try
            Dim AloNxt As Integer
            If Me.BomaiLstVew.Items.Count > 0 Then
                For Each ckItm As ListViewItem In Me.BomaiLstVew.Items
                    If Trim(ckItm.SubItems(9).Text) = "NotAded" Then
                        ckItm.BackColor = Color.Yellow
                        AloNxt += 1
                    Else
                        ckItm.BackColor = Color.White
                    End If
                Next
                If AloNxt <> 0 Then
                    MsgBox("One or more item(s) is/are not configured to the Movement schema ", MsgBoxStyle.Critical, "Movement Schema!!!")
                    AloNxt = 0
                    Exit Sub
                End If
                If Not Me.Lstvewitmsel.Items.Count > 0 Then
                    MsgBox("Movement schema should not empty", MsgBoxStyle.Critical, "Movement Schema!!!")
                    Exit Sub
                End If

            End If
            Dim ix As Integer = 0
            If BomaiLstVew.Items.Count > 0 Then
                Dim CurBomName As String = Trim(BomaiLstVew.Items(ix).SubItems(1).Text)
                Dim CurbomId As Integer = FindcurrentId(CurBomName)
                For ix = 0 To BomaiLstVew.Items.Count - 1
                    If Trim(BomaiLstVew.Items(ix).SubItems(8).Text) = "Edited" Then
                        bomD_Cmd = New SqlCommand("finact_bommstr_update", FinActConn)
                        bomD_Cmd.CommandType = CommandType.StoredProcedure
                        bomD_Cmd.Parameters.AddWithValue("@bomid", BomaiLstVew.Items(ix).SubItems(5).Text)
                        bomD_Cmd.Parameters.AddWithValue("@bomconcrnid", ItmCurId)
                        bomD_Cmd.Parameters.AddWithValue("@bomconcrnitmid", BomaiLstVew.Items(ix).SubItems(7).Text)
                        bomD_Cmd.Parameters.AddWithValue("@bomitmqnty", BomaiLstVew.Items(ix).SubItems(2).Text)
                        bomD_Cmd.Parameters.AddWithValue("@bomitmrate", BomaiLstVew.Items(ix).SubItems(3).Text)
                        bomD_Cmd.Parameters.AddWithValue("@bomitmamt", BomaiLstVew.Items(ix).SubItems(4).Text)
                        bomD_Cmd.Parameters.AddWithValue("@bomitmPrcsGid", BomaiLstVew.Items(ix).SubItems(10).Text)
                        bomD_Cmd.Parameters.AddWithValue("@bomitmratio", CInt(BomaiLstVew.Items(ix).SubItems(11).Text))
                        bomD_Cmd.ExecuteNonQuery()
                    ElseIf Trim(BomaiLstVew.Items(ix).SubItems(8).Text) = "AddNew" Then
                        bomD_Cmd = New SqlCommand("finact_bommstr_insert", FinActConn)
                        bomD_Cmd.CommandType = CommandType.StoredProcedure
                        bomD_Cmd.Parameters.AddWithValue("@bomconcrnid", ItmCurId)
                        bomD_Cmd.Parameters.AddWithValue("@bomconcrnitmid", BomaiLstVew.Items(ix).SubItems(7).Text)
                        bomD_Cmd.Parameters.AddWithValue("@bomitmqnty", BomaiLstVew.Items(ix).SubItems(2).Text)
                        bomD_Cmd.Parameters.AddWithValue("@bomitmrate", BomaiLstVew.Items(ix).SubItems(3).Text)
                        bomD_Cmd.Parameters.AddWithValue("@bomitmamt", BomaiLstVew.Items(ix).SubItems(4).Text)
                        bomD_Cmd.Parameters.AddWithValue("@bomitmPrcsGid", BomaiLstVew.Items(ix).SubItems(10).Text)
                        bomD_Cmd.Parameters.AddWithValue("@bomitmratio", CInt(BomaiLstVew.Items(ix).SubItems(11).Text))
                        bomD_Cmd.ExecuteNonQuery()
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        Finally
            bomD_Cmd.Dispose()

        End Try
        Try
            Dim Ixx As Integer
            For Ixx = 0 To Me.lstbxprocs1.Items.Count - 1
                ' If Me.lstbxprocs1.Items(Ixx).SubItems(3).Text = "Added" Then
                If Me.lstbxprocs1.Items(Ixx).SubItems(3).Text = "NewAdded" Then
                    bomD_Cmd = New SqlCommand("Finact_ProcesMoveSql_Insert", FinActConn)
                    bomD_Cmd.CommandType = CommandType.StoredProcedure
                    bomD_Cmd.Parameters.AddWithValue("@pmbomconid", ItmCurId)
                    bomD_Cmd.Parameters.AddWithValue("@pmprcsconid", Me.lstbxprocs1.Items(Ixx).Text)
                    bomD_Cmd.Parameters.AddWithValue("@pmmoveno", Ixx)
                    bomD_Cmd.Parameters.AddWithValue("@pmadusrid", Current_UsrId)
                    bomD_Cmd.Parameters.AddWithValue("@pmaddt", Now)
                    bomD_Cmd.Parameters.AddWithValue("@pmdelstatus", 1)
                    bomD_Cmd.ExecuteNonQuery()

                End If

            Next
            MsgBox("Current Item(s) has been save and updated", MsgBoxStyle.Information, "Bill of Material Editing...")
            SqlProcs_flag = True
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Function find_itemfromlstvew() As Boolean
        Try
            If BomaiLstVew.Items.Count > 0 Then
                Dim i As Integer = 0
                For i = 0 To BomaiLstVew.Items.Count - 1
                    If Trim(cmbxaiselitm.Text.ToUpper) = Trim(BomaiLstVew.Items(i).Text.ToUpper) Then
                        MsgBox("This item is already added to BOM", MsgBoxStyle.Critical, "Already entered")
                        Return True
                    Else
                        '  Return False
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Function find_itemfromlstvew_RowHighlighted() As Boolean

        Try
            If BomaiLstVew.Items.Count > 0 Then
                Dim i, j As Integer
                For i = 0 To BomaiLstVew.Items.Count - 1
                    For j = i + 1 To Me.BomaiLstVew.Items.Count - 1
                        If Trim(Me.BomaiLstVew.Items(i).Text) = Trim(BomaiLstVew.Items(j).Text.ToUpper) Then
                            Me.BomaiLstVew.Items(i).BackColor = Color.Yellow
                            MsgBox("This item is already added to BOM", MsgBoxStyle.Critical, "Already entered")
                            Return True
                        Else
                            Me.BomaiLstVew.Items(i).BackColor = Color.White
                            '  Return False
                        End If
                    Next
                    
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Sub find_item_Nos_Total()
        Try
            Me.lblainos.Text = ""
            Me.lblaival.Text = ""
            If BomaiLstVew.Items.Count > 0 Then
                Dim i As Integer = 0
                Dim Itm_Nos As Integer = 0
                Dim Itm_Valtotal As Double = 0
                For i = 0 To BomaiLstVew.Items.Count - 1
                    Itm_Valtotal += CDbl(BomaiLstVew.Items(i).SubItems(4).Text)
                Next
                lblainos.Text = i
                lblaival.Text = FormatNumber(Itm_Valtotal, 2)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub
    Private Sub SelRec_Itemmaster()
        Try
            ItemId = cmbxaiselitm.SelectedValue
            bomD1_Cmd = New SqlCommand("select itmcode,itmname,itmcatid,itmunttype,itmratechek,itmsalerate,itmreorder,itmmax,itmtype from finactitmmstr where itmid='" & (ItemId) & "' ", FinActConn)
            bomD1_rdr = bomD1_Cmd.ExecuteReader
            bomD1_rdr.Read()
            If bomD1_rdr.HasRows = True Then
                LblCode.Text = Trim(bomD1_rdr(0))
                lblic.Text = Trim(bomD1_rdr(8))
                lblin.Text = Trim(bomD1_rdr(1))
                Dim Gid As Integer = bomD1_rdr(2)
                bomD_Cmd = New SqlCommand("select cogrupnam from finactstokgrupname where cogrpid='" & (Gid) & "'", FinActConn1)
                bomD_rdr = bomD_Cmd.ExecuteReader
                bomD_rdr.Read()
                If bomD_rdr.HasRows = True Then
                    lblig.Text = Trim(bomD_rdr(0))
                End If
                bomD_Cmd.Dispose()
                bomD_rdr.Close()
                lblut.Text = Trim(bomD1_rdr(3))
                lblpr.Text = FormatNumber(bomD1_rdr(4), 2)
                lblsr.Text = FormatNumber(bomD1_rdr(5), 2)
                lblrol.Text = FormatNumber(bomD1_rdr(6), 3)
                lblmq.Text = FormatNumber(bomD1_rdr(7), 3)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            bomD1_Cmd.Dispose()
            bomD1_rdr.Close()
        End Try
    End Sub
    Private Sub set_Condition()
        If Trim(BomCurType) = "Sale" Then
            If rbairaw.Checked = True Then
                SelStrg1 = "Select itmid, itmcode from finactitmmstr where itmid<>'" & (ItmCurId) & "' and itmtype in ('Sale','Trading') and itmtype1='RawItem' order by itmcode"
            ElseIf rbaibom.Checked = True Then
                SelStrg1 = "Select itmid,itmcode from finactitmmstr where itmid<>'" & (ItmCurId) & "' and itmtype in ('Sale','Production') and itmtype1='BomItem'order by itmcode"
            ElseIf rbaiboth.Checked = True Then
                SelStrg1 = "Select itmid, itmcode from finactitmmstr where itmid<>'" & (ItmCurId) & "' and itmtype in ('Sale','Trading','Production') and itmtype1 in('RawItem','BomItem')order by itmcode"
            End If
        ElseIf Trim(BomCurType) = "Production" Then
            If rbairaw.Checked = True Then
                SelStrg1 = "Select itmid, itmcode from finactitmmstr where itmid<>'" & (ItmCurId) & "' and itmtype in ('Purchase','Trading') and itmtype1='RawItem'order by itmcode"
            ElseIf rbaibom.Checked = True Then
                SelStrg1 = "Select itmid, itmcode from finactitmmstr where itmid<>'" & (ItmCurId) & "' and itmtype in ('Purchase','Production') and itmtype1='BomItem'order by itmcode"
            ElseIf rbaiboth.Checked = True Then
                SelStrg1 = "Select itmid, itmcode from finactitmmstr where itmid<>'" & (ItmCurId) & "' and itmtype in ('Purchase','Trading','Production') and itmtype1 in('RawItem','BomItem')order by itmcode"
            End If
        ElseIf Trim(BomCurType) = "Both" Then
            If rbairaw.Checked = True Then
                SelStrg1 = "Select itmid, itmcode from finactitmmstr where itmid<>'" & (ItmCurId) & "' and itmtype in ('Sale','Purchase','Trading','Production') and itmtype1='RawItem'order by itmcode"
            ElseIf rbaibom.Checked = True Then
                SelStrg1 = "Select itmid, itmcode from finactitmmstr where itmid<>'" & (ItmCurId) & "' and  itmtype in ('Sale','Purchase','Trading','Production') and itmtype1='BomItem'order by itmcode"
            ElseIf rbaiboth.Checked = True Then
                SelStrg1 = "Select itmid, itmcode from finactitmmstr where itmid<>'" & (ItmCurId) & "' and  itmtype in ('Sale','Purchase','Trading','Production') and itmtype1 in('RawItem','BomItem')order by itmcode"
            End If
        End If

    End Sub

    Private Sub btnaiadditm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaiadditm.Click
        Dim frmiLa As New FrmStokItm
        frmiLa.ShowInTaskbar = False
        FrmShow_flag(3) = True
        If Me.rbairaw.Checked = True Then
            FrmStokItm.rBTradingOnly.Checked = True
        ElseIf Me.RbBom.Checked = True Then
            FrmStokItm.rBTradingOnly.Checked = True
        Else
            FrmStokItm.rBTradingOnly.Checked = True
        End If


        If Trim(BomCurType) = "Sale" Then
            Rbstatus(0) = 1 'Sales
        ElseIf Trim(BomCurType) = "Production" Then
            Rbstatus(0) = 2 'Production
        End If
        frmiLa.ShowDialog()
    End Sub

    Private Sub btnaiadditm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnaiadditm.GotFocus
        If FrmShow_flag(3) = True Then
            cmbxaiselitm.Focus()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        set_Condition()
        Spl_Fill_Combobox(SelStrg1, cmbxaiselitm)
        LstViewEdit_Flag = False
        Me.TableLayoutPanel1.Enabled = True
        Me.Gbaitm.Enabled = True
        Me.btnaiadditm.Enabled = True
        Me.cmbxaiselitm.Enabled = True
        Me.BomaiLstVew.Focus()
        cmbxaiselitm.Focus()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            Dim lstCont As Integer = Me.lstbxprocs1.Items.Count
            If Not lstCont >= 2 Then '++ make sure that there are atleat two process selected. 
                MsgBox("No of Processes should be atleast '2'" & Chr(13) & "For Example... " & Chr(13) & "(1)..Material Requirement Check/Item(s) Issue From Store" & Chr(13) & "(2).. Process in which current item to be produce.", MsgBoxStyle.Information, "MRP....")
                Exit Sub
            End If

            If Not BomaiLstVew.Items.Count > 0 Then '++ Make sure that atleat one item attached to current BoM
                MsgBox("Invalid input! One or more items should be attached to a BOM", MsgBoxStyle.Critical, "Items are required")
                Exit Sub
            End If

            If Me.Lstvewitmsel.Items.Count > 0 Then '++ Make sure that first process have atleat one record.
                Dim ChkItm As String = Trim(Me.lstbxprocs1.Items(0).SubItems(1).Text)
                Dim xItm As Integer = 0
                Dim Flag1 As Boolean = False
                For xItm = 0 To Me.Lstvewitmsel.Items.Count - 1
                    If Trim(ChkItm) = Trim(Me.Lstvewitmsel.Items(xItm).Group.Name) Then
                        Flag1 = True
                        Exit For
                    End If
                Next
                If Flag1 = False Then
                    MsgBox("First Process should have atleat one item in movement schema", MsgBoxStyle.Critical, "Invalid movement schema!!")
                    Exit Sub
                End If
               
            End If
            If MessageBox.Show("Are you sure to update or save current record(s)", "BOM Editing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                save_Bomitems()
            Else
                BomaiLstVew.Focus()
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
    Private Sub Fill_lstvewProcess_NotSelected()
        Try

            Dim xStr As String = "Select process_id,Process_name from finact_processmstr" _
            & " where process_id not in(select bomitmprocsgrupid from finact_bommstr where bomconcrnid=@Bconid) order by process_name"
            dtaset = New DataSet
            dtaset.Tables.Clear()

            bomD_Cmd = New SqlCommand(xStr, FinActConn1)
            bomD_Cmd.Parameters.AddWithValue("@Bconid", ItmCurId)
            Dim bomD_SqlAdptr As SqlDataAdapter = New SqlDataAdapter(bomD_Cmd)
            Dim bomd_dtaset As DataSet = New DataSet(bomD_Cmd.CommandText)
            bomD_SqlAdptr.Fill(bomd_dtaset)
            Dim xf As Integer = 0

            For xf = 0 To bomd_dtaset.Tables(0).Rows.Count - 1
                Dim iX As Integer = 0
                Dim Ixx As Boolean = False
                If Me.lstbxprocs1.Items.Count > 0 Then
                    For iX = 0 To Me.lstbxprocs1.Items.Count - 1
                        If Trim(bomd_dtaset.Tables(0).Rows(xf).ItemArray(1).ToString()) = Trim(Me.lstbxprocs1.Items(iX).SubItems(1).Text) Then
                            Ixx = True
                            Exit For
                        End If
                    Next
                End If
                If Ixx = False Then
                    Dim lstpr As New ListViewItem
                    lstpr.Text = bomd_dtaset.Tables(0).Rows(xf).ItemArray(0)
                    lstpr.SubItems.Add(Trim(bomd_dtaset.Tables(0).Rows(xf).ItemArray(1).ToString()))
                    Me.Lstbxprocs.Items.Add(lstpr)
                End If


            Next
            bomD_SqlAdptr.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            bomD_Cmd.Dispose()
        End Try



    End Sub
    Private Sub Fill_lstvewProcess_Selected()
        Dim xStr As String = "select procssql_id, process_id,Process_name  from finact_processmovementsqlmstr" _
        & " inner join finact_processmstr on process_id =procssql_procsconcrnid" _
        & " where procssql_bomconcrnid=@Bconid order by procssql_sqlno"
        Dim bomD_SqlAdptr As SqlDataAdapter
        Dim bomd_dtaset As DataSet
        bomd_dtaset = New DataSet
        bomd_dtaset.Tables.Clear()
        Try
            bomD_Cmd = New SqlCommand(xStr, FinActConn1)
            bomD_Cmd.Parameters.AddWithValue("@Bconid", ItmCurId)
            bomD_SqlAdptr = New SqlDataAdapter(bomD_Cmd)
            bomd_dtaset = New DataSet(bomD_Cmd.CommandText)
            bomD_SqlAdptr.Fill(bomd_dtaset)
            Dim xf As Integer = 0

            For xf = 0 To bomd_dtaset.Tables(0).Rows.Count - 1
                Dim lstpr As New ListViewItem
                lstpr.Text = bomd_dtaset.Tables(0).Rows(xf).ItemArray(1)
                lstpr.SubItems.Add(Trim(bomd_dtaset.Tables(0).Rows(xf).ItemArray(2).ToString()))
                lstpr.SubItems.Add(Trim("Fixed"))
                lstpr.SubItems.Add(Trim("Added"))
                lstpr.BackColor = Color.LightCyan
                Me.lstbxprocs1.Items.Add(lstpr)
            Next
            bomD_SqlAdptr.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            bomD_Cmd.Dispose()
        End Try



    End Sub
    Private Sub fetch_groupwiseitemtofilllstvew()
        Try
            DynaRptDt = New DataTable("SetItemMove")
            DynaRptDt.Columns.Add("Item Name")
            DynaRptDt.Columns.Add("Item Id")
            DynaRptDt.Columns.Add("Quantity")
            DynaRptDt.Columns.Add("Item Group")
            DynaRptDt.Columns.Add("Item Group Id")

            DynaRptDt.Columns(1).Unique = True

            For Each itm As ListViewItem In Me.BomaiLstVew.Items
                If Trim(itm.SubItems(9).Text) = "Aded" Then
                    DynaRptDtrow = DynaRptDt.NewRow
                    DynaRptDtrow(1) = itm.Text
                    DynaRptDtrow(0) = itm.SubItems(1).Text
                    DynaRptDtrow(2) = itm.SubItems(2).Text
                   
                    For Each Xitm As ListViewItem In Me.lstbxprocs1.Items
                        If Xitm.SubItems(0).Text = itm.SubItems(10).Text Then
                            DynaRptDtrow(3) = Xitm.SubItems(1).Text ' Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text
                            DynaRptDtrow(4) = Xitm.Text ' Me.lstbxprocs1.SelectedItems(0).Text
                        End If
                    Next
                    
                    DynaRptDt.Rows.Add(DynaRptDtrow)
                    Dim idx As Integer = itm.Index
                    itm.SubItems(0).ForeColor = Color.DarkGray
                    itm.SubItems(0).BackColor = Color.LightCyan
                End If
            Next
            Dim Xc As Integer = 0
            For Xc = 0 To Me.lstbxprocs1.Items.Count - 1
                Me.Lstvewitmsel.Groups.Add(Trim(Me.lstbxprocs1.Items(Xc).SubItems(1).Text), Trim(Me.lstbxprocs1.Items(Xc).SubItems(1).Text))
            Next
            Me.Lstvewitmsel.BeginUpdate()
            For Each ItmRow As DataRow In DynaRptDt.Rows
                Dim lstVitm As New ListViewItem
                lstVitm.Text = ItmRow(0).ToString
                lstVitm.SubItems.Add(ItmRow(1))
                lstVitm.SubItems.Add(ItmRow(2))
                Dim a As String = ItmRow(2)
                lstVitm.Group = Me.Lstvewitmsel.Groups(ItmRow(3))

                Lstvewitmsel.Items.Add(lstVitm)

            Next
            Me.Lstvewitmsel.EndUpdate()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub

    Private Sub Btnmove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnmove1.Click
        Dim itm As Integer
        Try
            If Me.Lstbxprocs.SelectedItems.Count = 1 Then
                itm = Me.Lstbxprocs.SelectedItems(0).Index
                Dim lstp2 As New ListViewItem
                lstp2.Text = Me.Lstbxprocs.SelectedItems(0).Text
                lstp2.SubItems.Add(Trim(Me.Lstbxprocs.SelectedItems(0).SubItems(1).Text))
                lstp2.SubItems.Add(Trim(""))
                lstp2.SubItems.Add(Trim("NewAdded"))
                Me.lstbxprocs1.Items.Add(lstp2)
                Me.Lstbxprocs.Items.RemoveAt(itm)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnMove2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMove2.Click
        Dim itm As Integer
        Try
            If Me.lstbxprocs1.SelectedItems.Count = 1 Then
                itm = Me.lstbxprocs1.SelectedItems(0).Index
                Dim ChkItm As String = Trim(Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text)
                Dim xItm As Integer = 0
                If Me.Lstvewitmsel.Items.Count > 0 Then
                    For xItm = 0 To Me.Lstvewitmsel.Items.Count - 1
                        If Trim(ChkItm) = Trim(Me.Lstvewitmsel.Items(xItm).Group.Name) Then Exit Sub
                    Next
                End If
                Dim lstp3 As New ListViewItem
                lstp3.Text = Me.lstbxprocs1.SelectedItems(0).Text
                delid = lstp3.Text
                lstp3.SubItems.Add(Trim(Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text))
                Me.Lstbxprocs.Items.Add(lstp3)
                Me.lstbxprocs1.Items.RemoveAt(itm)
                delete_SqlProcsItem(ItmCurId, Delid, 0) 'set delstatus as 0
                SqlProcs_flag = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Btnmove3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnmove3.Click
        Try
            For Each itm As ListViewItem In Me.Lstbxprocs.Items
                Dim lstp5 As New ListViewItem
                lstp5.Text = itm.Text
                lstp5.SubItems.Add(Trim(itm.SubItems(1).Text))
                lstp5.SubItems.Add(Trim(""))
                lstp5.SubItems.Add(Trim("NewAdded"))
                Me.lstbxprocs1.Items.Add(lstp5)
                Me.Lstbxprocs.Items.RemoveAt(itm.Index)
            Next
            ' Me.Lstbxprocs.Items.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Btnmove4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnmove4.Click
        Try
            For Each itm As ListViewItem In Me.lstbxprocs1.Items
                'itm = Me.lstbxprocs1.SelectedItems(0).Index
                Dim ChkItm As String = Trim(itm.SubItems(1).Text)
                Dim xItm As Integer = 0
                If Me.Lstvewitmsel.Items.Count > 0 Then
                    For xItm = 0 To Me.Lstvewitmsel.Items.Count - 1
                        If Trim(ChkItm) = Trim(Me.Lstvewitmsel.Items(xItm).Group.Name) Then Exit Sub
                    Next
                End If
                Dim lstp4 As New ListViewItem
                lstp4.Text = itm.Text
                Delid = lstp4.Text
                lstp4.SubItems.Add(Trim(itm.SubItems(1).Text))
                Me.Lstbxprocs.Items.Add(lstp4)
                Me.lstbxprocs1.Items.RemoveAt(itm.Index)
                delete_SqlProcsItem(ItmCurId, Delid, 0) 'set delstatus as 0
                SqlProcs_flag = False
            Next
            Me.lstbxprocs1.Items.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSelItm1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelItm1.Click
        Try
            If find_itemfromlstvew_RowHighlighted() = True Then

                Exit Sub
            End If
            If Me.lstbxprocs1.SelectedItems.Count >= 1 Then
                If Me.BomaiLstVew.CheckedItems.Count > 0 Then
                    CreateOffLineTablelistvew()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CreateOffLineTablelistvew()
        Try
            DynaRptDt = New DataTable("SetItemMove")
            DynaRptDt.Columns.Add("Item Name")
            DynaRptDt.Columns.Add("Item Id")
            DynaRptDt.Columns.Add("Quantity")
            DynaRptDt.Columns.Add("Item Group")
            DynaRptDt.Columns.Add("Item Group Id")

            DynaRptDt.Columns(1).Unique = True

            For Each itm As ListViewItem In Me.BomaiLstVew.CheckedItems
                If Trim(itm.SubItems(9).Text) <> "Aded" Then
                    DynaRptDtrow = DynaRptDt.NewRow
                    DynaRptDtrow(1) = itm.Text
                    DynaRptDtrow(0) = itm.SubItems(1).Text
                    DynaRptDtrow(2) = itm.SubItems(2).Text
                    Dim b As Integer = Me.lstbxprocs1.SelectedItems(0).Text
                    Dim bx As String = Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text
                    DynaRptDtrow(3) = Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text
                    DynaRptDtrow(4) = Me.lstbxprocs1.SelectedItems(0).Text
                    DynaRptDt.Rows.Add(DynaRptDtrow)
                    Dim idx As Integer = itm.Index
                    itm.SubItems(0).ForeColor = Color.DarkGray
                    itm.SubItems(0).BackColor = Color.LightCyan
                    If Trim(itm.SubItems(8).Text) <> "AddNew" Then
                        itm.SubItems(8).Text = "Edited"
                    End If
                    itm.SubItems(9).Text = "Aded"
                    itm.SubItems(10).Text = b
                    Dim LstIndx As Integer = Me.lstbxprocs1.SelectedItems(0).Index
                    'Me.lstbxprocs1.Items(LstIndx).SubItems(3).Text = "NewAdded"
                    Me.lstbxprocs1.Items(LstIndx).SubItems(2).Text = "Fixed"

                    Me.lstbxprocs1.Items(LstIndx).BackColor = Color.LightPink
                End If
            Next
            Me.Lstvewitmsel.Groups.Add(Trim(Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text), Trim(Me.lstbxprocs1.SelectedItems(0).SubItems(1).Text))
            Me.Lstvewitmsel.BeginUpdate()
            For Each ItmRow As DataRow In DynaRptDt.Rows
                Dim lstVitm As New ListViewItem
                lstVitm.Text = ItmRow(0).ToString
                lstVitm.SubItems.Add(ItmRow(1))
                lstVitm.SubItems.Add(ItmRow(2))
                Dim a As String = ItmRow(2)
                lstVitm.Group = Me.Lstvewitmsel.Groups(ItmRow(3))
                Lstvewitmsel.Items.Add(lstVitm)
            Next
            Me.Lstvewitmsel.EndUpdate()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub

    Private Sub BtnItmUnsel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnItmUnsel.Click
        If Me.Lstvewitmsel.Items.Count > 0 Then
            If Me.Lstvewitmsel.SelectedItems.Count > 0 Then
                For Each SelItm As ListViewItem In Me.Lstvewitmsel.SelectedItems
                    Dim Idx1 As Integer = Me.Lstvewitmsel.SelectedItems(0).Index
                    For Each SelItm1 As ListViewItem In Me.BomaiLstVew.Items
                        If Trim(SelItm.SubItems(1).Text) = Trim(SelItm1.SubItems(0).Text) Then
                            SelItm1.ForeColor = Color.Black
                            SelItm1.BackColor = Color.White
                            SelItm1.SubItems(9).Text = Trim("NotAded")
                            SelItm1.SubItems(10).Text = Trim("")

                            SelItm1.Checked = False
                        End If
                    Next
                    Me.Lstvewitmsel.Items.RemoveAt(Idx1)

                Next
                ''For Each gitm As ListViewItem In Me.lstbxprocs1.Items
                ''    For Each gn As ListViewGroup In Me.Lstvewitmsel.Groups
                ''        Dim a As String = Trim(gitm.SubItems(1).Text)
                ''        Dim aa As String = Trim(gn.Name)
                ''        If Trim(gitm.SubItems(1).Text) = Trim(gn.Name) Then
                ''            If gn.Items.Count = 0 Then
                ''                Me.lstbxprocs1.Items(gitm.Index).SubItems(2).Text = ""
                ''                gn.Name.Remove(0)
                ''            End If
                ''        End If
                ''    Next
                ''Next
            End If
        End If
    End Sub

    Private Sub BomaiLstVew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BomaiLstVew.Click
        Try
            Dim xI As Integer
            If Me.BomaiLstVew.CheckedItems.Count > 0 Then
                Me.lstvewContextms.Enabled = True
                xI = (Me.BomaiLstVew.SelectedItems(0).Index)
                If Me.BomaiLstVew.Items(xI).SubItems(9).Text = "Aded" Then
                    Me.lstvewContextms.Items(1).Enabled = False
                    Me.lstvewContextms.Items(2).Enabled = False
                    Me.btndele.Enabled = False
                    Me.btnedit.Enabled = False
                    Exit Sub
                Else
                    'If Me.BomaiLstVew.Items(xI).SubItems(11).Text >= 1 Then

                    '    _Fill_Combobox_PACKMTRL_WhereNotItmId(Me.cmbxaiselitm)
                    '    Me.lstvewContextms.Items(1).Enabled = True
                    '    Me.lstvewContextms.Items(2).Enabled = False
                    '    Me.btndele.Enabled = False
                    '    Me.btnedit.Enabled = False


                    'Else
                    Me.lstvewContextms.Enabled = True
                    Me.lstvewContextms.Items(1).Enabled = True
                    Me.lstvewContextms.Items(2).Enabled = True
                    Me.btndele.Enabled = True
                    Me.btnedit.Enabled = True

                    ' End If
                End If

            Else
            Me.lstvewContextms.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub _Fill_Combobox_PACKMTRL_WhereNotItmId(ByVal Xcombox2 As ComboBox)
        Try
            Dim xStr As String = "Finact_ItemMaster_Only_PackingMaterial_Select_Where_Not_none"
            bomD_dset = New DataSet
            bomD_dset.Tables.Clear()

            bomD_Cmd = New SqlCommand(xStr, FinActConn1)
            bomD_Cmd.CommandType = CommandType.StoredProcedure
            'bomD_Cmd.Parameters.AddWithValue("@NotItmid", NotItmid)
            bomD_Adptr = New SqlDataAdapter(bomD_Cmd)
            bomD_dset = New DataSet(bomD_Cmd.CommandText)
            bomD_Adptr.Fill(bomD_dset)
            Xcombox2.DataSource = bomD_dset.Tables(0)
            Xcombox2.ValueMember = "itmid"
            Xcombox2.DisplayMember = "itmname"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            bomD_Cmd.Dispose()
            bomD_Adptr.Dispose()
        End Try

    End Sub

    Private Sub BomaiLstVew_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BomaiLstVew.GotFocus

    End Sub

    Private Sub BomaiLstVew_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles BomaiLstVew.ItemChecked
        Try
            If Me.BomaiLstVew.CheckedItems.Count > 0 Then
                If Trim(Me.BomaiLstVew.Items(e.Item.Index).SubItems(9).Text) = "Aded" Then
                    e.Item.Checked = 1
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BomaiLstVew_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BomaiLstVew.SelectedIndexChanged

    End Sub

    Private Sub Btnbomok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnbomok.Click
        Try
            Me.txtaiqnty_Leave(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Lstbxprocs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lstbxprocs.SelectedIndexChanged

    End Sub

    Private Sub btnaddnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddnew.Click
        Try
            ToolStripMenuItem2_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            ToolStripMenuItem1_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        Try
            EditToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btndele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndele.Click
        Try
            If Me.BomaiLstVew.SelectedItems.Count > 0 Then
                DeleteToolStripMenuItem_Click(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Try
            ExitToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtRatio_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRatio.Leave
        Try
            If Trim(TxtRatio.Text) <> "" Then
                Me.TxtRatio.BackColor = Color.White
                If IsNumeric(TxtRatio.Text) = False Or Trim(TxtRatio.Text.EndsWith("-")) = True Or Trim(TxtRatio.Text.StartsWith("-")) = True Then
                    MsgBox("Invalid Input! Only numbers are allowed", MsgBoxStyle.Critical, "Enter number like 1,2,3...")
                    TxtRatio.Focus()
                    TxtRatio.SelectAll()
                    Exit Sub
                End If
            Else
                Me.TxtRatio.BackColor = Color.Cyan
                Me.TxtRatio.Focus()
                Me.TxtRatio.SelectAll()

            End If

        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub TxtRatio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRatio.TextChanged

    End Sub

    Private Sub rbaiboth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbaiboth.CheckedChanged, rbaibom.CheckedChanged, rbairaw.CheckedChanged
        Try
            If xFlag = True Then
                set_Condition()
                Spl_Fill_Combobox(SelStrg1, cmbxaiselitm)
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
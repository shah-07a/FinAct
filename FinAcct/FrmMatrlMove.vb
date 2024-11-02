Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmMatrlMove
    Dim MM_cmd As SqlCommand
    Dim MM_rdr As SqlDataReader
    Dim MM_Adptr As SqlDataAdapter
    Dim MM_Dset As DataSet
    Dim MM_cmd1 As SqlCommand
    Dim MM_rdr1 As SqlDataReader
    Dim MM_Adptr1 As SqlDataAdapter
    Dim MM__SplrId As Integer = 0
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim fill_Xcmbx As Boolean = True
    Dim fill_Xcmbx1 As Boolean = True
    Dim TxtCond1, MM_Indx, MM_ItemId, MM_Machid, NxtProcsid As Integer
    Dim PurItmLocId As Integer
    Dim fstProcsid As Integer
    Dim ProcsAry(2000) As String
    Dim LstIndx As Integer = 0
    Dim ResrvStok As Double = 0
    Dim ResrvStok1 As Double = 0
    Dim ResrvStok2 As Double = 0
    Dim xItemType As String = ""

    Private Sub FrmMatrlMove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.DtpMovedt.MinDate = Now.Date
            Me.DtpMovedt.MaxDate = Now.Date
            Me.SplitContainer1.IsSplitterFixed = True
            Me.Width = 920
            Me.SplitContainer1.Panel1.Enabled = False
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpMovedt, Me.DtpMovedt)
            SetControlCurrentDate(Me.DtpMovedt)
            Me.DtpMovedt.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DtpMovedt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpMovedt.GotFocus
        Try
            Me.SplitContainer1.Panel1.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

        Private Sub AllControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpMovedt.KeyDown, CmbxWrkrName.KeyDown _
    , Rbxicode.KeyDown, RbxiName.KeyDown, Txtitmcode.KeyDown, txtmovqnty.KeyDown, txtremark.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DtpMovedt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpMovedt.Leave
        Try
            Dim mXid As Integer = FindMax_MovId()
            Me.lblbatno.Text = Format(Me.DtpMovedt.Value.Date, "yyyyMMdd") & "/" & mXid
        Catch ex As Exception

        End Try
     
    End Sub

    Private Sub Select_2rec_where_Not(ByVal xfield1id As String, ByVal xfield2name As String, ByVal xFieldcond As String, ByVal xFielddt As String, ByVal xFieldordrby As String, ByVal xtblename As String, ByVal xCombobox As ComboBox, ByVal CondStr As String, ByVal Conddt As Date)
        Try
            Dim xStr As String = "Select " & (xfield1id) & "," & (xfield2name) & " from " & (xtblename) & " where " & Trim(xFieldcond) & "= @fldval and   " & Trim(xFielddt) & " <= @fldvaldt order by " & Trim(xFieldordrby) & " "
            MM_Dset = New DataSet
            MM_Dset.Tables.Clear()

            MM_cmd = New SqlCommand(xStr, FinActConn1)
            MM_cmd.Parameters.AddWithValue("@fldval", CondStr)
            MM_cmd.Parameters.AddWithValue("@fldvaldt", Conddt)
            MM_Adptr = New SqlDataAdapter(MM_cmd)
            MM_Dset = New DataSet(MM_cmd.CommandText)
            MM_Adptr.Fill(MM_Dset)
            xCombobox.DataSource = MM_Dset.Tables(0)
            xCombobox.ValueMember = xfield1id
            xCombobox.DisplayMember = xfield2name
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd.Dispose()
            MM_Adptr.Dispose()
        End Try
    End Sub



    Private Sub CmbxWrkrName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWrkrName.GotFocus
        Try
            If Me.CmbxWrkrName.Items.Count > 0 Then
                If Me.CmbxWrkrName.SelectedIndex = -1 Then
                    Me.CmbxWrkrName.SelectedIndex = 0
                End If
            Else
                Fill_Combobox("empid", "empname", "finactempmstr", "EmpDelStatus", CInt(1), Me.CmbxWrkrName)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxWrkrName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWrkrName.Leave
        Try
            If Me.CmbxWrkrName.Items.Count > 0 Then
                If fill_Xcmbx = True Then
                    Select_Wrkrmachine()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxWrkrName_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWrkrName.SelectionChangeCommitted
        Try
            If Me.CmbxWrkrName.Items.Count > 0 Then
                Select_Wrkrmachine()
            End If
        Catch ex As Exception
            fill_Xcmbx = False
        End Try
    End Sub


    Private Sub Select_Wrkrmachine()
        Try
            Dim xStr As String = "finactempmstr_select_workid_where"
            MM_Dset = New DataSet
            MM_Dset.Tables.Clear()

            MM_cmd = New SqlCommand(xStr, FinActConn1)
            MM_cmd.CommandType = CommandType.StoredProcedure
            MM_cmd.Parameters.AddWithValue("@wrkid", Me.CmbxWrkrName.SelectedValue)
            MM_cmd.Parameters.AddWithValue("@cond", 1)
            MM_Adptr = New SqlDataAdapter(MM_cmd)
            MM_Dset = New DataSet(MM_cmd.CommandText)
            MM_Adptr.Fill(MM_Dset)
            Dim xf1 As Integer = MM_Dset.Tables(0).Rows.Count
            For xf1 = 0 To MM_Dset.Tables(0).Rows.Count - 1
                MM_Machid = MM_Dset.Tables(0).Rows(xf1).ItemArray(0).ToString
                Me.lblmachinname.Text = MM_Dset.Tables(0).Rows(xf1).ItemArray(1).ToString
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd.Dispose()
            MM_Adptr.Dispose()
        End Try
    End Sub

    Private Sub Txtitmcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtitmcode.GotFocus
        Try
            Me.Tplitem.Location = New System.Drawing.Point(140, 3)
            Me.Tplitem.Visible = True
            Me.Tplitem.Enabled = True
            Me.Txticode.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txticode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txticode.GotFocus
        Try
            TxtCond1 = 1
            Dim ItmStr As String = Trim(Txticode.Text)
            find_Item_list(ItmStr)
            If TxtCond1 = 4 Then
                Me.Txticode.Enabled = False
                Me.LstVewItem.Focus()
            Else
                Me.Txticode.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txticode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txticode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Trim(Me.Txticode.Text) = "" Then
                    Me.LstVewItem.Focus()
                Else
                    LstVewItem_DoubleClick(sender, e)
                End If
            End If
            If e.KeyCode = Keys.Escape Then
                Me.Tplitem.Enabled = False
                Me.Tplitem.Visible = False
                Me.Tplitem.Location = New System.Drawing.Point(837, 243)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txticode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txticode.TextChanged

        Try
            Dim ItmStr As String = Trim(Txticode.Text)
            find_Item_list(ItmStr)
            For Each itm As ListViewItem In Me.LstVewItem.Items
                itm.BackColor = Color.White
                itm.ForeColor = Color.Black
            Next
            GoToItem(Me.LstVewItem, Me.Txticode)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        'Try
        '    Dim ItmStr As String = Trim(Txticode.Text)
        '    find_Item_list(ItmStr)
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub GoToItem(ByVal LsV As ListView, ByVal Txt As TextBox)
        Try
            Dim itmX As ListViewItem = LsV.FindItemWithText(Trim(Txt.Text), True, 0)
            If Not itmX Is Nothing Then
                itmX.Selected = True
                LstIndx = itmX.Index
                LsV.Items(itmX.Index).Selected = True
                LsV.Items(itmX.Index).BackColor = Color.Blue
                LsV.Items(itmX.Index).ForeColor = Color.White
                itmX.EnsureVisible()
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message) do not uncomment it
            LstIndx = -1
        End Try
    End Sub
    Private Sub find_Item_list(ByVal CurString1 As String)
        Dim i As Integer
        Me.LstVewItem.Items.Clear()
        Try
            MM_cmd = New SqlCommand("FinAct_ItemMstr_Select_Like", FinActConn)
            MM_cmd.CommandType = CommandType.StoredProcedure
            MM_cmd.Parameters.AddWithValue("@Sale_Pur_Type1", "Both")
            MM_cmd.Parameters.AddWithValue("@currval1", Trim(CurString1))

            If Me.Rbxicode.Checked = True Then
                MM_cmd.Parameters.AddWithValue("@currfield1", "itmcode")
            ElseIf Me.RbxiName.Checked = True Then
                MM_cmd.Parameters.AddWithValue("@currfield1", "itmname")
            End If
            If TxtCond1 = 3 Then
                MM_cmd.Parameters.AddWithValue("@currfield1", "itmcatid")
            End If
            MM_rdr = MM_cmd.ExecuteReader
            i = 0
            While (MM_rdr.Read)
                If MM_rdr.HasRows = True Then
                    Dim lstvew1 As ListViewItem
                    lstvew1 = Me.LstVewItem.Items.Add(MM_rdr("itmcode")) '0
                    Me.LstVewItem.Items(i).SubItems.Add(MM_rdr("itmname")) '1
                    Me.LstVewItem.Items(i).SubItems.Add(MM_rdr("itmid")) '2
                    Me.LstVewItem.Items(i).SubItems.Add(MM_rdr("itmratechek")) '3
                    Me.LstVewItem.Items(i).SubItems.Add(MM_rdr("itmreorder")) '4
                    Me.LstVewItem.Items(i).SubItems.Add(MM_rdr("itmmax")) '5
                    Me.LstVewItem.Items(i).SubItems.Add(MM_rdr("itmopnqnty")) '6
                    Me.LstVewItem.Items(i).SubItems.Add(MM_rdr("itmunttype")) '7
                    Me.LstVewItem.Items(i).SubItems.Add(MM_rdr("itmtype1")) '8
                    Me.LstVewItem.Items(i).SubItems.Add(MM_rdr("itmtype")) '9


                End If
                i = i + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd = Nothing
            MM_rdr.Close()
        End Try

    End Sub


    Private Sub LstVewItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.DoubleClick
        Try
            'LstVewItem_Leave(sender, e)
            Sel_itm_xfromLstvew()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LstVewItem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.GotFocus
        Try
            If Me.LstVewItem.Items.Count > 0 Then
                Me.LstVewItem.Items(0).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewItem.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.LstVewItem.Items.Count > 0 Then
                    LstVewItem_DoubleClick(sender, e)
                Else
                    Me.Tplitem.Visible = False
                    Me.Tplitem.Enabled = False
                    Me.Tplitem.Location = New System.Drawing.Point(837, 243)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewItem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewItem.Leave
        Try
            If Me.LstVewItem.Items.Count > 0 Then
                If Not (Me.LstVewItem.SelectedItems.Count) > 0 Then
                    MsgBox("double click or press enter key  on a selected item", MsgBoxStyle.Information, "Select an item")
                    Me.LstVewItem.Focus()

                Else
                    Me.Tplitem.Enabled = False
                    Me.Tplitem.Visible = False
                    Me.Tplitem.Location = New System.Drawing.Point(837, 243)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function SumOf_In_and_Outward_Items(ByVal SalItemId As Integer, ByVal PurItemId As Integer) As Double
        Try
            'If xItemType = "Production" Then
            MM_cmd1 = New SqlCommand("Finact_Sum_In_out_pur_Particularitem", FinActConn2)
            MM_cmd1.CommandType = CommandType.StoredProcedure
            MM_cmd1.Parameters.AddWithValue("@PurItemid", PurItemId)
            'ElseIf xItemType = "Sale" Then
            '    MM_cmd1 = New SqlCommand("Finact_Sum_In_out_Sale_Particularitem", FinActConn2)
            '    MM_cmd1.CommandType = CommandType.StoredProcedure
            '    MM_cmd1.Parameters.AddWithValue("@SaleItemid", PurItemId)
            'End If


            'MM_cmd1.Parameters.AddWithValue("@PurItmlocid", PurItmLocId)
            MM_rdr1 = MM_cmd1.ExecuteReader
            While MM_rdr1.Read
                If MM_rdr1.IsDBNull(1) = False Then
                    ResrvStok = MM_rdr1(1)
                Else
                    ResrvStok = 0
                End If
                If MM_rdr1.IsDBNull(0) = False Then
                    Return MM_rdr1(0)
                Else
                    Return 0
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd1.Dispose()
            MM_rdr1.Close()
        End Try
    End Function
    Private Function Check_StokInDemand_ParticularItem(ByVal CurrItemId As Integer) As Double
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            If xItemType = "Production" Then
                MM_cmd1 = New SqlCommand("finact_Chek_StockInDemand_OfItemDependency_Select", FinActConn2)
                MM_cmd1.CommandType = CommandType.StoredProcedure
                MM_cmd1.Parameters.AddWithValue("@CurrItemId", CurrItemId)
            ElseIf xItemType = "Sale" Then
                MM_cmd1 = New SqlCommand("finact_Chek_StockInDemand_OfItemDependency_Select", FinActConn2)
                MM_cmd1.CommandType = CommandType.StoredProcedure
                MM_cmd1.Parameters.AddWithValue("@CurrItemId", CurrItemId)
            End If
            MM_rdr1 = MM_cmd1.ExecuteReader
            While MM_rdr1.Read
                If MM_rdr1.IsDBNull(0) = False Then
                    Return MM_rdr1(0)
                Else
                    Return 0
                End If
               
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd1.Dispose()
            MM_rdr1.Close()
        End Try
    End Function

    Private Sub txtmovqnty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmovqnty.Leave
        Try

            If Trim(txtmovqnty.Text) <> "" Then
                If IsNumeric(Me.txtmovqnty.Text) = True Then
                    Dim Qval1, Qval2 As Double
                    Qval1 = Me.lblsih.Text
                    Qval2 = Me.txtmovqnty.Text
                    If Qval2 > Qval1 Then
                        ''MsgBox("You can't move quantity more" & " " & Me.lblsih.Text & " " & " than you have", MsgBoxStyle.Critical, "Excess move")
                        ''Me.txtmovqnty.Focus()
                        ''Me.txtmovqnty.SelectAll()
                        ''Exit Sub
                    ElseIf Qval2 = 0 Then
                        MsgBox("Invalid input, quantity should be greater than zero", MsgBoxStyle.Critical, "Zero !!")
                        Me.txtmovqnty.Focus()
                        Me.txtmovqnty.SelectAll()
                        Exit Sub
                    Else
                        '' Me.lstbxprocs.Focus()
                    End If

                End If
            Else
                Me.txtmovqnty.Focus()
                Me.txtmovqnty.SelectAll()
            End If
        Catch ex As Exception
        Finally
            If Trim(Me.txtmovqnty.Text) = "" Then
                Me.txtmovqnty.Text = 1
            End If
        End Try
    End Sub

    Private Sub txtmovqnty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmovqnty.TextChanged
        Try
            If Trim(Me.lblunit.Text) <> "" Then
                If Trim(Me.lblunit.Text) = "Kg" Then
                    Check_Minus_Dot_Kgformat(txtmovqnty)
                End If
            End If
            If Me.Lstvewitmall.Items.Count > 0 Then
                Me.Lstvewitmall.Groups.Clear()
                Me.Lstvewitmall.Items.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chk_Empty_Xvalu()
        Try
            With Me.lblmachinname
                If Trim(.Text) = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    MM_Indx += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With Me.CmbxWrkrName
                If .SelectedIndex = -1 Then
                    .BackColor = Color.Cyan
                    .Focus()
                    MM_Indx += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With Me.txtmovqnty
                If Trim(.Text) = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    MM_Indx += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With Me.Txtitmcode
                If Trim(.Text) = "" Then
                    .BackColor = Color.Cyan
                    .Focus()
                    MM_Indx += 1
                Else
                    .BackColor = Color.White
                End If
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnMMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMMSave.Click
        Try
            If chek_shortStok() Then
                Exit Sub
            End If
            Chk_Empty_Xvalu()
            If MM_Indx <> 0 Then
                MM_Indx = 0
                Exit Sub
            Else
                If Not Me.Lstvewitmall.Groups.Count >= 2 Then
                    MsgBox("Invalid input! Processes should be atleast 2.", MsgBoxStyle.Critical, "Invalid Process Number")
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure to move/issue current item for production", "Item Moving!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                    Return
                Else
                    xCurnt_xRec_xSav_xMmove()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub xCurnt_xRec_xSav_xMmove()
        Dim SetSave As Integer = 0
        Dim MinusAllow As Integer = 0
        Try
            For SetSave = 0 To Me.Lstvewitmall.Items.Count - 1
                Dim MM_ProcsCount As Integer = 0
                MM_cmd = New SqlCommand("Finact_MaterialMovement_Alltable_Insert1", FinActConn)
                MM_cmd.CommandType = CommandType.StoredProcedure
                MM_cmd.Parameters.AddWithValue("@Mmsavestatus", SetSave)
                '=---MaterialMoveMaster
                MM_cmd.Parameters.AddWithValue("@mmdt", Me.DtpMovedt.Value.Date)
                MM_cmd.Parameters.AddWithValue("@mmbomid", MM_ItemId)
                MM_cmd.Parameters.AddWithValue("@Mmbatno", Trim(Me.lblbatno.Text))
                MM_cmd.Parameters.AddWithValue("@Mmqnty1", Me.txtmovqnty.Text)
                MM_cmd.Parameters.AddWithValue("@mmprocsstatus", 0)
                MM_cmd.Parameters.AddWithValue("@mmremrks", Trim(Me.txtremark.Text))
                MM_cmd.Parameters.AddWithValue("@Mmdelstatus", 1)
                MM_cmd.Parameters.AddWithValue("@Mmadusrid", Current_UsrId)
                MM_cmd.Parameters.AddWithValue("@Mmaddt", Now)
                MM_cmd.Parameters.AddWithValue("@mmwrkid", Me.CmbxWrkrName.SelectedValue)
                Dim inx As Integer = Me.Lstvewitmall.Groups.Count
                Dim idg As String = Trim(Me.Lstvewitmall.Items(SetSave).Group.Name)
                MM_cmd.Parameters.AddWithValue("@MMprocsName", Trim(idg))
                Dim MM_QntyPerUnt As Double = Me.Lstvewitmall.Items(SetSave).SubItems(2).Text
                Dim MM_Mqnty As Double = Me.Lstvewitmall.Items(SetSave).SubItems(3).Text
                Dim MM_Itmid As Integer = Me.Lstvewitmall.Items(SetSave).SubItems(7).Text
                Dim MM_Locid As Integer = Me.Lstvewitmall.Items(SetSave).SubItems(10).Text

                MM_cmd.Parameters.AddWithValue("@Mmitemid", MM_Itmid)
                MM_cmd.Parameters.AddWithValue("@Mmqntyperunt", MM_QntyPerUnt)
                MM_cmd.Parameters.AddWithValue("@Mmissuqnty", MM_Mqnty)
                MM_cmd.Parameters.AddWithValue("@Mmovefrom", MM_Locid)
                ' MM_cmd.Parameters.AddWithValue("@MmProcsid", fstProcsid)
                If Trim(Me.Lstvewitmall.Items(SetSave).SubItems(8).Text) = "Issue" Then
                    MinusAllow = 0
                    MM_cmd.Parameters.AddWithValue("@Mmstatus_procs", "UndrProcs")
                    MM_cmd.Parameters.AddWithValue("@MmMinusAllow", MinusAllow)
                Else
                    MM_cmd.Parameters.AddWithValue("@Mmstatus_procs", "N/A")
                    MinusAllow = 1
                    MM_cmd.Parameters.AddWithValue("@MmMinusAllow", MinusAllow)
                End If
                MM_cmd.ExecuteNonQuery()

            Next

            MsgBox("Current Material has been moved to first destination", MsgBoxStyle.Information, "Moved!!")
            Me.Lstvewitmall.Items.Clear()
            Me.Lstvewitmall.Groups.Clear()
            xClr_xVal()
            Me.DtpMovedt.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd.Dispose()
        End Try

    End Sub
    Public Function FindMax_MovId() As Integer
        Try
            Dim MaxSplid As Integer = 0
            MM_cmd = New SqlCommand("select Max(matmovid) from finact_materialmovmaster where  mmdelstatus=1", FinActConn1)
            MM_rdr = MM_cmd.ExecuteReader
            MM_rdr.Read()
            If MM_rdr.IsDBNull(0) = False Then
                MaxSplid = MM_rdr(0)
                Return MaxSplid
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_rdr.Close()
            MM_cmd.Dispose()
        End Try
    End Function
    Private Sub xClr_xVal()
        Try
            Me.lblbatno.Text = ""
            Me.Txtitmcode.Text = ""
            Me.lbldesc.Text = ""
            Me.lblunit.Text = ""
            Me.lblmin.Text = ""
            Me.lblmax.Text = ""
            Me.lblsih.Text = ""
            Me.txtmovqnty.Text = 1
            Me.txtremark.Text = ""
            Me.Lblissueto.Text = ""
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnMMCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMMCancel.Click
        Try
            xClr_xVal()
            Me.Lstvewitmall.Items.Clear()
            Me.Lstvewitmall.Groups.Clear()
            Me.DtpMovedt.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Sel_itm_xfromLstvew()
        Dim ItmAry(0) As String
        Dim ItmLoop As Integer = 0
        Dim Minqnty As Double '= 0
        Dim RatioQnty As Integer = 0
        Dim MinPerUnit As Double ' = 0
        Try
            Me.Lstvewitmall.Items.Clear()
            Me.Lstvewitmall.Groups.Clear()
            If Me.LstVewItem.SelectedItems.Count > 0 Then
                Me.lbldesc.Text = Trim(LstVewItem.SelectedItems.Item(0).SubItems(1).Text)
                Dim CurItemId As Integer = Trim(LstVewItem.SelectedItems.Item(0).SubItems(2).Text)
                Me.lblmin.Text = Trim(LstVewItem.SelectedItems.Item(0).SubItems(4).Text)
                Me.lblmax.Text = Trim(LstVewItem.SelectedItems.Item(0).SubItems(5).Text)
                Me.lblunit.Text = Trim(LstVewItem.SelectedItems.Item(0).SubItems(7).Text)
                xItemType = Trim(LstVewItem.SelectedItems.Item(0).SubItems(9).Text)
                Me.lblsih.Text = FormatNumber(SumOf_In_and_Outward_Items(CurItemId, CurItemId), 3) 'Stok in hand
                Me.LblResStock.Text = FormatNumber(ResrvStok, 3) 'Order in hand
                Dim x1 As Double = Me.lblsih.Text
                Dim x2 As Double = Me.txtmovqnty.Text
                Dim x3 As Double = Me.LblResStock.Text
                Dim x4 As Double = Me.lblmax.Text
                Dim x5 As Double = (x1 + x2)
                Dim x6 As Double = (x5 - x3)
                Me.LblNet.Text = FormatNumber(x1 - x3, 3) 'Balance 
                If x6 > x4 Then
                    MsgBox("Maximum Limit Of Stok Exceeded by :- " & (x6 - x4), MsgBoxStyle.Information, "Limit Exceeded!!!")
                    Me.txtmovqnty.Focus()
                    Me.txtmovqnty.SelectAll()
                    Exit Sub
                End If
                

                MM_ItemId = Trim(LstVewItem.SelectedItems.Item(0).SubItems(2).Text)
                Me.Txtitmcode.Text = Trim(LstVewItem.SelectedItems.Item(0).Text)
                Try
                    MM_cmd = New SqlCommand("Finact_SequelOfProcess_Select", FinActConn)
                    MM_cmd.CommandType = CommandType.StoredProcedure
                    MM_cmd.Parameters.AddWithValue("@bid", MM_ItemId)
                    MM_rdr = MM_cmd.ExecuteReader

                    While MM_rdr.Read = True
                        If MM_rdr.IsDBNull(0) = False Then

                            Me.Lstvewitmall.Groups.Add(Trim(MM_rdr(1)), Trim(MM_rdr(1)))

                            If ItmLoop = 0 Then
                                ItmAry(0) = Trim(MM_rdr(1))
                                'idg = Trim(MM_rdr(1))
                                fstProcsid = Trim(MM_rdr(2))
                            End If
                            If ItmLoop = 1 Then
                                fstProcsid = Trim(MM_rdr(2))
                            End If
                            ProcsAry(ItmLoop) = Trim(MM_rdr(0))
                            ItmLoop += 1
                        End If
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    MM_cmd.Dispose()
                    MM_rdr.Close()
                    xItemType = ""
                End Try
                Try
                    If Trim(LstVewItem.SelectedItems.Item(0).SubItems(8).Text) = "BomItem" Then
                        MM_cmd = New SqlCommand("Finact_BomMstrId_Select_Where_id", FinActConn)
                        MM_cmd.CommandType = CommandType.StoredProcedure
                        MM_cmd.Parameters.AddWithValue("@Bomconid", MM_ItemId)
                        MM_rdr = MM_cmd.ExecuteReader
                        Dim BomAmt As Double = 0
                        Dim Recloop As Integer = 0
                        While MM_rdr.Read = True
                            If MM_rdr.IsDBNull(0) = False Then
                                Try
                                    Dim BomMstrItmid As Integer = MM_rdr(0)
                                    Dim BomMstrQnty As Double = MM_rdr(1)
                                    Dim BomItmName As String = Trim(MM_rdr(2))
                                    Dim ProcsName As String = Trim(MM_rdr(3))
                                    Dim LocName As String = ""
                                    If MM_rdr.IsDBNull(4) = False Then
                                        locname = Trim(MM_rdr(4))
                                    End If


                                    Dim UnitName As String = Trim(MM_rdr(5))
                                    PurItmLocId = Trim(MM_rdr(6))

                                    RatioQnty = MM_rdr(7)
                                    Dim xItype As String = MM_rdr(8)
                                    If xItype = "Trading" Or xItype = "Purchase" Or xItype = "Production" Then
                                        xItemType = "Production"
                                    Else
                                        xItemType = "Sale"
                                    End If

                                    Dim rst As Double = Check_StokInDemand_ParticularItem(BomMstrItmid)

                                    BomAmt = SumOf_In_and_Outward_Items(BomMstrItmid, BomMstrItmid)

                                    Dim BomLstVew As New ListViewItem
                                    BomLstVew.BackColor = Color.Pink
                                    BomLstVew.ForeColor = Color.Black
                                    BomLstVew.Text = Trim(BomItmName) ' 0 Item Name
                                    BomLstVew.SubItems.Add(LocName) '1 Location
                                    BomLstVew.SubItems.Add(FormatNumber(BomMstrQnty, 3)) '2 per unit qnty.
                                    Dim Rqnty, Movqnty As Double
                                    Movqnty = Me.txtmovqnty.Text

                                    If Movqnty < RatioQnty Then
                                        Me.Tplitem.Enabled = False
                                        Me.Tplitem.Visible = False

                                        Me.Tplitem.Location = New System.Drawing.Point(800, 3)
                                        MsgBox("You are going to produce less quantity than required by a " & Chr(13) & BomItmName & ". The ratio of current item is 1:" & RatioQnty & ". System can't allow you to move further?", MsgBoxStyle.Critical, "Invalid Ratio")
                                        xClr_xVal()
                                        Me.Lstvewitmall.Items.Clear()
                                        Me.Lstvewitmall.Groups.Clear()
                                        Me.DtpMovedt.Focus()
                                        Exit Sub
                                    End If
                            
                            Movqnty = Me.txtmovqnty.Text \ RatioQnty
                            Rqnty = Movqnty * BomMstrQnty
                            BomLstVew.SubItems.Add(FormatNumber(Rqnty, 3)) '3 Required qnty.
                            BomLstVew.SubItems.Add(FormatNumber(BomAmt, 3)) '4 Sotck in hand
                            Dim ResQnty As Double = FormatNumber(rst, 3)
                            BomLstVew.SubItems.Add(FormatNumber(ResQnty, 3)) '5 Restricted qnty
                            BomLstVew.SubItems.Add(FormatNumber(BomAmt - Rqnty, 3)) '6 avialable qnty
                            BomLstVew.SubItems.Add(BomMstrItmid) '7 Item Id
                            If Trim(ItmAry(0)) = Trim(ProcsName) Then
                                BomLstVew.SubItems.Add("Issue") '8 current Status
                                If (BomAmt) < Rqnty Then
                                    BomLstVew.BackColor = Color.Yellow
                                    BomLstVew.ForeColor = Color.Black
                                    MinPerUnit = BomMstrQnty
                                    If Recloop = 0 Then
                                        Minqnty = (BomAmt) / MinPerUnit
                                    End If

                                    If Minqnty > (BomAmt) / MinPerUnit Then
                                        Minqnty = (BomAmt) / MinPerUnit
                                    End If
                                    Recloop += 1
                                Else
                                    BomLstVew.BackColor = Color.White
                                    BomLstVew.ForeColor = Color.Black
                                End If
                            Else
                                BomLstVew.SubItems.Add("Not Yet") '8 current Status
                                BomLstVew.BackColor = Color.Cyan
                                BomLstVew.ForeColor = Color.Navy
                            End If
                            BomLstVew.SubItems.Add(UnitName) '9 Unit type
                            BomLstVew.SubItems.Add(PurItmLocId) '10 Location id
                            Dim Shrt As Double = (BomAmt - (Rqnty + ResQnty))
                            BomLstVew.SubItems.Add(FormatNumber(Shrt, 3)) '11 Short id

                            BomLstVew.Group = Me.Lstvewitmall.Groups(ProcsName)
                            Me.Lstvewitmall.Items.Add(BomLstVew)
                                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    xItemType = ""
                End Try
                            End If

                        End While
                        If Minqnty > 0 Then
                            lblSuggest.Text = "Maximum Quantity Suggested By The System Is  " & FormatNumber(Minqnty, 2)
                            Me.lblalrt.Text = Trim("Suggestion!")
                            Me.lblalrt.Visible = True
                            Me.lblSuggest.Visible = True
                        Else
                            Me.lblalrt.Visible = False
                            Me.lblSuggest.Visible = False
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    If Trim(LstVewItem.SelectedItems.Item(0).SubItems(8).Text) = "BomItem" Then
                        MM_cmd.Dispose()
                        MM_rdr.Close()
                    End If
                End Try
                Me.Tplitem.Location = New System.Drawing.Point(800, 3)
                Me.Tplitem.Visible = False
                Me.Tplitem.Enabled = False
                Me.CmbxWrkrName.Focus()
                Me.CmbxWrkrName.SelectAll()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If MM_ItemId <> 0 Then
                Nxt_procesName()
            End If
        End Try
    End Sub

    Private Function chek_shortStok() As Boolean
        For Each ItmVal As ListViewItem In Me.Lstvewitmall.Items
            If Trim(ItmVal.SubItems(8).Text) = "Issue" Then
                Dim IVal1 As Double = ItmVal.SubItems(4).Text
                Dim IVal2 As Double = ItmVal.SubItems(3).Text
                If IVal2 > IVal1 Then
                    MsgBox("Negative Quantity not allowed")
                    Return True
                End If

            End If

        Next
    End Function

    Private Sub txtremark_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtremark.Leave
        Me.BtnMMSave.Focus()
    End Sub

    Private Sub Nxt_procesName()
        Try
            MM_cmd = New SqlCommand("Finact_Finact_ProcessMovementSqlMstr_SelectNxtProcess", FinActConn)
            MM_cmd.CommandType = CommandType.StoredProcedure
            MM_cmd.Parameters.AddWithValue("@bomiid", MM_ItemId)
            MM_cmd.Parameters.AddWithValue("@psqlno", 1)
            MM_rdr = MM_cmd.ExecuteReader
            While MM_rdr.Read = True
                If MM_rdr.IsDBNull(0) = False Then
                    NxtProcsid = MM_rdr(0)
                    Me.Lblissueto.Text = Trim((MM_rdr(1).ToString))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd.Dispose()
            MM_rdr.Close()

        End Try
    End Sub

    Private Sub LstVewItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVewItem.SelectedIndexChanged

    End Sub

    Private Sub BtnMMexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMMexit.Click

        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

   
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
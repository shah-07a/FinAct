Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmMRPlanner
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
            Me.Top = 70
            Me.Left = 10
            
            Me.SplitContainer1.IsSplitterFixed = True
            Me.Width = 900
            Me.SplitContainer1.Panel1.Enabled = False
            Sel_itm_xfromLstvew()
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

    Private Function SumOf_In_and_Outward_Items(ByVal SalItemId As Integer, ByVal PurItemId As Integer) As Double
        Try
            'If xItemType = "Production" Then
            '    MM_cmd1 = New SqlCommand("Finact_Sum_In_out_pur_Particularitem", FinActConn2)
            '    MM_cmd1.CommandType = CommandType.StoredProcedure
            '    MM_cmd1.Parameters.AddWithValue("@PurItemid", PurItemId)
            'ElseIf xItemType = "Sale" Then
            MM_cmd1 = New SqlCommand("Finact_Sum_In_out_Sale_Particularitem", FinActConn2)
            MM_cmd1.CommandType = CommandType.StoredProcedure
            MM_cmd1.Parameters.AddWithValue("@SaleItemid", PurItemId)
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
            'If xItemType = "Production" Then
            '    MM_cmd1 = New SqlCommand("finact_Chek_StockInDemand_OfItemDependency_Select", FinActConn2)
            '    MM_cmd1.CommandType = CommandType.StoredProcedure
            '    MM_cmd1.Parameters.AddWithValue("@CurrItemId", CurrItemId)
            'ElseIf xItemType = "Sale" Then
            MM_cmd1 = New SqlCommand("finact_Chek_StockInDemand_OfItemDependency_Select", FinActConn2)
            MM_cmd1.CommandType = CommandType.StoredProcedure
            MM_cmd1.Parameters.AddWithValue("@CurrItemId", CurrItemId)
            'End If
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
   

    Private Sub Sel_itm_xfromLstvew()
        Dim ItmAry(0) As String
        Dim ItmLoop As Integer = 0
        Dim Minqnty As Double '= 0
        Dim RatioQnty As Integer = 0
        Dim MinPerUnit As Double ' = 0
        Try
            Me.Lstvewitmall.Items.Clear()
            Me.Lstvewitmall.Groups.Clear()

            Try
                MM_ItemId = xMrpCurBomId
                MM_cmd = New SqlCommand("Finact_SequelOfProcess_Select", FinActConn)
                MM_cmd.CommandType = CommandType.StoredProcedure
                MM_cmd.Parameters.AddWithValue("@bid", MM_ItemId)
                MM_rdr = MM_cmd.ExecuteReader

                While MM_rdr.Read = True
                    If MM_rdr.IsDBNull(0) = False Then

                        '  Me.Lstvewitmall.Groups.Add(Trim(MM_rdr(1)), Trim(MM_rdr(1)))

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
            End Try
            Try
                ' If Trim(LstVewItem.SelectedItems.Item(0).SubItems(8).Text) = "BomItem" Then
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
                                LocName = Trim(MM_rdr(4))
                            End If


                            Dim UnitName As String = Trim(MM_rdr(5))
                            PurItmLocId = Trim(MM_rdr(6))
                            RatioQnty = MM_rdr(7)
                            Dim xItype As String = MM_rdr(8)

                            Dim rst As Double = Check_StokInDemand_ParticularItem(BomMstrItmid)

                            BomAmt = SumOf_In_and_Outward_Items(BomMstrItmid, BomMstrItmid)

                            Dim BomLstVew As New ListViewItem
                            BomLstVew.BackColor = Color.Pink
                            BomLstVew.ForeColor = Color.Black
                            BomLstVew.Text = Trim(BomItmName) ' 0 Item Name
                            BomLstVew.SubItems.Add(LocName) '1 Location
                            BomLstVew.SubItems.Add(FormatNumber(BomMstrQnty, 3)) '2 per unit qnty.
                            Dim Rqnty, Movqnty As Double
                            Movqnty = xMrpQnty

                            If Not RatioQnty > 0 Then
                                RatioQnty = 1
                            End If
                            Movqnty = xMrpQnty \ RatioQnty
                            Rqnty = Movqnty * BomMstrQnty
                            BomLstVew.SubItems.Add(FormatNumber(Rqnty, 3)) '3 Required qnty.
                            BomLstVew.SubItems.Add(FormatNumber(BomAmt, 3)) '4 Sotck in hand
                            Dim ResQnty As Double = 0 ' FormatNumber(rst, 3)
                            BomLstVew.SubItems.Add(FormatNumber(ResQnty, 3)) '5 Restricted qnty
                            BomLstVew.SubItems.Add(FormatNumber(BomAmt - Rqnty, 3)) '6 avialable qnty
                            BomLstVew.SubItems.Add(BomMstrItmid) '7 Item Id
                            ' If Trim(ItmAry(0)) = Trim(ProcsName) Then
                            BomLstVew.SubItems.Add("") '8 current Status
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
                            'Else
                            'BomLstVew.SubItems.Add("") '8 current Status
                            'BomLstVew.BackColor = Color.Cyan
                            'BomLstVew.ForeColor = Color.Navy
                            'End If
                            BomLstVew.SubItems.Add(UnitName) '9 Unit type
                            BomLstVew.SubItems.Add(PurItmLocId) '10 Location id
                            Dim Shrt As Double = (BomAmt - (Rqnty + ResQnty))
                            BomLstVew.SubItems.Add(FormatNumber(Shrt, 3)) '11 Short id

                            BomLstVew.Group = Me.Lstvewitmall.Groups(ProcsName)
                            Me.Lstvewitmall.Items.Add(BomLstVew)
                        Catch ex As Exception
                MsgBox(ex.Message)
            End Try
                    End If

                End While
                

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                ' If Trim(LstVewItem.SelectedItems.Item(0).SubItems(8).Text) = "BomItem" Then
                MM_cmd.Dispose()
                MM_rdr.Close()
                'End If
            End Try
           
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
                Dim IVal1 As Double = ItmVal.SubItems(6).Text
                Dim IVal2 As Double = ItmVal.SubItems(3).Text
                If IVal2 > IVal1 Then
                    MsgBox("Negative Quantity not allowed")
                    Return True
                End If

            End If

        Next
    End Function


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
                    ' Me.Lblissueto.Text = Trim((MM_rdr(1).ToString))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MM_cmd.Dispose()
            MM_rdr.Close()

        End Try
    End Sub


    Private Sub BtnMMexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub BtnMMexit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMMexit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
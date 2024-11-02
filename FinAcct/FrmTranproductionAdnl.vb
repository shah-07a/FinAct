Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmTranproductionAdnl
    Dim prod_Adl_Cmd As SqlCommand
    Dim prod_Adl_Rdr As SqlDataReader
    Dim prod_Adl_Cmd1 As SqlCommand
    Dim prod_Adl_Rdr1 As SqlDataReader
    Dim prod_Adl_Adptr As SqlDataAdapter
    Dim prod_Adl_DataSet As DataSet
    Dim Allow_Close As Boolean
    Dim Set_True As Int16 = 0

    Private Sub FrmTranproductionAdnl_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            If Allow_Close = False Then
                Process_Allow_NxtTask = False
            End If
        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub FrmTranproductionAdnl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sel_itm_xfromLstvew()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Sel_itm_xfromLstvew()
        Dim Minqnty As Double '= 0
        Dim RatioQnty As Integer = 0
        Dim MinPerUnit As Double ' = 0
        Dim PrsId As Integer = 0
        Try

            Try
                Me.Lstvewitmall.Groups.Add(Trim(Process_Name), Trim(Process_Name))
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try
            Dim Ax As Integer
            For Ax = 0 To Process_id.Length - 1
                Try
                    prod_Adl_Cmd = New SqlCommand("Finact_MaterialmovProcess_Select_Adl", FinActConn)
                    prod_Adl_Cmd.CommandType = CommandType.StoredProcedure
                    prod_Adl_Cmd.Parameters.AddWithValue("@prsid", Process_id(Ax))
                    PrsId = Process_id(Ax)
                    prod_Adl_Rdr = prod_Adl_Cmd.ExecuteReader
                    Dim BomAmt As Double = 0
                    Dim Recloop As Integer = 0
                    While prod_Adl_Rdr.Read = True
                        If prod_Adl_Rdr.IsDBNull(0) = False Then
                            Try
                                Dim BomMstrItmid As Integer = prod_Adl_Rdr(4)
                                Dim MmInqnty As Double = (prod_Adl_Rdr(7) / prod_Adl_Rdr(6))
                                Dim MstrBomQnty As Double = (prod_Adl_Rdr(18))
                                Dim BomMstrQnty As Double = prod_Adl_Rdr(6)
                                Dim Movqnty As Double = 0
                                Dim Rqd As Integer = Chk_ratio_bomItem(PrsId, BomMstrItmid)
                                If MstrBomQnty >= MmInqnty Then
                                    If (MstrBomQnty - MmInqnty) > Processed_Qnty Then
                                        If MessageBox.Show("Total Quantity of Current Batch is  = " & (MstrBomQnty - MmInqnty) & ", currently you are going to produce quantity =" & Processed_Qnty & Chr(13) _
                                        & "System found item(s), which needs to release on this stage from relative destination." & Chr(13) _
                                        & "As you are going to produce partly, you can release full or partly quantity of the reruired items on this stage" _
                                        & Chr(13) & " Press 'Yes' to release full quanty." & Chr(13) & " Press 'No' to relese quantity currently you required.", _
                                        "Handling Additional Items", MessageBoxButtons.YesNo, MessageBoxIcon.Information, _
                                        MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                            Movqnty = (MstrBomQnty - MmInqnty)
                                        Else
                                            Movqnty = Processed_Qnty
                                        End If
                                    ElseIf (MstrBomQnty - MmInqnty) = Processed_Qnty Then
                                        Movqnty = Processed_Qnty
                                    End If
                                End If
                                If MstrBomQnty = Movqnty Then
                                    Set_True = 1
                                Else
                                    Set_True = 0
                                End If
                                Dim BomItmName As String
                                Dim ProcsName As String = Process_Name
                                Dim LocName As String = ""
                                Dim UnitName As String = ""
                                Dim PurLocId1 As Integer = Trim(prod_Adl_Rdr(5))
                                If prod_Adl_Rdr.IsDBNull(15) = False Then
                                    BomItmName = Trim(prod_Adl_Rdr(15))
                                Else
                                    BomItmName = ""
                                End If

                                If prod_Adl_Rdr.IsDBNull(16) = False Then
                                    LocName = Trim(prod_Adl_Rdr(16))
                                Else
                                    LocName = ""
                                End If
                                If prod_Adl_Rdr.IsDBNull(17) = False Then
                                    UnitName = Trim(prod_Adl_Rdr(17))
                                Else
                                    UnitName = ""
                                End If


                                BomAmt = SumOf_In_and_Outward_Items1(BomMstrItmid, PurLocId1)

                                Dim BomLstVew As New ListViewItem
                                BomLstVew.BackColor = Color.Pink
                                BomLstVew.ForeColor = Color.Black
                                BomLstVew.Text = Trim(BomItmName) ' 0 Item Name
                                BomLstVew.SubItems.Add(LocName) '1 Location
                                BomLstVew.SubItems.Add(FormatNumber(BomMstrQnty, 3)) '2 per unit qnty.
                                Dim Rqnty As Double
                                'Movqnty = Processed_Qnty

                                Rqnty = (Movqnty \ Rqd) * BomMstrQnty
                                BomLstVew.SubItems.Add(FormatNumber(Rqnty, 3)) '3 Required qnty.
                                'Exit Sub
                                BomLstVew.SubItems.Add(FormatNumber(BomAmt, 3)) '4 Sotck in hand
                                Dim ResQnty As Double = 0
                                BomLstVew.SubItems.Add(FormatNumber(ResQnty, 3)) '5 Restricted qnty
                                BomLstVew.SubItems.Add(FormatNumber((BomAmt - ResQnty), 3)) '6 avialable qnty
                                BomLstVew.SubItems.Add(BomMstrItmid) '7 Item Id
                                ' If Trim(ItmAry(0)) = Trim(ProcsName) Then
                                BomLstVew.SubItems.Add("Issue") '8 current Status
                                If (BomAmt - ResQnty) < Rqnty Then
                                    BomLstVew.BackColor = Color.Yellow
                                    BomLstVew.ForeColor = Color.Black
                                    MinPerUnit = BomMstrQnty
                                    If Recloop = 0 Then
                                        Minqnty = (BomAmt - ResQnty) / MinPerUnit
                                    End If

                                    If Minqnty > (BomAmt - ResQnty) / MinPerUnit Then
                                        Minqnty = (BomAmt - ResQnty) / MinPerUnit
                                    End If
                                    Recloop += 1
                                Else
                                    BomLstVew.BackColor = Color.White
                                    BomLstVew.ForeColor = Color.Black
                                End If

                                BomLstVew.SubItems.Add(UnitName) '9 Unit type
                                BomLstVew.SubItems.Add(PurLocId1) '10 Location id
                                BomLstVew.SubItems.Add(PrsId)   '11 Process id
                                BomLstVew.Group = Me.Lstvewitmall.Groups(ProcsName)
                                Me.Lstvewitmall.Items.Add(BomLstVew)
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        End If

                    End While
                    If Minqnty > 0 Then
                        lblsuggest.Text = "Maximum Quantity Suggested By The System Is  " & Minqnty
                        Me.lblalrt.Text = Trim("Suggestion!")
                        Me.lblalrt.Visible = True
                        Me.lblsuggest.Visible = True
                    Else
                        Me.lblalrt.Visible = False
                        Me.lblsuggest.Visible = False
                    End If
                    ' End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally

                    prod_Adl_Cmd.Dispose()
                    prod_Adl_Rdr.Close()

                End Try
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Function SumOf_In_and_Outward_Items1(ByVal PurItemId As Integer, ByVal PurLocId As Integer) As Double
        Try
            prod_Adl_Cmd1 = New SqlCommand("Finact_Sum_In_out_pur_Particularitem", FinActConn2)
            prod_Adl_Cmd1.CommandType = CommandType.StoredProcedure
            prod_Adl_Cmd1.Parameters.AddWithValue("@PurItemid", PurItemId)
            'prod_Adl_Cmd1.Parameters.AddWithValue("@PurItmlocid", PurLocId)
            prod_Adl_Rdr1 = prod_Adl_Cmd1.ExecuteReader
            While prod_Adl_Rdr1.Read
                If prod_Adl_Rdr1.IsDBNull(0) = False Then
                    Return prod_Adl_Rdr1(0)
                Else
                    Return 0
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            prod_Adl_Cmd1.Dispose()
            prod_Adl_Rdr1.Close()
        End Try
    End Function
    Private Function chek1_shortStok() As Boolean
        Try
            For Each ItmVal As ListViewItem In Me.Lstvewitmall.Items
                If Trim(ItmVal.SubItems(8).Text) = "Issue" Then
                    Dim IVal1 As Double = ItmVal.SubItems(6).Text
                    Dim IVal2 As Double = ItmVal.SubItems(3).Text
                    If IVal2 > IVal1 Then
                        MsgBox("Negative Stock is not allowed", MsgBoxStyle.Critical, "Negative Stock")
                        Return True
                    End If

                End If

            Next
        Catch ex As Exception

        End Try
    End Function

    Private Sub BtnAdlOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdlOk.Click
        Try
            If chek1_shortStok() Then
                Me.Lstvewitmall.Focus()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure to move/issue current item for production", "Item Moving!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Return
            Else
                xCurnt_xAdlItem_xSav_xMmove()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub xCurnt_xAdlItem_xSav_xMmove()
        Dim SetSave As Integer = 0
        Dim MinusAllow As Integer = 0
        Try
            For SetSave = 0 To Me.Lstvewitmall.Items.Count - 1
                Dim MM_ProcsCount As Integer = 0
                prod_Adl_Cmd = New SqlCommand("Finact_MaterialMovement_Alltable_AdnlItems_Insert1", FinActConn)
                prod_Adl_Cmd.CommandType = CommandType.StoredProcedure
                Dim prod_Adl_QntyPerUnt As Double = Me.Lstvewitmall.Items(SetSave).SubItems(2).Text
                Dim prod_Adl_Mqnty As Double = Me.Lstvewitmall.Items(SetSave).SubItems(3).Text
                Dim prod_Adl_Itmid As Integer = Me.Lstvewitmall.Items(SetSave).SubItems(7).Text
                Dim prod_Adl_Locid As Integer = Me.Lstvewitmall.Items(SetSave).SubItems(10).Text
                Dim prod_Adl_Procsid As Integer = Me.Lstvewitmall.Items(SetSave).SubItems(11).Text
                prod_Adl_Cmd.Parameters.AddWithValue("@Mmitemid", prod_Adl_Itmid)
                prod_Adl_Cmd.Parameters.AddWithValue("@Mmissuqnty", prod_Adl_Mqnty)
                ''prod_Adl_Cmd.Parameters.AddWithValue("@Mmovefrom", prod_Adl_Locid)
                prod_Adl_Cmd.Parameters.AddWithValue("@Mmprocsid", prod_Adl_Procsid)
                prod_Adl_Cmd.Parameters.AddWithValue("@MmSetTrue", Set_True)
                prod_Adl_Cmd.Parameters.AddWithValue("@Mmdt", MMdate)
                prod_Adl_Cmd.Parameters.AddWithValue("@Mmbatno", MMbatNox)
                prod_Adl_Cmd.Parameters.AddWithValue("@Mmbomid", MMbomidx)
                prod_Adl_Cmd.ExecuteNonQuery()
            Next
            MsgBox("Current Material has been moved to first destination", MsgBoxStyle.Information, "Moved!!")
            Me.Lstvewitmall.Items.Clear()
            Me.Lstvewitmall.Groups.Clear()
            Process_Allow_NxtTask = True
            Allow_Close = True
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            prod_Adl_Cmd.Dispose()
        End Try

    End Sub

    Private Sub BtnAdlcancl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdlcancl.Click
        Try
            Allow_Close = False
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Function Chk_ratio_bomItem(ByVal xPid As Integer, ByVal xBomid As Integer) As Integer
        Try
            prod_Adl_Cmd1 = New SqlCommand("Finact_Bom_Item_Ratio_Select", FinActConn1)
            prod_Adl_Cmd1.CommandType = CommandType.StoredProcedure
            prod_Adl_Cmd1.Parameters.AddWithValue("@mmprocsid1", xPid)
            prod_Adl_Cmd1.Parameters.AddWithValue("@mmitemid1", xBomid)
            prod_Adl_Rdr1 = prod_Adl_Cmd1.ExecuteReader
            While prod_Adl_Rdr1.Read
                If prod_Adl_Rdr1.IsDBNull(0) = False Then
                    Return prod_Adl_Rdr1(0)
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            prod_Adl_Cmd1.Dispose()
            prod_Adl_Rdr1.Close()

        End Try
    End Function

    Private Sub BtnAdlAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdlOk.GotFocus, BtnAdlOk.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdlOk.Leave, BtnAdlcancl.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
End Class
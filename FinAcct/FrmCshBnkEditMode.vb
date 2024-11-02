Imports System.Data
Imports System.Data.SqlClient
Public Class FrmCshBnkEditMode
    Dim Csh_Bnk_Cmd As SqlCommand
    Dim Csh_Bnk_rdr As SqlDataReader
    Dim Csh_Bnk_Sqladptr As SqlDataAdapter
    Dim Csh_Bnk_Dset As DataSet
    Dim Cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim IndxMstr As Integer
    Dim BookName As String = ""
    Dim BookName1 As String = ""
    Dim chk_entry As String = ""
    Dim TranType As String = ""
    Dim TranMode As String = ""
    Dim splrid As Integer = 0
    Dim xBokType As String = ""
    Dim xEdtAddNew As Boolean = False
    Dim xEdtAmt As Double = 0
    Dim xEdtIndx As Integer = 0
    Dim xParentRecId As Integer = 0
    Dim xRecContxx As Integer = 0
    Private Sub FrmCshBnkEditMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 20
            If xCBedtmode_Mode.Trim = "Contra" Then
                Me.BtnCon.Enabled = True
                Me.BtnRecd.Enabled = False
                Me.BtnPay.Enabled = False
                Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbBokName, "Finactsplrmstr", "splrid", "SplrName", "Splrtype", "Splrdelstatus", "Cash Book", "Bank", 1)
                Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxACname, "Finactsplrmstr", "splrid", "SplrName", "Splrtype", "Splrdelstatus", "Cash Book", "Bank", 1)
            Else
                Me.BtnRecd.Enabled = True
                Me.BtnPay.Enabled = True
                Me.BtnCon.Enabled = False
                Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbBokName, "Finactsplrmstr", "splrid", "SplrName", "Splrtype", "Splrdelstatus", "Cash Book", "Bank", 1)
                Fill_Combobox_Dynamiclly_Where_Cond2_NotIn_COND(Me.CmbxACname, "Finactsplrmstr", "splrid", "SplrName", "Splrtype", "Splrdelstatus", "Cash Book", "Bank", 1, "SplrDelStatus", CInt(1))
            End If
            Fill_Combobox("Nrrid", "Narration", "finact_Narration", "NRRDELSTATUS", CInt(1), Me.CmbxNar)
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpkrCbnk, Me.DtpkrCbnk)
            Fill_Combobox("DrwnId", "DrwnName", "Finact_DrawnNameMstr", "DRWNDELSTATUS", CInt(1), Me.CmbxDrawn)
            xFill_SelRecEdtMode()
            Me.DtpkrCbnk.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFill_SelRecEdtMode()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("FinAct_CshBnk_forUpdt_Select ", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xCBedtmode_Vno", CInt(xCBedtmode_Vno))
            FinActRdr = FinActCmd.ExecuteReader
            Dim xChk As Integer = 0
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    If xChk = 0 Then
                        Me.DtpkrCbnk.Value = FinActRdr("CBTranDt")
                        Me.Lblvno.Text = FinActRdr("CBtranVNo")
                        Me.CmbxDrawn.SelectedValue = CInt(FinActRdr("CbTranDrawnOn"))
                        Me.Mskdbxdate.Text = FinActRdr("CbTranDrawnDt")
                        Me.CmbxNar.Text = Trim(FinActRdr("CBtranNratn"))
                        xParentRecId = CInt(FinActRdr("CBtransid"))
                        xRecContxx = CInt(FinActRdr("xRCONT"))
                        If CInt(FinActRdr("CBTranCshRno")) > 0 Then
                            Me.LblCrNo.Text = FinActRdr("CBTranCshRno")
                            Me.LblCrNo.Visible = True
                            Me.Label10.Visible = True
                        Else
                            Me.LblCrNo.Visible = False
                            Me.Label10.Visible = False
                        End If
                    End If
                    If CInt(FinActRdr("xRCONT")) = 1 Then
                        Dim xEtype As String = Trim(FinActRdr("CBtranType"))
                        Me.BtnRecd.Enabled = True
                        Me.BtnPay.Enabled = True
                        Me.BtnCon.Enabled = False
                        If Trim(xEtype) = "Credit" Then
                            Me.EntryType.Text = "Receipt"
                        ElseIf Trim(xEtype) = "Debit" Then
                            Me.EntryType.Text = "Payment"
                        ElseIf Trim(xEtype) = "Contra" Then
                            Me.EntryType.Text = "Contra"
                            Me.BtnRecd.Enabled = False
                            Me.BtnPay.Enabled = False
                            Me.BtnCon.Enabled = True
                        End If
                        Me.CmbBokName.SelectedValue = CInt(FinActRdr("CBtranBokName"))
                        Me.TxtBokAmt.Text = FormatNumber(FinActRdr("CBtranAmtDrCR"), 2) '-==Debit
                        Me.CmbxACname.SelectedValue = CInt(FinActRdr("CBtranCustId"))
                        Me.Txtamt.Text = FormatNumber(FinActRdr("CBtranAmtDrCR"), 2) '-==CREDIT
                        Dim xlitm As ListViewItem
                        xlitm = Me.LstVewAmtDetails.Items.Add(Me.CmbxACname.Text.Trim)
                        xlitm.SubItems.Add(FormatNumber(CDbl(Me.Txtamt.Text), 2))
                        xlitm.SubItems.Add(Me.CmbxACname.SelectedValue)
                        xlitm.SubItems.Add(CInt(FinActRdr("CBtransid")))
                        xlitm.SubItems.Add(CInt(1)) ' Existed Entry
                        xlitm.SubItems.Add(FinActRdr("CbTranSpltStatus")) '
                    ElseIf CInt(FinActRdr("xRCONT")) > 1 Then
                        If xChk = 0 Then
                            Me.CmbBokName.SelectedValue = CInt(FinActRdr("CBtranCustId"))
                            Me.TxtBokAmt.Text = FormatNumber(FinActRdr("CBtranAmtDrCR"), 2) '-==Debit
                            Dim xEtype As String = Trim(FinActRdr("CBtranType"))
                            Me.BtnRecd.Enabled = True
                            Me.BtnPay.Enabled = True
                            Me.BtnCon.Enabled = False
                            If Trim(xEtype) = "Debit" Then
                                Me.EntryType.Text = "Receipt"
                            ElseIf Trim(xEtype) = "Credit" Then
                                Me.EntryType.Text = "Payment"
                            End If
                        Else
                            Me.CmbxACname.SelectedValue = CInt(FinActRdr("CBtranCustId"))
                            Me.Txtamt.Text = FormatNumber(FinActRdr("CBtranAmtDrCR"), 2) '-==CREDIT
                            Dim xlitm As ListViewItem
                            xlitm = Me.LstVewAmtDetails.Items.Add(Me.CmbxACname.Text.Trim)
                            xlitm.SubItems.Add(FormatNumber(CDbl(Me.Txtamt.Text), 2))
                            xlitm.SubItems.Add(Me.CmbxACname.SelectedValue)
                            xlitm.SubItems.Add(CInt(FinActRdr("CBtransid")))
                            xlitm.SubItems.Add(CInt(1)) ' Existed Entry
                            xlitm.SubItems.Add(FinActRdr("CbTranSpltStatus")) '
                        End If
                    End If
                End If
                xChk += 1
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            Me.Txtamt.Text = FormatNumber(xAmtTotal(), 2)
            If Me.EntryType.Text.Trim = "Receipt" Then
                Me.BtnRecd.Focus()
            ElseIf Me.EntryType.Text.Trim = "Payment" Then
                Me.BtnPay.Focus()
            ElseIf Me.EntryType.Text.Trim = "Contra" Then
                Me.BtnCon.Focus()
            End If
        End Try
    End Sub
    Private Sub BtnRecd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecd.Click
        Try
            EntryType.Text = "Receipt"
            Panel2.Enabled = True

            LblDr.Visible = True
            LblDr.Text = "Amount is Being Credited"
            LblCr.Visible = True
            LblCr.Text = "Amount is Being Debited"
            DtpkrCbnk.Focus()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub BtnPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPay.Click
        Try
            EntryType.Text = "Payment"
            Panel2.Enabled = True
            LblDr.Visible = True
            LblDr.Text = "Amount is Being Debited"
            LblCr.Visible = True
            LblCr.Text = "Amount is Being Credited"
            DtpkrCbnk.Focus()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub BtnCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon.Click
        Try
            EntryType.Text = "Contra"
            LblDr.Visible = True
            LblDr.Text = "Amount is Being Credited"

            LblCr.Visible = True
            LblCr.Text = "Amount is Being Debited"

            Panel2.Enabled = True
            If EntryType.Text.Trim = "Contra" Then
                fetch_bokname(Me.CmbxACname)
            End If
            DtpkrCbnk.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            Chk_val()
            If IndxMstr <> 0 Then
                IndxMstr = 0
                Exit Sub
            Else
                If CDbl(Me.Txtamt.Text) <> CDbl(Me.TxtBokAmt.Text) Then
                    MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure to Update current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    CshBnkSaverec()
                Else
                    Return
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CshBnkSaverec()
        Try
            Dim Contsplrid As Integer
            Dim ContCashid As Integer

            ContCashid = Me.CmbBokName.SelectedValue
            If Trim(EntryType.Text) = "Contra" Then
                TranType = "Contra"
                Contsplrid = Me.CmbxACname.SelectedValue
            Else
                splrid = Me.CmbxACname.SelectedValue
            End If

            If Trim(EntryType.Text) = "Receipt" Then
                TranType = "Credit"
                chk_entry = "Receipt"
            ElseIf Trim(EntryType.Text) = "Payment" Then
                TranType = "Debit"
                chk_entry = "Payment"
            ElseIf Trim(EntryType.Text) = "Contra" Then
                TranType = "Contra"
                chk_entry = "Contra"
            End If
            BookName = Fetch_BokType(Me.CmbBokName.SelectedValue)
            BookName1 = Fetch_BokType(Me.CmbxACname.SelectedValue)
            If Trim(EntryType.Text) = "Contra" And BookName = Trim("Cash Book") And BookName1 <> Trim("Cash Book") Then
                TranMode = "CshBnk"
            ElseIf Trim(EntryType.Text) = "Contra" And BookName <> Trim("Cash Book") And BookName1 = Trim("Cash Book") Then
                TranMode = "BnkCsh"
            ElseIf Trim(EntryType.Text) = "Contra" And BookName <> Trim("Cash Book") And BookName1 <> Trim("Cash Book") Then
                TranMode = "BnkBnk"
            ElseIf Trim(EntryType.Text) = "Contra" And BookName = Trim("Cash Book") And BookName1 = Trim("Cash Book") Then
                TranMode = "CshCsh"
            ElseIf Trim(EntryType.Text) = "Receipt" And BookName = Trim("Cash Book") Then
                TranMode = "Csh"
            ElseIf Trim(EntryType.Text) = "Receipt" And BookName <> Trim("Cash Book") Then
                TranMode = "Bnk"
            ElseIf Trim(EntryType.Text) = "Payment" And BookName = Trim("Cash Book") Then
                TranMode = "Csh"
            ElseIf Trim(EntryType.Text) = "Payment" And BookName <> Trim("Cash Book") Then
                TranMode = "Bnk"
            End If
            Try

                If TranType <> "Contra" Then
                    Dim SetContr As Integer = Me.LstVewAmtDetails.Items.Count
                    Dim xNewSplrid As Integer = 0
                    Dim xNewBokId As Integer = 0
                    Dim xNewSplt As Integer = 0
                    Dim xNewType As String = ""
                    Dim Amt As Double = 0
                    Dim xCurTransid As Integer = 0

                    For xxSveContr As Integer = 0 To SetContr '- 1
                        If SetContr > 1 Then
                            If xxSveContr = 0 Then
                                xNewSplrid = ContCashid
                                xNewBokId = 0
                                xNewSplt = 1
                                If chk_entry.Trim = "Receipt" Then
                                    TranType = "Debit"
                                Else
                                    TranType = "Credit"
                                End If
                                Amt = FormatNumber(CDbl(Txtamt.Text), 2)
                                xCurTransid = xParentRecId
                            Else
                                xNewSplt = 0
                                If chk_entry.Trim = "Receipt" Then
                                    TranType = "Credit"
                                Else
                                    TranType = "Debit"
                                End If
                                xNewSplrid = CInt(Me.LstVewAmtDetails.Items(xxSveContr - 1).SubItems(2).Text)
                                xNewBokId = 0
                                Amt = CDbl(Me.LstVewAmtDetails.Items(xxSveContr - 1).SubItems(1).Text)
                                Dim xEdtFlg As Integer = CInt(Me.LstVewAmtDetails.Items(xxSveContr - 1).SubItems(4).Text)
                                If xEdtFlg = 1 Then 'Existed Record
                                    xCurTransid = CInt(Me.LstVewAmtDetails.Items(xxSveContr - 1).SubItems(3).Text)

                                ElseIf xEdtFlg = 2 Then 'New Record
                                    xCurTransid = CInt(0)
                                End If

                            End If
                        Else
                            Amt = FormatNumber(CDbl(Txtamt.Text), 2)
                            xNewSplrid = splrid
                            xNewBokId = ContCashid
                            xCurTransid = xParentRecId
                        End If
                        If SetContr = 1 And xxSveContr = 1 Then Exit Sub
                        If Me.BtnAdd.Text = "&Update" Then
                            Csh_Bnk_Cmd = New SqlCommand("Finact_CshBnk_Update", FinActConn)
                            Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
                            Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranCustId", xNewSplrid)
                            Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranedtdt", Now)
                            Csh_Bnk_Cmd.Parameters.AddWithValue("@cbedtusrid", Current_UsrId)
                            Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranVNo", CInt(Me.Lblvno.Text))
                            Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtransid", CInt(xCurTransid))
                        End If
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtrandelstatus", 1)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranAmtDrCr", (Amt))
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranBokName", xNewBokId)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranDt", DtpkrCbnk.Value.Date)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranmode", TranMode)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranNraTn", Trim(CmbxNar.Text))
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranType", TranType)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CbTranDrawnOn", CInt(Me.CmbxDrawn.SelectedValue))
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CbTranDrawndt", Me.Mskdbxdate.Text)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranCshRno", CInt(Me.LblCrNo.Text))
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CbTranSpltStatus", CInt(xNewSplt))
                        Csh_Bnk_Cmd.ExecuteNonQuery()
                    Next '--xxSveContr
                ElseIf TranType = "Contra" Then
                    If Me.BtnAdd.Text = "&Update" Then
                        Csh_Bnk_Cmd = New SqlCommand("Finact_CshBnk_Update", FinActConn)
                        Csh_Bnk_Cmd.CommandType = CommandType.StoredProcedure
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranedtdt", Now)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranCustId", Contsplrid)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@cbedtusrid", Current_UsrId)
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranVNo", CInt(Me.Lblvno.Text))
                        Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtransid", CInt(Me.LstVewAmtDetails.Items(0).SubItems(3).Text))
                    End If
                    Dim Amt1 As Double
                    Amt1 = FormatNumber(Txtamt.Text, 2)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranAmtDrCr", (Amt1))
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtrandelstatus", 1)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranBokName", ContCashid)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBTranDt", DtpkrCbnk.Value.Date)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranmode", TranMode)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranNraTn", Trim(CmbxNar.Text))
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CBtranType", TranType)
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CbTranDrawnOn", CInt(Me.CmbxDrawn.SelectedValue))
                    Csh_Bnk_Cmd.Parameters.AddWithValue("@CbTranDrawndt", Me.Mskdbxdate.Text)
                    Csh_Bnk_Cmd.ExecuteNonQuery()
                End If
                MsgBox("Record has been Successfully Updated")
                For Each xLi1 As ListViewItem In Me.LstVewAmtDetailsBackup.Items
                    xDel_A_Rec_FromTable_dynamiclyInLoop("FinactCshBnk", "CbTransid", CInt(xLi1.SubItems(3).Text))
                Next

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Csh_Bnk_Cmd = Nothing
                Me.Close()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub fetch_bokname(ByVal xCmboBox As ComboBox)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Csh_Bnk_Cmd = New SqlCommand("select splrid,splrname from Finactsplrmstr where SPLRDELSTATUS=1 AND splrtype In ( 'Bank'  , 'Cash Book' ) order by splrname ", FinActConn)

            Csh_Bnk_Sqladptr = New SqlDataAdapter(Csh_Bnk_Cmd)
            Csh_Bnk_Dset = New DataSet(Csh_Bnk_Cmd.CommandText)
            Csh_Bnk_Dset.Tables.Clear()
            Csh_Bnk_Sqladptr.Fill(Csh_Bnk_Dset)

            xCmboBox.DataSource = Csh_Bnk_Dset.Tables(0)
            xCmboBox.ValueMember = "Splrid"
            xCmboBox.DisplayMember = "Splrname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Csh_Bnk_Cmd.Dispose()
            Csh_Bnk_Sqladptr.Dispose()
        End Try


    End Sub

    Private Function Fetch_BokType(ByVal BokId As Integer) As String
        Fetch_BokType = ""
        Try

            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Csh_Bnk_Cmd = New SqlCommand("select splrid,splrtype from Finactsplrmstr where SPLRDELSTATUS=1 AND splrid=@B_id", FinActConn)
            Csh_Bnk_Cmd.Parameters.AddWithValue("@B_id", BokId)
            Csh_Bnk_rdr = Csh_Bnk_Cmd.ExecuteReader
            While Csh_Bnk_rdr.Read()
                If Csh_Bnk_rdr.IsDBNull(0) = False Then
                    Return Csh_Bnk_rdr(1)
                Else
                    Return ""
                End If

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Csh_Bnk_rdr.Close()
            Csh_Bnk_Cmd = Nothing

        End Try

    End Function
    Private Sub Chk_val()
        Try
            With Lblvno
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip

                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With CmbBokName
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip

                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With CmbxACname

                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip

                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If

            End With

            With Txtamt
                If Trim(.Text) = "" Or .Text = 0 Then
                    .BackColor = Color.PapayaWhip

                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With CmbxNar
                If Trim(.Text) = "" Then
                    .BackColor = Color.PapayaWhip

                    IndxMstr += 1
                Else
                    .BackColor = Color.White
                End If
            End With
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CmbBokName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBokName.GotFocus
        'Done by Rm
        Try
            If xCmbxRefresh = True Then
                fetch_bokname(Me.CmbxACname)
            End If
            If Me.CmbBokName.Items.Count > 0 Then
                If Me.CmbBokName.SelectedIndex = -1 Then
                    Me.CmbBokName.SelectedIndex = 0
                End If
            End If

            Me.CmbBokName.DroppedDown = True

            Me.CmbBokName.SelectAll()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbBokName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBokName.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbBokName) = True Then
                Panel3.Enabled = True

                xBokType = xDynamic_Find_xAnItem_xInA_Table_1cond_String("SplrType", "Splrid", CInt(Me.CmbBokName.SelectedValue), "Finactsplrmstr")
                If xBokType.Trim = "Cash Book" And EntryType.Text = "Receipt" Then
                    If xIniCshRecptNo = 0 Then
                        CmbxACname.Focus()
                        Exit Sub
                    End If

                    Me.Label10.Visible = True
                    Me.LblCrNo.Visible = True

                    Me.LblCrNo.Text = xSetCRNO(xIniCshRecptNo)
                Else
                    Me.Label10.Visible = False
                    Me.LblCrNo.Visible = False
                    Me.LblCrNo.Text = 0
                End If
                Me.TxtBokAmt.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Function xSetCRNO(ByVal xxCRNO As Integer) As Integer
        Try
            If xxCRNO > 0 Then
                Dim xMXX As Integer = xFetchMxVal_dynamic("FINACTCSHBNK", "CBTranCshRno")
                If xMXX > 0 Then
                    Return xMXX + 1
                Else
                    Return xxCRNO
                End If
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Sub Txtamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtamt.GotFocus
        Try
            Me.Txtamt.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtamt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtamt.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Txtamt_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtamt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtamt.Leave
        Try
            If Len(Me.Txtamt.Text.Trim) = 0 Then
                Me.Txtamt.Focus()
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

            If xChk_numericValidation(Me.Txtamt) = False Then
                If Me.EntryType.Text.Trim = "Contra" And CDbl(Me.TxtBokAmt.Text) <> CDbl(Me.Txtamt.Text) Then
                    MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                    Me.Txtamt.Focus()
                    Exit Sub
                End If
                If CInt(xRecContxx) = 1 And CDbl(Me.TxtBokAmt.Text) <> CDbl(Me.Txtamt.Text) Then
                    MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                    Me.Txtamt.Focus()
                    Exit Sub
                End If
                Txtamt.Text = FormatNumber(Txtamt.Text, 2)
                Me.BtnOkAmt.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function xAmtTotal() As Double
        Try
            Dim xxAmtTotl As Double = 0
            If Me.LstVewAmtDetails.Items.Count > 0 Then
                For Each xitm As ListViewItem In Me.LstVewAmtDetails.Items
                    xxAmtTotl += xitm.SubItems(1).Text
                Next
            End If
            Return xxAmtTotl
        Catch ex As Exception

        End Try

    End Function
    Private Sub CmbxACname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxACname.GotFocus
        Try
            If xCmbxRefresh = True Then
                If Trim(EntryType.Text) = "Contra" Then
                    fetch_bokname(Me.CmbxACname)
                Else
                    fetch_splr_Name(Me.CmbxACname)
                End If
            End If

            If Me.CmbxACname.Items.Count > 0 Then
                If Me.CmbxACname.SelectedIndex = -1 Then
                    Me.CmbxACname.SelectedIndex = 0
                End If
            End If

            Me.CmbxACname.DroppedDown = True

            Me.CmbxACname.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Trannar_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            If CmbxNar.Text <> "" Then
                BtnAdd.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub fetch_splr_Name(ByVal x2Combox As ComboBox)
        Try
            Csh_Bnk_Cmd = New SqlCommand("select splrid,splrname from Finactsplrmstr where SPLRDELSTATUS=1 AND splrtype not In ( 'Bank'  , 'Cash Book' ) order by splrname ", FinActConn)

            Csh_Bnk_Sqladptr = New SqlDataAdapter(Csh_Bnk_Cmd)
            Csh_Bnk_Dset = New DataSet(Csh_Bnk_Cmd.CommandText)
            Csh_Bnk_Dset.Tables.Clear()
            Csh_Bnk_Sqladptr.Fill(Csh_Bnk_Dset)

            x2Combox.DataSource = Csh_Bnk_Dset.Tables(0)
            x2Combox.ValueMember = "Splrid"
            x2Combox.DisplayMember = "Splrname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Csh_Bnk_Cmd.Dispose()
            Csh_Bnk_Sqladptr.Dispose()
        End Try

    End Sub
    Private Sub BtnaLL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRecd.GotFocus, BtnAdd.GotFocus, BtnClose.GotFocus, BtnCon.GotFocus, BtnPay.GotFocus
        Try
            Try
                Dim xBtn As Button = CType(sender, Button)
                xBtn.BackColor = Color.Blue
                If xBtn.Name.Trim = "BtnRecd" Or xBtn.Name.Trim = "BtnPay" Or xBtn.Name.Trim = "BtnCon" Then
                    xBtn.ForeColor = Color.White
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnAdd.KeyDown, BtnClose.KeyDown, BtnCon.KeyDown, BtnRecd.KeyDown, CmbBokName.KeyDown, CmbxACname.KeyDown, DtpkrCbnk.KeyDown, EntryType.KeyDown, Label1.KeyDown, Label3.KeyDown, Label4.KeyDown, Label5.KeyDown, Label6.KeyDown, Label7.KeyDown, LblCr.KeyDown, LblDr.KeyDown, Lblvno.KeyDown, Panel1.KeyDown, Panel3.KeyDown, Panel2.KeyDown, Panel4.KeyDown, Label9.KeyDown, Label12.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub CmbBokName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbBokName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbBokName_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxACname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxACname.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxACname_Leave(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TranNar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxNar.GotFocus
        Try
            If xCmbxRefresh = True Then
                Fill_Combobox("Nrrid", "Narration", "finact_Narration", "NRRDELSTATUS", CInt(1), Me.CmbxNar)
            End If
            Me.CmbxNar.DroppedDown = True
            Me.CmbxNar.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxACname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxACname.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxACname) = True Then
                If EntryType.Text = "Contra" Then
                    Me.Txtamt.Enabled = False
                    Me.BtnOkAmt.Focus()
                Else
                    Me.Txtamt.Enabled = True
                    Me.Txtamt.Focus()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Allcontrolss_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrCbnk.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub TranNar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxNar.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.BtnAdd.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub BtnALL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Leave, BtnClose.Leave, BtnCon.Leave, BtnPay.Leave, BtnRecd.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
            If xBtn.Name.Trim = "BtnRecd" Or xBtn.Name.Trim = "BtnPay" Or xBtn.Name.Trim = "BtnCon" Then
                xBtn.ForeColor = Color.Navy
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnbok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnbok.Click
        Try
            xCall_LinkFrm(FrmActMstr, Me.CmbBokName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAct.Click
        Try
            xCall_LinkFrm(FrmActMstr, Me.CmbxACname)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNarr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNarr.Click
        Try
            xCall_LinkFrm(FrmNarrationMstr, Me.CmbxNar)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxNar_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxNar.Leave
        Try
            '' CheckBlank_Cmbx(Me.CmbxNar)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDrawn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDrawn.Click
        Try
            xCall_LinkFrm(FrmDrawnNameMstr, Me.CmbxDrawn)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxDrawn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDrawn.GotFocus
        Try
            If xCmbxRefresh = True Then
                Fill_Combobox("DrwnId", "DrwnName", "Finact_DrawnNameMstr", "DRWNDELSTATUS", CInt(1), Me.CmbxDrawn)
            End If
            Me.CmbxDrawn.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxDrawn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxDrawn.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Mskdbxdate.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Mskdbxdate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mskdbxdate.GotFocus
        Try
            Me.Mskdbxdate.SelectAll()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Mskdbxdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Mskdbxdate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxNar.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Mskdbxdate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mskdbxdate.Leave
        Try
            If Me.Mskdbxdate.Text = "  /  /" Then
                Me.Mskdbxdate.Text = "00/00/0000"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTNoK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNoK.Click
        Try
            TxtBokAmt_Leave(sender, e)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub TxtBokAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBokAmt.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.TxtBokAmt_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBokAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBokAmt.Leave
        Try
            If Len(Me.TxtBokAmt.Text.Trim) = 0 Then
                Me.TxtBokAmt.Focus()
                Exit Sub
            End If

            If xChk_numericValidation(Me.TxtBokAmt) = False Then
                If Me.TxtBokAmt.Text = 0 Then
                    Me.TxtBokAmt.Focus()
                    Me.TxtBokAmt.SelectAll()
                    Exit Sub
                End If
                Me.TxtBokAmt.Text = FormatNumber(CDbl(Me.TxtBokAmt.Text), 2)
                Me.Txtamt.Text = FormatNumber(CDbl(Me.TxtBokAmt.Text), 2)
                Me.CmbxACname.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnOkAmt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOkAmt.Click
        Try
            Dim xLstTotal As Double = CDbl(xAmtTotal())
            If xEdtAddNew = False Then
                xLstTotal = xLstTotal - xEdtAmt
            End If
          
            Dim xCurAmt As Double = CDbl(Me.Txtamt.Text)

            If CDbl(xLstTotal) + CDbl(xCurAmt) = CDbl(Me.TxtBokAmt.Text) Then
                Me.Txtamt.Text = FormatNumber(CDbl(xLstTotal) + CDbl(xCurAmt), 2, , TriState.False)
                Me.Panel2.Enabled = False
                Me.Panel3.Enabled = False
                Me.CmbxDrawn.Focus()
            ElseIf CDbl(xLstTotal) + CDbl(xCurAmt) > CDbl(Me.TxtBokAmt.Text) Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                Me.Txtamt.Focus()
                Exit Sub
            Else
                Me.Txtamt.Text = CDbl(Me.TxtBokAmt.Text) - (CDbl(xLstTotal) + CDbl(xCurAmt))

                Me.CmbxACname.Focus()
            End If
            If xEdtAddNew = True Then
                If Me.EntryType.Text.Trim = "Contra" Then
                    MsgBox("Invalid Mode!")
                Else
                    Dim xlitm As ListViewItem
                    xlitm = Me.LstVewAmtDetails.Items.Add(Me.CmbxACname.Text.Trim)
                    xlitm.SubItems.Add(FormatNumber(CDbl(xCurAmt), 2))
                    xlitm.SubItems.Add(Me.CmbxACname.SelectedValue)
                    xlitm.SubItems.Add(CInt(0))
                    xlitm.SubItems.Add(CInt(2))
                    xlitm.SubItems.Add(0)
                End If
            ElseIf xEdtAddNew = False Then
                Me.LstVewAmtDetails.Items(xEdtIndx).SubItems(0).Text = Me.CmbxACname.Text.Trim
                Me.LstVewAmtDetails.Items(xEdtIndx).SubItems(1).Text = FormatNumber(CDbl(xCurAmt), 2)
                Me.LstVewAmtDetails.Items(xEdtIndx).SubItems(2).Text = Me.CmbxACname.SelectedValue
            End If
            If CDbl(Me.TxtBokAmt.Text) - (CDbl(xLstTotal) + CDbl(xCurAmt)) > 0 Then
                xEdtAddNew = True
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnokAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOkAmt.GotFocus, BTNoK.GotFocus

        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTNokAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNoK.Leave, BtnOkAmt.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteSelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSelectedToolStripMenuItem.Click
        Try
            If Me.LstVewAmtDetails.SelectedItems.Count > 0 Then
                If Me.EntryType.Text.Trim = "Contra" Then
                    MsgBox("Invalid Mode!")
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure to delete current selected record(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    For Each xlxx As ListViewItem In Me.LstVewAmtDetails.SelectedItems
                        If CInt(xlxx.SubItems(4).Text) = 1 Then
                            xFillLstVewAmtDetailsBakup(xlxx) '== Only already existed items needs to take backup.
                        End If
                        xlxx.Remove()
                    Next
                    MsgBox("Current record(s) has been successfully deleted", MsgBoxStyle.Information, Me.Text)
                    Me.LstVewAmtDetails.Focus()
                Else
                    Return
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFillLstVewAmtDetailsBakup(ByVal xSelLstItm As ListViewItem)
        Try
            Dim xlitm As ListViewItem
            xlitm = Me.LstVewAmtDetailsBackup.Items.Add(xSelLstItm.SubItems(0).Text.Trim)
            xlitm.SubItems.Add(FormatNumber(CDbl(xSelLstItm.SubItems(1).Text), 2))
            xlitm.SubItems.Add(xSelLstItm.SubItems(2).Text)
            xlitm.SubItems.Add(CInt(xSelLstItm.SubItems(3).Text))
            xlitm.SubItems.Add(CInt(xSelLstItm.SubItems(4).Text)) ' Existed Entry
            xlitm.SubItems.Add(xSelLstItm.SubItems(5).Text) '
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        Try
            Me.BtnAdd_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.BtnClose_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            xEdtAddNew = False
            If Me.LstVewAmtDetails.SelectedItems.Count = 1 Then
                Me.CmbxACname.SelectedValue = CInt(Me.LstVewAmtDetails.SelectedItems(0).SubItems(2).Text)
                xEdtAmt = CDbl(Me.LstVewAmtDetails.SelectedItems(0).SubItems(1).Text)
                xEdtIndx = CInt(Me.LstVewAmtDetails.SelectedItems(0).Index)
                Me.Txtamt.Text = FormatNumber(xEdtAmt, 2)
                Me.Txtamt.Enabled = True
                Me.Txtamt.Focus()
                Me.Txtamt.SelectAll()
            Else
                Me.Txtamt.Enabled = False
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            xEdtAddNew = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtamt.TextChanged

    End Sub
End Class
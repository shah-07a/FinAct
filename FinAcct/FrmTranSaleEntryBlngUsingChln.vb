Imports System.Data
Imports System.Data.SqlClient
Public Class FrmTranSaleEntryBlngUsingChln
    Dim xxRdr As SqlDataReader
    Dim TpoCmd1 As SqlCommand
    Dim TpoRdr1 As SqlDataReader
    Private Sub AllCntrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpBilldt.KeyDown _
    , TxtChrgsTxable.KeyDown, TxtDis.KeyDown, TxtGrand.KeyDown, TxtInVat.KeyDown, TxtInVatSurChrgs.KeyDown, TxtOthrChrgs.KeyDown, TxtRondOff.KeyDown _
    , TxtTxAble.KeyDown, TxtTxAble.KeyDown, TxtValue.KeyDown, TxtInvNo.KeyDown, TxtDisRate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub TxtInvNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtInvNo.Leave
        Try
            If Len(Me.TxtInvNo.Text.Trim) = 0 Then
                Me.TxtInvNo.BackColor = Color.Cyan
                Exit Sub
            Else
                Me.TxtInvNo.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmTranPurEntryBlngUsingChln_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Dim cond As String = "Purchase"
            Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", CmbxVATrate, cond, "DELSTATUS", CInt(1))
            Fill_Combobox_DistinctSplrid_PurEntryDetails(Me.CmbxSplr)
            Me.DgChlnInv.Rows.Clear()
            Me.DtpBilldt.MinDate = FinStartDt.Date
            Me.DtpBilldt.MaxDate = FinEnddt.Date
            If Curr_MaxId() > 0 Then
                Me.DtpBilldt.Value = Curr_Maxdate()
            Else
                Me.DtpBilldt.Value = Now
            End If

            Me.TxtInvNo.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Function Curr_Maxdate() As Date
        Try
            Dim Curr_MaxPurdt As Date
            TpoCmd1 = New SqlCommand("select max(purentdt) from finactpurentry where purentdelstatus=1", FinActConn1)
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.IsDBNull(0) = False Then
                Curr_MaxPurdt = TpoRdr1(0)
                Return Curr_MaxPurdt
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoRdr1.Close()
            TpoCmd1.Dispose()
        End Try

    End Function
    Private Function Curr_MaxId() As Integer
        Try
            Dim Curr_MaxPurid As Integer = 0
            TpoCmd1 = New SqlCommand("select max(purentid) from finactpurentry ", FinActConn1)
            TpoRdr1 = TpoCmd1.ExecuteReader
            TpoRdr1.Read()
            If TpoRdr1.IsDBNull(0) = False Then
                Curr_MaxPurid = TpoRdr1(0)
            Else
                Curr_MaxPurid = 0
            End If
            Return Curr_MaxPurid
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TpoRdr1.Close()
            TpoCmd1.Dispose()
        End Try

    End Function
    Private Sub CmbxVATrate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxVATrate.GotFocus
        Try
            Me.CmbxVATrate.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxVATrate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxVATrate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxVATrate_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxVATrate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxVATrate.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxVATrate) = True Then
                xCalValues()
                Me.LstVewChllans.Focus()
                Me.LstVewChllans.Items(0).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fill_Combobox_DistinctSplrid_PurEntryDetails(ByVal Xcombobx As ComboBox)
        Dim xStr As String = "Finact_PurEntry_Details_challanBill_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            FinActCmd = New SqlCommand(xStr, FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            SqlAdptr = New SqlDataAdapter(FinActCmd)
            dtaset = New DataSet(FinActCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = "Splrid"
            Xcombobx.DisplayMember = "SplrName"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Private Sub xFillSelectedChallanNos(ByVal xxSprlid As Integer, ByVal xxDt As Date)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_PurEntry_Details_challanBill1_Select", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xxSplrid", CInt(xxSprlid))
            FinActCmd.Parameters.AddWithValue("@xxDt", xxDt.Date)
            FinActRdr = FinActCmd.ExecuteReader
            Me.LstVewChllans.Items.Clear()
            Dim xxLst As ListViewItem
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    xxLst = Me.LstVewChllans.Items.Add(Trim(FinActRdr("dpurentChlnNo")))
                    xxLst.SubItems.Add(Format(FinActRdr("dpurentproddt"), "dd/MM/yyyy"))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Sub
    Private Sub xFillSelectedChallanDetails(ByVal xxSprlid As Integer, ByVal xxdpurentChlnNo As String)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_PurEntry_Details_challanBill_details_Select", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xxSplrid", CInt(xxSprlid))
            FinActCmd.Parameters.AddWithValue("@xxdpurentChlnNo", xxdpurentChlnNo.Trim)
            xxRdr = FinActCmd.ExecuteReader
            Dim ii As Integer = 0
            If Me.DgChlnInv.RowCount > 0 Then
                ii = Me.DgChlnInv.RowCount
            Else
                ii = 0
            End If

            While xxRdr.Read
                If xxRdr.IsDBNull(0) = False Then
                    Me.DgChlnInv.Rows.Add()
                    Me.DgChlnInv.Rows(ii).Cells(0).Value = Trim(xxRdr("dpurentChlnNo"))
                    Me.DgChlnInv.Rows(ii).Cells(1).Value = Trim(xxRdr("itmname"))
                    Me.DgChlnInv.Rows(ii).Cells(2).Value = FormatNumber(xxRdr("dpurentqnty"), 3)
                    Me.DgChlnInv.Rows(ii).Cells(3).Value = Trim(xxRdr("itmuntType"))
                    Me.DgChlnInv.Rows(ii).Cells(4).Value = FormatNumber(xxRdr("dpurentitmrate"), 2)
                    Me.DgChlnInv.Rows(ii).Cells(5).Value = FormatNumber(CDbl(xxRdr("dpurentqnty")) * CDbl(xxRdr("dpurentitmrate")), 2)
                    Me.DgChlnInv.Rows(ii).Cells(6).Value = Trim(xxRdr("dpurentid"))
                    ii += 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            xxRdr.Close()
        End Try
    End Sub

    Private Sub CmbxSplr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSplr.GotFocus
        Try
            Me.CmbxSplr.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSplr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSplr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxSplr_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSplr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSplr.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxSplr) = True Then
                If Me.CmbxSplr.SelectedIndex = 0 Then
                    Me.DgChlnInv.Rows.Clear()
                    xFillSelectedChallanNos(CInt(Me.CmbxSplr.SelectedValue), Me.DtpBilldt.Value.Date)
                End If
                Me.CmbxVATrate.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSplr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxSplr.SelectedIndexChanged
        Try
            If Me.CmbxSplr.SelectedIndex > 0 Then
                Me.DgChlnInv.Rows.Clear()
                xFillSelectedChallanNos(CInt(Me.CmbxSplr.SelectedValue), Me.DtpBilldt.Value.Date)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewChllans_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles LstVewChllans.ItemChecked
        Try
            If e.Item.Checked = True Then
                xFillSelectedChallanDetails(CInt(Me.CmbxSplr.SelectedValue), e.Item.SubItems(0).Text.Trim)
            Else
                For ixx As Integer = 0 To Me.DgChlnInv.RowCount - 1
                    For Each xdgrr As DataGridViewRow In Me.DgChlnInv.Rows
                        If Trim(xdgrr.Cells(0).Value) = e.Item.SubItems(0).Text.Trim Then
                            Me.DgChlnInv.Rows.RemoveAt(xdgrr.Index)
                        End If
                    Next
                Next
            End If
            xCalValues()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If Me.DgChlnInv.RowCount > 0 Then
                Me.CmbxDisType.Focus()
            Else
                MsgBox("Invalid Input! System could not find any item.", MsgBoxStyle.Critical, Me.Text)
                Me.TxtInvNo.Focus()
                Me.TxtInvNo.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtDis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDis.Leave, TxtChrgsTxable.Leave, TxtOthrChrgs.Leave, TxtDisRate.Leave
        Try
            Dim xTxt As TextBox = CType(sender, TextBox)
            If Len(xTxt.Text.Trim) = 0 Then
                xTxt.Text = 0
            End If
            xChk_numericValidation(xTxt)
            xTxt.Text = FormatNumber(xTxt.Text, 2)
            xCalValues()
        Catch ex As Exception

        End Try
    End Sub

    Private Function xCalValues() As Double
        Try
            If Me.DgChlnInv.RowCount > 0 Then
                xCalValues = 0
                If xChkEmptyValu() = False Then
                    MsgBox("Invalid Input! System found one or more control has no value", MsgBoxStyle.Critical, Me.Text)
                    Exit Function
                End If
                Dim xLstAmt As Double = 0
                For Each xdgr As DataGridViewRow In Me.DgChlnInv.Rows
                    xLstAmt += CDbl(xdgr.Cells(5).Value)
                Next
                Me.TxtValue.Text = FormatNumber(CDbl(xLstAmt), 2)
                If Me.CmbxDisType.SelectedIndex = 0 Then
                    Me.TxtDis.Text = FormatNumber(CDbl(Me.TxtDisRate.Text), 2)
                ElseIf Me.CmbxDisType.SelectedIndex = 1 Then
                    Me.TxtDis.Text = FormatNumber(CDbl(CDbl(Me.TxtValue.Text) * CDbl(Me.TxtDisRate.Text)) / 100, 2)
                End If
                Me.TxtTxAble.Text = FormatNumber(CDbl((CDbl(Me.TxtValue.Text) + CDbl(Me.TxtChrgsTxable.Text)) - (CDbl(Me.TxtDis.Text))), 2)
                Dim xVATRate As Double = Fetch_vatrate(CInt(Me.CmbxVATrate.SelectedValue))
                Me.TxtInVat.Text = FormatNumber(CDbl(CDbl(Me.TxtTxAble.Text) * xVATRate / 100), 2)

                Dim xV As Double = CDbl(Me.TxtInVat.Text)
                Dim xSur As Double = xCal_xInvoiceSurCharge(Me.CmbxVATrate.SelectedValue, xV, Me.Label10)
                ''Select Case xCheckxSalePur_VATStatus(xSalxPurxType)
                ''    Case 1 '==SurCharge applicable.
                ''        xSur = Math.Round(xV * 10 / 100, 3)
                ''        Me.Label10.Text = "Surcharge @ 10% On Input VAT"
                ''    Case 2 '==SurCharge and Labour Charges Applicable.
                ''        Me.Label10.Text = "Surcharge @ 10% On Input VAT"
                ''    Case 3 '==Labour Charges Applicable (InterStates).
                ''        Me.Label10.Text = "Surcharge @ 0% On Input VAT"
                ''    Case Else
                ''        xSur = Math.Round(0, 3)
                ''        Me.Label10.Text = "Surcharge @ 0% On Input VAT"
                ''End Select

                Me.TxtInVatSurChrgs.Text = FormatNumber(xSur, 2)
                Dim xGtotal1 As Double = CDbl(CDbl(Me.TxtTxAble.Text) + CDbl(Me.TxtInVat.Text) + CDbl(Me.TxtInVatSurChrgs.Text) + CDbl(Me.TxtOthrChrgs.Text))
                Me.TxtGrand.Text = FormatNumber(Math.Round(xGtotal1, 0), 2)
                Me.TxtRondOff.Text = FormatNumber((CDbl(Me.TxtGrand.Text) - xGtotal1), 2)
            Else
                Me.TxtValue.Text = 0
                Me.TxtDis.Text = 0
                Me.TxtChrgsTxable.Text = 0
                Me.TxtTxAble.Text = 0
                Me.TxtInVat.Text = 0
                Me.TxtInVatSurChrgs.Text = 0
                Me.TxtOthrChrgs.Text = 0
                Me.TxtRondOff.Text = 0
                Me.TxtGrand.Text = 0
                Me.TxtDisRate.Text = 0

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function xChkEmptyValu() As Boolean
        Try
            Dim xEpty As Integer = 0
            If Len(Me.TxtInvNo.Text.Trim) = 0 Then
                xEpty += 1
            End If
            If Me.CmbxSplr.SelectedIndex = -1 Then
                xEpty += 1
            End If
            If Me.CmbxVATrate.SelectedIndex = -1 Then
                xEpty += 1
            End If
            If Me.LstVewChllans.Items.Count = 0 Then
                xEpty += 1
            End If
            If Me.DgChlnInv.RowCount = 0 Then
                xEpty += 1
            End If
            If xEpty > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub LstVewChllans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewChllans.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.LstVewChllans.CheckedItems.Count > 0 Then
                    Me.BtnOk.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If xChkEmptyValu() = False Then
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            If MessageBox.Show("Are you sure to save current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                xSavePurEntryChllan()
            Else
                Return
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub xSavePurEntryChllan()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_Purentry_Insert", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@purentdt", (Me.DtpBilldt.Value.Date))
            FinActCmd.Parameters.AddWithValue("@purbilstatus", Trim("Credit Purchase"))
            FinActCmd.Parameters.AddWithValue("@purentvno", TxtInvNo.Text.Trim)
            FinActCmd.Parameters.AddWithValue("@purentduedt", (Me.DtpBilldt.Value.Date))
            FinActCmd.Parameters.AddWithValue("@purenttotlamt", CDbl(Me.TxtGrand.Text))
            FinActCmd.Parameters.AddWithValue("@purentsplrid", CInt(Me.CmbxSplr.SelectedValue))
            FinActCmd.Parameters.AddWithValue("@purentlocid", 0)
            FinActCmd.Parameters.AddWithValue("@purentcarri", 0)
            FinActCmd.Parameters.AddWithValue("@purentfrtcharg", CDbl(0.0))
            FinActCmd.Parameters.AddWithValue("@purentgrno", 0)
            FinActCmd.Parameters.AddWithValue("@purentcarino", 0)
            FinActCmd.Parameters.AddWithValue("@purentgrdt", (Me.DtpBilldt.Value.Date))
            FinActCmd.Parameters.AddWithValue("@purentulcharg", CDbl(0.0))
            FinActCmd.Parameters.AddWithValue("@purentuload", 0)
            FinActCmd.Parameters.AddWithValue("@purentcoment", "")
            FinActCmd.Parameters.AddWithValue("@purentpkgcharg", CDbl(Me.TxtChrgsTxable.Text)) 'if input vat apply
            FinActCmd.Parameters.AddWithValue("@purentpostcharg", CDbl(0.0))
            FinActCmd.Parameters.AddWithValue("@purentothrcharg", CDbl(Me.TxtOthrChrgs.Text))
            FinActCmd.Parameters.AddWithValue("@purentinscharg", CDbl(0.0))
            FinActCmd.Parameters.AddWithValue("@purentpolcyno", 0)
            FinActCmd.Parameters.AddWithValue("@purentinsco", 0)
            FinActCmd.Parameters.AddWithValue("@purentdisonamt", CDbl(Me.TxtValue.Text))
            If Me.CmbxDisType.SelectedIndex = 0 Then
                FinActCmd.Parameters.AddWithValue("@purentdistype", "Discount Value")
            ElseIf Me.CmbxDisType.SelectedIndex = 1 Then
                FinActCmd.Parameters.AddWithValue("@purentdistype", "Discount Percentage")
            End If
            FinActCmd.Parameters.AddWithValue("@purentdisrate", CDbl(Me.TxtDisRate.Text))
            FinActCmd.Parameters.AddWithValue("@purentdisvalue", CDbl(Me.TxtDis.Text))
            FinActCmd.Parameters.AddWithValue("@purentvatrate", CInt(Me.CmbxVATrate.SelectedValue))
            FinActCmd.Parameters.AddWithValue("@purentvatamt", CDbl(Me.TxtInVat.Text))
            FinActCmd.Parameters.AddWithValue("@PurEntTxAbleAmt", CDbl(Me.TxtTxAble.Text))
            FinActCmd.Parameters.AddWithValue("@PurEntVATSurChrg", CDbl(Me.TxtInVatSurChrgs.Text))
            FinActCmd.Parameters.AddWithValue("@PurEntRondOff", CDbl(Me.TxtRondOff.Text))
            FinActCmd.Parameters.AddWithValue("@PurENTBILLTYPE", "CHLN")
            FinActCmd.Parameters.AddWithValue("@purentorderid", 0)
            FinActCmd.Parameters.AddWithValue("@purentadusrid", Current_UsrId)
            FinActCmd.Parameters.AddWithValue("@purentaddt", Now)
            FinActCmd.Parameters.AddWithValue("@purentdelstatus", 1)
            FinActCmd.ExecuteNonQuery()
            FinActCmd.Dispose()
            Dim xLstId As Integer = xDynamic_Find_xAnItem_xInA_Table_2cond("purentid", "Purentsplrid", CInt(Me.CmbxSplr.SelectedValue), "Finactpurentry", "purentvno", Me.TxtInvNo.Text.Trim)
            For Each xdgr As DataGridViewRow In Me.DgChlnInv.Rows
                FinActCmd = New SqlCommand("Finact_Purentry_Details_ChallanType_Update", FinActConn)
                FinActCmd.CommandType = CommandType.StoredProcedure
                FinActCmd.Parameters.AddWithValue("@dpurentconcrnid", xLstId)
                FinActCmd.Parameters.AddWithValue("@dpurentid", CInt(xdgr.Cells(6).Value))
                FinActCmd.Parameters.AddWithValue("@dpurentChlnEdtusrid", CInt(Current_UsrId))
                FinActCmd.Parameters.AddWithValue("@dpurentChlnEdtdt", Now)
                FinActCmd.Parameters.AddWithValue("@dpurentitmrate", CDbl(xdgr.Cells(4).Value))
                FinActCmd.ExecuteNonQuery()
                FinActCmd.Dispose()
            Next
            MsgBox("Current record has been successfully saved.", MsgBoxStyle.Information, Me.Text)
            xClrvalues()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
        End Try
    End Sub
    Private Sub xClrvalues()
        Try
            Me.TxtInvNo.Clear()
            Me.CmbxSplr.DataSource = Nothing
            Fill_Combobox_DistinctSplrid_PurEntryDetails(Me.CmbxSplr)
            Me.DgChlnInv.Rows.Clear()
            Me.LstVewChllans.Items.Clear()
            Me.TxtValue.Text = 0
            Me.TxtDis.Text = 0
            Me.TxtChrgsTxable.Text = 0
            Me.TxtTxAble.Text = 0
            Me.TxtInVat.Text = 0
            Me.TxtInVatSurChrgs.Text = 0
            Me.TxtOthrChrgs.Text = 0
            Me.TxtRondOff.Text = 0
            Me.TxtGrand.Text = 0
            Me.TxtDisRate.Text = 0
            Me.TxtInvNo.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        Try
            Dim FrmPc As New FrmTranSaleEntryBlngUsingChlnEdit
            FrmPc.MdiParent = FrmMainMdi
            FrmPc.BringToFront()
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(FrmPc)
            FrmPc.Show()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgChlnInv_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgChlnInv.CellEndEdit
        Try
            If e.ColumnIndex = 4 Then
                Me.DgChlnInv.CurrentRow.Cells(4).Value = FormatNumber(Me.DgChlnInv.CurrentRow.Cells(4).Value, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub DgChlnInv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgChlnInv.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgChlnInv.Rows.Count '- 1
            If Cr_Row <> Me.DgChlnInv.CurrentRow.Index Then
                If e.ColumnIndex = 4 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgChlnInv.CurrentCell.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        Me.DgChlnInv.CurrentCell.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgChlnInv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgChlnInv.CellValueChanged
        Try
            If Me.DgChlnInv.RowCount > 0 Then
                If e.ColumnIndex = 4 Then
                    Me.DgChlnInv.CurrentRow.Cells(5).Value = FormatNumber(CDbl(Me.DgChlnInv.CurrentRow.Cells(2).Value) * CDbl(Me.DgChlnInv.CurrentRow.Cells(4).Value), 2)
                    xCalValues()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DgChlnInv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgChlnInv.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If Me.DgChlnInv.CurrentCell.ColumnIndex = Me.DgChlnInv.ColumnCount - 3 Then
                    If Me.DgChlnInv.CurrentRow.Index = Me.DgChlnInv.Rows.Count - 1 Then
                        Me.CmbxDisType.Focus()
                    End If
                End If
            End If

            If Me.DgChlnInv.CurrentCell.RowIndex < Me.DgChlnInv.RowCount - 1 Then
                Me.DgChlnInv.CurrentCell = Me.DgChlnInv.Item(4, Me.DgChlnInv.CurrentCell.RowIndex + 1)
            End If
            e.Handled = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxDisType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDisType.GotFocus
        Try
            Me.CmbxDisType.DroppedDown = True
            If Me.CmbxDisType.SelectedIndex = -1 Then
                Me.CmbxDisType.SelectedIndex = 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxDisType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxDisType.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxDisType_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CmbxDisType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDisType.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxDisType) = True Then
                Me.TxtDisRate.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtDisRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDisRate.TextChanged
        Try
            If xChk_numericValidation(Me.TxtDisRate) = False Then
                If Me.CmbxDisType.SelectedIndex = 0 Then
                    Me.TxtDis.Text = FormatNumber(CDbl(Me.TxtDisRate.Text), 2)
                ElseIf Me.CmbxDisType.SelectedIndex = 1 Then
                    Me.TxtDis.Text = FormatNumber(CDbl(CDbl(Me.TxtValue.Text) * CDbl(Me.TxtDisRate.Text)) / 100, 2)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxDisType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxDisType.SelectedIndexChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxVATrate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxVATrate.SelectedIndexChanged

    End Sub
End Class
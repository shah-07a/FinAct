Imports System.Data
Imports System.Data.SqlClient
Public Class FrmTranSaleEntryBlngUsingChlnEdit
    Dim xxRdr As SqlDataReader
    Private Sub AllCntrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpBilldt.KeyDown _
    , TxtChrgsTxable.KeyDown, TxtDis.KeyDown, TxtGrand.KeyDown, TxtInVat.KeyDown, TxtInVatSurChrgs.KeyDown, TxtOthrChrgs.KeyDown, TxtRondOff.KeyDown _
    , TxtTxAble.KeyDown, TxtTxAble.KeyDown, TxtValue.KeyDown, TxtDisRate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmTranPurEntryBlngUsingChl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Dim cond As String = "Purchase"
            Select_2rec_where("spcatid", "spcatname", "spcattype", "Finactsalepurcatgry", CmbxVATrate, cond, "DELSTATUS", CInt(1))
            Fill_Combobox_DistinctPURVNO_PurEntryDetails(Me.CmbxBillNo)
            Fill_Combobox_Dynamiclly_Where_In_Cond2(Me.CmbxSplr, "FinactsplrMstr", "Splrid", "Splrname", "SplrType", "SplrDelStatus", "Vendor", "Vendor", 1)
            Me.CmbxBillNo.SelectedIndex = -1
            Me.CmbxSplr.SelectedIndex = -1
            Me.CmbxVATrate.SelectedIndex = -1
            Me.DgChlnInv.Rows.Clear()
            Me.DtpBilldt.MinDate = FinStartDt.Date
            Me.DtpBilldt.MaxDate = FinEnddt.Date
            Me.CmbxBillNo.Focus()
        Catch ex As Exception

        End Try
    End Sub

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
                Me.BtnOk.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Fill_Combobox_DistinctPURVNO_PurEntryDetails(ByVal Xcombobx As ComboBox)
        Dim xStr As String = "Finact_Purentry_InvoiceNO_ChallanType_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            FinActCmd = New SqlCommand(xStr, FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            SqlAdptr = New SqlDataAdapter(FinActCmd)
            dtaset = New DataSet(FinActCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = "PurEntid"
            Xcombobx.DisplayMember = "PurentVno"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Private Sub xFillSelectedChallanNos(ByVal xxPurentid As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_PurEntry_Details_challanBill1_edit_Select", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xxPurentid", CInt(xxPurentid))
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
            If Me.LstVewChllans.Items.Count > 0 Then
                For Each xll As ListViewItem In Me.LstVewChllans.Items
                    xll.Checked = True
                Next
            End If
        End Try
    End Sub
    Private Sub xFillSelectedChallanDetails(ByVal xxpurentid As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_PurEntry_Details_challanBill_details_edit_Select", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xxpurentid", CInt(xxpurentid))
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
                If Me.CmbxSplr.SelectedIndex >= 0 Then
                    Me.DgChlnInv.Rows.Clear()
                    xFillSelectedChallanNos(CInt(Me.CmbxBillNo.SelectedValue))
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewChllans_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles LstVewChllans.ItemChecked
        Try
            If e.Item.Checked = True Then
                xFillSelectedChallanDetails(CInt(Me.CmbxBillNo.SelectedValue))
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
            Me.CmbxSplr_Leave(sender, e)
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

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function xChkEmptyValu() As Boolean
        Try
            Dim xEpty As Integer = 0
            If Len(Me.CmbxBillNo.Text.Trim) = 0 Then
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
                xUpdatePurEntryChllan()
            Else
                Return
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub xUpdatePurEntryChllan()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_PurEntry_ChlanType_Update", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@purentid", CInt(Me.CmbxBillNo.SelectedValue))
            FinActCmd.Parameters.AddWithValue("@purenttotlamt", CDbl(Me.TxtGrand.Text))
            FinActCmd.Parameters.AddWithValue("@purentpkgcharg", CDbl(Me.TxtChrgsTxable.Text)) 'if input vat apply
            FinActCmd.Parameters.AddWithValue("@purentothrcharg", CDbl(Me.TxtOthrChrgs.Text))
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
            FinActCmd.Parameters.AddWithValue("@purentEdtusrid", Current_UsrId)
            FinActCmd.Parameters.AddWithValue("@purentEdtdt", Now)
            FinActCmd.ExecuteNonQuery()
            FinActCmd.Dispose()

            For Each xdgr As DataGridViewRow In Me.DgChlnInv.Rows
                FinActCmd = New SqlCommand("Finact_Purentry_Details_ChallanType_Update", FinActConn)
                FinActCmd.CommandType = CommandType.StoredProcedure
                FinActCmd.Parameters.AddWithValue("@dpurentconcrnid", CInt(Me.CmbxBillNo.SelectedValue))
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
            Me.CmbxBillNo.SelectedIndex = -1
            Me.CmbxSplr.SelectedIndex = -1
            Me.CmbxVATrate.SelectedIndex = -1
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
            Me.CmbxBillNo.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xClrvaluesPartly()
        Try
            Me.CmbxSplr.SelectedIndex = -1
            Me.CmbxVATrate.SelectedIndex = -1
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxBillNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxBillNo.GotFocus
        Try
            xClrvaluesPartly()
            Me.CmbxBillNo.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxBillNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxBillNo.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxBillNo) = True Then
                If CmbxBillNo.SelectedIndex = 0 Then
                    xSelectedChallanNosDetails(Me.CmbxBillNo.SelectedValue)
                    BtnOk_Click(sender, e)
                End If
                Me.DtpBilldt.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxBillNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxBillNo.SelectedIndexChanged
        Try
            If CmbxBillNo.SelectedIndex > 0 Then
                xSelectedChallanNosDetails(Me.CmbxBillNo.SelectedValue)
                BtnOk_Click(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxBillNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxBillNo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxBillNo_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xSelectedChallanNosDetails(ByVal xxPurentid As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_Purentry_ChallanType_Select", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xxPurentid", CInt(xxPurentid))
            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    Me.CmbxSplr.SelectedValue = CInt(FinActRdr("purentsplrid"))
                    Me.CmbxVATrate.SelectedValue = CInt(FinActRdr("purentvatrate"))
                    Me.TxtChrgsTxable.Text = FormatNumber(CDbl(FinActRdr("purentpkgcharg")), 2)
                    Me.TxtOthrChrgs.Text = FormatNumber(CDbl(FinActRdr("purentothrcharg")), 2)
                    If Trim(FinActRdr("Purentdistype")) = "Discount Value" Then
                        Me.CmbxDisType.SelectedIndex = 0
                    ElseIf Trim(FinActRdr("Purentdistype")) = "Discount Percentage" Then
                        Me.CmbxDisType.SelectedIndex = 1
                    End If
                    Me.TxtDis.Text = FormatNumber(CDbl(FinActRdr("purentdisvalue")), 2)
                    Me.TxtDisRate.Text = FormatNumber(CDbl(FinActRdr("purentdisrate")), 2)
                    Me.DtpBilldt.Value = FinActRdr("purentdt")
                End If
            End While
            Me.LblCurBal.Text = FormatNumber(xFetch_NetBalance(CInt(Me.CmbxSplr.SelectedValue), Me.LblType), 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        Try
            Dim FrmPc As New FrmTranPurEntryBlngUsingChln
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

    End Sub

    Private Sub BtnDele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDele.Click
        Try
            If Not Me.CmbxBillNo.SelectedIndex = -1 And Not Me.CmbxSplr.SelectedIndex = -1 Then
                If MessageBox.Show("It is strognly suggested not to delete entry(ies). Are you sure to delete current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim Delid As Integer = CInt(Me.CmbxBillNo.SelectedValue)
                        FinActCmd = New SqlCommand("Finact_DelEntry_PurEntry_Challan", FinActConn)
                        FinActCmd.CommandType = CommandType.StoredProcedure
                        FinActCmd.Parameters.AddWithValue("@xpurentid", CInt(Me.CmbxBillNo.SelectedValue))
                        FinActCmd.Parameters.AddWithValue("@xSplrId", CInt(Me.CmbxSplr.SelectedValue))
                        FinActRdr = FinActCmd.ExecuteReader
                        While FinActRdr.Read
                            Dim x As Object = FinActRdr("xMessage")
                            If FinActRdr("xMessage") = True Then
                                MsgBox("Access denied!, system could not delete current record.", MsgBoxStyle.Critical, "Relationship Developed")
                            Else
                                MsgBox("Current item has been successfully deleted", MsgBoxStyle.Information, Me.Text)
                                xClrvalues()
                                Fill_Combobox_DistinctPURVNO_PurEntryDetails(Me.CmbxBillNo)
                            End If
                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Exit Sub
                    Finally
                        FinActCmd.Dispose()
                        FinActRdr.Close()
                    End Try

                Else
                    Return
                End If
            Else
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
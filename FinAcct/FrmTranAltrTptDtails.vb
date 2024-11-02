Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmTranAltrTptDtails
    Dim xCurSaleentid As Integer = 0
    Dim xCurLodCharg As Double = 0
    Dim xCurFrgtCharg As Double = 0
    Dim xCurFrgtStatus As Integer = 0
    Private Sub CmbxAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxBillno.GotFocus, CmbxCarri.GotFocus, _
     CmbxWareh.GotFocus
        Try
            Dim xCmbx As ComboBox = CType(sender, ComboBox)
            xCmbx.DroppedDown = True
            xCmbx.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxBillno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxBillno.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxBillno_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxBillno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxBillno.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxBillno) = True Then
                If Me.CmbxBillno.SelectedIndex = 0 Then
                    xFilltptDetails(CInt(Me.CmbxBillno.Text.Trim))
                End If
                Me.Txtname.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CmbxBillno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxBillno.SelectedIndexChanged
        Try
            If Me.CmbxBillno.SelectedIndex > 0 Then
                xFilltptDetails(CInt(Me.CmbxBillno.Text.Trim))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtname.KeyDown, TxtBillAmt.KeyDown _
    , TxtFrght.KeyDown, Txtgrno.KeyDown, TxtGrsWt.KeyDown, TxtLodchrgs.KeyDown, TxtCariNo.KeyDown, TxtPvtMrk.KeyDown, Dtpgrdt.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub FrmTranAltrTptDtails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Fill_Combobox("Saleentid", "Saleentvno", "Finactsaleentry", "SaleEntDelStatus", CInt(1), Me.CmbxBillno)
            Fill_Combobox("shpid", "shpname", "finact_Carriermstr", "SHPDELSTATUS", CInt(1), Me.CmbxCarri)
            Me.CmbxBillno.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFilltptDetails(ByVal xSeVno As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_SaleEntry_TptDtails_SELECT", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@SeVNo", CInt(xSeVno))
            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    Select_2rec_with_where(Me.CmbxWareh, CInt(FinActRdr("SaleentSplrid")))
                    Me.CmbxWareh.SelectedValue = CInt(FinActRdr("Saleentlocid"))
                    xCurSaleentid = CInt(FinActRdr("Saleentid"))
                    Me.CmbxCarri.SelectedValue = CInt(FinActRdr("Saleentcarri"))
                    Me.DtpBilldt.Value = FinActRdr("Saleentdt")
                    Me.Lbldt.Text = Format(Me.DtpBilldt.Value.Date, "dd/MM/yyyy")
                    Me.Txtname.Text = Trim(FinActRdr("splrname"))
                    Me.TxtBillAmt.Text = FormatNumber(FinActRdr("Saleenttotlamt"), 2)
                    Me.TxtGrsWt.Text = FormatNumber(FinActRdr("Saleentuload"), 3)
                    Me.TxtCariNo.Text = Trim(FinActRdr("Saleentcarino"))
                    Me.Txtgrno.Text = Trim(FinActRdr("Saleentgrno"))
                    Me.Dtpgrdt.Value = FinActRdr("Saleentgrdt")
                    xCurLodCharg = FinActRdr("Saleentulcharg")
                    Me.TxtLodchrgs.Text = FormatNumber(xCurLodCharg, 2)
                    xCurFrgtCharg = FinActRdr("Saleentfrtcharg")
                    Me.TxtFrght.Text = FormatNumber(xCurFrgtCharg, 2)
                    Me.TxtPvtMrk.Text = Trim(FinActRdr("SaleentPvtmrk"))
                    xCurFrgtStatus = CInt(FinActRdr("SaleEntFrgtType"))
                    If xCurFrgtStatus = 0 Then
                        Me.Rb2pay.Checked = True
                    Else
                        Me.Rbpaid.Checked = True
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Sub

    Private Sub CmbxWareh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxWareh.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxWareh_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxWareh_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWareh.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxWareh) = True Then
                Me.CmbxCarri.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCarri_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCarri.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxCarri_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCarri_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCarri.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxCarri) = True Then
                If Me.Panel1.Enabled = True Then
                    Me.TxtGrsWt.Focus()
                    Me.TxtGrsWt.SelectAll()
                Else
                    Me.BtnSave.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCarri_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxCarri.SelectedIndexChanged
        Try
            If Me.CmbxCarri.SelectedIndex > 0 Then
                Me.Panel1.Enabled = True
            Else
                Me.Panel1.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnaALL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCncl.GotFocus, BtnExit.GotFocus _
    , BtnFind.GotFocus, BtnSave.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCncl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCncl.Leave, BtnExit.Leave _
    , BtnFind.Leave, BtnSave.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtGrsWt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGrsWt.Leave
        Try
            xChk_numericValidation(Me.TxtGrsWt)
            If Len(Me.TxtGrsWt.Text.Trim) = 0 Then
                Me.TxtGrsWt.Text = 0
            End If
            Me.TxtGrsWt.Text = FormatNumber(CDbl(Me.TxtGrsWt.Text), 3)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtFrght_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFrght.Leave
        Try
            xChk_numericValidation(Me.TxtFrght)
            If Len(Me.TxtFrght.Text.Trim) = 0 Then
                Me.TxtFrght.Text = 0
            End If
            Me.TxtFrght.Text = FormatNumber(CDbl(Me.TxtFrght.Text), 2)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtLodchrgs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLodchrgs.Leave
        Try
            xChk_numericValidation(Me.TxtLodchrgs)
            If Len(Me.TxtLodchrgs.Text.Trim) = 0 Then
                Me.TxtLodchrgs.Text = 0
            End If
            Me.TxtLodchrgs.Text = FormatNumber(CDbl(Me.TxtLodchrgs.Text), 2)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaleEntry_TptDetails_update()
        Try
            FinActCmd = New SqlCommand("Finact_SaleEntry_TptDetails_Update", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@Saleentid", CInt(xCurSaleentid))
            Dim xAmt As Double = CDbl(Me.TxtBillAmt.Text)
            Dim xPrvsTot As Double = 0
            If xCurFrgtStatus = 1 Then
                xPrvsTot = CDbl(xCurFrgtCharg + xCurLodCharg)
            End If
            Dim xBalAmt As Double = xAmt - xPrvsTot
            Dim xCurTot As Double = 0
            If Me.Rbpaid.Checked = True Then
                xCurTot = CDbl(Me.TxtFrght.Text) + CDbl(Me.TxtLodchrgs.Text)
            End If
            FinActCmd.Parameters.AddWithValue("@Saleenttotlamt", CDbl(xBalAmt + xCurTot))
            FinActCmd.Parameters.AddWithValue("@Saleentlocid", Me.CmbxWareh.SelectedValue)
            FinActCmd.Parameters.AddWithValue("@Saleentcarri", Me.CmbxCarri.SelectedValue)
            FinActCmd.Parameters.AddWithValue("@Saleentfrtcharg", CDbl(Me.TxtFrght.Text))
            FinActCmd.Parameters.AddWithValue("@Saleentgrno", Me.Txtgrno.Text.Trim)
            FinActCmd.Parameters.AddWithValue("@Saleentcarino", Me.TxtCariNo.Text)
            FinActCmd.Parameters.AddWithValue("@Saleentgrdt", Me.Dtpgrdt.Value.Date)
            FinActCmd.Parameters.AddWithValue("@Saleentulcharg", CDbl(Me.TxtLodchrgs.Text))
            FinActCmd.Parameters.AddWithValue("@Saleentuload", CDbl(Me.TxtGrsWt.Text))
            FinActCmd.Parameters.AddWithValue("@Saleentpvtmrk", Trim(Me.TxtPvtMrk.Text))
            If Me.Rb2pay.Checked = True Then
                FinActCmd.Parameters.AddWithValue("@SaleEntFrgtType", CInt(0))
            Else
                FinActCmd.Parameters.AddWithValue("@SaleEntFrgtType", CInt(1))
            End If
            FinActCmd.Parameters.AddWithValue("@Saleentedtusrid", Current_UsrId)
            FinActCmd.Parameters.AddWithValue("@Saleentedtdt", Now)
            FinActCmd.ExecuteNonQuery()
            MsgBox("Current Record Has Been Updated Successfully", MsgBoxStyle.Information, "Update Record")
            Clear_Values()
            If MessageBox.Show("Do you want modify more record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Me.CmbxBillno.Focus()
            Else
                Me.Close()
            End If
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
        End Try

    End Sub
    Private Sub Clear_Values()
        Try
            Me.TxtCariNo.Text = ""
            Me.TxtFrght.Text = 0
            Me.Txtgrno.Text = ""
            Me.TxtGrsWt.Text = 0
            Me.TxtLodchrgs.Text = 0
            Me.Txtname.Text = ""
            Me.TxtPvtMrk.Text = ""
            Me.xCurSaleentid = 0
            Me.TxtBillAmt.Text = 0
            Me.CmbxCarri.SelectedIndex = -1
            Me.CmbxWareh.SelectedIndex = -1
            Me.CmbxBillno.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        Try
            Me.CmbxBillno.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        Try
            Me.BtnFind.Enabled = True
            Clear_Values()
            Me.CmbxBillno.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function xxchkemptval() As Integer
        Try
            Dim xActFeIndx As Integer = 0
          
            With Me.CmbxBillno
                If .SelectedIndex = -1 Then
                    .BackColor = Color.Yellow
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With Me.CmbxWareh
                If .SelectedIndex = -1 Then
                    .BackColor = Color.Yellow
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With Me.CmbxCarri
                If .SelectedIndex = -1 Then
                    .BackColor = Color.Yellow
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With

            With Me.TxtFrght
                If Len(.Text.Trim) = 0 Then
                    .BackColor = Color.Yellow
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With Txtname
                If Len(.Text.Trim) = 0 Then
                    .BackColor = Color.Yellow
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtGrsWt
                If Len(.Text.Trim) = 0 Then
                    .BackColor = Color.Yellow
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With
            With TxtLodchrgs
                If Len(.Text.Trim) = 0 Then
                    .BackColor = Color.Yellow
                    xActFeIndx = xActFeIndx + 1
                Else
                    .BackColor = Color.White
                End If
            End With
            Return xActFeIndx
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If xxchkemptval() > 0 Then
                MsgBox("Invalid Input! Highlighted Column(s) Is/Are Required Data", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            If xCmpreDateTimes() = False Then Exit Sub
            If Me.BtnSave.Text.Trim = "&Update" Then
                If MessageBox.Show("Are you sure to update current record.", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    SaleEntry_TptDetails_update()
                Else
                    Return
                End If
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DtpBilldt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpBilldt.ValueChanged
        Try
            Me.Dtpgrdt.Value = Me.DtpBilldt.Value
        Catch ex As Exception

        End Try
    End Sub
    Private Function xCmpreDateTimes() As Boolean
        Try
            If Date.Compare(Me.DtpBilldt.Value.Date, Me.Dtpgrdt.Value.Date) = 1 Then
                MsgBox("Invalid Input! GR date should be equal or greater than Bill/Invoice date")
                Me.Dtpgrdt.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function

    Private Sub TxtLodchrgs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLodchrgs.TextChanged

    End Sub
End Class
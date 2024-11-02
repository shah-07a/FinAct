Imports System.Data
Imports System.Data.SqlClient
Public Class FrmTran_KblTypeDrctProdn
    Dim xCurrSelid As Integer = 0
    Private Sub FrmTran_KblTypeDrctProdn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 50
            Me.LblEntyNo.Text = xFetchVno_dynamic("FinactSaleentry_Details", "dSaleentid")
            Fill_Combobox_where_cond_KblType(Me.CmbxItm)
            Dim xLastDt As Date = xSelect_xLastEntrdDate_xintbl("dSaleEntProddt", "FinactSaleentry_details")
            If xMxDtFlag = True Then
                Me.DTPprod1.Value = Today.Date
            Else
                Me.DTPprod1.Value = xLastDt
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(DTPprod1, DTPprod1)
            SetControlCurrentDate(DTPprod1)
            Me.DTPprod1.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub Fill_Combobox_where_cond_KblType(ByVal Xcombobx As ComboBox)
        Dim xStr As String = "FinAct_ItemMstr_KBLtype_Select_Like"
        '===============
        '==DelStatus Handled
        '===============
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            FinActCmd = New SqlCommand(xStr, FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xtype", CInt(1))
            FinActCmd.Parameters.AddWithValue("@GRUPNAME", "%Mach%")
            FinActCmd.Parameters.AddWithValue("@currval1", Trim(""))
            FinActCmd.Parameters.AddWithValue("@currfield1", "itmcode")
            FinActCmd.Parameters.AddWithValue("@Sale_Pur_Type1", "Sale")
            SqlAdptr = New SqlDataAdapter(FinActCmd)
            dtaset = New DataSet(FinActCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = "Itmid"
            Xcombobx.DisplayMember = "Itmcode"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub

    Private Sub TxtQnty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQnty.GotFocus
        Try
            Me.TxtQnty.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtItmcost_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItmcost.GotFocus
        Try
            Me.TxtItmcost.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ALLCont_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPprod1.KeyDown _
    , TxtItmcost.KeyDown, TxtQnty.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxItm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxItm.GotFocus
        Try
            Me.CmbxItm.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxItm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxItm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxItm_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxItm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxItm.Leave
        Try

            If CheckBlank_Cmbx(Me.CmbxItm) = True Then
                Me.TxtQnty.Focus()
                Me.TxtQnty.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtQnty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQnty.Leave
        Try
            If xChk_numericValidation(Me.TxtQnty) = False Then
                If Len(Me.TxtQnty.Text.Trim) = 0 Then
                    Me.TxtQnty.Text = 0
                End If
                Me.TxtQnty.Text = FormatNumber(Me.TxtQnty.Text, 3)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtItmcost_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItmcost.Leave
        Try
            If xChk_numericValidation(Me.TxtItmcost) = False Then
                If Len(Me.TxtItmcost.Text.Trim) = 0 Then
                    Me.TxtItmcost.Text = 0
                End If
                Me.TxtItmcost.Text = FormatNumber(Me.TxtItmcost.Text, 2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Me.CmbxItm.SelectedIndex = -1 Or Not Me.TxtQnty.Text > 0 Then
                MsgBox("Invalid input!", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            If Me.BtnSave.Text.Trim = "&Save" Then
                If MessageBox.Show("Are you sure to save current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    xDirectItmProdInsert()
                Else
                    Return
                End If
            Else
                If MessageBox.Show("Are you sure to update current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    xDirectItmProdUpdate()
                Else
                    Return
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xDirectItmProdInsert()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_SaleEntryDetails_KblType_Insert", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@dSaleentitmid", CInt(Me.CmbxItm.SelectedValue))
            FinActCmd.Parameters.AddWithValue("@dSaleentqnty", CDbl(Me.TxtQnty.Text))
            FinActCmd.Parameters.AddWithValue("@dSaleentItmrate", CDbl(Me.TxtItmcost.Text))
            FinActCmd.Parameters.AddWithValue("@dSaleentproddt", Me.DTPprod1.Value.Date)
            FinActCmd.ExecuteNonQuery()
            MsgBox("Current record has been successfully saved.", MsgBoxStyle.Information, Me.Text)
            xClrVal()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
        End Try
    End Sub
    Private Sub xDirectItmProdUpdate()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_SaleEntryDetails_KblType_Update", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@dSaleentid", CInt(xCurrSelid))
            FinActCmd.Parameters.AddWithValue("@dSaleentitmid", CInt(Me.CmbxItm.SelectedValue))
            FinActCmd.Parameters.AddWithValue("@dSaleentqnty", CDbl(Me.TxtQnty.Text))
            FinActCmd.Parameters.AddWithValue("@dSaleentItmrate", CDbl(Me.TxtItmcost.Text))
            FinActCmd.Parameters.AddWithValue("@dSaleentproddt", Me.DTPprod1.Value.Date)
            FinActCmd.ExecuteNonQuery()
            MsgBox("Current record has been updated", MsgBoxStyle.Information, Me.Text)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
        End Try
    End Sub

    Private Sub xClrVal()
        Try
            Me.CmbxItm.SelectedIndex = -1
            Me.TxtQnty.Text = 0
            Me.TxtItmcost.Text = 0
            Me.LblEntyNo.Text = xFetchVno_dynamic("FinactSaleentry_Details", "dSaleentid")
            Me.DTPprod1.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xDirectItmProdSelect(ByVal xdSaleid As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_SaleEntryDetails_KblType_Select", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@dSaleentid", CInt(xdSaleid))
            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    Me.CmbxItm.SelectedValue = CInt(FinActRdr("dSaleentitmid"))
                    Me.TxtQnty.Text = FormatNumber(FinActRdr("dSaleentqnty"), 3)
                    Me.TxtItmcost.Text = FormatNumber(FinActRdr("dSaleentItmrate"), 2)
                    Me.DTPprod1.Value = FinActRdr("dSaleentproddt")
                    Me.LblEntyNo.Text = FinActRdr("dSaleentid")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        Try
            If Me.BtnFind.Text.Trim = "&Find" Then
                Me.BtnSave.Text = "&Update"
                Me.BtnFind.Text = "&Cancel"
                Me.CmbxFind.Enabled = True
                Me.CmbxFind.Visible = True
                Me.LblFind.Visible = True
                Fill_Combobox_where_cond("dSaleentId", "dSaleentitmid", "DSaleEntDescrpt", "FinactSaleEntry_Details", "dSaleEntDelStatus", CInt(1), "DIRCT_PROD", Me.CmbxFind)
                Me.CmbxFind.Focus()
            Else
                Me.BtnSave.Text = "&Save"
                Me.BtnFind.Text = "&Find"
                Me.CmbxFind.Enabled = False
                Me.CmbxFind.Visible = False
                Me.LblFind.Visible = False
                xClrVal()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFind_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxFind.GotFocus
        Try
            Me.CmbxFind.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxFind.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxFind_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxFind_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxFind.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxFind) = True Then
                If Me.CmbxFind.SelectedIndex = 0 Then
                    xDirectItmProdSelect(CInt(Me.CmbxFind.SelectedValue))
                  
                End If
                xCurrSelid = CInt(Me.CmbxFind.SelectedValue)
                Me.CmbxFind.Enabled = False
                Me.CmbxFind.Visible = False
                Me.LblFind.Visible = False
                Me.DTPprod1.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFind_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxFind.SelectedIndexChanged
        Try
            If Me.CmbxFind.SelectedIndex > 0 Then
                xDirectItmProdSelect(CInt(Me.CmbxFind.SelectedValue))
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
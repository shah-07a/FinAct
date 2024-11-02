Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCrRptBOMCosting
    Dim BcCmd As SqlCommand
    Dim BcRdr As SqlDataReader
    Dim BcDset As DataSet
    Dim BcAdptr As SqlDataAdapter
    Dim DgIndx As Integer = 0

    Private Sub FrmCrRptBOMCosting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Size = New Point(905, 592)
            Fill_Combobox_where_cond("itmid", "itmname", "itmtype1", "FinactItmmstr", "ITMDELSTATUS", CInt(1), "BomItem", Me.CmbxBcName)
            Me.Dtpbc1.Focus()
            If Cl_TimeIndia = True Then
                Me.ChkRptLdgr.Checked = False
            Else
                Me.ChkRptLdgr.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkRptLdgr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkRptLdgr.GotFocus
        Try
            Me.ChkRptLdgr.BackColor = Color.Blue
            Me.ChkRptLdgr.ForeColor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Rbcalpcent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rbcalpcent.GotFocus
        Try
            Me.Rbcalpcent.BackColor = Color.Blue
            Me.Rbcalpcent.ForeColor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RbCalVal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCalVal.GotFocus
        Try
            Me.RbCalVal.BackColor = Color.Blue
            Me.RbCalVal.ForeColor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xAllContrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEc.KeyDown, TxtLc.KeyDown _
    , TxtMc.KeyDown, TxtOc.KeyDown, TxtPval.KeyDown, TxtTwC.KeyDown, Rbcalpcent.KeyDown, RbCalVal.KeyDown, ChkRptLdgr.KeyDown, Dtpbc1.KeyDown, TxtRemrks.KeyDown, TxtACom.KeyDown, TxtMrp.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxBcName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxBcName.GotFocus
        Try
            Me.CmbxBcName.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxBcName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxBcName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxBcName_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxBcName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxBcName.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxBcName) = False Then
                Me.CmbxBcName.Focus()
            Else
                Me.CmbxMthd.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxMthd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxMthd.GotFocus
        Try
            Me.CmbxMthd.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxMthd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxMthd.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxMthd_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxMthd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxMthd.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxMthd) = False Then
                Me.CmbxMthd.Focus()
            Else
                Me.TxtEc.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xFill_Dg()
        Try
            For ix As Integer = 0 To 1
                Dim cnt As Control
                Dim xi As Integer = 0
                Dim xPrft As Double = 0
                Dim Pft As Boolean = False
                If DgIndx = 1 Then
                    For Each cnt In Me.Panel1.Controls
                        If TypeOf cnt Is TextBox Then
                            If cnt.Text > 0 And cnt.TabIndex <> 12 And cnt.TabIndex <> 13 And cnt.TabIndex <> 14 Then
                                DgBOMcost.Rows.Add()
                                Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(0).Value = SetSrNO()
                                Select Case cnt.TabIndex
                                    Case 4
                                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Value = "Electricity Charges"
                                    Case 5
                                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Value = "Tear & Wear Charges"
                                    Case 6
                                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Value = "Marketting  Charges"
                                    Case 7
                                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Value = "Labour Charges"
                                    Case 9
                                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Value = "Other Charges"
                                End Select
                                Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(2).Value = 1
                                Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(3).Value = 1
                                Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).Value = FormatNumber(cnt.Text, 2)
                                Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Value = FormatNumber(cnt.Text, 2)
                                Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).ReadOnly = True
                                xi += 1
                            End If
                        End If
                    Next
                    '==Total Block

                    Me.DgBOMcost.Rows.Add()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(0).Value = SetSrNO()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Value = "Total ==>"
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Style.BackColor = Color.NavajoWhite
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(2).Value = 1
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(3).Value = 1
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).Value = FormatNumber(0, 2)
                    Dim xxAmt As Double = 0 'xSetTotlDg()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Value = FormatNumber(xxAmt, 2)
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Style.BackColor = Color.NavajoWhite
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).ReadOnly = True

                    '==Profit Block
                    If Me.TxtPval.Text > 0 Then
                        Me.DgBOMcost.Rows.Add()
                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(0).Value = SetSrNO()
                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Value = "Profit (% or Value)"
                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(2).Value = 1
                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(3).Value = 1
                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).Value = FormatNumber(Me.TxtPval.Text, 2)
                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Value = 0
                        Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).ReadOnly = True
                    End If

                    '==Sub Total Block

                    Me.DgBOMcost.Rows.Add()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(0).Value = SetSrNO()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Value = "Sub Total ==>"
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Style.BackColor = Color.Yellow
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(2).Value = 1
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(3).Value = 1
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).Value = FormatNumber(0, 2)
                    Dim xxxAmt As Double = xSetTotlDg()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Value = 0 ' FormatNumber(xxxAmt - xxAmt, 2)
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Style.BackColor = Color.Yellow
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).ReadOnly = True
                    Me.Panel1.Enabled = False

                    '==Agent's Commission Block

                    Me.DgBOMcost.Rows.Add()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(0).Value = SetSrNO()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Value = "Agent's Commission ==>"
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Style.BackColor = Color.White
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(2).Value = 1
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(3).Value = 1
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).Value = FormatNumber(Me.TxtACom.Text, 2)
                    Dim xxxAmt1 As Double = xSetTotlDg()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Value = 0 ' FormatNumber(xxxAmt1 - xxAmt, 2)
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Style.BackColor = Color.White
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).ReadOnly = True
                    Me.Panel1.Enabled = False

                    '==Add MRP Percentage Block

                    Me.DgBOMcost.Rows.Add()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(0).Value = SetSrNO()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Value = "Add MRP Percentage ==>"
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Style.BackColor = Color.White
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(2).Value = 1
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(3).Value = 1
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).Value = FormatNumber(Me.TxtMrp.Text, 2)
                    Dim xxxAmt2 As Double = xSetTotlDg()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Value = 0 ' FormatNumber(xxxAmt1 - xxAmt, 2)
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Style.BackColor = Color.White
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).ReadOnly = True
                    Me.Panel1.Enabled = False

                    '==MRP  Block

                    Me.DgBOMcost.Rows.Add()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(0).Value = SetSrNO()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Value = "List Rate (MRP) ==>"
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(1).Style.BackColor = Color.Cyan
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(2).Value = 1
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(3).Value = 1
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).Value = FormatNumber(0, 2)
                    Dim xxxAmt3 As Double = xSetTotlDg()
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Value = 0 ' FormatNumber(xxxAmt1 - xxAmt, 2)
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(5).Style.BackColor = Color.Cyan
                    Me.DgBOMcost.Rows(SetSrNO() - 1).Cells(4).ReadOnly = True
                    Me.Panel1.Enabled = False
                Else
                    xSelRecFromTbl()
                    DgIndx = 1
                End If
            Next ix
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xReSetGridTotoal()
        End Try
    End Sub
    Private Function SetSrNO() As Integer
        Try
            Return Me.DgBOMcost.Rows.Count

        Catch ex As Exception

        End Try
    End Function
    Private Function xSetTotlDg() As Double
        Try
            Dim Amt As Double = 0
            For Each xxRw As DataGridViewRow In Me.DgBOMcost.Rows
                Amt += xxRw.Cells(5).Value
            Next
            Return Amt
        Catch ex As Exception

        End Try
    End Function

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If Me.CmbxBcName.SelectedIndex = -1 Then
                Me.CmbxBcName.BackColor = Color.Cyan
                Me.CmbxBcName.Focus()
                Exit Sub
            Else
                Me.CmbxBcName.BackColor = Color.White
            End If
            If Me.CmbxMthd.SelectedIndex = -1 Then
                Me.CmbxMthd.BackColor = Color.Cyan
                Me.CmbxMthd.Focus()
                Exit Sub
            Else
                Me.CmbxMthd.BackColor = Color.White
            End If
            If Not Me.TxtPval.Text > 0 Then
                Me.TxtPval.Focus()
                Me.TxtPval.BackColor = Color.Cyan
                Exit Sub
            Else
                Me.TxtPval.BackColor = Color.White
            End If

            If Not Me.TxtACom.Text > 0 Then
                Me.TxtACom.Focus()
                Me.TxtACom.BackColor = Color.Cyan
                Exit Sub
            Else
                Me.TxtACom.BackColor = Color.White
            End If

            If Not Me.TxtMrp.Text > 0 Then
                Me.TxtMrp.Focus()
                Me.TxtMrp.BackColor = Color.Cyan
                Exit Sub
            Else
                Me.TxtMrp.BackColor = Color.White
            End If
            xFill_Dg()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Clr_Cntrl()
        Try
            Dim cntr As Control
            DgIndx = 0
            For Each cntr In Me.Panel1.Controls
                If TypeOf cntr Is TextBox Then
                    cntr.Text = FormatNumber(0, 2)
                End If
            Next
            Me.CmbxMthd.SelectedIndex = -1
            Me.CmbxBcName.SelectedIndex = -1
            Me.Dtpbc1.Focus()
            Me.DgBOMcost.Rows.Clear()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        Try
            Clr_Cntrl()
            Me.Panel1.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgBOMcost_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgBOMcost.CellEndEdit
        Try
            If e.ColumnIndex = 4 Then
                Me.DgBOMcost.CurrentRow.Cells(e.ColumnIndex).Value = FormatNumber(Me.DgBOMcost.CurrentRow.Cells(e.ColumnIndex).Value, 2)
                xReSetGridTotoal()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgBOMcost_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgBOMcost.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgBOMcost.Rows.Count '- 1
            If Cr_Row <> Me.DgBOMcost.CurrentRow.Index Then
                If e.ColumnIndex = 4 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgBOMcost.CurrentCell.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        Me.DgBOMcost.CurrentCell.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgBOMcost_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgBOMcost.CellValueChanged
        Try
            If e.ColumnIndex = 4 Then
                If Me.DgBOMcost.Rows.Count > 0 Then
                    Dim col2 As Double = Me.DgBOMcost.CurrentRow.Cells(2).Value
                    Dim col3 As Integer = Me.DgBOMcost.CurrentRow.Cells(3).Value
                    Dim col4 As Double = Me.DgBOMcost.CurrentRow.Cells(4).Value
                    Dim Col5 As Double = col2 * col4 / col3
                    Me.DgBOMcost.Rows(e.RowIndex).Cells(5).Value = FormatNumber(Col5, 2)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xReSetGridTotoal()
        Try
            Dim Amt1 As Double = 0
            Dim Amt2 As Double = 0
            Dim Amt3 As Double = 0
            Dim Amt4 As Double = 0
            Dim Amt6 As Double = 0
            Dim Amt7 As Double = 0
            Dim Amt8 As Double = 0


            Dim Rindx1 As Integer = 0
            Dim Rindx2 As Integer = 0
            Dim Rindx3 As Integer = 0
            Dim Rindx4 As Integer = 0
            Dim Rindx5 As Integer = 0
            Dim Rindx6 As Integer = 0
        
            For Each Rxw As DataGridViewRow In Me.DgBOMcost.Rows
                If Trim(Rxw.Cells(1).Value) = "Total ==>" Then
                    Amt1 = Rxw.Cells(5).Value
                    Rindx1 = Rxw.Index
                End If
                If Trim(Rxw.Cells(1).Value) = "Profit (% or Value)" Then
                    Amt2 = Rxw.Cells(5).Value
                    Rindx2 = Rxw.Index
                End If
                If Trim(Rxw.Cells(1).Value) = "Sub Total ==>" Then
                    Amt3 = Rxw.Cells(5).Value
                    Rindx3 = Rxw.Index
                End If

                If Trim(Rxw.Cells(1).Value) = "Agent's Commission ==>" Then
                    Amt6 = Rxw.Cells(5).Value
                    Rindx4 = Rxw.Index
                End If

                If Trim(Rxw.Cells(1).Value) = "Add MRP Percentage ==>" Then
                    Amt7 = Rxw.Cells(5).Value
                    Rindx5 = Rxw.Index
                End If

                If Trim(Rxw.Cells(1).Value) = "List Rate (MRP) ==>" Then
                    Amt8 = Rxw.Cells(5).Value
                    Rindx6 = Rxw.Index
                End If

              

                Amt4 += Rxw.Cells(5).Value
            Next

            Me.DgBOMcost.Rows(Rindx1).Cells(5).Value = FormatNumber(Amt4 - (Amt1 + Amt2 + Amt3), 2)
            Dim xPrft As Double = 0
            If Me.Rbcalpcent.Checked = True Then
                Dim xPrcnt As Double = Me.TxtPval.Text
                Dim Amt5 As Double = Amt4 - (Amt1 + Amt2 + Amt3)
                xPrft = Amt5 * xPrcnt / 100
                Me.DgBOMcost.Rows(Rindx2).Cells(5).Value = FormatNumber(xPrft, 2)
            Else
                Me.DgBOMcost.Rows(Rindx2).Cells(5).Value = FormatNumber(Me.TxtPval.Text, 2)
            End If
            Me.DgBOMcost.Rows(Rindx3).Cells(5).Value = FormatNumber((Amt4 + xPrft) - (Amt1 + Amt2 + Amt3), 2) 'sub total

            Dim xSub As Double = FormatNumber((Amt4 + xPrft) - (Amt1 + Amt2 + Amt3), 2)
            Dim xAcom As Double = FormatNumber(Me.TxtACom.Text, 2)
            Dim xAcomNet As Double = xSub * xAcom / 100
            Me.DgBOMcost.Rows(Rindx4).Cells(5).Value = FormatNumber(xAcomNet, 2) 'Agent commission

            Dim xMRP1 As Double = Me.TxtMrp.Text
            Dim xMRpNet As Double = (xSub + xAcomNet) * xMRP1 / 100

            Me.DgBOMcost.Rows(Rindx5).Cells(5).Value = FormatNumber(xMRpNet, 2) ' MRP Percentage

            Me.DgBOMcost.Rows(Rindx6).Cells(5).Value = FormatNumber((xSub + xAcomNet + xMRpNet), 2) ' List Rate

        Catch ex As Exception

        End Try
    End Sub
    Private Sub xSelRecFromTbl()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            BcCmd = New SqlCommand("Finact_Rpt_Temp_BomCosting_Filltable", FinActConn)
            BcCmd.CommandType = CommandType.StoredProcedure
            BcCmd.Parameters.AddWithValue("@xBomid", Me.CmbxBcName.SelectedValue)
            BcCmd.ExecuteNonQuery()
            BcCmd.Dispose()

            BcCmd = New SqlCommand("Finact_Rpt_Temp_BomCosting_Select", FinActConn)
            BcCmd.CommandType = CommandType.StoredProcedure
            BcCmd.Parameters.AddWithValue("@xBomIndx", Me.CmbxMthd.SelectedIndex)
            BcRdr = BcCmd.ExecuteReader
            Me.DgBOMcost.Rows.Clear()
            Dim ix As Integer = 0
            While BcRdr.Read
                If BcRdr.IsDBNull(0) = False Then
                    Me.DgBOMcost.Rows.Add()
                    Me.DgBOMcost.Rows(ix).Cells(0).Value = SetSrNO()
                    Me.DgBOMcost.Rows(ix).Cells(1).Value = Trim(BcRdr("bcbomitmname"))
                    Me.DgBOMcost.Rows(ix).Cells(2).Value = FormatNumber(BcRdr("bcbomitmqnty"), 3)
                    Me.DgBOMcost.Rows(ix).Cells(3).Value = FormatNumber(BcRdr("bcbomitmratio"), 0)
                    Me.DgBOMcost.Rows(ix).Cells(4).Value = FormatNumber(BcRdr("bcbomitmrate"), 2)
                    Dim col2 As Double = FormatNumber(BcRdr("bcbomitmqnty"), 3)
                    Dim col3 As Integer = FormatNumber(BcRdr("bcbomitmratio"), 0)
                    Dim col4 As Double = FormatNumber(BcRdr("bcbomitmrate"), 2)
                    Dim Col5 As Double = col2 * col4 / col3
                    Me.DgBOMcost.Rows(ix).Cells(5).Value = FormatNumber(Col5, 2)
                    ix += 1
                End If

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            BcCmd.Dispose()
            BcRdr.Close()
        End Try
    End Sub

    Private Sub TxtPval_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPval.Leave, TxtEc.Leave, TxtLc.Leave _
    , TxtMc.Leave, TxtOc.Leave, TxtTwC.Leave, TxtMrp.Leave, TxtACom.Leave
        Try
            Dim tbx As TextBox = CType(sender, TextBox)
            If Len(Trim(tbx.Text)) = 0 Then
                tbx.Text = 0
            End If
            If xChk_numericValidation(tbx) = False Then
                tbx.Text = FormatNumber(tbx.Text, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xSavexRecx2xtbl()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
           
            For Each xrrw As DataGridViewRow In Me.DgBOMcost.Rows
                BcCmd = New SqlCommand("Finact_Rpt_Temp_RptFromGrid_Insert", FinActConn)
                BcCmd.CommandType = CommandType.StoredProcedure
                BcCmd.Parameters.AddWithValue("@bcbomdt", Me.Dtpbc1.Value.Date)
                BcCmd.Parameters.AddWithValue("@bcbomname", Trim(Me.CmbxBcName.Text))
                BcCmd.Parameters.AddWithValue("@bcbommthd", Trim(Me.CmbxMthd.Text))
                If Me.Rbcalpcent.Checked = True Then
                    BcCmd.Parameters.AddWithValue("@bcbomprfttype", Trim(Me.Rbcalpcent.Text))
                Else
                    BcCmd.Parameters.AddWithValue("@bcbomprfttype", Trim(Me.RbCalVal.Text))
                End If
                BcCmd.Parameters.AddWithValue("@bcbomremrk", Trim(Me.TxtRemrks.Text))
                BcCmd.Parameters.AddWithValue("@srno", xrrw.Cells(0).Value)
                BcCmd.Parameters.AddWithValue("@bcbomitmname", xrrw.Cells(1).Value)
                BcCmd.Parameters.AddWithValue("@bcbomitmqnty", xrrw.Cells(2).Value)
                BcCmd.Parameters.AddWithValue("@bcbomitmratio", xrrw.Cells(3).Value)
                BcCmd.Parameters.AddWithValue("@bcbomitmrate", xrrw.Cells(4).Value)
                BcCmd.Parameters.AddWithValue("@bcbomamt", xrrw.Cells(5).Value)
                BcCmd.ExecuteNonQuery()
                BcCmd.Dispose()
            Next
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Dim xSno As Integer = 1
            For Each xrrw1 As DataGridViewRow In Me.DgDtlChrgs.Rows
                If xrrw1.Cells(2).Value > 0 Then
                    BcCmd = New SqlCommand("Finact_Temp_OvrHed_Insert", FinActConn)
                    BcCmd.CommandType = CommandType.StoredProcedure
                    BcCmd.Parameters.AddWithValue("@OhSrNo", xSno)
                    BcCmd.Parameters.AddWithValue("@Ohname", Trim(xrrw1.Cells(1).Value))
                    BcCmd.Parameters.AddWithValue("@Ohamt", CDbl(xrrw1.Cells(2).Value))
                    BcCmd.ExecuteNonQuery()
                    BcCmd.Dispose()
                    xSno += 1
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            'BcCmd.Dispose()
        End Try

    End Sub

  

    Private Sub BtnRptVewLdgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click
        Try
            If Me.DgBOMcost.RowCount = 0 Then
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            xSavexRecx2xtbl()
            Dim frmRbc As New FrmCrRptBoMCostingChild
            frmRbc.ShowInTaskbar = False
            frmRbc.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkRptLdgr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptLdgr.CheckedChanged
        Try
            If Me.ChkRptLdgr.Checked = True Then
                xCrptFlag = True
            Else
                xCrptFlag = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.BtnOk_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Try
            xReSetGridTotoal()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Try
            Me.BtnRptVewLdgr_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CancelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelToolStripMenuItem.Click
        Try
            Me.BtnCncl_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOthr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOthr.Click
        Try
            Me.DgDtlChrgs.Location = New System.Drawing.Point(281, 130)
            Me.DgDtlChrgs.Visible = True
            Me.DgDtlChrgs.Enabled = True
            xFill_DgDtls()
            Me.DgDtlChrgs.Focus()
            Me.DgDtlChrgs.Rows(0).Selected = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFill_DgDtls()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()

            BcCmd = New SqlCommand("Finact_OvrHedmstr_Select", FinActConn)
            BcCmd.CommandType = CommandType.StoredProcedure
            BcRdr = BcCmd.ExecuteReader
            Dim ix As Integer = 0
            Me.DgDtlChrgs.Rows.Clear()
            While BcRdr.Read
                Me.DgDtlChrgs.Rows.Add()
                Me.DgDtlChrgs.Rows(ix).Cells(0).Value = BcRdr("ohid")
                Me.DgDtlChrgs.Rows(ix).Cells(1).Value = BcRdr("Ohname")
                Me.DgDtlChrgs.Rows(ix).Cells(2).Value = FormatNumber(BcRdr("Ohamt"), 2)
                ix += 1
            End While
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgBOMcost_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgBOMcost.CellContentClick

    End Sub

    Private Sub DgDtlChrgs_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDtlChrgs.CellEndEdit
        Try
            Try
                If e.ColumnIndex = 2 Then
                    Me.DgDtlChrgs.CurrentRow.Cells(e.ColumnIndex).Value = FormatNumber(Me.DgDtlChrgs.CurrentRow.Cells(e.ColumnIndex).Value, 2)
                    xReSetGridTotoal()
                End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgDtlChrgs_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgDtlChrgs.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgDtlChrgs.Rows.Count '- 1
            If Cr_Row <> Me.DgDtlChrgs.CurrentRow.Index Then
                If e.ColumnIndex = 2 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgDtlChrgs.CurrentCell.ErrorText = "Only Number are allowed"
                        e.Cancel = True
                    Else
                        Me.DgDtlChrgs.CurrentCell.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgDtlChrgs_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDtlChrgs.CellValueChanged
        Try
            If Me.DgDtlChrgs.Rows.Count > 0 Then
                Dim Oth As Double = 0
                For Each xrw As DataGridViewRow In Me.DgDtlChrgs.Rows
                    Oth += CDbl(xrw.Cells(2).Value)
                Next
                Me.TxtOc.Text = FormatNumber(Oth, 2)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub

    Private Sub DgDtlChrgs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgDtlChrgs.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.DgDtlChrgs.Location = New System.Drawing.Point(908, 145)
                Me.Rbcalpcent.Focus()
                Me.DgDtlChrgs.Visible = False
                Me.DgDtlChrgs.Enabled = False
                Exit Sub
            End If
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                Dim Inx As Integer = Me.DgDtlChrgs.Columns.Count
                If Me.DgDtlChrgs.CurrentCell.ColumnIndex = Inx - 1 Then

                    If Me.DgDtlChrgs.CurrentCell.RowIndex < Me.DgDtlChrgs.RowCount - 1 Then
                        Me.DgDtlChrgs.CurrentCell = Me.DgDtlChrgs.Item(1, Me.DgDtlChrgs.CurrentCell.RowIndex + 1)
                    Else
                        Me.DgDtlChrgs.Location = New System.Drawing.Point(908, 145)
                        Me.Rbcalpcent.Focus()

                        Me.DgDtlChrgs.Visible = False
                        Me.DgDtlChrgs.Enabled = False

                    End If
                Else
                    Me.DgDtlChrgs.CurrentCell = Me.DgDtlChrgs.Item(Me.DgDtlChrgs.CurrentCell.ColumnIndex + 1, Me.DgDtlChrgs.CurrentCell.RowIndex)
                End If

                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub DgBOMcost_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgBOMcost.CellEnter
        Try

            If Trim(Me.DgBOMcost.CurrentRow.Cells(1).Value) = "Other Charges" Then
                Me.DgDtlChrgs.Location = New System.Drawing.Point(281, 130)
                Me.DgDtlChrgs.Visible = True
                Me.DgDtlChrgs.Enabled = True
            Else
                Me.DgDtlChrgs.Location = New System.Drawing.Point(908, 145)
                Me.DgDtlChrgs.Visible = False
                Me.DgDtlChrgs.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgBOMcost_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgBOMcost.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.ChkRptLdgr.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkRptLdgr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkRptLdgr.Leave
        Try
            Me.ChkRptLdgr.BackColor = Color.Transparent
            Me.ChkRptLdgr.ForeColor = Color.Black
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Rbcalpcent_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rbcalpcent.Leave
        Try
            Me.Rbcalpcent.BackColor = Color.Transparent
            Me.Rbcalpcent.ForeColor = Color.Black
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RbCalVal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCalVal.Leave
        Try
            Me.RbCalVal.BackColor = Color.Transparent
            Me.RbCalVal.ForeColor = Color.Black
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgDtlChrgs_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDtlChrgs.CellContentClick

    End Sub

    Private Sub TxtPval_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPval.TextChanged

    End Sub
End Class
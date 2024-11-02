Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmTranProductionMovment
    Dim Prod_Cmd As SqlCommand
    Dim Prod_Rdr As SqlDataReader
    Dim Prod_Cmd1 As SqlCommand
    Dim Prod_Rdr1 As SqlDataReader
    Dim Prod_Adptr As SqlDataAdapter
    Dim Prod_DataSet As DataSet
    Dim NxProdid, CurBomid, CurConid, prod_Machid, NxtProcsid As Integer
    Dim NxProdName, CurProcsname As String
    Dim AloCancl As Boolean = False
    Dim ChkIndx, ChkProcs, MaxProcsid, BomLocid, Cond As Integer
    ' Dim Cond1 As Integer = 0

    Private Sub FrmTranProductionMovment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.SplitContainer1.SplitterDistance = 590
            Me.DtpProddt.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxBatchno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxBatchno.GotFocus
        Try
            Me.cmbxBatchno.DroppedDown = True
            If cmbxBatchno.Items.Count > 0 Then
                If cmbxBatchno.SelectedIndex = -1 Then
                    cmbxBatchno.SelectedIndex = 0
                End If
                Try
                    'If Trim(Me.Lbliname.Text) = "" Then
                    Fetch_BatchNo_Record()
                    'End If
                Catch ex As Exception

                End Try

            End If
            
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fetch_BatchNo()
        Try
            Prod_DataSet = New DataSet
            Prod_DataSet.Tables.Clear()
            Prod_Cmd = New SqlCommand("Finact_MaterialMoveMstr_selectBathNo", FinActConn)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Prod_Cmd.Parameters.AddWithValue("@Curdate", Me.DtpProddt.Value.Date)
            Prod_Cmd.Parameters.AddWithValue("@Wrkrid", Me.cmbxworker1.SelectedValue)
            Prod_Adptr = New SqlDataAdapter(Prod_Cmd)
            Prod_DataSet = New DataSet(Prod_Cmd.CommandText)
            Prod_Adptr.Fill(Prod_DataSet)
            Me.cmbxBatchno.DataSource = Prod_DataSet.Tables(0)
            Me.cmbxBatchno.ValueMember = "matmovid"
            Me.cmbxBatchno.DisplayMember = "batchno"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
            Prod_Adptr.Dispose()
        End Try
    End Sub
    Private Function Fetch_WorkrMachn() As Boolean
        Try
            Prod_DataSet = New DataSet
            Prod_DataSet.Tables.Clear()
            Prod_Cmd = New SqlCommand("Finact_MaterialMoveMstr_selectWorker", FinActConn)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Prod_Cmd.Parameters.AddWithValue("@Curdate1", Me.DtpProddt.Value.Date)
            Prod_Adptr = New SqlDataAdapter(Prod_Cmd)
            Prod_DataSet = New DataSet(Prod_Cmd.CommandText)
            Prod_Adptr.Fill(Prod_DataSet)
            Me.CmbxWorker1.DataSource = Prod_DataSet.Tables(0)
            Me.CmbxWorker1.ValueMember = "empid"
            Me.CmbxWorker1.DisplayMember = "empname"
            Me.CmbxWorker1.Tag = "empwrkid"
            If Not (Prod_DataSet.Tables(0).Rows.Count) > 0 Then
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
            Prod_Adptr.Dispose()
        End Try
    End Function



    Private Sub DtpProddt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpProddt.Leave
        Try
            If Fetch_WorkrMachn() Then
                Me.Lblerr.Text = Trim("System could not found any record. Try another date")
                Me.Lblerr.Visible = True
                Me.DtpProddt.Focus()
                Exit Sub
            Else
                Me.Lblerr.Visible = False
                Me.cmbxworker1.Focus()
                Me.cmbxworker1.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmbxBatchno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxBatchno.Leave
        Try
            Me.cmbxBatchno.DroppedDown = False
            If Trim(Me.Lbliname.Text) = "" Then
                Fetch_BatchNo_Record()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fetch_BatchNo_Record()
        Try
            Prod_Cmd = New SqlCommand("Finact_MaterialMoveMstr_selectBatchrecord", FinActConn)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Prod_Cmd.Parameters.AddWithValue("@Batchid", Me.cmbxBatchno.SelectedValue)
            Prod_Rdr = Prod_Cmd.ExecuteReader
            While Prod_Rdr.Read = True
                If Prod_Rdr.IsDBNull(0) = False Then
                    Me.Lbliname.Text = Trim(Prod_Rdr(5).ToString())
                    Me.lbliqnty.Text = FormatNumber(Prod_Rdr(2), 3)
                    Me.lblalprod.Text = FormatNumber(Prod_Rdr(3), 3)
                    Me.lblbalqnty1.Text = FormatNumber(Prod_Rdr(4), 3)
                    Me.lblunttype.Text = Trim(Prod_Rdr(6).ToString())
                    Me.lblunt.Text = Trim(Prod_Rdr(6).ToString())
                    CurConid = Prod_Rdr(0)
                    CurBomid = Prod_Rdr(7)
                    Me.lblsdate.Text = Format(Prod_Rdr(1), "dd/MM/yyyy")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
            Prod_Rdr.Close()
            If CurBomid > 0 Then
                Curr_procesName()
            End If
        End Try
    End Sub

    Private Sub cmbxBatchno_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxBatchno.SelectionChangeCommitted
        Try
            Fetch_BatchNo_Record()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtProcdqnty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProcdqnty.GotFocus
        If Trim(Me.TxtProcdqnty.Text) = "" Then
            TxtProcdqnty.Text = Me.lblbalqnty1.Text
        End If

        Me.TxtProcdqnty.SelectAll()
    End Sub

    Private Sub TxtProcdqnty_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProcdqnty.HandleCreated

    End Sub

    Private Sub TxtProcdqnty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProcdqnty.Leave
        Try
            Dim Qval1a, Qval2a As Double
            If Trim(Me.TxtProcdqnty.Text) <> "" And IsNumeric(Me.TxtProcdqnty.Text) = True Then
                If Me.Rbfirst.Checked = True Then
                    Qval1a = Me.lblbalqnty.Text
                ElseIf Me.Rbreprocs.Checked = True Then
                    Qval1a = Me.lblreprocs.Text
                End If
                'Qval1a = Me.lblbalqnty.Text
                Qval2a = Me.TxtProcdqnty.Text
                If Not Qval2a > 0 Or Qval2a > Qval1a Then
                    Me.Lblerr.Text = Trim("Quanty should be greater than zero or less than balance quantity")
                    Me.Lblerr.Visible = True
                    Me.TxtProcdqnty.Focus()
                    Me.TxtProcdqnty.SelectAll()
                    Exit Sub
                Else
                    Me.Lblerr.Visible = False
                End If
            Else
                Me.TxtProcdqnty.Focus()
                Me.TxtProcdqnty.SelectAll()
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub TxtProcdqnty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProcdqnty.TextChanged
        Try
            If AloCancl = False Then
                Dim Qval1, Qval2, Qval3 As Double
                If Trim(Me.TxtProcdqnty.Text) <> "" And IsNumeric(Me.TxtProcdqnty.Text) = True Then
                    If Me.Rbfirst.Checked = True Then
                        Qval1 = Me.lblbalqnty.Text
                    ElseIf Me.Rbreprocs.Checked = True Then
                        Qval1 = Me.lblreprocs.Text
                    End If
                    Qval3 = Me.lbluprocs.Text
                    Qval2 = Me.TxtProcdqnty.Text
                    If Qval2 > Qval1 Then
                        Me.Lblerr.Text = Trim("Quanty should be equal or less than  " & FormatNumber(Qval1, 3))
                        Me.Lblerr.Visible = True
                        Me.TxtProcdqnty.Focus()
                        Me.TxtProcdqnty.SelectAll()
                        Exit Sub
                    Else
                        If Me.Rbfirst.Checked = True Then
                            If Qval2 = Qval1 Or Qval1 = Qval3 Then
                                Me.txtundrprocs.Enabled = False
                                Me.txtundrprocs.Text = 0
                            Else
                                Me.txtundrprocs.Enabled = True
                            End If
                        End If

                        End If
                        Me.lblnet.Text = FormatNumber(Qval2, 3)
                        Me.Lblerr.Visible = False
                Else
                        Me.Lblerr.Text = Trim("Invalid input! Only Numeric are allowed")
                        Me.Lblerr.Visible = True
                        Me.TxtProcdqnty.Focus()
                        Me.TxtProcdqnty.SelectAll()

                End If
                End If
            Dim Netval As Double = Me.lblnet.Text
            If Not Netval > 0 Then
                Me.CmbxNxtworker.SelectedValue = Me.cmbxworker1.SelectedValue
                Me.CmbxNxtworker.Enabled = False
            Else
                Me.CmbxNxtworker.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbxwtqntyloss_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxwtqntyloss.GotFocus
        Try
            Me.cmbxwtqntyloss.DroppedDown = True
            If Me.cmbxwtqntyloss.SelectedIndex = -1 Then
                Me.cmbxwtqntyloss.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxScrap_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxScrap.GotFocus
        Try
            Me.CmbxScrap.DroppedDown = True
            If Me.CmbxScrap.SelectedIndex = -1 Then
                Me.CmbxScrap.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtundrprocs_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtundrprocs.GotFocus
        Try
            If Trim(Me.txtundrprocs.Text) = "" Then
                Me.txtundrprocs.Text = 0
            End If
            Me.txtundrprocs.SelectAll()
            If Me.Rbreprocs.Checked = True Then
                Me.txtundrprocs.Enabled = False
                Me.txtsend.Enabled = False
            Else
                Me.txtundrprocs.Enabled = True
                Me.txtsend.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtundrprocs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtundrprocs.Leave
        Try
            If IsNumeric(Me.txtundrprocs.Text) = False Then
                Me.txtundrprocs.Focus()
                Me.txtundrprocs.SelectAll()
            Else
                Dim Uval, Uval1, Uval2 As Double
                Uval = Me.txtundrprocs.Text
                If Me.Rbfirst.Checked = True Then
                    Uval1 = Me.lblbalqnty.Text
                ElseIf Me.Rbreprocs.Checked = True Then
                    Uval1 = Me.lblreprocs.Text
                End If
                'Uval1 = Me.lblbalqnty.Text
                Uval2 = Me.TxtProcdqnty.Text
                If (Uval + Uval2) > Uval1 Then
                    Me.txtundrprocs.Focus()
                    Me.txtundrprocs.SelectAll()
                    Me.Lblerr.Text = Trim("Invalid input! quantity should not be greater than balance quantity")
                    Me.Lblerr.Visible = True
                Else
                    Me.Lblerr.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtundrprocs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtundrprocs.TextChanged
        Try
            If AloCancl = False Then
                Dim Qval1, Qval2, Qval3, Qval4 As Double
                If Trim(Me.txtundrprocs.Text) <> "" And IsNumeric(Me.txtundrprocs.Text) = True Then
                    If Me.Rbfirst.Checked = True Then
                        Qval1 = Me.lblbalqnty.Text
                    ElseIf Me.Rbreprocs.Checked = True Then
                        Qval1 = Me.lblreprocs.Text
                    End If
                    'Qval1 = Me.lblbalqnty.Text
                    Qval4 = Me.lbluprocs.Text
                    Qval2 = Me.txtundrprocs.Text
                    If Trim(Me.TxtProcdqnty.Text) <> "" Then
                        Qval3 = Me.TxtProcdqnty.Text
                    End If
                    If Qval2 > (Qval1 - Qval3) Then
                        Me.Lblerr.Text = Trim("Quanty should be equal or less than  " & FormatNumber(Qval1 - Qval3, 3))
                        Me.Lblerr.Visible = True
                        Me.txtundrprocs.Focus()
                        Me.txtundrprocs.SelectAll()
                        Exit Sub
                    Else
                        If Qval2 = Qval1 Then
                            Me.txtsend.Enabled = False
                            Me.txtsend.Text = 0
                        Else
                            Me.txtsend.Enabled = True
                        End If
                    End If
                    Me.Lblerr.Visible = False
                Else
                    Me.Lblerr.Text = Trim("Invalid input! Only Numeric are allowed")
                    Me.Lblerr.Visible = True
                    Me.txtundrprocs.Focus()
                    Me.txtundrprocs.SelectAll()

                End If


            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtsend_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsend.GotFocus
        Try
            If Trim(Me.txtsend.Text) = "" Then
                Me.txtsend.Text = 0
            End If
            Me.txtsend.SelectAll()
            If Me.Rbreprocs.Checked = True Then
                Me.txtundrprocs.Enabled = False
                Me.txtsend.Enabled = False
            Else
                Me.txtundrprocs.Enabled = True
                Me.txtsend.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsend_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsend.Leave
        Try
            If IsNumeric(Me.txtsend.Text) = False Then
                Me.txtsend.Focus()
                Me.txtsend.SelectAll()
            Else
                Dim Sval, Sval1 As Double
                Sval = Me.txtsend.Text
                Sval1 = Me.TxtProcdqnty.Text
                If Sval > Sval1 Then
                    Me.Lblerr.Text = Trim("Invalid input! Quantity is greater than processed quantity")
                    Me.Lblerr.Visible = True
                    Me.txtsend.Focus()
                    Me.txtsend.SelectAll()
                Else
                    Me.Lblerr.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub txtsend_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsend.TextChanged
        Try
            If AloCancl = False Then
                Dim Qval1, Qval2 As Double
                If Trim(Me.txtsend.Text) <> "" And IsNumeric(Me.txtsend.Text) = True Then
                    Qval1 = Me.txtsend.Text
                    Qval2 = Me.TxtProcdqnty.Text
                    If Qval1 > Qval2 Then
                        Me.Lblerr.Text = Trim("Quanty should be equal or less than  " & FormatNumber(Qval2, 3))
                        Me.Lblerr.Visible = True
                        Me.txtsend.Focus()
                        Me.txtsend.SelectAll()
                        Exit Sub
                    Else
                    End If
                    Me.lblnet.Text = FormatNumber(Qval2 - Qval1, 3)
                    Me.Lblerr.Visible = False
                Else
                    Me.Lblerr.Text = Trim("Invalid input! Only Numeric are allowed")
                    Me.Lblerr.Visible = True
                    Me.txtsend.Focus()
                    Me.txtsend.SelectAll()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxworker1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxworker1.GotFocus
        Try
            Me.cmbxworker1.DroppedDown = True
            If Trim(Me.Lbliname.Text) = "" Then
                Fetch_BatchNo()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxworker1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxworker1.Leave
        Try
            Me.cmbxworker1.DroppedDown = False
            If Trim(Me.cmbxBatchno.Text) = "" Then
                If Trim(Me.cmbxworker1.Text) <> "" Then
                    Fetch_BatchNo()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub cmbxworker1_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxworker1.SelectionChangeCommitted
        Try
            Fetch_BatchNo()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Curr_procesName()
        Try
            Prod_DataSet = New DataSet
            Prod_DataSet.Tables.Clear()
            Prod_Cmd = New SqlCommand("Finact_ProcessMovementSqlMstr_SelectNxtProcess_1", FinActConn)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Prod_Cmd.Parameters.AddWithValue("@bomitid", CurBomid)
            Prod_Cmd.Parameters.AddWithValue("@pconid", CurConid)
            Prod_Cmd.Parameters.AddWithValue("@wrkrid", Me.cmbxworker1.SelectedValue)
            Prod_Adptr = New SqlDataAdapter(Prod_Cmd)
            Prod_DataSet = New DataSet(Prod_Cmd.CommandText)
            Prod_Adptr.Fill(Prod_DataSet)
            Me.CmbxPname.DataSource = Prod_DataSet.Tables(0)
            Me.CmbxPname.ValueMember = "matmovprocsid"
            Me.CmbxPname.DisplayMember = "pname"
            Me.CmbxPname.Tag = "matmprocsno"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
            Prod_Adptr.Dispose()

        End Try
    End Sub
    Private Sub Nxt_procesName()
        Try
            Max_procesid()
            Prod_Cmd = New SqlCommand("Finact_Finact_ProcessMovementSqlMstr_SelectNxtProcess", FinActConn)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Prod_Cmd.Parameters.AddWithValue("@bomiid", CurBomid)

            If (MaxProcsid) > NxProdid Then
                Prod_Cmd.Parameters.AddWithValue("@psqlno", NxProdid + 1)
            Else
                Prod_Cmd.Parameters.AddWithValue("@psqlno", NxProdid)
            End If

            Prod_Rdr = Prod_Cmd.ExecuteReader
            While Prod_Rdr.Read = True
                If Prod_Rdr.IsDBNull(0) = False Then
                    NxtProcsid = Trim(Prod_Rdr(0))
                    Me.LblNxtprocs.Text = Trim((Prod_Rdr(1).ToString))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
            Prod_Rdr.Close()
            Try

                If Max_procesid() = NxProdid Then 'NxtProcsid Then
                    Me.lblnxtp.Text = "WareHouse Name"
                    Me.lblwrkrn.Text = "Receiving Person's Name"
                    Me.lbldesi.Text = "Designation"
                    BOm_Location_name_id()
                    Cond = 0

                Else
                    Me.lblnxtp.Text = "Next Process"
                    Me.lblwrkrn.Text = "Worker's Name"
                    Me.lbldesi.Text = "Machine No/Name"
                    Cond = 1


                End If

            Catch ex As Exception

            End Try
        End Try
    End Sub

    Private Function Fetch_WorkrMachn_all() As Boolean
        Try
            Prod_DataSet = New DataSet
            Prod_DataSet.Tables.Clear()
            Prod_Cmd = New SqlCommand("Finact_MaterialMoveMstr_selectWorker_all", FinActConn)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Prod_Cmd.Parameters.AddWithValue("@wrkrnotid", Me.cmbxworker1.SelectedValue)
            Prod_Cmd.Parameters.AddWithValue("@bomid", Me.cmbxBatchno.SelectedValue)
            Prod_Cmd.Parameters.AddWithValue("@procsid", Me.CmbxPname.SelectedValue)
            Prod_Adptr = New SqlDataAdapter(Prod_Cmd)
            Prod_DataSet = New DataSet(Prod_Cmd.CommandText)
            Prod_Adptr.Fill(Prod_DataSet)
            Me.CmbxNxtworker.DataSource = Prod_DataSet.Tables(0)
            Me.CmbxNxtworker.ValueMember = "empid"
            Me.CmbxNxtworker.DisplayMember = "empname"
            Me.CmbxNxtworker.Tag = "empwrkid"
            If Not (Prod_DataSet.Tables(0).Rows.Count) > 0 Then
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
            Prod_Adptr.Dispose()
        End Try
    End Function

    Private Sub CmbxNxtworker_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxNxtworker.GotFocus
        Try
            Me.CmbxNxtworker.DroppedDown = True
            Fetch_WorkrMachn_all()
            If CmbxNxtworker.Items.Count > 0 Then
                If CmbxNxtworker.SelectedIndex = -1 Then
                    CmbxNxtworker.SelectedIndex = 0
                End If

            Else
                'Fetch_WorkrMachn_all()
                CmbxNxtworker.SelectedIndex = 0

            End If
            If CmbxNxtworker.Items.Count > 0 Then
                Try
                    'If Trim(Me.lblNxtmach.Text) = "" Then
                    Select_WrkrmachineName()
                    ' End If
                Catch ex As Exception

                End Try
            End If
            Dim Netval As Double = Me.lblnet.Text
            If Not Netval > 0 Then
                Me.CmbxNxtworker.SelectedValue = Me.cmbxworker1.SelectedValue
                Me.CmbxNxtworker.Enabled = False
            End If
        Catch ex As Exception


        End Try
    End Sub

    Private Sub CmbxNxtworker_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxNxtworker.Leave
        Try
            Me.CmbxNxtworker.DroppedDown = False
            If Trim(Me.lblNxtmach.Text) = "" Then
                Select_WrkrmachineName()
            End If
            Dim nbal As Double = Me.lblnet.Text
            If nbal > 0 Then
                If Me.cmbxworker1.SelectedValue = Me.CmbxNxtworker.SelectedValue Then
                    If MessageBox.Show("Worker Name at both side is same. Are you sure to proceed?", "Same Worker", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.CmbxNxtworker.Focus()
                        Me.CmbxNxtworker.SelectAll()
                    Else
                        Me.BtnOk.Focus()
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Select_WrkrmachineName()
        Dim xStr As String = "finactempmstr_select_workid_where"
        Prod_DataSet = New DataSet
        Prod_DataSet.Tables.Clear()
        Try
            Prod_Cmd = New SqlCommand(xStr, FinActConn1)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Prod_Cmd.Parameters.AddWithValue("@wrkid", Me.CmbxNxtworker.SelectedValue)
            Prod_Cmd.Parameters.AddWithValue("@Cond", Cond) '0 for worker designation and 1 for machine name
            Prod_Adptr = New SqlDataAdapter(Prod_Cmd)
            Prod_DataSet = New DataSet(Prod_Cmd.CommandText)
            Prod_Adptr.Fill(Prod_DataSet)
            Dim xf1 As Integer = Prod_DataSet.Tables(0).Rows.Count
            For xf1 = 0 To Prod_DataSet.Tables(0).Rows.Count - 1
                prod_Machid = Prod_DataSet.Tables(0).Rows(xf1).ItemArray(0).ToString
                Me.lblNxtmach.Text = Prod_DataSet.Tables(0).Rows(xf1).ItemArray(1).ToString
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
            Prod_Adptr.Dispose()
        End Try
    End Sub

    Private Sub CmbxNxtworker_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxNxtworker.SelectionChangeCommitted
        Try
            Select_WrkrmachineName()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Clr_Txtlblval()
        Try
            Me.TxtProcdqnty.Text = ""
            Me.txtundrprocs.Text = ""
            Me.txtsend.Text = ""
            Me.txtreason.Text = ""
            Me.Lbliname.Text = ""
            Me.lblsdate.Text = ""
            Me.lbliqnty.Text = ""
            Me.lblunt.Text = ""
            Me.lblunttype.Text = ""
            Me.lblalprod.Text = ""
            Me.lblbalqnty.Text = ""
            Me.lblNxtmach.Text = ""
            Me.LblNxtprocs.Text = ""
            Me.lblreprocs.Text = ""
            Me.lblbalqnty1.Text = ""
            Me.lblalprocsd.Text = ""
            Me.lbluprocs.Text = ""
            Me.CmbxPname.DataSource = Nothing
            Me.CmbxNxtworker.DataSource = Nothing
            Me.cmbxworker1.DataSource = Nothing
            Me.cmbxBatchno.DataSource = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCancl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancl.Click
        Try
            AloCancl = True
            Clr_Txtlblval()
            Me.DtpProddt.Focus()
            AloCancl = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExt.Click
        Me.Close()
    End Sub

    Private Sub ChekEmptyVal()
        Try
            With Me.CmbxNxtworker
                If Trim(.Text) = "" Then
                    .BackColor = Color.DarkCyan
                    .ForeColor = Color.White
                    '.Focus()
                    ChkIndx += 1
                Else
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End If
            End With

            With Me.TxtProcdqnty
                If Trim(.Text) = "" Then
                    .BackColor = Color.DarkCyan
                    .ForeColor = Color.White
                    '.Focus()
                    ChkIndx += 1
                ElseIf IsNumeric(.Text) = True Then
                    Dim Cval, Cval1 As Double
                    Cval = .Text
                    If Me.Rbfirst.Checked = True Then
                        Cval1 = Me.lblbalqnty.Text
                    ElseIf Me.Rbreprocs.Checked = True Then
                        Cval1 = Me.lblreprocs.Text
                    End If

                    If Cval > Cval1 Then
                        .BackColor = Color.DarkCyan
                        .ForeColor = Color.White
                        '.Focus()
                        ChkIndx += 1
                    Else
                        .BackColor = Color.White
                        .ForeColor = Color.Black
                    End If
                Else
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End If
            End With

            With Me.txtsend
                If IsNumeric(.Text) = True Then
                    Dim Cval, Cval1 As Double
                    Cval = .Text
                    Cval1 = Me.TxtProcdqnty.Text
                    If Cval > Cval1 Then
                        .BackColor = Color.DarkCyan
                        .ForeColor = Color.White
                        '.Focus()
                        ChkIndx += 1
                    End If
                Else
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End If
            End With

            With Me.txtundrprocs
                If IsNumeric(.Text) = True Then
                    Dim Cval, Cval1, Cval2 As Double
                    Cval = .Text
                    Cval1 = Me.TxtProcdqnty.Text
                    If Me.Rbfirst.Checked = True Then
                        Cval2 = Me.lblbalqnty.Text
                    ElseIf Me.Rbreprocs.Checked = True Then
                        Cval2 = Me.lblreprocs.Text
                    End If

                    If Cval > (Cval2 - Cval1) Then
                        .BackColor = Color.DarkCyan
                        .ForeColor = Color.White
                        '.Focus()
                        ChkIndx += 1
                    End If
                Else
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End If
            End With
            With Me.CmbxPname
                If Trim(.Text) = "" Then
                    .BackColor = Color.DarkCyan
                    .ForeColor = Color.White
                    '.Focus()
                    ChkIndx += 1
                Else
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End If
            End With


            With Me.cmbxBatchno
                If Trim(.Text) = "" Then
                    .BackColor = Color.DarkCyan
                    .ForeColor = Color.White
                    '.Focus()
                    ChkIndx += 1
                Else
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End If
            End With
            With Me.Lbliname
                If Trim(.Text) = "" Then
                    '.Focus()
                    ChkIndx += 1
                End If
            End With


            With Me.cmbxworker1
                If Trim(.Text) = "" Then
                    .BackColor = Color.DarkCyan
                    .ForeColor = Color.White
                    '.Focus()
                    ChkIndx += 1
                Else
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End If
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            ChekEmptyVal()
            If ChkIndx <> 0 Then
                ChkIndx = 0
                Exit Sub
            Else
                MMdate = Me.DtpProddt.Value.Date
                MMbatNox = Me.cmbxBatchno.Text
                MMbomidx = Me.CurBomid
                DtaSave_inRespectivetble()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DtaSave_inRespectivetble()
        Dim PId As Integer = 0
        Dim Rdm As Integer = SelMax_record()
        ReDim Process_ItemId(Rdm)
        ReDim Process_id(Rdm)

        Try

            Prod_Cmd = New SqlCommand("Finact_ChekNxtProcs_MaterialMov_Select", FinActConn)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Prod_Cmd.Parameters.AddWithValue("@NxtProcsNo", NxProdid)
            Prod_Cmd.Parameters.AddWithValue("@Movmstrid", Me.cmbxBatchno.SelectedValue)
            Prod_Rdr = Prod_Cmd.ExecuteReader
            While Prod_Rdr.Read
                If Prod_Rdr.IsDBNull(0) = False Then
                    Process_id(PId) = Prod_Rdr(0)
                    Process_Name = Trim(Prod_Rdr(1))
                    Process_ItemId(PId) = Prod_Rdr(2)
                    PId += 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
            Prod_Rdr.Close()
            Process_Allow_NxtTask = True
            Try
                If Process_id(0) > 0 Then
                    
                    Processed_Qnty = Me.lblnet.Text
                    'Cond1 = 0
                    Dim FrmAdnl As New FrmTranproductionAdnl
                    FrmAdnl.ShowInTaskbar = False
                    FrmAdnl.ShowDialog()
                Else
                    ' Cond1 = 1
                End If
            Catch ex As Exception

            End Try
        End Try
        If Process_Allow_NxtTask = False Then
            MsgBox("Current action has been cancelled!", MsgBoxStyle.Information, "Termination!!!!!")
            Me.DtpProddt.Focus()
            Exit Sub
        End If
        Try

            If Me.Rbfirst.Checked = True Then
                Prod_Cmd = New SqlCommand("Finact_HandlingProduction_Insert", FinActConn)
            ElseIf Me.Rbreprocs.Checked = True Then
                Prod_Cmd = New SqlCommand("Finact_HandlingProduction_ReprocessUpdate", FinActConn)
            End If
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            '==**-->Finact_Production_Handler

            Prod_Cmd.Parameters.AddWithValue("@prodprocsno", NxProdid)
            Prod_Cmd.Parameters.AddWithValue("@prod_mstrmov_conid", Me.cmbxBatchno.SelectedValue)
            Prod_Cmd.Parameters.AddWithValue("@prodwrkrid", Me.cmbxworker1.SelectedValue)
            Prod_Cmd.Parameters.AddWithValue("@prodQnty1", Me.TxtProcdqnty.Text)
            Prod_Cmd.Parameters.AddWithValue("@prodqnty", Me.lblnet.Text)
            Prod_Cmd.Parameters.AddWithValue("@proddt", Me.DtpProddt.Value.Date)
            Prod_Cmd.Parameters.AddWithValue("@prod_w_los_t", 0)
            Prod_Cmd.Parameters.AddWithValue("@prod_w_los_rate", 0)
            Prod_Cmd.Parameters.AddWithValue("@prod_waste_t", 0)
            Prod_Cmd.Parameters.AddWithValue("@prod_waste_rate", 0)

            If Trim(Me.txtundrprocs.Text) = "" Then
                Prod_Cmd.Parameters.AddWithValue("@produndrprocs", 0)
            Else
                Prod_Cmd.Parameters.AddWithValue("@produndrprocs", Me.txtundrprocs.Text)
            End If
            If Trim(Me.txtsend.Text) = "" Then
                Prod_Cmd.Parameters.AddWithValue("@prodreprocs", 0)
            Else
                Prod_Cmd.Parameters.AddWithValue("@prodreprocs", Me.txtsend.Text)
            End If

            Prod_Cmd.Parameters.AddWithValue("@prodnxtprocsid", NxtProcsid)
            Prod_Cmd.Parameters.AddWithValue("@prodnxtWrkrid", Me.CmbxNxtworker.SelectedValue)
            Prod_Cmd.Parameters.AddWithValue("@prodProcsid", Me.CmbxPname.SelectedValue)
            Prod_Cmd.Parameters.AddWithValue("@prodstatus", 0)
            Prod_Cmd.Parameters.AddWithValue("@prosStage", ChkProcs)
            Prod_Cmd.Parameters.AddWithValue("@SaveStage", Cond)
            'Prod_Cmd.Parameters.AddWithValue("@SaveStage1", Cond1)
            Prod_Cmd.Parameters.AddWithValue("@BomLocid", BomLocid)
            Prod_Cmd.Parameters.AddWithValue("@CurBomid", CurBomid)

            Prod_Cmd.ExecuteNonQuery()
            MsgBox("Current Record has been Saved", MsgBoxStyle.Information, "Record Saved!!!")
            Clr_Txtlblval()
            Me.DtpProddt.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
        End Try
    End Sub

    Private Sub CmbxPname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPname.GotFocus

        Try
            Me.CmbxPname.DroppedDown = True
            If Me.CmbxPname.Items.Count > 0 Then
                Fetch_Process_BalnaceQnty()
                If Me.CmbxPname.SelectedIndex = -1 Then
                    Me.CmbxPname.SelectedIndex = 0
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fetch_Process_BalnaceQnty()
        Dim Chkerr As Boolean = False
        Try

            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Prod_Cmd = New SqlCommand("Finact_ProcessPendingQnty_Select", FinActConn)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Dim intg As Integer = Me.cmbxBatchno.SelectedValue
            Dim intga As Integer = Me.CmbxPname.SelectedValue
            Prod_Cmd.Parameters.AddWithValue("@Matconid ", Me.cmbxBatchno.SelectedValue)
            Prod_Cmd.Parameters.AddWithValue("@MatProcsid ", Me.CmbxPname.SelectedValue)
            Prod_Rdr = Prod_Cmd.ExecuteReader
            While Prod_Rdr.Read
                If Prod_Rdr.IsDBNull(0) = False Then
                    Me.lblalprocsd.Text = FormatNumber(Prod_Rdr("outqnty"), 3)
                    Me.lblbalqnty.Text = FormatNumber(Prod_Rdr("balqnty")) '- (Prod_Rdr("reprocsqnty")), 3)
                    Me.lblreprocs.Text = FormatNumber(Prod_Rdr("reprocsqnty"), 3)
                    Me.lbluprocs.Text = FormatNumber(Prod_Rdr("uprocsqnty"), 3)
                    NxProdid = FormatNumber(Prod_Rdr("matmprocsno"), 3)
                    If FormatNumber(Prod_Rdr("balqnty"), 3) = FormatNumber(Prod_Rdr("uprocsqnty"), 3) Then
                        Me.txtundrprocs.Enabled = False
                    Else
                        Me.txtundrprocs.Enabled = True
                    End If
                End If
            End While

            Dim Rp As Double = Me.lblreprocs.Text
            Dim Rp1 As Double = Me.lblbalqnty.Text
            If Rp > 0 Then
                Me.Rbreprocs.Enabled = True
            Else
                Me.Rbreprocs.Enabled = False
            End If
            If Rp1 > 0 Then
                Me.Rbfirst.Enabled = True
                Me.Rbfirst.Checked = True
            Else
                Me.Rbfirst.Enabled = False
                Me.Rbreprocs.Checked = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Prod_Cmd.Dispose()
            Prod_Rdr.Close()
            Chkerr = True
        Finally
            If Chkerr = False Then
                Prod_Cmd.Dispose()
                Prod_Rdr.Close()
            End If
            Try
                Nxt_procesName()
            Catch ex As Exception

            End Try
        End Try
    End Sub

    Private Sub CmbxPname_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPname.SelectionChangeCommitted
        Try
            Fetch_Process_BalnaceQnty()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxNxtworker_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxNxtworker.SelectedIndexChanged

    End Sub

    Private Sub Rbfirst_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbfirst.CheckedChanged
        Try
            If Me.Rbfirst.Checked = True Then
                ChkProcs = 1 ' 1 mean normal process
                Dim qval1, qval2 As Double
                qval1 = Me.lbluprocs.Text
                qval2 = Me.lblbalqnty.Text
                If qval1 = qval2 Then
                    Me.txtundrprocs.Enabled = False
                    Me.txtsend.Enabled = True
                    Me.txtsend.Text = 0
                    Me.txtundrprocs.Text = 0
                Else
                    Me.txtundrprocs.Enabled = True
                    Me.txtsend.Enabled = True
                    Me.txtsend.Text = 0
                    Me.txtundrprocs.Text = 0
                End If
                
            Else
                ChkProcs = 0 ' 0 mean reprocess
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Rbreprocs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbreprocs.CheckedChanged
        Try
            If Me.Rbreprocs.Checked = True Then
                ChkProcs = 0 ' 0 mean reprocess
                Me.txtundrprocs.Enabled = False
                Me.txtsend.Enabled = False
                Me.txtsend.Text = 0
                Me.txtundrprocs.Text = 0
            Else
                ChkProcs = 1 ' 1 mean normal
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function Max_procesid() As Integer
        Try
            Prod_Cmd = New SqlCommand("Finact_Finact_ProcessMovementSqlMstr_Select_Max_Process", FinActConn)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Prod_Cmd.Parameters.AddWithValue("@bomiid", CurBomid)
            Prod_Rdr = Prod_Cmd.ExecuteReader
            While Prod_Rdr.Read ' = True
                If Prod_Rdr.IsDBNull(0) = False Then
                    MaxProcsid = (Prod_Rdr(1))
                    Return Trim(Prod_Rdr(1))

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
            Prod_Rdr.Close()

        End Try
    End Function

    Private Sub BOm_Location_name_id()
        Try
            Prod_Cmd = New SqlCommand("Finact_Production_Select_LocationName", FinActConn)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Prod_Cmd.Parameters.AddWithValue("@bom", CurBomid)
            Prod_Rdr = Prod_Cmd.ExecuteReader
            While Prod_Rdr.Read = True
                If Prod_Rdr.IsDBNull(0) = False Then
                    BomLocid = Trim(Prod_Rdr(0))
                    Me.LblNxtprocs.Text = Trim(Prod_Rdr(1))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
            Prod_Rdr.Close()

        End Try
    End Sub

    Private Sub cmbxworker1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxworker1.SelectedIndexChanged
        Me.CmbxNxtworker.DataSource = Nothing
        Me.lblNxtmach.Text = ""
    End Sub

    Private Sub DtpProddt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpProddt.ValueChanged

    End Sub

    Private Function SumOf_In_and_Outward_Items(ByVal SalItemId As Integer, ByVal PurItemId As Integer) As Double
        Try
            Prod_Cmd1 = New SqlCommand("Finact_Sum_In_out_pur_Particularitem", FinActConn2)
            Prod_Cmd1.CommandType = CommandType.StoredProcedure
            Prod_Cmd1.Parameters.AddWithValue("@PurItemid", PurItemId)
            'Prod_Cmd1.Parameters.AddWithValue("@PurItmlocid", PurItmLocId)
            Prod_Rdr1 = Prod_Cmd1.ExecuteReader
            While Prod_Rdr1.Read
                If Prod_Rdr1.IsDBNull(0) = False Then
                    Return Prod_Rdr1(0)
                Else
                    Return 0
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd1.Dispose()
            Prod_Rdr1.Close()
        End Try
    End Function

    ''Private Sub update_listview()
    ''    Try
    ''        'If Trim(LstVewItem.SelectedItems.Item(0).SubItems(8).Text) = "BomItem" Then
    ''        Prod_Cmd = New SqlCommand("Finact_BomMstrId_Select_Where_id", FinActConn)
    ''        Prod_Cmd.CommandType = CommandType.StoredProcedure
    ''        Prod_Cmd.Parameters.AddWithValue("@Bomconid", prod_ItemId)
    ''        Prod_Rdr = Prod_Cmd.ExecuteReader
    ''        Dim BomAmt As Double = 0
    ''        Dim Recloop As Integer = 0
    ''        While Prod_Rdr.Read = True
    ''            If Prod_Rdr.IsDBNull(0) = False Then
    ''                Try
    ''                    Dim BomMstrItmid As Integer = Prod_Rdr(0)
    ''                    Dim BomMstrQnty As Double = Prod_Rdr(1)
    ''                    Dim BomItmName As String = Trim(Prod_Rdr(2))
    ''                    Dim ProcsName As String = Trim(Prod_Rdr(3))
    ''                    Dim LocName As String = Trim(Prod_Rdr(4))
    ''                    Dim UnitName As String = Trim(Prod_Rdr(5))
    ''                    PurItmLocId = Trim(Prod_Rdr(6))
    ''                    RatioQnty = Prod_Rdr(7)

    ''                    ' If SumOf_In_and_Outward_Items(CurItemId, CurItemId) > 0 Then
    ''                    BomAmt = SumOf_In_and_Outward_Items(BomMstrItmid, BomMstrItmid)
    ''                    'End If
    ''                    Dim BomLstVew As New ListViewItem
    ''                    BomLstVew.BackColor = Color.Pink
    ''                    BomLstVew.ForeColor = Color.Black
    ''                    BomLstVew.Text = Trim(BomItmName) ' 0 Item Name
    ''                    BomLstVew.SubItems.Add(LocName) '1 Location
    ''                    BomLstVew.SubItems.Add(FormatNumber(BomMstrQnty, 3)) '2 per unit qnty.
    ''                    Dim Rqnty, Movqnty As Double
    ''                    Movqnty = Me.txtmovqnty.Text

    ''                    If Movqnty < RatioQnty Then
    ''                        If MessageBox.Show("You are going to produce less quantity, current item " & Chr(13) & BomItmName & " 's ratio is 1:" & RatioQnty & ". Aru you sure to move further?", "Check Ratio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
    ''                            xClr_xVal()
    ''                            Me.DtpMovedt.Focus()
    ''                            Exit Sub
    ''                        End If
    ''                    End If
    ''                    Movqnty = Me.txtmovqnty.Text \ RatioQnty
    ''                    Rqnty = Movqnty * BomMstrQnty
    ''                    BomLstVew.SubItems.Add(FormatNumber(Rqnty, 3)) '3 Required qnty.
    ''                    BomLstVew.SubItems.Add(FormatNumber(BomAmt, 3)) '4 Sotck in hand
    ''                    Dim ResQnty As Double = 0
    ''                    BomLstVew.SubItems.Add(FormatNumber(ResQnty, 3)) '5 Restricted qnty
    ''                    BomLstVew.SubItems.Add(FormatNumber((BomAmt - ResQnty), 3)) '6 avialable qnty
    ''                    BomLstVew.SubItems.Add(BomMstrItmid) '7 Item Id
    ''                    If Trim(ItmAry(0)) = Trim(ProcsName) Then
    ''                        BomLstVew.SubItems.Add("Issue") '8 current Status
    ''                        If (BomAmt - ResQnty) < Rqnty Then
    ''                            BomLstVew.BackColor = Color.Yellow
    ''                            BomLstVew.ForeColor = Color.Black
    ''                            MinPerUnit = BomMstrQnty
    ''                            If Recloop = 0 Then
    ''                                Minqnty = (BomAmt - ResQnty) / MinPerUnit
    ''                            End If

    ''                            If Minqnty > (BomAmt - ResQnty) / MinPerUnit Then
    ''                                Minqnty = (BomAmt - ResQnty) / MinPerUnit
    ''                            End If
    ''                            Recloop += 1
    ''                        Else
    ''                            BomLstVew.BackColor = Color.White
    ''                            BomLstVew.ForeColor = Color.Black
    ''                        End If
    ''                    Else
    ''                        BomLstVew.SubItems.Add("Not Yet") '8 current Status
    ''                        BomLstVew.BackColor = Color.Red
    ''                        BomLstVew.ForeColor = Color.White
    ''                    End If
    ''                    BomLstVew.SubItems.Add(UnitName) '9 Unit type
    ''                    BomLstVew.SubItems.Add(PurItmLocId) '10 Location id
    ''                    BomLstVew.Group = Me.Lstvewitmall.Groups(ProcsName)
    ''                    Me.Lstvewitmall.Items.Add(BomLstVew)
    ''                Catch ex As Exception
    ''                    MsgBox(ex.Message)
    ''                End Try
    ''                'End If

    ''        End While
    ''        If Minqnty > 0 Then
    ''            lblSuggest.Text = "Maximum Quantity Suggested By The System Is  " & Minqnty
    ''            Me.lblalrt.Text = Trim("Suggestion!")
    ''            Me.lblalrt.Visible = True
    ''            Me.lblSuggest.Visible = True
    ''        Else
    ''            Me.lblalrt.Visible = False
    ''            Me.lblSuggest.Visible = False
    ''        End If
    ''        End If
    ''    Catch ex As Exception
    ''        MsgBox(ex.Message)
    ''    Finally
    ''        If Trim(LstVewItem.SelectedItems.Item(0).SubItems(8).Text) = "BomItem" Then
    ''            Prod_Cmd.Dispose()
    ''            Prod_Rdr.Close()
    ''        End If
    ''    End Try
    ''    Me.Tplitem.Location = New System.Drawing.Point(800, 3)
    ''    Me.Tplitem.Visible = False
    ''    Me.Tplitem.Enabled = False
    ''    Me.CmbxWrkrName.Focus()
    ''    Me.CmbxWrkrName.SelectAll()
    ''        End If
    ''    Catch ex As Exception
    ''        MsgBox(ex.Message)
    ''    Finally
    ''        If prod_ItemId <> 0 Then
    ''            Nxt_procesName()
    ''        End If
    ''    End Try
    ''End Sub
    Private Function SelMax_record() As Integer

        Try

            Prod_Cmd = New SqlCommand("Finact_ChekNxtProcs_MaterialMov_Select_MaxRec", FinActConn)
            Prod_Cmd.CommandType = CommandType.StoredProcedure
            Prod_Cmd.Parameters.AddWithValue("@NxtProcsNoa", NxProdid)
            Prod_Cmd.Parameters.AddWithValue("@Movmstrida", Me.cmbxBatchno.SelectedValue)
            Prod_Rdr = Prod_Cmd.ExecuteReader
            While Prod_Rdr.Read
                If Prod_Rdr.IsDBNull(0) = False Then
                    Return Prod_Rdr(0)
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Prod_Cmd.Dispose()
            Prod_Rdr.Close()
        End Try
    End Function

    Private Sub cmbxBatchno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxBatchno.SelectedIndexChanged

    End Sub

    Private Sub CmbxPname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxPname.SelectedIndexChanged

    End Sub

    Private Sub CmbxWorker_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWorker.GotFocus
        Try
            Me.CmbxWorker.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Allcontrols_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxBatchno.KeyDown, CmbxNxtworker.KeyDown, CmbxPname.KeyDown _
    , CmbxScrap.KeyDown, CmbxWorker.KeyDown, cmbxworker1.KeyDown, cmbxwtqntyloss.KeyDown, DtpProddt.KeyDown, Rbfirst.KeyDown, Rbreprocs.KeyDown, txtlossrate.KeyDown, TxtProcdqnty.KeyDown _
    , txtreason.KeyDown, txtsend.KeyDown, txtundrprocs.KeyDown, txtwasterate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxPname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPname.Leave
        Try
            Me.CmbxPname.DroppedDown = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxScrap_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxScrap.Leave
        Try
            Me.CmbxScrap.DroppedDown = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxWorker_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxWorker.Leave
        Try
            Me.CmbxWorker.DroppedDown = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxwtqntyloss_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxwtqntyloss.Leave
        Try
            Me.cmbxwtqntyloss.DroppedDown = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExtAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExt.GotFocus, BtnCancl.GotFocus, BtnOk.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCanclAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancl.Leave, BtnExt.Leave, BtnOk.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports
Public Class FrmCrRptDrNote
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim rdr As SqlDataReader
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CrRptrcpt As New CrRptDrNote

    Private Sub FrmRptCashBook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            cmd = New SqlCommand("Delete from FinAct_TEMP_RecptVochr", FinActConn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            ''FrmMainMdi.MenuItem200.Enabled = True
        End Try
    End Sub

    Private Sub FrmRptCashBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 10
            If Cl_TimeIndia = True Then
                Me.ChkRptcbook.Checked = False
            Else
                Me.ChkRptcbook.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpCb1, Me.DtpCb2)
            If xDrCrNoteFlag = True Then
                Me.DtpCb1.Value = xDrCrNoteDt
                Me.DtpCb2.Value = xDrCrNoteDt
                Me.RbVno.Checked = True
                Me.Txtvno1.Text = CInt(xDrCrNo)
                Me.Txtvno2.Text = CInt(xDrCrNo)
            End If
            FillTempTable_Cbook()
            Fill_Combobox_with_Sp(Me.CmbxAct)
            Me.ChkRptcbook.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillTempTable_Cbook()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Finact_Rpt_CrDrNote_FillTalbe", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Sel_Dt1", Me.DtpCb1.Value.Date)
            cmd.Parameters.AddWithValue("@Sel_Dt2", Me.DtpCb2.Value.Date)
            cmd.Parameters.AddWithValue("@xIndx", 1)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- FillTempTable_Cbook, Line No. 31 ")
        Finally
            cmd.Dispose()

        End Try
    End Sub

    Private Sub BtnRptVewCb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewCb.Click

        Try
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_cb()
            Handle_P_Bar(Me)
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 20
            Me.Height = Screen.PrimaryScreen.WorkingArea.Height - 20
            Me.Top = 0
            Me.Left = 10
        Catch ex As Exception

        End Try

    End Sub
    Private Sub SelRecd_Fromtable_cb()
        Try
            If Me.Rbact.Checked = True Then
                Dim Actid As Integer = Me.CmbxAct.SelectedValue
                xFetch_RptRecord_Dt_Vno_Actt_Range("Finact_Rpt_RecptVochr_Select_Acct", Me.CrRptrcpt, Me.CrRptVewRecpt, Me.DtpCb1.Value.Date, DtpCb2.Value.Date, 1, CStr(Actid), 0, 0)
            ElseIf Me.Rball.Checked = True Then
                xFetch_RptRecord_Dt_Vno_Actt_Range("Finact_Rpt_RecptVochr_Select", Me.CrRptrcpt, Me.CrRptVewRecpt, Me.DtpCb1.Value.Date, Me.DtpCb2.Value.Date, 0, 0, 0, 0)
            ElseIf Me.RbVno.Checked = True Then
                xFetch_RptRecord_Dt_Vno_Actt_Range("Finact_Rpt_RecptVochr_Select_Vno", Me.CrRptrcpt, Me.CrRptVewRecpt, Me.DtpCb1.Value.Date, DtpCb2.Value.Date, 2, 0, Trim(Me.Txtvno1.Text), Trim(Me.Txtvno2.Text))
            End If
            SetExtraPramtoCrRpt()
            If Me.ChkRptcbook.Checked = True Then
                CoprofileParamsRest_Adrs(Me.CrRptrcpt, Me.CrRptVewRecpt, True, True, Me.DtpCb1, Me.DtpCb2)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptrcpt, Me.CrRptVewRecpt, True, False, Me.DtpCb1, Me.DtpCb2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_cb, Line No.211 ")
        End Try
    End Sub

    Private Sub ChkRptcbook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptcbook.CheckedChanged
        Try
            Me.BtnRptVewCb_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fill_Combobox_with_Sp(ByVal Xcombobx As ComboBox)
        Dim xStr As String = "Finact_Rpt_Fillcmbx_SelectAct"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            cmd = New SqlCommand(xStr, FinActConn1)
            cmd.CommandType = CommandType.StoredProcedure

            SqlAdptr = New SqlDataAdapter(cmd)
            dtaset = New DataSet(cmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = "Splrid"
            Xcombobx.DisplayMember = "Splrname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub

    Private Sub Rball_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rball.CheckedChanged, Rbact.CheckedChanged, RbVno.CheckedChanged
        Try
            If Me.Rball.Checked = True Then
                Me.CmbxAct.Enabled = False
                Me.Txtvno1.Enabled = False
                Me.Txtvno2.Enabled = False
                Me.BtnRptVewCb.Focus()
            ElseIf Me.Rbact.Checked = True Then
                Me.CmbxAct.Enabled = True
                Me.Txtvno1.Enabled = False
                Me.Txtvno2.Enabled = False
                Me.CmbxAct.Focus()
                Me.CmbxAct.SelectAll()
            ElseIf Me.RbVno.Checked = True Then
                Me.CmbxAct.Enabled = False
                Me.Txtvno1.Enabled = True
                Me.Txtvno2.Enabled = True
                Me.Txtvno1.Focus()
                Me.Txtvno1.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpCb1.KeyDown, ChkRptcbook.KeyDown _
    , CmbxAct.KeyDown, DtpCb2.KeyDown, Rbact.KeyDown, Rball.KeyDown, RbVno.KeyDown, Txtvno1.KeyDown, Txtvno2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub SetExtraPramtoCrRpt()
        Try
            Dim ParmVal1 As ParameterValues = New ParameterValues()
            Dim DisVal1 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal1.Value = 1
            ParmVal1.Add(DisVal1)



            ParmVal1.AddValue(RupeesToWord(xDrCrNoteAmt))
            Me.CrRptrcpt.DataDefinition.ParameterFields("InWords").ApplyCurrentValues(ParmVal1)
            CrRptVewRecpt.ReportSource = CrRptrcpt


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally


        End Try
    End Sub
End Class
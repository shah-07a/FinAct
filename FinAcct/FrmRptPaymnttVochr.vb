Imports System.Data.SqlClient
Public Class FrmRptPaymnttVochr
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim rdr As SqlDataReader
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CrRptPay As New CrRptPayment

    Private Sub FrmRptCashBook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            cmd = New SqlCommand("Delete from FinAct_TEMP_paymntVochr", FinActConn)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            ''FrmMainMdi.MenuItem201.Enabled = True
        End Try
    End Sub

    Private Sub FrmRptCashBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 50, 139)
            Me.Top = 0
            Me.Left = 0
            If Cl_TimeIndia = True Then
                Me.ChkRptcbook.Checked = False
            Else
                Me.ChkRptcbook.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpCb1, Me.DtpCb2)
            FillTempTable_Cbook()
            Fill_Combobox_with_Sp(Me.CmbxAct)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillTempTable_Cbook()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Finact_Rpt_PaymntVochr_FillTalbe", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Sel_Dt1", Me.DtpCb1.Value.Date)
            cmd.Parameters.AddWithValue("@Sel_Dt2", Me.DtpCb2.Value.Date)
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
            ''FrmMainMdi.MenuItem201.Enabled = False
            Handle_P_Bar(Me)
          Me.Size=New Point(Screen.PrimaryScreen.WorkingArea.Width-50,Screen.PrimaryScreen.WorkingArea.Height-80)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try

    End Sub
    Private Sub SelRecd_Fromtable_cb()
        Try
            If Me.Rbact.Checked = True Then
                Dim Actid As Integer = Me.CmbxAct.SelectedValue
                Fetch_Stock_Record_SelectedDateRange_withSelITem("Finact_Rpt_PaymntVochr_Select_Acct", Me.CrRptPay, Me.CrRptVewPay, Me.DtpCb1.Value.Date, DtpCb2.Value.Date, CStr(Actid))
            ElseIf Me.Rball.Checked = True Then
                Fetch_Stock_Record_SelectedDateRange("Finact_Rpt_PaymntVochr_Select", Me.CrRptPay, Me.CrRptVewPay, Me.DtpCb1.Value.Date, Me.DtpCb2.Value.Date)
            ElseIf Me.RbVno.Checked = True Then
                Fetch_Stock_Record_SelectedDateRange_withVnoRange("Finact_Rpt_PaymntVochr_Select_Vno", Me.CrRptPay, Me.CrRptVewPay, Me.DtpCb1.Value.Date, DtpCb2.Value.Date, Trim(Me.Txtvno1.Text), Trim(Me.Txtvno2.Text))
            End If

            If Me.ChkRptcbook.Checked = True Then
                CoprofileParamsRest_Adrs(Me.CrRptPay, Me.CrRptVewPay, True, True, Me.DtpCb1, Me.DtpCb2)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptPay, Me.CrRptVewPay, True, False, Me.DtpCb1, Me.DtpCb2)
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
    Private Sub Fill_Combobox_with_Sp(ByVal Xcombobx As ComboBox)
        Dim xStr As String = "Finact_Rpt_Fillcmbx_SelectAct_1"
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
End Class
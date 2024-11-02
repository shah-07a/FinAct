Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmCrRptBalConfrm
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd1 As SqlCommand
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CrRptLdgr As New CrRptBalConfrm

    Private Sub FrmRptGenLdgr_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cmd = New SqlCommand("Delete from FINACT_TEMP_gl", FinActConn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            ''FrmMainMdi.MenuItem198.Enabled = True
        End Try
    End Sub

    Private Sub FrmRptGenLdgr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, 129)
            If Cl_TimeIndia = True Then
                Me.ChkRptLdgr.Checked = False
            Else
                Me.ChkRptLdgr.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpLdgr1, Me.DtpLdgr2)
            Fill_Combobox_where_Not_In_cond("splrid", "Splrname", "Splrtype", "Finactsplrmstr", "Bank", "Cash BooK", Me.CmbxLdgr, "SPLRDELSTATUS", CInt(1))
            FillTempTable_Ldgr()
            Me.DtpLdgr1.Focus()
        Catch ex As Exception

        End Try


    End Sub
    Private Sub FillTempTable_Ldgr()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Finact_Rpt_Ledger_FillTalbe", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@F_Dt", Me.DtpLdgr1.Value.Date)
            cmd.Parameters.AddWithValue("@T_Dt", Me.DtpLdgr2.Value.Date)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- FillTempTable_Ldgr, Line No. 38 ")
        Finally
            cmd.Dispose()

        End Try

    End Sub

    Private Sub ChkLdgrAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLdgrAll.CheckedChanged
        Try
            If Me.ChkLdgrAll.Checked = True Then
                Me.CmbxLdgr.Enabled = False
            Else
                Me.CmbxLdgr.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRptVewLdgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click
        Try
            If Me.CmbxLdgr.SelectedIndex = -1 Then Exit Sub

            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_Ldgr()
            ''FrmMainMdi.MenuItem198.Enabled = False
            Handle_P_Bar(Me)
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, Screen.PrimaryScreen.WorkingArea.Height - 50)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_Ldgr()
        Try
            Dim Stype, Sbtype As Integer
            If Me.ChkLdgrAll.Checked = True Then
                Stype = 1

            Else
                Stype = 2

            End If
            If Me.Rbdr.Checked = True Then
                Sbtype = 1
            ElseIf Me.RbCr.Checked = True Then
                Sbtype = 2
            Else
                Sbtype = 3
            End If
            Dim Selact As String = Trim(Me.CmbxLdgr.Text)
            Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType("Finact_Rpt_Ledger_Select", Me.CrRptLdgr, Me.CrRptVewLdgr, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact, Stype, Sbtype)
            SetExtraPramtoCrRpt()
            If Me.ChkRptLdgr.Checked = True Then
                CoprofileParamsRest_Adrs(Me.CrRptLdgr, Me.CrRptVewLdgr, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptLdgr, Me.CrRptVewLdgr, True, False, Me.DtpLdgr1, Me.DtpLdgr2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_Ldgr, Line No. 234 ")
        End Try
    End Sub

    Private Sub ChkRptLdgr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptLdgr.CheckedChanged
        Try
            Me.BtnRptVewLdgr_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpLdgr1.KeyDown, ChkLdgrAll.KeyDown _
    , ChkRptLdgr.KeyDown, DtpLdgr2.KeyDown, RbBoth.KeyDown, RbCr.KeyDown, Rbdr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxLdgr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxLdgr.GotFocus
        Try
            Me.CmbxLdgr.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxLdgr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxLdgr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxLdgr_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxLdgr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxLdgr.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxLdgr) = True Then
                Me.BtnRptVewLdgr.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnRptVewLdgr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.GotFocus
        Try
            Me.BtnRptVewLdgr.BackColor = Color.Blue

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRptVewLdgr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Leave
        Try
            Me.BtnRptVewLdgr.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetExtraPramtoCrRpt()
        Try
            Dim ParmVal1 As ParameterValues = New ParameterValues()
            Dim DisVal1 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal1.Value = 1
            Dim ParmVal2 As ParameterValues = New ParameterValues()
            Dim DisVaL2 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVaL2.Value = 1
            Dim ParmVal3 As ParameterValues = New ParameterValues()
            Dim DisVal3 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal3.Value = 1
            ParmVal1.Add(DisVal1)
            ParmVal1.Add(DisVaL2)
            ParmVal1.Add(DisVal3)
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("FINACT_Rpt_PARTYADRS_Select", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Pid", CInt(Me.CmbxLdgr.SelectedValue))
            rdr = cmd.ExecuteReader
            While rdr.Read
                ParmVal1.AddValue(rdr("ADRS"))
                ParmVal2.AddValue(rdr("CTY"))
                ParmVal3.AddValue(rdr("PAN"))
            End While

            Me.CrRptLdgr.DataDefinition.ParameterFields("PRMADRS1").ApplyCurrentValues(ParmVal1)
            Me.CrRptLdgr.DataDefinition.ParameterFields("PRMADRS2").ApplyCurrentValues(ParmVal2)
            Me.CrRptLdgr.DataDefinition.ParameterFields("PRMPAN").ApplyCurrentValues(ParmVal3)
            CrRptVewLdgr.ReportSource = CrRptLdgr
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            rdr.Close()
        End Try
    End Sub
End Class
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmCrRptTdsChkList
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd1 As SqlCommand
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CrRptLdgr As Object

    Private Sub FrmRptGenLdgr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            If Cl_TimeIndia = True Then
                Me.ChkRptLdgr.Checked = False
            Else
                Me.ChkRptLdgr.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpLdgr1, Me.DtpLdgr2)

            Me.DtpLdgr1.Focus()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub ChkLdgrAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLdgrAll.CheckedChanged
        Try
            If Me.ChkLdgrAll.Checked = True Then
                Me.CmbxLdgr.Enabled = False
                Me.CmbxLdgr.SelectedIndex = -1
            Else
                Fill_Combobox_DistinctSplrid_HAVINGtds(Me.CmbxLdgr)
                Me.CmbxLdgr.SelectedIndex = 0
                Me.CmbxLdgr.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRptVewLdgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click
        Try
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_Ldgr()
            Handle_P_Bar(Me)
       Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, Screen.PrimaryScreen.WorkingArea.Height - 50)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_Ldgr()
        Try
            Dim Selact As Integer = 0
            If Me.ChkLdgrAll.Checked = False Then
                Selact = CInt(Me.CmbxLdgr.SelectedValue)
            End If

            CrRptLdgr = New CrRptTDSCheckList
            Fetch_Stock_Record_SelectedDateRange_withSelITem("FinAct_PurEntry_TDS_Select", Me.CrRptLdgr, Me.CrRptVewLdgr, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, Selact)

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
    , ChkRptLdgr.KeyDown, DtpLdgr2.KeyDown
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
    Private Sub Fill_Combobox_DistinctSplrid_HAVINGtds(ByVal Xcombobx As ComboBox)
        Dim xStr As String = "FinAct_PurEntry_SPLRLIST_HAVING_TDS_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            FinActCmd = New SqlCommand(xStr, FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@SDT", Me.DtpLdgr1.Value.Date)
            FinActCmd.Parameters.AddWithValue("@TDT", Me.DtpLdgr2.Value.Date)
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
   
    Private Sub DtpLdgr2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpLdgr2.ValueChanged

    End Sub
End Class
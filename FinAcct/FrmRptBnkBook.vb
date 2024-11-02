Imports System.Data.SqlClient
Public Class FrmRptBnkBook
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim rdr As SqlDataReader
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CrRptbb As New CrRptBnkBook

    Private Sub FrmRptBnkBook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cmd = New SqlCommand("Delete from FINACT_TEMP_bbook", FinActConn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            ''FrmMainMdi.MenuItem75.Enabled = True

        End Try
    End Sub

    Private Sub FrmRptBnkBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 50, 100)
            Me.Top = 0
            Me.Left = 0
            If Cl_TimeIndia = True Then
                Me.ChkRptbb.Checked = False
            Else
                Me.ChkRptbb.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.Dtpbb1, Me.Dtpbb2)
            Select_2rec_where("splrid", "Splrname", "Splrtype", "Finactsplrmstr", Me.Cmbxbb, "Bank", "SPLRDELSTATUS", CInt(1))
            FillTempTable_BB()
            Me.ChkRptbb.Focus()

        Catch ex As Exception

        End Try



    End Sub
    Private Sub FillTempTable_BB()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Finact_Rpt_BankBook_FillTalbe", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Sel_Dt1", Me.Dtpbb1.Value.Date)
            cmd.Parameters.AddWithValue("@Sel_Dt2", Me.Dtpbb2.Value.Date)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- FillTempTable_BB, Line No. 38 ")
        Finally
            cmd.Dispose()

        End Try

    End Sub

    Private Sub ChkbbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbbAll.CheckedChanged
        Try
            If Me.ChkbbAll.Checked = True Then
                Me.Cmbxbb.Enabled = False
            Else
                Me.Cmbxbb.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRptVewbb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRptVewbb.Click
        Try
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_BB()
            Handle_P_Bar(Me)
           Me.Size=New Point(Screen.PrimaryScreen.WorkingArea.Width-50,Screen.PrimaryScreen.WorkingArea.Height-80)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkRptbb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptbb.CheckedChanged
        Try
            Me.BtnRptVewbb_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_BB()
        Try
            If Me.ChkbbAll.Checked = True Then
                Fetch_Stock_Record_SelectedDateRange("Finact_Rpt_BankBook_Select", Me.CrRptbb, Me.CrRptVewBB, Me.Dtpbb1.Value.Date, Me.Dtpbb2.Value.Date)
            Else
                Fetch_Stock_Record_SelectedDateRange_withSelITem("Finact_Rpt_BankBook_SelectedBank_Select", Me.CrRptbb, Me.CrRptVewBB, Me.Dtpbb1.Value.Date, Me.Dtpbb2.Value.Date, Trim(Me.Cmbxbb.Text))
            End If

            If Me.ChkRptbb.Checked = True Then
                CoprofileParamsRest_Adrs(Me.CrRptbb, Me.CrRptVewBB, True, True, Me.Dtpbb1, Me.Dtpbb2)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptbb, Me.CrRptVewBB, True, False, Me.Dtpbb1, Me.Dtpbb2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_BB, Line No. 236 ")
        End Try


    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpbb2.KeyDown, ChkbbAll.KeyDown _
    , ChkRptbb.KeyDown, Dtpbb1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxbb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxbb.GotFocus
        Try
            Me.Cmbxbb.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxbb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxbb.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Cmbxbb_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxbb_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxbb.Leave
        Try
            If CheckBlank_Cmbx(Me.Cmbxbb) = True Then
                Me.BtnRptVewbb.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    
End Class
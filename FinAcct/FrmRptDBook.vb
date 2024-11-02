Imports System.Data.SqlClient

Public Class FrmRptDBook
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim rdr As SqlDataReader
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim CrRptdBook As New CrRptDayBook
    Dim CrRptdBookWithdate As New CrRptDbookWithAddDt


    Private Sub FrmRptDBook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Delete from FINACT_TEMP_dbook", FinActConn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            ''FrmMainMdi.MenuItem77.Enabled = True

        End Try

    End Sub

    Private Sub FrmRptDBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 50, 92)
            Me.Top = 0
            Me.Left = 0
            If Cl_TimeIndia = True Then
                Me.ChkRptDbook.Checked = False
            Else
                Me.ChkRptDbook.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpDb1, Me.Dtp2)
            Dim x As Integer = 0
            ' For x = 0 To 10
            Me.Cursor = Cursors.WaitCursor
            FillTempTable_Dbook()
            ' Next
            Me.Cursor = Cursors.Default
            Me.ChkRptDbook.Focus()
        Catch ex As Exception

        End Try


    End Sub
    Private Sub FillTempTable_Dbook()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            If Me.ChkbxRptFormat.Checked = True Then
                cmd = New SqlCommand("Finact_Rpt_DayBookWithAddDate_FillTalbe", FinActConn)
                cmd.Parameters.AddWithValue("@F_dt", Me.DtpDb1.Value)
                cmd.Parameters.AddWithValue("@T_dt", Me.Dtp2.Value)
            Else
                cmd = New SqlCommand("Finact_Rpt_DayBook_FillTalbe", FinActConn)
                cmd.Parameters.AddWithValue("@F_dt", Me.DtpDb1.Value.Date)
                cmd.Parameters.AddWithValue("@T_dt", Me.Dtp2.Value.Date)
            End If

            cmd.CommandType = CommandType.StoredProcedure

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- FillTempTable_Dbook, Line No. 44 ")
        Finally
            cmd.Dispose()
        End Try

    End Sub
    Private Sub SelRecd_Fromtable()
        Try
            Fetch_Stock_Record_SelectedDateRange("Finact_Rpt_DayBook_Select", Me.CrRptdBook, Me.CrRptVewDbook, Me.DtpDb1.Value.Date, Me.Dtp2.Value.Date)
            If Me.ChkRptDbook.Checked = True Then
                CoprofileParamsRest_Adrs(Me.CrRptdBook, Me.CrRptVewDbook, True, True, Me.DtpDb1, Me.Dtp2)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptdBook, Me.CrRptVewDbook, True, False, Me.DtpDb1, Me.Dtp2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable, Line No. 54 ")
        End Try
    End Sub

    Private Sub aLLCONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpDb1.KeyDown, ChkRptDbook.KeyDown, Dtp2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DtpDb1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpDb1.ValueChanged
        Try
            Date.TryParse(Me.DtpDb1.Value.Date, CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
            Me.Dtp2.MinDate = (CurrDate.Date)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRptVew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRptVew.Click
        Try
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable()
            ''FrmMainMdi.MenuItem77.Enabled = False
            Handle_P_Bar(Me)
       Me.Size=New Point(Screen.PrimaryScreen.WorkingArea.Width-50,Screen.PrimaryScreen.WorkingArea.Height-80)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ChkRptDbook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptDbook.CheckedChanged
        Try
            Me.BtnRptVew_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChkbxRptFormat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbxRptFormat.CheckedChanged
        Try

            FillTempTable_Dbook()
        Catch ex As Exception

        End Try
    End Sub
End Class
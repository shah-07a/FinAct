Imports System.Data.SqlClient
Public Class FrmRptJrnl
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim rdr As SqlDataReader
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim tDset As DataSet
    Dim tSqlAdptr As SqlDataAdapter
    Dim CrRptJurnl As New CrRptJrnl

    Private Sub FrmRptJrnl_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cmd = New SqlCommand("Delete from FINACT_TEMP_Jrnlbook", FinActConn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            ''FrmMainMdi.MenuItem76.Enabled = True

        End Try
    End Sub

    Private Sub FrmRptJrnl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 50, 88)
            Me.Top = 0
            Me.Left = 0
            If Cl_TimeIndia = True Then
                Me.ChkRptJrnl.Checked = False
            Else
                Me.ChkRptJrnl.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpJrnl1, Me.DtpJrnl2)
            FillTempTable_Jrnl()
            Me.ChkRptJrnl.Focus()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub FillTempTable_Jrnl()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Finact_Rpt_Journal_FillTalbe", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Sel_Dt1", Me.DtpJrnl1.Value.Date)
            cmd.Parameters.AddWithValue("@Sel_Dt2", Me.DtpJrnl2.Value.Date)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- FillTempTable_Jrnl, Line No. 29 ")
        Finally
            cmd.Dispose()

        End Try
    End Sub


    Private Sub ChkRptJrnl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptJrnl.CheckedChanged
        Try
            Me.BtnRptVewJrnl_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRptVewJrnl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewJrnl.Click
        Try
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_Jrnl()
            ''FrmMainMdi.MenuItem76.Enabled = False
            Handle_P_Bar(Me)
         Me.Size=New Point(Screen.PrimaryScreen.WorkingArea.Width-50,Screen.PrimaryScreen.WorkingArea.Height-80)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_Jrnl()
        Try
            Fetch_Stock_Record_SelectedDateRange("Finact_Rpt_Journal_Select", Me.CrRptJurnl, Me.CrRptVewJrnl, Me.DtpJrnl1.Value.Date, Me.DtpJrnl2.Value.Date)
            If Me.ChkRptJrnl.Checked = True Then
                CoprofileParamsRest_Adrs(Me.CrRptJurnl, Me.CrRptVewJrnl, True, True, Me.DtpJrnl1, Me.DtpJrnl2)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptJurnl, Me.CrRptVewJrnl, True, False, Me.DtpJrnl1, Me.DtpJrnl2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_Jrnl, Line No. 142 ")
        End Try
    End Sub
   
    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpJrnl1.KeyDown, ChkRptJrnl.KeyDown _
    , DtpJrnl2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
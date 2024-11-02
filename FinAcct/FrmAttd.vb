Imports System.Data
Imports System.Data.SqlClient

Public Class FrmAttd
    Dim Attd_Sift_Cmd As SqlCommand
    Dim Attd_Sift_Rdr As SqlDataReader
    Dim cmpny_strtdt As Date
    Dim cnt_recrds As Integer
    Dim BrkInTm As Date
    Dim BrkOutTm As Date
    Dim OutTm As Date



    Private Sub FrmAttd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        DtpkrDte.Text = Today
        fetch_Strtdt()
        DtpkrDte.MinDate = cmpny_strtdt
        fetch_ComboShift()
        RbInTime.Checked = True
        DtpkrDte.Focus()

    End Sub


    Private Sub fetch_ComboShift()
        Cmbxsft.Items.Clear()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select EmpSift from FinactEmpTimeMstr where Empdelstatus=0", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            While Attd_Sift_Rdr.Read
                If Attd_Sift_Rdr.HasRows = True Then
                    Cmbxsft.Items.Add(Attd_Sift_Rdr(0))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
        If Cmbxsft.Items.Count > 0 Then
            Cmbxsft.SelectedIndex = 0
        End If
    End Sub


    Private Sub fetch_Strtdt()
        Try
            Attd_Sift_Cmd = New SqlCommand("Select costrtdt from Finactcogatemstr  ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            While Attd_Sift_Rdr.Read
                If Attd_Sift_Rdr.HasRows = True Then
                    cmpny_strtdt = Attd_Sift_Rdr(0)
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Chek_Recrd()
        If cnt_recrds = 0 And Attd_Type = 1 Or cnt_recrds = 0 And Attd_Type = 5 Then

            Attd_Date = DtpkrDte.Value.Date
            Attd_Shift = Cmbxsft.Text
            ' Me.Close()
            FrmAttend.ShowDialog()
        ElseIf cnt_recrds = 0 And Attd_Type = 2 Or cnt_recrds = 0 And Attd_Type = 3 Or cnt_recrds = 0 And Attd_Type = 4 Then
            MsgBox("First mark the InTime Attendance for the selected shift.", MsgBoxStyle.Information, "InTime")
            Exit Sub
        ElseIf cnt_recrds > 0 Then
            Attd_Date = DtpkrDte.Value.Date
            Attd_Shift = Cmbxsft.Text
            ' Me.Close()
            FrmAttend.ShowDialog()
        End If
    End Sub

    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        FrmAttend.Close()
        Me.Close()
    End Sub

    Private Sub RbInTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbInTime.CheckedChanged
        If RbInTime.Checked = True Then
            Attd_Type = 1
        End If
    End Sub

    Private Sub RbBrkOutTm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbBrkOutTm.CheckedChanged
        If RbBrkOutTm.Checked = True Then
            Attd_Type = 2
        End If
    End Sub

    Private Sub RbBrkInTm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbBrkInTm.CheckedChanged
        If RbBrkInTm.Checked = True Then
            Attd_Type = 3
        End If
    End Sub

    Private Sub RbOutTm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbOutTm.CheckedChanged
        If RbOutTm.Checked = True Then
            Attd_Type = 4
        End If
    End Sub

    Private Sub RbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAll.CheckedChanged
        If RbAll.Checked = True Then
            Attd_Type = 5
        End If
    End Sub

    Private Sub DtpkrDte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDte.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Cmbxsft.Focus()

        End If
    End Sub



    Private Sub Cmbxsft_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxsft.GotFocus
        If Cmbxsft.Items.Count > 0 Then
            If Cmbxsft.Text = "" Then
                Cmbxsft.SelectedIndex = 0
            End If
            Cmbxsft.DroppedDown = True
        End If
    End Sub

    Private Sub Cmbxsft_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxsft.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            RbInTime.Focus()

        End If
    End Sub


    Private Sub RbInTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbInTime.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            RbBrkOutTm.Focus()

        End If
    End Sub

    Private Sub Chek_Recrd()

        Try
            Attd_Sift_Cmd = New SqlCommand("Select AttdId ,AttdBrkInTime,AttdBrkOutTime,AttdOutTime from Finact_Attd where Attddt='" & (DtpkrDte.Value.Date) & "' and AttdSft='" & (Cmbxsft.Text) & "'  ", FinActConn)
            Attd_Sift_Rdr = Attd_Sift_Cmd.ExecuteReader
            Attd_Sift_Rdr.Read()
            If Attd_Sift_Rdr.HasRows = True Then
                cnt_recrds = Attd_Sift_Rdr(0)
                BrkInTm = Attd_Sift_Rdr(1)
                BrkOutTm = Attd_Sift_Rdr(2)
                OutTm = Attd_Sift_Rdr(3)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Sift_Rdr.Close()
            Attd_Sift_Cmd = Nothing
        End Try


    End Sub
End Class
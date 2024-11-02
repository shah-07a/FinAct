Imports System.Data
Imports System.Data.SqlClient

Public Class FrmAttendOut

    Dim Attd_Out_Cmd As SqlCommand
    Dim Attd_Out_rdr As SqlDataReader
    Dim StrtDt As Date
    Dim StrtTm As Date
    Dim EndTm As Date
    Dim Brkfrm As Date
    Dim cnfrm_msg As String
    Dim OutTime_Recrds As Integer = 0
    Dim a As Integer = 0


    Private Sub FrmAttendOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        DtpkrDt.Focus()
        DtpkrDt.MinDate = StrtDt
        LblShift.Visible = False
        fetch_Shift()

    End Sub

    Private Sub fetch_Strtdt()
        Try
            Attd_Out_Cmd = New SqlCommand("Select costrtdt from Finactcogatemstr  ", FinActConn)
            Attd_Out_rdr = Attd_Out_Cmd.ExecuteReader
            While Attd_Out_rdr.Read
                If Attd_Out_rdr.HasRows = True Then
                    StrtDt = Attd_Out_rdr(0)
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Out_rdr.Close()
            Attd_Out_Cmd = Nothing
        End Try
    End Sub

    Private Sub fetch_Shift()
        CmbxShift.Items.Clear()
        Try
            Attd_Out_Cmd = New SqlCommand("Select EmpSift from FinactEmpTimeMstr where Empdelstatus=0 ", FinActConn)
            Attd_Out_rdr = Attd_Out_Cmd.ExecuteReader
            While Attd_Out_rdr.Read
                If Attd_Out_rdr.HasRows = True Then
                    CmbxShift.Items.Add(Attd_Out_rdr(0))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Out_rdr.Close()
            Attd_Out_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Shift_Recrd()
        Try
            Attd_Out_Cmd = New SqlCommand("Select Empstdtime,Empendtime,Empbrkfrom,Empbrkto from FinactEmpTimeMstr where EmpSift='" & (CmbxShift.Text) & "' ", FinActConn)
            Attd_Out_rdr = Attd_Out_Cmd.ExecuteReader
            If Trim(CmbxShift.Text) <> "" Then
                Attd_Out_rdr.Read()
                If Attd_Out_rdr.HasRows = True Then
                    StrtTm = Attd_Out_rdr(0)
                    LblStrtTm.Text = Format(StrtTm, "HH:mm:ss")
                    EndTm = Attd_Out_rdr(1)
                    LblEndTm.Text = Format(EndTm, "HH:mm:ss")
                    BrkFrm = Format(Attd_Out_rdr(2), "HH:mm:ss")
                    'LblBrkFrm.Text = Format(BrkFrm, "HH:mm:ss")
                    'BrkTo = Attd_Out_rdr(3)
                    'LblBrkTo.Text = Format(BrkTo, "HH:mm:ss")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Out_rdr.Close()
            Attd_Out_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Attd_OutTime()
        OutTime_Recrds = 0
        Try
            Attd_Out_Cmd = New SqlCommand("Select AttdOutTime from Finact_Attd where AttdSft='" & (CmbxShift.Text) & "'and Attddt='" & (DtpkrDt.Value.Date) & "' ", FinActConn)
            Attd_Out_rdr = Attd_Out_Cmd.ExecuteReader
            If Trim(CmbxShift.Text) <> "" Then
                While Attd_Out_rdr.Read()
                    If Attd_Out_rdr.IsDBNull(0) = False Then
                        OutTime_Recrds += 1

                    End If
                End While
                Me.DatagrdOutTime.AllowUserToAddRows = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'If Attd_Out_rdr.IsDBNull(0) = True Then
            '    OutTime_Recrds = 0

            'End If
            Attd_Out_rdr.Close()
            Attd_Out_Cmd = Nothing
        End Try
    End Sub


    Private Sub Chek_Attd_Intime_Recrd()

        Dim RepStatus As String
        DatagrdOutTime.Visible = True
        DatagrdOutTime.Rows.Clear()
        Me.DatagrdOutTime.AllowUserToAddRows = True
        a = 0
        Try
            Attd_Out_Cmd = New SqlCommand("Select AttdEmpid,FinactEmpmstr.empname,AttdStatus,AttdRepStatus from Finact_Attd inner join  Finactempmstr on Finact_Attd.AttdEmpid=FinactEmpmstr.empid where AttdSft='" & (CmbxShift.Text) & "'and Attddt='" & (DtpkrDt.Value.Date) & "' ", FinActConn)
            Attd_Out_rdr = Attd_Out_Cmd.ExecuteReader
            If Trim(CmbxShift.Text) <> "" Then
                While Attd_Out_rdr.Read()
                    If Attd_Out_rdr.HasRows = True Then
                        'DatagrdOutTime_flag = True
                        DatagrdOutTime.Rows.Add()
                        DatagrdOutTime.Rows(a).Cells(0).Value = Attd_Out_rdr(0)
                        DatagrdOutTime.Rows(a).Cells(1).Value = Attd_Out_rdr(1)
                        DatagrdOutTime.Rows(a).Cells(2).Value = Attd_Out_rdr(2)
                        DatagrdOutTime.Rows(a).Cells(3).Value = Attd_Out_rdr(3)
                        RepStatus = Attd_Out_rdr(3)
                        If RepStatus = "Absent" Or RepStatus = "Full Day Leave" Or RepStatus = "Holiday" Then
                            DatagrdOutTime.Rows(a).Cells(4).Value = ("00:00:00")
                        ElseIf RepStatus = "2nd Half Day Leave" Then
                            DatagrdOutTime.Rows(a).Cells(4).Value = Brkfrm.TimeOfDay
                        Else

                            DatagrdOutTime.Rows(a).Cells(4).Value = (LblEndTm.Text)
                        End If
                        a += 1
                        If Me.Height < 654 Then
                            DatagrdOutTime.Height = DatagrdOutTime.Height + 15
                            Me.Height = Me.Height + 15
                        End If

                    End If
                End While
                Me.DatagrdOutTime.AllowUserToAddRows = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Attd_Out_rdr.HasRows = False Then
                MsgBox("No Record Found. ", MsgBoxStyle.Information, "Records")
                CmbxShift.Focus()

            End If
            Attd_Out_rdr.Close()
            Attd_Out_Cmd = Nothing
        End Try

        DatagrdOutTime.Focus()
        If DatagrdOutTime.Rows.Count > 0 Then
            DatagrdOutTime.CurrentCell = DatagrdOutTime.Rows(0).Cells(4)


        End If

    End Sub


    Private Sub Chek_Attd_OutTime_Recrd()
        Dim Tm As Date
        DatagrdOutTime.Visible = True
        DatagrdOutTime.Rows.Clear()
        Me.DatagrdOutTime.AllowUserToAddRows = True
        a = 0
        Try
            Attd_Out_Cmd = New SqlCommand("Select AttdEmpid,FinactEmpmstr.empname,AttdStatus,AttdRepStatus,AttdOutTime from Finact_Attd inner join  Finactempmstr on Finact_Attd.AttdEmpid=FinactEmpmstr.empid where AttdSft='" & (CmbxShift.Text) & "'and Attddt='" & (DtpkrDt.Value.Date) & "' ", FinActConn)
            Attd_Out_rdr = Attd_Out_Cmd.ExecuteReader
            If Trim(CmbxShift.Text) <> "" Then
                While Attd_Out_rdr.Read()
                    If Attd_Out_rdr.HasRows = True Then

                        DatagrdOutTime.Rows.Add()
                        DatagrdOutTime.Rows(a).Cells(0).Value = Attd_Out_rdr(0)
                        DatagrdOutTime.Rows(a).Cells(1).Value = Attd_Out_rdr(1)
                        DatagrdOutTime.Rows(a).Cells(2).Value = Attd_Out_rdr(2)
                        DatagrdOutTime.Rows(a).Cells(3).Value = Attd_Out_rdr(3)
                        Tm = Attd_Out_rdr(4)

                        DatagrdOutTime.Rows(a).Cells(4).Value = Tm.TimeOfDay
                  
                        a += 1
                        If Me.Height < 654 Then
                            DatagrdOutTime.Height = DatagrdOutTime.Height + 15
                            Me.Height = Me.Height + 15
                        End If
                    End If
                End While
                Me.DatagrdOutTime.AllowUserToAddRows = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Attd_Out_rdr.HasRows = False Then
                MsgBox("No Record Found. ", MsgBoxStyle.Information, "Records")
                CmbxShift.Focus()

            End If
            Attd_Out_rdr.Close()
            Attd_Out_Cmd = Nothing
        End Try

        DatagrdOutTime.Focus()
        If DatagrdOutTime.Rows.Count > 0 Then
            DatagrdOutTime.CurrentCell = DatagrdOutTime.Rows(0).Cells(4)


        End If

    End Sub


    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        cnfrm_msg = MsgBox("Are you sure to Exit?", MsgBoxStyle.YesNo, "Confirmation")
        If cnfrm_msg = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub DtpkrDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDt.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbxShift.Focus()
        End If
    End Sub

    Private Sub CmbxShift_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxShift.GotFocus
        'CmbxShift.DroppedDown = True
    End Sub

    Private Sub CmbxShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxShift.SelectedIndexChanged
        Fetch_Shift_Recrd()
        Fetch_Attd_OutTime()
        If OutTime_Recrds > 0 Then
            Chek_Attd_OutTime_Recrd()
        Else

            Chek_Attd_Intime_Recrd()
        End If

        ' Lstveiw.Focus()

    End Sub

    Private Sub Clr_val()
        DatagrdOutTime.Rows.Clear()
        LblStrtTm.Text = ""
        LblEndTm.Text = ""
        Me.Height = 300
        DatagrdOutTime.Height = 84
        'CmbxShift.Focus()
        DtpkrDt.Focus()
    End Sub


    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        Clr_val()

    End Sub

    Private Sub Lstveiw_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ''Dim indx, cnt As Integer
        ''Dim chek_edit As String = ""
        ''indx = 0
        ''cnt = Lstveiw.Items.Count
        ''Try
        ''    indx = Lstveiw.SelectedItems(0).Index
        ''    chek_edit = Lstveiw.Items(indx).SubItems(4).Text
        ''    If chek_edit = "Absent" Or chek_edit = "Full Day Leave" Then
        ''        Lstveiw.LabelEdit = False
        ''        MsgBox("Can't edit this Time", MsgBoxStyle.Critical, "Alert")

        ''    Else
        ''        Lstveiw.LabelEdit = True
        ''    End If
        ''Catch ex As Exception
        ''    MsgBox(ex.Message)
        ''End Try



    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        Dim Totl_recrds As Integer = 0
        Dim cntr As Integer = 0
        Totl_recrds = DatagrdOutTime.Rows.Count
        If Totl_recrds > 0 Then
            While cntr < Totl_recrds

                Try
                    Attd_Out_Cmd = New SqlCommand("Finact_Attd_Update_OutTime", FinActConn)
                    Attd_Out_Cmd.CommandType = CommandType.StoredProcedure
                    Attd_Out_Cmd.Parameters.AddWithValue("@Attdedtusrid", Current_UsrId)
                    Attd_Out_Cmd.Parameters.AddWithValue("@Attdedtdt", Now)

                    Attd_Out_Cmd.Parameters.AddWithValue("@AttdEmpid", DatagrdOutTime.Rows(cntr).Cells(0).Value)

                    Attd_Out_Cmd.Parameters.AddWithValue("@Attddt", DtpkrDt.Value.Date)
                    Attd_Out_Cmd.Parameters.AddWithValue("@AttdOutTime", DatagrdOutTime.Rows(cntr).Cells(4).Value)


                    Attd_Out_Cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Attd_Out_Cmd = Nothing
                End Try





                Dim Ovr_Eid As Integer = 0
                Dim Ovr_InTime As Date
                Dim Ovr_OutTime As Date

                Dim th1 As Single
                Dim tm1 As Single
                Dim th2 As Single
                Dim tm2 As Single
                Dim diff1 As Single

                Dim th3 As Single
                Dim tm3 As Single
                Dim th4 As Single
                Dim tm4 As Single
                Dim ovrtm_limit As Single
                Dim diff2 As Single
                Dim Timdiff As Single

                Try
                    Attd_Out_Cmd = New SqlCommand("Select AttdEmpid,AttdInTime,AttdOutTime from Finact_Attd where AttdEmpid='" & (DatagrdOutTime.Rows(cntr).Cells(0).Value) & "'and Attddt='" & (DtpkrDt.Value.Date) & "' ", FinActConn)
                    Attd_Out_rdr = Attd_Out_Cmd.ExecuteReader
                    Attd_Out_rdr.Read()
                    If Attd_Out_rdr.HasRows = True Then
                        Ovr_Eid = Attd_Out_rdr(0)
                        Ovr_InTime = Format(Attd_Out_rdr(1), "HH:mm:ss")
                        Ovr_OutTime = Format(Attd_Out_rdr(2), "HH:mm:ss")

                        th1 = Format(Attd_Out_rdr(1), "hh")
                        th1 = th1 * 60
                        tm1 = Format(Attd_Out_rdr(1), "mm")
                        tm1 = th1 + tm1
                        ' Txtdif.Text = diff
                        th2 = Format(Attd_Out_rdr(2), "hh")
                        th2 = th2 * 60
                        tm2 = Format(Attd_Out_rdr(2), "mm")
                        tm2 = th2 + tm2
                        diff1 = tm2 - tm1

                        MsgBox(diff1)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Attd_Out_rdr.Close()
                    Attd_Out_Cmd = Nothing
                End Try



                Try
                    Attd_Out_Cmd = New SqlCommand("Select Empstdtime,Empendtime,Empovertm from FinactEmpTimeMstr where EmpSift='" & (CmbxShift.Text) & "' and Empdelstatus='" & (0) & "' ", FinActConn)
                    Attd_Out_rdr = Attd_Out_Cmd.ExecuteReader
                    Attd_Out_rdr.Read()
                    If Attd_Out_rdr.HasRows = True Then
                        th3 = Format(Attd_Out_rdr(0), "hh")
                        th3 = th3 * 60
                        tm3 = Format(Attd_Out_rdr(0), "mm")
                        tm3 = th3 + tm3
                        th4 = Format(Attd_Out_rdr(1), "hh")
                        th4 = th4 * 60
                        tm4 = Format(Attd_Out_rdr(1), "mm")
                        tm4 = th4 + tm4
                        diff2 = tm4 - tm3
                        ovrtm_limit = Attd_Out_rdr(2)

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Attd_Out_rdr.Close()
                    Attd_Out_Cmd = Nothing

                End Try

                If diff1 > diff2 Then
                    Timdiff = diff1 - diff2
                    If Timdiff > ovrtm_limit Then
                        Try
                            Attd_Out_Cmd = New SqlCommand("Finact_Attd_OvrTime_Insert", FinActConn)
                            Attd_Out_Cmd.CommandType = CommandType.StoredProcedure
                            Attd_Out_Cmd.Parameters.AddWithValue("@OvrTmadusrid", Current_UsrId)
                            Attd_Out_Cmd.Parameters.AddWithValue("@OvrTmaddt", Now)

                            Attd_Out_Cmd.Parameters.AddWithValue("@OvrTmEmpId", DatagrdOutTime.Rows(cntr).Cells(0).Value)

                            Attd_Out_Cmd.Parameters.AddWithValue("@OvrTmMinuts", Timdiff)
                            Attd_Out_Cmd.Parameters.AddWithValue("@OvrTmDt", DtpkrDt.Value.Date)


                            Attd_Out_Cmd.ExecuteNonQuery()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Attd_Out_Cmd = Nothing
                        End Try


                    End If
                End If


                cntr = cntr + 1
            End While

            MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information, "Save Record")

            Clr_val()

        End If
    End Sub

    Private Sub Count_OvrTimeHrs()
      



    End Sub


    Private Sub fetch_Diff() 'no use
      
    End Sub



    Private Sub DatagrdOutTime_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DatagrdOutTime.CellBeginEdit
        If DatagrdOutTime.Rows(e.RowIndex).Cells(3).Value = "Holiday" Or DatagrdOutTime.Rows(e.RowIndex).Cells(3).Value = "Absent" Or DatagrdOutTime.Rows(e.RowIndex).Cells(3).Value = "Full Day Leave" Then

            DatagrdOutTime.Rows(e.RowIndex).Cells(4).ReadOnly = True
            'DatagrdOutTime.Rows(e.RowIndex).Cells(4).IsInEditMode = False


            MsgBox("Can't edit this Time", MsgBoxStyle.Information, "Time Validity")
            DatagrdOutTime.Rows(e.RowIndex).Cells(4).ReadOnly = True
            If e.RowIndex < DatagrdOutTime.Rows.Count - 1 Then
                DatagrdOutTime.Focus()
                DatagrdOutTime.Rows(e.RowIndex + 1).Cells(4).ReadOnly = True
                DatagrdOutTime.CurrentCell = DatagrdOutTime.Rows(e.RowIndex + 1).Cells(4)

            Else
                DatagrdOutTime.Focus()
                DatagrdOutTime.CurrentCell = DatagrdOutTime.Rows(e.RowIndex - 1).Cells(4)
                DatagrdOutTime.Rows(e.RowIndex - 1).Cells(4).ReadOnly = True
            End If
            Exit Sub
        End If
    End Sub

    Private Sub DatagrdOutTime_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DatagrdOutTime.CellValidating
        If DatagrdOutTime.Columns(e.ColumnIndex).Name = "Column5" Then
            If e.FormattedValue IsNot Nothing AndAlso _
                String.IsNullOrEmpty(e.FormattedValue.ToString()) Then

                DatagrdOutTime.Rows(e.RowIndex).ErrorText = "Blank field not allowed"
                e.Cancel = True
            Else
                DatagrdOutTime.Rows(e.RowIndex).ErrorText = ""
                e.Cancel = False
            End If
        End If
        Dim cell As DataGridViewCell = DatagrdOutTime.Item(e.ColumnIndex, e.RowIndex)
        ''If DatagrdOutTime.Rows(e.RowIndex).Cells(3).Value = "Holiday" Then
        ''    MsgBox("Can't edit")
        ''    Exit Sub
        ''End If
        If cell.IsInEditMode Then
            Dim c As Control = DatagrdOutTime.EditingControl

            Select Case DatagrdOutTime.Columns(e.ColumnIndex).Name
                Case "Column5"
                    c.Text = CleanInputNumber(c.Text)
                    '' ''Case "name"
                    '' ''    c.Text = CleanInputAlphabet(c.Text)
            End Select


            Dim str As String
            Dim Hrs As String = ""
            Dim Minuts As String = ""
            Dim Secnds As String = ""
            Dim len As Integer = 0
            Dim i As Integer = 0
            Dim num As Integer = 0
            Dim cnt As Integer = 0
            Dim cnt1 As Integer = 0

            str = c.Text
            len = str.Length
            While i < len

                If str.Chars(i) = ":" Then
                    num += 1
                    If num = 1 Then
                        cnt = i
                    End If
                    If num = 2 Then
                        cnt1 = i
                    End If

                End If

                If num < 1 Then
                    Hrs = Hrs + str.Chars(i)
                End If
                If i > cnt And num = 1 And num < 2 Then
                    Minuts = Minuts + str.Chars(i)
                End If
                If i > cnt1 And num = 2 Then
                    Secnds = Secnds + str.Chars(i)
                End If
                i = i + 1
            End While
            If num < 2 Then
                MsgBox("Enter the Time in correct Format- 'HH:MM:SS'", MsgBoxStyle.Information, "Time Validity")
                e.Cancel = True
            ElseIf CInt(Hrs) > 24 Or CInt(Hrs) < 0 Then
                MsgBox("Value of Hours must be between 1 and 24 ")
                e.Cancel = True
            ElseIf CInt(Minuts) > 60 Then
                MsgBox("Value of Minutes must be between 0 and 60 ")
                e.Cancel = True
            ElseIf CInt(Secnds) > 60 Then
                MsgBox("Value of Seconds must be between 0 and 60 ")
                e.Cancel = True
            End If


        End If


    End Sub


    Private Function CleanInputNumber(ByVal str As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(str, "[a-zA-Z\b\s-.*/_+=\|`~,<>?;']", "")
    End Function


    Private Sub DatagrdOutTime_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DatagrdOutTime.CellValueChanged
        ''If e.RowIndex >= 0 Then
        ''    If DatagrdOutTime.Rows(e.RowIndex).Cells(2).Value = "Holiday" Then

        ''        MsgBox("Can't edit ", MsgBoxStyle.Information, "Alert")
        ''        ''chk_cell_flag = True
        ''        ''Datagrdusrdef.Focus()
        ''        ''Datagrdusrdef.CurrentCell = Datagrdusrdef.Rows(e.RowIndex).Cells(1)


        ''        ''End Try
        ''    End If
        ''End If


    End Sub
End Class
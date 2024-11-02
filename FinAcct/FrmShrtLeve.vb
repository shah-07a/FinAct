Imports System.Data
Imports System.Data.SqlClient

Public Class FrmShrtLeve
    Dim Attd_SrtLeve_Cmd As SqlCommand
    Dim Attd_SrtLeve_Rdr As SqlDataReader
    Dim Cnfrm_msgbx As String
    Dim Comp_Strtdt As Date
    Dim StrtTm As Date
    Dim EndTm As Date
    Dim BrkFrm, BrkTo As Date
    Dim Empid As Integer
    Dim EmpSid As Integer
    Dim num_recrds As Integer = 0
    Dim Totl_Casual_Levs As Integer = 0
    Dim Totl_Sick_Levs As Integer = 0
    Dim Totl_Earn_Levs As Integer = 0
    Dim Totl_Short_Levs As Integer = 0
    Dim Srt_Levs_Attend As Integer = 0
    Dim Srt_Levs As Integer = 0
    Dim Srch_Empid As Integer
    Dim frmdt, Todt, RepDt As Date
    Dim Chk_SrtLevs As Integer
    Dim chng_flag As Boolean = False


    Private Sub FrmShrtLeve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If attd_flag = False Then
            Me.Left = 0
            Me.Top = 0

        End If

        DtpkrDt_SL.Focus()
        fetch_Strtdt()
        DtpkrDt_SL.MinDate = Comp_Strtdt
        Me.Size = New System.Drawing.Point(480, 374)
        fetch_Shift()
        Panel2.Visible = False

        TxtEmpnm.Visible = False

        If attd_flag = True Then
            Me.Location = New System.Drawing.Point(320, 220)
            DtpkrDt_SL.Text = SrtLev_dt
            DtpkrDt_SL.Enabled = False
            CmbSft.Text = SrtLev_Shift
            CmbSft.Enabled = False
            CmbEmName.Visible = False
            TxtEmpnm.Visible = True
            TxtEmpnm.Text = SrtLev_Empnm
            TxtEmpnm.Enabled = False
            CmType.Focus()

        End If
        If Leve_flag = 1 Then
            Me.Location = New System.Drawing.Point(5, 44)
        End If

        BtnFnd.Visible = False
        BtnSave.Location = New System.Drawing.Point(192, 310)
    End Sub


    Private Sub fetch_Strtdt()
        Try
            Attd_SrtLeve_Cmd = New SqlCommand("Select costrtdt from Finactcogatemstr  ", FinActConn)
            Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
            While Attd_SrtLeve_Rdr.Read
                If Attd_SrtLeve_Rdr.HasRows = True Then
                    Comp_Strtdt = Attd_SrtLeve_Rdr(0)
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_SrtLeve_Rdr.Close()
            Attd_SrtLeve_Cmd = Nothing
        End Try
    End Sub


    Private Sub fetch_Shift()
        CmbSft.Items.Clear()
        Try
            Attd_SrtLeve_Cmd = New SqlCommand("Select EmpSift from FinactEmpTimeMstr where Empdelstatus=0 ", FinActConn)
            Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
            While Attd_SrtLeve_Rdr.Read
                If Attd_SrtLeve_Rdr.HasRows = True Then
                    CmbSft.Items.Add(Attd_SrtLeve_Rdr(0))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_SrtLeve_Rdr.Close()
            Attd_SrtLeve_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Shft_Recrd()
        Try
            Attd_SrtLeve_Cmd = New SqlCommand("Select Empstdtime,Empendtime,Empbrkfrom,Empbrkto from FinactEmpTimeMstr where EmpSift='" & (CmbSft.Text) & "' ", FinActConn)
            Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
            If Trim(CmbSft.Text) <> "" Then
                Attd_SrtLeve_Rdr.Read()
                If Attd_SrtLeve_Rdr.HasRows = True Then
                    StrtTm = Attd_SrtLeve_Rdr(0)
                    'LblStrtTime.Text = Format(StrtTime, "HH:mm:ss")
                    EndTm = Attd_SrtLeve_Rdr(1)
                    'LblEndTime.Text = Format(EndTime, "HH:mm:ss")
                    BrkFrm = Attd_SrtLeve_Rdr(2)
                    'LblBrkFrm.Text = Format(BrkFrm, "HH:mm:ss")
                    BrkTo = Attd_SrtLeve_Rdr(3)
                    'LblBrkTo.Text = Format(BrkTo, "HH:mm:ss")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_SrtLeve_Rdr.Close()
            Attd_SrtLeve_Cmd = Nothing
        End Try
    End Sub


    Private Sub Fetch_Recrds()
        Try
            Attd_SrtLeve_Cmd = New SqlCommand("Select count(AttdEmpid) from Finact_Attd where AttdSft='" & (CmbSft.Text) & "'and Attddt='" & (DtpkrDt_SL.Value.Date) & "' ", FinActConn)
            Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
            If Trim(CmbSft.Text) <> "" Then
                Attd_SrtLeve_Rdr.Read()
                If Attd_SrtLeve_Rdr.IsDBNull(0) = False Then

                    num_recrds = Attd_SrtLeve_Rdr(0)
                End If


            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'If Attd_SrtLeve_Rdr.HasRows = False Then

            'End If
            Attd_SrtLeve_Rdr.Close()
            Attd_SrtLeve_Cmd = Nothing
        End Try

    End Sub

    Private Sub Fetch_EmpName()
        CmbEmName.Items.Clear()

        Try
            Attd_SrtLeve_Cmd = New SqlCommand("Select AttdEmpid,FinactEmpmstr.empname from Finact_Attd inner join  Finactempmstr on Finact_Attd.AttdEmpid=FinactEmpmstr.empid where AttdSft='" & (CmbSft.Text) & "'and Attddt='" & (DtpkrDt_SL.Value.Date) & "'and AttdStatus ='Present'  ", FinActConn)
            ' Attd_SrtLeve_Cmd = New SqlCommand("Select empid,empname from FinactEmpmstr where empdelstatus=1 and empcateg='Working' and empothrsift='" & (CmbSft.Text) & "'and empjnDt<='" & (DtpkrDt_SL.Value.Date) & "' ", FinActConn)
            Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
            'Attd_Sift_Rdr.Read()
            While Attd_SrtLeve_Rdr.Read()
                If Attd_SrtLeve_Rdr.HasRows = True Then

                    CmbEmName.Items.Add(Attd_SrtLeve_Rdr(1))

                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Attd_SrtLeve_Rdr.HasRows = False Then
                MsgBox("System has found no Present Status of " & (CmbSft.Text) & " Shift.", MsgBoxStyle.Information, "Find Record")
                DtpkrDt_SL.Focus()
            End If

            Attd_SrtLeve_Rdr.Close()
            Attd_SrtLeve_Cmd = Nothing
        End Try

        If CmbEmName.Items.Count > 0 Then
            CmbEmName.SelectedIndex = 0
            CmbEmName.DroppedDown = True
        End If
    End Sub

    'Private Sub Fetch_Lsthr()
    '    CmbxHr.Items.Clear()
    '    If attd_flag = True Then
    '        Fetch_Shft_Recrd()

    '    End If
    '    Dim strttime As Date
    '    Dim endtime As Date
    '    Dim strt As Single
    '    Dim etime As Single
    '    strttime = Format(StrtTm, "HH:mm:ss")
    '    endtime = Format(EndTm, "HH:mm:ss")
    '    strt = Format(strttime, "HH")
    '    etime = Format(endtime, "HH")
    '    If etime < strt Then
    '        etime = 24 + etime
    '    End If
    '    While strt <= etime
    '        If strt > 24 Then
    '            strt = strt - 24
    '            CmbxHr.Items.Add(strt)
    '            strt = strt + 24 + 1
    '        Else
    '            CmbxHr.Items.Add(strt)
    '            strt = strt + 1
    '        End If

    '    End While

    'End Sub

    Private Sub Fetch_SrtLeaves_Mstr()
        Try
            Attd_SrtLeve_Cmd = New SqlCommand("Select Empsrtlv from FinactEmplevMstr where Empdelstatus=0 ", FinActConn)
            Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
            Attd_SrtLeve_Rdr.Read()
            If Attd_SrtLeve_Rdr.HasRows = True Then

                Totl_Short_Levs = Attd_SrtLeve_Rdr(0)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'If Attd_SrtLeve_Rdr.HasRows = False Then

            'End If
            Attd_SrtLeve_Rdr.Close()
            Attd_SrtLeve_Cmd = Nothing
        End Try



    End Sub

   

    Private Sub Fetch_SrtLeaves()
        Fetch_Empid()
        Try
            Attd_SrtLeve_Cmd = New SqlCommand("Select count(SrtLevId) from Finact_Attd_SrtLev where SrtLevType='Personal' and SrtLevEmpid='" & (Empid) & "'and month(SrtLevDate)='" & (DtpkrDt_SL.Value.Date.Month) & "'and Year(SrtLevDate)='" & (DtpkrDt_SL.Value.Date.Year) & "' ", FinActConn)
            Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
            Attd_SrtLeve_Rdr.Read()
            If Attd_SrtLeve_Rdr.HasRows = True Then
                Srt_Levs = Attd_SrtLeve_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'If Attd_SrtLeve_Rdr.HasRows = False Then

            'End If
            Attd_SrtLeve_Rdr.Close()
            Attd_SrtLeve_Cmd = Nothing
        End Try

    End Sub


    Private Sub BtnCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCls.Click
        Cnfrm_msgbx = MsgBox("Are you sure to Exit?", MsgBoxStyle.YesNo, "Confirmation")
        If Cnfrm_msgbx = vbYes Then
            Me.Close()
            If attd_flag = True Then
                attd_flag = False
            End If
        End If

    End Sub

    Private Sub DtpkrDt_SL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDt_SL.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbSft.Focus()
        End If
    End Sub

    Private Sub CmbSft_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSft.GotFocus
        If CmbSft.Items.Count > 0 Then
            CmbSft.SelectedIndex = 0
            CmbSft.DroppedDown = True

        End If
    End Sub

    Private Sub CmbSft_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbSft.KeyDown
        If e.KeyCode = Keys.Enter Then
            Fetch_Shft_Recrd()
            Fetch_Recrds()
            If num_recrds > 0 Then
                CmbEmName.Focus()
                Fetch_EmpName()
            Else
                MsgBox("System has found no marked Attendance of " & (CmbSft.Text) & "Shift.", MsgBoxStyle.Information, "Find Record")
                DtpkrDt_SL.Focus()
            End If
        End If
    End Sub

    Private Sub CmbEmName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEmName.GotFocus

        If CmbEmName.Items.Count > 0 Then
            CmbEmName.SelectedIndex = 0
            CmbEmName.DroppedDown = True

        End If
    End Sub

    Private Sub CmbEmName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbEmName.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmType.Focus()

        End If
    End Sub

    Private Sub CmType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmType.GotFocus
        If CmType.Items.Count > 0 And BtnSave.Text = "&Save" Then
            CmType.SelectedIndex = 0
            CmType.DroppedDown = True

        End If
    End Sub

    Private Sub CmType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmType.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Dim indx As Integer
            ' Lsthour.GetItemText(0)
            If CmType.Text = "Personal" Then
                Fetch_SrtLeaves_Mstr()

             
                If Srt_Levs < Totl_Short_Levs Then
                    DtpkrFrm.Focus()
                ElseIf Srt_Levs >= Totl_Short_Levs Then
                    MsgBox("All issued Short Leaves(Personal) have been used.", MsgBoxStyle.Information, "Short Leave")
                End If

        
            ElseIf CmType.Text = "Official" Then
                DtpkrFrm.Focus()
            End If
            
        End If
    End Sub


    'Private Sub CmbxMnt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If CmbxMnt.Items.Count > 0 Then
    '        CmbxMnt.SelectedIndex = 0
    '        CmbxMnt.DroppedDown = True
    '    End If
    'End Sub


    'Private Sub CmbxMnt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        Cmbxhr2.Focus()
    '    End If
    'End Sub

    Private Sub ListMnt2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            BtnSave.Focus()

        End If
    End Sub


    'Private Sub CmbxMnt_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CmbxMnt.DroppedDown = False
    'End Sub


    'Private Sub CmbxMnt_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If CmbxHr.Text <> "" Then
    '        LblSrtLevFrm.Text = Trim(CmbxHr.Text) & " : " & Trim(CmbxMnt.Text) & ":00"
    '        LblSrtLevTo.Text = Trim(CmbxHr.Text + 2) & ":" & Trim(CmbxMnt.Text) & ":00"
    '        Cmbxhr2.Text = Mid(LblSrtLevTo.Text, 1, 2)
    '        CmbxMnt2.Text = Mid(LblSrtLevTo.Text, 4, 2)
    '        LblRepTm.Text = Trim(CmbxHr.Text + 2) & ":" & Trim(CmbxMnt.Text) & ":00"
    '    Else
    '        MsgBox("Please select the Hours", MsgBoxStyle.Information, "Time")

    '    End If
    'End Sub

    'Private Sub Fetch_Lsthr_RpTime()
    '    Cmbxhr2.Items.Clear()

    '    Dim strttime As Date
    '    Dim endtime As Date
    '    Dim strt As Single
    '    Dim etime As Single
    '    strttime = Format(StrtTm, "HH:mm:ss")
    '    endtime = Format(EndTm, "HH:mm:ss")
    '    strt = Format(strttime, "HH")
    '    etime = Format(endtime, "HH")
    '    If etime < strt Then
    '        etime = 24 + etime
    '    End If
    '    While strt <= etime
    '        If strt > 24 Then
    '            strt = strt - 24
    '            Cmbxhr2.Items.Add(strt)
    '            strt = strt + 24 + 1
    '        Else
    '            Cmbxhr2.Items.Add(strt)
    '            strt = strt + 1
    '        End If
    '    End While
    'End Sub

    'Private Sub Listhr2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    LblRepTm.Text = Trim(Cmbxhr2.Text) & " : " & Trim(CmbxMnt2.Text) & ":00"
    'End Sub

    'Private Sub ListMnt2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    LblRepTm.Text = Trim(Cmbxhr2.Text) & " : " & Trim(CmbxMnt2.Text) & ":00"
    'End Sub

    'Private Sub CmbxHr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Fetch_Lsthr()
    '    Fetch_Lsthr_RpTime()
    '    If CmbxHr.Items.Count > 0 Then
    '        CmbxHr.SelectedIndex = 0
    '        CmbxHr.DroppedDown = True
    '    End If
    'End Sub


    'Private Sub CmbxHr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        CmbxMnt.Focus()
    '    End If
    'End Sub

    'Private Sub CmbxHr_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CmbxHr.DroppedDown = False
    'End Sub

    'Private Sub CmbxHr_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    LblSrtLevFrm.Text = Trim(CmbxHr.Text) & " : " & Trim(CmbxMnt.Text) & ":00"
    '    LblSrtLevTo.Text = Trim(CmbxHr.Text + 2) & ":" & Trim(CmbxMnt.Text) & ":00"
    '    Cmbxhr2.Text = Mid(LblSrtLevTo.Text, 1, 2)
    '    CmbxMnt2.Text = Mid(LblSrtLevTo.Text, 4, 2)
    '    LblRepTm.Text = Trim(CmbxHr.Text + 2) & ":" & Trim(CmbxMnt.Text) & ":00"
    'End Sub

    'Private Sub Cmbxhr2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Cmbxhr2.Items.Count > 0 Then
    '        Cmbxhr2.SelectedIndex = 0
    '        Cmbxhr2.DroppedDown = True
    '    End If
    'End Sub

    'Private Sub Cmbxhr2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        CmbxMnt2.Focus()
    '    End If
    'End Sub

    'Private Sub Cmbxhr2_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Cmbxhr2.DroppedDown = False
    '    If Cmbxhr2.SelectedIndex < CmbxHr.SelectedIndex Then
    '        MsgBox("Value should be greater than '" & (CmbxHr.Text) & "'")
    '        Cmbxhr2.Focus()

    '    End If
    'End Sub

    'Private Sub CmbxMnt2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If CmbxMnt2.Items.Count > 0 Then
    '        CmbxMnt2.SelectedIndex = 0
    '        CmbxMnt2.DroppedDown = True
    '    End If
    'End Sub

    'Private Sub CmbxMnt2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
    '        BtnSave.Focus()
    '    End If
    'End Sub

    'Private Sub CmbxMnt2_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CmbxMnt2.DroppedDown = False
    'End Sub

    Private Sub Cmbxhr2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'LblSrtLevFrm.Text = Trim(CmbxHr.Text) & " : " & Trim(CmbxMnt.Text) & ":00"
        'LblSrtLevTo.Text = Trim(CmbxHr.Text + 2) & ":" & Trim(CmbxMnt.Text) & ":00"
        'Cmbxhr2.Text = Mid(LblSrtLevTo.Text, 1, 2)
        'CmbxMnt2.Text = Mid(LblSrtLevTo.Text, 4, 2)
        'LblRepTm.Text = Trim(Cmbxhr2.Text) & ":" & Trim(CmbxMnt2.Text) & ":00"
    End Sub

    'Private Sub CmbxMnt2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    LblRepTm.Text = Trim(Cmbxhr2.Text) & ":" & Trim(CmbxMnt2.Text) & ":00"
    'End Sub

    Private Sub Fetch_Empid()
        If attd_flag = False Then
            Try
                Attd_SrtLeve_Cmd = New SqlCommand("Select empid from  FinactEmpmstr where empname='" & (CmbEmName.Text) & "'", FinActConn)
                Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
                Attd_SrtLeve_Rdr.Read()

                If Attd_SrtLeve_Rdr.HasRows = True Then

                    Empid = Attd_SrtLeve_Rdr(0)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Attd_SrtLeve_Rdr.Close()
                Attd_SrtLeve_Cmd = Nothing
            End Try

        ElseIf attd_flag = True Then
            Try
                Attd_SrtLeve_Cmd = New SqlCommand("Select empid from  FinactEmpmstr where empname='" & (TxtEmpnm.Text) & "'", FinActConn)
                Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
                Attd_SrtLeve_Rdr.Read()

                If Attd_SrtLeve_Rdr.HasRows = True Then

                    Empid = Attd_SrtLeve_Rdr(0)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Attd_SrtLeve_Rdr.Close()
                Attd_SrtLeve_Cmd = Nothing
            End Try
        End If
    End Sub

    Private Sub Fetch_Empid_Fnd()
        Try
            Attd_SrtLeve_Cmd = New SqlCommand("Select empid from  FinactEmpmstr where empname='" & (CmbxSrchEmp.Text) & "'", FinActConn)
            Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
            Attd_SrtLeve_Rdr.Read()

            If Attd_SrtLeve_Rdr.HasRows = True Then

                EmpSid = Attd_SrtLeve_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_SrtLeve_Rdr.Close()
            Attd_SrtLeve_Cmd = Nothing
        End Try
    End Sub


    Private Sub Chek_SrtLev()
        If BtnSave.Text = "&Save" Then

            Fetch_Empid()
            Try
                Attd_SrtLeve_Cmd = New SqlCommand("Select count(SrtLevId) from  Finact_Attd_SrtLev where SrtLevEmpid='" & (Empid) & "'and SrtLevDate='" & (DtpkrDt_SL.Value.Date) & "'and SrtLevStrtTm = '" & (frmdt) & "' or  SrtLevStrtTm <'" & (frmdt) & "'and SrtLevEndTm> '" & (frmdt) & "' ", FinActConn)
                Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
                Attd_SrtLeve_Rdr.Read()

                If Attd_SrtLeve_Rdr.HasRows = True Then

                    Chk_SrtLevs = Attd_SrtLeve_Rdr(0)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Attd_SrtLeve_Rdr.Close()
                Attd_SrtLeve_Cmd = Nothing
            End Try

        ElseIf BtnSave.Text = "&Edit" Then
            Fetch_Empid_Fnd()
            Try
                Attd_SrtLeve_Cmd = New SqlCommand("Select count(SrtLevId) from  Finact_Attd_SrtLev where SrtLevEmpid='" & (EmpSid) & "'and SrtLevDate='" & (DtpkrDt_SL.Value.Date) & "'and SrtLevStrtTm = '" & (frmdt) & "' or  SrtLevStrtTm <'" & (frmdt) & "'and SrtLevEndTm> '" & (frmdt) & "' ", FinActConn)
                Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
                Attd_SrtLeve_Rdr.Read()

                If Attd_SrtLeve_Rdr.HasRows = True Then

                    Chk_SrtLevs = Attd_SrtLeve_Rdr(0)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Attd_SrtLeve_Rdr.Close()
                Attd_SrtLeve_Cmd = Nothing
            End Try
        End If

    End Sub


    Private Sub SrtLev_recrd()

        Fetch_Empid()
        Try
            Attd_SrtLeve_Cmd = New SqlCommand("Select SrtLevRepTm from  Finact_Attd_SrtLev where SrtLevId=(select max(SrtLevId) from Finact_Attd_SrtLev)", FinActConn)
            Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
            Attd_SrtLeve_Rdr.Read()

            If Attd_SrtLeve_Rdr.HasRows = True Then

                SrtLev_RepTm = Format(Attd_SrtLeve_Rdr(0), "HH:mm:ss")


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_SrtLeve_Rdr.Close()
            Attd_SrtLeve_Cmd = Nothing
        End Try
    End Sub


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            Fetch_Empid()

            'If LblSrtLevFrm.Text = "24:00:00" Then
            '    LblSrtLevFrm.Text = "00:00:00"
            'End If
            'If LblSrtLevTo.Text = "24:00:00" Then
            '    LblSrtLevTo.Text = "00:00:00"
            'End If
            'If LblRepTm.Text = "24:00:00" Then
            '    LblRepTm.Text = "00:00:00"
            'End If

            frmdt = DtpkrFrm.Value.Date
            ' Todt = CDate(LblSrtLevTo.Text)
            ' RepDt = CDate(LblRepTm.Text)
            Chek_SrtLev()
            If Chk_SrtLevs = 0 Then
                Try
                    Attd_SrtLeve_Cmd = New SqlCommand("Finact_Insert_SrtLev", FinActConn)
                    Attd_SrtLeve_Cmd.CommandType = CommandType.StoredProcedure
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevDate", DtpkrDt_SL.Value.Date)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevShift", CmbSft.Text)
                    If attd_flag = True Then
                        Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevEmpid", SrtLev_Empid)
                    ElseIf attd_flag = False Then
                        Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevEmpid", Empid)
                    End If


                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevType", CmType.Text)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevStrtTm", DtpkrFrm.Text)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevEndTm", DtpkrTo.Text)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevRepTm", DtpkrRepTm.Text)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevadusrid", Current_UsrId)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevaddt", Now)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevdelstatus", 0)

                    Attd_SrtLeve_Cmd.ExecuteNonQuery()
                    MsgBox("Record has been Saved Successfully.", MsgBoxStyle.Information, "Save")
                    'SrtLev_RepTm = CDate(DtpkrRepTm.Text)
                    'SrtLev_RepTm = Format(SrtLev_RepTm, "HH:mm:ss")

                    'SrtLev_RepTm = DtpkrRepTm.Value.ToLocalTime
                    SrtLev_recrd()
                    'Dim str, str1 As String
                    'str = SrtLev_RepTm
                    'str1 = str.Substring(8, 2)
                    'If str1 = "PM" Then
                    '    SrtLev_RepTm = DtpkrRepTm.Value.AddHours(+12)
                    'End If
                    SrtLev_Type = CmType.Text

                    If frmdt <> StrtTm Then
                        SrtLevMark_flag = True
                    Else
                        SrtLevMark_flag = False
                    End If
                    Clrvalue()
                    Me.Close()
                    ' DtpkrDt_SL.Focus()

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Attd_SrtLeve_Cmd = Nothing
                End Try
            ElseIf Chk_SrtLevs > 0 Then
                MsgBox("Short Leave has already been issued for the selected Time Period.", MsgBoxStyle.Information, "Short Leave")
                DtpkrFrm.Focus()
            End If

        ElseIf BtnSave.Text = "&Edit" Then
            Fetch_Empid_Fnd()
            'If LblSrtLevFrm.Text = "24:00:00" Then
            '    LblSrtLevFrm.Text = "00:00:00"
            'End If
            'If LblSrtLevTo.Text = "24:00:00" Then
            '    LblSrtLevTo.Text = "00:00:00"
            'End If
            'If LblRepTm.Text = "24:00:00" Then
            '    LblRepTm.Text = "00:00:00"
            'End If

            'frmdt = CDate(LblSrtLevFrm.Text)
            'Todt = CDate(LblSrtLevTo.Text)
            ' RepDt = CDate(LblRepTm.Text)
            Chek_SrtLev()
            If Chk_SrtLevs = 0 Then

                Try
                    Attd_SrtLeve_Cmd = New SqlCommand("Finact_Edit_SrtLev", FinActConn)
                    Attd_SrtLeve_Cmd.CommandType = CommandType.StoredProcedure
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevEmpid", EmpSid)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevType", CmType.Text)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevStrtTm", DtpkrFrm.Value.Date)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevEndTm", DtpkrTo.Value.Date)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevRepTm", DtpkrRepTm.Value.Date)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevedtusrid", Current_UsrId)
                    Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevedtdt", Now)
                    Attd_SrtLeve_Cmd.ExecuteNonQuery()
                    MsgBox("Record has been Updated Successfully.", MsgBoxStyle.Information, "Edit")
                    Clrvalue()
                    BtnSave.Text = "&Save"
                    BtnFnd.Text = "&Find"
                    DtpkrDt_SL.Enabled = True
                    CmbSft.Enabled = True
                    CmbEmName.Visible = True
                    CmbEmName.Enabled = True
                    TxtEmpnm.Visible = False
                    DtpkrDt_SL.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Attd_SrtLeve_Cmd = Nothing
                End Try
            ElseIf Chk_SrtLevs > 0 Then
                MsgBox("Short Leave has already been issued for the selected Time Period.", MsgBoxStyle.Information, "Short Leave")
                DtpkrFrm.Focus()
            End If
        End If

    End Sub

    Private Sub Clrvalue()
        If CmbSft.SelectedIndex > 0 Then
            CmbSft.SelectedIndex = 0
        End If
        If CmbEmName.SelectedIndex > 0 Then
            CmbEmName.SelectedIndex = 0
        End If
        If CmType.SelectedIndex > 0 Then
            CmType.SelectedIndex = 0
        End If
        'If CmbxHr.SelectedIndex > 0 Then
        '    CmbxHr.SelectedIndex = 0
        'End If
        'If CmbxMnt.SelectedIndex > 0 Then
        '    CmbxMnt.SelectedIndex = 0
        'End If
        ' LblSrtLevFrm.Text = ""
        ' LblSrtLevTo.Text = ""

        'If Cmbxhr2.SelectedIndex > 0 Then
        '    Cmbxhr2.SelectedIndex = 0
        'End If
        'If CmbxMnt2.SelectedIndex > 0 Then
        '    CmbxMnt2.SelectedIndex = 0
        'End If
        'LblRepTm.Text = ""
    End Sub


    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        Clrvalue()
        If attd_flag = False Then
            Panel2.Visible = False
            Me.Size = New System.Drawing.Point(480, 374)
            ListVew.Items.Clear()
            BtnSave.Text = "&Save"
            BtnFnd.Text = "&Find"
            DtpkrDt_SL.Enabled = True
            CmbSft.Enabled = True
            CmbEmName.Enabled = True
            DtpkrDt_SL.Focus()
        ElseIf attd_flag = True Then
            Me.Close()
        End If

    End Sub


    Private Sub BtnFnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd.Click
        If BtnFnd.Text = "&Find" Then
            CmbxSrchEmp.Items.Clear()
            Panel2.Visible = True
            Me.Size = New System.Drawing.Point(480, 588)
            BtnFnd.Text = "&Delete"
            BtnSave.Text = "&Edit"
            Try
                Attd_SrtLeve_Cmd = New SqlCommand("Select empname from  FinactEmpmstr inner join Finact_Attd_SrtLev on FinactEmpmstr.empid=Finact_Attd_SrtLev.SrtLevEmpid where SrtLevdelstatus=0 union Select empname from  FinactEmpmstr inner join Finact_Attd on FinactEmpmstr.empid=Finact_Attd.AttdEmpid where AttdRepStatus='Short Leave'", FinActConn)
                Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader

                While Attd_SrtLeve_Rdr.Read()
                    If Attd_SrtLeve_Rdr.HasRows = True Then
                        CmbxSrchEmp.Items.Add(Attd_SrtLeve_Rdr(0))

                    End If
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Attd_SrtLeve_Rdr.Close()
                Attd_SrtLeve_Cmd = Nothing
            End Try
            CmbxSrchEmp.Focus()

        ElseIf BtnFnd.Text = "&Delete" Then

            Fetch_Empid_Fnd()
            Try
                Attd_SrtLeve_Cmd = New SqlCommand("Finact_Delete_SrtLev", FinActConn)
                Attd_SrtLeve_Cmd.CommandType = CommandType.StoredProcedure
                Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevEmpid", EmpSid)
                Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevdelusrid", Current_UsrId)
                Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevdeldt", Now)
                Attd_SrtLeve_Cmd.Parameters.AddWithValue("@SrtLevdelstatus", 1)
                Attd_SrtLeve_Cmd.ExecuteNonQuery()
                MsgBox("Record has been Deleted Successfully.", MsgBoxStyle.Information, "Delete")
                Clrvalue()
                BtnSave.Text = "&Save"
                BtnFnd.Text = "&Find"
                DtpkrDt_SL.Enabled = True
                CmbSft.Enabled = True
                CmbEmName.Visible = True
                CmbEmName.Enabled = True
                TxtEmpnm.Visible = False
                DtpkrDt_SL.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Attd_SrtLeve_Cmd = Nothing
            End Try

        End If
    End Sub


    Private Sub Fetch_Srch_Empid()
        Try
            Attd_SrtLeve_Cmd = New SqlCommand("Select empid from  FinactEmpmstr where empname='" & (CmbxSrchEmp.Text) & "'", FinActConn)
            Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader
            Attd_SrtLeve_Rdr.Read()

            If Attd_SrtLeve_Rdr.HasRows = True Then

                Srch_Empid = Attd_SrtLeve_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_SrtLeve_Rdr.Close()
            Attd_SrtLeve_Cmd = Nothing
        End Try
    End Sub

    Private Sub Dtpkr_Fnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpkr_Fnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbxType_Fnd.Focus()
        End If
    End Sub


    Private Sub CmbxSrchEmp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSrchEmp.GotFocus
        If CmbxSrchEmp.Items.Count > 0 Then
            CmbxSrchEmp.SelectedIndex = 0
            CmbxSrchEmp.DroppedDown = True
        End If
    End Sub

    Private Sub CmbxSrchEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSrchEmp.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Dtpkr_Fnd.Focus()
        End If
    End Sub

    Private Sub ListVew_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListVew.DoubleClick
        Dim indx As Integer
        Dim frmdt, Reprtdt As Date
        CmbEmName.Visible = True
        TxtEmpnm.Visible = True

        indx = ListVew.SelectedItems(0).Index
        DtpkrDt_SL.Text = ListVew.Items(indx).SubItems(0).Text
        TxtEmpnm.Text = ListVew.Items(indx).SubItems(2).Text
        DtpkrFrm.Text = ListVew.Items(indx).SubItems(3).Text
        CmbSft.Text = ListVew.Items(indx).SubItems(6).Text
        Fetch_Shft_Recrd()
        'Fetch_Lsthr()
        'Fetch_Lsthr_RpTime()
        frmdt = ListVew.Items(indx).SubItems(3).Text
        'CmbxHr.Text = frmdt.Hour
        'CmbxMnt.Text = frmdt.Minute
        DtpkrTo.Text = ListVew.Items(indx).SubItems(4).Text
        DtpkrRepTm.Text = ListVew.Items(indx).SubItems(5).Text
        Reprtdt = ListVew.Items(indx).SubItems(5).Text
        'Cmbxhr2.Text = Reprtdt.Hour
        'CmbxMnt2.Text = Reprtdt.Minute

        CmType.Text = ListVew.Items(indx).SubItems(7).Text

        DtpkrDt_SL.Enabled = False
        CmbSft.Enabled = False
        TxtEmpnm.Enabled = False
        Me.Size = New System.Drawing.Point(480, 374)
        CmType.Focus()

    End Sub

    Private Sub CmbxType_Fnd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxType_Fnd.GotFocus
        If CmbxType_Fnd.Items.Count > 0 Then
            CmbxType_Fnd.SelectedIndex = 0
            CmbxType_Fnd.DroppedDown = True
        End If
    End Sub

    Private Sub CmbxType_Fnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxType_Fnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Type As String = ""
            If CmbxType_Fnd.Text = "Official" Then
                Type = "Official"
            ElseIf CmbxType_Fnd.Text = "Personal" Then
                Type = "Personal"
            End If

            Dim Lstvw As ListViewItem
            Fetch_Srch_Empid()
            Try
                Attd_SrtLeve_Cmd = New SqlCommand("Select SrtLevDate,SrtLevEmpid,Finactempmstr.empname,SrtLevStrtTm,SrtLevEndTm,SrtLevRepTm,SrtLevShift,SrtLevType from  Finact_Attd_SrtLev inner join FinactEmpmstr on Finact_Attd_SrtLev.SrtLevEmpid=FinactEmpmstr.empid where SrtLevEmpid='" & (Srch_Empid) & "'and month(SrtLevDate)='" & (Dtpkr_Fnd.Value.Date.Month) & "'and year(SrtLevDate)='" & (Dtpkr_Fnd.Value.Date.Year) & "'and SrtLevType='" & (Type) & "'and SrtLevdelstatus=0 ", FinActConn)
                Attd_SrtLeve_Rdr = Attd_SrtLeve_Cmd.ExecuteReader

                While Attd_SrtLeve_Rdr.Read()
                    If Attd_SrtLeve_Rdr.HasRows = True Then

                        Lstvw = ListVew.Items.Add(Attd_SrtLeve_Rdr(0))
                        Lstvw.SubItems.Add(Attd_SrtLeve_Rdr(1))
                        Lstvw.SubItems.Add(Attd_SrtLeve_Rdr(2))
                        Lstvw.SubItems.Add(Format(Attd_SrtLeve_Rdr(3), "HH:mm:ss"))
                        Lstvw.SubItems.Add(Format(Attd_SrtLeve_Rdr(4), "HH:mm:ss"))
                        Lstvw.SubItems.Add(Format(Attd_SrtLeve_Rdr(5), "HH:mm:ss"))
                        Lstvw.SubItems.Add(Attd_SrtLeve_Rdr(6))
                        Lstvw.SubItems.Add(Attd_SrtLeve_Rdr(7))
                    End If
                End While
                If Attd_SrtLeve_Rdr.HasRows = True Then
                    Panel2.Visible = False
                    Me.Size = New System.Drawing.Point(1024, 387)
                    If ListVew.Items.Count > 0 Then
                        ListVew.Focus()
                        ListVew.Items(0).Selected = True
                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Attd_SrtLeve_Rdr.HasRows = False Then
                    MsgBox("System has found no Short Leave record of '" & (CmbxSrchEmp.Text) & "'", MsgBoxStyle.Information, "Find")

                End If

                Attd_SrtLeve_Rdr.Close()
                Attd_SrtLeve_Cmd = Nothing
            End Try

        End If
    End Sub


    Private Sub ListVew_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListVew.KeyDown
        If e.KeyCode = Keys.Enter And ListVew.SelectedItems.Count > 0 Then
            ListVew_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub DtpkrFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrFrm.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If chng_flag = False Then
                DtpkrTo.Text = DtpkrFrm.Value.AddHours(+2)
                DtpkrRepTm.Text = DtpkrFrm.Value.AddHours(+2)
            End If

            DtpkrRepTm.Focus()

        End If
    End Sub


    Private Sub DtpkrRepTm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrRepTm.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            BtnSave.Focus()

        End If
    End Sub


    Private Sub DtpkrFrm_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrFrm.ValueChanged
        DtpkrTo.Text = DtpkrFrm.Value.AddHours(+2)
        DtpkrRepTm.Text = DtpkrFrm.Value.AddHours(+2)
        chng_flag = True
    End Sub

    Private Sub CmbxType_Fnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxType_Fnd.SelectedIndexChanged

    End Sub
End Class
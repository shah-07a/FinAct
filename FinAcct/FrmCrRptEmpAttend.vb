Imports System.Data
Imports System.Data.SqlClient
Imports System.Math
Imports System.Data.Odbc
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCrRptEmpAttend
    Inherits System.Windows.Forms.Form
    Dim da1 As SqlDataAdapter
    Dim Atd_Head_Cmd As SqlCommand
    Dim Atd_Head_Adptr As SqlDataAdapter
    Dim Atd_Head_Rdr As SqlDataReader
    Dim Atd_Head_Cmd2 As SqlCommand
    Dim Atd_Head_Rdr2 As SqlDataReader
    Dim Atd_Head_Cmd3 As SqlCommand
    Dim Atd_Head_Rdr3 As SqlDataReader
    Dim odc_Head_Cmd As SqlCommand
    Dim odc_Head_Rdr As SqlDataReader
    Dim Atd_Head_Cmd1 As SqlCommand
    Dim Atd_Head_Rdr1 As SqlDataReader
    Dim odbccon1 As OdbcConnection
    Dim OdbcCmd1 As OdbcCommand
    Dim OdbcDa1 As OdbcDataAdapter
    Dim Odbcrdr1 As OdbcDataReader
    'Dim Odbccon1 As SqlConnection
    'Dim OdbcCmd1 As SqlCommand
    'Dim OdbcDa1 As SqlDataAdapter
    'Dim OdbcRdr1 As SqlDataReader
    Dim hour1 As Integer = 0
    Dim SEC As Integer = 0
    Dim fetch_mainempid As Integer = 0
    Dim Strtminyear As Date
    Dim mnth As Integer = 0
    Dim Maxselid As Integer = 0
    Dim monthdays As Integer = 0
    Dim sunday As Integer = 0
    Dim Dtagrdflag As Boolean = False
    Dim Strtyear As Date
    Dim minmon As Integer
    Dim minyear As Integer
    Dim maxmon As Integer
    Dim maxyear As Integer
    Dim lavflag As Boolean = False
    Dim holiday As Integer = 0
    Dim indx As Integer = 0
    Dim CrRptAttnd As New CrRptEmp_Attnd_mnthly
    Dim TellRptstatus As Boolean
    Private Sub FrmEmpAttend_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Left = 0
        Me.Top = 0
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 20
        Me.Height = 122
        TellRptstatus = True
        CoprofileParamsEmpInfo()
        fetch_Costrtdate()
        Dtpick1.MinDate = Strtminyear
        Combcatgry.Text = Combcatgry.Items(0)
        Dtpick1.Focus()

    End Sub

    Private Sub Combcatgry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combcatgry.GotFocus
        Combcatgry.DroppedDown = True
        Dtagrdflag = False
    End Sub
    Private Sub Combcatgry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combcatgry.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Combcatgry.SelectedIndex = 0 Then
                Me.Height = 122
                fetchrd()
                lbldeptcriteria.Visible = False
                Panel1.Visible = False
                Lbldesi.Visible = False
                Combdesi.Visible = False
                Lblempnm.Visible = False
                Combename.Visible = False
                Lbltoid.Visible = False
                Lbldept.Visible = False
                Combodeptnm.Visible = False
                Lblempid.Visible = False
                Combotoid.Visible = False
                Combofromid.Visible = False
                BtnAttndVew.Focus()
            ElseIf Combcatgry.SelectedIndex = 1 Then
                Me.Height = 122
                lbldeptcriteria.Visible = False
                Panel1.Visible = False
                Lbldesi.Visible = False
                Combdesi.Visible = False
                Lbltoid.Visible = False
                Lbldept.Visible = False
                Combodeptnm.Visible = False
                Lblempid.Visible = False
                Combotoid.Visible = False
                Combofromid.Visible = False
                Lblempnm.Visible = True
                Combename.Visible = True
                Combename.Focus()
            ElseIf Combcatgry.SelectedIndex = 2 Then
                Me.Height = 122
                lbldeptcriteria.Visible = False
                Panel1.Visible = False
                Lbldesi.Visible = False
                Combdesi.Visible = False
                Lblempid.Visible = True
                Lbldept.Visible = False
                Combodeptnm.Visible = False
                Lbltoid.Visible = True
                Lblempnm.Visible = False
                Combename.Visible = False
                Combofromid.Visible = True
                Combotoid.Visible = True
                Combofromid.Focus()
            ElseIf Combcatgry.SelectedIndex = 3 Then
                Me.Height = 122
                lbldeptcriteria.Visible = False
                Panel1.Visible = False
                Lbldesi.Visible = False
                Combdesi.Visible = False
                Lblempnm.Visible = False
                Combename.Visible = False
                Lbltoid.Visible = False
                Lblempid.Visible = False
                Combotoid.Visible = False
                Combofromid.Visible = False
                Lblempnm.Visible = False
                Combename.Visible = False
                Lbldept.Visible = True
                Combodeptnm.Visible = True
                Combodeptnm.Focus()
            End If
        End If
    End Sub
    Private Sub Combcatgry_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combcatgry.Leave
        Combcatgry.DroppedDown = False
    End Sub
    Private Sub Combename_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combename.GotFocus
        Combename.Items.Clear()
        fetch_Empname()
        If Combename.Items.Count > 0 Then
            If Combename.SelectedIndex = -1 Then
                Combename.SelectedIndex = 0
            End If
            Combename.DroppedDown = True
        End If
    End Sub
    Private Sub fetch_Empname() '-----------------------fetch employee names
        Dim dtproc As Date
        Dim day1 As Integer
        day1 = Dtpick1.Value.Day
        Dim difday As Integer
        If day1 <> monthdays Then
            'difday = day1 - 1
            'dtproc = Dtpick1.Value.Date.AddDays(-difday)
            difday = monthdays - Dtpick1.Value.Day
            dtproc = Dtpick1.Value.Date.AddDays(difday)

        Else
            dtproc = Dtpick1.Value.Date
        End If


        Try
            Atd_Head_Cmd = New SqlCommand("Select empname from finactEmpMstr where empdelstatus= 1 and  finactEmpMstr.empjndt<='" & (dtproc.Date) & "'order by empname", FinActConn)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            While Atd_Head_Rdr.Read()
                If Atd_Head_Rdr.IsDBNull(0) = False Then
                    If Atd_Head_Rdr.HasRows = True Then
                        Combename.Items.Add(Atd_Head_Rdr(0))
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try
    End Sub
    Private Sub fetch_deptname() '------------------------fetch dept name
        Try
            Atd_Head_Cmd = New SqlCommand("Select deptname from finactdept where deptdelstatus= 1 and depttype='" & ("Dept") & "'order by deptname", FinActConn)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            While Atd_Head_Rdr.Read()
                If Atd_Head_Rdr.IsDBNull(0) = False Then
                    If Atd_Head_Rdr.HasRows = True Then
                        Combodeptnm.Items.Add(Atd_Head_Rdr(0))
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Atd_Head_Rdr.HasRows = False Then
                Atd_Head_Rdr.Close()
                Atd_Head_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Critical, "Department section")
            End If
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try
    End Sub
    Private Sub fetch_Empid() '----------------------------to fetch id's of employees
        Try
            Atd_Head_Cmd = New SqlCommand("Select empid from finactEmpMstr where empdelstatus= 1 order by empid", FinActConn)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            While Atd_Head_Rdr.Read()
                If Atd_Head_Rdr.IsDBNull(0) = False Then
                    If Atd_Head_Rdr.HasRows = True Then
                        Combofromid.Items.Add(Atd_Head_Rdr(0))
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try
    End Sub
    Private Sub fetch_Costrtdate() '-------------to fetch srtdate,year of company and add items in year combo

        Try
            Atd_Head_Cmd = New SqlCommand("Select Costrtdt from finactcogatemstr ", FinActConn)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            Atd_Head_Rdr.Read()
            If Atd_Head_Rdr.IsDBNull(0) = False Then
                If Atd_Head_Rdr.HasRows = True Then
                    Strtminyear = Format(Atd_Head_Rdr(0), "MMMM/yyyy")

                Else
                    Strtminyear = Format("1 / 1 / 1900", "MMMM/yyyy")

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try
    End Sub
    Private Sub fetch_Empminid() '----------to add items in combotoid control acc to set its min id .
        Try
            Atd_Head_Cmd = New SqlCommand("Select empid from finactEmpMstr where empid >= '" & (Maxselid) & "' and  empdelstatus= 1 order by empid", FinActConn)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            While Atd_Head_Rdr.Read()
                If Atd_Head_Rdr.IsDBNull(0) = False Then
                    If Atd_Head_Rdr.HasRows = True Then
                        Combotoid.Items.Add(Atd_Head_Rdr(0))
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try
    End Sub
    Private Sub cntsundays1() '--------for count sundays in monthb---------------- no use
        Dim j1 As Integer = 0
        Dim yer As Integer = 0
        yer = Dtpick1.Value.Year
        sunday = 0
        monthdays = 0
        mnth = Dtpick1.Value.Month
        monthdays = Date.DaysInMonth(yer, mnth)
        Dim dt As Date
        dt = "1/ " & mnth & " / " & yer
        dtp1.Value = Format(dt, "dd/MM/yyyy")
        While j1 < monthdays
            If dtp1.Value.DayOfWeek = 0 Then
                sunday += 1
            End If
            dtp1.Value = dtp1.Value.AddDays(1)
            j1 += 1
        End While
    End Sub
    Private Sub over_time() 'to cal Over Time of emp's per mnth
        Dim Ovr_Eid As Integer = 0
        Dim Ovr_InTime As Date
        Dim str As String = ""
        Dim Ovr_OutTime As Date
        Dim th1 As Single
        Dim tm1 As Single
        Dim th2 As Single
        Dim tm2 As Single
        Dim res_tm As Double = 0.0
        Dim diff1 As Single
        Dim th3 As Single
        Dim tm3 As Single
        Dim th4 As Single
        Dim tm4 As Single
        Dim ovrtm_limit As Single
        Dim diff2 As Single
        Dim Timdiff As Single
        Dim j1 As Integer = 1
        Dim yer As Integer = 0
        Dim con_sft As String = ""
        hour1 = 0
        SEC = 0
        monthdays = 0
        yer = Dtpick1.Value.Year
        monthdays = 0
        mnth = Dtpick1.Value.Month
        monthdays = Date.DaysInMonth(yer, mnth)
        Dim dt As Date
        dt = "1/ " & mnth & " / " & yer
        dtp1.Value = Format(dt, "dd/MM/yyyy")
        While j1 <= monthdays
            Try
                con_sft = ""
                Atd_Head_Cmd3 = New SqlCommand("Select AttdEmpid,AttdInTime,AttdOutTime ,Attdsft from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "'and day(Attddt)='" & (dtp1.Value.Day) & "' and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer) & "' and AttdStatus in('Present','Paid Holiday') ", FinActConn3)
                Atd_Head_Rdr3 = Atd_Head_Cmd3.ExecuteReader
                Atd_Head_Rdr3.Read()
                ' If Atd_Head_Rdr2.IsDBNull(0) = False Then
                If Atd_Head_Rdr3.HasRows = True Then
                    If Atd_Head_Rdr3(2).ToString <> "" Then
                        Ovr_Eid = Atd_Head_Rdr3(0)
                        Ovr_InTime = Format(Atd_Head_Rdr3(1), "HH:mm:ss")
                        str = Atd_Head_Rdr3(2)
                        If str <> "" Then
                            Ovr_OutTime = Format(Atd_Head_Rdr3(2), "HH:mm:ss")
                        End If
                        th1 = Format(Atd_Head_Rdr3(1), "hh")
                        th1 = th1 * 60
                        tm1 = Format(Atd_Head_Rdr3(1), "mm")
                        tm1 = th1 + tm1
                        th2 = Format(Atd_Head_Rdr3(2), "hh")
                        th2 = th2 * 60
                        tm2 = Format(Atd_Head_Rdr3(2), "mm")
                        tm2 = th2 + tm2
                        diff1 = tm2 - tm1
                        con_sft = Atd_Head_Rdr3(3)

                        Atd_Head_Cmd1 = New SqlCommand("Select Empstdtime,Empendtime,Empovertm from FinactEmpTimeMstr where EmpSift='" & (con_sft) & "' and Empdelstatus='" & (0) & "' ", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            th3 = Format(Atd_Head_Rdr1(0), "hh")
                            th3 = th3 * 60
                            tm3 = Format(Atd_Head_Rdr1(0), "mm")
                            tm3 = th3 + tm3
                            th4 = Format(Atd_Head_Rdr1(1), "hh")
                            th4 = th4 * 60
                            tm4 = Format(Atd_Head_Rdr1(1), "mm")
                            tm4 = th4 + tm4
                            diff2 = tm4 - tm3
                            ovrtm_limit = Atd_Head_Rdr1(2)
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        If diff1 > diff2 Then
                            Timdiff = diff1 - diff2
                            If Timdiff >= ovrtm_limit Then
                                Try
                                    res_tm += Timdiff
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            End If
                        End If
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Atd_Head_Rdr3.Close()
                Atd_Head_Cmd3 = Nothing
            End Try
            diff1 = 0
            diff2 = 0
            j1 += 1
            dtp1.Value = dtp1.Value.AddDays(1)
        End While

        Dim overtm As Integer = 0
        overtm = res_tm
        hour1 = Math.DivRem(overtm, 60, 0)
        SEC = overtm Mod 60


    End Sub
    Private Sub cntsundays() '--------for count weekly offdays---------holidays in month
        Dim j1 As Integer = 1
        Dim yer As Integer = 0
        yer = Dtpick1.Value.Year
        sunday = 0
        monthdays = 0

        holiday = 0
        Try
            mnth = Dtpick1.Value.Month
            monthdays = Date.DaysInMonth(yer, mnth)
            Dim dt As Date
            dt = "1/ " & mnth & " / " & yer
            dtp1.Value = Format(dt, "dd/MM/yyyy")
            While j1 <= monthdays
                Atd_Head_Cmd1 = New SqlCommand("Select distinct(AttdStatus) from Finact_Attd where  AttdStatus in('Holiday') and AttdLeveRsn in ('Offday') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer) & "' and Day(Attddt)='" & (dtp1.Value.Day) & "' ", FinActConn1) 'AttdEmpid='" & (fetch_mainempid) & "' and
                Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                Atd_Head_Rdr1.Read()
                If Atd_Head_Rdr1.HasRows = True Then
                    sunday += 1
                Else
                    sunday += 0
                End If
                Atd_Head_Rdr1.Close()
                Atd_Head_Cmd1 = Nothing
                dtp1.Value = dtp1.Value.AddDays(1)
                j1 += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        j1 = 1
        yer = 0
        yer = Dtpick1.Value.Year

        Try
            mnth = Dtpick1.Value.Month
            monthdays = Date.DaysInMonth(yer, mnth)
            Dim dt As Date
            dt = "1/ " & mnth & " / " & yer
            dtp1.Value = Format(dt, "dd/MM/yyyy")
            While j1 <= monthdays
                Atd_Head_Cmd1 = New SqlCommand("Select distinct(AttdStatus) from Finact_Attd where  AttdStatus in('Holiday') and AttdLeveRsn in ('Holiday') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer) & "'  and Day(Attddt)='" & (dtp1.Value.Day) & "' ", FinActConn1)
                Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                Atd_Head_Rdr1.Read()
                If Atd_Head_Rdr1.HasRows = True Then
                    holiday += 1
                Else
                    holiday += 0
                End If
                Atd_Head_Rdr1.Close()
                Atd_Head_Cmd1 = Nothing
                dtp1.Value = dtp1.Value.AddDays(1)
                j1 += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub fetchrdtry()  '---------------------------no use

        Dim i As Integer = 0
        fetch_mainempid = 0
        Dim j As Integer = 1
        cntsundays()
        Dim yer_srch As Integer = 0
        Dim leave As Double = 0
        Dim srtlev As Integer = 0
        yer_srch = Dtpick1.Value.Year
        Dim tot_days As Double = 0.0
        Dim pres As Double = 0
        Dim abst As Integer = 0
        Dim holi As Integer = 0
        Dim overtm As Integer = 0
        Dim week As Integer = 0

        Try
            Dim emid As New SqlParameter("@empid", SqlDbType.BigInt)
            Atd_Head_Cmd = New SqlCommand("Finact_EmpAttend_SelectAll", FinActConn)
            Atd_Head_Cmd.CommandType = CommandType.StoredProcedure
            Atd_Head_Cmd.Parameters.Add("@empid", SqlDbType.BigInt).Value = DBNull.Value
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            While Atd_Head_Rdr.Read()
                If Atd_Head_Rdr.IsDBNull(0) = False Then
                    If Atd_Head_Rdr.HasRows = True Then
                        'DataGridView.Rows.Add()
                        'DataGridView.Rows(i).Cells(0).Value = j
                        'DataGridView.Rows(i).Cells(1).Value = Atd_Head_Rdr("empname")
                        'DataGridView.Rows(i).Cells(2).Value = Atd_Head_Rdr("empid")
                        'DataGridView.Rows(i).Cells(3).Value = Atd_Head_Rdr("desiname")
                        'fetch_mainempid = Atd_Head_Rdr("empid")

                        '=================present
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            pres = Atd_Head_Rdr1(0)
                            ' DataGridView.Rows(i).Cells(4).Value = Atd_Head_Rdr1(0)
                        Else
                            pres = 0
                            'DataGridView.Rows(i).Cells(4).Value = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd1 = New SqlCommand("Select  AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        While Atd_Head_Rdr1.Read()
                            If Atd_Head_Rdr1.HasRows = True Then
                                pres += 0.5
                            Else
                                pres += 0
                            End If
                        End While
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        ' DataGridView.Rows(i).Cells(4).Value = pres
                        '==================absent
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Absent') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            abst = Atd_Head_Rdr1(0)
                        Else
                            abst = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '=====holiday 
                        'DataGridView.Rows(i).Cells(6).Value = holiday

                        '==============short leave
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and AttdRepstatus in ('Short Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            srtlev = Atd_Head_Rdr1(0)
                        Else
                            srtlev = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd1 = New SqlCommand("Select srtlevid from Finact_Attd_srtlev where SrtlevEmpid='" & (fetch_mainempid) & "' and SrtLevType='" & ("Personal") & "' and month(SrtLevdate)='" & (mnth) & "' and year(SrtLevdate)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        While Atd_Head_Rdr1.Read()
                            If Atd_Head_Rdr1.HasRows = True Then
                                srtlev += 1
                            Else
                                srtlev += 0
                            End If
                        End While
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing
                        'DataGridView.Rows(i).Cells(8).Value = srtlev

                        '================leave
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Leave') and AttdRepstatus in ('Full Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            leave = Atd_Head_Rdr1(0)
                        Else
                            leave = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd1 = New SqlCommand("Select AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and AttdRepstatus in ('1st Half Day Leave','2nd Half Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        While Atd_Head_Rdr1.Read()
                            If Atd_Head_Rdr1.HasRows = True Then
                                leave += 0.5
                            Else
                                leave += 0
                            End If
                        End While
                        'DataGridView.Rows(i).Cells(7).Value = leave
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        ''=====weekly offday
                        'DataGridView.Rows(i).Cells(5).Value = sunday


                        '==============paid holiday
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Paid Holiday') and AttdLeveRsn in ('Present') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) '
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            overtm = Atd_Head_Rdr1(0)
                            'DataGridView.Rows(i).Cells(11).Value = Atd_Head_Rdr1(0)
                        Else
                            overtm = 0
                            'DataGridView.Rows(i).Cells(11).Value = Atd_Head_Rdr1(0)
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '===============monthdays
                        'DataGridView.Rows(i).Cells(10).Value = monthdays


                        '===============joindtforabsent
                        Dim dt As Date
                        Dim days_abs As Double = 0
                        Atd_Head_Cmd1 = New SqlCommand("Select empjndt from FinactEmpMstr where Empid='" & (fetch_mainempid) & "' and EmpdelStatus='" & (1) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            dt = Atd_Head_Rdr1(0)
                            If dt.Month = mnth Then
                                If dt.Day <> 1 Then
                                    days_abs = abst + pres + holiday + sunday + leave
                                    days_abs = (monthdays - days_abs) + abst
                                    'DataGridView.Rows(i).Cells(9).Value = days_abs
                                    ' DataGridView.Rows(i).Cells(12).Value = "Joining Date on " & dt
                                Else
                                    'DataGridView.Rows(i).Cells(9).Value = abst
                                End If
                            Else
                                If pres = 0 And abst = 0 And leave = 0 Then
                                    'DataGridView.Rows(i).Cells(9).Value = monthdays - holiday - sunday
                                Else
                                    'DataGridView.Rows(i).Cells(9).Value = abst
                                End If

                            End If
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing
                        indx = i
                        over_time()

                        j += 1
                        i += 1
                        'If Me.Height < Screen.PrimaryScreen.WorkingArea.Height Then
                        '    DataGridView.Height =' DataGridView.Height + 15
                        '    Me.Height = Me.Height + 15
                        'End If
                    End If
                End If
                srtlev = 0
                leave = 0
                tot_days = 0.0
                pres = 0
                abst = 0
                holi = 0
                overtm = 0
                week = 0
            End While

            'Me.DataGridView.AllowUserToAddRows = False
            'DataGridView.Focus()
            'If DataGridView.Rows.Count > 0 Then
            'DataGridView.CurrentCell = DataGridView.Rows(0).Cells(1)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Atd_Head_Rdr.HasRows = False Then
                Atd_Head_Rdr.Close()
                Atd_Head_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "Search All")
                'DataGridView.Visible = False
            End If
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try

    End Sub
    Private Sub fetchrd()  '---------------------------All option
        'to delete
        Try
            Atd_Head_Cmd = New SqlCommand("Finact_Emp_Sum_Mnth_Delete", FinActConn)
            Atd_Head_Cmd.CommandType = CommandType.StoredProcedure
            Atd_Head_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Atd_Head_Cmd = Nothing
        End Try

        hour1 = 0
        SEC = 0
        Dim i As Integer = 0
        fetch_mainempid = 0
        Dim j As Integer = 1
        cntsundays()
        Dim yer_srch As Integer = 0
        Dim leave As Double = 0
        Dim srtlev As Integer = 0
        yer_srch = Dtpick1.Value.Year
        Dim tot_days As Double = 0.0
        Dim pres As Double = 0
        Dim abst As Integer = 0
        Dim holi As Integer = 0
        Dim overtm As Integer = 0
        Dim week As Integer = 0
        Dim str As String = ""
        Dim dtproc As Date
        Dim day1 As Integer
        day1 = Dtpick1.Value.Day
        Dim difday As Integer
        If day1 <> monthdays Then
            'difday = day1 - 1
            'dtproc = Dtpick1.Value.Date.AddDays(-difday)
            difday = monthdays - Dtpick1.Value.Day
            dtproc = Dtpick1.Value.Date.AddDays(difday)

        Else
            dtproc = Dtpick1.Value.Date
        End If

        str = MonthName(Dtpick1.Value.Month) & "-" & Dtpick1.Value.Year
        Try
            ' Dim emid As New SqlParameter("@empid", SqlDbType.BigInt)
            Atd_Head_Cmd = New SqlCommand("Finact_EmpAttend_SelectAll1", FinActConn)
            Atd_Head_Cmd.CommandType = CommandType.StoredProcedure
            Atd_Head_Cmd.Parameters.AddWithValue("@Strtdt", dtproc.Date)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            While Atd_Head_Rdr.Read()
                If Atd_Head_Rdr.IsDBNull(0) = False Then
                    If Atd_Head_Rdr.HasRows = True Then

                        Atd_Head_Cmd2 = New SqlCommand("Finact_Emp_Sum_Mnth_Insert", FinActConn2)
                        Atd_Head_Cmd2.CommandType = CommandType.StoredProcedure
                        Atd_Head_Cmd2.Parameters.AddWithValue("@Empsrno", j) ' Atd_Head_Rdr("empname"))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@Empname", Atd_Head_Rdr("empname"))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpConId", Atd_Head_Rdr("empid"))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpDesi", Atd_Head_Rdr("desiname"))
                        fetch_mainempid = Atd_Head_Rdr("empid")

                        '=================present
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present','PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            pres = Atd_Head_Rdr1(0)
                        Else
                            pres = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing


                        Atd_Head_Cmd2.Parameters.AddWithValue("@Emppresent", pres)


                        '==================absent
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Absent') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            abst = Atd_Head_Rdr1(0)
                        Else
                            abst = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '=====holiday 
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpHolidays", holiday)

                        '==============short leave
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and AttdRepstatus in ('Short Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            srtlev = Atd_Head_Rdr1(0)
                        Else
                            srtlev = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd1 = New SqlCommand("Select srtlevid from Finact_Attd_srtlev where SrtlevEmpid='" & (fetch_mainempid) & "' and SrtLevType='" & ("Personal") & "' and month(SrtLevdate)='" & (mnth) & "' and year(SrtLevdate)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        While Atd_Head_Rdr1.Read()
                            If Atd_Head_Rdr1.HasRows = True Then
                                srtlev += 1
                            Else
                                srtlev += 0
                            End If
                        End While
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing


                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpSrtLeav", srtlev)

                        '================leave
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Leave') and AttdRepstatus in ('Full Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            leave = Atd_Head_Rdr1(0)
                        Else
                            leave = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd1 = New SqlCommand("Select AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and AttdRepstatus in ('1st Half Day Leave','2nd Half Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        While Atd_Head_Rdr1.Read()
                            If Atd_Head_Rdr1.HasRows = True Then
                                leave += 0.5
                            Else
                                leave += 0
                            End If
                        End While

                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpLeaves", leave)

                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        ''=====weekly offday

                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOffdays", sunday)

                        '==============paid holiday
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Paid Holiday') and AttdLeveRsn in ('Present') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) '
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            overtm = Atd_Head_Rdr1(0)
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmppaidHoli", Atd_Head_Rdr1(0))
                        Else
                            overtm = 0
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmppaidHoli", Atd_Head_Rdr1(0))
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '===============monthdays
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpTotMnthday ", monthdays)

                        '===============joindtforabsent
                        Dim dt As Date
                        Dim days_abs As Double = 0
                        Atd_Head_Cmd1 = New SqlCommand("Select empjndt from FinactEmpMstr where Empid='" & (fetch_mainempid) & "' and EmpdelStatus='" & (1) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            dt = Atd_Head_Rdr1(0)
                            If dt.Month = mnth Then
                                If dt.Day <> 1 Then
                                    days_abs = abst + pres + holiday + sunday + leave
                                    days_abs = (monthdays - days_abs) + abst
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", days_abs)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "Joining Date on " & dt)
                                Else
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                                End If
                            Else
                                If pres = 0 And abst = 0 And leave = 0 Then
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", monthdays - holiday - sunday)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                                Else
                                    ' Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    'Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                                    Dim cnter As Integer = 0
                                    cnter = Date.DaysInMonth(yer_srch, mnth) '+
                                    Dim totdiff As Double = 0
                                    totdiff = cnter - pres - leave - sunday - holiday
                                    If abst + pres + leave + sunday + holiday = cnter Then
                                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    Else
                                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", totdiff)
                                    End If

                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")

                                End If

                            End If
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpFatherName", Atd_Head_Rdr(4))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpDept", Atd_Head_Rdr(5))
                        over_time()
                        If SEC <> 0 Then
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", hour1 & " hours " & " & " & SEC & " min")
                        Else
                            If hour1 <> 0 Then
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", hour1 & " hours ")
                            Else
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", "0")
                            End If
                        End If


                    End If
                End If
                srtlev = 0
                leave = 0
                tot_days = 0.0
                pres = 0
                abst = 0
                holi = 0
                overtm = 0
                week = 0
                hour1 = 0
                SEC = 0
                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpMnthyer", str)
                Atd_Head_Cmd2.ExecuteNonQuery()
                j += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Atd_Head_Rdr.HasRows = False Then
                Atd_Head_Rdr.Close()
                Atd_Head_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "Search All")

            End If
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try

    End Sub
    Private Sub fetchrdempwise()  '------------------------emp wise
        'to delete
        Try
            Atd_Head_Cmd = New SqlCommand("Finact_Emp_Sum_Mnth_Delete", FinActConn)
            Atd_Head_Cmd.CommandType = CommandType.StoredProcedure
            Atd_Head_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Atd_Head_Cmd = Nothing
        End Try

        hour1 = 0
        SEC = 0
        Dim i As Integer = 0
        fetch_mainempid = 0
        Dim j As Integer = 1
        cntsundays()
        Dim yer_srch As Integer = 0
        Dim leave As Double = 0
        Dim srtlev As Integer = 0
        yer_srch = Dtpick1.Value.Year
        Dim tot_days As Double = 0.0
        Dim abst As Integer = 0
        Dim pres As Double = 0
        Dim holi As Integer = 0
        Dim overtm As Integer = 0
        Dim week As Integer = 0
        Dim str As String = ""
        str = MonthName(Dtpick1.Value.Month) & "-" & Dtpick1.Value.Year
        Dim dtproc As Date
        Dim day1 As Integer
        day1 = Dtpick1.Value.Day
        Dim difday As Integer
        If day1 <> monthdays Then
            'difday = day1 - 1
            'dtproc = Dtpick1.Value.Date.AddDays(-difday)
            difday = monthdays - Dtpick1.Value.Day
            dtproc = Dtpick1.Value.Date.AddDays(difday)

        Else
            dtproc = Dtpick1.Value.Date
        End If
        Try
            Atd_Head_Cmd = New SqlCommand("Finact_EmpAttend_Selempwise", FinActConn)
            Atd_Head_Cmd.CommandType = CommandType.StoredProcedure
            Atd_Head_Cmd.Parameters.AddWithValue("@Employename", Combename.Text)
            Atd_Head_Cmd.Parameters.AddWithValue("@strtdt", dtproc.Date)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            Atd_Head_Rdr.Read()
            If Atd_Head_Rdr.IsDBNull(0) = False Then
                If Atd_Head_Rdr.HasRows = True Then

                    Atd_Head_Cmd2 = New SqlCommand("Finact_Emp_Sum_Mnth_Insert", FinActConn2)
                    Atd_Head_Cmd2.CommandType = CommandType.StoredProcedure
                    Atd_Head_Cmd2.Parameters.AddWithValue("@Empsrno", j)
                    Atd_Head_Cmd2.Parameters.AddWithValue("@Empname", Atd_Head_Rdr("empname"))
                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpConId", Atd_Head_Rdr("empid"))
                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpDesi", Atd_Head_Rdr("desiname"))
                    fetch_mainempid = Atd_Head_Rdr("empid")

                    '=================present
                    Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present','PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                    Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                    Atd_Head_Rdr1.Read()
                    If Atd_Head_Rdr1.HasRows = True Then
                        pres = Atd_Head_Rdr1(0)
                    Else
                        pres = 0
                    End If
                    Atd_Head_Rdr1.Close()
                    Atd_Head_Cmd1 = Nothing

                    'Atd_Head_Cmd1 = New SqlCommand("Select  AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                    'Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                    'While Atd_Head_Rdr1.Read()
                    '    If Atd_Head_Rdr1.HasRows = True Then
                    '        pres += 0.5
                    '    Else
                    '        pres += 0
                    '    End If
                    'End While
                    'Atd_Head_Rdr1.Close()
                    'Atd_Head_Cmd1 = Nothing

                    Atd_Head_Cmd2.Parameters.AddWithValue("@Emppresent", pres)

                    '==================absent
                    Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Absent') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                    Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                    Atd_Head_Rdr1.Read()
                    If Atd_Head_Rdr1.HasRows = True Then
                        abst = Atd_Head_Rdr1(0)
                    Else
                        abst = 0
                    End If
                    Atd_Head_Rdr1.Close()
                    Atd_Head_Cmd1 = Nothing

                    '==================holiday 
                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpHolidays", holiday)

                    '=================short leave
                    Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and AttdRepstatus in ('Short Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                    Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                    Atd_Head_Rdr1.Read()
                    If Atd_Head_Rdr1.HasRows = True Then
                        srtlev = Atd_Head_Rdr1(0)
                    Else
                        srtlev = 0
                    End If
                    Atd_Head_Rdr1.Close()
                    Atd_Head_Cmd1 = Nothing

                    Atd_Head_Cmd1 = New SqlCommand("Select srtlevid from Finact_Attd_srtlev where SrtlevEmpid='" & (fetch_mainempid) & "' and SrtLevType='" & ("Personal") & "' and month(SrtLevdate)='" & (mnth) & "' and year(SrtLevdate)='" & (yer_srch) & "'", FinActConn1)
                    Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                    While Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            srtlev += 1
                        Else
                            srtlev += 0
                        End If
                    End While
                    Atd_Head_Rdr1.Close()
                    Atd_Head_Cmd1 = Nothing
                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpSrtLeav", srtlev)

                    '=======================leave
                    Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Leave') and AttdRepstatus in ('Full Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                    Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                    Atd_Head_Rdr1.Read()
                    If Atd_Head_Rdr1.HasRows = True Then
                        leave = Atd_Head_Rdr1(0)
                    Else
                        leave = 0
                    End If
                    Atd_Head_Rdr1.Close()
                    Atd_Head_Cmd1 = Nothing

                    Atd_Head_Cmd1 = New SqlCommand("Select AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and AttdRepstatus in ('1st Half Day Leave','2nd Half Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                    Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                    While Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            leave += 0.5
                        Else
                            leave += 0
                        End If
                    End While
                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpLeaves", leave)
                    Atd_Head_Rdr1.Close()
                    Atd_Head_Cmd1 = Nothing

                    '==============weekly offday
                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOffdays", sunday)

                    '==============paid holiday
                    Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Paid Holiday') and AttdLeveRsn in ('Present') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) '
                    Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                    Atd_Head_Rdr1.Read()
                    If Atd_Head_Rdr1.HasRows = True Then
                        overtm = Atd_Head_Rdr1(0)
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmppaidHoli", Atd_Head_Rdr1(0))
                    Else
                        overtm = 0
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmppaidHoli", Atd_Head_Rdr1(0))
                    End If
                    Atd_Head_Rdr1.Close()
                    Atd_Head_Cmd1 = Nothing

                    '===============monthdays
                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpTotMnthday ", monthdays)

                    '===============joindtforabsent
                    Dim dt As Date
                    Dim days_abs As Double = 0
                    Atd_Head_Cmd1 = New SqlCommand("Select empjndt from FinactEmpMstr where Empid='" & (fetch_mainempid) & "' and EmpdelStatus='" & (1) & "'", FinActConn1)
                    Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                    Atd_Head_Rdr1.Read()
                    If Atd_Head_Rdr1.HasRows = True Then
                        dt = Atd_Head_Rdr1(0)
                        If dt.Month = mnth Then
                            If dt.Day <> 1 Then
                                days_abs = abst + pres + holiday + sunday + leave
                                days_abs = (monthdays - days_abs) + abst
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", days_abs)
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "Joining Date on " & dt)
                            Else
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                            End If
                        Else
                            If pres = 0 And abst = 0 And leave = 0 Then
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", monthdays - holiday - sunday)
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                            Else
                                ' Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                'Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")


                                Dim cnter As Integer = 0
                                cnter = Date.DaysInMonth(yer_srch, mnth) '+
                                Dim totdiff As Double = 0
                                totdiff = cnter - pres - leave - sunday - holiday
                                If abst + pres + leave + sunday + holiday = cnter Then
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                Else
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", totdiff)
                                End If

                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")

                            End If

                        End If
                    End If
                    Atd_Head_Rdr1.Close()
                    Atd_Head_Cmd1 = Nothing

                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpFatherName", Atd_Head_Rdr(3))
                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpDept", Atd_Head_Rdr(4))
                    over_time()
                    If SEC <> 0 Then
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", hour1 & " hours " & " & " & SEC & " min")
                    Else
                        If hour1 <> 0 Then
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", hour1 & " hours ")
                        Else
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", "0")
                        End If
                    End If

                    srtlev = 0
                    leave = 0
                    tot_days = 0.0
                    pres = 0
                    abst = 0
                    holi = 0
                    overtm = 0
                    week = 0
                    hour1 = 0
                    SEC = 0
                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpMnthyer", str)
                    Atd_Head_Cmd2.ExecuteNonQuery()
                    j += 1

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Atd_Head_Rdr.HasRows = False Then
                Atd_Head_Rdr.Close()
                Atd_Head_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "Search Section")
            End If
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try


    End Sub
    Private Sub fetchrd_deptwise()  '*******************dept wise
        'to delete
        Try
            Atd_Head_Cmd = New SqlCommand("Finact_Emp_Sum_Mnth_Delete", FinActConn)
            Atd_Head_Cmd.CommandType = CommandType.StoredProcedure
            Atd_Head_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Atd_Head_Cmd = Nothing
        End Try

        hour1 = 0
        SEC = 0
        Dim i As Integer = 0
        fetch_mainempid = 0
        Dim j As Integer = 1
        cntsundays()
        Dim yer_srch As Integer = 0
        Dim leave As Double = 0
        Dim srtlev As Integer = 0
        yer_srch = Dtpick1.Value.Year
        Dim tot_days As Double = 0.0
        Dim abst As Integer = 0
        Dim pres As Double = 0
        Dim holi As Integer = 0
        Dim overtm As Integer = 0
        Dim week As Integer = 0
        Dim str As String = ""
        Dim dtproc As Date
        Dim day1 As Integer
        day1 = Dtpick1.Value.Day
        Dim difday As Integer
        If day1 <> monthdays Then
            'difday = day1 - 1
            'dtproc = Dtpick1.Value.Date.AddDays(-difday)
            difday = monthdays - Dtpick1.Value.Day
            dtproc = Dtpick1.Value.Date.AddDays(difday)

        Else
            dtproc = Dtpick1.Value.Date
        End If

        str = MonthName(Dtpick1.Value.Month) & "-" & Dtpick1.Value.Year
        Try
            Atd_Head_Cmd = New SqlCommand("Finact_EmpAttend_Seldeptwise", FinActConn)
            Atd_Head_Cmd.CommandType = CommandType.StoredProcedure
            Atd_Head_Cmd.Parameters.AddWithValue("@Deptname", Combodeptnm.Text)
            Atd_Head_Cmd.Parameters.AddWithValue("@Strtdt", dtproc.Date)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            While Atd_Head_Rdr.Read()
                If Atd_Head_Rdr.IsDBNull(0) = False Then
                    If Atd_Head_Rdr.HasRows = True Then

                        Atd_Head_Cmd2 = New SqlCommand("Finact_Emp_Sum_Mnth_Insert", FinActConn2)
                        Atd_Head_Cmd2.CommandType = CommandType.StoredProcedure
                        Atd_Head_Cmd2.Parameters.AddWithValue("@Empsrno", j)
                        Atd_Head_Cmd2.Parameters.AddWithValue("@Empname", Atd_Head_Rdr("empname"))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpConId", Atd_Head_Rdr("empid"))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpDesi", Atd_Head_Rdr("desiname"))
                        fetch_mainempid = Atd_Head_Rdr("empid")

                        '=================present
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present','PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            pres = Atd_Head_Rdr1(0)
                        Else
                            pres = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        'Atd_Head_Cmd1 = New SqlCommand("Select  AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        'Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        'While Atd_Head_Rdr1.Read()
                        '    If Atd_Head_Rdr1.HasRows = True Then
                        '        pres += 0.5
                        '    Else
                        '        pres += 0
                        '    End If
                        'End While
                        'Atd_Head_Rdr1.Close()
                        'Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd2.Parameters.AddWithValue("@Emppresent", pres)
                        '================absent
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Absent') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            abst = Atd_Head_Rdr1(0)
                        Else
                            abst = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '=====holiday 
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpHolidays", holiday)

                        '==================short leave
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and AttdRepstatus in ('Short Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            srtlev = Atd_Head_Rdr1(0)
                        Else
                            srtlev = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd1 = New SqlCommand("Select srtlevid from Finact_Attd_srtlev where SrtlevEmpid='" & (fetch_mainempid) & "' and SrtLevType='" & ("Personal") & "' and month(SrtLevdate)='" & (mnth) & "' and year(SrtLevdate)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        While Atd_Head_Rdr1.Read()
                            If Atd_Head_Rdr1.HasRows = True Then
                                srtlev += 1
                            Else
                                srtlev += 0
                            End If
                        End While
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpSrtLeav", srtlev)

                        '===============leave
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Leave') and AttdRepstatus in ('Full Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            leave = Atd_Head_Rdr1(0)
                        Else
                            leave = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd1 = New SqlCommand("Select AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and AttdRepstatus in ('1st Half Day Leave','2nd Half Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        While Atd_Head_Rdr1.Read()
                            If Atd_Head_Rdr1.HasRows = True Then
                                leave += 0.5
                            Else
                                leave += 0
                            End If
                        End While

                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpLeaves", leave)

                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOffdays", sunday)

                        '==============paid holiday
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Paid Holiday') and AttdLeveRsn in ('Present') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) '
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            overtm = Atd_Head_Rdr1(0)
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmppaidHoli", Atd_Head_Rdr1(0))
                        Else
                            overtm = 0
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmppaidHoli", Atd_Head_Rdr1(0))
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '===============monthdays
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpTotMnthday ", monthdays)

                        '===============joindtforabsent
                        Dim dt As Date
                        Dim days_abs As Double = 0
                        Atd_Head_Cmd1 = New SqlCommand("Select empjndt from FinactEmpMstr where Empid='" & (fetch_mainempid) & "' and EmpdelStatus='" & (1) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            dt = Atd_Head_Rdr1(0)
                            If dt.Month = mnth Then
                                If dt.Day <> 1 Then
                                    days_abs = abst + pres + holiday + sunday + leave
                                    days_abs = (monthdays - days_abs) + abst
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", days_abs)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "Joining Date on " & dt)
                                Else
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                                End If
                            Else
                                If pres = 0 And abst = 0 And leave = 0 Then
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", monthdays - holiday - sunday)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                                Else
                                    'Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    'Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                                    Dim cnter As Integer = 0
                                    cnter = Date.DaysInMonth(yer_srch, mnth) '+
                                    Dim totdiff As Double = 0
                                    totdiff = cnter - pres - leave - sunday - holiday
                                    If abst + pres + leave + sunday + holiday = cnter Then
                                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    Else
                                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", totdiff)
                                    End If

                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")

                                End If

                            End If
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpFatherName", Atd_Head_Rdr(3))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpDept", Atd_Head_Rdr(4))
                        over_time()
                        If SEC <> 0 Then
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", hour1 & " hours " & " & " & SEC & " min")
                        Else
                            If hour1 <> 0 Then
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", hour1 & " hours ")
                            Else
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", "0")
                            End If
                        End If

                    End If
                End If
                srtlev = 0
                leave = 0
                tot_days = 0.0
                pres = 0
                abst = 0
                holi = 0
                overtm = 0
                week = 0
                hour1 = 0
                SEC = 0
                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpMnthyer", str)
                Atd_Head_Cmd2.ExecuteNonQuery()
                j += 1
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Atd_Head_Rdr.HasRows = False Then
                Atd_Head_Rdr.Close()
                Atd_Head_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "Search Section")
            End If
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try

    End Sub
    Private Sub fetchrd_rangewise()   '*******************range wise i.e acc to id's range
        'to delete
        Try
            Atd_Head_Cmd = New SqlCommand("Finact_Emp_Sum_Mnth_Delete", FinActConn)
            Atd_Head_Cmd.CommandType = CommandType.StoredProcedure
            Atd_Head_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Atd_Head_Cmd = Nothing
        End Try

        hour1 = 0
        SEC = 0
        Dim i As Integer = 0
        fetch_mainempid = 0
        Dim j As Integer = 1
        cntsundays()
        Maxselid = CInt(Combofromid.Text)
        Dim yer_srch As Integer = 0
        Dim leave As Double = 0
        Dim srtlev As Integer = 0
        yer_srch = Dtpick1.Value.Year
        Dim tot_days As Double = 0.0
        Dim abst As Integer = 0
        Dim pres As Double = 0
        Dim holi As Integer = 0
        Dim overtm As Integer = 0
        Dim week As Integer = 0
        Dim str As String = ""
        Dim dtproc As Date
        Dim day1 As Integer
        day1 = Dtpick1.Value.Day
        Dim difday As Integer
        If day1 <> monthdays Then
            'difday = day1 - 1
            'dtproc = Dtpick1.Value.Date.AddDays(-difday)
            difday = monthdays - Dtpick1.Value.Day
            dtproc = Dtpick1.Value.Date.AddDays(difday)

        Else
            dtproc = Dtpick1.Value.Date
        End If
        str = MonthName(Dtpick1.Value.Month) & "-" & Dtpick1.Value.Year
        Try
            Atd_Head_Cmd = New SqlCommand("Finact_EmpAttend_Selidwise", FinActConn)
            Atd_Head_Cmd.CommandType = CommandType.StoredProcedure
            Atd_Head_Cmd.Parameters.AddWithValue("@minid", Maxselid)
            Atd_Head_Cmd.Parameters.AddWithValue("@maxid", CInt(Combotoid.Text))
            Atd_Head_Cmd.Parameters.AddWithValue("@Strtdt", dtproc.Date)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            While Atd_Head_Rdr.Read()
                If Atd_Head_Rdr.IsDBNull(0) = False Then
                    If Atd_Head_Rdr.HasRows = True Then
                        Atd_Head_Cmd2 = New SqlCommand("Finact_Emp_Sum_Mnth_Insert", FinActConn2)
                        Atd_Head_Cmd2.CommandType = CommandType.StoredProcedure
                        Atd_Head_Cmd2.Parameters.AddWithValue("@Empsrno", j)
                        Atd_Head_Cmd2.Parameters.AddWithValue("@Empname", Atd_Head_Rdr("empname"))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpConId", Atd_Head_Rdr("empid"))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpDesi", Atd_Head_Rdr("desiname"))
                        fetch_mainempid = Atd_Head_Rdr("empid")

                        '=================present
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present','PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            pres = Atd_Head_Rdr1(0)
                        Else
                            pres = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        'Atd_Head_Cmd1 = New SqlCommand("Select  AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        'Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        'While Atd_Head_Rdr1.Read()
                        '    If Atd_Head_Rdr1.HasRows = True Then
                        '        pres += 0.5
                        '    Else
                        '        pres += 0
                        '    End If
                        'End While
                        'Atd_Head_Rdr1.Close()
                        'Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd2.Parameters.AddWithValue("@Emppresent", pres)

                        '===============absent
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Absent') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            abst = Atd_Head_Rdr1(0)
                        Else
                            abst = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '==============holiday 
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpHolidays", holiday)

                        '=============short leave
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and AttdRepstatus in ('Short Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            srtlev = Atd_Head_Rdr1(0)
                        Else
                            srtlev = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd1 = New SqlCommand("Select srtlevid from Finact_Attd_srtlev where SrtlevEmpid='" & (fetch_mainempid) & "' and SrtLevType='" & ("Personal") & "' and month(SrtLevdate)='" & (mnth) & "' and year(SrtLevdate)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        While Atd_Head_Rdr1.Read()
                            If Atd_Head_Rdr1.HasRows = True Then
                                srtlev += 1
                            Else
                                srtlev += 0
                            End If
                        End While
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpSrtLeav", srtlev)
                        '==============leave
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Leave') and AttdRepstatus in ('Full Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            leave = Atd_Head_Rdr1(0)
                        Else
                            leave = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd1 = New SqlCommand("Select AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and AttdRepstatus in ('1st Half Day Leave','2nd Half Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        While Atd_Head_Rdr1.Read()
                            If Atd_Head_Rdr1.HasRows = True Then
                                leave += 0.5
                            Else
                                leave += 0
                            End If
                        End While
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpLeaves", leave)
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '===========weekly offday
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOffdays", sunday)

                        '==============paid holiday
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Paid Holiday') and AttdLeveRsn in ('Present') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) '
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            overtm = Atd_Head_Rdr1(0)
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmppaidHoli", Atd_Head_Rdr1(0))
                        Else
                            overtm = 0
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmppaidHoli", Atd_Head_Rdr1(0))
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '===============monthdays
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpTotMnthday ", monthdays)

                        '===============joindtforabsent
                        Dim dt As Date
                        Dim days_abs As Double = 0
                        Atd_Head_Cmd1 = New SqlCommand("Select empjndt from FinactEmpMstr where Empid='" & (fetch_mainempid) & "' and EmpdelStatus='" & (1) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            dt = Atd_Head_Rdr1(0)
                            If dt.Month = mnth Then
                                If dt.Day <> 1 Then
                                    days_abs = abst + pres + holiday + sunday + leave
                                    days_abs = (monthdays - days_abs) + abst
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", days_abs)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "Joining Date on " & dt)
                                Else
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                                End If
                            Else
                                If pres = 0 And abst = 0 And leave = 0 Then
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", monthdays - holiday - sunday)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                                Else
                                    ' Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    'Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")


                                    Dim cnter As Integer = 0
                                    cnter = Date.DaysInMonth(yer_srch, mnth) '+
                                    Dim totdiff As Double = 0
                                    totdiff = cnter - pres - leave - sunday - holiday
                                    If abst + pres + leave + sunday + holiday = cnter Then
                                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    Else
                                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", totdiff)
                                    End If

                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")

                                End If

                            End If
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpFatherName", Atd_Head_Rdr(3))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpDept", Atd_Head_Rdr(4))
                        over_time()
                        If SEC <> 0 Then
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", hour1 & " hours " & " & " & SEC & " min")
                        Else
                            If hour1 <> 0 Then
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", hour1 & " hours ")
                            Else
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", "0")
                            End If
                        End If

                    End If
                End If
                srtlev = 0
                leave = 0
                tot_days = 0.0
                pres = 0
                abst = 0
                holi = 0
                overtm = 0
                week = 0
                hour1 = 0
                SEC = 0
                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpMnthyer", str)
                Atd_Head_Cmd2.ExecuteNonQuery()
                j += 1
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Atd_Head_Rdr.HasRows = False Then
                Atd_Head_Rdr.Close()
                Atd_Head_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "range Section")

            End If
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try
    End Sub
    Private Sub Combename_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combename.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Combename.Text <> "" Then
                fetchrdempwise()
                BtnAttndVew.Focus()
            End If
        End If
    End Sub
    Private Sub Combofromid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combofromid.GotFocus

        Combofromid.Items.Clear()
        fetch_Empid()
        If Combofromid.Items.Count > 0 Then
            If Combofromid.SelectedIndex = -1 Then
                Combofromid.SelectedIndex = 0
            End If
            Combofromid.DroppedDown = True
        End If
    End Sub
    Private Sub Combofromid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combofromid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Combofromid_Leave(sender, e)
            Combotoid.Focus()
        End If
    End Sub
    Private Sub Combofromid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combofromid.Leave
        If Combofromid.Text <> "" Then
            Maxselid = CInt(Combofromid.Text)
        End If
    End Sub
    Private Sub Combotoid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combotoid.GotFocus
        Combotoid.Items.Clear()
        fetch_Empminid()
        If Combotoid.Items.Count > 0 Then
            If Combotoid.SelectedIndex = -1 Then
                Combotoid.SelectedIndex = 0
            End If
            Combotoid.DroppedDown = True
        End If
    End Sub

    Private Sub Combotoid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combotoid.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' DataGridView.Visible = True
            fetchrd_rangewise()
            BtnAttndVew.Focus()
        End If
    End Sub
    Private Sub Combodeptnm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combodeptnm.GotFocus
        Lbldesi.Visible = False
        Rb1.Checked = True
        Combdesi.Visible = False
        Combodeptnm.Items.Clear()
        fetch_deptname()
        If Combodeptnm.Items.Count > 0 Then
            If Combodeptnm.SelectedIndex = -1 Then
                Combodeptnm.SelectedIndex = 0
            End If
            Combodeptnm.DroppedDown = True
        End If

    End Sub

    Private Sub Combodeptnm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combodeptnm.KeyDown
        Combcatgry.DroppedDown = False
        If e.KeyCode = Keys.Enter Then
            lbldeptcriteria.Visible = True
            Panel1.Visible = True
            fetchrd_deptwise()
            BtnAttndVew.Focus()

        End If
    End Sub
    Private Sub Rb2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rb2.CheckedChanged
        If Rb2.Checked = True Then
            Lbldesi.Visible = True
            Combdesi.Visible = True
            Combdesi.Focus()
        End If
    End Sub
    Private Sub fetrd_desiwise() '---------------------------*******************deisgnation wise
        'to delete
        Try
            Atd_Head_Cmd = New SqlCommand("Finact_Emp_Sum_Mnth_Delete", FinActConn)
            Atd_Head_Cmd.CommandType = CommandType.StoredProcedure
            Atd_Head_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Atd_Head_Cmd = Nothing
        End Try

        hour1 = 0
        SEC = 0
        Dim i As Integer = 0
        fetch_mainempid = 0
        Dim j As Integer = 1
        cntsundays()
        Dim yer_srch As Integer = 0
        Dim leave As Double = 0
        Dim srtlev As Integer = 0
        yer_srch = Dtpick1.Value.Year
        Dim tot_days As Double = 0.0
        Dim pres As Double = 0
        Dim abst As Integer = 0
        Dim holi As Integer = 0
        Dim overtm As Integer = 0
        Dim week As Integer = 0
        Dim str As String = ""
        str = MonthName(Dtpick1.Value.Month) & "-" & Dtpick1.Value.Year
        Dim dtproc As Date
        Dim day1 As Integer
        day1 = Dtpick1.Value.Day
        Dim difday As Integer
        If day1 <> monthdays Then
            'difday = day1 - 1
            'dtproc = Dtpick1.Value.Date.AddDays(-difday)
            difday = monthdays - Dtpick1.Value.Day
            dtproc = Dtpick1.Value.Date.AddDays(difday)

        Else
            dtproc = Dtpick1.Value.Date
        End If
        str = MonthName(Dtpick1.Value.Month) & "-" & Dtpick1.Value.Year
        Try
            Atd_Head_Cmd = New SqlCommand("Select empname,Empid,desiname,deptname,empfather from finactEmpMstr inner join   Finactdept on deptid=empdeptid inner join   Finactdesi on desiid=empdesiid   inner join  finactEmpinfo on empconcrnid=empid where  finactEmpMstr.empdelstatus=1 and Finactdesi.desiname='" & (Combdesi.Text) & "' and Finactdept.deptname='" & (Combodeptnm.Text) & "' and  finactEmpMstr.empjndt<='" & (dtproc.Date) & "' order by finactempmstr.empname", FinActConn)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            While Atd_Head_Rdr.Read()
                If Atd_Head_Rdr.IsDBNull(0) = False Then
                    If Atd_Head_Rdr.HasRows = True Then

                        Atd_Head_Cmd2 = New SqlCommand("Finact_Emp_Sum_Mnth_Insert", FinActConn2)
                        Atd_Head_Cmd2.CommandType = CommandType.StoredProcedure
                        Atd_Head_Cmd2.Parameters.AddWithValue("@Empsrno", j)
                        Atd_Head_Cmd2.Parameters.AddWithValue("@Empname", Atd_Head_Rdr("empname"))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpConId", Atd_Head_Rdr("empid"))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpDesi", Atd_Head_Rdr("desiname"))
                        fetch_mainempid = Atd_Head_Rdr("empid")

                        '=================present
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present','PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            pres = Atd_Head_Rdr1(0)
                        Else
                            pres = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        'Atd_Head_Cmd1 = New SqlCommand("Select  AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        'Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        'While Atd_Head_Rdr1.Read()
                        '    If Atd_Head_Rdr1.HasRows = True Then
                        '        pres += 0.5
                        '    Else
                        '        pres += 0
                        '    End If
                        'End While
                        'Atd_Head_Rdr1.Close()
                        'Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd2.Parameters.AddWithValue("@Emppresent", pres)

                        '==============absent
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Absent') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            abst = Atd_Head_Rdr1(0)
                        Else
                            abst = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '==============holiday 
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpHolidays", holiday)


                        '==============short leave
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and AttdRepstatus in ('Short Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            srtlev = Atd_Head_Rdr1(0)
                        Else
                            srtlev = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd1 = New SqlCommand("Select srtlevid from Finact_Attd_srtlev where SrtlevEmpid='" & (fetch_mainempid) & "' and SrtLevType='" & ("Personal") & "' and month(SrtLevdate)='" & (mnth) & "' and year(SrtLevdate)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        While Atd_Head_Rdr1.Read()
                            If Atd_Head_Rdr1.HasRows = True Then
                                srtlev += 1
                            Else
                                srtlev += 0
                            End If
                        End While
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpSrtLeav", srtlev)

                        '=================leave
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Leave') and AttdRepstatus in ('Full Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            leave = Atd_Head_Rdr1(0)
                        Else
                            leave = 0
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        Atd_Head_Cmd1 = New SqlCommand("Select AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and AttdRepstatus in ('1st Half Day Leave','2nd Half Day Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        While Atd_Head_Rdr1.Read()
                            If Atd_Head_Rdr1.HasRows = True Then
                                leave += 0.5
                            Else
                                leave += 0
                            End If
                        End While
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpLeaves", leave)
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '==============weekly offday
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOffdays", sunday)

                        '==============paid holiday
                        Atd_Head_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Paid Holiday') and AttdLeveRsn in ('Present') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) '
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            overtm = Atd_Head_Rdr1(0)
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmppaidHoli", Atd_Head_Rdr1(0))
                        Else
                            overtm = 0
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmppaidHoli", Atd_Head_Rdr1(0))
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing

                        '===============monthdays
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpTotMnthday ", monthdays)

                        '===============joindtforabsent
                        Dim dt As Date
                        Dim days_abs As Double = 0
                        Atd_Head_Cmd1 = New SqlCommand("Select empjndt from FinactEmpMstr where Empid='" & (fetch_mainempid) & "' and EmpdelStatus='" & (1) & "'", FinActConn1)
                        Atd_Head_Rdr1 = Atd_Head_Cmd1.ExecuteReader
                        Atd_Head_Rdr1.Read()
                        If Atd_Head_Rdr1.HasRows = True Then
                            dt = Atd_Head_Rdr1(0)
                            If dt.Month = mnth Then
                                If dt.Day <> 1 Then
                                    days_abs = abst + pres + holiday + sunday + leave
                                    days_abs = (monthdays - days_abs) + abst
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", days_abs)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "Joining Date on " & dt)
                                Else
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                                End If
                            Else
                                If pres = 0 And abst = 0 And leave = 0 Then
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", monthdays - holiday - sunday)
                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")
                                Else
                                    ' Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    'Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")

                                    Dim cnter As Integer = 0
                                    cnter = Date.DaysInMonth(yer_srch, mnth) '+
                                    Dim totdiff As Double = 0
                                    totdiff = cnter - pres - leave - sunday - holiday
                                    If abst + pres + leave + sunday + holiday = cnter Then
                                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", abst)
                                    Else
                                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpAbsent", totdiff)
                                    End If

                                    Atd_Head_Cmd2.Parameters.AddWithValue("@EmpRemarks ", "")

                                End If

                            End If
                        End If
                        Atd_Head_Rdr1.Close()
                        Atd_Head_Cmd1 = Nothing


                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpFatherName", Atd_Head_Rdr(3))
                        Atd_Head_Cmd2.Parameters.AddWithValue("@EmpDept", Atd_Head_Rdr(4))
                        over_time()

                        If SEC <> 0 Then
                            Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", hour1 & " hours " & " & " & SEC & " min")
                        Else
                            If hour1 <> 0 Then
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", hour1 & " hours ")
                            Else
                                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpOvertm", "0")
                            End If
                        End If


                    End If
                End If
                srtlev = 0
                leave = 0
                tot_days = 0.0
                pres = 0
                abst = 0
                holi = 0
                overtm = 0
                week = 0
                hour1 = 0
                SEC = 0
                Atd_Head_Cmd2.Parameters.AddWithValue("@EmpMnthyer", str)
                Atd_Head_Cmd2.ExecuteNonQuery()
                j += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Atd_Head_Rdr.HasRows = False Then
                Atd_Head_Rdr.Close()
                Atd_Head_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "Search Section")

            End If

            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try

    End Sub
    Private Sub Combdesi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combdesi.GotFocus
        Combdesi.Items.Clear()
        fetch_desiname()
        If Combdesi.Items.Count > 0 Then
            If Combdesi.SelectedIndex = -1 Then
                Combdesi.SelectedIndex = 0
            End If
            Combdesi.DroppedDown = True
        End If
    End Sub

    Private Sub fetch_desiname()
        Try
            Atd_Head_Cmd = New SqlCommand("Select desiname from finactdesi where desidelstatus= 1 and desitype='" & ("Desi") & "'order by desiname", FinActConn)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            While Atd_Head_Rdr.Read()
                If Atd_Head_Rdr.IsDBNull(0) = False Then
                    If Atd_Head_Rdr.HasRows = True Then
                        Combdesi.Items.Add(Atd_Head_Rdr(0))
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Atd_Head_Rdr.HasRows = False Then
                Atd_Head_Rdr.Close()
                Atd_Head_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "Department section")
            End If
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try
    End Sub

    Private Sub Combdesi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        fetrd_desiwise()
    End Sub

    Private Sub Rb1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rb1.Click
        If Rb1.Checked = True Then
            Lbldesi.Visible = False
            Combdesi.Visible = False
            fetchrd_deptwise()
        End If

    End Sub

    'Private Sub DataGridView_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dtagrdflag = False
    'End Sub

    Private Sub fetch_Attd_Date()
        Dim i As Integer = 0
        Dim minmondt As Date
        Dim maxmondt As Date
        Try
            Atd_Head_Cmd = New SqlCommand("Select min(Attddt) from finact_Attd ", FinActConn)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            Atd_Head_Rdr.Read()
            If Atd_Head_Rdr.IsDBNull(0) = False Then
                If Atd_Head_Rdr.HasRows = True Then
                    minmondt = Atd_Head_Rdr(0)
                    minyear = minmondt.Year
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try
        Try
            Atd_Head_Cmd = New SqlCommand("Select max(Attddt) from finact_Attd ", FinActConn)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            Atd_Head_Rdr.Read()
            If Atd_Head_Rdr.IsDBNull(0) = False Then
                If Atd_Head_Rdr.HasRows = True Then
                    maxmondt = Atd_Head_Rdr(0)
                    maxyear = maxmondt.Year
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try

    End Sub
    Private Sub fetch_mon()
        Dim maxmondt As Date
        Dim minmondt As Date
        Try
            Atd_Head_Cmd = New SqlCommand("Select max(Attddt) from finact_Attd WHERE year(Attddt)='" & (Dtpick1.Value.Year) & "'", FinActConn)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            Atd_Head_Rdr.Read()
            If Atd_Head_Rdr.IsDBNull(0) = False Then
                If Atd_Head_Rdr.HasRows = True Then
                    maxmondt = Atd_Head_Rdr(0)
                    maxmon = maxmondt.Month
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try

        Try
            Atd_Head_Cmd = New SqlCommand("Select min(Attddt) from finact_Attd WHERE year(Attddt)='" & (Dtpick1.Value.Year) & "'", FinActConn)
            Atd_Head_Rdr = Atd_Head_Cmd.ExecuteReader
            Atd_Head_Rdr.Read()
            If Atd_Head_Rdr.IsDBNull(0) = False Then
                If Atd_Head_Rdr.HasRows = True Then
                    minmondt = Atd_Head_Rdr(0)
                    minmon = minmondt.Month
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Atd_Head_Rdr.Close()
            Atd_Head_Cmd = Nothing
        End Try

    End Sub
    Private Sub clr() '==========to set the form similar to its load position
        Me.Height = 180
        lbldeptcriteria.Visible = False
        Panel1.Visible = False
        Lbldesi.Visible = False
        Combdesi.Visible = False
        Lblempnm.Visible = False
        Combename.Visible = False
        Lbltoid.Visible = False
        Lbldept.Visible = False
        Combodeptnm.Visible = False
        Lblempid.Visible = False
        Combotoid.Visible = False
        Combofromid.Visible = False

    End Sub

    Private Sub Dtpick1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpick1.GotFocus
        lavflag = False
    End Sub


    Private Sub Dtpick1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpick1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Combcatgry.Focus()
        End If
    End Sub

    Private Sub Dtpick1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpick1.Leave
        If lavflag = False Then
            fetch_Attd_Date()
            fetch_mon()
            Dim yer As Integer = 0
            Dim mnth As Integer = 0
            yer = Dtpick1.Value.Year
            mnth = Dtpick1.Value.Month
            If yer > maxyear Then
                lavflag = True
                clr()
                MsgBox("System has found no marked Attendance for this year ", MsgBoxStyle.Information, "Alert")
                Dtpick1.Focus()
                Exit Sub
            ElseIf mnth > maxmon Then
                lavflag = True
                clr()
                MsgBox("System has found no marked Attendance for this month ", MsgBoxStyle.Information, "Alert")
                Dtpick1.Focus()
                Exit Sub
            ElseIf yer < minyear Then
                lavflag = True
                clr()
                MsgBox("System has found no marked Attendance for this year ", MsgBoxStyle.Information, "Alert")
                Dtpick1.Focus()
                Exit Sub
            ElseIf mnth < minmon Then
                lavflag = True
                clr()
                MsgBox("System has found no marked Attendance for this month ", MsgBoxStyle.Information, "Alert")
                Dtpick1.Focus()
                Exit Sub
            End If

        End If


    End Sub

    Private Sub CoprofileParamsEmpInfo()

        Dim ParmVal1 As ParameterValues = New ParameterValues()
        Dim DisVal1 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal1.Value = 1
        ParmVal1.Add(DisVal1)

        Dim ParmVal2 As ParameterValues = New ParameterValues()
        Dim DisVal2 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal2.Value = 1
        ParmVal2.Add(DisVal2)

        Dim ParmVal3 As ParameterValues = New ParameterValues()
        Dim DisVal3 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal3.Value = 1
        ParmVal3.Add(DisVal3)

        Dim ParmVal4 As ParameterValues = New ParameterValues()
        Dim DisVal4 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal4.Value = 1
        ParmVal4.Add(DisVal4)

        Dim ParmVal5 As ParameterValues = New ParameterValues()
        Dim DisVal5 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal5.Value = 1
        ParmVal5.Add(DisVal5)
        Dim nparm As New OdbcParameter("@@N", Odbc.OdbcType.VarBinary, 200)
        Dim aparm As New OdbcParameter("@@a", Odbc.OdbcType.VarChar, 100)
        Dim aparm1 As New OdbcParameter("@@a1", Odbc.OdbcType.VarChar, 100)
        Dim conparm As New OdbcParameter("@@coN", Odbc.OdbcType.VarChar, 100)
        Dim con2parm As New OdbcParameter("@@con2", Odbc.OdbcType.VarChar, 100)
        Dim con3parm As New OdbcParameter("@@con3", Odbc.OdbcType.VarChar, 100)
        Dim pinparm As New OdbcParameter("@@pin", Odbc.OdbcType.VarChar, 100)
        Dim ctyparm As New OdbcParameter("@@cty", Odbc.OdbcType.VarChar, 100)

        Dim DcrypConame As New EnCryp_DeCryp_String
        Try
            If TellRptstatus = False Then
                Fetch_InfoCrRptEp()
            End If
            ' Odbccon1 = New SqlConnection("Driver={SQL Native Client};Server=.;Database=hrprdata08;Uid=sa;Pwd=sa;")
            'Odbccon1.Open()
            OdbcCmd1 = New OdbcCommand("exec Tempcncrpt nparm,aparm,aparm1,conparm,conparm2,conparm3,pinparm,ctyparm ", FinactOdbcCon1)
            OdbcCmd1.CommandType = CommandType.StoredProcedure '
            Odbcrdr1 = OdbcCmd1.ExecuteReader
            While Odbcrdr1.Read()
                Dim co As Object = DcrypConame.Decrypt(Odbcrdr1("col1"))
                Dim co1 As Object = Odbcrdr1(1)
                Dim co2 As Object = Odbcrdr1(5) & "-" & Odbcrdr1(6)
                Dim co3 As Object = Odbcrdr1(2)
                ParmVal1.AddValue(co)
                ParmVal2.AddValue(co1)
                ParmVal3.AddValue(co2)
                ParmVal4.AddValue(co3)
                Dim Rptstr As String = ""
                'If Trim(CmbxSelcat.Text) = "All" Then
                Rptstr = ("Attendance of Employees/Workers for the period of").ToUpper
                'End If
                ParmVal5.AddValue(Rptstr)
                CrRptAttnd.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptAttnd.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptAttnd.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptAttnd.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
                CrRptAttnd.DataDefinition.ParameterFields("Rpttype").ApplyCurrentValues(ParmVal5)
            End While

            CrVewAttnd.ReportSource = CrRptAttnd
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            'Odbccon1.Close()
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()

        End Try

    End Sub
    Private Sub Fetch_InfoCrRptEp()
        Try
            Atd_Head_Cmd = New SqlCommand("select * from Finact_Emp_Sumary_Mnthwise order by empname,empconid", FinActConn)

            Dim dssal As New DataSet(Atd_Head_Cmd.CommandText)
            Atd_Head_Adptr = New SqlDataAdapter(Atd_Head_Cmd)
            Atd_Head_Adptr.Fill(dssal)

            CrRptAttnd.SetDataSource(dssal.Tables(0))

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Atd_Head_Cmd = Nothing
        End Try
    End Sub

    Private Sub BtnAttndVew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttndVew.Click
        Me.CrVewAttnd.Visible = True
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height - 50
        TellRptstatus = False
        CoprofileParamsEmpInfo()
        'Me.CrVewAttnd.Location = New System.Drawing.Point(7, 20)
        ' Me.CrVewAttnd.Height = Me.Height - 20

    End Sub


    Private Sub Combcatgry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combcatgry.SelectedIndexChanged

    End Sub

    Private Sub Combdesi_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combdesi.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Combdesi.Text.Trim <> "" Then
                BtnAttndVew.Focus()
            End If
        End If
    End Sub
End Class
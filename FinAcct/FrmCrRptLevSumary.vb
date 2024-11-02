Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmCrRptLevSumary
    Inherits System.Windows.Forms.Form
    Dim Leav_Cmd As SqlCommand
    Dim Leav_Rdr As SqlDataReader
    Dim Leav_Cmd1 As SqlCommand
    Dim Leav_Rdr1 As SqlDataReader
    Dim Leav_Cmd2 As SqlCommand
    Dim Leav_Rdr2 As SqlDataReader
    Dim Strtminyear As Date
    Dim dt2minyear As Date
    Dim fetch_mainempid As Integer
    Dim monthdays As Integer = 0
    Dim sunday As Integer = 0
    Dim holiday As Integer = 0
    Dim mnth As Integer = 0
    Dim yer_srch As Integer = 0
    Dim indx As Integer = 0
    Dim yer_flag As Boolean = False
    Dim fetch_conempid As Integer = 0
    Dim join_dt As Date
    Dim minmon As Integer = 0
    Dim presntdayinter As Double = 0.0
    Dim balernlev As Double = 0.0
    Dim TellRptstatus As Boolean
    Dim CrRptLWW As New CrRptLwwRegstr
    Dim OdbcCmd1 As OdbcCommand
    Dim Odbcrdr1 As OdbcDataReader
    Dim EsiF6_DtaTble As DataTable
    Dim IndxEsi As Integer
    Dim EsiAmt As String
    Dim EsiF6_Cmd As SqlCommand
    Dim EsiF6_Adptr As SqlDataAdapter
 

    Private Sub Combcatgry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combcatgry.GotFocus

        Combcatgry.DroppedDown = True

    End Sub

    Private Sub Combcatgry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combcatgry.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Combcatgry.SelectedIndex = 0 Then
                Lblempid.Visible = False
                Combofromid.Visible = False
                Lblempnm.Visible = True
                Combename.Visible = True
                Combename.Focus()
            ElseIf Combcatgry.SelectedIndex = 1 Then
                Lblempid.Visible = True
                Lblempnm.Visible = False
                Combename.Visible = False
                Combofromid.Visible = True
                Combofromid.Focus()
            End If
        End If

    End Sub
    Private Sub FrmLeaveSumary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Me.Left = 0
            Me.Top = 0
            Me.Width = 1025

            Me.Height = 149

            fetch_Costrtdate()
            Dtpick1.MinDate = Strtminyear
            Combcatgry.Text = Combcatgry.Items(0)
            Dtpick1.Focus()
            TellRptstatus = True
            CoprofileParamsLww()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub fetch_Costrtdate() '-------------to fetch srtdate,year of company and add items in year combo
        Try
            Leav_Cmd = New SqlCommand("Select Costrtdt from finactcogatemstr ", FinActConn)
            Leav_Rdr = Leav_Cmd.ExecuteReader
            Leav_Rdr.Read()
            If Leav_Rdr.IsDBNull(0) = False Then
                If Leav_Rdr.HasRows = True Then
                    Strtminyear = Format(Leav_Rdr(0), "MMMM/yyyy")
                Else
                    Strtminyear = Format("1 / 1 / 1900", "MMMM/yyyy")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Leav_Rdr.Close()
            Leav_Cmd = Nothing
        End Try

    End Sub

    Private Sub fetch_Empname() '-----------------------fetch employee names

        Try
            Leav_Cmd = New SqlCommand("Select empname from finactEmpMstr where empdelstatus= 1 order by empname", FinActConn)
            Leav_Rdr = Leav_Cmd.ExecuteReader
            While Leav_Rdr.Read()
                If Leav_Rdr.IsDBNull(0) = False Then
                    If Leav_Rdr.HasRows = True Then
                        Combename.Items.Add(Leav_Rdr(0))
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Leav_Rdr.Close()
            Leav_Cmd = Nothing
        End Try

    End Sub
    Private Sub Dtpick1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpick1.KeyDown

        If e.KeyCode = Keys.Enter Then
            Dim mnth As Integer = 0
            Dim dt2mnth As Date
            dt2mnth = Dtpick1.Value.AddMonths(11)
            Dtpick2.Value = dt2mnth
            Combcatgry.Focus()
        End If

    End Sub
    Private Sub fetch_Empid() '----------------------------to fetch id's of employees

        Try
            Leav_Cmd = New SqlCommand("Select empid from finactEmpMstr where empdelstatus= 1 order by empid", FinActConn)
            Leav_Rdr = Leav_Cmd.ExecuteReader
            While Leav_Rdr.Read()
                If Leav_Rdr.IsDBNull(0) = False Then
                    If Leav_Rdr.HasRows = True Then
                        Combofromid.Items.Add(Leav_Rdr(0))
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Leav_Rdr.Close()
            Leav_Cmd = Nothing
        End Try

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
    Private Sub fetch_res()
        'to delete
        Try
            Leav_Cmd = New SqlCommand("Finact_leave_sumary_Delete", FinActConn)
            Leav_Cmd.CommandType = CommandType.StoredProcedure
            Leav_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Leav_Cmd = Nothing
        End Try
        Dim ern As Integer = 0
        '================leave
        Dim str_pres As Integer = 0
        Dim pres As Double = 0.0
        mnth = Dtpick1.Value.Month '-----------
        Dim str As String = ""
        yer_srch = Dtpick1.Value.Year '----------
        Dim sicklev As Double = 0
        Dim casuallev As Double = 0
        Dim materlev As Double = 0
        Dim srtlev As Integer = 0
        'Dim i As Integer = 0
        fetch_mainempid = 0
        Dim j As Integer = 1
        Dim totlev As Double = 0
        Try
            While j <= 12 '12
                Leav_Cmd = New SqlCommand("Select empid from finactEmpMstr where empdelstatus= 1 and Empname='" & (Combename.Text) & "'", FinActConn)
                Leav_Rdr = Leav_Cmd.ExecuteReader
                Leav_Rdr.Read()
                If Leav_Rdr.IsDBNull(0) = False Then
                    If Leav_Rdr.HasRows = True Then
                        str = ""
                        sicklev = 0
                        str = MonthName(mnth) & "-" & yer_srch
                        Leav_Cmd2 = New SqlCommand("Finact_leave_sumary_insert", FinActConn2)
                        Leav_Cmd2.CommandType = CommandType.StoredProcedure
                        Leav_Cmd2.Parameters.AddWithValue("@EmpwagePrd", str)
                        fetch_mainempid = Leav_Rdr("empid")

                        '=================present
                        Leav_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                        Leav_Rdr1.Read()
                        If Leav_Rdr1.HasRows = True Then
                            pres = Leav_Rdr1(0)
                        Else
                            pres = 0
                        End If
                        Leav_Rdr1.Close()
                        Leav_Cmd1 = Nothing

                        Leav_Cmd1 = New SqlCommand("Select  AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                        Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                        While Leav_Rdr1.Read()
                            If Leav_Rdr1.HasRows = True Then
                                pres += 0.5
                            Else
                                pres += 0
                            End If
                        End While
                        Leav_Rdr1.Close()
                        Leav_Cmd1 = Nothing
                        Leav_Cmd2.Parameters.AddWithValue("@Empworkdays", pres)

                        '========offlaydays
                        Leav_Cmd2.Parameters.AddWithValue("@Emplayoffday", 0) '---

                        ' mater 
                        Leav_Cmd1 = New SqlCommand("Select AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and  AttdRepstatus in ('Maternity Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) ' and attdleversn='" & ("Maternity Leave") & "'
                        Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                        While Leav_Rdr1.Read
                            If Leav_Rdr1.HasRows = True Then
                                materlev += 1
                            Else
                                materlev += 0
                            End If
                        End While
                        Leav_Rdr1.Close()
                        Leav_Cmd1 = Nothing
                        Leav_Cmd2.Parameters.AddWithValue("@Empmatrntyleav", materlev)

                        'enjoy(earn) leave

                        Dim ernlev As Double = 0.0
                        Leav_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and   AttdStatus in('Leave') and AttdRepstatus in ('Full Day ErnLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) ' and attdleversn='" & ("Maternity Leave") & "'
                        Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                        Leav_Rdr1.Read()
                        If Leav_Rdr1.HasRows = True Then
                            ernlev = Leav_Rdr1(0)
                        Else
                            ernlev = 0
                        End If
                        'End While
                        Leav_Rdr1.Close()
                        Leav_Cmd1 = Nothing


                        Leav_Cmd1 = New SqlCommand("Select AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and   AttdStatus in('PresntCumLev') and AttdRepstatus in ('1st Half Day Ernlev','2nd Half Day ErnLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) ' and attdleversn='" & ("Maternity Leave") & "'
                        Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                        While Leav_Rdr1.Read
                            If Leav_Rdr1.HasRows = True Then
                                ernlev += 0.5
                            Else
                                ernlev += 0
                            End If
                        End While
                        Leav_Rdr1.Close()
                        Leav_Cmd1 = Nothing

                        Leav_Cmd2.Parameters.AddWithValue("@Empenjoyleav", ernlev) '----
                        totlev = pres + materlev + ernlev '---enjoylev
                        Leav_Cmd2.Parameters.AddWithValue("@Emptot", totlev)
                        ern = 0
                        If pres >= 20 Then
                            str_pres += pres - 20
                            If str_pres >= 20 Then
                                ern = 2
                                Leav_Cmd2.Parameters.AddWithValue("@Empearnleav", 2)
                                Leav_Cmd2.Parameters.AddWithValue("@Empcrdleavbal ", 2)
                                str_pres = str_pres - 20
                            Else
                                ern = 1
                                Leav_Cmd2.Parameters.AddWithValue("@Empearnleav", 1)
                                Leav_Cmd2.Parameters.AddWithValue("@Empcrdleavbal ", 1)
                            End If
                        Else
                            ern = 0
                            Leav_Cmd2.Parameters.AddWithValue("@Empearnleav", 0)
                            Leav_Cmd2.Parameters.AddWithValue("@Empcrdleavbal ", 0)
                        End If

                        Leav_Cmd2.Parameters.AddWithValue("@Empsection", "NO")
                        Leav_Cmd2.Parameters.AddWithValue("@Emplevenjoyfrmto ", "")

                    

                        Leav_Cmd2.Parameters.AddWithValue("@Empcshequi ", "0")


                        fetch_conempid = fetch_mainempid
                        fet_emp_dtjoin()
                        If join_dt.Month >= mnth And join_dt.Year >= yer_srch Then
                            Leav_Cmd2.Parameters.AddWithValue("@Empremarks", "joindate is on   " & join_dt)
                        Else
                            Leav_Cmd2.Parameters.AddWithValue("@Empremarks", "")
                        End If
                    End If
                End If
                Leav_Rdr.Close()
                Leav_Cmd = Nothing
                Leav_Cmd2.Parameters.AddWithValue("@Empconid", fetch_conempid)
                casuallev = 0
                sicklev = 0
                pres = 0
                materlev = 0
                'indx = i
                fetch_netslry()
                chk_previous_bal()

                If balernlev <> 0 Then
                    balernlev = balernlev + ern
                    Leav_Cmd2.Parameters.AddWithValue("@Emptotleav", balernlev) 'con
                Else

                    Leav_Cmd2.Parameters.AddWithValue("@Emptotleav", ern)

                End If

                'emp information
                Leav_Cmd1 = New SqlCommand("Select finactempmstr.empname,finactempmstr.empjndt," _
                & " finactempinfo.empfather,finactempothr.empothrrelevdt,finactdept.deptname," _
                & " finactdesi.desiname,finactemppfesi.empnewpfno from finactempmstr" _
                & " Inner join finactempinfo on finactempmstr.empid=finactempinfo.empconcrnid" _
                & " Inner join finactempothr on finactempmstr.empid=finactempothr.empothrconcrnid" _
                & " inner join finactdept on finactempmstr.empdeptid=finactdept.deptid" _
                & " inner join finactdesi on finactempmstr.empdesiid=finactdesi.desiid" _
                & " inner join finactemppfesi on finactempmstr.empid=finactemppfesi.emppfconcrnid" _
                & " where finactempmstr.empid='" & (fetch_conempid) & "'", FinActConn1) ' and attdleversn='" & ("Maternity Leave") & "'
                Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                While Leav_Rdr1.Read
                    If Leav_Rdr1.HasRows = True Then
                        Leav_Cmd2.Parameters.AddWithValue("@Empname", Leav_Rdr1("empname"))
                        Leav_Cmd2.Parameters.AddWithValue("@Empfname", Leav_Rdr1("empfather"))
                        Leav_Cmd2.Parameters.AddWithValue("@Empjndt", Leav_Rdr1("empjndt"))
                        Leav_Cmd2.Parameters.AddWithValue("@Emplevdt", Leav_Rdr1("empothrrelevdt"))
                        Leav_Cmd2.Parameters.AddWithValue("@Empdept", Leav_Rdr1("deptname"))
                        Leav_Cmd2.Parameters.AddWithValue("@Empdesi", Leav_Rdr1("desiname"))
                        Leav_Cmd2.Parameters.AddWithValue("@Emppfno", Leav_Rdr1("empnewpfno"))
                    End If
                End While
                Leav_Rdr1.Close()
                Leav_Cmd1 = Nothing


                Leav_Cmd2.ExecuteNonQuery()
                ' i += 1
                j += 1
                mnth += 1
                If mnth = 13 Then
                    mnth = 1
                    yer_srch += 1
                End If

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

    End Sub
    
    Private Sub chk_previous_bal() '------------to calculate ern leav bal of previous year
        minmon = 0
        Dim dtpckdt As Date
        Dim maxmondt As Date
        dtpckdt = Dtpick1.Value.Date
        maxmondt = dtpckdt.AddYears(-1)
        Dim minmondt As Date

        Try
            Leav_Cmd = New SqlCommand("Select min(Attddt) from finact_Attd WHERE Attddt>='" & (maxmondt) & "' and Attddt<='" & (dtpckdt) & "'", FinActConn)
            Leav_Rdr = Leav_Cmd.ExecuteReader
            Leav_Rdr.Read()
            If Leav_Rdr.IsDBNull(0) = False Then
                If Leav_Rdr.HasRows = True Then
                    minmondt = Leav_Rdr(0)
                    minmon = minmondt.Month
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Leav_Rdr.HasRows = False Then
                minmon = 0
            End If
            Leav_Rdr.Close()
            Leav_Cmd = Nothing
        End Try
        If minmon <> 0 Then

            'enjoy(earn) leave

            balernlev = 0.0
            Leav_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_conempid) & "' and   AttdStatus in('Leave') and AttdRepstatus in ('Full Day ErnLev') and  Attddt>='" & (maxmondt) & "' and Attddt<='" & (dtpckdt) & "' ", FinActConn1) ' 
            Leav_Rdr1 = Leav_Cmd1.ExecuteReader
            Leav_Rdr1.Read()
            If Leav_Rdr1.HasRows = True Then
                balernlev = Leav_Rdr1(0)
            Else
                balernlev = 0
            End If
            Leav_Rdr1.Close()
            Leav_Cmd1 = Nothing


            Leav_Cmd1 = New SqlCommand("Select AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_conempid) & "' and   AttdStatus in('PresntCumLev') and AttdRepstatus in ('1st Half Day Ernlev','2nd Half Day ErnLev') and  Attddt>='" & (maxmondt) & "' and Attddt<='" & (dtpckdt) & "' ", FinActConn1) ' 
            Leav_Rdr1 = Leav_Cmd1.ExecuteReader
            While Leav_Rdr1.Read
                If Leav_Rdr1.HasRows = True Then
                    balernlev += 0.5
                Else
                    balernlev += 0
                End If
            End While
            Leav_Rdr1.Close()
            Leav_Cmd1 = Nothing


            '=================present
            Leav_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_conempid) & "' and AttdStatus in('Present') and Attddt>='" & (maxmondt) & "' and Attddt<='" & (dtpckdt) & "' ", FinActConn1) ' 
            Leav_Rdr1 = Leav_Cmd1.ExecuteReader
            Leav_Rdr1.Read()
            If Leav_Rdr1.HasRows = True Then
                presntdayinter = Leav_Rdr1(0)
            Else
                presntdayinter = 0
            End If
            Leav_Rdr1.Close()
            Leav_Cmd1 = Nothing

            Leav_Cmd1 = New SqlCommand("Select  AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_conempid) & "' and  AttdStatus in('PresntCumLev') and Attddt>='" & (maxmondt) & "' and Attddt<='" & (dtpckdt) & "' ", FinActConn1) ' 
            Leav_Rdr1 = Leav_Cmd1.ExecuteReader
            While Leav_Rdr1.Read()
                If Leav_Rdr1.HasRows = True Then
                    presntdayinter += 0.5
                Else
                    presntdayinter += 0
                End If
            End While
            Leav_Rdr1.Close()
            Leav_Cmd1 = Nothing

            '----------to cal tot ern lev acc to emp totwrkingdays.
            If balernlev <> 0 And presntdayinter <> 0 Then
                Dim totern As Double = 0.0
                totern = presntdayinter / 20
                If balernlev < totern And totern >= 1 Then
                    balernlev = totern - balernlev
                Else
                    balernlev = 0
                End If
            End If
            Leav_Cmd2.Parameters.AddWithValue("@EmpBalleav", balernlev)
        Else
            Leav_Cmd2.Parameters.AddWithValue("@EmpBalleav", 0) '"-NIL-"
        End If

    End Sub
    Private Sub fetch_netslry() ''totern-overtm

        Dim slry As Double = 0.0
        '================================totslry

        Dim overtm As Double = 0.0

        Leav_Cmd1 = New SqlCommand("Select Sum(AslryTotlern)  from FinactAutoSalary WHERE Aslrydelstatus='" & (0) & "'and Aslryempid='" & (fetch_conempid) & "'and  Aslrymnth='" & MonthName(mnth) & "' and year(Aslrydt)='" & (yer_srch) & "'", FinActConn1)
        Leav_Rdr1 = Leav_Cmd1.ExecuteReader
        Leav_Rdr1.Read()
        If Leav_Rdr1.IsDBNull(0) = False Then
            If Leav_Rdr1.HasRows = True Then
                slry = Leav_Rdr1(0)
            Else
                slry = 0
            End If
        End If
        Leav_Rdr1.Close()
        Leav_Cmd1 = Nothing


        Leav_Cmd1 = New SqlCommand("Select Sum(Aslryovrtmern)  from FinactAutoSalary WHERE Aslrydelstatus='" & (0) & "'and Aslryempid='" & (fetch_conempid) & "'and  Aslrymnth='" & MonthName(mnth) & "' and year(Aslrydt)='" & (yer_srch) & "'", FinActConn1)
        Leav_Rdr1 = Leav_Cmd1.ExecuteReader
        Leav_Rdr1.Read()
        If Leav_Rdr1.IsDBNull(0) = False Then
            If Leav_Rdr1.HasRows = True Then
                overtm = Leav_Rdr1(0)
            Else
                overtm = 0
            End If
        End If
        Leav_Rdr1.Close()
        Leav_Cmd1 = Nothing
        slry = slry - overtm

        Leav_Cmd2.Parameters.AddWithValue("@EmpwageErn", slry)
        Leav_Cmd2.Parameters.AddWithValue("@Empratwages", slry)
        Leav_Cmd2.Parameters.AddWithValue("@Empratslry", slry)
    End Sub
    Private Sub cntsundays() '----------------------/No--USE

        Dim j1 As Integer = 1
        sunday = 0
        monthdays = 0
        holiday = 0

        Try

            monthdays = Date.DaysInMonth(yer_srch, mnth)
            Dim dt As Date
            dt = "1/ " & mnth & " / " & yer_srch
            DateTimePicker2.Value = Format(dt, "dd/MM/yyyy")
            While j1 <= monthdays
                Leav_Cmd1 = New SqlCommand("Select distinct(AttdStatus) from Finact_Attd where  AttdStatus in('Holiday') and AttdLeveRsn in ('Offday') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "' and Day(Attddt)='" & (DateTimePicker2.Value.Day) & "' ", FinActConn1) 'AttdEmpid='" & (fetch_mainempid) & "' and
                Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                Leav_Rdr1.Read()
                If Leav_Rdr1.HasRows = True Then
                    sunday += 1
                Else
                    sunday += 0
                End If
                Leav_Rdr1.Close()
                Leav_Cmd1 = Nothing
                DateTimePicker2.Value = DateTimePicker2.Value.AddDays(1)
                j1 += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        j1 = 1
        Try
            monthdays = Date.DaysInMonth(yer_srch, mnth)
            Dim dt As Date
            dt = "1/ " & mnth & " / " & yer_srch
            DateTimePicker2.Value = Format(dt, "dd/MM/yyyy")
            While j1 <= monthdays
                Leav_Cmd1 = New SqlCommand("Select distinct(AttdStatus) from Finact_Attd where  AttdStatus in('Holiday') and AttdLeveRsn in ('Holiday') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'  and Day(Attddt)='" & (DateTimePicker2.Value.Day) & "' ", FinActConn1)
                Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                Leav_Rdr1.Read()
                If Leav_Rdr1.HasRows = True Then
                    holiday += 1
                Else
                    holiday += 0
                End If
                Leav_Rdr1.Close()
                Leav_Cmd1 = Nothing
                DateTimePicker2.Value = DateTimePicker2.Value.AddDays(1)
                j1 += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        sunday = holiday + sunday

    End Sub
    Private Sub fet_emp_dtjoin()

        Try
            Leav_Cmd1 = New SqlCommand("Select empjndt from finactEmpMstr where empdelstatus= 1 and Empid='" & (fetch_conempid) & "'", FinActConn1)
            Leav_Rdr1 = Leav_Cmd1.ExecuteReader
            Leav_Rdr1.Read()
            If Leav_Rdr1.HasRows = True Then
                join_dt = Leav_Rdr1(0)
            End If
            Leav_Rdr1.Close()
            Leav_Cmd1 = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    
    Private Sub fetch_res_idwise()
        'to delete
        Try
            Leav_Cmd = New SqlCommand("Finact_leave_sumary_Delete", FinActConn)
            Leav_Cmd.CommandType = CommandType.StoredProcedure
            Leav_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Leav_Cmd = Nothing
        End Try

        '-------------------to save in database
        Dim ern As Integer = 0
        Dim str_pres As Integer = 0
        Dim totlev As Double = 0
        Dim pres As Double = 0.0
        mnth = Dtpick1.Value.Month '-----------
        Dim str As String = ""
        yer_srch = Dtpick1.Value.Year '----------
        Dim sicklev As Double = 0
        Dim casuallev As Double = 0
        Dim materlev As Double = 0
        Dim srtlev As Integer = 0
        'Dim i As Integer = 0
        fetch_mainempid = 0
        Dim j As Integer = 1
        Try
            While j <= 12
                str = ""
                sicklev = 0
                str = MonthName(mnth) & "-" & yer_srch
                fetch_mainempid = CInt(Combofromid.Text)
                fetch_conempid = fetch_mainempid

                Leav_Cmd2 = New SqlCommand("Finact_leave_sumary_insert", FinActConn2)
                Leav_Cmd2.CommandType = CommandType.StoredProcedure
                Leav_Cmd2.Parameters.AddWithValue("@EmpwagePrd", str)

                '=================present
                Leav_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                Leav_Rdr1.Read()
                If Leav_Rdr1.HasRows = True Then
                    pres = Leav_Rdr1(0)
                Else
                    pres = 0
                End If
                Leav_Rdr1.Close()
                Leav_Cmd1 = Nothing

                Leav_Cmd1 = New SqlCommand("Select  AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1)
                Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                While Leav_Rdr1.Read()
                    If Leav_Rdr1.HasRows = True Then
                        pres += 0.5
                    Else
                        pres += 0
                    End If
                End While
                Leav_Rdr1.Close()
                Leav_Cmd1 = Nothing
                Leav_Cmd2.Parameters.AddWithValue("@Empworkdays", pres)



                '========offlaydays
                Leav_Cmd2.Parameters.AddWithValue("@Emplayoffday", 0) '---

                ' mater 
                Leav_Cmd1 = New SqlCommand("Select AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and  AttdRepstatus in ('Maternity Leave') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) ' and attdleversn='" & ("Maternity Leave") & "'
                Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                While Leav_Rdr1.Read
                    If Leav_Rdr1.HasRows = True Then
                        materlev += 1
                    Else
                        materlev += 0
                    End If
                End While
                Leav_Rdr1.Close()
                Leav_Cmd1 = Nothing

                Leav_Cmd2.Parameters.AddWithValue("@Empmatrntyleav", materlev)

                'enjoy(earn) leave

                Dim ernlev As Double = 0.0

                Leav_Cmd1 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and   AttdStatus in('Leave') and AttdRepstatus in ('Full Day ErnLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) ' and attdleversn='" & ("Maternity Leave") & "'
                Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                Leav_Rdr1.Read()
                If Leav_Rdr1.HasRows = True Then
                    ernlev = Leav_Rdr1(0)
                Else
                    ernlev = 0
                End If
                'End While
                Leav_Rdr1.Close()
                Leav_Cmd1 = Nothing


                Leav_Cmd1 = New SqlCommand("Select AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and   AttdStatus in('PresntCumLev') and AttdRepstatus in ('1st Half Day Ernlev','2nd Half Day ErnLev') and month(Attddt)='" & (mnth) & "' and year(Attddt)='" & (yer_srch) & "'", FinActConn1) ' and attdleversn='" & ("Maternity Leave") & "'
                Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                While Leav_Rdr1.Read
                    If Leav_Rdr1.HasRows = True Then
                        ernlev += 0.5
                    Else
                        ernlev += 0
                    End If
                End While
                Leav_Rdr1.Close()
                Leav_Cmd1 = Nothing

                Leav_Cmd2.Parameters.AddWithValue("@Empenjoyleav", ernlev) '----
                totlev = pres + materlev + ernlev '---enjoylev

                Leav_Cmd2.Parameters.AddWithValue("@Emptot", totlev)

                ern = 0
                If pres >= 20 Then
                    str_pres += pres - 20
                    If str_pres >= 20 Then
                        ern = 2
                        Leav_Cmd2.Parameters.AddWithValue("@Empearnleav", 2)
                        Leav_Cmd2.Parameters.AddWithValue("@Empcrdleavbal ", 2)
                        str_pres = str_pres - 20
                    Else
                        ern = 1
                        Leav_Cmd2.Parameters.AddWithValue("@Empearnleav", 1)
                        Leav_Cmd2.Parameters.AddWithValue("@Empcrdleavbal ", 1)
                    End If
                Else
                    ern = 0
                    Leav_Cmd2.Parameters.AddWithValue("@Empearnleav", 0)
                    Leav_Cmd2.Parameters.AddWithValue("@Empcrdleavbal ", 0)
                End If


                Leav_Cmd2.Parameters.AddWithValue("@Empsection", "NO")
                Leav_Cmd2.Parameters.AddWithValue("@Emplevenjoyfrmto ", "")
                Leav_Cmd2.Parameters.AddWithValue("@Empcshequi ", "0")
                fetch_conempid = fetch_mainempid
                fet_emp_dtjoin()
                If join_dt.Month >= mnth And join_dt.Year >= yer_srch Then
                    Leav_Cmd2.Parameters.AddWithValue("@Empremarks", "joindate is on   " & join_dt)
                Else
                    Leav_Cmd2.Parameters.AddWithValue("@Empremarks", "")
                End If

                Leav_Cmd2.Parameters.AddWithValue("@Empconid", fetch_conempid)
                casuallev = 0
                sicklev = 0
                pres = 0
                materlev = 0
                fetch_netslry()
                chk_previous_bal()
                If balernlev <> 0 Then
                    balernlev = balernlev + ern
                    Leav_Cmd2.Parameters.AddWithValue("@Emptotleav", balernlev) 'con
                Else

                    Leav_Cmd2.Parameters.AddWithValue("@Emptotleav", ern)

                End If
                'emp information
                Leav_Cmd1 = New SqlCommand("Select finactempmstr.empname,finactempmstr.empjndt," _
                & " finactempinfo.empfather,finactempothr.empothrrelevdt,finactdept.deptname," _
                & " finactdesi.desiname,finactemppfesi.empnewpfno from finactempmstr" _
                & " Inner join finactempinfo on finactempmstr.empid=finactempinfo.empconcrnid" _
                & " Inner join finactempothr on finactempmstr.empid=finactempothr.empothrconcrnid" _
                & " inner join finactdept on finactempmstr.empdeptid=finactdept.deptid" _
                & " inner join finactdesi on finactempmstr.empdesiid=finactdesi.desiid" _
                & " inner join finactemppfesi on finactempmstr.empid=finactemppfesi.emppfconcrnid" _
                & " where finactempmstr.empid='" & (fetch_conempid) & "'", FinActConn1) ' and attdleversn='" & ("Maternity Leave") & "'
                Leav_Rdr1 = Leav_Cmd1.ExecuteReader
                While Leav_Rdr1.Read
                    If Leav_Rdr1.HasRows = True Then
                        Leav_Cmd2.Parameters.AddWithValue("@Empname", Leav_Rdr1("empname"))
                        Leav_Cmd2.Parameters.AddWithValue("@Empfname", Leav_Rdr1("empfather"))
                        Leav_Cmd2.Parameters.AddWithValue("@Empjndt", Leav_Rdr1("empjndt"))
                        Leav_Cmd2.Parameters.AddWithValue("@Emplevdt", Leav_Rdr1("empothrrelevdt"))
                        Leav_Cmd2.Parameters.AddWithValue("@Empdept", Leav_Rdr1("deptname"))
                        Leav_Cmd2.Parameters.AddWithValue("@Empdesi", Leav_Rdr1("desiname"))
                        Leav_Cmd2.Parameters.AddWithValue("@Emppfno", Leav_Rdr1("empnewpfno"))
                    End If
                End While
                Leav_Rdr1.Close()
                Leav_Cmd1 = Nothing

                Leav_Cmd2.ExecuteNonQuery()
                'i += 1
                j += 1
                mnth += 1
                If mnth = 13 Then
                    mnth = 1
                    yer_srch += 1
                End If

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

    End Sub
    Private Sub Dtpick1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpick1.Leave

        dt2minyear = Dtpick1.Value.Date
        Dim mnth As Integer = 0
        Dim dt2mnth As Date
        dt2mnth = Dtpick1.Value.AddMonths(11)
        Dtpick2.Value = dt2mnth

        Combcatgry.Focus()
    End Sub

    Private Sub Combename_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combename.GotFocus

        Combename.Items.Clear()

        Try
            fetch_Empname()
            If Combename.Items.Count > 0 Then
                If Combename.SelectedIndex = -1 Then
                    Combename.SelectedIndex = 0
                End If
                Combename.DroppedDown = True
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try


    End Sub

    Private Sub Combofromid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combofromid.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Combofromid.Text <> "" Then
                'DataGridView.Visible = True
                ' BtnSave.Visible = True
                'Me.Height = 632
                fetch_res_idwise()
            End If
        End If

    End Sub

    Private Sub Combename_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combename.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Combename.Text <> "" Then
                fetch_res()
            End If
        End If

    End Sub
    Private Sub Combcatgry_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combcatgry.Leave
        If Combcatgry.SelectedIndex = 0 Then
            Lblempid.Visible = False
            Combofromid.Visible = False
            Lblempnm.Visible = True
            Combename.Visible = True
        ElseIf Combcatgry.SelectedIndex = 1 Then
            Lblempid.Visible = True
            Lblempnm.Visible = False
            Combename.Visible = False
            Combofromid.Visible = True

        End If
    End Sub

    Private Sub Combename_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combename.Leave
        If Combename.Text <> "" Then
           
            fetch_res()
        End If
    End Sub

    Private Sub Combofromid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combofromid.Leave
        If Combofromid.Text <> "" Then
            fetch_res_idwise()
        End If
    End Sub


    Private Sub Combofromid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combofromid.SelectedIndexChanged

    End Sub

    Private Sub Combename_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combename.SelectedIndexChanged

    End Sub

    Private Sub BtnLww_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLww.Click
        Try
            Me.Height = 700
            CrVewLww.Enabled = True
            TellRptstatus = False
            CoprofileParamsLww()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CoprofileParamsLww()
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

        Dim ParmVal6 As ParameterValues = New ParameterValues()
        Dim DisVal6 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal6.Value = 1
        ParmVal6.Add(DisVal6)

        Dim ParmVal7 As ParameterValues = New ParameterValues()
        Dim DisVal7 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal7.Value = 1
        ParmVal7.Add(DisVal7)

        Dim nparm As New OdbcParameter("@@N", Odbc.OdbcType.VarBinary, 200)
        Dim aparm As New OdbcParameter("@@a", Odbc.OdbcType.VarChar, 100)
        Dim aparm1 As New OdbcParameter("@@a1", Odbc.OdbcType.VarChar, 100)
        Dim conparm As New OdbcParameter("@@coN", Odbc.OdbcType.VarChar, 100)
        Dim con2parm As New OdbcParameter("@@con2", Odbc.OdbcType.VarChar, 100)
        Dim con3parm As New OdbcParameter("@@con3", Odbc.OdbcType.VarChar, 100)
        Dim pinparm As New OdbcParameter("@@pin", Odbc.OdbcType.VarChar, 100)
        Dim ctyparm As New OdbcParameter("@@cty", Odbc.OdbcType.VarChar, 100)
        Dim EsiNOparm As New OdbcParameter("@@Esino", Odbc.OdbcType.VarChar, 50)
        Dim Pfnoparm As New OdbcParameter("@@Pfno", Odbc.OdbcType.VarChar, 50)

        Dim DcrypConame As New EnCryp_DeCryp_String
        Try
            If TellRptstatus = False Then
                Fetch_InfoCrRptLww()
            End If
            OdbcCmd1 = New OdbcCommand("exec Tempcncrpt_esipfinfo nparm,aparm,aparm1,conparm,conparm2,conparm3,pinparm,ctyparm,Esinoparm,Pfnoparm", FinactOdbcCon)
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
                Rptstr = Odbcrdr1(3)
                ParmVal5.AddValue(Rptstr)
                If Trim(EsiAmt) = "" Then
                    ParmVal6.AddValue("Nil")
                Else
                    ParmVal6.AddValue(EsiAmt)
                End If
                CrRptLWW.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptLWW.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptLWW.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
             
            End While
            CrVewLww.ReportSource = CrRptLWW
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub
    Private Sub Fetch_InfoCrRptLww()
        Try
            EsiF6_Cmd = New SqlCommand("Select * from Finact_Leave_summary", FinActConn)
            Dim dsEsino As New DataSet(EsiF6_Cmd.CommandText)
            EsiF6_Adptr = New SqlDataAdapter(EsiF6_Cmd)
            EsiF6_Adptr.Fill(dsEsino)
            CrRptLWW.SetDataSource(dsEsino.Tables(0))
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiF6_Cmd = Nothing

            EsiF6_Adptr.Dispose()

        End Try
    End Sub

   
End Class
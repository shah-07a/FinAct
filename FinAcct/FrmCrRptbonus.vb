Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmCrRptbonus
    Inherits System.Windows.Forms.Form
    Dim Bns_Cmd As SqlCommand
    Dim Bns_Adptr As SqlDataAdapter
    Dim Bns_Rdr As SqlDataReader
    Dim Bns_Cmd2 As SqlCommand
    Dim Bns_Rdr2 As SqlDataReader
    Dim Bns_Cmd1 As SqlCommand
    Dim Bns_Rdr1 As SqlDataReader
    Dim TellRptstatus As Boolean
    Dim CrRptbons As New CrRptBonus
    Dim odbccon1 As OdbcConnection
    Dim OdbcCmd1 As OdbcCommand
    Dim OdbcDa1 As OdbcDataAdapter
    Dim Odbcrdr1 As OdbcDataReader
    Dim OdbcCmd As SqlCommand
    Dim OdbcRdr As SqlDataReader
    'Dim Odbccon1 As SqlConnection
    'Dim OdbcCmd1 As SqlCommand
    Dim OdbcDa As SqlDataAdapter
    'Dim OdbcDa1 As SqlDataAdapter
    'Dim OdbcRdr1 As SqlDataReader
    Dim RateofBonus As Double

    Private Sub fetch_res()

        '--------------------------to delete recds in backend ----------

        Try
            Bns_Cmd = New SqlCommand("Finact_Bonus_Delete", FinActConn)
            Bns_Cmd.CommandType = CommandType.StoredProcedure
            Bns_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Bns_Cmd = Nothing
        End Try

        '-----------------------------to save recds in backend ----------

        Dim str_age As String = ""
        Dim j As Integer = 1
        Dim frmdt, todt, frmdt1 As Date
        Dim emp_id As Integer = 0
        Dim pres As Double = 0.0
        Try
            Bns_Cmd = New SqlCommand("Select empid,empname,desiname,deptname,desiname,empfather from finactEmpMstr inner join finactdesi on desiid=empdesiid inner join  finactdept on empdeptid=deptid  inner join  finactEmpinfo on empconcrnid=empid where finactempmstr.empdelstatus= 1 order by empname", FinActConn)
            Bns_Rdr = Bns_Cmd.ExecuteReader
            While Bns_Rdr.Read()
                If Bns_Rdr.IsDBNull(0) = False Then
                    If Bns_Rdr.HasRows = True Then
                        frmdt1 = Format(Dtpick1.Value, "MM/dd/yyyy")
                        todt = dtpick2.Value
                        frmdt = Dtpick1.Value
                        Bns_Cmd1 = New SqlCommand("Finact_Bonus_Insert", FinActConn1)
                        Bns_Cmd1.CommandType = CommandType.StoredProcedure
                        Bns_Cmd1.Parameters.AddWithValue("@BnsSrNo", j)
                        Bns_Cmd1.Parameters.AddWithValue("@BnsEmpName", Bns_Rdr(1))
                        Bns_Cmd1.Parameters.AddWithValue("@BnsEmpConId", Bns_Rdr(0))
                        Bns_Cmd1.Parameters.AddWithValue("@BnsEmpFather", Bns_Rdr(5))
                        Bns_Cmd1.Parameters.AddWithValue("@BnsEmpDesi", Bns_Rdr(2))
                        Bns_Cmd1.Parameters.AddWithValue("@BnsEmpDept", Bns_Rdr(3))
                        emp_id = Bns_Rdr(0)

                        '===============================chk emp age with brthddt

                        Dim fet_dt As Date
                        Bns_Cmd2 = New SqlCommand("Select empdobdt from finactEmpMstr where empdelstatus= 1 and empid='" & (emp_id) & "'", FinActConn2)
                        Bns_Rdr2 = Bns_Cmd2.ExecuteReader
                        Bns_Rdr2.Read()
                        If Bns_Rdr2.HasRows = True Then
                            fet_dt = Bns_Rdr2(0)
                            If frmdt1.Date > fet_dt Then
                                Dim diff As Integer = 0
                                While fet_dt.Year <= frmdt1.Date.Year
                                    fet_dt = fet_dt.AddYears(1)
                                    diff += 1
                                End While
                                If diff >= 15 Then
                                    str_age = "YES"
                                Else
                                    str_age = "NO"
                                End If
                            Else
                                str_age = "NO"
                            End If
                        Else
                            str_age = "NO"
                        End If
                        Bns_Rdr2.Close()
                        Bns_Cmd2 = Nothing
                        Bns_Cmd1.Parameters.AddWithValue("@BnsAge", str_age)


                        '================================chk emp work days

                        Bns_Cmd2 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (emp_id) & "' and AttdStatus in('Present','PresntCumLev','Holiday')  and  Attddt  between'" & (frmdt.Date) & "'and'" & (todt.Date) & "' ", FinActConn2)
                        Bns_Rdr2 = Bns_Cmd2.ExecuteReader
                        Bns_Rdr2.Read()
                        If Bns_Rdr2.HasRows = True Then
                            pres = Bns_Rdr2(0)
                        Else
                            pres = 0
                        End If
                        Bns_Rdr2.Close()
                        Bns_Cmd2 = Nothing

                        Bns_Cmd1.Parameters.AddWithValue("@BnsWrkdays ", pres) '-work days

                        '================================totslry
                        Dim todt1 As Date
                        Dim slry As Double = 0.0
                        Dim overtm As Double = 0.0
                        todt1 = todt

                        Bns_Cmd2 = New SqlCommand("Select Sum(AslryTotlern)  from FinactAutoSalary where AslryEmpid='" & (emp_id) & "' and   Aslrydt  between'" & (frmdt.Date) & "'and'" & (todt1.Date) & "' ", FinActConn2)
                        Bns_Rdr2 = Bns_Cmd2.ExecuteReader
                        Bns_Rdr2.Read()
                        If Bns_Rdr2.IsDBNull(0) = False Then
                            If Bns_Rdr2.HasRows = True Then
                                slry = Bns_Rdr2(0)
                            Else
                                slry = 0
                            End If
                        End If
                        Bns_Rdr2.Close()
                        Bns_Cmd2 = Nothing

                        Bns_Cmd2 = New SqlCommand("Select Sum(Aslryovrtmern)  from FinactAutoSalary where AslryEmpid='" & (emp_id) & "' and   Aslrydt  between'" & (frmdt.Date) & "'and'" & (todt1.Date) & "' ", FinActConn2)
                        Bns_Rdr2 = Bns_Cmd2.ExecuteReader
                        Bns_Rdr2.Read()
                        If Bns_Rdr2.IsDBNull(0) = False Then
                            If Bns_Rdr2.HasRows = True Then
                                overtm = Bns_Rdr2(0)
                            Else
                                overtm = 0
                            End If
                        End If
                        Bns_Rdr2.Close()
                        Bns_Cmd2 = Nothing

                        slry = slry - overtm
                        Bns_Cmd1.Parameters.AddWithValue("@Bnstotslry", slry)


                        '===========fetch bonus rt frm payhed

                        Dim rt As Double = 0.0
                        Dim bns_amt As Double = 0.0
                        Bns_Cmd2 = New SqlCommand("Select PheadRate  from Finactpayhead where pheadtype='" & Trim("Bonus") & "' and   pheaddelstatus=0 ", FinActConn2)
                        Bns_Rdr2 = Bns_Cmd2.ExecuteReader
                        Bns_Rdr2.Read()
                        If Bns_Rdr2.IsDBNull(0) = False Then
                            If Bns_Rdr2.HasRows = True Then
                                rt = Bns_Rdr2(0)
                                rateofbonus = rt

                            Else
                                rt = 0
                            End If
                        End If

                        Bns_Rdr2.Close()
                        Bns_Cmd2 = Nothing
                        If rt <> 0 And slry <> 0 Then
                            bns_amt = FormatNumber((slry * rt) / 100, 2)
                        Else
                            bns_amt = 0
                        End If

                        Bns_Cmd1.Parameters.AddWithValue("@BnsAmt", bns_amt)
                        Bns_Cmd1.Parameters.AddWithValue("@BnsOtherAmt ", 0)
                        Bns_Cmd1.Parameters.AddWithValue("@BnsIntrim", 0)
                        Bns_Cmd1.Parameters.AddWithValue("@BnsFine", 0)
                        Bns_Cmd1.Parameters.AddWithValue("@Bnstotdeduct", 0)
                        Bns_Cmd1.Parameters.AddWithValue("@BnsNetamt", bns_amt)
                        Bns_Cmd1.Parameters.AddWithValue("@BnsPaid", 0)
                        Bns_Cmd1.Parameters.AddWithValue("@BnsdtPaid", "")
                        Bns_Cmd1.ExecuteNonQuery()
                        j += 1
                    End If
                End If

                pres = 0
                str_age = ""

            End While '----------------------------------------------------------->>main condition
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Bns_Rdr.Close()
            Bns_Cmd = Nothing
        End Try
    End Sub


    Private Sub FrmCrRptbonus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Width = 1085
            Me.Height = 75
            TellRptstatus = True
            CoprofileParamsEmpInfo()
            Me.Txtbons.Focus()
            Me.Txtbons.SelectAll()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CoprofileParamsEmpInfo()
        Try

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

            Dim DcrypConame As New EnCryp_DeCryp_String
            Try
                If TellRptstatus = False Then
                    Fetch_InfoCrRptEp()
                End If
                ' Odbccon1 = New SqlConnection("Driver={SQL Native Client};Server=.;Database=hrprdata08;Uid=sa;Pwd=sa;")
                ''Odbccon1.Open()
                OdbcCmd1 = New OdbcCommand("exec Tempcncrpt nparm,aparm,aparm1,conparm,conparm2,conparm3,pinparm,ctyparm ", FinactOdbcCon)
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
                    Rptstr = ("Bonus Paid to Employees/Workers for the accounting year" & "-" & Trim(Txtbons.Text)).ToUpper
                    'End If
                    ParmVal5.AddValue(Rptstr)
                    ParmVal6.AddValue(Trim(Txtbons.Text))
                    ParmVal7.AddValue(RateofBonus)
                    CrRptbons.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                    CrRptbons.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                    CrRptbons.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                    CrRptbons.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
                    CrRptbons.DataDefinition.ParameterFields("Rpttype").ApplyCurrentValues(ParmVal5)
                    CrRptbons.DataDefinition.ParameterFields("Actyear").ApplyCurrentValues(ParmVal6)
                    CrRptbons.DataDefinition.ParameterFields("Bonsrate").ApplyCurrentValues(ParmVal7)
                End While

                CrVewBonus.ReportSource = CrRptbons
            Catch ex As SqlException
                MsgBox(ex.Number & " " & ex.Message)
            Finally

                Odbcrdr1.Close()
                OdbcCmd1.Dispose()

            End Try
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Fetch_InfoCrRptEp()
        Try
            Bns_Cmd = New SqlCommand("select * from Finact_bonus ", FinActConn)

            Dim dssal As New DataSet(Bns_Cmd.CommandText)
            Bns_Adptr = New SqlDataAdapter(Bns_Cmd)
            Bns_Adptr.Fill(dssal)
            CrRptbons.SetDataSource(dssal.Tables(0))

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Bns_Cmd = Nothing
        End Try
    End Sub

    Private Sub BtnBonus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBonus.Click
        fetch_res()
        TellRptstatus = False
        Me.Height = 700
        Me.CrVewBonus.Visible = True
        CoprofileParamsEmpInfo()
    End Sub

    Private Sub ALLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtbons.KeyDown, Dtpick1.KeyDown _
    , dtpick2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtbons_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbons.Leave
        If Txtbons.Text.Trim = "" Then
            Txtbons.Focus()
            Txtbons.BackColor = Color.Khaki
        Else
            Txtbons.BackColor = Color.White
            Dtpick1.Focus()
        End If
    End Sub

   
End Class
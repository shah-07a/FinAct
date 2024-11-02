Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.Shared
Public Class FrmCrRptSalSumry

    Dim odbccon1 As OdbcConnection
    Dim OdbcCmd1 As OdbcCommand
    Dim OdbcDa1 As OdbcDataAdapter
    Dim Odbcrdr1 As OdbcDataReader
    
    'Dim Odbccon1 As SqlConnection
    'Dim OdbcCmd1 As SqlCommand
    'Dim OdbcDa1 As SqlDataAdapter
    'Dim OdbcRdr1 As SqlDataReader

    Dim DataTblEp As DataTable
    Dim SelRptdata As SqlDataAdapter
    Dim SelRptDtaTble As DataTable
    Dim Sql_Sal_Slp_Cmd As SqlCommand
    Dim Sql_Sal_Slp_Cmd1 As SqlCommand
    Dim Sql_Sal_Slp_Rdr As SqlDataReader
    Dim Sql_Sal_Slp_Adptr As SqlDataAdapter
    Dim Sql_Sal_Slp_dtbl As DataTable
    Dim SalMonth As Integer
    Dim SalYear As Integer
    Dim CrRptSalsumry As New CrRptSalSumry
    Dim TellRptstatus As Boolean
    Dim Salamt, Wagamt, OvrtimeAmt, AdvAmt, LonAmt, TotDed, TotErn, Netamt As Double
    Dim Rolsal, Rolwag As Integer

    Private Sub Fetch_InfoCrRptEp()
        Salamt = 0
        Wagamt = 0
        OvrtimeAmt = 0
        AdvAmt = 0
        LonAmt = 0
        TotDed = 0
        TotErn = 0
        Netamt = 0
        Rolsal = 0
        Rolwag = 0


        SalMonth = DtpSalslip.Value.Month
        SalYear = DtpSalslip.Value.Year
        Dim Salempid As Integer = Cmbxselemp.SelectedValue
        Dim SalMname As String = MonthName(DtpSalslip.Value.Month)
        Try

            Dim chktype As String = ""
            If Chkbx1.Checked = True Then
                chktype = Trim("All")
            Else
                chktype = Trim("OnebyOne")
            End If

            'chktype = Trim("All")
            Sql_Sal_Slp_Cmd = New SqlCommand("Temp_Sal_Slp_Select", FinActConn)
            Sql_Sal_Slp_Cmd.CommandType = CommandType.StoredProcedure
            Sql_Sal_Slp_Cmd.Parameters.AddWithValue("@yr", SalYear)
            Sql_Sal_Slp_Cmd.Parameters.AddWithValue("@mnth", SalMname)
            Sql_Sal_Slp_Cmd.Parameters.AddWithValue("@empid", Salempid)
            Sql_Sal_Slp_Cmd.Parameters.AddWithValue("@chktype", Trim(chktype))
            Dim dssal As New DataSet(Sql_Sal_Slp_Cmd.CommandText)
            Sql_Sal_Slp_Adptr = New SqlDataAdapter(Sql_Sal_Slp_Cmd)
            Sql_Sal_Slp_Adptr.Fill(dssal)

            CrRptSalsumry.SetDataSource(dssal.Tables(0))
            Try
                Sql_Sal_Slp_Cmd1 = New SqlCommand("Temp_Sal_Summary_Select ", FinActConn1)
                Sql_Sal_Slp_Cmd1.CommandType = CommandType.StoredProcedure
                Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@yr", SalYear)
                Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@mnth", SalMname)
                Sql_Sal_Slp_Rdr = Sql_Sal_Slp_Cmd1.ExecuteReader
                While Sql_Sal_Slp_Rdr.Read()
                    If Sql_Sal_Slp_Rdr.IsDBNull(0) = False Then
                        Salamt = Sql_Sal_Slp_Rdr("SalErnamt")
                        Rolsal = Sql_Sal_Slp_Rdr("salcont")
                    End If
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Sql_Sal_Slp_Rdr.Close()
                Sql_Sal_Slp_Cmd1 = Nothing
            End Try
            Try
                Sql_Sal_Slp_Cmd1 = New SqlCommand("Temp_Sal_Summary1_Select ", FinActConn1)
                Sql_Sal_Slp_Cmd1.CommandType = CommandType.StoredProcedure
                Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@yr", SalYear)
                Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@mnth", SalMname)
                Sql_Sal_Slp_Rdr = Sql_Sal_Slp_Cmd1.ExecuteReader
                While Sql_Sal_Slp_Rdr.Read()
                    If Sql_Sal_Slp_Rdr.IsDBNull(0) = False Then
                        Wagamt = Sql_Sal_Slp_Rdr("wagErnamt")
                        Rolwag = Sql_Sal_Slp_Rdr("wagcont")
                    End If

                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Sql_Sal_Slp_Rdr.Close()
                Sql_Sal_Slp_Cmd1 = Nothing
            End Try

            Try
                Sql_Sal_Slp_Cmd1 = New SqlCommand("Temp_Sal_Summary2_Select ", FinActConn1)
                Sql_Sal_Slp_Cmd1.CommandType = CommandType.StoredProcedure
                Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@yr", SalYear)
                Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@mnth", SalMname)
                Sql_Sal_Slp_Rdr = Sql_Sal_Slp_Cmd1.ExecuteReader
                While Sql_Sal_Slp_Rdr.Read()
                    If Sql_Sal_Slp_Rdr.IsDBNull(0) = False Then
                        OvrtimeAmt = Sql_Sal_Slp_Rdr("overtime")
                        AdvAmt = Sql_Sal_Slp_Rdr("advamount")
                        LonAmt = Sql_Sal_Slp_Rdr("lonamount")
                        TotDed = Sql_Sal_Slp_Rdr("totdeduction")
                        TotErn = Sql_Sal_Slp_Rdr("salwagtot")
                        Netamt = Sql_Sal_Slp_Rdr("netamount")
                    End If
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Sql_Sal_Slp_Rdr.Close()
                Sql_Sal_Slp_Cmd1 = Nothing
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql_Sal_Slp_Cmd = Nothing
        End Try
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

        Dim ParmVal6 As ParameterValues = New ParameterValues()
        Dim DisVal6 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal6.Value = 1
        ParmVal6.Add(DisVal6)

        Dim ParmVal7 As ParameterValues = New ParameterValues()
        Dim DisVal7 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal7.Value = 1
        ParmVal7.Add(DisVal7)

        Dim ParmVal8 As ParameterValues = New ParameterValues()
        Dim DisVal8 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal8.Value = 1
        ParmVal8.Add(DisVal8)

        Dim ParmVal9 As ParameterValues = New ParameterValues()
        Dim DisVal9 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal9.Value = 1
        ParmVal9.Add(DisVal9)

        Dim ParmVal10 As ParameterValues = New ParameterValues()
        Dim DisVal10 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal10.Value = 1
        ParmVal10.Add(DisVal10)

        Dim ParmVal11 As ParameterValues = New ParameterValues()
        Dim DisVal11 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal11.Value = 1
        ParmVal11.Add(DisVal11)

        Dim ParmVal12 As ParameterValues = New ParameterValues()
        Dim DisVal12 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal12.Value = 1
        ParmVal12.Add(DisVal12)

        Dim ParmVal13 As ParameterValues = New ParameterValues()
        Dim DisVal13 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal13.Value = 1
        ParmVal13.Add(DisVal13)

        Dim ParmVal14 As ParameterValues = New ParameterValues()
        Dim DisVal14 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal14.Value = 1
        ParmVal14.Add(DisVal14)

        Dim ParmVal15 As ParameterValues = New ParameterValues()
        Dim DisVal15 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal15.Value = 1
        ParmVal15.Add(DisVal15)


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
                Rptstr = ("Salary/wages summarty for the period of" & " :- " & SalYear).ToUpper
                ParmVal5.AddValue(Rptstr)

                ParmVal6.AddValue(Salamt)
                ParmVal7.AddValue(Wagamt)
                ParmVal8.AddValue(OvrtimeAmt)
                ParmVal9.AddValue(AdvAmt)
                ParmVal10.AddValue(LonAmt)
                ParmVal11.AddValue(TotDed)
                ParmVal12.AddValue(TotErn)
                ParmVal13.AddValue(Netamt)
                ParmVal14.AddValue(Rolsal)
                ParmVal15.AddValue(Rolwag)

                CrRptSalsumry.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptSalsumry.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptSalsumry.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptSalsumry.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
                CrRptSalsumry.DataDefinition.ParameterFields("Rpttypw").ApplyCurrentValues(ParmVal5)

                CrRptSalsumry.DataDefinition.ParameterFields("@salry").ApplyCurrentValues(ParmVal6)
                CrRptSalsumry.DataDefinition.ParameterFields("@wages").ApplyCurrentValues(ParmVal7)
                CrRptSalsumry.DataDefinition.ParameterFields("@ovrtime").ApplyCurrentValues(ParmVal8)
                CrRptSalsumry.DataDefinition.ParameterFields("@advnce").ApplyCurrentValues(ParmVal9)
                CrRptSalsumry.DataDefinition.ParameterFields("@loninstl").ApplyCurrentValues(ParmVal10)
                CrRptSalsumry.DataDefinition.ParameterFields("@totded").ApplyCurrentValues(ParmVal11)
                CrRptSalsumry.DataDefinition.ParameterFields("@totern").ApplyCurrentValues(ParmVal12)
                CrRptSalsumry.DataDefinition.ParameterFields("@netsal").ApplyCurrentValues(ParmVal13)
                CrRptSalsumry.DataDefinition.ParameterFields("@rolsal").ApplyCurrentValues(ParmVal14)
                CrRptSalsumry.DataDefinition.ParameterFields("@rolwage").ApplyCurrentValues(ParmVal15)

            End While
            CrVewSalSumry.ReportSource = CrRptSalsumry
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()

        End Try

    End Sub

    Private Sub FrmCrRptSalSumry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, 109)

            TellRptstatus = True
            CoprofileParamsEmpInfo()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fetch_empinfo()
        SelRptdata = New SqlDataAdapter("Select empid,empname from finactempmstr inner join finactautosalary on finactempmstr.empid=finactautosalary.aslryempid order by empname", FinActConn)
        Try
            SelRptDtaTble = New DataTable
            SelRptDtaTble.Clear()
            SelRptdata.Fill(SelRptDtaTble)
            Cmbxselemp.DataSource = SelRptDtaTble
            Cmbxselemp.DisplayMember = "empname"
            Cmbxselemp.ValueMember = "Empid"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SelRptdata.Dispose()
        End Try
    End Sub
    Private Sub Chkbx1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkbx1.CheckStateChanged
        If Chkbx1.Checked = True Then
            Cmbxselemp.Enabled = False
        Else
            Cmbxselemp.Enabled = True

        End If
    End Sub

    Private Sub BtnCrptvew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrptvew.Click
        Try
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, Screen.PrimaryScreen.WorkingArea.Height - 50)
            Me.Top = 0
            Me.Left = 0
            delrec_temp_salsumry()
            Fetch_recfortempsalsumry()
            TellRptstatus = False
            CoprofileParamsEmpInfo()
            Me.CrVewSalSumry.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fetch_recfortempsalsumry()
        Try
            Sql_Sal_Slp_Cmd = New SqlCommand("FinAct_Sal_Slp_Select", FinActConn)
            Sql_Sal_Slp_Cmd.CommandType = CommandType.StoredProcedure
            Sql_Sal_Slp_Rdr = Sql_Sal_Slp_Cmd.ExecuteReader
            Dim PdType As String = ""
            While Sql_Sal_Slp_Rdr.Read
                If Sql_Sal_Slp_Rdr.HasRows = True Then
                    Sql_Sal_Slp_Cmd1 = New SqlCommand("finact_Sal_slip_insert", FinActConn1)
                    Sql_Sal_Slp_Cmd1.CommandType = CommandType.StoredProcedure
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pddt", Sql_Sal_Slp_Rdr("Aspddt"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdmnth", Sql_Sal_Slp_Rdr("Aslrymnth"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdconid", Sql_Sal_Slp_Rdr("AsPdConcrnid"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdtyp", Sql_Sal_Slp_Rdr("AsPdType"))

                    PdType = Trim(Sql_Sal_Slp_Rdr("AsPdType"))
                    If Trim(PdType) = "DEEmp" Or Trim(PdType) = "DEEmpESI" Or Trim(PdType) = "DEEmpPF" Or Trim(PdType) = "DEEmpVPF" Then
                        Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdamt1", Sql_Sal_Slp_Rdr("AsPdAmt"))
                        Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdname1", Sql_Sal_Slp_Rdr("pheadslipname"))
                        Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdname", "")
                        Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdamt", 0)
                    Else
                        Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdamt", Sql_Sal_Slp_Rdr("AsPdAmt"))
                        Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdname1", "")
                        Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdname", Sql_Sal_Slp_Rdr("pheadslipname"))
                        Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdamt1", 0)
                    End If

                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@pdernded", Sql_Sal_Slp_Rdr("AsPdErnDeduc"))
                    Sql_Sal_Slp_Cmd1.ExecuteNonQuery()
                End If
            End While
            Sql_Sal_Slp_Cmd1.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql_Sal_Slp_Rdr.Close()
            Sql_Sal_Slp_Cmd = Nothing
        End Try
    End Sub
    Private Sub delrec_temp_salsumry()
        Try
            Sql_Sal_Slp_Cmd = New SqlCommand("delete from temp_salsumry", FinActConn)
            Sql_Sal_Slp_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql_Sal_Slp_Cmd = Nothing
        End Try
    End Sub

    Private Sub Allcontrols_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkbx1.KeyDown, DtpSalslip.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Cmbxselemp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxselemp.GotFocus
        Try
            Me.Cmbxselemp.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxselemp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxselemp.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Cmbxselemp_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxselemp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxselemp.Leave
        Try
            If CheckBlank_Cmbx(Me.Cmbxselemp) = True Then
                Me.BtnCrptvew.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkbx1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkbx1.CheckedChanged

    End Sub
End Class
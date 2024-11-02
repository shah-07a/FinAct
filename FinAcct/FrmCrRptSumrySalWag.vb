Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.Shared
Public Class FrmCrRptSumrySalWag
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
    Dim CrRptSalwag As New CrRptSumrySalWag
    Dim TellRptstatus As Boolean
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
                Fetch_InfoCrRptSalWagrgstr()
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
                Rptstr = ("Salary/Wages register for the period of" & " :- " & SalYear).ToUpper
                'End If
                ParmVal5.AddValue(Rptstr)
                CrRptSalwag.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptSalwag.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptSalwag.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptSalwag.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
                CrRptSalwag.DataDefinition.ParameterFields("Rpttype").ApplyCurrentValues(ParmVal5)
            End While
            CrVewSumSalWag.ReportSource = CrRptSalwag
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            'Odbccon1.Close()
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()

        End Try

    End Sub
    Private Sub Fetch_InfoCrRptSalWagrgstr()
        Try
            SalMonth = DtpSalslip.Value.Month
            SalYear = DtpSalslip.Value.Year
            Dim Salempid As Integer = Cmbxselemp.SelectedValue
            Dim SalMname As String = MonthName(DtpSalslip.Value.Month)
            Dim chktype As String = ""
            If Chkbx1.Checked = True Then
                chktype = Trim("All")
            Else
                chktype = Trim("OnebyOne")
            End If

            Sql_Sal_Slp_Cmd = New SqlCommand("Temp_Salwag_regstr_Select", FinActConn)
            Sql_Sal_Slp_Cmd.CommandType = CommandType.StoredProcedure
            Sql_Sal_Slp_Cmd.Parameters.AddWithValue("@yr", SalYear)
            Sql_Sal_Slp_Cmd.Parameters.AddWithValue("@mnth", SalMonth)
            Sql_Sal_Slp_Cmd.Parameters.AddWithValue("@empid", Salempid)
            Sql_Sal_Slp_Cmd.Parameters.AddWithValue("@chktype", Trim(chktype))
            Dim dssal As New DataSet(Sql_Sal_Slp_Cmd.CommandText)
            Sql_Sal_Slp_Adptr = New SqlDataAdapter(Sql_Sal_Slp_Cmd)
            Sql_Sal_Slp_Adptr.Fill(dssal)
            CrRptSalwag.SetDataSource(dssal.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql_Sal_Slp_Cmd = Nothing
        End Try
    End Sub
    Private Sub FrmCrRptSumrySalWag_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 0
            Me.Left = 10
            Me.Width = 900
            Me.Height = 125
            TellRptstatus = True
            delrec_temp_salwagregstr()
            Fetch_recfortempsalwagregstr()
            Fetch_empinfo()
            CoprofileParamsEmpInfo()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fetch_recfortempsalwagregstr()
        Try
            Sql_Sal_Slp_Cmd = New SqlCommand("Temp_salwagregstr_select", FinActConn)
            Sql_Sal_Slp_Cmd.CommandType = CommandType.StoredProcedure
            Sql_Sal_Slp_Rdr = Sql_Sal_Slp_Cmd.ExecuteReader
            Dim PdType As String = ""
            While Sql_Sal_Slp_Rdr.Read
                If Sql_Sal_Slp_Rdr.HasRows = True Then
                    Sql_Sal_Slp_Cmd1 = New SqlCommand("Temp_salwag_rgstr_Insert", FinActConn1)
                    Sql_Sal_Slp_Cmd1.CommandType = CommandType.StoredProcedure
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@asid", Sql_Sal_Slp_Rdr("AslryId"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@asdt", Sql_Sal_Slp_Rdr("AslryDt"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@Asmnth", Sql_Sal_Slp_Rdr("AslryMnth"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@Astyp", Sql_Sal_Slp_Rdr("AslryType"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@asempid", Sql_Sal_Slp_Rdr("AslryEmpid"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@asename", Sql_Sal_Slp_Rdr("empname"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@asefname", Sql_Sal_Slp_Rdr("empfather"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@asedobdt", Sql_Sal_Slp_Rdr("empdobdt"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@asejndt", Sql_Sal_Slp_Rdr("empjndt"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@ashday", Sql_Sal_Slp_Rdr("AslryWholidys"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@aswday", Sql_Sal_Slp_Rdr("AslryWrkDys"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@asErnAmt", Sql_Sal_Slp_Rdr("AslryErnAmt"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@asOvrtmAmt", Sql_Sal_Slp_Rdr("AslryOvrTmErn"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@asadamt", Sql_Sal_Slp_Rdr("AslryAdvAmt"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@aslnamt", Sql_Sal_Slp_Rdr("AslryLnAmt"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@astern", Sql_Sal_Slp_Rdr("AslryTotlErn"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@astded", Sql_Sal_Slp_Rdr("AslryTotlDeduc"))
                    Sql_Sal_Slp_Cmd1.Parameters.AddWithValue("@asnsal", Sql_Sal_Slp_Rdr("AslryNetSlry"))
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
    Private Sub delrec_temp_salwagregstr()
        Try
            Sql_Sal_Slp_Cmd = New SqlCommand("delete from temp_salwagregstr", FinActConn)
            Sql_Sal_Slp_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql_Sal_Slp_Cmd = Nothing
        End Try
    End Sub

    Private Sub BtnCrptvew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrptvew.Click
        Try
            TellRptstatus = False
            CoprofileParamsEmpInfo()
            Me.Height = 700
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Chkbx1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkbx1.CheckStateChanged
        If Chkbx1.Checked = True Then
            Cmbxselemp.Enabled = False
        Else
            Cmbxselemp.Enabled = True

        End If
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
    Private Sub allControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkbx1.KeyDown, DtpSalslip.KeyDown
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
End Class
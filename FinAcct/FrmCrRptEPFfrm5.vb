Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptEPFfrm5
    Dim EPF_f5_Cmd As SqlCommand
    Dim EPF_f5_Adptr As SqlDataAdapter
    Dim EPF_f5_Rdr As SqlDataReader
    Dim EPF_f5_Cmd1 As SqlCommand
    Dim EPF_f5_tbl As DataTable
    Dim TellRptstatus As Boolean
    Dim CrRptEPF_f5 As New CrRptEPFfrm5
    Dim OdbcCmd1 As OdbcCommand
    Dim Odbcrdr1 As OdbcDataReader

    Private Sub BtnEPf5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEPF5.Click
        Try
            If Trim(txtepfgno.Text) <> "" Then
                Me.Height = 700
                txtepfgno.BackColor = Color.White
                TellRptstatus = False
                CrVewEpfFrm5.Enabled = True
                temp_tblEpf_f5_Del()
                CreatTemp_Epf_f5_tbl()
                CoprofileParamsEPF_f5()
            Else
                txtepfgno.BackColor = Color.Orange
                txtepfgno.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmCrRptEPFfrm5_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Width = 1025
            Me.Height = 80
            TellRptstatus = True
            CoprofileParamsEPF_f5()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CoprofileParamsEPF_f5()
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
        '=====
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
        Dim OnrAdrsparm As New OdbcParameter("@@Onradrs", Odbc.OdbcType.VarChar, 75)
        Dim OnrAdrs1parm As New OdbcParameter("@@Onradrs1", Odbc.OdbcType.VarChar, 75)
        Dim OnrDesiparm As New OdbcParameter("@@OnrDesi", Odbc.OdbcType.VarChar, 50)
        Dim Onrnameparm As New OdbcParameter("@@Onrname", Odbc.OdbcType.VarChar, 50)

        Dim DcrypConame As New EnCryp_DeCryp_String
        Try

            OdbcCmd1 = New OdbcCommand("exec Tempcncrpt_esipf_roc nparm,aparm,aparm1,conparm," _
            & " conparm2,conparm3,pinparm,ctyparm,Esinoparm,Pfnoparm,OnrAdrsparm,OnrAdrs1parm,Onrdesiparm,Onrnameparm", FinactOdbcCon)
            OdbcCmd1.CommandType = CommandType.StoredProcedure '
            Odbcrdr1 = OdbcCmd1.ExecuteReader
            While Odbcrdr1.Read()
                Dim co As Object = DcrypConame.Decrypt(Odbcrdr1("col1"))
                Dim co1 As Object = Odbcrdr1(1)
                Dim co2 As Object = Odbcrdr1(5) & "-" & Odbcrdr1(6)
                Dim co3 As Object = Odbcrdr1(10)
                Dim Onr1 As Object = Odbcrdr1(7) & "," & Odbcrdr1(8)
                Dim Onr2 As Object = Odbcrdr1(9)
                ParmVal1.AddValue(co)
                ParmVal2.AddValue(co1)
                ParmVal3.AddValue(co2)
                ParmVal4.AddValue(Trim(txtepfgno.Text)) 'Owner name
                Dim Rptstr As String = ""
                Rptstr = Odbcrdr1(4)
                ParmVal5.AddValue(Rptstr)
                ParmVal6.AddValue(Dtpick1.Value.Date)
                ParmVal7.AddValue(Trim(Dtpick2.Text))

                If TellRptstatus = False Then
                    Fetch_InfoCrRptEpf_f5()
                End If

                CrRptEPF_f5.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptEPF_f5.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptEPF_f5.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptEPF_f5.DataDefinition.ParameterFields("parmacno").ApplyCurrentValues(ParmVal4)
                CrRptEPF_f5.DataDefinition.ParameterFields("Parmepfcode").ApplyCurrentValues(ParmVal5)
                CrRptEPF_f5.DataDefinition.ParameterFields("parmdate").ApplyCurrentValues(ParmVal6)
                CrRptEPF_f5.DataDefinition.ParameterFields("parmmnth").ApplyCurrentValues(ParmVal7)

            End While
            CrVewEpfFrm5.ReportSource = CrRptEPF_f5
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub
    Private Sub Fetch_InfoCrRptEpf_f5()

        Try
            EPF_f5_Cmd = New SqlCommand("Select * from temp_epf_f5", FinActConn)
            Dim dsEsino As New DataSet(EPF_f5_Cmd.CommandText)
            EPF_f5_Adptr = New SqlDataAdapter(EPF_f5_Cmd)
            EPF_f5_Adptr.Fill(dsEsino)
            CrRptEPF_f5.SetDataSource(dsEsino.Tables(0))
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_f5_Cmd = Nothing

            EPF_f5_Adptr.Dispose()

        End Try
    End Sub
    Private Sub CreatTemp_Epf_f5_tbl()
        Dim F5mnth As Integer = Dtpick2.Value.Month
        Dim F5year As Integer = Dtpick2.Value.Year

        Try
            EPF_f5_Cmd = New SqlCommand("Temp_Epf_f5_Select", FinActConn)
            EPF_f5_Cmd.CommandType = CommandType.StoredProcedure
            EPF_f5_Cmd.Parameters.AddWithValue("@f5yr", F5year)
            EPF_f5_Cmd.Parameters.AddWithValue("@f5mnth", F5mnth)
            EPF_f5_Rdr = EPF_f5_Cmd.ExecuteReader
            While EPF_f5_Rdr.Read
                If EPF_f5_Rdr.HasRows = True Then
                    EPF_f5_Cmd1 = New SqlCommand("Temp_Epf_f5_Insert", FinActConn1)
                    EPF_f5_Cmd1.CommandType = CommandType.StoredProcedure
                    EPF_f5_Cmd1.Parameters.AddWithValue("@f5id", EPF_f5_Rdr("empid"))
                    EPF_f5_Cmd1.Parameters.AddWithValue("@f5name", EPF_f5_Rdr("empname"))
                    EPF_f5_Cmd1.Parameters.AddWithValue("@f5fname", EPF_f5_Rdr("empfather"))
                    Dim Agedt As Date = EPF_f5_Rdr("empdobdt")
                    Dim Curdt As Date = Dtpick1.Value.Date
                    Dim ts As TimeSpan
                    ts = curdt.Subtract(agedt)
                    Dim f5days As Integer = ts.Days
                    Dim f5ageyr As Integer = f5days / 365

                    EPF_f5_Cmd1.Parameters.AddWithValue("@f5age", f5ageyr)
                    EPF_f5_Cmd1.Parameters.AddWithValue("@f5sex", EPF_f5_Rdr("empsex"))
                    EPF_f5_Cmd1.Parameters.AddWithValue("@f5pfjndt", EPF_f5_Rdr("emppfjndt"))
                    EPF_f5_Cmd1.Parameters.AddWithValue("@f5pfno", EPF_f5_Rdr("empnewpfno"))
                    EPF_f5_Cmd1.ExecuteNonQuery()
                End If

            End While
            If EPF_f5_Rdr.HasRows = True Then
                EPF_f5_Cmd1.Dispose()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_f5_Cmd.Dispose()
            EPF_f5_Rdr.Close()

        End Try

    End Sub

    Private Sub temp_tblEpf_f5_Del()
        Try
            EPF_f5_Cmd = New SqlCommand("delete from Temp_Epf_f5", FinActConn)
            EPF_f5_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_f5_Cmd.Dispose()
        End Try
    End Sub
    
   
    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpick1.KeyDown, Dtpick2.KeyDown _
    , txtepfgno.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
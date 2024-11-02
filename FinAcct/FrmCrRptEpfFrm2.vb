Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptEpfFrm2
    Dim EPF_f2_Cmd As SqlCommand
    Dim EPF_f2_Adptr As SqlDataAdapter
    Dim EPF_f2_Rdr As SqlDataReader
    Dim EPF_f2_Rdr2 As SqlDataReader
    Dim EPF_f2_Cmd1 As SqlCommand
    Dim EPF_f2_Cmd2 As SqlCommand
    Dim EPF_f2_tbl As DataTable
    Dim TellRptstatus As Boolean
    Dim CrRptEPF_f2 As New CrRptFrm2
    Dim OdbcCmd1 As OdbcCommand
    Dim Odbcrdr1 As OdbcDataReader
    Dim EpfempidF2 As Integer
   
    Private Sub FrmCrRptEpfFrm2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 1025
            Me.Height = 82
            TellRptstatus = True
            CoprofileParamsEPF_f2()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnEPF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEPF2.Click
        Try
            If Trim(CmbxEpfEmpname.Text) <> "" Then
                CmbxEpfEmpname.BackColor = Color.White
                Me.Height = 700
                TellRptstatus = False
                CrVewEpfFrm2.Enabled = True
                temp_tblEpf_f2_Del()
                CreatTemp_Epf_f2_tbl()
                CoprofileParamsEPF_f2()
            Else
                CrVewEpfFrm2.Enabled = False
                CmbxEpfEmpname.BackColor = Color.Orange
                CmbxEpfEmpname.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CoprofileParamsEPF_f2()

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
                ParmVal4.AddValue(co3) 'Owner name
                Dim Rptstr As String = ""
                Rptstr = Odbcrdr1(4)
                ParmVal5.AddValue(Rptstr)
                ParmVal6.AddValue(Dtpick1.Value.Date)
                ParmVal7.AddValue(Onr2)

                If TellRptstatus = False Then
                    Fetch_InfoCrRptEpf_f2()
                End If

                CrRptEPF_f2.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptEPF_f2.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptEPF_f2.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptEPF_f2.DataDefinition.ParameterFields("onwr").ApplyCurrentValues(ParmVal4)
                CrRptEPF_f2.DataDefinition.ParameterFields("Parmepfcode").ApplyCurrentValues(ParmVal5)
                CrRptEPF_f2.DataDefinition.ParameterFields("parmdate").ApplyCurrentValues(ParmVal6)
                CrRptEPF_f2.DataDefinition.ParameterFields("desi").ApplyCurrentValues(ParmVal7)
                
            End While
            CrVewEpfFrm2.ReportSource = CrRptEPF_f2
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub
    Private Sub Fetch_InfoCrRptEpf_f2()

        Try
            EPF_f2_Cmd = New SqlCommand("Select * from temp_epf_f2", FinActConn)
            Dim dsEsino As New DataSet(EPF_f2_Cmd.CommandText)
            EPF_f2_Adptr = New SqlDataAdapter(EPF_f2_Cmd)
            EPF_f2_Adptr.Fill(dsEsino)
            CrRptEPF_f2.SetDataSource(dsEsino.Tables(0))
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_f2_Cmd = Nothing

            EPF_f2_Adptr.Dispose()

        End Try
    End Sub
    Private Sub CreatTemp_Epf_f2_tbl()
        Dim esirecno As Integer = 1
        Dim esiempstatus As String = ""
        Try
            EPF_f2_Cmd = New SqlCommand("Temp_Epf_f2_Select", FinActConn)
            EPF_f2_Cmd.CommandType = CommandType.StoredProcedure
            EPF_f2_Cmd.Parameters.AddWithValue("@epfempid", EpfempidF2)
            EPF_f2_Rdr = EPF_f2_Cmd.ExecuteReader
            While EPF_f2_Rdr.Read
                If EPF_f2_Rdr.HasRows = True Then
                    EPF_f2_Cmd1 = New SqlCommand("Temp_Epf_f2_Insert", FinActConn1)
                    EPF_f2_Cmd1.CommandType = CommandType.StoredProcedure
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2adrs1", EPF_f2_Rdr("empadrs1"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2adrs2", EPF_f2_Rdr("empadrs2"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2adrs3", EPF_f2_Rdr("empadrs3"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2pin", EPF_f2_Rdr("emppin"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2sex", EPF_f2_Rdr("empsex"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2mari", EPF_f2_Rdr("empmarital"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2father", EPF_f2_Rdr("empfather"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2same", EPF_f2_Rdr("empadrssame"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2name", EPF_f2_Rdr("empname"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2dob", EPF_f2_Rdr("empdobdt"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2jndt", EPF_f2_Rdr("empjndt"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2pfno", EPF_f2_Rdr("empnewpfno"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2ctyname", EPF_f2_Rdr("cscctyname"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2state", EPF_f2_Rdr("cscstatename"))
                    EPF_f2_Cmd1.Parameters.AddWithValue("@f2contry", EPF_f2_Rdr("csccontry"))
                    Try
                        EPF_f2_Cmd2 = New SqlCommand("Temp_EPF_f2tempadrs_select", FinActConn2)
                        EPF_f2_Cmd2.CommandType = CommandType.StoredProcedure
                        EPF_f2_Cmd2.Parameters.AddWithValue("@EpfTempadrsid", EpfempidF2)
                        EPF_f2_Rdr2 = EPF_f2_Cmd2.ExecuteReader
                        While EPF_f2_Rdr2.Read
                            If EPF_f2_Rdr2.HasRows = True Then
                                EPF_f2_Cmd1.Parameters.AddWithValue("@f2tadrs1", EPF_f2_Rdr2("empcuradrs1"))
                                EPF_f2_Cmd1.Parameters.AddWithValue("@f2tadrs2", EPF_f2_Rdr2("empcuradrs2"))
                                EPF_f2_Cmd1.Parameters.AddWithValue("@f2tadrs3", EPF_f2_Rdr2("empcuradrs3"))
                                EPF_f2_Cmd1.Parameters.AddWithValue("@f2tpin", EPF_f2_Rdr2("empcurpin"))
                                EPF_f2_Cmd1.Parameters.AddWithValue("@f2tctyname", EPF_f2_Rdr2("city"))
                                EPF_f2_Cmd1.Parameters.AddWithValue("@f2tstate", EPF_f2_Rdr2("state"))
                                EPF_f2_Cmd1.Parameters.AddWithValue("@f2tcontry", EPF_f2_Rdr2("contry"))
                            End If
                        End While
                    Catch ex1 As Exception
                        MsgBox(ex1.Message)
                    Finally
                        If EPF_f2_Rdr2.HasRows = True Then
                            EPF_f2_Cmd2.Dispose()
                            EPF_f2_Rdr2.Close()
                        End If

                    End Try

                    EPF_f2_Cmd1.ExecuteNonQuery()
                End If

            End While
            If EPF_f2_Rdr.HasRows = True Then
                EPF_f2_Cmd1.Dispose()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_f2_Cmd.Dispose()
            EPF_f2_Rdr.Close()

        End Try

    End Sub

    Private Sub temp_tblEpf_f2_Del()
        Try
            EPF_f2_Cmd = New SqlCommand("delete from Temp_Epf_f2", FinActConn)
            EPF_f2_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_f2_Cmd.Dispose()
        End Try
    End Sub
    Private Sub Fetch_empinfo()
        EPF_f2_Adptr = New SqlDataAdapter("Select empid,empname from finactempmstr" _
        & " inner join finactemppfesi on empid=emppfconcrnid where emppfapli=1 and empjndt<='" & (Dtpick1.Value.Date) & "' order by empname", FinActConn)
        Try
            EPF_f2_tbl = New DataTable
            EPF_f2_tbl.Clear()
            EPF_f2_Adptr.Fill(EPF_f2_tbl)
            CmbxEpfEmpname.DataSource = EPF_f2_tbl
            CmbxEpfEmpname.DisplayMember = "empname"
            CmbxEpfEmpname.ValueMember = "Empid"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_f2_Adptr.Dispose()
        End Try
    End Sub

    Private Sub CmbxEpfEmpname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEpfEmpname.GotFocus
        Fetch_empinfo()
    End Sub

    Private Sub ALLCONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEpfEmpname.KeyDown, Dtpick1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxEpfEmpname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEpfEmpname.Leave
        EpfempidF2 = CmbxEpfEmpname.SelectedValue
    End Sub

    Private Sub Dtpick1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpick1.GotFocus
        Dtpick1.MaxDate = Now.Date
    End Sub

End Class
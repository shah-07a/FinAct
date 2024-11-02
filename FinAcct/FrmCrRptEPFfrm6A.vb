Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptEPFfrm6A
    Dim EPFf6_A_Cmd As SqlCommand
    Dim EPFf6_A_Adptr As SqlDataAdapter
    Dim EPFf6_A_Rdr As SqlDataReader
    Dim EPFf6_A_Cmd1 As SqlCommand
    Dim TellRptstatus As Boolean
    Dim CrRptEPF6a As New CrRptEPFform6_A
    Dim OdbcCmd1 As OdbcCommand
    Dim Odbcrdr1 As OdbcDataReader
    Private Sub FrmCrRptEPFfrm6A_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 1025
            Me.Height = 83
            TellRptstatus = True
            temp_tblEpf_f6a_Del()
            CreatTemp_Epf_f6a_tbl()
            CoprofileParamsEPFf6a()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnEPF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEPF.Click
        Try
            If Trim(TxtAcNo.Text) = "" Then
                TxtAcNo.BackColor = Color.Orange
                TxtAcNo.Focus()
            Else
                TxtAcNo.BackColor = Color.White
                Me.Height = 700
                TellRptstatus = False
                CoprofileParamsEPFf6a()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CoprofileParamsEPFf6a()
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
                Fetch_InfoCrRptEpf_f6a()
            End If
            OdbcCmd1 = New OdbcCommand("exec Tempcncrpt_esipfinfo nparm,aparm,aparm1,conparm,conparm2,conparm3,pinparm,ctyparm,Esinoparm,Pfnoparm", FinactOdbcCon)
            OdbcCmd1.CommandType = CommandType.StoredProcedure '
            Odbcrdr1 = OdbcCmd1.ExecuteReader
            While Odbcrdr1.Read()
                Dim co As Object = DcrypConame.Decrypt(Odbcrdr1("col1"))
                Dim co1 As Object = Odbcrdr1(1)
                Dim co2 As Object = Odbcrdr1(5) & "-" & Odbcrdr1(6)
                Dim co3 As Object = Trim(TxtAcNo.Text)
                ParmVal1.AddValue(co)
                ParmVal2.AddValue(co1)
                ParmVal3.AddValue(co2)
                ParmVal4.AddValue(co3)
                Dim Rptstr As String = ""

                Rptstr = Odbcrdr1(4)

                ParmVal5.AddValue(Rptstr)
                Dim mnthNo As Integer = dtpick2.Value.Month
                Dim mntday As Integer
                Dim chkleap As Date = dtpick2.Value.Date
                If mnthNo = 2 Then
                    If Date.IsLeapYear(chkleap.Year) Then
                        mntday = 29
                    Else
                        mntday = 28
                    End If

                ElseIf mnthNo = 4 Or mnthNo = 6 Or mnthNo = 9 Or mnthNo = 11 Then
                    mntday = 30
                Else
                    mntday = 31
                End If
                Dim Fromdt As Date = DateSerial(Year(Dtpick1.Value.Date), Month(Dtpick1.Value.Date), 1) ')'.AddDays(-1)
                Dim todt As Date = DateSerial(Year(dtpick2.Value.Date), Month(dtpick2.Value.Date), mntday)
                ParmVal6.AddValue(Fromdt)
                ParmVal7.AddValue(todt)
                CrRptEPF6a.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptEPF6a.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptEPF6a.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptEPF6a.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
                CrRptEPF6a.DataDefinition.ParameterFields("Parmesicode").ApplyCurrentValues(ParmVal5)
                CrRptEPF6a.DataDefinition.ParameterFields("parmfromdt").ApplyCurrentValues(ParmVal6)
                CrRptEPF6a.DataDefinition.ParameterFields("parmtodt").ApplyCurrentValues(ParmVal7)
            End While
            CrVewEpF6a.ReportSource = CrRptEPF6a
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub
    Private Sub Fetch_InfoCrRptEpf_f6a()
        Dim Mnth_No As Integer = dtpick2.Value.Month
        Dim Mnth_day As Integer
        Dim chkleap As Date = dtpick2.Value.Date
        If Mnth_No = 2 Then
            If Date.IsLeapYear(chkleap.Year) Then
                Mnth_day = 29
            Else
                Mnth_day = 28
            End If

        ElseIf Mnth_No = 4 Or Mnth_No = 6 Or Mnth_No = 9 Or Mnth_No = 11 Then
            Mnth_day = 30
        Else
            Mnth_day = 31
        End If
        Dim From_dt As Date = DateSerial(Year(Dtpick1.Value.Date), Month(Dtpick1.Value.Date), 1) ')'.AddDays(-1)
        Dim to_dt As Date = DateSerial(Year(dtpick2.Value.Date), Month(dtpick2.Value.Date), Mnth_day)

        Try
            EPFf6_A_Cmd = New SqlCommand("Select * from temp_epf_f6a where epfdate between '" & (From_dt) & "'and '" & (to_dt) & "'  ", FinActConn) ' where epfmnth between '" & (MnthNO_F) & "'and '" & (MnthNO_T) & "' 
            Dim dsEsino As New DataSet(EPFf6_A_Cmd.CommandText)
            EPFf6_A_Adptr = New SqlDataAdapter(EPFf6_A_Cmd)
            EPFf6_A_Adptr.Fill(dsEsino)
            CrRptEPF6a.SetDataSource(dsEsino.Tables(0))
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf6_A_Cmd = Nothing

            EPFf6_A_Adptr.Dispose()

        End Try
    End Sub
    Private Sub CreatTemp_Epf_f6a_tbl()
        Dim esirecno As Integer = 1
        Dim esiempstatus As String = ""
        Try
            EPFf6_A_Cmd = New SqlCommand("Temp_EmpEpf_f6a_Select", FinActConn)
            EPFf6_A_Cmd.CommandType = CommandType.StoredProcedure
            EPFf6_A_Rdr = EPFf6_A_Cmd.ExecuteReader
            While EPFf6_A_Rdr.Read
                If EPFf6_A_Rdr.HasRows = True Then
                    EPFf6_A_Cmd1 = New SqlCommand("Temp_Epf_f6a_Insert", FinActConn1)
                    EPFf6_A_Cmd1.CommandType = CommandType.StoredProcedure
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfid", EPFf6_A_Rdr("aslryempid"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfempname", EPFf6_A_Rdr("empname"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfbamt", EPFf6_A_Rdr("ephedbamt"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfempamt", EPFf6_A_Rdr("aslrypf"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfempvpfamt", EPFf6_A_Rdr("aslryvpf"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfrate", EPFf6_A_Rdr("ephedrate"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfpensnrate", EPFf6_A_Rdr("ephedpensnrate"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfemplrpfamt", EPFf6_A_Rdr("ephedcontriamt"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfemplrpensnamt", EPFf6_A_Rdr("ephedpensnamt"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfempno", EPFf6_A_Rdr("emppfno"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfmnth", EPFf6_A_Rdr("aslrymnth"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfdate", EPFf6_A_Rdr("aslryyear"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epfvpfrate", EPFf6_A_Rdr("empvpfpcent"))
                    EPFf6_A_Cmd1.Parameters.AddWithValue("@epffullbasic", EPFf6_A_Rdr("aslryernamt"))
                    EPFf6_A_Cmd1.ExecuteNonQuery()
                End If

            End While
            If EPFf6_A_Rdr.HasRows = True Then
                EPFf6_A_Cmd1.Dispose()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf6_A_Cmd.Dispose()
            EPFf6_A_Rdr.Close()

        End Try

    End Sub

    Private Sub temp_tblEpf_f6a_Del()
        Try
            EPFf6_A_Cmd = New SqlCommand("delete from Temp_Epf_f6a", FinActConn)
            EPFf6_A_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf6_A_Cmd.Dispose()
        End Try
    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpick1.KeyDown, dtpick2.KeyDown, TxtAcNo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
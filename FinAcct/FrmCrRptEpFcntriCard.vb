Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptEpFcntriCard
    Private Sub FrmCrRptEpFcntriCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 1025
            Me.Height = 83
            TellRptstatus = True

            CoprofileParamsEPF_ContCard()
        Catch ex As Exception

        End Try
    End Sub

    Dim EPF_ConCard_Cmd As SqlCommand
    Dim EPF_ConCard_Adptr As SqlDataAdapter
    Dim EPF_ConCard_tbl As DataTable
    Dim EPF_ConCard_Rdr As SqlDataReader
    Dim EPF_ConCard_Cmd1 As SqlCommand
    Dim TellRptstatus As Boolean
    Dim CrRpt_ContCard As New CrRptEpfContriCard
    Dim OdbcCmd1 As OdbcCommand
    Dim Odbcrdr1 As OdbcDataReader
    Dim EpfEmpId As Integer
    Private Sub BtnEPFcntri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEPFcntri.Click
        Try
            If Trim(TxtAcNo.Text) = "" Then
                TxtAcNo.BackColor = Color.Orange
                TxtAcNo.Focus()
            Else
                TxtAcNo.BackColor = Color.White
                Me.Height = 700
                TellRptstatus = False
                temp_tblEpf__ContCard_Del()
                CreatTemp_Epf__ContCard_tbl()
                CrvewEpfCntriCard.Enabled = True
                CoprofileParamsEPF_ContCard()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CoprofileParamsEPF_ContCard()
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
                Fetch_InfoCrRptEpf__ContCard()
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
                CrRpt_ContCard.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRpt_ContCard.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRpt_ContCard.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRpt_ContCard.DataDefinition.ParameterFields("Parmgrupno").ApplyCurrentValues(ParmVal4)
                CrRpt_ContCard.DataDefinition.ParameterFields("Parmpfcode").ApplyCurrentValues(ParmVal5)
                CrRpt_ContCard.DataDefinition.ParameterFields("parmfromdt").ApplyCurrentValues(ParmVal6)
                CrRpt_ContCard.DataDefinition.ParameterFields("parmtodt").ApplyCurrentValues(ParmVal7)
            End While
            CrvewEpfCntriCard.ReportSource = CrRpt_ContCard
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub
    Private Sub Fetch_InfoCrRptEpf__ContCard()
        

        Try
            EPF_ConCard_Cmd = New SqlCommand("Select * from Temp_Epf_Contri_Card ", FinActConn)
            Dim dsEsino As New DataSet(EPF_ConCard_Cmd.CommandText)
            EPF_ConCard_Adptr = New SqlDataAdapter(EPF_ConCard_Cmd)
            EPF_ConCard_Adptr.Fill(dsEsino)
            CrRpt_ContCard.SetDataSource(dsEsino.Tables(0))
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_ConCard_Cmd = Nothing
            EPF_ConCard_Adptr.Dispose()
        End Try
    End Sub
    Private Sub CreatTemp_Epf__ContCard_tbl()
        Dim esirecno As Integer = 1
        Dim esiempstatus As String = ""
        Try
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
            EPF_ConCard_Cmd = New SqlCommand("Temp_EmpEpf_ContCard_Select", FinActConn)
            EPF_ConCard_Cmd.CommandType = CommandType.StoredProcedure
            EPF_ConCard_Cmd.Parameters.AddWithValue("@Ccardfdt", From_dt)
            EPF_ConCard_Cmd.Parameters.AddWithValue("@Ccardtdt", to_dt)
            EPF_ConCard_Rdr = EPF_ConCard_Cmd.ExecuteReader
            While EPF_ConCard_Rdr.Read
                If EPF_ConCard_Rdr.HasRows = True Then
                    EPF_ConCard_Cmd1 = New SqlCommand("Temp_empEpf_ContCard_Insert", FinActConn1)
                    EPF_ConCard_Cmd1.CommandType = CommandType.StoredProcedure
                    EPF_ConCard_Cmd1.Parameters.AddWithValue("@ccpf", EPF_ConCard_Rdr("epf"))
                    EPF_ConCard_Cmd1.Parameters.AddWithValue("@ccvpf", EPF_ConCard_Rdr("vpf"))
                    EPF_ConCard_Cmd1.Parameters.AddWithValue("@ccmnth", EPF_ConCard_Rdr("mnth"))
                    EPF_ConCard_Cmd1.Parameters.AddWithValue("@cctotlwag", EPF_ConCard_Rdr("total_wages"))
                    EPF_ConCard_Cmd1.Parameters.AddWithValue("@ccemplrpf", EPF_ConCard_Rdr("emplr_contripf"))
                    EPF_ConCard_Cmd1.Parameters.AddWithValue("@ccemplrpnsn", EPF_ConCard_Rdr("emplr_contripensn"))

                    EPF_ConCard_Cmd1.ExecuteNonQuery()
                End If

            End While
            If EPF_ConCard_Rdr.HasRows = True Then
                EPF_ConCard_Cmd1.Dispose()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_ConCard_Cmd.Dispose()
            EPF_ConCard_Rdr.Close()

        End Try

    End Sub

    Private Sub temp_tblEpf__ContCard_Del()
        Try
            EPF_ConCard_Cmd = New SqlCommand("delete from Temp_Epf_Contri_Card", FinActConn)
            EPF_ConCard_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_ConCard_Cmd.Dispose()
        End Try
    End Sub

    Private Sub aLLCONTROL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAcNo.KeyDown, Dtpick1.KeyDown _
    , dtpick2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptEsiContriCard
    Dim EsiROC_Cmd As SqlCommand
    Dim EsiROC_Adptr As SqlDataAdapter
    Dim EsiROC_Rdr As SqlDataReader
    Dim EsiROC_Cmd1 As SqlCommand
    Dim TellRptstatus As Boolean
    Dim CrRptEsiContriCard As New CrRptEsIContriCard
    Dim OdbcCmd1 As OdbcCommand
    Dim Odbcrdr1 As OdbcDataReader
    Dim EsiFdt, EsiTdt As Date
    Dim pdt() As Object
    Dim pamt() As Object
    Dim half1 As Boolean
    Dim M1, M2, M3, M4, M5, M6 As String


    Private Sub BtnEsicntri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEsicntri.Click
        Try
            Dim Mno As Integer = Dtpick1.Value.Month
            If Mno = 4 Then
                M1 = Trim("APR") & "-" & Dtpick1.Value.Year
                M2 = Trim("MAY") & "-" & Dtpick1.Value.Year
                M3 = Trim("JUN") & "-" & Dtpick1.Value.Year
                M4 = Trim("JUL") & "-" & Dtpick1.Value.Year
                M5 = Trim("AUG") & "-" & Dtpick1.Value.Year
                M6 = Trim("SEP") & "-" & Dtpick1.Value.Year
            ElseIf Mno = 10 Then
                M1 = Trim("OCT") & "-" & Dtpick1.Value.Year
                M2 = Trim("NOV") & "-" & Dtpick1.Value.Year
                M3 = Trim("DEC") & "-" & Dtpick1.Value.Year
                M4 = Trim("JAN") & "-" & Dtpick1.Value.Year + 1
                M5 = Trim("FEB") & "-" & Dtpick1.Value.Year + 1
                M6 = Trim("MAR") & "-" & Dtpick1.Value.Year + 1
            Else
                MsgBox("Since return period is half yearly, system does not allow other than April or October as starting month", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            Dim mnthNo1 As Integer = dtpick2.Value.Month
            Dim mntday1 As Integer
            Dim chkleap1 As Date = dtpick2.Value.Date
            Me.Height = 700
            If mnthNo1 = 2 Then
                If Date.IsLeapYear(chkleap1.Year) Then
                    mntday1 = 29
                Else
                    mntday1 = 28
                End If
            ElseIf mnthNo1 = 4 Or mnthNo1 = 6 Or mnthNo1 = 9 Or mnthNo1 = 11 Then
                mntday1 = 30
            Else
                mntday1 = 31
            End If
            EsiFdt = DateSerial(Year(Dtpick1.Value.Date), Month(Dtpick1.Value.Date), 1) ')'.AddDays(-1)
            EsiTdt = DateSerial(Year(dtpick2.Value.Date), Month(dtpick2.Value.Date), mntday1)
            TellRptstatus = False
            temp_tblEsiROC_Del()
            CreatTemp_EsiROC_tbl()
            CoprofileParamsEsiROC()
        Catch ex As Exception
            MsgBox(ex.Message)


        End Try

    End Sub
    Private Sub FrmCrRptEsiContriCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 1025
            Me.Height = 88
            TellRptstatus = True
            CoprofileParamsEsiROC()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CoprofileParamsEsiROC()
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
            '=====
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
                    Rptstr = Odbcrdr1(3)
                    ParmVal5.AddValue(Rptstr)
                    ParmVal7.AddValue(Onr2)


                    If TellRptstatus = False Then
                        ParmVal9.AddValue(M1)
                        ParmVal10.AddValue(M2)
                        ParmVal11.AddValue(M3)
                        ParmVal12.AddValue(M4)
                        ParmVal13.AddValue(M5)
                        ParmVal14.AddValue(M6)
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
                        ParmVal8.AddValue(todt)
                        Fetch_InfoCrRptEsiContri()
                    End If
                    CrRptEsiContriCard.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("Onr").ApplyCurrentValues(ParmVal4)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("Parmesicode").ApplyCurrentValues(ParmVal5)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("parmonrdesi").ApplyCurrentValues(ParmVal7)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("parmfdt").ApplyCurrentValues(ParmVal6)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("parmtdt").ApplyCurrentValues(ParmVal8)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("parmm1").ApplyCurrentValues(ParmVal9)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("parmm2").ApplyCurrentValues(ParmVal10)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("parmm3").ApplyCurrentValues(ParmVal11)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("parmm4").ApplyCurrentValues(ParmVal12)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("parmm5").ApplyCurrentValues(ParmVal13)
                    CrRptEsiContriCard.DataDefinition.ParameterFields("parmm6").ApplyCurrentValues(ParmVal14)
                End While
                CrVewEsiContriCard.ReportSource = CrRptEsiContriCard
            Catch ex As SqlException
                MsgBox(ex.Number & " " & ex.Message)
            Finally
                Odbcrdr1.Close()
                OdbcCmd1.Dispose()
            End Try
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CreatTemp_EsiROC_tbl()
        Dim Fmnth As Integer = EsiFdt.Month
        Dim Tmnth As Integer = EsiTdt.Month
        Dim eid As Integer = 0
        Dim x As Integer
        For x = Fmnth To Tmnth
            Try
                EsiROC_Cmd = New SqlCommand("Temp_Esi_ContriCard_Select", FinActConn)
                EsiROC_Cmd.CommandType = CommandType.StoredProcedure
                EsiROC_Cmd.Parameters.AddWithValue("@E_yr", EsiFdt.Year)
                EsiROC_Cmd.Parameters.AddWithValue("@E_mnth", x)
                EsiROC_Rdr = EsiROC_Cmd.ExecuteReader
                While EsiROC_Rdr.Read
                    If EsiROC_Rdr.HasRows = True Then
                        eid = Trim(EsiROC_Rdr("eid"))
                        EsiROC_Cmd1 = New SqlCommand("Temp_esi_contricard_Insert", FinActConn1)
                        EsiROC_Cmd1.CommandType = CommandType.StoredProcedure
                        EsiROC_Cmd1.Parameters.AddWithValue("@eid1", eid)
                        EsiROC_Cmd1.Parameters.AddWithValue("@mdt", EsiROC_Rdr("dt"))
                        EsiROC_Cmd1.Parameters.AddWithValue("@esi", EsiROC_Rdr("esi"))
                        EsiROC_Cmd1.Parameters.AddWithValue("@totalearn", EsiROC_Rdr("tern"))
                        EsiROC_Cmd1.Parameters.AddWithValue("@emplresi", EsiROC_Rdr("emesi"))
                        EsiROC_Cmd1.Parameters.AddWithValue("@totlesi", EsiROC_Rdr("tesi"))
                        EsiROC_Cmd1.Parameters.AddWithValue("@eid", EsiROC_Rdr("eid"))
                        EsiROC_Cmd1.Parameters.AddWithValue("@wrkdays", EsiROC_Rdr("wdys"))
                        EsiROC_Cmd1.Parameters.AddWithValue("@ename", EsiROC_Rdr("ename"))
                        EsiROC_Cmd1.Parameters.AddWithValue("@ejndt", EsiROC_Rdr("jndt"))
                        EsiROC_Cmd1.Parameters.AddWithValue("@efather", EsiROC_Rdr("efather"))
                        EsiROC_Cmd1.Parameters.AddWithValue("@edptname", EsiROC_Rdr("dept"))
                        EsiROC_Cmd1.Parameters.AddWithValue("@elevdt", EsiROC_Rdr("ldt"))
                        EsiROC_Cmd1.ExecuteNonQuery()
                    End If
                End While
                If EsiROC_Rdr.HasRows = True Then
                    EsiROC_Cmd1.Dispose()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                EsiROC_Cmd.Dispose()
                EsiROC_Rdr.Close()
            End Try

        Next

    End Sub
    Private Sub temp_tblEsiROC_Del()
        Try
            EsiROC_Cmd = New SqlCommand("delete from Temp_Esi_contricard ", FinActConn)
            EsiROC_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiROC_Cmd.Dispose()
        End Try
    End Sub

    Private Sub Fetch_InfoCrRptEsiContri()
        Try
            EsiROC_Cmd = New SqlCommand("Select * from Temp_Esi_contricard", FinActConn)
            Dim dsEsino As New DataSet(EsiROC_Cmd.CommandText)
            EsiROC_Adptr = New SqlDataAdapter(EsiROC_Cmd)
            EsiROC_Adptr.Fill(dsEsino)
            CrRptEsiContriCard.SetDataSource(dsEsino.Tables(0))
            CrVewEsiContriCard.ReportSource = CrRptEsiContriCard
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiROC_Cmd = Nothing
            EsiROC_Adptr.Dispose()
        End Try
    End Sub

   
    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpick1.KeyDown, dtpick2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try


    End Sub
End Class
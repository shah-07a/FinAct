Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptEsiForm6
    Dim EsiF6_Cmd As SqlCommand
    Dim EsiF6_Adptr As SqlDataAdapter
    Dim EsiF6_Rdr As SqlDataReader
    Dim EsiF6_Cmd2 As SqlCommand
    Dim EsiF6_Rdr2 As SqlDataReader
    Dim EsiF6_Cmd1 As SqlCommand
    Dim EsiF6_Rdr1 As SqlDataReader
    Dim TellRptstatus As Boolean
    Dim Esi_Co_Code As String = ""
    Dim CrRptEsino As New CrRptEsiform6
    Dim odbccon1 As OdbcConnection
    Dim OdbcCmd1 As OdbcCommand
    Dim OdbcDa1 As OdbcDataAdapter
    Dim Odbcrdr1 As OdbcDataReader
    Dim OdbcCmd As SqlCommand
    Dim OdbcRdr As SqlDataReader
    Dim OdbcDa As SqlDataAdapter
    Dim RateofBonus As Double

    Private Sub FrmCrRptEsiForm6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 1025
            Me.Height = 82
            TellRptstatus = True
            temp_tblEsiinfo_Del()
            CreatTemp_EsiInfoF6_tbl()
            CoprofileParamsEsiF6()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnBonus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBonus.Click
        Try
            Me.Height = 700
            TellRptstatus = False
            CoprofileParamsEsiF6()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CoprofileParamsEsiF6()

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
                Fetch_InfoCrRptEsiNo()
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
                'If Trim(CmbxSelcat.Text) = "All" Then
                Rptstr = Odbcrdr1(3)
                'End If
                ParmVal5.AddValue(Rptstr)
                ParmVal6.AddValue(Dtpick1.Value)
                ParmVal7.AddValue(dtpick2.Value)

                CrRptEsino.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptEsino.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptEsino.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptEsino.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
                CrRptEsino.DataDefinition.ParameterFields("Parmesicode").ApplyCurrentValues(ParmVal5)
                CrRptEsino.DataDefinition.ParameterFields("parmfromdt").ApplyCurrentValues(ParmVal6)
                CrRptEsino.DataDefinition.ParameterFields("parmtodt").ApplyCurrentValues(ParmVal7)
            End While
            CrVewEsiF6.ReportSource = CrRptEsino
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub
    Private Sub Fetch_InfoCrRptEsiNo()
        Dim MnthNO_F As Integer = Dtpick1.Value.Month
        Dim MnthNO_T As Integer = dtpick2.Value.Month
        Try
            EsiF6_Cmd = New SqlCommand("Select * from temp_esiinfof6 where esimnth between '" & (MnthNO_F) & "'and '" & (MnthNO_T) & "'  and esiamt>0 ", FinActConn)


            Dim dsEsino As New DataSet(EsiF6_Cmd.CommandText)
            EsiF6_Adptr = New SqlDataAdapter(EsiF6_Cmd)
            EsiF6_Adptr.Fill(dsEsino)
            CrRptEsino.SetDataSource(dsEsino.Tables(0))
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiF6_Cmd = Nothing

            EsiF6_Adptr.Dispose()

        End Try
    End Sub
    Private Sub CreatTemp_EsiInfoF6_tbl()
        Dim esirecno As Integer = 1
        Dim esiempstatus As String = ""
        Try
            EsiF6_Cmd = New SqlCommand("Temp_EmpEsiInfo_Select", FinActConn)
            EsiF6_Cmd.CommandType = CommandType.StoredProcedure
            EsiF6_Rdr = EsiF6_Cmd.ExecuteReader
            While EsiF6_Rdr.Read
                If EsiF6_Rdr.HasRows = True Then
                    EsiF6_Cmd1 = New SqlCommand("Temp_EsiInfoF6_Insert", FinActConn1)
                    EsiF6_Cmd1.CommandType = CommandType.StoredProcedure
                    EsiF6_Cmd1.Parameters.AddWithValue("@esiid", EsiF6_Rdr("aslryempid"))
                    EsiF6_Cmd1.Parameters.AddWithValue("@esiempname", EsiF6_Rdr("empname"))
                    EsiF6_Cmd1.Parameters.AddWithValue("@esiwrkdys", EsiF6_Rdr("aslrywrkdys"))
                    EsiF6_Cmd1.Parameters.AddWithValue("@esiernamt", EsiF6_Rdr("aslrytotlern"))
                    EsiF6_Cmd1.Parameters.AddWithValue("@esiamt", EsiF6_Rdr("aslryesi"))
                    EsiF6_Cmd1.Parameters.AddWithValue("@esijndt", EsiF6_Rdr("empjndt"))
                    If Trim(EsiF6_Rdr("empcateg")) = "Working" Then
                        EsiF6_Cmd1.Parameters.AddWithValue("@esiempstatus", "Yes")
                    Else
                        EsiF6_Cmd1.Parameters.AddWithValue("@esiempstatus", "No")
                    End If

                    EsiF6_Cmd1.Parameters.AddWithValue("@esilevdt", EsiF6_Rdr("empothrrelevdt"))
                    EsiF6_Cmd1.Parameters.AddWithValue("@esiempno", EsiF6_Rdr("empesicno"))
                    Dim SalMnth As String = Trim(EsiF6_Rdr("aslrymnth"))
                    Dim MnthNo As Integer = Nothing

                    Select Case SalMnth
                        Case "Janaury"
                            MnthNo = 1
                        Case "February"
                            MnthNo = 2
                        Case "March"
                            MnthNo = 3
                        Case "April"
                            MnthNo = 4
                        Case "May"
                            MnthNo = 5
                        Case "June"
                            MnthNo = 6
                        Case "July"
                            MnthNo = 7
                        Case "August"
                            MnthNo = 8
                        Case "September"
                            MnthNo = 9
                        Case "October"
                            MnthNo = 10
                        Case "November"
                            MnthNo = 11
                        Case "December"
                            MnthNo = 12
                    End Select
                    EsiF6_Cmd1.Parameters.AddWithValue("@esimnth", MnthNo)
                    EsiF6_Cmd1.Parameters.AddWithValue("@esidispnsry", EsiF6_Rdr("empdispensry"))
                    EsiF6_Cmd1.ExecuteNonQuery()
                End If
            End While
            EsiF6_Cmd1.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiF6_Cmd.Dispose()
            EsiF6_Rdr.Close()

        End Try

    End Sub

    Private Sub temp_tblEsiinfo_Del()
        Try
            EsiF6_Cmd = New SqlCommand("delete from Temp_EsiInfoF6 ", FinActConn)
            EsiF6_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiF6_Cmd.Dispose()
        End Try
    End Sub


    Private Sub aLLCONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpick2.KeyDown, Dtpick1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions
Imports CrystalDecisions.Shared

Module MdlCrRptParm
    Dim MsSqlCmd1 As SqlCommand
    Dim MsSqlRdr1 As SqlDataReader
    Dim SqlCmd1 As SqlCommand
    Dim Sqlrdr1 As SqlDataReader
    Dim RestDel_cmd As SqlCommand
    Public TellRptstatus As Boolean
    ''Imports System.Data
    ''Imports System.Data.SqlClient
    ''Imports System.Data.Odbc
    ''Imports CrystalDecisions.CrystalReports.Engine
    ''Imports CrystalDecisions
    ''Imports CrystalDecisions.Shared

    ''Module MdlCrRptParm
    ''    Dim OdbcCmd1 As OdbcCommand
    ''    Dim Odbcrdr1 As OdbcDataReader
    ''    Dim SqlCmd1 As SqlCommand
    ''    Dim Sqlrdr1 As SqlDataReader
    ''    Dim RestDel_cmd As SqlCommand
    ''    Public TellRptstatus As Boolean

    ''Public Sub CoprofileParamsRest_Adrs(ByVal CrRpt As Object, ByVal CrRptVew As Object, ByVal DtRange As Boolean, ByVal Co_Info As Boolean, Optional ByVal DptFrom_xDt As DateTimePicker = Nothing, Optional ByVal DptTo_xDt As DateTimePicker = Nothing)

    ''    Dim ParmVal1 As ParameterValues = New ParameterValues()
    ''    Dim DisVal1 As ParameterDiscreteValue = New ParameterDiscreteValue
    ''    DisVal1.Value = 1
    ''    ParmVal1.Add(DisVal1)

    ''    Dim ParmVal2 As ParameterValues = New ParameterValues()
    ''    Dim DisVal2 As ParameterDiscreteValue = New ParameterDiscreteValue
    ''    DisVal2.Value = 1
    ''    ParmVal2.Add(DisVal2)

    ''    Dim ParmVal3 As ParameterValues = New ParameterValues()
    ''    Dim DisVal3 As ParameterDiscreteValue = New ParameterDiscreteValue
    ''    DisVal3.Value = 1
    ''    ParmVal3.Add(DisVal3)

    ''    Dim ParmVal4 As ParameterValues = New ParameterValues()
    ''    Dim DisVal4 As ParameterDiscreteValue = New ParameterDiscreteValue
    ''    DisVal4.Value = 1
    ''    ParmVal4.Add(DisVal4)

    ''    Dim ParmVal5 As ParameterValues = New ParameterValues()
    ''    Dim DisVal5 As ParameterDiscreteValue = New ParameterDiscreteValue
    ''    DisVal5.Value = 1
    ''    ParmVal5.Add(DisVal5)

    ''    Dim ParmVal6 As ParameterValues = New ParameterValues()
    ''    Dim DisVal6 As ParameterDiscreteValue = New ParameterDiscreteValue
    ''    DisVal6.Value = 1
    ''    ParmVal6.Add(DisVal6)

    ''    Dim ParmVal7 As ParameterValues = New ParameterValues()
    ''    Dim DisVal7 As ParameterDiscreteValue = New ParameterDiscreteValue
    ''    DisVal7.Value = 1
    ''    ParmVal7.Add(DisVal7)
    ''    '=====
    ''    Dim ParmVal8 As ParameterValues = New ParameterValues()
    ''    Dim DisVal8 As ParameterDiscreteValue = New ParameterDiscreteValue
    ''    DisVal8.Value = 1
    ''    ParmVal8.Add(DisVal8)
    ''    '=====
    ''    Dim nparm As New Odbc.OdbcParameter("@@N", Odbc.OdbcType.VarBinary, 200)
    ''    Dim aparm As New Odbc.OdbcParameter("@@a", Odbc.OdbcType.VarChar, 100)
    ''    Dim aparm1 As New Odbc.OdbcParameter("@@a1", Odbc.OdbcType.VarChar, 100)
    ''    Dim conparm As New Odbc.OdbcParameter("@@coN", Odbc.OdbcType.VarChar, 100)
    ''    Dim con2parm As New Odbc.OdbcParameter("@@con2", Odbc.OdbcType.VarChar, 100)
    ''    Dim con3parm As New Odbc.OdbcParameter("@@con3", Odbc.OdbcType.VarChar, 100)
    ''    Dim pinparm As New Odbc.OdbcParameter("@@pin", Odbc.OdbcType.VarChar, 100)
    ''    Dim ctyparm As New Odbc.OdbcParameter("@@cty", Odbc.OdbcType.VarChar, 100)
    ''    Dim EsiNOparm As New Odbc.OdbcParameter("@@TIN", Odbc.OdbcType.VarChar, 50)



    ''    Dim DcrypConame As New EnCryp_DeCryp_String
    ''    Try
    ''        OdbcCmd1 = New OdbcCommand("exec Temp_VssCoAdrs nparm,aparm,aparm1,conparm," _
    ''        & " conparm2,conparm3,pinparm,ctyparm,Tin", FinactOdbcCon1)
    ''        OdbcCmd1.CommandType = CommandType.StoredProcedure '
    ''        Odbcrdr1 = OdbcCmd1.ExecuteReader
    ''        While Odbcrdr1.Read()
    ''            Dim co As Object = DcrypConame.Decrypt(Odbcrdr1("col1"))
    ''            Dim co1 As Object = Odbcrdr1(1) ' col2
    ''            Dim co2 As Object = Odbcrdr1(3) & "-" & Odbcrdr1(4) 'col4 and col5
    ''            Dim co3 As Object = Odbcrdr1(2)
    ''            Dim co4 As Object = Odbcrdr1(5)
    ''            If Co_Info = False Then
    ''                ParmVal1.AddValue("") 'coname
    ''                ParmVal2.AddValue("") 'coadrs
    ''                ParmVal3.AddValue("") ' ctystatecontrypin
    ''                ParmVal4.AddValue("") 'contactnos
    ''                ParmVal5.AddValue("") 'tin
    ''            Else
    ''                ParmVal1.AddValue(co) 'coname
    ''                ParmVal2.AddValue(co1) 'coadrs
    ''                ParmVal3.AddValue(co2) ' ctystatecontrypin
    ''                ParmVal4.AddValue(co3) 'contactnos
    ''                ' ParmVal5.AddValue(co4) 'tin
    ''            End If

    ''            'If DtRange = True Then

    ''            'End If

    ''            CrRpt.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
    ''            CrRpt.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
    ''            CrRpt.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
    ''            CrRpt.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
    ''            ' CrRpt.DataDefinition.ParameterFields("vatTin").ApplyCurrentValues(ParmVal5)

    ''            If DtRange = True Then
    ''                ParmVal6.AddValue(DptFrom_xDt.Value.Date)
    ''                ParmVal7.AddValue(DptTo_xDt.Value.Date)
    ''                CrRpt.DataDefinition.ParameterFields("Fdt").ApplyCurrentValues(ParmVal6)
    ''                CrRpt.DataDefinition.ParameterFields("Tdt").ApplyCurrentValues(ParmVal7)
    ''            End If

    ''        End While
    ''        CrRptVew.ReportSource = CrRpt
    ''    Catch ex As Exception
    ''        MsgBox(ex.Message)
    ''    Finally
    ''        Odbcrdr1.Close()
    ''        OdbcCmd1.Dispose()
    ''    End Try
    ''End Sub


    ''Public Sub Temp_TblDel(ByVal tblname As Object)
    ''    Dim SqlStr As String = "delete from " & (tblname) & ""
    ''    Try
    ''        RestDel_cmd = New SqlCommand(SqlStr, FinActConn1)
    ''        RestDel_cmd.ExecuteNonQuery()
    ''    Catch ex As Exception
    ''        MsgBox(ex.Message)
    ''    Finally
    ''        RestDel_cmd.Dispose()
    ''    End Try
    ''End Sub
    Public Sub CoprofileParamsRest_Adrs(ByVal CrRpt As Object, ByVal CrRptVew As Object, ByVal DtRange As Boolean, ByVal Co_Info As Boolean, Optional ByVal DptFrom_xDt As DateTimePicker = Nothing, Optional ByVal DptTo_xDt As DateTimePicker = Nothing)

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
        '=====

        Dim nparm As New SqlParameter("@@N", SqlDbType.VarBinary, 200)
        Dim aparm As New SqlParameter("@@a", SqlDbType.VarChar, 100)
        Dim aparm1 As New SqlParameter("@@a1", SqlDbType.VarChar, 100)
        Dim conparm As New SqlParameter("@@coN", SqlDbType.VarChar, 100)
        Dim con2parm As New SqlParameter("@@con2", SqlDbType.VarChar, 100)
        Dim con3parm As New SqlParameter("@@con3", SqlDbType.VarChar, 100)
        Dim pinparm As New SqlParameter("@@pin", SqlDbType.VarChar, 100)
        Dim ctyparm As New SqlParameter("@@cty", SqlDbType.VarChar, 100)
        Dim EsiNOparm As New SqlParameter("@@TIN", SqlDbType.VarChar, 50)
        nparm.Direction = ParameterDirection.Output
        aparm.Direction = ParameterDirection.Output
        aparm1.Direction = ParameterDirection.Output
        conparm.Direction = ParameterDirection.Output
        con2parm.Direction = ParameterDirection.Output
        con3parm.Direction = ParameterDirection.Output
        pinparm.Direction = ParameterDirection.Output
        ctyparm.Direction = ParameterDirection.Output
        EsiNOparm.Direction = ParameterDirection.Output




        Dim DcrypConame As New EnCryp_DeCryp_String
        Try
            MsSqlCmd1 = New SqlCommand("Temp_FinactCoAdrs ", FinActConn3)
            MsSqlCmd1.CommandType = CommandType.StoredProcedure
            MsSqlCmd1.Parameters.Add(nparm)
            MsSqlCmd1.Parameters.Add(aparm)
            MsSqlCmd1.Parameters.Add(aparm1)
            MsSqlCmd1.Parameters.Add(conparm)
            MsSqlCmd1.Parameters.Add(con2parm)
            MsSqlCmd1.Parameters.Add(con3parm)
            MsSqlCmd1.Parameters.Add(pinparm)
            MsSqlCmd1.Parameters.Add(ctyparm)
            MsSqlCmd1.Parameters.Add(EsiNOparm)

            MsSqlRdr1 = MsSqlCmd1.ExecuteReader
            While MsSqlRdr1.Read()
                Dim co As Object = DcrypConame.Decrypt(MsSqlRdr1("col1"))
                Dim co1 As Object = MsSqlRdr1("col2") ' col2
                Dim co2 As Object = MsSqlRdr1("col4") & "-" & MsSqlRdr1("col5") 'col4 and col5
                Dim co3 As Object = MsSqlRdr1(2)
                Dim co4 As Object = MsSqlRdr1(5)
                If Co_Info = False Then
                    ParmVal1.AddValue("") 'coname
                    ParmVal2.AddValue("") 'coadrs
                    ParmVal3.AddValue("") ' ctystatecontrypin
                    ParmVal4.AddValue("") 'contactnos
                    ParmVal5.AddValue("") 'tin
                Else
                    ParmVal1.AddValue(co) 'coname
                    ParmVal2.AddValue(co1) 'coadrs
                    ParmVal3.AddValue(co2) ' ctystatecontrypin
                    ParmVal4.AddValue(co3) 'contactnos
                    ParmVal5.AddValue(co4) 'tin
                End If

                'If DtRange = True Then

                'End If

                CrRpt.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRpt.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRpt.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRpt.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
                ' CrRpt.DataDefinition.ParameterFields("Tin").ApplyCurrentValues(ParmVal5)

                If DtRange = True Then
                    ParmVal6.AddValue(DptFrom_xDt.Value.Date)
                    ParmVal7.AddValue(DptTo_xDt.Value.Date)
                    CrRpt.DataDefinition.ParameterFields("Fdt").ApplyCurrentValues(ParmVal6)
                    CrRpt.DataDefinition.ParameterFields("Tdt").ApplyCurrentValues(ParmVal7)
                End If

            End While
            CrRptVew.ReportSource = CrRpt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MsSqlRdr1.Close()
            MsSqlCmd1.Dispose()
        End Try
    End Sub


    Public Sub Temp_TblDel(ByVal tblname As Object)
        Dim SqlStr As String = "delete from " & (tblname) & ""
        Try
            RestDel_cmd = New SqlCommand(SqlStr, FinActConn1)
            RestDel_cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            RestDel_cmd.Dispose()
        End Try
    End Sub



End Module

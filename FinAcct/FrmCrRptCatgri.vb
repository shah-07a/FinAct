Imports System.Collections
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Imports System.Data.Odbc
Imports System.Data.Odbc.OdbcParameter
Public Class FrmCrRptCatgri

    Dim OdbcCmd As OdbcCommand
    Dim OdbcRdr As OdbcDataReader
    Dim Odbccon1 As Odbc.OdbcConnection
    Dim OdbcCmd1 As OdbcCommand
    Dim OdbcRdr1 As OdbcDataReader
    Dim datatbl As New DataTable
    Dim OdbcDa As OdbcDataAdapter
    
    Dim Odbccon As SqlConnection
    
    Dim OdbcDa1 As SqlDataAdapter
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CoprofileParamsbrnchcatgri()
            Me.Height = 700
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CoprofileParamsbrnchcatgri()

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

                'Odbccon = New SqlConnection("Driver={SQL Native Client};Server=.;Database=hrprdata08;Uid=sa;Pwd=sa;")
                'odbccon.open()
                datatbl = New DataTable
                OdbcDa = New OdbcDataAdapter("Select * from Finactdept where depttype ='" & ("Catgri") & "' order by deptname,deptid", FinactOdbcCon)
                OdbcDa.Fill(datatbl)
                Dim CRptCatgri1 As New CrRptCatgri
                CRptCatgri1.SetDataSource(datatbl)
                Try
                    'Odbccon1 = New SqlConnection("Driver={SQL Native Client};Server=.;Database=hrprdata08;Uid=sa;Pwd=sa;")
                    ''Odbccon1.Open()
                    OdbcCmd1 = New OdbcCommand("exec Tempcncrpt nparm,aparm,aparm1,conparm,conparm2,conparm3,pinparm,ctyparm ", FinactOdbcCon1)
                    OdbcCmd1.CommandType = CommandType.StoredProcedure '
                    OdbcRdr1 = OdbcCmd1.ExecuteReader
                    While OdbcRdr1.Read()
                        Dim co As Object = DcrypConame.Decrypt(OdbcRdr1("col1"))
                        ParmVal1.AddValue(co)
                        ParmVal2.AddValue(OdbcRdr1(1))
                        ParmVal3.AddValue(OdbcRdr1(5) & "-" & OdbcRdr1(6))
                        ParmVal4.AddValue(OdbcRdr1(2))
                        CRptCatgri1.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                        CRptCatgri1.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                        CRptCatgri1.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                        CRptCatgri1.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
                    End While
                Catch ex As SqlException
                    MsgBox(ex.Number & " " & ex.Message)
                Finally
                    'Odbccon1.Close()
                    OdbcCmd1.Dispose()
                    OdbcRdr1.Close()
                End Try


                CrVewCatgri.ReportSource = CRptCatgri1
            Catch ex As SqlException
                MsgBox(ex.Number & " " & ex.Message)
            Finally
                'Odbccon.Close()
                OdbcDa.Dispose()
                datatbl.Clear()

            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CrVewCatgri_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrVewCatgri.Load

    End Sub
End Class
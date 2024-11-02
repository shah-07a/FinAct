Imports System.Collections
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.Data.Odbc

Module CrRptCon

    Dim Dta_deptTbl As DataTable
    Dim datadptr As SqlDataAdapter
    Dim Catdt As New DataTable
    Dim dta_deptrow As DataRow
    Dim CatRptcmd As SqlCommand
    Dim CatRptRdr As SqlDataReader
    'Public Odbccon As Odbc.OdbcConnection
    Public Odbccon As SqlConnection
    'Dim OdbcCmd As OdbcCommand
    Dim odbccmd As SqlCommand
    'Dim OdbcdataAdptr As OdbcDataAdapter
    Dim OdbcDataAdptr As SqlDataAdapter



    Public Sub trytble()
        'Odbccon = New SqlConnection("Driver={SQL Native Client};Server=.;Database=hrprdata08;Uid=sa;Pwd=sa;")
        'odbccon.open()
        Dta_deptTbl = New DataTable
        OdbcDataAdptr = New SqlDataAdapter("Select * from finactdept", Odbccon) 'FinActConn)

        Dim ParmVal1 As ParameterValues = New ParameterValues()
        Dim DisVal1 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal1.Value = "Virka solutions "
        Dim co As String = "Virka solutions"
        ParmVal1.Add(DisVal1)
        OdbcdataAdptr.Fill(Dta_deptTbl)

       
        ' FrmCrRptSp.CrVewRpt1.ReportSource = crprt
        OdbcdataAdptr.Dispose()
        Dta_deptTbl.Clear()
        'Odbccon.Close()




    End Sub





   
End Module

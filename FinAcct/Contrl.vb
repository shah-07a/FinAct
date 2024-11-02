
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.IO
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions
Imports System.Drawing.Printing
Imports System.Threading

Module Contrl
    Public StrtDate As Date  'for start date
    Public EndDate As Date   'for end date

    Public FinActConn As SqlConnection
    Public FinActConn1 As SqlConnection
    Public FinActConn2 As SqlConnection
    Public FinActConn3 As SqlConnection
    Public FinactOdbcCon As OdbcConnection
    Public FinactOdbcCon1 As OdbcConnection

    Public BackupCmd As SqlCommand
    Public GroupNamCmd As SqlCommand
    Public GroupNamRdr As SqlDataReader
    Public Conft As SqlConnection
    Dim xChkexisitCmd As SqlCommand
    Dim xChkexisitRdr As SqlDataReader
    Public SqlAdptr As SqlDataAdapter
    Public dtaset As DataSet
    Public FinActRdr As SqlDataReader
    Public FinActCmd As SqlCommand
    Public FinActDset As DataSet
    Public FinActSqlAdptr As SqlDataAdapter
    Public xxCmd As SqlCommand
    Public xxRdr As SqlDataReader

    Public xStr1 As String = ""
    Public xStr2 As String = ""
    Public OkFormat As Boolean
    Dim Dir_Backup As String

    Public Pblc_CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Public Pblc_CurrDate As Date
    Dim Rpt_CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim Rpt_CurrDate As Date
    Public Bakstr As String
    Public xCmbxRefresh As Boolean = False
    Public xConvrtId As Integer = 0
    Public xConVrt_Flag As Boolean = False
    Public xMxDtFlag As Boolean = False
    Public SqlServerName As String = ""


    Public Sub FinActSqlConn()
        Try
            '===The Following Connection Strings are used for Login Qifar@Time1
            ''FinActConn = New SqlConnection("Server=qifar-2880-b-1\SQLEXPRESS,1028;Uid=Qifar@Time1;Pwd=mohd@786rafiqhcl;database=FinAct07") ' connection string for Ms-Sql Express
            ''FinActConn1 = New SqlConnection("Server=qifar-2880-b-1\SQLEXPRESS,1028;Uid=Qifar@Time1;Pwd=mohd@786rafiqhcl;database=FinAct07") 'connection string for Ms-Sql Express
            ''FinActConn2 = New SqlConnection("Server=qifar-2880-b-1\SQLEXPRESS,1028;Uid=Qifar@Time1;Pwd=mohd@786rafiqhcl;database=FinAct07") 'connection string for Ms-Sql Express
            ''FinActConn3 = New SqlConnection("Server=qifar-2880-b-1\SQLEXPRESS,1028;Uid=Qifar@Time1;Pwd=mohd@786rafiqhcl;database=FinAct07") 'connection string for Ms-Sql Express
            ''FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=qifar-2880-b-1\sqlexpress,1028;database=FinAct07;Uid=Qifar@Time1;Pwd=mohd@786rafiqhcl;") ';Uid=sa;Pwd=sa;
            ''FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=qifar-2880-b-1\sqlexpress,1028;database=FinAct07;Uid=Qifar@Time1;Pwd=mohd@786rafiqhcl;") ';Uid=sa;Pwd=sa;

            '===The Following Connection Strings are used for Login Qifar@Time2
            '' FinActConn = New SqlConnection("Server=qifar-2880-b-1\SQLEXPRESS,1030;Uid=Qifar@Time2;Pwd=qifar@time2user;database=FinAct07") ' connection string for Ms-Sql Express
            ''FinActConn1 = New SqlConnection("Server=qifar-2880-b-1\SQLEXPRESS,1030;Uid=Qifar@Time2;Pwd=qifar@time2user;database=FinAct07") 'connection string for Ms-Sql Express
            ''FinActConn2 = New SqlConnection("Server=qifar-2880-b-1\SQLEXPRESS,1030;Uid=Qifar@Time2;Pwd=qifar@time2user;database=FinAct07") 'connection string for Ms-Sql Express
            ''FinActConn3 = New SqlConnection("Server=qifar-2880-b-1\SQLEXPRESS,1030;Uid=Qifar@Time2;Pwd=qifar@time2user;database=FinAct07") 'connection string for Ms-Sql Express
            ''FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=qifar-2880-b-1\sqlexpress,1030;database=FinAct07;Uid=Qifar@Time2;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            ''FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=qifar-2880-b-1\sqlexpress,1030;database=FinAct07;Uid=Qifar@Time2;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;

            '===The Following Connection Strings are used for Login in Time Rubber for Computer Name Server
            ''FinActConn = New SqlConnection("Server=Server\SQLEXPRESS,1085;Uid=Qifar@Time2;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
            ''FinActConn1 = New SqlConnection("Server=Server\SQLEXPRESS,1085;Uid=Qifar@Time2;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") 'connection string for Ms-Sql Express
            ''FinActConn2 = New SqlConnection("Server=Server\SQLEXPRESS,1085;Uid=Qifar@Time2;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") 'connection string for Ms-Sql Express
            ''FinActConn3 = New SqlConnection("Server=Server\SQLEXPRESS,1085;Uid=Qifar@Time2;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") 'connection string for Ms-Sql Express
            ''FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=Server\sqlexpress,1085;database=" & (Db_FinAct) & ";Uid=Qifar@Time2;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            ''FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=Server\sqlexpress,1085;database=" & (Db_FinAct) & ";Uid=Qifar@Time2;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;

            'The Following Connection Strings are used for Login in Time Rubber for Computer Name Server
            '========================
            'FinActConn = New SqlConnection("Server=Server\SQLEXPRESS,1030;Uid=Qifar@Time2;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
            'FinActConn1 = New SqlConnection("Server=Server\SQLEXPRESS,1030;Uid=Qifar@Time2;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
            'FinActConn2 = New SqlConnection("Server=Server\SQLEXPRESS,1030;Uid=Qifar@Time2;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
            'FinActConn3 = New SqlConnection("Server=Server\SQLEXPRESS,1030;Uid=Qifar@Time2;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
            'FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Server Native Client 10.0};Server=Server\SQLEXPRESS,1030;database=" & (Db_FinAct) & ";Uid=Qifar@Time2;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            'FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Server Native Client 10.0};Server=Server\SQLEXPRESS,1030;database=" & (Db_FinAct) & ";Uid=Qifar@Time2;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            '==================================================
            FinActConn = New SqlConnection("Server='" & (SqlServerName) & "';Uid=jonnis;Pwd=mohd@786#jonni;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
            FinActConn1 = New SqlConnection("Server='" & (SqlServerName) & "';Uid=jonnis;Pwd=mohd@786#jonni;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
            FinActConn2 = New SqlConnection("Server='" & (SqlServerName) & "';Uid=jonnis;Pwd=mohd@786#jonni;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
            FinActConn3 = New SqlConnection("Server='" & (SqlServerName) & "';Uid=jonnis;Pwd=mohd@786#jonni;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
            ' FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Server Native Client 10.0};Server=" & (SqlServerName) & ";database=" & (Db_FinAct) & ";Uid=jonnis;Pwd=mohd@786#jonni;") ';Uid=sa;Pwd=sa;
            ' FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Server Native Client 10.0};Server=" & (SqlServerName) & ";database=" & (Db_FinAct) & ";Uid=jonnis;Pwd=mohd@786#jonni;") ';Uid=sa;Pwd=sa;
            ''FinActConn = New SqlConnection("Data Source=192.168.1.1\GR_SERVER\EZEESQLEXP,1042;Initial Catalog=Finact10;User ID=Qifar@Time2;Password=qifar@time2user;")
            '==================================================
            '===TIME INDIA SETTING FOR MSSQL EXPRESS 2005
            ''FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=" & (SqlServerName) & ";database=" & (Db_FinAct) & ";Uid=Qifar@Time2;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            ''FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=" & (SqlServerName) & ";database=" & (Db_FinAct) & ";Uid=Qifar@Time2;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            '========================
            ' FinActConn = New SqlConnection("Data Source=203.134.217.254,49157;Network Library=DBMSSOCN;Initial Catalog=Finact10;User ID=Qifar@Time2;Password=qifar@time2user;")
            ' ''********************************************
            '' ''***Following connection strings are for attached db file

            ''Dim strngcon As String = GetSqlDB()
            ''FinActConn = New SqlConnection(strngcon)
            ''FinActConn1 = New SqlConnection(strngcon)
            ''FinActConn2 = New SqlConnection(strngcon)
            ''FinActConn3 = New SqlConnection(strngcon)
            ''FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=.\sqlexpress;Database=FinAct07;Trusted_Connection=yes;")
            ''FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=.\sqlexpress;Database=FinAct07;Trusted_Connection=yes;")
            'FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=.\SQLExpress;AttachDbFilename=" & Application.StartupPath & "\Finact07.MDF;Trusted_Connection=yes;")
            'FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=.\SQLExpress;AttachDbFilename=" & Application.StartupPath & "\Finact07.MDF;Trusted_Connection=yes;")

            '-========================================================================================================
            'VISTA COMPETIBAL CONNECTIONS
            '========================
            '===The Following Connection Strings are used for Login Qifar@Time2
            ''FinActConn = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@Time1;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
            ''FinActConn1 = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@Time1;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") 'connection string for Ms-Sql Express
            ''FinActConn2 = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@Time1;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") 'connection string for Ms-Sql Express
            ''FinActConn3 = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@Time1;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") 'connection string for Ms-Sql Express
            ''FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=Qifar_Info_786\sqlexpress,1030;database=" & (Db_FinAct) & ";Uid=Qifar@Time1;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            ''FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=Qifar_Info_786\sqlexpress,1030;database=" & (Db_FinAct) & ";Uid=Qifar@Time1;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            '========================

            ''FinActConn = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@Time1;Pwd=qifar@time2user;database=TempFinact07") ' connection string for Ms-Sql Express
            ''FinActConn1 = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@Time1;Pwd=qifar@time2user;database=TempFinact07") 'connection string for Ms-Sql Express
            ''FinActConn2 = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@Time1;Pwd=qifar@time2user;database=TempFinact07") 'connection string for Ms-Sql Express
            ''FinActConn3 = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@Time1;Pwd=qifar@time2user;database=TempFinact07") 'connection string for Ms-Sql Express
            ''FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=Qifar_Info_786\sqlexpress,1030;database=TempFinact07;Uid=Qifar@Time1;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            ''FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=Qifar_Info_786\sqlexpress,1030;database=TempFinact07;Uid=Qifar@Time1;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;

            '========================
            'LTG Connection Accounts
            '=======================
            ''FinActConn = New SqlConnection("Server=.\SQLEXPRESS;Uid=Qifar@Time1;Pwd=qifar@time2user;database=MsSql08_FinAct07") ' connection string for Ms-Sql Express
            ''FinActConn1 = New SqlConnection("Server=.\SQLEXPRESS;Uid=Qifar@Time1;Pwd=qifar@time2user;database=MsSql08_FinAct07") ' connection string for Ms-Sql Express
            ''FinActConn2 = New SqlConnection("Server=.\SQLEXPRESS;Uid=Qifar@Time1;Pwd=qifar@time2user;database=MsSql08_FinAct07") ' connection string for Ms-Sql Express
            ''FinActConn3 = New SqlConnection("Server=.\SQLEXPRESS;Uid=Qifar@Time1;Pwd=qifar@time2user;database=MsSql08_FinAct07") ' connection string for Ms-Sql Express
            ''FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=.\sqlexpress;database=MsSql08_FinAct07;Uid=Qifar@Time1;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            ''FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=.\sqlexpress;database=MsSql08_FinAct07;Uid=Qifar@Time1;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;

            '===The Following Connection Strings are used for Login in KBl Sales for Computer Name GR_SERVER
            ''FinActConn = New SqlConnection("Server=GR_Server\SQLEXPRESS,1056;Uid=Qifar@SqlKBL;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
            ''FinActConn1 = New SqlConnection("Server=GR_Server\SQLEXPRESS,1056;Uid=Qifar@SqlKBL;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") 'connection string for Ms-Sql Express
            ''FinActConn2 = New SqlConnection("Server=GR_Server\SQLEXPRESS,1056;Uid=Qifar@SqlKBL;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") 'connection string for Ms-Sql Express
            ''FinActConn3 = New SqlConnection("Server=GR_Serverr\SQLEXPRESS,1056;Uid=Qifar@SqlKBL;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") 'connection string for Ms-Sql Express
            ''FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=GR_Server\sqlexpress,1056;database=" & (Db_FinAct) & ";Uid=Qifar@SqlKBL;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            ''FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=GR_Server\sqlexpress,1056;database=" & (Db_FinAct) & ";Uid=Qifar@SqlKBL;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;

            ''FinActConn = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@SqlKBL;Pwd=qifar@time2user;database=MsSql08_FinAct_KblSales09") ' connection string for Ms-Sql Express
            ''FinActConn1 = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@SqlKBL;Pwd=qifar@time2user;database=MsSql08_FinAct_KblSales09") 'connection string for Ms-Sql Express
            ''FinActConn2 = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@SqlKBL;Pwd=qifar@time2user;database=MsSql08_FinAct_KblSales09") 'connection string for Ms-Sql Express
            ''FinActConn3 = New SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@SqlKBL;Pwd=qifar@time2user;database=MsSql08_FinAct_KblSales09") 'connection string for Ms-Sql Express
            ''FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=Qifar_Info_786\SQLEXPRESS,1030;database=MsSql08_FinAct_KblSales09;Uid=Qifar@SqlKBL;Pwd=qifar@time2user;") ';Uid=sa;Pwd=sa;
            ''FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=Qifar_Info_786\SQLEXPRESS,1030;database=MsSql08_FinAct_KblSales09;Uid=Qifar@SqlKBL;Pwd=qifar@time2user;")  ';Uid=sa;Pwd=sa;
            ''===========================================

           
        Catch ex As SqlException
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub FinActSqlConn1()
        'FinActConn1 = New SqlConnection("integrated security=SSPI;data source=.;persist security info=False;initial catalog=FinAct07") ' Connection for server on nerworking mssql 2000
        '' FinActConn1 = New SqlConnection("integrated security=SSPI;data source=.\SQLEXPRESS;persist security info=False;initial catalog=FinAct07") 'connection string for Ms-Sql Express
        '++++
        'Dim path As String = Application.StartupPath
        'BnMBillingConn1 = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=path\Database1.mdf;Integrated Security=True;User Instance=True")
        'Dim strngcon As String = GetSqlDB()
        'BnMBillingConn1 = New SqlConnection(strngcon)

        '++++
    End Sub
    Public Function GetSqlDB() As String
        Dim st As String = ""
        st = "integrated security=SSPI;data source=.\SQLEXPRESS;persist security info=False;initial catalog=FinAct07"
        ''st = "Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\Finact07.MDF;Integrated Security=True;User Instance=True;"
        ' st = "Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\Finact07.MDF;Integrated Security=True;User Instance=True;"
        'SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=;Integrated Security=True;Connect Timeout=30;User Instance=True");
        Return st
    End Function

    Public Sub FinActSqlConn2()
        'FinActConn2 = New SqlConnection("integrated security=SSPI;data source=.;persist security info=False;initial catalog=FinAct07") ' Connection for server on nerworking mssql 2000
        ''FinActConn2 = New SqlConnection("integrated security=SSPI;data source=.\SQLEXPRESS;persist security info=False;initial catalog=FinAct07") 'connection string for Ms-Sql Express
    End Sub
    Public Sub FinActSqlConn3()
        'FinActConn3 = New SqlConnection("integrated security=SSPI;data source=.;persist security info=False;initial catalog=FinAct07") ' Connection for server on nerworking mssql 2000
        ' FinActConn3 = New SqlConnection("workstation id=(local);packet size=4096;integrated security=SSPI;data source=.;persist security info=False;initial catalog=master")
        '' FinActConn3 = New SqlConnection("integrated security=SSPI;data source=.\SQLEXPRESS;persist security info=False;initial catalog=FinAct07") 'connection string for Ms-Sql Express
    End Sub

    Public Sub FinactOdbcConn()
        'FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=.\sqlexpress;Database=FinAct07;Trusted_Connection=yes;") ';Uid=sa;Pwd=sa;
        'FinactOdbcCon = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=.;Database=hrprdata08;Trusted_Connection=yes;") ';Uid=sa;Pwd=sa;
        'FinActConn4 = New SqlConnection("integrated security=SSPI;data source=.\SQLEXPRESS;persist security info=False;initial catalog=HrPrData08") 'connection string for Ms-Sql Express
        'FinActConn4 = New SqlConnection("Data Source=(local);Initial Catalog=HrPrData08;Integrated Security=True")
    End Sub
    Public Sub FinactOdbcConn1()
        'FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=.\sqlexpress;Database=FinAct07;Trusted_Connection=yes;") ';Uid=sa;Pwd=sa;
        'FinactOdbcCon1 = New Odbc.OdbcConnection("Driver={SQL Native Client};Server=.;Database=hrprdata08;Trusted_Connection=yes;") ';Uid=sa;Pwd=sa;
        'FinActConn5 = New SqlConnection("integrated security=SSPI;data source=.\SQLEXPRESS;persist security info=False;initial catalog=HrPrData08") 'connection string for Ms-Sql Express
        ' FinActConn5 = New SqlConnection("Data Source=(local);Initial Catalog=HrPrData08;Integrated Security=True")
    End Sub
    Public Sub CsCcmbxRecrd(ByVal CboxCty As ComboBox, ByVal CboxState As ComboBox, ByVal CboxContry As ComboBox)
        CoCmbxRecrd = New SqlCommand("Select distinct(cscctyname) from finactcscmstr order by cscctyname", FinActConn)
        CoCmBxRdr = CoCmbxRecrd.ExecuteReader
        Try
            CboxCty.Items.Clear()
            While CoCmBxRdr.Read
                CboxCty.Items.Add(Trim(CoCmBxRdr("Cscctyname")))
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
            Exit Try
        Finally
            CoCmBxRdr.Close()
            CoCmbxRecrd = Nothing
        End Try
        CoCmbxRecrd = New SqlCommand("Select distinct (cscstatename) from finactcscmstr order by cscstatename", FinActConn)
        CoCmBxRdr = CoCmbxRecrd.ExecuteReader
        Try
            CboxState.Items.Clear()
            While CoCmBxRdr.Read
                CboxState.Items.Add(Trim(CoCmBxRdr("Cscstatename")))
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
            Exit Try
        Finally
            CoCmBxRdr.Close()
            CoCmbxRecrd = Nothing
        End Try
        CoCmbxRecrd = New SqlCommand("Select distinct(csccontry) from finactcscmstr order by csccontry", FinActConn)
        CoCmBxRdr = CoCmbxRecrd.ExecuteReader
        Try
            CboxContry.Items.Clear()
            While CoCmBxRdr.Read
                CboxContry.Items.Add(Trim(CoCmBxRdr("Csccontry")))
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
            Exit Try
        Finally
            CoCmBxRdr.Close()
            CoCmbxRecrd = Nothing
        End Try
    End Sub
    Public Function Searchstring(ByVal StringToSearch As String, ByVal StringToFind As String) As String

        Dim Char1 As String
        Dim Newword As String = ""
        Dim intStartingFrom, intCount As Long
        intCount = Len(StringToSearch) + 1
        Do Until intStartingFrom >= intCount
            intStartingFrom = intStartingFrom + 1
            Char1 = Mid$(StringToSearch.ToUpper, intStartingFrom, 1)
            Newword = Newword & Char1
            If Newword = StringToFind Then
                OkFormat = True
                Exit Do
            Else
                OkFormat = False
            End If
        Loop
        Searchstring = Newword
    End Function
    Public Sub BackRestoreDB1()
        Dim Sqlstr As String
        Try
            If Dir_Backup <> Nothing Then
                If Not System.IO.Directory.Exists(Dir_Backup) Then
                    System.IO.Directory.CreateDirectory(Dir_Backup)
                End If
            Else
                If Not System.IO.Directory.Exists(BacUp + "\backup") Then
                    System.IO.Directory.CreateDirectory(BacUp + "\backup")
                End If

                Dir_Backup = BacUp + "\backup"
            End If
            Bakstr = Dir_Backup
            Dim Dtstr As String = Db_FinAct & "_" & Format(Now, "ddMMyyyhhmmss")
            Bakstr += "\DataBackup" & Dtstr & ".bak"
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Sqlstr = "backup database " & (Db_FinAct) & " to disk='" + Bakstr + "' with name='Finact10_ backup all',description='Full Backup Of MyDataBase'"    'SQL statement for backup
            ' Sqlstr = "RESTORE DATABASE { stock_manager| @database_name_var } [ FROM < '" + Bakstr + "\stock_manager.bak' with name='stock_manager '  > [ ,...n ] ] " 'SQL statement for restoring
            Dim xxFileName As String = Bakstr '+ "\DataBackup" & Dtstr & ".bak"
            Dim fileExists1 As Boolean
            fileExists1 = My.Computer.FileSystem.FileExists(xxFileName)
            If fileExists1 = True Then
                My.Computer.FileSystem.DeleteFile(xxFileName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                BackupCmd = New SqlClient.SqlCommand(Sqlstr, FinActConn)
                FrmMainMdi.Cursor = Cursors.WaitCursor
                BackupCmd.ExecuteNonQuery()
                FrmMainMdi.Cursor = Cursors.Default
            Else
                BackupCmd = New SqlClient.SqlCommand(Sqlstr, FinActConn)
                FrmMainMdi.Cursor = Cursors.WaitCursor
                BackupCmd.ExecuteNonQuery()
                FrmMainMdi.Cursor = Cursors.Default
            End If


            Dim SaveFileDialog As New SaveFileDialog
            SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            SaveFileDialog.Filter = "Backup Files (*.bak)|*.bak|Sql Files (*.sql)|*.sql"
            SaveFileDialog.OverwritePrompt = False
            Dim Xfilename As String = IO.Path.GetFileName(xxFileName)
            If (SaveFileDialog.ShowDialog(FrmMainMdi) = System.Windows.Forms.DialogResult.OK) Then
                Dim FileName As String = SaveFileDialog.FileName
                Dim fileExists As Boolean
                fileExists = My.Computer.FileSystem.FileExists(FileName)

                If fileExists = True Then
                    If MessageBox.Show("There is already a file with the same name in this location. Would you like to over write it?", "Data Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        My.Computer.FileSystem.DeleteFile(FileName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                        My.Computer.FileSystem.CopyFile(xxFileName, FileName)
                    Else
                        MsgBox("Current command has been terminated.", MsgBoxStyle.Information, FrmMainMdi.Text)
                        Return
                    End If
                Else
                    My.Computer.FileSystem.CopyFile(xxFileName, FileName)
                End If
                MsgBox("Backup of database currently  in use has been taken successfully", MsgBoxStyle.Information, FrmMainMdi.Text)
            Else
                MsgBox("Backup of database currently  in use could not be taken.", MsgBoxStyle.Information, FrmMainMdi.Text)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            BackupCmd.Dispose()
        End Try
    End Sub
    Public Sub AutoDataBackup()
        Dim Sqlstr As String
        Try
            If Dir_Backup <> Nothing Then
                If Not System.IO.Directory.Exists(Dir_Backup) Then
                    System.IO.Directory.CreateDirectory(Dir_Backup)
                End If
            Else
                If Not System.IO.Directory.Exists(BacUp + "\backup") Then
                    System.IO.Directory.CreateDirectory(BacUp + "\backup")
                End If

                Dir_Backup = BacUp + "\backup"
            End If
            Bakstr = Dir_Backup
            Dim Dtstr As String = Format(Now, "ddMMyyyhhmmss")
            Bakstr += "\DataBackup" & Dtstr & ".bak"
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            Sqlstr = "backup database " & (Db_FinAct) & " to disk='" + Bakstr + "' with name='Finact09_ backup all',description='Full Backup Of MyDataBase'"    'SQL statement for backup
            ' Sqlstr = "RESTORE DATABASE { stock_manager| @database_name_var } [ FROM < '" + Bakstr + "\stock_manager.bak' with name='stock_manager '  > [ ,...n ] ] " 'SQL statement for restoring
            Dim xxFileName As String = Bakstr '+ "\DataBackup" & Dtstr & ".bak"
            Dim fileExists1 As Boolean
            fileExists1 = My.Computer.FileSystem.FileExists(xxFileName)
            If fileExists1 = True Then
                My.Computer.FileSystem.DeleteFile(xxFileName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                BackupCmd = New SqlClient.SqlCommand(Sqlstr, FinActConn)
                FrmMainMdi.Cursor = Cursors.WaitCursor
                BackupCmd.ExecuteNonQuery()
                FrmMainMdi.Cursor = Cursors.Default
            Else
                BackupCmd = New SqlClient.SqlCommand(Sqlstr, FinActConn)
                FrmMainMdi.Cursor = Cursors.WaitCursor
                BackupCmd.ExecuteNonQuery()
                FrmMainMdi.Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckAcess_Btn(ByVal BtnnSave As Button, _
      ByVal BtnnEdt As Button, ByVal BtnnDel As Button)
        Select Case Trim(AcessRight)
            Case "OwnrFull"
                BtnnSave.Enabled = True
                BtnnEdt.Enabled = True
                BtnnDel.Enabled = True
            Case "DataEntry"
                BtnnSave.Enabled = True
                BtnnEdt.Enabled = False
                BtnnDel.Enabled = False
            Case "DataEntryMstr"
                BtnnSave.Enabled = True
                BtnnEdt.Enabled = False
                BtnnDel.Enabled = False
        End Select
    End Sub

    Public Sub CheckAcess_MenuItems_false()
        Select Case Trim(AcessRight)
            Case "DataEntry"
                FrmMainMdi.COMPANYPROFILESToolStripMenuItem.Enabled = False
                FrmMainMdi.BACKUPToolStripMenuItem.Enabled = False
                FrmMainMdi.RESTOREToolStripMenuItem.Enabled = False
                FrmMainMdi.MASTERToolStripMenuItem1.Enabled = False

                FrmMainMdi.COMPANYPROFILESToolStripMenuItem.Visible = False
                FrmMainMdi.BACKUPToolStripMenuItem.Visible = False
                FrmMainMdi.RESTOREToolStripMenuItem.Visible = False
                FrmMainMdi.MASTERToolStripMenuItem1.Visible = False

            Case "DataEntryMstr"
                FrmMainMdi.COMPANYPROFILESToolStripMenuItem.Enabled = False

            Case "View"
                FrmMainMdi.COMPANYPROFILESToolStripMenuItem.Enabled = False
                FrmMainMdi.BACKUPToolStripMenuItem.Enabled = False
                FrmMainMdi.RESTOREToolStripMenuItem.Enabled = False
                FrmMainMdi.MASTERToolStripMenuItem1.Enabled = False
                FrmMainMdi.TRANSACTIONToolStripMenuItem.Enabled = False

            Case "ViewPrint"
                FrmMainMdi.COMPANYPROFILESToolStripMenuItem.Enabled = False
                FrmMainMdi.BACKUPToolStripMenuItem.Enabled = False
                FrmMainMdi.RESTOREToolStripMenuItem.Enabled = False
                FrmMainMdi.MASTERToolStripMenuItem1.Enabled = False
                FrmMainMdi.TRANSACTIONToolStripMenuItem.Enabled = False

            Case "PayRoll"
                FrmMainMdi.COMPANYPROFILESToolStripMenuItem.Enabled = False
                FrmMainMdi.BACKUPToolStripMenuItem.Enabled = False
                FrmMainMdi.RESTOREToolStripMenuItem.Enabled = False
                FrmMainMdi.GROUPMASTERToolStripMenuItem.Enabled = False
                FrmMainMdi.ACCOUNTMASTERToolStripMenuItem.Enabled = False



            Case "ESSTx"
                FrmMainMdi.COMPANYPROFILESToolStripMenuItem.Enabled = False
                FrmMainMdi.BACKUPToolStripMenuItem.Enabled = False
                FrmMainMdi.RESTOREToolStripMenuItem.Enabled = False
                FrmMainMdi.MASTERToolStripMenuItem1.Enabled = False
                FrmMainMdi.TRANSACTIONToolStripMenuItem.Enabled = False
                FrmMainMdi.REPORTSToolStripMenuItem.Enabled = False

            Case "IncomeTx"
                FrmMainMdi.COMPANYPROFILESToolStripMenuItem.Enabled = False
                FrmMainMdi.BACKUPToolStripMenuItem.Enabled = False
                FrmMainMdi.RESTOREToolStripMenuItem.Enabled = False
                FrmMainMdi.MASTERToolStripMenuItem1.Enabled = False
                FrmMainMdi.TRANSACTIONToolStripMenuItem.Enabled = False

            Case "AllTx"
                FrmMainMdi.COMPANYPROFILESToolStripMenuItem.Enabled = False
                FrmMainMdi.BACKUPToolStripMenuItem.Enabled = False
                FrmMainMdi.RESTOREToolStripMenuItem.Enabled = False
                FrmMainMdi.MASTERToolStripMenuItem1.Enabled = False
                FrmMainMdi.TRANSACTIONToolStripMenuItem.Enabled = False
                FrmMainMdi.REPORTSToolStripMenuItem.Enabled = False

        End Select
    End Sub
    Public Sub CheckAcess_MenuItems_True()
        FrmMainMdi.LOGINToolStripMenuItem.Enabled = True
        FrmMainMdi.LOGOUTToolStripMenuItem.Enabled = True
        FrmMainMdi.CHANGEPASSToolStripMenuItem1.Enabled = True
        FrmMainMdi.COMPANYPROFILESToolStripMenuItem.Enabled = True
        FrmMainMdi.BACKUPToolStripMenuItem.Enabled = True
        FrmMainMdi.RESTOREToolStripMenuItem.Enabled = True
        FrmMainMdi.MASTERToolStripMenuItem1.Enabled = True
        FrmMainMdi.GROUPMASTERToolStripMenuItem.Enabled = True
        FrmMainMdi.ACCOUNTMASTERToolStripMenuItem.Enabled = True
        FrmMainMdi.TRANSACTIONToolStripMenuItem.Enabled = True
        FrmMainMdi.REPORTSToolStripMenuItem.Enabled = True
        FrmMainMdi.HRPAYROLLToolStripMenuItem.Enabled = True
        FrmMainMdi.CONFIGURESToolStripMenuItem.Enabled = True
        FrmMainMdi.FEATURESToolStripMenuItem.Enabled = True

        FrmMainMdi.CREATENEWUSERToolStripMenuItem.Enabled = True

    End Sub
    Public Sub ChkGroupName()
        Try
            GroupNamCmd = New SqlCommand("Finact_Set_InitialValues", FinActConn)
            GroupNamCmd.CommandType = CommandType.StoredProcedure
            GroupNamCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            GroupNamCmd.Dispose()
        End Try

    End Sub

    Public Sub CheckAcess_MenuItems_True_To_False()
        ''''FrmMainMdi.MenuItem2.Enabled = False
        ''''FrmMainMdi.MenuItem3.Enabled = False
        ''''FrmMainMdi.MenuItem7.Enabled = False
        ''''FrmMainMdi.MenuItem4.Enabled = False
        ''''FrmMainMdi.MenuItem6.Enabled = False
        ''''FrmMainMdi.MenuItem8.Enabled = False
        ''''FrmMainMdi.MenuItem9.Enabled = False
        ''''FrmMainMdi.MenuItem11.Enabled = False
        ''''FrmMainMdi.MenuItem12.Enabled = False
        ''''FrmMainMdi.MenuItem13.Enabled = False
        ''''FrmMainMdi.MenuItem14.Enabled = False
        ''''FrmMainMdi.MenuItem15.Enabled = False
        ''''FrmMainMdi.MenuItem25.Enabled = False
        ''''FrmMainMdi.MenuItem26.Enabled = False
        ''''FrmMainMdi.MenuItem21.Enabled = False
        ''''FrmMainMdi.MenuItem22.Enabled = False
        ' ''FrmMainMdi.MenuItem28.Enabled = False
        ''''FrmMainMdi.MenuItem34.Enabled = False
        ''''FrmMainMdi.MenuItem35.Enabled = False
        ''''FrmMainMdi.MenuItem37.Enabled = False
        ''''FrmMainMdi.MenuItem38.Enabled = False
        ''''FrmMainMdi.MenuItem69.Enabled = False
        ''''FrmMainMdi.MenuItem70.Enabled = False
        ''''FrmMainMdi.MenuItem77.Enabled = False
        ''''FrmMainMdi.MenuItem74.Enabled = False
        ''''FrmMainMdi.MenuItem78.Enabled = False
        ''''FrmMainMdi.MenuItem75.Enabled = False
        ''''FrmMainMdi.MenuItem76.Enabled = False
        ''''FrmMainMdi.MenuItem79.Enabled = False
        ''''FrmMainMdi.MenuItem80.Enabled = False
        ''''FrmMainMdi.MenuItem81.Enabled = False
        ''''FrmMainMdi.MenuItem90.Enabled = False
        ''''FrmMainMdi.MenuItem95.Enabled = False
        ''''FrmMainMdi.MenuItem96.Enabled = False
    End Sub


    Public Function Searchstr_prs(ByVal StringToSearch1 As String, ByVal StringToSearch As String) As String
        Dim char11 As String = ""
        Dim intStartingFrom1, intCount1 As Long
        intStartingFrom1 = Len(StringToSearch1)
        intCount1 = Len(StringToSearch) + 1
        Do Until intCount1 >= intStartingFrom1
            char11 = ""
            If StringToSearch1.Chars(intCount1) <> "," Then
                char11 += StringToSearch1.Chars(intCount1)
            Else
                char11 = char11
                Exit Do
            End If

            intCount1 += 1
        Loop

        Searchstr_prs = char11

    End Function
    Public Function Check_Minus_Dot(ByVal ToSearchtxtbox As TextBox, ByVal MsgLbl As Label) As Object
        Dim StringToSearch1 As String = Trim(ToSearchtxtbox.Text)
        Dim MsgLabel As String = Trim(MsgLbl.Text)
        Dim char11 As String = ""
        Dim intStartingFrom1, intCount1 As Long
        intStartingFrom1 = Len(StringToSearch1)
        intCount1 = Len(StringToSearch1)

        If StringToSearch1.StartsWith("-") Or StringToSearch1.StartsWith(".") Then
            ToSearchtxtbox.Focus()
            MsgLbl.Visible = True
            Exit Function
        End If

        If intCount1 > 0 Then
            Do Until intCount1 >= intStartingFrom1
                char11 = ""
                If StringToSearch1.Chars(intCount1) <> "." Then
                    char11 += StringToSearch1.Chars(intCount1)
                Else
                    char11 = char11
                    Exit Do
                End If

                intCount1 += 1
            Loop

            Check_Minus_Dot = char11
        End If


    End Function


    Public Sub Chk_Exisit(ByVal xTable As Object, ByVal xFieldname As Object, ByVal xTextstr As Object)
        Dim xStr As String = "Select " & (xFieldname) & " from " & (xTable) & " where " & Trim(xFieldname) & "= @fldval "
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn)
            xChkexisitCmd.Parameters.AddWithValue("@fldval", xTextstr)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.HasRows = True Then
                    xStr1 = xChkexisitRdr(0)
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Sub

    Public Sub Fill_Combobox(ByVal xField1name As String, ByVal xField2name As String, ByVal xTable As String, ByVal xField3Cond As String, ByVal xCondVal As String, ByVal Xcombobx As ComboBox)
        Dim xStr As String = "Select " & (xField1name) & "," & (xField2name) & " from " & (xTable) & " WHERE " & (xField3Cond) & "=@CondVal order by " & (xField2name) & " "
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal", Trim(xCondVal))
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xField1name
            Xcombobx.DisplayMember = xField2name

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_Combobox_WitoutDelStatus(ByVal xField1name As String, ByVal xField2name As String, ByVal xTable As String, ByVal Xcombobx As ComboBox)
        '===========================================
        '===This is used in where table having not DelStatus column
        '===========================================

        Dim xStr As String = "Select " & (xField1name) & "," & (xField2name) & " from " & (xTable) & "  order by " & (xField2name) & " "
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xField1name
            Xcombobx.DisplayMember = xField2name

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Function Chk_Exisit2(ByVal xTable As Object, ByVal xFieldname As Object, ByVal xFieldid As Object, ByVal xTextstr As Object) As Boolean
        Dim xStr As String = "Select " & (xFieldname) & " from " & (xTable) & " where " & Trim(xFieldid) & "= @fldval  order by " & Trim(xFieldid) & " "
        Try
            If xTextstr = Nothing Then xTextstr = 0
            xChkexisitCmd = New SqlCommand(xStr, FinActConn)
            xChkexisitCmd.Parameters.AddWithValue("@fldval", xTextstr)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.HasRows = True Then
                    xStr2 = xChkexisitRdr(0)
                    Return True
                Else
                    xStr2 = 0
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xBill_xDuedays(ByVal xTable As Object, ByVal xFieldname As Object, ByVal xFieldid As Object, ByVal xTextstr As Object) As Integer
        Dim xStr As String = "Select " & (xFieldname) & " from " & (xTable) & " where " & Trim(xFieldid) & "= @fldval  order by " & Trim(xFieldid) & " "
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn)
            xChkexisitCmd.Parameters.AddWithValue("@fldval", xTextstr)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0)
                End If
            End While
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xFetchVno_dynamic(ByVal xTblName As String, ByVal xFldName As String) As Integer
        Try
            Dim xV As Integer = 0
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Fianct_fetchVoucherNo_Dynamicly", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@tbl", xTblName)
            FinActCmd.Parameters.AddWithValue("@Fld", xFldName)
            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    xV = FinActRdr(0)
                Else
                    xV = 0
                End If
            End While
            If xV > 0 Then
                xV += 1
            Else
                xV = 1
            End If
            Return xV
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
    Public Function xFetchVno_AccordingVATBillType(ByVal xxSplrid As Integer, ByVal xxSpcatid As Integer, ByVal xxDTP As DateTimePicker) As Integer
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            Dim xInvType As String = ""
            Dim xFldName As String = ""
            If Cl_Kbl = True Then
                FinActCmd = New SqlCommand("Finact_xSaleBill_Terms", FinActConn2) ' === HAVING TWO BILL SERIES
            Else
                FinActCmd = New SqlCommand("Finact_xSaleBill_PrePrintedType_MultiSeries_Terms", FinActConn2) ' === HAVING FIVE BILL SERIES
            End If

            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@XXSPLRID", CInt(xxSplrid))
            FinActCmd.Parameters.AddWithValue("@xxSpCatid", CInt(xxSpcatid))
            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    xInvType = Trim(FinActRdr(1))
                End If
            End While
            FinActCmd.Dispose()
            FinActRdr.Close()

            Dim xV As Integer = 0
            Dim xV1 As Integer = 0
            ''================KBL SALES SECTION====================
            If Cl_Kbl = True Then
                If xInvType.Trim = "VAT INVOICE" Then
                    xV1 = xSaleVATvNo
                    xFldName = "SaleEntVATvNO"
                ElseIf xInvType.Trim = "RETAIL INVOICE" Then
                    xV1 = xSaleRetailVno
                    xFldName = "SaleEntRETAILvNO"
                Else 'Category Included Export, against H form , tax free etc.
                    xV = xSaleRetailVno
                    xFldName = "SaleEntRETAILvNO"
                End If
                ''================END OF KBL SALES SECTION====================
            Else
                If xInvType.Trim = "RETAIL INVOICE CST" Then
                    xV1 = RETAIL_INV_CST
                    xSetSaleBillCate = 1
                ElseIf xInvType.Trim = "DIRECT EXPORT INVOICE" Then
                    xV1 = DIRCTEXPRT_INV
                    xSetSaleBillCate = 2
                ElseIf xInvType.Trim = "RETAIL INVOICE LOCAL" Then
                    xV1 = RETAILINV_LOCAL
                    xSetSaleBillCate = 3
                ElseIf xInvType.Trim = "VAT INVOICE" Then
                    xV1 = VAT_INV
                    xSetSaleBillCate = 4
                ElseIf xInvType.Trim = "RETAIL INVOICE TXFREE" Then
                    xV1 = RETAILINV_TXFREE
                    xSetSaleBillCate = 5
                Else 'Category Included Export, against H form , tax free etc.
                    xV1 = xSaleRetailVno
                    xSetSaleBillCate = 5
                End If

            End If


            If Cl_Kbl = True Then
                FinActCmd = New SqlCommand("Fianct_fetchVoucherNo_Dynamicly", FinActConn2)
                FinActCmd.CommandType = CommandType.StoredProcedure
                FinActCmd.Parameters.AddWithValue("@tbl", "FinactSaleEntry")
                FinActCmd.Parameters.AddWithValue("@Fld", xFldName)
            Else
                FinActCmd = New SqlCommand("Fianct_fetchVoucherNo_Dynamicly_WHERE_COND", FinActConn2)
                FinActCmd.CommandType = CommandType.StoredProcedure
                FinActCmd.Parameters.AddWithValue("@tbl", "FinactSaleEntry")
                FinActCmd.Parameters.AddWithValue("@Fld", "SaleEntRETAILvNO")
                FinActCmd.Parameters.AddWithValue("@CONDFld", "SaleEntVATvNO")
                FinActCmd.Parameters.AddWithValue("@CONDval", CInt(xSetSaleBillCate))
            End If

            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    xV = FinActRdr(0)
                    Dim xdt As Date = Curr_Maxdate("SaleentDT", "saleentvno", "Finactsaleentry", CInt(xV))
                    'If xdt.CompareTo(FinStartDt) True Then
                    '    xxDTP.MinDate = xdt
                    '    xxDTP.Value = xdt
                    'Else
                    '    xxDTP.MinDate = FinStartDt.Date
                    '    xxDTP.Value = xdt
                    'End If

                Else
                    xxDTP.MinDate = FinStartDt.Date
                End If
            End While
            If Cl_Kbl = True Then
                If xV > 0 Then
                    xV += 1
                Else
                    xV = xV1 + 1
                End If
            Else
                If xV > 0 Then
                    xV += 1
                Else
                    xV = xV1 + 1
                End If
            End If

            Return xV
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
    Public Function Curr_Maxdate(ByVal xFld As String, ByVal xCondFld As String, ByVal xTbl As String, ByVal xCondVal As Integer) As Date
        Try
            Dim Curr_MaxSaledt As Date
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xxCmd = New SqlCommand("xSelect_xLastEntrdDate_xinatbl_cond_maxInvNo_select", FinActConn1)
            xxCmd.CommandType = CommandType.StoredProcedure
            xxCmd.Parameters.AddWithValue("@xFld", xFld.Trim)
            xxCmd.Parameters.AddWithValue("@xCondFld", xCondFld.Trim)
            xxCmd.Parameters.AddWithValue("@xTbl", xTbl.Trim)
            xxCmd.Parameters.AddWithValue("@xCondVal", CInt(xCondVal))
            xxRdr = xxCmd.ExecuteReader
            xxRdr.Read()
            If xxRdr.IsDBNull(0) = False Then
                Curr_MaxSaledt = xxRdr(0)
                Return Curr_MaxSaledt
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xxRdr.Close()
            xxCmd.Dispose()
        End Try

    End Function
    Public Function xFetchMxVal_dynamic(ByVal xTblName As String, ByVal xFldName As String) As Integer
        Try
            Dim xV As Integer = 0
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Fianct_fetchVoucherNo_Dynamicly", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@tbl", xTblName)
            FinActCmd.Parameters.AddWithValue("@Fld", xFldName)
            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    xV = FinActRdr(0)
                End If
            End While
            Return xV
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
    Public Function xFetchMxVal_dynamic_1Cond(ByVal xTblName As String, ByVal xFldName As String, ByVal xCondFld As String, ByVal xCondVal As String) As Integer
        Try
            Dim xV As Integer = 0
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Fianct_fetchVoucherNo_Dynamicly_WHERE_COND", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@tbl", xTblName.Trim)
            FinActCmd.Parameters.AddWithValue("@Fld", xFldName.Trim)
            FinActCmd.Parameters.AddWithValue("@CondFld", xCondFld.Trim)
            FinActCmd.Parameters.AddWithValue("@CondVal", xCondVal)
            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    xV = FinActRdr(0)
                End If
            End While
            Return xV
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
    Public Function FindMaxId(ByVal Splrname As String, ByVal SplrSurfix As Integer) As Integer
        Try
            Dim MaxSplid As Integer = 0
            xChkexisitCmd = New SqlCommand("select splrid from finactsplrmstr where splrname=@name and splrsurfix=@surfix", FinActConn1)
            xChkexisitCmd.Parameters.AddWithValue("@name", Trim(Splrname))
            xChkexisitCmd.Parameters.AddWithValue("@surfix", Trim(SplrSurfix))
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            xChkexisitRdr.Read()
            If xChkexisitRdr.HasRows = True Then
                MaxSplid = xChkexisitRdr(0)
                Return MaxSplid
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitRdr.Close()
            xChkexisitCmd.Dispose()
        End Try

    End Function
    Public Sub Check_Minus_Dot1(ByVal txtbox As TextBox)
        Dim StringToSearch1 As String
        StringToSearch1 = Trim(txtbox.Text)
        Dim char11 As String = ""
        Dim dot As String
        Dim x As Integer
        Dim intStartingFrom1, intCount1 As Long
        intStartingFrom1 = Len(StringToSearch1)
        intCount1 = Len(StringToSearch1)

        If intCount1 > 0 Then
            For x = 1 To intCount1
                dot = Mid$(StringToSearch1, x, 1)
                If dot = "." Then
                    Dim y As Integer
                    y += 1
                    char11 = char11 & dot
                    If y > 1 Then
                        txtbox.BackColor = Color.LemonChiffon
                        txtbox.Focus()
                        txtbox.Clear()
                        Exit Sub
                    End If

                Else
                    txtbox.BackColor = Color.White
                    char11 = char11 & dot
                    Dim y1 As Integer = char11.IndexOf(".")
                    If y1 <> -1 Then
                        Dim chrdeci As Integer = Len(char11.Substring(y1))

                        If char11.StartsWith(".") Then
                            If chrdeci = 4 Then
                                txtbox.SelectionStart = chrdeci - 1
                                txtbox.Select(chrdeci - 1, 1)
                                char11.Remove(3, 1)
                                txtbox.Text = char11
                            End If
                        Else
                            If chrdeci = 4 Then
                                Dim txtlen As Integer = Len(txtbox.Text) - 1 'chrdeci
                                txtbox.SelectionStart = txtlen
                                txtbox.Select(txtlen, 1)
                                char11.Remove(4, 1)
                                txtbox.Text = char11
                            End If
                        End If

                    End If
                End If
            Next x
        End If
    End Sub

    Public Sub Set_Max_Min_Date(ByVal Fromdt As Date)
        Try
            Dim mnthNo As Integer = Format(Fromdt, "MM")
            Dim mnthDay As Integer = Format(Fromdt, "dd")
            Dim mnthYear As Integer = Format(Fromdt, "yyyy")
            Dim mntday As Integer
            Dim chkleap As Date = Fromdt.Date
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

            FinStartDt = DateSerial(mnthYear, mnthNo, 1)
            FinEnddt = DateSerial(Year(FinStartDt.Date.AddYears(1)), Month(FinStartDt.Date.AddMonths(11)), 31)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Check_Minus_Dot_Kgformat(ByVal txtbox As TextBox)
        Dim StringToSearch1 As String
        StringToSearch1 = Trim(txtbox.Text)
        Dim char11 As String = ""
        Dim dot As String
        Dim x As Integer
        Dim intStartingFrom1, intCount1 As Long
        intStartingFrom1 = Len(StringToSearch1)
        intCount1 = Len(StringToSearch1)
        If intCount1 > 0 Then
            For x = 1 To intCount1
                dot = Mid$(StringToSearch1, x, 1)
                If dot = "." Then
                    Dim y As Integer
                    y += 1
                    char11 = char11 & dot
                    If y > 1 Then
                        txtbox.BackColor = Color.LemonChiffon
                        txtbox.Focus()
                        txtbox.Clear()
                        Exit Sub
                    End If
                Else
                    txtbox.BackColor = Color.White
                    char11 = char11 & dot
                    Dim y1 As Integer = char11.IndexOf(".")
                    If y1 <> -1 Then
                        Dim chrdeci As Integer = Len(char11.Substring(y1))

                        If char11.StartsWith(".") Then
                            If chrdeci = 4 Then
                                txtbox.SelectionStart = chrdeci - 1
                                txtbox.Select(chrdeci - 1, 1)
                                char11.Remove(3, 1)
                                txtbox.Text = char11
                            End If
                        Else
                            If chrdeci = 4 Then
                                Dim txtlen As Integer = Len(txtbox.Text) - 1 'chrdeci
                                txtbox.SelectionStart = txtlen
                                txtbox.Select(txtlen, 1)
                                char11.Remove(4, 1)
                                txtbox.Text = char11
                            End If
                        End If

                    End If
                End If
            Next x
        End If
    End Sub
    Public Sub Fill_Combobox_where_Not_cond(ByVal xField1name As String, ByVal xField2name As String, ByVal XCondField As String _
                                            , ByVal xTable As Object, ByVal xStrCond As String, ByVal Xcombobx As ComboBox, ByVal XCondField2 As String, ByVal xValCond2 As String)
        Dim xStr As String = "xFill_Combobox_where_Not_cond"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFldId", xField1name.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@xFldName", xField2name.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@xCondFld1", XCondField.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@xCondFld2", XCondField2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@xCondVal1", xStrCond.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@xCondVal2", xValCond2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@xTbl", xTable.Trim)

            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xField1name
            Xcombobx.DisplayMember = xField2name

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_Combobox_where_cond(ByVal xField1name As String, ByVal xField2name As String, ByVal XCondField As String _
                                        , ByVal xTable As Object, ByVal XCondField1 As String, ByVal XCondVAL1 As String, ByVal xStrCond As String, ByVal Xcombobx As ComboBox)
        Dim xStr As String = "Select " & (xField1name) & "," & (xField2name) & " from " & (xTable) & " where " & (XCondField1) & "=@Cond2  AND  " & (XCondField) & "=@Cond1 ORDER BY " & (xField2name) & " "
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.Parameters.AddWithValue("@Cond1", Trim(xStrCond))
            xChkexisitCmd.Parameters.AddWithValue("@Cond2", Trim(XCondVAL1))
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xField1name
            Xcombobx.DisplayMember = xField2name

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_Cmbx_xDynamic_WHERECond_CONVRTvar2iNT_Select(ByVal xField1name As String, ByVal xField2name As String _
, ByVal XCondField As String, ByVal xTable As String, ByVal xStrCond As String, ByVal Xcombobx As ComboBox, ByVal xDelStatus As String, ByVal xDelVal As String)
        Dim xStr As String = "xFilCmbx_xDynamic_WHERECond_CONVRTvar2iNT_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@FldID", xField1name.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldNAME", xField2name.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@DelStatus", xDelStatus.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@DelVal", xDelVal.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@TBL", xTable.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond", XCondField.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@ValCond", xStrCond.Trim)
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xField1name
            Xcombobx.DisplayMember = xField2name

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_Combobox_where_Not_In_cond(ByVal xField1name As String, ByVal xField2name As String, _
            ByVal XCondField As String, ByVal xTable As Object, ByVal xStrCond As String, ByVal xStrCond1 As String, _
             ByVal Xcombobx As ComboBox, ByVal XCondField1 As String, ByVal xCondVal1 As String)
        Dim xStr As String = "Select " & (xField1name) & "," & (xField2name) & " from " & (xTable) & " where " & (XCondField1) & "=" & (xCondVal1) & "  AND  " & (XCondField) & " not in(@Cond1,@Cond2) order by " & (xField2name) & " "
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.Parameters.AddWithValue("@Cond1", Trim(xStrCond))
            xChkexisitCmd.Parameters.AddWithValue("@Cond2", Trim(xStrCond1))

            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xField1name
            Xcombobx.DisplayMember = xField2name

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_Combobox_where_Not_In_cond4(ByVal xField1name As String, ByVal xField2name As String, _
           ByVal XCondField As String, ByVal xTable As Object, ByVal xStrCond As String, ByVal xStrCond1 As String, _
           ByVal xStrCond2 As String, ByVal xStrCond3 As String, ByVal Xcombobx As ComboBox, ByVal xDelStatus As String, ByVal xDelVal As Integer)
        Dim xStr As String = "Select " & (xField1name) & "," & (xField2name) & " from " & (xTable) & " where " & (xDelStatus) & "=@DelVal and  " & (XCondField) & " not in(@Cond1,@Cond2,@Cond3,@Cond4) order by " & (xField2name) & " "
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.Parameters.AddWithValue("@Cond1", Trim(xStrCond))
            xChkexisitCmd.Parameters.AddWithValue("@Cond2", Trim(xStrCond1))
            xChkexisitCmd.Parameters.AddWithValue("@Cond3", Trim(xStrCond2))
            xChkexisitCmd.Parameters.AddWithValue("@Cond4", Trim(xStrCond3))
            xChkexisitCmd.Parameters.AddWithValue("@DelVal", CInt(xDelVal))
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xField1name
            Xcombobx.DisplayMember = xField2name

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Select_State_Contry_where_id(ByVal xfield1id As String, ByVal xfield2name As String, ByVal xFieldcond As String, ByVal xtblename As String, ByVal xlbl1 As Label, ByVal xlbl2 As Label, ByVal CondStr As String)
        Dim xStr As String = "Select " & (xfield1id) & "," & (xfield2name) & " from " & (xtblename) & " where " & Trim(xFieldcond) & "= @fldval  order by " & Trim(xfield2name) & " "
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.Parameters.AddWithValue("@fldval", CondStr)
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            xlbl1.Text = Trim(dtaset.Tables(0).Rows(0).ItemArray(0).ToString)
            xlbl2.Text = Trim(dtaset.Tables(0).Rows(0).ItemArray(1).ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()
        End Try
    End Sub
    Public Sub Select_2rec_with_Union_where(ByVal xCombobox As ComboBox, ByVal Curidx As Integer)
        Dim xStr As String = "Finact_CscMstr_Union_shpadrsmstr_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@curid", Curidx)
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            xCombobox.DataSource = dtaset.Tables(0)
            xCombobox.ValueMember = "idx"
            xCombobox.DisplayMember = "Nmx"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()
        End Try
    End Sub
    Public Sub Select_2rec_with_where(ByVal xCombobox As ComboBox, ByVal Curidx As Integer)
        Dim xStr As String = "Finact_shpadrsmstr_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@curid", Curidx)
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            xCombobox.DataSource = dtaset.Tables(0)
            xCombobox.ValueMember = "idx"
            xCombobox.DisplayMember = "Nmx"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()
        End Try
    End Sub
    Public Sub Fetch_Stock_Record(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object)
        Try
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)
            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt '.subreport


            FinActCmd = Nothing
        End Try
    End Sub
    Public Sub Fetch_Stock_Record_SelectedItem(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object, ByVal SelItmId As Integer)
        Try
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@SelItmId", SelItmId)
            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)
            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            FinActCmd = Nothing
        End Try
    End Sub
    Public Sub Fetch_Stock_Record_SelectedItem_String(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object, ByVal xHtNo As String)
        Try
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xHtNo", xHtNo)
            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)
            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            FinActCmd = Nothing
        End Try
    End Sub

    Public Sub xFetch_RptRecord_Dt_Vno_Actt_Range(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object _
                                                  , ByVal SelDt1 As Date, ByVal SelDt2 As Date, ByVal xPrmIndx As Integer, ByVal xSelid As String _
                                                  , ByVal xSelVno1 As String, ByVal xSelVno2 As String)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@SelDt1", SelDt1)
            FinActCmd.Parameters.AddWithValue("@SelDt2", SelDt2)
            If xPrmIndx = 1 Then '==SELECTED ACCOUNT
                FinActCmd.Parameters.AddWithValue("@SelDt2", SelDt2)
            ElseIf xPrmIndx = 2 Then '==VOUCHER RANGE
                FinActCmd.Parameters.AddWithValue("@SelVno1", xSelVno1)
                FinActCmd.Parameters.AddWithValue("@SelVno2", xSelVno2)
            End If

            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)

            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            FinActCmd = Nothing
        End Try
    End Sub
    Public Sub Fetch_Stock_Record_SelectedDateRange(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object, ByVal SelDt1 As Date, ByVal SelDt2 As Date)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@SelDt1", SelDt1)
            FinActCmd.Parameters.AddWithValue("@SelDt2", SelDt2)
            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)
            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            FinActCmd = Nothing
        End Try
    End Sub
    Public Sub Fetch_Stock_Record_SelectedDateRange_withSelITem(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object _
                                                                , ByVal SelDt1 As Date, ByVal SelDt2 As Date, ByVal xSelid As String)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@SelDt1", SelDt1)
            FinActCmd.Parameters.AddWithValue("@SelDt2", SelDt2)
            FinActCmd.Parameters.AddWithValue("@SeliId", xSelid)
            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)
            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            FinActCmd = Nothing
        End Try
    End Sub
    Public Sub Fetch_Stock_Record_SelectedDateRange_with2SelITem(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object, ByVal SelDt1 As Date, ByVal SelDt2 As Date, ByVal xSelid As String, ByVal xRate As Double)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xDt1", SelDt1)
            FinActCmd.Parameters.AddWithValue("@xDt2", SelDt2)
            FinActCmd.Parameters.AddWithValue("@xAgntId", CInt(xSelid))
            FinActCmd.Parameters.AddWithValue("@xComm", CDbl(xRate))
            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)
            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            FinActCmd = Nothing
        End Try
    End Sub
    Public Sub Fetch_Stock_Record_SelectedDateRange_withVnoRange(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object, ByVal SelDt1 As Date, ByVal SelDt2 As Date, ByVal xSelVno1 As String, ByVal xSelVno2 As String)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@SelDt1", SelDt1)
            FinActCmd.Parameters.AddWithValue("@SelDt2", SelDt2)
            FinActCmd.Parameters.AddWithValue("@SelVno1", xSelVno1)
            FinActCmd.Parameters.AddWithValue("@SelVno2", xSelVno2)
            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)
            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            FinActCmd = Nothing
        End Try
    End Sub
    Public Sub Fetch_Stock_Record_SelectedDateRange_withSelITem_and_BalType(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object, ByVal SelDt1 As Date, ByVal SelDt2 As Date, ByVal xSelid As String, ByVal SelType As Integer, ByVal SelBaltype As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@SelDt1", SelDt1)
            FinActCmd.Parameters.AddWithValue("@SelDt2", SelDt2)
            FinActCmd.Parameters.AddWithValue("@SeliId", xSelid)
            FinActCmd.Parameters.AddWithValue("@Seltype", SelType)
            FinActCmd.Parameters.AddWithValue("@SelBaltype", SelBaltype)
            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)
            For Each row As DataRow In FinActDset.Tables(0).Rows
                '=== xSaleBillId = CInt(row.Item(1))

            Next
            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            FinActCmd = Nothing
        End Try
    End Sub
    Public Sub Fetch1_Stock_Record_SelectedDateRange_withSelITem_and_BalType(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object, ByVal SelDt1 As Date, ByVal SelDt2 As Date, ByVal xSelid As String, ByVal SelType As Integer, ByVal xxSPLRID As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@SelDt1", SelDt1)
            FinActCmd.Parameters.AddWithValue("@SelDt2", SelDt2)
            FinActCmd.Parameters.AddWithValue("@xITMID", xSelid)
            FinActCmd.Parameters.AddWithValue("@Seltype", SelType)
            FinActCmd.Parameters.AddWithValue("@xxSPLRID", xxSPLRID)
            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)
            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            FinActCmd = Nothing
        End Try
    End Sub
    Public Sub Fetch_SalePur_Record_SelectedDateRange_withSelITems(ByVal xStr As String, ByVal xCrRpt As Object, _
                                                                   ByVal CrRptVew As Object, ByVal SelDt1 As Date, ByVal SelDt2 As Date, ByVal xSelPrtyId As Integer, _
                                                                   ByVal xSelTaxVal As Double, ByVal xSelTaxCat As Integer, ByVal xSelCustRange As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@SelDt1", SelDt1)
            FinActCmd.Parameters.AddWithValue("@SelDt2", SelDt2)
            FinActCmd.Parameters.AddWithValue("@SelPrtyId", xSelPrtyId)
            FinActCmd.Parameters.AddWithValue("@SelTaxVal", xSelTaxVal)
            FinActCmd.Parameters.AddWithValue("@SelTaxCat", xSelTaxCat) ' 0 Stands for All and 1 Satands for Selected item
            FinActCmd.Parameters.AddWithValue("@SelCustRange", xSelCustRange) ' 0 Stands for All and 1 Satands for Selected item
            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)
            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            FinActCmd = Nothing
        End Try
    End Sub
    Public Sub Fetch_SalePur_Record_SelectedDateRange_withSelITems_and_Indx(ByVal xStr As String, ByVal xCrRpt As Object, _
                                                                  ByVal CrRptVew As Object, ByVal SelDt1 As Date, ByVal SelDt2 As Date, ByVal xSelPrtyId As Integer, _
                                                                  ByVal xSelIndx As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand(xStr, FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xDtF", SelDt1)
            FinActCmd.Parameters.AddWithValue("@xDtT", SelDt2)
            FinActCmd.Parameters.AddWithValue("@xSPLRID", CInt(xSelPrtyId))
            FinActCmd.Parameters.AddWithValue("@xINDX", xSelIndx) ' 0 Stands for All and 1 Satands for Selected item
            FinActDset = New DataSet(FinActCmd.CommandText)
            FinActSqlAdptr = New SqlDataAdapter(FinActCmd)
            FinActSqlAdptr.Fill(FinActDset)
            xCrRpt.SetDataSource(FinActDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            FinActCmd = Nothing
        End Try
    End Sub
    Public Sub Fill_Combobox_WhereID_In(ByVal xField1name As String, ByVal xField2name As String, ByVal xTable As Object, ByVal Xcombobx As ComboBox)
        '====================
        '==DelStatus Handles 
        '====================
        Dim xStr As String = "Finact_Check_Item_Dependencies_SelectItems"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure

            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xField1name
            Xcombobx.DisplayMember = xField2name

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_Combobox_DistinctSplrid(ByVal Xcombobx As ComboBox)
        Dim xStr As String = "Finact_Rpt_Purentry_Fill_ComboBox"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure

            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = "Splrid"
            Xcombobx.DisplayMember = "SplrName"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_Combobox_DistinctVal_Where_1_Cond(ByVal xFld As String, ByVal xCondFld As String, ByVal xCondVal As String, ByVal xTbl As String, ByVal Xcombobx As ComboBox)
        '===================
        '==DelStatus Not Required
        '===================
        Dim xStr As String = "xSelect_xFind_Distinct_xinatbl_Where_1_Condition"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xFld.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@xFld1", xCondFld.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@xVal", xCondVal.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@xTbl", xTbl.Trim)

            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.DisplayMember = xFld
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()
            '
        End Try
    End Sub
    Public Sub Fill_xLstVew_Dynamic_xSelct_3Fld_Where_1_Cond_isOptional(ByVal xFld1 As String, ByVal xFld2 As String _
                                                                        , ByVal xFld3 As String, ByVal xCondFld As String, ByVal xCondVal As String _
                                                                        , ByVal xTbl As String, ByVal xLstVew As ListView)
        Dim xStr As String = "xSelect_x3Flds_xinatbl_Where_1_Condition"
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            FinActCmd = New SqlCommand(xStr, FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xFld1", xFld1.Trim)
            FinActCmd.Parameters.AddWithValue("@xFld2", xFld2.Trim)
            FinActCmd.Parameters.AddWithValue("@xFld3", xFld3.Trim)
            FinActCmd.Parameters.AddWithValue("@xCondFld1", xCondFld.Trim)
            FinActCmd.Parameters.AddWithValue("@xCondVal1", xCondVal.Trim)
            FinActCmd.Parameters.AddWithValue("@xTbl", xTbl.Trim)
            FinActRdr = FinActCmd.ExecuteReader
            xLstVew.Items.Clear()
            Dim xlv As ListViewItem
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    If FinActRdr(xFld1) = True Then
                        xlv = xLstVew.Items.Add("Activated") 'Check Status
                    Else
                        xlv = xLstVew.Items.Add("Deactivated") 'Check Status
                        xlv.Checked = True
                        xlv.BackColor = Color.Cyan
                    End If
                    xlv.SubItems.Add(FinActRdr(xFld2)) ' Id
                    xlv.SubItems.Add(FinActRdr(xFld3)) ' Name
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Sub
    Public Sub xUpdate_From_xLstVew_Dynamic_3Fld_Where_1_Cond(ByVal xFld1 As String, ByVal xFld2 As String, ByVal xFld3 As String _
                                                              , ByVal xFld1UpdtVal As String, ByVal xFld2UpdtVal As String, ByVal xFld3UpdtVal As Date _
                                                              , ByVal xCondFld As String, ByVal xCondVal As String, ByVal xTbl As String)
        Dim xStr As String = "xUpdate_x3Flds_xinatbl_Where_1_Condition"
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()

            FinActCmd = New SqlCommand(xStr, FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xFld1", xFld1.Trim)
            FinActCmd.Parameters.AddWithValue("@xFld2", xFld2.Trim)
            FinActCmd.Parameters.AddWithValue("@xFld3", xFld3.Trim)
            FinActCmd.Parameters.AddWithValue("@xUpdtVaL1", xFld1UpdtVal)
            FinActCmd.Parameters.AddWithValue("@xUpdtVaL2", xFld2UpdtVal)
            FinActCmd.Parameters.AddWithValue("@xUpdtVaL3", xFld3UpdtVal)
            FinActCmd.Parameters.AddWithValue("@xCondFld1", xCondFld.Trim)
            FinActCmd.Parameters.AddWithValue("@xCondVal1", xCondVal.Trim)
            FinActCmd.Parameters.AddWithValue("@xTbl", xTbl.Trim)
            FinActCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
        End Try
    End Sub
    Public Sub Fill_Combobox_DistinctSaleSplrid(ByVal Xcombobx As ComboBox)
        Dim xStr As String = "Finact_Rpt_Saleentry_Fill_ComboBox"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure

            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = "Splrid"
            Xcombobx.DisplayMember = "SplrName"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_CMBX_DYNAMIC_WITH_INNERJOIN_DISTINCT_SELECT(ByVal xDelStatus As String, ByVal xDelVal As String, ByVal xFLD1 As String, ByVal xFLD2 As String, _
                                                                ByVal xTBL As String, ByVal xJFLD1 As String, ByVal xJFLD2 As String, ByVal xJTBL As String, _
                                                                ByVal xCMBX As ComboBox)
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            Dim xStr As String = "xFilCmbx_xDynamic_with_InnerJoin_DISTINCT_Select"
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@SID", xFLD1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@SNAME", xFLD2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@DelStatus", xDelStatus.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@DelVal", xDelVal.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@TBL", xTBL.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@J_ON_SID1", xJFLD1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@J_ON_SID2", xJFLD2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@J_TBL", xJTBL.Trim)
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            xCMBX.DataSource = dtaset.Tables(0)
            xCMBX.ValueMember = xFLD1
            xCMBX.DisplayMember = xFLD2
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Handle_P_Bar(ByVal frm As Form)
        Try
            Dim xa As Integer = 0
            FrmMainMdi.Progrs01.Value = 0
            For xa = 1 To 10
                FrmMainMdi.Progrs01.Value = FrmMainMdi.Progrs01.Value + 10
                FrmMainMdi.Label3.Visible = False
                System.Threading.Thread.Sleep(1)
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & frm.Name & "  Sub/Function Name:- 'Handle_P_Bar', Line No 34")
        Finally
            FrmMainMdi.Panel1.Visible = False
            frm.Visible = True
        End Try
    End Sub
    Public Sub Handle_P_Bar_Part_I(ByVal Frm1 As Form)
        Try
            Dim a As Integer = 0
            FrmMainMdi.Label3.Text = ""
            FrmMainMdi.Label3.Text = a & " %"
            Frm1.Visible = False
            FrmMainMdi.Progrs01.Value = 0
            FrmMainMdi.Panel1.Visible = True
            FrmMainMdi.Panel1.Top = 3
            FrmMainMdi.Panel1.Left = 0
            FrmMainMdi.Progrs01.Value = FrmMainMdi.Progrs01.Value + 1
            a += FrmMainMdi.Progrs01.Value
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Optional ByVal DtpMin1 As DateTimePicker = Nothing, Optional ByVal DtpMax1 As DateTimePicker = Nothing)
        Try
            DtpMin1.MinDate = FinStartDt
            DtpMax1.MinDate = FinStartDt

            DtpMin1.MaxDate = FinEnddt
            DtpMax1.MaxDate = FinEnddt
            DtpMin1.Value = FinStartDt
            If Today.Date > FinEnddt Then
                DtpMax1.Value = FinEnddt
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function GetServerCurrentDate() As Date
        Try
            Dim xStr As String = "Finact_Server_GetCurrentDate"
            xChkexisitCmd = New SqlCommand(xStr, FinActConn)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure

            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.HasRows = True Then
                    Return xChkexisitRdr(0)
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function SetControlCurrentDate(ByVal xDtp As DateTimePicker) As Date
        Try
            If GetServerCurrentDate.Date >= FinStartDt.Date And GetServerCurrentDate.Date <= FinEnddt.Date Then
                xDtp.Value = GetServerCurrentDate()
            ElseIf GetServerCurrentDate.Date < FinStartDt.Date Then
                xDtp.Value = FinStartDt
            ElseIf GetServerCurrentDate.Date > FinEnddt.Date Then
                xDtp.Value = FinEnddt
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function xChk_numericValidation(ByVal xNumTxt As TextBox) As Boolean
        Try
            If Trim(xNumTxt.Text) <> "" Then
                If IsNumeric(xNumTxt.Text) = False Or Trim(xNumTxt.Text.EndsWith("-")) = True Or Trim(xNumTxt.Text.StartsWith("-")) = True Then
                    xNumTxt.Focus()
                    xNumTxt.SelectAll()
                    xNumTxt.BackColor = Color.Cyan
                    Return True
                Else
                    xNumTxt.BackColor = Color.White
                    'xNumTxt.Text = FormatNumber(xNumTxt.Text, 2)
                    Return False
                End If
            Else
                xNumTxt.BackColor = Color.White
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Function
    Public Function CheckBlank_Cmbx(ByVal xCmbxProd As ComboBox) As Boolean
        Try
            Dim indx As Integer = xCmbxProd.FindStringExact(xCmbxProd.Text)
            If Not indx = -1 Then
                xCmbxProd.SelectedIndex = indx
                Return True
            Else
                xCmbxProd.Focus()
                xCmbxProd.SelectAll()
                Return False
            End If
        Catch ex As Exception

        End Try
    End Function
    Public Function CheckBlank_IndxCmbx(ByVal xCmbxProd As ComboBox) As Boolean
        Try
            Dim indx As Integer = xCmbxProd.SelectedIndex
            If Not indx = -1 Then
                xCmbxProd.SelectedIndex = indx
                Return True
            Else
                xCmbxProd.Focus()
                xCmbxProd.SelectAll()
                Return False
            End If
        Catch ex As Exception

        End Try
    End Function
    Public Sub xUsr_xRol_xStatus(ByVal xxRolcTsText As String)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            xxCmd = New SqlCommand("Finact_UserRole_Child_Role_Select", FinActConn)
            xxCmd.CommandType = CommandType.StoredProcedure
            xxCmd.Parameters.AddWithValue("@xRolcConcrnid", CInt(Current_UsrId))
            xxCmd.Parameters.AddWithValue("@xRolcTsText", xxRolcTsText.Trim)
            xxRdr = xxCmd.ExecuteReader
            While xxRdr.Read
                xUsrRol_Add = CInt(xxRdr("RolcPAddnew"))
                xUsrRol_Edit = CInt(xxRdr("RolcPEdit"))
                xUsrRol_Del = CInt(xxRdr("RolcDele"))
                xUsrRol_Prnt = CInt(xxRdr("RolcPrnt"))
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            xxCmd.Dispose()
            xxRdr.Close()
        End Try
    End Sub


    Public Sub xCall_LinkFrm(ByVal xFrm As Form, ByVal xCmbx As ComboBox)
        Try
            xFrm.ShowInTaskbar = False
            xFrm.ShowDialog()
            xFrm.Top = 25
            xCmbxRefresh = True
            xCmbx.Focus()
            xCmbxRefresh = False
        Catch ex As Exception

        End Try
    End Sub
    Public Sub xCall_LinkFrm_xConvrt(ByVal xFrm As Form, ByVal xxStId As Integer, ByVal xxCmbx As ComboBox)
        Try
            xFrm.ShowInTaskbar = False
            xConvrtId = xxStId
            xConVrt_Flag = True
            xFrm.ShowDialog()
            xFrm.Top = 25
            xCmbxRefresh = True
            xxCmbx.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub xCall_LinkFrmLstVew(ByVal xFrm As Form, ByVal xLstvew As ListView)
        Try
            xFrm.ShowInTaskbar = False
            xFrm.ShowDialog()
            xFrm.Top = 25
            xCmbxRefresh = True
            xLstvew.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub xCall_LinkFrmDgVew(ByVal xFrm As Form, ByVal xDgVew As DataGridView)
        Try
            xFrm.ShowInTaskbar = False
            xFrm.ShowDialog()
            xFrm.Top = 25
            xCmbxRefresh = True
            xDgVew.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub xDel_A_Rec_FromTable_dynamicly(ByVal xTblName As String, ByVal xFldName As String, ByVal xRecId As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            xChkexisitCmd = New SqlCommand("Finact_xTableName_Delete", FinActConn)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xrecid", CInt(xRecId))
            xChkexisitCmd.Parameters.AddWithValue("@xtblname", Trim(xTblName))
            xChkexisitCmd.Parameters.AddWithValue("@xfldname", Trim(xFldName))
            xChkexisitCmd.ExecuteNonQuery()
            MsgBox("Current record has been successfully deleted.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            xChkexisitCmd.Dispose()
        End Try
    End Sub
    Public Sub xDel_A_Rec_FromTable_dynamiclyInLoop(ByVal xTblName As String, ByVal xFldName As String, ByVal xRecId As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            xChkexisitCmd = New SqlCommand("Finact_xTableName_Delete", FinActConn)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xrecid", CInt(xRecId))
            xChkexisitCmd.Parameters.AddWithValue("@xtblname", Trim(xTblName))
            xChkexisitCmd.Parameters.AddWithValue("@xfldname", Trim(xFldName))
            xChkexisitCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            xChkexisitCmd.Dispose()
        End Try
    End Sub
    Public Sub xDel_A_Rec_FromTable_dynamicly_3Cond(ByVal xTblName As String, ByVal xFldName As String, ByVal xFldName1 As String, ByVal xFldName2 As String, ByVal xRecId As Integer, ByVal xFldVal1 As String, ByVal xFldVal2 As String)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            xChkexisitCmd = New SqlCommand("Finact_xTableName_3Cond_Delete", FinActConn)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xrecid", CInt(xRecId))
            xChkexisitCmd.Parameters.AddWithValue("@xtblname", Trim(xTblName))
            xChkexisitCmd.Parameters.AddWithValue("@xfldname", Trim(xFldName))
            xChkexisitCmd.Parameters.AddWithValue("@xfldname1", Trim(xFldName1))
            xChkexisitCmd.Parameters.AddWithValue("@xfldname2", Trim(xFldName2))
            xChkexisitCmd.Parameters.AddWithValue("@xfldVal1", Trim(xFldVal1))
            xChkexisitCmd.Parameters.AddWithValue("@xfldVal2", Trim(xFldVal2))
            xChkexisitCmd.ExecuteNonQuery()
            ''MsgBox("Current record has been successfully deleted.", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            xChkexisitCmd.Dispose()
        End Try
    End Sub
    Public Sub Select_2rec_where(ByVal xfield1id As String, ByVal xfield2name As String, ByVal xFieldcond As String, ByVal xtblename As String _
                                 , ByVal xCombobox As ComboBox, ByVal CondStr As String, ByVal xFieldcond1 As String, ByVal xCondVal1 As String)
        Dim xStr As String = "Select " & (xfield1id) & "," & (xfield2name) & " from " & (xtblename) & " where " & Trim(xFieldcond) & "= @fldval  and " & Trim(xFieldcond1) & "= @fldval1  order by " & Trim(xfield2name) & " "
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.Parameters.AddWithValue("@fldval", CondStr)
            xChkexisitCmd.Parameters.AddWithValue("@fldval1", xCondVal1)
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            xCombobox.DataSource = dtaset.Tables(0)
            xCombobox.ValueMember = xfield1id
            xCombobox.DisplayMember = xfield2name
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()
        End Try
    End Sub
    Public Function xSelect_xLastEntrdDate_xintbl(ByVal xfield As String, ByVal xtblename As String) As Date
        Dim xStr As String = "xSelect_xLastEntrdDate_xinatbl"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    xMxDtFlag = False
                    Return xChkexisitRdr(0)

                Else
                    xMxDtFlag = True
                    Return Nothing

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xSelect_xLastEntrd_Id_xintbl(ByVal xfield As String, ByVal xtblename As String) As Integer
        Dim xStr As String = "xSelect_xLastEntrdDate_xinatbl"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0) + 1
                Else
                    Return 1

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xSelect_xLastEntrd_Id_xintbl_WhereCond(ByVal xfield As String, ByVal xfield1 As String, ByVal xVal As String, ByVal xtblename As String) As Integer
        Dim xStr As String = "xSelect_xLastEntrdDate_xinatbl_Where_Condition"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xFld1", xfield1)
            xChkexisitCmd.Parameters.AddWithValue("@xVal", xVal)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0)
                Else
                    Return 0

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xDynamic_Find_xAnItem_xInA_Table_2cond(ByVal xfield As String, ByVal xfield1 As String, ByVal xVal As String, ByVal xtblename As String, ByVal xfield2 As String, ByVal xVal2 As String) As Integer
        Dim xStr As String = "xSelect_xFind_xinatbl_Where_2_Condition"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xFld1", xfield1)
            xChkexisitCmd.Parameters.AddWithValue("@xVal", xVal)
            xChkexisitCmd.Parameters.AddWithValue("@xFld2", xfield2)
            xChkexisitCmd.Parameters.AddWithValue("@xVal2", xVal2)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0)
                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xDynamic_Find_xAnItem_xInA_Table_3cond(ByVal xfield As String, ByVal xfield1 As String, ByVal xVal As String, ByVal xtblename As String _
                                                           , ByVal xfield2 As String, ByVal xVal2 As String, ByVal xfield3 As String, ByVal xVal3 As String) As Integer
        Dim xStr As String = "xSelect_xFind_xinatbl_Where_3_Condition"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xFld1", xfield1)
            xChkexisitCmd.Parameters.AddWithValue("@xVal", xVal)
            xChkexisitCmd.Parameters.AddWithValue("@xFld2", xfield2)
            xChkexisitCmd.Parameters.AddWithValue("@xVal2", xVal2)
            xChkexisitCmd.Parameters.AddWithValue("@xFld3", xfield3)
            xChkexisitCmd.Parameters.AddWithValue("@xVal3", xVal3)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0)
                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xDynamic_Find_xAnItem_xInA_Table_3INcond(ByVal xfield As String, ByVal xtblename As String _
                                                          , ByVal xfldId As String, ByVal xfldCond As String, ByVal xVal As String, ByVal xVal1 As String, ByVal xVal2 As String, ByVal xVal3 As String) As Integer
        Dim xStr As String = "Finact_xTbl_xCond3_where_3In_Select"
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@Fld1", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@tblNAME", xtblename.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldId", xfldId.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond", xfldCond.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal", xVal)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal1", xVal1)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal2", xVal2)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal3", xVal2)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0)
                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xDynamic_Find_xAnItem_xInA_Table_1cond_String(ByVal xfield As String, ByVal xfield1 As String, ByVal xVal As String, ByVal xtblename As String) As String
        xDynamic_Find_xAnItem_xInA_Table_1cond_String = ""
        Dim xStr As String = "xSelect_xFind_xinatbl_Where_1_Condition"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xFld1", xfield1)
            xChkexisitCmd.Parameters.AddWithValue("@xVal", xVal)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0)
                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xDynamic_Find_xAnItem_xInA_Table_String(ByVal xfield As String, ByVal xtblename As String) As String
        xDynamic_Find_xAnItem_xInA_Table_String = ""
        Dim xStr As String = "xSelect_xFind_xinatbl_"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0)
                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xDynamic_Find_xAnItem_xInA_Table(ByVal xfield As String, ByVal xtblename As String) As Integer
        Dim xStr As String = "xSelect_xFind_xinatbl_"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0)
                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xDynamic_Find_xAnItem_xInA_Table_1cond(ByVal xfield As String, ByVal xfield1 As String, ByVal xVal As String, ByVal xtblename As String) As Integer
        Dim xStr As String = "xSelect_xFind_xinatbl_Where_1_Condition"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xFld1", xfield1)
            xChkexisitCmd.Parameters.AddWithValue("@xVal", xVal)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0)
                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
   
    Public Function xDynamic_Find_xAnItem_xInA_Table_1cond_TrueFalse(ByVal xfield As String, ByVal xfield1 As String, ByVal xVal As String, ByVal xtblename As String) As Boolean
        Dim xStr As String = "xSelect_xFind_bool_xinatbl_Where_1_Condition"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xFld1", xfield1)
            xChkexisitCmd.Parameters.AddWithValue("@xVal", xVal)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0)
                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function
    Public Function xDynamic_COUNT_xAnItem_xInA_Table_1cond(ByVal xfield As String, ByVal xfield1 As String, ByVal xVal As String, ByVal xtblename As String) As Integer
        Dim xStr As String = "xSelect_xCOUNT_xinatbl_Where_1_Condition"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xFld1", xfield1)
            xChkexisitCmd.Parameters.AddWithValue("@xVal", xVal)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitRdr = xChkexisitCmd.ExecuteReader
            While xChkexisitRdr.Read
                If xChkexisitRdr.IsDBNull(0) = False Then
                    Return xChkexisitRdr(0)
                Else
                    Return 0
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            xChkexisitRdr.Close()
        End Try
    End Function

    Public Sub xDynamic_Update_xAnItem_xInA_Table_1cond(ByVal xfield As String, ByVal xfield1 As String, ByVal xVal As String, ByVal xtblename As String, ByVal xUpdateval As String)
        Try
            Dim xStr As String = "xUpdate_xArec_xinatbl_Cond1"
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@xFld", xfield)
            xChkexisitCmd.Parameters.AddWithValue("@xFld1", xfield1)
            xChkexisitCmd.Parameters.AddWithValue("@xVal", xVal)
            xChkexisitCmd.Parameters.AddWithValue("@xtbl", xtblename)
            xChkexisitCmd.Parameters.AddWithValue("@xUpdateval", xUpdateval)
            xChkexisitCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
        End Try
    End Sub
    Public Function Fetch_vatrate(ByVal xSpCatid As Integer) As Double
        Try
            xSalxPurxType = ""
            VATCST = 0
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            FinActCmd = New SqlCommand("Finact_SalePurCatgry_Vatrate_Select", FinActConn2)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xSpcatid", xSpCatid)
            FinActRdr = FinActCmd.ExecuteReader
            FinActRdr.Read()
            If FinActRdr.IsDBNull(0) = False Then
                xSalxPurxType = Trim(FinActRdr(1))
                VATCST = CDbl(FinActRdr(0))
                Return FinActRdr(0)
            Else
                xSalxPurxType = ""
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try


    End Function
    Public Function Fetch_SurChargeRate(ByVal xSpCatid As Integer) As Double
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            FinActCmd = New SqlCommand("Finact_SalePurCatgry_Vatrate_Select", FinActConn2)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xSpcatid", xSpCatid)
            FinActRdr = FinActCmd.ExecuteReader
            FinActRdr.Read()
            If FinActRdr.IsDBNull(2) = False Then
                Return FinActRdr(2)
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
    Public Function xDynamic_Fetch_Dbl(ByVal xTbl As String, ByVal xFld As String, ByVal xCondFld1 As String, ByVal xCondval As Integer) As Double
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            FinActCmd = New SqlCommand("xSelect_xFind_xinatbl_Where_1_Condition_Rtrn_Dbl", FinActConn2)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xFld", xFld.Trim)
            FinActCmd.Parameters.AddWithValue("@xTbl", xTbl.Trim)
            FinActCmd.Parameters.AddWithValue("@xFld1", xCondFld1.Trim)
            FinActCmd.Parameters.AddWithValue("@xVal", CInt(xCondval))
            FinActRdr = FinActCmd.ExecuteReader
            FinActRdr.Read()
            If FinActRdr.IsDBNull(0) = False Then
                Return FinActRdr(0)
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
    Public Function xDynamic_SumOfFld_2cond(ByVal xTblName As String, ByVal xSumFld As String, ByVal xFldCond As String _
                                            , ByVal xFldCond1 As String, ByVal xCondVal As String, ByVal xCondVal1 As String) As Double
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            FinActCmd = New SqlCommand("Finact_SumOfFld_2cond_Double_Select", FinActConn2)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@tbl", xTblName.Trim)
            FinActCmd.Parameters.AddWithValue("@fld", xSumFld.Trim)
            FinActCmd.Parameters.AddWithValue("@CONDfld", xFldCond.Trim)
            FinActCmd.Parameters.AddWithValue("@CONDval", xCondVal)
            FinActCmd.Parameters.AddWithValue("@CONDfld1", xFldCond1)
            FinActCmd.Parameters.AddWithValue("@CONDval1 ", xCondVal1)
            FinActRdr = FinActCmd.ExecuteReader
            FinActRdr.Read()
            If FinActRdr.IsDBNull(0) = False Then
                Return FinActRdr(0)
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
    Public Function xFetch_NetBalance(ByVal xSelctdId As Integer, ByVal xlblType As Label) As Double
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            FinActCmd = New SqlCommand("Finact_Rpt_xCurntBalance_Select", FinActConn2)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xSelctdId", CInt(xSelctdId))

            FinActRdr = FinActCmd.ExecuteReader
            FinActRdr.Read()
            If FinActRdr.IsDBNull(0) = False Then
                xlblType.Text = Trim(FinActRdr("XTYPE"))
                Return FinActRdr("XNETBALANCE")
            Else
                xlblType.Text = Trim(FinActRdr(""))
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
    Public Function xFetch_xLastPurRate_SelAcct(ByVal xSelctdAcctId As Integer, ByVal xSelctdItmId As Integer, ByVal xLblDt As Label) As Double
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            FinActCmd = New SqlCommand("FinAct_PurEntry_LastBuyRate_Select", FinActConn2)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xSelctdSplrId", CInt(xSelctdAcctId))
            FinActCmd.Parameters.AddWithValue("@xSelctdItmId", CInt(xSelctdItmId))
            FinActRdr = FinActCmd.ExecuteReader
            FinActRdr.Read()
            If FinActRdr.IsDBNull(0) = False Then
                xLblDt.Text = Format(FinActRdr(1), "dd/MM/yyyy")
                Return FinActRdr(0)
            Else
                xLblDt.Text = ""
                Return 0
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            xLblDt.Text = ""
            Return 0
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
    Public Function xFetch_xLastSaleRate_SelAcct(ByVal xSelctdAcctId As Integer, ByVal xSelctdItmId As Integer, ByVal xLblDt As Label) As Double
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            FinActCmd = New SqlCommand("FinAct_PurEntry_LastBuyRate_Select", FinActConn2)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xSelctdSplrId", CInt(xSelctdAcctId))
            FinActCmd.Parameters.AddWithValue("@xSelctdItmId", CInt(xSelctdItmId))
            FinActRdr = FinActCmd.ExecuteReader
            FinActRdr.Read()
            If FinActRdr.IsDBNull(0) = False Then
                xLblDt.Text = Format(FinActRdr(1), "dd/MM/yyyy")
                Return FinActRdr(0)
            Else
                xLblDt.Text = ""
                Return 0
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            xLblDt.Text = ""
            Return 0
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
    Public Sub Fill_Combobox_Dynamiclly_Where_In_Cond2(ByVal Xcombobx As ComboBox, ByVal xTblname As String, ByVal xFld1 As String, ByVal xFld2 As String, _
                                                 ByVal xFldCond As String, ByVal xFldCond1 As String, ByVal xCondVal As String, ByVal xCondVal1 As String, ByVal xCondVal2 As String)
        Dim xStr As String = "Finact_xTbl_xCond2_where_In_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@Fld1", xFld1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@Fld2", xFld2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond", xFldCond.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond1", xFldCond1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal", xCondVal.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal1", xCondVal1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal2", xCondVal2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@TblName", xTblname.Trim)
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xFld1
            Xcombobx.DisplayMember = xFld2
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_Combobox_Dynamiclly_Where_In_Cond2_And_NOT_COND(ByVal Xcombobx As ComboBox, ByVal xTblname As String, ByVal xFld1 As String, ByVal xFld2 As String, _
                                                ByVal xFldCond As String, ByVal xFldCond1 As String, ByVal xCondVal As String, ByVal xCondVal1 As String, ByVal xCondVal2 As String _
                                                , ByVal xFldCond2 As String, ByVal xCondVal3 As String)
        Dim xStr As String = "Finact_xTbl_xCond2_where_In_And_Not_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@Fld1", xFld1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@Fld2", xFld2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond", xFldCond.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond1", xFldCond1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond2", xFldCond2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal", xCondVal.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal1", xCondVal1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal2", xCondVal2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal3", xCondVal3.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@TblName", xTblname.Trim)
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xFld1
            Xcombobx.DisplayMember = xFld2
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_Combobox_Dynamiclly_Where_Cond2_NotIn_COND(ByVal Xcombobx As ComboBox, ByVal xTblname As String, ByVal xFld1 As String, ByVal xFld2 As String, _
                                                ByVal xFldCond As String, ByVal xFldCond1 As String, ByVal xCondVal As String, ByVal xCondVal1 As String, ByVal xCondVal2 As String, ByVal xDelStatus As String, ByVal xDelVal As String)
        Dim xStr As String = "Finact_xTbl_xCond2_where_NotIn_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@Fld1", xFld1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@Fld2", xFld2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond", xFldCond.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond1", xFldCond1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal", xCondVal.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal1", xCondVal1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal2", xCondVal2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@TblName", xTblname.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@DelStatus", xDelStatus.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@DelVal", CInt(xDelVal))
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xFld1
            Xcombobx.DisplayMember = xFld2
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_Combobox_Dynamiclly_Where_Cond2_1In_and_1notin(ByVal Xcombobx As ComboBox, ByVal xTblname As String, ByVal xFld1 As String, ByVal xFld2 As String, _
                                               ByVal xFldCond As String, ByVal xFldCond1 As String, ByVal xCondVal As String, ByVal xCondVal2 As String, ByVal xDelStatus As String, ByVal xDelVal As String)
        Dim xStr As String = "Finact_xTbl_xCond2_where_1In_and_1NotIn_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@Fld1", xFld1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@Fld2", xFld2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond", xFldCond.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond1", xFldCond1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal", xCondVal.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@CondVal2", xCondVal2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@TblName", xTblname.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@DelStatus", xDelStatus.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@DelVal", CInt(xDelVal))
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xFld1
            Xcombobx.DisplayMember = xFld2
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub Fill_Combobox_Dynamiclly_Where_LikeCond1(ByVal Xcombobx As ComboBox, ByVal xTblname As String, ByVal xFld1 As String, ByVal xFld2 As String, _
                                               ByVal xFldCond As String, ByVal xCondVal As String, ByVal xDelStatus As String, ByVal xDelVal As Integer)
        Dim xStr As String = "xFilCmbx_xDynamic_with_LikeCond_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            xChkexisitCmd = New SqlCommand(xStr, FinActConn1)
            xChkexisitCmd.CommandType = CommandType.StoredProcedure
            xChkexisitCmd.Parameters.AddWithValue("@Fldid", xFld1.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@Fldname", xFld2.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@FldCond", xFldCond.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@ValCond", xCondVal.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@Tbl", xTblname.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@DelStatus", xDelStatus.Trim)
            xChkexisitCmd.Parameters.AddWithValue("@DelVal", xDelVal)
            SqlAdptr = New SqlDataAdapter(xChkexisitCmd)
            dtaset = New DataSet(xChkexisitCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Xcombobx.DataSource = dtaset.Tables(0)
            Xcombobx.ValueMember = xFld1
            Xcombobx.DisplayMember = xFld2
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            xChkexisitCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub x_VAT_Forms_xFillSalePurTable(ByVal xSpStr As String, ByVal xSdate As Date, ByVal xEdate As Date)
        Try
            If FinActConn2.State Then FinActConn2.Close()
            FinActConn2.Open()
            FinActCmd = New SqlCommand(xSpStr.Trim, FinActConn2)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xSdate", xSdate)
            FinActCmd.Parameters.AddWithValue("@xEdate", xEdate)
            FinActCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            FinActCmd.Dispose()
        End Try
    End Sub
   
    Public Function xxVATrtrnStatus(ByVal xFldName As String, ByVal xCondFldName As String, ByVal xCondVal As Integer, ByVal xTblName As String) As Boolean
        Try
            xxVATrtrnStatus = False
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_Chk_VATrtrnStatus_Select", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@xFldName", Trim(xFldName))
            FinActCmd.Parameters.AddWithValue("@xCondFldName", Trim(xCondFldName))
            FinActCmd.Parameters.AddWithValue("@xRecId", CInt(xCondVal))
            FinActCmd.Parameters.AddWithValue("@xTblName", Trim(xTblName))
            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    Return FinActRdr(0)
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Function
    ''Public Function xCheckxSalePur_VATStatus(ByVal xxSPtype As String) As Integer
    ''    Try
    ''        Dim xxInt As Integer = 0
    ''        Select Case Trim(xxSPtype)
    ''            Case "WITHIN STATE", "FROM EXMPT.UNIT SOLD TO OTHER THAN TAXABLE PRSN", "INTER STATE UN-REGD. DEALER", "OTHER THAN TAXABLE", "WITHIN STATE UN-REGD. DEALER"
    ''                Return 1 '===SURCHARGE APPLICABLE
    ''            Case "UNDER WORKS CONTRACT" '==WITH IN STATE
    ''                Return 2 '===SURCHARGE APPLICABLE AFTER LABOUR CHARGE DEDUCTION 
    ''            Case "UNDER WORKS CONTRACT INTERSTATE", "INTER STATE"
    ''                Return 3 '===SURCHARGE  NOT APPLICABLE,  LABOUR CHARGE DEDUCTION 
    ''        End Select
    ''    Catch ex As Exception

    ''    End Try

    ''End Function
    Public Sub xCrRpt_SaveAndPrint(ByVal xRpt As Object, ByVal xCopyNo As Integer)
        Try

            Dim DiskOpts As CrystalDecisions.Shared.DiskFileDestinationOptions = New CrystalDecisions.Shared.DiskFileDestinationOptions()
            xRpt.ExportOptions.ExportDestinationType = CrystalDecisions.[Shared].ExportDestinationType.DiskFile
            ' You also have the option to export the report to other sources
            ' like Microsoft Exchange, MAPI, etc.        

            xRpt.ExportOptions.ExportFormatType = CrystalDecisions.[Shared].ExportFormatType.RichText

            'Here we are exporting the report to a .rpt format.  You can
            ' also choose any of the other formats specified above. 
            Dim xxCrRpt As String = "xxCrRptBill" & xCopyNo
            DiskOpts.DiskFileName = Application.StartupPath + "\" + xxCrRpt + ".rtf"

            'If you do not specify the exact path here (i.e. including the drive and Directory),

            'then you would find your output file landing up in the

            'c:\WinNT\System32 directory - atleast in case of a

            ' Windows 2000 System


            xRpt.ExportOptions.DestinationOptions = DiskOpts
            'The Reports Export Options does not have a filename property

            'that can be directly set. Instead, you will have to use

            'the DiskFileDestinationOptions object and set its DiskFileName

            'property to the file name (including the path) of your  choice.

            'Then you would set the Report Export Options

            'DestinationOptions property to point to the

            'DiskFileDestinationOption object. 



            xRpt.Export()

            'This statement exports the report based on the previously set properties.



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub xCOINFO_WRKCONTRCT()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("Finact_Cogatemstr_Info_Select", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    xWrkContRate = FinActRdr("COLBRPUR")    '==LABOUR % ON PURCHASE
                    xWrkContRate1 = FinActRdr("COLBRSALE") '==LABOUR % ON SALE
                    xTDSminLmt = FinActRdr("COTDSLMT") '== TDS LIMIT
                    xWrkContTDSRate = FinActRdr("COTDSRATE") '==TDS RATE 
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Sub
    Public Function xCal_xInvoiceSurCharge(ByVal xVATid As Integer, ByVal xVATamt As Double, ByVal xLblSurChrg As Label) As Double
        Try

            Dim xSurChargAmt As Double = 0
            Dim xSurChargRate As Double = 0
            If xVATid > 0 Then
                xSurChargRate = Fetch_SurChargeRate(CInt(xVATid))
            End If
            If xSurChargRate = 0 Then
                xSurChargAmt = 0
            Else
                xSurChargAmt = Math.Round(xVATamt * xSurChargRate / 100, 3)
            End If
            xLblSurChrg.Text = "Surcharge (" & FormatNumber(xSurChargRate, 2) & "%)"
            Return xSurChargAmt

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub CoInfo()

        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            Dim DcrpPass As New EnCryp_DeCryp_String
            FinActCmd = New SqlCommand("FinactCogatemstr_Select", FinActConn1)
            FinActRdr = FinActCmd.ExecuteReader
            FinActRdr.Read()
            CoName = DcrpPass.Decrypt(FinActRdr("coname"))
            VATNO = FinActRdr("covat")
            Adrs1 = FinActRdr("adrs1")
            Adrs2 = FinActRdr("adrs2")
            Cty = FinActRdr("adrscty")
            State = FinActRdr("adrsstate")
            Contry = FinActRdr("adrscontry")
            PhNo = FinActRdr("adrsphwork")
            Pin = FinActRdr("adrspin")
            Email = FinActRdr("adrsemail")
            FaxNo = FinActRdr("adrsfaxno")
            CoOnrName = FinActRdr("coonwr")
            CoOnrDesi = FinActRdr("COONRDESI")
            If FinActRdr("Costatus") = "CoFrm" Then
                CoStatus = "COMPANY"
            Else
                CoStatus = "PROPRIETORSHIP"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try


    End Sub
    Public Sub xFillLstVewWith2Recrd(ByVal xLstVew As ListView, ByVal xSrchStr As String, ByVal xFld1 As String _
                                     , ByVal xFld2 As String, ByVal xTbl As String, ByVal xSrchFld As String)
        Try
            xLstVew.Items.Clear()
            Dim xls As ListViewItem
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("select_2Rec_where_like_Cond", FinActConn)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue("@Fld1", xFld1.Trim)
            FinActCmd.Parameters.AddWithValue("@Fld2", xFld2.Trim)
            FinActCmd.Parameters.AddWithValue("@ta", xTbl.Trim)
            FinActCmd.Parameters.AddWithValue("@id", xSrchFld.Trim)
            FinActCmd.Parameters.AddWithValue("@idval", xSrchStr.Trim)
            FinActRdr = FinActCmd.ExecuteReader
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    xls = xLstVew.Items.Add(Trim(FinActRdr(1)))
                    xls.SubItems.Add(FinActRdr(0))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
            If xLstVew.Items.Count = 0 Then
                xLstVew.Visible = False
                xLstVew.Enabled = False
            Else
                xLstVew.Visible = True
                xLstVew.Enabled = True

                xLstVew.Items(xLstVew.Items.Count - 1).Selected = True
                xLstVew.Items(xLstVew.Items.Count - 1).Focused = True
            End If

        End Try
    End Sub
    Public Sub xFill_Cmbx_DynamicStorPro_where_Cond1(ByVal xSp As String, ByVal xCondVal As String, ByVal xCmbx As ComboBox _
                                                    , ByVal xValMembr As String, ByVal xDsplaMembr As String, ByVal xCondParm As String)
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            FinActCmd = New SqlCommand(xSp, FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue(xCondParm, xCondVal.Trim)
            SqlAdptr = New SqlDataAdapter(FinActCmd)
            dtaset = New DataSet(FinActCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            xCmbx.DataSource = dtaset.Tables(0)
            xCmbx.ValueMember = xValMembr
            xCmbx.DisplayMember = xDsplaMembr
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub xFill_Cmbx_DynamicStorProcedure(ByVal xSp As String, ByVal xCmbx As ComboBox, ByVal xValMembr As String, ByVal xDsplaMembr As String, ByVal xStlTypeId As String, ByVal xParm As String)
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            FinActCmd = New SqlCommand(xSp, FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            If Len(xParm) > 0 Then
                FinActCmd.Parameters.AddWithValue(xParm, CInt(xStlTypeId))
            End If
            SqlAdptr = New SqlDataAdapter(FinActCmd)
            dtaset = New DataSet(FinActCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            xCmbx.DataSource = dtaset.Tables(0)
            xCmbx.ValueMember = xValMembr
            xCmbx.DisplayMember = xDsplaMembr
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub xFill_Cmbx_DynamicStorPro_where_Cond2(ByVal xSp As String, ByVal xCondVal As String, ByVal xCondVal1 As String, ByVal xCmbx As ComboBox _
                                                     , ByVal xValMembr As String, ByVal xDsplaMembr As String, ByVal xCondParm As String, ByVal xCondParm1 As String)
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            FinActCmd = New SqlCommand(xSp, FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue(xCondParm, xCondVal.Trim)
            FinActCmd.Parameters.AddWithValue(xCondParm1, xCondVal1.Trim)
            SqlAdptr = New SqlDataAdapter(FinActCmd)
            dtaset = New DataSet(FinActCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            xCmbx.DataSource = dtaset.Tables(0)
            xCmbx.ValueMember = xValMembr
            xCmbx.DisplayMember = xDsplaMembr
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
    Public Sub xFill_Cmbx_DynamicStorPro_where_Cond3(ByVal xSp As String, ByVal xCondVal As String, ByVal xCondVal1 As String, ByVal xCondVal2 As String, ByVal xCmbx As ComboBox _
                                                   , ByVal xValMembr As String, ByVal xDsplaMembr As String, ByVal xCondParm As String, ByVal xCondParm1 As String, ByVal xCondParm2 As String)
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            FinActCmd = New SqlCommand(xSp, FinActConn1)
            FinActCmd.CommandType = CommandType.StoredProcedure
            FinActCmd.Parameters.AddWithValue(xCondParm, xCondVal.Trim)
            FinActCmd.Parameters.AddWithValue(xCondParm1, xCondVal1.Trim)
            FinActCmd.Parameters.AddWithValue(xCondParm2, (xCondVal2.Trim))
            SqlAdptr = New SqlDataAdapter(FinActCmd)
            dtaset = New DataSet(FinActCmd.CommandText)
            SqlAdptr.Fill(dtaset)
            xCmbx.DataSource = dtaset.Tables(0)
            xCmbx.ValueMember = xValMembr
            xCmbx.DisplayMember = xDsplaMembr
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            SqlAdptr.Dispose()

        End Try
    End Sub
End Module

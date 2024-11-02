Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptFrm12A
    Dim EPFf12A_Cmd As SqlCommand
    Dim EPFf12A_Adptr As SqlDataAdapter
    Dim EPFf12A_Rdr As SqlDataReader
    Dim EPFf12A_Cmd2 As SqlCommand
    Dim EPFf12A_Rdr2 As SqlDataReader
    Dim EPFf12A_Cmd1 As SqlCommand
    Dim EPFf12A_Rdr1 As SqlDataReader
    Dim TellRptstatus As Boolean
    Dim Esi_Co_Code As String = ""
    Dim CrRptEpFf12A As New CrRptEPFfrm12A
    Dim odbccon1 As OdbcConnection
    Dim OdbcCmd1 As OdbcCommand
    Dim OdbcDa1 As OdbcDataAdapter
    Dim Odbcrdr1 As OdbcDataReader
    Dim OdbcCmd As SqlCommand
    Dim OdbcRdr As SqlDataReader
    Dim OdbcDa As SqlDataAdapter
    Dim RateofBonus As Double
    Private Sub FrmCrRptFrm12A_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 1025
            Me.Height = 83
            TellRptstatus = True
            CoprofileParamsEPFf12A()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnEPF12A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEPF12A.Click
        Try
            If Trim(Txtacno.Text) <> "" Then
                Me.Height = 700
                Txtacno.BackColor = Color.White
                TellRptstatus = False
                temp_tblEsiinfo_Del()
                CreatTemp_EPFF12A_tbl()
                CrVewEPFfrm112A.Enabled = True
                CoprofileParamsEPFf12A()
            Else
                Txtacno.BackColor = Color.Orange
                Txtacno.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dtpick3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtpick3.ValueChanged
        Dtpick3.MaxDate = dtpick2.Value.Date
        Dtpick3.MinDate = Dtpick1.Value.Date
    End Sub
    Private Sub CoprofileParamsEPFf12A()

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

        Dim ParmVal8 As ParameterValues = New ParameterValues()
        Dim DisVal8 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal8.Value = 1
        ParmVal8.Add(DisVal8)

        Dim ParmVal9 As ParameterValues = New ParameterValues()
        Dim DisVal9 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal9.Value = 1
        ParmVal9.Add(DisVal9)

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
                Fetch_InfoCrRptEpFf12A()
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
                Rptstr = Odbcrdr1(4)
                'End If
                ParmVal5.AddValue(Rptstr)
                ParmVal6.AddValue(Dtpick1.Value)
                ParmVal7.AddValue(dtpick2.Value)
                ParmVal8.AddValue(Dtpick3.Text)
                ParmVal9.AddValue(Txtacno.Text)

                CrRptEpFf12A.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptEpFf12A.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptEpFf12A.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptEpFf12A.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
                CrRptEpFf12A.DataDefinition.ParameterFields("Parmpfcode").ApplyCurrentValues(ParmVal5)
                CrRptEpFf12A.DataDefinition.ParameterFields("parmfromdt").ApplyCurrentValues(ParmVal6)
                CrRptEpFf12A.DataDefinition.ParameterFields("parmtodt").ApplyCurrentValues(ParmVal7)
                CrRptEpFf12A.DataDefinition.ParameterFields("parmmnth").ApplyCurrentValues(ParmVal8)
                CrRptEpFf12A.DataDefinition.ParameterFields("parmgrupno").ApplyCurrentValues(ParmVal9)
            End While
            CrVewEPFfrm112A.ReportSource = CrRptEpFf12A
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub
    Private Sub Fetch_InfoCrRptEpFf12A()
        Dim MnthNO_F As Integer = Dtpick1.Value.Month
        Dim MnthNO_T As Integer = dtpick2.Value.Month
        Try
            EPFf12A_Cmd = New SqlCommand("Select * from temp_Epf_f12a", FinActConn)
            Dim dsEsino As New DataSet(EPFf12A_Cmd.CommandText)
            EPFf12A_Adptr = New SqlDataAdapter(EPFf12A_Cmd)
            EPFf12A_Adptr.Fill(dsEsino)
            CrRptEpFf12A.SetDataSource(dsEsino.Tables(0))
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf12A_Cmd = Nothing
            EPFf12A_Adptr.Dispose()

        End Try
    End Sub
    Private Sub CreatTemp_EPFF12A_tbl()
        Dim F12ayr As Integer = Dtpick3.Value.Year
        Dim F12amnth As Integer = Dtpick3.Value.Month
        Try
            EPFf12A_Cmd = New SqlCommand("Temp_EPF_f12a_Select_Insert", FinActConn)
            EPFf12A_Cmd.CommandType = CommandType.StoredProcedure
            EPFf12A_Cmd.Parameters.AddWithValue("@F12ayr", F12ayr)
            EPFf12A_Cmd.Parameters.AddWithValue("@f12amnth", F12amnth)
            EPFf12A_Cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf12A_Cmd.Dispose()
        End Try

    End Sub

    Private Sub temp_tblEsiinfo_Del()
        Try
            EPFf12A_Cmd = New SqlCommand("delete from Temp_Epf_f12a", FinActConn)
            EPFf12A_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf12A_Cmd.Dispose()
        End Try
    End Sub

    Private Sub Allcontrols_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtacno.KeyDown, Dtpick1.KeyDown _
    , dtpick2.KeyDown, Dtpick3.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
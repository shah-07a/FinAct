Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptForm10
    Dim EPFf10_Cmd As SqlCommand
    Dim EPFf10_Adptr As SqlDataAdapter
    Dim EPFf10_tbl As DataTable
    Dim EPFf10_Rdr As SqlDataReader
    Dim EPFf10_Cmd1 As SqlCommand
    Dim TellRptstatus As Boolean
    Dim CrRptEPF10 As New CrRptEpFform10
    Dim OdbcCmd1 As OdbcCommand
    Dim Odbcrdr1 As OdbcDataReader
    Dim EpfEmpId As Integer
    Dim Epfyr As Integer
    Dim Epfmnth As Integer
    Private Sub FrmCrRptForm10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 1025
            Me.Height = 89
            TellRptstatus = True
            CoprofileParamsEPFf10()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnEPF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEPF10.Click
        Try
            If Trim(TxtAcNo.Text) = "" Then
                TxtAcNo.BackColor = Color.Orange
                TxtAcNo.Focus()
            Else
                TxtAcNo.BackColor = Color.White
                Epfyr = Dtpick1.Value.Year
                Epfmnth = Dtpick1.Value.Month
                Me.Height = 700
                TellRptstatus = False
                temp_tblEpf_f10_Del()
                CreatTemp_Epf_f10_tbl()
                CrVewEpFFrm10.Enabled = True
                CoprofileParamsEPFf10()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CoprofileParamsEPFf10()
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
                    Fetch_InfoCrRptEpf_f10()
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

                    Rptstr = Odbcrdr1(4) 'Trim(TxtAcNo.Text)

                    ParmVal5.AddValue(Rptstr)
                    Dim mnthNo As Integer = Dtpick1.Value.Month

                    ParmVal6.AddValue(Trim(Dtpick1.Text))
                    ParmVal7.AddValue("")
                    CrRptEPF10.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                    CrRptEPF10.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                    CrRptEPF10.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                    CrRptEPF10.DataDefinition.ParameterFields("AcNo").ApplyCurrentValues(ParmVal4)
                    CrRptEPF10.DataDefinition.ParameterFields("Parmepfcode").ApplyCurrentValues(ParmVal5)
                    CrRptEPF10.DataDefinition.ParameterFields("parmfromdt").ApplyCurrentValues(ParmVal6)

                End While
                CrVewEpFFrm10.ReportSource = CrRptEPF10
            Catch ex As SqlException
                MsgBox(ex.Number & " " & ex.Message)
            Finally
                Odbcrdr1.Close()
                OdbcCmd1.Dispose()
            End Try
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Fetch_InfoCrRptEpf_f10()
        Try
            EPFf10_Cmd = New SqlCommand("Select * from temp_epf_f10", FinActConn)
            Dim dsEsino As New DataSet(EPFf10_Cmd.CommandText)
            EPFf10_Adptr = New SqlDataAdapter(EPFf10_Cmd)
            EPFf10_Adptr.Fill(dsEsino)
            CrRptEPF10.SetDataSource(dsEsino.Tables(0))
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf10_Cmd = Nothing
            EPFf10_Adptr.Dispose()
        End Try
    End Sub
    Private Sub CreatTemp_Epf_f10_tbl()
       
        Try
            EPFf10_Cmd = New SqlCommand("Temp_Epf_f10_Select", FinActConn)
            EPFf10_Cmd.CommandType = CommandType.StoredProcedure
            EPFf10_Cmd.Parameters.AddWithValue("@year", Epfyr)
            EPFf10_Cmd.Parameters.AddWithValue("@mnth", Epfmnth)
            EPFf10_Rdr = EPFf10_Cmd.ExecuteReader
            While EPFf10_Rdr.Read
                If EPFf10_Rdr.HasRows = True Then
                    EPFf10_Cmd1 = New SqlCommand("Temp_Epf_f10_Insert", FinActConn1)
                    EPFf10_Cmd1.CommandType = CommandType.StoredProcedure
                    EPFf10_Cmd1.Parameters.AddWithValue("@f10emppfno", EPFf10_Rdr("empnewpfno"))
                    EPFf10_Cmd1.Parameters.AddWithValue("@f10empname", EPFf10_Rdr("empname"))
                    EPFf10_Cmd1.Parameters.AddWithValue("@f10empfname", EPFf10_Rdr("empfather"))
                    EPFf10_Cmd1.Parameters.AddWithValue("@f10levdt", EPFf10_Rdr("empothrrelevdt"))
                    EPFf10_Cmd1.Parameters.AddWithValue("@f10levreson", EPFf10_Rdr("empothrresireson"))
                    EPFf10_Cmd1.Parameters.AddWithValue("@f10remark", EPFf10_Rdr("empothrresiremrk"))
                    EPFf10_Cmd1.ExecuteNonQuery()
                End If

            End While
            If EPFf10_Rdr.HasRows = True Then
                EPFf10_Cmd1.Dispose()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf10_Cmd.Dispose()
            EPFf10_Rdr.Close()

        End Try

    End Sub

    Private Sub temp_tblEpf_f10_Del()
        Try
            EPFf10_Cmd = New SqlCommand("delete from Temp_Epf_f10", FinActConn)
            EPFf10_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf10_Cmd.Dispose()
        End Try
    End Sub

    Private Sub aLLControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAcNo.KeyDown, Dtpick1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptForm13A
    Dim EPFf13_A_Cmd As SqlCommand
    Dim EPFf13_A_Adptr As SqlDataAdapter
    Dim EPFf13_A_tbl As DataTable
    Dim EPFf13_A_Rdr As SqlDataReader
    Dim EPFf13_A_Cmd1 As SqlCommand
    Dim TellRptstatus As Boolean
    Dim CrRptEPf13a As New CrRptfrm13A
    Dim OdbcCmd1 As OdbcCommand
    Dim Odbcrdr1 As OdbcDataReader
    Dim EpfEmpId As Integer
    Dim IndxEpf As Integer
    Private Sub FrmCrRptForm13A_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 1025
            Me.Height = 229
            Me.Top = 0
            Me.Left = 0
            TellRptstatus = True
            CoprofileParamsEPFf13a()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnEPF13a_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEPF13a.Click
        Try
            Chk_empty_val()
            If IndxEpf <> 0 Then
                IndxEpf = 0
                Me.CrVewEPFfrm13A.Enabled = False
                Exit Sub
            Else
                Me.Height = 700
                Me.CrVewEPFfrm13A.Enabled = True
                temp_tblEpf_f13a_Del()
                CreatTemp_Epf_f13a_tbl()
                TellRptstatus = False
                CoprofileParamsEPFf13a()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Dtpick1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpick1.GotFocus
        Dtpick1.MaxDate = Now.Date
    End Sub

    Private Sub Dtpick1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpick1.Leave
        If Trim(CmbxEpfEmpname.Text) <> "" Then
            Me.Panel2.Enabled = True
            DtpickLev.MaxDate = Dtpick1.Value.Date
            CmbxEpfEmpname.BackColor = Color.White
            TxtemplrName.Focus()
        Else
            Me.Panel2.Enabled = False
            CmbxEpfEmpname.BackColor = Color.Orange
            CmbxEpfEmpname.Focus()

        End If

    End Sub
    Private Sub CoprofileParamsEPFf13a()
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

        Dim ParmVal15 As ParameterValues = New ParameterValues()
        Dim DisVal15 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal15.Value = 1
        ParmVal15.Add(DisVal15)

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
                Rptstr = Trim(TxtemplrName.Text) 'Odbcrdr1(3)
                ParmVal5.AddValue(Rptstr)
                ParmVal6.AddValue(Onr1)
                ParmVal7.AddValue(Onr2)
                ParmVal8.AddValue(Trim(Txtemplradrs.Text))
                ParmVal9.AddValue(Trim(CmbxEpfEmpname.Text))
                ParmVal10.AddValue(Trim(TxtPfAcNo.Text))
                ParmVal11.AddValue(Trim(TxtPensnNo.Text))
                ParmVal12.AddValue(Trim(CmbxPemplrEpf.Text))
                ParmVal13.AddValue(Trim(Cmbxemplr.Text))
                ParmVal14.AddValue(Trim(DtpickLev.Value.Date))
                ParmVal15.AddValue(Trim(Dtpick1.Value.Date))

                If TellRptstatus = False Then
                    Fetch_InfoCrRptEpf_f13a()
                End If

                CrRptEPf13a.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptEPf13a.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptEPf13a.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptEPf13a.DataDefinition.ParameterFields("Onwr").ApplyCurrentValues(ParmVal4) 'owner name
                CrRptEPf13a.DataDefinition.ParameterFields("ParmExemplr").ApplyCurrentValues(ParmVal5)
                CrRptEPf13a.DataDefinition.ParameterFields("parmonradrs").ApplyCurrentValues(ParmVal6)
                CrRptEPf13a.DataDefinition.ParameterFields("parmonrdesi").ApplyCurrentValues(ParmVal7)
                CrRptEPf13a.DataDefinition.ParameterFields("parmexemplradrs").ApplyCurrentValues(ParmVal8)
                CrRptEPf13a.DataDefinition.ParameterFields("parmempname").ApplyCurrentValues(ParmVal9)
                CrRptEPf13a.DataDefinition.ParameterFields("parmexpfno").ApplyCurrentValues(ParmVal10)
                CrRptEPf13a.DataDefinition.ParameterFields("parmexpensnno").ApplyCurrentValues(ParmVal11)
                CrRptEPf13a.DataDefinition.ParameterFields("parmtype1").ApplyCurrentValues(ParmVal12)
                CrRptEPf13a.DataDefinition.ParameterFields("parmtype2").ApplyCurrentValues(ParmVal13)
                CrRptEPf13a.DataDefinition.ParameterFields("parmdtlev").ApplyCurrentValues(ParmVal14)
                CrRptEPf13a.DataDefinition.ParameterFields("parmdt").ApplyCurrentValues(ParmVal15)
            End While
            CrVewEPFfrm13A.ReportSource = CrRptEPf13a
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub


    Private Sub Fetch_InfoCrRptEpf_f13a()

        Try
            EPFf13_A_Cmd = New SqlCommand("Select * from temp_epf_f13a ", FinActConn) ' where epfmnth between '" & (MnthNO_F) & "'and '" & (MnthNO_T) & "' 
            Dim dsEsino As New DataSet(EPFf13_A_Cmd.CommandText)
            EPFf13_A_Adptr = New SqlDataAdapter(EPFf13_A_Cmd)
            EPFf13_A_Adptr.Fill(dsEsino)
            CrRptEPf13a.SetDataSource(dsEsino.Tables(0))
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf13_A_Cmd = Nothing

            EPFf13_A_Adptr.Dispose()

        End Try
    End Sub
    Private Sub CreatTemp_Epf_f13a_tbl()
        Dim esirecno As Integer = 1
        Dim esiempstatus As String = ""
        Try
            EPFf13_A_Cmd = New SqlCommand("Temp_Epf_f13a_Select", FinActConn)
            EPFf13_A_Cmd.CommandType = CommandType.StoredProcedure
            EPFf13_A_Cmd.Parameters.AddWithValue("@13aempid", EpfEmpId)
            EPFf13_A_Rdr = EPFf13_A_Cmd.ExecuteReader
            While EPFf13_A_Rdr.Read
                If EPFf13_A_Rdr.HasRows = True Then
                    EPFf13_A_Cmd1 = New SqlCommand("Temp_Epf_f13a_Insert", FinActConn1)
                    EPFf13_A_Cmd1.CommandType = CommandType.StoredProcedure
                    EPFf13_A_Cmd1.Parameters.AddWithValue("@empfather", EPFf13_A_Rdr("empfather"))
                    EPFf13_A_Cmd1.Parameters.AddWithValue("@empjndt", EPFf13_A_Rdr("empjndt"))
                    EPFf13_A_Cmd1.Parameters.AddWithValue("@emppfno", EPFf13_A_Rdr("empnewpfno"))
                    EPFf13_A_Cmd1.Parameters.AddWithValue("@emppfno1", EPFf13_A_Rdr("empnewpfno"))

                    EPFf13_A_Cmd1.ExecuteNonQuery()
                End If

            End While
            If EPFf13_A_Rdr.HasRows = True Then
                EPFf13_A_Cmd1.Dispose()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf13_A_Cmd.Dispose()
            EPFf13_A_Rdr.Close()

        End Try

    End Sub

    Private Sub temp_tblEpf_f13a_Del()
        Try
            EPFf13_A_Cmd = New SqlCommand("delete from Temp_Epf_f13a", FinActConn)
            EPFf13_A_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf13_A_Cmd.Dispose()
        End Try
    End Sub




    Private Sub Fetch_empinfo()

        EPFf13_A_Adptr = New SqlDataAdapter("Select empid,empname from finactempmstr order by empname", FinActConn)
        Try
            EPFf13_A_tbl = New DataTable
            EPFf13_A_tbl.Clear()
            EPFf13_A_Adptr.Fill(EPFf13_A_tbl)
            CmbxEpfEmpname.DataSource = EPFf13_A_tbl
            CmbxEpfEmpname.DisplayMember = "empname"
            CmbxEpfEmpname.ValueMember = "Empid"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPFf13_A_Adptr.Dispose()
        End Try
    End Sub

    Private Sub CmbxEpfEmpname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEpfEmpname.GotFocus
        Try
            Me.CmbxEpfEmpname.DroppedDown = True
            Fetch_empinfo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxEpfEmpname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEpfEmpname.Leave
        Try
            Me.CmbxEpfEmpname.DroppedDown = False
            EpfEmpId = CmbxEpfEmpname.SelectedValue
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Chk_empty_val()
        With Cmbxemplr
            If Trim(.Text) = "" Then
                .BackColor = Color.Orange
                .Focus()
                IndxEpf += 1
            Else
                .BackColor = Color.White
            End If
        End With

        With TxtPensnNo
            If Trim(.Text) = "" Then
                .BackColor = Color.Orange
                .Focus()
                IndxEpf += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With TxtPfAcNo
            If Trim(.Text) = "" Then
                .BackColor = Color.Orange
                .Focus()
                IndxEpf += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxPemplrEpf
            If Trim(.Text) = "" Then
                .BackColor = Color.Orange
                .Focus()
                IndxEpf += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtemplradrs
            If Trim(.Text) = "" Then
                .BackColor = Color.Orange
                .Focus()
                IndxEpf += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With TxtemplrName
            If Trim(.Text) = "" Then
                .BackColor = Color.Orange
                .Focus()
                IndxEpf += 1
            Else
                .BackColor = Color.White
            End If
        End With


    End Sub

    Private Sub Cmbxemplr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxemplr.GotFocus
        Try
            Me.Cmbxemplr.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPemplrEpf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPemplrEpf.GotFocus
        Try
            Me.CmbxPemplrEpf.DroppedDown = True

        Catch ex As Exception

        End Try
    End Sub
    Private Sub allcontrols_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPensnNo.KeyDown, Cmbxemplr.KeyDown _
    , CmbxEpfEmpname.KeyDown, CmbxPemplrEpf.KeyDown, Dtpick1.KeyDown, DtpickLev.KeyDown, Txtemplradrs.KeyDown, TxtemplrName.KeyDown, TxtPfAcNo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxemplr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxemplr.Leave
        Try
            Me.Cmbxemplr.DroppedDown = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPemplrEpf_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPemplrEpf.Leave
        Try
            Me.CmbxPemplrEpf.DroppedDown = False
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptEPFBnkChlan
    Dim EPF_BnkChlan_Cmd As SqlCommand
    Dim EPF_BnkChlan_Cmd1 As SqlCommand
    Dim EPF_BnkChlan_Adptr As SqlDataAdapter
    Dim EPF_BnkChlan_Rdr As SqlDataReader
    Dim EPF_BnkChlan_Cmd2 As SqlCommand
    Dim EPF_BnkChlan_Rdr2 As SqlDataReader
    Dim EPF_BnkChlan_Rdr1 As SqlDataReader
    Dim TellRptstatus As Boolean
    Dim CrRptEpfBnk As New CrRptEPFBnkChlan
    Dim OdbcCmd1 As OdbcCommand
    Dim Odbcrdr1 As OdbcDataReader
    Dim EPF_BnkChlan_DtaTble As DataTable
    Dim IndxEsi As Integer
    Dim EPF_Amt As String

    Private Sub BtnEsi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEsibnk.Click
        Try
            Call chkvalesi()
            If IndxEsi <> 0 Then
                IndxEsi = 0
                Exit Sub
            Else
                Me.Height = 700
                temp_tblEsibnkchlan_Del()
                CreatTemp_EsiBnkchlan_tbl()
                TellRptstatus = False
                CoprofileParamsEsiBnkChlan()
                CrVewEPFBnkChlan.Enabled = True
            End If
        Catch ex As Exception

        End Try

    End Sub

   

    Private Sub CoprofileParamsEsiBnkChlan()
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
                Fetch_InfoCrRptEsibnkchlan()
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
                Rptstr = Odbcrdr1(4)
                ParmVal5.AddValue(Rptstr)
                If Trim(EPF_Amt) = "" Then
                    ParmVal6.AddValue("Nil")
                Else
                    ParmVal6.AddValue(EPF_Amt)
                End If
                CrRptEpfBnk.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptEpfBnk.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptEpfBnk.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptEpfBnk.DataDefinition.ParameterFields("Parmepfcode").ApplyCurrentValues(ParmVal5)
                CrRptEpfBnk.DataDefinition.ParameterFields("ParmAmtWord").ApplyCurrentValues(ParmVal6)
            End While
            CrVewEPFBnkChlan.ReportSource = CrRptEpfBnk
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub

    Private Sub Cmbxtypw_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxtypw.GotFocus
        If Cmbxtypw.SelectedIndex = -1 Then
            Cmbxtypw.SelectedIndex = 0
        End If
    End Sub

    Private Sub Cmbxtypw_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxtypw.Leave
        If Cmbxtypw.SelectedIndex = 1 Then
            Dtpick2.Enabled = False
            cmbxbnkname.Enabled = False
            TxtNratn.Text = "Cash "
        Else
            Dtpick2.Enabled = True
            cmbxbnkname.Enabled = True
            TxtNratn.Text = "Ch No."
        End If
    End Sub

    Private Sub CreatTemp_EsiBnkchlan_tbl()
        Dim Epfbnkyr As Integer = Dtpick1.Value.Year
        Dim EpfBnkmnth As Integer = Dtpick1.Value.Month

        Try
            EPF_BnkChlan_Cmd = New SqlCommand("Temp_EmpEpfbnkclan_Select", FinActConn)
            EPF_BnkChlan_Cmd.CommandType = CommandType.StoredProcedure
            EPF_BnkChlan_Cmd.Parameters.AddWithValue("@epfbnkyr", Epfbnkyr)
            EPF_BnkChlan_Cmd.Parameters.AddWithValue("@epfbnkmnth", EpfBnkmnth)
            EPF_BnkChlan_Rdr = EPF_BnkChlan_Cmd.ExecuteReader
            While EPF_BnkChlan_Rdr.Read
                If EPF_BnkChlan_Rdr.HasRows = True Then
                    EPF_BnkChlan_Cmd1 = New SqlCommand("Temp_EmpEpfbnkchlan_Insert", FinActConn1)
                    EPF_BnkChlan_Cmd1.CommandType = CommandType.StoredProcedure
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ccpf", EPF_BnkChlan_Rdr("epf"))
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ccvpf", EPF_BnkChlan_Rdr("vpf"))
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ccmnth", EPF_BnkChlan_Rdr("mnth"))
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@cctotlwag", EPF_BnkChlan_Rdr("total_wages"))
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ccemplrpf", EPF_BnkChlan_Rdr("emplr_contripf"))
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ccemplrpnsn", EPF_BnkChlan_Rdr("emplr_contripensn"))
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ebnratn", Trim(TxtNratn.Text))
                    If Dtpick2.Enabled = True Then
                        EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ebdt", Trim(Dtpick2.Value.Date))
                        EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ebbname", Trim(cmbxbnkname.Text))
                    Else
                        EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ebdt", 0)
                        EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ebbname", "")
                    End If
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ebdepdt", 0)
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ebdepby", Cmbxempname.Text.Trim)
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@twrkr", EPF_BnkChlan_Rdr("totlwrkr"))
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ac2", EPF_BnkChlan_Rdr("acno2"))
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ac21", EPF_BnkChlan_Rdr("acno21"))
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@ac22", EPF_BnkChlan_Rdr("acno22"))
                    EPF_BnkChlan_Cmd1.Parameters.AddWithValue("@eamtword", CDbl(0.0))
                    EPF_BnkChlan_Cmd1.ExecuteNonQuery()
                End If
            End While

        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            If EPF_BnkChlan_Rdr.HasRows = True Then
                EPF_BnkChlan_Cmd1.Dispose()
            End If

            EPF_BnkChlan_Cmd.Dispose()
            EPF_BnkChlan_Rdr.Close()


            Try
                EPF_Amt = ""
                EPF_BnkChlan_Cmd = New SqlCommand("select sum(ccpf+ccemplrpf+ccemplrpnsn+ccacno2+ccacno21+ccacno22) from temp_Epf_bnkchlan", FinActConn)
                EPF_BnkChlan_Rdr = EPF_BnkChlan_Cmd.ExecuteReader
                EPF_BnkChlan_Rdr.Read()
                If EPF_BnkChlan_Rdr.IsDBNull(0) = False Then
                    EPF_Amt = RupeesToWord(EPF_BnkChlan_Rdr(0))
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Esi sum Error Handler")
            Finally
                EPF_BnkChlan_Cmd.Dispose()
                EPF_BnkChlan_Rdr.Close()
            End Try
        End Try

    End Sub

    Private Sub temp_tblEsibnkchlan_Del()
        Try
            EPF_BnkChlan_Cmd = New SqlCommand("delete from temp_Epf_bnkchlan", FinActConn)
            EPF_BnkChlan_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_BnkChlan_Cmd.Dispose()
        End Try
    End Sub

    Private Sub Fetch_InfoCrRptEsibnkchlan()
        Try
            EPF_BnkChlan_Cmd = New SqlCommand("Select * from temp_Epf_bnkchlan", FinActConn)
            Dim dsEsino As New DataSet(EPF_BnkChlan_Cmd.CommandText)
            EPF_BnkChlan_Adptr = New SqlDataAdapter(EPF_BnkChlan_Cmd)
            EPF_BnkChlan_Adptr.Fill(dsEsino)
            CrRptEpfBnk.SetDataSource(dsEsino.Tables(0))
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_BnkChlan_Cmd = Nothing

            EPF_BnkChlan_Adptr.Dispose()

        End Try
    End Sub

    Private Sub chkvalesi()
        If Cmbxtypw.Text.Trim = "" Or TxtNratn.Text.Trim = "" Then
            IndxEsi += 1
            Cmbxtypw.Focus()
        End If
        If Cmbxtypw.Text.Trim = "By Cheque" Then
            'If Dtpick2.Value > Dtpick3.Value Then
            '    IndxEsi += 1
            '    MsgBox("Cheque date should be less or equal than deposit date", MsgBoxStyle.Information, "Error hanler")
            '    Dtpick2.Focus()
            'End If
            If cmbxbnkname.Text.Trim = "" Then
                IndxEsi += 1
                MsgBox("Bank name should not be blank", MsgBoxStyle.Information, "Error hanler")
                cmbxbnkname.BackColor = Color.PaleTurquoise
                cmbxbnkname.Focus()
            Else
                cmbxbnkname.BackColor = Color.White
            End If
        End If
        If Cmbxempname.Text.Trim = "" Then
            IndxEsi += 1
            MsgBox("Depositer name should not be blank", MsgBoxStyle.Information, "Error hanler")
            Cmbxempname.BackColor = Color.PaleTurquoise
            Cmbxempname.Focus()
        Else
            Cmbxempname.BackColor = Color.White

        End If

    End Sub

    Private Sub TxtNratn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNratn.KeyDown, cmbxbnkname.KeyDown _
    , Cmbxempname.KeyDown, Cmbxtypw.KeyDown, Dtpick1.KeyDown, Dtpick2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

  

    Private Sub Cmbxempname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxempname.GotFocus
        Try
            Fetch_empinfo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxbnkname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxbnkname.Leave
        Try
            BtnEsibnk.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fetch_empinfo()
        EPF_BnkChlan_Adptr = New SqlDataAdapter("Select empid,empname from finactempmstr order by empname", FinActConn)
        Try
            EPF_BnkChlan_DtaTble = New DataTable
            EPF_BnkChlan_DtaTble.Clear()
            EPF_BnkChlan_Adptr.Fill(EPF_BnkChlan_DtaTble)
            Cmbxempname.DataSource = EPF_BnkChlan_DtaTble
            Cmbxempname.DisplayMember = "empname"
            Cmbxempname.ValueMember = "Empid"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EPF_BnkChlan_Adptr.Dispose()
        End Try
    End Sub

    Private Sub TxtNratn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNratn.Leave
        If Dtpick2.Enabled = True Then
            Dtpick2.Focus()
        Else
            Dtpick1.Focus()
        End If
    End Sub
    Private Sub Cmbxempname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxempname.Leave
        If cmbxbnkname.Enabled = True Then
            cmbxbnkname.Focus()
        Else
            BtnEsibnk.Enabled = True
            BtnEsibnk.Focus()
        End If
    End Sub

    Private Sub FrmCrRptEPFBnkChlan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 1025
            Me.Height = 144
            TellRptstatus = True
            CoprofileParamsEsiBnkChlan()
            Cmbxtypw.Focus()
        Catch ex As Exception

        End Try
    End Sub
End Class

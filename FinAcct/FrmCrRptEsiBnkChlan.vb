Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptEsiBnkChlan
    Dim EsiF6_Cmd As SqlCommand
    Dim EsiF6_Cmd1 As SqlCommand
    Dim EsiF6_Adptr As SqlDataAdapter
    Dim EsiF6_Rdr As SqlDataReader
    Dim EsiF6_Cmd2 As SqlCommand
    Dim EsiF6_Rdr2 As SqlDataReader
    Dim EsiF6_Rdr1 As SqlDataReader
    Dim TellRptstatus As Boolean
    Dim CrRptEsiBnk As New CrRptFrmESIC
    Dim OdbcCmd1 As OdbcCommand
    Dim Odbcrdr1 As OdbcDataReader
    Dim EsiF6_DtaTble As DataTable
    Dim IndxEsi As Integer
    Dim EsiAmt As String

    Private Sub FrmCrRptEsiBnkChlan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 1025
            Me.Height = 143
            temp_tblEsibnkchlan_Del()
            TellRptstatus = True
            CoprofileParamsEsiBnkChlan()
            Cmbxtypw.Focus()
        Catch ex As Exception

        End Try

    End Sub

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
                CrVewEsiBnk.Enabled = True
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
                Rptstr = Odbcrdr1(3)
                ParmVal5.AddValue(Rptstr)
                If Trim(EsiAmt) = "" Then
                    ParmVal6.AddValue("Nil")
                Else
                    ParmVal6.AddValue(EsiAmt)
                End If
                CrRptEsiBnk.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptEsiBnk.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptEsiBnk.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptEsiBnk.DataDefinition.ParameterFields("Parmesicode").ApplyCurrentValues(ParmVal5)
                CrRptEsiBnk.DataDefinition.ParameterFields("ParmAmtWord").ApplyCurrentValues(ParmVal6)
            End While
            CrVewEsiBnk.ReportSource = CrRptEsiBnk
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub

    Private Sub Cmbxtypw_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxtypw.GotFocus
        Try
            Me.Cmbxtypw.DroppedDown = True
            If Cmbxtypw.SelectedIndex = -1 Then
                Cmbxtypw.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxtypw_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxtypw.Leave
        Try
            Me.Cmbxtypw.DroppedDown = False
            If Cmbxtypw.SelectedIndex = 1 Then
                Dtpick2.Enabled = False
                cmbxbnkname.Enabled = False
                TxtNratn.Text = "Cash "
            Else
                Dtpick2.Enabled = True
                cmbxbnkname.Enabled = True
                TxtNratn.Text = "Ch No."
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreatTemp_EsiBnkchlan_tbl()
        
        Try
            EsiF6_Cmd = New SqlCommand("Temp_EmpEsibnkclan_Select", FinActConn)
            EsiF6_Cmd.CommandType = CommandType.StoredProcedure
            EsiF6_Cmd.Parameters.AddWithValue("@mnth", MonthName(Dtpick1.Value.Month))
            EsiF6_Rdr = EsiF6_Cmd.ExecuteReader
            While EsiF6_Rdr.Read
                If EsiF6_Rdr.HasRows = True Then
                    EsiF6_Cmd1 = New SqlCommand("Temp_EmpEsibnkchlan_Insert", FinActConn1)
                    EsiF6_Cmd1.CommandType = CommandType.StoredProcedure
                    EsiF6_Cmd1.Parameters.AddWithValue("@ebid", EsiF6_Rdr("aslryempid"))
                    EsiF6_Cmd1.Parameters.AddWithValue("@ebmy", Trim(Dtpick1.Text))
                    EsiF6_Cmd1.Parameters.AddWithValue("@ebnoe", EsiF6_Rdr("aslryempid"))
                    EsiF6_Cmd1.Parameters.AddWithValue("@ebwage", EsiF6_Rdr("aslrytotlern"))
                    EsiF6_Cmd1.Parameters.AddWithValue("@ebempamt", EsiF6_Rdr("aslryesi"))
                    EsiF6_Cmd1.Parameters.AddWithValue("@ebemplramt", EsiF6_Rdr("ephedcontriamt"))
                    EsiF6_Cmd1.Parameters.AddWithValue("@ebnratn", Trim(TxtNratn.Text))
                    If Dtpick2.Enabled = True Then
                        EsiF6_Cmd1.Parameters.AddWithValue("@ebdt", Trim(Dtpick2.Text))
                        EsiF6_Cmd1.Parameters.AddWithValue("@ebbname", Trim(cmbxbnkname.Text))
                    Else
                        EsiF6_Cmd1.Parameters.AddWithValue("@ebdt", 0)
                        EsiF6_Cmd1.Parameters.AddWithValue("@ebbname", "")
                    End If
                    EsiF6_Cmd1.Parameters.AddWithValue("@ebdepdt", 0)
                    EsiF6_Cmd1.Parameters.AddWithValue("@ebdepby", Cmbxempname.Text.Trim)
                    EsiF6_Cmd1.ExecuteNonQuery()
                End If
            End While

        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            If EsiF6_Rdr.HasRows = True Then
                EsiF6_Cmd1.Dispose()
            End If

            EsiF6_Cmd.Dispose()
            EsiF6_Rdr.Close()

           
            Try
                EsiAmt = ""
                EsiF6_Cmd = New SqlCommand("select sum(esibnkempamt+esibnkemplramt) from temp_esibnkchlan", FinActConn)
                EsiF6_Rdr = EsiF6_Cmd.ExecuteReader
                EsiF6_Rdr.Read()
                If EsiF6_Rdr.IsDBNull(0) = False Then
                    EsiAmt = RupeesToWord(EsiF6_Rdr(0))
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Esi sum Error Handler")
            Finally
                EsiF6_Cmd.Dispose()
                EsiF6_Rdr.Close()
            End Try
        End Try

    End Sub

    Private Sub temp_tblEsibnkchlan_Del()
        Try
            EsiF6_Cmd = New SqlCommand("delete from Temp_Esibnkchlan", FinActConn)
            EsiF6_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiF6_Cmd.Dispose()
        End Try
    End Sub

    Private Sub Fetch_InfoCrRptEsibnkchlan()
        Try
            EsiF6_Cmd = New SqlCommand("Select * from temp_esibnkchlan", FinActConn)
            Dim dsEsino As New DataSet(EsiF6_Cmd.CommandText)
            EsiF6_Adptr = New SqlDataAdapter(EsiF6_Cmd)
            EsiF6_Adptr.Fill(dsEsino)
            CrRptEsiBnk.SetDataSource(dsEsino.Tables(0))
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiF6_Cmd = Nothing

            EsiF6_Adptr.Dispose()

        End Try
    End Sub

    Private Sub chkvalesi()
        If Cmbxtypw.Text.Trim = "" Or TxtNratn.Text.Trim = "" Then
            IndxEsi += 1
            Cmbxtypw.Focus()
        End If
        If Cmbxtypw.Text.Trim = "By Cheque" Then
          
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

    Private Sub Cmbxempname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxempname.GotFocus
        Try
            Fetch_empinfo()
            Me.Cmbxempname.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxbnkname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxbnkname.GotFocus
        Try
            Me.cmbxbnkname.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub


    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxbnkname.KeyDown, Cmbxempname.KeyDown _
    , Cmbxtypw.KeyDown, Dtpick1.KeyDown, Dtpick2.KeyDown, TxtNratn.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbxbnkname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxbnkname.Leave
        Try
            BtnEsibnk.Enabled = True
            Me.cmbxbnkname.DroppedDown = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fetch_empinfo()
        EsiF6_Adptr = New SqlDataAdapter("Select empid,empname from finactempmstr order by empname", FinActConn)
        Try
            EsiF6_DtaTble= New DataTable
            EsiF6_DtaTble.Clear()
            EsiF6_Adptr.Fill(EsiF6_DtaTble)
            Cmbxempname.DataSource = EsiF6_DtaTble
            Cmbxempname.DisplayMember = "empname"
            Cmbxempname.ValueMember = "Empid"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiF6_Adptr.Dispose()
        End Try
    End Sub

    Private Sub TxtNratn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNratn.Leave
        Try
            Me.Cmbxempname.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Cmbxempname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxempname.Leave
        Try
            Me.Cmbxempname.DroppedDown = False
            If cmbxbnkname.Enabled = True Then
                cmbxbnkname.Focus()
            Else
                BtnEsibnk.Enabled = True
                BtnEsibnk.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbxtypw_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxtypw.SelectedIndexChanged

    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptRoContri
    Dim EsiROC_Cmd As SqlCommand
    Dim EsiROC_Adptr As SqlDataAdapter
    Dim EsiROC_Rdr As SqlDataReader
    Dim EsiROC_Cmd1 As SqlCommand
    Dim TellRptstatus As Boolean
    Dim CrRptEsiROC As New CrRptInsurance
    Dim OdbcCmd1 As OdbcCommand
    Dim Odbcrdr1 As OdbcDataReader
    Dim EsiFdt, EsiTdt As Date
    Dim pdt() As Object
    Dim pamt() As Object

    Private Sub BtnEsibnk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEsibnk.Click
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height - 50
        CrVewRoContri.Enabled = True
        temp_tblEsiROC_Del()
        TellRptstatus = False
        CoprofileParamsEsiROC()
        Btnsave.Visible = True
        Label2.Visible = True
        Label4.Visible = True
        Label4.Width = 415
    End Sub

    Private Sub FrmCrRptRoContri_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Width = 1025
            Me.Height = 251
            TellRptstatus = True
            CoprofileParamsEsiROC()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CoprofileParamsEsiROC()

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

        Dim ParmVal16 As ParameterValues = New ParameterValues()
        Dim DisVal16 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal16.Value = 1
        ParmVal16.Add(DisVal16)

        Dim ParmVal17 As ParameterValues = New ParameterValues()
        Dim DisVal17 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal17.Value = 1
        ParmVal17.Add(DisVal17)
        Dim ParmVal18 As ParameterValues = New ParameterValues()
        Dim DisVal18 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal18.Value = 1
        ParmVal18.Add(DisVal18)

        Dim ParmVal19 As ParameterValues = New ParameterValues()
        Dim DisVal19 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal19.Value = 1
        ParmVal19.Add(DisVal19)

        Dim ParmVal20 As ParameterValues = New ParameterValues()
        Dim DisVal20 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal20.Value = 1
        ParmVal20.Add(DisVal20)

        Dim ParmVal21 As ParameterValues = New ParameterValues()
        Dim DisVal21 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal21.Value = 1
        ParmVal21.Add(DisVal21)

        Dim ParmVal22 As ParameterValues = New ParameterValues()
        Dim DisVal22 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal22.Value = 1
        ParmVal22.Add(DisVal22)

        Dim ParmVal23 As ParameterValues = New ParameterValues()
        Dim DisVal23 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal23.Value = 1
        ParmVal23.Add(DisVal23)

        Dim ParmVal24 As ParameterValues = New ParameterValues()
        Dim DisVal24 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal24.Value = 1
        ParmVal24.Add(DisVal24)

        Dim ParmVal25 As ParameterValues = New ParameterValues()
        Dim DisVal25 As ParameterDiscreteValue = New ParameterDiscreteValue
        DisVal25.Value = 1
        ParmVal25.Add(DisVal25)
        '=====

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
                Rptstr = Odbcrdr1(3)
                ParmVal5.AddValue(Rptstr)
                ParmVal6.AddValue(Onr1)
                ParmVal7.AddValue(Onr2)
                ParmVal20.AddValue(Odbcrdr1(5))
                If TellRptstatus = False Then
                    Dim i As Integer
                    Dim ib As Integer
                    Dim ia As Integer = 1
                    Dim empesi As Double = 0
                    Dim emplresi As Double = 0
                    Dim esitotl As Double = 0
                    ReDim pdt(6)
                    ReDim pamt(6)
                    For ib = 0 To 5
                        pdt(ib) = "-NiL-"
                        pamt(ib) = "-NiL-"
                    Next
                    For i = 0 To Me.DgvewEsiRoc.Rows.Count - 1
                        If Trim(Me.DgvewEsiRoc.Rows(i).Cells(5).Value) <> "" Then
                            pdt(i) = Trim(Me.DgvewEsiRoc.Rows(i).Cells(5).Value)
                        Else
                            pdt(i) = "-NiL-"
                        End If
                        If Trim(Me.DgvewEsiRoc.Rows(i).Cells(4).Value) <> "" Then
                            pamt(i) = FormatNumber(Trim(Me.DgvewEsiRoc.Rows(i).Cells(4).Value), 2)
                            esitotl += CDbl(FormatNumber(Trim(Me.DgvewEsiRoc.Rows(i).Cells(4).Value), 2))
                            empesi += CDbl(FormatNumber(Trim(Me.DgvewEsiRoc.Rows(i).Cells(1).Value), 2))
                            emplresi += CDbl(FormatNumber(Trim(Me.DgvewEsiRoc.Rows(i).Cells(2).Value), 2))
                        Else
                            pamt(i) = "-NiL-"
                        End If
                    Next

                    ParmVal8.AddValue(pdt(0))
                    ParmVal9.AddValue(pdt(1))
                    ParmVal10.AddValue(pdt(2))
                    ParmVal11.AddValue(pdt(3))
                    ParmVal12.AddValue(pdt(4))
                    ParmVal13.AddValue(pdt(5))

                    ParmVal14.AddValue(pamt(0))
                    ParmVal15.AddValue(pamt(1))
                    ParmVal16.AddValue(pamt(2))
                    ParmVal17.AddValue(pamt(3))
                    ParmVal18.AddValue(pamt(4))
                    ParmVal19.AddValue(pamt(5))

                    ParmVal23.AddValue(esitotl)
                    ParmVal24.AddValue(emplresi)
                    ParmVal25.AddValue(empesi)


                    Dim mnthNo As Integer = dtpick2.Value.Month
                    Dim mntday As Integer
                    Dim chkleap As Date = dtpick2.Value.Date
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
                    Dim Fromdt As Date = DateSerial(Year(Dtpick1.Value.Date), Month(Dtpick1.Value.Date), 1) ')'.AddDays(-1)
                    Dim todt As Date = DateSerial(Year(dtpick2.Value.Date), Month(dtpick2.Value.Date), mntday)
                    ' EsiFdt = Fromdt
                    '  EsiTdt = todt
                    ParmVal21.AddValue(Format(Fromdt, "dd/MM/yyyy"))
                    ParmVal22.AddValue(Format(todt, "dd/MM/yyyy"))
                End If

                CrRptEsiROC.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptEsiROC.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptEsiROC.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptEsiROC.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
                CrRptEsiROC.DataDefinition.ParameterFields("Parmesicode").ApplyCurrentValues(ParmVal5)
                CrRptEsiROC.DataDefinition.ParameterFields("parmonradrs").ApplyCurrentValues(ParmVal6)
                CrRptEsiROC.DataDefinition.ParameterFields("parmonrdesi").ApplyCurrentValues(ParmVal7)
                CrRptEsiROC.DataDefinition.ParameterFields("parmdt1").ApplyCurrentValues(ParmVal8)
                CrRptEsiROC.DataDefinition.ParameterFields("parmdt2").ApplyCurrentValues(ParmVal9)
                CrRptEsiROC.DataDefinition.ParameterFields("parmdt3").ApplyCurrentValues(ParmVal10)
                CrRptEsiROC.DataDefinition.ParameterFields("parmdt4").ApplyCurrentValues(ParmVal11)
                CrRptEsiROC.DataDefinition.ParameterFields("parmdt5").ApplyCurrentValues(ParmVal12)
                CrRptEsiROC.DataDefinition.ParameterFields("parmdt6").ApplyCurrentValues(ParmVal13)
                CrRptEsiROC.DataDefinition.ParameterFields("parmamt1").ApplyCurrentValues(ParmVal14)
                CrRptEsiROC.DataDefinition.ParameterFields("parmamt2").ApplyCurrentValues(ParmVal15)
                CrRptEsiROC.DataDefinition.ParameterFields("parmamt3").ApplyCurrentValues(ParmVal16)
                CrRptEsiROC.DataDefinition.ParameterFields("parmamt4").ApplyCurrentValues(ParmVal17)
                CrRptEsiROC.DataDefinition.ParameterFields("parmamt5").ApplyCurrentValues(ParmVal18)
                CrRptEsiROC.DataDefinition.ParameterFields("parmamt6").ApplyCurrentValues(ParmVal19)
                CrRptEsiROC.DataDefinition.ParameterFields("parmplace").ApplyCurrentValues(ParmVal20)
                CrRptEsiROC.DataDefinition.ParameterFields("fmnth").ApplyCurrentValues(ParmVal21)
                CrRptEsiROC.DataDefinition.ParameterFields("tmnth").ApplyCurrentValues(ParmVal22)
                CrRptEsiROC.DataDefinition.ParameterFields("parmtotlesi").ApplyCurrentValues(ParmVal23)
                CrRptEsiROC.DataDefinition.ParameterFields("parmemplresi").ApplyCurrentValues(ParmVal24)
                CrRptEsiROC.DataDefinition.ParameterFields("parmempesi").ApplyCurrentValues(ParmVal25)
            End While
            CrVewRoContri.ReportSource = CrRptEsiROC
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub
    
    Private Sub CreatTemp_EsiROC_tbl()
        Dim esirecno As Integer = 1
        Dim esiempstatus As String = ""
        Try
            EsiROC_Cmd = New SqlCommand("Temp_Esi_ROC_Select", FinActConn)
            EsiROC_Cmd.CommandType = CommandType.StoredProcedure
            EsiROC_Cmd.Parameters.AddWithValue("@f_mnth", EsiFdt.Date)
            EsiROC_Cmd.Parameters.AddWithValue("@t_mnth", EsiTdt.Date)
            EsiROC_Rdr = EsiROC_Cmd.ExecuteReader
            While EsiROC_Rdr.Read
                If EsiROC_Rdr.HasRows = True Then
                    EsiROC_Cmd1 = New SqlCommand("Temp_Esi_ROC_Insert", FinActConn1)
                    EsiROC_Cmd1.CommandType = CommandType.StoredProcedure
                    EsiROC_Cmd1.Parameters.AddWithValue("@mname", EsiROC_Rdr("month_name"))
                    EsiROC_Cmd1.Parameters.AddWithValue("@mno", 1)
                    EsiROC_Cmd1.Parameters.AddWithValue("@empesi", EsiROC_Rdr("esi"))
                    EsiROC_Cmd1.Parameters.AddWithValue("@emplresi", EsiROC_Rdr("emplresi"))
                    EsiROC_Cmd1.Parameters.AddWithValue("@totlern", EsiROC_Rdr("totalearn"))
                    EsiROC_Cmd1.Parameters.AddWithValue("@totlesi", EsiROC_Rdr("totlesi"))
                    EsiROC_Cmd1.ExecuteNonQuery()
                End If
            End While
            If EsiROC_Rdr.HasRows = True Then
                EsiROC_Cmd1.Dispose()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiROC_Cmd.Dispose()
            EsiROC_Rdr.Close()

        End Try

    End Sub

    Private Sub temp_tblEsiROC_Del()
        Try
            EsiROC_Cmd = New SqlCommand("delete from Temp_Esi_Roc ", FinActConn)
            EsiROC_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiROC_Cmd.Dispose()
        End Try
    End Sub

    Private Sub BtnEsiGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEsiGo.Click

        Try
            Dim mnthNo1 As Integer = dtpick2.Value.Month
            Dim mntday1 As Integer
            Dim chkleap1 As Date = dtpick2.Value.Date
            If mnthNo1 = 2 Then
                If Date.IsLeapYear(chkleap1.Year) Then
                    mntday1 = 29
                Else
                    mntday1 = 28
                End If

            ElseIf mnthNo1 = 4 Or mnthNo1 = 6 Or mnthNo1 = 9 Or mnthNo1 = 11 Then
                mntday1 = 30
            Else
                mntday1 = 31
            End If
            EsiFdt = DateSerial(Year(Dtpick1.Value.Date), Month(Dtpick1.Value.Date), 1) ')'.AddDays(-1)
            EsiTdt = DateSerial(Year(dtpick2.Value.Date), Month(dtpick2.Value.Date), mntday1)
            temp_tblEsiROC_Del()
            CreatTemp_EsiROC_tbl()
            DgvewEsiRoc.Refresh()
            'TODO: This line of code loads data into the 'HrPrData08DataSet.Temp_Esi_RoC' table. You can move, or remove it, as needed.
            'Me.Temp_Esi_RoCTableAdapter.Fill(Me.HrPrData08DataSet.Temp_Esi_RoC)
            If Me.DgvewEsiRoc.Rows(0).Cells(4).Value > 0 Then
                BtnEsibnk.Enabled = True
            Else
                BtnEsibnk.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    
    Private Sub Dtpick1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtpick1.ValueChanged
        dtpick2.Value = Dtpick1.Value.AddMonths(5)
    End Sub
End Class
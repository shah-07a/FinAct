Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptActSec7PF
    Dim CrRptPFcvrltr As New CrRptActSec07
    Dim OdbcCmd1 As OdbcCommand
    Dim OdbcDa1 As OdbcDataAdapter
    Dim Odbcrdr1 As OdbcDataReader

    Private Sub BtnEsiGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEsiGo.Click
        If Trim(TxtSectn.Text) = "" Then
            TxtSectn.BackColor = Color.Orange
            TxtSectn.Focus()
        Else
            TxtSectn.BackColor = Color.White
            Me.Height = 700
            CoprofileParamsPFcoverltr()
            CrVewPFActSec.Enabled = True
        End If
        
    End Sub

    Private Sub FrmCrRptActSec7PF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Width = 1025
        Me.Height = 85
        CoprofileParamsPFcoverltr()
        Me.Dtpick1.Focus()

    End Sub
    Private Sub CoprofileParamsPFcoverltr()

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
                ParmVal4.AddValue(Format(Dtpick1.Value.Date, "dd/MM/yyyy"))
                Dim Rptstr As String = ""
                Rptstr = Odbcrdr1(4)
                ParmVal5.AddValue(Rptstr)
                ParmVal6.AddValue(dtpick2.Text)
                ParmVal7.AddValue(TxtSectn.Text)

                CrRptPFcvrltr.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                CrRptPFcvrltr.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                CrRptPFcvrltr.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                CrRptPFcvrltr.DataDefinition.ParameterFields("parmdate").ApplyCurrentValues(ParmVal4)
                CrRptPFcvrltr.DataDefinition.ParameterFields("Parmpfcode").ApplyCurrentValues(ParmVal5)
                CrRptPFcvrltr.DataDefinition.ParameterFields("parmmnth").ApplyCurrentValues(ParmVal6)
                CrRptPFcvrltr.DataDefinition.ParameterFields("parmsection").ApplyCurrentValues(ParmVal7)

            End While
            CrVewPFActSec.ReportSource = CrRptPFcvrltr
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            Odbcrdr1.Close()
            OdbcCmd1.Dispose()
        End Try

    End Sub
   
    Private Sub Allcontrol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSectn.KeyDown, Dtpick1.KeyDown _
    , dtpick2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If

        Catch ex As Exception

        End Try

    End Sub
End Class
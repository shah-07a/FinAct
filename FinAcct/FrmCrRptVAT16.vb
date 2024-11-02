Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmCrRptVAT16
    Dim CrRptV16 As New CrRptVAT16excelpage
    Private Sub FrmCrRptVAT16_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CoInfo()
            SetExtraPramtoCrRpt()
            Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 100, Screen.PrimaryScreen.WorkingArea.Height - 50)
            Me.Left = 25
            Me.Top = 0

        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetExtraPramtoCrRpt()
        Try
            Dim ParmVal1 As ParameterValues() '= New ParameterValues()
            Dim DisVal1 As ParameterDiscreteValue() '= New ParameterDiscreteValue
            ReDim ParmVal1(34)
            ReDim DisVal1(34)
            For xPr As Integer = 0 To 34
                ParmVal1(xPr) = New ParameterValues
                DisVal1(xPr) = New ParameterDiscreteValue
                DisVal1(xPr).Value = xPr
                ParmVal1(xPr).Add(DisVal1(xPr))
            Next
            ParmVal1(0).AddValue(VAT16MNAME.Trim)
            ParmVal1(1).AddValue(CoName.Trim)
            ParmVal1(2).AddValue(Adrs1.Trim)
            ParmVal1(3).AddValue(Adrs2.Trim)
            ParmVal1(4).AddValue(Cty.Trim)

            ParmVal1(5).AddValue(Pin)
            ParmVal1(6).AddValue(PhNo)
            ParmVal1(7).AddValue(State.Trim)
            ParmVal1(8).AddValue(FaxNo)
            ParmVal1(9).AddValue(VATNO)
            ParmVal1(10).AddValue(xVAT_DtF.Date)
            ParmVal1(11).AddValue(xVAT_DtT.Date)
            ParmVal1(12).AddValue(CDbl(xVAT_Purchase_b + xVAT_Purchase_g))
            ParmVal1(13).AddValue(CDbl(xVAT_Purchase_c + xVAT_Purchase_ea + xVAT_PurchaseInterState_f))
            ParmVal1(14).AddValue(CDbl(xVAT_Purchase_h))
            ParmVal1(15).AddValue(CDbl(0))
            ParmVal1(16).AddValue(CDbl(xVAT_Purchase_d))
            ParmVal1(17).AddValue(CDbl(xVAT_Purchase_l))
            ParmVal1(18).AddValue(CDbl(xVAT_Purchase_f + xVAT_Purchase_e))
            ParmVal1(19).AddValue(CDbl(xVAT_PurchaseTax_Col2l))
            ParmVal1(20).AddValue(CDbl(0))
            ParmVal1(21).AddValue(CDbl(VAT16PRVS))
            ParmVal1(22).AddValue(CDbl(VAT16EXPORTSALE))
            ParmVal1(23).AddValue(CDbl(VAT16INTERSTATESALE))
            ParmVal1(24).AddValue(CDbl(VAT16WITHINSTATESALE))
            ParmVal1(25).AddValue(CDbl(0))
            ParmVal1(26).AddValue(CDbl(VAT16VAT))
            ParmVal1(27).AddValue(CDbl(VAT16CST))
            ParmVal1(28).AddValue(CDbl(VAT16AMOUNT))
            ParmVal1(29).AddValue(VAT16CHNO.Trim)
            ParmVal1(30).AddValue(VAT16DT)
            ParmVal1(31).AddValue(VAT16DRAW.Trim)
            ParmVal1(32).AddValue(CoOnrDesi.Trim)

            Me.CrRptV16.DataDefinition.ParameterFields("PRMMONTH").ApplyCurrentValues(ParmVal1(0))
            Me.CrRptV16.DataDefinition.ParameterFields("CONAME").ApplyCurrentValues(ParmVal1(1))
            Me.CrRptV16.DataDefinition.ParameterFields("ADRS1").ApplyCurrentValues(ParmVal1(2))
            Me.CrRptV16.DataDefinition.ParameterFields("ADRS2").ApplyCurrentValues(ParmVal1(3))
            Me.CrRptV16.DataDefinition.ParameterFields("ADRS3").ApplyCurrentValues(ParmVal1(4))
            Me.CrRptV16.DataDefinition.ParameterFields("PIN").ApplyCurrentValues(ParmVal1(5))
            Me.CrRptV16.DataDefinition.ParameterFields("TELE").ApplyCurrentValues(ParmVal1(6))
            Me.CrRptV16.DataDefinition.ParameterFields("STATE").ApplyCurrentValues(ParmVal1(7))
            Me.CrRptV16.DataDefinition.ParameterFields("FAX").ApplyCurrentValues(ParmVal1(8))
            Me.CrRptV16.DataDefinition.ParameterFields("VATNO").ApplyCurrentValues(ParmVal1(9))
            Me.CrRptV16.DataDefinition.ParameterFields("FDT").ApplyCurrentValues(ParmVal1(10))
            Me.CrRptV16.DataDefinition.ParameterFields("TDT").ApplyCurrentValues(ParmVal1(11))
            Me.CrRptV16.DataDefinition.ParameterFields("IMPVAL").ApplyCurrentValues(ParmVal1(12))
            Me.CrRptV16.DataDefinition.ParameterFields("PURINTSTATE").ApplyCurrentValues(ParmVal1(13))
            Me.CrRptV16.DataDefinition.ParameterFields("PUS19").ApplyCurrentValues(ParmVal1(14))
            Me.CrRptV16.DataDefinition.ParameterFields("PUS20").ApplyCurrentValues(ParmVal1(15))
            Me.CrRptV16.DataDefinition.ParameterFields("PEXEMP").ApplyCurrentValues(ParmVal1(16))
            Me.CrRptV16.DataDefinition.ParameterFields("PTXABLE").ApplyCurrentValues(ParmVal1(17))
            Me.CrRptV16.DataDefinition.ParameterFields("PNONTXABLE").ApplyCurrentValues(ParmVal1(18))
            Me.CrRptV16.DataDefinition.ParameterFields("PACTLITC").ApplyCurrentValues(ParmVal1(19))
            Me.CrRptV16.DataDefinition.ParameterFields("PNOTNLITC").ApplyCurrentValues(ParmVal1(20))
            Me.CrRptV16.DataDefinition.ParameterFields("BFITC").ApplyCurrentValues(ParmVal1(21))

            Me.CrRptV16.DataDefinition.ParameterFields("SEXPORT").ApplyCurrentValues(ParmVal1(22))
            Me.CrRptV16.DataDefinition.ParameterFields("SINTERSTATE").ApplyCurrentValues(ParmVal1(23))
            Me.CrRptV16.DataDefinition.ParameterFields("STXABLE").ApplyCurrentValues(ParmVal1(24))
            Me.CrRptV16.DataDefinition.ParameterFields("SNONTXABLE").ApplyCurrentValues(ParmVal1(25))
            Me.CrRptV16.DataDefinition.ParameterFields("OUTPUTVAT").ApplyCurrentValues(ParmVal1(26))
            Me.CrRptV16.DataDefinition.ParameterFields("OUTPUTCST").ApplyCurrentValues(ParmVal1(27))
            Me.CrRptV16.DataDefinition.ParameterFields("AMONT").ApplyCurrentValues(ParmVal1(28))
            Me.CrRptV16.DataDefinition.ParameterFields("CHQNO").ApplyCurrentValues(ParmVal1(29))
            Me.CrRptV16.DataDefinition.ParameterFields("CHQDATE").ApplyCurrentValues(ParmVal1(30))
            Me.CrRptV16.DataDefinition.ParameterFields("CHQDRAWN").ApplyCurrentValues(ParmVal1(31))
            Me.CrRptV16.DataDefinition.ParameterFields("DESIG").ApplyCurrentValues(ParmVal1(32))
            CrRptVewVAT16.ReportSource = CrRptV16
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'cmd.Dispose()
            'rdr.Close()
        End Try
    End Sub
End Class
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Public Class FrmCrRptReconcilePrint
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim CrRptBr As New CrRptBnkReconcile
    Private Sub FrmCrRptReconcilePrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_BB()
            ''FrmMainMdi.MenuItem75.Enabled = False
            Handle_P_Bar(Me)
            Me.Top = 0
            Me.Left = 0
            Me.Height = 663
            Me.Width = 900
          
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_BB()
        Try

            Fetch_Stock_Record("Finact_Rpt_TEMP_BBookReconcile_Summary_Select", Me.CrRptBr, Me.CrRptVewBnkRecon)
            Dim xdtp As New DateTimePicker
            Dim xdtp1 As New DateTimePicker
            'If Me.ChkRptbb.Checked = True Then
            BnkReconPrintSummary()
            CoprofileParamsRest_Adrs(Me.CrRptBr, Me.CrRptVewBnkRecon, True, True, xdtp, xdtp1)
            'Else
            'CoprofileParamsRest_Adrs(Me.CrRptbb, Me.CrRptVewBB, True, False, Me.Dtpbb1, Me.Dtpbb2)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_BB, Line No. 236 ")
        End Try
    End Sub
    Private Sub BnkReconPrintSummary()
        Try
            Dim ParmVal1 As ParameterValues = New ParameterValues()
            Dim DisVal1 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal1.Value = 1
            ParmVal1.Add(DisVal1)

            Dim ParmVal2 As ParameterValues = New ParameterValues()
            Dim DisVal2 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal2.Value = 2
            ParmVal2.Add(DisVal2)

            Dim ParmVal3 As ParameterValues = New ParameterValues()
            Dim DisVal3 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal3.Value = 3
            ParmVal3.Add(DisVal3)

            Dim ParmVal4 As ParameterValues = New ParameterValues()
            Dim DisVal4 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal4.Value = 4
            ParmVal4.Add(DisVal4)

            Dim ParmVal5 As ParameterValues = New ParameterValues()
            Dim DisVal5 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal5.Value = 5
            ParmVal5.Add(DisVal5)

            Dim ParmVal6 As ParameterValues = New ParameterValues()
            Dim DisVal6 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal6.Value = 6
            ParmVal6.Add(DisVal6)

            Dim ParmVal7 As ParameterValues = New ParameterValues()
            Dim DisVal7 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal7.Value = 7
            ParmVal7.Add(DisVal7)

            Dim ParmVal8 As ParameterValues = New ParameterValues()
            Dim DisVal8 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal8.Value = 8
            ParmVal8.Add(DisVal8)

            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()

            cmd = New SqlCommand("Finact_Rpt_Temp_BnkReconSummary_Select", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.AddWithValue("@xint", xx)
            rdr = cmd.ExecuteReader
            While rdr.Read
                If rdr(2) = 1 Then
                    ParmVal1.AddValue(rdr(1))
                ElseIf rdr(2) = 2 Then
                    ParmVal2.AddValue(rdr(0))
                    ParmVal3.AddValue(rdr(1))
                ElseIf rdr(2) = 3 Then
                    ParmVal4.AddValue(rdr(0))
                    ParmVal5.AddValue(rdr(1))
                ElseIf rdr(2) = 4 Then
                    ParmVal6.AddValue(rdr(1))
                ElseIf rdr(2) = 5 Then
                    ParmVal7.AddValue(rdr(1))
                ElseIf rdr(2) = 6 Then
                    ParmVal8.AddValue(rdr(1))
                End If
            End While
            Me.CrRptBr.DataDefinition.ParameterFields("Bbamt").ApplyCurrentValues(ParmVal1)
            Me.CrRptBr.DataDefinition.ParameterFields("Cisutxt").ApplyCurrentValues(ParmVal2)
            Me.CrRptBr.DataDefinition.ParameterFields("CisuAmt").ApplyCurrentValues(ParmVal3)
            Me.CrRptBr.DataDefinition.ParameterFields("Cdeptxt").ApplyCurrentValues(ParmVal4)

            Me.CrRptBr.DataDefinition.ParameterFields("CdepAmt").ApplyCurrentValues(ParmVal5)
            Me.CrRptBr.DataDefinition.ParameterFields("Balamt").ApplyCurrentValues(ParmVal6)
            Me.CrRptBr.DataDefinition.ParameterFields("BalBnk").ApplyCurrentValues(ParmVal7)
            Me.CrRptBr.DataDefinition.ParameterFields("Diff").ApplyCurrentValues(ParmVal8)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            rdr.Close()
        End Try
    End Sub


End Class
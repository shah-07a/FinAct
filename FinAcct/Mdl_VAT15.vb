Imports System.Collections
Imports System.Linq
Module Mdl_VAT15
    Public xVATExlFilePath As String = String.Empty
    Public xPrdName As String = String.Empty
    ''==Flags used in all VAT15 related modules
    ''--=============================
    Public xVAT_FlagPrd As Boolean = False
    Public xVAT_FlagWc As Boolean = False
    Public xVAT_FlagPPA As Boolean = False
    Public xVAT_Flag1_2 As Boolean = False
    Public xVAT_Flag1_2a As Boolean = False
    Public xVAT_Flag3 As Boolean = False
    Public xVAT_Flag4 As Boolean = False
    Public xVAT_Flag5 As Boolean = False
    Public xVAT_Flag6 As Boolean = False
    Public xVAT_Flag7 As Boolean = False
    Public xVAT_Flag8 As Boolean = False
    Public xVAT_Flag9 As Boolean = False

    ''==Variables used in all VAT15 Modules
    ''==================================
    Public xVAT_DtF As Date = Nothing
    Public xVAT_DtT As Date = Nothing
    Public xVAT_DgSaleRowIndx As Integer = 0
    Public xVAT_DgPurchaseRowIndx As Integer = 0
    Public xVAT_Sale_a As Double = 0
    Public xVAT_Sale_b As Double = 0
    Public xVAT_Sale_c As Double = 0
    Public xVAT_Sale_cA As Double = 0
    Public xVAT_Sale_d As Double = 0
    Public xVAT_Sale_e As Double = 0
    Public xVAT_Sale_ea As Double = 0
    Public xVAT_Sale_f As Double = 0
    Public xVAT_Sale_g As Double = 0
    Public xVAT_Sale_h As Double = 0
    Public xVAT_Sale_i As Double = 0
    Public xVAT_Sale_j As Double = 0
    Public xVAT_SaleRtd_a As Double = 0
    Public xVAT_SaleRtd_b As Double = 0
    Public xVAT_SaleRtd_c As Double = 0
    Public xVAT_SaleRtd_cA As Double = 0
    Public xVAT_SaleRtd_d As Double = 0
    Public xVAT_SaleRtd_e As Double = 0
    Public xVAT_SaleRtd_ea As Double = 0
    Public xVAT_SaleRtd_f As Double = 0
    Public xVAT_SaleRtd_g As Double = 0
    Public xVAT_SaleRtd_h As Double = 0
    Public xVAT_SaleRtd_i As Double = 0
    Public xVAT_SaleRtd_j As Double = 0
    Public xVAT_S1 As Double = 0
    Public xVAT_S4 As Double = 0
    Public xVAT_S5 As Double = 0
    Public xVAT_S8_8 As Double = 0
    Public xVAT_S12_5 As Double = 0
    Public xVAT_S13_5 As Double = 0
    Public xVAT_S20 As Double = 0
    Public xVAT_S22 As Double = 0
    Public xVAT_S27_5 As Double = 0
    Public xVAT_S30 As Double = 0
    Public xVAT_Sothr As Double = 0
    Public xVAT_Sr1 As Double = 0
    Public xVAT_Sr4 As Double = 0
    Public xVAT_Sr5 As Double = 0
    Public xVAT_Sr8_8 As Double = 0
    Public xVAT_Sr12_5 As Double = 0
    Public xVAT_Sr13_5 As Double = 0
    Public xVAT_Sr20 As Double = 0
    Public xVAT_Sr22 As Double = 0
    Public xVAT_Sr27_5 As Double = 0
    Public xVAT_Sr30 As Double = 0
    Public xVAT_Srothr As Double = 0
    Public xVAT_S1C As Double = 0
    Public xVAT_S2C As Double = 0
    Public xVAT_S4C As Double = 0
    Public xVAT_S5C As Double = 0
    Public xVAT_S8_8C As Double = 0
    Public xVAT_S12_5C As Double = 0
    Public xVAT_S13_5C As Double = 0
    Public xVAT_S20C As Double = 0
    Public xVAT_S22C As Double = 0
    Public xVAT_S27_5C As Double = 0
    Public xVAT_S30C As Double = 0
    Public xVAT_SothrC As Double = 0
    Public xVAT_S1Cdg As Double = 0
    Public xVAT_S1CdgUn As Double = 0
    Public xVAT_S1CUn As Double = 0
    Public xVAT_S1Cbt As Double = 0
    Public xVAT_Sr1C As Double = 0
    Public xVAT_Sr2C As Double = 0
    Public xVAT_Sr4C As Double = 0
    Public xVAT_Sr5C As Double = 0
    Public xVAT_Sr8_8C As Double = 0
    Public xVAT_Sr12_5C As Double = 0
    Public xVAT_Sr13_5C As Double = 0
    Public xVAT_Sr20C As Double = 0
    Public xVAT_Sr22C As Double = 0
    Public xVAT_Sr27_5C As Double = 0
    Public xVAT_Sr30C As Double = 0
    Public xVAT_SrothrC As Double = 0
    Public xVAT_OutputTAX As Double = 0
    Public xCST_OutputTAX As Double = 0
    Public xVAT_OutputTAX_Col3d As Double = 0
    Public xVAT_InputTAX_Col4p As Double = 0
    Public xVAT_PurchaseTax_Col2h As Double = 0
    Public xVAT_PurchaseTax_Col2l As Double = 0
    Public xVAT_Purchase_a As Double = 0
    Public xVAT_Purchase_b As Double = 0
    Public xVAT_Purchase_c As Double = 0
    Public xVAT_Purchase_d As Double = 0
    Public xVAT_Purchase_e As Double = 0
    Public xVAT_Purchase_ea As Double = 0
    Public xVAT_Purchase_f As Double = 0
    Public xVAT_PurchaseInterState_f As Double = 0
    Public xVAT_Purchase_g As Double = 0
    Public xVAT_Purchase_h As Double = 0
    Public xVAT_Purchase_i As Double = 0
    Public xVAT_Purchase_j As Double = 0
    Public xVAT_Purchase_k As Double = 0
    Public xVAT_Purchase_l As Double = 0
    Public xVAT_PurchaseRtd_a As Double = 0
    Public xVAT_PurchaseRtd_b As Double = 0
    Public xVAT_PurchaseRtd_c As Double = 0
    Public xVAT_PurchaseRtd_d As Double = 0
    Public xVAT_PurchaseRtd_e As Double = 0
    Public xVAT_PurchaseRtd_ea As Double = 0
    Public xVAT_PurchaseRtd_f As Double = 0
    Public xVAT_PurchaseRtd_g As Double = 0
    Public xVAT_PurchaseRtd_h As Double = 0
    Public xVAT_PurchaseRtd_i As Double = 0
    Public xVAT_PurchaseRtd_j As Double = 0
    Public xVAT_PurchaseRtd_k As Double = 0
    Public xVAT_PurchaseRtd_l As Double = 0
    Public xVAT_P1 As Double = 0
    Public xVAT_P4 As Double = 0
    Public xVAT_P5 As Double = 0
    Public xVAT_P8_8 As Double = 0
    Public xVAT_P12_5 As Double = 0
    Public xVAT_P13_5 As Double = 0
    Public xVAT_P20 As Double = 0
    Public xVAT_P22 As Double = 0
    Public xVAT_P27_5 As Double = 0
    Public xVAT_P30 As Double = 0
    Public xVAT_Pothr As Double = 0
    Public xVAT_Pr1 As Double = 0
    Public xVAT_Pr4 As Double = 0
    Public xVAT_Pr5 As Double = 0
    Public xVAT_Pr8_8 As Double = 0
    Public xVAT_Pr12_5 As Double = 0
    Public xVAT_Pr13_5 As Double = 0
    Public xVAT_Pr20 As Double = 0
    Public xVAT_Pr22 As Double = 0
    Public xVAT_Pr27_5 As Double = 0
    Public xVAT_Pr30 As Double = 0
    Public xVAT_Prothr As Double = 0
    Public xPeriodId As Integer = 0
    Public xOTxPPANetOTx As Double = 0
    Public xITCtxt1_to_12(11) As Double
    Public xExmptUnt1_to_10(9) As Double
    Public xFrmPayExcs1_to_2(1) As Double
    Public xOTchk As Boolean = True
    Public xITchk As Boolean = True
    Public xUAE8 As String = ""
    Public xUAE8_2_to_7(5) As Double
    Public xUAE8dt(1) As Date
    Public xUAE8chk As Boolean = False
    Public xMiseInfo9_1_to_5(4) As Double
    Public xMiseInfo9chk As Boolean = False
    Public xOTtype As String = ""
    Public xITCtype As String = ""
    Public xOT_ITC_Adjstmnt(20) As Double
    Public xWcVal(10, 7) As Double
    Public xPPAsc1(1) As Double
    Public xPPAsc2(1) As Double
    Public xPPAsc3(1) As Double
    Public xPPAsc4(1) As Double
    Public xPPApc1(1) As Double
    Public xPPApc2(1) As Double
    Public xPPApc3(1) As Double
    Public xPPApc4(1) As Double
    '---------------
    Public xVAT_STx1 As Double = 0
    Public xVAT_STx4 As Double = 0
    Public xVAT_STx5 As Double = 0
    Public xVAT_STx8_8 As Double = 0
    Public xVAT_STx12_5 As Double = 0
    Public xVAT_STx13_5 As Double = 0
    Public xVAT_STx20 As Double = 0
    Public xVAT_STx22 As Double = 0
    Public xVAT_STx27_5 As Double = 0
    Public xVAT_STx30 As Double = 0
    Public xVAT_STxothr As Double = 0
    Public xVAT_CTx1C As Double = 0
    Public xVAT_CTx2C As Double = 0
    Public xVAT_CTx4C As Double = 0
    Public xVAT_CTx5C As Double = 0
    Public xVAT_CTx8_8C As Double = 0
    Public xVAT_CTx12_5C As Double = 0
    Public xVAT_CTx13_5C As Double = 0
    Public xVAT_CTx20C As Double = 0
    Public xVAT_CTx22C As Double = 0
    Public xVAT_CTx27_5C As Double = 0
    Public xVAT_CTx30C As Double = 0
    Public xVAT_CTxothrC As Double = 0

    Public xVAT_PTx1 As Double = 0
    Public xVAT_PTx4 As Double = 0
    Public xVAT_PTx5 As Double = 0
    Public xVAT_PTx8_8 As Double = 0
    Public xVAT_PTx12_5 As Double = 0
    Public xVAT_PTx13_5 As Double = 0
    Public xVAT_PTx20 As Double = 0
    Public xVAT_PTx22 As Double = 0
    Public xVAT_PTx27_5 As Double = 0
    Public xVAT_PTx30 As Double = 0
    Public xVAT_PTxothr As Double = 0
    ''--------------------------------
    ''------
    Public CoName As String = ""
    Public VATNO As String = ""
    Public Adrs1 As String = ""
    Public Adrs2 As String = ""
    Public Cty As String = ""
    Public State As String = ""
    Public Contry As String = ""
    Public PhNo As String = ""
    Public Pin As Integer = 0
    Public Email As String = ""
    Public FaxNo As String = ""
    Public CoOnrName As String = ""
    Public CoOnrDesi As String = ""
    Public CoStatus As String = ""
    Public VAT16MNAME As String = ""
    Public VAT16ITC As Double = 0
    Public VAT16AMOUNT As Double = 0
    Public VAT16PRVS As Double = 0
    Public VAT16VAT As Double = 0
    Public VAT16CST As Double = 0
    Public VAT16CHNO As String = ""
    Public VAT16DT As String = ""
    Public VAT16DRAW As String = ""
    Public VAT16STATUS As String = ""
    Public VAT16WITHINSTATESALE As Double = 0
    Public VAT16INTERSTATESALE As Double = 0
    Public VAT16EXPORTSALE As Double = 0
    '---------------------------------------

    ''==ArrayList used in all VAT15 Modules
    ''===========================================
#Region "VAT15 SALE UNDER WORKCONTRACT"

    Public WcAl As New ArrayList()

    Private Class VAT15Wc
        Public xDes As String
        Public xVal As Double()

    End Class
    Public Sub xDgValuesWc(ByVal xdgWc As DataGridView)
        Try
            '' In this Dg has 11 rows(0-10) and 8 columns (0-7)
            ''----------------------------------------------
            WcAl.Clear()
            For Each xr1 As DataGridViewRow In xdgWc.Rows
                Dim xx As New VAT15Wc With {.xDes = Trim(xr1.Cells(0).Value), _
                                                 .xVal = New Double() {CDbl(xr1.Cells(1).Value), CDbl(xr1.Cells(2).Value), CDbl(xr1.Cells(3).Value), CDbl(xr1.Cells(4).Value), CDbl(xr1.Cells(5).Value), CDbl(xr1.Cells(6).Value), CDbl(xr1.Cells(7).Value)}}
                WcAl.Add(xx)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Sub xFetchFromWcAl(ByVal xDgWcFill As DataGridView)
        Try

            Dim query As Object = From vAT15Wc As VAT15Wc In WcAl Select vAT15Wc
            Dim ix As Integer = 0
            For Each vAT15Wc As VAT15Wc In query
                xDgWcFill.Rows(ix).Cells(1).Value = FormatNumber(vAT15Wc.xVal(0), 2)
                xDgWcFill.Rows(ix).Cells(2).Value = FormatNumber(vAT15Wc.xVal(1), 2)
                xDgWcFill.Rows(ix).Cells(3).Value = FormatNumber(vAT15Wc.xVal(2), 2)
                xDgWcFill.Rows(ix).Cells(4).Value = FormatNumber(vAT15Wc.xVal(3), 2)
                xDgWcFill.Rows(ix).Cells(5).Value = FormatNumber(vAT15Wc.xVal(4), 2)
                xDgWcFill.Rows(ix).Cells(6).Value = FormatNumber(vAT15Wc.xVal(5), 2)
                ix += 1
            Next
            ix = 0
            xFilleXclCell()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub xFilleXclCell()
        Try
            Dim query As Object = From vAT15Wc As VAT15Wc In WcAl Select vAT15Wc
            Dim ix As Integer = 0
            For Each vAT15Wc As VAT15Wc In query
                xWcVal(ix, 1) = FormatNumber(vAT15Wc.xVal(0), 2)
                xWcVal(ix, 2) = FormatNumber(vAT15Wc.xVal(1), 2)
                xWcVal(ix, 3) = FormatNumber(vAT15Wc.xVal(2), 2)
                xWcVal(ix, 4) = FormatNumber(vAT15Wc.xVal(3), 2)
                xWcVal(ix, 5) = FormatNumber(vAT15Wc.xVal(4), 2)
                xWcVal(ix, 6) = FormatNumber(vAT15Wc.xVal(5), 2)
                xWcVal(ix, 7) = FormatNumber(vAT15Wc.xVal(6), 2)
                ix += 1
            Next
            ix = 0
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "VAT15 PRIOR PERIOD ADJUSTMENTS"
    Public PPAAl As New ArrayList()
    Public PPAAlpur As New ArrayList()

    Private Class VAT15PPA
        Public xPPADes As String
        Public xPPAVal As Double()
        Public xPPADespur As String
        Public xPPAValpur As Double()


    End Class
    Public Sub xDgValuesPPA(ByVal xdgPPA As DataGridView, ByVal xdgPPApur As DataGridView)
        Try
            '' In this Dg has 9 rows(0-8) and 7 columns (0-6)
            ''----------------------------------------------
            PPAAl.Clear()
            For Each xr1 As DataGridViewRow In xdgPPA.Rows
                Dim xx As New VAT15PPA With {.xPPADes = Trim(xr1.Cells(0).Value), _
                                                 .xPPAVal = New Double() {CDbl(xr1.Cells(1).Value), CDbl(xr1.Cells(2).Value), CDbl(xr1.Cells(3).Value), CDbl(xr1.Cells(4).Value), CDbl(xr1.Cells(5).Value)}}
                PPAAl.Add(xx)
            Next

            PPAAlpur.Clear()
            For Each xr1 As DataGridViewRow In xdgPPApur.Rows
                Dim xx As New VAT15PPA With {.xPPADespur = Trim(xr1.Cells(0).Value), _
                                                 .xPPAValpur = New Double() {CDbl(xr1.Cells(1).Value), CDbl(xr1.Cells(2).Value), CDbl(xr1.Cells(3).Value), CDbl(xr1.Cells(4).Value), CDbl(xr1.Cells(5).Value)}}
                PPAAlpur.Add(xx)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Sub xFetchFromPPAAl(ByVal xDgPPAFill As DataGridView, ByVal xDgPPAFillpur As DataGridView)
        Try

            Dim query As Object = From vAT15ppa As VAT15PPA In PPAAl Select vAT15ppa
            Dim ix As Integer = 0
            For Each vAT15ppa As VAT15PPA In query
                xDgPPAFill.Rows(ix).Cells(1).Value = FormatNumber(vAT15ppa.xPPAVal(0), 2)
                xDgPPAFill.Rows(ix).Cells(2).Value = FormatNumber(vAT15ppa.xPPAVal(1), 2)
                xDgPPAFill.Rows(ix).Cells(3).Value = FormatNumber(vAT15ppa.xPPAVal(2), 2)
                xDgPPAFill.Rows(ix).Cells(4).Value = FormatNumber(vAT15ppa.xPPAVal(3), 2)
                xDgPPAFill.Rows(ix).Cells(5).Value = FormatNumber(vAT15ppa.xPPAVal(4), 2)
                ix += 1
            Next
            ix = 0

            Dim queryPur As Object = From vAT15ppa As VAT15PPA In PPAAlpur Select vAT15ppa
            Dim iix As Integer = 0
            For Each vAT15ppa As VAT15PPA In queryPur
                xDgPPAFillpur.Rows(iix).Cells(1).Value = FormatNumber(vAT15ppa.xPPAValpur(0), 2)
                xDgPPAFillpur.Rows(iix).Cells(2).Value = FormatNumber(vAT15ppa.xPPAValpur(1), 2)
                xDgPPAFillpur.Rows(iix).Cells(3).Value = FormatNumber(vAT15ppa.xPPAValpur(2), 2)
                xDgPPAFillpur.Rows(iix).Cells(4).Value = FormatNumber(vAT15ppa.xPPAValpur(3), 2)
                xDgPPAFillpur.Rows(iix).Cells(5).Value = FormatNumber(vAT15ppa.xPPAValpur(4), 2)
                iix += 1
            Next
            iix = 0
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region
#Region "FETCH TDS AND PRIOR PERIOD ADJUSTMENTS"
    Public Sub xFtchTDSfromWcAl(ByVal xTdsTxt As TextBox, ByVal xPPAITCtxt As TextBox, ByVal xChkBx As CheckBox)
        Try
            Dim query As Object = From vAT15Wc As VAT15Wc In WcAl Select vAT15Wc
            Dim ix As Integer = 0
            For Each vAT15Wc As VAT15Wc In query
                If ix = 8 Then
                    xTdsTxt.Text = FormatNumber(vAT15Wc.xVal(4), 2)
                    xTdsTxt.ReadOnly = True
                End If
                ix += 1
            Next
            Dim query1 As Object = From vAT15PPA As VAT15PPA In PPAAlpur Select vAT15PPA
            Dim ix1 As Integer = 0
            For Each vAT15PPA As VAT15PPA In query1
                If ix1 = 8 Then
                    xPPAITCtxt.Text = FormatNumber(vAT15PPA.xPPAValpur(4), 2)
                    xPPAITCtxt.ReadOnly = True
                End If
                ix1 += 1
            Next
            Dim xVal As Double = CDbl(xPPAITCtxt.Text)
            If xVal > 0 Then
                xChkBx.CheckState = CheckState.Checked
            Else
                xChkBx.CheckState = CheckState.Unchecked
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "FETCH OUTPUT TAX"
    Public Sub xFtchOTfromPPAAL(ByVal xOTtxt As TextBox, ByVal xChkBx As CheckBox)
        Try
            Dim query As Object = From vAT15PPA As VAT15PPA In PPAAl Select vAT15PPA
            Dim ix As Integer = 0
            For Each vAT15PPA As VAT15PPA In query
                If ix = 8 Then
                    xOTtxt.Text = FormatNumber(vAT15PPA.xPPAVal(4), 2)
                    xOTtxt.ReadOnly = True
                End If
                ix += 1
            Next
            Dim xVal As Double = CDbl(xOTtxt.Text)
            If xVal > 0 Then
                xChkBx.CheckState = CheckState.Checked
            Else
                xChkBx.CheckState = CheckState.Unchecked
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "FETCH TAX PAYABLE/EXCESS ITC"
    Public ITCOTAl As New ArrayList()

    Private Class VAT15ITCOT
        Public xDesITCOT As String
        Public xValITCOT As Double()

    End Class
    Public Sub xDgValuesITCOT(ByVal xdgITCOT As DataGridView)
        Try
            '' In this Dg has 21 rows(0-20) and 2 columns (0-1)
            ''----------------------------------------------
            ITCOTAl.Clear()
            For Each xr1 As DataGridViewRow In xdgITCOT.Rows
                Dim xx As New VAT15ITCOT With {.xDesITCOT = Trim(xr1.Cells(0).Value), _
                                                 .xValITCOT = New Double() {CDbl(xr1.Cells(1).Value)}}
                ITCOTAl.Add(xx)
            Next
            xFetchITCOT()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub xFetchITCOT()
        Try
            Dim query As Object = From vAT15ITCOT As VAT15ITCOT In ITCOTAl Select vAT15ITCOT
            Dim ix As Integer = 0
            For Each VAT15ITCOT As VAT15ITCOT In query
                xOT_ITC_Adjstmnt(ix) = FormatNumber(VAT15ITCOT.xValITCOT(0), 2)
                ix += 1
            Next
            ix = 0
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "On EXIT CLEAR ALL VALUES"
    Public Sub xOnExitClrAllValues()
        Try
            xVAT_Flag1_2 = False
            xVAT_Flag1_2a = False
            xVAT_Flag3 = False
            xVAT_Flag4 = False
            xVAT_Flag5 = False
            xVAT_Flag6 = False
            xVAT_Flag7 = False
            xVAT_Flag8 = False
            xVAT_Flag9 = False
            xVAT_FlagPPA = False
            xVAT_FlagPrd = False
            xVAT_FlagWc = False
            xVAT_DtF = Nothing
            xVAT_DtT = Nothing
            WcAl.Clear()
            PPAAl.Clear()
            PPAAlpur.Clear()
            xPeriodId = 0
            xOTxPPANetOTx = 0
            For Each xdbl As Double In xITCtxt1_to_12
                xdbl = 0
            Next
            For Each xdbl1 As Double In xExmptUnt1_to_10
                xdbl1 = 0
            Next
            xFrmPayExcs1_to_2(0) = 0
            xFrmPayExcs1_to_2(1) = 0
            xOTchk = True
            xITchk = True
            xUAE8 = ""
            For Each xdbl2 As Double In xUAE8_2_to_7
                xdbl2 = 0
            Next
            xUAE8chk = False
            xUAE8dt(0) = Nothing
            xUAE8dt(1) = Nothing
            For Each xdbl3 As Double In xMiseInfo9_1_to_5
                xdbl3 = 0
            Next
            xMiseInfo9chk = False
            xVAT_DgSaleRowIndx = 0
            xVAT_DgPurchaseRowIndx = 0
            xVAT_Sale_a = 0
            xVAT_Sale_b = 0
            xVAT_Sale_c = 0
            xVAT_Sale_cA = 0
            xVAT_Sale_d = 0
            xVAT_Sale_e = 0
            xVAT_Sale_ea = 0
            xVAT_Sale_f = 0
            xVAT_Sale_g = 0
            xVAT_Sale_h = 0
            xVAT_Sale_i = 0
            xVAT_Sale_j = 0
            xVAT_SaleRtd_a = 0
            xVAT_SaleRtd_b = 0
            xVAT_SaleRtd_c = 0
            xVAT_SaleRtd_cA = 0
            xVAT_SaleRtd_d = 0
            xVAT_SaleRtd_e = 0
            xVAT_SaleRtd_ea = 0
            xVAT_SaleRtd_f = 0
            xVAT_SaleRtd_g = 0
            xVAT_SaleRtd_h = 0
            xVAT_SaleRtd_i = 0
            xVAT_SaleRtd_j = 0
            xVAT_S1 = 0
            xVAT_S4 = 0
            xVAT_S5 = 0
            xVAT_S8_8 = 0
            xVAT_S12_5 = 0
            xVAT_S13_5 = 0
            xVAT_S20 = 0
            xVAT_S22 = 0
            xVAT_S27_5 = 0
            xVAT_S30 = 0
            xVAT_Sothr = 0
            xVAT_Sr1 = 0
            xVAT_Sr4 = 0
            xVAT_Sr5 = 0
            xVAT_Sr8_8 = 0
            xVAT_Sr12_5 = 0
            xVAT_Sr13_5 = 0
            xVAT_Sr20 = 0
            xVAT_Sr22 = 0
            xVAT_Sr27_5 = 0
            xVAT_Sr30 = 0
            xVAT_Srothr = 0
            xVAT_S1C = 0
            xVAT_S4C = 0
            xVAT_S5C = 0
            xVAT_S8_8C = 0
            xVAT_S12_5C = 0
            xVAT_S13_5C = 0
            xVAT_S20C = 0
            xVAT_S22C = 0
            xVAT_S27_5C = 0
            xVAT_S30C = 0
            xVAT_SothrC = 0
            xVAT_Sr1C = 0
            xVAT_Sr4C = 0
            xVAT_Sr5C = 0
            xVAT_Sr8_8C = 0
            xVAT_Sr12_5C = 0
            xVAT_Sr13_5C = 0
            xVAT_Sr20C = 0
            xVAT_Sr22C = 0
            xVAT_Sr27_5C = 0
            xVAT_Sr30C = 0
            xVAT_SrothrC = 0
            xVAT_OutputTAX = 0
            xCST_OutputTAX = 0
            xVAT_OutputTAX_Col3d = 0
            xVAT_InputTAX_Col4p = 0
            xVAT_PurchaseTax_Col2h = 0
            xVAT_PurchaseTax_Col2l = 0
            xVAT_Purchase_a = 0
            xVAT_Purchase_b = 0
            xVAT_Purchase_c = 0
            xVAT_Purchase_d = 0
            xVAT_Purchase_e = 0
            xVAT_Purchase_ea = 0
            xVAT_Purchase_f = 0
            xVAT_PurchaseInterState_f = 0
            xVAT_Purchase_g = 0
            xVAT_Purchase_h = 0
            xVAT_Purchase_i = 0
            xVAT_Purchase_j = 0
            xVAT_Purchase_k = 0
            xVAT_Purchase_l = 0
            xVAT_PurchaseRtd_a = 0
            xVAT_PurchaseRtd_b = 0
            xVAT_PurchaseRtd_c = 0
            xVAT_PurchaseRtd_d = 0
            xVAT_PurchaseRtd_e = 0
            xVAT_PurchaseRtd_ea = 0
            xVAT_PurchaseRtd_f = 0
            xVAT_PurchaseRtd_g = 0
            xVAT_PurchaseRtd_h = 0
            xVAT_PurchaseRtd_i = 0
            xVAT_PurchaseRtd_j = 0
            xVAT_PurchaseRtd_k = 0
            xVAT_PurchaseRtd_l = 0
            xVAT_P1 = 0
            xVAT_P4 = 0
            xVAT_P5 = 0
            xVAT_P8_8 = 0
            xVAT_P12_5 = 0
            xVAT_P13_5 = 0
            xVAT_P20 = 0
            xVAT_P22 = 0
            xVAT_P27_5 = 0
            xVAT_P30 = 0
            xVAT_Pothr = 0
            xVAT_Pr1 = 0
            xVAT_Pr4 = 0
            xVAT_Pr5 = 0
            xVAT_Pr8_8 = 0
            xVAT_Pr12_5 = 0
            xVAT_Pr13_5 = 0
            xVAT_Pr20 = 0
            xVAT_Pr22 = 0
            xVAT_Pr27_5 = 0
            xVAT_Pr30 = 0
            xVAT_Prothr = 0
            xPeriodId = 0
            xOTxPPANetOTx = 0
            xOTtype = ""
            xITCtype = ""
            For Each xdbl4 As Double In xOT_ITC_Adjstmnt
                xdbl4 = 0
            Next
            ITCOTAl.Clear()
            For Each xdblxx As Double In xWcVal
                xdblxx = 0
            Next
            xVAT_S1Cdg = 0
            xVAT_S1CdgUn = 0
            xVAT_S1CUn = 0
            xVAT_S1Cbt = 0
            xVAT_STx1 = 0
            xVAT_STx4 = 0
            xVAT_STx5 = 0
            xVAT_STx8_8 = 0
            xVAT_STx12_5 = 0
            xVAT_STx13_5 = 0
            xVAT_STx20 = 0
            xVAT_STx22 = 0
            xVAT_STx27_5 = 0
            xVAT_STx30 = 0
            xVAT_STxothr = 0
            xVAT_CTx1C = 0
            xVAT_CTx4C = 0
            xVAT_CTx5C = 0
            xVAT_CTx8_8C = 0
            xVAT_CTx12_5C = 0
            xVAT_CTx13_5C = 0
            xVAT_CTx20C = 0
            xVAT_CTx22C = 0
            xVAT_CTx27_5C = 0
            xVAT_CTx30C = 0
            xVAT_CTxothrC = 0
            xVAT_CTx2C = 0
            xVAT_S2C = 0
            xVAT_Sr2C = 0


            xVAT_PTx1 = 0
            xVAT_PTx4 = 0
            xVAT_PTx5 = 0
            xVAT_PTx8_8 = 0
            xVAT_PTx12_5 = 0
            xVAT_PTx13_5 = 0
            xVAT_PTx20 = 0
            xVAT_PTx22 = 0
            xVAT_PTx27_5 = 0
            xVAT_PTx30 = 0
            xVAT_PTxothr = 0
        Catch ex As Exception
        End Try
    End Sub
#End Region

End Module

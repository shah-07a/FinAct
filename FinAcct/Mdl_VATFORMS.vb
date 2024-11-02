Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Math
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Runtime.InteropServices ' For COMException
Imports Microsoft.Office.Interop.Excel
Imports Excel = Microsoft.Office.Interop.Excel
Module Mdl_VATFORMS
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader
    Dim SELCASE As Integer = -1


    Public Sub CallVatForm(ByVal xxSelCase As Integer)
        Try
            CoInfo()
            Dim AppExcl As Excel.Application
            AppExcl = New Excel.Application

            If AppExcl Is Nothing Then
                MsgBox("Invalid Action: Excel Could not be Started!", MsgBoxStyle.Critical, "Sys Error")
                Environment.ExitCode = 0
                Exit Sub
            End If

            Select Case xxSelCase
                Case 0 'VAT 1
                    AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\Form-1(CST).xls")
                    With AppExcl
                        '.Visible = False
                        .Range("N7").Value = VATNO.Trim
                        .Range("E7").Value = Format(xVAT_DtF.Date, "dd/MM/yyyy")
                        .Range("H7").Value = Format(xVAT_DtT.Date, "dd/MM/yyyy")
                        .Range("D9").Value = CoName.Trim
                        .Range("H9").Value = CoStatus.Trim
                        .Range("M9").Value = xCoType.Trim
                    End With
                    Try

                        With AppExcl
                            .Range("M11").Value = FormatNumber(xVAT_Sale_a, 2, , , TriState.False) 'GROSS
                            .Range("M13").Value = FormatNumber(xVAT_Sale_c, 2, , , TriState.False)  'DIRECT EXPORT
                            .Range("M14").Value = FormatNumber(xVAT_Sale_cA, 2, , , TriState.False) 'AGAINST H FORM
                            .Range("M15").Value = FormatNumber(xVAT_S1Cbt, 2) 'BRANCH TRANSFER
                            Dim xc As Double = CDbl(xVAT_Sale_c)
                            Dim xcA As Double = CDbl(xVAT_Sale_cA)
                            Dim xcBT As Double = xVAT_S1Cbt
                            .Range("M16").Value = FormatNumber(xVAT_Sale_a - (xc + xcA + xcBT), 2, , , TriState.False) 'INTER STATES INCLUDED WITHIN STATE
                            Dim xM16 As Double = CDbl(.Range("M16").Value)  ' - xVAT_Sale_f
                            .Range("M18").Value = FormatNumber((xVAT_Sale_b + xVAT_Sale_e + xVAT_Sale_h + xVAT_Sale_j), 2, , , TriState.False) 'WITH IN STATES
                            Dim xM18 As Double = CDbl(.Range("M18").Value)
                            .Range("M19").Value = FormatNumber(xM16 - xM18, 2, , , TriState.False) 'INTER STATE SALES 
                            .Range("M21").Value = FormatNumber(0, 2) 'FREIGHT ETC
                            .Range("M22").Value = FormatNumber(xM16 - xM18, 2, , , TriState.False) 'INTER STATE SALES AFTER FREIGHT
                            Dim xM22 As Double = CDbl(.Range("M22").Value)
                            .Range("M24").Value = FormatNumber(xVAT_Sale_ea, 2, , , TriState.False) 'INTER STATE SALES TAX FREE
                            .Range("M25").Value = FormatNumber(xVAT_SaleRtd_d + xVAT_SaleRtd_ea, 2, , , TriState.False) 'INTER STATE SALES RETURNS
                            .Range("M26").Value = FormatNumber(0, 2) ' YET TO CONFIRM' 
                            Dim xM242526 As Double = CDbl(.Range("M24").Value + .Range("M25").Value + .Range("M26").Value)
                            .Range("M27").Value = FormatNumber(xM22 - xM242526, 2, , , TriState.False)
                            Dim xM27 As Double = CDbl(.Range("M27").Value)
                            ' .Range("M28").Value = FormatNumber(0, 2)
                            ' .Range("M29").Value = FormatNumber(0, 2)
                            .Range("M30").Value = FormatNumber(xVAT_S1Cdg, 2, , , TriState.False)
                            .Range("M31").Value = FormatNumber(xVAT_S1CdgUn, 2, , , TriState.False)
                            ' .Range("M32").Value = FormatNumber(0, 2)
                            .Range("E34").Value = FormatNumber(xVAT_S1CUn, 2, , , TriState.False)
                            Dim xM3031E34 As Double = CDbl(xVAT_S1Cdg + xVAT_S1CdgUn + xVAT_S1CUn)
                            .Range("M33").Value = FormatNumber(xM27 - xM3031E34, 2, , , TriState.False)
                            .Range("M34").Value = FormatNumber(xM27, 2, , , TriState.False)

                            .Range("C35").Value = FormatNumber(2, 2)
                            .Range("C36").Value = FormatNumber(4, 2)
                            .Range("C37").Value = FormatNumber(5.5, 2)
                            .Range("C38").Value = FormatNumber(8.8, 2)
                            .Range("C39").Value = FormatNumber(12.5, 2)
                            .Range("C40").Value = FormatNumber(13.75, 2)
                            .Range("F35").Value = FormatNumber(xVAT_S1C, 2, , , TriState.False)
                            .Range("F36").Value = FormatNumber(xVAT_S4C, 2, , , TriState.False)
                            .Range("F37").Value = FormatNumber(xVAT_S5C, 2, , , TriState.False)
                            .Range("F38").Value = FormatNumber(xVAT_S8_8C, 2, , , TriState.False)
                            .Range("F39").Value = FormatNumber(xVAT_S12_5C, 2, , , TriState.False)
                            .Range("F40").Value = FormatNumber((xVAT_S13_5C + xVAT_S20C + xVAT_S22C + xVAT_S27_5C + xVAT_S30C + xVAT_SothrC), 2, , , TriState.False)
                            .Range("M35").Value = FormatNumber(xVAT_Sr1C, 2, , , TriState.False)
                            .Range("M36").Value = FormatNumber(xVAT_Sr4C, 2, , , TriState.False)
                            .Range("M37").Value = FormatNumber(xVAT_Sr5C, 2, , , TriState.False)
                            .Range("M38").Value = FormatNumber(xVAT_Sr8_8C, 2, , , TriState.False)
                            .Range("M39").Value = FormatNumber(xVAT_Sr12_5C, 2, , , TriState.False)
                            .Range("M40").Value = FormatNumber((xVAT_Sr13_5C + xVAT_Sr20C + xVAT_Sr22C + xVAT_Sr27_5C + xVAT_Sr30C + xVAT_SrothrC), 2, , , TriState.False)
                            .Range("E41").Value = FormatNumber(xM27, 2, , , TriState.False)
                            .Range("M41").Value = FormatNumber((xVAT_Sr1C + xVAT_Sr4C + xVAT_Sr5C + xVAT_Sr8_8C + xVAT_Sr12_5C + xVAT_Sr13_5C + xVAT_Sr20C + xVAT_Sr22C + xVAT_Sr27_5C + xVAT_Sr30C + xVAT_SrothrC), 2, , , TriState.False)



                            .Range("B48").Value = "LUDHIANA"
                            .Range("B49").Value = Format(Today.Date, "dd/MM/yyyy")
                            .Range("L48").Value = "Sd/-"
                            .Range("L49").Value = CoOnrDesi.Trim
                        End With

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    Finally

                    End Try
                Case 1 'VAT 15
                    AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-15.xls")

                    With AppExcl
                        '.Visible = False
                        .Range("B9").Value = VATNO.Trim
                        .Range("F9").Value = Format(xVAT_DtF.Date, "dd/MM/yyyy")
                        .Range("H9").Value = Format(xVAT_DtT.Date, "dd/MM/yyyy")
                        .Range("B11").Value = CoName.Trim
                        .Range("B13").Value = Adrs1.Trim & "," & Adrs2.Trim & "-" & Cty
                        .Range("B15").Value = Pin
                        .Range("E15").Value = State.Trim
                        .Range("B17").Value = PhNo.Trim
                        .Range("E17").Value = FaxNo.Trim
                        .Range("B19").Value = Email.Trim
                    End With
                    Try

                        With AppExcl
                            '==S.NO.1 SALE DETAILS
                            .Range("H22").Value = FormatNumber(xVAT_Sale_a, 2, , , TriState.False) 'GROSS
                            .Range("H23").Value = FormatNumber(xVAT_Sale_b, 2, , , TriState.False) 'EXEMPTED
                            .Range("H24").Value = FormatNumber(xVAT_Sale_c + xVAT_Sale_cA, 2, , , TriState.False) 'ZERO RATED (EXPORT)
                            .Range("H25").Value = FormatNumber(xVAT_Sale_d + xVAT_Sale_ea, 2, , , TriState.False) 'INTERSTATE SALE+TAX FREE INTER STATE
                            .Range("H26").Value = FormatNumber(xVAT_Sale_e, 2, , , TriState.False) 'TAX FREE SALE
                            .Range("H27").Value = FormatNumber(xVAT_Sale_f, 2, , , TriState.False) 'SALE RETURN DISCOUNT  ?
                            .Range("H28").Value = FormatNumber(xVAT_Sale_g, 2, , , TriState.False) 'TAX ELEMENTS
                            .Range("H29").Value = FormatNumber(xVAT_Sale_h, 2, , , TriState.False)
                            .Range("H30").Value = FormatNumber(xVAT_Sale_i, 2, , , TriState.False)
                            ' .Range("H31").Value = 'NET SALE AUTO FILLED
                            '==S.NO.2 PURCHASE DETAILS 
                            .Range("H36").Value = FormatNumber(xVAT_Purchase_a, 2, , , TriState.False) 'GROSS
                            .Range("H37").Value = FormatNumber(xVAT_Purchase_b, 2, , , TriState.False) 'IMPORT OUT SIDE INDIA
                            .Range("H38").Value = FormatNumber(xVAT_Purchase_c + xVAT_Purchase_ea, 2, , , TriState.False) ' INTER STATE,BRANCH TFR ETC
                            .Range("H39").Value = FormatNumber(xVAT_Purchase_d, 2, , , TriState.False) 'EXEMPTED
                            .Range("H40").Value = FormatNumber(xVAT_Purchase_e, 2, , , TriState.False) 'TAX FREE PURCHASE
                            .Range("H41").Value = FormatNumber(xVAT_Purchase_f, 2, , , TriState.False) 'PURCHASE FROM OTHER THAN TAXABLE PERSON ?
                            .Range("H42").Value = FormatNumber(xVAT_Purchase_g, 2, , , TriState.False) 'PURCHASE H FORM ?
                            .Range("H43").Value = FormatNumber(xVAT_Purchase_h, 2, , , TriState.False) 'PURCHASE U/S 19(1) AND 20  ?
                            .Range("H44").Value = FormatNumber(xVAT_Purchase_i, 2, , , TriState.False) 'PURCHASE U/S 13(5) ?
                            .Range("H45").Value = FormatNumber(xVAT_Purchase_j, 2, , , TriState.False) 'PURCHASE RETURN DISCOUNT  ?
                            .Range("H46").Value = FormatNumber(xVAT_Purchase_k, 2, , , TriState.False) 'OTHER S
                            '.Range("H47").Value = NET PURCHASE AUTO FILLED

                            '==S.NO.3 OUTPUT TAX
                            .Range("H51").Value = FormatNumber(xVAT_OutputTAX, 2, , , TriState.False) '
                            .Range("H52").Value = FormatNumber(xVAT_PurchaseTax_Col2h, 2, , , TriState.False) '
                            .Range("B53").Value = xOTtype.Trim '
                            .Range("H53").Value = FormatNumber(Math.Abs(xOTxPPANetOTx), 2, , , TriState.False) '
                            '.Range("H54").Value = FormatNumber(0, 2) 'AUTO FILLED

                            '==S.NO.4 INPUT TAX CREDIT ON ACTUAL BASIS
                            .Range("H57").Value = FormatNumber(xITCtxt1_to_12(0), 2, , , TriState.False)
                            .Range("H58").Value = FormatNumber(xITCtxt1_to_12(1), 2, , , TriState.False)
                            .Range("H59").Value = FormatNumber(xITCtxt1_to_12(2), 2, , , TriState.False)
                            ' .Range("H60").Value = FormatNumber(xITCtxt1_to_12(3), 2, , , TriState.False 
                            .Range("H60").Value = FormatNumber(xVAT_PurchaseTax_Col2l, 2, , , TriState.False)
                            .Range("H61").Value = FormatNumber(xITCtxt1_to_12(3), 2, , , TriState.False)
                            .Range("B62").Value = xITCtype.Trim
                            .Range("H62").Value = FormatNumber(Math.Abs(xITCtxt1_to_12(4)), 2, , , TriState.False)
                            .Range("H63").Value = FormatNumber(xITCtxt1_to_12(5), 2, , , TriState.False)
                            ' .Range("H64").Value = FormatNumber(0, 2) 'AUTO FILLED
                            .Range("H65").Value = FormatNumber(xITCtxt1_to_12(6), 2, , , TriState.False)
                            .Range("H66").Value = FormatNumber(xITCtxt1_to_12(7), 2, , , TriState.False)
                            .Range("H67").Value = FormatNumber(xITCtxt1_to_12(8), 2, , , TriState.False)
                            .Range("H68").Value = FormatNumber(xITCtxt1_to_12(9), 2, , , TriState.False)
                            .Range("H69").Value = FormatNumber(xITCtxt1_to_12(10), 2, , , TriState.False)
                            .Range("H70").Value = FormatNumber(xITCtxt1_to_12(11), 2, , , TriState.False)
                            ' .Range("H71").Value = FormatNumber(0, 2) 'AUTO FILLED
                            ' .Range("H72").Value = FormatNumber(0, 2) ' AUTO FILLED
                            '------------------
                            '================
                            '==S.NO.5 GOODS PURCHASE FROM EXEMPTED UNITS
                            .Range("H76").Value = FormatNumber(xVAT_Purchase_d, 2, , , TriState.False) '
                            .Range("H77").Value = FormatNumber(xVAT_PurchaseRtd_d, 2, , , TriState.False) '
                            .Range("H78").Value = FormatNumber(xExmptUnt1_to_10(1), 2, , , TriState.False) '
                            .Range("H79").Value = FormatNumber(xExmptUnt1_to_10(2), 2, , , TriState.False) '
                            .Range("H80").Value = FormatNumber(xExmptUnt1_to_10(3), 2, , , TriState.False) '
                            .Range("H81").Value = FormatNumber(xExmptUnt1_to_10(4), 2, , , TriState.False) '
                            .Range("H82").Value = FormatNumber(xExmptUnt1_to_10(5), 2, , , TriState.False) '
                            .Range("H83").Value = FormatNumber(xExmptUnt1_to_10(6), 2, , , TriState.False) '
                            .Range("H84").Value = FormatNumber(xExmptUnt1_to_10(7), 2, , , TriState.False) '
                            ' .Range("H85").Value = FormatNumber(0, 2) ' AUTO FILLED

                            '==S.NO.5-A INPUT TAX CREDIT ON NOTIONAL BASIS
                            .Range("H88").Value = FormatNumber(xExmptUnt1_to_10(8), 2, , , TriState.False) '
                            .Range("H89").Value = FormatNumber(xExmptUnt1_to_10(9), 2, , , TriState.False) '
                            ' .Range("H90").Value = FormatNumber(0, 2) ' AUTO FILLED

                            '==S.NO.6 TAX PAYABLE/EXCESS INPUT TAX CREDIT
                            .Range("H93").Value = FormatNumber(xOT_ITC_Adjstmnt(0), 2, , , TriState.False) '
                            .Range("H94").Value = FormatNumber(xOT_ITC_Adjstmnt(1), 2, , , TriState.False) '
                            .Range("H95").Value = FormatNumber(xOT_ITC_Adjstmnt(2), 2, , , TriState.False) '
                            .Range("H96").Value = FormatNumber(xOT_ITC_Adjstmnt(3), 2, , , TriState.False) '
                            .Range("H97").Value = FormatNumber(xOT_ITC_Adjstmnt(4), 2, , , TriState.False) '
                            ' .Range("H98").Value = FormatNumber(0, 2) 'AUTO FILLED
                            '.Range("H99").Value = FormatNumber(0, 2) '
                            .Range("H100").Value = FormatNumber(xOT_ITC_Adjstmnt(7), 2, , , TriState.False) '
                            .Range("H101").Value = FormatNumber(xOT_ITC_Adjstmnt(8), 2, , , TriState.False) '
                            .Range("H102").Value = FormatNumber(xOT_ITC_Adjstmnt(9), 2, , , TriState.False) '
                            .Range("H103").Value = FormatNumber(xOT_ITC_Adjstmnt(10), 2, , , TriState.False) '
                            '.Range("H104").Value = FormatNumber(0, 2) '
                            .Range("H105").Value = FormatNumber(xOT_ITC_Adjstmnt(12), 2, , , TriState.False) '
                            .Range("H106").Value = FormatNumber(xOT_ITC_Adjstmnt(13), 2, , , TriState.False) '
                            .Range("H107").Value = FormatNumber(xOT_ITC_Adjstmnt(14), 2, , , TriState.False) '
                            ' .Range("H108").Value = FormatNumber(0, 2) '
                            .Range("H109").Value = FormatNumber(xOT_ITC_Adjstmnt(16), 2, , , TriState.False) '
                            .Range("H110").Value = FormatNumber(xOT_ITC_Adjstmnt(17), 2, , , TriState.False) '
                            .Range("H111").Value = FormatNumber(xOT_ITC_Adjstmnt(18), 2, , , TriState.False) '
                            .Range("H112").Value = FormatNumber(xOT_ITC_Adjstmnt(19), 2, , , TriState.False) '
                            .Range("H113").Value = FormatNumber(xOT_ITC_Adjstmnt(20), 2, , , TriState.False) '

                            '==S.NO.7 DETAIL OF TAX PAYMENT DURING THE RETURN PERIOD
                            'TO BE FILLED ON LINE MANUALLY

                            '==S.NO.8  FOR UNITS AVAILING EXEMPTION OR DEFFERMENT
                            ' TO BE CONSULT WITH LAYWER
                            If Not Len(xUAE8.Trim) = 0 Then
                                .Range("F123").Value = xUAE8.Trim
                                .Range("H123").Value = Format(xUAE8dt(0).Date, "dd/MM/yyyy")
                                .Range("H124").Value = Format(xUAE8dt(1).Date, "dd/MM/yyyy")
                                .Range("H125").Value = FormatNumber(xUAE8_2_to_7(0), 2, , , TriState.False)
                                .Range("H126").Value = FormatNumber(xUAE8_2_to_7(1), 2, , , TriState.False)
                                .Range("H127").Value = FormatNumber(xUAE8_2_to_7(2), 2, , , TriState.False)
                                .Range("H128").Value = FormatNumber(xUAE8_2_to_7(3), 2, , , TriState.False)
                                .Range("H129").Value = FormatNumber(xUAE8_2_to_7(4), 2, , , TriState.False)
                                .Range("H130").Value = FormatNumber(xUAE8_2_to_7(5), 2, , , TriState.False)
                            Else
                                .Range("H125").Value = FormatNumber(0, 2, , , TriState.False)
                                .Range("H126").Value = FormatNumber(0, 2, , , TriState.False)
                                .Range("H127").Value = FormatNumber(0, 2, , , TriState.False)
                                .Range("H128").Value = FormatNumber(0, 2, , , TriState.False)
                                .Range("H129").Value = FormatNumber(0, 2, , , TriState.False)
                                .Range("H130").Value = FormatNumber(0, 2, , , TriState.False)
                            End If
                            '==S.NO.9 MISCELLANEOUS INFORMATION (WHEREEVER APPLICABLE)
                            .Range("H133").Value = FormatNumber(xMiseInfo9_1_to_5(0), 2, , , TriState.False) '
                            .Range("H134").Value = FormatNumber(xMiseInfo9_1_to_5(1), 2, , , TriState.False) '
                            .Range("H135").Value = FormatNumber(xMiseInfo9_1_to_5(2), 2, , , TriState.False) '
                            .Range("H136").Value = FormatNumber(xMiseInfo9_1_to_5(3), 2, , , TriState.False) '
                            .Range("H137").Value = FormatNumber(xMiseInfo9_1_to_5(4), 2, , , TriState.False) '

                            'NAME
                            .Range("B139").Value = CoOnrName.Trim
                            'SIGNATURE
                            .Range("B140").Value = "sd/-"
                            'STATUS
                            .Range("F139").Value = CoOnrDesi.Trim
                            'DATE
                            .Range("F140").Value = Format(Today.Date, "dd/MM/yyyy")

                            '========WORKSHEET==========
                            'S.NO. BREAK UP OF TAXABLE SALES AND PURCHASE IN PUNJAB(EXCLUDING CAPITAL GOODS)

                            .Range("B151").Value = FormatNumber(xVAT_S1, 2, , , TriState.False)
                            .Range("C151").Value = FormatNumber(xVAT_Sr1, 2, , , TriState.False)
                            .Range("B152").Value = FormatNumber(xVAT_S4, 2, , , TriState.False)
                            .Range("C152").Value = FormatNumber(xVAT_Sr4, 2, , , TriState.False)
                            .Range("B153").Value = FormatNumber(xVAT_S8_8, 2, , , TriState.False)
                            .Range("C153").Value = FormatNumber(xVAT_Sr8_8, 2, , , TriState.False)
                            .Range("B154").Value = FormatNumber(xVAT_S12_5, 2, , , TriState.False)
                            .Range("C154").Value = FormatNumber(xVAT_Sr12_5, 2, , , TriState.False)
                            .Range("B155").Value = FormatNumber(xVAT_S20, 2, , , TriState.False)
                            .Range("C155").Value = FormatNumber(xVAT_Sr20, 2, , , TriState.False)
                            .Range("B156").Value = FormatNumber(xVAT_S22, 2, , , TriState.False)
                            .Range("C156").Value = FormatNumber(xVAT_Sr22, 2, , , TriState.False)
                            .Range("B157").Value = FormatNumber(xVAT_S27_5, 2, , , TriState.False)
                            .Range("C157").Value = FormatNumber(xVAT_Sr27_5, 2, , , TriState.False)
                            .Range("B158").Value = FormatNumber(xVAT_S30, 2, , , TriState.False)
                            .Range("C158").Value = FormatNumber(xVAT_Sr30, 2, , , TriState.False)
                            .Range("B160").Value = FormatNumber(xVAT_S5 + xVAT_S13_5 + xVAT_Sothr, 2, , , TriState.False)
                            .Range("C160").Value = FormatNumber(xVAT_Sr5 + xVAT_Sr13_5 + xVAT_Srothr, 2, , , TriState.False)
                            '.Range("B160").Value = FormatNumber(0, 2)'AUTO FILLED
                            ' .Range("C160").Value = FormatNumber(0, 2)'AUTO FILLED

                            .Range("D151").Value = FormatNumber(xVAT_P1, 2, , , TriState.False)
                            .Range("G151").Value = FormatNumber(xVAT_Pr1, 2, , , TriState.False)
                            .Range("D152").Value = FormatNumber(xVAT_P4, 2, , , TriState.False)
                            .Range("G152").Value = FormatNumber(xVAT_Pr4, 2, , , TriState.False)
                            .Range("D153").Value = FormatNumber(xVAT_P8_8, 2, , , TriState.False)
                            .Range("G153").Value = FormatNumber(xVAT_Pr8_8, 2, , , TriState.False)
                            .Range("D154").Value = FormatNumber(xVAT_P12_5, 2, , , TriState.False)
                            .Range("G154").Value = FormatNumber(xVAT_Pr12_5, 2, , , TriState.False)
                            .Range("D155").Value = FormatNumber(xVAT_P20, 2, , , TriState.False)
                            .Range("G155").Value = FormatNumber(xVAT_Pr20, 2, , , TriState.False)
                            .Range("D156").Value = FormatNumber(xVAT_P22, 2, , , TriState.False)
                            .Range("G156").Value = FormatNumber(xVAT_Pr22, 2, , , TriState.False)
                            .Range("D157").Value = FormatNumber(xVAT_P27_5, 2, , , TriState.False)
                            .Range("G157").Value = FormatNumber(xVAT_Pr27_5, 2, , , TriState.False)
                            .Range("D158").Value = FormatNumber(xVAT_P30, 2, , , TriState.False)
                            .Range("G158").Value = FormatNumber(xVAT_Pr30, 2, , , TriState.False)
                            .Range("D160").Value = FormatNumber(xVAT_P5 + xVAT_P13_5 + xVAT_Pothr, 2, , , TriState.False)
                            .Range("G160").Value = FormatNumber(xVAT_Pr5 + xVAT_Pr13_5 + xVAT_Prothr, 2, , , TriState.False)
                            '.Range("D160").Value = FormatNumber(0, 2)'AUTO FILLED
                            ' .Range("G160").Value = FormatNumber(0, 2)'AUTO FILLED
                            'S.NO. 2 BREAK UP OF GOODS SOLD UNDER WORKS CONTRACT
                            .Range("A165").Value = FormatNumber(xWcVal(0, 1), 2, , , TriState.False)
                            .Range("A166").Value = FormatNumber(xWcVal(1, 1), 2, , , TriState.False)
                            .Range("A167").Value = FormatNumber(xWcVal(2, 1), 2, , , TriState.False)
                            .Range("A168").Value = FormatNumber(xWcVal(3, 1), 2, , , TriState.False)
                            .Range("A169").Value = FormatNumber(xWcVal(4, 1), 2, , , TriState.False)
                            .Range("A170").Value = FormatNumber(xWcVal(5, 1), 2, , , TriState.False)
                            .Range("A171").Value = FormatNumber(xWcVal(6, 1), 2, , , TriState.False)
                            .Range("A172").Value = FormatNumber(xWcVal(7, 1), 2, , , TriState.False)

                            '.Range("A172").Value = FormatNumber(0, 2)
                            '.Range("A173").Value = FormatNumber(0, 2)
                            '.Range("A174").Value = FormatNumber(0, 2)
                            .Range("B165").Value = FormatNumber(xWcVal(0, 2), 2, , , TriState.False)
                            .Range("B166").Value = FormatNumber(xWcVal(1, 2), 2, , , TriState.False)
                            .Range("B167").Value = FormatNumber(xWcVal(2, 2), 2, , , TriState.False)
                            .Range("B168").Value = FormatNumber(xWcVal(3, 2), 2, , , TriState.False)
                            .Range("B169").Value = FormatNumber(xWcVal(4, 2), 2, , , TriState.False)
                            .Range("B170").Value = FormatNumber(xWcVal(5, 2), 2, , , TriState.False)
                            .Range("B171").Value = FormatNumber(xWcVal(6, 2), 2, , , TriState.False)
                            .Range("B172").Value = FormatNumber(xWcVal(7, 2), 2, , , TriState.False)
                            '.Range("B172").Value = FormatNumber(0, 2)
                            '.Range("B173").Value = FormatNumber(0, 2)
                            '.Range("B174").Value = FormatNumber(0, 2)
                            .Range("C165").Value = FormatNumber(xWcVal(0, 3), 2, , , TriState.False)
                            .Range("C166").Value = FormatNumber(xWcVal(1, 3), 2, , , TriState.False)
                            .Range("C167").Value = FormatNumber(xWcVal(2, 3), 2, , , TriState.False)
                            .Range("C168").Value = FormatNumber(xWcVal(3, 3), 2, , , TriState.False)
                            .Range("C169").Value = FormatNumber(xWcVal(4, 3), 2, , , TriState.False)
                            .Range("C170").Value = FormatNumber(xWcVal(5, 3), 2, , , TriState.False)
                            .Range("C171").Value = FormatNumber(xWcVal(6, 3), 2, , , TriState.False)
                            .Range("C172").Value = FormatNumber(xWcVal(7, 3), 2, , , TriState.False)
                            '.Range("C172").Value = FormatNumber(0, 2)
                            '.Range("C173").Value = FormatNumber(0, 2)
                            '.Range("C174").Value = FormatNumber(0, 2)
                            .Range("D165").Value = FormatNumber(xWcVal(0, 7), 2, , , TriState.False)
                            .Range("D166").Value = FormatNumber(xWcVal(1, 7), 2, , , TriState.False)
                            .Range("D167").Value = FormatNumber(xWcVal(2, 7), 2, , , TriState.False)
                            .Range("D168").Value = FormatNumber(xWcVal(3, 7), 2, , , TriState.False)
                            .Range("D169").Value = FormatNumber(xWcVal(4, 7), 2, , , TriState.False)
                            .Range("D170").Value = FormatNumber(xWcVal(5, 7), 2, , , TriState.False)
                            .Range("D171").Value = FormatNumber(xWcVal(6, 7), 2, , , TriState.False)
                            .Range("D172").Value = FormatNumber(xWcVal(7, 7), 2, , , TriState.False)
                            '.Range("D172").Value = FormatNumber(0, 2)
                            '.Range("D173").Value = FormatNumber(0, 2)
                            '.Range("D174").Value = FormatNumber(0, 2)
                            '.Range("F164").Value = FormatNumber(0, 2)
                            '.Range("F165").Value = FormatNumber(0, 2)
                            '.Range("F166").Value = FormatNumber(0, 2)
                            '.Range("F167").Value = FormatNumber(0, 2)
                            '.Range("F168").Value = FormatNumber(0, 2)
                            '.Range("F169").Value = FormatNumber(0, 2)
                            '.Range("F170").Value = FormatNumber(0, 2)
                            '.Range("F171").Value = FormatNumber(0, 2)
                            '.Range("F172").Value = FormatNumber(0, 2)
                            '.Range("F173").Value = FormatNumber(0, 2)
                            '.Range("F174").Value = FormatNumber(0, 2)
                            .Range("G165").Value = FormatNumber(xWcVal(0, 4), 2, , , TriState.False)
                            .Range("G166").Value = FormatNumber(xWcVal(1, 4), 2, , , TriState.False)
                            .Range("G167").Value = FormatNumber(xWcVal(2, 4), 2, , , TriState.False)
                            .Range("G168").Value = FormatNumber(xWcVal(3, 4), 2, , , TriState.False)
                            .Range("G169").Value = FormatNumber(xWcVal(4, 4), 2, , , TriState.False)
                            .Range("G170").Value = FormatNumber(xWcVal(5, 4), 2, , , TriState.False)
                            .Range("G171").Value = FormatNumber(xWcVal(6, 4), 2, , , TriState.False)
                            .Range("G172").Value = FormatNumber(xWcVal(7, 4), 2, , , TriState.False)
                            .Range("G173").Value = FormatNumber(xWcVal(10, 4), 2, , , TriState.False)
                            .Range("G174").Value = FormatNumber(xWcVal(10, 5), 2, , , TriState.False)
                            .Range("G175").Value = FormatNumber(xWcVal(10, 6), 2, , , TriState.False)

                            'S.NO. 3 BREAK UP OF ZERO RATED SALES
                            .Range("C179").Value = FormatNumber(xVAT_Sale_c, 2, , , TriState.False)
                            .Range("C180").Value = FormatNumber(xVAT_Sale_cA, 2, , , TriState.False)
                            .Range("D179").Value = FormatNumber(xVAT_SaleRtd_c, 2, , , TriState.False)
                            .Range("D180").Value = FormatNumber(xVAT_SaleRtd_cA, 2, , , TriState.False)
                            .Range("E179").Value = FormatNumber(0, 2, , , TriState.False)
                            .Range("E180").Value = FormatNumber(0, 2, , , TriState.False)
                            .Range("G179").Value = FormatNumber(xVAT_Sale_c - xVAT_SaleRtd_c, 2, , , TriState.False)
                            .Range("G180").Value = FormatNumber(xVAT_Sale_cA - xVAT_SaleRtd_cA, 2, , , TriState.False)

                            'S.NO. PRIOR PERIOD ADJUSTMENTS
                            .Range("C184").Value = FormatNumber(xPPAsc1(0), 2, , , TriState.False)
                            .Range("C185").Value = FormatNumber(xPPAsc2(0), 2, , , TriState.False)
                            .Range("C186").Value = FormatNumber(xPPAsc3(0), 2, , , TriState.False)
                            .Range("C187").Value = FormatNumber(xPPAsc4(0), 2, , , TriState.False)
                            ' .Range("C187").Value = FormatNumber(0, 2)

                            .Range("D184").Value = FormatNumber(xPPAsc1(1), 2, , , TriState.False)
                            .Range("D185").Value = FormatNumber(xPPAsc2(1), 2, , , TriState.False)
                            .Range("D186").Value = FormatNumber(xPPAsc3(1), 2, , , TriState.False)
                            .Range("D187").Value = FormatNumber(xPPAsc4(1), 2, , , TriState.False)
                            ' .Range("D187").Value = FormatNumber(0, 2)

                            .Range("F184").Value = FormatNumber(xPPApc1(0), 2, , , TriState.False)
                            .Range("F185").Value = FormatNumber(xPPApc2(0), 2, , , TriState.False)
                            .Range("F186").Value = FormatNumber(xPPApc3(0), 2, , , TriState.False)
                            .Range("F187").Value = FormatNumber(xPPApc4(0), 2, , , TriState.False)
                            '.Range("F187").Value = FormatNumber(0, 2)

                            .Range("H184").Value = FormatNumber(xPPApc1(1), 2, , , TriState.False)
                            .Range("H185").Value = FormatNumber(xPPApc2(1), 2, , , TriState.False)
                            .Range("H186").Value = FormatNumber(xPPApc3(1), 2, , , TriState.False)
                            .Range("H187").Value = FormatNumber(xPPApc4(1), 2, , , TriState.False)
                            ' .Range("H187").Value = FormatNumber(0, 2)

                            'S.NO. ANY OTHER ADJUSTMENT (PLEASE SPECIFY)
                            .Range("A191").Value = FormatNumber(0, 2)
                            ''.Range("B190").Value = FormatNumber(0, 2)

                        End With

                        '--------

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    Finally

                    End Try

                Case 2 'VAT 16
                    '  AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\VAT16.xls")

                Case 3 'VAT 18
                    'AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-18-100.xls")
                Case 4 'VAT 19
                    '  AppExcl.Workbooks.Open(xVATExlFilePath & "\VAT FORMS\PVAT-19-100.xls")
                Case 5 'VAT 23
                  
                Case 6 'VAT 24

                  
            End Select

            Dim xF As String = Mid(CoName.Trim, 1, 1)
            Dim xI As Integer = 0
            For Each xCh As Char In CoName.Trim
                xI += 1
                If xCh = " " Then
                    xF += Mid(CoName.Trim, xI + 1, 1)
                End If
            Next


            Select Case xxSelCase
                Case 0 'VAT 1
                    With AppExcl
                        Dim xPth As String = xChkxOrxCreateDir(xF.ToUpper & " " & xPrdName.Trim)
                        If Len(xPth.Trim) = 0 Then Exit Sub
                        '==.ActiveWorkbook.SaveAs(xPth & "\CST1_1stQtr.XLS", , , , , , XlSaveAsAccessMode.xlNoChange) 'it is working ok
                        '==.ActiveWorkbook.SaveAs(xPth & "\CST1_1stQtr.XLS", , "mohd@786#rafiq#cst1", , , , XlSaveAsAccessMode.xlNoChange) ' it work with password
                        .ActiveWorkbook.SaveAs(xPth & "\Form-1(CST).xls")
                        .Visible = True
                        .DisplayAlerts = False
                        .Workbooks.Close()
                        .Quit()
                        ' MsgBox("You can find current file at: " & xPth)
                    End With
                Case 1 'VAT 15
                    With AppExcl
                        Dim xPth As String = xChkxOrxCreateDir(xF.ToUpper & " " & xPrdName.Trim)
                        If Len(xPth.Trim) = 0 Then Exit Sub
                        ''==.ActiveWorkbook.SaveAs(xPth & "\PVAT15_1stQtr.XLS", , , , , , XlSaveAsAccessMode.xlNoChange) 'it is working ok
                        '== .ActiveWorkbook.SaveAs(xPth & "\PVAT15_1stQtr.XLS", , "mohd@786#rafiq#vat15", , , , XlSaveAsAccessMode.xlNoChange) ' it work with password
                        .ActiveWorkbook.SaveAs(xPth & "\PVAT-15.xls")
                        .Visible = True
                        .DisplayAlerts = False
                        .Workbooks.Close()
                        .Quit()
                        ' MsgBox("You can find current file at: " & xPth)
                    End With
            End Select


            Debug.WriteLine("Sleeping...")
            System.Threading.Thread.Sleep(100)
            Debug.WriteLine("End Excel")
            releaseObject(AppExcl)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub
    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub
    Public Function xChkxOrxCreateDir(ByVal xxSubDir As String) As String
        xChkxOrxCreateDir = ""
        Try

            'Check to make sure the directory given exists.
            Dim xDir As String = xBaKupDrive & "QIS VAT FORMS"
            Dim xSubDir As String = xDir & "\" & xxSubDir.Trim

            If Not System.IO.Directory.Exists(xDir) Then
                System.IO.Directory.CreateDirectory(xDir)
            End If
            If Not System.IO.Directory.Exists(xSubDir) Then
                System.IO.Directory.CreateDirectory(xSubDir)
            End If
            Dim xSD As New DirectoryInfo(xDir)
            xSD.Attributes = FileAttributes.Normal
            Return xSubDir.Trim
        Catch ex As Exception

        End Try

    End Function


End Module

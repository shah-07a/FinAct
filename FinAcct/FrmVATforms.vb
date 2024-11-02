
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Runtime.InteropServices ' For COMException
Imports Microsoft.Office.Interop.Excel
Imports Excel = Microsoft.Office.Interop.Excel

Public Class FrmVATforms
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader
    Dim CoName As String = ""
    Dim VATNO As String = ""
    Dim Adrs1 As String = ""
    Dim Adrs2 As String = ""
    Dim Cty As String = ""
    Dim State As String = ""
    Dim Contry As String = ""
    Dim PhNo As String = ""
    Dim Pin As Integer = 0
    Dim Email As String = ""
    Dim FaxNo As String = ""
    Dim CoOnrDesi As String = ""
    Dim CoStatus As String = ""

    Private Sub FrmVATforms_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Try
                If FinActConn.State Then FinActConn.Close()
                FinActConn.Open()
                VATcmd = New SqlCommand("TRUNCATE TABLE Finact_Temp_VAT_PurEntry", FinActConn)
                VATcmd.ExecuteNonQuery()
                VATcmd.Dispose()
                VATcmd = New SqlCommand("TRUNCATE TABLE Finact_Temp_VAT_SaleEntry", FinActConn)
                VATcmd.ExecuteNonQuery()
                VATcmd.Dispose()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub


    Private Sub FrmVATforms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Fill_Combobox("Perdid", "PerdName", "Finact_PerdMstr", "PerdDelStatus", CInt(1), Me.CmbxPerd)
            CoInfo()
            Me.CmbxVatfrm.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxVatfrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxVatfrm.GotFocus
        Try
            Me.CmbxVatfrm.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxVatfrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxVatfrm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxVatfrm_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxVatfrm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxVatfrm.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxVatfrm) = True Then
                Me.CmbxPerd.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Allcntl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpVAT1.KeyDown, DtpVAT2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CoInfo()

        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            Dim DcrpPass As New EnCryp_DeCryp_String
            VATcmd = New SqlCommand("FinactCogatemstr_Select", FinActConn1)
            VATrdr = VATcmd.ExecuteReader
            VATrdr.Read()
            CoName = DcrpPass.Decrypt(VATrdr("coname"))
            VATNO = VATrdr("covat")
            Adrs1 = VATrdr("adrs1")
            Adrs2 = VATrdr("adrs2")
            Cty = VATrdr("adrscty")
            State = VATrdr("adrsstate")
            Contry = VATrdr("adrscontry")
            PhNo = VATrdr("adrsphwork")
            Pin = VATrdr("adrspin")
            Email = VATrdr("adrsemail")
            FaxNo = VATrdr("adrsfaxno")
            CoOnrDesi = VATrdr("COONRDESI")
            If VATrdr("Costatus") = "CoFrm" Then
                CoStatus = "COMPANY"
            Else
                CoStatus = "PROPRIETORSHIP"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            VATcmd.Dispose()
            VATrdr.Close()
        End Try


    End Sub
    Private Sub CallVatForm()
        Try
            If Me.CmbxVatfrm.SelectedIndex = -1 Then
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

            Dim AppExcl As Excel.Application
            AppExcl = New Excel.Application
            If AppExcl Is Nothing Then
                MsgBox("Invalid Action: Excel Could not be Started!", MsgBoxStyle.Critical, Me.Text)
                Environment.ExitCode = 0
                Me.CmbxVatfrm.Focus()
                Exit Sub
            End If


            Select Case Me.CmbxVatfrm.SelectedIndex
                Case 0 'VAT 1
                    AppExcl.Workbooks.Open("E:\Data from home pc 01012208\My Projects after vis\FinAcct_Master\Finact_MASTER\FinAcct\bin\x86\Debug\VAT FORMS\Form-1(CST).xls")
                    With AppExcl
                        '.Visible = False
                        .Range("N7").Value = VATNO.Trim
                        .Range("E7").Value = Format(DtpVAT1.Value.Date, "dd/MM/yyyy")
                        .Range("H7").Value = Format(DtpVAT2.Value.Date, "dd/MM/yyyy")
                        .Range("D9").Value = CoName.Trim
                        .Range("H9").Value = CoStatus.Trim
                        .Range("M9").Value = xCoType.Trim
                    End With
                    Try
                        If FinActConn1.State Then FinActConn1.Close()
                        FinActConn1.Open()
                        VATcmd = New SqlCommand("Finact_Temp_VAT_SalePurEntry_Select", FinActConn1)
                        VATcmd.CommandType = CommandType.StoredProcedure
                        VATrdr = VATcmd.ExecuteReader
                        While VATrdr.Read
                            With AppExcl
                                .Range("M11").Value = FormatNumber(VATrdr("SGROSS"), 2) 'GROSS
                                .Range("M13").Value = FormatNumber(0, 2)
                                .Range("M14").Value = FormatNumber(0, 2)
                                .Range("M15").Value = FormatNumber(0, 2)
                                .Range("M16").Value = FormatNumber(VATrdr("SGROSS"), 2) 'LESS M13,M14,15
                                .Range("M18").Value = FormatNumber(VATrdr("S_WISEXEMP") + VATrdr("S_ISEXEMP") + VATrdr("SEXPORT") + VATrdr("S_ISTF") + VATrdr("S_WISTF") + VATrdr("S_WIS"), 2) 'EXEMPTED
                                .Range("M19").Value = FormatNumber(0, 2)
                                .Range("M21").Value = FormatNumber(0, 2)
                                .Range("M22").Value = FormatNumber(0, 2)
                                .Range("M24").Value = FormatNumber(0, 2)
                                .Range("M25").Value = FormatNumber(0, 2)
                                .Range("M26").Value = FormatNumber(0, 2)
                                .Range("M27").Value = FormatNumber(0, 2)
                                .Range("M28").Value = FormatNumber(0, 2)
                                .Range("M29").Value = FormatNumber(0, 2)
                                .Range("M30").Value = FormatNumber(0, 2)
                                .Range("M31").Value = FormatNumber(0, 2)
                                .Range("M32").Value = FormatNumber(0, 2)
                                .Range("M33").Value = FormatNumber(0, 2)
                                .Range("M34").Value = FormatNumber(0, 2)

                                .Range("B48").Value = "LUDHIANA"
                                .Range("B49").Value = Format(Today.Date, "dd/MM/yyyy")
                                .Range("L48").Value = "Sd/-"
                                .Range("L49").Value = CoOnrDesi.Trim
                            End With
                        End While
                        '--------

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    Finally
                        VATcmd.Dispose()
                        VATrdr.Close()
                    End Try
                Case 1 'VAT 15
                    AppExcl.Workbooks.Open("d:\Data from home pc 01012208\My Projects after vis\FinAcct_Master\Finact_MASTER\FinAcct\bin\x86\Debug\VAT FORMS\Qifar_evat15_q2_2009.xls")

                    With AppExcl
                        '.Visible = False
                        .Range("B9").Value = VATNO.Trim
                        .Range("F9").Value = Format(DtpVAT1.Value.Date, "dd/MM/yyyy")
                        .Range("H9").Value = Format(DtpVAT2.Value.Date, "dd/MM/yyyy")
                        .Range("B11").Value = CoName.Trim
                        .Range("B13").Value = Adrs1.Trim & "," & Adrs2.Trim & "-" & Cty
                        .Range("B15").Value = Pin
                        .Range("E15").Value = State.Trim
                        .Range("B17").Value = PhNo.Trim
                        .Range("E17").Value = FaxNo.Trim
                        .Range("B19").Value = Email.Trim
                    End With
                    Try
                        If FinActConn1.State Then FinActConn1.Close()
                        FinActConn1.Open()
                        VATcmd = New SqlCommand("Finact_Temp_VAT_SalePurEntry_Select", FinActConn1)
                        VATcmd.CommandType = CommandType.StoredProcedure
                        VATrdr = VATcmd.ExecuteReader
                        While VATrdr.Read
                            With AppExcl
                                '==S.NO.1 SALE DETAILS
                                .Range("H22").Value = FormatNumber(VATrdr("SGROSS"), 2) 'GROSS
                                .Range("H23").Value = FormatNumber(VATrdr("S_WISEXEMP") + VATrdr("S_ISEXEMP"), 2) 'EXEMPTED
                                .Range("H24").Value = FormatNumber(VATrdr("SEXPORT"), 2) 'ZERO RATED (EXPORT)
                                .Range("H25").Value = FormatNumber(VATrdr("S_IS"), 2) 'INTERSTATE SALE
                                .Range("H26").Value = FormatNumber(VATrdr("S_ISTF") + VATrdr("S_WISTF"), 2) 'TAX FREE SALE
                                .Range("H27").Value = FormatNumber(0, 2) 'SALE RETURN DISCOUNT  ?
                                .Range("H28").Value = FormatNumber(VATrdr("S_TX"), 2) 'TAX ELEMENTS
                                .Range("H29").Value = FormatNumber(0, 2)
                                .Range("H30").Value = FormatNumber(VATrdr("S_CHARG"), 2)
                                ' .Range("H31").Value = 'NET SALE AUTO FILLED
                                '==S.NO.2 PURCHASE DETAILS 
                                .Range("H36").Value = FormatNumber(VATrdr("PGROSS"), 2) 'GROSS
                                .Range("H37").Value = FormatNumber(VATrdr("PIMPORT"), 2) 'IMPORT OUT SIDE INDIA
                                .Range("H38").Value = FormatNumber(0, 2) ' 
                                .Range("H39").Value = FormatNumber(VATrdr("P_WISEXEMP") + VATrdr("P_ISEXEMP"), 2) 'EXEMPTED
                                .Range("H40").Value = FormatNumber(VATrdr("S_ISTF") + VATrdr("S_WISTF"), 2) 'TAX FREE PURCHASE
                                .Range("H41").Value = FormatNumber(0, 2) 'PURCHASE FROM OTHER THAN TAXABLE PERSON ?
                                .Range("H42").Value = FormatNumber(0, 2) 'PURCHASE H FORM ?
                                .Range("H43").Value = FormatNumber(0, 2) 'PURCHASE U/S 19(1) AND 20  ?
                                .Range("H44").Value = FormatNumber(0, 2) 'PURCHASE U/S 13(5) ?
                                .Range("H45").Value = FormatNumber(0, 2) 'PURCHASE RETURN DISCOUNT  ?
                                .Range("H46").Value = FormatNumber(0, 2) 'OTHER S
                                '.Range("H47").Value = NET PURCHASE AUTO FILLED

                                '==S.NO.3 OUTPUT TAX
                                .Range("H51").Value = FormatNumber(0, 2) '
                                .Range("H52").Value = FormatNumber(0, 2) '
                                .Range("H53").Value = FormatNumber(0, 2) '
                                '.Range("H54").Value = FormatNumber(0, 2) 'AUTO FILLED

                                '==S.NO.4 INPUT TAX CREDIT ON ACTUAL BASIS
                                .Range("H57").Value = FormatNumber(0, 2) '
                                .Range("H58").Value = FormatNumber(0, 2) '
                                .Range("H59").Value = FormatNumber(0, 2) '
                                .Range("H60").Value = FormatNumber(0, 2) '
                                .Range("H61").Value = FormatNumber(0, 2) '
                                .Range("H62").Value = FormatNumber(0, 2) '
                                .Range("H63").Value = FormatNumber(0, 2) '
                                ' .Range("H64").Value = FormatNumber(0, 2) 'AUTO FILLED
                                .Range("H65").Value = FormatNumber(0, 2) '
                                .Range("H66").Value = FormatNumber(0, 2) '
                                .Range("H67").Value = FormatNumber(0, 2) '
                                .Range("H68").Value = FormatNumber(0, 2) '
                                .Range("H69").Value = FormatNumber(0, 2) '
                                .Range("H70").Value = FormatNumber(0, 2) '
                                ' .Range("H71").Value = FormatNumber(0, 2) 'AUTO FILLED
                                ' .Range("H72").Value = FormatNumber(0, 2) ' AUTO FILLED

                                '==S.NO.5 GOODS PURCHASE FROM EXEMPTED UNITS
                                .Range("H76").Value = FormatNumber(0, 2) '
                                .Range("H77").Value = FormatNumber(0, 2) '
                                .Range("H78").Value = FormatNumber(0, 2) '
                                .Range("H79").Value = FormatNumber(0, 2) '
                                .Range("H80").Value = FormatNumber(0, 2) '
                                .Range("H81").Value = FormatNumber(0, 2) '
                                .Range("H82").Value = FormatNumber(0, 2) '
                                .Range("H83").Value = FormatNumber(0, 2) '
                                .Range("H84").Value = FormatNumber(0, 2) '
                                ' .Range("H85").Value = FormatNumber(0, 2) ' AUTO FILLED

                                '==S.NO.5-A INPUT TAX CREDIT ON NOTIONAL BASIS
                                .Range("H88").Value = FormatNumber(0, 2) '
                                .Range("H89").Value = FormatNumber(0, 2) '
                                ' .Range("H90").Value = FormatNumber(0, 2) ' AUTO FILLED

                                '==S.NO.6 TAX PAYABLE/EXCESS INPUT TAX CREDIT
                                .Range("H93").Value = FormatNumber(0, 2) '
                                .Range("H94").Value = FormatNumber(0, 2) '
                                .Range("H95").Value = FormatNumber(0, 2) '
                                .Range("H96").Value = FormatNumber(0, 2) '
                                .Range("H97").Value = FormatNumber(0, 2) '
                                ' .Range("H98").Value = FormatNumber(0, 2) 'AUTO FILLED
                                '.Range("H99").Value = FormatNumber(0, 2) '
                                .Range("H100").Value = FormatNumber(0, 2) '
                                .Range("H101").Value = FormatNumber(0, 2) '
                                .Range("H102").Value = FormatNumber(0, 2) '
                                .Range("H103").Value = FormatNumber(0, 2) '
                                '.Range("H104").Value = FormatNumber(0, 2) '
                                .Range("H105").Value = FormatNumber(0, 2) '
                                .Range("H106").Value = FormatNumber(0, 2) '
                                .Range("H107").Value = FormatNumber(0, 2) '
                                ' .Range("H108").Value = FormatNumber(0, 2) '
                                .Range("H109").Value = FormatNumber(0, 2) '
                                .Range("H110").Value = FormatNumber(0, 2) '
                                .Range("H111").Value = FormatNumber(0, 2) '
                                .Range("H112").Value = FormatNumber(0, 2) '
                                .Range("H113").Value = FormatNumber(0, 2) '

                                '==S.NO.7 DETAIL OF TAX PAYMENT DURING THE RETURN PERIOD
                                'TO BE FILLED ON LINE MANUALLY

                                '==S.NO.8  FOR UNITS AVAILING EXEMPTION OR DEFFERMENT
                                ' TO BE CONSULT WITH LAYWER


                                '==S.NO.9 MISCELLANEOUS INFORMATION (WHEREEVER APPLICABLE)
                                .Range("H133").Value = FormatNumber(0, 2) '
                                .Range("H134").Value = FormatNumber(0, 2) '
                                .Range("H135").Value = FormatNumber(0, 2) '
                                .Range("H136").Value = FormatNumber(0, 2) '
                                .Range("H137").Value = FormatNumber(0, 2) '

                                'NAME
                                .Range("B139").Value = ""
                                'SIGNATURE
                                .Range("B140").Value = "sd/-"
                                'STATUS
                                .Range("F139").Value = CoOnrDesi.Trim
                                'DATE
                                .Range("F140").Value = Format(Today.Date, "dd/MM/yyyy")

                                '========WORKSHEET==========
                                'S.NO. BREAK UP OF TAXABLE SALES AND PURCHASE IN PUNJAB(EXCLUDING CAPITAL GOODS)
                                .Range("B151").Value = FormatNumber(VATrdr("sVAT1"), 2)
                                .Range("C151").Value = FormatNumber(VATrdr("sVAT1") * 1 / 100, 2)
                                .Range("B152").Value = FormatNumber(VATrdr("sVAT4"), 2)
                                .Range("C152").Value = FormatNumber(VATrdr("sVAT4") * 4 / 100, 2)
                                .Range("B153").Value = FormatNumber(VATrdr("sVAT8_8"), 2)
                                .Range("C153").Value = FormatNumber(VATrdr("sVAT8_8") * 8.8 / 100, 2)
                                .Range("B154").Value = FormatNumber(VATrdr("sVAT12_5"), 2)
                                .Range("C154").Value = FormatNumber(VATrdr("sVAT12_5") * 12.5 / 100, 2)
                                .Range("B155").Value = FormatNumber(VATrdr("sVAT20"), 2)
                                .Range("C155").Value = FormatNumber(VATrdr("sVAT20") * 20 / 100, 2)
                                .Range("B156").Value = FormatNumber(VATrdr("sVAT22"), 2)
                                .Range("C156").Value = FormatNumber(VATrdr("sVAT22") * 22 / 100, 2)
                                .Range("B157").Value = FormatNumber(VATrdr("sVAT27_5"), 2)
                                .Range("C157").Value = FormatNumber(VATrdr("sVAT27_5") * 27.5 / 100, 2)
                                .Range("B158").Value = FormatNumber(VATrdr("sVAT30"), 2)
                                .Range("C158").Value = FormatNumber(VATrdr("sVAT30") * 30 / 100, 2)
                                .Range("B159").Value = FormatNumber(VATrdr("sVATOTHR"), 2)
                                .Range("C159").Value = FormatNumber(VATrdr("sVATOTHRVAT"), 2)
                                '.Range("B160").Value = FormatNumber(0, 2)'AUTO FILLED
                                ' .Range("C160").Value = FormatNumber(0, 2)'AUTO FILLED

                                .Range("D151").Value = FormatNumber(VATrdr("pVAT1"), 2)
                                .Range("G151").Value = FormatNumber(VATrdr("pVAT1") * 1 / 100, 2)
                                .Range("D152").Value = FormatNumber(VATrdr("pVAT4"), 2)
                                .Range("G152").Value = FormatNumber(VATrdr("pVAT4") * 4 / 100, 2)
                                .Range("D153").Value = FormatNumber(VATrdr("pVAT8_8"), 2)
                                .Range("G153").Value = FormatNumber(VATrdr("pVAT8_8") * 8.8 / 100, 2)
                                .Range("D154").Value = FormatNumber(VATrdr("pVAT12_5"), 2)
                                .Range("G154").Value = FormatNumber(VATrdr("pVAT12_5") * 12.5 / 100, 2)
                                .Range("D155").Value = FormatNumber(VATrdr("pVAT20"), 2)
                                .Range("G155").Value = FormatNumber(VATrdr("pVAT20") * 20 / 100, 2)
                                .Range("D156").Value = FormatNumber(VATrdr("pVAT22"), 2)
                                .Range("G156").Value = FormatNumber(VATrdr("pVAT22") * 22 / 100, 2)
                                .Range("D157").Value = FormatNumber(VATrdr("pVAT27_5"), 2)
                                .Range("G157").Value = FormatNumber(VATrdr("pVAT27_5") * 27.5 / 100, 2)
                                .Range("D158").Value = FormatNumber(VATrdr("pVAT30"), 2)
                                .Range("G158").Value = FormatNumber(VATrdr("pVAT30") * 30 / 100, 2)
                                .Range("D159").Value = FormatNumber(VATrdr("pVATOTHR"), 2)
                                .Range("G159").Value = FormatNumber(VATrdr("pVATOTHRVAT"), 2)
                                '.Range("D160").Value = FormatNumber(0, 2)'AUTO FILLED
                                ' .Range("G160").Value = FormatNumber(0, 2)'AUTO FILLED
                                'S.NO. 2 BREAK UP OF GOODS SOLD UNDER WORKS CONTRACT
                                .Range("A164").Value = FormatNumber(0, 2)
                                .Range("A165").Value = FormatNumber(0, 2)
                                .Range("A166").Value = FormatNumber(0, 2)
                                .Range("A167").Value = FormatNumber(0, 2)
                                .Range("A168").Value = FormatNumber(0, 2)
                                .Range("A169").Value = FormatNumber(0, 2)
                                .Range("A170").Value = FormatNumber(0, 2)
                                .Range("A171").Value = FormatNumber(0, 2)
                                .Range("A172").Value = FormatNumber(0, 2)
                                .Range("A173").Value = FormatNumber(0, 2)
                                .Range("A174").Value = FormatNumber(0, 2)
                                .Range("B164").Value = FormatNumber(0, 2)
                                .Range("B165").Value = FormatNumber(0, 2)
                                .Range("B166").Value = FormatNumber(0, 2)
                                .Range("B167").Value = FormatNumber(0, 2)
                                .Range("B168").Value = FormatNumber(0, 2)
                                .Range("B169").Value = FormatNumber(0, 2)
                                .Range("B170").Value = FormatNumber(0, 2)
                                .Range("B171").Value = FormatNumber(0, 2)
                                .Range("B172").Value = FormatNumber(0, 2)
                                .Range("B173").Value = FormatNumber(0, 2)
                                .Range("B174").Value = FormatNumber(0, 2)
                                .Range("C164").Value = FormatNumber(0, 2)
                                .Range("C165").Value = FormatNumber(0, 2)
                                .Range("C166").Value = FormatNumber(0, 2)
                                .Range("C167").Value = FormatNumber(0, 2)
                                .Range("C168").Value = FormatNumber(0, 2)
                                .Range("C169").Value = FormatNumber(0, 2)
                                .Range("C170").Value = FormatNumber(0, 2)
                                .Range("C171").Value = FormatNumber(0, 2)
                                .Range("C172").Value = FormatNumber(0, 2)
                                .Range("C173").Value = FormatNumber(0, 2)
                                .Range("C174").Value = FormatNumber(0, 2)
                                .Range("D164").Value = FormatNumber(0, 2)
                                .Range("D165").Value = FormatNumber(0, 2)
                                .Range("D166").Value = FormatNumber(0, 2)
                                .Range("D167").Value = FormatNumber(0, 2)
                                .Range("D168").Value = FormatNumber(0, 2)
                                .Range("D169").Value = FormatNumber(0, 2)
                                .Range("D170").Value = FormatNumber(0, 2)
                                .Range("D171").Value = FormatNumber(0, 2)
                                .Range("D172").Value = FormatNumber(0, 2)
                                .Range("D173").Value = FormatNumber(0, 2)
                                .Range("D174").Value = FormatNumber(0, 2)
                                .Range("F164").Value = FormatNumber(0, 2)
                                .Range("F165").Value = FormatNumber(0, 2)
                                .Range("F166").Value = FormatNumber(0, 2)
                                .Range("F167").Value = FormatNumber(0, 2)
                                '.Range("F168").Value = FormatNumber(0, 2)
                                '.Range("F169").Value = FormatNumber(0, 2)
                                '.Range("F170").Value = FormatNumber(0, 2)
                                '.Range("F171").Value = FormatNumber(0, 2)
                                '.Range("F172").Value = FormatNumber(0, 2)
                                '.Range("F173").Value = FormatNumber(0, 2)
                                '.Range("F174").Value = FormatNumber(0, 2)
                                .Range("G164").Value = FormatNumber(0, 2)
                                .Range("G165").Value = FormatNumber(0, 2)
                                .Range("G166").Value = FormatNumber(0, 2)
                                .Range("G167").Value = FormatNumber(0, 2)
                                .Range("G168").Value = FormatNumber(0, 2)
                                .Range("G169").Value = FormatNumber(0, 2)
                                .Range("G170").Value = FormatNumber(0, 2)
                                .Range("G171").Value = FormatNumber(0, 2)
                                .Range("G172").Value = FormatNumber(0, 2)
                                .Range("G173").Value = FormatNumber(0, 2)
                                '.Range("G174").Value = FormatNumber(0, 2)
                                'S.NO. 3 BREAK UP OF ZERO RATED SALES
                                .Range("C178").Value = FormatNumber(0, 2)
                                .Range("C179").Value = FormatNumber(0, 2)
                                .Range("D178").Value = FormatNumber(0, 2)
                                .Range("D179").Value = FormatNumber(0, 2)
                                .Range("E178").Value = FormatNumber(0, 2)
                                .Range("E179").Value = FormatNumber(0, 2)
                                .Range("G178").Value = FormatNumber(0, 2)
                                .Range("G179").Value = FormatNumber(0, 2)
                                'S.NO. PRIOR PERIOD ADJUSTMENTS
                                .Range("C183").Value = FormatNumber(0, 2)
                                .Range("C184").Value = FormatNumber(0, 2)
                                .Range("C185").Value = FormatNumber(0, 2)
                                .Range("C186").Value = FormatNumber(0, 2)
                                ' .Range("C187").Value = FormatNumber(0, 2)

                                .Range("D183").Value = FormatNumber(0, 2)
                                .Range("D184").Value = FormatNumber(0, 2)
                                .Range("D185").Value = FormatNumber(0, 2)
                                .Range("D186").Value = FormatNumber(0, 2)
                                ' .Range("D187").Value = FormatNumber(0, 2)

                                .Range("F183").Value = FormatNumber(0, 2)
                                .Range("F184").Value = FormatNumber(0, 2)
                                .Range("F185").Value = FormatNumber(0, 2)
                                .Range("F186").Value = FormatNumber(0, 2)
                                '.Range("F187").Value = FormatNumber(0, 2)

                                .Range("H183").Value = FormatNumber(0, 2)
                                .Range("H184").Value = FormatNumber(0, 2)
                                .Range("H185").Value = FormatNumber(0, 2)
                                .Range("H186").Value = FormatNumber(0, 2)
                                ' .Range("H187").Value = FormatNumber(0, 2)

                                'S.NO. ANY OTHER ADJUSTMENT (PLEASE SPECIFY)
                                .Range("A190").Value = FormatNumber(0, 2)
                                ''.Range("B190").Value = FormatNumber(0, 2)

                            End With
                        End While
                        '--------

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    Finally
                        VATcmd.Dispose()
                        VATrdr.Close()
                    End Try

                Case 2 'VAT 16
                    AppExcl.Workbooks.Open("E:\Data from home pc 01012208\My Projects after vis\FinAcct_Master\Finact_MASTER\FinAcct\bin\x86\Debug\VAT FORMS\VAT16.xls")

                Case 3 'VAT 18
                    AppExcl.Workbooks.Open("E:\Data from home pc 01012208\My Projects after vis\FinAcct_Master\Finact_MASTER\FinAcct\bin\x86\Debug\VAT FORMS\PVAT-18-100.xls")
                Case 4 'VAT 19
                    AppExcl.Workbooks.Open("E:\Data from home pc 01012208\My Projects after vis\FinAcct_Master\Finact_MASTER\FinAcct\bin\x86\Debug\VAT FORMS\PVAT-19-100.xls")
                Case 5 'VAT 23
                    AppExcl.Workbooks.Open("E:\Data from home pc 01012208\My Projects after vis\FinAcct_Master\Finact_MASTER\FinAcct\bin\x86\Debug\VAT FORMS\PVAT-23-100.xls")
                Case 6 'VAT 24
                    AppExcl.Workbooks.Open("E:\Data from home pc 01012208\My Projects after vis\FinAcct_Master\Finact_MASTER\FinAcct\bin\x86\Debug\VAT FORMS\PVAT-24-100.xls")

            End Select

            With AppExcl
                .Visible = True
            End With
            ' ''AppExcl.Workbooks.Close()
            ' ''AppExcl.Quit()
            ' ''AppExcl.Workbooks.Item(1).SaveAs("C:\Abc.xlsx", Text, , , False, , XlSaveAsAccessMode.xlNoChange, , , , , )
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            x_VAT_Forms_xFillSalePurTable("Finact_Rpt_VAT_Saleentry_FillTable", Me.DtpVAT1.Value.Date, Me.DtpVAT2.Value.Date)
            x_VAT_Forms_xFillSalePurTable("Finact_Rpt_VAT_Purentry_FillTable", Me.DtpVAT1.Value.Date, Me.DtpVAT2.Value.Date)
            CallVatForm()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnPerd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPerd.Click
        Try
            xCall_LinkFrm(FrmPirdMstr, Me.CmbxPerd)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPerd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPerd.GotFocus
        Try
            If xCmbxRefresh = True Then
                Fill_Combobox("Perdid", "PerdName", "Finact_PerdMstr", "PerdDelStatus", CInt(1), Me.CmbxPerd)
            End If
            Me.CmbxPerd.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPerd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxPerd.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxPerd_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPerd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPerd.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxPerd) = True Then
                If Me.CmbxPerd.SelectedIndex = 0 Then
                    xFillSelRec(Me.CmbxPerd.SelectedValue)
                End If
                Me.BtnOk.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFillSelRec(ByVal xPerdid As Integer)
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            VATcmd = New SqlCommand("Finact_PerdMstr_Select", FinActConn1)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATcmd.Parameters.AddWithValue("@PerdId", CInt(xPerdid))
            VATrdr = VATcmd.ExecuteReader
            While VATrdr.Read
                If VATrdr.IsDBNull(0) = False Then
                    Me.DtpVAT1.Value = VATrdr("perdFdt")
                    Me.DtpVAT2.Value = VATrdr("PerdTdt")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            VATcmd.Dispose()
            VATrdr.Close()
        End Try
    End Sub

    Private Sub CmbxPerd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPerd.SelectedIndexChanged
        Try
            If Me.CmbxPerd.SelectedIndex > 0 Then
                xFillSelRec(Me.CmbxPerd.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub BtnOk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.GotFocus
        Try
            Me.BtnOk.BackColor = Color.Blue

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Leave
        Try
            Me.BtnOk.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnExit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.GotFocus
        Try
            Me.BtnExit.BackColor = Color.Blue

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Leave
        Try
            Me.BtnExit.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
    Private Sub x_VAT_Forms_15_xFillSalePurTable()
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            VATcmd = New SqlCommand("Finact_Temp_VAT_SalePurEntry_Select", FinActConn1)
            VATcmd.CommandType = CommandType.StoredProcedure
            VATrdr = VATcmd.ExecuteReader
            While VATrdr.Read

            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            VATcmd.Dispose()
            VATrdr.Close()
        End Try
    End Sub
End Class
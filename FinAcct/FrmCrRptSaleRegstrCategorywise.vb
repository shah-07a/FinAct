Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCrRptSaleRegstrCategorywise
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd1 As SqlCommand
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader
    Dim CrRptSaleReg As Object
    Dim xVATRate As Double = 0

   
    Private Sub FrmCrRptSaleRegstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 10
            If Cl_TimeIndia = True Then
                Me.ChkRptLdgr.Checked = False
            Else
                Me.ChkRptLdgr.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpLdgr1, Me.DtpLdgr2)
            Fill_Combobox_DistinctSaleSplrid(Me.CmbxLdgr)
            Dim cond As String = "Sale"
            Select_2rec_where("spcatid", "spcatname", "spcattype", "FinactSalepurcatgry", CmbxTaxCat, cond, "SPCATDELSTATUS", CInt(1))
            Me.DtpLdgr1.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ChkLdgrAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLdgrAll.CheckedChanged
        Try
            If Me.ChkLdgrAll.CheckState = CheckState.Checked Then
                Me.CmbxLdgr.Enabled = False
                Me.CmbxLdgr.SelectedIndex = -1
            Else
                Me.CmbxLdgr.Enabled = True
                Me.CmbxLdgr.Focus()
                If Me.CmbxLdgr.SelectedIndex = -1 Then
                    Me.CmbxLdgr.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnRptVewLdgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click
        Try
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_SaleEntry()
            ' FrmMainMdi.MenuItem261.Enabled = False
            Handle_P_Bar(Me)
            Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 100, Screen.PrimaryScreen.WorkingArea.Height - 50)
            'Me.Height = 663
            'Me.Width = 1025
            Me.MaximizeBox = True
            Me.Top = 0
            Me.Left = 25
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_SaleEntry()
        Try
            If xCrRptSale = True Then
                CrRptSaleReg = New CrRptSaleRegstrSumry
            Else
                If Me.ChkRptType.CheckState = CheckState.Checked Then
                    CrRptSaleReg = New CrRptSaleSummryCatWise
                Else
                    CrRptSaleReg = New CrRptSaleRptHeadWise
                End If

            End If
            Dim xTaxVal As Integer = 0
            Dim xCustmrId As Integer
            Dim xxSelTaxCat, xxSelCustRange As Integer

            If Me.ChkBxTaxCat.CheckState = CheckState.Checked Then
                xxSelTaxCat = 0
                xTaxVal = 0
            Else
                xxSelTaxCat = 1
                xTaxVal = CInt(Me.CmbxTaxCat.SelectedValue)
            End If
            If Me.ChkLdgrAll.CheckState = CheckState.Checked Then
                xxSelCustRange = 0
                xCustmrId = 0
            Else
                xxSelCustRange = 1
                xCustmrId = CInt(Me.CmbxLdgr.SelectedValue)
            End If
            Fetch_Stock_Record_SelectedDateRange("FINACT_SALEENTRY_HEADWISE_SALES_SELECT", Me.CrRptSaleReg, Me.CrRptVewSaleRegstr, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date)
            SetExtraPramtoCrRpt()
            If Me.ChkRptLdgr.Checked = True Then
                CoprofileParamsRest_Adrs(Me.CrRptSaleReg, Me.CrRptVewSaleRegstr, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptSaleReg, Me.CrRptVewSaleRegstr, True, False, Me.DtpLdgr1, Me.DtpLdgr2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File :- " & Me.Name & " Sub/Function :- SelRecd_Fromtable_Ldgr, Line No. 234 ")
        End Try
    End Sub

    Private Sub ChkRptLdgr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptLdgr.CheckedChanged
        Try
            'If xCrRptSale = True Then
            '    CrRptSaleReg = New CrRptSaleRegstrSumry
            'Else
            '    If Me.ChkRptType.CheckState = CheckState.Checked Then
            '        CrRptSaleReg = New CrRptSaleSummryCatWise
            '    Else
            '        CrRptSaleReg = New CrRptSaleRptHeadWise
            '    End If

            'End If
            Me.BtnRptVewLdgr_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkBxTaxCat_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBxTaxCat.CheckedChanged
        Try
            If Me.ChkBxTaxCat.CheckState = CheckState.Checked Then
                Me.CmbxTaxCat.Enabled = False
                Me.CmbxTaxCat.SelectedIndex = -1
            Else
                Me.CmbxTaxCat.Enabled = True
                Me.ChkBxTaxCat.Focus()
                If Me.CmbxTaxCat.SelectedIndex = -1 Then
                    Me.CmbxTaxCat.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpLdgr1.KeyDown, ChkLdgrAll.KeyDown _
    , ChkRptLdgr.KeyDown, DtpLdgr2.KeyDown, ChkBxTaxCat.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetExtraPramtoCrRpt()
        Try
            Dim ParmVal1 As ParameterValues = New ParameterValues()
            Dim DisVal1 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal1.Value = 1
            ParmVal1.Add(DisVal1)
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand("Select cocst from finactcogatemstr", FinActConn)
            rdr = cmd.ExecuteReader
            While rdr.Read
                ParmVal1.AddValue(rdr(0))
            End While

            Me.CrRptSaleReg.DataDefinition.ParameterFields("vattin").ApplyCurrentValues(ParmVal1)
            CrRptVewSaleRegstr.ReportSource = CrRptSaleReg
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            rdr.Close()
        End Try
    End Sub

    Private Sub CmbxLdgr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxLdgr.GotFocus
        Try
            Me.CmbxLdgr.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxLdgr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxLdgr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxLdgr_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxLdgr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxLdgr.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxLdgr) = True Then
                Me.BtnRptVewLdgr.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRptVewLdgr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.GotFocus
        Try
            Me.BtnRptVewLdgr.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRptVewLdgr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Leave
        Try
            Me.BtnRptVewLdgr.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CmbxTaxCat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxTaxCat.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxTaxCat_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxTaxCat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxTaxCat.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxTaxCat) = True Then
                If Me.CmbxTaxCat.SelectedIndex = 0 Then
                    xVATRate = Fetch_vatrate(Me.CmbxTaxCat.SelectedValue)
                End If
                Me.ChkLdgrAll.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxTaxCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxTaxCat.SelectedIndexChanged
        Try
            If Me.CmbxTaxCat.SelectedIndex > 0 Then
                xVATRate = Fetch_vatrate(Me.CmbxTaxCat.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkRptType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptType.CheckedChanged
        Try
            If Me.ChkRptType.CheckState = CheckState.Checked Then
                Me.ChkRptType.Text = "Summarized"
            Else
                Me.ChkRptType.Text = "Detailed"
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
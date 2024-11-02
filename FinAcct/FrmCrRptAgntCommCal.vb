Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCrRptAgntCommCal
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
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 20, 124)
            Me.Top = 0
            Me.Left = 0
            If Cl_TimeIndia = True Then
                Me.ChkRptLdgr.Checked = False
            Else
                Me.ChkRptLdgr.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpLdgr1, Me.DtpLdgr2)
            Dim cond As String = "Sales Agent"
            Select_2rec_where("splrid", "splrname", "splrtype", "FinactSplrmstr", CmbxLdgr, cond, "SPLRDELSTATUS", CInt(1))

            Me.DtpLdgr1.Focus()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub BtnRptVewLdgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click
        Try
            If Me.TxtComm.Text = 0 Or Len(Me.TxtComm.Text.Trim) = 0 Then
                Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 20, 124)
                Exit Sub
            End If

            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_SaleEntry()
            Handle_P_Bar(Me)
            Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 100, Screen.PrimaryScreen.WorkingArea.Height - 50)
            Me.MaximizeBox = True
            Me.Top = 0
            Me.Left = 25
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_SaleEntry()
        Try
            If xCrRptSale = True Then
                ' CrRptSaleReg = New CrRptSaleRegstrSumry
            Else
                If Me.ChkRptType.CheckState = CheckState.Checked Then
                    CrRptSaleReg = New CrRptAgntCommCal
                Else
                    CrRptSaleReg = New CrRptAgntCommCal
                End If

            End If
            Fetch_Stock_Record_SelectedDateRange_with2SelITem("Finact_Rpt_Cal_AgentComm_Select", Me.CrRptSaleReg, Me.CrRptVewSaleRegstr, Me.DtpLdgr1.Value.Date, Me.DtpLdgr2.Value.Date, CInt(Me.CmbxLdgr.SelectedValue), CDbl(Me.TxtComm.Text))
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
            Me.BtnRptVewLdgr_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtComm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtComm.GotFocus
        Try
            Me.TxtComm.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpLdgr1.KeyDown, ChkRptLdgr.KeyDown, DtpLdgr2.KeyDown, TxtComm.KeyDown, ChkRptType.KeyDown
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
            'If FinActConn.State Then FinActConn.Close()
            'FinActConn.Open()
            'cmd = New SqlCommand("Select cocst from finactcogatemstr", FinActConn)
            'rdr = cmd.ExecuteReader
            'While rdr.Read
            '    ParmVal1.AddValue(rdr(0))
            'End While
            ParmVal1.AddValue(Me.CmbxLdgr.Text.Trim)
            Me.CrRptSaleReg.DataDefinition.ParameterFields("AgntName").ApplyCurrentValues(ParmVal1)
            CrRptVewSaleRegstr.ReportSource = CrRptSaleReg
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'cmd.Dispose()
            'rdr.Close()
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

                If Me.CmbxLdgr.SelectedIndex = 0 Then
                    Me.TxtComm.Text = CDbl(xDynamic_Fetch_Dbl("Finactsplrmstr", "Splrdiscom", "Splrid", CInt(Me.CmbxLdgr.SelectedValue)))
                End If
                Me.TxtComm.Focus()
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

    Private Sub TxtComm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtComm.Leave
        Try
            If Len(Me.TxtComm.Text) = 0 Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                Me.TxtComm.Focus()
                Exit Sub
            End If
            If xChk_numericValidation(Me.TxtComm) = True Then
                Exit Sub
            End If
            If Me.TxtComm.Text = 0 Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                Me.TxtComm.Focus()
                Exit Sub
            End If
            Me.TxtComm.Text = FormatNumber(Me.TxtComm.Text, 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxLdgr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxLdgr.SelectedIndexChanged
        Try
            If Me.CmbxLdgr.SelectedIndex > 0 Then
                Me.TxtComm.Text = CDbl(xDynamic_Fetch_Dbl("Finactsplrmstr", "Splrdiscom", "Splrid", CInt(Me.CmbxLdgr.SelectedValue)))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtComm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtComm.TextChanged

    End Sub
End Class
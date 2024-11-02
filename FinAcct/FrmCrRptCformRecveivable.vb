Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCrRptCformRecveivable
    Dim CFcmd As SqlCommand
    Dim CFrdr As SqlDataReader
    Dim CFcmd1 As SqlCommand
    Dim CrRptCF As New CrRptCformReceivable
    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If Me.BtnOk.Text = "&OK" Then
                If Me.ChkBx1.CheckState = CheckState.Unchecked And Me.CmbxCForm.SelectedIndex = -1 Then Exit Sub
                Me.BtnOk.Text = "&CANCEL"
                Me.CmbxCForm.Enabled = False
                Me.ChkBx1.Enabled = False
                Me.DtpFrom.Enabled = False
                Me.DtpTo.Enabled = False
                Me.ChkRptLdgr.Enabled = False

                Handle_P_Bar_Part_I(Me)
                SelRecd_Fromtable_Ldgr()
                Handle_P_Bar(Me)
                Me.Size = New System.Drawing.Point(900, 675)
                Me.Top = 0
                Me.Left = 0
            Else
                Me.BtnOk.Text = "&OK"
                Me.Size = New System.Drawing.Point(900, 117)
                Me.CmbxCForm.Enabled = True
                Me.ChkBx1.Enabled = True
                Me.DtpFrom.Enabled = True
                Me.DtpTo.Enabled = True
                Me.ChkRptLdgr.Enabled = True
                Me.DtpFrom.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.GotFocus
        Try
            Me.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Leave
        Try
            Me.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmCformRecveivable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Size = New System.Drawing.Point(900, 124)
            If Cl_TimeIndia = True Then
                Me.ChkRptLdgr.Checked = False
            Else
                Me.ChkRptLdgr.Checked = True
            End If
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpFrom, Me.DtpTo)
            Fill_Combobox_Cforms()
            Me.DtpFrom.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCForm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCForm.GotFocus
        Try
            Me.CmbxCForm.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCForm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxCForm_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCForm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCForm.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxCForm) = True Then
                Me.BtnOk.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxCForm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxCForm.SelectedIndexChanged
        Try
            If Me.CmbxCForm.SelectedIndex > 0 Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkBx1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBx1.CheckedChanged
        Try
            If Me.ChkBx1.CheckState = CheckState.Checked Then
                Me.CmbxCForm.Enabled = False
                Me.CmbxCForm.SelectedIndex = -1
            Else
                Me.CmbxCForm.Enabled = True
                Me.CmbxCForm.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_Ldgr()
        Try
            Dim xIndx As Integer = 0
            Dim xSPLR As Integer = 0
            If Me.ChkBx1.CheckState = CheckState.Checked Then
                xIndx = 0
                xSPLR = 0
            Else
                xSPLR = Me.CmbxCForm.SelectedValue
                xIndx = 1
            End If
            Fetch_SalePur_Record_SelectedDateRange_withSelITems_and_Indx("Finact_SALEENTRY_CFORM_RECEIVABLE_Select", _
                                                                         Me.CrRptCF, Me.CrRptVewCform, Me.DtpFrom.Value.Date, Me.DtpTo.Value.Date, xSPLR, xIndx)
            SetExtraPramtoCrRpt()
            If Me.ChkRptLdgr.Checked = True Then
                CoprofileParamsRest_Adrs(Me.CrRptCF, Me.CrRptVewCform, True, True, Me.DtpFrom, Me.DtpTo)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptCF, Me.CrRptVewCform, True, False, Me.DtpFrom, Me.DtpTo)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SetExtraPramtoCrRpt()
        Try
            Dim ParmVal1 As ParameterValues = New ParameterValues()
            Dim DisVal1 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal1.Value = 1
            Dim ParmVal2 As ParameterValues = New ParameterValues()
            Dim DisVaL2 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVaL2.Value = 1

            ParmVal1.Add(DisVal1)
            ParmVal1.Add(DisVaL2)

            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            CFcmd = New SqlCommand("FINACT_Rpt_PARTYADRS_Select", FinActConn)
            CFcmd.CommandType = CommandType.StoredProcedure
            CFcmd.Parameters.AddWithValue("@Pid", CInt(Me.CmbxCForm.SelectedValue))
            CFrdr = CFcmd.ExecuteReader
            If Me.ChkBx1.CheckState = CheckState.Unchecked Then
                While CFrdr.Read
                    ParmVal1.AddValue(CFrdr("ADRS"))
                    ParmVal2.AddValue(CFrdr("CTY"))
                End While
            Else
                ParmVal1.AddValue("----------------------------------")
                ParmVal2.AddValue("----------------------------------")
            End If
            Me.CrRptCF.DataDefinition.ParameterFields("PRMADRS1").ApplyCurrentValues(ParmVal1)
            Me.CrRptCF.DataDefinition.ParameterFields("PRMADRS2").ApplyCurrentValues(ParmVal2)
            CrRptVewCform.ReportSource = CrRptCF
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CFcmd.Dispose()
            CFrdr.Close()
        End Try
    End Sub

    Private Sub ALLCONT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkBx1.KeyDown, ChkRptLdgr.KeyDown _
    , DtpFrom.KeyDown, DtpTo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub
 
    Private Sub Fill_Combobox_Cforms()
        Dim xStr As String = "FINACT_Rpt_CForm_FILLCMBX_Select"
        dtaset = New DataSet
        dtaset.Tables.Clear()
        Try
            CFcmd = New SqlCommand(xStr, FinActConn1)
            CFcmd.CommandType = CommandType.StoredProcedure
            CFcmd.Parameters.AddWithValue("@DtF", Me.DtpFrom.Value.Date)
            CFcmd.Parameters.AddWithValue("@DtT", Me.DtpTo.Value.Date)
          
            SqlAdptr = New SqlDataAdapter(CFcmd)
            dtaset = New DataSet(CFcmd.CommandText)
            SqlAdptr.Fill(dtaset)
            Me.CmbxCForm.DataSource = dtaset.Tables(0)
            Me.CmbxCForm.ValueMember = "SPLRID"
            Me.CmbxCForm.DisplayMember = "SPLRNAME"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CFcmd.Dispose()
            SqlAdptr.Dispose()
        End Try
    End Sub
End Class

Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCrRptBOMDetails
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd1 As SqlCommand
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim BomDset As DataSet
    Dim BomAdptr As SqlDataAdapter
    Dim rdr2 As SqlDataReader
    Dim CrRptSbill As New CrRptBomDetails

  
    Private Sub FrmCrRptSaleBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, 103)
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpLdgr1, Me.DtpLdgr2)
            Fill_Combobox_where_cond("itmid", "itmname", "itmtype1", "FinactItmmstr", "ITMDELSTATUS", CInt(1), "BomItem", Me.CmbxLdgr)
            Me.ChkLdgrAll.Focus()
            If Cl_TimeIndia = True Then
                Me.ChkRptLdgr.Checked = False
            Else
                Me.ChkRptLdgr.Checked = True
            End If
        Catch ex As Exception

        End Try

    End Sub
   

    Private Sub ChkLdgrAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLdgrAll.CheckedChanged
        Try
            If Me.ChkLdgrAll.Checked = True Then
                Me.CmbxLdgr.Enabled = False
            Else
                Me.CmbxLdgr.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRptVewLdgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click
        Try
            Handle_P_Bar_Part_I(Me)
            SelRecd_Fromtable_BOMDetails()

            Handle_P_Bar(Me)
             Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, Screen.PrimaryScreen.WorkingArea.Height - 50)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelRecd_Fromtable_BOMDetails()
        Try
            Dim Stype As Integer
            If Me.ChkLdgrAll.Checked = True Then
                Stype = 0

            Else
                Stype = 1

            End If

            Dim Selact As String = Trim(Me.CmbxLdgr.SelectedValue)
            Fetch_BOMDetails_withSelITem("Finact_Rpt_BoMmstr_Detail_Select", Me.CrRptSbill, Me.CrRptVewBOMDetails, Selact, Stype)

            If Me.ChkRptLdgr.Checked = True Then
                CoprofileParamsRest_Adrs(Me.CrRptSbill, Me.CrRptVewBOMDetails, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptSbill, Me.CrRptVewBOMDetails, True, False, Me.DtpLdgr1, Me.DtpLdgr2)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ChkRptLdgr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRptLdgr.CheckedChanged
        Try
            Me.BtnRptVewLdgr_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkLdgrAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLdgrAll.GotFocus
        Try
            Me.ChkLdgrAll.BackColor = Color.Blue

        Catch ex As Exception

        End Try
    End Sub

    Private Sub aLLcONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkLdgrAll.KeyDown _
    , ChkRptLdgr.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub
    
    Private Sub Fetch_BOMDetails_withSelITem(ByVal xStr As String, ByVal xCrRpt As Object, ByVal CrRptVew As Object, ByVal xSelid As String, ByVal xIndx As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            cmd = New SqlCommand(xStr, FinActConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@xBomid", xSelid)
            cmd.Parameters.AddWithValue("@xindx", xIndx)
            BomDset = New DataSet(cmd.CommandText)
            bomAdptr = New SqlDataAdapter(cmd)
            BomAdptr.Fill(BomDset)
            xCrRpt.SetDataSource(BomDset.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptVew.ReportSource = xCrRpt

            cmd = Nothing
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
                CmbxLdgr_Leave(sender, e)
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

    Private Sub CmbxLdgr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxLdgr.SelectedIndexChanged

    End Sub

    Private Sub ChkLdgrAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLdgrAll.Leave
        Try
            Me.ChkLdgrAll.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
End Class

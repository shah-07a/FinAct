Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmCrRptStokReg_KblType
    Dim CrRptStokReg As Object
    Private Sub FrmCrRptStokReg_KblType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Size = New Point(890, 99)
            Set_Min_Max_Financial_Yrdate_OfDatetimepicker(Me.DtpLdgr1, Me.DtpLdgr2)
            If xItmStokOptn = 0 Then
                xFill_Cmbx_DynamicStorPro_where_Cond1("finactitmmstr_ITM_LIST_KBLTYPE_Select", CStr("Sale"), Me.CmbxItms, "Itmid", "ItmName", "@xItmType")
            ElseIf xItmStokOptn = 1 Then
                xFill_Cmbx_DynamicStorPro_where_Cond1("finactitmmstr_ITM_LIST_KBLTYPE_Select", CStr("Trading"), Me.CmbxItms, "Itmid", "ItmName", "@xItmType")
            End If
            Me.CmbxItms.SelectedIndex = -1
            Me.ChkBxAll.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ChkBxAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBxAll.CheckedChanged
        Try
            If Me.ChkBxAll.CheckState = CheckState.Checked Then
                Me.CmbxItms.SelectedIndex = -1
                Me.CmbxItms.Enabled = False
            Else
                Me.CmbxItms.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRptVewLdgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVewLdgr.Click
        Try
            If xItmStokOptn = 0 Then '===Finished items
                If Me.ChkBxAll.CheckState = CheckState.Checked Then
                    xxCrRpt(0, 0)
                Else
                    xxCrRpt(CInt(Me.CmbxItms.SelectedValue), 0)
                End If
            ElseIf xItmStokOptn = 1 Then '=== Trading items
                If Me.ChkBxAll.CheckState = CheckState.Checked Then
                    xxCrRpt(0, 1)
                Else
                    xxCrRpt(CInt(Me.CmbxItms.SelectedValue), 1)
                End If
            End If
            Me.Size = New Point(900, 630)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xxCrRpt(ByVal xSelId As Integer, ByVal xStokOptn As Integer)
        Try
            If xItmStokSumry = 0 Then '==DETAILED
                CrRptStokReg = New CrRptItmStokReg_KBL_Type
            ElseIf xItmStokSumry = 1 Then '==SUMMARIZED 
                CrRptStokReg = New CrRptItmStokRegSumry_KblType
            End If
            If xStokOptn = 0 Then
                Fetch_Stock_Record_SelectedDateRange_withSelITem("FinactSaleEntry_Rpt_FINISHED_STOCK_KBLTYPE_SELECT", Me.CrRptStokReg, Me.CrRptVewStokReg, Me.DtpLdgr1.Value, Me.DtpLdgr2.Value, xSelId)
            ElseIf xStokOptn = 1 Then
                Fetch_Stock_Record_SelectedDateRange_withSelITem("FinactSaleEntry_Rpt_TRADING_STOCK_KBLTYPE_SELECT", Me.CrRptStokReg, Me.CrRptVewStokReg, Me.DtpLdgr1.Value, Me.DtpLdgr2.Value, xSelId)
            End If
            CoprofileParamsRest_Adrs(Me.CrRptStokReg, Me.CrRptVewStokReg, True, True, Me.DtpLdgr1, Me.DtpLdgr2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
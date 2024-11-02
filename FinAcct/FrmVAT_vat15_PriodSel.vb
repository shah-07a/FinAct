Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVAT_vat15_PriodSel
    Dim VATcmd As SqlCommand
    Dim VATrdr As SqlDataReader

    Private Sub FrmVAT_vat15_PriodSel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            xOnExitClrAllValues()
            Fill_Combobox("Perdid", "PerdName", "Finact_PerdMstr", "PerdDelStatus", CInt(1), Me.CmbxPeriod)
            If xVAT_FlagPrd = True Then
                Me.DtpVAT1.Value = xVAT_DtF
                Me.DtpVAT2.Value = xVAT_DtT
                Me.CmbxPeriod.SelectedValue = xPeriodId
            End If
            Me.CmbxPeriod.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnPRDMSTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPRDMSTR.Click

        Try
            xCall_LinkFrm(FrmPirdMstr, Me.CmbxPeriod)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPeriod_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPeriod.Click
        Try
            Me.CmbxPeriod.DroppedDown = True
            If xCmbxRefresh = True Then
                Fill_Combobox("Perdid", "PerdName", "Finact_PerdMstr", "PerdDelStatus", CInt(1), Me.CmbxPeriod)
            End If
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

    Private Sub CmbxPeriod_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPeriod.GotFocus
        Try
            Me.CmbxPeriod.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPeriod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxPeriod.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxPeriod_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPeriod_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPeriod.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxPeriod) = True Then
                If Me.CmbxPeriod.SelectedIndex = 0 Then
                    xFillSelRec(Me.CmbxPeriod.SelectedValue)
                End If
                Me.BtnOK.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxPeriod.SelectedIndexChanged
        Try
            If Me.CmbxPeriod.SelectedIndex > 0 Then
                xFillSelRec(Me.CmbxPeriod.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Try
            xVAT_DtF = Me.DtpVAT1.Value
            xVAT_DtT = Me.DtpVAT2.Value
            xVAT_FlagPrd = True
            xPeriodId = Me.CmbxPeriod.SelectedValue
            xPrdName = Me.CmbxPeriod.Text.Trim
            Me.Cursor = Cursors.WaitCursor
            Dim FrmWrkCon As New FrmVAT_vat15_WrkContrct
            FrmWrkCon.MdiParent = FrmMainMdi
            FrmMainMdi.SplitContainer1.Panel2.Controls.Add(FrmWrkCon)
            FrmWrkCon.BringToFront()
            FrmWrkCon.Show()
            Me.Close()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnOK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.GotFocus, Btnext.GotFocus
        Try
            Me.BtnOK.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOK_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.Leave, Btnext.Leave
        Try
            BtnOK.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnext.Click
        Try
            xOnExitClrAllValues()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
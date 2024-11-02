Public Class FrmVewPrnt_ItmDependencies
    Dim CrRptItmDepen As New CrRptVewPrntItemDependency

    Private Sub FrmVewPrnt_ItmDependencies_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Fill_Combobox_WhereID_In("itmid", "itmName", "Finactitmmstr", Me.CmbxItemVew)
            Me.Top = 0
            Me.Left = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnItmVew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnItmVew.Click
        Try
            Handle_P_Bar_Part_I(Me)
            If Me.ChkbxAll.Checked = True Then
                Fetch_Stock_Record_SelectedItem("Finact_Check_Item_Dependencies", CrRptItmDepen, Me.CrRptVewItemDepen, 0)
            Else
                If Not Me.CmbxItemVew.SelectedIndex = -1 Then
                    Fetch_Stock_Record_SelectedItem("Finact_Check_Item_Dependencies", CrRptItmDepen, Me.CrRptVewItemDepen, Me.CmbxItemVew.SelectedValue)
                End If
            End If
            If Me.Chkinfo.Checked = True Then
                CoprofileParamsRest_Adrs(CrRptItmDepen, Me.CrRptVewItemDepen, False, True)
            Else
                CoprofileParamsRest_Adrs(CrRptItmDepen, Me.CrRptVewItemDepen, False, False)
            End If
            Handle_P_Bar(Me)

            Me.Width = 1020
            Me.Height = 650
        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub ChkbxAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbxAll.CheckedChanged
        Try
            If Me.ChkbxAll.Checked = True Then
                Me.CmbxItemVew.Enabled = False
            Else
                Me.CmbxItemVew.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkinfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkinfo.CheckedChanged
        Try
            Me.BtnItmVew_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub
End Class
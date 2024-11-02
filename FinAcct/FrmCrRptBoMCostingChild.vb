Imports CrystalDecisions
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCrRptBoMCostingChild
    Dim CrRptCmd As SqlCommand
    Dim CrRptDset As DataSet
    Dim CrRptAdptr As SqlDataAdapter
    Dim CrRptCmd1 As SqlCommand
    Dim CrRptDset1 As DataSet
    Dim CrRptAdptr1 As SqlDataAdapter
    Dim CrRptbc As New CrRptBOMCosting



    Private Sub FrmCrRptBoMCostingChild_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Top = 0
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 30, Screen.PrimaryScreen.WorkingArea.Height - 50)
            SelRecd_Fromtable_RptFromGridTempBomCosting_Select()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub SelRecd_Fromtable_RptFromGridTempBomCosting_Select()
        Try
            ' Fetch_Stock_Record("Finact_RptFromGrid_Temp_BomCosting_Select", Me.CrRptbc, Me.CrRptVewBomCost)
            Fetch_Stock_Record()
            If xCrptFlag = True Then
                CoprofileParamsRest_Adrs(Me.CrRptbc, Me.CrRptVewBomCost, True, True, Me.Dtp1, Me.Dtp2)
            Else
                CoprofileParamsRest_Adrs(Me.CrRptbc, Me.CrRptVewBomCost, True, False, Me.Dtp1, Me.Dtp2)
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CrRptVewBomCost_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrRptVewBomCost.Load

    End Sub
    Public Sub Fetch_Stock_Record()
        Try
            Dim xStr As String = "Finact_RptFromGrid_Temp_BomCosting_Select"
            CrRptCmd = New SqlCommand(xStr, FinActConn)
            CrRptCmd.CommandType = CommandType.StoredProcedure
            CrRptDset = New DataSet(CrRptCmd.CommandText)
            CrRptAdptr = New SqlDataAdapter(CrRptCmd)
            CrRptAdptr.Fill(CrRptDset)
            Me.CrRptbc.SetDataSource(CrRptDset.Tables(0))

            Dim xStr1 As String = "Finact_Rpt_Temp_Ovrhed_Select"
            CrRptCmd1 = New SqlCommand(xStr1, FinActConn1)
            CrRptCmd1.CommandType = CommandType.StoredProcedure
            CrRptDset1 = New DataSet(CrRptCmd1.CommandText)
            CrRptAdptr1 = New SqlDataAdapter(CrRptCmd1)
            CrRptAdptr1.Fill(CrRptDset1)
            CrRptbc.Subreports.Item("CrRptBomCostingSub1").SetDataSource(CrRptDset1.Tables(0))

            Me.CrRptVewBomCost.ReportSource = CrRptbc
            

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CrRptCmd.Dispose()
            CrRptCmd1.Dispose()

        End Try
    End Sub
End Class
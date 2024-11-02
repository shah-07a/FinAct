Imports System.Data
Imports System.Data.SqlClient
Public Class FrmTranAltrTptGrNo

    Private Sub FrmTranAltrTptGrNo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            xTptGRFill()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xTptGRFill()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            FinActCmd = New SqlCommand("SELECT Saleentid,Saleentvno,Saleentgrno  FROM FinactSaleEntry where sale_cat in('INTER STATE','INTER STATE TAX FREE') order by saleentid", FinActConn)
            FinActRdr = FinActCmd.ExecuteReader
            Me.DgTptGR.Rows.Clear()
            Dim xx As Integer = 0
            While FinActRdr.Read
                If FinActRdr.IsDBNull(0) = False Then
                    Me.DgTptGR.Rows.Add()
                    Me.DgTptGR.Rows(xx).Cells(0).Value = Trim(FinActRdr("Saleentvno"))
                    Me.DgTptGR.Rows(xx).Cells(1).Value = Trim(FinActRdr("Saleentgrno"))
                    Me.DgTptGR.Rows(xx).Cells(2).Value = CInt(FinActRdr("Saleentid"))
                    xx += 1
                End If

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
            FinActRdr.Close()
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If Me.DgTptGR.Rows.Count = 0 Then
                MsgBox("Invalid input!", MsgBoxStyle.Critical, Me.Text)
                Me.DgTptGR.Focus()
                Exit Sub
            End If


            If MessageBox.Show("Are you sure to update current session?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                xTptGrUpdate()
            Else
                Return
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xTptGrUpdate()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            For Each xR As DataGridViewRow In Me.DgTptGR.Rows
                FinActCmd = New SqlCommand("UPDATE  FinactSaleEntry SET Saleentgrno=@Saleentgrno where saleEntid=@Saleentid", FinActConn)
                FinActCmd.Parameters.AddWithValue("@Saleentgrno", Trim(xR.Cells(1).Value))
                FinActCmd.Parameters.AddWithValue("@SaleentId", CInt(xR.Cells(2).Value))
                FinActCmd.ExecuteNonQuery()
            Next
            MsgBox("Current session has been successfully updated.", MsgBoxStyle.Information, Me.Text)
            Me.DgTptGR.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FinActCmd.Dispose()
        End Try
    End Sub
End Class
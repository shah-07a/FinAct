Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmSaleItmRecdBackDetails
    Dim SBRcmd As SqlCommand
    Dim SBRrdr As SqlDataReader
    Dim SBRcmd1 As SqlCommand
    Dim SBRrdr1 As SqlDataReader
    Dim iT As String = ""
    Dim SaveFlag As Boolean

    Private Sub FrmSaleItmRecdBackDetails_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If SaveFlag = False Then
                If MessageBox.Show("You are going to close current page without saving any record. Are you sure to close?", "Page closing.....!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = False
                    Try
                        If FinActConn1.State Then FinActConn1.Close()
                        FinActConn1.Open()
                        SBRcmd1 = New SqlCommand("Finact_SBR_Ifcommandisunsuccess_2_Delete", FinActConn1)
                        SBRcmd1.CommandType = CommandType.StoredProcedure
                        SBRcmd1.Parameters.AddWithValue("@ConIdxx", SBRCurrId)
                        SBRcmd1.ExecuteNonQuery()
                    Catch ex1 As Exception
                        MsgBox(ex1.Message, MsgBoxStyle.Critical, "File Name:- " & Me.Text & "  Private Sub FrmSaleItmRecdBackDetails_FormClosing, Line No. 13")
                    Finally
                        SBRcmd1.Dispose()
                    End Try
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmSaleItmRecdBackDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 50
            Me.Left = 50
            SaveFlag = False
            fill_DgView(SBRItmId)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub fill_DgView(ByVal curitmid As Integer)
        Dim ic, ina As String
        Dim ii As Integer = 0
        ic = ""
        ina = ""
        Try
            SBRcmd = New SqlCommand("Select * from finact_bommstr where bomconcrnid=@Citmid order by bomid ", FinActConn)
            SBRcmd.Parameters.AddWithValue("@citmid", curitmid)
            SBRrdr = SBRcmd.ExecuteReader
            Dim x As Integer
            x = 0
            While SBRrdr.Read()
                If SBRrdr.HasRows = True Then
                    Try
                        SBRcmd1 = New SqlCommand("Select itmid,itmcode,itmname,itmtype from finactitmmstr where itmid=@itmid  ", FinActConn1)
                        SBRcmd1.Parameters.AddWithValue("@itmid", SBRrdr("bomconcrnitmid"))
                        SBRrdr1 = SBRcmd1.ExecuteReader
                        SBRrdr1.Read()
                        ii = Trim(SBRrdr1("itmid"))
                        ic = Trim(SBRrdr1("itmcode"))
                        ina = Trim(SBRrdr1("itmname"))
                        iT = Trim(SBRrdr1("itmtype"))
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        SBRcmd1.Dispose()
                        SBRrdr1.Close()
                    End Try
                    Me.DgSBRItems.Rows.Add()
                    Me.DgSBRItems.Rows(x).Cells(0).Value = (ic)
                    Me.DgSBRItems.Rows(x).Cells(1).Value = (ina)
                    Me.DgSBRItems.Rows(x).Cells(2).Value = FormatNumber(SBRrdr("bomitmqnty"), 4)
                    Me.DgSBRItems.Rows(x).Cells(3).Value = FormatNumber((SBRrdr("bomitmqnty") * SBRqnty) \ SBRrdr("bomitmratio"), 4)
                    Me.DgSBRItems.Rows(x).Cells(4).Value = FormatNumber(SBRrdr("bomitmrate"), 2)
                    Me.DgSBRItems.Rows(x).Cells(5).Value = FormatNumber(Me.DgSBRItems.Rows(x).Cells(3).Value * Me.DgSBRItems.Rows(x).Cells(4).Value, 2)
                    Me.DgSBRItems.Rows(x).Cells(6).Value = FormatNumber(0, 4)
                    Me.DgSBRItems.Rows(x).Cells(7).Value = FormatNumber(0, 4)
                    Me.DgSBRItems.Rows(x).Cells(8).Value = (SBRrdr("bomconcrnitmid"))
                    Me.DgSBRItems.Rows(x).Cells(9).Value = (iT)
                    Me.DgSBRItems.Rows(x).Cells(10).Value = (SBRrdr("bomitmratio"))


                    x += 1
                End If
            End While
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            SBRcmd.Dispose()
            SBRrdr.Close()
        End Try
    End Sub

    Private Sub DgSBRItems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSBRItems.CellEndEdit
        Try
            If e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
                Me.DgSBRItems.CurrentCell.ErrorText = ""
                Me.DgSBRItems.CurrentRow.Cells(6).Value = FormatNumber(Me.DgSBRItems.CurrentRow.Cells(6).Value, 4)
                Me.DgSBRItems.CurrentRow.Cells(7).Value = FormatNumber(Me.DgSBRItems.CurrentRow.Cells(7).Value, 4)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgSBRItems_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgSBRItems.CellValidating
        Try
            Dim Cr_Row As Integer = Me.DgSBRItems.Rows.Count '- 1
            If Cr_Row <> Me.DgSBRItems.CurrentRow.Index Then
                If e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
                    If Not Double.TryParse(e.FormattedValue, Nothing) Then
                        Me.DgSBRItems.CurrentCell.ErrorText = "Only Numbers are allowed"
                        e.Cancel = True
                    Else
                        Me.DgSBRItems.CurrentCell.ErrorText = ""
                        e.Cancel = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgSBRItems_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSBRItems.CellValueChanged
        Try
            Dim a, b As Double
            If Not (e.RowIndex) = -1 Then
                a = CDbl((Me.DgSBRItems.Rows(e.RowIndex).Cells(6).Value) + CDbl(Me.DgSBRItems.Rows(e.RowIndex).Cells(7).Value))
                b = CDbl((Me.DgSBRItems.Rows(e.RowIndex).Cells(3).Value))

                If a > b Then
                    Me.DgSBRItems.CurrentRow.Cells(6).ErrorText = "Excess Qnty"
                    Me.DgSBRItems.CurrentRow.Cells(7).ErrorText = "Excess Qnty"
                Else
                    Me.DgSBRItems.CurrentRow.Cells(6).ErrorText = ""
                    Me.DgSBRItems.CurrentRow.Cells(7).ErrorText = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File Name:- " & Me.Name & "Private Sub DgSBRItems_CellValueChanged, Line No. 103")

        End Try
    End Sub
    Private Function validate_input() As Boolean
        Try
            Dim CurIndx As Integer = 0
            For CurIndx = 0 To Me.DgSBRItems.RowCount - 1
                If Not Trim(Me.DgSBRItems.Rows(CurIndx).Cells(6).ErrorText) = "" Or Not Trim(Me.DgSBRItems.Rows(CurIndx).Cells(6).ErrorText) = "" Then
                    '  Exit For
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Function

    Private Function validate_QntyTotal() As Boolean
        Try
            Dim CurIndx As Integer = 0
            Dim a6 As Double = 0
            Dim a3 As Double = 0
            Dim a7 As Double = 0
            For CurIndx = 0 To Me.DgSBRItems.RowCount - 1
                a6 = CDbl(Me.DgSBRItems.Rows(CurIndx).Cells(6).Value)
                a7 = CDbl(Me.DgSBRItems.Rows(CurIndx).Cells(7).Value)
                a3 = CDbl(Me.DgSBRItems.Rows(CurIndx).Cells(3).Value)

                If (a6 + a7) > a3 Then
                    Me.DgSBRItems.Rows(CurIndx).DefaultCellStyle.BackColor = Color.Yellow
                    Return True
                ElseIf (a6 + a7) < a3 Then
                    Me.DgSBRItems.Rows(CurIndx).DefaultCellStyle.BackColor = Color.Yellow
                    Return True
                Else
                    Me.DgSBRItems.Rows(CurIndx).DefaultCellStyle.BackColor = Color.White
                End If
            Next
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Function

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            '+++Check if there is an error
            If Trim(Me.BtnSave.Text) = "&Save" Then
                If validate_input() = True Then
                    MsgBox("Invalid Input! Total of Column no 7 and 8 should be equal to total of column of 4 ", MsgBoxStyle.Critical, "File :- " & Me.Name)
                    Exit Sub
                End If

                '+++ Check Quantity Total 
                If validate_QntyTotal() = True Then
                    MsgBox("Invalid Input! Total of Column no 7 and 8 should be equal to total of column of 4 ", MsgBoxStyle.Critical, "File :- " & Me.Name)
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure to save current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    SBRItemsSave()

                Else
                    SaveFlag = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnext.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCncl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCncl.Click

        Try
            Dim CurIndx As Integer = 0
            For CurIndx = 0 To Me.DgSBRItems.RowCount - 1
                Me.DgSBRItems.Rows(CurIndx).Cells(6).Value = FormatNumber(0, 4)
                Me.DgSBRItems.Rows(CurIndx).Cells(7).Value = FormatNumber(0, 4)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub
    Private Sub SBRItemsSave()
        Try

            Dim DgCntr As Integer
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            For DgCntr = 0 To Me.DgSBRItems.Rows.Count - 1
                Dim Qnty6 As Double = CDbl(Me.DgSBRItems.Rows(DgCntr).Cells(6).Value)
                Dim Qnty7 As Double = CDbl(Me.DgSBRItems.Rows(DgCntr).Cells(7).Value)
                If Qnty6 > 0 Then
                    SBRcmd = New SqlCommand("Finact_SBR_FirstQltyOtherThanBom_Details_Insert", FinActConn)
                    SBRcmd.CommandType = CommandType.StoredProcedure
                    SBRcmd.Parameters.AddWithValue("@dPurentconcrnid", (SBRCurrId))
                    SBRcmd.Parameters.AddWithValue("@dPurent_con_dpurid", 0)
                    SBRcmd.Parameters.AddWithValue("@dPurentitmid", (Me.DgSBRItems.Rows(DgCntr).Cells(8).Value))
                    SBRcmd.Parameters.AddWithValue("@dPurentqnty", (Me.DgSBRItems.Rows(DgCntr).Cells(6).Value))
                    SBRcmd.Parameters.AddWithValue("@dPurentitmrate", (Me.DgSBRItems.Rows(DgCntr).Cells(4).Value))
                    SBRcmd.Parameters.AddWithValue("@dPurentlocid", 0)
                    SBRcmd.Parameters.AddWithValue("@dPurent_Isprod", 2)
                    SBRcmd.ExecuteNonQuery()
                    SBRcmd.Dispose()
                End If
                If Qnty7 > 0 Then
                    SBRcmd = New SqlCommand("Finact_SaleItemBackRecdEntry_Details_Insert", FinActConn1)
                    SBRcmd.CommandType = CommandType.StoredProcedure
                    SBRcmd.Parameters.AddWithValue("@d_SBR_entconcrnid", (SBRCurrId))
                    SBRcmd.Parameters.AddWithValue("@d_SBR_ent_con_d_SBR_id", 0)
                    SBRcmd.Parameters.AddWithValue("@d_SBR_entitmid", (Me.DgSBRItems.Rows(DgCntr).Cells(8).Value))
                    SBRcmd.Parameters.AddWithValue("@d_SBR_entqnty", (Me.DgSBRItems.Rows(DgCntr).Cells(7).Value))
                    SBRcmd.Parameters.AddWithValue("@d_SBR_entitmrate", (Me.DgSBRItems.Rows(DgCntr).Cells(4).Value))
                    SBRcmd.Parameters.AddWithValue("@d_SBR_entlocid", 0)
                    SBRcmd.ExecuteNonQuery()
                    SBRcmd.Dispose()
                End If

            Next
            MsgBox("Current Record Has Been Saved Successfully", MsgBoxStyle.Information, "Save Record")
            SaveFlag = True
            Me.Close()
            FrmShow_flag(23) = True
        Catch ex As Exception
            SaveFlag = False
            FrmShow_flag(23) = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "File Name:- " & Me.Text & "  Private Sub SBRItemsSave, Line No. 212")
            Try
                SBRcmd1 = New SqlCommand("Finact_SBR_Ifcommandisunsuccess_1_Delete", FinActConn1)
                SBRcmd1.CommandType = CommandType.StoredProcedure
                SBRcmd1.Parameters.AddWithValue("@ConIdxx", SBRCurrId)
                SBRcmd1.ExecuteNonQuery()
            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.Critical, "File Name:- " & Me.Text & "  Private Sub SBRItemsSave, Line No. 255")
            Finally
                SBRcmd1.Dispose()
            End Try
        Finally

        End Try
       
    End Sub
End Class
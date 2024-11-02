Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmHintQues
    Dim Hint_com As SqlCommand
    Private Sub BtnQExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnQExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnQSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnQSave.Click
        Try
            If Trim(Me.TxtHQues.Text) = "" Then
                MsgBox("Invalid Input!", MsgBoxStyle.Critical, "Empty Text ???")
                Me.TxtHQues.Focus()
                Exit Sub
            End If
            Hint_com = New SqlCommand("Finact_HintQues_Insert", FinActConn)
            Hint_com.CommandType = CommandType.StoredProcedure
            Hint_com.Parameters.AddWithValue("@hques", Trim(Me.TxtHQues.Text))
            Hint_com.ExecuteNonQuery()
            MsgBox("Current Record Has Been Successfully Saved", MsgBoxStyle.Information, "HintQuestion?????")
           
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Trim(Me.TxtHQues.Text) <> "" Then
                Hint_com.Dispose()
                Me.TxtHQues.Text = ""
                Me.TxtHQues.Focus()
            End If
        End Try
    End Sub

    Private Sub TxtHQues_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtHQues.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtHQues_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHQues.TextChanged

    End Sub

    Private Sub FrmHintQues_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.TxtHQues.Focus()
        Catch ex As Exception

        End Try
    End Sub
End Class
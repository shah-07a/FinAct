Imports System.Data
Imports System.Data.SqlClient
Public Class FrmCostOvrHeds
    Dim OHcmd As SqlCommand
    Dim OHrdr As SqlDataReader
    Dim SelOhId As Integer = 0
    Private Sub BtnFnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd.Click
        Try
            If Me.BtnFnd.Text = "&Find" Then
                Me.Height = 425
                Me.Width = 855
                xFill_LstVewOhFnd()
                Me.BtnFnd.Text = "&Cancel"
                Me.BtnSave.Text = "&Update"
                Me.LstVewOhFnd.Enabled = True
                Me.LstVewOhFnd.Visible = True
                Me.LstVewOhFnd.Focus()
                Me.LstVewOhFnd.Items(0).Selected = True
            ElseIf Me.BtnFnd.Text = "&Cancel" Then
                Me.Height = 190
                Me.Width = 535
                Me.LstVewOhFnd.Enabled = False
                Me.LstVewOhFnd.Visible = False
                Me.TxtOH.Enabled = True
                Me.TxtDfltVal.Text = 0
                Me.TxtOH.Clear()
                Me.TxtOH.Focus()
                Me.BtnFnd.Text = "&Find"
                Me.BtnSave.Text = "&Save"

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExt.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Me.BtnSave.Text = "&Save" Then

                If Me.TxtOH.Text.Trim = "" Then
                    MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure to save this record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    save_UoMmst()
                Else
                    Return
                End If
            ElseIf Me.BtnSave.Text = "&Update" Then
                If MessageBox.Show("Are you sure to update this record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Update_UoMmst()
                    Me.BtnSave.Text = "&Save"
                Else
                    Return
                End If
               
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmUoMmstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 25
            Me.Height = 190
            Me.Width = 535
            Me.TxtOH.Focus()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub save_UoMmst()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            OHcmd = New SqlCommand("Finact_OvrHedMstr_Insert", FinActConn)
            OHcmd.CommandType = CommandType.StoredProcedure
            OHcmd.Parameters.AddWithValue("@OhName", Trim(Me.TxtOH.Text))
            OHcmd.Parameters.AddWithValue("@Ohamt", CDbl(Me.TxtDfltVal.Text))
            OHcmd.Parameters.AddWithValue("@Ohadusrid", Current_UsrId)
            OHcmd.Parameters.AddWithValue("@Ohaddt", Now)
            OHcmd.ExecuteNonQuery()
            MsgBox("Current record has been successfully saved.", MsgBoxStyle.Information, Me.Text)
            Me.TxtOH.Clear()
            Me.TxtDfltVal.Text = 0
            Me.TxtOH.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            OHcmd.Dispose()
        End Try
    End Sub
    Private Sub xFill_LstVewOhFnd()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            OHcmd = New SqlCommand("Finact_OvrHedmstr_Select", FinActConn)
            OHcmd.CommandType = CommandType.StoredProcedure
            OHrdr = OHcmd.ExecuteReader
            Me.LstVewOhFnd.Items.Clear()
            Dim xls As ListViewItem
            While OHrdr.Read
                If OHrdr.IsDBNull(0) = False Then
                    xls = Me.LstVewOhFnd.Items.Add(Trim(OHrdr("Ohname")))
                    xls.SubItems.Add(CDbl(OHrdr("Ohamt")))
                    xls.SubItems.Add(OHrdr("Ohid"))
                End If
            End While
        Catch ex As Exception
        Finally
            OHcmd.Dispose()
            OHrdr.Close()
        End Try

    End Sub
    Private Sub Update_UoMmst()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            OHcmd = New SqlCommand("Finact_OvrHedMstr_Update", FinActConn)
            OHcmd.CommandType = CommandType.StoredProcedure
            OHcmd.Parameters.AddWithValue("@OhId", SelOhId)
            OHcmd.Parameters.AddWithValue("@Ohamt", CDbl(Me.TxtDfltVal.Text))
            OHcmd.Parameters.AddWithValue("@OhEdtusrid", Current_UsrId)
            OHcmd.Parameters.AddWithValue("@OhEdtdt", Now)
            OHcmd.ExecuteNonQuery()
            MsgBox("Current record has been successfully updated.", MsgBoxStyle.Information, Me.Text)
            Me.TxtOH.Clear()
            Me.TxtDfltVal.Text = 0
            Me.TxtOH.Enabled = True
            Me.TxtOH.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            OHcmd.Dispose()
        End Try
    End Sub

    Private Sub LstVewOhFnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewOhFnd.DoubleClick
        Try
            If Me.LstVewOhFnd.SelectedItems.Count > 0 Then
                Me.TxtOH.Text = Trim(Me.LstVewOhFnd.SelectedItems(0).SubItems(0).Text)
                Me.TxtDfltVal.Text = FormatNumber(Me.LstVewOhFnd.SelectedItems(0).SubItems(1).Text, 2)
                SelOhId = Me.LstVewOhFnd.SelectedItems(0).SubItems(2).Text
                Me.LstVewOhFnd.Enabled = False
                Me.LstVewOhFnd.Visible = False
                Me.Height = 190
                Me.Width = 535
                Me.BtnFnd.Text = "&Find"
                Me.TxtOH.Enabled = False
                Me.TxtDfltVal.Focus()
                Me.TxtDfltVal.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewOhFnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewOhFnd.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.LstVewOhFnd_DoubleClick(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewOhFnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewOhFnd.Leave
        Try
            If Trim(Me.TxtOH.Text) = "" Then
                Me.LstVewOhFnd_DoubleClick(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtOH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOH.GotFocus
        Try
            Me.TxtOH.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtDfltVal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDfltVal.GotFocus
        Try
            Me.TxtDfltVal.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtOH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOH.KeyDown, TxtDfltVal.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TxtDfltVal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDfltVal.Leave
        Try
            If xChk_numericValidation(Me.TxtDfltVal) = False Then
                If Len(Trim(Me.TxtDfltVal.Text)) = 0 Then
                    Me.TxtDfltVal.Text = 0
                End If
                Me.TxtDfltVal.Text = FormatNumber(Me.TxtDfltVal.Text, 2)

            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub DeleteSelectedRowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSelectedRowToolStripMenuItem.Click
        Try

            If Me.LstVewOhFnd.SelectedItems.Count > 0 Then
                If MessageBox.Show("Are you sure to delete current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    If FinActConn.State Then FinActConn.Close()
                    FinActConn.Open()
                    OHcmd = New SqlCommand("Finact_OvrHedmstr_Delete", FinActConn)
                    OHcmd.CommandType = CommandType.StoredProcedure
                    OHcmd.Parameters.AddWithValue("@Ohid", CInt(Me.LstVewOhFnd.SelectedItems(0).SubItems(2).Text))
                    OHcmd.ExecuteNonQuery()
                    OHcmd.Dispose()
                    Me.LstVewOhFnd.SelectedItems(0).Remove()
                Else
                    Return
                End If
            Else
                MsgBox("Invalid Input", MsgBoxStyle.Critical, Me.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
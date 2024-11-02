Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCreatUserRole
    Dim RolCmd As SqlCommand
    Dim RolRdr As SqlDataReader
    Dim RolFlg As Boolean = False
    Private Sub FrmStyleFind_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 10
            Me.Left = 10
            Me.TxtRoleName.Focus()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Fill_DgUsrRole()
        Try
            Me.DgUsrRole.Rows.Clear()
            Dim a1 As Integer = 1
            Dim i As Integer = 0
            Me.DgUsrRole.AllowUserToAddRows = False
            For Each ToolItems As ToolStripMenuItem In FrmMainMdi.Ms1.Items
                Me.DgUsrRole.Rows.Add()
                Me.DgUsrRole.Rows(i).Cells(1).Value = ToolItems.Text.ToUpper '1
                Me.DgUsrRole.Rows(i).Cells(8).Value = ToolItems.Name.ToUpper '8
                Me.DgUsrRole.Rows(i).Cells(2).Value = a1 '2
                Me.DgUsrRole.Rows(i).Cells(3).Value = 0 '3
                Me.DgUsrRole.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                Me.DgUsrRole.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                ' End If
                For Each tl As ToolStripMenuItem In ToolItems.DropDownItems
                    i += 1
                    Me.DgUsrRole.Rows.Add()
                    Me.DgUsrRole.Rows(i).Cells(1).Value = tl.Text '1
                    Me.DgUsrRole.Rows(i).Cells(8).Value = tl.Name '8
                    Me.DgUsrRole.Rows(i).Cells(2).Value = 0 '2
                    Me.DgUsrRole.Rows(i).Cells(3).Value = a1 '3
                    Me.DgUsrRole.Rows(i).DefaultCellStyle.BackColor = Color.White
                    Me.DgUsrRole.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    For Each tlc As ToolStripMenuItem In tl.DropDownItems
                        i += 1
                        Me.DgUsrRole.Rows.Add()
                        Me.DgUsrRole.Rows(i).Cells(1).Value = tlc.Text '1
                        Me.DgUsrRole.Rows(i).Cells(8).Value = tlc.Name '8
                        Me.DgUsrRole.Rows(i).Cells(2).Value = 0 '2
                        Me.DgUsrRole.Rows(i).Cells(3).Value = a1 '3
                        Me.DgUsrRole.Rows(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                        Me.DgUsrRole.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    Next
                    ' End If
                Next
                a1 += 1
                i += 1
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub TxtRoleName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRoleName.KeyDown, ChkAall.KeyDown _
    , ChkAnew.KeyDown, ChkDele.KeyDown, ChkEdt.KeyDown, ChkPrnVew.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtRoleName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRoleName.Leave
        Try
            If Len(Trim(Me.TxtRoleName.Text)) = 0 Then
                Me.DgUsrRole.Enabled = False
                Me.TxtRoleName.BackColor = Color.Cyan
                Me.TxtRoleName.Focus()

                Exit Sub
            Else
                Me.TxtRoleName.BackColor = Color.White
                Fill_DgUsrRole()
                Me.DgUsrRole.Enabled = True
                Me.DgUsrRole.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Me.BtnSave.Text = "&Save" Then
                If Len(Trim(Me.TxtRoleName.Text)) = 0 Then
                    Me.TxtRoleName.BackColor = Color.Cyan
                    Me.TxtRoleName.Focus()
                    Exit Sub
                Else
                    Me.TxtRoleName.BackColor = Color.White
                End If
            End If
            Dim xL As Integer = 0

            For Each rx As DataGridViewRow In Me.DgUsrRole.Rows
                If rx.Cells(0).Value = True Then
                    xL += 1
                End If
            Next

            If Not xL > 0 Then
                MsgBox("Invalid Input! Select Atleast One Item In Schema Membership", MsgBoxStyle.Critical, Me.Text)
                Me.DgUsrRole.Focus()
                Exit Sub
            End If

            xL = 0
            For Each rx As DataGridViewRow In Me.DgUsrRole.Rows
                If rx.Cells(4).Value = True Then
                    xL += 1
                End If
                If rx.Cells(5).Value = True Then
                    xL += 1
                End If
                If rx.Cells(6).Value = True Then
                    xL += 1
                End If
                If rx.Cells(7).Value = True Then
                    xL += 1
                End If
            Next

            If Not xL > 0 Then
                MsgBox("Invalid Input! Grant Atleast One Permission In Current Role", MsgBoxStyle.Critical, Me.Text)
                Me.ChkAnew.Focus()
                Exit Sub
            End If
            If Me.BtnSave.Text = "&Save" Then
                If MessageBox.Show("Are you sure to save current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    xxSav_xxUsrRole()
                Else
                    Return
                End If
            ElseIf Me.BtnSave.Text = "&Update" Then
                If Me.CmbxRole.SelectedIndex = -1 Then
                    Me.CmbxRole.Focus()
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure to update current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    xxUpdate_xxUsrRole()
                Else
                    Return
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkAall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAall.CheckedChanged
        Try
            Dim cx As Integer = 0
            If Me.ChkAall.Checked = True Then
                For cx = 4 To 7
                    Chk_UnChk_SelChkBxs(cx, True)
                Next
                Me.ChkAall.Text = "Clear All  Permission Of  All Selected Item(s)"
            Else
                For cx = 4 To 7
                    Chk_UnChk_SelChkBxs(cx, False)
                Next
                Me.ChkAall.Text = "Grant  All Permission To All Selected Item(s)"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgUsrRole_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgUsrRole.CellClick
        Try
            If e.ColumnIndex = 0 Then

            End If

            If e.ColumnIndex = 4 Then
                If Me.DgUsrRole.CurrentRow.Cells(0).Value = True Then
                    Me.DgUsrRole.CurrentRow.Cells(4).ReadOnly = False
                Else
                    Me.DgUsrRole.CurrentRow.Cells(4).ReadOnly = True
                End If
            End If
            If e.ColumnIndex = 5 Then
                If Me.DgUsrRole.CurrentRow.Cells(0).Value = True Then
                    Me.DgUsrRole.CurrentRow.Cells(5).ReadOnly = False
                Else
                    Me.DgUsrRole.CurrentRow.Cells(5).ReadOnly = True
                End If
            End If
            If e.ColumnIndex = 6 Then
                If Me.DgUsrRole.CurrentRow.Cells(0).Value = True Then
                    Me.DgUsrRole.CurrentRow.Cells(6).ReadOnly = False
                Else
                    Me.DgUsrRole.CurrentRow.Cells(6).ReadOnly = True
                End If
            End If
            If e.ColumnIndex = 7 Then
                If Me.DgUsrRole.CurrentRow.Cells(0).Value = True Then
                    Me.DgUsrRole.CurrentRow.Cells(7).ReadOnly = False
                Else
                    Me.DgUsrRole.CurrentRow.Cells(7).ReadOnly = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

  
    Private Sub DgUsrRole_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgUsrRole.CellEndEdit
        Try
            If e.ColumnIndex = 0 Then
                If Me.DgUsrRole.CurrentRow.Cells(2).Value > 0 Then
                    Dim Ix As Integer = Me.DgUsrRole.CurrentRow.Cells(2).Value

                    If Me.DgUsrRole.CurrentRow.Cells(0).Value = True Then
                        For Each rx As DataGridViewRow In Me.DgUsrRole.Rows
                            If rx.Cells(3).Value = Ix Then
                                rx.Cells(0).Value = True
                                rx.Cells(0).ReadOnly = False
                            End If
                        Next
                    Else
                        For Each rx As DataGridViewRow In Me.DgUsrRole.Rows
                            If rx.Cells(3).Value = Ix Then
                                rx.Cells(0).Value = False
                                rx.Cells(4).Value = False
                                rx.Cells(5).Value = False
                                rx.Cells(6).Value = False
                                rx.Cells(7).Value = False
                                rx.Cells(0).ReadOnly = True
                            End If
                        Next
                     
                    End If
                End If
                If Me.DgUsrRole.CurrentRow.Cells(0).Value = False Then
                    Me.DgUsrRole.CurrentRow.Cells(4).Value = False
                    Me.DgUsrRole.CurrentRow.Cells(5).Value = False
                    Me.DgUsrRole.CurrentRow.Cells(6).Value = False
                    Me.DgUsrRole.CurrentRow.Cells(7).Value = False
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub ChkAnew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAnew.CheckedChanged
        Try
            If Me.ChkAnew.Checked = True Then
                Chk_UnChk_SelChkBxs(4, True)
                Me.ChkAnew.Text = "Clear All  Add New Permissions Of All Selected Item(s)"
            Else
                Me.ChkAnew.Text = "Grant  Add New Permission Of All Selected Item(s)"
                Chk_UnChk_SelChkBxs(4, False)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkEdt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEdt.CheckedChanged
        Try
            If Me.ChkEdt.Checked = True Then
                Chk_UnChk_SelChkBxs(5, True)
                Me.ChkEdt.Text = "Clear All  Alter/Edit Permissions Of All Selected Item(s)"
            Else
                Me.ChkEdt.Text = "Grant  Alter/Edit Permission To All Selected Item(s)"
                Chk_UnChk_SelChkBxs(5, False)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkDele_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDele.CheckedChanged
        Try
            If Me.ChkDele.Checked = True Then
                Chk_UnChk_SelChkBxs(6, True)
                Me.ChkDele.Text = "Clear All  Delete Permissions Of All Selected Item(s)"
            Else
                Me.ChkDele.Text = "Grant  Delete Permission To All Selected Item(s)"
                Chk_UnChk_SelChkBxs(6, False)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkPrnVew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPrnVew.CheckedChanged
        Try
            If Me.ChkPrnVew.Checked = True Then
                Chk_UnChk_SelChkBxs(7, True)
                Me.ChkPrnVew.Text = "Clear All Printing Permissions Of All Selected Item(s)"
            Else
                Me.ChkPrnVew.Text = "Grant  Printing Permission To All Selected Item(s)"
                Chk_UnChk_SelChkBxs(7, False)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Chk_UnChk_SelChkBxs(ByVal xIndxx As Integer, ByVal xtr As Boolean)
        Try
            For Each xxRw As DataGridViewRow In Me.DgUsrRole.Rows
                If xtr = True Then
                    If xxRw.Cells(0).Value = True Then
                        xxRw.Cells(xIndxx).Value = True
                    End If
                Else
                    If xxRw.Cells(0).Value = True Then
                        xxRw.Cells(xIndxx).Value = False
                    End If
                    End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub xxSav_xxUsrRole()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            RolCmd = New SqlCommand("Finact_UserRoleMstr_Insert", FinActConn)
            RolCmd.CommandType = CommandType.StoredProcedure
            RolCmd.Parameters.AddWithValue("@RolName", Trim(Me.TxtRoleName.Text))
            RolCmd.Parameters.AddWithValue("@RolAdusrid", Current_UsrId)
            RolCmd.Parameters.AddWithValue("@RolAddt", Now)
            RolCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        Finally
            RolCmd.Dispose()
        End Try
        Dim xMxId As Integer = 0

        Try
            RolCmd = New SqlCommand("Finact_UserRoleMstr_MaxId_Select", FinActConn)
            RolCmd.CommandType = CommandType.StoredProcedure
            RolCmd.Parameters.AddWithValue("@RolName", Trim(Me.TxtRoleName.Text))
            RolRdr = RolCmd.ExecuteReader
            While RolRdr.Read
                If RolRdr.IsDBNull(0) = False Then
                    xMxId = RolRdr(0)
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        Finally
            RolCmd.Dispose()
            RolRdr.Close()
        End Try


        Try
            For Each xRw1 As DataGridViewRow In Me.DgUsrRole.Rows
                If xRw1.Cells(0).Value = True Then
                    RolCmd = New SqlCommand("Finact_UserRoleChild_Insert", FinActConn)
                    RolCmd.CommandType = CommandType.StoredProcedure
                    RolCmd.Parameters.AddWithValue("@RolcConcrnid", xMxId)
                    RolCmd.Parameters.AddWithValue("@RolcTsName", Trim(xRw1.Cells(1).Value))
                    RolCmd.Parameters.AddWithValue("@RolcTsText", Trim(xRw1.Cells(8).Value))
                    If xRw1.Cells(4).Value = True Then
                        RolCmd.Parameters.AddWithValue("@RolcPaddnew", 1)
                    Else
                        RolCmd.Parameters.AddWithValue("@RolcPaddnew", 0)
                    End If
                    If xRw1.Cells(5).Value = True Then
                        RolCmd.Parameters.AddWithValue("@RolcPEdit", 1)
                    Else
                        RolCmd.Parameters.AddWithValue("@RolcPEdit", 0)
                    End If
                    If xRw1.Cells(6).Value = True Then
                        RolCmd.Parameters.AddWithValue("@RolcDele", 1)
                    Else
                        RolCmd.Parameters.AddWithValue("@RolcDele", 0)
                    End If
                    If xRw1.Cells(7).Value = True Then
                        RolCmd.Parameters.AddWithValue("@RolcPrnt", 1)
                    Else
                        RolCmd.Parameters.AddWithValue("@RolcPrnt", 0)
                    End If

                    RolCmd.ExecuteNonQuery()
                End If
            Next
            MsgBox("Current record has been successfully saved.", MsgBoxStyle.Information, Me.Text)
            Me.TxtRoleName.Clear()
            Me.DgUsrRole.Rows.Clear()
            Me.ChkAall.Checked = False
            Me.ChkAnew.Checked = False
            Me.ChkDele.Checked = False
            Me.ChkEdt.Checked = False
            Me.ChkPrnVew.Checked = False


        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        Finally
            RolCmd.Dispose()
        End Try

    End Sub
    Private Sub xxUpdate_xxUsrRole()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            RolCmd = New SqlCommand("Finact_UserRole_Child_Delete", FinActConn)
            RolCmd.CommandType = CommandType.StoredProcedure
            RolCmd.Parameters.AddWithValue("@UrConcrnid", Me.CmbxRole.SelectedValue)
            RolCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        Finally
            RolCmd.Dispose()
        End Try

        Try
            For Each xRw1 As DataGridViewRow In Me.DgUsrRole.Rows
                If xRw1.Cells(0).Value = True Then
                    RolCmd = New SqlCommand("Finact_UserRoleChild_Insert", FinActConn)
                    RolCmd.CommandType = CommandType.StoredProcedure
                    RolCmd.Parameters.AddWithValue("@RolcConcrnid", Me.CmbxRole.SelectedValue)
                    RolCmd.Parameters.AddWithValue("@RolcTsName", Trim(xRw1.Cells(1).Value))
                    RolCmd.Parameters.AddWithValue("@RolcTsText", Trim(xRw1.Cells(8).Value))
                    If xRw1.Cells(4).Value = True Then
                        RolCmd.Parameters.AddWithValue("@RolcPaddnew", 1)
                    Else
                        RolCmd.Parameters.AddWithValue("@RolcPaddnew", 0)
                    End If
                    If xRw1.Cells(5).Value = True Then
                        RolCmd.Parameters.AddWithValue("@RolcPEdit", 1)
                    Else
                        RolCmd.Parameters.AddWithValue("@RolcPEdit", 0)
                    End If
                    If xRw1.Cells(6).Value = True Then
                        RolCmd.Parameters.AddWithValue("@RolcDele", 1)
                    Else
                        RolCmd.Parameters.AddWithValue("@RolcDele", 0)
                    End If
                    If xRw1.Cells(7).Value = True Then
                        RolCmd.Parameters.AddWithValue("@RolcPrnt", 1)
                    Else
                        RolCmd.Parameters.AddWithValue("@RolcPrnt", 0)
                    End If

                    RolCmd.ExecuteNonQuery()
                End If
            Next
            MsgBox("Current record has been successfully updated.", MsgBoxStyle.Information, Me.Text)
            Me.DgUsrRole.Rows.Clear()
            Me.ChkAall.Checked = False
            Me.ChkAnew.Checked = False
            Me.ChkDele.Checked = False
            Me.ChkEdt.Checked = False
            Me.ChkPrnVew.Checked = False
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        Finally
            RolCmd.Dispose()
        End Try

    End Sub
    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        Try
          
            If Me.BtnFind.Text = "&Find" Then
                Me.TxtRoleName.Enabled = False
                Me.TxtRoleName.Visible = False
                Me.CmbxRole.Enabled = True
                Me.CmbxRole.Visible = True
                Me.ChkAall.Checked = False
                Me.ChkAnew.Checked = False
                Me.ChkDele.Checked = False
                Me.ChkEdt.Checked = False
                Me.ChkPrnVew.Checked = False
                Fill_Combobox("Nrrid", "Narration", "finact_Narration", "ROLDELSTATUS", CInt(1), Me.CmbxRole)
                Me.BtnSave.Text = "&Update"
                Me.BtnFind.Text = "&Cancel"
               
            Else
                Me.BtnSave.Text = "&Save"
                Me.BtnFind.Text = "&Find"
                Me.TxtRoleName.Enabled = True
                Me.TxtRoleName.Visible = True
                Me.CmbxRole.Enabled = False
                Me.CmbxRole.Visible = False
                Me.DgUsrRole.Rows.Clear()
                Me.TxtRoleName.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxRole_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxRole.GotFocus
        Try
            If Me.CmbxRole.Items.Count > 0 Then
                RolFlg = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxRole_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxRole.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxRole) = False Then
                Exit Sub
            Else
                Me.DgUsrRole.Enabled = True
                Me.DgUsrRole.Focus()
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub CmbxRole_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxRole.SelectedIndexChanged
        Try
            If Not Me.CmbxRole.SelectedIndex = -1 Then
                Me.DgUsrRole.Rows.Clear()
                Me.DgUsrRole.Enabled = True
                Fill_DgUsrRole()
                If RolFlg = True Then
                    Fill_DgforEdit()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fill_DgforEdit()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            RolCmd = New SqlCommand("Finact_UserRole_Child_Select", FinActConn)
            RolCmd.CommandType = CommandType.StoredProcedure
            RolCmd.Parameters.AddWithValue("@UrConcrnid", Me.CmbxRole.SelectedValue)
            RolRdr = RolCmd.ExecuteReader
            While RolRdr.Read
                If RolRdr.IsDBNull(0) = False Then
                    Dim Col1 As String = Trim(RolRdr("RolcTsName"))
                    Dim Col2 As String = RolRdr("RolcPaddNew")
                    Dim Col3 As String = RolRdr("RolcPEdit")
                    Dim Col4 As String = RolRdr("RolcDele")
                    Dim Col5 As String = RolRdr("RolcPrnt")
                    Dim Col6 As String = RolRdr("RolcTsText")
                    For Each rx As DataGridViewRow In Me.DgUsrRole.Rows
                        If Trim(rx.Cells(8).Value) = Trim(Col6) Then
                            rx.Cells(0).Value = True
                            If Col2 = "True" Then
                                rx.Cells(4).Value = True
                            End If
                            If Col3 = "True" Then
                                rx.Cells(5).Value = True
                            End If
                            If Col4 = "True" Then
                                rx.Cells(6).Value = True
                            End If
                            If Col5 = "True" Then
                                rx.Cells(7).Value = True
                            End If
                        End If
                    Next
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            RolCmd.Dispose()
            RolRdr.Close()
        End Try
    End Sub

    Private Sub DgUsrRole_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgUsrRole.CellContentClick

    End Sub
End Class
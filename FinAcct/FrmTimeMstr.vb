Imports System.Data
Imports System.Data.SqlClient
Imports System.Math
Public Class FrmTimeMstr
    Inherits System.Windows.Forms.Form
    Dim Tme_mstr_Cmd As SqlCommand
    Dim Tme_mstr_rdr As SqlDataReader
    Dim Add_Edit_Flag As Boolean
    Dim delstatus As Boolean
    Dim Indx As Integer
    Dim chkdupliitm As Boolean = False
    Dim no_rd As Boolean = False
    Dim lev_foc As Boolean = False
    Dim lev_foc1 As Boolean = False

    Private Sub FrmTimeMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        CheckAcess_Btn_frm(Btnadd, Btnfnd, Btndel)
        Combsft.SelectedIndex = 0
        Combmin.SelectedIndex = 0
        Me.Width = 481
        Me.Height = 227
        Panel1.Enabled = False
        Btndel.Enabled = False
        Lblempid.Visible = False
        Combid.Visible = False
    End Sub
    Private Sub CheckAcess_Btn_frm(ByVal BtnnAdd As Button, ByVal BtnnEdt As Button, _
      ByVal BtnnDel As Button)
        Select Case Trim(AcessRight)
            Case "OwnrFull"
                BtnnAdd.Enabled = True
                BtnnEdt.Enabled = True
                BtnnDel.Enabled = True
            Case "DataEntryMstr"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(149, 189)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
            Case "PayRoll"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(149, 189)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
        End Select
    End Sub
    Private Sub fetch_AllRec_from_Table()
        'Dim th As String
        'Dim tm As Single
        'Dim th2 As Single
        'Dim tm2 As Single
        'Dim res As Single
        Try
            Tme_mstr_Cmd = New SqlCommand("Select * from FinactEmpTimeMstr where Empsift='" & (Combid.Text) & "' and Empdelstatus='" & (0) & "' ", FinActConn)
            Tme_mstr_rdr = Tme_mstr_Cmd.ExecuteReader
            Tme_mstr_rdr.Read()
            If Tme_mstr_rdr.HasRows = True Then
                Combsft.Text = Tme_mstr_rdr("Empsift")
                txtconid.Text = Tme_mstr_rdr("Empid")
                Dtpkrstime.Text = Tme_mstr_rdr("Empstdtime")
                Dtpkrendtm.Text = Tme_mstr_rdr("Empendtime")
                Dtpkrbrk.Text = Tme_mstr_rdr("Empbrkfrom")
                Dtpkrbrkto.Text = Tme_mstr_rdr("Empbrkto")
                Combmin.Text = Tme_mstr_rdr("Empovertm")
                If Tme_mstr_rdr("Empovertm") = 0 Then
                    Combmin.SelectedIndex = 0
                ElseIf Tme_mstr_rdr("Empovertm") = 15 Then
                    Combmin.SelectedIndex = 1
                ElseIf Tme_mstr_rdr("Empovertm") = 30 Then
                    Combmin.SelectedIndex = 2
                ElseIf Tme_mstr_rdr("Empovertm") = 45 Then
                    Combmin.SelectedIndex = 3
                ElseIf Tme_mstr_rdr("Empovertm") = 60 Then
                    Combmin.SelectedIndex = 4
                End If
                'th = Format(Dtpkrstime.Value, "hh")
                'th = th * 60
                'tm = Format(Dtpkrstime.Value, "mm")
                'tm = th + tm

                'th2 = Format(Dtpkrendtm.Value, "hh")
                'th2 = th2 * 60
                'tm2 = Format(Dtpkrendtm.Value, "mm")
                'tm2 = th2 + tm2
                'res = Abs(tm - tm2)
                ''Txtdif.Text = res
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Tme_mstr_rdr.Close()
            Tme_mstr_Cmd = Nothing
        End Try

    End Sub
    Private Sub fetch_Diff() 'no use
        Dim th As Single
        Dim tm As Single
        Dim th2 As Single
        Dim tm2 As Single
        Dim diff As String

        Try
            Tme_mstr_Cmd = New SqlCommand("Select Empstdtime,Empendtime from FinactEmpTimeMstr where Empid='" & (Combid.Text) & "' and Empdelstatus='" & (0) & "' ", FinActConn)
            Tme_mstr_rdr = Tme_mstr_Cmd.ExecuteReader
            Tme_mstr_rdr.Read()
            If Tme_mstr_rdr.HasRows = True Then
                th = Format(Tme_mstr_rdr("Empstdtime"), "hh")
                th = th * 60
                tm = Format(Tme_mstr_rdr("Empstdtime"), "mm")
                diff = th + tm
                'Txtdif.Text = diff
                th2 = Format(Tme_mstr_rdr("Empendtime"), "hh")
                th2 = th2 * 60
                tm2 = Format(Tme_mstr_rdr("Empendtime"), "mm")
                tm2 = th2 + tm2
                'Txtdif.Text = tm - tm2
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Tme_mstr_rdr.Close()
            Tme_mstr_Cmd = Nothing
        End Try
    End Sub

    Private Sub Saverrecord()
        delstatus = 0
        Try
            If Add_Edit_Flag = True Then
                Tme_mstr_Cmd = New SqlCommand("Finact_TimeMstr_Insert", FinActConn)
                Tme_mstr_Cmd.CommandType = CommandType.StoredProcedure
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empadddt", Now)
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empadusrid", Current_UsrId)
            ElseIf Add_Edit_Flag = False Then
                Tme_mstr_Cmd = New SqlCommand("Finact_TimeMstr_Update", FinActConn)
                Tme_mstr_Cmd.CommandType = CommandType.StoredProcedure
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empedtdt", Now)
                Tme_mstr_Cmd.Parameters.AddWithValue("@EmpEdtusrid", Current_UsrId)
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empid", CInt(txtconid.Text))
            End If
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empsift", Trim(Combsft.Text))
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empstdtime", Dtpkrstime.Value)
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empendtime", Dtpkrendtm.Value)
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empbrkfrom", Dtpkrbrk.Value)
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empbrkto", Dtpkrbrkto.Value)
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empdelstatus", delstatus)
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empovertm", Combmin.Text)
            Tme_mstr_Cmd.ExecuteNonQuery()
            MsgBox("Current Record has been Successfully Saved", MsgBoxStyle.Information, "Shift Master!!!")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Shift Master!!!")
        Finally
            Tme_mstr_Cmd = Nothing
        End Try

    End Sub

    Private Sub Btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click

        If Btnadd.Text = "&Add" Then
            Btnfnd.Text = "&Cancel"
            Me.Width = 481
            Me.Height = 227
            Btnadd.Text = "&Save"
            Panel1.Enabled = True
            Combsft.Focus()
            Add_Edit_Flag = True
        ElseIf Btnadd.Text = Trim("&Save") Then
            Chk_val()
            If Indx <> 0 Then
                Indx = 0
                Exit Sub
            ElseIf Add_Edit_Flag = True Then
                Saverrecord()
                clrvalues()
            ElseIf Add_Edit_Flag = False Then
                ' diff()
                Saverrecord()
                clrvalues()
            End If
        End If

    End Sub


    Private Sub Btnclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnclose.Click
        Dim delconfrm As String
        delconfrm = MsgBox("Are you sure to exit", MsgBoxStyle.YesNo, "Close Section")
        If delconfrm = vbYes Then
            Me.Close()
        End If
    End Sub
    Private Sub Combsft_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combsft.GotFocus
        Combsft.DroppedDown = True
    End Sub
    Private Sub Dtpkrstime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpkrstime.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dtpkrendtm.Focus()

        End If
    End Sub
    Private Sub Dtpkrendtm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpkrendtm.GotFocus
        lev_foc = False
    End Sub
    Private Sub Dtpkrendtm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpkrendtm.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dtpkrbrk.Focus()

        End If
    End Sub

    Private Sub Dtpkrbrk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpkrbrk.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dtpkrbrkto.Focus()

        End If
    End Sub
    Private Sub Btnfnd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnfnd.Click
        If Btnfnd.Text = "&Find" Then
            fetch_empid_sft()
            If no_rd = True Then
                clrvalues()
                Exit Sub
            End If
            Me.Width = 481 ' 388
            Me.Height = 319
            Btnfnd.Text = "&Cancel"
            Combsft.Text = ""
            Dtpkrbrkto.Text = ""
            Dtpkrstime.Text = ""
            Dtpkrendtm.Text = ""
            Dtpkrbrk.Text = ""
            Add_Edit_Flag = False
            Btndel.Enabled = True
            Panel1.Enabled = False
            Btnadd.Text = "&Save"
            Lblempid.Visible = True
            Combid.Visible = True
            Combid.Enabled = True
            Combid.Focus()
        ElseIf Btnfnd.Text = "&Cancel" Then
            Btnfnd.Text = "&Find"
            clrvalues()
        End If
    End Sub
    Private Sub Del_rd()
        delstatus = 1
        Try
            Tme_mstr_Cmd = New SqlCommand("Finact_TimeMstr_Delete", FinActConn)
            Tme_mstr_Cmd.CommandType = CommandType.StoredProcedure
            Tme_mstr_Cmd.Parameters.AddWithValue("@EmpId", CInt(txtconid.Text))
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empdelusrid", Current_UsrId)
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empdeldt", Now)
            Tme_mstr_Cmd.Parameters.AddWithValue("@EmpdelStatus", delstatus)
            Tme_mstr_Cmd.ExecuteNonQuery()
            MsgBox("Current Record has been Deleted", MsgBoxStyle.Information, "Record Deleted")
        Catch EX As Exception
            MsgBox(EX.Message)
        Finally
            Tme_mstr_Cmd = Nothing
            clrvalues()
        End Try
    End Sub

    Private Sub Btndel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btndel.Click
        Dim delconfrm As String
        delconfrm = MsgBox("Are you sure to delete this record", MsgBoxStyle.YesNo, "Delete Section")
        If delconfrm = vbYes Then
            Del_rd()
        Else
            Btndel.Focus()
        End If
    End Sub

    Private Sub Chk_val()
        With Combsft
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Dtpkrstime
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Dtpkrendtm

            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If

        End With

        With Dtpkrbrk
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Dtpkrbrkto
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Combmin
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        If Dtpkrbrkto.Value <= Dtpkrbrk.Value Then
            Indx += 1
            lev_foc1 = True
            Dtpkrbrkto.Focus()
            MsgBox("Break to time should be greater than break from time of shift", MsgBoxStyle.Information, "Alert")
        Else

            lev_foc1 = False
        End If

        If Dtpkrendtm.Value <= Dtpkrstime.Value Then
            Indx += 1
            lev_foc = True
            Dtpkrendtm.Focus()
            MsgBox("End time should be greater than start time of shift", MsgBoxStyle.Information, "Alert")
        Else

            lev_foc = False
        End If
    End Sub
    Private Sub clrvalues()
        Combsft.Text = ""
        Dtpkrbrkto.Text = ""
        Dtpkrstime.Text = ""
        Dtpkrendtm.Text = ""
        Dtpkrbrk.Text = ""
        Btnadd.Text = "&Add"
        Add_Edit_Flag = True
        Btndel.Enabled = False
        Panel1.Enabled = False
        Btnfnd.Text = "&Find"
        Lblempid.Visible = False
        Combid.Visible = False
        Me.Width = 481 '388
        Me.Height = 227
        no_rd = False
        Labenter.Visible = False
        lev_foc = False
        lev_foc1 = False
        Btnadd.Focus()
    End Sub
    Private Sub fetch_empid_sft()

        Try
            Tme_mstr_Cmd = New SqlCommand("Select Empsift from FinactEmpTimeMstr where Empdelstatus<>'" & (1) & "' ", FinActConn)
            Tme_mstr_rdr = Tme_mstr_Cmd.ExecuteReader

            While Tme_mstr_rdr.Read()
                Combid.Items.Add(Tme_mstr_rdr(0))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Tme_mstr_rdr.HasRows = False Then
                Tme_mstr_rdr.Close()
                Tme_mstr_Cmd = Nothing
                no_rd = True
                MsgBox("No record has been found", MsgBoxStyle.Critical, "Find Section")
            End If
            Tme_mstr_rdr.Close()
            Tme_mstr_Cmd = Nothing

        End Try
    End Sub
    Private Sub Combid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combid.GotFocus
        Combid.Items.Clear()
        Labenter.Visible = True
        fetch_empid_sft()
        If Combid.Items.Count > 0 Then
            If Combid.SelectedIndex = -1 Then
                Combid.SelectedIndex = 0
            End If
            Combid.DroppedDown = True
        End If
    End Sub
    Private Sub Combid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Combid.Enabled = False
            Labenter.Visible = False
            Panel1.Enabled = True
            Btnadd.Text = "&Save"
            Me.Width = 481
            Me.Height = 263
            Combsft.Focus()
        End If
    End Sub
    Private Sub Combid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combid.SelectedIndexChanged
        fetch_AllRec_from_Table()
    End Sub

    Private Sub Dtpkrbrkto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpkrbrkto.GotFocus
        lev_foc1 = False
    End Sub
    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Panel1.KeyDown, Combid.KeyDown, _
         Combsft.KeyDown, Dtpkrbrk.KeyDown, Dtpkrbrkto.KeyDown, Dtpkrendtm.KeyDown, Dtpkrstime.KeyDown, Lblbrk.KeyDown, Lblbrkto.KeyDown, _
        Lblempid.KeyDown, Lblend.KeyDown, Lblsft.KeyDown, Lblsrt.KeyDown, Btnadd.KeyDown, Btnclose.KeyDown, Btndel.KeyDown, Btnfnd.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Dtpkrbrkto_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpkrbrkto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Combmin.Focus()
        End If
    End Sub
    Private Sub Combmin_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combmin.GotFocus
        Combmin.DroppedDown = True
    End Sub
    Private Sub Combmin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combmin.KeyDown
        If e.KeyCode = Keys.Enter Then
            Btnadd.Focus()
        End If
    End Sub
    Private Sub Combsft_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combsft.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dtpkrstime.Focus()
        End If
    End Sub
    Private Sub dupl_rd()
        Dim chk_dupli_name As String = ""
        If Add_Edit_Flag = True And chkdupliitm <> True Then
            Try
                Tme_mstr_Cmd = New SqlCommand("Select Empsift from FinactEmpTimeMstr where Empdelstatus<>'" & (1) & "'", FinActConn)
                Tme_mstr_rdr = Tme_mstr_Cmd.ExecuteReader
                While Tme_mstr_rdr.Read()
                    If Tme_mstr_rdr.HasRows = True Then
                        chk_dupli_name = Tme_mstr_rdr(0)
                        If Trim(Combsft.Text.ToUpper) = Trim(chk_dupli_name.ToUpper) Then
                            chkdupliitm = True
                            MsgBox("System found same sift no in data table, try again with another sift no", MsgBoxStyle.Information, "Duplicate Value")
                            Combsft.Focus()
                            Tme_mstr_rdr.Close()
                            Tme_mstr_Cmd = Nothing
                            Exit Sub
                        End If
                    End If
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Tme_mstr_rdr.Close()
                Tme_mstr_Cmd = Nothing
            End Try
        ElseIf chkdupliitm <> True And Add_Edit_Flag = False Then
            Try
                Tme_mstr_Cmd = New SqlCommand("Select Empsift from FinactEmpTimeMstr where Empdelstatus<>'" & (1) & "' and Empsift<>'" & (Combid.Text) & "'", FinActConn)
                Tme_mstr_rdr = Tme_mstr_Cmd.ExecuteReader
                While Tme_mstr_rdr.Read()
                    If Tme_mstr_rdr.HasRows = True Then
                        chk_dupli_name = Tme_mstr_rdr(0)
                        If Trim(Combsft.Text.ToUpper) = Trim(chk_dupli_name.ToUpper) Then
                            chkdupliitm = True
                            MsgBox("System found same sift no in data table, try again with another sift no", MsgBoxStyle.Information, "Duplicate Value")
                            Combsft.Focus()
                            Tme_mstr_rdr.Close()
                            Tme_mstr_Cmd = Nothing
                            Exit Sub
                        End If
                    End If
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Tme_mstr_rdr.Close()
                Tme_mstr_Cmd = Nothing
            End Try


        End If
    End Sub

    Private Sub Combsft_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combsft.Leave
        If Combsft.Text <> "" Then
            dupl_rd()
            chkdupliitm = False

        End If
    End Sub

    Private Sub Dtpkrendtm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpkrendtm.Leave
        If lev_foc = False Then
            If Dtpkrendtm.Value <= Dtpkrstime.Value Then
                lev_foc = True
                Dtpkrendtm.Focus()
                MsgBox("End time should be greater than start time of shift", MsgBoxStyle.Information, "Alert")
            End If
        End If

    End Sub

    Private Sub Dtpkrbrkto_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpkrbrkto.Leave
        If lev_foc1 = False Then
            If Dtpkrbrkto.Text <= Dtpkrbrk.Text Then
                lev_foc1 = True
                Dtpkrbrkto.Focus()
                MsgBox("Break to time should be greater than break from time of shift", MsgBoxStyle.Information, "Alert")
            End If
        End If
    End Sub

    
    Private Sub Dtpkrendtm_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtpkrendtm.ValueChanged

    End Sub
End Class
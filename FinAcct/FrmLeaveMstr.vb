Imports System.Data
Imports System.Data.SqlClient

Public Class FrmLeaveMstr
    Inherits System.Windows.Forms.Form
    Dim Tme_mstr_Cmd As SqlCommand
    Dim Tme_mstr_rdr As SqlDataReader
    Dim Add_Edit_Flag As Boolean
    Dim delstatus As Boolean
    Dim fet_res As Boolean = False
    Dim Indx As Integer
    Dim lev_foc As Boolean = False
    Dim lev_foc1 As Boolean = False
    Dim lev_foc2 As Boolean = False
    Dim lev_foc3 As Boolean = False
    Dim lev_foc4 As Boolean = False
    Dim no_rd As Boolean = False
    Dim Strtminyear As Date


    Private Sub Frmleavemstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Try
            Tme_mstr_Cmd = New SqlCommand("Select empid from FinactEmplevMstr where empdelstatus='" & (0) & "'  ", FinActConn)
            Tme_mstr_rdr = Tme_mstr_Cmd.ExecuteReader
            While Tme_mstr_rdr.Read()
                If Tme_mstr_rdr.IsDBNull(0) = False Then
                    If Tme_mstr_rdr.HasRows = True Then
                        Btnadd.Text = "&Save"
                        fet_res = True
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Tme_mstr_rdr.HasRows = False Then
                Tme_mstr_rdr.Close()
                Tme_mstr_Cmd = Nothing
                fet_res = False
                Btnadd.Text = "&Add"
            End If

            Tme_mstr_rdr.Close()
            Tme_mstr_Cmd = Nothing
        End Try
        If fet_res = True Then
            MsgBox("Record has been already Saved Only Updation can be done", MsgBoxStyle.Information, "Leave Master")
        End If
        CheckAcess_Btn_frm(Btnadd, Btnfnd, Btndel)
        Panel1.Enabled = False
        Btndel.Enabled = False
        fetch_Costrtdate()
        dtp1.MinDate = Strtminyear
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
                BtnnAdd.Location = New System.Drawing.Point(115, 102)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
            Case "PayRoll"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(115, 102)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
        End Select
    End Sub
    Private Sub fetch_Costrtdate() '-------------to fetch srtdate,year of company and add items in year combo
        Try
            Tme_mstr_Cmd = New SqlCommand("Select Costrtdt from finactcogatemstr ", FinActConn)
            Tme_mstr_rdr = Tme_mstr_Cmd.ExecuteReader
            Tme_mstr_rdr.Read()
            If Tme_mstr_rdr.IsDBNull(0) = False Then
                If Tme_mstr_rdr.HasRows = True Then
                    Strtminyear = Format(Tme_mstr_rdr(0), "MMMM/yyyy")
                Else
                    Strtminyear = Format("1 / 1 / 1900", "MMMM/yyyy")
                End If
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
                Tme_mstr_Cmd = New SqlCommand("Finact_LeaveMstr_Insert", FinActConn)
                Tme_mstr_Cmd.CommandType = CommandType.StoredProcedure
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empadddt", Now)
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empadusrid", Current_UsrId)
            ElseIf Add_Edit_Flag = False Then
                Tme_mstr_Cmd = New SqlCommand("Finact_LeaveMstr_Update", FinActConn)
                Tme_mstr_Cmd.CommandType = CommandType.StoredProcedure
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empedtdt", Now)
                Tme_mstr_Cmd.Parameters.AddWithValue("@EmpEdtusrid", Current_UsrId)
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empid", CInt(Txtid.Text))
            End If
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empcasual", Trim(Num1.Text))
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empsicklv", Trim(Num2.Text))
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empsrtlv", Trim(Num3.Text))
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empmaternitylv", Trim(Num4.Text))
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empsrtlevhr", CmbxHr.Text)
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empsrtlevmin", CmbxMnt.Text)
            Tme_mstr_Cmd.Parameters.AddWithValue("@Empdelstatus", delstatus)

            If Txtmnth.Visible = True Then
                Tme_mstr_Cmd.Parameters.AddWithValue("@EmpMnthdays", CInt(Txtmnth.Text))
            Else
                Tme_mstr_Cmd.Parameters.AddWithValue("@EmpMnthdays", 0)
            End If
            If Cmbxmnth.Text <> "User Defined" Then
                Tme_mstr_Cmd.Parameters.AddWithValue("@EmpMnthUD", Trim("calendarDf"))
            Else
                Tme_mstr_Cmd.Parameters.AddWithValue("@EmpMnthUD", Trim("UserDef"))
            End If
            Tme_mstr_Cmd.Parameters.AddWithValue("@EmpsrtlevCompohr", Cmbxhr1.Text)
            Tme_mstr_Cmd.Parameters.AddWithValue("@EmpsrtlevCompomin", Cmbxmin1.Text)
            Tme_mstr_Cmd.Parameters.AddWithValue("@EmpCompomnth", CInt(Txtval.Text))
            Tme_mstr_Cmd.Parameters.AddWithValue("@Emplevapprovedpd", CInt(txtlev.Text))

            If Cmbxyr.Text = "Calendar Year" Then
                Tme_mstr_Cmd.Parameters.AddWithValue("@Booksyr", "Calendar Year")
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empfinancialyrfr", "")
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empfinancialyrto", "")
            ElseIf Cmbxyr.Text = "User Defined" Then
                Tme_mstr_Cmd.Parameters.AddWithValue("@Booksyr", "User Defined")
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empfinancialyrfr", dtp1.Value.Date)
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empfinancialyrto", Dtp2.Value.Date)
            End If
            If Txtprefix.Text <> "" Then
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empcodeprefx", Txtprefix.Text)
            Else
                Tme_mstr_Cmd.Parameters.AddWithValue("@Empcodeprefx", "")
            End If

            Tme_mstr_Cmd.Parameters.AddWithValue("@Empstrtcode", CInt(Txtcode.Text))
            Tme_mstr_Cmd.Parameters.AddWithValue("@lateflextm", CInt(Combmin.Text))
            Tme_mstr_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Tme_mstr_Cmd = Nothing
        End Try
        MsgBox("Record has been Successfully Saved")
    End Sub


    Private Sub Btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.Click

        If Btnadd.Text = "&Add" Then
            Btnadd.Text = "&Save"
            Panel1.Enabled = True
            Num1.Focus()
            Add_Edit_Flag = True
        ElseIf Btnadd.Text = Trim("&Save") Then
            Chk_val()
            If Indx <> 0 Then
                Indx = 0
                Exit Sub
            ElseIf Add_Edit_Flag = True Then
                Saverrecord()
                fet_res = True
                clrvalues()
            ElseIf Add_Edit_Flag = False Then

                If Txtid.Text <> "" Then
                    Saverrecord()


                End If

                clrvalues()
            End If
        End If
    End Sub
    Private Sub Chk_val()
        With Num1
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Num2
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Num3
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxHr
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With CmbxMnt
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Cmbxhr1
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Cmbxmin1
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtval
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Cmbxmnth
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
        With txtlev
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtval
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtcode
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        If Txtmnth.Visible = True Then
            If Txtmnth.Text <> "" Then
                Dim val As Integer = 0
                val = CInt(Txtmnth.Text)
                If val < 0 Then
                    Indx += 1
                    Txtmnth.Text = ""
                    Txtmnth.BackColor = Color.PapayaWhip
                    Txtmnth.Focus()
                Else
                    Txtmnth.BackColor = Color.White
                End If
                If val > 31 Then
                    Indx += 1
                    Txtmnth.Text = ""
                    Txtmnth.BackColor = Color.PapayaWhip
                    Txtmnth.Focus()
                Else
                    Txtmnth.BackColor = Color.White
                End If
                If val < 28 Then
                    Indx += 1
                    Txtmnth.Text = ""
                    Txtmnth.BackColor = Color.PapayaWhip
                    Txtmnth.Focus()
                Else
                    Txtmnth.BackColor = Color.White
                End If
            Else
                Indx += 1
                Txtmnth.BackColor = Color.PapayaWhip
                Txtmnth.Focus()
            End If
        End If
    End Sub

    Private Sub clrvalues()
        Txtval.Text = ""
        Num1.Text = ""
        Num2.Text = ""
        Num3.Text = ""
        If fet_res = False Then
            Btnadd.Text = "&Add"
        Else
            Btnadd.Text = "&Save"
        End If
        Btnfnd.Text = "&Find"
        Add_Edit_Flag = True
        Panel1.Enabled = False
        Num4.Text = ""
        CmbxMnt.SelectedIndex = 1
        CmbxHr.SelectedIndex = 1
        CmbxMnt.SelectedIndex = 1
        CmbxHr.SelectedIndex = 1
        Btndel.Enabled = False
        ' Me.Width = 368
        Cmbxmnth.SelectedIndex = 1
        Txtmnth.Visible = False
        Txtmnth.Text = ""
        lev_foc = False
        lev_foc1 = False
        lev_foc2 = False
        lev_foc3 = False
        no_rd = False
        lev_foc4 = False
        txtlev.Text = ""
        If Num1.BackColor <> Color.White Then
            Num1.BackColor = Color.White
        End If
        If Num2.BackColor <> Color.White Then
            Num2.BackColor = Color.White
        End If
        If Num4.BackColor <> Color.White Then
            Num4.BackColor = Color.White
        End If
        If Num3.BackColor <> Color.White Then
            Num3.BackColor = Color.White
        End If
        If CmbxHr.BackColor <> Color.White Then
            CmbxHr.BackColor = Color.White
        End If
        If CmbxMnt.BackColor <> Color.White Then
            CmbxMnt.BackColor = Color.White
        End If
        If Cmbxhr1.BackColor <> Color.White Then
            Cmbxhr1.BackColor = Color.White
        End If
        If Txtval.BackColor <> Color.White Then
            Txtval.BackColor = Color.White
        End If
        If Cmbxmnth.BackColor <> Color.White Then
            Cmbxmnth.BackColor = Color.White
        End If
        If Txtmnth.BackColor <> Color.White Then
            Txtmnth.BackColor = Color.White
        End If
        If txtlev.BackColor <> Color.White Then
            txtlev.BackColor = Color.White
        End If
        If Txtprefix.BackColor <> Color.White Then
            Txtprefix.BackColor = Color.White
        End If
        If Txtcode.BackColor <> Color.White Then
            Txtcode.BackColor = Color.White
        End If
        If Cmbxyr.BackColor <> Color.White Then
            Cmbxyr.BackColor = Color.White
        End If
        If Txtid.BackColor <> Color.White Then
            Txtid.BackColor = Color.White
        End If
        If Cmbxmin1.BackColor <> Color.White Then
            Cmbxmin1.BackColor = Color.White
        End If
        If Combmin.BackColor <> Color.White Then
            Combmin.BackColor = Color.White
        End If


        Btnadd.Focus()
    End Sub
    Private Sub Num1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Num1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Num2.Focus()
        End If
    End Sub

    Private Sub Num2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Num2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Num4.Focus()
        End If
    End Sub

    Private Sub Num3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Num3.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbxHr.Focus()
        End If
    End Sub
    Private Sub Btnfnd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnfnd.Click
        If Btnfnd.Text = "&Find" Then
            Fetchid()
            If no_rd = True Then
                clrvalues()
                Exit Sub

            End If
            Btnfnd.Text = "&Cancel"
            Add_Edit_Flag = False
            Panel1.Enabled = True
            Fetchid()
            Fetch_All_rd()
            Btndel.Enabled = True
            Btnadd.Text = "&Save"
            Num1.Focus()
        ElseIf Btnfnd.Text = "&Cancel" Then
            Btnfnd.Text = "&Find"
            clrvalues()
        End If
    End Sub
    Private Sub Fetchid()
        Try
            Tme_mstr_Cmd = New SqlCommand("Select Empid from FinactEmplevMstr where empdelstatus='" & (0) & "' ", FinActConn)
            Tme_mstr_rdr = Tme_mstr_Cmd.ExecuteReader
            While Tme_mstr_rdr.Read()
                Txtid.Text = Tme_mstr_rdr(0)
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
    Private Sub Fetch_All_rd()
        Try
            Tme_mstr_Cmd = New SqlCommand("Select * from FinactEmplevMstr where Empid='" & CInt((Txtid.Text)) & "' and Empdelstatus='" & (0) & "' ", FinActConn)
            Tme_mstr_rdr = Tme_mstr_Cmd.ExecuteReader
            Tme_mstr_rdr.Read()
            If Tme_mstr_rdr.HasRows = True Then
                Num1.Text = Tme_mstr_rdr("Empcasual")
                Num2.Text = Tme_mstr_rdr("Empsicklv")
                Num3.Text = Tme_mstr_rdr("Empsrtlv")
                Num4.Text = Tme_mstr_rdr("Empmaternitylv")
                CmbxHr.Text = Tme_mstr_rdr("Empsrtlevhr")
                If Tme_mstr_rdr("Empsrtlevmin") = 0 Then
                    CmbxMnt.SelectedIndex = 0
                Else
                    CmbxMnt.Text = Tme_mstr_rdr("Empsrtlevmin")
                End If
                Cmbxhr1.Text = Tme_mstr_rdr("EmpsrtlevCompohr")
                If Tme_mstr_rdr("EmpsrtlevCompomin") = 0 Then
                    Cmbxmin1.SelectedIndex = 0
                Else
                    Cmbxmin1.Text = Tme_mstr_rdr("EmpsrtlevCompomin")
                End If
                Txtval.Text = Tme_mstr_rdr("EmpCompomnth")
                If Trim(Tme_mstr_rdr("EmpMnthUD")) = Trim("UserDef") Then
                    Cmbxmnth.SelectedIndex = 0
                    Txtmnth.Visible = True
                    Txtmnth.Text = Tme_mstr_rdr("EmpMnthdays")
                Else
                    Cmbxmnth.SelectedIndex = 1
                    Txtmnth.Visible = False

                End If
                txtlev.Text = Tme_mstr_rdr("Emplevapprovedpd")

                Cmbxyr.Text = Tme_mstr_rdr("Booksyr")
                If Tme_mstr_rdr("Booksyr") = "Calendar Year" Then
                    Panel2.Visible = False
                    Me.Panel4.Location = New System.Drawing.Point(0, 395)
                ElseIf Tme_mstr_rdr("Booksyr") = "User Defined" Then
                    Panel2.Visible = True
                    Me.Panel4.Location = New System.Drawing.Point(0, 433)
                    dtp1.Value = Tme_mstr_rdr("Empfinancialyrfr")
                    Dtp2.Value = Tme_mstr_rdr("Empfinancialyrto")
                End If

                If Tme_mstr_rdr("Empcodeprefx") <> "" Then

                    Txtprefix.Text = Tme_mstr_rdr("Empcodeprefx")
                Else
                    Txtprefix.Text = ""

                End If

                Txtcode.Text = Tme_mstr_rdr("Empstrtcode")
                Combmin.Text = Tme_mstr_rdr("lateflextm")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Tme_mstr_rdr.HasRows = False Then
                Tme_mstr_rdr.Close()
                Tme_mstr_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "Alert")
            End If
            Tme_mstr_rdr.Close()
            Tme_mstr_Cmd = Nothing
        End Try

    End Sub
    Private Sub Cmbid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Fetch_All_rd()
    End Sub

    Private Sub Del_rd()
        delstatus = 1
        Try
            Tme_mstr_Cmd = New SqlCommand("Finact_LeaveMstr_Delete", FinActConn)
            Tme_mstr_Cmd.CommandType = CommandType.StoredProcedure
            Tme_mstr_Cmd.Parameters.AddWithValue("@EmpId", CInt(Txtid.Text))
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
    Private Sub btndel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btndel.Click
        Dim delconfrm As String
        delconfrm = MsgBox("Are you sure to delete this record", MsgBoxStyle.YesNo, "Delete Section")
        If delconfrm = vbYes Then
            Del_rd()
            fet_res = False
            clrvalues()
        Else
            Btndel.Focus()
        End If
    End Sub
    Private Sub Btnclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnclose.Click
        Dim delconfrm As String
        delconfrm = MsgBox("Are you sure to exit", MsgBoxStyle.YesNo, "Close Section")
        If delconfrm = vbYes Then
            Me.Close()
        End If
    End Sub
    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Label1.KeyDown, Label2.KeyDown, _
        label3.KeyDown, Num1.KeyDown, Num2.KeyDown, Num3.KeyDown, Panel1.KeyDown, Btnadd.KeyDown, Btnclose.KeyDown, Btndel.KeyDown, Btnfnd.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Num4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Num4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Num3.Focus()
        End If
    End Sub
    Private Sub CmbxHr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxHr.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbxMnt.Focus()
        End If
    End Sub
    Private Sub CmbxMnt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxMnt.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Cmbxmnth.Focus()
            Cmbxhr1.Focus()
        End If
    End Sub

    Private Sub Cmbxmnth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxmnth.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Cmbxmnth.SelectedIndex = 0 Then
                Txtmnth.Visible = True
                Txtmnth.Focus()
                Exit Sub
            Else
                Txtmnth.Visible = False
            End If
            txtlev.Focus()
        End If
    End Sub
    Private Sub Cmbxmnth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxmnth.Leave
        If Cmbxmnth.SelectedIndex = 0 Then
            Txtmnth.Visible = True
        Else
            Txtmnth.Visible = False
        End If
    End Sub

    Private Sub Txtmnth_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtmnth.GotFocus
        lev_foc = False
    End Sub

    Private Sub Txtmnth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtmnth.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtlev.Focus()
        End If
    End Sub

    Private Sub Txtval_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtval.GotFocus
        lev_foc1 = False
    End Sub

    Private Sub Txtval_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtval.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmbxmnth.Focus()
        End If
    End Sub

    Private Sub txtlev_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlev.GotFocus
        lev_foc3 = False
    End Sub

    Private Sub txtlev_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlev.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txtprefix.Focus()
        End If
    End Sub

    Private Sub Txtmnth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtmnth.KeyPress, Txtval.KeyPress, txtlev.KeyPress, Txtcode.KeyPress
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "." Then
            e.Handled = True
            If Not (IsNumeric(tb.Text & e.KeyChar)) Then
                e.Handled = True
                MsgBox("Enter Valid Number")
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtmnth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtmnth.Leave
        If Txtmnth.Text <> "" And lev_foc = False Then
            Dim val As Integer = 0
            val = CInt(Txtmnth.Text)
            If val <= 0 Then
                Txtmnth.Text = ""
                Txtmnth.BackColor = Color.PapayaWhip
                lev_foc = True
                MsgBox("Enter valid Value", MsgBoxStyle.Information, "Alert")
                Txtmnth.Focus()
            End If
            If val > 31 Then
                Txtmnth.Text = ""
                Txtmnth.BackColor = Color.PapayaWhip
                lev_foc = True
                MsgBox("Enter valid Value", MsgBoxStyle.Information, "Alert")
                Txtmnth.Focus()
            End If
            If val < 28 Then
                Txtmnth.Text = ""
                Txtmnth.BackColor = Color.PapayaWhip
                lev_foc = True
                MsgBox("Enter valid Value", MsgBoxStyle.Information, "Alert")
                Txtmnth.Focus()
            End If
        End If
    End Sub

    Private Sub Txtval_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtval.Leave
        If Txtval.Text <> "" And lev_foc1 = False Then
            Dim val As Integer = 0
            val = CInt(Txtval.Text)
            If val < 0 Then
                Txtval.Text = ""
                Txtval.BackColor = Color.PapayaWhip
                lev_foc1 = True
                MsgBox("Enter valid Value", MsgBoxStyle.Information, "Alert")
                Txtval.Focus()
            End If
            If val > 12 Then
                Txtval.Text = ""
                Txtval.BackColor = Color.PapayaWhip
                lev_foc1 = True

                MsgBox("Enter valid Value", MsgBoxStyle.Information, "Alert")
                Txtval.Focus()
            End If
        End If
    End Sub

    Private Sub Cmbxhr1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxhr1.GotFocus
        lev_foc1 = False
    End Sub

    Private Sub Cmbxhr1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxhr1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmbxmin1.Focus()
        End If
    End Sub

    Private Sub Cmbxmin1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxmin1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txtval.Focus()
        End If
    End Sub

    Private Sub Cmbxmin1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxmin1.Leave
        If Cmbxhr1.Text = 24 Then
            Cmbxmin1.SelectedIndex = 0
        End If
        If Cmbxhr1.Text <> "" And Cmbxmin1.Text <> "" And lev_foc1 = False Then
            If Cmbxhr1.Text = 0 And Cmbxmin1.Text = 0 Then
                lev_foc1 = True
                Cmbxhr1.Focus()
                MsgBox("Value should be greater than 0 ", MsgBoxStyle.Information, "Alert")
            End If
        End If
    End Sub

    Private Sub dtp1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Btnadd.Focus()
            Combmin.Focus()
        End If
    End Sub

    Private Sub dtp1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp1.Leave
        Dim mnth As Integer = 0
        Dim dt2mnth As Date
        dt2mnth = dtp1.Value.AddMonths(12)
        Dtp2.Value = dt2mnth.AddDays(-1)  'DateSerial(Year(dt2mnth), Month(dt2mnth), -1).AddDays(1)

    End Sub

    Private Sub txtlev_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlev.Leave
        If txtlev.Text <> "" And lev_foc3 = False Then
            Dim val As Integer = 0
            val = CInt(txtlev.Text)
            If val <= 0 Then
                txtlev.Text = ""
                txtlev.BackColor = Color.PapayaWhip
                lev_foc3 = True
                MsgBox("Enter valid Value", MsgBoxStyle.Information, "Alert")
                txtlev.Focus()
            End If
        End If
    End Sub


    Private Sub Txtprefix_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtprefix.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txtcode.Focus()
        End If
    End Sub

    Private Sub Txtcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcode.GotFocus
        lev_foc4 = False
    End Sub

    Private Sub Txtcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmbxyr.Focus()
        End If
    End Sub

    Private Sub Cmbxyr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxyr.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Cmbxyr.SelectedIndex = 0 Then
                Panel2.Visible = False
                Me.Panel4.Location = New System.Drawing.Point(0, 395)
                Combmin.Focus()
            ElseIf Cmbxyr.SelectedIndex = 1 Then
                Panel2.Visible = True
                Me.Panel2.Location = New System.Drawing.Point(114, 400)
                Me.Panel4.Location = New System.Drawing.Point(0, 433)
                dtp1.Focus()
            End If
        End If
    End Sub

    Private Sub Txtcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtcode.Leave
        If Txtcode.Text <> "" And lev_foc4 = False Then
            Dim val As Integer = 0
            val = CInt(Txtcode.Text)
            If val <= 0 Then
                Txtcode.Text = ""
                Txtcode.BackColor = Color.PapayaWhip
                lev_foc4 = True
                MsgBox("Enter valid Value", MsgBoxStyle.Information, "Alert")
                Txtcode.Focus()
            End If
        End If
    End Sub

    Private Sub Cmbxyr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxyr.Leave
        If Cmbxyr.SelectedIndex = 0 Then
            Panel2.Visible = False
        ElseIf Cmbxyr.SelectedIndex = 1 Then
            Panel2.Visible = True

        End If
    End Sub

    Private Sub Combmin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combmin.KeyDown
        If e.KeyCode = Keys.Enter Then
            Btnadd.Focus()
        End If
    End Sub

    Private Sub Combmin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combmin.SelectedIndexChanged
        If Combmin.BackColor <> Color.White Then
            Combmin.BackColor = Color.White
        End If
    End Sub

    Private Sub Num1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num1.ValueChanged
        If Num1.BackColor <> Color.White Then
            Num1.BackColor = Color.White
        End If

    End Sub

    Private Sub Num2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num2.ValueChanged
        If Num2.BackColor <> Color.White Then
            Num2.BackColor = Color.White
        End If
    End Sub

    Private Sub Num4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num4.ValueChanged
        If Num4.BackColor <> Color.White Then
            Num4.BackColor = Color.White
        End If

    End Sub

    Private Sub Num3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num3.ValueChanged
        If Num3.BackColor <> Color.White Then
            Num3.BackColor = Color.White
        End If
    End Sub

    Private Sub CmbxHr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxHr.SelectedIndexChanged
        If CmbxHr.BackColor <> Color.White Then
            CmbxHr.BackColor = Color.White
        End If
    End Sub

    Private Sub CmbxMnt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxMnt.SelectedIndexChanged
        If CmbxMnt.BackColor <> Color.White Then
            CmbxMnt.BackColor = Color.White
        End If
    End Sub

    Private Sub Cmbxhr1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxhr1.SelectedIndexChanged
        If Cmbxhr1.BackColor <> Color.White Then
            Cmbxhr1.BackColor = Color.White
        End If
    End Sub

    Private Sub Txtval_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtval.TextChanged
        If Txtval.BackColor <> Color.White Then
            Txtval.BackColor = Color.White
        End If
    End Sub

    Private Sub Cmbxmnth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxmnth.SelectedIndexChanged
        If Cmbxmnth.BackColor <> Color.White Then
            Cmbxmnth.BackColor = Color.White
        End If
    End Sub

    Private Sub Txtmnth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtmnth.TextChanged
        If Txtmnth.BackColor <> Color.White Then
            Txtmnth.BackColor = Color.White
        End If
    End Sub

    Private Sub txtlev_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlev.TextChanged
        If txtlev.BackColor <> Color.White Then
            txtlev.BackColor = Color.White
        End If
    End Sub

    Private Sub Txtprefix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtprefix.TextChanged
        If Txtprefix.BackColor <> Color.White Then
            Txtprefix.BackColor = Color.White
        End If
    End Sub

    Private Sub Txtcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcode.TextChanged
        If Txtcode.BackColor <> Color.White Then
            Txtcode.BackColor = Color.White
        End If
    End Sub

    Private Sub Cmbxyr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxyr.SelectedIndexChanged
        If Cmbxyr.BackColor <> Color.White Then
            Cmbxyr.BackColor = Color.White
        End If
    End Sub

    Private Sub Txtid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtid.TextChanged
        If Txtid.BackColor <> Color.White Then
            Txtid.BackColor = Color.White
        End If
    End Sub

    Private Sub Cmbxmin1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbxmin1.SelectedIndexChanged
        If Cmbxmin1.BackColor <> Color.White Then
            Cmbxmin1.BackColor = Color.White
        End If
    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmFine
    Inherits System.Windows.Forms.Form
    Dim fine_Cmd As SqlCommand
    Dim fine_Rdr As SqlDataReader
    Dim fine_Adptr As SqlDataAdapter
    Dim ds As DataSet
    Dim Indx As Integer = 0
    Dim Add_Edit_Flag As Boolean = False
    Dim listIndex As Integer = 0
    Dim Focus_Flag As Boolean = False
    Dim flg As Boolean = False
    Dim lev_foc As Boolean = False
    Dim Strtminyear As Date
    Dim no_rd As Boolean = False
    Dim maxslrymnth As Date
    Dim CONID As Integer = 0
    Dim STR_MINDT As Date

    Private Sub FrmFine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 0
        Me.Top = 0
        Me.Width = 596
        Me.Height = 286
        ListView1.Visible = False
        Add_Edit_Flag = False
        Btndel.Enabled = False
        fetch_Empname()
        If Cmbxemp.Items.Count > 0 Then
            If Cmbxemp.SelectedIndex = -1 Then
                Cmbxemp.SelectedIndex = 0
            End If
        End If
        fetch_Costrtdate()
        Dtp1.MinDate = Strtminyear
        Dtp1.MinDate = DateSerial(Year(Dtp1.Value), Month(Dtp1.Value), 1)
        STR_MINDT = Dtp1.MinDate
        Dtp1.Focus()
    End Sub
   
    Private Sub fetch_Empname() '-----------------------fetch employee names
        ds = New DataSet
        ds.Tables.Clear()
        Try
            fine_Cmd = New SqlCommand("Select empname,empid from finactEmpMstr where empcateg='" & ("Working") & "' order by empname", FinActConn)
            fine_Adptr = New SqlDataAdapter(fine_Cmd)
            ds = New DataSet(fine_Cmd.CommandText)
            fine_Adptr.Fill(ds)
            Cmbxemp.DataSource = ds.Tables(0)
            Me.Cmbxemp.ValueMember = "empid"
            Me.Cmbxemp.DisplayMember = "empname"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If ds.Tables(0).Rows.Count = 0 Then
                fine_Cmd = Nothing
                Btnclos.Focus()
                MsgBox("No record has been found", MsgBoxStyle.Information, "Alert")
            End If
            fine_Cmd = Nothing
        End Try

    End Sub
    Private Sub Cmbxemp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxemp.GotFocus

        fetch_Empname()
        If Cmbxemp.Items.Count > 0 Then
            If Cmbxemp.SelectedIndex = -1 Then
                Cmbxemp.SelectedIndex = 0
            End If
            Cmbxemp.DroppedDown = True
        End If

    End Sub
    Private Sub fetch_deptname() '------------------------fetch dept name

        Try
            fine_Cmd = New SqlCommand("Select deptname from finactempmstr inner join  finactdept on empdeptid=deptid where  empcateg='" & ("Working") & "' and empid='" & (CInt(txtid.Text)) & "' order by empname", FinActConn)
            fine_Rdr = fine_Cmd.ExecuteReader
            While fine_Rdr.Read()
                If fine_Rdr.IsDBNull(0) = False Then
                    If fine_Rdr.HasRows = True Then
                        Txtdept.Text = fine_Rdr(0)
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If fine_Rdr.HasRows = False Then
                fine_Rdr.Close()
                fine_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Critical, "Department Section")
            End If
            fine_Rdr.Close()
            fine_Cmd = Nothing
        End Try

    End Sub


    Private Sub fetch_Empid() '----------------------------to fetch id's of employees
        Try
            fine_Cmd = New SqlCommand("Select empid from finactEmpMstr where empcateg='" & ("Working") & "' and empname='" & (Cmbxemp.Text) & "'  order by empname", FinActConn)
            fine_Rdr = fine_Cmd.ExecuteReader
            fine_Rdr.Read()
            If fine_Rdr.IsDBNull(0) = False Then
                If fine_Rdr.HasRows = True Then
                    txtid.Text = fine_Rdr(0)
                End If
            Else
                txtid.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If fine_Rdr.HasRows = False Then
                fine_Rdr.Close()
                fine_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "Id Section")
            End If
            fine_Rdr.Close()
            fine_Cmd = Nothing
        End Try

    End Sub

    Private Sub fetch_desiname()

        Try
            fine_Cmd = New SqlCommand("Select desiname from finactempmstr inner join  finactdesi on empdesiid=desiid where  empcateg='" & ("Working") & "' and empid='" & (CInt(txtid.Text)) & "' order by empname", FinActConn)
            fine_Rdr = fine_Cmd.ExecuteReader
            fine_Rdr.Read()
            If fine_Rdr.IsDBNull(0) = False Then
                If fine_Rdr.HasRows = True Then
                    txtdesi.Text = fine_Rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If fine_Rdr.HasRows = False Then
                fine_Rdr.Close()
                fine_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "Department Section")
            End If
            fine_Rdr.Close()
            fine_Cmd = Nothing
        End Try

    End Sub

    Private Sub Txtamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtamt.GotFocus
        lev_foc = False
    End Sub

    Private Sub Txtamt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtamt.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txtamt.Text <> "" Then
                Txtremark.Focus()
            Else
                Txtamt.Focus()
            End If
        End If

    End Sub
    Private Sub Txtfine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtamt.KeyPress

        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "." Then
            e.Handled = False
            If Not (IsNumeric(tb.Text & e.KeyChar)) Then
                e.Handled = True
                MsgBox("Enter Valid Number")
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub
    
    Private Sub saverd()
        Try
            fine_Cmd = New SqlCommand("Finact_FineEmp_Insert", FinActConn)
            fine_Cmd.CommandType = CommandType.StoredProcedure
            fine_Cmd.Parameters.AddWithValue("@FineEmpID", CInt(txtid.Text))
            fine_Cmd.Parameters.AddWithValue("@FineAmt ", CDbl(Txtamt.Text))
            fine_Cmd.Parameters.AddWithValue("@Finedt ", Dtp1.Value.Date)
            fine_Cmd.Parameters.AddWithValue("@FineAddt", Now)
            fine_Cmd.Parameters.AddWithValue("@FineDelstatus", 0)
            fine_Cmd.Parameters.AddWithValue("@FineAddusrid ", Current_UsrId)
            fine_Cmd.Parameters.AddWithValue("@FineRemarks ", Trim(Txtremark.Text))
            fine_Cmd.ExecuteNonQuery()
            MsgBox("Record has been saved successfully", MsgBoxStyle.Information, "Record Saved")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            fine_Cmd = Nothing
        End Try
    End Sub
    Private Sub Update_rd()

        Try
            fine_Cmd = New SqlCommand("Finact_FineEmp_Update", FinActConn)
            fine_Cmd.CommandType = CommandType.StoredProcedure
            fine_Cmd.Parameters.AddWithValue("@FineEmpID", CDbl(txtid.Text))
            fine_Cmd.Parameters.AddWithValue("@FineAmt ", CDbl(Txtamt.Text))
            fine_Cmd.Parameters.AddWithValue("@Finedt ", TXTDT.Text)

            fine_Cmd.Parameters.AddWithValue("@FineEdtdt", Now)
            fine_Cmd.Parameters.AddWithValue("@FineDelstatus", 0)
            fine_Cmd.Parameters.AddWithValue("@FineRemarks ", Txtremark.Text)
            fine_Cmd.Parameters.AddWithValue("@Fineid ", CDbl(ListView1.Items(listIndex).SubItems(5).Text))
            fine_Cmd.ExecuteNonQuery()
            MsgBox("Record has been updated successfully", MsgBoxStyle.Information, "Record Updated")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            fine_Cmd = Nothing
        End Try

    End Sub
    Private Sub del_rd()
        Dim inx As Integer = 0
        If ListView1.Items.Count > 0 Then
            If ListView1.SelectedItems.Count > 0 Then
                inx = ListView1.SelectedItems(0).Index
            End If
        End If
        Try
            fine_Cmd = New SqlCommand("Finact_FineEmp_Delete", FinActConn)
            fine_Cmd.CommandType = CommandType.StoredProcedure
            fine_Cmd.Parameters.AddWithValue("@FineDeldt", Now)
            fine_Cmd.Parameters.AddWithValue("@FineDelstatus", 1)
            fine_Cmd.Parameters.AddWithValue("@Fineid ", CDbl(ListView1.Items(inx).SubItems(5).Text))
            fine_Cmd.ExecuteNonQuery()
            MsgBox("Record has been deleted successfully", MsgBoxStyle.Information, "Deleted")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            fine_Cmd = Nothing
        End Try

    End Sub
    Private Sub fetch_Costrtdate() '-------------to fetch srtdate company 
        Try
            fine_Cmd = New SqlCommand("Select Costrtdt from finactcogatemstr ", FinActConn)
            fine_Rdr = fine_Cmd.ExecuteReader
            fine_Rdr.Read()
            If fine_Rdr.IsDBNull(0) = False Then
                If fine_Rdr.HasRows = True Then
                    Strtminyear = fine_Rdr(0)
                Else
                    Strtminyear = Format("1 / 1 / 1900", "dd/MM/yyyy")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            fine_Rdr.Close()
            fine_Cmd = Nothing
        End Try

    End Sub
    Private Sub Chk_val()

        With Cmbxemp
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With

        With Txtamt
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtremark
            If Trim(.Text) = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                Indx += 1
            Else
                .BackColor = Color.White
            End If
        End With


    End Sub
    Private Sub BtnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.Click
        Chk_val()
        If Indx <> 0 Then
            Indx = 0
            Exit Sub
        ElseIf Add_Edit_Flag = False Then
            Dim delconfrm1 As String
            delconfrm1 = MsgBox("Are you sure to save the record", MsgBoxStyle.YesNo, "Alert")
            If delconfrm1 = vbYes Then
                saverd()
                clrval()
            End If
        ElseIf Add_Edit_Flag <> False Then
            fetch_maxslryslp()
            Dim dtc As Date
            dtc = TXTDT.Text
            If dtc.Month <= maxslrymnth.Month Then 'compare with date whenfine has been applicable
                MsgBox("Record Can't be Update this fine has already deduct", MsgBoxStyle.Information, "Alert")
                clrval()
                Exit Sub
            End If
            Update_rd()
            clrval()
        End If


    End Sub
  
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnclos.Click

        Dim delconfrm As String
        delconfrm = MsgBox("Are you sure to exit", MsgBoxStyle.YesNo, "Close Section")
        If delconfrm = vbYes Then
            Me.Close()
        End If

    End Sub
   
    Private Sub clrval()
        Me.Width = 596
        Me.Height = 286
        Btndel.Enabled = False
        Add_Edit_Flag = False
        Btnfind.Text = "&Find"
        Txtamt.Text = ""
        Txtremark.Text = ""
        ListView1.Items.Clear()
        txtid.Text = ""
        Txtdept.Text = ""
        txtdesi.Text = ""
        ListView1.Visible = False
        Cmbxemp.SelectedItem = 0
        no_rd = False
        Dtp1.Visible = True
        TXTDT.Visible = False
        TXTDT.Text = ""
        Dtp1.Focus()

    End Sub

    Private Sub Btnfind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnfind.Click
        fetch_Empname()
        If Cmbxemp.Items.Count > 0 Then
            If Cmbxemp.SelectedIndex = -1 Then
                Cmbxemp.SelectedIndex = 0
            End If
        End If
        If Btnfind.Text = "&Find" Then
            ListView1.Visible = False
            fetch_backrd()
            If no_rd = True Then
                clrval()
                Exit Sub
            End If
            ListView1.Visible = True
            Txtamt.Text = ""
            Txtremark.Text = ""
            ListView1.Items.Clear()
            txtid.Text = ""
            Txtdept.Text = ""
            txtdesi.Text = ""
            Btnfind.Text = "&Cancel"
            Me.Width = 596
            Me.Height = 496
            fetch_backrd()
            Add_Edit_Flag = True
            Btndel.Enabled = True
            ListView1.Focus()
            If ListView1.Items.Count > 0 Then
                ListView1.Items(0).Selected = True
            End If
        ElseIf Btnfind.Text = "&Cancel" Then
            clrval()
        End If

    End Sub
    Private Sub fetch_backrd()
        Try
            ListView1.Items.Clear()
            Dim Sublst As ListViewItem
            fine_Cmd = New SqlCommand("Select FineEmpid,FineAmt,Finedt,Empname,fineremarks,fineid from finact_Fine_emp inner join finactempmstr on empid=fineempid where finedelstatus= 0  and  empcateg='" & ("Working") & "' order by finedt", FinActConn)
            fine_Rdr = fine_Cmd.ExecuteReader
            While fine_Rdr.Read()
                If fine_Rdr.HasRows = True Then
                    ListView1.Visible = True
                    Sublst = ListView1.Items.Add(Format(fine_Rdr(2), "dd/MM/yyyy"))
                    Sublst.SubItems.Add((fine_Rdr(0)))
                    Sublst.SubItems.Add((fine_Rdr(3)))
                    Sublst.SubItems.Add(FormatNumber(fine_Rdr(1), 2))
                    Sublst.SubItems.Add((fine_Rdr(4)))
                    Sublst.SubItems.Add((fine_Rdr(5)))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If fine_Rdr.HasRows = False Then
                fine_Rdr.Close()
                fine_Cmd = Nothing
                no_rd = True
                MsgBox("No record has been found", MsgBoxStyle.Critical, "Find Section")
            End If
            fine_Rdr.Close()
            fine_Cmd = Nothing
        End Try
    End Sub

    Public Shared Function ConvertDate(ByVal strtdate As String) As Date

        Return DateTime.ParseExact(strtdate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat)

    End Function

    Private Sub fetch_maxslryslp()

        Try
            fine_Cmd = New SqlCommand("Select max(aslrymnth) from FinactAutoSalary where AslryDelstatus<>'" & (1) & "'  ", FinActConn)
            fine_Rdr = fine_Cmd.ExecuteReader
            fine_Rdr.Read()
            If fine_Rdr.IsDBNull(0) = False Then
                If fine_Rdr.HasRows = True Then
                    maxslrymnth = fine_Rdr(0)
                End If
            Else
                maxslrymnth = Strtminyear
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If fine_Rdr.HasRows = False Then
                maxslrymnth = Strtminyear
                fine_Rdr.Close()
                fine_Cmd = Nothing
            End If
            fine_Rdr.Close()
            fine_Cmd = Nothing
        End Try

    End Sub
    Private Sub Fetch_list_text()

        If ListView1.Items.Count > 0 Then
            ListView1.Visible = False
            Me.Width = 596
            Me.Height = 286
            Dim Sublst As ListViewItem
            listIndex = ListView1.SelectedItems(0).Index
            Sublst = ListView1.SelectedItems(0)
            txtid.Text = Sublst.SubItems.Item(1).Text
            'CONID = CInt(Sublst.SubItems.Item(1).Text)
            'fetch_maxslryslp()
            Dtp1.Visible = False
            TXTDT.Visible = True
            TXTDT.Text = ConvertDate(ListView1.Items(listIndex).SubItems(0).Text)
            'If Dtp1.Value.Month <= maxslrymnth.Month Then
            '    Dtp1.MinDate = maxslrymnth
            'End If
            Cmbxemp.Text = Sublst.SubItems.Item(2).Text
            Txtamt.Text = Sublst.SubItems.Item(3).Text
            Txtremark.Text = Sublst.SubItems.Item(4).Text
            Try
                fine_Cmd = New SqlCommand("Select desiname,deptname from finactempmstr inner join  finactdept on empdeptid=deptid inner join  finactdesi on empdesiid=desiid where  empcateg='" & ("Working") & "' and empid='" & (CInt(Sublst.SubItems.Item(1).Text)) & "' order by empname", FinActConn)
                fine_Rdr = fine_Cmd.ExecuteReader
                fine_Rdr.Read()
                If fine_Rdr.IsDBNull(0) = False Then
                    If fine_Rdr.HasRows = True Then
                        txtdesi.Text = fine_Rdr(0)
                        Txtdept.Text = fine_Rdr(1)
                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If fine_Rdr.HasRows = False Then
                    fine_Rdr.Close()
                    fine_Cmd = Nothing
                    MsgBox("No record has been found", MsgBoxStyle.Information, "Department Section")
                End If
                fine_Rdr.Close()
                fine_Cmd = Nothing
            End Try
        End If

    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Fetch_list_text()
        Panel2.Enabled = True
        Txtamt.Enabled = True
        Txtamt.Focus()
    End Sub
    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Fetch_list_text()
            Panel2.Enabled = True
            Txtamt.Enabled = True
            Txtamt.Focus()
        End If

    End Sub

    Private Sub Txtremark_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtremark.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Txtremark.Text <> "" Then
                Btnsave.Focus()
            Else
                Txtremark.Focus()
            End If
        End If

    End Sub

    Private Sub Btndel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btndel.Click

        Dim delconfrm As String
        delconfrm = MsgBox("Are you sure to delete the record", MsgBoxStyle.YesNo, "Delete Section")
        If delconfrm = vbYes Then
            Dim inx As Integer = 0
            If ListView1.Items.Count > 0 Then
                If ListView1.SelectedItems.Count > 0 Then
                    inx = ListView1.SelectedItems(0).Index
                Else
                    MsgBox("No record Select to delete", MsgBoxStyle.Information, "Alert")
                    ListView1.Focus()
                    If ListView1.Items.Count > 0 Then
                        ListView1.Items(0).Selected = True
                    End If
                    Exit Sub
                End If
            End If
            del_rd()
            clrval()
        End If

    End Sub

    Private Sub Cmbxemp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbxemp.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Cmbxemp.Text <> "" Then
                Cmbxemp_Leave(sender, e)
                Txtamt.Focus()
            Else
                Cmbxemp.Focus()
            End If
        End If
    End Sub

    Private Sub Dtp1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp1.GotFocus
        Dim mnth As Integer
        mnth = Date.DaysInMonth(Year(Dtp1.Value), Month(Dtp1.Value))
        'Dtp1.MinDate = DateSerial(Year(Dtp1.Value), Month(Dtp1.Value), 1)
        Dtp1.MaxDate = DateSerial(Year(Dtp1.Value), Month(Dtp1.Value), 1).AddDays(mnth - 1)

    End Sub

    Private Sub Dtp1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtp1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmbxemp.Focus()
        End If
    End Sub

    Private Sub Cmbxemp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbxemp.Leave
        If Cmbxemp.Text <> "" Then
            txtid.Text = Cmbxemp.SelectedValue
            fetch_deptname()
            fetch_desiname()
        End If

    End Sub

    Private Sub Txtamt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtamt.Leave
        If Txtamt.Text <> "" And lev_foc = False Then
            Dim val As Integer = 0
            val = CInt(Txtamt.Text)
            If val <= 0 Then
                Txtamt.Text = ""
                Txtamt.BackColor = Color.PapayaWhip
                lev_foc = True
                MsgBox("Enter valid Value", MsgBoxStyle.Information, "Alert")
                Txtamt.Focus()
            End If
        End If
    End Sub
End Class
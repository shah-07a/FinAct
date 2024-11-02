Imports System.Data
Imports System.Data.SqlClient

Public Class FrmNmDetails

    Dim Info_Cty_Cmd As SqlCommand
    Dim Info_Cty_rdr As SqlDataReader
    Dim P_Roll_Fmly_Cmd As SqlCommand
    Dim P_Roll_Fmly_rdr As SqlDataReader
    Dim Add_Edit_Flag As Boolean = False
    Dim dgr As DataGridViewRow
    Dim cel As DataGridViewTextBoxCell
    Dim com As DataGridViewComboBoxCell
    Dim counter1 As Integer = 0
    Dim lstcnt As Integer = 0

    Private Sub Btnclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnclos.Click
        Dim totlshare As Double = 0
        Dim cnt As Integer = 0
        Dim totl As Integer = 0
        If DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0).Value <> "" Then
            totl = DataGridView1.Rows.Count
            While cnt < totl
                totlshare = totlshare + DataGridView1.Rows(cnt).Cells(3).Value
                cnt = cnt + 1
            End While
            If totlshare < 100 Then

                MsgBox(String.Format("Since Nominee's Share is less than 100% ,so either Add New Nominee Record or{0} Update the Share of Existing Nominees{0}", Environment.NewLine), MsgBoxStyle.Critical, "Nominee Details")
                BtnAdd.Focus()

            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub add_row_grid()

        dgr = New DataGridViewRow()


        cel = New DataGridViewTextBoxCell()
        cel.Value = ""
        dgr.Cells.Add(cel)

        com = New DataGridViewComboBoxCell
        com.Items.Add("Father")
        com.Items.Add("Mother")
        com.Items.Add("Brother")
        com.Items.Add("Sister")
        com.Items.Add("Daughter")
        com.Items.Add("Son")
        com.Items.Add("Wife")
     

        com.Value = com.Items(0)
        dgr.Cells.Add(com)


        com = New DataGridViewComboBoxCell
        com.Items.Add("Major")
        com.Items.Add("Minor")
      
        com.Value = com.Items(0)

        dgr.Cells.Add(com)

        cel = New DataGridViewTextBoxCell()
        cel.Value = ""
        dgr.Cells.Add(cel)
        cel = New DataGridViewTextBoxCell()
        cel.Value = ""
        dgr.Cells.Add(cel)
        cel = New DataGridViewTextBoxCell()
        cel.Value = ""
        dgr.Cells.Add(cel)
        cel = New DataGridViewTextBoxCell()
        cel.Value = ""
        dgr.Cells.Add(cel)
        'cel = New DataGridViewTextBoxCell()
        'cel.Value = ""
        'dgr.Cells.Add(cel)

        com = New DataGridViewComboBoxCell
        Try
            Info_Cty_Cmd = New SqlCommand("select cscid,cscctyname from FinactCscmstr where csctype='Outer'", FinActConn1)
            Info_Cty_rdr = Info_Cty_Cmd.ExecuteReader
            While Info_Cty_rdr.Read()
                If Info_Cty_rdr.HasRows = True Then
                    ' Cmbxctynomi.Items.Add(Info_Cty_Rdr("cscctyname"))
                    com.Items.Add(Info_Cty_rdr("cscctyname"))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Info_Cty_Cmd = Nothing
            Info_Cty_rdr.Close()

        End Try

        com.Value = com.Items(0)
        dgr.Cells.Add(com)


        cel = New DataGridViewTextBoxCell()
        cel.Value = ""
        dgr.Cells.Add(cel)


        cel = New DataGridViewTextBoxCell()
        cel.Value = 0
        dgr.Cells.Add(cel)

        DataGridView1.Rows.Add(dgr)


    End Sub

    
    Private Sub FrmNmDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HrPrData08DataSet.FinactPFNomi' table. You can move, or remove it, as needed.
        ' Me.FinactPFNomiTableAdapter.Fill(Me.HrPrData08DataSet.FinactPFNomi)
        Me.Text = "Nominee Details"
        LblSrch.Text = "Nominee Details of " & (Emname) & ""
        Me.Size = New System.Drawing.Point(756, 270)


    End Sub

   
    Private Sub BtnUpdt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdt.Click
        lstcnt = 0
        lstcnt = DataGridView1.Rows.Count
        'counter1 = 0
        'While counter1 < lstcnt
        '    If DataGridView1.Rows(counter1).Cells(0).Value = "" Then
        '        'And DataGridView1.Rows(counter1).Cells(3).Value = 0 Or DataGridView1.Rows(counter1).Cells(4).Value = "" Then
        '        DataGridView1.Rows.Remove(Me.DataGridView1.SelectedRows(0))
        '    End If
        'End While
        counter1 = 0
        While counter1 < lstcnt

            If DataGridView1.Rows(counter1).Cells(2).Value = "Minor" And DataGridView1.Rows(counter1).Cells(7).Value = "" Then
                MsgBox("If Nominee is Major then Guardian's name must be filled", MsgBoxStyle.Information, "Guardian's Name")
                Me.DataGridView1.CurrentCell = DataGridView1.Rows(counter1).Cells(7)
                Exit Sub
            End If
            counter1 += 1
        End While
        counter1 = 0
        While counter1 < lstcnt

            If DataGridView1.Rows(counter1).Cells(2).Value = "Major" And DataGridView1.Rows(counter1).Cells(7).Value <> "" Then
                DataGridView1.Rows(counter1).Cells(7).Value = ""
            End If
            counter1 += 1
        End While
        Add_Edit_Flag = False
        EmpNomineeSaverec()
    End Sub


    Private Sub EmpNomineeSaverec()
      
        Dim PFId As Integer = 0
        lstcnt = 0
        lstcnt = DataGridView1.Rows.Count

        Dim Ctyid3 As Integer
        counter1 = 0
        While counter1 < lstcnt
            If DataGridView1.Rows(counter1).Cells(9).Value = 0 Then
                Add_Edit_Flag = True
            ElseIf DataGridView1.Rows(counter1).Cells(9).Value <> 0 Then
                Add_Edit_Flag = False
            End If
            Try
                Info_Cty_Cmd = New SqlCommand("select cscid from FinactCscmstr where cscctyname=@city", FinActConn)
                Info_Cty_Cmd.Parameters.AddWithValue("@city", DataGridView1.Rows(counter1).Cells(7).Value)
                Info_Cty_rdr = Info_Cty_Cmd.ExecuteReader

                Info_Cty_rdr.Read()
                If Info_Cty_rdr.HasRows = True Then
                    Ctyid3 = Info_Cty_rdr("cscid")
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Info_Cty_Cmd = Nothing
                Info_Cty_rdr.Close()
            End Try

            Try
                Info_Cty_Cmd = New SqlCommand("select max(empPfEsiId) from FinActEmpPfEsi where emppfdelstatus=1", FinActConn)

                Info_Cty_rdr = Info_Cty_Cmd.ExecuteReader

                Info_Cty_rdr.Read()
                If Info_Cty_rdr.HasRows = True Then
                    PFId = Info_Cty_rdr(0)
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Info_Cty_Cmd = Nothing
                Info_Cty_rdr.Close()
            End Try

            Try
                If Add_Edit_Flag = True Then
                    P_Roll_Fmly_Cmd = New SqlCommand("Finact_NmDetls_Insert", FinActConn)
                    P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
                    ' fetch_empid()

                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("PfConcrnId", Fetch_PFId)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmadusrid", Current_UsrId)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmaddt", Now)

                ElseIf Add_Edit_Flag = False Then
                    P_Roll_Fmly_Cmd = New SqlCommand("Finact_NmDetails_Update", FinActConn)
                    P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("PfConcrnId", Fetch_PFId)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@NmId", DataGridView1.Rows(counter1).Cells(9).Value)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmedtusrid", Current_UsrId)
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmedtdt", Now)
                End If
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmdelstatus", 1)

                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnominame", DataGridView1.Rows(counter1).Cells(0).Value)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomireltn", DataGridView1.Rows(counter1).Cells(1).Value)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomidob", DataGridView1.Rows(counter1).Cells(10).Value)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomiadrs", DataGridView1.Rows(counter1).Cells(4).Value)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomiadrs1", DataGridView1.Rows(counter1).Cells(5).Value)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomictyid", Ctyid3)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomipin", DataGridView1.Rows(counter1).Cells(8).Value)
                If DataGridView1.Rows(counter1).Cells(2).Value = "Major" Then
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomistatus", 1)       'If Status is Major
                Else
                    P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomistatus", 0)       'If Status is Minor
                End If
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomigrdian", DataGridView1.Rows(counter1).Cells(6).Value)
                P_Roll_Fmly_Cmd.Parameters.AddWithValue("@empnomishare", DataGridView1.Rows(counter1).Cells(3).Value)
                P_Roll_Fmly_Cmd.ExecuteNonQuery()
              


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                P_Roll_Fmly_Cmd = Nothing
            End Try
            counter1 = counter1 + 1
        End While
        If Add_Edit_Flag = False Then
            MsgBox("Record has been updated successfully", MsgBoxStyle.Information, "Update Record")
        ElseIf Add_Edit_Flag = True Then
            MsgBox("Record has been saved successfully", MsgBoxStyle.Information, "Save Record")
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click

        Try
            P_Roll_Fmly_Cmd = New SqlCommand("Finact_NmDetls_delete", FinActConn)
            P_Roll_Fmly_Cmd.CommandType = CommandType.StoredProcedure
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("PfConcrnId", Fetch_PFId)
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@NmId", DataGridView1.SelectedRows(0).Cells(9).Value)

            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmdelusrid", Current_UsrId)
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmdeldt", Now)
            P_Roll_Fmly_Cmd.Parameters.AddWithValue("@Nmdelstatus", 0)


            P_Roll_Fmly_Cmd.ExecuteNonQuery()
            DataGridView1.Rows.Remove(Me.DataGridView1.SelectedRows(0))
            MsgBox("Current Record has been Deleted", MsgBoxStyle.Information, "Record Deleted")

        Catch EX As Exception
            MsgBox(EX.Message)
        Finally
            P_Roll_Fmly_Cmd = Nothing

        End Try
    End Sub

   
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        add_row_grid()
        Me.DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0)
    End Sub
End Class

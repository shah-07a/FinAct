Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCrRptEmpEsi
    Inherits System.Windows.Forms.Form
    Dim Esi_Cmd As SqlCommand
    Dim Esi_Rdr As SqlDataReader
    Dim Esi_Cmd1 As SqlCommand
    Dim Esi_Rdr1 As SqlDataReader
    Dim Esi_Cmd2 As SqlCommand
    Dim Esi_Rdr2 As SqlDataReader
    Dim Strtminyear As Date
    Dim mindtpick2 As Date

    Private Sub FrmEmpEsi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Left = 0
        Me.Top = 0
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        fetch_Costrtdate()
        Dtpick1.MinDate = Strtminyear
        Dtpick1.Focus()

    End Sub

    Private Sub fill_temptbl()

        Dim frmdt As Date
        Dim todt As Date

        '--------------------------to delete recrds in backend ----------

        Try
            Esi_Cmd = New SqlCommand("Temp_EsiContri_Delete", FinActConn)
            Esi_Cmd.CommandType = CommandType.StoredProcedure
            Esi_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Esi_Cmd = Nothing
        End Try

        '-----------------------------to save recrds in backend ----------
        Dim srno As Integer = 1
        Dim pres As Double = 0.0
        Dim fetch_mainempid As Integer = 0
        frmdt = Dtpick1.Value.Date
        todt = dtpick2.Value.Date

        Try
            'Esi_Cmd = New SqlCommand("Select empid,empname,empEsicno,empDispensry,empjndt from  finactEmpPfEsi inner join finactEmpMstr  on empPfconcrnid=empid where finactempmstr.empdelstatus= 1  and finactEmpPfEsi.empesiapli= 1  and finactempmstr.empjndt<='" & (frmdt.Date) & "' and  finactempmstr.empjndt<='" & (todt.Date) & "'", FinActConn)
            Esi_Cmd = New SqlCommand("Temp_Esi_Rpt_SelectAll", FinActConn)
            Esi_Cmd.CommandType = CommandType.StoredProcedure
            Esi_Cmd.Parameters.AddWithValue("@Strtdt", frmdt.Date)
            Esi_Cmd.Parameters.AddWithValue("@enddt", todt.Date)
            Esi_Rdr = Esi_Cmd.ExecuteReader
            While Esi_Rdr.Read()

                If Esi_Rdr.IsDBNull(0) = False Then
                    If Esi_Rdr.HasRows = True Then

                        Esi_Cmd1 = New SqlCommand("Temp_EsiContri_Insert", FinActConn1)
                        Esi_Cmd1.CommandType = CommandType.StoredProcedure
                        Esi_Cmd1.Parameters.AddWithValue("@EsiSrNo", srno)
                        Esi_Cmd1.Parameters.AddWithValue("@EsiInsNo", Esi_Rdr(2))
                        Esi_Cmd1.Parameters.AddWithValue("@EsiEmpName", Esi_Rdr(1))
                        Esi_Cmd1.Parameters.AddWithValue("@EsiEmpId", Esi_Rdr(0))

                        fetch_mainempid = Esi_Rdr(0)

                        '=================present
                        Esi_Cmd2 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and Attddt  between'" & (frmdt.Date) & "'and'" & (todt.Date) & "' ", FinActConn2)
                        Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                        Esi_Rdr2.Read()
                        If Esi_Rdr2.HasRows = True Then
                            pres = Esi_Rdr2(0)
                        Else
                            pres = 0
                        End If
                        Esi_Rdr2.Close()
                        Esi_Cmd2 = Nothing

                        Esi_Cmd2 = New SqlCommand("Select  AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and Attddt  between'" & (frmdt.Date) & "'and'" & (todt.Date) & "' ", FinActConn2)
                        Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                        While Esi_Rdr2.Read()
                            If Esi_Rdr2.HasRows = True Then
                                pres += 0.5
                            Else
                                pres += 0
                            End If
                        End While
                        Esi_Rdr2.Close()
                        Esi_Cmd2 = Nothing

                        Esi_Cmd1.Parameters.AddWithValue("@EsiWrkDays", pres)


                        '================================totslry
                        Dim slry As Double = 0.0
                        Dim overtm As Double = 0.0
                        Dim frmdt1 As Date
                        Dim todt1 As Date
                        frmdt1 = Dtpick1.Value.Date
                        todt1 = dtpick2.Value.Date

                        Esi_Cmd2 = New SqlCommand("Select Sum(AslryTotlern)  from FinactAutoSalary WHERE Aslrydelstatus='" & (0) & "'and Aslryempid='" & (fetch_mainempid) & "'and Aslrydt  between'" & (frmdt1.Date) & "'and'" & (todt1.Date) & "' ", FinActConn2)
                        Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                        Esi_Rdr2.Read()
                        If Esi_Rdr2.IsDBNull(0) = False Then
                            If Esi_Rdr2.HasRows = True Then
                                slry = Esi_Rdr2(0)
                            Else
                                slry = 0
                            End If
                        End If
                        Esi_Rdr2.Close()
                        Esi_Cmd2 = Nothing

                        Esi_Cmd2 = New SqlCommand("Select Sum(Aslryovrtmern)  from FinactAutoSalary WHERE Aslrydelstatus='" & (0) & "'and Aslryempid='" & (fetch_mainempid) & "'and  Aslrydt  between'" & (frmdt1.Date) & "'and'" & (todt1.Date) & "' ", FinActConn2)
                        Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                        Esi_Rdr2.Read()
                        If Esi_Rdr2.IsDBNull(0) = False Then
                            If Esi_Rdr2.HasRows = True Then
                                overtm = Esi_Rdr2(0)
                            Else
                                overtm = 0
                            End If
                        End If
                        Esi_Rdr2.Close()
                        Esi_Cmd2 = Nothing
                        slry = slry - overtm

                        Esi_Cmd1.Parameters.AddWithValue("@EsiTotWages", slry)

                        '===========fetch esi rt frm payhed
                        Dim rt As Double = 0.0
                        Dim esi_amt As Double = 0.0
                        Esi_Cmd2 = New SqlCommand("Select pheadrate  from Finactpayhead   where pheadtype='" & Trim("Contribution For Employers ESI") & "' and   pheaddelstatus=0 ", FinActConn2)
                        Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                        Esi_Rdr2.Read()
                        If Esi_Rdr2.IsDBNull(0) = False Then
                            If Esi_Rdr2.HasRows = True Then
                                rt = Esi_Rdr2(0)
                            Else
                                rt = 0
                            End If
                        End If
                        Esi_Rdr2.Close()
                        Esi_Cmd2 = Nothing
                        If rt <> 0 And slry <> 0 Then
                            esi_amt = FormatNumber((slry * rt) / 100, 2)
                            Esi_Cmd1.Parameters.AddWithValue("@EsiEmpContr", esi_amt)
                        Else
                            esi_amt = 0
                            Esi_Cmd1.Parameters.AddWithValue("@EsiEmpContr", esi_amt)
                        End If
                        If pres > 0 And slry > 0 Then
                            Dim wgs As Double = 0.0
                            wgs = slry / pres
                            Esi_Cmd1.Parameters.AddWithValue("@EsiDailyWages", wgs)
                        Else
                            Esi_Cmd1.Parameters.AddWithValue("@EsiDailyWages", 0)
                        End If

                        Esi_Cmd1.Parameters.AddWithValue("@EsiDispno", Esi_Rdr(3))
                        Esi_Cmd1.Parameters.AddWithValue("@EsiEmpjndt", Esi_Rdr(4))
                        Dim levdt As Date
                        Esi_Cmd2 = New SqlCommand("Select Empcateg ,empothrrelevdt from Finactempmstr inner join  finactempothr on empothrconcrnid=empid  where Empid='" & (fetch_mainempid) & "' and empdelstatus=1 and empcateg='" & ("Non-Working") & "' ", FinActConn2)
                        Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                        Esi_Rdr2.Read()
                        If Esi_Rdr2.HasRows = True Then
                            levdt = Esi_Rdr2(1)
                            Esi_Cmd1.Parameters.AddWithValue("@EsiEmpleavdt", levdt)
                            Esi_Cmd1.Parameters.AddWithValue("@EsiDrwing", "NO")
                        Else
                            Esi_Cmd1.Parameters.AddWithValue("@EsiEmpleavdt", "")
                            Esi_Cmd1.Parameters.AddWithValue("@EsiDrwing", "YES")
                        End If
                        Esi_Rdr2.Close()
                        Esi_Cmd2 = Nothing
                        Esi_Cmd1.ExecuteNonQuery()
                    End If
                End If
                srno += 1
                pres = 0
            End While '>>main cond
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Esi_Rdr.HasRows = False Then
                Esi_Rdr.Close()
                Esi_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "Search All")

            End If
            Esi_Rdr.Close()
            Esi_Cmd = Nothing
        End Try

    End Sub
    Private Sub Chbxall_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chbxall.CheckedChanged

        If Chbxall.Checked = True Then
            Combcatgry.Enabled = False
            fill_temptbl()
        Else
            Combcatgry.Enabled = True
        End If

    End Sub

    Private Sub Chbxall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chbxall.Click

        If Chbxall.Checked = True Then
            Combcatgry.Enabled = False
            fill_temptbl()
        Else
            Combcatgry.Enabled = True
        End If

    End Sub
    Private Sub fetch_empname()

        Dim frmdt As Date
        Dim todt As Date
        frmdt = Dtpick1.Value.Date
        todt = dtpick2.Value.Date

        Try
            Esi_Cmd = New SqlCommand("Select empname from finactEmpMstr where empdelstatus= 1 and finactempmstr.empjndt<='" & (frmdt.Date) & "' and  finactempmstr.empjndt<='" & (todt.Date) & "' order by empname", FinActConn)
            Esi_Rdr = Esi_Cmd.ExecuteReader
            While Esi_Rdr.Read()
                If Esi_Rdr.IsDBNull(0) = False Then
                    If Esi_Rdr.HasRows = True Then
                        Combcatgry.Items.Add(Esi_Rdr(0))
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Esi_Rdr.Close()
            Esi_Cmd = Nothing
        End Try

    End Sub

    Private Sub Combcatgry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combcatgry.GotFocus

        Combcatgry.Items.Clear()
        fetch_empname()

        If Combcatgry.Items.Count > 0 Then
            If Combcatgry.SelectedIndex = -1 Then
                Combcatgry.SelectedIndex = 0
            End If
            Combcatgry.DroppedDown = True
        End If

    End Sub
    Private Sub fetch_Costrtdate() '-------------to fetch srtdate,year of company and add items in year combo

        Try
            Esi_Cmd = New SqlCommand("Select Costrtdt from finactcogatemstr", FinActConn)
            Esi_Rdr = Esi_Cmd.ExecuteReader
            Esi_Rdr.Read()
            If Esi_Rdr.IsDBNull(0) = False Then
                If Esi_Rdr.HasRows = True Then
                    Strtminyear = Format(Esi_Rdr(0), "dd/MM/yyyy")
                Else
                    Strtminyear = Format("1 / 1 / 1900", "dd/MM/yyyy")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Esi_Rdr.Close()
            Esi_Cmd = Nothing
        End Try

    End Sub

    Private Sub Dtpick1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpick1.KeyDown

        If e.KeyCode = Keys.Enter Then
            dtpick2.Focus()
        End If

    End Sub

    Private Sub Dtpick1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtpick1.Leave

        Strtminyear = Dtpick1.Value

    End Sub

    Private Sub dtpick2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpick2.GotFocus

        dtpick2.MinDate = Strtminyear

    End Sub

    Private Sub FrmEmpEsi_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        Dtpick1.Focus()

    End Sub
    Private Sub fill_temptbl_empwse()

        Dim frmdt As Date
        Dim todt As Date
        '--------------------------to delete recrds in backend ----------

        Try
            Esi_Cmd = New SqlCommand("Temp_EsiContri_Delete", FinActConn)
            Esi_Cmd.CommandType = CommandType.StoredProcedure
            Esi_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Esi_Cmd = Nothing
        End Try


        '-----------------------------to save recrds in backend ----------
        Dim srno As Integer = 1
        Dim pres As Double = 0.0
        Dim fetch_mainempid As Integer = 0
        frmdt = Dtpick1.Value.Date
        todt = dtpick2.Value.Date

        Try
            ' Esi_Cmd = New SqlCommand("Select empid,empname,empEsicno,empDispensry,empjndt from  finactEmpPfEsi inner join finactEmpMstr  on empPfconcrnid=empid where finactempmstr.empdelstatus= 1  and finactEmpPfEsi.empesiapli= 1  and finactempmstr.empjndt<='" & (frmdt.Date) & "' and  finactempmstr.empjndt<='" & (todt.Date) & "' and  finactempmstr.empname='" & (Combcatgry.Text) & "'", FinActConn)
            Esi_Cmd = New SqlCommand("Temp_Esi_Rpt_SelectEmpWise", FinActConn)
            Esi_Cmd.CommandType = CommandType.StoredProcedure
            Esi_Cmd.Parameters.AddWithValue("@Strtdt", frmdt.Date)
            Esi_Cmd.Parameters.AddWithValue("@enddt", todt.Date)
            Esi_Cmd.Parameters.AddWithValue("@Employenm", Combcatgry.Text)
            Esi_Rdr = Esi_Cmd.ExecuteReader
            Esi_Rdr.Read()
            If Esi_Rdr.HasRows = True Then

                Esi_Cmd1 = New SqlCommand("Temp_EsiContri_Insert", FinActConn1)
                Esi_Cmd1.CommandType = CommandType.StoredProcedure
                Esi_Cmd1.Parameters.AddWithValue("@EsiSrNo", srno)
                Esi_Cmd1.Parameters.AddWithValue("@EsiInsNo", Esi_Rdr(2))
                Esi_Cmd1.Parameters.AddWithValue("@EsiEmpName", Esi_Rdr(1))
                Esi_Cmd1.Parameters.AddWithValue("@EsiEmpId", Esi_Rdr(0))

                fetch_mainempid = Esi_Rdr(0)

                '=================present
                Esi_Cmd2 = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('Present') and Attddt  between'" & (frmdt.Date) & "'and'" & (todt.Date) & "' ", FinActConn2)
                Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                Esi_Rdr2.Read()
                If Esi_Rdr2.HasRows = True Then
                    pres = Esi_Rdr2(0)
                Else
                    pres = 0
                End If
                Esi_Rdr2.Close()
                Esi_Cmd2 = Nothing

                Esi_Cmd2 = New SqlCommand("Select  AttdStatus from Finact_Attd where AttdEmpid='" & (fetch_mainempid) & "' and AttdStatus in('PresntCumLev') and Attddt  between'" & (frmdt.Date) & "'and'" & (todt.Date) & "' ", FinActConn2)
                Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                While Esi_Rdr2.Read()
                    If Esi_Rdr2.HasRows = True Then
                        pres += 0.5
                    Else
                        pres += 0
                    End If
                End While
                Esi_Rdr2.Close()
                Esi_Cmd2 = Nothing

                Esi_Cmd1.Parameters.AddWithValue("@EsiWrkDays", pres)



                '================================totslry
                Dim slry As Double = 0.0
                Dim overtm As Double = 0.0
                Dim frmdt1 As Date
                Dim todt1 As Date
                frmdt1 = Dtpick1.Value.Date
                todt1 = dtpick2.Value.Date

                Esi_Cmd2 = New SqlCommand("Select Sum(AslryTotlern)  from FinactAutoSalary WHERE Aslrydelstatus='" & (0) & "'and Aslryempid='" & (fetch_mainempid) & "'and Aslrydt  between'" & (frmdt1.Date) & "'and'" & (todt1.Date) & "' ", FinActConn2)
                Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                Esi_Rdr2.Read()
                If Esi_Rdr2.IsDBNull(0) = False Then
                    If Esi_Rdr2.HasRows = True Then
                        slry = Esi_Rdr2(0)
                    Else
                        slry = 0
                    End If
                End If
                Esi_Rdr2.Close()
                Esi_Cmd2 = Nothing

                Esi_Cmd2 = New SqlCommand("Select Sum(Aslryovrtmern)  from FinactAutoSalary WHERE Aslrydelstatus='" & (0) & "'and Aslryempid='" & (fetch_mainempid) & "'and  Aslrydt  between'" & (frmdt1.Date) & "'and'" & (todt1.Date) & "' ", FinActConn2)
                Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                Esi_Rdr2.Read()
                If Esi_Rdr2.IsDBNull(0) = False Then
                    If Esi_Rdr2.HasRows = True Then
                        overtm = Esi_Rdr2(0)
                    Else
                        overtm = 0
                    End If
                End If
                Esi_Rdr2.Close()
                Esi_Cmd2 = Nothing
                slry = slry - overtm

                Esi_Cmd1.Parameters.AddWithValue("@EsiTotWages", slry)


                '===========fetch esi rt frm payhed

                Dim rt As Double = 0.0
                Dim esi_amt As Double = 0.0
                Esi_Cmd2 = New SqlCommand("Select pheadrate  from Finactpayhead   where pheadtype='" & Trim("Contribution For Employers ESI") & "' and   pheaddelstatus=0 ", FinActConn2)
                Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                Esi_Rdr2.Read()
                If Esi_Rdr2.IsDBNull(0) = False Then
                    If Esi_Rdr2.HasRows = True Then
                        rt = Esi_Rdr2(0)
                    Else
                        rt = 0
                    End If
                End If

                Esi_Rdr2.Close()
                Esi_Cmd2 = Nothing

                If rt <> 0 And slry <> 0 Then
                    esi_amt = FormatNumber((slry * rt) / 100, 2)
                    Esi_Cmd1.Parameters.AddWithValue("@EsiEmpContr", esi_amt)
                Else
                    esi_amt = 0
                    Esi_Cmd1.Parameters.AddWithValue("@EsiEmpContr", esi_amt)
                End If

                If pres > 0 And slry > 0 Then
                    Dim wgs As Double = 0.0
                    wgs = slry / pres
                    Esi_Cmd1.Parameters.AddWithValue("@EsiDailyWages", wgs)
                Else
                    Esi_Cmd1.Parameters.AddWithValue("@EsiDailyWages", 0)
                End If

                Esi_Cmd1.Parameters.AddWithValue("@EsiDispno", Esi_Rdr(3))
                Esi_Cmd1.Parameters.AddWithValue("@EsiEmpjndt", Esi_Rdr(4))
                Dim levdt As Date
                Esi_Cmd2 = New SqlCommand("Select Empcateg ,empothrrelevdt from Finactempmstr inner join  finactempothr on empothrconcrnid=empid  where Empid='" & (fetch_mainempid) & "' and empdelstatus=1 and empcateg='" & ("Non-Working") & "' ", FinActConn2)
                Esi_Rdr2 = Esi_Cmd2.ExecuteReader
                Esi_Rdr2.Read()
                If Esi_Rdr2.HasRows = True Then
                    levdt = Esi_Rdr2(1)
                    Esi_Cmd1.Parameters.AddWithValue("@EsiEmpleavdt", levdt)
                    Esi_Cmd1.Parameters.AddWithValue("@EsiDrwing", "NO")
                Else
                    Esi_Cmd1.Parameters.AddWithValue("@EsiEmpleavdt", "")
                    Esi_Cmd1.Parameters.AddWithValue("@EsiDrwing", "YES")
                End If
                Esi_Rdr2.Close()
                Esi_Cmd2 = Nothing

                Esi_Cmd1.ExecuteNonQuery()
            End If
            'End If
            srno += 1
            pres = 0
            '>>main cond
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Esi_Rdr.HasRows = False Then
                Esi_Rdr.Close()
                Esi_Cmd = Nothing
                MsgBox("No record has been found", MsgBoxStyle.Information, "Search Employee")

            End If
            Esi_Rdr.Close()
            Esi_Cmd = Nothing
        End Try

    End Sub

    Private Sub Combcatgry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combcatgry.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Combcatgry.Text <> "" Then
                fill_temptbl_empwse()
            End If
        End If

    End Sub

    Private Sub Combcatgry_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combcatgry.Leave

        If Combcatgry.Text <> "" Then
            fill_temptbl_empwse()
        End If

    End Sub

    Private Sub dtpick2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpick2.KeyDown

        If e.KeyCode = Keys.Enter Then
            Chbxall.Focus()
        End If

    End Sub

    Private Sub Chbxall_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chbxall.KeyDown

        If e.KeyCode = Keys.Enter Then
            Combcatgry.Focus()
        End If

    End Sub

End Class
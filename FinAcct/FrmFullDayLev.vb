Imports System.Data
Imports System.Data.SqlClient


Public Class FrmFullDayLev

    Dim Comp_Strtdt As Date
    Dim Attd_FullLeve_Cmd As SqlCommand
    Dim Attd_FullLeve_Rdr As SqlDataReader
    Dim Attd_FullLev_adaptr As SqlDataAdapter
    Dim ds As DataSet
    Dim add_flag As Boolean = False
    Dim Srch_Empid As Integer
    Dim cnfrmmsg As String
    Dim no_recrd As Boolean = False
    Dim count_rec As Integer


    Private Sub FrmFullDayLev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If attd_flag = True Then

            DtpkrDt.Text = FDayLev_dt
            Me.CmbSft.Text = FDayLev_Shift
            CmbxEmp.Text = FDayLev_Empnm
            Me.LblEmpid.Text = FdayLev_Empid

            Panel2.Enabled = False
            Label1.Enabled = False
            Label5.Enabled = False
            CmbxEmp.Enabled = False
            LblEmpid.Enabled = False

            DtpkrFrm.MinDate = DtpkrDt.Value
            DtpkrTo.MinDate = DtpkrDt.Value

            Me.Top = 0
            Me.Left = 0
            LstvewLev.Visible = False
            If Leve_flag = 4 Then
                Me.Text = "Full Day Leave"
                Me.Location = New System.Drawing.Point(5, 44)
                Me.Size = New System.Drawing.Point(546, 368)
                Panel2.Size = New System.Drawing.Point(515, 43)
                Panel1.Size = New System.Drawing.Point(515, 224)
                DtpkrFrm.Visible = True
                DtpkrTo.Visible = True
                Label3.Visible = True
                Label6.Visible = True
                Panel1.Size = New System.Drawing.Point(515, 224)
                Label6.Location = New System.Drawing.Point(14, 63)
                DtpkrFrm.Location = New System.Drawing.Point(127, 63)
                Label3.Location = New System.Drawing.Point(332, 63)
                DtpkrTo.Location = New System.Drawing.Point(399, 63)
                Label4.Location = New System.Drawing.Point(14, 112)
                CmType.Location = New System.Drawing.Point(127, 110)
                Label7.Location = New System.Drawing.Point(14, 156)
                TxtResn.Location = New System.Drawing.Point(127, 157)
            End If

        Else
            Me.Top = 0
            Me.Left = 0
            LstvewLev.Visible = False
            If Leve_flag = 4 Then
                Me.Text = "Full Day Leave"
                Me.Location = New System.Drawing.Point(5, 44)
                Me.Size = New System.Drawing.Point(546, 368)
                Panel2.Size = New System.Drawing.Point(515, 43)
                Panel1.Size = New System.Drawing.Point(515, 224)
                DtpkrFrm.Visible = True
                DtpkrTo.Visible = True
                Label3.Visible = True
                Label6.Visible = True
                Panel1.Size = New System.Drawing.Point(515, 224)
                Label6.Location = New System.Drawing.Point(14, 63)
                DtpkrFrm.Location = New System.Drawing.Point(127, 63)
                Label3.Location = New System.Drawing.Point(332, 63)
                DtpkrTo.Location = New System.Drawing.Point(399, 63)
                Label4.Location = New System.Drawing.Point(14, 112)
                CmType.Location = New System.Drawing.Point(127, 110)
                Label7.Location = New System.Drawing.Point(14, 156)
                TxtResn.Location = New System.Drawing.Point(127, 157)
            ElseIf Leve_flag = 2 Or Leve_flag = 3 Then
                Me.Location = New System.Drawing.Point(5, 44)
                Me.Size = New System.Drawing.Point(546, 348)
                Panel2.Size = New System.Drawing.Point(515, 43)
                Panel1.Size = New System.Drawing.Point(515, 224)
                DtpkrFrm.Visible = False
                DtpkrTo.Visible = False
                Label3.Visible = False
                Label6.Visible = False
                Panel1.Size = New System.Drawing.Point(515, 204)
                ' Label6.Location = New System.Drawing.Point(14, 63)
                ' DtpkrFrm.Location = New System.Drawing.Point(127, 63)
                ' Label3.Location = New System.Drawing.Point(332, 63)
                'DtpkrTo.Location = New System.Drawing.Point(399, 63)
                Label4.Location = New System.Drawing.Point(14, 63)
                CmType.Location = New System.Drawing.Point(127, 63)
                Label7.Location = New System.Drawing.Point(14, 112)
                TxtResn.Location = New System.Drawing.Point(127, 110)

            End If
            If Leve_flag = 2 Then
                Me.Text = "1st Half Day Leave"
            ElseIf Leve_flag = 3 Then
                Me.Text = "2nd Half Day Leave"
            End If
            fetch_Strtdt()
            fetch_Shift()
            Fetch_EmpName()
            If CmType.Items.Count > 0 Then
                If CmType.Text = "" Then
                    CmType.SelectedIndex = 0
                End If
            End If
            DtpkrDt.MinDate = Comp_Strtdt
            DtpkrFrm.MinDate = Comp_Strtdt
            ' DtpkrTo.MinDate = DtpkrFrm.Value.Date
            DtpkrDt.Focus()
        End If
    End Sub


    Private Sub fetch_Strtdt()
        Try
            Attd_FullLeve_Cmd = New SqlCommand("Select costrtdt from Finactcogatemstr  ", FinActConn)
            Attd_FullLeve_Rdr = Attd_FullLeve_Cmd.ExecuteReader
            While Attd_FullLeve_Rdr.Read
                If Attd_FullLeve_Rdr.HasRows = True Then
                    Comp_Strtdt = Attd_FullLeve_Rdr(0)
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_FullLeve_Rdr.Close()
            Attd_FullLeve_Cmd = Nothing
        End Try
    End Sub


    Private Sub fetch_Shift()
        CmbSft.Items.Clear()
        Try
            Attd_FullLeve_Cmd = New SqlCommand("Select EmpSift from FinactEmpTimeMstr where Empdelstatus=0 ", FinActConn)
            Attd_FullLeve_Rdr = Attd_FullLeve_Cmd.ExecuteReader
            While Attd_FullLeve_Rdr.Read
                If Attd_FullLeve_Rdr.HasRows = True Then
                    CmbSft.Items.Add(Attd_FullLeve_Rdr(0))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_FullLeve_Rdr.Close()
            Attd_FullLeve_Cmd = Nothing
        End Try

        If CmbSft.Items.Count > 0 Then
            If CmbSft.Text = "" Then
                CmbSft.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub Fetch_EmpName()

        Try
            Attd_FullLeve_Cmd = New SqlCommand("Select AttdEmpid,FinactEmpmstr.empname from Finact_Attd inner join  Finactempmstr on Finact_Attd.AttdEmpid=FinactEmpmstr.empid where AttdSft='" & (CmbSft.Text) & "'and Attddt<'" & (DtpkrDt.Value.Date) & "'  ", FinActConn)
            Attd_FullLev_adaptr = New SqlDataAdapter(Attd_FullLeve_Cmd)
            ds = New DataSet(Attd_FullLeve_Cmd.CommandText)
            Attd_FullLev_adaptr.Fill(ds)
            CmbxEmp.DataSource = ds.Tables(0)
            Me.CmbxEmp.ValueMember = "AttdEmpid"
            Me.CmbxEmp.DisplayMember = "empname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Attd_FullLeve_Cmd = Nothing
        End Try

        If CmbxEmp.Items.Count > 0 Then
            If CmbxEmp.Text = "" Then
                CmbxEmp.SelectedIndex = 0
            End If

        End If
    End Sub

    Private Sub DtpkrDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDt.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            CmbSft.Focus()
        End If
    End Sub

    Private Sub CmbSft_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSft.GotFocus
        If CmbSft.Items.Count > 0 Then
            If CmbSft.Text = "" Then
                CmbSft.SelectedIndex = 0
            End If
            CmbSft.DroppedDown = True

        End If
    End Sub


    Private Sub CmbSft_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbSft.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            CmbxEmp.Focus()
        End If
    End Sub

    Private Sub CmbxEmp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEmp.GotFocus
        If CmbxEmp.Items.Count > 0 Then
            If CmbxEmp.Text = "" Then
                CmbxEmp.SelectedIndex = 0

            End If
            CmbxEmp.DroppedDown = True

        End If
    End Sub

    Private Sub CmbxEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEmp.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            LblEmpid.Text = CmbxEmp.SelectedValue
            Chek_Recrd()
            If count_rec = 0 Then
                If Leve_flag = 4 Then
                    DtpkrFrm.Focus()
                ElseIf Leve_flag = 2 Or Leve_flag = 3 Then
                    CmType.Focus()
                End If
            ElseIf count_rec <> 0 Then
                MsgBox("Leave has already been issued to '" & (CmbxEmp.Text) & "'", MsgBoxStyle.Information, "Leave")
                DtpkrDt.Focus()

            End If
        End If
    End Sub


    Private Sub DtpkrFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrFrm.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            DtpkrTo.Focus()
        End If
    End Sub


    Private Sub DtpkrTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrTo.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            CmType.Focus()
        End If
    End Sub

    Private Sub CmType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmType.GotFocus
        If CmType.Items.Count > 0 Then
            If CmType.Text = "" Then
                CmType.SelectedIndex = 0

            End If
            CmType.DroppedDown = True
        End If
    End Sub


    Private Sub CmType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmType.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            TxtResn.Focus()
        End If
    End Sub

    Private Sub TxtResn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtResn.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
        End If
    End Sub

  
    Private Sub BtnCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCls.Click

        cnfrmmsg = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmmsg = vbYes Then
            Me.Close()

        End If
    End Sub

    Private Sub CmbxEmp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEmp.Leave
        LblEmpid.Text = CmbxEmp.SelectedValue
    End Sub

    Private Sub DtpkrDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpkrDt.ValueChanged
        DtpkrFrm.Text = DtpkrDt.Value.Date
        DtpkrTo.Text = DtpkrDt.Value.Date
    End Sub

    Private Sub DtpkrFrm_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpkrFrm.ValueChanged
        DtpkrTo.MinDate = DtpkrFrm.Value.Date
        DtpkrTo.Text = DtpkrFrm.Value.Date
    End Sub

    Private Sub Chek_Recrd()
        Try
            Attd_FullLeve_Cmd = New SqlCommand("Select count(LevId) from  Finact_Attd_FDLeave where LevEmpid='" & (LblEmpid.Text) & "'and LevDt='" & (DtpkrDt.Value.Date) & "'", FinActConn)
            Attd_FullLeve_Rdr = Attd_FullLeve_Cmd.ExecuteReader

            Attd_FullLeve_Rdr.Read()
            If Attd_FullLeve_Rdr.HasRows = True Then
                count_rec = Attd_FullLeve_Rdr(0)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
         
            Attd_FullLeve_Rdr.Close()
            Attd_FullLeve_Cmd = Nothing
        End Try


    End Sub



    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            add_flag = True
            If Leve_flag = 4 Then
                FullDay_Saverec()
            ElseIf Leve_flag = 2 Or Leve_flag = 3 Then
                HalfDay_Saverec()

            End If

        ElseIf BtnSave.Text = "&Edit" Then
            add_flag = False
            If Leve_flag = 4 Then
                FullDay_Saverec()
            ElseIf Leve_flag = 2 Or Leve_flag = 3 Then
                HalfDay_Saverec()

            End If
            BtnSave.Text = "&Save"
            BtnFnd.Text = "&Find"
            DtpkrDt.Enabled = True
            CmbSft.Enabled = True
            CmbxEmp.Enabled = True

        End If
    End Sub

    Private Sub FullDay_Saverec()

        Try
            If add_flag = True Then
                Attd_FullLeve_Cmd = New SqlCommand("Finact_Insert_FDLeave", FinActConn)
                Attd_FullLeve_Cmd.CommandType = CommandType.StoredProcedure
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevDt", DtpkrDt.Value.Date)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevShft", CmbSft.Text)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevEmpid", LblEmpid.Text)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevCateg", "Full Day Leave")
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levadusrid", Current_UsrId)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levaddt", Now)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levdelstatus", 0)
            ElseIf add_flag = False Then
                Attd_FullLeve_Cmd = New SqlCommand("Finact_Edit_FDLeave", FinActConn)
                Attd_FullLeve_Cmd.CommandType = CommandType.StoredProcedure
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevEmpid", LblEmpid.Text)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levedtusrid", Current_UsrId)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levedtdt", Now)

            End If

            Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevFrm", DtpkrFrm.Value.Date)
            Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevTo", DtpkrTo.Value.Date)
            Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevType", CmType.Text)
            Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevRsn", TxtResn.Text)

            Attd_FullLeve_Cmd.ExecuteNonQuery()
            If add_flag = True Then
                MsgBox("Record has been Saved Successfully.", MsgBoxStyle.Information, "Save")
            ElseIf add_flag = False Then
                MsgBox("Record has been Updated Successfully.", MsgBoxStyle.Information, "Edit")

            End If

            Clrvalue()

            DtpkrDt.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_FullLeve_Cmd = Nothing
        End Try

    End Sub


    Private Sub HalfDay_Saverec()
        Try
            If add_flag = True Then
                Attd_FullLeve_Cmd = New SqlCommand("Finact_Insert_FDLeave", FinActConn)
                Attd_FullLeve_Cmd.CommandType = CommandType.StoredProcedure
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevDt", DtpkrDt.Value.Date)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevShft", CmbSft.Text)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevEmpid", LblEmpid.Text)
                If Leve_flag = 2 Then
                    Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevCateg", "1st Half Day Leave")
                ElseIf Leve_flag = 3 Then
                    Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevCateg", "2nd Half Day Leave")
                End If
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levadusrid", Current_UsrId)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levaddt", Now)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levdelstatus", 0)
            ElseIf add_flag = False Then
                Attd_FullLeve_Cmd = New SqlCommand("Finact_Edit_EmpSuspend", FinActConn)
                Attd_FullLeve_Cmd.CommandType = CommandType.StoredProcedure
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevEmpid", LblEmpid.Text)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levedtusrid", Current_UsrId)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levedtdt", Now)

            End If

            Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevFrm", "1/1/1900")
            Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevTo", "1/1/1900")
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevType", CmType.Text)
                Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevRsn", TxtResn.Text)

                Attd_FullLeve_Cmd.ExecuteNonQuery()
                If add_flag = True Then
                    MsgBox("Record has been Saved Successfully.", MsgBoxStyle.Information, "Save")
                ElseIf add_flag = False Then
                    MsgBox("Record has been Updated Successfully.", MsgBoxStyle.Information, "Edit")

                End If

                Clrvalue()

                DtpkrDt.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_FullLeve_Cmd = Nothing
        End Try



    End Sub

    Private Sub Clrvalue()
        DtpkrDt.Text = Today
        If CmbSft.SelectedIndex > 0 Then
            CmbSft.SelectedIndex = 0

        End If

        If CmbxEmp.SelectedIndex > 0 Then
            CmbxEmp.SelectedIndex = 0

        End If

        LblEmpid.Text = ""
        DtpkrFrm.Text = Today
        DtpkrTo.Text = Today
        If CmType.SelectedIndex > 0 Then
            CmType.SelectedIndex = 0

        End If

        TxtResn.Clear()


    End Sub



    Private Sub Fetch_FullDay_Recrds()
        Try
            Attd_FullLeve_Cmd = New SqlCommand("Select empname from  FinactEmpmstr inner join Finact_Attd_FDLeave on FinactEmpmstr.empid=Finact_Attd_FDLeave.LevEmpid where Levdelstatus=0 and LevCateg='Full Day Leave' union Select empname from  FinactEmpmstr inner join Finact_Attd on FinactEmpmstr.empid=Finact_Attd.AttdEmpid where AttdRepStatus='Full Day Leave' ", FinActConn)
            Attd_FullLeve_Rdr = Attd_FullLeve_Cmd.ExecuteReader

            While Attd_FullLeve_Rdr.Read()
                If Attd_FullLeve_Rdr.HasRows = True Then
                    CmbxSrchEmp.Items.Add(Attd_FullLeve_Rdr(0))

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Attd_FullLeve_Rdr.HasRows = False Then
                MsgBox("System has found no record ", MsgBoxStyle.Information, "Find")
                no_recrd = True
                DtpkrDt.Focus()

            End If
            Attd_FullLeve_Rdr.Close()
            Attd_FullLeve_Cmd = Nothing
        End Try
    End Sub


    Private Sub Fetch_1HFDay_Recrds()
        Try
            Attd_FullLeve_Cmd = New SqlCommand("Select empname from  FinactEmpmstr inner join Finact_Attd_FDLeave on FinactEmpmstr.empid=Finact_Attd_FDLeave.LevEmpid where Levdelstatus=0 and LevCateg='1st Half Day Leave' union Select empname from  FinactEmpmstr inner join Finact_Attd on FinactEmpmstr.empid=Finact_Attd.AttdEmpid where AttdRepStatus='1stHalf Day Leave'", FinActConn)
            Attd_FullLeve_Rdr = Attd_FullLeve_Cmd.ExecuteReader

            While Attd_FullLeve_Rdr.Read()
                If Attd_FullLeve_Rdr.HasRows = True Then
                    CmbxSrchEmp.Items.Add(Attd_FullLeve_Rdr(0))

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Attd_FullLeve_Rdr.HasRows = False Then
                MsgBox("System has found no record ", MsgBoxStyle.Information, "Find")
                no_recrd = True
                DtpkrDt.Focus()

            End If
            Attd_FullLeve_Rdr.Close()
            Attd_FullLeve_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_2HFDay_Recrds()
        Try
            Attd_FullLeve_Cmd = New SqlCommand("Select empname from  FinactEmpmstr inner join Finact_Attd_FDLeave on FinactEmpmstr.empid=Finact_Attd_FDLeave.LevEmpid where Levdelstatus=0 and LevCateg='2nd Half Day Leave' union Select empname from  FinactEmpmstr inner join Finact_Attd on FinactEmpmstr.empid=Finact_Attd.AttdEmpid where AttdRepStatus='2ndHalf Day Leave'", FinActConn)
            Attd_FullLeve_Rdr = Attd_FullLeve_Cmd.ExecuteReader

            While Attd_FullLeve_Rdr.Read()
                If Attd_FullLeve_Rdr.HasRows = True Then
                    CmbxSrchEmp.Items.Add(Attd_FullLeve_Rdr(0))

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Attd_FullLeve_Rdr.HasRows = False Then
                MsgBox("System has found no record", MsgBoxStyle.Information, "Find")
                no_recrd = True
                DtpkrDt.Focus()

            End If
            Attd_FullLeve_Rdr.Close()
            Attd_FullLeve_Cmd = Nothing
        End Try
    End Sub

    Private Sub BtnFnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd.Click
        If BtnFnd.Text = "&Find" Then
            CmbxSrchEmp.Items.Clear()
            If Leve_flag = 4 Then
                Fetch_FullDay_Recrds()
            ElseIf Leve_flag = 2 Then
                Fetch_1HFDay_Recrds()
            ElseIf Leve_flag = 3 Then
                Fetch_2HFDay_Recrds()
            End If
            If no_recrd = False Then
                Panel1.Enabled = False
                Panel2.Enabled = False
                Panel3.Visible = True
                Panel3.Location = New System.Drawing.Point(12, 297)
                Me.Size = New System.Drawing.Point(546, 556)
                BtnFnd.Text = "&Delete"
                BtnSave.Text = "&Edit"
                CmbxSrchEmp.Focus()
            End If

        ElseIf BtnFnd.Text = "&Delete" Then
            cnfrmmsg = MsgBox("Are you sure to delete record?", MsgBoxStyle.YesNo, "Delete")
            If cnfrmmsg = vbYes Then

                Try
                    Attd_FullLeve_Cmd = New SqlCommand("Finact_Delete_FDleave", FinActConn)
                    Attd_FullLeve_Cmd.CommandType = CommandType.StoredProcedure
                    Attd_FullLeve_Cmd.Parameters.AddWithValue("@LevEmpid", LblEmpid.Text)
                    Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levdelusrid", Current_UsrId)
                    Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levdeldt", Now)
                    Attd_FullLeve_Cmd.Parameters.AddWithValue("@Levdelstatus", 1)
                    Attd_FullLeve_Cmd.ExecuteNonQuery()
                    MsgBox("Record has been Deleted Successfully.", MsgBoxStyle.Information, "Delete")
                    Clrvalue()
                    BtnSave.Text = "&Save"
                    BtnFnd.Text = "&Find"
                    DtpkrDt.Enabled = True
                    CmbSft.Enabled = True
                    CmbxEmp.Enabled = True
                    DtpkrDt.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Attd_FullLeve_Cmd = Nothing
                End Try
            End If
        End If

    End Sub

    Private Sub CmbxSrchEmp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSrchEmp.GotFocus
        If CmbxSrchEmp.Items.Count > 0 Then
            If CmbxSrchEmp.Text = "" Then
                CmbxSrchEmp.SelectedIndex = 0
            End If
            CmbxSrchEmp.DroppedDown = True
        End If
    End Sub

    Private Sub CmbxSrchEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSrchEmp.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            Dtpkr_Fnd.Focus()

        End If
    End Sub

    Private Sub Dtpkr_Fnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpkr_Fnd.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            CmbxType_Fnd.Focus()

        End If
    End Sub

    
    Private Sub Dtpkr_Fnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtpkr_Fnd.ValueChanged

    End Sub

    Private Sub CmbxType_Fnd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxType_Fnd.GotFocus
        If CmbxType_Fnd.Items.Count > 0 Then
            If CmbxType_Fnd.Text = "" Then
                CmbxType_Fnd.SelectedIndex = 0
            End If
            CmbxType_Fnd.DroppedDown = True
        End If
    End Sub

    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        Clrvalue()
        Panel1.Enabled = True
        Panel2.Enabled = True
        DtpkrDt.Enabled = True
        CmbSft.Enabled = True
        CmbxEmp.Enabled = True
        If Leve_flag = 4 Then
            Panel3.Visible = False
            Me.Size = New System.Drawing.Point(546, 368)
            If BtnFnd.Text = "&Delete" Then
                BtnFnd.Text = "&Find"
            End If
            If BtnSave.Text = "&Edit" Then
                BtnSave.Text = "&Save"
            End If

        ElseIf Leve_flag = 2 Or Leve_flag = 3 Then
            Panel3.Visible = False
            Me.Size = New System.Drawing.Point(546, 348)
            If BtnFnd.Text = "&Delete" Then
                BtnFnd.Text = "&Find"
            End If
            If BtnSave.Text = "&Edit" Then
                BtnSave.Text = "&Save"
            End If
        End If
    End Sub


    Private Sub Fetch_Srch_Empid()
        Try
            Attd_FullLeve_Cmd = New SqlCommand("Select empid from  FinactEmpmstr where empname='" & (CmbxSrchEmp.Text) & "'", FinActConn)
            Attd_FullLeve_Rdr = Attd_FullLeve_Cmd.ExecuteReader
            Attd_FullLeve_Rdr.Read()
            If Attd_FullLeve_Rdr.HasRows = True Then
                Srch_Empid = Attd_FullLeve_Rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_FullLeve_Rdr.Close()
            Attd_FullLeve_Cmd = Nothing
        End Try
    End Sub

    Private Sub CmbxType_Fnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxType_Fnd.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then

            Dim Lstvw As ListViewItem
            Fetch_Srch_Empid()

            If Leve_flag = 4 Then
                LstvewLev.Items.Clear()
                Try
                    Attd_FullLeve_Cmd = New SqlCommand("Select LevDt,LevShft,LevEmpid,Finactempmstr.empname,LevFrm,LevTo,LevType,LevRsn from  Finact_Attd_FDLeave inner join FinactEmpmstr on Finact_Attd_FDLeave.LevEmpid=FinactEmpmstr.empid where LevEmpid='" & (Srch_Empid) & "'and month(LevDt)='" & (Dtpkr_Fnd.Value.Date.Month) & "'and year(LevDt)='" & (Dtpkr_Fnd.Value.Date.Year) & "'and LevType='" & (CmbxType_Fnd.Text) & "'and Levdelstatus=0 and LevCateg='Full Day Leave' ", FinActConn)
                    Attd_FullLeve_Rdr = Attd_FullLeve_Cmd.ExecuteReader

                    While Attd_FullLeve_Rdr.Read()
                        If Attd_FullLeve_Rdr.HasRows = True Then

                            Lstvw = LstvewLev.Items.Add(Attd_FullLeve_Rdr(0))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(1))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(2))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(3))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(4))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(5))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(6))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(7))
                        End If
                    End While
                    If Attd_FullLeve_Rdr.HasRows = True Then
                        Me.Size = New System.Drawing.Point(730, 607)
                        Panel2.Size = New System.Drawing.Point(701, 43)
                        Panel1.Size = New System.Drawing.Point(701, 224)
                        Panel3.Visible = False
                        LstvewLev.Visible = True
                        If LstvewLev.Items.Count > 0 Then
                            LstvewLev.Focus()
                            LstvewLev.Items(0).Selected = True
                        End If
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    If Attd_FullLeve_Rdr.HasRows = False Then
                        MsgBox("System has found no Short Leave record of '" & (CmbxSrchEmp.Text) & "'", MsgBoxStyle.Information, "Find")

                    End If

                    Attd_FullLeve_Rdr.Close()
                    Attd_FullLeve_Cmd = Nothing
                End Try


            ElseIf Leve_flag = 2 Then
                Lstvew2.Items.Clear()
                Try
                    Attd_FullLeve_Cmd = New SqlCommand("Select LevDt,LevShft,LevEmpid,Finactempmstr.empname,LevType,LevRsn from  Finact_Attd_FDLeave inner join FinactEmpmstr on Finact_Attd_FDLeave.LevEmpid=FinactEmpmstr.empid where LevEmpid='" & (Srch_Empid) & "'and month(LevDt)='" & (Dtpkr_Fnd.Value.Date.Month) & "'and year(LevDt)='" & (Dtpkr_Fnd.Value.Date.Year) & "'and LevType='" & (CmbxType_Fnd.Text) & "'and Levdelstatus=0 and LevCateg='1st Half Day Leave' ", FinActConn)
                    Attd_FullLeve_Rdr = Attd_FullLeve_Cmd.ExecuteReader

                    While Attd_FullLeve_Rdr.Read()
                        If Attd_FullLeve_Rdr.HasRows = True Then

                            Lstvw = Lstvew2.Items.Add(Attd_FullLeve_Rdr(0))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(1))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(2))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(3))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(4))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(5))

                        End If
                    End While
                    If Attd_FullLeve_Rdr.HasRows = True Then
                        Me.Size = New System.Drawing.Point(730, 607)
                        Panel2.Size = New System.Drawing.Point(701, 43)
                        Panel1.Size = New System.Drawing.Point(701, 224)
                        Panel3.Visible = False
                        Lstvew2.Visible = True
                        If Lstvew2.Items.Count > 0 Then
                            Lstvew2.Focus()
                            Lstvew2.Items(0).Selected = True
                        End If
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    If Attd_FullLeve_Rdr.HasRows = False Then
                        MsgBox("System has found no Short Leave record of '" & (CmbxSrchEmp.Text) & "'", MsgBoxStyle.Information, "Find")

                    End If

                    Attd_FullLeve_Rdr.Close()
                    Attd_FullLeve_Cmd = Nothing
                End Try

            ElseIf Leve_flag = 3 Then
                Lstvew2.Items.Clear()
                Try
                    Attd_FullLeve_Cmd = New SqlCommand("Select LevDt,LevShft,LevEmpid,Finactempmstr.empname,LevType,LevRsn from  Finact_Attd_FDLeave inner join FinactEmpmstr on Finact_Attd_FDLeave.LevEmpid=FinactEmpmstr.empid where LevEmpid='" & (Srch_Empid) & "'and month(LevDt)='" & (Dtpkr_Fnd.Value.Date.Month) & "'and year(LevDt)='" & (Dtpkr_Fnd.Value.Date.Year) & "'and LevType='" & (CmbxType_Fnd.Text) & "'and Levdelstatus=0 and LevCateg='2nd Half Day Leave' ", FinActConn)
                    Attd_FullLeve_Rdr = Attd_FullLeve_Cmd.ExecuteReader

                    While Attd_FullLeve_Rdr.Read()
                        If Attd_FullLeve_Rdr.HasRows = True Then

                            Lstvw = Lstvew2.Items.Add(Attd_FullLeve_Rdr(0))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(1))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(2))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(3))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(4))
                            Lstvw.SubItems.Add(Attd_FullLeve_Rdr(5))

                        End If
                    End While
                    If Attd_FullLeve_Rdr.HasRows = True Then
                        Me.Size = New System.Drawing.Point(730, 607)
                        Panel2.Size = New System.Drawing.Point(701, 43)
                        Panel1.Size = New System.Drawing.Point(701, 224)
                        Panel3.Visible = False
                        Lstvew2.Visible = True
                        If Lstvew2.Items.Count > 0 Then
                            Lstvew2.Focus()
                            Lstvew2.Items(0).Selected = True
                        End If
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    If Attd_FullLeve_Rdr.HasRows = False Then
                        MsgBox("System has found no Short Leave record of '" & (CmbxSrchEmp.Text) & "'", MsgBoxStyle.Information, "Find")

                    End If

                    Attd_FullLeve_Rdr.Close()
                    Attd_FullLeve_Cmd = Nothing
                End Try

            End If

        End If
    End Sub


    Private Sub LstvewLev_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstvewLev.DoubleClick
        Panel1.Enabled = True
        Panel2.Enabled = True
        Dim indx As Integer

        indx = LstvewLev.SelectedItems(0).Index
        DtpkrDt.Text = LstvewLev.Items(indx).SubItems(0).Text
        CmbSft.Text = LstvewLev.Items(indx).SubItems(1).Text
        MsgBox(LstvewLev.Items(indx).SubItems(2).Text)
        LblEmpid.Text = LstvewLev.Items(indx).SubItems(2).Text
        CmbxEmp.Text = LstvewLev.Items(indx).SubItems(3).Text
        DtpkrFrm.Text = LstvewLev.Items(indx).SubItems(4).Text
        DtpkrTo.Text = LstvewLev.Items(indx).SubItems(5).Text
        CmType.Text = LstvewLev.Items(indx).SubItems(6).Text
        TxtResn.Text = LstvewLev.Items(indx).SubItems(7).Text
      
        Me.Size = New System.Drawing.Point(546, 368)
        Panel2.Size = New System.Drawing.Point(515, 43)
        Panel1.Size = New System.Drawing.Point(515, 224)
        LstvewLev.Visible = False
        DtpkrDt.Enabled = False
        CmbSft.Enabled = False
        CmbxEmp.Enabled = False
        DtpkrFrm.Focus()

    End Sub


    Private Sub Lstvew2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lstvew2.DoubleClick
        Panel1.Enabled = True
        Panel2.Enabled = True
        Dim indx As Integer

        indx = Lstvew2.SelectedItems(0).Index
        DtpkrDt.Text = Lstvew2.Items(indx).SubItems(0).Text
        CmbSft.Text = Lstvew2.Items(indx).SubItems(1).Text
        LblEmpid.Text = Lstvew2.Items(indx).SubItems(2).Text
        CmbxEmp.Text = Lstvew2.Items(indx).SubItems(3).Text
        CmType.Text = Lstvew2.Items(indx).SubItems(4).Text
        TxtResn.Text = Lstvew2.Items(indx).SubItems(5).Text

        Me.Size = New System.Drawing.Point(546, 368)
        Panel2.Size = New System.Drawing.Point(515, 43)
        Panel1.Size = New System.Drawing.Point(515, 220)
        Lstvew2.Visible = False
        DtpkrDt.Enabled = False
        CmbSft.Enabled = False
        CmbxEmp.Enabled = False
        CmType.Focus()

    End Sub

    
   
    Private Sub CmbxEmp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxEmp.SelectedIndexChanged

    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient


Public Class FrmMatrntyLev
    Dim Attd_Lev_Cmd As SqlCommand
    Dim Attd_Lev_Rdr As SqlDataReader
    Dim Compny_Strtdt As Date
    Dim MLevs As Integer
    Dim EmplId As Integer
    Dim EmpSId As Integer
    Dim no_of_recrds As Integer
    Dim LevDt, LevFrm, LevTo As Date
    Dim cnt_recrds As Integer
    Dim MaxDt As Date
    Dim MinDt As Date


    Private Sub FrmMatrntyLev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Text = "Maternity Leave"
        Dtpkrdt1.Focus()
        fetch_Strtdt()
        Me.Size = New System.Drawing.Point(487, 289)
        LblSrch.Visible = False
        CmbxSrchEmp.Visible = False
        LblPress.Visible = False
        TxtEmpnm.Visible = False


    End Sub


    Private Sub fetch_Strtdt()
        Try
            Attd_Lev_Cmd = New SqlCommand("Select costrtdt from Finactcogatemstr  ", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            While Attd_Lev_Rdr.Read
                If Attd_Lev_Rdr.HasRows = True Then
                    Compny_Strtdt = Attd_Lev_Rdr(0)
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try
    End Sub



    Private Sub fetch_Shift()
        CmbxShift.Items.Clear()
        Try
            Attd_Lev_Cmd = New SqlCommand("Select EmpSift from FinactEmpTimeMstr where Empdelstatus=0 ", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            While Attd_Lev_Rdr.Read
                If Attd_Lev_Rdr.HasRows = True Then
                    CmbxShift.Items.Add(Attd_Lev_Rdr(0))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try
    End Sub

    Private Sub CmbxShift_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxShift.GotFocus
        If CmbxShift.Items.Count > 0 Then
            CmbxShift.SelectedIndex = 0
            CmbxShift.DroppedDown = True
        End If
    End Sub


    Private Sub Fetch_EmpName()
        CmbxEmpnm.Items.Clear()

        Try
            Attd_Lev_Cmd = New SqlCommand("Select AttdEmpid,FinactEmpmstr.empname from Finact_Attd inner join  Finactempmstr on Finact_Attd.AttdEmpid=FinactEmpmstr.empid inner join FinactEmpInfo on FinactEmpmstr.empid=FinactEmpInfo.empconcrnid where AttdSft='" & (CmbxShift.Text) & "'and Attddt='" & (Dtpkrdt1.Value.Date) & "'and AttdStatus ='Present' and FinactEmpInfo.empsex='Female' and FinactEmpInfo.empMarital='Married'", FinActConn)
            ' Attd_SrtLeve_Cmd = New SqlCommand("Select empid,empname from FinactEmpmstr where empdelstatus=1 and empcateg='Working' and empothrsift='" & (CmbSft.Text) & "'and empjnDt<='" & (DtpkrDt_SL.Value.Date) & "' ", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            'Attd_Sift_Rdr.Read()
            While Attd_Lev_Rdr.Read()
                If Attd_Lev_Rdr.HasRows = True Then

                    CmbxEmpnm.Items.Add(Attd_Lev_Rdr(1))

                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Attd_Lev_Rdr.HasRows = False Then
                MsgBox("System has found no Present Status of " & (CmbxShift.Text) & " Shift.", MsgBoxStyle.Information, "Find Record")
                Dtpkrdt1.Focus()
            End If

            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try

        If CmbxEmpnm.Items.Count > 0 Then
            CmbxEmpnm.SelectedIndex = 0
            CmbxEmpnm.DroppedDown = True
        End If
    End Sub


    Private Sub CmbxShift_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxShift.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            CmbxEmpnm.Focus()
            Fetch_EmpName()
        End If

    End Sub

    Private Sub Dtpkrdt1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpkrdt1.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            CmbxShift.Focus()
        End If
    End Sub

    Private Sub Find_recrd()
        Try
            Attd_Lev_Cmd = New SqlCommand("Select count(MLevDt) from Finact_Attd_MatrnityLev where MLevEmpId ='" & (EmplId) & "'", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            Attd_Lev_Rdr.Read()
            If Attd_Lev_Rdr.HasRows = True Then

                no_of_recrds = Attd_Lev_Rdr(0)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_MLevDt()
        Try
            Attd_Lev_Cmd = New SqlCommand("Select MLevDt,MLevFrm,MLevTo from Finact_Attd_MatrnityLev where MLevEmpId ='" & (EmplId) & "'", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            Attd_Lev_Rdr.Read()
            If Attd_Lev_Rdr.HasRows = True Then

                LevDt = Attd_Lev_Rdr(0)
                LevFrm = Attd_Lev_Rdr(1)
                LevTo = Attd_Lev_Rdr(2)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_MLevDt_Fnd()
        Try
            Attd_Lev_Cmd = New SqlCommand("Select MLevDt,MLevFrm,MLevTo from Finact_Attd_MatrnityLev where MLevEmpId ='" & (EmpSId) & "'", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            Attd_Lev_Rdr.Read()
            If Attd_Lev_Rdr.HasRows = True Then

                LevDt = Attd_Lev_Rdr(0)
                LevFrm = Attd_Lev_Rdr(1)
                LevTo = Attd_Lev_Rdr(2)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try
    End Sub

    Private Sub CmbxEmpnm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEmpnm.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            Fetch_Empid()
            Find_recrd()
            If no_of_recrds > 0 Then

                Fetch_MLevDt()

                If Dtpkrdt1.Value.Date > LevTo Then
                    DtpkrDt2.Focus()
                ElseIf Dtpkrdt1.Value.Date < LevTo Then
                    MsgBox("This leave has already been assigned to '" & (CmbxEmpnm.Text) & "' from '" & (LevFrm) & "' to '" & (LevTo) & "'", MsgBoxStyle.Information, "Maternity Leave")
                    CmbxEmpnm.Focus()
                End If
            Else
                DtpkrDt2.Focus()
            End If
        End If
    End Sub

    Private Sub DtpkrDt2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrDt2.GotFocus
        DtpkrDt2.MinDate = Dtpkrdt1.Value.Date
        DtpkrDt2.Value = DtpkrDt2.MinDate

    End Sub


    Private Sub DtpkrDt2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDt2.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            DtpkrDt3.Focus()
        End If
    End Sub

    Private Sub DtpkrDt3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrDt3.GotFocus
        DtpkrDt3.MinDate = DtpkrDt2.Value.Date
        Fetch_MLeaves()
        DtpkrDt3.MaxDate = DtpkrDt2.Value.Date.AddDays(+MLevs)
    End Sub

    Private Sub DtpkrDt3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDt3.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            CmbxType.Focus()
            If CmbxType.Items.Count > 0 Then
                CmbxType.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub CmbxType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxType.GotFocus
        If CmbxType.Items.Count > 0 Then
            CmbxType.SelectedIndex = 0
            CmbxType.DroppedDown = True
        End If
    End Sub


    Private Sub CmbxType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxType.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
        End If
    End Sub

    Private Sub BtnCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCls.Click
        Dim Cnfrm_Msg As String
        Cnfrm_Msg = MsgBox("Are you sure to Exit?", MsgBoxStyle.YesNo, "Close")
        If Cnfrm_Msg = vbYes Then
            Me.Close()
        End If

    End Sub


    Private Sub Fetch_MLeaves()
        Try
            Attd_Lev_Cmd = New SqlCommand("Select Empmaternitylv from FinactEmplevMstr where Empdelstatus=0 ", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            Attd_Lev_Rdr.Read()
            If Attd_Lev_Rdr.HasRows = True Then
                MLevs = Attd_Lev_Rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try

    End Sub



    Private Sub Fetch_Empid()
        Try
            Attd_Lev_Cmd = New SqlCommand("Select empid from  FinactEmpmstr where empname='" & (CmbxEmpnm.Text) & "'", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            Attd_Lev_Rdr.Read()

            If Attd_Lev_Rdr.HasRows = True Then

                EmplId = Attd_Lev_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try
    End Sub

 
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        If BtnSave.Text = "&Save" Then
            Fetch_Empid()
            Try
                Attd_Lev_Cmd = New SqlCommand("Finact_MatrnityLev_Insert", FinActConn)
                Attd_Lev_Cmd.CommandType = CommandType.StoredProcedure
                Attd_Lev_Cmd.Parameters.AddWithValue("@MLevDt", Dtpkrdt1.Value.Date)
                Attd_Lev_Cmd.Parameters.AddWithValue("@MLevShft", CmbxShift.Text)

                Attd_Lev_Cmd.Parameters.AddWithValue("@MLevEmpId", EmplId)
                Attd_Lev_Cmd.Parameters.AddWithValue("@MLevFrm", DtpkrDt2.Value.Date)
                Attd_Lev_Cmd.Parameters.AddWithValue("@MLevTo", DtpkrDt3.Value.Date)
                Attd_Lev_Cmd.Parameters.AddWithValue("@MLevType", CmbxType.Text)
                Attd_Lev_Cmd.Parameters.AddWithValue("@MLevadusrid", Current_UsrId)
                Attd_Lev_Cmd.Parameters.AddWithValue("@MLevaddt", Now)
                Attd_Lev_Cmd.Parameters.AddWithValue("@MLevdelstatus", 0)
                Attd_Lev_Cmd.ExecuteNonQuery()
                MsgBox("Record has been Saved Successfully.", MsgBoxStyle.Information, "Save")
                CLRVAL()
                Dtpkrdt1.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Attd_Lev_Cmd = Nothing
            End Try

        ElseIf BtnSave.Text = "&Edit" Then

            Fetch_Attd_Recrd()
            If cnt_recrds = 0 Then
                Fetch_SrchEmpid()
                Try
                    Attd_Lev_Cmd = New SqlCommand("Finact_MatrnityLev_Edit", FinActConn)
                    Attd_Lev_Cmd.CommandType = CommandType.StoredProcedure

                    Attd_Lev_Cmd.Parameters.AddWithValue("@MLevEmpId", EmpSId)
                    Attd_Lev_Cmd.Parameters.AddWithValue("@MLevFrm", DtpkrDt2.Value.Date)
                    Attd_Lev_Cmd.Parameters.AddWithValue("@MLevTo", DtpkrDt3.Value.Date)
                    Attd_Lev_Cmd.Parameters.AddWithValue("@MLevType", CmbxType.Text)
                    Attd_Lev_Cmd.Parameters.AddWithValue("@MLevedtusrid", Current_UsrId)
                    Attd_Lev_Cmd.Parameters.AddWithValue("@MLevedtdt", Now)
                    Attd_Lev_Cmd.ExecuteNonQuery()
                    MsgBox("Record has been Updated Successfully.", MsgBoxStyle.Information, "Edit ")
                    CLRVAL()
                    BtnSave.Text = "&Save"
                    BtnFind.Text = "&Find"
                    Me.Size = New System.Drawing.Point(487, 289)
                    LblSrch.Visible = False
                    CmbxSrchEmp.Visible = False
                    LblPress.Visible = False
                    TxtEmpnm.Visible = False
                    Dtpkrdt1.Enabled = True
                    CmbxShift.Enabled = True
                    CmbxEmpnm.Visible = True
                    CmbxEmpnm.Enabled = True
                    Dtpkrdt1.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Attd_Lev_Cmd = Nothing
                End Try
            ElseIf cnt_recrds > 0 Then
                Fetch_MLevDt_Fnd()
                Fetch_Attd_Recrd_Maxdt()
                If DtpkrDt2.Value.Date < LevFrm Or DtpkrDt2.Value.Date > LevFrm Or DtpkrDt3.Value.Date < MaxDt Then
                    MsgBox("Can't edit the record as this leave has already been marked in Attendance from '" & (LevFrm) & "'to '" & (MaxDt) & "'", MsgBoxStyle.Information, "Edit")
                    BtnCncl.Focus()
                ElseIf DtpkrDt2.Value.Date = LevFrm And DtpkrDt3.Value.Date > MaxDt Then
                    Fetch_SrchEmpid()
                    Try
                        Attd_Lev_Cmd = New SqlCommand("Finact_MatrnityLev_Edit", FinActConn)
                        Attd_Lev_Cmd.CommandType = CommandType.StoredProcedure

                        Attd_Lev_Cmd.Parameters.AddWithValue("@MLevEmpId", EmpSId)
                        Attd_Lev_Cmd.Parameters.AddWithValue("@MLevFrm", DtpkrDt2.Value.Date)
                        Attd_Lev_Cmd.Parameters.AddWithValue("@MLevTo", DtpkrDt3.Value.Date)
                        Attd_Lev_Cmd.Parameters.AddWithValue("@MLevType", CmbxType.Text)
                        Attd_Lev_Cmd.Parameters.AddWithValue("@MLevedtusrid", Current_UsrId)
                        Attd_Lev_Cmd.Parameters.AddWithValue("@MLevedtdt", Now)
                        Attd_Lev_Cmd.ExecuteNonQuery()
                        MsgBox("Record has been Updated Successfully.", MsgBoxStyle.Information, "Edit ")
                        CLRVAL()
                        BtnSave.Text = "&Save"
                        BtnFind.Text = "&Find"
                        Me.Size = New System.Drawing.Point(487, 289)
                        LblSrch.Visible = False
                        CmbxSrchEmp.Visible = False
                        LblPress.Visible = False
                        TxtEmpnm.Visible = False
                        Dtpkrdt1.Enabled = True
                        CmbxShift.Enabled = True
                        CmbxEmpnm.Visible = True
                        CmbxEmpnm.Enabled = True
                        Dtpkrdt1.Focus()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Attd_Lev_Cmd = Nothing
                    End Try

                End If
            End If
        End If
    End Sub


    Private Sub CLRVAL()
        Dtpkrdt1.Value = Today
        If CmbxShift.SelectedIndex >= 0 Or CmbxShift.SelectedIndex < 0 Then
            CmbxShift.SelectedIndex = 0
        End If
        If CmbxEmpnm.Items.Count > 0 Then
            If CmbxEmpnm.SelectedIndex >= 0 Or CmbxEmpnm.SelectedIndex < 0 Then
                CmbxEmpnm.SelectedIndex = 0
            End If
        End If
       
        If CmbxType.SelectedIndex >= 0 Or CmbxType.SelectedIndex < 0 Then
            CmbxType.SelectedIndex = 0
        End If

    End Sub

    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        CLRVAL()
        Panel1.Enabled = True
        LblSrch.Visible = False
        CmbxSrchEmp.Visible = False
        LblPress.Visible = False
        TxtEmpnm.Visible = False
        Dtpkrdt1.Enabled = True
        CmbxShift.Enabled = True
        CmbxEmpnm.Visible = True
        CmbxEmpnm.Enabled = True
        Me.Size = New System.Drawing.Point(487, 289)
        BtnSave.Text = "&Save"
        BtnFind.Text = "&Find"
        Dtpkrdt1.Focus()

    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        If BtnFind.Text = "&Find" Then
            BtnFind.Text = "&Delete"
            BtnSave.Text = "&Edit"
            
            Fetch_SrchEmpnm()

        ElseIf BtnFind.Text = "&Delete" Then

            Fetch_Attd_Recrd()
            If cnt_recrds = 0 Then

                Dim cnfrm As String
                cnfrm = MsgBox("Are you sure to delete record?", MsgBoxStyle.YesNo, "Delete")
                If cnfrm = vbYes Then

                    Fetch_SrchEmpid()
                    Try
                        Attd_Lev_Cmd = New SqlCommand("Finact_MatrnityLev_Delete", FinActConn)
                        Attd_Lev_Cmd.CommandType = CommandType.StoredProcedure

                        Attd_Lev_Cmd.Parameters.AddWithValue("@MLevEmpId", EmpSId)
                        Attd_Lev_Cmd.Parameters.AddWithValue("@MLevdelusrid", Current_UsrId)
                        Attd_Lev_Cmd.Parameters.AddWithValue("@MLevdeldt", Now)
                        Attd_Lev_Cmd.Parameters.AddWithValue("@MLevdelstatus", 1)
                        Attd_Lev_Cmd.ExecuteNonQuery()

                        MsgBox("Record has been Deleted Successfully.", MsgBoxStyle.Information, "Delete ")
                        CLRVAL()
                        LblSrch.Visible = False
                        CmbxSrchEmp.Visible = False
                        LblPress.Visible = False
                        TxtEmpnm.Visible = False
                        Me.Size = New System.Drawing.Point(487, 289)
                        CmbxEmpnm.Visible = True
                        Dtpkrdt1.Enabled = True
                        CmbxShift.Enabled = True
                        CmbxEmpnm.Enabled = True
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Attd_Lev_Cmd = Nothing
                    End Try
                    BtnSave.Text = "&Save"
                    BtnFind.Text = "&Find"
                    Dtpkrdt1.Focus()

                End If
            ElseIf cnt_recrds > 0 Then
                MsgBox("Can't delete this record as marking of Attendance has been started for this leave.", MsgBoxStyle.Information, "Delete")
                BtnCncl.Focus()
            End If
        End If
    End Sub

    Private Sub Fetch_SrchEmpnm()
        CmbxSrchEmp.Items.Clear()

        Try
            Attd_Lev_Cmd = New SqlCommand("Select empname from FinactEmpmstr inner join  Finact_Attd_MatrnityLev on FinactEmpmstr.empid=Finact_Attd_MatrnityLev.MLevEmpId where MLevdelstatus =0", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            While Attd_Lev_Rdr.Read()
                If Attd_Lev_Rdr.HasRows = True Then

                    CmbxSrchEmp.Items.Add(Attd_Lev_Rdr(0))

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Attd_Lev_Rdr.HasRows = False Then
                MsgBox("No Record found", MsgBoxStyle.Information, "Find Record")
                Me.Size = New System.Drawing.Point(487, 289)
                LblSrch.Visible = False
                CmbxSrchEmp.Visible = False
                LblPress.Visible = False
                TxtEmpnm.Visible = False
                BtnSave.Text = "&Save"
                BtnFind.Text = "&Find"
                Dtpkrdt1.Focus()
            ElseIf Attd_Lev_Rdr.HasRows = True Then
                Dtpkrdt1.Enabled = False
                Panel1.Enabled = False
                CmbxShift.Enabled = False
                LblSrch.Visible = True
                CmbxSrchEmp.Visible = True
                LblPress.Visible = True
                TxtEmpnm.Visible = True
                Me.Size = New System.Drawing.Point(487, 366)
                CmbxSrchEmp.Focus()
            End If

            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try

       
    End Sub


    Private Sub CmbxSrchEmp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSrchEmp.GotFocus
        If CmbxSrchEmp.Items.Count > 0 Then
            CmbxSrchEmp.SelectedIndex = 0
            CmbxSrchEmp.DroppedDown = True
        End If
    End Sub

    Private Sub Fetch_SrchEmpid()
        Try
            Attd_Lev_Cmd = New SqlCommand("Select empid from  FinactEmpmstr where empname='" & (CmbxSrchEmp.Text) & "'", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            Attd_Lev_Rdr.Read()

            If Attd_Lev_Rdr.HasRows = True Then

                EmpSId = Attd_Lev_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try
    End Sub


    Private Sub Fetch_Attd_Recrd()

        Fetch_MLevDt_Fnd()
        Try
            Attd_Lev_Cmd = New SqlCommand("Select Count(Attddt) from  Finact_Attd where Attddt between'" & (LevFrm.Date) & "'and'" & (LevTo.Date) & "'and AttdRepStatus='Maternity Leave'", FinActConn)
            ' Attd_Lev_Cmd = New SqlCommand("Select Attddt from  Finact_Attd where Attddt between '" & (LevFrm.Date) & "'and '" & (LevTo.Date) & "' and AttdRepStatus='Maternity Leave'", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            Attd_Lev_Rdr.Read()

            If Attd_Lev_Rdr.HasRows = True Then

                cnt_recrds = Attd_Lev_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try

    End Sub



    Private Sub Fetch_Attd_Recrd_Maxdt()

        Fetch_MLevDt_Fnd()
        Try
            Attd_Lev_Cmd = New SqlCommand("Select max(Attddt),min(Attddt) from  Finact_Attd where Attddt between'" & (LevFrm.Date) & "'and'" & (LevTo.Date) & "'and AttdRepStatus='Maternity Leave'", FinActConn)
            ' Attd_Lev_Cmd = New SqlCommand("Select Attddt from  Finact_Attd where Attddt between '" & (LevFrm.Date) & "'and '" & (LevTo.Date) & "' and AttdRepStatus='Maternity Leave'", FinActConn)
            Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
            Attd_Lev_Rdr.Read()

            If Attd_Lev_Rdr.HasRows = True Then

                MaxDt = Attd_Lev_Rdr(0)
                MinDt = Attd_Lev_Rdr(1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Attd_Lev_Rdr.Close()
            Attd_Lev_Cmd = Nothing
        End Try

    End Sub

    Private Sub CmbxSrchEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSrchEmp.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbxEmpnm.Visible = False
            Fetch_SrchEmpid()
            Try
                Attd_Lev_Cmd = New SqlCommand("Select MLevDt,MLevShft,MLevFrm,MLevTo,MLevType,Finactempmstr.empname from Finact_Attd_MatrnityLev inner join FinactEmpmstr on Finact_Attd_MatrnityLev.MLevEmpId=FinactEmpmstr.empid where MLevEmpId ='" & (EmpSId) & "'", FinActConn)
                Attd_Lev_Rdr = Attd_Lev_Cmd.ExecuteReader
                Attd_Lev_Rdr.Read()
                If Attd_Lev_Rdr.HasRows = True Then
                    CmbxEmpnm.Visible = False
                    TxtEmpnm.Visible = True
                    TxtEmpnm.Enabled = False
                    Dtpkrdt1.Text = Attd_Lev_Rdr(0)
                    CmbxShift.Text = Attd_Lev_Rdr(1)
                    DtpkrDt2.Text = Attd_Lev_Rdr(2)
                    DtpkrDt3.Text = Attd_Lev_Rdr(3)
                    CmbxType.Text = Attd_Lev_Rdr(4)
                    TxtEmpnm.Text = Attd_Lev_Rdr(5)
                    Panel1.Enabled = True
                    DtpkrDt2.Focus()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Attd_Lev_Rdr.Close()
                Attd_Lev_Cmd = Nothing
            End Try
        End If
    End Sub

   
End Class
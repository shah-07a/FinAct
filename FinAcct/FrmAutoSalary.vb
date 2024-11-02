
Imports System.data
Imports System.Data.SqlClient


Public Class FrmAutoSalary
    Dim cnt As Integer = 0
    '  Private Event MyEvent As MyEventHander
    'Delegate Sub de1(ByVal Enter As KeyEventHandler)
    'Public Event event1 As de1

    Dim cntr1 As Integer = 0
    Dim arr(100) As Integer
    Dim arr_eid(100) As Integer
    Dim lstvew As ListViewItem
    Dim Fetch_Ename_Cmd As SqlCommand
    Dim Fetch_Ename_Rdr As SqlDataReader
    Dim Auto_Slry_Cmd As SqlCommand
    Dim Auto_Slry_Rdr As SqlDataReader
    Dim no_recrd_flag As Boolean
    Dim EmpId As Integer
    Dim EmpDeptId As Integer
    Dim EmpDesigId As Integer
    Dim EmpBscSlry As Double
    Dim TotlDays As Integer
    Dim PerdaySalary As Double
    Dim Mnth As Integer
    Dim LnEffDt As Date
    Dim Loan_Salry_Cmd As SqlCommand
    Dim Loan_Salry_Rdr As SqlDataReader
    Dim Count_Instlmnt As Integer
    Dim dt As Date
    Dim Mnthval, Yearval As Integer
    Dim prevsdt As Date
    Dim prevsmnth As Integer
    Dim RateId As Integer
    Dim Count_Payhead As Integer
    Dim Count_SlabId As Integer
    Dim Min_Payhead As Integer
    Dim Payhead_Name As String
    Dim Payhead_Type As String
    Dim PheadType As String
    Dim indx As Integer
    Dim Ern_Deduc As String
    Dim Mnthname As String
    Dim Eid As Integer
    Dim Empname As String
    Dim Fetch_AslryId As Integer
    Dim Cid As Integer
    Dim DptType As String
    Dim Max_Payhead As Integer
    Dim no_of_payhed As Integer = 0
    Dim no_of_payhed1 As Integer = 0
    Dim all_flag As Boolean = False
    Dim Arr_Bscsalary(100) As Double
    Dim Arr_PheadType(100) As String
    Dim cntr As Integer = 0
    Dim str_wrkdys As Integer
    Dim all_ernamt As Double
    Dim all_advncamt As Double
    Dim all_loanamt As Double
    Dim all_payhedamt As Double
    Dim all_payhedamt_ern As Double
    Dim all_payhedamt_deduct As Double
    Dim All_Deptid As Integer
    Dim All_Desiid As Integer
    Dim ctr As Integer = 0
    Dim Employee_Id As Integer
    Dim i As Integer = 0
    Dim tot_recrds As Integer = 0
    Dim STRT As Integer = 0
    Dim INC_ARR As Integer = 0
    Dim phed_arr(100) As Double
    Dim Arr_Ern_Deduc(100) As String
    Dim j As Integer = 0
    Dim add_flag As Boolean
    Dim k As Integer = 0
    Dim Arr_Phed_Type2(100) As String
    Dim l As Integer = 0
    Dim arr_ern(100), arr_deduct(100) As Double
    Dim phed_ern, phed_deduc As Double
    Dim Ernamt As Integer
    Dim fnd_recrd As Integer = 0
    Dim Fetch_Empid As Integer
    Dim NetSalary, Totl_Ern, Totl_Deduc As Double
    Dim deduc_payhed As Double
    Dim add_payhed As Double
    Dim Wrkdays As Double
    Dim cnt_slip As Integer
    Dim r As Integer = 0
    Dim totl_rec As Integer
    Dim WrkDys_Arr(100) As Integer
    Dim p As Integer = 0
    Dim wrkdys_flag As Boolean = False
    Dim index As Integer = 0



    Private Sub FrmAutoSalary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        GrpBxPayHed.Visible = False
        Me.Size = New System.Drawing.Point(708, 688)
        PnlEmpDtl.Visible = True
        dt = DtpkrAutoSlry.Value.Date.AddMonths(-1)
        LblMnth.Text = MonthName(dt.Month)

        LblSelCritera.Visible = False
        CmbxSelCritera.Visible = False

        LblCateg.Visible = True
        CmbxCateg.Visible = True
        'ListView1.Visible = False
        DataGridAll.Visible = False
        BtnSave.Enabled = False

    End Sub

    Private Sub DtpkrAutoSlry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrAutoSlry.GotFocus
        DtpkrAutoSlry.MaxDate = Now


    End Sub

    Private Sub DtpkrAutoSlry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrAutoSlry.KeyDown
        If e.KeyCode = Keys.Enter Then

            RbOne.Checked = True
            RbOne.Focus()
        End If
    End Sub


    Private Sub RbOne_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbOne.CheckedChanged
        If RbOne.Checked = True Then
            Me.Size = New System.Drawing.Point(708, 688)
            PnlEmpDtl.Visible = True
            If BtnSave.Text = "&Save" Then
                'fetch_Cmbx_Ename()
                ' CmbxEname.Focus()
            End If
            all_flag = False
            LblSelCritera.Visible = False
            CmbxSelCritera.Visible = False
            LblCateg.Visible = False
            CmbxCateg.Visible = False
            LstvewAll.Visible = False
            DataGridAll.Visible = False
            BtnFnd.Enabled = True
            ' BtnSave.Location = New System.Drawing.Point(340, 600)
            BtnFnd.Visible = True
            'BtnFnd.Location = New System.Drawing.Point(440, 600)

        ElseIf RbOne.Checked = False Then
            BtnFnd.Text = "&Find"
            BtnFnd.Enabled = False
        End If
    End Sub

    Private Sub fetch_Cmbx_Ename()
        Dim days As Integer

        Dim dt As Date
        CmbxEname.Items.Clear()
        Dim PrevDate As Date
        Dim PrevMnth As Integer


        PrevDate = DtpkrAutoSlry.Value.Date.AddMonths(-1)
        PrevMnth = PrevDate.Month
        days = Date.DaysInMonth(PrevDate.Year, PrevDate.Month)
        Mnthname = MonthName(PrevMnth)
        dt = DateSerial(Year(DtpkrAutoSlry.Value.Date), Month(DtpkrAutoSlry.Value.Date), -1)

        Try

            Fetch_Ename_Cmd = New SqlCommand("Select empname from FinactEmpmstr where empdelstatus=1 and empcateg='Working'and empjnDt<='" & (dt) & "'order by empname ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            While Fetch_Ename_Rdr.Read
                If Fetch_Ename_Rdr.HasRows = True Then
                    CmbxEname.Items.Add(Fetch_Ename_Rdr(0))
                End If
            End While
            If CmbxEname.Items.Count > 0 Then
                CmbxEname.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            'If Fetch_Ename_Rdr.HasRows = False Then
            '    no_recrd_flag = True

            'End If
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
            'If no_recrd_flag = True Then
            '    '

            '    MsgBox("No Employee record found to generate Salary Slip ", MsgBoxStyle.Information, "Employee Name")
            'End If
        End Try


    End Sub

    Private Sub CmbxEname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEname.GotFocus
        ' fetch_Cmbx_Ename()
        If BtnSave.Text = "&Save" Then
            CmbxEname.DroppedDown = True
        End If
    End Sub

    Private Sub Fetch_DeptName()
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select deptname from finactdept where deptid='" & (EmpDeptId) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmpDeptId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.HasRows = True Then
                    LblDept.Text = Fetch_Ename_Rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_DesigName()
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select desiname from finactDesi where desiid='" & (EmpDesigId) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmpDesigId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.HasRows = True Then
                    LblDesig.Text = Fetch_Ename_Rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub Chk_Recrd()
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select count(Aslryid) from  FinactAutoSalary  where AslryEmpid='" & (EmpId) & "'and AslryMnth='" & (LblMnth.Text) & "'and AslryType=1and Aslrydelstatus=0", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_Rdr.Read()
            If Fetch_Ename_Rdr.HasRows = True Then

                fnd_recrd = Fetch_Ename_Rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub CmbxEname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEname.KeyDown
        If e.KeyCode = Keys.Enter Then
            If CmbxEname.SelectedIndex >= 0 Then
                Try
                    Fetch_Ename_Cmd = New SqlCommand("Select empid,empdeptid,empdesiid,empgrade,empjnDt from FinactEmpmstr where empname='" & (CmbxEname.Text) & "'", FinActConn)
                    Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
                    Fetch_Ename_Rdr.Read()
                    If Fetch_Ename_Rdr.HasRows = True Then
                        EmpId = Fetch_Ename_Rdr(0)
                        EmpDeptId = Fetch_Ename_Rdr(1)
                        EmpDesigId = Fetch_Ename_Rdr(2)
                        EmpBscSlry = Fetch_Ename_Rdr(3)
                        ' EmpJnDt = Fetch_Ename_Rdr(4)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Fetch_Ename_Rdr.Close()
                    Fetch_Ename_Cmd = Nothing
                End Try
                Chk_Recrd()
                If fnd_recrd = 0 Then
                    Fetch_WrkDays()
                    If Wrkdays > 0 Then
                        LblWrkDays.Text = Wrkdays
                        LblMnth.Text = Mnthname

                        LblBscSlry.Text = FormatNumber(EmpBscSlry, 2)
                        Fetch_DeptName()
                        Fetch_DesigName()
                        RbWithHoli.Checked = True
                        LblWrkDays.Text = Wrkdays
                        PerdaySalry()
                        Fetch_AdvncAmt()
                        Fetch_Loan()
                        LstvewPayhed.Items.Clear()
                        Fetch_Payhead_Name()
                        userdefin_slab()
                        LstvewPayhed.LabelEdit = True
                        'LstvewPayhed.Focus()
                        'LstvewPayhed.Items(0).Selected = True

                        PhedAmt.Focus()
                    ElseIf Wrkdays = 0 Then
                        MsgBox(String.Format("Salary Slip of '" & (CmbxEname.Text) & "' can't be generated.{0} (Working Days=0){0}", Environment.NewLine), MsgBoxStyle.Information, "Alert")
                        Exit Sub
                    End If
                  
                ElseIf fnd_recrd > 0 Then
                    MsgBox("Salary Slip has already been generated for '" & (CmbxEname.Text) & "'", MsgBoxStyle.Information, "Salary Slip")
                    DtpkrAutoSlry.Focus()
                    RbOne.Checked = False
                End If
            End If
        End If


    End Sub
    

    Private Sub PerdaySalry()
        TotlDays = Date.DaysInMonth(DtpkrAutoSlry.Value.Date.Year, Mnth)
        If all_flag = False Then
            PerdaySalary = FormatNumber(CDbl(LblBscSlry.Text / TotlDays), 2)
            LblErnAmt.Text = FormatNumber(CDbl(Wrkdays * PerdaySalary), 2)
        ElseIf all_flag = True And i < tot_recrds Then
            PerdaySalary = FormatNumber(CDbl(Arr_Bscsalary(cntr) / TotlDays), 2)
            all_ernamt = FormatNumber(CDbl(str_wrkdys * PerdaySalary), 2)
            LstvewAll.Items(i).SubItems(5).Text = all_ernamt
        End If



        ' HrSalry = FormatNumber(PerdaySalary() / 24, 2)

    End Sub

    Private Sub Fetch_WrkDays()
        Dim count As Integer
        Mnthvalue()
        If all_flag = False And wrkdys_flag = True Then
            Employee_Id = arr_eid(ctr)

        ElseIf all_flag = True Then
            Employee_Id = arr_eid(ctr)
        ElseIf all_flag = False Then
            Employee_Id = EmpId
        End If
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (Employee_Id) & "'and AttdStatus in('Present', 'Holiday','Paid Holiday') and month(Attddt)='" & (Mnth) & "'and year(Attddt)='" & (DtpkrAutoSlry.Value.Year) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmpId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.HasRows = True Then
                    If all_flag = False Then
                        Wrkdays = Fetch_Ename_Rdr(0)
                        WrkDys_Arr(p) = Fetch_Ename_Rdr(0)
                        p = p + 1
                        'LblWrkDays.Text = Fetch_Ename_Rdr(0)
                    ElseIf all_flag = True Then
                        count = LstvewAll.Items.Count
                        LstvewAll.Items(i).SubItems(4).Text = Fetch_Ename_Rdr(0)



                        ' lstvew.SubItems(4).Text = Fetch_Ename_Rdr(0)
                        str_wrkdys = Fetch_Ename_Rdr(0)
                        'lstvew.SubItems(5).Text = Fetch_Ename_Rdr(0)
                        'MsgBox(Fetch_Ename_Rdr(0))

                    End If


                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub Mnthvalue()

        If LblMnth.Text = "January" Then
            Mnth = 1
        ElseIf LblMnth.Text = "February" Then
            Mnth = 2
        ElseIf LblMnth.Text = "March" Then
            Mnth = 3
        ElseIf LblMnth.Text = "April" Then
            Mnth = 4
        ElseIf LblMnth.Text = "May" Then
            Mnth = 5
        ElseIf LblMnth.Text = "June" Then
            Mnth = 6
        ElseIf LblMnth.Text = "July" Then
            Mnth = 7
        ElseIf LblMnth.Text = "August" Then
            Mnth = 8
        ElseIf LblMnth.Text = "September" Then
            Mnth = 9
        ElseIf LblMnth.Text = "October" Then
            Mnth = 10
        ElseIf LblMnth.Text = "November" Then
            Mnth = 11
        ElseIf LblMnth.Text = "December" Then
            Mnth = 12
        End If


    End Sub


    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub RbWotHoli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbWotHoli.CheckedChanged
        If RbWotHoli.Checked = True Then
            Mnthvalue()
            Try
                Fetch_Ename_Cmd = New SqlCommand("Select count(AttdStatus) from Finact_Attd where AttdEmpid='" & (EmpId) & "'and AttdStatus ='Present' and month(Attddt)='" & (Mnth) & "'", FinActConn)
                Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
                If Trim(EmpId) <> "" Then
                    Fetch_Ename_Rdr.Read()
                    If Fetch_Ename_Rdr.HasRows = True Then
                        LblWrkDays.Text = Fetch_Ename_Rdr(0)
                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Fetch_Ename_Rdr.Close()
                Fetch_Ename_Cmd = Nothing
            End Try
            PerdaySalry()
            If PnlPayhed.Visible = True Then
                LblPhedErn.Text = FormatNumber(CDbl(LblPhedErn.Text) - Ernamt + CDbl(LblErnAmt.Text), 2)
                LblNetSlry.Text = FormatNumber(CDbl(LblPhedErn.Text) - CDbl(LblPhedDeduc.Text), 2)
            End If
        End If
    End Sub

    Private Sub RbWithHoli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbWithHoli.CheckedChanged
        If RbWithHoli.Checked = True Then

            Fetch_WrkDays()
            PerdaySalry()
            If PnlPayhed.Visible = True Then
                LblPhedErn.Text = FormatNumber(CDbl(LblPhedErn.Text) - Ernamt + CDbl(LblErnAmt.Text), 2)
                LblNetSlry.Text = FormatNumber(CDbl(LblPhedErn.Text) - CDbl(LblPhedDeduc.Text), 2)
            End If
        End If
    End Sub

    Private Sub Fetch_AdvncAmt()
        Mnthvalue()
        If all_flag = False Then
            Employee_Id = EmpId
        ElseIf all_flag = True Then
            Employee_Id = arr_eid(ctr)
        End If
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select AdvAmt from FinactAdvance where AdvEmpId='" & (Employee_Id) & "'and AdvStatus='Not Adjusted'  and Advdelstatus=1 ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmpId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.HasRows = True Then
                    If all_flag = False Then
                        LblAdvAmt.Text = FormatNumber(Fetch_Ename_Rdr(0), 2)
                    ElseIf all_flag = True Then
                        LstvewAll.Items(i).SubItems(6).Text = FormatNumber(Fetch_Ename_Rdr(0), 2)
                        all_advncamt = FormatNumber(Fetch_Ename_Rdr(0), 2)
                    End If
                ElseIf Fetch_Ename_Rdr.HasRows = False Then
                    If all_flag = False Then
                        LblAdvAmt.Text = FormatNumber(0, 2)
                    ElseIf all_flag = True Then
                        LstvewAll.Items(i).SubItems(6).Text = FormatNumber(0, 2)
                        all_advncamt = FormatNumber(0, 2)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub
    Private Sub Fetch_LnEffDt()

        'dt = DtpkrAutoSlry.Value.Date.AddMonths(-1)
        'Mnthval = dt.Month
        'Yearval = dt.Year
        If all_flag = False Then
            Employee_Id = EmpId
        ElseIf all_flag = True Then
            Employee_Id = arr_eid(ctr)
        End If
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select LnEffDt from FinactLoan where LnEmpId='" & (Employee_Id) & "'and LnStatus='Not Adjusted'and Lndelstatus=1 ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmpId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.HasRows = True Then
                    LnEffDt = Fetch_Ename_Rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub Count_Reduc_Instlmnt()

        'prevsdt = DtpkrAutoSlry.Value.Date.AddMonths(-1)
        ' prevsmnth = prevsdt.Month

        Fetch_LnEffDt()
        If all_flag = False Then
            Employee_Id = EmpId
        ElseIf all_flag = True Then
            Employee_Id = arr_eid(ctr)
        End If
        Try
            Loan_Salry_Cmd = New SqlCommand("select count(SlryLnDeduc) from FinactSlrySlip where SlryEmpid='" & (Employee_Id) & "'and Slrydelstatus=1 and SlryDt between '" & (LnEffDt) & "'and '" & (DtpkrAutoSlry.Value.Date) & "'", FinActConn)
            Loan_Salry_Rdr = Loan_Salry_Cmd.ExecuteReader
            Loan_Salry_Rdr.Read()
            If Loan_Salry_Rdr.IsDBNull(0) = False Then
                Count_Instlmnt = Loan_Salry_Rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Loan_Salry_Rdr.Close()
            Loan_Salry_Cmd = Nothing
        End Try
    End Sub

    Private Sub Prevs_Loan_Instlmnt()

        Dim ActualInstlmnt As Integer

        ' prevsdt = DtpkrAutoSlry.Value.Date.AddMonths(-1)
        'prevsmnth = prevsdt.Month
        If all_flag = False Then
            Employee_Id = EmpId
        ElseIf all_flag = True Then
            Employee_Id = arr_eid(ctr)
        End If
        Try
            Loan_Salry_Cmd = New SqlCommand("select SlryLnDeduc,ActualLnInstlmnt from FinactSlrySlip where SlryEmpid='" & (Employee_Id) & "'and Slrydelstatus=1 and month(SlryDt)='" & (Mnth) & "'", FinActConn)
            Loan_Salry_Rdr = Loan_Salry_Cmd.ExecuteReader
            Loan_Salry_Rdr.Read()
            If Loan_Salry_Rdr.HasRows = True Then
                'LnDeduction = FormatNumber(Loan_Salry_Rdr(0), 2)
                ActualInstlmnt = FormatNumber(Loan_Salry_Rdr(1), 2)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Loan_Salry_Rdr.Close()
            Loan_Salry_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Loan()
        Fetch_LnEffDt()
        Dim LnType As String
        Dim Reduc_Loan_Instlmnt, Reduc_Loan_Amt, Reduc_Loan_Intrst, MnthlyInst As Double
        Dim Reduc_Loan_RepayPrd As Integer
        ' Dim Mnthval1 As Integer
        Dim Principal, Deduct, Intrstvalue, Amount As Double
        Dim IntrstAppli As Boolean

        'Mnthval1 = DtpkrAutoSlry.Value.Date.Month
        dt = DtpkrAutoSlry.Value.Date.AddMonths(-1)
        'Mnthval = dt.Month
        Yearval = dt.Year
        Prevs_Loan_Instlmnt()
        Count_Reduc_Instlmnt()
        ' Find_loan_Slry()
        If all_flag = False Then
            Employee_Id = EmpId
        ElseIf all_flag = True Then
            Employee_Id = arr_eid(ctr)
        End If
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select MethdIntrst,MnthlyInst,LnAmt,LnRateIntrst,RepayPrd,LnIntrstAppli from FinactLoan where LnEmpId='" & (Employee_Id) & "'and LnStatus<>'Adjusted' and Lndelstatus=1 and month(LnEffDt)<='" & (Mnth) & "'and Year(LnEffDt)='" & (Yearval) & "' ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmpId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.HasRows = True Then
                    LnType = Fetch_Ename_Rdr(0)
                    If LnType = "Flat" And IntrstAppli = True Then
                        If all_flag = False Then
                            LblLoan.Text = FormatNumber(Fetch_Ename_Rdr(1), 2)
                        ElseIf all_flag = True Then
                            LstvewAll.Items(i).SubItems(7).Text = FormatNumber(Fetch_Ename_Rdr(1), 2)
                            all_loanamt = FormatNumber(Fetch_Ename_Rdr(1), 2)
                        End If

                        'LoanAmt = LblLoan.Text
                    ElseIf LnType = "Reducing" And IntrstAppli = True Then
                        LblLoan.Visible = False

                        Reduc_Loan_Instlmnt = FormatNumber(Fetch_Ename_Rdr(1), 2)
                        Reduc_Loan_Amt = FormatNumber(Fetch_Ename_Rdr(2), 2)
                        Reduc_Loan_Intrst = FormatNumber(Fetch_Ename_Rdr(3), 2)
                        Reduc_Loan_RepayPrd = FormatNumber(Fetch_Ename_Rdr(4), 2)

                        If Reduc_Loan_RepayPrd - Count_Instlmnt > 0 Then
                            Deduct = Reduc_Loan_Amt / Reduc_Loan_RepayPrd
                            Principal = FormatNumber(Reduc_Loan_Amt - (Count_Instlmnt * Deduct), 2)

                            Intrstvalue = (Principal * Reduc_Loan_Intrst) / 100
                            Amount = Principal / (Reduc_Loan_RepayPrd - Count_Instlmnt)
                            MnthlyInst = FormatNumber(Amount + Intrstvalue)
                            If all_flag = False Then
                                LblLoan.Text = FormatNumber(MnthlyInst, 2)
                            ElseIf all_flag = True Then
                                LstvewAll.Items(i).SubItems(7).Text = FormatNumber(MnthlyInst, 2)
                                all_loanamt = FormatNumber(MnthlyInst, 2)
                            End If
                        End If

                    ElseIf IntrstAppli = False Then
                        Reduc_Loan_Instlmnt = FormatNumber(Fetch_Ename_Rdr(1), 2)
                        If all_flag = False Then
                            LblLoan.Text = FormatNumber(Reduc_Loan_Instlmnt, 2)
                        ElseIf all_flag = True Then
                            LstvewAll.Items(i).SubItems(7).Text = FormatNumber(Reduc_Loan_Instlmnt, 2)
                            all_loanamt = FormatNumber(Reduc_Loan_Instlmnt, 2)
                        End If


                        'LoanAmt = LblLoan.Text
                    End If
                ElseIf Fetch_Ename_Rdr.HasRows = False Then
                    If all_flag = False Then
                        LblLoan.Text = FormatNumber(Reduc_Loan_Instlmnt, 2)
                    ElseIf all_flag = True Then
                        LstvewAll.Items(i).SubItems(7).Text = FormatNumber(0, 2)
                        all_loanamt = FormatNumber(0, 2)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Payhead()

        Try
            Loan_Salry_Cmd = New SqlCommand("select count(PheadId),min(PheadId),max(PheadId) from FinactPayHead where PheadDelstatus=0", FinActConn)
            Loan_Salry_Rdr = Loan_Salry_Cmd.ExecuteReader
            Loan_Salry_Rdr.Read()
            If Loan_Salry_Rdr.IsDBNull(0) = False Then
                Count_Payhead = Loan_Salry_Rdr(0)
                Min_Payhead = Loan_Salry_Rdr(1)
                Max_Payhead = Loan_Salry_Rdr(2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Loan_Salry_Rdr.Close()
            Loan_Salry_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Payhead_Name()
        Dim count As Integer = 0
        Dim list_add As Boolean
        Fetch_Payhead()
        While count < Count_Payhead
            Try
                Loan_Salry_Cmd = New SqlCommand("select PheadName,PheadCalmtd,PheadComp ,PheadType from FinactPayHead where PheadDelstatus=0 and PheadId='" & (Min_Payhead) & "'", FinActConn)
                Loan_Salry_Rdr = Loan_Salry_Cmd.ExecuteReader
                Loan_Salry_Rdr.Read()
                If Loan_Salry_Rdr.HasRows = True Then
                    Payhead_Name = Loan_Salry_Rdr(0)
                    Payhead_Type = Loan_Salry_Rdr(1)
                    Ern_Deduc = Loan_Salry_Rdr(2)
                    PheadType = Loan_Salry_Rdr(3)
                    list_add = True

                ElseIf Loan_Salry_Rdr.HasRows = False Then
                    list_add = False
                    Count_Payhead = Count_Payhead + 1

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Loan_Salry_Rdr.Close()
                Loan_Salry_Cmd = Nothing
            End Try
            If list_add = True Then
                Fetch_Payhead_Amt()
            End If
            Min_Payhead = Min_Payhead + 1
            count = count + 1
        End While
    End Sub

    Private Sub Count_Slab_RateId()

        Try
            Loan_Salry_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and  PheadDelstatus=0 and PheadName='" & (Payhead_Name) & "'", FinActConn)
            Loan_Salry_Rdr = Loan_Salry_Cmd.ExecuteReader
            Loan_Salry_Rdr.Read()
            If Loan_Salry_Rdr.IsDBNull(0) = False Then
                Count_SlabId = Loan_Salry_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Loan_Salry_Rdr.Close()
            Loan_Salry_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Slab_RateId()

        Count_Slab_RateId()
        If Count_SlabId > 0 Then
            Try
                Loan_Salry_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadName='" & (Payhead_Name) & "'and PheadDelstatus=0", FinActConn)
                Loan_Salry_Rdr = Loan_Salry_Cmd.ExecuteReader
                Loan_Salry_Rdr.Read()
                If Loan_Salry_Rdr.IsDBNull(0) = False Then
                    RateId = Loan_Salry_Rdr(0)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Loan_Salry_Rdr.Close()
                Loan_Salry_Cmd = Nothing
            End Try
        End If
    End Sub

    Private Sub Fetch_Payhead_Amt()
        Dim Rateval, RateId1 As Integer
        Dim FromAmt, UptoAmt, BscSlry, SlabAmt, DiffAmt, TotSlabAmt As Double
        Dim counter As Integer = 0
        Dim LstPayhed As ListViewItem = Nothing
        Dim recrd_flag As Boolean
        ' Count_Slab_RateId()
        Fetch_Slab_RateId()
        While counter < Count_SlabId
            Try
                Loan_Salry_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadName='" & (Payhead_Name) & "'and PheadDelstatus=0 and SrateId='" & (RateId) & "'", FinActConn)
                Loan_Salry_Rdr = Loan_Salry_Cmd.ExecuteReader
                Loan_Salry_Rdr.Read()
                If Loan_Salry_Rdr.IsDBNull(0) = False Then
                    RateId1 = Loan_Salry_Rdr(0)
                    FromAmt = Loan_Salry_Rdr(1)
                    UptoAmt = Loan_Salry_Rdr(2)
                    Rateval = Loan_Salry_Rdr(3)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Loan_Salry_Rdr.IsDBNull(0) = False Then
                    recrd_flag = True
                ElseIf Loan_Salry_Rdr.IsDBNull(0) = True Then
                    recrd_flag = False
                End If
                Loan_Salry_Rdr.Close()
                Loan_Salry_Cmd = Nothing
            End Try
            If all_flag = False And LblBscSlry.Text <> "" Then
                BscSlry = CDbl(LblBscSlry.Text)
            ElseIf all_flag = True Then
                '                i = 0
                ' BscSlry = CDbl(LstvewAll.Items(i).SubItems(2).Text)
                BscSlry = Arr_Bscsalary(cntr)

            End If
            If FromAmt = 0 Then
                DiffAmt = (UptoAmt - FromAmt)
            ElseIf FromAmt > 0 Then
                DiffAmt = (UptoAmt - FromAmt) + 1

            End If
            If FromAmt <= BscSlry Then
                SlabAmt = FormatNumber((DiffAmt * Rateval) / 100, 2)
                TotSlabAmt = TotSlabAmt + SlabAmt

                TotSlabAmt = CDbl(TotSlabAmt)
            End If

            RateId = RateId + 1
            counter = counter + 1
            
        End While
        If counter = Count_SlabId And BscSlry > UptoAmt Then
            DiffAmt = (BscSlry - UptoAmt)
            SlabAmt = FormatNumber((DiffAmt * Rateval) / 100, 2)
            TotSlabAmt = TotSlabAmt + SlabAmt

        End If
       
        If all_flag = False Then
            If recrd_flag = True Then
                LstPayhed = LstvewPayhed.Items.Add(TotSlabAmt)
            ElseIf recrd_flag = False Then
                LstPayhed = LstvewPayhed.Items.Add(0)
            End If

            LstPayhed.SubItems.Add(Payhead_Name)


            LstPayhed.SubItems.Add(Payhead_Type)

            LstPayhed.SubItems.Add(Ern_Deduc)
            If Payhead_Type = "As User Defined Value" Then

                LstPayhed.SubItems.Add("Not Edit")
            Else
                LstPayhed.SubItems.Add("Edit")


            End If
            LstPayhed.SubItems.Add(PheadType)

        ElseIf all_flag = True Then


            If recrd_flag = True Then
                If STRT = 0 Then
                    phed_arr(0) = TotSlabAmt
                    STRT += 1
                    INC_ARR += 1
                ElseIf STRT <> 0 Then
                    phed_arr(INC_ARR) = TotSlabAmt
                    INC_ARR += 1
                End If
                'LstvewAll.Items(i).SubItems(15).Text = TotSlabAmt
            ElseIf recrd_flag = False Then
                'LstvewAll.Items(i).SubItems(13).Text = 0
            End If

        End If

    End Sub

    Private Sub userdefin_slab()
        Dim totrecrd, counter2 As Integer
        Dim Type_Slab As String
        totrecrd = LstvewPayhed.Items.Count
        counter2 = 0
        While counter2 < totrecrd
            Type_Slab = LstvewPayhed.Items(counter2).SubItems(4).Text
            If Type_Slab = "Not Edit" Then
                GrpBxPayHed.Visible = True
                GrpBxPayHed.Location = New System.Drawing.Point(334, 329)
                LblPayhed.Text = LstvewPayhed.Items(counter2).SubItems(1).Text

                indx = counter2
                PhedAmt.Focus()
                Exit Sub
            End If
            counter2 = counter2 + 1
        End While
        'userdefin_slab()

    End Sub

    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        LblPayhed.Text = ""
        PhedAmt.Text = ""
        GrpBxPayHed.Visible = False

    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click

        If PhedAmt.Text <> "" Then
            Dim counter3, Lstcount, end_cntr As Integer
            LstvewPayhed.Items(indx).SubItems(0).Text = FormatNumber(PhedAmt.Text, 2)
            LstvewPayhed.Items(indx).SubItems(4).Text = "Edit"
            PhedAmt.Text = ""
            GrpBxPayHed.Visible = False
            Lstcount = LstvewPayhed.Items.Count
            end_cntr = 0
            While counter3 < Lstcount
                If LstvewPayhed.Items(counter3).SubItems(4).Text = "Not Edit" Then
                    userdefin_slab()
                ElseIf LstvewPayhed.Items(counter3).SubItems(4).Text = "Edit" Then
                    end_cntr = end_cntr + 1
                End If
                counter3 = counter3 + 1

            End While
            ' userdefin_slab()
            ' GrpBxPayHed.Visible = False
            'If no_recrd_flag = True Then
            '    PnlPayhed.Visible = True
            'End If
            'counter3 = 0

            'While counter3 < Lstcount
            '    If LstvewPayhed.Items(counter3).SubItems(4).Text = "Edit" Then
            '        end_cntr = end_cntr + 1
            '    End If
            '    '        PnlPayhed.Visible = True
            '    '    End If
            '    counter3 = counter3 + 1
            'End While
            If end_cntr = Lstcount Then
                PnlPayhed.Visible = True
                PnlPayhed.Location = New System.Drawing.Point(342, 317)
                BtnSave.Focus()

            End If
        ElseIf PhedAmt.Text = "" Then
            PhedAmt.BackColor = Color.PapayaWhip
            MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Amount")

            PhedAmt.Focus()
        End If
    End Sub

    Private Sub PhedAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PhedAmt.KeyDown
        If e.KeyCode = Keys.Enter Then
            If PhedAmt.Text = "" Then
                PhedAmt.BackColor = Color.PapayaWhip
                MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Amount")

                PhedAmt.Focus()
            ElseIf PhedAmt.Text <> "" Then
                BtnOK.Focus()

            End If
        End If
    End Sub


    Private Sub PhedAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PhedAmt.TextChanged
        If PhedAmt.BackColor = Color.PapayaWhip Then
            PhedAmt.BackColor = Color.White
        End If
    End Sub


    Private Sub PnlPayhed_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PnlPayhed.VisibleChanged
        If PnlPayhed.Visible = True Then
            Dim totrecrd, counter2 As Integer
            Dim Earning, TotlErn, Deduction, Totldeduc As Double
            Dim PType As String
            Dim PhedErn, PhedDeduc, Advnc, Loan As Double
            totrecrd = LstvewPayhed.Items.Count
            counter2 = 0
            While counter2 < totrecrd
                PType = LstvewPayhed.Items(counter2).SubItems(5).Text
                If PType = "EREmp" Or PType = "REB" Then
                    Earning = LstvewPayhed.Items(counter2).SubItems(0).Text
                    Deduction = 0
                ElseIf PType = "DEEmp" Or PType = "ESDed" Or PType = "ESConThen" Then
                    Deduction = LstvewPayhed.Items(counter2).SubItems(0).Text
                    Earning = 0
                End If

                TotlErn = TotlErn + Earning
                Totldeduc = Totldeduc + Deduction
                counter2 = counter2 + 1
            End While

            If LblErnAmt.Text <> "" Then

                Ernamt = CDbl(LblErnAmt.Text)
                Advnc = CDbl(LblAdvAmt.Text)
                Loan = CDbl(LblLoan.Text)
                LblPhedErn.Text = FormatNumber(TotlErn + Ernamt, 2)
                LblPhedDeduc.Text = FormatNumber(Totldeduc + Advnc + Loan, 2)
                PhedErn = CDbl(LblPhedErn.Text)
                PhedDeduc = CDbl(LblPhedDeduc.Text)
                LblNetSlry.Text = FormatNumber(CDbl(PhedErn - PhedDeduc), 2)

            End If
            BtnSave.Enabled = True
        End If
    End Sub

    Private Sub RbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAll.CheckedChanged
        If RbAll.Checked = True And BtnFnd.Text = "&Find" Then
            clrvalues()
            PnlEmpDtl.Visible = False
            Me.Size = New System.Drawing.Point(780, 250)

            LblSelCritera.Visible = True
            CmbxSelCritera.Visible = True

            LblSelCritera.Location = New System.Drawing.Point(22, 98)
            CmbxSelCritera.Location = New System.Drawing.Point(170, 98)

            LstvewAll.Visible = False
            LstvewAll.Size = New System.Drawing.Point(989, 244)
            LstvewAll.Location = New System.Drawing.Point(12, 56)
            all_flag = True
          
            'BtnSave.Location = New System.Drawing.Point(708, 588)
            ' BtnFnd.Visible = False
            BtnFnd.Enabled = False

        End If
    End Sub

    Private Sub clrvalues()
        If PnlEmpDtl.Visible = True Then

            If CmbxEname.SelectedIndex >= 0 Then
                CmbxEname.SelectedIndex = -1
                CmbxEname.Text = ""
                CmbxEname.Text = "Select"
            End If
            LblDesig.Text = ""
            LblBscSlry.Text = ""
            LblDept.Text = ""
            RbWithHoli.Checked = False
            RbWotHoli.Checked = False
            LblWrkDays.Text = ""
            LblErnAmt.Text = ""
            LblAdvAmt.Text = ""
            LblLoan.Text = ""
            LblPayhed.Text = ""
            PhedAmt.Text = ""
            LstvewPayhed.Items.Clear()
            LblPhedErn.Text = ""
            LblPhedDeduc.Text = ""
            LblNetSlry.Text = ""
            GrpBxPayHed.Visible = False
            PnlPayhed.Visible = False
            'RbOne.Checked = False
            'RbAll.Checked = False

        Else
            LstvewAll.Items.Clear()
            LstvewAll.Visible = False
        End If

    End Sub


    Private Sub BtnCancl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancl.Click
        If RbOne.Checked = True Then

            clrvalues()

            GrpBxPayHed.Visible = False
            Me.Size = New System.Drawing.Point(708, 688)
            PnlEmpDtl.Visible = True
            PnlEmpDtl.Size = New System.Drawing.Point(678, 502)
            LstvewAll.Visible = False
            LstvewPayhed.Visible = True
            LstvewAll.Items.Clear()
            BtnSave.Text = "&Save"
            BtnFnd.Text = "&Find"
            LblSelCritera.Visible = False
            CmbxSelCritera.Visible = False
            DataGridAll.Visible = False
            LblCateg.Visible = False
            CmbxCateg.Visible = False
            RbAll.Checked = False
            RbOne.Checked = False
            DtpkrAutoSlry.Enabled = True
            CmbxEname.Enabled = True
            RbWithHoli.Enabled = True
            RbWotHoli.Enabled = True
            DataGridAll.Visible = False
            DtpkrAutoSlry.Focus()
        ElseIf RbAll.Checked = True Then
            DataGridAll.Visible = False
            LstvewAll.Items.Clear()
            LstvewAll.Visible = False

            Me.Size = New System.Drawing.Point(780, 250)

            RbAll.Checked = False
            DtpkrAutoSlry.Focus()
        End If
        


    End Sub

    Private Sub Fetch_Concrnid()
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select max(AslryId)from FinactAutoSalary", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_Rdr.Read()
            If Fetch_Ename_Rdr.HasRows = True Then
                Cid = Fetch_Ename_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_Rdr.Close()
        End Try
    End Sub




    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim Lstcnt, cntr As Integer
        Dim cnt_strt As Integer = 0
        Dim yr As Integer
        yr = DtpkrAutoSlry.Value.Date.Year
        If BtnSave.Text = "&Save" Then
            If RbOne.Checked = True Then

                Try
                    Auto_Slry_Cmd = New SqlCommand("Finact_AutoSlry_Insert", FinActConn)
                    Auto_Slry_Cmd.CommandType = CommandType.StoredProcedure
                    Auto_Slry_Cmd.Parameters.AddWithValue("AslryDt", DtpkrAutoSlry.Value.Date)
                    Auto_Slry_Cmd.Parameters.AddWithValue("AslryMnth", LblMnth.Text)
                    If RbOne.Checked = True Then
                        Auto_Slry_Cmd.Parameters.AddWithValue("AslryType", 1)
                    ElseIf RbAll.Checked = True Then
                        Auto_Slry_Cmd.Parameters.AddWithValue("AslryType", 0)
                    End If
                    Auto_Slry_Cmd.Parameters.AddWithValue("AslryEmpid", EmpId)
                    If RbWithHoli.Checked = True Then
                        Auto_Slry_Cmd.Parameters.AddWithValue("AslryWholidys", 1)
                    ElseIf RbWotHoli.Checked = True Then
                        Auto_Slry_Cmd.Parameters.AddWithValue("AslryWholidys", 0)
                    End If
                    Auto_Slry_Cmd.Parameters.AddWithValue("AslryWrkDys", LblWrkDays.Text)
                    Auto_Slry_Cmd.Parameters.AddWithValue("AslryErnAmt", CDbl(LblErnAmt.Text))
                    Auto_Slry_Cmd.Parameters.AddWithValue("AslryAdvAmt", CDbl(LblAdvAmt.Text))
                    Auto_Slry_Cmd.Parameters.AddWithValue("AslryLnAmt", CDbl(LblLoan.Text))
                    Auto_Slry_Cmd.Parameters.AddWithValue("AslryTotlErn", CDbl(LblPhedErn.Text))
                    Auto_Slry_Cmd.Parameters.AddWithValue("AslryTotlDeduc", CDbl(LblPhedDeduc.Text))
                    Auto_Slry_Cmd.Parameters.AddWithValue("AslryNetSlry", CDbl(LblNetSlry.Text))
                    Auto_Slry_Cmd.Parameters.AddWithValue("Aslryadusrid", Current_UsrId)
                    Auto_Slry_Cmd.Parameters.AddWithValue("Aslryaddt", Now)
                    Auto_Slry_Cmd.Parameters.AddWithValue("Aslrydelstatus", 0)

                    Auto_Slry_Cmd.ExecuteNonQuery()
                    MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                    RbOne.Checked = False
                    DtpkrAutoSlry.Focus()

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Auto_Slry_Cmd = Nothing
                End Try
                Fetch_Concrnid()
                Lstcnt = LstvewPayhed.Items.Count
                cntr = 0
                While cntr < Lstcnt
                    Try
                        Auto_Slry_Cmd = New SqlCommand("FinactAutoSlry_Phed_Insert", FinActConn)
                        Auto_Slry_Cmd.CommandType = CommandType.StoredProcedure
                        Auto_Slry_Cmd.Parameters.AddWithValue("AsPdConcrnid", Cid)
                        Auto_Slry_Cmd.Parameters.AddWithValue("AsPdName", LstvewPayhed.Items(cntr).SubItems(1).Text)
                        Auto_Slry_Cmd.Parameters.AddWithValue("AsPdAmt", CDbl(LstvewPayhed.Items(cntr).SubItems(0).Text))
                        Auto_Slry_Cmd.Parameters.AddWithValue("AsPdType", LstvewPayhed.Items(cntr).SubItems(2).Text)
                        ' Auto_Slry_Cmd.Parameters.AddWithValue("AsPdErnDeduc", LstvewPayhed.Items(cntr).SubItems(3).Text)
                        Auto_Slry_Cmd.Parameters.AddWithValue("AsPdDt", DtpkrAutoSlry.Value.Date)
                        Auto_Slry_Cmd.Parameters.AddWithValue("AsPdEmpid", EmpId)
                        Auto_Slry_Cmd.Parameters.AddWithValue("AsPdStatus", 1)
                        Auto_Slry_Cmd.Parameters.AddWithValue("AsPdaddt", Now)
                        Auto_Slry_Cmd.Parameters.AddWithValue("AsPdadusrid", Current_UsrId)
                        Auto_Slry_Cmd.Parameters.AddWithValue("AsPddelstatus", 0)
                        Auto_Slry_Cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Auto_Slry_Cmd = Nothing
                    End Try

                    cntr = cntr + 1
                End While
                Mnthvalue()
                Try
                    Auto_Slry_Cmd = New SqlCommand("Update  Finact_Attd set SlrySlip=@SlrySlip where AttdEmpid='" & (EmpId) & "'and month(Attddt)='" & (Mnth) & "'", FinActConn)
                    Auto_Slry_Cmd.Parameters.AddWithValue("@SlrySlip", 1)
                    Auto_Slry_Cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Auto_Slry_Cmd = Nothing
                End Try

                clrvalues()
            ElseIf RbAll.Checked = True Then
                Dim cnfrmmsg As String

                MsgBox("Salary Slip of all employees will be generated after Saving this record", MsgBoxStyle.Exclamation, "Alert")
                cnfrmmsg = MsgBox("Do you want to continue?", MsgBoxStyle.YesNo, "Confirmation")
                If cnfrmmsg = vbYes Then
                    Dim All_TotlErn, All_TotlDeduc As Double
                    Lstcnt = LstvewAll.Items.Count
                    cntr = 0
                    While cntr < Lstcnt
                        Try
                            Auto_Slry_Cmd = New SqlCommand("Finact_AutoSlry_Insert", FinActConn)
                            Auto_Slry_Cmd.CommandType = CommandType.StoredProcedure
                            Auto_Slry_Cmd.Parameters.AddWithValue("AslryDt", DtpkrAutoSlry.Value.Date)
                            Auto_Slry_Cmd.Parameters.AddWithValue("AslryMnth", LblMnth.Text)
                            If RbOne.Checked = True Then
                                Auto_Slry_Cmd.Parameters.AddWithValue("AslryType", 1)
                            ElseIf RbAll.Checked = True Then
                                Auto_Slry_Cmd.Parameters.AddWithValue("AslryType", 0)
                            End If
                            Auto_Slry_Cmd.Parameters.AddWithValue("AslryEmpid", arr_eid(cntr))
                            Auto_Slry_Cmd.Parameters.AddWithValue("AslryWholidys", 1)
                            Auto_Slry_Cmd.Parameters.AddWithValue("AslryWrkDys", LstvewAll.Items(cntr).SubItems(4).Text)
                            Auto_Slry_Cmd.Parameters.AddWithValue("AslryErnAmt", CDbl(LstvewAll.Items(cntr).SubItems(5).Text))
                            Auto_Slry_Cmd.Parameters.AddWithValue("AslryAdvAmt", CDbl(LstvewAll.Items(cntr).SubItems(6).Text))
                            Auto_Slry_Cmd.Parameters.AddWithValue("AslryLnAmt", CDbl(LstvewAll.Items(cntr).SubItems(7).Text))
                            All_TotlErn = CDbl(LstvewAll.Items(cntr).SubItems(5).Text) + arr_ern(cntr) + phed_ern
                            Auto_Slry_Cmd.Parameters.AddWithValue("AslryTotlErn", CDbl(All_TotlErn))
                            All_TotlDeduc = CDbl(LstvewAll.Items(cntr).SubItems(6).Text) + CDbl(LstvewAll.Items(cntr).SubItems(7).Text) + arr_deduct(cntr) + phed_deduc
                            Auto_Slry_Cmd.Parameters.AddWithValue("AslryTotlDeduc", All_TotlDeduc)
                            Auto_Slry_Cmd.Parameters.AddWithValue("AslryNetSlry", CDbl(LstvewAll.Items(cntr).SubItems(8).Text))
                            Auto_Slry_Cmd.Parameters.AddWithValue("Aslryadusrid", Current_UsrId)
                            Auto_Slry_Cmd.Parameters.AddWithValue("Aslryaddt", Now)
                            Auto_Slry_Cmd.Parameters.AddWithValue("Aslrydelstatus", 0)

                            Auto_Slry_Cmd.ExecuteNonQuery()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Auto_Slry_Cmd = Nothing
                        End Try

                        Lstcnt = LstvewAll.Columns.Count - 17
                        Dim colmn_strt As Integer
                        colmn_strt = 17
                        Fetch_Concrnid()
                        k = 0
                        l = 0
                        cnt_strt = 0
                        While cnt_strt < Lstcnt
                            Try
                                Auto_Slry_Cmd = New SqlCommand("FinactAutoSlry_Phed_Insert", FinActConn)
                                Auto_Slry_Cmd.CommandType = CommandType.StoredProcedure
                                Auto_Slry_Cmd.Parameters.AddWithValue("AsPdConcrnid", Cid)
                                Auto_Slry_Cmd.Parameters.AddWithValue("AsPdName", LstvewAll.Columns(colmn_strt).Text)

                                Auto_Slry_Cmd.Parameters.AddWithValue("AsPdAmt", CDbl(LstvewAll.Items(cnt_strt).SubItems(colmn_strt).Text))
                                If cnt_strt < no_of_payhed Then
                                    Auto_Slry_Cmd.Parameters.AddWithValue("AsPdType", Arr_PheadType(k))
                                    'Auto_Slry_Cmd.Parameters.AddWithValue("AsPdErnDeduc", 0)
                                    k = k + 1
                                End If
                                If cnt_strt >= no_of_payhed Then
                                    Auto_Slry_Cmd.Parameters.AddWithValue("AsPdType", Arr_Phed_Type2(l))
                                    'Auto_Slry_Cmd.Parameters.AddWithValue("AsPdErnDeduc", 0)
                                    l = l + 1
                                End If
                                Auto_Slry_Cmd.Parameters.AddWithValue("AsPdDt", DtpkrAutoSlry.Value.Date)
                                Auto_Slry_Cmd.Parameters.AddWithValue("AsPdEmpid", arr_eid(cntr))
                                Auto_Slry_Cmd.Parameters.AddWithValue("AsPdStatus", 0)
                                Auto_Slry_Cmd.Parameters.AddWithValue("AsPdaddt", Now)
                                Auto_Slry_Cmd.Parameters.AddWithValue("AsPdadusrid", Current_UsrId)
                                Auto_Slry_Cmd.Parameters.AddWithValue("AsPddelstatus", 0)
                                Auto_Slry_Cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                Auto_Slry_Cmd = Nothing
                            End Try

                            colmn_strt += 1
                            cnt_strt += 1


                        End While
                        '    clrvalues()
                        Try
                            Auto_Slry_Cmd = New SqlCommand("Update  Finact_Attd set SlrySlip=@SlrySlip where AttdEmpid='" & (arr_eid(cntr)) & "'and month(Attddt)='" & (Mnth) & "'", FinActConn)
                            Auto_Slry_Cmd.Parameters.AddWithValue("SlrySlip", 1)
                            Auto_Slry_Cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Auto_Slry_Cmd = Nothing
                        End Try
                        cntr = cntr + 1
                    End While
                    MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information, "Save Record")




                    LstvewAll.Items.Clear()
                    LstvewAll.Visible = False
                    DtpkrAutoSlry.Focus()
                    Me.Size = New System.Drawing.Point(780, 250)
                ElseIf cnfrmmsg = vbNo Then
                    Exit Sub
                End If
            End If

        ElseIf BtnSave.Text = "&Edit" Then
            If RbOne.Checked = True Then
                If no_of_payhed > 0 Then

                    Try
                        Auto_Slry_Cmd = New SqlCommand("Finact_AutoSlry_Edit", FinActConn)
                        Auto_Slry_Cmd.CommandType = CommandType.StoredProcedure

                        Auto_Slry_Cmd.Parameters.AddWithValue("AslryId", Fetch_AslryId)


                        Auto_Slry_Cmd.Parameters.AddWithValue("AslryTotlErn", CDbl(LblPhedErn.Text))
                        Auto_Slry_Cmd.Parameters.AddWithValue("AslryTotlDeduc", CDbl(LblPhedDeduc.Text))
                        Auto_Slry_Cmd.Parameters.AddWithValue("AslryNetSlry", CDbl(LblNetSlry.Text))
                        Auto_Slry_Cmd.Parameters.AddWithValue("Aslryedtusrid", Current_UsrId)
                        Auto_Slry_Cmd.Parameters.AddWithValue("Aslryedtdt", Now)
                        Auto_Slry_Cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    Dim Min_id As Integer = 0
                    Fetch_Concrnid()
                    Try
                        Auto_Slry_Cmd = New SqlCommand("select min(AsPdId)from FinactAutoSalary_Payhed where AsPdConcrnid='" & (Fetch_AslryId) & "'and AsPdDt='" & (DtpkrAutoSlry.Value.Date) & "'and Aspddelstatus=0 and AsPdType='As User Defined Value'", FinActConn)
                        Auto_Slry_Rdr = Auto_Slry_Cmd.ExecuteReader
                        Auto_Slry_Rdr.Read()
                        If Auto_Slry_Rdr.IsDBNull(0) = False Then
                            Min_id = Auto_Slry_Rdr(0)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Auto_Slry_Cmd = Nothing
                        Auto_Slry_Rdr.Close()
                    End Try

                    Lstcnt = DataGridAll.Rows.Count
                    cntr = 0
                    While cntr < Lstcnt
                        Try
                            Auto_Slry_Cmd = New SqlCommand("Update FinactAutoSalary_Payhed set AsPdAmt=@AsPdAmt where AsPdConcrnid='" & (Fetch_AslryId) & "'and AsPdDt='" & (DtpkrAutoSlry.Value.Date) & "'and Aspddelstatus=0 and AsPdType='As User Defined Value'and AsPdId='" & (Min_id) & "'", FinActConn)
                            Auto_Slry_Cmd.Parameters.AddWithValue("AsPdAmt", CDbl(DataGridAll.Rows(cntr).Cells(1).Value))

                            Auto_Slry_Cmd.Parameters.AddWithValue("AsPdedtdt", Now)
                            Auto_Slry_Cmd.Parameters.AddWithValue("AsPdedtusrid", Current_UsrId)
                            Auto_Slry_Cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Auto_Slry_Cmd = Nothing
                        End Try
                        Min_id += 1
                        cntr = cntr + 1
                    End While
                    MsgBox("Record has been Updated Successfully", MsgBoxStyle.Information, "Edit Record")

                    DataGridAll.Visible = False
                    LstvewAll.Items(index).SubItems(13).Text = FormatNumber(LblPhedErn.Text, 2)
                    LstvewAll.Items(index).SubItems(14).Text = FormatNumber(LblPhedDeduc.Text, 2)
                    LstvewAll.Items(index).SubItems(8).Text = FormatNumber(LblNetSlry.Text, 2)
                    cntr1 = 0
                    i = 17 + no_of_payhed1
                    While cntr1 < no_of_payhed
                        LstvewAll.Items(index).SubItems(i).Text = arr(cntr1)
                        cntr1 += 1
                        i += 1
                    End While
                    clrvalues()
                    PnlPayhed.Visible = True
                ElseIf no_of_payhed = 0 Then
                    MsgBox("System could not found any Payhead to Edit", MsgBoxStyle.Information, "Edit Record")
                    Exit Sub
                End If
            End If
        End If

    End Sub

    Private Sub Fetch_Emp_Recrd()
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select empname,deptid,desiid,empgrade from Finactempmstr where empid='" & (Eid) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_Rdr.Read()
            If Fetch_Ename_Rdr.HasRows = True Then
                Empname = Fetch_Ename_Rdr(0)
                EmpDeptId = Fetch_Ename_Rdr(1)
                EmpDesigId = Fetch_Ename_Rdr(2)
                EmpBscSlry = Fetch_Ename_Rdr(3)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_Rdr.Close()

        End Try
    End Sub

    Private Sub BtnFnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd.Click
        If BtnFnd.Text = "&Find" Then
            clrvalues()
            BtnFnd.Text = "&Delete"
            BtnSave.Text = "&Edit"
            RbOne.Checked = True
            CmbxEname.Items.Clear()
            CmbxEname.Text = ""

            Dim Lstvew As ListViewItem
            Me.Size = New System.Drawing.Point(1010, 654)
            LstvewPayhed.Visible = False
            'Label24.Location = New System.Drawing.Point(10, 329)
            ' LblNetSlry.Location = New System.Drawing.Point(164, 329)
            'Label22.Location = New System.Drawing.Point(291, 329)
            LstvewAll.Visible = True
            LstvewAll.Size = New System.Drawing.Point(989, 120)
            LstvewAll.Location = New System.Drawing.Point(10, 460)

            createsummary1()
            createsummary()
            PnlEmpDtl.Size = New System.Drawing.Point(980, 362)
         
            PnlPayhed.Visible = True
            PnlPayhed.Location = New System.Drawing.Point(477, 180)

          
            Dim empid_arr(100) As Integer
            Dim dt_arr(100) As Date
            Dim ctr1 As Integer = 0
            Dim lst_flag As Boolean
            Try
                Auto_Slry_Cmd = New SqlCommand("select Finactempmstr.empname,finactDesi.desiname,Finactempmstr.empgrade,finactDept.deptname,Aslrywrkdys,AslryErnamt,AslryAdvamt,AslryLnAmt,AslryNetSlry,AslryMnth,AslryType,AslryWholidys,AslryId,AslryTotlErn,AslryTotlDeduc,Finactempmstr.empid ,AslryDt from FinactAutoSalary inner join Finactempmstr on FinactAutoSalary.AslryEmpid=Finactempmstr.Empid inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid where Aslrydelstatus=0 and AslryType=1", FinActConn)
                Auto_Slry_Rdr = Auto_Slry_Cmd.ExecuteReader()
                While Auto_Slry_Rdr.Read
                    If Auto_Slry_Rdr.HasRows = True Then
                        Lstvew = LstvewAll.Items.Add(Auto_Slry_Rdr(0))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(1))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(2))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(3))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(4))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(5))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(6))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(7))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(8))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(9))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(10))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(11))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(12))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(13))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(14))
                        empid_arr(ctr1) = Auto_Slry_Rdr(15)
                        dt_arr(ctr1) = Auto_Slry_Rdr(16)
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(16))
                        Lstvew.SubItems.Add(Auto_Slry_Rdr(15))
                        lst_flag = True
                    End If
                    ctr1 = ctr1 + 1
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Auto_Slry_Rdr.HasRows = False Then
                    MsgBox("No record found", MsgBoxStyle.Information, "Find Record")
                    lst_flag = False
                End If
                Auto_Slry_Cmd = Nothing
                Auto_Slry_Rdr.Close()

            End Try
            If lst_flag = True Then
                Dim lstcnt1 As Integer = 0
                lstcnt1 = LstvewAll.Items.Count
                Dim clmn As Integer
                clmn = 17
                ctr1 = 0
                While ctr1 < lstcnt1
                    Try
                        Auto_Slry_Cmd = New SqlCommand("select AsPdAmt from FinactAutoSalary_Payhed where AsPdEmpid='" & (empid_arr(ctr1)) & "'and AsPdDt='" & (dt_arr(ctr1)) & "'", FinActConn)
                        Auto_Slry_Rdr = Auto_Slry_Cmd.ExecuteReader()
                        While Auto_Slry_Rdr.Read
                            If Auto_Slry_Rdr.HasRows = True Then
                                LstvewAll.Items(ctr1).SubItems.Add(Auto_Slry_Rdr(0))
                                clmn += 1
                            End If

                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Auto_Slry_Cmd = Nothing
                        Auto_Slry_Rdr.Close()

                    End Try
                    ctr1 = ctr1 + 1
                    clmn = 17
                End While
            End If
        ElseIf BtnFnd.Text = "&Delete" And LstvewAll.Visible = True Then

            Dim rspns As String
            Dim List_cnt, List_sel_cnt, indx1 As Integer
            List_cnt = LstvewAll.Items.Count
            List_sel_cnt = LstvewAll.SelectedItems.Count
            'If List_sel_cnt = 0 Then
            '    MsgBox("No record selected in the list to delete", MsgBoxStyle.Information, "Delete Record")
            'ElseIf List_sel_cnt > 0 Then

            rspns = MsgBox("Are you sure to delete record?", MsgBoxStyle.YesNo, "Delete Record")
            If rspns = vbYes Then
                'While List_cntr < List_sel_cnt
                Try
                    Auto_Slry_Cmd = New SqlCommand("Finact_AutoSalary_Delete", FinActConn)
                    Auto_Slry_Cmd.CommandType = CommandType.StoredProcedure
                    Auto_Slry_Cmd.Parameters.AddWithValue("ASlryId", Fetch_AslryId)
                    Auto_Slry_Cmd.Parameters.AddWithValue("Aslrydelstatus", 1)
                    Auto_Slry_Cmd.Parameters.AddWithValue("Aslrydelusrid", Current_UsrId)
                    Auto_Slry_Cmd.Parameters.AddWithValue("Aslrydeldt", Now)
                    Auto_Slry_Cmd.ExecuteNonQuery()
                    MsgBox("Record has been Deleted Successfully", MsgBoxStyle.Information, "Record Deleted")
                    'indx = LstvewAll.SelectedItems(0).Index
                    LstvewAll.Items(indx1).Remove()
                    clrvalues()

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Auto_Slry_Cmd = Nothing
                    Auto_Slry_Rdr.Close()

                End Try
                'List_cntr = List_cntr + 1

                Try
                    Auto_Slry_Cmd = New SqlCommand("update FinactAutoSalary_Payhed set AsPddelusrid=@AsPddelusrid,AsPddeldt=@AsPddeldt,AsPddelstatus=@AsPddelstatus where AsPdConcrnid='" & (Fetch_AslryId) & "'", FinActConn)
                    Auto_Slry_Cmd.Parameters.AddWithValue("AsPddelusrid", Current_UsrId)
                    Auto_Slry_Cmd.Parameters.AddWithValue("AsPddeldt", Now)
                    Auto_Slry_Cmd.Parameters.AddWithValue("AsPddelstatus", 1)
                    Auto_Slry_Cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'End While
                Mnthvalue()
                Try
                    Auto_Slry_Cmd = New SqlCommand("Update  Finact_Attd set SlrySlip=@SlrySlip where AttdEmpid='" & (Fetch_Empid) & "'and month(Attddt)='" & (Mnth) & "'", FinActConn)
                    Auto_Slry_Cmd.Parameters.AddWithValue("@SlrySlip", 0)
                    Auto_Slry_Cmd.ExecuteNonQuery()
                    MsgBox("Record has been Deleted Successfully", MsgBoxStyle.Information, "Record Deleted")
                    clrvalues()
                    DataGridAll.Visible = False

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Auto_Slry_Cmd = Nothing
                End Try

            ElseIf rspns = vbNo Then
                BtnCancl.Focus()
            End If
        End If
        'End If

    End Sub


    Private Sub LstvewAll_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstvewAll.DoubleClick
        If all_flag = False Then
            If LstvewAll.Items.Count > 0 Then
                Dim indx As Integer = 0
                index = 0
                Dim type As Boolean
                Dim Wholidys_type As Integer

                indx = LstvewAll.SelectedItems(0).Index
                index = LstvewAll.SelectedItems(0).Index
                CmbxEname.Text = LstvewAll.Items(indx).SubItems(0).Text
                LblDesig.Text = LstvewAll.Items(indx).SubItems(1).Text
                LblBscSlry.Text = LstvewAll.Items(indx).SubItems(2).Text
                LblDept.Text = LstvewAll.Items(indx).SubItems(3).Text
                LblWrkDays.Text = LstvewAll.Items(indx).SubItems(4).Text
                LblErnAmt.Text = LstvewAll.Items(indx).SubItems(5).Text
                LblAdvAmt.Text = LstvewAll.Items(indx).SubItems(6).Text
                LblLoan.Text = LstvewAll.Items(indx).SubItems(7).Text
                LblNetSlry.Text = LstvewAll.Items(indx).SubItems(8).Text
                NetSalary = LstvewAll.Items(indx).SubItems(8).Text
                LblMnth.Text = LstvewAll.Items(indx).SubItems(9).Text
                type = LstvewAll.Items(indx).SubItems(10).Text
                'If type = "True" Then
                RbOne.Checked = True
                'ElseIf Type = "False" Then
                '    RbAll.Checked = True
                'End If
                LblPhedErn.Text = LstvewAll.Items(indx).SubItems(13).Text
                Totl_Ern = LstvewAll.Items(indx).SubItems(13).Text

                LblPhedDeduc.Text = LstvewAll.Items(indx).SubItems(14).Text
                Totl_Deduc = LstvewAll.Items(indx).SubItems(14).Text
                Fetch_AslryId = LstvewAll.Items(indx).SubItems(12).Text
                Fetch_Empid = LstvewAll.Items(indx).SubItems(16).Text
                Wholidys_type = LstvewAll.Items(indx).SubItems(11).Text
                If Wholidys_type = 1 Then
                    RbWithHoli.Checked = True
                    RbWotHoli.Enabled = False
                ElseIf Wholidys_type = 0 Then
                    RbWotHoli.Checked = True
                    RbWithHoli.Enabled = False
                End If
                LblWrkDays.Text = LstvewAll.Items(indx).SubItems(4).Text
                LblErnAmt.Text = LstvewAll.Items(indx).SubItems(5).Text
                LblPhedErn.Text = LstvewAll.Items(indx).SubItems(13).Text

                LblPhedDeduc.Text = LstvewAll.Items(indx).SubItems(14).Text
                DtpkrAutoSlry.Text = LstvewAll.Items(indx).SubItems(15).Text
                DtpkrAutoSlry.Enabled = False
                DataGridAll.Visible = True
                CmbxEname.Enabled = False

                DataGridAll.Location = New System.Drawing.Point(550, 150)
                fill()
                i = 0
                Fetch_Usrdfin_Payhed()

                Dim clmn_indx As Integer
                If no_of_payhed > 0 Then

                    clmn_indx = 17 + no_of_payhed1
                    k = 0

                    While i < no_of_payhed
                        DataGridAll.Rows(i).Cells(1).Value = LstvewAll.Items(indx).SubItems(clmn_indx).Text
                        If (Arr_PheadType(k)) = "EREmp" Or (Arr_PheadType(k)) = "REB" Then
                            deduc_payhed = deduc_payhed + LstvewAll.Items(indx).SubItems(clmn_indx).Text
                        End If
                        i = i + 1
                        clmn_indx += 1
                        k += 1
                    End While
                End If
                If no_of_payhed1 > 0 Then
                    i = 0
                    add_payhed = 0
                    clmn_indx = 0
                    clmn_indx = 17
                    While i < no_of_payhed1
                        If LstvewAll.Items(indx).SubItems(clmn_indx).Text Then
                            add_payhed = add_payhed + LstvewAll.Items(indx).SubItems(clmn_indx).Text
                        End If
                        i = i + 1
                        clmn_indx += 1
                    End While
                End If

                'DataGridAll.Rows(1).Cells(1).Value = LstvewAll.Items(indx).SubItems(16).Text
                'DataGridAll.Rows(2).Cells(1).Value = LstvewAll.Items(indx).SubItems(17).Text
                'DataGridAll.Rows(3).Cells(1).Value = LstvewAll.Items(indx).SubItems(18).Text

                If no_of_payhed > 0 Then
                    Me.DataGridAll.Focus()
                    DataGridAll.CurrentCell = DataGridAll.Rows(0).Cells(1)
                End If
                'DataGridAll.EditMode = DataGridViewEditMode.EditOnEnter
                ' LstvewAll.Items(indx).Remove()
            End If

        End If

    End Sub


    Private Sub RbOne_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbOne.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            fetch_Cmbx_Ename()
            CmbxEname.Focus()

        End If
        'fetch_Cmbx_Ename()
        'CmbxEname.Focus()
    End Sub


    Private Sub RbAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbAll.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            CmbxSelCritera.Focus()

        End If
    End Sub

    Private Sub CmbxSelCritera_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSelCritera.GotFocus
        If CmbxSelCritera.Items.Count > 0 Then
            CmbxSelCritera.DroppedDown = True

        End If
    End Sub

    Private Sub Fetch_Dept()

        CmbxCateg.Items.Clear()
        CmbxCateg.Text = ""
        CmbxCateg.Text = "Select"
        Try
            Fetch_Ename_Cmd = New SqlCommand("select deptname from finactDept where Depttype='" & (DptType) & "'and deptdelstatus=1 order by deptname", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            While Fetch_Ename_Rdr.Read()
                CmbxCateg.Items.Add(Fetch_Ename_Rdr(0))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_Rdr.Close()


        End Try

    End Sub

    Private Sub Fetch_Desig()
        CmbxCateg.Items.Clear()
        CmbxCateg.Text = ""
        CmbxCateg.Text = "Select"

        Try
            Fetch_Ename_Cmd = New SqlCommand("select desiname from finactDesi where desidelstatus=1 order by desiname", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            While Fetch_Ename_Rdr.Read()
                CmbxCateg.Items.Add(Fetch_Ename_Rdr(0))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_Rdr.Close()


        End Try
    End Sub


    Private Sub CmbxSelCritera_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSelCritera.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then

            LblCateg.Visible = True
            CmbxCateg.Visible = True
            LblCateg.Location = New System.Drawing.Point(22, 148)
            CmbxCateg.Location = New System.Drawing.Point(170, 148)
            LblCateg.Text = CmbxSelCritera.Text
            If LblCateg.Text = "Branch" Then
                DptType = "Brnch"
                Fetch_Dept()
            ElseIf LblCateg.Text = "Category" Then
                DptType = "Catgri"
                Fetch_Dept()
            ElseIf LblCateg.Text = "Department" Then
                DptType = "Dept"
                Fetch_Dept()
            ElseIf LblCateg.Text = "Designation" Then
                Fetch_Desig()
            End If
            CmbxCateg.Focus()

        End If
    End Sub


    Private Sub CmbxCateg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCateg.GotFocus
        If CmbxCateg.Items.Count > 0 Then
            CmbxCateg.DroppedDown = True

        End If
    End Sub

    Private Sub Fetch_Usrdfin_Payhed()
        Dim count As Integer = 0
        Dim list_add As Boolean
        no_of_payhed = 0
        Fetch_Payhead()
        k = 0
        While count < Count_Payhead And Min_Payhead <= Max_Payhead
            Try
                Loan_Salry_Cmd = New SqlCommand("select PheadName,PheadComp,PheadType from FinactPayHead where PheadDelstatus=0 and PheadId='" & (Min_Payhead) & "'and PheadCalmtd='As User Defined Value'", FinActConn)
                Loan_Salry_Rdr = Loan_Salry_Cmd.ExecuteReader
                Loan_Salry_Rdr.Read()
                If Loan_Salry_Rdr.HasRows = True Then
                    Payhead_Name = Loan_Salry_Rdr(0)
                    Ern_Deduc = Loan_Salry_Rdr(1)
                    Arr_PheadType(k) = Loan_Salry_Rdr(2)
                    list_add = True
                    no_of_payhed = no_of_payhed + 1
                    k = k + 1
                ElseIf Loan_Salry_Rdr.HasRows = False Then
                    list_add = False
                    Count_Payhead = Count_Payhead + 1

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Loan_Salry_Rdr.Close()
                Loan_Salry_Cmd = Nothing
            End Try
            If list_add = True Then
                'Fetch_Payhead_Amt()
                ' ListView1.Items.Add(Payhead_Name)
                Dim dgr As DataGridViewRow
                Dim cel As DataGridViewTextBoxCell

                dgr = New DataGridViewRow()

                cel = New DataGridViewTextBoxCell()
                cel.Value = Payhead_Name
                dgr.Cells.Add(cel)

                cel = New DataGridViewTextBoxCell()
                cel.Value = ""
                dgr.Cells.Add(cel)
                Me.DataGridAll.Rows.Add(dgr)
            End If
            Min_Payhead = Min_Payhead + 1
            count = count + 1
        End While
      
    End Sub


    Private Sub CmbxCateg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCateg.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            Dim no_of_recrds As Integer = 0
            Dim Min_Eid As Integer = 0
            'Try
            '    Loan_Salry_Cmd = New SqlCommand("select min(AslryEmpid),count(AslryId) from FinactAutoSalary where Aslrydelstatus=0 and AslryType=0 and AslryMnth='" & (LblMnth.Text) & "'", FinActConn)
            '    Loan_Salry_Rdr = Loan_Salry_Cmd.ExecuteReader
            '    Loan_Salry_Rdr.Read()
            '    If Loan_Salry_Rdr.HasRows = True Then
            '        Min_Eid = Loan_Salry_Rdr(0)
            '        no_of_recrds = Loan_Salry_Rdr(1)

            '    End If
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'Finally
            '    Loan_Salry_Rdr.Close()
            '    Loan_Salry_Cmd = Nothing
            'End Try
           

            'If no_of_recrds = 0 Then
            LstvewAll.Items.Clear()
            LstvewAll.Visible = True
            Me.Size = New System.Drawing.Point(1010, 530)
            LstvewAll.Location = New System.Drawing.Point(10, 200)

            createsummary()
            add_itms_to_list()
            totl_rec = LstvewAll.Items.Count
            If tot_recrds > 0 Then
                If totl_rec > 0 Then
                    DataGridAll.Visible = True
                    DataGridAll.Location = New System.Drawing.Point(250, 300)
                    fill()
                    i = 0

                    Fetch_Usrdfin_Payhed()
                    flag = False


                    Me.DataGridAll.Focus()
                    DataGridAll.CurrentCell = DataGridAll.Rows(0).Cells(1)
                ElseIf totl_rec = 0 Then
                    MsgBox("No Employee Record found to generate Salary Slip", MsgBoxStyle.Information, "Salary Slip")
                    CmbxSelCritera.Focus()
                    Exit Sub
                End If
                'ElseIf no_of_recrds > 0 Then
                '    MsgBox("Salary Slips have already been generated of all employees for '" & (CmbxCateg.Text) & "'", MsgBoxStyle.Information, "Find Record")
                '    CmbxSelCritera.Focus()
                'End If
            End If
        End If
    End Sub

    Private Sub fill()
        Try
            Me.DataGridAll.Columns.Clear()
            Me.DataGridAll.Rows.Clear()
            Me.DataGridAll.Columns.Add("Name", "Pay Head Name")
            Me.DataGridAll.Columns.Add("Amt", "Amount")
           
            Me.DataGridAll.ColumnHeadersHeight = 30
            Me.DataGridAll.Columns(0).Width = 180
            Me.DataGridAll.Columns(1).Width = 180

            Me.DataGridAll.Columns(0).ReadOnly = True

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            Me.DataGridAll.AutoResizeColumns()
            Me.DataGridAll.Sort(Me.DataGridAll.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        End Try

    End Sub

    Dim flag As Boolean = False

    Private Sub DataGridAll_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridAll.CellEndEdit
       
    End Sub

    Private Sub DataGridAll_EditModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridAll.EditModeChanged
        If RbAll.Checked = True Then
            If Me.DataGridAll.SelectedRows(0).Index = no_of_payhed - 1 Then
                Me.DataGridAll.EditMode = DataGridViewEditMode.EditOnF2


            End If
        End If
    End Sub

    'Private Sub DataGridAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridAll.GotFocus
    ' Me.DataGridAll.Rows(0).Selected = True
    ' Me.DataGridAll.SelectedRows(0).Cells(1).Selected = True
    ' Me.DataGridAll.BeginEdit(True)
    'End Sub
    Private Sub DataGridAll_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridAll.KeyDown
        'If e.KeyCode = Keys.F10 Then
        '    MsgBox("s")
        '    BtnSave.Focus()


        'End If
        ''If e.KeyCode = Keys.Enter Then
        ''    If flag Then
        ''        e.Handled = True
        ''        cntr1 = 0
        ''        While cntr1 < no_of_payhed
        ''            If DataGridAll.Rows(cntr1).Cells(1).Value = "" Then
        ''                arr(cntr1) = 0
        ''            Else
        ''                'If e.KeyValue < 48 Or e.KeyValue > 57 Then
        ''                '    e.Handled = True
        ''                'Else
        ''                arr(cntr1) = DataGridAll.Rows(cntr1).Cells(1).Value
        ''                cntr1 += 1
        ''                'Else
        ''                '    MsgBox("Only Numeric values are allowed", MsgBoxStyle.Information, "Validation")
        ''            End If

        ''        End While
        ''        'DataGridAll.Visible = False
        ''        If BtnFnd.Text = "&Find" Then
        ''            DataGridAll.Visible = False
        ''            MsgBox("Entered amount of Pay heads will be applicable for all employees", MsgBoxStyle.Exclamation, "Alert")

        ''            If tot_recrds > 0 Then
        ''                totl_rec = LstvewAll.Items.Count
        ''                cntr1 = 0

        ''                i = 0
        ''                While i < tot_recrds
        ''                    cntr1 = 0
        ''                    k = 0
        ''                    phed_ern = 0
        ''                    phed_deduc = 0
        ''                    While cntr1 < no_of_payhed And k < no_of_payhed
        ''                        LstvewAll.Items(i).SubItems.Add(arr(cntr1))
        ''                        ' all_payhedamt = all_payhedamt + arr(cntr1)
        ''                        If (Arr_PheadType(k)) = "EREmp" Or (Arr_PheadType(k)) = "REB" Then
        ''                            phed_ern = phed_ern + arr(cntr1)
        ''                        ElseIf (Arr_PheadType(k)) = "DEEmp" Or (Arr_PheadType(k)) = "ESDed" Or (Arr_PheadType(k)) = "ESCon" Then
        ''                            phed_deduc = phed_deduc + arr(cntr1)

        ''                        End If
        ''                        cntr1 += 1
        ''                        k = k + 1
        ''                    End While

        ''                    Dim all_netslry, ern, advnc, loan As Double
        ''                    all_netslry = 0
        ''                    ern = 0
        ''                    advnc = 0
        ''                    loan = 0
        ''                    ern = CDbl(LstvewAll.Items(i).SubItems(5).Text)
        ''                    advnc = CDbl(LstvewAll.Items(i).SubItems(6).Text)
        ''                    loan = CDbl(LstvewAll.Items(i).SubItems(7).Text)
        ''                    all_netslry = ern + phed_ern - advnc - loan - phed_deduc
        ''                    LstvewAll.Items(i).SubItems(8).Text = all_netslry
        ''                    i = i + 1
        ''                End While
        ''                createsummary1()
        ''                cntr1 = 0
        ''                all_payhedamt = 0
        ''                While cntr1 < no_of_payhed
        ''                    all_payhedamt = all_payhedamt + arr(cntr1)
        ''                    cntr1 += 1
        ''                End While

        ''                l = 0
        ''                cntr1 = 0
        ''                Dim recrds As Integer = 0
        ''                recrds = LstvewAll.Items.Count
        ''                i = 0

        ''                Dim m As Integer = 0
        ''                While i < tot_recrds

        ''                    cntr1 = 0
        ''                    cntr1 = cntr1 + i
        ''                    i = i + 1
        ''                    all_payhedamt_ern = 0
        ''                    l = 0
        ''                    all_payhedamt_ern = 0
        ''                    While l < no_of_payhed1

        ''                        If Arr_Phed_Type2(l) = "EREmp" Or Arr_Phed_Type2(l) = "REB" Then
        ''                            all_payhedamt_ern = all_payhedamt_ern + phed_arr(cntr1)
        ''                        ElseIf Arr_Phed_Type2(l) = "DEEmp" Or Arr_Phed_Type2(l) = "ESDed" Or Arr_Phed_Type2(l) = "ESCon" Then
        ''                            all_payhedamt_deduct = all_payhedamt_deduct + phed_arr(cntr1)
        ''                        End If

        ''                        l = l + 1
        ''                        cntr1 = cntr1 + recrds
        ''                    End While
        ''                    arr_ern(m) = all_payhedamt_ern
        ''                    arr_deduct(m) = all_payhedamt_deduct
        ''                    m = m + 1
        ''                End While

        ''                i = 0
        ''                m = 0
        ''                While i < tot_recrds
        ''                    LstvewAll.Items(i).SubItems(8).Text = LstvewAll.Items(i).SubItems(8).Text + arr_ern(m) - arr_deduct(m)
        ''                    i = i + 1
        ''                    m = m + 1
        ''                End While

        ''                BtnSave.Focus()
        ''            Else

        ''            End If
        ''        End If
        ''    End If
        ''Else
        ''    e.Handled = True
        ''    Me.DataGridAll.BeginEdit(True)
        ''End If
        ''If Me.DataGridAll.SelectedRows(0).Index = no_of_payhed - 1 Then
        ''    flag = True
        ''End If
    End Sub


    Private Sub createsummary1()
        Dim count As Integer = 0
        Dim list_add As Boolean
        no_of_payhed1 = 0
        Fetch_Payhead()
        j = 0
        l = 0
        While count < Count_Payhead And Min_Payhead <= Max_Payhead
            Try
                Loan_Salry_Cmd = New SqlCommand("select PheadName,PheadComp,PheadType from FinactPayHead where PheadDelstatus=0 and PheadId='" & (Min_Payhead) & "'and PheadCalmtd<>'As User Defined Value'", FinActConn)
                Loan_Salry_Rdr = Loan_Salry_Cmd.ExecuteReader
                Loan_Salry_Rdr.Read()
                If Loan_Salry_Rdr.HasRows = True Then
                    Payhead_Name = Loan_Salry_Rdr(0)
                    Arr_Ern_Deduc(j) = Loan_Salry_Rdr(1)
                    Arr_Phed_Type2(l) = Loan_Salry_Rdr(2)
                    list_add = True
                    no_of_payhed1 = no_of_payhed1 + 1
                    j = j + 1
                    l = l + 1
                ElseIf Loan_Salry_Rdr.HasRows = False Then
                    list_add = False
                    Count_Payhead = Count_Payhead + 1

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Loan_Salry_Rdr.Close()
                Loan_Salry_Cmd = Nothing
            End Try
            If list_add = True Then
                LstvewAll.Columns.Add(Payhead_Name, 80, HorizontalAlignment.Right)
                cntr = 0
                While cntr < tot_recrds
                    Fetch_Payhead_Amt()
                    cntr = cntr + 1
                End While
                'ElseIf list_add = False Then
                '    Exit Sub  

            End If

            Min_Payhead = Min_Payhead + 1
            count = count + 1
        End While
        i = 0
        cntr1 = 0
        p = 0
        ctr = 0
        'While i < totl_rec
        '    MsgBox(LstvewAll.Items(i).SubItems(1).Text)
        '    While cntr1 < INC_ARR
        '        If WrkDys_Arr(p) > 0 And LstvewAll.Items(i).SubItems(16).Text = arr_eid(ctr) Then
        '            LstvewAll.Items(i).SubItems.Add(phed_arr(cntr1))
        '            i += 1
        '        End If
        '        ctr += 1
        '        cntr1 += 1

        '        p += 1
        '        If p = tot_recrds Then
        '            p = 0
        '            i = 0
        '            ctr = 0
        '            cntr1 = tot_recrds
        '            While cntr1 < INC_ARR
        '                If WrkDys_Arr(p) > 0 Then
        '                    LstvewAll.Items(i).SubItems.Add(phed_arr(cntr1))
        '                    i += 1
        '                End If
        '                ctr += 1
        '                cntr1 += 1
        '                p += 1
        '            End While

        '        End If
        '    End While


        'End While

    End Sub


    Private Sub createsummary()
        Dim count As Integer = 0
        Dim list_add As Boolean
        no_of_payhed = 0
        Fetch_Payhead()
        While count < Count_Payhead And Min_Payhead <= Max_Payhead
            Try
                Loan_Salry_Cmd = New SqlCommand("select PheadName,PheadComp from FinactPayHead where PheadDelstatus=0 and PheadId='" & (Min_Payhead) & "'and PheadCalmtd='As User Defined Value'", FinActConn)
                Loan_Salry_Rdr = Loan_Salry_Cmd.ExecuteReader
                Loan_Salry_Rdr.Read()
                If Loan_Salry_Rdr.HasRows = True Then
                    Payhead_Name = Loan_Salry_Rdr(0)
                    Ern_Deduc = Loan_Salry_Rdr(1)
                    list_add = True
                    no_of_payhed = no_of_payhed + 1
                ElseIf Loan_Salry_Rdr.HasRows = False Then
                    list_add = False
                    Count_Payhead = Count_Payhead + 1

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Loan_Salry_Rdr.Close()
                Loan_Salry_Cmd = Nothing
            End Try
            If list_add = True Or BtnFnd.Text = "Delete" Then
                '          LstvewAll.Columns.IndexOf()
                LstvewAll.Columns.Add(Payhead_Name, 80, HorizontalAlignment.Right)
            End If
            Min_Payhead = Min_Payhead + 1
            count = count + 1
        End While

    End Sub

    Private Sub Fetch_DeptId()
        Try
            Fetch_Ename_Cmd = New SqlCommand("select deptid from finactDept where deptname='" & (CmbxCateg.Text) & "'and deptdelstatus=1 ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_Rdr.Read()
            All_Deptid = Fetch_Ename_Rdr(0)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_Rdr.Close()


        End Try

    End Sub

    Private Sub Fetch_DesigId()
        Try
            Fetch_Ename_Cmd = New SqlCommand("select desiid from finactDesi where desiname='" & (CmbxCateg.Text) & "'and desidelstatus=1 ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_Rdr.Read()
            All_Desiid = Fetch_Ename_Rdr(0)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_Rdr.Close()


        End Try
    End Sub

    Private Sub add_itms_to_list()
        tot_recrds = 0
        EmpId = 0
        ctr = 0
        cntr = 0
        r = 0
        dt = DateSerial(Year(DtpkrAutoSlry.Value.Date), Month(DtpkrAutoSlry.Value.Date), -1)

        If CmbxSelCritera.Text = "Category" Then
            Fetch_DeptId()
            Try

                Fetch_Ename_Cmd = New SqlCommand("select Finactempmstr.empname,Finactempmstr.empid,finactDesi.desiname,Finactempmstr.empgrade,finactDept.deptname from Finactempmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid where empdelstatus=1 and empcatid='" & (All_Deptid) & "'and empcateg='Working' and empjndt<='" & (dt) & "'", FinActConn)
                Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader()
                While Fetch_Ename_Rdr.Read()
                    If Fetch_Ename_Rdr.HasRows = True Then
                        lstvew = LstvewAll.Items.Add(Fetch_Ename_Rdr(0))
                        ' lstvew.SubItems.Add(Fetch_Ename_Rdr(1))
                        EmpId = Fetch_Ename_Rdr(1)
                        arr_eid(ctr) = Fetch_Ename_Rdr(1)

                        lstvew.SubItems.Add(Fetch_Ename_Rdr(2))
                        lstvew.SubItems.Add(Fetch_Ename_Rdr(3))
                        Arr_Bscsalary(cntr) = Fetch_Ename_Rdr(3)
                        lstvew.SubItems.Add(Fetch_Ename_Rdr(4))
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        'lstvew.SubItems.Add("")
                        'lstvew.SubItems.Add(Fetch_Ename_Rdr(1))
                    End If
                    ctr = ctr + 1
                    tot_recrds = tot_recrds + 1
                    cntr = cntr + 1
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Fetch_Ename_Rdr.HasRows = False Then
                    MsgBox("No Employee record found to generate Salary Slip", MsgBoxStyle.Information, "Find Record")
                End If
                Fetch_Ename_Rdr.Close()
                Fetch_Ename_Cmd = Nothing
            End Try
        ElseIf CmbxSelCritera.Text = "Designation" Then
            Fetch_DesigId()
            Try

                Fetch_Ename_Cmd = New SqlCommand("select Finactempmstr.empname,Finactempmstr.empid,finactDesi.desiname,Finactempmstr.empgrade,finactDept.deptname from Finactempmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid  where empdelstatus=1 and empdesiid='" & (All_Desiid) & "'and empcateg='Working' and empjndt<='" & (dt) & "' ", FinActConn)
                Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader()
                While Fetch_Ename_Rdr.Read()
                    If Fetch_Ename_Rdr.HasRows = True Then
                        lstvew = LstvewAll.Items.Add(Fetch_Ename_Rdr(0))
                        ' lstvew.SubItems.Add(Fetch_Ename_Rdr(1))
                        EmpId = Fetch_Ename_Rdr(1)
                        arr_eid(ctr) = Fetch_Ename_Rdr(1)

                        lstvew.SubItems.Add(Fetch_Ename_Rdr(2))
                        lstvew.SubItems.Add(Fetch_Ename_Rdr(3))
                        Arr_Bscsalary(cntr) = Fetch_Ename_Rdr(3)
                        lstvew.SubItems.Add(Fetch_Ename_Rdr(4))
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                    End If
                    ctr = ctr + 1
                    tot_recrds = tot_recrds + 1
                    cntr = cntr + 1
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Fetch_Ename_Rdr.HasRows = False Then
                    MsgBox("No Employee record found to generate Salary Slip", MsgBoxStyle.Information, "Find Record")
                End If
                Fetch_Ename_Rdr.Close()
                Fetch_Ename_Cmd = Nothing
            End Try
        ElseIf CmbxSelCritera.Text = "Department" Then
            Fetch_DeptId()
            Try

                Fetch_Ename_Cmd = New SqlCommand("select Finactempmstr.empname,Finactempmstr.empid,finactDesi.desiname,Finactempmstr.empgrade,finactDept.deptname from Finactempmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join finactDesi on FinactEmpmstr.empdesiid=finactDesi.desiid where empdelstatus=1 and empdeptid='" & (All_Deptid) & "'and empcateg='Working' and empjndt<='" & (dt) & "'", FinActConn)
                Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader()
                While Fetch_Ename_Rdr.Read()
                    If Fetch_Ename_Rdr.HasRows = True Then
                        lstvew = LstvewAll.Items.Add(Fetch_Ename_Rdr(0))
                        ' lstvew.SubItems.Add(Fetch_Ename_Rdr(1))
                        EmpId = Fetch_Ename_Rdr(1)
                        arr_eid(ctr) = Fetch_Ename_Rdr(1)

                        lstvew.SubItems.Add(Fetch_Ename_Rdr(2))
                        lstvew.SubItems.Add(Fetch_Ename_Rdr(3))
                        Arr_Bscsalary(cntr) = Fetch_Ename_Rdr(3)
                        lstvew.SubItems.Add(Fetch_Ename_Rdr(4))
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        lstvew.SubItems.Add("")
                        'lstvew.SubItems.Add("")
                        'lstvew.SubItems.Add(Fetch_Ename_Rdr(1))
                    End If
                    ctr = ctr + 1
                    cntr = cntr + 1
                    tot_recrds = tot_recrds + 1
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Fetch_Ename_Rdr.HasRows = False Then
                    MsgBox("No Employee record found to generate Salary Slip", MsgBoxStyle.Information, "Find Record")
                End If
                Fetch_Ename_Rdr.Close()
                Fetch_Ename_Cmd = Nothing
            End Try
        End If
        If tot_recrds > 0 Then
            Mnthvalue()
            wrkdys_flag = True
            all_flag = False
            i = 0
            p = 0
            ctr = 0
            While i < tot_recrds
                Fetch_WrkDays()
                i = i + 1
                ctr += 1
            End While
            all_flag = True
            wrkdys_flag = False
            r = 0
            i = 0
            ctr = 0
            cntr = 0
            While r < tot_recrds
                Chek_Recrd()
                If cnt_slip > 0 Then

                    Fetch_WrkDays()
                    PerdaySalry()
                    Fetch_AdvncAmt()
                    Fetch_Loan()
                    i = i + 1
                ElseIf cnt_slip = 0 Then
                    LstvewAll.Items(i).Remove()
                End If
                r = r + 1
                ctr = ctr + 1
                cntr = cntr + 1
            End While




        ElseIf tot_recrds <= 0 Then
            Exit Sub

        End If

    End Sub

    Private Sub LstvewPayhed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstvewPayhed.Click
        Dim inx As Integer = 0
        Dim chk_edt As String = ""
        cnt = LstvewPayhed.Items.Count

        Try
            inx = LstvewPayhed.SelectedItems(0).Index
            chk_edt = LstvewPayhed.Items(inx).SubItems(2).Text
            If chk_edt = "As User Defined Value" Then
                LstvewPayhed.LabelEdit = True
            ElseIf chk_edt <> "As User Defined Value" Then
                LstvewPayhed.LabelEdit = False
                MsgBox("Can't edit this Amount", MsgBoxStyle.Critical, "Alert")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub LstvewPayhed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LstvewPayhed.KeyPress
        'If LstvewPayhed.LabelEdit = True Then
        '    Dim tb As TextBox = CType(sender, TextBox)
        '    Dim chr As Char = e.KeyChar
        '    If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
        '        e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        '    ElseIf e.KeyChar = "." Then
        '        If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
        '            e.Handled = True
        '        End If
        '    ElseIf e.KeyChar = "-" Then

        '        If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
        '            e.Handled = True
        '        End If
        '    ElseIf Not Char.IsControl(e.KeyChar) Then
        '        e.Handled = True
        '    End If
        'End If
        If LstvewPayhed.LabelEdit = True Then
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(e.KeyChar)
            ElseIf e.KeyChar = "." Then

                e.Handled = True
            End If
        End If


        '[ End If
    End Sub

   
    Private Sub LstvewAll_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstvewAll.VisibleChanged
        If LstvewAll.Visible = True And all_flag = True Then
            BtnSave.Enabled = True
        ElseIf LstvewAll.Visible = False And all_flag = True Then
            BtnSave.Enabled = False
        End If
    End Sub

    Private Sub numericTextboxKeyPress1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PhedAmt.KeyPress
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "." Then
            If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                e.Handled = True
            End If
        ElseIf e.KeyChar = "-" Then

            If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                e.Handled = True
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub GrpBxPayHed_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrpBxPayHed.VisibleChanged
        If GrpBxPayHed.Visible = True Then
            BtnSave.Enabled = False
        End If
    End Sub

    Private Sub DataGridAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridAll.Leave
        cntr1 = 0
        While cntr1 < no_of_payhed
            If DataGridAll.Rows(cntr1).Cells(1).Value = "" Then
                arr(cntr1) = 0
            Else
                'If e.KeyValue < 48 Or e.KeyValue > 57 Then
                '    e.Handled = True
                'Else
                arr(cntr1) = DataGridAll.Rows(cntr1).Cells(1).Value
                cntr1 += 1
                'Else
                '    MsgBox("Only Numeric values are allowed", MsgBoxStyle.Information, "Validation")
            End If

        End While
        ' DataGridAll.Visible = False

        If BtnFnd.Text = "&Delete" Then

            cntr1 = 0
            i = 0
            'While i < tot_recrds
            '    cntr1 = 0
            k = 0
            phed_ern = 0
            phed_deduc = 0
            While cntr1 < no_of_payhed And k < no_of_payhed
                'LstvewAll.Items(i).SubItems.Add(arr(cntr1))
                ' all_payhedamt = all_payhedamt + arr(cntr1)
                If (Arr_PheadType(k)) = "EREmp" Or (Arr_PheadType(k)) = "REB" Then
                    phed_ern = phed_ern + arr(cntr1)

                ElseIf (Arr_PheadType(k)) = "DEEmp" Or (Arr_PheadType(k)) = "ESDed" Or (Arr_PheadType(k)) = "ESCon" Then
                    phed_deduc = phed_deduc + arr(cntr1)

                End If
                cntr1 += 1
                k = k + 1
                'End While

               
                'i = i + 1
            End While

            Dim all_netslry, ern, advnc, loan As Double
            all_netslry = 0
            ern = 0
            advnc = 0
            loan = 0
            ern = CDbl(LblErnAmt.Text)
            advnc = CDbl(LblAdvAmt.Text)
            loan = CDbl(LblLoan.Text)
            LblPhedErn.Text = FormatNumber(ern + phed_ern + add_payhed, 2)
            LblPhedDeduc.Text = FormatNumber(advnc + loan + phed_deduc, 2)
            all_netslry = CDbl(LblPhedErn.Text) - CDbl(LblPhedDeduc.Text)
            LblNetSlry.Text = FormatNumber(all_netslry, 2)
          
            'arr_ern(m) = all_payhedamt_ern
            'arr_deduct(m) = all_payhedamt_deduct
            BtnSave.Focus()
        End If
        If BtnFnd.Text = "&Find" Then
            DataGridAll.Visible = False
            MsgBox("Entered amount of Pay heads will be applicable for all employees", MsgBoxStyle.Exclamation, "Alert")
            totl_rec = 0
            'totl_rec = tot_recrds
            totl_rec = LstvewAll.Items.Count
            If totl_rec > 0 Then
                ' 
                cntr1 = 0
                i = 0
                While i < totl_rec
                    cntr1 = 0
                    k = 0
                    phed_ern = 0
                    phed_deduc = 0
                    While cntr1 < no_of_payhed And k < no_of_payhed
                        LstvewAll.Items(i).SubItems.Add(arr(cntr1))
                        ' all_payhedamt = all_payhedamt + arr(cntr1)
                        If (Arr_PheadType(k)) = "EREmp" Or (Arr_PheadType(k)) = "REB" Then
                            phed_ern = phed_ern + arr(cntr1)
                        ElseIf (Arr_PheadType(k)) = "DEEmp" Or (Arr_PheadType(k)) = "ESDed" Or (Arr_PheadType(k)) = "ESCon" Then
                            phed_deduc = phed_deduc + arr(cntr1)

                        End If
                        cntr1 += 1
                        k = k + 1
                    End While

                    Dim all_netslry, ern, advnc, loan As Double
                    all_netslry = 0
                    ern = 0
                    advnc = 0
                    loan = 0
                    ern = CDbl(LstvewAll.Items(i).SubItems(5).Text)
                    advnc = CDbl(LstvewAll.Items(i).SubItems(6).Text)
                    loan = CDbl(LstvewAll.Items(i).SubItems(7).Text)
                    all_netslry = ern + phed_ern - advnc - loan - phed_deduc
                    LstvewAll.Items(i).SubItems(8).Text = all_netslry
                    i = i + 1
                End While
                createsummary1()
                cntr1 = 0
                all_payhedamt = 0
                While cntr1 < no_of_payhed
                    all_payhedamt = all_payhedamt + arr(cntr1)
                    cntr1 += 1
                End While

                l = 0
                cntr1 = 0
                Dim recrds As Integer = 0
                recrds = LstvewAll.Items.Count
                i = 0

                Dim m As Integer = 0
                While i < totl_rec

                    cntr1 = 0
                    cntr1 = cntr1 + i
                    i = i + 1
                    all_payhedamt_ern = 0
                    l = 0
                    all_payhedamt_ern = 0
                    While l < no_of_payhed1
                        If Arr_Phed_Type2(l) = "EREmp" Or Arr_Phed_Type2(l) = "REB" Then
                            all_payhedamt_ern = all_payhedamt_ern + phed_arr(cntr1)
                        ElseIf Arr_Phed_Type2(l) = "DEEmp" Or Arr_Phed_Type2(l) = "ESDed" Or Arr_Phed_Type2(l) = "ESCon" Then
                            all_payhedamt_deduct = all_payhedamt_deduct + phed_arr(cntr1)
                        End If

                        l = l + 1
                        cntr1 = cntr1 + recrds
                    End While
                    arr_ern(m) = all_payhedamt_ern

                    arr_deduct(m) = all_payhedamt_deduct
                    m = m + 1
                End While

                i = 0
                m = 0
                While i < totl_rec
                    LstvewAll.Items(i).SubItems(8).Text = LstvewAll.Items(i).SubItems(8).Text + arr_ern(m) - arr_deduct(m)

                    i = i + 1
                    m = m + 1
                End While
                ' BtnSave.Focus()

                'Else

            End If


        End If
        BtnSave.Focus()
        '    End If
        'Else
        'e.Handled = True
        'Me.DataGridAll.BeginEdit(True)
        'End If
        'If Me.DataGridAll.SelectedRows(0).Index = no_of_payhed - 1 Then
        '    flag = True
        'End If
    End Sub

    Private Sub Chek_Recrd()
     
        Try
            Fetch_Ename_Cmd = New SqlCommand("select count(AttdId) from Finact_Attd where AttdEmpid='" & (arr_eid(ctr)) & "'and SlrySlip=0 and month(Attddt)='" & (Mnth) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_Rdr.Read()
            cnt_slip = Fetch_Ename_Rdr(0)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_Rdr.Close()


        End Try

    End Sub

End Class
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmSalry
    Dim Fetch_Ename_Cmd As SqlCommand
    Dim Fetch_Ename_Rdr As SqlDataReader
    Dim Slry_Slip_Cmd As SqlCommand
    Dim Slry_Slip_Rdr As SqlDataReader
    Dim Loan_Slry_Cmd As SqlCommand
    Dim Loan_Slry_Rdr As SqlDataReader
    Dim Loan_Advnc_Cmd As SqlCommand
    Dim Loan_Advnc_Rdr As SqlDataReader
    Dim Fetch_MinDt_Cmd As SqlCommand
    Dim Fetch_MinDt_Rdr As SqlDataReader
    Dim EmpDptid As Integer
    Dim EmpDesid As Integer
    Dim EmpGrade As Double
    Dim Mnth As Integer
    Dim HDays As Integer
    Dim LWTPDays As Integer
    Dim Deduc As Double
    Dim TotDays As Integer
    Dim WrkingDays As Integer
    Dim PerDaySalry As Double
    Dim PerDaySalry1 As Double
    Dim Slry As Double
    Dim HrSalry As Double
    Dim OvrTmSlry As Double
    Dim EmId As Integer
    Dim TotSalry As Double
    Dim LstEmpid As Integer
    Dim LstEname As String
    Dim IndxMstr As Integer
    Dim Tot As Double
    Dim No_of_Recrd As Integer
    Dim SlryMnth As String
    Dim dt As Date
    Dim Lstvw As ListViewItem
    Dim TotOvrTm As Integer
    Dim FetchId As Integer
    Dim AdvAmt As Double
    Dim LoanAmt As Double
    Dim OthrDeduc As Double
    Dim TotlDeduc As Double
    Dim LnDeduc As Double
    Dim TotLoan As Double
    Dim Fetch_LnType As String
    Dim Reduc_Loan_Instlmnt As Double
    Dim Reduc_Loan_Amt As Double
    Dim Reduc_Loan_Intrst As Double
    Dim Reduc_Loan_RepayPrd As Integer
    Dim Pending_Instlmnt As Double
    Dim Extra_Instlmnt As Double
    Dim LnEffDt As Date
    Dim count_instlmnt As Integer
    Dim MnthlyInst As Double
    Dim Pending_Amt As Double
    Dim Extra_Amt As Double
    Dim Principal1 As Double
    Dim Amount1 As Double
    Dim ActualLnDeduc As Double
    Dim LnDeduction, ActualInstlmnt As Double
    Dim Mnthval, Yearval As Integer
    Dim prevsdt As Date
    Dim prevsmnth As Integer
    Dim TDays, HoliDays As Integer
    Dim count_Slrydt1 As Integer
    Dim count_Slrydt2 As Integer

    Dim Strtdt As Date
    Dim count_recrds As Integer
    Dim Add_Edit_Flag As Boolean
    Dim Min_SlryDt As Date
    Dim Count_Emprecrds As Integer
    Dim FirstSlryDt As Date
    Dim EmpJnDt As Date
    Dim no_rcrd_flag As Boolean
    Dim Strtdt_Emp_SlrySlip As Date
    Dim Count_Emp_Recrds As Integer
    Dim TMdays As Integer
    Dim Totldays As Integer
    Dim totday As Integer
    Dim mxdt As Date
    Dim sum_instlmnt As Double
    Dim left_instlmnt As Double
    Dim min_advdt As Date
    Dim Slrytotl, Advance, Loan As Double
    Dim Advnc_flag As Boolean



    Private Sub FrmSalry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New System.Drawing.Point(629, 667)
        PnlSlryDtl.Size = New System.Drawing.Point(597, 433)
        LblStrtDt.Visible = False
        Chek_Databse()
        If count_recrds = 0 And LblStrtDt.Visible = False Then
            Add_Edit_Flag = True
            PnlEmpDtl.Size = New System.Drawing.Point(597, 73)
            PnlEmpDtl.Location = New System.Drawing.Point(12, 80)
            LblStrtDt.Visible = True
        End If

        fetch_Adv_MinDt()
        DtPkrSlrySlipDt.Focus()
        DtPkrSlrySlipDt.MinDate = Strtdt
        'fetch_Cmbx_Ename()
        dt = DtPkrSlrySlipDt.Value.Date.AddMonths(-1)
        ' DtPkrSlrySlipDt.MaxDate = Today
        LblTotSlry.Visible = False
        PnlSlry.Visible = False
        BtnDelete.Text = "&Cancel"
        Me.Top = 0
        Me.Left = 0
        LblSlryOfMnth.Visible = False
        LblSlryMnth.Visible = False
        ListVew.Visible = False
        TxtLoan.Visible = False
        PnlRebt.Visible = False

        'CmbxEName.SelectedIndex = 0
        If Final_Slry = True Then
            Me.Text = "Full and Final"
            Label4.Visible = False
            LblMnth.Visible = False
            Label5.Location = New System.Drawing.Point(14, 11)
            LblDays.Location = New System.Drawing.Point(159, 11)
            BtnFind.Visible = False
            BtnSave.Location = New System.Drawing.Point(321, 609)

        ElseIf Final_Slry = False Then
            Me.Text = "Salary Slip"
        End If

    End Sub

    Private Sub fetch_Adv_MinDt()
        Try

            Slry_Slip_Cmd = New SqlCommand("Select costrtdt from Finactcogatemstr", FinActConn)

            Slry_Slip_Rdr = Slry_Slip_Cmd.ExecuteReader
            Slry_Slip_Rdr.Read()
            If Slry_Slip_Rdr.HasRows = True Then
                Strtdt = Slry_Slip_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Slry_Slip_Rdr.Close()
            Slry_Slip_Cmd = Nothing
        End Try
    End Sub

    Private Sub Chek_Databse()

        Try
            Slry_Slip_Cmd = New SqlCommand("Select count(SlryId) from FinactSlrySlip where Slrydelstatus=1", FinActConn)

            Slry_Slip_Rdr = Slry_Slip_Cmd.ExecuteReader
            Slry_Slip_Rdr.Read()
            If Slry_Slip_Rdr.HasRows = True Then
                count_recrds = Slry_Slip_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Slry_Slip_Rdr.Close()
            Slry_Slip_Cmd = Nothing
        End Try
    End Sub


    Private Sub Count_Recrds_Emp()

        Try
            Slry_Slip_Cmd = New SqlCommand("Select count(SlryId) from FinactSlrySlip where Slrydelstatus=1 and SlryEmpid='" & (EmId) & "'", FinActConn)

            Slry_Slip_Rdr = Slry_Slip_Cmd.ExecuteReader
            Slry_Slip_Rdr.Read()
            If Slry_Slip_Rdr.HasRows = True Then
                Count_Emp_Recrds = Slry_Slip_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Slry_Slip_Rdr.Close()
            Slry_Slip_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Min_Slrydt()
        Try

            Fetch_MinDt_Cmd = New SqlCommand("select SlryDt from FinactSlrySlip where SlryId=(select min(SlryId) from FinactSlrySlip where Slrydelstatus=1)", FinActConn)

            Fetch_MinDt_Rdr = Fetch_MinDt_Cmd.ExecuteReader
            Fetch_MinDt_Rdr.Read()
            If Fetch_MinDt_Rdr.HasRows = True Then
                Min_SlryDt = Fetch_MinDt_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_MinDt_Rdr.Close()
            Fetch_MinDt_Cmd = Nothing
        End Try
    End Sub


    Private Sub fetch_Cmbx_Ename()
        Dim days As Integer

        Dim dt As Date
        CmbxEName.Items.Clear()
        Dim PrevDate As Date
        Dim PrevMnth As Integer
        Dim Mnthname As String

        PrevDate = DtPkrSlrySlipDt.Value.Date.AddMonths(-1)
        PrevMnth = PrevDate.Month
        days = Date.DaysInMonth(PrevDate.Year, PrevDate.Month)
        Mnthname = MonthName(PrevMnth)
        If Final_Slry = False Then
            dt = DateSerial(Year(DtPkrSlrySlipDt.Value.Date), Month(DtPkrSlrySlipDt.Value.Date), 0)
        ElseIf Final_Slry = True Then
            dt = DtPkrSlrySlipDt.Value.Date
        End If

        Try

            'Fetch_Ename_Cmd = New SqlCommand("Select empname from FinactEmpmstr where empdelstatus=1 and empcateg='Working'and Month(empjnDt)<='" & (PrevMnth) & "'and year(empjndt)<='" & (Year(PrevDate)) & "'order by empname ", FinActConn)
            Fetch_Ename_Cmd = New SqlCommand("Select empname from FinactEmpmstr where empdelstatus=1 and empcateg='Working'and empjnDt<='" & (dt) & "'order by empname ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            While Fetch_Ename_Rdr.Read
                If Fetch_Ename_Rdr.HasRows = True Then
                    CmbxEName.Items.Add(Fetch_Ename_Rdr(0))
                End If
            End While
            If CmbxEName.Items.Count > 0 Then
                CmbxEName.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Fetch_Ename_Rdr.HasRows = True Then
                LblStrtDt.Visible = False
                PnlEmpDtl.Size = New System.Drawing.Point(597, 104)
                PnlEmpDtl.Location = New System.Drawing.Point(12, 48)

                CmbxEName.DroppedDown = True
                CmbxEName.SelectedIndex = 0
                no_rcrd_flag = False
            ElseIf Fetch_Ename_Rdr.HasRows = False Then
                'If DtPkrSlrySlipDt.Focused = False Then
                'DtPkrSlrySlipDt.Focus()
                'DtPkrSlrySlipDt.Select()

                'End If

                no_rcrd_flag = True

                ' DtPkrSlrySlipDt.Select()
            End If
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
            If no_rcrd_flag = True Then
                '
                LblStrtDt.Text = "Choose another date"
                LblStrtDt.Visible = True
                PnlEmpDtl.Size = New System.Drawing.Point(597, 71)
                PnlEmpDtl.Location = New System.Drawing.Point(12, 83)
                DtPkrSlrySlipDt.Focus()
                DtPkrSlrySlipDt.Select()
                MsgBox("No Employee record found to generate Salary Slip ", MsgBoxStyle.Information, "Employee Name")
            End If
        End Try

        'If no_rcrd_flag = True Then
        '    MsgBox("No Employee record found to generate Salary Slip ", MsgBoxStyle.Information, "Employee Name")
        '    DtPkrSlrySlipDt.Focus()

        'End If
    End Sub

    Private Sub Chk_Prevs2_SlrySlip()
        Dim PrevsMnthnm2 As String


        If Final_Slry = False Then
            Strtdt_Emp_SlrySlip = EmpJnDt.AddMonths(+1)
            dt = DtPkrSlrySlipDt.Value.Date.AddMonths(-2)
        ElseIf Final_Slry = True Then
            Strtdt_Emp_SlrySlip = EmpJnDt
            dt = DtPkrSlrySlipDt.Value.Date.AddMonths(-1)
        End If

        PrevsMnthnm2 = MonthName(dt.Month)

        Try
            Fetch_Ename_Cmd = New SqlCommand("Select count(SlryDt) from FinactSlrySlip where SlryEmpid='" & (EmId) & "'and SlryMnth='" & (PrevsMnthnm2) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.IsDBNull(0) = False Then
                    count_Slrydt2 = Fetch_Ename_Rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub Chk_Prevs1_SlrySlip()
        Dim PrevsMnthnm1 As String
        If Final_Slry = False Then
            Strtdt_Emp_SlrySlip = EmpJnDt.AddMonths(+1)
        ElseIf Final_Slry = True Then
            Strtdt_Emp_SlrySlip = EmpJnDt
        End If

        PrevsMnthnm1 = MonthName(Strtdt_Emp_SlrySlip.Month)

        Try
            Fetch_Ename_Cmd = New SqlCommand("Select count(SlryDt) from FinactSlrySlip where SlryEmpid='" & (EmId) & "'and SlryMnth='" & (PrevsMnthnm1) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.IsDBNull(0) = False Then
                    count_Slrydt1 = Fetch_Ename_Rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub Chk_RcrdofEmpl()
        Dim Year As String
        Dim Mnthvalue As Integer
        ' Fetch_Min_Slrydt()
        Mnthvalue = Min_SlryDt.Month
        Year = Min_SlryDt.Year
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select count(SlryId) from FinactSlrySlip where SlryEmpid='" & (EmId) & "'and Month(SlryDt)='" & (Mnthvalue) & "'and Year(SlryDt)='" & (Year) & "'and Slrydelstatus=1", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.IsDBNull(0) = False Then
                    Count_Emprecrds = Fetch_Ename_Rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_DeptName()
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select deptname from finactdept where deptid='" & (EmpDptid) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmpDptid) <> "" Then
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
            Fetch_Ename_Cmd = New SqlCommand("Select desiname from finactDesi where desiid='" & (EmpDesid) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmpDesid) <> "" Then
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

    Private Sub Maxdate()
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select max(SlryDt)from FinactSlrySlip where Slryempid='" & (EmId) & "'and Slrydelstatus=1 ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.IsDBNull(0) = False Then
                    mxdt = Fetch_Ename_Rdr(0)

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Fetch_Ename_Rdr.IsDBNull(0) = True Then
                mxdt = EmpJnDt
            End If
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Maxdate()
        Dim crntdt As Date
        Dim mxmnth, crntmnth As Integer
        Dim endday, crntday, mnthdiff, mxyear, crntyear As Integer
        Dim Salary As Double
        Salary = EmpGrade
        Maxdate()
        crntdt = DtPkrSlrySlipDt.Value.Date
        mxmnth = mxdt.Month
        mxyear = mxdt.Year
        crntyear = crntdt.Year

        endday = Date.DaysInMonth(mxdt.Year, mxdt.Month)
        crntmnth = crntdt.Month
        mnthdiff = crntmnth - mxmnth
        If crntdt >= mxdt Then
            'And mxmnth < crntmnth Then
            If mnthdiff = 0 And EmpJnDt.Month <> crntmnth Then
                totday = crntdt.Day
            ElseIf EmpJnDt.Month = crntmnth Then
                ' mnthdiff = 0 And
                ' totday = crntdt.Day - EmpJnDt.Day
                totday = crntdt.Day

            ElseIf mnthdiff > 0 Or mnthdiff < 0 Then
                crntday = crntdt.Day
                'lstday = mxdt.Day

                'diff = endday - lstday
                'totday = crntday + diff
                totday = crntday + endday
                If mnthdiff > 1 Or mnthdiff <> 0 And mnthdiff <> 1 And crntyear > mxyear Then
                    Dim cntr, fulmnth As Integer
                    cntr = 1
                    fulmnth = mnthdiff - 1
                    If crntyear > mxyear Then
                        'crntmnth = 12 - mxmnth + crntmnth + 1
                        While mxmnth + 1 < 13
                            totday = totday + Date.DaysInMonth(mxdt.AddMonths(+cntr).Year, mxdt.AddMonths(+cntr).Month)
                            cntr = cntr + 1
                            mxmnth = mxmnth + 1
                        End While

                        mxmnth = 1
                        While mxmnth < crntmnth
                            totday = totday + Date.DaysInMonth(mxdt.AddMonths(+cntr).Year, mxdt.AddMonths(+cntr).Month)
                            cntr = cntr + 1
                            mxmnth = mxmnth + 1
                        End While

                    Else
                        While mxmnth + 1 < crntmnth
                            totday = totday + Date.DaysInMonth(mxdt.AddMonths(+cntr).Year, mxdt.AddMonths(+cntr).Month)
                            cntr = cntr + 1
                            mxmnth = mxmnth + 1

                        End While
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub CmbxEName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEName.KeyDown

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If CmbxEName.SelectedIndex >= 0 Then
                Try
                    Fetch_Ename_Cmd = New SqlCommand("Select empid,empdeptid,empdesiid,empgrade,empjnDt from FinactEmpmstr where empname='" & (CmbxEName.Text) & "'", FinActConn)
                    Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
                    Fetch_Ename_Rdr.Read()
                    If Fetch_Ename_Rdr.HasRows = True Then
                        EmId = Fetch_Ename_Rdr(0)
                        EmpDptid = Fetch_Ename_Rdr(1)
                        EmpDesid = Fetch_Ename_Rdr(2)
                        EmpGrade = Fetch_Ename_Rdr(3)
                        EmpJnDt = Fetch_Ename_Rdr(4)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Fetch_Ename_Rdr.Close()
                    Fetch_Ename_Cmd = Nothing
                End Try
                Fnd_Recrd()
                Maxdate()
                Dim lstdat As Date
                Dim days As Integer
                days = mxdt.Day

                lstdat = mxdt.AddDays(-days)
               
                If No_of_Recrd = 0 Or No_of_Recrd > 0 And Final_Slry = True And lstdat < DtPkrSlrySlipDt.Value.Date Then
                    Chek_Databse()
                    Chk_Prevs2_SlrySlip()
                    Chk_Prevs1_SlrySlip()
                    Fetch_Min_Slrydt()
                    Count_Recrds_Emp()
                    If count_recrds > 0 Then
                        If count_Slrydt2 = 0 And DtPkrSlrySlipDt.Value.Date < Min_SlryDt Then
                            MsgBox("Starting Date to generate Salary Slip is '" & (Format(Min_SlryDt, "dd/MM/yyyy")) & "'", MsgBoxStyle.Information, "Salary Slip")
                            DtPkrSlrySlipDt.Focus()
                            DtPkrSlrySlipDt.Select()
                            Exit Sub

                        ElseIf Strtdt_Emp_SlrySlip < Min_SlryDt Then
                            If count_Slrydt2 = 0 And Month(DtPkrSlrySlipDt.Value.Date) >= Month(Min_SlryDt) Then
                                'And DtPkrSlrySlipDt.Value.Date > Strtdt_Emp_SlrySlip Then
                                'If count_Slrydt1 < 0 Then
                                ' If Count_Emp_Recrds > 0 Then
                                If Final_Slry = False Then
                                    MsgBox("Please generate the Salary of Previous Month first", MsgBoxStyle.Information, "Salary Slip")
                                    DtPkrSlrySlipDt.Focus()
                                    Exit Sub
                                End If

                            End If
                        ElseIf Strtdt_Emp_SlrySlip >= Min_SlryDt Then
                            If Final_Slry = False Then
                                Min_SlryDt = Strtdt_Emp_SlrySlip.AddMonths(+1)
                                'ElseIf Final_Slry = True Then
                                '    Min_SlryDt = Strtdt_Emp_SlrySlip
                            End If

                            If Final_Slry = False And count_Slrydt2 = 0 And Month(DtPkrSlrySlipDt.Value.Date) >= Month(Min_SlryDt) And DtPkrSlrySlipDt.Value.Date > Strtdt_Emp_SlrySlip Then
                                MsgBox("Please generate the Salary of Previous Month first", MsgBoxStyle.Information, "Salary Slip")
                                DtPkrSlrySlipDt.Focus()
                                Exit Sub
                                'ElseIf Final_Slry = True And count_Slrydt2 = 0 And Month(DtPkrSlrySlipDt.Value.Date) > Month(Min_SlryDt) And DtPkrSlrySlipDt.Value.Date > Strtdt_Emp_SlrySlip Then
                                '    MsgBox("Please generate the Salary of Previous Month first", MsgBoxStyle.Information, "Salary Slip")
                                '    DtPkrSlrySlipDt.Focus()
                                '    Exit Sub
                            End If
                        End If

                    End If

                    LblScale.Text = FormatNumber(EmpGrade, 2)
                    Fetch_DeptName()
                    Fetch_DesigName()
                    If Final_Slry = False Then
                        dt = DtPkrSlrySlipDt.Value.Date.AddMonths(-1)
                        LblMnth.Text = MonthName(dt.Month)
                        LblDays.Text = Date.DaysInMonth(dt.Year, dt.Month)
                    ElseIf Final_Slry = True Then
                        dt = DtPkrSlrySlipDt.Value.Date
                        LblMnth.Text = MonthName(dt.Month)
                        ' LblDays.Text = Date.DaysInMonth(dt.Year, dt.Month)
                        Fetch_Maxdate()
                        LblDays.Text = totday

                    End If

                    Count_Recrds_Emp()
                    If Count_Emp_Recrds = 0 Then
                        MsgBox((CmbxEName.Text) & "'s Joining Date is " & Format(EmpJnDt, "dd/MM/yyyy"), MsgBoxStyle.Exclamation, "Alert")
                    End If
                    Totldays = LblDays.Text
                    If Final_Slry = False Then
                        TotDays = LblDays.Text
                    ElseIf Final_Slry = True Then
                        'TotDays = DtPkrSlrySlipDt.Value.Day
                        TotDays = LblDays.Text
                    End If
                    If LblScale.Text <> "" Then
                        PerDaySalry = CDbl(LblScale.Text / Totldays)
                        HrSalry = FormatNumber(PerDaySalry / 24, 2)
                        TxtHDays.Focus()
                    End If
                Else

                    MsgBox("Salary Slip has already been generated for " & (CmbxEName.Text), MsgBoxStyle.Information, "Salary Slip")
                    DtPkrSlrySlipDt.Focus()
                    ClrValues()
                End If

            End If
        End If
        'End If
    End Sub


    Private Sub DtPkrSlrySlipDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtPkrSlrySlipDt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            fetch_Cmbx_Ename()
            If no_rcrd_flag = False Then
                CmbxEName.Focus()
                CmbxEName.SelectedIndex = 0
            End If

            'MsgBox(no_rcrd_flag)
            'Chek_Databse()
            'If count_recrds = 0 And LblStrtDt.Visible = True And no_rcrd_flag = False Then
            '    CmbxEName.Focus()
            '    LblStrtDt.Visible = False
            '    PnlEmpDtl.Size = New System.Drawing.Point(597, 104)
            '    PnlEmpDtl.Location = New System.Drawing.Point(12, 48)
            'ElseIf count_recrds = 0 And LblStrtDt.Visible = False And no_rcrd_flag = False Then
            '    CmbxEName.Focus()
            '    'ElseIf count_recrds > 0 And no_rcrd_flag = False Then
            '    '    DtPkrSlrySlipDt.Focus()
            '    '    DtPkrSlrySlipDt.Select()
            'ElseIf count_recrds > 0 And no_rcrd_flag = True Then
            '    CmbxEName.Focus()

            'End If


        End If
    End Sub

    'Private Sub TxtHDays_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHDays.GotFocus
    '    TxtHDays.Text = 0
    'End Sub


    Private Sub TxtHDays_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtHDays.KeyDown

        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If TxtHDays.Text = "" Then
                TxtHDays.Text = 0
                TxtLvWotPay.Focus()

            ElseIf TxtHDays.Text <> "" And LblDays.Text <> "" Then
                TDays = LblDays.Text
                HoliDays = TxtHDays.Text
                If HoliDays > TDays Then
                    TxtHDays.BackColor = Color.PapayaWhip
                    MsgBox("Invalid value", MsgBoxStyle.Information, "Holidays")
                    TxtHDays.Focus()
                    TxtHDays.SelectAll()
                    Exit Sub
                Else
                    If TxtLvWotPay.Text <> "" Then
                        LblWrkDays.Text = LblDays.Text - TxtHDays.Text - TxtLvWotPay.Text

                    End If
                    TxtLvWotPay.Focus()
                End If
            End If
        End If

    End Sub


    Private Sub TxtLvWotPay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLvWotPay.KeyDown

        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If TxtLvWotPay.Text = "" Then
                TxtLvWotPay.Text = 0

            End If

            If TxtHDays.Text <> "" And LblDays.Text <> "" And TxtLvWotPay.Text <> "" Then
               
                If TxtLvWotPay.Text > LblDays.Text - TxtHDays.Text Then
                    TxtLvWotPay.BackColor = Color.PapayaWhip
                    MsgBox("Invalid value", MsgBoxStyle.Information, "Leave")
                    TxtLvWotPay.Focus()
                    TxtLvWotPay.SelectAll()
                    Exit Sub


                Else
                    HDays = 0
                    LWTPDays = 0
                    If TxtHDays.Text <> "" Then
                        HDays = TxtHDays.Text
                    End If
                    If TxtLvWotPay.Text <> "" Then
                        LWTPDays = TxtLvWotPay.Text
                    End If
                    WrkingDays = TotDays - HDays - LWTPDays
                    Slry = WrkingDays * PerDaySalry
                    LblWrkDays.Text = WrkingDays
                    LblErnAmt.Text = FormatNumber(Slry, 2)
                    TxtOvrTime.Focus()
                End If
            ElseIf TxtHDays.Text = "" And LblDays.Text <> "" And TxtLvWotPay.Text <> "" Then

                If TxtLvWotPay.Text > LblDays.Text - TxtHDays.Text Then
                    TxtLvWotPay.BackColor = Color.PapayaWhip
                    MsgBox("Invalid value", MsgBoxStyle.Information, "Leave")
                    TxtLvWotPay.Focus()
                    TxtLvWotPay.SelectAll()
                    Exit Sub
                Else
                    HDays = 0
                    LWTPDays = 0
                    If TxtHDays.Text <> "" Then
                        HDays = TxtHDays.Text
                    End If
                    If TxtLvWotPay.Text <> "" Then
                        LWTPDays = TxtLvWotPay.Text
                    End If
                    WrkingDays = TotDays - LWTPDays
                    Slry = WrkingDays * PerDaySalry
                    LblWrkDays.Text = WrkingDays
                    LblErnAmt.Text = FormatNumber(Slry, 2)
                    TxtOvrTime.Focus()
                End If

            End If

            End If



    End Sub

    Private Sub TxtOvrTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOvrTime.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If TxtOvrTime.Text > TotOvrTm Then
                TxtOvrTime.BackColor = Color.PapayaWhip
                MsgBox("Invalid value", MsgBoxStyle.Information, "OverTime Hours")
                TxtOvrTime.Value = 0
                TxtOvrTime.Focus()
                TxtOvrTime.Select(0, Len(TxtOvrTime.Value))
            Else
                If BtnSave.Text = "&Save" Then
                    If Final_Slry = False Then
                        Fetch_Advance()
                    ElseIf Final_Slry = True Then
                        Fetch_Min_Advdt()
                        If Advnc_flag = True Then
                            Fetch_Final_Advance()
                        End If

                    End If

                    Fetch_Loan()
                End If

                OvrTmSlry = CDbl(TxtOvrTime.Value * HrSalry)
                LblOvrtmErn.Text = FormatNumber(OvrTmSlry, 2)

                Tot = Slry + OvrTmSlry
                LblTot.Text = FormatNumber(Tot, 2)
                If PnlRebt.Visible = False Then
                    TxtDeduc.Focus()
                End If
                
            End If
        End If

    End Sub

    Private Sub TxtDeduc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDeduc.KeyDown
        Dim Deduction, DeducTotl, Actualdeduc As Double

        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If TxtDeduc.Text = "" Then
                TxtDeduc.Text = FormatNumber(0, 2)
                OthrDeduc = TxtDeduc.Text
            ElseIf TxtDeduc.Text <> "" Then
                TotDays = LblDays.Text
                Totldays = LblDays.Text
                If Final_Slry = False Then
                    PerDaySalry = CDbl(LblScale.Text / Totldays)
                    HrSalry = FormatNumber(PerDaySalry / 24, 2)
                ElseIf Final_Slry = True Then
                    PerDaySalry = CDbl(LblScale.Text / 30)
                    HrSalry = FormatNumber(PerDaySalry / 24, 2)
                End If
                WrkingDays = TotDays - HDays - LWTPDays
                Slry = WrkingDays * PerDaySalry
                OvrTmSlry = CDbl(TxtOvrTime.Value * HrSalry)
                Tot = Slry + OvrTmSlry

                Slrytotl = CDbl(Tot)
                Advance = CDbl(LblAdvnc.Text)
                If LbLoan.Visible = True Then
                    Loan = CDbl(LblLoan.Text)
                End If
                If TxtLoan.Visible = True Then
                    Loan = CDbl(TxtLoan.Text)
                End If
                Deduction = CDbl(TxtDeduc.Text)
                DeducTotl = Advance + Loan + Deduction
                If DeducTotl > Slrytotl Then
                    If Slrytotl > Advance + Loan Then
                        Actualdeduc = Slrytotl - Advance - Loan
                        TxtDeduc.BackColor = Color.PapayaWhip
                        MsgBox("Can't Deduct more than '" & (Actualdeduc) & "'", MsgBoxStyle.Information, "Other Deduction")
                        TxtDeduc.Focus()
                        TxtDeduc.SelectAll()
                    ElseIf Slrytotl < Advance + Loan Then
                        MsgBox("The amount to be deducted is greater than the calculated Salary", MsgBoxStyle.Exclamation, "Warning")
                        RbWHoli.Focus()
                        Exit Sub
                    End If

                Else
                    TxtDeduc.Text = FormatNumber(TxtDeduc.Text, 2)
                    OthrDeduc = TxtDeduc.Text
                    RbWHoli.Focus()
                End If
                End If
        End If

    End Sub

    Private Sub RbWHoli_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbWHoli.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            RbWotHoli.Focus()
        End If
    End Sub

    Private Sub TxtLvWotPay_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLvWotPay.Leave
        Dim deduct_days, wrkdays As Integer

        Count_Recrds_Emp()

        If Count_Emp_Recrds = 0 And TxtLvWotPay.Text <> "" Then
            deduct_days = EmpJnDt.Day - 1
            wrkdays = TxtLvWotPay.Text
            If wrkdays < deduct_days Then
                MsgBox("Value should be more than or equalto " & (deduct_days), MsgBoxStyle.Information, "Leave")
                TxtLvWotPay.Focus()
                TxtLvWotPay.SelectAll()

                'ElseIf wrkdays > LblDays.Text - deduct_days - TxtHDays.Text Then
                '    MsgBox("Value should be less than or equalto " & (LblDays.Text - TxtHDays.Text - 1), MsgBoxStyle.Information, "Leave")
                '    TxtLvWotPay.Focus()
                '    TxtLvWotPay.SelectAll()

            End If
        End If
    End Sub

    Private Sub TxtOvrTime_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOvrTime.GotFocus
        If LblDays.Text <> "" Then
            TotOvrTm = (LblDays.Text * 24) - (LblDays.Text * 8)
            TxtOvrTime.Maximum = TotOvrTm
        End If
        TxtOvrTime.Select(0, Len(TxtOvrTime.Value))


    End Sub

    Private Sub Fetch_Advance()

        dt = DtPkrSlrySlipDt.Value.Date.AddMonths(-1)
        Mnthval = dt.Month
        Yearval = dt.Year
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select AdvAmt from FinactAdvance where AdvEmpId='" & (EmId) & "'and AdvStatus<>'Adjusted' and Advdelstatus=1 and month(Advdt)='" & (Mnthval) & "'and Year(Advdt)='" & (Yearval) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.HasRows = True And BtnSave.Text = "&Save" Then
                    LblAdvnc.Text = FormatNumber(Fetch_Ename_Rdr(0), 2)
                    AdvAmt = LblAdvnc.Text
                ElseIf Fetch_Ename_Rdr.HasRows = False And BtnSave.Text = "&Save" Then
                    LblAdvnc.Text = FormatNumber(0, 2)
                    AdvAmt = LblAdvnc.Text
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub


    Private Sub Fetch_Min_Advdt()
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select min(AdvDt) from FinactAdvance where AdvEmpId='" & (EmId) & "'and AdvStatus<>'Adjusted' and Advdelstatus=1 ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.IsDBNull(0) = False And BtnSave.Text = "&Save" Then
                    min_advdt = Fetch_Ename_Rdr(0)
                    Advnc_flag = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Fetch_Ename_Rdr.IsDBNull(0) = True And BtnSave.Text = "&Save" Then
                LblAdvnc.Text = FormatNumber(0, 2)
                AdvAmt = LblAdvnc.Text
                Advnc_flag = False
            End If
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Final_Advance()
        Fetch_Min_Advdt()
        dt = min_advdt
        Mnthval = dt.Month
        Yearval = dt.Year
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select sum(AdvAmt) from FinactAdvance where AdvEmpId='" & (EmId) & "'and AdvStatus<>'Adjusted' and Advdelstatus=1 and month(Advdt) between '" & (Mnthval) & "'and'" & (DtPkrSlrySlipDt.Value.Date.Month) & "'and Year(Advdt)='" & (Yearval) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.HasRows = True And BtnSave.Text = "&Save" Then
                    LblAdvnc.Text = FormatNumber(Fetch_Ename_Rdr(0), 2)
                    AdvAmt = LblAdvnc.Text
                ElseIf Fetch_Ename_Rdr.HasRows = False And BtnSave.Text = "&Save" Then
                    LblAdvnc.Text = FormatNumber(0, 2)
                    AdvAmt = LblAdvnc.Text
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
        'dt = DtPkrSlrySlipDt.Value.Date.AddMonths(-1)
        'Mnthval = dt.Month
        'Yearval = dt.Year

        Try
            Fetch_Ename_Cmd = New SqlCommand("Select LnEffDt from FinactLoan where LnEmpId='" & (EmId) & "'and LnStatus='Not Adjusted'and Lndelstatus=1 ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmId) <> "" Then
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
        Fetch_LnEffDt()

        prevsdt = LnEffDt.AddMonths(+1)
        prevsmnth = prevsdt.Month

        Try
            Loan_Slry_Cmd = New SqlCommand("select count(SlryLnDeduc) from FinactSlrySlip where SlryEmpid='" & (EmId) & "'and Slrydelstatus=1 and month(SlryDt) between '" & (prevsmnth) & "'and '" & (DtPkrSlrySlipDt.Value.Date.Month) & "'and year(SlryDt)='" & (LnEffDt.Year) & "'", FinActConn)
            Loan_Slry_Rdr = Loan_Slry_Cmd.ExecuteReader
            Loan_Slry_Rdr.Read()
            If Loan_Slry_Rdr.IsDBNull(0) = False Then
                count_instlmnt = Loan_Slry_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Loan_Slry_Rdr.Close()
            Loan_Slry_Cmd = Nothing
        End Try
    End Sub

    Private Sub Sum_Reduc_Instlmnt()
        Fetch_LnEffDt()

        prevsdt = LnEffDt.AddMonths(+1)
        prevsmnth = prevsdt.Month

        Try
            Loan_Slry_Cmd = New SqlCommand("select sum(SlrylnDeduc) from FinactSlrySlip where SlryEmpid='" & (EmId) & "'and Slrydelstatus=1 and month(SlryDt) between '" & (prevsmnth) & "'and '" & (DtPkrSlrySlipDt.Value.Date.Month) & "'and year(SlryDt)='" & (LnEffDt.Year) & "'", FinActConn)
            Loan_Slry_Rdr = Loan_Slry_Cmd.ExecuteReader
            Loan_Slry_Rdr.Read()
            If Loan_Slry_Rdr.IsDBNull(0) = True Then
                sum_instlmnt = 0
            Else
                sum_instlmnt = Loan_Slry_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Loan_Slry_Rdr.Close()
            Loan_Slry_Cmd = Nothing
        End Try
    End Sub

    Private Sub Prevs_Loan_Instlmnt()
        prevsdt = DtPkrSlrySlipDt.Value.Date.AddMonths(-1)
        prevsmnth = prevsdt.Month
        Pending_Instlmnt = 0
        Try
            Loan_Slry_Cmd = New SqlCommand("select SlryLnDeduc,ActualLnInstlmnt from FinactSlrySlip where SlryEmpid='" & (EmId) & "'and Slrydelstatus=1 and month(SlryDt)='" & (prevsmnth) & "'", FinActConn)
            Loan_Slry_Rdr = Loan_Slry_Cmd.ExecuteReader
            Loan_Slry_Rdr.Read()
            If Loan_Slry_Rdr.HasRows = True Then
                LnDeduction = FormatNumber(Loan_Slry_Rdr(0), 2)
                ActualInstlmnt = FormatNumber(Loan_Slry_Rdr(1), 2)
                If ActualInstlmnt > LnDeduction Then
                    Pending_Instlmnt = FormatNumber(ActualInstlmnt - LnDeduction, 2)

                ElseIf ActualInstlmnt < LnDeduction Then
                    Pending_Instlmnt = FormatNumber(0, 2)
                End If
            ElseIf Loan_Slry_Rdr.HasRows = False Then
                Pending_Instlmnt = FormatNumber(0, 2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Loan_Slry_Rdr.Close()
            Loan_Slry_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_Loan()
        Fetch_LnEffDt()
        Dim LnType As String
        Dim Mnthval1 As Integer
        Dim Principal, Deduct, Intrstvalue, Amount As Double
        Dim IntrstAppli As Boolean
        Mnthval1 = DtPkrSlrySlipDt.Value.Date.Month
        If Final_Slry = False Then
            dt = DtPkrSlrySlipDt.Value.Date.AddMonths(-1)
        ElseIf Final_Slry = True Then
            dt = DtPkrSlrySlipDt.Value.Date

        End If
        Mnthval = dt.Month
        Yearval = dt.Year
        Prevs_Loan_Instlmnt()
        Count_Reduc_Instlmnt()
        Sum_Reduc_Instlmnt()
        Find_loan_Slry()
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select MethdIntrst,MnthlyInst,LnAmt,LnRateIntrst,RepayPrd,LnIntrstAppli from FinactLoan where LnEmpId='" & (EmId) & "'and LnStatus<>'Adjusted' and Lndelstatus=1 and month(LnEffDt)<='" & (Mnthval) & "'and Year(LnEffDt)='" & (Yearval) & "' ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(EmId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.HasRows = True And BtnSave.Text = "&Save" Then
                    LnType = Fetch_Ename_Rdr(0)
                    IntrstAppli = Fetch_Ename_Rdr(5)
                    Reduc_Loan_Instlmnt = FormatNumber(Fetch_Ename_Rdr(1), 2)
                    Reduc_Loan_Amt = FormatNumber(Fetch_Ename_Rdr(2), 2)
                    Reduc_Loan_Intrst = FormatNumber(Fetch_Ename_Rdr(3), 2)
                    Reduc_Loan_RepayPrd = FormatNumber(Fetch_Ename_Rdr(4), 2)
                    If Final_Slry = False Then
                        If LnType = "Flat" And IntrstAppli = True Then
                            LblLoan.Visible = True
                            TxtLoan.Visible = False
                            LblLoan.Text = FormatNumber(Fetch_Ename_Rdr(1), 2)
                            LoanAmt = LblLoan.Text
                            TxtLoan.Text = FormatNumber(0, 2)
                        ElseIf LnType = "Reducing" And IntrstAppli = True Then
                            LblLoan.Visible = False
                            TxtLoan.Visible = True

                            If Reduc_Loan_RepayPrd - count_instlmnt = Reduc_Loan_RepayPrd Then

                                MnthlyInst = FormatNumber(Reduc_Loan_Instlmnt, 2)
                                TxtLoan.Text = FormatNumber(Reduc_Loan_Instlmnt, 2)
                            ElseIf Reduc_Loan_RepayPrd - count_instlmnt < Reduc_Loan_RepayPrd And Reduc_Loan_RepayPrd - count_instlmnt >= 1 Then

                                Deduct = Reduc_Loan_Amt / Reduc_Loan_RepayPrd
                                Principal1 = FormatNumber(Reduc_Loan_Amt - (count_instlmnt * Deduct), 2)
                                Principal = FormatNumber(Reduc_Loan_Amt - (count_instlmnt * Deduct) + Pending_Instlmnt, 2)
                                Intrstvalue = (Principal * Reduc_Loan_Intrst) / 100
                                Amount = Principal / (Reduc_Loan_RepayPrd - count_instlmnt)
                                MnthlyInst = FormatNumber(Amount + Intrstvalue)
                                TxtLoan.Text = FormatNumber(MnthlyInst, 2)
                            ElseIf Reduc_Loan_RepayPrd - count_instlmnt <= 0 And LnDeduc <> ActualLnDeduc Then
                                Principal = Pending_Instlmnt
                                Principal1 = Pending_Instlmnt
                                Intrstvalue = (Principal * Reduc_Loan_Intrst) / 100
                                Amount = Principal
                                MnthlyInst = FormatNumber(Amount + Intrstvalue)
                                TxtLoan.Text = FormatNumber(MnthlyInst, 2)
                            End If
                            LoanAmt = TxtLoan.Text
                            LblLoan.Text = FormatNumber(0, 2)
                        ElseIf IntrstAppli = False Then
                            Reduc_Loan_Instlmnt = FormatNumber(Fetch_Ename_Rdr(1), 2)
                            LblLoan.Visible = True
                            TxtLoan.Visible = False

                            LblLoan.Text = FormatNumber(Reduc_Loan_Instlmnt, 2)
                            LoanAmt = LblLoan.Text
                        Else
                            LblLoan.Visible = True
                            TxtLoan.Visible = False
                            LblLoan.Text = FormatNumber(0, 2)
                            LoanAmt = LblLoan.Text
                        End If
                    ElseIf Final_Slry = True Then
                        If LnType = "Flat" And IntrstAppli = True Then
                            LblLoan.Visible = True
                            TxtLoan.Visible = False
                            left_instlmnt = Reduc_Loan_Amt - sum_instlmnt
                            LblLoan.Text = FormatNumber(left_instlmnt, 2)
                            If left_instlmnt > 0 Then
                                Me.Size = New System.Drawing.Point(680, 667)

                                PnlEmpDtl.Size = New System.Drawing.Point(648, 106)
                                PnlSlryDtl.Size = New System.Drawing.Point(648, 433)
                                PnlRebt.Visible = True
                                PnlRebt.Location = New System.Drawing.Point(350, 100)

                                LblLnAmt.Text = Reduc_Loan_Amt
                                LblLnType.Text = LnType
                                LblRIntrst.Text = Reduc_Loan_Intrst
                                LblRepayPrd.Text = Reduc_Loan_RepayPrd

                                TxtRbt.Focus()
                            End If
                           
                           
                        ElseIf LnType = "Reducing" And IntrstAppli = True Then
                            LblLoan.Visible = False
                            TxtLoan.Visible = True
                            If Reduc_Loan_RepayPrd - count_instlmnt = Reduc_Loan_RepayPrd Then

                                MnthlyInst = FormatNumber(Reduc_Loan_Amt, 2)
                                TxtLoan.Text = FormatNumber(Reduc_Loan_Amt, 2)
                            ElseIf Reduc_Loan_RepayPrd - count_instlmnt < Reduc_Loan_RepayPrd And Reduc_Loan_RepayPrd - count_instlmnt >= 1 Then
                                Deduct = Reduc_Loan_Amt / Reduc_Loan_RepayPrd
                                Principal1 = FormatNumber(Reduc_Loan_Amt - (count_instlmnt * Deduct), 2)
                                Principal = FormatNumber(Reduc_Loan_Amt - (count_instlmnt * Deduct) + Pending_Instlmnt, 2)
                                Intrstvalue = (Principal * Reduc_Loan_Intrst) / 100
                                Amount = Principal
                                MnthlyInst = FormatNumber(Amount + Intrstvalue)
                                TxtLoan.Text = FormatNumber(MnthlyInst, 2)
                            ElseIf Reduc_Loan_RepayPrd - count_instlmnt <= 0 And LnDeduc <> ActualLnDeduc Then
                                Principal = Pending_Instlmnt
                                Principal1 = Pending_Instlmnt
                                Intrstvalue = (Principal * Reduc_Loan_Intrst) / 100
                                Amount = Principal
                                MnthlyInst = FormatNumber(Amount + Intrstvalue)
                                TxtLoan.Text = FormatNumber(MnthlyInst, 2)
                            End If

                            LoanAmt = TxtLoan.Text
                            LblLoan.Text = FormatNumber(0, 2)
                        ElseIf IntrstAppli = False Then
                            Reduc_Loan_Instlmnt = FormatNumber(Fetch_Ename_Rdr(1), 2)
                            LblLoan.Visible = True
                            TxtLoan.Visible = False
                            LblLoan.Text = FormatNumber(Reduc_Loan_Instlmnt, 2)
                            LoanAmt = LblLoan.Text
                        Else
                            LblLoan.Visible = True
                            TxtLoan.Visible = False
                            LblLoan.Text = FormatNumber(0, 2)
                            LoanAmt = LblLoan.Text
                        End If
                        End If
                    ElseIf Fetch_Ename_Rdr.HasRows = False And BtnSave.Text = "&Save" Then
                        LblLoan.Visible = True
                        TxtLoan.Visible = False
                        LblLoan.Text = FormatNumber(0, 2)
                        LoanAmt = LblLoan.Text

                    End If
                End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub


    Private Sub TxtHDays_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHDays.TextChanged

        If TxtHDays.BackColor = Color.PapayaWhip Then
            TxtHDays.BackColor = Color.White
        End If
        If BtnSave.Text = "&Update" Then
            RbWHoli.Checked = False
            RbWotHoli.Checked = False
            'If LblDays.Text <> "" And TxtHDays.Text <> "" Then
            '    TMdays = LblDays.Text
            '    LblWrkDays.Text = TMdays - TxtHDays.Text
            'End If
           

        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Dim cnfrmclos As String
        cnfrmclos = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmclos = vbYes Then
            Me.Close()
        End If

    End Sub

    Private Sub Fnd_Recrd()
        Dim Mth As Integer
        If Final_Slry = False Then
            Mth = DtPkrSlrySlipDt.Value.Date.Month
        ElseIf Final_Slry = True Then
            Mth = DtPkrSlrySlipDt.Value.Date.Month
            Mth = Mth + 1
        End If

        Try
            'Fetch_Ename_Cmd = New SqlCommand("Select count(SlryId) from FinactSlrySlip where SlryEmpid='" & (EmId) & "'and SlryMnth='" & (LblMnth.Text) & "'and Slrydelstatus=1 ", FinActConn)
            Fetch_Ename_Cmd = New SqlCommand("Select count(SlryId) from FinactSlrySlip where SlryEmpid='" & (EmId) & "'and month(SlryDt)='" & (Mth) & "'and Slrydelstatus=1 ", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_Rdr.Read()
            If Fetch_Ename_Rdr.IsDBNull(0) = False Then
                No_of_Recrd = Fetch_Ename_Rdr(0)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try

    End Sub
    Private Sub LstAdd()
        Lstvw = ListVew.Items.Add(CmbxEName.Text)
        Lstvw.SubItems.Add(LblErnAmt.Text)
        Lstvw.SubItems.Add(LblOvrtmErn.Text)
        Lstvw.SubItems.Add(LblTot.Text)
        Lstvw.SubItems.Add(LblDeduc.Text)
        Lstvw.SubItems.Add(LblNtSlry.Text)
        Lstvw.SubItems.Add(EmId)
        Lstvw.SubItems.Add(LblMnth.Text)
        Lstvw.SubItems.Add(TxtHDays.Text)
        Lstvw.SubItems.Add(TxtLvWotPay.Text)
        Lstvw.SubItems.Add(LblWrkDays.Text)
        Lstvw.SubItems.Add(TxtOvrTime.Text)
        Lstvw.SubItems.Add(LblDesig.Text)
        Lstvw.SubItems.Add(LblDept.Text)
        Lstvw.SubItems.Add(LblScale.Text)
        If RbWHoli.Checked = True Then
            Lstvw.SubItems.Add(1)
        ElseIf RbWotHoli.Checked = True Then
            Lstvw.SubItems.Add(0)
        End If
        Lstvw.SubItems.Add(DtPkrSlrySlipDt.Value.Date)
    End Sub


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        If BtnSave.Text = "&Save" Then
            chkblank()
            If IndxMstr <> 0 Then
                IndxMstr = 0
                Exit Sub
            Else
                If Final_Slry = True Then
                    Dim cnfrmmsg As String
                    MsgBox(String.Format("After generating this Salary Slip, the status of " & (CmbxEName.Text) & "{0} will be changed as Non-Working{0}", Environment.NewLine), MsgBoxStyle.Exclamation, "Warning")
                    cnfrmmsg = MsgBox("Do you want to Save this record?", MsgBoxStyle.YesNo, "Confirmation")
                    If cnfrmmsg = vbNo Then
                        BtnDelete.Focus()
                        Exit Sub
                    End If

                End If

                Try
                    Slry_Slip_Cmd = New SqlCommand("Finact_SlrySlip_Insert", FinActConn)
                    Slry_Slip_Cmd.CommandType = CommandType.StoredProcedure
                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryEmpid", EmId)
                    Slry_Slip_Cmd.Parameters.AddWithValue("@Slryadusrid", Current_UsrId)
                    Slry_Slip_Cmd.Parameters.AddWithValue("@Slryaddt", Now)

                    Slry_Slip_Cmd.Parameters.AddWithValue("@Slrydelstatus", 1)
                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryDt", DtPkrSlrySlipDt.Value.Date)
                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryMnth", Trim(LblMnth.Text))

                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryHDays", TxtHDays.Text)
                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryLWTPDays", TxtLvWotPay.Text)

                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryWrkDays", LblWrkDays.Text)
                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryOvrTm", TxtOvrTime.Text)
                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryAdvDeduc", CDbl(LblAdvnc.Text))
                    If LblLoan.Visible = True Then
                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryLnDeduc", CDbl(LblLoan.Text))
                    ElseIf TxtLoan.Visible = True Then

                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryLnDeduc", CDbl(TxtLoan.Text))
                    End If
                    Slry_Slip_Cmd.Parameters.AddWithValue("@ActualLnInstlmnt", CDbl(MnthlyInst))
                    Slry_Slip_Cmd.Parameters.AddWithValue("@LnPrincipal", CDbl(Principal1))
                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryOthrDeduc", CDbl(TxtDeduc.Text))

                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryTotDeduc", CDbl(LblDeduc.Text))
                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryTotal", CDbl(LblTotSlry.Text))
                    If RbWHoli.Checked = True Then
                        Slry_Slip_Cmd.Parameters.AddWithValue("@WithHDays", 1)
                    ElseIf RbWotHoli.Checked = True Then
                        Slry_Slip_Cmd.Parameters.AddWithValue("@WithHDays", 0)
                    End If
                    Slry_Slip_Cmd.Parameters.AddWithValue("@ErnAmt", CDbl(LblErnAmt.Text))
                    Slry_Slip_Cmd.Parameters.AddWithValue("@OvrTmErn", CDbl(LblOvrtmErn.Text))
                    Slry_Slip_Cmd.Parameters.AddWithValue("@TotEO", CDbl(LblTot.Text))

                    Slry_Slip_Cmd.ExecuteNonQuery()
                    LstAdd()

                    MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                    ' DtPkrSlrySlipDt.Focus()
                    If TxtLoan.Text <> "" Then
                        If TxtLoan.Text < MnthlyInst Then
                            Pending_Amt = MnthlyInst - TxtLoan.Text
                        ElseIf TxtLoan.Text > MnthlyInst Then
                            Extra_Amt = TxtLoan.Text - MnthlyInst
                        End If
                    End If
                    If LblAdvnc.Text > 0 Then
                        updt_advnc()
                    End If
                    If LblLoan.Visible = True And LblLoan.Text > 0 Then
                        Find_loan_Slry()
                        Find_loan_Advnc()
                    End If

                    If LnDeduc = TotLoan Or count_instlmnt + 1 = Reduc_Loan_RepayPrd Then
                        If LblLoan.Visible = True Then
                            If LnDeduc = TotLoan And LnDeduc <> 0 And TotLoan <> 0 Then
                                updt_loan()
                            End If
                        End If
                    End If

                    Prevs_Loan_Instlmnt()
                    If TxtLoan.Visible = True Then
                        If LnDeduc <> 0 And ActualLnDeduc <> 0 And count_instlmnt + 1 >= Reduc_Loan_RepayPrd Then
                            If TxtLoan.Text = MnthlyInst Then
                                updt_loan()
                            End If
                        End If
                    End If
                  

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Slry_Slip_Cmd = Nothing
                End Try
                If Final_Slry = True Then

                    Try
                        Slry_Slip_Cmd = New SqlCommand("update finactempmstr set empcateg='Non-Working' where empid='" & (EmId) & "'", FinActConn)
                        Slry_Slip_Cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Slry_Slip_Rdr.Close()
                        Slry_Slip_Cmd = Nothing

                    End Try
                End If


                ClrValues()
                PnlSlry.Visible = False
                DtPkrSlrySlipDt.Focus()
                DtPkrSlrySlipDt.Select()
                ListVew.Visible = False
            End If

        ElseIf BtnSave.Text = "&Update" Then
            If CmbxEName.Text = "" Then
                MsgBox("First double click any record from the list to Update", MsgBoxStyle.Information, "Edit Record")
                Exit Sub
            Else
                chkblank()
                If IndxMstr <> 0 Then
                    IndxMstr = 0
                    Exit Sub
                Else
                    Try

                        Slry_Slip_Cmd = New SqlCommand("Finact_SlrySlip_Update", FinActConn)
                        Slry_Slip_Cmd.CommandType = CommandType.StoredProcedure
                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryEmpid", FetchId)
                        Slry_Slip_Cmd.Parameters.AddWithValue("@Slryedtusrid", Current_UsrId)
                        Slry_Slip_Cmd.Parameters.AddWithValue("@Slryedtdt", Now)


                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryMnth", Trim(LblMnth.Text))

                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryHDays", TxtHDays.Text)

                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryLWTPDays", TxtLvWotPay.Text)
                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryWrkDays", LblWrkDays.Text)
                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryOvrTm", TxtOvrTime.Text)
                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryAdvDeduc", CDbl(LblAdvnc.Text))
                        If LblLoan.Visible = True Then
                            Slry_Slip_Cmd.Parameters.AddWithValue("@SlryLnDeduc", CDbl(LblLoan.Text))
                        ElseIf TxtLoan.Visible = True Then
                            Slry_Slip_Cmd.Parameters.AddWithValue("@SlryLnDeduc", CDbl(TxtLoan.Text))
                        End If
                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryOthrDeduc", CDbl(TxtDeduc.Text))
                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryTotDeduc", CDbl(LblDeduc.Text))
                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryTotal", CDbl(LblTotSlry.Text))
                        If RbWHoli.Checked = True Then
                            Slry_Slip_Cmd.Parameters.AddWithValue("@WithHDays", 1)
                        ElseIf RbWotHoli.Checked = True Then
                            Slry_Slip_Cmd.Parameters.AddWithValue("@WithHDays", 0)
                        End If
                        Slry_Slip_Cmd.Parameters.AddWithValue("@ErnAmt", CDbl(LblErnAmt.Text))
                        Slry_Slip_Cmd.Parameters.AddWithValue("@OvrTmErn", CDbl(LblOvrtmErn.Text))
                        Slry_Slip_Cmd.Parameters.AddWithValue("@TotEO", CDbl(LblTot.Text))

                        Slry_Slip_Cmd.ExecuteNonQuery()
                        MsgBox("Record has been Updated Successfully", MsgBoxStyle.Information, "Update Record")
                        ClrValues()
                        BtnSave.Text = "Save"
                        BtnFind.Text = "Find"
                        DtPkrSlrySlipDt.Enabled = True
                        CmbxEName.Enabled = True
                        'PnlSlry.Visible = False
                        DtPkrSlrySlipDt.Focus()
                        Fnd_Cncl()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Slry_Slip_Cmd = Nothing
                    End Try

                End If
            End If
        End If
    End Sub

    Private Sub updt_advnc()
        Try
            Slry_Slip_Cmd = New SqlCommand("update FinactAdvance set AdvStatus='Adjusted'where AdvEmpid='" & (EmId) & "'and Advdelstatus=1", FinActConn)
            Slry_Slip_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Slry_Slip_Cmd = Nothing
        End Try


    End Sub

    Private Sub Find_loan_Slry()
        LnDeduc = 0
        ActualLnDeduc = 0
        Try
            Loan_Slry_Cmd = New SqlCommand("select sum(SlryLnDeduc),sum(ActualLnInstlmnt) from FinactSlrySlip where SlryEmpid='" & (EmId) & "'and Slrydelstatus=1", FinActConn)
            Loan_Slry_Rdr = Loan_Slry_Cmd.ExecuteReader
            Loan_Slry_Rdr.Read()
            If Loan_Slry_Rdr.IsDBNull(0) = False Then
                LnDeduc = Loan_Slry_Rdr(0)
                ActualLnDeduc = Loan_Slry_Rdr(1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Loan_Slry_Rdr.Close()
            Loan_Slry_Cmd = Nothing
        End Try
    End Sub

    Private Sub Find_loan_Advnc()
        TotLoan = 0
        Try
            Loan_Advnc_Cmd = New SqlCommand("select (MnthlyInst*RepayPrd)from FinactLoan where LnEmpid='" & (EmId) & "'and LnStatus<>'Adjusted' and Lndelstatus=1", FinActConn)
            Loan_Advnc_Rdr = Loan_Advnc_Cmd.ExecuteReader
            Loan_Advnc_Rdr.Read()
            If Loan_Advnc_Rdr.IsDBNull(0) = False Then
                TotLoan = Loan_Advnc_Rdr(0)
            ElseIf Loan_Advnc_Rdr.IsDBNull(0) = True Then
                TotLoan = FormatNumber(0, 2)

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Loan_Advnc_Rdr.Close()
            Loan_Advnc_Cmd = Nothing
        End Try
    End Sub

    Private Sub updt_loan()
        Try
            Slry_Slip_Cmd = New SqlCommand("update FinactLoan set LnStatus='Adjusted' where LnEmpid='" & (EmId) & "'and Lndelstatus=1", FinActConn)
            Slry_Slip_Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Slry_Slip_Cmd = Nothing
        End Try


    End Sub


    Private Sub RbWHoli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbWHoli.CheckedChanged


        If TxtHDays.Text <> "" Then
            HDays = TxtHDays.Text
        End If
        If TxtLvWotPay.Text <> "" Then
            LWTPDays = TxtLvWotPay.Text
        End If
        If RbWHoli.Checked = True Then
            PnlSlry.Visible = True

            If Final_Slry = False Then
                TotDays = LblDays.Text
            ElseIf Final_Slry = True Then
                'TotDays = DtPkrSlrySlipDt.Value.Day
                'ElseIf Final_Slry = True And BtnSave.Text = "&Update" Then
                TotDays = LblDays.Text
            End If
            If LblScale.Text <> "" Then
                Totldays = LblDays.Text
                If Final_Slry = False Then
                    PerDaySalry = CDbl(LblScale.Text / Totldays)
                    HrSalry = FormatNumber(PerDaySalry / 24, 2)
                ElseIf Final_Slry = True Then
                    PerDaySalry = CDbl(LblScale.Text / 30)
                    HrSalry = FormatNumber(PerDaySalry / 24, 2)
                End If
               
                'TxtHDays.Focus()
            End If
            If TxtHDays.Text <> "" Then
                If TxtDeduc.Text <> "" Then
                    Deduc = TxtDeduc.Text

                End If
                
                WrkingDays = TotDays - HDays - LWTPDays
                Slry = WrkingDays * PerDaySalry

                'MsgBox(LblAdvnc.Text)
                'MsgBox(TxtLoan.Text)
                ''If TxtDeduc.Text <> "" Then
                ''    'Deduc = TxtDeduc.Text + LblAdvnc.Text + TxtLoan.Text

                ''End If
                OvrTmSlry = CDbl(TxtOvrTime.Value * HrSalry)
                Tot = Slry + OvrTmSlry

                OvrTmSlry = CDbl(TxtOvrTime.Value * HrSalry)
                If BtnSave.Text = "&Save" Then
                    Fetch_Advance()
                    'Fetch_Loan()
                End If

                AdvAmt = CDbl(LblAdvnc.Text)
                If LblLoan.Visible = True Then
                    LoanAmt = CDbl(LblLoan.Text)
                ElseIf TxtLoan.Visible = True Then
                    LoanAmt = CDbl(TxtLoan.Text)
                End If
                If TxtDeduc.Text = "" Then
                    TxtDeduc.Text = FormatNumber(0, 2)
                End If
                OthrDeduc = CDbl(TxtDeduc.Text)


                TotlDeduc = FormatNumber(AdvAmt + LoanAmt + OthrDeduc, 2)

                LblDeduc.Text = FormatNumber(TotlDeduc, 2)
                'MsgBox(LblDeduc.Text)
                TotSalry = CDbl(Slry + OvrTmSlry - TotlDeduc)
                LblTotSlry.Visible = True
                LblErnAmt.Text = FormatNumber(Slry, 2)
                LblTotSlry.Text = FormatNumber(TotSalry, 2)
                LblTot.Text = FormatNumber(Tot, 2)
                LblNtSlry.Text = LblTotSlry.Text

                BtnSave.Focus()
            ElseIf TxtHDays.Text = "" Then
                TxtHDays.BackColor = Color.PapayaWhip
                RbWHoli.Checked = False
                TxtHDays.Focus()
                MsgBox("Invalid value", MsgBoxStyle.Information, "Holidays")

            End If
        End If

    End Sub


    Private Sub RbWotHoli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbWotHoli.CheckedChanged

        If TxtHDays.Text <> "" Then
            HDays = TxtHDays.Text
        End If
        If TxtLvWotPay.Text <> "" Then
            LWTPDays = TxtLvWotPay.Text
        End If
        If RbWotHoli.Checked = True Then
            PnlSlry.Visible = True
            If Final_Slry = False Then
                TotDays = LblDays.Text
            ElseIf Final_Slry = True Then
                ' TotDays = DtPkrSlrySlipDt.Value.Day
                'ElseIf Final_Slry = True And BtnSave.Text = "&Update" Then
                TotDays = LblDays.Text
            End If

            If LblScale.Text <> "" Then
                Totldays = LblDays.Text
                If Final_Slry = False Then
                    PerDaySalry = CDbl(LblScale.Text / Totldays)
                    HrSalry = FormatNumber(PerDaySalry / 24, 2)
                ElseIf Final_Slry = True Then
                    PerDaySalry = CDbl(LblScale.Text / 30)
                    HrSalry = FormatNumber(PerDaySalry / 24, 2)
                End If

                TxtHDays.Focus()
            End If
            If TxtLvWotPay.Text <> "" Then
                LWTPDays = TxtLvWotPay.Text
            End If
            WrkingDays = TotDays - LWTPDays
            Slry = WrkingDays * PerDaySalry
            If TxtDeduc.Text <> "" Then
                Deduc = TxtDeduc.Text

            End If
            OvrTmSlry = CDbl(TxtOvrTime.Value * HrSalry)
            Tot = Slry + OvrTmSlry
            TotSalry = CDbl(Slry + OvrTmSlry - Deduc)
            OvrTmSlry = CDbl(TxtOvrTime.Value * HrSalry)

            If BtnSave.Text = "&Save" Then
                Fetch_Advance()
                'Fetch_Loan()
            End If

            AdvAmt = CDbl(LblAdvnc.Text)
            If LblLoan.Visible = True Then
                LoanAmt = CDbl(LblLoan.Text)
            ElseIf TxtLoan.Visible = True Then
                LoanAmt = CDbl(TxtLoan.Text)
            End If
            OthrDeduc = TxtDeduc.Text

            TotlDeduc = FormatNumber(AdvAmt + LoanAmt + OthrDeduc, 2)
            LblDeduc.Text = FormatNumber(TotlDeduc, 2)
            LblTotSlry.Visible = True
            LblErnAmt.Text = FormatNumber(Slry, 2)
            LblTot.Text = FormatNumber(Tot, 2)
            LblErnAmt.Text = FormatNumber(Slry, 2)
            LblTotSlry.Text = FormatNumber(TotSalry, 2)
            LblNtSlry.Text = LblTotSlry.Text



            BtnSave.Focus()
        End If
    End Sub

    Private Sub chkblank()
        If LblDesig.Text = "" Or LblDept.Text = "" Or LblScale.Text = "" Then
            MsgBox("First select the name of an Employee whose Salay is to be generated", MsgBoxStyle.Information, "Employee Name")
            'CmbxEName.Focus()
            'CmbxEName.SelectAll()
            DtPkrSlrySlipDt.Focus()
            IndxMstr += 1
        ElseIf TxtHDays.Text = "" Then
            TxtHDays.BackColor = Color.PapayaWhip
            MsgBox("Blank field not allowed  ", MsgBoxStyle.Information, "Holidays")
            TxtHDays.Focus()
            IndxMstr += 1
        ElseIf TxtLvWotPay.Text = "" Then
            TxtLvWotPay.BackColor = Color.PapayaWhip
            MsgBox("Blank field not allowed  ", MsgBoxStyle.Information, "Leave")
            TxtLvWotPay.Focus()
            IndxMstr += 1
        ElseIf LblLoan.Text = "" And LblAdvnc.Text = "" Then
            Fetch_Loan()
            Fetch_Advance()
            TxtDeduc.Focus()
            IndxMstr += 1
        ElseIf TxtDeduc.Text = "" Then
            TxtDeduc.BackColor = Color.PapayaWhip
            MsgBox("Blank field not allowed  ", MsgBoxStyle.Information, "Other Deduction")
            TxtDeduc.Focus()
            IndxMstr += 1
        ElseIf RbWHoli.Checked = False And RbWotHoli.Checked = False Then
            MsgBox("Select:- With Holidays  or  Without Holidays", MsgBoxStyle.Information, "Salary")
            IndxMstr += 1


        End If
    End Sub


    Private Sub ClrValues()

        If CmbxEName.SelectedIndex >= 1 Then
            'Or CmbxEName.SelectedIndex = -1 Then
            CmbxEName.SelectedIndex = 0
        End If
        'If CmbxEName.SelectedIndex >= 1 Or CmbxEName.SelectedIndex = 0 Then
        '    CmbxEName.SelectedIndex = -1
        'End If
        LblDesig.Text = ""
        LblDept.Text = ""
        LblScale.Text = ""
        LblMnth.Text = ""
        LblDays.Text = ""
        TxtHDays.Text = ""
        LblWrkDays.Text = ""
        TxtLvWotPay.Clear()
        TxtOvrTime.Value = 0
        LblErnAmt.Text = ""
        TxtDeduc.Clear()
        LblTotSlry.Text = ""
        RbWHoli.Checked = False
        RbWotHoli.Checked = False
        LblOvrtmErn.Text = ""
        LblTot.Text = ""
        LblDeduc.Text = ""
        LblNtSlry.Text = ""
        LblAdvnc.Text = ""
        LblLoan.Text = ""
        TxtLoan.Clear()
        TxtLoan.Visible = False
        LblLoan.Visible = True
        TxtRbt.Clear()
        PnlRebt.Visible = False

    End Sub

    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHDays.KeyPress, TxtLvWotPay.KeyPress
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar <> "." Then
            If (tb.SelectedText <> "." Or IsNumeric(tb.Text & e.KeyChar)) Then
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

    Private Sub numericTextboxKeyPress1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDeduc.KeyPress
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


    Private Sub Fetch_EmpName()
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select empname from FinactEmpmstr where empid='" & (LstEmpid) & "'", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(LstEmpid) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.HasRows = True Then
                    LstEname = Fetch_Ename_Rdr(0)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try
    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        Dim SlryMnthval, SlryYear As Integer
        Dim dt1 As Date
        Dim Listcount As Integer
        If BtnFind.Text = "&Find" Then
            If Final_Slry = False Then
                dt = DtPkrSlrySlipDt.Value.Date.AddMonths(-1)
            ElseIf Final_Slry = True Then
                dt = DtPkrSlrySlipDt.Value.Date
            End If

            dt1 = DtPkrSlrySlipDt.Value.Date
            SlryMnth = MonthName(dt.Month)
            SlryMnthval = dt.Month
            SlryYear = dt1.Year
            LblSlryMnth.Text = SlryMnth

            ClrValues()
            ListVew.Visible = True
            ListVew.Items.Clear()

            PnlSlry.Visible = False
            LblAny.Visible = False
            LbLoan.Visible = False
            LblLoan.Visible = False
            LblRs2.Visible = False
            LblDed.Visible = False
            TxtDeduc.Visible = False
            LblRs3.Visible = False
            Me.Size = New System.Drawing.Point(629, 689)
            PnlSlryDtl.Size = New System.Drawing.Point(597, 304)
            RbWHoli.Location = New System.Drawing.Point(14, 243)
            RbWotHoli.Location = New System.Drawing.Point(122, 243)
            LblTotl.Location = New System.Drawing.Point(14, 275)
            LblTotSlry.Location = New System.Drawing.Point(159, 275)
            ListVew.Location = New System.Drawing.Point(12, 504)
            LblSlryOfMnth.Location = New System.Drawing.Point(154, 472)
            LblSlryMnth.Location = New System.Drawing.Point(284, 472)
            ListVew.Size = New System.Drawing.Point(554, 115)

            EnblFalse()
            BtnDelete.Text = "&Delete"
            BtnFind.Text = "&Cancel"
            BtnSave.Text = "&Update"

            Me.Size = New System.Drawing.Point(629, 689)
            LblSlryOfMnth.Visible = True
            LblSlryMnth.Visible = True

            ListVew.Visible = True
            ListVew.Location = New System.Drawing.Point(12, 504)

            Try
                Slry_Slip_Cmd = New SqlCommand("Select FinactEmpmstr.empname,FinactSlrySlip.ErnAmt,FinactSlrySlip.OvrTmErn,FinactSlrySlip.TotEO,FinactSlrySlip.SlryTotDeduc,FinactSlrySlip.SlryTotal,FinactSlrySlip.SlryEmpid,FinactSlrySlip.SlryMnth,FinactSlrySlip.SlryHDays,FinactSlrySlip.SlryLWTPDays,FinactSlrySlip.SlryWrkDays,FinactSlrySlip.SlryOvrTm,FinactDept.deptname,finactDesi.desiname,FinactEmpmstr.empgrade,FinactSlrySlip.WithHDays,FinactSlrySlip.SlryDt,FinactSlryslip.SlryAdvDeduc,FinactSlrySlip.SlryLnDeduc,FinactSlrySlip.SlryOthrDeduc,FinactSlrySlip.ActualLnInstlmnt from FinactEmpmstr inner join FinactSlrySlip on FinactEmpmstr.empid=FinactSlrySlip.SlryEmpid inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid inner join FinactDesi on FinactEmpmstr.empdesiid=FinactDesi.desiid where empdelstatus=1 and slrydelstatus=1 and SlryMnth='" & (SlryMnth) & "'and year(SlryDt)='" & (SlryYear) & "'", FinActConn)
                Slry_Slip_Rdr = Slry_Slip_Cmd.ExecuteReader

                While Slry_Slip_Rdr.Read()
                    If Slry_Slip_Rdr.HasRows = True Then
                        If CmbxEName.SelectedIndex >= 1 Or CmbxEName.SelectedIndex = 0 Then
                            CmbxEName.SelectedIndex = -1
                        End If

                        Lstvw = ListVew.Items.Add(Slry_Slip_Rdr(0))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(1))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(2))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(3))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(4))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(5))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(6))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(7))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(8))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(9))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(10))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(11))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(12))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(13))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(14))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(15))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(16))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(17))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(18))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(19))
                        Lstvw.SubItems.Add(Slry_Slip_Rdr(20))

                    End If
                End While
                ListVew.Focus()
                Listcount = ListVew.Items.Count
                If Listcount <> 0 Then
                    ListVew.Items(0).Selected = True
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Slry_Slip_Rdr.HasRows = False Then
                    MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")
                    Fnd_Cncl()
                    DtPkrSlrySlipDt.Focus()
                End If

                Slry_Slip_Rdr.Close()
                Slry_Slip_Cmd = Nothing
            End Try
        ElseIf BtnFind.Text = "&Cancel" Then
            Fnd_Cncl()
            DtPkrSlrySlipDt.Focus()

        End If
    End Sub

    Private Sub Fnd_Cncl()
        DtPkrSlrySlipDt.Enabled = True
        CmbxEName.Enabled = True
        BtnDelete.Text = "&Cancel"
        BtnFind.Text = "&Find"
        BtnSave.Text = "&Save"
        ClrValues()
        EnblTrue()
        ListVew.Visible = False
        PnlSlry.Visible = False

        Me.Size = New System.Drawing.Point(629, 667)
        PnlSlryDtl.Size = New System.Drawing.Point(597, 433)
        LblAny.Visible = True
        LbLoan.Visible = True
        LblLoan.Visible = True
        LblRs2.Visible = True
        'LblAny2.Visible = True
        LblDed.Visible = True
        TxtDeduc.Visible = True
        LblRs3.Visible = True

        LblAny.Location = New System.Drawing.Point(12, 335)
        LbLoan.Location = New System.Drawing.Point(13, 254)
        LblLoan.Location = New System.Drawing.Point(159, 263)
        LblRs2.Location = New System.Drawing.Point(268, 265)
        'LblAny2.Location = New System.Drawing.Point(12, 288)
        LblDed.Location = New System.Drawing.Point(13, 315)
        TxtDeduc.Location = New System.Drawing.Point(159, 315)
        LblRs3.Location = New System.Drawing.Point(270, 315)
        RbWHoli.Location = New System.Drawing.Point(14, 367)
        RbWotHoli.Location = New System.Drawing.Point(122, 367)
        LblTotl.Location = New System.Drawing.Point(15, 399)
        LblTotSlry.Location = New System.Drawing.Point(159, 399)

        LblSlryOfMnth.Visible = False
        LblSlryMnth.Visible = False
        
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim response As String
        If BtnDelete.Text = "&Delete" And ListVew.Visible = True Then
            Dim Lst_cnt, Lst_sel_cnt, Lst_cntr, Id, indx As Integer
            Lst_cnt = ListVew.Items.Count
            Lst_sel_cnt = ListVew.SelectedItems.Count
            Lst_cntr = 0
            If Lst_sel_cnt = 0 Then
                MsgBox("No record Selected in the list to delete", MsgBoxStyle.Information, "Delete")
                Exit Sub
            ElseIf Lst_sel_cnt <> 0 Then
                response = MsgBox("Are you sure to Delete Record?", MsgBoxStyle.YesNo, "Delete")
                If response = vbYes Then

                    While Lst_cntr < Lst_sel_cnt
                        Id = ListVew.Items(Lst_cntr).SubItems(6).Text
                        Try

                            Slry_Slip_Cmd = New SqlCommand("Finact_SlrySlip_Delete", FinActConn)
                            Slry_Slip_Cmd.CommandType = CommandType.StoredProcedure
                            Slry_Slip_Cmd.Parameters.AddWithValue("@SlryEmpid", Id)
                            Slry_Slip_Cmd.Parameters.AddWithValue("@Slrydelusrid", Current_UsrId)
                            Slry_Slip_Cmd.Parameters.AddWithValue("@Slrydeldt", Now)
                            Slry_Slip_Cmd.Parameters.AddWithValue("@Slrydelstatus", 0)
                            Slry_Slip_Cmd.ExecuteNonQuery()

                            indx = ListVew.SelectedItems(0).Index
                            ListVew.Items(indx).Remove()
                            ClrValues()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Slry_Slip_Cmd = Nothing
                        End Try
                        Lst_cntr = Lst_cntr + 1
                    End While
                    If Lst_cntr <> 0 Then
                        MsgBox("Record has been Deleted Successfully", MsgBoxStyle.Information, "Delete Record")
                    End If
                End If
                End If
            ElseIf BtnDelete.Text = "&Delete" And ListVew.Visible = False Then
                If CmbxEName.Text = "" Then
                    MsgBox("No Record Found to Delete", MsgBoxStyle.Information, "Delete Record")

            ElseIf CmbxEName.Text <> "" Then
                response = MsgBox("Are you sure to Delete Record?", MsgBoxStyle.YesNo, "Delete")
                If response = vbYes Then

                    Try

                        Slry_Slip_Cmd = New SqlCommand("Finact_SlrySlip_Delete", FinActConn)
                        Slry_Slip_Cmd.CommandType = CommandType.StoredProcedure
                        Slry_Slip_Cmd.Parameters.AddWithValue("@SlryEmpid", FetchId)
                        Slry_Slip_Cmd.Parameters.AddWithValue("@Slrydelusrid", Current_UsrId)
                        Slry_Slip_Cmd.Parameters.AddWithValue("@Slrydeldt", Now)
                        Slry_Slip_Cmd.Parameters.AddWithValue("@Slrydelstatus", 0)
                        Slry_Slip_Cmd.ExecuteNonQuery()
                        MsgBox("Current Record has been Deleted Successfully", MsgBoxStyle.Information, "Delete Record")
                        ClrValues()
                        PnlSlry.Visible = False
                        DtPkrSlrySlipDt.Focus()
                        BtnSave.Text = "&Save"
                        BtnFind.Text = "&Find"
                        BtnDelete.Text = "&Cancel"
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Slry_Slip_Cmd = Nothing
                    End Try
                End If
                End If
            ElseIf BtnDelete.Text = "&Cancel" Then
                DtPkrSlrySlipDt.Focus()
                ClrValues()
                EnblTrue()

                ListVew.Visible = False
                PnlSlry.Visible = False

                Me.Size = New System.Drawing.Point(629, 667)
                PnlSlryDtl.Size = New System.Drawing.Point(597, 433)

                'Me.Size = New System.Drawing.Point(629, 528)
                LblSlryOfMnth.Visible = False
                LblSlryMnth.Visible = False

            End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        BtnDelete_Click(sender, e)
    End Sub

    Private Sub DeleteAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAllToolStripMenuItem.Click
        Dim Lst_cnt, Lst_cntr, Id, indx As Integer
        Lst_cnt = ListVew.Items.Count
        Lst_cntr = 0
        If Lst_cnt = 0 Then
            MsgBox("No record in the list to delete", MsgBoxStyle.Information, "Delete All")
            Exit Sub
        ElseIf Lst_cnt <> 0 Then

            While Lst_cntr < Lst_cnt
                Id = 0
                Id = ListVew.Items(0).SubItems(6).Text
                Try
                    Slry_Slip_Cmd = New SqlCommand("Finact_SlrySlip_Delete", FinActConn)
                    Slry_Slip_Cmd.CommandType = CommandType.StoredProcedure
                    Slry_Slip_Cmd.Parameters.AddWithValue("@SlryEmpid", Id)
                    Slry_Slip_Cmd.Parameters.AddWithValue("@Slrydelusrid", Current_UsrId)
                    Slry_Slip_Cmd.Parameters.AddWithValue("@Slrydeldt", Now)
                    Slry_Slip_Cmd.Parameters.AddWithValue("@Slrydelstatus", 0)
                    Slry_Slip_Cmd.ExecuteNonQuery()

                    indx = ListVew.Items(0).Index
                    ListVew.Items(indx).Remove()
                    ClrValues()

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Slry_Slip_Cmd = Nothing
                End Try
                Lst_cntr = Lst_cntr + 1
            End While
            If Lst_cntr <> 0 Then
                MsgBox("All Records have been Deleted Successfully", MsgBoxStyle.Information, "Delete Record")
            End If
        End If

    End Sub

    Private Sub TxtHDays_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHDays.Leave
        Try
            Dim deduc_days, Hldays, Tdays As Integer
            Count_Recrds_Emp()
            If Count_Emp_Recrds = 0 And TxtHDays.Text <> "" Then
                deduc_days = EmpJnDt.Day - 1
                Hldays = TxtHDays.Text
                If Final_Slry = False Then
                    Tdays = LblDays.Text
                ElseIf Final_Slry = True Then
                    Tdays = DtPkrSlrySlipDt.Value.Date.Day

                End If


                If Hldays > Tdays - deduc_days Then
                    MsgBox("Value should be less than or equalto " & (Tdays - deduc_days - 1), MsgBoxStyle.Information, "Leave")
                    TxtHDays.Focus()
                    TxtHDays.SelectAll()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EnblFalse()
        CmbxEName.Enabled = False
        TxtHDays.Enabled = False
        TxtLvWotPay.Enabled = False
        TxtOvrTime.Enabled = False
        TxtDeduc.Enabled = False
        RbWHoli.Enabled = False
        RbWotHoli.Enabled = False

    End Sub
    Private Sub EnblTrue()
        CmbxEName.Enabled = True
        TxtHDays.Enabled = True
        TxtLvWotPay.Enabled = True
        TxtOvrTime.Enabled = True
        TxtDeduc.Enabled = True
        RbWHoli.Enabled = True
        RbWotHoli.Enabled = True

    End Sub

    Private Sub RbWHoli_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbWHoli.GotFocus
        RbWHoli.Checked = True
    End Sub

    Private Sub RbWotHoli_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbWotHoli.GotFocus
        RbWotHoli.Checked = True
    End Sub


    Private Sub Find_Fetch_Loan()

        Try
            Fetch_Ename_Cmd = New SqlCommand("Select MethdIntrst,MnthlyInst from FinactLoan where LnEmpId='" & (FetchId) & "'and LnStatus<>'Adjusted' and Lndelstatus=1", FinActConn)
            Fetch_Ename_Rdr = Fetch_Ename_Cmd.ExecuteReader
            If Trim(FetchId) <> "" Then
                Fetch_Ename_Rdr.Read()
                If Fetch_Ename_Rdr.HasRows = True And BtnSave.Text = "&Update" Then
                    Fetch_LnType = Fetch_Ename_Rdr(0)
                    'If Fetch_LnType = "Flat" Then
                    '    LblLoan.Visible = True
                    '    TxtLoan.Visible = False

                    If Fetch_LnType = "Reducing" Then
                        LblLoan.Visible = False
                        TxtLoan.Visible = True
                    Else
                        LblLoan.Visible = True
                        TxtLoan.Visible = False
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


    Private Sub ListVew_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListVew.DoubleClick
        Dim Indx1 As Integer
        Dim WithHDays As Boolean
        Dim SlryLndeduc, ActualLndeduc As Double
        EnblTrue()
        DtPkrSlrySlipDt.Text = ListVew.Items(Indx1).SubItems(16).Text
        DtPkrSlrySlipDt.Enabled = False
        CmbxEName.Enabled = False

        Indx1 = ListVew.SelectedItems(0).Index
        CmbxEName.Items.Clear()
        CmbxEName.Items.Add(ListVew.Items(Indx1).SubItems(0).Text)
        If CmbxEName.Items.Count > 0 Then
            CmbxEName.SelectedIndex = 0
        End If
        MsgBox(ListVew.Items(Indx1).SubItems(1).Text)
        LblErnAmt.Text = ListVew.Items(Indx1).SubItems(1).Text
        LblOvrtmErn.Text = FormatNumber(ListVew.Items(Indx1).SubItems(2).Text, 2)
        LblTot.Text = ListVew.Items(Indx1).SubItems(3).Text
        LblDeduc.Text = FormatNumber(ListVew.Items(Indx1).SubItems(4).Text, 2)
        
        TxtDeduc.Text = FormatNumber(ListVew.Items(Indx1).SubItems(19).Text, 2)
        LblNtSlry.Text = ListVew.Items(Indx1).SubItems(5).Text
        LblTotSlry.Text = ListVew.Items(Indx1).SubItems(5).Text
        FetchId = ListVew.Items(Indx1).SubItems(6).Text
        LblMnth.Text = ListVew.Items(Indx1).SubItems(7).Text
        If Final_Slry = False Then
            dt = Today.AddMonths(-1)
        ElseIf Final_Slry = True Then
            dt = DtPkrSlrySlipDt.Value.Date

        End If

        LblDays.Text = Date.DaysInMonth(Today.Year, dt.Month)
        TxtHDays.Text = ListVew.Items(Indx1).SubItems(8).Text
        TxtLvWotPay.Text = ListVew.Items(Indx1).SubItems(9).Text
        LblWrkDays.Text = ListVew.Items(Indx1).SubItems(10).Text
        TxtOvrTime.Value = ListVew.Items(Indx1).SubItems(11).Text
        LblDesig.Text = ListVew.Items(Indx1).SubItems(12).Text
        LblDept.Text = ListVew.Items(Indx1).SubItems(13).Text
        LblScale.Text = FormatNumber(ListVew.Items(Indx1).SubItems(14).Text, 2)
        WithHDays = ListVew.Items(Indx1).SubItems(15).Text
        LblAdvnc.Text = FormatNumber(ListVew.Items(Indx1).SubItems(17).Text, 2)
        SlryLndeduc = FormatNumber(ListVew.Items(Indx1).SubItems(18).Text, 2)
        ActualLndeduc = FormatNumber(ListVew.Items(Indx1).SubItems(20).Text, 2)
        
        Find_Fetch_Loan()

        If Fetch_LnType = "Reducing" And SlryLndeduc = 0 And ActualLndeduc = 0 Then
            TxtLoan.Visible = False
            LblLoan.Visible = True
            LblLoan.Location = New System.Drawing.Point(159, 263)
            LblLoan.Text = FormatNumber(ListVew.Items(Indx1).SubItems(18).Text, 2)
        ElseIf Fetch_LnType = "Reducing" And SlryLndeduc <> 0 And ActualLndeduc <> 0 Then
            LblLoan.Visible = False
            TxtLoan.Visible = True
            TxtLoan.Location = New System.Drawing.Point(159, 263)
            TxtLoan.Text = FormatNumber(ListVew.Items(Indx1).SubItems(18).Text, 2)
        Else
            TxtLoan.Visible = False
            LblLoan.Visible = True
            LblLoan.Location = New System.Drawing.Point(159, 263)
            LblLoan.Text = FormatNumber(ListVew.Items(Indx1).SubItems(18).Text, 2)
        End If
        If WithHDays = True Then
            RbWHoli.Checked = True
        ElseIf WithHDays = False Then
            RbWotHoli.Checked = True
        End If


        ListVew.Items(Indx1).Remove()
        ListVew.Visible = False
        PnlSlry.Visible = True

        Me.Size = New System.Drawing.Point(629, 667)
        PnlSlryDtl.Size = New System.Drawing.Point(597, 433)

        LblAny.Visible = True
        LbLoan.Visible = True

        LblRs2.Visible = True
        LblDed.Visible = True
        TxtDeduc.Visible = True
        LblRs3.Visible = True

        LblAny.Location = New System.Drawing.Point(12, 335)
        LbLoan.Location = New System.Drawing.Point(13, 254)

        LblRs2.Location = New System.Drawing.Point(268, 265)
        'LblAny2.Location = New System.Drawing.Point(12, 288)
        LblDed.Location = New System.Drawing.Point(13, 315)
        TxtDeduc.Location = New System.Drawing.Point(159, 315)
        LblRs3.Location = New System.Drawing.Point(270, 315)
        RbWHoli.Location = New System.Drawing.Point(14, 367)
        RbWotHoli.Location = New System.Drawing.Point(122, 367)
        LblTotl.Location = New System.Drawing.Point(15, 399)
        LblTotSlry.Location = New System.Drawing.Point(159, 399)


        LblSlryOfMnth.Visible = False
        LblSlryMnth.Visible = False
        'BtnDelete.Enabled = False
        If BtnFind.Text = "&Find" Then
            BtnFind.Text = "&Cancel"
        End If
        If BtnSave.Text = "&Save" Then
            BtnSave.Text = "&Update"
        End If
        TxtHDays.Focus()
    End Sub


    Private Sub TxtDeduc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDeduc.LostFocus
        TotlDeduc = FormatNumber(AdvAmt + LoanAmt + OthrDeduc, 2)
        LblDeduc.Text = FormatNumber(TotlDeduc, 2)
        
        'If TotlDeduc > EmpGrade Then
        '    MsgBox("Total Deductiom Amount can't exceed Basic Salary", MsgBoxStyle.Information, "Deduction")
        '    TxtDeduc.Focus()
        '    PnlSlry.Visible = False
        '    LblTotSlry.Text = ""
        '    RbWHoli.Checked = False
        '    RbWotHoli.Checked = False
        '    Exit Sub
        'End If
    End Sub


    Private Sub TxtLvWotPay_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLvWotPay.TextChanged

        If TxtLvWotPay.BackColor = Color.PapayaWhip Then
            TxtLvWotPay.BackColor = Color.White
        End If
        If BtnSave.Text = "&Update" Then
            RbWHoli.Checked = False
            RbWotHoli.Checked = False
            'If LblDays.Text <> "" And TxtLvWotPay.Text <> "" And TxtHDays.Text <> "" Then
            '    TMdays = LblDays.Text
            '    LblWrkDays.Text = TMdays - TxtLvWotPay.Text - TxtHDays.Text
            'End If
        End If
    End Sub

    Private Sub TxtOvrTime_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOvrTime.ValueChanged
        If TxtOvrTime.BackColor = Color.PapayaWhip Then
            TxtOvrTime.BackColor = Color.White
        End If
        If BtnSave.Text = "&Update" Then
            RbWHoli.Checked = False
            RbWotHoli.Checked = False
            OvrTmSlry = CDbl(TxtOvrTime.Value * HrSalry)
            LblOvrtmErn.Text = FormatNumber(OvrTmSlry, 2)

            Tot = Slry + OvrTmSlry
            LblTot.Text = FormatNumber(Tot, 2)
        End If
    End Sub

    Private Sub TxtLoan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLoan.KeyDown
        Dim SlryTotl, Advance, Loan, DeducTotl, Actualdeduc As Double
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If TxtLoan.Text = "" Then
                TxtLoan.Text = FormatNumber(0, 2)
               
            ElseIf TxtLoan.Text <> "" Then
                SlryTotl = CDbl(LblTot.Text)
                Advance = CDbl(LblAdvnc.Text)
                Loan = CDbl(TxtLoan.Text)
                DeducTotl = Advance + Loan
                Actualdeduc = FormatNumber(SlryTotl - Advance, 2)
                If DeducTotl > SlryTotl Then
                    TxtLoan.BackColor = Color.PapayaWhip
                    MsgBox("Can't deduct more than '" & (Actualdeduc) & "'", MsgBoxStyle.Information, "Loan Deduction")
                    TxtLoan.Focus()
                    TxtLoan.SelectAll()
                    Exit Sub
                Else
                    TxtLoan.Text = FormatNumber(TxtLoan.Text, 2)
                End If

            End If

            TxtDeduc.Focus()
            TxtDeduc.SelectAll()
        End If
    End Sub

    Private Sub TxtLoan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLoan.TextChanged
        If TxtLoan.BackColor = Color.PapayaWhip Then
            TxtLoan.BackColor = Color.White
        End If
    End Sub

    Private Sub TxtDeduc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDeduc.TextChanged
        If TxtDeduc.BackColor = Color.PapayaWhip Then
            TxtDeduc.BackColor = Color.White
        End If
        If BtnSave.Text = "&Update" Then
            RbWHoli.Checked = False
            RbWotHoli.Checked = False

        End If
    End Sub

    Private Sub ListVew_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListVew.KeyDown
        If e.KeyCode = Keys.Enter And ListVew.SelectedItems.Count > 0 Then
            ListVew_DoubleClick(sender, e)

        End If
    End Sub


    

    Private Sub BtnRbtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRbtOk.Click
        Dim rbtval As Double
        If TxtRbt.Text <> "" Then
            rbtval = (left_instlmnt * TxtRbt.Text) / 100
            LblLoan.Text = FormatNumber(left_instlmnt - rbtval, 2)
            LoanAmt = LblLoan.Text
            TxtLoan.Text = FormatNumber(0, 2)
            PnlRebt.Visible = False
            Me.Size = New System.Drawing.Point(629, 667)
            PnlEmpDtl.Size = New System.Drawing.Point(597, 106)
            PnlSlryDtl.Size = New System.Drawing.Point(597, 433)
            TxtDeduc.Focus()
        End If
    End Sub

    Private Sub BtnRbtCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRbtCncl.Click
        TxtRbt.Clear()
        PnlRebt.Visible = False
        TxtDeduc.Focus()
        Me.Size = New System.Drawing.Point(629, 667)
        PnlEmpDtl.Size = New System.Drawing.Point(597, 106)
        PnlSlryDtl.Size = New System.Drawing.Point(597, 433)
    End Sub

    Private Sub TxtRbt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRbt.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            If TxtRbt.Text = "" Then
                MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Fields")

                TxtRbt.BackColor = Color.PapayaWhip
                TxtRbt.Focus()
                Exit Sub
            End If
            BtnRbtOk.Focus()
        End If
    End Sub

    
    Private Sub TxtRbt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRbt.TextChanged
        If TxtRbt.BackColor <> Color.White Then
            TxtRbt.BackColor = Color.White

        End If
    End Sub
End Class

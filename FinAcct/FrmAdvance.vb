Imports System.Data
Imports System.Data.SqlClient

Public Class FrmAdvance
    Dim Emp_Adv_Cmd As SqlCommand
    Dim Emp_Adv_Rdr As SqlDataReader
    Dim Fetch_MinDt_Cmd As SqlCommand
    Dim Fetch_MinDt_rdr As SqlDataReader
    Dim ToTAdvnc As Double
    Dim EmpAdvnc As Double
    Dim BscSlry As Double
    Dim Mindt As Date
    Dim Totdays As Integer
    Dim WrkDays As Integer
    Dim PerDaySalry As Double
    Dim HrSalry As Double
    Dim EmpSalry As Double
    Dim Tot_Loan_Amt As Double
    Dim Strtdt As Date
    Dim EmpId As Integer
    Dim EmplId As Integer
    Dim IntrstAmt As Double
    Dim No_of_Recrd As Integer
    Dim Loan_Recrd As Integer
    Dim First_Mnth_Amt, Reduc_Intrst_Amt As Double
    Dim Count_LnInstlmnt As Integer
    Dim Lstcount As Integer
    Dim OvrTmSalry As Double
    Dim EffDt, AdvDt As Date


    Private Sub Advance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Size = New System.Drawing.Point(432, 296)
        PnlEmpAdv.Size = New System.Drawing.Point(399, 199)

        DtPkrAdvDt.Focus()

        fetch_Cmbx_Ename()

        LblAdcAmt.Visible = False
        TxtAdvAmt.Visible = False
        PnlIntrst.Visible = False
        CmbxEmpNm.SelectedIndex = 0
        fetch_Adv_MinDt()
        DtPkrAdvDt.MinDate = Strtdt
        DtPkrAdvDt.MaxDate = Today
        DtpkrEffDt.MinDate = Today
        LstVewAdv.Visible = False
        PnlFnd.Visible = False
        TxtAbsnt.Text = 0
        TxtAmt.Text = FormatNumber(0, 2)
        TxtOvrTime.Value = 0
        TxtRtInt.Text = 0
        TxtAdvAmt.Text = FormatNumber(0, 2)
    End Sub

    Private Sub fetch_Adv_MinDt()
        Try

            Emp_Adv_Cmd = New SqlCommand("Select costrtdt from Finactcogatemstr", FinActConn)

            Emp_Adv_Rdr = Emp_Adv_Cmd.ExecuteReader
            Emp_Adv_Rdr.Read()
            If Emp_Adv_Rdr.HasRows = True Then
                Strtdt = Emp_Adv_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Adv_Rdr.Close()
            Emp_Adv_Cmd = Nothing
        End Try
    End Sub

    Private Sub fetch_Cmbx_Ename()
        CmbxEmpNm.Items.Clear()
        Dim PrevDate As Date
        PrevDate = Today.AddMonths(-1)

        Try

            Emp_Adv_Cmd = New SqlCommand("Select empname from FinactEmpmstr where empdelstatus=1 and empcateg='Working'and empjnDt<='" & (PrevDate) & "' order by empname ", FinActConn)

            Emp_Adv_Rdr = Emp_Adv_Cmd.ExecuteReader
            While Emp_Adv_Rdr.Read
                If Emp_Adv_Rdr.HasRows = True Then
                    CmbxEmpNm.Items.Add(Emp_Adv_Rdr(0))
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Adv_Rdr.Close()
            Emp_Adv_Cmd = Nothing
        End Try
    End Sub

    Private Sub CmbxEmpNm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEmpNm.GotFocus

        CmbxEmpNm.DroppedDown = True
    End Sub

    Private Sub CmbxEmpNm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEmpNm.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            RbAdvnce.Focus()

            'TxtAmt.Focus()
            'TxtAmt.SelectAll()

        End If

    End Sub

    Private Sub CmbxEmpNm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEmpNm.KeyUp
        If e.KeyCode = 9 Then
            RbAdvnce.Focus()
            'TxtAmt.Focus()
            'TxtAmt.SelectAll()

        End If
    End Sub

    Private Sub RbAdvnce_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAdvnce.GotFocus
        TxtAmt.Focus()
        TxtAmt.SelectAll()
    End Sub


    Private Sub DtPkrAdvDt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtPkrAdvDt.GotFocus
        If BtnSve.Text = "&Save" Then
            DtPkrAdvDt.MinDate = Today

        End If
    End Sub


    Private Sub DtPkrAdvDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtPkrAdvDt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            CmbxEmpNm.Focus()
        End If
    End Sub

    Private Sub DtPkrAdvDt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtPkrAdvDt.KeyUp
        If e.KeyCode = 9 Then
            CmbxEmpNm.Focus()
        End If
    End Sub

    Private Sub Fetch_Shft_Recrd()
        Dim strttime, endtime As Date
        Dim endtime1 As Date
        Try
            Emp_Adv_Cmd = New SqlCommand("Select Empstdtime,Empendtime from FinactEmpTimeMstr where EmpSift='1st' ", FinActConn)
            Emp_Adv_Rdr = Emp_Adv_Cmd.ExecuteReader

            Emp_Adv_Rdr.Read()
            If Emp_Adv_Rdr.HasRows = True Then
                strttime = Format(Emp_Adv_Rdr(0), "HH:mm:ss")
                'MsgBox(strttime)
                ' LblStrtTime.Text = Format(Emp_Adv_Rdr(0), "HH:mm:ss")
                endtime = Emp_Adv_Rdr("Empendtime")
                'MsgBox(endtime)
                endtime = Format(Emp_Adv_Rdr(1), "HH:mm:ss")
                endtime1 = Format(endtime, "HH:mm:ss")
                'MsgBox(endtime1)
                '' LblEndTime.Text = Format(Emp_Adv_Rdr(1), "HH:mm:ss")


            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Adv_Rdr.Close()
            Emp_Adv_Cmd = Nothing
        End Try
    End Sub


    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Dim cnfrmcls As String
        cnfrmcls = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmcls = vbYes Then
            Me.Close()
        End If

    End Sub

    Private Sub RbAdvnce_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAdvnce.CheckedChanged
        If RbAdvnce.Checked = True Then
            Fnd_Recrd_Advnc()
            If No_of_Recrd <> 0 And BtnSve.Text = "&Save" Then
                MsgBox("Advance has already been given to " & (CmbxEmpNm.Text), MsgBoxStyle.Information, "Advance")
                Me.Size = New System.Drawing.Point(432, 296)
                PnlEmpAdv.Size = New System.Drawing.Point(399, 199)
                Clrval()
                DtPkrAdvDt.Focus()

            Else
                PnlIntrst.Visible = False
                LblAbsnt.Visible = True
                TxtAbsnt.Visible = True
                LblOvrTm.Visible = True
                TxtOvrTime.Visible = True
                LblHrs.Visible = True
                LblErnAmt.Visible = True
                LblEAmt.Visible = True
                TxtAdvAmt.Visible = True
                LblAdcAmt.Visible = True
                LblRs.Visible = True
                LblEAmtRs.Visible = True
                TxtAbsnt.Focus()
                TxtAbsnt.SelectAll()

                LblAmt.Visible = False
                TxtAmt.Visible = False
                LblIntAppl.Visible = False
                RbIntYes.Visible = False
                RbIntNo.Visible = False
                LblRtInt.Visible = False
                TxtRtInt.Visible = False
                LblAnly.Visible = False
                LblMCalc.Visible = False
                RbReduc.Visible = False
                RbFlat.Visible = False
                LblMnthInst.Visible = False
                LblInst.Visible = False


                LblRepay.Visible = False
                NumRepay.Visible = False
                LblMnths.Visible = False
                LblInst.Visible = False
                LblEffDt.Visible = False
                DtpkrEffDt.Visible = False

                Me.Size = New System.Drawing.Point(432, 518)
                PnlEmpAdv.Size = New System.Drawing.Point(399, 419)
                LblAbsnt.Location = New System.Drawing.Point(13, 205)
                TxtAbsnt.Location = New System.Drawing.Point(172, 211)
                LblOvrTm.Location = New System.Drawing.Point(13, 272)
                TxtOvrTime.Location = New System.Drawing.Point(172, 272)
                LblHrs.Location = New System.Drawing.Point(217, 272)
                LblErnAmt.Location = New System.Drawing.Point(13, 322)
                LblEAmt.Location = New System.Drawing.Point(172, 322)
                LblEAmtRs.Location = New System.Drawing.Point(297, 322)
                LblAdcAmt.Location = New System.Drawing.Point(13, 375)
                TxtAdvAmt.Location = New System.Drawing.Point(172, 375)
                LblRs.Location = New System.Drawing.Point(297, 375)

            End If
        End If
    End Sub

    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        If PnlFnd.Visible = True Then
            PnlFnd.Visible = False
            PnlEmpAdv.Enabled = True
            DtPkrAdvDt.Focus()
            Exit Sub
        End If
        Clrval()
        PnlEmpAdv.Enabled = True

        Me.Size = New System.Drawing.Point(432, 296)
        PnlEmpAdv.Size = New System.Drawing.Point(399, 199)

        If BtnSve.Text = "&Update" Then
            BtnSve.Text = "&Save"
        End If
        If BtnFnd.Text = "&Delete" Then
            BtnFnd.Text = "&Find"
        End If
        CmbxEmpNm.Enabled = True
        DtPkrAdvDt.Enabled = True
        PnlEmpAdv.Enabled = True
        RbLoan.Enabled = True
        RbAdvnce.Enabled = True
        RbIntYes.Enabled = True
        RbIntNo.Enabled = True

        DtPkrAdvDt.Focus()
        If TxtAdvAmt.BackColor <> Color.White Then
            TxtAdvAmt.BackColor = Color.White

        End If

    End Sub

    Private Sub RbLoan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbLoan.CheckedChanged
        If RbLoan.Checked = True Then
            Fnd_Recrd_Loan()
            If Loan_Recrd <> 0 And BtnSve.Text = "&Save" Then
                MsgBox("Loan has already been given to " & (CmbxEmpNm.Text), MsgBoxStyle.Information, "Advance")
                Me.Size = New System.Drawing.Point(432, 296)
                PnlEmpAdv.Size = New System.Drawing.Point(399, 199)
                Clrval()
                DtPkrAdvDt.Focus()

            Else
                LblAbsnt.Visible = False
                TxtAbsnt.Visible = False
                LblOvrTm.Visible = False
                TxtOvrTime.Visible = False
                LblHrs.Visible = False
                LblErnAmt.Visible = False
                LblEAmt.Visible = False
                TxtAdvAmt.Visible = False
                LblAdcAmt.Visible = False
                LblAmt.Visible = True
                TxtAmt.Visible = True
                LblIntAppl.Visible = True
                RbIntYes.Visible = True
                RbIntNo.Visible = True
                LblEAmtRs.Visible = False
                TxtAmt.Focus()
                TxtAmt.SelectAll()

                Me.Size = New System.Drawing.Point(432, 389)
                PnlEmpAdv.Size = New System.Drawing.Point(399, 288)
                LblAmt.Location = New System.Drawing.Point(12, 200)
                TxtAmt.Location = New System.Drawing.Point(170, 201)
                LblIntAppl.Location = New System.Drawing.Point(12, 248)
                RbIntYes.Location = New System.Drawing.Point(170, 249)
                RbIntNo.Location = New System.Drawing.Point(254, 249)

            End If
        End If
    End Sub

    Private Sub TxtAdvAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAdvAmt.GotFocus
        If TxtAdvAmt.Text = "" Then
            TxtAdvAmt.Text = FormatNumber(0, 2)
        End If
        TxtAdvAmt.SelectAll()

    End Sub

    Private Sub TxtAdvAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAdvAmt.KeyDown
        Dim response As String
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If LblBscSlry.Text <> "" Then
                BscSlry = CDbl(LblBscSlry.Text)
                ToTAdvnc = CDbl(FormatNumber(LblBscSlry.Text / 2, 2))
                If TxtAdvAmt.Text <> "" Then
                    EmpAdvnc = CDbl(TxtAdvAmt.Text)
                End If

                If EmpAdvnc <> 0 And EmpAdvnc > ToTAdvnc And EmpAdvnc <= BscSlry Then
                    response = MsgBox("Do you want to give Advance more than 50% of Basic Salary?", MsgBoxStyle.YesNo, "Alert")
                    If response = vbYes Then
                        BtnSve.Focus()
                        Exit Sub
                    ElseIf response = vbNo Then
                        TxtAdvAmt.Focus()
                        TxtAdvAmt.SelectAll()

                        Exit Sub
                    End If
                ElseIf EmpAdvnc > BscSlry Then
                    MsgBox("Can't exceed Basic Salary", MsgBoxStyle.Information, "Advanced Amount")
                    TxtAdvAmt.SelectAll()
                    TxtAdvAmt.BackColor = Color.PapayaWhip
                    TxtAdvAmt.Focus()
                    Exit Sub
                ElseIf TxtAdvAmt.Text = "" Then
                    TxtAdvAmt.BackColor = Color.PapayaWhip
                    TxtAdvAmt.Focus()
                    TxtAdvAmt.SelectAll()

                    MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Advanced Amount")
                ElseIf TxtAdvAmt.Text = 0 Then
                    MsgBox("Invalid value", MsgBoxStyle.Information, "Advanced Amount")
                    TxtAdvAmt.SelectAll()
                    TxtAdvAmt.BackColor = Color.PapayaWhip
                    TxtAdvAmt.Focus()
                    Exit Sub
                Else
                    BtnSve.Focus()
                End If
            End If

        End If
    End Sub

    Private Sub TxtAdvAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAdvAmt.KeyUp
        If e.KeyCode = Keys.Tab Then
            TxtAdvAmt_KeyDown(sender, e)
         
        End If
    End Sub

    Private Sub TxtAdvAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAdvAmt.Leave
        If TxtAdvAmt.Text <> "" Then
            TxtAdvAmt.Text = FormatNumber(TxtAdvAmt.Text, 2)
        End If
    End Sub


    Private Sub RbIntYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbIntYes.CheckedChanged
        If RbIntYes.Checked = True Then
            Me.Size = New System.Drawing.Point(432, 652)
            PnlEmpAdv.Size = New System.Drawing.Point(399, 554)

            LblRtInt.Visible = True
            TxtRtInt.Visible = True
            LblAnly.Visible = True
            LblMCalc.Visible = True
            PnlIntrst.Visible = True
            RbReduc.Visible = True
            RbFlat.Visible = True
            LblMnthInst.Visible = True
            LblRepay.Visible = True
            NumRepay.Visible = True
            LblMnths.Visible = True
            LblInst.Visible = True
            LblRs.Visible = True
            LblEffDt.Visible = True
            DtpkrEffDt.Visible = True

            LblRtInt.Location = New System.Drawing.Point(12, 297)
            TxtRtInt.Location = New System.Drawing.Point(170, 298)
            LblAnly.Location = New System.Drawing.Point(12, 318)
            LblMCalc.Location = New System.Drawing.Point(12, 357)
            PnlIntrst.Location = New System.Drawing.Point(169, 364)
            LblRepay.Location = New System.Drawing.Point(12, 417)
            NumRepay.Location = New System.Drawing.Point(170, 419)
            LblMnths.Location = New System.Drawing.Point(218, 419)
            LblMnthInst.Location = New System.Drawing.Point(12, 465)
            LblInst.Location = New System.Drawing.Point(170, 465)
            LblRs.Location = New System.Drawing.Point(297, 465)
            LblEffDt.Location = New System.Drawing.Point(12, 515)
            DtpkrEffDt.Location = New System.Drawing.Point(170, 515)

            TxtRtInt.Focus()
            TxtRtInt.SelectAll()

        End If
    End Sub


    Private Sub RbAdvnce_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbAdvnce.KeyDown
        If e.KeyCode = 13 Then
            TxtAbsnt.Focus()
            TxtAbsnt.SelectAll()
        ElseIf e.KeyCode = 9 Then
            TxtAbsnt.Focus()
            TxtAbsnt.SelectAll()

        End If
    End Sub

    Private Sub TxtAbsnt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAbsnt.GotFocus
        If TxtAbsnt.Text = "" Then
            TxtAbsnt.Text = 0
        End If
        TxtAbsnt.SelectAll()

    End Sub

    Private Sub TxtAbsnt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAbsnt.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then

            If TxtAbsnt.Text = "" Then
                TxtAbsnt.Text = 0
                TxtOvrTime.Select(0, Len(TxtOvrTime.Value))
                TxtOvrTime.Focus()
            ElseIf TxtAbsnt.Text > WrkDays Then
                MsgBox("Invalid value", MsgBoxStyle.Information, "Absent/Leave")

                TxtAbsnt.BackColor = Color.PapayaWhip
                TxtAbsnt.Focus()
                TxtAbsnt.SelectAll()
            Else
                TxtOvrTime.Select(0, Len(TxtOvrTime.Value))
                TxtOvrTime.Focus()

            End If

        End If
    End Sub

    Private Sub TxtAbsnt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAbsnt.KeyUp
        If e.KeyCode = Keys.Tab Then

            TxtAbsnt_KeyDown(sender, e)
            TxtOvrTime.Select(0, Len(TxtOvrTime.Value))
            TxtOvrTime.Focus()
        End If
    End Sub

    Private Sub TxtAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAmt.GotFocus
        If TxtAmt.Text = "" Then
            TxtAmt.Text = FormatNumber(0, 2)
        End If
        TxtAmt.SelectAll()

    End Sub

    Private Sub TxtAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAmt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then

            If TxtAmt.Text = "" Then
                TxtAmt.BackColor = Color.PapayaWhip
                TxtAmt.Focus()
                TxtAmt.SelectAll()

                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Loan Amount")
            ElseIf TxtAmt.Text = 0 Then
                TxtAmt.BackColor = Color.PapayaWhip
                MsgBox("Invalid value", MsgBoxStyle.Information, "Loan Amount")
                TxtAmt.Focus()
                TxtAmt.SelectAll()

            ElseIf TxtAmt.Text <> "" And TxtAmt.Text > 0 Then
                TxtAmt.Text = FormatNumber(TxtAmt.Text, 2)

                If BtnSve.Text = "&Update" And RbIntNo.Checked = True Then
                    LblInst.Text = TxtAmt.Text / NumRepay.Value
                ElseIf BtnSve.Text = "&Update" And RbIntYes.Checked = True Then
                    If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                        IntrstAmt = (TxtAmt.Text * TxtRtInt.Text) / 100
                        Tot_Loan_Amt = TxtAmt.Text + IntrstAmt
                        LblInst.Text = FormatNumber(Tot_Loan_Amt / NumRepay.Value, 2)
                    End If
                End If
                RbIntYes.Checked = True
                TxtRtInt.SelectAll()
                TxtRtInt.Focus()
            End If

        End If
    End Sub

    Private Sub TxtAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAmt.KeyUp
        If e.KeyCode = 9 Then
            TxtAmt_KeyDown(sender, e)
        End If
    End Sub

    Private Sub TxtLWPay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = 13 Then
            TxtOvrTime.Select(0, Len(TxtOvrTime.Value))
            TxtOvrTime.Focus()
        ElseIf e.KeyCode = 9 Then
            TxtOvrTime.Select(0, Len(TxtOvrTime.Value))
            TxtOvrTime.Focus()
        End If
    End Sub

    Private Sub TxtRtInt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRtInt.GotFocus
        If TxtRtInt.Text = "" Then
            TxtRtInt.Text = 0
        End If
        TxtRtInt.SelectAll()

    End Sub

    Private Sub TxtRtInt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRtInt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If TxtRtInt.Text = "" Then
                TxtRtInt.BackColor = Color.PapayaWhip
                TxtRtInt.Focus()
                TxtRtInt.SelectAll()

                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Loan Amount")
            ElseIf TxtRtInt.Text = 0 Then
                TxtRtInt.BackColor = Color.PapayaWhip
                MsgBox("Invalid value", MsgBoxStyle.Information, "Loan Amount")
                TxtRtInt.Focus()
                TxtRtInt.SelectAll()

            ElseIf TxtRtInt.Text <> "" And TxtRtInt.Text > 0 Then
                If BtnSve.Text = "&Update" And RbIntYes.Checked = True Or BtnSve.Text = "&Update" And RbIntYes.Checked = True And RbFlat.Checked = True Then
                    If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                        IntrstAmt = (TxtAmt.Text * TxtRtInt.Text * NumRepay.Value) / (12 * 100)
                        Tot_Loan_Amt = TxtAmt.Text + IntrstAmt
                        LblInst.Text = FormatNumber(Tot_Loan_Amt / NumRepay.Value, 2)

                    End If
                ElseIf BtnSve.Text = "&Update" And RbIntYes.Checked = True Or BtnSve.Text = "&Update" And RbIntYes.Checked = True And RbReduc.Checked = True Then
                    If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                        First_Mnth_Amt = TxtAmt.Text / NumRepay.Value
                        Reduc_Intrst_Amt = (TxtAmt.Text * TxtRtInt.Text) / 100

                        LblInst.Text = FormatNumber(First_Mnth_Amt + Reduc_Intrst_Amt, 2)

                    End If
                End If
                RbReduc.Checked = True
                NumRepay.Select(0, Len(NumRepay.Value))
                NumRepay.Focus()

            End If
       
        End If
    End Sub

    Private Sub TxtRtInt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRtInt.KeyUp
        If e.KeyCode = Keys.Tab Then
            TxtRtInt_KeyDown(sender, e)

        End If
    End Sub

    Private Sub RbFlat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RbFlat.KeyDown
        If e.KeyCode = 13 Then
            NumRepay.Select(0, Len(NumRepay.Value))
            NumRepay.Focus()
        ElseIf e.KeyCode = 9 Then
            NumRepay.Select(0, Len(NumRepay.Value))
            NumRepay.Focus()
        End If
    End Sub

    Private Sub NumRepay_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumRepay.GotFocus
        NumRepay.Select(0, Len(NumRepay.Value))
    End Sub

    Private Sub NumRepay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumRepay.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If NumRepay.Text = "" Then
                MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Repayment Period")
                NumRepay.Select(0, Len(NumRepay.Value))
                NumRepay.Focus()
                Exit Sub
            ElseIf NumRepay.Value = 0 Then
                MsgBox("Invalid value", MsgBoxStyle.Information, "Repayment Period")
                NumRepay.Select(0, Len(NumRepay.Value))
                NumRepay.Focus()
                Exit Sub
            ElseIf NumRepay.Text <> "" And NumRepay.Value > 0 Then

                If RbReduc.Checked = False And RbIntNo.Checked = False Then
                    LblMnthInst.Text = ""
                    LblMnthInst.Text = "Monthly Installment:-"
                    If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                        IntrstAmt = (TxtAmt.Text * TxtRtInt.Text * NumRepay.Value) / (12 * 100)
                        Tot_Loan_Amt = TxtAmt.Text + IntrstAmt
                    End If
                    If NumRepay.Value <> 0 Then
                        LblInst.Text = FormatNumber(Tot_Loan_Amt / NumRepay.Value, 2)
                    End If
                ElseIf RbReduc.Checked = True Then
                    If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                        First_Mnth_Amt = TxtAmt.Text / NumRepay.Value
                        Reduc_Intrst_Amt = (TxtAmt.Text * TxtRtInt.Text) / 100

                        LblInst.Text = FormatNumber(First_Mnth_Amt + Reduc_Intrst_Amt, 2)
                    End If
                ElseIf RbIntNo.Checked = True Then
                    If TxtAmt.Text <> "" Then
                        LblInst.Text = FormatNumber(TxtAmt.Text / NumRepay.Value, 2)
                        DtpkrEffDt.Focus()
                    End If

                End If
                DtpkrEffDt.Focus()
            End If
        End If
    End Sub

    Private Sub NumRepay_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumRepay.KeyUp
        If e.KeyCode = 9 Then
            NumRepay_KeyDown(sender, e)
        End If
    End Sub

    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAbsnt.KeyPress
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


    Private Sub numericTextboxKeyPress1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAdvAmt.KeyPress, TxtAmt.KeyPress, TxtRtInt.KeyPress
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

    Private Sub TxtOvrTime_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOvrTime.GotFocus
        TxtOvrTime.Select(0, Len(TxtOvrTime.Value))

    End Sub


    Private Sub TxtOvrTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOvrTime.KeyDown
        Dim calchrs As Integer

        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            'If TxtOvrTime.Value = "" Then
            '    TxtOvrTime.Value = 0

            If TxtOvrTime.Value > 0 Then
                calchrs = (WrkDays * 24) - WrkDays * (6)
                If TxtOvrTime.Value > calchrs Then
                    MsgBox("Invalid value", MsgBoxStyle.Information, "Overtime Hours")
                    TxtOvrTime.BackColor = Color.PapayaWhip
                    TxtOvrTime.Select(0, Len(TxtOvrTime.Value))
                    TxtOvrTime.Focus()
                    Exit Sub
                ElseIf TxtOvrTime.Value < calchrs Then
                    OvrTmSalry = TxtOvrTime.Value * HrSalry
                    LblEAmt.Text = FormatNumber(EmpSalry + OvrTmSalry, 2)
                    TxtAdvAmt.Focus()
                    TxtAdvAmt.SelectAll()
                End If
            End If
            TxtAdvAmt.SelectAll()
            TxtAdvAmt.Focus()
        End If
    End Sub

    Private Sub TxtOvrTime_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOvrTime.KeyUp
        If e.KeyCode = Keys.Tab Then
            TxtOvrTime_KeyDown(sender, e)
        End If
    End Sub

    Private Sub DtPkrAdvDt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtPkrAdvDt.Leave
        Dim Advdt As Date

        Advdt = DtPkrAdvDt.Value.Date
        WrkDays = Advdt.Day
        DtPkrAdvDt.TabStop = False

    End Sub


    Private Sub TxtOvrTime_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOvrTime.Leave
        Dim OvrTmSalry As Double
        'If TxtOvrTime.Value = "" Then
        '    TxtOvrTime.Value = 0
        'Else
        OvrTmSalry = TxtOvrTime.Value * HrSalry
        LblEAmt.Text = FormatNumber(EmpSalry + OvrTmSalry, 2)

        TxtAdvAmt.Focus()
        TxtAdvAmt.SelectAll()

        'End If
    End Sub

   

    Private Sub TxtAbsnt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAbsnt.Leave
        Dim EmpWrkdays As Double
        If TxtAbsnt.Text = "" Then
            TxtAbsnt.Text = 0
        End If
        If TxtAbsnt.Text <> "" Then
            EmpWrkdays = WrkDays - TxtAbsnt.Text
            EmpSalry = (EmpWrkdays * PerDaySalry)
        End If

    End Sub


    Private Sub NumRepay_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumRepay.Leave
       

    End Sub

    Private Sub RbReduc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbReduc.CheckedChanged
        If RbReduc.Checked = True Then
            LblMnthInst.Text = ""
            LblMnthInst.Text = "1st Month Installment"
        End If
    End Sub

    Private Sub Fnd_Recrd_Advnc()
        Dim Mnth As Integer
        Mnth = DtPkrAdvDt.Value.Date.Month
        Try
            Emp_Adv_Cmd = New SqlCommand("Select count(AdvId) from FinactAdvance where AdvEmpid='" & (EmpId) & "'and month(AdvDt)='" & (Mnth) & "'and AdvStatus<>'Adjusted' and Advdelstatus=1 ", FinActConn)
            Emp_Adv_Rdr = Emp_Adv_Cmd.ExecuteReader
            Emp_Adv_Rdr.Read()
            If Emp_Adv_Rdr.IsDBNull(0) = False Then
                No_of_Recrd = Emp_Adv_Rdr(0)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Adv_Rdr.Close()
            Emp_Adv_Cmd = Nothing
        End Try

    End Sub

    Private Sub Fnd_Recrd_Loan()
        Dim Mnth As Integer
        Mnth = DtPkrAdvDt.Value.Date.Month
        Try
            Emp_Adv_Cmd = New SqlCommand("Select count(LnId) from FinactLoan where LnEmpid='" & (EmpId) & "'and month(LnDt)='" & (Mnth) & "' and LnStatus<>'Adjusted' and Lndelstatus=1 ", FinActConn)
            Emp_Adv_Rdr = Emp_Adv_Cmd.ExecuteReader
            Emp_Adv_Rdr.Read()
            If Emp_Adv_Rdr.IsDBNull(0) = False Then
                Loan_Recrd = Emp_Adv_Rdr(0)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Adv_Rdr.Close()
            Emp_Adv_Cmd = Nothing
        End Try

    End Sub


    Private Sub BtnSve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSve.Click
        Dim Advamt, Bscsalry As Double
       
        If BtnSve.Text = "&Save" Then
            If RbAdvnce.Checked = False And RbLoan.Checked = False Then
                MsgBox("Select Type: Advance or Loan", MsgBoxStyle.Information, "Save")

            ElseIf RbAdvnce.Checked = True Then
                If LblEAmt.Text = "" Then
                    OvrTmSalry = TxtOvrTime.Value * HrSalry
                    LblEAmt.Text = FormatNumber(EmpSalry + OvrTmSalry, 2)
                End If
                If TxtAdvAmt.Text = "" Then
                    TxtAdvAmt.BackColor = Color.PapayaWhip
                    TxtAdvAmt.Focus()
                    TxtAdvAmt.SelectAll()

                    MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Advanced Amount")

                ElseIf TxtAdvAmt.Text = 0 Then
                    TxtAdvAmt.BackColor = Color.PapayaWhip
                    TxtAdvAmt.Focus()
                    TxtAdvAmt.SelectAll()

                    MsgBox("Invalid value", MsgBoxStyle.Information, "Advanced Amount")
                ElseIf TxtAdvAmt.Text <> "" And TxtAdvAmt.Text <> 0 Then
                    Advamt = CDbl(TxtAdvAmt.Text)
                    Bscsalry = CDbl(LblBscSlry.Text)
                    If Advamt > Bscsalry Then
                        TxtAdvAmt.BackColor = Color.PapayaWhip
                        TxtAdvAmt.Focus()
                        TxtAdvAmt.SelectAll()
                        MsgBox("Can't exceed Basic Salary", MsgBoxStyle.Information, "Advanced Amount")
                        Exit Sub
                    Else

                        TxtAdvAmt.BackColor = Color.White

                        Try
                            Emp_Adv_Cmd = New SqlCommand("Finact_Advance_Insert", FinActConn)
                            Emp_Adv_Cmd.CommandType = CommandType.StoredProcedure

                            Emp_Adv_Cmd.Parameters.AddWithValue("@Advadusrid", Current_UsrId)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@Advaddt", Now)

                            Emp_Adv_Cmd.Parameters.AddWithValue("@Advdelstatus", 1)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@AdvDt", DtPkrAdvDt.Value.Date)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@AdvEmpid", EmpId)

                            Emp_Adv_Cmd.Parameters.AddWithValue("@AdvAmt", CDbl(TxtAdvAmt.Text))
                            Emp_Adv_Cmd.Parameters.AddWithValue("@AdvStatus", "Not Adjusted")
                            Emp_Adv_Cmd.ExecuteNonQuery()

                            MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                            Clrval()
                            Me.Size = New System.Drawing.Point(432, 296)
                            PnlEmpAdv.Size = New System.Drawing.Point(399, 199)
                            DtPkrAdvDt.Focus()
                            LblAbsnt.Visible = False
                            TxtAbsnt.Visible = False


                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Emp_Adv_Cmd = Nothing
                        End Try
                    End If
                End If
            ElseIf RbLoan.Checked = True Then
                If TxtAmt.Text = "" Then
                    TxtAmt.BackColor = Color.PapayaWhip
                    TxtAmt.Focus()
                    TxtAmt.SelectAll()
                    MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Loan Amount")
                    Exit Sub

                ElseIf TxtAmt.Text = 0 Then
                    TxtAmt.BackColor = Color.PapayaWhip
                    MsgBox("Invalid value", MsgBoxStyle.Information, "Loan Amount")
                    TxtAmt.Focus()
                    TxtAmt.SelectAll()
                    Exit Sub

                ElseIf TxtAmt.Text <> "" And TxtAmt.Text > 0 Then
                    TxtAmt.Text = FormatNumber(TxtAmt.Text, 2)

                    If BtnSve.Text = "&Update" And RbIntNo.Checked = True Then
                        LblInst.Text = TxtAmt.Text / NumRepay.Value
                    ElseIf BtnSve.Text = "&Update" And RbIntYes.Checked = True Then
                        If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                            IntrstAmt = (TxtAmt.Text * TxtRtInt.Text) / 100
                            Tot_Loan_Amt = TxtAmt.Text + IntrstAmt
                            LblInst.Text = FormatNumber(Tot_Loan_Amt / NumRepay.Value, 2)
                        End If
                    End If
                    RbIntYes.Checked = True
                    TxtRtInt.SelectAll()
                    TxtRtInt.Focus()

                    If TxtRtInt.Text = "" Then
                        TxtRtInt.BackColor = Color.PapayaWhip
                        TxtRtInt.Focus()
                        TxtRtInt.SelectAll()
                        MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Rate of Interest")
                        Exit Sub

                    ElseIf TxtRtInt.Text = 0 Then
                        TxtRtInt.BackColor = Color.PapayaWhip
                        MsgBox("Invalid value", MsgBoxStyle.Information, "Rate of Interest")
                        TxtRtInt.Focus()
                        TxtRtInt.SelectAll()
                        Exit Sub

                    ElseIf TxtRtInt.Text <> "" And TxtRtInt.Text > 0 Then
                        If BtnSve.Text = "&Update" And RbIntYes.Checked = True Or BtnSve.Text = "&Update" And RbIntYes.Checked = True And RbFlat.Checked = True Then
                            If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                                IntrstAmt = (TxtAmt.Text * TxtRtInt.Text * NumRepay.Value) / (12 * 100)
                                Tot_Loan_Amt = TxtAmt.Text + IntrstAmt
                                LblInst.Text = FormatNumber(Tot_Loan_Amt / NumRepay.Value, 2)
                            End If
                        ElseIf BtnSve.Text = "&Update" And RbIntYes.Checked = True Or BtnSve.Text = "&Update" And RbIntYes.Checked = True And RbReduc.Checked = True Then
                            If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                                First_Mnth_Amt = TxtAmt.Text / NumRepay.Value
                                Reduc_Intrst_Amt = (TxtAmt.Text * TxtRtInt.Text) / 100

                                LblInst.Text = FormatNumber(First_Mnth_Amt + Reduc_Intrst_Amt, 2)

                            End If
                        End If
                        'RbReduc.Checked = True
                        NumRepay.Select(0, Len(NumRepay.Value))
                        NumRepay.Focus()
                    End If
                    If NumRepay.Text = "" Then
                        MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Repayment Period")
                        NumRepay.Select(0, Len(NumRepay.Value))
                        NumRepay.Focus()
                        Exit Sub
                    ElseIf NumRepay.Value = 0 Then
                        MsgBox("Invalid value", MsgBoxStyle.Information, "Repayment Period")
                        NumRepay.Select(0, Len(NumRepay.Value))
                        NumRepay.Focus()
                        Exit Sub
                    ElseIf NumRepay.Text <> "" And NumRepay.Value > 0 Then

                        If RbReduc.Checked = False And RbIntNo.Checked = False Then
                            LblMnthInst.Text = ""
                            LblMnthInst.Text = "Monthly Installment:-"
                            If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                                IntrstAmt = (TxtAmt.Text * TxtRtInt.Text * NumRepay.Value) / (12 * 100)
                                Tot_Loan_Amt = TxtAmt.Text + IntrstAmt
                            End If
                            If NumRepay.Value <> 0 Then
                                LblInst.Text = FormatNumber(Tot_Loan_Amt / NumRepay.Value, 2)
                            End If
                        ElseIf RbReduc.Checked = True Then
                            If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                                First_Mnth_Amt = TxtAmt.Text / NumRepay.Value
                                Reduc_Intrst_Amt = (TxtAmt.Text * TxtRtInt.Text) / 100

                                LblInst.Text = FormatNumber(First_Mnth_Amt + Reduc_Intrst_Amt, 2)
                            End If
                        ElseIf RbIntNo.Checked = True Then
                            If TxtAmt.Text <> "" Then
                                LblInst.Text = FormatNumber(TxtAmt.Text / NumRepay.Value, 2)
                                DtpkrEffDt.Focus()
                            End If

                        End If
                        DtpkrEffDt.Focus()




                        Try
                            Emp_Adv_Cmd = New SqlCommand("Finact_Loan_Insert", FinActConn)
                            Emp_Adv_Cmd.CommandType = CommandType.StoredProcedure
                            Emp_Adv_Cmd.Parameters.AddWithValue("@Lnadusrid", Current_UsrId)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@Lnaddt", Now)

                            Emp_Adv_Cmd.Parameters.AddWithValue("@Lndelstatus", 1)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@LnDt", DtPkrAdvDt.Value.Date)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@LnEmpid", EmpId)


                            Emp_Adv_Cmd.Parameters.AddWithValue("@LnAmt", CDbl(TxtAmt.Text))
                            If RbIntYes.Checked = True Then
                                Emp_Adv_Cmd.Parameters.AddWithValue("@LnIntrstAppli", 1)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@LnRateIntrst", TxtRtInt.Text)
                                If RbReduc.Checked = True Then
                                    Emp_Adv_Cmd.Parameters.AddWithValue("@MethdIntrst", "Reducing")
                                ElseIf RbFlat.Checked = True Then
                                    Emp_Adv_Cmd.Parameters.AddWithValue("@MethdIntrst", "Flat")
                                End If
                            ElseIf RbIntNo.Checked = True Then
                                Emp_Adv_Cmd.Parameters.AddWithValue("@LnIntrstAppli", 0)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@LnRateIntrst", 0)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@MethdIntrst", 0)
                            End If


                            Emp_Adv_Cmd.Parameters.AddWithValue("@RepayPrd", NumRepay.Value)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@MnthlyInst", CDbl(LblInst.Text))
                            Emp_Adv_Cmd.Parameters.AddWithValue("@LnEffDt", DtpkrEffDt.Value.Date)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@LnStatus", "Not Adjusted")


                            Emp_Adv_Cmd.ExecuteNonQuery()


                            MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information, "Save Record")
                            Clrval()
                            Me.Size = New System.Drawing.Point(432, 296)
                            PnlEmpAdv.Size = New System.Drawing.Point(399, 199)
                            DtPkrAdvDt.Focus()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Emp_Adv_Cmd = Nothing
                        End Try
                    End If
                End If
            End If
        ElseIf BtnSve.Text = "&Update" Then
            Count_LnInstlmnt_FrmSlrySlip()
            If PnlEmpAdv.Enabled = False Then
                MsgBox("First double click any record from the List to Edit", MsgBoxStyle.Information, "Edit Record")
                
            ElseIf RbAdvnce.Checked = True Then
                If TxtAdvAmt.Text = "" Then
                    TxtAdvAmt.BackColor = Color.PapayaWhip
                    TxtAdvAmt.Focus()
                    TxtAdvAmt.SelectAll()

                    MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Advanced Amount")

                ElseIf TxtAdvAmt.Text = 0 Then
                    TxtAdvAmt.BackColor = Color.PapayaWhip
                    TxtAdvAmt.Focus()
                    TxtAdvAmt.SelectAll()

                    MsgBox("Invalid value", MsgBoxStyle.Information, "Advanced Amount")
                ElseIf TxtAdvAmt.Text <> "" And TxtAdvAmt.Text <> 0 Then
                    Advamt = CDbl(TxtAdvAmt.Text)
                    Bscsalry = CDbl(LblBscSlry.Text)
                    If Advamt > Bscsalry Then
                        TxtAdvAmt.BackColor = Color.PapayaWhip
                        TxtAdvAmt.Focus()
                        TxtAdvAmt.SelectAll()
                        MsgBox("Can't exceed Basic Salary", MsgBoxStyle.Information, "Advanced Amount")
                        Exit Sub
                    Else

                        TxtAdvAmt.BackColor = Color.White
                        Try
                            Emp_Adv_Cmd = New SqlCommand("Finact_Advance_Update", FinActConn)
                            Emp_Adv_Cmd.CommandType = CommandType.StoredProcedure

                            Emp_Adv_Cmd.Parameters.AddWithValue("@Advedtusrid", Current_UsrId)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@Advedtdt", Now)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@AdvEmpid", EmplId)

                            Emp_Adv_Cmd.Parameters.AddWithValue("@AdvAmt", CDbl(TxtAdvAmt.Text))
                            Emp_Adv_Cmd.ExecuteNonQuery()

                            MsgBox("Record has been Updated Successfully", MsgBoxStyle.Information, "Edit Record")
                            Clrval()
                            BtnSve.Text = "&Save"
                            BtnFnd.Text = "&Find"
                            PnlEmpAdv.Enabled = True
                            CmbxEmpNm.Enabled = True
                            DtPkrAdvDt.Enabled = True
                            RbLoan.Enabled = True

                            Me.Size = New System.Drawing.Point(432, 296)
                            PnlEmpAdv.Size = New System.Drawing.Point(399, 199)
                            DtPkrAdvDt.Focus()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Emp_Adv_Cmd = Nothing
                        End Try
                    End If
                End If
            ElseIf RbLoan.Checked = True Then
                If Count_LnInstlmnt > 0 Then
                    MsgBox("Can't Update this Record as Installments have been started", MsgBoxStyle.Information, "Edit Record")
                    Exit Sub

                ElseIf TxtAmt.Text = "" Then
                    TxtAmt.BackColor = Color.PapayaWhip
                    TxtAmt.Focus()
                    TxtAmt.SelectAll()
                    MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Loan Amount")
                    Exit Sub

                ElseIf TxtAmt.Text = 0 Then
                    TxtAmt.BackColor = Color.PapayaWhip
                    MsgBox("Invalid value", MsgBoxStyle.Information, "Loan Amount")
                    TxtAmt.Focus()
                    TxtAmt.SelectAll()
                    Exit Sub

                ElseIf TxtAmt.Text <> "" And TxtAmt.Text > 0 Then
                    TxtAmt.Text = FormatNumber(TxtAmt.Text, 2)

                    If BtnSve.Text = "&Update" And RbIntNo.Checked = True Then
                        LblInst.Text = TxtAmt.Text / NumRepay.Value
                    ElseIf BtnSve.Text = "&Update" And RbIntYes.Checked = True Then
                        If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                            IntrstAmt = (TxtAmt.Text * TxtRtInt.Text) / 100
                            Tot_Loan_Amt = TxtAmt.Text + IntrstAmt
                            LblInst.Text = FormatNumber(Tot_Loan_Amt / NumRepay.Value, 2)
                        End If
                    End If
                    RbIntYes.Checked = True
                    TxtRtInt.SelectAll()
                    TxtRtInt.Focus()

                    If TxtRtInt.Text = "" Then
                        TxtRtInt.BackColor = Color.PapayaWhip
                        TxtRtInt.Focus()
                        TxtRtInt.SelectAll()
                        MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Rate of Interest")
                        Exit Sub

                    ElseIf TxtRtInt.Text = 0 Then
                        TxtRtInt.BackColor = Color.PapayaWhip
                        MsgBox("Invalid value", MsgBoxStyle.Information, "Rate of Interest")
                        TxtRtInt.Focus()
                        TxtRtInt.SelectAll()
                        Exit Sub

                    ElseIf TxtRtInt.Text <> "" And TxtRtInt.Text > 0 Then
                        If BtnSve.Text = "&Update" And RbIntYes.Checked = True Or BtnSve.Text = "&Update" And RbIntYes.Checked = True And RbFlat.Checked = True Then
                            If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                                IntrstAmt = (TxtAmt.Text * TxtRtInt.Text * NumRepay.Value) / (12 * 100)
                                Tot_Loan_Amt = TxtAmt.Text + IntrstAmt
                                LblInst.Text = FormatNumber(Tot_Loan_Amt / NumRepay.Value, 2)
                            End If
                        ElseIf BtnSve.Text = "&Update" And RbIntYes.Checked = True Or BtnSve.Text = "&Update" And RbIntYes.Checked = True And RbReduc.Checked = True Then
                            If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                                First_Mnth_Amt = TxtAmt.Text / NumRepay.Value
                                Reduc_Intrst_Amt = (TxtAmt.Text * TxtRtInt.Text) / 100

                                LblInst.Text = FormatNumber(First_Mnth_Amt + Reduc_Intrst_Amt, 2)

                            End If
                        End If
                        RbReduc.Checked = True
                        NumRepay.Select(0, Len(NumRepay.Value))
                        NumRepay.Focus()
                    End If
                    If NumRepay.Text = "" Then
                        MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Repayment Period")
                        NumRepay.Select(0, Len(NumRepay.Value))
                        NumRepay.Focus()
                        Exit Sub
                    ElseIf NumRepay.Value = 0 Then
                        MsgBox("Invalid value", MsgBoxStyle.Information, "Repayment Period")
                        NumRepay.Select(0, Len(NumRepay.Value))
                        NumRepay.Focus()
                        Exit Sub
                    ElseIf NumRepay.Text <> "" And NumRepay.Value > 0 Then

                        If RbReduc.Checked = False And RbIntNo.Checked = False Then
                            LblMnthInst.Text = ""
                            LblMnthInst.Text = "Monthly Installment:-"
                            If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                                IntrstAmt = (TxtAmt.Text * TxtRtInt.Text * NumRepay.Value) / (12 * 100)
                                Tot_Loan_Amt = TxtAmt.Text + IntrstAmt
                            End If
                            If NumRepay.Value <> 0 Then
                                LblInst.Text = FormatNumber(Tot_Loan_Amt / NumRepay.Value, 2)
                            End If
                        ElseIf RbReduc.Checked = True Then
                            If TxtAmt.Text <> "" And TxtRtInt.Text <> "" Then
                                First_Mnth_Amt = TxtAmt.Text / NumRepay.Value
                                Reduc_Intrst_Amt = (TxtAmt.Text * TxtRtInt.Text) / 100

                                LblInst.Text = FormatNumber(First_Mnth_Amt + Reduc_Intrst_Amt, 2)
                            End If
                        ElseIf RbIntNo.Checked = True Then
                            If TxtAmt.Text <> "" Then
                                LblInst.Text = FormatNumber(TxtAmt.Text / NumRepay.Value, 2)
                                DtpkrEffDt.Focus()
                            End If

                        End If
                        DtpkrEffDt.Focus()
                        Try
                            Emp_Adv_Cmd = New SqlCommand("Finact_Loan_Update", FinActConn)
                            Emp_Adv_Cmd.CommandType = CommandType.StoredProcedure

                            Emp_Adv_Cmd.Parameters.AddWithValue("@Lnedtusrid", Current_UsrId)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@Lnedtdt", Now)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@LnEmpid", EmplId)

                            Emp_Adv_Cmd.Parameters.AddWithValue("@LnAmt", CDbl(TxtAmt.Text))
                            If RbIntYes.Checked = True Then
                                Emp_Adv_Cmd.Parameters.AddWithValue("@LnIntrstAppli", 1)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@LnRateIntrst", TxtRtInt.Text)
                                If RbReduc.Checked = True Then
                                    Emp_Adv_Cmd.Parameters.AddWithValue("@MethdIntrst", "Reducing")
                                ElseIf RbFlat.Checked = True Then
                                    Emp_Adv_Cmd.Parameters.AddWithValue("@MethdIntrst", "Flat")
                                End If
                            ElseIf RbIntNo.Checked = True Then
                                Emp_Adv_Cmd.Parameters.AddWithValue("@LnIntrstAppli", 0)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@LnRateIntrst", 0)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@MethdIntrst", 0)
                            End If

                            Emp_Adv_Cmd.Parameters.AddWithValue("@RepayPrd", NumRepay.Value)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@MnthlyInst", CDbl(LblInst.Text))
                            Emp_Adv_Cmd.Parameters.AddWithValue("@LnEffDt", DtpkrEffDt.Value.Date)


                            Emp_Adv_Cmd.ExecuteNonQuery()

                            MsgBox("Record has been Updated Successfully", MsgBoxStyle.Information, "Edit Record")
                            Clrval()
                            BtnSve.Text = "&Save"
                            BtnFnd.Text = "&Find"
                            PnlEmpAdv.Enabled = True
                            CmbxEmpNm.Enabled = True
                            DtPkrAdvDt.Enabled = True
                            RbLoan.Enabled = True

                            Me.Size = New System.Drawing.Point(432, 296)
                            PnlEmpAdv.Size = New System.Drawing.Point(399, 199)
                            DtPkrAdvDt.Focus()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Emp_Adv_Cmd = Nothing
                        End Try

                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Clrval()

        If CmbxEmpNm.SelectedIndex >= 0 Then
            CmbxEmpNm.SelectedIndex = 0
        End If
        'If CmbxEmpNm.SelectedIndex >= 1 Or CmbxEmpNm.SelectedIndex = 0 Then
        '    CmbxEmpNm.SelectedIndex = -1
        'End If
        RbAdvnce.Checked = False
        RbLoan.Checked = False
        TxtAbsnt.Clear()
        TxtOvrTime.Value = 0
        LblEAmt.Text = ""
        TxtAdvAmt.Clear()
        TxtAmt.Text = FormatNumber(0, 2)
        RbIntYes.Checked = False
        RbIntNo.Checked = False
        TxtRtInt.Clear()
        RbReduc.Checked = False
        RbFlat.Checked = False
        NumRepay.Value = 0
        LblInst.Text = ""
        'LblBscSlry.Text = ""
    End Sub

    Private Sub RbIntNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbIntNo.CheckedChanged
        Me.Size = New System.Drawing.Point(432, 554)
        PnlEmpAdv.Size = New System.Drawing.Point(399, 458)

        LblRtInt.Visible = False
        TxtRtInt.Visible = False
        LblAnly.Visible = False
        LblMCalc.Visible = False
        PnlIntrst.Visible = False
        RbReduc.Visible = False
        RbFlat.Visible = False
        LblMnthInst.Visible = True
        LblRepay.Visible = True
        NumRepay.Visible = True
        LblMnths.Visible = True
        LblInst.Visible = True
        LblRs.Visible = True
        LblEffDt.Visible = True
        DtpkrEffDt.Visible = True
        NumRepay.Select(0, Len(NumRepay.Value))
        NumRepay.Focus()


        LblRepay.Location = New System.Drawing.Point(12, 297)
        NumRepay.Location = New System.Drawing.Point(170, 299)
        LblMnths.Location = New System.Drawing.Point(218, 299)
        LblMnthInst.Location = New System.Drawing.Point(12, 353)
        LblInst.Location = New System.Drawing.Point(170, 353)
        LblRs.Location = New System.Drawing.Point(297, 353)
        LblEffDt.Location = New System.Drawing.Point(12, 414)
        DtpkrEffDt.Location = New System.Drawing.Point(170, 415)

    End Sub

    Private Sub Count_LnInstlmnt_FrmSlrySlip()
        Dim mnthname As String
        mnthname = MonthName(EffDt.Month)
        Try
            Emp_Adv_Cmd = New SqlCommand("Select count(SlryId)from FinactSlrySlip inner join FinactLoan on FinactSlrySlip.SlryEmpid=FinactLoan.LnEmpid where SlryMnth='" & (mnthname) & "' and SlryLnDeduc<>0 and Slrydelstatus=1 and MethdIntrst='Reducing' and LnStatus<>'Adjusted' and Lndelstatus=1 and SlryEmpid='" & (EmplId) & "'", FinActConn)

            Emp_Adv_Rdr = Emp_Adv_Cmd.ExecuteReader
            Emp_Adv_Rdr.Read()
            If Emp_Adv_Rdr.IsDBNull(0) = False Then
                Count_LnInstlmnt = Emp_Adv_Rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Adv_Rdr.Close()
            Emp_Adv_Cmd = Nothing
        End Try
    End Sub


    Private Sub BtnFnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd.Click
        Dim response As String
        If BtnFnd.Text = "&Find" Then

            Me.Size = New System.Drawing.Point(432, 296)
            PnlEmpAdv.Size = New System.Drawing.Point(399, 199)
            PnlEmpAdv.Enabled = False
            PnlFnd.Visible = True

            PnlFnd.Location = New System.Drawing.Point(175, 75)
            PnlRbAdvnc.Checked = True
            PnlRbAdvnc.Focus()

        ElseIf BtnFnd.Text = "&Delete" And LstVewAdv.Visible = True Then
            Dim Lst_cnt, Lst_sel_cnt, Lst_cntr, Id, indx As Integer
            Lst_cnt = LstVewAdv.Items.Count
            Lst_sel_cnt = LstVewAdv.SelectedItems.Count
            Lst_cntr = 0
            If Lst_sel_cnt = 0 Then
                MsgBox("No record Selected in the list to delete", MsgBoxStyle.Information, "Delete")
                Exit Sub
            ElseIf Lst_sel_cnt <> 0 Then
                Count_LnInstlmnt_FrmSlrySlip()
                If Count_LnInstlmnt > 0 And Me.ColumnHeader3.Text = "Loan Amount" Then
                    MsgBox("Can't Delete this Record as Installments have been started.", MsgBoxStyle.Information, "Delete Record")
                    Exit Sub
                Else
                    response = MsgBox("Are you sure to Delete Record?", MsgBoxStyle.YesNo, "Delete")
                    If response = vbYes And Me.ColumnHeader3.Text = "Advanced Amount" Then

                        While Lst_cntr < Lst_sel_cnt
                            Id = LstVewAdv.SelectedItems(Lst_cntr).SubItems(0).Text
                            Try

                                Emp_Adv_Cmd = New SqlCommand("Finact_Advance_Delete", FinActConn)
                                Emp_Adv_Cmd.CommandType = CommandType.StoredProcedure
                                Emp_Adv_Cmd.Parameters.AddWithValue("@AdvEmpId", Id)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@Advdelusrid", Current_UsrId)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@Advdeldt", Now)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@Advdelstatus", 0)
                                Emp_Adv_Cmd.ExecuteNonQuery()

                                indx = LstVewAdv.SelectedItems(0).Index
                                LstVewAdv.Items(indx).Remove()
                                Clrval()

                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                Emp_Adv_Cmd = Nothing
                            End Try
                            Lst_cntr = Lst_cntr + 1
                        End While
                    ElseIf response = vbYes And Me.ColumnHeader3.Text = "Loan Amount" Then
                        While Lst_cntr < Lst_sel_cnt
                            Id = LstVewAdv.SelectedItems(Lst_cntr).SubItems(0).Text
                            Try

                                Emp_Adv_Cmd = New SqlCommand("Finact_Loan_Delete", FinActConn)
                                Emp_Adv_Cmd.CommandType = CommandType.StoredProcedure
                                Emp_Adv_Cmd.Parameters.AddWithValue("@LnEmpid", Id)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@Lndelusrid", Current_UsrId)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@Lndeldt", Now)
                                Emp_Adv_Cmd.Parameters.AddWithValue("@Lndelstatus", 0)
                                Emp_Adv_Cmd.ExecuteNonQuery()

                                indx = LstVewAdv.SelectedItems(0).Index
                                LstVewAdv.Items(indx).Remove()
                                Clrval()

                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                Emp_Adv_Cmd = Nothing
                            End Try
                            Lst_cntr = Lst_cntr + 1
                        End While
                    ElseIf response = vbNo Then
                        LstVewAdv.Focus()
                        Lstcount = LstVewAdv.Items.Count
                        If Lstcount <> 0 Then
                            LstVewAdv.Items(0).Selected = True
                        End If
                    End If
                End If
                If Lst_cntr <> 0 And Count_LnInstlmnt = 0 Then
                    MsgBox("Record has been Deleted Successfully", MsgBoxStyle.Information, "Delete Record")
                    Clrval()
                    BtnSve.Text = "&Save"
                    BtnFnd.Text = "&Find"
                    Me.Size = New System.Drawing.Point(432, 296)
                    PnlEmpAdv.Size = New System.Drawing.Point(399, 199)
                    PnlEmpAdv.Enabled = True

                    CmbxEmpNm.Enabled = True
                    DtPkrAdvDt.Enabled = True
                    RbLoan.Enabled = True
                    DtPkrAdvDt.Focus()
                End If
            End If

        ElseIf BtnFnd.Text = "&Delete" And LstVewAdv.Visible = False Then
            If CmbxEmpNm.Text = "" Then
                MsgBox("No Record Found to Delete", MsgBoxStyle.Information, "Delete Record")

            ElseIf CmbxEmpNm.Text <> "" Then
                Count_LnInstlmnt_FrmSlrySlip()
                If Count_LnInstlmnt > 0 And TxtAmt.Visible = True Then
                    MsgBox("Can't Delete this Record as Installments have been started", MsgBoxStyle.Information, "Delete Record")
                    Exit Sub
                Else
                    response = MsgBox("Are you sure to Delete Record?", MsgBoxStyle.YesNo, "Delete")
                    If response = vbYes And TxtAdvAmt.Visible = True Then

                        Try

                            Emp_Adv_Cmd = New SqlCommand("Finact_Advance_Delete", FinActConn)
                            Emp_Adv_Cmd.CommandType = CommandType.StoredProcedure
                            Emp_Adv_Cmd.Parameters.AddWithValue("@AdvEmpId", EmplId)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@Advdelusrid", Current_UsrId)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@Advdeldt", Now)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@Advdelstatus", 0)
                            Emp_Adv_Cmd.ExecuteNonQuery()

                            MsgBox("Record has been Deleted Successfully", MsgBoxStyle.Information, "Delete Record")
                            Clrval()
                            BtnSve.Text = "&Save"
                            BtnFnd.Text = "&Find"
                            Me.Size = New System.Drawing.Point(432, 296)
                            PnlEmpAdv.Size = New System.Drawing.Point(399, 199)
                            DtPkrAdvDt.Focus()


                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Emp_Adv_Cmd = Nothing
                        End Try
                    ElseIf response = vbYes And TxtAmt.Visible = True Then
                        Try

                            Emp_Adv_Cmd = New SqlCommand("Finact_Loan_Delete", FinActConn)
                            Emp_Adv_Cmd.CommandType = CommandType.StoredProcedure
                            Emp_Adv_Cmd.Parameters.AddWithValue("@LnEmpid", EmplId)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@Lndelusrid", Current_UsrId)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@Lndeldt", Now)
                            Emp_Adv_Cmd.Parameters.AddWithValue("@Lndelstatus", 0)
                            Emp_Adv_Cmd.ExecuteNonQuery()
                            MsgBox("Record has been Deleted Successfully", MsgBoxStyle.Information, "Delete Record")
                            Clrval()
                            BtnSve.Text = "&Save"
                            BtnFnd.Text = "&Find"
                            Me.Size = New System.Drawing.Point(432, 296)
                            PnlEmpAdv.Size = New System.Drawing.Point(399, 199)
                            DtPkrAdvDt.Focus()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Emp_Adv_Cmd = Nothing
                        End Try

                    End If
                End If
        End If
        End If
    End Sub


    Private Sub BtnFnd_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd_OK.Click
        LblAbsnt.Visible = False
        TxtAbsnt.Visible = False
        PnlFnd.Visible = False
        LstVewAdv.Visible = True

        If PnlRbAdvnc.Checked = True Then
            LstVewAdv.Visible = True
            Me.ColumnHeader3.Text = "Advanced Amount"
            Fetch_List_Advnc()
        ElseIf PnlRbLoan.Checked = True Then
            LstVewAdv.Visible = True
            Me.ColumnHeader3.Text = "Loan Amount"
            Fetch_List_Loan()
        End If

    End Sub

    Private Sub Fetch_List_Advnc()
        Dim LstAdvnc As ListViewItem
        LstVewAdv.Items.Clear()
        Try
            Emp_Adv_Cmd = New SqlCommand("Select AdvEmpId,FinactEmpmstr.empname,AdvAmt,AdvDt,FinactEmpmstr.empgrade from FinactAdvance  inner join FinactEmpmstr on FinactAdvance.AdvEmpId= FinactEmpmstr.empid where Advdelstatus=1 and AdvStatus='Not Adjusted' and empdelstatus=1", FinActConn)
            Emp_Adv_Rdr = Emp_Adv_Cmd.ExecuteReader

            BtnSve.Text = "&Update"
            BtnFnd.Text = "&Delete"

          
            While Emp_Adv_Rdr.Read()
                If Emp_Adv_Rdr.HasRows = True Then
                    Me.Size = New System.Drawing.Point(856, 342)
                    PnlEmpAdv.Size = New System.Drawing.Point(399, 244)
                    LblAmt.Visible = False
                    TxtAmt.Visible = False
                    TxtAdvAmt.Visible = True
                    LblAdcAmt.Visible = True
                    LblRs.Visible = True
                    LblAdcAmt.Location = New System.Drawing.Point(12, 200)
                    TxtAdvAmt.Location = New System.Drawing.Point(170, 201)
                    LblRs.Location = New System.Drawing.Point(299, 200)
                    LstAdvnc = LstVewAdv.Items.Add(Emp_Adv_Rdr(0))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(1))
                    LstAdvnc.SubItems.Add(FormatNumber(Emp_Adv_Rdr(2), 2))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(3))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(4))
                End If
            End While
            LstVewAdv.Focus()
            Lstcount = LstVewAdv.Items.Count
            If Lstcount <> 0 Then
                LstVewAdv.Items(0).Selected = True
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Emp_Adv_Rdr.HasRows = False Then
                MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")
                PnlEmpAdv.Enabled = True
                BtnSve.Text = "&Save"
                BtnFnd.Text = "&Find"
                DtPkrAdvDt.Focus()
            End If
            Emp_Adv_Rdr.Close()
            Emp_Adv_Cmd = Nothing
        End Try
    End Sub

    Private Sub Fetch_List_Loan()
        Dim LstAdvnc As ListViewItem
        LstVewAdv.Items.Clear()
        Try
            Emp_Adv_Cmd = New SqlCommand("Select LnEmpId,FinactEmpmstr.empname,LnAmt,LnEffDt,FinactEmpmstr.empgrade,LnIntrstAppli,LnRateIntrst,MethdIntrst,RepayPrd,MnthlyInst,LnEffDt from FinactLoan  inner join FinactEmpmstr on FinactLoan.LnEmpId= FinactEmpmstr.empid where LnStatus<>'Adjusted' and Lndelstatus=1 ", FinActConn)
            Emp_Adv_Rdr = Emp_Adv_Cmd.ExecuteReader

            While Emp_Adv_Rdr.Read()
                If Emp_Adv_Rdr.HasRows = True Then
                    BtnSve.Text = "&Update"
                    BtnFnd.Text = "&Delete"

                    Me.Size = New System.Drawing.Point(856, 342)
                    PnlEmpAdv.Size = New System.Drawing.Point(399, 244)
                    LblAmt.Visible = False
                    TxtAmt.Visible = False
                    TxtAdvAmt.Visible = True
                    LblAdcAmt.Visible = True
                    LblRs.Visible = True
                    LblAdcAmt.Location = New System.Drawing.Point(12, 200)
                    TxtAdvAmt.Location = New System.Drawing.Point(170, 201)
                    LblRs.Location = New System.Drawing.Point(299, 200)

                    LstAdvnc = LstVewAdv.Items.Add(Emp_Adv_Rdr(0))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(1))
                    LstAdvnc.SubItems.Add(FormatNumber(Emp_Adv_Rdr(2), 2))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(3))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(4))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(5))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(6))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(7))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(8))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(9))
                    LstAdvnc.SubItems.Add(Emp_Adv_Rdr(10))
                End If
            End While
            'LstVewAdv.Items(0).Selected = True
            LstVewAdv.Focus()
            Lstcount = LstVewAdv.Items.Count
            If Lstcount <> 0 Then
                LstVewAdv.Items(0).Selected = True
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Emp_Adv_Rdr.HasRows = False Then
                MsgBox("No Record Found", MsgBoxStyle.Information, "Find Record")
                PnlEmpAdv.Enabled = True
                BtnSve.Text = "&Save"
                BtnFnd.Text = "&Find"
                DtPkrAdvDt.Focus()
              
            End If

            Emp_Adv_Rdr.Close()
            Emp_Adv_Cmd = Nothing
        End Try
    End Sub


    Private Sub LstVewAdv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewAdv.DoubleClick
        Dim Indx1 As Integer
        Dim yesno As Boolean

        PnlEmpAdv.Enabled = True
        Indx1 = LstVewAdv.SelectedItems(0).Index
        EmplId = LstVewAdv.Items(Indx1).SubItems(0).Text
        CmbxEmpNm.Text = LstVewAdv.Items(Indx1).SubItems(1).Text
        AdvDt = LstVewAdv.Items(Indx1).SubItems(3).Text
        DtPkrAdvDt.MaxDate = Today
        DtPkrAdvDt.MinDate = AdvDt
        DtPkrAdvDt.Text = AdvDt

        LblBscSlry.Text = FormatNumber(LstVewAdv.Items(Indx1).SubItems(4).Text, 2)
        If Me.ColumnHeader3.Text = "Advanced Amount" Then
            TxtAdvAmt.Text = FormatNumber(LstVewAdv.Items(Indx1).SubItems(2).Text, 2)
            RbAdvnce.Checked = True
            RbLoan.Enabled = False
            RbAdvnce.Enabled = True
            Me.Size = New System.Drawing.Point(432, 342)
            PnlEmpAdv.Size = New System.Drawing.Point(399, 244)
            LblAbsnt.Visible = False
            TxtAbsnt.Visible = False

            TxtAdvAmt.Visible = True
            LblAdcAmt.Visible = True
            LblRs.Visible = True
            LblAdcAmt.Location = New System.Drawing.Point(12, 200)
            TxtAdvAmt.Location = New System.Drawing.Point(170, 201)
            LblRs.Location = New System.Drawing.Point(299, 200)
            TxtAdvAmt.Focus()
            TxtAdvAmt.SelectAll()
        ElseIf Me.ColumnHeader3.Text = "Loan Amount" Then
            RbLoan.Checked = True
            RbLoan.Enabled = True
            RbAdvnce.Enabled = False

            TxtAmt.Text = FormatNumber(LstVewAdv.Items(Indx1).SubItems(2).Text, 2)
            yesno = LstVewAdv.Items(Indx1).SubItems(5).Text

            If yesno = "True" Then
                RbIntYes.Checked = True
                RbIntYes.Enabled = True
                RbIntNo.Enabled = False
            ElseIf yesno = "False" Then
                RbIntNo.Checked = True
                RbIntNo.Enabled = True
                RbIntYes.Enabled = False
            End If
            TxtRtInt.Text = LstVewAdv.Items(Indx1).SubItems(6).Text
            If LstVewAdv.Items(Indx1).SubItems(7).Text = "Reducing" Then
                RbReduc.Checked = True
                RbFlat.Enabled = False

            ElseIf LstVewAdv.Items(Indx1).SubItems(7).Text = "Flat" Then
                RbFlat.Checked = True
                RbReduc.Enabled = False

            End If
            NumRepay.Value = LstVewAdv.Items(Indx1).SubItems(8).Text
            LblInst.Text = FormatNumber(LstVewAdv.Items(Indx1).SubItems(9).Text, 2)
            EffDt = LstVewAdv.Items(Indx1).SubItems(10).Text
            DtpkrEffDt.MaxDate = Today
            DtpkrEffDt.MinDate = EffDt
            DtpkrEffDt.Text = EffDt

            TxtAmt.Focus()
            TxtAmt.SelectAll()

        End If

        LstVewAdv.Visible = False

        CmbxEmpNm.Enabled = False
        DtPkrAdvDt.Enabled = False
    End Sub


    Private Sub BtnFnd_Cncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PnlFnd.Visible = False
        PnlEmpAdv.Enabled = True
        DtPkrAdvDt.Focus()
    End Sub


    Private Sub PnlRbAdvnc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PnlRbAdvnc.KeyDown
        If e.KeyCode = 13 Then

            PnlRbLoan.Focus()
        ElseIf e.KeyCode = 9 Then

            PnlRbLoan.Focus()
        End If
    End Sub


    Private Sub PnlRbLoan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PnlRbLoan.KeyDown
        If e.KeyCode = 13 Then
            BtnFnd_OK.Focus()
        ElseIf e.KeyCode = 9 Then
            BtnFnd_OK.Focus()
        End If
    End Sub


    Private Sub CmbxEmpNm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEmpNm.SelectedIndexChanged
        If CmbxEmpNm.SelectedIndex >= 0 Then
            Try
                Emp_Adv_Cmd = New SqlCommand("Select empgrade,empid from FinactEmpmstr where empname='" & (CmbxEmpNm.Text) & "' ", FinActConn)
                Emp_Adv_Rdr = Emp_Adv_Cmd.ExecuteReader
                Emp_Adv_Rdr.Read()
                If Emp_Adv_Rdr.HasRows = True Then

                    LblBscSlry.Text = FormatNumber(Emp_Adv_Rdr(0), 2)
                    EmpId = Emp_Adv_Rdr(1)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Emp_Adv_Rdr.Close()
                Emp_Adv_Cmd = Nothing
            End Try


            Totdays = Date.DaysInMonth(Today.Year, Today.Month)

            If LblBscSlry.Text <> "" Then
                PerDaySalry = CDbl(LblBscSlry.Text / Totdays)
                HrSalry = FormatNumber(PerDaySalry / 24, 2)

            End If
            'RbAdvnce.Focus()
        End If

    End Sub

    Private Sub TxtAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAmt.TextChanged
        If TxtAmt.BackColor <> Color.White And TxtAmt.Text <> "" Then
            TxtAmt.BackColor = Color.White
        End If
    End Sub


    Private Sub TxtRtInt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRtInt.TextChanged
        If TxtRtInt.BackColor <> Color.White And TxtRtInt.Text <> "" Then
            TxtRtInt.BackColor = Color.White
        End If
      
    End Sub


    Private Sub TxtAbsnt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAbsnt.TextChanged
        If TxtAbsnt.BackColor <> Color.White Then
            TxtAbsnt.BackColor = Color.White
        End If
    End Sub

    Private Sub TxtOvrTime_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOvrTime.ValueChanged
        If TxtOvrTime.BackColor <> Color.White And TxtOvrTime.Text <> "" Then
            TxtOvrTime.BackColor = Color.White
        End If
    End Sub

    Private Sub DtpkrEffDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrEffDt.KeyDown
        If e.KeyCode = Keys.Tab Then
            BtnSve.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            BtnSve.Focus()

        End If
    End Sub

    Private Sub TxtAdvAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAdvAmt.TextChanged
        If TxtAdvAmt.BackColor <> Color.White And TxtAdvAmt.Text <> "" Then
            TxtAdvAmt.BackColor = Color.White
        End If
    End Sub

    
    Private Sub LstVewAdv_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewAdv.Enter
        'If LstVewAdv.SelectedItems(0).IndentCount > 0 Then
        '    MsgBox("hello")

        'End If
        ' LstVewAdv_DoubleClick(sender, e)
    End Sub

    

 
    Private Sub LstVewAdv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewAdv.KeyDown
        If e.KeyCode = Keys.Enter And LstVewAdv.SelectedItems.Count > 0 Then
            LstVewAdv_DoubleClick(sender, e)

        End If
    End Sub

    Private Sub TxtRtInt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRtInt.LostFocus
        '' ''Dim val As Integer
        '' ''val = CInt(TxtOvrTime.Text)
        '' ''If val > 0 Then
        '' ''    MsgBox(HrSalry)
        '' ''    MsgBox(TxtOvrTime.Value)
        '' ''    OvrTmSalry = TxtOvrTime.Value * HrSalry
        '' ''    MsgBox(OvrTmSalry)
        '' ''    MsgBox(EmpSalry)
        '' ''    LblEAmt.Text = FormatNumber(EmpSalry + OvrTmSalry, 2)
        '' ''    LblInst.Text = FormatNumber(EmpSalry + OvrTmSalry, 2)
        '' ''End If
        '''''''TxtOvrTime_KeyDown(sender, e)
    End Sub


End Class
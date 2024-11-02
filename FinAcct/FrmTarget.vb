Imports System.Data
Imports System.Data.SqlClient

Public Class FrmTarget

    Dim Emp_Trgt_Cmd As SqlCommand
    Dim Emp_Trgt_Rdr As SqlDataReader
    Dim Strtdt As Date
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim Deptid As Integer
    Dim EmplId As Integer
    Dim EmSrchId As Integer
    Dim add_flag As Boolean = False
    Dim Sel_Date As Date
    Dim Max_dt As Date
    Dim Empnm As String
    Dim cnfrm As String
    Dim count_recrds As Integer
    Dim FrmDt As String
    Dim ToDt As String

    Dim Payhead_Name As String
    Dim Payhead_Type As String
    Dim Phed_Calmtd As String
    Dim Ern_Deduc As String
    Dim Phed_Comp As String
    Dim PheadType As String
    Dim Phed_Formulatype As String
    Dim Phed_Id As Integer
    Dim Count_Payhead As Integer
    Dim totslab_flag As Boolean = False
    Dim LST_CNTR As Integer
    Dim BscSlry As Double
    Dim TOTSLABAMT As Double
    Dim j1, l1 As Integer
    Dim TotSlabamt1 As Double
    Dim Payhead_Name1 As String
    Dim Arr_Ern_Deduc1(100) As String
    Dim Phed_Comp1 As String
    Dim Arr_Phed_Type21(100) As String
    Dim Phed_Calmtd1 As String
    Dim Phed_Formulatype1 As String
    Dim Phed_Id1 As Integer
    Dim phed_detls As Boolean = False
    Dim arr_srateid(100) As Integer
    Dim i, p As Integer
    Dim RateId, RateId1 As Integer
    Dim Count_SlabId As Integer
    Dim UsrPhed_Amt As Double
    Dim Target_Amt As Double
    Dim ctr As Integer
    Dim BscSry_cng As Double
    Dim BscAmt, finalamt As Double
    Dim loopvar_flag As Boolean = False
    Dim Sec_Phed_id As Integer
    Dim str_PheadFormula As String
    Dim recursve_flag As Boolean = False
    Dim SlabAmt1 As Double
    Dim DiffAmt1 As Double
    Dim FromAmt1 As Double
    Dim UptoAmt1 As Double
    Dim Rateval1 As Double
    Dim Count_Slabid1 As Integer
    Dim rateid11 As Integer
    Dim arr_srateid1(100) As Integer
    Dim Rem_amt As Double
    Dim VPF_Amt As Double
    Dim VPF_Pcent, BscSlry1, result As Double
    Dim Arr_Phed_Id(100) As Integer
    Dim count As Integer = 0
    Dim no_recrd As Boolean = False
    Dim arr_phed_amt(100) As Double
  



    Private Sub FrmTarget_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Top = 0
        Me.Left = 0
        Me.Size = New System.Drawing.Point(644, 499)
        Panel1.Size = New System.Drawing.Point(612, 357)
        DtpkrTo.Location = New System.Drawing.Point(445, 218)
        fetch_MinDt()
        DtpkrDt.MinDate = Strtdt
        DtpkrDt.Text = Today
        set_frm()
        fetch_Deptnm()
        DtpkrDt.Focus()

    End Sub


    Private Sub set_frm()

        Label4.Visible = True
        txtAtrget.Visible = True
        LblQty.Visible = False
        LblRate.Visible = False
        LblTgAmt.Visible = False
        TxtQty.Visible = False
        LblMul.Visible = False
        TxtRate.Visible = False
        LblTgAmt.Visible = False
        TxtQty.Visible = False
        LblEql.Visible = False
        LblTrAmt.Visible = False
        LblRs2.Visible = False
        txtAtrget.Location = New System.Drawing.Point(145, 178)
        Label4.Location = New System.Drawing.Point(17, 177)
        Label2.Location = New System.Drawing.Point(17, 220)
        DtpkrFrm.Location = New System.Drawing.Point(145, 220)
        Label5.Location = New System.Drawing.Point(356, 218)
        DtpkrTo.Location = New System.Drawing.Point(445, 218)
        Label3.Location = New System.Drawing.Point(17, 264)
        CmbxCalc.Location = New System.Drawing.Point(145, 273)
        Label6.Location = New System.Drawing.Point(17, 322)
        LblAtrgt.Location = New System.Drawing.Point(145, 322)
        PnlSrch.Location = New System.Drawing.Point(10, 416)
        Me.Size = New System.Drawing.Point(644, 499)
        LblRs.Location = New System.Drawing.Point(268, 322)
        Panel1.Size = New System.Drawing.Point(612, 357)
    End Sub

    Private Sub fetch_MinDt()
        Try

            Emp_Trgt_Cmd = New SqlCommand("Select costrtdt from Finactcogatemstr", FinActConn)

            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            Emp_Trgt_Rdr.Read()
            If Emp_Trgt_Rdr.HasRows = True Then
                Strtdt = Emp_Trgt_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_Rdr.Close()
            Emp_Trgt_Cmd = Nothing
        End Try
    End Sub


    Private Sub fetch_Deptnm()

        Try
            Emp_Trgt_Cmd = New SqlCommand("Select deptname,deptid from  finactDept where deptdelstatus=1 and Depttype='Dept'order by deptname", FinActConn)
            da = New SqlDataAdapter(Emp_Trgt_Cmd)
            ds = New DataSet(Emp_Trgt_Cmd.CommandText)
            da.Fill(ds)
            CmbxDept.DataSource = ds.Tables(0)
            Me.CmbxDept.ValueMember = "deptid"
            Me.CmbxDept.DisplayMember = "deptname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'CmbxEname = Nothing
        End Try


    End Sub


    Private Sub fetch_Empnm()
        Deptid = CmbxDept.SelectedValue

        Try
            Emp_Trgt_Cmd = New SqlCommand("Select empname,empid from  FinactEmpmstr where empdeptid='" & (Deptid) & "' and empdelstatus=1 order by empname", FinActConn)
            da = New SqlDataAdapter(Emp_Trgt_Cmd)
            ds = New DataSet(Emp_Trgt_Cmd.CommandText)
            da.Fill(ds)
            CmbxEname.DataSource = ds.Tables(0)
            Me.CmbxEname.ValueMember = "empid"
            Me.CmbxEname.DisplayMember = "empname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'CmbxEname = Nothing
        End Try
      


    End Sub


    Private Sub fetch_Desig()
        EmplId = CmbxEname.SelectedValue
        Try

            Emp_Trgt_Cmd = New SqlCommand("select desiname from finactDesi inner join FinactEmpmstr on FinactEmpmstr.empdesiid=finactDesi.Desiid where FinactEmpmstr.empid='" & (EmplId) & "'", FinActConn)

            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            Emp_Trgt_Rdr.Read()
            If Emp_Trgt_Rdr.HasRows = True Then
                lblDesig.Text = Emp_Trgt_Rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_Rdr.Close()
            Emp_Trgt_Cmd = Nothing
        End Try
    End Sub



    Private Sub DtpkrDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDt.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            fetch_Deptnm()
            CmbxDept.Focus()
        End If
    End Sub

    Private Sub CmbxDept_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxDept.GotFocus

        If CmbxDept.Items.Count > 0 Then
            If CmbxDept.Text = "" Then
                CmbxDept.SelectedIndex = 0
                CmbxDept.DroppedDown = True
            End If
            CmbxDept.DroppedDown = True
        End If
    End Sub

    Private Sub CmbxDept_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxDept.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            fetch_Empnm()
            If CmbxEname.Items.Count = 0 Then
                MsgBox("No record found", MsgBoxStyle.Information, "Employee Name")
                CmbxDept.Focus()
            Else
                CmbxEname.Focus()
            End If
        End If
    End Sub

    Private Sub CmbxEname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEname.GotFocus

        If CmbxEname.Items.Count > 0 Then
            If CmbxEname.Text = "" Then
                CmbxEname.SelectedIndex = 0
            End If
            CmbxEname.DroppedDown = True
        End If
    End Sub

    Private Sub CmbxEname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEname.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            LblEid.Text = CmbxEname.SelectedValue
            fetch_Desig()
            RbAmt.Checked = True
            txtAtrget.Focus()
        End If
    End Sub

    Private Sub txtAtrget_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAtrget.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            If txtAtrget.Text = "" Then
                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                txtAtrget.BackColor = Color.PapayaWhip
                txtAtrget.Focus()
            Else
                DtpkrFrm.Focus()
            End If
        End If
    End Sub


    Private Sub DtpkrFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrFrm.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            DtpkrTo.MinDate = DtpkrFrm.Value.Date
            DtpkrTo.Focus()
        End If
    End Sub

    Private Sub DtpkrTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrTo.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            If DtpkrTo.Value.Date < DtpkrFrm.Value.Date Then
                MsgBox("Value should be greater than or equal to From Month", MsgBoxStyle.Information, "To Month")
                DtpkrTo.Focus()

            End If
            If BtnSave.Text = "&Save" Then
                Chek_recrds()
                If count_recrds = 0 Then
                    CmbxCalc.Focus()
                ElseIf count_recrds > 0 Then
                    MsgBox("Incentive has already been generated from " & (FrmDt) & " to " & (ToDt) & "", MsgBoxStyle.Information, "Validity")
                    DtpkrFrm.Focus()
                End If
            ElseIf BtnSave.Text = "&Edit" Then
                CmbxCalc.Focus()
            End If
        End If
    End Sub


    Private Sub Chek_recrds()
        count_recrds = 0
        Try
            ' Emp_Trgt_Cmd = New SqlCommand("select TgId from FinactempTarget where TgEmpid='" & (LblEid.Text) & "'and TgFrm>='" & (DtpkrTo.Value.Date) & "'or TgEmpid='" & (LblEid.Text) & "'and TgTo>='" & (DtpkrTo.Value.Date) & "'or TgEmpid='" & (LblEid.Text) & "'and TgFrm>='" & (DtpkrFrm.Value.Date) & "'or TgEmpid='" & (LblEid.Text) & "'and TgTo>='" & (DtpkrFrm.Value.Date) & "'", FinActConn)
            Emp_Trgt_Cmd = New SqlCommand("select TgId,TgFrm,TgTo from FinactempTarget where TgEmpid='" & (LblEid.Text) & "'and month(TgFrm)='" & Month(DtpkrFrm.Value.Date) & "'or TgEmpid='" & (LblEid.Text) & "'and month(TgFrm)='" & Month(DtpkrTo.Value.Date) & "'or TgEmpid='" & (LblEid.Text) & "'and month(TgTo)='" & Month(DtpkrFrm.Value.Date) & "'or TgEmpid='" & (LblEid.Text) & "'and month(TgTo)='" & Month(DtpkrTo.Value.Date) & "'or TgEmpid='" & (LblEid.Text) & "'and month(TgFrm)>'" & Month(DtpkrFrm.Value.Date) & "'and month(TgTo)<'" & Month(DtpkrTo.Value.Date) & "'or TgEmpid='" & (LblEid.Text) & "'and month(TgFrm)<'" & Month(DtpkrFrm.Value.Date) & "'and month(TgTo)>'" & Month(DtpkrTo.Value.Date) & "'or TgEmpid='" & (LblEid.Text) & "'and month(TgTo)>='" & Month(DtpkrTo.Value.Date) & "'and month(TgFrm)<'" & Month(DtpkrTo.Value.Date) & "'and month(TgTo)>'" & Month(DtpkrFrm.Value.Date) & "'or TgEmpid='" & (LblEid.Text) & "'and month(TgTo)<='" & Month(DtpkrTo.Value.Date) & "'and month(TgFrm)<='" & Month(DtpkrFrm.Value.Date) & "'and month(TgTo)>'" & Month(DtpkrFrm.Value.Date) & "' ", FinActConn)

            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            Emp_Trgt_Rdr.Read()
            If Emp_Trgt_Rdr.HasRows = True Then
                count_recrds = Emp_Trgt_Rdr(0)
                FrmDt = Format(Emp_Trgt_Rdr(1), "MMMM/yyyy")

                ToDt = Format(Emp_Trgt_Rdr(2), "MMMM/yyyy")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_Rdr.Close()
            Emp_Trgt_Cmd = Nothing
        End Try

    End Sub



    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click

        cnfrm = MsgBox("Are you sure to Exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrm = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub CmbxCalc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxCalc.GotFocus
        If CmbxCalc.Items.Count > 0 Then
            If CmbxCalc.Text = "" Then
                CmbxCalc.SelectedIndex = 0
            End If
            CmbxCalc.DroppedDown = True
        End If
    End Sub

    Private Sub CmbxCalc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxCalc.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            If CmbxCalc.Text = "Value" Then
                LblAmt.Text = "Amount:-"
                LblAmt.Visible = True
                TxtAmt.Visible = True
                LblRs1.Visible = True
                TxtPerc.Visible = False
                LblPercnt.Visible = False
                If RbAmt.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 218)
                ElseIf RbProd.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 239)
                End If
                CmbxPhed.Visible = False
                LblPhed.Visible = False
                TxtAmt.Focus()
            ElseIf CmbxCalc.Text = "Percentage" Then
                LblAmt.Text = "Percentage:-"
                TxtPerc.Visible = True
                LblPercnt.Visible = True
                LblAmt.Visible = True
                TxtAmt.Visible = False
                LblRs1.Visible = False
                CmbxPhed.Visible = False
                LblPhed.Visible = False
                If RbAmt.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 218)
                ElseIf RbProd.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 239)
                End If
                TxtPerc.Focus()
            ElseIf CmbxCalc.Text = "Formula" Then
                TxtPerc.Visible = False
                LblPercnt.Visible = False
                LblAmt.Visible = False
                TxtAmt.Visible = False
                LblRs1.Visible = False
                CmbxPhed.Visible = True
                LblPhed.Visible = True
                LblAmt.Visible = False
                If RbAmt.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 218)
                ElseIf RbProd.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 239)
                End If
                fetch_Phed()
                If CmbxPhed.Items.Count > 0 Then
                    CmbxPhed.Focus()
                Else
                    CmbxPhed.Visible = False
                    LblPhed.Visible = False
                    Dim Frmdt1 As String
                    FrmDt1 = Format(DtpkrFrm.Value.Date, "MMMM/yyyy")
                    MsgBox("No Payhead found which is effective from '" & (Frmdt1) & "'", MsgBoxStyle.Information, "Payhead")

                    CmbxCalc.Focus()
                End If

            End If
            End If
    End Sub

  

    Private Sub TxtAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAmt.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            If TxtAmt.Text = "" Then
                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                TxtAmt.Focus()
            Else
                BtnSave.Focus()
            End If
        End If
    End Sub

    Private Sub TxtAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAmt.Leave
        
        If TxtAmt.Text <> "" Then
            TxtAmt.Text = FormatNumber(TxtAmt.Text, 2)
            LblAtrgt.Text = FormatNumber(LblAtrgt.Text, 2)
        End If
    End Sub

    Private Sub TxtAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAmt.TextChanged
        If TxtAmt.Text <> "" Then
            LblAtrgt.Text = FormatNumber(CDbl(TxtAmt.Text), 2)
        End If
    End Sub

    Private Sub TxtPerc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPerc.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            If TxtPerc.Text = "" Then
                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                TxtPerc.Focus()
            Else
                ' TxtPerc_TextChanged(sender, e)
                BtnSave.Focus()
            End If
        End If
    End Sub

    Private Sub TxtPerc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPerc.TextChanged
        If RbAmt.Checked = True Then
            If TxtPerc.Text <> "" Then
                LblAtrgt.Text = FormatNumber((CDbl(TxtPerc.Text) * CDbl(txtAtrget.Text)) / 100, 2)
            End If
        ElseIf RbProd.Checked = True Then
            If TxtPerc.Text <> "" Then
                LblAtrgt.Text = FormatNumber((CDbl(TxtPerc.Text) * CDbl(LblTrAmt.Text)) / 100, 2)
            End If
        End If
       
    End Sub
    Private Sub Clrval()
        DtpkrDt.Text = Today
        If CmbxDept.SelectedIndex > 0 Then
            CmbxDept.SelectedIndex = 0
        End If
        If CmbxEname.SelectedIndex > 0 Then
            CmbxEname.SelectedIndex = 0
        End If
        lblDesig.Text = ""
        txtAtrget.Clear()
        LblAtrgt.Text = ""
        TxtQty.Clear()
        TxtRate.Clear()
        LblTrAmt.Text = ""
        TxtPerc.Text = ""
        RbProd.Checked = False
        RbAmt.Checked = False

        CmbxPhed.Visible = False
        LblPhed.Visible = False
        If CmbxPhed.SelectedIndex > 0 Then
            CmbxPhed.SelectedIndex = 0

        End If
        TxtPerc.Visible = False
        LblPercnt.Visible = False
        LblAmt.Visible = False
        TxtAmt.Visible = False
        LblRs1.Visible = False
        Me.Size = New System.Drawing.Point(644, 499)
        Panel1.Size = New System.Drawing.Point(612, 357)
        PnlSrch.Visible = False
        LstTrgt.Visible = False
        Lblheding.Visible = False
        Panel1.Enabled = True
        DtpkrDt.Enabled = True
        BtnFnd.Text = "&Find"
        BtnSave.Text = "&Save"
        CmbxDept.Enabled = True
        LblEmpnm.Visible = False
        CmbxEname.Visible = True
        CmbxEname.Enabled = True
        LblEid.Text = ""
        BtnSave.Enabled = True
        BtnFnd.Enabled = True
        set_frm()

        DtpkrDt.Focus()
    End Sub
    
    Private Sub BtnCancl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancl.Click

        Clrval()

    End Sub

    Private Sub fetch_Phed()

        Try
            Emp_Trgt_Cmd = New SqlCommand("Select Pheadname,Pheadid from  FinactPayHead where PheadDelstatus=0 and PheadType='Incentive'and month(PhEfecdt)<='" & (Month(DtpkrFrm.Value.Date)) & "'and year(PhEfecdt)<='" & (Year(DtpkrFrm.Value.Date)) & "' order by PheadName", FinActConn)
            da = New SqlDataAdapter(Emp_Trgt_Cmd)
            ds = New DataSet(Emp_Trgt_Cmd.CommandText)
            da.Fill(ds)
            CmbxPhed.DataSource = ds.Tables(0)
            Me.CmbxPhed.ValueMember = "Pheadid"
            Me.CmbxPhed.DisplayMember = "Pheadname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'CmbxEname = Nothing
        End Try


    End Sub

    Private Sub CmbxPhed_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxPhed.GotFocus
        If CmbxPhed.Items.Count > 0 Then
            If CmbxPhed.Text = "" Then
                CmbxPhed.SelectedValue = 0
            End If
            CmbxPhed.DroppedDown = True
        End If
    End Sub

    Private Sub CmbxPhed_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxPhed.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            Fetch_Payhead_Name()
            BtnSave.Focus()

        End If
    End Sub


    Private Sub Fetch_Payhead_Name()

        Dim list_add As Boolean

        Try
            Emp_Trgt_Cmd = New SqlCommand("select PheadName,PheadCalmtd,PheadComp ,PheadType,PhFormulatype,PheadId from FinactPayHead where PheadDelstatus=0 and PheadName='" & (CmbxPhed.Text) & "'", FinActConn)
            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            Emp_Trgt_Rdr.Read()
            If Emp_Trgt_Rdr.HasRows = True Then
                Payhead_Name = Emp_Trgt_Rdr(0)
                Payhead_Type = Emp_Trgt_Rdr(1)
                Phed_Calmtd = Emp_Trgt_Rdr(1)
                Ern_Deduc = Emp_Trgt_Rdr(2)
                Phed_Comp = Emp_Trgt_Rdr(2)
                PheadType = Emp_Trgt_Rdr(3)
                Phed_Formulatype = Emp_Trgt_Rdr(4)
                Phed_Id = Emp_Trgt_Rdr(5)
                list_add = True

                'ElseIf Emp_Trgt_rdr.HasRows = False Then
                '    list_add = False
                '    Count_Payhead = Count_Payhead + 1

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_Rdr.Close()
            Emp_Trgt_Cmd = Nothing
        End Try

        If list_add = True Then
            totslab_flag = False
            Fetch_Payhead_Amt()
        End If


    End Sub


    Private Sub Fetch_Payhead_Amt()

        ' BscSlry = CDbl(LblBscSlry.Text)
        Dim res As Double = 0.0
        Dim counter As Integer = 0
        If Phed_Calmtd = "As Computed Value" Or Phed_Calmtd = "on Production/Performance value" Then
            If Phed_Comp = "On Basic" Then
                Fetch_Slab_RateId()
                Fetch_slabrate()
            ElseIf Phed_Comp = "On Specified Formula" Then
                If Phed_Formulatype = "Compound(stepwise)" Or Phed_Formulatype = "Flat Rate" Then
                    Dim Rateval, RateId1 As Integer
                    Dim FromAmt, UptoAmt, SlabAmt, DiffAmt As Double
                    ' Dim LstPayhed As ListViewItem
                    Dim recrd_flag As Boolean
                    TotSlabAmt = 0
                    Dim Arr_Pay_Type(100) As String
                    Dim Arr_PhedId(100), Arr_PFId(100) As Integer
                    Dim m As Integer
                    m = 0
                    Try
                        '  Loan_Salry_Cmd = New SqlCommand("select EmpPayHeadName,EmpPayType from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (Phed_Id) & "'", FinActConn)
                        Emp_Trgt_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PayheadConId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (Phed_Id) & "' ", FinActConn)
                        Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                        While Emp_Trgt_Rdr.Read()
                            If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                Arr_PFId(m) = Emp_Trgt_Rdr(0)
                                Arr_Pay_Type(m) = Emp_Trgt_Rdr(1)
                                Arr_PhedId(m) = Emp_Trgt_Rdr(2)

                            End If
                            m = m + 1
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Emp_Trgt_Rdr.Close()
                        Emp_Trgt_Cmd = Nothing
                    End Try

                    Dim contr As Integer = 0
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&Recursive begin------------------------------------
                    While contr < m
                        counter = 0
                        j1 = 0
                        l1 = 0
                        TotSlabAmt1 = 0
                        Try
                            Emp_Trgt_Cmd = New SqlCommand("select PheadName,PheadComp,PheadType,PheadCalmtd,PhFormulatype,PheadId from FinactPayHead where PheadDelstatus=0 and PheadId='" & (Arr_PFId(contr)) & " '", FinActConn) 'and PheadCalmtd<>'As User Defined Value'", FinActConn)
                            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                            Emp_Trgt_Rdr.Read()
                            If Emp_Trgt_Rdr.HasRows = True Then
                                Payhead_Name1 = Emp_Trgt_Rdr(0)
                                Arr_Ern_Deduc1(j1) = Emp_Trgt_Rdr(1)
                                Phed_Comp1 = Emp_Trgt_Rdr(1)
                                Arr_Phed_Type21(l1) = Emp_Trgt_Rdr(2)
                                Phed_Calmtd1 = Emp_Trgt_Rdr(3)
                                Phed_Formulatype1 = Emp_Trgt_Rdr(4)
                                Phed_Id1 = Emp_Trgt_Rdr(5)
                                j1 = j1 + 1
                                l1 = l1 + 1
                            End If '--
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Emp_Trgt_Rdr.Close()
                            Emp_Trgt_Cmd = Nothing
                        End Try
                        If Phed_Calmtd1 = "As Computed Value" Or Phed_Calmtd1 = "on Production/Performance value" Then
                            phed_detls = True
                            If Phed_Comp1 = "On Basic" Then
                                Fetch_Slab_RateId()
                                Fetch_SrateId()
                                Fetch_SrateId1()
                                '--------Fetch_slabrate()
                                Rateval = 0
                                RateId1 = 0
                                FromAmt = 0
                                UptoAmt = 0

                                SlabAmt = 0
                                DiffAmt = 0
                                counter = 0
                                recrd_flag = False
                                Dim extsub_flag As Boolean = False
                                TotSlabAmt = 0
                                i = 0
                                While counter < Count_SlabId
                                    If phed_detls = False Then
                                        Try
                                            Emp_Trgt_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0 and SrateId='" & (arr_srateid(i)) & "'", FinActConn)
                                            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                            Emp_Trgt_Rdr.Read()
                                            If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                                recrd_flag = True
                                                RateId1 = Emp_Trgt_Rdr(0)
                                                FromAmt = Emp_Trgt_Rdr(1)
                                                If Emp_Trgt_Rdr(2) <> "Above" Then
                                                    UptoAmt = Emp_Trgt_Rdr(2)
                                                Else
                                                    UptoAmt = 9999999999999
                                                End If
                                                Rateval = Emp_Trgt_Rdr(3)
                                            End If

                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        Finally
                                            If Emp_Trgt_Rdr.IsDBNull(0) = True Then
                                                recrd_flag = False
                                            End If
                                            Emp_Trgt_Rdr.Close()
                                            Emp_Trgt_Cmd = Nothing
                                        End Try
                                    ElseIf phed_detls = True Then
                                        Try
                                            Emp_Trgt_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 and SrateId ='" & (arr_srateid1(i)) & "'", FinActConn)
                                            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                            Emp_Trgt_Rdr.Read()
                                            If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                                recrd_flag = True
                                                rateid11 = Emp_Trgt_Rdr(0)
                                                FromAmt = Emp_Trgt_Rdr(1)
                                                If Emp_Trgt_Rdr(2) <> "Above" Then
                                                    UptoAmt = Emp_Trgt_Rdr(2)
                                                Else
                                                    UptoAmt = 9999999999999
                                                End If
                                                Rateval = Emp_Trgt_Rdr(3)
                                            End If
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        Finally
                                            If Emp_Trgt_Rdr.IsDBNull(0) = True Then
                                                recrd_flag = False
                                            End If
                                            Emp_Trgt_Rdr.Close()
                                            Emp_Trgt_Cmd = Nothing
                                        End Try
                                    End If
                                    'If BscSlry <> "" Then
                                    '    'BscSlry = CDbl(LblBscSlry.Text)
                                    BscSlry = CDbl(BscSlry)
                                    If UptoAmt = 9999999999999 Then
                                        UptoAmt = BscSlry
                                    End If
                                    'End If
                                    If UptoAmt > BscSlry And Phed_Formulatype1 <> "Achieved Target" Then
                                        UptoAmt = BscSlry
                                    End If
                                    If Phed_Formulatype1 = "Compound(stepwise)" Then
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
                                    ElseIf Phed_Formulatype1 = "Flat Rate" Then
                                        If BscSlry <= UptoAmt And BscSlry >= FromAmt Then
                                            TotSlabAmt = 0
                                            SlabAmt = FormatNumber((BscSlry * Rateval) / 100, 2)
                                            TotSlabAmt = SlabAmt
                                            TotSlabAmt = CDbl(TotSlabAmt)
                                        End If
                                    ElseIf Phed_Formulatype1 = "Achieved Target" Then
                                        If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                                            TotSlabAmt = 0
                                            SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                                            TotSlabAmt = CDbl(SlabAmt)
                                        End If
                                    ElseIf Phed_Formulatype1 = "Earned Amount" Then
                                        If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                                            TotSlabAmt = 0
                                            SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                                            TotSlabAmt = CDbl(SlabAmt)
                                        End If
                                    End If
                                    If phed_detls = False Then
                                        RateId = RateId + 1
                                    ElseIf phed_detls = True Then
                                        RateId11 = RateId11 + 1
                                    End If
                                    counter = counter + 1
                                    extsub_flag = True
                                    i = i + 1
                                End While
                                If counter = Count_SlabId Then
                                    ' Dim LstPayhed1 As ListViewItem
                                    TotSlabAmt = FormatNumber(TotSlabAmt, 2)
                                    If recrd_flag = True And extsub_flag <> True Then
                                        LblAtrgt.Text = FormatNumber(TOTSLABAMT, 2)
                                    ElseIf recrd_flag = False And extsub_flag <> True Then
                                        LblAtrgt.Text = FormatNumber(TOTSLABAMT, 2)
                                    End If
                                    'If extsub_flag <> True Then
                                    '    LstPayhed1.SubItems.Add(Payhead_Name)
                                    '    LstPayhed1.SubItems.Add(Payhead_Type)
                                    '    LstPayhed1.SubItems.Add(Ern_Deduc)
                                    '    If Payhead_Type = "As User Defined Value" Then
                                    '        LstPayhed1.SubItems.Add("Not Edit")
                                    '    Else
                                    '        LstPayhed1.SubItems.Add("Edit")
                                    '    End If
                                    '    LstPayhed1.SubItems.Add(PheadType)
                                    '    LstPayhed1.SubItems.Add(Phed_Id)
                                    'End If
                                    'End If
                                End If
                                '''''''''''''''''''''''''''''contr = contr + 1
                            ElseIf Phed_Comp1 = "On Specified Formula" Then
                                Dim m1 As Integer
                                Dim loopvar As Integer = 0
                                Dim Target_Amt1 As Double = 0.0
                                Dim Arr_Pay_Type1(100) As String
                                Dim Arr_PhedId1(100), Arr_PFId1(100) As Integer
                                If Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Or Phed_Formulatype1 = "Achieved Target" Or Phed_Formulatype1 = "Earned Amount" Then
                                    If Phed_Formulatype1 <> "Achieved Target" And Phed_Formulatype1 <> "Earned Amount" Then
                                        TotSlabAmt1 = 0

                                        m1 = 0
                                        Try
                                            Emp_Trgt_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PheadId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (Phed_Id1) & "'", FinActConn)
                                            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                            While Emp_Trgt_Rdr.Read()
                                                If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                                    Arr_PFId1(m1) = Emp_Trgt_Rdr(0)
                                                    Arr_Pay_Type1(m1) = Emp_Trgt_Rdr(1)
                                                    Arr_PhedId1(m1) = Emp_Trgt_Rdr(2)

                                                End If
                                                m1 = m1 + 1
                                            End While
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        Finally
                                            Emp_Trgt_Rdr.Close()
                                            Emp_Trgt_Cmd = Nothing
                                        End Try
                                        TotSlabAmt1 = 0
                                    End If
                                    If Phed_Formulatype1 = "Achieved Target" Or Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Or Phed_Formulatype1 = "Earned Amount" Then
                                        If Phed_Formulatype1 = "Achieved Target" Then
                                            ' Arr_PhedId(loopvar) = Phed_Id1
                                            Arr_PFId(loopvar) = Phed_Id1
                                            m1 = 1
                                            Try
                                                Emp_Trgt_Cmd = New SqlCommand("select Amt from Finact_Target where EId='" & (EmplId) & "'", FinActConn)
                                                Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                                Emp_Trgt_Rdr.Read()
                                                If Emp_Trgt_Rdr.HasRows = True Then
                                                    Target_Amt1 = CDbl(Emp_Trgt_Rdr(0))
                                                End If
                                            Catch ex As Exception
                                                MsgBox(ex.Message)
                                            Finally
                                                If Emp_Trgt_Rdr.HasRows = False Then
                                                    Target_Amt1 = CDbl(0)
                                                End If
                                                Emp_Trgt_Rdr.Close()
                                                Emp_Trgt_Cmd = Nothing
                                            End Try
                                        End If
                                        If Phed_Formulatype1 = "Earned Amount" Then
                                            'Arr_PhedId(loopvar) = Phed_Id1
                                            Arr_PFId(loopvar) = Phed_Id1
                                            m1 = 1
                                            Target_Amt1 = CDbl(BscSlry)
                                        End If


                                        While loopvar < m1
                                            If Phed_Formulatype1 = "Earned Amount" Or Phed_Formulatype1 = "Achieved Target" Then

                                                Try
                                                    Emp_Trgt_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                                    Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                                    Emp_Trgt_Rdr.Read()
                                                    If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                                        Count_Slabid1 = Emp_Trgt_Rdr(0)
                                                    End If
                                                Catch ex As Exception
                                                    MsgBox(ex.Message)
                                                Finally
                                                    Emp_Trgt_Rdr.Close()
                                                    Emp_Trgt_Cmd = Nothing
                                                End Try
                                                If Count_SlabId1 > 0 Then
                                                    Try
                                                        Emp_Trgt_Cmd = New SqlCommand("select SrateId from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                                        Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                                        Emp_Trgt_Rdr.Read()
                                                        If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                                            rateid11 = Emp_Trgt_Rdr(0)
                                                        End If
                                                    Catch ex As Exception
                                                        MsgBox(ex.Message)
                                                    Finally
                                                        Emp_Trgt_Rdr.Close()
                                                        Emp_Trgt_Cmd = Nothing
                                                    End Try
                                                End If

                                                While counter < Count_SlabId1

                                                    Try
                                                        Emp_Trgt_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Arr_PFId(loopvar)) & "'and PheadDelstatus=0 and SrateId='" & (rateid11) & "'", FinActConn)
                                                        Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                                        Emp_Trgt_Rdr.Read()
                                                        If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                                            rateid11 = Emp_Trgt_Rdr(0)
                                                            FromAmt1 = Emp_Trgt_Rdr(1)
                                                            If Emp_Trgt_Rdr(2) <> "Above" Then
                                                                UptoAmt1 = Emp_Trgt_Rdr(2)
                                                            Else
                                                                UptoAmt1 = 9999999999999
                                                            End If

                                                            Rateval1 = Emp_Trgt_Rdr(3)
                                                        End If

                                                    Catch ex As Exception
                                                        MsgBox(ex.Message)
                                                    Finally
                                                        If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                                            recrd_flag = True
                                                        ElseIf Emp_Trgt_Rdr.IsDBNull(0) = True Then
                                                            recrd_flag = False
                                                        End If
                                                        Emp_Trgt_Rdr.Close()
                                                        Emp_Trgt_Cmd = Nothing
                                                    End Try
                                                    'If LblBscSlry.Text <> "" Then
                                                    '  BscSlry1 = CDbl(LblBscSlry.Text)
                                                    BscSlry = CDbl(BscSlry)
                                                    If UptoAmt1 = 9999999999999 Then
                                                        UptoAmt1 = BscSlry
                                                    End If

                                                    'End If
                                                    If UptoAmt1 > BscSlry And Phed_Formulatype1 <> "Achieved Target" Then
                                                        UptoAmt1 = BscSlry
                                                    End If
                                                    If Phed_Formulatype1 = "Compound(stepwise)" Then
                                                        If FromAmt1 = 0 Then
                                                            DiffAmt1 = (UptoAmt1 - FromAmt1)
                                                        ElseIf FromAmt > 0 Then
                                                            DiffAmt1 = (UptoAmt1 - FromAmt1) + 1
                                                        End If
                                                        If FromAmt <= BscSlry Then
                                                            SlabAmt1 = FormatNumber((DiffAmt1 * Rateval1) / 100, 2)
                                                            TotSlabAmt1 = TotSlabAmt1 + SlabAmt1
                                                            TotSlabAmt1 = CDbl(TotSlabAmt1)
                                                        End If
                                                    ElseIf Phed_Formulatype1 = "Flat Rate" Then
                                                        If BscSlry <= UptoAmt1 And BscSlry >= FromAmt1 Then
                                                            TotSlabAmt1 = 0
                                                            SlabAmt1 = FormatNumber((BscSlry * Rateval1) / 100, 2)
                                                            TotSlabAmt1 = SlabAmt1
                                                            TotSlabAmt1 = CDbl(TotSlabAmt1)
                                                        End If
                                                    ElseIf Phed_Formulatype1 = "Achieved Target" Then
                                                        If Target_Amt1 <= UptoAmt1 And Target_Amt1 >= FromAmt1 Then
                                                            TotSlabAmt1 = 0
                                                            SlabAmt1 = FormatNumber(Target_Amt1 * Rateval1 / 100, 2)
                                                            TotSlabAmt1 = CDbl(SlabAmt1)
                                                        End If
                                                    ElseIf Phed_Formulatype1 = "Earned Amount" Then
                                                        If Target_Amt1 <= UptoAmt1 And Target_Amt1 >= FromAmt1 Then
                                                            TotSlabAmt1 = 0
                                                            SlabAmt1 = FormatNumber(Target_Amt1 * Rateval1 / 100, 2)
                                                            TotSlabAmt1 = CDbl(SlabAmt1)
                                                        End If
                                                    End If
                                                    TotSlabAmt = TotSlabAmt1
                                                    RateId11 = RateId11 + 1
                                                    RateId = RateId + 1
                                                    counter = counter + 1
                                                End While
                                            ElseIf Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Then
                                                'Arr_PhedId(loopvar) = Phed_Id1
                                                Arr_PFId(loopvar) = Phed_Id1
                                                Sec_Phed_id = Phed_Id1
                                                str_PheadFormula = Phed_Formulatype1
                                                ' recfun_payhead(Payhead_Name1, Phed_Id1)
                                                recursve_flag = False
                                                Phed_Formulatype1 = str_PheadFormula
                                                m1 = 1
                                            End If

                                            loopvar += 1
                                            If loopvar = m1 Then
                                                loopvar_flag = True
                                                totslab_flag = True
                                                phed_detls = True
                                                'If Phed_Formulatype1 <> "Achieved Target" And Phed_Formulatype1 <> "Earned Amount" Then
                                                '    BscAmt = CDbl(TotSlabAmt)
                                                '    finalamt = BscSlry - BscAmt
                                                '    BscAmt = CDbl(finalamt)
                                                '    Fetch_Slab_RateId()
                                                '    Fetch_slabrate()
                                                'End If
                                            End If
                                        End While 'lop[






                                    End If 'COME()
                                End If
                                '''''''''''''''''''''contr = contr + 1
                            End If
                        ElseIf Phed_Calmtd1 = "As User Defined Value" Then 'USER---------------


                            Fetch_UsrPhed_Amt1()
                            TotSlabAmt = UsrPhed_Amt

                            '    End If
                            '        j += 1
                            'End While
                            ' End If
                        End If


                        'If LblBscSlry.Text <> "" Then
                        ' BscSlry = CDbl(LblBscSlry.Text)
                        BscSlry = CDbl(BscSlry)
                        ' End If
                        If contr = m Then
                            totslab_flag = True
                            phed_detls = False
                            BscAmt = CDbl(TotSlabAmt)
                            finalamt = BscSlry - BscAmt
                            BscAmt = CDbl(finalamt)
                            Fetch_Slab_RateId()
                            Fetch_slabrate()
                        End If
                        If Trim(Arr_Pay_Type(contr)) = Trim("Add") Then
                            If contr = 0 Then
                                res = BscSlry + TotSlabAmt
                            ElseIf contr <> 0 Then
                                res += TotSlabAmt
                            End If
                        ElseIf Trim(Arr_Pay_Type(contr)) = Trim("Minus") Then
                            If contr = 0 Then
                                res = BscSlry - TotSlabAmt
                            ElseIf contr <> 0 Then
                                res -= TotSlabAmt
                            End If
                            '
                        End If
                        contr = contr + 1
                    End While 'main while
                    phed_detls = False
                    BscSlry = res
                    BscSry_cng = res
                    totslab_flag = True
                    Fetch_Slab_RateId()
                    Fetch_slabrate()

                ElseIf Phed_Formulatype = "Achieved Target" Then
                    If RbAmt.Checked = True Then
                        If txtAtrget.Text <> "" Then
                            Target_Amt = CDbl(txtAtrget.Text)
                        End If
                    ElseIf RbProd.Checked = True Then
                        If LblTrAmt.Text <> "" Then
                            Target_Amt = CDbl(LblTrAmt.Text)
                        End If
                    End If


                    'Try
                    '    Emp_Trgt_Cmd = New SqlCommand("select Amt from Finact_Target where EId='" & (EmplId) & "'", FinActConn)
                    '    Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                    '    Emp_Trgt_Rdr.Read()
                    '    If Emp_Trgt_Rdr.HasRows = True Then
                    '        Target_Amt = CDbl(Emp_Trgt_Rdr(0))
                    '        ctr = ctr + 1
                    '    End If
                    'Catch ex As Exception
                    '    MsgBox(ex.Message)
                    'Finally
                    '    If Emp_Trgt_Rdr.HasRows = False Then
                    '        Target_Amt = CDbl(0)
                    '    End If
                    '    Emp_Trgt_Rdr.Close()
                    '    Emp_Trgt_Cmd = Nothing
                    'End Try
                    Fetch_Slab_RateId()
                    Fetch_slabrate()
                    p = p + 1

                ElseIf Phed_Formulatype = "Earned Amount" Then

                    Target_Amt = CDbl(BscSlry)
                    Fetch_Slab_RateId()
                    Fetch_slabrate()
                    p = p + 1
                    ' End If
                End If
            End If

        ElseIf Phed_Calmtd = "As User Defined Value" Then
            Fetch_UsrPhed_Amt()
            TotSlabAmt = FormatNumber(UsrPhed_Amt, 2)
            LblAtrgt.Text = FormatNumber(CDbl(TOTSLABAMT), 2)
            'Dim j As Integer = 0
            'Dim lstpay As ListViewItem
            'If Datagrdusrdef.Rows.Count > 0 Then
            '    While j < Datagrdusrdef.Rows.Count
            '        If Datagrdusrdef.Rows(j).Cells(0).Value = Payhead_Name Then
            '            TotSlabAmt = Datagrdusrdef.Rows(j).Cells(1).Value
            '            Exit While
            '        End If
            '        j += 1
            '    End While
            '    lstpay = LstvewPhed.Items.Add(TotSlabAmt)
            '    lstpay.SubItems.Add(Payhead_Name)
            '    lstpay.SubItems.Add(Payhead_Type)
            '    lstpay.SubItems.Add(Ern_Deduc)
            '    lstpay.SubItems.Add("Not Edit")
            '    lstpay.SubItems.Add(PheadType)
            '    lstpay.SubItems.Add(Phed_Id)
            'End If
        End If
    End Sub



    Private Sub Count_Slab_RateId()
        If phed_detls = True Then
            Try
                Emp_Trgt_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and  PheadDelstatus=0 and PheadId='" & (Phed_Id1) & "'", FinActConn)
                Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                Emp_Trgt_Rdr.Read()
                If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                    Count_SlabId = Emp_Trgt_Rdr(0)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Emp_Trgt_Rdr.Close()
                Emp_Trgt_Cmd = Nothing
            End Try
        ElseIf phed_detls = False Then
            Try
                Emp_Trgt_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and  PheadDelstatus=0 and PheadId='" & (Phed_Id) & "'", FinActConn)
                Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                Emp_Trgt_Rdr.Read()
                If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                    Count_SlabId = Emp_Trgt_Rdr(0)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Emp_Trgt_Rdr.Close()
                Emp_Trgt_Cmd = Nothing
            End Try
        End If


    End Sub




    Private Sub Fetch_Slab_RateId()

        Count_Slab_RateId()
        If phed_detls = True Then
            If Count_SlabId > 0 Then
                Try
                    Emp_Trgt_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0", FinActConn)
                    Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                    Emp_Trgt_Rdr.Read()
                    If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                        rateid11 = Emp_Trgt_Rdr(0)

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Emp_Trgt_Rdr.Close()
                    Emp_Trgt_Cmd = Nothing
                End Try
            End If
        ElseIf phed_detls = False Then
            If Count_SlabId > 0 Then
                Try
                    Emp_Trgt_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0", FinActConn)
                    Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                    Emp_Trgt_Rdr.Read()
                    If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                        RateId = Emp_Trgt_Rdr(0)

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Emp_Trgt_Rdr.Close()
                    Emp_Trgt_Cmd = Nothing
                End Try
            End If
        End If

    End Sub

    Private Sub Fetch_SrateId()
        i = 0
        Try
            Emp_Trgt_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0 ", FinActConn)
            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            While Emp_Trgt_Rdr.Read()
                If Emp_Trgt_Rdr.HasRows = True Then
                    arr_srateid(i) = Emp_Trgt_Rdr(0)
                    i = i + 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'If Loan_Salry_Rdr.IsDBNull(0) = False Then
            'recrd_flag = True
            'Else'

            Emp_Trgt_Rdr.Close()
            Emp_Trgt_Cmd = Nothing
        End Try

    End Sub


    Private Sub Fetch_SrateId1()
        i = 0
        Try
            Emp_Trgt_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 ", FinActConn)
            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            While Emp_Trgt_Rdr.Read()
                If Emp_Trgt_Rdr.HasRows = True Then
                    arr_srateid1(i) = Emp_Trgt_Rdr(0)
                    i = i + 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'If Loan_Salry_Rdr.IsDBNull(0) = False Then
            'recrd_flag = True
            'Else'

            Emp_Trgt_rdr.Close()
            Emp_Trgt_Cmd = Nothing
        End Try

    End Sub


    Private Sub Fetch_slabrate()
        'Fetch_BscSlry()
        Dim Rateval As Double
        Dim RateId1 As Integer
        Dim FromAmt, UptoAmt, SlabAmt, DiffAmt As Double
        Dim counter As Integer = 0
        'Dim LstPayhed As ListViewItem
        Dim recrd_flag As Boolean
        Dim extsub_flag As Boolean = False
        Dim Rem_flag As Boolean = False
        TotSlabAmt = 0
        Fetch_SrateId()
        Fetch_SrateId1()
        i = 0
        While counter < Count_SlabId
            If phed_detls = False Then
                Try
                    Emp_Trgt_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0 and SrateId='" & (arr_srateid(i)) & "'", FinActConn)
                    Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                    Emp_Trgt_Rdr.Read()
                    If Emp_Trgt_Rdr.HasRows = True Then
                        recrd_flag = True
                        RateId1 = Emp_Trgt_Rdr(0)
                        FromAmt = Emp_Trgt_rdr(1)
                        If Emp_Trgt_Rdr(2) <> "Above" Then
                            UptoAmt = Emp_Trgt_Rdr(2)
                        Else
                            UptoAmt = 9999999999999
                        End If
                        Rateval = Emp_Trgt_Rdr(3)
                    End If
                    If counter = 0 Then
                        ' If all_flag = False Then
                        If BscSlry > UptoAmt And PheadType = "DEEmpPF" Then
                            Rem_amt = CDbl(BscSlry) - UptoAmt
                            Rem_flag = True
                        End If
                        'ElseIf all_flag = True Then
                        '    If arr_ernamt(cntr) > UptoAmt And Phed_type2 = "DEEmpPF" Then

                        '        Rem_Amt = CDbl(arr_ernamt(cntr)) - UptoAmt
                        '        Rem_flag = True
                        '    End If
                        'End If

                    End If


                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    'If Loan_Salry_Rdr.IsDBNull(0) = False Then
                    'recrd_flag = True
                    'Else'
                    If Emp_Trgt_Rdr.HasRows = False Then

                        recrd_flag = False
                    End If
                    Emp_Trgt_Rdr.Close()
                    Emp_Trgt_Cmd = Nothing
                End Try
            ElseIf phed_detls = True Then
                Try
                    Emp_Trgt_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 and SrateId='" & (arr_srateid1(i)) & "'", FinActConn)
                    Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                    Emp_Trgt_Rdr.Read()
                    If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                        recrd_flag = True
                        rateid11 = Emp_Trgt_Rdr(0)
                        FromAmt = Emp_Trgt_Rdr(1)
                        If Emp_Trgt_Rdr(2) <> "Above" Then
                            UptoAmt = Emp_Trgt_Rdr(2)
                        Else
                            UptoAmt = 9999999999999
                        End If
                        Rateval = Emp_Trgt_Rdr(3)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    'If Loan_Salry_Rdr.IsDBNull(0) = False Then
                    'recrd_flag = True
                    'Else'
                    If Emp_Trgt_Rdr.IsDBNull(0) = True Then
                        recrd_flag = False
                    End If
                    Emp_Trgt_Rdr.Close()
                    Emp_Trgt_Cmd = Nothing
                End Try
            End If
            'If LblBscSlry.Text <> "" Then
            If (phed_detls = False Or recursve_flag = True) And totslab_flag = True Then
                BscSlry = BscSry_cng
            Else
                ' BscSlry = CDbl(LblBscSlry.Text)
                If RbAmt.Checked = True Then
                    If txtAtrget.Text <> "" Then
                        BscSlry = CDbl(txtAtrget.Text)
                    End If
                ElseIf RbProd.Checked = True Then
                    If LblTrAmt.Text <> "" Then
                        BscSlry = CDbl(LblTrAmt.Text)
                    End If
                End If


                If UptoAmt = 9999999999999 Then
                    UptoAmt = BscSlry
                End If
                '________________
                'BscSlry = BscAmt
                'extsub_flag = True
            End If
            'ElseIf all_flag = True Then
            '    If (phed_detls = False Or recursve_flag = True) And totslab_flag = True Then
            '        extsub_flag = False
            '        BscSlry = BscSry_cng 'BscAmt
            '    Else
            '        BscSlry = arr_ernamt(cntr)
            '    End If
            '    If UptoAmt = 9999999999999 Then
            '        UptoAmt = BscSlry
            '    End If
            'End If
            If UptoAmt > BscSlry And Phed_Formulatype <> "Achieved Target" Then
                UptoAmt = BscSlry
            End If
            If phed_detls = False Then
                If Phed_Formulatype = "Compound(stepwise)" Then
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
                ElseIf Phed_Formulatype = "Flat Rate" Then
                    If BscSlry <= UptoAmt And BscSlry >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = FormatNumber((BscSlry * Rateval) / 100, 2)
                        TotSlabAmt = SlabAmt
                        TotSlabAmt = CDbl(TotSlabAmt)
                    End If
                ElseIf Phed_Formulatype = "Achieved Target" Then
                    If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                        TotSlabAmt = CDbl(SlabAmt)
                    End If
                ElseIf Phed_Formulatype = "Earned Amount" Then
                    If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                        TotSlabAmt = CDbl(SlabAmt)
                    End If
                End If
            ElseIf phed_detls = True Then
                If Phed_Formulatype1 = "Compound(stepwise)" Then
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
                ElseIf Phed_Formulatype1 = "Flat Rate" Then
                    If BscSlry <= UptoAmt And BscSlry >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = CDbl(FormatNumber((BscSlry * Rateval) / 100, 2))
                        TotSlabAmt = SlabAmt
                        TotSlabAmt = CDbl(TotSlabAmt)
                    End If
                ElseIf Phed_Formulatype1 = "Achieved Target" Then
                    If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                        TotSlabAmt = CDbl(SlabAmt)
                    End If
                ElseIf Phed_Formulatype1 = "Earned Amount" Then
                    If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                        TotSlabAmt = 0
                        SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                        TotSlabAmt = CDbl(SlabAmt)
                    End If
                End If
            End If
            If phed_detls = False Then
                RateId = RateId + 1
            ElseIf phed_detls = True Then
                RateId11 = RateId11 + 1
            End If

            i = i + 1
            counter = counter + 1

        End While
        If extsub_flag = True Then
            extsub_flag = False
            Exit Sub
        End If
        If counter = Count_SlabId Then
            'And BscSlry > UptoAmt Then

            'If Phed_Formulatype = "Compound(stepwise)" Then
            '    DiffAmt = (BscSlry - UptoAmt)
            '    SlabAmt = FormatNumber((DiffAmt * Rateval) / 100, 2)
            '    TotSlabAmt = TotSlabAmt + SlabAmt
            'ElseIf Phed_Formulatype = "Flat Rate" Then
            '    TotSlabAmt = 0
            '    SlabAmt = FormatNumber((BscSlry * Rateval) / 100, 2)
            '    TotSlabAmt = TotSlabAmt + SlabAmt
            '    TotSlabAmt = CDbl(TotSlabAmt)
            'End If

            'If loopvar_flag = True Then
            '    loopvar_flag = False
            '    Exit Sub
            'End If

            If recursve_flag = False And phed_detls = False Then
                If recrd_flag = True Then
                    If PheadType = "DEEmpPF" And Rem_flag = True Then
                        Fetch_VPF()
                        VPF_Amt = CDbl((Rem_amt * VPF_Pcent) / 100)
                        TotSlabAmt = FormatNumber((TotSlabAmt + VPF_Amt), 2)
                        Rem_flag = False
                    End If
                    If PheadType = "DEEmpESI" And BscSlry > 10000 Then
                        TotSlabAmt = FormatNumber(CDbl(0), 2)
                    End If

                    LblAtrgt.Text = FormatNumber(TOTSLABAMT, 2)
                    'lst_cntr).SubItems(4)

                ElseIf recrd_flag = False Then
                    LblAtrgt.Text = FormatNumber(0, 2)
                    'LstPayhed.SubItems.Add(0)

                End If


                'ElseIf all_flag = True And recursve_flag = False And phed_detls = False Then

                '    If recrd_flag = True Then
                '        If Phed_type2 = "DEEmpPF" And Rem_flag = True Then
                '            Fetch_VPF_All()
                '            VPF_Amt = CDbl((Rem_Amt * VPF_Pcent) / 100)
                '            TotSlabAmt = FormatNumber(TotSlabAmt + VPF_Amt, 2)
                '            Rem_flag = False
                '        End If
                '        If Phed_type2 = "DEEmpESI" And arr_ernamt(cntr) > 10000 Then
                '            TotSlabAmt = CDbl(0)
                '        End If
                '        If STRT = 0 Then
                '            phed_arr(0) = TotSlabAmt
                '            STRT += 1
                '            INC_ARR += 1
                '        ElseIf STRT <> 0 Then
                '            phed_arr(INC_ARR) = TotSlabAmt
                '            INC_ARR += 1
                '        End If
                'LstvewAll.Items(i).SubItems(15).Text = TotSlabAmt
                'ElseIf recrd_flag = False Then
                '    'LstvewAll.Items(i).SubItems(13).Text = 0
                'End If
            End If
        End If

    End Sub


    Private Sub Fetch_VPF()

        Try
            Emp_Trgt_Cmd = New SqlCommand("select empvpfPcent from FinActEmpPfEsi where emppfdelstatus=1 and emppfconcrnid='" & (EmplId) & "'", FinActConn)
            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            Emp_Trgt_Rdr.Read()
            If Emp_Trgt_Rdr.HasRows = True Then
                VPF_Pcent = Emp_Trgt_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_rdr.Close()
            Emp_Trgt_Cmd = Nothing
        End Try

    End Sub

    Private Function recfun_payhead(ByVal headname As String, ByVal headid As Integer) As Integer

        Dim Rateval, RateId1, counter As Integer
        Dim FromAmt, UptoAmt, BscSlry, SlabAmt, DiffAmt As Double
        'Dim LstPayhed As ListViewItem
        Dim recrd_flag As Boolean
        TOTSLABAMT = 0
        Dim Arr_Pay_Type(100) As String
        Dim Arr_PhedId(100), Arr_PFId(100) As Integer
        Dim m As Integer
        m = 0
        Try
            Emp_Trgt_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PheadId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (headid) & "' ", FinActConn)
            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            While Emp_Trgt_Rdr.Read()
                If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                    Arr_PFId(m) = Emp_Trgt_Rdr(0)
                    Arr_Pay_Type(m) = Emp_Trgt_Rdr(1)
                    Arr_PhedId(m) = Emp_Trgt_Rdr(2)
                End If
                m = m + 1
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_Rdr.Close()
            Emp_Trgt_Cmd = Nothing
        End Try

        Dim contr As Integer = 0
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&Recursive begin------------------------------------
        While contr < m
            counter = 0
            j1 = 0
            l1 = 0
            Try
                Emp_Trgt_Cmd = New SqlCommand("select PheadName,PheadComp,PheadType,PheadCalmtd,PhFormulatype,PheadId from FinactPayHead where PheadDelstatus=0 and PheadId='" & (Arr_PFId(contr)) & "'", FinActConn) 'and PheadCalmtd<>'As User Defined Value' 
                Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                Emp_Trgt_Rdr.Read()
                If Emp_Trgt_Rdr.HasRows = True Then
                    Payhead_Name1 = Emp_Trgt_Rdr(0)
                    Arr_Ern_Deduc1(j1) = Emp_Trgt_Rdr(1)
                    Phed_Comp1 = Emp_Trgt_Rdr(1)
                    Arr_Phed_Type21(l1) = Emp_Trgt_Rdr(2)
                    Phed_Calmtd1 = Emp_Trgt_Rdr(3)
                    Phed_Formulatype1 = Emp_Trgt_Rdr(4)
                    Phed_Id1 = Emp_Trgt_Rdr(5)
                    j1 = j1 + 1
                    l1 = l1 + 1
                End If '--
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Emp_Trgt_Rdr.Close()
                Emp_Trgt_Cmd = Nothing
            End Try
            If Phed_Calmtd1 = "As Computed Value" Or Phed_Calmtd1 = "on Production/Performance value" Then
                phed_detls = True
                If Phed_Comp1 = "On Basic" Then
                    Fetch_Slab_RateId()
                    '--------Fetch_slabrate()
                    Rateval = 0
                    RateId1 = 0
                    FromAmt = 0
                    UptoAmt = 0
                    BscSlry = 0
                    SlabAmt = 0
                    DiffAmt = 0
                    counter = 0
                    recrd_flag = False
                    Dim extsub_flag As Boolean = False
                    TOTSLABAMT = 0
                    While counter < Count_SlabId
                        If phed_detls = True Then
                            Try
                                Emp_Trgt_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 and SrateId='" & (rateid11) & "'", FinActConn)
                                Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                Emp_Trgt_Rdr.Read()
                                If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                    recrd_flag = True
                                    rateid11 = Emp_Trgt_Rdr(0)
                                    FromAmt = Emp_Trgt_Rdr(1)
                                    If Emp_Trgt_Rdr(2) <> "Above" Then
                                        UptoAmt = Emp_Trgt_Rdr(2)
                                    Else
                                        UptoAmt = 9999999999999
                                    End If
                                    Rateval = Emp_Trgt_Rdr(3)
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                If Emp_Trgt_Rdr.IsDBNull(0) = True Then
                                    recrd_flag = False
                                End If
                                Emp_Trgt_Rdr.Close()
                                Emp_Trgt_Cmd = Nothing
                            End Try
                        End If
                        'If LblBscSlry.Text <> "" Then
                        ' BscSlry = CDbl(LblBscSlry.Text)
                        BscSlry = CDbl(BscSlry)
                        If UptoAmt = 9999999999999 Then
                            UptoAmt = BscSlry
                        End If
                        'End If
                        If UptoAmt > BscSlry And Phed_Formulatype1 <> "Achieved Target" Then
                            UptoAmt = BscSlry
                        End If
                        If Phed_Formulatype1 = "Compound(stepwise)" Then
                            If FromAmt = 0 Then
                                DiffAmt = (UptoAmt - FromAmt)
                            ElseIf FromAmt > 0 Then
                                DiffAmt = (UptoAmt - FromAmt) + 1
                            End If
                            If FromAmt <= BscSlry Then
                                SlabAmt = FormatNumber((DiffAmt * Rateval) / 100, 2)
                                TOTSLABAMT = TOTSLABAMT + SlabAmt
                                TOTSLABAMT = CDbl(TOTSLABAMT)
                            End If
                        ElseIf Phed_Formulatype1 = "Flat Rate" Then
                            If BscSlry <= UptoAmt And BscSlry >= FromAmt Then
                                TOTSLABAMT = 0
                                SlabAmt = FormatNumber((BscSlry * Rateval) / 100, 2)
                                TOTSLABAMT = SlabAmt
                                TOTSLABAMT = CDbl(TOTSLABAMT)
                            End If
                        ElseIf Phed_Formulatype1 = "Achieved Target" Then
                            If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                                TOTSLABAMT = 0
                                SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                                TOTSLABAMT = CDbl(SlabAmt)
                            End If
                        ElseIf Phed_Formulatype1 = "Earned Amount" Then
                            If Target_Amt <= UptoAmt And Target_Amt >= FromAmt Then
                                TOTSLABAMT = 0
                                SlabAmt = FormatNumber(Target_Amt * Rateval / 100, 2)
                                TOTSLABAMT = CDbl(SlabAmt)
                            End If
                        End If
                        If phed_detls = False Then
                            RateId = RateId + 1
                        ElseIf phed_detls = True Then
                            rateid11 = rateid11 + 1
                        End If
                        counter = counter + 1
                        extsub_flag = True
                    End While
                    If counter = Count_SlabId Then
                        ' Dim LstPayhed1 As ListViewItem
                        'If all_flag = False Then
                        If recrd_flag = True And extsub_flag <> True Then
                            'LstPayhed1 = LstvewPayhed.Items.Add(TotSlabAmt)
                        ElseIf recrd_flag = False And extsub_flag <> True Then
                            ' LstPayhed1 = LstvewPayhed.Items.Add(0)
                        End If
                        If extsub_flag <> True Then
                            'LstPayhed1.SubItems.Add(Payhead_Name)
                            'LstPayhed1.SubItems.Add(Payhead_Type)
                            'LstPayhed1.SubItems.Add(Ern_Deduc)
                            'If Payhead_Type = "As User Defined Value" Then
                            '    LstPayhed1.SubItems.Add("Not Edit")
                            'Else
                            '    LstPayhed1.SubItems.Add("Edit")
                            'End If
                            'LstPayhed1.SubItems.Add(PheadType)
                        End If
                        'End If
                    End If
                    ''''''''''''''''''''''''''''' contr = contr + 1
                ElseIf Phed_Comp1 = "On Specified Formula" Then
                    Dim m1 As Integer
                    Dim loopvar As Integer = 0
                    Dim Target_Amt1 As Double = 0.0
                    Dim Arr_Pay_Type1(100) As String
                    Dim Arr_PhedId1(100), Arr_PFid1(100) As Integer

                    If Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Or Phed_Formulatype1 = "Achieved Target" Or Phed_Formulatype1 = "Earned Amount" Then
                        If Phed_Formulatype1 <> "Achieved Target" And Phed_Formulatype1 <> "Earned Amount" Then
                            TotSlabamt1 = 0

                            m1 = 0
                            Try
                                Emp_Trgt_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PheadId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (Phed_Id1) & "'", FinActConn)
                                Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                While Emp_Trgt_Rdr.Read()
                                    If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                        Arr_PFid1(m1) = Emp_Trgt_Rdr(0)
                                        Arr_Pay_Type1(m1) = Emp_Trgt_Rdr(1)
                                        Arr_PhedId1(m1) = Emp_Trgt_Rdr(2)
                                    End If
                                    m1 = m1 + 1
                                End While
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                Emp_Trgt_Rdr.Close()
                                Emp_Trgt_Cmd = Nothing
                            End Try
                            TotSlabamt1 = 0

                        End If
                        If Phed_Formulatype1 = "Achieved Target" Or Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Or Phed_Formulatype1 = "Earned Amount" Then
                            If Phed_Formulatype1 = "Achieved Target" Then
                                ' Arr_PhedId(loopvar) = Phed_Id1
                                Arr_PFId(loopvar) = Phed_Id1
                                m1 = 1
                                Try
                                    Emp_Trgt_Cmd = New SqlCommand("select Amt from Finact_Target where EId='" & (EmplId) & "'", FinActConn)
                                    Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                    Emp_Trgt_Rdr.Read()
                                    If Emp_Trgt_Rdr.HasRows = True Then
                                        Target_Amt1 = CDbl(Emp_Trgt_Rdr(0))
                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                Finally
                                    If Emp_Trgt_Rdr.HasRows = False Then
                                        Target_Amt1 = CDbl(0)
                                    End If
                                    Emp_Trgt_Rdr.Close()
                                    Emp_Trgt_Cmd = Nothing
                                End Try

                            End If
                            If Phed_Formulatype1 = "Earned Amount" Then
                                'Arr_PhedId(loopvar) = Phed_Id1
                                Arr_PFId(loopvar) = Phed_Id1
                                m1 = 1
                                Target_Amt1 = CDbl(BscSlry)
                            End If
                            If Phed_Formulatype1 = "Compound(stepwise)" Then
                                'Arr_PhedId(loopvar) = Phed_Id1
                                Arr_PFId(loopvar) = Phed_Id1
                                ' m1 = 1
                                ' Target_Amt1 = CDbl(LblErnAmt.Text)
                            End If




                            While loopvar < m1

                                Try
                                    Emp_Trgt_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                    Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                    Emp_Trgt_Rdr.Read()
                                    If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                        Count_Slabid1 = Emp_Trgt_Rdr(0)
                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                Finally
                                    Emp_Trgt_Rdr.Close()
                                    Emp_Trgt_Cmd = Nothing
                                End Try
                                If Count_Slabid1 > 0 Then
                                    Try
                                        Emp_Trgt_Cmd = New SqlCommand("select SrateId from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                        Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                        Emp_Trgt_Rdr.Read()
                                        If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                            rateid11 = Emp_Trgt_Rdr(0)
                                        End If
                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                    Finally
                                        Emp_Trgt_Rdr.Close()
                                        Emp_Trgt_Cmd = Nothing
                                    End Try

                                End If

                                While counter < Count_Slabid1

                                    Try
                                        Emp_Trgt_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Arr_PFId(loopvar)) & "'and PheadDelstatus=0 and SrateId='" & (rateid11) & "'", FinActConn)
                                        Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
                                        Emp_Trgt_Rdr.Read()
                                        If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                            rateid11 = Emp_Trgt_Rdr(0)
                                            FromAmt1 = Emp_Trgt_Rdr(1)
                                            If Emp_Trgt_Rdr(2) <> "Above" Then
                                                UptoAmt1 = Emp_Trgt_Rdr(2)
                                            Else
                                                UptoAmt1 = 9999999999999
                                            End If

                                            Rateval1 = Emp_Trgt_Rdr(3)
                                        End If

                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                    Finally
                                        If Emp_Trgt_Rdr.IsDBNull(0) = False Then
                                            recrd_flag = True
                                        ElseIf Emp_Trgt_Rdr.IsDBNull(0) = True Then
                                            recrd_flag = False
                                        End If
                                        Emp_Trgt_Rdr.Close()
                                        Emp_Trgt_Cmd = Nothing
                                    End Try
                                    'If LblBscSlry.Text <> "" Then
                                    'BscSlry1 = CDbl(LblBscSlry.Text)
                                    If RbAmt.Checked = True Then
                                        If txtAtrget.Text <> "" Then
                                            BscSlry1 = CDbl(txtAtrget.Text)
                                        End If
                                    ElseIf RbProd.Checked = True Then
                                        If LblTrAmt.Text <> "" Then
                                            BscSlry1 = CDbl(LblTrAmt.Text)
                                        End If
                                    End If

                                    If UptoAmt1 = 9999999999999 Then
                                        UptoAmt1 = BscSlry
                                    End If
                                    'ElseIf all_flag = True Then
                                    'BscSlry1 = Arr_Bscsalary(cntr)
                                    'If UptoAmt1 = 9999999999999 Then
                                    '    UptoAmt1 = BscSlry1
                                    'End If
                                    'End If
                                    If UptoAmt1 > BscSlry1 And Phed_Formulatype1 <> "Achieved Target" Then
                                        UptoAmt1 = BscSlry1
                                    End If
                                    If Phed_Formulatype1 = "Compound(stepwise)" Then
                                        If FromAmt1 = 0 Then
                                            DiffAmt1 = (UptoAmt1 - FromAmt1)
                                        ElseIf FromAmt > 0 Then
                                            DiffAmt1 = (UptoAmt1 - FromAmt1) + 1
                                        End If
                                        If FromAmt1 <= BscSlry1 Then
                                            SlabAmt1 = FormatNumber((DiffAmt1 * Rateval1) / 100, 2)
                                            TotSlabamt1 = TotSlabamt1 + SlabAmt1
                                            TotSlabamt1 = CDbl(TotSlabamt1)
                                        End If
                                    ElseIf Phed_Formulatype1 = "Flat Rate" Then
                                        If BscSlry1 <= UptoAmt1 And BscSlry1 >= FromAmt1 Then
                                            TotSlabamt1 = 0
                                            SlabAmt1 = FormatNumber((BscSlry1 * Rateval1) / 100, 2)
                                            TotSlabamt1 = SlabAmt1
                                            TotSlabamt1 = CDbl(TotSlabamt1)
                                        End If
                                    ElseIf Phed_Formulatype1 = "Achieved Target" Then
                                        If Target_Amt1 <= UptoAmt1 And Target_Amt1 >= FromAmt1 Then
                                            TotSlabamt1 = 0
                                            SlabAmt1 = FormatNumber(Target_Amt1 * Rateval1 / 100, 2)
                                            TotSlabamt1 = CDbl(SlabAmt1)
                                        End If
                                    ElseIf Phed_Formulatype1 = "Earned Amount" Then
                                        If Target_Amt1 <= UptoAmt1 And Target_Amt1 >= FromAmt1 Then
                                            TotSlabamt1 = 0
                                            SlabAmt1 = FormatNumber(Target_Amt1 * Rateval1 / 100, 2)
                                            TotSlabamt1 = CDbl(SlabAmt1)
                                        End If
                                    End If
                                    TOTSLABAMT = TotSlabamt1
                                    rateid11 = rateid11 + 1
                                    RateId = RateId + 1
                                    counter = counter + 1
                                End While
                                loopvar += 1
                                If loopvar = m1 Then
                                    loopvar_flag = True
                                    totslab_flag = True
                                    phed_detls = True
                                    If Phed_Formulatype1 <> "Achieved Target" And Phed_Formulatype1 <> "Earned Amount" Then
                                        BscAmt = CDbl(TOTSLABAMT)
                                        finalamt = BscSlry1 - BscAmt
                                        BscAmt = CDbl(finalamt)
                                        Fetch_Slab_RateId()
                                        Fetch_slabrate()
                                    End If
                                End If
                            End While 'lop[
                        End If 'COME()
                    End If
                    '''''''''''''''''''''contr = contr + 1

                End If
            ElseIf Phed_Calmtd1 = "As User Defined Value" Then 'USER---------------
                Fetch_UsrPhed_Amt1()
                TOTSLABAMT = FormatNumber(UsrPhed_Amt, 2)
                ' LstvewPhed.Items(lst_cntr).SubItems.Add(TotSlabAmt)
                'Dim j As Integer = 0
                'Dim j As Integer = 0
                'If Datagrdusrdef.Rows.Count > 0 Then
                '    While j < Datagrdusrdef.Rows.Count
                '        If Datagrdusrdef.Rows(j).Cells(0).Value = Payhead_Name1 Then

                '            TotSlabAmt = Val(Datagrdusrdef.Rows(j).Cells(1).Value)
                '            Exit While
                '        End If
                '        j += 1
                '    End While
                'End If
            End If
            'If  LblBscSlry.Text <> "" Then
            'BscSlry = CDbl(LblBscSlry.Text)
            If RbAmt.Checked = True Then
                If txtAtrget.Text <> "" Then
                    BscSlry = CDbl(txtAtrget.Text)
                End If
            ElseIf RbProd.Checked = True Then
                If LblTrAmt.Text <> "" Then
                    BscSlry = CDbl(LblTrAmt.Text)
                End If
            End If


            'End If
            If contr = m Then
                totslab_flag = True
                phed_detls = False
                BscAmt = CDbl(TOTSLABAMT)
                finalamt = BscSlry - BscAmt
                BscAmt = CDbl(finalamt)
                Fetch_Slab_RateId()
                Fetch_slabrate()
            End If
            If Trim(Arr_Pay_Type(contr)) = Trim("Add") Then
                If contr = 0 Then
                    result = BscSlry + TOTSLABAMT
                ElseIf contr <> 0 Then
                    result += TOTSLABAMT
                End If
            ElseIf Trim(Arr_Pay_Type(contr)) = Trim("Minus") Then
                If contr = 0 Then
                    result = BscSlry - TOTSLABAMT
                ElseIf contr <> 0 Then
                    result -= TOTSLABAMT
                End If
                '
            End If
            contr = contr + 1
        End While 'main while
        phed_detls = False
        BscSlry = result
        totslab_flag = True
        BscSry_cng = result
        Payhead_Name1 = headname
        phed_detls = True
        Phed_Formulatype1 = str_PheadFormula
        Phed_Id1 = Sec_Phed_id
        recursve_flag = True
        Fetch_Slab_RateId()
        Fetch_slabrate()
        result = TOTSLABAMT
        Return result

    End Function

    Private Sub Fetch_UsrPhed_Amt()
        Try
            Emp_Trgt_Cmd = New SqlCommand("select PheadRate from FinactPayhead where PheadId='" & (Phed_Id) & "'", FinActConn)
            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            Emp_Trgt_Rdr.Read()
            If Emp_Trgt_Rdr.HasRows = True Then
                UsrPhed_Amt = Emp_Trgt_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_Rdr.Close()
            Emp_Trgt_Cmd = Nothing
        End Try
    End Sub


    Private Sub Fetch_UsrPhed_Amt1()
        Try
            Emp_Trgt_Cmd = New SqlCommand("select PheadRate from FinactPayhead where PheadId='" & (Phed_Id1) & "'", FinActConn)
            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            Emp_Trgt_Rdr.Read()
            If Emp_Trgt_Rdr.HasRows = True Then
                UsrPhed_Amt = Emp_Trgt_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_Rdr.Close()
            Emp_Trgt_Cmd = Nothing
        End Try
    End Sub


    Private Sub txtAtrget_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAtrget.TextChanged
        If txtAtrget.BackColor <> Color.White Then
            txtAtrget.BackColor = Color.White
        End If
    End Sub

    Private Sub SaveRecrd()

        Try
            If add_flag = True Then
                Emp_Trgt_Cmd = New SqlCommand("Finact_Target_Insert", FinActConn)
                Emp_Trgt_Cmd.CommandType = CommandType.StoredProcedure
                Emp_Trgt_Cmd.Parameters.AddWithValue("@TgDt", DtpkrDt.Value.Date)
                Emp_Trgt_Cmd.Parameters.AddWithValue("@TgEmpid", EmplId)
                Emp_Trgt_Cmd.Parameters.AddWithValue("@Tgadusrid", Current_UsrId)
                Emp_Trgt_Cmd.Parameters.AddWithValue("@Tgaddt", Now)
                Emp_Trgt_Cmd.Parameters.AddWithValue("@Tgdelstatus", 0)
                Emp_Trgt_Cmd.Parameters.AddWithValue("@TgDeptid", Deptid)
            ElseIf add_flag = False Then
                Emp_Trgt_Cmd = New SqlCommand("Finact_Target_Edit", FinActConn)
                Emp_Trgt_Cmd.CommandType = CommandType.StoredProcedure
                Emp_Trgt_Cmd.Parameters.AddWithValue("@TgEmpid", LblEid.Text)
                Emp_Trgt_Cmd.Parameters.AddWithValue("@Tgedtusrid", Current_UsrId)
                Emp_Trgt_Cmd.Parameters.AddWithValue("@Tgedtdt", Now)

            End If
            If RbAmt.Checked = True Then
                If txtAtrget.Text <> "" Then
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@TgAchdTrgt", CDbl(txtAtrget.Text))
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@TgTrgtType", "Amount")
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@TgQty", CDbl(0))
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@TgRate", CDbl(0))

                End If
            ElseIf RbProd.Checked = True Then
                If LblTrAmt.Text <> "" Then
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@TgAchdTrgt", CDbl(LblTrAmt.Text))
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@TgTrgtType", "Production")
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@TgQty", CDbl(TxtQty.Text))
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@TgRate", CDbl(TxtRate.Text))

                End If
            End If

            Emp_Trgt_Cmd.Parameters.AddWithValue("@TgFrm", DtpkrFrm.Value.Date)
            Emp_Trgt_Cmd.Parameters.AddWithValue("@TgTo", DtpkrTo.Value.Date)
            Emp_Trgt_Cmd.Parameters.AddWithValue("@TgType", CmbxCalc.Text)
            If CmbxCalc.SelectedIndex = 0 Then
                Emp_Trgt_Cmd.Parameters.AddWithValue("@TgAmt", CmbxPhed.Text)
            ElseIf CmbxCalc.SelectedIndex = 1 Then
                Emp_Trgt_Cmd.Parameters.AddWithValue("@TgAmt", TxtPerc.Text)
            ElseIf CmbxCalc.SelectedIndex = 2 Then
                Emp_Trgt_Cmd.Parameters.AddWithValue("@TgAmt", TxtAmt.Text)
            End If

            Emp_Trgt_Cmd.Parameters.AddWithValue("@TgInc", CDbl(LblAtrgt.Text))

            Emp_Trgt_Cmd.ExecuteNonQuery()
            If add_flag = True Then
                MsgBox("Record has been Saved Successfully.", MsgBoxStyle.Information, "Save")
            ElseIf add_flag = False Then
                MsgBox("Record has been Updated Successfully.", MsgBoxStyle.Information, "Edit")

            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_Cmd = Nothing
        End Try


    End Sub


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            cnfrm = MsgBox("Are you sure to save the record?", MsgBoxStyle.YesNo, "Save Record")
            If cnfrm = vbYes Then
                add_flag = True
                SaveRecrd()
                Clrval()
            End If
        ElseIf BtnSave.Text = "&Edit" Then
            cnfrm = MsgBox("Are you sure to update the record?", MsgBoxStyle.YesNo, "Edit Record")
            If cnfrm = vbYes Then
                add_flag = False
                SaveRecrd()
                Clrval()
            End If
            End If
    End Sub


    Private Sub Fetch_Recrds()
        no_recrd = False

        Try
            Emp_Trgt_Cmd = New SqlCommand("Select distinct(TgEmpid),FinactEmpmstr.empname from  FinactEmpTarget inner join FinactEmpmstr on FinactEmpmstr.empid=FinactEmpTarget.TgEmpid where Tgdelstatus=0 ", FinActConn)
            da = New SqlDataAdapter(Emp_Trgt_Cmd)
            ds = New DataSet(Emp_Trgt_Cmd.CommandText)
            da.Fill(ds)
            CmbxSrchEmp.DataSource = ds.Tables(0)
            Me.CmbxSrchEmp.ValueMember = "TgEmpid"
            Me.CmbxSrchEmp.DisplayMember = "empname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try


    End Sub

    Private Sub BtnFnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd.Click
        If BtnFnd.Text = "&Find" Then
            Fetch_Recrds()
            If CmbxSrchEmp.Items.Count > 0 Then
                PnlSrch.Visible = True

                If RbAmt.Checked = True Or RbAmt.Checked = False And RbProd.Checked = False Then
                    Me.Size = New System.Drawing.Point(644, 618)
                ElseIf RbProd.Checked = True Then
                    Me.Size = New System.Drawing.Point(644, 649)

                End If

                Panel1.Enabled = False
                BtnSave.Text = "&Edit"
                BtnFnd.Text = "&Delete"
                BtnSave.Enabled = False
                BtnFnd.Enabled = False
                DtpkrDt.Enabled = False

                CmbxSrchEmp.Focus()
            Else
                MsgBox("No record found", MsgBoxStyle.Information, "Find")
                DtpkrDt.Focus()
            End If



        ElseIf BtnFnd.Text = "&Delete" Then

            cnfrm = MsgBox("Are you sure to delete record?", MsgBoxStyle.YesNo, "Delete")
            If cnfrm = vbYes Then

                Try
                    Emp_Trgt_Cmd = New SqlCommand("Finact_Target_Delete", FinActConn)
                    Emp_Trgt_Cmd.CommandType = CommandType.StoredProcedure
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@TgEmpid", LblEid.Text)
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@TgDt", DtpkrDt.Value.Date)
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@Tgdelusrid", Current_UsrId)
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@Tgdeldt", Now)
                    Emp_Trgt_Cmd.Parameters.AddWithValue("@Tgdelstatus", 1)
                    Emp_Trgt_Cmd.ExecuteNonQuery()
                    MsgBox("Record has been Deleted Successfully.", MsgBoxStyle.Information, "Delete")
                    Clrval()
                    BtnSave.Text = "&Save"
                    BtnFnd.Text = "&Find"
                    DtpkrDt.Enabled = True
                    DtpkrDt.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Emp_Trgt_Cmd = Nothing
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
            LblSrchid.Text = CmbxSrchEmp.SelectedValue
            BtnSrch.Focus()

        End If
    End Sub

    Private Sub CmbxSrchEmp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxSrchEmp.SelectedIndexChanged

    End Sub

    Private Sub BtnSrch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSrch.Click
        BtnSave.Enabled = True
        BtnFnd.Enabled = True

        LblSrchid.Text = CmbxSrchEmp.SelectedValue

        If CmbxSrchEmp.Items.Count > 0 Then
            EmSrchId = CmbxSrchEmp.SelectedValue
            PnlSrch.Visible = False
            CmbxSrchEmp.DroppedDown = False
            LstTrgt.Visible = True
            Lblheding.Visible = True
            Lblheding.Size = New System.Drawing.Point(301, 20)
            Lblheding.Location = New System.Drawing.Point(130, 418)
            LstTrgt.Location = New System.Drawing.Point(12, 446)
            LstTrgt.Size = New System.Drawing.Point(614, 108)
            Me.Size = New System.Drawing.Point(644, 633)

            Empnm = CmbxSrchEmp.Text
            Lblheding.Text = "Target Details of  " + CmbxSrchEmp.Text
            Fetch_DetailRecrds()

        End If


    End Sub


    Private Sub Fetch_DetailRecrds()

        Dim Lstvw As ListViewItem
        LstTrgt.Items.Clear()
        Try
            Emp_Trgt_Cmd = New SqlCommand("Select TgDt,TgDeptid,TgAchdTrgt,TgFrm,TgTo,TgType,TgAmt,TgInc,TgEmpid,TgTrgtType,TgQty,TgRate from  FinactempTarget where TgEmpid='" & (EmSrchId) & "'and Tgdelstatus=0 ", FinActConn)
            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader

            While Emp_Trgt_Rdr.Read()
                If Emp_Trgt_Rdr.HasRows = True Then

                    Lstvw = LstTrgt.Items.Add(Emp_Trgt_Rdr(0))
                    Lstvw.SubItems.Add(FormatNumber(Emp_Trgt_Rdr(1), 2))
                    Lstvw.SubItems.Add(FormatNumber(Emp_Trgt_Rdr(2), 2))
                    Lstvw.SubItems.Add(Emp_Trgt_Rdr(3))
                    Lstvw.SubItems.Add(Emp_Trgt_Rdr(4))
                    Lstvw.SubItems.Add(Emp_Trgt_Rdr(5))
                    Lstvw.SubItems.Add(Emp_Trgt_Rdr(6))
                    Lstvw.SubItems.Add(Emp_Trgt_Rdr(7))
                    Lstvw.SubItems.Add(Emp_Trgt_Rdr(8))
                    Lstvw.SubItems.Add(Emp_Trgt_Rdr(9))
                    Lstvw.SubItems.Add(Emp_Trgt_Rdr(10))
                    Lstvw.SubItems.Add(Emp_Trgt_Rdr(11))

                End If
            End While
            If Emp_Trgt_Rdr.HasRows = True Then

                If LstTrgt.Items.Count > 0 Then
                    LstTrgt.Focus()
                    LstTrgt.Items(0).Selected = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Emp_Trgt_Rdr.HasRows = False Then
                MsgBox("System has found no record of '" & (CmbxSrchEmp.Text) & "'", MsgBoxStyle.Information, "Find")

            End If

            Emp_Trgt_Rdr.Close()
            Emp_Trgt_Cmd = Nothing
        End Try


    End Sub

    Private Sub Fetch_Max_recrd()

        Try
            Emp_Trgt_Cmd = New SqlCommand("select max(TgDt) from FinactEmpTarget where TgEmpid='" & EmSrchId & "'and Tgdelstatus=0", FinActConn)
            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            Emp_Trgt_Rdr.Read()
            If Emp_Trgt_Rdr.HasRows = True Then
                Max_dt = Emp_Trgt_Rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_Cmd = Nothing
            Emp_Trgt_Rdr.Close()
        End Try

    End Sub

    Private Sub Fetch_Dept_Desi()

        Try
            Emp_Trgt_Cmd = New SqlCommand("select deptname from finactDept inner join FinactEmpmstr on FinactEmpmstr.empdeptid=finactdept.deptid where FinactEmpmstr.empid='" & EmSrchId & "'", FinActConn)
            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            Emp_Trgt_Rdr.Read()
            If Emp_Trgt_Rdr.HasRows = True Then
                CmbxDept.Text = Emp_Trgt_Rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_Cmd = Nothing
            Emp_Trgt_Rdr.Close()
        End Try

        Try
            Emp_Trgt_Cmd = New SqlCommand("select desiname from finactDesi inner join FinactEmpmstr on FinactEmpmstr.empdesiid=finactDesi.Desiid where FinactEmpmstr.empid='" & EmSrchId & "'", FinActConn)
            Emp_Trgt_Rdr = Emp_Trgt_Cmd.ExecuteReader
            Emp_Trgt_Rdr.Read()
            If Emp_Trgt_Rdr.HasRows = True Then
                lblDesig.Text = Emp_Trgt_Rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Trgt_Cmd = Nothing
            Emp_Trgt_Rdr.Close()
        End Try


    End Sub



    Private Sub LstTrgt_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstTrgt.DoubleClick
        Dim indx As Integer
        Dim trgt_type As String
        indx = LstTrgt.SelectedItems(0).Index
        Panel1.Enabled = True
        CmbxDept.Enabled = False
        Sel_Date = LstTrgt.Items(indx).SubItems(0).Text
        Fetch_Max_recrd()
        If Max_dt = Sel_Date Then
            trgt_type = LstTrgt.Items(indx).SubItems(9).Text
            If trgt_type = "Amount" Then
                set_frm()
                RbAmt.Checked = True
                txtAtrget.Text = LstTrgt.Items(indx).SubItems(2).Text
            ElseIf trgt_type = "Production" Then
                RbProd.Checked = True
                set_frm_prod()
                TxtQty.Text = LstTrgt.Items(indx).SubItems(10).Text
                TxtRate.Text = FormatNumber(LstTrgt.Items(indx).SubItems(11).Text, 2)
                LblTrAmt.Text = LstTrgt.Items(indx).SubItems(2).Text
            End If

            DtpkrFrm.Text = LstTrgt.Items(indx).SubItems(0).Text
            CmbxDept.Text = LstTrgt.Items(indx).SubItems(1).Text

            DtpkrFrm.Text = LstTrgt.Items(indx).SubItems(3).Text

            DtpkrTo.Text = LstTrgt.Items(indx).SubItems(4).Text
            CmbxCalc.Text = LstTrgt.Items(indx).SubItems(5).Text
            If CmbxCalc.Text = "Formula" Then

                TxtPerc.Visible = False
                LblPercnt.Visible = False
                LblAmt.Visible = False
                TxtAmt.Visible = False
                LblRs1.Visible = False
                CmbxPhed.Visible = True
                LblPhed.Visible = True
                LblAmt.Visible = False
                If RbAmt.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 218)
                ElseIf RbProd.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 239)
                End If
                fetch_Phed()

                CmbxPhed.Text = LstTrgt.Items(indx).SubItems(6).Text

            ElseIf CmbxCalc.Text = "Value" Then
                LblAmt.Text = "Amount:-"
                LblAmt.Visible = True
                TxtAmt.Visible = True
                LblRs1.Visible = True
                TxtPerc.Visible = False
                LblPercnt.Visible = False
                If RbAmt.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 218)
                ElseIf RbProd.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 239)
                End If
                CmbxPhed.Visible = False
                LblPhed.Visible = False
                TxtAmt.Text = FormatNumber(LstTrgt.Items(indx).SubItems(6).Text, 2)
            ElseIf CmbxCalc.Text = "Percentage" Then
                LblAmt.Text = "Percentage:-"
                TxtPerc.Visible = True
                LblPercnt.Visible = True
                LblAmt.Visible = True
                TxtAmt.Visible = False
                LblRs1.Visible = False
                CmbxPhed.Visible = False
                LblPhed.Visible = False
                If RbAmt.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 218)
                ElseIf RbProd.Checked = True Then
                    DtpkrTo.Location = New System.Drawing.Point(445, 239)
                End If

                TxtPerc.Text = LstTrgt.Items(indx).SubItems(6).Text
            End If

            LblAtrgt.Text = FormatNumber(LstTrgt.Items(indx).SubItems(7).Text, 2)
            LblEid.Text = LstTrgt.Items(indx).SubItems(8).Text
            EmSrchId = LstTrgt.Items(indx).SubItems(8).Text
            CmbxEname.Visible = False
            LblEmpnm.Visible = True
            LblEmpnm.Text = Empnm
            Fetch_Dept_Desi()

            'Me.Size = New System.Drawing.Point(644, 499)

            LstTrgt.Visible = False
            DtpkrDt.Enabled = False
            CmbxEname.Enabled = False
            Lblheding.Visible = False

            txtAtrget.Focus()
        Else
            MsgBox("Can't update it as this is not the Recent Appraisal", MsgBoxStyle.Information, "Record")

        End If



    End Sub


    Private Sub numericTextboxKeyPress1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAtrget.KeyPress, TxtPerc.KeyPress, TxtAmt.KeyPress

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

    Private Sub LstTrgt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstTrgt.Enter
        'LstTrgt_DoubleClick(sender, e)
    End Sub



    Private Sub RbAmt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAmt.CheckedChanged
        If RbAmt.Checked = True Then
            Label4.Visible = True
            txtAtrget.Visible = True
            LblQty.Visible = False
            LblRate.Visible = False
            LblTgAmt.Visible = False
            TxtQty.Visible = False
            LblMul.Visible = False
            TxtRate.Visible = False
            LblTgAmt.Visible = False
            TxtQty.Visible = False
            LblEql.Visible = False
            LblTrAmt.Visible = False
            LblRs2.Visible = False
            txtAtrget.Location = New System.Drawing.Point(145, 178)
            Label4.Location = New System.Drawing.Point(17, 177)
            Label2.Location = New System.Drawing.Point(17, 220)
            DtpkrFrm.Location = New System.Drawing.Point(145, 220)
            Label5.Location = New System.Drawing.Point(356, 218)
            DtpkrTo.Location = New System.Drawing.Point(445, 218)
            Label3.Location = New System.Drawing.Point(17, 264)
            CmbxCalc.Location = New System.Drawing.Point(145, 273)
            Label6.Location = New System.Drawing.Point(17, 322)
            LblAtrgt.Location = New System.Drawing.Point(145, 322)
            PnlSrch.Location = New System.Drawing.Point(10, 416)
            Me.Size = New System.Drawing.Point(644, 499)
            LblRs.Location = New System.Drawing.Point(268, 322)
            Panel1.Size = New System.Drawing.Point(612, 357)

        End If
    End Sub
    Private Sub set_frm_prod()
        txtAtrget.Visible = False
        LblQty.Visible = True
        LblRate.Visible = True
        LblTgAmt.Visible = True
        TxtQty.Visible = True
        LblMul.Visible = True
        TxtRate.Visible = True
        LblTgAmt.Visible = True
        TxtQty.Visible = True
        LblEql.Visible = True
        LblTrAmt.Visible = True
        LblRs2.Visible = True
        Label4.Location = New System.Drawing.Point(17, 196)
        LblQty.Location = New System.Drawing.Point(164, 167)
        LblRate.Location = New System.Drawing.Point(280, 167)
        LblTgAmt.Location = New System.Drawing.Point(388, 167)
        TxtQty.Location = New System.Drawing.Point(148, 197)
        LblMul.Location = New System.Drawing.Point(237, 197)
        TxtRate.Location = New System.Drawing.Point(269, 197)
        LblEql.Location = New System.Drawing.Point(339, 197)
        LblTrAmt.Location = New System.Drawing.Point(369, 196)
        LblRs2.Location = New System.Drawing.Point(464, 196)
        Label2.Location = New System.Drawing.Point(17, 241)
        DtpkrFrm.Location = New System.Drawing.Point(145, 241)
        Label5.Location = New System.Drawing.Point(356, 239)
        DtpkrTo.Location = New System.Drawing.Point(445, 239)
        Label3.Location = New System.Drawing.Point(17, 285)
        CmbxCalc.Location = New System.Drawing.Point(145, 294)
        Label6.Location = New System.Drawing.Point(17, 343)
        LblAtrgt.Location = New System.Drawing.Point(145, 343)
        LblRs.Location = New System.Drawing.Point(268, 343)
        Panel1.Size = New System.Drawing.Point(612, 382)
        PnlSrch.Location = New System.Drawing.Point(10, 445)
        Me.Size = New System.Drawing.Point(644, 525)
        LblPhed.Location = New System.Drawing.Point(356, 290)
        CmbxPhed.Location = New System.Drawing.Point(475, 290)
    End Sub

    Private Sub RbProd_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbProd.CheckedChanged
        set_frm_prod()
        TxtQty.Focus()
    End Sub

    Private Sub TxtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            TxtRate.Focus()
        End If
    End Sub

    Private Sub TxtRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRate.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If TxtQty.Text <> "" And TxtRate.Text <> "" Then
                LblTrAmt.Text = FormatNumber(CDbl(TxtQty.Text) * CDbl(TxtRate.Text), 2)

            End If
            DtpkrFrm.Focus()
        End If
    End Sub

  
    Private Sub TxtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty.TextChanged
        If TxtQty.Text <> "" And TxtRate.Text <> "" Then
            LblTrAmt.Text = FormatNumber(CDbl(TxtQty.Text) * CDbl(TxtRate.Text), 2)

        End If
    End Sub

    Private Sub TxtRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRate.TextChanged
        If TxtQty.Text <> "" And TxtRate.Text <> "" Then
            LblTrAmt.Text = FormatNumber(CDbl(TxtQty.Text) * CDbl(TxtRate.Text), 2)

        End If
    End Sub

    Private Sub CmbxPhed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxPhed.SelectedIndexChanged

    End Sub
End Class
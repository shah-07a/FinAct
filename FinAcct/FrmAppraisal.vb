Imports System.Data
Imports System.Data.SqlClient

Public Class FrmAppraisal
    Dim Fetch_Ename_Cmd As SqlCommand
    Dim Fetch_Ename_rdr As SqlDataReader
    Dim Fetch_Payhed_Cmd As SqlCommand
    Dim Fetch_Payhed_rdr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim Empid, EmpDeptid, EmpDesigid As Integer
    Dim EmpBscSlry As Double
    Dim EmpJndt As Date
    Dim EmId As Integer
    Dim Max_dt As Date
    Dim Sel_Date As Date
    Dim cnfrmmsg As String
    Dim fnlslry As Double

    Dim Total As Double
    Dim add_flag As Boolean = False
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


    Private Sub FrmAppraisal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Appraisal"
        Me.Top = 0
        Me.Left = 0
        PnlApraisl.Size = New System.Drawing.Point(614, 476)
        Me.Size = New System.Drawing.Point(648, 572)

        fetch_Cmbx_Ename()
    End Sub

    Private Sub fetch_Cmbx_Ename()
     

        Try
            Fetch_Ename_Cmd = New SqlCommand("Select empname,empid from  FinactEmpmstr where empdelstatus=1 and empcateg='Working'and empjnDt<='" & (DtpkrDt.Value.Date) & "'order by empname", FinActConn)
            da = New SqlDataAdapter(Fetch_Ename_Cmd)
            ds = New DataSet(Fetch_Ename_Cmd.CommandText)
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

    Private Sub ComboEname()
    
        If CmbxEname.Text <> "" Then
            Try
                Fetch_Ename_Cmd = New SqlCommand("Select empid,empdeptid,empdesiid,empgrade,empothrsift,empcategory,empjnDt from FinactEmpmstr where empname='" & (CmbxEname.Text) & "'", FinActConn)
                Fetch_Ename_rdr = Fetch_Ename_Cmd.ExecuteReader
                Fetch_Ename_rdr.Read()
                If Fetch_Ename_rdr.HasRows = True Then
                    Empid = Fetch_Ename_rdr(0)
                    EmpDeptid = Fetch_Ename_rdr(1)
                    EmpDesigid = Fetch_Ename_rdr(2)
                    EmpBscSlry = Fetch_Ename_rdr(3)

                    EmpJndt = Fetch_Ename_rdr(6)

                    ' EmpJnDt = Fetch_Ename_Rdr(4)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Fetch_Ename_rdr.Close()
                Fetch_Ename_Cmd = Nothing
            End Try

            LblEmpid.Text = Empid
            LblBscSlry.Text = FormatNumber(EmpBscSlry, 2)

            Fetch_Dept()
            Fetch_Payhead_Name()
            'p = 0
            'Dim total As Double

            'While p < i

            '    total = total + arr_phed_amt(p)
            '    p = p + 1

            'End While

            'LblGrossSlry.Text = FormatNumber(total, 2)

        End If

    End Sub

    Private Sub Fetch_Dept()

        Try
            Fetch_Ename_Cmd = New SqlCommand("select deptname from finactDept where Deptid='" & EmpDeptid & "'and deptdelstatus=1", FinActConn)
            Fetch_Ename_rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_rdr.Read()
            If Fetch_Ename_rdr.HasRows = True Then
                lblDept.Text = Fetch_Ename_rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_rdr.Close()
        End Try

        Try
            Fetch_Ename_Cmd = New SqlCommand("select desiname from finactDesi where Desiid='" & EmpDesigid & "'and desidelstatus=1", FinActConn)
            Fetch_Ename_rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_rdr.Read()
            If Fetch_Ename_rdr.HasRows = True Then
                lblDesig.Text = Fetch_Ename_rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_rdr.Close()
        End Try

        cmbxmode.focus()

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click

        cnfrmmsg = MsgBox("Are you sure to Exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmmsg = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub DtpkrDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            'Me.fetch_Cmbx_Ename()
            If CmbxEname.Items.Count > 0 Then

                CmbxEname.Focus()
            End If
        End If
    End Sub

    Private Sub DtpkrDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpkrDt.ValueChanged

    End Sub

    Private Sub CmbxEname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEname.GotFocus
        If CmbxEname.Items.Count > 0 Then
            CmbxEname.DroppedDown = True

        End If
    End Sub

    Private Sub CmbxEname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEname.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            ComboEname()
        End If
    End Sub

    Private Sub CmbxEname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEname.Leave
        CmbxEname.DroppedDown = False
    End Sub

    Private Sub CmbxEname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxEname.SelectedIndexChanged

    End Sub

    Private Sub cmbxMode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxMode.GotFocus
        If cmbxMode.Items.Count > 0 Then
            If cmbxMode.Text = "" Then
                cmbxMode.SelectedIndex = 0
            End If
            cmbxMode.DroppedDown = True
        End If
    End Sub

    Private Sub cmbxMode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbxMode.KeyDown
        If e.KeyCode = 13 Then
            If cmbxMode.SelectedIndex = 0 Then
                Label4.Text = "Appraisal Amount"
                Label4.Visible = True
                Label9.Visible = True
                txtAppAmt.Visible = True
                Label14.Visible = False
                txtAppPer.Visible = False
                Label12.Visible = False
                CmbxAppon.Visible = False
                LblAmt.Visible = False
                Label17.Visible = False
                Label9.Location = New System.Drawing.Point(278, 322)
                txtAppAmt.Focus()
             
            ElseIf cmbxMode.SelectedIndex = 1 Then
                Label9.Visible = False
                txtAppAmt.Visible = False
              

                Label4.Text = "Appraisal %age"
                Label14.Visible = True
                txtAppPer.Visible = True
                Label12.Visible = True
                CmbxAppon.Visible = True
                LblAmt.Visible = True
                Label17.Visible = True
                CmbxAppon.Focus()

            End If

        End If
    End Sub

    Private Sub cmbxMode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxMode.Leave
        cmbxMode.DroppedDown = False
    End Sub

    Private Sub txtAppAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAppAmt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If txtAppAmt.Text <> "" Then
                txtAppAmt.Text = FormatNumber(txtAppAmt.Text, 2)
                LblFnlSlry.Text = FormatNumber(CDbl(LblBscSlry.Text) + CDbl(txtAppAmt.Text), 2)
                DtpkrFrm.Focus()
            ElseIf txtAppAmt.Text = "" Then
                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                txtAppAmt.BackColor = Color.PapayaWhip
                txtAppAmt.Focus()
            End If
        End If
    End Sub


    Private Sub txtAppPer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAppPer.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            If txtAppPer.Text <> "" Then
                Label17.Visible = True
                Label17.Location = New System.Drawing.Point(315, 322)
                LblAmt.Visible = True
                LblAmt.Location = New System.Drawing.Point(447, 322)
                Label9.Visible = True
                Label9.Location = New System.Drawing.Point(567, 322)
                If CmbxAppon.Text = "Gross Salary" Then
                    LblFnlSlry.Text = FormatNumber(CDbl(LblBscSlry.Text) + (CDbl(txtAppPer.Text) * CDbl(LblGrossSlry.Text) / 100), 2)
                    LblAmt.Text = FormatNumber((CDbl(txtAppPer.Text) * CDbl(LblGrossSlry.Text) / 100), 2)
                ElseIf CmbxAppon.Text = "Basic Salary" Then
                    LblFnlSlry.Text = FormatNumber(CDbl(LblBscSlry.Text) + (CDbl(txtAppPer.Text) * CDbl(LblBscSlry.Text) / 100), 2)
                    LblAmt.Text = FormatNumber((CDbl(txtAppPer.Text) * CDbl(LblBscSlry.Text) / 100), 2)
                End If
                DtpkrFrm.Focus()
            ElseIf txtAppPer.Text = "" Then
                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                txtAppPer.BackColor = Color.PapayaWhip
                txtAppPer.Focus()
            End If

            End If
    End Sub

   

    Private Sub CmbxAppon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxAppon.GotFocus
        If CmbxAppon.Items.Count > 0 Then
            If CmbxAppon.Text = "" Then
                CmbxAppon.SelectedIndex = 0

            End If
            CmbxAppon.DroppedDown = True

        End If
    End Sub

    Private Sub CmbxAppon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxAppon.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            txtAppPer.Focus()
        End If
    End Sub



    Private Sub Fetch_Phed_Id()

        i = 0

        Try
            Fetch_Payhed_Cmd = New SqlCommand("select PdPhedId from FinactEmp_SlryPhed inner join FinactEmp_SlryBrkup on FinactEmp_SlryBrkup.SBid=FinactEmp_SlryPhed.PdSlryConcrnid inner join FinactPayhead on FinactPayHead.PheadId=FinactEmp_SlryPhed.PdPhedId where FinactEmp_SlryBrkup.SBEmpConcrnId='" & (Empid) & "'and FinactPayHead.PheadType='EREmp' or FinactEmp_SlryBrkup.SBEmpConcrnId='" & (Empid) & "' and FinactPayHead.PheadType='REB'", FinActConn)
            Fetch_Payhed_rdr = Fetch_Payhed_Cmd.ExecuteReader
            While Fetch_Payhed_rdr.Read()
                If Fetch_Payhed_rdr.HasRows = True Then
                 
                    Arr_Phed_Id(i) = Fetch_Payhed_rdr(0)
                    count = count + 1
                    i = i + 1
                End If

            End While
            'ElseIf Fetch_Payhed_Rdr.HasRows = False Then
            '    list_add = False
            '    Count_Payhead = Count_Payhead + 1


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Fetch_Payhed_rdr.HasRows = False Then
                count = 0
            End If
            Fetch_Payhed_rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try


    End Sub




    Private Sub Fetch_Payhead_Name()

        Dim list_add As Boolean
        Dim m As Integer = 0
        ' Fetch_Payhead()
        Fetch_Phed_Id()
        m = 0
        While m < count
            Try
                Fetch_Payhed_Cmd = New SqlCommand("select PheadName,PheadCalmtd,PheadComp ,PheadType,PhFormulatype,PheadId from FinactPayHead where PheadDelstatus=0 and PheadId='" & (Arr_Phed_Id(m)) & "'", FinActConn)
                Fetch_Payhed_rdr = Fetch_Payhed_Cmd.ExecuteReader
                Fetch_Payhed_rdr.Read()
                If Fetch_Payhed_rdr.HasRows = True Then
                    Payhead_Name = Fetch_Payhed_rdr(0)
                    Payhead_Type = Fetch_Payhed_rdr(1)
                    Phed_Calmtd = Fetch_Payhed_rdr(1)
                    Ern_Deduc = Fetch_Payhed_rdr(2)
                    Phed_Comp = Fetch_Payhed_rdr(2)
                    PheadType = Fetch_Payhed_rdr(3)
                    Phed_Formulatype = Fetch_Payhed_rdr(4)
                    Phed_Id = Fetch_Payhed_rdr(5)
                    list_add = True

                    'ElseIf Fetch_Payhed_Rdr.HasRows = False Then
                    '    list_add = False
                    '    Count_Payhead = Count_Payhead + 1

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Fetch_Payhed_rdr.Close()
                Fetch_Payhed_Cmd = Nothing
            End Try

            If list_add = True Then
                totslab_flag = False
                Fetch_Payhead_Amt()
            End If

            m = m + 1
            LST_CNTR = LST_CNTR + 1

            Total = Total + arr_phed_amt(i)
        End While
     
        LblGrossSlry.Text = FormatNumber(CDbl(LblBscSlry.Text) + Total, 2)

    End Sub


    Private Sub Fetch_Payhead_Amt()

        BscSlry = CDbl(LblBscSlry.Text)
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
                        Fetch_Payhed_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PayheadConId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (Phed_Id) & "' ", FinActConn)
                        Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                        While Fetch_Payhed_Rdr.Read()
                            If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                Arr_PFId(m) = Fetch_Payhed_Rdr(0)
                                Arr_Pay_Type(m) = Fetch_Payhed_Rdr(1)
                                Arr_PhedId(m) = Fetch_Payhed_Rdr(2)

                            End If
                            m = m + 1
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Fetch_Payhed_Rdr.Close()
                        Fetch_Payhed_Cmd = Nothing
                    End Try

                    Dim contr As Integer = 0
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&Recursive begin------------------------------------
                    While contr < m
                        counter = 0
                        j1 = 0
                        l1 = 0
                        TotSlabAmt1 = 0
                        Try
                            Fetch_Payhed_Cmd = New SqlCommand("select PheadName,PheadComp,PheadType,PheadCalmtd,PhFormulatype,PheadId from FinactPayHead where PheadDelstatus=0 and PheadId='" & (Arr_PFId(contr)) & " '", FinActConn) 'and PheadCalmtd<>'As User Defined Value'", FinActConn)
                            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                            Fetch_Payhed_Rdr.Read()
                            If Fetch_Payhed_Rdr.HasRows = True Then
                                Payhead_Name1 = Fetch_Payhed_Rdr(0)
                                Arr_Ern_Deduc1(j1) = Fetch_Payhed_Rdr(1)
                                Phed_Comp1 = Fetch_Payhed_Rdr(1)
                                Arr_Phed_Type21(l1) = Fetch_Payhed_Rdr(2)
                                Phed_Calmtd1 = Fetch_Payhed_Rdr(3)
                                Phed_Formulatype1 = Fetch_Payhed_Rdr(4)
                                Phed_Id1 = Fetch_Payhed_Rdr(5)
                                j1 = j1 + 1
                                l1 = l1 + 1
                            End If '--
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Fetch_Payhed_Rdr.Close()
                            Fetch_Payhed_Cmd = Nothing
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
                                            Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0 and SrateId='" & (arr_srateid(i)) & "'", FinActConn)
                                            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                            Fetch_Payhed_Rdr.Read()
                                            If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                recrd_flag = True
                                                RateId1 = Fetch_Payhed_Rdr(0)
                                                FromAmt = Fetch_Payhed_Rdr(1)
                                                If Fetch_Payhed_Rdr(2) <> "Above" Then
                                                    UptoAmt = Fetch_Payhed_Rdr(2)
                                                Else
                                                    UptoAmt = 9999999999999
                                                End If
                                                Rateval = Fetch_Payhed_Rdr(3)
                                            End If

                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        Finally
                                            If Fetch_Payhed_Rdr.IsDBNull(0) = True Then
                                                recrd_flag = False
                                            End If
                                            Fetch_Payhed_Rdr.Close()
                                            Fetch_Payhed_Cmd = Nothing
                                        End Try
                                    ElseIf phed_detls = True Then
                                        Try
                                            Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 and SrateId ='" & (arr_srateid1(i)) & "'", FinActConn)
                                            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                            Fetch_Payhed_Rdr.Read()
                                            If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                recrd_flag = True
                                                RateId11 = Fetch_Payhed_Rdr(0)
                                                FromAmt = Fetch_Payhed_Rdr(1)
                                                If Fetch_Payhed_Rdr(2) <> "Above" Then
                                                    UptoAmt = Fetch_Payhed_Rdr(2)
                                                Else
                                                    UptoAmt = 9999999999999
                                                End If
                                                Rateval = Fetch_Payhed_Rdr(3)
                                            End If
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        Finally
                                            If Fetch_Payhed_Rdr.IsDBNull(0) = True Then
                                                recrd_flag = False
                                            End If
                                            Fetch_Payhed_Rdr.Close()
                                            Fetch_Payhed_Cmd = Nothing
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
                                        arr_phed_amt(i) = TOTSLABAMT
                                    ElseIf recrd_flag = False And extsub_flag <> True Then
                                        arr_phed_amt(i) = TOTSLABAMT
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
                                            Fetch_Payhed_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PheadId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (Phed_Id1) & "'", FinActConn)
                                            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                            While Fetch_Payhed_Rdr.Read()
                                                If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                    Arr_PFId1(m1) = Fetch_Payhed_Rdr(0)
                                                    Arr_Pay_Type1(m1) = Fetch_Payhed_Rdr(1)
                                                    Arr_PhedId1(m1) = Fetch_Payhed_Rdr(2)

                                                End If
                                                m1 = m1 + 1
                                            End While
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        Finally
                                            Fetch_Payhed_Rdr.Close()
                                            Fetch_Payhed_Cmd = Nothing
                                        End Try
                                        TotSlabAmt1 = 0
                                    End If
                                    If Phed_Formulatype1 = "Achieved Target" Or Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Or Phed_Formulatype1 = "Earned Amount" Then
                                        If Phed_Formulatype1 = "Achieved Target" Then
                                            ' Arr_PhedId(loopvar) = Phed_Id1
                                            Arr_PFId(loopvar) = Phed_Id1
                                            m1 = 1
                                            Try
                                                Fetch_Payhed_Cmd = New SqlCommand("select Amt from Finact_Target where EId='" & (empid) & "'", FinActConn)
                                                Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                                Fetch_Payhed_Rdr.Read()
                                                If Fetch_Payhed_Rdr.HasRows = True Then
                                                    Target_Amt1 = CDbl(Fetch_Payhed_Rdr(0))
                                                End If
                                            Catch ex As Exception
                                                MsgBox(ex.Message)
                                            Finally
                                                If Fetch_Payhed_Rdr.HasRows = False Then
                                                    Target_Amt1 = CDbl(0)
                                                End If
                                                Fetch_Payhed_Rdr.Close()
                                                Fetch_Payhed_Cmd = Nothing
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
                                                    Fetch_Payhed_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                                    Fetch_Payhed_Rdr.Read()
                                                    If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                        Count_SlabId1 = Fetch_Payhed_Rdr(0)
                                                    End If
                                                Catch ex As Exception
                                                    MsgBox(ex.Message)
                                                Finally
                                                    Fetch_Payhed_Rdr.Close()
                                                    Fetch_Payhed_Cmd = Nothing
                                                End Try
                                                If Count_SlabId1 > 0 Then
                                                    Try
                                                        Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                                        Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                                        Fetch_Payhed_Rdr.Read()
                                                        If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                            RateId11 = Fetch_Payhed_Rdr(0)
                                                        End If
                                                    Catch ex As Exception
                                                        MsgBox(ex.Message)
                                                    Finally
                                                        Fetch_Payhed_Rdr.Close()
                                                        Fetch_Payhed_Cmd = Nothing
                                                    End Try
                                                End If

                                                While counter < Count_SlabId1

                                                    Try
                                                        Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Arr_PFId(loopvar)) & "'and PheadDelstatus=0 and SrateId='" & (RateId11) & "'", FinActConn)
                                                        Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                                                        Fetch_Payhed_Rdr.Read()
                                                        If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                            RateId11 = Fetch_Payhed_Rdr(0)
                                                            FromAmt1 = Fetch_Payhed_Rdr(1)
                                                            If Fetch_Payhed_Rdr(2) <> "Above" Then
                                                                UptoAmt1 = Fetch_Payhed_Rdr(2)
                                                            Else
                                                                UptoAmt1 = 9999999999999
                                                            End If

                                                            Rateval1 = Fetch_Payhed_Rdr(3)
                                                        End If

                                                    Catch ex As Exception
                                                        MsgBox(ex.Message)
                                                    Finally
                                                        If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                                                            recrd_flag = True
                                                        ElseIf Fetch_Payhed_Rdr.IsDBNull(0) = True Then
                                                            recrd_flag = False
                                                        End If
                                                        Fetch_Payhed_Rdr.Close()
                                                        Fetch_Payhed_Cmd = Nothing
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

                    Try
                        Fetch_Payhed_Cmd = New SqlCommand("select Amt from Finact_Target where EId='" & (empid) & "'", FinActConn)
                        Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                        Fetch_Payhed_Rdr.Read()
                        If Fetch_Payhed_Rdr.HasRows = True Then
                            Target_Amt = CDbl(Fetch_Payhed_Rdr(0))
                            ctr = ctr + 1
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        If Fetch_Payhed_Rdr.HasRows = False Then
                            Target_Amt = CDbl(0)
                        End If
                        Fetch_Payhed_Rdr.Close()
                        Fetch_Payhed_Cmd = Nothing
                    End Try
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
            arr_phed_amt(i) = TOTSLABAMT
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
                Fetch_Payhed_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and  PheadDelstatus=0 and PheadId='" & (Phed_Id1) & "'", FinActConn)
                Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                Fetch_Payhed_Rdr.Read()
                If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                    Count_SlabId = Fetch_Payhed_Rdr(0)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Fetch_Payhed_Rdr.Close()
                Fetch_Payhed_Cmd = Nothing
            End Try
        ElseIf phed_detls = False Then
            Try
                Fetch_Payhed_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and  PheadDelstatus=0 and PheadId='" & (Phed_Id) & "'", FinActConn)
                Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                Fetch_Payhed_Rdr.Read()
                If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                    Count_SlabId = Fetch_Payhed_Rdr(0)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Fetch_Payhed_Rdr.Close()
                Fetch_Payhed_Cmd = Nothing
            End Try
        End If


    End Sub




    Private Sub Fetch_Slab_RateId()

        Count_Slab_RateId()
        If phed_detls = True Then
            If Count_SlabId > 0 Then
                Try
                    Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0", FinActConn)
                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                    Fetch_Payhed_Rdr.Read()
                    If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                        RateId11 = Fetch_Payhed_Rdr(0)

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Fetch_Payhed_Rdr.Close()
                    Fetch_Payhed_Cmd = Nothing
                End Try
            End If
        ElseIf phed_detls = False Then
            If Count_SlabId > 0 Then
                Try
                    Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0", FinActConn)
                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                    Fetch_Payhed_Rdr.Read()
                    If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                        RateId = Fetch_Payhed_Rdr(0)

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Fetch_Payhed_Rdr.Close()
                    Fetch_Payhed_Cmd = Nothing
                End Try
            End If
        End If

    End Sub

    Private Sub Fetch_SrateId()
        i = 0
        Try
            Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0 ", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            While Fetch_Payhed_Rdr.Read()
                If Fetch_Payhed_Rdr.HasRows = True Then
                    arr_srateid(i) = Fetch_Payhed_Rdr(0)
                    i = i + 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'If Loan_Salry_Rdr.IsDBNull(0) = False Then
            'recrd_flag = True
            'Else'

            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try

    End Sub


    Private Sub Fetch_SrateId1()
        i = 0
        Try
            Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 ", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            While Fetch_Payhed_Rdr.Read()
                If Fetch_Payhed_Rdr.HasRows = True Then
                    arr_srateid1(i) = Fetch_Payhed_Rdr(0)
                    i = i + 1
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'If Loan_Salry_Rdr.IsDBNull(0) = False Then
            'recrd_flag = True
            'Else'

            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
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
                    Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id) & "'and PheadDelstatus=0 and SrateId='" & (arr_srateid(i)) & "'", FinActConn)
                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                    Fetch_Payhed_Rdr.Read()
                    If Fetch_Payhed_Rdr.HasRows = True Then
                        recrd_flag = True
                        RateId1 = Fetch_Payhed_Rdr(0)
                        FromAmt = Fetch_Payhed_Rdr(1)
                        If Fetch_Payhed_Rdr(2) <> "Above" Then
                            UptoAmt = Fetch_Payhed_Rdr(2)
                        Else
                            UptoAmt = 9999999999999
                        End If
                        Rateval = Fetch_Payhed_Rdr(3)
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
                    If Fetch_Payhed_Rdr.HasRows = False Then

                        recrd_flag = False
                    End If
                    Fetch_Payhed_Rdr.Close()
                    Fetch_Payhed_Cmd = Nothing
                End Try
            ElseIf phed_detls = True Then
                Try
                    Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 and SrateId='" & (arr_srateid1(i)) & "'", FinActConn)
                    Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
                    Fetch_Payhed_Rdr.Read()
                    If Fetch_Payhed_Rdr.IsDBNull(0) = False Then
                        recrd_flag = True
                        RateId11 = Fetch_Payhed_Rdr(0)
                        FromAmt = Fetch_Payhed_Rdr(1)
                        If Fetch_Payhed_Rdr(2) <> "Above" Then
                            UptoAmt = Fetch_Payhed_Rdr(2)
                        Else
                            UptoAmt = 9999999999999
                        End If
                        Rateval = Fetch_Payhed_Rdr(3)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    'If Loan_Salry_Rdr.IsDBNull(0) = False Then
                    'recrd_flag = True
                    'Else'
                    If Fetch_Payhed_Rdr.IsDBNull(0) = True Then
                        recrd_flag = False
                    End If
                    Fetch_Payhed_Rdr.Close()
                    Fetch_Payhed_Cmd = Nothing
                End Try
            End If
            'If LblBscSlry.Text <> "" Then
            If (phed_detls = False Or recursve_flag = True) And totslab_flag = True Then
                BscSlry = BscSry_cng
            Else
                ' BscSlry = CDbl(LblBscSlry.Text)
                BscSlry = CDbl(BscSlry)
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

                    arr_phed_amt(i) = TOTSLABAMT
                    'lst_cntr).SubItems(4)

                ElseIf recrd_flag = False Then
                    arr_phed_amt(i) = 0
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
            Fetch_Payhed_Cmd = New SqlCommand("select empvpfPcent from FinActEmpPfEsi where emppfdelstatus=1 and emppfconcrnid='" & (empid) & "'", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            Fetch_Payhed_Rdr.Read()
            If Fetch_Payhed_Rdr.HasRows = True Then
                VPF_Pcent = Fetch_Payhed_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try

    End Sub

    Private Function recfun_payhead(ByVal headname As String, ByVal headid As Integer) As Object

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
            Fetch_Payhed_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PheadId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (headid) & "' ", FinActConn)
            Fetch_Payhed_rdr = Fetch_Payhed_Cmd.ExecuteReader
            While Fetch_Payhed_rdr.Read()
                If Fetch_Payhed_rdr.IsDBNull(0) = False Then
                    Arr_PFId(m) = Fetch_Payhed_rdr(0)
                    Arr_Pay_Type(m) = Fetch_Payhed_rdr(1)
                    Arr_PhedId(m) = Fetch_Payhed_rdr(2)
                End If
                m = m + 1
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Payhed_rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try

        Dim contr As Integer = 0
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&Recursive begin------------------------------------
        While contr < m
            counter = 0
            j1 = 0
            l1 = 0
            Try
                Fetch_Payhed_Cmd = New SqlCommand("select PheadName,PheadComp,PheadType,PheadCalmtd,PhFormulatype,PheadId from FinactPayHead where PheadDelstatus=0 and PheadId='" & (Arr_PFId(contr)) & "'", FinActConn) 'and PheadCalmtd<>'As User Defined Value' 
                Fetch_Payhed_rdr = Fetch_Payhed_Cmd.ExecuteReader
                Fetch_Payhed_rdr.Read()
                If Fetch_Payhed_rdr.HasRows = True Then
                    Payhead_Name1 = Fetch_Payhed_rdr(0)
                    Arr_Ern_Deduc1(j1) = Fetch_Payhed_rdr(1)
                    Phed_Comp1 = Fetch_Payhed_rdr(1)
                    Arr_Phed_Type21(l1) = Fetch_Payhed_rdr(2)
                    Phed_Calmtd1 = Fetch_Payhed_rdr(3)
                    Phed_Formulatype1 = Fetch_Payhed_rdr(4)
                    Phed_Id1 = Fetch_Payhed_rdr(5)
                    j1 = j1 + 1
                    l1 = l1 + 1
                End If '--
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Fetch_Payhed_rdr.Close()
                Fetch_Payhed_Cmd = Nothing
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
                                Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Phed_Id1) & "'and PheadDelstatus=0 and SrateId='" & (rateid11) & "'", FinActConn)
                                Fetch_Payhed_rdr = Fetch_Payhed_Cmd.ExecuteReader
                                Fetch_Payhed_rdr.Read()
                                If Fetch_Payhed_rdr.IsDBNull(0) = False Then
                                    recrd_flag = True
                                    rateid11 = Fetch_Payhed_rdr(0)
                                    FromAmt = Fetch_Payhed_rdr(1)
                                    If Fetch_Payhed_rdr(2) <> "Above" Then
                                        UptoAmt = Fetch_Payhed_rdr(2)
                                    Else
                                        UptoAmt = 9999999999999
                                    End If
                                    Rateval = Fetch_Payhed_rdr(3)
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                If Fetch_Payhed_rdr.IsDBNull(0) = True Then
                                    recrd_flag = False
                                End If
                                Fetch_Payhed_rdr.Close()
                                Fetch_Payhed_Cmd = Nothing
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
                                Fetch_Payhed_Cmd = New SqlCommand("select EmpPayformulaid,EmpPayType,PheadId from Finact_EmpPayHeadFormula inner join FinactPayHead on Finact_EmpPayHeadFormula.PayheadConId=FinactPayHead.PheadId where Empdelstatus=0 and PheadDelstatus=0 and PayheadConId='" & (Phed_Id1) & "'", FinActConn)
                                Fetch_Payhed_rdr = Fetch_Payhed_Cmd.ExecuteReader
                                While Fetch_Payhed_rdr.Read()
                                    If Fetch_Payhed_rdr.IsDBNull(0) = False Then
                                        Arr_PFid1(m1) = Fetch_Payhed_rdr(0)
                                        Arr_Pay_Type1(m1) = Fetch_Payhed_rdr(1)
                                        Arr_PhedId1(m1) = Fetch_Payhed_rdr(2)
                                    End If
                                    m1 = m1 + 1
                                End While
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                Fetch_Payhed_rdr.Close()
                                Fetch_Payhed_Cmd = Nothing
                            End Try
                            TotSlabamt1 = 0

                        End If
                        If Phed_Formulatype1 = "Achieved Target" Or Phed_Formulatype1 = "Compound(stepwise)" Or Phed_Formulatype1 = "Flat Rate" Or Phed_Formulatype1 = "Earned Amount" Then
                            If Phed_Formulatype1 = "Achieved Target" Then
                                ' Arr_PhedId(loopvar) = Phed_Id1
                                Arr_PFId(loopvar) = Phed_Id1
                                m1 = 1
                                Try
                                    Fetch_Payhed_Cmd = New SqlCommand("select Amt from Finact_Target where EId='" & (Empid) & "'", FinActConn)
                                    Fetch_Payhed_rdr = Fetch_Payhed_Cmd.ExecuteReader
                                    Fetch_Payhed_rdr.Read()
                                    If Fetch_Payhed_rdr.HasRows = True Then
                                        Target_Amt1 = CDbl(Fetch_Payhed_rdr(0))
                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                Finally
                                    If Fetch_Payhed_rdr.HasRows = False Then
                                        Target_Amt1 = CDbl(0)
                                    End If
                                    Fetch_Payhed_rdr.Close()
                                    Fetch_Payhed_Cmd = Nothing
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
                                    Fetch_Payhed_Cmd = New SqlCommand("select count(SrateId) from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                    Fetch_Payhed_rdr = Fetch_Payhed_Cmd.ExecuteReader
                                    Fetch_Payhed_rdr.Read()
                                    If Fetch_Payhed_rdr.IsDBNull(0) = False Then
                                        Count_Slabid1 = Fetch_Payhed_rdr(0)
                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                Finally
                                    Fetch_Payhed_rdr.Close()
                                    Fetch_Payhed_Cmd = Nothing
                                End Try
                                If Count_Slabid1 > 0 Then
                                    Try
                                        Fetch_Payhed_Cmd = New SqlCommand("select SrateId from FinactslabRate where SrateDelStatus=0 and SrateConId='" & (Arr_PFId(loopvar)) & "'", FinActConn)
                                        Fetch_Payhed_rdr = Fetch_Payhed_Cmd.ExecuteReader
                                        Fetch_Payhed_rdr.Read()
                                        If Fetch_Payhed_rdr.IsDBNull(0) = False Then
                                            rateid11 = Fetch_Payhed_rdr(0)
                                        End If
                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                    Finally
                                        Fetch_Payhed_rdr.Close()
                                        Fetch_Payhed_Cmd = Nothing
                                    End Try

                                End If

                                While counter < Count_Slabid1

                                    Try
                                        Fetch_Payhed_Cmd = New SqlCommand("select SrateId,SrateFAmt,SrateUpAmt,Sratevalue from FinactslabRate inner join FinactPayHead on Finactslabrate.SrateConId=FinactPayHead.PheadId where SrateDelStatus=0 and PheadId='" & (Arr_PFId(loopvar)) & "'and PheadDelstatus=0 and SrateId='" & (rateid11) & "'", FinActConn)
                                        Fetch_Payhed_rdr = Fetch_Payhed_Cmd.ExecuteReader
                                        Fetch_Payhed_rdr.Read()
                                        If Fetch_Payhed_rdr.IsDBNull(0) = False Then
                                            rateid11 = Fetch_Payhed_rdr(0)
                                            FromAmt1 = Fetch_Payhed_rdr(1)
                                            If Fetch_Payhed_rdr(2) <> "Above" Then
                                                UptoAmt1 = Fetch_Payhed_rdr(2)
                                            Else
                                                UptoAmt1 = 9999999999999
                                            End If

                                            Rateval1 = Fetch_Payhed_rdr(3)
                                        End If

                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                    Finally
                                        If Fetch_Payhed_rdr.IsDBNull(0) = False Then
                                            recrd_flag = True
                                        ElseIf Fetch_Payhed_rdr.IsDBNull(0) = True Then
                                            recrd_flag = False
                                        End If
                                        Fetch_Payhed_rdr.Close()
                                        Fetch_Payhed_Cmd = Nothing
                                    End Try
                                    'If LblBscSlry.Text <> "" Then
                                    'BscSlry1 = CDbl(LblBscSlry.Text)
                                    BscSlry1 = CDbl(BscSlry)
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
            BscSlry = CDbl(BscSlry)

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
            Fetch_Payhed_Cmd = New SqlCommand("select PheadRate from FinactPayhead where PheadId='" & (Phed_Id) & "'", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            Fetch_Payhed_Rdr.Read()
            If Fetch_Payhed_Rdr.HasRows = True Then
                UsrPhed_Amt = Fetch_Payhed_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try
    End Sub


    Private Sub Fetch_UsrPhed_Amt1()
        Try
            Fetch_Payhed_Cmd = New SqlCommand("select PheadRate from FinactPayhead where PheadId='" & (Phed_Id1) & "'", FinActConn)
            Fetch_Payhed_Rdr = Fetch_Payhed_Cmd.ExecuteReader
            Fetch_Payhed_Rdr.Read()
            If Fetch_Payhed_Rdr.HasRows = True Then
                UsrPhed_Amt = Fetch_Payhed_Rdr(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Payhed_Rdr.Close()
            Fetch_Payhed_Cmd = Nothing
        End Try
    End Sub



   

    Private Sub DtpkrFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrFrm.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            BtnSave.Focus()

        End If
    End Sub

    Private Sub ClrVal()

        LblEmpid.Text = ""
        lblDept.Text = ""
        lblDesig.Text = ""
        LblBscSlry.Text = ""
        LblGrossSlry.Text = ""
        txtAppPer.Clear()
        txtAppAmt.Clear()
        LblFnlSlry.Text = ""
        LblAmt.Text = ""

        If CmbxEname.SelectedIndex > 0 Then
            CmbxEname.SelectedIndex = 0
        End If
        If cmbxMode.SelectedIndex > 0 Then
            cmbxMode.SelectedIndex = 0
        End If
        If CmbxAppon.SelectedIndex > 0 Then
            CmbxAppon.SelectedIndex = 0
        End If
        DtpkrDt.Text = Today
        DtpkrFrm.Text = Today
        Label12.Visible = False
        CmbxAppon.Visible = False
        Label14.Visible = False
        txtAppPer.Visible = False
        txtAppAmt.Visible = True
        Label9.Visible = True
        LblAmt.Visible = False
        Label17.Visible = False
        Label9.Location = New System.Drawing.Point(278, 322)

        DtpkrDt.Focus()

    End Sub


    Private Sub BtnCancl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancl.Click
        PnlSrch.Visible = False
        LstAprsl.Visible = False
        LblSrchnm.Visible = False
        BtnSave.Text = "&Save"
        BtnFnd.Text = "&Find"
        Me.Size = New System.Drawing.Point(648, 572)
        ClrVal()
       

    End Sub

    Private Sub txtAppAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAppAmt.TextChanged
        If txtAppAmt.BackColor <> Color.White Then
            txtAppAmt.BackColor = Color.White
        End If
    End Sub

    Private Sub txtAppPer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAppPer.TextChanged
        If txtAppPer.BackColor <> Color.White Then
            txtAppPer.BackColor = Color.White
        End If
    End Sub


    Private Sub SaveRecrd()

        Try
            If add_flag = True Then
                Fetch_Ename_Cmd = New SqlCommand("Finact_Appraisal_Insert", FinActConn)
                Fetch_Ename_Cmd.CommandType = CommandType.StoredProcedure
                Fetch_Ename_Cmd.Parameters.AddWithValue("@ApDt", DtpkrDt.Value.Date)
                Fetch_Ename_Cmd.Parameters.AddWithValue("@ApEid", LblEmpid.Text)
                Fetch_Ename_Cmd.Parameters.AddWithValue("@Apadusrid", Current_UsrId)
                Fetch_Ename_Cmd.Parameters.AddWithValue("@Apaddt", Now)
                Fetch_Ename_Cmd.Parameters.AddWithValue("@Apdelstatus", 0)
            ElseIf add_flag = False Then
                Fetch_Ename_Cmd = New SqlCommand("Finact_Appraisal_Edit", FinActConn)
                Fetch_Ename_Cmd.CommandType = CommandType.StoredProcedure
                Fetch_Ename_Cmd.Parameters.AddWithValue("@ApEid", LblEmpid.Text)
                Fetch_Ename_Cmd.Parameters.AddWithValue("@Apedtusrid", Current_UsrId)
                Fetch_Ename_Cmd.Parameters.AddWithValue("@Apedtdt", Now)

            End If
            Fetch_Ename_Cmd.Parameters.AddWithValue("@ApBscSlry", CDbl(LblBscSlry.Text))
            Fetch_Ename_Cmd.Parameters.AddWithValue("@ApGrossSlry", CDbl(LblGrossSlry.Text))
            Fetch_Ename_Cmd.Parameters.AddWithValue("@ApMode", cmbxMode.Text)
            If cmbxMode.Text = "Value" Then
                Fetch_Ename_Cmd.Parameters.AddWithValue("@ApAmt", CDbl(txtAppAmt.Text))
                Fetch_Ename_Cmd.Parameters.AddWithValue("@ApOn", " ")
                Fetch_Ename_Cmd.Parameters.AddWithValue("@ApPerc", " ")

            ElseIf cmbxMode.Text = "Percentage" Then

                Fetch_Ename_Cmd.Parameters.AddWithValue("@ApOn", CmbxAppon.Text)
                Fetch_Ename_Cmd.Parameters.AddWithValue("@ApPerc", CDbl(txtAppPer.Text))
                Fetch_Ename_Cmd.Parameters.AddWithValue("@ApAmt", CDbl(LblAmt.Text))
            End If



            Fetch_Ename_Cmd.Parameters.AddWithValue("@ApFnlSlry", CDbl(LblFnlSlry.Text))
            Fetch_Ename_Cmd.Parameters.AddWithValue("@ApEfDt", DtpkrFrm.Value.Date)

            Fetch_Ename_Cmd.ExecuteNonQuery()
            If add_flag = True Then
                MsgBox("Record has been Saved Successfully.", MsgBoxStyle.Information, "Save")
            ElseIf add_flag = False Then
                MsgBox("Record has been Updated Successfully.", MsgBoxStyle.Information, "Edit")

            End If

           

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
        End Try


    End Sub


    Private Sub Updt_BscSlry()

        Try
            Fetch_Ename_Cmd = New SqlCommand("update FinactEmpmstr set empgrade=@empgrade where empid='" & (LblEmpid.Text) & "'", FinActConn)
            Fetch_Ename_Cmd.Parameters.AddWithValue("@empgrade", fnlslry)
            Fetch_Ename_Cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
        End Try

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            add_flag = True
            fnlslry = CDbl(LblFnlSlry.Text)
            SaveRecrd()
            Updt_BscSlry()
            ClrVal()
            DtpkrDt.Focus()
        ElseIf BtnSave.Text = "&Edit" Then
            add_flag = False
            SaveRecrd()
            Updt_BscSlry()
            BtnSave.Text = "&Save"
            BtnFnd.Text = "&Find"
            ClrVal()
            DtpkrDt.Focus()
        End If
    End Sub


    Private Sub Fetch_Recrds()
        no_recrd = False

        Try
            Fetch_Ename_Cmd = New SqlCommand("Select distinct(ApEid),FinactEmpmstr.empname from  FinactEmpAppraisal inner join FinactEmpmstr on FinactEmpmstr.empid=FinactEmpAppraisal.ApEid where Apdelstatus=0 ", FinActConn)
            da = New SqlDataAdapter(Fetch_Ename_Cmd)
            ds = New DataSet(Fetch_Ename_Cmd.CommandText)
            da.Fill(ds)
            CmbxSrchEmp.DataSource = ds.Tables(0)
            Me.CmbxSrchEmp.ValueMember = "ApEid"
            Me.CmbxSrchEmp.DisplayMember = "empname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
           
        End Try


    End Sub



    Private Sub BtnFnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd.Click
        If BtnFnd.Text = "&Find" Then
            Fetch_Recrds()
            If CmbxSrchEmp.Items.Count = 0 Then
                no_recrd = True
            End If
            If no_recrd = False Then
                Me.Size = New System.Drawing.Point(648, 684)
                PnlApraisl.Enabled = False
                PnlSrch.Visible = True
                BtnSave.Text = "&Edit"
                BtnFnd.Text = "&Delete"
                CmbxSrchEmp.Focus()
            ElseIf no_recrd = True Then
                MsgBox("System has found no record", MsgBoxStyle.Information, "Find")
                DtpkrDt.Focus()

            End If
        ElseIf BtnFnd.Text = "&Delete" Then

            cnfrmmsg = MsgBox("Are you sure to delete record?", MsgBoxStyle.YesNo, "Delete")
            If cnfrmmsg = vbYes Then

                Try
                    Fetch_Ename_Cmd = New SqlCommand("Finact_Appraisal_Delete", FinActConn)
                    Fetch_Ename_Cmd.CommandType = CommandType.StoredProcedure
                    Fetch_Ename_Cmd.Parameters.AddWithValue("@ApEid", LblEmpid.Text)
                    Fetch_Ename_Cmd.Parameters.AddWithValue("@ApDt", DtpkrDt.Value.Date)
                    Fetch_Ename_Cmd.Parameters.AddWithValue("@Apdelusrid", Current_UsrId)
                    Fetch_Ename_Cmd.Parameters.AddWithValue("@Apdeldt", Now)
                    Fetch_Ename_Cmd.Parameters.AddWithValue("@Apdelstatus", 1)
                    Fetch_Ename_Cmd.ExecuteNonQuery()
                    MsgBox("Record has been Deleted Successfully.", MsgBoxStyle.Information, "Delete")
                    ClrVal()
                    BtnSave.Text = "&Save"
                    BtnFnd.Text = "&Find"
                    DtpkrDt.Enabled = True
                    DtpkrDt.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Fetch_Ename_Cmd = Nothing
                End Try
            End If

        End If

    End Sub

    Private Sub CmbxSrchEmp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSrchEmp.GotFocus
        If CmbxSrchEmp.Items.Count > 0 Then
            CmbxSrchEmp.SelectedIndex = 0
            CmbxSrchEmp.DroppedDown = True
            '  LblSrchid.Text = CmbxSrchEmp.SelectedValue
        End If
    End Sub

    Private Sub CmbxSrchEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSrchEmp.KeyDown
        LblSrchid.Text = CmbxSrchEmp.SelectedValue
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            If CmbxSrchEmp.Items.Count > 0 Then
                EmId = CmbxSrchEmp.SelectedValue

                PnlSrch.Visible = False
                LstAprsl.Visible = True
                LblSrchnm.Visible = True
                Me.Size = New System.Drawing.Point(648, 706)
                LblSrchnm.Location = New System.Drawing.Point(183, 497)
                LstAprsl.Location = New System.Drawing.Point(4, 528)
                LblSrchnm.Text = "Appraisal Details of  " + CmbxSrchEmp.Text
                Fetch_DetailRecrds()
            End If
        End If
    End Sub

    Private Sub Fetch_DetailRecrds()

        Dim Lstvw As ListViewItem
        LstAprsl.Items.Clear()
        Try
            Fetch_Ename_Cmd = New SqlCommand("Select ApEfDt,ApBscSlry,ApGrossSlry,ApMode,ApOn,ApAmt,ApFnlSlry,ApDt,ApPerc from  FinactEmpAppraisal where ApEid='" & (EmId) & "'and Apdelstatus=0 ", FinActConn)
            Fetch_Ename_rdr = Fetch_Ename_Cmd.ExecuteReader

            While Fetch_Ename_rdr.Read()
                If Fetch_Ename_rdr.HasRows = True Then

                    Lstvw = LstAprsl.Items.Add(Fetch_Ename_rdr(0))
                    Lstvw.SubItems.Add(FormatNumber(Fetch_Ename_rdr(1), 2))
                    Lstvw.SubItems.Add(FormatNumber(Fetch_Ename_rdr(2), 2))
                    Lstvw.SubItems.Add(Fetch_Ename_rdr(3))
                    Lstvw.SubItems.Add(Fetch_Ename_rdr(4))
                    Lstvw.SubItems.Add(FormatNumber(Fetch_Ename_rdr(5), 2))
                    Lstvw.SubItems.Add(FormatNumber(Fetch_Ename_rdr(6), 2))
                    Lstvw.SubItems.Add(Fetch_Ename_rdr(7))
                    Lstvw.SubItems.Add(Fetch_Ename_rdr(8))
                End If
            End While
            If Fetch_Ename_rdr.HasRows = True Then

                If LstAprsl.Items.Count > 0 Then
                    LstAprsl.Focus()
                    LstAprsl.Items(0).Selected = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Fetch_Ename_rdr.HasRows = False Then
                MsgBox("System has found no record of '" & (CmbxSrchEmp.Text) & "'", MsgBoxStyle.Information, "Find")

            End If

            Fetch_Ename_rdr.Close()
            Fetch_Ename_Cmd = Nothing
        End Try


    End Sub


    Private Sub LstAprsl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstAprsl.DoubleClick

        Dim indx As Integer

        indx = LstAprsl.SelectedItems(0).Index

        Sel_Date = LstAprsl.Items(indx).SubItems(7).Text
        Fetch_Max_recrd()
        If Max_dt = Sel_Date Then


            DtpkrFrm.Text = LstAprsl.Items(indx).SubItems(0).Text
            LblBscSlry.Text = LstAprsl.Items(indx).SubItems(1).Text
            LblGrossSlry.Text = LstAprsl.Items(indx).SubItems(2).Text
            cmbxMode.Text = LstAprsl.Items(indx).SubItems(3).Text

            CmbxAppon.Text = LstAprsl.Items(indx).SubItems(4).Text
            If CmbxAppon.Text <> "" Then
                LblAmt.Visible = True
                txtAppPer.Visible = True
                txtAppAmt.Visible = False
                Label9.Visible = False
                Label17.Visible = True
                Label12.Visible = True
                CmbxAppon.Visible = True
                Label14.Visible = True

                LblAmt.Text = LstAprsl.Items(indx).SubItems(5).Text
                txtAppPer.Text = LstAprsl.Items(indx).SubItems(8).Text
            ElseIf CmbxAppon.Text = "" Then
                LblAmt.Visible = False
                txtAppPer.Visible = False
                txtAppAmt.Visible = True
                Label9.Visible = True
                Label17.Visible = False
                Label12.Visible = False
                CmbxAppon.Visible = False
                Label14.Visible = False
                txtAppAmt.Text = LstAprsl.Items(indx).SubItems(5).Text
            End If
            LblFnlSlry.Text = LstAprsl.Items(indx).SubItems(6).Text
            DtpkrDt.Text = LstAprsl.Items(indx).SubItems(7).Text
            LblEmpid.Text = EmId
            Fetch_Dept_Desi()
            PnlApraisl.Enabled = True
            LblSrchnm.Visible = False
            Me.Size = New System.Drawing.Point(648, 572)

            LstAprsl.Visible = False
            DtpkrDt.Enabled = False
            CmbxEname.Enabled = False

            cmbxMode.Focus()
        Else
            MsgBox("Can't update it as this is not the Recent Appraisal", MsgBoxStyle.Information, "Record")

        End If
    End Sub



    Private Sub Fetch_Dept_Desi()

        Try
            Fetch_Ename_Cmd = New SqlCommand("select deptname from finactDept inner join FinactEmpmstr on FinactEmpmstr.empdeptid=finactdept.deptid where FinactEmpmstr.empid='" & EmId & "'", FinActConn)
            Fetch_Ename_rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_rdr.Read()
            If Fetch_Ename_rdr.HasRows = True Then
                lblDept.Text = Fetch_Ename_rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_rdr.Close()
        End Try

        Try
            Fetch_Ename_Cmd = New SqlCommand("select desiname from finactDesi inner join FinactEmpmstr on FinactEmpmstr.empdesiid=finactDesi.Desiid where FinactEmpmstr.empid='" & EmId & "'", FinActConn)
            Fetch_Ename_rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_rdr.Read()
            If Fetch_Ename_rdr.HasRows = True Then
                lblDesig.Text = Fetch_Ename_rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_rdr.Close()
        End Try


    End Sub


    Private Sub Fetch_MaxSlry()

        Try
            Fetch_Ename_Cmd = New SqlCommand("select max(AslryDt) from FinactAutoSalary where AslryEmpid='" & EmId & "'and Apdelstatus=0", FinActConn)
            Fetch_Ename_rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_rdr.Read()
            If Fetch_Ename_rdr.HasRows = True Then
                Max_dt = Fetch_Ename_rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_rdr.Close()
        End Try


    End Sub



    Private Sub Fetch_Max_recrd()

        Try
            Fetch_Ename_Cmd = New SqlCommand("select max(ApDt) from FinactEmpAppraisal where ApEid='" & EmId & "'and Apdelstatus=0", FinActConn)
            Fetch_Ename_rdr = Fetch_Ename_Cmd.ExecuteReader
            Fetch_Ename_rdr.Read()
            If Fetch_Ename_rdr.HasRows = True Then
                Max_dt = Fetch_Ename_rdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Fetch_Ename_Cmd = Nothing
            Fetch_Ename_rdr.Close()
        End Try


    End Sub




End Class
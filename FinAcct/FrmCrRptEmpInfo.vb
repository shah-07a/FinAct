Imports System.Collections
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.Data.Odbc
'Imports System.Data.Odbc.OdbcParameter
Public Class FrmCrRptEmpInfo
    Dim Odbccon As Odbc.OdbcConnection
    Dim OdbcCmd As OdbcCommand
    Dim OdbcRdr As OdbcDataReader
    Dim Odbccon1 As Odbc.OdbcConnection
    Dim OdbcCmd1 As OdbcCommand
    Dim OdbcRdr1 As OdbcDataReader
    Dim datatbl As New DataTable
    Dim OdbcDa As OdbcDataAdapter
    Dim OdbcDa1 As OdbcDataAdapter
    Dim Tbl_Col_id As String
    Dim Col_Condition_val As Integer
    Dim Select_Case_No As Integer
    Dim TellRptstatus As Boolean
    Dim Mindt, Maxdt As Date
    Dim CRptEmpInfo1 As New CrRptEmpInfo
    Dim SqlCmd As SqlCommand
    Dim sqlRdr As SqlDataReader
    'Dim SqlCmd As SqlCommand
    Dim SqlDa As SqlDataAdapter
    Dim SqlCmd1 As SqlCommand
    Dim sqlRdr1 As SqlDataReader
    Dim SqlDa1 As SqlDataAdapter
    



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 1025
            Me.Height = 656
            Me.Top = 0
            TellRptstatus = True
            If CmbxSelcat.Items.Count > 0 Then
                CmbxSelcat.DroppedDown = True
                CmbxSelcat.Focus()
            Else
                CmbxSelcat.DroppedDown = False

            End If


            DelRecfromtemptbl()
            Fill_tempTables()
            Update_tbl_Tempempinfo()
            CoprofileParamsEmpInfo()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub CoprofileParamsEmpInfo()

        Try
            Dim ParmVal1 As ParameterValues = New ParameterValues()
            Dim DisVal1 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal1.Value = 1
            ParmVal1.Add(DisVal1)

            Dim ParmVal2 As ParameterValues = New ParameterValues()
            Dim DisVal2 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal2.Value = 1
            ParmVal2.Add(DisVal2)

            Dim ParmVal3 As ParameterValues = New ParameterValues()
            Dim DisVal3 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal3.Value = 1
            ParmVal3.Add(DisVal3)

            Dim ParmVal4 As ParameterValues = New ParameterValues()
            Dim DisVal4 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal4.Value = 1
            ParmVal4.Add(DisVal4)

            Dim ParmVal5 As ParameterValues = New ParameterValues()
            Dim DisVal5 As ParameterDiscreteValue = New ParameterDiscreteValue
            DisVal5.Value = 1
            ParmVal5.Add(DisVal5)
            Dim nparm As New OdbcParameter("@@N", Odbc.OdbcType.VarBinary, 200)
            Dim aparm As New OdbcParameter("@@a", Odbc.OdbcType.VarChar, 100)
            Dim aparm1 As New OdbcParameter("@@a1", Odbc.OdbcType.VarChar, 100)
            Dim conparm As New OdbcParameter("@@coN", Odbc.OdbcType.VarChar, 100)
            Dim con2parm As New OdbcParameter("@@con2", Odbc.OdbcType.VarChar, 100)
            Dim con3parm As New OdbcParameter("@@con3", Odbc.OdbcType.VarChar, 100)
            Dim pinparm As New OdbcParameter("@@pin", Odbc.OdbcType.VarChar, 100)
            Dim ctyparm As New OdbcParameter("@@cty", Odbc.OdbcType.VarChar, 100)

            'Dim nparm As New SqlParameter("@@N", SqlDbType.VarBinary, 200)
            'Dim aparm As New SqlParameter("@@a", SqlDbType.VarChar, 100)
            'Dim aparm1 As New SqlParameter("@@a1", SqlDbType.VarChar, 100)
            'Dim conparm As New SqlParameter("@@coN", SqlDbType.VarChar, 100)
            'Dim con2parm As New SqlParameter("@@con2", SqlDbType.VarChar, 100)
            'Dim con3parm As New SqlParameter("@@con3", SqlDbType.VarChar, 100)
            'Dim pinparm As New SqlParameter("@@pin", SqlDbType.VarChar, 100)
            'Dim ctyparm As New SqlParameter("@@cty", SqlDbType.VarChar, 100)
            Dim DcrypConame As New EnCryp_DeCryp_String

            Try
                If TellRptstatus = False Then
                    Fetch_CrRpt()
                End If

                ' Odbccon1 = New SqlConnection("Driver={SQL Native Client};Server=.;Database=hrprdata08;Uid=sa;Pwd=sa;")
                'Odbccon1.Open()
                OdbcCmd1 = New OdbcCommand("exec Tempcncrpt nparm,aparm,aparm1,conparm,conparm2,conparm3,pinparm,ctyparm ", FinactOdbcCon1)
                OdbcCmd1.CommandType = CommandType.StoredProcedure '
                OdbcRdr1 = OdbcCmd1.ExecuteReader
                While OdbcRdr1.Read()
                    Dim co As Object = DcrypConame.Decrypt(OdbcRdr1("col1"))
                    Dim co1 As Object = OdbcRdr1(1)
                    Dim co2 As Object = OdbcRdr1(5) & "-" & OdbcRdr1(6)
                    Dim co3 As Object = OdbcRdr1(2)
                    ParmVal1.AddValue(co)
                    ParmVal2.AddValue(co1)
                    ParmVal3.AddValue(co2)
                    ParmVal4.AddValue(co3)
                    Dim Rptstr As String = ""
                    If Trim(CmbxSelcat.Text) = "All" Then
                        Rptstr = ("Report of all Employee(s)").ToUpper
                    End If

                    ParmVal5.AddValue(Rptstr)
                    CRptEmpInfo1.DataDefinition.ParameterFields("Coname").ApplyCurrentValues(ParmVal1)
                    CRptEmpInfo1.DataDefinition.ParameterFields("Adrs").ApplyCurrentValues(ParmVal2)
                    CRptEmpInfo1.DataDefinition.ParameterFields("Csc").ApplyCurrentValues(ParmVal3)
                    CRptEmpInfo1.DataDefinition.ParameterFields("con").ApplyCurrentValues(ParmVal4)
                    CRptEmpInfo1.DataDefinition.ParameterFields("Rpttype").ApplyCurrentValues(ParmVal5)
                End While

                CrVewEmpInfo.ReportSource = CRptEmpInfo1
            Catch ex As SqlException
                MsgBox(ex.Number & " " & ex.Message)
            Finally
                OdbcCmd1.Dispose()
                OdbcRdr1.Close()

            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSelcat_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSelcat.GotFocus
        
        Me.Panel1.Height = 35
        Me.CrVewEmpInfo.Top = 53
    End Sub

    Private Sub CmbxSelcat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSelcat.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbxSelcat_Leave(sender, e)
        End If
    End Sub

    Private Sub CmbxSelcat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSelcat.Leave

        If CmbxSelcat.SelectedIndex = -1 Then
            MsgBox("Please select an item to proceed", MsgBoxStyle.Information, "Select an item")
            CmbxSelcat.Focus()
        Else
            Create_xcontrol()
        End If
    End Sub

    Private Sub CmbxSelVal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSelVal.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbxSelVal_Leave(sender, e)
        End If
    End Sub

    Private Sub CmbxSelVal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSelVal.Leave

        If Trim(CmbxSelcat.Text) = "Category/Grade" Then
            If Not IsNumeric(CmbxSelVal.Text) = True Then
                CmbxSelVal.Focus()
                CmbxSelVal.SelectAll()
                Exit Sub
            Else
               
                Exit Sub
            End If
        End If

        If (CmbxSelVal.SelectedIndex) <> -1 Then
            If Trim(CmbxSelcat.Text) = "Employee's Name" Or Trim(CmbxSelcat.Text) = "Employment Status" Or Trim(CmbxSelcat.Text) = "Department" Or Trim(CmbxSelcat.Text) = "Designation" Or Trim(CmbxSelcat.Text) = "Payment Mode" Then

                TellRptstatus = False
                CoprofileParamsEmpInfo()
            ElseIf Trim(CmbxSelcat.Text) = "Employee's Id" Then

                'Odbccon = New SqlConnection("Driver={SQL Native Client};Server=.;Database=hrprdata08;Uid=sa;Pwd=sa;")
                'odbccon.open()
                Dim Eid As Integer = CmbxSelVal.Text
                OdbcCmd = New OdbcCommand("select empid,empname from finactempmstr where empid > '" & (Eid) & "' order by empid ", FinactOdbcCon)
                Dim OdbcDa As New OdbcDataAdapter(OdbcCmd)
                Dim ds As New DataSet(OdbcCmd.CommandText)

                OdbcDa = New OdbcDataAdapter(OdbcCmd)
                ds = New DataSet(OdbcCmd.CommandText)
                OdbcDa.Fill(ds)
                CmbxSelval2.DataSource = ds.Tables(0)
                Me.CmbxSelval2.ValueMember = "empid"
                Me.CmbxSelval2.DisplayMember = ("empid")

            End If
        Else
            CmbxSelVal.Focus()

        End If

    End Sub

    
    Private Sub Create_xcontrol()
        Try
            'Odbccon = New SqlConnection("Driver={SQL Native Client};Server=.;Database=hrprdata08;Uid=sa;Pwd=sa;")
            'odbccon.open()
            OdbcCmd = New OdbcCommand("select * from tempempinfo order by empname", FinactOdbcCon)
            Dim OdbcDa As New OdbcDataAdapter(OdbcCmd)
            Dim ds As New DataSet(OdbcCmd.CommandText)
            OdbcDa.Fill(ds)
            CmbxSelVal.DataSource = ds.Tables(0)
            Label2.Text = ""
            Label3.Text = ""
            DtpDtFrom.Visible = False
            DtpDtTo.Visible = False
            CmbxSelval2.Visible = False
            CmbxSelVal.Visible = False
            Me.Panel1.Height = 85
            Me.CrVewEmpInfo.Top = 103

            Select Case Trim(CmbxSelcat.Text)
                Case "All"
                    Me.Panel1.Height = 35
                    Me.CrVewEmpInfo.Top = 53
                    TellRptstatus = False
                    CoprofileParamsEmpInfo()
                    Exit Select
                Case "Employee's Name"
                    OdbcDa1 = New OdbcDataAdapter("Select empid,empname from tempempinfo  order by empname ", FinactOdbcCon1)
                    Create_cmbxLbl()
                    Me.CmbxSelVal.ValueMember = "empid"
                    Me.CmbxSelVal.DisplayMember = ("empname")
                    '
                Case "Employee's Id"
                    Create_cmbxLbl()
                    Create_cmbxlbl2()
                    OdbcCmd = New OdbcCommand("select empid,empname from tempempinfo order by empid", FinactOdbcCon)
                    OdbcDa = New OdbcDataAdapter(OdbcCmd)
                    ds = New DataSet(OdbcCmd.CommandText)
                    OdbcDa.Fill(ds)
                    CmbxSelVal.DataSource = ds.Tables(0)
                    CmbxSelVal.Enabled = True
                    Me.CmbxSelVal.ValueMember = "empid"
                    Me.CmbxSelVal.DisplayMember = ("empid")

                Case "Date Of Birth"
                    Create_Dtplbl()
                    OdbcCmd = New OdbcCommand("select min(empdobdt),max(empdobdt) from tempempinfo", FinactOdbcCon)
                    OdbcRdr1 = OdbcCmd.ExecuteReader
                    OdbcRdr1.Read()
                    Me.DtpDtFrom.MinDate = OdbcRdr1(0)
                    Me.DtpDtFrom.MaxDate = OdbcRdr1(1)
                    Me.DtpDtTo.MinDate = OdbcRdr1(0)
                    Me.DtpDtTo.MaxDate = OdbcRdr1(1)
                    OdbcCmd.Dispose()
                    OdbcRdr1.Close()
                    '  Me.DtpDtFrom.Focus()
                    Me.DtpDtTo.Enabled = False
                    Exit Sub


                Case "Date Of Joining"
                    Create_Dtplbl()
                    OdbcCmd = New OdbcCommand("select min(empjndt),max(empjndt) from tempempinfo ", FinactOdbcCon)
                    OdbcRdr1 = OdbcCmd.ExecuteReader
                    OdbcRdr1.Read()
                    Me.DtpDtFrom.MinDate = OdbcRdr1(0)
                    Me.DtpDtFrom.MaxDate = OdbcRdr1(1)
                    Me.DtpDtTo.MinDate = OdbcRdr1(0)
                    Me.DtpDtTo.MaxDate = OdbcRdr1(1)
                    OdbcCmd.Dispose()
                    OdbcRdr1.Close()
                    'Me.DtpDtFrom.Focus()
                    Me.DtpDtTo.Enabled = False
                    Exit Sub
                Case "Payment Mode"
                    Create_cmbxLbl()
                   
                    Create_cmbxLbl()
                    OdbcCmd = New OdbcCommand("select distinct(emppaymode) from tempempinfo order by emppaymode ", FinactOdbcCon)
                    OdbcDa = New OdbcDataAdapter(OdbcCmd)
                    ds = New DataSet(OdbcCmd.CommandText)
                    OdbcDa.Fill(ds)
                    CmbxSelVal.DataSource = ds.Tables(0)
                    CmbxSelVal.Enabled = True
                    Me.CmbxSelVal.DisplayMember = ("emppaymode")
                Case "Department"
                    Create_cmbxLbl()
                    OdbcCmd = New OdbcCommand("select distinct(tempempinfo.deptname) from tempempinfo order by deptname ", FinactOdbcCon)
                    OdbcDa = New OdbcDataAdapter(OdbcCmd)
                    ds = New DataSet(OdbcCmd.CommandText)
                    OdbcDa.Fill(ds)
                    CmbxSelVal.DataSource = ds.Tables(0)
                    Me.CmbxSelVal.ValueMember = "deptname"
                    Me.CmbxSelVal.DisplayMember = ("deptname")
                Case "Designation"
                    Create_cmbxLbl()
                    OdbcCmd = New OdbcCommand("select distinct(desiname) from tempempinfo order by desiname ", FinactOdbcCon)
                    OdbcDa = New OdbcDataAdapter(OdbcCmd)
                    ds = New DataSet(OdbcCmd.CommandText)
                    OdbcDa.Fill(ds)
                    CmbxSelVal.DataSource = ds.Tables(0)
                    Me.CmbxSelVal.ValueMember = "desiname"
                    Me.CmbxSelVal.DisplayMember = ("desiname")
                Case "Category/Grade"
                    Create_cmbxLbl()
                    Create_cmbxlbl2()

                Case "Employment Status"
                    Create_cmbxLbl()
                    OdbcCmd = New OdbcCommand("select distinct(emplstatus) from tempempinfo  order by emplstatus ", FinactOdbcCon)
                    OdbcDa = New OdbcDataAdapter(OdbcCmd)
                    ds = New DataSet(OdbcCmd.CommandText)
                    OdbcDa.Fill(ds)
                    CmbxSelVal.DataSource = ds.Tables(0)
                    Me.CmbxSelVal.DisplayMember = ("emplstatus")
            End Select

        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            'Odbccon1.Close()
            OdbcCmd.Dispose()
        End Try
        


    End Sub
    Private Sub Create_cmbxLbl()
        'CmbxSelVal
        '
        Me.CmbxSelVal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

        If Trim(CmbxSelcat.Text) = "Category/Grade" Then
            Me.CmbxSelVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.CmbxSelVal.Text = ""
        Else
            Me.CmbxSelVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        End If
        Me.CmbxSelVal.FormattingEnabled = True
        Me.CmbxSelVal.Location = New System.Drawing.Point(119, 33)
        Me.CmbxSelVal.Name = "CmbxSelVal"
        Me.CmbxSelVal.Size = New System.Drawing.Size(717, 21)
        Me.CmbxSelVal.TabIndex = 2
        Me.CmbxSelVal.Visible = True
        'Label2
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Selection Value"

        Me.Panel1.Controls.Add(Me.CmbxSelVal)
        Me.Panel1.Controls.Add(Me.Label2)
    End Sub
    Private Sub Create_cmbxlbl2()
        'CmbxSelval2
        Me.CmbxSelval2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

        If Trim(CmbxSelcat.Text) = "Category/Grade" Then
            Me.CmbxSelval2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.CmbxSelval2.Text = ""
        Else
            Me.CmbxSelval2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        End If
        Me.CmbxSelval2.FormattingEnabled = True
        Me.CmbxSelval2.Location = New System.Drawing.Point(119, 59)
        Me.CmbxSelval2.Name = "CmbxSelval2"
        Me.CmbxSelval2.Size = New System.Drawing.Size(717, 21)
        Me.CmbxSelval2.TabIndex = 3
        Me.CmbxSelval2.Visible = True
        'Label3
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Selection Value"

        Me.Panel1.Controls.Add(Me.CmbxSelval2)
        Me.Panel1.Controls.Add(Me.Label3)
    End Sub
    Private Sub Create_Dtplbl()
        'DtpDtFrom
        '
        Me.DtpDtFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpDtFrom.CustomFormat = "dd/MM/yyyy"
        Me.DtpDtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDtFrom.Location = New System.Drawing.Point(119, 33)
        Me.DtpDtFrom.Name = "DtpDtFrom"
        Me.DtpDtFrom.Size = New System.Drawing.Size(161, 20)
        Me.DtpDtFrom.TabIndex = 2
        Me.DtpDtFrom.Visible = True
        '
        'DtpDtTo
        '
        Me.DtpDtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpDtTo.CustomFormat = "dd/MM/yyyy"
        Me.DtpDtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDtTo.Location = New System.Drawing.Point(119, 59)
        Me.DtpDtTo.Name = "DtpDtTo"
        Me.DtpDtTo.Size = New System.Drawing.Size(161, 20)
        Me.DtpDtTo.TabIndex = 3
        Me.DtpDtTo.Visible = True
        'Label()
        'Label2
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "From Date"

        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)


        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "To Date"

        Me.Panel1.Controls.Add(Me.DtpDtTo)
        Me.Panel1.Controls.Add(Me.DtpDtFrom)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
    End Sub

    Private Sub CmbxSelval2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxSelval2.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbxSelval2_Leave(sender, e)
        End If


    End Sub

    Private Sub CmbxSelval2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSelval2.Leave
        If CmbxSelval2.Text <> "" Then
            If Trim(CmbxSelcat.Text) = "Category/Grade" Then
                If Not IsNumeric(CmbxSelval2.Text) = True Or Trim(CmbxSelval2.Text) < Trim(CmbxSelVal.Text) Then
                    CmbxSelval2.Focus()
                    CmbxSelval2.SelectAll()
                    Exit Sub
                End If
            End If
            TellRptstatus = False
            CoprofileParamsEmpInfo()
        Else
            CmbxSelval2.Focus()
        End If
    End Sub
    Private Sub Fetch_CrRpt()
        Try
            ' Odbccon1 = New SqlConnection("Driver={SQL Native Client};Server=.;Database=hrprdata08;Uid=sa;Pwd=sa;")
            'Odbccon1.Open()
            datatbl = New DataTable
            Dim ds As New DataSet

            Select Case Trim(CmbxSelcat.Text)
                Case "All"
                    Me.Panel1.Height = 35
                    Me.CrVewEmpInfo.Top = 53
                    OdbcDa1 = New OdbcDataAdapter("SELECT * FROM tempempinfo order by empname", FinactOdbcCon1)
                Case "Employee's Name"
                    OdbcDa1 = New OdbcDataAdapter("Select * from tempempinfo where empname='" & (Trim(CmbxSelVal.Text)) & "'  order by empname ", FinactOdbcCon1)
                Case "Employee's Id"
                    OdbcDa1 = New OdbcDataAdapter("Select * from tempempinfo where empid between '" & (Trim(CmbxSelVal.SelectedValue)) & "' and '" & (Trim(CmbxSelval2.SelectedValue)) & "'  order by empid ", FinactOdbcCon1)
                Case "Date Of Birth"
                    OdbcDa1 = New OdbcDataAdapter("Select * from tempempinfo where empdobdt between '" & (Me.DtpDtFrom.Value.Date) & "' and '" & (Me.DtpDtTo.Value.Date) & "'  order by empdobdt ", FinactOdbcCon1)
                Case "Date Of Joining"
                    OdbcDa1 = New OdbcDataAdapter("Select * from tempempinfo where empjndt between '" & (Me.DtpDtFrom.Value.Date) & "' and '" & (Me.DtpDtTo.Value.Date) & "'  order by empjndt ", FinactOdbcCon1)
                Case "Payment Mode"
                    OdbcDa1 = New OdbcDataAdapter("Select * from tempempinfo where emppaymode ='" & (Trim(CmbxSelVal.Text)) & "'    order by empname ", FinactOdbcCon1)
                Case "Department"
                    OdbcDa1 = New OdbcDataAdapter("Select * from tempempinfo where deptname = '" & (Trim(CmbxSelVal.Text)) & "'  order by empname ", FinactOdbcCon1)
                Case "Designation"
                    OdbcDa1 = New OdbcDataAdapter("Select * from tempempinfo where desiname = '" & (Trim(CmbxSelVal.Text)) & "'  order by empname ", FinactOdbcCon1)
                Case "Category/Grade"
                    Dim minsal As Double = CDbl(CmbxSelVal.Text)
                    Dim maxsal As Double = CDbl(CmbxSelval2.Text)
                    Dim nparm1 As New OdbcParameter("@minsal", Odbc.OdbcType.Double, 30)
                    Dim nparm2 As New OdbcParameter("@maxsal", Odbc.OdbcType.Double, 30)

                    nparm2.Direction = ParameterDirection.Output
                    nparm1.Direction = ParameterDirection.Output
                    nparm1.Value = minsal
                    nparm2.Value = maxsal
                    OdbcCmd1.Parameters.Add(nparm1)
                    OdbcCmd1.Parameters.Add(nparm2)
                    OdbcCmd1 = New OdbcCommand("Temp_EmpGraderange", FinactOdbcCon1)
                    OdbcCmd1.CommandType = CommandType.StoredProcedure
                    OdbcRdr1 = OdbcCmd1.ExecuteReader
                    OdbcRdr1.Read()
                    OdbcDa1 = New OdbcDataAdapter(OdbcCmd1)

                Case "Employment Status"
                    OdbcDa1 = New OdbcDataAdapter("Select * from tempempinfo where emplstatus='" & (Trim(CmbxSelVal.Text)) & "'  order by empname ", FinactOdbcCon1)

            End Select
            OdbcRdr1.Close()
            datatbl.Clear()
            OdbcDa1.Fill(datatbl)
            OdbcDa1.Fill(ds)
            'Dim CRptEmpInfo1 As New CrRptEmpInfo
            CrRptEmpInfo1.Close()
            CRptEmpInfo1.SetDataSource(ds.Tables(0))
        Catch ex As SqlException
            MsgBox(ex.Number & " " & ex.Message)
        Finally
            'Odbccon1.Close()
            OdbcCmd.Dispose()
        End Try

    End Sub

    Private Sub DtpDtTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpDtTo.GotFocus

        Me.DtpDtTo.Enabled = True
        Me.DtpDtTo.Focus()
    End Sub

    Private Sub DtpDtTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpDtTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpDtFrom_Leave(sender, e)
        End If
    End Sub

    Private Sub DtpDtTo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpDtTo.Leave
        TellRptstatus = False
        CoprofileParamsEmpInfo()
    End Sub

    Private Sub DtpDtFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpDtFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpDtFrom_Leave(sender, e)
        End If
    End Sub

    Private Sub DtpDtFrom_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpDtFrom.Leave
        DtpDtTo.Enabled = True
        DtpDtTo.Focus()
        DtpDtTo.MinDate = DtpDtFrom.Value

    End Sub

    Private Sub CmbxSelcat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxSelcat.SelectedIndexChanged

    End Sub
    Private Sub Fill_tempTables()
        Try
            SqlCmd = New SqlCommand("select * from finactdept where depttype='WrkName' order by deptname", FinActConn1)
            sqlRdr = SqlCmd.ExecuteReader
            While sqlRdr.Read
                SqlCmd1 = New SqlCommand("insert into tempwrkname  values (@wrkid,@wrkname)", FinActConn)
                SqlCmd1.Parameters.AddWithValue("@wrkid", sqlRdr(0))
                SqlCmd1.Parameters.AddWithValue("@wrkname", sqlRdr(1))
                SqlCmd1.ExecuteNonQuery()
            End While
            SqlCmd.Dispose()
            SqlCmd1.Dispose()
            sqlRdr.Close()

            SqlCmd = New SqlCommand("select * from finactdept where depttype='Brnch' order by deptname", FinActConn1)
            sqlRdr = SqlCmd.ExecuteReader
            While sqlRdr.Read
                SqlCmd1 = New SqlCommand("insert into tempbranch  values (@wrkid,@wrkname)", FinActConn)
                SqlCmd1.Parameters.AddWithValue("@wrkid", sqlRdr(0))
                SqlCmd1.Parameters.AddWithValue("@wrkname", sqlRdr(1))
                SqlCmd1.ExecuteNonQuery()
            End While
            SqlCmd.Dispose()
            SqlCmd1.Dispose()
            sqlRdr.Close()

            SqlCmd = New SqlCommand("select * from finactdept where depttype='Catgri' order by deptname", FinActConn1)
            sqlRdr = SqlCmd.ExecuteReader
            While sqlRdr.Read
                SqlCmd1 = New SqlCommand("insert into tempcatgri  values (@wrkid,@wrkname)", FinActConn)
                SqlCmd1.Parameters.AddWithValue("@wrkid", sqlRdr(0))
                SqlCmd1.Parameters.AddWithValue("@wrkname", sqlRdr(1))
                SqlCmd1.ExecuteNonQuery()
            End While
            SqlCmd.Dispose()
            SqlCmd1.Dispose()
            sqlRdr.Close()

            SqlCmd = New SqlCommand("select * from finactcscmstr where csctype='Outer'", FinActConn1)
            sqlRdr = SqlCmd.ExecuteReader
            While sqlRdr.Read
                SqlCmd1 = New SqlCommand("insert into tempcurcsc  values (@cid,@cname,@sname,@cnname)", FinActConn)
                SqlCmd1.Parameters.AddWithValue("@cid", sqlRdr(0))
                SqlCmd1.Parameters.AddWithValue("@cname", sqlRdr(1))
                SqlCmd1.Parameters.AddWithValue("@sname", sqlRdr(2))
                SqlCmd1.Parameters.AddWithValue("@cnname", sqlRdr(3))
                SqlCmd1.ExecuteNonQuery()
            End While
            SqlCmd.Dispose()
            SqlCmd1.Dispose()
            sqlRdr.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlCmd.Dispose()
            SqlCmd1.Dispose()
            sqlRdr.Close()
        End Try

    End Sub
    Private Sub DelRecfromtemptbl()
        Try
            OdbcCmd = New OdbcCommand("Delete from tempwrkname", FinactOdbcCon)
            OdbcCmd.ExecuteNonQuery()

            OdbcCmd = New OdbcCommand("Delete from tempbranch", FinactOdbcCon)
            OdbcCmd.ExecuteNonQuery()

            OdbcCmd = New OdbcCommand("Delete from tempcatgri", FinactOdbcCon)
            OdbcCmd.ExecuteNonQuery()

            OdbcCmd = New OdbcCommand("Delete from tempcurcsc", FinactOdbcCon)
            OdbcCmd.ExecuteNonQuery()

            OdbcCmd = New OdbcCommand("Delete from tempempinfo", FinactOdbcCon)
            OdbcCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            OdbcCmd.Dispose()
        End Try

    End Sub
    Private Sub Update_tbl_Tempempinfo()
        Try
            SqlCmd = New SqlCommand("Temp_EmpDetails_select", FinActConn)
            SqlCmd.CommandType = CommandType.StoredProcedure '
            sqlRdr = SqlCmd.ExecuteReader
            While sqlRdr.Read()
                SqlCmd1 = New SqlCommand("temp_empinsert_info1", FinActConn1)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                SqlCmd1.Parameters.AddWithValue("@empid", sqlRdr("empid"))
                SqlCmd1.Parameters.AddWithValue("@ename", sqlRdr("empname"))
                SqlCmd1.Parameters.AddWithValue("@edname", sqlRdr("empdsplaname"))
                SqlCmd1.Parameters.AddWithValue("@edob", sqlRdr("empdobdt"))
                SqlCmd1.Parameters.AddWithValue("@ejdt", sqlRdr("empjndt"))
                SqlCmd1.Parameters.AddWithValue("@eprb", sqlRdr("empprobprd"))
                SqlCmd1.Parameters.AddWithValue("@ecdt", sqlRdr("empconfrmdt"))
                SqlCmd1.Parameters.AddWithValue("@egrade", sqlRdr("empgrade"))
                SqlCmd1.Parameters.AddWithValue("@epmode", sqlRdr("emppaymode"))
                SqlCmd1.Parameters.AddWithValue("@ebac", sqlRdr("empbnkac"))
                SqlCmd1.Parameters.AddWithValue("@estatus", sqlRdr("emplstatus"))
                SqlCmd1.Parameters.AddWithValue("@eshift", sqlRdr("empothrsift"))
                SqlCmd1.Parameters.AddWithValue("@ad1", sqlRdr("empadrs1"))
                SqlCmd1.Parameters.AddWithValue("@ad2", sqlRdr("empadrs2"))
                SqlCmd1.Parameters.AddWithValue("@ad3", sqlRdr("empadrs3"))
                SqlCmd1.Parameters.AddWithValue("@epin", sqlRdr("emppin"))
                SqlCmd1.Parameters.AddWithValue("@eph", sqlRdr("empphno"))
                SqlCmd1.Parameters.AddWithValue("@emob", sqlRdr("empmobno"))
                SqlCmd1.Parameters.AddWithValue("@email", sqlRdr("empemail"))
                SqlCmd1.Parameters.AddWithValue("@ehgt", sqlRdr("emphight"))
                SqlCmd1.Parameters.AddWithValue("@ehgt1", sqlRdr("emphight1"))
                SqlCmd1.Parameters.AddWithValue("@esex", sqlRdr("empsex"))
                SqlCmd1.Parameters.AddWithValue("@emrl", sqlRdr("empmarital"))
                SqlCmd1.Parameters.AddWithValue("@eanni", sqlRdr("empanniver"))
                SqlCmd1.Parameters.AddWithValue("@ereli", sqlRdr("emprelign"))
                SqlCmd1.Parameters.AddWithValue("@enat", sqlRdr("empnation"))
                SqlCmd1.Parameters.AddWithValue("@epid", sqlRdr("emppersonid"))
                SqlCmd1.Parameters.AddWithValue("@epid1", sqlRdr("emppersonid1"))
                SqlCmd1.Parameters.AddWithValue("@ecad1", sqlRdr("empcuradrs1"))
                SqlCmd1.Parameters.AddWithValue("@ecad2", sqlRdr("empcuradrs2"))
                SqlCmd1.Parameters.AddWithValue("@ecad3", sqlRdr("empcuradrs3"))
                SqlCmd1.Parameters.AddWithValue("@ecpin", sqlRdr("empcurpin"))
                SqlCmd1.Parameters.AddWithValue("@ecph", sqlRdr("empcurphno"))
                SqlCmd1.Parameters.AddWithValue("@ecmob", sqlRdr("empcurmobno"))
                SqlCmd1.Parameters.AddWithValue("@epan", sqlRdr("emppan"))
                SqlCmd1.Parameters.AddWithValue("@eitr", sqlRdr("empitrange"))
                SqlCmd1.Parameters.AddWithValue("@eitw", sqlRdr("empitward"))
                SqlCmd1.Parameters.AddWithValue("@ef1", sqlRdr("empfather"))
                SqlCmd1.Parameters.AddWithValue("@em1", sqlRdr("empmother"))
                SqlCmd1.Parameters.AddWithValue("@es1", sqlRdr("empspose"))
                SqlCmd1.Parameters.AddWithValue("@ee1", sqlRdr("empemrgency"))
                SqlCmd1.Parameters.AddWithValue("@ectname", sqlRdr("cscctyname"))
                SqlCmd1.Parameters.AddWithValue("@estate", sqlRdr("cscstatename"))
                SqlCmd1.Parameters.AddWithValue("@ecntr", sqlRdr("csccontry"))
                SqlCmd1.Parameters.AddWithValue("@ecctname", sqlRdr("curctyname"))
                SqlCmd1.Parameters.AddWithValue("@ecstate", sqlRdr("curstatename"))
                SqlCmd1.Parameters.AddWithValue("@eccntr", sqlRdr("curcontry"))
                SqlCmd1.Parameters.AddWithValue("@edptname", sqlRdr("deptname"))
                SqlCmd1.Parameters.AddWithValue("@ecatname", sqlRdr("Catgriname"))
                SqlCmd1.Parameters.AddWithValue("@ewrkname", sqlRdr("WrkName"))
                SqlCmd1.Parameters.AddWithValue("@ebranch", sqlRdr("branchname"))
                SqlCmd1.Parameters.AddWithValue("@edsiname", sqlRdr("desiname"))
                SqlCmd1.ExecuteNonQuery()
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sqlRdr.Close()
            SqlCmd.Dispose()
            SqlCmd1 = Nothing

        End Try

    End Sub

End Class
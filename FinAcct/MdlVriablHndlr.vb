Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Module MdlVriablHndlr
    Dim Invntconn As SqlConnection
    Dim Invntconn1 As SqlConnection
    Dim Invntconn2 As SqlConnection
    Dim Invntconn3 As SqlConnection
    Public DbConn As SqlConnection
    Public CoCmbxRecrd As SqlCommand
    Public CoCmBxRdr As SqlDataReader
    Public EmpRecordCmd As SqlCommand
    Public CoProfile As SqlCommand
    Public CoDtaRdr As SqlDataReader
    Public TbleInsert As SqlCommand
    Public RecordReader As SqlDataReader
    Public StokHndCmd As SqlCommand
    Public StokHndRdr As SqlDataReader
    Public TranGenVnoCmd As SqlCommand
    Public TranGenVnoDtardr As SqlDataReader
    Public SelRptRdr2 As SqlDataReader
    Public SelRptCmd2 As SqlCommand
    Public DynaRptDt As DataTable
    Public DynaRptDtrow As DataRow
    Public Chk_and_Create_db As SqlCommand
    Public Chk_and_Create_db1 As SqlCommand
    Public StokInward, StokOutward, InvntVNo As Double
    Public Chk_dt_status As Boolean
    Public Allow_Delete As Boolean 'Variable if True,will give access for delete
    Public Allow_Edit As Boolean 'Variable if True, will give access for Edit 
    Public Allow_AddWithValuenew As Boolean 'Variable if True, will give access for AddWithValue new record
    Public Allow_View_All As Boolean ' in true condition, will give access to View all reports
    Public Allow_Create_Master As Boolean ' in true condition, will give access to create new masters
    'Public InvntConn As OdbcConnection

    Public Sub EmpRecord(ByVal Empname As String)
        EmpRecordCmd = New SqlCommand("select * from InventEmpmstr where frstname=@empname  ", Invntconn)
        EmpRecordCmd.Parameters.AddWithValue("@empname", Trim(Empname))
        RecordReader = EmpRecordCmd.ExecuteReader
    End Sub
    Public Sub ItemRecord()
        EmpRecordCmd = New SqlCommand("select * from Invntitmmstr order by itmname ", Invntconn)
        RecordReader = EmpRecordCmd.ExecuteReader
        Try
            While RecordReader.Read
                TbleInsert = New SqlCommand("insert into invnttmpitmrpt values(@id,@iname)", Invntconn1)
                TbleInsert.Parameters.AddWithValue("@id", RecordReader("itmid"))
                TbleInsert.Parameters.AddWithValue("@iname", RecordReader("itmname"))
                TbleInsert.ExecuteNonQuery()
            End While
            RecordReader.Close()
            TbleInsert = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error From Item Master")
        End Try
    End Sub

    Public Sub DeptRecord(ByVal Deptname As String)
        EmpRecordCmd = New SqlCommand("select * from Invntdept where deptname=@deptname ", Invntconn)
        EmpRecordCmd.Parameters.AddWithValue("@deptname", Trim(Deptname))
        RecordReader = EmpRecordCmd.ExecuteReader
    End Sub
    Public Sub EmpRecordName()
        EmpRecordCmd = New SqlCommand("select * from InventEmpmstr order by frstname ", Invntconn)
        RecordReader = EmpRecordCmd.ExecuteReader
        Try
            While RecordReader.Read
                TbleInsert = New SqlCommand("insert into invnttmpemprpt values(@id,@fname,@lname,@title,@dpt)", Invntconn1)
                TbleInsert.Parameters.AddWithValue("@id", RecordReader("empid"))
                TbleInsert.Parameters.AddWithValue("@fname", RecordReader("frstname"))
                TbleInsert.Parameters.AddWithValue("@lname", RecordReader("lstname"))
                TbleInsert.Parameters.AddWithValue("@title", RecordReader("dept"))
                TbleInsert.Parameters.AddWithValue("@dpt", RecordReader("designation"))
                TbleInsert.ExecuteNonQuery()
            End While
            RecordReader.Close()
            TbleInsert = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error From Employee Master")
        End Try

    End Sub
    Public Sub ItemRecord_Id(ByVal Itmid As Double)
        EmpRecordCmd = New SqlCommand("select * from Invntitmmstr where itmid=@itmid ", Invntconn)
        EmpRecordCmd.Parameters.AddWithValue("@itmid", Trim(Itmid))
        RecordReader = EmpRecordCmd.ExecuteReader
    End Sub
    Public Sub DeptRecord_Id(ByVal DeptId As String)
        EmpRecordCmd = New SqlCommand("select * from Invntdept where deptid=@deptid ", Invntconn)
        EmpRecordCmd.Parameters.AddWithValue("@deptid", Trim(DeptId))
        RecordReader = EmpRecordCmd.ExecuteReader
    End Sub
    Public Sub AllowNumberOnly(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim Txtcontrl As TextBox = DirectCast(sender, TextBox)
        Dim ErrText As String
        Try
            Dim i As Double = Double.Parse(Txtcontrl.Text)
        Catch ErrProvider As Exception
            ErrText = "Value must be a Number like(0123456789)"
            Txtcontrl.Text = ""
            MsgBox(ErrText)
            Txtcontrl.SelectAll()
            Txtcontrl.Focus()
        End Try
    End Sub
    Public Sub GetStokInHnd(ByVal TrnItmid As Label)
        StokHndCmd = New SqlCommand("Select sum(tranitmqnty)as InTot from finacttrans where trantype=@trtype and tranitmid=@trnitmid", FinActConn)
        StokHndCmd.Parameters.AddWithValue("@trtype", Trim("Inward"))
        StokHndCmd.Parameters.AddWithValue("@trnitmid", Trim(Val(TrnItmid.Text)))
        StokHndRdr = StokHndCmd.ExecuteReader
        StokHndRdr.Read()
        If StokHndRdr.IsDBNull(0) = True Then
            StokInward = CDbl(0)
        Else
            StokInward = StokHndRdr("InTot")
        End If

        StokHndCmd = Nothing
        StokHndRdr.Close()

        StokHndCmd = New SqlCommand("Select sum(tranitmqnty)as OutTot from finacttrans where trantype=@trtype and tranitmid=@trnitmid", FinActConn)
        StokHndCmd.Parameters.AddWithValue("@trtype", Trim("Outward"))
        StokHndCmd.Parameters.AddWithValue("@trnitmid", Trim(Val(TrnItmid.Text)))
        StokHndRdr = StokHndCmd.ExecuteReader
        StokHndRdr.Read()
        If StokHndRdr.IsDBNull(0) = True Then
            StokOutward = CDbl(0)
        Else
            StokOutward = Val(StokHndRdr("OutTot"))
        End If

        StokHndCmd = Nothing
        StokHndRdr.Close()

    End Sub
    Public Sub TranGenVNo()
        TranGenVnoCmd = New SqlCommand("Select max(tranvno) from finacttrans", FinActConn)
        TranGenVnoDtardr = TranGenVnoCmd.ExecuteReader
        Try
            TranGenVnoDtardr.Read()

            If TranGenVnoDtardr.IsDBNull(0) = True Then

                InvntVNo = CDbl(1)
            Else
                InvntVNo += TranGenVnoDtardr(0) + CDbl(1)
            End If
            TranGenVnoDtardr.Close()
            TranGenVnoCmd = Nothing
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Public Sub CreateOffLineTable()
        SelRptCmd2 = New SqlCommand("Select finactmrr.*,inventempmstr.frstname,finactdept.deptname,finactitmmstr.itmname from finactmrr" _
        & " inner join inventempmstr on finactmrr.mrrempid=inventempmstr.empid" _
        & " inner join finactdept on finactmrr.mrrdept=finactdept.deptid" _
         & " inner join finactitmmstr on finactmrr.mrritmid=finactitmmstr.itmid" _
         & " where finactmrr.mrrempid= '" & Trim(124500) & "' order by finactmrr.mrrid", FinActConn1)
        SelRptRdr2 = SelRptCmd2.ExecuteReader
        DynaRptDt = New DataTable("SelRptMrr")
        DynaRptDt.Columns.Add("Date")
        DynaRptDt.Columns.Add("MRR No")
        DynaRptDt.Columns.Add("Item Name")
        DynaRptDt.Columns.Add("Quantity")
        DynaRptDt.Columns.Add("Unit")
        DynaRptDt.Columns.Add("MRR Status")
        DynaRptDt.Columns.Add("Order Status")
        DynaRptDt.Columns.Add("Employee's Name")
        DynaRptDt.Columns.Add("Department Name")
        DynaRptDt.Columns(1).Unique = True

        While SelRptRdr2.Read
            DynaRptDtrow = DynaRptDt.NewRow
            DynaRptDtrow(0) = SelRptRdr2("mrrdt")
            DynaRptDtrow(1) = SelRptRdr2("mrrid")
            DynaRptDtrow(2) = SelRptRdr2("itmname")
            DynaRptDtrow(3) = SelRptRdr2("mrrqnty")
            DynaRptDtrow(4) = SelRptRdr2("mrrunit")
            DynaRptDtrow(5) = SelRptRdr2("mrrstatus")
            DynaRptDtrow(6) = SelRptRdr2("mrrordrstatus")
            DynaRptDtrow(7) = SelRptRdr2("frstname")
            DynaRptDtrow(8) = SelRptRdr2("Deptname")
            DynaRptDt.Rows.Add(DynaRptDtrow)
           
        End While
        SelRptRdr2.Close()
        SelRptCmd2 = Nothing
    End Sub
    Public Sub FetchSplrmstr()
        EmpRecordCmd = New SqlCommand("select * from finactsplrmstr where splrtype='Supplier' order by splrname", FinActConn)
        RecordReader = EmpRecordCmd.ExecuteReader
        Try
            While RecordReader.Read
                TbleInsert = New SqlCommand("insert into finacttmpsplrrpt values(@id,@sname)", FinActConn1)
                TbleInsert.Parameters.AddWithValue("@id", RecordReader("splrid"))
                TbleInsert.Parameters.AddWithValue("@sname", RecordReader("splrname"))
                TbleInsert.ExecuteNonQuery()
            End While
            RecordReader.Close()
            TbleInsert = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error From supplier Master")
        End Try
    End Sub
    Public Sub Delfromempmstr()
        EmpRecordCmd = New SqlCommand("Delete from finacttmpemprpt", FinActConn1)
        Try
            EmpRecordCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        EmpRecordCmd = Nothing
    End Sub
    Public Sub DelfromItmmstr()
        EmpRecordCmd = New SqlCommand("Delete from finacttmpitmrpt", FinActConn1)
        Try
            EmpRecordCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        EmpRecordCmd = Nothing
    End Sub
    Public Sub DelfromSplrmstr()
        EmpRecordCmd = New SqlCommand("Delete from finacttmpsplrrpt", FinActConn1)
        Try
            EmpRecordCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        EmpRecordCmd = Nothing
    End Sub
    Public Sub CheckDatabase()
        'DbConn = New SqlConnection("Server=.;initial catalog=Stock_Manager;user id=sa")
        DbConn = New SqlConnection("data source=.;persist security info=False;initial catalog=Stock_Manager")
        Try
            DbConn.Open()
        Catch ex As Exception
            MsgBox("Required Database not found, System is creating new database ", MsgBoxStyle.Information, "Database Creating.....")
            '==========Database Creating
            Dim mystr As String
            mystr = "Create database Stock_Manager1"
            Chk_and_Create_db = New SqlCommand(mystr, FinActConn3)
            Chk_and_Create_db.ExecuteNonQuery()
            Chk_and_Create_db = Nothing
        End Try

    End Sub
    Public Sub TableCreater()
        '=============Table Creating
        If DbConn.State Then DbConn.Close()
        DbConn = New SqlConnection("integrated security=SSPI;data source=.;persist security info=False;initial catalog=Stock_Manager1")
        Try
            FinActConn3.ChangeDatabase("Stock_Manager")
        Catch ex As Exception
            MsgBox(ex.Message + "   " + "Error occoured when tables are being created")
        End Try

        Dim DbCreater As String = ""
        Dim Sqltxt As New IO.FileStream("C:\Setup Generating\Inventory_Control\CreateTable.txt", FileMode.Open, FileAccess.ReadWrite)
        Dim SqltxtReader As New StreamReader(Sqltxt)
        SqltxtReader.BaseStream.Seek(0, SeekOrigin.Begin)
        While SqltxtReader.Peek > -1
            'TextBox1.Text += SqltxtReader.ReadLine() & " " & ControlChars.CrLf
            DbCreater += SqltxtReader.ReadLine() & " " '& ControlChars.CrLf
        End While
        SqltxtReader.Close()
        ' DbConn = New SqlConnection("Server=(local);initial catalog=Stock_Manager1;user id=sa")
        Chk_and_Create_db1 = New SqlCommand(DbCreater, FinActConn3)
        Chk_and_Create_db1.ExecuteNonQuery()
        Chk_and_Create_db1 = Nothing
    End Sub
    Public Sub Chk_Co_Profile()
        CoProfile = New SqlCommand("select *  from finactcogatemstr", FinActConn)
        Try
            CoDtaRdr = CoProfile.ExecuteReader
            CoDtaRdr.Read()
            If CoDtaRdr.HasRows = True Then
                Chk_dt_status = True
            ElseIf CoDtaRdr.HasRows = False Then
                Chk_dt_status = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Company Profile")
        Finally
            CoDtaRdr.Close()
            CoProfile = Nothing
        End Try
    End Sub
    Public Function ScreenResolution() As String
        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        Return intX & " X " & intY

    End Function
    Public Function UniqueChars(ByVal OrigString As String) _
         As String

        'INPUT: ANY STRING
        'OUTPUT: The Unique Characters of the string, in the order
        '        They First appear
        'Example: Debug.Print(UniqueChars("FreeVBCode")):
        '         Outputs: FreVBCod

        Dim oCol As New Collection
        Dim sAns As String = ""
        Dim lCtr As Long, lCount As Long
        Dim sChar As String

        lCount = Len(OrigString)

        For lCtr = 1 To lCount
            sChar = Mid(OrigString, lCtr, 1)
            On Error Resume Next
            oCol.Add(sChar, sChar)
            If Err.Number = 0 Then sAns = sAns & sChar
            Err.Clear()
        Next
        UniqueChars = sAns
    End Function

    Public Function UniqueCharCount(ByVal TheString As String) _
       As Long
        UniqueCharCount = Len(UniqueChars(TheString))
    End Function
    'Searchstring by Terrankiller 
    'Example stringvar = Searchstring("3,000,000", ",")
    'stringvar will be the new word without the commas

    'Function Searchstring(ByVal StringToSearch As String, ByVal StringToFind As String) As String
    '    Dim Char1, Newword As String
    '    Dim intStartingFrom, intCount As Long

    '    intCount = Len(StringToSearch) + 1
    '    Do Until intStartingFrom >= intCount
    '        intStartingFrom = intStartingFrom + 1
    '        Char1 = Mid$(StringToSearch, intStartingFrom, 1)
    '        If Char1 = StringToFind Then
    '        Else
    '            Newword = Newword & Char1
    '        End If
    '    Loop
    '    Searchstring = Newword
    'End Function


End Module

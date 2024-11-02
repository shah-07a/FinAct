Imports System.Data.SqlClient
Imports System.Data.DataTable
Imports System.Data

Public Class FrmWrkName
    Inherits System.Windows.Forms.Form
    Dim Indx As Integer
    Dim CatCmd As SqlCommand
    Dim DtaRdr As SqlDataReader
    Dim addFlag As Boolean
    Dim EdtFlag As Boolean
    Dim AllowEdt As Boolean = False
    Dim EdtRecrdNo As Integer
    Dim DelStatus As Integer
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ChekEmpty()
        If Indx <> 0 Then
            'BtnSave.Enabled = False
            Indx = 0
            Exit Sub
        Else
            'BtnSave.Enabled = True
        End If
        Dim SveCnfrm As String
        SveCnfrm = MsgBox("Are u sure to Save this record", MsgBoxStyle.YesNo)
        If SveCnfrm = vbYes Then
            If addFlag = True Then
                CatCmd = New SqlCommand("Insert Into finactDept(deptname,depttype,deptadusrid,deptaddt,deptdelstatus) values(@deptname,@type,@adusrid,@addt,@delstatus)", FinActConn)
                CatCmd.Parameters.AddWithValue("@deptname", Trim(TxtDept.Text))
                CatCmd.Parameters.AddWithValue("@type", Trim("WrkName"))
                CatCmd.Parameters.AddWithValue("@adusrid", Current_UsrId)
                CatCmd.Parameters.AddWithValue("@addt", Now)
                CatCmd.Parameters.AddWithValue("@delstatus", 1)
            ElseIf EdtFlag = True Then
                CatCmd = New SqlCommand("update finactdept set deptname=@deptname,deptdelstatus=@delstatus,deptedtusrid=@edtusrid,deptedtdt=@edtdt where deptid=@deptid", FinActConn)
                CatCmd.Parameters.AddWithValue("@deptname", Trim(TxtDept.Text))
                CatCmd.Parameters.AddWithValue("@deptid", EdtRecrdNo)
                CatCmd.Parameters.AddWithValue("@delstatus", 1)
                CatCmd.Parameters.AddWithValue("@edtusrid", Current_UsrId)
                CatCmd.Parameters.AddWithValue("@edtdt", Now)
            End If

            Try
                CatCmd.ExecuteNonQuery()
                MsgBox("Record Has been Successfully Saved", MsgBoxStyle.Information)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Department")
                TxtDept.SelectAll()
                TxtDept.Focus()
                Exit Try
            Finally
                CatCmd = Nothing
                Btnadd.Focus()
            End Try
        ElseIf SveCnfrm = vbNo Then
            TxtDept.Focus()
        End If
    End Sub

    Private Sub FrmdeptMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Size = New Size(550, 160)
        Me.Top = 0
        Me.Width = 430 'MeWidth / 1.45
        Me.Height = 160 'MeHeight / 3.7
        CheckAcess_Btn_frm(Btnadd, Btnedt, BtnDele, BtnFind)

        addFlag = True
        EdtFlag = False
    End Sub
    Private Sub CheckAcess_Btn_frm(ByVal BtnnAdd As Button, ByVal BtnnEdt As Button, _
       ByVal BtnnDel As Button, ByVal BtnnFnd As Button)
        Select Case Trim(AcessRight)
            Case "OwnrFull"
                BtnnAdd.Enabled = True
                BtnnEdt.Enabled = True
                BtnnDel.Enabled = True
                BtnnFnd.Enabled = True
            Case "DataEntryMstr"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(204, 68)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
                BtnnFnd.Visible = False
            Case "PayRoll"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(204, 68)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
                BtnnFnd.Visible = False
        End Select
    End Sub
    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        Me.Width = 584
        Me.Height = 160

        LstVewFnd.Clear()
        LstVewFnd.Columns.add("Name Of Department", LstVewFnd.Width, HorizontalAlignment.Left)
        LstVewFnd.Columns.add("Id", LstVewFnd.Width \ 1, HorizontalAlignment.Left)
        Dim LstItem As ListViewItem
        LstVewFnd.Visible = True
        CatCmd = New SqlCommand("Select * from finactdept where deptdelstatus=1 and depttype='" & Trim("WrkName") & "' order by deptname ", FinActConn)
        Try
            DtaRdr = CatCmd.ExecuteReader
            Dim x As Integer
            x = 0
            While DtaRdr.Read()
                LstItem = LstVewFnd.Items.add(DtaRdr("deptname"), 1)
                LstVewFnd.Items(x).SubItems.add(DtaRdr("deptid"))
                x += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        Finally
            DtaRdr.Close()
            CatCmd = Nothing
            LstVewFnd.Focus()
            LstVewFnd.Select()
        End Try
        addFlag = False
        EdtFlag = True
    End Sub
    Private Sub BtnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClos.Click
        Me.Close()
    End Sub

    Private Sub BtnDele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDele.Click
        If TxtDept.Text = "" Or EdtRecrdNo < 1 Then
            MsgBox("No record is present to delete", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtDept.Text <> "" And EdtRecrdNo > 0 Then
            Select Case MsgBox("Are you sure to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    CatCmd = New SqlCommand("update finactdept set deptname=@deptname,deptdelstatus=@delstatus,deptdelusrid=@delusrid,deptdeldt=@deldt where deptid=@deptid", FinActConn)
                    CatCmd.Parameters.AddWithValue("@deptname", Trim(TxtDept.Text))
                    CatCmd.Parameters.AddWithValue("@deptid", EdtRecrdNo)
                    CatCmd.Parameters.AddWithValue("@delstatus", 0)
                    CatCmd.Parameters.AddWithValue("@delusrid", Current_UsrId)
                    CatCmd.Parameters.AddWithValue("@deldt", Now)
                    Try
                        CatCmd.ExecuteNonQuery()
                        MsgBox("Current Record has been successfully Delated", MsgBoxStyle.Information, "Current Record Deleted")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Exit Try
                    Finally
                        CatCmd = Nothing
                        TxtDept.Text = ""
                        EdtRecrdNo = 0
                    End Try
                Case MsgBoxResult.No
                    BtnDele.Focus()
            End Select
        End If

    End Sub

    Private Sub Btnedt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnedt.Click
        If AllowEdt = True Then
            TxtDept.Focus()
            addFlag = False
            EdtFlag = True
        Else
            MsgBox("Invalid Input", MsgBoxStyle.Critical, "Invalid")
            Btnadd.Focus()
        End If

    End Sub


    Private Sub LstVewFnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewFnd.DoubleClick
        Try
            TxtDept.Text = LstVewFnd.SelectedItems(0).Text
            EdtRecrdNo = LstVewFnd.SelectedItems.Item(0).SubItems.Item(1).Text
            LstVewFnd.Visible = False
            Me.Size = New Size(430, 160)
            Btnedt.Enabled = True
            AllowEdt = True
            Btnedt.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub LstVewFnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewFnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            LstVewFnd_DoubleClick(sender, e)
        ElseIf e.KeyCode = Keys.Escape Then
            LstVewFnd.Visible = False
            Me.Size = New Size(430, 160)
        End If
    End Sub


    Private Sub TxtDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDept.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(13)
                BtnSave.Focus()
            Case Microsoft.VisualBasic.ChrW(9)
                BtnSave.Focus()
            Case Else
        End Select


    End Sub
    Private Sub TxtDept_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDept.Leave
        BtnSave.Focus()
    End Sub
    Private Sub ChekEmpty()
        With TxtDept
            If .Text = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                Indx = Indx + 1
                .Focus()
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
    End Sub
    Private Sub ClrValue()
        TxtDept.Text = ""
    End Sub

    Private Sub Btnadd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        ClrValue()
        addFlag = True
        EdtFlag = False
        AllowEdt = False
        TxtDept.Focus()
        If LstVewFnd.Visible = True Then
            LstVewFnd.Visible = False
            Me.Size = New Size(430, 160)
        End If
    End Sub
    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GroupBox1.KeyDown, Label1.KeyDown, _
      LstVewFnd.KeyDown, TxtDept.KeyDown, Btnadd.KeyDown, BtnClos.KeyDown, BtnDele.KeyDown, Btnedt.KeyDown, BtnFind.KeyDown, BtnSave.KeyDown

        If e.KeyCode = Keys.Escape Then

            Me.Close()

        End If
    End Sub
End Class
Imports System.Data.SqlClient
Imports System.Data.DataTable
Imports System.Data


Public Class FrmDeptMstr
    Inherits System.Windows.Forms.Form

    Dim Indx As Integer
    Dim CatCmd As SqlCommand
    Dim DtaRdr As SqlDataReader
    Dim addFlag As Boolean
    Dim EdtFlag As Boolean
    Dim AllowEdt As Boolean = False
    Dim EdtRecrdNo As Integer
    Dim DelStatus As Integer

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Btnadd As System.Windows.Forms.Button
    Friend WithEvents TxtDept As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
    Friend WithEvents LstVewFnd As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDeptMstr))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Btnadd = New System.Windows.Forms.Button
        Me.TxtDept = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnClos = New System.Windows.Forms.Button
        Me.LstVewFnd = New System.Windows.Forms.ListView
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Btnadd)
        Me.GroupBox1.Controls.Add(Me.TxtDept)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnFind)
        Me.GroupBox1.Controls.Add(Me.BtnSave)
        Me.GroupBox1.Controls.Add(Me.BtnClos)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(404, 327)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Btnadd
        '
        Me.Btnadd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btnadd.BackColor = System.Drawing.Color.LightCyan
        Me.Btnadd.BackgroundImage = CType(resources.GetObject("Btnadd.BackgroundImage"), System.Drawing.Image)
        Me.Btnadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnadd.Location = New System.Drawing.Point(207, 290)
        Me.Btnadd.Name = "Btnadd"
        Me.Btnadd.Size = New System.Drawing.Size(90, 30)
        Me.Btnadd.TabIndex = 3
        Me.Btnadd.Text = "&Cancel"
        Me.Btnadd.UseVisualStyleBackColor = False
        '
        'TxtDept
        '
        Me.TxtDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDept.Location = New System.Drawing.Point(123, 27)
        Me.TxtDept.MaxLength = 70
        Me.TxtDept.Name = "TxtDept"
        Me.TxtDept.Size = New System.Drawing.Size(270, 20)
        Me.TxtDept.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 14)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Deparment Name "
        '
        'BtnFind
        '
        Me.BtnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnFind.BackColor = System.Drawing.Color.LightCyan
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Location = New System.Drawing.Point(111, 290)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(90, 30)
        Me.BtnFind.TabIndex = 2
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.BackColor = System.Drawing.Color.LightCyan
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Location = New System.Drawing.Point(15, 290)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(90, 30)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnClos
        '
        Me.BtnClos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClos.BackColor = System.Drawing.Color.LightCyan
        Me.BtnClos.BackgroundImage = CType(resources.GetObject("BtnClos.BackgroundImage"), System.Drawing.Image)
        Me.BtnClos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClos.Location = New System.Drawing.Point(303, 290)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(90, 30)
        Me.BtnClos.TabIndex = 4
        Me.BtnClos.Text = "&Close"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'LstVewFnd
        '
        Me.LstVewFnd.AllowDrop = True
        Me.LstVewFnd.BackColor = System.Drawing.Color.LightCyan
        Me.LstVewFnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstVewFnd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVewFnd.ForeColor = System.Drawing.Color.Blue
        Me.LstVewFnd.GridLines = True
        Me.LstVewFnd.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstVewFnd.HoverSelection = True
        Me.LstVewFnd.Location = New System.Drawing.Point(421, 6)
        Me.LstVewFnd.MultiSelect = False
        Me.LstVewFnd.Name = "LstVewFnd"
        Me.LstVewFnd.Size = New System.Drawing.Size(335, 327)
        Me.LstVewFnd.TabIndex = 7
        Me.LstVewFnd.UseCompatibleStateImageBehavior = False
        Me.LstVewFnd.View = System.Windows.Forms.View.Details
        Me.LstVewFnd.Visible = False
        '
        'FrmDeptMstr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.ClientSize = New System.Drawing.Size(759, 337)
        Me.Controls.Add(Me.LstVewFnd)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmDeptMstr"
        Me.Text = "Department  Master"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            addFlag = True
            EdtFlag = False
            ChekEmpty()
            If Indx <> 0 Then
                MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Field")
                ' BtnSave.Enabled = False
                Indx = 0
                Exit Sub
            Else
                'BtnSave.Enabled = True
            End If
            Dim SveCnfrm As String
            SveCnfrm = MsgBox("Are you sure to Save this record?", MsgBoxStyle.YesNo, "Save")
            If SveCnfrm = vbYes Then
                If addFlag = True Then
                    CatCmd = New SqlCommand("Insert Into finactDept(deptname,depttype,deptadusrid,deptaddt,deptdelstatus) values(@deptname,@type,@adusrid,@addt,@delstatus)", FinActConn)
                    CatCmd.Parameters.AddWithValue("@deptname", Trim(TxtDept.Text))
                    CatCmd.Parameters.AddWithValue("@type", Trim("Dept"))
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
                    MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information, "Save")
                    ClrValue()

                Catch ex As Exception
                    MsgBox("Violation of Primary key" + Chr(10) + "Name already exist, you can not insert Duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "Department Name Already Exist!")
                  
                    'MsgBox(ex.Message, MsgBoxStyle.Critical, "Department")
                    TxtDept.SelectAll()
                    TxtDept.Focus()
                    Exit Try
                Finally
                    CatCmd = Nothing
                    '  Btnadd.Focus()
                    TxtDept.Focus()
                End Try
            ElseIf SveCnfrm = vbNo Then
                TxtDept.Focus()
            End If
        ElseIf BtnSave.Text = "&Update" Then
            If AllowEdt = True Then
                TxtDept.Focus()
                addFlag = False
                EdtFlag = True
                ChekEmpty()
                If Indx <> 0 Then
                    MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Field")
                    ' BtnSave.Enabled = False
                    Indx = 0
                    Exit Sub
                Else
                    'BtnSave.Enabled = True
                End If
                'Dim SveCnfrm As String
                'SveCnfrm = MsgBox("Are you sure to Update this record?", MsgBoxStyle.YesNo)
                'If SveCnfrm = vbYes Then

                If EdtFlag = True Then
                    CatCmd = New SqlCommand("update finactdept set deptname=@deptname,deptdelstatus=@delstatus,deptedtusrid=@edtusrid,deptedtdt=@edtdt where deptid=@deptid", FinActConn)
                    CatCmd.Parameters.AddWithValue("@deptname", Trim(TxtDept.Text))
                    CatCmd.Parameters.AddWithValue("@deptid", EdtRecrdNo)
                    CatCmd.Parameters.AddWithValue("@delstatus", 1)
                    CatCmd.Parameters.AddWithValue("@edtusrid", Current_UsrId)
                    CatCmd.Parameters.AddWithValue("@edtdt", Now)
                End If

                Try
                    CatCmd.ExecuteNonQuery()
                    MsgBox("Record has been Updated Successfully", MsgBoxStyle.Information)
                    ClrValue()
                    BtnSave.Text = "&Save"
                    BtnFind.Text = "&Find"

                Catch ex As Exception
                    MsgBox("Violation of Primary key" + Chr(10) + "Name already exist, you can not insert Duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "Department Name Already Exist!")
                    ' MsgBox(ex.Message, MsgBoxStyle.Critical, "Department")
                    TxtDept.SelectAll()
                    TxtDept.Focus()
                    Exit Try
                Finally
                    CatCmd = Nothing
                    'Btnadd.Focus()
                    TxtDept.Focus()
                End Try
                'ElseIf SveCnfrm = vbNo Then
                '    TxtDept.Focus()
                'End If

            Else
                'MsgBox("Invalid Input", MsgBoxStyle.Critical, "Invalid")
                'Btnadd.Focus()
                If TxtDept.Text = "" Then
                    MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Field")
                    TxtDept.BackColor = Color.LemonChiffon
                    TxtDept.Focus()
                End If
            End If

        End If
    End Sub

    Private Sub FrmdeptMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Size = New Size(550, 365)
        Try
            Me.Width = 430 'MeWidth / 1.45
            Me.Height = 365 'MeHeight / 3.7
            CheckAcess_Btn_frm(Btnadd, BtnFind)
            addFlag = True
            EdtFlag = False
            Me.TxtDept.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckAcess_Btn_frm(ByVal BtnnAdd As Button, ByVal BtnnFnd As Button)
        Select Case Trim(AcessRight)
            Case "OwnrFull"
                BtnnAdd.Enabled = True
                BtnnFnd.Enabled = True
            Case "DataEntryMstr"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(204, 68)
                BtnnFnd.Visible = False
            Case "PayRoll"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(204, 68)
                BtnnFnd.Visible = False
        End Select
    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        If BtnFind.Text = "&Find" Then
            If TxtDept.BackColor <> Color.White Then
                TxtDept.BackColor = Color.White
            End If
            Me.Width = 765
            Me.Height = 365

            LstVewFnd.Clear()
            LstVewFnd.Columns.Add("Name Of Department", LstVewFnd.Width, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Id", LstVewFnd.Width \ 1, HorizontalAlignment.Left)
            Dim LstItem As ListViewItem
            LstVewFnd.Visible = True
            CatCmd = New SqlCommand("Select * from finactdept where deptdelstatus=1 and depttype='" & Trim("Dept") & "' order by deptname ", FinActConn)
            Try
                DtaRdr = CatCmd.ExecuteReader
                Dim x As Integer
                x = 0
                While DtaRdr.Read()
                    LstItem = LstVewFnd.Items.Add(DtaRdr("deptname"), 1)
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("deptid"))
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
            BtnFind.Text = "&Delete"
            BtnSave.Text = "&Update"
        ElseIf BtnFind.Text = "&Delete" Then
            If TxtDept.Text = "" Or EdtRecrdNo < 1 Then
                MsgBox("No record is present to delete", MsgBoxStyle.Information)
                Exit Sub
            End If
            If TxtDept.Text <> "" And EdtRecrdNo > 0 Then
                Dim delmsg As String
                delmsg = MsgBox("Are you sure to delete this record?", MsgBoxStyle.YesNo)
                If delmsg = vbYes Then
                    'CatCmd = New SqlCommand("update finactdept set deptname=@deptname,deptdelstatus=@delstatus,deptdelusrid=@delusrid,deptdeldt=@deldt where deptid=@deptid", FinActConn)
                    CatCmd = New SqlCommand("Delete from  finactdept where deptid=@deptid", FinActConn)

                    'CatCmd.Parameters.AddWithValue("@deptname", Trim(TxtDept.Text))
                    CatCmd.Parameters.AddWithValue("@deptid", EdtRecrdNo)
                    'CatCmd.Parameters.AddWithValue("@delstatus", 0)
                    'CatCmd.Parameters.AddWithValue("@delusrid", Current_UsrId)
                    'CatCmd.Parameters.AddWithValue("@deldt", Now)
                    Try
                        CatCmd.ExecuteNonQuery()
                        MsgBox("Current Record has been Deleted Successfully", MsgBoxStyle.Information, "Current Record Deleted")
                        BtnFind.Text = "&Find"
                        BtnSave.Text = "&Save"
                        TxtDept.Focus()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Exit Try
                    Finally
                        CatCmd = Nothing
                        TxtDept.Text = ""

                    End Try
                ElseIf delmsg = vbNo Then
                    BtnFind.Focus()
                End If


            End If
        End If
    End Sub
    Private Sub BtnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClos.Click
        Dim cnfrmmsg As String
        cnfrmmsg = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmmsg = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub LstVewFnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewFnd.DoubleClick
        Try
            TxtDept.Text = LstVewFnd.SelectedItems(0).Text
            EdtRecrdNo = LstVewFnd.SelectedItems.Item(0).SubItems.Item(1).Text
            LstVewFnd.Visible = False
            Me.Size = New Size(430, 365)
            BtnSave.Enabled = True
            AllowEdt = True
            BtnSave.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub LstVewFnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewFnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            LstVewFnd_DoubleClick(sender, e)
        ElseIf e.KeyCode = Keys.Escape Then
            LstVewFnd.Visible = False
            Me.Size = New Size(430, 365)
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
            Me.Size = New Size(430, 365)
        End If
        BtnSave.Text = "&Save"
        BtnFind.Text = "&Find"
        If TxtDept.BackColor <> Color.White Then
            TxtDept.BackColor = Color.White
        End If
    End Sub


    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GroupBox1.KeyDown, Label1.KeyDown, LstVewFnd.KeyDown, TxtDept.KeyDown, Btnadd.KeyDown, BtnClos.KeyDown, BtnFind.KeyDown, BtnSave.KeyDown

        If e.KeyCode = Keys.Escape Then

            Me.Close()

        End If
    End Sub

    Private Sub TxtDept_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDept.TextChanged
        If TxtDept.BackColor <> Color.White Then
            TxtDept.BackColor = Color.White
        End If
    End Sub
End Class

Imports System.Data.SqlClient
Imports System.Data.DataTable
Imports System.Data

Public Class FrmMachineMstr
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

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtDept As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
    Friend WithEvents LstVewFnd As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMachineMstr))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnAdd = New System.Windows.Forms.Button
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
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BtnAdd)
        Me.GroupBox1.Controls.Add(Me.TxtDept)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnFind)
        Me.GroupBox1.Controls.Add(Me.BtnSave)
        Me.GroupBox1.Controls.Add(Me.BtnClos)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(404, 385)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.BackgroundImage = CType(resources.GetObject("BtnAdd.BackgroundImage"), System.Drawing.Image)
        Me.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdd.FlatAppearance.BorderSize = 0
        Me.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Location = New System.Drawing.Point(205, 342)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(90, 33)
        Me.BtnAdd.TabIndex = 4
        Me.BtnAdd.Text = "&Cancel"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'TxtDept
        '
        Me.TxtDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDept.Location = New System.Drawing.Point(132, 27)
        Me.TxtDept.MaxLength = 70
        Me.TxtDept.Name = "TxtDept"
        Me.TxtDept.Size = New System.Drawing.Size(254, 23)
        Me.TxtDept.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Machine Name"
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = System.Drawing.Color.Transparent
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFind.FlatAppearance.BorderSize = 0
        Me.BtnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Location = New System.Drawing.Point(104, 342)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(90, 33)
        Me.BtnFind.TabIndex = 3
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Location = New System.Drawing.Point(3, 342)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(90, 33)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnClos
        '
        Me.BtnClos.BackColor = System.Drawing.Color.Transparent
        Me.BtnClos.BackgroundImage = CType(resources.GetObject("BtnClos.BackgroundImage"), System.Drawing.Image)
        Me.BtnClos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClos.FlatAppearance.BorderSize = 0
        Me.BtnClos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnClos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClos.Location = New System.Drawing.Point(308, 342)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(90, 33)
        Me.BtnClos.TabIndex = 5
        Me.BtnClos.Text = "&Close"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'LstVewFnd
        '
        Me.LstVewFnd.AllowDrop = True
        Me.LstVewFnd.BackColor = System.Drawing.Color.White
        Me.LstVewFnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstVewFnd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVewFnd.ForeColor = System.Drawing.Color.Blue
        Me.LstVewFnd.GridLines = True
        Me.LstVewFnd.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstVewFnd.HoverSelection = True
        Me.LstVewFnd.Location = New System.Drawing.Point(419, 11)
        Me.LstVewFnd.MultiSelect = False
        Me.LstVewFnd.Name = "LstVewFnd"
        Me.LstVewFnd.Size = New System.Drawing.Size(337, 380)
        Me.LstVewFnd.TabIndex = 6
        Me.LstVewFnd.UseCompatibleStateImageBehavior = False
        Me.LstVewFnd.View = System.Windows.Forms.View.Details
        Me.LstVewFnd.Visible = False
        '
        'FrmMachineMstr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.BurlyWood
        Me.ClientSize = New System.Drawing.Size(759, 393)
        Me.Controls.Add(Me.LstVewFnd)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Navy
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmMachineMstr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Machine Master"
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
                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                'BtnSave.Enabled = False
                Indx = 0
                Exit Sub
            Else
                'BtnSave.Enabled = True
            End If
            Dim SveCnfrm As String
            SveCnfrm = MsgBox("Are you sure to Save this record?", MsgBoxStyle.YesNo)
            If SveCnfrm = vbYes Then
                If addFlag = True Then
                    CatCmd = New SqlCommand("Insert Into finact_MachinMstr(Machinname,Machintype,Machinadusrid,Machinaddt,Machindelstatus) values(@Machinname,@type,@adusrid,@addt,@delstatus)", FinActConn)
                    CatCmd.Parameters.AddWithValue("@Machinname", Trim(TxtDept.Text))
                    CatCmd.Parameters.AddWithValue("@type", Trim("Machin"))
                    CatCmd.Parameters.AddWithValue("@adusrid", Current_UsrId)
                    CatCmd.Parameters.AddWithValue("@addt", Now)
                    CatCmd.Parameters.AddWithValue("@delstatus", 1)
                ElseIf EdtFlag = True Then
                    CatCmd = New SqlCommand("update finact_Machinmstr set Machinname=@Machinname,Machindelstatus=@delstatus,Machinedtusrid=@edtusrid,Machinedtdt=@edtdt where Machinid=@Machinid", FinActConn)
                    CatCmd.Parameters.AddWithValue("@Machinname", Trim(TxtDept.Text))
                    CatCmd.Parameters.AddWithValue("@Machinid", EdtRecrdNo)
                    CatCmd.Parameters.AddWithValue("@delstatus", 1)
                    CatCmd.Parameters.AddWithValue("@edtusrid", Current_UsrId)
                    CatCmd.Parameters.AddWithValue("@edtdt", Now)
                End If

                Try
                    CatCmd.ExecuteNonQuery()
                    MsgBox("Record has been Saved successfully", MsgBoxStyle.Information)
                    ClrValue()

                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Violation of Primary key" + Chr(10) + "Name already exist, you can not insert Duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "Job Title Already Exist!")
                    '  MsgBox(ex.Message, MsgBoxStyle.Critical, "Department")
                    TxtDept.SelectAll()
                    TxtDept.Focus()
                    Exit Try
                Finally
                    CatCmd = Nothing
                    TxtDept.Focus()
                    'BtnAdd.Focus()
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
                    MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                    'BtnSave.Enabled = False
                    Indx = 0
                    Exit Sub
                Else
                    'BtnSave.Enabled = True
                End If

                If EdtFlag = True Then
                    CatCmd = New SqlCommand("update finact_Machinmstr set Machinname=@Machinname,Machindelstatus=@delstatus,Machinedtusrid=@edtusrid,Machinedtdt=@edtdt where Machinid=@Machinid", FinActConn)
                    CatCmd.Parameters.AddWithValue("@Machinname", Trim(TxtDept.Text))
                    CatCmd.Parameters.AddWithValue("@Machinid", EdtRecrdNo)
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
                    MsgBox("Violation of Primary key" + Chr(10) + "Name already exist, you can not insert Duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "Job Title Already Exist!")
                    ' MsgBox(ex.Message, MsgBoxStyle.Critical, "Department")
                    TxtDept.SelectAll()
                    TxtDept.Focus()
                    Exit Try
                Finally
                    CatCmd = Nothing
                    '  Btnadd.Focus()
                    TxtDept.Focus()
                End Try
                'ElseIf SveCnfrm = vbNo Then
                '    TxtDept.Focus()
                'End If
            Else

                If TxtDept.Text = "" Then
                    MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                    TxtDept.BackColor = Color.LemonChiffon
                    TxtDept.Focus()
                End If
                'MsgBox("Invalid Input", MsgBoxStyle.Critical, "Invalid")
                'Btnadd.Focus()
            End If
        End If

    End Sub

    Private Sub FrmdeptMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 430 'MeWidth / 1.45
            Me.Height = 419 'MeHeight / 3.7
            CheckAcess_Btn_frm(BtnAdd, BtnFind)
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
            Me.Height = 419

            LstVewFnd.Clear()
            LstVewFnd.Columns.Add("Name Of Department", LstVewFnd.Width, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Id", LstVewFnd.Width \ 1, HorizontalAlignment.Left)
            Dim LstItem As ListViewItem
            LstVewFnd.Visible = True
            CatCmd = New SqlCommand("Select * from finact_Machinmstr where Machindelstatus=1 and Machintype='" & Trim("Machin") & "' order by Machinname ", FinActConn)
            Try
                DtaRdr = CatCmd.ExecuteReader
                Dim x As Integer
                x = 0
                While DtaRdr.Read()
                    LstItem = LstVewFnd.Items.Add(DtaRdr("Machinname"), 1)
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("Machinid"))
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
            BtnSave.Text = "&Update"
            BtnFind.Text = "&Delete"
        ElseIf BtnFind.Text = "&Delete" Then
            If TxtDept.Text = "" Or EdtRecrdNo < 1 Then
                MsgBox("No record is present to delete", MsgBoxStyle.Information)
                Exit Sub
            End If
            If TxtDept.Text <> "" And EdtRecrdNo > 0 Then
                Select Case MsgBox("Are you sure to Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                    Case MsgBoxResult.Yes

                        CatCmd = New SqlCommand("update finact_Machinmstr set Machinname=@Machinname,Machindelstatus=@delstatus,Machindelusrid=@delusrid,Machindeldt=@deldt where Machinid=@Machinid", FinActConn)
                        CatCmd.Parameters.AddWithValue("@Machinname", Trim(TxtDept.Text))
                        CatCmd.Parameters.AddWithValue("@Machinid", EdtRecrdNo)
                        CatCmd.Parameters.AddWithValue("@delstatus", 0)
                        CatCmd.Parameters.AddWithValue("@delusrid", Current_UsrId)
                        CatCmd.Parameters.AddWithValue("@deldt", Now)
                        Try
                            CatCmd.ExecuteNonQuery()
                            MsgBox("Current Record has been Deleted successfully", MsgBoxStyle.Information, "Current Record Deleted")
                            BtnSave.Text = "&Save"
                            BtnFind.Text = "&Find"
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Exit Try
                        Finally
                            CatCmd = Nothing
                            TxtDept.Text = ""
                            EdtRecrdNo = 0
                            TxtDept.Focus()
                        End Try
                    Case MsgBoxResult.No
                        BtnFind.Focus()

                End Select
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
            Me.Size = New Size(430, 419)
            AllowEdt = True
            BtnFind.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub LstVewFnd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LstVewFnd.Validating
        ' LstVewFnd_DoubleClick(sender, e)
    End Sub

    Private Sub LstVewFnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewFnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            LstVewFnd_DoubleClick(sender, e)
        ElseIf e.KeyCode = Keys.Escape Then
            LstVewFnd.Visible = False
            Me.Size = New Size(430, 419)
        End If
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

    Private Sub BtnAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        ClrValue()
        addFlag = True
        EdtFlag = False
        AllowEdt = False
        TxtDept.Focus()
        If LstVewFnd.Visible = True Then
            LstVewFnd.Visible = False
            Me.Size = New Size(430, 419)
        End If
        If TxtDept.BackColor <> Color.White Then
            TxtDept.BackColor = Color.White
        End If
        BtnFind.Text = "&Find"
        BtnSave.Text = "&Save"

    End Sub

    Private Sub Btnall_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.GotFocus, BtnAdd.GotFocus _
    , BtnClos.GotFocus, BtnFind.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GroupBox1.KeyDown, Label1.KeyDown, LstVewFnd.KeyDown, TxtDept.KeyDown, BtnAdd.KeyDown, BtnClos.KeyDown, BtnFind.KeyDown, BtnSave.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub AllControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDept.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TxtDept_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDept.TextChanged
        If TxtDept.BackColor <> Color.White Then
            TxtDept.BackColor = Color.White
        End If

    End Sub

    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Leave, BtnClos.Leave, BtnFind.Leave, BtnSave.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent

        Catch ex As Exception

        End Try

    End Sub
End Class
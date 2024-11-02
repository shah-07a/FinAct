Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCsCMstr
    Inherits System.Windows.Forms.Form
    Dim indx As Integer
    Dim CoCsCCmd As SqlCommand
    Dim DtaRdr As SqlDataReader
    Dim EdtRecrdNo As Integer
    Dim EdtFlag As Boolean
    Dim AddWithValueFlag As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'AddWithValue any initialization after the InitializeComponent() call

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCty As System.Windows.Forms.TextBox
    Friend WithEvents TxtState As System.Windows.Forms.TextBox
    Friend WithEvents TxtContry As System.Windows.Forms.TextBox
    Friend WithEvents BtnAddWithValue As System.Windows.Forms.Button
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
    Friend WithEvents LstVewFnd As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCsCMstr))
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCty = New System.Windows.Forms.TextBox
        Me.TxtState = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtContry = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnAddWithValue = New System.Windows.Forms.Button
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnClos = New System.Windows.Forms.Button
        Me.LstVewFnd = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "City   "
        '
        'TxtCty
        '
        Me.TxtCty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCty.Location = New System.Drawing.Point(82, 8)
        Me.TxtCty.MaxLength = 30
        Me.TxtCty.Name = "TxtCty"
        Me.TxtCty.Size = New System.Drawing.Size(343, 20)
        Me.TxtCty.TabIndex = 0
        '
        'TxtState
        '
        Me.TxtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtState.Location = New System.Drawing.Point(82, 96)
        Me.TxtState.MaxLength = 30
        Me.TxtState.Name = "TxtState"
        Me.TxtState.Size = New System.Drawing.Size(343, 20)
        Me.TxtState.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "State  "
        '
        'TxtContry
        '
        Me.TxtContry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtContry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtContry.Location = New System.Drawing.Point(82, 184)
        Me.TxtContry.MaxLength = 30
        Me.TxtContry.Name = "TxtContry"
        Me.TxtContry.Size = New System.Drawing.Size(343, 20)
        Me.TxtContry.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Country   "
        '
        'BtnAddWithValue
        '
        Me.BtnAddWithValue.BackColor = System.Drawing.Color.Transparent
        Me.BtnAddWithValue.BackgroundImage = CType(resources.GetObject("BtnAddWithValue.BackgroundImage"), System.Drawing.Image)
        Me.BtnAddWithValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAddWithValue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAddWithValue.FlatAppearance.BorderSize = 0
        Me.BtnAddWithValue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnAddWithValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddWithValue.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddWithValue.ForeColor = System.Drawing.Color.Navy
        Me.BtnAddWithValue.Location = New System.Drawing.Point(219, 272)
        Me.BtnAddWithValue.Name = "BtnAddWithValue"
        Me.BtnAddWithValue.Size = New System.Drawing.Size(100, 33)
        Me.BtnAddWithValue.TabIndex = 5
        Me.BtnAddWithValue.Text = "&Cancel"
        Me.BtnAddWithValue.UseVisualStyleBackColor = False
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
        Me.BtnFind.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.ForeColor = System.Drawing.Color.Navy
        Me.BtnFind.Location = New System.Drawing.Point(113, 272)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(100, 33)
        Me.BtnFind.TabIndex = 4
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
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Navy
        Me.BtnSave.Location = New System.Drawing.Point(7, 272)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(100, 33)
        Me.BtnSave.TabIndex = 3
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
        Me.BtnClos.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClos.ForeColor = System.Drawing.Color.Navy
        Me.BtnClos.Location = New System.Drawing.Point(325, 272)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(100, 33)
        Me.BtnClos.TabIndex = 6
        Me.BtnClos.Text = "C&lose"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'LstVewFnd
        '
        Me.LstVewFnd.AllowDrop = True
        Me.LstVewFnd.BackColor = System.Drawing.Color.LightCyan
        Me.LstVewFnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstVewFnd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVewFnd.ForeColor = System.Drawing.Color.Navy
        Me.LstVewFnd.GridLines = True
        Me.LstVewFnd.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstVewFnd.HoverSelection = True
        Me.LstVewFnd.Location = New System.Drawing.Point(451, 8)
        Me.LstVewFnd.MultiSelect = False
        Me.LstVewFnd.Name = "LstVewFnd"
        Me.LstVewFnd.Size = New System.Drawing.Size(376, 297)
        Me.LstVewFnd.TabIndex = 4
        Me.LstVewFnd.UseCompatibleStateImageBehavior = False
        Me.LstVewFnd.View = System.Windows.Forms.View.Details
        Me.LstVewFnd.Visible = False
        '
        'FrmCsCMstr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.MediumTurquoise
        Me.ClientSize = New System.Drawing.Size(828, 311)
        Me.Controls.Add(Me.LstVewFnd)
        Me.Controls.Add(Me.BtnAddWithValue)
        Me.Controls.Add(Me.TxtCty)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtState)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtContry)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnClos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCsCMstr"
        Me.Text = "City,State and Country Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub ChekEmpty()
        
      
        With TxtContry
            If .Text = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                indx = indx + 1
                .Focus()
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
        With TxtState
            If .Text = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                indx = indx + 1
                .Focus()
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
        With TxtCty
            If .Text = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                indx = indx + 1
                .Focus()
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
    End Sub

    Private Sub ClrValue()
        TxtCty.Text = ""
        TxtState.Text = ""
        TxtContry.Text = ""
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        If Trim(BtnSave.Text) = "&Save" Then
            AddWithValueFlag = True
            EdtFlag = False
        ElseIf Trim(BtnSave.Text) = "&Update" Then
            AddWithValueFlag = False
            EdtFlag = True
        End If
        If BtnSave.Text = "&Save" Or BtnSave.Text = "&Update" Then

            ChekEmpty()
            If indx <> 0 Then
                'BtnSave.Enabled = False
                indx = 0
                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                Exit Sub
            Else
                'BtnSave.Enabled = True
            End If
            Dim SveCnfrm As String
            SveCnfrm = MsgBox("Are you sure to Save this record?", MsgBoxStyle.YesNo, "Save")
            If SveCnfrm = vbYes Then
                If AddWithValueFlag = True Then
                    CoCsCCmd = New SqlCommand("Insert Into finactcscmstr(cscctyname,cscstatename,csccontry,csccontry1,csctype) values(@ctyname,@CscState,@cscContry,@csccontry1,@csctype)", FinActConn)
                    CoCsCCmd.Parameters.AddWithValue("@ctyName", Trim(TxtCty.Text))
                    CoCsCCmd.Parameters.AddWithValue("@cscstate", Trim(TxtState.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csccontry", Trim(TxtContry.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csccontry1", Trim("N.A"))
                    CoCsCCmd.Parameters.AddWithValue("@csctype", ("Outer"))
                ElseIf EdtFlag = True Then
                    If EdtRecrdNo = 0 Then
                        MsgBox("Invalid input!,select an item from list.", MsgBoxStyle.Critical, "Invalid action!!!")
                        ClrValue()
                        Me.LstVewFnd.Focus()
                        Exit Sub
                    End If
                    CoCsCCmd = New SqlCommand("update finactcscmstr set cscctyname=@ctyname,cscstatename=@CscState,csccontry=@cscContry,csccontry1=@cscContry1,csctype=@csctype where cscid=@cscid", FinActConn)
                    CoCsCCmd.Parameters.AddWithValue("@ctyName", Trim(TxtCty.Text))
                    CoCsCCmd.Parameters.AddWithValue("@cscid", EdtRecrdNo)
                    CoCsCCmd.Parameters.AddWithValue("@cscstate", Trim(TxtState.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csccontry", Trim(TxtContry.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csccontry1", Trim("N.A"))
                    CoCsCCmd.Parameters.AddWithValue("@csctype", ("Outer"))
                End If

                Try
                    IntHtCmMm(0) = Trim(TxtCty.Text)

                    CoCsCCmd.ExecuteNonQuery()
                    MsgBox("Record has been Saved Successfully.", MsgBoxStyle.Information)
                    ClrValue()
                    TxtCty.Focus()
                    ' BtnAddWithValue.Focus()
                Catch ex As SqlException
                    If ex.Number = 2627 Then
                        MsgBox("Violation of Primary key" + Chr(10) + "City Name already exist, you can not insert Duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "City Name Alread Exist!")
                    Else
                        MsgBox(ex.Message)
                    End If
                    TxtCty.SelectAll()
                    TxtCty.Focus()
                    Exit Try
                Finally
                    CoCsCCmd = Nothing
                End Try
            ElseIf SveCnfrm = vbNo Then
                TxtCty.Focus()
            End If
        ElseIf BtnSave.Text = "&Edit" Then
            ' TxtCty.Focus()
            AddWithValueFlag = False
            EdtFlag = True
            ChekEmpty()
            If indx <> 0 Then

                indx = 0
                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                Exit Sub
            End If
            Dim SveCnfrm As String
            SveCnfrm = MsgBox("Are you sure to Edit this record?", MsgBoxStyle.YesNo, "Save")
            If SveCnfrm = vbYes Then

                If EdtFlag = True Then
                    CoCsCCmd = New SqlCommand("update finactcscmstr set cscctyname=@ctyname,cscstatename=@CscState,csccontry=@cscContry,csctype=@csctype where cscid=@cscid", FinActConn)
                    CoCsCCmd.Parameters.AddWithValue("@ctyName", Trim(TxtCty.Text))
                    CoCsCCmd.Parameters.AddWithValue("@cscid", EdtRecrdNo)
                    CoCsCCmd.Parameters.AddWithValue("@cscstate", Trim(TxtState.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csccontry", Trim(TxtContry.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csctype", ("Outer"))
                End If

                Try
                    IntHtCmMm(0) = Trim(TxtCty.Text)

                    CoCsCCmd.ExecuteNonQuery()
                    MsgBox("Record has been Updated Successfully.", MsgBoxStyle.Information)
                    ClrValue()
                    TxtCty.Focus()
                    'BtnAddWithValue.Focus()
                    BtnSave.Text = "&Save"
                    BtnFind.Text = "&Find"
                Catch ex As Exception
                    'MsgBox(ex.Message)
                    MsgBox("Violation of Primary key" + Chr(10) + "City Name already exist, you can not insert duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "City Name Alread Exist!")
                    TxtCty.SelectAll()
                    TxtCty.Focus()
                    Exit Try
                Finally
                    CoCsCCmd = Nothing
                End Try
            ElseIf SveCnfrm = vbNo Then
                TxtCty.Focus()

            End If
        End If
    End Sub

    Private Sub BtnAddWithValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddWithValue.Click
        ClrValue()
        TxtCty.Focus()
        AddWithValueFlag = True
        EdtFlag = False
        If LstVewFnd.Visible = True Then
            LstVewFnd.Visible = False
            Me.Height = 337
            Me.Width = 447

        End If
        BtnFind.Text = "&Find"
        BtnSave.Text = "&Save"
        If TxtCty.BackColor <> Color.White Then
            TxtCty.BackColor = Color.White
        End If
        If TxtState.BackColor <> Color.White Then
            TxtState.BackColor = Color.White
        End If
        If TxtContry.BackColor <> Color.White Then
            TxtContry.BackColor = Color.White
        End If
    End Sub

    Private Sub TxtContry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtContry.KeyPress

        ''Select Case e.KeyChar
        ''    Case Microsoft.VisualBasic.ChrW(13)
        ''        BtnSave.Focus()
        ''    Case Microsoft.VisualBasic.ChrW(9)
        ''        BtnSave.Focus()
        ''    Case Else

        ''End Select
    End Sub

    Private Sub TxtState_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtState.GotFocus
        If AddWithValueFlag = True Then
            TxtState.Text = "Punjab"
        End If
        If TxtState.Text <> "" Then
            TxtState.SelectAll()
        End If
    End Sub

    Private Sub TxtContry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtContry.GotFocus
        If AddWithValueFlag = True Then
            TxtContry.Text = "India"
        End If
        If TxtContry.Text <> "" Then
            TxtContry.SelectAll()
        End If

    End Sub

    Private Sub TxtContry_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtContry.Leave
        Try
            If TxtContry.Text = "" Then
                TxtContry.BackColor = Color.LemonChiffon
                ''MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Field")
                ''TxtContry.Focus()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmCsCMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Left = 0
            Me.Top = 0
            Me.Width = 447
            Me.Height = 337
            CheckAcess_Btn_frm(BtnAddWithValue, BtnFind)
            EdtFlag = False
            AddWithValueFlag = True
            Me.TxtCty.Focus()
            Me.TxtCty.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckAcess_Btn_frm(ByVal BtnnAdd As Button, _
         ByVal BtnnFnd As Button)
        Select Case Trim(AcessRight)
            Case "OwnrFull"
                BtnnAdd.Enabled = True
                'BtnnEdt.Enabled = True
                'BtnnDel.Enabled = True
                BtnnFnd.Enabled = True
            Case "DataEntryMstr"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(208, 104)
                'BtnnEdt.Visible = False
                'BtnnDel.Visible = False
                BtnnFnd.Visible = False
            Case "PayRoll"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(208, 104)
                'BtnnEdt.Visible = False
                'BtnnDel.Visible = False
                BtnnFnd.Visible = False
        End Select
    End Sub

    Private Sub BtnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClos.Click
        Dim cnfrmmsg As String
        cnfrmmsg = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmmsg = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub Backcolor_chng()

        If TxtCty.BackColor <> Color.White Then
            TxtCty.BackColor = Color.White
        End If
        If TxtState.BackColor <> Color.White Then
            TxtState.BackColor = Color.White
        End If
        If TxtContry.BackColor <> Color.White Then
            TxtContry.BackColor = Color.White
        End If
    End Sub


    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        If BtnFind.Text = "&Find" Then
            Backcolor_chng()
            LstVewFnd.Clear()
            LstVewFnd.Columns.Add("Name Of City", LstVewFnd.Width, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Id", LstVewFnd.Width \ 3, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("State", LstVewFnd.Width \ 3, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Country", LstVewFnd.Width \ 3, HorizontalAlignment.Left)
            Dim LstItem As ListViewItem
            Me.Height = 337
            Me.Width = 834
            LstVewFnd.Visible = True
            CoCsCCmd = New SqlCommand("Select * from finactcscmstr where csctype='Outer' order by cscctyname ", FinActConn)
            Try
                DtaRdr = CoCsCCmd.ExecuteReader
                Dim x As Integer
                x = 0
                While DtaRdr.Read()
                    LstItem = LstVewFnd.Items.Add(DtaRdr("cscctyname"), 1)
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("cscid"))
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("cscstatename"))
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("csccontry"))
                    x += 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            Finally
                DtaRdr.Close()
                CoCsCCmd = Nothing
                LstVewFnd.Focus()
            End Try
            AddWithValueFlag = False
            EdtFlag = True
            BtnFind.Text = "&Delete"
            BtnSave.Text = "&Update"
        ElseIf BtnFind.Text = "&Delete" Then
            If TxtCty.Text = "" Or EdtRecrdNo < 1 Then
                MsgBox("No record is present to Delete.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ' Dim Cntrl As Control
            ' For Each Cntrl In Me.Controls
            If EdtRecrdNo > 0 Then 'TypeOf Cntrl Is TextBox And Cntrl.Text <> "" Then
                Dim delmsgconfrm As String
                delmsgconfrm = MsgBox("Are you sure to Delete this record?", MsgBoxStyle.YesNo)
                If delmsgconfrm = vbYes Then
                    CoCsCCmd = New SqlCommand("Delete  from finactcscmstr where cscid=@cscid", FinActConn)
                    CoCsCCmd.Parameters.AddWithValue("@cscid", EdtRecrdNo)
                    'CoCsCCmd.ExecuteNonQuery()
                    'MsgBox("Current record has been deleted successfully", MsgBoxStyle.Information, "Delete Record")
                    ' Cntrl.Text = ""

                ElseIf delmsgconfrm = vbNo Then
                    BtnFind.Focus()
                    Exit Sub
                End If

            End If

            'Next


            Try
                'CoCsCCmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Try
            Finally
                CoCsCCmd = Nothing
                MsgBox("Current Record has been Deleted Successfully.", MsgBoxStyle.Information, "Delete")
                ClrValue()
                EdtRecrdNo = 0
                BtnSave.Text = "&Save"
                BtnFind.Text = "&Find"
                TxtCty.Focus()
                BtnFind.Text = "&Find"

            End Try



        End If
    End Sub

    Private Sub LstVewFnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewFnd.DoubleClick
        Try
            TxtCty.Text = LstVewFnd.SelectedItems(0).Text
            EdtRecrdNo = LstVewFnd.SelectedItems.Item(0).SubItems.Item(1).Text
            TxtState.Text = LstVewFnd.SelectedItems.Item(0).SubItems.Item(2).Text
            TxtContry.Text = LstVewFnd.SelectedItems.Item(0).SubItems.Item(3).Text
            LstVewFnd.Visible = False
            Me.Height = 337
            Me.Width = 447
            ' BtnSave.Text = "&Update"
            'Btnedt.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub LstVewFnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewFnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            LstVewFnd_DoubleClick(sender, e)
        End If

    End Sub


    Private Sub FrmCsCMstr_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Show_FrmCsC = False Then
            Dim FrmCo As FrmCoGateway
            FrmCo = New FrmCoGateway
            FrmCo.MdiParent = FrmMainMdi.ActiveForm
            FrmCo.Show()
            Show_FrmCsC = True
        End If
    End Sub

    Private Sub BtnALL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddWithValue.GotFocus, BtnClos.GotFocus _
    , BtnFind.GotFocus, BtnSave.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Label1.KeyDown, LstVewFnd.KeyDown, BtnClos.KeyDown, BtnFind.KeyDown, BtnSave.KeyDown, BtnAddWithValue.KeyDown, Label2.KeyDown, Label3.KeyDown, TxtCty.KeyDown, TxtState.KeyDown, TxtContry.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AllControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtContry.KeyDown, TxtCty.KeyDown, TxtState.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCty.Leave
        Try
            If TxtCty.Text = "" Then
                TxtCty.BackColor = Color.LemonChiffon
                ''MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Field")
                ''TxtCty.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCty.TextChanged
        If TxtCty.BackColor <> Color.White Then
            TxtCty.BackColor = Color.White
        End If
    End Sub


    Private Sub TxtState_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtState.Leave
        Try
            If TxtState.Text = "" Then
                TxtState.BackColor = Color.LemonChiffon
                '' MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Field")
                ''TxtState.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtState_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtState.TextChanged
        If TxtState.BackColor <> Color.White Then
            TxtState.BackColor = Color.White
        End If
    End Sub

    Private Sub TxtContry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtContry.TextChanged
        If TxtContry.BackColor <> Color.White Then
            TxtContry.BackColor = Color.White
        End If
    End Sub

   
    Private Sub BtnALL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddWithValue.Leave, BtnClos.Leave _
    , BtnFind.Leave, BtnSave.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
End Class

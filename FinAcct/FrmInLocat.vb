Imports System.Data
Imports System.Data.SqlClient

Public Class FrmInLocat
    Inherits System.Windows.Forms.Form
    Dim indx As Integer
    Dim CoCsCCmd As SqlCommand
    Dim DtaRdr As SqlDataReader
    Dim EdtRecrdNo As Integer
    Dim EdtFlag As Boolean
    Friend WithEvents Txtsubpos As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LstVewFnd As System.Windows.Forms.ListView
    Friend WithEvents BtnAddWithValue As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
    Friend WithEvents TxtGodown As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Txtunitname As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInLocat))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Txtsubpos = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.LstVewFnd = New System.Windows.Forms.ListView
        Me.BtnAddWithValue = New System.Windows.Forms.Button
        Me.TxtGodown = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtLocation = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txtunitname = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnClos = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Txtsubpos)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LstVewFnd)
        Me.Panel1.Controls.Add(Me.BtnAddWithValue)
        Me.Panel1.Controls.Add(Me.TxtGodown)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TxtLocation)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Txtunitname)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.BtnFind)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.BtnClos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(828, 311)
        Me.Panel1.TabIndex = 0
        '
        'Txtsubpos
        '
        Me.Txtsubpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtsubpos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtsubpos.Location = New System.Drawing.Point(119, 204)
        Me.Txtsubpos.MaxLength = 30
        Me.Txtsubpos.Name = "Txtsubpos"
        Me.Txtsubpos.Size = New System.Drawing.Size(294, 20)
        Me.Txtsubpos.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(3, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Sub Position  "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.LstVewFnd.Location = New System.Drawing.Point(419, 3)
        Me.LstVewFnd.MultiSelect = False
        Me.LstVewFnd.Name = "LstVewFnd"
        Me.LstVewFnd.Size = New System.Drawing.Size(402, 301)
        Me.LstVewFnd.TabIndex = 17
        Me.LstVewFnd.UseCompatibleStateImageBehavior = False
        Me.LstVewFnd.View = System.Windows.Forms.View.Details
        Me.LstVewFnd.Visible = False
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
        Me.BtnAddWithValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddWithValue.ForeColor = System.Drawing.Color.MediumBlue
        Me.BtnAddWithValue.Location = New System.Drawing.Point(210, 268)
        Me.BtnAddWithValue.Name = "BtnAddWithValue"
        Me.BtnAddWithValue.Size = New System.Drawing.Size(100, 33)
        Me.BtnAddWithValue.TabIndex = 6
        Me.BtnAddWithValue.Text = "&Cancel"
        Me.BtnAddWithValue.UseVisualStyleBackColor = False
        '
        'TxtGodown
        '
        Me.TxtGodown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGodown.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtGodown.Location = New System.Drawing.Point(119, 3)
        Me.TxtGodown.MaxLength = 30
        Me.TxtGodown.Name = "TxtGodown"
        Me.TxtGodown.Size = New System.Drawing.Size(294, 20)
        Me.TxtGodown.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Name "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtLocation
        '
        Me.TxtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLocation.Location = New System.Drawing.Point(119, 70)
        Me.TxtLocation.MaxLength = 30
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.Size = New System.Drawing.Size(294, 20)
        Me.TxtLocation.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(3, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Location  "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtunitname
        '
        Me.Txtunitname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtunitname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtunitname.Location = New System.Drawing.Point(119, 137)
        Me.Txtunitname.MaxLength = 30
        Me.Txtunitname.Name = "Txtunitname"
        Me.Txtunitname.Size = New System.Drawing.Size(294, 20)
        Me.Txtunitname.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(3, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Main Position  "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.BtnFind.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.ForeColor = System.Drawing.Color.MediumBlue
        Me.BtnFind.Location = New System.Drawing.Point(108, 268)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(100, 33)
        Me.BtnFind.TabIndex = 5
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
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.MediumBlue
        Me.BtnSave.Location = New System.Drawing.Point(6, 268)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(100, 33)
        Me.BtnSave.TabIndex = 4
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
        Me.BtnClos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClos.ForeColor = System.Drawing.Color.MediumBlue
        Me.BtnClos.Location = New System.Drawing.Point(312, 268)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(100, 33)
        Me.BtnClos.TabIndex = 7
        Me.BtnClos.Text = "C&lose"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'FrmInLocat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(828, 311)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmInLocat"
        Me.Text = "Set Inner Locations"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub FrmInLocat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Left = 0
            Me.Top = 0
            Me.Width = 427
            Me.Height = 337
            EdtFlag = False
            AddWithValueFlag = True
            CheckAcess_Btn_frm(BtnAddWithValue, BtnFind)
            Me.TxtGodown.Focus()
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
                BtnnAdd.Location = New System.Drawing.Point(208, 112)
                BtnnFnd.Visible = False
            Case "PayRoll"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(208, 112)
                BtnnFnd.Visible = False
        End Select
    End Sub
    Private Sub ChekEmpty()
        With Txtsubpos
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
        With Txtunitname
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

        With TxtLocation
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

        With TxtGodown
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
        TxtGodown.Text = ""
        TxtLocation.Text = ""
        Txtunitname.Text = ""
        Txtsubpos.Text = ""
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
                MsgBox("Blank fields not allowed", MsgBoxStyle.Information, "Blank Field")
                indx = 0
                Exit Sub
            Else
            End If
            Dim SveCnfrm As String
            SveCnfrm = MsgBox("Are you sure to Save this record?", MsgBoxStyle.YesNo)
            If SveCnfrm = vbYes Then
                If AddWithValueFlag = True Then
                    CoCsCCmd = New SqlCommand("Insert Into finactcscmstr values(@ctyname,@CscState,@cscContry,@cscContry,@csctype)", FinActConn)
                    CoCsCCmd.Parameters.AddWithValue("@ctyName", Trim(TxtGodown.Text))
                    CoCsCCmd.Parameters.AddWithValue("@cscstate", Trim(TxtLocation.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csccontry", Trim(Txtunitname.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csccontry1", Trim(Txtsubpos.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csctype", ("Inner"))
                ElseIf EdtFlag = True Then
                    If EdtRecrdNo = 0 Then
                        MsgBox("Invalid Input!,Select an item from list.", MsgBoxStyle.Critical, "Invalid Action!!")
                        ClrValue()
                        Me.LstVewFnd.Focus()
                        Exit Sub
                    End If
                    CoCsCCmd = New SqlCommand("update finactcscmstr set cscctyname=@ctyname,cscstatename=@CscState,csccontry=@cscContry,csccontry1=@cscContry1,csctype=@csctype where cscid=@cscid", FinActConn)
                    CoCsCCmd.Parameters.AddWithValue("@ctyName", Trim(TxtGodown.Text))
                    CoCsCCmd.Parameters.AddWithValue("@cscid", EdtRecrdNo)
                    CoCsCCmd.Parameters.AddWithValue("@cscstate", Trim(TxtLocation.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csccontry", Trim(Txtunitname.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csccontry1", Trim(Txtsubpos.Text))
                    CoCsCCmd.Parameters.AddWithValue("@csctype", ("Inner"))
                End If

                Try
                    If FrmShow_flag(1) = True Then  '+****for item master
                        IntHtCmMm(1) = Trim(TxtGodown.Text)
                    End If
                    If FrmShow_flag(2) = True Then  '+****for bom master
                        IntHtCmMm(2) = Trim(TxtGodown.Text)
                    End If
                    If FrmShow_flag(6) = True Then  '+****for purchase order
                        IntHtCmMm(6) = Trim(TxtGodown.Text)
                    End If
                    If FrmShow_flag(12) = True Then
                        IntHtCmMm(12) = Trim(TxtGodown.Text)
                    End If
                    If FrmShow_flag(13) = True Then
                        IntHtCmMm(13) = Trim(TxtGodown.Text)
                    End If
                    CoCsCCmd.ExecuteNonQuery()
                    MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information)
                    ClrValue()
                    TxtGodown.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Violation of Primary key" + Chr(10) + "Name already exist, you can not insert Duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "City Name Alread Exist!")
                    TxtGodown.SelectAll()
                    TxtGodown.Focus()
                    Exit Try
                Finally
                    CoCsCCmd = Nothing
                End Try
            ElseIf SveCnfrm = vbNo Then
                TxtGodown.Focus()
            End If
        ElseIf BtnSave.Text = "&Edit" Then
            TxtGodown.Focus()
            AddWithValueFlag = False
            EdtFlag = True
            ChekEmpty()
            If indx <> 0 Then
                MsgBox("Blank fields not allowed", MsgBoxStyle.Information, "Blank Field")
                indx = 0
                Exit Sub
            Else
            End If
            If EdtFlag = True Then
                CoCsCCmd = New SqlCommand("update finactcscmstr set cscctyname=@ctyname,cscstatename=@CscState,csccontry=@cscContry,csctype=@csctype where cscid=@cscid", FinActConn)
                CoCsCCmd.Parameters.AddWithValue("@ctyName", Trim(TxtGodown.Text))
                CoCsCCmd.Parameters.AddWithValue("@cscid", EdtRecrdNo)
                CoCsCCmd.Parameters.AddWithValue("@cscstate", Trim(TxtLocation.Text))
                CoCsCCmd.Parameters.AddWithValue("@csccontry", Trim(Txtunitname.Text))
                CoCsCCmd.Parameters.AddWithValue("@csctype", ("Inner"))
            End If

            Try
                CoCsCCmd.ExecuteNonQuery()
                MsgBox("Record has been Updated Successfully", MsgBoxStyle.Information)
                ClrValue()
                BtnSave.Text = "&Save"
                BtnFind.Text = "&Find"
                TxtGodown.Focus()
            Catch ex As Exception
                MsgBox("Violation of Primary key" + Chr(10) + "Name already exist, you can not insert Duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "City Name Alread Exist!")
                TxtGodown.SelectAll()
                TxtGodown.Focus()
                Exit Try
            Finally
                CoCsCCmd = Nothing
            End Try
        End If
    End Sub

    Private Sub BtnAddWithValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddWithValue.Click
        ClrValue()
        TxtGodown.Focus()
        AddWithValueFlag = True
        EdtFlag = False
        If LstVewFnd.Visible = True Then
            LstVewFnd.Visible = False
            Me.Width = 427
            Me.Height = 337
        End If
        BtnSave.Text = "&Save"
        BtnFind.Text = "&Find"
        If TxtGodown.BackColor <> Color.White Then
            TxtGodown.BackColor = Color.White
        End If

        If TxtLocation.BackColor <> Color.White Then
            TxtLocation.BackColor = Color.White
        End If

        If Txtunitname.BackColor <> Color.White Then
            Txtunitname.BackColor = Color.White
        End If
    End Sub

  
    Private Sub TxtState_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLocation.GotFocus
        If AddWithValueFlag = True Then
            ' TxtLocation.Text = "Punjab"
        End If

        TxtLocation.SelectAll()
    End Sub

    Private Sub TxtContry_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtunitname.GotFocus
        If AddWithValueFlag = True Then
            ' Txtunitname.Text = "India"
        End If

        Txtunitname.SelectAll()
    End Sub

    Private Sub BtnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClos.Click
        Dim cnfrmmsg As String
        cnfrmmsg = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmmsg = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub Backcolor_change()
        If TxtGodown.BackColor <> Color.White Then
            TxtGodown.BackColor = Color.White
        End If
        If TxtLocation.BackColor <> Color.White Then
            TxtLocation.BackColor = Color.White
        End If
        If Txtunitname.BackColor <> Color.White Then
            Txtunitname.BackColor = Color.White
        End If

    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        If BtnFind.Text = "&Find" Then
            Backcolor_change()
            LstVewFnd.Clear()
            LstVewFnd.Columns.Add("Name ", LstVewFnd.Width, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Id", LstVewFnd.Width \ 3, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Location", LstVewFnd.Width \ 3, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Main Position", LstVewFnd.Width \ 4, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Sub Position", LstVewFnd.Width \ 4, HorizontalAlignment.Left)
            Dim LstItem As ListViewItem
            Me.Width = 834
            Me.Height = 337
            LstVewFnd.Visible = True
            CoCsCCmd = New SqlCommand("Select * from finactcscmstr where csctype='Inner' order by cscctyname ", FinActConn)
            Try
                DtaRdr = CoCsCCmd.ExecuteReader
                Dim x As Integer
                x = 0
                While DtaRdr.Read()
                    LstItem = LstVewFnd.Items.Add(DtaRdr("cscctyname"), 1)
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("cscid"))
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("cscstatename"))
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("csccontry"))
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("csccontry1"))
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
            If TxtGodown.Text = "" Or EdtRecrdNo < 1 Then
                MsgBox("No record is present to delete", MsgBoxStyle.Information)
                Exit Sub
            End If
            If EdtRecrdNo > 0 Then ' TypeOf Cntrl Is TextBox And Cntrl.Text <> "" Then
                Dim Delmsg As String
                Delmsg = MsgBox("Are you sure to delete this record?", MsgBoxStyle.YesNo)
                If Delmsg = vbYes Then
                    CoCsCCmd = New SqlCommand("Delete  from finactcscmstr where cscid=@cscid", FinActConn)
                    CoCsCCmd.Parameters.AddWithValue("@cscid", EdtRecrdNo)
                ElseIf Delmsg = vbNo Then
                    BtnFind.Focus()
                    Exit Sub
                End If

            End If
            Try
                '  CoCsCCmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Try
            Finally
                CoCsCCmd = Nothing
                MsgBox("Current Record has been Deleted successfully", MsgBoxStyle.Information, "Current Record Deleted")
                ClrValue()
                EdtRecrdNo = 0
                BtnSave.Text = "&Save"
                BtnFind.Text = "&Find"
                TxtGodown.Focus()
            End Try


        End If

    End Sub

    Private Sub LstVewFnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewFnd.DoubleClick
        Try
            TxtGodown.Text = LstVewFnd.SelectedItems(0).Text
            EdtRecrdNo = LstVewFnd.SelectedItems.Item(0).SubItems.Item(1).Text
            TxtLocation.Text = LstVewFnd.SelectedItems.Item(0).SubItems.Item(2).Text
            Txtunitname.Text = LstVewFnd.SelectedItems.Item(0).SubItems.Item(3).Text
            Txtsubpos.Text = LstVewFnd.SelectedItems.Item(0).SubItems.Item(4).Text
            LstVewFnd.Visible = False
            Me.Width = 427
            Me.Height = 337
            BtnSave.Enabled = True
            BtnSave.Focus()
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

    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddWithValue.GotFocus, BtnClos.GotFocus _
    , BtnFind.GotFocus, BtnSave.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Label1.KeyDown, LstVewFnd.KeyDown, BtnClos.KeyDown, BtnFind.KeyDown, BtnSave.KeyDown, BtnAddWithValue.KeyDown, Panel1.KeyDown

        If e.KeyCode = Keys.Escape Then

            Me.Close()

        End If
    End Sub

    Private Sub AllControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGodown.KeyDown, TxtLocation.KeyDown, Txtsubpos.KeyDown, Txtunitname.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtGodown_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGodown.Leave
        Try
            If TxtGodown.Text = "" Then
                TxtGodown.BackColor = Color.LemonChiffon
                MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank field")
                ''  TxtGodown.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtGodown_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGodown.TextChanged
        If TxtGodown.BackColor <> Color.White Then
            TxtGodown.BackColor = Color.White
        End If
    End Sub


    Private Sub TxtLocation_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLocation.Leave
        Try
            If TxtLocation.Text = "" Then
                TxtLocation.BackColor = Color.LemonChiffon
                MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank field")
                TxtLocation.Focus()
           
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtLocation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLocation.TextChanged
        If TxtLocation.BackColor <> Color.White Then
            TxtLocation.BackColor = Color.White
        End If
    End Sub

    Private Sub Txtunitname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtunitname.TextChanged
        If Txtunitname.BackColor <> Color.White Then
            Txtunitname.BackColor = Color.White
        End If
    End Sub

    Private Sub Txtunitname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtunitname.Leave
        Try
            If Txtunitname.Text = "" Then
                Txtunitname.BackColor = Color.LemonChiffon
                MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank field")
                Txtunitname.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddWithValue.Leave, BtnClos.Leave _
    , BtnFind.Leave, BtnSave.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent

        Catch ex As Exception

        End Try

    End Sub
End Class

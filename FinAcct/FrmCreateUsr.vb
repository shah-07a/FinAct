Imports System.Data
Imports system.data.SqlClient
Imports FinAcct.EnCryp_DeCryp_String
Public Class FrmCreateUsr
    Inherits System.Windows.Forms.Form

    Dim findflag As Boolean = False
    Dim Hintid As Integer
    Dim UsrIndx As Integer
    Dim UsrCmd As SqlCommand
    Dim UsrCmd1 As SqlCommand
    Dim UsrRdr As SqlDataReader
    Dim UsrRdr1 As SqlDataReader
    Dim UsrSqlAdptr As SqlDataAdapter
    Dim UsrDSet As DataSet
    Dim UsrAcess, Seltxt As String
    Dim Usrid1 As Integer = 0
    Dim Uflag As Boolean = False
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents cmbxId As System.Windows.Forms.ComboBox
    Friend WithEvents cmbxHint As System.Windows.Forms.ComboBox
    Friend WithEvents lblHint As System.Windows.Forms.Label
    Friend WithEvents BtnUsave As System.Windows.Forms.Button
    Friend WithEvents Btndel As System.Windows.Forms.Button
    Friend WithEvents Btnfind As System.Windows.Forms.Button
    Friend WithEvents BtnUclos As System.Windows.Forms.Button
    Friend WithEvents lblAns As System.Windows.Forms.Label
    Friend WithEvents txtans As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbxUsrRole As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbxAc As System.Windows.Forms.ComboBox
    Friend WithEvents LblAc As System.Windows.Forms.Label
    Dim UsrDel As Boolean = False
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txtusrname As System.Windows.Forms.TextBox
    Friend WithEvents TxtPass As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txtpass1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblConfrm As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCreateUsr))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CmbxAc = New System.Windows.Forms.ComboBox
        Me.CmbxUsrRole = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.BtnUsave = New System.Windows.Forms.Button
        Me.LblAc = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblAns = New System.Windows.Forms.Label
        Me.Btndel = New System.Windows.Forms.Button
        Me.Btnfind = New System.Windows.Forms.Button
        Me.BtnUclos = New System.Windows.Forms.Button
        Me.cmbxHint = New System.Windows.Forms.ComboBox
        Me.cmbxId = New System.Windows.Forms.ComboBox
        Me.lblHint = New System.Windows.Forms.Label
        Me.lblId = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblConfrm = New System.Windows.Forms.Label
        Me.Txtusrname = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPass = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtans = New System.Windows.Forms.TextBox
        Me.Txtpass1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CmbxAc)
        Me.Panel1.Controls.Add(Me.CmbxUsrRole)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.BtnUsave)
        Me.Panel1.Controls.Add(Me.LblAc)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblAns)
        Me.Panel1.Controls.Add(Me.Btndel)
        Me.Panel1.Controls.Add(Me.Btnfind)
        Me.Panel1.Controls.Add(Me.BtnUclos)
        Me.Panel1.Controls.Add(Me.cmbxHint)
        Me.Panel1.Controls.Add(Me.cmbxId)
        Me.Panel1.Controls.Add(Me.lblHint)
        Me.Panel1.Controls.Add(Me.lblId)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblConfrm)
        Me.Panel1.Controls.Add(Me.Txtusrname)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TxtPass)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtans)
        Me.Panel1.Controls.Add(Me.Txtpass1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(8, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(552, 524)
        Me.Panel1.TabIndex = 0
        '
        'CmbxAc
        '
        Me.CmbxAc.FormattingEnabled = True
        Me.CmbxAc.Location = New System.Drawing.Point(149, 350)
        Me.CmbxAc.Name = "CmbxAc"
        Me.CmbxAc.Size = New System.Drawing.Size(287, 22)
        Me.CmbxAc.TabIndex = 7
        Me.CmbxAc.TabStop = False
        Me.CmbxAc.Visible = False
        '
        'CmbxUsrRole
        '
        Me.CmbxUsrRole.FormattingEnabled = True
        Me.CmbxUsrRole.Location = New System.Drawing.Point(149, 295)
        Me.CmbxUsrRole.Name = "CmbxUsrRole"
        Me.CmbxUsrRole.Size = New System.Drawing.Size(387, 22)
        Me.CmbxUsrRole.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(450, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 32)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "System could not found any record."
        Me.Label6.Visible = False
        '
        'BtnUsave
        '
        Me.BtnUsave.BackColor = System.Drawing.Color.Transparent
        Me.BtnUsave.BackgroundImage = CType(resources.GetObject("BtnUsave.BackgroundImage"), System.Drawing.Image)
        Me.BtnUsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnUsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUsave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUsave.Location = New System.Drawing.Point(11, 482)
        Me.BtnUsave.Name = "BtnUsave"
        Me.BtnUsave.Size = New System.Drawing.Size(100, 33)
        Me.BtnUsave.TabIndex = 8
        Me.BtnUsave.Text = "&Save"
        Me.BtnUsave.UseVisualStyleBackColor = False
        '
        'LblAc
        '
        Me.LblAc.AutoSize = True
        Me.LblAc.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAc.Location = New System.Drawing.Point(8, 350)
        Me.LblAc.Name = "LblAc"
        Me.LblAc.Size = New System.Drawing.Size(76, 14)
        Me.LblAc.TabIndex = 14
        Me.LblAc.Text = "User Name"
        Me.LblAc.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 295)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 14)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Assign A Role"
        '
        'lblAns
        '
        Me.lblAns.AutoSize = True
        Me.lblAns.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAns.Location = New System.Drawing.Point(8, 247)
        Me.lblAns.Name = "lblAns"
        Me.lblAns.Size = New System.Drawing.Size(54, 14)
        Me.lblAns.TabIndex = 14
        Me.lblAns.Text = "Answer"
        '
        'Btndel
        '
        Me.Btndel.BackColor = System.Drawing.Color.Transparent
        Me.Btndel.BackgroundImage = CType(resources.GetObject("Btndel.BackgroundImage"), System.Drawing.Image)
        Me.Btndel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btndel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btndel.Enabled = False
        Me.Btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btndel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btndel.Location = New System.Drawing.Point(152, 482)
        Me.Btndel.Name = "Btndel"
        Me.Btndel.Size = New System.Drawing.Size(100, 33)
        Me.Btndel.TabIndex = 9
        Me.Btndel.Text = "&Delete"
        Me.Btndel.UseVisualStyleBackColor = False
        '
        'Btnfind
        '
        Me.Btnfind.BackColor = System.Drawing.Color.Transparent
        Me.Btnfind.BackgroundImage = CType(resources.GetObject("Btnfind.BackgroundImage"), System.Drawing.Image)
        Me.Btnfind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnfind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnfind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnfind.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnfind.Location = New System.Drawing.Point(293, 482)
        Me.Btnfind.Name = "Btnfind"
        Me.Btnfind.Size = New System.Drawing.Size(100, 33)
        Me.Btnfind.TabIndex = 10
        Me.Btnfind.Text = "&Find"
        Me.Btnfind.UseVisualStyleBackColor = False
        '
        'BtnUclos
        '
        Me.BtnUclos.BackColor = System.Drawing.Color.Transparent
        Me.BtnUclos.BackgroundImage = CType(resources.GetObject("BtnUclos.BackgroundImage"), System.Drawing.Image)
        Me.BtnUclos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnUclos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUclos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUclos.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUclos.Location = New System.Drawing.Point(434, 482)
        Me.BtnUclos.Name = "BtnUclos"
        Me.BtnUclos.Size = New System.Drawing.Size(100, 33)
        Me.BtnUclos.TabIndex = 11
        Me.BtnUclos.Text = "&Close"
        Me.BtnUclos.UseVisualStyleBackColor = False
        '
        'cmbxHint
        '
        Me.cmbxHint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxHint.FormattingEnabled = True
        Me.cmbxHint.Location = New System.Drawing.Point(149, 199)
        Me.cmbxHint.Name = "cmbxHint"
        Me.cmbxHint.Size = New System.Drawing.Size(386, 22)
        Me.cmbxHint.TabIndex = 4
        '
        'cmbxId
        '
        Me.cmbxId.FormattingEnabled = True
        Me.cmbxId.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbxId.Location = New System.Drawing.Point(149, 8)
        Me.cmbxId.Name = "cmbxId"
        Me.cmbxId.Size = New System.Drawing.Size(287, 22)
        Me.cmbxId.TabIndex = 0
        '
        'lblHint
        '
        Me.lblHint.AutoSize = True
        Me.lblHint.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHint.Location = New System.Drawing.Point(7, 199)
        Me.lblHint.Name = "lblHint"
        Me.lblHint.Size = New System.Drawing.Size(135, 14)
        Me.lblHint.TabIndex = 12
        Me.lblHint.Text = "Select Hint Question"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.Location = New System.Drawing.Point(7, 8)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(122, 14)
        Me.lblId.TabIndex = 19
        Me.lblId.Text = "Employee's  Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(324, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(205, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Username must have atleast 6 characters"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(324, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(203, 15)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Password must have atleast 8 characters"
        Me.Label5.Visible = False
        '
        'lblConfrm
        '
        Me.lblConfrm.AutoSize = True
        Me.lblConfrm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblConfrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfrm.ForeColor = System.Drawing.Color.Blue
        Me.lblConfrm.Location = New System.Drawing.Point(10, 129)
        Me.lblConfrm.Name = "lblConfrm"
        Me.lblConfrm.Size = New System.Drawing.Size(2, 15)
        Me.lblConfrm.TabIndex = 16
        Me.lblConfrm.Visible = False
        '
        'Txtusrname
        '
        Me.Txtusrname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtusrname.Location = New System.Drawing.Point(149, 56)
        Me.Txtusrname.MaxLength = 75
        Me.Txtusrname.Name = "Txtusrname"
        Me.Txtusrname.Size = New System.Drawing.Size(170, 22)
        Me.Txtusrname.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPass
        '
        Me.TxtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPass.Location = New System.Drawing.Point(149, 103)
        Me.TxtPass.MaxLength = 32
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPass.Size = New System.Drawing.Size(169, 21)
        Me.TxtPass.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Password "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtans
        '
        Me.txtans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtans.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtans.Location = New System.Drawing.Point(150, 247)
        Me.txtans.MaxLength = 32
        Me.txtans.Name = "txtans"
        Me.txtans.Size = New System.Drawing.Size(386, 21)
        Me.txtans.TabIndex = 5
        '
        'Txtpass1
        '
        Me.Txtpass1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtpass1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtpass1.Location = New System.Drawing.Point(149, 151)
        Me.Txtpass1.MaxLength = 32
        Me.Txtpass1.Name = "Txtpass1"
        Me.Txtpass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtpass1.Size = New System.Drawing.Size(169, 21)
        Me.Txtpass1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 14)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Confirm Password  "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmCreateUsr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(568, 533)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "FrmCreateUsr"
        Me.Text = "Create User"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub BtnUclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUclos.Click
        Me.Close()
    End Sub

    Private Sub FrmCreateUsr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            Me.Left = 0
            Clr_Value()
            fetch_id_frm_empmstr()
            cmbxId.Focus()
            fetch_hint_ques()
            Fill_Combobox("Nrrid", "Narration", "finact_Narration", "ROLDELSTATUS", CInt(1), Me.CmbxUsrRole)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub fetch_id_frm_empmstr()
        Try

            Dim UsrStr As String = ("select empid,empname from finactempmstr where empid not in (select empid from finactusr)")
            UsrCmd = New SqlCommand(UsrStr, FinActConn1)

            UsrSqlAdptr = New SqlDataAdapter(UsrCmd)
            UsrDSet = New DataSet(UsrCmd.CommandText)
            UsrSqlAdptr.Fill(UsrDSet)
            Me.cmbxId.DataSource = UsrDSet.Tables(0)
            Me.cmbxId.ValueMember = "empid"
            Me.cmbxId.DisplayMember = "empname"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd.Dispose()
            UsrSqlAdptr.Dispose()
        End Try
    End Sub
    Private Sub Chek_Empty()
        Try
            With Me.CmbxUsrRole
                If .SelectedIndex = -1 Then
                    .BackColor = Color.PapayaWhip
                    UsrIndx += 1
                    .Focus()
                Else
                    UsrIndx = 0
                    .BackColor = Color.White
                End If
            End With
            With Txtusrname
                If .Text = "" Or Trim(Len(.Text)) < 6 Then
                    .BackColor = Color.PapayaWhip
                    UsrIndx += 1
                    .Focus()
                Else
                    UsrIndx = 0
                    .BackColor = Color.White
                End If
            End With
            With TxtPass
                If .Text = "" Or Trim(Len(.Text)) < 8 Then
                    .BackColor = Color.PapayaWhip
                    UsrIndx += 1
                    '.Focus()
                Else
                    UsrIndx = 0
                    .BackColor = Color.White
                End If
            End With
            With Txtpass1
                If .Text = "" Or .Text <> TxtPass.Text Then
                    .BackColor = Color.PapayaWhip
                    UsrIndx += 1
                    '.Focus()
                    lblConfrm.Text = "Please verify your Passsword again"
                    lblConfrm.Location = New System.Drawing.Point(8, 136)
                Else
                    UsrIndx = 0
                    .BackColor = Color.White
                End If
                If .Text = "" Or .Text = TxtPass.Text Then
                    lblConfrm.Visible = False
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Check Blank Value")
        Finally
            If UsrIndx <> 0 Then
                MsgBox("field left empty", MsgBoxStyle.Information, "Empty Field")
            End If
        End Try
    End Sub

    Private Sub Clr_Value()
        Try
            Txtusrname.Text = ""
            TxtPass.Text = ""
            Txtpass1.Text = ""
            txtans.Text = ""
            Me.CmbxUsrRole.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Clear Value Section")
        End Try
    End Sub

    Private Sub BtnUsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUsave.Click
        Try
            Chek_Empty()
            If UsrIndx <> 0 Then
                UsrIndx = 0
                Exit Sub
            Else
                If BtnUsave.Text = "&Save" Then
                    SveRec()
                    Label4.Visible = False
                    Label5.Visible = False
                ElseIf BtnUsave.Text = "&Update" Then
                    findflag = False
                    BtnUsave.Text = "&Save"
                    Btnfind.Text = "&Find"
                    UpdateRec()
                    Label4.Visible = False
                    Label5.Visible = False
                    lblAc.Visible = False
                    CmbxAc.Visible = False

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fetch_hint_ques()
        Try

            Dim UsrStr As String = ("select hintid,hintques from finacthintques")
            UsrCmd = New SqlCommand(UsrStr, FinActConn1)

            UsrSqlAdptr = New SqlDataAdapter(UsrCmd)
            UsrDSet = New DataSet(UsrCmd.CommandText)
            UsrSqlAdptr.Fill(UsrDSet)
            Me.cmbxHint.DataSource = UsrDSet.Tables(0)
            Me.cmbxHint.ValueMember = "hintid"
            Me.cmbxHint.DisplayMember = "hintques"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd.Dispose()
            UsrSqlAdptr.Dispose()
        End Try



    End Sub
    Private Sub SveRec()
        '===Following codes are useful to abstract an integer from a string. Don't delete it.
        '=***********************************************************************************
        'Dim str1 As String = ""
        'Dim str2 As String = ""
        'Dim i As Integer = 0
        'str1 = cmbxId.Text
        'While i <= str1.Length - 1
        '    If str1.Chars(i) <> "(" Then
        '        str2 += str1.Chars(i)
        '    Else
        '        str2 = str2
        '        Exit While
        '    End If
        '    i += 1
        'End While
        'Usrid1 = CInt(str2)
        '=***********************************************************************************

        Try
            Dim EncrpPass As New EnCryp_DeCryp_String
            UsrCmd = New SqlCommand("finact_usr_Insert", FinActConn)
            UsrCmd.CommandType = CommandType.StoredProcedure
            UsrCmd.Parameters.AddWithValue("@Uname", EncrpPass.Encrypt(Txtusrname.Text))
            UsrCmd.Parameters.AddWithValue("@upass", EncrpPass.Encrypt(TxtPass.Text))
            UsrCmd.Parameters.AddWithValue("@UType", EncrpPass.Encrypt(Me.CmbxUsrRole.SelectedValue))
            UsrCmd.Parameters.AddWithValue("@Uhint", Me.cmbxHint.SelectedValue)
            UsrCmd.Parameters.AddWithValue("@Uans", txtans.Text)
            UsrCmd.Parameters.AddWithValue("@rempass", 0)
            UsrCmd.Parameters.AddWithValue("@Uempid", Me.cmbxId.SelectedValue)
            UsrCmd.Parameters.AddWithValue("@UsrRoleId", CInt(Me.CmbxUsrRole.SelectedValue))
            UsrCmd.ExecuteNonQuery()
            MsgBox("Current record has been successfully saved", MsgBoxStyle.Information, "Group Name")
            Clr_Value()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Save Section")
            Txtusrname.Focus()
        Finally
            UsrCmd.Dispose()
        End Try
    End Sub

    Private Sub Btnfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnfind.Click
        Try
            If Btnfind.Text = "&Find" Then
                Btndel.Enabled = True
                BtnUsave.Text = "&Update"
                findflag = True
                fetch_id_frm_empmstr_all()
                cmbxId.Enabled = False
                Btnfind.Text = "&Cancel"
                LblAc.Visible = True
                CmbxAc.Visible = True
                Findrec()
                If CmbxAc.Focused = False Then
                    CmbxAc.Focus()
                End If
                Label4.Visible = False
                Label5.Visible = False
            ElseIf Btnfind.Text = "&Cancel" Then
                BtnUsave.Text = "&Save"
                Btnfind.Text = "&Find"
                Clr_Value()
                fetch_id_frm_empmstr()
                cmbxId.Enabled = True
                findflag = False
                cmbxId.Focus()
                Label4.Visible = False
                Label5.Visible = False
                LblAc.Visible = False
                CmbxAc.Visible = False

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Fetch_Rec()

        Dim Encryp As New EnCryp_DeCryp_String

        Try
            UsrCmd = New SqlCommand("Finact_Userid_SelectAll", FinActConn)
            UsrCmd.CommandType = CommandType.StoredProcedure
            UsrCmd.Parameters.AddWithValue("@usrid", Me.CmbxAc.SelectedValue)
            UsrRdr = UsrCmd.ExecuteReader
            UsrRdr.Read()
            If UsrRdr.HasRows = True Then
                Usrid1 = UsrRdr("empid")
                Txtusrname.Text = Encryp.Decrypt(UsrRdr("Usrname"))
                TxtPass.Text = Encryp.Decrypt(UsrRdr("usrpass"))
                Txtpass1.Text = Encryp.Decrypt(UsrRdr("usrpass"))
                UsrAcess = Encryp.Decrypt(UsrRdr("usracestype"))
                Me.CmbxUsrRole.SelectedValue = CInt(UsrAcess)
                Hintid = UsrRdr("usrhint")
                txtans.Text = UsrRdr("usrans")
                Me.CmbxUsrRole.SelectedValue = CInt(UsrRdr("UsrRoleid"))
              
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrRdr.Close()
            UsrCmd.Dispose()
            If Usrid1 > 0 Then
                Me.cmbxId.SelectedValue = Usrid1
                Me.cmbxHint.SelectedValue = Hintid
                Me.cmbxId.Enabled = False
            End If
        End Try
    End Sub

    Private Sub Txtusrname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtusrname.GotFocus
        Txtusrname.SelectAll()
    End Sub
    Private Sub TxtPass_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPass.GotFocus
        TxtPass.SelectAll()
    End Sub

    Private Sub Txtpass1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtpass1.GotFocus
        Txtpass1.SelectAll()
    End Sub
    Private Sub UpdateRec()
        Try
            Dim EncrpPass As New EnCryp_DeCryp_String
            UsrCmd = New SqlCommand("finact_usr_update", FinActConn)
            UsrCmd.CommandType = CommandType.StoredProcedure
            UsrCmd.Parameters.AddWithValue("@uid", Usrid1)      'usrid1 is empid

            Dim Usrprm As SqlParameter = New SqlParameter("@Uname", SqlDbType.VarBinary, (300))
            Usrprm.Direction = ParameterDirection.Input
            Usrprm.Value = EncrpPass.Encrypt(Txtusrname.Text)

            Dim Usrprm1 As SqlParameter = New SqlParameter("@Upass", SqlDbType.VarBinary, (200))
            Usrprm1.Direction = ParameterDirection.Input

            Usrprm1.Value = EncrpPass.Encrypt(TxtPass.Text)

            Dim Usrprm2 As SqlParameter = New SqlParameter("@UType", SqlDbType.VarBinary, (50))
            Usrprm2.Direction = ParameterDirection.Input
            Usrprm2.Value = EncrpPass.Encrypt(Me.CmbxUsrRole.SelectedValue)

            ' Dim Usrprm3 As SqlParameter = New SqlParameter("@UHint", SqlDbType.VarChar)
            ' Usrprm3.Value = cmbxHint.Text
            UsrCmd.Parameters.Add(Usrprm)
            UsrCmd.Parameters.Add(Usrprm1)
            UsrCmd.Parameters.Add(Usrprm2)
            UsrCmd.Parameters.AddWithValue("@uhint", Hintid)
            UsrCmd.Parameters.AddWithValue("@uempid", Usrid1)
            UsrCmd.Parameters.AddWithValue("@uans", txtans.Text)
            UsrCmd.Parameters.AddWithValue("@UsrRoleId", CInt(Me.CmbxUsrRole.SelectedValue))
            UsrCmd.ExecuteNonQuery()
            MsgBox("Current record has been successfully updated", MsgBoxStyle.Information, "Group Name")
            Clr_Value()
            UsrCmd = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Save Section")
            Exit Try
            Exit Sub
        Finally
            UsrRdr.Close()
            UsrCmd = Nothing
        End Try
    End Sub

    Private Sub Btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndel.Click
        Dim DelConfrm As String
        Try
            If UsrDel = True Then
                DelConfrm = MsgBox("Are You Sure to Delete This Record?", MsgBoxStyle.YesNo, "Delete a record")
                If DelConfrm = vbYes Then
                    UsrCmd = New SqlCommand("Finact_Usr_Delete", FinActConn)
                    UsrCmd.CommandType = CommandType.StoredProcedure
                    'UsrCmd = New SqlCommand("delete from finactusr where usrid=@uid", FinActConn)
                    UsrCmd.Parameters.AddWithValue("@uid", Usrid1)
                    UsrCmd.ExecuteNonQuery()
                    MsgBox("Record has been Successfully removed", MsgBoxStyle.Information, "Record Deleted")
                    Clr_Value()
                    Findrec()
                    Btndel.Enabled = False
                Else
                    UsrDel = False
                    Btndel.Enabled = False
                    cmbxId.Enabled = True
                    cmbxId.Focus()
                    Exit Sub
                    Exit Try
                End If
                UsrDel = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Findrec()
        Dim DcrpValue As New EnCryp_DeCryp_String
        'CmbxAc.Items.Clear()
        Try
            UsrCmd = New SqlCommand("finact_usr_Select", FinActConn)
            UsrCmd.CommandType = CommandType.StoredProcedure
            UsrRdr = UsrCmd.ExecuteReader
            While UsrRdr.Read()
                If UsrRdr.IsDBNull(0) = False Then
                    Try

                        UsrCmd1 = New SqlCommand("insert into temp_useridname(usrid,usrname)values(@Uid,@Uname)", FinActConn1)
                        UsrCmd1.Parameters.AddWithValue("@Uid", UsrRdr("usrid"))
                        UsrCmd1.Parameters.AddWithValue("@Uname", DcrpValue.Decrypt(UsrRdr("usrname")))
                        UsrCmd1.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        UsrCmd1.Dispose()

                    End Try


                End If

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd.Dispose()
            UsrRdr.Close()
            Try
                Dim UsrStr2 As String = ("Select usrid,usrname from temp_useridname order by usrname")
                UsrCmd = New SqlCommand(UsrStr2, FinActConn)
                UsrSqlAdptr = New SqlDataAdapter(UsrCmd)
                UsrDSet = New DataSet(UsrCmd.CommandText)
                UsrSqlAdptr.Fill(UsrDSet)
                Me.CmbxAc.DataSource = UsrDSet.Tables(0)
                Me.CmbxAc.ValueMember = "usrid"
                Me.CmbxAc.DisplayMember = "usrname"
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                UsrCmd.Dispose()
                UsrSqlAdptr.Dispose()
                UsrCmd = New SqlCommand("delete from temp_useridname", FinActConn)
                UsrCmd.ExecuteNonQuery()
                UsrCmd.Dispose()
            End Try

            CmbxAc.Focus()
        End Try

    End Sub

    Private Sub Txtusrname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtusrname.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            With Txtusrname
                If .Text = "" Then
                    UsrIndx += 1
                    MsgBox("Field left empty", MsgBoxStyle.Information, "Empty field")
                    Txtusrname.BackColor = Color.PapayaWhip
                Else
                    UsrIndx = 0
                    Txtusrname.BackColor = Color.White
                End If
                If .Text <> "" And Trim(Len(.Text)) < 6 Then
                    MsgBox("Invalid Input", MsgBoxStyle.Information, "Invalid")
                    Txtusrname.BackColor = Color.PapayaWhip
                    Txtusrname.Focus()
                End If
            End With
            If UsrIndx = 0 And Trim(Len(Txtusrname.Text)) >= 6 Then
                Label4.Visible = False
                Txtusrname.BackColor = Color.White
                Txtusrname_Leave(sender, e)
            End If
        End If
    End Sub

    Private Sub Txtusrname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtusrname.Leave
        Label4.Visible = False
        If findflag <> True Then
            If UCase$(Trim(Txtusrname.Text)) = "ADMINISTRATOR" Then
                Txtusrname.Clear()
                Txtusrname.Focus()
            ElseIf UCase$(Trim(Txtusrname.Text)) <> "ADMINISTRATOR" And UCase$(Trim(Txtusrname.Text)) <> "" Then
                TxtPass.Focus()
            End If
        End If
        If findflag = True Then
            TxtPass.Focus()
        End If
    End Sub

    Private Sub cmbxId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxId.GotFocus
        Me.cmbxId.DroppedDown = True
        If cmbxId.Items.Count > 0 Then
            If cmbxId.SelectedIndex = -1 Then
                Label6.Visible = False
                cmbxId.SelectedIndex = 0
                cmbxId.BackColor = Color.White
            End If
        Else
            fetch_id_frm_empmstr()
        End If

    End Sub

    Private Sub TxtPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPass.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            With TxtPass
                If .Text = "" Then
                    UsrIndx += 1
                    MsgBox("Field left empty", MsgBoxStyle.Information, "Empty field")
                    TxtPass.BackColor = Color.PapayaWhip
                Else
                    UsrIndx = 0
                    TxtPass.BackColor = Color.White
                End If
                If .Text <> "" And Trim(Len(.Text)) < 8 Then
                    MsgBox("Invalid Input", MsgBoxStyle.Information, "Invalid")
                    TxtPass.BackColor = Color.PapayaWhip
                    TxtPass.Focus()
                End If
            End With
            If UsrIndx = 0 And Trim(Len(TxtPass.Text)) >= 8 And findflag = False Then
                Label5.Visible = False
                TxtPass.BackColor = Color.White
                TxtPass_Leave(sender, e)
            End If
            If findflag = True Then
                Txtpass1.Focus()
            End If
        End If
    End Sub

    Private Sub TxtPass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPass.Leave
        Label5.Visible = False
        If findflag = False Then
            Txtpass1.Focus()
        End If
    End Sub
    Private Sub Txtpass1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtpass1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                With Txtpass1
                    If .Text = "" Then
                        UsrIndx += 1
                        MsgBox("Field left empty", MsgBoxStyle.Information, "Empty field")
                        Txtpass1.BackColor = Color.PapayaWhip
                    Else
                        UsrIndx = 0
                        Txtpass1.BackColor = Color.White
                    End If
                    If .Text = "" Or .Text <> TxtPass.Text Then
                        .BackColor = Color.PapayaWhip
                        UsrIndx += 1
                        lblConfrm.Text = "Please verify your Passsword again"
                        lblConfrm.Location = New System.Drawing.Point(333, 116)
                        lblConfrm.Visible = True
                        TxtPass.Focus()
                    End If
                End With
                If UsrIndx = 0 And Trim(Len(TxtPass.Text)) >= 8 And Txtpass1.Text = TxtPass.Text And findflag = False Then
                    lblConfrm.Visible = False
                    TxtPass.BackColor = Color.White
                    Txtpass1_Leave(sender, e)
                End If
                If findflag = True Then
                    cmbxHint.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtpass1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtpass1.Leave
        Try
            If findflag <> True Then
                cmbxHint.Focus()
            End If
            If TxtPass.Text <> Txtpass1.Text Then
                Txtpass1.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxHint_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxHint.GotFocus
        Try
            Me.cmbxHint.DroppedDown = True
            If cmbxHint.Items.Count > 0 Then
                If Me.cmbxHint.SelectedIndex = -1 Then
                    cmbxHint.SelectedIndex = 0
                End If
                Me.cmbxHint.SelectAll()
            Else
                fetch_hint_ques()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtans.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If txtans.Text = "" Then
                MsgBox("Field left empty", MsgBoxStyle.Information, "Empty Field")
                txtans.BackColor = Color.PapayaWhip
                txtans.Focus()
            End If
            If txtans.Text <> "" Then
                txtans.BackColor = Color.White
            End If
          
        End If
    End Sub

    Private Sub TxtPass_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPass.TextChanged
        Label5.Visible = True
    End Sub

    Private Sub Txtusrname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtusrname.TextChanged
        Dim usrname As String = ""
        If Txtusrname.Text.Length = 1 Then
            usrname = Txtusrname.Text
            If Asc(usrname) >= 48 And Asc(usrname) <= 57 Then
                MsgBox("First character must be an alphabet", MsgBoxStyle.Information, "Validation")
                Txtusrname.SelectAll()
            End If
        End If
        Label4.Visible = True
    End Sub
    Private Sub BtnUsave_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUsave.MouseHover
        BtnUsave.BackColor = Color.LightBlue

    End Sub

    Private Sub BtnUsave_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUsave.MouseLeave
        BtnUsave.BackColor = Color.LightCyan
    End Sub

    Private Sub fetch_id_frm_empmstr_all()
        Try

            Dim UsrStr As String = ("select empid,empname from finactempmstr where empdelstatus=1 order by empname")
            UsrCmd = New SqlCommand(UsrStr, FinActConn1)

            UsrSqlAdptr = New SqlDataAdapter(UsrCmd)
            UsrDSet = New DataSet(UsrCmd.CommandText)
            UsrSqlAdptr.Fill(UsrDSet)
            Me.cmbxId.DataSource = UsrDSet.Tables(0)
            Me.cmbxId.ValueMember = "empid"
            Me.cmbxId.DisplayMember = "empname"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd.Dispose()
            UsrSqlAdptr.Dispose()
        End Try
    End Sub

    Private Sub CmbxUsrRole_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxUsrRole.Leave
        Try

            If CheckBlank_Cmbx(Me.CmbxUsrRole) = False Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxAc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxAc.GotFocus
        Try
            If Me.CmbxAc.Items.Count > 0 Then
                Uflag = True
            Else
                Uflag = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxAc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxAc.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CmbxAc_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxAc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxAc.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxAc) = True Then
                Label4.Visible = False
                Label5.Visible = False
                Txtusrname.Focus()
                BtnUsave.Text = "&Update"
                UsrDel = True
                Me.LblAc.Visible = False
                Me.CmbxAc.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmbxId_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbxId.Leave
        Try
            If CheckBlank_Cmbx(Me.cmbxId) = False Then
            End If
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub CmbxAc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxAc.SelectedIndexChanged
        Try
            If Not Me.CmbxAc.SelectedIndex = -1 Then
                If Uflag = True Then
                    Fetch_Rec()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class

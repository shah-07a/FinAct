Imports System.Data.SqlClient
Public Class FrmLogin
    Inherits System.Windows.Forms.Form
    Dim CmdLogin As SqlCommand
    Dim RdrLogin As SqlDataReader
    Dim UsrCmd As SqlCommand
    Dim UsrCmd1 As SqlCommand
    Dim UsrRdr As SqlDataReader
    Dim Usrid, Pass1 As String
    Dim hintans As String = ""
    Dim status As Boolean
    Dim indx As Integer = 0
    Dim notexist As Boolean
    Dim usrnm As String = ""
    Dim chkpass As Boolean = False
    Dim ChkIndx As Integer
    Dim Defusrid As Integer = 0
    Dim passusr As String = ""
    Dim Rem_Copass As String = ""
    Dim chk_corempas As Boolean = False
    Friend WithEvents txthint As System.Windows.Forms.TextBox
    Friend WithEvents txtans As System.Windows.Forms.TextBox
    Friend WithEvents lblhint As System.Windows.Forms.Label
    Friend WithEvents lblans As System.Windows.Forms.Label
    Friend WithEvents lblinfo As System.Windows.Forms.Label
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Dim ChkRec As Boolean = True
    Dim chk_default As Boolean = False
    Dim Tsmi(100) As String

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
    Friend WithEvents Txtuid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txtpass As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnLogin As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.txtid = New System.Windows.Forms.TextBox
        Me.lblid = New System.Windows.Forms.Label
        Me.lblinfo = New System.Windows.Forms.Label
        Me.txthint = New System.Windows.Forms.TextBox
        Me.txtans = New System.Windows.Forms.TextBox
        Me.lblans = New System.Windows.Forms.Label
        Me.lblhint = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.BtnLogin = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txtuid = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txtpass = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.FinAcct.My.Resources.Resources.smallf_Bgrm
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Controls.Add(Me.txtid)
        Me.Panel1.Controls.Add(Me.lblid)
        Me.Panel1.Controls.Add(Me.lblinfo)
        Me.Panel1.Controls.Add(Me.txthint)
        Me.Panel1.Controls.Add(Me.txtans)
        Me.Panel1.Controls.Add(Me.lblans)
        Me.Panel1.Controls.Add(Me.lblhint)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.BtnLogin)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Txtuid)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Txtpass)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(309, 317)
        Me.Panel1.TabIndex = 0
        '
        'CheckBox2
        '
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(9, 106)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(100, 19)
        Me.CheckBox2.TabIndex = 17
        Me.CheckBox2.Text = "Default User"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'txtid
        '
        Me.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtid.Location = New System.Drawing.Point(90, 200)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(178, 20)
        Me.txtid.TabIndex = 7
        Me.txtid.Visible = False
        '
        'lblid
        '
        Me.lblid.BackColor = System.Drawing.Color.Transparent
        Me.lblid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblid.Location = New System.Drawing.Point(7, 200)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(78, 20)
        Me.lblid.TabIndex = 16
        Me.lblid.Text = "EmployeeId"
        Me.lblid.Visible = False
        '
        'lblinfo
        '
        Me.lblinfo.BackColor = System.Drawing.Color.Transparent
        Me.lblinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblinfo.Location = New System.Drawing.Point(9, 135)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(175, 41)
        Me.lblinfo.TabIndex = 13
        Me.lblinfo.Text = "Label4"
        Me.lblinfo.Visible = False
        '
        'txthint
        '
        Me.txthint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txthint.Enabled = False
        Me.txthint.Location = New System.Drawing.Point(90, 225)
        Me.txthint.Name = "txthint"
        Me.txthint.Size = New System.Drawing.Size(207, 20)
        Me.txthint.TabIndex = 8
        Me.txthint.Visible = False
        '
        'txtans
        '
        Me.txtans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtans.Location = New System.Drawing.Point(90, 247)
        Me.txtans.Name = "txtans"
        Me.txtans.Size = New System.Drawing.Size(207, 20)
        Me.txtans.TabIndex = 9
        Me.txtans.Visible = False
        '
        'lblans
        '
        Me.lblans.BackColor = System.Drawing.Color.Transparent
        Me.lblans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblans.Location = New System.Drawing.Point(6, 245)
        Me.lblans.Name = "lblans"
        Me.lblans.Size = New System.Drawing.Size(75, 20)
        Me.lblans.TabIndex = 11
        Me.lblans.Text = "Answer"
        Me.lblans.Visible = False
        '
        'lblhint
        '
        Me.lblhint.BackColor = System.Drawing.Color.Transparent
        Me.lblhint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhint.Location = New System.Drawing.Point(6, 225)
        Me.lblhint.Name = "lblhint"
        Me.lblhint.Size = New System.Drawing.Size(76, 20)
        Me.lblhint.TabIndex = 11
        Me.lblhint.Text = "Question"
        Me.lblhint.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.ForeColor = System.Drawing.Color.Blue
        Me.LinkLabel1.Location = New System.Drawing.Point(56, 281)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(186, 16)
        Me.LinkLabel1.TabIndex = 10
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Forget your Id or Password"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(9, 178)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(184, 19)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "  Remember my Password"
        Me.CheckBox1.UseVisualStyleBackColor = False
        Me.CheckBox1.Visible = False
        '
        'BtnLogin
        '
        Me.BtnLogin.BackColor = System.Drawing.Color.Transparent
        Me.BtnLogin.BackgroundImage = Global.FinAcct.My.Resources.Resources.bg
        Me.BtnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLogin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLogin.Location = New System.Drawing.Point(217, 106)
        Me.BtnLogin.Name = "BtnLogin"
        Me.BtnLogin.Size = New System.Drawing.Size(80, 24)
        Me.BtnLogin.TabIndex = 6
        Me.BtnLogin.Text = "Sign In"
        Me.BtnLogin.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(11, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Sign In"
        '
        'Txtuid
        '
        Me.Txtuid.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Txtuid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtuid.Location = New System.Drawing.Point(136, 44)
        Me.Txtuid.MaxLength = 100
        Me.Txtuid.Name = "Txtuid"
        Me.Txtuid.Size = New System.Drawing.Size(161, 20)
        Me.Txtuid.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "User Name:->"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtpass
        '
        Me.Txtpass.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Txtpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtpass.Location = New System.Drawing.Point(136, 68)
        Me.Txtpass.MaxLength = 50
        Me.Txtpass.Name = "Txtpass"
        Me.Txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtpass.Size = New System.Drawing.Size(161, 20)
        Me.Txtpass.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password :->"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGreen
        Me.ClientSize = New System.Drawing.Size(309, 317)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        lblid.Visible = True
        txtid.Visible = True
        txtid.Focus()
        CheckBox1.Visible = True
        Txtpass.Text = ""
        frgt_pass()
    End Sub
    Private Sub rem_pass()
        Dim encrp As New EnCryp_DeCryp_String
        If Txtuid.Text <> "Administrator" Or txtid.Text <> "Administrator" Then

            Try
                UsrCmd = New SqlCommand("select rempass,usrpass from finactusr where usrname=@usr1", FinActConn)
                If Txtuid.Text <> "" Then
                    UsrCmd.Parameters.AddWithValue("@usr1", encrp.Encrypt(Txtuid.Text))
                ElseIf Txtuid.Text = "" Then
                    UsrCmd.Parameters.AddWithValue("@usr1", encrp.Encrypt(Usrid))
                End If
                UsrRdr = UsrCmd.ExecuteReader
                UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    status = UsrRdr(0)
                    Pass1 = encrp.Decrypt(UsrRdr(1))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                UsrCmd = Nothing
                UsrRdr.Close()
            End Try
        ElseIf Txtuid.Text = "Administrator" Or txtid.Text = "Administrator" Then
            Try
                UsrCmd = New SqlCommand("select Cohintques,cohintans,coadmnpass,corempass from finactCogatemstr,finactHintQues where finactcogatemstr.cohintques=finactHintQues.hintid ", FinActConn)
                UsrRdr = UsrCmd.ExecuteReader
                UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    Pass1 = encrp.Decrypt(UsrRdr(2)).ToString
                    status = UsrRdr(3)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                UsrCmd = Nothing
                UsrRdr.Close()
            End Try
         
        End If


    End Sub
    
    Private Sub frgt_pass()
        Dim encrypt As New EnCryp_DeCryp_String
        If Txtuid.Text <> "" And Txtuid.Text <> "Administrator" Then
            Try
                UsrCmd = New SqlCommand("select usrhint,usrans,hintques,usrpass from finactusr,finactHintQues where finactusr.usrname=@usr1 and finactusr.usrhint=finactHintQues.hintid", FinActConn)
                UsrCmd.Parameters.AddWithValue("@usr1", encrypt.Encrypt(Txtuid.Text))
                UsrRdr = UsrCmd.ExecuteReader
                UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    txthint.Text = UsrRdr(2)
                    Pass1 = encrypt.Decrypt(UsrRdr(3)).ToString
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                UsrCmd = Nothing
                UsrRdr.Close()
            End Try
            txthint.Visible = False
            txtans.Visible = False
            lblhint.Visible = False
            lblans.Visible = False
        ElseIf Txtuid.Text <> "" And Txtuid.Text = "Administrator" Then
            Try
                UsrCmd = New SqlCommand("select Cohintques,cohintans,coadmnpass from finactCogatemstr,finactHintQues where finactcogatemstr.cohintques=finactHintQues.hintid ", FinActConn)
                UsrRdr = UsrCmd.ExecuteReader
                UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    txthint.Text = UsrRdr(0)
                    Pass1 = encrypt.Decrypt(UsrRdr(2)).ToString
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                UsrCmd = Nothing
                UsrRdr.Close()
            End Try
            txthint.Visible = False
            txtans.Visible = False
            lblhint.Visible = False
            lblans.Visible = False
        End If

    End Sub

    Private Sub FrmLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Txtuid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtuid.GotFocus
        If Txtuid.Text = "Administrator" Then
            ChekIdPassword()
        End If
    End Sub

    Private Sub Txtuid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtuid.KeyDown
        Dim decrp As New EnCryp_DeCryp_String
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            With Txtuid
                If .Text = "" Then
                    indx += 1
                    Txtuid.BackColor = Color.LemonChiffon
                    MsgBox("Invalid input", MsgBoxStyle.Critical, "Error handler")
                    Txtuid.Focus()
                End If
                If .Text <> "" Then
                    indx = 0
                    Txtuid.BackColor = Color.White
                    Txtpass.Focus()
                End If
            End With
        End If

    End Sub
    Private Sub Chk_val()
        With Txtuid
            If Trim(.Text) = "" Then
                .BackColor = Color.Cyan
                .Focus()
                ChkIndx += 1
            Else
                .BackColor = Color.White
            End If
        End With
        With Txtpass
            If Trim(.Text) = "" Then
                .BackColor = Color.Cyan
                .Focus()
                ChkIndx += 1
            Else
                .BackColor = Color.White
            End If
        End With
    End Sub
    Private Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click
        Chk_val()
        If ChkIndx <> 0 Then
            ChkIndx = 0
            Exit Sub
        Else
            Try
                Dim mdi As New FrmMainMdi
                If Trim(Txtuid.Text) <> "" Or Trim(Txtpass.Text) <> "" Then
                    If Txtuid.Text <> "Administrator" Then
                        ChekIdPassword()
                    End If
                    If Usrid <> Trim(Txtuid.Text) Or Pass1 <> Trim(Txtpass.Text) Then
                        If ChkRec = True Then
                            MsgBox("Invalid User name or Password", MsgBoxStyle.Critical, "Login")
                            Txtuid.Focus()
                            Txtuid.SelectAll()
                        Else
                            Exit Sub
                        End If
                    Else
                        If Txtuid.Text <> "Administrator" Then 'Administrator
                            chk_pass()
                        End If
                        MsgBox("You have successfully logged in", MsgBoxStyle.Information, "Login")

                        If AcessRight = "FullOnwer" Then
                            For Each Tsmi As ToolStripMenuItem In FrmMainMdi.Ms1.Items
                                Tsmi.Visible = True
                                Tsmi.Enabled = True
                            Next
                            FrmMainMdi.CREATENEWUSERToolStripMenuItem.Visible = True
                            FrmMainMdi.COMPANYPROFILESToolStripMenuItem.Visible = True
                            FrmMainMdi.BACKUPToolStripMenuItem.Visible = True
                            FrmMainMdi.RESTOREToolStripMenuItem.Visible = True
                            FrmMainMdi.CHANGEPASSToolStripMenuItem1.Visible = True
                            FrmMainMdi.ToolStripMenuItem4.Visible = True
                        Else
                            xFtch_xUsr_Prmisons(CInt(AcessRight))

                            Dim i As Integer = 0
                            Dim xTMi As String = ""
                            Dim ix As Integer = 0
                            For Each ToolItems As ToolStripMenuItem In FrmMainMdi.Ms1.Items
                                xTMi = ToolItems.Name.ToUpper
                                For ix = 0 To Tsmi.Length - 1
                                    If Not Tsmi(ix) = Nothing Then
                                        If Trim(xTMi).ToUpper = (Tsmi(ix).ToUpper) Then
                                            ToolItems.Enabled = True
                                            ToolItems.Visible = True
                                        End If
                                    End If
                                Next ix
                                For Each tl As ToolStripMenuItem In ToolItems.DropDownItems
                                    i += 1
                                    xTMi = tl.Name.ToUpper
                                    tl.Enabled = False
                                    tl.Visible = False
                                    For ix = 0 To Tsmi.Length - 1
                                        If Not Tsmi(ix) = Nothing Then

                                            If Trim(xTMi).ToUpper = (Tsmi(ix).ToUpper) Then
                                                tl.Enabled = True
                                                tl.Visible = True
                                            End If
                                        End If
                                    Next ix
                                Next tl
                                i += 1
                            Next ToolItems
                        End If
                        FrmMainMdi.LOGINToolStripMenuItem.Enabled = False
                        FrmMainMdi.LOGOUTToolStripMenuItem.Enabled = True
                        Me.Close()

                    End If

                Else
                    Txtuid.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                xCustMize()
                ' Current_UserName = "Romesh Kumar"   'to be configure with userid and designations
                'Current_UserDesi = "Partner"

            End Try
        End If

    End Sub
    Private Sub xFtch_xUsr_Prmisons(ByVal xUsrRolid As Integer)
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            UsrCmd = New SqlCommand("Finact_UserRolechild_Select", FinActConn)
            UsrCmd.CommandType = CommandType.StoredProcedure
            UsrCmd.Parameters.AddWithValue("@UsrRoleid", xUsrRolid)
            UsrRdr = UsrCmd.ExecuteReader
            Dim i As Integer = 0
            While UsrRdr.Read
                If UsrRdr.IsDBNull(0) = False Then
                    Tsmi(i) = Trim(UsrRdr("Rolctstext"))
                End If
                i += 1
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            UsrCmd.Dispose()
            UsrRdr.Close()

        End Try
    End Sub
    Private Sub Txtpass_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtpass.GotFocus
        Txtpass.SelectAll()
    End Sub

    Private Sub Txtpass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtpass.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            With Txtpass
                If .Text = "" Then
                    indx += 1
                    Txtpass.BackColor = Color.LemonChiffon
                    MsgBox("Field left empty", MsgBoxStyle.Information, "Empty Field")
                    Txtpass.Focus()
                End If
                If .Text <> "" Then
                    ChekIdPassword()
                    If Txtpass.Text <> Pass1 Then
                        MsgBox("Wrong Password.Try again", MsgBoxStyle.Critical, "Password")
                        Txtpass.Focus()
                    ElseIf Txtpass.Text = Pass1 Then
                        indx = 0
                        Txtpass.BackColor = Color.White
                        CheckBox1.Visible = True
                        BtnLogin_Click(sender, e)
                    End If
                End If
            End With
        End If
    End Sub
    Private Sub numericTextboxKeyPress1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar <> "." Then
            If (tb.SelectedText <> "." Or IsNumeric(tb.Text & e.KeyChar)) Then
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

    Private Sub ChekIdPassword()
        Dim EnDeCryp As New EnCryp_DeCryp_String
        Dim chk_def As Boolean = False
        chk_default = True
        chkpass = True
        Try
            CmdLogin = New SqlCommand("finact_UsrIdPassword", FinActConn)
            CmdLogin.CommandType = CommandType.StoredProcedure
            CmdLogin.Parameters.AddWithValue("@Chktxt", Trim(Txtuid.Text))
            CmdLogin.Parameters.AddWithValue("@Chktxt1", EnDeCryp.Encrypt(Trim(Txtuid.Text)))
            RdrLogin = CmdLogin.ExecuteReader
            RdrLogin.Read()
            If RdrLogin.HasRows = True Then
                notexist = False
                If Trim(Txtuid.Text) = "Administrator" Then
                    Usrid = Trim(RdrLogin("coadmn"))
                    Pass1 = EnDeCryp.Decrypt(RdrLogin("coadmnpass"))
                    AcessRight = "FullOnwer"
                    Current_UsrId = Trim(RdrLogin("coid"))
                    Current_UserName = "Administrator"
                    Current_UserDesi = "Owner"
                    chk_def = RdrLogin("codefusr")
                    chk_corempas = RdrLogin("Corempass")
                    If chk_def = True Then

                        CheckBox2.Visible = True
                        CheckBox2.Checked = True
                    ElseIf chk_def = False Then
                        CheckBox2.Checked = False

                    End If
                    If chk_corempas = True Then
                        CheckBox1.Visible = True
                        CheckBox1.Checked = True
                        Txtpass.Text = Pass1
                    ElseIf chk_corempas = False Then
                        CheckBox1.Checked = False
                        CheckBox1.Visible = True
                    End If
                Else
                    Usrid = EnDeCryp.Decrypt(RdrLogin("usrname"))
                    Pass1 = EnDeCryp.Decrypt(RdrLogin("usrpass"))
                    AcessRight = EnDeCryp.Decrypt(RdrLogin("usrAcestype"))
                    Current_UsrId = Trim(RdrLogin("usrid"))
                    Current_UserName = Usrid
                    Current_UserDesi = "Operator"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Login")
            ChkRec = False
        Finally
            If RdrLogin.HasRows = False And Txtuid.Text <> "Administrator" Then
                MsgBox("Username Doesn't exist.Try another name", MsgBoxStyle.Information, "Information")
                Txtuid.Text = ""
                Txtpass.Text = ""
                CheckBox1.Visible = False
                CheckBox2.Visible = False
                notexist = True
                Txtuid.Focus()
                Txtuid.SelectAll()
                LinkLabel1.Visible = True
            End If
            RdrLogin.Close()
            CmdLogin = Nothing
        End Try
        chk_default = False
        chkpass = False

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If chkpass <> True Then
            update_usrmstr()
        End If

    End Sub

    Private Sub update_usrmstr()
        Dim DcrpValue As New EnCryp_DeCryp_String
        Dim uid As Integer
        If Txtuid.Text <> "Administrator" Then
            Try
                UsrCmd = New SqlCommand("select usrid from finactusr where usrname=@usr1", FinActConn)
                UsrCmd.Parameters.AddWithValue("@usr1", DcrpValue.Encrypt(Txtuid.Text))
                UsrRdr = UsrCmd.ExecuteReader
                UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    uid = UsrRdr(0)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                UsrCmd = Nothing
                UsrRdr.Close()
            End Try
            Try
                UsrCmd = New SqlCommand("finact_usrrempass_update", FinActConn)
                UsrCmd.CommandType = CommandType.StoredProcedure
                UsrCmd.Parameters.AddWithValue("@uid", uid)
                If CheckBox1.Checked = True Then
                    UsrCmd.Parameters.AddWithValue("@rempass", 1)
                ElseIf CheckBox1.Checked = False Then
                    UsrCmd.Parameters.AddWithValue("@rempass", 0)
                End If

                UsrCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                UsrCmd = Nothing
                UsrRdr.Close()
            End Try
        ElseIf Txtuid.Text = "Administrator" Then
            Try
                If CheckBox1.Checked = True Then
                    UsrCmd = New SqlCommand("Update  finactCogatemstr set Corempass='" & (1) & "' where CoAdmn = '" & ("Administrator") & "' ", FinActConn)
                    UsrCmd.ExecuteNonQuery()
                ElseIf CheckBox1.Checked = False Then
                    UsrCmd = New SqlCommand("Update  finactCogatemstr set Corempass='" & (0) & "' where CoAdmn = '" & ("Administrator") & "' ", FinActConn)
                    UsrCmd.ExecuteNonQuery()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                UsrCmd = Nothing

            End Try

        End If
    End Sub
    Private Sub CheckBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckBox1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            BtnLogin.Focus()
        End If
    End Sub

    Private Sub BtnLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnLogin.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub FrmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fetch_defusr()
            Txtuid.Text = usrnm
            Txtpass.Text = passusr
            chk_default = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub fetch_defusr() 'default user
        Dim nord As Boolean = False
        Dim nord1 As Boolean = False
        Dim encrypt As New EnCryp_DeCryp_String
        Try
            UsrCmd = New SqlCommand("select usrid,usrname from finactusr where usrdefault='" & (1) & "'", FinActConn)
            UsrRdr = UsrCmd.ExecuteReader
            UsrRdr.Read()
            If UsrRdr.HasRows = True Then
                Defusrid = UsrRdr(0)
                usrnm = encrypt.Decrypt(UsrRdr(1)).ToString
                chk_default = True
                CheckBox2.Checked = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If UsrRdr.HasRows = False Then
                nord = True
            End If
            UsrRdr.Close()
            UsrCmd = Nothing
        End Try
        If nord <> True Then
            Try
                UsrCmd = New SqlCommand("finact_usr_Selectall", FinActConn)
                UsrCmd.CommandType = CommandType.StoredProcedure
                UsrCmd.Parameters.AddWithValue("@uname", encrypt.Encrypt(usrnm))
                UsrRdr = UsrCmd.ExecuteReader
                UsrRdr.Read()
                passusr = encrypt.Decrypt(UsrRdr("usrpass"))
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                UsrRdr.Close()
                UsrCmd = Nothing
            End Try
        ElseIf nord = True Then
           nord = False
            Try
                UsrCmd = New SqlCommand("select coid,coAdmn,coadmnpass from finactCogatemstr where codefusr='" & (1) & "'", FinActConn) ' where codefusr='" & (1) & "'", FinActConn)
                UsrRdr = UsrCmd.ExecuteReader
                UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    usrnm = Trim(UsrRdr("coadmn"))
                    passusr = encrypt.Decrypt(UsrRdr("coadmnpass"))
                     chk_default = True
                    CheckBox2.Visible = True
                    CheckBox2.Checked = True
            
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If UsrRdr.HasRows = False Then
                    nord1 = True
                End If
                UsrRdr.Close()
                UsrCmd = Nothing
            End Try
        ElseIf nord1 = True Then
            nord = False
            nord1=false
            usrnm = ""
            passusr = ""
            Exit Sub
        End If
    End Sub
    Private Sub chek_empty()
        Dim indx As Integer = 0
        With Txtuid
            If .Text = "" Then
                indx += 1
                Txtuid.BackColor = Color.LemonChiffon
                If indx = 1 Then
                    MsgBox("Field left empty", MsgBoxStyle.Information, "Empty Field")
                End If
                Txtuid.Focus()
            End If
            If .Text <> "" Then
                indx = 0
                Txtuid.BackColor = Color.White
            End If
        End With
        With Txtpass
            If .Text = "" Then
                indx += 1
                Txtpass.BackColor = Color.LemonChiffon
                If indx = 1 Then
                    MsgBox("Field left empty", MsgBoxStyle.Information, "Empty Field")
                End If
                Txtpass.Focus()
            End If
            If .Text <> "" Then
                indx = 0
                Txtpass.BackColor = Color.White
            End If
        End With

    End Sub

    Private Sub txtans_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtans.GotFocus
        txtans.Text = ""
    End Sub

    Private Sub txtans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtans.KeyDown
        Dim decrypt As New EnCryp_DeCryp_String
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If txtans.Text = hintans Then
                Txtuid.Text = Usrid
                rem_pass()
                Txtpass.Text = Pass1
                BtnLogin.Focus()
                lblhint.Visible = False
                lblans.Visible = False
                txthint.Visible = False
                txtans.Visible = False
                lblinfo.Text = " User Name:- " & Txtuid.Text & "                  " & "Password:-" & Pass1
                lblinfo.Visible = True
                lblinfo.ForeColor = Color.Blue
                If status = False Then
                    CheckBox1.Visible = True
                End If
                LinkLabel1.Visible = False
                txtid.Visible = False
                lblid.Visible = False
            Else
                MsgBox("Wrong answer.Try again", MsgBoxStyle.Critical, "Wrong Answer")
            End If
        End If
    End Sub

    Private Sub Txtuid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtuid.Leave
        'ChekIdPassword()
        If indx = 0 And ChkIndx = 0 And Txtuid.Text <> "" And Txtuid.Text <> "Administrator" Then
            ChekIdPassword()
            If notexist = False Then
                rem_pass()
                If indx = 0 Then
                    If status = True Then
                        Txtpass.Text = Pass1
                        chk_pass()
                        CheckBox1.Focus()
                        LinkLabel1.Visible = False
                    ElseIf status = False Then
                        Txtpass.Clear()
                        Txtpass.Focus()
                        chk_pass()
                        LinkLabel1.Visible = True
                    End If
                End If
            End If
        ElseIf Txtuid.Text = "Administrator" Then
            ChekIdPassword()

        End If

    End Sub

    Private Sub txtid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtid.KeyDown
        Dim decrypt As New EnCryp_DeCryp_String
        Dim chkusrnm As String = ""
        Dim Encryp As New EnCryp_DeCryp_String
        Dim usrid1 As Integer = 0
        Dim remval As Boolean = False
        Dim fet_def_usr As Boolean = False
        chkusrnm = Trim(txtid.Text)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
           
            chkpass = True
            chk_default = True
            Try
                UsrCmd = New SqlCommand("select usrname,usrpass,usrhint,usrans,hintques,rempass,usrdefault from finactHintQues,finactusr where finactHintQues.hintid=finactusr.usrhint and finactusr.empid='" & txtid.Text & "'", FinActConn)
                UsrRdr = UsrCmd.ExecuteReader
                UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    txthint.Visible = True
                    txtans.Visible = True
                    lblhint.Visible = True
                    lblans.Visible = True
                    txthint.Text = UsrRdr(4)
                    remval = UsrRdr(5)
                    fet_def_usr = UsrRdr(6)
                    If remval = True Then
                        CheckBox1.Checked = True
                    ElseIf remval = False Then
                        CheckBox1.Checked = False
                    End If
                    If fet_def_usr = True Then
                        CheckBox2.Visible = True
                        CheckBox2.Checked = True
                    ElseIf fet_def_usr = False Then
                        CheckBox2.Visible = True
                        CheckBox2.Checked = False
                    End If
                    hintans = UsrRdr(3)
                    Usrid = decrypt.Decrypt(UsrRdr(0))
                    txtans.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If UsrRdr.HasRows = False Then
                    MsgBox("Enter valid Employee Id", MsgBoxStyle.Information, "Invalid Employee Id")
                    txtid.SelectAll()
                End If
                UsrCmd = Nothing
                UsrRdr.Close()
            End Try
        ElseIf txtid.Text = "Administrator" Then
            chkpass = True
            chk_default = True
            Try
                UsrCmd = New SqlCommand("select hintques,Cohintques,cohintans,coadmnpass,coadmn from finactCogatemstr,finactHintQues where finactcogatemstr.cohintques=finactHintQues.hintid ", FinActConn)
                UsrRdr = UsrCmd.ExecuteReader
                UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    txthint.Visible = True
                    txtans.Visible = True
                    lblhint.Visible = True
                    lblans.Visible = True
                    txthint.Text = UsrRdr(0)
                    hintans = UsrRdr(2)
                    Usrid = UsrRdr(4)
                    txtans.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If UsrRdr.HasRows = False Then
                    MsgBox("Enter valid Employee Id", MsgBoxStyle.Information, "Employee Id")
                    txtid.SelectAll()
                End If
                UsrCmd = Nothing
                UsrRdr.Close()
            End Try
        End If
        chkpass = False
        chk_default = False
    End Sub

    Private Sub chk_pass()
        Dim decrypt As New EnCryp_DeCryp_String
        Dim chkusrnm As String = ""
        Dim Encryp As New EnCryp_DeCryp_String
        Dim usrid1 As Integer = 0
        Dim remval As Boolean = False
        Dim fet_def_usr As Boolean = False
        chkusrnm = Trim(Txtuid.Text)

        Try
            UsrCmd = New SqlCommand("finact_usr_Selectall", FinActConn)
            UsrCmd.CommandType = CommandType.StoredProcedure
            UsrCmd.Parameters.AddWithValue("@uname", Encryp.Encrypt(chkusrnm))
            UsrRdr = UsrCmd.ExecuteReader
            UsrRdr.Read()
            If UsrRdr.HasRows = True Then
                usrid1 = UsrRdr("Usrid")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrRdr.Close()
        End Try
        chkpass = True
        chk_default = True
        Try
            UsrCmd = New SqlCommand("select usrname,usrpass,usrhint,usrans,hintques,rempass,usrdefault from finactHintQues,finactusr where finactHintQues.hintid=finactusr.usrhint and finactusr.usrid='" & usrid1 & "'", FinActConn)
            UsrRdr = UsrCmd.ExecuteReader
            UsrRdr.Read()
            If UsrRdr.HasRows = True Then
                remval = UsrRdr(5)
                fet_def_usr = UsrRdr(6)
                If remval = True Then
                    CheckBox1.Visible = True
                    CheckBox1.Checked = True
                ElseIf remval = False Then
                    CheckBox1.Visible = True
                    CheckBox1.Checked = False
                End If
                If fet_def_usr = True Then
                    CheckBox2.Visible = True
                    CheckBox2.Checked = True
                ElseIf fet_def_usr = False Then
                    CheckBox2.Visible = True
                    CheckBox2.Checked = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If UsrRdr.HasRows = False Then
                MsgBox("Enter valid User Name", MsgBoxStyle.Information, "User Name")
            End If
            UsrCmd = Nothing
            UsrRdr.Close()

        End Try
        chkpass = False
        chk_default = False
    End Sub
    Private Sub Presesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txthint.KeyDown, txtid.KeyDown
        Dim delconfrm As String
        If e.KeyCode = Keys.Escape Then
            delconfrm = MsgBox("Are you sure to Exit without save", MsgBoxStyle.YesNo, "Exit")
            If delconfrm = vbYes Then
                Me.Close()
            End If
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If chk_default <> True Then
            If Txtuid.Text <> "Administrator" Then
                update_usrdefault()
            ElseIf Txtuid.Text = "Administrator" Then
                update_usrdefault_admin()
            End If

        End If
    End Sub
    Private Sub update_usrdefault()
        Dim DcrpValue As New EnCryp_DeCryp_String
        Dim uid As Integer
        Dim defuid As Integer = 0

        Try
            UsrCmd = New SqlCommand("select usrid from finactusr where usrdefault='" & (1) & "'", FinActConn)

            UsrRdr = UsrCmd.ExecuteReader
            While UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    defuid = UsrRdr(0)
                    Try
                        UsrCmd1 = New SqlCommand("finact_setdefaultusr_update", FinActConn1)
                        UsrCmd1.CommandType = CommandType.StoredProcedure
                        UsrCmd1.Parameters.AddWithValue("@uid", defuid)

                        UsrCmd1.Parameters.AddWithValue("@usrdefault", 0)


                        UsrCmd1.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        UsrCmd1 = Nothing

                    End Try
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd = Nothing
            UsrRdr.Close()
        End Try
        Try
            UsrCmd = New SqlCommand("select usrid from finactusr where usrname=@usr1", FinActConn)
            UsrCmd.Parameters.AddWithValue("@usr1", DcrpValue.Encrypt(Txtuid.Text))
            UsrRdr = UsrCmd.ExecuteReader
            UsrRdr.Read()
            If UsrRdr.HasRows = True Then
                uid = UsrRdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd = Nothing
            UsrRdr.Close()
        End Try
        Try
            UsrCmd = New SqlCommand("finact_setdefaultusr_update", FinActConn)
            UsrCmd.CommandType = CommandType.StoredProcedure
            UsrCmd.Parameters.AddWithValue("@uid", uid)
            If CheckBox2.Checked = True Then
                UsrCmd.Parameters.AddWithValue("@usrdefault", 1)
            ElseIf CheckBox2.Checked = False Then
                UsrCmd.Parameters.AddWithValue("@usrdefault", 0)
            End If

            UsrCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd = Nothing
            UsrRdr.Close()
        End Try
        '*******************to update def usr in -company table-******
        Dim defuid1 As Integer = 0
        Try
            UsrCmd = New SqlCommand("select coid from finactCogatemstr where codefusr='" & (1) & "'", FinActConn)

            UsrRdr = UsrCmd.ExecuteReader
            While UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    defuid1 = UsrRdr(0)
                    Try
                        UsrCmd1 = New SqlCommand("finact_setdefaultadmin_update", FinActConn1)
                        UsrCmd1.CommandType = CommandType.StoredProcedure
                        UsrCmd1.Parameters.AddWithValue("@coid", defuid1)

                        UsrCmd1.Parameters.AddWithValue("@codefusr", 0)


                        UsrCmd1.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        UsrCmd1 = Nothing

                    End Try
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd = Nothing
            UsrRdr.Close()
        End Try
    End Sub
    Private Sub update_usrdefault_admin()

        Dim uid As Integer
        Dim defuid As Integer = 0

        Try
            UsrCmd = New SqlCommand("select coid from finactCogatemstr where codefusr='" & (1) & "'", FinActConn)
            UsrRdr = UsrCmd.ExecuteReader
            While UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    defuid = UsrRdr(0)
                    Try
                        UsrCmd1 = New SqlCommand("finact_setdefaultadmin_update", FinActConn1)
                        UsrCmd1.CommandType = CommandType.StoredProcedure
                        UsrCmd1.Parameters.AddWithValue("@coid", defuid)
                        UsrCmd1.Parameters.AddWithValue("@codefusr", 0)
                        UsrCmd1.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        UsrCmd1 = Nothing
                    End Try
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd = Nothing
            UsrRdr.Close()
        End Try
        Try
            UsrCmd = New SqlCommand("select coid from finactCogatemstr where CoAdmn='" & ("Administrator") & "'", FinActConn)
            UsrRdr = UsrCmd.ExecuteReader
            UsrRdr.Read()
            If UsrRdr.HasRows = True Then
                uid = UsrRdr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd = Nothing
            UsrRdr.Close()
        End Try
        Try
            UsrCmd = New SqlCommand("finact_setdefaultadmin_update", FinActConn)
            UsrCmd.CommandType = CommandType.StoredProcedure
            UsrCmd.Parameters.AddWithValue("@coid", uid)
            If CheckBox2.Checked = True Then
                UsrCmd.Parameters.AddWithValue("@codefusr", 1)
            ElseIf CheckBox2.Checked = False Then
                UsrCmd.Parameters.AddWithValue("@codefusr", 0)
            End If
            UsrCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd = Nothing
            UsrRdr.Close()
        End Try
        '******************* to update defusr in -user table-
        Dim defuid1 As Integer = 0

        Try
            UsrCmd = New SqlCommand("select usrid from finactusr where usrdefault='" & (1) & "'", FinActConn)

            UsrRdr = UsrCmd.ExecuteReader
            While UsrRdr.Read()
                If UsrRdr.HasRows = True Then
                    defuid1 = UsrRdr(0)
                    Try
                        UsrCmd1 = New SqlCommand("finact_setdefaultusr_update", FinActConn1)
                        UsrCmd1.CommandType = CommandType.StoredProcedure
                        UsrCmd1.Parameters.AddWithValue("@uid", defuid1)

                        UsrCmd1.Parameters.AddWithValue("@usrdefault", 0)


                        UsrCmd1.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        UsrCmd1 = Nothing

                    End Try
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            UsrCmd = Nothing
            UsrRdr.Close()
        End Try
    End Sub

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid.KeyPress
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "." Then
            If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                e.Handled = True
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtuid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtuid.TextChanged

    End Sub
    Private Sub AllControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtuid.KeyDown, BtnLogin.KeyDown, CheckBox1.KeyDown _
    , CheckBox2.KeyDown, txtans.KeyDown, txthint.KeyDown, txtid.KeyDown, Txtpass.KeyDown, Txtuid.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class

Imports System.Data
Imports System.Data.SqlClient
Public Class FrmAltrPass
    Inherits System.Windows.Forms.Form
    Dim AltrCmd As SqlCommand
    Dim AltrRdr As SqlDataReader
    Dim UsrId As String
    Friend WithEvents BtnSubmit As System.Windows.Forms.Button
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents lbl6 As System.Windows.Forms.Label
    Friend WithEvents lbl8 As System.Windows.Forms.Label
    Friend WithEvents lbl7 As System.Windows.Forms.Label
    Dim UsrPass As String
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
    Friend WithEvents TxtUsrid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtOldPass As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNewPass As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtConfrmPass As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAltrPass))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lbl8 = New System.Windows.Forms.Label
        Me.lbl7 = New System.Windows.Forms.Label
        Me.lbl6 = New System.Windows.Forms.Label
        Me.lbl5 = New System.Windows.Forms.Label
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.BtnSubmit = New System.Windows.Forms.Button
        Me.TxtUsrid = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtOldPass = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtNewPass = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtConfrmPass = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.FinAcct.My.Resources.Resources.Prairie_Wind
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lbl8)
        Me.Panel1.Controls.Add(Me.lbl7)
        Me.Panel1.Controls.Add(Me.lbl6)
        Me.Panel1.Controls.Add(Me.lbl5)
        Me.Panel1.Controls.Add(Me.BtnCncl)
        Me.Panel1.Controls.Add(Me.BtnSubmit)
        Me.Panel1.Controls.Add(Me.TxtUsrid)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtOldPass)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtNewPass)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtConfrmPass)
        Me.Panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(358, 228)
        Me.Panel1.TabIndex = 0
        '
        'lbl8
        '
        Me.lbl8.BackColor = System.Drawing.Color.Transparent
        Me.lbl8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl8.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbl8.Location = New System.Drawing.Point(11, 169)
        Me.lbl8.Name = "lbl8"
        Me.lbl8.Size = New System.Drawing.Size(306, 16)
        Me.lbl8.TabIndex = 10
        Me.lbl8.Text = "Invalid input, please try again."
        Me.lbl8.Visible = False
        '
        'lbl7
        '
        Me.lbl7.BackColor = System.Drawing.Color.Transparent
        Me.lbl7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbl7.Location = New System.Drawing.Point(11, 128)
        Me.lbl7.Name = "lbl7"
        Me.lbl7.Size = New System.Drawing.Size(309, 16)
        Me.lbl7.TabIndex = 9
        Me.lbl7.Text = "Invalid input, please try again."
        Me.lbl7.Visible = False
        '
        'lbl6
        '
        Me.lbl6.BackColor = System.Drawing.Color.Transparent
        Me.lbl6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbl6.Location = New System.Drawing.Point(11, 85)
        Me.lbl6.Name = "lbl6"
        Me.lbl6.Size = New System.Drawing.Size(335, 16)
        Me.lbl6.TabIndex = 8
        Me.lbl6.Text = "Invalid password, please try again  with another value."
        Me.lbl6.Visible = False
        '
        'lbl5
        '
        Me.lbl5.BackColor = System.Drawing.Color.Transparent
        Me.lbl5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbl5.Location = New System.Drawing.Point(11, 43)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(335, 16)
        Me.lbl5.TabIndex = 7
        Me.lbl5.Text = "Invalid user name , please try again  with another value."
        Me.lbl5.Visible = False
        '
        'BtnCncl
        '
        Me.BtnCncl.BackgroundImage = CType(resources.GetObject("BtnCncl.BackgroundImage"), System.Drawing.Image)
        Me.BtnCncl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCncl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCncl.ForeColor = System.Drawing.Color.Navy
        Me.BtnCncl.Location = New System.Drawing.Point(184, 192)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(162, 26)
        Me.BtnCncl.TabIndex = 6
        Me.BtnCncl.Text = "Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'BtnSubmit
        '
        Me.BtnSubmit.BackgroundImage = CType(resources.GetObject("BtnSubmit.BackgroundImage"), System.Drawing.Image)
        Me.BtnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSubmit.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSubmit.ForeColor = System.Drawing.Color.Navy
        Me.BtnSubmit.Location = New System.Drawing.Point(11, 192)
        Me.BtnSubmit.Name = "BtnSubmit"
        Me.BtnSubmit.Size = New System.Drawing.Size(162, 26)
        Me.BtnSubmit.TabIndex = 4
        Me.BtnSubmit.Text = "Submit"
        Me.BtnSubmit.UseVisualStyleBackColor = True
        '
        'TxtUsrid
        '
        Me.TxtUsrid.BackColor = System.Drawing.Color.LemonChiffon
        Me.TxtUsrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUsrid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsrid.Location = New System.Drawing.Point(145, 19)
        Me.TxtUsrid.MaxLength = 50
        Me.TxtUsrid.Name = "TxtUsrid"
        Me.TxtUsrid.Size = New System.Drawing.Size(201, 20)
        Me.TxtUsrid.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "User Id"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(8, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Old Password"
        '
        'TxtOldPass
        '
        Me.TxtOldPass.BackColor = System.Drawing.Color.LemonChiffon
        Me.TxtOldPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOldPass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOldPass.Location = New System.Drawing.Point(145, 63)
        Me.TxtOldPass.MaxLength = 32
        Me.TxtOldPass.Name = "TxtOldPass"
        Me.TxtOldPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtOldPass.Size = New System.Drawing.Size(201, 20)
        Me.TxtOldPass.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(8, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "New Password"
        '
        'TxtNewPass
        '
        Me.TxtNewPass.BackColor = System.Drawing.Color.LemonChiffon
        Me.TxtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNewPass.Enabled = False
        Me.TxtNewPass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNewPass.Location = New System.Drawing.Point(145, 105)
        Me.TxtNewPass.MaxLength = 32
        Me.TxtNewPass.Name = "TxtNewPass"
        Me.TxtNewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtNewPass.Size = New System.Drawing.Size(201, 20)
        Me.TxtNewPass.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(8, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Confirm Password"
        '
        'TxtConfrmPass
        '
        Me.TxtConfrmPass.BackColor = System.Drawing.Color.LemonChiffon
        Me.TxtConfrmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConfrmPass.Enabled = False
        Me.TxtConfrmPass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConfrmPass.Location = New System.Drawing.Point(145, 146)
        Me.TxtConfrmPass.MaxLength = 32
        Me.TxtConfrmPass.Name = "TxtConfrmPass"
        Me.TxtConfrmPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfrmPass.Size = New System.Drawing.Size(201, 20)
        Me.TxtConfrmPass.TabIndex = 3
        '
        'FrmAltrPass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(359, 228)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmAltrPass"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub FrmAltrPass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Panel1.Width = Me.Width
        Me.Panel1.Height = Me.Height
    End Sub

    Private Sub TxtUsrid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUsrid.GotFocus
        TxtUsrid.SelectAll()
    End Sub
    

    Private Sub TxtOldPass_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOldPass.GotFocus
        TxtOldPass.SelectAll()
    End Sub

    
    Private Sub TxtOldPass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOldPass.Leave
        If Trim(TxtUsrid.Text) <> "" And Trim(TxtOldPass.Text) <> "" Then
            CmparePass()
            ' TxtOldPass.BackColor = Color.LemonChiffon
        Else
            TxtUsrid.Focus()

            TxtOldPass.BackColor = Color.Cyan


            Exit Sub
        End If

       

    End Sub
    Private Sub ChekIdPassword()
        Dim EnDeCryp As New EnCryp_DeCryp_String
        Try
            AltrCmd = New SqlCommand("Finact_UsrIdPassword", FinActConn)
            AltrCmd.CommandType = CommandType.StoredProcedure
            AltrCmd.Parameters.AddWithValue("@Chktxt", Trim(TxtUsrid.Text))
            AltrCmd.Parameters.AddWithValue("@Chktxt1", EnDeCryp.Encrypt(Trim(TxtUsrid.Text)))
            AltrRdr = AltrCmd.ExecuteReader
            AltrRdr.Read()
            If Trim(TxtUsrid.Text) = "Administrator" Then
                UsrId = Trim(AltrRdr("coadmn"))
                UsrPass = EnDeCryp.Decrypt(AltrRdr("coadmnpass"))
            Else
                UsrId = EnDeCryp.Decrypt(AltrRdr("usrname"))
                UsrPass = EnDeCryp.Decrypt(AltrRdr("usrpass"))
            End If

        Catch ex As Exception
            ' MsgBox(ex.Message)
        Finally
            AltrRdr.Close()
            AltrCmd = Nothing
        End Try
    End Sub
    Private Sub CmparePass()
        If Trim(TxtUsrid.Text) <> "" And Trim(TxtOldPass.Text) <> "" Then
            ChekIdPassword()
            If UsrId <> Trim(TxtUsrid.Text) Then
                'MsgBox("Invalid User name or Password", MsgBoxStyle.Critical, "Login")
                TxtUsrid.BackColor = Color.Cyan
                TxtUsrid.Focus()
                TxtUsrid.SelectAll()
                lbl5.Visible = True
                Exit Sub
            End If
            If UsrPass <> Trim(TxtOldPass.Text) Then
                TxtOldPass.BackColor = Color.Cyan
                TxtOldPass.Focus()
                TxtOldPass.SelectAll()
                lbl6.Visible = True
                Exit Sub
            End If
            TxtOldPass.BackColor = Color.LemonChiffon
            TxtNewPass.Enabled = True
            TxtConfrmPass.Enabled = True
            TxtNewPass.Focus()
            lbl5.Visible = False
            lbl6.Visible = False
            
        End If

    End Sub

    Private Sub TxtConfrmPass_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtConfrmPass.GotFocus
        TxtConfrmPass.SelectAll()
    End Sub

    Private Sub TxtNewPass_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNewPass.GotFocus
        TxtNewPass.SelectAll()
    End Sub
    Private Sub UpdateRec()
        Dim EnDeCryp As New EnCryp_DeCryp_String
        AltrCmd = New SqlCommand("Finact_Password_Update", FinActConn)
        AltrCmd.CommandType = CommandType.StoredProcedure
        Try
            AltrCmd.CommandType = CommandType.StoredProcedure
            AltrCmd.Parameters.AddWithValue("@Chkval", Trim(TxtUsrid.Text))
            AltrCmd.Parameters.AddWithValue("@Chkval1", EnDeCryp.Encrypt(Trim(TxtUsrid.Text)))
            AltrCmd.Parameters.AddWithValue("@upass", EnDeCryp.Encrypt(TxtConfrmPass.Text))
            AltrCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            AltrCmd = Nothing
        End Try
    End Sub

    Private Sub BtnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        If TxtNewPass.Enabled = True And TxtConfrmPass.Enabled = True Then
            If Trim(TxtNewPass.Text) = "" Or Trim(TxtConfrmPass.Text) = "" Then
                TxtNewPass.Focus()
                
                Exit Sub
            Else
                If Trim(TxtNewPass.Text) = Trim(TxtConfrmPass.Text) Then
                    UpdateRec()
                    MsgBox("Your Password has been Successfully Changed.", MsgBoxStyle.Information, "Password Changed")
                    lbl7.Visible = False
                    lbl8.Visible = False
                    TxtNewPass.BackColor = Color.LemonChiffon
                    TxtConfrmPass.BackColor = Color.LemonChiffon
                    Me.Close()
                Else
                    TxtNewPass.Focus()
                    lbl7.Visible = True
                    lbl8.Visible = True
                    TxtNewPass.BackColor = Color.Cyan
                    TxtConfrmPass.BackColor = Color.Cyan
                    Exit Sub
                End If

            End If
        Else
            TxtUsrid.Focus()
        End If

    End Sub

    Private Sub TxtConfrmPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConfrmPass.KeyDown, BtnCncl.KeyDown, BtnSubmit.KeyDown _
    , TxtNewPass.KeyDown, TxtOldPass.KeyDown, TxtUsrid.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AllControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConfrmPass.KeyDown _
   , TxtNewPass.KeyDown, TxtOldPass.KeyDown, TxtUsrid.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        Me.Close()
    End Sub

    Private Sub TxtUsrid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUsrid.Leave
        If Trim(TxtUsrid.Text) = "" Then
            TxtUsrid.BackColor = Color.Cyan
        Else
            TxtUsrid.BackColor = Color.LemonChiffon
            lbl5.Visible = False
        End If
    End Sub

   
    Private Sub TxtOldPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOldPass.TextChanged

    End Sub

    Private Sub TxtUsrid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUsrid.TextChanged

    End Sub

    Private Sub TxtNewPass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNewPass.Leave
        If Trim(Len(TxtNewPass.Text)) < 8 Then
            lbl7.Visible = True
            TxtNewPass.BackColor = Color.Cyan
            TxtNewPass.Focus()
        Else
            lbl7.Visible = False
            TxtNewPass.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub TxtNewPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNewPass.TextChanged

    End Sub

    Private Sub TxtConfrmPass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtConfrmPass.Leave
        If Trim(Len(TxtConfrmPass.Text)) < 8 Then
            lbl8.Visible = True
            TxtConfrmPass.BackColor = Color.Cyan
            TxtConfrmPass.Focus()
        Else
            lbl8.Visible = False
            TxtConfrmPass.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub TxtConfrmPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtConfrmPass.TextChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
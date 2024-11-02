<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShipConts
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmShipConts))
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dGshp = New System.Windows.Forms.DataGridView
        Me.Btncancel = New System.Windows.Forms.Button
        Me.BtnDele = New System.Windows.Forms.Button
        Me.Btnsave = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Txtshphome = New System.Windows.Forms.TextBox
        Me.Txtshpmail = New System.Windows.Forms.TextBox
        Me.TxtshpFax = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtshpname = New System.Windows.Forms.TextBox
        Me.txtshpPH1 = New System.Windows.Forms.TextBox
        Me.txtshpPH2 = New System.Windows.Forms.TextBox
        Me.txtshpremarks = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtShpMob = New System.Windows.Forms.TextBox
        Me.Txtextn1 = New System.Windows.Forms.TextBox
        Me.Txtextn2 = New System.Windows.Forms.TextBox
        Me.CmbxJobtytl = New System.Windows.Forms.ComboBox
        Me.Btnjobtytl = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dGshp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackgroundImage = Global.FinAcct.My.Resources.Resources.key10
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Location = New System.Drawing.Point(1, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(609, 74)
        Me.Panel5.TabIndex = 45
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.FinAcct.My.Resources.Resources._9559hb
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(524, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(85, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 75)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer1.Panel1.Controls.Add(Me.dGshp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Btncancel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnDele)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Btnsave)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(604, 363)
        Me.SplitContainer1.SplitterDistance = 137
        Me.SplitContainer1.TabIndex = 100
        Me.SplitContainer1.TabStop = False
        '
        'dGshp
        '
        Me.dGshp.AllowUserToDeleteRows = False
        Me.dGshp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGshp.Location = New System.Drawing.Point(21, 12)
        Me.dGshp.Name = "dGshp"
        Me.dGshp.Size = New System.Drawing.Size(76, 38)
        Me.dGshp.TabIndex = 14
        Me.dGshp.Visible = False
        '
        'Btncancel
        '
        Me.Btncancel.BackgroundImage = CType(resources.GetObject("Btncancel.BackgroundImage"), System.Drawing.Image)
        Me.Btncancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Btncancel.Location = New System.Drawing.Point(10, 317)
        Me.Btncancel.Name = "Btncancel"
        Me.Btncancel.Size = New System.Drawing.Size(115, 35)
        Me.Btncancel.TabIndex = 14
        Me.Btncancel.Text = "&Cancel"
        Me.Btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btncancel.UseVisualStyleBackColor = True
        '
        'BtnDele
        '
        Me.BtnDele.BackgroundImage = CType(resources.GetObject("BtnDele.BackgroundImage"), System.Drawing.Image)
        Me.BtnDele.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnDele.Location = New System.Drawing.Point(10, 276)
        Me.BtnDele.Name = "BtnDele"
        Me.BtnDele.Size = New System.Drawing.Size(115, 35)
        Me.BtnDele.TabIndex = 13
        Me.BtnDele.Text = "&Delete"
        Me.BtnDele.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDele.UseVisualStyleBackColor = True
        Me.BtnDele.Visible = False
        '
        'Btnsave
        '
        Me.Btnsave.BackgroundImage = CType(resources.GetObject("Btnsave.BackgroundImage"), System.Drawing.Image)
        Me.Btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Btnsave.Location = New System.Drawing.Point(10, 231)
        Me.Btnsave.Name = "Btnsave"
        Me.Btnsave.Size = New System.Drawing.Size(115, 35)
        Me.Btnsave.TabIndex = 12
        Me.Btnsave.Text = "&Save"
        Me.Btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btnsave.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.19355!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.80645!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Txtshphome, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Txtshpmail, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtshpFax, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtshpname, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtshpPH1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtshpPH2, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtshpremarks, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtShpMob, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Txtextn1, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Txtextn2, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbxJobtytl, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Btnjobtytl, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.60606!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.75757!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(461, 361)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Txtshphome
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Txtshphome, 2)
        Me.Txtshphome.Location = New System.Drawing.Point(121, 164)
        Me.Txtshphome.MaxLength = 45
        Me.Txtshphome.Name = "Txtshphome"
        Me.Txtshphome.Size = New System.Drawing.Size(203, 21)
        Me.Txtshphome.TabIndex = 8
        '
        'Txtshpmail
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Txtshpmail, 3)
        Me.Txtshpmail.Location = New System.Drawing.Point(121, 228)
        Me.Txtshpmail.MaxLength = 45
        Me.Txtshpmail.Name = "Txtshpmail"
        Me.Txtshpmail.Size = New System.Drawing.Size(332, 21)
        Me.Txtshpmail.TabIndex = 10
        '
        'TxtshpFax
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtshpFax, 2)
        Me.TxtshpFax.Location = New System.Drawing.Point(121, 196)
        Me.TxtshpFax.MaxLength = 45
        Me.TxtshpFax.Name = "TxtshpFax"
        Me.TxtshpFax.Size = New System.Drawing.Size(203, 21)
        Me.TxtshpFax.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NAME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "JOB TITLE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 26)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "PHONE BUSSINESS 1."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 26)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "PHONE BUSSINESS 2."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 26)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "CELLUR (MOBILE)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 193)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "FAX No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 225)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "E-MAIL ID"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 263)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "REMARKS"
        '
        'txtshpname
        '
        Me.txtshpname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtshpname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtshpname, 3)
        Me.txtshpname.Location = New System.Drawing.Point(121, 4)
        Me.txtshpname.MaxLength = 45
        Me.txtshpname.Name = "txtshpname"
        Me.txtshpname.Size = New System.Drawing.Size(336, 21)
        Me.txtshpname.TabIndex = 0
        '
        'txtshpPH1
        '
        Me.txtshpPH1.Location = New System.Drawing.Point(121, 68)
        Me.txtshpPH1.MaxLength = 45
        Me.txtshpPH1.Name = "txtshpPH1"
        Me.txtshpPH1.Size = New System.Drawing.Size(114, 21)
        Me.txtshpPH1.TabIndex = 3
        '
        'txtshpPH2
        '
        Me.txtshpPH2.Location = New System.Drawing.Point(121, 100)
        Me.txtshpPH2.MaxLength = 45
        Me.txtshpPH2.Name = "txtshpPH2"
        Me.txtshpPH2.Size = New System.Drawing.Size(114, 21)
        Me.txtshpPH2.TabIndex = 5
        '
        'txtshpremarks
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtshpremarks, 3)
        Me.txtshpremarks.Location = New System.Drawing.Point(121, 266)
        Me.txtshpremarks.MaxLength = 20
        Me.txtshpremarks.Multiline = True
        Me.txtshpremarks.Name = "txtshpremarks"
        Me.txtshpremarks.Size = New System.Drawing.Size(332, 91)
        Me.txtshpremarks.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(242, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "EXTN. No."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(242, 97)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "EXTN. No."
        '
        'TxtShpMob
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtShpMob, 2)
        Me.TxtShpMob.Location = New System.Drawing.Point(121, 132)
        Me.TxtShpMob.MaxLength = 45
        Me.TxtShpMob.Name = "TxtShpMob"
        Me.TxtShpMob.Size = New System.Drawing.Size(203, 21)
        Me.TxtShpMob.TabIndex = 7
        '
        'Txtextn1
        '
        Me.Txtextn1.Location = New System.Drawing.Point(331, 68)
        Me.Txtextn1.MaxLength = 45
        Me.Txtextn1.Name = "Txtextn1"
        Me.Txtextn1.Size = New System.Drawing.Size(78, 21)
        Me.Txtextn1.TabIndex = 4
        '
        'Txtextn2
        '
        Me.Txtextn2.Location = New System.Drawing.Point(331, 100)
        Me.Txtextn2.MaxLength = 45
        Me.Txtextn2.Name = "Txtextn2"
        Me.Txtextn2.Size = New System.Drawing.Size(78, 21)
        Me.Txtextn2.TabIndex = 6
        '
        'CmbxJobtytl
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.CmbxJobtytl, 2)
        Me.CmbxJobtytl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxJobtytl.FormattingEnabled = True
        Me.CmbxJobtytl.Location = New System.Drawing.Point(121, 36)
        Me.CmbxJobtytl.Name = "CmbxJobtytl"
        Me.CmbxJobtytl.Size = New System.Drawing.Size(203, 21)
        Me.CmbxJobtytl.TabIndex = 1
        '
        'Btnjobtytl
        '
        Me.Btnjobtytl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnjobtytl.Location = New System.Drawing.Point(331, 36)
        Me.Btnjobtytl.Name = "Btnjobtytl"
        Me.Btnjobtytl.Size = New System.Drawing.Size(40, 23)
        Me.Btnjobtytl.TabIndex = 2
        Me.Btnjobtytl.TabStop = False
        Me.Btnjobtytl.Text = "...."
        Me.Btnjobtytl.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 161)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "HOME"
        '
        'FrmShipConts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(608, 438)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmShipConts"
        Me.Text = "Contact Master"
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dGshp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Btnsave As System.Windows.Forms.Button
    Friend WithEvents txtshpname As System.Windows.Forms.TextBox
    Friend WithEvents txtshpPH1 As System.Windows.Forms.TextBox
    Friend WithEvents txtshpPH2 As System.Windows.Forms.TextBox
    Friend WithEvents txtshpremarks As System.Windows.Forms.TextBox
    Friend WithEvents Btncancel As System.Windows.Forms.Button
    Friend WithEvents dGshp As System.Windows.Forms.DataGridView
    Friend WithEvents BtnDele As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtShpMob As System.Windows.Forms.TextBox
    Friend WithEvents Txtextn1 As System.Windows.Forms.TextBox
    Friend WithEvents Txtextn2 As System.Windows.Forms.TextBox
    Friend WithEvents CmbxJobtytl As System.Windows.Forms.ComboBox
    Friend WithEvents Txtshpmail As System.Windows.Forms.TextBox
    Friend WithEvents TxtshpFax As System.Windows.Forms.TextBox
    Friend WithEvents Btnjobtytl As System.Windows.Forms.Button
    Friend WithEvents Txtshphome As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class

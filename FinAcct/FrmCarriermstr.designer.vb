<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCarriermstr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCarriermstr))
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dGshp = New System.Windows.Forms.DataGridView
        Me.Btncancel = New System.Windows.Forms.Button
        Me.BtnDele = New System.Windows.Forms.Button
        Me.Btnsave = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtshpname = New System.Windows.Forms.TextBox
        Me.txtshpadrs = New System.Windows.Forms.TextBox
        Me.txtshpadrs1 = New System.Windows.Forms.TextBox
        Me.txtshpadrs2 = New System.Windows.Forms.TextBox
        Me.lblshpstate = New System.Windows.Forms.Label
        Me.lblshpcontry = New System.Windows.Forms.Label
        Me.txtshppinno = New System.Windows.Forms.TextBox
        Me.txtshpphno = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnShpcty = New System.Windows.Forms.Button
        Me.Cmbxshpcty = New System.Windows.Forms.ComboBox
        Me.CmbxMode = New System.Windows.Forms.ComboBox
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dGshp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackgroundImage = Global.FinAcct.My.Resources.Resources.image4
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
        Me.PictureBox1.BackgroundImage = Global.FinAcct.My.Resources.Resources.K31
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(536, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 73)
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
        Me.Btncancel.TabIndex = 13
        Me.Btncancel.Text = "&Exit"
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
        Me.BtnDele.TabIndex = 12
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
        Me.Btnsave.TabIndex = 11
        Me.Btnsave.Text = "&Save"
        Me.Btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btnsave.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.12281!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.87719!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.txtshpname, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtshpadrs, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtshpadrs1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtshpadrs2, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblshpstate, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblshpcontry, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtshppinno, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtshpphno, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbxMode, 1, 9)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(461, 361)
        Me.TableLayoutPanel1.TabIndex = 1
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
        Me.Label2.Location = New System.Drawing.Point(4, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "ADDRESS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "AREA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "LAND MARK"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "CITY"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "STATE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "COUNTRY"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 253)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "PIN NO."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 289)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "PHONE NO."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 325)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Mode"
        '
        'txtshpname
        '
        Me.txtshpname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtshpname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtshpname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtshpname.Location = New System.Drawing.Point(115, 4)
        Me.txtshpname.MaxLength = 45
        Me.txtshpname.Name = "txtshpname"
        Me.txtshpname.Size = New System.Drawing.Size(342, 21)
        Me.txtshpname.TabIndex = 0
        '
        'txtshpadrs
        '
        Me.txtshpadrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtshpadrs.Location = New System.Drawing.Point(115, 40)
        Me.txtshpadrs.MaxLength = 45
        Me.txtshpadrs.Name = "txtshpadrs"
        Me.txtshpadrs.Size = New System.Drawing.Size(285, 21)
        Me.txtshpadrs.TabIndex = 1
        '
        'txtshpadrs1
        '
        Me.txtshpadrs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtshpadrs1.Location = New System.Drawing.Point(115, 76)
        Me.txtshpadrs1.MaxLength = 45
        Me.txtshpadrs1.Name = "txtshpadrs1"
        Me.txtshpadrs1.Size = New System.Drawing.Size(285, 21)
        Me.txtshpadrs1.TabIndex = 2
        '
        'txtshpadrs2
        '
        Me.txtshpadrs2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtshpadrs2.Location = New System.Drawing.Point(115, 112)
        Me.txtshpadrs2.MaxLength = 45
        Me.txtshpadrs2.Name = "txtshpadrs2"
        Me.txtshpadrs2.Size = New System.Drawing.Size(285, 21)
        Me.txtshpadrs2.TabIndex = 3
        '
        'lblshpstate
        '
        Me.lblshpstate.AutoSize = True
        Me.lblshpstate.Location = New System.Drawing.Point(115, 181)
        Me.lblshpstate.Name = "lblshpstate"
        Me.lblshpstate.Size = New System.Drawing.Size(0, 13)
        Me.lblshpstate.TabIndex = 0
        '
        'lblshpcontry
        '
        Me.lblshpcontry.AutoSize = True
        Me.lblshpcontry.Location = New System.Drawing.Point(115, 217)
        Me.lblshpcontry.Name = "lblshpcontry"
        Me.lblshpcontry.Size = New System.Drawing.Size(0, 13)
        Me.lblshpcontry.TabIndex = 0
        '
        'txtshppinno
        '
        Me.txtshppinno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtshppinno.Location = New System.Drawing.Point(115, 256)
        Me.txtshppinno.MaxLength = 20
        Me.txtshppinno.Name = "txtshppinno"
        Me.txtshppinno.Size = New System.Drawing.Size(285, 21)
        Me.txtshppinno.TabIndex = 8
        '
        'txtshpphno
        '
        Me.txtshpphno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtshpphno.Location = New System.Drawing.Point(115, 292)
        Me.txtshpphno.MaxLength = 49
        Me.txtshpphno.Name = "txtshpphno"
        Me.txtshpphno.Size = New System.Drawing.Size(285, 21)
        Me.txtshpphno.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnShpcty)
        Me.Panel1.Controls.Add(Me.Cmbxshpcty)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(115, 148)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(342, 29)
        Me.Panel1.TabIndex = 5
        Me.Panel1.TabStop = True
        '
        'BtnShpcty
        '
        Me.BtnShpcty.Location = New System.Drawing.Point(289, 2)
        Me.BtnShpcty.Name = "BtnShpcty"
        Me.BtnShpcty.Size = New System.Drawing.Size(31, 23)
        Me.BtnShpcty.TabIndex = 7
        Me.BtnShpcty.TabStop = False
        Me.BtnShpcty.Text = "...."
        Me.BtnShpcty.UseVisualStyleBackColor = True
        '
        'Cmbxshpcty
        '
        Me.Cmbxshpcty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxshpcty.FormattingEnabled = True
        Me.Cmbxshpcty.Location = New System.Drawing.Point(3, 3)
        Me.Cmbxshpcty.Name = "Cmbxshpcty"
        Me.Cmbxshpcty.Size = New System.Drawing.Size(282, 21)
        Me.Cmbxshpcty.TabIndex = 6
        '
        'CmbxMode
        '
        Me.CmbxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxMode.FormattingEnabled = True
        Me.CmbxMode.Items.AddRange(New Object() {"Air", "Currier", "Railway", "Road Transport", "Shipping"})
        Me.CmbxMode.Location = New System.Drawing.Point(115, 328)
        Me.CmbxMode.Name = "CmbxMode"
        Me.CmbxMode.Size = New System.Drawing.Size(130, 21)
        Me.CmbxMode.Sorted = True
        Me.CmbxMode.TabIndex = 10
        '
        'FrmCarriermstr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(608, 438)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCarriermstr"
        Me.Text = "Carrier Master"
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dGshp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Btnsave As System.Windows.Forms.Button
    Friend WithEvents txtshpname As System.Windows.Forms.TextBox
    Friend WithEvents txtshpadrs As System.Windows.Forms.TextBox
    Friend WithEvents txtshpadrs1 As System.Windows.Forms.TextBox
    Friend WithEvents txtshpadrs2 As System.Windows.Forms.TextBox
    Friend WithEvents lblshpstate As System.Windows.Forms.Label
    Friend WithEvents lblshpcontry As System.Windows.Forms.Label
    Friend WithEvents txtshppinno As System.Windows.Forms.TextBox
    Friend WithEvents txtshpphno As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnShpcty As System.Windows.Forms.Button
    Friend WithEvents Cmbxshpcty As System.Windows.Forms.ComboBox
    Friend WithEvents Btncancel As System.Windows.Forms.Button
    Friend WithEvents dGshp As System.Windows.Forms.DataGridView
    Friend WithEvents BtnDele As System.Windows.Forms.Button
    Friend WithEvents CmbxMode As System.Windows.Forms.ComboBox
End Class

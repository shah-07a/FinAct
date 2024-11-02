<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSalePurCatgry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSalePurCatgry))
        Me.LstVewFnd = New System.Windows.Forms.ListView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtSurcharg = New System.Windows.Forms.TextBox
        Me.Vatpercent = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Btnsp = New System.Windows.Forms.Button
        Me.Cmbxtxtype = New System.Windows.Forms.ComboBox
        Me.RbPur = New System.Windows.Forms.RadioButton
        Me.RbSale = New System.Windows.Forms.RadioButton
        Me.Btnadd = New System.Windows.Forms.Button
        Me.TxtDept = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblVatRate = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Btnedt = New System.Windows.Forms.Button
        Me.BtnDele = New System.Windows.Forms.Button
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnClos = New System.Windows.Forms.Button
        Me.ChkbxCform = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LstVewFnd
        '
        Me.LstVewFnd.AllowDrop = True
        Me.LstVewFnd.BackColor = System.Drawing.Color.White
        Me.LstVewFnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstVewFnd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVewFnd.ForeColor = System.Drawing.Color.Navy
        Me.LstVewFnd.GridLines = True
        Me.LstVewFnd.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstVewFnd.HoverSelection = True
        Me.LstVewFnd.Location = New System.Drawing.Point(498, 5)
        Me.LstVewFnd.MultiSelect = False
        Me.LstVewFnd.Name = "LstVewFnd"
        Me.LstVewFnd.Size = New System.Drawing.Size(348, 424)
        Me.LstVewFnd.TabIndex = 10
        Me.LstVewFnd.UseCompatibleStateImageBehavior = False
        Me.LstVewFnd.View = System.Windows.Forms.View.Details
        Me.LstVewFnd.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ChkbxCform)
        Me.GroupBox1.Controls.Add(Me.TxtSurcharg)
        Me.GroupBox1.Controls.Add(Me.Vatpercent)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Btnadd)
        Me.GroupBox1.Controls.Add(Me.TxtDept)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblVatRate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Btnedt)
        Me.GroupBox1.Controls.Add(Me.BtnDele)
        Me.GroupBox1.Controls.Add(Me.BtnFind)
        Me.GroupBox1.Controls.Add(Me.BtnSave)
        Me.GroupBox1.Controls.Add(Me.BtnClos)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(485, 424)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'TxtSurcharg
        '
        Me.TxtSurcharg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSurcharg.Location = New System.Drawing.Point(160, 259)
        Me.TxtSurcharg.Name = "TxtSurcharg"
        Me.TxtSurcharg.Size = New System.Drawing.Size(82, 23)
        Me.TxtSurcharg.TabIndex = 7
        Me.TxtSurcharg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Vatpercent
        '
        Me.Vatpercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Vatpercent.Location = New System.Drawing.Point(160, 185)
        Me.Vatpercent.Name = "Vatpercent"
        Me.Vatpercent.Size = New System.Drawing.Size(82, 23)
        Me.Vatpercent.TabIndex = 6
        Me.Vatpercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Btnsp)
        Me.GroupBox2.Controls.Add(Me.Cmbxtxtype)
        Me.GroupBox2.Controls.Add(Me.RbPur)
        Me.GroupBox2.Controls.Add(Me.RbSale)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(469, 83)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Btnsp
        '
        Me.Btnsp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnsp.Location = New System.Drawing.Point(425, 40)
        Me.Btnsp.Name = "Btnsp"
        Me.Btnsp.Size = New System.Drawing.Size(31, 23)
        Me.Btnsp.TabIndex = 16
        Me.Btnsp.TabStop = False
        Me.Btnsp.Text = "..."
        Me.Btnsp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btnsp.UseVisualStyleBackColor = True
        '
        'Cmbxtxtype
        '
        Me.Cmbxtxtype.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxtxtype.FormattingEnabled = True
        Me.Cmbxtxtype.Location = New System.Drawing.Point(9, 41)
        Me.Cmbxtxtype.Name = "Cmbxtxtype"
        Me.Cmbxtxtype.Size = New System.Drawing.Size(410, 21)
        Me.Cmbxtxtype.TabIndex = 4
        '
        'RbPur
        '
        Me.RbPur.AutoSize = True
        Me.RbPur.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPur.ForeColor = System.Drawing.Color.Navy
        Me.RbPur.Location = New System.Drawing.Point(119, 14)
        Me.RbPur.Name = "RbPur"
        Me.RbPur.Size = New System.Drawing.Size(91, 20)
        Me.RbPur.TabIndex = 3
        Me.RbPur.Text = "Purchase "
        Me.RbPur.UseVisualStyleBackColor = True
        '
        'RbSale
        '
        Me.RbSale.Checked = True
        Me.RbSale.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSale.ForeColor = System.Drawing.Color.Navy
        Me.RbSale.Location = New System.Drawing.Point(9, 11)
        Me.RbSale.Name = "RbSale"
        Me.RbSale.Size = New System.Drawing.Size(104, 24)
        Me.RbSale.TabIndex = 2
        Me.RbSale.TabStop = True
        Me.RbSale.Text = "Sale "
        Me.RbSale.UseVisualStyleBackColor = True
        '
        'Btnadd
        '
        Me.Btnadd.BackColor = System.Drawing.Color.Transparent
        Me.Btnadd.BackgroundImage = CType(resources.GetObject("Btnadd.BackgroundImage"), System.Drawing.Image)
        Me.Btnadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnadd.FlatAppearance.BorderSize = 0
        Me.Btnadd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnadd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnadd.ForeColor = System.Drawing.Color.DarkBlue
        Me.Btnadd.Location = New System.Drawing.Point(5, 392)
        Me.Btnadd.Name = "Btnadd"
        Me.Btnadd.Size = New System.Drawing.Size(74, 23)
        Me.Btnadd.TabIndex = 9
        Me.Btnadd.Text = "&Add"
        Me.Btnadd.UseVisualStyleBackColor = False
        '
        'TxtDept
        '
        Me.TxtDept.BackColor = System.Drawing.Color.White
        Me.TxtDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDept.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDept.Location = New System.Drawing.Point(93, 113)
        Me.TxtDept.MaxLength = 30
        Me.TxtDept.Name = "TxtDept"
        Me.TxtDept.ReadOnly = True
        Me.TxtDept.Size = New System.Drawing.Size(384, 21)
        Me.TxtDept.TabIndex = 5
        Me.TxtDept.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(14, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Tax Rate (%) :-"
        '
        'lblVatRate
        '
        Me.lblVatRate.BackColor = System.Drawing.Color.White
        Me.lblVatRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVatRate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVatRate.ForeColor = System.Drawing.Color.Navy
        Me.lblVatRate.Location = New System.Drawing.Point(244, 185)
        Me.lblVatRate.Name = "lblVatRate"
        Me.lblVatRate.Size = New System.Drawing.Size(82, 22)
        Me.lblVatRate.TabIndex = 15
        Me.lblVatRate.Text = "Vat Rate"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(14, 259)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Surcharge Rate (%)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(6, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Category :-"
        Me.Label1.Visible = False
        '
        'Btnedt
        '
        Me.Btnedt.BackColor = System.Drawing.Color.Transparent
        Me.Btnedt.BackgroundImage = CType(resources.GetObject("Btnedt.BackgroundImage"), System.Drawing.Image)
        Me.Btnedt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnedt.FlatAppearance.BorderSize = 0
        Me.Btnedt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btnedt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnedt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnedt.ForeColor = System.Drawing.Color.DarkBlue
        Me.Btnedt.Location = New System.Drawing.Point(85, 392)
        Me.Btnedt.Name = "Btnedt"
        Me.Btnedt.Size = New System.Drawing.Size(74, 23)
        Me.Btnedt.TabIndex = 10
        Me.Btnedt.Text = "&Edit"
        Me.Btnedt.UseVisualStyleBackColor = False
        '
        'BtnDele
        '
        Me.BtnDele.BackColor = System.Drawing.Color.Transparent
        Me.BtnDele.BackgroundImage = CType(resources.GetObject("BtnDele.BackgroundImage"), System.Drawing.Image)
        Me.BtnDele.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDele.FlatAppearance.BorderSize = 0
        Me.BtnDele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnDele.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDele.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDele.ForeColor = System.Drawing.Color.DarkBlue
        Me.BtnDele.Location = New System.Drawing.Point(165, 392)
        Me.BtnDele.Name = "BtnDele"
        Me.BtnDele.Size = New System.Drawing.Size(74, 23)
        Me.BtnDele.TabIndex = 11
        Me.BtnDele.Text = "&Delete"
        Me.BtnDele.UseVisualStyleBackColor = False
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = System.Drawing.Color.Transparent
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFind.FlatAppearance.BorderSize = 0
        Me.BtnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.ForeColor = System.Drawing.Color.DarkBlue
        Me.BtnFind.Location = New System.Drawing.Point(245, 392)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(74, 23)
        Me.BtnFind.TabIndex = 12
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.DarkBlue
        Me.BtnSave.Location = New System.Drawing.Point(325, 392)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(74, 23)
        Me.BtnSave.TabIndex = 13
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnClos
        '
        Me.BtnClos.BackColor = System.Drawing.Color.Transparent
        Me.BtnClos.BackgroundImage = CType(resources.GetObject("BtnClos.BackgroundImage"), System.Drawing.Image)
        Me.BtnClos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClos.FlatAppearance.BorderSize = 0
        Me.BtnClos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnClos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClos.ForeColor = System.Drawing.Color.DarkBlue
        Me.BtnClos.Location = New System.Drawing.Point(405, 392)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(74, 23)
        Me.BtnClos.TabIndex = 14
        Me.BtnClos.Text = "&Close"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'ChkbxCform
        '
        Me.ChkbxCform.AutoSize = True
        Me.ChkbxCform.Location = New System.Drawing.Point(17, 327)
        Me.ChkbxCform.Name = "ChkbxCform"
        Me.ChkbxCform.Size = New System.Drawing.Size(164, 20)
        Me.ChkbxCform.TabIndex = 8
        Me.ChkbxCform.Text = "Is 'C' Form Required?"
        Me.ChkbxCform.UseVisualStyleBackColor = True
        '
        'FrmSalePurCatgry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.ClientSize = New System.Drawing.Size(496, 432)
        Me.Controls.Add(Me.LstVewFnd)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmSalePurCatgry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sale/Purchase Tax  Category Master"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LstVewFnd As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Btnadd As System.Windows.Forms.Button
    Friend WithEvents TxtDept As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btnedt As System.Windows.Forms.Button
    Friend WithEvents BtnDele As System.Windows.Forms.Button
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RbPur As System.Windows.Forms.RadioButton
    Friend WithEvents RbSale As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVatRate As System.Windows.Forms.Label
    Friend WithEvents Cmbxtxtype As System.Windows.Forms.ComboBox
    Friend WithEvents Btnsp As System.Windows.Forms.Button
    Friend WithEvents Vatpercent As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSurcharg As System.Windows.Forms.TextBox
    Friend WithEvents ChkbxCform As System.Windows.Forms.CheckBox
End Class

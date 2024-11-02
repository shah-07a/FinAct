<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBrnch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBrnch))
        Me.LstVewFnd = New System.Windows.Forms.ListView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Btnadd = New System.Windows.Forms.Button
        Me.TxtDept = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnClos = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.LstVewFnd.Location = New System.Drawing.Point(418, 10)
        Me.LstVewFnd.MultiSelect = False
        Me.LstVewFnd.Name = "LstVewFnd"
        Me.LstVewFnd.Size = New System.Drawing.Size(329, 101)
        Me.LstVewFnd.TabIndex = 7
        Me.LstVewFnd.UseCompatibleStateImageBehavior = False
        Me.LstVewFnd.View = System.Windows.Forms.View.Details
        Me.LstVewFnd.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Btnadd)
        Me.GroupBox1.Controls.Add(Me.TxtDept)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnFind)
        Me.GroupBox1.Controls.Add(Me.BtnSave)
        Me.GroupBox1.Controls.Add(Me.BtnClos)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(404, 106)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Btnadd
        '
        Me.Btnadd.BackColor = System.Drawing.Color.Gainsboro
        Me.Btnadd.BackgroundImage = CType(resources.GetObject("Btnadd.BackgroundImage"), System.Drawing.Image)
        Me.Btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnadd.Location = New System.Drawing.Point(207, 68)
        Me.Btnadd.Name = "Btnadd"
        Me.Btnadd.Size = New System.Drawing.Size(90, 30)
        Me.Btnadd.TabIndex = 3
        Me.Btnadd.Text = "&Cancel"
        Me.Btnadd.UseVisualStyleBackColor = False
        '
        'TxtDept
        '
        Me.TxtDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDept.Location = New System.Drawing.Point(111, 27)
        Me.TxtDept.MaxLength = 70
        Me.TxtDept.Name = "TxtDept"
        Me.TxtDept.Size = New System.Drawing.Size(282, 20)
        Me.TxtDept.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 14)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Branch Name :-"
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Location = New System.Drawing.Point(111, 68)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(90, 30)
        Me.BtnFind.TabIndex = 2
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Location = New System.Drawing.Point(15, 68)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(90, 30)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnClos
        '
        Me.BtnClos.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnClos.BackgroundImage = CType(resources.GetObject("BtnClos.BackgroundImage"), System.Drawing.Image)
        Me.BtnClos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClos.Location = New System.Drawing.Point(303, 68)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(90, 30)
        Me.BtnClos.TabIndex = 4
        Me.BtnClos.Text = "&Close"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'FrmBrnch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Indigo
        Me.ClientSize = New System.Drawing.Size(759, 120)
        Me.Controls.Add(Me.LstVewFnd)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmBrnch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Branch Master"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LstVewFnd As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Btnadd As System.Windows.Forms.Button
    Friend WithEvents TxtDept As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
End Class

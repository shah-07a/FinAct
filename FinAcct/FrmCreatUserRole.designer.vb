<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCreatUserRole
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCreatUserRole))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtRoleName = New System.Windows.Forms.TextBox
        Me.ChkAall = New System.Windows.Forms.CheckBox
        Me.ChkDele = New System.Windows.Forms.CheckBox
        Me.ChkEdt = New System.Windows.Forms.CheckBox
        Me.ChkAnew = New System.Windows.Forms.CheckBox
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.ChkPrnVew = New System.Windows.Forms.CheckBox
        Me.DgUsrRole = New System.Windows.Forms.DataGridView
        Me.CmbxRole = New System.Windows.Forms.ComboBox
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DgUsrRole, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Role Name"
        '
        'TxtRoleName
        '
        Me.TxtRoleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRoleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRoleName.Location = New System.Drawing.Point(92, 8)
        Me.TxtRoleName.MaxLength = 70
        Me.TxtRoleName.Name = "TxtRoleName"
        Me.TxtRoleName.Size = New System.Drawing.Size(671, 22)
        Me.TxtRoleName.TabIndex = 0
        '
        'ChkAall
        '
        Me.ChkAall.AutoSize = True
        Me.ChkAall.Location = New System.Drawing.Point(425, 471)
        Me.ChkAall.Name = "ChkAall"
        Me.ChkAall.Size = New System.Drawing.Size(300, 18)
        Me.ChkAall.TabIndex = 6
        Me.ChkAall.Text = "Grant  All Permission To All Selected Item(s)"
        Me.ChkAall.UseVisualStyleBackColor = True
        '
        'ChkDele
        '
        Me.ChkDele.AutoSize = True
        Me.ChkDele.Location = New System.Drawing.Point(16, 495)
        Me.ChkDele.Name = "ChkDele"
        Me.ChkDele.Size = New System.Drawing.Size(327, 18)
        Me.ChkDele.TabIndex = 4
        Me.ChkDele.Text = "Grant  Delete Permission To All Selected Item(s)"
        Me.ChkDele.UseVisualStyleBackColor = True
        '
        'ChkEdt
        '
        Me.ChkEdt.AutoSize = True
        Me.ChkEdt.Location = New System.Drawing.Point(16, 471)
        Me.ChkEdt.Name = "ChkEdt"
        Me.ChkEdt.Size = New System.Drawing.Size(344, 18)
        Me.ChkEdt.TabIndex = 3
        Me.ChkEdt.Text = "Grant  Alter/Edit Permission To All Selected Item(s)"
        Me.ChkEdt.UseVisualStyleBackColor = True
        '
        'ChkAnew
        '
        Me.ChkAnew.AutoSize = True
        Me.ChkAnew.Location = New System.Drawing.Point(16, 447)
        Me.ChkAnew.Name = "ChkAnew"
        Me.ChkAnew.Size = New System.Drawing.Size(342, 18)
        Me.ChkAnew.TabIndex = 2
        Me.ChkAnew.Text = "Grant  Add New Permission To All Selected Item(s)"
        Me.ChkAnew.UseVisualStyleBackColor = True
        '
        'BtnExit
        '
        Me.BtnExit.BackgroundImage = CType(resources.GetObject("BtnExit.BackgroundImage"), System.Drawing.Image)
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(575, 526)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(188, 33)
        Me.BtnExit.TabIndex = 9
        Me.BtnExit.Text = "&Exit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'BtnFind
        '
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.Location = New System.Drawing.Point(295, 526)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(188, 33)
        Me.BtnFind.TabIndex = 8
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(15, 526)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(188, 33)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'ChkPrnVew
        '
        Me.ChkPrnVew.AutoSize = True
        Me.ChkPrnVew.Location = New System.Drawing.Point(425, 447)
        Me.ChkPrnVew.Name = "ChkPrnVew"
        Me.ChkPrnVew.Size = New System.Drawing.Size(338, 18)
        Me.ChkPrnVew.TabIndex = 5
        Me.ChkPrnVew.Text = " Grant  Printing Permission To All Selected Item(s)"
        Me.ChkPrnVew.UseVisualStyleBackColor = True
        '
        'DgUsrRole
        '
        Me.DgUsrRole.BackgroundColor = System.Drawing.Color.SteelBlue
        Me.DgUsrRole.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgUsrRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgUsrRole.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column9, Me.Column10})
        Me.DgUsrRole.Location = New System.Drawing.Point(15, 37)
        Me.DgUsrRole.MultiSelect = False
        Me.DgUsrRole.Name = "DgUsrRole"
        Me.DgUsrRole.Size = New System.Drawing.Size(748, 401)
        Me.DgUsrRole.TabIndex = 1
        '
        'CmbxRole
        '
        Me.CmbxRole.Enabled = False
        Me.CmbxRole.FormattingEnabled = True
        Me.CmbxRole.Location = New System.Drawing.Point(92, 8)
        Me.CmbxRole.Name = "CmbxRole"
        Me.CmbxRole.Size = New System.Drawing.Size(345, 22)
        Me.CmbxRole.TabIndex = 10
        Me.CmbxRole.TabStop = False
        Me.CmbxRole.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Schema Membership Owned By This Role"
        Me.DataGridViewTextBoxColumn1.MaxInputLength = 150
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 300
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Owner Index"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 10
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Child Index"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 10
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "TsmiText"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 5
        '
        'Column8
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.NullValue = False
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column8.HeaderText = "Check"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 60
        '
        'Column1
        '
        Me.Column1.HeaderText = "Schema Membership Owned By This Role"
        Me.Column1.MaxInputLength = 150
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 300
        '
        'Column2
        '
        Me.Column2.HeaderText = "Parent Index"
        Me.Column2.MaxInputLength = 10
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "Child Index"
        Me.Column3.MaxInputLength = 10
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.NullValue = False
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.HeaderText = "Add New"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 80
        '
        'Column5
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.NullValue = False
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Alter/Edit"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 80
        '
        'Column6
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.NullValue = False
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column6.HeaderText = "Delete"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 80
        '
        'Column7
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.NullValue = False
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column7.HeaderText = "Printing"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 80
        '
        'Column9
        '
        Me.Column9.HeaderText = "TsmiText"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        Me.Column9.Width = 5
        '
        'Column10
        '
        Me.Column10.HeaderText = "Grand Child Indx"
        Me.Column10.MaxInputLength = 10
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Visible = False
        '
        'FrmCreatUserRole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(779, 564)
        Me.Controls.Add(Me.CmbxRole)
        Me.Controls.Add(Me.DgUsrRole)
        Me.Controls.Add(Me.ChkPrnVew)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.ChkAnew)
        Me.Controls.Add(Me.ChkEdt)
        Me.Controls.Add(Me.ChkDele)
        Me.Controls.Add(Me.ChkAall)
        Me.Controls.Add(Me.TxtRoleName)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCreatUserRole"
        Me.Text = "Create A New User Role"
        CType(Me.DgUsrRole, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TxtRoleName As System.Windows.Forms.TextBox
    Friend WithEvents ChkAall As System.Windows.Forms.CheckBox
    Friend WithEvents ChkDele As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEdt As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAnew As System.Windows.Forms.CheckBox
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents ChkPrnVew As System.Windows.Forms.CheckBox
    Friend WithEvents DgUsrRole As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmbxRole As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

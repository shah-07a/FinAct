<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAttachItem
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAttachItem))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GBoxfilter = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnGo = New System.Windows.Forms.Button
        Me.CmbxItmgrp = New System.Windows.Forms.ComboBox
        Me.ChkItmGrp = New System.Windows.Forms.CheckBox
        Me.GBoxrange = New System.Windows.Forms.GroupBox
        Me.rBall = New System.Windows.Forms.RadioButton
        Me.rBtrading = New System.Windows.Forms.RadioButton
        Me.rBpurchase = New System.Windows.Forms.RadioButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GBoxaction = New System.Windows.Forms.GroupBox
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.Btndel = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.ChkBoxAll = New System.Windows.Forms.CheckBox
        Me.dGAttitm = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GBoxfilter.SuspendLayout()
        Me.GBoxrange.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GBoxaction.SuspendLayout()
        CType(Me.dGAttitm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBoxfilter
        '
        Me.GBoxfilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GBoxfilter.Controls.Add(Me.Label1)
        Me.GBoxfilter.Controls.Add(Me.BtnGo)
        Me.GBoxfilter.Controls.Add(Me.CmbxItmgrp)
        Me.GBoxfilter.Controls.Add(Me.ChkItmGrp)
        Me.GBoxfilter.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxfilter.ForeColor = System.Drawing.Color.Yellow
        Me.GBoxfilter.Location = New System.Drawing.Point(12, 156)
        Me.GBoxfilter.Name = "GBoxfilter"
        Me.GBoxfilter.Size = New System.Drawing.Size(235, 141)
        Me.GBoxfilter.TabIndex = 4
        Me.GBoxfilter.TabStop = False
        Me.GBoxfilter.Text = " Group Filter"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Select a group"
        '
        'BtnGo
        '
        Me.BtnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGo.Location = New System.Drawing.Point(97, 102)
        Me.BtnGo.Name = "BtnGo"
        Me.BtnGo.Size = New System.Drawing.Size(131, 33)
        Me.BtnGo.TabIndex = 7
        Me.BtnGo.Text = "Show Items"
        Me.BtnGo.UseVisualStyleBackColor = True
        '
        'CmbxItmgrp
        '
        Me.CmbxItmgrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxItmgrp.FormattingEnabled = True
        Me.CmbxItmgrp.Location = New System.Drawing.Point(6, 66)
        Me.CmbxItmgrp.Name = "CmbxItmgrp"
        Me.CmbxItmgrp.Size = New System.Drawing.Size(222, 24)
        Me.CmbxItmgrp.TabIndex = 6
        '
        'ChkItmGrp
        '
        Me.ChkItmGrp.AutoSize = True
        Me.ChkItmGrp.BackColor = System.Drawing.Color.Transparent
        Me.ChkItmGrp.Checked = True
        Me.ChkItmGrp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkItmGrp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkItmGrp.ForeColor = System.Drawing.Color.Yellow
        Me.ChkItmGrp.Location = New System.Drawing.Point(6, 20)
        Me.ChkItmGrp.Name = "ChkItmGrp"
        Me.ChkItmGrp.Size = New System.Drawing.Size(40, 17)
        Me.ChkItmGrp.TabIndex = 5
        Me.ChkItmGrp.Text = "All"
        Me.ChkItmGrp.UseVisualStyleBackColor = False
        '
        'GBoxrange
        '
        Me.GBoxrange.BackColor = System.Drawing.Color.Transparent
        Me.GBoxrange.Controls.Add(Me.rBall)
        Me.GBoxrange.Controls.Add(Me.rBtrading)
        Me.GBoxrange.Controls.Add(Me.rBpurchase)
        Me.GBoxrange.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxrange.ForeColor = System.Drawing.Color.Yellow
        Me.GBoxrange.Location = New System.Drawing.Point(12, 3)
        Me.GBoxrange.Name = "GBoxrange"
        Me.GBoxrange.Size = New System.Drawing.Size(235, 96)
        Me.GBoxrange.TabIndex = 0
        Me.GBoxrange.TabStop = False
        Me.GBoxrange.Text = "Range"
        '
        'rBall
        '
        Me.rBall.AutoSize = True
        Me.rBall.Checked = True
        Me.rBall.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rBall.ForeColor = System.Drawing.Color.Yellow
        Me.rBall.Location = New System.Drawing.Point(6, 70)
        Me.rBall.Name = "rBall"
        Me.rBall.Size = New System.Drawing.Size(39, 17)
        Me.rBall.TabIndex = 3
        Me.rBall.TabStop = True
        Me.rBall.Text = "All"
        Me.rBall.UseVisualStyleBackColor = True
        '
        'rBtrading
        '
        Me.rBtrading.AutoSize = True
        Me.rBtrading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rBtrading.ForeColor = System.Drawing.Color.Yellow
        Me.rBtrading.Location = New System.Drawing.Point(6, 44)
        Me.rBtrading.Name = "rBtrading"
        Me.rBtrading.Size = New System.Drawing.Size(189, 17)
        Me.rBtrading.TabIndex = 2
        Me.rBtrading.Text = "Ready To Use/Trading Items"
        Me.rBtrading.UseVisualStyleBackColor = True
        '
        'rBpurchase
        '
        Me.rBpurchase.AutoSize = True
        Me.rBpurchase.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rBpurchase.ForeColor = System.Drawing.Color.Yellow
        Me.rBpurchase.Location = New System.Drawing.Point(6, 18)
        Me.rBpurchase.Name = "rBpurchase"
        Me.rBpurchase.Size = New System.Drawing.Size(197, 17)
        Me.rBpurchase.TabIndex = 1
        Me.rBpurchase.Text = "Purchase Items(Raw Material)"
        Me.rBpurchase.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 77)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.GBoxaction)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GBoxrange)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GBoxfilter)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.Color.Navy
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.SplitContainer1.Panel2.Controls.Add(Me.ChkBoxAll)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dGAttitm)
        Me.SplitContainer1.Size = New System.Drawing.Size(942, 519)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 27
        '
        'GBoxaction
        '
        Me.GBoxaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GBoxaction.Controls.Add(Me.BtnCncl)
        Me.GBoxaction.Controls.Add(Me.Btndel)
        Me.GBoxaction.Controls.Add(Me.BtnSave)
        Me.GBoxaction.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxaction.ForeColor = System.Drawing.Color.Yellow
        Me.GBoxaction.Location = New System.Drawing.Point(12, 352)
        Me.GBoxaction.Name = "GBoxaction"
        Me.GBoxaction.Size = New System.Drawing.Size(235, 160)
        Me.GBoxaction.TabIndex = 8
        Me.GBoxaction.TabStop = False
        Me.GBoxaction.Text = "Action"
        '
        'BtnCncl
        '
        Me.BtnCncl.BackColor = System.Drawing.Color.Transparent
        Me.BtnCncl.BackgroundImage = CType(resources.GetObject("BtnCncl.BackgroundImage"), System.Drawing.Image)
        Me.BtnCncl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCncl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCncl.ForeColor = System.Drawing.Color.Navy
        Me.BtnCncl.Location = New System.Drawing.Point(9, 108)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(219, 33)
        Me.BtnCncl.TabIndex = 11
        Me.BtnCncl.Text = "&Exit"
        Me.BtnCncl.UseVisualStyleBackColor = False
        '
        'Btndel
        '
        Me.Btndel.BackColor = System.Drawing.Color.Transparent
        Me.Btndel.BackgroundImage = CType(resources.GetObject("Btndel.BackgroundImage"), System.Drawing.Image)
        Me.Btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btndel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btndel.ForeColor = System.Drawing.Color.Navy
        Me.Btndel.Location = New System.Drawing.Point(9, 71)
        Me.Btndel.Name = "Btndel"
        Me.Btndel.Size = New System.Drawing.Size(219, 33)
        Me.Btndel.TabIndex = 10
        Me.Btndel.Text = "&Delete"
        Me.Btndel.UseVisualStyleBackColor = False
        Me.Btndel.Visible = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Navy
        Me.BtnSave.Location = New System.Drawing.Point(9, 30)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(219, 33)
        Me.BtnSave.TabIndex = 9
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'ChkBoxAll
        '
        Me.ChkBoxAll.AutoSize = True
        Me.ChkBoxAll.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBoxAll.ForeColor = System.Drawing.Color.Yellow
        Me.ChkBoxAll.Location = New System.Drawing.Point(6, 492)
        Me.ChkBoxAll.Name = "ChkBoxAll"
        Me.ChkBoxAll.Size = New System.Drawing.Size(45, 20)
        Me.ChkBoxAll.TabIndex = 12
        Me.ChkBoxAll.Text = "All"
        Me.ChkBoxAll.UseVisualStyleBackColor = True
        '
        'dGAttitm
        '
        Me.dGAttitm.AllowUserToAddRows = False
        Me.dGAttitm.AllowUserToDeleteRows = False
        Me.dGAttitm.AllowUserToOrderColumns = True
        Me.dGAttitm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGAttitm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dGAttitm.Location = New System.Drawing.Point(3, 3)
        Me.dGAttitm.Name = "dGAttitm"
        Me.dGAttitm.Size = New System.Drawing.Size(672, 487)
        Me.dGAttitm.TabIndex = 13
        '
        'Column1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.NullValue = False
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "Select Item(s)"
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "Code "
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 160
        '
        'Column3
        '
        Me.Column3.HeaderText = "Item Name"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 275
        '
        'Column4
        '
        Me.Column4.HeaderText = "Type"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 150
        '
        'Column5
        '
        Me.Column5.HeaderText = "Item Id"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        Me.Column5.Width = 5
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 70)
        Me.ContextMenuStrip1.Text = "Save"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem1.Text = "Check All"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Code "
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 160
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Item Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 275
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Item Id"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.ErrorImage = Global.FinAcct.My.Resources.Resources.K4
        Me.PictureBox1.Image = Global.FinAcct.My.Resources.Resources.K31
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(869, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 74)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackgroundImage = Global.FinAcct.My.Resources.Resources.image4
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Location = New System.Drawing.Point(-3, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(945, 75)
        Me.Panel2.TabIndex = 26
        '
        'FrmAttachItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(942, 596)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmAttachItem"
        Me.Text = "Attach Items to an Account"
        Me.GBoxfilter.ResumeLayout(False)
        Me.GBoxfilter.PerformLayout()
        Me.GBoxrange.ResumeLayout(False)
        Me.GBoxrange.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GBoxaction.ResumeLayout(False)
        CType(Me.dGAttitm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GBoxrange As System.Windows.Forms.GroupBox
    Friend WithEvents rBall As System.Windows.Forms.RadioButton
    Friend WithEvents rBtrading As System.Windows.Forms.RadioButton
    Friend WithEvents rBpurchase As System.Windows.Forms.RadioButton
    Friend WithEvents GBoxfilter As System.Windows.Forms.GroupBox
    Friend WithEvents CmbxItmgrp As System.Windows.Forms.ComboBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dGAttitm As System.Windows.Forms.DataGridView
    Friend WithEvents GBoxaction As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents Btndel As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnGo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkItmGrp As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkBoxAll As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class

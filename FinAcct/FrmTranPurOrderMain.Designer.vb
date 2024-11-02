<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTranPurOrderMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTranPurOrderMain))
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.CmbxFltr = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Btnfilter = New System.Windows.Forms.Button
        Me.BtnFind = New System.Windows.Forms.Button
        Me.Btnedit = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.dgOrder = New System.Windows.Forms.DataGridView
        Me.ContxPordr = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContxPordr.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.NavajoWhite
        Me.Panel4.BackgroundImage = Global.FinAcct.My.Resources.Resources._728x90_winning1
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Location = New System.Drawing.Point(-1, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(873, 73)
        Me.Panel4.TabIndex = 28
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 74)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbxFltr)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Btnfilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnFind)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Btnedit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnNew)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.Color.Black
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgOrder)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Size = New System.Drawing.Size(870, 503)
        Me.SplitContainer1.SplitterDistance = 53
        Me.SplitContainer1.TabIndex = 29
        '
        'CmbxFltr
        '
        Me.CmbxFltr.FormattingEnabled = True
        Me.CmbxFltr.Items.AddRange(New Object() {"All", "Completed", "Cancelled", "On Order", "Worksheet"})
        Me.CmbxFltr.Location = New System.Drawing.Point(655, 14)
        Me.CmbxFltr.Name = "CmbxFltr"
        Me.CmbxFltr.Size = New System.Drawing.Size(203, 21)
        Me.CmbxFltr.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(603, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Filter"
        '
        'Btnfilter
        '
        Me.Btnfilter.BackgroundImage = CType(resources.GetObject("Btnfilter.BackgroundImage"), System.Drawing.Image)
        Me.Btnfilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnfilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnfilter.FlatAppearance.BorderSize = 0
        Me.Btnfilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btnfilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnfilter.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnfilter.ForeColor = System.Drawing.Color.Navy
        Me.Btnfilter.Location = New System.Drawing.Point(325, 9)
        Me.Btnfilter.Name = "Btnfilter"
        Me.Btnfilter.Size = New System.Drawing.Size(100, 33)
        Me.Btnfilter.TabIndex = 0
        Me.Btnfilter.Text = "&Refresh"
        Me.Btnfilter.UseVisualStyleBackColor = True
        '
        'BtnFind
        '
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFind.FlatAppearance.BorderSize = 0
        Me.BtnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.ForeColor = System.Drawing.Color.Navy
        Me.BtnFind.Location = New System.Drawing.Point(219, 9)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(100, 33)
        Me.BtnFind.TabIndex = 0
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = True
        '
        'Btnedit
        '
        Me.Btnedit.BackgroundImage = CType(resources.GetObject("Btnedit.BackgroundImage"), System.Drawing.Image)
        Me.Btnedit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnedit.FlatAppearance.BorderSize = 0
        Me.Btnedit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnedit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnedit.ForeColor = System.Drawing.Color.Navy
        Me.Btnedit.Location = New System.Drawing.Point(113, 9)
        Me.Btnedit.Name = "Btnedit"
        Me.Btnedit.Size = New System.Drawing.Size(100, 33)
        Me.Btnedit.TabIndex = 0
        Me.Btnedit.Text = "&Edit"
        Me.Btnedit.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.BackgroundImage = CType(resources.GetObject("BtnNew.BackgroundImage"), System.Drawing.Image)
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNew.FlatAppearance.BorderSize = 0
        Me.BtnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.Navy
        Me.BtnNew.Location = New System.Drawing.Point(7, 9)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(100, 33)
        Me.BtnNew.TabIndex = 0
        Me.BtnNew.Text = "&New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'dgOrder
        '
        Me.dgOrder.AllowUserToAddRows = False
        Me.dgOrder.AllowUserToDeleteRows = False
        Me.dgOrder.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOrder.ContextMenuStrip = Me.ContxPordr
        Me.dgOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgOrder.GridColor = System.Drawing.Color.Navy
        Me.dgOrder.Location = New System.Drawing.Point(0, 0)
        Me.dgOrder.Name = "dgOrder"
        Me.dgOrder.Size = New System.Drawing.Size(868, 444)
        Me.dgOrder.TabIndex = 0
        '
        'ContxPordr
        '
        Me.ContxPordr.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem2, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.ContxPordr.Name = "ContxPordr"
        Me.ContxPordr.Size = New System.Drawing.Size(139, 92)
        Me.ContxPordr.Text = "&File"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItem2.Text = "Edit"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItem1.Text = "Refresh Grid"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'FrmTranPurOrderMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.LightGreen
        Me.ClientSize = New System.Drawing.Size(872, 579)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTranPurOrderMain"
        Me.Text = "Purchase Order"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContxPordr.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Btnfilter As System.Windows.Forms.Button
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents Btnedit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents dgOrder As System.Windows.Forms.DataGridView
    Friend WithEvents ContxPordr As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmbxFltr As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
End Class

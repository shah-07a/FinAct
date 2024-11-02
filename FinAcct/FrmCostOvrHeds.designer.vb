<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCostOvrHeds
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
        Me.components = New System.ComponentModel.Container
        Me.TxtOH = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnExt = New System.Windows.Forms.Button
        Me.BtnFnd = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.LstVewOhFnd = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.TxtDfltVal = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ContxMs1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteSelectedRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContxMs1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtOH
        '
        Me.TxtOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOH.Location = New System.Drawing.Point(136, 12)
        Me.TxtOH.MaxLength = 70
        Me.TxtOH.Name = "TxtOH"
        Me.TxtOH.Size = New System.Drawing.Size(379, 23)
        Me.TxtOH.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Over Head Name"
        '
        'BtnExt
        '
        Me.BtnExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnExt.BackgroundImage = Global.FinAcct.My.Resources.Resources.btn
        Me.BtnExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExt.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExt.Location = New System.Drawing.Point(415, 354)
        Me.BtnExt.Name = "BtnExt"
        Me.BtnExt.Size = New System.Drawing.Size(100, 33)
        Me.BtnExt.TabIndex = 5
        Me.BtnExt.Text = "&Exit"
        Me.BtnExt.UseVisualStyleBackColor = True
        '
        'BtnFnd
        '
        Me.BtnFnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnFnd.BackgroundImage = Global.FinAcct.My.Resources.Resources.btn
        Me.BtnFnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFnd.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFnd.Location = New System.Drawing.Point(215, 354)
        Me.BtnFnd.Name = "BtnFnd"
        Me.BtnFnd.Size = New System.Drawing.Size(100, 33)
        Me.BtnFnd.TabIndex = 4
        Me.BtnFnd.Text = "&Find"
        Me.BtnFnd.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.BackgroundImage = Global.FinAcct.My.Resources.Resources.btn
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(15, 354)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(100, 33)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'LstVewOhFnd
        '
        Me.LstVewOhFnd.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.LstVewOhFnd.ContextMenuStrip = Me.ContxMs1
        Me.LstVewOhFnd.Enabled = False
        Me.LstVewOhFnd.FullRowSelect = True
        Me.LstVewOhFnd.GridLines = True
        Me.LstVewOhFnd.Location = New System.Drawing.Point(539, 12)
        Me.LstVewOhFnd.MultiSelect = False
        Me.LstVewOhFnd.Name = "LstVewOhFnd"
        Me.LstVewOhFnd.ShowItemToolTips = True
        Me.LstVewOhFnd.Size = New System.Drawing.Size(301, 377)
        Me.LstVewOhFnd.TabIndex = 6
        Me.LstVewOhFnd.UseCompatibleStateImageBehavior = False
        Me.LstVewOhFnd.View = System.Windows.Forms.View.Details
        Me.LstVewOhFnd.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Over Head Name"
        Me.ColumnHeader1.Width = 215
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Value"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Head Id"
        Me.ColumnHeader3.Width = 0
        '
        'TxtDfltVal
        '
        Me.TxtDfltVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDfltVal.Location = New System.Drawing.Point(136, 75)
        Me.TxtDfltVal.MaxLength = 14
        Me.TxtDfltVal.Name = "TxtDfltVal"
        Me.TxtDfltVal.Size = New System.Drawing.Size(121, 23)
        Me.TxtDfltVal.TabIndex = 2
        Me.TxtDfltVal.Text = "0"
        Me.TxtDfltVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Default Value"
        '
        'ContxMs1
        '
        Me.ContxMs1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteSelectedRowToolStripMenuItem})
        Me.ContxMs1.Name = "ContxMs1"
        Me.ContxMs1.Size = New System.Drawing.Size(181, 26)
        '
        'DeleteSelectedRowToolStripMenuItem
        '
        Me.DeleteSelectedRowToolStripMenuItem.Name = "DeleteSelectedRowToolStripMenuItem"
        Me.DeleteSelectedRowToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DeleteSelectedRowToolStripMenuItem.Text = "Delete Selected Row"
        '
        'FrmCostOvrHeds
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(849, 399)
        Me.Controls.Add(Me.TxtDfltVal)
        Me.Controls.Add(Me.LstVewOhFnd)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnFnd)
        Me.Controls.Add(Me.BtnExt)
        Me.Controls.Add(Me.TxtOH)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCostOvrHeds"
        Me.Text = "Costing Over Head Master"
        Me.ContxMs1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtOH As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnExt As System.Windows.Forms.Button
    Friend WithEvents BtnFnd As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents LstVewOhFnd As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TxtDfltVal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContxMs1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteSelectedRowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class

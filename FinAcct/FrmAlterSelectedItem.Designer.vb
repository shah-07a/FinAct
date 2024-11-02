<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAlterSelectedItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAlterSelectedItem))
        Me.ItmDg = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Btnok = New System.Windows.Forms.Button
        Me.BtnCncl = New System.Windows.Forms.Button
        CType(Me.ItmDg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ItmDg
        '
        Me.ItmDg.AllowUserToOrderColumns = True
        Me.ItmDg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ItmDg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ItmDg.Location = New System.Drawing.Point(2, 2)
        Me.ItmDg.Name = "ItmDg"
        Me.ItmDg.Size = New System.Drawing.Size(940, 116)
        Me.ItmDg.TabIndex = 18
        Me.ItmDg.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Btnok)
        Me.Panel1.Controls.Add(Me.BtnCncl)
        Me.Panel1.Location = New System.Drawing.Point(2, 120)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(218, 45)
        Me.Panel1.TabIndex = 19
        '
        'Btnok
        '
        Me.Btnok.BackgroundImage = CType(resources.GetObject("Btnok.BackgroundImage"), System.Drawing.Image)
        Me.Btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnok.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnok.Location = New System.Drawing.Point(5, 6)
        Me.Btnok.Name = "Btnok"
        Me.Btnok.Size = New System.Drawing.Size(100, 33)
        Me.Btnok.TabIndex = 0
        Me.Btnok.Text = "&Update"
        Me.Btnok.UseVisualStyleBackColor = True
        '
        'BtnCncl
        '
        Me.BtnCncl.BackgroundImage = CType(resources.GetObject("BtnCncl.BackgroundImage"), System.Drawing.Image)
        Me.BtnCncl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCncl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCncl.Location = New System.Drawing.Point(111, 6)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(100, 33)
        Me.BtnCncl.TabIndex = 0
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'FrmAlterSelectedItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(944, 167)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ItmDg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmAlterSelectedItem"
        Me.Text = "Alter A Selected Item"
        CType(Me.ItmDg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ItmDg As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents Btnok As System.Windows.Forms.Button
End Class

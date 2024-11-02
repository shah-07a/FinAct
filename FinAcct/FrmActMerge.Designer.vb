<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmActMerge
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmActMerge))
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbxAct = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbxAct1 = New System.Windows.Forms.ComboBox
        Me.Btnext = New System.Windows.Forms.Button
        Me.BtnOk = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbxType = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblInfo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 101)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 14)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Account Name"
        '
        'CmbxAct
        '
        Me.CmbxAct.FormattingEnabled = True
        Me.CmbxAct.Location = New System.Drawing.Point(153, 101)
        Me.CmbxAct.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CmbxAct.Name = "CmbxAct"
        Me.CmbxAct.Size = New System.Drawing.Size(435, 22)
        Me.CmbxAct.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 193)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 14)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Merge With Account"
        '
        'CmbxAct1
        '
        Me.CmbxAct1.Enabled = False
        Me.CmbxAct1.FormattingEnabled = True
        Me.CmbxAct1.Location = New System.Drawing.Point(153, 193)
        Me.CmbxAct1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CmbxAct1.Name = "CmbxAct1"
        Me.CmbxAct1.Size = New System.Drawing.Size(435, 22)
        Me.CmbxAct1.TabIndex = 2
        '
        'Btnext
        '
        Me.Btnext.BackColor = System.Drawing.Color.Transparent
        Me.Btnext.BackgroundImage = CType(resources.GetObject("Btnext.BackgroundImage"), System.Drawing.Image)
        Me.Btnext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnext.FlatAppearance.BorderSize = 0
        Me.Btnext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.Btnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnext.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnext.ForeColor = System.Drawing.Color.Navy
        Me.Btnext.Location = New System.Drawing.Point(455, 286)
        Me.Btnext.Name = "Btnext"
        Me.Btnext.Size = New System.Drawing.Size(133, 33)
        Me.Btnext.TabIndex = 4
        Me.Btnext.Text = "&Exit"
        Me.Btnext.UseVisualStyleBackColor = False
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.Color.Transparent
        Me.BtnOk.BackgroundImage = CType(resources.GetObject("BtnOk.BackgroundImage"), System.Drawing.Image)
        Me.BtnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOk.FlatAppearance.BorderSize = 0
        Me.BtnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOk.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.ForeColor = System.Drawing.Color.Navy
        Me.BtnOk.Location = New System.Drawing.Point(316, 286)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(133, 33)
        Me.BtnOk.TabIndex = 3
        Me.BtnOk.Text = "&Ok"
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(150, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(355, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "(Account to be merged with an account selected from below)"
        '
        'CmbxType
        '
        Me.CmbxType.FormattingEnabled = True
        Me.CmbxType.Items.AddRange(New Object() {"Bank", "Cash Book", "Customer/Vendor", "Sales Agent", "General Account        "})
        Me.CmbxType.Location = New System.Drawing.Point(153, 9)
        Me.CmbxType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CmbxType.Name = "CmbxType"
        Me.CmbxType.Size = New System.Drawing.Size(222, 22)
        Me.CmbxType.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 9)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 14)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Type Of Account"
        '
        'LblInfo
        '
        Me.LblInfo.AutoSize = True
        Me.LblInfo.Location = New System.Drawing.Point(150, 54)
        Me.LblInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblInfo.Name = "LblInfo"
        Me.LblInfo.Size = New System.Drawing.Size(26, 14)
        Me.LblInfo.TabIndex = 33
        Me.LblInfo.Text = "?..."
        '
        'FrmActMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 331)
        Me.Controls.Add(Me.LblInfo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.Btnext)
        Me.Controls.Add(Me.CmbxAct1)
        Me.Controls.Add(Me.CmbxType)
        Me.Controls.Add(Me.CmbxAct)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "FrmActMerge"
        Me.Text = "Merge An Account"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbxAct As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbxAct1 As System.Windows.Forms.ComboBox
    Friend WithEvents Btnext As System.Windows.Forms.Button
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbxType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblInfo As System.Windows.Forms.Label
End Class

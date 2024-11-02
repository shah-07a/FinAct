<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVewPrnt_ItmDependencies
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
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnItmVew = New System.Windows.Forms.Button
        Me.Chkinfo = New System.Windows.Forms.CheckBox
        Me.ChkbxAll = New System.Windows.Forms.CheckBox
        Me.CmbxItemVew = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CrRptVewItemDepen = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptVewPrntItemDependency1 = New FinAcct.CrRptVewPrntItemDependency
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackgroundImage = Global.FinAcct.My.Resources.Resources.image4
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Location = New System.Drawing.Point(-1, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(892, 73)
        Me.Panel4.TabIndex = 29
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = Global.FinAcct.My.Resources.Resources.K31
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(819, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnItmVew)
        Me.Panel1.Controls.Add(Me.Chkinfo)
        Me.Panel1.Controls.Add(Me.ChkbxAll)
        Me.Panel1.Controls.Add(Me.CmbxItemVew)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 74)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(889, 58)
        Me.Panel1.TabIndex = 30
        '
        'BtnItmVew
        '
        Me.BtnItmVew.BackgroundImage = Global.FinAcct.My.Resources.Resources.btn
        Me.BtnItmVew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnItmVew.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnItmVew.Location = New System.Drawing.Point(767, 12)
        Me.BtnItmVew.Name = "BtnItmVew"
        Me.BtnItmVew.Size = New System.Drawing.Size(119, 33)
        Me.BtnItmVew.TabIndex = 2
        Me.BtnItmVew.Text = "View Report"
        Me.BtnItmVew.UseVisualStyleBackColor = True
        '
        'Chkinfo
        '
        Me.Chkinfo.AutoSize = True
        Me.Chkinfo.Checked = True
        Me.Chkinfo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chkinfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkinfo.ForeColor = System.Drawing.Color.White
        Me.Chkinfo.Location = New System.Drawing.Point(559, 19)
        Me.Chkinfo.Name = "Chkinfo"
        Me.Chkinfo.Size = New System.Drawing.Size(207, 17)
        Me.Chkinfo.TabIndex = 3
        Me.Chkinfo.Text = "Company Information Required"
        Me.Chkinfo.UseVisualStyleBackColor = True
        '
        'ChkbxAll
        '
        Me.ChkbxAll.AutoSize = True
        Me.ChkbxAll.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkbxAll.ForeColor = System.Drawing.Color.White
        Me.ChkbxAll.Location = New System.Drawing.Point(119, 20)
        Me.ChkbxAll.Name = "ChkbxAll"
        Me.ChkbxAll.Size = New System.Drawing.Size(42, 20)
        Me.ChkbxAll.TabIndex = 2
        Me.ChkbxAll.Text = "All"
        Me.ChkbxAll.UseVisualStyleBackColor = True
        '
        'CmbxItemVew
        '
        Me.CmbxItemVew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxItemVew.FormattingEnabled = True
        Me.CmbxItemVew.Location = New System.Drawing.Point(167, 19)
        Me.CmbxItemVew.Name = "CmbxItemVew"
        Me.CmbxItemVew.Size = New System.Drawing.Size(386, 21)
        Me.CmbxItemVew.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select An Item"
        '
        'CrRptVewItemDepen
        '
        Me.CrRptVewItemDepen.ActiveViewIndex = 0
        Me.CrRptVewItemDepen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewItemDepen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewItemDepen.Location = New System.Drawing.Point(5, 133)
        Me.CrRptVewItemDepen.Name = "CrRptVewItemDepen"
        Me.CrRptVewItemDepen.ReportSource = Me.CrRptVewPrntItemDependency1
        Me.CrRptVewItemDepen.Size = New System.Drawing.Size(886, 0)
        Me.CrRptVewItemDepen.TabIndex = 31
        '
        'FrmVewPrnt_ItmDependencies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(892, 132)
        Me.Controls.Add(Me.CrRptVewItemDepen)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.MaximizeBox = False
        Me.Name = "FrmVewPrnt_ItmDependencies"
        Me.Text = "Check Item Dependencies "
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnItmVew As System.Windows.Forms.Button
    Friend WithEvents CmbxItemVew As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CrRptVewItemDepen As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptVewPrntItemDependency1 As FinAcct.CrRptVewPrntItemDependency
    Friend WithEvents ChkbxAll As System.Windows.Forms.CheckBox
    Friend WithEvents Chkinfo As System.Windows.Forms.CheckBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUtlBillDele
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RbInvVAT = New System.Windows.Forms.RadioButton
        Me.RbInvRetail = New System.Windows.Forms.RadioButton
        Me.CmbxInv = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnDele = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Invoice Type :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbInvRetail)
        Me.GroupBox1.Controls.Add(Me.RbInvVAT)
        Me.GroupBox1.Location = New System.Drawing.Point(123, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(289, 42)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'RbInvVAT
        '
        Me.RbInvVAT.AutoSize = True
        Me.RbInvVAT.Checked = True
        Me.RbInvVAT.Location = New System.Drawing.Point(6, 14)
        Me.RbInvVAT.Name = "RbInvVAT"
        Me.RbInvVAT.Size = New System.Drawing.Size(113, 20)
        Me.RbInvVAT.TabIndex = 0
        Me.RbInvVAT.TabStop = True
        Me.RbInvVAT.Text = "INVOICE VAT"
        Me.RbInvVAT.UseVisualStyleBackColor = True
        '
        'RbInvRetail
        '
        Me.RbInvRetail.AutoSize = True
        Me.RbInvRetail.Location = New System.Drawing.Point(151, 14)
        Me.RbInvRetail.Name = "RbInvRetail"
        Me.RbInvRetail.Size = New System.Drawing.Size(132, 20)
        Me.RbInvRetail.TabIndex = 0
        Me.RbInvRetail.Text = "INVOICE RETAIL"
        Me.RbInvRetail.UseVisualStyleBackColor = True
        '
        'CmbxInv
        '
        Me.CmbxInv.FormattingEnabled = True
        Me.CmbxInv.Location = New System.Drawing.Point(123, 61)
        Me.CmbxInv.Name = "CmbxInv"
        Me.CmbxInv.Size = New System.Drawing.Size(219, 24)
        Me.CmbxInv.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Invoice No. :"
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(279, 217)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(133, 33)
        Me.BtnExit.TabIndex = 3
        Me.BtnExit.Text = "&Exit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'BtnDele
        '
        Me.BtnDele.Location = New System.Drawing.Point(140, 217)
        Me.BtnDele.Name = "BtnDele"
        Me.BtnDele.Size = New System.Drawing.Size(133, 33)
        Me.BtnDele.TabIndex = 3
        Me.BtnDele.Text = "&Delete"
        Me.BtnDele.UseVisualStyleBackColor = True
        '
        'FrmUtlBillDele
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(432, 262)
        Me.Controls.Add(Me.BtnDele)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.CmbxInv)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmUtlBillDele"
        Me.Text = "Sale Bill Category Wise Delete"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbInvRetail As System.Windows.Forms.RadioButton
    Friend WithEvents RbInvVAT As System.Windows.Forms.RadioButton
    Friend WithEvents CmbxInv As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnDele As System.Windows.Forms.Button
End Class

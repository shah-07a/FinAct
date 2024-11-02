<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEsiForm1
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
        Me.CrVewEsiF1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptFrm11 = New FinAcct.CrRptfrm1
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbxEmpname = New System.Windows.Forms.ComboBox
        Me.BtnEsi = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrVewEsiF1
        '
        Me.CrVewEsiF1.ActiveViewIndex = 0
        Me.CrVewEsiF1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEsiF1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEsiF1.Location = New System.Drawing.Point(2, 52)
        Me.CrVewEsiF1.Name = "CrVewEsiF1"
        Me.CrVewEsiF1.ReportSource = Me.CrRptFrm11
        Me.CrVewEsiF1.Size = New System.Drawing.Size(1006, 0)
        Me.CrVewEsiF1.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CmbxEmpname)
        Me.Panel1.Controls.Add(Me.BtnEsi)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1006, 43)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(3, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Select an Employee"
        '
        'CmbxEmpname
        '
        Me.CmbxEmpname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxEmpname.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxEmpname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.CmbxEmpname.FormattingEnabled = True
        Me.CmbxEmpname.Location = New System.Drawing.Point(145, 10)
        Me.CmbxEmpname.Name = "CmbxEmpname"
        Me.CmbxEmpname.Size = New System.Drawing.Size(504, 24)
        Me.CmbxEmpname.TabIndex = 1
        '
        'BtnEsi
        '
        Me.BtnEsi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEsi.Enabled = False
        Me.BtnEsi.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEsi.Location = New System.Drawing.Point(802, 8)
        Me.BtnEsi.Name = "BtnEsi"
        Me.BtnEsi.Size = New System.Drawing.Size(185, 23)
        Me.BtnEsi.TabIndex = 2
        Me.BtnEsi.Text = "View Report"
        Me.BtnEsi.UseVisualStyleBackColor = True
        '
        'FrmCrRptEsiForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 49)
        Me.Controls.Add(Me.CrVewEsiF1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptEsiForm1"
        Me.Text = "FrmCrRptEsiForm1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVewEsiF1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnEsi As System.Windows.Forms.Button
    Friend WithEvents CrRptFrm11 As fINACCT.CrRptFrm1
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbxEmpname As System.Windows.Forms.ComboBox
End Class

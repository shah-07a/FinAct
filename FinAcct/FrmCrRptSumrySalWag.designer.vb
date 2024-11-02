<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptSumrySalWag
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Chkbx1 = New System.Windows.Forms.CheckBox
        Me.DtpSalslip = New System.Windows.Forms.DateTimePicker
        Me.BtnCrptvew = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cmbxselemp = New System.Windows.Forms.ComboBox
        Me.CrVewSumSalWag = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptSumrySalWag1 = New FinAcct.CrRptSumrySalWag
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Chkbx1)
        Me.Panel1.Controls.Add(Me.DtpSalslip)
        Me.Panel1.Controls.Add(Me.BtnCrptvew)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Cmbxselemp)
        Me.Panel1.Location = New System.Drawing.Point(0, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1004, 81)
        Me.Panel1.TabIndex = 0
        '
        'Chkbx1
        '
        Me.Chkbx1.AutoSize = True
        Me.Chkbx1.Location = New System.Drawing.Point(160, 13)
        Me.Chkbx1.Name = "Chkbx1"
        Me.Chkbx1.Size = New System.Drawing.Size(37, 17)
        Me.Chkbx1.TabIndex = 1
        Me.Chkbx1.Text = "All"
        Me.Chkbx1.UseVisualStyleBackColor = True
        '
        'DtpSalslip
        '
        Me.DtpSalslip.CustomFormat = "MMMM/yyyy"
        Me.DtpSalslip.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpSalslip.Location = New System.Drawing.Point(160, 50)
        Me.DtpSalslip.Name = "DtpSalslip"
        Me.DtpSalslip.ShowUpDown = True
        Me.DtpSalslip.Size = New System.Drawing.Size(127, 20)
        Me.DtpSalslip.TabIndex = 3
        '
        'BtnCrptvew
        '
        Me.BtnCrptvew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCrptvew.Location = New System.Drawing.Point(706, 50)
        Me.BtnCrptvew.Name = "BtnCrptvew"
        Me.BtnCrptvew.Size = New System.Drawing.Size(290, 23)
        Me.BtnCrptvew.TabIndex = 4
        Me.BtnCrptvew.Text = "View Report"
        Me.BtnCrptvew.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = " Selection Criteria"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = " Selection Criteria"
        '
        'Cmbxselemp
        '
        Me.Cmbxselemp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmbxselemp.FormattingEnabled = True
        Me.Cmbxselemp.Location = New System.Drawing.Point(203, 13)
        Me.Cmbxselemp.Name = "Cmbxselemp"
        Me.Cmbxselemp.Size = New System.Drawing.Size(793, 21)
        Me.Cmbxselemp.Sorted = True
        Me.Cmbxselemp.TabIndex = 2
        '
        'CrVewSumSalWag
        '
        Me.CrVewSumSalWag.ActiveViewIndex = 0
        Me.CrVewSumSalWag.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewSumSalWag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewSumSalWag.Location = New System.Drawing.Point(0, 89)
        Me.CrVewSumSalWag.Name = "CrVewSumSalWag"
        Me.CrVewSumSalWag.ReportSource = Me.CrRptSumrySalWag1
        Me.CrVewSumSalWag.Size = New System.Drawing.Size(1004, 0)
        Me.CrVewSumSalWag.TabIndex = 0
        '
        'FrmCrRptSumrySalWag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 89)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrVewSumSalWag)
        Me.Name = "FrmCrRptSumrySalWag"
        Me.Text = "FrmCrRptSumrySalWag"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVewSumSalWag As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptSumrySalWag1 As fINACCT.CrRptSumrySalWag
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Chkbx1 As System.Windows.Forms.CheckBox
    Friend WithEvents DtpSalslip As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnCrptvew As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmbxselemp As System.Windows.Forms.ComboBox
End Class

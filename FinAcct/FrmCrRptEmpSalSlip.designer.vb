<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEmpSalSlip
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
        Me.CrVewSalSlip = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptSalSlip2 = New FinAcct.CrRptSalSlip
        Me.CrRptSalSlip1 = New FinAcct.CrRptSalSlip
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
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1003, 72)
        Me.Panel1.TabIndex = 0
        '
        'Chkbx1
        '
        Me.Chkbx1.AutoSize = True
        Me.Chkbx1.Location = New System.Drawing.Point(160, 9)
        Me.Chkbx1.Name = "Chkbx1"
        Me.Chkbx1.Size = New System.Drawing.Size(40, 17)
        Me.Chkbx1.TabIndex = 1
        Me.Chkbx1.Text = "All"
        Me.Chkbx1.UseVisualStyleBackColor = True
        '
        'DtpSalslip
        '
        Me.DtpSalslip.CustomFormat = "MMMM/yyyy"
        Me.DtpSalslip.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpSalslip.Location = New System.Drawing.Point(160, 40)
        Me.DtpSalslip.Name = "DtpSalslip"
        Me.DtpSalslip.ShowUpDown = True
        Me.DtpSalslip.Size = New System.Drawing.Size(127, 21)
        Me.DtpSalslip.TabIndex = 3
        '
        'BtnCrptvew
        '
        Me.BtnCrptvew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCrptvew.Location = New System.Drawing.Point(625, 40)
        Me.BtnCrptvew.Name = "BtnCrptvew"
        Me.BtnCrptvew.Size = New System.Drawing.Size(358, 23)
        Me.BtnCrptvew.TabIndex = 4
        Me.BtnCrptvew.Text = "View Report"
        Me.BtnCrptvew.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = " Selection Criteria"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = " Selection Criteria"
        '
        'Cmbxselemp
        '
        Me.Cmbxselemp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmbxselemp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxselemp.FormattingEnabled = True
        Me.Cmbxselemp.Location = New System.Drawing.Point(203, 9)
        Me.Cmbxselemp.Name = "Cmbxselemp"
        Me.Cmbxselemp.Size = New System.Drawing.Size(780, 21)
        Me.Cmbxselemp.Sorted = True
        Me.Cmbxselemp.TabIndex = 2
        '
        'CrVewSalSlip
        '
        Me.CrVewSalSlip.ActiveViewIndex = 0
        Me.CrVewSalSlip.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewSalSlip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewSalSlip.Location = New System.Drawing.Point(3, 81)
        Me.CrVewSalSlip.Name = "CrVewSalSlip"
        Me.CrVewSalSlip.ReportSource = Me.CrRptSalSlip2
        Me.CrVewSalSlip.Size = New System.Drawing.Size(1003, 0)
        Me.CrVewSalSlip.TabIndex = 4
        '
        'FrmCrRptEmpSalSlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 79)
        Me.Controls.Add(Me.CrVewSalSlip)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.Name = "FrmCrRptEmpSalSlip"
        Me.Text = "Employee's Salary/Wages Slip "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmbxselemp As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnCrptvew As System.Windows.Forms.Button
    Friend WithEvents CrVewSalSlip As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DtpSalslip As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrRptSalSlip1 As fINACCT.CrRptSalSlip
    Friend WithEvents CrRptSalSlip2 As fINACCT.CrRptSalSlip
    Friend WithEvents Chkbx1 As System.Windows.Forms.CheckBox
    'Friend WithEvents CrRptEmpPersonal1 As fINACCT.CrRptEmpPersonal
End Class

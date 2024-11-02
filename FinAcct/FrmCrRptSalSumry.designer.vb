<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptSalSumry
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
        Me.CrVewSalSumry = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptSalSumry2 = New FinAcct.CrRptSalSumry
        Me.CrRptSalSumry1 = New FinAcct.CrRptSalSumry
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Chkbx1 = New System.Windows.Forms.CheckBox
        Me.DtpSalslip = New System.Windows.Forms.DateTimePicker
        Me.BtnCrptvew = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cmbxselemp = New System.Windows.Forms.ComboBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrVewSalSumry
        '
        Me.CrVewSalSumry.ActiveViewIndex = 0
        Me.CrVewSalSumry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewSalSumry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewSalSumry.Location = New System.Drawing.Point(6, 79)
        Me.CrVewSalSumry.Name = "CrVewSalSumry"
        Me.CrVewSalSumry.ReportSource = Me.CrRptSalSumry2
        Me.CrVewSalSumry.ShowRefreshButton = False
        Me.CrVewSalSumry.Size = New System.Drawing.Size(876, 0)
        Me.CrVewSalSumry.TabIndex = 0
        Me.CrVewSalSumry.Visible = False
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
        Me.Panel1.Location = New System.Drawing.Point(6, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(876, 71)
        Me.Panel1.TabIndex = 0
        '
        'Chkbx1
        '
        Me.Chkbx1.AutoSize = True
        Me.Chkbx1.Checked = True
        Me.Chkbx1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chkbx1.Enabled = False
        Me.Chkbx1.Location = New System.Drawing.Point(160, 7)
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
        Me.DtpSalslip.Location = New System.Drawing.Point(160, 39)
        Me.DtpSalslip.Name = "DtpSalslip"
        Me.DtpSalslip.ShowUpDown = True
        Me.DtpSalslip.Size = New System.Drawing.Size(127, 20)
        Me.DtpSalslip.TabIndex = 3
        '
        'BtnCrptvew
        '
        Me.BtnCrptvew.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCrptvew.Location = New System.Drawing.Point(708, 38)
        Me.BtnCrptvew.Name = "BtnCrptvew"
        Me.BtnCrptvew.Size = New System.Drawing.Size(144, 25)
        Me.BtnCrptvew.TabIndex = 4
        Me.BtnCrptvew.Text = "View Report"
        Me.BtnCrptvew.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = " Selection Criteria"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = " Selection Criteria"
        '
        'Cmbxselemp
        '
        Me.Cmbxselemp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmbxselemp.Enabled = False
        Me.Cmbxselemp.FormattingEnabled = True
        Me.Cmbxselemp.Location = New System.Drawing.Point(203, 7)
        Me.Cmbxselemp.Name = "Cmbxselemp"
        Me.Cmbxselemp.Size = New System.Drawing.Size(649, 21)
        Me.Cmbxselemp.Sorted = True
        Me.Cmbxselemp.TabIndex = 2
        '
        'FrmCrRptSalSumry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(884, 73)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrVewSalSumry)
        Me.Name = "FrmCrRptSalSumry"
        Me.Text = "FrmCrRptSalSumry"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVewSalSumry As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptSalSumry1 As fINACCT.CrRptSalSumry
    Friend WithEvents CrRptSalSumry2 As fINACCT.CrRptSalSumry
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Chkbx1 As System.Windows.Forms.CheckBox
    Friend WithEvents DtpSalslip As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnCrptvew As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmbxselemp As System.Windows.Forms.ComboBox
End Class

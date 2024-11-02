<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptForm10
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
        Me.TxtAcNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnEPF10 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.CrVewEpFFrm10 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptEpFform101 = New FinAcct.CrRptEpFform10
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtAcNo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.BtnEPF10)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1007, 48)
        Me.Panel1.TabIndex = 0
        '
        'TxtAcNo
        '
        Me.TxtAcNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAcNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcNo.Location = New System.Drawing.Point(498, 12)
        Me.TxtAcNo.MaxLength = 6
        Me.TxtAcNo.Name = "TxtAcNo"
        Me.TxtAcNo.Size = New System.Drawing.Size(152, 22)
        Me.TxtAcNo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(351, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 18)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Account Group No. :"
        '
        'BtnEPF10
        '
        Me.BtnEPF10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEPF10.Location = New System.Drawing.Point(759, 12)
        Me.BtnEPF10.Name = "BtnEPF10"
        Me.BtnEPF10.Size = New System.Drawing.Size(235, 23)
        Me.BtnEPF10.TabIndex = 3
        Me.BtnEPF10.Text = "View Report"
        Me.BtnEPF10.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Return For The Month"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "MMMM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(165, 12)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.ShowUpDown = True
        Me.Dtpick1.Size = New System.Drawing.Size(134, 20)
        Me.Dtpick1.TabIndex = 1
        '
        'CrVewEpFFrm10
        '
        Me.CrVewEpFFrm10.ActiveViewIndex = 0
        Me.CrVewEpFFrm10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEpFFrm10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEpFFrm10.DisplayGroupTree = False
        Me.CrVewEpFFrm10.Enabled = False
        Me.CrVewEpFFrm10.Location = New System.Drawing.Point(2, 55)
        Me.CrVewEpFFrm10.Name = "CrVewEpFFrm10"
        Me.CrVewEpFFrm10.ReportSource = Me.CrRptEpFform101
        Me.CrVewEpFFrm10.ShowGroupTreeButton = False
        Me.CrVewEpFFrm10.ShowRefreshButton = False
        Me.CrVewEpFFrm10.Size = New System.Drawing.Size(1007, 0)
        Me.CrVewEpFFrm10.TabIndex = 3
        '
        'FrmCrRptForm10
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 53)
        Me.Controls.Add(Me.CrVewEpFFrm10)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptForm10"
        Me.Text = "EPF (Form No. 10)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtAcNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnEPF10 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrVewEpFFrm10 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptEpFform101 As fINACCT.CrRptEpFform10
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEpfFrm2
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
        Me.BtnEPF2 = New System.Windows.Forms.Button
        Me.CmbxEpfEmpname = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.CrVewEpfFrm2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptFrm21 = New FinAcct.CrRptFrm2
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnEPF2)
        Me.Panel1.Controls.Add(Me.CmbxEpfEmpname)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1002, 38)
        Me.Panel1.TabIndex = 0
        '
        'BtnEPF2
        '
        Me.BtnEPF2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEPF2.Location = New System.Drawing.Point(878, 8)
        Me.BtnEPF2.Name = "BtnEPF2"
        Me.BtnEPF2.Size = New System.Drawing.Size(114, 23)
        Me.BtnEPF2.TabIndex = 3
        Me.BtnEPF2.Text = "View Report"
        Me.BtnEPF2.UseVisualStyleBackColor = True
        '
        'CmbxEpfEmpname
        '
        Me.CmbxEpfEmpname.FormattingEnabled = True
        Me.CmbxEpfEmpname.Location = New System.Drawing.Point(147, 8)
        Me.CmbxEpfEmpname.Name = "CmbxEpfEmpname"
        Me.CmbxEpfEmpname.Size = New System.Drawing.Size(365, 21)
        Me.CmbxEpfEmpname.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 18)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Employee's  Name :-"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(518, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Date :-"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(573, 8)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.Size = New System.Drawing.Size(174, 20)
        Me.Dtpick1.TabIndex = 2
        '
        'CrVewEpfFrm2
        '
        Me.CrVewEpfFrm2.ActiveViewIndex = 0
        Me.CrVewEpfFrm2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEpfFrm2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEpfFrm2.DisplayGroupTree = False
        Me.CrVewEpfFrm2.Enabled = False
        Me.CrVewEpfFrm2.Location = New System.Drawing.Point(4, 48)
        Me.CrVewEpfFrm2.Name = "CrVewEpfFrm2"
        Me.CrVewEpfFrm2.ReportSource = Me.CrRptFrm21
        Me.CrVewEpfFrm2.ShowGroupTreeButton = False
        Me.CrVewEpfFrm2.ShowRefreshButton = False
        Me.CrVewEpfFrm2.Size = New System.Drawing.Size(1002, 0)
        Me.CrVewEpfFrm2.TabIndex = 2
        '
        'FrmCrRptEpfFrm2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 46)
        Me.Controls.Add(Me.CrVewEpfFrm2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptEpfFrm2"
        Me.Text = "EPF FORM -2 (Revised)"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnEPF2 As System.Windows.Forms.Button
    Friend WithEvents CmbxEpfEmpname As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrVewEpfFrm2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptFrm21 As fINACCT.CrRptFrm2
End Class

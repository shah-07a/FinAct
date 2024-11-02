<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEPFfrm6A
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
        Me.BtnEPF = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.CrVewEpF6a = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptEPFform6_A1 = New FinAcct.CrRptEPFform6_A
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
        Me.Panel1.Controls.Add(Me.BtnEPF)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Controls.Add(Me.dtpick2)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1003, 42)
        Me.Panel1.TabIndex = 0
        '
        'TxtAcNo
        '
        Me.TxtAcNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAcNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcNo.Location = New System.Drawing.Point(662, 10)
        Me.TxtAcNo.MaxLength = 6
        Me.TxtAcNo.Name = "TxtAcNo"
        Me.TxtAcNo.Size = New System.Drawing.Size(158, 22)
        Me.TxtAcNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(514, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 18)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Account Group No. :"
        '
        'BtnEPF
        '
        Me.BtnEPF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEPF.Location = New System.Drawing.Point(857, 10)
        Me.BtnEPF.Name = "BtnEPF"
        Me.BtnEPF.Size = New System.Drawing.Size(134, 23)
        Me.BtnEPF.TabIndex = 4
        Me.BtnEPF.Text = "View Report"
        Me.BtnEPF.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(272, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 18)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "To Month"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "From Month"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "MMMM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(105, 10)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.ShowUpDown = True
        Me.Dtpick1.Size = New System.Drawing.Size(143, 21)
        Me.Dtpick1.TabIndex = 1
        '
        'dtpick2
        '
        Me.dtpick2.CustomFormat = "MMMM/yyyy"
        Me.dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpick2.Location = New System.Drawing.Point(353, 10)
        Me.dtpick2.Name = "dtpick2"
        Me.dtpick2.ShowUpDown = True
        Me.dtpick2.Size = New System.Drawing.Size(143, 21)
        Me.dtpick2.TabIndex = 2
        '
        'CrVewEpF6a
        '
        Me.CrVewEpF6a.ActiveViewIndex = 0
        Me.CrVewEpF6a.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEpF6a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEpF6a.DisplayGroupTree = False
        Me.CrVewEpF6a.Location = New System.Drawing.Point(3, 52)
        Me.CrVewEpF6a.Name = "CrVewEpF6a"
        Me.CrVewEpF6a.ReportSource = Me.CrRptEPFform6_A1
        Me.CrVewEpF6a.ShowRefreshButton = False
        Me.CrVewEpF6a.Size = New System.Drawing.Size(1005, 0)
        Me.CrVewEpF6a.TabIndex = 3
        '
        'FrmCrRptEPFfrm6A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 47)
        Me.Controls.Add(Me.CrVewEpF6a)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptEPFfrm6A"
        Me.Text = "EPF FORM 6-A (Revised)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnEPF As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrVewEpF6a As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptEPFform6_A1 As fINACCT.CrRptEPFform6_A
    Friend WithEvents TxtAcNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class

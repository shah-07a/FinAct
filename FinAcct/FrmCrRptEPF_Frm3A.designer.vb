<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEPF_Frm3A
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
        Me.CmbxEpfEmpname = New System.Windows.Forms.ComboBox
        Me.TxtAcNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnEPF3a = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.CrVewEpfFrm3a = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptEpFfrm3_A1 = New FinAcct.CrRptEpFfrm3_A
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CmbxEpfEmpname)
        Me.Panel1.Controls.Add(Me.TxtAcNo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.BtnEPF3a)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Controls.Add(Me.dtpick2)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1004, 74)
        Me.Panel1.TabIndex = 0
        '
        'CmbxEpfEmpname
        '
        Me.CmbxEpfEmpname.FormattingEnabled = True
        Me.CmbxEpfEmpname.Location = New System.Drawing.Point(124, 46)
        Me.CmbxEpfEmpname.Name = "CmbxEpfEmpname"
        Me.CmbxEpfEmpname.Size = New System.Drawing.Size(473, 21)
        Me.CmbxEpfEmpname.TabIndex = 4
        '
        'TxtAcNo
        '
        Me.TxtAcNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAcNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcNo.Location = New System.Drawing.Point(882, 11)
        Me.TxtAcNo.MaxLength = 6
        Me.TxtAcNo.Name = "TxtAcNo"
        Me.TxtAcNo.Size = New System.Drawing.Size(117, 22)
        Me.TxtAcNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(740, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 18)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Account Group No. :"
        '
        'BtnEPF3a
        '
        Me.BtnEPF3a.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEPF3a.Location = New System.Drawing.Point(751, 46)
        Me.BtnEPF3a.Name = "BtnEPF3a"
        Me.BtnEPF3a.Size = New System.Drawing.Size(248, 23)
        Me.BtnEPF3a.TabIndex = 5
        Me.BtnEPF3a.Text = "View Report"
        Me.BtnEPF3a.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(361, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 18)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "To Month"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 18)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Employee Name"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "From Month"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "MMMM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(124, 11)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.ShowUpDown = True
        Me.Dtpick1.Size = New System.Drawing.Size(114, 21)
        Me.Dtpick1.TabIndex = 1
        '
        'dtpick2
        '
        Me.dtpick2.CustomFormat = "MMMM/yyyy"
        Me.dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpick2.Location = New System.Drawing.Point(436, 11)
        Me.dtpick2.Name = "dtpick2"
        Me.dtpick2.ShowUpDown = True
        Me.dtpick2.Size = New System.Drawing.Size(151, 21)
        Me.dtpick2.TabIndex = 2
        '
        'CrVewEpfFrm3a
        '
        Me.CrVewEpfFrm3a.ActiveViewIndex = 0
        Me.CrVewEpfFrm3a.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEpfFrm3a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEpfFrm3a.DisplayGroupTree = False
        Me.CrVewEpfFrm3a.Enabled = False
        Me.CrVewEpfFrm3a.Location = New System.Drawing.Point(2, 82)
        Me.CrVewEpfFrm3a.Name = "CrVewEpfFrm3a"
        Me.CrVewEpfFrm3a.ReportSource = Me.CrRptEpFfrm3_A1
        Me.CrVewEpfFrm3a.ShowRefreshButton = False
        Me.CrVewEpfFrm3a.Size = New System.Drawing.Size(1004, 0)
        Me.CrVewEpfFrm3a.TabIndex = 5
        '
        'FrmCrRptEPF_Frm3A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 80)
        Me.Controls.Add(Me.CrVewEpfFrm3a)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptEPF_Frm3A"
        Me.Text = "EPF Form 3-A (Revised)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtAcNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnEPF3a As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrVewEpfFrm3a As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptEpFfrm3_A1 As fINACCT.CrRptEpFfrm3_A
    Friend WithEvents CmbxEpfEmpname As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

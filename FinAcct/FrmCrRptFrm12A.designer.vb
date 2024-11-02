<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptFrm12A
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
        Me.dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.Dtpick3 = New System.Windows.Forms.DateTimePicker
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnEPF12A = New System.Windows.Forms.Button
        Me.Txtacno = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.CrVewEPFfrm112A = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptEPFfrm12A1 = New FinAcct.CrRptEPFfrm12A
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpick2
        '
        Me.dtpick2.CustomFormat = "dd/MM/yyyy"
        Me.dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpick2.Location = New System.Drawing.Point(324, 11)
        Me.dtpick2.Name = "dtpick2"
        Me.dtpick2.Size = New System.Drawing.Size(111, 21)
        Me.dtpick2.TabIndex = 2
        '
        'Dtpick3
        '
        Me.Dtpick3.CustomFormat = "MMMM-yyyy"
        Me.Dtpick3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick3.Location = New System.Drawing.Point(591, 9)
        Me.Dtpick3.Name = "Dtpick3"
        Me.Dtpick3.ShowUpDown = True
        Me.Dtpick3.Size = New System.Drawing.Size(142, 21)
        Me.Dtpick3.TabIndex = 3
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(178, 11)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.Size = New System.Drawing.Size(111, 21)
        Me.Dtpick1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Currency Period From :-"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(294, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 18)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "To"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(440, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 18)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Contribution Month :-"
        '
        'BtnEPF12A
        '
        Me.BtnEPF12A.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEPF12A.Location = New System.Drawing.Point(915, 5)
        Me.BtnEPF12A.Name = "BtnEPF12A"
        Me.BtnEPF12A.Size = New System.Drawing.Size(85, 27)
        Me.BtnEPF12A.TabIndex = 5
        Me.BtnEPF12A.Text = "View Report"
        Me.BtnEPF12A.UseVisualStyleBackColor = True
        '
        'Txtacno
        '
        Me.Txtacno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtacno.Location = New System.Drawing.Point(846, 8)
        Me.Txtacno.Name = "Txtacno"
        Me.Txtacno.Size = New System.Drawing.Size(57, 21)
        Me.Txtacno.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Txtacno)
        Me.Panel1.Controls.Add(Me.BtnEPF12A)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Controls.Add(Me.Dtpick3)
        Me.Panel1.Controls.Add(Me.dtpick2)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 41)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(737, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 18)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Group Sec. No."
        '
        'CrVewEPFfrm112A
        '
        Me.CrVewEPFfrm112A.ActiveViewIndex = 0
        Me.CrVewEPFfrm112A.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEPFfrm112A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEPFfrm112A.DisplayGroupTree = False
        Me.CrVewEPFfrm112A.Enabled = False
        Me.CrVewEPFfrm112A.Location = New System.Drawing.Point(1, 49)
        Me.CrVewEPFfrm112A.Name = "CrVewEPFfrm112A"
        Me.CrVewEPFfrm112A.ReportSource = Me.CrRptEPFfrm12A1
        Me.CrVewEPFfrm112A.ShowGroupTreeButton = False
        Me.CrVewEPFfrm112A.ShowRefreshButton = False
        Me.CrVewEPFfrm112A.Size = New System.Drawing.Size(1008, 0)
        Me.CrVewEPFfrm112A.TabIndex = 5
        '
        'FrmCrRptFrm12A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 47)
        Me.Controls.Add(Me.CrVewEPFfrm112A)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptFrm12A"
        Me.Text = "EPF FORM 12-A (Revised)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVewEPFfrm112A As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptEPFfrm12A1 As fINACCT.CrRptEPFfrm12A
    Friend WithEvents dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtpick3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnEPF12A As System.Windows.Forms.Button
    Friend WithEvents Txtacno As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

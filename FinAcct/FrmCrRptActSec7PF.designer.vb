<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptActSec7PF
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
        Me.TxtSectn = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnEsiGo = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.CrVewPFActSec = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptActSec071 = New FinAcct.CrRptActSec07
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtSectn)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.BtnEsiGo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Controls.Add(Me.dtpick2)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1001, 41)
        Me.Panel1.TabIndex = 0
        '
        'TxtSectn
        '
        Me.TxtSectn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSectn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSectn.Location = New System.Drawing.Point(707, 6)
        Me.TxtSectn.MaxLength = 6
        Me.TxtSectn.Name = "TxtSectn"
        Me.TxtSectn.Size = New System.Drawing.Size(149, 22)
        Me.TxtSectn.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(641, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Section"
        '
        'BtnEsiGo
        '
        Me.BtnEsiGo.Location = New System.Drawing.Point(919, 6)
        Me.BtnEsiGo.Name = "BtnEsiGo"
        Me.BtnEsiGo.Size = New System.Drawing.Size(74, 23)
        Me.BtnEsiGo.TabIndex = 3
        Me.BtnEsiGo.Text = "<Go>"
        Me.BtnEsiGo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(225, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(218, 18)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "EPF Return For The Month :-"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 18)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Date :-"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(56, 6)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.ShowUpDown = True
        Me.Dtpick1.Size = New System.Drawing.Size(123, 23)
        Me.Dtpick1.TabIndex = 0
        '
        'dtpick2
        '
        Me.dtpick2.CustomFormat = "MMMM-yyyy"
        Me.dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpick2.Location = New System.Drawing.Point(449, 6)
        Me.dtpick2.Name = "dtpick2"
        Me.dtpick2.ShowUpDown = True
        Me.dtpick2.Size = New System.Drawing.Size(123, 23)
        Me.dtpick2.TabIndex = 1
        '
        'CrVewPFActSec
        '
        Me.CrVewPFActSec.ActiveViewIndex = 0
        Me.CrVewPFActSec.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewPFActSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewPFActSec.DisplayGroupTree = False
        Me.CrVewPFActSec.Enabled = False
        Me.CrVewPFActSec.Location = New System.Drawing.Point(3, 50)
        Me.CrVewPFActSec.Name = "CrVewPFActSec"
        Me.CrVewPFActSec.ReportSource = Me.CrRptActSec071
        Me.CrVewPFActSec.ShowRefreshButton = False
        Me.CrVewPFActSec.Size = New System.Drawing.Size(1001, 0)
        Me.CrVewPFActSec.TabIndex = 4
        '
        'FrmCrRptActSec7PF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 49)
        Me.Controls.Add(Me.CrVewPFActSec)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptActSec7PF"
        Me.Text = "Account Section 07 (Cover Letter For Monthly Return Of EPF)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnEsiGo As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrVewPFActSec As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptActSec071 As FinAcct.CrRptActSec07
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSectn As System.Windows.Forms.TextBox
End Class

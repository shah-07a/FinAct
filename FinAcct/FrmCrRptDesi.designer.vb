<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptdesi
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
        Me.CrVewdesi = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptDesi1 = New FinAcct.CrRptDesi
        Me.SuspendLayout()
        '
        'CrVewdesi
        '
        Me.CrVewdesi.ActiveViewIndex = 0
        Me.CrVewdesi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewdesi.DisplayGroupTree = False
        Me.CrVewdesi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrVewdesi.Location = New System.Drawing.Point(0, 0)
        Me.CrVewdesi.Name = "CrVewdesi"
        Me.CrVewdesi.ReportSource = Me.CrRptDesi1
        Me.CrVewdesi.Size = New System.Drawing.Size(880, 0)
        Me.CrVewdesi.TabIndex = 0
        '
        'FrmCrRptdesi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 0)
        Me.Controls.Add(Me.CrVewdesi)
        Me.Name = "FrmCrRptdesi"
        Me.Text = "FrmCrRptDesi"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVewdesi As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptDesi1 As fINACCT.CrRptDesi
End Class

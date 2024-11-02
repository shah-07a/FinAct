<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptcsciner
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
        Me.CrVewiner = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRprCsCIner1 = New FinAcct.CrRprCsCIner
        Me.SuspendLayout()
        '
        'CrVewiner
        '
        Me.CrVewiner.ActiveViewIndex = 0
        Me.CrVewiner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewiner.DisplayGroupTree = False
        Me.CrVewiner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrVewiner.Location = New System.Drawing.Point(0, 0)
        Me.CrVewiner.Name = "CrVewiner"
        Me.CrVewiner.ReportSource = Me.CrRprCsCIner1
        Me.CrVewiner.Size = New System.Drawing.Size(880, 0)
        Me.CrVewiner.TabIndex = 0
        '
        'FrmCrRptcsciner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 0)
        Me.Controls.Add(Me.CrVewiner)
        Me.Name = "FrmCrRptcsciner"
        Me.Text = "FrmCrRptCscIner"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVewiner As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRprCsCIner1 As fINACCT.CrRprCsCIner
End Class

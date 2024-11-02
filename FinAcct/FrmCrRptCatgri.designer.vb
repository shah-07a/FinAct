<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptCatgri
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
        Me.CrVewCatgri = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptCatgri1 = New FinAcct.CrRptCatgri
        Me.SuspendLayout()
        '
        'CrVewCatgri
        '
        Me.CrVewCatgri.ActiveViewIndex = 0
        Me.CrVewCatgri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewCatgri.DisplayGroupTree = False
        Me.CrVewCatgri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrVewCatgri.Location = New System.Drawing.Point(0, 0)
        Me.CrVewCatgri.Name = "CrVewCatgri"
        Me.CrVewCatgri.ReportSource = Me.CrRptCatgri1
        Me.CrVewCatgri.Size = New System.Drawing.Size(880, 0)
        Me.CrVewCatgri.TabIndex = 0
        '
        'FrmCrRptCatgri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 0)
        Me.Controls.Add(Me.CrVewCatgri)
        Me.Name = "FrmCrRptCatgri"
        Me.Text = "FrmCrRptCatgri"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVewCatgri As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptCatgri1 As fINACCT.CrRptCatgri
End Class

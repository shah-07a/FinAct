<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptbrnch
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
        Me.CrVewBrnch = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptBrnch1 = New FinAcct.CrRptBrnch
        Me.SuspendLayout()
        '
        'CrVewBrnch
        '
        Me.CrVewBrnch.ActiveViewIndex = 0
        Me.CrVewBrnch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewBrnch.DisplayGroupTree = False
        Me.CrVewBrnch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrVewBrnch.Location = New System.Drawing.Point(0, 0)
        Me.CrVewBrnch.Name = "CrVewBrnch"
        Me.CrVewBrnch.ReportSource = Me.CrRptBrnch1
        Me.CrVewBrnch.Size = New System.Drawing.Size(880, 0)
        Me.CrVewBrnch.TabIndex = 0
        '
        'FrmCrRptbrnch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 0)
        Me.Controls.Add(Me.CrVewBrnch)
        Me.Name = "FrmCrRptbrnch"
        Me.Text = "FrmCrRptBrnch"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVewBrnch As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptBrnch1 As FinAcct.CrRptBrnch
End Class

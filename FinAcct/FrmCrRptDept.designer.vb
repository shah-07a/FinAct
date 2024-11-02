<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptDept
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
        Me.CrVew1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptAdept1 = New FinAcct.CrRptAdept
        Me.SuspendLayout()
        '
        'CrVew1
        '
        Me.CrVew1.ActiveViewIndex = 0
        Me.CrVew1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVew1.DisplayGroupTree = False
        Me.CrVew1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrVew1.Location = New System.Drawing.Point(0, 0)
        Me.CrVew1.Name = "CrVew1"
        Me.CrVew1.ReportSource = Me.CrRptAdept1
        Me.CrVew1.Size = New System.Drawing.Size(243, 0)
        Me.CrVew1.TabIndex = 0
        '
        'FrmCrRptDept
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(243, 0)
        Me.Controls.Add(Me.CrVew1)
        Me.Name = "FrmCrRptDept"
        Me.Text = "List Of Deparments"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVew1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptAdept1 As fINACCT.CrRptAdept
End Class

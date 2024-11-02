<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptwrkname
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
        Me.CrVewWrk = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptWrkname1 = New FinAcct.CrRptWrkname
        Me.SuspendLayout()
        '
        'CrVewWrk
        '
        Me.CrVewWrk.ActiveViewIndex = 0
        Me.CrVewWrk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewWrk.DisplayGroupTree = False
        Me.CrVewWrk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrVewWrk.Location = New System.Drawing.Point(0, 0)
        Me.CrVewWrk.Name = "CrVewWrk"
        Me.CrVewWrk.ReportSource = Me.CrRptWrkname1
        Me.CrVewWrk.Size = New System.Drawing.Size(880, 0)
        Me.CrVewWrk.TabIndex = 0
        '
        'FrmCrRptwrkname
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 0)
        Me.Controls.Add(Me.CrVewWrk)
        Me.Name = "FrmCrRptwrkname"
        Me.Text = "FrmCrRptWrkname"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVewWrk As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptWrkname1 As fINACCT.CrRptWrkname
End Class

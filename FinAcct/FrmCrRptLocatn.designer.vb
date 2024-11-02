<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptlocatn
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
        Me.CrVewcsc = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptLocatn1 = New FinAcct.CrRptLocatn
        Me.SuspendLayout()
        '
        'CrVewcsc
        '
        Me.CrVewcsc.ActiveViewIndex = 0
        Me.CrVewcsc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewcsc.DisplayGroupTree = False
        Me.CrVewcsc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrVewcsc.Location = New System.Drawing.Point(0, 0)
        Me.CrVewcsc.Name = "CrVewcsc"
        Me.CrVewcsc.ReportSource = Me.CrRptLocatn1
        Me.CrVewcsc.Size = New System.Drawing.Size(880, 207)
        Me.CrVewcsc.TabIndex = 0
        '
        'FrmCrRptlocatn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 207)
        Me.Controls.Add(Me.CrVewcsc)
        Me.Name = "FrmCrRptlocatn"
        Me.Text = "Outer Location Master"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVewcsc As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptLocatn1 As fINACCT.CrRptLocatn
End Class

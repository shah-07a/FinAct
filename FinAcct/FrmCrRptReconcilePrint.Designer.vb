<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptReconcilePrint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CrRptVewBnkRecon = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptBnkReconcile1 = New FinAcct.CrRptBnkReconcile
        Me.SuspendLayout()
        '
        'CrRptVewBnkRecon
        '
        Me.CrRptVewBnkRecon.ActiveViewIndex = 0
        Me.CrRptVewBnkRecon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewBnkRecon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrRptVewBnkRecon.Location = New System.Drawing.Point(0, 0)
        Me.CrRptVewBnkRecon.Name = "CrRptVewBnkRecon"
        Me.CrRptVewBnkRecon.ReportSource = Me.CrRptBnkReconcile1
        Me.CrRptVewBnkRecon.Size = New System.Drawing.Size(1009, 0)
        Me.CrRptVewBnkRecon.TabIndex = 0
        '
        'FrmCrRptReconcilePrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 0)
        Me.Controls.Add(Me.CrRptVewBnkRecon)
        Me.Name = "FrmCrRptReconcilePrint"
        Me.Text = "Bank Reconcile Summary Report"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptVewBnkRecon As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptBnkReconcile1 As FinAcct.CrRptBnkReconcile
End Class
